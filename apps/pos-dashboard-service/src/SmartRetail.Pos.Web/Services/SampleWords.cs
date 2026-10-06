using SmartRetail.AI.Settings;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// The "for example" words in the boxes of the Creatives, Past chats and Memory pages. They are sample content, so they belong to the customer (CLAUDE.md, section 8):
/// they use the first festival and the second language of the customer's profile when it has them, and are plain and neutral when it has not.
/// </summary>
public static class SampleWords
{
    private static string? Festival(ShopProfile shop) => shop.Festivals.Count > 0 ? shop.Festivals[0] : null;

    /// <summary>"e.g. Diwali offer" for a shop whose first festival is Diwali; "e.g. Seasonal sale" for one with no festival.</summary>
    public static string CreativeHeadline(ShopProfile shop) => "e.g. " + (Festival(shop) is { } festival ? festival + " offer" : "Seasonal sale");

    public static string CreativeSubtitle(ShopProfile shop) => "e.g. " + (Festival(shop) is { } festival ? "Fresh stock for " + festival : "Fresh stock just in");

    public static string CreativeBackground(ShopProfile shop) => "e.g. a warm evening glow" + (Festival(shop) is { } festival ? " with " + festival + " decorations" : "");

    /// <summary>The words in the box that searches past chats.</summary>
    public static string PastChatSearch(ShopProfile shop) => "Search past chats, e.g. " + (Festival(shop) is { } festival ? "sugar " + festival : "best sellers");

    /// <summary>What the shop's memory might hold.</summary>
    public static string MemoryAboutShop(ShopProfile shop) => "e.g. Sales are higher in " + (Festival(shop) is { } festival ? festival + " week" : "the last week of the month");

    /// <summary>What the memory of the person might hold: the second language is offered only when the profile has one.</summary>
    public static string MemoryAboutYou(ShopProfile shop) => "e.g. Answer " + (shop.HasLocalLanguage ? "in " + shop.LocalLanguage + ", " : "") + "short, with the main figures first";
}
