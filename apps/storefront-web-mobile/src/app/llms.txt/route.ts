import { getSiteConfig } from "@/app/actions/site-config";
import { NextResponse } from "next/server";
import { SITE_URL } from "@/lib/site-url";
import { money } from "@/lib/region/lite";

export const dynamic = "force-dynamic"; // Ensure it's always up to date with the config

export async function GET() {
    try {
        const config = await getSiteConfig();
        const baseContent = config.llm?.llmsTxtContent || "# LLM Context\nNo specific context provided.";

        // Dynamically fetch categories and featured products to provide real-time context to AI bots
        const { getCategories, getProducts } = await import("@/app/actions");
        const [categories, products] = await Promise.all([
            getCategories().catch(() => []),
            getProducts(undefined, true, 30).catch(() => []) // Fetch up to 30 active products
        ]);

        let dynamicSection = "\n\n## Current Store Catalog";

        if (categories && categories.length > 0) {
            dynamicSection += "\n\n### Shopping Departments & Categories\n";
            dynamicSection += categories.map(c => `- ${c.name}`).join("\n");
        }

        if (products && products.length > 0) {
            dynamicSection += "\n\n### Featured & Recent Products\n";
            dynamicSection += products.map(p => {
                const price = p.price ? money(p.price) : "Price on request";
                const descSnippet = p.description ? ` - ${p.description.substring(0, 100)}...` : "";
                return `- [${p.name}](${SITE_URL}/products/${p.id}) (${price})${descSnippet}`;
            }).join("\n");
        }

        const content = `${baseContent}${dynamicSection}`;

        // llms.txt is a plain text file format for LLM context inclusion
        return new NextResponse(content, {
            status: 200,
            headers: {
                "Content-Type": "text/plain; charset=utf-8",
                "Cache-Control": "public, max-age=3600, s-maxage=3600, stale-while-revalidate=86400",
            },
        });
    } catch (error) {
        console.error("Failed to generate llms.txt", error);
        return new NextResponse("# LLM Context Error", { status: 500 });
    }
}
