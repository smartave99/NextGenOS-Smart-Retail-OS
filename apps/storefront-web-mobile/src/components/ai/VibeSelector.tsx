"use client";

import { useState } from "react";
import { useRouter } from "next/navigation";
import { Sparkles, ArrowRight, Loader2, Gift, Home, Coins, ShoppingBasket } from "lucide-react";
import { motion, useReducedMotion } from "framer-motion";
import { getVibeFilters } from "@/app/actions/vibe-check-action";

const VIBES = [
    { id: "gift", label: "Birthday Gift", icon: Gift },
    { id: "home", label: "Home Refresh", icon: Home },
    { id: "budget", label: "Budget Picks", icon: Coins },
    { id: "essentials", label: "Daily Essentials", icon: ShoppingBasket },
];

export default function VibeSelector() {
    const router = useRouter();
    const [customVibe, setCustomVibe] = useState("");
    const [isLoading, setIsLoading] = useState(false);
    const reduceMotion = useReducedMotion();

    const handleVibeCheck = async (vibe: string) => {
        setIsLoading(true);

        try {
            const response = await getVibeFilters(vibe);

            if (response.success && response.filters) {
                const params = new URLSearchParams();
                const f = response.filters;

                if (f.searchQuery) params.set("q", f.searchQuery);
                if (f.category) params.set("category", f.category);
                if (f.colors && f.colors.length > 0) params.set("color", f.colors[0]); // Simple single color for now
                if (f.priceRange?.min) params.set("minPrice", f.priceRange.min.toString());
                if (f.priceRange?.max) params.set("maxPrice", f.priceRange.max.toString());

                router.push(`/products?${params.toString()}`);
            } else {
                console.error("Vibe Check Failed:", response.error);
                setIsLoading(false);
            }
        } catch (error) {
            console.error("Vibe Check Error:", error);
            setIsLoading(false);
        }
    };

    return (
        <section className="bg-white py-14 sm:py-20" aria-labelledby="smart-shopping-title">
            <div className="container mx-auto px-4 max-w-7xl">
                <div className="text-center mb-10">
                    <span className="inline-flex items-center gap-2 px-3 py-1 rounded-full bg-slate-100 border border-slate-200 text-slate-600 text-[13px] font-medium mb-4">
                        <Sparkles className="w-3.5 h-3.5" />
                        Smart shopping assistant
                    </span>
                    <h2 id="smart-shopping-title" className="text-3xl sm:text-4xl font-extrabold tracking-tight text-slate-900 mb-4">Tell us what you need</h2>
                    <p className="text-slate-600 max-w-2xl mx-auto">
                        Pick a starting point or describe the occasion. We&apos;ll narrow the store to a useful, budget-friendly collection.
                    </p>
                </div>

                <div className="max-w-4xl mx-auto bg-white rounded-[2rem] p-6 sm:p-10 border border-slate-200/60 shadow-sm relative overflow-hidden">
                    {/* Minimal decorative background (optional, keeping it extremely subtle) */}
                    <div className="absolute top-0 right-0 w-64 h-64 bg-slate-50 rounded-full blur-3xl -translate-y-1/2 translate-x-1/2"></div>

                    <div className="relative z-10">
                        {/* Preset Vibes */}
                        <div className="grid grid-cols-2 md:grid-cols-4 gap-4 mb-8">
                            {VIBES.map((v) => (
                                <motion.button
                                    key={v.id}
                                    whileHover={reduceMotion ? undefined : { y: -2 }}
                                    whileTap={reduceMotion ? undefined : { scale: 0.98 }}
                                    onClick={() => handleVibeCheck(v.label)}
                                    disabled={isLoading}
                                    className={`group flex min-h-36 flex-col items-center justify-center rounded-2xl border border-slate-200 bg-white p-4 shadow-sm transition-[border-color,box-shadow] hover:border-blue-300 hover:shadow-md focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-blue-500 sm:p-6 ${isLoading ? "cursor-not-allowed opacity-50" : ""
                                        }`}
                                >
                                    <div className={`p-3.5 rounded-full mb-4 bg-slate-50 text-slate-400 group-hover:bg-slate-900 group-hover:text-white transition-colors`}>
                                        <v.icon className="w-5 h-5" />
                                    </div>
                                    <span className="font-semibold text-sm text-slate-700 group-hover:text-slate-900 transition-colors tracking-tight">{v.label}</span>
                                </motion.button>
                            ))}
                        </div>

                        {/* Custom Vibe Input */}
                        <div className="relative flex flex-col sm:flex-row gap-3 sm:gap-0 sm:p-2 sm:rounded-full bg-transparent sm:bg-white sm:shadow-lg sm:shadow-slate-200/50 sm:border sm:border-slate-100 items-center">
                            <input
                                type="text"
                                value={customVibe}
                                onChange={(e) => setCustomVibe(e.target.value)}
                                placeholder="Try: a birthday gift for a 10-year-old on a small budget"
                                aria-label="Describe what you are shopping for"
                                className="w-full sm:flex-1 px-6 py-4 sm:py-3 rounded-2xl sm:rounded-full bg-white sm:bg-transparent border border-slate-200 sm:border-none shadow-sm sm:shadow-none text-[15px] text-slate-900 placeholder:text-slate-400 focus:outline-none focus:ring-2 focus:ring-slate-900/5 sm:focus:ring-0 transition-[transform,opacity,background-color,border-color,color,box-shadow] font-medium"
                                onKeyDown={(e) => e.key === "Enter" && handleVibeCheck(customVibe)}
                                disabled={isLoading}
                            />
                            <button
                                type="button"
                                onClick={() => handleVibeCheck(customVibe)}
                                disabled={!customVibe.trim() || isLoading}
                                className="w-full sm:w-auto p-4 sm:p-3 bg-slate-900 text-white rounded-2xl sm:rounded-full hover:bg-slate-800 disabled:opacity-50 transition-colors flex items-center justify-center gap-2 sm:px-6 font-medium tracking-tight"
                            >
                                {isLoading ? (
                                    <>
                                        <Loader2 className="w-4 h-4 animate-spin" />
                                        Curating...
                                    </>
                                ) : (
                                    <>
                                        Find Vibe
                                        <ArrowRight className="w-4 h-4 ml-0.5" />
                                    </>
                                )}
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
}

