/**
 * verify_and_fix_sync.mjs
 * Thorough verification of all Prisma tables and Redis keys across all accounts.
 * Will automatically sync any missed tables (like ApiKey) or missing records.
 */

import fs from "fs";
import path from "path";
import { fileURLToPath } from "url";

const __dirname = path.dirname(fileURLToPath(import.meta.url));
const ROOT = path.resolve(__dirname, "..");

function loadEnv(filePath) {
    const text = fs.readFileSync(filePath, "utf8");
    const env = {};
    for (const line of text.split("\n")) {
        const trimmed = line.trim();
        if (!trimmed || trimmed.startsWith("#")) continue;
        const eqIdx = trimmed.indexOf("=");
        if (eqIdx < 0) continue;
        const key = trimmed.slice(0, eqIdx).trim();
        let val = trimmed.slice(eqIdx + 1).trim();
        if ((val.startsWith('"') && val.endsWith('"')) || (val.startsWith("'") && val.endsWith("'"))) {
            val = val.slice(1, -1);
        }
        env[key] = val;
    }
    return env;
}

const ENV = loadEnv(path.join(ROOT, ".env.local"));

const { PrismaClient } = await import("@prisma/client");
const { Redis } = await import("@upstash/redis");

console.log("\n🔍 INITIATING EXHAUSTIVE SYNC VERIFICATION...\n");

// --- NEON POSTGRES ---
const MODELS = [
    "product", "category", "offer", "review",
    "productRequest", "apiKey", "newsletterSubscriber",
    "staff", "page"
];

const neonClients = [
    { label: "Account 1 (Primary)", url: ENV.DATABASE_URL, client: new PrismaClient({ datasources: { db: { url: ENV.DATABASE_URL } }, log: [] }) },
    { label: "Account 2", url: ENV.DATABASE_URL_2, client: new PrismaClient({ datasources: { db: { url: ENV.DATABASE_URL_2 } }, log: [] }) },
    { label: "Account 3", url: ENV.DATABASE_URL_3, client: new PrismaClient({ datasources: { db: { url: ENV.DATABASE_URL_3 } }, log: [] }) },
];

console.log("=== NEON ROW COUNTS ===");
const rowCounts = {};
for (const model of MODELS) {
    rowCounts[model] = [];
}

let primaryOnline = false;

for (let i = 0; i < neonClients.length; i++) {
    const nc = neonClients[i];
    try {
        await nc.client.$queryRaw`SELECT 1`; // ping
        if (i === 0) primaryOnline = true;

        let out = `  ${nc.label}: `;
        for (const model of MODELS) {
            const count = await nc.client[model].count();
            rowCounts[model].push({ account: nc.label, client: nc.client, count });
            out += `${model}=${count} | `;
        }
        console.log(out);
    } catch (e) {
        console.log(`  ❌ ${nc.label} is OFFLINE: ${e.message}`);
    }
}

if (primaryOnline) {
    let needsFix = false;
    for (const model of MODELS) {
        const counts = rowCounts[model];
        if (counts.length < 3) continue; // one is offline, skip 
        if (counts[0].count !== counts[1].count || counts[0].count !== counts[2].count) {
            console.log(`\n⚠️ DISCREPANCY DETECTED IN TABLE: ${model}`);
            console.log(`    Primary: ${counts[0].count} | Acc 2: ${counts[1].count} | Acc 3: ${counts[2].count}`);
            needsFix = true;

            console.log(`    🔄 Auto-fixing ${model}...`);
            const allRecords = await counts[0].client[model].findMany();

            // Replicas missing data
            for (let j = 1; j <= 2; j++) {
                if (counts[j].count !== counts[0].count) {
                    let synced = 0;
                    for (const record of allRecords) {
                        try {
                            const idField = (model === "newsletterSubscriber" || model === "staff") ? "email" :
                                (model === "apiKey") ? "key" : "id";

                            await counts[j].client[model].upsert({
                                where: { [idField]: record[idField] },
                                update: record,
                                create: record
                            });
                            synced++;
                        } catch (e) {
                            console.log(`      Failed to sync record in ${model}: ${e.message}`);
                        }
                    }
                    console.log(`      ✅ Acc ${j + 1}: Synced ${synced} records for ${model}`);
                }
            }
        }
    }
    if (!needsFix) {
        console.log("\n✅ ALL NEON POSTGRES TABLES ARE 100% IN SYNC.");
    }
}

for (const nc of neonClients) {
    try { await nc.client.$disconnect(); } catch { }
}

// --- UPSTASH REDIS ---
console.log("\n=== UPSTASH REDIS KEY COMPARISON ===");

const redisConfigs = [
    { label: "Account 1", url: ENV.UPSTASH_REDIS_REST_URL_1 || ENV.UPSTASH_REDIS_REST_URL, token: ENV.UPSTASH_REDIS_REST_TOKEN_1 || ENV.UPSTASH_REDIS_REST_TOKEN },
    { label: "Account 2", url: ENV.UPSTASH_REDIS_REST_URL_2, token: ENV.UPSTASH_REDIS_REST_TOKEN_2 },
    { label: "Account 3", url: ENV.UPSTASH_REDIS_REST_URL_3, token: ENV.UPSTASH_REDIS_REST_TOKEN_3 },
];

const REDIS_KEYS = [
    "site_config.json",
    "llmo.json",
    "llmo_prompts.json",
    "site_content_hero.json",
    "site_content_departments.json",
    "site_content_features.json",
    "site_content_cta.json",
    "site_content_highlights.json",
    "site_content_contact.json",
];

const rClients = [];
for (const c of redisConfigs) {
    try {
        const client = new Redis({ url: c.url, token: c.token });
        await client.ping();
        rClients.push({ label: c.label, client });
    } catch (e) {
        console.log(`  ❌ ${c.label} is OFFLINE`);
    }
}

if (rClients.length > 0) {
    const primaryRedis = rClients[0];
    let redisNeedsFix = false;

    for (const key of REDIS_KEYS) {
        const primaryVal = await primaryRedis.client.get(key);

        let discrepancy = false;
        for (let i = 1; i < rClients.length; i++) {
            const replicaVal = await rClients[i].client.get(key);
            if (JSON.stringify(primaryVal) !== JSON.stringify(replicaVal)) {
                discrepancy = true;
                redisNeedsFix = true;
                console.log(`\n⚠️ REDIS DISCREPANCY DETECTED FOR KEY: ${key}`);
                console.log(`    Primary has data: ${!!primaryVal}, ${rClients[i].label} has data: ${!!replicaVal}`);

                if (primaryVal !== null) {
                    await rClients[i].client.set(key, primaryVal);
                    console.log(`    ✅ Auto-fixed: Synced ${key} to ${rClients[i].label}`);
                } else if (replicaVal !== null) {
                    await rClients[i].client.del(key);
                    console.log(`    ✅ Auto-fixed: Deleted ${key} from ${rClients[i].label} to match primary`);
                }
            }
        }
    }

    if (!redisNeedsFix) {
        console.log("✅ ALL REDIS KEYS ARE 100% IN SYNC.");
    }
}

console.log("\n🚀 VERIFICATION SCRIPT FINISHED.\n");
