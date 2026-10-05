using System.IO.Compression;
using System.Text;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;
using SmartRetail.AI.Products;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using SmartRetail.AI.Storage;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Core.Labels;
using SmartRetail.Pos.Core.Posters;

namespace SmartRetail.Pos.Web.Services;

/// <summary>Where a product's photos stand, for the screens.</summary>
public sealed record PhotoProgress(PhotoWork? Making, int PlaceInQueue, string? Problem, int Made, int Pending)
{
    public static readonly PhotoProgress None = new(null, 0, null, 0, 0);

    public bool Busy => Making is not null || PlaceInQueue > 0;
}

/// <summary>A product waiting for its turn to have photos made: how many photos, and whether its listings are written too.</summary>
public sealed record QueuedProduct(int ProductId, string Name, int Photos, bool Listing);

/// <summary>
/// What the AI is making now and what comes next, across every product, so the owner can see which photo of which product is being
/// made, what follows it, and what waits. <see cref="NextKinds"/> are the rest of the product being made, in order.
/// </summary>
public sealed record PhotoQueue(PhotoWork? Now, string NowName, IReadOnlyList<PhotoKind> NextKinds, bool ListingNext, IReadOnlyList<QueuedProduct> Waiting)
{
    public static readonly PhotoQueue Empty = new(null, "", Array.Empty<PhotoKind>(), false, Array.Empty<QueuedProduct>());

    public bool IsEmpty => Now is null && Waiting.Count == 0;

    /// <summary>When Codex's usage limit was reached, the time the work carries on by itself; null while it is not waiting for the limit.</summary>
    public DateTimeOffset? PausedUntil { get; init; }

    /// <summary>The photos still to be made in all: the rest of the product being made, and the waiting products' (each a full set at most).</summary>
    public int PhotosLeft => (Now is { IsListing: false } ? 1 : 0) + NextKinds.Count + Waiting.Sum(waiting => waiting.Photos);
}

/// <summary>
/// Product photos: the owner adds phone photos of a product, and Codex's image tool (ChatGPT Images) makes five photos
/// from them, one by one, in the background: white background, in use, and with a European, an Indian and an East
/// Asian model. Right after the first photo Codex also writes the product's listings for Amazon and the website, once:
/// they are kept, and written again only when the owner asks. Everything is kept in the data folder the owner chose,
/// never in the POS database; prices and barcodes in the listings' files come from the POS.
/// </summary>
public sealed class ProductPhotoService
{
    public const long MaxUploadBytes = 15L * 1024 * 1024;

    /// <summary>Room to leave on the drive beyond the photos themselves.</summary>
    public const long SpareBytes = 100L * 1024 * 1024;

    private readonly AiEnvironment _ai;
    private readonly StorageService _storage;
    private readonly ISalesFactsRepository _facts;
    private readonly IProductRepository _products;
    private readonly ShopOptions _shop;
    private readonly TimeProvider _clock;
    private readonly ILogger<ProductPhotoService> _log;

    public ProductPhotoService(AiEnvironment ai, StorageService storage, ISalesFactsRepository facts, IProductRepository products,
        IOptions<ShopOptions> shop, TimeProvider clock, ILogger<ProductPhotoService> log)
    {
        _ai = ai;
        _storage = storage;
        _facts = facts;
        _products = products;
        _shop = shop.Value;
        _clock = clock;
        _log = log;
        Store = new ProductPhotoStore(() => storage.ProductsFolder);
        Maker = new ProductPhotoMaker(
            Store,
            (request, ct) => _ai.CreateCodex(AiJob.Photos).MakeProductPhotoAsync(request, null, ct),
            () => Now,
            (request, ct) => _ai.CreateCodex(AiJob.Listing).WriteProductListingAsync(request, ct),
            PhotoFitter.Fit,
            ai.LimitPause);
        Maker.Error += ex => log.LogError(ex, "Making product photos failed.");
    }

    public ProductPhotoStore Store { get; }

    public ProductPhotoMaker Maker { get; }

    /// <summary>Raised with the product id whenever its photos change, on a background thread.</summary>
    public event Action<int> Changed
    {
        add => Maker.Changed += value;
        remove => Maker.Changed -= value;
    }

    private DateTime Now => _clock.GetLocalNow().DateTime;

    public Task<ProviderStatus> CheckCodexAsync(CancellationToken ct) => _ai.CreateCodex().CheckAsync(ct);

    /// <summary>Keeps the phone photos and starts making the five photos from them.</summary>
    public async Task<PhotoSet> UploadAsync(ProductFacts product, IReadOnlyList<IBrowserFile> files, CancellationToken ct)
    {
        NotWhileMoving();
        CheckCount(files.Count);
        foreach (var file in files)
        {
            if (!ProductPhotoRequest.PhotoExtensions.Contains(Path.GetExtension(file.Name).ToLowerInvariant()))
            {
                throw new InvalidOperationException($"{file.Name}: photos must be JPG, PNG or WEBP files.");
            }

            if (file.Size > MaxUploadBytes)
            {
                throw new InvalidOperationException($"{file.Name} is larger than 15 MB.");
            }
        }

        CheckSpace(files.Sum(f => f.Size));
        var photos = new List<byte[]>();
        foreach (var file in files)
        {
            await using var upload = file.OpenReadStream(MaxUploadBytes, ct);
            photos.Add(await ReadPhotoAsync(upload, file.Name, ct));
        }

        return Start(product, photos);
    }

    /// <summary>Keeps photos taken with the camera on the product's page (JPEG, read as streams from the page) and
    /// starts making the five photos from them.</summary>
    public async Task<PhotoSet> UploadAsync(ProductFacts product, IReadOnlyList<Func<long, CancellationToken, Task<Stream>>> stills, CancellationToken ct)
    {
        NotWhileMoving();
        CheckCount(stills.Count);
        var photos = new List<byte[]>();
        for (var i = 0; i < stills.Count; i++)
        {
            await using var still = await stills[i](MaxUploadBytes, ct);
            photos.Add(await ReadPhotoAsync(still, $"Photo {i + 1}", ct));
        }

        CheckSpace(photos.Sum(p => (long)p.Length));
        return Start(product, photos);
    }

    private static void CheckCount(int count)
    {
        if (count is 0 or > ProductPhotoRequest.MaxPhotos)
        {
            throw new InvalidOperationException($"Add 1 to {ProductPhotoRequest.MaxPhotos} photos of the product.");
        }
    }

    private void CheckSpace(long bytes)
    {
        var free = DataFolderMover.FreeBytes(_storage.DataFolder);
        if (free >= 0 && free < bytes + SpareBytes)
        {
            throw new InvalidOperationException($"Only {DataFolderMover.Describe(free)} is free where photos are kept ({_storage.DataFolder}). "
                + "Choose a folder on a drive with more space under Storage.");
        }
    }

    /// <summary>A photo's bytes, when they are a JPEG, PNG or WebP (by their first bytes, whatever the file is called)
    /// no larger than <see cref="MaxUploadBytes"/>.</summary>
    private static async Task<byte[]> ReadPhotoAsync(Stream content, string name, CancellationToken ct)
    {
        using var buffer = new MemoryStream();
        var chunk = new byte[81920];
        int read;
        while ((read = await content.ReadAsync(chunk, ct)) > 0)
        {
            if (buffer.Length + read > MaxUploadBytes)
            {
                throw new InvalidOperationException($"{name} is larger than 15 MB.");
            }

            buffer.Write(chunk, 0, read);
        }

        var bytes = buffer.ToArray();
        return ImageFile.ExtensionOf(bytes) is null
            ? throw new InvalidOperationException($"{name} is not a JPG, PNG or WEBP photo.")
            : bytes;
    }

    /// <summary>Keeps the photos, each under the extension its bytes need, and starts the five photos.</summary>
    private PhotoSet Start(ProductFacts product, IReadOnlyList<byte[]> photos)
    {
        NotWhileMoving();
        var names = photos
            .Select(bytes => Store.SaveRaw(product.Id, new MemoryStream(bytes), ImageFile.ExtensionOf(bytes)!, Now, product.Name))
            .ToList();
        return Maker.Start(product.Id, product.Code, product.Name, product.Category, names);
    }

    /// <summary>
    /// Deletes a phone photo of the newest set, e.g. one added by mistake: the file is deleted from this PC, and what is
    /// being made from it is made again from the others. Photos already made stay.
    /// </summary>
    public void RemovePhoto(int productId, string fileName)
    {
        NotWhileMoving();
        Maker.RemoveRaw(productId, fileName);
    }

    /// <summary>Deletes a set with its phone photos and every photo made from them, e.g. all of them added by mistake;
    /// work on it stops.</summary>
    public void RemoveSet(int productId, string setId)
    {
        NotWhileMoving();
        Maker.RemoveSet(productId, setId);
    }

    public ProductPhotoInfo? Info(int productId) => Store.Load(productId);

    public IReadOnlyDictionary<int, ProductPhotoInfo> All() => Store.LoadAll();

    /// <summary>What the product is, as the AI saw it in its photos; null when it has none. Feeds the AI's brief.</summary>
    public string? WhatItIs(int productId) => Store.Load(productId)?.Understanding?.WhatItIs is { Length: > 0 } what ? what : null;

    /// <summary>Writes the product's listings again from its newest photos; the current ones are kept as earlier ones.</summary>
    public void WriteListing(int productId)
    {
        NotWhileMoving();
        Maker.WriteListing(productId);
    }

    /// <summary>Keeps the owner's changes to the listings, held to the same rules as the AI's; returns them as kept.</summary>
    public ProductListing SaveListing(int productId, ProductListing listing)
    {
        NotWhileMoving();
        var saved = Store.EditListing(productId, listing, Now);
        Maker.Enqueue(productId);
        return saved;
    }

    /// <summary>Goes back to an earlier listing (0 is the newest).</summary>
    public ProductListing? RestoreListing(int productId, int index)
    {
        NotWhileMoving();
        var restored = Store.RestoreListing(productId, index);
        Maker.Enqueue(productId);
        return restored;
    }

    /// <summary>What the listings need from the POS: the price the customer pays (with GST, as on posters), the stock's
    /// MRP and the code the till scans (the batch with the most stock), and the maker's barcode of any batch.</summary>
    public async Task<ListingFacts> ListingFactsAsync(ProductFacts product, CancellationToken ct)
    {
        IReadOnlyList<SmartRetail.Pos.Core.Models.StockBatch> batches;
        try
        {
            batches = await _products.GetBatchesAsync(new[] { product.Id }, ct);
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            // Without the stock's own codes no barcode and no MRP are shown.
            _log.LogWarning(ex, "Reading the stock of product {Id} for its listing failed.", product.Id);
            batches = Array.Empty<SmartRetail.Pos.Core.Models.StockBatch>();
        }

        return FactsOf(product, batches, _shop.PricesIncludeTax);
    }

    /// <summary>The same for many products, reading the stock in as few queries as it takes. Unlike one product's, a failed read
    /// is not hidden: what is offered to the website must not lose a barcode or an MRP because the stock could not be read.</summary>
    public async Task<IReadOnlyDictionary<int, ListingFacts>> ListingFactsAsync(IReadOnlyList<ProductFacts> products, CancellationToken ct)
    {
        var facts = new Dictionary<int, ListingFacts>();
        foreach (var chunk in products.Chunk(500))
        {
            var batches = await _products.GetBatchesAsync(chunk.Select(product => product.Id).ToArray(), ct);
            var byProduct = batches.ToLookup(batch => batch.ProductId);
            foreach (var product in chunk)
            {
                facts[product.Id] = FactsOf(product, byProduct[product.Id].ToList(), _shop.PricesIncludeTax);
            }
        }

        return facts;
    }

    internal static ListingFacts FactsOf(ProductFacts product, IReadOnlyList<SmartRetail.Pos.Core.Models.StockBatch> batches, bool pricesIncludeTax)
    {
        var batch = batches.Where(b => b.Code.Length > 0).OrderByDescending(b => b.Qty).FirstOrDefault();
        return new ListingFacts(
            product.Name,
            product.Code,
            PosterPricing.CustomerPrice(product.SellingPrice, product.GstRatePercent, pricesIncludeTax),
            batch?.Mrp ?? 0m,
            // Only the code the till scans: the product's own code is not a barcode, so none is better than it.
            batch?.Code ?? "",
            product.StockInHand,
            // The maker's barcode wherever the stock has it, for finding the same product elsewhere.
            Gtin.MakerCode(batches));
    }

    private void NotWhileMoving()
    {
        if (_storage.IsMoving)
        {
            throw new InvalidOperationException("The data folder is being moved. Try again in a minute.");
        }
    }

    /// <summary>What is being made now and what comes next, for every product.</summary>
    public PhotoQueue Queue() => Describe(Store, Maker.Current, Maker.Waiting(), Maker.Pause?.Until);

    /// <summary>Stops waiting for Codex's usage limit: the photos are tried again at once (e.g. the owner got more usage).</summary>
    public void TryNow() => Maker.TryNow();

    /// <summary>The queue as the owner reads it: the photo being made, the rest of that product, and the products waiting.</summary>
    internal static PhotoQueue Describe(ProductPhotoStore store, PhotoWork? now, IReadOnlyList<int> waitingProducts, DateTimeOffset? pausedUntil = null)
    {
        var queue = Snapshot(store, now, waitingProducts);
        return pausedUntil is null || queue.IsEmpty ? queue : queue with { PausedUntil = pausedUntil };
    }

    private static PhotoQueue Snapshot(ProductPhotoStore store, PhotoWork? now, IReadOnlyList<int> waitingProducts)
    {
        var waiting = waitingProducts
            .Select(id => store.Load(id) is { } info
                ? new QueuedProduct(id, info.Name.Length > 0 ? info.Name : $"Product {id}", info.LatestSet?.Pending.Count ?? 0, info.ListingPending)
                : null)
            .OfType<QueuedProduct>()
            .ToList();
        if (now is null)
        {
            return waiting.Count == 0 ? PhotoQueue.Empty : new PhotoQueue(null, "", Array.Empty<PhotoKind>(), false, waiting);
        }

        var current = store.Load(now.ProductId);
        var rest = current?.LatestSet is { } set ? set.Pending.Where(kind => now.IsListing || kind != now.Kind).OrderBy(kind => kind).ToList() : new List<PhotoKind>();
        return new PhotoQueue(now, current?.Name is { Length: > 0 } name ? name : $"Product {now.ProductId}", rest, current?.ListingPending == true && !now.IsListing, waiting);
    }

    public PhotoProgress Progress(int productId, ProductPhotoInfo? info)
    {
        var making = Maker.Current is { } work && work.ProductId == productId ? work : null;
        var set = info?.LatestSet;
        return new PhotoProgress(making, Maker.PlaceInQueue(productId), set?.Problem, set?.MadeCount ?? 0, set?.Pending.Count ?? 0);
    }

    /// <summary>A name for a downloaded photo, e.g. "Sunflower Oil 1 L - 1 White background.png".</summary>
    public string DownloadName(int productId, string fileName)
    {
        var info = Store.Load(productId);
        var image = info?.Sets.SelectMany(s => s.Images).FirstOrDefault(i => i.File == fileName);
        var product = SafeName(info?.Name is { Length: > 0 } name ? name : productId.ToString());
        return image is null
            ? $"{product} - phone photo{Path.GetExtension(fileName)}"
            : $"{product} - {image.Kind.Number()} {image.Kind.Title()}{Path.GetExtension(fileName)}";
    }

    /// <summary>The set's newest photo of each kind in one ZIP file, named for uploading to a website or Amazon, with
    /// the listings for both when they are written.</summary>
    public async Task<(byte[] Zip, string FileName)?> ZipAsync(int productId, string? setId, CancellationToken ct)
    {
        var info = Store.Load(productId);
        var set = setId is null ? info?.LatestSet : info?.Sets.FirstOrDefault(s => s.Id == setId);
        if (info is null || set is null)
        {
            return null;
        }

        var photos = PhotoKinds.All
            .Select(kind => set.Latest(kind))
            .Where(image => image is not null && Store.PathOf(productId, image.File) is not null)
            .Select(image => (Path: Store.PathOf(productId, image!.File)!, Name: DownloadName(productId, image.File)))
            .ToList();
        var product = info.Listing is null ? null : (await _facts.GetProductsAsync(ct)).FirstOrDefault(p => p.Id == productId);
        var facts = product is null ? null : await ListingFactsAsync(product, ct);

        using var output = new MemoryStream();
        using (var zip = new ZipArchive(output, ZipArchiveMode.Create, leaveOpen: true))
        {
            foreach (var photo in photos)
            {
                zip.CreateEntryFromFile(photo.Path, photo.Name, CompressionLevel.NoCompression);
            }

            if (info.Listing is { } listing && facts is not null)
            {
                Add(zip, ListingExport.FileName(facts.Name, "Amazon listing.txt"), ListingExport.AmazonText(listing, facts));
                Add(zip, ListingExport.FileName(facts.Name, "website listing.json"), ListingExport.WebsiteJson(listing, facts, photos.Select(p => p.Name).ToList()));
            }
        }

        return (output.ToArray(), $"{SafeName(info.Name is { Length: > 0 } n ? n : productId.ToString())} photos.zip");
    }

    /// <summary>The photos' names in the ZIP of all photos, for the website's listing.</summary>
    public IReadOnlyList<string> ZipPhotoNames(int productId) =>
        Store.Load(productId)?.LatestSet is { } set
            ? PhotoKinds.All.Select(set.Latest).Where(image => image is not null).Select(image => DownloadName(productId, image!.File)).ToList()
            : Array.Empty<string>();

    private static void Add(ZipArchive zip, string name, string text)
    {
        using var entry = zip.CreateEntry(name, CompressionLevel.Optimal).Open();
        var bytes = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetPreamble().Concat(Encoding.UTF8.GetBytes(text)).ToArray();
        entry.Write(bytes);
    }

    public static string Url(int productId, string fileName, bool download = false) =>
        $"product-photos/{productId}/{Uri.EscapeDataString(fileName)}" + (download ? "?download=true" : "");

    public static string ZipUrl(int productId, string setId) => $"product-photos/{productId}/all.zip?set={Uri.EscapeDataString(setId)}";

    private static string SafeName(string name)
    {
        var safe = string.Concat(name.Select(c => Path.GetInvalidFileNameChars().Contains(c) || c is '<' or '>' or ':' or '"' or '/' or '\\' or '|' or '?' or '*' ? ' ' : c)).Trim();
        return safe.Length > 60 ? safe[..60].Trim() : safe;
    }
}
