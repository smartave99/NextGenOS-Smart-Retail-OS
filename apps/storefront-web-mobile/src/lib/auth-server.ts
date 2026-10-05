import "server-only";

import type { DecodedIdToken } from "firebase-admin/auth";
import { cookies } from "next/headers";
import { getAdminAuth } from "@/lib/firebase-admin";
import { getWriteClient } from "@/lib/db-manager";
import { isOwnerAdmin } from "@/lib/owner-admins";

export const ADMIN_SESSION_COOKIE = "ngos_session";
export const ADMIN_SESSION_MAX_AGE_SECONDS = 60 * 60 * 24 * 5;

export interface AdminIdentity {
    uid: string;
    email: string;
    role: string;
    permissions: string[];
}

function normalizedEmail(token: DecodedIdToken): string | null {
    return typeof token.email === "string" ? token.email.trim().toLowerCase() : null;
}

async function resolveAdminIdentity(token: DecodedIdToken): Promise<AdminIdentity | null> {
    const email = normalizedEmail(token);
    if (!email) return null;

    // Everybody, the owner included, must have a verified e-mail address.
    if (token.email_verified !== true) return null;
    if (isOwnerAdmin(email)) {
        return { uid: token.uid, email, role: "Admin", permissions: ["*"] };
    }

    const staff = await getWriteClient().staff.findFirst({
        where: { email: { equals: email, mode: "insensitive" } },
        select: { role: true, permissions: true },
    });

    if (!staff) return null;

    return {
        uid: token.uid,
        email,
        role: staff.role,
        permissions: staff.permissions,
    };
}

export async function getAdminIdentityFromRequest(request?: Request): Promise<AdminIdentity | null> {
    const auth = getAdminAuth();
    let token: DecodedIdToken | null = null;

    const authorization = request?.headers.get("authorization");
    if (authorization?.startsWith("Bearer ")) {
        try {
            token = await auth.verifyIdToken(authorization.slice(7), true);
        } catch {
            return null;
        }
    } else {
        const cookieStore = await cookies();
        const sessionCookie = cookieStore.get(ADMIN_SESSION_COOKIE)?.value;
        if (!sessionCookie) return null;

        try {
            token = await auth.verifySessionCookie(sessionCookie, true);
        } catch {
            return null;
        }
    }

    return token ? resolveAdminIdentity(token) : null;
}

/** The shop owner only (full permissions): for settings of the system itself, such as the AI keys and the databases. Staff are refused. */
export async function getOwnerIdentityFromRequest(request?: Request): Promise<AdminIdentity | null> {
    const identity = await getAdminIdentityFromRequest(request);
    return identity && identity.permissions.includes("*") ? identity : null;
}

export async function requireAdminSession(permission?: string): Promise<AdminIdentity> {
    const identity = await getAdminIdentityFromRequest();
    if (!identity) throw new Error("UNAUTHORIZED");

    if (
        permission &&
        !identity.permissions.includes("*") &&
        !identity.permissions.includes(permission)
    ) {
        throw new Error("FORBIDDEN");
    }

    return identity;
}
