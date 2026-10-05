using System.Runtime.CompilerServices;
using SmartRetail.Pos.Core.Abstractions;

namespace SmartRetail.Pos.Core.Bills;

public static class BillExport
{
    /// <summary>Every bill a search finds, newest first, read a few thousand at a time. Bills made while it reads
    /// are left out, so none is skipped or repeated.</summary>
    public static async IAsyncEnumerable<InvoiceSummary> AllAsync(this IInvoiceRepository invoices, BillQuery query,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(invoices);
        ArgumentNullException.ThrowIfNull(query);

        var newest = await invoices.SearchAsync(query with { Skip = 0, Take = 1 }, ct).ConfigureAwait(false);
        if (newest.NewestId is not { } upTo)
        {
            yield break;
        }

        var steady = query with { UpToId = query.UpToId is { } limit ? Math.Min(limit, upTo) : upTo, Take = BillQuery.MaxTake };
        for (var skip = 0; ; skip += BillQuery.MaxTake)
        {
            var page = await invoices.SearchAsync(steady with { Skip = skip }, ct).ConfigureAwait(false);
            foreach (var bill in page.Items)
            {
                yield return bill;
            }

            if (page.Items.Count < BillQuery.MaxTake)
            {
                yield break;
            }
        }
    }
}
