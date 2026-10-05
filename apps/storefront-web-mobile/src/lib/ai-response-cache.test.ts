// @vitest-environment node

import { afterEach, beforeEach, describe, expect, it, vi } from "vitest";

vi.mock("server-only", () => ({}));

beforeEach(async () => {
    vi.resetModules();
    vi.stubEnv("UPSTASH_REDIS_REST_URL", "");
    vi.stubEnv("UPSTASH_REDIS_REST_TOKEN", "");
});

afterEach(() => {
    vi.unstubAllEnvs();
});

describe("AI response cache", () => {
    it("deduplicates identical in-flight and subsequent requests", async () => {
        const { withAIResponseCache } = await import("./ai-response-cache");
        const generate = vi.fn(async () => "generated once");

        const [first, second] = await Promise.all([
            withAIResponseCache({ namespace: "test", fingerprint: { query: "same" }, ttlSeconds: 60, generate }),
            withAIResponseCache({ namespace: "test", fingerprint: { query: "same" }, ttlSeconds: 60, generate }),
        ]);
        const third = await withAIResponseCache({
            namespace: "test",
            fingerprint: { query: "same" },
            ttlSeconds: 60,
            generate,
        });

        expect(first).toBe("generated once");
        expect(second).toBe("generated once");
        expect(third).toBe("generated once");
        expect(generate).toHaveBeenCalledTimes(1);
    });

    it("advances the catalogue revision used to invalidate recommendations", async () => {
        const { bumpCatalogAIRevision, getCatalogAIRevision } = await import("./ai-response-cache");

        expect(await getCatalogAIRevision()).toBe(0);
        expect(await bumpCatalogAIRevision()).toBe(1);
        expect(await getCatalogAIRevision()).toBe(1);
    });
});

