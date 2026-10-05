"use client";

import { motion, useReducedMotion } from "framer-motion";
import { ArrowRight, CalendarDays, Download, MessageSquare, Store, Tag } from "lucide-react";
import { useSiteConfig } from "@/context/SiteConfigContext";
import { Offer } from "@/app/actions";
import Link from "next/link";

const dateFormatter = new Intl.DateTimeFormat("en-IN", {
    day: "numeric",
    month: "long",
    year: "numeric",
});

export default function OffersList({ offers, catalogueUrl, catalogueTitle, catalogueSubtitle }: { offers: Offer[], catalogueUrl?: string, catalogueTitle?: string, catalogueSubtitle?: string }) {
    const { config } = useSiteConfig();
    const { contact } = config;
    const reduceMotion = useReducedMotion();

    return (
        <>
            <section className="relative mb-12 overflow-hidden rounded-3xl bg-brand-dark p-6 text-white shadow-xl sm:p-8 md:p-10" aria-labelledby="store-catalogue-title">
                <div className="relative z-10 max-w-3xl">
                    <span className="inline-flex min-h-8 items-center gap-2 rounded-full border border-blue-300/25 bg-blue-300/10 px-3 text-xs font-bold text-blue-100">
                        <Store className="h-4 w-4" aria-hidden="true" /> Store catalogue
                    </span>
                    <h2 id="store-catalogue-title" className="mt-4 text-3xl font-extrabold tracking-tight md:text-4xl">
                        {catalogueTitle || "Browse before you visit"}
                    </h2>
                    <p className="mt-4 max-w-2xl text-base leading-7 text-slate-200">
                        {catalogueSubtitle || "See the current Smart Avenue catalogue, then visit the Patna store to confirm availability and purchase in person."}
                    </p>
                    {catalogueUrl ? (
                        <a href={catalogueUrl} target="_blank" rel="noopener noreferrer" className="sa-press mt-6 inline-flex min-h-12 items-center justify-center gap-3 rounded-xl bg-blue-700 px-6 py-3 font-bold text-white transition-[transform,background-color] duration-100 hover:bg-blue-800 focus-visible:ring-2 focus-visible:ring-white">
                            <Download className="h-5 w-5" aria-hidden="true" /> View store catalogue
                        </a>
                    ) : (
                        <p className="mt-6 inline-flex min-h-12 items-center justify-center gap-3 rounded-xl border border-white/20 bg-white/10 px-5 py-3 text-sm font-semibold text-slate-200" role="status">
                            Catalogue update in progress
                        </p>
                    )}
                </div>
            </section>

            <section aria-labelledby="current-offers-title">
                <div className="mb-6">
                    <h2 id="current-offers-title" className="text-2xl font-extrabold text-slate-950">Current in-store offers</h2>
                    <p className="mt-2 max-w-2xl text-base leading-6 text-slate-600">Open an offer to check its validity, conditions, and in-store redemption details.</p>
                </div>

                <div className="grid grid-cols-1 gap-5 md:grid-cols-2 lg:grid-cols-3">
                    {offers.length === 0 ? (
                        <div className="col-span-full mx-auto max-w-sm py-16 text-center">
                            <span className="mx-auto grid h-16 w-16 place-items-center rounded-2xl bg-slate-100 text-slate-500">
                                <Tag className="h-8 w-8" aria-hidden="true" />
                            </span>
                            <h3 className="mt-5 text-xl font-bold text-slate-900">No current offers</h3>
                            <p className="mt-2 text-base leading-6 text-slate-600">Browse the catalogue while the next in-store offers are prepared.</p>
                            <Link href="/products" className="mt-5 inline-flex min-h-12 items-center justify-center rounded-xl bg-blue-700 px-5 py-3 font-bold text-white hover:bg-blue-800">
                                Browse products
                            </Link>
                        </div>
                    ) : (
                        offers.map((offer, index) => (
                            <motion.article
                                key={offer.id}
                                initial={reduceMotion ? false : { opacity: 0, y: 12 }}
                                whileInView={{ opacity: 1, y: 0 }}
                                viewport={{ once: true }}
                                transition={reduceMotion ? { duration: 0 } : { duration: 0.3, delay: Math.min(index, 5) * 0.04 }}
                                className="sa-card flex flex-col rounded-3xl p-6"
                            >
                                <div className="flex items-start justify-between gap-4">
                                    <span className="grid h-12 w-12 shrink-0 place-items-center rounded-2xl bg-blue-50 text-blue-700">
                                        <Tag className="h-6 w-6" aria-hidden="true" />
                                    </span>
                                    <span className="rounded-full border border-blue-200 bg-blue-50 px-3 py-1.5 text-sm font-bold text-blue-900">{offer.discount}</span>
                                </div>

                                <h3 className="mt-5 text-2xl font-bold text-slate-950">{offer.title}</h3>
                                <p className="mt-3 line-clamp-3 flex-1 text-base leading-7 text-slate-600">{offer.description}</p>

                                <div className="mt-6 rounded-2xl bg-slate-50 p-4">
                                    <p className="flex items-center gap-2 text-sm font-semibold text-slate-700">
                                        <CalendarDays className="h-4 w-4 text-blue-700" aria-hidden="true" />
                                        Listed {dateFormatter.format(new Date(offer.createdAt))}
                                    </p>
                                    <p className="mt-2 text-sm leading-5 text-slate-600">Check the offer details for current validity and conditions before visiting.</p>
                                </div>

                                <Link
                                    href={`/offers/${offer.id}`}
                                    className="sa-press mt-5 inline-flex min-h-12 items-center justify-center gap-2 rounded-xl bg-blue-700 px-5 py-3 font-bold text-white transition-[transform,background-color] duration-100 hover:bg-blue-800"
                                >
                                    View validity and conditions <ArrowRight className="h-4 w-4" aria-hidden="true" />
                                </Link>
                            </motion.article>
                        ))
                    )}
                </div>
            </section>

            <div className="mt-16 rounded-3xl border border-slate-200 bg-white p-6 text-center sm:p-8">
                <h2 className="text-xl font-bold text-slate-950">Need information before you visit?</h2>
                <p className="mx-auto mt-2 max-w-xl text-sm leading-6 text-slate-600">Offers are redeemed in store only. A WhatsApp enquiry starts a conversation; it does not create an order or reservation.</p>
                {contact.whatsappUrl && (
                    <a
                        href={contact.whatsappUrl}
                        target="_blank"
                        rel="noopener noreferrer"
                        className="sa-press mt-5 inline-flex min-h-12 items-center gap-3 rounded-xl bg-emerald-700 px-6 py-3 font-bold text-white transition-[transform,background-color] duration-100 hover:bg-emerald-800 focus-visible:ring-2 focus-visible:ring-emerald-700 focus-visible:ring-offset-2"
                    >
                        <MessageSquare className="h-5 w-5" aria-hidden="true" /> Ask about in-store offers
                    </a>
                )}
            </div>
        </>
    );
}

