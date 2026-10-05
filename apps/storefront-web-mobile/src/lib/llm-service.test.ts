// @vitest-environment node

import { afterEach, beforeEach, describe, expect, it, vi } from "vitest";

vi.mock("server-only", () => ({}));

vi.mock("./ai-config", () => ({
    getAIConfig: vi.fn(async () => ({
        enabled: true,
        showVibeSelector: true,
        personaName: "Genie",
        greeting: "Hello",
        systemPrompt: "You are Genie.",
        temperature: 0.7,
        maxTokens: 512,
        providerPriority: "groq",
        maxRecommendations: 5,
        enableVoiceInput: false,
        enableProductRequests: true,
    })),
    invalidateAIConfig: vi.fn(),
}));

vi.mock("./prompt-registry", () => ({
    getPrompt: vi.fn(async () => "Test prompt"),
}));

const TEST_ENV_KEYS = [
    "GEMINI_API_KEY_1",
    "GROQ_API_KEY",
    ...Array.from({ length: 10 }, (_, index) => `GROQ_API_KEY_${index + 1}`),
    "GROQ_TEXT_MODEL_PRIMARY",
    "GROQ_TEXT_MODEL_FALLBACK",
    "GROQ_VISION_MODEL_PRIMARY",
    "GROQ_VISION_MODEL_FALLBACK",
    "GROQ_MODEL_FALLBACKS",
    "GROQ_VISION_MODEL_FALLBACKS",
    "GROQ_TEXT_CACHE_TTL_SECONDS",
    "UPSTASH_REDIS_REST_URL",
    "UPSTASH_REDIS_REST_TOKEN",
    "LIGHTNING_API_KEY",
];

function clearEnvironment() {
    TEST_ENV_KEYS.forEach(name => vi.stubEnv(name, ""));
}

function successResponse(content: string, finishReason = "stop") {
    return {
        ok: true,
        status: 200,
        statusText: "OK",
        text: vi.fn(async () => ""),
        json: vi.fn(async () => ({
            choices: [{ message: { content }, finish_reason: finishReason }],
        })),
    };
}

beforeEach(() => {
    vi.resetModules();
    clearEnvironment();
    vi.stubEnv("GROQ_API_KEY", "groq-shared-key");
});

afterEach(() => {
    vi.unstubAllEnvs();
    vi.unstubAllGlobals();
});

describe("Groq Qwen routing", () => {
    it("uses Qwen 3.8 as the primary text model", async () => {
        const fetchMock = vi.fn().mockResolvedValueOnce(
            successResponse('{"reply":"Hello!","suggestedActions":[]}')
        );
        vi.stubGlobal("fetch", fetchMock);

        const { chatWithAssistant } = await import("./llm-service");
        const result = await chatWithAssistant("Hi", []);

        expect(result.reply).toBe("Hello!");
        const requestBody = JSON.parse(fetchMock.mock.calls[0][1]?.body);
        expect(requestBody.model).toBe("qwen/qwen3.8-27b");
        expect(fetchMock.mock.calls[0][1]?.headers.Authorization).toBe("Bearer groq-shared-key");
    });

    it("moves from the Qwen 3.8 bucket to Qwen 3.6 on HTTP 429 using the same key", async () => {
        const fetchMock = vi.fn()
            .mockResolvedValueOnce({ ok: false, status: 429, statusText: "Too Many Requests" })
            .mockResolvedValueOnce(successResponse('{"reply":"Fallback","suggestedActions":[]}'));
        vi.stubGlobal("fetch", fetchMock);

        const { chatWithAssistant } = await import("./llm-service");
        const result = await chatWithAssistant("Hello", []);

        expect(result.reply).toBe("Fallback");
        expect(fetchMock).toHaveBeenCalledTimes(2);
        const firstBody = JSON.parse(fetchMock.mock.calls[0][1]?.body);
        const secondBody = JSON.parse(fetchMock.mock.calls[1][1]?.body);
        expect(firstBody.model).toBe("qwen/qwen3.8-27b");
        expect(secondBody.model).toBe("qwen/qwen3.6-27b");
        expect(fetchMock.mock.calls[0][1]?.headers.Authorization).toBe("Bearer groq-shared-key");
        expect(fetchMock.mock.calls[1][1]?.headers.Authorization).toBe("Bearer groq-shared-key");
    });

    it("continues through the lower-capability text reserve buckets", async () => {
        const fetchMock = vi.fn()
            .mockResolvedValueOnce({ ok: false, status: 429, statusText: "Too Many Requests" })
            .mockResolvedValueOnce({ ok: false, status: 429, statusText: "Too Many Requests" })
            .mockResolvedValueOnce({ ok: false, status: 429, statusText: "Too Many Requests" })
            .mockResolvedValueOnce(successResponse('{"reply":"Last reserve","suggestedActions":[]}'));
        vi.stubGlobal("fetch", fetchMock);

        const { chatWithAssistant } = await import("./llm-service");
        const result = await chatWithAssistant("Keep serving", []);

        expect(result.reply).toBe("Last reserve");
        expect(fetchMock.mock.calls.map(call => JSON.parse(call[1]?.body).model)).toEqual([
            "qwen/qwen3.8-27b",
            "qwen/qwen3.6-27b",
            "openai/gpt-oss-120b",
            "openai/gpt-oss-20b",
        ]);
    });

    it("retries the intelligence ladder with the next Groq key after all model buckets are limited", async () => {
        vi.stubEnv("GROQ_API_KEY_1", "groq-backup-key");
        const fetchMock = vi.fn()
            .mockResolvedValueOnce({ ok: false, status: 429, statusText: "Too Many Requests" })
            .mockResolvedValueOnce({ ok: false, status: 429, statusText: "Too Many Requests" })
            .mockResolvedValueOnce({ ok: false, status: 429, statusText: "Too Many Requests" })
            .mockResolvedValueOnce({ ok: false, status: 429, statusText: "Too Many Requests" })
            .mockResolvedValueOnce(successResponse('{"reply":"Backup key served","suggestedActions":[]}'));
        vi.stubGlobal("fetch", fetchMock);

        const { chatWithAssistant } = await import("./llm-service");
        const result = await chatWithAssistant("Stay online", []);

        expect(result.reply).toBe("Backup key served");
        expect(fetchMock.mock.calls.map(call => JSON.parse(call[1]?.body).model)).toEqual([
            "qwen/qwen3.8-27b",
            "qwen/qwen3.6-27b",
            "openai/gpt-oss-120b",
            "openai/gpt-oss-20b",
            "qwen/qwen3.8-27b",
        ]);
        expect(fetchMock.mock.calls.slice(0, 4).every(call =>
            call[1]?.headers.Authorization === "Bearer groq-shared-key"
        )).toBe(true);
        expect(fetchMock.mock.calls[4][1]?.headers.Authorization).toBe("Bearer groq-backup-key");
    });

    it("advances models when a successful response fails JSON validation", async () => {
        const fetchMock = vi.fn()
            .mockResolvedValueOnce(successResponse("I forgot to return JSON"))
            .mockResolvedValueOnce(successResponse('{"reply":"Validated fallback","suggestedActions":null}'));
        vi.stubGlobal("fetch", fetchMock);

        const { chatWithAssistant } = await import("./llm-service");
        const result = await chatWithAssistant("Hello", []);

        expect(result).toEqual({
            reply: "Validated fallback",
            suggestedActions: undefined,
        });
        expect(fetchMock.mock.calls.map(call => JSON.parse(call[1]?.body).model)).toEqual([
            "qwen/qwen3.8-27b",
            "qwen/qwen3.6-27b",
        ]);
        expect(JSON.parse(fetchMock.mock.calls[0][1]?.body).response_format).toEqual({
            type: "json_object",
        });
    });

    it("routes advanced review analysis through Groq instead of a legacy provider", async () => {
        vi.stubEnv("LIGHTNING_API_KEY", "legacy-key-that-must-not-be-used");
        const fetchMock = vi.fn().mockResolvedValueOnce(
            successResponse('{"pros":["Durable"],"cons":[],"summary":"Strong reviews"}')
        );
        vi.stubGlobal("fetch", fetchMock);

        const { summarizeReviews } = await import("./llm-service");
        const result = await summarizeReviews("Test product", [{ rating: 5, comment: "Durable" }]);

        expect(result.summary).toBe("Strong reviews");
        expect(fetchMock.mock.calls[0][0]).toBe("https://api.groq.com/openai/v1/chat/completions");
        const requestBody = JSON.parse(fetchMock.mock.calls[0][1]?.body);
        expect(requestBody.model).toBe("qwen/qwen3.8-27b");
    });
});

describe("Groq Qwen vision", () => {
    it("uses Qwen 3.8 for image search", async () => {
        const fetchMock = vi.fn().mockResolvedValueOnce(
            successResponse("red leather handbag gold clasp")
        );
        vi.stubGlobal("fetch", fetchMock);

        const { callVisionAPI } = await import("./llm-service");
        const result = await callVisionAPI("data:image/png;base64,aW1hZ2U=");

        expect(result).toBe("red leather handbag gold clasp");
        const requestBody = JSON.parse(fetchMock.mock.calls[0][1]?.body);
        expect(requestBody.model).toBe("qwen/qwen3.8-27b");
        expect(requestBody.messages[0].content[1]).toEqual({
            type: "image_url",
            image_url: {
                url: "data:image/png;base64,aW1hZ2U=",
                detail: "auto",
            },
        });
    });

    it("falls back to Qwen 3.6 when the Qwen 3.8 vision bucket is limited", async () => {
        const fetchMock = vi.fn()
            .mockResolvedValueOnce({ ok: false, status: 429, statusText: "Too Many Requests" })
            .mockResolvedValueOnce(successResponse("Sony WH-1000XM5 wireless headphones"));
        vi.stubGlobal("fetch", fetchMock);

        const { callVisionAPI } = await import("./llm-service");
        const result = await callVisionAPI("aW1hZ2U=");

        expect(result).toBe("Sony WH-1000XM5 wireless headphones");
        const fallbackBody = JSON.parse(fetchMock.mock.calls[1][1]?.body);
        expect(fallbackBody.model).toBe("qwen/qwen3.6-27b");
        expect(fetchMock.mock.calls[1][1]?.headers.Authorization).toBe("Bearer groq-shared-key");
    });

    it("uses the next Groq key after both vision model buckets are limited", async () => {
        vi.stubEnv("GROQ_API_KEY_1", "groq-backup-key");
        const fetchMock = vi.fn()
            .mockResolvedValueOnce({ ok: false, status: 429, statusText: "Too Many Requests" })
            .mockResolvedValueOnce({ ok: false, status: 429, statusText: "Too Many Requests" })
            .mockResolvedValueOnce(successResponse("gold floral bottle"));
        vi.stubGlobal("fetch", fetchMock);

        const { callVisionAPI } = await import("./llm-service");
        await expect(callVisionAPI("aW1hZ2U=")).resolves.toBe("gold floral bottle");
        expect(fetchMock.mock.calls.map(call => JSON.parse(call[1]?.body).model)).toEqual([
            "qwen/qwen3.8-27b",
            "qwen/qwen3.6-27b",
            "qwen/qwen3.8-27b",
        ]);
        expect(fetchMock.mock.calls[2][1]?.headers.Authorization).toBe("Bearer groq-backup-key");
    });

    it("caches identical image analysis without storing the API key in the cache fingerprint", async () => {
        const fetchMock = vi.fn().mockResolvedValueOnce(successResponse("blue running shoes mesh"));
        vi.stubGlobal("fetch", fetchMock);

        const { callVisionAPI } = await import("./llm-service");
        const first = await callVisionAPI("data:image/png;base64,c2FtZS1pbWFnZQ==");
        const second = await callVisionAPI("data:image/png;base64,c2FtZS1pbWFnZQ==");

        expect(first).toBe(second);
        expect(fetchMock).toHaveBeenCalledTimes(1);
    });

    it("uses the product revision salt when caching catalogue image enrichment", async () => {
        const fetchMock = vi.fn()
            .mockResolvedValueOnce(successResponse("Brand X; Model 1; black bottle"))
            .mockResolvedValueOnce(successResponse("Brand X; Model 2; blue bottle"));
        vi.stubGlobal("fetch", fetchMock);

        const { analyzeProductImageForIndex } = await import("./llm-service");
        await analyzeProductImageForIndex("https://example.com/product.jpg", "revision-1");
        await analyzeProductImageForIndex("https://example.com/product.jpg", "revision-1");
        await analyzeProductImageForIndex("https://example.com/product.jpg", "revision-2");

        expect(fetchMock).toHaveBeenCalledTimes(2);
    });
});

describe("structured output normalization", () => {
    it("normalizes nullable intent fields returned by Qwen", async () => {
        const fetchMock = vi.fn().mockResolvedValueOnce(successResponse(JSON.stringify({
            category: null,
            subcategory: null,
            requirements: null,
            budgetMin: null,
            budgetMax: null,
            preferences: null,
            useCase: null,
            searchTerm: null,
            confidence: null,
            isGeneralChat: true,
        })));
        vi.stubGlobal("fetch", fetchMock);

        const { analyzeIntent } = await import("./llm-service");
        const result = await analyzeIntent("Hello", []);

        expect(result.useCase).toBe("");
        expect(result.requirements).toEqual([]);
        expect(result.preferences).toEqual([]);
        expect(result.confidence).toBe(0.5);
        expect(result.isGeneralChat).toBe(true);
    });
});
