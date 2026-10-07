import type { CountryPack, CurrencyInfo } from "./types";

/**
 * What the website uses when the customer has chosen no country: no country name, no currency symbol, two decimals, the plain English the screens are written in.
 * It is not a market (CLAUDE.md, section 8): amounts are shown as plain numbers, and there is no tax rule.
 */
export const NEUTRAL_CURRENCY: CurrencyInfo = {
    code: "",
    symbol: "",
    decimals: 2,
    symbolPosition: "before",
    symbolSpace: false,
    grouping: "standard",
    decimalSeparator: ".",
    groupSeparator: ",",
};

export const NEUTRAL_REGION = {
    name: "",
    currency: NEUTRAL_CURRENCY,
    locale: "en",
    languages: ["en"],
    timezone: "",
    taxName: "Tax",
    pricesIncludeTax: true,
};

/** The country pack for "no country": no tax rule at all. */
export const NEUTRAL_PACK: CountryPack = {
    schema: 1,
    country: "",
    name: "",
    asOf: "",
    review: null,
    currency: NEUTRAL_CURRENCY,
    locale: "en",
    languages: ["en"],
    timezone: "",
    phoneCode: "",
    fiscalYearStart: { month: 1, day: 1 },
    tax: { name: "Tax", model: "none", pricesIncludeTaxDefault: true, rates: [] },
    invoice: { title: "Invoice", requiredFields: [], eInvoice: null, retentionYears: 0 },
    notes: [],
};
