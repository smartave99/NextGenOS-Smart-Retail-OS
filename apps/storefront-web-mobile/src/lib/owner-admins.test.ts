import { afterEach, describe, expect, it } from "vitest";
import { isOwnerAdmin, ownerAdminEmails } from "./owner-admins";

describe("owner admins", () => {
    afterEach(() => { delete process.env.OWNER_ADMIN_EMAILS; });

    it("is nobody when the setting is empty (nothing is built into the code)", () => {
        expect(ownerAdminEmails()).toEqual([]);
        expect(isOwnerAdmin("admin@demomart99.com")).toBe(false);
        expect(isOwnerAdmin("anyone@example.com")).toBe(false);
    });

    it("reads a comma-separated list, ignoring case, spaces and junk", () => {
        process.env.OWNER_ADMIN_EMAILS = " Boss@Shop.example , second@shop.example,not-an-email,, ";
        expect(ownerAdminEmails()).toEqual(["boss@shop.example", "second@shop.example"]);
        expect(isOwnerAdmin("BOSS@shop.example")).toBe(true);
        expect(isOwnerAdmin("third@shop.example")).toBe(false);
        expect(isOwnerAdmin(null)).toBe(false);
        expect(isOwnerAdmin(undefined)).toBe(false);
    });
});
