using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using SmartRetail.AI.Storage;
using SmartRetail.Pos.Core.Creatives;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// Creatives in the data folder the owner chose. Each has a folder under "Creatives" (e.g. "20260928-113000") holding
/// creative.json, the pictures the owner added to take the look from (assets/), every picture made with what it was
/// made from (generations/&lt;n&gt;/: request.json, prompt.txt and result.png) and the pictures exported (exports/). The
/// shop's brand and logo are in "Creatives/Brand". Only names this store makes are ever read or served.
/// </summary>
public sealed partial class CreativeStore
{
    public const string ProjectFileName = "creative.json";

    public const string ResultFileName = "result.png";

    private const string BrandFolderName = "Brand";

    private const string BrandFileName = "brand.json";

    private static readonly JsonSerializerOptions Json = new() { WriteIndented = true };

    private readonly Func<string> _dataFolder;
    private readonly object _gate = new();

    public CreativeStore(StorageService storage)
        : this(() => storage.DataFolder)
    {
    }

    public CreativeStore(Func<string> dataFolder) => _dataFolder = dataFolder;

    /// <summary>The "Creatives" folder in the data folder.</summary>
    public string Folder => DataFolders.Creatives(_dataFolder());

    public static bool IsId(string? id) => id is not null && IdPattern().IsMatch(id);

    /// <summary>A picture the owner added, or one exported: names this store makes.</summary>
    public static bool IsAssetName(string? name) => name is not null && AssetPattern().IsMatch(name);

    public static bool IsExportName(string? name) => name is not null && ExportPattern().IsMatch(name);

    public static bool IsLogoName(string? name) => name is not null && LogoPattern().IsMatch(name);

    /// <summary>Makes the creative's folder under a new id (the time, with a number when two start in the same second).</summary>
    public CreativeProject Create(CreativeProject project, DateTime now)
    {
        ArgumentNullException.ThrowIfNull(project);
        lock (_gate)
        {
            var id = now.ToString("yyyyMMdd-HHmmss", CultureInfo.InvariantCulture);
            for (var n = 2; Directory.Exists(Path.Combine(Folder, id)); n++)
            {
                id = now.ToString("yyyyMMdd-HHmmss", CultureInfo.InvariantCulture) + "-" + n.ToString(CultureInfo.InvariantCulture);
            }

            var created = project with { Id = id, Created = now, Updated = now };
            Save(created);
            return created;
        }
    }

    public void Save(CreativeProject project)
    {
        ArgumentNullException.ThrowIfNull(project);
        if (!IsId(project.Id))
        {
            throw new ArgumentException("Not a creative id: " + project.Id, nameof(project));
        }

        lock (_gate)
        {
            var folder = Path.Combine(Folder, project.Id);
            Directory.CreateDirectory(folder);
            WriteAtomically(Path.Combine(folder, ProjectFileName), JsonSerializer.Serialize(project, Json));
        }
    }

    public CreativeProject? Load(string? id)
    {
        if (!IsId(id))
        {
            return null;
        }

        var path = Path.Combine(Folder, id!, ProjectFileName);
        lock (_gate)
        {
            try
            {
                var project = File.Exists(path) ? JsonSerializer.Deserialize<CreativeProject>(File.ReadAllText(path), Json) : null;
                return project is null ? null : project with { Id = id!, Brief = Clean(project.Brief), Generations = project.Generations.Where(g => g.Number > 0).ToList() };
            }
            catch (Exception ex) when (ex is JsonException or IOException or NotSupportedException or UnauthorizedAccessException)
            {
                return null;
            }
        }
    }

    /// <summary>Changes a saved creative under the store's lock, so the worker and the owner's edits never overwrite each
    /// other; null when it is gone.</summary>
    public CreativeProject? Update(string id, Func<CreativeProject, CreativeProject> change, DateTime now)
    {
        ArgumentNullException.ThrowIfNull(change);
        lock (_gate)
        {
            if (Load(id) is not { } project)
            {
                return null;
            }

            var changed = change(project) with { Id = project.Id, Created = project.Created, Updated = now };
            Save(changed);
            return changed;
        }
    }

    /// <summary>The latest creatives, newest first.</summary>
    public IReadOnlyList<CreativeProject> Recent(int count = 48)
    {
        if (!Directory.Exists(Folder))
        {
            return Array.Empty<CreativeProject>();
        }

        return Directory.EnumerateDirectories(Folder)
            .Select(Path.GetFileName)
            .Where(IsId)
            .OrderByDescending(id => id, StringComparer.Ordinal)
            .Select(Load)
            .OfType<CreativeProject>()
            .Take(count)
            .ToList();
    }

    /// <summary>Deletes a creative's folder and everything in it.</summary>
    public bool Delete(string id)
    {
        if (!IsId(id))
        {
            return false;
        }

        lock (_gate)
        {
            var folder = Path.Combine(Folder, id);
            if (!File.Exists(Path.Combine(folder, ProjectFileName)))
            {
                return false;
            }

            Directory.Delete(folder, recursive: true);
            return true;
        }
    }

    /// <summary>Keeps a picture made, with the prompt and the request it was made from.</summary>
    public void SaveResult(string id, int number, byte[] image, string prompt, object request)
    {
        ArgumentNullException.ThrowIfNull(image);
        var folder = GenerationFolder(id, number) ?? throw new ArgumentException("Not a creative id: " + id, nameof(id));
        lock (_gate)
        {
            Directory.CreateDirectory(folder);
            File.WriteAllText(Path.Combine(folder, "prompt.txt"), prompt ?? "");
            File.WriteAllText(Path.Combine(folder, "request.json"), JsonSerializer.Serialize(request, Json));
            WriteAtomically(Path.Combine(folder, ResultFileName), image);
        }
    }

    /// <summary>A picture made, or null when there is none.</summary>
    public string? ResultPath(string id, int number) =>
        GenerationFolder(id, number) is { } folder && File.Exists(Path.Combine(folder, ResultFileName)) ? Path.Combine(folder, ResultFileName) : null;

    /// <summary>The prompt a picture was made from, or null.</summary>
    public string? Prompt(string id, int number) =>
        GenerationFolder(id, number) is { } folder && File.Exists(Path.Combine(folder, "prompt.txt")) ? File.ReadAllText(Path.Combine(folder, "prompt.txt")) : null;

    private string? GenerationFolder(string id, int number) =>
        IsId(id) && number > 0 ? Path.Combine(Folder, id, "generations", number.ToString(CultureInfo.InvariantCulture)) : null;

    /// <summary>Keeps a picture the owner added to take the look from; gives its name.</summary>
    public string AddReference(string id, byte[] bytes, string extension, DateTime now)
    {
        ArgumentNullException.ThrowIfNull(bytes);
        if (!IsId(id) || extension is not (".jpg" or ".png" or ".webp"))
        {
            throw new ArgumentException("Not a creative or a picture.");
        }

        lock (_gate)
        {
            var folder = Path.Combine(Folder, id, "assets");
            Directory.CreateDirectory(folder);
            var stamp = now.ToString("yyyyMMdd-HHmmss", CultureInfo.InvariantCulture);
            var name = $"reference-{stamp}{extension}";
            for (var n = 2; File.Exists(Path.Combine(folder, name)); n++)
            {
                name = $"reference-{stamp}-{n}{extension}";
            }

            File.WriteAllBytes(Path.Combine(folder, name), bytes);
            return name;
        }
    }

    public string? AssetPath(string id, string? name) =>
        IsId(id) && IsAssetName(name) && File.Exists(Path.Combine(Folder, id, "assets", name!)) ? Path.Combine(Folder, id, "assets", name!) : null;

    public void RemoveAsset(string id, string name)
    {
        if (AssetPath(id, name) is { } path)
        {
            File.Delete(path);
        }
    }

    /// <summary>Keeps an exported picture under a readable name, e.g. "diwali-offer-square-2.png"; gives the name.</summary>
    public string SaveExport(string id, byte[] png, string title, string format, int number)
    {
        ArgumentNullException.ThrowIfNull(png);
        if (!IsId(id))
        {
            throw new ArgumentException("Not a creative id: " + id, nameof(id));
        }

        var name = Slug(title) + "-" + format + "-" + number.ToString(CultureInfo.InvariantCulture) + ".png";
        lock (_gate)
        {
            var folder = Path.Combine(Folder, id, "exports");
            Directory.CreateDirectory(folder);
            WriteAtomically(Path.Combine(folder, name), png);
        }

        return name;
    }

    public string? ExportPath(string id, string? name) =>
        IsId(id) && IsExportName(name) && File.Exists(Path.Combine(Folder, id, "exports", name!)) ? Path.Combine(Folder, id, "exports", name!) : null;

    /// <summary>The shop's brand; empty when none was saved.</summary>
    public CreativeBrand LoadBrand()
    {
        var path = Path.Combine(Folder, BrandFolderName, BrandFileName);
        lock (_gate)
        {
            try
            {
                var brand = File.Exists(path) ? JsonSerializer.Deserialize<CreativeBrand>(File.ReadAllText(path), Json) : null;
                return brand is null ? new CreativeBrand() : brand with
                {
                    Colours = brand.Colours.Select(TagLayout.CleanColour).OfType<string>().Take(CreativeBrand.MaxColours).ToList(),
                    Logo = IsLogoName(brand.Logo) ? brand.Logo : null,
                };
            }
            catch (Exception ex) when (ex is JsonException or IOException or NotSupportedException or UnauthorizedAccessException)
            {
                return new CreativeBrand();
            }
        }
    }

    public void SaveBrand(CreativeBrand brand)
    {
        ArgumentNullException.ThrowIfNull(brand);
        lock (_gate)
        {
            var folder = Path.Combine(Folder, BrandFolderName);
            Directory.CreateDirectory(folder);
            WriteAtomically(Path.Combine(folder, BrandFileName), JsonSerializer.Serialize(brand, Json));
        }
    }

    /// <summary>Keeps the shop's logo, in place of any earlier one; gives its name.</summary>
    public string SaveLogo(byte[] bytes, string extension, DateTime now)
    {
        ArgumentNullException.ThrowIfNull(bytes);
        if (extension is not (".jpg" or ".png" or ".webp"))
        {
            throw new ArgumentException("The logo must be a JPG, PNG or WEBP picture.", nameof(extension));
        }

        lock (_gate)
        {
            var folder = Path.Combine(Folder, BrandFolderName);
            Directory.CreateDirectory(folder);
            foreach (var old in Directory.EnumerateFiles(folder).Where(file => IsLogoName(Path.GetFileName(file))))
            {
                File.Delete(old);
            }

            var name = "logo-" + now.ToString("yyyyMMdd-HHmmss", CultureInfo.InvariantCulture) + extension;
            File.WriteAllBytes(Path.Combine(folder, name), bytes);
            return name;
        }
    }

    public string? LogoPath(string? name) =>
        IsLogoName(name) && File.Exists(Path.Combine(Folder, BrandFolderName, name!)) ? Path.Combine(Folder, BrandFolderName, name!) : null;

    /// <summary>"Diwali offer!" as "diwali-offer"; "creative" when nothing is left.</summary>
    internal static string Slug(string? title)
    {
        var slug = SlugBreak().Replace((title ?? "").ToLowerInvariant(), "-").Trim('-');
        slug = slug.Length > 40 ? slug[..40].TrimEnd('-') : slug;
        return slug.Length == 0 ? "creative" : slug;
    }

    private static CreativeBrief Clean(CreativeBrief brief) => brief with
    {
        Products = brief.Products.Where(item => item.ProductId > 0).DistinctBy(item => item.ProductId).Take(CreativeBrief.MaxProducts).ToList(),
        References = brief.References.Where(IsAssetName).Distinct().Take(CreativeBrief.MaxReferences).ToList(),
    };

    private static void WriteAtomically(string path, string text)
    {
        var temporary = path + ".tmp";
        File.WriteAllText(temporary, text);
        File.Move(temporary, path, overwrite: true);
    }

    private static void WriteAtomically(string path, byte[] bytes)
    {
        var temporary = path + ".tmp";
        File.WriteAllBytes(temporary, bytes);
        File.Move(temporary, path, overwrite: true);
    }

    [GeneratedRegex(@"^\d{8}-\d{6}(-\d{1,3})?$")]
    private static partial Regex IdPattern();

    [GeneratedRegex(@"^reference-\d{8}-\d{6}(-\d{1,3})?\.(jpg|png|webp)$")]
    private static partial Regex AssetPattern();

    [GeneratedRegex(@"^[a-z0-9-]{1,40}-[a-z0-9]{1,12}-\d{1,4}\.png$")]
    private static partial Regex ExportPattern();

    [GeneratedRegex(@"^logo-\d{8}-\d{6}\.(jpg|png|webp)$")]
    private static partial Regex LogoPattern();

    [GeneratedRegex(@"[^a-z0-9]+")]
    private static partial Regex SlugBreak();
}
