/**
 * RAG Admin Management API
 * 
 * Provides admin endpoints for managing the RAG (Retrieval-Augmented Generation) system:
 * - GET  /api/admin/rag — Get RAG index status (embedding coverage)
 * - POST /api/admin/rag — Trigger bulk reindex of all products
 * 
 * @module api/admin/rag
 */

import { NextRequest, NextResponse } from "next/server";
import { reindexAllProducts, getRAGIndexStatus } from "@/lib/vector-store";
import { getEmbeddingCacheStats } from "@/lib/embedding-service";
import { getAdminIdentityFromRequest } from "@/lib/auth-server";
import { invalidateCatalogSearchState } from "@/lib/product-indexing";

/**
 * GET /api/admin/rag
 * 
 * Returns the current RAG index status:
 * - Total products in database
 * - Products with embeddings
 * - Coverage percentage
 * - Embedding cache stats
 */
export async function GET(request: NextRequest) {
    try {
        if (!await getAdminIdentityFromRequest(request)) {
            return NextResponse.json({ success: false, error: "Unauthorized" }, { status: 401 });
        }
        const [indexStatus, cacheStats] = await Promise.all([
            getRAGIndexStatus(),
            Promise.resolve(getEmbeddingCacheStats()),
        ]);

        return NextResponse.json({
            success: true,
            rag: {
                ...indexStatus,
                embeddingCache: cacheStats,
            },
        });
    } catch (error) {
        console.error("[API /admin/rag] GET Error:", error);
        return NextResponse.json(
            { success: false, error: "Failed to get RAG status" },
            { status: 500 }
        );
    }
}

/**
 * POST /api/admin/rag
 * 
 * Triggers a full reindex of all products.
 * Enriches product images with Groq Qwen vision, then generates the pgvector
 * embedding with Gemini's dedicated embedding endpoint.
 * 
 * Request body (optional):
 * - action: "reindex" (default) — Reindex all products
 * 
 * Response:
 * - total: Number of products processed
 * - succeeded: Number successfully embedded
 * - failed: Number that failed
 * - durationMs: Time taken in milliseconds
 */
export async function POST(request: NextRequest) {
    try {
        if (!await getAdminIdentityFromRequest(request)) {
            return NextResponse.json({ success: false, error: "Unauthorized" }, { status: 401 });
        }
        const body = await request.json().catch(() => ({}));
        const action = body.action || "reindex";
        const forceAll = body.forceAll === true;

        if (action !== "reindex") {
            return NextResponse.json(
                { success: false, error: `Unknown action: ${action}. Use "reindex".` },
                { status: 400 }
            );
        }

        console.log(`[API /admin/rag] Starting product reindex (forceAll=${forceAll})...`);

        const result = await reindexAllProducts((completed, total, productName) => {
            if (completed % 10 === 0 || completed === total) {
                console.log(`[RAG Reindex] ${completed}/${total} — ${productName}`);
            }
        }, forceAll);
        await invalidateCatalogSearchState();

        return NextResponse.json({
            success: true,
            action: "reindex",
            result: {
                totalProducts: result.total,
                succeeded: result.succeeded,
                failed: result.failed,
                durationSeconds: (result.durationMs / 1000).toFixed(1),
            },
            message: `Reindexed ${result.succeeded}/${result.total} products in ${(result.durationMs / 1000).toFixed(1)}s`,
        });
    } catch (error) {
        console.error("[API /admin/rag] POST Error:", error);
        return NextResponse.json(
            { success: false, error: "Failed to reindex products" },
            { status: 500 }
        );
    }
}
