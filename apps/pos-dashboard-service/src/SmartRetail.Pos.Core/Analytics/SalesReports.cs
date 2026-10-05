using SmartRetail.Pos.Core.Abstractions;

namespace SmartRetail.Pos.Core.Analytics;

public static class SalesReports
{
    /// <summary>Loads a period, the period before it and the products, and analyses them.</summary>
    public static async Task<SalesReport> LoadReportAsync(this ISalesFactsRepository facts, DateRange range, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(facts);
        var current = await facts.GetFactsAsync(range, ct).ConfigureAwait(false);
        var previous = await facts.GetFactsAsync(range.Previous, ct).ConfigureAwait(false);
        var products = await facts.GetProductsAsync(ct).ConfigureAwait(false);
        return SalesAnalysis.Analyse(current, previous, products);
    }
}
