import "server-only";

import packs from "./generated/packs.json";
import type { CountryPack } from "./types";

/**
 * What the website needs to know about the shop's country: its money, language and tax words. It comes from the country pack
 * (country-packs/ in the repository), chosen by NEXT_PUBLIC_COUNTRY, so selling to a shop in another country means setting that
 * one value, not changing code.
 */
export interface RegionInfo {
    country: string;
    countryName: string;
    currency: CountryPack["currency"];
    locale: string;
    languages: string[];
    taxName: string;
    pricesIncludeTax: boolean;
    /** The town or area the shop is in, for the words on the site (for example "Patna, India"). */
    place: string;
    /** The state or province code that decides local tax (for example "10"). */
    regionCode: string;
    /** True when a local adviser has recorded that they checked this country's rules. */
    reviewed: boolean;
}

const all = packs as unknown as Record<string, CountryPack>;
export const DEFAULT_COUNTRY = "IN";

export function getPack(country: string | undefined = process.env.NEXT_PUBLIC_COUNTRY): CountryPack {
    const code = (country || DEFAULT_COUNTRY).trim().toUpperCase();
    const pack = all[code];
    if (!pack) {
        throw new Error(`There is no country pack for "${code}". Add one with: node country-packs/tools/cli.mjs new ${code}`);
    }
    return pack;
}

export function listPacks(): CountryPack[] {
    return Object.values(all).sort((a, b) => a.name.localeCompare(b.name));
}

export function getRegion(): RegionInfo {
    const pack = getPack();
    return {
        country: pack.country,
        countryName: pack.name,
        currency: pack.currency,
        locale: pack.locale,
        languages: pack.languages,
        taxName: pack.tax.name,
        pricesIncludeTax: pack.tax.pricesIncludeTaxDefault,
        place: (process.env.NEXT_PUBLIC_SHOP_PLACE || "").trim(),
        regionCode: (process.env.NEXT_PUBLIC_REGION_CODE || "").trim(),
        reviewed: pack.review !== null,
    };
}
