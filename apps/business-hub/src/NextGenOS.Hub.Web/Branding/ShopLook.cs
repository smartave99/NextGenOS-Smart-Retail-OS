namespace NextGenOS.Hub.Web.Branding;

/// <summary>
/// The two looks of the program. The list look is for a PC or laptop monitor: the menu along the top, items as a list you scroll down, the bill below.
/// The counter look is for a touch screen at the counter: big buttons, the menu on the left, the items in the middle and the bill on the right, all in view.
/// Each look is a bundle of the settings the theme already has (size of buttons, menu place, bill place, text size), so no new licence setting is needed.
/// The same values are written in wwwroot/theme.js (which applies a look before the first picture is drawn); a test keeps the two in step.
/// </summary>
public static class ShopLooks
{
    public sealed record Look(string Id, string Name, string Text, string Density, string Nav, string NavLabels, string Cart, double FontScale);

    public static readonly Look List = new("list", "List look",
        "For a PC or laptop: the menu along the top, items as a list you scroll down, the bill below.",
        "comfortable", "top", "full", "bottom", 1.0);

    public static readonly Look Counter = new("counter", "Counter look",
        "For a touch screen at the counter: big buttons, the menu on the left, the items in the middle and the bill on the right, all in view.",
        "touch", "left", "full", "right", 1.1);

    /// <summary>What the shop can choose: as it was before (standard), the screen decides (auto: a touch screen gets the counter look, any other the list look), or one of the two.</summary>
    public static readonly string[] Choices = ["standard", "auto", "list", "counter"];

    public static Look? Get(string? id) => id switch { "list" => List, "counter" => Counter, _ => null };

    public static string Known(string? id) => id is not null && Array.IndexOf(Choices, id) >= 0 ? id : "standard";
}

/// <summary>The look the owner chose for the whole shop, kept in the shop's database. A single computer can still choose its own (kept in that browser).</summary>
public sealed class ShopLookStore
{
    public const string Key = "look.shop";
    private readonly Func<HubApp> shop;
    private readonly object gate = new();
    private string? cached;

    // The shop is found only when it is needed (the "licence needed" page is built without it).
    public ShopLookStore(IServiceProvider services) => shop = () => services.GetRequiredService<HubApp>();

    private ShopLookStore(HubApp app) => shop = () => app;

    /// <summary>A store over a shop already open (the tests use this).</summary>
    public static ShopLookStore Over(HubApp app) => new(app);

    public string Current
    {
        get
        {
            lock (gate)
            {
                return cached ??= ShopLooks.Known(shop().SettingsStore.GetText(Key));
            }
        }
    }

    public void Save(string id, long? userId)
    {
        var clean = ShopLooks.Known(id);
        var app = shop();
        app.SettingsStore.SetText(Key, clean);
        lock (gate) cached = null;
        app.Audit.Log(userId, "settings", "look", null, $"look of the shop: {clean}");
    }
}
