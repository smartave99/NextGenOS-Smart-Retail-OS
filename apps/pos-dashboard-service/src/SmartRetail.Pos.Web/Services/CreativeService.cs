using System.Threading.Channels;
using Microsoft.Extensions.Options;
using SmartRetail.AI.Creatives;
using SmartRetail.AI.Products;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Creatives;

namespace SmartRetail.Pos.Web.Services;

/// <summary>A problem with a creative, in words for the owner.</summary>
public sealed class CreativeException(string message) : Exception(message);

/// <summary>A product for the brief editor: its name, photo and price as the POS has them.</summary>
/// <param name="Price">What the customer pays, with GST.</param>
/// <param name="InPos">False for a product deleted from the POS since it was put on the brief: it has no price and can
/// only be taken off.</param>
public sealed record CreativeProductInfo(int ProductId, string Name, string Code, string? Photo, bool HasPhoto, decimal Price, IReadOnlyList<decimal> OfferChoices, bool InPos = true);

/// <summary>The price tags a picture shows, worked out from the POS now, and what stops it being exported.</summary>
public sealed record CreativeTags(IReadOnlyList<PriceTag> Tags, IReadOnlyList<string> Problems);

/// <summary>
/// The Creatives studio. The owner writes a brief (format, style, products, words, background, pictures to take the
/// look from) and Codex's image tool designs the whole advertisement from it, leaving room for the prices; the app
/// adds every price itself, from the POS (<see cref="CreativePricing"/>). Each picture is kept with what it was made
/// from, can be changed with a few words (a new picture from the earlier one), chosen, and exported. Pictures are made
/// one at a time, in the background, and never while the data folder moves.
/// </summary>
public sealed class CreativeService
{
    private const long MaxPictureBytes = 15L * 1024 * 1024;

    private readonly CreativeStore _store;
    private readonly ProductPhotoService _photos;
    private readonly StorageService _storage;
    private readonly ISalesFactsRepository _facts;
    private readonly AiEnvironment _ai;
    private readonly ShopOptions _shop;
    private readonly TimeProvider _clock;
    private readonly ILogger<CreativeService> _log;
    private readonly Func<CreativeArtRequest, IProgress<string>, CancellationToken, Task<CreativeArtResult>> _make;
    private readonly Channel<(string Id, int Number)> _queue = Channel.CreateUnbounded<(string, int)>();
    private readonly object _gate = new();
    private readonly HashSet<(string Id, int Number)> _waiting = new();
    private readonly Dictionary<string, string> _status = new();
    private (string Id, int Number, CancellationTokenSource Cancel)? _current;

    public CreativeService(CreativeStore store, ProductPhotoService photos, StorageService storage, ISalesFactsRepository facts,
        AiEnvironment ai, IOptions<ShopOptions> shop, TimeProvider clock, ILogger<CreativeService> log)
        : this(store, photos, storage, facts, ai, shop, clock, log,
            (request, progress, ct) => ai.CreateCodex(AiJob.Creative).MakeCreativeAsync(request, progress, ct))
    {
    }

    internal CreativeService(CreativeStore store, ProductPhotoService photos, StorageService storage, ISalesFactsRepository facts,
        AiEnvironment ai, IOptions<ShopOptions> shop, TimeProvider clock, ILogger<CreativeService> log,
        Func<CreativeArtRequest, IProgress<string>, CancellationToken, Task<CreativeArtResult>> make)
    {
        _store = store;
        _photos = photos;
        _storage = storage;
        _facts = facts;
        _ai = ai;
        _shop = shop.Value;
        _clock = clock;
        _log = log;
        _make = make;
    }

    /// <summary>Raised with a creative's id when it changes, on a background thread.</summary>
    public event Action<string>? Changed;

    public CreativeStore Store => _store;

    /// <summary>True when no picture is being made or waits to be: the data folder may move.</summary>
    public bool IsIdle
    {
        get
        {
            lock (_gate)
            {
                return _current is null && _waiting.Count == 0;
            }
        }
    }

    /// <summary>What Codex is doing for the creative now, or that its picture waits for another; null when nothing is.</summary>
    public string? Status(string id)
    {
        lock (_gate)
        {
            if (_current is { } current && current.Id == id)
            {
                return _status.GetValueOrDefault(id) ?? "Starting Codex…";
            }

            if (!_waiting.Any(job => job.Id == id))
            {
                return null;
            }

            return _ai.LimitPause.Until is { } until
                ? $"Paused: Codex's usage limit was reached. This picture is made by itself at {UsageLimitPause.Describe(until, DateTimeOffset.Now)}."
                : "Waiting for the creative being made now…";
        }
    }

    /// <summary>True while the pictures wait for Codex's usage limit to lift.</summary>
    public bool IsWaitingForLimit => _ai.LimitPause.IsPaused;

    /// <summary>Stops waiting for the usage limit: the next picture is tried at once (e.g. the owner got more usage).</summary>
    public void TryNow() => _ai.LimitPause.Clear();

    public Task<ProviderStatus> CheckCodexAsync(CancellationToken ct) => _ai.CreateCodex().CheckAsync(ct);

    private DateTime Now => _clock.GetLocalNow().DateTime;

    private decimal MaxOfferPercent => _ai.LoadSettings().Posters.CheckedMaxOfferPercent;

    /// <summary>A new creative for the products (at most four), in the format; named after the first product.</summary>
    public CreativeProject Create(CreativeFormat format, IReadOnlyList<int> productIds, string? productName)
    {
        ArgumentNullException.ThrowIfNull(format);
        ArgumentNullException.ThrowIfNull(productIds);
        RefuseWhileMoving();
        var brief = new CreativeBrief
        {
            Format = format.Id,
            Products = productIds.Where(id => id > 0).Distinct().Take(CreativeBrief.MaxProducts).Select(id => new CreativeItem(id)).ToList(),
        };
        var title = string.IsNullOrWhiteSpace(productName) ? "New creative" : productName.Trim();
        return _store.Create(new CreativeProject { Title = Trim(title, 80), Brief = brief }, Now);
    }

    /// <summary>Saves the owner's changes to the brief and the title; words are checked when a picture is made.</summary>
    public CreativeProject SaveBrief(string id, string title, CreativeBrief brief)
    {
        ArgumentNullException.ThrowIfNull(brief);
        RefuseWhileMoving();
        var clean = brief with
        {
            Format = CreativeFormat.Find(brief.Format).Id,
            Style = CreativeStyle.Find(brief.Style).Id,
            Audience = Trim(CreativeWords.Tidy(brief.Audience), CreativeWords.MaxNotes),
            Headline = Trim(brief.Headline, CreativeWords.MaxHeadline),
            Subtitle = Trim(brief.Subtitle, CreativeWords.MaxLine),
            CallToAction = Trim(brief.CallToAction, CreativeWords.MaxLine),
            SmallPrint = Trim(brief.SmallPrint, CreativeWords.MaxLine),
            Background = Trim(brief.Background, CreativeWords.MaxNotes),
            Instructions = Trim(brief.Instructions, CreativeWords.MaxNotes),
            Products = brief.Products.Where(item => item.ProductId > 0).DistinctBy(item => item.ProductId).Take(CreativeBrief.MaxProducts).ToList(),
            References = brief.References.Where(CreativeStore.IsAssetName).Distinct().Take(CreativeBrief.MaxReferences).ToList(),
        };
        return _store.Update(id, project => project with { Title = Trim(string.IsNullOrWhiteSpace(title) ? project.Title : title, 80), Brief = clean }, Now)
            ?? throw new CreativeException("This creative was deleted.");
    }

    /// <summary>What stops a picture being made from the brief, in words for the owner; null when it can be made.</summary>
    public string? Problem(CreativeBrief brief)
    {
        ArgumentNullException.ThrowIfNull(brief);
        if (brief.Products.Count > CreativeBrief.MaxProducts)
        {
            return $"A creative shows at most {CreativeBrief.MaxProducts} products.";
        }

        return CreativeWords.Problem("The headline", brief.Headline, CreativeWords.MaxHeadline)
            ?? CreativeWords.Problem("The line under it", brief.Subtitle, CreativeWords.MaxLine)
            ?? CreativeWords.Problem("What to do", brief.CallToAction, CreativeWords.MaxLine)
            ?? CreativeWords.Problem("The small print", brief.SmallPrint, CreativeWords.MaxLine)
            ?? (CreativeWords.NameProblem("The shop's name", ShopName(_store.LoadBrand()), CreativeWords.MaxLine) is { } name
                ? name + " Change it under \"Your shop's brand\"."
                : null);
    }

    /// <summary>Makes a new picture from the creative's brief, in the background.</summary>
    public CreativeProject Make(string id)
    {
        var project = _store.Load(id) ?? throw new CreativeException("This creative was deleted.");
        if (Problem(project.Brief) is { } problem)
        {
            throw new CreativeException(problem);
        }

        return Start(id, project.NextNumber, null, "", project.Brief);
    }

    /// <summary>Makes a new picture from an earlier one, changed as the owner asks, in the background.</summary>
    public CreativeProject Change(string id, int from, string change)
    {
        var project = _store.Load(id) ?? throw new CreativeException("This creative was deleted.");
        var parent = project.Generation(from);
        if (parent is not { HasImage: true })
        {
            throw new CreativeException("Choose a picture that was made, then say what to change.");
        }

        var words = CreativeWords.Tidy(change);
        if (words.Length == 0)
        {
            throw new CreativeException("Say what to change, e.g. \"make the background deep blue\".");
        }

        if (CreativeWords.Problem("What to change", words, CreativeWords.MaxNotes, allowNumbers: true) is { } problem)
        {
            throw new CreativeException(problem);
        }

        return Start(id, project.NextNumber, from, words, parent.Brief);
    }

    private CreativeProject Start(string id, int number, int? parent, string change, CreativeBrief brief)
    {
        RefuseWhileMoving();
        CreativeProject? added;
        lock (_gate)
        {
            if ((_current is { } current && current.Id == id) || _waiting.Any(job => job.Id == id))
            {
                throw new CreativeException("A picture is being made for this creative already. Wait for it, or stop it.");
            }

            added = _store.Update(id, project => project with
            {
                Generations = project.Generations.Append(new CreativeGeneration
                {
                    Number = number,
                    Parent = parent,
                    Change = change,
                    Brief = brief,
                    Started = Now,
                }).ToList(),
            }, Now);
            if (added is null)
            {
                throw new CreativeException("This creative was deleted.");
            }

            _waiting.Add((id, number));
        }

        _queue.Writer.TryWrite((id, number));
        Raise(id);
        return added;
    }

    /// <summary>Stops the picture being made (or waiting) for the creative.</summary>
    public void Stop(string id)
    {
        List<int> waiting;
        lock (_gate)
        {
            if (_current is { } current && current.Id == id)
            {
                current.Cancel.Cancel();
            }

            waiting = _waiting.Where(job => job.Id == id).Select(job => job.Number).ToList();
            _waiting.RemoveWhere(job => job.Id == id);
        }

        foreach (var number in waiting)
        {
            Finish(id, number, generation => generation with { Problem = "Stopped before it began." });
        }

        Raise(id);
    }

    /// <summary>The picture to export and to show first.</summary>
    public CreativeProject Choose(string id, int number)
    {
        RefuseWhileMoving();
        return _store.Update(id, project => project.Generation(number) is { HasImage: true } ? project with { Chosen = number } : project, Now)
            ?? throw new CreativeException("This creative was deleted.");
    }

    /// <summary>Moves a price tag on a picture, kept inside it.</summary>
    public CreativeProject MoveTag(string id, int number, int index, double x, double y)
    {
        RefuseWhileMoving();
        return _store.Update(id, project =>
        {
            if (project.Generation(number) is not { } generation || index < 0 || index >= generation.Tags.Count)
            {
                return project;
            }

            var format = CreativeFormat.Find(generation.Brief.Format);
            var tags = generation.Tags.ToList();
            tags[index] = TagLayout.Clamp(new TagPlace(x, y), format);
            return project with { Generations = project.Generations.Select(g => g.Number == number ? g with { Tags = tags } : g).ToList() };
        }, Now) ?? throw new CreativeException("This creative was deleted.");
    }

    /// <summary>Deletes a creative with its pictures; not while one is being made for it.</summary>
    public void Delete(string id)
    {
        RefuseWhileMoving();
        if (Status(id) is not null)
        {
            throw new CreativeException("Stop the picture being made first.");
        }

        _store.Delete(id);
        Raise(id);
    }

    /// <summary>
    /// The products as the brief editor shows them, in the brief's order: name, photo, the POS price and the offers
    /// allowed. A product deleted from the POS since is still shown (<see cref="CreativeProductInfo.InPos"/>), so it can
    /// be taken off.
    /// </summary>
    public async Task<IReadOnlyList<CreativeProductInfo>> ProductsAsync(IReadOnlyList<int> productIds, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(productIds);
        if (productIds.Count == 0)
        {
            return Array.Empty<CreativeProductInfo>();
        }

        var facts = (await _facts.GetProductsAsync(ct)).Where(p => productIds.Contains(p.Id)).ToDictionary(p => p.Id);
        var photos = _photos.All();
        var limit = MaxOfferPercent;
        return productIds.Select(productId =>
        {
            var info = photos.GetValueOrDefault(productId);
            var thumbnail = info?.Thumbnail is { } file ? ProductPhotoService.Url(productId, file) : null;
            if (!facts.TryGetValue(productId, out var fact))
            {
                var name = string.IsNullOrWhiteSpace(info?.Name) ? "A product" : info.Name;
                return new CreativeProductInfo(productId, name, info?.Code ?? "", thumbnail, false, 0m, Array.Empty<decimal>(), InPos: false);
            }

            var tagFacts = new TagFacts(fact.Id, fact.Name, fact.SellingPrice, fact.CostPrice, fact.GstRatePercent);
            return new CreativeProductInfo(fact.Id, fact.Name, fact.Code,
                thumbnail,
                PhotoOf(info) is not null,
                Core.Posters.PosterPricing.CustomerPrice(fact.SellingPrice, fact.GstRatePercent, _shop.PricesIncludeTax),
                CreativePricing.OfferChoices(tagFacts, _shop.PricesIncludeTax, limit));
        }).ToList();
    }

    /// <summary>
    /// The price tags for a picture, from the POS as it is now: a tag for each product with a price, the owner's offer
    /// only while it keeps the rules. The problems (an offer that no longer does, a product gone) stop the export.
    /// </summary>
    public async Task<CreativeTags> TagsAsync(CreativeBrief brief, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(brief);
        if (!brief.ShowPrices || brief.Products.Count == 0)
        {
            return new CreativeTags(Array.Empty<PriceTag>(), Array.Empty<string>());
        }

        var facts = (await _facts.GetProductsAsync(ct)).ToDictionary(p => p.Id);
        var limit = MaxOfferPercent;
        var tags = new List<PriceTag>();
        var problems = new List<string>();
        foreach (var item in brief.Products)
        {
            if (!facts.TryGetValue(item.ProductId, out var fact))
            {
                problems.Add("A product on this creative is no longer in the POS. Take it off the creative.");
                continue;
            }

            var (tag, problem) = CreativePricing.Tag(new TagFacts(fact.Id, fact.Name, fact.SellingPrice, fact.CostPrice, fact.GstRatePercent),
                item.Offer, _shop.PricesIncludeTax, limit);
            if (tag is not null)
            {
                tags.Add(tag);
            }

            if (problem is not null)
            {
                problems.Add(problem);
            }
        }

        return new CreativeTags(tags, problems);
    }

    /// <summary>Keeps a picture the owner added to take the look from: JPEG, PNG or WebP by its first bytes, at most 15 MB.</summary>
    public async Task<string> AddReferenceAsync(string id, Stream picture, CancellationToken ct)
    {
        RefuseWhileMoving();
        var bytes = await ReadPictureAsync(picture, ct);
        return _store.AddReference(id, bytes, ImageFile.ExtensionOf(bytes)!, Now);
    }

    /// <summary>The shop's brand, with the shop's name from the POS when none was saved.</summary>
    public CreativeBrand Brand
    {
        get
        {
            var brand = _store.LoadBrand();
            return brand with { ShopName = ShopName(brand) };
        }
    }

    public void SaveBrand(CreativeBrand brand)
    {
        ArgumentNullException.ThrowIfNull(brand);
        RefuseWhileMoving();
        if (CreativeWords.NameProblem("The shop's name", brand.ShopName, CreativeWords.MaxLine) is { } problem)
        {
            throw new CreativeException(problem);
        }

        var saved = _store.LoadBrand();
        _store.SaveBrand(saved with
        {
            ShopName = CreativeWords.Tidy(brand.ShopName),
            Colours = brand.Colours.Select(TagLayout.CleanColour).OfType<string>().Distinct().Take(CreativeBrand.MaxColours).ToList(),
            Notes = Trim(brand.Notes, CreativeWords.MaxNotes),
        });
    }

    public async Task SaveLogoAsync(Stream picture, CancellationToken ct)
    {
        RefuseWhileMoving();
        var bytes = await ReadPictureAsync(picture, ct);
        var name = _store.SaveLogo(bytes, ImageFile.ExtensionOf(bytes)!, Now);
        _store.SaveBrand(_store.LoadBrand() with { Logo = name });
    }

    public void RemoveLogo()
    {
        RefuseWhileMoving();
        _store.SaveBrand(_store.LoadBrand() with { Logo = null });
    }

    /// <summary>Keeps an exported picture (a PNG drawn in the page) with the creative; gives its name.</summary>
    public async Task<string> SaveExportAsync(string id, int number, Stream png, CancellationToken ct)
    {
        RefuseWhileMoving();
        var project = _store.Load(id) ?? throw new CreativeException("This creative was deleted.");
        var generation = project.Generation(number) ?? throw new CreativeException("That picture is gone.");
        var bytes = await ReadPictureAsync(png, ct, 40L * 1024 * 1024);
        if (ImageFile.ExtensionOf(bytes) != ".png")
        {
            throw new CreativeException("The exported picture could not be read. Export it again.");
        }

        return _store.SaveExport(id, bytes, project.Title, CreativeFormat.Find(generation.Brief.Format).Id, number);
    }

    /// <summary>Runs until <paramref name="stopping"/>: makes the pictures waiting, one at a time.</summary>
    public async Task RunAsync(CancellationToken stopping)
    {
        MarkAbandoned();
        await foreach (var (id, number) in _queue.Reader.ReadAllAsync(stopping))
        {
            // Not while the data folder moves: the picture is written into it.
            while (_storage.IsMoving)
            {
                await Task.Delay(TimeSpan.FromSeconds(2), stopping);
            }

            // Nor while Codex's usage limit holds: the picture waits for the time Codex gave, then is made.
            await _ai.LimitPause.WaitAsync(stopping);
            await MakeAsync(id, number, stopping);
        }
    }

    /// <summary>Makes one picture that waits; false when there was none (for tests).</summary>
    internal async Task<bool> MakeNextAsync(CancellationToken stopping)
    {
        if (!_queue.Reader.TryRead(out var job))
        {
            return false;
        }

        await MakeAsync(job.Id, job.Number, stopping);
        return true;
    }

    /// <summary>Pictures still being made when the app last closed are marked as not made, except those that waited for Codex's usage
    /// limit: they wait for it again, and are made when it lifts.</summary>
    internal void MarkAbandoned()
    {
        foreach (var project in _store.Recent(int.MaxValue).Where(p => p.IsMaking))
        {
            foreach (var generation in project.Generations.Where(g => g.IsMaking))
            {
                if (generation.WaitingForLimit)
                {
                    lock (_gate)
                    {
                        _waiting.Add((project.Id, generation.Number));
                    }

                    _queue.Writer.TryWrite((project.Id, generation.Number));
                    continue;
                }

                Finish(project.Id, generation.Number, g => g with { Problem = "The app was closed before this picture was made. Make it again." });
            }
        }
    }

    private async Task MakeAsync(string id, int number, CancellationToken stopping)
    {
        using var cancel = CancellationTokenSource.CreateLinkedTokenSource(stopping);
        lock (_gate)
        {
            if (!_waiting.Remove((id, number)))
            {
                // Stopped before it began.
                return;
            }

            _current = (id, number, cancel);
            _status.Remove(id);
        }

        Raise(id);
        var started = Now;
        try
        {
            var project = _store.Load(id);
            if (project?.Generation(number) is not { IsMaking: true } generation)
            {
                return;
            }

            if (generation.WaitingForLimit)
            {
                project = _store.Update(id, p => p with
                {
                    Generations = p.Generations.Select(g => g.Number == number ? g with { WaitingForLimit = false } : g).ToList(),
                }, Now) ?? project;
            }

            var request = await ArtRequestAsync(project, generation, cancel.Token);
            var progress = new InlineProgress(message =>
            {
                lock (_gate)
                {
                    _status[id] = message;
                }

                Raise(id);
            });
            var result = await _make(request, progress, cancel.Token);
            cancel.Token.ThrowIfCancellationRequested();

            var format = CreativeFormat.Find(generation.Brief.Format);
            var tags = TagLayout.Place(request.PriceTags, result.PriceAreas.Select(a => (a.X, a.Y, a.Width, a.Height)).ToList(), format);
            if (_store.Load(id) is null)
            {
                // Deleted meanwhile: nothing is written.
                return;
            }

            _store.SaveResult(id, number, result.Image, result.Prompt, Describe(request));
            Finish(id, number, g => g with
            {
                HasImage = true,
                By = result.ProviderName,
                Notes = result.Notes,
                Seconds = Math.Round(result.Duration.TotalSeconds),
                Tags = tags,
            });
        }
        catch (OperationCanceledException) when (!stopping.IsCancellationRequested)
        {
            Finish(id, number, g => g with { Problem = "Stopped." });
        }
        catch (AiProviderException ex) when (ex.UsageLimit is { } limit && !stopping.IsCancellationRequested)
        {
            // Nothing failed: the picture is made when Codex can answer again, and everything waits until then.
            _log.LogInformation("Codex's usage limit was reached; the picture waits for it.");
            _ai.LimitPause.Hit(limit);
            _store.Update(id, project => project with
            {
                Generations = project.Generations.Select(g => g.Number == number ? g with { WaitingForLimit = true } : g).ToList(),
            }, Now);
            lock (_gate)
            {
                _waiting.Add((id, number));
            }

            _queue.Writer.TryWrite((id, number));
        }
        catch (Exception ex) when (ex is AiProviderException or CreativeException or ArgumentException or IOException or UnauthorizedAccessException or InvalidOperationException)
        {
            _log.LogWarning(ex, "A creative's picture could not be made.");
            Finish(id, number, g => g with { Problem = ex.Message, Seconds = Math.Round((Now - started).TotalSeconds) });
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            // Anything else stops this picture only: the next ones are still made.
            _log.LogError(ex, "A creative's picture failed unexpectedly.");
            Finish(id, number, g => g with { Problem = "The picture could not be made: " + ex.Message });
        }
        finally
        {
            lock (_gate)
            {
                _current = null;
                _status.Remove(id);
            }

            Raise(id);
        }
    }

    /// <summary>What Codex is given for a picture: the brief with the shop's brand, and the products' names and photos.</summary>
    internal async Task<CreativeArtRequest> ArtRequestAsync(CreativeProject project, CreativeGeneration generation, CancellationToken ct)
    {
        var brief = generation.Brief;
        var format = CreativeFormat.Find(brief.Format);
        var brand = Brand;
        var facts = (await _facts.GetProductsAsync(ct)).ToDictionary(p => p.Id);
        var photos = _photos.All();
        var products = brief.Products.Select(item =>
        {
            var info = photos.GetValueOrDefault(item.ProductId);
            var fact = facts.GetValueOrDefault(item.ProductId);
            var hasPrice = brief.ShowPrices && fact is not null
                && Core.Posters.PosterPricing.CustomerPrice(fact.SellingPrice, fact.GstRatePercent, _shop.PricesIncludeTax) > 0;
            return new CreativeArtProduct
            {
                Name = fact?.Name ?? info?.Name ?? "",
                WhatItIs = info?.Understanding?.WhatItIs ?? "",
                Photo = PhotoOf(info),
                HasPrice = hasPrice,
            };
        }).Where(product => product.Name.Length > 0).ToList();

        var previous = generation.Parent is { } parent ? _store.ResultPath(project.Id, parent) : null;
        if (generation.Parent is not null && previous is null)
        {
            throw new CreativeException("The picture to change is gone. Make a new one from the brief.");
        }

        return new CreativeArtRequest
        {
            FormatName = format.Name,
            FormatUse = format.Use,
            Width = format.Width,
            Height = format.Height,
            Style = CreativeStyle.Find(brief.Style).Brief,
            Audience = brief.Audience,
            ShopName = brand.ShopName,
            BrandColours = brand.Colours.ToList(),
            BrandNotes = brand.Notes,
            Logo = _store.LogoPath(brand.Logo),
            Headline = brief.Headline,
            Subtitle = brief.Subtitle,
            CallToAction = brief.CallToAction,
            SmallPrint = brief.SmallPrint,
            Background = brief.Background,
            Instructions = brief.Instructions,
            Products = products,
            References = brief.References.Select(name => _store.AssetPath(project.Id, name)).OfType<string>().ToList(),
            Previous = previous,
            Change = generation.Change,
        };
    }

    /// <summary>The request as kept with the picture: the words and choices, with file names instead of paths.</summary>
    private static object Describe(CreativeArtRequest request) => new
    {
        request.FormatName,
        request.Width,
        request.Height,
        request.Style,
        request.Audience,
        request.ShopName,
        request.BrandColours,
        request.BrandNotes,
        Logo = request.Logo is null ? null : Path.GetFileName(request.Logo),
        request.Headline,
        request.Subtitle,
        request.CallToAction,
        request.SmallPrint,
        request.Background,
        request.Instructions,
        Products = request.Products.Select(p => new { p.Name, p.WhatItIs, Photo = p.Photo is null ? null : Path.GetFileName(p.Photo), p.HasPrice }),
        References = request.References.Select(Path.GetFileName),
        Previous = request.Previous is null ? null : Path.GetFileName(request.Previous),
        request.Change,
    };

    /// <summary>The photo that shows the product best: its newest white-background photo, else its newest phone photo.</summary>
    private string? PhotoOf(ProductPhotoInfo? info)
    {
        if (info is null)
        {
            return null;
        }

        var white = info.Sets.Select(set => set.Latest(PhotoKind.WhiteBackground)?.File).FirstOrDefault(file => file is not null);
        var file = white ?? info.LatestSet?.RawFiles.FirstOrDefault();
        return file is null ? null : _photos.Store.PathOf(info.ProductId, file);
    }

    private void Finish(string id, int number, Func<CreativeGeneration, CreativeGeneration> change) =>
        _store.Update(id, project => project with
        {
            Generations = project.Generations.Select(g => g.Number == number ? change(g) with { Finished = Now } : g).ToList(),
        }, Now);

    private async Task<byte[]> ReadPictureAsync(Stream picture, CancellationToken ct, long max = MaxPictureBytes)
    {
        ArgumentNullException.ThrowIfNull(picture);
        using var copy = new MemoryStream();
        var buffer = new byte[81920];
        int read;
        while ((read = await picture.ReadAsync(buffer, ct)) > 0)
        {
            if (copy.Length + read > max)
            {
                throw new CreativeException($"The picture is larger than {max / 1024 / 1024} MB.");
            }

            copy.Write(buffer, 0, read);
        }

        var bytes = copy.ToArray();
        return ImageFile.ExtensionOf(bytes) is null
            ? throw new CreativeException("That is not a JPG, PNG or WEBP picture.")
            : bytes;
    }

    private string ShopName(CreativeBrand brand) => string.IsNullOrWhiteSpace(brand.ShopName) ? _shop.Name : brand.ShopName;

    private void RefuseWhileMoving()
    {
        if (_storage.IsMoving)
        {
            throw new CreativeException("The data folder is being moved. Try again when the move is done.");
        }
    }

    private void Raise(string id)
    {
        try
        {
            Changed?.Invoke(id);
        }
        catch (Exception ex)
        {
            _log.LogWarning(ex, "A creative's screen could not be told of a change.");
        }
    }

    private static string Trim(string? text, int max)
    {
        var tidy = (text ?? "").Trim();
        return tidy.Length > max ? tidy[..max].TrimEnd() : tidy;
    }

    private sealed class InlineProgress(Action<string> report) : IProgress<string>
    {
        public void Report(string value) => report(value);
    }
}
