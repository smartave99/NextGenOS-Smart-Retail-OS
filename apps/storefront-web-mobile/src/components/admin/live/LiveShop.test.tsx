import { afterEach, describe, expect, it, vi } from "vitest";
import { render, screen } from "@testing-library/react";
import LiveShop from "./LiveShop";

// From the shop reaches the website's server actions and its admin sign-in; these tests are about the other screens.
vi.mock("@/app/actions", () => ({ getCategories: vi.fn(async () => []) }));
vi.mock("@/app/actions/shop-products", () => ({ findShopProduct: vi.fn(), publishShopProduct: vi.fn() }));
vi.mock("@/app/cloudinary-actions", () => ({ uploadToCloudinary: vi.fn() }));
vi.mock("@/context/auth-context", () => ({ useAuth: () => ({ user: null, loading: false }) }));

const saved = { ...process.env };

afterEach(() => {
    process.env = { ...saved };
});

describe("LiveShop", () => {
    it("says what the website needs before it can show the shop", () => {
        delete process.env.NEXT_PUBLIC_SUPABASE_URL;
        delete process.env.NEXT_PUBLIC_SUPABASE_PUBLISHABLE_KEY;
        delete process.env.NEXT_PUBLIC_SUPABASE_ANON_KEY;
        render(<LiveShop />);
        expect(screen.getByRole("heading", { name: "Live shop is not set up yet" })).toBeInTheDocument();
        expect(screen.getByRole("alert")).toHaveTextContent("NEXT_PUBLIC_SUPABASE_PUBLISHABLE_KEY");
    });

    it("never uses the project's secret key: the server drops it, so it never reaches the page, and the panel says it is not set up", () => {
        process.env.NEXT_PUBLIC_SUPABASE_URL = "https://abcd.supabase.co";
        process.env.NEXT_PUBLIC_SUPABASE_PUBLISHABLE_KEY = "sb_secret_abcdefghij";
        render(<LiveShop />);
        expect(screen.getByRole("heading", { name: "Live shop is not set up yet" })).toBeInTheDocument();
        expect(screen.getByRole("alert")).not.toHaveTextContent("sb_secret_abcdefghij");
    });

    it("asks the owner to sign in", async () => {
        process.env.NEXT_PUBLIC_SUPABASE_URL = "http://127.0.0.1:54321";
        process.env.NEXT_PUBLIC_SUPABASE_PUBLISHABLE_KEY = "sb_publishable_abcdefghij";
        render(<LiveShop />);
        expect(await screen.findByRole("heading", { name: "See your shop, live" })).toBeInTheDocument();
        expect(screen.getByLabelText("E-mail")).toBeRequired();
        expect(screen.getByRole("button", { name: "Create the owner's account" })).toBeInTheDocument();
    });
});
