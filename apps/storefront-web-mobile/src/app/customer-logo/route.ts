// The shop's logo, served as /logo.png (next.config.ts sends that address here). The customer's own logo is a file in the folder "customer" beside the program, put there by the
// Setup Studio; a shop that has none shows the plain built-in picture (public/logo.png). Nothing of a customer is built into the program.
import { readFileSync } from "node:fs";
import { join } from "node:path";
import { readCustomerLogo } from "@/lib/runtime-settings";

export const dynamic = "force-dynamic";

const HEADERS = {
    "Content-Type": "image/png",
    "Cache-Control": "public, max-age=300",
    "X-Content-Type-Options": "nosniff",
};

export function GET(): Response {
    let bytes: Uint8Array | null = readCustomerLogo();
    if (!bytes) {
        try {
            bytes = readFileSync(join(process.cwd(), "public", "logo.png"));
        } catch {
            return new Response("No logo.", { status: 404, headers: { "Content-Type": "text/plain; charset=utf-8" } });
        }
    }
    return new Response(new Uint8Array(bytes), { status: 200, headers: HEADERS });
}
