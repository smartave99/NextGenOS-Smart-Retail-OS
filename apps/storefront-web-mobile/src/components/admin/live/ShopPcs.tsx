"use client";

import { useEffect, useRef, useState } from "react";
import type { SupabaseClient } from "@supabase/supabase-js";
import { Monitor } from "lucide-react";
import { calendarDate, clockTime, pairingCode } from "@/lib/live-shop/format";
import type { Shop, ShopPc } from "@/lib/live-shop/types";
import { Card, CardHead, Note, Pill, linkButton, primaryButton } from "./ui";

type Pairing = { code: string; until: number } | { connected: string } | { problem: string } | null;

const CODE_MINUTES = 15;

/** The shop PCs that send figures; a one-time code connects another. */
export default function ShopPcs({ db, shop, devices, onChanged, projectUrl, publicKey }: {
    db: SupabaseClient;
    shop: Shop;
    devices: ShopPc[];
    onChanged: () => Promise<ShopPc[]>;
    projectUrl: string;
    publicKey: string;
}) {
    const [pairing, setPairing] = useState<Pairing>(null);
    const [problem, setProblem] = useState<string | null>(null);
    const known = useRef(devices.length);

    // A shop PC that appears while a code is showing has just connected with it.
    useEffect(() => {
        if (pairing && "code" in pairing && devices.length > known.current) {
            setPairing({ connected: devices[devices.length - 1].label });
        }
        known.current = devices.length;
    }, [devices, pairing]);

    // While a code is showing, look for the shop PC every few seconds.
    useEffect(() => {
        if (!pairing || !("code" in pairing)) return;
        const timer = setInterval(() => {
            if (pairing.until < Date.now()) setPairing(null);
            else void onChanged();
        }, 5000);
        return () => clearInterval(timer);
    }, [pairing, onChanged]);

    async function makeCode() {
        known.current = devices.length;
        const { data, error } = await db.rpc("new_pairing_code", { p_shop: shop.id });
        setPairing(error ? { problem: error.message } : { code: String(data), until: Date.now() + CODE_MINUTES * 60 * 1000 });
    }

    async function disconnect(device: ShopPc) {
        if (!window.confirm(`Disconnect ${device.label}? It stops sending at once; it can be connected again with a new code.`)) return;
        const { error } = await db.from("shop_devices").delete().eq("id", device.id);
        setProblem(error ? error.message : null);
        if (!error) setPairing(null);
        await onChanged();
    }

    const code = pairing && "code" in pairing && pairing.until > Date.now() ? pairing.code : null;

    return (
        <Card>
            <CardHead title="Shop PCs">
                <button type="button" className={primaryButton} onClick={makeCode}>{code ? "New code" : "Connect a shop PC"}</button>
            </CardHead>
            {devices.length ? (
                <ul className="divide-y divide-gray-100">
                    {devices.map((d) => (
                        <li key={d.id} className="flex items-center justify-between gap-3 py-3">
                            <span className="flex items-center gap-3 min-w-0">
                                <Monitor className="w-5 h-5 text-brand-gray shrink-0" aria-hidden="true" />
                                <span className="min-w-0">
                                    <span className="flex items-center gap-2 min-w-0 text-sm font-medium text-brand-dark">
                                        <span className="truncate">{d.label}</span>
                                        {devices.length > 1 && typeof d.is_main === "boolean" && (
                                            <Pill tone={d.is_main ? "live" : "plain"} title={d.is_main ? "This PC sends the shop's figures and products" : "A counter PC sends nothing"}>
                                                {d.is_main ? "Main PC" : "Counter"}
                                            </Pill>
                                        )}
                                    </span>
                                    <span className="block text-xs text-brand-gray">
                                        {d.last_seen_at ? `Last sent ${clockTime(new Date(d.last_seen_at))}, ${calendarDate(new Date(d.last_seen_at))}` : "Not sent yet"}
                                    </span>
                                </span>
                            </span>
                            <button type="button" className="text-sm font-medium text-red-600 hover:underline" onClick={() => disconnect(d)}>Disconnect</button>
                        </li>
                    ))}
                </ul>
            ) : (
                <p className="text-sm text-brand-gray">No shop PC is connected yet.</p>
            )}
            {problem && <div className="mt-3"><Note problem>{problem}</Note></div>}
            {pairing && "problem" in pairing && <div className="mt-3"><Note problem>{pairing.problem}</Note></div>}
            {pairing && "connected" in pairing && <div className="mt-3"><Note>{pairing.connected} is connected. Its figures show here within a minute.</Note></div>}
            {code && (
                <div className="mt-4 rounded-2xl bg-brand-green/5 border border-brand-green/10 p-5 space-y-3">
                    <p className="text-sm text-brand-dark">
                        On the shop PC, open Smart Retail POS, then Settings, then Owner&apos;s live view. Paste the project URL and public key,
                        type this code and press Connect. The code works once, for {CODE_MINUTES} minutes.
                    </p>
                    <p id="live-pairing-code" className="font-mono text-3xl font-semibold tracking-[0.2em] text-brand-dark">{pairingCode(code)}</p>
                    <dl className="grid gap-1 text-sm">
                        <dt className="text-xs font-medium text-brand-gray uppercase tracking-wider">Project URL</dt>
                        <dd className="font-mono break-all">{projectUrl}</dd>
                        <dt className="mt-2 text-xs font-medium text-brand-gray uppercase tracking-wider">Public key</dt>
                        <dd className="font-mono break-all text-xs">{publicKey}</dd>
                    </dl>
                    <button type="button" className={linkButton} onClick={() => setPairing(null)}>Hide the code</button>
                </div>
            )}
        </Card>
    );
}
