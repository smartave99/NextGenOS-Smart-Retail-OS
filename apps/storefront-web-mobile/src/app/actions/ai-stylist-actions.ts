"use server";

import { generateStylistAdvice, generateGiftRecommendations } from "@/lib/llm-service";
import { getFilteredProducts } from "@/app/actions";
import { allowServerAction } from "@/lib/server-action-rate-limit";

function parseBudget(value: string): number | undefined {
    const amounts = value.match(/\d[\d,]*/g)?.map((amount) => Number(amount.replace(/,/g, "")));
    return amounts?.filter(Number.isFinite).sort((a, b) => b - a)[0];
}

export async function getStylistAdvice(data: {
    gender: string;
    style: string;
    occasion: string;
    budget: string;
    colors: string[];
}) {
    try {
        if (!await allowServerAction("ai-stylist", 10, 300)) {
            throw new Error("Stylist limit reached. Please try again in a few minutes.");
        }
        const products = await getFilteredProducts({
            search: [data.style, data.occasion, ...data.colors].filter(Boolean).join(" "),
            maxPrice: parseBudget(data.budget),
            available: true,
            sort: "relevance",
        });
        const inventory = products.length > 0
            ? products
            : await getFilteredProducts({ maxPrice: parseBudget(data.budget), available: true, sort: "featured" });
        return await generateStylistAdvice(data, inventory);
    } catch (error) {
        console.error("Stylist error:", error);
        throw new Error("Failed to get stylist advice.");
    }
}

export async function getGiftRecommendations(data: {
    relation: string;
    age: string;
    interests: string[];
    occasion: string;
    budget: string;
}) {
    try {
        if (!await allowServerAction("gift-concierge", 10, 300)) {
            throw new Error("Gift concierge limit reached. Please try again in a few minutes.");
        }
        const products = await getFilteredProducts({
            search: data.interests.join(" "),
            maxPrice: parseBudget(data.budget),
            available: true,
            sort: "relevance",
        });
        const inventory = products.length > 0
            ? products
            : await getFilteredProducts({ maxPrice: parseBudget(data.budget), available: true, sort: "featured" });
        return await generateGiftRecommendations(data, inventory);
    } catch (error) {
        console.error("Gift concierge error:", error);
        throw new Error("Failed to get gift recommendations.");
    }
}
