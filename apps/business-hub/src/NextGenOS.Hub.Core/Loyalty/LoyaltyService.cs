using System.Globalization;
using System.Numerics;
using System.Text.Json;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Shop;
using NextGenOS.Tax;
using NewtonJson = Newtonsoft.Json.JsonConvert;

namespace NextGenOS.Hub.Loyalty;

/// <summary>
/// Loyalty points (decision 31, the older touch tills' way: points for each item, each point worth some money). The shop turns them on in Settings and chooses what an item earns when it
/// has no setting of its own; an item can have its own ("per": a percent of what the line comes to before tax; "point": points for each unit sold). A customer's points are the sum of
/// a ledger that is only ever added to. Points are earned when a bill to a named customer is made, used as a discount on a later bill (never more than the balance), and taken back
/// with a return or a cancelled bill.
///
/// Where the older POS differed, and what is done here: the points on a line are worked from what the line comes to after its discounts and before tax (the older POS used the price
/// before discounts, so a discounted line earned on the full price); points cannot be used beyond the balance (the older touch tills did not check); everything happens in the same
/// transaction as the bill, so a bill that fails never uses or gives points.
/// </summary>
public sealed class LoyaltyService(HubDb db, ShopContextProvider shop, IClock clock)
{
    /// <summary>The keys of an item's own setting, in its loose attributes.</summary>
    public const string ModeKey = "loyalty-mode", ValueKey = "loyalty-value";

    public static readonly string[] Modes = ["none", "per", "point"];

    public bool Enabled => shop.Settings.LoyaltyOn;

    // ---- the arithmetic (whole numbers, rounded half up) ------------------------------------------------------------------------------

    private static long R(BigInteger a, BigInteger b) => (long)((2 * a + b) / (2 * b));

    /// <summary>
    /// The points (in hundredths) a line earns. "per": baseMinor is what the line comes to before tax and after discounts; the value is a percent in thousandths (5000 = 5%): 600.00 at 5% is
    /// 30.00 points. "point": the value is points for each unit in thousandths (2000 = 2 points): 4 units is 8.00 points.
    /// </summary>
    public static long LinePointsCent(string mode, long valueMilli, long baseMinor, long qtyMilli, int decimals)
    {
        if (valueMilli <= 0) return 0;
        return mode switch
        {
            "per" => baseMinor <= 0 ? 0 : R((BigInteger)baseMinor * valueMilli, BigInteger.Pow(10, decimals) * 1000),
            "point" => qtyMilli <= 0 ? 0 : R((BigInteger)qtyMilli * valueMilli, 10_000),
            _ => 0,
        };
    }

    /// <summary>What points (in hundredths) are worth in the shop's money (minor units), given what one point is worth in thousandths of a whole unit.</summary>
    public static long PointsValueMinor(long pointsCent, long pointValueMilli, int decimals) =>
        pointsCent <= 0 || pointValueMilli <= 0 ? 0 : R((BigInteger)pointsCent * pointValueMilli * BigInteger.Pow(10, decimals), 100 * 1000);

    /// <summary>"5" or "2.5" or "2,5" as thousandths. Anything else is no value.</summary>
    public static long ParseMilli(string? text)
    {
        if (string.IsNullOrWhiteSpace(text)) return 0;
        try { return (long)MoneyText.Parse(text.Trim().Replace(',', '.'), 3); }
        catch (FormatException) { return 0; }
    }

    // ---- reading ---------------------------------------------------------------------------------------------------------------

    public long Balance(long partyId) => Convert.ToInt64(db.Scalar("SELECT COALESCE(SUM(points_cent), 0) FROM loyalty_ledger WHERE party_id = $p", ("$p", partyId)) ?? 0L);

    public long Balance(SqliteConnection c, SqliteTransaction t, long partyId) =>
        Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(SUM(points_cent), 0) FROM loyalty_ledger WHERE party_id = $p", t, ("$p", partyId)) ?? 0L);

    public sealed record Row(DateTimeOffset At, string Kind, long PointsCent, string? Memo, long BalanceCent);

    public IReadOnlyList<Row> Ledger(long partyId)
    {
        var rows = db.Query("SELECT at, kind, points_cent, memo FROM loyalty_ledger WHERE party_id = $p ORDER BY id",
            r => (At: DateTimeOffset.Parse(r.GetString(0), CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal), Kind: r.GetString(1), Points: r.GetInt64(2), Memo: r.IsDBNull(3) ? null : r.GetString(3)), ("$p", partyId));
        long running = 0;
        return rows.Select(r => new Row(r.At, r.Kind, r.Points, r.Memo, running += r.Points)).ToList();
    }

    /// <summary>What a bill earned and used, and where the customer stands now, for the bill to print (in hundredths of a point).</summary>
    public sealed record Summary(long EarnedCent, long UsedCent, long BalanceCent);

    public Summary? ForDocument(long documentId, long partyId)
    {
        var rows = db.Query("SELECT kind, points_cent FROM loyalty_ledger WHERE document_id = $d", r => (Kind: r.GetString(0), Points: r.GetInt64(1)), ("$d", documentId));
        if (rows.Count == 0) return null;
        return new Summary(rows.Where(r => r.Kind == "earn").Sum(r => r.Points), -rows.Where(r => r.Kind == "redeem").Sum(r => r.Points), Balance(partyId));
    }

    /// <summary>What one point is worth now, as money.</summary>
    public long ValueOf(long pointsCent) => PointsValueMinor(pointsCent, shop.Settings.LoyaltyPointValueMilli, shop.Current.Decimals);

    // ---- earning, using and taking back, inside the transaction of the bill ------------------------------------------------------------

    private sealed record Doc(string Type, string Direction, long? PartyId, string? Number, string? Result, int Decimals, long PointsUsedCent);

    private static Doc? LoadDoc(SqliteConnection c, SqliteTransaction t, long id) => HubDb.Query(c,
        "SELECT type, direction, party_id, number, result, currency_decimals, loyalty_points_used_cent FROM documents WHERE id = $id",
        r => new Doc(r.GetString(0), r.GetString(1), r.IsDBNull(2) ? null : r.GetInt64(2), r.IsDBNull(3) ? null : r.GetString(3), r.IsDBNull(4) ? null : r.GetString(4), r.GetInt32(5), r.GetInt64(6)), t, ("$id", id)).FirstOrDefault();

    /// <summary>The points the lines of a document earn under the rules above, in hundredths.</summary>
    private long PointsOf(SqliteConnection c, SqliteTransaction t, long documentId, Doc doc)
    {
        if (doc.Result is null) return 0;
        var settings = shop.Settings;
        var result = NewtonJson.DeserializeObject<TaxResult>(doc.Result);
        if (result is null) return 0;
        var lines = HubDb.Query(c, "SELECT item_id, qty_milli FROM document_lines WHERE document_id = $id ORDER BY line_no", r => (Item: r.IsDBNull(0) ? (long?)null : r.GetInt64(0), Qty: r.GetInt64(1)), t, ("$id", documentId));
        long total = 0;
        for (var i = 0; i < lines.Count && i < result.Lines.Count; i++)
        {
            var (mode, value) = ModeOf(c, t, lines[i].Item, settings);
            var taxable = (long)MoneyText.Parse(result.Lines[i].Taxable, doc.Decimals);
            total += LinePointsCent(mode, value, taxable, lines[i].Qty, doc.Decimals);
        }
        return total;
    }

    private static (string Mode, long Value) ModeOf(SqliteConnection c, SqliteTransaction t, long? itemId, ShopSettings settings)
    {
        if (itemId is { } id && HubDb.Scalar(c, "SELECT attrs FROM items WHERE id = $id", t, ("$id", id)) is string json && json.Length > 2)
        {
            try
            {
                var attrs = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                if (attrs is not null && attrs.TryGetValue(ModeKey, out var mode) && Modes.Contains(mode))
                    return mode == "none" ? ("none", 0) : (mode, attrs.TryGetValue(ValueKey, out var value) ? ParseMilli(value) : 0);
            }
            catch (JsonException) { /* a damaged setting means the shop's own */ }
        }
        return (Modes.Contains(settings.LoyaltyDefaultMode) ? settings.LoyaltyDefaultMode : "none", settings.LoyaltyDefaultValueMilli);
    }

    private static void Add(SqliteConnection c, SqliteTransaction t, DateTimeOffset at, long partyId, string kind, long pointsCent, long? documentId, string memo, long? userId, DateTimeOffset now) =>
        HubDb.Exec(c, "INSERT INTO loyalty_ledger(party_id, at, kind, points_cent, document_id, memo, user_id, created_at) VALUES ($p, $at, $k, $pts, $d, $m, $u, $now)", t,
            ("$p", partyId), ("$at", Iso.Text(at)), ("$k", kind), ("$pts", pointsCent), ("$d", documentId), ("$m", memo), ("$u", userId), ("$now", Iso.Text(now)));

    /// <summary>A bill to a named customer has just been made: the points used are taken, the points earned are given.</summary>
    public void OnIssued(SqliteConnection c, SqliteTransaction t, long documentId, long? userId)
    {
        if (!Enabled || LoadDoc(c, t, documentId) is not { Type: "invoice", Direction: "out", PartyId: { } party } doc) return;
        var now = clock.UtcNow;
        if (doc.PointsUsedCent > 0)
        {
            var balance = Balance(c, t, party);
            if (doc.PointsUsedCent > balance) throw new HubException("loyalty", $"This customer has only {Points(balance)} points, not {Points(doc.PointsUsedCent)}.");
            Add(c, t, now, party, "redeem", -doc.PointsUsedCent, documentId, $"Used on {doc.Number}", userId, now);
        }
        var earned = PointsOf(c, t, documentId, doc);
        if (earned > 0) Add(c, t, now, party, "earn", earned, documentId, $"Earned on {doc.Number}", userId, now);
    }

    /// <summary>A bill was cancelled: whatever it earned or used is turned round.</summary>
    public void OnVoid(SqliteConnection c, SqliteTransaction t, long documentId, long? userId)
    {
        if (LoadDoc(c, t, documentId) is not { PartyId: { } party } doc) return;
        var now = clock.UtcNow;
        foreach (var row in HubDb.Query(c, "SELECT kind, points_cent FROM loyalty_ledger WHERE document_id = $d AND kind IN ('earn', 'redeem') ORDER BY id", r => (Kind: r.GetString(0), Points: r.GetInt64(1)), t, ("$d", documentId)))
            Add(c, t, now, party, "void", -row.Points, documentId, $"{doc.Number} cancelled", userId, now);
    }

    /// <summary>Goods came back on a credit note: the points the returned lines earned are taken back (the balance may go below nothing; points cannot then be used until it is above nothing).</summary>
    public void OnCreditNote(SqliteConnection c, SqliteTransaction t, long noteId, long invoiceId, long? userId)
    {
        if (!Enabled || LoadDoc(c, t, noteId) is not { PartyId: { } party } note) return;
        if (HubDb.Scalar(c, "SELECT 1 FROM loyalty_ledger WHERE document_id = $d AND kind = 'earn' LIMIT 1", t, ("$d", invoiceId)) is null) return;   // that bill earned nothing
        var back = PointsOf(c, t, noteId, note);
        if (back > 0) Add(c, t, clock.UtcNow, party, "return", -back, noteId, $"Returned on {note.Number}", userId, clock.UtcNow);
    }

    private static string Points(long cent) => (cent / 100m).ToString("0.##", CultureInfo.InvariantCulture);
}
