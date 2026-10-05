"use client";

import { useState, useEffect, useCallback } from "react";
import Link from "next/link";
import Image from "next/image";
import {
    ArrowRight,
    ChevronLeft,
    ChevronRight,
    Package,
    PenTool,
    Smile,
    Utensils,
    Home as HomeIcon,
    Smartphone,
    Cpu,
    LucideIcon,
} from "lucide-react";
import type { DepartmentContent } from "@/app/actions";
import { useReducedMotion } from "framer-motion";

const iconMap: Record<string, LucideIcon> = {
    PenTool,
    Smile,
    Utensils,
    Home: HomeIcon,
    Package,
    Smartphone,
    Cpu,
};

interface Props {
    departments: DepartmentContent[];
    exploreLabel?: string;
}

export default function HighlightsCarousel({ departments, exploreLabel }: Props) {
    const [currentIndex, setCurrentIndex] = useState(0);
    const [isPaused, setIsPaused] = useState(false);
    const [visibleCount, setVisibleCount] = useState(3);
    const reduceMotion = useReducedMotion();

    // Responsive breakpoints
    useEffect(() => {
        const update = () => {
            if (window.innerWidth < 768) setVisibleCount(1);
            else if (window.innerWidth < 1024) setVisibleCount(2);
            else setVisibleCount(3);
        };
        update();
        window.addEventListener("resize", update);
        return () => window.removeEventListener("resize", update);
    }, []);

    const maxIndex = Math.max(0, departments.length - visibleCount);

    const goNext = useCallback(() => {
        setCurrentIndex((prev) => (prev >= maxIndex ? 0 : prev + 1));
    }, [maxIndex]);

    const goPrev = useCallback(() => {
        setCurrentIndex((prev) => (prev <= 0 ? maxIndex : prev - 1));
    }, [maxIndex]);

    // Auto-advance every 5 seconds
    useEffect(() => {
        if (isPaused || reduceMotion || departments.length <= visibleCount) return;
        const timer = setInterval(goNext, 5000);
        return () => clearInterval(timer);
    }, [isPaused, reduceMotion, goNext, departments.length, visibleCount]);

    // Clamp index when visibleCount changes
    useEffect(() => {
        setCurrentIndex((prev) => Math.min(prev, maxIndex));
    }, [maxIndex]);

    const showControls = departments.length > visibleCount;

    return (
        <div
            className="relative"
            onMouseEnter={() => setIsPaused(true)}
            onMouseLeave={() => setIsPaused(false)}
            onFocusCapture={() => setIsPaused(true)}
            onBlurCapture={() => setIsPaused(false)}
            aria-roledescription="carousel"
            aria-label="Shop by department"
        >
            {/* Carousel Track */}
            <div className="overflow-hidden">
                <div
                    className="flex transition-transform duration-300 ease-in-out motion-reduce:transition-none"
                    style={{
                        transform: `translateX(-${currentIndex * (100 / visibleCount)}%)`,
                    }}
                >
                    {departments.map((item, idx) => {
                        const Icon = iconMap[item.icon] || Package;
                        return (
                            <div
                                key={item.id || idx}
                                className="flex-shrink-0 px-4 first:pl-0 last:pr-0"
                                style={{ width: `${100 / visibleCount}%` }}
                            >
                                <Link
                                    href={item.link || `/departments#${item.id}`}
                                    className="group relative block h-[430px] overflow-hidden rounded-3xl bg-white shadow-xl shadow-brand-dark/5 transition-shadow duration-300 hover:shadow-2xl hover:shadow-brand-blue/10 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-blue-500 focus-visible:ring-offset-4 sm:h-[500px]"
                                >
                                    {/* Image Container */}
                                    <div className="absolute inset-0 h-2/3 overflow-hidden">
                                        <div className="absolute inset-0 bg-brand-dark/10 group-hover:bg-transparent transition-colors z-10" />
                                        <Image
                                            src={item.image}
                                            alt={item.title}
                                            fill
                                            className="object-cover transition-transform duration-300 motion-safe:group-hover:scale-105"
                                            sizes="(max-width: 768px) 100vw, (max-width: 1200px) 50vw, 33vw"
                                        />
                                    </div>

                                    {/* Content Container */}
                                    <div className="absolute bottom-0 inset-x-0 h-1/2 bg-gradient-to-t from-white via-white to-transparent pt-12 px-8 pb-8 flex flex-col justify-end">
                                        <div className="relative z-10">
                                            <div className="w-14 h-14 rounded-2xl bg-brand-blue/10 flex items-center justify-center mb-6 text-brand-blue group-hover:bg-brand-blue group-hover:text-white transition-colors duration-300">
                                                <Icon className="w-7 h-7" />
                                            </div>
                                            <h3 className="text-2xl font-bold text-brand-dark mb-2 group-hover:text-brand-blue transition-colors">
                                                {item.title}
                                            </h3>
                                            <p className="text-slate-500 mb-6 line-clamp-2">
                                                {item.description}
                                            </p>
                                            <div className="flex items-center text-brand-dark font-medium text-sm group-hover:translate-x-2 transition-transform duration-300">
                                                {exploreLabel || "Explore Zone"}{" "}
                                                <ArrowRight className="w-4 h-4 ml-2" />
                                            </div>
                                        </div>
                                    </div>
                                </Link>
                            </div>
                        );
                    })}
                </div>
            </div>

            {/* Navigation Arrows */}
            {showControls && (
                <>
                    <button
                        type="button"
                        onClick={goPrev}
                        className="absolute left-0 top-1/2 -translate-y-1/2 -translate-x-4 w-12 h-12 rounded-full bg-white/90 backdrop-blur-sm shadow-lg border border-slate-200 flex items-center justify-center text-brand-dark hover:bg-brand-blue hover:text-white transition-[transform,opacity,background-color,border-color,color,box-shadow] duration-300 z-20"
                        aria-label="Show previous departments"
                    >
                        <ChevronLeft className="w-5 h-5" />
                    </button>
                    <button
                        type="button"
                        onClick={goNext}
                        className="absolute right-0 top-1/2 -translate-y-1/2 translate-x-4 w-12 h-12 rounded-full bg-white/90 backdrop-blur-sm shadow-lg border border-slate-200 flex items-center justify-center text-brand-dark hover:bg-brand-blue hover:text-white transition-[transform,opacity,background-color,border-color,color,box-shadow] duration-300 z-20"
                        aria-label="Show next departments"
                    >
                        <ChevronRight className="w-5 h-5" />
                    </button>
                </>
            )}

            {/* Dot Indicators */}
            {showControls && (
                <div className="flex justify-center gap-2 mt-8">
                    {Array.from({ length: maxIndex + 1 }).map((_, i) => (
                        <button
                            key={i}
                            type="button"
                            onClick={() => setCurrentIndex(i)}
                            className={`h-2 rounded-full transition-[transform,opacity,background-color,border-color,color,box-shadow] duration-300 ${
                                i === currentIndex
                                    ? "w-8 bg-brand-blue"
                                    : "w-2 bg-slate-300 hover:bg-slate-400"
                            }`}
                            aria-label={`Go to slide ${i + 1}`}
                            aria-current={i === currentIndex ? "true" : undefined}
                        />
                    ))}
                </div>
            )}
        </div>
    );
}

