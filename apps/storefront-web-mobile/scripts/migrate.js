const { list } = require('@vercel/blob');
const { Redis } = require('@upstash/redis');
require('dotenv').config({ path: '.env.local' });

const redis = Redis.fromEnv();

async function migrate() {
    console.log('Starting migration...');
    const files = ['site_config.json', 'llmo.json', 'llmo_prompts.json'];

    for (const file of files) {
        try {
            const { blobs } = await list({
                prefix: file,
                limit: 1,
                token: process.env.BLOB_READ_WRITE_TOKEN
            });

            if (blobs.length > 0) {
                console.log(`Found ${file} in Vercel. Downloading...`);
                // Add timestamp to bypass Vercel CDN Cache
                const versionedUrl = `${blobs[0].url}?v=${Date.now()}`;
                const response = await fetch(versionedUrl);
                const data = await response.json();
                console.log(`Uploading ${file} to Upstash...`);
                await redis.set(file, data);
                console.log(`✅ Migrated ${file}`);
            } else {
                console.log(`⏩ Skipped ${file} (Not found in Vercel Blob)`);
            }
        } catch (e) {
            console.error(`❌ Error migrating ${file}:`, e);
        }
    }
    console.log('Migration complete!');
}

migrate();
