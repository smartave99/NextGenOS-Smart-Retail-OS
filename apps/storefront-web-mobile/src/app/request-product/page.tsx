import type { Metadata } from "next";
import ProductRequestPageClient from "@/components/ProductRequestPageClient";
import { SHOP_NAME } from "@/lib/shop-name";

export const metadata: Metadata = {
    title: "Request a Product",
    description: `Suggest a product for the ${SHOP_NAME} store to consider stocking.`,
    alternates: {
        canonical: "/request-product",
    },
};

interface RequestProductPageProps {
    searchParams: Promise<{ product?: string }>;
}

export default async function RequestProductPage({
    searchParams,
}: RequestProductPageProps) {
    const { product } = await searchParams;
    const initialQuery = typeof product === "string" ? product.slice(0, 200) : "";

    return <ProductRequestPageClient initialQuery={initialQuery} />;
}
