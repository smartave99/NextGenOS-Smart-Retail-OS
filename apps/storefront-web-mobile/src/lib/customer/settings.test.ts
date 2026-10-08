// What a customer's settings do to the website: the website is one program for every customer, and everything that is one customer's own is read, when it starts,
// from the customer folder (docs/CUSTOMER-BUILDS.md). These tests change the folder and look at what the website says, and look at the program's files for a value
// that is fixed in them.
import { afterEach, beforeEach, describe, expect, it, vi } from "vitest";
import { existsSync, mkdirSync, mkdtempSync, readdirSync, readFileSync, rmSync, statSync, writeFileSync } from "node:fs";
import { tmpdir } from "node:os";
import { dirname, join, relative } from "node:path";
import { fileURLToPath } from "node:url";
import { loadSettings, neutralSettings, resetSettingsCache, settingsForScript, type PublicSettings } from "./settings";
import { mergeLayers, parseBrand, parseSetup, parseSettings } from "./rules.mjs";

const PNG = Buffer.concat([Buffer.from([0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a]), Buffer.alloc(40)]);
const roots: string[] = [];

/** Makes a customer folder from { 'brand.json': object | text, 'assets/logo.png': Buffer, ... }. */
function folder(files: Record<string, unknown>): string {
    const root = mkdtempSync(join(tmpdir(), "customer-folder-"));
    roots.push(root);
    for (const [name, content] of Object.entries(files)) {
        const file = join(root, ...name.split("/"));
        mkdirSync(dirname(file), { recursive: true });
        writeFileSync(file, Buffer.isBuffer(content) ? content : typeof content === "string" ? content : JSON.stringify(content));
    }
    return root;
}

const LUZON = {
    "brand.json": { schema: 1, name: "Luzon Fresh Mart", tagline: "Fresh every morning", primaryColor: "#0b6e4f", accentColor: "#c2410c", country: "PH", industry: "retail", language: "en-PH", logo: "logo.png",
        contact: { email: "hello@luzon.example", phone: "+63 2 555 0100", address: "Rizal Ave, Quezon City, Philippines" }, storefront: { siteUrl: "https://shop.luzon.example/" } },
    "assets/logo.png": PNG,
};
const SECOND = {
    "website-settings.env": "NEXT_PUBLIC_SITE_NAME=Second Shop\r\nNEXT_PUBLIC_COUNTRY=GB\r\nNEXT_PUBLIC_INDUSTRY=restaurant\r\nNEXT_PUBLIC_SITE_URL=https://second.example\r\n",
    "brand.json": { schema: 1, name: "Ignored Name", primaryColor: "#1d4ed8", language: "en-GB", contact: { address: "1 High Street, Leeds, United Kingdom" } },
};

const saved = { ...process.env };
function useFolder(dir: string | null) {
    for (const k of Object.keys(process.env)) if (k.startsWith("NEXT_PUBLIC_") || k === "NGOS_CUSTOMER_DIR") delete process.env[k];
    if (dir) process.env.NGOS_CUSTOMER_DIR = dir;
    else process.env.NGOS_CUSTOMER_DIR = join(tmpdir(), "no-such-customer-folder-" + Date.now());
    vi.resetModules();
    resetSettingsCache();
}

/** What the website's own modules say now, with a fresh start (the way a server that has just started would see them). */
async function website() {
    const region = await import("@/lib/region/lite");
    const industry = await import("@/lib/industry/lite");
    const name = await import("@/lib/shop-name");
    const url = await import("@/lib/site-url");
    const config = await import("@/types/site-config");
    return { region, industry, name, url, config: config.DEFAULT_SITE_CONFIG };
}

beforeEach(() => { vi.spyOn(console, "warn").mockImplementation(() => {}); });
afterEach(() => {
    process.env = { ...saved };
    delete (window as unknown as { __NGOS_SETTINGS__?: unknown }).__NGOS_SETTINGS__;
    for (const r of roots.splice(0)) rmSync(r, { recursive: true, force: true });
    vi.restoreAllMocks();
    vi.resetModules();
    resetSettingsCache();
});

describe("with no customer folder the website is neutral: no country, no currency, no company, no kind of shop", () => {
    it("says nothing that belongs to a market or a company", async () => {
        useFolder(null);
        const w = await website();
        expect(w.region.COUNTRY).toBe("");
        expect(w.region.COUNTRY_NAME).toBe("");
        expect(w.region.CURRENCY.symbol).toBe("");
        expect(w.region.CURRENCY.code).toBe("");
        expect(w.region.money(1234.5)).toBe("1,234.50");
        expect(w.region.moneyShort(155)).toBe("155");
        expect(w.region.LOCALE).toBe("en");
        expect(w.region.LANGUAGE).toBe("en");
        expect(w.region.SHOP_PLACE).toBe("");
        expect(w.industry.INDUSTRY_ID).toBe("generic");
        expect(w.industry.TERM.item.plural).toBe("Items");
        expect(w.name.SHOP_NAME).toBe("our store");
        expect(w.name.UPLOAD_FOLDER_ROOT).toBe("shop");
        expect(w.url.SITE_URL).toBe("http://localhost:3000");
        expect(w.config.branding.siteName).toBe("My Shop");
        expect(w.config.branding.logoUrl).toBe("/logo.png");
        expect(w.config.theme.primaryColor).toBe("#0f6cbd");
        expect(w.config.contact).toMatchObject({ email: "", phone: "", address: "" });
        const everything = JSON.stringify(w.config);
        expect(everything).not.toMatch(/₹|India|Hindi|Smart ?Avenue|Luzon|rupee|stationery|décor|soft toys/i);
        expect(w.config.seo.keywords).toEqual(["My Shop", "items online", "online shopping", "shop near me"]);
    });

    it("a folder that is missing, empty, or holds only unknown files gives the same neutral settings", () => {
        const none = loadSettings({ NGOS_CUSTOMER_DIR: join(tmpdir(), "nothing-here-" + Date.now()) }, tmpdir());
        expect(none.found).toBe(false);
        expect(none.settings).toEqual(neutralSettings());
        expect(none.problems.join(" ")).toMatch(/was not found/);
        const empty = loadSettings({ NGOS_CUSTOMER_DIR: folder({}) });
        expect(empty.found).toBe(true);
        expect(empty.settings).toEqual(neutralSettings());
        expect(empty.problems).toEqual([]);
        expect(loadSettings({ NGOS_CUSTOMER_DIR: folder({ "notes.txt": "hello" }) }).settings).toEqual(neutralSettings());
    });
});

describe("changing the customer folder changes what the website says", () => {
    it("name, address, country and money, language, colours, contact and logo follow the folder", async () => {
        useFolder(folder(LUZON));
        const a = await website();
        expect(a.name.SHOP_NAME).toBe("Luzon Fresh Mart");
        expect(a.name.UPLOAD_FOLDER_ROOT).toBe("luzon-fresh-mart");
        expect(a.url.SITE_URL).toBe("https://shop.luzon.example");
        expect(a.region.COUNTRY).toBe("PH");
        expect(a.region.COUNTRY_NAME).toBe("Philippines");
        expect(a.region.CURRENCY.code).toBe("PHP");
        expect(a.region.money(1234.5)).toBe("₱1,234.50");
        expect(a.region.LOCALE).toBe("en-PH");
        expect(a.region.LANGUAGE).toBe("en");
        expect(a.region.SHOP_PLACE).toBe("Quezon City, Philippines");
        expect(a.industry.TERM.item.plural).toBe("Products");
        expect(a.config.branding.siteName).toBe("Luzon Fresh Mart");
        expect(a.config.branding.tagline).toBe("Fresh every morning");
        expect(a.config.branding.logoUrl).toBe("/customer-assets/logo.png");
        expect(a.config.theme.primaryColor).toBe("#0b6e4f");
        expect(a.config.theme.accentColor).toBe("#c2410c");
        expect(a.config.manifest.themeColor).toBe("#0b6e4f");
        expect(a.config.contact).toMatchObject({ email: "hello@luzon.example", phone: "+63 2 555 0100", address: "Rizal Ave, Quezon City, Philippines" });
        expect(a.config.seo.jsonLd.url).toBe("https://shop.luzon.example");
        expect(a.config.seo.jsonLd.name).toBe("Luzon Fresh Mart");

        useFolder(folder(SECOND));
        const b = await website();
        expect(b.name.SHOP_NAME).toBe("Second Shop");           // website-settings.env wins over brand.json
        expect(b.url.SITE_URL).toBe("https://second.example");
        expect(b.region.COUNTRY).toBe("GB");
        expect(b.region.CURRENCY.symbol).toBe("£");
        expect(b.region.money(1234.5)).toBe("£1,234.50");
        expect(b.region.LOCALE).toBe("en-GB");
        expect(b.industry.TERM.item.plural).toBe("Menu items");
        expect(b.config.theme.primaryColor).toBe("#1d4ed8");
        expect(b.config.theme.accentColor).toBe("#0071e3");     // not set by this customer: the neutral one
        expect(b.config.branding.logoUrl).toBe("/logo.png");
        expect(b.config.seo.jsonLd.url).toBe("https://second.example");
        expect(JSON.stringify(b.config)).not.toMatch(/Luzon|₱|Philippines/);
        expect(JSON.stringify(a.config)).not.toMatch(/Second Shop|£/);
    });

    it("the language of the pages is a setting, with the country's own as the fallback", async () => {
        useFolder(folder({ "brand.json": { schema: 1, name: "Shop", country: "PH" } }));
        expect((await website()).region.LANGUAGE).toBe("en");
        useFolder(folder({ "brand.json": { schema: 1, name: "Shop", country: "PH", language: "fil" } }));
        const fil = await website();
        expect(fil.region.LANGUAGE).toBe("fil");
        expect(fil.region.LANGUAGES[0]).toBe("fil");
        expect(fil.region.LOCALE).toBe("en-PH");                // a language without a region leaves the country's locale
        useFolder(folder({ "brand.json": { schema: 1, name: "Shop", language: "de-AT" } }));
        const de = await website();
        expect(de.region.LANGUAGE).toBe("de");
        expect(de.region.LOCALE).toBe("de-AT");
        expect(de.region.COUNTRY).toBe("");                     // a language is not a country: the money stays neutral
    });

    it("what the server put in the page is what the browser's copy of the website uses", async () => {
        useFolder(null);
        const served: PublicSettings = { ...neutralSettings(), siteName: "From The Page", country: "GB", primaryColor: "#123456", logoUrl: "/customer-assets/mine.png" };
        (window as unknown as { __NGOS_SETTINGS__: PublicSettings }).__NGOS_SETTINGS__ = served;
        const w = await website();
        expect(w.name.SHOP_NAME).toBe("From The Page");
        expect(w.region.CURRENCY.symbol).toBe("£");
        expect(w.config.theme.primaryColor).toBe("#123456");
        expect(w.config.branding.logoUrl).toBe("/customer-assets/mine.png");
    });
});

describe("what the customer folder may hold, and what is refused", () => {
    it("a value that fails its rule is left out and named; the rest still counts", () => {
        const dir = folder({
            "brand.json": { name: "<b>Bad</b>", primaryColor: "#ffff00", accentColor: "red", country: "XX", industry: "spaceship", language: "english", storefront: { siteUrl: "ftp://x.example" }, logo: "../logo.png", tagline: "Good tagline" },
        });
        const r = loadSettings({ NGOS_CUSTOMER_DIR: dir });
        expect(r.settings.tagline).toBe("Good tagline");
        for (const field of ["siteName", "primaryColor", "accentColor", "country", "industry", "language", "siteUrl", "logoUrl"] as const) expect(r.settings[field], field).toBe("");
        const text = r.problems.join("\n");
        expect(text).toMatch(/the name has a character that is not allowed/);
        expect(text).toMatch(/main colour is too light/);
        expect(text).toMatch(/second colour must look like #0f6cbd/);
        expect(text).toMatch(/there is no country pack for XX/);
        expect(text).toMatch(/no industry pack called spaceship/);
        expect(text).toMatch(/the language/);
        expect(text).toMatch(/the web address/);
        expect(text).toMatch(/logo must be the name of a picture file/);
    });

    it("the checks of website-settings.env are the package maker's: a key is never put in a page, a secret key is dropped", () => {
        const dir = folder({ "website-settings.env": ["NEXT_PUBLIC_SITE_NAME=Shop", "NEXT_PUBLIC_SUPABASE_URL=https://abcd.supabase.co", "NEXT_PUBLIC_SUPABASE_PUBLISHABLE_KEY=sb_secret_abcdefghijklmnop", "DATABASE_URL=postgres://user:pw@host/db", "NEXT_PUBLIC_UNKNOWN=1"].join("\n") });
        const r = loadSettings({ NGOS_CUSTOMER_DIR: dir });
        expect(r.settings.siteName).toBe("Shop");
        expect(r.settings.supabase).toEqual({ url: "https://abcd.supabase.co", key: "" });
        const text = r.problems.join("\n");
        expect(text).toMatch(/NEXT_PUBLIC_SUPABASE_PUBLISHABLE_KEY must be the publishable key/);
        expect(text).toMatch(/DATABASE_URL is not a public setting/);
        expect(text).toMatch(/NEXT_PUBLIC_UNKNOWN is not a setting this website knows/);
        expect(JSON.stringify(r.settings)).not.toMatch(/sb_secret|postgres/);
    });

    it("a file that is not JSON, a file that is too big and a logo that is not a picture are left out, in plain words", () => {
        const dir = folder({ "brand.json": "{ not json", "setup.json": JSON.stringify({ business: { name: "Setup Shop", country: "PH", industry: "library" } }), "website-settings.env": "#".repeat(70000), "assets/logo.png": "not a picture" });
        const r = loadSettings({ NGOS_CUSTOMER_DIR: dir });
        const text = r.problems.join("\n");
        expect(text).toMatch(/brand\.json cannot be read/);
        expect(text).toMatch(/website-settings\.env is too big/);
        expect(text).toMatch(/not a real PNG picture/);
        expect(r.settings.siteName).toBe("Setup Shop");        // setup.json still counts
        expect(r.settings.country).toBe("PH");
        expect(r.settings.industry).toBe("library");
        expect(r.settings.logoUrl).toBe("");
    });

    it("the order is: website-settings.env, then brand.json, then setup.json, then the developer's own environment", () => {
        const dir = folder({
            "website-settings.env": "NEXT_PUBLIC_SITE_NAME=From the env file\n",
            "brand.json": { name: "From brand", tagline: "From brand", country: "PH" },
            "setup.json": { business: { name: "From setup", country: "GB", industry: "library" } },
        });
        const r = loadSettings({ NGOS_CUSTOMER_DIR: dir, NEXT_PUBLIC_SITE_NAME: "From the computer", NEXT_PUBLIC_SHOP_PLACE: "Somewhere", NEXT_PUBLIC_INDUSTRY: "retail" });
        expect(r.settings.siteName).toBe("From the env file");
        expect(r.settings.tagline).toBe("From brand");
        expect(r.settings.country).toBe("PH");
        expect(r.settings.industry).toBe("library");
        expect(r.settings.shopPlace).toBe("Somewhere");
        expect(mergeLayers({ env: { siteName: "A" }, brand: { siteName: "B" } }).siteName).toBe("A");
    });

    it("the developer's own environment is used only where there is no folder value, and a production package needs none of it", async () => {
        useFolder(null);
        process.env.NEXT_PUBLIC_SITE_NAME = "Dev Shop";
        process.env.NEXT_PUBLIC_COUNTRY = "GB";
        process.env.NEXT_PUBLIC_SUPABASE_URL = "http://127.0.0.1:54321";
        const w = await website();
        expect(w.name.SHOP_NAME).toBe("Dev Shop");
        expect(w.region.CURRENCY.symbol).toBe("£");
        expect(loadSettings(process.env).settings.supabase.url).toBe("http://127.0.0.1:54321");
        // The same value from a customer folder must be a secure address: a local one is for a developer only.
        expect(parseSettings("NEXT_PUBLIC_SITE_NAME=A\nNEXT_PUBLIC_SUPABASE_URL=http://127.0.0.1:54321").problems.join(" ")).toMatch(/must start with https/);
    });

    it("brand.json and setup.json are read with their own rules (a name, a country and a kind of business that exist)", () => {
        expect(parseBrand(JSON.stringify({ name: "A", country: "PH" }), { countries: ["PH"], industries: ["retail"] })).toMatchObject({ layer: { siteName: "A", country: "PH" }, problems: [] });
        expect(parseBrand(JSON.stringify({ name: "A", country: "ZZ" }), { countries: ["PH"] }).problems.join(" ")).toMatch(/no country pack for ZZ/);
        expect(parseBrand("[1]").problems.join(" ")).toMatch(/not a settings file/);
        expect(parseSetup(JSON.stringify({ business: { name: "S", country: "ph" } }), { countries: ["PH"] }).layer).toEqual({ siteName: "S", country: "PH" });
        expect(parseSetup(JSON.stringify({ business: { industry: "nope" } }), { industries: ["retail"] }).problems.join(" ")).toMatch(/no kind of business called "nope"/);
    });
});

describe("handing the settings to the page", () => {
    it("text inside a script tag cannot end the tag or break the line", () => {
        const s = { ...neutralSettings(), siteName: "</script><script>alert(1)</script>\u2028\u2029&" };
        const text = settingsForScript(s);
        expect(text).not.toMatch(/<|>|&|\u2028|\u2029/);
        expect(JSON.parse(text).siteName).toBe(s.siteName);
    });

    it("/api/settings answers with the settings the website holds, and nothing else", async () => {
        useFolder(folder(LUZON));
        const { GET } = await import("@/app/api/settings/route");
        const response = await GET();
        expect(response.headers.get("cache-control")).toBe("no-store");
        const body = await response.json();
        expect(body).toMatchObject({ siteName: "Luzon Fresh Mart", country: "PH", primaryColor: "#0b6e4f", logoUrl: "/customer-assets/logo.png" });
        expect(Object.keys(body).sort()).toEqual(Object.keys(neutralSettings()).sort());
    });

    it("/customer-assets/<name> serves the customer's logo, and nothing that is not a picture in the customer folder", async () => {
        useFolder(folder({ ...LUZON, "assets/fake.png": "this is text", "assets/art.svg": "<svg xmlns='http://www.w3.org/2000/svg'><script>alert(1)</script></svg>" }));
        const { GET } = await import("@/app/customer-assets/[name]/route");
        const get = (name: string) => GET(new Request("http://x/customer-assets/" + name), { params: Promise.resolve({ name }) });
        const logo = await get("logo.png");
        expect(logo.status).toBe(200);
        expect(logo.headers.get("content-type")).toBe("image/png");
        expect(Buffer.from(await logo.arrayBuffer()).equals(PNG)).toBe(true);
        const svg = await get("art.svg");
        expect(svg.status).toBe(200);
        expect(svg.headers.get("content-security-policy")).toMatch(/sandbox/);
        for (const name of ["brand.json", "website-settings.env", "../brand.json", "..%2Fbrand.json", "assets/logo.png", "..\\brand.json", "fake.png", "missing.png", ".env", ""]) expect((await get(name)).status, name).toBe(404);
        useFolder(null);
        const none = await import("@/app/customer-assets/[name]/route");
        expect((await none.GET(new Request("http://x/"), { params: Promise.resolve({ name: "logo.png" }) })).status).toBe(404);
    });
});

describe("nothing a customer owns is fixed in the program's files", () => {
    const root = join(dirname(fileURLToPath(import.meta.url)), "..", "..", "..");
    const walk = (dir: string): string[] => readdirSync(dir).flatMap((n) => {
        const full = join(dir, n);
        return statSync(full).isDirectory() ? (n === "generated" ? [] : walk(full)) : [full];
    });
    const sources = walk(join(root, "src")).filter((f) => /\.(tsx?|mjs)$/.test(f) && !/\.test\.(tsx?|mjs)$/.test(f));

    it("no file reads a NEXT_PUBLIC_ value from the build: they are read when the website starts, from the customer folder", () => {
        const offenders = sources.filter((f) => /process\.env\.NEXT_PUBLIC_/.test(readFileSync(f, "utf8"))).map((f) => relative(root, f));
        expect(offenders).toEqual([]);
    });

    it("no file names a company, a country's money or a kind of shop as a built-in value", () => {
        const text = sources.filter((f) => !f.includes(join("lib", "customer"))).map((f) => [relative(root, f), readFileSync(f, "utf8")] as const);
        const bad = text.filter(([, t]) => /smart ?avenue|\|\| *"IN"|\|\| *'IN'|=\s*"IN";/i.test(t)).map(([f]) => f);
        expect(bad).toEqual([]);
    });

    it("the folder reader, the rules and the neutral settings are one file that can travel with the program (plain JavaScript, nothing imported)", () => {
        const text = readFileSync(join(root, "src", "lib", "customer", "rules.mjs"), "utf8");
        expect(text).not.toMatch(/^import /m);
        expect(existsSync(join(root, "src", "lib", "customer", "rules.mjs"))).toBe(true);
    });
});
