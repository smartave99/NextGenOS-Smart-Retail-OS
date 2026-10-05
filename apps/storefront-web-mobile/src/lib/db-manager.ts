/**
 * DB Manager — Neon/Postgres Multi-Client with Read Rotation + Write Fan-Out
 *
 * DATABASE_URL     → primary (all writes + reads)
 * DATABASE_URL_2   → secondary (read failover + write fan-out)
 * DATABASE_URL_3   → tertiary  (read failover + write fan-out)
 *
 * READS:  round-robin across all clients with automatic failover
 * WRITES: fan-out to ALL clients simultaneously — keeps all DBs in sync
 */

import { PrismaClient } from "@prisma/client";

export interface DBClientSyncResult {
    clientIndex: number;
    label: string;
    success: boolean;
    error?: string;
}

// ── Client pool ──────────────────────────────────────────────────────────────

interface ManagedClient {
    client: PrismaClient;
    label: string;
    url: string;
}

let pool: ManagedClient[] | null = null;
let readIndex = 0;
let lastWriteTime = 0;
const WRITE_PINNING_MS = 2000; // Pin reads to primary for 2s after a write

function buildPool(): ManagedClient[] {
    const entries = [
        { key: "DATABASE_URL", label: "Primary" },
        { key: "DATABASE_URL_2", label: "Account 2" },
        { key: "DATABASE_URL_3", label: "Account 3" },
    ];

    const built: ManagedClient[] = [];

    for (const { key, label } of entries) {
        const url = process.env[key];
        if (url && url.trim()) {
            built.push({
                client: new PrismaClient({ datasources: { db: { url } } }),
                label,
                url,
            });
        }
    }

    if (built.length === 0) {
        console.warn("[DB Manager] No DATABASE_URL found — using default Prisma env lookup.");
        built.push({ client: new PrismaClient(), label: "Primary", url: "" });
    }

    console.log(`[DB Manager] Initialized ${built.length} Prisma client(s).`);
    return built;
}

function getPool(): ManagedClient[] {
    if (!pool) pool = buildPool();
    return pool;
}

// ── Public API ───────────────────────────────────────────────────────────────

/** Primary client — use for writes to keep data consistent */
export function getWriteClient(): PrismaClient {
    return getPool()[0].client;
}

/** Round-robin read client with failover.
 *  After a recent write, reads are pinned to primary to ensure consistency. */
export function getReadClient(): PrismaClient {
    const p = getPool();

    // If a write happened recently, read from primary to avoid stale data
    if (Date.now() - lastWriteTime < WRITE_PINNING_MS) {
        return p[0].client;
    }

    const client = p[readIndex % p.length].client;
    readIndex = (readIndex + 1) % p.length;
    return client;
}

/**
 * Executes a read query with automatic failover across all clients.
 * Tries each client in turn until one succeeds, returns fallback if all fail.
 */
export async function withReadFallback<T>(
    query: (client: PrismaClient) => Promise<T>,
    fallback: T
): Promise<T> {
    const p = getPool();
    const start = readIndex % p.length;
    readIndex = (readIndex + 1) % p.length;

    for (let i = 0; i < p.length; i++) {
        const idx = (start + i) % p.length;
        try {
            return await query(p[idx].client);
        } catch (error) {
            if (i < p.length - 1) {
                console.warn(`[DB Manager] ${p[idx].label} read failed, trying next...`, error);
            } else {
                console.error(`[DB Manager] All ${p.length} clients failed. Returning fallback.`, error);
                return fallback;
            }
        }
    }

    return fallback;
}

/**
 * WRITE FAN-OUT — runs the same write operation on ALL clients simultaneously.
 *
 * ⚠️  For CREATE operations: generate the ID explicitly before calling this
 *     so all databases receive the same UUID:
 *
 *     const id = crypto.randomUUID();
 *     await fanOutWrite(client => client.product.create({ data: { id, ...rest } }));
 *
 * For UPDATE/DELETE by existing ID: just pass the operation directly.
 */
export async function fanOutWrite<T>(
    operation: (client: PrismaClient) => Promise<T>
): Promise<{ primaryResult: T; syncResults: DBClientSyncResult[] }> {
    const p = getPool();

    // Mark write timestamp so reads are pinned to primary briefly
    lastWriteTime = Date.now();

    const settled = await Promise.allSettled(
        p.map(({ client }) => operation(client))
    );

    const syncResults: DBClientSyncResult[] = settled.map((r, i) => ({
        clientIndex: i + 1,
        label: p[i].label,
        success: r.status === "fulfilled",
        error: r.status === "rejected"
            ? (r.reason instanceof Error ? r.reason.message : String(r.reason))
            : undefined,
    }));

    const primaryResult = settled[0];
    if (primaryResult.status === "rejected") {
        throw new Error(`Primary DB write failed: ${primaryResult.reason}`);
    }

    const failed = syncResults.filter(r => !r.success);
    if (failed.length > 0) {
        console.warn(
            `[DB Manager] Fan-out: ${p.length - failed.length}/${p.length} succeeded. ` +
            `Failed: ${failed.map(f => f.label).join(", ")}`
        );

        // Retry failed secondary writes once after 1 second
        setTimeout(async () => {
            for (const f of failed) {
                // Don't retry primary (index 0) — it already threw above if it failed
                if (f.clientIndex === 1) continue;
                try {
                    await operation(p[f.clientIndex - 1].client);
                    console.log(`[DB Manager] Retry succeeded for ${f.label}`);
                } catch (retryError) {
                    console.error(`[DB Manager] Retry also failed for ${f.label}:`, retryError);
                }
            }
        }, 1000);
    }

    return { primaryResult: primaryResult.value, syncResults };
}

// ── Health / Sync Status ─────────────────────────────────────────────────────

export interface DBAccountStatus {
    clientIndex: number;
    label: string;
    reachable: boolean;
    error?: string;
}

/** Pings all configured Neon accounts. Used by admin sync panel. */
export async function getDBAccountStatus(): Promise<DBAccountStatus[]> {
    const p = getPool();

    const results = await Promise.allSettled(
        p.map(({ client }) => client.$queryRaw`SELECT 1`)
    );

    return results.map((r, i) => ({
        clientIndex: i + 1,
        label: p[i].label,
        reachable: r.status === "fulfilled",
        error: r.status === "rejected"
            ? (r.reason instanceof Error ? r.reason.message : String(r.reason))
            : undefined,
    }));
}

/** Reset pool (useful after env changes or in tests) */
export function resetDBManager(): void {
    pool = null;
    readIndex = 0;
}

export { getPool as _getPool };
