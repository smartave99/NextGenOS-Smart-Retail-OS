using SmartRetail.AI.Settings;
using SmartRetail.Pos.Core.Posters;

namespace SmartRetail.Pos.Web.Services;

/// <summary>Turns the customer's AI profile into what the poster code needs to know.</summary>
public static class PosterLocales
{
    public static PosterLocale From(ShopProfile? shop)
    {
        if (shop is null)
        {
            return PosterLocale.Neutral;
        }

        return new PosterLocale
        {
            CountryName = shop.CountryName,
            ShopKind = shop.ShopKind,
            LocalLanguage = shop.LocalLanguage,
            LocalLanguageTag = shop.LocalLanguageTag,
            Festivals = shop.Festivals.ToList(),
            LocalLines = new Dictionary<string, string>(shop.PosterLines),
        };
    }
}
