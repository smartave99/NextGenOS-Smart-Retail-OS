using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Creatives;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    public class CreativeArtTests : IDisposable
    {
        private readonly TempFolder _temp = new TempFolder();
        private readonly FakeCliRunner _runner = new FakeCliRunner();
        private readonly AssistantSettings _settings;

        public CreativeArtTests()
        {
            (_settings, _) = TestSettings.Create();
            _settings.Codex.ExecutablePath = _temp.File("codex-tool");
        }

        public void Dispose() => _temp.Dispose();

        private CodexCliProvider Codex() =>
            new CodexCliProvider(_runner, () => _settings, Path.Combine(_temp.Path, "runs")) { CodexHome = Path.Combine(_temp.Path, "codex-home") };

        private CreativeArtRequest Diwali() => new CreativeArtRequest
        {
            FormatName = "Square post",
            FormatUse = "Instagram, Facebook and WhatsApp posts",
            Width = 1080,
            Height = 1080,
            Style = "Festive: rich colours, marigolds and warm lights",
            ShopName = "Sharma General Store",
            BrandColours = new List<string> { "#E4572E", "#FFC914", "red" },
            BrandNotes = "Friendly and family-run",
            Logo = _temp.File("logo.PNG", "logo"),
            Headline = "Diwali Dhamaka",
            Subtitle = "Fresh stock for the festival",
            CallToAction = "Visit us today",
            SmallPrint = "While stocks last",
            Background = "A warm evening glow with diyas",
            Instructions = "Keep it simple, 2 products side by side",
            Products = new List<CreativeArtProduct>
            {
                new CreativeArtProduct { Name = "Sunflower Oil 1 L", WhatItIs = "a 1 litre bottle of golden oil with a yellow cap", Photo = _temp.File("white-1.png", "oil"), HasPrice = true },
                new CreativeArtProduct { Name = "Basmati Rice 5 kg", Photo = _temp.File("raw-1.jpeg", "rice"), HasPrice = true },
            },
            References = new List<string> { _temp.File("look.webp", "look") },
        };

        private static string Answer(string priceAreas) =>
            "{\"image\":\"creative.png\",\"price_areas\":" + priceAreas + ",\"notes\":\"A festive square post with both products.\"}";

        [Fact]
        public async Task Codex_designs_a_creative_from_copies_of_the_photos_and_says_where_the_prices_go()
        {
            string[] filesAtStart = null;
            _runner.Handler = call =>
            {
                filesAtStart = Directory.GetFiles(call.WorkingDirectory).Select(Path.GetFileName).OrderBy(n => n, StringComparer.Ordinal).ToArray();
                File.WriteAllBytes(Path.Combine(call.WorkingDirectory, CreativeArtPrompt.ResultFileName), ProductPhotoTests.Png);
                File.WriteAllText(FakeCliRunner.ArgumentAfter(call, "--output-last-message"),
                    Answer("[{\"x\":0.6,\"y\":0.7,\"width\":0.3,\"height\":0.12},{\"x\":0.05,\"y\":0.72,\"width\":0.3,\"height\":0.12}]"));
                return new CliResult { ExitCode = 0, Duration = TimeSpan.FromSeconds(95) };
            };
            var messages = new List<string>();

            var result = await Codex().MakeCreativeAsync(Diwali(), new ListProgress(messages), CancellationToken.None);

            Assert.Equal(ProductPhotoTests.Png, result.Image);
            Assert.Equal(2, result.PriceAreas.Count);
            Assert.Equal((0.6, 0.7, 0.3, 0.12), (result.PriceAreas[0].X, result.PriceAreas[0].Y, result.PriceAreas[0].Width, result.PriceAreas[0].Height));
            Assert.Equal("A festive square post with both products.", result.Notes);
            Assert.Equal("Codex CLI (OpenAI)", result.ProviderName);
            Assert.Equal(TimeSpan.FromSeconds(95), result.Duration);
            Assert.Contains("designing the creative", Assert.Single(messages));

            // Only copies of the pictures, under plain names, and the answer's schema.
            Assert.Equal(new[] { CodexCliProvider.CreativeSchemaFile, "logo.png", "product-1.png", "product-2.jpg", "reference-1.webp" }, filesAtStart);
            var call = _runner.Calls.Single();
            Assert.Equal("exec", call.Arguments[0]);
            var images = call.Arguments.Select((argument, i) => (argument, i)).Where(a => a.argument == "--image").Select(a => Path.GetFileName(call.Arguments[a.i + 1])).ToList();
            Assert.Equal(new[] { "product-1.png", "product-2.jpg", "logo.png", "reference-1.webp" }, images);
            Assert.Equal("--skip-git-repo-check", call.Arguments[1 + 2 * images.Count]);
            Assert.Equal("image_generation", FakeCliRunner.ArgumentAfter(call, "--enable"));
            Assert.Equal("workspace-write", FakeCliRunner.ArgumentAfter(call, "--sandbox"));
            Assert.EndsWith(CodexCliProvider.CreativeSchemaFile, FakeCliRunner.ArgumentAfter(call, "--output-schema"));
            Assert.Equal("-", call.Arguments.Last());
            Assert.True(call.Timeout >= CodexCliProvider.MinimumCreativeTimeout);
            Assert.Equal(call.StandardInput, result.Prompt);
            Assert.False(Directory.Exists(call.WorkingDirectory), "the working folder is cleaned up");

            var prompt = call.StandardInput;
            Assert.Contains("a small shop, Sharma General Store.", prompt);
            Assert.Contains("- Format: Square post, for Instagram, Facebook and WhatsApp posts, 1080 x 1080 pixels. Make the image 1024 x 1024 (square)", prompt);
            Assert.Contains("- Style: Festive: rich colours, marigolds and warm lights.", prompt);
            Assert.Contains("its colours are #E4572E and #FFC914; Friendly and family-run; its logo is logo.png: show it small and clear, exactly as it is.", prompt);
            Assert.Contains("  1. Sunflower Oil 1 L (a 1 litre bottle of golden oil with a yellow cap): photo product-1.png.", prompt);
            Assert.Contains("  2. Basmati Rice 5 kg: photo product-2.jpg.", prompt);
            Assert.Contains("  Headline: \"Diwali Dhamaka\"\n  Line under it: \"Fresh stock for the festival\"\n  What to do: \"Visit us today\"\n  Small print: \"While stocks last\"\n  Shop's name: \"Sharma General Store\"", prompt);
            Assert.Contains("Strictly no numbers, prices, currency signs such as ₹, percent signs", prompt);
            Assert.Contains("except what is printed on the products' own packaging. No watermark or signature.", prompt);
            Assert.DoesNotContain("part of the shop's name", prompt);
            Assert.Contains("The shop adds 2 price tags, one for each product in order, itself. Leave a clear, calm, empty place for each", prompt);
            Assert.Contains("- Background: A warm evening glow with diyas.", prompt);
            Assert.Contains("from reference-1.webp.", prompt);
            Assert.Contains("- The owner also asks: Keep it simple, 2 products side by side.", prompt);
            Assert.Contains("Save the picture as creative.png", prompt);
            Assert.DoesNotContain("red", prompt.Substring(prompt.IndexOf("its colours", StringComparison.Ordinal), 40));
        }

        [Fact]
        public async Task A_change_works_on_the_picture_made_before()
        {
            var request = Diwali();
            request.Previous = _temp.File("result.png", "before");
            request.Change = "Make the \"background\" deep blue";
            _runner.Handler = call =>
            {
                Assert.True(File.Exists(Path.Combine(call.WorkingDirectory, "previous.png")));
                File.WriteAllBytes(Path.Combine(call.WorkingDirectory, CreativeArtPrompt.ResultFileName), ProductPhotoTests.Png);
                return new CliResult { ExitCode = 0 };
            };
            var messages = new List<string>();

            var result = await Codex().MakeCreativeAsync(request, new ListProgress(messages), CancellationToken.None);

            var call = _runner.Calls.Single();
            Assert.Equal("previous.png", Path.GetFileName(FakeCliRunner.ArgumentAfter(call, "--image")));
            Assert.Contains("You made the picture previous.png before. Make it again with your image generation tool, keeping everything the same except this change the owner asks for: \"Make the 'background' deep blue\".", call.StandardInput);
            Assert.Contains("The brief it was made from, which still holds:", call.StandardInput);
            Assert.Contains("changing the creative", Assert.Single(messages));
            Assert.Empty(result.PriceAreas);
        }

        [Fact]
        public async Task The_picture_is_the_one_made_not_one_given()
        {
            var request = Diwali();
            request.Previous = _temp.File("result.png", "before");
            request.Change = "Brighter";
            _runner.Handler = call => new CliResult { ExitCode = 0 };

            var error = await Assert.ThrowsAsync<AiProviderException>(() => Codex().MakeCreativeAsync(request, null, CancellationToken.None));

            Assert.Contains("made no picture", error.Message);
        }

        [Fact]
        public async Task A_photo_given_for_two_products_is_copied_once()
        {
            var request = Diwali();
            request.Products[1].Photo = request.Products[0].Photo;
            request.Logo = null;
            request.References.Clear();
            string[] filesAtStart = null;
            _runner.Handler = call =>
            {
                filesAtStart = Directory.GetFiles(call.WorkingDirectory).Select(Path.GetFileName).Where(n => n.EndsWith(".png", StringComparison.Ordinal)).ToArray();
                File.WriteAllBytes(Path.Combine(call.WorkingDirectory, CreativeArtPrompt.ResultFileName), ProductPhotoTests.Png);
                return new CliResult { ExitCode = 0 };
            };

            await Codex().MakeCreativeAsync(request, null, CancellationToken.None);

            Assert.Equal(new[] { "product-1.png" }, filesAtStart);
            var prompt = _runner.Calls.Single().StandardInput;
            Assert.Contains("  2. Basmati Rice 5 kg: photo product-1.png.", prompt);
            Assert.DoesNotContain("logo", prompt);
        }

        [Theory]
        [InlineData("Diwali sale 50% off", "The headline")]
        [InlineData("Only ₹99", "The headline")]
        [InlineData("Rs. ninety nine", "The headline")]
        [InlineData("दिवाली सेल ५०", "The headline")]
        [InlineData("Buy 2 get 1", "The headline")]
        public async Task Words_with_numbers_are_refused_before_Codex_runs(string headline, string label)
        {
            var request = Diwali();
            request.Headline = headline;

            var error = await Assert.ThrowsAsync<AiProviderException>(() => Codex().MakeCreativeAsync(request, null, CancellationToken.None));

            Assert.StartsWith(label + " has a number, ₹ or % in it.", error.Message);
            Assert.Empty(_runner.Calls);
        }

        [Theory]
        [InlineData("Demo Mart 99")]
        [InlineData("1004 GANESH")]
        [InlineData("Shop No. 12 Kirana")]
        [InlineData("स्मार्ट ९९")]
        public async Task The_shops_own_name_may_have_a_number_and_is_drawn_as_written(string name)
        {
            var request = Diwali();
            request.ShopName = name;
            Assert.Null(request.Problem());
            _runner.Handler = call =>
            {
                File.WriteAllBytes(Path.Combine(call.WorkingDirectory, CreativeArtPrompt.ResultFileName), ProductPhotoTests.Png);
                return new CliResult { ExitCode = 0 };
            };

            await Codex().MakeCreativeAsync(request, null, CancellationToken.None);

            var prompt = _runner.Calls.Single().StandardInput;
            Assert.Contains("  Shop's name: \"" + name + "\"", prompt);
            Assert.Contains("and the number that is part of the shop's name, drawn exactly as written. No watermark or signature.", prompt);
        }

        [Theory]
        [InlineData("Sale 50% Store")]
        [InlineData("₹99 Store")]
        [InlineData("Rs 99 Mart")]
        public async Task The_shops_name_still_may_not_look_like_a_price(string name)
        {
            var request = Diwali();
            request.ShopName = name;

            var error = await Assert.ThrowsAsync<AiProviderException>(() => Codex().MakeCreativeAsync(request, null, CancellationToken.None));

            Assert.StartsWith("The shop's name has a ₹, a % or a money word in it.", error.Message);
            Assert.Empty(_runner.Calls);
        }

        [Fact]
        public void A_headline_with_a_number_is_still_refused_when_the_shops_name_has_one()
        {
            var request = Diwali();
            request.ShopName = "Demo Mart 99";
            request.Headline = "Avenue 99 sale";

            Assert.StartsWith("The headline has a number, ₹ or % in it.", request.Problem());
        }

        [Fact]
        public void Words_are_checked_for_numbers_and_length_but_instructions_may_have_numbers()
        {
            Assert.Null(CreativeWords.NameProblem("The shop's name", "Demo Mart 99", CreativeWords.MaxLine));
            Assert.Contains("too long", CreativeWords.NameProblem("The shop's name", new string('a', CreativeWords.MaxLine + 1), CreativeWords.MaxLine));
            Assert.Contains("a number is fine", CreativeWords.NameProblem("The shop's name", "Mart 50%", CreativeWords.MaxLine), StringComparison.OrdinalIgnoreCase);
            Assert.True(CreativeWords.HasDigits("Avenue 99"));
            Assert.True(CreativeWords.HasDigits("९९ स्टोर"));
            Assert.False(CreativeWords.HasDigits("Avenue ninety nine"));
            Assert.True(CreativeWords.HasMoney("Rs. ninety"));
            Assert.False(CreativeWords.HasMoney("Avenue 99"));
            Assert.Null(CreativeWords.Problem("The headline", "शुभ दीपावली Offers", CreativeWords.MaxHeadline));
            Assert.Null(CreativeWords.Problem("The headline", "Crispy, fresh and first-class", CreativeWords.MaxHeadline));
            Assert.Contains("too long", CreativeWords.Problem("The headline", new string('a', CreativeWords.MaxHeadline + 1), CreativeWords.MaxHeadline));
            Assert.Null(CreativeWords.Problem("The instructions", "Show 2 products", CreativeWords.MaxNotes, allowNumbers: true));
            Assert.True(CreativeWords.HasNumbers("INR ninety"));
            Assert.False(CreativeWords.HasNumbers("Crisp, fresh words for Rsvp"));
            Assert.Equal("Say 'hi' there", CreativeWords.Tidy("  Say \"hi\"\n  there "));

            var request = Diwali();
            request.Instructions = "Put 3 diyas at the bottom";
            request.Previous = _temp.File("before.png");
            request.Change = "";
            Assert.Equal("Say what to change.", request.Problem());
            request.Change = "Make 2 more diyas";
            Assert.Null(request.Problem());
            request.Products.AddRange(Enumerable.Range(0, 3).Select(i => new CreativeArtProduct { Name = "P" }));
            Assert.Contains("at most 4 products", request.Problem());
        }

        [Theory]
        [InlineData(1080, 1080, "1024 x 1024 (square)")]
        [InlineData(1080, 1350, "1024 x 1536 (tall)")]
        [InlineData(1080, 1920, "1024 x 1536 (tall)")]
        [InlineData(2480, 3508, "1024 x 1536 (tall)")]
        [InlineData(1200, 628, "1536 x 1024 (wide)")]
        public void The_image_tool_is_asked_for_its_closest_shape(int width, int height, string size)
        {
            Assert.Equal(size, CreativeArtPrompt.ToolSize(width, height));
        }

        [Fact]
        public void The_answer_keeps_each_price_place_inside_the_picture()
        {
            var (areas, notes) = CreativeArtAnswer.Parse(Answer(
                "[{\"x\":0.9,\"y\":-0.2,\"width\":0.3,\"height\":0.01},{\"x\":0.1,\"y\":0.1,\"width\":1.5,\"height\":0.2},{\"x\":\"left\",\"y\":0.1,\"width\":0.2,\"height\":0.2},{\"x\":0.2,\"y\":0.2,\"width\":0.2,\"height\":0.2}]"), 3);

            Assert.Equal(2, areas.Count);
            Assert.Equal((0.7, 0.0, 0.3, CreativeArtAnswer.MinSize), (areas[0].X, areas[0].Y, areas[0].Width, areas[0].Height));
            Assert.Equal((0.0, 0.1, 1.0, 0.2), (areas[1].X, areas[1].Y, areas[1].Width, areas[1].Height));
            Assert.Equal("A festive square post with both products.", notes);

            Assert.Empty(CreativeArtAnswer.Parse(Answer("[{\"x\":0.2,\"y\":0.2,\"width\":0.2,\"height\":0.2}]"), 0).Areas);
            Assert.Empty(CreativeArtAnswer.Parse("not json", 2).Areas);
            Assert.Empty(CreativeArtAnswer.Parse(null, 2).Areas);
            Assert.Empty(CreativeArtAnswer.Parse("{\"image\":\"creative.png\"}", 2).Areas);
        }

        [Fact]
        public void Without_words_or_prices_the_picture_has_none()
        {
            var request = new CreativeArtRequest { FormatName = "Story", Width = 1080, Height = 1920 };

            var prompt = CreativeArtPrompt.CodexPrompt(request);

            Assert.Contains("- Show no words at all.", prompt);
            Assert.DoesNotContain("price tag", prompt);
            Assert.Contains("\"price_areas\" lists nothing (an empty list)", prompt);
            Assert.Contains("a small shop.\n", prompt);
            Assert.DoesNotContain("India", prompt); // no country unless the customer's profile names one
        }

        private sealed class ListProgress : IProgress<string>
        {
            private readonly List<string> _messages;

            public ListProgress(List<string> messages) => _messages = messages;

            public void Report(string value) => _messages.Add(value);
        }
    }
}
