import type { Metadata } from "next";
import LiveShop from "@/components/admin/live/LiveShop";

export const metadata: Metadata = {
    title: "Live shop",
    robots: { index: false, follow: false },
};

// The shop's figures from the POS, live, for the owner: signed in with the owner's Supabase account.
export default function LiveShopPage() {
    return <LiveShop />;
}
