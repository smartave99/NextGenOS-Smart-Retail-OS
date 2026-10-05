"use client";

import { MapPin, MessageSquare } from "lucide-react";
import { useSiteConfig } from "@/context/SiteConfigContext";
import { SITE_URL } from "@/lib/site-url";
import { SHOP_NAME } from "@/lib/shop-name";

interface WhatsAppOrderButtonProps {
    productName: string;
    productPrice: number;
    productImage?: string | null;
    productId: string;
}

export default function WhatsAppOrderButton({
    productName,
    productPrice,
    productId,
}: WhatsAppOrderButtonProps) {
    const { config } = useSiteConfig();
    const whatsappUrl = config.contact.whatsappUrl || config.branding.whatsappUrl;

    const handleOrderClick = () => {
        if (!whatsappUrl) {
            window.alert("WhatsApp is not configured yet. Please contact the store directly.");
            return;
        }

        const phone = whatsappUrl.replace(/\D/g, "");
        const productUrl = `${SITE_URL}/products/${productId}`;
        const message = `*In-store availability enquiry - ${SHOP_NAME}*

*${productName}*
Price: ₹${productPrice.toLocaleString("en-IN")}

${productUrl}

I plan to visit the store. Is this item currently available in store?

I understand this message is not an order or reservation.`;

        window.open(
            `https://wa.me/${phone}?text=${encodeURIComponent(message)}`,
            "_blank",
            "noopener,noreferrer",
        );
    };

    return (
        <div className="space-y-3">
            <button
                type="button"
                onClick={handleOrderClick}
                className="flex min-h-12 w-full items-center justify-center gap-3 rounded-xl bg-[#128C4A] px-6 py-4 font-bold text-white shadow-lg shadow-emerald-900/15 transition-[background-color,transform,box-shadow] hover:bg-[#0f7a40] hover:shadow-xl focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-emerald-600 focus-visible:ring-offset-2 active:scale-[0.99]"
            >
                <MessageSquare className="h-5 w-5" aria-hidden="true" />
                Check in-store availability
            </button>
            <p className="flex items-start justify-center gap-1.5 text-center text-xs leading-5 text-slate-500">
                <MapPin className="mt-0.5 h-3.5 w-3.5 shrink-0" aria-hidden="true" />
                WhatsApp is for enquiries only. Products must be purchased at the store.
            </p>
        </div>
    );
}
