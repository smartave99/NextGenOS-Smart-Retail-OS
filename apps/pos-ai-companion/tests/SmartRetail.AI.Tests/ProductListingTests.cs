using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Products;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>Listings for Amazon and the shop's website, written by Codex from a product's photos and kept with them.</summary>
    public class ProductListingTests : IDisposable
    {
        internal const string Answer = @"```json
{
  ""display_name"": ""Pink Flip-Top Water Bottle 750 ml, Leak-Proof, BPA-Free Plastic, for School and Office"",
  ""amazon"": {
    ""bullets"": [
      ""Leak-proof lid: the flip-top lid closes tight, so bags stay dry."",
      ""Right size: holds 750 ml, enough water for a school day."",
      ""Easy to carry: light plastic with a handle on the lid."",
      ""Easy to clean: a wide mouth fits a brush."",
      ""Everyday use: for school, office, gym and travel.""
    ],
    ""description"": ""A light pink bottle for every day.\n\nThe flip-top lid opens with one hand.\n\nWash by hand before first use."",
    ""search_terms"": ""pani ki bottle sipper kids bottle"",
    ""brand"": """",
    ""generic_name"": ""Water Bottle"",
    ""colour"": ""Pink"",
    ""material"": ""Plastic"",
    ""size"": ""750 ml"",
    ""item_count"": ""1"",
    ""included"": ""1 bottle with lid"",
    ""product_type"": ""Water bottle""
  },
  ""website"": {
    ""description"": ""A light, leak-proof bottle for school and office.\n\nThe flip-top lid opens with one hand."",
    ""highlights"": [""Leak-proof flip-top lid"", ""Holds 750 ml"", ""Light and easy to carry""],
    ""specifications"": [{ ""key"": ""Material"", ""value"": ""Plastic"" }, { ""key"": ""Capacity"", ""value"": ""750 ml"" }],
    ""tags"": [""water bottle"", ""school bottle"", ""pink bottle""],
    ""category"": ""Home & Kitchen > Bottles""
  }
}
```";

        private const int Bottle = 1193;

        private readonly TempFolder _temp = new TempFolder();
        private readonly FakeCliRunner _runner = new FakeCliRunner();
        private readonly AssistantSettings _settings;
        private readonly ProductPhotoStore _store;
        private DateTime _now = new DateTime(2026, 9, 27, 10, 0, 0);

        public ProductListingTests()
        {
            (_settings, _) = TestSettings.Create();
            _settings.Codex.ExecutablePath = _temp.File("codex-tool");
            _store = new ProductPhotoStore(Path.Combine(_temp.Path, "Product photos"));
        }

        public void Dispose() => _temp.Dispose();

        private CodexCliProvider Codex() => new CodexCliProvider(_runner, () => _settings, Path.Combine(_temp.Path, "runs"));

        private ProductListingRequest Request() => new ProductListingRequest
        {
            ProductId = Bottle,
            Code = "PP-1193",
            Name = "PINK BOTTLE 750ML",
            Category = "GENERAL",
            SetId = "20260927-100000",
            RawPhotos = new List<string> { _temp.File("raw.jpg", "front"), _temp.File("back.webp", "back") },
            CataloguePhoto = _temp.File("white-20260927-100100.png", "white"),
            Understanding = ProductUnderstanding.Parse(ProductPhotoTests.Answer),
        };

        private Func<CliInvocation, CliResult> Writes(string answer = Answer) => call =>
        {
            File.WriteAllText(FakeCliRunner.ArgumentAfter(call, "--output-last-message"), answer);
            return new CliResult { ExitCode = 0, Duration = TimeSpan.FromSeconds(21) };
        };

        [Fact]
        public async Task Codex_writes_the_listing_from_the_photos_read_only_and_without_its_image_tool()
        {
            _settings.Codex.SandboxMode = "workspace-write";
            _settings.Codex.Model = "gpt-6";
            _settings.Codex.ReasoningEffort = "medium";
            string schema = null;
            _runner.Handler = call =>
            {
                schema = File.ReadAllText(FakeCliRunner.ArgumentAfter(call, "--output-schema"));
                return Writes()(call);
            };

            var result = await Codex().WriteProductListingAsync(Request(), CancellationToken.None);

            // One name, for the website and for Amazon.
            Assert.Equal("Pink Flip-Top Water Bottle 750 ml, Leak-Proof, BPA-Free Plastic, for School and Office", result.Listing.DisplayName);
            Assert.Equal(result.Listing.DisplayName, result.Listing.Amazon.Title);
            Assert.Equal(result.Listing.DisplayName, result.Listing.Website.Name);
            Assert.Equal(5, result.Listing.Amazon.Bullets.Count);
            Assert.Equal("Home & Kitchen > Bottles", result.Listing.Website.Category);
            Assert.Equal("Codex CLI (OpenAI)", result.ProviderName);
            Assert.Equal(TimeSpan.FromSeconds(21), result.Duration);
            Assert.True(_runner.Calls.Single().Timeout >= CodexCliProvider.MinimumListingTimeout);

            var call = _runner.Calls.Single();
            // The catalogue photo first, then the phone photos; then flags, so "-" at the end is the prompt.
            Assert.Equal(new[]
            {
                "exec",
                "--image", Path.Combine(call.WorkingDirectory, "catalogue-photo.png"),
                "--image", Path.Combine(call.WorkingDirectory, "photo-1.jpg"),
                "--image", Path.Combine(call.WorkingDirectory, "photo-2.webp"),
            }, call.Arguments.Take(7));
            Assert.Equal("read-only", FakeCliRunner.ArgumentAfter(call, "--sandbox"));
            Assert.Contains("--ephemeral", call.Arguments);
            Assert.DoesNotContain("--enable", call.Arguments);
            Assert.Equal("gpt-6", FakeCliRunner.ArgumentAfter(call, "--model"));
            Assert.Equal("model_reasoning_effort=medium", FakeCliRunner.ArgumentAfter(call, "--config"));
            Assert.Equal("-", call.Arguments.Last());
            Assert.False(Directory.Exists(call.WorkingDirectory), "the working folder is cleaned up");

            var prompt = call.StandardInput;
            Assert.Contains("\"PINK BOTTLE 750ML\" (code PP-1193, category GENERAL)", prompt);
            Assert.Contains("The first attached photo is its catalogue photo", prompt);
            Assert.Contains("- What it is: a pink plastic water bottle with a flip-top lid", prompt);
            Assert.Contains("- Size or quantity: 750 ml", prompt);
            Assert.Contains("Never invent a brand", prompt);
            Assert.Contains("No prices, offers or discounts", prompt);
            Assert.Contains("answer with JSON only", prompt);
            Assert.DoesNotContain("₹", prompt);

            // Codex refuses a schema unless every object lists all its fields as required and allows nothing else.
            AssertStrict(JObject.Parse(schema));
        }

        private static void AssertStrict(JObject schema)
        {
            if ((string)schema["type"] == "object")
            {
                Assert.False((bool)schema["additionalProperties"]);
                var properties = ((JObject)schema["properties"]).Properties().Select(p => p.Name).OrderBy(n => n).ToList();
                Assert.Equal(properties, schema["required"].Select(r => (string)r).OrderBy(n => n));
                foreach (var property in ((JObject)schema["properties"]).Properties())
                {
                    AssertStrict((JObject)property.Value);
                }
            }
            else if ((string)schema["type"] == "array")
            {
                AssertStrict((JObject)schema["items"]);
            }
        }

        [Fact]
        public async Task An_answer_without_a_listing_or_a_codex_not_signed_in_is_a_clear_problem()
        {
            _runner.Handler = Writes("Sorry, I cannot see the product.");
            var empty = await Assert.ThrowsAsync<AiProviderException>(() => Codex().WriteProductListingAsync(Request(), CancellationToken.None));
            Assert.Contains("without a listing", empty.Message);

            _runner.Handler = call => new CliResult { ExitCode = 1, StandardError = "Error: not logged in. Run codex login." };
            var signedOut = await Assert.ThrowsAsync<AiProviderException>(() => Codex().WriteProductListingAsync(Request(), CancellationToken.None));
            Assert.Contains("not signed in", signedOut.Message);

            var noPhotos = Request();
            noPhotos.RawPhotos.Clear();
            noPhotos.CataloguePhoto = null;
            var problem = await Assert.ThrowsAsync<AiProviderException>(() => Codex().WriteProductListingAsync(noPhotos, CancellationToken.None));
            Assert.Contains("Add photos of the product first", problem.Message);
            Assert.Equal(2, _runner.Calls.Count);
        }

        [Fact]
        public void The_answer_is_read_even_when_it_is_not_quite_as_asked()
        {
            var listing = ProductListing.Parse("Here it is:\n{ \"amazon\": { \"title\": \"Steel Tiffin Box\", \"bullets\": \"Keeps food warm\\nThree containers\" }, \"website\": null }");

            // An answer with a title only (the way listings were asked for before there was one name) gives that name to both.
            Assert.Equal("Steel Tiffin Box", listing.DisplayName);
            Assert.Equal("Steel Tiffin Box", listing.Amazon.Title);
            Assert.Equal(new[] { "Keeps food warm", "Three containers" }, listing.Amazon.Bullets);
            Assert.Equal("Steel Tiffin Box", listing.Website.Name);
            Assert.Empty(listing.Website.Tags);
            Assert.Null(ProductListing.Parse("{ \"amazon\": { \"title\": \" \" }, \"website\": { \"name\": \"\" } }"));
            Assert.Null(ProductListing.Parse("not json {"));
            Assert.Null(ProductListing.Parse(null));
        }

        [Fact]
        public void A_title_keeps_to_amazons_rules()
        {
            var notes = new List<string>();

            var title = ListingRules.Title("Milton Pink Bottle 750 ml - Best Seller! Only ₹199 | Free Delivery #1 (20% off)", notes);

            Assert.Equal("Milton Pink Bottle 750 ml", title);
            Assert.Contains(ListingRules.NotePrices, notes);
            Assert.Contains(ListingRules.NoteClaims, notes);
            Assert.Equal("Bottle Water Bottle Steel for School", ListingRules.Title("Bottle Water Bottle Steel Bottle for School Bottle"));
            Assert.Equal("Steel Tiffin, 3 Containers, 3 Layers of Steel", ListingRules.Title("Steel Tiffin, 3 Containers, 3 Layers of Steel"));
            Assert.Equal("Cooker Up to 100°C", ListingRules.Title("Cooker ☕ Up to 100°C"));
            Assert.Equal("Tea 250 g", ListingRules.Title("Tea 250 g – visit www.example.in"));
            var longTitle = ListingRules.Title(string.Join(" ", Enumerable.Range(1, 60).Select(i => "Word" + i)));
            Assert.True(longTitle.Length <= ListingRules.TitleMax);
            Assert.EndsWith("Word" + longTitle.Split(' ').Length, longTitle);
        }

        [Fact]
        public void Bullets_lose_what_amazon_refuses_but_keep_the_rest()
        {
            var notes = new List<string>();

            var bullets = ListingRules.Points(new[]
            {
                "• leak-proof lid: closes tight. Only ₹199 today!",
                "Call 98765 43210 to order.",
                "1. Holds 750 ml of water.",
                "- Holds 750 ml of water.",
                "**Easy to clean**: a wide mouth.",
                "Light: easy to carry.",
                "Strong: food-grade plastic.",
                "Seventh point.",
            }, ListingRules.BulletCount, ListingRules.BulletMax, notes);

            Assert.Equal(new[] { "Leak-proof lid: closes tight.", "Holds 750 ml of water.", "Easy to clean: a wide mouth.", "Light: easy to carry.", "Strong: food-grade plastic." }, bullets);
            Assert.Contains(ListingRules.NotePrices, notes);
            Assert.Contains(ListingRules.NoteContacts, notes);
            Assert.Contains(ListingRules.NoteLength, notes);
            var cut = ListingRules.Points(new[] { string.Join(" ", Enumerable.Repeat("strong", 80)) }, 5, ListingRules.BulletMax);
            Assert.True(cut.Single().Length <= ListingRules.BulletMax);
        }

        [Theory]
        [InlineData("Big pack. Just 499 rupees.")]
        [InlineData("Big pack. Only ₹ 499/-")]
        [InlineData("Big pack. Yours for 1,299/-.")]
        [InlineData("Big pack. Now $10.")]
        [InlineData("Big pack. Rs.499 only.")]
        [InlineData("Big pack. Worth 499 rs. at the shop.")]
        [InlineData("Big pack. केवल 499 रुपये।")]
        [InlineData("Big pack. Pay in rupees.")]
        [InlineData("Big pack. Costs INR 450.")]
        [InlineData("Big pack. Save 20 % off.")]
        [InlineData("Big pack. MRP: 175.")]
        public void A_price_however_it_is_written_is_taken_out(string bullet)
        {
            var notes = new List<string>();

            Assert.Equal(new[] { "Big pack." }, ListingRules.Points(new[] { bullet }, ListingRules.BulletCount, ListingRules.BulletMax, notes));
            Assert.Contains(ListingRules.NotePrices, notes);
        }

        [Fact]
        public void Figures_that_are_not_prices_stay()
        {
            var notes = new List<string>();
            var point = "Holds 750 ml, a pack of 2, up to 100°C, for 24/7 use, 100% cotton cover, 5 L in all.";

            Assert.Equal(new[] { point }, ListingRules.Points(new[] { point }, ListingRules.BulletCount, ListingRules.BulletMax, notes));
            Assert.Empty(notes);
            Assert.Equal("Tea 500 g", ListingRules.Title("Tea 500 g - Rs 199 only"));
            Assert.Equal("Tea 500 g", ListingRules.Title("Tea 500 g 199/-"));
            Assert.Equal("Tea 500 g", ListingRules.Title("Tea 500 g, 5 dollars"));
        }

        [Fact]
        public void A_description_is_plain_paragraphs_within_the_limit()
        {
            var text = ListingRules.Paragraphs("## About\n<b>Light</b> and **strong**.\nFits bags.\n\nWrite to shop@example.com for more. Wash by hand.\n\n\n", 2000);

            Assert.Equal("About Light and strong. Fits bags.\n\nWash by hand.", text);
            var cut = ListingRules.Paragraphs(string.Join(" ", Enumerable.Repeat("A light bottle for school.", 120)), 2000);
            Assert.True(cut.Length <= 2000);
            Assert.EndsWith("school.", cut);
        }

        [Fact]
        public void Search_terms_are_new_words_within_amazons_byte_limit()
        {
            var notes = new List<string>();

            Assert.Equal("pani ki sipper kids", ListingRules.SearchTerms("Pani ki BOTTLE, sipper; kids bottle best cheap", "Pink Water Bottle 750 ml"));
            var hindi = ListingRules.SearchTerms(string.Join(" ", Enumerable.Range(1, 60).Select(i => "बोतल" + i)), "Bottle", notes);
            Assert.True(Encoding.UTF8.GetByteCount(hindi) <= ListingRules.SearchTermsMaxBytes);
            Assert.Contains(ListingRules.NoteLength, notes);
        }

        [Fact]
        public void The_whole_listing_is_checked_and_checking_again_changes_nothing()
        {
            var listing = ProductListing.Parse(Answer);
            listing.Amazon.Brand = "Call 9876543210";
            listing.Website.Tags = new List<string> { "#Water Bottle", "water bottle", "sale", "Kids" };
            listing.Website.Specifications.Add(new ListingSpec { Key = "material", Value = "Steel" });
            listing.Website.Specifications.Add(new ListingSpec { Key = "Lid", Value = " " });
            listing.Website.Category = "Home & Kitchen>Bottles";

            var check = ListingRules.Clean(listing);

            var clean = check.Listing;
            Assert.Equal("", clean.Amazon.Brand);
            Assert.Equal("pani ki sipper kids", clean.Amazon.SearchTerms);
            Assert.Equal(new[] { "water bottle", "kids" }, clean.Website.Tags);
            Assert.Equal(new[] { "Material: Plastic", "Capacity: 750 ml" }, clean.Website.Specifications.Select(s => s.Key + ": " + s.Value));
            Assert.Equal("Home & Kitchen > Bottles", clean.Website.Category);
            Assert.Contains(ListingRules.NoteContacts, check.Notes);
            Assert.Equal(check.Notes, clean.Notes);

            var again = ListingRules.Clean(clean);
            Assert.Empty(again.Notes);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(clean.Amazon), Newtonsoft.Json.JsonConvert.SerializeObject(again.Listing.Amazon));
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(clean.Website), Newtonsoft.Json.JsonConvert.SerializeObject(again.Listing.Website));
            Assert.Empty(ListingRules.Clean(ProductListing.Parse(Answer)).Notes);
        }

        private string StartSet()
        {
            string raw;
            using (var photo = new MemoryStream(Encoding.UTF8.GetBytes("front")))
            {
                raw = _store.SaveRaw(Bottle, photo, ".jpg", _now, "Pink Bottle 750 ml");
            }

            return _store.StartSet(Bottle, "PP-1193", "Pink Bottle 750 ml", "GENERAL", new[] { raw }, _now).Id;
        }

        [Fact]
        public void The_website_and_amazon_show_one_name_held_to_amazons_rules_and_kept_short()
        {
            var listing = ProductListing.Parse(Answer);
            listing.DisplayName = "Fortune Sunflower Oil 1 L Bottle - Best Seller! Only ₹155";

            var check = ListingRules.Clean(listing);

            Assert.Equal("Fortune Sunflower Oil 1 L Bottle", check.Listing.DisplayName);
            Assert.Equal(check.Listing.DisplayName, check.Listing.Amazon.Title);
            Assert.Equal(check.Listing.DisplayName, check.Listing.Website.Name);
            Assert.Contains(ListingRules.NotePrices, check.Notes);
            Assert.Contains(ListingRules.NoteClaims, check.Notes);

            var cut = ListingRules.DisplayName(string.Join(" ", Enumerable.Range(1, 60).Select(i => "Word" + i)));
            Assert.True(cut.Length <= ListingRules.DisplayNameMax && cut.Length > ListingRules.DisplayNameMax / 2, cut.Length.ToString());

            // Search terms never repeat the name's words, whichever side edited it.
            Assert.DoesNotContain("sunflower", check.Listing.Amazon.SearchTerms);
        }

        [Fact]
        public void A_listing_kept_when_the_website_and_amazon_had_a_name_each_gets_one_name_when_it_is_read()
        {
            StartSet();
            _store.SaveListing(Bottle, ProductListing.Parse(Answer), _now);

            // The file as an earlier version kept it: no display name, a title for Amazon and another name for the website.
            var file = Directory.GetFiles(_store.Root, "product.json", SearchOption.AllDirectories).Single();
            var json = JObject.Parse(File.ReadAllText(file));
            ((JObject)json["Listing"]).Remove("DisplayName");
            json["Listing"]["Amazon"]["Title"] = "Pink Flip-Top Water Bottle 750 ml, Leak-Proof, for School and Office";
            json["Listing"]["Website"]["Name"] = "Pink Flip-Top Water Bottle, 750 ml";
            File.WriteAllText(file, json.ToString());

            var listing = _store.Load(Bottle).Listing;

            Assert.Equal("Pink Flip-Top Water Bottle, 750 ml", listing.DisplayName);
            Assert.Equal("Pink Flip-Top Water Bottle, 750 ml", listing.Amazon.Title);
            Assert.Equal("Pink Flip-Top Water Bottle, 750 ml", listing.Website.Name);

            // An answer that has only the website's name, or only Amazon's title, gives that name to both.
            Assert.Equal("Steel Box", ProductListing.Parse("{ \"amazon\": {}, \"website\": { \"name\": \"Steel Box\" } }").Amazon.Title);
            Assert.Equal("Steel Box 2", ProductListing.Parse("{ \"display_name\": \"Steel Box 2\", \"amazon\": { \"title\": \"Other\" }, \"website\": { \"name\": \"Another\" } }").Website.Name);
        }

        [Fact]
        public void The_owner_changes_the_one_name_and_the_pos_name_is_left_alone()
        {
            StartSet();
            _store.SaveListing(Bottle, ProductListing.Parse(Answer), _now);
            var edited = _store.Load(Bottle).Listing.Copy();
            edited.DisplayName = "Milton Pink Bottle 750 ml";

            _store.EditListing(Bottle, edited, _now.AddHours(1));

            var info = _store.Load(Bottle);
            Assert.Equal("Milton Pink Bottle 750 ml", info.Listing.DisplayName);
            Assert.Equal("Milton Pink Bottle 750 ml", info.Listing.Amazon.Title);
            Assert.Equal("Milton Pink Bottle 750 ml", info.Listing.Website.Name);
            Assert.Equal("Pink Bottle 750 ml", info.Name);
        }

        [Fact]
        public void The_prompt_asks_for_one_name_and_says_the_billing_name_is_not_for_customers()
        {
            var prompt = ProductListingPrompt.CodexPrompt(Request());

            Assert.Contains("display_name", prompt);
            Assert.Contains("billing system", prompt);
            Assert.DoesNotContain("a title of at most 150", prompt);
            var schema = JObject.Parse(ProductListingPrompt.Schema);
            Assert.Contains("display_name", schema["required"].Select(r => (string)r));
            Assert.DoesNotContain("title", ((JObject)schema["properties"]["amazon"]["properties"]).Properties().Select(p => p.Name));
            Assert.DoesNotContain("name", ((JObject)schema["properties"]["website"]["properties"]).Properties().Select(p => p.Name));
        }

        [Fact]
        public void The_store_keeps_the_listing_checked_with_earlier_ones_to_go_back_to()
        {
            Assert.False(_store.QueueListing(Bottle), "a product without photos has nothing to write from");
            var set = StartSet();
            Assert.True(_store.QueueListing(Bottle));
            Assert.True(_store.Load(Bottle).ListingPending);

            var first = ProductListing.Parse(Answer);
            first.Amazon.Bullets[0] = "Leak-proof lid: closes tight. Now at ₹199 only.";
            first.Provider = "Codex CLI (OpenAI)";
            first.SetId = set;
            _store.SaveListing(Bottle, first, _now);

            var info = _store.Load(Bottle);
            Assert.False(info.ListingPending);
            Assert.Equal("Leak-proof lid: closes tight.", info.Listing.Amazon.Bullets[0]);
            Assert.Equal(new[] { ListingRules.NotePrices }, info.Listing.Notes);
            Assert.Equal(_now, info.Listing.Written);
            Assert.Equal(set, info.Listing.SetId);
            Assert.Null(info.Listing.Edited);
            Assert.Empty(info.EarlierListings);

            var edited = info.Listing.Copy();
            edited.Amazon.Brand = "Milton";
            _now = _now.AddHours(1);
            _store.EditListing(Bottle, edited, _now);
            info = _store.Load(Bottle);
            Assert.Equal("Milton", info.Listing.Amazon.Brand);
            Assert.Equal(_now, info.Listing.Edited);
            Assert.Equal("", Assert.Single(info.EarlierListings).Amazon.Brand);

            _store.RestoreListing(Bottle, 0);
            info = _store.Load(Bottle);
            Assert.Equal("", info.Listing.Amazon.Brand);
            Assert.Equal("Milton", Assert.Single(info.EarlierListings).Amazon.Brand);
            Assert.Null(_store.RestoreListing(Bottle, 5));

            for (var i = 0; i < 8; i++)
            {
                _store.SaveListing(Bottle, ProductListing.Parse(Answer), _now);
            }

            Assert.Equal(ProductPhotoStore.EarlierListingsKept, _store.Load(Bottle).EarlierListings.Count);

            _store.StopListing(Bottle, "Codex is not signed in.");
            info = _store.Load(Bottle);
            Assert.False(info.ListingPending);
            Assert.Equal("Codex is not signed in.", info.ListingProblem);
            Assert.NotNull(info.Listing);
        }

        private readonly List<string> _work = new List<string>();

        private ProductPhotoMaker Maker(
            Func<ProductListingRequest, CancellationToken, Task> beforeListing = null,
            Func<ProductPhotoRequest, CancellationToken, Task> beforePhoto = null,
            bool writesListings = true)
        {
            Func<ProductListingRequest, CancellationToken, Task<ProductListingResult>> write = async (request, ct) =>
            {
                _work.Add("listing");
                if (beforeListing != null)
                {
                    await beforeListing(request, ct);
                }

                return new ProductListingResult { Listing = ProductListing.Parse(Answer), ProviderName = "Codex CLI (OpenAI)" };
            };
            return new ProductPhotoMaker(_store, async (request, ct) =>
            {
                _work.Add(request.Kind.FilePrefix());
                if (beforePhoto != null)
                {
                    await beforePhoto(request, ct);
                }

                _now = _now.AddMinutes(1);
                return new ProductPhotoResult
                {
                    Image = ProductPhotoTests.Png,
                    Understanding = request.Describe ? ProductUnderstanding.Parse(ProductPhotoTests.Answer) : null,
                    ProviderName = "Codex CLI (OpenAI)",
                };
            }, () => _now, writesListings ? write : null);
        }

        private string Raw(string content = "raw")
        {
            using (var photo = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                return _store.SaveRaw(Bottle, photo, ".jpg", _now, "Pink Bottle 750 ml");
            }
        }

        [Fact]
        public async Task The_listing_is_written_right_after_the_white_photo_from_it_and_what_the_ai_saw()
        {
            ProductListingRequest asked = null;
            PhotoWork during = null;
            ProductPhotoMaker maker = null;
            maker = Maker(beforeListing: (request, ct) =>
            {
                asked = request;
                during = maker.Current;
                return Task.CompletedTask;
            });
            var set = maker.Start(Bottle, "PP-1193", "Pink Bottle 750 ml", "GENERAL", new[] { Raw() });

            await maker.MakeNextAsync(CancellationToken.None);

            Assert.Equal(new[] { "white", "listing", "in-use", "european-model", "indian-model", "east-asian-model" }, _work);
            Assert.True(during.IsListing);
            var info = _store.Load(Bottle);
            Assert.Equal(_store.PathOf(Bottle, info.LatestSet.Latest(PhotoKind.WhiteBackground).File), asked.CataloguePhoto);
            Assert.Equal("a pink plastic water bottle with a flip-top lid", asked.Understanding.WhatItIs);
            Assert.Equal(set.Id, asked.SetId);
            Assert.Equal(set.Id, info.Listing.SetId);
            Assert.Equal("Codex CLI (OpenAI)", info.Listing.Provider);
            Assert.False(info.ListingPending);
            Assert.True(maker.IsIdle);

            // New photos keep the listing: it is written again only when asked.
            _work.Clear();
            maker.Start(Bottle, "PP-1193", "Pink Bottle 750 ml", "GENERAL", new[] { Raw("closer") });
            await maker.MakeNextAsync(CancellationToken.None);
            Assert.DoesNotContain("listing", _work);

            _work.Clear();
            maker.WriteListing(Bottle);
            await maker.MakeNextAsync(CancellationToken.None);
            Assert.Equal(new[] { "listing" }, _work);
            Assert.Single(_store.Load(Bottle).EarlierListings);
        }

        [Fact]
        public async Task A_listing_that_fails_waits_for_write_again_and_the_photos_carry_on()
        {
            var refuse = true;
            var maker = Maker(beforeListing: (request, ct) => refuse ? throw new AiProviderException("codex-cli", "Codex is not signed in.") : Task.CompletedTask);
            maker.Start(Bottle, "PP-1193", "Pink Bottle", "", new[] { Raw() });

            await maker.MakeNextAsync(CancellationToken.None);

            var info = _store.Load(Bottle);
            Assert.Equal(5, info.LatestSet.MadeCount);
            Assert.Null(info.LatestSet.Problem);
            Assert.Null(info.Listing);
            Assert.False(info.ListingPending);
            Assert.Equal("Codex is not signed in.", info.ListingProblem);
            Assert.Empty(_store.Resumable());

            refuse = false;
            maker.WriteListing(Bottle);
            await maker.MakeNextAsync(CancellationToken.None);
            info = _store.Load(Bottle);
            Assert.NotNull(info.Listing);
            Assert.Null(info.ListingProblem);
        }

        [Fact]
        public async Task Stop_while_the_listing_is_written_stops_it_and_the_photos()
        {
            ProductPhotoMaker maker = null;
            maker = Maker(beforeListing: async (request, ct) =>
            {
                maker.Stop(Bottle);
                await Task.Delay(Timeout.Infinite, ct);
            });
            maker.Start(Bottle, "PP-1193", "Pink Bottle", "", new[] { Raw() });

            await maker.MakeNextAsync(CancellationToken.None);

            var info = _store.Load(Bottle);
            Assert.Equal("Stopped.", info.ListingProblem);
            Assert.Equal("Stopped.", info.LatestSet.Problem);
            Assert.Equal(1, info.LatestSet.MadeCount);
            Assert.True(maker.IsIdle);
        }

        [Fact]
        public async Task Stop_holds_a_listing_asked_for_during_a_photo_and_continue_carries_on_with_both()
        {
            ProductPhotoMaker maker = null;
            var stopped = false;
            maker = Maker(beforePhoto: async (request, ct) =>
            {
                if (request.Kind == PhotoKind.EuropeanModel && !stopped)
                {
                    stopped = true;
                    maker.WriteListing(Bottle);
                    maker.Stop(Bottle);
                    await Task.Delay(Timeout.Infinite, ct);
                }
            });
            maker.Start(Bottle, "PP-1193", "Pink Bottle", "", new[] { Raw() });

            await maker.MakeNextAsync(CancellationToken.None);

            Assert.Equal(new[] { "white", "listing", "in-use", "european-model" }, _work);
            var info = _store.Load(Bottle);
            Assert.Equal("Stopped.", info.LatestSet.Problem);
            Assert.Equal("Stopped.", info.ListingProblem);
            Assert.False(info.ListingPending);
            Assert.Empty(_store.Resumable());

            _work.Clear();
            maker.Continue(Bottle);
            await maker.MakeNextAsync(CancellationToken.None);
            Assert.Equal(new[] { "listing", "european-model", "indian-model", "east-asian-model" }, _work);
            info = _store.Load(Bottle);
            Assert.Null(info.ListingProblem);
            Assert.Equal(5, info.LatestSet.MadeCount);
            Assert.Single(info.EarlierListings);
        }

        [Fact]
        public async Task A_listing_left_when_the_app_closed_is_written_after_the_next_start()
        {
            using (var closing = new CancellationTokenSource())
            {
                var first = Maker(beforeListing: (request, ct) =>
                {
                    closing.Cancel();
                    ct.ThrowIfCancellationRequested();
                    return Task.CompletedTask;
                });
                first.Start(Bottle, "PP-1193", "Pink Bottle", "", new[] { Raw() });
                await Assert.ThrowsAnyAsync<OperationCanceledException>(() => first.MakeNextAsync(closing.Token));
            }

            Assert.True(_store.Load(Bottle).ListingPending);
            Assert.Equal(new[] { Bottle }, _store.Resumable());

            _work.Clear();
            var next = Maker();
            next.ResumeAll();
            await next.MakeNextAsync(CancellationToken.None);

            Assert.Equal(new[] { "listing", "in-use", "european-model", "indian-model", "east-asian-model" }, _work);
            Assert.NotNull(_store.Load(Bottle).Listing);
        }

        [Fact]
        public async Task Without_a_writer_no_listing_is_asked_for()
        {
            var maker = Maker(writesListings: false);
            maker.Start(Bottle, "PP-1193", "Pink Bottle", "", new[] { Raw() });
            maker.WriteListing(Bottle);

            await maker.MakeNextAsync(CancellationToken.None);

            Assert.DoesNotContain("listing", _work);
            Assert.False(_store.Load(Bottle).ListingPending);
            Assert.False(maker.WritesListings);
        }

        [Fact]
        public async Task A_listing_asked_for_while_the_white_photo_waits_comes_after_it()
        {
            // The white photo was stopped: the listing waits for it, even after a restart.
            var maker = Maker(beforePhoto: (request, ct) => throw new AiProviderException("codex-cli", "Codex is not signed in."));
            maker.Start(Bottle, "PP-1193", "Pink Bottle", "", new[] { Raw() });
            await maker.MakeNextAsync(CancellationToken.None);

            Assert.True(_store.Load(Bottle).ListingPending);
            Assert.Empty(_store.Resumable());
            Assert.Equal(new[] { "white" }, _work);

            _work.Clear();
            var next = Maker();
            next.Continue(Bottle);
            await next.MakeNextAsync(CancellationToken.None);
            Assert.Equal(new[] { "white", "listing", "in-use", "european-model", "indian-model", "east-asian-model" }, _work);
        }
    }
}
