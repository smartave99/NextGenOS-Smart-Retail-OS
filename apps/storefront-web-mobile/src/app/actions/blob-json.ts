import "server-only";

import { Redis } from "@upstash/redis";
import { revalidateTag } from "next/cache";

/**
 * blob-json.ts — Upstash Redis JSON store with WRITE FAN-OUT
 *
 * On every write, data is pushed to ALL configured Redis accounts simultaneously.
 * On reads, the first available healthy account is used (rotation/fallback).
 *
 * Accounts are configured via:
 *   UPSTASH_REDIS_REST_URL / TOKEN         (default/fallback)
 *   UPSTASH_REDIS_REST_URL_1 / TOKEN_1     (account 1)
 *   UPSTASH_REDIS_REST_URL_2 / TOKEN_2     (account 2)
 *   UPSTASH_REDIS_REST_URL_3 / TOKEN_3     (account 3)
 */

export interface ClientSyncResult {
    clientIndex: number;       // 1-based
    label: string;             // e.g. "Account 1"
    success: boolean;
    error?: string;
}

// ── Client pool ──────────────────────────────────────────────────────────────

let cachedRedisClients: { client: Redis; label: string }[] | null = null;

function getRedisClients(): { client: Redis; label: string }[] {
    if (cachedRedisClients) return cachedRedisClients;

    const configs: { url: string; token: string; label: string }[] = [];

    // Numbered accounts (1, 2, 3)
    for (let i = 1; i <= 3; i++) {
        const url = process.env[`UPSTASH_REDIS_REST_URL_${i}`];
        const token = process.env[`UPSTASH_REDIS_REST_TOKEN_${i}`];
        if (url && token) {
            configs.push({ url, token, label: `Account ${i}` });
        }
    }

    // Default/fallback account
    const defaultUrl = process.env.UPSTASH_REDIS_REST_URL;
    const defaultToken = process.env.UPSTASH_REDIS_REST_TOKEN;
    if (defaultUrl && defaultToken && !configs.some(c => c.url === defaultUrl)) {
        configs.push({ url: defaultUrl, token: defaultToken, label: "Default" });
    }

    if (configs.length === 0) {
        console.warn("[Redis JSON] No Redis environment variables found.");
        cachedRedisClients = [];
    } else {
        cachedRedisClients = configs.map(c => ({
            client: new Redis({ url: c.url, token: c.token }),
            label: c.label,
        }));
        console.log(`[Redis JSON] Initialized ${cachedRedisClients.length} Redis client(s).`);
    }

    return cachedRedisClients;
}

function isLimitError(error: unknown): boolean {
    const msg = error instanceof Error ? error.message.toLowerCase() : String(error).toLowerCase();
    return msg.includes("limit") || msg.includes("quota") || msg.includes("429") || msg.includes("402") || msg.includes("exceeded");
}

// ── READ — rotation/fallback ─────────────────────────────────────────────────

export async function getBlobJson<T>(filename: string, defaultData: T): Promise<T> {
    const pool = getRedisClients();

    if (pool.length === 0) {
        console.warn(`[Redis JSON] No Redis clients — returning default for ${filename}.`);
        return defaultData;
    }

    for (let i = 0; i < pool.length; i++) {
        try {
            const data = await pool[i].client.get<T>(filename);
            if (data === null || data === undefined) return defaultData;
            return data;
        } catch (error) {
            if (isLimitError(error) && i < pool.length - 1) {
                console.warn(`[Redis JSON] ${pool[i].label} hit limit on GET ${filename}. Rotating...`);
                continue;
            }
            console.error(`[Redis JSON] Error reading ${filename} from ${pool[i].label}:`, error);
            if (i === pool.length - 1) return defaultData;
        }
    }

    return defaultData;
}

// ── WRITE — fan-out to ALL accounts ─────────────────────────────────────────

/**
 * Writes data to ALL Redis accounts simultaneously.
 * Returns per-account sync results so the admin panel can show which succeeded.
 */
export async function updateBlobJson<T>(
    filename: string,
    data: T
): Promise<{ success: boolean; results: ClientSyncResult[]; error?: string }> {
    const pool = getRedisClients();

    if (pool.length === 0) {
        return { success: false, results: [], error: "No Redis clients configured." };
    }

    // Fan-out: write to ALL accounts in parallel
    const settled = await Promise.allSettled(
        pool.map(({ client }) => client.set(filename, data))
    );

    const results: ClientSyncResult[] = settled.map((result, i) => ({
        clientIndex: i + 1,
        label: pool[i].label,
        success: result.status === "fulfilled",
        error: result.status === "rejected"
            ? (result.reason instanceof Error ? result.reason.message : String(result.reason))
            : undefined,
    }));

    const anySuccess = results.some(r => r.success);
    const allSuccess = results.every(r => r.success);

    if (anySuccess) {
        // Invalidate Next.js cache regardless of partial failure
        revalidateTag(`blob-${filename}`);
        revalidateTag("blob-url");
    }

    const failed = results.filter(r => !r.success);
    if (failed.length > 0) {
        console.warn(`[Redis JSON] Fan-out for "${filename}": ${results.length - failed.length}/${results.length} succeeded.`);
    } else {
        console.log(`[Redis JSON] Fan-out for "${filename}": all ${results.length} accounts updated.`);
    }

    return {
        success: anySuccess,
        results,
        error: allSuccess ? undefined : `${failed.length} account(s) failed to sync.`,
    };
}

// ── SYNC STATUS — per account health check ────────────────────────────────────

export interface RedisSyncStatus {
    label: string;
    clientIndex: number;
    reachable: boolean;
    error?: string;
}

/**
 * Pings all configured Redis accounts and returns their health status.
 * Used by the admin sync panel.
 */
export async function getRedisAccountStatus(): Promise<RedisSyncStatus[]> {
    const pool = getRedisClients();

    if (pool.length === 0) return [];

    const results = await Promise.allSettled(
        pool.map(({ client }) => client.ping())
    );

    return results.map((r, i) => ({
        label: pool[i].label,
        clientIndex: i + 1,
        reachable: r.status === "fulfilled",
        error: r.status === "rejected"
            ? (r.reason instanceof Error ? r.reason.message : String(r.reason))
            : undefined,
    }));
}

/**
 * Forces a specific key to sync from the primary (first healthy) account
 * to all other accounts.
 */
export async function forceResyncKey(filename: string): Promise<{ success: boolean; results: ClientSyncResult[] }> {
    const pool = getRedisClients();
    if (pool.length === 0) return { success: false, results: [] };

    // Read from primary
    let data: unknown = null;
    for (const { client, label } of pool) {
        try {
            data = await client.get(filename);
            if (data !== null && data !== undefined) {
                console.log(`[Redis JSON] Read "${filename}" from ${label} for re-sync.`);
                break;
            }
        } catch {
            continue;
        }
    }

    if (data === null || data === undefined) {
        return { success: false, results: [] };
    }

    // Write to ALL
    const settled = await Promise.allSettled(
        pool.map(({ client }) => client.set(filename, data))
    );

    const results: ClientSyncResult[] = settled.map((r, i) => ({
        clientIndex: i + 1,
        label: pool[i].label,
        success: r.status === "fulfilled",
        error: r.status === "rejected"
            ? (r.reason instanceof Error ? r.reason.message : String(r.reason))
            : undefined,
    }));

    revalidateTag(`blob-${filename}`);
    return { success: results.some(r => r.success), results };
}
