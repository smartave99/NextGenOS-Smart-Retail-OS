/**
 * The shop's own name, from the setting NEXT_PUBLIC_SITE_NAME (set when a customer's site is set up, for example by the
 * Brand Studio). Nothing is built in. Used in texts and AI instructions that must name the shop.
 */
export const SHOP_NAME = process.env.NEXT_PUBLIC_SITE_NAME || "our store";
