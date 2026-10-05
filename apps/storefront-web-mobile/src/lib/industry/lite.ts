import industries from "./generated/industries.json";

/**
 * The words of the shop's kind of business (restaurant: "Menu items", library: "Titles", construction: "Rate items"), from the
 * industry pack (industry-packs/), chosen by NEXT_PUBLIC_INDUSTRY. Pages say TERM.items.plural instead of the word "Products", so
 * the same website fits a shop, a café or a library.
 */
type Pair = [string, string];
interface IndustryLite {
    name: string;
    summary: string;
    vocabulary: Record<"customer" | "item" | "sale" | "invoice" | "staff" | "supplier" | "stock", Pair>;
    features: Record<string, boolean | string>;
    aiContext: string;
}

const table = industries as unknown as Record<string, IndustryLite>;
const id = (process.env.NEXT_PUBLIC_INDUSTRY || "retail").trim().toLowerCase();
const entry = table[id];
if (!entry) {
    throw new Error(`There is no industry pack "${id}" (NEXT_PUBLIC_INDUSTRY). Choose one of: ${Object.keys(table).join(", ")}.`);
}

export const INDUSTRY_ID = id;
export const INDUSTRY_NAME = entry.name;
export const AI_CONTEXT = entry.aiContext;

const pair = (p: Pair) => ({ singular: p[0], plural: p[1], lower: p[0].toLowerCase(), pluralLower: p[1].toLowerCase() });

/** TERM.item.plural is "Products" in a shop, "Menu items" in a café; TERM.customer.singular is "Guest" there. */
export const TERM = {
    customer: pair(entry.vocabulary.customer),
    item: pair(entry.vocabulary.item),
    sale: pair(entry.vocabulary.sale),
    invoice: pair(entry.vocabulary.invoice),
    staff: pair(entry.vocabulary.staff),
    supplier: pair(entry.vocabulary.supplier),
    stock: pair(entry.vocabulary.stock),
};
