import { describe, expect, it } from "vitest";
import {
    classifyAssistantScope,
    createScopedAssistantResponse,
} from "./assistant-scope";

describe("assistant business scope", () => {
    it("allows direct product searches, including Groq Vision descriptions", () => {
        expect(classifyAssistantScope("Gold butterfly floral pattern thermos flask")).toEqual({
            scope: "shopping",
        });
        expect(classifyAssistantScope("I need a screwdriver under ₹500")).toEqual({
            scope: "shopping",
        });
        expect(classifyAssistantScope("weatherproof umbrella")).toEqual({
            scope: "shopping",
        });
    });

    it("allows barcode lookups without calling an LLM", () => {
        expect(classifyAssistantScope("barcode: 8901234567890")).toEqual({
            scope: "shopping",
        });
    });

    it("keeps greetings local and friendly", () => {
        const decision = classifyAssistantScope("Namaste Genie");
        const response = createScopedAssistantResponse(decision);

        expect(decision).toEqual({ scope: "greeting" });
        expect(response.summary).toContain("Smart Avenue’s shopping assistant");
        expect(response.intent?.isGeneralChat).toBe(true);
    });

    it("rejects general-purpose prompts before they reach Groq", () => {
        const decision = classifyAssistantScope("Write a short poem about space");
        const response = createScopedAssistantResponse(decision);

        expect(decision).toEqual({ scope: "out_of_scope" });
        expect(response.summary).toContain("only with Smart Avenue products");
        expect(classifyAssistantScope("Tell me a joke about bangles")).toEqual({
            scope: "out_of_scope",
        });
    });
});
