namespace SmartRetail.Pos.Core.Analytics;

/// <summary>What the AI is asked in the chat on the demo shop, where it answers from the shop's figures.</summary>
public static class ShopQuestionPrompt
{
    public const string SystemPrompt =
        "You are the assistant of a small shop in India. You are given the shop's figures, taken from its billing "
        + "software, and a question from the owner.\n"
        + "Rules:\n"
        + "- Answer from the figures given only. Never invent numbers, products or customers.\n"
        + "- If the figures do not answer the question, say so in one sentence and say what would.\n"
        + "- Keep it short: two to five sentences, or a short list. Put the key figures in **bold**.\n"
        + "- Reply in the language of the question: English, Hindi (Devanagari script) or Hinglish.";

    public const int MaxQuestionLength = 1000;

    /// <summary>The first line of an answer to a voice note, saying what was heard.</summary>
    public const string HeardPrefix = "Heard:";

    /// <param name="memory">What the assistant remembers (the owner saved or approved it), or empty.</param>
    /// <param name="photos">How many photos the owner sent with the question (attached to the request).</param>
    /// <param name="voice">The owner asked by voice (a recording is attached).</param>
    public static string UserPrompt(string brief, string question, string? memory = null, int photos = 0, bool voice = false)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(brief);
        var asked = (question ?? "").Trim();
        if (asked.Length == 0 && photos == 0 && !voice)
        {
            throw new ArgumentException("A question is needed.", nameof(question));
        }

        if (asked.Length > MaxQuestionLength)
        {
            asked = asked[..MaxQuestionLength];
        }

        var sent = "";
        if (photos > 0)
        {
            sent += "THE OWNER SENT " + (photos == 1 ? "A PHOTO" : photos + " PHOTOS") + " (attached)\n"
                + "Look at " + (photos == 1 ? "it" : "them") + ": a product, a shelf or a note. Use what you can read on "
                + (photos == 1 ? "it" : "them") + ", such as a product's name or size, and never guess what you cannot read.\n\n";
        }

        if (voice)
        {
            sent += "THE OWNER ASKED BY VOICE (a recording is attached)\n"
                + "Listen to it. Start your answer with one line, \"" + HeardPrefix + " \" and what they said in their words, then a blank line.\n\n";
        }

        return "THE SHOP'S FIGURES\n" + brief.TrimEnd() + "\n\n"
            + GrowthPlanPrompt.MemoryBlock(memory)
            + sent
            + "THE OWNER'S QUESTION\n" + (asked.Length > 0 ? asked : voice ? "(asked by voice)" : "(only the photo: say what it shows and what the figures say about it)");
    }

    /// <summary>An answer to a voice note split into what was heard (its first line) and the answer itself.</summary>
    public static (string? Heard, string Answer) SplitHeard(string answer)
    {
        var text = (answer ?? "").Trim();
        if (!text.StartsWith(HeardPrefix, StringComparison.OrdinalIgnoreCase))
        {
            return (null, text);
        }

        var end = text.IndexOf('\n');
        var heard = (end < 0 ? text : text[..end])[HeardPrefix.Length..].Trim().Trim('"', '“', '”');
        return (heard.Length > 0 ? heard : null, end < 0 ? "" : text[(end + 1)..].Trim());
    }
}
