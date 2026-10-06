"use client";

import { createContext, useContext, useMemo, type ReactNode } from "react";
import { formatMoney } from "./money";
import type { RegionInfo } from "./server";

const RegionContext = createContext<RegionInfo | null>(null);

export function RegionProvider({ region, children }: { region: RegionInfo; children: ReactNode }) {
    return <RegionContext.Provider value={region}>{children}</RegionContext.Provider>;
}

/** The shop's country, and `money()` that writes an amount the way people in that country write it. */
export function useRegion() {
    const region = useContext(RegionContext);
    if (!region) throw new Error("useRegion needs the RegionProvider (it is in the root layout).");
    return useMemo(() => ({
        ...region,
        /** 1234.5 → "₹1,234.50" (or "1.234,50 €" and so on, by country). */
        money: (amount: number | string) => formatPrice(amount, region.currency),
    }), [region]);
}

export function formatPrice(amount: number | string, currency: RegionInfo["currency"]): string {
    const n = typeof amount === "number" ? amount : Number(amount);
    if (!Number.isFinite(n)) return "";
    // Rounded to the currency's decimals as text, then written out: no floating point reaches the screen.
    return formatMoney(Math.abs(n).toFixed(currency.decimals).replace(/^/, n < 0 ? "-" : ""), currency);
}
