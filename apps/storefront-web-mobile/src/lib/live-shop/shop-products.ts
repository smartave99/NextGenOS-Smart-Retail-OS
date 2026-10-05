// The products the shop PC offers for the website (Smart Retail POS 2.18.0 or later), read with care: a row from an older or
// newer shop PC, or a damaged one, shows what can be read or is left out. It never stops the page. Everything that comes
// from the project is text to show, never markup, and is checked again before it reaches this website's products.
import { normalizeBarcode } from "@/lib/barcode";
import type { CategoryChoice, PhotoKind, ShopOffer, ShopPhoto, ShopProduct, ShopProductState, SiteCategory } from "./types";

/** The five photos, in the order the shop PC makes them. The first is the white-background photo: the website's main image. */
export const PHOTO_KINDS: { kind: PhotoKind; label: string }[] = [
    { kind: "white", label: "White background" },
    { kind: "in-use", label: "In use" },
    { kind: "european-model", label: "European model" },
    { kind: "indian-model", label: "Indian model" },
    { kind: "east-asian-model", label: "East Asian model" },
];

const KINDS = new Set<string>(PHOTO_KINDS.map((p) => p.kind));
const STATES = new Set<string>(["sending", "waiting", "published", "declined"]);
const MIMES = new Set<string>(["image/jpeg", "image/png", "image/webp"]);

export const photoLabel = (kind: PhotoKind): string => PHOTO_KINDS.find((p) => p.kind === kind)?.label ?? kind;

/** What the website's products take, so a damaged or hostile row cannot make a huge or odd product. */
export const LIMITS = {
    name: 200,
    description: 5000,
    highlight: 200,
    highlights: 10,
    specKey: 80,
    specValue: 200,
    specs: 20,
    tag: 50,
    tags: 15,
    code: 40,
    price: 10_000_000,
    photos: 5,
} as const;

const isObject = (value: unknown): value is Record<string, unknown> => typeof value === "object" && value !== null && !Array.isArray(value);
const finite = (value: unknown): value is number => typeof value === "number" && Number.isFinite(value);

// Control characters other than tab and new line are never wanted in a name or a word.
const CONTROL = /[\u0000-\u0008\u000B\u000C\u000E-\u001F\u007F]/g;

/** A line of text, tidied: no control characters, one space between words, cut to its length. */
export function line(value: unknown, max: number): string {
    return typeof value === "string" ? value.replace(CONTROL, "").replace(/\s+/g, " ").trim().slice(0, max) : "";
}

/** A paragraph, tidied: no control characters and no blank lines in a row, cut to its length. */
export function paragraph(value: unknown, max: number): string {
    return typeof value === "string" ? value.replace(CONTROL, "").replace(/\r\n?/g, "\n").replace(/\n{3,}/g, "\n\n").trim().slice(0, max) : "";
}

function lines(value: unknown, max: number, count: number): string[] {
    return Array.isArray(value) ? value.map((item) => line(item, max)).filter(Boolean).slice(0, count) : [];
}

const money = (value: number) => Math.round(value * 100) / 100;

/** The words and prices of an offer, or null when it cannot be one (no name, no description, no price the shop could charge). */
export function readOffer(data: unknown): ShopOffer | null {
    if (!isObject(data)) return null;
    const name = line(data.name, LIMITS.name);
    const description = paragraph(data.description, LIMITS.description);
    if (!name || !description || !finite(data.price) || !(data.price > 0) || data.price > LIMITS.price) return null;
    const price = money(data.price);
    const mrp = finite(data.originalPrice) && data.originalPrice > price && data.originalPrice <= LIMITS.price ? money(data.originalPrice) : null;
    const specifications = (Array.isArray(data.specifications) ? data.specifications : [])
        .map((spec) => (isObject(spec) ? { key: line(spec.key, LIMITS.specKey), value: line(spec.value, LIMITS.specValue) } : null))
        .filter((spec): spec is { key: string; value: string } => spec !== null && spec.key !== "" && spec.value !== "")
        .slice(0, LIMITS.specs);
    const barcode = typeof data.barcode === "string" ? normalizeBarcode(line(data.barcode, 64)) : "";
    return {
        name,
        description,
        price,
        originalPrice: mrp,
        highlights: lines(data.highlights, LIMITS.highlight, LIMITS.highlights),
        specifications,
        tags: lines(data.tags, LIMITS.tag, LIMITS.tags),
        categoryId: line(data.categoryId, 64),
        subcategoryId: line(data.subcategoryId, 64),
        categoryPath: line(data.categoryPath, 200),
        barcode: /^[A-Z0-9.]{4,64}$/.test(barcode) ? barcode : null,
        posName: line(data.posName, LIMITS.name),
        code: line(data.code, LIMITS.code),
    };
}

/** A row of `shop_products`, or null when it cannot be read. A photo kind this page does not know is left out. */
export function readShopProduct(row: unknown): ShopProduct | null {
    if (!isObject(row)) return null;
    const key = typeof row.product_key === "string" && /^\d{1,10}$/.test(row.product_key) ? row.product_key : null;
    const offer = readOffer(row.data);
    const state = typeof row.state === "string" && STATES.has(row.state) ? (row.state as ShopProductState) : null;
    const sentAt = new Date(typeof row.sent_at === "string" ? row.sent_at : NaN);
    const decided = typeof row.decided_at === "string" ? new Date(row.decided_at) : null;
    if (!key || !offer || !state || Number.isNaN(sentAt.getTime())) return null;
    const kinds = Array.isArray(row.photo_kinds) ? row.photo_kinds.filter((k): k is PhotoKind => typeof k === "string" && KINDS.has(k)) : [];
    return {
        key,
        offer,
        state,
        photoKinds: PHOTO_KINDS.map((p) => p.kind).filter((kind) => kinds.includes(kind)),
        sentAt,
        decidedAt: decided && !Number.isNaN(decided.getTime()) ? decided : null,
    };
}

const BASE64 = /^[A-Za-z0-9+/]+={0,2}$/;

/** A row of `shop_product_photos`, or null when it is not a picture this page will show or upload. */
export function readPhoto(row: unknown): ShopPhoto | null {
    if (!isObject(row)) return null;
    const { kind, mime, content } = row;
    if (typeof kind !== "string" || !KINDS.has(kind) || typeof mime !== "string" || !MIMES.has(mime)) return null;
    if (typeof content !== "string" || content.length < 100 || content.length > 900_000 || !BASE64.test(content)) return null;
    return { kind: kind as PhotoKind, mime: mime as ShopPhoto["mime"], content };
}

/** The picture as an address to show or to upload. */
export const photoSrc = (photo: ShopPhoto): string => `data:${photo.mime};base64,${photo.content}`;

/** Supabase's answer when the project's script is older than this screen: the waiting list's tables are not there. */
const NO_TABLE = new Set(["42P01", "PGRST205"]);

export const productsMissing = (error: { code?: string } | null | undefined, status?: number) =>
    Boolean(error) && (NO_TABLE.has(error?.code ?? "") || status === 404);

// ---------------------------------------------------------------------------------------------------------------
// This website's categories: a main category, and subcategories under it. Deeper levels have no place in a product.
// ---------------------------------------------------------------------------------------------------------------

const BETWEEN = " › ";

/** The places a product can go, each main category followed by its subcategories, in the order the website keeps them. */
export function categoryChoices(categories: SiteCategory[]): CategoryChoice[] {
    const mains = categories.filter((c) => !c.parentId);
    const out: CategoryChoice[] = [];
    for (const main of mains) {
        out.push({ categoryId: main.id, subcategoryId: "", label: main.name });
        for (const sub of categories.filter((c) => c.parentId === main.id)) {
            out.push({ categoryId: main.id, subcategoryId: sub.id, label: main.name + BETWEEN + sub.name });
        }
    }
    return out;
}

/** The place the pair names, when it is one of the website's; else null. */
export function choiceOf(categories: SiteCategory[], categoryId: string, subcategoryId: string): CategoryChoice | null {
    return categoryChoices(categories).find((c) => c.categoryId === categoryId && c.subcategoryId === (subcategoryId || "")) ?? null;
}

/** The value of a choice in a list of choices: the subcategory's id, or the main category's. */
export const choiceValue = (choice: CategoryChoice): string => choice.subcategoryId || choice.categoryId;

export function choiceFromValue(categories: SiteCategory[], value: string): CategoryChoice | null {
    return categoryChoices(categories).find((c) => choiceValue(c) === value) ?? null;
}

/** What the website sends to the project so that the shop PC can choose a category (`save_site_categories`): at most 1,000. */
export function categoriesForProject(categories: SiteCategory[]): { id: string; name: string; parentId: string | null }[] {
    const seen = new Set<string>();
    const out: { id: string; name: string; parentId: string | null }[] = [];
    for (const category of categories) {
        const id = typeof category.id === "string" ? category.id.trim() : "";
        const name = line(category.name, 120);
        const parentId = category.parentId ? String(category.parentId).trim() : null;
        if (!id || id.length > 64 || !name || seen.has(id) || (parentId !== null && (parentId === "" || parentId.length > 64))) continue;
        seen.add(id);
        out.push({ id, name, parentId });
        if (out.length >= 1000) break;
    }
    return out;
}

/** Whether the list the project already has (`site_categories.categories`) is the one to send, so an unchanged list is not sent again. */
export function sameCategories(stored: unknown, wanted: { id: string; name: string; parentId: string | null }[]): boolean {
    if (!Array.isArray(stored) || stored.length !== wanted.length) return false;
    return wanted.every((category, index) => {
        const have = stored[index];
        return isObject(have) && have.id === category.id && have.name === category.name && (have.parentId ?? null) === category.parentId;
    });
}

/** A short text that changes when the list of categories does, so the project is told only when it changed. */
export const categoriesSignature = (categories: SiteCategory[]): string =>
    categoriesForProject(categories).map((c) => `${c.id}\t${c.parentId ?? ""}\t${c.name}`).join("\n");

// ---------------------------------------------------------------------------------------------------------------
// Publishing: what the screen asks this website to do for one approved product.
// ---------------------------------------------------------------------------------------------------------------

/** A product to put on the website (or to update there), as the screen sends it to the server. */
export interface PublishInput {
    shopId: string; // the Supabase shop, to give the product a place that is the same every time
    productKey: string; // the POS product's number
    name: string;
    description: string;
    price: number;
    originalPrice: number | null;
    highlights: string[];
    specifications: { key: string; value: string }[];
    tags: string[];
    barcode: string | null;
    categoryId: string;
    subcategoryId: string;
    /** The photos to use, as addresses of Cloudinary pictures; none leaves an existing product's pictures as they are. */
    imageUrls: string[];
    /** A product already on the website that the owner chose to update, when it is not the one this shop PC made before. */
    updateId: string | null;
}

export type Cleaned = { ok: true; value: PublishInput } | { ok: false; error: string };

const UUID = /^[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}$/i;
const SITE_ID = /^[A-Za-z0-9_-]{1,64}$/;
const CLOUDINARY = /^https:\/\/res\.cloudinary\.com\/[A-Za-z0-9_-]+\/image\/upload\/[^\s"'<>]+$/;

/** Checks what the browser sent, whatever it is: the server never takes it on trust. */
export function cleanPublishInput(input: unknown): Cleaned {
    if (!isObject(input)) return { ok: false, error: "The product is missing." };
    if (typeof input.shopId !== "string" || !UUID.test(input.shopId)) return { ok: false, error: "The shop is not known." };
    if (typeof input.productKey !== "string" || !/^\d{1,10}$/.test(input.productKey)) return { ok: false, error: "The product is not known." };
    const offer = readOffer({
        name: input.name, description: input.description, price: input.price, originalPrice: input.originalPrice,
        highlights: input.highlights, specifications: input.specifications, tags: input.tags, barcode: input.barcode,
    });
    if (!offer) return { ok: false, error: "The product needs a name, a description and a price." };
    const categoryId = line(input.categoryId, 64);
    const subcategoryId = line(input.subcategoryId, 64);
    if (!categoryId) return { ok: false, error: "Choose a category for the product." };
    const imageUrls = Array.isArray(input.imageUrls) ? input.imageUrls : [];
    if (imageUrls.length > LIMITS.photos || !imageUrls.every((url) => typeof url === "string" && url.length <= 600 && CLOUDINARY.test(url))) {
        return { ok: false, error: "The photos are not as expected." };
    }
    const updateId = input.updateId === null || input.updateId === undefined ? null : input.updateId;
    if (updateId !== null && (typeof updateId !== "string" || !SITE_ID.test(updateId))) return { ok: false, error: "The product to update is not known." };
    return {
        ok: true,
        value: {
            shopId: input.shopId.toLowerCase(),
            productKey: input.productKey,
            name: offer.name,
            description: offer.description,
            price: offer.price,
            originalPrice: offer.originalPrice,
            highlights: offer.highlights,
            specifications: offer.specifications,
            tags: offer.tags,
            barcode: offer.barcode,
            categoryId,
            subcategoryId,
            imageUrls: imageUrls as string[],
            updateId,
        },
    };
}

/** The fields of a website product that an approved offer sets. What it leaves out (stock, offers, video, reviews) stays as it is. */
export function productFields(value: PublishInput): Record<string, unknown> {
    const fields: Record<string, unknown> = {
        name: value.name,
        description: value.description,
        price: value.price,
        originalPrice: value.originalPrice,
        categoryId: value.categoryId,
        subcategoryId: value.subcategoryId || null,
        tags: value.tags,
        highlights: value.highlights,
        specifications: value.specifications,
        barcode: value.barcode,
    };
    if (value.imageUrls.length > 0) {
        fields.imageUrl = value.imageUrls[0];
        fields.images = value.imageUrls;
    }
    return fields;
}

/** Whether the offer can be approved as it stands, and if not, what the owner has to do first (in words for the owner). */
export function approveBlocker(options: { signedIn: boolean; choice: CategoryChoice | null; photos: number; isNew: boolean; loadingPhotos: boolean }): string | null {
    if (!options.signedIn) return "Sign in to your website's admin to publish products.";
    if (!options.choice) return "Choose a category of your website.";
    if (options.loadingPhotos) return "The photos are still loading.";
    if (options.isNew && options.photos === 0) return "Choose at least one photo: a new product needs a picture.";
    return null;
}
