using System.Text.Json;
using SmartRetail.AI.Prices;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using SmartRetail.AI.Storage;
using SmartRetail.Pos.Core.Prices;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// The price check: for a product the owner follows, Codex searches the web for the same product in online shops
/// (<see cref="PriceShops"/>) and the pages found wait for the owner to say which show exactly this product; only the
/// confirmed ones are compared with the shop's price, and their prices are read again on request. Only the product's name,
/// the maker's barcode and its category leave the PC. Nothing here changes a price in the POS or anywhere else, and a price
/// found on the web is never given to another AI. Kept in pricecheck.json in the data folder's Price checks folder, never
/// while the data folder moves; one product is checked at a time.
/// </summary>
public sealed class PriceCheckService
{
    public const string FileName = "pricecheck.json";

    private static readonly JsonSerializerOptions Json = new() { WriteIndented = true, Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() } };

    private readonly StorageService _storage;
    private readonly TimeProvider _clock;
    private readonly ILogger<PriceCheckService> _log;
    private readonly Func<PriceCheckRequest, CancellationToken, Task<PriceCheckAnswer>> _ask;
    private readonly object _gate = new();
    private readonly object _running = new();
    private readonly Dictionary<int, string> _problems = new();
    private readonly HashSet<int> _refused = new();
    private int? _checking;

    public PriceCheckService(StorageService storage, AiEnvironment ai, TimeProvider clock, ILogger<PriceCheckService> log)
        : this(storage, clock, log, async (request, ct) => (await ai.CreateCodex(AiJob.PriceCheck).CheckPricesAsync(request, ct)).Answer)
    {
    }

    /// <param name="ask">Looks the prices up; a stand-in in tests.</param>
    internal PriceCheckService(StorageService storage, TimeProvider clock, ILogger<PriceCheckService> log, Func<PriceCheckRequest, CancellationToken, Task<PriceCheckAnswer>> ask)
    {
        _storage = storage;
        _clock = clock;
        _log = log;
        _ask = ask;
    }

    /// <summary>A product followed, forgotten or checked, a page confirmed or rejected, or a check started or ended.</summary>
    public event Action? Changed;

    public string Path => System.IO.Path.Combine(DataFolders.PriceChecks(_storage.DataFolder), FileName);

    /// <summary>The product being checked now; null when none is.</summary>
    public int? Checking
    {
        get
        {
            lock (_running)
            {
                return _checking;
            }
        }
    }

    /// <summary>True for the moment a change is being written; the Storage page waits for it before moving data.</summary>
    public bool IsWriting
    {
        get
        {
            if (!Monitor.TryEnter(_gate))
            {
                return true;
            }

            Monitor.Exit(_gate);
            return false;
        }
    }

    /// <summary>The last check's failure for the product, e.g. Codex's usage limit; null when it went well.</summary>
    public string? ProblemOf(int productId)
    {
        lock (_running)
        {
            return _problems.GetValueOrDefault(productId);
        }
    }

    private DateTime Now => _clock.GetLocalNow().DateTime;

    public PriceBook Load()
    {
        lock (_gate)
        {
            return Read();
        }
    }

    public WatchedProduct? For(int productId) => Load().Products.FirstOrDefault(p => p.ProductId == productId);

    /// <summary>Starts following a product; nothing changes when it is followed already.</summary>
    public void Watch(int productId, string name) => Write(book =>
    {
        if (book.Products.All(p => p.ProductId != productId))
        {
            book.Products.Add(new WatchedProduct { ProductId = productId, Name = PriceCheckRules.Clean(name) });
        }

        return null;
    });

    /// <summary>Stops following a product and forgets its pages.</summary>
    public void Forget(int productId) => Write(book =>
    {
        book.Products.RemoveAll(p => p.ProductId == productId);
        return null;
    });

    /// <summary>What the owner says about a page: it shows exactly this product (confirmed), another one (rejected, so it never
    /// comes back), or not decided (new). Null when kept, else why not.</summary>
    public string? SetStatus(int productId, string url, LinkStatus status) => Write(book =>
    {
        var link = book.Products.FirstOrDefault(p => p.ProductId == productId)?.Links.FirstOrDefault(l => l.Url == url);
        if (link is null || !Enum.IsDefined(status))
        {
            return "That page is not there any more.";
        }

        link.Status = status;
        return null;
    });

    /// <summary>
    /// Has Codex look for the product's prices on the web, or read the confirmed pages again, and keeps what it found: new
    /// pages wait for the owner, known ones get their new price. Null when it went well, else why not (Codex's usage limit,
    /// not signed in, another check running…). One product is checked at a time.
    /// </summary>
    /// <param name="barcode">The maker's barcode when the product has one; empty otherwise.</param>
    public async Task<string?> CheckAsync(int productId, string name, string barcode, string category, string whatItIs, bool onlyConfirmed, CancellationToken ct)
    {
        lock (_running)
        {
            if (_checking is { } other)
            {
                if (other == productId)
                {
                    return "This product is being checked already.";
                }

                // Shown on the card of the product that asked, until the check that is running ends.
                _refused.Add(productId);
                return Failed(productId, "Another product is being checked now. Try again when it is done.");
            }

            _checking = productId;
            _problems.Remove(productId);
        }

        Changed?.Invoke();
        try
        {
            Watch(productId, name);
            var known = For(productId);
            var request = new PriceCheckRequest
            {
                ProductId = productId,
                Name = name,
                Barcode = barcode ?? "",
                Category = category ?? "",
                WhatItIs = whatItIs ?? "",
                ReadAgain = known?.Links.Where(l => l.Status == LinkStatus.Confirmed).Select(l => l.Url).ToList() ?? new List<string>(),
                OnlyReadAgain = onlyConfirmed,
            };
            if (request.Problem() is { } problem)
            {
                return Failed(productId, problem);
            }

            PriceCheckAnswer answer;
            try
            {
                answer = await _ask(request, ct);
            }
            catch (AiProviderException ex)
            {
                return Failed(productId, ex.Message);
            }

            var found = answer.Quotes.Select(q => new PriceFound(q.Url, q.Shop, q.Title, q.Pack, q.Price, q.SameProduct, q.InStock)).ToList();
            var note = string.Join(" ", new[] { answer.Note }.Concat(answer.Skipped).Where(text => text.Length > 0));
            return Write(book =>
            {
                var product = book.Products.FirstOrDefault(p => p.ProductId == productId);
                if (product is null)
                {
                    // Forgotten while it was being checked: what was found is not kept.
                    return null;
                }

                var (_, _, reopened) = PriceLinks.Merge(product, found, Now);
                var told = reopened == 0 ? note
                    : string.Join(" ", new[] { note, (reopened == 1 ? "1 confirmed page shows" : reopened + " confirmed pages show") + " another pack now and wait for you again." }.Where(text => text.Length > 0));
                product.Name = PriceCheckRules.Clean(name);
                product.Checked = Now;
                product.Note = told.Length > 300 ? told[..299] + "…" : told;
                return null;
            });
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or InvalidOperationException)
        {
            _log.LogWarning(ex, "Keeping the price check failed.");
            return Failed(productId, ex.Message);
        }
        finally
        {
            lock (_running)
            {
                _checking = null;
                foreach (var refused in _refused)
                {
                    _problems.Remove(refused);
                }

                _refused.Clear();
            }

            Changed?.Invoke();
        }
    }

    private string Failed(int productId, string problem)
    {
        lock (_running)
        {
            _problems[productId] = problem;
        }

        return problem;
    }

    private string? Write(Func<PriceBook, string?> change)
    {
        string? problem;
        lock (_gate)
        {
            if (_storage.IsMoving)
            {
                throw new InvalidOperationException("The data folder is being moved. Try again when the move is done.");
            }

            var book = Read();
            problem = change(book);
            if (problem is null)
            {
                var path = Path;
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path)!);
                var temporary = path + ".tmp";
                File.WriteAllText(temporary, JsonSerializer.Serialize(book, Json));
                File.Move(temporary, path, overwrite: true);
            }
        }

        if (problem is null)
        {
            Changed?.Invoke();
        }

        return problem;
    }

    private PriceBook Read()
    {
        var path = Path;
        if (!File.Exists(path))
        {
            return new PriceBook();
        }

        try
        {
            return Screen(JsonSerializer.Deserialize<PriceBook>(File.ReadAllText(path), Json));
        }
        catch (JsonException ex)
        {
            // A damaged file is kept aside, never overwritten, and the price book starts again.
            _log.LogWarning(ex, "The price check file is damaged; it was kept as {File}.bad.", FileName);
            File.Copy(path, path + ".bad", overwrite: true);
            return new PriceBook();
        }
    }

    /// <summary>
    /// What a file, perhaps edited by hand, may give to the page: only pages of listed shops over https with a plain price,
    /// their shop named by the link and not by the file, texts cleaned, nothing missing, no page twice.
    /// </summary>
    internal static PriceBook Screen(PriceBook? found)
    {
        var book = new PriceBook();
        foreach (var product in found?.Products ?? new List<WatchedProduct>())
        {
            if (product is null || product.ProductId <= 0 || book.Products.Any(p => p.ProductId == product.ProductId))
            {
                continue;
            }

            var kept = new WatchedProduct
            {
                ProductId = product.ProductId,
                Name = Cut(PriceCheckRules.Clean(product.Name), 200),
                Checked = product.Checked,
                Note = Cut(PriceCheckRules.Clean(product.Note), PriceCheckRules.MaxNote),
            };
            foreach (var link in product.Links ?? new List<PriceLink>())
            {
                if (link is null)
                {
                    continue;
                }

                var shop = PriceShops.Match(link.Url, out var url);
                if (shop is null || link.Price <= 0 || link.Price > PriceCheckRules.MaxPrice || !Enum.IsDefined(link.Status) || kept.Links.Any(l => l.Url == url))
                {
                    continue;
                }

                kept.Links.Add(new PriceLink
                {
                    Url = url,
                    Shop = shop.Name,
                    Title = Cut(PriceCheckRules.Clean(link.Title), PriceCheckRules.MaxTitle),
                    Pack = Cut(PriceCheckRules.Clean(link.Pack), PriceCheckRules.MaxPack),
                    Status = link.Status,
                    LooksSame = link.LooksSame,
                    Price = link.Price,
                    Seen = link.Seen,
                    InStock = link.InStock,
                    History = (link.History ?? new List<PricePoint>())
                        .Where(point => point is { Price: > 0 and <= PriceCheckRules.MaxPrice })
                        .TakeLast(PriceLink.MaxHistory)
                        .Select(point => new PricePoint { Seen = point.Seen, Price = point.Price })
                        .ToList(),
                });
            }

            book.Products.Add(kept);
        }

        return book;
    }

    private static string Cut(string text, int max) => text.Length <= max ? text : text[..(max - 1)].TrimEnd() + "…";
}
