// @vitest-environment node
import { describe as suite, it, expect } from "vitest";
import fs from "node:fs";
import path from "node:path";
import crypto from "node:crypto";
import { evaluate, fingerprintMatches, hostMatches, describe as words, isUsable, type TrustedKey } from "./evaluate";

// The Studio signed these examples; this port must reach the same decision for every one of them.
const vectors = JSON.parse(fs.readFileSync(path.resolve(__dirname, "../../../../../licensing/testvectors/vectors.json"), "utf8"));
const keys: TrustedKey[] = vectors.publicKeys;
const list = (map: Record<string, string>) => Object.entries(map).map(([k, v]) => `${k}:${v}`).sort();

suite("licence evaluator against the Studio's signed vectors", () => {
    for (const c of vectors.cases) {
        it(`${c.name} -> ${c.expect}`, () => {
            const state = evaluate({
                licenceToken: c.lic, activationToken: c.act, revocationListToken: c.crl, fingerprint: list(c.fp), host: c.host,
                requiredModule: c.module, now: c.now, lastSeen: c.lastSeen ?? 0, trustedKeys: keys,
            });
            expect(state.status).toBe(c.expect);
        });
    }

    it("covers every status the .NET library knows", () => {
        const seen = new Set(vectors.cases.map((c: { expect: string }) => c.expect));
        for (const s of ["Valid", "Grace", "NotActivated", "NeedsCheckIn", "Expired", "NotYetValid", "Revoked", "DeviceMismatch", "DomainMismatch", "ClockTampered", "Invalid", "Missing", "ModuleNotLicensed", "Ended"]) expect(seen.has(s)).toBe(true);
    });

    it("a paid licence past its end date keeps working and says so; a trial stops; a revoked one stops", () => {
        const run = (name: string) => {
            const c = vectors.cases.find((x: { name: string }) => x.name === name);
            return evaluate({ licenceToken: c.lic, activationToken: c.act, revocationListToken: c.crl, fingerprint: list(c.fp), host: c.host, requiredModule: c.module, now: c.now, lastSeen: c.lastSeen ?? 0, trustedKeys: keys });
        };
        const ended = run("ended_paid_keeps_working");
        expect(ended.status).toBe("Ended");
        expect(isUsable(ended)).toBe(true);
        expect(words(ended)).toContain("ended on");
        expect(words(ended)).toContain("keeps working");
        expect(run("ended_trial_stops_even_if_it_says_banner").status).toBe("Expired");
        expect(isUsable(run("ended_trial_stops_even_if_it_says_banner"))).toBe(false);
        expect(run("expired").status).toBe("Expired");
        expect(run("not_ended_paid_is_valid").status).toBe("Valid");
        expect(run("ended_paid_that_is_revoked").status).toBe("Revoked");
        expect(run("end_claim_changed_after_signing").status).toBe("Invalid");
    });

    it("refuses everything when no key is trusted", () => {
        const good = vectors.cases.find((c: { name: string }) => c.name === "valid_online");
        expect(evaluate({ licenceToken: good.lic, activationToken: good.act, fingerprint: list(good.fp), now: good.now, trustedKeys: [] }).status).toBe("Invalid");
    });

    it("counts the days left in grace and says so in plain words", () => {
        const c = vectors.cases.find((x: { name: string }) => x.name === "grace_after_checkin_due");
        const s = evaluate({ licenceToken: c.lic, activationToken: c.act, fingerprint: list(c.fp), now: c.now, trustedKeys: keys });
        expect(s.graceDaysLeft).toBe(8);
        expect(isUsable(s)).toBe(true);
        expect(words(s)).toContain("8 more day");
    });
});

suite("fingerprint and host rules", () => {
    const part = (k: string) => `${k}:${crypto.createHash("sha256").update(`ngos-fp-v1:${k}:v`).digest("hex").slice(0, 32)}`;
    const stored = ["bios", "board", "cpu", "disk", "os"].map(part);
    it("needs most parts and two strong ones", () => {
        expect(fingerprintMatches(stored, 3, stored)).toBe(true);
        expect(fingerprintMatches(stored, 3, ["bios", "board", "cpu", "disk"].map(part))).toBe(true);
        expect(fingerprintMatches(stored, 3, ["cpu", "os"].map(part))).toBe(false);
        expect(fingerprintMatches(stored, 3, ["cpu", "bios"].map(part))).toBe(false);
        expect(fingerprintMatches(stored, 3, [])).toBe(false);
        expect(fingerprintMatches([], 1, stored)).toBe(false);
        expect(fingerprintMatches(undefined, 1, stored)).toBe(false);
    });
    it("matches hosts exactly or by wildcard, ignoring case and port, and refuses look-alikes", () => {
        expect(hostMatches("Shop.Example.com:443", ["shop.example.com"])).toBe(true);
        expect(hostMatches("a.b.example.org", ["*.example.org"])).toBe(true);
        expect(hostMatches("example.org", ["*.example.org"])).toBe(false);
        expect(hostMatches("shop.example.com.evil.test", ["shop.example.com"])).toBe(false);
        expect(hostMatches("evilshop.example.com", ["*.shop.example.com"])).toBe(false);
        expect(hostMatches("", ["shop.example.com"])).toBe(false);
        expect(hostMatches(null, ["shop.example.com"])).toBe(false);
        expect(hostMatches("[::1]:3000", ["localhost"])).toBe(false);
    });
});
