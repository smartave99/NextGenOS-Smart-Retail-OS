import "server-only";

import { createHash } from "node:crypto";
import { Redis } from "@upstash/redis";

interface MemoryEntry {
    value: unknown;
    expiresAt: number;
}

const CACHE_SCHEMA_VERSION = "v2";
const MAX_MEMORY_ENTRIES = 500;
const memoryCache = new Map<string, MemoryEntry>();
const inFlight = new Map<string, Promise<unknown>>();
let memoryCatalogVersion = 0;
let redisClient: Redis | null | undefined;

function getRedis(): Redis | null {
    if (redisClient !== undefined) return redisClient;

    const url = process.env.UPSTASH_REDIS_REST_URL;
    const token = process.env.UPSTASH_REDIS_REST_TOKEN;
    redisClient = url && token ? new Redis({ url, token }) : null;
    return redisClient;
}

function stableSerialize(value: unknown): string {
    if (value === null || typeof value !== "object") {
        return JSON.stringify(value);
    }

    if (Array.isArray(value)) {
        return `[${value.map(stableSerialize).join(",")}]`;
    }

    const record = value as Record<string, unknown>;
    return `{${Object.keys(record)
        .sort()
        .map(key => `${JSON.stringify(key)}:${stableSerialize(record[key])}`)
        .join(",")}}`;
}

export function createCacheDigest(value: unknown): string {
    return createHash("sha256").update(stableSerialize(value)).digest("hex");
}

function cacheKey(namespace: string, fingerprint: unknown): string {
    const safeNamespace = namespace.replace(/[^a-zA-Z0-9:_-]/g, "-").slice(0, 80);
    return `ai-cache:${CACHE_SCHEMA_VERSION}:${safeNamespace}:${createCacheDigest(fingerprint)}`;
}

function setMemory(key: string, value: unknown, ttlSeconds: number): void {
    if (memoryCache.size >= MAX_MEMORY_ENTRIES) {
        const oldestKey = memoryCache.keys().next().value;
        if (oldestKey) memoryCache.delete(oldestKey);
    }

    memoryCache.set(key, {
        value,
        expiresAt: Date.now() + ttlSeconds * 1000,
    });
}

function getMemory<T>(key: string): T | null {
    const entry = memoryCache.get(key);
    if (!entry) return null;

    if (entry.expiresAt <= Date.now()) {
        memoryCache.delete(key);
        return null;
    }

    return entry.value as T;
}

export async function getCachedAIResponse<T>(
    namespace: string,
    fingerprint: unknown
): Promise<T | null> {
    const key = cacheKey(namespace, fingerprint);
    const redis = getRedis();

    if (redis) {
        try {
            const value = await redis.get<T>(key);
            if (value !== null && value !== undefined) return value;
        } catch (error) {
            console.warn("[AIResponseCache] Redis read failed; using memory fallback:", error instanceof Error ? error.message : "unknown error");
        }
    }

    return getMemory<T>(key);
}

export async function setCachedAIResponse<T>(
    namespace: string,
    fingerprint: unknown,
    value: T,
    ttlSeconds: number
): Promise<void> {
    if (!Number.isFinite(ttlSeconds) || ttlSeconds <= 0) return;

    const key = cacheKey(namespace, fingerprint);
    const normalizedTtl = Math.max(1, Math.floor(ttlSeconds));
    const redis = getRedis();

    if (redis) {
        try {
            await redis.set(key, value, { ex: normalizedTtl });
            return;
        } catch (error) {
            console.warn("[AIResponseCache] Redis write failed; using memory fallback:", error instanceof Error ? error.message : "unknown error");
        }
    }

    setMemory(key, value, normalizedTtl);
}

/** Prevents duplicate identical calls in the same process as well as caching the result. */
export async function withAIResponseCache<T>(options: {
    namespace: string;
    fingerprint: unknown;
    ttlSeconds: number;
    generate: () => Promise<T>;
}): Promise<T> {
    const existing = await getCachedAIResponse<T>(options.namespace, options.fingerprint);
    if (existing !== null) return existing;

    const key = cacheKey(options.namespace, options.fingerprint);
    const pending = inFlight.get(key) as Promise<T> | undefined;
    if (pending) return pending;

    const generated = options.generate()
        .then(async value => {
            await setCachedAIResponse(
                options.namespace,
                options.fingerprint,
                value,
                options.ttlSeconds
            );
            return value;
        })
        .finally(() => {
            inFlight.delete(key);
        });

    inFlight.set(key, generated);
    return generated;
}

export async function getCatalogAIRevision(): Promise<number> {
    const redis = getRedis();
    if (redis) {
        try {
            const value = await redis.get<number>(`ai-cache:${CACHE_SCHEMA_VERSION}:catalog-revision`);
            return Number(value || 0);
        } catch (error) {
            console.warn("[AIResponseCache] Catalog revision read failed; using memory fallback:", error instanceof Error ? error.message : "unknown error");
        }
    }

    return memoryCatalogVersion;
}

/**
 * Versioned invalidation avoids expensive Redis key scans. Every product
 * mutation advances the revision, making all prior recommendation keys stale.
 */
export async function bumpCatalogAIRevision(): Promise<number> {
    const redis = getRedis();
    if (redis) {
        try {
            return Number(await redis.incr(`ai-cache:${CACHE_SCHEMA_VERSION}:catalog-revision`));
        } catch (error) {
            console.warn("[AIResponseCache] Catalog revision update failed; using memory fallback:", error instanceof Error ? error.message : "unknown error");
        }
    }

    memoryCatalogVersion += 1;
    return memoryCatalogVersion;
}

export function resetAIResponseCacheForTests(): void {
    memoryCache.clear();
    inFlight.clear();
    memoryCatalogVersion = 0;
    redisClient = undefined;
}

