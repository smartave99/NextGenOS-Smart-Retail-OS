"use client";

// Live shop (admin panel): the shop's figures from the POS, live, from anywhere. The shop PC running Smart Retail
// POS sends them to the owner's own Supabase project; this signs the owner in there (Supabase Auth, with an
// optional authenticator app) and shows them. Supabase itself checks every read: only the owner's account sees
// the shop, whoever can open this page.

import { useCallback, useEffect, useMemo, useRef, useState } from "react";
import type { SupabaseClient } from "@supabase/supabase-js";
import { Loader2, LogOut } from "lucide-react";
import { liveShopClient } from "@/lib/live-shop/client";
import { readLiveShopConfig, type LiveShopConfig } from "@/lib/live-shop/config";
import { selectDevices } from "@/lib/live-shop/devices";
import { liveState, longDate, withToday } from "@/lib/live-shop/format";
import type { OwnerDay, OwnerLive, Shop, ShopPc } from "@/lib/live-shop/types";
import AskShop from "./AskShop";
import { BestSellers, Bills, FixNow, History, Hours, LowStock, Today, Week } from "./Figures";
import FromTheShop from "./FromTheShop";
import ScreenTabs, { useScreen } from "./ScreenTabs";
import Security from "./Security";
import ShopPcs from "./ShopPcs";
import { Brand, CreateShop, NewPassword, SignIn, TwoStep } from "./SignIn";
import { Card, Note, Pill, softButton } from "./ui";
import WeeklyReview from "./WeeklyReview";

type Stage =
    | { name: "starting" }
    | { name: "signed-out" }
    | { name: "two-step" }
    | { name: "new-password" }
    | { name: "no-shop" }
    | { name: "shop"; shop: Shop }
    | { name: "problem"; text: string };

const HISTORY_DAYS = 60;
const REFRESH_EVERY_MS = 60_000;

export default function LiveShop() {
    const config = useMemo(() => readLiveShopConfig(), []);
    return (
        <div className="min-h-full px-4 sm:px-6 py-6 sm:py-8">
            {config.ok ? <LiveShopApp config={config} /> : <NotSetUp problem={config.problem} />}
        </div>
    );
}

function NotSetUp({ problem }: { problem: string }) {
    return (
        <Card className="max-w-xl mx-auto">
            <Brand />
            <h1 className="mt-4 text-2xl font-semibold text-brand-dark">Live shop is not set up yet</h1>
            <p className="mt-2 text-sm text-brand-gray">It shows the shop&apos;s figures from the POS, from your own Supabase project.</p>
            <div className="mt-4"><Note problem>{problem}</Note></div>
        </Card>
    );
}

function LiveShopApp({ config }: { config: Extract<LiveShopConfig, { ok: true }> }) {
    const db = useMemo(() => liveShopClient(config), [config]);
    const [stage, setStage] = useState<Stage>({ name: "starting" });
    const current = useRef<Stage>(stage);
    const recovering = useRef(false);

    useEffect(() => {
        current.current = stage;
    }, [stage]);

    const loadShop = useCallback(async () => {
        const { data, error } = await db.from("shops").select("id, name").order("created_at").limit(1);
        if (error) setStage({ name: "problem", text: error.message });
        else if (!data?.length) setStage({ name: "no-shop" });
        else setStage({ name: "shop", shop: data[0] as Shop });
    }, [db]);

    // An owner who turned on the authenticator app enters its code before anything else.
    const decide = useCallback(async () => {
        const { data, error } = await db.auth.mfa.getAuthenticatorAssuranceLevel();
        if (!error && data?.nextLevel === "aal2" && data.currentLevel !== "aal2") {
            setStage({ name: "two-step" });
            return;
        }
        await loadShop();
    }, [db, loadShop]);

    useEffect(() => {
        const { data } = db.auth.onAuthStateChange((event, session) => {
            if (event === "PASSWORD_RECOVERY") {
                recovering.current = true;
                setStage({ name: "new-password" });
                return;
            }
            if (!session) {
                setStage({ name: "signed-out" });
                return;
            }
            const signedIn = event === "INITIAL_SESSION" || event === "SIGNED_IN" || event === "MFA_CHALLENGE_VERIFIED";
            if (!signedIn || recovering.current || (event === "SIGNED_IN" && current.current.name === "shop")) return;
            // Supabase asks for no waiting inside this callback: the rest happens just after it.
            setTimeout(() => void decide(), 0);
        });
        return () => data.subscription.unsubscribe();
    }, [db, decide]);

    // Signs out this device only: the owner stays signed in on the others.
    const signOut = useCallback(async () => {
        await db.auth.signOut({ scope: "local" });
        setStage({ name: "signed-out" });
    }, [db]);

    switch (stage.name) {
        case "starting":
            return <Loading />;
        case "signed-out":
            return <SignIn db={db} />;
        case "two-step":
            return <TwoStep db={db} onSignOut={signOut} />;
        case "new-password":
            return <NewPassword db={db} onDone={() => { recovering.current = false; void decide(); }} />;
        case "no-shop":
            return (
                <div className="space-y-4">
                    <TopBar onSignOut={signOut} />
                    <CreateShop db={db} onCreated={() => void loadShop()} />
                </div>
            );
        case "problem":
            return (
                <div className="space-y-4">
                    <TopBar onSignOut={signOut} />
                    <Card className="max-w-md mx-auto">
                        <h1 className="text-xl font-semibold text-brand-dark">Something went wrong</h1>
                        <div className="mt-3"><Note problem>{stage.text}</Note></div>
                        <button type="button" className={`${softButton} mt-4`} onClick={() => void decide()}>Try again</button>
                    </Card>
                </div>
            );
        case "shop":
            return <Dashboard db={db} shop={stage.shop} config={config} onSignOut={signOut} />;
    }
}

function Loading() {
    return (
        <div className="flex justify-center py-24 text-brand-gray" role="status">
            <Loader2 className="w-6 h-6 animate-spin" aria-hidden="true" />
            <span className="sr-only">Loading</span>
        </div>
    );
}

function TopBar({ onSignOut, children }: { onSignOut: () => void; children?: React.ReactNode }) {
    return (
        <div className="max-w-6xl mx-auto flex flex-wrap items-center justify-between gap-3">
            <Brand />
            <div className="flex items-center gap-3">
                {children}
                <button type="button" className={softButton} onClick={onSignOut}><LogOut className="w-4 h-4" aria-hidden="true" /> Sign out</button>
            </div>
        </div>
    );
}

function Dashboard({ db, shop, config, onSignOut }: {
    db: SupabaseClient;
    shop: Shop;
    config: Extract<LiveShopConfig, { ok: true }>;
    onSignOut: () => void;
}) {
    const [live, setLive] = useState<OwnerLive | null>(null);
    const [sentAt, setSentAt] = useState<Date | null>(null);
    const [days, setDays] = useState<OwnerDay[]>([]);
    const [devices, setDevices] = useState<ShopPc[]>([]);
    const [problem, setProblem] = useState<string | null>(null);
    const [loaded, setLoaded] = useState(false);
    const [now, setNow] = useState(() => new Date());
    const [screen, showScreen] = useScreen();
    // How many products wait for the owner on From the shop; null while that is not known.
    const [waiting, setWaiting] = useState<number | null>(null);
    const counts = useRef({ days: 0, devices: 0 });

    useEffect(() => {
        counts.current = { days: days.length, devices: devices.length };
    }, [days, devices]);

    const loadDevices = useCallback(async () => {
        const { data, error } = await selectDevices(db, shop.id);
        if (error || !data) return [];
        setDevices(data as ShopPc[]);
        return data as ShopPc[];
    }, [db, shop.id]);

    const refresh = useCallback(async (withDays: boolean) => {
        const since = new Date(Date.now() - HISTORY_DAYS * 86_400_000).toISOString().slice(0, 10);
        const [liveRow, deviceRows, dayRows] = await Promise.all([
            db.from("shop_live").select("data, sent_at").eq("shop_id", shop.id).maybeSingle(),
            selectDevices(db, shop.id),
            withDays ? db.from("shop_days").select("day, data").eq("shop_id", shop.id).gte("day", since).order("day") : Promise.resolve(null),
        ]);
        setProblem(liveRow.error?.message ?? deviceRows.error?.message ?? dayRows?.error?.message ?? null);
        if (liveRow.data) {
            setLive(liveRow.data.data as OwnerLive);
            setSentAt(new Date(liveRow.data.sent_at as string));
        }
        if (deviceRows.data) setDevices(deviceRows.data as ShopPc[]);
        if (dayRows?.data) setDays(dayRows.data.map((d) => d.data as OwnerDay));
        setLoaded(true);
    }, [db, shop.id]);

    useEffect(() => {
        void refresh(true);
    }, [refresh]);

    // New figures arrive the moment the shop PC sends them; a look every minute covers a lost connection.
    useEffect(() => {
        const channel = db
            .channel(`shop-live-${shop.id}`)
            .on("postgres_changes", { event: "*", schema: "public", table: "shop_live", filter: `shop_id=eq.${shop.id}` }, (change) => {
                const row = change.new as { data?: OwnerLive; sent_at?: string } | undefined;
                if (!row?.data) return;
                setLive(row.data);
                setSentAt(row.sent_at ? new Date(row.sent_at) : new Date());
                if (counts.current.days < 2 || counts.current.devices === 0) void refresh(true);
            })
            .subscribe();
        const poll = setInterval(() => void refresh(new Date().getMinutes() % 10 === 0), REFRESH_EVERY_MS);
        const tick = setInterval(() => setNow(new Date()), 30_000);
        return () => {
            void db.removeChannel(channel);
            clearInterval(poll);
            clearInterval(tick);
        };
    }, [db, shop.id, refresh]);

    const history = useMemo(() => withToday(days, live), [days, live]);
    const state = liveState(sentAt, now);

    return (
        <div className="max-w-6xl mx-auto space-y-5">
            <TopBar onSignOut={onSignOut} />
            <header className="flex flex-wrap items-end justify-between gap-3">
                <div className="min-w-0">
                    <p className="text-xs uppercase tracking-widest text-brand-gray">{live ? longDate(live.today.day) : " "}</p>
                    <h1 className="text-2xl sm:text-3xl font-semibold text-brand-dark truncate">{shop.name}</h1>
                </div>
                <Pill tone={state.kind === "live" ? "live" : "warn"}
                    title={state.kind === "stale" ? "Is the shop PC on, with Smart Retail POS open and the internet working?" : undefined}>
                    {state.kind === "live" && <i className="inline-block w-2 h-2 rounded-full bg-brand-green animate-pulse" aria-hidden="true" />}
                    <span data-testid="live-state">{state.text}</span>
                </Pill>
            </header>
            {problem && <Note problem>{problem}</Note>}
            {live?.demo && <Note>These are the demo shop&apos;s figures: the shop PC has not found the POS database.</Note>}
            <ScreenTabs screen={screen} onChange={showScreen} waiting={waiting} />
            {/* Questions can be asked as soon as a shop PC is connected, even before its first figures arrive. */}
            {(live || devices.length > 0) && <AskShop db={db} shop={shop} pcLive={state.kind === "live"} />}
            {/* The screen not shown stays on the page, hidden, so changing screens loses nothing (an opened day, a pairing code). */}
            <div className="space-y-5" hidden={screen !== "today"}>
                {!live ? (
                    loaded ? (
                        <Card>
                            <h2 className="text-base font-semibold text-brand-dark">No figures yet</h2>
                            <p className="mt-1 text-sm text-brand-gray">Connect the shop PC below. Its figures show here within a minute.</p>
                        </Card>
                    ) : (
                        <Loading />
                    )
                ) : (
                    <>
                        <div className="grid gap-5 lg:grid-cols-2">
                            <Today live={live} />
                            <Hours live={live} />
                        </div>
                        <Bills live={live} />
                        <div className="grid gap-5 md:grid-cols-2">
                            <Week live={live} />
                            <BestSellers live={live} />
                            <LowStock live={live} />
                            <FixNow live={live} />
                        </div>
                        <History days={history} />
                    </>
                )}
            </div>
            <div hidden={screen !== "review"}>
                <WeeklyReview db={db} shop={shop} liveDemo={Boolean(live?.demo)} />
            </div>
            <div hidden={screen !== "shop"}>
                <FromTheShop db={db} shop={shop} active={screen === "shop"} onWaiting={setWaiting} />
            </div>
            <div hidden={screen !== "today"}>
                <div className="grid gap-5 lg:grid-cols-2">
                    <ShopPcs db={db} shop={shop} devices={devices} onChanged={loadDevices} projectUrl={config.url} publicKey={config.key} />
                    <Security db={db} />
                </div>
            </div>
            <p className="text-center text-xs text-brand-gray">Figures from the shop PC. Customer names and phone numbers never leave the shop.</p>
        </div>
    );
}
