"use client";

import Link from "next/link";
import Image from "next/image";
import { ArrowRight } from "lucide-react";
import ChatTriggerButton from "@/components/ChatTriggerButton";
import { CTAContent } from "@/app/actions";

export default function CTA({ content, aiEnabled = true }: { content?: CTAContent; aiEnabled?: boolean }) {
    if (!content) {
        return null;
    }

    const backgroundImage = content.images?.[0] || content.backgroundImage;

    return (
        <section className="relative flex min-h-[460px] items-center overflow-hidden py-16 sm:py-20" aria-labelledby="cta-heading">
            <div className="absolute inset-0 z-0">
                {backgroundImage ? (
                    <>
                        <Image src={backgroundImage} alt="" fill className="object-cover" sizes="100vw" />
                        <div className="absolute inset-0 bg-slate-950/75" />
                    </>
                ) : (
                    <div className="absolute inset-0 bg-brand-dark">
                        <div className="absolute inset-0 bg-gradient-to-r from-brand-blue/20 to-brand-lime/20 mix-blend-overlay" />
                        <div className="absolute top-0 right-0 w-full h-full bg-[radial-gradient(ellipse_at_top_right,_var(--tw-gradient-stops))] from-brand-blue/30 via-transparent to-transparent opacity-50" />
                    </div>
                )}
            </div>

            <div className="container mx-auto px-4 relative z-10 text-center">
                <h2 id="cta-heading" className="text-balance text-3xl md:text-5xl font-black text-white mb-6 tracking-tight max-w-4xl mx-auto">
                    {content.title}
                </h2>
                <p className="text-pretty text-lg leading-8 text-slate-300 mb-9 max-w-2xl mx-auto">
                    {content.text}
                </p>
                <div className="flex flex-col sm:flex-row gap-4 justify-center">
                    <Link
                        href={content.ctaLink || "/products"}
                        className="inline-flex min-h-12 items-center justify-center gap-2 rounded-xl bg-blue-600 px-7 py-3.5 font-bold text-white transition-colors hover:bg-blue-500 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-white"
                    >
                        {content.ctaPrimary} <ArrowRight className="w-5 h-5" />
                    </Link>
                    {/* Secondary Action - dynamic check if it's "Chat with Us" or a link */}
                    {content.ctaSecondary === "Chat with Us" && aiEnabled ? (
                        <ChatTriggerButton />
                    ) : (
                        <Link
                            href="/register"
                            className="inline-flex min-h-12 items-center justify-center rounded-xl border border-white/25 bg-white/10 px-7 py-3.5 font-bold text-white backdrop-blur-md transition-colors hover:bg-white/20 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-white"
                        >
                            {content.ctaSecondary === "Chat with Us" ? "Register Now" : content.ctaSecondary}
                        </Link>
                    )}
                </div>
            </div>
        </section>
    );
}
