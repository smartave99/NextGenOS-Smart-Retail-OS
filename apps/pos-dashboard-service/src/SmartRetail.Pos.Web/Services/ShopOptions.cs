using SmartRetail.Pos.Core.Billing;

namespace SmartRetail.Pos.Web.Services;

/// <summary>The "Shop" section of appsettings.json: what prints on the receipt, and billing defaults.</summary>
public sealed class ShopOptions
{
    public const string SectionName = "Shop";

    /// <summary>The name used when neither appsettings nor the POS database names the shop.</summary>
    public const string DefaultName = "Smart Retail POS";

    public const string DemoName = "Demo Store";
    public const string DemoAddress = "12 Market Road, Pune 411001";

    /// <summary>Empty: the shop's name from the POS database, or the demo shop's.</summary>
    public string Name { get; set; } = "";
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Gstin { get; set; }
    public string ReceiptTitle { get; set; } = "Tax Invoice";
    public string ReceiptFooter { get; set; } = "Thank you! Please visit again.";

    public GstMode GstMode { get; set; } = GstMode.Intrastate;
    public bool PricesIncludeTax { get; set; } = true;
    public bool RoundToNearestRupee { get; set; } = true;

    public BillOptions ToBillOptions() => new()
    {
        GstMode = GstMode,
        PricesIncludeTax = PricesIncludeTax,
        RoundToNearestRupee = RoundToNearestRupee,
    };
}
