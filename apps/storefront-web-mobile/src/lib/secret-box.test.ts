import { describe, expect, it, vi } from "vitest";
import { randomBytes } from "node:crypto";

vi.mock("server-only", () => ({}));

import { decryptSecret, encryptSecret, isEncrypted } from "./secret-box";

const key = randomBytes(32);

describe("secret-box", () => {
    it("round-trips and never stores the secret in the clear", () => {
        const stored = encryptSecret("AIzaSy-very-secret-key", key);
        expect(isEncrypted(stored)).toBe(true);
        expect(stored).not.toContain("secret");
        expect(decryptSecret(stored, key)).toBe("AIzaSy-very-secret-key");
    });

    it("makes a different stored value each time", () => {
        expect(encryptSecret("same", key)).not.toBe(encryptSecret("same", key));
    });

    it("refuses a tampered value or the wrong key", () => {
        const stored = encryptSecret("abc", key);
        const parts = stored.split(":");
        parts[4] = parts[4].slice(0, -2) + (parts[4].endsWith("AA") ? "BB" : "AA");
        expect(() => decryptSecret(parts.join(":"), key)).toThrow();
        expect(() => decryptSecret(stored, randomBytes(32))).toThrow();
        expect(() => decryptSecret("enc:v1:onlyone", key)).toThrow();
    });

    it("returns a value stored before encryption existed as it is", () => {
        expect(decryptSecret("legacy-plain-key", key)).toBe("legacy-plain-key");
    });

    it("needs the data key in the environment", () => {
        const before = process.env.NGOS_DATA_KEY;
        delete process.env.NGOS_DATA_KEY;
        try {
            expect(() => encryptSecret("x")).toThrow(/NGOS_DATA_KEY/);
            process.env.NGOS_DATA_KEY = Buffer.alloc(16).toString("base64");
            expect(() => encryptSecret("x")).toThrow(/32 random bytes/);
        } finally {
            if (before === undefined) delete process.env.NGOS_DATA_KEY; else process.env.NGOS_DATA_KEY = before;
        }
    });
});
