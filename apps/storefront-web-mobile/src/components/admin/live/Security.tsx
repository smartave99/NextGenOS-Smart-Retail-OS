"use client";

import { useCallback, useEffect, useState, type FormEvent } from "react";
import type { SupabaseClient } from "@supabase/supabase-js";
import { ShieldCheck, ShieldOff } from "lucide-react";
import { Card, CardHead, Field, Note, Pill, inputClass, primaryButton, softButton } from "./ui";

interface Enrolling { id: string; qr: string; secret: string }

/**
 * The second sign-in step, the owner's choice: a 6-digit code from an authenticator app (Google Authenticator,
 * Microsoft Authenticator…). Once it is on, Supabase itself refuses the shop's data to a sign-in without the code.
 */
export default function Security({ db }: { db: SupabaseClient }) {
    const [factorId, setFactorId] = useState<string | null | undefined>(undefined);
    const [enrolling, setEnrolling] = useState<Enrolling | null>(null);
    const [code, setCode] = useState("");
    const [message, setMessage] = useState<{ text: string; problem: boolean } | null>(null);
    const [busy, setBusy] = useState(false);

    const load = useCallback(async () => {
        const { data, error } = await db.auth.mfa.listFactors();
        if (error) setMessage({ text: error.message, problem: true });
        setFactorId(data?.totp?.[0]?.id ?? null);
    }, [db]);

    useEffect(() => {
        void load();
    }, [load]);

    async function turnOn() {
        setBusy(true);
        setMessage(null);
        // An earlier try that was never confirmed is removed first.
        const { data: list } = await db.auth.mfa.listFactors();
        for (const factor of list?.all ?? []) {
            if (factor.factor_type === "totp" && factor.status === "unverified") await db.auth.mfa.unenroll({ factorId: factor.id });
        }
        const { data, error } = await db.auth.mfa.enroll({ factorType: "totp", friendlyName: "Live shop" });
        setBusy(false);
        if (error || !data) {
            setMessage({ text: error?.message ?? "The authenticator app could not be added.", problem: true });
            return;
        }
        const qr = data.totp.qr_code.startsWith("data:image/svg+xml") ? data.totp.qr_code : "";
        setEnrolling({ id: data.id, qr, secret: data.totp.secret });
    }

    async function confirm(event: FormEvent) {
        event.preventDefault();
        if (!enrolling) return;
        setBusy(true);
        const { error } = await db.auth.mfa.challengeAndVerify({ factorId: enrolling.id, code: code.replace(/\s/g, "") });
        setBusy(false);
        if (error) {
            setMessage({ text: error.message, problem: true });
            return;
        }
        setEnrolling(null);
        setCode("");
        setMessage({ text: "Two-step sign-in is on. From now on, signing in also asks for the app's code.", problem: false });
        await load();
    }

    async function turnOff() {
        if (!factorId || !window.confirm("Turn off two-step sign-in? Signing in will then need only the password.")) return;
        setBusy(true);
        const { error } = await db.auth.mfa.unenroll({ factorId });
        setBusy(false);
        setMessage(error ? { text: error.message, problem: true } : { text: "Two-step sign-in is off.", problem: false });
        await load();
    }

    return (
        <Card>
            <CardHead title="Two-step sign-in">
                {factorId ? <Pill tone="live"><ShieldCheck className="w-3.5 h-3.5" aria-hidden="true" /> On</Pill> : factorId === null ? <Pill>Off</Pill> : null}
            </CardHead>
            <p className="text-sm text-brand-gray">
                Your choice. When it is on, signing in needs the password and a 6-digit code from an authenticator app on your phone,
                so a stolen password alone shows nothing.
            </p>
            {enrolling ? (
                <form onSubmit={confirm} className="mt-4 space-y-4">
                    <p className="text-sm text-brand-dark">
                        In your authenticator app, add an account by scanning this code, or type the key below it. Then type the 6-digit code the app shows.
                    </p>
                    {enrolling.qr && (
                        // eslint-disable-next-line @next/next/no-img-element -- a data URL made by Supabase, not a file to optimise
                        <img src={enrolling.qr} alt="Code to scan with the authenticator app" width={180} height={180} className="rounded-xl border border-gray-100 bg-white p-2" />
                    )}
                    <p className="font-mono text-sm break-all bg-gray-50 rounded-xl px-3 py-2">{enrolling.secret}</p>
                    <Field label="Code from the app" htmlFor="live-mfa-code">
                        <input id="live-mfa-code" inputMode="numeric" autoComplete="one-time-code" required pattern="[0-9 ]{6,7}" maxLength={7}
                            value={code} onChange={(e) => setCode(e.target.value)} className={`${inputClass} font-mono tracking-widest max-w-[12rem]`} placeholder="123456" />
                    </Field>
                    <div className="flex flex-wrap gap-2">
                        <button type="submit" disabled={busy} className={primaryButton}>Turn on</button>
                        <button type="button" className={softButton} onClick={() => { setEnrolling(null); setMessage(null); }}>Cancel</button>
                    </div>
                </form>
            ) : (
                <div className="mt-4">
                    {factorId ? (
                        <button type="button" disabled={busy} className={softButton} onClick={turnOff}><ShieldOff className="w-4 h-4" aria-hidden="true" /> Turn off</button>
                    ) : factorId === null ? (
                        <button type="button" disabled={busy} className={softButton} onClick={turnOn}><ShieldCheck className="w-4 h-4" aria-hidden="true" /> Turn on</button>
                    ) : null}
                </div>
            )}
            {message && <div className="mt-4"><Note problem={message.problem}>{message.text}</Note></div>}
        </Card>
    );
}
