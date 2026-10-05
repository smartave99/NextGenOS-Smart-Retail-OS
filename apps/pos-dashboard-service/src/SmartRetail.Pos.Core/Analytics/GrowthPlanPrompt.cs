namespace SmartRetail.Pos.Core.Analytics;

public enum PlanLanguage
{
    English,
    Hindi,
    Hinglish,
}

/// <summary>What the AI is asked when the owner wants a plan to grow sales.</summary>
public static class GrowthPlanPrompt
{
    public const string SystemPrompt =
        "You are a practical retail advisor for small shops in India. You are given one shop's figures, taken from its "
        + "billing software. Suggest what the owner can do in the next 30 days to sell more and earn more.\n"
        + "Rules:\n"
        + "- Use only the figures given. Never invent numbers, products or customers.\n"
        + "- When a figure is missing or cannot be trusted (for example negative stock), say what to check instead of guessing.\n"
        + "- Suggest things a small shop can do with little money: better displays, bundles, offers on slow days, "
        + "reordering best sellers, clearing stock that does not sell, rewards for repeat customers, UPI and WhatsApp.\n"
        + "- Be specific: name the products, categories and weekdays from the figures.\n"
        + "- Keep it short and simple; the owner reads it on the shop computer.";

    public const int MaxGoalLength = 300;

    /// <param name="memory">What the assistant remembers, e.g. what the shop tried and how it went; or empty.</param>
    /// <param name="doingNow">What the shop is doing now or soon to sell more (the Actions page), one line each.</param>
    public static string UserPrompt(string brief, PlanLanguage language, string? goal = null, string? memory = null,
        IReadOnlyList<string>? doingNow = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(brief);
        var ownerGoal = (goal ?? "").Trim();
        if (ownerGoal.Length > MaxGoalLength)
        {
            ownerGoal = ownerGoal[..MaxGoalLength];
        }

        return "THE SHOP'S FIGURES\n"
            + brief.TrimEnd() + "\n\n"
            + MemoryBlock(memory)
            + (doingNow is { Count: > 0 }
                ? "WHAT THE SHOP IS DOING NOW\n" + string.Concat(doingNow.Select(line => "- " + line + "\n")) + "Build around these; do not suggest them again.\n\n"
                : "")
            + (ownerGoal.Length > 0 ? "THE OWNER'S GOAL\n" + ownerGoal + "\n\n" : "")
            + "Write the plan in " + LanguageInstruction(language) + ". Use Markdown: ## headings, - bullet points, "
            + "**bold** for the key figures. Use these four parts:\n"
            + "## Where the shop stands\n3 short points, each with a figure from above.\n"
            + "## Plan for the next 30 days\n5 to 7 actions, the most valuable first. For each: what to do, why (quote the figures), "
            + "and how the owner will see that it worked.\n"
            + "## Quick wins this week\n3 things to do in the next 7 days.\n"
            + "## Stock\nWhat to reorder, what to clear with an offer, and which stock records to correct.\n"
            + "Stay under 450 words.";
    }

    /// <summary>What the assistant remembers, as a part of a prompt; nothing when memory is empty. Build on what
    /// worked, and do not suggest again what did not.</summary>
    public static string MemoryBlock(string? memory) =>
        string.IsNullOrWhiteSpace(memory)
            ? ""
            : "WHAT YOU REMEMBER\n" + memory.Trim() + "\nBuild on what worked before, and do not suggest again what did not.\n\n";

    private static string LanguageInstruction(PlanLanguage language) => language switch
    {
        PlanLanguage.Hindi => "Hindi (Devanagari script), keeping product names as they are written above",
        PlanLanguage.Hinglish => "Hinglish (Hindi written in English letters, mixed with English words), as shop owners write on WhatsApp",
        _ => "simple English",
    };
}
