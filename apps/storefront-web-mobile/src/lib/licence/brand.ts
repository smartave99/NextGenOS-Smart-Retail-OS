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
