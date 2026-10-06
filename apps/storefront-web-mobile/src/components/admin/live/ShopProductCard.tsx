"use client";

// One product the shop PC has made ready for the website, waiting for the owner. Opened, it shows the photos, the words and the
// POS's prices; the owner picks the photos and the category and approves (it is put on the website, its photos are uploaded to
// Cloudinary first) or declines (nothing is put on the website). Either way the project is told, and its copy of the photos goes.

import { useCallback, useEffect, useMemo, useRef, useState } from "react";
import type { SupabaseClient } from "@supabase/supabase-js";
import { Check, ChevronDown, ChevronUp, Loader2, X } from "lucide-react";
import { uploadToCloudinary } from "@/app/cloudinary-actions";
import { findShopProduct, publishShopProduct, type ExistingProduct } from "@/app/actions/shop-products";
import { price } from "@/lib/live-shop/format";
import {
    PHOTO_KINDS,
    approveBlocker,
    categoryChoices,
    choiceFromValue,
    choiceOf,
    choiceValue,
    photoLabel,
    photoSrc,
    readPhoto,
} from "@/lib/live-shop/shop-products";
import type { PhotoKind, Shop, ShopPhoto, ShopProduct, SiteCategory } from "@/lib/live-shop/types";
import { Note, Pill, inputClass, primaryButton, softButton } from "./ui";
import { LOCALE } from "@/lib/region/lite";

/** What happened to a product here, so the screen can say so and look at the list again. */
export type Decision = { kind: "published"; id: string; created: boolean; name: string } | { kind: "declined"; name: string };

const when = new Intl.DateTimeFormat(LOCALE, { day: "numeric", month: "short", hour: "numeric", minute: "2-digit" });

interface Existing { byKey: ExistingProduct | null; byBarcode: ExistingProduct | null }

export default function ShopProductCard({ db, shop, product, categories, signedIn, open, onToggle, onDecided }: {
    db: SupabaseClient;
    shop: Shop;
    product: ShopProduct;
    categories: SiteCategory[];
    /** Signed in to this website's admin, which publishing needs. */
    signedIn: boolean;
    open: boolean;
    onToggle: () => void;
    onDecided: (decision: Decision) => void;
}) {
    const { offer } = product;
    const [photos, setPhotos] = useState<ShopPhoto[] | null>(null);
    const [photoProblem, setPhotoProblem] = useState<string | null>(null);
    const [ticked, setTicked] = useState<Set<PhotoKind>>(new Set());
    const [existing, setExisting] = useState<Existing | null>(null);
    const [mode, setMode] = useState<"update" | "new">("update");
    const [busy, setBusy] = useState<"approve" | "decline" | null>(null);
    const [error, setError] = useState<string | null>(null);
    // The pictures already on Cloudinary, so that trying again after a failure does not upload them again.
    const uploaded = useRef<Partial<Record<PhotoKind, string>>>({});

    const initial = useMemo(() => choiceOf(categories, offer.categoryId, offer.subcategoryId), [categories, offer.categoryId, offer.subcategoryId]);
    const [picked, setPicked] = useState<string>("");
    // The place the shop PC chose, until the owner chooses another.
    const choice = picked ? choiceFromValue(categories, picked) : initial;

    // The photos come when the card is opened: they are large, so the list does not load them.
    useEffect(() => {
        if (!open || photos !== null) return;
        let cancelled = false;
        void (async () => {
            const { data, error: failure } = await db.from("shop_product_photos").select("kind, mime, content").eq("shop_id", shop.id).eq("product_key", product.key);
            if (cancelled) return;
            if (failure) {
                setPhotoProblem(failure.message);
                setPhotos([]);
                return;
            }
            const read = (data ?? []).map(readPhoto).filter((p): p is ShopPhoto => p !== null);
            const ordered = PHOTO_KINDS.map((p) => read.find((photo) => photo.kind === p.kind)).filter((p): p is ShopPhoto => Boolean(p));
            setPhotos(ordered);
            setTicked(new Set(ordered.map((p) => p.kind)));
        })();
        return () => {
            cancelled = true;
        };
    }, [open, photos, db, shop.id, product.key]);

    // Whether the product is on the website already, so an approval updates it and never makes a second one.
    useEffect(() => {
        if (!open || !signedIn || existing !== null) return;
        let cancelled = false;
        void (async () => {
            const result = await findShopProduct(shop.id, product.key, offer.barcode);
            if (cancelled) return;
            setExisting(result.success ? { byKey: result.byKey, byBarcode: result.byBarcode } : { byKey: null, byBarcode: null });
        })();
        return () => {
            cancelled = true;
        };
    }, [open, signedIn, existing, shop.id, product.key, offer.barcode]);

    const options = useMemo(() => categoryChoices(categories), [categories]);
    const updating = Boolean(existing?.byKey) || (mode === "update" && Boolean(existing?.byBarcode));
    const chosenPhotos = (photos ?? []).filter((p) => ticked.has(p.kind));
    const blocker = approveBlocker({ signedIn, choice, photos: chosenPhotos.length, isNew: !updating, loadingPhotos: photos === null });

    const toggle = useCallback((kind: PhotoKind) => {
        setTicked((now) => {
            const next = new Set(now);
            if (next.has(kind)) next.delete(kind);
            else next.add(kind);
            return next;
        });
    }, []);

    async function decide(state: "published" | "declined") {
        return db.rpc("decide_shop_product", { p_shop: shop.id, p_product: product.key, p_state: state });
    }

    async function approve() {
        if (!choice || blocker) return;
        setError(null);
        setBusy("approve");
        try {
            const imageUrls: string[] = [];
            for (const photo of chosenPhotos) {
                const have = uploaded.current[photo.kind];
                if (have) {
                    imageUrls.push(have);
                    continue;
                }
                const result = await uploadToCloudinary(photoSrc(photo), "products", "image");
                if (!result.success || !result.url) throw new Error(result.error || "A photo could not be uploaded. Try again.");
                uploaded.current[photo.kind] = result.url;
                imageUrls.push(result.url);
            }
            const result = await publishShopProduct({
                shopId: shop.id,
                productKey: product.key,
                name: offer.name,
                description: offer.description,
                price: offer.price,
                originalPrice: offer.originalPrice,
                highlights: offer.highlights,
                specifications: offer.specifications,
                tags: offer.tags,
                barcode: offer.barcode,
                categoryId: choice.categoryId,
                subcategoryId: choice.subcategoryId,
                imageUrls,
                updateId: !existing?.byKey && mode === "update" ? existing?.byBarcode?.id ?? null : null,
            });
            if (!result.success) throw new Error(result.error);
            const { error: failure } = await decide("published");
            if (failure) {
                throw new Error(`It is on your website, but it could not be marked as done here (${failure.message}). Press Approve again: that updates the same product.`);
            }
            onDecided({ kind: "published", id: result.id, created: result.created, name: offer.name });
        } catch (failure) {
            setError(failure instanceof Error ? failure.message : "Something went wrong. Try again.");
        } finally {
            setBusy(null);
        }
    }

    async function decline() {
        if (!window.confirm(`Decline “${offer.name}”? It will not be put on your website. You can offer it again from its page on the shop PC.`)) return;
        setError(null);
        setBusy("decline");
        const { error: failure } = await decide("declined");
        setBusy(null);
        if (failure) setError(failure.message);
        else onDecided({ kind: "declined", name: offer.name });
    }

    const headingId = `shop-product-${product.key}`;
    return (
        <article className="rounded-2xl border border-gray-100 bg-white shadow-sm" aria-labelledby={headingId} data-testid={`shop-product-${product.key}`}>
            <div className="flex flex-wrap items-start justify-between gap-x-4 gap-y-2 p-4 sm:p-5">
                <div className="min-w-0">
                    <h3 id={headingId} className="text-base font-semibold text-brand-dark break-words">{offer.name}</h3>
                    <p className="mt-0.5 text-xs text-brand-gray break-words">
                        {`In your POS: ${offer.posName || "—"}${offer.code ? ` · code ${offer.code}` : ""}`}
                    </p>
                    <p className="mt-1.5 text-sm text-brand-dark">
                        <span className="font-semibold">{price(offer.price)}</span>
                        {offer.originalPrice !== null && <span className="ml-2 text-brand-gray line-through">{price(offer.originalPrice)}</span>}
                        <span className="ml-2 text-xs text-brand-gray">price from your POS</span>
                    </p>
                    <p className="mt-1 text-xs text-brand-gray">
                        {`${offer.categoryPath ? `Shop PC chose: ${offer.categoryPath}. ` : "No category chosen yet. "}Offered ${when.format(product.sentAt)}`}
                    </p>
                </div>
                <button type="button" className={softButton} onClick={onToggle} aria-expanded={open} aria-controls={`${headingId}-body`}>
                    {open ? <><ChevronUp className="w-4 h-4" aria-hidden="true" /> Close</> : <><ChevronDown className="w-4 h-4" aria-hidden="true" /> Review</>}
                </button>
            </div>
            {open && (
                <div id={`${headingId}-body`} className="space-y-5 border-t border-gray-100 p-4 sm:p-5">
                    <section aria-label="Photos">
                        <h4 className="text-xs font-medium text-brand-gray uppercase tracking-wider">Photos</h4>
                        {photos === null ? (
                            <p role="status" className="mt-2 flex items-center gap-2 text-sm text-brand-gray"><Loader2 className="w-4 h-4 animate-spin" aria-hidden="true" /> Loading the photos…</p>
                        ) : photos.length === 0 ? (
                            <p className="mt-2 text-sm text-brand-gray">
                                {photoProblem ?? (existing?.byKey ? "No new photos came with this: its photos stay as they are on your website." : "No photos came with this product.")}
                            </p>
                        ) : (
                            <>
                                <ul className="mt-2 grid grid-cols-2 gap-3 sm:grid-cols-3 lg:grid-cols-5">
                                    {photos.map((photo) => (
                                        <li key={photo.kind} className="min-w-0">
                                            <label className="block cursor-pointer">
                                                {/* A picture from the shop PC, drawn from its own data, so a plain image is right here. */}
                                                {/* eslint-disable-next-line @next/next/no-img-element */}
                                                <img src={photoSrc(photo)} alt={`${photoLabel(photo.kind)} photo of ${offer.name}`} className="aspect-square w-full rounded-xl border border-gray-200 bg-gray-50 object-contain" />
                                                <span className="mt-1.5 flex items-center gap-2 text-xs text-brand-dark">
                                                    <input type="checkbox" checked={ticked.has(photo.kind)} onChange={() => toggle(photo.kind)} aria-label={`Use the ${photoLabel(photo.kind)} photo`} />
                                                    {photoLabel(photo.kind)}
                                                </span>
                                            </label>
                                        </li>
                                    ))}
                                </ul>
                                <p className="mt-2 text-xs text-brand-gray">
                                    {updating && existing?.byKey
                                        ? "It is on your website already. Ticked photos replace its pictures; untick all to keep the ones it has."
                                        : "The first ticked photo is the product's main picture."}
                                </p>
                            </>
                        )}
                    </section>

                    <section aria-label="Category" className="space-y-1.5">
                        <label htmlFor={`${headingId}-category`} className="block text-xs font-medium text-brand-gray uppercase tracking-wider">Category on your website</label>
                        <select id={`${headingId}-category`} className={inputClass} value={choice ? choiceValue(choice) : ""} onChange={(e) => setPicked(e.target.value)}>
                            {!choice && <option value="">Choose a category…</option>}
                            {options.map((option) => (
                                <option key={choiceValue(option)} value={choiceValue(option)}>{option.label}</option>
                            ))}
                        </select>
                        {!initial && offer.categoryPath && !picked && (
                            <p className="text-xs text-amber-800">{`“${offer.categoryPath}” the shop PC chose is not on your website any more. Choose another.`}</p>
                        )}
                    </section>

                    <section aria-label="Words">
                        <h4 className="text-xs font-medium text-brand-gray uppercase tracking-wider">What the website will say</h4>
                        <p className="mt-2 whitespace-pre-line text-sm text-brand-dark break-words">{offer.description}</p>
                        {offer.highlights.length > 0 && (
                            <ul className="mt-3 list-disc space-y-0.5 pl-5 text-sm text-brand-dark">
                                {offer.highlights.map((text, index) => <li key={index} className="break-words">{text}</li>)}
                            </ul>
                        )}
                        {offer.specifications.length > 0 && (
                            <dl className="mt-3 grid grid-cols-[auto_1fr] gap-x-4 gap-y-1 text-sm">
                                {offer.specifications.map((spec, index) => (
                                    <div key={index} className="contents">
                                        <dt className="text-brand-gray">{spec.key}</dt>
                                        <dd className="break-words text-brand-dark">{spec.value}</dd>
                                    </div>
                                ))}
                            </dl>
                        )}
                        {offer.tags.length > 0 && (
                            <p className="mt-3 flex flex-wrap gap-1.5">
                                {offer.tags.map((tag, index) => <Pill key={index}>{tag}</Pill>)}
                            </p>
                        )}
                        {offer.barcode && <p className="mt-3 text-xs text-brand-gray">{`Barcode ${offer.barcode}`}</p>}
                        <p className="mt-3 text-xs text-brand-gray">Change anything else afterwards under Products. Stock is not copied: the website keeps its own stock level.</p>
                    </section>

                    {signedIn && existing?.byKey && (
                        <Note>{`“${existing.byKey.name}” is on your website already, from this shop PC. Approving updates it with these words and prices.`}</Note>
                    )}
                    {signedIn && !existing?.byKey && existing?.byBarcode && (
                        <fieldset className="space-y-2 rounded-xl bg-gray-50 px-4 py-3 text-sm">
                            <legend className="px-1 text-xs font-medium text-brand-gray uppercase tracking-wider">Your website has a product with this barcode</legend>
                            <label className="flex items-start gap-2">
                                <input type="radio" name={`${headingId}-mode`} checked={mode === "update"} onChange={() => setMode("update")} className="mt-1" />
                                <span>{`Update “${existing.byBarcode.name}” (${price(existing.byBarcode.price)}) with these words and prices`}</span>
                            </label>
                            <label className="flex items-start gap-2">
                                <input type="radio" name={`${headingId}-mode`} checked={mode === "new"} onChange={() => setMode("new")} className="mt-1" />
                                <span>Add it as a new product</span>
                            </label>
                        </fieldset>
                    )}

                    {error && <Note problem>{error}</Note>}
                    <div className="flex flex-wrap items-center gap-3">
                        <button type="button" className={primaryButton} disabled={busy !== null || Boolean(blocker)} onClick={() => void approve()}>
                            {busy === "approve" ? <Loader2 className="w-4 h-4 animate-spin" aria-hidden="true" /> : <Check className="w-4 h-4" aria-hidden="true" />}
                            {busy === "approve" ? "Putting it on your website…" : updating ? "Approve and update" : "Approve and publish"}
                        </button>
                        <button type="button" className={softButton} disabled={busy !== null} onClick={() => void decline()}>
                            <X className="w-4 h-4" aria-hidden="true" /> Decline
                        </button>
                        {blocker && busy === null && <span className="text-xs text-brand-gray">{blocker}</span>}
                    </div>
                </div>
            )}
        </article>
    );
}
