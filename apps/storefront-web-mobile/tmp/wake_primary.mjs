// wake_primary.mjs - wake up the suspended primary Neon DB
import { PrismaClient } from "@prisma/client";

const URL = "postgresql://neondb_owner:npg_y3NxSJ2tqzIR@ep-broad-mountain-ain5e1yj-pooler.c-4.us-east-1.aws.neon.tech/neondb?sslmode=require";

console.log("Waking up primary Neon DB (may take 10-30s to resume from suspension)...");

const p = new PrismaClient({ datasources: { db: { url: URL } }, log: [] });

for (let attempt = 1; attempt <= 5; attempt++) {
    try {
        await p.$queryRaw`SELECT 1`;
        const counts = await Promise.all([
            p.product.count(),
            p.category.count(),
            p.offer.count(),
            p.review.count(),
            p.staff.count(),
        ]);
        console.log(`\n✅ Primary DB ONLINE (attempt ${attempt})`);
        console.log(`  Products: ${counts[0]}, Categories: ${counts[1]}, Offers: ${counts[2]}, Reviews: ${counts[3]}, Staff: ${counts[4]}`);
        break;
    } catch (e) {
        console.log(`  Attempt ${attempt}/5 failed. Waiting 10s...`);
        await new Promise(r => setTimeout(r, 10000));
    }
}

await p.$disconnect();
