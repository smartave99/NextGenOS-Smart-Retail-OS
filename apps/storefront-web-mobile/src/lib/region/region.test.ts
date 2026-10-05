import { describe, expect, it } from "vitest";
import packs from "./generated/packs.json";
import vectors from "./generated/tax-vectors.json";
import { formatMoney } from "./money";
import { calculateTax } from "./tax-engine";
import type { CountryPack, TaxAdjustmentInput, TaxContext, TaxLineInput } from "./types";
import { formatPrice } from "./RegionProvider";

const all = packs as unknown as Record<string, CountryPack>;

interface Case {
    name: string;
    pack?: string;
    inline?: CountryPack;
    context: TaxContext;
    lines: TaxLineInput[];
    adjustments?: TaxAdjustmentInput[];
    expected: unknown;
}

describe("the engine contract (country-packs/vectors)", () => {
    for (const c of vectors.cases as unknown as Case[]) {
        it(c.name, () => {
            const pack = c.inline ?? all[c.pack as string];
            expect(calculateTax(pack, c.context, c.lines, c.adjustments ?? [])).toEqual(c.expected);
        });
    }
});

describe("how amounts are written", () => {
    for (const f of vectors.formats) {
        it(`${f.pack} ${f.amount}`, () => {
            expect(formatMoney(f.amount, all[f.pack].currency)).toBe(f.expected);
        });
    }

    it("writes a JavaScript number the way the shop's country does, without floating point surprises", () => {
        expect(formatPrice(1234567.5, all.IN.currency)).toBe("₹12,34,567.50");
        expect(formatPrice(0.1 + 0.2, all.IN.currency)).toBe("₹0.30");
        expect(formatPrice(-19.99, all.US.currency)).toBe("-$19.99");
        expect(formatPrice(1999, all.JP.currency)).toBe("¥1,999");
        expect(formatPrice(Number.NaN, all.IN.currency)).toBe("");
    });
});

describe("the packs", () => {
    it("India and the Philippines have what a shop there needs", () => {
        expect(all.IN.tax.model).toBe("gst-india");
        expect(all.IN.tax.rates.filter((r) => !r.legacy && r.percent).map((r) => r.percent)).toEqual(expect.arrayContaining(["5", "18", "40"]));
        expect(all.IN.tax.regions?.list.length).toBeGreaterThanOrEqual(36);
        expect(all.PH.tax.customerDiscounts?.map((d) => d.code)).toEqual(["SENIOR", "PWD"]);
        expect(Object.keys(all).length).toBeGreaterThanOrEqual(30);
    });

    it("refuses what it cannot compute, in plain words", () => {
        expect(() => calculateTax(all.IN, { pricesIncludeTax: true, sellerRegion: "27" }, [{ qty: "1", unitPrice: "10.005", taxCode: "GST5" }])).toThrow(/more than 2 decimals/);
        expect(() => calculateTax(all.IN, { pricesIncludeTax: true, sellerRegion: "27" }, [{ qty: "1", unitPrice: "10", taxCode: "NOPE" }])).toThrow(/Unknown tax code/);
    });
});
