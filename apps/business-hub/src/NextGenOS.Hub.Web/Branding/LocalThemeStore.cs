using NextGenOS.Licensing;

namespace NextGenOS.Hub.Web.Branding;

/// <summary>What the owner chose for the screen and layout on this PC, kept in the shop's database. How much of it shows is decided by the licence (<see cref="ThemePolicy"/>).</summary>
public sealed class LocalThemeStore
{
    public const string Key = "theme.local";
    private readonly Func<HubApp> shop;
    private readonly object gate = new();
    private ThemeSettings? cached;
    private bool loaded;

    // The shop is found only when it is needed (the "licence needed" page is built without it).
    public LocalThemeStore(IServiceProvider services) => shop = () => services.GetRequiredService<HubApp>();

    private LocalThemeStore(HubApp app) => shop = () => app;

    /// <summary>A store over a shop already open (the tests use this).</summary>
    public static LocalThemeStore Over(HubApp app) => new(app);

    public ThemeSettings Current
    {
        get
        {
            lock (gate)
            {
                if (!loaded)
                {
                    cached = ThemeSettings.Parse(shop().SettingsStore.GetText(Key));
                    loaded = true;
                }
                return cached!;
            }
        }
    }

    public void Save(ThemeSettings theme, long? userId)
    {
        // Only values the policy knows are kept: what is saved is what can show.
        var clean = new ThemeSettings
        {
            Mode = Known(theme.Mode, ThemePolicy.Modes), Surface = Known(theme.Surface, ThemePolicy.Surfaces), Shape = Known(theme.Shape, ThemePolicy.Shapes),
            Density = Known(theme.Density, ThemePolicy.Densities), Font = Known(theme.Font, ThemePolicy.Fonts), FontScale = ThemePolicy.Scale(theme.FontScale),
            Nav = Known(theme.Nav, ThemePolicy.NavPositions), NavLabels = Known(theme.NavLabels, ThemePolicy.NavLabelModes), Cart = Known(theme.Cart, ThemePolicy.CartPositions), Depth = Known(theme.Depth, ThemePolicy.Depths),
        };
        var app = shop();
        app.SettingsStore.SetText(Key, clean.IsEmpty ? string.Empty : clean.ToJson());
        lock (gate) { loaded = false; cached = null; }
        app.Audit.Log(userId, "settings", "layout", null, clean.IsEmpty ? "standard layout restored" : "layout changed");
    }

    public void Reset(long? userId) => Save(new ThemeSettings(), userId);

    private static string? Known(string? value, string[] allowed) => value is not null && Array.IndexOf(allowed, value) >= 0 ? value : null;
}
