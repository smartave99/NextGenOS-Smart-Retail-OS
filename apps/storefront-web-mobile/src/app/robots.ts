import { MetadataRoute } from "next";
import { getSiteConfig } from "@/app/actions/site-config";
import { SITE_URL } from "@/lib/site-url";

// The shop's own web address is read when the website starts, so this is made when it is asked for, never when the program was built.
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
