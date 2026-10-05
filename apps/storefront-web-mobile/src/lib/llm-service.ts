/**
 * LLM Service
 * 
 * Workload-aware Groq wrapper with automatic Qwen model-bucket fallback.
 * Settings (temperature, maxTokens, provider, persona) are loaded from admin config via Firestore.
 */

import { getAPIKeyManager } from "./api-key-manager";
import {
    LLMIntentResponse,
    LLMServiceError,
    APIKeyExhaustedError,
    LLMProvider
} from "@/types/assistant-types";
import type { Product, Category } from "@/app/actions";
import { getAIConfig } from "./ai-config";
import { validateCategoryId, validateRankings } from "./llm-validators";
import { getPrompt } from "./prompt-registry";
import {
    getGroqPrimaryModel,
    getGroqTextModelOrder,
    getGroqVisionModelOrder,
} from "./groq-config";
import { withAIResponseCache } from "./ai-response-cache";
import { z } from "zod";
import { SHOP_NAME } from "@/lib/shop-name";

// Extended intent response to include product requests
interface GenericIntentResponse extends LLMIntentResponse {
    requestProduct?: {
        name: string;
        description: string;
    } | null;
}

const intentResponseSchema = z.looseObject({
    category: z.string().max(300).nullable().default(null),
    subcategory: z.string().max(300).nullable().default(null),
    requirements: z.array(z.string().max(300)).max(30).nullish().transform(value => value ?? []),
    budgetMin: z.number().finite().nonnegative().nullable().default(null),
    budgetMax: z.number().finite().nonnegative().nullable().default(null),
    preferences: z.array(z.string().max(300)).max(30).nullish().transform(value => value ?? []),
    useCase: z.string().max(1_000).nullish().transform(value => value ?? ""),
    searchTerm: z.string().max(300).nullish().transform(value => value ?? null),
    confidence: z.number().finite().min(0).max(1).nullish().transform(value => value ?? 0.5),
    isGeneralChat: z.boolean().nullish().transform(value => value ?? false),
});

const rankingSchema = z.object({
    productId: z.string().min(1).max(200),
    matchScore: z.number().finite(),
    highlights: z.array(z.string().max(500)).max(10).default([]),
    whyRecommended: z.string().max(2_000).default(""),
});

const rankAndSummarySchema = z.object({
    rankings: z.array(rankingSchema).max(20),
    summary: z.string().max(5_000),
});
const rankingsSchema = z.array(rankingSchema).max(20);

const generalChatSchema = z.object({
    reply: z.string().min(1).max(5_000),
    suggestedActions: z.array(z.string().max(200)).max(8).nullish()
        .transform(value => value ?? undefined),
});

const MAX_RETRIES = 3;

// Default fallback values (overridden by admin config from Firestore)
const DEFAULT_TEMPERATURE = 0.7;
const DEFAULT_MAX_TOKENS = 2048;

const GROQ_API_BASE = "https://api.groq.com/openai/v1/chat/completions";
const GROQ_MODEL = getGroqPrimaryModel();
const GROQ_MODEL_WHISPER = process.env.GROQ_MODEL_WHISPER || "whisper-large-v3-turbo";


const GROQ_AUDIO_BASE = "https://api.groq.com/openai/v1/audio/transcriptions";

/**
 * Options for LLM calls — allows overriding default temperature and maxTokens.
 * When not provided, values are loaded from admin config.
 */
export interface LLMCallOptions {
    temperature?: number;
    maxTokens?: number;
    provider?: LLMProvider | "auto";
    model?: string;
    cacheTtlSeconds?: number;
    cacheNamespace?: string;
    responseFormat?: "json_object";
}

interface GroqResponse {
    choices?: Array<{
        message?: {
            content?: string;
        };
        finish_reason?: string;
    }>;
    error?: {
        code: string | number;
        message: string;
    };
}

/**
 * Make a request to Groq API
 */
async function callSingleGroqModel(
    prompt: string,
    model: string,
    options?: LLMCallOptions,
    apiKeyOverride?: string
): Promise<string> {
    const keyManager = getAPIKeyManager();
    const apiKey = apiKeyOverride || keyManager.getActiveKey("groq");

    // Use provided options, fallback to defaults
    const temperature = options?.temperature ?? DEFAULT_TEMPERATURE;
    const maxTokens = options?.maxTokens ?? DEFAULT_MAX_TOKENS;

    try {
        const response = await fetch(GROQ_API_BASE, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${apiKey}`
            },
            body: JSON.stringify({
                model: model,
                messages: [
                    { role: "user", content: prompt }
                ],
                temperature,
                max_tokens: maxTokens,
                top_p: 1,
                ...(options?.responseFormat
                    ? { response_format: { type: options.responseFormat } }
                    : {}),
            }),
        });

        if (response.status === 429) {
            // Groq quotas are model-scoped. Do not cool down the credential:
            // the same key remains valid for the fallback model's bucket.
            throw new LLMServiceError(`Groq model ${model} is rate limited`, 429);
        }

        if (!response.ok) {
            const errorText = await response.text();
            console.error(`[LLMService] Groq Error Body: ${errorText}`);

            // Handle terminal errors (Unauthorized or Leaked)
            if (response.status === 401 || response.status === 403) {
                keyManager.markKeyInvalid(apiKey);
                throw new LLMServiceError(`Groq API key is invalid or unauthorized: ${response.status}`, response.status);
            }

            if (response.status >= 400 && response.status < 500) {
                throw new LLMServiceError(
                    `Groq model ${model} request failed: ${response.statusText} - ${errorText}`,
                    response.status
                );
            }

            keyManager.markKeyFailed(apiKey);
            throw new LLMServiceError(`Groq model ${model} request failed: ${response.statusText} - ${errorText}`, response.status);
        }

        const data: GroqResponse = await response.json();

        if (data.error) {
            keyManager.markKeyFailed(apiKey);
            throw new LLMServiceError(data.error.message, typeof data.error.code === 'number' ? data.error.code : 500);
        }

        const text = data.choices?.[0]?.message?.content;
        if (!text) {
            throw new LLMServiceError("No response text from Groq");
        }

        keyManager.markKeySuccess(apiKey);
        return text;
    } catch (error) {
        if (error instanceof LLMServiceError || error instanceof APIKeyExhaustedError) throw error;

        keyManager.markKeyFailed(apiKey);
        throw new LLMServiceError(`Unexpected Groq ${model} error: ${error instanceof Error ? error.message : "Unknown"}`);
    }
}

function isGroqModelRateLimit(error: unknown): boolean {
    return error instanceof LLMServiceError && error.isRateLimited;
}

function isGroqCredentialRejection(error: unknown): boolean {
    return error instanceof LLMServiceError &&
        (error.statusCode === 401 || error.statusCode === 403);
}

/**
 * Groq limits are primarily model-bucket scoped, so each credential first
 * walks the intelligence-ordered model list. If every bucket on that
 * credential is limited, the whole ladder is retried with the next configured
 * Groq credential. This preserves Qwen quality before reserve models while
 * still using independently configured keys when they are available.
 */
async function runGroqModelRouter<T>(options: {
    models: string[];
    label: string;
    attempt: (model: string, apiKey: string) => Promise<T>;
}): Promise<T> {
    const keyManager = getAPIKeyManager();
    const keyPasses = Math.max(1, keyManager.getKeyCount("groq"));
    let lastError: unknown;

    for (let keyAttempt = 0; keyAttempt < keyPasses; keyAttempt++) {
        const apiKey = keyManager.getActiveKey("groq");
        let allModelBucketsLimited = true;
        let credentialRejected = false;

        for (const model of options.models) {
            try {
                return await options.attempt(model, apiKey);
            } catch (error) {
                lastError = error;
                allModelBucketsLimited &&= isGroqModelRateLimit(error);
                credentialRejected ||= isGroqCredentialRejection(error);
                console.warn(
                    `[LLMService] ${options.label} model ${model} failed; trying the next model bucket`,
                    error
                );

                // An authentication rejection already removes this credential
                // from the key manager, so begin the next ladder with a fresh
                // key rather than wasting the remaining models on it.
                if (credentialRejected) break;
            }
        }

        if (allModelBucketsLimited) {
            keyManager.markKeyRateLimited(apiKey);
            console.warn(
                `[LLMService] All ${options.label} model buckets are limited for one credential; trying the next configured Groq key`
            );
            continue;
        }

        if (credentialRejected) continue;

        // A model output or request problem that is not a rate limit has
        // already tried every lower model. Retrying it with another key is not
        // useful and could hide a real configuration error.
        break;
    }

    throw lastError instanceof Error
        ? lastError
        : new LLMServiceError(`All configured Groq ${options.label} models failed`);
}

/**
 * Groq text router. A failure in one model bucket advances to the next model
 * while retaining the same API key. Successful results are cached by the exact
 * prompt, generation settings, and ordered model list.
 */
async function callGroqAPI(
    prompt: string,
    preferredModel: string = GROQ_MODEL,
    options?: LLMCallOptions
): Promise<string> {
    const models = getGroqTextModelOrder(preferredModel);
    const ttlSeconds = options?.cacheTtlSeconds ?? Number(process.env.GROQ_TEXT_CACHE_TTL_SECONDS || 300);
    const fingerprint = {
        prompt,
        models,
        temperature: options?.temperature ?? DEFAULT_TEMPERATURE,
        maxTokens: options?.maxTokens ?? DEFAULT_MAX_TOKENS,
    };

    return withAIResponseCache({
        namespace: options?.cacheNamespace || "groq:text",
        fingerprint,
        ttlSeconds,
        generate: async () => {
            return runGroqModelRouter({
                models,
                label: "text",
                attempt: (model, apiKey) => callSingleGroqModel(prompt, model, options, apiKey),
            });
        },
    });
}

/**
 * Reasoning models (for example google/gemini-2.5-flash) bill their thinking
 * tokens against max_tokens, and that thinking scales with image complexity.
 * A budget sized only for the ~20-token answer gets consumed entirely by
 * reasoning on real camera photos, leaving a truncated query or an empty
 * response. This leaves headroom for thinking plus the answer.
 */
const VISION_MAX_TOKENS = 1500;

const PRODUCT_VISION_PROMPT = "Identify the main purchasable product in this image. Read any visible brand or model text, then return ONLY a concise catalog search query containing the product type and 2-4 distinguishing attributes such as brand, color, material, pattern, or style. No preamble.";
const PRODUCT_INDEX_VISION_PROMPT = `Analyze the main purchasable product for a private store search index.
Read exact visible brand, model, variant, size, color, material, pattern, product type, and packaging text.
Return ONE concise semicolon-separated line of searchable facts only.
Do not guess facts that are not visible. Do not include a preamble or markdown.`;

function parseImageData(base64Image: string): { dataUrl: string; cleanBase64: string; mimeType: string } {
    const dataUrlMatch = base64Image.match(/^data:(image\/[\w.+-]+);base64,([\s\S]+)$/);
    if (dataUrlMatch) {
        return {
            dataUrl: base64Image,
            cleanBase64: dataUrlMatch[2],
            mimeType: dataUrlMatch[1],
        };
    }

    return {
        dataUrl: `data:image/jpeg;base64,${base64Image}`,
        cleanBase64: base64Image,
        mimeType: "image/jpeg",
    };
}

async function callSingleGroqVisionModel(
    imageUrl: string,
    prompt: string,
    model: string,
    apiKeyOverride?: string
): Promise<string> {
    const keyManager = getAPIKeyManager();
    const apiKey = apiKeyOverride || keyManager.getActiveKey("groq");

    try {
        const response = await fetch(GROQ_API_BASE, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${apiKey}`,
            },
            body: JSON.stringify({
                model,
                messages: [{
                    role: "user",
                    content: [
                        { type: "text", text: prompt },
                        {
                            type: "image_url",
                            image_url: { url: imageUrl, detail: "auto" },
                        },
                    ],
                }],
                temperature: 0.1,
                max_tokens: VISION_MAX_TOKENS,
            }),
        });

        if (response.status === 429) {
            // The same key remains usable against the next model's bucket.
            throw new LLMServiceError(`Groq vision model ${model} is rate limited`, 429);
        }

        if (!response.ok) {
            const errorText = await response.text();
            if (response.status === 401 || response.status === 403) {
                keyManager.markKeyInvalid(apiKey);
            } else if (response.status >= 500) {
                keyManager.markKeyFailed(apiKey);
            }
            throw new LLMServiceError(
                `Groq vision model ${model} failed: ${response.statusText} - ${errorText}`,
                response.status
            );
        }

        const data: GroqResponse = await response.json();
        const choice = data.choices?.[0];
        const text = choice?.message?.content?.trim();

        if (!text) {
            throw new LLMServiceError(`No response from Groq vision model ${model}`);
        }
        if (choice?.finish_reason === "length") {
            throw new LLMServiceError(`Groq vision model ${model} truncated its response`);
        }

        keyManager.markKeySuccess(apiKey);
        return text;
    } catch (error) {
        if (error instanceof LLMServiceError || error instanceof APIKeyExhaustedError) throw error;
        keyManager.markKeyFailed(apiKey);
        throw new LLMServiceError(
            `Unexpected Groq vision ${model} error: ${error instanceof Error ? error.message : "Unknown"}`
        );
    }
}

async function callGroqVisionRouter(options: {
    imageUrl: string;
    prompt: string;
    cacheNamespace: string;
    cacheSalt?: string;
    cacheTtlSeconds?: number;
}): Promise<string> {
    const models = getGroqVisionModelOrder();
    const fingerprint = {
        imageUrl: options.imageUrl,
        prompt: options.prompt,
        models,
        cacheSalt: options.cacheSalt || "",
    };

    return withAIResponseCache({
        namespace: options.cacheNamespace,
        fingerprint,
        ttlSeconds: options.cacheTtlSeconds ?? 30 * 24 * 60 * 60,
        generate: async () => {
            return runGroqModelRouter({
                models,
                label: "vision",
                attempt: (model, apiKey) => callSingleGroqVisionModel(
                    options.imageUrl,
                    options.prompt,
                    model,
                    apiKey
                ),
            });
        },
    });
}

/**
 * Product image analysis through Groq's model-specific Qwen buckets.
 */
export async function callVisionAPI(base64Image: string): Promise<string> {
    const { dataUrl } = parseImageData(base64Image);
    return callGroqVisionRouter({
        imageUrl: dataUrl,
        prompt: PRODUCT_VISION_PROMPT,
        cacheNamespace: "groq:vision-search",
    });
}

/** Enriches a product's search embedding with facts visible only in its image. */
export async function analyzeProductImageForIndex(
    imageUrl: string,
    cacheSalt: string
): Promise<string> {
    if (!/^https:\/\//i.test(imageUrl)) {
        throw new LLMServiceError("Product image indexing requires an HTTPS image URL", 400);
    }

    const result = await callGroqVisionRouter({
        imageUrl,
        prompt: PRODUCT_INDEX_VISION_PROMPT,
        cacheNamespace: "groq:product-image-index",
        cacheSalt,
    });

    return result.replace(/\s+/g, " ").trim().slice(0, 1_500);
}


/**
 * Make a request to Groq Whisper API
 */
export async function callGroqWhisperAPI(audioFormData: FormData, retryCount: number = 0): Promise<string> {
    const keyManager = getAPIKeyManager();
    let apiKey: string;

    try {
        apiKey = keyManager.getActiveKey("groq");
    } catch (error) {
        throw error;
    }

    try {
        // Append model if not present, though usually caller might append it? 
        // Better to append here to enforce model choice.
        if (!audioFormData.has("model")) {
            audioFormData.append("model", GROQ_MODEL_WHISPER);
        }

        const response = await fetch(GROQ_AUDIO_BASE, {
            method: "POST",
            headers: {
                "Authorization": `Bearer ${apiKey}`
                // Content-Type is set automatically with boundary by fetch when body is FormData
            },
            body: audioFormData,
        });

        if (response.status === 429) {
            keyManager.markKeyRateLimited(apiKey);
            if (retryCount < MAX_RETRIES) return callGroqWhisperAPI(audioFormData, retryCount + 1);
            throw new LLMServiceError("Rate limit exceeded on Groq keys", 429);
        }

        if (!response.ok) {
            const errorText = await response.text();
            console.error(`[LLMService] Groq Whisper Error: ${errorText}`);
            keyManager.markKeyFailed(apiKey);
            if (retryCount < MAX_RETRIES) return callGroqWhisperAPI(audioFormData, retryCount + 1);
            throw new LLMServiceError(`Groq Whisper API failed: ${response.statusText}`, response.status);
        }

        const data: { text?: string } = await response.json();

        if (!data.text) {
            throw new LLMServiceError("No text in Whisper response");
        }

        keyManager.markKeySuccess(apiKey);
        return data.text.trim();

    } catch (error) {
        if (error instanceof LLMServiceError || error instanceof APIKeyExhaustedError) throw error;
        keyManager.markKeyFailed(apiKey);
        if (retryCount < MAX_RETRIES) return callGroqWhisperAPI(audioFormData, retryCount + 1);
        throw new LLMServiceError(`Unexpected Groq Whisper error: ${error instanceof Error ? error.message : "Unknown"}`);
    }
}

/**
 * Main LLM call function. Provider arguments remain accepted for backwards
 * compatibility with stored prompts/settings, but all text inference is now
 * intentionally routed through the Groq Qwen model sequence.
 */
async function callLLM(
    prompt: string,
    _provider: LLMProvider | "auto" = "auto",
    model?: string,
    options?: LLMCallOptions
): Promise<string> {
    void _provider;
    return callGroqAPI(prompt, model || GROQ_MODEL, options);
}

/**
 * LLM call with dynamic generation settings from admin configuration.
 * Provider priority is deliberately ignored because the shop now has one
 * LLM provider: Groq. Gemini remains isolated to vector embeddings only.
 */
async function callLLMWithConfig(prompt: string, overrideProvider?: LLMProvider | "auto", overrideModel?: string): Promise<string> {
    const config = await getAIConfig();

    const options: LLMCallOptions = {
        temperature: config.temperature,
        maxTokens: config.maxTokens,
    };

    return callLLM(prompt, overrideProvider || "groq", overrideModel || GROQ_MODEL, options);
}

/**
 * Parse JSON from LLM response, handling markdown code blocks and text around JSON
 */
function parseJSONFromResponse<T>(response: string): T {
    // Remove DeepSeek <think> tags if present to prevent JSON parse errors
    let cleaned = response.replace(/<think>[\s\S]*?<\/think>/g, "").trim();

    // Remove markdown code blocks if present
    if (cleaned.startsWith("```json")) {
        cleaned = cleaned.slice(7);
    } else if (cleaned.startsWith("```")) {
        cleaned = cleaned.slice(3);
    }
    if (cleaned.endsWith("```")) {
        cleaned = cleaned.slice(0, -3);
    }
    cleaned = cleaned.trim();

    // Attempt 1: Direct parse
    try {
        return JSON.parse(cleaned);
    } catch {
        // Attempt 2: Try to find a JSON object { ... } or array [ ... ] in the response
        const jsonObjectMatch = cleaned.match(/\{[\s\S]*\}/);
        if (jsonObjectMatch) {
            try {
                return JSON.parse(jsonObjectMatch[0]);
            } catch { /* fall through */ }
        }

        const jsonArrayMatch = cleaned.match(/\[[\s\S]*\]/);
        if (jsonArrayMatch) {
            try {
                return JSON.parse(jsonArrayMatch[0]);
            } catch { /* fall through */ }
        }

        throw new LLMServiceError(`Failed to parse LLM response as JSON: ${response.substring(0, 200)}...`);
    }
}

/**
 * Call LLM expecting JSON output. Retries once with a stricter prompt on parse failure.
 */
async function callLLMForJSON<T>(
    prompt: string,
    provider?: LLMProvider | "auto",
    model?: string,
    schema?: z.ZodType<T>
): Promise<T> {
    const parseAndValidate = (response: string): T => {
        const parsed = parseJSONFromResponse<unknown>(response);
        if (!schema) return parsed as T;

        const validated = schema.safeParse(parsed);
        if (!validated.success) {
            throw new LLMServiceError(`Failed to validate structured LLM response: ${z.prettifyError(validated.error).slice(0, 500)}`);
        }
        return validated.data;
    };

    void provider;
    const config = await getAIConfig();
    const models = getGroqTextModelOrder(model || GROQ_MODEL);
    const options: LLMCallOptions = {
        temperature: config.temperature,
        maxTokens: config.maxTokens,
        responseFormat: "json_object",
    };
    const ttlSeconds = Number(process.env.GROQ_TEXT_CACHE_TTL_SECONDS || 300);

    // Validation belongs inside the model loop. An HTTP 200 containing invalid
    // JSON is still a failed model attempt and must advance to the next bucket.
    return withAIResponseCache({
        namespace: "groq:structured",
        fingerprint: {
            prompt,
            models,
            temperature: options.temperature,
            maxTokens: options.maxTokens,
            schema: "validated-json-v1",
        },
        ttlSeconds,
        generate: async () => {
            return runGroqModelRouter({
                models,
                label: "structured",
                attempt: async (currentModel, apiKey) => {
                    const response = await callSingleGroqModel(
                        prompt,
                        currentModel,
                        options,
                        apiKey
                    );
                    return parseAndValidate(response);
                },
            });
        },
    });
}

/**
 * Analyze user query to extract intent
 */
export async function analyzeIntent(
    query: string,
    categories: Category[],
    messages: Array<{ role: string; content: string }> = [],
    provider: LLMProvider | "auto" = "groq"
): Promise<LLMIntentResponse> {
    const categoryMap = new Map<string, { name: string; children: string[] }>();
    categories.forEach(c => {
        if (!c.parentId) {
            categoryMap.set(c.id, { name: c.name, children: [] });
        }
    });
    categories.forEach(c => {
        if (c.parentId && categoryMap.has(c.parentId)) {
            categoryMap.get(c.parentId)!.children.push(`${c.name} (Sub ID: ${c.id})`);
        } else if (c.parentId) {
            // Edge case: if parentId is not in the list for some reason, treat as top level or ignore
            // For precision, let's just ignore or add if needed.
        }
    });

    const categoryList = Array.from(categoryMap.entries())
        .map(([id, data]) => {
            const children = data.children.length > 0
                ? `\n  - Subcategories: ${data.children.join(", ")}`
                : "";
            return `- ${data.name} (ID: ${id})${children}`;
        })
        .join("\n");

    const validCategoryIds = new Set(categories.map(c => c.id));

    const conversationContext = messages.length > 0
        ? messages.map(m => `${m.role.toUpperCase()}: ${m.content}`).join("\n")
        : "No previous history.";

    const prompt = await getPrompt("intent-analyze", {
        categoryList,
        query,
        conversationContext
    });

    const result = await callLLMForJSON<GenericIntentResponse>(
        prompt,
        provider,
        undefined,
        intentResponseSchema as z.ZodType<GenericIntentResponse>
    );

    // Validate category ID against real categories to prevent hallucination
    result.category = validateCategoryId(result.category, validCategoryIds);
    result.subcategory = validateCategoryId(result.subcategory, validCategoryIds);

    return result;
}

/**
 * Score and rank products for the user's needs
 */
export async function rankProducts(
    query: string,
    products: Product[],
    intent: LLMIntentResponse,
    provider: LLMProvider | "auto" = "groq"
): Promise<Array<{ productId: string; matchScore: number; highlights: string[]; whyRecommended: string }>> {
    if (products.length === 0) {
        return [];
    }

    const config = await getAIConfig();
    const persona = config.personaName;
    const validProductIds = new Set(products.map(p => p.id));

    const productList = products.map(p => ({
        id: p.id,
        name: p.name,
        description: p.description,
        price: p.price,
        tags: p.tags,
    }));

    const prompt = `Hi, I'm ${persona}, your personal Shopping Master at {SHOP_NAME}.

Customer query: "${query}"

Intent analysis:
- Use case: ${intent.useCase}
- Requirements: ${intent.requirements.join(", ") || "none specified"}
- Preferences: ${intent.preferences.join(", ") || "none specified"}
- Budget: ${intent.budgetMin ? `₹${intent.budgetMin}` : "any"} - ${intent.budgetMax ? `₹${intent.budgetMax}` : "any"}

Available products:
${JSON.stringify(productList, null, 2)}

Rank the top 3-5 most suitable products for this customer. For each product, explain why it matches their needs.

CRITICAL INSTRUCTIONS:
1. You must ONLY recommend products from the "Available products" list provided above.
2. Do NOT mention, suggest, or hallucinate any products that are not in the list.
3. If the list is empty, return an empty array. Do NOT invent a product.

Respond with a JSON array (and nothing else) in this exact format:
[
  {
    "productId": "the product ID",
    "matchScore": 0-100 indicating how well it matches,
    "highlights": ["key features that match their needs"],
    "whyRecommended": "A 1-2 sentence explanation of why this product is recommended"
  }
]

Only include products that are relevant. If no products match well, return an empty array.`;

    const rankings = await callLLMForJSON<Array<{ productId: string; matchScore: number; highlights: string[]; whyRecommended: string }>>(
        prompt,
        provider,
        undefined,
        rankingsSchema
    );

    // Validate product IDs to prevent hallucination
    return validateRankings(rankings, validProductIds);
}

/**
 * Generate a summary response for the user
 */
export async function generateSummary(
    query: string,
    recommendationCount: number,
    topProductName: string | null,
    provider: LLMProvider | "auto" = "groq"
): Promise<string> {
    if (recommendationCount === 0) {
        return "I couldn't find specific products matching your requirements. Could you provide more details about what you're looking for?";
    }

    const config = await getAIConfig();
    const persona = config.personaName;

    const prompt = `Hi, I'm ${persona}, your personal Shopping Master at {SHOP_NAME}.

Customer asked: "${query}"

You found ${recommendationCount} product recommendation(s)${topProductName ? `, with "${topProductName}" being the top match` : ""}.

Write a brief, friendly 1-2 sentence summary to introduce the recommendations. Be helpful and conversational as ${persona}. Do not use markdown formatting.`;

    const response = await callLLMWithConfig(prompt, provider);
    return response.trim().replace(/```/g, "").replace(/^["']|["']$/g, "");
}

/**
 * Generate a response when no products are found
 * The AI should offer to take a request and ask for details like price
 */
export async function generateNoProductFoundResponse(
    query: string,
    intent: LLMIntentResponse,
    provider: LLMProvider | "auto" = "groq"
): Promise<string> {
    const config = await getAIConfig();
    const persona = config.personaName;

    const prompt = `${config.systemPrompt}

CRITICAL INSTRUCTION:
- You MUST detect the language of the Customer Query.
- You MUST reply in the SAME language as the query (Hindi, Urdu, Hinglish, or English).
- Be the helpful Master ${persona}.

Customer query: "${query}"

Intent analysis:
- Product wanted: ${intent.category || intent.subcategory || "unknown product"}
- Use case: ${intent.useCase}
- Requirements: ${intent.requirements.join(", ") || "none specified"}

We do NOT have this product in stock right now.
1. Apologize that we don't have it currently.
2. STRICTLY DO NOT invent, hallucinate, or offer any product that you don't have context for.
3. Offer to note down their request as their Shopping Master.
4. Crucially, ask for their TARGET PRICE or BUDGET if they haven't provided it.
5. Ask for any other specific details (color, size, brand) if relevant.

Keep it concise (2-3 sentences max).`;

    const response = await callLLMWithConfig(prompt, provider);
    return response.trim().replace(/```/g, "").replace(/^["']|["']$/g, "");
}

/**
 * Handle scenarios where a requested product is missing.
 * Determine if we have enough info to request it, or if we need to ask the user.
 */
export async function handleMissingProduct(
    query: string,
    intent: LLMIntentResponse,
    messages: Array<{ role: string; content: string }> = [],
    provider: LLMProvider | "auto" = "groq"
): Promise<{
    action: "request" | "ask_details";
    response: string;
    requestData?: {
        name: string;
        category?: string;
        maxBudget?: number;
        specifications?: string[];
    };
}> {
    const config = await getAIConfig();
    const persona = config.personaName;
    const history = messages.length > 0
        ? `Conversation History:\n${messages.map(m => `${m.role.toUpperCase()}: ${m.content}`).join("\n")}\n\n`
        : "";

    const productName = intent.category || intent.subcategory || query;

    const prompt = `${config.systemPrompt}
    
${history}Customer Query: "${query}"

Context: The customer is interested in "${productName}", but we DO NOT have this product in stock.
As their Master, I want to inform them politely that we don't have it.

Decision Logic:
1. Apologize that we don't have exactly what they're looking for.
2. If they haven't provided a budget, ask for it so we can help them find alternatives in the future (without promising a specific request).
3. Be friendly as ${persona}.

Output a JSON object:
{
  "action": "ask_details",
  "response": "The text response to the user. Say 'We don't have [Product] right now. What is your budget/preference so I can assist you better?'"
}`;

    try {
        const result = await callLLMForJSON<{
            action: "request" | "ask_details";
            response: string;
            requestData?: {
                name: string;
                category?: string;
                maxBudget?: number | string;
                specifications?: string[];
            };
        }>(prompt, provider);

        // Sanitize maxBudget to ensure it's a number
        if (result.requestData) {
            if (typeof result.requestData.maxBudget === 'string') {
                const parsed = parseFloat(result.requestData.maxBudget);
                result.requestData.maxBudget = isNaN(parsed) ? 0 : parsed;
            } else if (typeof result.requestData.maxBudget !== 'number') {
                result.requestData.maxBudget = 0;
            }
        }

        return result as {
            action: "request" | "ask_details";
            response: string;
            requestData?: {
                name: string;
                category?: string;
                maxBudget?: number;
                specifications?: string[];
            };
        };
    } catch (error) {
        // Graceful fallback: if JSON parsing completely fails, return a helpful response
        // instead of crashing the entire recommendation pipeline
        console.error("[handleMissingProduct] Failed to parse LLM response, using fallback:", error);

        const fallbackProductName = intent.category || intent.subcategory || query;
        return {
            action: "ask_details" as const,
            response: `Hi, I'm ${persona}. We don't currently have "${fallbackProductName}" in stock. As your Shopping Master, I'd love to help you find alternatives! Could you share your preferred budget or any other details?`,
        };
    }
}

/**
 * Combined ranking and summary generation in a single LLM call
 * Reduces API calls from 3 to 2 for better performance
 */
export async function rankAndSummarize(
    query: string,
    products: Product[],
    intent: LLMIntentResponse,
): Promise<{
    rankings: Array<{ productId: string; matchScore: number; highlights: string[]; whyRecommended: string }>;
    summary: string;
}> {
    if (products.length === 0) {
        return {
            rankings: [],
            summary: "I couldn't find specific products matching your requirements. Could you provide more details about what you're looking for?",
        };
    }

    const config = await getAIConfig();
    const persona = config.personaName;
    const validProductIds = new Set(products.map(p => p.id));

    const productList = products.map(p => ({
        id: p.id,
        name: p.name,
        description: p.description,
        price: p.price,
        tags: p.tags,
    }));

    const prompt = `${config.systemPrompt}

CRITICAL INSTRUCTION:
- You MUST reply in the SAME language as the query (English, Hindi, Urdu, or Hinglish).
- Be charming and speak as ${persona}, the Shopping Master.

Customer query: "${query}"

Intent analysis:
- Use case: ${intent.useCase}
- Requirements: ${intent.requirements.join(", ") || "none specified"}
- Preferences: ${intent.preferences.join(", ") || "none specified"}
- Budget: ${intent.budgetMin ? `₹${intent.budgetMin}` : "any"} - ${intent.budgetMax ? `₹${intent.budgetMax}` : "any"}

Available products:
${JSON.stringify(productList, null, 2)}

Respond with a JSON object (and nothing else) in this exact format:
{
  "rankings": [
    {
      "productId": "the product ID",
      "matchScore": 0-100 indicating how well it matches,
      "highlights": ["key features that match their needs"],
      "whyRecommended": "A persuasive 1-2 sentence pitch for this product"
    }
  ],
  "summary": "A creative, charming, and persuasive summary for the customer, in their language"
}

CRITICAL:
1. You must ONLY recommend products from the "Available products" list provided above.
2. If "Available products" is empty array [], you MUST return empty rankings [].
3. In the summary, if no products are found, say "I couldn't find exactly that in our current collection, but I can take a request for it!"
4. Do NOT make up products.

Only include relevant products. If no products match well, return empty rankings.`;

    const result = await callLLMForJSON<{
        rankings: Array<{ productId: string; matchScore: number; highlights: string[]; whyRecommended: string }>;
        summary: string;
    }>(prompt, "groq", GROQ_MODEL, rankAndSummarySchema);

    // Validate product IDs to prevent hallucination
    result.rankings = validateRankings(result.rankings, validProductIds);

    return result;
}

/**
 * AI Sentiment Summarizer: Generates a Pros & Cons summary from customer reviews
 */
export async function summarizeReviews(
    productName: string,
    reviews: { rating: number; comment: string }[]
): Promise<{ pros: string[]; cons: string[]; summary: string }> {
    if (reviews.length === 0) {
        return { pros: [], cons: [], summary: "No reviews available yet for this product." };
    }

    const reviewText = reviews.map(r => `Rating: ${r.rating}/5, Comment: ${r.comment}`).join("\n---\n");

    const prompt = await getPrompt("review-summarizer", {
        productName,
        reviewText
    });

    return await callLLMForJSON<{ pros: string[]; cons: string[]; summary: string }>(
        prompt,
        "groq",
        GROQ_MODEL
    );
}

/**
 * Smart Deal Explainer: Explains why a specific deal/price is a "catch" for the user
 */
export async function generateDealExplanation(
    product: { name: string; price: number; originalPrice?: number; description: string },
    userIntent?: string
): Promise<string> {
    const savings = product.originalPrice ? product.originalPrice - product.price : 0;
    const savingsPercent = product.originalPrice ? Math.round((savings / product.originalPrice) * 100) : 0;

    const prompt = `You are a charismatic sales associate at {SHOP_NAME}.
Explain why the current deal on "${product.name}" is amazing for the customer.

Product Info:
- Current Price: ₹${product.price}
- Original Price: ${product.originalPrice ? `₹${product.originalPrice}` : "N/A"}
- Savings: ${savings > 0 ? `₹${savings} (${savingsPercent}% off)` : "Best value in category"}
${userIntent ? `- User's Goal: ${userIntent}` : ""}

Provide a persuasive, 1-2 sentence "pitch" that makes the user feel they are getting a great deal. Be friendly and culturally relevant to India.`;

    // Use light model for simple creative text
    const response = await callGroqAPI(prompt);
    return response.trim().replace(/^["']|["']$/g, "");
}

/**
 * AI Social Proof Generator: Generates trending snippets for products
 */
export async function generateSocialProof(
    product: { name: string; categoryId: string; tags: string[] },
    salesStats?: { salesInLastMonth: number; popularInCity?: string }
): Promise<string> {
    const stats = salesStats ? `${salesStats.salesInLastMonth} people bought this recently${salesStats.popularInCity ? ` in ${salesStats.popularInCity}` : ""}` : "Currently trending";

    const prompt = await getPrompt("social-proof", {
        productName: product.name,
        categoryId: product.categoryId,
        stats
    });

    const response = await callGroqAPI(prompt);
    return response.trim().replace(/^["']|["']$/g, "");
}

/**
 * AI Deal Explainer: Explains *why* a deal is good or the product value
 */
export async function generateDealInsight(
    product: { name: string; price: number; originalPrice?: number; description: string }
): Promise<string> {
    const discount = product.originalPrice
        ? Math.round(((product.originalPrice - product.price) / product.originalPrice) * 100)
        : 0;

    const prompt = await getPrompt("deal-insight", {
        productName: product.name,
        price: product.price,
        discount: discount > 0 ? `(was ₹${product.originalPrice}, ${discount}% OFF)` : "",
        description: product.description.substring(0, 100) + "..."
    });

    // Using Llama 3.1 8B for fast, snappy copy
    const response = await callGroqAPI(prompt, GROQ_MODEL);
    return response.trim().replace(/^["']|["']$/g, "");
}

/**
 * AI Personal Stylist: Generates outfit recommendations based on user preferences and occasion
 */
export async function generateStylistAdvice(
    userPreferences: {
        gender: string;
        style: string;
        occasion: string;
        budget?: string;
        colors?: string[];
    },
    products: Product[] = []
): Promise<{
    advice: string;
    suggestedOutfit: {
        top?: string;
        bottom?: string;
        shoes?: string;
        accessory?: string;
        reasoning: string
    }
}> {
    const config = await getAIConfig();
    const persona = config.personaName;

    // Map of product IDs to full products for easy lookup later
    const validProducts = new Map(products.map(p => [p.id, p]));

    const productList = products.map(p => ({
        id: p.id,
        name: p.name,
        category: p.categoryId,
        price: p.price,
        colors: p.tags
    }));

    const prompt = await getPrompt("stylist", {
        persona,
        gender: userPreferences.gender,
        style: userPreferences.style,
        occasion: userPreferences.occasion,
        budget: userPreferences.budget || "Flexible",
        colors: userPreferences.colors?.join(", ") || "Any",
        productList: JSON.stringify(productList, null, 2)
    });

    // Advanced styling uses the primary Groq Qwen model.
    const result = await callLLMForJSON<{
        advice: string;
        suggestedOutfit: {
            top?: string;
            bottom?: string;
            shoes?: string;
            accessory?: string;
            reasoning: string
        }
    }>(prompt, "groq", GROQ_MODEL);

    // Map IDs back to product names to satisfy the UI without requiring frontend changes, 
    // while ensuring strict catalog validation (removing hallucinations).
    if (result.suggestedOutfit) {
        if (result.suggestedOutfit.top && validProducts.has(result.suggestedOutfit.top)) {
            result.suggestedOutfit.top = validProducts.get(result.suggestedOutfit.top)?.name;
        } else {
            result.suggestedOutfit.top = undefined;
        }

        if (result.suggestedOutfit.bottom && validProducts.has(result.suggestedOutfit.bottom)) {
            result.suggestedOutfit.bottom = validProducts.get(result.suggestedOutfit.bottom)?.name;
        } else {
            result.suggestedOutfit.bottom = undefined;
        }

        if (result.suggestedOutfit.shoes && validProducts.has(result.suggestedOutfit.shoes)) {
            result.suggestedOutfit.shoes = validProducts.get(result.suggestedOutfit.shoes)?.name;
        } else {
            result.suggestedOutfit.shoes = undefined;
        }

        if (result.suggestedOutfit.accessory && validProducts.has(result.suggestedOutfit.accessory)) {
            result.suggestedOutfit.accessory = validProducts.get(result.suggestedOutfit.accessory)?.name;
        } else {
            result.suggestedOutfit.accessory = undefined;
        }
    }

    return result;
}

/**
 * Gift Concierge: Recommends gifts based on recipient persona
 */
export async function generateGiftRecommendations(
    recipient: {
        relation: string;
        age: string;
        interests: string[];
        occasion: string;
        budget: string;
    },
    products: Product[] = []
): Promise<{
    thoughtProcess: string;
    recommendations: Array<{ item: string; reason: string; category: string }>;
}> {
    const config = await getAIConfig();
    const persona = config.personaName;

    const validProducts = new Map(products.map(p => [p.id, p]));

    const productList = products.map(p => ({
        id: p.id,
        name: p.name,
        category: p.categoryId,
        price: p.price,
        description: p.description.substring(0, 100) + "..."
    }));

    const prompt = await getPrompt("gift-concierge", {
        persona,
        relation: recipient.relation,
        age: recipient.age,
        interests: recipient.interests.join(", "),
        occasion: recipient.occasion,
        budget: recipient.budget,
        productList: JSON.stringify(productList, null, 2)
    });

    // Advanced gift reasoning uses the primary Groq Qwen model.
    const result = await callLLMForJSON<{
        thoughtProcess: string;
        recommendations: Array<{ productId?: string; item?: string; reason: string; category: string }>;
    }>(prompt, "groq", GROQ_MODEL);

    // Validate IDs and map to product names for the frontend
    const validatedRecommendations = [];
    for (const rec of result.recommendations) {
        if (!rec.productId) continue;
        const product = validProducts.get(rec.productId);
        if (product) {
            validatedRecommendations.push({
                item: product.name,
                reason: rec.reason,
                category: rec.category || product.categoryId
            });
        }
    }

    return {
        thoughtProcess: result.thoughtProcess,
        recommendations: validatedRecommendations
    };
}

/**
 * Compare & Contrast: Analyzes two products side-by-side
 */
export async function generateProductComparison(
    product1: { name: string; price: number; description: string; features: string[] },
    product2: { name: string; price: number; description: string; features: string[] }
): Promise<{
    comparisonPoints: Array<{ feature: string; item1Value: string; item2Value: string; verdict: string }>;
    summary: string;
    recommendation: string;
}> {
    const prompt = await getPrompt("product-compare", {
        "product1.name": product1.name,
        "product1.price": product1.price.toString(),
        "product1.description": product1.description,
        "product1.features": product1.features.join(", "),
        "product2.name": product2.name,
        "product2.price": product2.price.toString(),
        "product2.description": product2.description,
        "product2.features": product2.features.join(", ")
    });

    // Advanced product comparison uses the primary Groq Qwen model.
    return await callLLMForJSON<{
        comparisonPoints: Array<{ feature: string; item1Value: string; item2Value: string; verdict: string }>;
        summary: string;
        recommendation: string;
    }>(prompt, "groq", GROQ_MODEL);
}

/**
 * Phase 4: Proactive Alerts
 */

/**
 * Out of Stock / Low Stock Urgency Generator
 */
export async function generateOOSUrgency(
    productName: string,
    sku: string,
    stockLevel: number,
    viewCount: number
): Promise<{ headline: string; subtext: string; urgencyLevel: "high" | "medium" | "low" }> {
    const prompt = await getPrompt("stock-urgency", {
        productName,
        sku,
        stockLevel: stockLevel.toString(),
        viewCount: viewCount.toString()
    });

    // Using Llama 3.1 8B (Light) for fast inference
    return await callLLMForJSON<{
        headline: string;
        subtext: string;
        urgencyLevel: "high" | "medium" | "low";
    }>(prompt, "groq", GROQ_MODEL);
}

/**
 * Restock Notification Message Generator
 */
export async function generateBackInStockMessage(
    productName: string,
    customerName: string
): Promise<{ subject: string; body: string; discountCode?: string }> {
    const prompt = `You are a customer loyalty bot for {SHOP_NAME}.
    Context:
    - Customer: ${customerName}
    - Item Back in Stock: ${productName}
    
    Task:
    Write a friendly, exciting notification message telling them their item is back.
    Suggest a small discount code 'WELCOMEBACK5' to nudge them.

    Response JSON:
    {
      "subject": "Email/Push subject line (Emojis allowed)",
      "body": "Warm, short, 2-sentence message.",
      "discountCode": "WELCOMEBACK5"
    }`;

    return await callLLMForJSON<{
        subject: string;
        body: string;
        discountCode?: string;
    }>(prompt, "groq", GROQ_MODEL);
}

/**
 * Phase 5: Interactive Features
 */

/**
 * Multilingual Local Language Assistant
 * Handles general queries, product advice, and store info in Indian context.
 */
export async function chatWithAssistant(
    message: string,
    history: { role: "user" | "assistant"; content: string }[]
): Promise<{ reply: string; suggestedActions?: string[] }> {
    const config = await getAIConfig();
    // Construct conversation history for context
    const conversationContext = history.map(msg => `${msg.role === "user" ? "Customer" : "Assistant"}: ${msg.content}`).join("\n");

    const prompt = await getPrompt("general-chat", {
        persona: config.personaName,
        conversationContext,
        message
    });

    // Using Llama 3.3 70B for high-quality multilingual chat
    return await callLLMForJSON<{
        reply: string;
        suggestedActions?: string[];
    }>(prompt, "groq", GROQ_MODEL, generalChatSchema);
}

/**
 * Translates a "Vibe" (abstract mood) into concrete product filters.
 */
export async function translateVibeToFilters(vibe: string): Promise<{
    searchQuery?: string;
    category?: string;
    colors?: string[];
    priceRange?: { min?: number; max?: number };
    sort?: "price_asc" | "price_desc" | "newest" | "rating";
    reasoning: string;
}> {
    const prompt = await getPrompt("vibe-translator", {
        vibe
    });

    // Semantic interpretation uses the primary Groq Qwen model.
    return await callLLMForJSON<{
        searchQuery?: string;
        category?: string;
        colors?: string[];
        priceRange?: { min?: number; max?: number };
        sort?: "price_asc" | "price_desc" | "newest" | "rating";
        reasoning: string;
    }>(prompt, "groq", GROQ_MODEL);
}
