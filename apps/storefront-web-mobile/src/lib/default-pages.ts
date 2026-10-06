import { SHOP_NAME } from "@/lib/shop-name";

/**
 * What the About page shows before the shop writes its own. Nothing here is a claim about the shop (no numbers of customers, no
 * guarantees, no place): the owner fills those in under Admin > Content > About. Empty parts are left out of the page.
 */
export const DEFAULT_ABOUT = {
    heroTitle: SHOP_NAME,
    heroSubtitle: "",
    heroImage: "",
    heroLabel: "Our Story",
    visionTitle: "About us",
    visionLabel: "Who we are",
    visionText1: `Welcome to ${SHOP_NAME}.`,
    visionText2: "",
    visionImage: "",
    statsCustomers: "",
    statsCustomersLabel: "",
    statsSatisfaction: "",
    statsSatisfactionLabel: "",
    contactTitle: "Visit Our Store",
    contactSubtitle: "Here is where you can find us.",
    valuesTitle: "",
    valuesSubtitle: "",
    values: [] as Array<{ title: string; desc: string; icon: string; color: string }>,
};

/** Only a map from a known provider, over https, is shown in the page. */
export function safeMapEmbed(url: string | null | undefined): string | null {
    if (!url) return null;
    try {
        const u = new URL(url);
        const ok = u.protocol === "https:" && (u.hostname === "www.google.com" || u.hostname === "maps.google.com" || u.hostname === "www.openstreetmap.org");
        return ok ? u.toString() : null;
    } catch {
        return null;
    }
}
