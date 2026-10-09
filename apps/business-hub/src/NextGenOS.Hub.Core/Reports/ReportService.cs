using System.Globalization;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Security;
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

/// <summary>One item's stock over a period (or over one day of it): what the shelf held before, what came in, what went out, and what was left.</summary>
public sealed record StockMovementRow(DateOnly? Day, long ItemId, string Name, string Unit, long OpeningMilli, long InMilli, long OutMilli)
{
    public long ClosingMilli => OpeningMilli + InMilli - OutMilli;
}

/// <summary>One move of one item's stock. The value is negative for stock that left, and empty for a move made before values were kept.</summary>
public sealed record StockCardRow(DateTimeOffset At, string Reason, long QtyMilli, long? ValueMinor, string? Note, string? Document);

/// <summary>One bill (or one return) of the sales list, with how it was paid, what the goods cost and what is left. A return is a row of its own with the figures below nothing.</summary>
public sealed record BillRow(long Id, string Number, DateTimeOffset At, bool IsReturn, string? Customer, string? Cashier, long TaxableMinor, long TotalMinor, long PaidMinor, IReadOnlyDictionary<string, long> ByMethod, long CostMinor)
{
    /// <summary>What the bill earned over what its goods cost (before tax). Goods that keep no stock have no cost, so their whole price counts.</summary>
    public long ProfitMinor => TaxableMinor - CostMinor;
    public long DueMinor => IsReturn ? 0 : Math.Max(0, TotalMinor - PaidMinor);
}

/// <summary>An item's sales in the period with what they cost: the profit is the sales before tax less the cost of the goods (returns taken off both).</summary>
public sealed record ProfitRow(long? ItemId, string Name, long QtyMilli, long TaxableMinor, long CostMinor)
{
    public long ProfitMinor => TaxableMinor - CostMinor;
}

/// <summary>A purchase received (or goods sent back, with the figures below nothing) in the purchase list.</summary>
public sealed record PurchaseRow(long Id, string Number, DateTimeOffset At, bool IsReturn, string? Supplier, long TaxableMinor, long TaxMinor, long TotalMinor, long PaidMinor)
{
    public long DueMinor => IsReturn ? 0 : Math.Max(0, TotalMinor - PaidMinor);
}

/// <summary>One line of an item's sales history: the price before discount and tax, the discount, the tax and what the line came to.</summary>
public sealed record ProductSale(long DocumentId, string Number, DateTimeOffset At, bool IsReturn, string? Customer, long QtyMilli, long UnitMinor, long DiscountMinor, long TaxMinor, long TotalMinor);

/// <summary>A tracked item with nothing (or less than nothing) on the shelf.</summary>
public sealed record OutOfStockRow(long ItemId, string Name, string Unit, long OnHandMilli);

/// <summary>The numbers an owner looks at: sales by day, top items, tax by rate, what was paid how, who owes what, stock worth.</summary>
public sealed class ReportService(HubDb db, ShopContextProvider shop, IClock clock, CatalogService catalog, Access access)
{
    /// <summary>Who may see the shop's figures (blueprint SEC-004, reads): the people who may see the reports. The Hub itself asks, not only the screen or the file download.</summary>
    private void Allowed() => access.Require(Perm.Reports);

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
        Allowed();
        return Days(from, to);
    }

    private IReadOnlyList<SalesDay> Days(DateOnly from, DateOnly to)
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
        access.RequireAny(Perm.Reports, Perm.Sell);   // the day's totals are on the first screen of the people who sell as well
        var days = Days(from, to);
        var documents = days.Sum(d => d.Documents);
        var total = days.Sum(d => d.TotalMinor);
        return new SalesSummary(documents, days.Sum(d => d.NetMinor), days.Sum(d => d.TaxMinor), total, days.Sum(d => d.RefundsMinor), days.Sum(d => d.TipsMinor), documents == 0 ? 0 : total / documents);
    }

    /// <summary>Best sellers by what they earned (each line's total as the tax engine worked it out), credit notes taken off.</summary>
    public IReadOnlyList<TopItem> TopItems(DateOnly from, DateOnly to, int limit = 20, bool byQuantity = false, bool lowest = false)
    {
        Allowed();
        var time = shop.Current.Time;
        var order = byQuantity ? (lowest ? "qty ASC, name" : "qty DESC, name") : "revenue DESC, name";   // by quantity, the best sellers sell the most and the low sellers the least (only items that sold at all)
        return db.Query(
            "SELECT l.description AS name, SUM(CASE d.type WHEN 'credit-note' THEN -l.qty_milli ELSE l.qty_milli END) AS qty, " +
            "SUM(CASE d.type WHEN 'credit-note' THEN -1 ELSE 1 END * CAST(REPLACE(json_extract(j.value, '$.lineTotal'), '.', '') AS INTEGER)) AS revenue " +
            "FROM documents d JOIN document_lines l ON l.document_id = d.id JOIN json_each(d.result, '$.lines') j ON j.key = l.line_no - 1 " +
            "WHERE d.status = 'issued' AND d.direction = 'out' AND d.type IN ('invoice','credit-note') AND d.issued_at >= $f AND d.issued_at < $t " +
            $"GROUP BY COALESCE(l.item_id, l.description), l.description HAVING qty > 0 ORDER BY {order} LIMIT $n",
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
        Allowed();
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
        Allowed();
        var time = shop.Current.Time;
        return db.Query(
            "SELECT p.method, SUM(p.amount_minor) AS total FROM payments p LEFT JOIN documents d ON d.id = p.document_id WHERE (d.direction = 'out' OR p.document_id IS NULL) AND p.at >= $f AND p.at < $t GROUP BY p.method ORDER BY total DESC",
            r => new PaymentTotal(r.Text("method"), r.Int("total")), ("$f", Iso.Text(time.StartOfDay(from))), ("$t", Iso.Text(time.StartOfNextDay(to))));
    }

    /// <summary>Who owes what, by how long it has been due.</summary>
    public IReadOnlyList<AgeingRow> Outstanding()
    {
        Allowed();
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
        Allowed();
        var time = shop.Current.Time;
        return db.Query(
            "SELECT d.party_id, p.name, COUNT(*) AS n, SUM(CASE d.type WHEN 'credit-note' THEN -d.total_minor ELSE d.total_minor END) AS total FROM documents d JOIN parties p ON p.id = d.party_id " +
            "WHERE d.status = 'issued' AND d.direction = 'out' AND d.type IN ('invoice','progress-bill','credit-note') AND d.issued_at >= $f AND d.issued_at < $t GROUP BY d.party_id ORDER BY total DESC LIMIT $n",
            r => new TopCustomer(r.Int("party_id"), r.Text("name"), (int)r.Int("n"), r.Int("total")), ("$f", Iso.Text(time.StartOfDay(from))), ("$t", Iso.Text(time.StartOfNextDay(to))), ("$n", limit));
    }

    /// <summary>What the stock on the shelves is worth at cost: the value its moves have (decision 36, average cost), the same figure as "Stock on the shelves" in the books. Stock whose value is not known (moved before values were kept, with no cost price) shows nothing.</summary>
    public IReadOnlyList<StockValue> StockValues()
    {
        access.RequireAny(Perm.Reports, Perm.Stock);
        return catalog.StockList().Where(s => s.OnHandMilli > 0).Select(s => new StockValue(s.ItemId, s.Name, s.OnHandMilli, s.CostMinor, s.ValueMinor)).ToList();
    }

    /// <summary>
    /// Stock in, stock out and what was left, for each item that had any of it in the period (the older POS's stock movement report, study 01 section 6.7). <paramref name="byDay"/> gives a row for each day an
    /// item moved instead of one for the whole period. <b>Opening</b> is what the shelf held before the first day (before that day, when by day); <b>in</b> is every move that added stock (a delivery, a
    /// purchase, goods back from a customer, a count that found more); <b>out</b> is every move that took stock off (a sale, goods sent back to a supplier, damage, a count that found less);
    /// <b>closing</b> is opening + in − out, and for a period that ends today it is what the item holds now. Every kind of move is in one place (the older program left some out, so its report did not agree with its stock).
    /// </summary>
    public IReadOnlyList<StockMovementRow> StockMovement(DateOnly from, DateOnly to, long? itemId = null, bool byDay = false)
    {
        access.RequireAny(Perm.Reports, Perm.Stock);
        var time = shop.Current.Time;
        var start = Iso.Text(time.StartOfDay(from));
        var end = Iso.Text(time.StartOfNextDay(to));
        var opening = db.Query(
            "SELECT m.item_id, i.name, i.unit, SUM(m.qty_milli) AS qty FROM stock_moves m JOIN items i ON i.id = m.item_id WHERE m.at < $s AND ($i IS NULL OR m.item_id = $i) GROUP BY m.item_id",
            r => (Item: r.Int("item_id"), Name: r.Text("name"), Unit: r.Text("unit"), Qty: r.Int("qty")), ("$s", start), ("$i", itemId));
        var moves = db.Query(
            "SELECT m.item_id, i.name, i.unit, m.qty_milli, m.at FROM stock_moves m JOIN items i ON i.id = m.item_id WHERE m.at >= $s AND m.at < $e AND m.qty_milli <> 0 AND ($i IS NULL OR m.item_id = $i) ORDER BY m.at, m.id",
            r => (Item: r.Int("item_id"), Name: r.Text("name"), Unit: r.Text("unit"), Qty: r.Int("qty_milli"), At: r.Time("at")), ("$s", start), ("$e", end), ("$i", itemId));

        var names = new Dictionary<long, (string Name, string Unit)>();
        var before = new Dictionary<long, long>();
        foreach (var o in opening) { names[o.Item] = (o.Name, o.Unit); before[o.Item] = o.Qty; }
        foreach (var m in moves) names[m.Item] = (m.Name, m.Unit);

        var rows = new List<StockMovementRow>();
        if (!byDay)
        {
            foreach (var group in moves.GroupBy(m => m.Item))
                rows.Add(new StockMovementRow(null, group.Key, names[group.Key].Name, names[group.Key].Unit, before.GetValueOrDefault(group.Key), group.Where(m => m.Qty > 0).Sum(m => m.Qty), group.Where(m => m.Qty < 0).Sum(m => -m.Qty)));
            foreach (var item in before.Keys.Where(k => before[k] != 0 && rows.All(r => r.ItemId != k)))
                rows.Add(new StockMovementRow(null, item, names[item].Name, names[item].Unit, before[item], 0, 0));   // held stock that did not move still shows, so the closing figure is the whole shelf
            return rows.OrderBy(r => r.Name, StringComparer.CurrentCultureIgnoreCase).ThenBy(r => r.ItemId).ToList();
        }

        var running = new Dictionary<long, long>(before);
        foreach (var day in moves.GroupBy(m => time.LocalDate(m.At)).OrderBy(g => g.Key))
        {
            foreach (var item in day.GroupBy(m => m.Item).OrderBy(g => names[g.Key].Name, StringComparer.CurrentCultureIgnoreCase).ThenBy(g => g.Key))
            {
                var open = running.GetValueOrDefault(item.Key);
                var added = item.Where(m => m.Qty > 0).Sum(m => m.Qty);
                var taken = item.Where(m => m.Qty < 0).Sum(m => -m.Qty);
                rows.Add(new StockMovementRow(day.Key, item.Key, names[item.Key].Name, names[item.Key].Unit, open, added, taken));
                running[item.Key] = open + added - taken;
            }
        }
        return rows;
    }

    /// <summary>One item's moves in the period, one by one, newest last: what moved, why, what it was worth (known from the day values were kept) and the bill it came with, if any.</summary>
    public IReadOnlyList<StockCardRow> StockCard(long itemId, DateOnly from, DateOnly to)
    {
        access.RequireAny(Perm.Reports, Perm.Stock);
        var time = shop.Current.Time;
        return db.Query(
            "SELECT m.at, m.reason, m.qty_milli, m.value_minor, m.note, d.number FROM stock_moves m LEFT JOIN documents d ON d.id = m.document_id " +
            "WHERE m.item_id = $i AND m.at >= $s AND m.at < $e AND m.qty_milli <> 0 ORDER BY m.at, m.id",
            r => new StockCardRow(r.Time("at"), r.Text("reason"), r.Int("qty_milli"), r.IntOrNull("value_minor"), r.TextOrNull("note"), r.TextOrNull("number")),
            ("$i", itemId), ("$s", Iso.Text(time.StartOfDay(from))), ("$e", Iso.Text(time.StartOfNextDay(to))));
    }

    private const string BillWhere = "d.status = 'issued' AND d.direction = 'out' AND d.type IN ('invoice','credit-note') AND d.issued_at >= $f AND d.issued_at < $t AND ($u IS NULL OR d.user_id = $u)";

    /// <summary>
    /// The bills and returns of the period, one row each, with the way each was paid (cash, card ... a column for each way used), what is still owed, what the goods cost and what the bill earned over that
    /// (the older POS's sales report with its multi-payment and profit-by-bill versions, study 02 C2 and C4). The cost is what the stock moves of the bill were worth (decision 36, average cost); a
    /// return gives its goods' cost back, so a return is a row of its own with the figures below nothing. Only bills of one cashier when a cashier is named. Newest last.
    /// </summary>
    public IReadOnlyList<BillRow> Bills(DateOnly from, DateOnly to, long? cashierId = null, int limit = 5000)
    {
        Allowed();
        var time = shop.Current.Time;
        var decimals = shop.Current.Decimals;
        var args = new (string, object?)[] { ("$f", Iso.Text(time.StartOfDay(from))), ("$t", Iso.Text(time.StartOfNextDay(to))), ("$u", cashierId) };
        var docs = db.Query(
            $"SELECT d.id, d.type, d.number, d.issued_at, p.name AS customer, u.display_name AS cashier, d.total_minor, d.result FROM documents d LEFT JOIN parties p ON p.id = d.party_id LEFT JOIN users u ON u.id = d.user_id WHERE {BillWhere} ORDER BY d.issued_at, d.id LIMIT {Math.Max(1, limit)}",
            r => (Id: r.Int("id"), Type: r.Text("type"), Number: r.Text("number"), At: r.Time("issued_at"), Customer: r.TextOrNull("customer"), Cashier: r.TextOrNull("cashier"), Total: r.Int("total_minor"), Result: r.TextOrNull("result")), args);
        var paid = db.Query($"SELECT p.document_id, p.method, SUM(p.amount_minor) AS amount FROM payments p JOIN documents d ON d.id = p.document_id WHERE {BillWhere} GROUP BY p.document_id, p.method",
            r => (Doc: r.Int("document_id"), Method: r.Text("method"), Amount: r.Int("amount")), args).ToLookup(x => x.Doc);
        var cost = db.Query($"SELECT m.document_id, SUM(m.value_minor) AS value FROM stock_moves m JOIN documents d ON d.id = m.document_id WHERE {BillWhere} AND m.reason IN ('sale', 'return') GROUP BY m.document_id",
            r => (Doc: r.Int("document_id"), Value: r.Int("value")), args).ToDictionary(x => x.Doc, x => x.Value);
        return docs.Select(d =>
        {
            var sign = d.Type == DocTypes.CreditNote ? -1 : 1;
            var taxable = d.Result is null ? 0 : (long)MoneyText.Parse(NewtonJson.DeserializeObject<TaxResult>(d.Result)?.Totals?.Taxable ?? "0", decimals);
            var byMethod = paid[d.Id].ToDictionary(x => x.Method, x => sign < 0 ? -Math.Abs(x.Amount) : x.Amount);
            return new BillRow(d.Id, d.Number, d.At, sign < 0, d.Customer, d.Cashier, sign * taxable, sign * d.Total, byMethod.Values.Sum(), byMethod, -cost.GetValueOrDefault(d.Id));
        }).ToList();
    }

    /// <summary>
    /// Each item's sales in the period against what its goods cost (the older POS's profit by product, study 02 C4): the quantity, the sales before tax (after every discount), the cost of the stock that
    /// went out, and the profit; returns are taken off all three. Most profit first.
    /// </summary>
    public IReadOnlyList<ProfitRow> ProfitByItem(DateOnly from, DateOnly to)
    {
        Allowed();
        var time = shop.Current.Time;
        var decimals = shop.Current.Decimals;
        var args = new (string, object?)[] { ("$f", Iso.Text(time.StartOfDay(from))), ("$t", Iso.Text(time.StartOfNextDay(to))), ("$u", (long?)null) };
        var lines = db.Query(
            $"SELECT l.item_id, l.description, CASE d.type WHEN 'credit-note' THEN -1 ELSE 1 END AS sign, l.qty_milli, json_extract(j.value, '$.taxable') AS taxable FROM documents d JOIN document_lines l ON l.document_id = d.id JOIN json_each(d.result, '$.lines') j ON j.key = l.line_no - 1 WHERE {BillWhere}",
            r => (Item: r.IntOrNull("item_id"), Name: r.Text("description"), Sign: (int)r.Int("sign"), Qty: r.Int("qty_milli"), Taxable: (long)MoneyText.Parse(r.TextOrNull("taxable") ?? "0", decimals)), args);
        var cost = db.Query($"SELECT m.item_id, SUM(m.value_minor) AS value FROM stock_moves m JOIN documents d ON d.id = m.document_id WHERE {BillWhere} AND m.reason IN ('sale', 'return') GROUP BY m.item_id",
            r => (Item: r.Int("item_id"), Value: r.Int("value")), args).ToDictionary(x => x.Item, x => -x.Value);
        return lines.GroupBy(l => l.Item is { } id ? (object)id : l.Name).Select(g =>
        {
            var first = g.First();
            return new ProfitRow(first.Item, first.Name, g.Sum(x => x.Sign * x.Qty), g.Sum(x => x.Sign * x.Taxable), first.Item is { } id ? cost.GetValueOrDefault(id) : 0);
        }).Where(p => p.QtyMilli != 0 || p.TaxableMinor != 0).OrderByDescending(p => p.ProfitMinor).ThenBy(p => p.Name, StringComparer.CurrentCultureIgnoreCase).ToList();
    }

    /// <summary>
    /// The purchases received in the period (and goods sent back, as rows below nothing), one row each: who from, the value before tax, the tax, the total and what is paid (the older POS's purchase report,
    /// study 02 C3; the Hub has no "previous due" in a purchase, so the older program's double count of it cannot happen).
    /// </summary>
    public IReadOnlyList<PurchaseRow> PurchaseRegister(DateOnly from, DateOnly to)
    {
        Allowed();
        var time = shop.Current.Time;
        var decimals = shop.Current.Decimals;
        return db.Query(
            "SELECT d.id, d.type, d.number, d.issued_at, p.name AS supplier, d.tax_minor, d.total_minor, d.paid_minor, d.result FROM documents d LEFT JOIN parties p ON p.id = d.party_id " +
            "WHERE d.status = 'issued' AND d.type IN ('purchase','debit-note') AND d.issued_at >= $f AND d.issued_at < $t ORDER BY d.issued_at, d.id",
            r =>
            {
                var sign = r.Text("type") == DocTypes.DebitNote ? -1 : 1;
                var taxable = r.TextOrNull("result") is { } json ? (long)MoneyText.Parse(NewtonJson.DeserializeObject<TaxResult>(json)?.Totals?.Taxable ?? "0", decimals) : 0;
                return new PurchaseRow(r.Int("id"), r.Text("number"), r.Time("issued_at"), sign < 0, r.TextOrNull("supplier"), sign * taxable, sign * r.Int("tax_minor"), sign * r.Int("total_minor"), sign * r.Int("paid_minor"));
            }, ("$f", Iso.Text(time.StartOfDay(from))), ("$t", Iso.Text(time.StartOfNextDay(to))));
    }

    /// <summary>
    /// The last lines an item was sold on (and brought back on), newest first (the older POS's product sales history, study 02 C2): the price before discount and tax, the discount, the tax and what the
    /// line came to.
    /// </summary>
    public IReadOnlyList<ProductSale> ProductHistory(long itemId, int limit = 50)
    {
        Allowed();
        var decimals = shop.Current.Decimals;
        long Minor(string? text) => (long)MoneyText.Parse(text ?? "0", decimals);
        return db.Query(
            "SELECT d.id, d.type, d.number, d.issued_at, p.name AS customer, l.qty_milli, json_extract(j.value, '$.taxable') AS taxable, json_extract(j.value, '$.discount') AS discount, json_extract(j.value, '$.lineTotal') AS total " +
            "FROM documents d JOIN document_lines l ON l.document_id = d.id JOIN json_each(d.result, '$.lines') j ON j.key = l.line_no - 1 LEFT JOIN parties p ON p.id = d.party_id " +
            "WHERE d.status = 'issued' AND d.direction = 'out' AND d.type IN ('invoice','credit-note') AND l.item_id = $i ORDER BY d.issued_at DESC, d.id DESC, l.line_no LIMIT $n",
            r =>
            {
                var sign = r.Text("type") == DocTypes.CreditNote ? -1 : 1;
                var qty = r.Int("qty_milli");
                var taxable = Minor(r.TextOrNull("taxable"));
                var discount = Minor(r.TextOrNull("discount"));
                var total = Minor(r.TextOrNull("total"));
                var unit = qty == 0 ? 0 : (long)Math.Round((decimal)(taxable + discount) * 1000 / qty, 0, MidpointRounding.AwayFromZero);
                return new ProductSale(r.Int("id"), r.Text("number"), r.Time("issued_at"), sign < 0, r.TextOrNull("customer"), sign * qty, unit, sign * discount, sign * (total - taxable), sign * total);
            }, ("$i", itemId), ("$n", Math.Max(1, limit)));
    }

    /// <summary>The items that keep stock and have none left (or less than none), by name (the older POS's stock-out list, study 02 C6).</summary>
    public IReadOnlyList<OutOfStockRow> OutOfStock()
    {
        access.RequireAny(Perm.Reports, Perm.Stock);
        return db.Query(
            "SELECT i.id, i.name, i.unit, COALESCE((SELECT SUM(m.qty_milli) FROM stock_moves m WHERE m.item_id = i.id), 0) AS on_hand FROM items i WHERE i.track_stock = 1 AND i.active = 1 ORDER BY i.name COLLATE NOCASE",
            r => new OutOfStockRow(r.Int("id"), r.Text("name"), r.Text("unit"), r.Int("on_hand"))).Where(x => x.OnHandMilli <= 0).ToList();
    }

    /// <summary>Purchases received in the period (goods sent back to suppliers taken off) and what is still unpaid to suppliers (credit from goods sent back already counts as paid).</summary>
    public (long ReceivedMinor, long UnpaidMinor) Purchases(DateOnly from, DateOnly to)
    {
        Allowed();
        var time = shop.Current.Time;
        var received = Convert.ToInt64(db.Scalar("SELECT COALESCE(SUM(CASE type WHEN 'debit-note' THEN -total_minor ELSE total_minor END), 0) FROM documents WHERE type IN ('purchase','debit-note') AND status = 'issued' AND issued_at >= $f AND issued_at < $t",
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

    /// <summary>
    /// Reads a file a spreadsheet saved as text: rows of cells separated by commas, semicolons (the way some countries' spreadsheets save) or tabs, cells in quotes when they hold the separator,
    /// a quote or a line break. A mark at the start of the file is ignored, and so is an empty line. A cell that <see cref="Build"/> protected from being run as a formula (a quote in front) is given back as typed.
    /// </summary>
    public static List<string[]> Read(string text)
    {
        text = text.TrimStart('﻿');
        var first = text.Split('\n', 2)[0];
        var separator = new[] { ',', ';', '\t' }.OrderByDescending(ch => first.Count(x => x == ch)).First();
        if (first.Count(x => x == separator) == 0) separator = ',';
        var rows = new List<string[]>();
        var row = new List<string>();
        var cell = new System.Text.StringBuilder();
        var quoted = false;
        for (var i = 0; i < text.Length; i++)
        {
            var ch = text[i];
            if (quoted)
            {
                if (ch == '"' && i + 1 < text.Length && text[i + 1] == '"') { cell.Append('"'); i++; }
                else if (ch == '"') quoted = false;
                else cell.Append(ch);
            }
            else if (ch == '"' && cell.Length == 0) quoted = true;
            else if (ch == separator) { row.Add(Unprotect(cell.ToString())); cell.Clear(); }
            else if (ch == '\n' || ch == '\r')
            {
                if (ch == '\r' && i + 1 < text.Length && text[i + 1] == '\n') i++;
                row.Add(Unprotect(cell.ToString())); cell.Clear();
                if (row.Any(x => x.Length > 0)) rows.Add(row.ToArray());
                row.Clear();
            }
            else cell.Append(ch);
        }
        if (cell.Length > 0 || row.Count > 0)
        {
            row.Add(Unprotect(cell.ToString()));
            if (row.Any(x => x.Length > 0)) rows.Add(row.ToArray());
        }
        return rows;
    }

    private static string Unprotect(string cell) => cell.Length > 1 && cell[0] == '\'' && "=+-@".Contains(cell[1]) ? cell[1..] : cell.Trim();

    private static string Cell(object? value)
    {
        var text = value switch { null => "", IFormattable f => f.ToString(null, CultureInfo.InvariantCulture), _ => value.ToString() ?? "" };
        if (value is string && text.Length > 0 && "=+-@\t\r".Contains(text[0])) text = "'" + text;
        return text.Contains('"') || text.Contains(',') || text.Contains('\n') || text.Contains('\r') ? "\"" + text.Replace("\"", "\"\"") + "\"" : text;
    }
}
