import type { CurrencyInfo } from "./types";

/**
 * Money as exact text (country-packs/SPEC.md): amounts are never floating point numbers. "199.50" with two decimals is 19950n.
 * Kept in step with libs/dotnet/NextGenOS.Tax/MoneyText.cs: the vectors prove they agree.
 */
export function parseDecimal(text: string, decimals: number): bigint {
    const s = String(text ?? "").trim();
    const m = /^(\d+)(?:\.(\d+))?$/.exec(s);
    if (!m) throw new Error(`"${text}" is not an amount.`);
    const frac = m[2] ?? "";
    if (frac.length > decimals) throw new Error(`"${text}" has more than ${decimals} decimals.`);
    return BigInt(m[1] + frac.padEnd(decimals, "0"));
}

export function formatMinor(n: bigint, decimals: number): string {
    const negative = n < 0n;
    const digits = (negative ? -n : n).toString().padStart(decimals + 1, "0");
    const body = decimals === 0 ? digits : `${digits.slice(0, -decimals)}.${digits.slice(-decimals)}`;
    return negative ? `-${body}` : body;
}

/** The amount as a person reads it in this currency: "₹12,34,567.50", "1.234,50 €", "-$5.00". */
export function formatMoney(amount: string, currency: CurrencyInfo): string {
    const text = String(amount).trim();
    const negative = text.startsWith("-");
    const minor = parseDecimal(negative ? text.slice(1) : text, currency.decimals);
    const [whole, frac = ""] = formatMinor(minor, currency.decimals).split(".");
    const size = currency.grouping === "indian" ? 2 : 3;
    let grouped = whole;
    if (currency.grouping !== "none" && whole.length > 3) {
        const parts: string[] = [];
        let head = whole.slice(0, -3);
        while (head.length > size) {
            parts.unshift(head.slice(-size));
            head = head.slice(0, -size);
        }
        if (head) parts.unshift(head);
        parts.push(whole.slice(-3));
        grouped = parts.join(currency.groupSeparator);
    }
    const number = frac ? grouped + currency.decimalSeparator + frac : grouped;
    const space = currency.symbolSpace ? " " : "";
    const shown = currency.symbolPosition === "after" ? number + space + currency.symbol : currency.symbol + space + number;
    return negative && minor !== 0n ? `-${shown}` : shown;
}
