using System.Net;
using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using SkiaSharp;
using SmartRetail.AI.Products;
using SmartRetail.AI.Settings;
using SmartRetail.Pos.Data.Demo;
using SmartRetail.Pos.Vision;
using SmartRetail.Pos.Web.Services;
using ZXing;

namespace SmartRetail.Pos.Tests.Vision;

/// <summary>Camera search on the demo shop, with the tiny stand-in models "downloaded" from a stand-in server.</summary>
public sealed class CameraSearchServiceTests : IDisposable
{
    private const int Oil = 6;
    private const int Rice = 1;
    private const int Dal = 3;

    private readonly string _root = Directory.CreateTempSubdirectory("camera-search-").FullName;
    private readonly DemoStore _store = new(new FixedClock(new DateTimeOffset(2026, 9, 28, 10, 0, 0, TimeSpan.FromHours(5.5))), seedSales: false);
    private readonly IOptions<AiOptions> _options;
    private readonly ProductPhotoService _photos;
    private readonly StorageService _storage;
    private readonly byte[] _modelBytes = File.ReadAllBytes(Path.Combine(AppContext.BaseDirectory, "Vision", "tiny-embedder.onnx"));
    private readonly byte[] _betterBytes = File.ReadAllBytes(Path.Combine(AppContext.BaseDirectory, "Vision", "tiny-embedder-tokens.onnx"));
    private readonly Serves _server;
    private DateTime _now = new(2026, 9, 28, 10, 0, 0);

    public CameraSearchServiceTests()
    {
        File.WriteAllText(Path.Combine(_root, StorageSettingsStoreFile), JsonSerializer.Serialize(new { DataFolder = Path.Combine(_root, "data") }));
        _options = Options.Create(new AiOptions { SettingsFile = Path.Combine(_root, "settings.json") });
        _photos = new ProductPhotoService(new AiEnvironment(_options), new StorageService(_options), _store, _store, Options.Create(new ShopOptions()),
            TimeProvider.System, NullLogger<ProductPhotoService>.Instance);
        _server = new Serves(_modelBytes);
        _server.Offer("https://models.example/tiny2.onnx", _betterBytes);
        _storage = new StorageService(_options);
    }

    private static string StorageSettingsStoreFile => SmartRetail.AI.Storage.StorageSettingsStore.FileName;

    public void Dispose() => Directory.Delete(_root, recursive: true);

    private VisionModel Model => new("tiny@1", "tiny.onnx", new Uri("https://models.example/tiny.onnx"), _modelBytes.Length,
        Convert.ToHexString(SHA256.HashData(_modelBytes)).ToLowerInvariant()) { Name = "Tiny 1" };

    /// <summary>The better model of a later version of the app: another file, so another size and hash.</summary>
    private VisionModel Better => new("tiny@2", "tiny2.onnx", new Uri("https://models.example/tiny2.onnx"), _betterBytes.Length,
        Convert.ToHexString(SHA256.HashData(_betterBytes)).ToLowerInvariant()) { Name = "Tiny 2" };

    private string ModelsFolder => Path.Combine(_root, "models");

    private CameraSearchService Search(Func<IImageEmbedder, IImageEmbedder>? wrap = null, bool withBetter = false) => new(new AiEnvironment(_options), _photos, _storage, _store, _store,
        Options.Create(new ShopOptions()), NullLogger<CameraSearchService>.Instance,
        new ModelDownloader(new HttpClient(_server), ModelsFolder), withBetter ? new[] { Model, Better } : new[] { Model },
        (model, path) => (wrap ?? (embedder => embedder))(new OnnxImageEmbedder(path, model.Id)));

    /// <summary>The model that made the vectors kept for a product.</summary>
    private string? ModelOf(int productId) =>
        _photos.Store.FolderOf(productId) is { } folder && File.Exists(Path.Combine(folder, VisualStore.FileName))
            ? JsonSerializer.Deserialize<VisualFile>(File.ReadAllText(Path.Combine(folder, VisualStore.FileName)))!.Model
            : null;

    private bool Learned(int productId) =>
        _photos.Store.FolderOf(productId) is { } folder && File.Exists(Path.Combine(folder, VisualStore.FileName));

    private static byte[] Png(byte r, byte g, byte b) => Pictures.Encode(Pictures.Plain(160, 120, r, g, b), SKEncodedImageFormat.Png);

    /// <summary>A product with a phone photo and a white-background photo, as the photo page leaves it.</summary>
    private void Photograph(int productId, byte r, byte g, byte b)
    {
        using var raw = new MemoryStream(Png(r, g, b));
        var name = _photos.Store.SaveRaw(productId, raw, ".png", _now, "Product " + productId);
        var set = _photos.Store.StartSet(productId, "P" + productId, "Product " + productId, "", new[] { name }, _now);
        _now = _now.AddMinutes(1);
        _photos.Store.SaveImage(productId, set.Id, PhotoKind.WhiteBackground, new ProductPhotoResult { Image = Png(r, g, b) }, _now);
    }

    [Fact]
    public async Task A_barcode_finds_its_product_without_any_download()
    {
        using var search = Search();
        var code = (await _store.GetBatchesAsync(new[] { Oil })).Single().Code;

        var found = await search.SearchAsync(Pictures.Encode(Pictures.Barcode(code, BarcodeFormat.EAN_13), SKEncodedImageFormat.Png), CancellationToken.None);

        var (read, product) = Assert.Single(found.ByCode);
        Assert.Equal(code, read);
        Assert.Equal(Oil, product.ProductId);
        Assert.Equal("Sunflower Oil 1 L", product.Name);
        Assert.Equal(155m, product.Price);
        Assert.Equal(new[] { code }, product.Codes);
        Assert.False(found.LookedFor);
        Assert.Empty(found.ByLook);
        Assert.Equal(LookModelState.Off, search.Status.Model);
        Assert.Equal(0, _server.Requests);

        var unknown = await search.SearchAsync(Pictures.Encode(Pictures.Barcode("4006381333931", BarcodeFormat.EAN_13), SKEncodedImageFormat.Png), CancellationToken.None);
        Assert.Equal(new[] { "4006381333931" }, unknown.UnknownCodes);
        Assert.Empty(unknown.ByCode);

        Assert.Equal("The photo could not be read. Take it again.", (await search.SearchAsync("text"u8.ToArray(), CancellationToken.None)).Problem);
    }

    [Fact]
    public async Task Turned_on_it_downloads_the_model_learns_the_photos_and_finds_products_by_their_look()
    {
        Photograph(Oil, 240, 200, 30);
        Photograph(Rice, 240, 240, 235);
        using var search = Search();

        search.TurnOn();
        await search.StepAsync(CancellationToken.None);

        var status = search.Status;
        Assert.Equal(LookModelState.Ready, status.Model);
        Assert.Equal((2, 2), (status.Learned, status.WithPhotos));
        Assert.True(search.ModelIsDownloaded);
        Assert.True(new SettingsStore(_options.Value.SettingsFilePath).Load().CameraSearch.FindByLook);
        Assert.True(File.Exists(Path.Combine(_photos.Store.FolderOf(Oil)!, VisualStore.FileName)));

        var found = await search.SearchAsync(Png(235, 195, 35), CancellationToken.None);

        Assert.True(found.LookedFor);
        Assert.Equal(Oil, found.ByLook[0].ProductId);
        Assert.NotNull(found.ByLook[0].Score);
        Assert.StartsWith("product-photos/6/white-", found.ByLook[0].Photo);
        Assert.Empty(found.ByCode);

        // New photos of a product are learned when the photo maker says they came.
        Photograph(Rice, 30, 90, 200);
        _photos.Maker.Enqueue(Rice);
        await search.StepAsync(CancellationToken.None);
        Assert.Equal(Rice, (await search.SearchAsync(Png(35, 95, 205), CancellationToken.None)).ByLook[0].ProductId);

        search.TurnOff();
        await search.StepAsync(CancellationToken.None);
        Assert.Equal(LookModelState.Off, search.Status.Model);
        Assert.False((await search.SearchAsync(Png(235, 195, 35), CancellationToken.None)).LookedFor);
        Assert.True(search.ModelIsDownloaded, "turning off keeps the model");
        search.DeleteModel();
        Assert.False(search.ModelIsDownloaded);
        Assert.Equal(1, _server.Requests);
    }

    [Fact]
    public async Task A_failed_download_says_why_and_is_tried_again_only_when_asked()
    {
        _server.Status = HttpStatusCode.ServiceUnavailable;
        using var search = Search();

        search.TurnOn();
        await search.StepAsync(CancellationToken.None);

        Assert.Equal(LookModelState.Problem, search.Status.Model);
        Assert.Contains("could not be downloaded", search.Status.Problem);
        await search.StepAsync(CancellationToken.None);
        Assert.Equal(1, _server.Requests);

        _server.Status = HttpStatusCode.OK;
        search.TurnOn();
        await search.StepAsync(CancellationToken.None);
        Assert.Equal(LookModelState.Ready, search.Status.Model);
        Assert.Null(search.Status.Problem);
    }

    [Fact]
    public async Task A_damaged_model_is_found_when_the_app_starts_and_deleted()
    {
        using (var first = Search())
        {
            first.TurnOn();
            await first.StepAsync(CancellationToken.None);
        }

        var path = Path.Combine(ModelsFolder, "tiny.onnx");
        var spoilt = File.ReadAllBytes(path);
        spoilt[^1] ^= 0xFF;
        File.WriteAllBytes(path, spoilt);

        using var next = Search();
        await next.StepAsync(CancellationToken.None);

        Assert.Equal(LookModelState.Problem, next.Status.Model);
        Assert.Contains("damaged", next.Status.Problem);
        Assert.False(File.Exists(path));
        Assert.False(next.FindByLookIsOn, "it waits to be turned on again");
    }

    [Fact]
    public async Task Turned_off_while_learning_it_stops_after_the_product_it_is_on()
    {
        Photograph(Oil, 240, 200, 30);
        Photograph(Rice, 240, 240, 235);
        Photograph(Dal, 200, 150, 40);
        var gate = new Gate();
        using var search = Search(embedder => new GatedEmbedder(embedder, gate));

        search.TurnOn();
        var step = search.StepAsync(CancellationToken.None);
        Assert.True(gate.Started.Wait(TimeSpan.FromSeconds(30)), "learning never began");
        search.TurnOff();
        gate.Go.Set();
        await step.WaitAsync(TimeSpan.FromSeconds(30));

        Assert.Equal(1, new[] { Oil, Rice, Dal }.Count(Learned));
        await search.StepAsync(CancellationToken.None);
        Assert.Equal(LookModelState.Off, search.Status.Model);
        Assert.Equal(0, search.Status.Learned);
    }

    [Fact]
    public async Task Another_data_folder_with_its_own_photos_is_learned_and_the_old_index_never_searched()
    {
        // The second folder already holds the add-on's data: a photo of the rice.
        var second = Path.Combine(_root, "second");
        var settings = SmartRetail.AI.Storage.StorageSettingsStore.Beside(_options.Value.SettingsFilePath);
        var first = settings.Load();
        settings.Save(new SmartRetail.AI.Storage.StorageSettings { DataFolder = second });
        Photograph(Rice, 30, 90, 200);
        settings.Save(first);

        Photograph(Oil, 240, 200, 30);
        using var search = Search();
        search.TurnOn();
        await search.StepAsync(CancellationToken.None);
        Assert.Equal(Oil, (await search.SearchAsync(Png(235, 195, 35), CancellationToken.None)).ByLook[0].ProductId);

        var said = await _storage.ChangeAsync(second, () => null, null);
        Assert.StartsWith("Now using the data already in", said);

        // Until the index is loaded from the new folder, only barcodes are read.
        Assert.False((await search.SearchAsync(Png(235, 195, 35), CancellationToken.None)).LookedFor);
        await search.StepAsync(CancellationToken.None);

        Assert.Equal((1, 1), (search.Status.Learned, search.Status.WithPhotos));
        var found = await search.SearchAsync(Png(35, 95, 205), CancellationToken.None);
        Assert.Equal(new[] { Rice }, found.ByLook.Select(p => p.ProductId).ToArray());
        Assert.True(Learned(Rice));
    }

    [Fact]
    public async Task A_better_model_chosen_is_downloaded_while_the_old_one_goes_on_finding_then_the_photos_are_learned_again_and_the_old_model_goes()
    {
        Photograph(Oil, 240, 200, 30);
        Photograph(Rice, 240, 240, 235);
        using var search = Search(withBetter: true);
        search.TurnOn();
        await search.StepAsync(CancellationToken.None);
        Assert.Equal(("tiny@1", "tiny@2"), (search.Model.Id, search.Better!.Id));
        Assert.Equal("tiny@1", ModelOf(Oil));
        Assert.True(File.Exists(Path.Combine(ModelsFolder, "tiny.onnx")));

        var (arrived, release) = _server.Hold(Better.Url.AbsoluteUri);
        search.Switch(Better.Id);
        Assert.Equal("tiny@2", new SettingsStore(_options.Value.SettingsFilePath).Load().CameraSearch.Model);
        Assert.Null(search.Better);
        var step = search.StepAsync(CancellationToken.None);
        await arrived.WaitAsync(TimeSpan.FromSeconds(30));

        // The new model is on its way; the old one has not been let go, so finding by look goes on.
        Assert.Equal((LookModelState.Ready, "Tiny 2"), (search.Status.Model, search.Status.SwitchingTo));
        var meanwhile = await search.SearchAsync(Png(235, 195, 35), CancellationToken.None);
        Assert.True(meanwhile.LookedFor);
        Assert.Equal(Oil, meanwhile.ByLook[0].ProductId);
        Assert.Equal("tiny@1", ModelOf(Oil));

        release.SetResult();
        await step.WaitAsync(TimeSpan.FromSeconds(30));

        Assert.Equal(LookModelState.Ready, search.Status.Model);
        Assert.Null(search.Status.SwitchingTo);
        Assert.Equal((2, 2), (search.Status.Learned, search.Status.WithPhotos));
        Assert.Equal(("tiny@2", "tiny@2"), (ModelOf(Oil), ModelOf(Rice)));
        Assert.True(File.Exists(Path.Combine(ModelsFolder, "tiny2.onnx")));
        Assert.False(File.Exists(Path.Combine(ModelsFolder, "tiny.onnx")), "the old model goes once the new one works");
        Assert.Equal(Oil, (await search.SearchAsync(Png(235, 195, 35), CancellationToken.None)).ByLook[0].ProductId);
        Assert.Equal((1, 1), (_server.RequestsFor(Model.Url.AbsoluteUri), _server.RequestsFor(Better.Url.AbsoluteUri)));
    }

    [Fact]
    public async Task A_model_that_cannot_be_downloaded_leaves_the_working_one_alone_and_says_so_and_a_new_try_is_made_only_when_asked()
    {
        Photograph(Oil, 240, 200, 30);
        using var search = Search(withBetter: true);
        search.TurnOn();
        await search.StepAsync(CancellationToken.None);
        _server.StatusOf(Better.Url.AbsoluteUri, HttpStatusCode.ServiceUnavailable);

        search.Switch(Better.Id);
        await search.StepAsync(CancellationToken.None);

        Assert.Equal(LookModelState.Ready, search.Status.Model);
        Assert.StartsWith("Tiny 2: The model could not be downloaded", search.Status.Problem);
        Assert.Null(search.Status.SwitchingTo);
        Assert.True((await search.SearchAsync(Png(235, 195, 35), CancellationToken.None)).LookedFor);
        Assert.Equal("tiny@1", ModelOf(Oil));
        Assert.True(File.Exists(Path.Combine(ModelsFolder, "tiny.onnx")));

        // The working model goes on learning new photos, and the failed download is not repeated at every round.
        Photograph(Rice, 240, 240, 235);
        _photos.Maker.Enqueue(Rice);
        await search.StepAsync(CancellationToken.None);
        Assert.Equal(1, _server.RequestsFor(Better.Url.AbsoluteUri));
        Assert.Equal("tiny@1", ModelOf(Rice));

        _server.StatusOf(Better.Url.AbsoluteUri, HttpStatusCode.OK);
        search.TurnOn();
        await search.StepAsync(CancellationToken.None);
        Assert.Null(search.Status.Problem);
        Assert.Equal(("tiny@2", "tiny@2"), (ModelOf(Oil), ModelOf(Rice)));
    }

    [Fact]
    public async Task Choosing_the_model_that_works_again_cancels_the_download_of_the_other()
    {
        Photograph(Oil, 240, 200, 30);
        using var search = Search(withBetter: true);
        search.TurnOn();
        await search.StepAsync(CancellationToken.None);
        var (arrived, _) = _server.Hold(Better.Url.AbsoluteUri);
        search.Switch(Better.Id);
        var step = search.StepAsync(CancellationToken.None);
        await arrived.WaitAsync(TimeSpan.FromSeconds(30));

        search.Switch(Model.Id);
        await step.WaitAsync(TimeSpan.FromSeconds(30));
        await search.StepAsync(CancellationToken.None);

        Assert.Equal(LookModelState.Ready, search.Status.Model);
        Assert.Null(search.Status.SwitchingTo);
        Assert.Null(search.Status.Problem);
        Assert.Equal("tiny@1", search.Model.Id);
        Assert.Equal("tiny@1", ModelOf(Oil));
        Assert.False(File.Exists(Path.Combine(ModelsFolder, "tiny2.onnx")));
        Assert.Equal(1, _server.RequestsFor(Model.Url.AbsoluteUri));
    }

    [Fact]
    public async Task A_model_chosen_while_finding_by_look_is_off_is_kept_for_when_it_is_turned_on_and_an_unknown_one_is_refused()
    {
        Photograph(Oil, 240, 200, 30);
        using var search = Search(withBetter: true);

        search.Switch(Better.Id);
        await search.StepAsync(CancellationToken.None);
        Assert.Equal(LookModelState.Off, search.Status.Model);
        Assert.Equal(0, _server.Requests);
        Assert.Equal(Better.Id, search.Model.Id);

        search.TurnOn();
        await search.StepAsync(CancellationToken.None);
        Assert.Equal(LookModelState.Ready, search.Status.Model);
        Assert.Equal(("tiny@2", 0, 1), (ModelOf(Oil), _server.RequestsFor(Model.Url.AbsoluteUri), _server.RequestsFor(Better.Url.AbsoluteUri)));

        var error = Assert.Throws<InvalidOperationException>(() => search.Switch("dinov2-huge@1"));
        Assert.Equal("That is not one of the models to choose from.", error.Message);
        Assert.Equal(Better.Id, new SettingsStore(_options.Value.SettingsFilePath).Load().CameraSearch.Model);
    }

    [Fact]
    public async Task A_shop_that_never_chose_stays_on_the_first_model_whatever_the_app_offers()
    {
        using var search = Search(withBetter: true);

        Assert.Equal("", new SettingsStore(_options.Value.SettingsFilePath).Load().CameraSearch.Model);
        Assert.Equal(("tiny@1", "tiny@2"), (search.Model.Id, search.Better!.Id));
        search.TurnOn();
        await search.StepAsync(CancellationToken.None);
        Assert.Equal(0, _server.RequestsFor(Better.Url.AbsoluteUri));
        Assert.Equal("", new SettingsStore(_options.Value.SettingsFilePath).Load().CameraSearch.Model);
    }

    [Fact]
    public void Another_copy_of_a_model_is_used_only_with_its_exact_size_and_hash()
    {
        var mirror = new CameraSearchOptions { ModelUrl = "https://mirror.example/dinov2.onnx", ModelId = "dinov2-small@8b1f705", ModelSize = 88_532_934, ModelSha256 = VisionModels.Dinov2Small.Sha256.ToUpperInvariant() };

        var model = mirror.Model();

        Assert.Equal(new Uri("https://mirror.example/dinov2.onnx"), model.Url);
        Assert.Equal(VisionModels.Dinov2Small.Sha256, model.Sha256);
        Assert.Equal("model-f22797eabf81.onnx", model.FileName);
        Assert.Same(VisionModels.Dinov2Small, new CameraSearchOptions().Model());
        Assert.Same(VisionModels.Dinov2Small, new CameraSearchOptions { ModelUrl = "https://mirror.example/x.onnx", ModelId = "x", ModelSize = 10 }.Model());
        Assert.Same(VisionModels.Dinov2Small, new CameraSearchOptions { ModelUrl = "file:///c:/x.onnx", ModelId = "x", ModelSize = 10, ModelSha256 = new string('a', 64) }.Model());
    }

    [Fact]
    public void The_models_to_choose_from_are_the_apps_own_unless_a_copy_is_configured_and_then_that_one_and_a_better_one_when_given()
    {
        Assert.Same(VisionModels.All, new CameraSearchOptions().Models());
        var configured = new CameraSearchOptions { ModelUrl = "http://127.0.0.1:1/a.onnx", ModelId = "a@1", ModelSize = 10, ModelSha256 = new string('a', 64) };
        Assert.Equal(new[] { "a@1" }, configured.Models().Select(m => m.Id));

        configured.BetterModelUrl = "http://127.0.0.1:1/b.onnx";
        configured.BetterModelId = "b@1";
        configured.BetterModelSize = 20;
        Assert.Equal(new[] { "a@1" }, configured.Models().Select(m => m.Id)); // a part of it is not enough
        configured.BetterModelSha256 = new string('B', 64);
        Assert.Equal(new[] { "a@1", "b@1" }, configured.Models().Select(m => m.Id));
        Assert.Equal(new string('b', 64), configured.Models()[1].Sha256);
    }

    private sealed class Gate
    {
        public ManualResetEventSlim Started { get; } = new();

        public ManualResetEventSlim Go { get; } = new();
    }

    /// <summary>The model, held at its first picture until the test lets it go on.</summary>
    private sealed class GatedEmbedder(IImageEmbedder inner, Gate gate) : IImageEmbedder
    {
        public string ModelId => inner.ModelId;

        public float[] Embed(VisionImage image)
        {
            gate.Started.Set();
            gate.Go.Wait(TimeSpan.FromSeconds(30));
            return inner.Embed(image);
        }

        public void Dispose() => inner.Dispose();
    }

    /// <summary>The stand-in server: <paramref name="bytes"/> for any address, other files for the addresses offered, a status for all or
    /// one address, and requests that wait until the test lets them go.</summary>
    private sealed class Serves(byte[] bytes) : HttpMessageHandler
    {
        private readonly object _lock = new();
        private readonly Dictionary<string, byte[]> _offered = new();
        private readonly Dictionary<string, HttpStatusCode> _statuses = new();
        private readonly Dictionary<string, TaskCompletionSource> _held = new();
        private readonly Dictionary<string, TaskCompletionSource> _arrived = new();
        private readonly Dictionary<string, int> _counts = new();

        public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;

        public int Requests { get; private set; }

        public int RequestsFor(string url)
        {
            lock (_lock)
            {
                return _counts.GetValueOrDefault(url);
            }
        }

        public void Offer(string url, byte[] other) => _offered[url] = other;

        public void StatusOf(string url, HttpStatusCode status) => _statuses[url] = status;

        /// <summary>The next request for the address waits until the returned source is completed; the task completes when it has arrived.</summary>
        public (Task Arrived, TaskCompletionSource Release) Hold(string url)
        {
            var arrived = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            var release = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            lock (_lock)
            {
                _arrived[url] = arrived;
                _held[url] = release;
            }

            return (arrived.Task, release);
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var url = request.RequestUri!.AbsoluteUri;
            TaskCompletionSource? arrived;
            TaskCompletionSource? held;
            lock (_lock)
            {
                Requests++;
                _counts[url] = _counts.GetValueOrDefault(url) + 1;
                _arrived.TryGetValue(url, out arrived);
                _held.TryGetValue(url, out held);
            }

            arrived?.TrySetResult();
            if (held is not null)
            {
                await held.Task.WaitAsync(cancellationToken);
            }

            var status = _statuses.TryGetValue(url, out var own) ? own : Status;
            var content = status == HttpStatusCode.OK ? _offered.TryGetValue(url, out var other) ? other : bytes : Array.Empty<byte>();
            return new HttpResponseMessage(status) { Content = new ByteArrayContent(content) };
        }
    }
}
