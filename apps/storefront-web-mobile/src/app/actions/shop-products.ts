"use server";

// Putting the products the shop PC offers (Live shop, From the shop) on this website, once the owner has approved them. It
// goes through the same createProduct and updateProduct as the admin's product form, so a product made here is indexed,
// cached and announced exactly like one made there. Nothing here runs unless an admin with the products permission asks.

import { createProduct, getProductByBarcode, updateProduct } from "@/app/actions";
import { requireAdminSession } from "@/lib/auth-server";
import { getWriteClient } from "@/lib/db-manager";
import { normalizeBarcode } from "@/lib/barcode";
import { shopProductId } from "@/lib/live-shop/product-id";
import { cleanPublishInput, productFields } from "@/lib/live-shop/shop-products";

/** A product that is already on the website, as much of it as the owner needs to tell it is the one. */
export interface ExistingProduct {
    id: string;
    name: string;
    price: number;
    imageUrl: string | null;
}

export type FindResult =
    | { success: true; /** The product this shop PC's product was published as before. */ byKey: ExistingProduct | null; /** Another product with the same barcode. */ byBarcode: ExistingProduct | null }
    | { success: false; error: string };

export type PublishResult = { success: true; id: string; created: boolean } | { success: false; error: string };

const SIGN_IN = "Sign in to your website's admin to publish products.";

async function allowed(): Promise<string | null> {
    try {
        await requireAdminSession("products");
        return null;
    } catch (error) {
        return error instanceof Error && error.message === "FORBIDDEN" ? "Your account may not change the website's products." : SIGN_IN;
    }
}

const shown = (product: { id: string; name: string; price: number; imageUrl: string | null }): ExistingProduct => ({
    id: product.id,
    name: product.name,
    price: product.price,
    imageUrl: product.imageUrl,
});

/** Whether the product is on the website already: the one the shop PC's product was published as, or another with its barcode. */
export async function findShopProduct(shopId: string, productKey: string, barcode: string | null): Promise<FindResult> {
    const refused = await allowed();
    if (refused) return { success: false, error: refused };
    if (typeof shopId !== "string" || !/^[0-9a-f-]{36}$/i.test(shopId) || typeof productKey !== "string" || !/^\d{1,10}$/.test(productKey)) {
        return { success: false, error: "The product is not known." };
    }
    try {
        const own = await getWriteClient().product.findUnique({
            where: { id: shopProductId(shopId, productKey) },
            select: { id: true, name: true, price: true, imageUrl: true },
        });
        const code = typeof barcode === "string" ? normalizeBarcode(barcode) : "";
        const other = code.length >= 4 ? await getProductByBarcode(code, "all") : null;
        return {
            success: true,
            byKey: own ? shown(own) : null,
            byBarcode: other && other.id !== own?.id ? shown({ id: other.id, name: other.name, price: other.price, imageUrl: other.imageUrl ?? null }) : null,
        };
    } catch (error) {
        console.error("Looking for the shop's product on the website failed:", error);
        return { success: false, error: "The website's products could not be looked at. Try again." };
    }
}

/**
 * Makes the product on the website, or updates it there: the product this shop PC's product was published as before, or the one
 * the owner chose. The category must be one the website has. An update keeps what the offer does not say (stock, offer, video,
 * reviews) and keeps its pictures unless new ones are given.
 */
export async function publishShopProduct(input: unknown): Promise<PublishResult> {
    const refused = await allowed();
    if (refused) return { success: false, error: refused };
    const cleaned = cleanPublishInput(input);
    if (!cleaned.ok) return { success: false, error: cleaned.error };
    const value = cleaned.value;

    try {
        const db = getWriteClient();
        const wanted = [value.categoryId, value.subcategoryId].filter(Boolean);
        const found = await db.category.findMany({ where: { id: { in: wanted } }, select: { id: true, parentId: true } });
        const main = found.find((c) => c.id === value.categoryId);
        const sub = value.subcategoryId ? found.find((c) => c.id === value.subcategoryId) : null;
        if (!main || main.parentId || (value.subcategoryId && (!sub || sub.parentId !== main.id))) {
            return { success: false, error: "That category is not on your website any more. Choose another." };
        }

        const ownId = shopProductId(value.shopId, value.productKey);
        const targetId = value.updateId ?? ownId;
        const current = await db.product.findUnique({ where: { id: targetId }, select: { id: true, offerId: true, videoUrl: true } });
        if (value.updateId && !current) return { success: false, error: "The product to update is not on your website any more." };

        const fields = productFields(value);
        if (current) {
            // updateProduct empties these when they are not given, so they are given as they are.
            const result = await updateProduct(current.id, { ...fields, offerId: current.offerId ?? "", videoUrl: current.videoUrl ?? "" });
            return result.success ? { success: true, id: current.id, created: false } : { success: false, error: result.error ?? "The product could not be updated." };
        }

        if (value.imageUrls.length === 0) return { success: false, error: "A new product needs at least one photo." };
        const result = await createProduct({ ...fields, id: ownId, available: true, featured: false });
        return result.success && result.id ? { success: true, id: result.id, created: true } : { success: false, error: result.error ?? "The product could not be made." };
    } catch (error) {
        console.error("Publishing the shop's product failed:", error);
        return { success: false, error: "The product could not be put on your website. Try again." };
    }
}
