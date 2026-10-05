"use server";

import { createProductRequest } from "@/app/actions/request-actions";
import { emitWorkflowEvent } from "@/lib/workflow-events";
import { z } from "zod";

export interface OOSUrgencyResult {
    success: boolean;
    data?: {
        headline: string;
        subtext: string;
        urgencyLevel: "high" | "medium" | "low";
    };
    error?: string;
}

export interface RestockSubscriptionResult {
    success: boolean;
    message?: string;
    error?: string;
}

export async function getOOSUrgency(
    productName: string,
    sku: string,
    stockLevel: number
): Promise<OOSUrgencyResult> {
    void sku;
    const safeStock = Math.max(0, Math.floor(stockLevel));
    return {
        success: true,
        data: safeStock === 0
            ? {
                headline: "Currently out of stock",
                subtext: `Join the ${productName} restock list and we'll let you know when availability changes.`,
                urgencyLevel: "low",
            }
            : {
                headline: `Only ${safeStock} currently listed`,
                subtext: "Stock can change before your store visit, so please check availability.",
                urgencyLevel: safeStock <= 2 ? "high" : "medium",
            },
    };
}

export async function subscribeToRestock(
    productName: string,
    email: string
): Promise<RestockSubscriptionResult> {
    try {
        const validated = z.object({
            productName: z.string().trim().min(1).max(200),
            email: z.string().trim().email().max(254),
        }).parse({ productName, email });

        const request = await createProductRequest({
            productName: validated.productName,
            brand: "Restock alert",
            description: `Customer requested a back-in-stock notification for ${validated.productName}.`,
            contactInfo: validated.email,
        });
        if (!request.success || !request.id) {
            throw new Error(request.error || "Unable to save restock request");
        }

        await emitWorkflowEvent("restock.requested", {
            requestId: request.id,
            productName: validated.productName,
            email: validated.email,
        });

        return {
            success: true,
            message: "You're on the restock list. We'll contact you when availability changes.",
        };
    } catch (error) {
        console.error("Error subscribing to restock:", error);
        return {
            success: false,
            error: "Failed to subscribe"
        };
    }
}
