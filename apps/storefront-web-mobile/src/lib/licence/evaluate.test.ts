// @vitest-environment node
import { describe as suite, it, expect } from "vitest";
import fs from "node:fs";
import path from "node:path";
import crypto from "node:crypto";
import { banner, evaluate, fingerprintMatches, hostMatches, describe as words, isUsable, type TrustedKey } from "./evaluate";

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
            // The numbers behind the banners must agree too, where the vectors give them (spec 10.1).
            if (c.endedDaysAgo !== null && c.endedDaysAgo !== undefined) expect(state.endedDaysAgo).toBe(c.endedDaysAgo);
            if (c.trialDaysLeft !== null && c.trialDaysLeft !== undefined) expect(state.trialDaysLeft).toBe(c.trialDaysLeft);
        });
    }

    it("covers every status the .NET library knows", () => {
        const seen = new Set(vectors.cases.map((c: { expect: string }) => c.expect));
        for (const s of ["Valid", "Grace", "NotActivated", "NeedsCheckIn", "Expired", "NotYetValid", "Revoked", "DeviceMismatch", "DomainMismatch", "ClockTampered", "Invalid", "Missing", "ModuleNotLicensed", "Ended"]) expect(seen.has(s)).toBe(true);
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

suite("a licence that ended: banner or stop", () => {
    const run = (name: string) => {
        const c = vectors.cases.find((x: { name: string }) => x.name === name);
        return evaluate({ licenceToken: c.lic, activationToken: c.act, revocationListToken: c.crl, fingerprint: list(c.fp), host: c.host, requiredModule: c.module, now: c.now, lastSeen: c.lastSeen ?? 0, trustedKeys: keys });
    };

    it("keeps working with a banner when the signed licence says banner", () => {
        const s = run("ended_banner_runs");
        expect(s.status).toBe("Ended");
        expect(isUsable(s)).toBe(true);
        expect(s.endedDaysAgo).toBe(5);
        expect(words(s)).toContain("ended 5 days ago");
        expect(banner(s)).toContain("ended 5 days ago");
        expect(banner(run("ended_banner_first_day_is_day_zero"))).toBe("The licence has ended, but the site keeps working. Please renew it with your supplier.");
    });

    it("stops when the licence says stop, says nothing, or says something that is not exactly banner", () => {
        for (const name of ["expired", "expired_when_on_end_is_stop", "expired_when_on_end_is_unknown_text", "expired_when_on_end_is_not_text", "expired_when_on_end_has_other_case", "trial_ended_stops", "trial_without_on_end_stops"]) {
            const s = run(name);
            expect(s.status, name).toBe("Expired");
            expect(isUsable(s), name).toBe(false);
            expect(s.endedDaysAgo, name).toBeUndefined();
            expect(banner(s), name).toBeNull();
        }
    });

    it("cannot be switched on by editing the licence: the signature breaks", () => {
        expect(run("tampered_on_end_to_banner").status).toBe("Invalid");
        expect(run("tampered_on_end_added").status).toBe("Invalid");
        expect(run("tampered_on_end_to_banner").status).not.toBe("Ended");
    });

    it("still stops for everything else: withdrawn, copied to another PC, no activation, clock set back, wrong module, wrong address, no check-in", () => {
        const expected: Record<string, string> = {
            ended_banner_still_revoked_by_crl: "Revoked", ended_banner_copied_to_another_pc: "DeviceMismatch", ended_banner_not_activated: "NotActivated",
            ended_banner_module_not_licensed: "ModuleNotLicensed", ended_banner_clock_rolled_back_by_state: "ClockTampered", ended_banner_not_yet_valid: "NotYetValid",
            ended_banner_website_other_address: "DomainMismatch", ended_banner_after_grace_needs_check_in: "NeedsCheckIn",
        };
        for (const [name, status] of Object.entries(expected)) {
            const s = run(name);
            expect(s.status, name).toBe(status);
            expect(isUsable(s), name).toBe(false);
        }
    });

    it("keeps the warning about a missed check-in when it has also ended", () => {
        const s = run("ended_banner_in_grace_stays_grace");
        expect(s.status).toBe("Grace");
        expect(s.endedDaysAgo).toBe(15);
        expect(banner(s)).toMatch(/more day.*ended 15 days ago/);
    });

    it("shows how long a trial has left, and a banner for it", () => {
        const s = run("trial_running_reports_days_left");
        expect(s.status).toBe("Valid");
        expect(s.trialDaysLeft).toBe(10);
        expect(banner(s)).toBe("This is a trial. 10 days left.");
        expect(banner(run("trial_last_day_is_one_day_left"))).toBe("This is a trial. 1 day left.");
        expect(banner(run("valid_online"))).toBeNull();
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
