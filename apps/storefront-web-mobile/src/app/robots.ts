import { MetadataRoute } from "next";
import { getSiteConfig } from "@/app/actions/site-config";
import { SITE_URL } from "@/lib/site-url";

// The website is built once for every customer: its address comes from the customer's settings when it runs, never from the build.
export const dynamic = "force-dynamic";

export default async function robots(): Promise<MetadataRoute.Robots> {
    const config = await getSiteConfig();

    return {
        rules: {
            userAgent: "*",
            allow: config.system.maintenanceMode ? "/admin" : "/",
            disallow: config.system.maintenanceMode ? "/" : "/admin/",
        },
        sitemap: `${SITE_URL}/sitemap.xml`,
    };
}
