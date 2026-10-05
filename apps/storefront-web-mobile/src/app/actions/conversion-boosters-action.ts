"use server";

import { unstable_cache } from "next/cache";
import { generateSocialProof, generateDealInsight } from "@/lib/llm-service";

/**
 * Generate a social proof snippet for a product.
 * Returns a short string like "Trending in Mumbai!"
 */
export async function getSocialProof(
    product: { id?: string; name: string; categoryId: string; tags: string[] },
    salesStats?: { salesInLastMonth: number; popularInCity?: string }
): Promise<{ success: boolean; proof?: string; error?: string }> {
    try {
        const cacheKey = product.id ? `social-proof-${product.id}` : `social-proof-${product.name.replace(/\s+/g, '-')}`;
        const cachedProof = unstable_cache(
            async () => generateSocialProof(product, salesStats),
            [cacheKey],
            { revalidate: 86400, tags: [cacheKey] } // Cache for 24 hours
        );
        const result = await cachedProof();
        return { success: true, proof: result };
    } catch (error) {
        console.error("Social Proof Error:", error);
        return { success: false, error: "Failed to generate social proof." };
    }
}

/**
 * Generate a deal insight snippet for a product.
 * Returns a short string like "🔥 Huge 40% drop!"
 */
export async function getDealInsight(
    product: { id?: string; name: string; price: number; originalPrice?: number; description: string }
): Promise<{ success: boolean; insight?: string; error?: string }> {
    try {
        const cacheKey = product.id ? `deal-insight-${product.id}` : `deal-insight-${product.name.replace(/\s+/g, '-')}`;
        const cachedInsight = unstable_cache(
            async () => generateDealInsight(product),
            [cacheKey],
            { revalidate: 86400, tags: [cacheKey] } // Cache for 24 hours
        );
        const result = await cachedInsight();
        return { success: true, insight: result };
    } catch (error) {
        console.error("Deal Insight Error:", error);
        return { success: false, error: "Failed to generate deal insight." };
    }
}
