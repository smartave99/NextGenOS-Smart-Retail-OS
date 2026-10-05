using NextGenOS.Licensing;
using NextGenOS.Licensing.AspNetCore;

namespace NextGenOS.Hub.Web.Branding;

/// <summary>
/// What the owner chose to change about the look on this PC (colours, logo, support contact, and with a "full" licence the product name).
/// Kept in the shop's database. Whether it shows, and how much of it, is decided by the licence (<see cref="BrandPolicy"/>), so a licence with a
/// fixed look keeps its look however this was filled in.
/// </summary>
public sealed class LocalBrandStore : IBrandOverrides
{
    public const string Key = "brand.local";
    private readonly Func<HubApp> shop;

    // The shop is found only when it is needed, so the "licence needed" page (which is built with the brand) never opens the shop's database.
    public LocalBrandStore(IServiceProvider services) => shop = () => services.GetRequiredService<HubApp>();

    private LocalBrandStore(HubApp app) => shop = () => app;

    /// <summary>A store over a shop already open (the tests use this).</summary>
    public static LocalBrandStore Over(HubApp app) => new(app);

    private HubApp app => shop();

    private readonly object gate = new();
    private LocalBrand? cached;
    private bool loaded;

    public LocalBrand? Current
    {
        get
        {
            lock (gate)
            {
                if (!loaded)
                {
                    var text = app.SettingsStore.GetText(Key);
                    cached = string.IsNullOrWhiteSpace(text) ? null : LocalBrand.Parse(text);
                    loaded = true;
                }
                return cached;
            }
        }
    }

    /// <summary>What is wrong with a local brand, in words for the person; null when it is fine. Empty fields are fine (they mean "leave as it is").</summary>
    public static string? Check(LocalBrand b)
    {
        if (!string.IsNullOrWhiteSpace(b.PrimaryColor) && BrandPolicy.UsableColour(b.PrimaryColor.Trim()) is null) return ColourProblem("main colour", b.PrimaryColor);
        if (!string.IsNullOrWhiteSpace(b.AccentColor) && BrandPolicy.UsableColour(b.AccentColor.Trim()) is null) return ColourProblem("second colour", b.AccentColor);
        if (!string.IsNullOrEmpty(b.Logo) && CheckPicture(b.Logo) is { } picture) return picture;
        if (BrandPolicy.CleanText(b.Name, 200).Length > 60) return "The name can have at most 60 letters.";
        if (BrandPolicy.CleanText(b.ShortName, 200).Length > 60) return "The short name can have at most 60 letters.";
        if (BrandPolicy.CleanText(b.SupportEmail, 500).Length > 120) return "The support email is too long.";
        if (BrandPolicy.CleanText(b.SupportPhone, 500).Length > 40) return "The support phone is too long.";
        return null;
    }

    /// <summary>
    /// A logo chosen on this PC must be a real PNG or JPEG picture (the first bytes say so) of at most 100 KB. SVG is left out here on purpose: a picture
    /// that can carry its own instructions is not something to accept from a file chosen at the counter.
    /// </summary>
    public static string? CheckPicture(string dataUri)
    {
        const string problem = "The logo must be a PNG or JPEG picture of at most 100 KB.";
        if (BrandPolicy.ValidLogo(dataUri) is null) return problem;
        var comma = dataUri.IndexOf(',');
        var type = dataUri[5..dataUri.IndexOf(';')];
        byte[] bytes;
        try { bytes = Convert.FromBase64String(dataUri[(comma + 1)..]); } catch (FormatException) { return problem; }
        if (bytes.Length > 100_000) return problem;
        var png = bytes.Length > 8 && bytes[0] == 0x89 && bytes[1] == 0x50 && bytes[2] == 0x4E && bytes[3] == 0x47;
        var jpeg = bytes.Length > 3 && bytes[0] == 0xFF && bytes[1] == 0xD8 && bytes[2] == 0xFF;
        return (type == "image/png" && png) || (type == "image/jpeg" && jpeg) ? null : problem;
    }

    /// <summary>The data address for a picture's bytes, or the reason it cannot be used.</summary>
    public static string? FromBytes(byte[] bytes, out string? problem)
    {
        var png = bytes.Length > 8 && bytes[0] == 0x89 && bytes[1] == 0x50 && bytes[2] == 0x4E && bytes[3] == 0x47;
        var jpeg = bytes.Length > 3 && bytes[0] == 0xFF && bytes[1] == 0xD8 && bytes[2] == 0xFF;
        var uri = png || jpeg ? $"data:{(png ? "image/png" : "image/jpeg")};base64,{Convert.ToBase64String(bytes)}" : null;
        problem = uri is null ? "The logo must be a PNG or JPEG picture." : bytes.Length > 100_000 ? "The logo is too big. Use a picture of at most 100 KB." : null;
        return problem is null ? uri : null;
    }

    private static string ColourProblem(string what, string value) =>
        System.Text.RegularExpressions.Regex.IsMatch(value.Trim(), "^#[0-9a-fA-F]{6}$")
            ? $"The {what} is too light to read white words on. Choose a darker colour."
            : $"The {what} must look like #0f6cbd (a # and six letters or numbers).";

    public void Save(LocalBrand brand, long? userId)
    {
        if (Check(brand) is { } problem) throw new HubException("brand", problem);
        var clean = new LocalBrand
        {
            Name = Nullable(BrandPolicy.CleanText(brand.Name, 60)),
            ShortName = Nullable(BrandPolicy.CleanText(brand.ShortName, 60)),
            PrimaryColor = Nullable(brand.PrimaryColor?.Trim().ToLowerInvariant()),
            AccentColor = Nullable(brand.AccentColor?.Trim().ToLowerInvariant()),
            Logo = Nullable(brand.Logo),
            SupportEmail = Nullable(BrandPolicy.CleanText(brand.SupportEmail, 120)),
            SupportPhone = Nullable(BrandPolicy.CleanText(brand.SupportPhone, 40)),
            PoweredBy = brand.PoweredBy,
        };
        Store(clean.IsEmpty ? string.Empty : clean.ToJson());
        app.Audit.Log(userId, "settings", "look", null, clean.IsEmpty ? "standard look restored" : "look changed");
    }

    /// <summary>Goes back to the licence's own look.</summary>
    public void Reset(long? userId)
    {
        Store(string.Empty);
        app.Audit.Log(userId, "settings", "look", null, "standard look restored");
    }

    private void Store(string text)
    {
        app.SettingsStore.SetText(Key, text);
        lock (gate) { loaded = false; cached = null; }
    }

    private static string? Nullable(string? text) => string.IsNullOrWhiteSpace(text) ? null : text;
}
