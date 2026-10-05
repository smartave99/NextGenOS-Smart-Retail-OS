using System.Text.Json;
using NextGenOS.Hub.Data;

namespace NextGenOS.Hub.Shop;

/// <summary>What the shop owner chose in the set-up wizard and in Settings.</summary>
public sealed class ShopSettings
{
    public string Name { get; set; } = "";
    public string Address { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Email { get; set; } = "";
    /// <summary>The shop's own tax number (GSTIN, TIN, VAT number ...).</summary>
    public string TaxId { get; set; } = "";
    public string Country { get; set; } = "IN";
    /// <summary>The state or province code that decides local tax (for India the GST state code, for Canada "ON").</summary>
    public string Region { get; set; } = "";
    public string Industry { get; set; } = "retail";
    public bool PricesIncludeTax { get; set; } = true;
    /// <summary>False for a shop that is not registered for the tax: no tax is charged.</summary>
    public bool TaxRegistered { get; set; } = true;
    public bool RoundTotal { get; set; }
    public bool AllowNegativeStock { get; set; } = true;
    public string ReceiptFooter { get; set; } = "Thank you!";
    public bool SetupDone { get; set; }
    /// <summary>Parts of the Hub the owner switched on or off, over the industry's defaults (name → on/off).</summary>
    public Dictionary<string, bool> FeatureOverrides { get; set; } = new();
    /// <summary>Words the owner renamed (for example "customer" → "Member"): singular and plural.</summary>
    public Dictionary<string, string[]> VocabularyOverrides { get; set; } = new();
    public List<string> PaymentMethods { get; set; } = new();
    /// <summary>The shop's own changes to the country's rates: code → percent (for example the sales tax of a US county).</summary>
    public Dictionary<string, string> RateOverrides { get; set; } = new();
    /// <summary>Region components the shop sets itself (regional packs): "region/component" → percent.</summary>
    public Dictionary<string, string> ComponentOverrides { get; set; } = new();
    /// <summary>The industry's default adjustments the owner switched off or changed: code → percent ("" is off).</summary>
    public Dictionary<string, string> AdjustmentOverrides { get; set; } = new();
    /// <summary>Money amounts that depend on the shop, as decimal text: library fine per day, and so on.</summary>
    public Dictionary<string, string> RuleOverrides { get; set; } = new();
}

/// <summary>Settings kept in the database as key/value rows.</summary>
public sealed class SettingsStore(HubDb db)
{
    private const string Key = "shop";
    private static readonly JsonSerializerOptions Json = new() { WriteIndented = false, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    public ShopSettings Load()
    {
        var text = db.Scalar("SELECT value FROM settings WHERE key = $k", ("$k", Key)) as string;
        return text is null ? new ShopSettings() : JsonSerializer.Deserialize<ShopSettings>(text, Json) ?? new ShopSettings();
    }

    public void Save(ShopSettings settings)
    {
        var text = JsonSerializer.Serialize(settings, Json);
        db.InTransaction((c, t) => HubDb.Exec(c, "INSERT INTO settings(key, value) VALUES ($k, $v) ON CONFLICT(key) DO UPDATE SET value = excluded.value", t, ("$k", Key), ("$v", text)));
    }

    public string? GetText(string key) => db.Scalar("SELECT value FROM settings WHERE key = $k", ("$k", key)) as string;

    public void SetText(string key, string value) =>
        db.InTransaction((c, t) => HubDb.Exec(c, "INSERT INTO settings(key, value) VALUES ($k, $v) ON CONFLICT(key) DO UPDATE SET value = excluded.value", t, ("$k", key), ("$v", value)));
}
