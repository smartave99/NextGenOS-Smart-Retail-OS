namespace SmartRetail.Pos.Core.Billing;

/// <summary>The money worked out for a whole bill.</summary>
public sealed record BillTotals
{
    public int ItemCount { get; init; }
    public decimal TotalQty { get; init; }
    public decimal Discount { get; init; }
    public decimal Taxable { get; init; }
    public decimal Cgst { get; init; }
    public decimal Sgst { get; init; }
    public decimal Igst { get; init; }
    public decimal Tax => Cgst + Sgst + Igst;

    /// <summary>Taxable value plus tax, before round-off.</summary>
    public decimal SubTotal { get; init; }
    public decimal RoundOff { get; init; }
    public decimal GrandTotal { get; init; }

    public static BillTotals Empty { get; } = new();
}
