/**
 * Applies the licence's brand to the site's configuration, as far as the licence's white-label level allows
 * (spec section 5.1). Pure functions: no files, no network.
 *
 *   none  : the licence brand is forced; the shop owner cannot change name, logo or colours.
 *   theme : the licence brand is the starting point; whatever the shop owner changed is kept.
 *   full  : like theme (a reseller also renames the product itself, which is outside the site configuration).
 */
import type { SiteConfig } from "@/types/site-config";
import type { BrandProfile } from "./evaluate";

type Level = "none" | "theme" | "full";

const same = (a: unknown, b: unknown) => a === b;

export function applyBrand(config: SiteConfig, brand: BrandProfile | null, level: Level, defaults: SiteConfig): SiteConfig {
    if (!brand) return config;
    const out: SiteConfig = JSON.parse(JSON.stringify(config));
    const force = level === "none";
    // Set a value when the licence is strict, or when the shop owner never changed the neutral default.
    const set = <T,>(read: () => T, write: (v: T) => void, def: () => T, value: T | undefined | null) => {
        if (value === undefined || value === null || value === "") return;
        if (force || same(read(), def())) write(value as T);
    };

    set(() => out.branding.siteName, (v) => { out.branding.siteName = v; }, () => defaults.branding.siteName, brand.name);
    if (brand.logo && /^data:image\//.test(brand.logo)) set(() => out.branding.logoUrl, (v) => { out.branding.logoUrl = v; }, () => defaults.branding.logoUrl, brand.logo);
    set(() => out.theme.primaryColor, (v) => { out.theme.primaryColor = v; }, () => defaults.theme.primaryColor, brand.primaryColor);
    set(() => out.theme.accentColor, (v) => { out.theme.accentColor = v; }, () => defaults.theme.accentColor, brand.accentColor);
    set(() => out.contact.email, (v) => { out.contact.email = v; }, () => defaults.contact.email, brand.supportEmail);
    set(() => out.contact.phone, (v) => { out.contact.phone = v; }, () => defaults.contact.phone, brand.supportPhone);
    set(() => out.seo.jsonLd.name, (v) => { out.seo.jsonLd.name = v; }, () => defaults.seo.jsonLd.name, brand.name);
    set(() => out.manifest.name, (v) => { out.manifest.name = v; }, () => defaults.manifest.name, brand.name);
    set(() => out.manifest.shortName, (v) => { out.manifest.shortName = v; }, () => defaults.manifest.shortName, brand.shortName || brand.name);
    return out;
}

// ---------------------------------------------------------------------------------------------------------------------------------------
// Local brand on top of the licence's brand (spec section 5.2). The .NET library (BrandPolicy.cs) follows the same rules and both pass
// licensing/testvectors/brand-policy.json.
// ---------------------------------------------------------------------------------------------------------------------------------------

export interface LocalBrand {
    name?: string; shortName?: string; primaryColor?: string; accentColor?: string; logo?: string;
    supportEmail?: string; supportPhone?: string; poweredBy?: boolean;
}

export const DEFAULT_BRAND: BrandProfile = {
    id: "B-0", name: "Smart Retail POS", shortName: "Smart Retail POS", legalName: "NextGenOS", primaryColor: "#0f6cbd", accentColor: "#f59e0b",
    supportEmail: "smartave99@gmail.com", supportPhone: "+91 6123115368", copyright: "© 2026 NextGenOS. All rights reserved.", poweredBy: false,
};

export const MAX_LOGO_LENGTH = 140000;
const MIN_CONTRAST_WITH_WHITE = 3.0;

/** WCAG contrast ratio of a "#rrggbb" colour with white (1 to 21). */
export function contrastWithWhite(hex: string): number {
    const channel = (from: number) => {
        const c = parseInt(hex.slice(from, from + 2), 16) / 255;
        return c <= 0.04045 ? c / 12.92 : Math.pow((c + 0.055) / 1.055, 2.4);
    };
    return 1.05 / (0.2126 * channel(1) + 0.7152 * channel(3) + 0.0722 * channel(5) + 0.05);
}

/** "#rrggbb" in lower case when the value is a hex colour white text can be read on; otherwise undefined. */
export function usableColour(value: unknown): string | undefined {
    return typeof value === "string" && /^#[0-9a-fA-F]{6}$/.test(value) && contrastWithWhite(value) >= MIN_CONTRAST_WITH_WHITE ? value.toLowerCase() : undefined;
}

/** The value when it is a small PNG, JPEG or SVG picture as a data URI; otherwise undefined. */
export function validLogo(value: unknown): string | undefined {
    return typeof value === "string" && value.length <= MAX_LOGO_LENGTH && /^data:image\/(png|jpeg|svg\+xml);base64,[A-Za-z0-9+/=]+$/.test(value) ? value : undefined;
}

/** Control characters removed, trimmed, cut to max characters. Never undefined. */
export function cleanText(value: unknown, max: number): string {
    if (typeof value !== "string" || value.trim() === "") return "";
    // eslint-disable-next-line no-control-regex
    const trimmed = value.replace(/[\u0000-\u001f\u007f-\u009f]/g, "").trim();
    return trimmed.length <= max ? trimmed : trimmed.slice(0, max);
}

/** The licence's brand (or NextGenOS's own) with the local brand applied as far as the white-label level allows. */
export function resolveBrand(licence: BrandProfile | null | undefined, level: string | null | undefined, local: LocalBrand | null | undefined): BrandProfile {
    const result: BrandProfile = { ...(licence ?? DEFAULT_BRAND) };
    if (!local || typeof local !== "object" || (level !== "theme" && level !== "full")) return result;

    const primary = usableColour(local.primaryColor); if (primary) result.primaryColor = primary;
    const accent = usableColour(local.accentColor); if (accent) result.accentColor = accent;
    const logo = validLogo(local.logo); if (logo) result.logo = logo;
    const email = cleanText(local.supportEmail, 120); if (email) result.supportEmail = email;
    const phone = cleanText(local.supportPhone, 40); if (phone) result.supportPhone = phone;
    if (level === "full") {
        const name = cleanText(local.name, 60); if (name) result.name = name;
        const shortName = cleanText(local.shortName, 60); if (shortName) result.shortName = shortName;
        if (typeof local.poweredBy === "boolean") result.poweredBy = local.poweredBy;
    }
    return result;
}
