namespace SmartRetail.Pos.Core.Analytics;

/// <summary>The days from <see cref="From"/> to <see cref="To"/>, both included.</summary>
public readonly record struct DateRange
{
    public DateRange(DateOnly from, DateOnly to)
    {
        if (to < from)
        {
            throw new ArgumentException($"The range ends ({to}) before it starts ({from}).", nameof(to));
        }

        From = from;
        To = to;
    }

    public DateOnly From { get; }
    public DateOnly To { get; }

    public int Days => To.DayNumber - From.DayNumber + 1;

    /// <summary>The same number of days just before this range, for comparison.</summary>
    public DateRange Previous => new(From.AddDays(-Days), From.AddDays(-1));

    public bool Contains(DateOnly day) => day >= From && day <= To;

    public IEnumerable<DateOnly> EachDay()
    {
        for (var day = From; day <= To; day = day.AddDays(1))
        {
            yield return day;
        }
    }

    /// <summary>The <paramref name="days"/> days ending on <paramref name="end"/>.</summary>
    public static DateRange Ending(DateOnly end, int days) => new(end.AddDays(-(Math.Max(1, days) - 1)), end);
}

/// <summary>The bills of one day (POS table <c>InvoiceInfo</c>) and its sales returns (<c>SalesReturn</c>).</summary>
public sealed record DaySales
{
    public DateOnly Day { get; init; }
    public int Bills { get; init; }

    /// <summary>Bill totals, GST included.</summary>
    public decimal Sales { get; init; }
    public decimal Returns { get; init; }

    /// <summary>Still owed on these bills.</summary>
    public decimal Outstanding { get; init; }
}

/// <summary>One product's bill lines on one day (<c>Invoice_Product</c>).</summary>
public sealed record ProductDaySales
{
    public DateOnly Day { get; init; }
    public int ProductId { get; init; }
    public decimal Qty { get; init; }

    /// <summary>Line totals, GST included.</summary>
    public decimal Sales { get; init; }
    public decimal SalesBeforeTax { get; init; }

    /// <summary>The part of <see cref="SalesBeforeTax"/> on lines that carry a purchase price, so profit is
    /// only worked out where the cost is known.</summary>
    public decimal CostedSalesBeforeTax { get; init; }

    /// <summary>Purchase cost of those lines.</summary>
    public decimal Cost { get; init; }

    /// <summary>Bills that had this product on this day.</summary>
    public int Bills { get; init; }
}

/// <summary>A product as it stands now (<c>Product</c> with its <c>Temp_Stock</c>).</summary>
public sealed record ProductFacts
{
    public int Id { get; init; }
    public string Code { get; init; } = "";
    public string Name { get; init; } = "";
    public string Category { get; init; } = "";
    public string SubCategory { get; init; } = "";
    public decimal StockInHand { get; init; }

    /// <summary>Reorder level; 0 when none is set.</summary>
    public decimal MinStock { get; init; }
    public decimal CostPrice { get; init; }
    public decimal SellingPrice { get; init; }

    /// <summary>CGST + SGST (the same total as IGST).</summary>
    public decimal GstRatePercent { get; init; }
    public bool Active { get; init; } = true;

    /// <summary>When the product was added to the POS, if known.</summary>
    public DateOnly? AddedOn { get; init; }
}

/// <summary>Payments on the period's bills in one payment mode (<c>Invoice_Payment</c>).</summary>
public sealed record PaymentTotal
{
    public string Mode { get; init; } = "";
    public int Payments { get; init; }
    public decimal Amount { get; init; }
}

/// <summary>One customer's bills in the period.</summary>
public sealed record CustomerFacts
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public int Bills { get; init; }
    public decimal Sales { get; init; }

    /// <summary>The customer's first bill ever, to tell new customers from returning ones.</summary>
    public DateOnly FirstBillEver { get; init; }
    public DateOnly LastBill { get; init; }
}

/// <summary>The bills made in one hour of one day: those the POS log says were saved on their own date.</summary>
public sealed record HourSales
{
    public DateOnly Day { get; init; }

    /// <summary>0 to 23: 18 is from 6 to 7 PM.</summary>
    public int Hour { get; init; }
    public int Bills { get; init; }

    /// <summary>Bill totals, GST included.</summary>
    public decimal Sales { get; init; }
}

/// <summary>A bill's date and total, with when the POS saved it (null when its log does not have it).</summary>
public sealed record BillTime(DateOnly Day, DateTime? SavedAt, decimal Total)
{
    /// <summary>The time of day it was made; null when not known or typed in on a later day.</summary>
    public TimeOnly? Time => Abstractions.BillTimes.TimeOf(Day, SavedAt);
}

/// <summary>Everything the analysis needs about one period's sales.</summary>
public sealed record SalesFacts
{
    public DateRange Range { get; init; }
    public IReadOnlyList<DaySales> Days { get; init; } = Array.Empty<DaySales>();

    /// <summary>Bills by the hour they were made; bills without a known time are left out.</summary>
    public IReadOnlyList<HourSales> Hours { get; init; } = Array.Empty<HourSales>();

    /// <summary>False when the times of bills cannot be read: the database login may not read the POS log.</summary>
    public bool TimesReadable { get; init; } = true;
    public IReadOnlyList<ProductDaySales> ProductDays { get; init; } = Array.Empty<ProductDaySales>();
    public IReadOnlyList<PaymentTotal> Payments { get; init; } = Array.Empty<PaymentTotal>();
    public IReadOnlyList<CustomerFacts> Customers { get; init; } = Array.Empty<CustomerFacts>();
}
