
import { MetadataRoute } from 'next';
import { getSiteConfig } from "@/app/actions/site-config";
import { SHOP_NAME } from "@/lib/shop-name";

export const dynamic = "force-dynamic";

export default async function manifest(): Promise<MetadataRoute.Manifest> {
    const config = await getSiteConfig();
    const manifest = config.manifest;

    return {
        name: manifest.name || SHOP_NAME,
        short_name: manifest.shortName || SHOP_NAME,
        description: manifest.description || `${SHOP_NAME} is a one-stop departmental store.`,
        start_url: manifest.startUrl || '/',
        display: manifest.display || 'standalone',
        background_color: manifest.backgroundColor || '#ffffff',
        theme_color: manifest.themeColor || '#0284c7',
        icons: [
            {
                src: config.branding.logoUrl || '/logo.png',
                sizes: '192x192',
                type: 'image/png',
                purpose: 'any',
            },
            {
                src: config.branding.logoUrl || '/logo.png',
                sizes: '512x512',
                type: 'image/png',
                purpose: 'any',
            },
        ],
    };
}
