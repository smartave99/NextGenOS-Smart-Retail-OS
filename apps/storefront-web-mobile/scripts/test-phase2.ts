
import * as dotenv from "dotenv";
import path from "path";
import { fileURLToPath } from 'url';

// Fix for __dirname in ESM
const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

// Load env vars BEFORE importing the service
const envPath = path.resolve(process.cwd(), '.env.local');
console.log(`Loading env from ${envPath}`);
const result = dotenv.config({ path: envPath });

if (result.error) {
    console.error("Error loading .env.local", result.error);
} else {
    console.log("Environment loaded successfully.");
}

// Check if GROQ key is present
console.log("Checking GROQ_API_KEY:", process.env.GROQ_API_KEY ? "Present" : "Missing");
console.log("Checking GROQ_API_KEY_1:", process.env.GROQ_API_KEY_1 ? "Present" : "Missing");

async function testPhase2() {
    // Dynamic import to ensure env vars are loaded first
    const { generateStylistAdvice, generateGiftRecommendations } = await import("../src/lib/llm-service");

    console.log("----------------------------------------------------------------");
    console.log("🧪 STARTING PHASE 2 AI FEATURE TESTS (GROQ - DEEPSEEK MODELS)");
    console.log("----------------------------------------------------------------");

    // Test 1: AI Personal Stylist
    console.log("\n👠 TEST 1: AI Personal Stylist (Llama 3.3 70B)");
    try {
        const preferences = {
            gender: "Female",
            style: "Bohemian",
            occasion: "Summer Music Festival",
            budget: "Under ₹5000",
            colors: ["Teal", "Gold"]
        };
        console.log("Input:", preferences);

        const start = Date.now();
        const advice = await generateStylistAdvice(preferences, []);
        const duration = Date.now() - start;

        console.log(`⏱️ Duration: ${duration}ms`);
        console.log("✅ Advice:", advice.advice.substring(0, 100) + "...");
        console.log("✅ Outfit:", advice.suggestedOutfit);

        if (!advice.suggestedOutfit.top || !advice.suggestedOutfit.reasoning) {
            throw new Error("Invalid stylist output structure");
        }
    } catch (error) {
        console.error("❌ Stylist Test Failed:", error);
    }

    // Test 2: Gift Concierge
    console.log("\n🎁 TEST 2: Gift Concierge (Llama 3.3 70B)");
    try {
        const recipient = {
            relation: "Brother",
            age: "Young Adult (20-30)",
            interests: ["Gaming", "Tech", "Coffee"],
            occasion: "Birthday",
            budget: "₹2000 - ₹5000"
        };
        console.log("Input:", recipient);

        const start = Date.now();
        const gifts = await generateGiftRecommendations(recipient);
        const duration = Date.now() - start;

        console.log(`⏱️ Duration: ${duration}ms`);
        console.log("✅ Thought Process:", gifts.thoughtProcess.substring(0, 100) + "...");
        console.log("✅ Recommendations:", gifts.recommendations.length);
        console.log("First Rec:", gifts.recommendations[0]);

        if (gifts.recommendations.length === 0 || !gifts.recommendations[0].item) {
            throw new Error("Invalid gift output structure");
        }
    } catch (error) {
        console.error("❌ Gift Concierge Test Failed:", error);
    }

    console.log("\n----------------------------------------------------------------");
    console.log("🏁 PHASE 2 TESTS COMPLETE");
    console.log("----------------------------------------------------------------");
}

testPhase2();
