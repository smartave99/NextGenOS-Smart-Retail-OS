/**
 * Reads, activates and enforces the licence of this website (licensing/spec/LICENCE-FORMAT.md).
 *
 * Where the licence comes from, in this order:
 *   1. the NGOS_LICENCE environment variable (the text of the .ngoslic file; works on read-only hosts such as Vercel);
 *   2. the file licence.ngos in LICENCE_DIR (default ./.licence), written by the activation page.
 * A licence for a website is tied to the web address it is used on, so it needs no activation: the file from the
 * Licence Studio is enough. The activation page is a convenience that fetches that file with the licence key.
 *
 * Be honest about what this protects: the site's code runs on the customer's own server, so a determined person can
 * remove this check. It stops casual copying and resale, shows who the licence is for, and carries the brand. The
 * strong protection is that NextGenOS hosts the site and the AI keys, and the contract (EULA.txt).
 *
 * Used by middleware.ts (every request), by server actions and by the layout. It imports nothing from next/headers at
 * the top, so that it can run in the middleware.
 */
import crypto from "node:crypto";
import fs from "node:fs";
import path from "node:path";
import { TRUSTED_KEYS, LICENCE_SERVER_URL } from "./defaults";
import { evaluate, verifyToken, isUsable, type LicenceState, type BrandProfile, type LicenceClaims } from "./evaluate";
import { getSettings } from "@/lib/customer/settings";

// How often the revocation list is fetched. Only the frequency can be changed by setting; the list itself must verify.
const crlRefreshMs = () => Math.max(1, Number(process.env.NGOS_CRL_REFRESH_SECONDS) || 6 * 3600) * 1000;
const CACHE_MS = 10_000;
let crlToken: string | null = null;
let crlFetchedAt = 0;
const cache = new Map<string, { at: number; state: LicenceState }>();

export const licenceDir = () => process.env.LICENCE_DIR || path.join(process.cwd(), ".licence");
export const serverUrl = () => (process.env.NGOS_LICENCE_SERVER || LICENCE_SERVER_URL || "").replace(/\/+$/, "");

/** Only while developing, and only when asked for: never in a production build. */
export const devBypass = () => process.env.NODE_ENV !== "production" && process.env.NGOS_DEV_UNLICENSED === "1";

function readFile(name: string): string | null {
    try {
        const file = path.join(licenceDir(), name);
        return fs.existsSync(file) ? fs.readFileSync(file, "utf8").trim() : null;
    } catch {
        return null;
    }
}

function writeFile(name: string, content: string): boolean {
    try {
        fs.mkdirSync(licenceDir(), { recursive: true });
        const file = path.join(licenceDir(), name);
        const temp = `${file}.${crypto.randomBytes(6).toString("hex")}.tmp`;
        fs.writeFileSync(temp, content.trim() + "\n", { mode: 0o600 });
        fs.renameSync(temp, file);
        return true;
    } catch {
        return false;
    }
}

export function readLicenceToken(): string | null {
    return (process.env.NGOS_LICENCE || "").trim() || readFile("licence.ngos");
}

/** The site's own address as configured (NGOS_SITE_HOST, or the customer's web address setting), for places with no request. */
export function configuredHost(): string | null {
    if (process.env.NGOS_SITE_HOST) return process.env.NGOS_SITE_HOST;
    const url = getSettings().siteUrl;
    return url ? url.replace(/^https?:\/\//, "").replace(/\/.*$/, "") : null;
}

/** The host of a request. X-Forwarded-Host is believed only when the site is told it sits behind a proxy. */
export function hostOf(get: (name: string) => string | null | undefined): string | null {
    if (process.env.NGOS_SITE_HOST) return process.env.NGOS_SITE_HOST;
    const forwarded = process.env.NGOS_TRUST_PROXY === "1" ? get("x-forwarded-host") : null;
    return ((forwarded || get("host") || "").split(",")[0].trim()) || null;
}

function maybeRefreshRevocations() {
    const base = serverUrl();
    if (!base || Date.now() - crlFetchedAt < crlRefreshMs()) return;
    crlFetchedAt = Date.now();
    void (async () => {
        try {
            const res = await fetch(`${base}/api/v1/crl`, { signal: AbortSignal.timeout(5000), cache: "no-store" });
            if (!res.ok) return;
            const body = (await res.json()) as { crl?: string };
            if (!body.crl) return;
            verifyToken(body.crl, TRUSTED_KEYS, "crl"); // a list we cannot verify is not kept
            crlToken = body.crl;
            writeFile("crl.ngos", body.crl);
            cache.clear();
        } catch {
            /* offline: the cached list (if any) stays in force */
        }
    })();
}

/** What the licence means right now for a website address. Cached for a few seconds. */
export function getLicenceState(host: string | null, requiredModule: string | null = "storefront"): LicenceState {
    const token = readLicenceToken();
    maybeRefreshRevocations();
    const key = `${host}|${requiredModule}|${token ? crypto.createHash("sha256").update(token).digest("hex") : ""}|${crlToken ? 1 : 0}`;
    const hit = cache.get(key);
    if (hit && Date.now() - hit.at < CACHE_MS) return hit.state;
    const state = evaluate({
        licenceToken: token,
        revocationListToken: crlToken ?? readFile("crl.ngos"),
        host, requiredModule, now: Math.floor(Date.now() / 1000), trustedKeys: TRUSTED_KEYS,
    });
    if (cache.size > 200) cache.clear();
    cache.set(key, { at: Date.now(), state });
    return state;
}

export function clearLicenceCache() { cache.clear(); }

/** Pages that must stay reachable so that an unlicensed site can be activated. */
export function isActivationPath(pathname: string | null | undefined): boolean {
    const p = pathname || "";
    return p === "/admin/licence" || p.startsWith("/admin/licence/") || p === "/licence-required";
}

/** For server actions and API routes: throws when the site is not licensed for this request. */
export async function requireLicence(): Promise<void> {
    if (devBypass()) return;
    const { headers } = await import("next/headers");
    const h = await headers();
    const state = getLicenceState(hostOf((n) => h.get(n)));
    if (!isUsable(state)) throw new Error("LICENCE_REQUIRED");
}

export interface LicenceBrand { brand: BrandProfile | null; level: "none" | "theme" | "full"; licence: LicenceClaims | null }

/**
 * The brand and white-label level of the licence, or the defaults without one. The address check is made by the middleware,
 * so here only the signature, the dates and the revocation list matter.
 */
export function getLicenceBrand(): LicenceBrand {
    if (devBypass()) return { brand: null, level: "full", licence: null };
    let state = getLicenceState(configuredHost());
    if (state.status === "DomainMismatch" && state.licence) {
        const d = state.licence.bind.domains[0] || "";
        state = getLicenceState(d.startsWith("*.") ? `www${d.slice(1)}` : d);
    }
    if (!isUsable(state) || !state.licence) return { brand: null, level: "none", licence: null };
    return { brand: state.licence.brand ?? null, level: state.licence.white?.level ?? "none", licence: state.licence };
}

// ----- Activation with a licence key (optional convenience) -----

const KEY_ALPHABET = "0123456789ABCDEFGHJKMNPQRSTVWXYZ";

export function normaliseKey(text: string): string | null {
    let s = String(text || "").toUpperCase().replace(/[^0-9A-Z]/g, "");
    if (s.startsWith("NGOS")) s = s.slice(4);
    s = s.replace(/O/g, "0").replace(/[IL]/g, "1");
    if (s.length !== 20 || [...s].some((c) => !KEY_ALPHABET.includes(c))) return null;
    return `NGOS-${s.slice(0, 5)}-${s.slice(5, 10)}-${s.slice(10, 15)}-${s.slice(15)}`;
}

function installFingerprint(): Record<string, string> {
    let id = readFile("install-id");
    if (!id) {
        id = crypto.randomBytes(16).toString("hex");
        writeFile("install-id", id);
    }
    return { os: crypto.createHash("sha256").update(`ngos-fp-v1:os:${id}`).digest("hex").slice(0, 32) };
}

export interface ActivationResult { ok: boolean; message: string; saved?: boolean; token?: string }

/** Asks the Licence Studio for the licence file belonging to a key, checks it, and keeps it. */
export async function activateWithKey(rawKey: string, host: string | null): Promise<ActivationResult> {
    const key = normaliseKey(rawKey);
    if (!key) return { ok: false, message: "That does not look like a licence key. It has 20 letters and numbers, like NGOS-ABCDE-12345-FGHJK-67890." };
    const base = serverUrl();
    if (!base) return { ok: false, message: "This build does not know where the licence server is. Ask your supplier for the licence file instead." };
    let body: { lic?: string; error?: { message?: string } };
    try {
        const res = await fetch(`${base}/api/v1/activate`, {
            method: "POST", headers: { "content-type": "application/json" }, signal: AbortSignal.timeout(20000), cache: "no-store",
            body: JSON.stringify({ key, product: "smart-retail-os", version: "storefront", fp: installFingerprint(), host: host || "website" }),
        });
        body = await res.json();
        if (!res.ok || !body.lic) return { ok: false, message: body?.error?.message || "The licence server refused the key." };
    } catch {
        return { ok: false, message: "The licence server could not be reached. Check the Internet connection and try again." };
    }
    let claims: LicenceClaims;
    try {
        claims = verifyToken<LicenceClaims>(body.lic, TRUSTED_KEYS, "lic");
    } catch {
        return { ok: false, message: "The answer did not come from NextGenOS and was not used." };
    }
    if (claims.bind.mode === "device") return { ok: false, message: "This key is for Windows PCs, not for a website. Ask your supplier for a website licence." };
    const saved = writeFile("licence.ngos", body.lic);
    clearLicenceCache();
    return saved
        ? { ok: true, saved: true, message: "The site is activated." }
        : { ok: true, saved: false, token: body.lic, message: "The licence is valid, but this server cannot store it. Put the text below into the setting NGOS_LICENCE and restart the site." };
}
