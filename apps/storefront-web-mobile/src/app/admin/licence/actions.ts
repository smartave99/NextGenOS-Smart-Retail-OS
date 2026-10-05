"use server";

import { headers } from "next/headers";
import { activateWithKey, getLicenceState, hostOf, serverUrl, type ActivationResult } from "@/lib/licence/manager";
import { describe, isUsable } from "@/lib/licence/evaluate";
import { allowServerAction } from "@/lib/server-action-rate-limit";
import { requireAdminSession } from "@/lib/auth-server";

export interface LicenceView {
    status: string;
    usable: boolean;
    message: string;
    customer?: string;
    edition?: string;
    ends?: string;
    domains?: string[];
    canActivate: boolean;
}

/** What the licence says, in words. Safe for anyone: it shows no key and nothing secret. */
export async function getLicenceView(): Promise<LicenceView> {
    const h = await headers();
    const state = getLicenceState(hostOf((n) => h.get(n)));
    const lic = state.licence;
    return {
        status: state.status,
        usable: isUsable(state),
        message: describe(state),
        customer: isUsable(state) ? lic?.cust.name : undefined,
        edition: isUsable(state) ? lic?.edition : undefined,
        ends: isUsable(state) && lic?.exp ? new Date(lic.exp * 1000).toISOString().slice(0, 10) : undefined,
        domains: isUsable(state) ? lic?.bind.domains : undefined,
        canActivate: !!serverUrl(),
    };
}

/**
 * Activates the site with a licence key. When the site already has a working licence, only a signed-in administrator may
 * replace it; an unlicensed site may be activated by anyone holding a valid key (the key is the secret).
 */
export async function activateLicenceAction(key: string): Promise<ActivationResult> {
    const h = await headers();
    if (!(await allowServerAction("licence-activate", 8, 600))) return { ok: false, message: "Too many tries. Please wait ten minutes." };
    const state = getLicenceState(hostOf((n) => h.get(n)));
    if (isUsable(state)) {
        try { await requireAdminSession(); } catch { return { ok: false, message: "Sign in as an administrator to change the licence." }; }
    }
    return activateWithKey(String(key || "").slice(0, 100), hostOf((n) => h.get(n)));
}
