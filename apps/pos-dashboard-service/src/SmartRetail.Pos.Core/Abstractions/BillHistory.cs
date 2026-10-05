namespace SmartRetail.Pos.Core.Abstractions;

/// <summary>Which bills to show: a date range, a search and whether only bills with money still owed.</summary>
public sealed record BillQuery
{
    public const int MaxTake = 5000;
    public const int MaxText = 100;

    /// <summary>Searched dates are kept within these, which every database and date sum can hold (SQL Server's
    /// datetime starts in 1753; the day after 31 Dec 9999 does not exist).</summary>
    public static readonly DateOnly EarliestDate = new(1900, 1, 1);
    public static readonly DateOnly LatestDate = new(9998, 12, 31);

    public DateOnly? From { get; init; }
    public DateOnly? To { get; init; }

    /// <summary>Part of a bill number, a customer's name or phone number.</summary>
    public string? Text { get; init; }

    /// <summary>Only bills with a balance still owed (given on credit).</summary>
    public bool OnlyOwed { get; init; }

    /// <summary>Only bills up to this id (<see cref="BillPage.NewestId"/> of an earlier search), so later pages stay
    /// steady while new bills come in.</summary>
    public long? UpToId { get; init; }

    public int Skip { get; init; }
    public int Take { get; init; } = 50;

    /// <summary>The query kept to sane values: dates in order and in range, a short search, paging within bounds.</summary>
    public BillQuery Checked()
    {
        var (from, to) = From is { } f && To is { } t && t < f ? (To, From) : (From, To);
        from = from is { } earliest ? Clamp(earliest) : null;
        to = to is { } latest ? Clamp(latest) : null;
        var text = Text?.Trim();
        return this with
        {
            From = from,
            To = to,
            Text = string.IsNullOrEmpty(text) ? null : text.Length > MaxText ? text[..MaxText] : text,
            Skip = Math.Max(0, Skip),
            Take = Math.Clamp(Take, 1, MaxTake),
        };
    }

    private static DateOnly Clamp(DateOnly date) => date < EarliestDate ? EarliestDate : date > LatestDate ? LatestDate : date;
}

/// <summary>One page of bills, with what the whole search adds up to.</summary>
public sealed record BillPage
{
    public IReadOnlyList<InvoiceSummary> Items { get; init; } = Array.Empty<InvoiceSummary>();

    /// <summary>How many bills match the search, on every page.</summary>
    public int Total { get; init; }
    public decimal TotalAmount { get; init; }
    public decimal TotalOwed { get; init; }

    /// <summary>The first and the latest matching bill.</summary>
    public DateTime? First { get; init; }
    public DateTime? Last { get; init; }

    /// <summary>The highest bill id that matches; a new bill always has a higher one.</summary>
    public long? NewestId { get; init; }
}

/// <summary>One item on a bill, as the POS saved it.</summary>
public sealed record BillItem
{
    public int ProductId { get; init; }
    public string Name { get; init; } = "";
    public string Code { get; init; } = "";
    public decimal Qty { get; init; }
    public string Unit { get; init; } = "";
    public decimal Rate { get; init; }
    public decimal Mrp { get; init; }
    public decimal Discount { get; init; }

    /// <summary>CGST + SGST + IGST, in percent.</summary>
    public decimal TaxPercent { get; init; }
    public decimal Tax { get; init; }
    public decimal Amount { get; init; }
}

public sealed record BillPayment(DateTime? Date, string Mode, decimal Amount);

/// <summary>Everything about one bill.</summary>
public sealed record BillDetails
{
    public InvoiceSummary Summary { get; init; } = new();
    public string? CustomerPhone { get; init; }
    public decimal SubTotal { get; init; }
    public decimal Discount { get; init; }
    public decimal Cgst { get; init; }
    public decimal Sgst { get; init; }
    public decimal Igst { get; init; }
    public decimal RoundOff { get; init; }
    public decimal Paid { get; init; }
    public string? Operator { get; init; }
    public string? Remarks { get; init; }
    public IReadOnlyList<BillItem> Items { get; init; } = Array.Empty<BillItem>();
    public IReadOnlyList<BillPayment> Payments { get; init; } = Array.Empty<BillPayment>();
}
