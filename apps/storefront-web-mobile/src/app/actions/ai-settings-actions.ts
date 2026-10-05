"use server";

import { revalidatePath, revalidateTag } from "next/cache";
import { invalidateAIConfig } from "@/lib/ai-config";
import { requireAdminSession } from "@/lib/auth-server";

// ==================== AI SETTINGS TYPES ====================

export interface AISettings {
    enabled: boolean;
    showVibeSelector: boolean;
    personaName: string;
    greeting: string;
    systemPrompt: string;
    temperature: number;
    maxTokens: number;
    providerPriority: "groq" | "lightning" | "google" | "auto";
    maxRecommendations: number;
    enableVoiceInput: boolean;
    enableProductRequests: boolean;
    updatedAt?: Date;
}

const DEFAULT_AI_SETTINGS: AISettings = {
    enabled: true,
    showVibeSelector: true,
    personaName: "Genie",
    greeting: `Hey there! ✨ I'm Genie, your personal shopping assistant at ${SHOP_NAME}! Whether you need help finding the perfect product, a gift for someone special, or just want to explore what's trending — I've got you covered. What are you looking for today? 🛍️`,
    systemPrompt: `You are Genie, a warm and enthusiastic Personal Shopping Assistant at ${SHOP_NAME} — India's curated lifestyle store. You speak like a trusted shopping friend, not a corporate bot. Be conversational, use emojis naturally, ask smart follow-up questions about preferences/budget/occasion, proactively suggest complementary products, and celebrate their choices. You're multilingual (English, Hindi, Hinglish) — match the customer's language. Never hallucinate products. Always guide them toward discovery with helpful nudges and suggestions.`,
    temperature: 0.7,
    maxTokens: 2048,
    providerPriority: "groq",
    maxRecommendations: 5,
    enableVoiceInput: false,
    enableProductRequests: true,
};

// ==================== SERVER ACTIONS ====================

import { getBlobJson, updateBlobJson } from "./blob-json";
import { SHOP_NAME } from "@/lib/shop-name";

const BLOB_FILENAME = "llmo.json";

/**
 * Get AI settings from Vercel Blob (admin use)
 */
export async function getAISettings(): Promise<AISettings> {
    const data = await getBlobJson<Partial<AISettings>>(BLOB_FILENAME, DEFAULT_AI_SETTINGS);
    return {
        ...DEFAULT_AI_SETTINGS,
        ...data,
        providerPriority: "groq",
    };
}

/**
 * Update AI settings in Vercel Blob (admin use)
 */
export async function updateAISettings(data: Partial<AISettings>): Promise<{ success: boolean; error?: string }> {
    try {
        await requireAdminSession("api-keys");
        // Validate temperature range
        if (data.temperature !== undefined && (data.temperature < 0 || data.temperature > 2)) {
            return { success: false, error: "Temperature must be between 0 and 2" };
        }

        // Validate maxTokens
        if (data.maxTokens !== undefined && (data.maxTokens < 256 || data.maxTokens > 8192)) {
            return { success: false, error: "Max tokens must be between 256 and 8192" };
        }

        const currentSettings = await getAISettings();
        const newSettings = {
            ...currentSettings,
            ...data,
            providerPriority: "groq" as const,
            updatedAt: new Date()
        };

        const result = await updateBlobJson(BLOB_FILENAME, newSettings);

        if (!result.success) {
            throw new Error(result.error || "Failed to save to Blob");
        }

        revalidatePath("/admin/ai-settings");
        revalidatePath("/", "layout"); // Revalidate homepage so Shop by Vibe toggles immediately
        revalidateTag("blob-llmo.json"); // Invalidates the fetch cache used by getBlobJson

        // Invalidate cached AI config so next LLM call picks up new settings
        invalidateAIConfig();

        return { success: true };
    } catch (error: unknown) {
        console.error("[AI Settings] Error updating:", error);
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    }
}

/**
 * Get public-facing AI settings (for the frontend chat widget)
 * Only returns fields safe for the client
 */
export async function getPublicAISettings(): Promise<{
    enabled: boolean;
    personaName: string;
    greeting: string;
    enableVoiceInput: boolean;
    enableProductRequests: boolean;
}> {
    try {
        const settings = await getAISettings();
        return {
            enabled: settings.enabled,
            personaName: settings.personaName,
            greeting: settings.greeting,
            enableVoiceInput: settings.enableVoiceInput,
            enableProductRequests: settings.enableProductRequests,
        };
    } catch (error) {
        console.error("[AI Settings] Error fetching public settings:", error);
        return {
            enabled: true,
            personaName: "Genie",
            greeting: DEFAULT_AI_SETTINGS.greeting,
            enableVoiceInput: false,
            enableProductRequests: true,
        };
    }
}
