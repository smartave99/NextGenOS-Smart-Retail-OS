/** A country pack (country-packs/SPEC.md section 3). Kept in step with libs/dotnet/NextGenOS.Tax/CountryPack.cs. */
export interface CurrencyInfo {
    code: string;
    symbol: string;
    decimals: number;
    symbolPosition: "before" | "after";
    symbolSpace: boolean;
    grouping: "indian" | "standard" | "none";
    decimalSeparator: string;
    groupSeparator: string;
}

export interface TaxRate {
    code: string;
    label: string;
    percent?: string;
    exempt?: boolean;
    zero?: boolean;
    taxable?: boolean;
    legacy?: boolean;
    component?: string;
}

export interface RegionComponent {
    name: string;
    percent: string;
    editable?: boolean;
}

export interface Region {
    code: string;
    name: string;
    components?: RegionComponent[];
}

export interface CustomerDiscount {
    code: string;
    label: string;
    percent: string;
    vatExempt: boolean;
    law?: string;
}

export interface TaxRules {
    name: string;
    model: "gst-india" | "vat" | "regional" | "none";
    pricesIncludeTaxDefault: boolean;
    rates: TaxRate[];
    classes?: Partial<Record<"standard" | "reduced" | "zero" | "exempt", string>>;
    regions?: { label?: string; list: Region[] };
    businessId?: { label: string; pattern?: string | null };
    /** A code a line may carry for the goods or service it sells (the country's own name for it). Shown on the item and the bill when present. */
    itemCode?: { label: string; help?: string };
    /** A further tax some items carry on top of the main one, as a percent set on the item (the country's own name for it). */
    extraTax?: { label: string; help?: string };
    /** The lists this country's tax returns are made from: each bill or credit note goes into the first list whose rule it meets. */
    /** The blocks of the summary of supplies the country's periodic return asks for: each line goes in the first block of its side whose rule it meets. */
    summary?: { title: string; blocks: { id: string; label: string; side: "outward" | "inward"; when: { rate?: "taxed" | "zero" | "exempt"; partyHasTaxId?: boolean; betweenRegions?: boolean } }[] };
    returns?: { title: string; lists: { id: string; label: string; kind: "bill" | "credit"; when: { partyHasTaxId?: boolean; betweenRegions?: boolean; totalOver?: string } }[] };
    customerDiscounts?: CustomerDiscount[];
    rounding?: { total: "nearest" | "none"; increment?: string; defaultOn?: boolean };
}

export interface CountryPack {
    schema: number;
    country: string;
    name: string;
    asOf: string;
    review: { by: string; on: string; notes?: string } | null;
    currency: CurrencyInfo;
    locale: string;
    languages: string[];
    timezone: string;
    phoneCode: string;
    fiscalYearStart: { month: number; day: number };
    units?: { weight: string; length: string };
    tax: TaxRules;
    invoice: { title: string; requiredFields: string[]; eInvoice: string | null; retentionYears: number };
    notes: string[];
}

export interface TaxContext {
    pricesIncludeTax: boolean;
    sellerRegion?: string;
    buyerRegion?: string;
    registered?: boolean;
    roundTotal?: boolean;
}

export interface TaxLineInput {
    name?: string;
    qty: string;
    unitPrice: string;
    taxCode: string;
    discountPercent?: string;
    discountAmount?: string;
    cessPercent?: string;
    customerDiscount?: string;
}

export interface TaxAdjustmentInput {
    code: string;
    kind: "surcharge" | "fee" | "tip" | "retention" | "advance";
    label?: string;
    percent?: string;
    amount?: string;
    base?: "taxable" | "subTotal";
    taxCode?: string;
}

export interface Component {
    name: string;
    amount: string;
}

export interface TaxResult {
    lines: Array<{
        gross: string; discount: string; taxable: string; components: Component[]; cess: string;
        customerDiscount: string; exemptAmount: string; lineTotal: string;
    }>;
    adjustments: Array<{ code: string; kind: string; label: string; amount: string; taxable: string; components: Component[] }>;
    totals: {
        gross: string; discount: string; taxable: string; components: Component[]; cess: string; customerDiscount: string;
        exemptSales: string; subTotal: string; roundOff: string; grandTotal: string;
        tips: string; advances: string; retention: string; payable: string; credit: string;
    };
    byCode: Array<{ code: string; percent: string; taxable: string; components: Component[]; cess: string }>;
}
