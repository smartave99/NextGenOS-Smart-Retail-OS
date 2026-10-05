namespace SmartRetail.Pos.Core.Models;

/// <summary>Stock in hand for one product, against its reorder level.</summary>
public sealed record StockLevel
{
    public int ProductId { get; init; }
    public string Code { get; init; } = "";
    public string Name { get; init; } = "";
    public decimal InHand { get; init; }
    public decimal MinStock { get; init; }

    /// <summary>How many units are needed to get back to the reorder level.</summary>
    public decimal Shortfall => Math.Max(0m, MinStock - InHand);
}
