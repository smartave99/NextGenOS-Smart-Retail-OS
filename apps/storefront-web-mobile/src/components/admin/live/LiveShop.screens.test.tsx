import { afterEach, beforeEach, describe, expect, it, vi } from "vitest";
import { fireEvent, render, screen, within } from "@testing-library/react";
import LiveShop from "./LiveShop";

// From the shop reaches the website's server actions and its admin sign-in; these tests are about the other screens.
vi.mock("@/app/actions", () => ({ getCategories: vi.fn(async () => []) }));
vi.mock("@/app/actions/shop-products", () => ({ findShopProduct: vi.fn(), publishShopProduct: vi.fn() }));
vi.mock("@/app/cloudinary-actions", () => ({ uploadToCloudinary: vi.fn() }));
vi.mock("@/context/auth-context", () => ({ useAuth: () => ({ user: null, loading: false }) }));

// The signed-in shop, with a stand-in for the Supabase client that answers each table.
const holder = vi.hoisted(() => ({ db: null as unknown }));
vi.mock("@/lib/live-shop/client", () => ({ liveShopClient: () => holder.db }));

const saved = { ...process.env };

const week = (from: string, to: string, over: Record<string, unknown> = {}) => ({
    from, to, sales: 0, bills: 0, averageBill: 0, profit: null, margin: null, ...over,
});

const live = (demo = false) => ({
    version: 1,
    shop: "Smart Avenue",
    demo,
    sentAt: new Date().toISOString(),
    today: { day: "2026-09-27", sales: 900, bills: 3, credit: 0, lastBillAt: "18:57", vsLastWeek: 0.12, comparedAt: "18:58", lastWeekSales: 800 },
    hours: [{ hour: 18, sales: 900, bills: 3, lastWeekSales: 100 }],
    bills: [{ number: "INV-1", time: "18:57", total: 900, due: 0, later: false }],
    week: [{ day: "2026-09-27", sales: 900, bills: 3 }],
    top: [{ name: "Basmati Rice 5 kg", qty: 1, sales: 650 }],
    lowStock: [],
    fixNow: { count: 0, items: [] },
});

const waitingProduct = (key: string, name: string) => ({
    product_key: key,
    data: { name, description: "Light cooking oil.", price: 155, originalPrice: 175, highlights: [], specifications: [], tags: [], categoryId: "", subcategoryId: "", categoryPath: "", barcode: null, posName: name, code: key },
    state: "waiting",
    photo_kinds: ["white"],
    sent_at: "2026-10-04T10:00:00+00:00",
    decided_at: null,
});

const review = (demo = false) => ({
    version: 1,
    demo,
    sentAt: "2026-09-28T09:15:00+05:30",
    thisWeek: week("2026-09-21", "2026-09-27", { sales: 123456.78, bills: 301, averageBill: 410.16 }),
    weekBefore: week("2026-09-14", "2026-09-20", { sales: 100000, bills: 250, averageBill: 400 }),
    yearBefore: null,
    runningOut: [],
    notSelling: [],
    reviewedOn: null,
});

/** Every table answers as the real one does; the reports table can be left out, as in a project with an older script. */
function fakeSupabase({ demo = false, reportsTable = true, productsTable = true, products = [], devices }: {
    demo?: boolean;
    reportsTable?: boolean;
    productsTable?: boolean;
    products?: unknown[];
    devices?: unknown[];
} = {}) {
    const sentAt = new Date().toISOString();
    const rows: Record<string, unknown[]> = {
        shops: [{ id: "shop-1", name: "Smart Avenue" }],
        shop_devices: devices ?? [{ id: "pc-1", label: "Counter PC", connected_at: sentAt, last_seen_at: sentAt }],
        shop_days: [],
        shop_questions: [],
        shop_products: products,
        shop_product_photos: [],
    };
    const single = (table: string) => {
        if (table === "shop_live") return { data: { data: live(demo), sent_at: sentAt }, error: null, status: 200 };
        if (table === "shop_reports" && !reportsTable) return { data: null, error: { message: "Not Found", code: "PGRST205" }, status: 404 };
        if (table === "shop_reports") return { data: { data: review(demo), sent_at: sentAt }, error: null, status: 200 };
        return { data: null, error: null, status: 200 };
    };
    const from = (table: string) => {
        const query: Record<string, unknown> = {};
        for (const step of ["select", "eq", "gte", "order", "limit"]) query[step] = () => query;
        query.maybeSingle = async () => single(table);
        query.then = (done: (value: unknown) => unknown, fail: (reason: unknown) => unknown) =>
            Promise.resolve(
                table === "shop_products" && !productsTable
                    ? { data: null, error: { message: "Not Found", code: "PGRST205" }, status: 404 }
                    : { data: rows[table] ?? [], error: null },
            ).then(done, fail);
        return query;
    };
    const channel = { on: () => channel, subscribe: () => channel };
    return {
        from,
        channel: () => channel,
        removeChannel: async () => "ok",
        rpc: async () => ({ data: null, error: null }),
        auth: {
            onAuthStateChange: (callback: (event: string, session: unknown) => void) => {
                setTimeout(() => callback("INITIAL_SESSION", { user: { id: "owner" } }), 0);
                return { data: { subscription: { unsubscribe: () => {} } } };
            },
            signOut: async () => ({ error: null }),
            mfa: {
                getAuthenticatorAssuranceLevel: async () => ({ data: { currentLevel: "aal1", nextLevel: "aal1" }, error: null }),
                listFactors: async () => ({ data: { all: [], totp: [] }, error: null }),
            },
        },
    };
}

beforeEach(() => {
    process.env.NEXT_PUBLIC_SUPABASE_URL = "http://127.0.0.1:54321";
    process.env.NEXT_PUBLIC_SUPABASE_PUBLISHABLE_KEY = "sb_publishable_abc";
});

afterEach(() => {
    process.env = { ...saved };
    window.history.replaceState(null, "", "/");
});

describe("LiveShop screens", () => {
    it("opens on Today, with Last week one press away and not shown", async () => {
        holder.db = fakeSupabase();
        render(<LiveShop />);

        expect(await screen.findByTestId("live-sales")).toBeVisible();
        const screens = screen.getByRole("navigation", { name: "Screens" });
        expect(within(screens).getByRole("button", { name: "Today" })).toHaveAttribute("aria-current", "true");
        expect(within(screens).getByRole("button", { name: "Last week" })).not.toHaveAttribute("aria-current");
        expect(await screen.findByTestId("weekly-review")).not.toBeVisible();
        expect(screen.getByRole("heading", { name: "Shop PCs" })).toBeVisible();
        expect(window.location.hash).toBe("");
    });

    it("shows last week when it is pressed, keeps the address for it, and brings Today back", async () => {
        holder.db = fakeSupabase();
        render(<LiveShop />);
        await screen.findByTestId("live-sales");

        fireEvent.click(screen.getByRole("button", { name: "Last week" }));
        expect(await screen.findByRole("heading", { name: /^Last week, 21–27 Sept?$/ })).toBeVisible();
        expect(screen.getByTestId("review-sales")).toHaveTextContent("₹1,23,457");
        expect(screen.getByRole("button", { name: "Last week" })).toHaveAttribute("aria-current", "true");
        expect(screen.getByTestId("live-sales")).not.toBeVisible();
        // The shop PCs and the sign-in security belong to Today; the question box is for both.
        expect(screen.getByRole("heading", { name: "Shop PCs", hidden: true })).not.toBeVisible();
        expect(screen.getByLabelText("Your question")).toBeVisible();
        expect(window.location.hash).toBe("#review");

        fireEvent.click(screen.getByRole("button", { name: "Today" }));
        expect(screen.getByTestId("live-sales")).toBeVisible();
        expect(screen.getByTestId("weekly-review")).not.toBeVisible();
        expect(screen.getByRole("heading", { name: "Shop PCs" })).toBeVisible();
        expect(window.location.hash).toBe("");
    });

    it("opens on Last week when the address says so", async () => {
        window.history.replaceState(null, "", "/admin/live#review");
        holder.db = fakeSupabase();
        render(<LiveShop />);

        expect(await screen.findByRole("heading", { name: /^Last week, 21–27 Sept?$/ })).toBeVisible();
        expect(screen.getByTestId("live-sales")).not.toBeVisible();
        expect(screen.getByRole("button", { name: "Last week" })).toHaveAttribute("aria-current", "true");
    });

    it("says once that the figures are the demo shop's, whichever screen is open", async () => {
        holder.db = fakeSupabase({ demo: true });
        render(<LiveShop />);
        await screen.findByTestId("live-sales");

        fireEvent.click(screen.getByRole("button", { name: "Last week" }));
        await screen.findByTestId("review-sales");
        expect(screen.getAllByText(/These are the demo shop's figures/)).toHaveLength(1);
    });

    it("keeps the live figures when the project's script is older than the weekly review", async () => {
        holder.db = fakeSupabase({ reportsTable: false });
        render(<LiveShop />);

        expect(await screen.findByTestId("live-sales")).toHaveTextContent("₹900");
        fireEvent.click(screen.getByRole("button", { name: "Last week" }));
        expect(await screen.findByRole("heading", { name: "The weekly review needs the updated script" })).toBeVisible();
        expect(screen.queryByRole("alert")).toBeNull();
        fireEvent.click(screen.getByRole("button", { name: "Today" }));
        expect(screen.getByTestId("live-sales")).toBeVisible();
    });

    it("counts the products waiting for the owner on From the shop, and shows them there", async () => {
        holder.db = fakeSupabase({ products: [waitingProduct("6", "Sunflower Oil 1 L"), waitingProduct("9", "Mustard Oil 500 ml")] });
        render(<LiveShop />);
        await screen.findByTestId("live-sales");

        const tab = await screen.findByRole("button", { name: "From the shop, 2 waiting for you" });
        expect(await screen.findByTestId("from-the-shop")).not.toBeVisible();

        fireEvent.click(tab);
        expect(await screen.findByRole("heading", { name: "Waiting for you (2)" })).toBeVisible();
        expect(screen.getByRole("article", { name: "Sunflower Oil 1 L" })).toBeVisible();
        expect(screen.getByTestId("live-sales")).not.toBeVisible();
        expect(tab).toHaveAttribute("aria-current", "true");
        expect(window.location.hash).toBe("#shop");

        fireEvent.click(screen.getByRole("button", { name: "Today" }));
        expect(screen.getByTestId("live-sales")).toBeVisible();
        expect(screen.getByTestId("from-the-shop")).not.toBeVisible();
    });

    it("opens on From the shop when the address says so", async () => {
        window.history.replaceState(null, "", "/admin/live#shop");
        holder.db = fakeSupabase({ products: [waitingProduct("6", "Sunflower Oil 1 L")] });
        render(<LiveShop />);

        expect(await screen.findByRole("heading", { name: "Waiting for you (1)" })).toBeVisible();
        expect(screen.getByTestId("live-sales")).not.toBeVisible();
    });

    it("keeps the other screens when the project's script is older than the waiting list", async () => {
        holder.db = fakeSupabase({ productsTable: false });
        render(<LiveShop />);

        expect(await screen.findByTestId("live-sales")).toHaveTextContent("₹900");
        expect(screen.getByRole("button", { name: "From the shop" })).toBeInTheDocument();
        fireEvent.click(screen.getByRole("button", { name: "From the shop" }));
        expect(await screen.findByRole("heading", { name: "This needs the updated script" })).toBeVisible();
        expect(screen.queryByRole("alert")).toBeNull();
        fireEvent.click(screen.getByRole("button", { name: "Today" }));
        expect(screen.getByTestId("live-sales")).toBeVisible();
    });

    it("marks the main PC under Shop PCs when the shop has more than one", async () => {
        const at = new Date().toISOString();
        holder.db = fakeSupabase({
            devices: [
                { id: "pc-1", label: "Mother PC", connected_at: at, last_seen_at: at, is_main: true },
                { id: "pc-2", label: "Counter 2", connected_at: at, last_seen_at: at, is_main: false },
            ],
        });
        render(<LiveShop />);

        const pcs = (await screen.findByRole("heading", { name: "Shop PCs" })).closest("section")!;
        const mother = (await within(pcs).findByText("Mother PC")).closest("li")!;
        const counter = (await within(pcs).findByText("Counter 2")).closest("li")!;
        expect(within(mother).getByText("Main PC")).toBeInTheDocument();
        expect(within(counter).getByText("Counter")).toBeInTheDocument();
    });

    it("marks no PC when there is one, or when the project's script does not say which is the main one", async () => {
        const at = new Date().toISOString();
        holder.db = fakeSupabase({ devices: [{ id: "pc-1", label: "Mother PC", connected_at: at, last_seen_at: at, is_main: true }] });
        const { unmount } = render(<LiveShop />);
        const alone = (await screen.findByRole("heading", { name: "Shop PCs" })).closest("section")!;
        await within(alone).findByText("Mother PC");
        expect(within(alone).queryByText("Main PC")).toBeNull();
        unmount();

        holder.db = fakeSupabase({
            devices: [
                { id: "pc-1", label: "Mother PC", connected_at: at, last_seen_at: at },
                { id: "pc-2", label: "Counter 2", connected_at: at, last_seen_at: at },
            ],
        });
        render(<LiveShop />);
        const older = (await screen.findByRole("heading", { name: "Shop PCs" })).closest("section")!;
        await within(older).findByText("Counter 2");
        expect(within(older).queryByText("Main PC")).toBeNull();
        expect(within(older).queryByText("Counter")).toBeNull();
    });
});
