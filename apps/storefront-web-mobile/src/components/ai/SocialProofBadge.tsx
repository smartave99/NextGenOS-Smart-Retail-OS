"use client";

import { useState, useEffect } from "react";
import { Users, TrendingUp } from "lucide-react";
import { getSocialProof } from "@/app/actions/conversion-boosters-action";

interface SocialProofBadgeProps {
    product: {
        id: string;
        name: string;
        categoryId: string;
        tags: string[];
    };
    compact?: boolean;
}

export default function SocialProofBadge({ product, compact = false }: SocialProofBadgeProps) {
    const [proof, setProof] = useState<string | null>(null);

    useEffect(() => {
        const cacheKey = `social_proof_${product.id}`;
        const cached = sessionStorage.getItem(cacheKey);

        if (cached) {
            setProof(cached);
            return;
        }

        const fetchProof = async () => {
            // Generate deterministic stats from product ID for consistency
            // (same product always shows same social proof)
            const idHash = product.id.split("").reduce((acc, char) => acc + char.charCodeAt(0), 0);
            const cities = ["Mumbai", "Delhi", "Bangalore", "Hyderabad", "Pune", "Kolkata", "Chennai", "Patna"];
            const stats = {
                salesInLastMonth: (idHash % 45) + 15, // Range: 15-59
                popularInCity: cities[idHash % cities.length]
            };

            const res = await getSocialProof(product, stats);
            if (res.success && res.proof) {
                setProof(res.proof);
                sessionStorage.setItem(cacheKey, res.proof);
            }
        };

        fetchProof();
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [product.id]);

    if (!proof) return null;

    if (compact) {
        return (
            <div className="absolute top-2 left-2 z-10 bg-white/90 backdrop-blur-sm px-2 py-1 rounded-full text-xs font-bold text-slate-700 shadow-sm border border-slate-100 flex items-center gap-1 max-w-[90%] truncate">
                <TrendingUp className="w-3 h-3 text-brand-blue shrink-0" />
                <span className="truncate">{proof}</span>
            </div>
        );
    }

    return (
        <div className="flex items-center gap-2 text-sm text-slate-600 bg-slate-50 px-3 py-1.5 rounded-full border border-slate-100 w-fit">
            <Users className="w-4 h-4 text-brand-blue" />
            <span className="font-medium">{proof}</span>
        </div>
    );
}

