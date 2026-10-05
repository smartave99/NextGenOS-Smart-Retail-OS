import { describe, expect, it } from "vitest";
import { hourName, liveState, pairingCode, price, rupees, share, timeOfDay, weekName, withToday } from "./format";
import type { OwnerDay, OwnerLive } from "./types";

describe("format", () => {
    it("writes rupees the Indian way, whole", () => {
        expect(rupees(123456.4)).toBe("₹1,23,456");
        expect(rupees(null)).toBe("₹0");
    });

    it("writes a price whole, or with paise when it has them", () => {
        expect(price(155)).toBe("₹155");
        expect(price(99.5)).toBe("₹99.50");
        expect(price(1234567.25)).toBe("₹12,34,567.25");
    });

    it("writes a change against last week as a share", () => {
        expect(share(0.123)).toBe("+12%");
        expect(share(-0.08)).toBe("−8%");
        expect(share(null)).toBe("");
    });

    it("writes hours and the shop PC's times as the shop reads them", () => {
        expect([hourName(0), hourName(9), hourName(12), hourName(18)]).toEqual(["12 am", "9 am", "12 pm", "6 pm"]);
        expect(timeOfDay("18:57")).toBe("6:57 pm");
        expect(timeOfDay("00:05")).toBe("12:05 am");
        expect(timeOfDay("12:30")).toBe("12:30 pm");
        expect(timeOfDay(null)).toBe("");
        expect(timeOfDay("7 pm")).toBe("");
    });

    it("shows a code as ABCD-EFGH", () => {
        expect(pairingCode("ABCDEFGH")).toBe("ABCD-EFGH");
    });

    it("names a week by its days, with the month once unless the week crosses one", () => {
        expect(weekName("2026-09-21", "2026-09-27")).toMatch(/^21–27 Sept?$/);
        expect(weekName("2026-09-21", "2026-09-27", true)).toMatch(/^21–27 Sept? 2026$/);
        expect(weekName("2026-09-28", "2026-10-04")).toMatch(/^28 Sept? – 4 Oct$/);
        expect(weekName("2026-12-28", "2027-01-03", true)).toBe("28 Dec – 3 Jan 2027");
    });
});

describe("liveState", () => {
    const now = new Date(2026, 8, 27, 18, 0, 0);

    it("is live while the shop PC sent within 3 minutes", () => {
        expect(liveState(null, now)).toEqual({ kind: "waiting", text: "Waiting for the shop PC" });
        const live = liveState(new Date(now.getTime() - 30_000), now);
        expect(live.kind).toBe("live");
        expect(live.text).toMatch(/^Live · 5:59:30\s?pm$/i);
    });

    it("says when the shop PC last sent, with the date after a day", () => {
        const stale = liveState(new Date(now.getTime() - 10 * 60_000), now);
        expect(stale.kind).toBe("stale");
        expect(stale.text).toMatch(/^Last sent 5:50\s?pm$/i);
        expect(liveState(new Date(2026, 8, 25, 9, 15), now).text).toMatch(/^Last sent 9:15\s?am, 25 Sept?$/i);
    });
});

describe("withToday", () => {
    const live = {
        today: { day: "2026-09-27", sales: 900, bills: 3, credit: 0, lastBillAt: "18:57", vsLastWeek: null, comparedAt: null, lastWeekSales: 0 },
        hours: [{ hour: 18, sales: 900, bills: 3, lastWeekSales: 100 }],
        top: [{ name: "Basmati Rice 5 kg", qty: 1, sales: 650 }],
    } as unknown as OwnerLive;
    const day = (d: string, sales: number, returns = 0): OwnerDay => ({ day: d, sales, bills: 1, returns, hours: [], top: [] });

    it("puts today's latest figures in the history's last day, keeping its returns", () => {
        const merged = withToday([day("2026-09-26", 500), day("2026-09-27", 300, 40)], live);
        expect(merged.map((d) => [d.day, d.sales, d.returns])).toEqual([["2026-09-26", 500, 0], ["2026-09-27", 900, 40]]);
        expect(merged[1].hours).toEqual([{ hour: 18, sales: 900, bills: 3 }]);
        expect(merged[1].top[0].name).toBe("Basmati Rice 5 kg");
    });

    it("adds today when the history does not have it yet, and leaves the history alone without figures", () => {
        expect(withToday([day("2026-09-26", 500)], live).map((d) => d.day)).toEqual(["2026-09-26", "2026-09-27"]);
        const days = [day("2026-09-26", 500)];
        expect(withToday(days, null)).toBe(days);
    });
});
