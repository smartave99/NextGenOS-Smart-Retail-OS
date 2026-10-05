namespace SmartRetail.Pos.Core.Models;

/// <summary>A sellable product (POS table <c>Product</c>, key <c>PID</c>).</summary>
public sealed record Product
{
    public int Id { get; init; }
    public string Code { get; init; } = "";
    public string Name { get; init; } = "";
    public string? Barcode { get; init; }
    public string? HsnCode { get; init; }
    public string? Category { get; init; }

    /// <summary>The price the product is billed at.</summary>
    public decimal SellingPrice { get; init; }
    public decimal Mrp { get; init; }
    public decimal GstRatePercent { get; init; }

    /// <summary>Reorder level.</summary>
    public decimal MinStock { get; init; }

    /// <summary>Stock in hand: the sum of the product's <c>Temp_Stock</c> rows.</summary>
    public decimal StockInHand { get; init; }

    public bool IsLowStock => MinStock > 0 && StockInHand < MinStock;
}
