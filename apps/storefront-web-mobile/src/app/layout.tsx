import type { Metadata } from "next";
import { Inter, Outfit } from "next/font/google";
import ClientLayout from "@/components/ClientLayout";
import { SpeedInsights } from "@vercel/speed-insights/next";
import "./globals.css";
import { getSiteConfig } from "@/app/actions/site-config";
import { DEFAULT_SITE_CONFIG } from "@/types/site-config";
import { Suspense } from "react";
import Script from "next/script";

// The licence brand and the licence gate depend on the licence at run time, not on the build: every page is rendered per request
// (the shop's own data stays cached for an hour by getSiteConfig).
export const dynamic = "force-dynamic";

const inter = Inter({
  variable: "--font-inter",
  subsets: ["latin"],
  display: "swap",
});

// Using Outfit as it's geometric and matches modern tech/retail logos better than Playfair
const outfit = Outfit({
  variable: "--font-outfit",
  subsets: ["latin"],
  display: "swap",
});

export async function generateMetadata(): Promise<Metadata> {
  const config = await getSiteConfig();

  return {
    metadataBase: new URL(config.seo.jsonLd.url || process.env.NEXT_PUBLIC_SITE_URL || 'http://localhost:3000'),
    title: {
      default: config.seo.siteTitle,
      template: config.seo.titleTemplate,
    },
    description: config.seo.metaDescription,
    keywords: config.seo.keywords,
    openGraph: {
      title: config.seo.siteTitle,
      description: config.seo.metaDescription,
      url: config.seo.jsonLd.url || undefined,
      siteName: config.branding.siteName,
      images: [
        {
          url: config.seo.ogImageUrl || "/logo.png",
          width: 1200,
          height: 630,
        },
      ],
      type: 'website',
    },
    twitter: {
      card: "summary_large_image",
      creator: config.seo.twitterHandle,
      site: config.seo.twitterHandle,
      images: [config.seo.ogImageUrl || "/logo.png"],
    },
    verification: {
      google: config.seo.googleVerification,
    },
    icons: {
      icon: config.branding.faviconUrl || "/favicon.ico",
    },
    robots: config.system.robotsTxt ? null : {
      index: true,
      follow: true
    },
    other: {
      ...(config.system.scripts.googleAnalyticsId ? {} : { "google-site-verification": config.seo.googleVerification })
    }
  };
}

// Optimized Layout that fetches config ONCE and injects into ClientLayout + scripts
async function ConfigLoader({ children }: { children: React.ReactNode }) {
  const config = await getSiteConfig();

  const organizationSchema = {
    "@context": "https://schema.org",
    "@type": "Organization",
    "name": config.seo.jsonLd.name,
    "url": config.seo.jsonLd.url,
    "logo": config.seo.jsonLd.logo,
    "description": config.seo.jsonLd.description,
    "contactPoint": {
      "@type": "ContactPoint",
      "telephone": config.contact.phone,
      "email": config.contact.email,
      "contactType": "customer service"
    },
    "sameAs": [
      config.contact.instagramUrl,
      config.contact.facebookUrl,
      config.contact.twitterUrl
    ].filter(Boolean)
  };

  const websiteSchema = {
    "@context": "https://schema.org",
    "@type": "WebSite",
    "name": config.seo.jsonLd.name,
    "url": config.seo.jsonLd.url,
    "potentialAction": {
      "@type": "SearchAction",
      "target": {
        "@type": "EntryPoint",
        "urlTemplate": `${config.seo.jsonLd.url}/products?q={search_term_string}`
      },
      "query-input": "required name=search_term_string"
    }
  };

  return (
    <>
      <script
        type="application/ld+json"
        dangerouslySetInnerHTML={{ __html: JSON.stringify(organizationSchema) }}
      />
      <script
        type="application/ld+json"
        dangerouslySetInnerHTML={{ __html: JSON.stringify(websiteSchema) }}
      />
      {config.system.scripts.customHeadScript && (
        <script
          dangerouslySetInnerHTML={{
            __html: config.system.scripts.customHeadScript.replace(/<script[^>]*>/i, "").replace(/<\/script>/i, ""),
          }}
        />
      )}
      {config.system.scripts.googleAnalyticsId && (
        <>
          <Script
            src={`https://www.googletagmanager.com/gtag/js?id=${config.system.scripts.googleAnalyticsId}`}
            strategy="afterInteractive"
          />
          <Script id="google-analytics" strategy="afterInteractive">
            {`
                  window.dataLayer = window.dataLayer || [];
                  function gtag(){dataLayer.push(arguments);}
                  gtag('js', new Date());
                  gtag('config', '${config.system.scripts.googleAnalyticsId}');
                  `}
          </Script>
        </>
      )}
      <ClientLayout initialConfig={config}>{children}</ClientLayout>
      {config.system.scripts.customBodyScript && (
        <div dangerouslySetInnerHTML={{ __html: config.system.scripts.customBodyScript }} />
      )}
    </>
  );
}

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body
        className={`${inter.variable} ${outfit.variable} antialiased bg-slate-50 text-slate-900 flex flex-col min-h-screen`}
      >
        <Suspense fallback={<ClientLayout initialConfig={DEFAULT_SITE_CONFIG}>{children}</ClientLayout>}>
          <ConfigLoader>{children}</ConfigLoader>
        </Suspense>

        <SpeedInsights />
      </body>
    </html>
  );
}

