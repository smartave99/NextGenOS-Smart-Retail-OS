"use client";

import { useState, useEffect, useRef, useCallback } from "react";
import Image from "next/image";
import { Film, Zap, Play, Pause, RotateCw } from "lucide-react";
import { useReducedMotion } from "framer-motion";
import { SHOP_NAME } from "@/lib/shop-name";

interface ImageGalleryProps {
    images: string[];
    videoUrl?: string | null;
    productName: string;
    discount?: number;
    isFeatured?: boolean;
    autoRotate?: boolean;
}

export default function ImageGallery({
    images,
    videoUrl,
    productName,
    discount = 0,
    isFeatured = false,
    autoRotate = false
}: ImageGalleryProps) {
    const reduceMotion = useReducedMotion();
    const [activeIndex, setActiveIndex] = useState(0);
    const [isPlaying, setIsPlaying] = useState(autoRotate);
    const [isHovered, setIsHovered] = useState(false);
    const [isTransitioning, setIsTransitioning] = useState(false);
    const resumeTimeoutRef = useRef<NodeJS.Timeout | null>(null);
    const rotationIntervalRef = useRef<NodeJS.Timeout | null>(null);

    const allMedia = [
        ...images.map(url => ({ type: "image" as const, url })),
        ...(videoUrl ? [{ type: "video" as const, url: videoUrl }] : [])
    ];

    // Only auto-rotate through images (skip video)
    const imageCount = images.length;
    const currentMedia = allMedia[activeIndex] || { type: "image", url: "" };

    // Calculate rotation progress for the indicator
    const [progress, setProgress] = useState(0);
    const progressRef = useRef(0);
    const progressIntervalRef = useRef<NodeJS.Timeout | null>(null);

    const ROTATION_INTERVAL = 3000; // 3 seconds per image
    const RESUME_DELAY = 8000; // 8 seconds before auto-resume

    const clearTimers = useCallback(() => {
        if (rotationIntervalRef.current) {
            clearInterval(rotationIntervalRef.current);
            rotationIntervalRef.current = null;
        }
        if (progressIntervalRef.current) {
            clearInterval(progressIntervalRef.current);
            progressIntervalRef.current = null;
        }
        if (resumeTimeoutRef.current) {
            clearTimeout(resumeTimeoutRef.current);
            resumeTimeoutRef.current = null;
        }
    }, []);

    const startRotation = useCallback(() => {
        if (imageCount <= 1) return;

        clearTimers();
        progressRef.current = 0;
        setProgress(0);

        // Progress bar update every 30ms
        progressIntervalRef.current = setInterval(() => {
            progressRef.current += (250 / ROTATION_INTERVAL) * 100;
            setProgress(Math.min(progressRef.current, 100));
        }, 250);

        // Rotate to next image
        rotationIntervalRef.current = setInterval(() => {
            setIsTransitioning(true);
            setTimeout(() => {
                setActiveIndex(prev => {
                    const next = (prev + 1) % imageCount;
                    return next;
                });
                setIsTransitioning(false);
            }, 200);
            progressRef.current = 0;
            setProgress(0);
        }, ROTATION_INTERVAL);
    }, [imageCount, clearTimers]);

    // Start/stop rotation based on isPlaying and isHovered
    useEffect(() => {
        if (isPlaying && !reduceMotion && !isHovered && imageCount > 1) {
            startRotation();
        } else {
            clearTimers();
        }

        return () => clearTimers();
    }, [isPlaying, reduceMotion, isHovered, imageCount, startRotation, clearTimers]);

    const handleManualSelect = (index: number) => {
        setActiveIndex(index);
        setIsPlaying(false);
        clearTimers();

        // Auto-resume after 8 seconds
        if (resumeTimeoutRef.current) clearTimeout(resumeTimeoutRef.current);
        resumeTimeoutRef.current = setTimeout(() => {
            if (autoRotate && imageCount > 1) {
                setIsPlaying(true);
            }
        }, RESUME_DELAY);
    };

    const togglePlayPause = () => {
        if (isPlaying) {
            setIsPlaying(false);
            clearTimers();
        } else {
            setIsPlaying(true);
        }
    };

    return (
        <div className="space-y-4">
            {/* Main Display */}
            <div
                className="relative aspect-square bg-white rounded-3xl overflow-hidden shadow-sm border border-slate-100 flex items-center justify-center"
                onMouseEnter={() => setIsHovered(true)}
                onMouseLeave={() => setIsHovered(false)}
            >
                <div
                    className={`absolute inset-0 transition-opacity duration-300 ${isTransitioning ? "opacity-0" : "opacity-100"}`}
                >
                    {currentMedia.type === "image" ? (
                        <Image
                            src={currentMedia.url}
                            alt={`${productName} - product image at ${SHOP_NAME}`}
                            fill
                            className="object-cover"
                            priority
                            quality={95}
                            sizes="(max-width: 768px) 100vw, (max-width: 1200px) 50vw, 58vw"
                        />
                    ) : (
                        <div className="relative w-full h-full bg-black flex items-center justify-center">
                            <video
                                src={currentMedia.url}
                                className="max-w-full max-h-full"
                                controls
                                preload="metadata"
                            />
                        </div>
                    )}
                </div>

                {/* Badges */}
                <div className="absolute top-4 left-4 flex flex-col gap-2 z-10">
                    {discount > 0 && (
                        <span className="bg-brand-lime text-brand-dark px-3 py-1 rounded-full text-xs font-bold uppercase tracking-wider">
                            {discount}% OFF
                        </span>
                    )}
                    {isFeatured && (
                        <span className="bg-brand-dark text-white px-3 py-1 rounded-full text-xs font-bold uppercase tracking-wider flex items-center gap-1">
                            <Zap className="w-3 h-3 fill-current" /> Hot
                        </span>
                    )}
                </div>

                {/* Auto-rotate play/pause control */}
                {imageCount > 1 && (
                    <button
                        type="button"
                        onClick={togglePlayPause}
                        aria-label={isPlaying ? "Pause image slideshow" : "Play image slideshow"}
                        className="absolute top-4 right-4 z-10 p-2 bg-black/40 backdrop-blur-sm text-white rounded-full hover:bg-black/60 transition-[transform,opacity,background-color,border-color,color,box-shadow] group"
                        title={isPlaying ? "Pause auto-rotate" : "Resume auto-rotate"}
                    >
                        {isPlaying ? (
                            <Pause className="w-3.5 h-3.5" />
                        ) : (
                            <RotateCw className="w-3.5 h-3.5" />
                        )}
                    </button>
                )}

                {currentMedia.type === "video" && (
                    <div className="absolute bottom-4 left-4 px-2 py-1 bg-black/60 text-white text-xs rounded flex items-center gap-1 z-10 font-bold uppercase tracking-widest">
                        <Film className="w-3 h-3" /> Video Mode
                    </div>
                )}

                {/* Progress bar for auto-rotation */}
                {isPlaying && imageCount > 1 && !isHovered && (
                    <div className="absolute bottom-0 left-0 right-0 h-1 bg-black/10 z-10">
                        <div
                            className="h-full bg-brand-blue/80 transition-none"
                            style={{ width: `${progress}%` }}
                        />
                    </div>
                )}

                {/* Image counter */}
                {imageCount > 1 && (
                    <div className="absolute bottom-4 right-4 z-10 px-2.5 py-1 bg-black/40 backdrop-blur-sm rounded-full text-white text-xs font-bold tabular-nums">
                        {activeIndex + 1} / {imageCount}
                    </div>
                )}
            </div>

            {/* Thumbnails */}
            {allMedia.length > 1 && (
                <div className="flex gap-2 overflow-x-auto pb-2 scrollbar-none">
                    {allMedia.map((media, index) => (
                        <button
                            key={`${media.url}-${index}`}
                            type="button"
                            onClick={() => handleManualSelect(index)}
                            aria-label={`Show ${media.type === "video" ? "product video" : `product image ${index + 1}`}`}
                            aria-current={activeIndex === index ? "true" : undefined}
                            className={`relative w-20 h-20 rounded-xl overflow-hidden border-2 transition-[transform,opacity,background-color,border-color,color,box-shadow] shrink-0 ${activeIndex === index ? "border-brand-blue shadow-md scale-105" : "border-transparent opacity-70 hover:opacity-100"
                                }`}
                        >
                            {media.type === "image" ? (
                                <Image
                                    src={media.url}
                                    alt={`${productName} - view ${index + 1} of ${allMedia.length}`}
                                    fill
                                    className="object-cover"
                                    loading="lazy"
                                    quality={90}
                                    sizes="80px"
                                />
                            ) : (
                                <div className="w-full h-full bg-slate-900 flex items-center justify-center">
                                    <Film className="w-6 h-6 text-white opacity-50" />
                                    <div className="absolute inset-0 flex items-center justify-center">
                                        <Play className="w-6 h-6 text-white fill-white opacity-80" />
                                    </div>
                                </div>
                            )}

                            {/* Active indicator ring animation */}
                            {activeIndex === index && isPlaying && (
                                <div className="absolute inset-0 border-2 border-brand-blue rounded-xl animate-pulse pointer-events-none" />
                            )}
                        </button>
                    ))}
                </div>
            )}
        </div>
    );
}


