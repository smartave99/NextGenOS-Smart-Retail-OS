import Link from "next/link";
import Image from "next/image";
import { ArrowRight, Facebook, Instagram, Mail, MapPin, Store, Twitter } from "lucide-react";
import { useSiteConfig } from "@/context/SiteConfigContext";
import { SHOP_NAME } from "@/lib/shop-name";

export default function Footer() {
    const { config } = useSiteConfig();
    const { branding, contact, footer } = config;
    const socialLinks = [
        { label: "Facebook", Icon: Facebook, url: footer.socialLinks.facebook !== "#" ? footer.socialLinks.facebook : contact?.facebookUrl },
        { label: "Instagram", Icon: Instagram, url: footer.socialLinks.instagram !== "#" ? footer.socialLinks.instagram : branding?.instagramUrl },
        { label: "X", Icon: Twitter, url: footer.socialLinks.twitter !== "#" ? footer.socialLinks.twitter : contact?.twitterUrl },
    ].filter((social) => social.url && social.url !== "#");

    return (
        <footer className="relative overflow-hidden border-t border-white/10 bg-brand-dark text-white">
            <div className="mx-auto max-w-7xl px-4 py-12 sm:px-6 lg:px-8 lg:py-16">
                <div className="mb-10 flex flex-col gap-5 rounded-3xl border border-white/15 bg-white/[0.07] p-5 sm:flex-row sm:items-center sm:justify-between sm:p-6">
                    <div className="flex items-start gap-4">
                        <span className="grid h-12 w-12 shrink-0 place-items-center rounded-2xl bg-emerald-400/15 text-emerald-300">
                            <Store className="h-6 w-6" aria-hidden="true" />
                        </span>
                        <div>
                            <h2 className="text-lg font-bold">Browse online, purchase in store</h2>
                            <p className="mt-1 max-w-2xl text-sm leading-6 text-slate-300">
                                Check products and offers before you visit. The website does not take payments, deliveries, or remote orders.
                            </p>
                        </div>
                    </div>
                    <Link
                        href="/products"
                        className="sa-press inline-flex min-h-12 shrink-0 items-center justify-center gap-2 rounded-xl bg-blue-700 px-5 py-3 font-bold text-white transition-[transform,background-color] duration-100 hover:bg-blue-800"
                    >
                        Browse products <ArrowRight className="h-4 w-4" aria-hidden="true" />
                    </Link>
                </div>

                <div className="grid gap-10 border-b border-white/10 pb-10 md:grid-cols-2 lg:grid-cols-12">
                    <div className="lg:col-span-4">
                        <Link href="/" aria-label={`${SHOP_NAME} home`} className="inline-flex items-center gap-3 rounded-xl">
                            <span className="relative h-14 w-14 overflow-hidden rounded-2xl border border-white/15 bg-white/10">
                                <Image
                                    src={branding.logoUrl || "/logo.png"}
                                    alt=""
                                    fill
                                    className="object-contain p-1.5"
                                    sizes="56px"
                                />
                            </span>
                            <span>
                                <span className="block text-lg font-extrabold">{branding.siteName || SHOP_NAME}</span>
                                <span className="block text-sm text-slate-300">Patna&apos;s local discovery catalogue</span>
                            </span>
                        </Link>
                        <p className="mt-5 max-w-sm text-sm leading-6 text-slate-300">
                            {footer.tagline || branding.tagline}
                        </p>
                        <div className="mt-6 space-y-3 text-sm text-slate-300">
                            {contact.address && (
                                <p className="flex items-start gap-3">
                                    <MapPin className="mt-0.5 h-5 w-5 shrink-0 text-blue-300" aria-hidden="true" />
                                    <span>{contact.address}</span>
                                </p>
                            )}
                            {contact.email && (
                                <a href={`mailto:${contact.email}`} className="flex min-h-11 items-center gap-3 rounded-lg hover:text-white">
                                    <Mail className="h-5 w-5 shrink-0 text-blue-300" aria-hidden="true" />
                                    <span className="break-all">{contact.email}</span>
                                </a>
                            )}
                        </div>
                    </div>

                    <nav className="lg:col-span-2" aria-label="Shop links">
                        <h2 className="text-sm font-bold text-white">{footer.navigation.shop.title}</h2>
                        <ul className="mt-4 space-y-1">
                            {footer.navigation.shop.links.map((link) => (
                                <li key={`${link.href}-${link.name}`}>
                                    <Link href={link.href} className="flex min-h-11 items-center rounded-lg text-sm text-slate-300 transition-colors duration-100 hover:text-white">
                                        {link.name}
                                    </Link>
                                </li>
                            ))}
                        </ul>
                    </nav>

                    <nav className="lg:col-span-2" aria-label="Company links">
                        <h2 className="text-sm font-bold text-white">{footer.navigation.company.title}</h2>
                        <ul className="mt-4 space-y-1">
                            {footer.navigation.company.links.map((link) => (
                                <li key={`${link.href}-${link.name}`}>
                                    <Link href={link.href} className="flex min-h-11 items-center rounded-lg text-sm text-slate-300 transition-colors duration-100 hover:text-white">
                                        {link.name}
                                    </Link>
                                </li>
                            ))}
                        </ul>
                    </nav>

                    <div className="lg:col-span-4">
                        <h2 className="text-xl font-bold">Plan your visit</h2>
                        <p className="mt-3 max-w-md text-sm leading-6 text-slate-300">
                            See current offers, then contact the store if you need help confirming a product before travelling.
                        </p>
                        <div className="mt-5 flex flex-col gap-3 sm:flex-row">
                            <Link href="/offers" className="sa-press inline-flex min-h-12 items-center justify-center gap-2 rounded-xl bg-blue-700 px-5 py-3 font-bold transition-[transform,background-color] duration-100 hover:bg-blue-800">
                                View current offers <ArrowRight className="h-4 w-4" aria-hidden="true" />
                            </Link>
                            {contact.email && (
                                <a href={`mailto:${contact.email}`} className="sa-press inline-flex min-h-12 items-center justify-center rounded-xl border border-white/25 bg-white/10 px-5 py-3 font-bold transition-[transform,background-color] duration-100 hover:bg-white/15">
                                    Contact the store
                                </a>
                            )}
                        </div>
                    </div>
                </div>

                <div className="flex flex-col gap-6 pt-8 text-sm text-slate-400 md:flex-row md:items-center md:justify-between">
                    <p>
                        {config.labels?.messages?.copyright
                            ? config.labels.messages.copyright.replace("{year}", new Date().getFullYear().toString())
                            : `© ${new Date().getFullYear()} ${branding.siteName || "${SHOP_NAME}"}. All rights reserved.`}
                    </p>
                    <div className="flex flex-wrap items-center gap-x-5 gap-y-2">
                        {footer.bottomLinks.map((link) => (
                            <Link key={`${link.href}-${link.name}`} href={link.href === "/sitemap" ? "/site-map" : link.href} className="flex min-h-11 items-center rounded-lg hover:text-white">
                                {link.name}
                            </Link>
                        ))}
                        {socialLinks.map(({ label, Icon, url }) => (
                            <a key={label} href={url} target="_blank" rel="noopener noreferrer" aria-label={`Open ${SHOP_NAME} on ${label}`} className="grid h-11 w-11 place-items-center rounded-xl border border-white/15 text-slate-300 transition-colors duration-100 hover:bg-white/10 hover:text-white">
                                <Icon className="h-4 w-4" aria-hidden="true" />
                            </a>
                        ))}
                    </div>
                </div>
            </div>
        </footer>
    );
}

