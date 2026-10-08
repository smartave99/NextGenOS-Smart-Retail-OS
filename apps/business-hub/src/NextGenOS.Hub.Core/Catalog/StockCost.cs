using System.Numerics;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Data;

namespace NextGenOS.Hub.Catalog;

/// <summary>
/// What stock is worth (docs/PLATFORM-DECISIONS.md decision 36). Every move of stock carries its value in money, signed like its quantity, so what an item holds and what it is worth are the
/// sums of its moves, and the <b>average cost</b> is the one divided by the other. A purchase brings in its quantity at what was paid for it (the line's amount without tax, after discounts);
/// a sale takes out its quantity at the average cost of that moment, and the last unit takes out whatever value is left, so nothing is left behind when the shelf is empty; goods brought back
/// by a customer return at the cost they left at; a count, damage or a delivery is valued at the average (a delivery at the item's last cost price).
/// <para>
/// All in whole minor units. A share of a value is rounded half-up, and a move that takes everything out takes exactly what is left, so the pieces always add up to the whole.
/// When the shelf holds nothing (or less than nothing, if the shop lets stock go below zero) there is no average, and the item's last cost price stands in for it.
/// </para>
/// </summary>
internal static class StockCost
{
    /// <summary>What an item holds, and what that is worth.</summary>
    public readonly record struct Held(long QtyMilli, long ValueMinor)
    {
        /// <summary>True when there is a real average: stock on the shelf, worth something that is not below nothing.</summary>
        public bool HasAverage => QtyMilli > 0 && ValueMinor >= 0;
    }

    public static Held Read(SqliteConnection c, SqliteTransaction? t, long itemId) => HubDb.Query(c,
        "SELECT COALESCE(SUM(qty_milli), 0), COALESCE(SUM(value_minor), 0) FROM stock_moves WHERE item_id = $i", r => new Held(r.GetInt64(0), r.GetInt64(1)), t, ("$i", itemId)).Single();

    /// <summary>The cost price on the item: what was paid last, which stands in for the average when there is none.</summary>
    public static long LastCost(SqliteConnection c, SqliteTransaction? t, long itemId) =>
        Convert.ToInt64(HubDb.Scalar(c, "SELECT cost_minor FROM items WHERE id = $i", t, ("$i", itemId)) ?? 0L);

    /// <summary>value × numerator ÷ denominator, rounded half-up; for amounts that are not below nothing.</summary>
    public static long Share(long value, long numerator, long denominator) =>
        denominator <= 0 || value <= 0 || numerator <= 0 ? 0 : (long)((2 * (BigInteger)value * numerator + denominator) / (2 * (BigInteger)denominator));

    /// <summary>What a quantity (in thousandths) is worth at a price for one whole unit.</summary>
    public static long Worth(long qtyMilli, long unitCostMinor) => Share(unitCostMinor, qtyMilli, 1000);

    /// <summary>What it costs to take this quantity (positive, in thousandths) off the shelf now. Never below nothing.</summary>
    public static long TakeOut(SqliteConnection c, SqliteTransaction? t, long itemId, long qtyMilli)
    {
        if (qtyMilli <= 0) return 0;
        var held = Read(c, t, itemId);
        if (!held.HasAverage) return Worth(qtyMilli, LastCost(c, t, itemId));
        if (qtyMilli == held.QtyMilli) return held.ValueMinor;
        if (qtyMilli < held.QtyMilli) return Share(held.ValueMinor, qtyMilli, held.QtyMilli);
        return held.ValueMinor + Worth(qtyMilli - held.QtyMilli, LastCost(c, t, itemId));    // more than is held: what is held at its average, the rest at the last price
    }

    /// <summary>What this quantity is worth when it joins the shelf without a price of its own (a count that found more): at the average, so the average does not move.</summary>
    public static long BringIn(SqliteConnection c, SqliteTransaction? t, long itemId, long qtyMilli)
    {
        if (qtyMilli <= 0) return 0;
        var held = Read(c, t, itemId);
        return held.HasAverage ? Share(held.ValueMinor, qtyMilli, held.QtyMilli) : Worth(qtyMilli, LastCost(c, t, itemId));
    }

    /// <summary>The value of what was taken out (or put in) by the moves a document made for an item, as a positive amount, and whether any of them had a value. Moves made before values were kept have none.</summary>
    public static (long Value, long Qty, bool Known) Made(SqliteConnection c, SqliteTransaction? t, long documentId, long itemId, string reason) => HubDb.Query(c,
        "SELECT COALESCE(SUM(value_minor), 0), COALESCE(SUM(qty_milli), 0), COUNT(value_minor) FROM stock_moves WHERE document_id = $d AND item_id = $i AND reason = $r",
        r => (Value: Math.Abs(r.GetInt64(0)), Qty: Math.Abs(r.GetInt64(1)), Known: r.GetInt64(2) > 0), t, ("$d", documentId), ("$i", itemId), ("$r", reason)).Single();

    /// <summary>
    /// What goods brought back by a customer are worth: what they cost when they were sold (not what the average is now). A part of what was sold is that part of its cost, and the part that
    /// brings the last of it back takes exactly what is left of it, so the returns of one bill never add up to more or less than the bill cost. A bill made before costs were kept has no cost
    /// to give back, so the goods return at the average.
    /// </summary>
    public static long Returned(SqliteConnection c, SqliteTransaction? t, long invoiceId, long creditNoteId, long itemId, long qtyMilli)
    {
        var sold = Made(c, t, invoiceId, itemId, "sale");
        if (!sold.Known || sold.Qty <= 0) return BringIn(c, t, itemId, qtyMilli);
        var before = HubDb.Query(c,
            "SELECT COALESCE(SUM(m.qty_milli), 0), COALESCE(SUM(m.value_minor), 0) FROM stock_moves m JOIN documents d ON d.id = m.document_id " +
            "WHERE d.ref_document_id = $inv AND d.type = 'credit-note' AND m.reason = 'return' AND m.item_id = $i AND m.document_id <> $note",
            r => (Qty: r.GetInt64(0), Value: r.GetInt64(1)), t, ("$inv", invoiceId), ("$i", itemId), ("$note", creditNoteId)).Single();
        return qtyMilli + before.Qty >= sold.Qty ? Math.Max(0, sold.Value - before.Value) : Share(sold.Value, qtyMilli, sold.Qty);
    }

    /// <summary>Writes a move of stock with its value. Returns its number.</summary>
    public static long Insert(SqliteConnection c, SqliteTransaction t, long itemId, long qtyMilli, string reason, long? documentId, string? note, DateTimeOffset at, long? userId, long valueMinor) => HubDb.Insert(c,
        "INSERT INTO stock_moves(item_id, qty_milli, reason, document_id, note, at, user_id, value_minor) VALUES ($i, $q, $r, $d, $n, $at, $u, $v)", t,
        ("$i", itemId), ("$q", qtyMilli), ("$r", reason), ("$d", documentId), ("$n", note), ("$at", Iso.Text(at)), ("$u", userId), ("$v", valueMinor));
}
