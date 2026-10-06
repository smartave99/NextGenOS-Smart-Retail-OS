"use client";

import { useState, type FormEvent } from "react";
import type { SupabaseClient } from "@supabase/supabase-js";
import { Activity, Loader2 } from "lucide-react";
import { Card, Field, Note, inputClass, linkButton, primaryButton } from "./ui";
import { SHOP_NAME } from "@/lib/shop-name";

/** Where Supabase's e-mails (confirm the account, new password) bring the owner back to. */
export const backHere = () => `${window.location.origin}/admin/live`;

export function Brand() {
    return (
        <div className="flex items-center gap-2 text-brand-dark font-semibold">
            <Activity className="w-5 h-5 text-brand-green" aria-hidden="true" />
            Live shop
        </div>
    );
}

/** The owner's sign-in, with the owner's Supabase account; the first account creates the shop. */
export function SignIn({ db, note }: { db: SupabaseClient; note?: string }) {
    const [mode, setMode] = useState<"signin" | "signup">("signin");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [message, setMessage] = useState<{ text: string; problem: boolean } | null>(note ? { text: note, problem: false } : null);
    const [busy, setBusy] = useState(false);

    async function submit(event: FormEvent) {
        event.preventDefault();
        setBusy(true);
        setMessage({ text: mode === "signup" ? "Creating the account…" : "Signing in…", problem: false });
        const credentials = { email: email.trim(), password };
        const { data, error } = mode === "signup"
            ? await db.auth.signUp({ ...credentials, options: { emailRedirectTo: backHere() } })
            : await db.auth.signInWithPassword(credentials);
        setBusy(false);
        if (error) setMessage({ text: error.message, problem: true });
        else if (mode === "signup" && !data.session) setMessage({ text: "Check your e-mail and open the link to confirm, then sign in here.", problem: false });
        else setMessage(null);
    }

    async function forgot() {
        if (!email.trim()) {
            setMessage({ text: "Type your e-mail first.", problem: true });
            return;
        }
        const { error } = await db.auth.resetPasswordForEmail(email.trim(), { redirectTo: backHere() });
        setMessage(error ? { text: error.message, problem: true } : { text: "If that e-mail has an account, a link to set a new password is on its way.", problem: false });
    }

    return (
        <Card className="max-w-md w-full mx-auto">
            <Brand />
            <h1 className="mt-4 text-2xl font-semibold text-brand-dark">{mode === "signup" ? "Create the owner's account" : "See your shop, live"}</h1>
            <p className="mt-1 text-sm text-brand-gray">
                {mode === "signup"
                    ? "The first account creates the shop. The shop PC then sends its figures here."
                    : "Sign in with the owner's account to see today's sales, bills and stock from anywhere."}
            </p>
            <form onSubmit={submit} className="mt-6 space-y-4">
                <Field label="E-mail" htmlFor="live-email">
                    <input id="live-email" type="email" autoComplete="email" required value={email} onChange={(e) => setEmail(e.target.value)} className={inputClass} placeholder="you@example.com" />
                </Field>
                <Field label="Password" htmlFor="live-password">
                    <input id="live-password" type="password" minLength={8} required value={password} onChange={(e) => setPassword(e.target.value)}
                        autoComplete={mode === "signup" ? "new-password" : "current-password"} className={inputClass} />
                </Field>
                <button type="submit" disabled={busy} className={`${primaryButton} w-full`}>
                    {busy && <Loader2 className="w-4 h-4 animate-spin" aria-hidden="true" />}
                    {mode === "signup" ? "Create account" : "Sign in"}
                </button>
            </form>
            {message && <div className="mt-4"><Note problem={message.problem}>{message.text}</Note></div>}
            <div className="mt-5 flex flex-wrap gap-x-5 gap-y-2">
                {mode === "signup" ? (
                    <button type="button" className={linkButton} onClick={() => { setMode("signin"); setMessage(null); }}>I have an account: sign in</button>
                ) : (
                    <>
                        <button type="button" className={linkButton} onClick={() => { setMode("signup"); setMessage(null); }}>Create the owner&apos;s account</button>
                        <button type="button" className={linkButton} onClick={forgot}>Forgot the password?</button>
                    </>
                )}
            </div>
        </Card>
    );
}

/** The second step, for an owner who turned on the authenticator app: the 6-digit code it shows. */
export function TwoStep({ db, onSignOut }: { db: SupabaseClient; onSignOut: () => void }) {
    const [code, setCode] = useState("");
    const [problem, setProblem] = useState<string | null>(null);
    const [busy, setBusy] = useState(false);

    async function submit(event: FormEvent) {
        event.preventDefault();
        setBusy(true);
        setProblem(null);
        const { data, error: listError } = await db.auth.mfa.listFactors();
        const factor = data?.totp?.[0];
        if (listError || !factor) {
            setBusy(false);
            setProblem(listError?.message ?? "No authenticator app is set up for this account.");
            return;
        }
        const { error } = await db.auth.mfa.challengeAndVerify({ factorId: factor.id, code: code.replace(/\s/g, "") });
        setBusy(false);
        if (error) setProblem(error.message);
    }

    return (
        <Card className="max-w-md w-full mx-auto">
            <Brand />
            <h1 className="mt-4 text-2xl font-semibold text-brand-dark">Enter the code</h1>
            <p className="mt-1 text-sm text-brand-gray">Open your authenticator app and type the 6-digit code it shows for Live shop.</p>
            <form onSubmit={submit} className="mt-6 space-y-4">
                <Field label="Code" htmlFor="live-code">
                    <input id="live-code" inputMode="numeric" autoComplete="one-time-code" required pattern="[0-9 ]{6,7}" maxLength={7}
                        value={code} onChange={(e) => setCode(e.target.value)} className={`${inputClass} font-mono tracking-widest`} placeholder="123456" />
                </Field>
                <button type="submit" disabled={busy} className={`${primaryButton} w-full`}>
                    {busy && <Loader2 className="w-4 h-4 animate-spin" aria-hidden="true" />}
                    Continue
                </button>
            </form>
            {problem && <div className="mt-4"><Note problem>{problem}</Note></div>}
            <button type="button" className={`${linkButton} mt-5`} onClick={onSignOut}>Use another account</button>
        </Card>
    );
}

/** After the "new password" e-mail's link. */
export function NewPassword({ db, onDone }: { db: SupabaseClient; onDone: () => void }) {
    const [password, setPassword] = useState("");
    const [problem, setProblem] = useState<string | null>(null);

    async function submit(event: FormEvent) {
        event.preventDefault();
        const { error } = await db.auth.updateUser({ password });
        if (error) setProblem(error.message);
        else onDone();
    }

    return (
        <Card className="max-w-md w-full mx-auto">
            <Brand />
            <h1 className="mt-4 text-2xl font-semibold text-brand-dark">Set a new password</h1>
            <form onSubmit={submit} className="mt-6 space-y-4">
                <Field label="New password" htmlFor="live-new-password">
                    <input id="live-new-password" type="password" autoComplete="new-password" minLength={8} required value={password}
                        onChange={(e) => setPassword(e.target.value)} className={inputClass} />
                </Field>
                <button type="submit" className={`${primaryButton} w-full`}>Save</button>
            </form>
            {problem && <div className="mt-4"><Note problem>{problem}</Note></div>}
        </Card>
    );
}

/** The first account names the shop, once. */
export function CreateShop({ db, onCreated, note }: { db: SupabaseClient; onCreated: () => void; note?: string }) {
    const [name, setName] = useState("");
    const [problem, setProblem] = useState<string | null>(note ?? null);

    async function submit(event: FormEvent) {
        event.preventDefault();
        const { error } = await db.rpc("create_shop", { p_name: name });
        if (error) setProblem(error.message);
        else onCreated();
    }

    return (
        <Card className="max-w-md w-full mx-auto">
            <h1 className="text-2xl font-semibold text-brand-dark">Name your shop</h1>
            <p className="mt-1 text-sm text-brand-gray">Then connect the shop PC with a code, and its figures show here.</p>
            <form onSubmit={submit} className="mt-6 space-y-4">
                <Field label="Shop name" htmlFor="live-shop-name">
                    <input id="live-shop-name" required maxLength={120} value={name} onChange={(e) => setName(e.target.value)} className={inputClass} placeholder={SHOP_NAME} />
                </Field>
                <button type="submit" className={`${primaryButton} w-full`}>Create the shop</button>
            </form>
            {problem && <div className="mt-4"><Note problem>{problem}</Note></div>}
        </Card>
    );
}
