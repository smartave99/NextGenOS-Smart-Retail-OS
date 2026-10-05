import "server-only";

import { Annotation, END, START, StateGraph } from "@langchain/langgraph";
import { getRecommendations } from "@/lib/recommendation-engine";
import type {
    RecommendationRequest,
    RecommendationResponse,
} from "@/types/assistant-types";

const ShoppingAgentState = Annotation.Root({
    request: Annotation<RecommendationRequest>(),
    response: Annotation<RecommendationResponse | null>(),
    traceId: Annotation<string>(),
    startedAt: Annotation<number>(),
    error: Annotation<string | null>(),
});

function prepareRequest(state: typeof ShoppingAgentState.State) {
    const query = state.request.query.trim();
    if (!query) return { error: "Query is required" };

    return {
        request: {
            ...state.request,
            query,
            maxResults: Math.min(Math.max(state.request.maxResults ?? 5, 1), 10),
            messages: state.request.messages?.slice(-20),
        },
        error: null,
    };
}

async function searchAndRecommend(state: typeof ShoppingAgentState.State) {
    if (state.error) {
        return {
            response: {
                success: false,
                error: state.error,
                recommendations: [],
                summary: "",
                processingTime: Date.now() - state.startedAt,
                traceId: state.traceId,
            } satisfies RecommendationResponse,
        };
    }

    const response = await getRecommendations(state.request);
    return { response: { ...response, traceId: state.traceId } };
}

function verifyResponse(state: typeof ShoppingAgentState.State) {
    if (!state.response) {
        return {
            response: {
                success: false,
                error: "The shopping agent returned no response",
                recommendations: [],
                summary: "",
                processingTime: Date.now() - state.startedAt,
                traceId: state.traceId,
            } satisfies RecommendationResponse,
        };
    }

    const seen = new Set<string>();
    const recommendations = state.response.recommendations
        .filter(({ product }) => product.available && !seen.has(product.id) && seen.add(product.id))
        .map((recommendation) => ({
            ...recommendation,
            matchScore: Math.min(100, Math.max(0, recommendation.matchScore)),
        }))
        .slice(0, state.request.maxResults ?? 5);

    return {
        response: {
            ...state.response,
            recommendations,
            traceId: state.traceId,
        },
    };
}

const shoppingAgent = new StateGraph(ShoppingAgentState)
    .addNode("prepare_request", prepareRequest)
    .addNode("search_and_recommend", searchAndRecommend)
    .addNode("verify_response", verifyResponse)
    .addEdge(START, "prepare_request")
    .addEdge("prepare_request", "search_and_recommend")
    .addEdge("search_and_recommend", "verify_response")
    .addEdge("verify_response", END)
    .compile();

export async function runShoppingAgent(
    request: RecommendationRequest
): Promise<RecommendationResponse> {
    const traceId = crypto.randomUUID();
    const result = await shoppingAgent.invoke({
        request,
        response: null,
        traceId,
        startedAt: Date.now(),
        error: null,
    });

    return result.response ?? {
        success: false,
        error: "The shopping agent did not complete",
        recommendations: [],
        summary: "",
        processingTime: 0,
        traceId,
    };
}
