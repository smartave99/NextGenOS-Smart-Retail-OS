import { LOCALE } from "@/lib/region/lite";
// The shop's AI answers in simple Markdown (headings, lists, **bold**). It is read here into plain parts that the
// page shows as text: nothing in an answer is ever put on the page as HTML.

export interface Inline { text: string; bold: boolean }

export type Block =
    | { kind: "heading"; parts: Inline[] }
    | { kind: "paragraph"; parts: Inline[] }
    | { kind: "list"; ordered: boolean; items: Inline[][] };

export function readAnswer(text: string): Block[] {
    const blocks: Block[] = [];
    let paragraph: string[] = [];
    let list: { ordered: boolean; items: string[] } | null = null;
    const endParagraph = () => {
        if (paragraph.length) blocks.push({ kind: "paragraph", parts: inline(paragraph.join(" ")) });
        paragraph = [];
    };
    const endList = () => {
        if (list) blocks.push({ kind: "list", ordered: list.ordered, items: list.items.map(inline) });
        list = null;
    };

    for (const raw of (text ?? "").replace(/\r\n?/g, "\n").split("\n")) {
        const line = raw.trim();
        const heading = /^#{1,6}\s+(.+)$/.exec(line);
        const item = /^(?:[-*•]|(\d+)[.)])\s+(.+)$/.exec(line);
        if (!line) {
            endParagraph();
            endList();
        } else if (heading) {
            endParagraph();
            endList();
            blocks.push({ kind: "heading", parts: inline(heading[1]) });
        } else if (item) {
            endParagraph();
            const ordered = item[1] !== undefined;
            if (list && list.ordered !== ordered) endList();
            list ??= { ordered, items: [] };
            list.items.push(item[2]);
        } else {
            endList();
            paragraph.push(line);
        }
    }
    endParagraph();
    endList();
    return blocks;
}

/** A line's words, with **bold** marked; any other mark stays as it is. */
export function inline(text: string): Inline[] {
    const parts: Inline[] = [];
    const bold = /\*\*(.+?)\*\*/g;
    let at = 0;
    for (let match = bold.exec(text); match; match = bold.exec(text)) {
        if (match.index > at) parts.push({ text: text.slice(at, match.index), bold: false });
        parts.push({ text: match[1], bold: true });
        at = match.index + match[0].length;
    }
    if (at < text.length) parts.push({ text: text.slice(at), bold: false });
    return parts;
}

const figure = new Intl.NumberFormat(LOCALE, { maximumFractionDigits: 2 });

/** A table cell as text: numbers the way the shop's country writes them (in India 1,23,456.5), yes/no, and nothing for an empty cell. */
export function answerCell(value: string | number | boolean | null | undefined): string {
    if (value === null || value === undefined) return "";
    if (typeof value === "number") return Number.isFinite(value) ? figure.format(value) : "";
    if (typeof value === "boolean") return value ? "Yes" : "No";
    return value;
}

/** True when every filled cell in the column is a number, so the column lines up on the right. */
export function isNumberColumn(rows: (string | number | boolean | null)[][], column: number): boolean {
    const filled = rows.map((row) => row[column]).filter((cell) => cell !== null && cell !== undefined && cell !== "");
    return filled.length > 0 && filled.every((cell) => typeof cell === "number");
}
