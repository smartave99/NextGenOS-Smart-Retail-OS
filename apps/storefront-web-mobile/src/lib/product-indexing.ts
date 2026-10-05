import "server-only";

import { bumpCatalogAIRevision } from "./ai-response-cache";
import { getSearchCache } from "./search-cache";
import { analyzeProductImageForIndex } from "./llm-service";
import { clearProductEmbedding, embedProduct } from "./vector-store";

export interface ProductSearchIndexInput {
    id: string;
    name: string;
    description: string;
    tags?: string[];
    highlights?: string[];
    categoryId?: string;
    subcategoryId?: string | null;
    barcode?: string | null;
    specifications?: unknown;
    imageUrl?: string | null;
    images?: string[];
    updatedAt?: Date | string | null;
}

export interface ProductIndexResult {
    productId: string;
    success: boolean;
    visionAnalyzed: boolean;
}

async function syncRuntimeAPIKeys(): Promise<void> {
    try {
        const { syncAPIKeysToManager } = await import("@/app/api-key-actions");
        await syncAPIKeysToManager();
    } catch (error) {
        // Environment-provided keys still work. A database sync failure should
        // not prevent text-only indexing.
        console.warn("[ProductIndexing] Could not sync database API keys:", error instanceof Error ? error.message : "unknown error");
    }
}

function getIndexableImage(product: ProductSearchIndexInput): string | null {
    const candidates = [product.imageUrl, ...(product.images || [])];
    return candidates.find(url => typeof url === "string" && /^https:\/\//i.test(url)) || null;
}

function productCacheSalt(product: ProductSearchIndexInput): string {
    return JSON.stringify({
        id: product.id,
        updatedAt: product.updatedAt || null,
        name: product.name,
        imageUrl: product.imageUrl || null,
        images: product.images || [],
    });
}

async function indexOneProduct(product: ProductSearchIndexInput): Promise<ProductIndexResult> {
    let visualDescription = "";
    let visionAnalyzed = false;
    const imageUrl = getIndexableImage(product);

    // Clearing first prevents an updated product from remaining searchable by
    // an obsolete vector if either vision or embedding generation later fails.
    await clearProductEmbedding(product.id);

    if (imageUrl) {
        try {
            visualDescription = await analyzeProductImageForIndex(
                imageUrl,
                productCacheSalt(product)
            );
            visionAnalyzed = visualDescription.length > 0;
        } catch (error) {
            console.warn(`[ProductIndexing] Vision enrichment failed for ${product.id}; continuing with catalog text:`, error instanceof Error ? error.message : "unknown error");
        }
    }

    const success = await embedProduct({
        id: product.id,
        name: product.name,
        description: product.description || "",
        tags: product.tags || [],
        highlights: product.highlights || [],
        categoryId: product.categoryId,
        subcategoryId: product.subcategoryId,
        barcode: product.barcode,
        specifications: product.specifications,
        visualDescription,
    });

    return {
        productId: product.id,
        success,
        visionAnalyzed,
    };
}

/** Invalidate both process-local search entries and distributed AI results. */
export async function invalidateCatalogSearchState(): Promise<number> {
    getSearchCache().clearPrefix("products");
    getSearchCache().clearPrefix("query");
    return bumpCatalogAIRevision();
}

/** Reliable single-product indexing: the caller waits until retrieval is ready. */
export async function syncProductSearchIndex(
    product: ProductSearchIndexInput
): Promise<ProductIndexResult> {
    await syncRuntimeAPIKeys();
    return indexOneProduct(product);
}

/**
 * Bounded concurrency keeps imports faster without exhausting Groq/Gemini
 * quotas or the database connection pool.
 */
export async function syncProductsSearchIndex(
    products: ProductSearchIndexInput[],
    concurrency: number = 3
): Promise<ProductIndexResult[]> {
    if (products.length === 0) return [];
    await syncRuntimeAPIKeys();

    const results: ProductIndexResult[] = new Array(products.length);
    let nextIndex = 0;
    const workerCount = Math.max(1, Math.min(Math.floor(concurrency), 6, products.length));

    async function worker(): Promise<void> {
        while (true) {
            const index = nextIndex++;
            if (index >= products.length) return;

            try {
                results[index] = await indexOneProduct(products[index]);
            } catch (error) {
                console.error(`[ProductIndexing] Indexing failed for ${products[index].id}:`, error);
                results[index] = {
                    productId: products[index].id,
                    success: false,
                    visionAnalyzed: false,
                };
            }
        }
    }

    await Promise.all(Array.from({ length: workerCount }, () => worker()));
    return results;
}

