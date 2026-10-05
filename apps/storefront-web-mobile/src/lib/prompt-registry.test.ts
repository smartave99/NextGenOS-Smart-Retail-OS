import { describe, expect, it, vi } from "vitest";

vi.mock("@/app/actions/ai-prompts-actions", () => ({
    getAIPrompts: vi.fn().mockResolvedValue([]),
}));

import { renderPromptTemplate } from "./prompt-registry";

describe("renderPromptTemplate", () => {
    it("renders standard and legacy whitespace placeholders", () => {
        const rendered = renderPromptTemplate(
            "Hello {{persona}}. Product: { { productName } }. Again: {{ productName }}.",
            { persona: "Genie", productName: "Travel Bag" }
        );

        expect(rendered).toBe("Hello Genie. Product: Travel Bag. Again: Travel Bag.");
    });

    it("does not treat dots in variable names as wildcard patterns", () => {
        const rendered = renderPromptTemplate(
            "Use case: {{ intent.useCase }} / untouched: {{ intentXuseCase }}",
            { "intent.useCase": "Daily commute" }
        );

        expect(rendered).toBe("Use case: Daily commute / untouched: {{ intentXuseCase }}");
    });
});
