"use client";

import { motion } from "framer-motion";
import { CheckCircle2, Globe, ShieldCheck, Users, Zap, TrendingUp, MapPin, Phone, Mail, Clock, Check, Star, Heart, Award } from "lucide-react";
import type { ReactNode } from "react";
import Image from "next/image";
import { AboutPageContent, ContactContent } from "@/app/actions";
import { DEFAULT_ABOUT, safeMapEmbed } from "@/lib/default-pages";

// Map string icon names to Lucide icons
const iconMap: Record<string, React.ElementType> = {
    CheckCircle2, Globe, ShieldCheck, Users, Zap, TrendingUp, MapPin, Phone, Mail, Clock, Check, Star, Heart, Award
};

/** One line of store information (address, phone, hours, e-mail): shown only when the shop has filled it in. */
function InfoCard({ icon, title, children }: { icon: ReactNode; title: string; children: ReactNode }) {
    return (
        <div className="flex items-start gap-4 p-6 bg-white rounded-2xl shadow-sm border border-slate-100 hover:shadow-md transition-shadow">
            <div className="p-3 bg-brand-blue/10 text-brand-blue rounded-full">{icon}</div>
            <div>
                <h4 className="font-bold text-lg mb-1 text-brand-dark">{title}</h4>
                {children}
            </div>
        </div>
    );
}

export default function AboutContent({ content, contact }: { content: AboutPageContent | null, contact: ContactContent | null }) {
    // Until the shop writes its own: plain words with no claims (lib/default-pages.ts). Parts left empty are left out.
    const data = content || DEFAULT_ABOUT;
    const mapUrl = safeMapEmbed(contact?.mapEmbed);
    const hasStats = Boolean(data.statsCustomers || data.statsSatisfaction);
    const values = data.values ?? [];
    const hasContact = Boolean(contact?.address || contact?.phone || contact?.storeHours || contact?.email);

    return (
        <div className="bg-slate-50 min-h-screen">
            {/* Hero */}
            <section className="relative h-[60vh] min-h-[500px] flex items-center justify-center overflow-hidden bg-brand-dark">
                <div className="absolute inset-0">
                    <div className="absolute inset-0 bg-gradient-to-r from-brand-blue/20 to-brand-lime/20 mix-blend-overlay" />
                    {data.heroImage ? (
                        <Image src={data.heroImage} alt="Hero Background" fill className="object-cover opacity-40 mix-blend-overlay" />
                    ) : (
                        <div className="absolute inset-0 opacity-20"
                            style={{ backgroundImage: "linear-gradient(#fff 1px, transparent 1px), linear-gradient(90deg, #fff 1px, transparent 1px)", backgroundSize: "40px 40px" }}
                        />
                    )}
                </div>

                <div className="container mx-auto px-4 relative z-10 text-center text-white">
                    <motion.div
                        initial={{ opacity: 0, y: 30 }}
                        animate={{ opacity: 1, y: 0 }}
                        transition={{ duration: 0.8 }}
                    >
                        <span className="text-blue-300 font-bold tracking-[0.2em] uppercase text-sm mb-4 block">{data.heroLabel || "Our Story"}</span>
                        <h1 className="text-5xl md:text-7xl font-bold mb-6 tracking-tight">
                            {data.heroTitle}
                        </h1>
                        {data.heroSubtitle && (
                            <p className="text-xl md:text-2xl text-slate-300 max-w-3xl mx-auto font-light leading-relaxed">
                                {data.heroSubtitle}
                            </p>
                        )}
                    </motion.div>
                </div>
            </section>

            {/* Vision */}
            <section className="py-24 container mx-auto px-4 md:px-6">
                <div className="flex flex-col md:flex-row items-center gap-16">
                    <div className="flex-1 space-y-8">
                        <div>
                            <span className="text-brand-blue font-bold tracking-widest uppercase text-xs mb-2 block">{data.visionLabel || "Who we are"}</span>
                            <h2 className="text-4xl font-bold text-brand-dark mb-6 tracking-tight">{data.visionTitle}</h2>
                        </div>
                        <p className="text-slate-600 text-lg leading-relaxed">
                            {data.visionText1}
                        </p>
                        {data.visionText2 && (
                            <p className="text-slate-600 text-lg leading-relaxed">
                                {data.visionText2}
                            </p>
                        )}

                        {hasStats && (
                            <div className="grid grid-cols-2 gap-6 pt-6">
                                {data.statsCustomers && (
                                    <div className="p-4 bg-white rounded-xl shadow-sm border border-slate-100">
                                        <Users className="w-6 h-6 text-brand-blue mb-2" />
                                        <div className="text-2xl font-bold text-brand-dark">{data.statsCustomers}</div>
                                        <div className="text-sm text-slate-500">{data.statsCustomersLabel}</div>
                                    </div>
                                )}
                                {data.statsSatisfaction && (
                                    <div className="p-4 bg-white rounded-xl shadow-sm border border-slate-100">
                                        <TrendingUp className="w-6 h-6 text-brand-lime mb-2" />
                                        <div className="text-2xl font-bold text-brand-dark">{data.statsSatisfaction}</div>
                                        <div className="text-sm text-slate-500">{data.statsSatisfactionLabel}</div>
                                    </div>
                                )}
                            </div>
                        )}
                    </div>

                    {data.visionImage && (
                        <div className="flex-1 relative aspect-square w-full max-w-md mx-auto">
                            <div className="absolute inset-0 bg-brand-blue rounded-full opacity-20 blur-3xl transform -translate-x-12 translate-y-12" />
                            <div className="absolute inset-0 bg-brand-lime rounded-full opacity-20 blur-3xl transform translate-x-12 -translate-y-12" />

                            <div className="relative h-full w-full rounded-[2rem] overflow-hidden shadow-2xl border border-white/50">
                                <Image
                                    src={data.visionImage}
                                    alt="Vision"
                                    fill
                                    className="object-cover hover:scale-105 transition-transform duration-300"
                                />
                            </div>
                        </div>
                    )}
                </div>
            </section>

            {/* Values */}
            {values.length > 0 && (
                <section className="py-24 bg-white relative overflow-hidden">
                    <div className="container mx-auto px-4 md:px-6 relative z-10">
                        <div className="text-center mb-20">
                            <h2 className="text-4xl font-bold text-brand-dark mb-4 tracking-tight">{data.valuesTitle}</h2>
                            {data.valuesSubtitle && <p className="text-slate-500 max-w-2xl mx-auto">{data.valuesSubtitle}</p>}
                        </div>

                        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-8">
                            {values.map((value, index) => {
                                const IconComponent = iconMap[value.icon] || ShieldCheck;
                                return (
                                    <motion.div
                                        key={index}
                                        initial={{ opacity: 0, y: 20 }}
                                        whileInView={{ opacity: 1, y: 0 }}
                                        transition={{ delay: index * 0.1 }}
                                        className="bg-slate-50 p-8 rounded-2xl border border-slate-100 hover:border-brand-lime/50 hover:bg-white hover:shadow-xl transition-[transform,opacity,background-color,border-color,color,box-shadow] duration-300 group"
                                    >
                                        <div className={`w-14 h-14 rounded-2xl bg-white shadow-sm flex items-center justify-center mb-6 group-hover:scale-110 transition-transform duration-300 ${value.color ?? "text-brand-blue"}`}>
                                            <IconComponent className="w-7 h-7" />
                                        </div>
                                        <h3 className="text-xl font-bold text-brand-dark mb-3 group-hover:text-brand-blue transition-colors">{value.title}</h3>
                                        <p className="text-slate-500 leading-relaxed group-hover:text-slate-600">{value.desc}</p>
                                    </motion.div>
                                );
                            })}
                        </div>
                    </div>
                </section>
            )}

            {/* Contact: only what the shop has filled in */}
            {(hasContact || mapUrl) && (
                <section className="py-24 bg-slate-50 border-t border-slate-200">
                    <div className="container mx-auto px-4 md:px-6">
                        <div className="text-center mb-16">
                            <span className="text-brand-blue font-bold tracking-widest uppercase text-sm mb-2 block">Get in Touch</span>
                            <h2 className="text-4xl font-bold text-brand-dark mb-4 tracking-tight">{data.contactTitle || "Visit Our Store"}</h2>
                            {data.contactSubtitle && <p className="text-slate-500 max-w-2xl mx-auto">{data.contactSubtitle}</p>}
                        </div>

                        <div className={`grid grid-cols-1 gap-12 ${mapUrl ? "lg:grid-cols-2" : ""}`}>
                            <div className="space-y-6">
                                <h3 className="text-2xl font-bold text-brand-dark mb-6">Store Information</h3>
                                {contact?.address && (
                                    <InfoCard icon={<MapPin className="w-6 h-6" />} title="Address">
                                        <p className="text-slate-600 leading-relaxed whitespace-pre-line">{contact.address}</p>
                                    </InfoCard>
                                )}
                                {contact?.phone && (
                                    <InfoCard icon={<Phone className="w-6 h-6" />} title="Phone">
                                        <p className="text-slate-600">{contact.phone}</p>
                                    </InfoCard>
                                )}
                                {contact?.storeHours && (
                                    <InfoCard icon={<Clock className="w-6 h-6" />} title="Opening Hours">
                                        <p className="text-slate-600 whitespace-pre-line">{contact.storeHours}</p>
                                    </InfoCard>
                                )}
                                {contact?.email && (
                                    <InfoCard icon={<Mail className="w-6 h-6" />} title="Email">
                                        <p className="text-slate-600">{contact.email}</p>
                                    </InfoCard>
                                )}
                            </div>

                            {mapUrl && (
                                <div className="h-full min-h-[400px] w-full bg-slate-200 rounded-3xl overflow-hidden shadow-lg border border-slate-200 relative">
                                    <iframe
                                        src={mapUrl}
                                        title="Map"
                                        width="100%"
                                        height="100%"
                                        style={{ border: 0 }}
                                        allowFullScreen
                                        loading="lazy"
                                        referrerPolicy="no-referrer-when-downgrade"
                                        className="absolute inset-0 grayscale hover:grayscale-0 transition-[transform,opacity,background-color,border-color,color,box-shadow] duration-300"
                                    />
                                </div>
                            )}
                        </div>
                    </div>
                </section>
            )}
        </div>
    );
}
