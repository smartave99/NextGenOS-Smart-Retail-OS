import { extractBarcodeCandidate } from "./barcode";
import type { IntentAnalysis, RecommendationResponse } from "@/types/assistant-types";
import { SHOP_NAME } from "@/lib/shop-name";

export type AssistantScope = "shopping" | "greeting" | "out_of_scope";

export interface AssistantScopeDecision {
    scope: AssistantScope;
}

const GREETING_PATTERN = /^(?:hi|hello|hey|namaste|adaab|salaam|assalam(?:u)?\s*alaikum|good\s+(?:morning|afternoon|evening))(?:\s+(?:genie|smart\s*avenue))?[!,.?\s]*$/i;

// These requests have no legitimate storefront-discovery purpose. Check them
// before broader shopping signals so phrases such as "write a poem" cannot
// borrow a shopping word to reach an LLM.
const OFF_TOPIC_PATTERN = /\b(?:poem|essay|story|joke|lyrics?|song|homework|coding|program(?:ming)?|debug(?:ging)?|algorithm|translate|translation|summari[sz]e|math(?:s|ematics)?|physics|chemistry|biology|medical|medicine|diagnos(?:is|e)|legal|law|politics?|election|weather|cricket|football|stock\s*market|share\s*market|crypto(?:currency)?|recipe|travel|relationship|astrology|horoscope|religion|history|geography)\b/i;

const GENERIC_ANSWER_REQUEST_PATTERN = /\b(?:write|compose|draft|tell(?:\s+me)?|explain|solve|teach|translate|summari[sz]e|calculate|diagnose|predict)\b/i;

const SHOPPING_SIGNAL_PATTERN = /(?:\b(?:smart\s*avenue|product|products|item|items|shop|store|visit|department|category|categories|browse|find|show|search|recommend|recommendation|compare|comparison|gift|present|offer|offers|deal|deals|discount|sale|price|cost|budget|available|availability|stock|arrival|arrivals|trending|popular|barcode|ean|upc|sku|scan|image|photo|camera|colour|color|size|brand|material|feature|variant|quality|delivery|order|purchase|buy|pickup|reservation|reserve|address|location|timings?|hours|open|close|contact|whatsapp)\b|₹|\brs\.?\s*\d)/i;

// Covers direct catalogue-style searches, including the concise phrases Groq
// Vision returns after reading a product photo. Customers can still ask for an
// unknown item by using an ordinary shopping phrase such as "I need a...".
const PRODUCT_TERM_PATTERN = /\b(?:bottle|flask|thermos|tumbler|toy|toys|teddy|stationery|pen|pencil|notebook|diary|book|eraser|marker|cosmetic|makeup|lipstick|nail|cream|lotion|soap|shampoo|bangle|jewell?ry|bracelet|earring|ring|home|decor|decoration|kitchen|plastic|container|box|basket|gadget|camera|mobile|phone|charger|cable|earphones?|headphones?|speaker|watch|bag|wallet|purse|shoe|shoes|sandal|dress|shirt|t-?shirt|clothes?|saree|kurti|jeans|mug|cup|plate|bowl|spoon|blender|mixer|scissors?|knife|tool|umbrella|light|lamp|frame|cushion|pillow|bed|mirror|perfume|deodorant|baby|kids?|school|office|grocer(?:y|ies)|snack|food|drink)\b/i;

const HINGLISH_SHOPPING_PATTERN = /(?:\b(?:mujhe|mujhko|humko)\b.*\b(?:chahiye|dikha(?:o|iye)?|dikhaiye)\b|\b(?:kitna|kitne)\b.*\b(?:price|ka|ki|ke)\b|\b(?:available|stock|offer|discount)\b.*\b(?:hai|hain)\b)/i;

// Lets customers ask for a new or unfamiliar item without granting broad
// free-form chat. Obvious non-shopping prompts are still rejected first.
const ENGLISH_SHOPPING_REQUEST_PATTERN = /\b(?:i\s+(?:need|want)|(?:looking|look)\s+for|need\s+(?:a|an|some)|want\s+(?:a|an|some))\b/i;

export function classifyAssistantScope(query: string): AssistantScopeDecision {
    const normalized = query.trim().replace(/\s+/g, " ");

    if (extractBarcodeCandidate(normalized)) {
        return { scope: "shopping" };
    }

    if (GREETING_PATTERN.test(normalized)) {
        return { scope: "greeting" };
    }

    const hasShoppingSignal =
        SHOPPING_SIGNAL_PATTERN.test(normalized) ||
        PRODUCT_TERM_PATTERN.test(normalized) ||
        HINGLISH_SHOPPING_PATTERN.test(normalized) ||
        ENGLISH_SHOPPING_REQUEST_PATTERN.test(normalized);

    // A direct product phrase such as "weatherproof umbrella" is legitimate,
    // but a request to write, teach, diagnose, or otherwise answer a generic
    // question is not. This prevents false rejections for product attributes
    // while keeping general-purpose tasks out of the model.
    if (
        OFF_TOPIC_PATTERN.test(normalized) &&
        (GENERIC_ANSWER_REQUEST_PATTERN.test(normalized) || !hasShoppingSignal)
    ) {
        return { scope: "out_of_scope" };
    }

    if (hasShoppingSignal) {
        return { scope: "shopping" };
    }

    return { scope: "out_of_scope" };
}

function scopeIntent(scope: AssistantScope): IntentAnalysis {
    return {
        category: null,
        subcategory: null,
        requirements: [],
        budget: { min: null, max: null },
        preferences: [],
        useCase: scope === "greeting" ? "Storefront greeting" : `Outside ${SHOP_NAME} shopping scope`,
        searchTerm: null,
        confidence: 1,
        // The client uses this flag to avoid offering a product-request link
        // for a greeting or an unrelated request.
        isGeneralChat: true,
    };
}

/**
 * Returns a useful response without loading API credentials or invoking an
 * LLM. This is intentionally shared by the API route and recommendation
 * engine so a future caller cannot bypass the business-only boundary.
 */
export function createScopedAssistantResponse(
    decision: AssistantScopeDecision,
    processingTime: number = 0
): RecommendationResponse {
    const isGreeting = decision.scope === "greeting";

    return {
        success: true,
        intent: scopeIntent(decision.scope),
        recommendations: [],
        summary: isGreeting
            ? `Hi, I’m Genie, ${SHOP_NAME}’s shopping assistant. I can help you find products, compare options, check current offers, plan a store visit, or request an item. What are you shopping for?`
            : `I can help only with ${SHOP_NAME} products, current offers, store visits, availability, comparisons, and product requests. Tell me what you’re shopping for.`,
        processingTime,
    };
}
