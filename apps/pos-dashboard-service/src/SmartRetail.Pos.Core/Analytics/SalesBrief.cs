using System.Globalization;
using System.Text;

namespace SmartRetail.Pos.Core.Analytics;

/// <summary>A plain-text summary of a <see cref="SalesReport"/> for an AI to plan from. Figures and product
/// names only: never customer names, phone numbers or other personal details.</summary>
public static class SalesBrief
{
    public const int ProductLimit = 15;
    public const int ShortListLimit = 8;

    /// <param name="describe">What a product is, by POS product id, e.g. from its product photo; the POS's own
    /// names are often codes such as "PP-1193". Null or empty when unknown.</param>
    public static string Write(SalesReport report, Func<int, string?>? describe = null)
    {
        ArgumentNullException.ThrowIfNull(report);
        string Name(int productId, string name) => describe?.Invoke(productId) is { Length: > 0 } what
            ? $"{name} ({(what.Length <= 90 ? what.Trim() : what[..90].Trim() + "…")})"
            : name;
        var range = report.Range;
        var now = report.Current;
        var before = report.Previous;
        var text = new StringBuilder();

        text.AppendLine($"Period: {Day(range.From)} to {Day(range.To)} ({range.Days} days), compared with the {range.Days} days before "
            + $"({Day(report.PreviousRange.From)} to {Day(report.PreviousRange.To)}).");
        text.AppendLine("Amounts are in Indian Rupees with GST unless noted. The POS keeps only the date on a bill; the time comes from "
            + "its own log of when each bill was saved.");

        text.AppendLine().AppendLine("TOTALS");
        text.AppendLine($"- Sales: {Rupees(now.Sales)} (before: {Rupees(before.Sales)}{Versus(now.Sales, before.Sales)})");
        text.AppendLine($"- Bills: {now.Bills} (before: {before.Bills}{Versus(now.Bills, before.Bills)}), on {now.DaysWithSales} of {range.Days} days");
        text.AppendLine($"- Average bill: {Rupees(now.AverageBill)} (before: {Rupees(before.AverageBill)}{Versus(now.AverageBill, before.AverageBill)})");
        text.AppendLine($"- Different products per bill: {Number(now.ProductsPerBill)} (before: {Number(before.ProductsPerBill)})");
        if (now.ProfitMargin is { } margin)
        {
            text.AppendLine($"- Profit before GST: {Rupees(now.Profit)}, a margin of {Share(margin)}, worked out on the {Share(now.ProfitCoverage)} of sales "
                + "whose purchase price is recorded");
        }
        else
        {
            text.AppendLine("- Profit: unknown (no purchase prices recorded on these bills)");
        }

        if (now.Returns > 0)
        {
            text.AppendLine($"- Sales returns: {Rupees(now.Returns)}");
        }

        if (now.Outstanding > 0)
        {
            text.AppendLine($"- Still owed by customers on these bills: {Rupees(now.Outstanding)}");
        }

        WriteTrend(text, report);

        var weekdays = report.Weekdays.Where(w => w.DaysCounted > 0).ToList();
        if (weekdays.Count > 0 && now.Bills > 0)
        {
            text.AppendLine().AppendLine("AVERAGE SALES BY WEEKDAY");
            text.AppendLine("- " + string.Join(", ", weekdays.Select(w => $"{Short(w.Day)} {Rupees(w.AverageSales)}")));
            var best = weekdays.MaxBy(w => w.AverageSales)!;
            var worst = weekdays.MinBy(w => w.AverageSales)!;
            text.AppendLine($"- Best day: {best.Day}; weakest: {worst.Day}");
        }

        if (report.Hours.Count > 0 && report.BusiestHours is { } busiest)
        {
            var timed = now.Bills > 0 ? Math.Min(1m, report.TimedBills / (decimal)now.Bills) : 0m;
            text.AppendLine().AppendLine($"SALES BY HOUR OF DAY (share of sales; the time is known for {Share(timed)} of bills)");
            text.AppendLine("- " + string.Join(", ", report.Hours.Select(h => $"{HourNames.Of(h.Hour)} {Share(h.Share)}")));
            text.AppendLine($"- Busiest: {HourNames.Range(busiest.From, busiest.To)}, {Share(busiest.Share)} of sales");
        }

        if (report.Categories.Count > 0)
        {
            text.AppendLine().AppendLine("CATEGORIES (sales, share, profit margin, change)");
            foreach (var category in report.Categories.Take(ShortListLimit + 2))
            {
                text.AppendLine($"- {category.Name}: {Rupees(category.Sales)}, {Share(category.Share)}, margin {Share(category.ProfitMargin)}, {Change(category.Change)}");
            }
        }

        if (report.TopProducts.Count > 0)
        {
            text.AppendLine().AppendLine("TOP PRODUCTS (sales, quantity, profit margin, stock now, days of stock left, change)");
            foreach (var product in report.TopProducts.Take(ProductLimit))
            {
                var days = product.DaysOfStock is { } d ? Days(d) : "n/a";
                text.AppendLine($"- {Name(product.ProductId, product.Name)} [{product.Category}]: {Rupees(product.Sales)}, qty {Money.FormatQty(product.Qty)}, "
                    + $"margin {Share(product.ProfitMargin)}, stock {Money.FormatQty(product.StockInHand)}, {days}, {Change(product.Change)}");
            }
        }

        WriteChanges(text, "SELLING MORE THAN BEFORE", report.Rising, Name);
        WriteChanges(text, "SELLING LESS THAN BEFORE", report.Falling, Name);

        if (report.ReorderNow.Count > 0)
        {
            text.AppendLine().AppendLine("GOOD SELLERS RUNNING OUT (stock now, how fast it sells)");
            foreach (var item in report.ReorderNow.Take(ShortListLimit))
            {
                text.AppendLine($"- {Name(item.ProductId, item.Name)}: stock {Money.FormatQty(item.StockInHand)}, sells {Rate(item.QtyPerDay)}");
            }
        }

        if (report.SlowMoverCount > 0)
        {
            text.AppendLine().AppendLine($"NOT SELLING: {report.SlowMoverCount} products in stock had no sale in the period, "
                + $"{Rupees(report.MoneyInSlowStock)} of stock at purchase price. Largest:");
            foreach (var item in report.SlowMovers.Take(ShortListLimit))
            {
                text.AppendLine($"- {Name(item.ProductId, item.Name)} [{item.Category}]: {Money.FormatQty(item.StockInHand)} in stock, {Rupees(item.StockValue)}");
            }
        }

        if (report.NegativeStockCount > 0)
        {
            text.AppendLine().AppendLine($"STOCK RECORDS TO CORRECT: {report.NegativeStockCount} products show negative stock "
                + "(sold before their purchase was entered), so their stock figures cannot be trusted.");
        }

        if (report.Payments.Count > 0)
        {
            text.AppendLine().AppendLine("PAYMENTS");
            text.AppendLine("- " + string.Join(", ", report.Payments.Select(p => $"{p.Group} {Share(p.Share)}")));
        }

        var customers = report.Customers;
        text.AppendLine().AppendLine("CUSTOMERS");
        text.AppendLine($"- Bills to the walk-in (unnamed) customer: {Share(customers.WalkInShare)}");
        text.AppendLine($"- Named customers who bought: {customers.NamedCustomers}; of them bought twice or more: {customers.RepeatCustomers}; "
            + $"first-time customers: {customers.NewCustomers}");
        return text.ToString();
    }

    private static void WriteTrend(StringBuilder text, SalesReport report)
    {
        if (report.Range.Days > 62)
        {
            text.AppendLine().AppendLine("BY MONTH (sales, bills)");
            foreach (var month in report.Monthly)
            {
                var name = new DateOnly(month.Year, month.Month, 1).ToString("MMM yyyy", CultureInfo.InvariantCulture);
                text.AppendLine($"- {name}{(month.Partial ? " (part)" : "")}: {Rupees(month.Sales)}, {month.Bills} bills");
            }

            return;
        }

        if (report.Range.Days < 14)
        {
            return;
        }

        // Whole weeks counted back from the last day, so every line covers seven days.
        text.AppendLine().AppendLine("BY WEEK (sales, bills)");
        var weeks = new List<(DateOnly From, DateOnly To, decimal Sales, int Bills)>();
        for (var end = report.Range.To; end.AddDays(-6) >= report.Range.From; end = end.AddDays(-7))
        {
            var days = report.Daily.Where(d => d.Day <= end && d.Day > end.AddDays(-7)).ToList();
            weeks.Add((end.AddDays(-6), end, days.Sum(d => d.Sales), days.Sum(d => d.Bills)));
        }

        foreach (var week in Enumerable.Reverse(weeks))
        {
            text.AppendLine($"- {Day(week.From)} to {Day(week.To)}: {Rupees(week.Sales)}, {week.Bills} bills");
        }
    }

    private static void WriteChanges(StringBuilder text, string heading, IReadOnlyList<ProductChange> changes, Func<int, string, string> name)
    {
        if (changes.Count == 0)
        {
            return;
        }

        text.AppendLine().AppendLine(heading + " (sales now, before)");
        foreach (var change in changes)
        {
            text.AppendLine($"- {name(change.ProductId, change.Name)}: {Rupees(change.Sales)}, before {Rupees(change.PreviousSales)}");
        }
    }

    private static string Day(DateOnly day) => day.ToString("d MMM yyyy", CultureInfo.InvariantCulture);

    private static string Short(DayOfWeek day) => day.ToString()[..3];

    private static string Rupees(decimal amount) => Money.FormatCompact(Money.RoundToRupee(amount));

    private static string Number(decimal value) => value.ToString("0.#", CultureInfo.InvariantCulture);

    private static string Share(decimal? share) => share switch
    {
        null => "unknown",
        > 0m and < 0.01m => "<1%",
        { } s => (s * 100m).ToString("0", CultureInfo.InvariantCulture) + "%",
    };

    private static string Days(decimal days) => (days >= 10 ? days.ToString("0", CultureInfo.InvariantCulture) : Number(days)) + " days";

    /// <summary>"3 a day", "2 a week" or "1.5 a month", whichever reads naturally.</summary>
    private static string Rate(decimal perDay) => perDay switch
    {
        >= 1m => Number(perDay) + " a day",
        >= 1m / 7 => Number(perDay * 7) + " a week",
        _ => Number(perDay * 30) + " a month",
    };

    private static string Change(decimal? change) => change is { } c
        ? (c >= 0 ? "+" : "-") + Math.Abs(c * 100m).ToString("0", CultureInfo.InvariantCulture) + "%"
        : "new";

    private static string Versus(decimal now, decimal before) => before > 0 ? ", " + Change((now - before) / before) : "";
}
