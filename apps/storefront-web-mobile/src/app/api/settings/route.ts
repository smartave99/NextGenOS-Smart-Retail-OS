import { NextResponse } from "next/server";
import { getSettings } from "@/lib/customer/settings";

export const dynamic = "force-dynamic";

/**
 * The customer's public settings (name, web address, country, language, colours, contact lines, logo, and the public parts of their Supabase, Firebase and
 * Cloudinary accounts), read when the website started and checked by the rules in lib/customer/rules.mjs. The same object the pages carry. Nothing private is in it:
 * the settings the website holds are only the ones the rules allow, and the licence check of the middleware stays in front of this address like any other.
 */
export async function GET() {
    return NextResponse.json(getSettings(), { headers: { "Cache-Control": "no-store" } });
}
