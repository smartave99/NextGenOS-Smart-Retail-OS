/**
 * Embedding Service
 * 
 * Generates text embeddings using Google's current Gemini embedding model.
 * 
 * WHY GEMINI FOR EMBEDDINGS (not Groq):
 * - Groq does NOT offer embedding models — it's inference-only (LLMs).
 * - Groq remains the PRIMARY provider for ALL LLM work (intent, ranking, chat, styling).
 * - Gemini is used ONLY for this one embedding operation (text → vector).
 * - Uses the SAME Gemini API key already in .env (GEMINI_API_KEY_1) — NO new keys needed.
 * 
 * Cost: $0 — Gemini embedding API is free tier (1,500 RPM).
 * Vector dimensions: 768 (matches the pgvector column in Product table).
 * 
 * Provider hierarchy:
 *   LLM calls → Groq (primary) → Gemini (fallback)
 *   Embeddings → Gemini (only option, free, uses existing key)
 * 
 * @module embedding-service
 */


import { getAPIKeyManager } from "./api-key-manager";
import { LLMServiceError, APIKeyExhaustedError } from "@/types/assistant-types";

/** Gemini embedding model — free tier, 768 dimensions via MRL */
const GEMINI_EMBEDDING_MODEL = process.env.GEMINI_EMBEDDING_MODEL || "gemini-embedding-2";
const GEMINI_EMBEDDING_BASE = "https://generativelanguage.googleapis.com/v1beta/models";
const EMBEDDING_DIMENSIONS = 768;
const MAX_RETRIES = 3;

/** In-memory LRU cache for recent embeddings (avoids re-computing for repeated queries) */
const embeddingCache = new Map<string, { vector: number[]; timestamp: number }>();
const CACHE_TTL_MS = 10 * 60 * 1000; // 10 minutes
const MAX_CACHE_SIZE = 200;

/**
 * Response shape from Gemini Embedding API
 */
interface GeminiEmbeddingResponse {
    embedding?: {
        values?: number[];
    };
    error?: {
        code: number;
        message: string;
    };
}

/**
 * Generate an embedding vector for the given text using Gemini Embedding 2.
 * 
 * @param text - The text to embed (product name + description + tags)
 * @param useCache - Whether to use the in-memory cache (default: true)
 * @returns A 768-dimensional float vector
 * 
 * @example
 * ```ts
 * const vector = await generateEmbedding("Blue cotton shirt for office wear");
 * // Returns: [0.023, -0.145, 0.089, ...] (768 floats)
 * ```
 */
export async function generateEmbedding(text: string, useCache = true): Promise<number[]> {
    if (!text || text.trim().length === 0) {
        throw new LLMServiceError("Cannot generate embedding for empty text");
    }

    const normalizedText = text.trim().toLowerCase();

    // Check cache first
    if (useCache) {
        const cached = embeddingCache.get(normalizedText);
        if (cached && (Date.now() - cached.timestamp) < CACHE_TTL_MS) {
            return cached.vector;
        }
    }

    const vector = await callGeminiEmbeddingAPI(normalizedText);

    // Store in cache
    if (useCache) {
        // Evict oldest entries if cache is full
        if (embeddingCache.size >= MAX_CACHE_SIZE) {
            const oldestKey = embeddingCache.keys().next().value;
            if (oldestKey) embeddingCache.delete(oldestKey);
        }
        embeddingCache.set(normalizedText, { vector, timestamp: Date.now() });
    }

    return vector;
}

/**
 * Generate embeddings for multiple texts in a batch.
 * Processes sequentially to respect rate limits on free tier.
 * 
 * @param texts - Array of texts to embed
 * @param onProgress - Optional callback for progress updates
 * @returns Array of 768-dimensional vectors
 */
export async function generateEmbeddingsBatch(
    texts: string[],
    onProgress?: (completed: number, total: number) => void
): Promise<number[][]> {
    const results: number[][] = [];

    for (let i = 0; i < texts.length; i++) {
        try {
            const vector = await generateEmbedding(texts[i], false);
            results.push(vector);
        } catch (error) {
            console.error(`[EmbeddingService] Failed to embed text ${i + 1}/${texts.length}:`, error);
            // Push zero vector as fallback so indices stay aligned
            results.push(new Array(EMBEDDING_DIMENSIONS).fill(0));
        }

        onProgress?.(i + 1, texts.length);

        // Throttle to avoid hitting free tier rate limits (1,500 RPM = 25 RPS)
        // We'll be conservative with 50ms delay (~20 RPS)
        if (i < texts.length - 1) {
            await new Promise(resolve => setTimeout(resolve, 50));
        }
    }

    return results;
}

/**
 * Build the text representation of a product for embedding.
 * Combines name, description, and tags into a single string
 * optimized for semantic search.
 * 
 * @param product - Product data with name, description, and tags
 * @returns Formatted text for embedding
 */
export function buildProductEmbeddingText(product: {
    name: string;
    description: string;
    tags?: string[];
    highlights?: string[];
    categoryId?: string;
    subcategoryId?: string | null;
    barcode?: string | null;
    specifications?: unknown;
    visualDescription?: string;
}): string {
    const parts: string[] = [];

    // Name gets priority (repeated for emphasis)
    parts.push(product.name);

    // Description (truncated to keep embedding focused)
    if (product.description) {
        const desc = product.description.substring(0, 500);
        parts.push(desc);
    }

    // Tags provide categorical context
    if (product.tags && product.tags.length > 0) {
        parts.push(`Tags: ${product.tags.join(", ")}`);
    }

    // Highlights provide feature context
    if (product.highlights && product.highlights.length > 0) {
        parts.push(`Features: ${product.highlights.join(", ")}`);
    }

    if (product.categoryId) parts.push(`Category: ${product.categoryId}`);
    if (product.subcategoryId) parts.push(`Subcategory: ${product.subcategoryId}`);
    if (product.barcode) parts.push(`Barcode: ${product.barcode}`);

    if (product.specifications) {
        try {
            parts.push(`Specifications: ${JSON.stringify(product.specifications).slice(0, 1_200)}`);
        } catch {
            // Ignore malformed non-serializable values; core product text is enough.
        }
    }

    if (product.visualDescription) {
        parts.push(`Visible product details: ${product.visualDescription.slice(0, 1_500)}`);
    }

    return parts.join(". ");
}

/**
 * Call the Gemini Embedding API with automatic key rotation and retry logic.
 * 
 * @internal
 */
async function callGeminiEmbeddingAPI(text: string, retryCount = 0): Promise<number[]> {
    const keyManager = getAPIKeyManager();
    let apiKey: string;

    try {
        apiKey = keyManager.getActiveKey("google");
    } catch (error) {
        throw error;
    }

    const url = `${GEMINI_EMBEDDING_BASE}/${GEMINI_EMBEDDING_MODEL}:embedContent?key=${apiKey}`;

    try {
        const response = await fetch(url, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
                model: `models/${GEMINI_EMBEDDING_MODEL}`,
                content: {
                    parts: [{ text }]
                },
                outputDimensionality: EMBEDDING_DIMENSIONS,
            }),
        });

        // Handle rate limiting with key rotation
        if (response.status === 429) {
            keyManager.markKeyRateLimited(apiKey);
            if (retryCount < MAX_RETRIES) {
                console.log(`[EmbeddingService] Rate limited, retrying (attempt ${retryCount + 1})`);
                return callGeminiEmbeddingAPI(text, retryCount + 1);
            }
            throw new LLMServiceError("Rate limit exceeded on Gemini embedding keys", 429);
        }

        if (!response.ok) {
            const errorText = await response.text();
            console.error(`[EmbeddingService] Gemini Error: ${errorText}`);

            if (response.status === 401 || response.status === 403) {
                keyManager.markKeyInvalid(apiKey);
                throw new LLMServiceError(`Gemini API key invalid: ${response.status}`, response.status);
            }

            // Unsupported models and malformed requests are configuration
            // failures, not unhealthy credentials.
            if (response.status >= 400 && response.status < 500) {
                throw new LLMServiceError(
                    `Gemini embedding failed: ${response.statusText} - ${errorText}`,
                    response.status
                );
            }

            keyManager.markKeyFailed(apiKey);
            if (retryCount < MAX_RETRIES) {
                return callGeminiEmbeddingAPI(text, retryCount + 1);
            }
            throw new LLMServiceError(`Gemini embedding failed: ${response.statusText}`, response.status);
        }

        const data: GeminiEmbeddingResponse = await response.json();

        if (data.error) {
            keyManager.markKeyFailed(apiKey);
            throw new LLMServiceError(data.error.message, data.error.code);
        }

        const values = data.embedding?.values;
        if (!values || values.length === 0) {
            throw new LLMServiceError("No embedding values returned from Gemini");
        }

        keyManager.markKeySuccess(apiKey);
        return values;
    } catch (error) {
        if (error instanceof LLMServiceError || error instanceof APIKeyExhaustedError) throw error;

        keyManager.markKeyFailed(apiKey);
        if (retryCount < MAX_RETRIES) return callGeminiEmbeddingAPI(text, retryCount + 1);

        throw new LLMServiceError(
            `Unexpected embedding error: ${error instanceof Error ? error.message : "Unknown"}`
        );
    }
}

/**
 * Clear the embedding cache.
 * Useful after bulk operations or when cache might be stale.
 */
export function clearEmbeddingCache(): void {
    embeddingCache.clear();
    console.log("[EmbeddingService] Cache cleared");
}

/**
 * Get embedding cache statistics.
 */
export function getEmbeddingCacheStats(): { size: number; maxSize: number; ttlMs: number } {
    return {
        size: embeddingCache.size,
        maxSize: MAX_CACHE_SIZE,
        ttlMs: CACHE_TTL_MS,
    };
}
