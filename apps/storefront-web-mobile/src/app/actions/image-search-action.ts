"use server";

import { callVisionAPI } from "@/lib/llm-service";
import { headers } from "next/headers";
import { checkRateLimit } from "@/lib/rate-limit";
import { APIKeyExhaustedError, LLMServiceError } from "@/types/assistant-types";
import { syncAPIKeysToManager } from "@/app/api-key-actions";

/**
 * Turns a vision failure into a message that tells the user (and, outside
 * production, the developer) what actually broke. Every branch still logs the
 * full error server-side; only the phrasing differs.
 */
function describeVisionFailure(error: unknown): string {
    if (error instanceof APIKeyExhaustedError) {
        return "Image search is not configured on this server. Please contact support.";
    }

    if (error instanceof LLMServiceError) {
        const status = error.statusCode;

        if (error.isRateLimited || status === 402) {
            return "Image search is busy right now. Please try again in a moment.";
        }
        if (status === 401 || status === 403) {
            return "Image search credentials were rejected. Please contact support.";
        }
        if (status !== undefined && status >= 400 && status < 500) {
            // Misconfigured vision model is the usual cause here, and it is
            // invisible to the user unless we say so.
            return process.env.NODE_ENV === "production"
                ? "Image search is misconfigured on this server. Please contact support."
                : `Image search is misconfigured: ${error.message}`;
        }
    }

    if (process.env.NODE_ENV !== "production" && error instanceof Error) {
        return `Failed to analyze image: ${error.message}`;
    }

    return "Failed to analyze image. Please try again.";
}

export async function analyzeImage(formData: FormData) {
    const file = formData.get("image") as File;

    if (!file) {
        return { success: false, error: "No image provided" };
    }

    // Base64 expands the request by roughly 33%; stay below Groq's request cap.
    if (file.size > 2.75 * 1024 * 1024) {
        return { success: false, error: "Image too large for AI search (max 2.75MB)" };
    }
    if (!["image/jpeg", "image/png", "image/webp"].includes(file.type)) {
        return { success: false, error: "Unsupported image format" };
    }

    try {
        const requestHeaders = await headers();
        const identifier = requestHeaders.get("x-forwarded-for")?.split(",")[0]?.trim() ||
            requestHeaders.get("x-real-ip") ||
            "anonymous";
        const rateLimit = await checkRateLimit(identifier, {
            limit: 8,
            windowSeconds: 60,
            prefix: "image-search",
        });
        if (!rateLimit.allowed) {
            return { success: false, error: "Image search limit reached. Please wait a moment." };
        }

        await syncAPIKeysToManager();

        const arrayBuffer = await file.arrayBuffer();
        const buffer = Buffer.from(arrayBuffer);
        const base64Image = buffer.toString("base64");
        const mimeType = file.type;
        const dataUrl = `data:${mimeType};base64,${base64Image}`;

        const searchKeywords = await callVisionAPI(dataUrl);

        return { success: true, query: searchKeywords };
    } catch (error) {
        console.error("Image analysis failed:", error);
        return { success: false, error: describeVisionFailure(error) };
    }
}
