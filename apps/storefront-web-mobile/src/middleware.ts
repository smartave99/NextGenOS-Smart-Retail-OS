/**
 * Runs on every page and API request (Node.js runtime, Next.js 15.5):
 *  1. the licence gate: an unlicensed site shows a plain "not available" page, except the activation page;
 *  2. security headers for every response.
 * The licence rules are in src/lib/licence (spec: licensing/spec/LICENCE-FORMAT.md).
 */
import { NextResponse, type NextRequest } from "next/server";
import { devBypass, getLicenceState, hostOf, isActivationPath } from "@/lib/licence/manager";
import { isUsable } from "@/lib/licence/evaluate";

export const config = {
    runtime: "nodejs",
    matcher: ["/((?!_next/static|_next/image|favicon\\.ico|.*\\.(?:png|jpe?g|gif|svg|webp|avif|ico|woff2?|ttf|css|js|map)$).*)"],
};

const isDev = process.env.NODE_ENV !== "production";

/** One policy for every page. Third parties the site uses are named; anything else cannot run or be framed. */
function contentSecurityPolicy(): string {
    return [
        "default-src 'self'",
        // Next.js needs inline scripts for its own bootstrap; eval only in development.
        `script-src 'self' 'unsafe-inline'${isDev ? " 'unsafe-eval'" : ""} https://www.googletagmanager.com https://vercel.live https://va.vercel-scripts.com https://apis.google.com`,
        "style-src 'self' 'unsafe-inline' https://fonts.googleapis.com",
        "img-src 'self' data: blob: https:",
        "font-src 'self' data: https://fonts.gstatic.com",
        "media-src 'self' blob: https:",
        "connect-src 'self' https: wss:",
        "frame-src 'self' https://www.google.com https://*.firebaseapp.com https://accounts.google.com",
        "worker-src 'self' blob:",
        "manifest-src 'self'",
        "object-src 'none'",
        "base-uri 'self'",
        "form-action 'self'",
        "frame-ancestors 'self'",
        ...(isDev ? [] : ["upgrade-insecure-requests"]),
    ].join("; ");
}

function secure(res: NextResponse): NextResponse {
    res.headers.set("Content-Security-Policy", contentSecurityPolicy());
    res.headers.set("Strict-Transport-Security", "max-age=63072000; includeSubDomains; preload");
    res.headers.set("X-Content-Type-Options", "nosniff");
    res.headers.set("X-Frame-Options", "SAMEORIGIN");
    res.headers.set("Referrer-Policy", "strict-origin-when-cross-origin");
    res.headers.set("Permissions-Policy", "camera=(self), geolocation=(), microphone=(self), payment=()");
    res.headers.set("Cross-Origin-Opener-Policy", "same-origin-allow-popups");
    res.headers.set("Cross-Origin-Resource-Policy", "same-site");
    return res;
}

export function middleware(req: NextRequest) {
    const path = req.nextUrl.pathname;
    if (!devBypass() && !isActivationPath(path)) {
        const state = getLicenceState(hostOf((n) => req.headers.get(n)));
        if (!isUsable(state)) {
            if (path.startsWith("/api/")) {
                return secure(NextResponse.json({ error: "licence_required" }, { status: 402, headers: { "Cache-Control": "no-store" } }));
            }
            const url = req.nextUrl.clone();
            url.pathname = "/licence-required";
            url.search = "";
            return secure(NextResponse.rewrite(url));
        }
    }
    return secure(NextResponse.next());
}
