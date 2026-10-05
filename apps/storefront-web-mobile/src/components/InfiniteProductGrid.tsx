"use client";

import { useState, useEffect, useCallback, useRef } from "react";
import Link from "next/link";
import Image from "next/image";
import { AlertCircle, CheckCircle2, ChevronRight, Package, RefreshCcw, Star, Tag, Zap } from "lucide-react";
import { Product, getProducts, Offer, Category } from "@/app/actions";
import SocialProofBadge from "@/components/ai/SocialProofBadge";
import GenieRequestTrigger from "@/components/GenieRequestTrigger";
import { SHOP_NAME } from "@/lib/shop-name";

interface InfiniteProductGridProps {
    initialProducts: Product[];
    categories: Category[];
    offers: Offer[];
    filters: {
        category?: string | string[];
        subcategory?: string;
        search?: string;
        minPrice?: number;
        maxPrice?: number;
        sort?: string;
        rating?: number;
        available?: boolean | "all";
    };
}

const inrFormatter = new Intl.NumberFormat("en-IN", {
    style: "currency",
    currency: "INR",
    maximumFractionDigits: 0,
});

export default function InfiniteProductGrid({
    initialProducts,
    categories,
    offers,
    filters
}: InfiniteProductGridProps) {
    const [products, setProducts] = useState<Product[]>(initialProducts);
    const [loading, setLoading] = useState(false);
    const [loadError, setLoadError] = useState<string | null>(null);

    // We only enable pagination if NO filters are active (except category/subcategory)
    // because our getFilteredProducts returns ALL matches at once.
    const hasActiveFilters = !!(filters.search || filters.minPrice !== undefined || filters.maxPrice !== undefined || filters.available !== undefined || (filters.sort && filters.sort !== 'newest'));

    const [hasMore, setHasMore] = useState(!hasActiveFilters && initialProducts.length === 20); // Assuming batch size 20
    const [lastId, setLastId] = useState<string | undefined>(
        initialProducts.length > 0 ? initialProducts[initialProducts.length - 1].id : undefined
    );

    const observer = useRef<IntersectionObserver | null>(null);
    const loadMore = useCallback(async () => {
        if (loading || !hasMore || hasActiveFilters) return;
        setLoading(true);
        setLoadError(null);

        try {
            // Determine active category for fetching
            const activeCategory = Array.isArray(filters.category) ? filters.category[0] : filters.category;

            const nextBatch = await getProducts(
                activeCategory,
                filters.available,
                20,
                lastId,
                filters.subcategory
            );

            if (nextBatch.length === 0) {
                setHasMore(false);
            } else {
                setProducts(prev => [...prev, ...nextBatch]);
                setLastId(nextBatch[nextBatch.length - 1].id);
                setHasMore(nextBatch.length === 20);
            }
        } catch (error) {
            console.error("Error loading products:", error);
            setLoadError("Couldn’t load more products. Check your connection and try again.");
        } finally {
            setLoading(false);
        }
    }, [loading, hasMore, lastId, filters.category, filters.subcategory, filters.available, hasActiveFilters]);

    const lastProductElementRef = useCallback((node: HTMLAnchorElement | null) => {
        if (loading) return;
        if (observer.current) observer.current.disconnect();
        observer.current = new IntersectionObserver(entries => {
            if (entries[0].isIntersecting && hasMore) {
                loadMore();
            }
        });
        if (node) observer.current.observe(node);
    }, [loading, hasMore, loadMore]);

    // Reset when initialProducts change
    useEffect(() => {
        setProducts(initialProducts);
        setHasMore(!hasActiveFilters && initialProducts.length === 20);
        setLastId(initialProducts.length > 0 ? initialProducts[initialProducts.length - 1].id : undefined);
        setLoadError(null);
    }, [initialProducts, hasActiveFilters]);


    const getCategoryName = (id: string) => categories.find(c => c.id === id)?.name || "Unknown";
    const getOffer = (id?: string) => id ? offers.find(o => o.id === id) : null;

    // displayProducts is now exactly the products array (which comprises initialProducts populated from getFilteredProducts + any paginated ones)
    const displayProducts = products;

    if (displayProducts.length === 0 && !loading && !hasMore) {
        return (
            <div className="flex flex-col gap-8">
                <div className="text-center py-20 bg-white rounded-3xl border border-dashed border-slate-300">
                    <Package className="w-12 h-12 text-slate-300 mx-auto mb-4" />
                    <h3 className="text-lg font-bold text-slate-700">No products found</h3>
                    <p className="text-slate-500">Try adjusting your filters.</p>
                    <Link href="/products" className="inline-block mt-4 text-brand-blue hover:underline">
                        Clear Filters
                    </Link>
                </div>

                {/* Genie Request Trigger */}
                <GenieRequestTrigger searchQuery={filters.search} />
            </div>
        );
    }

    return (
        <div className="flex flex-col gap-8" aria-busy={loading}>
            <p className="sr-only" aria-live="polite">{displayProducts.length} products shown</p>
            <div className="grid grid-cols-2 gap-3 sm:gap-5 lg:grid-cols-3">
                {displayProducts.map((product, index) => {
                    const offer = getOffer(product.offerId);
                    const categoryName = getCategoryName(product.categoryId);
                    const isLast = index === displayProducts.length - 1;

                    return (
                        <Link
                            key={product.id}
                            ref={isLast ? lastProductElementRef : null}
                            href={`/products/${product.id}`}
                            className="sa-card-link group flex min-w-0 flex-col overflow-hidden rounded-2xl border border-slate-200/80 bg-white shadow-sm focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-blue-500 focus-visible:ring-offset-2 sm:rounded-3xl"
                        >
                            <div className="relative aspect-square overflow-hidden bg-slate-100 sm:aspect-[4/3]">
                                <Image
                                    src={product.imageUrl}
                                    alt={`${product.name} - ${categoryName} available at ${SHOP_NAME}`}
                                    fill
                                    className="sa-card-image object-cover"
                                    quality={95}
                                    sizes="(max-width: 640px) 50vw, (max-width: 1024px) 50vw, 33vw"
                                />
                                <div className="absolute top-3 left-3 flex flex-col gap-2">
                                    {product.featured && (
                                        <span className="flex items-center gap-1 rounded-lg bg-emerald-700 px-2 py-1 text-xs font-bold text-white shadow-md sm:px-3 sm:py-1.5">
                                            <Zap className="h-3 w-3" aria-hidden="true" /> Featured
                                        </span>
                                    )}
                                    {offer && (
                                        <span className="flex items-center gap-1 rounded-lg bg-blue-700 px-2 py-1 text-xs font-bold text-white shadow-md sm:px-3 sm:py-1.5">
                                            <Tag className="h-3 w-3" aria-hidden="true" /> {offer.discount}
                                        </span>
                                    )}
                                </div>
                                <span className={`absolute bottom-3 left-3 inline-flex min-h-7 items-center gap-1.5 rounded-full px-2.5 text-xs font-bold shadow-sm ${product.available === false ? "bg-amber-50 text-amber-950" : "bg-emerald-50 text-emerald-800"}`}>
                                    <CheckCircle2 className="h-3.5 w-3.5" aria-hidden="true" />
                                    {product.available === false ? "Check availability" : "Available in store"}
                                </span>
                                <div className="absolute bottom-3 left-3 right-3 flex justify-end">
                                    <SocialProofBadge product={product} compact={true} />
                                </div>
                            </div>

                            <div className="flex flex-1 flex-col p-3 sm:p-5">
                                <div className="mb-2 flex min-w-0 items-center gap-2 text-xs text-slate-500">
                                    <span className="truncate rounded bg-slate-100 px-2 py-0.5 text-slate-600">{categoryName}</span>
                                    {product.averageRating ? (
                                        <span className="flex items-center gap-1 text-amber-500">
                                            <Star className="w-3 h-3 fill-current" /> {product.averageRating.toFixed(1)}
                                        </span>
                                    ) : null}
                                </div>

                                <h3 className="mb-1 line-clamp-2 text-base font-extrabold leading-6 text-slate-950 sm:text-lg">
                                    {product.name}
                                </h3>

                                <p className="mb-3 hidden flex-1 text-sm leading-6 text-slate-500 sm:line-clamp-2">
                                    {product.description}
                                </p>

                                {/* Tags */}
                                {product.tags && product.tags.length > 0 && (
                                    <div className="mb-3 hidden flex-wrap gap-1 sm:flex">
                                        {product.tags.slice(0, 3).map(tag => (
                                            <span
                                                key={tag}
                                                className="text-xs px-2 py-0.5 bg-brand-blue/8 text-brand-blue/70 border border-brand-blue/15 rounded-full"
                                            >
                                                #{tag}
                                            </span>
                                        ))}
                                    </div>
                                )}

                                <div className="mt-auto flex items-end justify-between gap-2">
                                    <div className="flex flex-col">
                                        <span className="text-xs font-medium text-slate-500">In-store price</span>
                                        <div className="flex flex-wrap items-baseline gap-x-2">
                                            <span className="text-base font-black text-slate-950 sm:text-xl">
                                                {inrFormatter.format(product.price)}
                                            </span>
                                            {product.originalPrice && (
                                                <span className="hidden text-sm text-slate-400 line-through sm:inline">
                                                    {inrFormatter.format(product.originalPrice)}
                                                </span>
                                            )}
                                        </div>
                                    </div>
                                    <span className="inline-flex min-h-11 shrink-0 items-center gap-1 rounded-lg bg-blue-50 px-2 text-xs font-bold text-blue-800" aria-hidden="true">
                                        <span className="hidden sm:inline">View details</span><ChevronRight className="h-4 w-4" />
                                    </span>
                                </div>
                            </div>
                        </Link>
                    );
                })}
            </div>

            {loading && (
                <div className="grid grid-cols-2 gap-3 sm:gap-5 lg:grid-cols-3">
                    {[...Array(3)].map((_, i) => (
                        <div key={`skeleton-${i}`} className="skeleton-card bg-white rounded-[2rem]">
                            <div className="skeleton-image rounded-t-[2rem]" />
                            <div className="p-5 space-y-3">
                                <div className="skeleton-line-sm" />
                                <div className="skeleton-line" />
                                <div className="skeleton-line w-3/4" />
                                <div className="flex items-center justify-between pt-2">
                                    <div className="h-6 w-20 rounded-lg skeleton-shimmer" />
                                    <div className="w-8 h-8 rounded-full skeleton-shimmer" />
                                </div>
                            </div>
                        </div>
                    ))}
                </div>
            )}

            {loadError && (
                <div className="mx-auto flex w-full max-w-xl flex-col items-center rounded-2xl border border-red-200 bg-red-50 p-5 text-center" role="alert">
                    <AlertCircle className="h-6 w-6 text-red-700" aria-hidden="true" />
                    <p className="mt-2 text-sm font-semibold text-red-900">{loadError}</p>
                    <button type="button" onClick={loadMore} className="mt-4 inline-flex min-h-11 items-center gap-2 rounded-xl bg-red-800 px-4 py-2 text-sm font-bold text-white hover:bg-red-900">
                        <RefreshCcw className="h-4 w-4" aria-hidden="true" /> Retry
                    </button>
                </div>
            )}

            {hasMore && !hasActiveFilters && !loadError && (
                <div className="text-center">
                    <button type="button" onClick={loadMore} disabled={loading} className="inline-flex min-h-12 items-center justify-center rounded-xl border border-slate-300 bg-white px-5 py-3 font-bold text-slate-800 hover:bg-slate-50 disabled:opacity-60">
                        {loading ? "Loading products…" : "Load more products"}
                    </button>
                </div>
            )}

            {!hasMore && products.length > 0 && !loadError && (
                <div className="text-center py-8 text-slate-400 text-sm">
                    You&apos;ve reached the end of our collection.
                </div>
            )}
        </div>
    );
}
