/**
 * Vector Store Service
 * 
 * Provides semantic search capabilities using PostgreSQL's pgvector extension.
 * Uses the existing `embedding` column on the Product table (vector(768)).
 * 
 * Operations:
 * - Store embeddings for products
 * - Semantic similarity search (cosine distance)
 * - Bulk reindex all products
 * - Check embedding coverage stats
 * 
 * Cost: $0 — Uses existing PostgreSQL database with pgvector extension.
 * 
 * @module vector-store
 */

import { getWriteClient } from "./db-manager";
import { 
    generateEmbedding, 
    buildProductEmbeddingText 
} from "./embedding-service";
import type { Product } from "@/app/actions";

/**
 * Result from a semantic similarity search.
 */
export interface SemanticSearchResult {
    productId: string;
    similarity: number; // 0-1, higher = more similar
}

/**
 * RAG index status for admin monitoring.
 */
export interface RAGIndexStatus {
    totalProducts: number;
    embeddedProducts: number;
    coveragePercent: number;
    lastIndexedAt: string | null;
}

/**
 * Store an embedding vector for a specific product.
 * Uses raw SQL because Prisma doesn't natively support pgvector operations.
 * 
 * @param productId - The product's UUID
 * @param embedding - A 768-dimensional float vector
 * 
 * @example
 * ```ts
 * const vector = await generateEmbedding("Blue cotton shirt");
 * await storeProductEmbedding("product-uuid", vector);
 * ```
 */
export async function storeProductEmbedding(
    productId: string,
    embedding: number[]
): Promise<void> {
    const client = getWriteClient();
    const vectorStr = `[${embedding.join(",")}]`;

    try {
        await client.$executeRawUnsafe(
            `UPDATE "Product" SET embedding = $1::vector WHERE id = $2`,
            vectorStr,
            productId
        );
    } catch (error) {
        console.error(`[VectorStore] Failed to store embedding for product ${productId}:`, error);
        throw error;
    }
}

/** Remove an outdated vector before rebuilding a product's search index. */
export async function clearProductEmbedding(productId: string): Promise<void> {
    const client = getWriteClient();
    await client.$executeRawUnsafe(
        `UPDATE "Product" SET embedding = NULL WHERE id = $1`,
        productId
    );
}

/**
 * Generate and store an embedding for a product.
 * Convenience function that combines text building + embedding + storage.
 * 
 * @param product - Product data (needs name, description, tags at minimum)
 * @returns true if successful, false if embedding generation failed (non-fatal)
 */
export async function embedProduct(product: {
    id: string;
    name: string;
    description: string;
    tags?: string[];
    highlights?: string[];
    categoryId?: string;
    subcategoryId?: string | null;
    barcode?: string | null;
    specifications?: unknown;
    visualDescription?: string;
}): Promise<boolean> {
    try {
        const text = buildProductEmbeddingText(product);
        const vector = await generateEmbedding(text, false); // Don't cache product embeddings
        await storeProductEmbedding(product.id, vector);
        console.log(`[VectorStore] Embedded product: ${product.name} (${product.id})`);
        return true;
    } catch (error) {
        console.error(`[VectorStore] Failed to embed product "${product.name}":`, error);
        return false;
    }
}

/**
 * Perform a semantic similarity search using pgvector cosine distance.
 * 
 * Finds the most semantically similar products to the given query text.
 * Only searches products that have embeddings AND are available.
 * 
 * @param queryText - Natural language search query
 * @param limit - Maximum number of results (default: 10)
 * @param minSimilarity - Minimum similarity threshold 0-1 (default: 0.3)
 * @returns Array of product IDs with similarity scores, sorted by relevance
 * 
 * @example
 * ```ts
 * const results = await semanticSearch("something cozy for winter evenings", 5);
 * // Returns: [{ productId: "abc", similarity: 0.87 }, ...]
 * ```
 */
export async function semanticSearch(
    queryText: string,
    limit: number = 10,
    minSimilarity: number = 0.3
): Promise<SemanticSearchResult[]> {
    const client = getWriteClient();

    try {
        // Generate embedding for the query
        const queryVector = await generateEmbedding(queryText);
        const vectorStr = `[${queryVector.join(",")}]`;

        // pgvector cosine distance: 1 - (a <=> b) gives similarity 0-1
        // <=> is the cosine distance operator in pgvector
        const results = await client.$queryRawUnsafe<
            Array<{ id: string; similarity: number }>
        >(
            `SELECT id, 1 - (embedding <=> $1::vector) AS similarity
             FROM "Product"
             WHERE embedding IS NOT NULL 
               AND available = true
               AND 1 - (embedding <=> $1::vector) >= $2
             ORDER BY embedding <=> $1::vector
             LIMIT $3`,
            vectorStr,
            minSimilarity,
            limit
        );

        return results.map(r => ({
            productId: r.id,
            similarity: Number(r.similarity),
        }));
    } catch (error) {
        console.error("[VectorStore] Semantic search failed:", error);
        // Return empty results on failure — recommendation engine will fall back to SQL
        return [];
    }
}

/**
 * Fetch full Product objects for semantic search results.
 * Preserves the similarity score and ordering from vector search.
 * 
 * @param queryText - Natural language search query
 * @param limit - Maximum number of results
 * @returns Array of Products with similarity scores
 */
export async function semanticSearchProducts(
    queryText: string,
    limit: number = 10
): Promise<Array<{ product: Product; similarity: number }>> {
    const searchResults = await semanticSearch(queryText, limit);

    if (searchResults.length === 0) return [];

    const client = getWriteClient();
    const productIds = searchResults.map(r => r.productId);

    try {
        const products = await client.product.findMany({
            where: { id: { in: productIds } },
        });

        // Create a map for O(1) lookup
        const productMap = new Map(products.map(p => [p.id, p as unknown as Product]));
        const similarityMap = new Map(searchResults.map(r => [r.productId, r.similarity]));

        // Return in similarity order (same order as searchResults)
        return searchResults
            .filter(r => productMap.has(r.productId))
            .map(r => ({
                product: productMap.get(r.productId)!,
                similarity: similarityMap.get(r.productId)!,
            }));
    } catch (error) {
        console.error("[VectorStore] Failed to fetch products for search results:", error);
        return [];
    }
}

/**
 * Reindex ALL products — generates and stores embeddings for every product.
 * 
 * This is an expensive operation intended for:
 * - Initial setup (first time enabling RAG)
 * - After bulk product imports
 * - Admin-triggered full reindex
 * 
 * @param onProgress - Optional callback for progress tracking
 * @returns Summary of the reindex operation
 */
export async function reindexAllProducts(
    onProgress?: (completed: number, total: number, productName: string) => void,
    forceAll: boolean = false
): Promise<{
    total: number;
    succeeded: number;
    failed: number;
    durationMs: number;
}> {
    const startTime = Date.now();
    const client = getWriteClient();

    let productsToEmbed;

    if (forceAll) {
        // Fetch all products
        productsToEmbed = await client.product.findMany({
            select: {
                id: true,
                name: true,
                description: true,
                tags: true,
                highlights: true,
                categoryId: true,
                subcategoryId: true,
                barcode: true,
                specifications: true,
                imageUrl: true,
                images: true,
                updatedAt: true,
            },
        });
    } else {
        // Find product IDs where embedding is null
        const missingEmbeddings = await client.$queryRawUnsafe<Array<{ id: string }>>(
            `SELECT id FROM "Product" WHERE embedding IS NULL`
        );
        const ids = missingEmbeddings.map(p => p.id);

        console.log(`[VectorStore] Found ${ids.length} products missing embeddings`);

        if (ids.length === 0) {
            return {
                total: 0,
                succeeded: 0,
                failed: 0,
                durationMs: 0,
            };
        }

        productsToEmbed = await client.product.findMany({
            where: { id: { in: ids } },
            select: {
                id: true,
                name: true,
                description: true,
                tags: true,
                highlights: true,
                categoryId: true,
                subcategoryId: true,
                barcode: true,
                specifications: true,
                imageUrl: true,
                images: true,
                updatedAt: true,
            },
        });
    }

    console.log(`[VectorStore] Starting reindex of ${productsToEmbed.length} products...`);

    const { syncProductsSearchIndex } = await import("./product-indexing");
    const indexResults = await syncProductsSearchIndex(productsToEmbed, 3);
    const succeeded = indexResults.filter(result => result.success).length;
    const failed = indexResults.length - succeeded;

    indexResults.forEach((_, index) => {
        onProgress?.(index + 1, productsToEmbed.length, productsToEmbed[index].name);
    });

    const durationMs = Date.now() - startTime;
    console.log(
        `[VectorStore] Reindex complete: ${succeeded}/${productsToEmbed.length} succeeded, ` +
        `${failed} failed, took ${(durationMs / 1000).toFixed(1)}s`
    );

    return {
        total: productsToEmbed.length,
        succeeded,
        failed,
        durationMs,
    };
}


/**
 * Get the current RAG index status — how many products have embeddings.
 * Used by admin dashboard to monitor RAG health.
 */
export async function getRAGIndexStatus(): Promise<RAGIndexStatus> {
    const client = getWriteClient();

    try {
        const [totalResult, embeddedResult] = await Promise.all([
            client.product.count(),
            client.$queryRawUnsafe<Array<{ count: bigint }>>(
                `SELECT COUNT(*) as count FROM "Product" WHERE embedding IS NOT NULL`
            ),
        ]);

        const total = totalResult;
        const embedded = Number(embeddedResult[0]?.count ?? 0);

        return {
            totalProducts: total,
            embeddedProducts: embedded,
            coveragePercent: total > 0 ? Math.round((embedded / total) * 100) : 0,
            lastIndexedAt: null, // Could be enhanced with a metadata table
        };
    } catch (error) {
        console.error("[VectorStore] Failed to get RAG index status:", error);
        return {
            totalProducts: 0,
            embeddedProducts: 0,
            coveragePercent: 0,
            lastIndexedAt: null,
        };
    }
}
