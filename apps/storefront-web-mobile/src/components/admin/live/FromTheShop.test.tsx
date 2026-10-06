import { afterEach, beforeEach, describe, expect, it, vi } from "vitest";
import { act, fireEvent, render, screen, waitFor, within } from "@testing-library/react";
import type { SupabaseClient } from "@supabase/supabase-js";

const mocks = vi.hoisted(() => ({
    getCategories: vi.fn(),
    uploadToCloudinary: vi.fn(),
    findShopProduct: vi.fn(),
    publishShopProduct: vi.fn(),
    user: { current: { uid: "owner" } as unknown },
}));

vi.mock("@/app/actions", () => ({ getCategories: mocks.getCategories }));
vi.mock("@/app/cloudinary-actions", () => ({ uploadToCloudinary: mocks.uploadToCloudinary }));
vi.mock("@/app/actions/shop-products", () => ({ findShopProduct: mocks.findShopProduct, publishShopProduct: mocks.publishShopProduct }));
vi.mock("@/context/auth-context", () => ({ useAuth: () => ({ user: mocks.user.current, loading: false }) }));

import FromTheShop from "./FromTheShop";

const SHOP = { id: "5b8f1a0e-1111-4222-8333-944455556666", name: "Demo Mart 99" };

const WEBSITE_CATEGORIES = [
    { id: "c-groc", name: "Grocery", parentId: null },
    { id: "c-oils", name: "Oils & Ghee", parentId: null },
    { id: "c-must", name: "Mustard Oil", parentId: "c-oils" },
    { id: "c-sun", name: "Sunflower Oil", parentId: "c-oils" },
];

const offer = (over: Record<string, unknown> = {}) => ({
    name: "Sunflower Oil 1 L Bottle",
    description: "Light, golden cooking oil.\n\nGood for frying.",
    price: 155,
    originalPrice: 175,
    highlights: ["Light on the stomach", "Good for frying"],
    specifications: [{ key: "Volume", value: "1 L" }],
    tags: ["oil", "cooking"],
    categoryId: "c-oils",
    subcategoryId: "c-sun",
    categoryPath: "Oils & Ghee › Sunflower Oil",
    barcode: "8901234567890",
    posName: "Sunflower Oil 1 L",
    code: "1512",
    ...over,
});

const row = (key: string, over: Record<string, unknown> = {}) => ({
    product_key: key,
    data: offer(),
    state: "waiting",
    photo_kinds: ["white", "in-use"],
    sent_at: "2026-10-04T10:00:00+00:00",
    decided_at: null,
    ...over,
});

const photo = (key: string, kind: string, over: Record<string, unknown> = {}) => ({ product_key: key, kind, mime: "image/jpeg", content: "A".repeat(200), ...over });

type Failure = { code?: string; message: string; status?: number };

/** A stand-in for the Supabase client: each table answers its rows (filtered as asked), and the calls to functions are kept. */
function fakeDb({ products = [row("6")], photos = [photo("6", "white"), photo("6", "in-use")], siteCategories = null, productsError, photosError, rpcError }: {
    products?: unknown[];
    photos?: unknown[];
    /** What the project already has as this website's categories. */
    siteCategories?: unknown[] | null;
    productsError?: Failure;
    photosError?: Failure;
    rpcError?: (name: string, args: Record<string, unknown>) => Failure | null;
} = {}) {
    const rpc = vi.fn(async (name: string, args: Record<string, unknown>) => {
        const failure = rpcError?.(name, args) ?? null;
        return { data: null, error: failure, status: failure?.status ?? 200 };
    });
    const tables: Record<string, { rows: unknown[]; error?: Failure }> = {
        shop_products: { rows: products, error: productsError },
        shop_product_photos: { rows: photos, error: photosError },
    };
    const from = (name: string) => {
        const table = tables[name] ?? { rows: [] };
        const filters: [string, unknown][] = [];
        const query: Record<string, unknown> = {};
        for (const step of ["select", "order", "limit"]) query[step] = () => query;
        query.eq = (column: string, value: unknown) => {
            filters.push([column, value]);
            return query;
        };
        query.maybeSingle = async () => ({ data: name === "site_categories" && siteCategories ? { categories: siteCategories } : null, error: null, status: 200 });
        query.then = (done: (value: unknown) => unknown, fail: (reason: unknown) => unknown) =>
            Promise.resolve({
                data: table.error ? null : (table.rows as Record<string, unknown>[]).filter((r) => filters.every(([c, v]) => r[c] === undefined || r[c] === v)),
                error: table.error ?? null,
                status: table.error?.status ?? 200,
            }).then(done, fail);
        return query;
    };
    const channel = () => {
        const chain = { on: () => chain, subscribe: () => chain };
        return chain;
    };
    const db = { from, rpc, channel, removeChannel: vi.fn() } as unknown as SupabaseClient;
    return { db, rpc };
}

function show(options: Parameters<typeof fakeDb>[0] = {}, props: { active?: boolean } = {}) {
    const fake = fakeDb(options);
    const onWaiting = vi.fn();
    const view = render(<FromTheShop db={fake.db} shop={SHOP} active={props.active ?? true} onWaiting={onWaiting} />);
    return { ...fake, onWaiting, ...view };
}

const decisions = (rpc: ReturnType<typeof vi.fn>) => rpc.mock.calls.filter(([name]) => name === "decide_shop_product");

async function openCard(name = "Sunflower Oil 1 L Bottle") {
    const card = await screen.findByRole("article", { name });
    fireEvent.click(within(card).getByRole("button", { name: /Review/ }));
    await within(card).findByRole("img", { name: /White background photo/ });
    return card;
}

beforeEach(() => {
    vi.resetAllMocks();
    mocks.user.current = { uid: "owner" };
    mocks.getCategories.mockResolvedValue(WEBSITE_CATEGORIES);
    mocks.findShopProduct.mockResolvedValue({ success: true, byKey: null, byBarcode: null });
    mocks.uploadToCloudinary.mockImplementation(async (data: string) => ({
        success: true,
        url: `https://res.cloudinary.com/demo/image/upload/v1/shop/products/${data.length}-${Math.random().toString(36).slice(2, 8)}.jpg`,
        publicId: "x",
    }));
    mocks.publishShopProduct.mockResolvedValue({ success: true, id: "site-1", created: true });
});

afterEach(() => {
    vi.restoreAllMocks();
});

describe("From the shop: the list", () => {
    it("shows what waits for the owner, with the POS's prices and where the shop PC put it, and counts them for the tab", async () => {
        const { onWaiting } = show({
            products: [
                row("6"),
                row("9", { data: offer({ name: "Mustard Oil 500 ml", price: 99.5, originalPrice: null, posName: "Mustard Oil 500", code: "1600", categoryPath: "" }) }),
            ],
        });

        expect(await screen.findByRole("heading", { name: "Waiting for you (2)" })).toBeInTheDocument();
        const first = screen.getByRole("article", { name: "Sunflower Oil 1 L Bottle" });
        expect(first).toHaveTextContent("In your POS: Sunflower Oil 1 L · code 1512");
        expect(first).toHaveTextContent("₹155");
        expect(first).toHaveTextContent("₹175");
        expect(first).toHaveTextContent("Shop PC chose: Oils & Ghee › Sunflower Oil.");
        const second = screen.getByRole("article", { name: "Mustard Oil 500 ml" });
        expect(second).toHaveTextContent("₹99.50");
        expect(second).toHaveTextContent("No category chosen yet.");
        await waitFor(() => expect(onWaiting).toHaveBeenLastCalledWith(2));
    });

    it("says what to do on the shop PC when nothing waits", async () => {
        const { onWaiting } = show({ products: [] });

        expect(await screen.findByRole("heading", { name: "Nothing is waiting" })).toBeInTheDocument();
        expect(screen.getByText(/Offer finished products to your website/)).toBeInTheDocument();
        await waitFor(() => expect(onWaiting).toHaveBeenLastCalledWith(0));
    });

    it("lists the products whose photos are still arriving, and the ones decided on", async () => {
        show({
            products: [
                row("6", { state: "sending", photo_kinds: ["white"] }),
                row("7", { state: "published", data: offer({ name: "Basmati Rice 5 kg" }), decided_at: "2026-10-03T09:00:00+00:00" }),
                row("8", { state: "declined", data: offer({ name: "Cold Drink 2 L" }), decided_at: "2026-10-04T09:00:00+00:00" }),
            ],
        });

        expect(await screen.findByRole("heading", { name: "On their way (1)" })).toBeInTheDocument();
        expect(screen.getByText("Its photos are arriving")).toBeInTheDocument();
        const decided = screen.getByText("Decided (2)").closest("details")!;
        const names = within(decided).getAllByRole("listitem").map((li) => li.textContent);
        expect(names[0]).toContain("Cold Drink 2 L");
        expect(names[0]).toContain("Declined");
        expect(names[1]).toContain("Basmati Rice 5 kg");
        expect(names[1]).toContain("On your website");
    });

    it("says to run the script again in a project that has no waiting list, and tells the tab nothing", async () => {
        const { onWaiting } = show({ productsError: { code: "PGRST205", message: "Could not find the table", status: 404 } });

        expect(await screen.findByRole("heading", { name: "This needs the updated script" })).toBeInTheDocument();
        expect(screen.queryByRole("alert")).not.toBeInTheDocument();
        await waitFor(() => expect(onWaiting).toHaveBeenLastCalledWith(null));
    });

    it("shows any other trouble as it is, and goes on", async () => {
        show({ productsError: { code: "XX000", message: "Something broke", status: 500 } });
        expect(await screen.findByRole("alert")).toHaveTextContent("Something broke");
    });

    it("leaves out a product it cannot read, and draws a name like HTML as text", async () => {
        show({
            products: [
                row("6", { data: offer({ name: '<img src=x onerror="window.__xss=1">Oil', description: "<b>bold</b>" }) }),
                row("7", { data: null }),
                row("not-a-number"),
            ],
        });

        expect(await screen.findByRole("heading", { name: "Waiting for you (1)" })).toBeInTheDocument();
        expect(screen.getByRole("heading", { level: 3 })).toHaveTextContent('<img src=x onerror="window.__xss=1">Oil');
        expect(document.querySelector("article img")).toBeNull();
        expect((window as unknown as { __xss?: number }).__xss).toBeUndefined();
    });
});

describe("From the shop: the website's categories", () => {
    it("tells the project this website's categories when the screen is open, once for the same list", async () => {
        const { rpc, rerender, db, onWaiting } = show();

        await waitFor(() => expect(rpc).toHaveBeenCalledWith("save_site_categories", { p_shop: SHOP.id, p_categories: WEBSITE_CATEGORIES }));
        rerender(<FromTheShop db={db} shop={SHOP} active onWaiting={onWaiting} />);
        await act(async () => { await Promise.resolve(); });
        expect(rpc.mock.calls.filter(([name]) => name === "save_site_categories")).toHaveLength(1);
    });

    it("tells the project at once, whichever screen is open, so the shop PC has them when the owner has only looked at Today", async () => {
        const { rpc } = show({}, { active: false });
        await screen.findByRole("heading", { name: "Waiting for you (1)" });
        await waitFor(() => expect(rpc).toHaveBeenCalledWith("save_site_categories", { p_shop: SHOP.id, p_categories: WEBSITE_CATEGORIES }));
    });

    it("reads them again each time the screen is opened, and sends a changed list", async () => {
        const fake = fakeDb();
        const onWaiting = vi.fn();
        const { rerender } = render(<FromTheShop db={fake.db} shop={SHOP} active={false} onWaiting={onWaiting} />);
        await waitFor(() => expect(mocks.getCategories).toHaveBeenCalledTimes(1));
        await waitFor(() => expect(fake.rpc).toHaveBeenCalledTimes(1));

        rerender(<FromTheShop db={fake.db} shop={SHOP} active onWaiting={onWaiting} />);
        await waitFor(() => expect(mocks.getCategories).toHaveBeenCalledTimes(2));
        await act(async () => { await Promise.resolve(); });
        expect(fake.rpc).toHaveBeenCalledTimes(1);

        rerender(<FromTheShop db={fake.db} shop={SHOP} active={false} onWaiting={onWaiting} />);
        await act(async () => { await Promise.resolve(); });
        expect(mocks.getCategories).toHaveBeenCalledTimes(2);

        mocks.getCategories.mockResolvedValue([...WEBSITE_CATEGORIES, { id: "c-bev", name: "Beverages", parentId: null }]);
        rerender(<FromTheShop db={fake.db} shop={SHOP} active onWaiting={onWaiting} />);
        await waitFor(() => expect(fake.rpc).toHaveBeenCalledTimes(2));
        expect(fake.rpc.mock.calls[1][1].p_categories).toHaveLength(5);
    });

    it("does not send a list the project already has, which would only change its date", async () => {
        const { rpc } = show({ siteCategories: WEBSITE_CATEGORIES.map((c) => ({ ...c })) });
        await screen.findByRole("heading", { name: "Waiting for you (1)" });
        await waitFor(() => expect(mocks.getCategories).toHaveBeenCalled());
        await act(async () => { await Promise.resolve(); await Promise.resolve(); });
        expect(rpc).not.toHaveBeenCalled();
    });

    it("sends the list when the project's is different", async () => {
        const { rpc } = show({ siteCategories: [{ id: "c-old", name: "Old", parentId: null }] });
        await waitFor(() => expect(rpc).toHaveBeenCalledWith("save_site_categories", { p_shop: SHOP.id, p_categories: WEBSITE_CATEGORIES }));
    });

    it("asks for the updated script when the project does not have the function", async () => {
        show({ rpcError: (name) => (name === "save_site_categories" ? { code: "PGRST202", message: "Could not find the function", status: 404 } : null) });
        expect(await screen.findByRole("heading", { name: "This needs the updated script" })).toBeInTheDocument();
    });

    it("says when the project refuses the categories", async () => {
        show({ rpcError: (name) => (name === "save_site_categories" ? { code: "P0001", message: "Only the shop's owner can send the website's categories." } : null) });
        expect(await screen.findByRole("alert")).toHaveTextContent("could not be sent to the shop PC: Only the shop's owner can send");
    });

    it("says when the website's own categories cannot be read", async () => {
        mocks.getCategories.mockRejectedValue(new Error("down"));
        show();
        expect(await screen.findByRole("alert")).toHaveTextContent("Your website's categories could not be read");
    });
});

describe("From the shop: reviewing a product", () => {
    it("shows its photos, its words and the place the shop PC chose, from the website's own list", async () => {
        show();
        const card = await openCard();

        expect(within(card).getByRole("img", { name: "In use photo of Sunflower Oil 1 L Bottle" })).toHaveAttribute("src", expect.stringMatching(/^data:image\/jpeg;base64,A+$/));
        expect(within(card).getAllByRole("checkbox")).toHaveLength(2);
        expect(within(card).getAllByRole("checkbox").every((box) => (box as HTMLInputElement).checked)).toBe(true);
        expect(within(card).getByLabelText("Category on your website")).toHaveValue("c-sun");
        expect(within(card).getAllByRole("option").map((o) => o.textContent)).toEqual([
            "Grocery", "Oils & Ghee", "Oils & Ghee › Mustard Oil", "Oils & Ghee › Sunflower Oil",
        ]);
        expect(card).toHaveTextContent("Good for frying.");
        expect(within(card).getByText("Light on the stomach")).toBeInTheDocument();
        expect(within(card).getByText("Volume")).toBeInTheDocument();
        expect(within(card).getByText("cooking")).toBeInTheDocument();
        expect(card).toHaveTextContent("Barcode 8901234567890");
        expect(within(card).getByRole("button", { name: "Approve and publish" })).toBeEnabled();
    });

    it("loads the photos only when the card is opened, and shows them in the shop PC's order", async () => {
        show({ photos: [photo("6", "in-use"), photo("6", "east-asian-model"), photo("6", "white"), photo("7", "white")] });
        const card = await screen.findByRole("article", { name: "Sunflower Oil 1 L Bottle" });
        expect(within(card).queryByRole("img")).not.toBeInTheDocument();

        fireEvent.click(within(card).getByRole("button", { name: /Review/ }));
        await within(card).findByRole("img", { name: /White background photo/ });
        expect(within(card).getAllByRole("img").map((img) => img.getAttribute("alt"))).toEqual([
            "White background photo of Sunflower Oil 1 L Bottle",
            "In use photo of Sunflower Oil 1 L Bottle",
            "East Asian model photo of Sunflower Oil 1 L Bottle",
        ]);
    });

    it("leaves out a picture that is not a safe one", async () => {
        show({ photos: [photo("6", "white"), photo("6", "in-use", { mime: "image/svg+xml" }), photo("6", "indian-model", { content: "<script>" })] });
        const card = await openCard();
        expect(within(card).getAllByRole("img")).toHaveLength(1);
    });

    it("asks for a category when the one the shop PC chose is not on the website any more", async () => {
        show({ products: [row("6", { data: offer({ categoryId: "c-gone", subcategoryId: "" }) })] });
        const card = await openCard();

        expect(within(card).getByLabelText("Category on your website")).toHaveValue("");
        expect(within(card).getByRole("button", { name: "Approve and publish" })).toBeDisabled();
        expect(card).toHaveTextContent("Choose a category of your website.");
        expect(card).toHaveTextContent("is not on your website any more");

        fireEvent.change(within(card).getByLabelText("Category on your website"), { target: { value: "c-groc" } });
        expect(within(card).getByRole("button", { name: "Approve and publish" })).toBeEnabled();
    });

    it("needs a photo for a new product, and is told so", async () => {
        show();
        const card = await openCard();
        for (const box of within(card).getAllByRole("checkbox")) fireEvent.click(box);

        expect(within(card).getByRole("button", { name: "Approve and publish" })).toBeDisabled();
        expect(card).toHaveTextContent("Choose at least one photo");
    });

    it("says when the photos could not be read", async () => {
        show({ photosError: { message: "permission denied" } });
        const card = await screen.findByRole("article", { name: "Sunflower Oil 1 L Bottle" });
        fireEvent.click(within(card).getByRole("button", { name: /Review/ }));
        expect(await within(card).findByText("permission denied")).toBeInTheDocument();
    });

    it("closes with the same button, and opens one card at a time", async () => {
        show({ products: [row("6"), row("9", { data: offer({ name: "Mustard Oil 500 ml" }) })], photos: [photo("6", "white"), photo("9", "white")] });
        const first = await openCard();
        const second = screen.getByRole("article", { name: "Mustard Oil 500 ml" });

        fireEvent.click(within(second).getByRole("button", { name: /Review/ }));
        await within(second).findByRole("img");
        expect(within(first).queryByRole("img")).not.toBeInTheDocument();
        fireEvent.click(within(second).getByRole("button", { name: /Close/ }));
        expect(within(second).queryByRole("img")).not.toBeInTheDocument();
    });
});

describe("From the shop: approving", () => {
    it("puts the photos on Cloudinary, the product on the website, and tells the project it is done", async () => {
        const { rpc } = show();
        const card = await openCard();

        fireEvent.click(within(card).getByRole("button", { name: "Approve and publish" }));

        expect(await screen.findByText(/“Sunflower Oil 1 L Bottle” is on your website/)).toBeInTheDocument();
        expect(screen.getByRole("link", { name: /View it/ })).toHaveAttribute("href", "/products/site-1");
        expect(mocks.uploadToCloudinary).toHaveBeenCalledTimes(2);
        expect(mocks.uploadToCloudinary.mock.calls[0]).toEqual([expect.stringMatching(/^data:image\/jpeg;base64,A+$/), "products", "image"]);
        expect(mocks.publishShopProduct).toHaveBeenCalledTimes(1);
        const sent = mocks.publishShopProduct.mock.calls[0][0];
        expect(sent).toMatchObject({
            shopId: SHOP.id,
            productKey: "6",
            name: "Sunflower Oil 1 L Bottle",
            price: 155,
            originalPrice: 175,
            barcode: "8901234567890",
            categoryId: "c-oils",
            subcategoryId: "c-sun",
            updateId: null,
        });
        expect(sent.imageUrls).toHaveLength(2);
        expect(decisions(rpc)).toEqual([["decide_shop_product", { p_shop: SHOP.id, p_product: "6", p_state: "published" }]]);
        // Publishing, then the decision: the project is told only after the website has the product.
        expect(mocks.publishShopProduct.mock.invocationCallOrder[0]).toBeLessThan(rpc.mock.invocationCallOrder[rpc.mock.calls.findIndex(([name]) => name === "decide_shop_product")]);
    });

    it("sends the category the owner chose and only the photos that are ticked, the first ticked being the main one", async () => {
        show({ photos: [photo("6", "white"), photo("6", "in-use"), photo("6", "indian-model")], products: [row("6", { photo_kinds: ["white", "in-use", "indian-model"] })] });
        const card = await openCard();
        fireEvent.click(within(card).getByRole("checkbox", { name: "Use the White background photo" }));
        fireEvent.change(within(card).getByLabelText("Category on your website"), { target: { value: "c-must" } });

        fireEvent.click(within(card).getByRole("button", { name: "Approve and publish" }));
        await screen.findByText(/is on your website/);

        expect(mocks.uploadToCloudinary).toHaveBeenCalledTimes(2);
        expect(mocks.publishShopProduct.mock.calls[0][0]).toMatchObject({ categoryId: "c-oils", subcategoryId: "c-must" });
        expect(mocks.publishShopProduct.mock.calls[0][0].imageUrls).toHaveLength(2);
    });

    it("sends a main category with no subcategory", async () => {
        show({ products: [row("6", { data: offer({ categoryId: "c-oils", subcategoryId: "" }) })] });
        const card = await openCard();
        expect(within(card).getByLabelText("Category on your website")).toHaveValue("c-oils");

        fireEvent.click(within(card).getByRole("button", { name: "Approve and publish" }));
        await screen.findByText(/is on your website/);
        expect(mocks.publishShopProduct.mock.calls[0][0]).toMatchObject({ categoryId: "c-oils", subcategoryId: "" });
    });

    it("updates the product it made before, and says so", async () => {
        mocks.findShopProduct.mockResolvedValue({ success: true, byKey: { id: "site-1", name: "Sunflower Oil", price: 150, imageUrl: null }, byBarcode: null });
        mocks.publishShopProduct.mockResolvedValue({ success: true, id: "site-1", created: false });
        show();
        const card = await openCard();

        expect(await within(card).findByText(/is on your website already, from this shop PC/)).toBeInTheDocument();
        fireEvent.click(within(card).getByRole("button", { name: "Approve and update" }));

        expect(await screen.findByText(/is on your website \(updated\)/)).toBeInTheDocument();
        expect(mocks.publishShopProduct.mock.calls[0][0].updateId).toBeNull();
    });

    it("lets a product with no new photos be updated without any", async () => {
        mocks.findShopProduct.mockResolvedValue({ success: true, byKey: { id: "site-1", name: "Sunflower Oil", price: 150, imageUrl: null }, byBarcode: null });
        mocks.publishShopProduct.mockResolvedValue({ success: true, id: "site-1", created: false });
        show({ photos: [], products: [row("6", { photo_kinds: ["white"] })] });
        const card = await screen.findByRole("article", { name: "Sunflower Oil 1 L Bottle" });
        fireEvent.click(within(card).getByRole("button", { name: /Review/ }));
        await within(card).findByText(/its photos stay as they are on your website/);

        const approve = await within(card).findByRole("button", { name: "Approve and update" });
        expect(approve).toBeEnabled();
        fireEvent.click(approve);
        await screen.findByText(/is on your website \(updated\)/);
        expect(mocks.uploadToCloudinary).not.toHaveBeenCalled();
        expect(mocks.publishShopProduct.mock.calls[0][0].imageUrls).toEqual([]);
    });

    it("offers to update another product with the same barcode, or to add a new one", async () => {
        mocks.findShopProduct.mockResolvedValue({ success: true, byKey: null, byBarcode: { id: "old-1", name: "Sunflower Oil 1 Litre", price: 150, imageUrl: null } });
        show();
        const card = await openCard();

        const update = await within(card).findByRole("radio", { name: /Update “Sunflower Oil 1 Litre” \(₹150\)/ });
        expect(update).toBeChecked();
        expect(within(card).getByRole("button", { name: "Approve and update" })).toBeEnabled();
        fireEvent.click(within(card).getByRole("button", { name: "Approve and update" }));
        await screen.findByText(/is on your website/);
        expect(mocks.publishShopProduct.mock.calls[0][0].updateId).toBe("old-1");
    });

    it("adds a new product when the owner says so, though one has the same barcode", async () => {
        mocks.findShopProduct.mockResolvedValue({ success: true, byKey: null, byBarcode: { id: "old-1", name: "Sunflower Oil 1 Litre", price: 150, imageUrl: null } });
        show();
        const card = await openCard();
        fireEvent.click(await within(card).findByRole("radio", { name: "Add it as a new product" }));

        fireEvent.click(within(card).getByRole("button", { name: "Approve and publish" }));
        await screen.findByText(/is on your website/);
        expect(mocks.publishShopProduct.mock.calls[0][0].updateId).toBeNull();
    });

    it("keeps the product in the list and says why when a photo cannot be uploaded", async () => {
        mocks.uploadToCloudinary.mockResolvedValue({ success: false, error: "All Cloudinary accounts have reached their limits." });
        const { rpc } = show();
        const card = await openCard();

        fireEvent.click(within(card).getByRole("button", { name: "Approve and publish" }));

        expect(await within(card).findByRole("alert")).toHaveTextContent("All Cloudinary accounts have reached their limits.");
        expect(mocks.publishShopProduct).not.toHaveBeenCalled();
        expect(decisions(rpc)).toHaveLength(0);
        expect(within(card).getByRole("button", { name: "Approve and publish" })).toBeEnabled();
    });

    it("keeps the product in the list and says why when the website refuses it", async () => {
        mocks.publishShopProduct.mockResolvedValue({ success: false, error: "That category is not on your website any more. Choose another." });
        const { rpc } = show();
        const card = await openCard();

        fireEvent.click(within(card).getByRole("button", { name: "Approve and publish" }));

        expect(await within(card).findByRole("alert")).toHaveTextContent("That category is not on your website any more.");
        expect(decisions(rpc)).toHaveLength(0);
    });

    it("does not upload the photos again when the owner tries again", async () => {
        mocks.publishShopProduct.mockResolvedValueOnce({ success: false, error: "The product could not be put on your website. Try again." });
        show();
        const card = await openCard();

        fireEvent.click(within(card).getByRole("button", { name: "Approve and publish" }));
        await within(card).findByRole("alert");
        expect(mocks.uploadToCloudinary).toHaveBeenCalledTimes(2);

        fireEvent.click(within(card).getByRole("button", { name: "Approve and publish" }));
        await screen.findByText(/is on your website/);
        expect(mocks.uploadToCloudinary).toHaveBeenCalledTimes(2);
        expect(mocks.publishShopProduct).toHaveBeenCalledTimes(2);
    });

    it("says what to do when the product is on the website but the project could not be told", async () => {
        const { rpc } = show({ rpcError: (name) => (name === "decide_shop_product" ? { message: "network down" } : null) });
        const card = await openCard();

        fireEvent.click(within(card).getByRole("button", { name: "Approve and publish" }));

        expect(await within(card).findByRole("alert")).toHaveTextContent("It is on your website, but it could not be marked as done here (network down). Press Approve again: that updates the same product.");
        expect(decisions(rpc)).toHaveLength(1);
    });
});

describe("From the shop: declining", () => {
    it("tells the project and puts nothing on the website, after the owner agrees", async () => {
        const confirm = vi.spyOn(window, "confirm").mockReturnValue(true);
        const { rpc } = show();
        const card = await openCard();

        fireEvent.click(within(card).getByRole("button", { name: "Decline" }));

        expect(await screen.findByText(/“Sunflower Oil 1 L Bottle” was declined/)).toBeInTheDocument();
        expect(confirm).toHaveBeenCalledTimes(1);
        expect(decisions(rpc)).toEqual([["decide_shop_product", { p_shop: SHOP.id, p_product: "6", p_state: "declined" }]]);
        expect(mocks.publishShopProduct).not.toHaveBeenCalled();
        expect(mocks.uploadToCloudinary).not.toHaveBeenCalled();
    });

    it("does nothing when the owner changes their mind", async () => {
        vi.spyOn(window, "confirm").mockReturnValue(false);
        const { rpc } = show();
        const card = await openCard();

        fireEvent.click(within(card).getByRole("button", { name: "Decline" }));

        expect(decisions(rpc)).toHaveLength(0);
        expect(screen.queryByText(/was declined/)).not.toBeInTheDocument();
    });

    it("says why when the project does not take the decision", async () => {
        vi.spyOn(window, "confirm").mockReturnValue(true);
        show({ rpcError: (name) => (name === "decide_shop_product" ? { message: "That product is not waiting for a decision." } : null) });
        const card = await openCard();

        fireEvent.click(within(card).getByRole("button", { name: "Decline" }));

        expect(await within(card).findByRole("alert")).toHaveTextContent("That product is not waiting for a decision.");
    });
});

describe("From the shop: an owner who is not signed in to the website's admin", () => {
    beforeEach(() => {
        mocks.user.current = null;
    });

    it("can look and decline, and is told how to sign in to publish", async () => {
        vi.spyOn(window, "confirm").mockReturnValue(true);
        const { rpc } = show();
        const link = await screen.findByRole("link", { name: /Sign in/ });
        expect(link).toHaveAttribute("href", "/admin/login");
        expect(link).toHaveAttribute("target", "_blank");

        const card = await openCard();
        expect(within(card).getByRole("button", { name: "Approve and publish" })).toBeDisabled();
        expect(card).toHaveTextContent("Sign in to your website's admin to publish products.");
        expect(mocks.findShopProduct).not.toHaveBeenCalled();

        fireEvent.click(within(card).getByRole("button", { name: "Decline" }));
        await screen.findByText(/was declined/);
        expect(decisions(rpc)).toHaveLength(1);
    });
});
