using SmartRetail.AI.Settings;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

/// <summary>The "for example" words in the boxes follow the customer's profile and are neutral without one (CLAUDE.md, section 8).</summary>
public sealed class SampleWordsTests
{
    private static ShopProfile Profile(string festivals, string language = "") => ShopProfile.Parse(
        "{\"schema\":1,\"images\":{\"festivals\":[" + festivals + "]" + (language.Length > 0 ? ",\"localLanguage\":{\"name\":\"" + language + "\",\"tag\":\"fil\"}" : "") + "}}");

    [Fact]
    public void With_no_profile_the_examples_name_no_festival_and_no_language()
    {
        var none = ShopProfile.Neutral;

        Assert.Equal("e.g. Seasonal sale", SampleWords.CreativeHeadline(none));
        Assert.Equal("e.g. Fresh stock just in", SampleWords.CreativeSubtitle(none));
        Assert.Equal("e.g. a warm evening glow", SampleWords.CreativeBackground(none));
        Assert.Equal("Search past chats, e.g. best sellers", SampleWords.PastChatSearch(none));
        Assert.Equal("e.g. Sales are higher in the last week of the month", SampleWords.MemoryAboutShop(none));
        Assert.Equal("e.g. Answer short, with the main figures first", SampleWords.MemoryAboutYou(none));
    }

    [Fact]
    public void Every_example_comes_from_the_first_festival_and_the_second_language_of_the_profile()
    {
        var shop = Profile("\"Sinulog\",\"Christmas\"", "Filipino");

        Assert.Equal("e.g. Sinulog offer", SampleWords.CreativeHeadline(shop));
        Assert.Equal("e.g. Fresh stock for Sinulog", SampleWords.CreativeSubtitle(shop));
        Assert.Equal("e.g. a warm evening glow with Sinulog decorations", SampleWords.CreativeBackground(shop));
        Assert.Equal("Search past chats, e.g. sugar Sinulog", SampleWords.PastChatSearch(shop));
        Assert.Equal("e.g. Sales are higher in Sinulog week", SampleWords.MemoryAboutShop(shop));
        Assert.Equal("e.g. Answer in Filipino, short, with the main figures first", SampleWords.MemoryAboutYou(shop));
    }

    [Fact]
    public void Changing_the_profile_changes_the_examples()
    {
        Assert.NotEqual(SampleWords.CreativeHeadline(Profile("\"Eid\"")), SampleWords.CreativeHeadline(Profile("\"Christmas\"")));
        Assert.NotEqual(SampleWords.MemoryAboutYou(Profile("", "Filipino")), SampleWords.MemoryAboutYou(Profile("")));
    }

    [Fact]
    public void No_example_names_a_market_the_profile_does_not()
    {
        var all = new[]
        {
            SampleWords.CreativeHeadline(ShopProfile.Neutral), SampleWords.CreativeSubtitle(ShopProfile.Neutral), SampleWords.CreativeBackground(ShopProfile.Neutral),
            SampleWords.PastChatSearch(ShopProfile.Neutral), SampleWords.MemoryAboutShop(ShopProfile.Neutral), SampleWords.MemoryAboutYou(ShopProfile.Neutral),
        };

        foreach (var text in all)
        {
            Assert.DoesNotMatch("(?i)diwali|diya|hindi|hinglish|rupee|india|festival", text);
        }
    }
}
