namespace SmartRetail.Pos.Core.Checks;

public enum FindingLevel
{
    /// <summary>Money is being lost, or the law broken, now.</summary>
    FixNow,

    /// <summary>Worth a look soon: maybe a mistake, maybe on purpose.</summary>
    CheckSoon,
}

public enum FindingKind
{
    BelowCost,
    AboveMrp,
    SoldAtLoss,
    SoldAboveMrp,
    SameCode,
    BigDiscount,
    FarAboveCost,
    NoCost,
    NegativeStock,
    MissingBills,
    OwedLong,
}

/// <summary>A bill a finding is about, with the day the POS dated it: where "when it happened" comes from.</summary>
public sealed record FindingBill(long Id, string Number, DateOnly Day);

/// <summary>Something in the POS that needs someone to act: what, the figures, and what to do there.</summary>
public sealed record Finding
{
    /// <summary>Stays the same while the figures behind it do, so "on purpose" hides it until they change.</summary>
    public string Key { get; init; } = "";
    public FindingKind Kind { get; init; }
    public FindingLevel Level { get; init; }
    public string Title { get; init; } = "";
    public string Detail { get; init; } = "";
    public string WhatToDo { get; init; } = "";
    public int? ProductId { get; init; }
    public long? BillId { get; init; }

    /// <summary>What finds the product(s) on the Products page: a name, or the shared barcode.</summary>
    public string? Search { get; init; }

    /// <summary>Rupees lost or at stake, for putting the biggest first.</summary>
    public decimal AtStake { get; init; }

    /// <summary>The bills it is about: when it happened. Empty for a finding about prices or stock, which the POS gives no date.</summary>
    public IReadOnlyList<FindingBill> Bills { get; init; } = Array.Empty<FindingBill>();

    /// <summary>The oldest day it goes back to, for money owed for a long time; null for the others.</summary>
    public DateOnly? Since { get; init; }

    /// <summary>
    /// The same problem while its figures change (a price moving, a stock count falling), which <see cref="Key"/> does not stay
    /// the same through: what "first noticed" follows. Null for a finding about bills, which carry their own dates.
    /// </summary>
    public string? Problem { get; init; }

    /// <summary>When it happened, or was first noticed, in words (<see cref="FindingTimes"/>); empty when that is not known.</summary>
    public string When { get; init; } = "";
}

public static class FindingKinds
{
    /// <summary>What a group of findings is called on the page, e.g. "Selling below cost".</summary>
    public static string Heading(this FindingKind kind) => kind switch
    {
        FindingKind.BelowCost => "Selling below cost",
        FindingKind.AboveMrp => "Price above MRP",
        FindingKind.SoldAtLoss => "Sold at a loss this week",
        FindingKind.SoldAboveMrp => "Charged above MRP this week",
        FindingKind.SameCode => "One barcode on two products",
        FindingKind.BigDiscount => "Big discounts this week",
        FindingKind.FarAboveCost => "Price far above cost",
        FindingKind.NoCost => "No purchase price",
        FindingKind.NegativeStock => "Stock below zero",
        FindingKind.MissingBills => "Missing bill numbers",
        FindingKind.OwedLong => "Money owed for a long time",
        _ => kind.ToString(),
    };
}
