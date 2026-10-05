import sanitizeHtml from "sanitize-html";

/**
 * The text of the shop's own pages (Terms, Privacy) is written by the shop and shown to every visitor, so it is cleaned before
 * it is saved and again before it is shown: only plain formatting is kept. Scripts, forms, frames, event handlers, styles and
 * links that run code are removed.
 */
const OPTIONS: sanitizeHtml.IOptions = {
    allowedTags: [
        "h1", "h2", "h3", "h4", "h5", "h6", "p", "br", "hr", "ul", "ol", "li", "strong", "b", "em", "i", "u", "s", "blockquote",
        "a", "span", "div", "table", "thead", "tbody", "tr", "th", "td", "code", "pre",
    ],
    allowedAttributes: {
        a: ["href", "title", "target", "rel"],
        th: ["colspan", "rowspan"],
        td: ["colspan", "rowspan"],
    },
    allowedSchemes: ["http", "https", "mailto", "tel"],
    allowProtocolRelative: false,
    disallowedTagsMode: "discard",
    transformTags: {
        a: (tagName, attribs) => ({
            tagName,
            attribs: { ...attribs, rel: "noopener noreferrer nofollow", ...(attribs.target ? { target: "_blank" } : {}) },
        }),
    },
};

export function sanitizePageHtml(html: string | null | undefined): string {
    return sanitizeHtml(html ?? "", OPTIONS);
}
