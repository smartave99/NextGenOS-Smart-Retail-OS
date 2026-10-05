using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;

namespace SmartRetail.Pos.Core.Checks;

public static class CheckFactsLoader
{
    /// <summary>Days of bills whose lines are checked: mistakes made at the till this week.</summary>
    public const int LineDays = 7;

    /// <summary>Days of bills checked for missing numbers.</summary>
    public const int BillDays = 30;

    /// <summary>Credit older than this many days counts as owed for long.</summary>
    public const int OwedDays = 30;

    /// <summary>Everything the checks look at, read from the POS now.</summary>
    /// <param name="pricesIncludeTax">False when the shop's prices in the POS are before GST (Shop:PricesIncludeTax):
    /// GST is added, since the checks compare what the customer pays.</param>
    public static async Task<CheckFacts> LoadCheckFactsAsync(this IShopChecksRepository checks, IInvoiceRepository invoices,
        DateOnly today, bool pricesIncludeTax, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(checks);
        ArgumentNullException.ThrowIfNull(invoices);

        var prices = await checks.GetPricesAsync(ct).ConfigureAwait(false);
        if (!pricesIncludeTax)
        {
            prices = prices.Select(p => p with { Price = Money.Round(p.Price * (1m + p.GstPercent / 100m)) }).ToList();
        }

        var lines = await checks.GetSoldLinesAsync(DateRange.Ending(today, LineDays), ct).ConfigureAwait(false);
        var bills = await checks.GetBillsAsync(DateRange.Ending(today, BillDays), ct).ConfigureAwait(false);
        var before = today.AddDays(-OwedDays);
        var owed = await invoices.SearchAsync(new BillQuery { OnlyOwed = true, To = before.AddDays(-1), Take = 1 }, ct).ConfigureAwait(false);

        return new CheckFacts
        {
            Today = today,
            Prices = prices,
            RecentLines = lines,
            RecentBills = bills,
            OwedLong = owed.Total > 0 ? new OwedBills(owed.Total, owed.TotalOwed, before, owed.First is { } oldest ? DateOnly.FromDateTime(oldest) : null) : null,
        };
    }
}
