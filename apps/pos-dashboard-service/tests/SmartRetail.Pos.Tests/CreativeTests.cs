using System.Text.Json;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using SkiaSharp;
using SmartRetail.AI.Creatives;
using SmartRetail.AI.Products;
using SmartRetail.AI.Providers;
using SmartRetail.Pos.Core.Creatives;
using SmartRetail.Pos.Data.Demo;
using SmartRetail.Pos.Tests.Vision;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

public sealed class CreativePricingTests
{
    private static readonly TagFacts Oil = new(6, "Sunflower Oil 1 L", 155m, 120m, 5m);

    [Fact]
    public void A_tag_shows_the_POS_price_with_GST_and_an_offer_only_within_the_rules()
    {
        // Lowest allowed: the purchase price plus GST (126), not the 30% limit (108.50).
        var (tag, problem) = CreativePricing.Tag(Oil, 139m, pricesIncludeTax: true, maxOfferPercent: 30m);
        Assert.Null(problem);
        Assert.Equal(new PriceTag(6, "Sunflower Oil 1 L", 155m, 139m, 10m), tag);
        Assert.Equal(139m, tag!.Pays);

        Assert.Equal(new PriceTag(6, "Sunflower Oil 1 L", 155m, null, 0m), CreativePricing.Tag(Oil, null, true, 30m).Tag);
        Assert.Equal(118m, CreativePricing.Tag(new TagFacts(1, "Mug", 100m, 60m, 18m), null, pricesIncludeTax: false, 30m).Tag!.Price);
    }

    [Theory]
    [InlineData(120, "the lowest allowed now is ₹126")]
    [InlineData(139.5, "the lowest allowed now is ₹126")]
    [InlineData(155, "the lowest allowed now is ₹126")]
    [InlineData(170, "the lowest allowed now is ₹126")]
    public void An_offer_that_breaks_the_rules_is_never_shown_and_says_why(decimal offer, string why)
    {
        var (tag, problem) = CreativePricing.Tag(Oil, offer, true, 30m);

        Assert.Null(tag!.Offer);
        Assert.Equal(155m, tag.Pays);
        Assert.Contains(why, problem);
        Assert.EndsWith("Choose its offer again.", problem);
    }

    [Fact]
    public void Without_a_purchase_price_or_a_price_there_is_no_offer_or_no_tag()
    {
        var noCost = Oil with { CostPrice = 0m };
        Assert.Empty(CreativePricing.OfferChoices(noCost, true, 30m));
        Assert.Contains("no offer is allowed on it now", CreativePricing.Tag(noCost, 140m, true, 30m).Problem);

        var (tag, problem) = CreativePricing.Tag(Oil with { SellingPrice = 0m }, null, true, 30m);
        Assert.Null(tag);
        Assert.Equal("Sunflower Oil 1 L has no price in the POS, so it gets no price tag.", problem);

        // 5%, 10% and 15% off rounded up to whole rupees, then the lowest allowed.
        Assert.Equal(new[] { 148m, 140m, 132m, 126m }, CreativePricing.OfferChoices(Oil, true, 30m));
    }

    [Fact]
    public void Tags_start_in_the_places_the_AI_left_else_along_the_bottom_and_stay_inside()
    {
        var square = CreativeFormat.Square;
        Assert.Equal(0.13, TagLayout.Height(square), 6);

        Assert.Equal(new[] { new TagPlace(0.62, 0.715) }, TagLayout.Place(1, new[] { (0.6, 0.7, 0.3, 0.16) }, square));
        Assert.Equal(new[] { new TagPlace(0.7, 0.83), new TagPlace(0.41, 0.83), new TagPlace(0.12, 0.83), new TagPlace(0.7, 0.67) },
            TagLayout.Place(4, Array.Empty<(double, double, double, double)>(), square));
        Assert.Equal(new TagPlace(0.7, 0.9044), TagLayout.Place(1, Array.Empty<(double, double, double, double)>(), CreativeFormat.Story)[0]);

        // An empty place at the very edge still keeps the whole tag inside.
        Assert.Equal(new TagPlace(0.74, 0.87), TagLayout.Place(1, new[] { (0.95, 0.95, 0.1, 0.1) }, square)[0]);
        Assert.Equal(new TagPlace(0.74, 0), TagLayout.Clamp(new TagPlace(1.5, -2), square));
        Assert.Equal(new TagPlace(0, 0), TagLayout.Clamp(new TagPlace(double.NaN, double.PositiveInfinity), square));
    }

    [Theory]
    [InlineData("#D7263D", "#D7263D", "#FFFFFF")]
    [InlineData("#1d3557", "#1D3557", "#FFFFFF")]
    [InlineData("#FFC914", "#FFC914", "#1D1D1F")]
    [InlineData("#E4572E", "#E4572E", "#1D1D1F")]
    [InlineData("red", "#D7263D", "#FFFFFF")]
    [InlineData(null, "#D7263D", "#FFFFFF")]
    public void Tag_words_are_white_or_near_black_whichever_stands_out(string? brand, string background, string words)
    {
        Assert.Equal((background, words), TagLayout.Colours(brand));
    }

    [Fact]
    public void Formats_and_styles_fall_back_to_the_first()
    {
        Assert.Equal(CreativeFormat.Story, CreativeFormat.Find("story"));
        Assert.Equal(CreativeFormat.Square, CreativeFormat.Find("../poster"));
        Assert.Equal(CreativeStyle.Festive, CreativeStyle.Find("festive"));
        Assert.Equal(CreativeStyle.Clean, CreativeStyle.Find(null));
        Assert.Equal("#ABCDEF", TagLayout.CleanColour(" #abcdef "));
        Assert.Null(TagLayout.CleanColour("#abc"));
    }
}

public sealed class CreativeStoreTests : IDisposable
{
    private readonly string _root = Directory.CreateTempSubdirectory("creatives-").FullName;
    private readonly CreativeStore _store;
    private readonly DateTime _now = new(2026, 9, 28, 11, 30, 0);

    public CreativeStoreTests() => _store = new CreativeStore(() => _root);

    public void Dispose() => Directory.Delete(_root, recursive: true);

    [Fact]
    public void A_creative_is_kept_in_its_own_folder_and_found_again()
    {
        var first = _store.Create(new CreativeProject { Title = "Diwali offer" }, _now);
        var second = _store.Create(new CreativeProject { Title = "Rice" }, _now);

        Assert.Equal("20260928-113000", first.Id);
        Assert.Equal("20260928-113000-2", second.Id);
        Assert.True(File.Exists(Path.Combine(_root, "Creatives", first.Id, CreativeStore.ProjectFileName)));
        Assert.Equal(new[] { second.Id, first.Id }, _store.Recent().Select(p => p.Id));

        var changed = _store.Update(first.Id, p => p with { Title = "Diwali", Id = "20990101-000000", Brief = new CreativeBrief { Headline = "Diwali Dhamaka" } }, _now.AddMinutes(5));
        Assert.Equal(first.Id, changed!.Id);
        Assert.Equal(_now, changed.Created);
        Assert.Equal(_now.AddMinutes(5), changed.Updated);
        Assert.Equal("Diwali Dhamaka", _store.Load(first.Id)!.Brief.Headline);

        Assert.True(_store.Delete(second.Id));
        Assert.Null(_store.Load(second.Id));
        Assert.False(_store.Delete("..\\x"));
        Assert.Null(_store.Load("../Creatives"));
    }

    [Fact]
    public void A_creative_saved_before_the_audience_was_asked_loads_with_it_empty_and_keeps_the_rest()
    {
        var id = _store.Create(new CreativeProject { Title = "Old one" }, _now).Id;
        var oldFile = $$"""
            {
              "Id": "{{id}}",
              "Title": "Old one",
              "Created": "2026-09-28T11:30:00",
              "Updated": "2026-09-28T11:30:00",
              "Brief": {
                "Format": "story", "Style": "festive", "Headline": "Fresh stock", "Subtitle": "", "CallToAction": "Visit us today", "SmallPrint": "",
                "Background": "", "Instructions": "Keep it simple", "Products": [ { "ProductId": 6, "Offer": 148 } ], "References": [], "ShowPrices": true
              },
              "Generations": [
                { "Number": 1, "Brief": { "Format": "story", "Headline": "Fresh stock", "Instructions": "Keep it simple" }, "Started": "2026-09-28T11:31:00", "HasImage": true }
              ]
            }
            """;
        File.WriteAllText(Path.Combine(_root, "Creatives", id, CreativeStore.ProjectFileName), oldFile);

        var loaded = _store.Load(id)!;

        Assert.Equal("", loaded.Brief.Audience);
        Assert.Equal("", loaded.Generations[0].Brief.Audience);
        Assert.Equal(("story", "festive", "Fresh stock", "Visit us today", "Keep it simple"),
            (loaded.Brief.Format, loaded.Brief.Style, loaded.Brief.Headline, loaded.Brief.CallToAction, loaded.Brief.Instructions));
        Assert.Equal(new[] { new CreativeItem(6, 148m) }, loaded.Brief.Products);

        // Saved again, the audience is kept with the brief and the old words are not lost.
        var saved = _store.Update(id, p => p with { Brief = p.Brief with { Audience = "families with young children" } }, _now.AddMinutes(1))!;
        Assert.Equal("families with young children", _store.Load(id)!.Brief.Audience);
        Assert.Equal("Fresh stock", saved.Brief.Headline);
    }

    [Fact]
    public void Pictures_their_prompts_references_and_exports_are_kept_under_names_the_store_makes()
    {
        var id = _store.Create(new CreativeProject(), _now).Id;
        _store.SaveResult(id, 1, new byte[] { 1, 2, 3 }, "the prompt", new { Headline = "Hi" });

        Assert.Equal(new byte[] { 1, 2, 3 }, File.ReadAllBytes(_store.ResultPath(id, 1)!));
        Assert.Equal("the prompt", _store.Prompt(id, 1));
        Assert.Null(_store.ResultPath(id, 2));
        Assert.Null(_store.ResultPath(id, 0));

        var reference = _store.AddReference(id, new byte[] { 9 }, ".webp", _now);
        var again = _store.AddReference(id, new byte[] { 8 }, ".png", _now);
        Assert.Equal("reference-20260928-113000.webp", reference);
        Assert.Equal("reference-20260928-113000.png", again);
        Assert.NotNull(_store.AssetPath(id, reference));
        Assert.Null(_store.AssetPath(id, "../creative.json"));
        Assert.Throws<ArgumentException>(() => _store.AddReference(id, new byte[] { 1 }, ".exe", _now));

        var export = _store.SaveExport(id, new byte[] { 7 }, "Diwali Offer!", "square", 2);
        Assert.Equal("diwali-offer-square-2.png", export);
        Assert.NotNull(_store.ExportPath(id, export));
        Assert.Null(_store.ExportPath(id, "..%2Fcreative.json"));
        Assert.Equal("creative-story-1.png", _store.SaveExport(id, new byte[] { 7 }, "दिवाली", "story", 1));
    }

    [Fact]
    public void The_brand_is_kept_for_every_creative_with_one_logo()
    {
        Assert.Equal(new CreativeBrand().Colours, _store.LoadBrand().Colours);
        _store.SaveBrand(new CreativeBrand { ShopName = "Sharma Store", Colours = new[] { "#1d3557", "blue", "#ffffff", "#000000" }, Notes = "Family-run" });

        var old = _store.SaveLogo(new byte[] { 1 }, ".png", _now);
        var logo = _store.SaveLogo(new byte[] { 2 }, ".jpg", _now.AddMinutes(1));
        _store.SaveBrand(_store.LoadBrand() with { Logo = logo });

        var brand = _store.LoadBrand();
        Assert.Equal("Sharma Store", brand.ShopName);
        Assert.Equal(new[] { "#1D3557", "#FFFFFF" }, brand.Colours);
        Assert.Equal(logo, brand.Logo);
        Assert.Null(_store.LogoPath(old));
        Assert.Equal(new byte[] { 2 }, File.ReadAllBytes(_store.LogoPath(logo)!));
        Assert.Null(_store.LogoPath("../brand.json"));
    }
}

public sealed class CreativeServiceTests : IDisposable
{
    private const int Oil = 6;

    private readonly string _root = Directory.CreateTempSubdirectory("creative-service-").FullName;
    private readonly DemoStore _pos = new(new FixedClock(new DateTimeOffset(2026, 9, 28, 11, 0, 0, TimeSpan.FromHours(5.5))), seedSales: false);
    private readonly IOptions<AiOptions> _options;
    private readonly ProductPhotoService _photos;
    private readonly StorageService _storage;
    private readonly List<CreativeArtRequest> _asked = new();
    private Func<CreativeArtRequest, CancellationToken, Task<CreativeArtResult>> _maker;

    public CreativeServiceTests()
    {
        File.WriteAllText(Path.Combine(_root, SmartRetail.AI.Storage.StorageSettingsStore.FileName), JsonSerializer.Serialize(new { DataFolder = Path.Combine(_root, "data") }));
        _options = Options.Create(new AiOptions { SettingsFile = Path.Combine(_root, "settings.json") });
        _storage = new StorageService(_options);
        _photos = new ProductPhotoService(new AiEnvironment(_options), _storage, _pos, _pos, Options.Create(new ShopOptions()), TimeProvider.System, NullLogger<ProductPhotoService>.Instance);
        _maker = (request, ct) => Task.FromResult(new CreativeArtResult
        {
            Image = Png,
            PriceAreas = new List<CreativeArea> { new() { X = 0.6, Y = 0.7, Width = 0.3, Height = 0.16 } },
            Notes = "A warm square post.",
            Prompt = CreativeArtPrompt.CodexPrompt(request),
            ProviderName = "Codex CLI (OpenAI)",
            Duration = TimeSpan.FromSeconds(95),
        });
    }

    public void Dispose() => Directory.Delete(_root, recursive: true);

    private static byte[] Png => Pictures.Encode(Pictures.Plain(64, 64, 240, 140, 40), SKEncodedImageFormat.Png);

    private CreativeService Service(string shopName = "Sharma Store", AiEnvironment? ai = null) => new(new CreativeStore(_storage), _photos, _storage, _pos, ai ?? new AiEnvironment(_options),
        Options.Create(new ShopOptions { Name = shopName }), new FixedClock(new DateTimeOffset(2026, 9, 28, 11, 30, 0, TimeSpan.FromHours(5.5))),
        NullLogger<CreativeService>.Instance,
        (request, progress, ct) =>
        {
            _asked.Add(request);
            progress.Report("Codex is designing the creative…");
            return _maker(request, ct);
        });

    /// <summary>The oil with a white-background photo, as the photo page leaves it.</summary>
    private string PhotographOil()
    {
        var now = new DateTime(2026, 9, 28, 10, 0, 0);
        using var raw = new MemoryStream(Png);
        var name = _photos.Store.SaveRaw(Oil, raw, ".png", now, "Sunflower Oil 1 L");
        var set = _photos.Store.StartSet(Oil, "1006", "Sunflower Oil 1 L", "", new[] { name }, now);
        _photos.Store.SaveImage(Oil, set.Id, PhotoKind.WhiteBackground, new ProductPhotoResult { Image = Png, Understanding = new ProductUnderstanding { WhatItIs = "a 1 litre bottle of golden oil" } }, now.AddMinutes(1));
        return _photos.Store.Load(Oil)!.LatestSet!.Latest(PhotoKind.WhiteBackground)!.File;
    }

    [Fact]
    public async Task A_picture_is_made_from_the_brief_with_the_products_photo_and_no_prices()
    {
        var white = PhotographOil();
        var service = Service();
        var project = service.Create(CreativeFormat.Square, new[] { Oil, Oil, 999 }, "Sunflower Oil 1 L");
        Assert.Equal(new[] { Oil, 999 }, project.Brief.Products.Select(p => p.ProductId));
        project = service.SaveBrief(project.Id, "Diwali offer", project.Brief with
        {
            Style = CreativeStyle.Festive.Id,
            Headline = "Diwali Dhamaka",
            CallToAction = "Visit us today",
            Products = new[] { new CreativeItem(Oil, 148m) },
        });

        project = service.Make(project.Id);
        Assert.True(Assert.Single(project.Generations).IsMaking);
        Assert.False(service.IsIdle);
        Assert.Equal("Waiting for the creative being made now…", service.Status(project.Id));
        Assert.True(await service.MakeNextAsync(CancellationToken.None));

        var asked = Assert.Single(_asked);
        Assert.Equal(("Square post", 1080, 1080), (asked.FormatName, asked.Width, asked.Height));
        Assert.Equal(CreativeStyle.Festive.Brief, asked.Style);
        Assert.Equal("Sharma Store", asked.ShopName);
        var product = Assert.Single(asked.Products);
        Assert.Equal(("Sunflower Oil 1 L", "a 1 litre bottle of golden oil", true), (product.Name, product.WhatItIs, product.HasPrice));
        Assert.Equal(white, Path.GetFileName(product.Photo));
        var prompt = CreativeArtPrompt.CodexPrompt(asked);
        Assert.DoesNotContain("₹", prompt.Replace("currency signs such as ₹", ""));
        Assert.DoesNotContain("155", prompt);
        Assert.DoesNotContain("148", prompt);

        var made = service.Store.Load(project.Id)!.Generation(1)!;
        Assert.True(made.HasImage);
        Assert.False(made.IsMaking);
        Assert.Equal(("Codex CLI (OpenAI)", "A warm square post.", 95d), (made.By, made.Notes, made.Seconds));
        Assert.Equal(new[] { new TagPlace(0.62, 0.715) }, made.Tags);
        Assert.Equal(Png, File.ReadAllBytes(service.Store.ResultPath(project.Id, 1)!));
        Assert.Contains("Diwali Dhamaka", service.Store.Prompt(project.Id, 1));
        Assert.True(service.IsIdle);
        Assert.Null(service.Status(project.Id));

        var tags = await service.TagsAsync(made.Brief, CancellationToken.None);
        Assert.Equal(new PriceTag(Oil, "Sunflower Oil 1 L", 155m, 148m, 4m), Assert.Single(tags.Tags));
        Assert.Empty(tags.Problems);
    }

    [Fact]
    public async Task A_change_is_made_from_the_picture_before_and_keeps_its_brief()
    {
        var service = Service();
        var project = service.Create(CreativeFormat.Story, new[] { Oil }, "Oil");
        service.SaveBrief(project.Id, "", project.Brief with { Headline = "Fresh stock" });
        service.Make(project.Id);
        await service.MakeNextAsync(CancellationToken.None);
        service.SaveBrief(project.Id, "", service.Store.Load(project.Id)!.Brief with { Headline = "Something else" });

        Assert.Throws<CreativeException>(() => service.Change(project.Id, 1, "   "));
        Assert.Throws<CreativeException>(() => service.Change(project.Id, 7, "Bluer"));
        project = service.Change(project.Id, 1, "Make the \"background\" deep blue");
        await service.MakeNextAsync(CancellationToken.None);

        var change = _asked[1];
        Assert.Equal(service.Store.ResultPath(project.Id, 1), change.Previous);
        Assert.Equal("Make the 'background' deep blue", change.Change);
        Assert.Equal("Fresh stock", change.Headline);
        var second = service.Store.Load(project.Id)!.Generation(2)!;
        Assert.Equal((1, true), (second.Parent, second.HasImage));

        service.Choose(project.Id, 2);
        Assert.Equal(2, service.Store.Load(project.Id)!.Chosen);
        Assert.Equal(2, service.Store.Load(project.Id)!.Shown!.Number);
    }

    [Fact]
    public void Who_it_is_for_is_kept_on_one_line_trimmed_and_cut_when_too_long()
    {
        var service = Service();
        var project = service.Create(CreativeFormat.Square, new[] { Oil }, "Oil");
        Assert.Equal("", project.Brief.Audience);

        project = service.SaveBrief(project.Id, "", project.Brief with { Audience = "  families with young children\r\nand \"grandparents\"\u0007  " });
        Assert.Equal("families with young children and 'grandparents'", project.Brief.Audience);
        Assert.Equal(project.Brief.Audience, service.Store.Load(project.Id)!.Brief.Audience);

        // Saving something else does not lose it.
        project = service.SaveBrief(project.Id, "", project.Brief with { Headline = "Fresh stock" });
        Assert.Equal("families with young children and 'grandparents'", service.Store.Load(project.Id)!.Brief.Audience);

        // Too long: cut to the same length as the other notes, without a space left at the end.
        var tooLong = string.Concat(Enumerable.Repeat("ab ", 200));
        project = service.SaveBrief(project.Id, "", project.Brief with { Audience = tooLong });
        Assert.InRange(project.Brief.Audience.Length, CreativeWords.MaxNotes - 1, CreativeWords.MaxNotes);
        Assert.StartsWith("ab ab ab", project.Brief.Audience);
        Assert.Equal(project.Brief.Audience.TrimEnd(), project.Brief.Audience);
        Assert.Equal(project.Brief.Audience, service.Store.Load(project.Id)!.Brief.Audience);
        Assert.Equal(CreativeWords.MaxNotes, service.SaveBrief(project.Id, "", project.Brief with { Audience = new string('a', CreativeWords.MaxNotes + 50) }).Brief.Audience.Length);

        // Emptied, or only blanks and line breaks: nothing is kept.
        Assert.Equal("", service.SaveBrief(project.Id, "", project.Brief with { Audience = " \r\n\t\u0007 " }).Brief.Audience);
        Assert.Equal("", service.SaveBrief(project.Id, "", project.Brief with { Audience = null! }).Brief.Audience);
    }

    [Fact]
    public async Task Who_it_is_for_goes_to_the_AI_only_when_it_is_given_and_a_number_in_it_is_fine()
    {
        var service = Service();
        var project = service.Create(CreativeFormat.Square, new[] { Oil }, "Oil");
        service.SaveBrief(project.Id, "", project.Brief with { Headline = "Fresh stock", Audience = "families with 2 children" });
        service.Make(project.Id);
        await service.MakeNextAsync(CancellationToken.None);

        var asked = Assert.Single(_asked);
        Assert.Equal("families with 2 children", asked.Audience);
        var prompt = service.Store.Prompt(project.Id, 1)!;
        Assert.Contains("- Who it is for: families with 2 children. Let the people, the setting and the mood suit them.", prompt);
        Assert.Contains("Strictly no numbers, prices, currency signs such as ₹, percent signs", prompt);
        Assert.Contains("and no other words:", prompt);
        var kept = File.ReadAllText(Path.Combine(Path.GetDirectoryName(service.Store.ResultPath(project.Id, 1))!, "request.json"));
        Assert.Contains("\"Audience\": \"families with 2 children\"", kept);

        // Taken out again, the next picture says nothing about it.
        var brief = service.Store.Load(project.Id)!.Brief;
        service.SaveBrief(project.Id, "", brief with { Audience = "" });
        service.Make(project.Id);
        await service.MakeNextAsync(CancellationToken.None);

        Assert.Equal("", _asked[1].Audience);
        Assert.DoesNotContain("Who it is for", service.Store.Prompt(project.Id, 2));
        // The first picture keeps the brief it was made from.
        Assert.Equal("families with 2 children", service.Store.Load(project.Id)!.Generation(1)!.Brief.Audience);
    }

    [Theory]
    [InlineData("Diwali 50% off")]
    [InlineData("Only ₹99")]
    [InlineData("Buy 2 get 1 free")]
    public void Words_with_numbers_stop_a_picture_before_it_is_asked_for(string headline)
    {
        var service = Service();
        var project = service.Create(CreativeFormat.Square, new[] { Oil }, "Oil");
        service.SaveBrief(project.Id, "", project.Brief with { Headline = headline });

        var error = Assert.Throws<CreativeException>(() => service.Make(project.Id));

        Assert.StartsWith("The headline has a number, ₹ or % in it.", error.Message);
        Assert.Empty(service.Store.Load(project.Id)!.Generations);
    }

    [Fact]
    public async Task Failures_and_stops_are_kept_with_the_picture_and_one_is_made_at_a_time()
    {
        var service = Service();
        var id = service.Create(CreativeFormat.Square, new[] { Oil }, "Oil").Id;
        _maker = (request, ct) => throw new AiProviderException("codex-cli", "Codex answered but made no picture.", canFallback: false);
        service.Make(id);
        Assert.Throws<CreativeException>(() => service.Make(id));
        await service.MakeNextAsync(CancellationToken.None);
        Assert.Equal("Codex answered but made no picture.", service.Store.Load(id)!.Generation(1)!.Problem);

        service.Make(id);
        service.Stop(id);
        Assert.False(await service.MakeNextAsync(CancellationToken.None) && _asked.Count > 1);
        Assert.Equal("Stopped before it began.", service.Store.Load(id)!.Generation(2)!.Problem);

        var running = new TaskCompletionSource();
        _maker = async (request, ct) =>
        {
            running.SetResult();
            await Task.Delay(Timeout.Infinite, ct);
            throw new InvalidOperationException("never");
        };
        service.Make(id);
        var make = service.MakeNextAsync(CancellationToken.None);
        await running.Task.WaitAsync(TimeSpan.FromSeconds(10));
        Assert.Equal("Codex is designing the creative…", service.Status(id));
        Assert.Throws<CreativeException>(() => service.Delete(id));
        service.Stop(id);
        await make.WaitAsync(TimeSpan.FromSeconds(10));
        Assert.Equal("Stopped.", service.Store.Load(id)!.Generation(3)!.Problem);
        Assert.True(service.IsIdle);
    }

    [Fact]
    public async Task An_unexpected_failure_stops_one_picture_and_the_next_is_still_made()
    {
        var service = Service();
        var id = service.Create(CreativeFormat.Square, Array.Empty<int>(), null).Id;
        var maker = _maker;
        _maker = (request, ct) => throw new FormatException("bad answer");
        service.Make(id);
        await service.MakeNextAsync(CancellationToken.None);
        Assert.Equal("The picture could not be made: bad answer", service.Store.Load(id)!.Generation(1)!.Problem);

        _maker = maker;
        service.Make(id);
        await service.MakeNextAsync(CancellationToken.None);
        Assert.True(service.Store.Load(id)!.Generation(2)!.HasImage);
    }

    private static AiProviderException UsageLimit() => new("codex-cli", "Codex has reached its usage limit. It can answer again at 7:33 PM.", canFallback: true,
        usageLimit: new UsageLimitInfo("Codex has reached its usage limit. It can answer again at 7:33 PM.", DateTimeOffset.Now.AddHours(2)));

    [Fact]
    public async Task A_picture_that_meets_codexs_usage_limit_waits_for_it_and_is_made_when_it_lifts()
    {
        var ai = new AiEnvironment(_options);
        var service = Service(ai: ai);
        var id = service.Create(CreativeFormat.Square, new[] { Oil }, "Oil").Id;
        var maker = _maker;
        var attempts = 0;
        _maker = (request, ct) => attempts++ == 0 ? throw UsageLimit() : maker(request, ct);
        service.Make(id);

        await service.MakeNextAsync(CancellationToken.None);

        // Nothing failed: the picture is still being made, waits for the time Codex gave, and says so.
        var waiting = service.Store.Load(id)!.Generation(1)!;
        Assert.True(waiting.IsMaking);
        Assert.True(waiting.WaitingForLimit);
        Assert.Null(waiting.Problem);
        Assert.False(service.IsIdle);
        Assert.True(service.IsWaitingForLimit);
        Assert.StartsWith("Paused: Codex's usage limit was reached. This picture is made by itself at ", service.Status(id));
        Assert.Throws<CreativeException>(() => service.Make(id));

        // The limit lifts (here: the owner presses Try now): the same picture is made.
        service.TryNow();
        Assert.False(service.IsWaitingForLimit);
        await service.MakeNextAsync(CancellationToken.None);

        var made = service.Store.Load(id)!.Generation(1)!;
        Assert.True(made.HasImage);
        Assert.False(made.IsMaking);
        Assert.False(made.WaitingForLimit);
        Assert.Equal(2, attempts);
        Assert.True(service.IsIdle);
        Assert.Null(service.Status(id));
    }

    [Fact]
    public async Task The_work_runs_on_by_itself_once_the_limit_has_lifted()
    {
        var ai = new AiEnvironment(_options);
        var service = Service(ai: ai);
        var id = service.Create(CreativeFormat.Square, new[] { Oil }, "Oil").Id;
        var maker = _maker;
        var attempts = 0;
        _maker = (request, ct) => attempts++ == 0 ? throw UsageLimit() : maker(request, ct);
        using var stop = new CancellationTokenSource();

        // As in the app: the worker starts first (and marks what an earlier run left), then a picture is asked for.
        var run = service.RunAsync(stop.Token);
        service.Make(id);

        await Until(() => service.IsWaitingForLimit);
        Assert.Equal(1, attempts);
        await Task.Delay(300);
        Assert.Equal(1, attempts);

        ai.LimitPause.Clear();
        await Until(() => service.Store.Load(id)!.Generation(1)!.HasImage);

        stop.Cancel();
        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => run);
    }

    [Fact]
    public async Task A_picture_waiting_for_the_limit_is_still_waiting_after_the_app_is_opened_again_but_others_are_marked()
    {
        var service = Service();
        var id = service.Create(CreativeFormat.Square, new[] { Oil }, "Oil").Id;
        var maker = _maker;
        _maker = (request, ct) => throw UsageLimit();
        service.Make(id);
        await service.MakeNextAsync(CancellationToken.None);
        Assert.True(service.Store.Load(id)!.Generation(1)!.WaitingForLimit);

        // Another picture was being made when the app closed.
        var other = service.Create(CreativeFormat.Story, Array.Empty<int>(), null).Id;
        service.Store.Update(other, p => p with { Generations = new[] { new CreativeGeneration { Number = 1, Started = DateTime.Now } } }, DateTime.Now);

        // The app is opened again.
        _maker = maker;
        var restarted = Service();
        restarted.MarkAbandoned();

        Assert.True(service.Store.Load(id)!.Generation(1)!.IsMaking);
        Assert.Null(service.Store.Load(id)!.Generation(1)!.Problem);
        Assert.False(restarted.IsIdle);
        Assert.Equal("The app was closed before this picture was made. Make it again.", service.Store.Load(other)!.Generation(1)!.Problem);

        Assert.True(await restarted.MakeNextAsync(CancellationToken.None));
        Assert.True(service.Store.Load(id)!.Generation(1)!.HasImage);
        Assert.False(service.Store.Load(id)!.Generation(1)!.WaitingForLimit);
    }

    /// <summary>Waits (up to 10 seconds) until the condition holds, for work that goes on in the background.</summary>
    private static async Task Until(Func<bool> condition)
    {
        var give = DateTime.UtcNow.AddSeconds(10);
        while (!condition())
        {
            Assert.True(DateTime.UtcNow < give, "the work did not get there in time");
            await Task.Delay(10);
        }
    }

    [Fact]
    public void A_picture_left_unmade_when_the_app_closed_is_marked_at_start()
    {
        var service = Service();
        var id = service.Create(CreativeFormat.Square, Array.Empty<int>(), null).Id;
        service.Store.Update(id, p => p with { Generations = new[] { new CreativeGeneration { Number = 1, Started = DateTime.Now } } }, DateTime.Now);

        Service().MarkAbandoned();

        Assert.Equal("The app was closed before this picture was made. Make it again.", service.Store.Load(id)!.Generation(1)!.Problem);
    }

    [Fact]
    public async Task An_offer_that_no_longer_keeps_the_rules_stops_the_export_and_tags_move_inside_the_picture()
    {
        var service = Service();
        var id = service.Create(CreativeFormat.Square, new[] { Oil }, "Oil").Id;
        service.SaveBrief(id, "", service.Store.Load(id)!.Brief with { Products = new[] { new CreativeItem(Oil, 100m) } });
        service.Make(id);
        await service.MakeNextAsync(CancellationToken.None);

        var tags = await service.TagsAsync(service.Store.Load(id)!.Brief, CancellationToken.None);
        Assert.Null(Assert.Single(tags.Tags).Offer);
        Assert.Contains("The offer of ₹100 on Sunflower Oil 1 L no longer keeps the rules", Assert.Single(tags.Problems));

        var moved = service.MoveTag(id, 1, 0, 0.95, -0.4);
        Assert.Equal(new TagPlace(0.74, 0), moved.Generation(1)!.Tags[0]);
        Assert.Equal(moved.Generation(1)!.Tags, service.MoveTag(id, 1, 5, 0.1, 0.1).Generation(1)!.Tags);

        var export = await service.SaveExportAsync(id, 1, new MemoryStream(Png), CancellationToken.None);
        Assert.Equal("oil-square-1.png", export);
        await Assert.ThrowsAsync<CreativeException>(() => service.SaveExportAsync(id, 1, new MemoryStream(Pictures.Encode(Pictures.Plain(8, 8, 1, 2, 3), SKEncodedImageFormat.Jpeg)), CancellationToken.None));
        await Assert.ThrowsAsync<CreativeException>(() => service.AddReferenceAsync(id, new MemoryStream("text"u8.ToArray()), CancellationToken.None));
        var reference = await service.AddReferenceAsync(id, new MemoryStream(Png), CancellationToken.None);
        Assert.StartsWith("reference-", reference);
    }

    [Fact]
    public async Task A_product_deleted_from_the_POS_stays_on_the_brief_to_be_taken_off()
    {
        const int Gone = 9_999, Unknown = 9_998;
        var now = new DateTime(2026, 9, 28, 10, 0, 0);
        using (var raw = new MemoryStream(Png))
        {
            var name = _photos.Store.SaveRaw(Gone, raw, ".png", now, "Old Soap");
            _photos.Store.StartSet(Gone, "2001", "Old Soap", "", new[] { name }, now);
        }

        var products = await Service().ProductsAsync(new[] { Gone, Oil, Unknown }, CancellationToken.None);

        Assert.Equal(new[] { Gone, Oil, Unknown }, products.Select(p => p.ProductId));
        Assert.Equal(new[] { false, true, false }, products.Select(p => p.InPos));
        Assert.Equal(new[] { "Old Soap", "Sunflower Oil 1 L", "A product" }, products.Select(p => p.Name));
        Assert.All(new[] { products[0], products[2] }, gone =>
        {
            Assert.Equal(0m, gone.Price);
            Assert.Empty(gone.OfferChoices);
            Assert.False(gone.HasPhoto);
        });
        Assert.True(products[1].Price > 0);
    }

    [Fact]
    public void The_brand_keeps_the_shop_name_from_the_POS_until_one_is_saved_and_refuses_price_signs_but_not_numbers()
    {
        var service = Service();
        Assert.Equal("Sharma Store", service.Brand.ShopName);

        service.SaveBrand(new CreativeBrand { ShopName = "Sharma General Store", Colours = new[] { "#1d3557", "not a colour" } });
        Assert.Equal("Sharma General Store", service.Brand.ShopName);
        Assert.Equal(new[] { "#1D3557" }, service.Brand.Colours);

        // A number is part of a name (Demo Mart 99); a price sign would look like an offer, which only the app draws.
        service.SaveBrand(new CreativeBrand { ShopName = "  Demo Mart 99 " });
        Assert.Equal("Demo Mart 99", service.Brand.ShopName);
        Assert.Throws<CreativeException>(() => service.SaveBrand(new CreativeBrand { ShopName = "Mega 50% Mart" }));
        Assert.Throws<CreativeException>(() => service.SaveBrand(new CreativeBrand { ShopName = "₹99 Store" }));
        Assert.Equal("Demo Mart 99", service.Brand.ShopName);
    }

    [Fact]
    public void A_shop_name_with_a_number_does_not_stop_a_picture_whether_it_is_from_the_POS_or_saved()
    {
        var service = Service("Demo Mart 99");
        Assert.Null(service.Problem(new CreativeBrief()));

        service.SaveBrand(new CreativeBrand { ShopName = "1004 Ganesh" });
        Assert.Null(service.Problem(new CreativeBrief()));
    }

    [Fact]
    public void A_price_sign_in_the_shop_name_stops_a_picture_and_says_where_to_change_it()
    {
        var service = Service("Hot 50% Mart");

        Assert.Equal("The shop's name has a ₹, a % or a money word in it. A number is fine (like Avenue 99), but not a price sign: "
            + "the app adds each price itself, from the POS. Change it under \"Your shop's brand\".", service.Problem(new CreativeBrief()));

        service.SaveBrand(new CreativeBrand { ShopName = "Hot Mart" });
        Assert.Null(service.Problem(new CreativeBrief()));
    }
}
