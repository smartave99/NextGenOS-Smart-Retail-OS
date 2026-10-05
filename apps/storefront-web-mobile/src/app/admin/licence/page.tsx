"use client";

import { useEffect, useState, useTransition } from "react";
import { activateLicenceAction, getLicenceView, type LicenceView } from "./actions";

// The one admin page that works without a licence: it is how an unlicensed site gets activated.
export default function LicencePage() {
    const [view, setView] = useState<LicenceView | null>(null);
    const [key, setKey] = useState("");
    const [message, setMessage] = useState<{ ok: boolean; text: string; token?: string } | null>(null);
    const [pending, start] = useTransition();

    const refresh = () => getLicenceView().then(setView).catch(() => setView(null));
    useEffect(() => { void refresh(); }, []);

    const submit = (e: React.FormEvent) => {
        e.preventDefault();
        setMessage(null);
        start(async () => {
            const r = await activateLicenceAction(key);
            setMessage({ ok: r.ok, text: r.message, token: r.token });
            if (r.ok) { setKey(""); await refresh(); }
        });
    };

    return (
        <div style={{ maxWidth: 560, margin: "48px auto", padding: "0 16px", fontFamily: "system-ui, sans-serif" }}>
            <h1 style={{ fontSize: 28, letterSpacing: "-0.02em" }}>Licence</h1>
            {view && (
                <p style={{ padding: 16, borderRadius: 14, background: view.usable ? "#e6f4ea" : "#fbe7e5", color: view.usable ? "#1f7a3d" : "#b3261e" }}>
                    {view.message}
                    {view.usable && view.customer ? <><br /><small>For {view.customer}{view.edition ? `, ${view.edition} plan` : ""}{view.ends ? `, until ${view.ends}` : ""}.</small></> : null}
                </p>
            )}
            {view?.canActivate ? (
                <form onSubmit={submit}>
                    <label htmlFor="key" style={{ display: "block", fontWeight: 600, margin: "16px 0 6px" }}>Licence key</label>
                    <input id="key" value={key} onChange={(e) => setKey(e.target.value)} placeholder="NGOS-XXXXX-XXXXX-XXXXX-XXXXX" autoComplete="off" spellCheck={false}
                        style={{ width: "100%", padding: "12px 14px", fontSize: 16, borderRadius: 12, border: "1px solid #c7c7cc" }} />
                    <button type="submit" disabled={pending || key.trim().length < 10}
                        style={{ marginTop: 16, padding: "12px 28px", borderRadius: 999, border: 0, background: "#0071e3", color: "#fff", fontSize: 16, fontWeight: 600, cursor: "pointer" }}>
                        {pending ? "Checking…" : "Activate"}
                    </button>
                </form>
            ) : (
                <p>Ask your supplier for the licence file, and put its text into the setting <code>NGOS_LICENCE</code>.</p>
            )}
            {message && <p role="status" style={{ color: message.ok ? "#1f7a3d" : "#b3261e" }}>{message.text}</p>}
            {message?.token && <textarea readOnly rows={5} value={message.token} style={{ width: "100%", fontFamily: "monospace", fontSize: 12 }} />}
        </div>
    );
}
