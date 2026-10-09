namespace NextGenOS.Hub.Catalog;

public sealed record Party(
    long Id, string Kind, string? Code, string Name, string? Phone, string? Email, string? Address, string? TaxId, string? Region,
    string? MemberType, string PriceLevel, long CreditLimitMinor, int TermsDays, string? CardBarcode, string? Notes, bool Active);

public sealed class PartyInput
{
    public string Kind { get; set; } = "customer";
    public string? Code { get; set; }
    public string Name { get; set; } = "";
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? TaxId { get; set; }
    public string? Region { get; set; }
    public string? MemberType { get; set; }
    public string PriceLevel { get; set; } = "retail";
    public long CreditLimitMinor { get; set; }
    public int TermsDays { get; set; }
    public string? CardBarcode { get; set; }
    public string? Notes { get; set; }
}

/// <summary>The loose attributes of an item that the Hub itself reads (the rest are the shop's own notes).</summary>
public static class ItemAttrs
{
    /// <summary>The code of the goods or service sold, under the country's own name for it (the pack says what it is called; a country without one shows no such field).</summary>
    public const string Code = "item-code";
    /// <summary>A further tax on top of the main one, as a percent ("12" or "2.5"), under the country's own name for it.</summary>
    public const string ExtraTax = "extra-tax-percent";
}

public sealed record Item(
    long Id, string Kind, string? Sku, string? Barcode, string Name, string? Category, string Unit, long PriceMinor, long? TradePriceMinor, long CostMinor,
    string TaxCode, bool TrackStock, long ReorderMilli, string? Station, int? DurationMin, IReadOnlyDictionary<string, string> Attrs, bool Active, bool TrackBatches = false, long? PackItemId = null, long PerPackMilli = 0)
{
    /// <summary>The price for a customer's price level: trade customers get the trade price when the item has one.</summary>
    public long PriceFor(string priceLevel) => priceLevel == "trade" && TradePriceMinor.HasValue ? TradePriceMinor.Value : PriceMinor;
}

public sealed class ItemInput
{
    public string Kind { get; set; } = "stock";
    public string? Sku { get; set; }
    public string? Barcode { get; set; }
    public string Name { get; set; } = "";
    public string? Category { get; set; }
    public string Unit { get; set; } = "pc";
    public long PriceMinor { get; set; }
    public long? TradePriceMinor { get; set; }
    public long CostMinor { get; set; }
    /// <summary>"standard", "reduced", "zero", "exempt" or a rate code of the country.</summary>
    public string TaxClass { get; set; } = "standard";
    /// <summary>Null: follow the item kind and the industry.</summary>
    public bool? TrackStock { get; set; }
    /// <summary>Keep this item's stock in batches, with a batch number and an expiry date (medicines, food). Null: leave as it is (a new item: not kept). Only an item that keeps stock can keep batches.</summary>
    public bool? TrackBatches { get; set; }
    /// <summary>Sell this item loose from a pack: the item whose packs it is opened from (null: leave as it is; 0: no longer sold loose). A piece of a box is sold loose from the box.</summary>
    public long? PackItemId { get; set; }
    /// <summary>How many of this item one pack holds, in thousandths (12000 = twelve). Needed with <see cref="PackItemId"/>.</summary>
    public long? PerPackMilli { get; set; }
    public long ReorderMilli { get; set; }
    public string? Station { get; set; }
    public int? DurationMin { get; set; }
    public Dictionary<string, string> Attrs { get; set; } = new();
}

/// <summary>One tracked item's stock. <paramref name="CostMinor"/> is the average cost of what is on the shelf (the last cost price when there is no average); <paramref name="ValueMinor"/> is what the stock on the shelf is worth in money, from its moves.</summary>
public sealed record StockRow(long ItemId, string Name, string? Category, string Unit, long OnHandMilli, long ReorderMilli, long CostMinor, long ValueMinor = 0);
