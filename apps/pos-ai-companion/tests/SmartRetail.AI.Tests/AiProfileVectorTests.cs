using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Nodes;
using SmartRetail.AI.Products;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>
    /// The shared cases (tests/vectors/ai-profile.json): how <c>profile/ai.json</c> is read, and the files the Setup Studio (tools/setup-studio/lib/aiprofile.mjs) writes for a few customers.
    /// The Studio's own tests read the same file, so what the Studio writes is never something this program drops, and the two cannot drift apart.
    /// </summary>
    public sealed class AiProfileVectorTests
    {
        private static readonly JsonNode Vectors = JsonNode.Parse(File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "ai-profile.json")));

        public static IEnumerable<object[]> ReadCases() => Vectors["read"].AsArray().Select((c, i) => new object[] { i, c["name"].GetValue<string>() });

        public static IEnumerable<object[]> BuildCases() => Vectors["build"].AsArray().Select((c, i) => new object[] { i, c["name"].GetValue<string>() });

        /// <summary>The profile in the one plain form the cases use: what the program ends up with.</summary>
        private static JsonNode Plain(ShopProfile p)
        {
            var models = new JsonArray();
            for (var i = 0; i < ShopProfile.ModelPhotos; i++)
            {
                var m = p.ModelAt(i);
                models.Add(new JsonObject { ["title"] = m.Title, ["looks"] = m.Looks });
            }

            var festivals = new JsonArray();
            foreach (var f in p.Festivals)
            {
                festivals.Add(f);
            }

            var lines = new JsonObject();
            foreach (var kind in ShopProfile.PosterLineKinds.Where(k => p.PosterLines.ContainsKey(k)))
            {
                lines[kind] = p.PosterLines[kind];
            }

            return new JsonObject
            {
                ["countryName"] = p.CountryName,
                ["shopKind"] = p.ShopKind,
                ["models"] = models,
                ["festivals"] = festivals,
                ["localLanguage"] = p.HasLocalLanguage ? new JsonObject { ["name"] = p.LocalLanguage, ["tag"] = p.LocalLanguageTag } : null,
                ["posterLines"] = lines,
            };
        }

        private static string[] Words(JsonNode list) => list.AsArray().Select(x => x.GetValue<string>()).ToArray();

        private static JsonNode BuildCase(string name) => Vectors["build"].AsArray().Single(c => c["name"].GetValue<string>() == name);

        /// <summary>The program's reading of the file the Studio writes for the named case (it must read all of it).</summary>
        private static ShopProfile Written(string name)
        {
            var problems = new List<string>();
            var shop = ShopProfile.Parse(BuildCase(name)["expect"]["file"].ToJsonString(), problems);
            Assert.Empty(problems);
            return shop;
        }

        [Fact]
        public void The_cases_are_there_and_are_many_enough_to_mean_something()
        {
            Assert.True(Vectors["read"].AsArray().Count >= 40);
            Assert.True(Vectors["build"].AsArray().Count >= 12);
        }

        [Theory]
        [MemberData(nameof(ReadCases))]
        public void A_file_is_read_the_way_the_cases_say_what_is_usable_is_kept_and_the_rest_is_left_out_with_a_word(int index, string name)
        {
            var c = Vectors["read"][index];
            var text = c["raw"] is JsonNode raw ? raw.GetValue<string>() : c["input"].ToJsonString();
            var problems = new List<string>();
            var shop = ShopProfile.Parse(text, problems);
            var expect = c["expect"];
            Assert.True(JsonNode.DeepEquals(expect["value"], Plain(shop)), $"{name}\nexpected: {expect["value"].ToJsonString()}\nread:     {Plain(shop).ToJsonString()}");
            Assert.Equal(Words(expect["problems"]), problems.ToArray());
        }

        [Theory]
        [MemberData(nameof(BuildCases))]
        public void What_the_studio_writes_is_read_whole_and_the_pictures_follow_it(int index, string name)
        {
            var c = Vectors["build"][index];
            var problems = new List<string>();
            var shop = ShopProfile.Parse(c["expect"]["file"].ToJsonString(), problems);
            Assert.True(problems.Count == 0, $"{name}: the program leaves out a part of what the Studio wrote: {string.Join(" | ", problems)}");
            var expected = c["expect"]["read"];
            Assert.True(JsonNode.DeepEquals(expected, Plain(shop)), $"{name}\nexpected: {expected.ToJsonString()}\nread:     {Plain(shop).ToJsonString()}");

            // the photos with a person are titled and described as the file says
            var seen = new ProductUnderstanding();
            foreach (var kind in new[] { PhotoKind.EuropeanModel, PhotoKind.IndianModel, PhotoKind.EastAsianModel })
            {
                var model = expected["models"][kind.ModelIndex()];
                Assert.Equal(model["title"].GetValue<string>(), kind.Title(shop));
                var looks = model["looks"].GetValue<string>();
                var instructions = ProductPhotoPrompt.ImageInstructions(kind, seen, null, shop);
                Assert.Equal(looks.Length > 0, instructions.Contains(" (" + looks + "), using or holding"));
            }

            // the business is named as the file says
            var country = expected["countryName"].GetValue<string>();
            Assert.Equal(expected["shopKind"].GetValue<string>() + (country.Length > 0 ? " in " + country : ""), shop.Shop);
            Assert.Equal(Words(expected["festivals"]), shop.Festivals.ToArray());
            Assert.Equal(expected["localLanguage"] != null, shop.HasLocalLanguage);
        }

        [Fact]
        public void Changing_one_setting_changes_what_the_program_does_and_only_that()
        {
            var packsOnly = Written("nothing typed: only what the country pack and the industry pack say");

            // the country and the kind of business
            var named = Written("the country and the business named by hand");
            Assert.Equal("a retail shop in Philippines", packsOnly.Shop);
            Assert.Equal("a small shop in the Philippines", named.Shop);
            Assert.NotEqual(packsOnly.TypicalPlace, named.TypicalPlace);
            Assert.Equal("a restaurant or café in Japan", Written("another country and another trade").Shop);

            // who the model photos show
            var models = Written("all three model photos");
            Assert.Equal("Model 2", packsOnly.ModelAt(1).Title);
            Assert.Equal("Chinese-Filipino model", models.ModelAt(1).Title);
            var seen = new ProductUnderstanding();
            Assert.NotEqual(ProductPhotoPrompt.ImageInstructions(PhotoKind.IndianModel, seen, null, packsOnly), ProductPhotoPrompt.ImageInstructions(PhotoKind.IndianModel, seen, null, models));
            Assert.Equal(packsOnly.Shop, models.Shop);
            Assert.Empty(models.Festivals);
            Assert.False(models.HasLocalLanguage);

            // the festivals
            var festivals = Written("festivals: a repeat in other letters is one");
            Assert.Empty(packsOnly.Festivals);
            Assert.Equal(new[] { "Christmas", "Sinulog", "Valentine's Day" }, festivals.Festivals);
            Assert.Equal("Model 2", festivals.ModelAt(1).Title);

            // the second language and its ready-made lines
            var language = Written("a second language with its name and tag");
            var lines = Written("a second language with ready-made lines");
            Assert.False(packsOnly.HasLocalLanguage);
            Assert.Equal(("Filipino", "fil"), (language.LocalLanguage, language.LocalLanguageTag));
            Assert.Empty(language.PosterLines);
            Assert.Equal("भारी छूट · सीमित स्टॉक", lines.PosterLines["clearance"]);
            Assert.Equal(2, lines.PosterLines.Count);
            Assert.NotEqual(ProductPhotoPrompt.SchemaFor(packsOnly), ProductPhotoPrompt.SchemaFor(language));
            Assert.Contains("Filipino", ProductPhotoPrompt.SchemaFor(language));
        }

        [Fact]
        public void A_file_that_asks_for_nothing_makes_the_pictures_neutral_and_never_names_a_market()
        {
            var empty = ShopProfile.Parse(Vectors["read"].AsArray().Single(c => c["name"].GetValue<string>() == "only the schema is the neutral profile, and nothing is said")["input"].ToJsonString());
            var seen = new ProductUnderstanding();
            foreach (var kind in PhotoKinds.All)
            {
                var text = ProductPhotoPrompt.ImageInstructions(kind, seen, null, empty);
                foreach (var word in new[] { "India", "Indian", "Hindi", "European", "East Asian", "fair complexion" })
                {
                    Assert.DoesNotContain(word, text);
                }
            }

            Assert.Equal("a small shop", empty.Shop);
            Assert.Empty(empty.Festivals);
            Assert.False(empty.HasLocalLanguage);
        }

        [Fact]
        public void Each_customers_own_profile_in_its_brand_kit_is_read_without_a_problem_and_says_something()
        {
            var folder = Path.Combine(AppContext.BaseDirectory, "brand-kits");
            var files = Directory.Exists(folder) ? Directory.GetFiles(folder, ShopProfile.FileName, SearchOption.AllDirectories) : new string[0];
            Assert.NotEmpty(files);
            foreach (var file in files)
            {
                var problems = new List<string>();
                var shop = ShopProfile.Parse(File.ReadAllText(file, System.Text.Encoding.UTF8), problems);
                Assert.True(problems.Count == 0, file + ": " + string.Join(" | ", problems));
                Assert.True(shop.CountryName.Length > 0 || shop.Festivals.Count > 0 || shop.HasLocalLanguage || shop.Models.Count > 0, file + " says nothing");
                Assert.True(new FileInfo(file).Length < 200 * 1024, file + " is bigger than the program reads");
            }
        }
    }
}
