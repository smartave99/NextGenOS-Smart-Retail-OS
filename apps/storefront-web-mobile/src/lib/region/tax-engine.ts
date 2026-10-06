import { formatMinor, parseDecimal } from "./money";
import type { Component, CountryPack, TaxAdjustmentInput, TaxContext, TaxLineInput, TaxRate, TaxResult } from "./types";

/**
 * The tax engine (country-packs/SPEC.md). Whole-number arithmetic only (BigInt), so the answer is exact and the same as the
 * C# engine's (libs/dotnet/NextGenOS.Tax): src/lib/region/generated/tax-vectors.json proves it.
 */
const HUNDRED = 100000n; // a percent is worked in thousandths: 100 % = 100000

/** Round half up: floor((2a + b) / 2b) for a >= 0, b > 0. */
const R = (a: bigint, b: bigint): bigint => (2n * a + b) / (2n * b);
const milli = (percent: string): bigint => parseDecimal(percent, 3);

interface Part { name: string; amount: bigint }
interface Comp { name: string; milli: bigint }
interface Work {
    code: string; percent: string; gross: bigint; discount: bigint; taxable: bigint; parts: Part[]; cess: bigint;
    customerDiscount: bigint; exemptAmount: bigint; lineTotal: bigint;
}

function rateOf(pack: CountryPack, code: string): TaxRate {
    const rate = pack.tax.rates.find((r) => r.code === code);
    if (!rate) throw new Error(`Unknown tax code ${code}`);
    return rate;
}

function regionComponents(pack: CountryPack, region: string | undefined): Comp[] {
    const found = pack.tax.regions?.list.find((x) => x.code === region);
    if (!found?.components) throw new Error(`No tax components for region ${region}`);
    return found.components.map((c) => ({ name: c.name, milli: milli(c.percent) }));
}

function formatPercent(m: bigint): string {
    const whole = m / 1000n;
    const frac = (m % 1000n).toString().padStart(3, "0").replace(/0+$/, "");
    return frac ? `${whole}.${frac}` : `${whole}`;
}

function componentNames(pack: CountryPack, context: TaxContext, rate: Partial<TaxRate>, comps: Comp[] | null): string[] {
    const model = pack.tax.model;
    if (model === "gst-india") {
        const inter = context.buyerRegion && context.sellerRegion && context.buyerRegion !== context.sellerRegion;
        return inter ? ["IGST"] : ["CGST", "SGST"];
    }
    if (model === "regional") return (comps ?? regionComponents(pack, context.buyerRegion ?? context.sellerRegion)).map((c) => c.name);
    if (model === "none") return [];
    return [rate.component ?? pack.tax.name];
}

const sum = (parts: Part[]): bigint => parts.reduce((a, p) => a + p.amount, 0n);

/** Steps 5 to 7 of the specification for one value: the net (prices include tax) or the taxable value (they do not). */
function taxLine(pack: CountryPack, names: string[], value: bigint, r: bigint, c: bigint, inclusive: boolean, comps: Comp[] | null) {
    const model = pack.tax.model;
    let taxable: bigint;
    let tax = 0n;
    let cess: bigint;
    if (inclusive) {
        taxable = R(value * HUNDRED, HUNDRED + r + c);
        const taxTotal = value - taxable;
        cess = R(taxable * c, HUNDRED);
        tax = taxTotal - cess;
    } else {
        taxable = value;
        cess = R(taxable * c, HUNDRED);
    }

    let parts: Part[];
    if (model === "none" || names.length === 0) {
        parts = [];
    } else if (model === "gst-india") {
        if (names.length === 2) {
            const cgst = inclusive ? R(tax, 2n) : R(taxable * r, 200000n);
            parts = [{ name: "CGST", amount: cgst }, { name: "SGST", amount: inclusive ? tax - cgst : cgst }];
        } else {
            parts = [{ name: "IGST", amount: inclusive ? tax : R(taxable * r, HUNDRED) }];
        }
    } else if (model === "regional") {
        const total = inclusive ? tax : R(taxable * r, HUNDRED);
        parts = [];
        let used = 0n;
        (comps ?? []).forEach((comp, i, all) => {
            let amount: bigint;
            if (i === all.length - 1) amount = total - used;
            else if (r === 0n) amount = 0n;
            else amount = inclusive ? R(total * comp.milli, r) : R(taxable * comp.milli, HUNDRED);
            used += amount;
            parts.push({ name: comp.name, amount });
        });
    } else {
        parts = [{ name: names[0], amount: inclusive ? tax : R(taxable * r, HUNDRED) }];
    }
    return { taxable, parts, cess };
}

function rateFor(pack: CountryPack, context: TaxContext, rate: TaxRate) {
    const registered = context.registered !== false;
    const taxFree = !registered || !!rate.exempt || !!rate.zero || pack.tax.model === "none";
    let r = 0n;
    let comps: Comp[] | null = null;
    if (pack.tax.model === "regional") {
        comps = regionComponents(pack, context.buyerRegion ?? context.sellerRegion);
        if (!taxFree) r = comps.reduce((a, c) => a + c.milli, 0n);
    } else if (!taxFree) {
        r = milli(rate.percent ?? "0");
    }
    return { taxFree, r, comps };
}

export function calculateTax(pack: CountryPack, context: TaxContext, lines: TaxLineInput[], adjustments: TaxAdjustmentInput[] = []): TaxResult {
    const d = pack.currency.decimals;
    const inclusive = !!context.pricesIncludeTax;
    const rounding = pack.tax.rounding ?? { total: "none" as const };
    const roundTotal = context.roundTotal ?? !!rounding.defaultOn;

    const work: Work[] = [];
    for (const line of lines) {
        const rate = rateOf(pack, line.taxCode);
        const q = parseDecimal(line.qty, 3);
        const p = parseDecimal(line.unitPrice, d);
        const gross = R(q * p, 1000n);
        let discount = 0n;
        if (line.discountAmount != null) discount = parseDecimal(line.discountAmount, d);
        else if (line.discountPercent != null) discount = R(gross * milli(line.discountPercent), HUNDRED);
        if (discount > gross) discount = gross;
        const net = gross - discount;

        const { taxFree, r, comps } = rateFor(pack, context, rate);
        const c = taxFree || line.cessPercent == null ? 0n : milli(line.cessPercent);
        const names = componentNames(pack, context, rate, comps);
        const out: Work = { code: line.taxCode, percent: formatPercent(r), gross, discount, taxable: 0n, parts: [], cess: 0n, customerDiscount: 0n, exemptAmount: 0n, lineTotal: 0n };

        const cd = line.customerDiscount ? (pack.tax.customerDiscounts ?? []).find((x) => x.code === line.customerDiscount) : undefined;
        if (line.customerDiscount && !cd) throw new Error(`Unknown customer discount ${line.customerDiscount}`);

        if (cd) {
            const base = inclusive ? R(net * HUNDRED, HUNDRED + r) : net;
            const amount = R(base * milli(cd.percent), HUNDRED);
            out.customerDiscount = amount;
            if (cd.vatExempt) {
                out.parts = names.map((name) => ({ name, amount: 0n }));
                out.exemptAmount = base;
                out.lineTotal = base - amount;
            } else {
                const t = base - amount;
                const rest = taxLine(pack, names, t, r, c, false, comps);
                out.taxable = t;
                out.parts = rest.parts;
                out.cess = rest.cess;
                out.lineTotal = t + sum(rest.parts) + rest.cess;
            }
        } else {
            const rest = taxLine(pack, names, net, r, c, inclusive, comps);
            out.taxable = rest.taxable;
            out.parts = rest.parts;
            out.cess = rest.cess;
            out.exemptAmount = rate.exempt ? rest.taxable : 0n;
            out.lineTotal = rest.taxable + sum(rest.parts) + rest.cess;
        }
        work.push(out);
    }

    const totalNames = work[0]?.parts.map((p) => p.name) ?? componentNames(pack, context, {}, null);
    const totals = { gross: 0n, discount: 0n, taxable: 0n, cess: 0n, customerDiscount: 0n, exemptSales: 0n, subTotal: 0n, parts: new Map<string, bigint>() };
    const byCode = new Map<string, { code: string; percent: string; taxable: bigint; parts: Map<string, bigint>; cess: bigint }>();
    const addParts = (into: Map<string, bigint>, parts: Part[]) => parts.forEach((p) => into.set(p.name, (into.get(p.name) ?? 0n) + p.amount));
    const bucket = (code: string, percent: string) => {
        let b = byCode.get(code);
        if (!b) byCode.set(code, (b = { code, percent, taxable: 0n, parts: new Map(), cess: 0n }));
        return b;
    };
    for (const l of work) {
        totals.gross += l.gross; totals.discount += l.discount; totals.taxable += l.taxable; totals.cess += l.cess;
        totals.customerDiscount += l.customerDiscount; totals.exemptSales += l.exemptAmount; totals.subTotal += l.lineTotal;
        addParts(totals.parts, l.parts);
        const b = bucket(l.code, l.percent);
        b.taxable += l.taxable;
        b.cess += l.cess;
        addParts(b.parts, l.parts);
    }

    // Adjustments (section 9), worked from the lines only.
    const lineTaxable = totals.taxable;
    const lineSub = totals.subTotal;
    const adjOut: Array<{ code: string; kind: string; label: string; amount: bigint; taxable: bigint; parts: Part[] }> = [];
    let tips = 0n;
    let advances = 0n;
    let retention = 0n;
    for (const adj of adjustments) {
        const baseValue = (adj.base ?? "taxable") === "subTotal" ? lineSub : lineTaxable;
        const pct = adj.percent != null ? milli(adj.percent) : null;
        const label = adj.label ?? "";
        if (adj.kind === "surcharge" || adj.kind === "fee") {
            const amount = pct != null ? R(baseValue * pct, HUNDRED) : parseDecimal(adj.amount ?? "0", d);
            let parts: Part[] = [];
            let taxable = 0n;
            if (adj.taxCode) {
                const rate = rateOf(pack, adj.taxCode);
                const { r, comps } = rateFor(pack, context, rate);
                const rest = taxLine(pack, componentNames(pack, context, rate, comps), amount, r, 0n, false, comps);
                taxable = rest.taxable;
                parts = rest.parts;
                totals.taxable += taxable;
                addParts(totals.parts, parts);
                const b = bucket(adj.taxCode, formatPercent(r));
                b.taxable += taxable;
                addParts(b.parts, parts);
            }
            totals.subTotal += amount + sum(parts);
            adjOut.push({ code: adj.code, kind: adj.kind, label, amount, taxable, parts });
        } else if (adj.kind === "tip") {
            const amount = parseDecimal(adj.amount ?? "0", d);
            tips += amount;
            adjOut.push({ code: adj.code, kind: adj.kind, label, amount, taxable: 0n, parts: [] });
        } else if (adj.kind === "advance") {
            const amount = parseDecimal(adj.amount ?? "0", d);
            advances += amount;
            adjOut.push({ code: adj.code, kind: adj.kind, label, amount, taxable: 0n, parts: [] });
        } else if (adj.kind === "retention") {
            const amount = pct != null ? R(baseValue * pct, HUNDRED) : parseDecimal(adj.amount ?? "0", d);
            retention += amount;
            adjOut.push({ code: adj.code, kind: adj.kind, label, amount, taxable: 0n, parts: [] });
        } else {
            throw new Error(`Unknown adjustment kind ${(adj as { kind: string }).kind}`);
        }
    }

    let grand = totals.subTotal;
    if (roundTotal && rounding.total === "nearest") {
        const inc = parseDecimal(rounding.increment ?? "1", d);
        grand = R(totals.subTotal, inc) * inc;
    }
    let payable = grand + tips - advances - retention;
    let credit = 0n;
    if (payable < 0n) {
        credit = -payable;
        payable = 0n;
    }

    const f = (n: bigint) => formatMinor(n, d);
    const comp = (parts: Part[]): Component[] => parts.map((p) => ({ name: p.name, amount: f(p.amount) }));
    return {
        lines: work.map((l) => ({
            gross: f(l.gross), discount: f(l.discount), taxable: f(l.taxable), components: comp(l.parts), cess: f(l.cess),
            customerDiscount: f(l.customerDiscount), exemptAmount: f(l.exemptAmount), lineTotal: f(l.lineTotal),
        })),
        adjustments: adjOut.map((a) => ({ code: a.code, kind: a.kind, label: a.label, amount: f(a.amount), taxable: f(a.taxable), components: comp(a.parts) })),
        totals: {
            gross: f(totals.gross), discount: f(totals.discount), taxable: f(totals.taxable),
            components: totalNames.map((name) => ({ name, amount: f(totals.parts.get(name) ?? 0n) })),
            cess: f(totals.cess), customerDiscount: f(totals.customerDiscount), exemptSales: f(totals.exemptSales),
            subTotal: f(totals.subTotal), roundOff: f(grand - totals.subTotal), grandTotal: f(grand),
            tips: f(tips), advances: f(advances), retention: f(retention), payable: f(payable), credit: f(credit),
        },
        byCode: [...byCode.values()].map((b) => ({
            code: b.code, percent: b.percent, taxable: f(b.taxable),
            components: [...b.parts.entries()].map(([name, amount]) => ({ name, amount: f(amount) })), cess: f(b.cess),
        })),
    };
}
