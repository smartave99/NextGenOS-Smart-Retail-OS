namespace SmartRetail.Pos.Core.Billing;

/// <summary>Shop-level billing rules.</summary>
public sealed record BillOptions
{
    public GstMode GstMode { get; init; } = GstMode.Intrastate;

    /// <summary>
    /// True when selling prices already include GST (usual for MRP retail): the customer pays the
    /// shelf price and the tax is worked out of it. False adds GST on top of the price.
    /// </summary>
    public bool PricesIncludeTax { get; init; } = true;

    /// <summary>Rounds the bill to the nearest rupee and shows the difference as round-off.</summary>
    public bool RoundToNearestRupee { get; init; } = true;

    public static BillOptions Default { get; } = new();
}
