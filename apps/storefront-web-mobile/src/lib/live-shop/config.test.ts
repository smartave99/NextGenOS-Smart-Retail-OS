import { describe, expect, it } from "vitest";
import { NOT_SET_UP, SECRET_KEY, jwtRole, projectUrl, readLiveShopConfig } from "./config";

/** A token like Supabase's older keys, with this role (its signature is not checked here). */
const jwt = (role: string) => {
    const part = (o: object) => btoa(JSON.stringify(o)).replace(/=+$/, "").replace(/\+/g, "-").replace(/\//g, "_");
    return `${part({ alg: "HS256", typ: "JWT" })}.${part({ iss: "supabase", ref: "abcd", role })}.c2lnbmF0dXJl`;
};

describe("readLiveShopConfig", () => {
    it("takes the project URL and its publishable key", () => {
        expect(readLiveShopConfig(" https://abcd.supabase.co/ ", " sb_publishable_abc ")).toEqual({
            ok: true, url: "https://abcd.supabase.co", key: "sb_publishable_abc",
        });
    });

    it("takes an older anon public key", () => {
        const anon = jwt("anon");
        expect(readLiveShopConfig("https://abcd.supabase.co", anon)).toEqual({ ok: true, url: "https://abcd.supabase.co", key: anon });
    });

    it("refuses the secret key, new or old, so it never reaches a browser", () => {
        expect(readLiveShopConfig("https://abcd.supabase.co", "sb_secret_abc")).toEqual({ ok: false, problem: SECRET_KEY });
        expect(readLiveShopConfig("https://abcd.supabase.co", jwt("service_role"))).toEqual({ ok: false, problem: SECRET_KEY });
    });

    it.each([
        ["", "sb_publishable_abc"],
        ["https://abcd.supabase.co", ""],
        ["http://abcd.supabase.co", "sb_publishable_abc"],
        ["https://abcd.supabase.co/rest/v1", "sb_publishable_abc"],
        ["javascript:alert(1)", "sb_publishable_abc"],
        ["https://abcd.supabase.co", "not-a-key"],
        ["https://abcd.supabase.co", jwt("authenticated")],
    ])("says what to set for %s and %s", (url, key) => {
        expect(readLiveShopConfig(url, key)).toEqual({ ok: false, problem: NOT_SET_UP });
    });
});

describe("projectUrl", () => {
    it("allows plain http only for a project on this computer", () => {
        expect(projectUrl("http://127.0.0.1:54321")).toBe("http://127.0.0.1:54321");
        expect(projectUrl("http://localhost:54321/")).toBe("http://localhost:54321");
        expect(projectUrl("http://abcd.supabase.co")).toBeNull();
        expect(projectUrl("https://user:pass@abcd.supabase.co")).toBeNull();
        expect(projectUrl("https://abcd.supabase.co?x=1")).toBeNull();
    });
});

describe("jwtRole", () => {
    it("reads a token's role, and nothing else", () => {
        expect(jwtRole(jwt("anon"))).toBe("anon");
        expect(jwtRole("sb_publishable_abc")).toBeNull();
        expect(jwtRole("a.b.c")).toBeNull();
    });
});
