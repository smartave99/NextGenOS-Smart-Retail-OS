namespace SmartRetail.Pos.Core.Billing;

/// <summary>The money worked out for one bill line.</summary>
public sealed record LineCharge
{
    /// <summary>Quantity × rate, before discount.</summary>
    public decimal Gross { get; init; }
    public decimal Discount { get; init; }

    /// <summary>Value before tax.</summary>
    public decimal Taxable { get; init; }
    public decimal Cgst { get; init; }
    public decimal Sgst { get; init; }
    public decimal Igst { get; init; }
    public decimal Tax => Cgst + Sgst + Igst;

    /// <summary>What the customer pays for this line.</summary>
    public decimal LineTotal { get; init; }
}
