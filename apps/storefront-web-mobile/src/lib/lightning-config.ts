const DEFAULT_LIGHTNING_API_BASE_URL = "https://lightning.ai/api/v1/";
const DEFAULT_LIGHTNING_MODEL = "lightning-ai/deepseek-v4-pro";
const DEFAULT_LIGHTNING_VISION_MODEL = "lightning-ai/gemma-4-31B-it";
const DEFAULT_LIGHTNING_VISION_FALLBACK_MODEL = "lightning-ai/nvidia-nemotron-3-nano-omni-30b-a3b";

/**
 * Accepts either an OpenAI-style API base URL (for example
 * https://lightning.ai/api/v1/) or the complete chat-completions endpoint.
 */
export function getLightningChatCompletionsUrl(): string {
    const configuredBase = process.env.LIGHTNING_API_BASE_URL?.trim()
        || DEFAULT_LIGHTNING_API_BASE_URL;
    const normalizedBase = configuredBase.replace(/\/+$/, "");

    return normalizedBase.endsWith("/chat/completions")
        ? normalizedBase
        : `${normalizedBase}/chat/completions`;
}

export function getLightningModel(): string {
    return process.env.LIGHTNING_MODEL?.trim() || DEFAULT_LIGHTNING_MODEL;
}

export function getLightningReasoningModel(): string {
    return process.env.LIGHTNING_MODEL_REASONING?.trim() || getLightningModel();
}

export function getLightningGiftModel(): string {
    return process.env.LIGHTNING_MODEL_GIFT?.trim() || getLightningModel();
}

export function getLightningVisionModel(): string {
    return process.env.LIGHTNING_VISION_MODEL?.trim()
        || DEFAULT_LIGHTNING_VISION_MODEL;
}

export function getLightningVisionFallbackModel(): string {
    return process.env.LIGHTNING_VISION_FALLBACK_MODEL?.trim()
        || DEFAULT_LIGHTNING_VISION_FALLBACK_MODEL;
}
