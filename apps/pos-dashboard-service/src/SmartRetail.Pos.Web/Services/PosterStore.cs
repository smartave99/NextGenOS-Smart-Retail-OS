using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using SmartRetail.AI.Storage;
using SmartRetail.Pos.Core.Posters;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// Posters in the data folder the owner chose: a folder per poster (e.g. "20260926-121500-clearance") holding
/// poster.json and its artwork. Only names this store makes are ever read or served.
/// </summary>
public sealed partial class PosterStore
{
    public const string PosterFileName = "poster.json";

    private static readonly JsonSerializerOptions Json = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() },
    };

    private readonly Func<string> _dataFolder;
    private readonly object _gate = new();

    public PosterStore(StorageService storage)
        : this(() => storage.DataFolder)
    {
    }

    public PosterStore(Func<string> dataFolder) => _dataFolder = dataFolder;

    /// <summary>The "Posters" folder in the data folder.</summary>
    public string Folder => DataFolders.Posters(_dataFolder());

    public static string NewId(DateTime now, PosterKind kind) =>
        now.ToString("yyyyMMdd-HHmmss", CultureInfo.InvariantCulture) + "-" + kind.Slug();

    public static bool IsId(string? id) => id is not null && IdPattern().IsMatch(id);

    public static bool IsArtworkName(string? name) => name is not null && ArtworkPattern().IsMatch(name);

    /// <summary>True for a poster's folder: its name is a poster id and it holds the poster.</summary>
    public static bool IsPosterFolder(string folder) => IsId(Path.GetFileName(folder)) && File.Exists(Path.Combine(folder, PosterFileName));

    public void Save(Poster poster)
    {
        ArgumentNullException.ThrowIfNull(poster);
        if (!IsId(poster.Id))
        {
            throw new ArgumentException("Not a poster id: " + poster.Id, nameof(poster));
        }

        lock (_gate)
        {
            var folder = Path.Combine(Folder, poster.Id);
            Directory.CreateDirectory(folder);
            var path = Path.Combine(folder, PosterFileName);
            var temporary = path + ".tmp";
            File.WriteAllText(temporary, JsonSerializer.Serialize(poster, Json));
            File.Move(temporary, path, overwrite: true);
        }
    }

    public Poster? Load(string? id)
    {
        if (!IsId(id))
        {
            return null;
        }

        var path = Path.Combine(Folder, id!, PosterFileName);
        lock (_gate)
        {
            try
            {
                var poster = File.Exists(path) ? JsonSerializer.Deserialize<Poster>(File.ReadAllText(path), Json) : null;
                return poster is null ? null : Clean(poster, id!);
            }
            catch (Exception ex) when (ex is JsonException or IOException or NotSupportedException)
            {
                return null;
            }
        }
    }

    /// <summary>Changes a saved poster under the store's lock, so the artwork and staff's edits never overwrite each other.</summary>
    public Poster? Update(string id, Func<Poster, Poster> change)
    {
        lock (_gate)
        {
            if (Load(id) is not { } poster)
            {
                return null;
            }

            var changed = change(poster) with { Id = poster.Id };
            Save(changed);
            return changed;
        }
    }

    /// <summary>The latest posters, newest first.</summary>
    public IReadOnlyList<Poster> Recent(int count = 12)
    {
        if (!Directory.Exists(Folder))
        {
            return Array.Empty<Poster>();
        }

        return Directory.EnumerateDirectories(Folder)
            .Select(Path.GetFileName)
            .Where(IsId)
            .OrderByDescending(id => id, StringComparer.Ordinal)
            .Select(Load)
            .OfType<Poster>()
            .Take(count)
            .ToList();
    }

    /// <summary>Keeps new artwork for a poster, removes its earlier artwork, and gives the file's name; null when the
    /// poster is no longer there (deleted while its artwork was being made), and then nothing is written.</summary>
    public string? SaveArtwork(string id, byte[] png, DateTime now)
    {
        if (!IsId(id))
        {
            throw new ArgumentException("Not a poster id: " + id, nameof(id));
        }

        ArgumentNullException.ThrowIfNull(png);
        lock (_gate)
        {
            var folder = Path.Combine(Folder, id);
            if (!File.Exists(Path.Combine(folder, PosterFileName)))
            {
                return null;
            }

            var name = "artwork-" + now.ToString("yyyyMMdd-HHmmss", CultureInfo.InvariantCulture) + ".png";
            File.WriteAllBytes(Path.Combine(folder, name), png);
            foreach (var old in Directory.EnumerateFiles(folder, "artwork-*.png").Where(path => Path.GetFileName(path) != name && IsArtworkName(Path.GetFileName(path))))
            {
                File.Delete(old);
            }

            return name;
        }
    }

    /// <summary>The artwork's full path, or null unless both names are ones this store makes and the file exists.</summary>
    public string? ArtworkPath(string? id, string? name)
    {
        if (!IsId(id) || !IsArtworkName(name))
        {
            return null;
        }

        var path = Path.Combine(Folder, id!, name!);
        return File.Exists(path) && File.Exists(Path.Combine(Folder, id!, PosterFileName)) ? path : null;
    }

    public bool Delete(string? id)
    {
        if (!IsId(id))
        {
            return false;
        }

        lock (_gate)
        {
            var folder = Path.Combine(Folder, id!);
            if (!Directory.Exists(folder))
            {
                return false;
            }

            Directory.Delete(folder, recursive: true);
            return true;
        }
    }

    public static string ArtworkUrl(Poster poster) => poster.Artwork is { } name
        ? "poster-art/" + poster.Id + "/" + Uri.EscapeDataString(name)
        : "";

    /// <summary>A poster file edited by hand keeps the store's own id, and only names the store could have made.</summary>
    private static Poster Clean(Poster poster, string id) => poster with
    {
        Id = id,
        Artwork = IsArtworkName(poster.Artwork) ? poster.Artwork : null,
        Items = poster.Items.Select(item => item.WithOffer(item.OfferPrice)).ToList(),
    };

    [GeneratedRegex(@"^\d{8}-\d{6}-[a-z]+(-[a-z]+)*$", RegexOptions.CultureInvariant)]
    private static partial Regex IdPattern();

    [GeneratedRegex(@"^artwork-\d{8}-\d{6}\.png$", RegexOptions.CultureInvariant)]
    private static partial Regex ArtworkPattern();
}
