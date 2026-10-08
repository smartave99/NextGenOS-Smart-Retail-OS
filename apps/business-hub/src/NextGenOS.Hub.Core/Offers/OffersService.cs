using System.Globalization;
using System.Numerics;
using System.Security.Cryptography;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Offers;

public static class OfferKinds
{
    /// <summary>Money off a bill that comes to an amount between two limits.</summary>
    public const string BillRange = "bill-range";
    /// <summary>A gift voucher given with a bill that comes to an amount between two limits, to use on a later visit.</summary>
    public const string GiftRule = "gift-rule";
    /// <summary>A percent off one item.</summary>
    public const string ItemPercent = "item-percent";
    /// <summary>Buy so many of an item and get so many of it free.</summary>
    public const string BuyGet = "buy-get";

    public static readonly string[] All = [BillRange, GiftRule, ItemPercent, BuyGet];
}

public sealed record Offer(
    long Id, string Kind, string? Name, long? ItemId, string? ItemName, long? FromMinor, long? ToMinor, long AmountMinor, long PctMilli, long MinQtyMilli, long FreeQtyMilli,
    DateOnly? ValidFrom, DateOnly? ValidTo, bool Enabled)
{
    public bool IsLive(DateOnly today) => Enabled && OffersService.InWindow(ValidFrom, ValidTo, today);
}

public sealed class OfferInput
{
    /// <summary>Null makes a new rule; an id changes that rule.</summary>
    public long? Id { get; set; }
    public string Kind { get; set; } = OfferKinds.BillRange;
    public string? Name { get; set; }
    public long? ItemId { get; set; }
    /// <summary>For a bill or voucher rule: the bill comes to at least this much (before tax and bill discounts).</summary>
    public long FromMinor { get; set; }
    /// <summary>... and at most this much. Null: no upper limit.</summary>
    public long? ToMinor { get; set; }
    /// <summary>Money off the bill (a bill rule), or the value of the voucher (a voucher rule).</summary>
    public long AmountMinor { get; set; }
    /// <summary>A percent off the item, in thousandths (10000 = 10%).</summary>
    public long PctMilli { get; set; }
    public long MinQtyMilli { get; set; }
    public long FreeQtyMilli { get; set; }
    public DateOnly? ValidFrom { get; set; }
    public DateOnly? ValidTo { get; set; }
    public bool Enabled { get; set; } = true;
}

/// <summary>A coupon (made by the shop for a customer) or a gift voucher (earned by a bill).</summary>
public sealed record Voucher(
    long Id, string Kind, string Code, long AmountMinor, long? PartyId, string? PartyName, DateOnly? ValidFrom, DateOnly? ValidTo, bool Enabled,
    DateTimeOffset IssuedAt, long? IssuedDocumentId, DateTimeOffset? UsedAt, long? UsedDocumentId)
{
    public string Pretty => OffersService.Pretty(Code);
    public bool Used => UsedAt is not null;
    public string Noun => Kind == "gift" ? "gift voucher" : "coupon";

    /// <summary>"ready", or why it cannot be used today: "expired", "used", "off" or "waiting" (it starts later).</summary>
    public string State(DateOnly today) => OffersService.Problem(this, today) ?? "ready";
}

/// <summary>What an offer or a voucher took off a bill.</summary>
public sealed record AppliedOffer(long Id, string Kind, long? VoucherId, string Label, long AmountMinor);

/// <summary>Everything offers did to one bill, for the till and the receipt.</summary>
public sealed record DocumentOffers(IReadOnlyList<AppliedOffer> Applied, AppliedOffer? Declined, long TotalMinor, IReadOnlyList<Voucher> Earned);

/// <summary>
/// Offers, coupons and gift vouchers (docs/old-programs/02-masters-accounting-reports.md, A1.7 to A1.9). Four kinds of rule feed a bill, and two kinds of code:
///   item offer      a percent off one item for some days;
///   customer rate   a customer's standing discount percent (it wins over an item offer, as it did in the older POS: only one of them applies to a line, they do not add up);
///   free goods      buy so many of an item and get so many free: a separate line of the same item at the full discount, so stock moves and the tax is on nothing;
///   bill offer      money off a bill whose items come to an amount between two limits (the cashier may choose not to use it);
///   coupon          money off, made by the shop for a customer, used once;
///   gift voucher    given with a bill whose total falls in a range, used once on a later visit.
/// What the Hub does differently from the older POS, on purpose, and why (all tested):
///   - a coupon or voucher is used when the bill is made, in the same step, never when it is only tried (the older POS burned it when the cashier pressed OK, even if the bill was then cancelled);
///   - both the start and the end day are tested, against today (the older gift voucher compared its own two dates, so it never ran out and could be used early);
///   - a cancelled bill gives back the coupon or voucher it used, and switches off the gift voucher it earned if that was not yet used;
///   - free goods are only given when the paid quantity reaches the minimum (the older POS skipped that test when two scans of one item were merged);
///   - when two bill offers fit, the one that takes most off wins (the older POS took the first row the database gave back);
///   - the discount of all offers and codes together never goes above what the bill comes to.
/// A cashier needs no discount right for these: the shop made them.
/// </summary>
public sealed class OffersService(HubDb db, ShopContextProvider shop, IClock clock, AuditService audit, Access access)
{
    private const string CodeLetters = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";   // no 0, O, 1 or I: a code read out over the phone or typed from a screen has fewer mistakes
    private const int CodeLength = 8;
    private const string DateFormat = "yyyy-MM-dd";

    public DateOnly Today => shop.Current.Time.LocalDate(clock.UtcNow);

    // ---- the rules (small, pure, tested with the older POS's worked examples) ------------------------------------------------------------------

    /// <summary>True when the day is inside the window; an empty end means no limit on that side. Both end days count.</summary>
    public static bool InWindow(DateOnly? from, DateOnly? to, DateOnly today) => (from is null || from <= today) && (to is null || today <= to);

    /// <summary>
    /// The percent off for a line from the customer's standing discount and the item offers: the customer's if there is one, else the item offer's, else none. They never add up.
    /// </summary>
    public static (long PctMilli, string? Source) ResolveLineDiscount(long customerPctMilli, long itemOfferPctMilli) =>
        customerPctMilli > 0 ? (customerPctMilli, "customer") : itemOfferPctMilli > 0 ? (itemOfferPctMilli, "offer") : (0, null);

    /// <summary>
    /// The free goods for a line that is bought: when at least the minimum is bought, the free quantity for each full minimum, in whole units (buy 3 get 1: buying 7 gives 2; buying 2 gives
    /// nothing). Quantities are in thousandths.
    /// </summary>
    public static long FreeQtyMilli(long paidMilli, long minMilli, long freeMilli)
    {
        if (minMilli <= 0 || freeMilli <= 0 || paidMilli < minMilli) return 0;
        var units = (BigInteger)freeMilli * paidMilli / minMilli;
        return (long)(units / 1000 * 1000);
    }

    /// <summary>The code with only letters and digits, in capitals: "abcd-2345" is "ABCD2345".</summary>
    public static string Normalize(string? text) => new string((text ?? "").Where(char.IsLetterOrDigit).ToArray()).ToUpperInvariant();

    /// <summary>
    /// The words to print for a gift voucher a bill earned, from the shop's own wording ({code}, {amount} and {valid} are filled in; {valid} is "from 1 Oct 2026 until 31 Oct 2026", "until ...",
    /// "from ..." or "any day").
    /// </summary>
    public static string GiftText(string template, Voucher voucher, Func<long, string> money)
    {
        var valid = voucher.ValidFrom is { } from && voucher.ValidTo is { } to ? $"from {Day(from)} until {Day(to)}"
            : voucher.ValidTo is { } until ? $"until {Day(until)}" : voucher.ValidFrom is { } start ? $"from {Day(start)}" : "any day";
        return template.Replace("{code}", voucher.Pretty).Replace("{amount}", money(voucher.AmountMinor)).Replace("{valid}", valid);
    }

    /// <summary>True when the shop has made any coupon or voucher that can still be used (so the till shows a place to type a code).</summary>
    public bool AnyUnusedVouchers => db.Scalar("SELECT 1 FROM vouchers WHERE used_at IS NULL AND enabled = 1 LIMIT 1") is not null;

    /// <summary>"ABCD-2345": a code in two halves, easier to read and type.</summary>
    public static string Pretty(string code) => code.Length == CodeLength ? code[..4] + "-" + code[4..] : code;

    /// <summary>
    /// Why a code cannot be used today, or null when it can. The older POS tested in this order and said the first thing that failed: ran out, already used, switched off. A start day
    /// that is still to come is new here (the older POS did not look at it).
    /// </summary>
    public static string? Problem(Voucher v, DateOnly today) =>
        v.ValidTo is { } to && to < today ? "expired" : v.Used ? "used" : !v.Enabled ? "off" : v.ValidFrom is { } from && from > today ? "waiting" : null;

    private string Say(Voucher v, string problem) => problem switch
    {
        "expired" => $"That {v.Noun} ran out on {Day(v.ValidTo!.Value)}.",
        "used" => $"That {v.Noun} was already used.",
        "off" => $"That {v.Noun} has been switched off.",
        _ => $"That {v.Noun} can be used from {Day(v.ValidFrom!.Value)}.",
    };

    private static string Day(DateOnly d) => d.ToString("d MMM yyyy", CultureInfo.InvariantCulture);

    private static string? Store(DateOnly? d) => d?.ToString(DateFormat, CultureInfo.InvariantCulture);

    private static DateOnly? Read(string? text) => string.IsNullOrEmpty(text) ? null : DateOnly.ParseExact(text, DateFormat, CultureInfo.InvariantCulture);

    // ---- the shop's rules ------------------------------------------------------------------------------------------------------------------

    private const string OfferColumns = "o.id, o.kind, o.name, o.item_id, i.name AS item_name, o.amount_from_minor, o.amount_to_minor, o.amount_minor, o.pct_milli, o.min_qty_milli, o.free_qty_milli, o.valid_from, o.valid_to, o.enabled";
    private const string OfferFrom = "FROM offers o LEFT JOIN items i ON i.id = o.item_id";

    private static Offer MapOffer(SqliteDataReader r) => new(
        r.Int("id"), r.Text("kind"), r.TextOrNull("name"), r.IntOrNull("item_id"), r.TextOrNull("item_name"), r.IntOrNull("amount_from_minor"), r.IntOrNull("amount_to_minor"),
        r.Int("amount_minor"), r.Int("pct_milli"), r.Int("min_qty_milli"), r.Int("free_qty_milli"), Read(r.TextOrNull("valid_from")), Read(r.TextOrNull("valid_to")), r.Flag("enabled"));

    public IReadOnlyList<Offer> Offers(string? kind = null) =>
        db.Query($"SELECT {OfferColumns} {OfferFrom} WHERE ($k IS NULL OR o.kind = $k) ORDER BY o.kind, o.enabled DESC, o.id DESC", MapOffer, ("$k", kind));

    public Offer? GetOffer(long id) => db.QueryOne($"SELECT {OfferColumns} {OfferFrom} WHERE o.id = $id", MapOffer, ("$id", id));

    /// <summary>Adds a rule, or changes the one named by the id. Refused, in plain words, when it does not make sense.</summary>
    public Offer SaveOffer(OfferInput input, long? userId = null)
    {
        access.Require(Perm.Discount);
        if (!OfferKinds.All.Contains(input.Kind)) throw new HubException("offer-kind", "That kind of offer does not exist.");
        if (input.ValidFrom is { } f && input.ValidTo is { } to && to < f) throw new HubException("offer-dates", "The last day cannot be before the first day.");
        var name = string.IsNullOrWhiteSpace(input.Name) ? null : input.Name.Trim();
        if (name is { Length: > 80 }) throw new HubException("offer-name", "That name is too long.");
        long? low = null, high = null; long amount = 0, pct = 0, min = 0, free = 0; long? item = null;
        switch (input.Kind)
        {
            case OfferKinds.BillRange or OfferKinds.GiftRule:
                if (input.FromMinor < 0) throw new HubException("offer-range", "A bill cannot come to less than nothing.");
                if (input.ToMinor is { } t0 && t0 < input.FromMinor) throw new HubException("offer-range", "The top of the range cannot be less than the bottom.");
                if (input.AmountMinor <= 0) throw new HubException("offer-amount", input.Kind == OfferKinds.GiftRule ? "Please enter what the voucher is worth." : "Please enter how much comes off.");
                low = input.FromMinor; high = input.ToMinor; amount = input.AmountMinor;
                break;
            case OfferKinds.ItemPercent:
                if (input.ItemId is null) throw new HubException("offer-item", "Choose the item.");
                if (input.PctMilli is <= 0 or > 100_000) throw new HubException("offer-percent", "The percent must be above 0 and at most 100.");
                item = input.ItemId; pct = input.PctMilli;
                break;
            case OfferKinds.BuyGet:
                if (input.ItemId is null) throw new HubException("offer-item", "Choose the item.");
                if (input.MinQtyMilli <= 0) throw new HubException("offer-quantity", "Say how many must be bought.");
                if (input.FreeQtyMilli <= 0) throw new HubException("offer-quantity", "Say how many come free.");
                item = input.ItemId; min = input.MinQtyMilli; free = input.FreeQtyMilli;
                break;
        }
        return db.InTransaction((c, t) =>
        {
            string? itemName = null;
            if (item is { } iid)
            {
                itemName = HubDb.Scalar(c, "SELECT name FROM items WHERE id = $i", t, ("$i", iid)) as string ?? throw new HubException("offer-item", "That item was not found.");
                // One free-goods offer at a time for an item that is still running (the older POS refused a second while one was active or not yet over).
                if (input.Kind == OfferKinds.BuyGet && input.Enabled
                    && HubDb.Scalar(c, "SELECT 1 FROM offers WHERE kind = 'buy-get' AND item_id = $i AND enabled = 1 AND id <> $id AND (valid_to IS NULL OR valid_to >= $today) LIMIT 1", t,
                        ("$i", iid), ("$id", input.Id ?? 0), ("$today", Store(Today))) is not null)
                    throw new HubException("offer-twice", $"{itemName} already has a free-goods offer that is running. Switch that one off first.");
            }
            long id;
            if (input.Id is { } existing)
            {
                var kindNow = HubDb.Scalar(c, "SELECT kind FROM offers WHERE id = $id", t, ("$id", existing)) as string ?? throw new HubException("not-found", "That offer was not found.");
                if (kindNow != input.Kind) throw new HubException("offer-kind", "An offer cannot change its kind. Make a new one.");
                HubDb.Exec(c,
                    "UPDATE offers SET name=$n, item_id=$item, amount_from_minor=$from, amount_to_minor=$to, amount_minor=$a, pct_milli=$p, min_qty_milli=$min, free_qty_milli=$free, valid_from=$vf, valid_to=$vt, enabled=$e WHERE id=$id", t,
                    ("$n", name), ("$item", item), ("$from", low), ("$to", high), ("$a", amount), ("$p", pct), ("$min", min), ("$free", free), ("$vf", Store(input.ValidFrom)), ("$vt", Store(input.ValidTo)),
                    ("$e", input.Enabled ? 1 : 0), ("$id", existing));
                id = existing;
            }
            else
            {
                id = HubDb.Insert(c,
                    "INSERT INTO offers(kind, name, item_id, amount_from_minor, amount_to_minor, amount_minor, pct_milli, min_qty_milli, free_qty_milli, valid_from, valid_to, enabled, created_at) " +
                    "VALUES ($k, $n, $item, $from, $to, $a, $p, $min, $free, $vf, $vt, $e, $at)", t,
                    ("$k", input.Kind), ("$n", name), ("$item", item), ("$from", low), ("$to", high), ("$a", amount), ("$p", pct), ("$min", min), ("$free", free), ("$vf", Store(input.ValidFrom)),
                    ("$vt", Store(input.ValidTo)), ("$e", input.Enabled ? 1 : 0), ("$at", Iso.Text(clock.UtcNow)));
            }
            audit.Log(c, t, userId, input.Id is null ? "offer-add" : "offer-change", "offer", id, $"{input.Kind} {name ?? itemName}");
            return HubDb.Query(c, $"SELECT {OfferColumns} {OfferFrom} WHERE o.id = $id", MapOffer, t, ("$id", id)).Single();
        });
    }

    public void SetOfferEnabled(long id, bool enabled, long? userId = null)
    {
        access.Require(Perm.Discount);
        db.InTransaction((c, t) =>
        {
            if (HubDb.Exec(c, "UPDATE offers SET enabled = $e WHERE id = $id", t, ("$e", enabled ? 1 : 0), ("$id", id)) == 0) throw new HubException("not-found", "That offer was not found.");
            audit.Log(c, t, userId, enabled ? "offer-on" : "offer-off", "offer", id, null);
        });
    }

    /// <summary>Takes a rule away. Bills already made keep what it gave them.</summary>
    public void DeleteOffer(long id, long? userId = null)
    {
        access.Require(Perm.Discount);
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "DELETE FROM offers WHERE id = $id", t, ("$id", id));
            audit.Log(c, t, userId, "offer-delete", "offer", id, null);
        });
    }

    // ---- a customer's standing discount ------------------------------------------------------------------------------------------------------

    public (long PctMilli, bool Enabled) PartyDiscount(long partyId)
    {
        var rows = db.Query("SELECT pct_milli, enabled FROM party_discounts WHERE party_id = $p", r => (Pct: r.Int("pct_milli"), On: r.Flag("enabled")), ("$p", partyId));
        return rows.Count == 0 || rows[0].Pct <= 0 ? (0, false) : (rows[0].Pct, rows[0].On);
    }

    /// <summary>Sets the percent a customer is always given off an item (0 takes it away). It can be switched off without losing the percent.</summary>
    public void SetPartyDiscount(long partyId, long pctMilli, bool enabled, long? userId = null)
    {
        access.Require(Perm.Discount);
        if (pctMilli is < 0 or > 100_000) throw new HubException("discount", "A discount must be between 0 and 100 percent.");
        db.InTransaction((c, t) => SetPartyDiscount(c, t, partyId, pctMilli, enabled, userId));
    }

    /// <summary>The same inside a bigger step (such as moving a shop across from an older system).</summary>
    public void SetPartyDiscount(SqliteConnection c, SqliteTransaction t, long partyId, long pctMilli, bool enabled, long? userId)
    {
        if (pctMilli is < 0 or > 100_000) throw new HubException("discount", "A discount must be between 0 and 100 percent.");
        if (HubDb.Scalar(c, "SELECT 1 FROM parties WHERE id = $p", t, ("$p", partyId)) is null) throw new HubException("party-not-found", "That customer was not found.");
        if (pctMilli == 0) HubDb.Exec(c, "DELETE FROM party_discounts WHERE party_id = $p", t, ("$p", partyId));
        else HubDb.Exec(c, "INSERT INTO party_discounts(party_id, pct_milli, enabled) VALUES ($p, $v, $e) ON CONFLICT(tenant_id, site_id, party_id) DO UPDATE SET pct_milli = $v, enabled = $e", t,
            ("$p", partyId), ("$v", pctMilli), ("$e", enabled ? 1 : 0));
        audit.Log(c, t, userId, "customer-discount", "party", partyId, pctMilli == 0 ? "removed" : $"{pctMilli / 1000m:0.###}% {(enabled ? "on" : "off")}");
    }

    // ---- coupons and gift vouchers ---------------------------------------------------------------------------------------------------------

    private const string VoucherColumns = "v.id, v.kind, v.code, v.amount_minor, v.party_id, p.name AS party_name, v.valid_from, v.valid_to, v.enabled, v.issued_at, v.issued_document_id, v.used_at, v.used_document_id";
    private const string VoucherFrom = "FROM vouchers v LEFT JOIN parties p ON p.id = v.party_id";

    private static Voucher MapVoucher(SqliteDataReader r) => new(
        r.Int("id"), r.Text("kind"), r.Text("code"), r.Int("amount_minor"), r.IntOrNull("party_id"), r.TextOrNull("party_name"), Read(r.TextOrNull("valid_from")), Read(r.TextOrNull("valid_to")),
        r.Flag("enabled"), r.Time("issued_at"), r.IntOrNull("issued_document_id"), r.TimeOrNull("used_at"), r.IntOrNull("used_document_id"));

    public IReadOnlyList<Voucher> Vouchers(string? kind = null, string? text = null, int limit = 200)
    {
        var like = "%" + Normalize(text) + "%";
        var nameLike = "%" + (text ?? "").Trim().Replace("%", "\\%").Replace("_", "\\_") + "%";
        return db.Query(
            $"SELECT {VoucherColumns} {VoucherFrom} WHERE ($k IS NULL OR v.kind = $k) AND ($t = '' OR v.code LIKE $like OR p.name LIKE $nl ESCAPE '\\') ORDER BY v.id DESC LIMIT $limit", MapVoucher,
            ("$k", kind), ("$t", (text ?? "").Trim()), ("$like", like), ("$nl", nameLike), ("$limit", limit));
    }

    public Voucher? FindByCode(string code) => db.QueryOne($"SELECT {VoucherColumns} {VoucherFrom} WHERE v.code = $c", MapVoucher, ("$c", Normalize(code)));

    private static Voucher? FindByCode(SqliteConnection c, SqliteTransaction t, string code) =>
        HubDb.Query(c, $"SELECT {VoucherColumns} {VoucherFrom} WHERE v.code = $c", MapVoucher, t, ("$c", Normalize(code))).FirstOrDefault();

    /// <summary>
    /// Makes one coupon for each customer chosen, each with its own code, for the same amount and days (an empty day means no limit). Nothing leaves the shop: the shop gives the code to
    /// the customer in whatever way it likes.
    /// </summary>
    public IReadOnlyList<Voucher> GenerateCoupons(IReadOnlyList<long> partyIds, long amountMinor, DateOnly? from, DateOnly? to, bool enabled = true, long? userId = null)
    {
        access.Require(Perm.Discount);
        if (amountMinor <= 0) throw new HubException("coupon-amount", "Please enter the amount of the coupon.");
        if (partyIds.Count == 0) throw new HubException("coupon-customers", "Choose at least one customer.");
        if (from is { } f && to is { } e && e < f) throw new HubException("coupon-dates", "The last day cannot be before the first day.");
        return db.InTransaction((c, t) =>
        {
            var made = new List<long>();
            foreach (var partyId in partyIds.Distinct())
            {
                if (HubDb.Scalar(c, "SELECT 1 FROM parties WHERE id = $p", t, ("$p", partyId)) is null) throw new HubException("party-not-found", "That customer was not found.");
                made.Add(Issue(c, t, "coupon", amountMinor, partyId, from, to, enabled, null, userId));
            }
            audit.Log(c, t, userId, "coupons-made", "voucher", made[0], $"{made.Count} coupon(s) of {shop.Current.Money(amountMinor)}");
            return made.Select(id => HubDb.Query(c, $"SELECT {VoucherColumns} {VoucherFrom} WHERE v.id = $id", MapVoucher, t, ("$id", id)).Single()).ToList();
        });
    }

    private long Issue(SqliteConnection c, SqliteTransaction t, string kind, long amountMinor, long? partyId, DateOnly? from, DateOnly? to, bool enabled, long? documentId, long? userId)
    {
        for (var attempt = 0; attempt < 20; attempt++)
        {
            var code = NewCode();
            if (HubDb.Scalar(c, "SELECT 1 FROM vouchers WHERE code = $c", t, ("$c", code)) is not null) continue;
            return HubDb.Insert(c,
                "INSERT INTO vouchers(kind, code, amount_minor, party_id, valid_from, valid_to, enabled, issued_at, issued_document_id, issued_by) VALUES ($k, $c, $a, $p, $vf, $vt, $e, $at, $d, $u)", t,
                ("$k", kind), ("$c", code), ("$a", amountMinor), ("$p", partyId), ("$vf", Store(from)), ("$vt", Store(to)), ("$e", enabled ? 1 : 0), ("$at", Iso.Text(clock.UtcNow)), ("$d", documentId), ("$u", userId));
        }
        throw new HubException("code", "A new code could not be made. Please try again.");
    }

    /// <summary>A code drawn at random (from the system's secure generator), so one cannot be guessed from another.</summary>
    private static string NewCode()
    {
        var chars = new char[CodeLength];
        for (var i = 0; i < chars.Length; i++) chars[i] = CodeLetters[RandomNumberGenerator.GetInt32(CodeLetters.Length)];
        return new string(chars);
    }

    /// <summary>Switches a coupon or voucher off (or back on). One that was used cannot be changed.</summary>
    public void SetVoucherEnabled(long id, bool enabled, long? userId = null)
    {
        access.Require(Perm.Discount);
        db.InTransaction((c, t) =>
        {
            var row = HubDb.Query(c, "SELECT used_at FROM vouchers WHERE id = $id", r => r.TextOrNull("used_at"), t, ("$id", id));
            if (row.Count == 0) throw new HubException("not-found", "That code was not found.");
            if (row[0] is not null) throw new HubException("voucher-used", "That code was already used and cannot be changed.");
            HubDb.Exec(c, "UPDATE vouchers SET enabled = $e WHERE id = $id", t, ("$e", enabled ? 1 : 0), ("$id", id));
            audit.Log(c, t, userId, enabled ? "voucher-on" : "voucher-off", "voucher", id, null);
        });
    }

    // ---- on a bill that is being made --------------------------------------------------------------------------------------------------------

    private sealed record Bill(string Type, string Status, string Direction, long? PartyId, bool Declined, long TotalMinor, string? Number);

    private static Bill? LoadBill(SqliteConnection c, SqliteTransaction t, long documentId) => HubDb.Query(c,
        "SELECT type, status, direction, party_id, offer_declined, total_minor, number FROM documents WHERE id = $id",
        r => new Bill(r.Text("type"), r.Text("status"), r.Text("direction"), r.IntOrNull("party_id"), r.Flag("offer_declined"), r.Int("total_minor"), r.TextOrNull("number")), t, ("$id", documentId)).FirstOrDefault();

    private static bool IsSale(Bill bill) => bill.Direction == "out" && bill.Type is DocTypes.Invoice or DocTypes.Order or DocTypes.Quote;

    /// <summary>The percent off a new line of an item for a customer: the customer's standing discount, else the best item offer running today, else none.</summary>
    internal (long PctMilli, string? Source) AutoLineDiscount(SqliteConnection c, SqliteTransaction t, long itemId, long? partyId)
    {
        long customer = 0;
        if (partyId is { } p) customer = Convert.ToInt64(HubDb.Scalar(c, "SELECT CASE WHEN enabled = 1 THEN pct_milli ELSE 0 END FROM party_discounts WHERE party_id = $p", t, ("$p", p)) ?? 0L);
        var day = Store(Today);
        var offer = Convert.ToInt64(HubDb.Scalar(c,
            "SELECT COALESCE(MAX(pct_milli), 0) FROM offers WHERE kind = 'item-percent' AND item_id = $i AND enabled = 1 AND (valid_from IS NULL OR valid_from <= $d) AND (valid_to IS NULL OR valid_to >= $d)", t,
            ("$i", itemId), ("$d", day)) ?? 0L);
        return ResolveLineDiscount(customer, offer);
    }

    /// <summary>
    /// The customer of a bill changed (or was chosen after the lines were added): lines whose discount was not typed by a person are worked out again for the new customer. A line with a discount
    /// someone typed is left as it is.
    /// </summary>
    internal void ReapplyLineDiscounts(SqliteConnection c, SqliteTransaction t, long documentId, long? partyId)
    {
        var bill = LoadBill(c, t, documentId);
        if (bill is null || !IsSale(bill)) return;
        var lines = HubDb.Query(c,
            "SELECT id, item_id FROM document_lines WHERE document_id = $d AND item_id IS NOT NULL AND free_for_line_id IS NULL AND ref_line_id IS NULL " +
            "AND (discount_source IN ('customer', 'offer') OR (discount_pct_milli = 0 AND discount_amount_minor = 0))", r => (Id: r.Int("id"), Item: r.Int("item_id")), t, ("$d", documentId));
        foreach (var (id, item) in lines)
        {
            var (pct, source) = AutoLineDiscount(c, t, item, partyId);
            HubDb.Exec(c, "UPDATE document_lines SET discount_pct_milli = $p, discount_amount_minor = 0, discount_source = $s WHERE id = $id", t, ("$p", pct), ("$s", source), ("$id", id));
        }
    }

    private sealed record LineRow(long Id, long? ItemId, string Description, long Qty, string? Unit, long Price, string TaxCode, string? Station, long? FreeFor, long DiscountPct, long DiscountAmount, string? ItemCode, long ExtraTaxPct);

    /// <summary>
    /// Brings everything that offers add to an open sale up to date after its lines changed: the free goods, the bill offer, the codes on it. It does nothing for a document that is not a sale
    /// that is still being made. Called by the document service every time the amounts are worked out.
    /// </summary>
    internal void Refresh(SqliteConnection c, SqliteTransaction t, long documentId)
    {
        var bill = LoadBill(c, t, documentId);
        if (bill is null || bill.Status != DocStatus.Open || !IsSale(bill)) return;
        var today = Today;
        SyncFreeLines(c, t, documentId, today);

        var rows = HubDb.Query(c, "SELECT qty_milli, unit_price_minor, discount_pct_milli, discount_amount_minor FROM document_lines WHERE document_id = $d", r => (Q: r.Int("qty_milli"), P: r.Int("unit_price_minor"), Pct: r.Int("discount_pct_milli"), Amt: r.Int("discount_amount_minor")), t, ("$d", documentId));
        var baseMinor = rows.Sum(l => DocumentService.NetOf(l.Q, l.P, l.Pct, l.Amt));

        // the bill offer: of the rules that fit, the one that takes most off
        HubDb.Exec(c, "DELETE FROM document_offers WHERE document_id = $d AND kind = 'bill-offer'", t, ("$d", documentId));
        if (bill.Type == DocTypes.Quote) HubDb.Exec(c, "DELETE FROM document_offers WHERE document_id = $d AND kind IN ('coupon', 'gift')", t, ("$d", documentId));   // a quote uses nothing up
        var rules = baseMinor <= 0 ? new List<Offer>() : HubDb.Query(c,
            $"SELECT {OfferColumns} {OfferFrom} WHERE o.kind = 'bill-range' AND o.enabled = 1 AND o.amount_from_minor <= $b AND (o.amount_to_minor IS NULL OR o.amount_to_minor >= $b) " +
            "AND (o.valid_from IS NULL OR o.valid_from <= $d) AND (o.valid_to IS NULL OR o.valid_to >= $d) ORDER BY o.amount_minor DESC, o.id", MapOffer, t, ("$b", baseMinor), ("$d", Store(today)));
        if (rules.FirstOrDefault() is { } best)
            HubDb.Exec(c, "INSERT INTO document_offers(document_id, kind, offer_id, label, amount_minor) VALUES ($d, 'bill-offer', $o, $l, $a)", t,
                ("$d", documentId), ("$o", best.Id), ("$l", string.IsNullOrWhiteSpace(best.Name) ? "Offer" : best.Name), ("$a", Math.Min(best.AmountMinor, baseMinor)));

        var total = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(SUM(amount_minor), 0) FROM document_offers WHERE document_id = $d AND ($x = 0 OR kind <> 'bill-offer')", t, ("$d", documentId), ("$x", bill.Declined ? 1 : 0)) ?? 0L);
        HubDb.Exec(c, "UPDATE documents SET offer_discount_minor = $t WHERE id = $d", t, ("$t", total), ("$d", documentId));
    }

    /// <summary>Buy so many get so many free: keeps one free line for each bought line that earns it, and none for a line that does not (any more).</summary>
    private void SyncFreeLines(SqliteConnection c, SqliteTransaction t, long documentId, DateOnly today)
    {
        var rows = HubDb.Query(c,
            "SELECT id, item_id, description, qty_milli, unit, unit_price_minor, tax_code, station, free_for_line_id, discount_pct_milli, discount_amount_minor, item_code, extra_tax_pct_milli FROM document_lines WHERE document_id = $d ORDER BY line_no",
            r => new LineRow(r.Int("id"), r.IntOrNull("item_id"), r.Text("description"), r.Int("qty_milli"), r.TextOrNull("unit"), r.Int("unit_price_minor"), r.Text("tax_code"), r.TextOrNull("station"),
                r.IntOrNull("free_for_line_id"), r.Int("discount_pct_milli"), r.Int("discount_amount_minor"), r.TextOrNull("item_code"), r.Int("extra_tax_pct_milli")), t, ("$d", documentId));
        var bought = rows.Where(r => r.FreeFor is null).ToList();
        var free = rows.Where(r => r.FreeFor is not null).ToList();
        foreach (var orphan in free.Where(f => bought.All(b => b.Id != f.FreeFor)))
            HubDb.Exec(c, "DELETE FROM document_lines WHERE id = $id", t, ("$id", orphan.Id));
        var live = HubDb.Query(c,
            $"SELECT {OfferColumns} {OfferFrom} WHERE o.kind = 'buy-get' AND o.enabled = 1 AND (o.valid_from IS NULL OR o.valid_from <= $d) AND (o.valid_to IS NULL OR o.valid_to >= $d)", MapOffer, t, ("$d", Store(today)))
            .Where(o => o.ItemId is not null).GroupBy(o => o.ItemId!.Value).ToDictionary(g => g.Key, g => g.OrderByDescending(o => o.FreeQtyMilli).First());
        if (live.Count == 0 && free.Count == 0) return;
        foreach (var line in bought)
        {
            var want = line.ItemId is { } item && live.TryGetValue(item, out var offer) ? FreeQtyMilli(line.Qty, offer.MinQtyMilli, offer.FreeQtyMilli) : 0;
            var have = free.FirstOrDefault(f => f.FreeFor == line.Id);
            if (want == 0)
            {
                if (have is not null) HubDb.Exec(c, "DELETE FROM document_lines WHERE id = $id", t, ("$id", have.Id));
            }
            else if (have is null)
            {
                var lineNo = Convert.ToInt32(HubDb.Scalar(c, "SELECT COALESCE(MAX(line_no), 0) + 1 FROM document_lines WHERE document_id = $d", t, ("$d", documentId)) ?? 1);
                HubDb.Exec(c,
                    "INSERT INTO document_lines(document_id, line_no, item_id, description, qty_milli, unit, unit_price_minor, discount_pct_milli, discount_amount_minor, tax_code, station, discount_source, free_for_line_id, item_code, extra_tax_pct_milli) " +
                    "VALUES ($d, $n, $item, $desc, $q, $unit, $price, 100000, 0, $tax, $station, 'offer', $for, $icode, $extra)", t,
                    ("$d", documentId), ("$n", lineNo), ("$item", line.ItemId), ("$desc", line.Description), ("$q", want), ("$unit", line.Unit), ("$price", line.Price), ("$tax", line.TaxCode), ("$station", line.Station), ("$for", line.Id),
                    ("$icode", line.ItemCode), ("$extra", line.ExtraTaxPct));
            }
            else if (have.Qty != want || have.Price != line.Price || have.TaxCode != line.TaxCode)
                HubDb.Exec(c, "UPDATE document_lines SET qty_milli = $q, unit_price_minor = $p, tax_code = $tax WHERE id = $id", t, ("$q", want), ("$p", line.Price), ("$tax", line.TaxCode), ("$id", have.Id));
        }
    }

    /// <summary>Puts a coupon or gift voucher on an open sale. It is not used up until the bill is made.</summary>
    internal void AttachCode(SqliteConnection c, SqliteTransaction t, long documentId, string codeText)
    {
        var bill = LoadBill(c, t, documentId) ?? throw new HubException("not-found", "That sale was not found.");
        if (bill.Status != DocStatus.Open || bill.Direction != "out" || bill.Type is not (DocTypes.Invoice or DocTypes.Order))
            throw new HubException("voucher-where", "Coupons and gift vouchers are used on a sale that is being made, not on a quote or a finished bill.");
        var code = Normalize(codeText);
        if (code.Length == 0) throw new HubException("voucher-code", "Please type the code.");
        var voucher = FindByCode(c, t, code) ?? throw new HubException("voucher-not-found", "That code was not found.");
        if (Problem(voucher, Today) is { } problem) throw new HubException("voucher-" + problem, Say(voucher, problem));
        if (HubDb.Scalar(c, "SELECT 1 FROM document_offers WHERE document_id = $d AND voucher_id = $v", t, ("$d", documentId), ("$v", voucher.Id)) is not null)
            throw new HubException("voucher-twice", "That code is already on this sale.");
        HubDb.Exec(c, "INSERT INTO document_offers(document_id, kind, voucher_id, label, amount_minor) VALUES ($d, $k, $v, $l, $a)", t,
            ("$d", documentId), ("$k", voucher.Kind), ("$v", voucher.Id), ("$l", $"{(voucher.Kind == "gift" ? "Gift voucher" : "Coupon")} {voucher.Pretty}"), ("$a", voucher.AmountMinor));
    }

    internal void DetachCode(SqliteConnection c, SqliteTransaction t, long documentId, long voucherId) =>
        HubDb.Exec(c, "DELETE FROM document_offers WHERE document_id = $d AND voucher_id = $v", t, ("$d", documentId), ("$v", voucherId));

    internal void SetDeclined(SqliteConnection c, SqliteTransaction t, long documentId, bool declined) =>
        HubDb.Exec(c, "UPDATE documents SET offer_declined = $x WHERE id = $d", t, ("$x", declined ? 1 : 0), ("$d", documentId));

    /// <summary>What offers and codes did to a bill, and the gift voucher the bill earned (if any).</summary>
    public DocumentOffers ForDocument(long documentId)
    {
        var declined = Convert.ToInt64(db.Scalar("SELECT offer_declined FROM documents WHERE id = $d", ("$d", documentId)) ?? 0L) != 0;
        var rows = db.Query("SELECT id, kind, voucher_id, label, amount_minor FROM document_offers WHERE document_id = $d ORDER BY id",
            r => new AppliedOffer(r.Int("id"), r.Text("kind"), r.IntOrNull("voucher_id"), r.Text("label"), r.Int("amount_minor")), ("$d", documentId));
        var applied = rows.Where(r => !(declined && r.Kind == "bill-offer")).ToList();
        var skipped = rows.FirstOrDefault(r => declined && r.Kind == "bill-offer");
        var earned = db.Query($"SELECT {VoucherColumns} {VoucherFrom} WHERE v.issued_document_id = $d AND v.kind = 'gift' ORDER BY v.id", MapVoucher, ("$d", documentId));
        return new DocumentOffers(applied, skipped, applied.Sum(a => a.AmountMinor), earned);
    }

    // ---- when the bill is made or cancelled ------------------------------------------------------------------------------------------------

    /// <summary>
    /// The bill has just been made (inside the same step): the coupons and vouchers on it are used up, each only if it is still good (a code used on another till in the meantime stops this
    /// bill, and nothing is saved), and a bill to a named customer that falls in a voucher rule earns a gift voucher.
    /// </summary>
    internal void OnIssued(SqliteConnection c, SqliteTransaction t, long documentId, long? userId)
    {
        var bill = LoadBill(c, t, documentId);
        if (bill is null || bill.Direction != "out" || bill.Type is not (DocTypes.Invoice or DocTypes.Quote)) return;
        var today = Today;
        var now = clock.UtcNow;
        foreach (var voucherId in HubDb.Query(c, "SELECT voucher_id FROM document_offers WHERE document_id = $d AND voucher_id IS NOT NULL", r => r.Int("voucher_id"), t, ("$d", documentId)))
        {
            var voucher = HubDb.Query(c, $"SELECT {VoucherColumns} {VoucherFrom} WHERE v.id = $id", MapVoucher, t, ("$id", voucherId)).Single();
            if (Problem(voucher, today) is { } problem) throw new HubException("voucher-" + problem, Say(voucher, problem));
            if (HubDb.Exec(c, "UPDATE vouchers SET used_at = $at, used_document_id = $d WHERE id = $id AND used_at IS NULL AND enabled = 1", t, ("$at", Iso.Text(now)), ("$d", documentId), ("$id", voucherId)) != 1)
                throw new HubException("voucher-used", $"That {voucher.Noun} was already used.");
            audit.Log(c, t, userId, "voucher-used", "voucher", voucherId, $"{voucher.Pretty} on {bill.Number}");
        }
        if (bill.Declined) HubDb.Exec(c, "DELETE FROM document_offers WHERE document_id = $d AND kind = 'bill-offer'", t, ("$d", documentId));
        if (bill.Type != DocTypes.Invoice || bill.PartyId is not { } party) return;
        var rule = HubDb.Query(c,
            $"SELECT {OfferColumns} {OfferFrom} WHERE o.kind = 'gift-rule' AND o.enabled = 1 AND o.amount_from_minor <= $b AND (o.amount_to_minor IS NULL OR o.amount_to_minor >= $b) " +
            "AND (o.valid_from IS NULL OR o.valid_from <= $d) AND (o.valid_to IS NULL OR o.valid_to >= $d) ORDER BY o.amount_minor DESC, o.id LIMIT 1", MapOffer, t, ("$b", bill.TotalMinor), ("$d", Store(today))).FirstOrDefault();
        if (rule is null) return;
        var id = Issue(c, t, "gift", rule.AmountMinor, party, rule.ValidFrom, rule.ValidTo, true, documentId, userId);
        audit.Log(c, t, userId, "voucher-earned", "voucher", id, $"gift voucher of {shop.Current.Money(rule.AmountMinor)} with {bill.Number}");
    }

    /// <summary>
    /// A bill was cancelled: the coupons and vouchers it used can be used again (the customer did not get the discount), and the gift voucher it earned is switched off if nobody used it yet
    /// (one that was already used stays: it cannot be taken back).
    /// </summary>
    internal void OnVoid(SqliteConnection c, SqliteTransaction t, long documentId, long? userId)
    {
        var freed = HubDb.Exec(c, "UPDATE vouchers SET used_at = NULL, used_document_id = NULL WHERE used_document_id = $d", t, ("$d", documentId));
        var switchedOff = HubDb.Exec(c, "UPDATE vouchers SET enabled = 0 WHERE issued_document_id = $d AND kind = 'gift' AND used_at IS NULL AND enabled = 1", t, ("$d", documentId));
        if (freed + switchedOff > 0) audit.Log(c, t, userId, "voucher-void", "document", documentId, $"{freed} code(s) given back, {switchedOff} gift voucher(s) switched off");
    }
}
