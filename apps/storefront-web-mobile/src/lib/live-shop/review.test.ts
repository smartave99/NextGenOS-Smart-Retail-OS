import { describe, expect, it } from "vitest";
import { compare, readReview, reportsMissing, yearComparison } from "./review";
import type { OwnerWeek } from "./types";

// What Smart Retail POS 2.17 sends, byte for byte: the review of the shop PC's own test (OwnerReviewTests), written
// by the same serializer. The name with the long number is masked at the shop before it leaves.
const SENT = `{"version":1,"demo":false,"sentAt":"2026-09-28T09:15:00+05:30","thisWeek":{"from":"2026-09-21","to":"2026-09-27","sales":123456.78,"bills":301,"averageBill":410.16,"profit":19000,"margin":0.19},"weekBefore":{"from":"2026-09-14","to":"2026-09-20","sales":100000,"bills":250,"averageBill":400,"profit":null,"margin":null},"yearBefore":{"from":"2025-09-22","to":"2025-09-28","sales":90000,"bills":240,"averageBill":375,"profit":null,"margin":null},"runningOut":[{"name":"Basmati Rice 5 kg","inHand":4,"perDay":2.46,"daysLeft":1.63},{"name":"Tea 250 g","inHand":0,"perDay":0.2,"daysLeft":0}],"notSelling":[{"name":"Pen (call 98\\u2022\\u2022\\u2022\\u2022\\u2022\\u202210)","inHand":40,"value":200.00}],"reviewedOn":"2026-09-28"}`;

// A quiet demo shop: nothing sold last week, no bills a year before, nothing to decide, not reviewed.
const SENT_QUIET = `{"version":1,"demo":true,"sentAt":"2026-09-28T09:15:00+05:30","thisWeek":{"from":"2026-09-21","to":"2026-09-27","sales":0,"bills":0,"averageBill":0,"profit":null,"margin":null},"weekBefore":{"from":"2026-09-14","to":"2026-09-20","sales":100000,"bills":250,"averageBill":400,"profit":null,"margin":null},"yearBefore":null,"runningOut":[],"notSelling":[],"reviewedOn":null}`;

const week = (over: Partial<OwnerWeek> = {}): OwnerWeek => ({
    from: "2026-09-21", to: "2026-09-27", sales: 100000, bills: 250, averageBill: 400, profit: null, margin: null, ...over,
});

describe("readReview", () => {
    it("reads the review the shop PC sends", () => {
        expect(readReview(JSON.parse(SENT))).toEqual({
            demo: false,
            thisWeek: { from: "2026-09-21", to: "2026-09-27", sales: 123456.78, bills: 301, averageBill: 410.16, profit: 19000, margin: 0.19 },
            weekBefore: { from: "2026-09-14", to: "2026-09-20", sales: 100000, bills: 250, averageBill: 400, profit: null, margin: null },
            yearBefore: { from: "2025-09-22", to: "2025-09-28", sales: 90000, bills: 240, averageBill: 375, profit: null, margin: null },
            runningOut: [
                { name: "Basmati Rice 5 kg", inHand: 4, perDay: 2.46, daysLeft: 1.63 },
                { name: "Tea 250 g", inHand: 0, perDay: 0.2, daysLeft: 0 },
            ],
            notSelling: [{ name: "Pen (call 98••••••10)", inHand: 40, value: 200 }],
            reviewedOn: "2026-09-28",
        });
    });

    it("reads a quiet week: no sales, no year before, nothing to decide, not reviewed", () => {
        const review = readReview(JSON.parse(SENT_QUIET));
        expect(review).toMatchObject({ demo: true, yearBefore: null, runningOut: [], notSelling: [], reviewedOn: null });
        expect(review?.thisWeek).toMatchObject({ sales: 0, bills: 0, averageBill: 0, profit: null, margin: null });
    });

    it("leaves out a year before and products it cannot read, and keeps the rest", () => {
        const data = {
            ...JSON.parse(SENT),
            yearBefore: { from: "2025-13-45", to: "2025-09-28", sales: 1, bills: 1, averageBill: 1 },
            runningOut: [{ name: "Tea", inHand: 2 }, { name: 5, inHand: 1 }, null, "Rice", { name: "Oil" }, { name: "Salt", inHand: "3" }],
            notSelling: [{ name: "Pen", inHand: 1, value: 10 }, { name: "Ink", inHand: 1 }, []],
        };
        const review = readReview(data);
        expect(review?.yearBefore).toBeNull();
        expect(review?.runningOut).toEqual([{ name: "Tea", inHand: 2, perDay: null, daysLeft: null }]);
        expect(review?.notSelling).toEqual([{ name: "Pen", inHand: 1, value: 10 }]);
        expect(review?.thisWeek.sales).toBe(123456.78);
    });

    it("takes a list that is not a list as an empty one", () => {
        const review = readReview({ ...JSON.parse(SENT), runningOut: "none", notSelling: { name: "Pen" } });
        expect(review?.runningOut).toEqual([]);
        expect(review?.notSelling).toEqual([]);
    });

    it("takes a figure that is not a number as not known, and a review day that is not a day as not reviewed", () => {
        const data = JSON.parse(SENT);
        data.thisWeek.profit = "19000";
        data.thisWeek.margin = null;
        data.reviewedOn = "28 Sept";
        const review = readReview(data);
        expect(review?.thisWeek.profit).toBeNull();
        expect(review?.thisWeek.margin).toBeNull();
        expect(review?.reviewedOn).toBeNull();
        expect(readReview({ ...JSON.parse(SENT), reviewedOn: "2026-02-30" })?.reviewedOn).toBeNull();
    });

    it("calls a review unreadable when one of the two weeks it is about cannot be read", () => {
        const good = JSON.parse(SENT);
        const bad: unknown[] = [
            null, undefined, 7, "review", [], {},
            { ...good, thisWeek: undefined },
            { ...good, weekBefore: null },
            { ...good, thisWeek: { ...good.thisWeek, sales: "123" } },
            { ...good, thisWeek: { ...good.thisWeek, bills: null } },
            { ...good, thisWeek: { ...good.thisWeek, averageBill: undefined } },
            { ...good, weekBefore: { ...good.weekBefore, from: "2026-9-14" } },
            { ...good, weekBefore: { ...good.weekBefore, to: "2026-02-30" } },
        ];
        for (const data of bad) expect(readReview(data)).toBeNull();
    });
});

describe("compare", () => {
    it("has nothing to say without anything before", () => {
        expect(compare(500, 0)).toEqual({ kind: "none" });
        expect(compare(500, -1)).toEqual({ kind: "none" });
        expect(compare(500, Number.NaN)).toEqual({ kind: "none" });
        expect(compare(0, 0)).toEqual({ kind: "none" });
    });

    it("says more or less in whole percent, and the same under half a percent", () => {
        expect(compare(123456.78, 100000)).toEqual({ kind: "up", percent: 23 });
        expect(compare(75, 100)).toEqual({ kind: "down", percent: 25 });
        expect(compare(0, 100)).toEqual({ kind: "down", percent: 100 });
        expect(compare(250, 100)).toEqual({ kind: "up", percent: 150 });
        expect(compare(100.4, 100)).toEqual({ kind: "same" });
        expect(compare(99.6, 100)).toEqual({ kind: "same" });
        expect(compare(100, 100)).toEqual({ kind: "same" });
        expect(compare(100.6, 100)).toEqual({ kind: "up", percent: 1 });
        expect(compare(99.4, 100)).toEqual({ kind: "down", percent: 1 });
    });
});

describe("reportsMissing", () => {
    it("knows a project whose script is older than the weekly screens", () => {
        expect(reportsMissing({ code: "PGRST205" })).toBe(true);
        expect(reportsMissing({ code: "42P01" })).toBe(true);
        expect(reportsMissing({}, 404)).toBe(true);
    });

    it("does not take any other trouble for it", () => {
        expect(reportsMissing(null)).toBe(false);
        expect(reportsMissing(undefined, 404)).toBe(false);
        expect(reportsMissing({ code: "PGRST301" }, 401)).toBe(false);
        expect(reportsMissing({ code: "42501" })).toBe(false);
        expect(reportsMissing({}, 0)).toBe(false);
    });
});

describe("yearComparison", () => {
    const year = week({ from: "2025-09-22", to: "2025-09-28", sales: 90000, bills: 240 });

    it("says how last week was against the same week a year before", () => {
        expect(yearComparison(week({ sales: 123456.78 }), year)).toMatch(/^The same week a year before \(22–28 Sept? 2025\): ₹90,000 from 240 bills, so last week was 37% higher\.$/);
        expect(yearComparison(week({ sales: 45000 }), year)).toMatch(/, so last week was 50% lower\.$/);
        expect(yearComparison(week({ sales: 90100 }), year)).toMatch(/, so last week was about the same\.$/);
    });

    it("only gives the year's figures when there is nothing to compare with", () => {
        expect(yearComparison(week(), { ...year, sales: 0, bills: 1 })).toMatch(/: ₹0 from 1 bill\.$/);
    });

    it("says so when the POS has no bills from then", () => {
        expect(yearComparison(week(), null)).toBe("The POS has no bills from the same week a year before, so the week is compared with the week before only.");
    });
});
