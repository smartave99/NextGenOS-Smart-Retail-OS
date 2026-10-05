using System.Security.Cryptography;

namespace SmartRetail.Pos.Vision;

/// <summary>A model to download: where from, and its exact size and SHA-256, so only that file is ever kept.</summary>
public sealed record VisionModel(string Id, string FileName, Uri Url, long Size, string Sha256)
{
    /// <summary>What the owner reads, e.g. "DINOv2-small".</summary>
    public string Name { get; init; } = "";

    /// <summary>A line on what the model is good at, for choosing between models.</summary>
    public string Note { get; init; } = "";
}

/// <summary>
/// The models camera search can use, each pinned to a fixed revision with its exact size and SHA-256: nothing else is ever
/// downloaded or kept. A better model reaches the shop with an update of the app, which adds it at the end of
/// <see cref="All"/>; the app never changes a pinned model, and never switches the owner to another by itself, because a
/// switch downloads the model and learns every product's photos again.
/// </summary>
public static class VisionModels
{
    /// <summary>
    /// DINOv2-small (Meta, Apache 2.0) as ONNX (onnx-community), at a fixed revision: about 88 MB, 384 numbers a
    /// picture. It is downloaded only when camera search is turned on.
    /// </summary>
    public static readonly VisionModel Dinov2Small = new(
        "dinov2-small@8b1f705",
        "dinov2-small-8b1f705.onnx",
        new Uri("https://huggingface.co/onnx-community/dinov2-small/resolve/8b1f705a3a7f6f062f6bdd21986c1583d3ef105d/onnx/model.onnx"),
        88_532_934,
        "f22797eabf810a75e41de68d378541ebea372122b25c4ce3ef25ff618250c20a")
    {
        Name = "DINOv2-small",
        Note = "Small and quick; finds most products by their look.",
    };

    /// <summary>
    /// DINOv2-base (Meta, Apache 2.0) as ONNX (onnx-community), at a fixed revision: about 347 MB, 768 numbers a picture. It sees
    /// more detail than the small one, so it tells look-alike packs apart better; it is about four times the size and slower to
    /// learn the shop's photos.
    /// </summary>
    public static readonly VisionModel Dinov2Base = new(
        "dinov2-base@31ef06c",
        "dinov2-base-31ef06c.onnx",
        new Uri("https://huggingface.co/onnx-community/dinov2-base/resolve/31ef06cac16d5d301c5930d147002a058c85a5e4/onnx/model.onnx"),
        346_627_111,
        "320d1012a6fc65b101fc85ca30ee7a47b2e4f6a2e8bd78fb9d7036def0e30cb0")
    {
        Name = "DINOv2-base",
        Note = "Sees more detail, so it tells look-alike packs apart better; about four times the size, and slower to learn your photos.",
    };

    /// <summary>The models, each better than the one before. The first is what every shop starts with.</summary>
    public static IReadOnlyList<VisionModel> All { get; } = new[] { Dinov2Small, Dinov2Base };

    /// <summary>The model a shop uses until its owner chooses another.</summary>
    public static VisionModel Default => Dinov2Small;

    /// <summary>The model with this id in <paramref name="models"/>; null for none (an empty id is the first one).</summary>
    public static VisionModel? Find(IReadOnlyList<VisionModel> models, string? id)
    {
        ArgumentNullException.ThrowIfNull(models);
        var wanted = (id ?? "").Trim();
        return wanted.Length == 0 ? models.FirstOrDefault() : models.FirstOrDefault(m => string.Equals(m.Id, wanted, StringComparison.Ordinal));
    }
}

/// <summary>
/// Downloads a model into a folder on this PC: first as a ".part" file, hashed as it comes, and kept only when its size
/// and SHA-256 are exactly the ones expected. A download that stops for a minute gives up.
/// </summary>
public sealed class ModelDownloader
{
    private readonly HttpClient _http;

    public ModelDownloader(HttpClient http, string folder)
    {
        _http = http ?? throw new ArgumentNullException(nameof(http));
        ArgumentException.ThrowIfNullOrWhiteSpace(folder);
        Folder = folder;
    }

    public string Folder { get; }

    /// <summary>How long a download may wait for more data.</summary>
    internal TimeSpan StallTimeout { get; set; } = TimeSpan.FromMinutes(1);

    public string PathOf(VisionModel model) => Path.Combine(Folder, model.FileName);

    /// <summary>The model is here at its full size (its hash was checked when it came, and by <see cref="VerifyAsync"/>).</summary>
    public bool IsDownloaded(VisionModel model) => new FileInfo(PathOf(model)) is { Exists: true } file && file.Length == model.Size;

    /// <summary>Checks the model's SHA-256 on disk; a file that is not the model is deleted. True when it is the model.</summary>
    public async Task<bool> VerifyAsync(VisionModel model, CancellationToken ct)
    {
        if (!IsDownloaded(model))
        {
            return false;
        }

        await using (var file = File.OpenRead(PathOf(model)))
        {
            if (Hex(await SHA256.HashDataAsync(file, ct)) == model.Sha256)
            {
                return true;
            }
        }

        File.Delete(PathOf(model));
        return false;
    }

    /// <summary>Downloads the model, reporting how much of it has come (0 to 1).</summary>
    /// <exception cref="InvalidDataException">What came is not the model (another size or hash); nothing is kept.</exception>
    public async Task DownloadAsync(VisionModel model, IProgress<double>? progress, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(model);
        Directory.CreateDirectory(Folder);
        var part = PathOf(model) + ".part";
        try
        {
            using (var response = await _http.GetAsync(model.Url, HttpCompletionOption.ResponseHeadersRead, ct))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"The model could not be downloaded ({(int)response.StatusCode} {response.ReasonPhrase}).", null, response.StatusCode);
                }

                await using var stream = await response.Content.ReadAsStreamAsync(ct);
                await using var file = new FileStream(part, FileMode.Create, FileAccess.Write, FileShare.None, 81920, useAsync: true);
                using var hash = IncrementalHash.CreateHash(HashAlgorithmName.SHA256);
                var buffer = new byte[81920];
                long total = 0;
                while (true)
                {
                    int read;
                    using (var stall = CancellationTokenSource.CreateLinkedTokenSource(ct))
                    {
                        stall.CancelAfter(StallTimeout);
                        try
                        {
                            read = await stream.ReadAsync(buffer, stall.Token);
                        }
                        catch (OperationCanceledException) when (!ct.IsCancellationRequested)
                        {
                            throw new IOException("The download stopped: nothing came for a while. Check the internet connection and try again.");
                        }
                    }

                    if (read == 0)
                    {
                        break;
                    }

                    total += read;
                    if (total > model.Size)
                    {
                        throw new InvalidDataException("What came is larger than the model, so it was not kept.");
                    }

                    hash.AppendData(buffer, 0, read);
                    await file.WriteAsync(buffer.AsMemory(0, read), ct);
                    progress?.Report((double)total / model.Size);
                }

                if (total != model.Size)
                {
                    throw new InvalidDataException($"Only {total:N0} of the model's {model.Size:N0} bytes came, so it was not kept. Try again.");
                }

                if (Hex(hash.GetHashAndReset()) != model.Sha256)
                {
                    throw new InvalidDataException("What came is not the expected model (its SHA-256 differs), so it was not kept.");
                }
            }

            File.Move(part, PathOf(model), overwrite: true);
        }
        catch
        {
            TryDelete(part);
            throw;
        }
    }

    /// <summary>Deletes the model, e.g. to free the space when camera search is turned off.</summary>
    public void Delete(VisionModel model)
    {
        TryDelete(PathOf(model));
        TryDelete(PathOf(model) + ".part");
    }

    private static string Hex(byte[] bytes) => Convert.ToHexString(bytes).ToLowerInvariant();

    private static void TryDelete(string path)
    {
        try
        {
            File.Delete(path);
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            // Left for the next try.
        }
    }
}
