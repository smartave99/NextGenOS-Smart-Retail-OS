using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public class ProductPhotoTests : IDisposable
    {
        internal const string Answer = @"```json
{ ""display_name"": ""Pink Flip-Top Water Bottle"", ""what_it_is"": ""a pink plastic water bottle with a flip-top lid"",
  ""description"": ""A light bottle for school and office. Easy to carry."", ""product_type"": ""water bottle"",
  ""suggested_category"": ""Home Essentials > Bottles"", ""colours"": [""pink"", ""white"", ""Pink""], ""material"": ""plastic"",
  ""size_or_quantity"": ""750 ml"", ""keywords"": [""bottle"", ""school bottle""], ""hindi_name"": ""पानी की बोतल"",
  ""use_case_scene"": ""a sunny office desk beside a laptop"", ""model_person"": ""a woman in her early 30s"", ""notes"": """" }
```";

        internal static readonly byte[] Png = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 0, 0, 0, 13, 0x49, 0x48, 0x44, 0x52, 0, 0, 4, 0, 0, 0, 3, 0 };

        private readonly TempFolder _temp = new TempFolder();
        private readonly FakeCliRunner _runner = new FakeCliRunner();
        private readonly AssistantSettings _settings;

        public ProductPhotoTests()
        {
            (_settings, _) = TestSettings.Create();
            _settings.Codex.ExecutablePath = _temp.File("codex-tool");
        }

        public void Dispose() => _temp.Dispose();

        private string Runs => Path.Combine(_temp.Path, "runs");

        private CodexCliProvider Codex() => new CodexCliProvider(_runner, () => _settings, Runs) { CodexHome = Path.Combine(_temp.Path, "codex-home") };

        private ProductPhotoRequest Request(params string[] photos) => new ProductPhotoRequest
        {
            ProductId = 1193,
            Code = "PP-1193",
            Name = "PP-1193",
            Category = "GENERAL",
            RawPhotos = (photos.Length == 0 ? new[] { _temp.File("raw.jpg", "raw photo") } : photos).ToList(),
        };

        private Func<CliInvocation, CliResult> MakesPhoto(string answer = Answer) => call =>
        {
            File.WriteAllBytes(Path.Combine(call.WorkingDirectory, ProductPhotoPrompt.ResultFileName), Png);
            File.WriteAllText(FakeCliRunner.ArgumentAfter(call, "--output-last-message"), answer);
            return new CliResult { ExitCode = 0, Duration = TimeSpan.FromSeconds(42) };
        };

        [Fact]
        public async Task Codex_makes_the_white_photo_with_its_image_tool_and_describes_the_product()
        {
            _runner.Handler = MakesPhoto();
            var messages = new List<string>();
            var request = Request(_temp.File("front.jpg", "front"), _temp.File("back.PNG", "back"));

            var result = await Codex().MakeProductPhotoAsync(request, new ListProgress(messages), CancellationToken.None);

            Assert.Equal(Png, result.Image);
            Assert.Equal("Codex CLI (OpenAI)", result.ProviderName);
            Assert.Equal(TimeSpan.FromSeconds(42), result.Duration);
            Assert.Equal("a pink plastic water bottle with a flip-top lid", result.Understanding.WhatItIs);
            Assert.Equal(new[] { "pink", "white" }, result.Understanding.Colours);
            Assert.Equal("पानी की बोतल", result.Understanding.LocalName); // an answer that still says hindi_name is read
            Assert.Equal("a sunny office desk beside a laptop", result.Understanding.UseCaseScene);
            Assert.Equal("a woman in her early 30s", result.Understanding.ModelPerson);
            Assert.Contains("photo 1 of 5: White background", Assert.Single(messages));

            var call = _runner.Calls.Single();
            var args = call.Arguments;
            // The photos come first, so "-" at the end is the prompt, not a third image.
            Assert.Equal(new[] { "exec", "--image", Path.Combine(call.WorkingDirectory, "photo-1.jpg"), "--image", Path.Combine(call.WorkingDirectory, "photo-2.png") }, args.Take(5));
            Assert.Equal("workspace-write", FakeCliRunner.ArgumentAfter(call, "--sandbox"));
            Assert.Equal("image_generation", FakeCliRunner.ArgumentAfter(call, "--enable"));
            Assert.Equal(call.WorkingDirectory, FakeCliRunner.ArgumentAfter(call, "--cd"));
            Assert.Contains("--output-schema", args);
            Assert.Contains("--skip-git-repo-check", args);
            Assert.DoesNotContain("--ephemeral", args);
            Assert.Equal("-", args.Last());
            Assert.Contains("\"PP-1193\" (code PP-1193, category GENERAL)", call.StandardInput);
            Assert.Contains("This is photo 1 of 5: White background.", call.StandardInput);
            Assert.Contains("pure white background (RGB 255, 255, 255)", call.StandardInput);
            Assert.Contains("filling about 85% of a square image", call.StandardInput);
            Assert.Contains("Keep the product exactly as it is", call.StandardInput);
            Assert.Contains("as clean.png", call.StandardInput);
            Assert.Contains("answer with JSON only", call.StandardInput);
            Assert.True(call.Timeout >= CodexCliProvider.MinimumPhotoTimeout);
            Assert.False(Directory.Exists(call.WorkingDirectory), "the working folder is cleaned up");
        }

        [Fact]
        public async Task Later_photos_show_codex_the_white_photo_first_and_ask_for_no_description()
        {
            _runner.Handler = MakesPhoto();
            var request = Request(_temp.File("front.jpg", "front"));
            request.Kind = PhotoKind.EuropeanModel;
            _settings.Shop = Shops.Philippines;
            request.CataloguePhoto = _temp.File("white-20260924-100000.png", "white");
            request.Understanding = ProductUnderstanding.Parse(Answer);

            var result = await Codex().MakeProductPhotoAsync(request, null, CancellationToken.None);

            Assert.Equal(Png, result.Image);
            Assert.Null(result.Understanding);
            var call = _runner.Calls.Single();
            Assert.Equal(new[] { "exec", "--image", Path.Combine(call.WorkingDirectory, "catalogue-photo.png"), "--image", Path.Combine(call.WorkingDirectory, "photo-1.jpg") }, call.Arguments.Take(5));
            Assert.DoesNotContain("--output-schema", call.Arguments);
            var prompt = call.StandardInput;
            Assert.Contains("The first attached photo is a catalogue photo of it made earlier", prompt);
            Assert.Contains("It is a pink plastic water bottle with a flip-top lid.", prompt);
            Assert.Contains("This is photo 3 of 5: Filipino model.", prompt);
            Assert.Contains("You are making product photos for a small shop in the Philippines,", prompt);
            Assert.Contains("one model, a woman in her early 30s (Filipino, in her late twenties), using or holding the product in a sunny office desk beside a laptop", prompt);
            Assert.Contains("answer with one short sentence", prompt);
        }

        [Fact]
        public async Task A_change_gives_codex_the_photo_made_before_first_and_the_owners_words()
        {
            _runner.Handler = MakesPhoto();
            var messages = new List<string>();
            var request = Request(_temp.File("front.jpg", "front"));
            request.Kind = PhotoKind.InUse;
            request.CataloguePhoto = _temp.File("white-20260924-100000.png", "white");
            request.PreviousPhoto = _temp.File("in-use-20260924-100100.png", "before");
            request.Note = "make the label easier to read";
            request.ReferenceWidth = 3024;
            request.ReferenceHeight = 4032;

            await Codex().MakeProductPhotoAsync(request, new ListProgress(messages), CancellationToken.None);

            var call = _runner.Calls.Single();
            var images = call.Arguments.Select((argument, i) => (argument, i)).Where(a => a.argument == "--image").Select(a => Path.GetFileName(call.Arguments[a.i + 1])).ToList();
            Assert.Equal(new[] { "previous-photo.png", "catalogue-photo.png", "photo-1.jpg" }, images);
            Assert.Contains("changing photo 2 of 5: In use", Assert.Single(messages));
            Assert.DoesNotContain("--output-schema", call.Arguments);
            Assert.Contains("The owner asks for this change to the photo you made before: \"make the label easier to read\".", call.StandardInput);
            Assert.Contains("make it 1024 x 1536 (tall)", call.StandardInput);
            Assert.False(Directory.Exists(call.WorkingDirectory), "the working folder is cleaned up");
        }

        [Fact]
        public void Each_photo_has_its_own_instructions()
        {
            var seen = ProductUnderstanding.Parse(Answer);

            var white = ProductPhotoPrompt.ImageInstructions(PhotoKind.WhiteBackground, seen);
            Assert.Contains("the product alone on a pure white background", white);
            Assert.Contains("No props and no people.", white);

            var inUse = ProductPhotoPrompt.ImageInstructions(PhotoKind.InUse, seen);
            Assert.Contains("being used in a real place: a sunny office desk beside a laptop.", inUse);
            Assert.Contains("no faces", inUse);
            Assert.Contains("must look like a real photograph", inUse);

            Assert.Contains("(Chinese-Filipino)", ProductPhotoPrompt.ImageInstructions(PhotoKind.IndianModel, seen, null, Shops.Philippines));
            Assert.Contains("(Visayan, in his forties)", ProductPhotoPrompt.ImageInstructions(PhotoKind.EastAsianModel, seen, null, Shops.Philippines));
            foreach (var kind in PhotoKinds.All.Where(k => k.IsModel()))
            {
                var text = ProductPhotoPrompt.ImageInstructions(kind, seen);
                Assert.Contains("an emotional lifestyle photo of one model, a woman in her early 30s", text);
                Assert.Contains("genuine moment", text);
                Assert.Contains("not a render or an illustration", text);
                Assert.Contains("Do not add, remove or change any text or logo", text);
            }

            // Without a description yet, the AI chooses the person and the place from the product.
            var unknown = ProductPhotoPrompt.ImageInstructions(PhotoKind.EuropeanModel);
            Assert.Contains("an adult whose gender and age suit the product's typical buyer or user", unknown);
            Assert.Contains("the most typical real-world place for this product, at home, at work or outdoors", unknown); // no country is assumed
            Assert.Contains("the most typical real-world place for this product in the Philippines, at home", ProductPhotoPrompt.ImageInstructions(PhotoKind.EuropeanModel, null, null, Shops.Philippines));
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, PhotoKinds.All.Select(k => k.Number()));
            Assert.Equal(new[] { "white", "in-use", "european-model", "indian-model", "east-asian-model" }, PhotoKinds.All.Select(k => k.FilePrefix()));
        }

        [Fact]
        public async Task The_schema_asks_for_every_field_and_nothing_else()
        {
            string schema = null;
            _runner.Handler = call =>
            {
                schema = File.ReadAllText(FakeCliRunner.ArgumentAfter(call, "--output-schema"));
                File.WriteAllBytes(Path.Combine(call.WorkingDirectory, ProductPhotoPrompt.ResultFileName), Png);
                return new CliResult { ExitCode = 0 };
            };

            var result = await Codex().MakeProductPhotoAsync(Request(), null, CancellationToken.None);

            var json = JObject.Parse(schema);
            Assert.False((bool)json["additionalProperties"]);
            var properties = ((JObject)json["properties"]).Properties().Select(p => p.Name).OrderBy(n => n).ToList();
            Assert.Equal(properties, json["required"].Select(r => (string)r).OrderBy(n => n));
            Assert.Contains("use_case_scene", properties);
            Assert.Contains("model_person", properties);
            Assert.Null(result.Understanding);
        }

        [Fact]
        public async Task An_image_saved_only_in_the_codex_home_folder_is_still_found()
        {
            var generated = Path.Combine(_temp.Path, "codex-home", "generated_images", "session-1");
            _runner.Handler = call =>
            {
                Directory.CreateDirectory(generated);
                File.WriteAllBytes(Path.Combine(generated, "ig_abc.png"), Png);
                File.WriteAllText(FakeCliRunner.ArgumentAfter(call, "--output-last-message"), Answer);
                return new CliResult { ExitCode = 0 };
            };

            var result = await Codex().MakeProductPhotoAsync(Request(), null, CancellationToken.None);

            Assert.Equal(Png, result.Image);
        }

        [Fact]
        public async Task No_image_means_a_clear_problem_about_signing_in()
        {
            _runner.Handler = call => new CliResult { ExitCode = 0 };

            var error = await Assert.ThrowsAsync<AiProviderException>(() => Codex().MakeProductPhotoAsync(Request(), null, CancellationToken.None));

            Assert.Contains("made no image", error.Message);
            Assert.Contains("codex login status", error.Message);
        }

        [Fact]
        public async Task A_codex_that_is_not_signed_in_says_so()
        {
            _runner.Handler = call => new CliResult { ExitCode = 1, StandardError = "Error: not logged in. Run codex login." };

            var error = await Assert.ThrowsAsync<AiProviderException>(() => Codex().MakeProductPhotoAsync(Request(), null, CancellationToken.None));

            Assert.Contains("not signed in", error.Message);
        }

        [Fact]
        public async Task Bad_photos_are_refused_before_codex_runs()
        {
            var request = Request(_temp.File("scan.pdf", "not a photo"));

            var error = await Assert.ThrowsAsync<AiProviderException>(() => Codex().MakeProductPhotoAsync(request, null, CancellationToken.None));

            Assert.Contains("JPG, PNG or WEBP", error.Message);
            Assert.Empty(_runner.Calls);
            Assert.Contains("at least one photo", new ProductPhotoRequest { Name = "x" }.Problem());
            Assert.Contains("at most 4", Request(Enumerable.Range(1, 5).Select(i => _temp.File("p" + i + ".jpg", "x")).ToArray()).Problem());
            Assert.Contains("was not found", Request(Path.Combine(_temp.Path, "missing.jpg")).Problem());

            // Four phone photos and the catalogue photo: Codex gets the catalogue photo and three phone photos.
            var four = Request(Enumerable.Range(1, 4).Select(i => _temp.File("q" + i + ".jpg", "x")).ToArray());
            four.CataloguePhoto = _temp.File("white.png", "w");
            Assert.Equal(new[] { four.CataloguePhoto }.Concat(four.RawPhotos.Take(3)), four.Attachments());
        }

        [Theory]
        [InlineData("not json at all")]
        [InlineData("{ broken")]
        [InlineData("{ \"notes\": \"blurry\" }")]
        [InlineData(null)]
        public void Answers_without_a_description_give_nothing(string answer)
        {
            Assert.Null(ProductUnderstanding.Parse(answer));
        }

        [Fact]
        public void Image_files_tell_their_format_and_size()
        {
            Assert.Equal(".png", ImageFile.ExtensionOf(Png));
            Assert.True(ImageFile.TryReadSize(Png, out var width, out var height));
            Assert.Equal((1024, 768), (width, height));

            // A JPEG with an APP0 block before its size (SOF0: 1600 wide, 1200 high).
            var jpeg = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0, 0, 6, 1, 2, 3, 4, 0xFF, 0xC0, 0, 17, 8, 0x04, 0xB0, 0x06, 0x40, 3, 0, 0, 0, 0, 0 };
            Assert.Equal(".jpg", ImageFile.ExtensionOf(jpeg));
            Assert.True(ImageFile.TryReadSize(jpeg, out width, out height));
            Assert.Equal((1600, 1200), (width, height));

            // An extended WebP (VP8X) of 2048 × 2048.
            var webp = new byte[30];
            System.Text.Encoding.ASCII.GetBytes("RIFF").CopyTo(webp, 0);
            System.Text.Encoding.ASCII.GetBytes("WEBPVP8X").CopyTo(webp, 8);
            webp[24] = 0xFF;
            webp[25] = 0x07;
            webp[27] = 0xFF;
            webp[28] = 0x07;
            Assert.Equal(".webp", ImageFile.ExtensionOf(webp));
            Assert.True(ImageFile.TryReadSize(webp, out width, out height));
            Assert.Equal((2048, 2048), (width, height));

            Assert.Null(ImageFile.ExtensionOf(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }));
            Assert.False(ImageFile.TryReadSize(new byte[] { 1, 2, 3 }, out _, out _));
        }

        private sealed class ListProgress : IProgress<string>
        {
            private readonly List<string> _messages;

            public ListProgress(List<string> messages) => _messages = messages;

            public void Report(string value) => _messages.Add(value);
        }
    }
}
