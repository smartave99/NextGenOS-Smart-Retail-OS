using SmartRetail.Pos.Core.Analytics;

namespace SmartRetail.Pos.Tests;

public class ShopQuestionPromptTests
{
    [Fact]
    public void The_ai_gets_the_figures_and_the_question()
    {
        var prompt = ShopQuestionPrompt.UserPrompt("Period: 1–30 Sep\nSales: ₹1,20,000\n", "  Kaunsa product sabse zyada bika?  ");

        Assert.StartsWith("THE SHOP'S FIGURES\nPeriod: 1–30 Sep\nSales: ₹1,20,000\n\nTHE OWNER'S QUESTION\n", prompt);
        Assert.EndsWith("\nKaunsa product sabse zyada bika?", prompt);
        Assert.Contains("Never invent numbers", ShopQuestionPrompt.SystemPrompt);
        Assert.Contains("language of the question", ShopQuestionPrompt.SystemPrompt);
    }

    [Fact]
    public void What_the_assistant_remembers_comes_before_the_question()
    {
        var memory = "What you remember from earlier conversations:\nAbout the owner:\n- Prefers answers in Hinglish.\n";

        var prompt = ShopQuestionPrompt.UserPrompt("Sales: ₹10", "Best sellers?", memory);

        Assert.Contains("\n\nWHAT YOU REMEMBER\nWhat you remember from earlier conversations:\nAbout the owner:\n- Prefers answers in Hinglish.\n", prompt);
        Assert.True(prompt.IndexOf("WHAT YOU REMEMBER", StringComparison.Ordinal) < prompt.IndexOf("THE OWNER'S QUESTION", StringComparison.Ordinal));
        Assert.DoesNotContain("REMEMBER", ShopQuestionPrompt.UserPrompt("Sales: ₹10", "Best sellers?", "  "));
    }

    [Fact]
    public void Long_questions_are_cut_short()
    {
        var prompt = ShopQuestionPrompt.UserPrompt("Sales: ₹10", new string('a', 5000));

        Assert.EndsWith("\n" + new string('a', ShopQuestionPrompt.MaxQuestionLength), prompt);
    }

    [Fact]
    public void Photos_sent_with_a_question_are_mentioned_before_it()
    {
        var one = ShopQuestionPrompt.UserPrompt("Sales: ₹10", "Is this selling?", photos: 1);
        var two = ShopQuestionPrompt.UserPrompt("Sales: ₹10", "Which sells more?", photos: 2);

        Assert.Contains("\n\nTHE OWNER SENT A PHOTO (attached)\nLook at it:", one);
        Assert.Contains("never guess what you cannot read", one);
        Assert.Contains("THE OWNER SENT 2 PHOTOS (attached)\nLook at them:", two);
        Assert.True(one.IndexOf("PHOTO", StringComparison.Ordinal) < one.IndexOf("THE OWNER'S QUESTION", StringComparison.Ordinal));
        Assert.EndsWith("THE OWNER'S QUESTION\n(only the photo: say what it shows and what the figures say about it)",
            ShopQuestionPrompt.UserPrompt("Sales: ₹10", " ", photos: 1));
        Assert.DoesNotContain("PHOTO", ShopQuestionPrompt.UserPrompt("Sales: ₹10", "Best sellers?"));
    }

    [Fact]
    public void A_voice_question_asks_the_ai_to_say_what_it_heard_first()
    {
        var prompt = ShopQuestionPrompt.UserPrompt("Sales: ₹10", "", voice: true);

        Assert.Contains("THE OWNER ASKED BY VOICE (a recording is attached)\nListen to it. Start your answer with one line, \"Heard: \"", prompt);
        Assert.EndsWith("THE OWNER'S QUESTION\n(asked by voice)", prompt);
    }

    [Theory]
    [InlineData("Heard: aaj kitna cash aaya\n\nToday: **₹5,723**.", "aaj kitna cash aaya", "Today: **₹5,723**.")]
    [InlineData("heard: “Kitna bika?”\nSales: ₹10", "Kitna bika?", "Sales: ₹10")]
    [InlineData("  Heard: \"What sold most?\"  \r\n\r\nTea.", "What sold most?", "Tea.")]
    [InlineData("Heard: only this line", "only this line", "")]
    [InlineData("Heard:\nSales: ₹10", null, "Sales: ₹10")]
    [InlineData("Sales: ₹10. Heard: nothing", null, "Sales: ₹10. Heard: nothing")]
    [InlineData("", null, "")]
    public void What_was_heard_is_taken_from_the_answers_first_line(string answer, string? heard, string rest)
    {
        Assert.Equal((heard, rest), ShopQuestionPrompt.SplitHeard(answer));
    }

    [Theory]
    [InlineData("", "Question?")]
    [InlineData("Figures", " ")]
    public void Figures_and_a_question_are_needed(string brief, string question)
    {
        Assert.ThrowsAny<ArgumentException>(() => ShopQuestionPrompt.UserPrompt(brief, question));
    }
}
