import { TERM } from "@/lib/industry/lite";
export interface BrandingConfig {
    siteName: string;
    tagline: string;
    logoUrl: string;
    faviconUrl: string;
    posterUrl?: string;
    pwaScreenshotUrl?: string;
    instagramUrl?: string;
    whatsappUrl?: string;
    searchPlaceholder?: string;
}

export interface ThemeConfig {
    primaryColor: string;
    secondaryColor: string;
    accentColor: string;
    backgroundColor: string;
    textColor: string;
    navbarColor: string;
    navbarTextColor: string;
    navbarOpaque: boolean;
}

export interface HeroSlide {
    id: string;
    title: string;
    subtitle: string;
    ctaText: string;
    ctaLink: string;
    learnMoreLink?: string;
    backgroundImageUrl: string;
    overlayOpacity: number;
}

export interface HeroConfig extends DeprecatedHeroConfig {
    slides: HeroSlide[];
}

export interface DeprecatedHeroConfig {
    title?: string;
    subtitle?: string;
    ctaText?: string;
    ctaLink?: string;
    learnMoreLink?: string;
    backgroundImageUrl?: string;
    overlayOpacity?: number;
}

export interface PromotionItem {
    id: string;
    imageUrl: string;
    title?: string;
    link?: string;
    active: boolean;
}

export interface HeaderLink {
    label: string;
    href: string;
}

export interface FooterLink {
    name: string;
    href: string;
}

export interface FooterSection {
    title: string;
    links: FooterLink[];
}

export interface FooterConfig {
    logoUrl?: string;
    logoPublicId?: string;
    tagline: string;
    newsletter: {
        title: string;
        description: string;
        subtext?: string;
    };
    socialSectionTitle?: string;
    socialLinks: {
        facebook: string;
        instagram: string;
        twitter: string;
    };
    navigation: {
        shop: FooterSection;
        company: FooterSection;
    };
    bottomLinks: FooterLink[];
}

export interface PromotionsConfig {
    enabled: boolean;
    title: string;
    items: PromotionItem[];
}

export interface SystemConfig {
    maintenanceMode: boolean;
    robotsTxt: string; // Custom content for robots.txt
    sitemapXml?: string; // Optional custom sitemap URL or content
    scripts: {
        googleAnalyticsId?: string;
        facebookPixelId?: string;
        customHeadScript?: string;
        customBodyScript?: string;
    };
}

export interface ManifestConfig {
    name: string;
    shortName: string;
    description: string;
    themeColor: string;
    backgroundColor: string;
    display: 'standalone' | 'fullscreen' | 'minimal-ui' | 'browser';
    startUrl: string;
}

export interface FrontendLabels {
    placeholders: {
        search: string;
        email: string;
    };
    buttons: {
        subscribe: string;
        viewCollection: string;
        shopNow: string;
        search: string;
    };
    messages: {
        success: string;
        error: string;
        loading: string;
        footerConnect: string;
        footerNoSpam: string;
        copyright: string;
    }
}

export interface SeoConfig {
    siteTitle: string;
    titleTemplate: string;
    metaDescription: string;
    keywords: string[];
    ogImageUrl: string;
    twitterHandle: string;
    googleVerification: string;
    jsonLd: {
        name: string;
        url: string;
        logo: string;
        description: string;
        addressCountry: string;
        priceRange: string;
    };
}

export interface LlmConfig {
    allowAiBots: boolean;
    brandIdentityText: string;
    llmsTxtContent: string;
    faqItems: { question: string; answer: string }[];
}

export interface SiteConfig {
    branding: BrandingConfig;
    theme: ThemeConfig;
    hero: HeroConfig;
    promotions: PromotionsConfig;
    footer: FooterConfig;
    sections: {
        showSmartClub: boolean;
        showWeeklyOffers: boolean;
        showDepartments: boolean;
        showTestimonials: boolean;
    };
    contact: {
        email: string;
        phone: string;
        address: string;
        mapEmbedUrl: string;
        facebookUrl?: string;
        instagramUrl?: string;
        twitterUrl?: string;
        whatsappUrl?: string;
        storeHours: string;
    };
    headerLinks?: HeaderLink[];
    system: SystemConfig;
    manifest: ManifestConfig;
    labels: FrontendLabels;
    seo: SeoConfig;
    llm: LlmConfig;
}

// A new site starts neutral: the shop's own name and address come from the licence's brand, the Brand Studio or the admin pages.
// NEXT_PUBLIC_SITE_NAME and NEXT_PUBLIC_SITE_URL let a deployment set them without touching code.
const SHOP = process.env.NEXT_PUBLIC_SITE_NAME || "My Shop";
const SITE_URL = (process.env.NEXT_PUBLIC_SITE_URL || "https://example.com").replace(/\/+$/, "");
const SITE_HOST = SITE_URL.replace(/^https?:\/\//, "");

export const DEFAULT_SITE_CONFIG: SiteConfig = {
    branding: {
        siteName: SHOP,
        tagline: "Everything you need, in one place",
        logoUrl: "/logo.png",
        faviconUrl: "/favicon.ico",
        posterUrl: "",
        pwaScreenshotUrl: "",
        instagramUrl: "",
        whatsappUrl: "",
        searchPlaceholder: "Search collections..."
    },
    theme: {
        primaryColor: "#0f6cbd", // Neutral blue (the brand kit replaces this)
        secondaryColor: "#f59e0b", // Amber
        accentColor: "#0071e3", // Blue
        backgroundColor: "#f8fafc", // Slate 50
        textColor: "#0f172a", // Slate 900
        navbarColor: "#ffffff", // White
        navbarTextColor: "#0f172a", // Slate 900
        navbarOpaque: true,
    },
    hero: {
        slides: [
            {
                id: "default-slide-1",
                title: `Welcome to ${SHOP}`,
                subtitle: "Quality products and friendly service.",
                ctaText: "View Collection",
                ctaLink: "/products",
                backgroundImageUrl: "https://images.unsplash.com/photo-1567401893414-76b7b1e5a7a5?q=80&w=2070&auto=format&fit=crop",
                overlayOpacity: 0.6,
            }
        ]
    },
    promotions: {
        enabled: true,
        title: "Special Offers",
        items: []
    },
    sections: {
        showSmartClub: true,
        showWeeklyOffers: true,
        showDepartments: true,
        showTestimonials: true,
    },
    footer: {
        logoUrl: "",
        tagline: `${SHOP}: quality products and friendly service.`,
        newsletter: {
            title: "Stay in touch",
            description: "Get the latest collections and exclusive offers sent to your inbox.",
            subtext: "No spam, unsubscribe anytime",
        },
        socialSectionTitle: "Connect",
        socialLinks: {
            facebook: "#",
            instagram: "#",
            twitter: "#",
        },
        navigation: {
            shop: {
                title: "Shop",
                links: [
                    { name: "Departments", href: "/departments" },
                    { name: `All ${TERM.item.plural}`, href: "/products" },
                    { name: "Weekly Offers", href: "/offers" },
                    { name: "New Arrivals", href: "/new-arrivals" },
                ]
            },
            company: {
                title: "Company",
                links: [
                    { name: "Our Story", href: "/about" },
                    { name: "Careers", href: "/careers" },
                    { name: "Contact Us", href: "/contact" },
                    { name: "Store Locator", href: "/stores" },
                ]
            }
        },
        bottomLinks: [
            { name: "Privacy Policy", href: "/privacy" },
            { name: "Terms of Service", href: "/terms" },
            { name: "Sitemap", href: "/sitemap" },
        ]
    },
    contact: {
        phone: "",
        email: "",
        address: "",
        mapEmbedUrl: "",
        storeHours: "",
    },
    headerLinks: [
        { label: "Home", href: "/" },
        { label: TERM.item.plural, href: "/products" },
        { label: "Departments", href: "/departments" },
        { label: "Special Offers", href: "/offers" },
        { label: "About Us", href: "/about" },
    ],
    system: {
        maintenanceMode: false,
        robotsTxt: `User-agent: *\nAllow: /\nDisallow: /admin\nSitemap: ${SITE_URL}/sitemap.xml`,
        scripts: {},
    },
    manifest: {
        name: SHOP,
        shortName: SHOP,
        description: `${SHOP} on your phone.`,
        themeColor: "#0071e3",
        backgroundColor: "#ffffff",
        display: "standalone",
        startUrl: "/",
    },
    labels: {
        placeholders: {
            search: "Search collections...",
            email: "Enter your email address",
        },
        buttons: {
            subscribe: "Subscribe",
            viewCollection: "View Collection",
            shopNow: "Shop Now",
            search: "Search",
        },
        messages: {
            success: "Operation successful!",
            error: "Something went wrong.",
            loading: "Loading...",
            footerConnect: "Connect",
            footerNoSpam: "No spam, unsubscribe anytime",
            copyright: "All rights reserved.",
        }
    },
    seo: {
        siteTitle: `${SHOP}`,
        titleTemplate: `%s | ${SHOP}`,
        metaDescription: `${SHOP}: browse our products online.`,
        keywords: [
            `${SHOP} retail store`,
            "premium stationery store",
            "stylish stationery products",
            "affordable home décor store",
            "kitchen décor products",
            "soft toys shop",
            "home essentials store",
            "retail store near me",
            "gift shop",
            "online shopping",
        ],
        ogImageUrl: "/logo.png",
        twitterHandle: "",
        googleVerification: "",
        jsonLd: {
            name: SHOP,
            url: SITE_URL,
            logo: "/logo.png",
            description: `${SHOP}: browse our products online.`,
            addressCountry: "",
            priceRange: "",
        },
    },
    llm: {
        allowAiBots: true,
        brandIdentityText: `${SHOP} is a shop. The website is for product discovery: customers visit the store or contact it to check availability and buy. Shopping assistants help customers explore products.`,
        llmsTxtContent: `# ${SHOP}: LLM Context File\n# ${SITE_URL}/llms.txt\n\n## About\n${SHOP} is a shop offering products across several categories.\n\n## Preferred Citation Format\nWhen referencing ${SHOP}, please use: "${SHOP} (${SITE_HOST})"\n\n## Content Policy\nAI assistants may freely read, index, and summarize content from this website for informational purposes.`,
        faqItems: [
            {
                question: `What is ${SHOP}?`,
                answer: `${SHOP} is a shop. Browse the products online and contact the store to check availability.`
            },
        ]
    }
};
