import { describe, expect, it } from "vitest";
import {
    approveBlocker,
    categoriesForProject,
    categoriesSignature,
    categoryChoices,
    choiceFromValue,
    choiceOf,
    choiceValue,
    cleanPublishInput,
    line,
    paragraph,
    photoLabel,
    photoSrc,
    productFields,
    productsMissing,
    readOffer,
    readPhoto,
    readShopProduct,
    sameCategories,
} from "./shop-products";
import type { SiteCategory } from "./types";

const offer = (over: Record<string, unknown> = {}) => ({
    name: "Sunflower Oil 1 L Bottle",
    description: "Light, golden cooking oil for everyday cooking.",
    price: 155,
    originalPrice: 175,
    highlights: ["Light on the stomach", "Good for frying"],
    specifications: [{ key: "Volume", value: "1 L" }],
    tags: ["oil", "cooking"],
    categoryId: "c-oils",
    subcategoryId: "c-sun",
    categoryPath: "Oils & Ghee › Sunflower Oil",
    barcode: "8901234567890",
    posName: "Sunflower Oil 1 L",
    code: "1512",
    ...over,
});

const row = (over: Record<string, unknown> = {}) => ({
    product_key: "6",
    data: offer(),
    state: "waiting",
    photo_kinds: ["white", "in-use"],
    sent_at: "2026-10-04T10:00:00+00:00",
    decided_at: null,
    ...over,
});

const base64 = "A".repeat(200);

const categories: SiteCategory[] = [
    { id: "c-groc", name: "Grocery", parentId: null },
    { id: "c-rice", name: "Rice & Pulses", parentId: "c-groc" },
    { id: "c-oils", name: "Oils & Ghee", parentId: null },
    { id: "c-must", name: "Mustard Oil", parentId: "c-oils" },
    { id: "c-deep", name: "Too deep", parentId: "c-must" },
    { id: "c-lost", name: "Lost", parentId: "c-gone" },
    { id: "c-sun", name: "Sunflower Oil", parentId: "c-oils" },
];

const valid = (over: Record<string, unknown> = {}) => ({
    shopId: "5B8F1A0E-1111-4222-8333-944455556666",
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
    imageUrls: ["https://res.cloudinary.com/demo/image/upload/v1/shop/products/a.jpg"],
    updateId: null,
    ...over,
});

describe("reading an offer", () => {
    it("reads the words, the prices and the place the shop PC sent", () => {
        expect(readOffer(offer())).toEqual({
            name: "Sunflower Oil 1 L Bottle",
            description: "Light, golden cooking oil for everyday cooking.",
            price: 155,
            originalPrice: 175,
            highlights: ["Light on the stomach", "Good for frying"],
            specifications: [{ key: "Volume", value: "1 L" }],
            tags: ["oil", "cooking"],
            categoryId: "c-oils",
            subcategoryId: "c-sun",
            categoryPath: "Oils & Ghee › Sunflower Oil",
            barcode: "8901234567890",
            posName: "Sunflower Oil 1 L",
            code: "1512",
        });
    });

    it("tidies text: no control characters, one space between words, cut to length", () => {
        const read = readOffer(offer({ name: "  Oil\u0000   1\tL \u0007 ", description: "A\r\n\r\n\r\n\r\nB", highlights: [" x ", "", 7, "y".repeat(500)] }));
        expect(read?.name).toBe("Oil 1 L");
        expect(read?.description).toBe("A\n\nB");
        expect(read?.highlights).toEqual(["x", "y".repeat(200)]);
        expect(line("a".repeat(300), 10)).toHaveLength(10);
        expect(paragraph("x".repeat(9000), 5000)).toHaveLength(5000);
        expect(line(42, 10)).toBe("");
    });

    it("is not an offer without a name, a description or a price the shop could charge", () => {
        expect(readOffer(offer({ name: "  " }))).toBeNull();
        expect(readOffer(offer({ description: "" }))).toBeNull();
        for (const price of [0, -5, Number.NaN, Number.POSITIVE_INFINITY, "155", null, 10_000_001]) expect(readOffer(offer({ price }))).toBeNull();
        expect(readOffer(null)).toBeNull();
        expect(readOffer([])).toBeNull();
        expect(readOffer("offer")).toBeNull();
    });

    it("keeps the MRP only when it is above the price, and rounds both to paise", () => {
        expect(readOffer(offer({ originalPrice: 155 }))?.originalPrice).toBeNull();
        expect(readOffer(offer({ originalPrice: 100 }))?.originalPrice).toBeNull();
        expect(readOffer(offer({ originalPrice: "175" }))?.originalPrice).toBeNull();
        expect(readOffer(offer({ originalPrice: undefined }))?.originalPrice).toBeNull();
        const rounded = readOffer(offer({ price: 154.999, originalPrice: 175.004 }));
        expect([rounded?.price, rounded?.originalPrice]).toEqual([155, 175]);
    });

    it("limits the lists and drops what is not a pair of words", () => {
        const read = readOffer(offer({
            highlights: Array.from({ length: 30 }, (_, i) => `h${i}`),
            tags: Array.from({ length: 30 }, (_, i) => `t${i}`),
            specifications: [{ key: "", value: "x" }, { key: "k", value: "" }, "text", { key: "Pack", value: "Bottle" }, ...Array.from({ length: 40 }, (_, i) => ({ key: `k${i}`, value: "v" }))],
        }));
        expect(read?.highlights).toHaveLength(10);
        expect(read?.tags).toHaveLength(15);
        expect(read?.specifications).toHaveLength(20);
        expect(read?.specifications[0]).toEqual({ key: "Pack", value: "Bottle" });
    });

    it("takes a barcode in the website's own form, or none", () => {
        expect(readOffer(offer({ barcode: " 890-1234 567890 " }))?.barcode).toBe("8901234567890");
        expect(readOffer(offer({ barcode: "abc" }))?.barcode).toBeNull();
        expect(readOffer(offer({ barcode: "<script>alert(1)</script>" }))?.barcode).toBeNull();
        expect(readOffer(offer({ barcode: undefined }))?.barcode).toBeNull();
        expect(readOffer(offer({ barcode: 8901234567890 }))?.barcode).toBeNull();
    });

    it("leaves the category empty when the shop PC chose none", () => {
        const read = readOffer(offer({ categoryId: undefined, subcategoryId: undefined, categoryPath: undefined }));
        expect([read?.categoryId, read?.subcategoryId, read?.categoryPath]).toEqual(["", "", ""]);
    });
});

describe("reading a row of the waiting list", () => {
    it("reads a product with its state, its photos in the shop PC's order, and its dates", () => {
        const read = readShopProduct(row({ photo_kinds: ["east-asian-model", "white", "mystery", "in-use", "white"], decided_at: "2026-10-04T12:00:00+00:00" }));
        expect(read?.key).toBe("6");
        expect(read?.state).toBe("waiting");
        expect(read?.photoKinds).toEqual(["white", "in-use", "east-asian-model"]);
        expect(read?.sentAt.toISOString()).toBe("2026-10-04T10:00:00.000Z");
        expect(read?.decidedAt?.toISOString()).toBe("2026-10-04T12:00:00.000Z");
        expect(readShopProduct(row({ decided_at: "not a date" }))?.decidedAt).toBeNull();
        expect(readShopProduct(row({ photo_kinds: "white" }))?.photoKinds).toEqual([]);
    });

    it("leaves out a row that cannot be read, so one damaged product never stops the list", () => {
        for (const over of [{ product_key: "abc" }, { product_key: 6 }, { state: "gone" }, { sent_at: "yesterday" }, { data: null }, { data: offer({ price: 0 }) }]) {
            expect(readShopProduct(row(over))).toBeNull();
        }
        expect(readShopProduct(null)).toBeNull();
        expect(readShopProduct("row")).toBeNull();
    });
});

describe("reading a photo", () => {
    const photo = (over: Record<string, unknown> = {}) => ({ kind: "white", mime: "image/jpeg", content: base64, ...over });

    it("reads a picture of a kind this page knows, as a data address", () => {
        const read = readPhoto(photo());
        expect(read).toEqual({ kind: "white", mime: "image/jpeg", content: base64 });
        expect(photoSrc(read!)).toBe(`data:image/jpeg;base64,${base64}`);
        expect(readPhoto(photo({ mime: "image/webp" }))?.mime).toBe("image/webp");
    });

    it("refuses anything else, an SVG above all, since it is the one picture that can carry a script", () => {
        for (const over of [
            { mime: "image/svg+xml" }, { mime: "text/html" }, { mime: "image/gif" }, { kind: "banner" }, { content: "short" }, { content: "A".repeat(900_001) },
            { content: base64 + "<script>" }, { content: base64 + " " }, { content: 5 },
        ]) {
            expect(readPhoto(photo(over))).toBeNull();
        }
        expect(readPhoto(null)).toBeNull();
    });

    it("names each kind", () => {
        expect(photoLabel("white")).toBe("White background");
        expect(photoLabel("east-asian-model")).toBe("East Asian model");
    });
});

describe("a project with an older script", () => {
    it("is told apart by the missing table, not by any other trouble", () => {
        expect(productsMissing({ code: "PGRST205" })).toBe(true);
        expect(productsMissing({ code: "42P01" })).toBe(true);
        expect(productsMissing({ code: "XX000" }, 404)).toBe(true);
        expect(productsMissing({ code: "XX000" }, 500)).toBe(false);
        expect(productsMissing(null)).toBe(false);
    });
});

describe("the website's categories", () => {
    it("lists each main category with its subcategories under it, and leaves out what has no place in a product", () => {
        expect(categoryChoices(categories).map((c) => c.label)).toEqual([
            "Grocery", "Grocery › Rice & Pulses", "Oils & Ghee", "Oils & Ghee › Mustard Oil", "Oils & Ghee › Sunflower Oil",
        ]);
    });

    it("knows a place only when the pair is a place of the website", () => {
        expect(choiceOf(categories, "c-oils", "c-sun")?.label).toBe("Oils & Ghee › Sunflower Oil");
        expect(choiceOf(categories, "c-oils", "")?.label).toBe("Oils & Ghee");
        expect(choiceOf(categories, "c-groc", "c-sun")).toBeNull();
        expect(choiceOf(categories, "c-sun", "")).toBeNull();
        expect(choiceOf(categories, "nope", "")).toBeNull();
        expect(choiceOf([], "c-oils", "")).toBeNull();
    });

    it("turns a choice into the value of a list and back", () => {
        const chosen = choiceOf(categories, "c-oils", "c-sun")!;
        expect(choiceValue(chosen)).toBe("c-sun");
        expect(choiceValue(choiceOf(categories, "c-oils", "")!)).toBe("c-oils");
        expect(choiceFromValue(categories, "c-sun")).toEqual(chosen);
        expect(choiceFromValue(categories, "c-deep")).toBeNull();
    });

    it("sends the project its list: ids, names and main categories, at most 1,000, each once", () => {
        const sent = categoriesForProject([
            ...categories,
            { id: "c-groc", name: "Grocery again", parentId: null },
            { id: "", name: "No id", parentId: null },
            { id: "c-blank", name: "   ", parentId: null },
            { id: "x".repeat(65), name: "Long id", parentId: null },
            { id: "c-name", name: ` ${"n".repeat(200)} `, parentId: null },
        ]);
        expect(sent.map((c) => c.id)).toEqual(["c-groc", "c-rice", "c-oils", "c-must", "c-deep", "c-lost", "c-sun", "c-name"]);
        expect(sent[1]).toEqual({ id: "c-rice", name: "Rice & Pulses", parentId: "c-groc" });
        expect(sent[7].name).toHaveLength(120);
        const many = Array.from({ length: 1500 }, (_, i) => ({ id: `c${i}`, name: `Category ${i}`, parentId: null }));
        expect(categoriesForProject(many)).toHaveLength(1000);
    });

    it("knows when the project already has the list, as the project keeps it", () => {
        const wanted = categoriesForProject(categories);
        // The project keeps each as { id, name, parentId } with parentId null for a main category, in the order sent.
        expect(sameCategories(wanted.map((c) => ({ ...c })), wanted)).toBe(true);
        expect(sameCategories(wanted.map((c) => ({ id: c.id, name: c.name, parentId: c.parentId ?? undefined })), wanted)).toBe(true);
        expect(sameCategories(wanted.slice(1), wanted)).toBe(false);
        expect(sameCategories([...wanted].reverse(), wanted)).toBe(false);
        expect(sameCategories(wanted.map((c) => (c.id === "c-sun" ? { ...c, name: "Sunflower" } : c)), wanted)).toBe(false);
        expect(sameCategories(wanted.map((c) => (c.id === "c-sun" ? { ...c, parentId: "c-groc" } : c)), wanted)).toBe(false);
        for (const bad of [null, undefined, "list", {}, [null], [1]]) expect(sameCategories(bad, wanted)).toBe(false);
        expect(sameCategories([], [])).toBe(true);
    });

    it("has a signature that changes when the list does, and only then", () => {
        const first = categoriesSignature(categories);
        expect(categoriesSignature([...categories])).toBe(first);
        expect(categoriesSignature([...categories, { id: "c-new", name: "New", parentId: null }])).not.toBe(first);
        expect(categoriesSignature(categories.map((c) => (c.id === "c-sun" ? { ...c, name: "Sunflower" } : c)))).not.toBe(first);
    });
});

describe("checking what the browser asks to publish", () => {
    it("takes a whole product and tidies it", () => {
        const cleaned = cleanPublishInput(valid({ barcode: "890-1234 567890", shopId: "5B8F1A0E-1111-4222-8333-944455556666" }));
        expect(cleaned.ok).toBe(true);
        if (!cleaned.ok) return;
        expect(cleaned.value.shopId).toBe("5b8f1a0e-1111-4222-8333-944455556666");
        expect(cleaned.value.barcode).toBe("8901234567890");
        expect(cleaned.value.categoryId).toBe("c-oils");
        expect(cleaned.value.imageUrls).toHaveLength(1);
        expect(cleaned.value.updateId).toBeNull();
    });

    it("refuses what is missing or not as expected, saying what", () => {
        const why = (over: Record<string, unknown>) => {
            const cleaned = cleanPublishInput(valid(over));
            return cleaned.ok ? "ok" : cleaned.error;
        };
        expect(why({ shopId: "shop-1" })).toBe("The shop is not known.");
        expect(why({ productKey: "6; drop table" })).toBe("The product is not known.");
        expect(why({ name: "" })).toBe("The product needs a name, a description and a price.");
        expect(why({ price: 0 })).toBe("The product needs a name, a description and a price.");
        expect(why({ categoryId: "" })).toBe("Choose a category for the product.");
        expect(why({ imageUrls: "https://res.cloudinary.com/demo/image/upload/a.jpg" })).toBe("ok"); // not a list: no photos
        expect(why({ updateId: 5 })).toBe("The product to update is not known.");
        expect(why({ updateId: "a b" })).toBe("The product to update is not known.");
        expect(cleanPublishInput(null)).toEqual({ ok: false, error: "The product is missing." });
        expect(cleanPublishInput("product")).toEqual({ ok: false, error: "The product is missing." });
    });

    it("takes photos only as pictures on Cloudinary, at most five", () => {
        const why = (imageUrls: unknown) => {
            const cleaned = cleanPublishInput(valid({ imageUrls }));
            return cleaned.ok ? "ok" : cleaned.error;
        };
        const good = "https://res.cloudinary.com/demo/image/upload/v1/shop/products/a.jpg";
        expect(why([good, good, good, good, good])).toBe("ok");
        expect(why([good, good, good, good, good, good])).toBe("The photos are not as expected.");
        for (const bad of [
            "http://res.cloudinary.com/demo/image/upload/a.jpg", "https://evil.example/image/upload/a.jpg", "https://res.cloudinary.com.evil.example/demo/image/upload/a.jpg",
            "javascript:alert(1)", "data:image/png;base64,AAAA", "https://res.cloudinary.com/demo/video/upload/a.mp4", `${good}"onerror="x`, 5, null,
        ]) {
            expect(why([bad])).toBe("The photos are not as expected.");
        }
        expect(why([])).toBe("ok");
    });

    it("lets the owner name a product of the website to update", () => {
        const cleaned = cleanPublishInput(valid({ updateId: "0f8fad5b-d9cb-469f-a165-70867728950e" }));
        expect(cleaned.ok && cleaned.value.updateId).toBe("0f8fad5b-d9cb-469f-a165-70867728950e");
    });
});

describe("the fields an approved product sets", () => {
    const value = () => {
        const cleaned = cleanPublishInput(valid());
        if (!cleaned.ok) throw new Error(cleaned.error);
        return cleaned.value;
    };

    it("sets the words, the prices, the place and the pictures, and nothing about stock, offers or reviews", () => {
        const fields = productFields(value());
        expect(fields).toEqual({
            name: "Sunflower Oil 1 L Bottle",
            description: "Light, golden cooking oil.",
            price: 155,
            originalPrice: 175,
            categoryId: "c-oils",
            subcategoryId: "c-sun",
            tags: ["oil"],
            highlights: ["Light"],
            specifications: [{ key: "Volume", value: "1 L" }],
            barcode: "8901234567890",
            imageUrl: "https://res.cloudinary.com/demo/image/upload/v1/shop/products/a.jpg",
            images: ["https://res.cloudinary.com/demo/image/upload/v1/shop/products/a.jpg"],
        });
        for (const key of ["stockLevel", "available", "featured", "offerId", "videoUrl", "averageRating", "reviewCount", "id"]) expect(fields).not.toHaveProperty(key);
    });

    it("leaves the pictures alone when none are given, and a main category has no subcategory", () => {
        const cleaned = cleanPublishInput(valid({ imageUrls: [], subcategoryId: "" }));
        if (!cleaned.ok) throw new Error(cleaned.error);
        const fields = productFields(cleaned.value);
        expect(fields).not.toHaveProperty("images");
        expect(fields).not.toHaveProperty("imageUrl");
        expect(fields.subcategoryId).toBeNull();
    });
});

describe("what stops an approval", () => {
    const ready = { signedIn: true, choice: choiceOf(categories, "c-oils", "")!, photos: 2, isNew: true, loadingPhotos: false };

    it("is nothing when the owner is signed in, has chosen a category and has photos", () => {
        expect(approveBlocker(ready)).toBeNull();
    });

    it("says what the owner has to do first", () => {
        expect(approveBlocker({ ...ready, signedIn: false })).toBe("Sign in to your website's admin to publish products.");
        expect(approveBlocker({ ...ready, choice: null })).toBe("Choose a category of your website.");
        expect(approveBlocker({ ...ready, loadingPhotos: true })).toBe("The photos are still loading.");
        expect(approveBlocker({ ...ready, photos: 0 })).toBe("Choose at least one photo: a new product needs a picture.");
    });

    it("lets an update go without photos, since the product has its own", () => {
        expect(approveBlocker({ ...ready, photos: 0, isNew: false })).toBeNull();
    });
});
