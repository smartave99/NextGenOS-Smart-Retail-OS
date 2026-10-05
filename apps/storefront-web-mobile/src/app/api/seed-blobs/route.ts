import { NextResponse } from "next/server";
import { updateBlobJson } from "@/app/actions/blob-json";
import { DEFAULT_SITE_CONFIG } from "@/types/site-config";
import { DEFAULT_PROMPTS } from "@/lib/prompt-defaults";
import { getAdminIdentityFromRequest } from "@/lib/auth-server";

const DEFAULT_AI_SETTINGS = {
    enabled: true,
    personaName: "Genie",
    greeting: "Hi, I'm Genie, your personal Shopping Master! 🧞‍♂️ How can I help you today?",
    systemPrompt: "You are Genie...",
    temperature: 0.7,
    maxTokens: 2048,
    providerPriority: "auto",
    maxRecommendations: 5,
    enableVoiceInput: false,
    enableProductRequests: true,
};

export async function GET(req: Request) {
    try {
        if (!await getAdminIdentityFromRequest(req)) {
            return NextResponse.json({ error: "Unauthorized" }, { status: 401 });
        }

        // 1. Seed site config
        await updateBlobJson("site_config.json", DEFAULT_SITE_CONFIG);
        console.log("Seeded site config");

        // 2. Seed AI settings
        await updateBlobJson("llmo.json", DEFAULT_AI_SETTINGS);
        console.log("Seeded LLMO settings");

        // 3. Seed AI Prompts
        const prompts: Record<string, unknown> = {};
        for (const [id, data] of Object.entries(DEFAULT_PROMPTS)) {
            prompts[id] = { ...data, id };
        }
        await updateBlobJson("llmo_prompts.json", prompts);
        console.log("Seeded LLMO prompts");

        // 4. Seed empty Departments
        await updateBlobJson("site_content_departments.json", { items: [] });
        console.log("Seeded departments");

        return NextResponse.json({ success: true, message: "Blobs seeded successfully" });
    } catch (error) {
        console.error("Seed error:", error);
        return NextResponse.json({ error: String(error) }, { status: 500 });
    }
}
