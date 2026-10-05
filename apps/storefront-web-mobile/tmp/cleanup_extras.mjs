/**
 * cleanup_extras.mjs
 * Finds records on Account 2 and Account 3 that do not exist on Primary and deletes them,
 * ensuring the databases match exactly in terms of record counts and content.
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

console.log("\n🧹 INITIATING CLEANUP OF EXTRA RECORDS ON REPLICAS...\n");

const MODELS = [
    "review", "productRequest", "product", "category", "offer",
    "apiKey", "newsletterSubscriber", "staff", "page"
];

const neonClients = [
    { label: "Account 1 (Primary)", url: ENV.DATABASE_URL, client: new PrismaClient({ datasources: { db: { url: ENV.DATABASE_URL } }, log: [] }) },
    { label: "Account 2", url: ENV.DATABASE_URL_2, client: new PrismaClient({ datasources: { db: { url: ENV.DATABASE_URL_2 } }, log: [] }) },
    { label: "Account 3", url: ENV.DATABASE_URL_3, client: new PrismaClient({ datasources: { db: { url: ENV.DATABASE_URL_3 } }, log: [] }) },
];

async function run() {
    let primaryOnline = false;
    try {
        await neonClients[0].client.$queryRaw`SELECT 1`;
        primaryOnline = true;
    } catch (e) {
        console.log("Primary is offline! ", e.message);
        return;
    }

    if (!primaryOnline) return;

    for (const model of MODELS) {
        const idField = (model === "newsletterSubscriber" || model === "staff") ? "email" :
            (model === "apiKey") ? "key" : "id";

        // Get primary IDs
        const primaryRecords = await neonClients[0].client[model].findMany({ select: { [idField]: true } });
        const primaryIds = new Set(primaryRecords.map(r => r[idField]));

        for (let i = 1; i < 3; i++) {
            const nc = neonClients[i];
            try {
                const replicaRecords = await nc.client[model].findMany({ select: { [idField]: true } });
                const extraIds = replicaRecords.map(r => r[idField]).filter(id => !primaryIds.has(id));

                if (extraIds.length > 0) {
                    console.log(`🗑️  ${nc.label} has ${extraIds.length} extra records in ${model}. Deleting...`);
                    await nc.client[model].deleteMany({
                        where: { [idField]: { in: extraIds } }
                    });
                    console.log(`    ✅ Deleted extra records.`);
                }
            } catch (e) {
                console.log(`    ❌ Failed on ${nc.label} ${model}: ${e.message}`);
            }
        }
    }

    console.log("\n✅ CLEANUP FINISHED. Re-running verification to confirm...");

    for (const nc of neonClients) {
        let out = `  ${nc.label}: `;
        for (const model of MODELS.slice().reverse()) { // Just to print out nicely
            const count = await nc.client[model].count();
            out += `${model}=${count} | `;
        }
        console.log(out);
        await nc.client.$disconnect();
    }
}

run().catch(console.error);
