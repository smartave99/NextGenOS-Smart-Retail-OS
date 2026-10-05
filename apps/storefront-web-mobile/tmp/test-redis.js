
const { Redis } = require("@upstash/redis");
const dotenv = require("dotenv");
const path = require("path");

// Load .env.local
dotenv.config({ path: path.join(process.cwd(), ".env.local") });

async function testRedis() {
    console.log("Testing Redis initialization...");
    console.log("Current working directory:", process.cwd());

    const configs = [];

    // Numbered accounts (1, 2, 3)
    for (let i = 1; i <= 3; i++) {
        const url = process.env[`UPSTASH_REDIS_REST_URL_${i}`];
        const token = process.env[`UPSTASH_REDIS_REST_TOKEN_${i}`];
        if (url && token) {
            configs.push({ url, token, source: `Numbered account ${i}` });
            console.log(`Found config for account ${i}`);
        }
    }

    // Fallback to default env vars
    const defaultUrl = process.env.UPSTASH_REDIS_REST_URL;
    const defaultToken = process.env.UPSTASH_REDIS_REST_TOKEN;
    if (defaultUrl && defaultToken) {
        const alreadyExists = configs.some(c => c.url === defaultUrl);
        if (!alreadyExists) {
            configs.push({ url: defaultUrl, token: defaultToken, source: "Default account" });
            console.log("Found config for default account");
        }
    }

    if (configs.length === 0) {
        console.error("FAILED: No Redis clients configured.");
        console.log("DEBUG: process.env keys:", Object.keys(process.env).filter(k => k.includes("UPSTASH")));
        process.exit(1);
    }

    console.log(`Initialized ${configs.length} configs. Testing first client connection...`);

    const redis = new Redis({ url: configs[0].url, token: configs[0].token });

    try {
        const testKey = "antigravity_test_key";
        await redis.set(testKey, { success: true, timestamp: Date.now() });
        const result = await redis.get(testKey);
        console.log("Redis connection test successful!", result);
        await redis.del(testKey);
    } catch (error) {
        console.error("Redis connection FAILED:", error);
        process.exit(1);
    }
}

testRedis().catch(err => {
    console.error("Unhandled error:", err);
    process.exit(1);
});
