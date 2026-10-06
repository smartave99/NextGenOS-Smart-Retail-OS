// @vitest-environment node

import { beforeEach, describe, expect, it, vi } from "vitest";
import type { IntentAnalysis } from "@/types/assistant-types";
import { getRecommendations } from "./recommendation-engine";
import { analyzeIntent, handleMissingProduct, rankAndSummarize } from "./llm-service";
import {
    getCategories,
    getFilteredProducts,
    searchProducts,
    type Category,
    type Product,
} from "@/app/actions";
import { SHOP_NAME } from "@/lib/shop-name";

const mocks = vi.hoisted(() => ({
    strictSearch: vi.fn(),
    lexicalSearch: vi.fn(),
}));

vi.mock("server-only", () => ({}));
vi.mock("@/app/actions", () => ({
    getCategories: vi.fn(),
    getProductByBarcode: vi.fn(),
    getFilteredProducts: mocks.strictSearch,
    searchProducts: mocks.lexicalSearch,
}));
vi.mock("./llm-service", () => ({
    analyzeIntent: vi.fn(),
    rankAndSummarize: vi.fn(),
    handleMissingProduct: vi.fn(),
}));
vi.mock("./search-cache", () => ({
    getSearchCache: () => ({ get: vi.fn(), set: vi.fn() }),
    hashQuery: vi.fn(() => "hash"),
}));
vi.mock("./ai-response-cache", () => ({
    getCachedAIResponse: vi.fn(),
    getCatalogAIRevision: vi.fn(async () => 0),
    setCachedAIResponse: vi.fn(),
}));
vi.mock("./ai-config", () => ({
    getAIConfig: vi.fn().mockResolvedValue({ maxRecommendations: 5 }),
}));
vi.mock("./vector-store", () => ({
    semanticSearchProducts: vi.fn().mockResolvedValue([]),
}));
vi.mock("@/app/actions/request-actions", () => ({
    createProductRequest: vi.fn(),
}));

const intent: IntentAnalysis = {
    category: "bottles",
    subcategory: null,
    requirements: [],
    budget: { min: null, max: null },
    preferences: [],
    useCase: "",
    searchTerm: "gold butterfly floral pattern thermos flask",
    confidence: 0.9,
    isGeneralChat: false,
};

const product = {
    id: "gold-bottle",
    name: "Decorative Gold-Tone Floral and Butterfly Bottle",
    description: "Decorative floral artwork",
    available: true,
};

beforeEach(() => {
    vi.clearAllMocks();
    vi.mocked(getCategories).mockResolvedValue([]);
    vi.mocked(getFilteredProducts).mockResolvedValue([]);
    vi.mocked(searchProducts).mockResolvedValue([]);
    vi.mocked(handleMissingProduct).mockResolvedValue({
        action: "ask_details",
        response: "We don't have that.",
    });
});

describe("catalogue candidate retrieval", () => {
    it("keeps the strict database result when the full phrase matches", async () => {
        mocks.strictSearch.mockResolvedValueOnce([product]);
        const { queryProducts } = await import("./recommendation-engine");

        await expect(queryProducts(intent, {})).resolves.toEqual([product]);
        expect(mocks.lexicalSearch).not.toHaveBeenCalled();
    });

    it("falls back to word-scored matching for a correct vision description", async () => {
        mocks.strictSearch.mockResolvedValueOnce([]);
        mocks.lexicalSearch.mockResolvedValueOnce([product]);
        const { queryProducts } = await import("./recommendation-engine");

        await expect(queryProducts(intent, {})).resolves.toEqual([product]);
        expect(mocks.lexicalSearch).toHaveBeenCalledWith(
            intent.searchTerm,
            "bottles",
            undefined,
            true
        );
    });

    it("retries without a mistaken category only after the scoped fallback is empty", async () => {
        mocks.strictSearch.mockResolvedValueOnce([]);
        mocks.lexicalSearch
            .mockResolvedValueOnce([])
            .mockResolvedValueOnce([product]);
        const { queryProducts } = await import("./recommendation-engine");

        await expect(queryProducts(intent, {})).resolves.toEqual([product]);
        expect(mocks.lexicalSearch).toHaveBeenNthCalledWith(
            2,
            intent.searchTerm,
            undefined,
            undefined,
            true
        );
    });
});

describe("business-only Genie boundary", () => {
    it("rejects an unrelated request before invoking any LLM helper", async () => {
        const result = await getRecommendations({
            query: "Write a short poem about space.",
        });

        expect(result.success).toBe(true);
        expect(result.recommendations).toEqual([]);
        expect(result.summary).toContain(`only with ${SHOP_NAME} products`);
        expect(result.intent?.isGeneralChat).toBe(true);
        expect(analyzeIntent).not.toHaveBeenCalled();
        expect(rankAndSummarize).not.toHaveBeenCalled();
        expect(handleMissingProduct).not.toHaveBeenCalled();
        expect(getCategories).not.toHaveBeenCalled();
    });

    it("answers a greeting locally without invoking Groq", async () => {
        const result = await getRecommendations({ query: "Assalam alaikum" });

        expect(result.success).toBe(true);
        expect(result.summary).toContain(`${SHOP_NAME}’s shopping assistant`);
        expect(analyzeIntent).not.toHaveBeenCalled();
    });

    it("does not enter general-purpose chat when intent classification is wrong", async () => {
        vi.mocked(analyzeIntent).mockResolvedValue({
            category: null,
            subcategory: null,
            searchTerm: null,
            requirements: [],
            budgetMin: null,
            budgetMax: null,
            preferences: [],
            useCase: "",
            confidence: 0.8,
            isGeneralChat: true,
        });

        const result = await getRecommendations({ query: "Show me current offers" });

        expect(result.success).toBe(true);
        expect(result.summary).toContain(`${SHOP_NAME} products`);
        expect(rankAndSummarize).not.toHaveBeenCalled();
        expect(handleMissingProduct).not.toHaveBeenCalled();
    });
});

describe("Recommendation Engine Search Expansion", () => {
    it("passes subcategory and keyword to getFilteredProducts", async () => {
        const categories: Category[] = [{
            id: "parent-1",
            name: "Electronics",
            parentId: null,
            slug: "electronics",
            order: 0,
            createdAt: new Date(),
        }];
        vi.mocked(getCategories).mockResolvedValue(categories);
        vi.mocked(analyzeIntent).mockResolvedValue({
            category: "parent-1",
            subcategory: "sub-1",
            searchTerm: "iPhone 15",
            requirements: [],
            budgetMin: null,
            budgetMax: null,
            preferences: [],
            useCase: "",
            confidence: 0.9,
            isGeneralChat: false,
        });
        vi.mocked(getFilteredProducts).mockResolvedValue([
            { id: "p1", name: "iPhone 15", price: 79999, available: true } as Product,
        ]);
        vi.mocked(rankAndSummarize).mockResolvedValue({
            rankings: [{ productId: "p1", matchScore: 95, highlights: [], whyRecommended: "Matches name" }],
            summary: "Found it.",
        });

        const result = await getRecommendations({ query: "I want an iPhone 15 in electronics" });

        expect(getFilteredProducts).toHaveBeenCalledWith(expect.objectContaining({
            search: "iPhone 15",
            category: "parent-1",
            subcategory: "sub-1",
        }));
        expect(result.recommendations).toHaveLength(1);
        expect(result.recommendations[0].product.name).toBe("iPhone 15");
    });

    it("prioritizes the subcategory identified by the intent analyzer", async () => {
        vi.mocked(analyzeIntent).mockResolvedValue({
            category: null,
            subcategory: "mens-shoes",
            searchTerm: "running shoes",
            requirements: [],
            budgetMin: null,
            budgetMax: null,
            preferences: [],
            useCase: "",
            confidence: 0.9,
            isGeneralChat: false,
        });

        await getRecommendations({ query: "Men's running shoes" });

        expect(getFilteredProducts).toHaveBeenCalledWith(expect.objectContaining({
            search: "running shoes",
            subcategory: "mens-shoes",
        }));
    });

    it("does not create a product request when no products are found", async () => {
        vi.mocked(analyzeIntent).mockResolvedValue({
            category: "electronics",
            subcategory: null,
            searchTerm: "NonExistentThing",
            requirements: [],
            budgetMin: null,
            budgetMax: null,
            preferences: [],
            useCase: "",
            confidence: 0.9,
            isGeneralChat: false,
        });

        const requestActions = await import("@/app/actions/request-actions");
        const createSpy = vi.spyOn(requestActions, "createProductRequest");

        await getRecommendations({ query: "I want a NonExistentThing" });

        expect(createSpy).not.toHaveBeenCalled();
    });
});
