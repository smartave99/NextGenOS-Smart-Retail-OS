import { describe, expect, it, vi } from "vitest";
import { fireEvent, render, screen } from "@testing-library/react";
import Bars from "./Bars";
import { History } from "./Figures";

describe("Bars", () => {
    it("opens a column with Enter or Space, as a click does", () => {
        const open = vi.fn();
        render(<Bars label="Sales by day" bars={[
            { label: "26 Sept", value: 500, title: "26 Sept: ₹500 from 2 bills", onClick: open },
            { label: "27 Sept", value: 900, title: "27 Sept: ₹900 from 3 bills", onClick: open, hi: true },
        ]} />);

        const [first, second] = screen.getAllByRole("button");
        expect(first).toHaveAttribute("tabindex", "0");
        expect(first).toHaveAccessibleName("26 Sept: ₹500 from 2 bills");
        expect(second).toHaveAttribute("aria-pressed", "true");
        fireEvent.keyDown(first, { key: "Enter" });
        fireEvent.keyDown(first, { key: " " });
        fireEvent.keyDown(first, { key: "a" });
        fireEvent.click(second);
        expect(open).toHaveBeenCalledTimes(3);
    });

    it("keeps a chart without actions a single picture", () => {
        render(<Bars label="Sales by hour" bars={[{ label: "9 am", value: 100, title: "9 am: ₹100" }]} />);
        expect(screen.queryAllByRole("button")).toHaveLength(0);
        expect(screen.getByRole("img", { name: "Sales by hour" })).toBeInTheDocument();
    });
});

describe("History", () => {
    it("shows a day's hours and best sellers when its column is opened with the keyboard", () => {
        const day = (d: string, sales: number) => ({
            day: d, sales, bills: 2, returns: 0,
            hours: [{ hour: 18, sales, bills: 2 }],
            top: [{ name: "Basmati Rice 5 kg", qty: 1, sales }],
        });
        render(<History days={[day("2026-09-26", 500), day("2026-09-27", 900)]} />);

        fireEvent.keyDown(screen.getAllByRole("button")[0], { key: "Enter" });

        expect(screen.getByRole("heading", { name: /: ₹500 from 2 bills$/ })).toBeInTheDocument();
        expect(screen.getByText("Basmati Rice 5 kg")).toBeInTheDocument();
    });
});
