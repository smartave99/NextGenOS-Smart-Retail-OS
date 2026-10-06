/** Turns the rows of an uploaded spreadsheet into objects, safely. */

export type SheetObject = Record<string, unknown>;

const MAX_COLUMNS = 60;
const MAX_CELL_TEXT = 5_000;
const FORBIDDEN_KEYS = new Set(["__proto__", "constructor", "prototype"]);

/**
 * The first row names the columns; every other row becomes an object. A column whose name could reach an object's
 * prototype is dropped, long text is cut, and rows with nothing in them are left out.
 */
export function sheetRowsToObjects(sheetRows: unknown[][]): SheetObject[] {
    if (!Array.isArray(sheetRows) || sheetRows.length < 2) return [];
    const header = sheetRows[0].slice(0, MAX_COLUMNS).map((h) => (h == null ? "" : String(h).trim()));
    const out: SheetObject[] = [];
    for (const cells of sheetRows.slice(1)) {
        const row: SheetObject = Object.create(null);
        let any = false;
        header.forEach((name, i) => {
            const raw = cells[i];
            if (!name || FORBIDDEN_KEYS.has(name.toLowerCase()) || raw === null || raw === undefined || raw === "") return;
            row[name] = typeof raw === "string" ? raw.slice(0, MAX_CELL_TEXT) : raw;
            any = true;
        });
        if (any) out.push(row);
    }
    return out;
}
