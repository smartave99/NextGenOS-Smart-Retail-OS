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

    /// <summary>The starting look (the owner's choice of 9 October 2026): one bar along the top with the menu as big pictures above words, big buttons for a finger, and on the sell screen the items and the bill side by side. It suits a touch counter and a mouse alike.</summary>
    public static readonly Look Top = new("top", "Top menu look",
        "The default: one bar along the top with the menu as big pictures, big buttons for a finger or a mouse, and on the sell screen the items and the bill side by side.",
        "touch", "top", "full", "right", 1.0);

    public static readonly Look Counter = new("counter", "Counter look",
        "For a touch screen at the counter: big buttons, the menu on the left, the items in the middle and the bill on the right, all in view.",
        "touch", "left", "full", "right", 1.1);

    /// <summary>What the shop can choose: as it was before (standard), the screen decides (auto: a touch screen gets the counter look, any other the list look), or one of the two.</summary>
    public static readonly string[] Choices = ["top", "standard", "auto", "list", "counter"];

    /// <summary>The look a shop has when nobody has chosen one (and its customer's profile does not name one).</summary>
    public const string Default = "top";

    public static Look? Get(string? id) => id switch { "top" => Top, "list" => List, "counter" => Counter, _ => null };

    /// <summary>The id when it is one of the choices, otherwise null.</summary>
    public static string? Valid(string? id) => id is not null && Array.IndexOf(Choices, id) >= 0 ? id : null;

    /// <summary>The id when it is one of the choices, otherwise "standard" (the layout as the settings below it say).</summary>
    public static string Known(string? id) => Valid(id) ?? "standard";
}

/// <summary>The look the owner chose for the whole shop, kept in the shop's database. A single computer can still choose its own (kept in that browser).</summary>
public sealed class ShopLookStore
{
    public const string Key = "look.shop";
    private readonly Func<HubApp> shop;
    private readonly object gate = new();
    private string? cached;
    private bool loaded;

    // The shop is found only when it is needed (the "licence needed" page is built without it).
    public ShopLookStore(IServiceProvider services) => shop = () => services.GetRequiredService<HubApp>();

    private ShopLookStore(HubApp app) => shop = () => app;

    /// <summary>A store over a shop already open (the tests use this).</summary>
    public static ShopLookStore Over(HubApp app) => new(app);

    /// <summary>What the owner chose for the shop, or null when nobody has.</summary>
    public string? Chosen
    {
        get
        {
            lock (gate)
            {
                if (!loaded) { cached = ShopLooks.Valid(shop().SettingsStore.GetText(Key)); loaded = true; }
                return cached;
            }
        }
    }

    /// <summary>The look in force for the shop: the owner's choice, else what the customer's profile names, else the starting look. A profile that sets the layout settings itself (button size, menu place ...) keeps them: nothing chosen then means "as the settings say".</summary>
    public string Effective(string? profileLook, bool themeSetsLayout) => Chosen ?? ShopLooks.Valid(profileLook) ?? (themeSetsLayout ? "standard" : ShopLooks.Default);

    public void Save(string id, long? userId)
    {
        var clean = ShopLooks.Known(id);
        var app = shop();
        app.SettingsStore.SetText(Key, clean);
        lock (gate) { cached = null; loaded = false; }
        app.Audit.Log(userId, "settings", "look", null, $"look of the shop: {clean}");
    }
}
