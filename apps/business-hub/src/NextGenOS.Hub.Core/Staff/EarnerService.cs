using System.Globalization;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Books;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;
using NextGenOS.Tax;
using NewtonJson = Newtonsoft.Json.JsonConvert;

namespace NextGenOS.Hub.Staff;

public static class EarnerKinds
{
    /// <summary>A person on the shop's side who sells: earns a percent of the bills they are named on.</summary>
    public const string Salesperson = "salesperson";
    /// <summary>A go-between outside the shop: earns a percent (or an amount) typed for each bill.</summary>
    public const string Broker = "broker";
}

public sealed record Earner(long Id, string Kind, string Name, string? Phone, string? Email, string? Address, long PctMilli, bool Active, string? Notes);

public sealed class EarnerInput
{
    public long? Id { get; set; }
    public string Kind { get; set; } = EarnerKinds.Salesperson;
    public string Name { get; set; } = "";
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    /// <summary>The usual commission, in thousandths of a percent (2500 = 2.5%). For a salesperson it is what each bill uses; for a broker it is only the approved rate shown when one is chosen.</summary>
    public long PctMilli { get; set; }
    public string? Notes { get; set; }
}

/// <summary>Who is named on a bill, and how their commission is worked out.</summary>
public sealed record BillEarner(long EarnerId, string Name, string Kind, string Basis, long? PctMilli, long? AmountMinor);

/// <summary>One line of what the shop owes a person. <see cref="AmountMinor"/> is positive when it adds to what is owed, negative when it takes from it.</summary>
public sealed record EarnerLine(long Id, DateTimeOffset At, string Kind, string Memo, long? DocumentId, long AmountMinor, long BalanceMinor);

public sealed record EarnerSummary(long EarnerId, string Name, string Kind, int Bills, long BaseMinor, long EarnedMinor, long ReversedMinor, long PaidMinor, long OwedMinor);

/// <summary>What paying a person did: the figure owed before and after, and whether more was paid than was owed (allowed, with a warning).</summary>
public sealed record EarnerPayment(long LedgerId, long OwedBeforeMinor, long OwedAfterMinor)
{
    public bool Overpaid => OwedAfterMinor < 0;
}

/// <summary>
/// Salespeople and brokers who earn a commission on bills, and what the shop owes them (the older POS, study 03 B1 and B2). The older program had two commission methods that never met and counted
/// them differently by price mode; this has one, and the corrections the study asked for:
/// <list type="bullet">
/// <item>The commission of a salesperson is a percent of the bill's <b>taxable value</b> (after every discount, before tax), so the same goods earn the same commission whether prices include tax or not.
/// A broker's is a percent of the taxable value or of the whole total (the person chooses, as the older program let them), or an amount typed for the bill.</item>
/// <item>Commission is written when the bill becomes final, with what the percent was at that moment; changing the person's percent later changes no bill.</item>
/// <item>Goods brought back take back a share of the commission (the returned part of the bill, not the whole), and a cancelled bill takes back all of it.</item>
/// <item>One account for each person (what the shop owes them), with the money paid to them against it; paying more than is owed is allowed, with a warning.</item>
/// <item>Everything is written in the books: commission is a cost (&quot;Sales commission&quot;) and a debt (&quot;Commission to pay&quot;) until it is paid.</item>
/// </list>
/// </summary>
public sealed class EarnerService(HubDb db, ShopContextProvider shop, IClock clock, AuditService audit, BooksService books, Access access)
{
    // ---- the people --------------------------------------------------------------------------------------------------------------------

    private const string Columns = "id, kind, name, phone, email, address, pct_milli, active, notes";

    private static Earner Map(SqliteDataReader r) => new(r.Int("id"), r.Text("kind"), r.Text("name"), r.TextOrNull("phone"), r.TextOrNull("email"), r.TextOrNull("address"), r.Int("pct_milli"), r.Flag("active"), r.TextOrNull("notes"));

    private static readonly string[] Pickers = [Perm.Staff, Perm.Sell, Perm.Orders];

    /// <summary>The people, newest names last; a person who was switched off shows only when asked for. A cashier may read the active list (to name a salesperson on a bill), not who is switched off.</summary>
    public IReadOnlyList<Earner> List(string? kind = null, bool includeInactive = false)
    {
        var actor = access.RequireAny(Pickers);
        if (includeInactive && !actor.CanAny([Perm.Staff])) throw new HubException("forbidden", "You are not allowed to do that.");
        return db.Query($"SELECT {Columns} FROM earners WHERE ($k IS NULL OR kind = $k) AND ($all = 1 OR active = 1) ORDER BY name COLLATE NOCASE, id", Map, ("$k", kind), ("$all", includeInactive ? 1 : 0));
    }

    public Earner? Get(long id)
    {
        access.RequireAny(Pickers);
        return db.QueryOne($"SELECT {Columns} FROM earners WHERE id = $id", Map, ("$id", id));
    }

    /// <summary>Adds a person, or changes the one named by the id. A name is needed; the percent is between 0 and 100.</summary>
    public Earner Save(EarnerInput input, long? userId = null)
    {
        access.Require(Perm.Staff);
        if (input.Kind is not (EarnerKinds.Salesperson or EarnerKinds.Broker)) throw new HubException("earner-kind", "A person is a salesperson or a broker.");
        var name = (input.Name ?? "").Trim();
        if (name.Length == 0) throw new HubException("earner-name", "Please give a name.");
        if (name.Length > 120) throw new HubException("earner-name", "That name is too long.");
        if (input.PctMilli is < 0 or > 100_000) throw new HubException("earner-percent", "The commission percent must be between 0 and 100.");
        var phone = Blank(input.Phone);
        return db.InTransaction((c, t) =>
        {
            if (phone is not null && HubDb.Scalar(c, "SELECT 1 FROM earners WHERE kind = $k AND phone = $p AND id <> $id", t, ("$k", input.Kind), ("$p", phone), ("$id", input.Id ?? 0)) is not null)
                throw new HubException("earner-phone", "Another " + (input.Kind == EarnerKinds.Broker ? "broker" : "salesperson") + " has that phone number.");
            long id;
            if (input.Id is { } existing)
            {
                var kindNow = HubDb.Scalar(c, "SELECT kind FROM earners WHERE id = $id", t, ("$id", existing)) as string ?? throw new HubException("not-found", "That person was not found.");
                if (kindNow != input.Kind) throw new HubException("earner-kind", "A salesperson cannot become a broker. Add a new person instead.");
                HubDb.Exec(c, "UPDATE earners SET name=$n, phone=$p, email=$e, address=$a, pct_milli=$pct, notes=$notes WHERE id=$id", t,
                    ("$n", name), ("$p", phone), ("$e", Blank(input.Email)), ("$a", Blank(input.Address)), ("$pct", input.PctMilli), ("$notes", Blank(input.Notes)), ("$id", existing));
                id = existing;
            }
            else
            {
                id = HubDb.Insert(c, "INSERT INTO earners(kind, name, phone, email, address, pct_milli, notes, created_at) VALUES ($k, $n, $p, $e, $a, $pct, $notes, $at)", t,
                    ("$k", input.Kind), ("$n", name), ("$p", phone), ("$e", Blank(input.Email)), ("$a", Blank(input.Address)), ("$pct", input.PctMilli), ("$notes", Blank(input.Notes)), ("$at", Iso.Text(clock.UtcNow)));
            }
            audit.Log(c, t, userId, input.Id is null ? "earner-add" : "earner-change", "earner", id, $"{input.Kind} {name}");
            return HubDb.Query(c, $"SELECT {Columns} FROM earners WHERE id = $id", Map, t, ("$id", id)).Single();
        });
    }

    /// <summary>Switches a person off (or on again). Nobody is deleted: what is owed to them and the bills they were named on stay.</summary>
    public void SetActive(long id, bool active, long? userId = null)
    {
        access.Require(Perm.Staff);
        db.InTransaction((c, t) =>
        {
            if (HubDb.Exec(c, "UPDATE earners SET active = $a WHERE id = $id", t, ("$a", active ? 1 : 0), ("$id", id)) == 0) throw new HubException("not-found", "That person was not found.");
            audit.Log(c, t, userId, active ? "earner-on" : "earner-off", "earner", id, null);
        });
    }

    private static string? Blank(string? text) => string.IsNullOrWhiteSpace(text) ? null : text.Trim();

    // ---- naming them on a bill ------------------------------------------------------------------------------------------------------------

    /// <summary>Who is named on a bill, with how their commission will be worked out.</summary>
    public IReadOnlyList<BillEarner> ForBill(long documentId)
    {
        access.RequireAny(Pickers);
        return db.Query("SELECT b.earner_id, e.name, e.kind, b.basis, b.pct_milli, b.amount_minor FROM bill_earners b JOIN earners e ON e.id = b.earner_id WHERE b.document_id = $d ORDER BY e.kind, e.name",
            r => new BillEarner(r.Int("earner_id"), r.Text("name"), r.Text("kind"), r.Text("basis"), r.IntOrNull("pct_milli"), r.IntOrNull("amount_minor")), ("$d", documentId));
    }

    /// <summary>
    /// Names the salesperson of a bill that is still being made (null takes the name off). The percent is the person's usual one at this moment. Only a sale that is open can name anyone.
    /// </summary>
    public void ChooseSalesperson(long documentId, long? earnerId)
    {
        access.RequireAny(Pickers);
        db.InTransaction((c, t) =>
        {
            RequireOpenSale(c, t, documentId);
            HubDb.Exec(c, "DELETE FROM bill_earners WHERE document_id = $d AND earner_id IN (SELECT id FROM earners WHERE kind = 'salesperson')", t, ("$d", documentId));
            if (earnerId is not { } id) return;
            var person = HubDb.Query(c, $"SELECT {Columns} FROM earners WHERE id = $id", Map, t, ("$id", id)).FirstOrDefault() ?? throw new HubException("not-found", "That person was not found.");
            if (person.Kind != EarnerKinds.Salesperson) throw new HubException("earner-kind", $"{person.Name} is a broker, not a salesperson.");
            if (!person.Active) throw new HubException("earner-off", $"{person.Name} is switched off.");
            HubDb.Exec(c, "INSERT INTO bill_earners(document_id, earner_id, basis, pct_milli) VALUES ($d, $e, 'taxable', $p)", t, ("$d", documentId), ("$e", id), ("$p", person.PctMilli));
        });
    }

    /// <summary>
    /// Names the broker of a bill that is still being made, with how the commission is worked out: <paramref name="withTax"/> on the whole total or on the taxable value, and either
    /// <paramref name="pctMilli"/> or <paramref name="amountMinor"/> (one of the two). Null for the broker takes the name off.
    /// </summary>
    public void ChooseBroker(long documentId, long? earnerId, bool withTax = false, long? pctMilli = null, long? amountMinor = null)
    {
        access.RequireAny(Pickers);
        db.InTransaction((c, t) =>
        {
            RequireOpenSale(c, t, documentId);
            HubDb.Exec(c, "DELETE FROM bill_earners WHERE document_id = $d AND earner_id IN (SELECT id FROM earners WHERE kind = 'broker')", t, ("$d", documentId));
            if (earnerId is not { } id) return;
            var person = HubDb.Query(c, $"SELECT {Columns} FROM earners WHERE id = $id", Map, t, ("$id", id)).FirstOrDefault() ?? throw new HubException("not-found", "That person was not found.");
            if (person.Kind != EarnerKinds.Broker) throw new HubException("earner-kind", $"{person.Name} is a salesperson, not a broker.");
            if (!person.Active) throw new HubException("earner-off", $"{person.Name} is switched off.");
            if ((pctMilli is null) == (amountMinor is null)) throw new HubException("broker-how", "Give the broker's commission as a percent or as an amount, not both and not neither.");
            if (pctMilli is < 0 or > 100_000) throw new HubException("earner-percent", "The commission percent must be between 0 and 100.");
            if (amountMinor is < 0) throw new HubException("broker-amount", "An amount cannot be less than nothing.");
            HubDb.Exec(c, "INSERT INTO bill_earners(document_id, earner_id, basis, pct_milli, amount_minor) VALUES ($d, $e, $b, $p, $a)", t,
                ("$d", documentId), ("$e", id), ("$b", withTax ? "total" : "taxable"), ("$p", pctMilli), ("$a", amountMinor));
        });
    }

    private static void RequireOpenSale(SqliteConnection c, SqliteTransaction t, long documentId)
    {
        var doc = HubDb.Query(c, "SELECT status, type, direction FROM documents WHERE id = $id", r => (Status: r.Text("status"), Type: r.Text("type"), Direction: r.Text("direction")), t, ("$id", documentId)).FirstOrDefault();
        if (doc == default) throw new HubException("not-found", "That bill was not found.");
        if (doc.Status != DocStatus.Open) throw new HubException("not-open", "That bill is final and cannot be changed.");
        if (doc.Direction != "out" || doc.Type is not (DocTypes.Invoice or DocTypes.Order or DocTypes.Quote)) throw new HubException("not-a-sale", "Commission is for sales.");
    }

    // ---- when the bill becomes final, is cancelled, or goods come back ------------------------------------------------------------------------------

    private sealed record Bill(string Type, string Direction, string? Number, int Decimals, string? Result, DateTimeOffset At);

    private static Bill? LoadBill(SqliteConnection c, SqliteTransaction t, long id) => HubDb.Query(c,
        "SELECT type, direction, number, currency_decimals, result, COALESCE(issued_at, created_at) AS at FROM documents WHERE id = $id",
        r => new Bill(r.Text("type"), r.Text("direction"), r.TextOrNull("number"), (int)r.Int("currency_decimals"), r.TextOrNull("result"), r.Time("at")), t, ("$id", id)).FirstOrDefault();

    /// <summary>The taxable value and the total of a final bill, in minor units, from the result the tax engine stored with it.</summary>
    private static (long Taxable, long Total) Bases(Bill bill)
    {
        if (bill.Result is null) return (0, 0);
        var result = NewtonJson.DeserializeObject<TaxResult>(bill.Result);
        if (result?.Totals is null) return (0, 0);
        return ((long)MoneyText.Parse(result.Totals.Taxable ?? "0", bill.Decimals), (long)MoneyText.Parse(result.Totals.GrandTotal ?? "0", bill.Decimals));
    }

    /// <summary>amount x numerator / denominator, rounded half up (all three are never negative here).</summary>
    private static long Share(long amount, long numerator, long denominator)
    {
        if (denominator == 0) return 0;
        var product = (System.Numerics.BigInteger)amount * numerator * 2 + denominator;
        return (long)(product / (2 * (System.Numerics.BigInteger)denominator));
    }

    /// <summary>
    /// A sale became final: for each person named on it, one commission entry for the shop owes them (and the cost in the books). Nothing is written for a bill nobody is named on, for a commission
    /// of nothing, or twice for the same bill.
    /// </summary>
    internal void OnIssued(SqliteConnection c, SqliteTransaction t, long documentId, long? userId)
    {
        var bill = LoadBill(c, t, documentId);
        if (bill is null || bill.Direction != "out" || bill.Type != DocTypes.Invoice) return;
        var named = HubDb.Query(c, "SELECT b.earner_id, e.name, e.kind, b.basis, b.pct_milli, b.amount_minor FROM bill_earners b JOIN earners e ON e.id = b.earner_id WHERE b.document_id = $d",
            r => new BillEarner(r.Int("earner_id"), r.Text("name"), r.Text("kind"), r.Text("basis"), r.IntOrNull("pct_milli"), r.IntOrNull("amount_minor")), t, ("$d", documentId));
        if (named.Count == 0) return;
        var (taxable, total) = Bases(bill);
        foreach (var person in named)
        {
            if (HubDb.Scalar(c, "SELECT 1 FROM earner_ledger WHERE document_id = $d AND earner_id = $e AND kind = 'commission'", t, ("$d", documentId), ("$e", person.EarnerId)) is not null) continue;
            var baseMinor = person.Basis == "total" ? total : taxable;
            var amount = person.AmountMinor ?? (person.PctMilli is { } pct ? Share(baseMinor, pct, 100_000) : 0);
            if (amount <= 0) continue;
            var ledgerId = HubDb.Insert(c, "INSERT INTO earner_ledger(earner_id, at, kind, document_id, base_minor, amount_minor, note, user_id) VALUES ($e, $at, 'commission', $d, $b, $a, $n, $u)", t,
                ("$e", person.EarnerId), ("$at", Iso.Text(bill.At)), ("$d", documentId), ("$b", baseMinor), ("$a", amount), ("$n", "Bill " + bill.Number), ("$u", userId));
            books.PostEntry(c, t, bill.At, "commission", ledgerId, $"Commission to {person.Name} on bill {bill.Number}", userId,
                [new("commission", null, amount, 0), new("commission-payable", null, 0, amount)]);
        }
    }

    /// <summary>A bill was cancelled: whatever commission it earned and has not been taken back is taken back.</summary>
    internal void OnVoid(SqliteConnection c, SqliteTransaction t, long documentId, long? userId)
    {
        var bill = LoadBill(c, t, documentId);
        var earned = HubDb.Query(c,
            "SELECT e.earner_id, e.id AS entry, e.base_minor, e.amount_minor, p.name FROM earner_ledger e JOIN earners p ON p.id = e.earner_id WHERE e.document_id = $d AND e.kind = 'commission'",
            r => (Earner: r.Int("earner_id"), Entry: r.Int("entry"), Base: r.Int("base_minor"), Amount: r.Int("amount_minor"), Name: r.Text("name")), t, ("$d", documentId));
        foreach (var e in earned)
        {
            var back = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(-SUM(amount_minor), 0) FROM earner_ledger WHERE document_id = $d AND earner_id = $e AND kind = 'reversal'", t, ("$d", documentId), ("$e", e.Earner)) ?? 0L);
            var left = e.Amount - back;
            if (left <= 0) continue;
            TakeBack(c, t, e.Earner, e.Name, documentId, bill?.Number, left, e.Base, "Bill cancelled", userId);
        }
    }

    /// <summary>
    /// Goods came back on a credit note: each person named on the bill gives back a share of the commission, as much as the returned part of the bill is of the whole (by the same base the commission
    /// used). The older program reversed the whole line's commission for any part of it. Never more than was earned.
    /// </summary>
    internal void OnCreditNote(SqliteConnection c, SqliteTransaction t, long creditNoteId, long invoiceId, long? userId)
    {
        var note = LoadBill(c, t, creditNoteId);
        var invoice = LoadBill(c, t, invoiceId);
        if (note is null || invoice is null) return;
        var earned = HubDb.Query(c,
            "SELECT e.earner_id, e.base_minor, e.amount_minor, p.name, b.basis FROM earner_ledger e JOIN earners p ON p.id = e.earner_id LEFT JOIN bill_earners b ON b.document_id = e.document_id AND b.earner_id = e.earner_id WHERE e.document_id = $d AND e.kind = 'commission'",
            r => (Earner: r.Int("earner_id"), Base: r.Int("base_minor"), Amount: r.Int("amount_minor"), Name: r.Text("name"), Basis: r.TextOrNull("basis") ?? "taxable"), t, ("$d", invoiceId));
        if (earned.Count == 0) return;
        var (invoiceTaxable, invoiceTotal) = Bases(invoice);
        var (noteTaxable, noteTotal) = Bases(note);
        foreach (var e in earned)
        {
            var whole = e.Basis == "total" ? invoiceTotal : invoiceTaxable;
            var returned = e.Basis == "total" ? noteTotal : noteTaxable;
            var back = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(-SUM(amount_minor), 0) FROM earner_ledger WHERE document_id = $d AND earner_id = $e AND kind = 'reversal'", t, ("$d", invoiceId), ("$e", e.Earner)) ?? 0L);
            var amount = Math.Min(Share(e.Amount, returned, whole), e.Amount - back);
            if (amount <= 0) continue;
            TakeBack(c, t, e.Earner, e.Name, invoiceId, invoice.Number, amount, returned, "Goods brought back (credit note " + note.Number + ")", userId, creditNoteId);
        }
    }

    private void TakeBack(SqliteConnection c, SqliteTransaction t, long earnerId, string name, long documentId, string? number, long amount, long baseMinor, string why, long? userId, long? sourceDocument = null)
    {
        var at = clock.UtcNow;
        var ledgerId = HubDb.Insert(c, "INSERT INTO earner_ledger(earner_id, at, kind, document_id, base_minor, amount_minor, note, user_id) VALUES ($e, $at, 'reversal', $d, $b, $a, $n, $u)", t,
            ("$e", earnerId), ("$at", Iso.Text(at)), ("$d", documentId), ("$b", -baseMinor), ("$a", -amount), ("$n", why), ("$u", userId));
        books.PostEntry(c, t, at, "commission-back", ledgerId, $"Commission of {name} taken back on bill {number}: {why}", userId,
            [new("commission-payable", null, amount, 0), new("commission", null, 0, amount)]);
        audit.Log(c, t, userId, "commission-back", "earner", earnerId, $"{why}: {amount}");
    }

    // ---- what is owed, and paying ------------------------------------------------------------------------------------------------------------------

    /// <summary>What the shop owes the person now (positive), or what they were paid beyond what they earned (negative).</summary>
    public long Owed(long earnerId)
    {
        access.Require(Perm.Staff);
        return Convert.ToInt64(db.Scalar("SELECT COALESCE(SUM(amount_minor), 0) FROM earner_ledger WHERE earner_id = $e", ("$e", earnerId)) ?? 0L);
    }

    /// <summary>
    /// Pays a person some of what is owed, in cash or by one of the shop's other ways of paying (the books take it out of the same place the cash book or the bank book reads). Paying more than is
    /// owed is allowed, and said so in the answer; the older program had no warning at all.
    /// </summary>
    public EarnerPayment Pay(long earnerId, long amountMinor, string method, string? note = null, long? userId = null)
    {
        access.Require(Perm.Staff);
        if (amountMinor <= 0) throw new HubException("pay-amount", "Please give the amount paid, above nothing.");
        var way = string.IsNullOrWhiteSpace(method) ? "cash" : method.Trim().ToLowerInvariant();
        return db.InTransaction((c, t) =>
        {
            var name = HubDb.Scalar(c, "SELECT name FROM earners WHERE id = $id", t, ("$id", earnerId)) as string ?? throw new HubException("not-found", "That person was not found.");
            var before = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(SUM(amount_minor), 0) FROM earner_ledger WHERE earner_id = $e", t, ("$e", earnerId)) ?? 0L);
            var at = clock.UtcNow;
            var ledgerId = HubDb.Insert(c, "INSERT INTO earner_ledger(earner_id, at, kind, amount_minor, method, note, user_id) VALUES ($e, $at, 'payment', $a, $m, $n, $u)", t,
                ("$e", earnerId), ("$at", Iso.Text(at)), ("$a", -amountMinor), ("$m", way), ("$n", Blank(note)), ("$u", userId));
            books.PostEntry(c, t, at, "commission-paid", ledgerId, $"Commission paid to {name}", userId,
                [new("commission-payable", null, amountMinor, 0), way == "cash" ? new("cash", null, 0, amountMinor) : new("method", way, 0, amountMinor)]);
            audit.Log(c, t, userId, "commission-paid", "earner", earnerId, $"{amountMinor} by {way}");
            return new EarnerPayment(ledgerId, before, before - amountMinor);
        });
    }

    /// <summary>The account of a person, oldest first, with the balance after each line (positive: the shop owes them).</summary>
    public IReadOnlyList<EarnerLine> Statement(long earnerId, DateTimeOffset? from = null, DateTimeOffset? to = null)
    {
        access.Require(Perm.Staff);
        var rows = db.Query(
            "SELECT l.id, l.at, l.kind, l.document_id, l.amount_minor, l.method, l.note, d.number FROM earner_ledger l LEFT JOIN documents d ON d.id = l.document_id WHERE l.earner_id = $e ORDER BY l.at, l.id",
            r => (Id: r.Int("id"), At: r.Time("at"), Kind: r.Text("kind"), Doc: r.IntOrNull("document_id"), Amount: r.Int("amount_minor"), Method: r.TextOrNull("method"), Note: r.TextOrNull("note"), Number: r.TextOrNull("number")), ("$e", earnerId));
        var list = new List<EarnerLine>();
        long balance = 0;
        foreach (var r in rows)
        {
            balance += r.Amount;
            if ((from is not null && r.At < from) || (to is not null && r.At >= to)) continue;
            var memo = r.Kind switch
            {
                "commission" => "Commission on bill " + r.Number,
                "reversal" => "Taken back on bill " + r.Number + (r.Note is { Length: > 0 } n ? ": " + n : ""),
                "payment" => "Paid" + (r.Method is { Length: > 0 } m && m != "cash" ? " by " + m : " in cash") + (r.Note is { Length: > 0 } pn ? " (" + pn + ")" : ""),
                _ => "Balance brought across",
            };
            list.Add(new EarnerLine(r.Id, r.At, r.Kind, memo, r.Doc, r.Amount, balance));
        }
        return list;
    }

    /// <summary>For each person: the bills they earned on in the period, the base, what they earned, what was taken back, what was paid, and what is owed now.</summary>
    public IReadOnlyList<EarnerSummary> Summary(DateTimeOffset from, DateTimeOffset to, string? kind = null)
    {
        access.Require(Perm.Staff);
        return db.Query(
            "SELECT p.id, p.name, p.kind, " +
            "COUNT(DISTINCT CASE WHEN l.kind = 'commission' AND l.at >= $f AND l.at < $t THEN l.document_id END) AS bills, " +
            "COALESCE(SUM(CASE WHEN l.kind IN ('commission', 'reversal') AND l.at >= $f AND l.at < $t THEN l.base_minor END), 0) AS base, " +
            "COALESCE(SUM(CASE WHEN l.kind = 'commission' AND l.at >= $f AND l.at < $t THEN l.amount_minor END), 0) AS earned, " +
            "COALESCE(-SUM(CASE WHEN l.kind = 'reversal' AND l.at >= $f AND l.at < $t THEN l.amount_minor END), 0) AS reversed, " +
            "COALESCE(-SUM(CASE WHEN l.kind = 'payment' AND l.at >= $f AND l.at < $t THEN l.amount_minor END), 0) AS paid, " +
            "COALESCE(SUM(l.amount_minor), 0) AS owed " +
            "FROM earners p LEFT JOIN earner_ledger l ON l.earner_id = p.id WHERE ($k IS NULL OR p.kind = $k) GROUP BY p.id ORDER BY p.name COLLATE NOCASE, p.id",
            r => new EarnerSummary(r.Int("id"), r.Text("name"), r.Text("kind"), (int)r.Int("bills"), r.Int("base"), r.Int("earned"), r.Int("reversed"), r.Int("paid"), r.Int("owed")),
            ("$f", Iso.Text(from)), ("$t", Iso.Text(to)), ("$k", kind));
    }
}
