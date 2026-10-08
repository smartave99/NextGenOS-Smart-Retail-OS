/**
 * Decides what a licence means (licensing/spec/LICENCE-FORMAT.md, sections 3 and 10).
 * A pure function: no files, no network, no clock. It fails closed. The .NET library follows the same rules, and both
 * are tested against the same signed vectors (licensing/testvectors/vectors.json).
 */
import crypto from "node:crypto";

export type LicenceStatus =
    | "Valid" | "Grace" | "NotActivated" | "NeedsCheckIn" | "Expired" | "NotYetValid" | "Revoked"
    | "DeviceMismatch" | "DomainMismatch" | "ClockTampered" | "Invalid" | "Missing" | "ModuleNotLicensed" | "Ended";

export interface TrustedKey { kid: string; publicKey: string }

export interface BrandProfile {
    id: string; name: string; shortName?: string; legalName?: string; primaryColor?: string; accentColor?: string;
    supportEmail?: string; supportPhone?: string; supportUrl?: string; websiteUrl?: string; copyright?: string;
    logo?: string | null; poweredBy?: boolean;
}

export interface LicenceClaims {
    typ: "lic"; v: number; iss: string; kid: string; lid: string; rev: number; iat: number; nbf: number; exp: number | null;
    cust: { id: string; name: string; country: string; email: string };
    product: string; edition: string; modules: string[];
    limits: { devices: number; stores: number; users: number };
    bind: { mode: "device" | "domain" | "none"; domains: string[] };
    brand: BrandProfile | null; reseller: { id: string; name: string } | null;
    act: { online: boolean; checkInDays: number; graceDays: number; offlineDays: number };
    trial: boolean;
    /** What happens when the licence has ended (spec 4.1a): "stop" or "banner". Absent means "stop". A trial always stops. */
    end?: "stop" | "banner";
    white?: { level: "none" | "theme" | "full" };
}

/** True when the program goes on working after the end date, with a banner: the licence says "banner" and it is not a trial. */
export const keepsWorkingAfterEnd = (lic: LicenceClaims) => !lic.trial && lic.end === "banner";

export interface ActivationClaims {
    typ: "act"; lid: string; iat: number; fp: string[]; fpMin: number; next: number; until: number;
}

export interface EvaluationInput {
    licenceToken?: string | null;
    activationToken?: string | null;
    revocationListToken?: string | null;
    fingerprint?: string[];
    host?: string | null;
    requiredModule?: string | null;
    now: number;
    lastSeen?: number;
    trustedKeys: TrustedKey[];
}

export interface LicenceState {
    status: LicenceStatus;
    licence?: LicenceClaims;
    activation?: ActivationClaims;
    graceDaysLeft: number;
}

export const PRODUCT_ID = "smart-retail-os";
const CLOCK_SLACK = 24 * 3600;

class LicenceError extends Error {}

function publicKeyObject(publicKey: string): crypto.KeyObject {
    const point = Buffer.from(publicKey, "base64url");
    if (point.length !== 65 || point[0] !== 0x04) throw new LicenceError("bad key");
    return crypto.createPublicKey({
        key: { kty: "EC", crv: "P-256", x: point.subarray(1, 33).toString("base64url"), y: point.subarray(33, 65).toString("base64url") },
        format: "jwk",
    });
}

/** Checks the signature and shape of a NextGenOS token (spec section 3). Throws when anything is wrong. */
export function verifyToken<T>(token: string, keys: TrustedKey[], expectedType: string): T {
    const parts = String(token ?? "").trim().split(".");
    if (parts.length !== 3 || parts[0] !== "NGOS1") throw new LicenceError("not a token");
    let payload: Record<string, unknown>;
    try {
        payload = JSON.parse(Buffer.from(parts[1], "base64url").toString("utf8"));
    } catch {
        throw new LicenceError("damaged");
    }
    if (!payload || typeof payload !== "object" || payload.iss !== "nextgenos") throw new LicenceError("issuer");
    const key = keys.find((k) => k.kid === payload.kid);
    if (!key) throw new LicenceError("unknown key");
    const signature = Buffer.from(parts[2], "base64url");
    if (signature.length !== 64) throw new LicenceError("signature");
    const ok = crypto.verify("sha256", Buffer.from(`${parts[0]}.${parts[1]}`, "ascii"), { key: publicKeyObject(key.publicKey), dsaEncoding: "ieee-p1363" }, signature);
    if (!ok) throw new LicenceError("signature");
    if (payload.v !== 1) throw new LicenceError("version");
    if (payload.typ !== expectedType) throw new LicenceError("type");
    return payload as T;
}

/** "example.com" matches itself; "*.example.com" matches any sub-domain but not example.com. Case and port are ignored. */
export function hostMatches(host: string | null | undefined, domains: string[] | undefined): boolean {
    if (!host || !domains) return false;
    let h = host.trim().toLowerCase();
    const colon = h.lastIndexOf(":");
    if (colon > 0 && h.indexOf("]") < colon) h = h.slice(0, colon);
    for (const raw of domains) {
        const d = String(raw ?? "").trim().toLowerCase();
        if (!d) continue;
        if (d.startsWith("*.")) {
            const suffix = d.slice(1);
            if (h.length > suffix.length && h.endsWith(suffix)) return true;
        } else if (h === d) return true;
    }
    return false;
}

/** Spec section 7: enough stored parts match, and at least two strong parts (everything except the CPU id). */
export function fingerprintMatches(stored: string[] | undefined, required: number, current: string[] | undefined): boolean {
    if (!stored || stored.length === 0 || !current) return false;
    const have = new Set(current);
    const common = stored.filter((p) => have.has(p));
    const strongStored = stored.filter((p) => !p.startsWith("cpu:")).length;
    const strongCommon = common.filter((p) => !p.startsWith("cpu:")).length;
    const need = Math.max(1, Math.min(required > 0 ? required : Math.ceil(stored.length * 0.6), stored.length));
    return common.length >= need && strongCommon >= Math.min(2, strongStored);
}

export function evaluate(input: EvaluationInput): LicenceState {
    try {
        return evaluateCore(input);
    } catch {
        return { status: "Invalid", graceDaysLeft: 0 };
    }
}

function evaluateCore(input: EvaluationInput): LicenceState {
    if (!input.licenceToken || !input.licenceToken.trim()) return { status: "Missing", graceDaysLeft: 0 };

    let lic: LicenceClaims;
    try {
        lic = verifyToken<LicenceClaims>(input.licenceToken, input.trustedKeys, "lic");
    } catch {
        return { status: "Invalid", graceDaysLeft: 0 };
    }
    const state: LicenceState = { status: "Invalid", licence: lic, graceDaysLeft: 0 };
    if (lic.product !== PRODUCT_ID || !lic.lid || !lic.bind || !Array.isArray(lic.modules) || !lic.limits) return state;

    // The revocation list can only make things stricter, so a broken one is ignored.
    let crl: { iat: number; revoked: string[] } | null = null;
    if (input.revocationListToken && input.revocationListToken.trim()) {
        try {
            crl = verifyToken<{ iat: number; revoked: string[] }>(input.revocationListToken, input.trustedKeys, "crl");
        } catch {
            crl = null;
        }
    }
    if (crl && Array.isArray(crl.revoked) && crl.revoked.includes(lic.lid)) return { ...state, status: "Revoked" };

    let act: ActivationClaims | null = null;
    if (lic.bind.mode === "device" && input.activationToken && input.activationToken.trim()) {
        try {
            act = verifyToken<ActivationClaims>(input.activationToken, input.trustedKeys, "act");
        } catch {
            return state;
        }
        if (act.lid !== lic.lid || !Array.isArray(act.fp) || act.fp.length === 0) return state;
        state.activation = act;
    }

    const floor = Math.max(input.lastSeen ?? 0, lic.iat, act ? act.iat : 0, crl ? crl.iat : 0);
    if (input.now < floor - CLOCK_SLACK) return { ...state, status: "ClockTampered" };
    if (input.now < lic.nbf) return { ...state, status: "NotYetValid" };
    // Past its end date a trial (or a licence that does not say "banner") stops; a paid licence that says "banner" goes on and is shown as ended (spec 4.1a). A revoked one was refused above.
    const ended = lic.exp != null && input.now > lic.exp;
    if (ended && !keepsWorkingAfterEnd(lic)) return { ...state, status: "Expired" };
    const running: LicenceStatus = ended ? "Ended" : "Valid";
    if (input.requiredModule && !lic.modules.includes(input.requiredModule)) return { ...state, status: "ModuleNotLicensed" };

    switch (lic.bind.mode) {
        case "none":
            return { ...state, status: running };
        case "domain":
            return { ...state, status: hostMatches(input.host, lic.bind.domains) ? running : "DomainMismatch" };
        case "device": {
            if (!act) return { ...state, status: "NotActivated" };
            if (!fingerprintMatches(act.fp, act.fpMin, input.fingerprint)) return { ...state, status: "DeviceMismatch" };
            if (input.now <= act.next) return { ...state, status: running };
            if (input.now <= act.until) return { ...state, status: "Grace", graceDaysLeft: Math.max(0, Math.floor((act.until - input.now + 86399) / 86400)) };
            return { ...state, status: "NeedsCheckIn" };
        }
        default:
            return state;
    }
}

export const isUsable = (s: LicenceState) => s.status === "Valid" || s.status === "Grace" || s.status === "Ended";

/** A short sentence for the person using the site, with no technical words. */
export function describe(s: LicenceState): string {
    switch (s.status) {
        case "Valid": return "The licence is active.";
        case "Grace": return `The licence server could not be reached. The site keeps working for ${s.graceDaysLeft} more day(s).`;
        case "NotActivated": return "This site needs to be activated with a licence key.";
        case "NeedsCheckIn": return "The site has not been able to confirm its licence for too long.";
        case "Expired": return "The licence has ended. Please renew it with your supplier.";
        case "Ended": return "The licence ended on " + (s.licence?.exp ? new Date(s.licence.exp * 1000).toISOString().slice(0, 10) : "an earlier date") + ". The site keeps working. Please renew it with your supplier.";
        case "NotYetValid": return "The licence has not started yet.";
        case "Revoked": return "This licence has been withdrawn. Please contact your supplier.";
        case "DeviceMismatch": return "This licence belongs to a different server.";
        case "DomainMismatch": return "This licence is for a different web address.";
        case "ClockTampered": return "The date and time of this server look wrong.";
        case "ModuleNotLicensed": return "The licence does not include the online shop.";
        case "Missing": return "No licence was found. Please activate the site.";
        default: return "The licence could not be read. Please activate again, or contact your supplier.";
    }
}
