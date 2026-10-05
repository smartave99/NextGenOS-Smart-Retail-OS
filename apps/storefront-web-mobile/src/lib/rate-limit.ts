import "server-only";

import { Redis } from "@upstash/redis";

interface RateLimitOptions {
    limit: number;
    windowSeconds: number;
    prefix: string;
}

interface MemoryCounter {
    count: number;
    resetAt: number;
}

export interface RateLimitResult {
    allowed: boolean;
    limit: number;
    remaining: number;
    resetAt: number;
}

const memoryCounters = new Map<string, MemoryCounter>();
let redisClient: Redis | null | undefined;

function getRedis(): Redis | null {
    if (redisClient !== undefined) return redisClient;

    const url = process.env.UPSTASH_REDIS_REST_URL;
    const token = process.env.UPSTASH_REDIS_REST_TOKEN;
    redisClient = url && token ? new Redis({ url, token }) : null;
    return redisClient;
}

function checkMemoryRateLimit(key: string, options: RateLimitOptions): RateLimitResult {
    const now = Date.now();
    const existing = memoryCounters.get(key);
    const counter = !existing || existing.resetAt <= now
        ? { count: 0, resetAt: now + options.windowSeconds * 1000 }
        : existing;

    counter.count += 1;
    memoryCounters.set(key, counter);

    if (memoryCounters.size > 5_000) {
        for (const [storedKey, value] of memoryCounters) {
            if (value.resetAt <= now) memoryCounters.delete(storedKey);
        }
    }

    return {
        allowed: counter.count <= options.limit,
        limit: options.limit,
        remaining: Math.max(0, options.limit - counter.count),
        resetAt: counter.resetAt,
    };
}

export async function checkRateLimit(
    identifier: string,
    options: RateLimitOptions
): Promise<RateLimitResult> {
    const window = Math.floor(Date.now() / (options.windowSeconds * 1000));
    const key = `rate-limit:${options.prefix}:${identifier}:${window}`;
    const redis = getRedis();

    if (redis) {
        try {
            const count = await redis.incr(key);
            if (count === 1) await redis.expire(key, options.windowSeconds + 1);

            return {
                allowed: count <= options.limit,
                limit: options.limit,
                remaining: Math.max(0, options.limit - count),
                resetAt: (window + 1) * options.windowSeconds * 1000,
            };
        } catch (error) {
            console.warn("[RateLimit] Redis unavailable; using process-local fallback:", error instanceof Error ? error.message : "unknown error");
        }
    }

    return checkMemoryRateLimit(key, options);
}

export function getRequestIdentifier(request: Request): string {
    const forwarded = request.headers.get("x-forwarded-for")?.split(",")[0]?.trim();
    return forwarded || request.headers.get("x-real-ip") || "anonymous";
}
