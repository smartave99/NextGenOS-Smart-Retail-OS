// The Monday review as the shop PC sends it (Smart Retail POS: OwnerReview), read with care: a report from an older or
// newer shop PC, or a damaged one, shows what can be read, or is called unreadable. It never stops the page.
import { quantity, rupees, weekName } from "./format";
import type { OwnerNotSelling, OwnerReview, OwnerRunningOut, OwnerWeek } from "./types";

const DAY = /^(\d{4})-(\d{2})-(\d{2})$/;

const isObject = (value: unknown): value is Record<string, unknown> => typeof value === "object" && value !== null && !Array.isArray(value);
const finite = (value: unknown): value is number => typeof value === "number" && Number.isFinite(value);
const orNull = (value: unknown): number | null => (finite(value) ? value : null);

/** "2026-09-27" when it is a real day, else null (a date the page cannot format would stop it). */
function day(value: unknown): string | null {
    const match = typeof value === "string" ? DAY.exec(value) : null;
    if (!match) return null;
    const [year, month, date] = [Number(match[1]), Number(match[2]), Number(match[3])];
    const real = new Date(year, month - 1, date);
    return real.getFullYear() === year && real.getMonth() === month - 1 && real.getDate() === date ? value as string : null;
}

function readWeek(value: unknown): OwnerWeek | null {
    if (!isObject(value)) return null;
    const from = day(value.from);
    const to = day(value.to);
    if (!from || !to || !finite(value.sales) || !finite(value.bills) || !finite(value.averageBill)) return null;
    return {
        from,
        to,
        sales: value.sales,
        bills: value.bills,
        averageBill: value.averageBill,
        profit: orNull(value.profit),
        margin: orNull(value.margin),
    };
}

function readRunningOut(value: unknown): OwnerRunningOut | null {
    if (!isObject(value) || typeof value.name !== "string" || !finite(value.inHand)) return null;
    return { name: value.name, inHand: value.inHand, perDay: orNull(value.perDay), daysLeft: orNull(value.daysLeft) };
}

function readNotSelling(value: unknown): OwnerNotSelling | null {
    if (!isObject(value) || typeof value.name !== "string" || !finite(value.inHand) || !finite(value.value)) return null;
    return { name: value.name, inHand: value.inHand, value: value.value };
}

/** The entries that can be read; anything else in the list is left out. */
function list<T>(value: unknown, read: (item: unknown) => T | null): T[] {
    return Array.isArray(value) ? value.map(read).filter((item): item is T => item !== null) : [];
}

/**
 * The review in a `shop_reports` row, or null when the two weeks that the screen is about cannot be read. A year
 * before that cannot be read counts as no year before; a product that cannot be read is left out.
 */
export function readReview(data: unknown): OwnerReview | null {
    if (!isObject(data)) return null;
    const thisWeek = readWeek(data.thisWeek);
    const weekBefore = readWeek(data.weekBefore);
    if (!thisWeek || !weekBefore) return null;
    return {
        demo: data.demo === true,
        thisWeek,
        weekBefore,
        yearBefore: readWeek(data.yearBefore),
        runningOut: list(data.runningOut, readRunningOut),
        notSelling: list(data.notSelling, readNotSelling),
        reviewedOn: day(data.reviewedOn),
    };
}

/** How much more or less than before. Under half a percent is the same; with nothing before there is nothing to say. */
export type Change = { kind: "none" } | { kind: "same" } | { kind: "up" | "down"; percent: number };

export function compare(now: number, before: number): Change {
    if (!(before > 0)) return { kind: "none" };
    const growth = (now - before) / before;
    if (Math.abs(growth) < 0.005) return { kind: "same" };
    return { kind: growth > 0 ? "up" : "down", percent: Math.round(Math.abs(growth) * 100) };
}

/** Supabase's answer when the project's script is older than this screen: the reports table is not there. */
const NO_REPORTS = new Set(["42P01", "PGRST205"]);

export const reportsMissing = (error: { code?: string } | null | undefined, status?: number) =>
    Boolean(error) && (NO_REPORTS.has(error?.code ?? "") || status === 404);

/** What last week's sales were against the same week a year before, as a sentence; or why there is no such sentence. */
export function yearComparison(week: OwnerWeek, year: OwnerWeek | null): string {
    if (!year) return "The POS has no bills from the same week a year before, so the week is compared with the week before only.";
    const change = compare(week.sales, year.sales);
    const so =
        change.kind === "none" ? "."
            : change.kind === "same" ? ", so last week was about the same."
                : `, so last week was ${change.percent}% ${change.kind === "up" ? "higher" : "lower"}.`;
    const bills = `${quantity(year.bills)} ${year.bills === 1 ? "bill" : "bills"}`;
    return `The same week a year before (${weekName(year.from, year.to, true)}): ${rupees(year.sales)} from ${bills}${so}`;
}
