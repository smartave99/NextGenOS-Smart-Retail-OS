/**
 * The customer's settings for this website, read when the website starts (not when it is built).
 *
 * The website is one finished program, the same for every customer. What belongs to one customer (name, web address, country, kind of business, language, colours,
 * logo, contact lines, and the public parts of their Supabase, Firebase and Cloudinary accounts) is data in a customer folder placed beside the program:
 *   - the folder named by the setting NGOS_CUSTOMER_DIR, else ./customer (or ../customer) next to where the website runs; see ./rules.mjs for what may be in it;
 *   - with nothing there, everything is NEUTRAL: no name, no country, no currency, no company (CLAUDE.md, section 8).
 * A developer may still set the old NEXT_PUBLIC_* values in the computer's environment; they are used only where the folder says nothing. A production package needs none of them.
 *
 * On the server the folder is read once, checked with the same rules the package maker uses, and kept. The server then puts the checked settings into the page
 * (window.__NGOS_SETTINGS__, written by the layout before anything else runs), so the browser never reads a file and never sees what was not checked.
 */
import lite from "@/lib/region/generated/lite.json";
import industries from "@/lib/industry/generated/industries.json";
import { NEUTRAL_SETTINGS, readCustomerFolder } from "./rules.mjs";

export interface PublicSettings {
    siteName: string;
    shortName: string;
    tagline: string;
    /** The public address, with no slash at the end. */
    siteUrl: string;
    /** A two-letter country code with a pack, or "" for no country. */
    country: string;
    regionCode: string;
    /** The kind of business (an industry pack), or "" for the general one. */
    industry: string;
    shopPlace: string;
    /** A language such as "en" or "en-PH", or "" for the country's own. */
    language: string;
    primaryColor: string;
    accentColor: string;
    contact: { email: string; phone: string; address: string };
    /** The address of the customer's logo on this website, or "" for the built-in neutral one. */
    logoUrl: string;
    supabase: { url: string; key: string };
    firebase: { apiKey: string; authDomain: string; projectId: string; storageBucket: string; messagingSenderId: string; appId: string };
    cloudinary: { cloudName: string; apiKey: string };
}

export interface SettingsResult {
    settings: PublicSettings;
    /** Plain sentences about what in the folder was wrong and was left out. */
    problems: string[];
    /** Whether a customer folder was found. */
    found: boolean;
    /** The folder that was looked at ("" when none), for the person who looks after the website. */
    folder: string;
}

declare global {
    interface Window {
        __NGOS_SETTINGS__?: PublicSettings;
    }
}

export const neutralSettings = (): PublicSettings => JSON.parse(JSON.stringify(NEUTRAL_SETTINGS)) as PublicSettings;

/** The packs this website knows: a country or a kind of business that has no pack is refused (it would silently use the wrong money). */
export const KNOWN_COUNTRIES = Object.keys(lite as Record<string, unknown>);
export const KNOWN_INDUSTRIES = Object.keys(industries as Record<string, unknown>);

interface NodeIo {
    fs: Parameters<typeof readCustomerFolder>[1]["fs"];
    path: Parameters<typeof readCustomerFolder>[1]["path"];
}

/** Node.js's own file tools, found without naming them in the code (so that the browser's copy of this file never tries to include them). Null in a browser. */
function nodeIo(): NodeIo | null {
    const get = typeof process !== "undefined" ? (process as unknown as { getBuiltinModule?: (id: string) => unknown }).getBuiltinModule : undefined;
    if (typeof get !== "function") return null;
    const fs = get.call(process, "node:fs");
    const path = get.call(process, "node:path");
    return fs && path ? ({ fs, path } as NodeIo) : null;
}

/** The folders to look in, in order: the one named by NGOS_CUSTOMER_DIR; else ./customer, then ../customer, next to where the website runs. */
export function customerFolderCandidates(env: Record<string, string | undefined>, cwd: string, path: NodeIo["path"]): string[] {
    const named = (env.NGOS_CUSTOMER_DIR ?? "").trim();
    if (named) return [path.resolve(cwd, named)];
    return [path.join(cwd, "customer"), path.join(cwd, "..", "customer")];
}

/** Reads the customer folder now (no cache). Never throws. */
export function loadSettings(env: Record<string, string | undefined> = process.env, cwd?: string): SettingsResult {
    const io = nodeIo();
    if (!io) return { settings: neutralSettings(), problems: [], found: false, folder: "" };
    const base = cwd ?? process.cwd();
    const packs = { countries: KNOWN_COUNTRIES, industries: KNOWN_INDUSTRIES };
    const candidates = customerFolderCandidates(env, base, io.path);
    let chosen = candidates[0];
    for (const c of candidates) {
        try { if (io.fs.existsSync(c) && io.fs.statSync(c).isDirectory()) { chosen = c; break; } } catch { /* the next one */ }
    }
    const read = readCustomerFolder(chosen, io, { ...packs, environment: env });
    const problems = [...read.problems];
    if (!read.found && (env.NGOS_CUSTOMER_DIR ?? "").trim()) problems.push(`The customer folder ${chosen} (NGOS_CUSTOMER_DIR) was not found, so the website shows its neutral settings.`);
    return { settings: read.settings as PublicSettings, problems, found: read.found, folder: read.found ? chosen : "" };
}

let cache: { key: string; result: SettingsResult } | null = null;
const said = new Set<string>();
const SIGNATURE_NAMES = ["NGOS_CUSTOMER_DIR", "NEXT_PUBLIC_SITE_NAME", "NEXT_PUBLIC_SITE_URL", "NEXT_PUBLIC_COUNTRY", "NEXT_PUBLIC_REGION_CODE", "NEXT_PUBLIC_INDUSTRY", "NEXT_PUBLIC_SHOP_PLACE",
    "NEXT_PUBLIC_SUPABASE_URL", "NEXT_PUBLIC_SUPABASE_PUBLISHABLE_KEY", "NEXT_PUBLIC_SUPABASE_ANON_KEY", "NEXT_PUBLIC_FIREBASE_API_KEY", "NEXT_PUBLIC_FIREBASE_AUTH_DOMAIN",
    "NEXT_PUBLIC_FIREBASE_PROJECT_ID", "NEXT_PUBLIC_FIREBASE_STORAGE_BUCKET", "NEXT_PUBLIC_FIREBASE_MESSAGING_SENDER_ID", "NEXT_PUBLIC_FIREBASE_APP_ID",
    "NEXT_PUBLIC_CLOUDINARY_CLOUD_NAME", "NEXT_PUBLIC_CLOUDINARY_API_KEY"];

/** What was read, with the problems. On the server it is read once (and again only if the computer's own settings changed, which only a developer's test does). */
export function getSettingsResult(): SettingsResult {
    const env = typeof process !== "undefined" && process.env ? (process.env as Record<string, string | undefined>) : {};
    const key = SIGNATURE_NAMES.map((n) => `${n}=${env[n] ?? ""}`).join("\n");
    if (cache && cache.key === key) return cache.result;
    const result = loadSettings(env);
    cache = { key, result };
    for (const p of result.problems) {
        if (said.has(p)) continue;
        said.add(p);
        console.warn(`[customer settings] ${p}`);
    }
    return result;
}

/**
 * The settings for this website: in the browser the ones the server put in the page, on the server the ones read from the customer folder.
 * Safe to call from any module at any time; it never throws and never returns nothing.
 */
export function getSettings(): PublicSettings {
    if (typeof window !== "undefined" && window.__NGOS_SETTINGS__) return window.__NGOS_SETTINGS__;
    return getSettingsResult().settings;
}

/** Forgets what was read (tests, and a developer who changed the folder). */
export function resetSettingsCache(): void {
    cache = null;
    said.clear();
}

/**
 * The settings as text that can sit inside a <script> tag: the characters that could end the tag or break a line are written as escapes, so that nothing a
 * customer typed can leave the script. (The values were also checked by the rules, which refuse "<" and ">" in names.)
 */
export function settingsForScript(settings: PublicSettings): string {
    return JSON.stringify(settings).replace(/</g, "\\u003c").replace(/>/g, "\\u003e").replace(/&/g, "\\u0026").replace(/\u2028/g, "\\u2028").replace(/\u2029/g, "\\u2029");
}
