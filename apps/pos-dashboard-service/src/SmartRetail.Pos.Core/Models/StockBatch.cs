namespace SmartRetail.Pos.Core.Models;

/// <summary>
/// A product's stock at one price (POS table <c>Temp_Stock</c>), with the code the till scans for it. The POS bills
/// by this code, and prints it on the product's sticker; it can differ from the product's own barcode.
/// </summary>
public sealed record StockBatch
{
    public int ProductId { get; init; }

    /// <summary>The product's name.</summary>
    public string Name { get; init; } = "";

    /// <summary>The code on the sticker: what the till scans or the cashier types.</summary>
    public string Code { get; init; } = "";
    public decimal Mrp { get; init; }

    /// <summary>The price this stock is billed at.</summary>
    public decimal Price { get; init; }
    public decimal Qty { get; init; }
    public string? Batch { get; init; }
}
