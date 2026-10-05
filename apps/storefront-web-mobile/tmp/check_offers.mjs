// check_offers.mjs
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

const neonClients = [
    { label: "Primary", url: ENV.DATABASE_URL },
    { label: "Account 2", url: ENV.DATABASE_URL_2 },
    { label: "Account 3", url: ENV.DATABASE_URL_3 },
];

console.log("\n🔍 VERIFYING OFFER CREATION FAN-OUT...\n");

for (const nc of neonClients) {
    const client = new PrismaClient({ datasources: { db: { url: nc.url } }, log: [] });
    try {
        const offers = await client.offer.findMany({ select: { title: true } });
        console.log(`✅ ${nc.label} has ${offers.length} offers:`);
        offers.forEach(o => console.log(`   - ${o.title}`));
    } catch (e) {
        console.log(`❌ ${nc.label} failed: ${e.message}`);
    } finally {
        await client.$disconnect();
    }
}
