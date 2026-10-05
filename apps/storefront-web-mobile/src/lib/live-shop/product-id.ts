// The place on this website of a product that came from the shop PC. It is worked out from the shop and the POS product's
// number, so the same product always lands on the same website product: approving it again after a price change updates it,
// and an approval that was repeated (the connection dropped after the product was made) never makes a second one.
import "server-only";

import { createHash } from "node:crypto";

/** Ours alone: a UUID made for these products, so no other name can give the same id. */
const NAMESPACE = "5e1b2d44-8a6f-5c0e-9d37-2a4f7b91c6d8";

/** A name-based (version 5) UUID, as RFC 4122 defines it. */
export function uuidV5(name: string, namespace: string): string {
    const space = Buffer.from(namespace.replace(/-/g, ""), "hex");
    const hash = createHash("sha1").update(space).update(name, "utf8").digest();
    hash[6] = (hash[6] & 0x0f) | 0x50;
    hash[8] = (hash[8] & 0x3f) | 0x80;
    const hex = hash.subarray(0, 16).toString("hex");
    return `${hex.slice(0, 8)}-${hex.slice(8, 12)}-${hex.slice(12, 16)}-${hex.slice(16, 20)}-${hex.slice(20, 32)}`;
}

export const shopProductId = (shopId: string, productKey: string): string => uuidV5(`smart-retail-pos:${shopId.toLowerCase()}:${productKey}`, NAMESPACE);
