import lite from "./generated/lite.json";
import { getSettings } from "@/lib/customer/settings";
import { formatMoney } from "./money";
import { NEUTRAL_REGION } from "./neutral";
import type { CurrencyInfo } from "./types";

/**
 * The shop's country as every page and component can read it, in the browser as well: money, locale, language and the name of the
 * tax. It is the customer's own setting (a two-letter code with a pack in country-packs/, read when the website starts: see
 * ../customer/settings.ts), so a website for a shop in another country is set up by changing that one value. With no country set
 * it is neutral: no currency symbol, no country name, plain English. For the full pack (tax rates and rules) see ./server.
 */
interface Lite {
    name: string;
    currency: CurrencyInfo;
    locale: string;
    languages: string[];
    timezone: string;
    taxName: string;
    pricesIncludeTax: boolean;
}

const table = lite as unknown as Record<string, Lite>;
const settings = getSettings();
const code = settings.country.trim().toUpperCase();
const entry: Lite = table[code] ?? NEUTRAL_REGION;

/** "en-PH" is a usable locale when the computer knows it; anything else is not used. */
function usableLocale(tag: string): string | null {
    if (!tag) return null;
    try {
        return Intl.getCanonicalLocales(tag)[0] ?? null;
    } catch {
        return null;
    }
}
const language = settings.language.trim();
const languageLocale = usableLocale(language);

export const COUNTRY = table[code] ? code : "";
export const COUNTRY_NAME = entry.name;
export const CURRENCY = entry.currency;
/** The customer's own language (a setting) when it names a region, else the country's usual locale. */
export const LOCALE = languageLocale && language.includes("-") ? languageLocale : entry.locale;
/** The language of the pages: the customer's own when it is set, else the country's first. */
export const LANGUAGE = language ? (languageLocale ?? language).split("-")[0] : (entry.languages[0] ?? "en");
export const LANGUAGES = language ? [LANGUAGE, ...entry.languages.filter((l) => l !== LANGUAGE)] : entry.languages;
export const TAX_NAME = entry.taxName;
export const PRICES_INCLUDE_TAX = entry.pricesIncludeTax;

/** The town or area the shop is in, for the words on the site (for example "Patna, India"); empty when not set. */
export const SHOP_PLACE = settings.shopPlace.trim();

/** 1234.5 → "₹1,234.50" (or "1.234,50 €" and so on, by country). A value that is not a number gives "". */
export function money(amount: number | string | null | undefined): string {
    if (amount === null || amount === undefined || amount === "") return "";
    const n = typeof amount === "number" ? amount : Number(amount);
    if (!Number.isFinite(n)) return "";
    const fixed = Math.abs(n).toFixed(CURRENCY.decimals);
    return formatMoney(n < 0 && Number(fixed) !== 0 ? `-${fixed}` : fixed, CURRENCY);
}

/** Whole amounts without the decimals when there are none to show: 155 → "₹155", 99.5 → "₹99.50". */
export function moneyShort(amount: number): string {
    return Number.isInteger(amount) ? money(amount).replace(new RegExp(`[${CURRENCY.decimalSeparator}]0{${CURRENCY.decimals}}$`), "") : money(amount);
}

/** Dates and times in the shop's country: new Intl.DateTimeFormat(LOCALE, …) written once. */
export const dateTime = (options: Intl.DateTimeFormatOptions) => new Intl.DateTimeFormat(LOCALE, { timeZone: undefined, ...options });
export const numberFormat = (options?: Intl.NumberFormatOptions) => new Intl.NumberFormat(LOCALE, options);
