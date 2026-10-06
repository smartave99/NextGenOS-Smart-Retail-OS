import { beforeEach, describe, expect, it, vi } from "vitest";

vi.mock("server-only", () => ({}));

const mocks = vi.hoisted(() => ({
    requireAdminSession: vi.fn(),
    createProduct: vi.fn(),
    updateProduct: vi.fn(),
    getProductByBarcode: vi.fn(),
    productFind: vi.fn(),
    categoryFind: vi.fn(),
}));

vi.mock("@/lib/auth-server", () => ({ requireAdminSession: mocks.requireAdminSession }));
vi.mock("@/lib/db-manager", () => ({
    getWriteClient: () => ({ product: { findUnique: mocks.productFind }, category: { findMany: mocks.categoryFind } }),
}));
vi.mock("@/app/actions", () => ({
    createProduct: mocks.createProduct,
    updateProduct: mocks.updateProduct,
    getProductByBarcode: mocks.getProductByBarcode,
}));

import { shopProductId, uuidV5 } from "@/lib/live-shop/product-id";
import { findShopProduct, publishShopProduct } from "./shop-products";

const SHOP = "5b8f1a0e-1111-4222-8333-944455556666";
const PHOTO = "https://res.cloudinary.com/demo/image/upload/v1/shop/products/a.jpg";
const PHOTO_2 = "https://res.cloudinary.com/demo/image/upload/v1/shop/products/b.jpg";

const input = (over: Record<string, unknown> = {}) => ({
    shopId: SHOP,
    productKey: "6",
    name: "Sunflower Oil 1 L Bottle",
    description: "Light, golden cooking oil.",
    price: 155,
    originalPrice: 175,
    highlights: ["Light"],
    specifications: [{ key: "Volume", value: "1 L" }],
    tags: ["oil"],
    barcode: "8901234567890",
    categoryId: "c-oils",
    subcategoryId: "c-sun",
    imageUrls: [PHOTO, PHOTO_2],
    updateId: null,
    ...over,
});

beforeEach(() => {
    vi.resetAllMocks();
    mocks.requireAdminSession.mockResolvedValue({ uid: "u", email: "owner@example.com", role: "Admin", permissions: ["*"] });
    mocks.categoryFind.mockResolvedValue([{ id: "c-oils", parentId: null }, { id: "c-sun", parentId: "c-oils" }]);
    mocks.productFind.mockResolvedValue(null);
    mocks.createProduct.mockResolvedValue({ success: true, id: "made", indexingReady: true });
    mocks.updateProduct.mockResolvedValue({ success: true, indexingReady: true });
    mocks.getProductByBarcode.mockResolvedValue(null);
});

describe("the id of a product that came from the shop PC", () => {
    it("is a version 5 UUID, as RFC 4122 works it out", () => {
        // The example of RFC 4122's authors, in every library that has one: python.org in the DNS namespace.
        expect(uuidV5("python.org", "6ba7b810-9dad-11d1-80b4-00c04fd430c8")).toBe("886313e1-3b8a-5372-9b90-0c9aee199e5d");
    });

    it("is the same for the same shop and product, and different for any other", () => {
        const id = shopProductId(SHOP, "6");
        expect(id).toMatch(/^[0-9a-f]{8}-[0-9a-f]{4}-5[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/);
        expect(shopProductId(SHOP.toUpperCase(), "6")).toBe(id);
        expect(shopProductId(SHOP, "7")).not.toBe(id);
        expect(shopProductId("0f8fad5b-d9cb-469f-a165-70867728950e", "6")).not.toBe(id);
    });
});

describe("publishing a product the owner approved", () => {
    it("makes a new product under its own id, available, with the photos in order", async () => {
        const result = await publishShopProduct(input());

        expect(result).toEqual({ success: true, id: "made", created: true });
        expect(mocks.updateProduct).not.toHaveBeenCalled();
        const data = mocks.createProduct.mock.calls[0][0];
        expect(data).toMatchObject({
            id: shopProductId(SHOP, "6"),
            name: "Sunflower Oil 1 L Bottle",
            price: 155,
            originalPrice: 175,
            categoryId: "c-oils",
            subcategoryId: "c-sun",
            barcode: "8901234567890",
            available: true,
            featured: false,
            imageUrl: PHOTO,
            images: [PHOTO, PHOTO_2],
        });
        expect(data).not.toHaveProperty("stockLevel");
    });

    it("updates the product it made before instead of making another, keeping its offer and video", async () => {
        mocks.productFind.mockResolvedValue({ id: shopProductId(SHOP, "6"), offerId: "offer-1", videoUrl: "https://video.example/v.mp4" });

        const result = await publishShopProduct(input({ price: 160, imageUrls: [] }));

        expect(result).toEqual({ success: true, id: shopProductId(SHOP, "6"), created: false });
        expect(mocks.createProduct).not.toHaveBeenCalled();
        const [id, data] = mocks.updateProduct.mock.calls[0];
        expect(id).toBe(shopProductId(SHOP, "6"));
        expect(data).toMatchObject({ price: 160, offerId: "offer-1", videoUrl: "https://video.example/v.mp4", originalPrice: 175 });
        expect(data).not.toHaveProperty("images");
        expect(data).not.toHaveProperty("imageUrl");
        expect(data).not.toHaveProperty("available");
        expect(data).not.toHaveProperty("stockLevel");
        expect(mocks.productFind).toHaveBeenCalledWith(expect.objectContaining({ where: { id: shopProductId(SHOP, "6") } }));
    });

    it("hands an update with no offer or video as empty ones, which the product form's update turns into none", async () => {
        mocks.productFind.mockResolvedValue({ id: shopProductId(SHOP, "6"), offerId: null, videoUrl: null });
        await publishShopProduct(input({ imageUrls: [] }));
        expect(mocks.updateProduct.mock.calls[0][1]).toMatchObject({ offerId: "", videoUrl: "" });
    });

    it("replaces a product's pictures when new ones are given", async () => {
        mocks.productFind.mockResolvedValue({ id: shopProductId(SHOP, "6"), offerId: null, videoUrl: null });
        await publishShopProduct(input());
        expect(mocks.updateProduct.mock.calls[0][1]).toMatchObject({ imageUrl: PHOTO, images: [PHOTO, PHOTO_2] });
    });

    it("updates the product the owner chose, and says when it is not there any more", async () => {
        mocks.productFind.mockResolvedValue({ id: "old-1", offerId: null, videoUrl: null });
        expect(await publishShopProduct(input({ updateId: "old-1" }))).toEqual({ success: true, id: "old-1", created: false });
        expect(mocks.productFind).toHaveBeenCalledWith(expect.objectContaining({ where: { id: "old-1" } }));

        mocks.productFind.mockResolvedValue(null);
        expect(await publishShopProduct(input({ updateId: "old-2" }))).toEqual({ success: false, error: "The product to update is not on your website any more." });
        expect(mocks.createProduct).not.toHaveBeenCalled();
    });

    it("needs at least one photo for a new product", async () => {
        expect(await publishShopProduct(input({ imageUrls: [] }))).toEqual({ success: false, error: "A new product needs at least one photo." });
        expect(mocks.createProduct).not.toHaveBeenCalled();
    });

    it("refuses a category the website does not have, or a subcategory that belongs to another", async () => {
        mocks.categoryFind.mockResolvedValue([{ id: "c-sun", parentId: "c-oils" }]);
        expect(await publishShopProduct(input())).toEqual({ success: false, error: "That category is not on your website any more. Choose another." });

        mocks.categoryFind.mockResolvedValue([{ id: "c-oils", parentId: null }, { id: "c-sun", parentId: "c-other" }]);
        expect((await publishShopProduct(input())).success).toBe(false);

        mocks.categoryFind.mockResolvedValue([{ id: "c-oils", parentId: "c-top" }]);
        expect((await publishShopProduct(input({ subcategoryId: "" }))).success).toBe(false);

        mocks.categoryFind.mockResolvedValue([{ id: "c-oils", parentId: null }]);
        expect((await publishShopProduct(input({ subcategoryId: "" }))).success).toBe(true);
        expect(mocks.createProduct).toHaveBeenCalledTimes(1);
    });

    it("says what the website said when it could not make or update the product", async () => {
        mocks.createProduct.mockResolvedValue({ success: false, error: "Unique constraint failed" });
        expect(await publishShopProduct(input())).toEqual({ success: false, error: "Unique constraint failed" });

        mocks.productFind.mockResolvedValue({ id: shopProductId(SHOP, "6"), offerId: null, videoUrl: null });
        mocks.updateProduct.mockResolvedValue({ success: false });
        expect(await publishShopProduct(input())).toEqual({ success: false, error: "The product could not be updated." });
    });

    it("does not leak a database error to the page", async () => {
        const quiet = vi.spyOn(console, "error").mockImplementation(() => undefined);
        mocks.categoryFind.mockRejectedValue(new Error("connection string postgres://user:secret@host"));
        const result = await publishShopProduct(input());
        expect(result).toEqual({ success: false, error: "The product could not be put on your website. Try again." });
        expect(JSON.stringify(result)).not.toContain("secret");
        quiet.mockRestore();
    });

    it("refuses what the browser should never send, before it looks at the website", async () => {
        for (const bad of [null, "x", input({ shopId: "shop" }), input({ imageUrls: ["https://evil.example/a.jpg"] }), input({ name: "" }), input({ categoryId: "" })]) {
            expect((await publishShopProduct(bad)).success).toBe(false);
        }
        expect(mocks.categoryFind).not.toHaveBeenCalled();
        expect(mocks.createProduct).not.toHaveBeenCalled();
        expect(mocks.updateProduct).not.toHaveBeenCalled();
    });

    it("does nothing for anyone who is not an admin who may change products", async () => {
        mocks.requireAdminSession.mockRejectedValue(new Error("UNAUTHORIZED"));
        expect(await publishShopProduct(input())).toEqual({ success: false, error: "Sign in to your website's admin to publish products." });

        mocks.requireAdminSession.mockRejectedValue(new Error("FORBIDDEN"));
        expect(await publishShopProduct(input())).toEqual({ success: false, error: "Your account may not change the website's products." });

        expect(mocks.requireAdminSession).toHaveBeenCalledWith("products");
        expect(mocks.categoryFind).not.toHaveBeenCalled();
        expect(mocks.productFind).not.toHaveBeenCalled();
        expect(mocks.createProduct).not.toHaveBeenCalled();
        expect(mocks.updateProduct).not.toHaveBeenCalled();
    });
});

describe("looking for the product on the website", () => {
    it("finds the one it made before and another with the same barcode", async () => {
        mocks.productFind.mockResolvedValue({ id: shopProductId(SHOP, "6"), name: "Sunflower Oil", price: 150, imageUrl: PHOTO });
        mocks.getProductByBarcode.mockResolvedValue({ id: "other-1", name: "Sunflower Oil 1 L", price: 155, imageUrl: null });

        const result = await findShopProduct(SHOP, "6", "890-1234567890");

        expect(result).toEqual({
            success: true,
            byKey: { id: shopProductId(SHOP, "6"), name: "Sunflower Oil", price: 150, imageUrl: PHOTO },
            byBarcode: { id: "other-1", name: "Sunflower Oil 1 L", price: 155, imageUrl: null },
        });
        expect(mocks.getProductByBarcode).toHaveBeenCalledWith("8901234567890", "all");
    });

    it("does not offer the same product twice", async () => {
        mocks.productFind.mockResolvedValue({ id: "same", name: "Oil", price: 1, imageUrl: null });
        mocks.getProductByBarcode.mockResolvedValue({ id: "same", name: "Oil", price: 1, imageUrl: null });
        const result = await findShopProduct(SHOP, "6", "8901234567890");
        expect(result.success && result.byBarcode).toBeNull();
    });

    it("looks for no barcode when there is none, or a short one", async () => {
        await findShopProduct(SHOP, "6", null);
        await findShopProduct(SHOP, "6", "12");
        expect(mocks.getProductByBarcode).not.toHaveBeenCalled();
    });

    it("refuses a stranger and a product it does not know", async () => {
        expect(await findShopProduct(SHOP, "six", null)).toEqual({ success: false, error: "The product is not known." });
        expect(await findShopProduct("nope", "6", null)).toEqual({ success: false, error: "The product is not known." });
        mocks.requireAdminSession.mockRejectedValue(new Error("UNAUTHORIZED"));
        expect(await findShopProduct(SHOP, "6", null)).toEqual({ success: false, error: "Sign in to your website's admin to publish products." });
        expect(mocks.productFind).not.toHaveBeenCalled();
    });

    it("says so when the website's products cannot be looked at", async () => {
        const quiet = vi.spyOn(console, "error").mockImplementation(() => undefined);
        mocks.productFind.mockRejectedValue(new Error("down"));
        expect(await findShopProduct(SHOP, "6", null)).toEqual({ success: false, error: "The website's products could not be looked at. Try again." });
        quiet.mockRestore();
    });
});
