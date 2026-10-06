import { afterEach, describe, expect, it, vi } from "vitest";

import { folderNameOf } from "./shop-name";

async function rootFor(siteName: string | undefined): Promise<string> {
    vi.resetModules();
    if (siteName === undefined) vi.stubEnv("NEXT_PUBLIC_SITE_NAME", "");
    else vi.stubEnv("NEXT_PUBLIC_SITE_NAME", siteName);
    return (await import("./shop-name")).UPLOAD_FOLDER_ROOT;
}

describe("the folder uploads go under", () => {
    afterEach(() => {
        vi.unstubAllEnvs();
        vi.resetModules();
    });

    it("is a plain neutral name when the shop has no name set, never a company's", async () => {
        const root = await rootFor(undefined);
        expect(root).toBe("shop");
    });

    it("follows the shop's own name, so another customer gets another folder", async () => {
        expect(await rootFor("Luzon Fresh Mart")).toBe("luzon-fresh-mart");
        expect(await rootFor("Example Shop")).toBe("example-shop");
    });

    it("turns a name into a safe folder name: letters, digits and single hyphens, not too long", () => {
        expect(folderNameOf("  Café  &  Bar / No.1 ")).toBe("cafe-bar-no-1");
        expect(folderNameOf("../../etc")).toBe("etc");
        expect(folderNameOf("x".repeat(100)).length).toBeLessThanOrEqual(40);
        expect(folderNameOf("***")).toBe("");
        expect(folderNameOf(undefined)).toBe("");
    });
});
