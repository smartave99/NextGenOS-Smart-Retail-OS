"use client";

import { useEffect, useState } from "react";
import Image from "next/image";
import Link from "next/link";
import { ArrowRight, ChevronLeft, ChevronRight, Pause, Play, ShieldCheck, Sparkles, Store } from "lucide-react";
import { AnimatePresence, motion, useReducedMotion } from "framer-motion";
import { useSiteConfig } from "@/context/SiteConfigContext";

export default function Hero() {
    const { config } = useSiteConfig();
    const [currentSlide, setCurrentSlide] = useState(0);
    const [isManuallyPaused, setIsManuallyPaused] = useState(false);
    const [isInteractionPaused, setIsInteractionPaused] = useState(false);
    const reduceMotion = useReducedMotion();
    const slides = config?.hero?.slides || [];
    const isPaused = isManuallyPaused || isInteractionPaused;

    useEffect(() => {
        if (slides.length <= 1 || reduceMotion || isPaused) return;
        const timer = window.setInterval(() => {
            setCurrentSlide((previous) => (previous + 1) % slides.length);
        }, 9000);
        return () => window.clearInterval(timer);
    }, [isPaused, slides.length, reduceMotion]);

    if (slides.length === 0) return null;

    const slide = slides[currentSlide];
    const nextSlide = () => setCurrentSlide((previous) => (previous + 1) % slides.length);
    const previousSlide = () => setCurrentSlide((previous) => (previous - 1 + slides.length) % slides.length);
    const primaryCta = slide.ctaText && !/^shop\b/i.test(slide.ctaText)
        ? slide.ctaText
        : "Browse products";

    return (
        <section
            className="relative isolate flex min-h-[680px] items-end overflow-hidden bg-brand-dark pt-32 sm:min-h-[720px] lg:min-h-[760px] lg:items-center"
            aria-roledescription="carousel"
            aria-label="Featured collections"
            onMouseEnter={() => setIsInteractionPaused(true)}
            onMouseLeave={() => setIsInteractionPaused(false)}
            onFocusCapture={() => setIsInteractionPaused(true)}
            onBlurCapture={(event) => {
                if (!event.currentTarget.contains(event.relatedTarget as Node | null)) setIsInteractionPaused(false);
            }}
        >
            <AnimatePresence mode="wait" initial={false}>
                <motion.div
                    key={slide.id}
                    initial={reduceMotion ? false : { opacity: 0 }}
                    animate={{ opacity: 1 }}
                    exit={reduceMotion ? undefined : { opacity: 0 }}
                    transition={{ duration: reduceMotion ? 0 : 0.3 }}
                    className="absolute inset-0"
                    role="group"
                    aria-roledescription="slide"
                    aria-label={`${currentSlide + 1} of ${slides.length}`}
                >
                    <Image
                        src={slide.backgroundImageUrl}
                        alt=""
                        fill
                        className="object-cover object-center"
                        priority={currentSlide === 0}
                        loading={currentSlide === 0 ? "eager" : "lazy"}
                        sizes="100vw"
                    />
                    <div className="absolute inset-0 bg-[linear-gradient(90deg,rgba(7,18,37,.97)_0%,rgba(7,18,37,.82)_46%,rgba(7,18,37,.24)_82%)]" />
                    <div className="absolute inset-0 bg-gradient-to-t from-slate-950 via-transparent to-slate-950/15" />
                </motion.div>
            </AnimatePresence>

            <div className="container relative z-10 mx-auto px-4 pb-24 sm:px-6 lg:pb-16">
                <motion.div
                    key={`content-${slide.id}`}
                    initial={reduceMotion ? false : { opacity: 0, y: 18 }}
                    animate={{ opacity: 1, y: 0 }}
                    transition={{ duration: reduceMotion ? 0 : 0.3, delay: reduceMotion ? 0 : 0.08 }}
                    className="max-w-3xl"
                >
                    <div className="mb-5 inline-flex items-center gap-2 rounded-full border border-white/20 bg-white/10 px-3 py-2 text-xs font-bold text-blue-100 backdrop-blur-md">
                        <Sparkles className="h-3.5 w-3.5" aria-hidden="true" />
                        Plan your Smart Avenue store visit
                    </div>
                    <h1 className="max-w-3xl text-balance text-4xl font-black leading-[1.02] tracking-[-0.045em] text-white sm:text-6xl lg:text-7xl">
                        {slide.title}
                    </h1>
                    <p className="mt-6 max-w-2xl text-pretty text-base leading-7 text-slate-200 sm:text-xl sm:leading-8">
                        {slide.subtitle}
                    </p>
                    <div className="mt-8 flex flex-col gap-3 sm:flex-row">
                        <Link
                            href={slide.ctaLink || "/products"}
                            className="sa-press inline-flex min-h-12 items-center justify-center gap-2 rounded-xl bg-blue-700 px-6 py-3.5 text-base font-bold text-white shadow-lg shadow-blue-950/30 transition-[transform,background-color] duration-100 hover:bg-blue-800 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-white"
                        >
                            {primaryCta}
                            <ArrowRight className="h-5 w-5" aria-hidden="true" />
                        </Link>
                        <Link
                            href={slide.learnMoreLink || "/offers"}
                            className="sa-press inline-flex min-h-12 items-center justify-center rounded-xl border border-white/30 bg-white/10 px-6 py-3.5 text-base font-bold text-white backdrop-blur-md transition-[transform,background-color] duration-100 hover:bg-white/20 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-white"
                        >
                            View today&apos;s offers
                        </Link>
                    </div>

                    <div className="mt-8 flex flex-wrap gap-3 text-sm font-semibold text-slate-100">
                        <span className="inline-flex min-h-11 items-center gap-2 rounded-xl border border-white/15 bg-slate-950/35 px-4"><ShieldCheck className="h-4 w-4 text-emerald-400" aria-hidden="true" /> Trusted local shopping</span>
                        <span className="inline-flex min-h-11 items-center gap-2 rounded-xl border border-white/15 bg-slate-950/35 px-4"><Store className="h-4 w-4 text-blue-300" aria-hidden="true" /> Purchase in store</span>
                    </div>
                </motion.div>
            </div>

            {slides.length > 1 && (
                <div className="absolute bottom-5 left-4 z-20 flex items-center gap-2 sm:left-6 lg:left-auto lg:right-8">
                    <button type="button" onClick={previousSlide} aria-label="Show previous collection" className="grid h-11 w-11 place-items-center rounded-xl border border-white/20 bg-slate-950/45 text-white backdrop-blur-md hover:bg-slate-950/70 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-white">
                        <ChevronLeft className="h-5 w-5" aria-hidden="true" />
                    </button>
                    <div className="flex items-center rounded-xl border border-white/20 bg-slate-950/45 px-1 backdrop-blur-md" aria-label={`Slide ${currentSlide + 1} of ${slides.length}`}>
                        {slides.map((item, index) => (
                            <button
                                key={item.id}
                                type="button"
                                onClick={() => setCurrentSlide(index)}
                                aria-label={`Show collection ${index + 1}`}
                                aria-current={index === currentSlide ? "true" : undefined}
                                className="grid h-11 w-8 place-items-center rounded-lg focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-white"
                            >
                                <span className={`h-2 rounded-full transition-[width,background-color] duration-200 ${index === currentSlide ? "w-6 bg-blue-300" : "w-2 bg-white/50"}`} />
                            </button>
                        ))}
                    </div>
                    <button
                        type="button"
                        onClick={() => setIsManuallyPaused((paused) => !paused)}
                        aria-label={isManuallyPaused ? "Resume automatic slide rotation" : "Pause automatic slide rotation"}
                        aria-pressed={isManuallyPaused}
                        className="grid h-11 w-11 place-items-center rounded-xl border border-white/20 bg-slate-950/45 text-white backdrop-blur-md hover:bg-slate-950/70 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-white"
                    >
                        {isManuallyPaused ? <Play className="h-4 w-4" aria-hidden="true" /> : <Pause className="h-4 w-4" aria-hidden="true" />}
                    </button>
                    <button type="button" onClick={nextSlide} aria-label="Show next collection" className="grid h-11 w-11 place-items-center rounded-xl border border-white/20 bg-slate-950/45 text-white backdrop-blur-md hover:bg-slate-950/70 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-white">
                        <ChevronRight className="h-5 w-5" aria-hidden="true" />
                    </button>
                </div>
            )}
        </section>
    );
}
