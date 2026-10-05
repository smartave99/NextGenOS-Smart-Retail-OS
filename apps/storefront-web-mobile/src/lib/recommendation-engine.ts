/**
 * Recommendation Engine
 * 
 * Orchestrates the product recommendation flow:
 * 1. Analyze user intent
 * 2. Query relevant products (SQL + RAG semantic search)
 * 3. Rank and filter products
 * 4. Generate recommendations with explanations
 * 
 * RAG Integration: Runs pgvector semantic search in parallel with
 * traditional SQL queries. Results are merged and deduplicated.
 * Semantic matches receive a relevance boost in final ranking.
 */

import { getCategories, getProductByBarcode, searchProducts, Product } from "@/app/actions";
import { analyzeIntent, rankAndSummarize, handleMissingProduct } from "./llm-service";
import { getSearchCache, hashQuery } from "./search-cache";
import {
    getCachedAIResponse,
    getCatalogAIRevision,
    setCachedAIResponse,
} from "./ai-response-cache";
import { getAIConfig } from "./ai-config";
import { semanticSearchProducts } from "./vector-store";
import { extractBarcodeCandidate } from "./barcode";
import {
    classifyAssistantScope,
    createScopedAssistantResponse,
} from "./assistant-scope";
import {
    RecommendationRequest,
    RecommendationResponse,
    IntentAnalysis,
    ProductMatch,
    LLMIntentResponse,
} from "@/types/assistant-types";

const DEFAULT_MAX_RESULTS = 5; // Fallback, overridden by admin config
const MAX_PRODUCTS_TO_ANALYZE = 20;

/**
 * Main recommendation function
 */
export async function getRecommendations(
    request: RecommendationRequest
): Promise<RecommendationResponse> {
    const startTime = Date.now();

    try {
        // Validate request
        if (!request.query || request.query.trim().length === 0) {
            return {
                success: false,
                error: "Query is required",
                recommendations: [],
                summary: "",
                processingTime: Date.now() - startTime,
            };
        }

        const query = request.query.trim();
        const scope = classifyAssistantScope(query);

        // This boundary runs before configuration, cache reads, categories, or
        // intent analysis. An unrelated request therefore makes zero Groq
        // calls and cannot be turned into general-purpose chat by a prompt.
        if (scope.scope !== "shopping") {
            return createScopedAssistantResponse(scope, Date.now() - startTime);
        }

        // Barcode scans are deterministic identifiers. Resolve them directly
        // before intent analysis so an LLM cannot reinterpret or drop the code.
        const barcode = extractBarcodeCandidate(query);
        if (barcode) {
            const product = await getProductByBarcode(barcode, true);
            const barcodeIntent: IntentAnalysis = {
                category: product?.categoryId || null,
                subcategory: product?.subcategoryId || null,
                requirements: ["Exact barcode match"],
                budget: { min: null, max: null },
                preferences: [],
                useCase: "Barcode lookup",
                searchTerm: barcode,
                confidence: 1,
                isGeneralChat: false,
            };

            if (!product) {
                return {
                    success: true,
                    intent: barcodeIntent,
                    recommendations: [],
                    summary: `I couldn't find an available product with barcode ${barcode}. Please check the digits or ask the store team to verify it.`,
                    processingTime: Date.now() - startTime,
                };
            }

            return {
                success: true,
                intent: barcodeIntent,
                recommendations: [{
                    product,
                    matchScore: 100,
                    highlights: ["Exact barcode match", product.available ? "Currently listed as available" : "Check in-store availability"],
                    whyRecommended: "This is the exact product registered to the scanned barcode.",
                }],
                summary: `I found ${product.name} from barcode ${barcode}. You can review it here before visiting the store.`,
                processingTime: Date.now() - startTime,
            };
        }

        const config = await getAIConfig();
        const maxResults = request.maxResults || config.maxRecommendations || DEFAULT_MAX_RESULTS;
        const catalogRevision = await getCatalogAIRevision();

        // Check cache for similar queries
        const cache = getSearchCache();
        const cacheFingerprint = JSON.stringify({
            query: query.toLowerCase(),
            context: request.context || {},
            messages: request.messages?.slice(-12) || [],
            maxResults,
            personaName: config.personaName,
            systemPrompt: config.systemPrompt,
            catalogRevision,
        });
        const queryHash = hashQuery(cacheFingerprint);
        const cacheKey = `query:recommendation:v${catalogRevision}:${queryHash}`;

        const cachedResult = cache.get<RecommendationResponse>(cacheKey);
        if (cachedResult) {
            return {
                ...cachedResult,
                processingTime: Date.now() - startTime,
            };
        }

        const distributedCachedResult = await getCachedAIResponse<RecommendationResponse>(
            "recommendation",
            cacheFingerprint
        );
        if (distributedCachedResult) {
            cache.set(cacheKey, distributedCachedResult, 2 * 60 * 1000);
            return {
                ...distributedCachedResult,
                processingTime: Date.now() - startTime,
            };
        }

        // Step 1: Get categories for intent analysis (cached in getCategories)
        const categories = await getCategories();

        // Step 2: Analyze user intent (1st LLM call)
        const intentResponse = await analyzeIntent(query, categories, request.messages);
        const intent = mapIntentResponse(intentResponse);

        // A model must never be allowed to upgrade a customer request into
        // general-purpose chat. Genuine greetings have already been answered
        // locally above; this is a defensive fallback for misclassification.
        if (intentResponse.isGeneralChat) {
            return createScopedAssistantResponse(
                { scope: "out_of_scope" },
                Date.now() - startTime
            );
        }

        // Step 3: Query relevant products via DUAL retrieval (SQL + RAG semantic search)
        // CHECK: If the previous message was from the assistant asking for details about a missing product,
        // we should NOT fallback to general search if the current query is just a budget/detail.
        const lastAssistantMessage = request.messages?.filter(m => m.role === "assistant").slice(-1)[0];
        const isInMissingProductFlow = lastAssistantMessage?.content.includes("don't have") ||
            lastAssistantMessage?.content.includes("request");

        // Run SQL query and semantic search in PARALLEL for speed
        const [sqlProducts, semanticResults] = await Promise.all([
            queryProducts(intent, {
                ...request.context,
                preventFallback: isInMissingProductFlow && !intent.category
            }),
            // RAG: Semantic search using pgvector (non-blocking, fails gracefully)
            semanticSearchProducts(query, 10).catch(err => {
                console.warn("[RecommendationEngine] RAG semantic search failed, using SQL only:", err);
                return [] as Array<{ product: Product; similarity: number }>;
            }),
        ]);

        // Merge SQL + RAG results with deduplication
        const products = mergeSearchResults(sqlProducts, semanticResults);

        if (products.length === 0) {
            // Check if this looks like a missing product scenario that we should handle
            const decision = await handleMissingProduct(query, intentResponse, request.messages);

            // Otherwise, just return the question/response from handleMissingProduct (or fallback to old one)
            return {
                success: true,
                intent,
                recommendations: [],
                summary: decision.response,
                processingTime: Date.now() - startTime,
            };
        }

        // Step 4: Rank products AND generate summary in single LLM call (2nd LLM call)
        let rankings: Array<{ productId: string; matchScore: number; highlights: string[]; whyRecommended: string }> = [];
        let summary = "";

        try {
            const result = await rankAndSummarize(
                query,
                products.slice(0, MAX_PRODUCTS_TO_ANALYZE),
                intentResponse
            );
            rankings = result.rankings;
            summary = result.summary;
        } catch (rankError) {
            console.warn("[RecommendationEngine] rankAndSummarize failed, using fallback:", rankError);
            // Graceful fallback: return top products without AI ranking
            rankings = products.slice(0, maxResults).map(p => ({
                productId: p.id,
                matchScore: 70,
                highlights: [p.description?.substring(0, 60) || p.name],
                whyRecommended: `This ${p.name} might be what you're looking for.`,
            }));
            summary = `I found ${products.length} products that might interest you. Here are my top picks:`;
        }

        // Step 5: Build recommendations
        const recommendations = buildRecommendations(rankings, products, maxResults);

        const result: RecommendationResponse = {
            success: true,
            intent,
            recommendations,
            summary,
            processingTime: Date.now() - startTime,
        };

        // Cache the result for 2 minutes
        cache.set(cacheKey, result, 2 * 60 * 1000);
        await setCachedAIResponse(
            "recommendation",
            cacheFingerprint,
            result,
            2 * 60
        );

        return result;
    } catch (error) {
        console.error("[RecommendationEngine] Error:", error);
        return {
            success: false,
            error: error instanceof Error ? error.message : "An unexpected error occurred",
            recommendations: [],
            summary: "",
            processingTime: Date.now() - startTime,
        };
    }
}

/**
 * Map LLM intent response to our IntentAnalysis type
 */
function mapIntentResponse(response: LLMIntentResponse): IntentAnalysis {
    return {
        category: response.category,
        subcategory: response.subcategory,
        requirements: response.requirements || [],
        budget: {
            min: response.budgetMin,
            max: response.budgetMax,
        },
        preferences: response.preferences || [],
        useCase: response.useCase || "",
        searchTerm: response.searchTerm || null,
        confidence: response.confidence || 0.5,
        isGeneralChat: response.isGeneralChat || false,
    };
}

export async function queryProducts(
    intent: IntentAnalysis,
    context: RecommendationRequest["context"]
): Promise<Product[]> {
    const { getFilteredProducts } = await import("@/app/actions");

    // 1. Determine category and subcategory
    // If intent has a subcategory, we prioritize that
    const category = intent.category || context?.categoryId || undefined;
    const subcategory = intent.subcategory || undefined;

    // 2. Fetch products using the robust filtered products action
    // This handles both text search (searchTerm) and category/subcategory filtering
    let products = await getFilteredProducts({
        search: intent.searchTerm || undefined,
        category: category,
        subcategory: subcategory,
        minPrice: intent.budget.min || undefined,
        maxPrice: intent.budget.max || context?.budget || undefined,
        available: true, // Only search available products for recommendations
        sort: "newest"
    });

    // Vision models deliberately return short descriptive phrases rather than
    // exact catalogue titles. PostgreSQL's first-pass search requires the
    // complete phrase to be contiguous, so a correct visual description such
    // as "gold butterfly floral bottle" can miss a real product named
    // "Decorative Gold-Tone Floral and Butterfly Bottle". If that strict pass
    // finds nothing, use the existing word-scored catalogue search. Keep the
    // inferred category first, then remove it only as a final recovery step in
    // case the intent model classified an uncategorised or newly added item.
    if (products.length === 0 && intent.searchTerm) {
        products = await searchProducts(
            intent.searchTerm,
            category,
            subcategory,
            true
        );

        if (products.length === 0 && (category || subcategory)) {
            products = await searchProducts(intent.searchTerm, undefined, undefined, true);
        }
    }

    // 3. Exclude specific products if requested (e.g., currently viewed product)
    if (context?.excludeProductIds && context.excludeProductIds.length > 0) {
        const excludeSet = new Set(context.excludeProductIds);
        return products.filter(p => !excludeSet.has(p.id));
    }

    return products;
}

/**
 * Build ProductMatch array from rankings
 */
function buildRecommendations(
    rankings: Array<{ productId: string; matchScore: number; highlights: string[]; whyRecommended: string }>,
    products: Product[],
    maxResults: number
): ProductMatch[] {
    const productMap = new Map(products.map(p => [p.id, p]));

    return rankings
        .filter(r => productMap.has(r.productId))
        .sort((a, b) => b.matchScore - a.matchScore) // Ensure sorted by score after validation
        .slice(0, maxResults)
        .map(r => ({
            product: productMap.get(r.productId)!,
            matchScore: r.matchScore,
            highlights: r.highlights,
            whyRecommended: r.whyRecommended,
        }));
}

/**
 * Get category name by ID
 */
export async function getCategoryName(categoryId: string): Promise<string | null> {
    const categories = await getCategories();
    const category = categories.find(c => c.id === categoryId);
    return category?.name || null;
}

/**
 * Merge SQL-filtered products with RAG semantic search results.
 * Deduplicates by product ID, preserving all unique products from both sources.
 * Products found by semantic search but not SQL get added at the end.
 * 
 * @param sqlProducts - Products from traditional SQL/Prisma query
 * @param semanticResults - Products from pgvector cosine similarity search
 * @returns Deduplicated merged product list
 */
function mergeSearchResults(
    sqlProducts: Product[],
    semanticResults: Array<{ product: Product; similarity: number }>
): Product[] {
    const mergedMap = new Map<string, { product: Product; score: number }>();
    const sqlDenominator = Math.max(sqlProducts.length - 1, 1);
    sqlProducts.forEach((product, index) => {
        const sqlScore = 1 - (index / sqlDenominator);
        mergedMap.set(product.id, { product, score: sqlScore * 0.6 });
    });

    let ragBonusCount = 0;
    for (const { product, similarity } of semanticResults) {
        const semanticScore = Math.min(1, Math.max(0, similarity));
        const existing = mergedMap.get(product.id);
        if (existing) {
            existing.score += semanticScore * 0.4 + 0.2;
        } else {
            mergedMap.set(product.id, { product, score: semanticScore * 0.4 });
            ragBonusCount++;
        }
    }

    if (ragBonusCount > 0) {
        console.log(`[RecommendationEngine] RAG found ${ragBonusCount} additional products not caught by SQL search`);
    }

    return Array.from(mergedMap.values())
        .sort((a, b) => b.score - a.score)
        .map(({ product }) => product);
}
