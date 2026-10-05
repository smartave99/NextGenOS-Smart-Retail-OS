// @vitest-environment node

import { afterEach, describe, expect, it, vi } from "vitest";
import {
    getLightningChatCompletionsUrl,
    getLightningModel,
    getLightningVisionFallbackModel,
    getLightningVisionModel,
} from "./lightning-config";

afterEach(() => {
    vi.unstubAllEnvs();
});

describe("Lightning AI configuration", () => {
    it("expands the shared API base URL to the chat-completions endpoint", () => {
        vi.stubEnv("LIGHTNING_API_BASE_URL", "https://lightning.ai/api/v1/");

        expect(getLightningChatCompletionsUrl())
            .toBe("https://lightning.ai/api/v1/chat/completions");
    });

    it("accepts a complete custom chat-completions endpoint", () => {
        vi.stubEnv(
            "LIGHTNING_API_BASE_URL",
            "https://custom.example/v1/chat/completions/"
        );

        expect(getLightningChatCompletionsUrl())
            .toBe("https://custom.example/v1/chat/completions");
    });

    it("uses DeepSeek V4 Pro by default", () => {
        vi.stubEnv("LIGHTNING_MODEL", "");

        expect(getLightningModel()).toBe("lightning-ai/deepseek-v4-pro");
    });

    it("uses Gemma 4 with Nemotron Omni as the vision fallback", () => {
        vi.stubEnv("LIGHTNING_VISION_MODEL", "");
        vi.stubEnv("LIGHTNING_VISION_FALLBACK_MODEL", "");

        expect(getLightningVisionModel()).toBe("lightning-ai/gemma-4-31B-it");
        expect(getLightningVisionFallbackModel())
            .toBe("lightning-ai/nvidia-nemotron-3-nano-omni-30b-a3b");
    });
});
