"use client";

import { useCallback, useEffect, useRef, useState } from "react";
import Image from "next/image";
import Link from "next/link";
import { usePathname, useRouter } from "next/navigation";
import { MapPin, Menu, PackagePlus, ScanLine, Search, Sparkles, X } from "lucide-react";
import { useSiteConfig } from "@/context/SiteConfigContext";
import BarcodeScanner from "@/components/BarcodeScanner";
import { useDialogFocus } from "@/components/ui/useDialogFocus";
import { SHOP_NAME } from "@/lib/shop-name";
import { TERM } from "@/lib/industry/lite";

const PRODUCT_REQUEST_LINK = { label: "Request a Product", href: "/request-product" };

const DEFAULT_NAV_LINKS = [
    { label: "Home", href: "/" },
    { label: TERM.item.plural, href: "/products" },
    { label: "Offers", href: "/offers" },
    { label: "Departments", href: "/departments" },
    { label: "About Us", href: "/about" },
    { label: "Genie Stylist", href: "/stylist" },
    { label: "Genie Gift Finder", href: "/gift-finder" },
];

const SMART_LINKS = new Set(["/stylist", "/gift-finder"]);

export default function Header() {
    const [isScrolled, setIsScrolled] = useState(false);
    const [isMenuOpen, setIsMenuOpen] = useState(false);
    const [isSearchOpen, setIsSearchOpen] = useState(false);
    const [isBarcodeScannerOpen, setIsBarcodeScannerOpen] = useState(false);
    const [searchQuery, setSearchQuery] = useState("");
    const searchInputRef = useRef<HTMLInputElement>(null);
    const searchDialogRef = useRef<HTMLDivElement>(null);
    const searchTriggerRef = useRef<HTMLButtonElement>(null);
    const menuDialogRef = useRef<HTMLDivElement>(null);
    const menuTriggerRef = useRef<HTMLButtonElement>(null);
    const menuCloseRef = useRef<HTMLButtonElement>(null);
    const pathname = usePathname();
    const router = useRouter();
    const { config } = useSiteConfig();

    const configuredNavLinks = config?.headerLinks?.length ? config.headerLinks : DEFAULT_NAV_LINKS;
    const navLinks = configuredNavLinks.some((link) => link.href === PRODUCT_REQUEST_LINK.href)
        ? configuredNavLinks
        : [...configuredNavLinks, PRODUCT_REQUEST_LINK];
    const primaryLinks = navLinks.filter(
        (link) => !SMART_LINKS.has(link.href) && link.href !== PRODUCT_REQUEST_LINK.href
    );
    const smartLink = navLinks.find((link) => link.href === "/gift-finder") || navLinks.find((link) => SMART_LINKS.has(link.href));
    const textColor = config.theme.navbarTextColor || config.theme.textColor || "#0f172a";

    useEffect(() => {
        const handleScroll = () => setIsScrolled(window.scrollY > 12);
        handleScroll();
        window.addEventListener("scroll", handleScroll, { passive: true });
        return () => window.removeEventListener("scroll", handleScroll);
    }, []);

    useEffect(() => {
        setIsMenuOpen(false);
        setIsSearchOpen(false);
        setIsBarcodeScannerOpen(false);
    }, [pathname]);

    const closeMenu = useCallback(() => setIsMenuOpen(false), []);
    const closeSearch = useCallback(() => setIsSearchOpen(false), []);

    useDialogFocus({
        open: isMenuOpen,
        onClose: closeMenu,
        containerRef: menuDialogRef,
        initialFocusRef: menuCloseRef,
        returnFocusRef: menuTriggerRef,
    });

    useDialogFocus({
        open: isSearchOpen,
        onClose: closeSearch,
        containerRef: searchDialogRef,
        initialFocusRef: searchInputRef,
        returnFocusRef: searchTriggerRef,
    });

    const openSearch = () => {
        setIsSearchOpen(true);
        setIsMenuOpen(false);
        window.setTimeout(() => searchInputRef.current?.focus(), 50);
    };

    const handleSearch = (event: React.FormEvent) => {
        event.preventDefault();
        const query = searchQuery.trim();
        if (!query) return;
        router.push(`/products?search=${encodeURIComponent(query)}`);
        setSearchQuery("");
        setIsSearchOpen(false);
    };

    const closeBarcodeScanner = useCallback(() => {
        setIsBarcodeScannerOpen(false);
    }, []);

    const handleBarcodeDetected = useCallback((barcode: string) => {
        const value = barcode.trim();
        if (!value) return;
        setSearchQuery("");
        setIsBarcodeScannerOpen(false);
        setIsSearchOpen(false);
        router.push(`/products?search=${encodeURIComponent(value)}`);
    }, [router]);

    return (
        <header className="fixed inset-x-0 top-0 z-[60] px-3 pt-3 sm:px-5 sm:pt-4">
            <div
                className={`mx-auto flex h-16 max-w-7xl items-center gap-3 rounded-2xl border px-3 transition-[background-color,box-shadow,border-color] duration-300 sm:px-4 ${
                    isScrolled
                        ? "border-slate-200/90 bg-white/95 shadow-[0_12px_40px_rgba(15,23,42,0.12)] backdrop-blur-xl"
                        : "border-white/50 bg-white/85 shadow-lg shadow-slate-950/5 backdrop-blur-xl"
                }`}
                style={{ color: textColor }}
            >
                <Link href="/" className="flex min-w-0 shrink-0 items-center gap-2 rounded-xl focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-blue-500" aria-label={`${SHOP_NAME} home`}>
                    <span className="relative h-11 w-11 shrink-0 overflow-hidden rounded-xl bg-white ring-1 ring-slate-200">
                        <Image
                            src={config.branding.logoUrl || "/logo.png"}
                            alt=""
                            fill
                            className="object-contain p-1"
                            priority
                        />
                    </span>
                    <span className="hidden min-w-0 xl:block">
                        <span className="block truncate text-sm font-extrabold tracking-tight text-slate-950">
                            {config.branding.siteName || SHOP_NAME}
                        </span>
                        <span className="block text-xs font-semibold text-slate-500">Find something brilliant</span>
                    </span>
                </Link>

                <nav className="hidden min-w-0 flex-1 items-center justify-center gap-1 lg:flex" aria-label="Main navigation">
                    {primaryLinks.slice(0, 5).map((link) => {
                        const isActive = pathname === link.href || (link.href !== "/" && pathname.startsWith(`${link.href}/`));
                        return (
                            <Link
                                key={link.href}
                                href={link.href}
                                aria-current={isActive ? "page" : undefined}
                                className={`whitespace-nowrap rounded-xl px-3 py-2 text-sm font-semibold transition-colors focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-blue-500 ${
                                    isActive ? "bg-slate-950 text-white" : "text-slate-600 hover:bg-slate-100 hover:text-slate-950"
                                }`}
                            >
                                {link.label}
                            </Link>
                        );
                    })}
                </nav>

                <div className="ml-auto flex shrink-0 items-center gap-2">
                    {/* Icon-only on mobile so it stays in the bar next to search
                        and menu; full label once there is room at md. */}
                    <Link
                        href={PRODUCT_REQUEST_LINK.href}
                        aria-current={pathname === PRODUCT_REQUEST_LINK.href ? "page" : undefined}
                        aria-label={PRODUCT_REQUEST_LINK.label}
                        className={`grid h-11 w-11 place-items-center rounded-xl text-sm font-bold transition-colors focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-blue-500 md:flex md:h-auto md:w-auto md:items-center md:gap-2 md:px-3 md:py-2 ${
                            pathname === PRODUCT_REQUEST_LINK.href
                                ? "bg-slate-950 text-white"
                                : "bg-emerald-50 text-emerald-800 hover:bg-emerald-100"
                        }`}
                    >
                        <PackagePlus className="h-5 w-5 md:h-4 md:w-4" aria-hidden="true" />
                        <span className="hidden md:inline">Request product</span>
                    </Link>
                    {smartLink && (
                        <Link
                            href={smartLink.href}
                            className="hidden items-center gap-2 rounded-xl bg-blue-50 px-3 py-2 text-sm font-bold text-blue-700 transition-colors hover:bg-blue-100 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-blue-500 xl:flex"
                        >
                            <Sparkles className="h-4 w-4" aria-hidden="true" />
                            Gift finder
                        </Link>
                    )}
                    <button
                        ref={searchTriggerRef}
                        type="button"
                        onClick={openSearch}
                        className="grid h-11 w-11 place-items-center rounded-xl border border-slate-200 bg-white text-slate-700 transition-colors hover:bg-slate-100 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-blue-500"
                        aria-label={`Search ${TERM.item.pluralLower}`}
                    >
                        <Search className="h-5 w-5" aria-hidden="true" />
                    </button>
                    <button
                        ref={menuTriggerRef}
                        type="button"
                        onClick={() => setIsMenuOpen(true)}
                        className="grid h-11 w-11 place-items-center rounded-xl bg-slate-950 text-white focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-blue-500 lg:hidden"
                        aria-label="Open menu"
                        aria-expanded={isMenuOpen}
                    >
                        <Menu className="h-5 w-5" aria-hidden="true" />
                    </button>
                </div>
            </div>

            <div className="mx-auto mt-2 flex w-fit max-w-[calc(100vw-1.5rem)] items-center justify-center gap-1.5 rounded-full border border-amber-200/80 bg-amber-50/95 px-3 py-2 text-center text-xs font-bold leading-4 text-amber-950 shadow-sm backdrop-blur sm:text-sm">
                <MapPin className="h-3.5 w-3.5 shrink-0" aria-hidden="true" />
                <span>Browse online. Purchase in store only — no delivery or remote orders.</span>
            </div>

            {isSearchOpen && (
                <div ref={searchDialogRef} tabIndex={-1} className="fixed inset-0 z-[70] bg-slate-950/50 p-3 backdrop-blur-sm sm:p-5" role="dialog" aria-modal="true" aria-labelledby="site-search-title">
                    <button className="absolute inset-0 cursor-default" onClick={closeSearch} aria-label="Close search" />
                    <form onSubmit={handleSearch} className="relative mx-auto mt-20 flex max-w-2xl items-center gap-2 rounded-2xl bg-white p-2 shadow-2xl">
                        <h2 id="site-search-title" className="sr-only">Search {SHOP_NAME} products</h2>
                        <Search className="ml-3 h-5 w-5 shrink-0 text-slate-400" aria-hidden="true" />
                        <label htmlFor="site-search" className="sr-only">{`Search ${TERM.item.pluralLower}`}</label>
                        <input
                            id="site-search"
                            ref={searchInputRef}
                            type="search"
                            value={searchQuery}
                            onChange={(event) => setSearchQuery(event.target.value)}
                            placeholder={config.labels?.placeholders?.search || config.branding.searchPlaceholder || "Search by product name or barcode"}
                            className="min-w-0 flex-1 bg-transparent px-2 py-3 text-base text-slate-950 outline-none placeholder:text-slate-400"
                        />
                        <button
                            type="button"
                            onClick={() => setIsBarcodeScannerOpen(true)}
                            className="grid h-11 w-11 shrink-0 place-items-center rounded-xl border border-slate-200 text-blue-700 hover:bg-blue-50 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-blue-500"
                            aria-label="Scan product barcode"
                            title="Scan product barcode"
                        >
                            <ScanLine className="h-5 w-5" aria-hidden="true" />
                        </button>
                        <button type="submit" className="rounded-xl bg-blue-600 px-5 py-3 text-sm font-bold text-white hover:bg-blue-700 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-blue-500">
                            Search
                        </button>
                        <button type="button" onClick={closeSearch} className="grid h-11 w-11 place-items-center rounded-xl text-slate-500 hover:bg-slate-100" aria-label="Close search">
                            <X className="h-5 w-5" aria-hidden="true" />
                        </button>
                    </form>
                </div>
            )}

            <BarcodeScanner
                open={isBarcodeScannerOpen}
                onClose={closeBarcodeScanner}
                onDetected={handleBarcodeDetected}
            />

            {isMenuOpen && (
                <div ref={menuDialogRef} tabIndex={-1} className="fixed inset-0 z-[80] lg:hidden" role="dialog" aria-modal="true" aria-labelledby="mobile-navigation-title">
                    <button className="absolute inset-0 bg-slate-950/55 backdrop-blur-sm" onClick={closeMenu} aria-label="Close menu" />
                    <div className="absolute inset-y-0 right-0 flex w-[min(90vw,380px)] flex-col bg-white p-5 shadow-2xl">
                        <div className="flex items-center justify-between border-b border-slate-100 pb-5">
                            <div>
                                <h2 id="mobile-navigation-title" className="font-extrabold text-slate-950">{config.branding.siteName || SHOP_NAME}</h2>
                                <p className="text-sm text-slate-500">Explore the store</p>
                            </div>
                            <button ref={menuCloseRef} type="button" onClick={closeMenu} className="grid h-11 w-11 place-items-center rounded-xl bg-slate-100 text-slate-700" aria-label="Close menu">
                                <X className="h-5 w-5" aria-hidden="true" />
                            </button>
                        </div>
                        <nav className="flex-1 space-y-1 overflow-y-auto py-5" aria-label="Mobile navigation">
                            {navLinks.map((link) => {
                                const isActive = pathname === link.href;
                                return (
                                    <Link
                                        key={link.href}
                                        href={link.href}
                                        aria-current={isActive ? "page" : undefined}
                                        className={`flex min-h-12 items-center justify-between rounded-xl px-4 py-3 text-base font-bold ${isActive ? "bg-slate-950 text-white" : "text-slate-700 hover:bg-slate-100"}`}
                                    >
                                        {link.label}
                                        {SMART_LINKS.has(link.href) && <Sparkles className="h-4 w-4 text-blue-500" aria-hidden="true" />}
                                    </Link>
                                );
                            })}
                        </nav>
                        <Link href="/products" className="rounded-xl bg-blue-600 px-5 py-4 text-center font-bold text-white hover:bg-blue-700">
                            Browse all products
                        </Link>
                    </div>
                </div>
            )}
        </header>
    );
}
