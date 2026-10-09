using System.Globalization;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Catalog;

/// <summary>
/// Batches of an item (the older POS kept stock "per lot" with a batch number and dates; docs/old-programs/01 section 6, 02 A2). An item that keeps batches has its stock in batches: every move of stock
/// says which batch it was in, and the stock of a batch is the sum of its moves. The stock of the item, its value and its average cost (decision 36) are still the sums over all its moves, so
/// money is worked out exactly as for any other item and a move is only <i>shared among batches</i> afterwards: its quantity by the rule below, its value in proportion to the quantities.
/// <list type="bullet">
/// <item><b>A sale takes the batch that expires first</b> (an item with no expiry date comes last), and <b>never takes a batch that has expired</b>: a batch is expired on its expiry date, as in the older program
/// ("the bill date is on or after it"). If what can be sold is not enough, the sale is refused, saying how much is out of date, unless the shop lets stock go below nothing, in which case the rest is taken without a batch.</item>
/// <item>Goods a customer brings back, a cancelled sale, goods sent back to a supplier and a cancelled purchase go back into (or out of) the batches the original moves used, in the order they were used.</item>
/// <item>A delivery names the batch it brought (and its dates); a count or damage names the batch it found.</item>
/// </list>
/// </summary>
internal static class StockBatches
{
    public readonly record struct Part(long? BatchId, long QtyMilli);

    /// <summary>A quantity in thousandths written for a person: 12, 2.5, 0.</summary>
    public static string Plain(long milli) => ShopContext.Qty(milli).TrimEnd('0').TrimEnd('.');

    public static string DayText(DateOnly day) => day.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

    public static DateOnly? ParseDay(string? text) => text is null ? null : DateOnly.ParseExact(text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

    public static bool Keeps(SqliteConnection c, SqliteTransaction? t, long itemId) =>
        Convert.ToInt64(HubDb.Scalar(c, "SELECT track_batches FROM items WHERE id = $i", t, ("$i", itemId)) ?? 0L) != 0;

    /// <summary>The batch of this item with this number, made if it is new. A batch has one expiry date: a different one is refused, a missing one is filled in.</summary>
    public static long FindOrCreate(SqliteConnection c, SqliteTransaction t, long itemId, string batchNo, DateOnly? mfgOn, DateOnly? expOn, DateTimeOffset at)
    {
        var no = (batchNo ?? "").Trim();
        if (no.Length == 0) throw new HubException("batch-no", "Please give the batch number.");
        if (no.Length > 40) throw new HubException("batch-no", "A batch number can have at most 40 letters and digits.");
        if (mfgOn is { } m && expOn is { } e && e < m) throw new HubException("batch-dates", "The expiry date cannot be before the date it was made.");
        var existing = HubDb.Query(c, "SELECT id, mfg_on, exp_on FROM item_batches WHERE item_id = $i AND batch_no = $n COLLATE NOCASE",
            r => (Id: r.GetInt64(0), Mfg: ParseDay(r.IsDBNull(1) ? null : r.GetString(1)), Exp: ParseDay(r.IsDBNull(2) ? null : r.GetString(2))), t, ("$i", itemId), ("$n", no)).FirstOrDefault();
        if (existing != default)
        {
            if (expOn is { } given && existing.Exp is { } had && given != had)
                throw new HubException("batch-expiry", $"Batch {no} already expires on {had:d MMM yyyy}, not {given:d MMM yyyy}. Use the same date, or correct the batch first.");
            if ((existing.Exp is null && expOn is not null) || (existing.Mfg is null && mfgOn is not null))
                HubDb.Exec(c, "UPDATE item_batches SET mfg_on = COALESCE(mfg_on, $m), exp_on = COALESCE(exp_on, $e) WHERE id = $id", t,
                    ("$m", mfgOn is { } mm ? DayText(mm) : null), ("$e", expOn is { } ee ? DayText(ee) : null), ("$id", existing.Id));
            return existing.Id;
        }
        return HubDb.Insert(c, "INSERT INTO item_batches(item_id, batch_no, mfg_on, exp_on, created_at) VALUES ($i, $n, $m, $e, $at)", t,
            ("$i", itemId), ("$n", no), ("$m", mfgOn is { } m2 ? DayText(m2) : null), ("$e", expOn is { } e2 ? DayText(e2) : null), ("$at", Iso.Text(at)));
    }

    /// <summary>Switches an item over to batches: what is on the shelf now becomes one batch called "OPENING" (no dates), so the sum of the batches is the stock of the item from the first moment.</summary>
    public static void Start(SqliteConnection c, SqliteTransaction t, long itemId, DateTimeOffset at)
    {
        var held = HubDb.Query(c, "SELECT COALESCE(SUM(qty_milli), 0), COALESCE(SUM(value_minor), 0) FROM stock_moves WHERE item_id = $i AND batch_id IS NULL", r => (Qty: r.GetInt64(0), Value: r.GetInt64(1)), t, ("$i", itemId)).Single();
        if (held.Qty == 0 && held.Value == 0) return;
        var batch = FindOrCreate(c, t, itemId, "OPENING", null, null, at);
        // two moves that cancel each other for the item (its stock and value do not change): out of "no batch", into the batch
        HubDb.Exec(c, "INSERT INTO stock_moves(item_id, qty_milli, reason, note, at, value_minor, batch_id) VALUES ($i, $q, 'batch-start', 'Stock put into the first batch', $at, $v, NULL)", t,
            ("$i", itemId), ("$q", -held.Qty), ("$at", Iso.Text(at)), ("$v", -held.Value));
        HubDb.Exec(c, "INSERT INTO stock_moves(item_id, qty_milli, reason, note, at, value_minor, batch_id) VALUES ($i, $q, 'batch-start', 'Stock put into the first batch', $at, $v, $b)", t,
            ("$i", itemId), ("$q", held.Qty), ("$at", Iso.Text(at)), ("$v", held.Value), ("$b", batch));
    }

    public readonly record struct Held(long Id, string BatchNo, DateOnly? ExpOn, long QtyMilli);

    /// <summary>The batches of an item that have stock, with how much each holds.</summary>
    public static IReadOnlyList<Held> OnHand(SqliteConnection c, SqliteTransaction? t, long itemId) => HubDb.Query(c,
        "SELECT b.id, b.batch_no, b.exp_on, COALESCE(SUM(m.qty_milli), 0) AS q FROM item_batches b LEFT JOIN stock_moves m ON m.batch_id = b.id WHERE b.item_id = $i GROUP BY b.id HAVING q > 0",
        r => new Held(r.GetInt64(0), r.GetString(1), ParseDay(r.IsDBNull(2) ? null : r.GetString(2)), r.GetInt64(3)), t, ("$i", itemId));

    /// <summary>A batch has expired on its expiry date and after it.</summary>
    public static bool Expired(DateOnly? expOn, DateOnly today) => expOn is { } e && e <= today;

    /// <summary>
    /// Takes a quantity (positive) off the batches for a sale: soonest expiry first, none that has expired. What cannot be taken goes without a batch if the shop lets stock go below nothing, and is
    /// refused otherwise.
    /// </summary>
    public static List<Part> TakeOut(SqliteConnection c, SqliteTransaction t, long itemId, string itemName, long qtyMilli, DateOnly today, bool allowNegative)
    {
        var held = OnHand(c, t, itemId);
        var parts = new List<Part>();
        var left = qtyMilli;
        foreach (var b in held.Where(x => !Expired(x.ExpOn, today)).OrderBy(x => x.ExpOn ?? DateOnly.MaxValue).ThenBy(x => x.Id))
        {
            if (left <= 0) break;
            var take = Math.Min(left, b.QtyMilli);
            parts.Add(new Part(b.Id, take));
            left -= take;
        }
        if (left > 0)
        {
            if (!allowNegative)
            {
                var sellable = qtyMilli - left;
                var expired = held.Where(x => Expired(x.ExpOn, today)).Sum(x => x.QtyMilli);
                throw new HubException("stock", expired > 0
                    ? $"Only {Plain(sellable)} of {itemName} can be sold: {Plain(expired)} more {(expired == 1000 ? "is" : "are")} past the expiry date."
                    : $"Only {Plain(sellable)} of {itemName} left.");
            }
            parts.Add(new Part(null, left));
        }
        return parts;
    }

    /// <summary>
    /// Shares a quantity (positive) among the batches the original moves used: those of document <paramref name="originDocument"/> for this item with the reason <paramref name="originReason"/>, in the
    /// order they were made, each up to what it took less what other documents that refer to the origin have already given back (<paramref name="backReason"/>). What does not fit goes to the last batch.
    /// </summary>
    public static List<Part> Follow(SqliteConnection c, SqliteTransaction t, long originDocument, long itemId, string originReason, string backReason, long qtyMilli, long exceptDocument)
    {
        var origin = HubDb.Query(c, "SELECT batch_id, SUM(qty_milli) FROM stock_moves WHERE document_id = $d AND item_id = $i AND reason = $r GROUP BY batch_id ORDER BY MIN(id)",
            r => (Batch: r.IsDBNull(0) ? (long?)null : r.GetInt64(0), Qty: Math.Abs(r.GetInt64(1))), t, ("$d", originDocument), ("$i", itemId), ("$r", originReason));
        if (origin.Count == 0) return [new Part(null, qtyMilli)];
        var back = HubDb.Query(c,
            "SELECT m.batch_id, SUM(m.qty_milli) FROM stock_moves m JOIN documents d ON d.id = m.document_id WHERE d.ref_document_id = $o AND m.item_id = $i AND m.reason = $r AND m.document_id <> $x GROUP BY m.batch_id",
            r => (Batch: r.IsDBNull(0) ? (long?)null : r.GetInt64(0), Qty: Math.Abs(r.GetInt64(1))), t, ("$o", originDocument), ("$i", itemId), ("$r", backReason), ("$x", exceptDocument));
        var parts = new List<Part>();
        var left = qtyMilli;
        foreach (var o in origin)
        {
            if (left <= 0) break;
            var room = o.Qty - back.Where(b => b.Batch == o.Batch).Sum(b => b.Qty);
            var take = Math.Min(left, Math.Max(0, room));
            if (take > 0) { parts.Add(new Part(o.Batch, take)); left -= take; }
        }
        if (left > 0) parts.Add(new Part(origin[^1].Batch, left));
        return parts;
    }

    /// <summary>
    /// What a purchase brought, batch by batch: its lines for this item, each naming the batch (and dates) it came in. Lines of one batch are added together. A line with no batch number is refused.
    /// </summary>
    public static List<Part> Delivered(SqliteConnection c, SqliteTransaction t, long documentId, long itemId, string itemName, DateTimeOffset at)
    {
        var lines = HubDb.Query(c, "SELECT batch_no, mfg_on, exp_on, qty_milli FROM document_lines WHERE document_id = $d AND item_id = $i ORDER BY line_no",
            r => (No: r.IsDBNull(0) ? null : r.GetString(0), Mfg: ParseDay(r.IsDBNull(1) ? null : r.GetString(1)), Exp: ParseDay(r.IsDBNull(2) ? null : r.GetString(2)), Qty: r.GetInt64(3)), t, ("$d", documentId), ("$i", itemId));
        var parts = new List<Part>();
        foreach (var l in lines)
        {
            if (string.IsNullOrWhiteSpace(l.No)) throw new HubException("batch-no", $"Please give the batch number of {itemName}.");
            var id = FindOrCreate(c, t, itemId, l.No, l.Mfg, l.Exp, at);
            var at2 = parts.FindIndex(p => p.BatchId == id);
            if (at2 >= 0) parts[at2] = new Part(id, parts[at2].QtyMilli + l.Qty);
            else parts.Add(new Part(id, l.Qty));
        }
        return parts;
    }

    /// <summary>Shares a value among parts in proportion to their quantities; the last part takes what is left, so the pieces add up to the whole.</summary>
    public static long[] Share(long valueMinor, IReadOnlyList<Part> parts)
    {
        var shares = new long[parts.Count];
        var total = parts.Sum(p => p.QtyMilli);
        long left = valueMinor;
        for (var i = 0; i < parts.Count; i++)
        {
            shares[i] = i == parts.Count - 1 ? left : (total == 0 ? 0 : (long)Math.Round((decimal)valueMinor * parts[i].QtyMilli / total, 0, MidpointRounding.AwayFromZero));
            left -= shares[i];
        }
        return shares;
    }
}
