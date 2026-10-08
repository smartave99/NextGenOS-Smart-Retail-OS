import fs from "node:fs";
import path from "node:path";
import { NextResponse } from "next/server";
import { getSettingsResult } from "@/lib/customer/settings";
import { isPictureName, looksLikePicture } from "@/lib/customer/rules.mjs";

export const dynamic = "force-dynamic";

const TYPES: Record<string, string> = { png: "image/png", jpg: "image/jpeg", jpeg: "image/jpeg", webp: "image/webp", svg: "image/svg+xml", ico: "image/x-icon" };

/**
 * A public picture of the customer (their logo): served from the customer folder (assets/, or beside brand.json where a brand kit keeps it), never from the program's files.
 * Only a plain picture file name is accepted; a name that tries to leave the folder, or is not a real picture of its kind, is answered "not found".
 */
export async function GET(_request: Request, context: { params: Promise<{ name: string }> }) {
    const { name } = await context.params;
    const folder = getSettingsResult().folder;
    const notFound = () => new NextResponse("Not found", { status: 404, headers: { "Cache-Control": "no-store" } });
    if (!folder || typeof name !== "string" || !(isPictureName(name) || name === "favicon.ico")) return notFound();
    for (const where of [path.join(folder, "assets"), folder]) {
        const file = path.resolve(where, name);
        if (path.dirname(file) !== path.resolve(where)) continue;   // nothing but a file directly in that folder
        try {
            if (!fs.statSync(file).isFile() || fs.statSync(file).size > 3 * 1024 * 1024) continue;
            const bytes = fs.readFileSync(file);
            if (name !== "favicon.ico" && !looksLikePicture(name, bytes)) continue;
            const ext = name.split(".").pop()!.toLowerCase();
            const headers: Record<string, string> = { "Content-Type": TYPES[ext] ?? "application/octet-stream", "Cache-Control": "public, max-age=300", "X-Content-Type-Options": "nosniff" };
            // A picture in SVG form may carry a script: it is shown as a picture only, never run.
            if (ext === "svg") headers["Content-Security-Policy"] = "default-src 'none'; style-src 'unsafe-inline'; sandbox";
            return new NextResponse(new Uint8Array(bytes), { status: 200, headers });
        } catch {
            /* not in this folder: try the next */
        }
    }
    return notFound();
}
