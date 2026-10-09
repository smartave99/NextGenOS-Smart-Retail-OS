using NextGenOS.Licensing;

namespace NextGenOS.Hub.Web.Branding;

/// <summary>
/// The customer's profile: a small folder of data files that NextGenOS puts next to the program when it prepares a setup for one business (<c>profile/</c>): the look
/// (<c>theme.json</c>), the brand (<c>brand.json</c>) and, at first run, how the business is set up (<c>setup.json</c>). It is only data: it holds no code, and the licence's
/// white-label level still decides how much of it shows (<see cref="ThemePolicy"/>, <see cref="BrandPolicy"/>). A file that is missing or cannot be read is as if it were not there.
/// </summary>
public sealed class ProfileStore
{
    private readonly string folder;
    private readonly object gate = new();
    private ThemeSettings? theme;
    private string? look;
    private LocalBrand? brand;
    private bool loaded;

    public ProfileStore(IConfiguration configuration) =>
        folder = configuration["Hub:ProfileFolder"] is { Length: > 0 } chosen ? Path.GetFullPath(chosen) : Path.Combine(AppContext.BaseDirectory, "profile");

    public string Folder => folder;

    /// <summary>The theme the profile chose, or an empty one.</summary>
    public ThemeSettings Theme { get { Load(); return theme!; } }

    /// <summary>The look the customer's profile names in <c>theme.json</c> ("look": "top", "list", "counter", "auto" or "standard"), or null. It is the starting look of that business; the owner can still choose another.</summary>
    public string? Look { get { Load(); return look; } }

    /// <summary>The brand values the profile chose (colours, logo, help details, name), or an empty one.</summary>
    public LocalBrand Brand { get { Load(); return brand!; } }

    public string? ReadText(string name)
    {
        try
        {
            var path = Path.Combine(folder, name);
            // Only a plain file of this folder, and of a sensible size.
            var info = new FileInfo(path);
            return info.Exists && info.Length <= 2_000_000 && string.Equals(info.DirectoryName, folder.TrimEnd(Path.DirectorySeparatorChar), StringComparison.Ordinal) ? File.ReadAllText(path) : null;
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException) { return null; }
    }

    private void Load()
    {
        lock (gate)
        {
            if (loaded) return;
            var themeText = ReadText("theme.json");
            theme = ThemeSettings.Parse(themeText);
            look = ReadLook(themeText);
            brand = LocalBrand.Parse(ReadText("brand.json"));
            loaded = true;
        }
    }

    /// <summary>The "look" word of a theme file; anything that is not a word of the look list is left out (a bad file never stops a shop).</summary>
    private static string? ReadLook(string? json)
    {
        if (string.IsNullOrWhiteSpace(json)) return null;
        try
        {
            using var doc = System.Text.Json.JsonDocument.Parse(json);
            return doc.RootElement.ValueKind == System.Text.Json.JsonValueKind.Object && doc.RootElement.TryGetProperty("look", out var e) && e.ValueKind == System.Text.Json.JsonValueKind.String
                ? ShopLooks.Valid(e.GetString())
                : null;
        }
        catch (System.Text.Json.JsonException) { return null; }
    }
}
