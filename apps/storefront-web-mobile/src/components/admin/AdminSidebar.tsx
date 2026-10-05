"use client";

import { useCallback, useEffect, useRef, useState } from "react";
import Link from "next/link";
import { usePathname, useRouter } from "next/navigation";
import { useAuth } from "@/context/auth-context";
import {
    Activity,
    LayoutDashboard,
    Home,
    ShoppingBag,
    Megaphone,
    Tag,
    Users,
    MessageSquare,
    Bot,
    LogOut,
    X,
    ChevronDown,
    ChevronRight,
    Store,
    Search,
    PanelBottom,
    ClipboardList,
    Smartphone,
    Settings,
    Image,
    Images
} from "lucide-react";
import { useDialogFocus } from "@/components/ui/useDialogFocus";

// Define generic type for nav items to avoid TS errors in the component
type NavItem = {
    name: string;
    href?: string;
    icon: React.ComponentType<{ className?: string }>;
    subItems?: { name: string; href: string; permission?: string; uploadFolder?: string }[];
    permission?: string;
    uploadFolder?: string;
};

type NavGroup = {
    title: string;
    permission?: string;
    items: NavItem[];
};

const navGroups: NavGroup[] = [
    {
        title: "Overview",
        items: [
            { name: "Dashboard", href: "/admin", icon: LayoutDashboard },
            // The shop's figures from the POS, live; it asks for the owner's Supabase sign-in as well.
            { name: "Live shop", href: "/admin/live", icon: Activity, permission: "live-shop" },
        ]
    },
    {
        title: "Catalog",
        items: [
            { name: "Products", href: "/admin/content/products", icon: ShoppingBag, permission: "products" },
            { name: "Categories", href: "/admin/content/categories", icon: Tag, permission: "categories" },
            { name: "Offers", href: "/admin/content/offers", icon: Megaphone, permission: "offers" },
        ]
    },
    {
        title: "Pages",
        items: [
            {
                name: "Homepage",
                icon: Home,
                href: "/admin/storefront",
                permission: "storefront",
                subItems: [
                    { name: "Hero Section", href: "/admin/content/hero", permission: "hero", uploadFolder: "hero" },
                    { name: "Highlights", href: "/admin/content/highlights", permission: "highlights", uploadFolder: "homepage" },
                    { name: "Promotions", href: "/admin/content/promotions", permission: "promotions", uploadFolder: "promotions" },
                    { name: "Features", href: "/admin/content/features", permission: "features", uploadFolder: "homepage" },
                    { name: "CTA Section", href: "/admin/content/cta", permission: "cta", uploadFolder: "homepage" },
                ]
            },
            {
                name: "About Us",
                href: "/admin/content/about",
                icon: Users,
                permission: "about",
                uploadFolder: "about",
                subItems: [
                    { name: "Contact Info", href: "/admin/content/contact", permission: "contact" }
                ]
            },
            { name: "Departments", href: "/admin/content/departments", icon: Tag, permission: "departments", uploadFolder: "departments" },
            {
                name: "Shop Page",
                href: "/admin/content/products-page",
                icon: Store,
                permission: "products-page",
                uploadFolder: "products",
                subItems: [
                    { name: "Listing Page", href: "/admin/content/products-page", permission: "products-page" },
                    { name: "Specific Product Page", href: "/admin/content/specific-product-page", permission: "products-page" }
                ]
            },
            { name: "Special Offers", href: "/admin/content/offers-page", icon: Megaphone, permission: "offers-page", uploadFolder: "offers" },
            {
                name: "Footer",
                href: "/admin/content/footer",
                icon: PanelBottom,
                permission: "footer",
                uploadFolder: "branding",
                subItems: [
                    { name: "Privacy Policy", href: "/admin/content/privacy", permission: "privacy" },
                    { name: "Terms of Service", href: "/admin/content/terms", permission: "terms" },
                    { name: "Navigation", href: "/admin/content/navigation", permission: "navigation" },
                ]
            },
        ]
    },
    {
        title: "Feedback",
        items: [
            { name: "Reviews", href: "/admin/content/reviews", icon: MessageSquare, permission: "reviews", uploadFolder: "reviews" },
        ]
    },
    {
        title: "Design",
        items: [
            { name: "Brand Identity", href: "/admin/content/branding", icon: Image, permission: "branding" },
            { name: "Mobile App", href: "/admin/branding", icon: Smartphone, permission: "branding" },
            { name: "SEO & Metadata", href: "/admin/content/seo", icon: Search, permission: "seo" },
            { name: "Media Library", href: "/admin/media", icon: Images, permission: "branding" },
        ]
    },
    {
        title: "System",
        items: [
            { name: "Staff", href: "/admin/staff", icon: Users, permission: "staff" },
            { name: "Settings", href: "/admin/settings", icon: Settings },
            {
                name: "Genie Assistant",
                href: "/admin/api-keys",
                icon: Bot,
                permission: "api-keys",
                subItems: [
                    { name: "API Keys", href: "/admin/api-keys", permission: "api-keys" },
                    { name: "AI Settings", href: "/admin/ai-settings", permission: "api-keys" },
                    { name: "Prompt Registry", href: "/admin/ai-prompts", permission: "api-keys" },
                ]
            },
        ]
    },
    {
        title: "Others",
        items: [
            {
                name: "Configuration",
                href: "/admin/others/configuration",
                icon: Settings,
                permission: "system"
            },
            {
                name: "Frontend Labels",
                href: "/admin/others/labels",
                icon: Tag,
                permission: "system"
            },
            {
                name: "PWA Manifest",
                href: "/admin/others/manifest",
                icon: Smartphone,
                permission: "branding"
            },
            {
                name: "Data Management",
                icon: ClipboardList,
                permission: "system",
                subItems: [
                    { name: "Newsletter", href: "/admin/others/newsletter" },
                    { name: "Product Requests", href: "/admin/requests" }, // Keeping existing route but grouped here
                ]
            },
        ]
    }
];

export default function AdminSidebar({ mobileOpen, setMobileOpen }: { mobileOpen: boolean, setMobileOpen: (open: boolean) => void }) {
    const { user, logout, role, permissions } = useAuth();
    const router = useRouter();
    const pathname = usePathname();
    const [isDesktop, setIsDesktop] = useState(false);
    const sidebarRef = useRef<HTMLElement>(null);
    const closeRef = useRef<HTMLButtonElement>(null);
    const closeMobile = useCallback(() => setMobileOpen(false), [setMobileOpen]);

    useEffect(() => {
        const media = window.matchMedia("(min-width: 1024px)");
        const update = () => setIsDesktop(media.matches);
        update();
        media.addEventListener("change", update);
        return () => media.removeEventListener("change", update);
    }, []);

    useDialogFocus({
        open: mobileOpen && !isDesktop,
        onClose: closeMobile,
        containerRef: sidebarRef,
        initialFocusRef: closeRef,
    });

    // Manage expanded expanded state for top-level groups
    const [expandedGroups, setExpandedGroups] = useState<Record<string, boolean>>({
        "Overview": true,
        "Catalog": true,
        "Pages": true,
        "Feedback": false,
        "Design": true,
        "System": false,
        "Others": false
    });

    // Manage expanded state for nested items (like Homepage)
    const [expandedItems, setExpandedItems] = useState<Record<string, boolean>>({
        "Homepage": true
    });


    const handleLogout = async () => {
        await logout();
        router.push("/admin/login");
    };

    const toggleGroup = (title: string) => {
        setExpandedGroups(prev => ({ ...prev, [title]: !prev[title] }));
    };

    const toggleItem = (name: string) => {
        setExpandedItems(prev => ({ ...prev, [name]: !prev[name] }));
    };

    if (!user) {
        return (
            <aside className="hidden lg:flex flex-col w-64 h-full bg-brand-dark border-r border-white/10 fixed lg:static inset-y-0 left-0 z-50">
                <div className="p-6 border-b border-white/10">
                    <div className="h-6 w-32 bg-white/10 rounded animate-pulse" />
                </div>
            </aside>
        );
    }

    return (
        <>
            {/* Mobile overlay */}
            {mobileOpen && (
                <div
                    className="fixed inset-0 bg-black/50 z-40 lg:hidden"
                    onClick={closeMobile}
                    aria-hidden="true"
                />
            )}

            {/* Sidebar */}
            <aside
                ref={sidebarRef}
                tabIndex={-1}
                role={mobileOpen && !isDesktop ? "dialog" : undefined}
                aria-modal={mobileOpen && !isDesktop ? "true" : undefined}
                aria-label={mobileOpen && !isDesktop ? "Admin navigation" : undefined}
                aria-hidden={!isDesktop && !mobileOpen}
                inert={!isDesktop && !mobileOpen ? true : undefined}
                className={`
                fixed lg:static inset-y-0 left-0 z-50 w-64 bg-brand-dark text-white transform transition-transform duration-300 ease-in-out flex flex-col border-r border-white/10
                ${mobileOpen ? 'translate-x-0' : '-translate-x-full lg:translate-x-0'}
            `}>
                {/* Logo */}
                <div className="p-6 border-b border-white/10 flex items-center justify-between">
                    <div>
                        <h1 className="text-xl font-serif tracking-tight">
                            Smart<span className="italic text-brand-blue">Avenue</span>
                        </h1>
                        <p className="text-brand-blue/80 text-xs uppercase tracking-widest mt-1">{role} Portal</p>
                    </div>
                    <button ref={closeRef} type="button" onClick={closeMobile} className="grid h-11 w-11 place-items-center rounded-xl text-white/80 hover:bg-white/10 hover:text-white lg:hidden" aria-label="Close admin navigation">
                        <X className="h-5 w-5" aria-hidden="true" />
                    </button>
                </div>

                {/* Navigation */}
                <nav className="flex-1 overflow-y-auto py-4 px-3 space-y-6">
                    {navGroups.map((group) => {
                        // Helper to check if a user has access
                        const hasAccess = (permission?: string) => {
                            if (role?.toLowerCase() === "admin" || (permissions && permissions.includes("*"))) return true;
                            if (!permission) return true;
                            return permissions && permissions.includes(permission);
                        };

                        // Filter items within groups based on permissions
                        const accessibleItems = group.items.flatMap((item) => {
                            const accessibleSubItems = item.subItems?.filter((sub) => hasAccess(sub.permission));
                            if (item.subItems?.length && !accessibleSubItems?.length && !hasAccess(item.permission)) return [];
                            if (!item.subItems?.length && !hasAccess(item.permission)) return [];
                            return [{ ...item, subItems: accessibleSubItems }];
                        });

                        if (accessibleItems.length === 0) return null;

                        // Special case: Only Admin can see System group for now, 
                        // unless we want to allow Managers with "staff" permission.
                        // Let's rely on the permission check above which handles "staff" and "api-keys".

                        return (
                            <div key={group.title}>
                                <button
                                    type="button"
                                    onClick={() => toggleGroup(group.title)}
                                    aria-expanded={Boolean(expandedGroups[group.title])}
                                    className="mb-2 flex min-h-11 w-full items-center justify-between rounded-lg px-3 text-xs font-semibold uppercase tracking-wider text-white/70 transition-colors hover:bg-white/5 hover:text-white"
                                >
                                    {group.title}
                                    {expandedGroups[group.title] ? <ChevronDown className="w-3 h-3" /> : <ChevronRight className="w-3 h-3" />}
                                </button>

                                {expandedGroups[group.title] && (
                                    <div className="space-y-0.5">
                                        {accessibleItems.map((item) => {
                                            const Icon = item.icon;
                                            const hasSubItems = item.subItems && item.subItems.length > 0;

                                            // Check if parent or any child is active
                                            const isParentActive = item.href === pathname;
                                            const isChildActive = item.subItems?.some(sub => sub.href === pathname);
                                            const isActive = isParentActive || isChildActive;

                                            return (
                                                <div key={item.name}>
                                                    {/* Parent Item */}
                                                    <div className="relative flex items-center gap-1">
                                                        {item.href ? (
                                                            <Link
                                                                href={item.href}
                                                                onClick={closeMobile}
                                                                aria-current={isParentActive ? "page" : undefined}
                                                                className={`flex min-h-11 min-w-0 flex-1 items-center gap-3 rounded-lg px-3 text-sm font-medium transition-[background-color,color] duration-100 ${isActive ? "bg-white/10 text-white" : "text-white/70 hover:bg-white/5 hover:text-white"}`}
                                                            >
                                                                <Icon className={`h-4 w-4 shrink-0 ${isActive ? "text-blue-300" : "text-white/60"}`} aria-hidden="true" />
                                                                <span className="truncate">{item.name}</span>
                                                            </Link>
                                                        ) : (
                                                            <button
                                                                type="button"
                                                                onClick={() => toggleItem(item.name)}
                                                                aria-expanded={Boolean(expandedItems[item.name])}
                                                                className="flex min-h-11 min-w-0 flex-1 items-center gap-3 rounded-lg px-3 text-left text-sm font-medium text-white/70 transition-[background-color,color] duration-100 hover:bg-white/5 hover:text-white"
                                                            >
                                                                <Icon className="h-4 w-4 shrink-0 text-white/60" aria-hidden="true" />
                                                                <span className="truncate">{item.name}</span>
                                                            </button>
                                                        )}
                                                        {hasSubItems && item.href && (
                                                            <button
                                                                type="button"
                                                                onClick={() => toggleItem(item.name)}
                                                                aria-label={`${expandedItems[item.name] ? "Collapse" : "Expand"} ${item.name}`}
                                                                aria-expanded={Boolean(expandedItems[item.name])}
                                                                className="grid h-11 w-11 shrink-0 place-items-center rounded-lg text-white/70 hover:bg-white/10 hover:text-white"
                                                            >
                                                                {expandedItems[item.name] ? <ChevronDown className="h-4 w-4" aria-hidden="true" /> : <ChevronRight className="h-4 w-4" aria-hidden="true" />}
                                                            </button>
                                                        )}
                                                    </div>

                                                    {/* Sub Items */}
                                                    {hasSubItems && expandedItems[item.name] && (
                                                        <div className="ml-9 mt-0.5 space-y-0.5 border-l border-white/10 pl-2">
                                                            {item.subItems!.map((sub) => {
                                                                const isSubActive = pathname === sub.href;
                                                                return (
                                                                    <Link
                                                                        key={sub.href}
                                                                        href={sub.href}
                                                                        onClick={() => setMobileOpen(false)}
                                                                        aria-current={isSubActive ? "page" : undefined}
                                                                        className={`
                                                                            flex min-h-11 items-center rounded-md px-3 text-sm font-medium transition-colors
                                                                            ${isSubActive
                                                                                ? "text-brand-blue bg-white/5"
                                                                                : "text-white/50 hover:text-white hover:bg-white/5"
                                                                            }
                                                                        `}
                                                                    >
                                                                        <div className="flex items-center justify-between group/sub">
                                                                            <span>{sub.name}</span>
                                                                        </div>
                                                                    </Link>
                                                                );
                                                            })}
                                                        </div>
                                                    )}
                                                </div>
                                            );
                                        })}
                                    </div>
                                )}
                            </div>
                        );
                    })}
                </nav>

                {/* User Profile */}
                <div className="p-4 border-t border-white/10 bg-black/20">
                    <div className="flex items-center gap-3 mb-3">
                        <div className="w-8 h-8 rounded-full bg-brand-blue flex items-center justify-center text-white font-bold text-xs">
                            {user.email?.charAt(0).toUpperCase()}
                        </div>
                        <div className="flex-1 overflow-hidden">
                            <p className="text-sm font-medium text-white truncate">{user.email}</p>
                            <p className="text-xs text-brand-blue/80 truncate capitalize">{role}</p>
                        </div>
                    </div>
                    <button
                        type="button"
                        onClick={handleLogout}
                        className="flex min-h-11 w-full items-center justify-center gap-2 rounded-lg border border-white/10 bg-white/5 px-4 text-sm font-medium text-white/70 transition-[background-color,border-color,color] duration-100 hover:border-red-400/30 hover:bg-red-500/20 hover:text-red-200"
                    >
                        <LogOut className="w-3.5 h-3.5" />
                        Sign Out
                    </button>
                </div>
            </aside>

        </>
    );
}
