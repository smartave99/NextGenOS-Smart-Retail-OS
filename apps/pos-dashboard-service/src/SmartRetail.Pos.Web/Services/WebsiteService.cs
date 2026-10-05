using SmartRetail.AI.Products;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;

namespace SmartRetail.Pos.Web.Services;

/// <summary>Where the products offered to the owner's website stand, for Settings.</summary>
public sealed record WebsiteStatus
{
    /// <summary>This PC is connected to the owner's project and offering products is switched on.</summary>
    public bool Enabled { get; init; }

    public bool Working { get; init; }

    /// <summary>On the website's waiting list while their photos arrive.</summary>
    public int Sending { get; init; }

    /// <summary>On the website's waiting list for the owner's decision.</summary>
    public int Waiting { get; init; }

    /// <summary>Approved by the owner on the website.</summary>
    public int Published { get; init; }

    /// <summary>Declined by the owner on the website.</summary>
    public int Declined { get; init; }

    /// <summary>Finished, with a category, and next to be offered.</summary>
    public int ReadyToOffer { get; init; }

    /// <summary>Finished but without a category of the website yet.</summary>
    public int NeedsCategory { get; init; }

    /// <summary>The waiting list is full: more are offered once the owner has decided on some.</summary>
    public bool ListFull { get; init; }

    /// <summary>How many categories of the website this PC knows; none until the website's admin has sent them.</summary>
    public int Categories { get; init; }

    public DateTimeOffset? LastRunAt { get; init; }

    /// <summary>How many times the waiting list was looked at since offering products was turned on; the page keeps it in <c>data-runs</c>,
    /// so a test can tell that a look it asked for is over.</summary>
    public int Runs { get; init; }

    /// <summary>Why the last try did not work, in words for the owner; null when it did.</summary>
    public string? Problem { get; init; }
}

/// <summary>What the website's waiting list says about one product, for its page: <see cref="Kind"/> is <c>sending</c>, <c>waiting</c>,
/// <c>published</c>, <c>declined</c>, <c>soon</c> (to be offered next) or <c>blocked</c> (not yet, with the reason as the text).</summary>
public sealed record ProductSiteState(string Kind, string Text);

/// <summary>
/// Offers the finished products to the owner's website, when the owner turned that on. A product is finished when its photos and
/// listing are made; the website needs a category for it, so one is chosen from the website's own list (the AI that looked at the photos
/// chooses; the owner can change it). The offer carries the listing's words, the photos and the POS's prices, and waits in the owner's
/// Supabase project, at most 25 at a time, until the owner approves it on the website: nothing is published by this PC.
/// </summary>
public sealed class WebsiteService
{
    /// <summary>The waiting list is looked at again this often, for new prices and the owner's decisions.</summary>
    public static readonly TimeSpan RunEvery = TimeSpan.FromMinutes(10);

    /// <summary>After a problem, a new try is made after this.</summary>
    public static readonly TimeSpan RetryAfterProblem = TimeSpan.FromMinutes(5);

    /// <summary>When a photo or listing finished, a run follows at once, but not more often than this.</summary>
    private static readonly TimeSpan LeastGap = TimeSpan.FromMinutes(1);

    private static readonly TimeSpan CategoriesEvery = TimeSpan.FromMinutes(15);
    private static readonly TimeSpan NothingFitsWait = TimeSpan.FromHours(6);
    private static readonly TimeSpan AiFailedWait = TimeSpan.FromMinutes(30);
    private const int AiPerRound = 4;

    private readonly AiEnvironment _ai;
    private readonly OwnerViewService _owner;
    private readonly OwnerViewClient _client;
    private readonly ProductPhotoService _photos;
    private readonly ISalesFactsRepository _facts;
    private readonly StorageService _storage;
    private readonly TimeProvider _clock;
    private readonly ILogger<WebsiteService> _log;
    private readonly SemaphoreSlim _gate = new(1, 1);
    private readonly Dictionary<int, DateTimeOffset> _noCategoryUntil = new();
    private SiteCategoryList _categories = SiteCategoryList.Empty;
    private DateTimeOffset _categoriesAt;
    private DateTimeOffset _nextRun;
    private DateTimeOffset _lastRun;
    private bool _wasEnabled;
    private volatile bool _dirty = true;
    private IReadOnlyDictionary<int, ProductSiteState> _per = new Dictionary<int, ProductSiteState>();

    public WebsiteService(AiEnvironment ai, OwnerViewService owner, OwnerViewClient client, ProductPhotoService photos,
        ISalesFactsRepository facts, StorageService storage, TimeProvider clock, ILogger<WebsiteService> log)
    {
        _ai = ai;
        _owner = owner;
        _client = client;
        _photos = photos;
        _facts = facts;
        _storage = storage;
        _clock = clock;
        _log = log;
        // A product's photos or listing were made or changed: the website is looked at again soon.
        _photos.Changed += _ => _dirty = true;
    }

    public event Action? Changed;

    public WebsiteStatus Status { get; private set; } = new();

    /// <summary>The website's categories as this PC last read them; empty until the website's admin has sent them.</summary>
    public SiteCategoryList Categories => _categories;

    /// <summary>Whether offering products to the website is switched on (and the PC is connected).</summary>
    public bool Enabled => _owner.Settings is { IsConnected: true, SendProducts: true };

    public ProductSiteState? StateOf(int productId) => _per.TryGetValue(productId, out var state) ? state : null;

    /// <summary>Switches offering products to the website on or off. Products already on the waiting list stay there for the owner.</summary>
    public void SetSendProducts(bool on)
    {
        _owner.SaveSettings(s => s.SendProducts = on);
        _dirty = true;
        _nextRun = default;
        Update(on ? Status : new WebsiteStatus());
    }

    /// <summary>Called every few seconds by <see cref="WebsiteWorker"/>: works when it is time.</summary>
    public async Task TickAsync(CancellationToken ct)
    {
        var settings = _owner.Settings;
        var enabled = settings.IsConnected && settings.SendProducts && _owner.HasShopData && _owner.Status.MainPc is null;
        if (!enabled)
        {
            _wasEnabled = false;
            if (Status.Enabled)
            {
                Update(new WebsiteStatus());
            }

            return;
        }

        if (_storage.IsMoving)
        {
            return;
        }

        var now = _clock.GetUtcNow();
        if (!_wasEnabled)
        {
            _wasEnabled = true;
            _dirty = true;
        }

        if ((_dirty && now - _lastRun >= LeastGap) || now >= _nextRun)
        {
            await RunAsync(ct).ConfigureAwait(false);
        }
    }

    /// <summary>Looks at the waiting list and offers what is ready, now (the Settings button).</summary>
    public Task RunNowAsync(CancellationToken ct = default) => RunAsync(ct, force: true);

    /// <summary>Asks the website's list for its categories now. False when the website has not sent any yet.</summary>
    public async Task<bool> RefreshCategoriesAsync(CancellationToken ct = default)
    {
        var settings = _owner.Settings;
        if (!settings.IsConnected || _owner.DeviceKey() is not { } key)
        {
            return false;
        }

        await ReadCategoriesAsync(settings, key, ct).ConfigureAwait(false);
        return !_categories.IsEmpty;
    }

    /// <summary>The owner chose where the product goes on the website.</summary>
    public bool SetCategory(int productId, string categoryId)
    {
        var choice = WebsiteCategoryChoice.Of(_categories, categoryId, WebsiteCategoryChoice.ByOwner, _clock.GetLocalNow().DateTime);
        if (choice is null || _photos.Info(productId) is null)
        {
            return false;
        }

        _photos.Store.SaveWebsiteCategory(productId, choice);
        _noCategoryUntil.Remove(productId);
        _dirty = true;
        Changed?.Invoke();
        return true;
    }

    /// <summary>Lets the AI choose the product's category from the website's list now (the owner pressed the button). With no AI tool ready, the
    /// nearest category its first guess names. Null when one was chosen; else why not, in words for the owner.</summary>
    public async Task<string?> ChooseAsync(int productId, CancellationToken ct = default)
    {
        if (_categories.IsEmpty)
        {
            return "Your website's categories have not reached this PC yet. Open From the shop in your website's admin once.";
        }

        var info = _photos.Info(productId);
        if (info is null)
        {
            return "This product has no photos yet.";
        }

        if (WebsiteOffers.NotFinished(info) is { } unfinished)
        {
            return unfinished;
        }

        try
        {
            SiteCategory? chosen;
            var source = WebsiteCategoryChoice.ByAi;
            if (await AiReadyAsync(ct).ConfigureAwait(false))
            {
                var product = (await ProductsByIdAsync(ct).ConfigureAwait(false)).GetValueOrDefault(productId);
                chosen = await AskAiAsync(info, product, ct).ConfigureAwait(false);
                if (chosen is null)
                {
                    return "Nothing in your website's list fits this product. Choose one yourself.";
                }
            }
            else
            {
                source = WebsiteCategoryChoice.ByMatch;
                chosen = CategoryMatcher.Find(_categories, true, info.Listing?.Website?.Category, info.Understanding?.SuggestedCategory, info.Understanding?.ProductType);
                if (chosen is null)
                {
                    return "No AI tool is ready to choose, and the first guess names none of your website's categories. Choose one yourself.";
                }
            }

            Save(info, chosen, source);
            return null;
        }
        catch (AiProviderException ex) when (ex.UsageLimit is { } limit)
        {
            _ai.LimitPause.Hit(limit);
            return limit.Message;
        }
        catch (AiProviderException ex)
        {
            return "The AI could not choose: " + ex.Message;
        }
    }

    /// <summary>Offers a product the owner declined once more (the owner changed their mind). Null when it was; else why not.</summary>
    public async Task<string?> OfferAgainAsync(int productId, CancellationToken ct = default)
    {
        var settings = _owner.Settings;
        if (!settings.IsConnected || _owner.DeviceKey() is not { } key)
        {
            return "This PC is not connected to your Supabase project.";
        }

        var info = _photos.Info(productId);
        var product = (await ProductsByIdAsync(ct).ConfigureAwait(false)).GetValueOrDefault(productId);
        if (info is null || product is null)
        {
            return "The product is not in the POS any more.";
        }

        var facts = await _photos.ListingFactsAsync(product, ct).ConfigureAwait(false);
        var result = WebsiteOffers.Build(info, facts, _categories, name => _photos.Store.PathOf(productId, name));
        if (result.Offer is not { } offer)
        {
            return result.Why;
        }

        try
        {
            await new WebsiteSender(new SupabaseWebsite(_client, settings.ProjectUrl, settings.PublicKey, key)).OfferAgainAsync(offer, ct).ConfigureAwait(false);
        }
        catch (OwnerViewException ex)
        {
            return ex.Message;
        }

        _dirty = true;
        _nextRun = default;
        return null;
    }

    private async Task RunAsync(CancellationToken ct, bool force = false)
    {
        if (!await _gate.WaitAsync(force ? TimeSpan.FromSeconds(30) : TimeSpan.Zero, ct).ConfigureAwait(false))
        {
            return;
        }

        var now = _clock.GetUtcNow();
        try
        {
            var settings = _owner.Settings;
            if (!settings.IsConnected || !settings.SendProducts)
            {
                return;
            }

            if (_owner.DeviceKey() is not { } key)
            {
                Update(Status with { Enabled = true, Working = false, Problem = "This PC's key could not be read. Connect it again with a new code." });
                _nextRun = now + RetryAfterProblem;
                return;
            }

            _dirty = false;
            _lastRun = now;
            Update(Status with { Enabled = true, Working = true, Problem = null });
            var site = new SupabaseWebsite(_client, settings.ProjectUrl, settings.PublicKey, key);

            if (force || now - _categoriesAt >= CategoriesEvery || _categories.IsEmpty)
            {
                await ReadCategoriesAsync(settings, key, ct).ConfigureAwait(false);
            }

            var products = await ProductsByIdAsync(ct).ConfigureAwait(false);
            await ChooseCategoriesAsync(products, now, ct).ConfigureAwait(false);

            var infos = _photos.All();
            var facts = await _photos.ListingFactsAsync(
                infos.Values.Where(info => WebsiteOffers.NotFinished(info) is null).Select(info => products.GetValueOrDefault(info.ProductId)).OfType<ProductFacts>().ToList(),
                ct).ConfigureAwait(false);
            var offers = new List<WebsiteOffer>();
            var blocked = new Dictionary<int, string>();
            foreach (var info in infos.Values)
            {
                if (!facts.TryGetValue(info.ProductId, out var listingFacts))
                {
                    blocked[info.ProductId] = WebsiteOffers.NotFinished(info) ?? "The POS does not have this product any more.";
                    continue;
                }

                var result = WebsiteOffers.Build(info, listingFacts, _categories, name => _photos.Store.PathOf(info.ProductId, name));
                if (result.Offer is { } offer)
                {
                    offers.Add(offer);
                }
                else
                {
                    blocked[info.ProductId] = result.Why!;
                }
            }

            offers = offers.OrderBy(offer => infos[offer.ProductId].LatestSet?.Started).ThenBy(offer => offer.ProductId).ToList();
            var onList = await site.StatesAsync(ct).ConfigureAwait(false);
            var withdraw = onList
                .Where(state => state.State is "sending" or "waiting")
                .Where(state => !int.TryParse(state.Product, System.Globalization.NumberStyles.None, System.Globalization.CultureInfo.InvariantCulture, out var id)
                    || !infos.TryGetValue(id, out var info) || WebsiteOffers.NotFinished(info) is not null)
                .Select(state => state.Product)
                .ToList();

            var round = await new WebsiteSender(site).RunAsync(offers, onList, withdraw, ct).ConfigureAwait(false);
            if (round.Offered > 0 || round.Withdrawn.Count > 0)
            {
                onList = await site.StatesAsync(ct).ConfigureAwait(false);
            }

            Describe(infos, offers, blocked, onList, round, now);
            _nextRun = now + (round.Problem is null ? RunEvery : RetryAfterProblem);
            if (round.Offered >= WebsiteSender.PerRound)
            {
                // There may be more to offer: the next try is soon.
                _dirty = true;
            }
        }
        catch (OwnerViewException ex)
        {
            _log.LogWarning(ex, "Offering products to the website failed.");
            Update(Status with { Working = false, Problem = ex.Message, LastRunAt = now, Runs = Status.Runs + 1 });
            _nextRun = now + RetryAfterProblem;
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            _log.LogError(ex, "Offering products to the website failed.");
            Update(Status with { Working = false, Problem = "The products could not be read from the POS to offer them. It will be tried again.", LastRunAt = now, Runs = Status.Runs + 1 });
            _nextRun = now + RetryAfterProblem;
        }
        finally
        {
            _gate.Release();
        }
    }

    private void Describe(IReadOnlyDictionary<int, ProductPhotoInfo> infos, IReadOnlyList<WebsiteOffer> offers, IReadOnlyDictionary<int, string> blocked,
        IReadOnlyList<SiteProductState> onList, WebsiteRound round, DateTimeOffset now)
    {
        var states = onList.Where(state => int.TryParse(state.Product, System.Globalization.NumberStyles.None, System.Globalization.CultureInfo.InvariantCulture, out _))
            .ToDictionary(state => int.Parse(state.Product, System.Globalization.CultureInfo.InvariantCulture), state => state);
        var per = new Dictionary<int, ProductSiteState>();
        var ready = 0;
        var needsCategory = 0;
        foreach (var info in infos.Values)
        {
            var offer = offers.FirstOrDefault(o => o.ProductId == info.ProductId);
            if (states.TryGetValue(info.ProductId, out var onTheList))
            {
                per[info.ProductId] = onTheList.State switch
                {
                    "sending" => new ProductSiteState("sending", "Being sent to your website."),
                    "waiting" => new ProductSiteState("waiting", "Waiting for your approval on your website."),
                    "published" => new ProductSiteState("published", "Approved: it is on your website."),
                    _ => new ProductSiteState("declined", "You declined it on your website."),
                };
                if (offer is not null && onTheList.State == "published" && WebsiteSender.Plan(offer, onTheList) == OfferPlan.Send)
                {
                    ready++;
                    per[info.ProductId] = new ProductSiteState("soon", "On your website. Its price or words changed, so it will be offered again for your approval.");
                }

                continue;
            }

            if (offer is not null)
            {
                ready++;
                per[info.ProductId] = new ProductSiteState("soon", round.ListFull
                    ? "Waiting for room on your website's list: decide on some products there first."
                    : "Ready: it will be offered to your website soon.");
            }
            else if (blocked.TryGetValue(info.ProductId, out var why))
            {
                if (WebsiteOffers.NotFinished(info) is null && why.Contains("categor", StringComparison.OrdinalIgnoreCase))
                {
                    needsCategory++;
                }

                per[info.ProductId] = new ProductSiteState("blocked", why);
            }
        }

        _per = per;
        Update(new WebsiteStatus
        {
            Enabled = true,
            Working = false,
            Sending = onList.Count(state => state.State == "sending"),
            Waiting = onList.Count(state => state.State == "waiting"),
            Published = onList.Count(state => state.State == "published"),
            Declined = onList.Count(state => state.State == "declined"),
            ReadyToOffer = ready,
            NeedsCategory = needsCategory,
            ListFull = round.ListFull,
            Categories = _categories.All.Count,
            LastRunAt = now,
            Runs = Status.Runs + 1,
            Problem = round.Problem ?? (round.Failed.Count > 0
                ? $"{round.Failed.Count} product{(round.Failed.Count == 1 ? "" : "s")} could not be offered because of a photo that could not be read. It will be tried again."
                : null),
        });
    }

    private async Task ReadCategoriesAsync(OwnerViewSettings settings, string key, CancellationToken ct)
    {
        var list = await _client.SiteCategoriesAsync(settings.ProjectUrl, settings.PublicKey, key, ct).ConfigureAwait(false);
        _categoriesAt = _clock.GetUtcNow();
        if (list is { IsEmpty: false })
        {
            if (list.UpdatedAt != _categories.UpdatedAt)
            {
                // The website's list changed: products that found nothing to fit are looked at again.
                _noCategoryUntil.Clear();
            }

            _categories = list;
        }
    }

    private async Task<Dictionary<int, ProductFacts>> ProductsByIdAsync(CancellationToken ct) =>
        (await _facts.GetProductsAsync(ct).ConfigureAwait(false)).GroupBy(product => product.Id).ToDictionary(group => group.Key, group => group.First());

    /// <summary>Gives every finished product without a (valid) category of the website one, when it can be chosen: the AI's first guess if it
    /// names a category of the website; else the AI, from the website's list (a few at a time, and not while Codex is at its usage limit);
    /// else, with no AI tool ready, the nearest category the first guess names. What fits nothing is left to the owner, and looked at
    /// again after hours, or when the website sends a changed list.</summary>
    private async Task ChooseCategoriesAsync(IReadOnlyDictionary<int, ProductFacts> products, DateTimeOffset now, CancellationToken ct)
    {
        if (_categories.IsEmpty)
        {
            return;
        }

        bool? aiReady = null;
        var asked = 0;
        foreach (var info in _photos.All().Values.OrderBy(info => info.LatestSet?.Started))
        {
            if (WebsiteOffers.NotFinished(info) is not null
                || (info.WebsiteCategory is { } have && have.IsValidIn(_categories))
                || (_noCategoryUntil.TryGetValue(info.ProductId, out var until) && until > now))
            {
                continue;
            }

            if (Guess(info) is { } named)
            {
                Save(info, named, WebsiteCategoryChoice.ByMatch);
                continue;
            }

            aiReady ??= await AiReadyAsync(ct).ConfigureAwait(false);
            if (aiReady != true)
            {
                var nearest = CategoryMatcher.Find(_categories, true, info.Listing?.Website?.Category, info.Understanding?.SuggestedCategory, info.Understanding?.ProductType);
                if (nearest is null)
                {
                    _noCategoryUntil[info.ProductId] = now + NothingFitsWait;
                }
                else
                {
                    Save(info, nearest, WebsiteCategoryChoice.ByMatch);
                }

                continue;
            }

            if (_ai.LimitPause.IsPaused || asked >= AiPerRound)
            {
                continue;
            }

            asked++;
            try
            {
                if (await AskAiAsync(info, products.GetValueOrDefault(info.ProductId), ct).ConfigureAwait(false) is { } chosen)
                {
                    Save(info, chosen, WebsiteCategoryChoice.ByAi);
                }
                else
                {
                    _noCategoryUntil[info.ProductId] = now + NothingFitsWait;
                }
            }
            catch (AiProviderException ex) when (ex.UsageLimit is { } limit)
            {
                _ai.LimitPause.Hit(limit);
                return;
            }
            catch (AiProviderException ex)
            {
                _log.LogWarning(ex, "The AI could not choose a website category for product {Id}.", info.ProductId);
                _noCategoryUntil[info.ProductId] = now + AiFailedWait;
            }
        }
    }

    /// <summary>The category the AI's first guess (written while it looked at the photos) names, if it names one of the website's.</summary>
    private SiteCategory? Guess(ProductPhotoInfo info) =>
        CategoryMatcher.Find(_categories, false, info.Listing?.Website?.Category, info.Understanding?.SuggestedCategory, info.Understanding?.ProductType);

    private async Task<SiteCategory?> AskAiAsync(ProductPhotoInfo info, ProductFacts? product, CancellationToken ct)
    {
        var listing = info.Listing!;
        var understanding = info.Understanding;
        var shopCategory = product is null ? info.Category : string.Join(" > ", new[] { product.Category, product.SubCategory }.Where(part => !string.IsNullOrWhiteSpace(part)));
        var about = new CategoryProduct
        {
            Name = listing.PublicName,
            WhatItIs = understanding?.WhatItIs ?? "",
            Description = listing.Website?.Description ?? understanding?.Description ?? "",
            ProductType = understanding?.ProductType ?? "",
            Keywords = (understanding?.Keywords?.Count > 0 ? understanding.Keywords : listing.Website?.Tags) ?? new List<string>(),
            SuggestedCategory = listing.Website?.Category ?? understanding?.SuggestedCategory ?? "",
            PosCategory = shopCategory,
        };
        var router = _ai.CreateRouter(AiJob.WebsiteCategory);
        var response = await router.CompleteAsync(
            new AiRequest { SystemPrompt = CategoryPrompt.SystemPrompt, UserPrompt = CategoryPrompt.UserPrompt(about, _categories) },
            ProviderIds.Auto, ct).ConfigureAwait(false);
        return CategoryPrompt.ReadAnswer(response.Text, _categories);
    }

    private async Task<bool> AiReadyAsync(CancellationToken ct)
    {
        var router = _ai.CreateRouter(AiJob.WebsiteCategory);
        foreach (var provider in router.PlanOrder(ProviderIds.Auto))
        {
            if ((await router.GetStatusAsync(provider, refresh: false, ct).ConfigureAwait(false)).IsReady)
            {
                return true;
            }
        }

        return false;
    }

    private void Save(ProductPhotoInfo info, SiteCategory chosen, string source)
    {
        if (WebsiteCategoryChoice.Of(_categories, chosen.Id, source, _clock.GetLocalNow().DateTime) is { } choice)
        {
            _photos.Store.SaveWebsiteCategory(info.ProductId, choice);
            _noCategoryUntil.Remove(info.ProductId);
            _dirty = true;
            Changed?.Invoke();
        }
    }

    private void Update(WebsiteStatus status)
    {
        Status = status;
        Changed?.Invoke();
    }
}

/// <summary>Looks at the website's waiting list every 30 seconds, and offers the finished products when it is time.</summary>
public sealed class WebsiteWorker : BackgroundService
{
    private static readonly TimeSpan LookEvery = TimeSpan.FromSeconds(30);

    private readonly WebsiteService _website;
    private readonly ILogger<WebsiteWorker> _log;

    public WebsiteWorker(WebsiteService website, ILogger<WebsiteWorker> log)
    {
        _website = website;
        _log = log;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            // Let the app finish starting first.
            await Task.Delay(TimeSpan.FromSeconds(20), stoppingToken).ConfigureAwait(false);
            using var timer = new PeriodicTimer(LookEvery);
            do
            {
                try
                {
                    await _website.TickAsync(stoppingToken).ConfigureAwait(false);
                }
                catch (Exception ex) when (ex is not OperationCanceledException)
                {
                    _log.LogWarning(ex, "Offering products to the website failed.");
                }
            }
            while (await timer.WaitForNextTickAsync(stoppingToken).ConfigureAwait(false));
        }
        catch (OperationCanceledException)
        {
        }
    }
}
