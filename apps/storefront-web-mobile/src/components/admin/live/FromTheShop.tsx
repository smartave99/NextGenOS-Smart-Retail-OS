"use client";

// Live shop, From the shop: the products the shop PC (Smart Retail POS 2.18.0 or later) has made ready for this website. Each
// waits in the owner's own Supabase project with its photos, its words and the POS's price, and nothing is on the website until
// the owner approves it here. This screen also tells the project which categories this website has, so that the shop PC can
// file each product under one of them.

import { useCallback, useEffect, useMemo, useRef, useState } from "react";
import type { SupabaseClient } from "@supabase/supabase-js";
import { ExternalLink } from "lucide-react";
import { getCategories } from "@/app/actions";
import { useAuth } from "@/context/auth-context";
import { categoriesForProject, categoriesSignature, productsMissing, readShopProduct, sameCategories } from "@/lib/live-shop/shop-products";
import type { Shop, ShopProduct, SiteCategory } from "@/lib/live-shop/types";
import ShopProductCard, { type Decision } from "./ShopProductCard";
import { Card, Note, Pill, linkButton, softButton } from "./ui";

/** The shop PC offers a product as soon as it is ready; a look now and then covers a lost connection. */
const LOOK_EVERY_MS = 5 * 60_000;

const when = new Intl.DateTimeFormat("en-IN", { day: "numeric", month: "short" });

export default function FromTheShop({ db, shop, active, onWaiting }: {
    db: SupabaseClient;
    shop: Shop;
    /** Whether this screen is the one shown: this website's categories are read again each time it is opened. */
    active: boolean;
    /** How many products wait for the owner, for the tab; null when the project cannot say. */
    onWaiting: (count: number | null) => void;
}) {
    const { user, loading: signingIn } = useAuth();
    const [products, setProducts] = useState<ShopProduct[]>([]);
    const [loaded, setLoaded] = useState(false);
    // The project's script is older than this screen: there is no waiting list yet.
    const [missing, setMissing] = useState(false);
    const [problem, setProblem] = useState<string | null>(null);
    const [categories, setCategories] = useState<SiteCategory[] | null>(null);
    const [categoryProblem, setCategoryProblem] = useState<string | null>(null);
    const [openKey, setOpenKey] = useState<string | null>(null);
    const [done, setDone] = useState<Decision | null>(null);
    const sent = useRef<string | null>(null);

    const load = useCallback(async () => {
        const { data, error, status } = await db
            .from("shop_products")
            .select("product_key, data, state, photo_kinds, sent_at, decided_at")
            .eq("shop_id", shop.id)
            .order("sent_at")
            .limit(300);
        if (error) {
            if (productsMissing(error, status)) {
                setMissing(true);
                setProblem(null);
            } else {
                setProblem(error.message);
            }
        } else {
            setMissing(false);
            setProblem(null);
            setProducts((data ?? []).map(readShopProduct).filter((p): p is ShopProduct => p !== null));
        }
        setLoaded(true);
    }, [db, shop.id]);

    // A channel of its own: in a project whose script is older the waiting list is not published, and that must not spoil
    // the live figures' channel.
    useEffect(() => {
        void load();
        const channel = db
            .channel(`shop-products-${shop.id}`)
            .on("postgres_changes", { event: "*", schema: "public", table: "shop_products", filter: `shop_id=eq.${shop.id}` }, () => void load())
            .subscribe();
        return () => {
            void db.removeChannel(channel);
        };
    }, [db, shop.id, load]);

    useEffect(() => {
        if (missing) return;
        const timer = setInterval(() => void load(), LOOK_EVERY_MS);
        return () => clearInterval(timer);
    }, [missing, load]);

    // This website's categories: when Live shop opens, and again each time this screen is opened (the website keeps them for a
    // few minutes), so the shop PC can choose from them whichever screen the owner looked at.
    useEffect(() => {
        if (!active && categories !== null) return;
        let cancelled = false;
        void (async () => {
            try {
                const rows = await getCategories();
                if (cancelled) return;
                setCategories(rows.map((c) => ({ id: c.id, name: c.name, parentId: c.parentId ?? null })));
                setCategoryProblem(null);
            } catch {
                if (!cancelled) setCategoryProblem("Your website's categories could not be read. Open this screen again in a moment.");
            }
        })();
        return () => {
            cancelled = true;
        };
        // eslint-disable-next-line react-hooks/exhaustive-deps -- read again when the screen is opened, not when the list arrives
    }, [active]);

    // The project is told the categories when they are new to it, so the shop PC can choose from them. A list it has already is not
    // sent again, which would only change its date.
    useEffect(() => {
        if (!categories || categories.length === 0 || missing) return;
        const signature = categoriesSignature(categories);
        if (sent.current === signature) return;
        sent.current = signature;
        void (async () => {
            const wanted = categoriesForProject(categories);
            const have = await db.from("site_categories").select("categories").eq("shop_id", shop.id).maybeSingle();
            if (!have.error && sameCategories(have.data?.categories, wanted)) return;
            const { error, status } = await db.rpc("save_site_categories", { p_shop: shop.id, p_categories: wanted });
            if (error) {
                sent.current = null;
                if (productsMissing(error, status) || error.code === "PGRST202") setMissing(true);
                else setCategoryProblem(`Your website's categories could not be sent to the shop PC: ${error.message}`);
            }
        })();
    }, [categories, missing, db, shop.id]);

    const waiting = useMemo(() => products.filter((p) => p.state === "waiting"), [products]);
    const arriving = useMemo(() => products.filter((p) => p.state === "sending"), [products]);
    const decided = useMemo(
        () => products.filter((p) => p.state === "published" || p.state === "declined").sort((a, b) => (b.decidedAt?.getTime() ?? 0) - (a.decidedAt?.getTime() ?? 0)).slice(0, 30),
        [products],
    );

    useEffect(() => {
        onWaiting(loaded && !missing ? waiting.length : null);
    }, [loaded, missing, waiting.length, onWaiting]);

    const decidedHere = useCallback((decision: Decision) => {
        setDone(decision);
        setOpenKey(null);
        void load();
    }, [load]);

    const signedIn = Boolean(user);

    return (
        <div className="space-y-5" data-testid="from-the-shop">
            {problem && <Note problem>{problem}</Note>}
            {categoryProblem && <Note problem>{categoryProblem}</Note>}
            {!loaded ? (
                <Card><p role="status" className="text-sm text-brand-gray">Loading the products…</p></Card>
            ) : missing ? (
                <Card>
                    <h2 className="text-base font-semibold text-brand-dark">This needs the updated script</h2>
                    <p className="mt-1 text-sm text-brand-gray">
                        Run the latest supabase-owner-view.sql (a file of each Smart Retail POS release) in your Supabase project&apos;s SQL
                        Editor once more; running it again is safe. The shop PC can then offer its finished products here.
                    </p>
                    <button type="button" className={`${softButton} mt-4`} onClick={() => void load()}>Check again</button>
                </Card>
            ) : (
                <>
                    <Card>
                        <h2 className="text-base font-semibold text-brand-dark">Products from your shop</h2>
                        <p className="mt-1 text-sm text-brand-gray">
                            When a product&apos;s photos and listing are finished, the shop PC offers it here with the price from your POS.
                            Nothing is on your website until you approve it. The photos stay in your project only until you decide.
                        </p>
                        {!signingIn && !signedIn && (
                            <div className="mt-3">
                                <Note>
                                    You are not signed in to your website&apos;s admin. You can look at the products and decline them here, but publishing needs
                                    that sign-in.{" "}
                                    <a href="/admin/login" target="_blank" rel="noopener noreferrer" className={linkButton}>
                                        Sign in <ExternalLink className="inline w-3.5 h-3.5" aria-hidden="true" />
                                        <span className="sr-only"> (opens in a new tab)</span>
                                    </a>
                                </Note>
                            </div>
                        )}
                    </Card>

                    {done && (
                        <Note>
                            {done.kind === "published"
                                ? <>{`“${done.name}” is on your website${done.created ? "" : " (updated)"}. `}<a href={`/products/${done.id}`} target="_blank" rel="noopener noreferrer" className={linkButton}>View it<span className="sr-only"> (opens in a new tab)</span></a></>
                                : `“${done.name}” was declined. It stays off your website.`}
                        </Note>
                    )}

                    {waiting.length > 0 ? (
                        <section aria-labelledby="waiting-heading" className="space-y-3">
                            <h2 id="waiting-heading" className="text-base font-semibold text-brand-dark">{`Waiting for you (${waiting.length})`}</h2>
                            {categories === null && !categoryProblem && <p role="status" className="text-sm text-brand-gray">Loading your website&apos;s categories…</p>}
                            {waiting.map((product) => (
                                <ShopProductCard
                                    key={product.key}
                                    db={db}
                                    shop={shop}
                                    product={product}
                                    categories={categories ?? []}
                                    signedIn={signedIn}
                                    open={openKey === product.key}
                                    onToggle={() => setOpenKey(openKey === product.key ? null : product.key)}
                                    onDecided={decidedHere}
                                />
                            ))}
                        </section>
                    ) : arriving.length === 0 ? (
                        <Card>
                            <h2 className="text-base font-semibold text-brand-dark">Nothing is waiting</h2>
                            <p className="mt-1 text-sm text-brand-gray">
                                When the shop PC finishes a product&apos;s photos and listing, it appears here. On the shop PC, open Settings, then Owner&apos;s
                                live view, and turn on <em>Offer finished products to your website</em>.
                            </p>
                        </Card>
                    ) : null}

                    {arriving.length > 0 && (
                        <section aria-labelledby="arriving-heading" className="space-y-2">
                            <h2 id="arriving-heading" className="text-base font-semibold text-brand-dark">{`On their way (${arriving.length})`}</h2>
                            <ul className="space-y-2">
                                {arriving.map((product) => (
                                    <li key={product.key} className="flex flex-wrap items-center justify-between gap-2 rounded-xl bg-white px-4 py-3 text-sm shadow-sm border border-gray-100">
                                        <span className="min-w-0 break-words text-brand-dark">{product.offer.name}</span>
                                        <Pill tone="warn">Its photos are arriving</Pill>
                                    </li>
                                ))}
                            </ul>
                        </section>
                    )}

                    {decided.length > 0 && (
                        <details className="rounded-2xl border border-gray-100 bg-white p-4 shadow-sm sm:p-5">
                            <summary className="cursor-pointer text-sm font-semibold text-brand-dark">{`Decided (${decided.length})`}</summary>
                            <ul className="mt-3 divide-y divide-gray-100">
                                {decided.map((product) => (
                                    <li key={product.key} className="flex flex-wrap items-center justify-between gap-2 py-2 text-sm">
                                        <span className="min-w-0 break-words text-brand-dark">{product.offer.name}</span>
                                        <span className="flex items-center gap-2">
                                            {product.decidedAt && <span className="text-xs text-brand-gray">{when.format(product.decidedAt)}</span>}
                                            <Pill tone={product.state === "published" ? "live" : "plain"}>{product.state === "published" ? "On your website" : "Declined"}</Pill>
                                        </span>
                                    </li>
                                ))}
                            </ul>
                        </details>
                    )}
                </>
            )}
        </div>
    );
}
