import "server-only";

import { createCipheriv, createDecipheriv, randomBytes } from "node:crypto";

/**
 * Secrets kept in the database (AI service keys) are stored encrypted with AES-256-GCM, under a key that lives only in the
 * server's environment (NGOS_DATA_KEY), never in the database. A copy of the database alone shows no secret.
 *
 * Stored form: enc:v1:<iv>:<tag>:<ciphertext>, each part base64url.
 */
const PREFIX = "enc:v1:";

function dataKey(): Buffer {
    const raw = process.env.NGOS_DATA_KEY?.trim();
    if (!raw) {
        throw new Error("NGOS_DATA_KEY is not set. Make one with: node -e \"console.log(require('crypto').randomBytes(32).toString('base64'))\"");
    }
    const key = Buffer.from(raw, "base64");
    if (key.length !== 32) throw new Error("NGOS_DATA_KEY must be 32 random bytes, base64 encoded.");
    return key;
}

export function isEncrypted(value: string): boolean {
    return value.startsWith(PREFIX);
}

export function encryptSecret(plain: string, key: Buffer = dataKey()): string {
    const iv = randomBytes(12);
    const cipher = createCipheriv("aes-256-gcm", key, iv);
    const body = Buffer.concat([cipher.update(plain, "utf8"), cipher.final()]);
    return `${PREFIX}${iv.toString("base64url")}:${cipher.getAuthTag().toString("base64url")}:${body.toString("base64url")}`;
}

/** Reads a stored secret. A value stored before encryption was added (no prefix) is returned as it is, to be encrypted on next save. */
export function decryptSecret(stored: string, key?: Buffer): string {
    if (!isEncrypted(stored)) return stored;
    const [iv, tag, body] = stored.slice(PREFIX.length).split(":");
    if (!iv || !tag || !body) throw new Error("The stored secret is damaged.");
    const decipher = createDecipheriv("aes-256-gcm", key ?? dataKey(), Buffer.from(iv, "base64url"));
    decipher.setAuthTag(Buffer.from(tag, "base64url"));
    return Buffer.concat([decipher.update(Buffer.from(body, "base64url")), decipher.final()]).toString("utf8");
}
