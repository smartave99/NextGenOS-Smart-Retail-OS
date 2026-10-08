import "server-only";

import packs from "./generated/packs.json";
import { getSettings } from "@/lib/customer/settings";
import { NEUTRAL_PACK } from "./neutral";
import type { CountryPack } from "./types";

/**
 * What the website needs to know about the shop's country: its money, language and tax words. It comes from the country pack
 * (country-packs/ in the repository), chosen by the customer's country setting (see ../customer/settings.ts), so selling to a
 * shop in another country means setting that one value, not changing code. With no country set the pack is neutral: no tax rule.
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

/** The pack of a country, or of the customer's own country (a setting) when none is given; the neutral pack when there is no country. */
export function getPack(country: string | undefined = getSettings().country): CountryPack {
    const code = (country || "").trim().toUpperCase();
    if (!code) return NEUTRAL_PACK;
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
        place: getSettings().shopPlace.trim(),
        regionCode: getSettings().regionCode.trim(),
        reviewed: pack.review !== null,
    };
}
