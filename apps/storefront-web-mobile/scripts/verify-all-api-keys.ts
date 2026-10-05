import * as dotenv from "dotenv";
import fs from "node:fs";
import path from "node:path";
import { getAPIKeyManager } from "../src/lib/api-key-manager";
import {
    getLightningChatCompletionsUrl,
    getLightningModel,
    getLightningVisionFallbackModel,
    getLightningVisionModel,
} from "../src/lib/lightning-config";
import type { LLMProvider } from "../src/types/assistant-types";

// Smallest valid PNG (1x1, transparent). Enough for the model to accept the
// request, cheap enough to send on every verification run.
const TINY_PNG_DATA_URL = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNk+M9QDwADhgGAWjR9awAAAABJRU5ErkJggg==";

type RequiredProvider = Extract<LLMProvider, "groq" | "lightning">;

interface ManagedKey {
    key: string;
    provider: LLMProvider;
}

interface KeyTestResult {
    state: "working" | "limited" | "invalid" | "failed" | "skipped";
    status?: number;
}

for (const filename of [".env.local", ".env", "env"]) {
    const envPath = path.resolve(process.cwd(), filename);
    if (fs.existsSync(envPath)) {
        dotenv.config({ path: envPath, override: false, quiet: true });
    }
}

const requestedProvider = process.argv[2]?.toLowerCase();
const PROVIDERS: RequiredProvider[] = requestedProvider === "groq" || requestedProvider === "lightning"
    ? [requestedProvider]
    : ["groq", "lightning"];
const DRY_RUN = process.env.AI_VERIFY_DRY_RUN === "1";

async function testKey(provider: RequiredProvider, apiKey: string): Promise<KeyTestResult> {
    if (DRY_RUN) return { state: "skipped" };

    const isGroq = provider === "groq";
    const endpoint = isGroq
        ? "https://api.groq.com/openai/v1/chat/completions"
        : getLightningChatCompletionsUrl();
    const model = isGroq
        ? process.env.GROQ_MODEL_LIGHT || "openai/gpt-oss-20b"
        : getLightningModel();

    try {
        const response = await fetch(endpoint, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${apiKey}`,
            },
            body: JSON.stringify({
                model,
                messages: [{
                    role: "user",
                    content: isGroq
                        ? "Reply with OK only."
                        : [{ type: "text", text: "Reply with OK only." }],
                }],
                max_tokens: 5,
            }),
            signal: AbortSignal.timeout(20_000),
        });

        if (response.ok) return { state: "working", status: response.status };
        if (response.status === 402 || response.status === 429) {
            return { state: "limited", status: response.status };
        }
        if (response.status === 401 || response.status === 403) {
            return { state: "invalid", status: response.status };
        }
        return { state: "failed", status: response.status };
    } catch {
        return { state: "failed" };
    }
}

/**
 * Vision uses different model ids than text, so a passing text check says
 * nothing about whether image search works. Send a real (tiny) image.
 */
async function testVisionModel(apiKey: string, model: string): Promise<KeyTestResult> {
    if (DRY_RUN) return { state: "skipped" };

    try {
        const response = await fetch(getLightningChatCompletionsUrl(), {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${apiKey}`,
            },
            body: JSON.stringify({
                model,
                messages: [{
                    role: "user",
                    content: [
                        { type: "image_url", image_url: { url: TINY_PNG_DATA_URL } },
                        { type: "text", text: "Reply with OK only." },
                    ],
                }],
                max_tokens: 5,
            }),
            signal: AbortSignal.timeout(30_000),
        });

        if (response.ok) return { state: "working", status: response.status };
        if (response.status === 402 || response.status === 429) {
            return { state: "limited", status: response.status };
        }
        if (response.status === 401 || response.status === 403) {
            return { state: "invalid", status: response.status };
        }
        return { state: "failed", status: response.status };
    } catch {
        return { state: "failed" };
    }
}

async function verifyVisionModels(keys: ManagedKey[]): Promise<boolean> {
    const lightningKey = keys.find(key => key.provider === "lightning");
    console.log("lightning vision (image search)");

    if (!lightningKey) {
        console.error("  MISSING: no Lightning AI key, so image search cannot run");
        return false;
    }

    const models = [
        { label: "primary ", name: getLightningVisionModel() },
        { label: "fallback", name: getLightningVisionFallbackModel() },
    ];

    let working = 0;
    for (const model of models) {
        const result = await testVisionModel(lightningKey.key, model.name);
        if (result.state === "working") working++;

        const status = result.status ? ` (HTTP ${result.status})` : "";
        console.log(`  ${model.label}: ${model.name} -> ${result.state.toUpperCase()}${status}`);

        if (result.status !== undefined && result.status >= 400 && result.status < 500
            && result.status !== 401 && result.status !== 403
            && result.status !== 402 && result.status !== 429) {
            console.error(`    HINT: ${model.name} was rejected. Check the model id`
                + " matches one Lightning AI serves (expected a lightning-ai/... id).");
        }
    }

    return DRY_RUN || working > 0;
}

async function verifyProvider(provider: RequiredProvider, keys: ManagedKey[]): Promise<boolean> {
    const providerKeys = keys.filter(key => key.provider === provider);
    console.log(`${provider}: ${providerKeys.length} configured key(s)`);

    if (providerKeys.length === 0) {
        console.error(`  MISSING: add at least one ${provider.toUpperCase()} API key`);
        return false;
    }

    let working = 0;
    for (const [index, keyConfig] of providerKeys.entries()) {
        const result = await testKey(provider, keyConfig.key);
        if (result.state === "working") working++;

        const status = result.status ? ` (HTTP ${result.status})` : "";
        console.log(`  key ${index + 1}: ${result.state.toUpperCase()}${status}`);
    }

    if (providerKeys.length === 1) {
        console.warn("  WARNING: only one key is configured, so same-provider rotation is unavailable");
    } else {
        console.log(`  rotation ready: ${providerKeys.length} keys`);
    }

    return DRY_RUN || working > 0;
}

async function verifyAllKeys() {
    const manager = getAPIKeyManager();
    const keys = (manager as unknown as { keys: ManagedKey[] }).keys;

    console.log("AI provider live verification");
    console.log("Key values are never printed.\n");

    const results = [];
    for (const provider of PROVIDERS) {
        results.push(await verifyProvider(provider, keys));
    }

    if (PROVIDERS.includes("lightning")) {
        results.push(await verifyVisionModels(keys));
    }

    if (results.every(Boolean)) {
        const providerLabel = PROVIDERS.map(provider => provider === "groq" ? "Groq" : "Lightning AI")
            .join(" and ");
        console.log(DRY_RUN
            ? `\nDRY RUN READY: ${providerLabel} configuration was discovered; no network requests were made.`
            : `\nREADY: ${providerLabel} completed live requests.`);
        return;
    }

    console.error("\nNOT READY: fix the missing or failing provider configuration above.");
    process.exitCode = 1;
}

void verifyAllKeys();
