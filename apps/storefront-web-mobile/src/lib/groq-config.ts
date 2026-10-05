import "server-only";

/**
 * Exact GroqCloud model IDs. Keep the defaults independent from the legacy
 * GROQ_MODEL variables so an old deployment value cannot silently route new
 * traffic back to GPT-OSS or a retired model.
 */
export const DEFAULT_GROQ_PRIMARY_MODEL = "qwen/qwen3.8-27b";
export const DEFAULT_GROQ_FALLBACK_MODEL = "qwen/qwen3.6-27b";
export const DEFAULT_GROQ_TEXT_RESERVE_MODELS = [
    "openai/gpt-oss-120b",
    "openai/gpt-oss-20b",
] as const;

function uniqueModels(models: Array<string | undefined>): string[] {
    const seen = new Set<string>();
    const result: string[] = [];

    for (const rawModel of models) {
        const model = rawModel?.trim();
        if (!model || seen.has(model)) continue;
        seen.add(model);
        result.push(model);
    }

    return result;
}

function configuredFallbacks(): string[] {
    return (process.env.GROQ_MODEL_FALLBACKS || "")
        .split(",")
        .map(model => model.trim())
        .filter(Boolean);
}

function configuredVisionFallbacks(): string[] {
    return (process.env.GROQ_VISION_MODEL_FALLBACKS || "")
        .split(",")
        .map(model => model.trim())
        .filter(Boolean);
}

export function getGroqPrimaryModel(): string {
    return process.env.GROQ_TEXT_MODEL_PRIMARY?.trim() || DEFAULT_GROQ_PRIMARY_MODEL;
}

export function getGroqFallbackModel(): string {
    return process.env.GROQ_TEXT_MODEL_FALLBACK?.trim() || DEFAULT_GROQ_FALLBACK_MODEL;
}

/**
 * Model order is deliberate: a model-specific 429 immediately advances to
 * the next model bucket while retaining the same Groq credential.
 */
export function getGroqTextModelOrder(preferredModel?: string): string[] {
    return uniqueModels([
        preferredModel,
        getGroqPrimaryModel(),
        getGroqFallbackModel(),
        ...DEFAULT_GROQ_TEXT_RESERVE_MODELS,
        ...configuredFallbacks(),
    ]);
}

export function getGroqVisionModelOrder(): string[] {
    return uniqueModels([
        process.env.GROQ_VISION_MODEL_PRIMARY,
        getGroqPrimaryModel(),
        process.env.GROQ_VISION_MODEL_FALLBACK,
        getGroqFallbackModel(),
        ...configuredVisionFallbacks(),
    ]);
}
