import { NextResponse } from "next/server";
import { getProducts, getCategories, getDepartments } from "@/app/actions";

export const revalidate = 3600; // Cache sitemap for 1 hour

export async function GET() {
    const baseUrl = "https://smartavenue99.com";

    try {
        const [products, categories, departments] = await Promise.all([
            getProducts(undefined, true, 1500), // Get all active products (up to 1500)
            getCategories(),
            getDepartments()
        ]);

        let xml = `<?xml version="1.0" encoding="UTF-8"?>
<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9"
        xmlns:image="http://www.google.com/schemas/sitemap-image/1.1">`;

        // 1. Static Pages
        const staticPages = ["", "/about", "/departments", "/products", "/offers", "/request-product", "/contact"];
        for (const page of staticPages) {
            xml += `
  <url>
    <loc>${baseUrl}${page}</loc>
    <changefreq>weekly</changefreq>
    <priority>${page === "" ? "1.0" : "0.8"}</priority>
  </url>`;
        }

        // 2. Product Pages with Google Image extensions (for Google Lens and Google Images discovery)
        for (const prod of products) {
            const lastMod = prod.updatedAt || prod.createdAt || new Date();
            const lastModIso = typeof lastMod === "string" ? lastMod : lastMod.toISOString();
            
            xml += `
  <url>
    <loc>${baseUrl}/products/${prod.id}</loc>
    <lastmod>${lastModIso}</lastmod>
    <changefreq>weekly</changefreq>
    <priority>0.6</priority>`;

            // Add images for Google Image/Google Lens indexing
            const productImages = prod.images && prod.images.length > 0 
                ? prod.images 
                : (prod.imageUrl ? [prod.imageUrl] : []);

            for (const imgUrl of productImages) {
                if (!imgUrl) continue;
                // Escape XML characters in image URL and product name
                const escapedImgUrl = escapeXml(imgUrl);
                const escapedName = escapeXml(prod.name);
                xml += `
    <image:image>
      <image:loc>${escapedImgUrl}</image:loc>
      <image:title>${escapedName}</image:title>
    </image:image>`;
            }

            xml += `
  </url>`;
        }

        // 3. Category Pages
        for (const cat of categories) {
            xml += `
  <url>
    <loc>${baseUrl}/products?category=${encodeURIComponent(cat.name)}</loc>
    <changefreq>weekly</changefreq>
    <priority>0.7</priority>
  </url>`;
        }

        // 4. Department Pages
        for (const dep of departments) {
            xml += `
  <url>
    <loc>${baseUrl}/departments#${dep.id}</loc>
    <changefreq>monthly</changefreq>
    <priority>0.7</priority>
  </url>`;
        }

        xml += `
</urlset>`;

        return new NextResponse(xml, {
            headers: {
                "Content-Type": "application/xml",
                "Cache-Control": "public, s-maxage=3600, stale-while-revalidate=600"
            }
        });
    } catch (error) {
        console.error("Sitemap XML generation error:", error);
        return new NextResponse(
            `<?xml version="1.0" encoding="UTF-8"?>
<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">
  <url>
    <loc>${baseUrl}</loc>
  </url>
</urlset>`,
            {
                headers: { "Content-Type": "application/xml" }
            }
        );
    }
}

function escapeXml(unsafe: string): string {
    return unsafe.replace(/[<>&'"]/g, (c) => {
        switch (c) {
            case "<": return "&lt;";
            case ">": return "&gt;";
            case "&": return "&amp;";
            case "'": return "&apos;";
            case "\"": return "&quot;";
            default: return c;
        }
    });
}
