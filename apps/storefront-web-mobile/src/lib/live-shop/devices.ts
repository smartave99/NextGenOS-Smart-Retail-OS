import type { SupabaseClient } from "@supabase/supabase-js";

/**
 * The shop PCs, oldest first. Which one is the main PC came with Smart Retail POS 2.18.0's script (`is_main`); a project with
 * an older script has no such column and answers that it is not there, so the list is asked for again with what that script
 * has, and no PC is marked.
 */
export async function selectDevices(db: SupabaseClient, shopId: string) {
    const wanted = await db.from("shop_devices").select("id, label, connected_at, last_seen_at, is_main").eq("shop_id", shopId).order("connected_at");
    if (!wanted.error || wanted.error.code !== "42703") return wanted;
    return db.from("shop_devices").select("id, label, connected_at, last_seen_at").eq("shop_id", shopId).order("connected_at");
}
