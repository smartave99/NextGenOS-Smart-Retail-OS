using SmartRetail.AI.Products;
using SmartRetail.AI.Settings;
using SmartRetail.Pos.Core.Posters;
using SmartRetail.Pos.Web.Services;
using Xunit;

namespace SmartRetail.Pos.Tests;

/// <summary>Posters follow the customer's profile: change the profile and the festivals, the second language and the words change; with none, nothing is assumed.</summary>
public sealed class PosterProfileTests : IDisposable
{
    private readonly string _folder = Path.Combine(Path.GetTempPath(), "poster-profile-" + Guid.NewGuid().ToString("N"));

    public PosterProfileTests() => Directory.CreateDirectory(Path.Combine(_folder, "profile"));

    public void Dispose()
    {
        try { Directory.Delete(_folder, recursive: true); } catch (IOException) { /* temp folder */ }
    }

    private AiEnvironment Environment() =>
        new(Microsoft.Extensions.Options.Options.Create(new AiOptions { SettingsFile = Path.Combine(_folder, "settings.json"), ProfileFolder = _folder }));

    private void WriteProfile(string json) => File.WriteAllText(Path.Combine(_folder, "profile", ShopProfile.FileName), json);

    [Fact]
    public void With_no_profile_a_poster_is_plain_one_language_and_names_no_country_or_festival()
    {
        var locale = Environment().PosterLocale;

        Assert.False(locale.HasLocalLanguage);
        Assert.Empty(locale.Festivals);
        Assert.Equal("a small shop", locale.Shop);
        Assert.Equal("", PosterKind.Clearance.DefaultWords(null, locale).LocalLine);
        Assert.DoesNotContain("India", PosterKind.FestivalOffer.ArtworkTheme(null, locale));
    }

    [Fact]
    public void A_profile_gives_the_festivals_the_second_language_and_its_ready_made_lines()
    {
        WriteProfile("""
            { "schema": 1, "country": { "name": "India" }, "shopKind": "a small grocery",
              "images": { "festivals": ["Diwali", "Holi"],
                "localLanguage": { "name": "Hindi", "tag": "hi", "lines": { "clearance": "भारी छूट · सीमित स्टॉक" } } } }
            """);
        var locale = Environment().PosterLocale;

        Assert.Equal(new[] { "Diwali", "Holi" }, locale.Festivals);
        Assert.Equal("Hindi", locale.LocalLanguage);
        Assert.Equal("hi", locale.LocalLanguageTag);
        Assert.Equal("a small grocery in India", locale.Shop);
        Assert.Equal("भारी छूट · सीमित स्टॉक", PosterKind.Clearance.DefaultWords(null, locale).LocalLine);
        Assert.Equal("", PosterKind.NewArrivals.DefaultWords(null, locale).LocalLine);
        Assert.Contains("in India", PosterKind.FestivalOffer.ArtworkTheme(null, locale));
    }

    [Fact]
    public void Another_customers_profile_changes_the_result_in_every_part()
    {
        WriteProfile("""{ "schema": 1, "country": { "name": "the Philippines" }, "images": { "festivals": ["Sinulog"], "localLanguage": { "name": "Filipino", "tag": "fil" } } }""");
        var locale = Environment().PosterLocale;

        Assert.Equal(new[] { "Sinulog" }, locale.Festivals);
        Assert.Contains("one line in Filipino", PosterPrompt.SystemPrompt(locale));
        Assert.DoesNotContain("Hindi", PosterPrompt.SystemPrompt(locale));
        Assert.Contains("the festival of Sinulog in the Philippines", PosterKind.FestivalOffer.ArtworkTheme("Sinulog", locale));
    }

    [Fact]
    public void The_photo_titles_come_from_the_profile_too()
    {
        WriteProfile("""{ "schema": 1, "images": { "models": [ { "title": "Filipino model" }, { "title": "Chinese-Filipino model" }, { "title": "Visayan model" } ] } }""");
        var shop = Environment().Shop;

        Assert.Equal("Chinese-Filipino model", PhotoKind.IndianModel.Title(shop));
        Assert.Equal("White background", PhotoKind.WhiteBackground.Title(shop));
        Assert.Equal("Model 1", PhotoKind.EuropeanModel.Title(ShopProfile.Neutral));
    }

    [Fact]
    public void The_poster_locale_of_no_profile_is_the_neutral_one()
    {
        Assert.Equal(PosterLocale.Neutral, PosterLocales.From(null));
    }
}
