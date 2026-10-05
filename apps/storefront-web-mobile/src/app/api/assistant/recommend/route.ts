/**
 * Product Recommendation API Endpoint
 * 
 * POST /api/assistant/recommend
 * 
 * Accepts natural-language shopping queries and returns product recommendations.
 * Syncs API keys only after the business-only boundary allows a request through.
 */

import { NextRequest, NextResponse } from "next/server";
import { z } from "zod";
import { syncAPIKeysToManager } from "@/app/api-key-actions";
import { getAISettings } from "@/app/actions/ai-settings-actions";
import { runShoppingAgent } from "@/lib/agent/shopping-agent";
import { checkRateLimit, getRequestIdentifier } from "@/lib/rate-limit";
import {
    classifyAssistantScope,
    createScopedAssistantResponse,
} from "@/lib/assistant-scope";

const messageSchema = z.object({
    role: z.enum(["user", "assistant"]),
    content: z.string().trim().min(1).max(2_000),
});

const recommendationRequestSchema = z.object({
    query: z.string().trim().min(1).max(1_000),
    context: z.object({
        budget: z.number().finite().nonnegative().max(100_000_000).optional(),
        categoryId: z.string().trim().max(100).optional(),
        preferences: z.array(z.string().trim().max(100)).max(20).optional(),
        excludeProductIds: z.array(z.string().uuid()).max(50).optional(),
        preventFallback: z.boolean().optional(),
    }).optional(),
    messages: z.array(messageSchema).max(20).optional(),
    maxResults: z.number().int().min(1).max(10).optional(),
}).strict();

function rateLimitHeaders(result: Awaited<ReturnType<typeof checkRateLimit>>) {
    return {
        "X-RateLimit-Limit": String(result.limit),
        "X-RateLimit-Remaining": String(result.remaining),
        "X-RateLimit-Reset": String(Math.ceil(result.resetAt / 1000)),
    };
}

export async function POST(request: NextRequest) {
    try {
        const rateLimit = await checkRateLimit(getRequestIdentifier(request), {
            limit: 20,
            windowSeconds: 60,
            prefix: "assistant",
        });
        if (!rateLimit.allowed) {
            return NextResponse.json(
                { success: false, error: "Too many requests. Please wait a moment and try again." },
                { status: 429, headers: rateLimitHeaders(rateLimit) }
            );
        }

        // Check if AI is enabled by admin
        const aiSettings = await getAISettings();
        if (!aiSettings.enabled) {
            return NextResponse.json({
                success: true,
                recommendations: [],
                summary: "I'm currently unavailable. Please check back later!",
                processingTime: 0,
            });
        }

        const parsed = recommendationRequestSchema.safeParse(await request.json());
        if (!parsed.success) {
            return NextResponse.json(
                { success: false, error: "Invalid request", details: z.flattenError(parsed.error).fieldErrors },
                { status: 400, headers: rateLimitHeaders(rateLimit) }
            );
        }

        // Reject unrelated chat locally before touching credentials or the
        // shopping agent. The engine repeats this check as a defense in depth
        // for any future non-HTTP caller.
        const scope = classifyAssistantScope(parsed.data.query);
        if (scope.scope !== "shopping") {
            return NextResponse.json(
                createScopedAssistantResponse(scope),
                { headers: rateLimitHeaders(rateLimit) }
            );
        }

        // Sync API keys only for a request that is allowed to reach Groq.
        await syncAPIKeysToManager();

        const response = await runShoppingAgent(parsed.data);

        if (!response.success) {
            return NextResponse.json(response, { status: 500 });
        }

        return NextResponse.json(response, { headers: rateLimitHeaders(rateLimit) });
    } catch (error) {
        console.error("[API /assistant/recommend] Error:", error);

        // Handle JSON parse errors
        if (error instanceof SyntaxError) {
            return NextResponse.json(
                { success: false, error: "Invalid JSON in request body" },
                { status: 400 }
            );
        }

        return NextResponse.json(
            {
                success: false,
                error: "Internal server error",
                recommendations: [],
                summary: "",
            },
            { status: 500 }
        );
    }
}

// Optionally support GET for simple queries
export async function GET(request: NextRequest) {
    const rateLimit = await checkRateLimit(getRequestIdentifier(request), {
        limit: 30,
        windowSeconds: 60,
        prefix: "assistant-get",
    });
    if (!rateLimit.allowed) {
        return NextResponse.json(
            { success: false, error: "Too many requests. Please wait a moment and try again." },
            { status: 429, headers: rateLimitHeaders(rateLimit) }
        );
    }

    const searchParams = request.nextUrl.searchParams;
    const query = searchParams.get("q") || searchParams.get("query");

    if (!query) {
        return NextResponse.json(
            { success: false, error: "Query parameter 'q' is required" },
            { status: 400 }
        );
    }

    const budget = searchParams.get("budget");
    const category = searchParams.get("category");

    const parsed = recommendationRequestSchema.safeParse({
        query,
        context: {
            budget: budget ? parseFloat(budget) : undefined,
            categoryId: category || undefined,
        },
        maxResults: 5,
    });

    if (!parsed.success) {
        return NextResponse.json(
            { success: false, error: "Invalid query parameters" },
            { status: 400, headers: rateLimitHeaders(rateLimit) }
        );
    }

    const scope = classifyAssistantScope(parsed.data.query);
    if (scope.scope !== "shopping") {
        return NextResponse.json(
            createScopedAssistantResponse(scope),
            { headers: rateLimitHeaders(rateLimit) }
        );
    }

    // Sync API keys only for a request that is allowed to reach Groq.
    await syncAPIKeysToManager();

    const response = await runShoppingAgent(parsed.data);

    if (!response.success) {
        return NextResponse.json(response, { status: 500 });
    }

    return NextResponse.json(response, { headers: rateLimitHeaders(rateLimit) });
}
