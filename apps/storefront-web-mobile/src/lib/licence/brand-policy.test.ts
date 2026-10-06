import { suite, test, expect } from "vitest";
import fs from "node:fs";
import path from "node:path";
import { resolveBrand, type LocalBrand } from "./brand";
import type { BrandProfile } from "./evaluate";

// The same cases the .NET library passes (licensing/testvectors/brand-policy.json): one rule, two implementations.
const vectors = JSON.parse(fs.readFileSync(path.resolve(__dirname, "../../../../../licensing/testvectors/brand-policy.json"), "utf8"));

const expand = (v: unknown): unknown => {
    if (v === "@logoSmall") return vectors.logoSmall;
    if (v === "@oversizeLogo") return "data:image/png;base64," + "A".repeat(140000);
    if (v === "@longText") return "x".repeat(100);
    return v;
};
const expandLocal = (local: Record<string, unknown> | null): LocalBrand | null =>
    local === null ? null : (Object.fromEntries(Object.entries(local).map(([k, v]) => [k, expand(v)])) as LocalBrand);

suite("a local brand on top of the licence's brand (shared vectors)", () => {
    for (const c of vectors.cases) {
        const levels: (string | null)[] = c.levels ?? [c.level];
        const locals: (Record<string, unknown> | null)[] = c.locals ?? [c.local];
        for (const level of levels) {
            locals.forEach((local, i) => {
                test(`${c.name} [level ${JSON.stringify(level)}${locals.length > 1 ? `, local ${i + 1}` : ""}]`, () => {
                    const licence: BrandProfile | null = c.noLicenceBrand ? null : vectors.licence;
                    const result = resolveBrand(licence, level, expandLocal(local));
                    for (const [field, wantRaw] of Object.entries(c.expect)) {
                        const want = expand(wantRaw);
                        if (field === "shortNameLength") expect(result.shortName?.length).toBe(want);
                        else expect((result as unknown as Record<string, unknown>)[field] ?? null).toEqual(want);
                    }
                });
            });
        }
    }

    test("the licence's own brand is never changed", () => {
        const licence: BrandProfile = JSON.parse(JSON.stringify(vectors.licence));
        resolveBrand(licence, "full", { name: "Other", primaryColor: "#112233", poweredBy: false });
        expect(licence.name).toBe("Luzon Fresh");
        expect(licence.primaryColor).toBe("#0f6cbd");
        expect(licence.poweredBy).toBe(true);
    });
});
