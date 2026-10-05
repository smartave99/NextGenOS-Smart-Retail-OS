import { describe, expect, it, vi } from "vitest";
import { fireEvent, render, screen, waitFor, within } from "@testing-library/react";
import type { SupabaseClient } from "@supabase/supabase-js";
import type { ShopQuestion } from "@/lib/live-shop/types";
import AskShop from "./AskShop";

const shop = { id: "shop-1", name: "Smart Avenue" };

/** A stand-in for the Supabase client: the questions to list, and what asking returns. */
function fakeDb(
    questions: ShopQuestion[],
    asked: { error: { message: string; code?: string } | null } = { error: null },
    reads: { error: { message: string; code?: string } | null }[] = [],
) {
    const query = {
        select: () => query,
        eq: () => query,
        order: () => query,
        limit: async () => {
            const read = reads.shift();
            return read?.error ? { data: null, error: read.error } : { data: questions, error: null };
        },
    };
    const channel = { on: () => channel, subscribe: () => channel };
    const db = {
        from: vi.fn(() => query),
        rpc: vi.fn(async () => ({ data: "q-new", ...asked })),
        channel: vi.fn(() => channel),
        removeChannel: vi.fn(async () => "ok"),
    };
    return db;
}

const answered: ShopQuestion = {
    id: "q-1",
    question: "Which products sold most this week?",
    status: "answered",
    asked_at: "2026-09-27T12:30:00Z",
    answered_at: "2026-09-27T12:30:40Z",
    answer: {
        text: "## This week\nThe best seller is **Sunflower Oil 1 L**.\n\n- Keep it near the counter\n- <b>not markup</b>",
        columns: ["Product", "Qty", "Sales"],
        rows: [["Sunflower Oil 1 L", 42, 6258.5], ["Tea 250 g", 30, 3600]],
        totalRows: 12,
        source: "Codex CLI · 4.2 s",
    },
};

describe("AskShop", () => {
    it("shows the shop's answers as text, with their table", async () => {
        const db = fakeDb([answered]);
        render(<AskShop db={db as unknown as SupabaseClient} shop={shop} pcLive />);
        const answer = await screen.findByTestId("shop-answer");
        expect(within(answer).getByRole("heading", { name: "This week" })).toBeInTheDocument();
        expect(within(answer).getByText("Sunflower Oil 1 L", { selector: "strong" })).toBeInTheDocument();
        expect(within(answer).getByText("<b>not markup</b>")).toBeInTheDocument();
        expect(answer.querySelector("b")).toBeNull();
        expect(within(answer).getByRole("cell", { name: "6,258.5" })).toHaveClass("text-right");
        expect(within(answer).getByText(/Showing the first 2 of 12 rows\. Codex CLI · 4\.2 s/)).toBeInTheDocument();
        expect(db.channel).toHaveBeenCalledWith("shop-questions-shop-1");
    });

    it("asks with the question trimmed and clears the box", async () => {
        const db = fakeDb([]);
        render(<AskShop db={db as unknown as SupabaseClient} shop={shop} pcLive />);
        const box = screen.getByLabelText("Your question");
        fireEvent.change(box, { target: { value: "  How were sales today?  " } });
        fireEvent.keyDown(box, { key: "Enter" });
        await waitFor(() => expect(db.rpc).toHaveBeenCalledWith("ask_the_shop", { p_shop: "shop-1", p_question: "How were sales today?" }));
        await waitFor(() => expect(box).toHaveValue(""));
    });

    it("keeps the question and says why when it cannot be asked", async () => {
        const db = fakeDb([], { error: { message: "That is 30 questions this hour. Ask again a little later." } });
        render(<AskShop db={db as unknown as SupabaseClient} shop={shop} pcLive={false} />);
        expect(screen.getByText(/Questions wait, and are answered when it is back on/)).toBeInTheDocument();
        const box = screen.getByLabelText("Your question");
        fireEvent.change(box, { target: { value: "One more" } });
        fireEvent.click(screen.getByRole("button", { name: "Ask" }));
        expect(await screen.findByRole("alert")).toHaveTextContent("30 questions this hour");
        expect(box).toHaveValue("One more");
    });

    it("keeps a question typed while the last one was being sent", async () => {
        let finish: (value: { data: string; error: null }) => void = () => {};
        const db = fakeDb([]);
        db.rpc = vi.fn(() => new Promise((done) => { finish = done; })) as unknown as typeof db.rpc;
        render(<AskShop db={db as unknown as SupabaseClient} shop={shop} pcLive />);
        const box = screen.getByLabelText("Your question");
        fireEvent.change(box, { target: { value: "How were sales today?" } });
        fireEvent.keyDown(box, { key: "Enter" });
        fireEvent.change(box, { target: { value: "And yesterday?" } });
        finish({ data: "q-new", error: null });
        await waitFor(() => expect(db.rpc).toHaveBeenCalled());
        await new Promise((r) => setTimeout(r, 0));
        expect(box).toHaveValue("And yesterday?");
    });

    it("stops showing a reading problem once the questions can be read again", async () => {
        const db = fakeDb([], { error: null }, [{ error: { message: "Failed to fetch" } }]);
        render(<AskShop db={db as unknown as SupabaseClient} shop={shop} pcLive />);
        expect(await screen.findByText("Failed to fetch")).toBeInTheDocument();
        const box = screen.getByLabelText("Your question");
        fireEvent.change(box, { target: { value: "How were sales today?" } });
        fireEvent.click(screen.getByRole("button", { name: "Ask" }));
        await waitFor(() => expect(screen.queryByText("Failed to fetch")).toBeNull());
    });

    it("says to run the updated script when the project has no questions yet", async () => {
        const db = fakeDb([], { error: null }, [{ error: { message: "Could not find the table 'public.shop_questions' in the schema cache", code: "PGRST205" } }]);
        render(<AskShop db={db as unknown as SupabaseClient} shop={shop} pcLive />);
        expect(await screen.findByText(/run supabase-owner-view\.sql from Smart Retail POS 2\.2\.0/)).toBeInTheDocument();
        expect(screen.queryByText(/schema cache/)).toBeNull();
    });

    it("says when a question is still waiting", async () => {
        const db = fakeDb([{ ...answered, id: "q-2", status: "waiting", answer: null, answered_at: null }]);
        render(<AskShop db={db as unknown as SupabaseClient} shop={shop} pcLive />);
        expect(await screen.findByText("Waiting for the shop PC")).toBeInTheDocument();
        expect(screen.queryByTestId("shop-answer")).toBeNull();
    });
});
