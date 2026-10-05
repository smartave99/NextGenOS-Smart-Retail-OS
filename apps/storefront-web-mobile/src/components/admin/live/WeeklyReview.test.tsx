import { afterEach, describe, expect, it, vi } from "vitest";
import { act, fireEvent, render, screen, waitFor, within } from "@testing-library/react";
import type { SupabaseClient } from "@supabase/supabase-js";
import WeeklyReview from "./WeeklyReview";

const shop = { id: "shop-1", name: "Smart Avenue" };

const week = (from: string, to: string, over: Record<string, unknown> = {}) => ({
    from, to, sales: 0, bills: 0, averageBill: 0, profit: null, margin: null, ...over,
});

/** The review as the shop PC sends it (see review.test.ts for the shop PC's own bytes). */
const reviewData = (over: Record<string, unknown> = {}) => ({
    version: 1,
    demo: false,
    sentAt: "2026-09-28T09:15:00+05:30",
    thisWeek: week("2026-09-21", "2026-09-27", { sales: 123456.78, bills: 301, averageBill: 410.16, profit: 19000, margin: 0.19 }),
    weekBefore: week("2026-09-14", "2026-09-20", { sales: 100000, bills: 250, averageBill: 400 }),
    yearBefore: week("2025-09-22", "2025-09-28", { sales: 90000, bills: 240, averageBill: 375 }),
    runningOut: [
        { name: "Basmati Rice 5 kg", inHand: 4, perDay: 2.46, daysLeft: 1.63 },
        { name: "Tea 250 g", inHand: 0, perDay: 0.2, daysLeft: 0 },
    ],
    notSelling: [{ name: "Pen", inHand: 40, value: 200 }],
    reviewedOn: "2026-09-28",
    ...over,
});

const row = (data: unknown = reviewData(), sentAt = new Date()) => ({ data, sent_at: sentAt.toISOString() });

interface Read { row?: { data: unknown; sent_at: string } | null; error?: { message: string; code?: string }; status?: number }

/** A stand-in for the Supabase client: what each look at the reports returns (the last one repeats), and the channel. */
function fakeDb(...reads: Read[]) {
    const queue = [...reads];
    const query = {
        select: vi.fn(() => query),
        eq: vi.fn(() => query),
        maybeSingle: vi.fn(async () => {
            const read = queue.length > 1 ? queue.shift()! : queue[0];
            return read.error
                ? { data: null, error: read.error, status: read.status ?? 400 }
                : { data: read.row ?? null, error: null, status: 200 };
        }),
    };
    let changed: () => void = () => {};
    const channel = {
        on: vi.fn((_type: string, _filter: unknown, callback: () => void) => {
            changed = callback;
            return channel;
        }),
        subscribe: vi.fn(() => channel),
    };
    const from = vi.fn(() => query);
    const db = { from, channel: vi.fn(() => channel), removeChannel: vi.fn(async () => "ok") };
    return { db: db as unknown as SupabaseClient, raw: db, query, channel, change: () => act(() => changed()) };
}

function show(db: SupabaseClient, liveDemo = false) {
    return render(<WeeklyReview db={db} shop={shop} liveDemo={liveDemo} />);
}

afterEach(() => {
    vi.useRealTimers();
});

describe("WeeklyReview", () => {
    it("shows last week against the week before, with the profit", async () => {
        const { db } = fakeDb({ row: row() });
        show(db);

        expect(await screen.findByRole("heading", { name: /^Last week, 21–27 Sept?$/ })).toBeInTheDocument();
        const card = (id: string) => screen.getByTestId(id).parentElement!;
        expect(card("review-sales")).toHaveTextContent("Sales₹1,23,457+23% vs the week before (₹1,00,000)");
        expect(card("review-bills")).toHaveTextContent("Bills301+20% vs the week before (250)");
        expect(card("review-average")).toHaveTextContent("Average bill₹410+3% vs the week before (₹400)");
        expect(card("review-profit")).toHaveTextContent("Profit before GST₹19,00019% margin");
        expect(screen.getByText("Reviewed on 28 Sept")).toBeInTheDocument();
        expect(screen.getByTestId("review-year")).toHaveTextContent(/^The same week a year before \(22–28 Sept? 2025\): ₹90,000 from 240 bills, so last week was 37% higher\.$/);
    });

    it("colours more green and less red, and says the same when it is", async () => {
        const data = reviewData({
            thisWeek: week("2026-09-21", "2026-09-27", { sales: 80000, bills: 250, averageBill: 320 }),
        });
        const { db } = fakeDb({ row: row(data) });
        show(db);

        await screen.findByTestId("review-sales");
        const delta = (id: string) => within(screen.getByTestId(id).parentElement!).getByText(/vs the week before/).parentElement!;
        expect(delta("review-sales")).toHaveTextContent("−20% vs the week before (₹1,00,000)");
        expect(delta("review-sales")).toHaveClass("text-red-600");
        expect(delta("review-bills")).toHaveTextContent("Same vs the week before (250)");
        expect(delta("review-bills")).toHaveClass("text-brand-gray");
        expect(delta("review-average")).toHaveTextContent("−20% vs the week before (₹400)");
    });

    it("lists the products running out and the ones not selling", async () => {
        const { db } = fakeDb({ row: row() });
        show(db);

        const running = await screen.findByTestId("review-running-out");
        expect(within(running).getAllByRole("listitem")).toHaveLength(2);
        expect(within(running).getByText("Basmati Rice 5 kg")).toBeInTheDocument();
        expect(within(running).getByText("sells about 2.46 a day")).toBeInTheDocument();
        expect(within(running).getByText("4 left")).toBeInTheDocument();
        expect(within(running).getByText("Out of stock")).toBeInTheDocument();
        const stuck = screen.getByTestId("review-not-selling");
        expect(within(stuck).getByText("Pen")).toBeInTheDocument();
        expect(within(stuck).getByText("40 in stock")).toBeInTheDocument();
        expect(within(stuck).getByText("₹200 tied up")).toBeInTheDocument();
    });

    it("says so when nothing is running out and nothing is stuck", async () => {
        const { db } = fakeDb({ row: row(reviewData({ runningOut: [], notSelling: [] })) });
        show(db);

        expect(await screen.findByText("Nothing is running out.")).toBeInTheDocument();
        expect(screen.getByText("Nothing in stock has gone 8 weeks unsold.")).toBeInTheDocument();
    });

    it("shows product names as text, never as markup", async () => {
        const { db } = fakeDb({ row: row(reviewData({ runningOut: [{ name: "<b>Tea</b>", inHand: 1, perDay: null, daysLeft: null }] })) });
        show(db);

        const running = await screen.findByTestId("review-running-out");
        expect(within(running).getByText("<b>Tea</b>")).toBeInTheDocument();
        expect(running.querySelector("b")).toBeNull();
        expect(within(running).queryByText(/sells about/)).toBeNull();
    });

    it("says when the week has not been reviewed at the shop yet", async () => {
        const { db } = fakeDb({ row: row(reviewData({ reviewedOn: null })) });
        show(db);

        const pill = await screen.findByText("Not reviewed yet");
        expect(pill).toHaveAttribute("title", expect.stringContaining("mark the week as reviewed"));
        expect(screen.queryByText(/^Reviewed on/)).toBeNull();
    });

    it("says so when no purchase price is known for the profit", async () => {
        const data = reviewData({ thisWeek: week("2026-09-21", "2026-09-27", { sales: 5000, bills: 10, averageBill: 500 }) });
        const { db } = fakeDb({ row: row(data) });
        show(db);

        const profit = await screen.findByTestId("review-profit");
        expect(profit).toHaveTextContent("–");
        expect(profit.parentElement).toHaveTextContent("No purchase prices recorded");
    });

    it("compares with the week before only when the POS has no bills from a year before", async () => {
        const { db } = fakeDb({ row: row(reviewData({ yearBefore: null })) });
        show(db);

        expect(await screen.findByTestId("review-year")).toHaveTextContent("The POS has no bills from the same week a year before, so the week is compared with the week before only.");
    });

    it("has nothing to compare with when the week before had no sales", async () => {
        const { db } = fakeDb({ row: row(reviewData({ weekBefore: week("2026-09-14", "2026-09-20") })) });
        show(db);

        await screen.findByTestId("review-sales");
        expect(screen.getAllByText("Nothing to compare with the week before")).toHaveLength(3);
    });

    it("shows the demo note only when the live figures above do not already say so", async () => {
        const { db } = fakeDb({ row: row(reviewData({ demo: true })) });
        const first = show(db);
        expect(await screen.findByText(/These are the demo shop's figures/)).toBeInTheDocument();
        first.unmount();

        show(fakeDb({ row: row(reviewData({ demo: true })) }).db, true);
        await screen.findByTestId("review-sales");
        expect(screen.queryByText(/These are the demo shop's figures/)).toBeNull();
    });

    it("says when it was sent, and the day too when it is old", async () => {
        const fresh = fakeDb({ row: row() });
        const first = show(fresh.db);
        expect(await screen.findByText(/^Sent at .+\. The rules only suggest\./)).toBeInTheDocument();
        expect(screen.getByText(/Monday review on the shop PC\.$/)).toBeInTheDocument();
        first.unmount();

        show(fakeDb({ row: row(reviewData(), new Date(Date.now() - 5 * 3600_000)) }).db);
        expect(await screen.findByText(/^Last sent .+, \d{1,2} \w+\. The rules only suggest\./)).toBeInTheDocument();
    });

    it("reads only this shop's review, and nothing else of the database", async () => {
        const { db, raw, query } = fakeDb({ row: row() });
        show(db);

        await screen.findByTestId("review-sales");
        expect(raw.from).toHaveBeenCalledWith("shop_reports");
        expect(query.select).toHaveBeenCalledWith("data, sent_at");
        expect(query.eq).toHaveBeenCalledWith("shop_id", "shop-1");
        expect(query.eq).toHaveBeenCalledWith("kind", "review");
    });
});

describe("WeeklyReview without a review", () => {
    it("tells the owner who sends it when none has come yet", async () => {
        const { db } = fakeDb({ row: null });
        show(db);

        expect(await screen.findByRole("heading", { name: "No review yet" })).toBeInTheDocument();
        expect(screen.getByText(/once an hour, from Smart Retail POS 2\.17\.0 or later/)).toBeInTheDocument();
    });

    it("says to run the updated script when the project has no reports yet, and looks again when asked", async () => {
        const { db, query } = fakeDb(
            { error: { message: "Could not find the table 'public.shop_reports' in the schema cache", code: "PGRST205" }, status: 404 },
            { row: row() },
        );
        show(db);

        expect(await screen.findByRole("heading", { name: "The weekly review needs the updated script" })).toBeInTheDocument();
        expect(screen.getByText(/Run the latest supabase-owner-view\.sql .* once more; running it again is safe/)).toBeInTheDocument();
        expect(screen.queryByText(/schema cache/)).toBeNull();
        expect(screen.queryByRole("alert")).toBeNull();

        fireEvent.click(screen.getByRole("button", { name: "Check again" }));
        expect(await screen.findByTestId("review-sales")).toHaveTextContent("₹1,23,457");
        expect(query.maybeSingle).toHaveBeenCalledTimes(2);
        expect(screen.queryByRole("heading", { name: "The weekly review needs the updated script" })).toBeNull();
    });

    it("takes a 404 for a project without the reports table, whatever its code", async () => {
        const { db } = fakeDb({ error: { message: "Not Found" }, status: 404 });
        show(db);

        expect(await screen.findByRole("heading", { name: "The weekly review needs the updated script" })).toBeInTheDocument();
    });

    it("says when the latest review cannot be read, instead of stopping the page", async () => {
        const { db } = fakeDb({ row: row({ version: 9, somethingNew: true }) });
        show(db);

        expect(await screen.findByRole("heading", { name: "The latest review could not be read" })).toBeInTheDocument();
        expect(screen.getByRole("button", { name: "Check again" })).toBeInTheDocument();
    });

    it("shows what went wrong with the look, and keeps the last review on show", async () => {
        const { db, change } = fakeDb({ row: row() }, { error: { message: "Failed to fetch" } }, { row: row() });
        show(db);
        await screen.findByTestId("review-sales");

        change();
        expect(await screen.findByRole("alert")).toHaveTextContent("Failed to fetch");
        expect(screen.getByTestId("review-sales")).toHaveTextContent("₹1,23,457");

        change();
        await waitFor(() => expect(screen.queryByRole("alert")).toBeNull());
    });
});

describe("WeeklyReview staying up to date", () => {
    it("listens on a channel of its own and shows the new review the moment the shop PC sends it", async () => {
        const next = reviewData({ thisWeek: week("2026-09-28", "2026-10-04", { sales: 50000, bills: 100, averageBill: 500 }) });
        const { db, raw, channel, change } = fakeDb({ row: row() }, { row: row(next) });
        const view = show(db);
        await screen.findByRole("heading", { name: /^Last week, 21–27 Sept?$/ });

        expect(raw.channel).toHaveBeenCalledWith("shop-reports-shop-1");
        expect(channel.on).toHaveBeenCalledWith(
            "postgres_changes",
            { event: "*", schema: "public", table: "shop_reports", filter: "shop_id=eq.shop-1" },
            expect.any(Function),
        );
        expect(channel.subscribe).toHaveBeenCalled();

        change();
        expect(await screen.findByRole("heading", { name: /^Last week, 28 Sept? – 4 Oct$/ })).toBeInTheDocument();

        view.unmount();
        expect(raw.removeChannel).toHaveBeenCalledWith(channel);
    });

    it("looks again every five minutes, but not while the project has no reports", async () => {
        vi.useFakeTimers({ toFake: ["setInterval", "clearInterval"] });
        const kept = fakeDb({ row: row() });
        const first = show(kept.db);
        await screen.findByTestId("review-sales");
        expect(kept.query.maybeSingle).toHaveBeenCalledTimes(1);

        await act(async () => {
            vi.advanceTimersByTime(5 * 60_000);
        });
        expect(kept.query.maybeSingle).toHaveBeenCalledTimes(2);
        first.unmount();

        const missing = fakeDb({ error: { message: "gone", code: "PGRST205" }, status: 404 });
        show(missing.db);
        await screen.findByRole("heading", { name: "The weekly review needs the updated script" });
        await act(async () => {
            vi.advanceTimersByTime(15 * 60_000);
        });
        expect(missing.query.maybeSingle).toHaveBeenCalledTimes(1);
    });
});
