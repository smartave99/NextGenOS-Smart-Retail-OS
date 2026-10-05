namespace SmartRetail.Pos.Core.Analytics;

/// <summary>How the shop did in a period, against the period just before it.</summary>
public sealed record SalesReport
{
    public DateRange Range { get; init; }
    public DateRange PreviousRange { get; init; }
    public SalesTotals Current { get; init; } = new();
    public SalesTotals Previous { get; init; } = new();

    /// <summary>Every day of the period, days without bills included.</summary>
    public IReadOnlyList<TrendPoint> Daily { get; init; } = Array.Empty<TrendPoint>();

    /// <summary>The calendar months the period touches.</summary>
    public IReadOnlyList<MonthPoint> Monthly { get; init; } = Array.Empty<MonthPoint>();

    /// <summary>Monday to Sunday.</summary>
    public IReadOnlyList<WeekdayPoint> Weekdays { get; init; } = Array.Empty<WeekdayPoint>();

    /// <summary>Sales in each hour of the day over the period, from the earliest to the latest hour with a bill;
    /// empty when no bill's time is known.</summary>
    public IReadOnlyList<HourPoint> Hours { get; init; } = Array.Empty<HourPoint>();

    /// <summary>The period's bills whose time is known, which <see cref="Hours"/> adds up.</summary>
    public int TimedBills { get; init; }

    /// <summary>False when the times of bills cannot be read: the database login may not read the POS log.</summary>
    public bool TimesReadable { get; init; } = true;

    /// <summary>The two hours in a row that sell most (one hour when only one has bills); null when no bill's time
    /// is known.</summary>
    public HourWindow? BusiestHours { get; init; }

    public IReadOnlyList<ProductLine> TopProducts { get; init; } = Array.Empty<ProductLine>();
    public IReadOnlyList<ProductChange> Rising { get; init; } = Array.Empty<ProductChange>();
    public IReadOnlyList<ProductChange> Falling { get; init; } = Array.Empty<ProductChange>();
    public IReadOnlyList<CategoryLine> Categories { get; init; } = Array.Empty<CategoryLine>();

    /// <summary>Products in stock that did not sell at all in the period, most money tied up first.</summary>
    public IReadOnlyList<SlowMover> SlowMovers { get; init; } = Array.Empty<SlowMover>();
    public int SlowMoverCount { get; init; }
    public decimal MoneyInSlowStock { get; init; }

    /// <summary>Products that sell but are running out, best sellers first.</summary>
    public IReadOnlyList<ReorderItem> ReorderNow { get; init; } = Array.Empty<ReorderItem>();

    /// <summary>Negative stock: sold before the purchase was entered.</summary>
    public IReadOnlyList<StockProblem> NegativeStock { get; init; } = Array.Empty<StockProblem>();
    public int NegativeStockCount { get; init; }

    public IReadOnlyList<PaymentShare> Payments { get; init; } = Array.Empty<PaymentShare>();
    public CustomerSummary Customers { get; init; } = new();

    /// <summary>Named customers only. For the owner's screen; never sent to an AI.</summary>
    public IReadOnlyList<TopCustomer> TopCustomers { get; init; } = Array.Empty<TopCustomer>();
}

public sealed record SalesTotals
{
    /// <summary>Bill totals, GST included.</summary>
    public decimal Sales { get; init; }
    public decimal Returns { get; init; }
    public decimal NetSales => Sales - Returns;
    public decimal SalesBeforeTax { get; init; }
    public int Bills { get; init; }
    public int DaysWithSales { get; init; }
    public decimal Outstanding { get; init; }

    /// <summary>Different products on an average bill.</summary>
    public decimal ProductsPerBill { get; init; }
    public decimal AverageBill => Bills == 0 ? 0m : Sales / Bills;

    /// <summary>Sales before GST minus purchase cost, on lines whose purchase price is known.</summary>
    public decimal Profit { get; init; }
    public decimal CostedSalesBeforeTax { get; init; }

    /// <summary>Profit as a share of the sales it was worked out on; null when no cost is known.</summary>
    public decimal? ProfitMargin => CostedSalesBeforeTax > 0 ? Profit / CostedSalesBeforeTax : null;

    /// <summary>The share of sales (before GST) whose cost is known.</summary>
    public decimal ProfitCoverage => SalesBeforeTax > 0 ? Math.Min(1m, CostedSalesBeforeTax / SalesBeforeTax) : 0m;
}

public sealed record TrendPoint(DateOnly Day, decimal Sales, int Bills, decimal SevenDayAverage);

public sealed record MonthPoint(int Year, int Month, decimal Sales, int Bills, decimal Profit, bool Partial);

public sealed record WeekdayPoint(DayOfWeek Day, decimal AverageSales, decimal AverageBills, int DaysCounted);

/// <param name="Hour">0 to 23: 18 is from 6 to 7 PM.</param>
/// <param name="Share">Of the sales whose time is known.</param>
public sealed record HourPoint(int Hour, decimal Sales, int Bills, decimal Share);

/// <summary>From the start of hour <paramref name="From"/> to the start of hour <paramref name="To"/>, e.g. 18 to 20
/// for 6 to 8 PM.</summary>
/// <param name="Share">Of the sales whose time is known.</param>
public sealed record HourWindow(int From, int To, decimal Sales, int Bills, decimal Share);

public sealed record ProductLine
{
    public int ProductId { get; init; }
    public string Code { get; init; } = "";
    public string Name { get; init; } = "";
    public string Category { get; init; } = "";
    public decimal Qty { get; init; }
    public decimal Sales { get; init; }
    public decimal Share { get; init; }
    public int Bills { get; init; }
    public decimal Profit { get; init; }
    public decimal? ProfitMargin { get; init; }
    public decimal StockInHand { get; init; }

    /// <summary>Days the stock lasts at the period's pace; null when it did not sell.</summary>
    public decimal? DaysOfStock { get; init; }
    public decimal PreviousSales { get; init; }

    /// <summary>Change against the previous period, e.g. 0.25 for +25%; null when it did not sell then.</summary>
    public decimal? Change { get; init; }
}

public sealed record ProductChange(int ProductId, string Name, string Category, decimal Sales, decimal PreviousSales)
{
    public decimal Difference => Sales - PreviousSales;
    public decimal? Change => PreviousSales > 0 ? (Sales - PreviousSales) / PreviousSales : null;
}

public sealed record CategoryLine
{
    public string Name { get; init; } = "";
    public decimal Sales { get; init; }
    public decimal Share { get; init; }
    public decimal Profit { get; init; }
    public decimal? ProfitMargin { get; init; }
    public int ProductsSold { get; init; }
    public decimal PreviousSales { get; init; }
    public decimal? Change { get; init; }
}

public sealed record SlowMover
{
    public int ProductId { get; init; }
    public string Code { get; init; } = "";
    public string Name { get; init; } = "";
    public string Category { get; init; } = "";
    public decimal StockInHand { get; init; }

    /// <summary>Stock at purchase price, or at selling price when no purchase price is set.</summary>
    public decimal StockValue { get; init; }
}

public sealed record ReorderItem
{
    public int ProductId { get; init; }
    public string Code { get; init; } = "";
    public string Name { get; init; } = "";
    public decimal StockInHand { get; init; }
    public decimal MinStock { get; init; }
    public decimal QtyPerDay { get; init; }
    public decimal DaysOfStock { get; init; }
    public decimal Sales { get; init; }
}

public sealed record StockProblem(int ProductId, string Code, string Name, decimal StockInHand);

public sealed record PaymentShare(string Group, decimal Amount, int Payments, decimal Share);

public sealed record CustomerSummary
{
    /// <summary>Different named customers with a bill in the period (the walk-in customer left out).</summary>
    public int NamedCustomers { get; init; }

    /// <summary>Named customers with two or more bills in the period.</summary>
    public int RepeatCustomers { get; init; }

    /// <summary>Named customers whose first bill ever is in the period.</summary>
    public int NewCustomers { get; init; }
    public int WalkInBills { get; init; }
    public decimal WalkInShare { get; init; }
    public decimal NamedCustomerSales { get; init; }
}

public sealed record TopCustomer(string Name, int Bills, decimal Sales, DateOnly LastBill);
