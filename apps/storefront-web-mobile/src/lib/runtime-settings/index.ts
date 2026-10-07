/**
 * The customer's public settings, read when the website starts: its name, web address, country, kind of business, place and the public keys of its own online accounts.
 *
 * A website is built ONCE, the same for every customer (docs/SETUP-STUDIO.md). Everything that is the customer's own is data in the folder "customer", which sits beside the
 * program and which the Setup Studio fills in:
 *     customer/public-settings.json   the settings (the names are the ones the website has always had: NEXT_PUBLIC_SITE_NAME, ...)
 *     customer/brand.json             optional: the customer's brand kit (name, tagline, colours, contact)
 *     customer/logo.png               optional: the customer's logo
 *
 * Where the values come from, in this order:
 *   1. on the server, when the program was started with NGOS_CUSTOMER_DIR (the start program of the website package always sets it): that folder, and nothing else.
 *      A folder that is missing, or has a value that is not good, stops the website at its start with a plain message (see start-check.ts); nothing is half-used.
 *   2. otherwise the environment (NEXT_PUBLIC_SITE_NAME, ...): for developing the website and for the tests. The values are read when they are asked for, never built into the pages.
 *   3. in the browser: the block the layout puts in every page (<script id="ngos-public-settings" type="application/json">). It is data, not a program, so the page's security
 *      policy has nothing to allow or to forbid for it.
 *
 * No other code reads a NEXT_PUBLIC value straight from the environment: Next.js would freeze it into the build (a test looks for that). Server-only secrets never come through here.
 */
import type { SiteBrandData } from "./public-settings.mjs";
import { SETTING_NAMES, readCustomerFolder, type CheckOptions } from "./public-settings.mjs";

export type PublicSettingName =
    | "NEXT_PUBLIC_SITE_NAME"
    | "NEXT_PUBLIC_SITE_URL"
    | "NEXT_PUBLIC_COUNTRY"
    | "NEXT_PUBLIC_REGION_CODE"
    | "NEXT_PUBLIC_INDUSTRY"
    | "NEXT_PUBLIC_SHOP_PLACE"
    | "NEXT_PUBLIC_SUPABASE_URL"
    | "NEXT_PUBLIC_SUPABASE_PUBLISHABLE_KEY"
    | "NEXT_PUBLIC_SUPABASE_ANON_KEY"
    | "NEXT_PUBLIC_FIREBASE_API_KEY"
    | "NEXT_PUBLIC_FIREBASE_AUTH_DOMAIN"
    | "NEXT_PUBLIC_FIREBASE_PROJECT_ID"
    | "NEXT_PUBLIC_FIREBASE_STORAGE_BUCKET"
    | "NEXT_PUBLIC_FIREBASE_MESSAGING_SENDER_ID"
    | "NEXT_PUBLIC_FIREBASE_APP_ID"
    | "NEXT_PUBLIC_CLOUDINARY_CLOUD_NAME"
    | "NEXT_PUBLIC_CLOUDINARY_API_KEY";

export type SiteBrand = SiteBrandData;

export interface PublicSettings {
    /** Where the values came from: the customer folder, the page the browser was given, or the environment (development and tests). */
    source: "folder" | "page" | "environment";
    /** The customer's short name, when the folder says it. */
    customer: string | null;
    /** The settings that are set. */
    values: Partial<Record<PublicSettingName, string>>;
    /** What the website takes from the customer's brand kit; null when there is none. */
    brand: SiteBrand | null;
    /** Whether the customer has put a logo of their own in the folder. */
    hasLogo: boolean;
}

/** The customer's folder is missing or wrong. The message is for the person who looks after the website: plain words, what to do. */
export class CustomerFolderError extends Error {
    constructor(message: string) {
        super(message);
        this.name = "CustomerFolderError";
    }
}

export const PAGE_BLOCK_ID = "ngos-public-settings";
const KNOWN = new Set<string>(SETTING_NAMES);

// ---------------------------------------------------------------------------------------------------------------------
// The environment (development, tests)
// ---------------------------------------------------------------------------------------------------------------------

const env = (): Record<string, string | undefined> => (typeof process !== "undefined" && process.env ? process.env : {});

function fromEnvironment(): PublicSettings {
    const values: Partial<Record<PublicSettingName, string>> = {};
    const e = env();
    for (const name of SETTING_NAMES) {
        const v = e[name];   // read by a name held in a variable on purpose: Next.js freezes only the literal form (process.env followed by a dot and the name) into a build
        if (v !== undefined && v !== "") values[name as PublicSettingName] = v;
    }
    return { source: "environment", customer: null, values, brand: null, hasLogo: false };
}

// ---------------------------------------------------------------------------------------------------------------------
// The customer folder (server)
// ---------------------------------------------------------------------------------------------------------------------

/** The folder the customer's details are in, when the program was started to use one. */
export function customerDir(): string | null {
    const v = env().NGOS_CUSTOMER_DIR;
    return v && v.trim() ? v.trim() : null;
}

/** A Node.js module, fetched by name when it is needed, so that this file can also be part of the browser's code (which has no files). */
function nodeModule<T>(name: string): T {
    const get = typeof process !== "undefined" ? (process as unknown as { getBuiltinModule?: (n: string) => unknown }).getBuiltinModule : undefined;
    if (typeof get !== "function") throw new CustomerFolderError("This website needs Node.js 22 or newer to read its customer folder, and it is running on an older one.");
    return get.call(process, name) as T;
}

const LIMITS: Record<string, number> = { "public-settings.json": 32 * 1024, "brand.json": 64 * 1024, "logo.png": 3 * 1024 * 1024 };

/** The words a person reads when the folder cannot be used. */
export function folderProblemText(dir: string, problems: string[]): string {
    return [
        `The shop's details in the folder "${dir}" cannot be used:`,
        ...problems.map((p) => `  - ${p}`),
        "The NextGenOS Setup Studio writes this folder. Make the website again with the Setup Studio, or ask the person who gave you the website.",
    ].join("\n");
}

/** Reads and checks the folder, or throws a CustomerFolderError that says in plain words what is wrong. `options` can add the country and industry packs the website knows. */
export function readFolder(dir: string, options: CheckOptions = {}): PublicSettings {
    const fs = nodeModule<typeof import("node:fs")>("node:fs");
    const path = nodeModule<typeof import("node:path")>("node:path");
    const result = readCustomerFolder((name) => {
        const file = path.join(dir, name);
        let size: number;
        try {
            size = fs.statSync(file).size;
        } catch (e) {
            if ((e as NodeJS.ErrnoException).code === "ENOENT" || (e as NodeJS.ErrnoException).code === "ENOTDIR") return null;
            throw e;
        }
        if (size > (LIMITS[name] ?? 0)) throw new Error(`${name} is too big`);
        return fs.readFileSync(file);
    }, options);
    if (!result.ok) throw new CustomerFolderError(folderProblemText(dir, result.problems));
    return { source: "folder", customer: result.customer, values: result.values as PublicSettings["values"], brand: result.brand, hasLogo: result.hasLogo };
}

/** What changed in the folder, as a short text: a new copy is read only when this changes. */
function signature(dir: string): string {
    const fs = nodeModule<typeof import("node:fs")>("node:fs");
    const path = nodeModule<typeof import("node:path")>("node:path");
    return Object.keys(LIMITS).map((name) => {
        try {
            const s = fs.statSync(path.join(dir, name));
            return `${s.size}:${s.mtimeMs}`;
        } catch {
            return "-";
        }
    }).join("|");
}

let folderCache: { dir: string; key: string; at: number; settings: PublicSettings } | null = null;
const LOOK_AGAIN_MS = 5000;

function fromFolder(dir: string): PublicSettings {
    const now = Date.now();
    if (folderCache && folderCache.dir === dir && now - folderCache.at < LOOK_AGAIN_MS) return folderCache.settings;
    const key = signature(dir);
    if (folderCache && folderCache.dir === dir && folderCache.key === key) {
        folderCache.at = now;
        return folderCache.settings;
    }
    try {
        const settings = readFolder(dir);
        folderCache = { dir, key, at: now, settings };
        return settings;
    } catch (e) {
        // A folder that was good and then changed into something wrong: the website keeps what it had and says so; it has not started with it.
        if (folderCache && folderCache.dir === dir) {
            console.error(e instanceof Error ? e.message : e);
            folderCache.at = now;
            return folderCache.settings;
        }
        throw e;
    }
}

/** The customer's logo as it is in the folder, or null when they have none. Server only. */
export function readCustomerLogo(): Uint8Array | null {
    const dir = customerDir();
    if (!dir || !fromFolder(dir).hasLogo) return null;
    const fs = nodeModule<typeof import("node:fs")>("node:fs");
    const path = nodeModule<typeof import("node:path")>("node:path");
    try {
        return fs.readFileSync(path.join(dir, "logo.png"));
    } catch {
        return null;
    }
}

// ---------------------------------------------------------------------------------------------------------------------
// The page (browser)
// ---------------------------------------------------------------------------------------------------------------------

const ESCAPES: Record<string, string> = { "<": "\\u003c", ">": "\\u003e", "&": "\\u0026", "\u2028": "\\u2028", "\u2029": "\\u2029" };

/**
 * The text of the block the layout puts in every page. Only the known public settings are in it, and the characters that could end the block early are written as escapes, so
 * whatever a value holds, it stays data.
 */
export function serializeForPage(settings: PublicSettings): string {
    const values: Record<string, string> = {};
    for (const name of SETTING_NAMES) {
        const v = settings.values[name as PublicSettingName];
        if (typeof v === "string") values[name] = v;
    }
    return JSON.stringify({ schema: 1, customer: settings.customer, values, brand: settings.brand, hasLogo: settings.hasLogo }).replace(/[<>&\u2028\u2029]/g, (c) => ESCAPES[c]);
}

/** Reads what serializeForPage wrote. Anything that does not fit is left out; null when there is nothing usable. */
export function parsePageBlock(text: string | null | undefined): PublicSettings | null {
    if (!text) return null;
    let data: unknown;
    try {
        data = JSON.parse(text);
    } catch {
        return null;
    }
    if (!data || typeof data !== "object") return null;
    const d = data as { schema?: unknown; customer?: unknown; values?: unknown; brand?: unknown; hasLogo?: unknown };
    if (d.schema !== 1 || !d.values || typeof d.values !== "object") return null;
    const values: Partial<Record<PublicSettingName, string>> = {};
    for (const [k, v] of Object.entries(d.values as Record<string, unknown>)) if (KNOWN.has(k) && typeof v === "string") values[k as PublicSettingName] = v;
    return {
        source: "page",
        customer: typeof d.customer === "string" ? d.customer : null,
        values,
        brand: d.brand && typeof d.brand === "object" ? (d.brand as SiteBrand) : null,
        hasLogo: d.hasLogo === true,
    };
}

let pageCache: PublicSettings | null = null;

function fromPage(): PublicSettings | null {
    if (pageCache) return pageCache;
    if (typeof document === "undefined") return null;
    const page = parsePageBlock(document.getElementById(PAGE_BLOCK_ID)?.textContent);
    if (page) pageCache = page;
    return page;
}

// ---------------------------------------------------------------------------------------------------------------------
// The getters
// ---------------------------------------------------------------------------------------------------------------------

/** The customer's public settings, wherever this code runs. */
export function getPublicSettings(): PublicSettings {
    if (typeof window !== "undefined") return fromPage() ?? fromEnvironment();
    const dir = customerDir();
    return dir ? fromFolder(dir) : fromEnvironment();
}

/** One setting, or undefined when it is not set. Used wherever the website used to read these values at build time; the same value gives the same result. */
export function publicSetting(name: PublicSettingName): string | undefined {
    if (typeof window !== "undefined") {
        const page = fromPage();
        return page ? page.values[name] : env()[name];
    }
    const dir = customerDir();
    return dir ? fromFolder(dir).values[name] : env()[name];
}

/** For the tests: forget what was read, so that the next read looks again. */
export function forgetPublicSettings(): void {
    folderCache = null;
    pageCache = null;
}
