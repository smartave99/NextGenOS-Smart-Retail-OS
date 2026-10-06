/**
 * The shop's own name, from the setting NEXT_PUBLIC_SITE_NAME (set when a customer's site is set up, for example by the
 * Brand Studio). Nothing is built in. Used in texts and AI instructions that must name the shop.
 */
export const SHOP_NAME = process.env.NEXT_PUBLIC_SITE_NAME || "our store";

/** A shop name as a short folder name: small letters, digits and single hyphens ("Luzon Fresh Mart" becomes "luzon-fresh-mart"). */
export function folderNameOf(name: string | undefined): string {
    return (name ?? "")
        .normalize("NFKD")
        .toLowerCase()
        .replace(/[^a-z0-9]+/g, "-")
        .replace(/^-+|-+$/g, "")
        .slice(0, 40)
        .replace(/-+$/g, "");
}

/** The folder every upload goes under in the media library: the shop's own name, or "shop" when it has none set. Nothing is built in. */
export const UPLOAD_FOLDER_ROOT = folderNameOf(process.env.NEXT_PUBLIC_SITE_NAME) || "shop";
