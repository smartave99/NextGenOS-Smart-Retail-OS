import dotenv from 'dotenv';
import path from 'path';

// Load .env.local
dotenv.config({ path: path.resolve(process.cwd(), '.env.local') });

import { DEFAULT_PROMPTS } from '../src/lib/prompt-defaults';
import { Redis } from '@upstash/redis';

const BLOB_FILENAME = "llmo_prompts.json";

// Initialize the Redis client from env vars (UPSTASH_REDIS_REST_URL/TOKEN)
const redis = Redis.fromEnv();

async function syncPrompts() {
    console.log(`Syncing '${BLOB_FILENAME}' with updated codebase defaults...`);
    try {
        let currentData = await redis.get<any>(BLOB_FILENAME);

        if (!currentData) {
            currentData = {};
        }

        // Let's explicitly overwrite intent-analyze
        if (currentData['intent-analyze']) {
            console.log("Found existing intent-analyze prompt in database. Updating it to match new defaults...");
            currentData['intent-analyze'] = {
                ...currentData['intent-analyze'],
                systemPrompt: DEFAULT_PROMPTS['intent-analyze'].systemPrompt,
                updatedAt: new Date().toISOString()
            };

            await redis.set(BLOB_FILENAME, currentData);

            console.log("✅ Successfully synced intent-analyze prompt to Upstash Redis.");
        } else {
            console.log("intent-analyze prompt not found in DB overrides. It will naturally use the codebase default.");
        }
    } catch (e) {
        console.error("Error syncing prompts to Redis:", e);
    }
}

syncPrompts();
