using System.Text.Json;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using SmartRetail.AI.Prices;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using SmartRetail.Pos.Core.Prices;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

public sealed class PriceCheckServiceTests : IDisposable
{
    /// <summary>A clock the test can move on, in Indian time.</summary>
    private sealed class Clock(DateTimeOffset start) : TimeProvider
    {
        private static readonly TimeZoneInfo India = TimeZoneInfo.CreateCustomTimeZone("IST", TimeSpan.FromHours(5.5), "India Standard Time", "India Standard Time");
        private DateTimeOffset _now = start;

        public void Advance(TimeSpan by) => _now += by;

        public override DateTimeOffset GetUtcNow() => _now.ToUniversalTime();

        public override TimeZoneInfo LocalTimeZone => India;
    }

    private readonly string _root = Directory.CreateTempSubdirectory("pricecheck-").FullName;
    private readonly StorageService _storage;
    private readonly Clock _clock = new(new DateTimeOffset(2026, 9, 29, 16, 0, 0, TimeSpan.FromHours(5.5)));
    private readonly List<PriceCheckRequest> _asked = new();
    private Func<PriceCheckRequest, Task<PriceCheckAnswer>> _answer;

    public PriceCheckServiceTests()
    {
        File.WriteAllText(Path.Combine(_root, SmartRetail.AI.Storage.StorageSettingsStore.FileName), JsonSerializer.Serialize(new { DataFolder = Path.Combine(_root, "data") }));
        _storage = new StorageService(Options.Create(new AiOptions { SettingsFile = Path.Combine(_root, "settings.json") }));
        _answer = _ => Task.FromResult(Answer(Quote("https://www.amazon.in/dp/B1", 189m), Quote("https://www.flipkart.com/oil/p/itm1", 172m, "Flipkart"), Quote("https://www.jiomart.com/p/oil/1", 165m, "JioMart", same: false)));
    }

    public void Dispose() => Directory.Delete(_root, recursive: true);

    private PriceCheckService Service() => new(_storage, _clock, NullLogger<PriceCheckService>.Instance, (request, _) =>
    {
        _asked.Add(request);
        return _answer(request);
    });

    private static PriceQuote Quote(string url, decimal price, string shop = "Amazon.in", bool same = true) =>
        new() { Shop = shop, Url = url, Title = "Sunflower Oil 1 L", Price = price, Pack = "1 L", SameProduct = same, InStock = true };

    private static PriceCheckAnswer Answer(params PriceQuote[] quotes) => new() { Quotes = quotes.ToList(), Note = "Blinkit had none." };

    private Task<string?> Check(PriceCheckService service, bool onlyConfirmed = false) =>
        service.CheckAsync(6, "Sunflower Oil 1 L", "8901234567890", "Oils & Ghee", "golden sunflower oil", onlyConfirmed, CancellationToken.None);

    [Fact]
    public async Task A_check_keeps_the_pages_it_finds_waiting_for_the_owner_and_asks_only_for_what_identifies_the_product()
    {
        var service = Service();

        Assert.Null(await Check(service));

        var product = Assert.Single(service.Load().Products);
        Assert.Equal((6, "Sunflower Oil 1 L", "Blinkit had none."), (product.ProductId, product.Name, product.Note));
        Assert.Equal(_clock.GetLocalNow().DateTime, product.Checked);
        Assert.All(product.Links, link => Assert.Equal(LinkStatus.New, link.Status));
        Assert.Equal(new[] { "Amazon.in", "Flipkart", "JioMart" }, product.Links.Select(l => l.Shop));
        var request = Assert.Single(_asked);
        Assert.Equal(("Sunflower Oil 1 L", "8901234567890", "Oils & Ghee", "golden sunflower oil", false), (request.Name, request.Barcode, request.Category, request.WhatItIs, request.OnlyReadAgain));
        Assert.Empty(request.ReadAgain);
        Assert.Equal(Path.Combine(_root, "data", "Price checks", PriceCheckService.FileName), service.Path);
        Assert.True(File.Exists(service.Path));
    }

    [Fact]
    public async Task Only_the_pages_the_owner_confirmed_are_read_again_and_a_rejected_page_never_comes_back()
    {
        var service = Service();
        await Check(service);
        Assert.Null(service.SetStatus(6, "https://www.amazon.in/dp/B1", LinkStatus.Confirmed));
        Assert.Null(service.SetStatus(6, "https://www.jiomart.com/p/oil/1", LinkStatus.Rejected));

        _clock.Advance(TimeSpan.FromHours(30));
        _answer = _ => Task.FromResult(Answer(
            Quote("https://www.amazon.in/dp/B1", 179m),
            Quote("https://www.jiomart.com/p/oil/1", 99m),
            Quote("https://www.dmart.in/product/oil", 170m, "DMart Ready")));
        await Check(service);

        var request = _asked.Last();
        Assert.Equal(new[] { "https://www.amazon.in/dp/B1" }, request.ReadAgain);
        Assert.False(request.OnlyReadAgain);
        var links = service.For(6)!.Links;
        var amazon = links.Single(l => l.Shop == "Amazon.in");
        Assert.Equal((LinkStatus.Confirmed, 179m), (amazon.Status, amazon.Price));
        Assert.Equal(new[] { 189m, 179m }, amazon.History.Select(p => p.Price));
        Assert.Equal((LinkStatus.Rejected, 165m), (links.Single(l => l.Shop == "JioMart").Status, links.Single(l => l.Shop == "JioMart").Price));
        Assert.Equal(LinkStatus.New, links.Single(l => l.Shop == "DMart Ready").Status);

        // "Update the prices I confirmed" reads only those pages.
        _answer = _ => Task.FromResult(Answer(Quote("https://www.amazon.in/dp/B1", 175m)));
        Assert.Null(await Check(service, onlyConfirmed: true));
        Assert.True(_asked.Last().OnlyReadAgain);
        Assert.Equal(175m, service.For(6)!.Links.Single(l => l.Shop == "Amazon.in").Price);
    }

    [Fact]
    public async Task Reading_again_without_a_confirmed_page_says_so_and_asks_nobody()
    {
        var service = Service();

        var problem = await Check(service, onlyConfirmed: true);

        Assert.Equal("No page has been confirmed for this product yet, so there is nothing to read again.", problem);
        Assert.Empty(_asked);
        Assert.Equal(problem, service.ProblemOf(6));
    }

    [Fact]
    public async Task A_failure_is_told_and_kept_until_the_next_check_goes_well_and_nothing_is_lost()
    {
        var service = Service();
        await Check(service);
        _answer = _ => throw new AiProviderException(ProviderIds.CodexCli, "Codex has reached its usage limit. It can answer again at 7:33 PM.");

        var problem = await Check(service);

        Assert.Equal("Codex has reached its usage limit. It can answer again at 7:33 PM.", problem);
        Assert.Equal(problem, service.ProblemOf(6));
        Assert.Equal(3, service.For(6)!.Links.Count);
        Assert.Null(service.Checking);

        _answer = _ => Task.FromResult(Answer());
        Assert.Null(await Check(service));
        Assert.Null(service.ProblemOf(6));
    }

    [Fact]
    public async Task One_product_is_checked_at_a_time_and_the_page_can_tell_which()
    {
        var finish = new TaskCompletionSource<PriceCheckAnswer>();
        _answer = _ => finish.Task;
        var service = Service();

        var running = Check(service);
        Assert.Equal(6, service.Checking);
        Assert.Equal("This product is being checked already.", await Check(service));
        Assert.Equal("Another product is being checked now. Try again when it is done.",
            await service.CheckAsync(7, "Toor Dal 1 kg", "", "", "", false, CancellationToken.None));

        // The refusal is on the card of the product that asked, not of the one running, and goes when the running check ends.
        Assert.Equal("Another product is being checked now. Try again when it is done.", service.ProblemOf(7));
        Assert.Null(service.ProblemOf(6));

        finish.SetResult(Answer(Quote("https://www.amazon.in/dp/B1", 189m)));
        Assert.Null(await running);
        Assert.Null(service.Checking);
        Assert.Null(service.ProblemOf(7));
        Assert.Null(service.ProblemOf(6));
        Assert.Single(service.For(6)!.Links);
        Assert.Null(service.For(7));
    }

    [Fact]
    public async Task What_was_found_is_not_kept_for_a_product_forgotten_meanwhile()
    {
        var service = Service();
        _answer = _ =>
        {
            service.Forget(6);
            return Task.FromResult(Answer(Quote("https://www.amazon.in/dp/B1", 189m)));
        };

        Assert.Null(await Check(service));

        Assert.Empty(service.Load().Products);
    }

    [Fact]
    public async Task A_file_edited_by_hand_gives_the_page_only_what_is_safe_to_show()
    {
        var service = Service();
        await Check(service);
        var edited = new PriceBook
        {
            Products =
            {
                new WatchedProduct
                {
                    ProductId = 6,
                    Name = "Oil‮\n<b>x</b>",
                    Note = new string('n', 500),
                    Links =
                    {
                        new PriceLink { Url = "https://www.flipkart.com/oil/p/itm1?pid=1#x", Shop = "Amazon.in", Title = "Oil\u0007", Status = LinkStatus.Confirmed, Price = 172m, Seen = new DateTime(2026, 9, 28), History = null! },
                        new PriceLink { Url = "https://evil.example/oil", Shop = "Flipkart", Price = 10m },
                        new PriceLink { Url = "https://www.amazon.in/dp/B1", Price = 0m },
                        new PriceLink { Url = "https://www.amazon.in/dp/B2", Price = 50m, Status = (LinkStatus)9 },
                        new PriceLink { Url = "https://www.flipkart.com/oil/p/itm1", Price = 172m },
                        null!,
                    },
                },
                new WatchedProduct { ProductId = 0 },
                new WatchedProduct { ProductId = 6 },
                null!,
                new WatchedProduct { ProductId = 8, Links = null! },
            },
        };
        File.WriteAllText(service.Path, JsonSerializer.Serialize(edited));

        var book = service.Load();

        Assert.Equal(new[] { 6, 8 }, book.Products.Select(p => p.ProductId));
        var product = book.Products[0];
        Assert.False(product.Name.Contains('‮'));
        Assert.Equal("Oil <b>x</b>", product.Name);
        Assert.Equal(300, product.Note.Length);
        var link = Assert.Single(product.Links);
        Assert.Equal(("https://www.flipkart.com/oil/p/itm1", "Flipkart", "Oil", LinkStatus.Confirmed), (link.Url, link.Shop, link.Title, link.Status));
        Assert.Empty(link.History);
        Assert.Empty(book.Products[1].Links);
    }

    [Fact]
    public void A_damaged_file_is_kept_aside_and_the_price_book_starts_again()
    {
        var service = Service();
        Directory.CreateDirectory(Path.GetDirectoryName(service.Path)!);
        File.WriteAllText(service.Path, "{ not json");

        Assert.Empty(service.Load().Products);
        Assert.Equal("{ not json", File.ReadAllText(service.Path + ".bad"));
    }

    [Fact]
    public async Task A_page_that_is_not_there_any_more_cannot_be_confirmed()
    {
        var service = Service();
        await Check(service);

        Assert.Equal("That page is not there any more.", service.SetStatus(6, "https://www.amazon.in/dp/NOPE", LinkStatus.Confirmed));
        Assert.Equal("That page is not there any more.", service.SetStatus(99, "https://www.amazon.in/dp/B1", LinkStatus.Confirmed));
        Assert.Equal("That page is not there any more.", service.SetStatus(6, "https://www.amazon.in/dp/B1", (LinkStatus)7));
    }
}
