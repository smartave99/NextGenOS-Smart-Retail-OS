import { describe, expect, it } from "vitest";
import { answerCell, inline, isNumberColumn, readAnswer } from "./answer";

describe("readAnswer", () => {
    it("reads headings, paragraphs and lists, with bold words", () => {
        const blocks = readAnswer("## Today\nSales were **₹5,723**\nfrom 5 bills.\n\n- Keep **tea** near the counter\n* Call the supplier\n1. First\n2) Second");
        expect(blocks).toEqual([
            { kind: "heading", parts: [{ text: "Today", bold: false }] },
            { kind: "paragraph", parts: [{ text: "Sales were ", bold: false }, { text: "₹5,723", bold: true }, { text: " from 5 bills.", bold: false }] },
            { kind: "list", ordered: false, items: [
                [{ text: "Keep ", bold: false }, { text: "tea", bold: true }, { text: " near the counter", bold: false }],
                [{ text: "Call the supplier", bold: false }],
            ] },
            { kind: "list", ordered: true, items: [[{ text: "First", bold: false }], [{ text: "Second", bold: false }]] },
        ]);
    });

    it("keeps anything else as plain text, HTML included", () => {
        expect(readAnswer("<b>not bold</b> and <script>x</script>")).toEqual([
            { kind: "paragraph", parts: [{ text: "<b>not bold</b> and <script>x</script>", bold: false }] },
        ]);
        expect(inline("a ** b")).toEqual([{ text: "a ** b", bold: false }]);
        expect(readAnswer("")).toEqual([]);
    });
});

describe("answer tables", () => {
    it("shows cells as text, numbers the Indian way", () => {
        expect(answerCell(123456.5)).toBe("1,23,456.5");
        expect(answerCell(true)).toBe("Yes");
        expect(answerCell(null)).toBe("");
        expect(answerCell("Sunflower Oil 1 L")).toBe("Sunflower Oil 1 L");
    });

    it("lines up a column of numbers on the right", () => {
        const rows = [["Tea", 120, null], ["Oil", 80.5, "x"]];
        expect(isNumberColumn(rows, 0)).toBe(false);
        expect(isNumberColumn(rows, 1)).toBe(true);
        expect(isNumberColumn(rows, 2)).toBe(false);
        expect(isNumberColumn([[null]], 0)).toBe(false);
    });
});
