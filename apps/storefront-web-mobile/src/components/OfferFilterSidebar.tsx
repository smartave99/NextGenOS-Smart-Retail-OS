"use client";

import { useState, useEffect } from "react";
import { useRouter, useSearchParams } from "next/navigation";
import { motion, AnimatePresence, useReducedMotion } from "framer-motion";
import { X, Filter, ChevronDown, Search } from "lucide-react";

export default function OfferFilterSidebar() {
    const router = useRouter();
    const searchParams = useSearchParams();
    const [isOpen, setIsOpen] = useState(false);
    const [search, setSearch] = useState(searchParams.get("search") || "");
    const [sort, setSort] = useState(searchParams.get("sort") || "newest");
    const reduceMotion = useReducedMotion();

    // Update local state when URL params change
    useEffect(() => {
        setSearch(searchParams.get("search") || "");
        setSort(searchParams.get("sort") || "newest");
    }, [searchParams]);

    const applyFilters = () => {
        const params = new URLSearchParams();
        if (search) params.set("search", search);
        if (sort && sort !== "newest") params.set("sort", sort);

        router.push(`/offers?${params.toString()}`);
        setIsOpen(false);
    };

    const clearFilters = () => {
        setSearch("");
        setSort("newest");
        router.push("/offers");
        setIsOpen(false);
    };

    return (
        <>
            {/* Desktop Sidebar */}
            <div className="hidden lg:block w-64 shrink-0">
                <div className="bg-white rounded-2xl p-6 border border-slate-100 sticky top-24 shadow-sm">
                    <div className="flex items-center gap-2 mb-6 text-brand-dark">
                        <Filter className="w-5 h-5" />
                        <h2 className="font-bold text-lg">Filters</h2>
                    </div>

                    <div className="space-y-8">
                        {/* Search */}
                        <div>
                            <h3 className="text-sm font-bold text-slate-900 uppercase tracking-wider mb-3">Search Offers</h3>
                            <div className="relative">
                                <Search className="absolute left-3 top-1/2 -translate-y-1/2 w-4 h-4 text-slate-400" />
                                <input
                                    type="text"
                                    aria-label="Search offers"
                                    placeholder="Keywords..."
                                    value={search}
                                    onChange={(e) => setSearch(e.target.value)}
                                    onKeyDown={(e) => e.key === "Enter" && applyFilters()}
                                    className="w-full pl-9 pr-3 py-2 bg-slate-50 border border-slate-200 rounded-lg text-sm focus:ring-2 focus:ring-brand-blue/50 outline-none"
                                />
                            </div>
                        </div>

                        {/* Sort */}
                        <div>
                            <h3 className="text-sm font-bold text-slate-900 uppercase tracking-wider mb-3">Sort By</h3>
                            <div className="space-y-2">
                                {[
                                    { label: "Newest First", value: "newest" },
                                    { label: "Oldest First", value: "oldest" },
                                ].map(option => (
                                    <label key={option.value} className="flex items-center gap-3 cursor-pointer group">
                                        <div className={`w-5 h-5 rounded-full border flex items-center justify-center transition-colors ${sort === option.value ? "border-brand-blue bg-brand-blue" : "border-slate-300 group-hover:border-brand-blue"}`}>
                                            {sort === option.value && <div className="w-2 h-2 bg-white rounded-full" />}
                                        </div>
                                        <input
                                            type="radio"
                                            name="offerSort"
                                            className="sr-only"
                                            checked={sort === option.value}
                                            onChange={() => setSort(option.value)}
                                        />
                                        <span className={`text-sm ${sort === option.value ? "text-slate-900 font-medium" : "text-slate-600 group-hover:text-slate-900"}`}>
                                            {option.label}
                                        </span>
                                    </label>
                                ))}
                            </div>
                        </div>

                        {/* Actions */}
                        <div className="pt-6 border-t border-slate-100 flex flex-col gap-3">
                            <button
                                type="button"
                                onClick={applyFilters}
                                className="w-full py-3 bg-brand-dark text-white rounded-xl font-bold hover:bg-black transition-colors shadow-lg shadow-brand-dark/20"
                            >
                                Apply Filters
                            </button>
                            <button
                                type="button"
                                onClick={clearFilters}
                                className="w-full py-3 bg-slate-100 text-slate-600 rounded-xl font-medium hover:bg-slate-200 transition-colors"
                            >
                                Clear All
                            </button>
                        </div>
                    </div>
                </div>
            </div>

            {/* Mobile Trigger */}
            <div className="sticky top-24 z-30 mb-6 lg:hidden">
                <button
                    type="button"
                    onClick={() => setIsOpen(true)}
                    aria-haspopup="dialog"
                    className="flex min-h-12 w-full items-center justify-between rounded-xl border border-slate-200 bg-white px-4 py-3 font-bold text-slate-700 shadow-lg shadow-slate-950/5 hover:bg-slate-50 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-blue-500"
                >
                    <span className="flex items-center gap-2"><Filter className="w-5 h-5 text-brand-blue" /> Search & Filter</span>
                    <ChevronDown className="w-4 h-4" />
                </button>
            </div>

            {/* Mobile Drawer */}
            <AnimatePresence>
                {isOpen && (
                    <>
                        <motion.div
                            initial={reduceMotion ? false : { opacity: 0 }}
                            animate={{ opacity: 1 }}
                            exit={{ opacity: 0 }}
                            onClick={() => setIsOpen(false)}
                            className="fixed inset-0 bg-black/40 backdrop-blur-sm z-50 lg:hidden"
                        />
                        <motion.div
                            initial={reduceMotion ? false : { x: "100%" }}
                            animate={{ x: 0 }}
                            exit={{ x: "100%" }}
                            transition={reduceMotion ? { duration: 0 } : { type: "spring", damping: 25, stiffness: 200 }}
                            role="dialog"
                            aria-modal="true"
                            aria-labelledby="offer-filters-title"
                            className="fixed inset-y-0 right-0 z-50 w-full max-w-sm overflow-y-auto bg-white p-6 shadow-2xl lg:hidden"
                        >
                            <div className="flex items-center justify-between mb-8">
                                <h2 id="offer-filters-title" className="text-xl font-bold text-slate-900">Search &amp; filter offers</h2>
                                <button
                                    type="button"
                                    onClick={() => setIsOpen(false)}
                                    aria-label="Close offer filters"
                                    className="grid h-11 w-11 place-items-center rounded-xl bg-slate-100 hover:bg-slate-200 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-blue-500"
                                >
                                    <X className="w-5 h-5 text-slate-600" />
                                </button>
                            </div>

                            <div className="space-y-8">
                                {/* Search */}
                                <div>
                                    <h3 className="text-sm font-bold text-slate-900 uppercase tracking-wider mb-3">Search Offers</h3>
                                    <div className="relative">
                                        <Search className="absolute left-3 top-1/2 -translate-y-1/2 w-4 h-4 text-slate-400" />
                                        <input
                                            type="text"
                                            aria-label="Search offers"
                                            placeholder="Keywords..."
                                            value={search}
                                            onChange={(e) => setSearch(e.target.value)}
                                            onKeyDown={(e) => e.key === "Enter" && applyFilters()}
                                            className="w-full pl-9 pr-3 py-2 bg-slate-50 border border-slate-200 rounded-lg text-sm focus:ring-2 focus:ring-brand-blue/50 outline-none"
                                        />
                                    </div>
                                </div>

                                {/* Sort */}
                                <div>
                                    <h3 className="text-sm font-bold text-slate-900 uppercase tracking-wider mb-3">Sort By</h3>
                                    <div className="space-y-2">
                                        {[
                                            { label: "Newest First", value: "newest" },
                                            { label: "Oldest First", value: "oldest" },
                                        ].map(option => (
                                            <label key={option.value} className="flex items-center gap-3 cursor-pointer group">
                                                <div className={`w-5 h-5 rounded-full border flex items-center justify-center transition-colors ${sort === option.value ? "border-brand-blue bg-brand-blue" : "border-slate-300 group-hover:border-brand-blue"}`}>
                                                    {sort === option.value && <div className="w-2 h-2 bg-white rounded-full" />}
                                                </div>
                                                <input
                                                    type="radio"
                                                    name="offerSort"
                                                    className="sr-only"
                                                    checked={sort === option.value}
                                                    onChange={() => setSort(option.value)}
                                                />
                                                <span className={`text-sm ${sort === option.value ? "text-slate-900 font-medium" : "text-slate-600 group-hover:text-slate-900"}`}>
                                                    {option.label}
                                                </span>
                                            </label>
                                        ))}
                                    </div>
                                </div>

                                {/* Actions */}
                                <div className="pt-6 border-t border-slate-100 flex flex-col gap-3">
                                    <button
                                        type="button"
                                        onClick={applyFilters}
                                        className="w-full py-3 bg-brand-dark text-white rounded-xl font-bold hover:bg-black transition-colors shadow-lg shadow-brand-dark/20"
                                    >
                                        Apply Filters
                                    </button>
                                    <button
                                        type="button"
                                        onClick={clearFilters}
                                        className="w-full py-3 bg-slate-100 text-slate-600 rounded-xl font-medium hover:bg-slate-200 transition-colors"
                                    >
                                        Clear All
                                    </button>
                                </div>
                            </div>
                        </motion.div>
                    </>
                )}
            </AnimatePresence>
        </>
    );
}
