// @vitest-environment node

import { beforeEach, describe, expect, it, vi } from "vitest";

const mocks = vi.hoisted(() => ({
    syncKeys: vi.fn(async () => ({ success: true })),
    bumpRevision: vi.fn(async () => 1),
    clearPrefix: vi.fn(),
    analyzeImage: vi.fn(async () => "Brand X; Model 7; red metal bottle"),
    clearEmbedding: vi.fn(async () => undefined),
    embedProduct: vi.fn(async () => true),
}));

vi.mock("server-only", () => ({}));
vi.mock("@/app/api-key-actions", () => ({ syncAPIKeysToManager: mocks.syncKeys }));
vi.mock("./ai-response-cache", () => ({ bumpCatalogAIRevision: mocks.bumpRevision }));
vi.mock("./search-cache", () => ({
    getSearchCache: () => ({ clearPrefix: mocks.clearPrefix }),
}));
vi.mock("./llm-service", () => ({ analyzeProductImageForIndex: mocks.analyzeImage }));
vi.mock("./vector-store", () => ({
    clearProductEmbedding: mocks.clearEmbedding,
    embedProduct: mocks.embedProduct,
}));

beforeEach(() => {
    vi.clearAllMocks();
});

describe("product search indexing", () => {
    it("waits for image enrichment and embeds the visible product facts", async () => {
        const { syncProductSearchIndex } = await import("./product-indexing");
        const result = await syncProductSearchIndex({
            id: "product-1",
            name: "Insulated Bottle",
            description: "Keeps drinks cold",
            tags: ["bottle"],
            imageUrl: "https://example.com/bottle.jpg",
            updatedAt: "2026-08-30T00:00:00.000Z",
        });

        expect(result).toEqual({
            productId: "product-1",
            success: true,
            visionAnalyzed: true,
        });
        expect(mocks.syncKeys).toHaveBeenCalledTimes(1);
        expect(mocks.clearEmbedding).toHaveBeenCalledWith("product-1");
        expect(mocks.analyzeImage).toHaveBeenCalledWith(
            "https://example.com/bottle.jpg",
            expect.stringContaining("product-1")
        );
        expect(mocks.embedProduct).toHaveBeenCalledWith(
            expect.objectContaining({
                id: "product-1",
                visualDescription: "Brand X; Model 7; red metal bottle",
            })
        );
        expect(mocks.clearEmbedding.mock.invocationCallOrder[0])
            .toBeLessThan(mocks.embedProduct.mock.invocationCallOrder[0]);
    });

    it("still creates a fresh text index when vision enrichment fails", async () => {
        mocks.analyzeImage.mockRejectedValueOnce(new Error("vision unavailable"));
        const { syncProductSearchIndex } = await import("./product-indexing");

        const result = await syncProductSearchIndex({
            id: "product-2",
            name: "Notebook",
            description: "A5 ruled notebook",
            imageUrl: "https://example.com/notebook.jpg",
        });

        expect(result.success).toBe(true);
        expect(result.visionAnalyzed).toBe(false);
        expect(mocks.embedProduct).toHaveBeenCalledWith(
            expect.objectContaining({
                id: "product-2",
                visualDescription: "",
            })
        );
    });

    it("advances the distributed catalogue revision on mutation", async () => {
        const { invalidateCatalogSearchState } = await import("./product-indexing");

        await expect(invalidateCatalogSearchState()).resolves.toBe(1);
        expect(mocks.clearPrefix).toHaveBeenCalledWith("products");
        expect(mocks.clearPrefix).toHaveBeenCalledWith("query");
        expect(mocks.bumpRevision).toHaveBeenCalledTimes(1);
    });
});

