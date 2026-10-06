import { describe, expect, it } from "vitest";
import { sheetRowsToObjects } from "./sheet-rows";

describe("sheetRowsToObjects", () => {
    it("names the columns from the first row and skips empty rows and empty cells", () => {
        const rows = sheetRowsToObjects([
            ["Name", " Price ", "Category"],
            ["Rice 5kg", 450, "Grocery"],
            [null, null, null],
            ["Tea", 120, ""],
        ]);
        expect(rows).toHaveLength(2);
        expect(rows[0]).toMatchObject({ Name: "Rice 5kg", Price: 450, Category: "Grocery" });
        expect(Object.keys(rows[1])).toEqual(["Name", "Price"]);
    });

    it("drops columns that could pollute an object's prototype", () => {
        const rows = sheetRowsToObjects([
            ["Name", "__proto__", "constructor", "prototype"],
            ["Tea", "x", "y", "z"],
        ]);
        expect(Object.keys(rows[0])).toEqual(["Name"]);
        expect(({} as Record<string, unknown>).x).toBeUndefined();
        expect(Object.getPrototypeOf(rows[0])).toBeNull();
    });

    it("cuts very long text, limits the columns and handles a sheet with no rows", () => {
        const long = sheetRowsToObjects([["Name"], ["x".repeat(20_000)]]);
        expect(String(long[0].Name)).toHaveLength(5_000);

        const wide = sheetRowsToObjects([Array.from({ length: 200 }, (_, i) => `c${i}`), Array.from({ length: 200 }, (_, i) => i + 1)]);
        expect(Object.keys(wide[0])).toHaveLength(60);

        expect(sheetRowsToObjects([])).toEqual([]);
        expect(sheetRowsToObjects([["Name"]])).toEqual([]);
    });
});
