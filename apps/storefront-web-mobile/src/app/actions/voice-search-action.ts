"use server";

import { callGroqWhisperAPI } from "@/lib/llm-service";
import { headers } from "next/headers";
import { checkRateLimit } from "@/lib/rate-limit";

export async function processVoiceSearch(formData: FormData) {
    const file = formData.get("audio") as File;

    if (!file) {
        throw new Error("No audio file provided");
    }
    if (file.size > 10 * 1024 * 1024) {
        return { success: false, error: "Audio is too large (max 10MB)" };
    }
    if (!file.type.startsWith("audio/")) {
        return { success: false, error: "Unsupported audio format" };
    }

    try {
        const requestHeaders = await headers();
        const identifier = requestHeaders.get("x-forwarded-for")?.split(",")[0]?.trim() ||
            requestHeaders.get("x-real-ip") ||
            "anonymous";
        const rateLimit = await checkRateLimit(identifier, {
            limit: 8,
            windowSeconds: 60,
            prefix: "voice-search",
        });
        if (!rateLimit.allowed) {
            return { success: false, error: "Voice search limit reached. Please wait a moment." };
        }

        console.log(`[VoiceSearch] Processing audio: ${file.name}, size: ${file.size}, type: ${file.type}`);

        // Prepare FormData for the API call
        const apiFormData = new FormData();
        apiFormData.append("file", file);
        apiFormData.append("model", "whisper-large-v3-turbo");

        const transcript = await callGroqWhisperAPI(apiFormData);
        console.log(`[VoiceSearch] Transcript: ${transcript}`);

        return { success: true, text: transcript };
    } catch (error) {
        console.error("[VoiceSearch] Error processing voice:", error);
        return { success: false, error: "Failed to process voice command" };
    }
}
