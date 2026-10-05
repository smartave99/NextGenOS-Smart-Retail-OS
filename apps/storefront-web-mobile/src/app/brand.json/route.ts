import { getSiteConfig } from "@/app/actions/site-config";
import { NextResponse } from "next/server";
import { SITE_URL } from "@/lib/site-url";
import { SHOP_NAME } from "@/lib/shop-name";

export const dynamic = "force-dynamic";

export async function GET() {
    try {
        const config = await getSiteConfig();
        const { seo, branding, contact, llm } = config;

        // Construct a highly detailed Knowledge Graph entity for the brand
        const entity = {
            "@context": "https://schema.org",
            "@type": "Organization",
            "@id": `${SITE_URL}/#organization`,
            "name": branding.siteName || SHOP_NAME,
            "url": SITE_URL,
            "logo": {
                "@type": "ImageObject",
                "url": `${SITE_URL}${branding.logoUrl || "/logo.png"}`,
            },
            "description": llm?.brandIdentityText || seo.metaDescription,
            "slogan": branding.tagline,
            "address": {
                "@type": "PostalAddress",
                "streetAddress": contact.address,
                "addressCountry": seo.jsonLd.addressCountry || "IN"
            },
            "contactPoint": [
                {
                    "@type": "ContactPoint",
                    "telephone": contact.phone,
                    "contactType": "customer service",
                    "email": contact.email,
                    "availableLanguage": ["English", "Hindi"]
                }
            ],
            "sameAs": [
                contact.facebookUrl,
                contact.instagramUrl,
                contact.twitterUrl
            ].filter(Boolean),
            "knowsAbout": ["Departmental Store", "Groceries", "Fashion", "Electronics", "Home Decor", "AI Shopping Assistant"]
        };

        return NextResponse.json(entity, {
            status: 200,
            headers: {
                "Content-Type": "application/ld+json; charset=utf-8",
                "Cache-Control": "public, max-age=3600, s-maxage=3600, stale-while-revalidate=86400",
                "Access-Control-Allow-Origin": "*", // Allow AI services to fetch it cross-origin
            },
        });
    } catch (error) {
        console.error("Failed to generate brand.json", error);
        return new NextResponse("{}", { status: 500 });
    }
}
