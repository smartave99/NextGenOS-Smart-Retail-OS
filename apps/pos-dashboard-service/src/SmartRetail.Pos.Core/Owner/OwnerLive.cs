using System.Globalization;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Core.Checks;
using SmartRetail.Pos.Core.Models;

namespace SmartRetail.Pos.Core.Owner;

/// <summary>
/// What this PC sends for the owner's live view: today's figures, each of today's bills (number, time and amount),
/// the week, the best sellers, low stock and the Fix now list. Never a customer's name or phone number, nor what was
/// on a bill; a long number in a product's or the shop's name is masked.
/// </summary>
public sealed record OwnerLive
{
    /// <summary>Raised when the shape changes, so the website can tell an old shop PC from a new one.</summary>
    public const int CurrentVersion = 1;

    public const int MaxBills = 300;
    public const int MaxProducts = 10;
    public const int MaxLowStock = 10;
    public const int MaxFindings = 8;

    public int Version { get; init; } = CurrentVersion;
    public string Shop { get; init; } = "";

    /// <summary>The demo shop's figures, not a real shop's.</summary>
    public bool Demo { get; init; }

    public DateTimeOffset SentAt { get; init; }
    public OwnerToday Today { get; init; } = new();

    /// <summary>Today hour by hour, with the same day last week.</summary>
    public IReadOnlyList<OwnerHour> Hours { get; init; } = Array.Empty<OwnerHour>();

    /// <summary>Today's bills, newest first.</summary>
    public IReadOnlyList<OwnerBill> Bills { get; init; } = Array.Empty<OwnerBill>();

    /// <summary>The 7 days ending today.</summary>
    public IReadOnlyList<OwnerDaySales> Week { get; init; } = Array.Empty<OwnerDaySales>();

    /// <summary>Today's best sellers.</summary>
    public IReadOnlyList<OwnerProduct> Top { get; init; } = Array.Empty<OwnerProduct>();

    public IReadOnlyList<OwnerStock> LowStock { get; init; } = Array.Empty<OwnerStock>();
    public OwnerFixNow FixNow { get; init; } = new();

    public static OwnerLive From(OwnerLiveInputs inputs)
    {
        ArgumentNullException.ThrowIfNull(inputs);
        var figures = inputs.Figures;
        return new OwnerLive
        {
            Shop = PersonalData.MaskNumbers(inputs.ShopName.Trim()),
            Demo = inputs.Demo,
            SentAt = inputs.Now,
            Today = new OwnerToday
            {
                Day = figures.Day,
                Sales = figures.Sales,
                Bills = figures.Bills,
                Credit = inputs.CreditToday,
                LastBillAt = Clock(figures.LastBillAt),
                VsLastWeek = figures.ChangeVsLastWeek is { } change ? Math.Round(change, 4) : null,
                ComparedAt = Clock(figures.ComparedAt),
                LastWeekSales = figures.LastWeekByNow ?? figures.SameDayLastWeek,
            },
            Hours = figures.Hours.Select(h => new OwnerHour(h.Hour, h.Sales, h.Bills, h.LastWeekSales)).ToList(),
            Bills = inputs.TodaysBills
                .OrderByDescending(b => b.Date).ThenByDescending(b => b.Id)
                .Take(MaxBills)
                .Select(b => new OwnerBill(b.Number, Clock(b.Time), b.GrandTotal, Math.Max(0m, b.Balance), b.EnteredLater))
                .ToList(),
            Week = figures.Week.Select(d => new OwnerDaySales(d.Day, d.Sales, d.Bills)).ToList(),
            Top = TopProducts(inputs.TodaysProducts, inputs.ProductNames, MaxProducts),
            LowStock = inputs.LowStock.Take(MaxLowStock).Select(s => new OwnerStock(PersonalData.MaskNumbers(s.Name), s.InHand, s.MinStock)).ToList(),
            FixNow = FixNowList(inputs.FixNow),
        };
    }

    /// <summary>The products that sold most, by sales, with their names from the POS. A long number typed into a name,
    /// such as a phone number, is masked, as on the dashboard's summary screens.</summary>
    internal static List<OwnerProduct> TopProducts(IEnumerable<ProductDaySales> sold, IReadOnlyDictionary<int, string> names, int count) =>
        sold.GroupBy(p => p.ProductId)
            .Select(g => (Id: g.Key, Qty: g.Sum(p => p.Qty), Sales: g.Sum(p => p.Sales)))
            .Where(p => p.Sales > 0)
            .OrderByDescending(p => p.Sales).ThenBy(p => p.Id)
            .Take(count)
            .Select(p => new OwnerProduct(
                names.TryGetValue(p.Id, out var name) ? PersonalData.MaskNumbers(name) : "Product " + p.Id.ToString(CultureInfo.InvariantCulture), p.Qty, p.Sales))
            .ToList();

    /// <summary>How many things need fixing, and the first few. Only mistakes in products carry a name: the others
    /// (money owed, missing bills) can name a customer, so they say only what kind of mistake it is.</summary>
    private static OwnerFixNow FixNowList(IReadOnlyList<Finding> findings) => new()
    {
        Count = findings.Count(f => f.Level == FindingLevel.FixNow),
        Items = findings
            .OrderBy(f => f.Level == FindingLevel.FixNow ? 0 : 1)
            .Take(MaxFindings)
            .Select(f => new OwnerFinding(f.Kind.Heading(), NamesAProduct(f.Kind) ? PersonalData.MaskNumbers(f.Title) : null, f.Level == FindingLevel.FixNow))
            .ToList(),
    };

    private static bool NamesAProduct(FindingKind kind) => kind is FindingKind.BelowCost or FindingKind.AboveMrp or FindingKind.SoldAtLoss
        or FindingKind.SoldAboveMrp or FindingKind.SameCode or FindingKind.FarAboveCost or FindingKind.NoCost or FindingKind.NegativeStock;

    private static string? Clock(TimeOnly? time) => time?.ToString("HH:mm", CultureInfo.InvariantCulture);
}

/// <summary>What the live view is built from.</summary>
public sealed record OwnerLiveInputs
{
    public string ShopName { get; init; } = "";
    public bool Demo { get; init; }
    public DateTimeOffset Now { get; init; }
    public TodayFigures Figures { get; init; } = new();
    public decimal CreditToday { get; init; }
    public IReadOnlyList<InvoiceSummary> TodaysBills { get; init; } = Array.Empty<InvoiceSummary>();
    public IReadOnlyList<ProductDaySales> TodaysProducts { get; init; } = Array.Empty<ProductDaySales>();
    public IReadOnlyDictionary<int, string> ProductNames { get; init; } = new Dictionary<int, string>();
    public IReadOnlyList<StockLevel> LowStock { get; init; } = Array.Empty<StockLevel>();
    public IReadOnlyList<Finding> FixNow { get; init; } = Array.Empty<Finding>();
}

public sealed record OwnerToday
{
    public DateOnly Day { get; init; }
    public decimal Sales { get; init; }
    public int Bills { get; init; }

    /// <summary>Still owed on today's bills.</summary>
    public decimal Credit { get; init; }

    /// <summary>"18:57"; null when no bill today has a time.</summary>
    public string? LastBillAt { get; init; }

    /// <summary>Today against the same day last week (0.12 for 12% more); null when there is nothing to compare.</summary>
    public decimal? VsLastWeek { get; init; }

    /// <summary>"18:58" when compared with last week by this time of day; null when compared with its whole day.</summary>
    public string? ComparedAt { get; init; }

    public decimal LastWeekSales { get; init; }
}

/// <param name="Hour">0 to 23: 18 is from 6 to 7 PM.</param>
public sealed record OwnerHour(int Hour, decimal Sales, int Bills, decimal LastWeekSales);

/// <param name="Time">"18:57"; null when not known.</param>
/// <param name="Later">Typed into the POS on a later day than its date.</param>
public sealed record OwnerBill(string Number, string? Time, decimal Total, decimal Due, bool Later);

public sealed record OwnerDaySales(DateOnly Day, decimal Sales, int Bills);

public sealed record OwnerProduct(string Name, decimal Qty, decimal Sales);

public sealed record OwnerStock(string Name, decimal Left, decimal ReorderAt);

public sealed record OwnerFixNow
{
    /// <summary>Things to fix now; the list also has things to check soon.</summary>
    public int Count { get; init; }
    public IReadOnlyList<OwnerFinding> Items { get; init; } = Array.Empty<OwnerFinding>();
}

/// <param name="Title">The product's name, for mistakes in products; null for the others.</param>
public sealed record OwnerFinding(string Kind, string? Title, bool Now);

/// <summary>One day for the owner's history: its totals, hours and best sellers.</summary>
public sealed record OwnerDay
{
    public const int MaxProducts = 5;

    public DateOnly Day { get; init; }
    public decimal Sales { get; init; }
    public int Bills { get; init; }
    public decimal Returns { get; init; }
    public IReadOnlyList<OwnerHourTotal> Hours { get; init; } = Array.Empty<OwnerHourTotal>();
    public IReadOnlyList<OwnerProduct> Top { get; init; } = Array.Empty<OwnerProduct>();

    /// <summary>Every day of <paramref name="facts"/> from the first that had bills or returns to the end of its range,
    /// the days without any as none: so a day whose bills were all deleted is sent again, as none.</summary>
    public static IReadOnlyList<OwnerDay> From(SalesFacts facts, IReadOnlyDictionary<int, string> names)
    {
        ArgumentNullException.ThrowIfNull(facts);
        ArgumentNullException.ThrowIfNull(names);
        var sold = facts.Days
            .Where(d => facts.Range.Contains(d.Day) && (d.Bills > 0 || d.Returns > 0))
            .ToLookup(d => d.Day);
        if (sold.Count == 0)
        {
            return Array.Empty<OwnerDay>();
        }

        var hours = facts.Hours.ToLookup(h => h.Day);
        var products = facts.ProductDays.ToLookup(p => p.Day);
        var days = new List<OwnerDay>();
        for (var day = sold.Min(g => g.Key); day <= facts.Range.To; day = day.AddDays(1))
        {
            days.Add(new OwnerDay
            {
                Day = day,
                Sales = sold[day].Sum(d => d.Sales),
                Bills = sold[day].Sum(d => d.Bills),
                Returns = sold[day].Sum(d => d.Returns),
                Hours = hours[day].OrderBy(h => h.Hour).Select(h => new OwnerHourTotal(h.Hour, h.Sales, h.Bills)).ToList(),
                Top = OwnerLive.TopProducts(products[day], names, MaxProducts),
            });
        }

        return days;
    }
}

public sealed record OwnerHourTotal(int Hour, decimal Sales, int Bills);
