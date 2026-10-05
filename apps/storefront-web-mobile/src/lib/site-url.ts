/**
 * The public address of this website, from the setting NEXT_PUBLIC_SITE_URL (for example https://shop.example.com).
 * Nothing is built in: each customer's deployment sets its own.
 */
export const SITE_URL = (process.env.NEXT_PUBLIC_SITE_URL || "http://localhost:3000").replace(/\/+$/, "");
