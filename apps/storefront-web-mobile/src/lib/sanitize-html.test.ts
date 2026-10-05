import { describe, expect, it } from "vitest";
import { sanitizePageHtml } from "./sanitize-html";

describe("sanitizePageHtml", () => {
    it("keeps plain formatting", () => {
        const html = "<h2>Terms</h2><p>Be <strong>kind</strong>, <em>always</em>.</p><ul><li>One</li></ul>";
        expect(sanitizePageHtml(html)).toBe(html);
    });

    it.each([
        ["<script>alert(1)</script><p>x</p>", "<p>x</p>"],
        ['<p onclick="alert(1)">x</p>', "<p>x</p>"],
        ['<img src=x onerror="alert(1)">', ""],
        ['<iframe src="https://evil.example"></iframe>', ""],
        ['<a href="javascript:alert(1)">x</a>', "<a rel=\"noopener noreferrer nofollow\">x</a>"],
        ['<p style="position:fixed">x</p>', "<p>x</p>"],
        ["<form action=/x><input name=a></form>", ""],
        ['<svg onload="alert(1)"></svg>', ""],
        ['<a href="data:text/html;base64,PHNjcmlwdD4=">x</a>', "<a rel=\"noopener noreferrer nofollow\">x</a>"],
    ])("removes what runs code: %s", (dirty, clean) => {
        expect(sanitizePageHtml(dirty)).toBe(clean);
    });

    it("makes links safe to follow and handles nothing", () => {
        expect(sanitizePageHtml('<a href="https://example.com" target="_blank">x</a>')).toBe('<a href="https://example.com" target="_blank" rel="noopener noreferrer nofollow">x</a>');
        expect(sanitizePageHtml(null)).toBe("");
        expect(sanitizePageHtml(undefined)).toBe("");
    });
});
