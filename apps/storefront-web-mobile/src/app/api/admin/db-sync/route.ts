import { NextRequest, NextResponse } from "next/server";
import { getRedisAccountStatus, forceResyncKey } from "@/app/actions/blob-json";
import { getDBAccountStatus } from "@/lib/db-manager";
import { getAdminIdentityFromRequest } from "@/lib/auth-server";

/**
 * GET /api/admin/db-sync
 * Returns the health status of all Redis and Neon DB accounts.
 */
export async function GET(request: NextRequest) {
    try {
        if (!await getAdminIdentityFromRequest(request)) {
            return NextResponse.json({ success: false, error: "Unauthorized" }, { status: 401 });
        }
        const [redisStatus, dbStatus] = await Promise.all([
            getRedisAccountStatus(),
            getDBAccountStatus(),
        ]);

        return NextResponse.json({
            success: true,
            redis: redisStatus,
            neon: dbStatus,
            timestamp: new Date().toISOString(),
        });
    } catch (error) {
        return NextResponse.json(
            { success: false, error: error instanceof Error ? error.message : "Unknown error" },
            { status: 500 }
        );
    }
}

/**
 * POST /api/admin/db-sync
 * Body: { action: "resync-redis-key", key: "site_config.json" }
 *       { action: "ping" }
 */
export async function POST(req: NextRequest) {
    try {
        if (!await getAdminIdentityFromRequest(req)) {
            return NextResponse.json({ success: false, error: "Unauthorized" }, { status: 401 });
        }
        const body = await req.json();
        const { action, key } = body;

        if (action === "resync-redis-key" && key) {
            const result = await forceResyncKey(key as string);
            return NextResponse.json({ success: result.success, results: result.results });
        }

        if (action === "ping") {
            const [redisStatus, dbStatus] = await Promise.all([
                getRedisAccountStatus(),
                getDBAccountStatus(),
            ]);
            return NextResponse.json({ success: true, redis: redisStatus, neon: dbStatus });
        }

        return NextResponse.json({ success: false, error: "Unknown action" }, { status: 400 });
    } catch (error) {
        return NextResponse.json(
            { success: false, error: error instanceof Error ? error.message : "Unknown error" },
            { status: 500 }
        );
    }
}
