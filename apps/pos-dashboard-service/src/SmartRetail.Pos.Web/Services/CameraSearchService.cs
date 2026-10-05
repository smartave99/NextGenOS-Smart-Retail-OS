using Microsoft.Extensions.Options;
using SmartRetail.AI;
using SmartRetail.AI.Products;
using SmartRetail.AI.Settings;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Posters;
using SmartRetail.Pos.Vision;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// Where camera search keeps and gets its model (section "CameraSearch"). All empty: DINOv2-small from Hugging Face,
/// kept in %LOCALAPPDATA%. Another copy of a model (a mirror for a network that blocks Hugging Face, or a stand-in for
/// tests) needs its address, id, exact size and SHA-256: nothing else is ever kept.
/// </summary>
public sealed class CameraSearchOptions
{
    public const string SectionName = "CameraSearch";

    public string ModelsFolder { get; set; } = "";

    public string ModelUrl { get; set; } = "";

    public string ModelId { get; set; } = "";

    public long ModelSize { get; set; }

    public string ModelSha256 { get; set; } = "";

    /// <summary>A better model besides that one (all four, or none), so a switch can be tried with stand-ins.</summary>
    public string BetterModelUrl { get; set; } = "";

    public string BetterModelId { get; set; } = "";

    public long BetterModelSize { get; set; }

    public string BetterModelSha256 { get; set; } = "";

    /// <summary>The model to start with: the one configured when all of it is given, else DINOv2-small.</summary>
    public VisionModel Model() => Configured(ModelUrl, ModelId, ModelSize, ModelSha256) ?? VisionModels.Default;

    /// <summary>
    /// The models there are to choose from, each better than the one before: the app's own (DINOv2-small, then DINOv2-base), or,
    /// when a model is configured, that one and the better one when it is configured too.
    /// </summary>
    public IReadOnlyList<VisionModel> Models()
    {
        var first = Configured(ModelUrl, ModelId, ModelSize, ModelSha256);
        if (first is null)
        {
            return VisionModels.All;
        }

        return Configured(BetterModelUrl, BetterModelId, BetterModelSize, BetterModelSha256) is { } better ? new[] { first, better } : new[] { first };
    }

    private static VisionModel? Configured(string url, string id, long size, string sha256) =>
        Uri.TryCreate(url, UriKind.Absolute, out var address) && address.Scheme is "https" or "http"
            && id.Trim().Length > 0 && size > 0 && System.Text.RegularExpressions.Regex.IsMatch(sha256 ?? "", "^[0-9a-fA-F]{64}$")
            ? new VisionModel(id.Trim(), "model-" + sha256![..12].ToLowerInvariant() + ".onnx", address, size, sha256.ToLowerInvariant()) { Name = id.Trim() }
            : null;
}

/// <summary>Where finding by look stands.</summary>
public enum LookModelState
{
    /// <summary>Not turned on: only barcodes are read.</summary>
    Off,

    Downloading,

    /// <summary>The downloaded model's SHA-256 is being checked.</summary>
    Checking,

    Loading,

    Ready,

    /// <summary>The model could not be downloaded or loaded; <see cref="CameraSearchStatus.Problem"/> says why.</summary>
    Problem,
}

/// <summary>Where camera search stands, for Settings and the search screens.</summary>
/// <param name="Progress">How much of the model has come, 0 to 1, while it downloads.</param>
/// <param name="Learned">Products whose photos are learned.</param>
/// <param name="WithPhotos">Products with photos to learn from.</param>
/// <param name="Learning">A product's photos are being learned now.</param>
/// <param name="SwitchingTo">The name of the model being downloaded to take the place of the one working, which keeps finding
/// products until the new one is here; null otherwise. <paramref name="Progress"/> is then how much of it has come.</param>
public sealed record CameraSearchStatus(LookModelState Model, double Progress, string? Problem, int Learned, int WithPhotos, bool Learning, string? SwitchingTo = null);

/// <summary>A product a photo found: by its barcode, or by its look (with how alike, 0 to 1).</summary>
/// <param name="Price">What the customer pays, with GST (as posters show it).</param>
/// <param name="Codes">The codes the till scans for it (its stock batches').</param>
/// <param name="Photo">Its white-background photo's address, when it has one.</param>
public sealed record FoundProduct(int ProductId, string Name, string Code, decimal Price, decimal Stock, IReadOnlyList<string> Codes, string? Photo, float? Score);

/// <summary>What a photo found.</summary>
/// <param name="ByCode">Products whose code is in the photo, each with the code read.</param>
/// <param name="UnknownCodes">Codes read that the POS does not have.</param>
/// <param name="ByLook">Products that look like the photo, most alike first (none when finding by look is off).</param>
/// <param name="Sure">The first look match leads the next by enough to call it the best.</param>
/// <param name="LookedFor">Products were looked for by their look.</param>
public sealed record CameraSearchResult(
    IReadOnlyList<(string Code, FoundProduct Product)> ByCode,
    IReadOnlyList<string> UnknownCodes,
    IReadOnlyList<FoundProduct> ByLook,
    bool Sure,
    bool LookedFor,
    string? Problem)
{
    public static CameraSearchResult Failed(string problem) => new(Array.Empty<(string, FoundProduct)>(), Array.Empty<string>(), Array.Empty<FoundProduct>(), false, false, problem);
}

/// <summary>
/// Finding a product with the camera, on this PC: a photo's barcodes first (read by ZXing and looked up in the POS),
/// then, once turned on in Settings, the products it looks like. For that, a DINOv2 model (small to start with) is downloaded
/// once (its SHA-256 checked) into %LOCALAPPDATA%, and each product's photos (its newest phone photos and white-background
/// photo) are learned in the background into visual.json next to them. Photos looked for are never kept or sent.
/// A better model reaches the shop with an update of the app, which adds it to <see cref="VisionModels.All"/>; the owner chooses
/// it in Settings (<see cref="Switch"/>), and the app never switches by itself. The new model is downloaded and checked while the
/// one working goes on finding products; then it takes its place, the old one is deleted once it works, and every product's photos
/// are learned again with it (vectors of another model are never read), the products learned so far being found meanwhile.
/// </summary>
public sealed class CameraSearchService : IDisposable
{
    private readonly AiEnvironment _ai;
    private readonly ProductPhotoService _photos;
    private readonly StorageService _storage;
    private readonly IProductRepository _products;
    private readonly ISalesFactsRepository _facts;
    private readonly ShopOptions _shop;
    private readonly ILogger<CameraSearchService> _log;
    private readonly ModelDownloader _downloader;
    private readonly IReadOnlyList<VisionModel> _models;
    private readonly Func<VisionModel, string, IImageEmbedder> _load;
    private readonly VisualIndex _index = new();
    private readonly SemaphoreSlim _wake = new(0);
    private readonly object _gate = new();
    private readonly HashSet<int> _toLearn = new();
    private readonly HashSet<int> _withPhotos = new();
    private IImageEmbedder? _embedder;
    private VisualLearner? _learner;
    private CancellationTokenSource? _download;
    private LookModelState _state = LookModelState.Off;
    private double _progress;
    private string? _problem;
    private string? _verifiedId;
    private string? _loadedId;
    private string? _cleanedFor;
    private string? _switchingTo;
    private bool _indexLoaded;
    private bool _downloadFailed;
    private bool _learning;

    /// <summary>The data folder whose photos the index holds; null while it is (re)loading.</summary>
    private string? _indexFolder;

    public CameraSearchService(AiEnvironment ai, ProductPhotoService photos, StorageService storage, IProductRepository products,
        ISalesFactsRepository facts, IOptions<ShopOptions> shop, IOptions<CameraSearchOptions> options, ILogger<CameraSearchService> log)
        : this(ai, photos, storage, products, facts, shop, log,
            new ModelDownloader(new HttpClient { Timeout = Timeout.InfiniteTimeSpan },
                options.Value.ModelsFolder.Trim().Length > 0 ? options.Value.ModelsFolder.Trim() : DefaultModelsFolder),
            options.Value.Models(),
            (model, path) => new OnnxImageEmbedder(path, model.Id))
    {
    }

    internal CameraSearchService(AiEnvironment ai, ProductPhotoService photos, StorageService storage, IProductRepository products,
        ISalesFactsRepository facts, IOptions<ShopOptions> shop, ILogger<CameraSearchService> log,
        ModelDownloader downloader, IReadOnlyList<VisionModel> models, Func<VisionModel, string, IImageEmbedder> load)
    {
        if (models is null || models.Count == 0)
        {
            throw new ArgumentException("There is no model to use.", nameof(models));
        }

        _ai = ai;
        _photos = photos;
        _storage = storage;
        _products = products;
        _facts = facts;
        _shop = shop.Value;
        _log = log;
        _downloader = downloader;
        _models = models;
        _load = load;
        _photos.Changed += OnPhotosChanged;
        _storage.FolderChanged += Wake;
    }

    /// <summary>Where the model is kept: on this PC, beside the app's other files, never in the data folder.</summary>
    public static string DefaultModelsFolder => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Branding.Company, Branding.AppFolderName, "models");

    /// <summary>Raised when the status changes, on a background thread.</summary>
    public event Action? Changed;

    /// <summary>The models there are to choose from, each better than the one before.</summary>
    public IReadOnlyList<VisionModel> Models => _models;

    /// <summary>The model chosen: the owner's choice, else the first, which every shop starts with.</summary>
    public VisionModel Model => VisionModels.Find(_models, _ai.LoadSettings().CameraSearch.Model) ?? _models[0];

    /// <summary>The best model there is above the chosen one; null when the chosen one is the best.</summary>
    public VisionModel? Better
    {
        get
        {
            var chosen = Model;
            var at = _models.ToList().FindIndex(m => m.Id == chosen.Id);
            return at >= 0 && at < _models.Count - 1 ? _models[^1] : null;
        }
    }

    public bool FindByLookIsOn => _ai.LoadSettings().CameraSearch.FindByLook;

    /// <summary>Photos are being learned: the data folder must not move meanwhile.</summary>
    public bool IsWriting
    {
        get
        {
            lock (_gate)
            {
                return _learning;
            }
        }
    }

    public CameraSearchStatus Status
    {
        get
        {
            lock (_gate)
            {
                return new CameraSearchStatus(_state, _progress, _problem, _index.ProductCount, _withPhotos.Count, _learning, _switchingTo);
            }
        }
    }

    /// <summary>The model is on this PC (it can be deleted to free the space).</summary>
    public bool ModelIsDownloaded => _downloader.IsDownloaded(Model);

    /// <summary>Turns finding by look on: the model is downloaded if it is not here, then the photos are learned.</summary>
    public void TurnOn()
    {
        Save(true);
        lock (_gate)
        {
            _downloadFailed = false;
            _problem = null;
        }

        Wake();
    }

    /// <summary>Turns finding by look off: a download stops, and the model is let go (it stays on disk).</summary>
    public void TurnOff()
    {
        Save(false);
        lock (_gate)
        {
            _download?.Cancel();
        }

        Wake();
    }

    /// <summary>Deletes the downloaded model, to free its space; only while finding by look is off.</summary>
    public void DeleteModel()
    {
        if (FindByLookIsOn)
        {
            throw new InvalidOperationException("Turn finding by look off first.");
        }

        var model = Model;
        _downloader.Delete(model);
        lock (_gate)
        {
            _verifiedId = null;
        }

        Raise();
    }

    /// <summary>
    /// Chooses another model for finding products by their look. When finding by look is on, the new model is downloaded and checked
    /// first, while the one working goes on finding products; then it takes its place, the old one is deleted once it works, and the
    /// photos are learned again with it. When finding by look is off, the choice is kept for when it is turned on.
    /// </summary>
    /// <exception cref="InvalidOperationException">The model is not one of <see cref="Models"/>.</exception>
    public void Switch(string modelId)
    {
        var wanted = _models.FirstOrDefault(m => string.Equals(m.Id, (modelId ?? "").Trim(), StringComparison.Ordinal))
            ?? throw new InvalidOperationException("That is not one of the models to choose from.");
        if (wanted.Id == Model.Id)
        {
            return;
        }

        var store = new SettingsStore(_ai.SettingsFile);
        var settings = store.Load();
        settings.CameraSearch.Model = wanted.Id;
        store.Save(settings);
        lock (_gate)
        {
            _downloadFailed = false;
            _problem = null;
            _download?.Cancel();
        }

        Wake();
        Raise();
    }

    public void Wake() => _wake.Release();

    /// <summary>Runs until <paramref name="stopping"/>: downloads and loads the model when turned on, and learns photos.</summary>
    public async Task RunAsync(CancellationToken stopping)
    {
        while (true)
        {
            var again = await StepAsync(stopping);
            // Photos left to learn while the data folder moves are tried again a little later.
            await _wake.WaitAsync(again ? TimeSpan.FromSeconds(10) : Timeout.InfiniteTimeSpan, stopping);
        }
    }

    /// <summary>One round of work; true when some is left for later.</summary>
    internal async Task<bool> StepAsync(CancellationToken stopping)
    {
        if (!FindByLookIsOn)
        {
            Unload();
            SetState(LookModelState.Off);
            return false;
        }

        var model = Model;
        if (_embedder is not null && _loadedId != model.Id)
        {
            // Another model was chosen while one is working: the new one is brought here and checked first, and the one working goes on
            // finding products meanwhile. Only then is it let go, and the photos are learned again with the new one.
            bool failed;
            lock (_gate)
            {
                failed = _downloadFailed;
            }

            if (failed)
            {
                // The switch did not work: the model working goes on, until the owner tries again or chooses another.
                model = _models.FirstOrDefault(m => m.Id == _loadedId) ?? model;
            }
            else
            {
                if (!_downloader.IsDownloaded(model) && !await DownloadAsync(model, stopping, switching: true))
                {
                    return false;
                }

                if (_verifiedId != model.Id && !await VerifyAsync(model, stopping, switching: true))
                {
                    return false;
                }

                Unload();
            }
        }

        if (!_downloader.IsDownloaded(model))
        {
            bool failed;
            lock (_gate)
            {
                failed = _downloadFailed;
            }

            if (failed || !await DownloadAsync(model, stopping, switching: false))
            {
                return false;
            }
        }

        if (_verifiedId != model.Id)
        {
            SetState(LookModelState.Checking);
            if (!await VerifyAsync(model, stopping, switching: false))
            {
                return false;
            }
        }

        if (_embedder is null)
        {
            SetState(LookModelState.Loading);
            try
            {
                var embedder = await Task.Run(() => _load(model, _downloader.PathOf(model)), stopping);
                lock (_gate)
                {
                    _embedder = embedder;
                    _loadedId = model.Id;
                    _learner = new VisualLearner(_index, embedder);
                }
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                _log.LogError(ex, "The camera search model could not be loaded.");
                Fail("The model could not be started on this PC: " + ex.Message);
                return false;
            }
        }

        SetState(LookModelState.Ready);
        ForgetOtherModels(model);

        // What was learned belongs to one data folder: after a switch to another, it is loaded again from there.
        var folder = _storage.DataFolder;
        if (!_indexLoaded || !SameFolder(folder, IndexFolder))
        {
            LoadIndex(folder);
            _indexLoaded = true;
        }

        return await LearnAsync(stopping);
    }

    /// <summary>
    /// Downloads <paramref name="model"/>. <paramref name="switching"/>: another model is working and goes on finding products
    /// meanwhile, so the state stays as it is, and a failure is said without stopping it.
    /// </summary>
    private async Task<bool> DownloadAsync(VisionModel model, CancellationToken stopping, bool switching)
    {
        using var cancel = CancellationTokenSource.CreateLinkedTokenSource(stopping);
        lock (_gate)
        {
            _download = cancel;
            _progress = 0;
            _switchingTo = switching ? ModelName(model) : null;
        }

        if (switching)
        {
            Raise();
        }
        else
        {
            SetState(LookModelState.Downloading);
        }

        try
        {
            var lastReport = DateTime.MinValue;
            await _downloader.DownloadAsync(model, new ProgressReport(done =>
            {
                lock (_gate)
                {
                    _progress = done;
                }

                // A few times a second is enough for the progress bar.
                if (DateTime.UtcNow - lastReport > TimeSpan.FromMilliseconds(250) || done >= 1)
                {
                    lastReport = DateTime.UtcNow;
                    Raise();
                }
            }), cancel.Token);
            lock (_gate)
            {
                _verifiedId = model.Id;
            }

            return true;
        }
        catch (OperationCanceledException) when (!stopping.IsCancellationRequested)
        {
            // Turned off while downloading, or another model chosen.
            if (!switching)
            {
                SetState(LookModelState.Off);
            }

            return false;
        }
        catch (Exception ex) when (ex is HttpRequestException or IOException or InvalidDataException or UnauthorizedAccessException)
        {
            _log.LogWarning(ex, "The camera search model could not be downloaded.");
            lock (_gate)
            {
                _downloadFailed = true;
            }

            var why = ex is InvalidDataException ? ex.Message : "The model could not be downloaded: " + ex.Message + " Check the internet connection, then try again.";
            if (switching)
            {
                // The model working goes on; the new one is said to have failed.
                lock (_gate)
                {
                    _problem = ModelName(model) + ": " + why;
                }

                Raise();
            }
            else
            {
                Fail(why);
            }

            return false;
        }
        finally
        {
            lock (_gate)
            {
                _download = null;
                _switchingTo = null;
            }

            if (switching)
            {
                Raise();
            }
        }
    }

    /// <summary>Checks the downloaded model's SHA-256 again; a file that is not the model is deleted.</summary>
    private async Task<bool> VerifyAsync(VisionModel model, CancellationToken stopping, bool switching)
    {
        if (await _downloader.VerifyAsync(model, stopping))
        {
            lock (_gate)
            {
                _verifiedId = model.Id;
            }

            return true;
        }

        var why = "The model on this PC was damaged, so it was deleted. " + (switching ? "Choose it again to download it again." : "Turn finding by look on again to download it again.");
        if (switching)
        {
            lock (_gate)
            {
                _problem = ModelName(model) + ": " + why;
                _downloadFailed = true;
            }

            Raise();
        }
        else
        {
            Fail(why);
            Save(false);
        }

        return false;
    }

    /// <summary>
    /// Once the chosen model works, the other models are deleted from this PC: they would only take space, and the owner can choose
    /// one again (it is downloaded again). Only the files of the models in <see cref="Models"/> are ever touched.
    /// </summary>
    private void ForgetOtherModels(VisionModel model)
    {
        if (_cleanedFor == model.Id)
        {
            return;
        }

        _cleanedFor = model.Id;
        foreach (var other in _models.Where(m => m.Id != model.Id))
        {
            try
            {
                _downloader.Delete(other);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                _log.LogInformation(ex, "The model {Model} could not be deleted.", other.Id);
            }
        }
    }

    private static string ModelName(VisionModel model) => model.Name.Length > 0 ? model.Name : model.Id;

    private string? IndexFolder
    {
        get
        {
            lock (_gate)
            {
                return _indexFolder;
            }
        }
    }

    /// <summary>Puts what was learned in <paramref name="folder"/> (the data folder) into the index, and notes the
    /// products with photos still to learn. Searches do not use the index meanwhile.</summary>
    private void LoadIndex(string folder)
    {
        var learner = _learner;
        if (learner is null)
        {
            return;
        }

        lock (_gate)
        {
            _indexFolder = null;
            _toLearn.Clear();
        }

        _index.Clear();

        var withPhotos = new HashSet<int>();
        foreach (var (productId, info) in _photos.All())
        {
            var files = FilesToLearn(info);
            if (files.Count > 0)
            {
                withPhotos.Add(productId);
            }

            try
            {
                if (learner.Load(productId, _photos.Store.FolderOf(productId), files))
                {
                    lock (_gate)
                    {
                        _toLearn.Add(productId);
                    }
                }
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                _log.LogWarning(ex, "Could not read what was learned about product {Id}.", productId);
            }
        }

        lock (_gate)
        {
            _withPhotos.Clear();
            _withPhotos.UnionWith(withPhotos);
            _indexFolder = folder;
        }

        Raise();
    }

    private static bool SameFolder(string folder, string? other) =>
        other is not null && string.Equals(Path.GetFullPath(folder).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
            Path.GetFullPath(other).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
            OperatingSystem.IsWindows() ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

    /// <summary>Learns the products waiting, one at a time; true when some wait for the data folder to finish moving.</summary>
    private async Task<bool> LearnAsync(CancellationToken stopping)
    {
        while (true)
        {
            // Turned off, or another data folder chosen, meanwhile: the next round lets the model go or loads the
            // other folder's index (both wake it), so no more is learned here.
            if (!FindByLookIsOn || !SameFolder(_storage.DataFolder, IndexFolder))
            {
                return false;
            }

            int productId;
            VisualLearner? learner;
            lock (_gate)
            {
                learner = _learner;
                if (learner is null || _toLearn.Count == 0)
                {
                    return false;
                }

                if (_storage.IsMoving)
                {
                    return true;
                }

                productId = _toLearn.First();
                _toLearn.Remove(productId);
                _learning = true;
            }

            Raise();
            try
            {
                var info = _photos.Info(productId);
                var files = info is null ? new List<string>() : FilesToLearn(info);
                lock (_gate)
                {
                    if (files.Count > 0)
                    {
                        _withPhotos.Add(productId);
                    }
                    else
                    {
                        _withPhotos.Remove(productId);
                    }
                }

                var done = await Task.Run(() => learner.Learn(productId, _photos.Store.FolderOf(productId), files, () => !_storage.IsMoving), stopping);
                if (!done)
                {
                    lock (_gate)
                    {
                        _toLearn.Add(productId);
                    }
                }
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or InvalidOperationException or ObjectDisposedException
                or Microsoft.ML.OnnxRuntime.OnnxRuntimeException)
            {
                _log.LogWarning(ex, "Could not learn the photos of product {Id}.", productId);
            }
            finally
            {
                lock (_gate)
                {
                    _learning = false;
                }

                Raise();
            }
        }
    }

    /// <summary>The photos a product is found by: its newest phone photos (taken as a camera photo would be) and its
    /// white-background photo. Model photos show people and places, so they are left out.</summary>
    internal List<string> FilesToLearn(ProductPhotoInfo info)
    {
        var set = info.LatestSet;
        if (set is null)
        {
            return new List<string>();
        }

        var files = set.RawFiles.ToList();
        if (set.Latest(PhotoKind.WhiteBackground) is { } white)
        {
            files.Add(white.File);
        }

        return files.Where(file => _photos.Store.PathOf(info.ProductId, file) is not null).Distinct().ToList();
    }

    private void OnPhotosChanged(int productId)
    {
        lock (_gate)
        {
            if (_learner is null)
            {
                return;
            }

            _toLearn.Add(productId);
        }

        Wake();
    }

    /// <summary>What a photo finds: products by the codes in it, then by its look.</summary>
    public async Task<CameraSearchResult> SearchAsync(byte[] photo, CancellationToken ct)
    {
        var image = await Task.Run(() => VisionImage.Decode(photo), ct);
        if (image is null)
        {
            return CameraSearchResult.Failed("The photo could not be read. Take it again.");
        }

        var codes = await Task.Run(() => BarcodeScanner.Read(image), ct);
        var byCode = new List<(string Code, int ProductId)>();
        var unknown = new List<string>();
        foreach (var code in codes)
        {
            var found = false;
            foreach (var form in BarcodeScanner.Forms(code))
            {
                if (await _products.FindByCodeAsync(form, ct) is { } product)
                {
                    if (!byCode.Any(c => c.ProductId == product.Id))
                    {
                        byCode.Add((code.Text, product.Id));
                    }

                    found = true;
                    break;
                }
            }

            if (!found)
            {
                unknown.Add(code.Text);
            }
        }

        IReadOnlyList<LookMatch> looks = Array.Empty<LookMatch>();
        var lookedFor = false;
        IImageEmbedder? embedder;
        var folder = _storage.DataFolder;
        bool stale;
        lock (_gate)
        {
            // An index from another data folder (it has just changed) is never searched: it is reloaded first.
            stale = _state == LookModelState.Ready && !SameFolder(folder, _indexFolder);
            embedder = _state == LookModelState.Ready && !stale ? _embedder : null;
        }

        if (stale)
        {
            Wake();
        }

        if (embedder is not null && _index.ProductCount > 0)
        {
            try
            {
                var (vector, colour) = await Task.Run(() => (embedder.Embed(image), ColourHistogram.Of(image)), ct);
                looks = _index.Search(vector, colour);
                lookedFor = true;
            }
            catch (ObjectDisposedException)
            {
                // Turned off while looking: the barcodes still count.
            }
        }

        var ids = byCode.Select(c => c.ProductId).Concat(looks.Select(l => l.ProductId)).Distinct().ToList();
        var products = ids.Count == 0 ? new Dictionary<int, FoundProduct>() : await DescribeAsync(ids, ct);
        return new CameraSearchResult(
            byCode.Where(c => products.ContainsKey(c.ProductId)).Select(c => (c.Code, products[c.ProductId])).ToList(),
            unknown,
            looks.Where(l => products.ContainsKey(l.ProductId)).Select(l => products[l.ProductId] with { Score = l.Score }).ToList(),
            VisualIndex.IsSure(looks),
            lookedFor,
            null);
    }

    /// <summary>The products as the screens show them, with the POS's price, stock and batch codes.</summary>
    private async Task<Dictionary<int, FoundProduct>> DescribeAsync(IReadOnlyCollection<int> ids, CancellationToken ct)
    {
        var facts = (await _facts.GetProductsAsync(ct)).Where(p => ids.Contains(p.Id)).ToList();
        var batches = (await _products.GetBatchesAsync(ids, ct))
            .Where(b => b.Code.Length > 0)
            .GroupBy(b => b.ProductId)
            .ToDictionary(g => g.Key, g => (IReadOnlyList<string>)g.OrderByDescending(b => b.Qty).Select(b => b.Code).Distinct().ToList());
        var photos = _photos.All();
        return facts.ToDictionary(p => p.Id, p => new FoundProduct(
            p.Id,
            p.Name,
            p.Code,
            PosterPricing.CustomerPrice(p.SellingPrice, p.GstRatePercent, _shop.PricesIncludeTax),
            p.StockInHand,
            batches.TryGetValue(p.Id, out var codes) ? codes : Array.Empty<string>(),
            photos.TryGetValue(p.Id, out var info) && info.Thumbnail is { } thumbnail ? ProductPhotoService.Url(p.Id, thumbnail) : null,
            null));
    }

    private void Save(bool findByLook)
    {
        var store = new SettingsStore(_ai.SettingsFile);
        var settings = store.Load();
        settings.CameraSearch.FindByLook = findByLook;
        store.Save(settings);
        Raise();
    }

    private void Unload()
    {
        IImageEmbedder? embedder;
        lock (_gate)
        {
            embedder = _embedder;
            _embedder = null;
            _loadedId = null;
            _learner = null;
            _indexLoaded = false;
            _indexFolder = null;
            _toLearn.Clear();
            _withPhotos.Clear();
        }

        _index.Clear();
        embedder?.Dispose();
    }

    private void Fail(string problem)
    {
        lock (_gate)
        {
            _problem = problem;
            _state = LookModelState.Problem;
        }

        Raise();
    }

    private void SetState(LookModelState state)
    {
        lock (_gate)
        {
            if (_state == state)
            {
                return;
            }

            _state = state;
            if (state is LookModelState.Ready or LookModelState.Downloading)
            {
                _problem = null;
            }
        }

        Raise();
    }

    private void Raise()
    {
        try
        {
            Changed?.Invoke();
        }
        catch (Exception ex)
        {
            _log.LogWarning(ex, "A camera search screen could not be told of a change.");
        }
    }

    public void Dispose()
    {
        _photos.Changed -= OnPhotosChanged;
        _storage.FolderChanged -= Wake;
        Unload();
        _wake.Dispose();
    }

    /// <summary>Progress reported as it happens, in order, on the downloading thread.</summary>
    private sealed class ProgressReport(Action<double> report) : IProgress<double>
    {
        public void Report(double value) => report(value);
    }
}
