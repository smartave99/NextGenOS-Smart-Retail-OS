import { afterEach, describe, expect, it, vi } from "vitest";
import { act, fireEvent, render, renderHook, screen, waitFor } from "@testing-library/react";
import ScreenTabs, { useScreen } from "./ScreenTabs";

afterEach(() => {
    vi.restoreAllMocks();
    window.history.replaceState(null, "", "/");
});

describe("ScreenTabs", () => {
    it("offers Today, Last week and From the shop, and marks the one that is open", () => {
        render(<ScreenTabs screen="review" onChange={() => {}} />);

        expect(screen.getByRole("navigation", { name: "Screens" })).toBeInTheDocument();
        expect(screen.getByRole("button", { name: "Last week" })).toHaveAttribute("aria-current", "true");
        expect(screen.getByRole("button", { name: "Today" })).not.toHaveAttribute("aria-current");
        expect(screen.getByRole("button", { name: "From the shop" })).not.toHaveAttribute("aria-current");
    });

    it("says how many products wait for the owner on From the shop, for everyone, and nothing when none do", () => {
        const { rerender } = render(<ScreenTabs screen="today" onChange={() => {}} waiting={3} />);
        expect(screen.getByRole("button", { name: "From the shop, 3 waiting for you" })).toBeInTheDocument();
        expect(screen.getByRole("button", { name: "From the shop, 3 waiting for you" })).toHaveTextContent("3");

        rerender(<ScreenTabs screen="today" onChange={() => {}} waiting={0} />);
        expect(screen.getByRole("button", { name: "From the shop" })).toBeInTheDocument();

        rerender(<ScreenTabs screen="today" onChange={() => {}} waiting={null} />);
        expect(screen.getByRole("button", { name: "From the shop" })).toBeInTheDocument();
        expect(screen.getByRole("button", { name: "Today" })).toHaveTextContent(/^Today$/);
    });

    it("opens a screen with a click, or with Enter or Space on the button", () => {
        const open = vi.fn();
        render(<ScreenTabs screen="today" onChange={open} />);

        fireEvent.click(screen.getByRole("button", { name: "Last week" }));
        expect(open).toHaveBeenCalledWith("review");
        fireEvent.click(screen.getByRole("button", { name: "From the shop" }));
        expect(open).toHaveBeenLastCalledWith("shop");
        fireEvent.click(screen.getByRole("button", { name: "Today" }));
        expect(open).toHaveBeenLastCalledWith("today");
    });
});

describe("useScreen", () => {
    it("starts on Today, on Last week when the address says #review and on From the shop for #shop", () => {
        expect(renderHook(() => useScreen()).result.current[0]).toBe("today");

        window.history.replaceState(null, "", "/admin/live#review");
        expect(renderHook(() => useScreen()).result.current[0]).toBe("review");

        window.history.replaceState(null, "", "/admin/live#shop");
        expect(renderHook(() => useScreen()).result.current[0]).toBe("shop");

        window.history.replaceState(null, "", "/admin/live#something-else");
        expect(renderHook(() => useScreen()).result.current[0]).toBe("today");
    });

    it("keeps the screen in the address, with the rest of it as it was, without adding to the history", () => {
        window.history.replaceState(null, "", "/admin/live?shop=1");
        const push = vi.spyOn(window.history, "pushState");
        const { result } = renderHook(() => useScreen());

        act(() => result.current[1]("review"));
        expect(result.current[0]).toBe("review");
        expect(window.location.pathname + window.location.search + window.location.hash).toBe("/admin/live?shop=1#review");

        act(() => result.current[1]("shop"));
        expect(result.current[0]).toBe("shop");
        expect(window.location.pathname + window.location.search + window.location.hash).toBe("/admin/live?shop=1#shop");

        act(() => result.current[1]("today"));
        expect(result.current[0]).toBe("today");
        expect(window.location.pathname + window.location.search + window.location.hash).toBe("/admin/live?shop=1");
        expect(push).not.toHaveBeenCalled();
    });

    it("follows the address when it changes by itself, and stops listening when it goes", async () => {
        const { result, unmount } = renderHook(() => useScreen());

        act(() => {
            window.location.hash = "#review";
        });
        await waitFor(() => expect(result.current[0]).toBe("review"));

        act(() => {
            window.location.hash = "";
        });
        await waitFor(() => expect(result.current[0]).toBe("today"));

        const remove = vi.spyOn(window, "removeEventListener");
        unmount();
        expect(remove).toHaveBeenCalledWith("hashchange", expect.any(Function));
    });
});
