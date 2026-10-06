using System.Globalization;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Shop;
using NextGenOS.Tax;
using NewtonJson = Newtonsoft.Json.JsonConvert;

namespace NextGenOS.Hub.Reports;

public sealed record SalesDay(DateOnly Day, int Documents, long NetMinor, long TaxMinor, long TotalMinor, long RefundsMinor, long TipsMinor);

public sealed record SalesSummary(int Documents, long NetMinor, long TaxMinor, long TotalMinor, long RefundsMinor, long TipsMinor, long AverageMinor);

public sealed record TopItem(string Name, long QtyMilli, long RevenueMinor);

public sealed record TaxSummaryRow(string Code, string Percent, long TaxableMinor, IReadOnlyList<(string Name, long AmountMinor)> Components, long CessMinor)
{
    public long TaxMinor => Components.Sum(c => c.AmountMinor) + CessMinor;
}

public sealed record PaymentTotal(string Method, long AmountMinor);

public sealed record AgeingRow(long PartyId, string Name, long CurrentMinor, long Days30Minor, long Days60Minor, long Days90Minor, long Over90Minor)
{
    public long TotalMinor => CurrentMinor + Days30Minor + Days60Minor + Days90Minor + Over90Minor;
}

public sealed record TopCustomer(long PartyId, string Name, int Documents, long TotalMinor);

public sealed record StockValue(long ItemId, string Name, long OnHandMilli, long CostMinor, long ValueMinor);

/// <summary>The numbers an owner looks at: sales by day, top items, tax by rate, what was paid how, who owes what, stock worth.</summary>
public sealed class ReportService(HubDb db, ShopContextProvider shop, IClock clock, CatalogService catalog)
{
    private const string SalesTypes = "'invoice','progress-bill'";

    private IReadOnlyList<(Document Doc, TaxResult? Result)> Issued(DateTimeOffset from, DateTimeOffset to, string types) => db.Query(
        "SELECT id, type, status, issued_at, party_id, subtotal_minor, tax_minor, total_minor, payable_minor, paid_minor, tips_minor, result FROM documents " +
        $"WHERE status = 'issued' AND direction = 'out' AND type IN ({types}) AND issued_at >= $f AND issued_at < $t ORDER BY issued_at",
        r => (new Document(r.Int("id"), r.Text("type"), null, r.Text("status"), "out", r.IntOrNull("party_id"), r.Time("issued_at"), r.Time("issued_at"), null, 0, false, null, null, false, true,
            r.Int("subtotal_minor"), r.Int("tax_minor"), r.Int("total_minor"), r.Int("payable_minor"), r.Int("paid_minor"), r.Int("tips_minor"), 0, 0, null, null, null, null, null, new Dictionary<string, string>()),
            r.TextOrNull("result") is { } json ? NewtonJson.DeserializeObject<TaxResult>(json) : null),
        ("$f", Iso.Text(from)), ("$t", Iso.Text(to)));

    /// <summary>Sales (invoices and progress bills) less credit notes, a row for each local day that had any.</summary>
    public IReadOnlyList<SalesDay> DailySales(DateOnly from, DateOnly to)
    {
        var time = shop.Current.Time;
        var start = time.StartOfDay(from);
        var end = time.StartOfNextDay(to);
        var rows = Issued(start, end, SalesTypes + ",'credit-note'");
        return rows.GroupBy(x => time.LocalDate(x.Doc.IssuedAt!.Value)).OrderBy(g => g.Key).Select(g =>
        {
            var sales = g.Where(x => x.Doc.Type != DocTypes.CreditNote).ToList();
            var credits = g.Where(x => x.Doc.Type == DocTypes.CreditNote).ToList();
            return new SalesDay(g.Key, sales.Count, sales.Sum(x => x.Doc.SubtotalMinor) - credits.Sum(x => x.Doc.SubtotalMinor), sales.Sum(x => x.Doc.TaxMinor) - credits.Sum(x => x.Doc.TaxMinor),
                sales.Sum(x => x.Doc.TotalMinor) - credits.Sum(x => x.Doc.TotalMinor), credits.Sum(x => x.Doc.TotalMinor), sales.Sum(x => x.Doc.TipsMinor));
        }).ToList();
    }

    public SalesSummary Summary(DateOnly from, DateOnly to)
    {
        var days = DailySales(from, to);
        var documents = days.Sum(d => d.Documents);
        var total = days.Sum(d => d.TotalMinor);
        return new SalesSummary(documents, days.Sum(d => d.NetMinor), days.Sum(d => d.TaxMinor), total, days.Sum(d => d.RefundsMinor), days.Sum(d => d.TipsMinor), documents == 0 ? 0 : total / documents);
    }

    /// <summary>Best sellers by what they earned (each line's total as the tax engine worked it out), credit notes taken off.</summary>
    public IReadOnlyList<TopItem> TopItems(DateOnly from, DateOnly to, int limit = 20)
    {
        var time = shop.Current.Time;
        return db.Query(
            "SELECT l.description AS name, SUM(CASE d.type WHEN 'credit-note' THEN -l.qty_milli ELSE l.qty_milli END) AS qty, " +
            "SUM(CASE d.type WHEN 'credit-note' THEN -1 ELSE 1 END * CAST(REPLACE(json_extract(j.value, '$.lineTotal'), '.', '') AS INTEGER)) AS revenue " +
            "FROM documents d JOIN document_lines l ON l.document_id = d.id JOIN json_each(d.result, '$.lines') j ON j.key = l.line_no - 1 " +
            "WHERE d.status = 'issued' AND d.direction = 'out' AND d.type IN ('invoice','credit-note') AND d.issued_at >= $f AND d.issued_at < $t " +
            "GROUP BY COALESCE(l.item_id, l.description), l.description HAVING qty > 0 ORDER BY revenue DESC, name LIMIT $n",
            r => new TopItem(r.Text("name"), r.Int("qty"), r.Int("revenue")), ("$f", Iso.Text(time.StartOfDay(from))), ("$t", Iso.Text(time.StartOfNextDay(to))), ("$n", limit));
    }

    private sealed class TaxBucket(string percent)
    {
        public string Percent { get; } = percent;
        public long Taxable;
        public long Cess;
        public Dictionary<string, long> Parts { get; } = new();
    }

    /// <summary>Tax collected, by rate and part (CGST, SGST, VAT ...): the figures a tax return is made from.</summary>
    public IReadOnlyList<TaxSummaryRow> TaxSummary(DateOnly from, DateOnly to)
    {
        var time = shop.Current.Time;
        var decimals = shop.Current.Decimals;
        long Minor(string text) => (long)MoneyText.Parse(text, decimals);
        var buckets = new Dictionary<string, TaxBucket>();
        foreach (var (doc, result) in Issued(time.StartOfDay(from), time.StartOfNextDay(to), SalesTypes + ",'credit-note'"))
        {
            if (result is null) continue;
            var sign = doc.Type == DocTypes.CreditNote ? -1 : 1;
            foreach (var b in result.ByCode)
            {
                if (!buckets.TryGetValue(b.Code, out var entry)) buckets[b.Code] = entry = new TaxBucket(b.Percent);
                entry.Taxable += sign * Minor(b.Taxable);
                entry.Cess += sign * Minor(b.Cess);
                foreach (var c in b.Components) entry.Parts[c.Name] = entry.Parts.GetValueOrDefault(c.Name) + sign * Minor(c.Amount);
            }
        }
        return buckets.OrderBy(b => b.Key, StringComparer.Ordinal).Select(b => new TaxSummaryRow(b.Key, b.Value.Percent, b.Value.Taxable, b.Value.Parts.Select(p => (p.Key, p.Value)).ToList(), b.Value.Cess)).ToList();
    }

    /// <summary>What came in by each way of paying (cash, card ...), refunds taken off.</summary>
    public IReadOnlyList<PaymentTotal> Payments(DateOnly from, DateOnly to)
    {
        var time = shop.Current.Time;
        return db.Query(
            "SELECT p.method, SUM(p.amount_minor) AS total FROM payments p LEFT JOIN documents d ON d.id = p.document_id WHERE (d.direction = 'out' OR p.document_id IS NULL) AND p.at >= $f AND p.at < $t GROUP BY p.method ORDER BY total DESC",
            r => new PaymentTotal(r.Text("method"), r.Int("total")), ("$f", Iso.Text(time.StartOfDay(from))), ("$t", Iso.Text(time.StartOfNextDay(to))));
    }

    /// <summary>Who owes what, by how long it has been due.</summary>
    public IReadOnlyList<AgeingRow> Outstanding()
    {
        var time = shop.Current.Time;
        var today = time.LocalDate(clock.UtcNow);
        var rows = db.Query(
            "SELECT d.party_id, p.name, d.payable_minor - d.paid_minor AS owed, COALESCE(d.due_at, d.issued_at) AS due FROM documents d JOIN parties p ON p.id = d.party_id " +
            "WHERE d.status = 'issued' AND d.direction = 'out' AND d.type IN ('invoice','progress-bill') AND d.paid_minor < d.payable_minor",
            r => (Party: r.Int("party_id"), Name: r.Text("name"), Owed: r.Int("owed"), Due: r.Time("due")));
        return rows.GroupBy(x => (x.Party, x.Name)).Select(g =>
        {
            long current = 0, d30 = 0, d60 = 0, d90 = 0, over = 0;
            foreach (var x in g)
            {
                var days = today.DayNumber - time.LocalDate(x.Due).DayNumber;
                if (days <= 0) current += x.Owed; else if (days <= 30) d30 += x.Owed; else if (days <= 60) d60 += x.Owed; else if (days <= 90) d90 += x.Owed; else over += x.Owed;
            }
            return new AgeingRow(g.Key.Party, g.Key.Name, current, d30, d60, d90, over);
        }).OrderByDescending(a => a.TotalMinor).ToList();
    }

    public IReadOnlyList<TopCustomer> TopCustomers(DateOnly from, DateOnly to, int limit = 20)
    {
        var time = shop.Current.Time;
        return db.Query(
            "SELECT d.party_id, p.name, COUNT(*) AS n, SUM(CASE d.type WHEN 'credit-note' THEN -d.total_minor ELSE d.total_minor END) AS total FROM documents d JOIN parties p ON p.id = d.party_id " +
            "WHERE d.status = 'issued' AND d.direction = 'out' AND d.type IN ('invoice','progress-bill','credit-note') AND d.issued_at >= $f AND d.issued_at < $t GROUP BY d.party_id ORDER BY total DESC LIMIT $n",
            r => new TopCustomer(r.Int("party_id"), r.Text("name"), (int)r.Int("n"), r.Int("total")), ("$f", Iso.Text(time.StartOfDay(from))), ("$t", Iso.Text(time.StartOfNextDay(to))), ("$n", limit));
    }

    /// <summary>What the stock on the shelves is worth at cost.</summary>
    public IReadOnlyList<StockValue> StockValues() =>
        catalog.StockList().Where(s => s.OnHandMilli > 0).Select(s => new StockValue(s.ItemId, s.Name, s.OnHandMilli, s.CostMinor, (2 * s.OnHandMilli * s.CostMinor + 1000) / 2000)).ToList();

    /// <summary>Purchases received in the period and what is still unpaid to suppliers.</summary>
    public (long ReceivedMinor, long UnpaidMinor) Purchases(DateOnly from, DateOnly to)
    {
        var time = shop.Current.Time;
        var received = Convert.ToInt64(db.Scalar("SELECT COALESCE(SUM(total_minor), 0) FROM documents WHERE type = 'purchase' AND status = 'issued' AND issued_at >= $f AND issued_at < $t",
            ("$f", Iso.Text(time.StartOfDay(from))), ("$t", Iso.Text(time.StartOfNextDay(to)))) ?? 0L);
        var unpaid = Convert.ToInt64(db.Scalar("SELECT COALESCE(SUM(payable_minor - paid_minor), 0) FROM documents WHERE type = 'purchase' AND status = 'issued' AND paid_minor < payable_minor") ?? 0L);
        return (received, unpaid);
    }
}

/// <summary>Reports as a file for a spreadsheet. Text that a spreadsheet would run as a formula is saved as plain text.</summary>
public static class Csv
{
    public static string Build(IReadOnlyList<string> headers, IEnumerable<IReadOnlyList<object?>> rows)
    {
        var sb = new System.Text.StringBuilder();
        sb.Append(string.Join(',', headers.Select(Cell))).Append("\r\n");
        foreach (var row in rows) sb.Append(string.Join(',', row.Select(Cell))).Append("\r\n");
        return sb.ToString();
    }

    private static string Cell(object? value)
    {
        var text = value switch { null => "", IFormattable f => f.ToString(null, CultureInfo.InvariantCulture), _ => value.ToString() ?? "" };
        if (value is string && text.Length > 0 && "=+-@\t\r".Contains(text[0])) text = "'" + text;
        return text.Contains('"') || text.Contains(',') || text.Contains('\n') || text.Contains('\r') ? "\"" + text.Replace("\"", "\"\"") + "\"" : text;
    }
}
