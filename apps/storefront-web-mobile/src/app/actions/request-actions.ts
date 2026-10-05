"use server";

import { fanOutWrite, getWriteClient } from "@/lib/db-manager";
import { revalidatePath, revalidateTag, unstable_cache } from "next/cache";
import { z } from "zod";
import { emitWorkflowEvent } from "@/lib/workflow-events";
import { requireAdminSession } from "@/lib/auth-server";
import { allowServerAction } from "@/lib/server-action-rate-limit";

// --- Types & Schema ---

const productRequestSchema = z.object({
    productName: z.string().trim().min(1, "Product name is required").max(200),
    brand: z.string().trim().max(100).optional(),
    description: z.string().trim().min(10, "Please provide more details").max(2_000),
    minPrice: z.number().min(0).optional(),
    maxPrice: z.number().min(0).optional(),
    imageUrl: z.string().url().max(2_000).optional().or(z.literal("")),
    contactInfo: z.string().trim().min(5, "Contact info is required").max(254),
});

export type ProductRequestInput = z.infer<typeof productRequestSchema>;

export interface ProductRequest extends ProductRequestInput {
    id: string;
    status: "PENDING" | "REVIEWED" | "FULFILLED" | "REJECTED";
    notes?: string;
    createdAt: Date;
    updatedAt: Date;
}

// --- Actions ---

export async function createProductRequest(data: ProductRequestInput) {
    try {
        if (!await allowServerAction("product-request", 5, 300)) {
            return { success: false, error: "Too many requests. Please try again later." };
        }
        const validated = productRequestSchema.parse(data);

        const { primaryResult: doc } = await fanOutWrite(c => c.productRequest.create({
            data: {
                // eslint-disable-next-line @typescript-eslint/no-explicit-any
                ...validated as any,
                status: "PENDING",
            }
        }));

        revalidatePath("/admin/requests");
        revalidateTag("requests");

        await emitWorkflowEvent("product.requested", {
            requestId: doc.id,
            productName: validated.productName,
            brand: validated.brand || null,
            contactInfo: validated.contactInfo,
            minPrice: validated.minPrice || null,
            maxPrice: validated.maxPrice || null,
        });

        return { success: true, id: doc.id };
    } catch (error) {
        console.error("Error creating product request:", error);
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    }
}

async function _fetchProductRequests(status?: string): Promise<ProductRequest[]> {
    try {
        // eslint-disable-next-line @typescript-eslint/no-explicit-any
        const where = status ? { status: status as any } : {};

        const requests = await getWriteClient().productRequest.findMany({
            where,
            orderBy: { createdAt: "desc" }
        });

        return requests as unknown as ProductRequest[];
    } catch (error) {
        console.error("Error fetching product requests from Postgres:", error);
        return [];
    }
}

export async function getProductRequests(status?: string): Promise<ProductRequest[]> {
    await requireAdminSession();
    const cachedFetch = unstable_cache(
        () => _fetchProductRequests(status),
        [`requests-${status || "all"}`],
        { revalidate: 300, tags: ["requests"] }
    );
    return cachedFetch();
}

export async function updateRequestStatus(id: string, status: string, notes?: string) {
    try {
        await requireAdminSession();
        const updateData: { status: string; notes?: string } = { status };
        if (notes !== undefined) updateData.notes = notes;

        await fanOutWrite(c => c.productRequest.update({
            where: { id },
            // eslint-disable-next-line @typescript-eslint/no-explicit-any
            data: updateData as any
        }));

        revalidatePath("/admin/requests");
        revalidateTag("requests");
        return { success: true };
    } catch (error) {
        console.error("Error updating product request:", error);
        return { success: false, error: error instanceof Error ? error.message : "Unknown error" };
    }
}
