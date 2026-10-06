import lite from "./generated/lite.json";
import { formatMoney } from "./money";
import type { CurrencyInfo } from "./types";

/**
 * The shop's country as every page and component can read it, in the browser as well: money, locale, language and the name of the
 * tax. It is chosen by NEXT_PUBLIC_COUNTRY (a two-letter code with a pack in country-packs/), so a website for a shop in another
 * country is set up by changing that one value. For the full pack (tax rates and rules) see ./server.
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
const code = (process.env.NEXT_PUBLIC_COUNTRY || "IN").trim().toUpperCase();
const entry = table[code];
if (!entry) {
    throw new Error(`There is no country pack for "${code}" (NEXT_PUBLIC_COUNTRY). Add one with: node country-packs/tools/cli.mjs new ${code}`);
}

export const COUNTRY = code;
export const COUNTRY_NAME = entry.name;
export const CURRENCY = entry.currency;
export const LOCALE = entry.locale;
export const LANGUAGES = entry.languages;
export const TAX_NAME = entry.taxName;
export const PRICES_INCLUDE_TAX = entry.pricesIncludeTax;

/** The town or area the shop is in, for the words on the site (for example "Patna, India"); empty when not set. */
export const SHOP_PLACE = (process.env.NEXT_PUBLIC_SHOP_PLACE || "").trim();

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
