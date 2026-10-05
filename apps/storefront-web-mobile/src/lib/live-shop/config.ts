// The Live shop section (admin panel): the owner's own Supabase project, where the shop PC running Smart Retail POS
// sends the shop's figures. Only the project's URL and its public key belong on the website; the secret key is
// refused, so it can never reach a browser.

export type LiveShopConfig =
    | { ok: true; url: string; key: string }
    | { ok: false; problem: string };

export const NOT_SET_UP =
    "Add NEXT_PUBLIC_SUPABASE_URL and NEXT_PUBLIC_SUPABASE_PUBLISHABLE_KEY to the website's settings (Supabase: Project Settings, then Data API and API Keys), then deploy again.";

export const SECRET_KEY =
    "NEXT_PUBLIC_SUPABASE_PUBLISHABLE_KEY holds the project's secret key, which must never be on a website. Replace it with the publishable (or anon public) key.";

/** The project's settings, checked. Next.js puts the NEXT_PUBLIC_ values into the page when it is built. */
export function readLiveShopConfig(
    url: string | undefined = process.env.NEXT_PUBLIC_SUPABASE_URL,
    key: string | undefined = process.env.NEXT_PUBLIC_SUPABASE_PUBLISHABLE_KEY || process.env.NEXT_PUBLIC_SUPABASE_ANON_KEY,
): LiveShopConfig {
    const address = projectUrl(url);
    const publicKey = (key ?? "").trim();
    if (!address || !publicKey) return { ok: false, problem: NOT_SET_UP };
    const role = jwtRole(publicKey);
    if (publicKey.startsWith("sb_secret_") || role === "service_role") return { ok: false, problem: SECRET_KEY };
    if (!publicKey.startsWith("sb_publishable_") && role !== "anon") return { ok: false, problem: NOT_SET_UP };
    return { ok: true, url: address, key: publicKey };
}

/** "https://abcd.supabase.co", or null. Plain http only for a project on this computer (Supabase's local setup). */
export function projectUrl(text: string | undefined): string | null {
    let url: URL;
    try {
        url = new URL((text ?? "").trim());
    } catch {
        return null;
    }
    const local = url.hostname === "localhost" || url.hostname === "127.0.0.1";
    if (!(url.protocol === "https:" || (url.protocol === "http:" && local)) || url.username || url.password
        || url.pathname.replace(/\/+$/, "") !== "" || url.search || url.hash) {
        return null;
    }
    return url.origin;
}

/** The "role" of a JSON Web Token, such as Supabase's older keys; null when the key is not one. */
export function jwtRole(key: string): string | null {
    const parts = key.split(".");
    if (parts.length !== 3 || !parts[1]) return null;
    try {
        const base64 = parts[1].replace(/-/g, "+").replace(/_/g, "/");
        const payload = JSON.parse(atob(base64.padEnd(base64.length + ((4 - (base64.length % 4)) % 4), "=")));
        return payload && typeof payload.role === "string" ? payload.role : null;
    } catch {
        return null;
    }
}
