using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Catalog;

/// <summary>One batch of an item that keeps batches: its number and dates, and how much of it is on the shelf. <see cref="Id"/> is 0 for the stock that is in no batch (taken when stock was allowed to go below nothing).</summary>
public sealed record BatchInfo(long Id, long ItemId, string ItemName, string Unit, string BatchNo, DateOnly? MfgOn, DateOnly? ExpOn, long OnHandMilli, int? DaysLeft)
{
    /// <summary>"expired", "soon" (within the days asked), "ok" or "none" (no expiry date).</summary>
    public string State(int soonDays) => DaysLeft is not { } d ? "none" : d <= 0 ? "expired" : d <= soonDays ? "soon" : "ok";
}

/// <summary>The batches a bill's goods came from or went into (to print on the bill, as the older POS did).</summary>
public sealed record BatchOnBill(long ItemId, string ItemName, string BatchNo, DateOnly? ExpOn, long QtyMilli);

/// <summary>
/// Batches and expiry dates of the items that keep them (the older POS kept stock per lot; see <see cref="StockBatches"/> for the rules). This is the reading side and the correction of a batch's dates;
/// the moves themselves are made by the sale, the purchase and the stock change.
/// </summary>
public sealed class BatchService(HubDb db, ShopContextProvider shop, IClock clock, AuditService audit, Access access)
{
    private static readonly string[] Readers = [Perm.Stock, Perm.Catalog, Perm.Purchases, Perm.Reports, Perm.Sell, Perm.Orders];

    private DateOnly Today => shop.Current.Time.LocalDate(clock.UtcNow);

    private BatchInfo Map(SqliteDataReader r, DateOnly today)
    {
        var exp = StockBatches.ParseDay(r.TextOrNull("exp_on"));
        return new BatchInfo(r.Int("id"), r.Int("item_id"), r.Text("name"), r.Text("unit"), r.Text("batch_no"), StockBatches.ParseDay(r.TextOrNull("mfg_on")), exp, r.Int("on_hand"), exp is { } e ? e.DayNumber - today.DayNumber : null);
    }

    private const string Select =
        "SELECT b.id, b.item_id, i.name, i.unit, b.batch_no, b.mfg_on, b.exp_on, COALESCE((SELECT SUM(m.qty_milli) FROM stock_moves m WHERE m.batch_id = b.id), 0) AS on_hand FROM item_batches b JOIN items i ON i.id = b.item_id";

    /// <summary>The batches of an item, soonest expiry first (no expiry last). Empty batches are left out unless asked for. Stock that is in no batch shows as one more line.</summary>
    public IReadOnlyList<BatchInfo> ForItem(long itemId, bool includeEmpty = false)
    {
        access.RequireAny(Readers);
        var today = Today;
        var rows = db.Query($"{Select} WHERE b.item_id = $i ORDER BY b.exp_on IS NULL, b.exp_on, b.id", r => Map(r, today), ("$i", itemId)).Where(b => includeEmpty || b.OnHandMilli != 0).ToList();
        var loose = Convert.ToInt64(db.Scalar("SELECT COALESCE(SUM(qty_milli), 0) FROM stock_moves WHERE item_id = $i AND batch_id IS NULL", ("$i", itemId)) ?? 0L);
        if (loose != 0 && db.Scalar("SELECT 1 FROM items WHERE id = $i AND track_batches = 1", ("$i", itemId)) is not null)
        {
            var item = db.Query("SELECT name, unit FROM items WHERE id = $i", r => (Name: r.Text("name"), Unit: r.Text("unit")), ("$i", itemId)).First();
            rows.Add(new BatchInfo(0, itemId, item.Name, item.Unit, "(no batch)", null, null, loose, null));
        }
        return rows;
    }

    /// <summary>Batches that have stock and expire within the days given, or have already expired (unless left out), soonest first.</summary>
    public IReadOnlyList<BatchInfo> Expiring(int withinDays, bool includeExpired = true)
    {
        access.RequireAny(Readers);
        var today = Today;
        var limit = StockBatches.DayText(today.AddDays(Math.Max(0, withinDays)));
        return db.Query($"{Select} WHERE b.exp_on IS NOT NULL AND b.exp_on <= $limit AND ($expired = 1 OR b.exp_on > $today) ORDER BY b.exp_on, i.name COLLATE NOCASE, b.id", r => Map(r, today),
            ("$limit", limit), ("$expired", includeExpired ? 1 : 0), ("$today", StockBatches.DayText(today))).Where(b => b.OnHandMilli > 0).ToList();
    }

    /// <summary>Every batch with stock (or every batch, if asked), for an item name or batch number typed in, soonest expiry first.</summary>
    public IReadOnlyList<BatchInfo> Search(string? text = null, bool withStock = true, int limit = 300)
    {
        access.RequireAny(Readers);
        var today = Today;
        var term = (text ?? "").Trim();
        var like = "%" + term.Replace("%", "\\%").Replace("_", "\\_") + "%";
        return db.Query($"{Select} WHERE ($t = '' OR i.name LIKE $like ESCAPE '\\' OR b.batch_no LIKE $like ESCAPE '\\') ORDER BY b.exp_on IS NULL, b.exp_on, i.name COLLATE NOCASE, b.id LIMIT $n", r => Map(r, today),
            ("$t", term), ("$like", like), ("$n", Math.Max(1, limit))).Where(b => !withStock || b.OnHandMilli > 0).ToList();
    }

    /// <summary>Corrects the dates of a batch (a date typed wrong on a delivery). The expiry cannot be before the date it was made.</summary>
    public void SetDates(long batchId, DateOnly? mfgOn, DateOnly? expOn, long? userId = null)
    {
        access.Require(Perm.Stock);
        if (mfgOn is { } m && expOn is { } e && e < m) throw new HubException("batch-dates", "The expiry date cannot be before the date it was made.");
        db.InTransaction((c, t) =>
        {
            var no = HubDb.Scalar(c, "SELECT batch_no FROM item_batches WHERE id = $id", t, ("$id", batchId)) as string ?? throw new HubException("not-found", "That batch was not found.");
            HubDb.Exec(c, "UPDATE item_batches SET mfg_on = $m, exp_on = $e WHERE id = $id", t,
                ("$m", mfgOn is { } mm ? StockBatches.DayText(mm) : null), ("$e", expOn is { } ee ? StockBatches.DayText(ee) : null), ("$id", batchId));
            audit.Log(c, t, userId, "batch-dates", "batch", batchId, $"{no}: made {(mfgOn is { } a ? StockBatches.DayText(a) : "-")}, expires {(expOn is { } b ? StockBatches.DayText(b) : "-")}");
        });
    }

    /// <summary>The batches the goods of a bill came out of (a sale) or went into (a purchase), for printing on it.</summary>
    public IReadOnlyList<BatchOnBill> OnBill(long documentId)
    {
        access.RequireAny(Readers);
        return db.Query(
            "SELECT m.item_id, i.name, b.batch_no, b.exp_on, SUM(ABS(m.qty_milli)) AS qty FROM stock_moves m JOIN item_batches b ON b.id = m.batch_id JOIN items i ON i.id = m.item_id " +
            "WHERE m.document_id = $d AND m.reason IN ('sale', 'purchase') GROUP BY m.item_id, b.id ORDER BY MIN(m.id)",
            r => new BatchOnBill(r.Int("item_id"), r.Text("name"), r.Text("batch_no"), StockBatches.ParseDay(r.TextOrNull("exp_on")), r.Int("qty")), ("$d", documentId));
    }
}
