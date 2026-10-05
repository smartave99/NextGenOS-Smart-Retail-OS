// Words and numbers for the Live shop section, the way the shop's country writes them (for India: ₹1,23,456 and "6:57 pm").
import type { OwnerDay, OwnerLive } from "./types";
import { LOCALE, CURRENCY } from "@/lib/region/lite";

const money = new Intl.NumberFormat(LOCALE, { style: "currency", currency: CURRENCY.code, maximumFractionDigits: 0 });
const number = new Intl.NumberFormat(LOCALE, { maximumFractionDigits: 2 });
const clock = new Intl.DateTimeFormat(LOCALE, { hour: "numeric", minute: "2-digit" });
const clockSeconds = new Intl.DateTimeFormat(LOCALE, { hour: "numeric", minute: "2-digit", second: "2-digit" });
const dayName = new Intl.DateTimeFormat(LOCALE, { weekday: "short" });
const weekdayName = new Intl.DateTimeFormat(LOCALE, { weekday: "long" });
const short = new Intl.DateTimeFormat(LOCALE, { day: "numeric", month: "short" });
const long = new Intl.DateTimeFormat(LOCALE, { weekday: "long", day: "numeric", month: "long", year: "numeric" });

const exact = new Intl.NumberFormat(LOCALE, { style: "currency", currency: CURRENCY.code, minimumFractionDigits: CURRENCY.decimals, maximumFractionDigits: CURRENCY.decimals });

export const rupees = (value: number | null | undefined) => money.format(Math.round(Number(value) || 0));

/** A price as the shop charges it: ₹155 when whole, ₹99.50 with paise (or the same in the shop's currency). */
export const price = (value: number) => (Number.isInteger(value) ? money : exact).format(value);
export const quantity = (value: number) => number.format(value);

/** "+12%" or "−8%"; "" when there is nothing to compare. */
export const share = (value: number | null | undefined) =>
    value === null || value === undefined ? "" : `${value >= 0 ? "+" : "−"}${Math.round(Math.abs(value) * 100)}%`;

/** 18 as "6 pm". */
export const hourName = (hour: number) => `${hour % 12 === 0 ? 12 : hour % 12} ${hour % 24 < 12 ? "am" : "pm"}`;

/** "18:57", in the shop's own time as the shop PC sends it, as "6:57 pm"; "" when it is not a time. */
export function timeOfDay(text: string | null | undefined): string {
    const match = /^(\d{2}):(\d{2})$/.exec(text ?? "");
    if (!match) return "";
    const hour = Number(match[1]);
    return `${hour % 12 === 0 ? 12 : hour % 12}:${match[2]} ${hour < 12 ? "am" : "pm"}`;
}

/** "2026-09-27" as a local date (no time zone shift). */
export function dateOf(iso: string): Date {
    const [y, m, d] = iso.split("-").map(Number);
    return new Date(y, m - 1, d);
}

export const shortDate = (iso: string) => short.format(dateOf(iso));
export const longDate = (iso: string) => long.format(dateOf(iso));
export const dayShort = (iso: string) => dayName.format(dateOf(iso));
export const weekday = (iso: string) => weekdayName.format(dateOf(iso));
export const clockTime = (when: Date) => clock.format(when);
export const clockTimeSeconds = (when: Date) => clockSeconds.format(when);
export const calendarDate = (when: Date) => short.format(when);

/** "21–27 Sept", or "29 Sept – 5 Oct" when the week crosses a month; with the year (of its last day) when asked. */
export function weekName(from: string, to: string, withYear = false): string {
    const first = dateOf(from);
    const last = dateOf(to);
    const year = withYear ? ` ${last.getFullYear()}` : "";
    return first.getMonth() === last.getMonth()
        ? `${first.getDate()}–${short.format(last)}${year}`
        : `${short.format(first)} – ${short.format(last)}${year}`;
}

/** The shop PC counts as live while it sent within the last 3 minutes. */
export const STALE_AFTER_MS = 3 * 60 * 1000;

export type LiveState =
    | { kind: "waiting"; text: string }
    | { kind: "live"; text: string }
    | { kind: "stale"; text: string };

export function liveState(sentAt: Date | null, now: Date): LiveState {
    if (!sentAt) return { kind: "waiting", text: "Waiting for the shop PC" };
    const age = now.getTime() - sentAt.getTime();
    if (age > STALE_AFTER_MS) {
        return { kind: "stale", text: `Last sent ${clockTime(sentAt)}${age > 86_400_000 ? ", " + calendarDate(sentAt) : ""}` };
    }
    return { kind: "live", text: `Live · ${clockTimeSeconds(sentAt)}` };
}

/** The history with today's latest figures in its last day (the days themselves come a few times an hour). */
export function withToday(days: OwnerDay[], live: OwnerLive | null): OwnerDay[] {
    const today = live?.today;
    if (!today) return days;
    const latest: OwnerDay = {
        day: today.day,
        sales: today.sales,
        bills: today.bills,
        returns: 0,
        hours: (live.hours ?? []).map((h) => ({ hour: h.hour, sales: h.sales, bills: h.bills })),
        top: (live.top ?? []).slice(0, 5),
    };
    const index = days.findIndex((d) => d.day === today.day);
    if (index < 0) return [...days, latest];
    const merged = days.slice();
    merged[index] = { ...days[index], ...latest, returns: days[index].returns };
    return merged;
}

/** ABCDEFGH as ABCD-EFGH. */
export const pairingCode = (code: string) => `${code.slice(0, 4)}-${code.slice(4)}`;
