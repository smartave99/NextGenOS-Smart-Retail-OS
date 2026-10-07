import { getSettings } from "@/lib/customer/settings";

/**
 * The public address of this website (for example https://shop.example.com), from the customer's settings (read when the website
 * starts: see customer/settings.ts). Nothing is built in: each customer's folder sets its own.
 */
export const SITE_URL = (getSettings().siteUrl || "http://localhost:3000").replace(/\/+$/, "");
