"use client";

import { Sparkles } from "lucide-react";

export default function ChatTriggerButton() {
    return (
        <button
            type="button"
            onClick={() => window.dispatchEvent(new Event("open-assistant-chat"))}
            className="group inline-flex min-h-12 items-center justify-center gap-2 rounded-xl border border-white/20 bg-white/10 px-7 py-3.5 font-bold text-white backdrop-blur-md transition-colors hover:bg-white/20 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-white"
        >
            Ask Smart Shopper
            <Sparkles className="w-5 h-5 text-brand-lime group-hover:scale-110 transition-transform" />
        </button>
    );
}
