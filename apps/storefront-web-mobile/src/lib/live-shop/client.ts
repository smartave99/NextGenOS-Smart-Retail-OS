import { createClient, type SupabaseClient } from "@supabase/supabase-js";
import type { LiveShopConfig } from "./config";

let client: SupabaseClient | null = null;

/** One Supabase client for the Live shop section. The owner stays signed in on this device until signing out. */
export function liveShopClient(config: Extract<LiveShopConfig, { ok: true }>): SupabaseClient {
    client ??= createClient(config.url, config.key, {
        auth: { persistSession: true, autoRefreshToken: true, detectSessionInUrl: true, storageKey: "smart-avenue-live-shop" },
    });
    return client;
}
