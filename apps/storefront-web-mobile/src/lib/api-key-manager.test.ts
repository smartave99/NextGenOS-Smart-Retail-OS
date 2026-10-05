// @vitest-environment node

import { afterEach, describe, expect, it, vi } from "vitest";
import { APIKeyManager } from "./api-key-manager";
import { APIKeyExhaustedError } from "@/types/assistant-types";

const PROVIDER_ENV_KEYS = [
    "GEMINI_API_KEY_1",
    "GEMINI_API_KEY_2",
    "GEMINI_API_KEY_3",
    "OPENAI_API_KEY",
    "OPENAI_API_KEY_1",
    "OPENAI_API_KEY_2",
    "OPENAI_API_KEY_3",
    "ANTHROPIC_API_KEY",
    "ANTHROPIC_API_KEY_1",
    "ANTHROPIC_API_KEY_2",
    "ANTHROPIC_API_KEY_3",
    "GROQ_API_KEY",
    ...Array.from({ length: 10 }, (_, index) => `GROQ_API_KEY_${index + 1}`),
    "LIGHTNING_API_KEY",
    ...Array.from({ length: 10 }, (_, index) => `LIGHTNING_API_KEY_${index + 1}`),
];

function clearProviderEnvironment() {
    PROVIDER_ENV_KEYS.forEach(name => vi.stubEnv(name, ""));
}

afterEach(() => {
    vi.unstubAllEnvs();
});

describe("APIKeyManager provider rotation", () => {
    it("loads unique Lightning AI keys and rotates after a limit", () => {
        clearProviderEnvironment();
        vi.stubEnv("LIGHTNING_API_KEY", "lightning-primary-key");
        vi.stubEnv("LIGHTNING_API_KEY_1", "lightning-primary-key");
        vi.stubEnv("LIGHTNING_API_KEY_2", "lightning-backup-key");

        const manager = new APIKeyManager();

        expect(manager.getKeyCount("lightning")).toBe(2);
        const primary = manager.getActiveKey("lightning");
        expect(primary).toBe("lightning-primary-key");

        manager.markKeyRateLimited(primary);

        expect(manager.getActiveKey("lightning")).toBe("lightning-backup-key");
        expect(manager.getHealthStatus().lastRotation).toBeInstanceOf(Date);
    });

    it("rotates Groq keys independently from Lightning AI keys", () => {
        clearProviderEnvironment();
        vi.stubEnv("GROQ_API_KEY", "groq-primary-key");
        vi.stubEnv("GROQ_API_KEY_1", "groq-backup-key");
        vi.stubEnv("LIGHTNING_API_KEY", "lightning-key");

        const manager = new APIKeyManager();
        const primary = manager.getActiveKey("groq");
        manager.markKeyRateLimited(primary);

        expect(manager.getActiveKey("groq")).toBe("groq-backup-key");
        expect(manager.getActiveKey("lightning")).toBe("lightning-key");
    });

    it("reports exhaustion after every key for a provider is limited", () => {
        clearProviderEnvironment();
        vi.stubEnv("LIGHTNING_API_KEY", "lightning-only-key");

        const manager = new APIKeyManager();
        manager.markKeyRateLimited(manager.getActiveKey("lightning"));

        expect(() => manager.getActiveKey("lightning")).toThrow(APIKeyExhaustedError);
    });
});
