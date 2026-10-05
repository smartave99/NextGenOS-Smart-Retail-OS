import "server-only";

import { headers } from "next/headers";
import { checkRateLimit } from "@/lib/rate-limit";

export async function allowServerAction(
    prefix: string,
    limit: number,
    windowSeconds: number
): Promise<boolean> {
    const requestHeaders = await headers();
    const identifier = requestHeaders.get("x-forwarded-for")?.split(",")[0]?.trim() ||
        requestHeaders.get("x-real-ip") ||
        "anonymous";
    const result = await checkRateLimit(identifier, { prefix, limit, windowSeconds });
    return result.allowed;
}
