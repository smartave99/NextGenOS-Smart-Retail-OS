/**
 * Public AI Settings API Endpoint
 * 
 * GET /api/assistant/settings
 * 
 * Returns public-facing AI settings for the frontend chat widget.
 */

import { NextResponse } from "next/server";
import { getPublicAISettings } from "@/app/actions/ai-settings-actions";

export async function GET() {
    try {
        const settings = await getPublicAISettings();
        return NextResponse.json(settings);
    } catch (error) {
        console.error("[API /assistant/settings] Error:", error);
        return NextResponse.json(
            {
                enabled: true,
                personaName: "Genie",
                greeting: "Hey there! ✨ I'm Genie, your personal shopping assistant at Smart Avenue 99! Whether you need help finding the perfect product, a gift for someone special, or just want to explore what's trending — I've got you covered. What are you looking for today? 🛍️",
                enableVoiceInput: false,
                enableProductRequests: true,
            },
            { status: 200 }
        );
    }
}
