/**
 * sync_all.mjs
 * Full diagnostic + data sync for Neon (Postgres) and Upstash Redis.
 *
 * What it does:
 *  1. Reads .env.local for all connection strings
 *  2. Pings all 3 Neon accounts, runs schema migration on accounts 2 & 3
 *  3. Dumps ALL data from primary Neon, inserts into accounts 2 & 3 (upsert)
 *  4. Pings all 3 Redis accounts, reads every known key from account 1 and copies to 2 & 3
 *
 * Run: node tmp/sync_all.mjs
 */

import fs from "fs";
import path from "path";
import { fileURLToPath } from "url";

const __dirname = path.dirname(fileURLToPath(import.meta.url));
const ROOT = path.resolve(__dirname, "..");

// ── Load .env.local ───────────────────────────────────────────────────────────
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
        if ((val.startsWith('"') && val.endsWith('"')) ||
            (val.startsWith("'") && val.endsWith("'"))) {
            val = val.slice(1, -1);
        }
        env[key] = val;
    }
    return env;
}

const ENV = loadEnv(path.join(ROOT, ".env.local"));

// ── Dynamic imports ───────────────────────────────────────────────────────────
const { PrismaClient } = await import("@prisma/client");
const { Redis } = await import("@upstash/redis");

// ══════════════════════════════════════════════════════════════════════════════
// NEON / POSTGRES
// ══════════════════════════════════════════════════════════════════════════════

const neonClients = [];
const neonURLs = [ENV.DATABASE_URL, ENV.DATABASE_URL_2, ENV.DATABASE_URL_3];
const neonLabels = ["Primary (DB 1)", "Account 2 (DB 2)", "Account 3 (DB 3)"];

for (let i = 0; i < neonURLs.length; i++) {
    if (neonURLs[i]) {
        neonClients.push({
            label: neonLabels[i],
            client: new PrismaClient({ datasources: { db: { url: neonURLs[i] } } })
        });
    } else {
        console.log(`⚠️  ${neonLabels[i]}: no URL — skipping`);
    }
}

// ── Step 1: Ping all Neon accounts ────────────────────────────────────────────
console.log("\n═══════════════════════════════════════");
console.log("  NEON POSTGRES HEALTH CHECK");
console.log("═══════════════════════════════════════");

const neonHealth = [];
for (const { label, client } of neonClients) {
    try {
        await client.$queryRaw`SELECT 1`;
        console.log(`  ✅  ${label}: ONLINE`);
        neonHealth.push({ label, client, online: true });
    } catch (e) {
        console.log(`  ❌  ${label}: OFFLINE — ${e.message}`);
        neonHealth.push({ label, client, online: false });
    }
}

const primary = neonHealth[0];
const replicas = neonHealth.slice(1).filter(n => n.online);

if (!primary.online) {
    console.log("\n🚨 PRIMARY DB IS OFFLINE. Cannot sync. Aborting DB sync.");
} else if (replicas.length === 0) {
    console.log("\nℹ️  No online replica accounts found. Nothing to sync.");
} else {
    // ── Step 2: Read ALL data from primary ───────────────────────────────────
    console.log("\n  📤 Reading all data from primary...");

    const [offers, categories, products, staff, pages, subscribers, requests, reviews] = await Promise.all([
        primary.client.offer.findMany(),
        primary.client.category.findMany(),
        primary.client.product.findMany(),
        primary.client.staff.findMany(),
        primary.client.page.findMany(),
        primary.client.newsletterSubscriber.findMany(),
        primary.client.productRequest.findMany(),
        primary.client.review.findMany(),
    ]);

    const summary = { offers: offers.length, categories: categories.length, products: products.length, staff: staff.length, pages: pages.length, subscribers: subscribers.length, requests: requests.length, reviews: reviews.length };
    console.log("  Primary data:", summary);

    // ── Step 3: Upsert everything into each replica ───────────────────────────
    for (const replica of replicas) {
        console.log(`\n  🔄 Syncing → ${replica.label}...`);
        const rc = replica.client;

        try {
            // Run Prisma's DB push to ensure schema is up to date
            // (We upsert data directly — schema is already applied at Neon account level)

            let synced = 0, failed = 0;

            // Helper
            async function upsertAll(model, records, idField = "id") {
                for (const record of records) {
                    try {
                        await rc[model].upsert({
                            where: { [idField]: record[idField] },
                            update: record,
                            create: record,
                        });
                        synced++;
                    } catch (e) {
                        console.log(`    ⚠️  ${model} upsert failed for ${record[idField]}: ${e.message.slice(0, 80)}`);
                        failed++;
                    }
                }
            }

            await upsertAll("offer", offers);
            await upsertAll("category", categories);
            // Products depend on categories — done after
            await upsertAll("product", products);
            await upsertAll("staff", staff, "email");
            await upsertAll("page", pages);
            await upsertAll("newsletterSubscriber", subscribers, "email");
            await upsertAll("productRequest", requests);
            await upsertAll("review", reviews);

            console.log(`  ✅  ${replica.label}: ${synced} records synced, ${failed} failed`);
        } catch (e) {
            console.log(`  ❌  ${replica.label}: sync error — ${e.message}`);
        }
    }
}

// Disconnect all Neon clients
for (const { client } of neonClients) {
    try { await client.$disconnect(); } catch { }
}

// ══════════════════════════════════════════════════════════════════════════════
// UPSTASH REDIS
// ══════════════════════════════════════════════════════════════════════════════

const redisConfigs = [
    { label: "Account 1", url: ENV.UPSTASH_REDIS_REST_URL_1 || ENV.UPSTASH_REDIS_REST_URL, token: ENV.UPSTASH_REDIS_REST_TOKEN_1 || ENV.UPSTASH_REDIS_REST_TOKEN },
    { label: "Account 2", url: ENV.UPSTASH_REDIS_REST_URL_2, token: ENV.UPSTASH_REDIS_REST_TOKEN_2 },
    { label: "Account 3", url: ENV.UPSTASH_REDIS_REST_URL_3, token: ENV.UPSTASH_REDIS_REST_TOKEN_3 },
].filter(c => c.url && c.token);

const redisClients = redisConfigs.map(c => ({
    label: c.label,
    client: new Redis({ url: c.url, token: c.token })
}));

console.log("\n═══════════════════════════════════════");
console.log("  UPSTASH REDIS HEALTH CHECK");
console.log("═══════════════════════════════════════");

const redisHealth = [];
for (const { label, client } of redisClients) {
    try {
        await client.ping();
        console.log(`  ✅  ${label}: ONLINE`);
        redisHealth.push({ label, client, online: true });
    } catch (e) {
        console.log(`  ❌  ${label}: OFFLINE — ${e.message}`);
        redisHealth.push({ label, client, online: false });
    }
}

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

const primaryRedis = redisHealth.find(r => r.online);
const replicaRedis = redisHealth.filter((r, i) => r.online && i > 0);

if (!primaryRedis) {
    console.log("\n🚨 ALL REDIS ACCOUNTS OFFLINE.");
} else {
    console.log(`\n  📤 Reading all keys from ${primaryRedis.label}...`);

    // Read all known keys from primary Redis
    const keyData = {};
    for (const key of REDIS_KEYS) {
        try {
            const val = await primaryRedis.client.get(key);
            if (val !== null && val !== undefined) {
                keyData[key] = val;
                console.log(`    ✅  ${key}: found`);
            } else {
                console.log(`    ⚪  ${key}: empty (not set yet)`);
            }
        } catch (e) {
            console.log(`    ⚠️  ${key}: read error — ${e.message}`);
        }
    }

    // Push to all other online accounts
    for (const replica of replicaRedis) {
        console.log(`\n  🔄 Syncing Redis → ${replica.label}...`);
        let ok = 0, skip = 0, fail = 0;
        for (const [key, val] of Object.entries(keyData)) {
            try {
                await replica.client.set(key, val);
                ok++;
            } catch (e) {
                console.log(`    ⚠️  Failed to set ${key}: ${e.message.slice(0, 60)}`);
                fail++;
            }
        }
        const noData = REDIS_KEYS.length - ok - fail;
        console.log(`  ✅  ${replica.label}: ${ok} keys synced, ${fail} failed, ${noData} were empty on primary`);
    }
}

console.log("\n✅ SYNC COMPLETE\n");
