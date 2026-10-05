import { COUNTRY_NAME, LANGUAGES, SHOP_PLACE } from "@/lib/region/lite";
import { SHOP_NAME } from "@/lib/shop-name";

/**
 * What the shop's AI assistants and texts may say about the shop, taken from settings and the country pack, never written into
 * the code: NEXT_PUBLIC_SITE_NAME, NEXT_PUBLIC_SHOP_PLACE (for example "Patna, India") and NEXT_PUBLIC_COUNTRY.
 */

/** "English, Hindi" for the languages the country pack lists. */
export function languageList(codes: readonly string[] = LANGUAGES): string {
    try {
        const names = new Intl.DisplayNames(["en"], { type: "language" });
        return codes.map((c) => names.of(c) ?? c).join(", ");
    } catch {
        return codes.join(", ");
    }
}

/** "a store in Patna, India" or just "a store". */
export const STORE_PHRASE = SHOP_PLACE ? `a store in ${SHOP_PLACE}` : "a store";

/** "the Patna store" style words: "the store". */
export const THE_STORE = "the store";

export const SHOP_FACTS = {
    name: SHOP_NAME,
    place: SHOP_PLACE,
    countryName: COUNTRY_NAME,
    languages: languageList(),
    storePhrase: STORE_PHRASE,
};
