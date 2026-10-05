using Microsoft.Extensions.Options;
using SmartRetail.AI.Products;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Posters;

namespace SmartRetail.Pos.Web.Services;

/// <summary>A poster just made, and what staff should know about how.</summary>
public sealed record MadePoster(Poster Poster, string? Note);

/// <summary>A saved poster checked against the POS as it is now.</summary>
public sealed record CheckedPoster(Poster Poster, IReadOnlyList<PosterChange> Changes);

/// <summary>
/// Makes A4 sale posters: the app's rules find the products that suit the kind of poster (<see cref="PosterPicker"/>),
/// the AI tool set up in the side panel picks from them and writes the words (<see cref="PosterPrompt"/>; figures and
/// product names only), and every price comes from the POS. Without an AI tool the app picks by its own rules.
/// </summary>
public sealed class PosterService
{
    private readonly ISalesFactsRepository _facts;
    private readonly ProductPhotoService _photos;
    private readonly AiEnvironment _ai;
    private readonly StorageService _storage;
    private readonly ShopOptions _shop;
    private readonly TimeProvider _clock;
    private readonly ILogger<PosterService> _log;

    public PosterService(ISalesFactsRepository facts, ProductPhotoService photos, PosterStore store, AiEnvironment ai,
        StorageService storage, IOptions<ShopOptions> shop, TimeProvider clock, ILogger<PosterService> log)
    {
        _facts = facts;
        _photos = photos;
        Store = store;
        _ai = ai;
        _storage = storage;
        _shop = shop.Value;
        _clock = clock;
        _log = log;
    }

    public PosterStore Store { get; }

    public DateOnly Today => DateOnly.FromDateTime(_clock.GetLocalNow().DateTime);

    /// <summary>The owner's limit on offers (Settings → Posters), with the other rules.</summary>
    public PosterRules Rules => new() { MaxOfferPercent = _ai.LoadSettings().Posters.CheckedMaxOfferPercent };

    public async Task<IReadOnlyList<PosterCandidate>> CandidatesAsync(PosterKind kind, CancellationToken ct)
    {
        var rules = Rules;
        var today = Today;
        var products = await _facts.GetProductsAsync(ct);
        var sales = await _facts.GetFactsAsync(rules.SalesRange(today), ct);
        var inputs = new PosterInputs(today, products, sales.ProductDays, WhitePhotos(), _shop.PricesIncludeTax);
        return PosterPicker.Candidates(kind, inputs, rules);
    }

    /// <summary>The AI tool that would pick and write, or null when none is ready.</summary>
    public async Task<string?> ReadyAiAsync(CancellationToken ct)
    {
        var router = _ai.CreateRouter(AiJob.PosterWords);
        foreach (var provider in router.PlanOrder(ProviderIds.Auto))
        {
            if ((await router.GetStatusAsync(provider, refresh: false, ct)).IsReady)
            {
                return provider.DisplayName;
            }
        }

        return null;
    }

    /// <summary>
    /// Makes and saves a poster. The AI picks when one is ready; when it is not, or its answer cannot be used, the
    /// app picks by its own rules and says so in the note.
    /// </summary>
    public async Task<MadePoster> MakeAsync(PosterKind kind, int count, string? festival, IProgress<string>? progress, CancellationToken ct)
    {
        RefuseWhileMoving();
        count = PosterKinds.ProductCounts.Contains(count) ? count : 4;
        festival = kind == PosterKind.FestivalOffer ? NullIfEmpty(PosterWords.Tidy(festival, PosterWords.MaxFestivalLength)) : null;
        var candidates = await CandidatesAsync(kind, ct);
        if (candidates.Count == 0)
        {
            throw new PosterException(NothingFits(kind));
        }

        var items = PosterPicker.DefaultPicks(kind, candidates, count);
        var words = kind.DefaultWords(festival);
        string? pickedBy = null;
        string? note = null;

        if (await ReadyAiAsync(ct) is not null)
        {
            progress?.Report("The AI is choosing the products and writing the words…");
            try
            {
                var router = _ai.CreateRouter(AiJob.PosterWords);
                var request = new AiRequest
                {
                    SystemPrompt = PosterPrompt.SystemPrompt,
                    UserPrompt = PosterPrompt.UserPrompt(kind, count, candidates, Today, Rules, festival),
                };
                var response = await router.CompleteAsync(request, ProviderIds.Auto, ct, progress);
                if (PosterPrompt.ReadAnswer(response.Text, kind, count, candidates, festival) is { } plan)
                {
                    items = plan.Items;
                    words = plan.Words;
                    pickedBy = router.Find(response.ProviderId)?.DisplayName ?? response.ProviderId;
                    if (plan.ChosenByAi < plan.Items.Count)
                    {
                        note = "The AI chose " + plan.ChosenByAi + "; the app added the rest from its list.";
                    }
                }
                else
                {
                    note = "The AI's answer could not be read, so the app picked the products by its own rules.";
                }
            }
            catch (AiProviderException ex)
            {
                _log.LogWarning(ex, "The AI could not plan a poster.");
                note = "The AI could not answer (" + ex.Message + "), so the app picked the products by its own rules.";
            }
        }
        else
        {
            note = "No AI tool is set up, so the app picked the products by its own rules and used its own words.";
        }

        if (candidates.Count < count)
        {
            note = (note is null ? "" : note + " ") + "Only " + candidates.Count + " products fit this poster right now.";
        }

        var now = _clock.GetLocalNow().DateTime;
        var poster = new Poster
        {
            Id = UniqueId(now, kind),
            Kind = kind,
            Made = now,
            ShopName = _shop.Name,
            Festival = festival,
            Words = words,
            ValidFrom = Today,
            ValidTill = Today.AddDays(6),
            Items = items,
            PickedBy = pickedBy,
        };
        RefuseWhileMoving();
        Store.Save(poster);
        return new MadePoster(poster, note);
    }

    /// <summary>Saves staff's changes, keeping every offer to the rules and the words tidy.</summary>
    public Poster? Save(Poster edited)
    {
        ArgumentNullException.ThrowIfNull(edited);
        RefuseWhileMoving();
        return Store.Update(edited.Id, saved => saved with
        {
            ShopName = PosterWords.Tidy(edited.ShopName, 60),
            Words = edited.Words.Tidied(),
            ValidFrom = edited.ValidFrom,
            ValidTill = edited.ValidTill < edited.ValidFrom ? edited.ValidFrom : edited.ValidTill,
            Items = edited.Items
                .Select(item => saved.Items.FirstOrDefault(s => s.ProductId == item.ProductId) is { } before
                    ? (before with { Name = NullIfEmpty(PosterWords.Tidy(item.Name, 80)) ?? before.Name }).WithOffer(item.OfferPrice)
                    : null)
                .OfType<PosterItem>()
                .ToList(),
        });
    }

    /// <summary>
    /// Checks a saved poster against the POS as it is now (<see cref="PosterRecheck"/>): prices, purchase prices,
    /// GST and the owner's offer limit may have changed since it was made. Offers that are still allowed get today's
    /// lowest allowed offer; everything else is listed, and the poster should not be printed until it is fixed.
    /// </summary>
    public async Task<CheckedPoster> RecheckAsync(Poster poster, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(poster);
        var now = await TodaysPricesAsync(ct);
        var changes = new List<PosterChange>();
        var lowest = new Dictionary<int, decimal>();
        foreach (var item in poster.Items)
        {
            decimal? priceNow = null;
            var lowestNow = item.LowestOffer;
            if (now.TryGetValue(item.ProductId, out var today))
            {
                priceNow = today.Price;
                lowestNow = today.Lowest;
            }

            var (checkedItem, change) = PosterRecheck.Check(item, priceNow, lowestNow);
            if (change is null)
            {
                lowest[item.ProductId] = checkedItem.LowestOffer;
            }
            else
            {
                changes.Add(change);
            }
        }

        if (poster.Items.Any(item => lowest.TryGetValue(item.ProductId, out var value) && value != item.LowestOffer) && !_storage.IsMoving)
        {
            poster = Store.Update(poster.Id, saved => saved with
            {
                Items = saved.Items.Select(item => lowest.TryGetValue(item.ProductId, out var value) ? item with { LowestOffer = value } : item).ToList(),
            }) ?? poster;
        }

        return new CheckedPoster(poster, changes);
    }

    /// <summary>Adds a product from the kind's list to a saved poster (at most six), with the kind's usual offer.</summary>
    public Poster? Add(string id, PosterCandidate candidate)
    {
        ArgumentNullException.ThrowIfNull(candidate);
        RefuseWhileMoving();
        return Store.Update(id, poster => poster.Items.Count >= 6 || poster.Items.Any(item => item.ProductId == candidate.ProductId)
            ? poster
            : poster with { Items = poster.Items.Append(candidate.ToItem(poster.Kind.DefaultOfferPercent())).ToList() });
    }

    /// <summary>Goes back to the app's own design.</summary>
    public Poster? UsePlainDesign(string id)
    {
        RefuseWhileMoving();
        return Store.Update(id, poster => poster with { Artwork = null, ArtworkBy = null });
    }

    public bool Delete(string id)
    {
        RefuseWhileMoving();
        return Store.Delete(id);
    }

    /// <summary>Puts today's POS prices and rules on a saved poster, keeping each offer's percentage within the rules.</summary>
    public async Task<CheckedPoster?> UseTodaysPricesAsync(string id, CancellationToken ct)
    {
        RefuseWhileMoving();
        var now = await TodaysPricesAsync(ct);
        var updated = Store.Update(id, poster => poster with
        {
            Items = poster.Items
                .Select(item => now.TryGetValue(item.ProductId, out var today) ? PosterRecheck.Refresh(item, today.Price, today.Lowest) : item)
                .ToList(),
        });
        return updated is null ? null : await RecheckAsync(updated, ct);
    }

    /// <summary>Each product's price today and its lowest allowed offer under today's rules.</summary>
    private async Task<Dictionary<int, (decimal Price, decimal Lowest)>> TodaysPricesAsync(CancellationToken ct)
    {
        var rules = Rules;
        var prices = new Dictionary<int, (decimal Price, decimal Lowest)>();
        foreach (var product in await _facts.GetProductsAsync(ct))
        {
            var price = PosterPricing.CustomerPrice(product.SellingPrice, product.GstRatePercent, _shop.PricesIncludeTax);
            prices[product.Id] = (price, PosterPricing.LowestOffer(price, product.CostPrice, product.GstRatePercent, rules.MaxOfferPercent));
        }

        return prices;
    }

    private void RefuseWhileMoving()
    {
        if (_storage.IsMoving)
        {
            throw new PosterException("The data folder is being moved. Try again when the move is done.");
        }
    }

    /// <summary>Each product's newest white-background photo, for the poster's product cards.</summary>
    private IReadOnlyDictionary<int, string> WhitePhotos()
    {
        var photos = new Dictionary<int, string>();
        foreach (var (productId, info) in _photos.All())
        {
            var white = info.Sets.Select(set => set.Latest(PhotoKind.WhiteBackground)?.File).FirstOrDefault(file => file is not null);
            if (white is not null)
            {
                photos[productId] = white;
            }
        }

        return photos;
    }

    private string UniqueId(DateTime now, PosterKind kind)
    {
        var id = PosterStore.NewId(now, kind);
        while (Store.Load(id) is not null)
        {
            now = now.AddSeconds(1);
            id = PosterStore.NewId(now, kind);
        }

        return id;
    }

    private static string NothingFits(PosterKind kind) => kind switch
    {
        PosterKind.Clearance => "Nothing to clear: every product in stock has sold in the last 30 days.",
        PosterKind.NewArrivals => "No new products: none in stock was added to the POS in the last 30 days.",
        _ => "No product in stock has sold in the last 30 days.",
    };

    private static string? NullIfEmpty(string text) => text.Length == 0 ? null : text;
}

/// <summary>A poster that cannot be made, with the reason for staff.</summary>
public sealed class PosterException(string message) : Exception(message);
