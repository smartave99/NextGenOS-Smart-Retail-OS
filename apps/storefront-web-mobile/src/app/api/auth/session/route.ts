import { NextRequest, NextResponse } from "next/server";
import { z } from "zod";
import { getAdminAuth } from "@/lib/firebase-admin";
import {
    ADMIN_SESSION_COOKIE,
    ADMIN_SESSION_MAX_AGE_SECONDS,
} from "@/lib/auth-server";
import { getWriteClient } from "@/lib/db-manager";
import { isOwnerAdmin } from "@/lib/owner-admins";

const sessionSchema = z.object({
    idToken: z.string().min(100).max(10_000),
});

export async function POST(request: NextRequest) {
    try {
        const payload = sessionSchema.parse(await request.json());
        const auth = getAdminAuth();
        const decoded = await auth.verifyIdToken(payload.idToken, true);
        const email = decoded.email?.trim().toLowerCase();

        if (!email || decoded.email_verified !== true) {
            return NextResponse.json({ success: false, error: "Verified email required" }, { status: 403 });
        }
        if (!isOwnerAdmin(email)) {
            const staff = await getWriteClient().staff.findFirst({
                where: { email: { equals: email, mode: "insensitive" } },
                select: { id: true },
            });
            if (!staff) {
                return NextResponse.json({ success: false, error: "Admin access required" }, { status: 403 });
            }
        }

        const sessionCookie = await auth.createSessionCookie(payload.idToken, {
            expiresIn: ADMIN_SESSION_MAX_AGE_SECONDS * 1000,
        });

        const response = NextResponse.json({ success: true });
        response.cookies.set(ADMIN_SESSION_COOKIE, sessionCookie, {
            httpOnly: true,
            secure: process.env.NODE_ENV === "production",
            sameSite: "lax",
            path: "/",
            maxAge: ADMIN_SESSION_MAX_AGE_SECONDS,
        });
        return response;
    } catch (error) {
        console.warn("[AuthSession] Session creation rejected:", error instanceof Error ? error.message : "unknown error");
        return NextResponse.json({ success: false, error: "Invalid authentication token" }, { status: 401 });
    }
}

export async function DELETE() {
    const response = NextResponse.json({ success: true });
    response.cookies.set(ADMIN_SESSION_COOKIE, "", {
        httpOnly: true,
        secure: process.env.NODE_ENV === "production",
        sameSite: "lax",
        path: "/",
        maxAge: 0,
    });
    return response;
}
