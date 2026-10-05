// @vitest-environment node

import { beforeEach, describe, expect, it, vi } from "vitest";
import { NextRequest } from "next/server";
import { POST } from "./route";

const mocks = vi.hoisted(() => ({
    syncAPIKeysToManager: vi.fn(),
    getAISettings: vi.fn(),
    runShoppingAgent: vi.fn(),
    checkRateLimit: vi.fn(),
}));

vi.mock("@/app/api-key-actions", () => ({
    syncAPIKeysToManager: mocks.syncAPIKeysToManager,
}));
vi.mock("@/app/actions/ai-settings-actions", () => ({
    getAISettings: mocks.getAISettings,
}));
vi.mock("@/lib/agent/shopping-agent", () => ({
    runShoppingAgent: mocks.runShoppingAgent,
}));
vi.mock("@/lib/rate-limit", () => ({
    checkRateLimit: mocks.checkRateLimit,
    getRequestIdentifier: vi.fn(() => "test-ip"),
}));

beforeEach(() => {
    vi.clearAllMocks();
    mocks.getAISettings.mockResolvedValue({ enabled: true });
    mocks.checkRateLimit.mockResolvedValue({
        allowed: true,
        limit: 20,
        remaining: 19,
        resetAt: Date.now() + 60_000,
    });
});

describe("POST /api/assistant/recommend business boundary", () => {
    it("returns a local response without syncing Groq keys or running the agent for off-topic chat", async () => {
        const request = new NextRequest("https://smartavenue99.com/api/assistant/recommend", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ query: "Write a short poem about space" }),
        });

        const response = await POST(request);
        const body = await response.json();

        expect(response.status).toBe(200);
        expect(body.summary).toContain("only with Smart Avenue products");
        expect(mocks.syncAPIKeysToManager).not.toHaveBeenCalled();
        expect(mocks.runShoppingAgent).not.toHaveBeenCalled();
    });
});
