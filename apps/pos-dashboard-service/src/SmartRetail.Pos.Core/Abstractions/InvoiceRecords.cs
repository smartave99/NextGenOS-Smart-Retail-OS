namespace SmartRetail.Pos.Core.Abstractions;

/// <summary>What the store returns after saving a bill.</summary>
public sealed record SavedInvoice
{
    public long Id { get; init; }
    public string Number { get; init; } = "";
    public decimal GrandTotal { get; init; }
    public decimal ChangeDue { get; init; }
    public decimal Balance { get; init; }
}

/// <summary>One bill in a list.</summary>
public sealed record InvoiceSummary
{
    public long Id { get; init; }
    public string Number { get; init; } = "";

    /// <summary>The bill's date. The POS keeps no time of day on it: see <see cref="SavedAt"/>.</summary>
    public DateTime Date { get; init; }

    public string CustomerName { get; init; } = "";
    public decimal GrandTotal { get; init; }
    public decimal Balance { get; init; }

    /// <summary>When the POS saved the bill, from its own log; null when the log does not have it.</summary>
    public DateTime? SavedAt { get; init; }

    /// <summary>The time of day the bill was made: when it was saved on its own date. Null when that is not known,
    /// or it was typed in on a later day (<see cref="EnteredLater"/>).</summary>
    public TimeOnly? Time => BillTimes.TimeOf(DateOnly.FromDateTime(Date), SavedAt);

    /// <summary>Typed in on a later day than its date, so when it was saved is not when it was sold.</summary>
    public bool EnteredLater => BillTimes.EnteredLater(DateOnly.FromDateTime(Date), SavedAt);
}

/// <summary>Sales totals for one day.</summary>
public sealed record SalesSummary
{
    public DateOnly Day { get; init; }
    public int BillCount { get; init; }
    public decimal Total { get; init; }
    public decimal Outstanding { get; init; }
}

/// <summary>Where the app's data comes from, shown in the header.</summary>
public sealed record DataSourceInfo(string Name, bool IsDemo, bool CanSaveBills);
