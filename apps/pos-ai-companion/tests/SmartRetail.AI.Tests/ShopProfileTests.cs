using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using SmartRetail.AI.Creatives;
using SmartRetail.AI.Posters;
using SmartRetail.AI.Products;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>A customer's profile for a few shops, as the Setup Studio writes it.</summary>
    internal static class Shops
    {
        public const string PhilippinesJson = @"{
  ""schema"": 1,
  ""country"": { ""code"": ""PH"", ""name"": ""the Philippines"" },
  ""shopKind"": ""a small shop"",
  ""images"": {
    ""models"": [
      { ""title"": ""Filipino model"", ""looks"": ""Filipino, in her late twenties"" },
      { ""title"": ""Chinese-Filipino model"", ""looks"": ""Chinese-Filipino"" },
      { ""title"": ""Visayan model"", ""looks"": ""Visayan, in his forties"" }
    ],
    ""festivals"": [""Christmas"", ""Sinulog"", ""christmas""],
    ""localLanguage"": { ""name"": ""Filipino"", ""tag"": ""fil"" }
  }
}";

        public static ShopProfile Philippines => ShopProfile.Parse(PhilippinesJson);
    }

    public sealed class ShopProfileTests : IDisposable
    {
        private readonly string _folder = Path.Combine(Path.GetTempPath(), "shop-profile-" + Guid.NewGuid().ToString("N"));

        public ShopProfileTests() => Directory.CreateDirectory(_folder);

        public void Dispose()
        {
            try { Directory.Delete(_folder, true); } catch (IOException) { }
        }

        [Fact]
        public void With_no_profile_nothing_is_assumed_not_a_country_a_look_a_festival_or_a_second_language()
        {
            var shop = ShopProfile.Neutral;

            Assert.Equal("a small shop", shop.Shop);
            Assert.Equal("", shop.InCountry);
            Assert.Empty(shop.Festivals);
            Assert.False(shop.HasLocalLanguage);
            Assert.Equal(new[] { "Model 1", "Model 2", "Model 3" }, Enumerable.Range(0, 3).Select(i => shop.ModelAt(i).Title));
            Assert.All(Enumerable.Range(0, 3), i => Assert.Equal("", shop.ModelAt(i).Looks));
            Assert.DoesNotContain("India", shop.TypicalPlace);
        }

        [Fact]
        public void A_profile_sets_the_country_the_kind_the_models_the_festivals_and_the_second_language()
        {
            var shop = Shops.Philippines;

            Assert.Equal("a small shop in the Philippines", shop.Shop);
            Assert.Equal(new[] { "Filipino model", "Chinese-Filipino model", "Visayan model" }, Enumerable.Range(0, 3).Select(i => shop.ModelAt(i).Title));
            Assert.Equal("Visayan, in his forties", shop.ModelAt(2).Looks);
            Assert.Equal(new[] { "Christmas", "Sinulog" }, shop.Festivals); // a repeat in other letters is one
            Assert.Equal(("Filipino", "fil"), (shop.LocalLanguage, shop.LocalLanguageTag));
        }

        [Fact]
        public void The_same_photo_prompts_say_neutral_things_without_a_profile_and_the_customers_own_with_one()
        {
            var seen = new ProductUnderstanding();
            foreach (var kind in PhotoKinds.All)
            {
                var neutral = ProductPhotoPrompt.ImageInstructions(kind, seen);
                foreach (var word in new[] { "India", "Indian", "Hindi", "Indian", "fair complexion", "European", "East Asian" })
                {
                    Assert.DoesNotContain(word, neutral);
                }
            }

            var withLooks = ProductPhotoPrompt.ImageInstructions(PhotoKind.IndianModel, seen, null, Shops.Philippines);
            var without = ProductPhotoPrompt.ImageInstructions(PhotoKind.IndianModel, seen);
            Assert.Contains("(Chinese-Filipino)", withLooks);
            Assert.DoesNotContain("(", without.Split(new[] { "using or holding" }, StringSplitOptions.None)[0].Split(new[] { "one model," }, StringSplitOptions.None)[1]);
            Assert.NotEqual(without, withLooks);
        }

        [Fact]
        public void The_titles_on_the_screen_are_the_customers_and_the_ids_in_file_names_stay_the_same()
        {
            Assert.Equal("White background", PhotoKind.WhiteBackground.Title(Shops.Philippines));
            Assert.Equal("In use", PhotoKind.InUse.Title(Shops.Philippines));
            Assert.Equal("Chinese-Filipino model", PhotoKind.IndianModel.Title(Shops.Philippines));
            Assert.Equal("Model 2", PhotoKind.IndianModel.Title());
            Assert.Equal(new[] { "white", "in-use", "european-model", "indian-model", "east-asian-model" }, PhotoKinds.All.Select(k => k.FilePrefix()));
        }

        [Fact]
        public void The_description_asks_for_a_name_in_the_second_language_only_when_there_is_one()
        {
            var plain = JObject.Parse(ProductPhotoPrompt.UnderstandingSchema);
            Assert.Equal("Leave empty.", (string)plain["properties"]["local_name"]["description"]);

            var local = JObject.Parse(ProductPhotoPrompt.SchemaFor(Shops.Philippines));
            Assert.Contains("Filipino", (string)local["properties"]["local_name"]["description"]);
            Assert.Contains("local_name", local["required"].Select(t => (string)t));
            Assert.DoesNotContain("hindi_name", ProductPhotoPrompt.UnderstandingSchema);
        }

        [Fact]
        public void A_product_file_written_before_the_second_language_was_a_setting_is_still_read()
        {
            var old = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductUnderstanding>(@"{ ""DisplayName"": ""Bottle"", ""HindiName"": ""बोतल"" }");
            Assert.Equal("बोतल", old.LocalName);
            var written = Newtonsoft.Json.JsonConvert.SerializeObject(old);
            Assert.Contains("\"LocalName\":\"बोतल\"", written);
            Assert.DoesNotContain("HindiName", written);
        }

        [Fact]
        public void A_poster_and_a_creative_are_made_for_the_customers_business_in_its_country()
        {
            var poster = PosterArtworkPrompt.CodexPrompt(new PosterArtworkRequest { Theme = "a clearance sale" });
            Assert.Contains("for a small shop.", poster);
            Assert.DoesNotContain("India", poster);
            Assert.Contains("for a small shop in the Philippines.", PosterArtworkPrompt.CodexPrompt(new PosterArtworkRequest { Theme = "a clearance sale", Shop = Shops.Philippines }));

            var creative = new CreativeArtRequest { FormatName = "Square post", Width = 1080, Height = 1080, ShopName = "Luzon Fresh Mart", Shop = Shops.Philippines };
            Assert.Contains("advertising creative for a small shop in the Philippines, Luzon Fresh Mart.", CreativeArtPrompt.CodexPrompt(creative));
            creative.Shop = ShopProfile.Neutral;
            Assert.DoesNotContain("India", CreativeArtPrompt.CodexPrompt(creative));
        }

        [Fact]
        public void Something_that_is_not_a_profile_gives_the_neutral_one_and_says_why_and_nothing_in_it_can_carry_markup()
        {
            var problems = new List<string>();
            Assert.Equal("a small shop", ShopProfile.Parse("not json", problems).Shop);
            Assert.Single(problems);
            problems.Clear();
            Assert.Equal("", ShopProfile.Parse(@"{ ""country"": { ""name"": ""X"" } }", problems).CountryName);
            Assert.Contains("schema", problems.Single());

            problems.Clear();
            var hostile = ShopProfile.Parse(@"{ ""schema"": 1, ""country"": { ""name"": ""<script>alert(1)</script>"" }, ""shopKind"": ""a \""quoted\"" shop"",
                ""images"": { ""models"": [ { ""title"": ""Ok model"", ""looks"": ""line one\nline two"" }, 5, null, {}, { ""title"": ""fourth"" } ], ""festivals"": [""A"", ""B\u0007"", ""C""],
                ""localLanguage"": { ""name"": ""Klingon"", ""tag"": ""Not A Tag"" } } }", problems);
            Assert.Equal("", hostile.CountryName);
            Assert.Equal("a small shop", hostile.ShopKind); // the bad one is left out, the default stays
            Assert.Equal("Ok model", hostile.ModelAt(0).Title);
            Assert.Equal("", hostile.ModelAt(0).Looks);
            Assert.Equal("Model 2", hostile.ModelAt(1).Title);
            Assert.Equal(new[] { "A", "C" }, hostile.Festivals);
            Assert.False(hostile.HasLocalLanguage);
            Assert.True(problems.Count >= 4);
        }

        [Fact]
        public void Ready_made_second_language_lines_are_read_for_the_poster_kinds_and_only_with_a_second_language()
        {
            var withLines = ShopProfile.Parse(@"{ ""schema"": 1, ""images"": { ""localLanguage"": { ""name"": ""Hindi"", ""tag"": ""hi"",
                ""lines"": { ""clearance"": ""भारी छूट"", ""best-sellers"": ""सबकी पसंद"", ""diwali"": ""x"", ""new-arrivals"": ""<b>नया</b>"" } } } }");
            var noLanguage = ShopProfile.Parse(@"{ ""schema"": 1, ""images"": { ""localLanguage"": { ""lines"": { ""clearance"": ""भारी छूट"" } } } }");

            Assert.Equal(2, withLines.PosterLines.Count);
            Assert.Equal("भारी छूट", withLines.PosterLines["clearance"]);
            Assert.Equal("सबकी पसंद", withLines.PosterLines["best-sellers"]);
            Assert.DoesNotContain("diwali", withLines.PosterLines.Keys);
            Assert.DoesNotContain("new-arrivals", withLines.PosterLines.Keys);
            Assert.Empty(noLanguage.PosterLines);
            Assert.Empty(ShopProfile.Neutral.PosterLines);
        }

        [Fact]
        public void The_profile_is_found_beside_the_program_or_in_the_folder_above_it_and_a_missing_or_huge_one_is_ignored()
        {
            var dashboard = Path.Combine(_folder, "Dashboard");
            Directory.CreateDirectory(dashboard);
            Assert.Equal("", ShopProfile.LoadNear(dashboard).CountryName);

            Directory.CreateDirectory(Path.Combine(_folder, "profile"));
            File.WriteAllText(Path.Combine(_folder, "profile", ShopProfile.FileName), Shops.PhilippinesJson);
            Assert.Equal("the Philippines", ShopProfile.LoadNear(dashboard).CountryName);   // the dashboard lives in a folder inside the program's
            Assert.Equal("the Philippines", ShopProfile.LoadNear(_folder).CountryName);

            File.WriteAllText(Path.Combine(_folder, "profile", ShopProfile.FileName), new string('x', 300_000));
            Assert.Equal("", ShopProfile.LoadNear(_folder).CountryName);
        }

        [Fact]
        public void The_settings_store_attaches_the_profile_and_never_saves_it_with_the_owners_settings()
        {
            Directory.CreateDirectory(Path.Combine(_folder, "profile"));
            File.WriteAllText(Path.Combine(_folder, "profile", ShopProfile.FileName), Shops.PhilippinesJson);
            var settingsFile = Path.Combine(_folder, "data", "settings.json");
            var store = new SettingsStore(settingsFile, _folder);

            var loaded = store.Load();
            Assert.Equal("the Philippines", loaded.Shop.CountryName);
            loaded.Shop = ShopProfile.Neutral; // whatever the owner's screens do with it
            store.Save(loaded);

            Assert.DoesNotContain("Philippines", File.ReadAllText(settingsFile));
            Assert.DoesNotContain("\"Shop\"", File.ReadAllText(settingsFile));
            Assert.Equal("the Philippines", store.Load().Shop.CountryName);
        }
    }
}
