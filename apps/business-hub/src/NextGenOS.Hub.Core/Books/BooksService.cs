using System.Globalization;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;
using NextGenOS.Tax;
using NewtonJson = Newtonsoft.Json.JsonConvert;

namespace NextGenOS.Hub.Books;

/// <summary>
/// The shop's books, double entry (decision 32). Every bill that becomes final, every payment and every refund is posted here as an entry whose lines add up to nothing: what
/// the shop gains on one side it owes on the other. The books are read from the bills and payments and never the other way round, so a bill is worked out by the tax engine as
/// before; this class only writes down what the bill says.
///
/// An entry is posted once: the pair (source, source id) is unique, so asking again does nothing. An entry is never changed (a trigger in the database refuses it); a bill that is
/// cancelled gets a second entry that turns the first one round. Bills and payments made before the books existed are posted by <see cref="CatchUp"/>.
///
/// Posting never stops a sale. If a case is met that was not foreseen and the lines would not add up, the difference goes to an account called "Needs checking", which shows in
/// the trial balance and is looked for by the tests, and the sale goes on.
/// </summary>
public sealed class BooksService(HubDb db, IClock clock)
{
    private const string Tenant = "local";
    private const string Site = "main";

    // ---- the accounts ----------------------------------------------------------------------------------------------------------

    /// <summary>The roles of the accounts the program makes for itself, with the kind, the number the first account of the role gets and the name it is given.</summary>
    private static readonly Dictionary<string, (string Kind, int Code, string Name)> RoleInfo = new()
    {
        ["cash"] = ("asset", 1000, "Cash"),
        ["method"] = ("asset", 1010, "Received by "),                      // one for each way of paying that is not cash: ref = the way
        ["receivable"] = ("asset", 1100, "Customers owe us"),
        ["retention-receivable"] = ("asset", 1150, "Held back by customers"),
        ["supplier-advances"] = ("asset", 1160, "Paid to suppliers in advance"),
        ["tax-input"] = ("asset", 1300, " paid on purchases"),            // one for each part of the tax: ref = its name
        ["payable"] = ("liability", 2000, "We owe suppliers"),
        ["customer-advances"] = ("liability", 2100, "Customers' money kept for them"),
        ["tips-payable"] = ("liability", 2150, "Tips to hand on"),
        ["retention-payable"] = ("liability", 2160, "Held back from suppliers"),
        ["tax-output"] = ("liability", 2200, " collected"),                 // one for each part of the tax: ref = its name
        ["opening-balance"] = ("equity", 3000, "Opening balances"),
        ["sales"] = ("income", 4000, "Sales"),
        ["rounding"] = ("income", 4900, "Rounding"),
        ["purchases"] = ("expense", 5000, "Purchases"),
        ["suspense"] = ("asset", 9999, "Needs checking"),
    };

    /// <summary>Roles that have one account for each reference (a way of paying, a part of the tax). The others have a single account.</summary>
    private static readonly HashSet<string> PerReference = new() { "method", "tax-input", "tax-output" };

    /// <summary>Finds the account for a role (and reference), making it the first time.</summary>
    private long Account(SqliteConnection c, SqliteTransaction t, string role, string? reference = null)
    {
        var key = reference ?? "";
        var found = HubDb.Scalar(c, "SELECT id FROM accounts WHERE tenant_id = $t AND site_id = $s AND role = $r AND COALESCE(ref, '') = $f", t, ("$t", Tenant), ("$s", Site), ("$r", role), ("$f", key));
        if (found is long id) return id;
        var (kind, baseCode, name) = RoleInfo[role];
        var code = baseCode;
        if (PerReference.Contains(role))
        {
            var taken = HubDb.Query(c, "SELECT code FROM accounts WHERE tenant_id = $t AND site_id = $s AND role = $r", r => r.GetString(0), t, ("$t", Tenant), ("$s", Site), ("$r", role));
            code = baseCode + taken.Count;
            while (HubDb.Scalar(c, "SELECT 1 FROM accounts WHERE tenant_id = $t AND site_id = $s AND code = $c", t, ("$t", Tenant), ("$s", Site), ("$c", code.ToString(CultureInfo.InvariantCulture))) is not null) code++;
            name = role == "method" ? name + Label(key) : key + name;
        }
        return HubDb.Insert(c,
            "INSERT INTO accounts(tenant_id, site_id, code, name, kind, role, ref, created_at) VALUES ($t, $s, $code, $name, $kind, $role, $ref, $at)", t,
            ("$t", Tenant), ("$s", Site), ("$code", code.ToString(CultureInfo.InvariantCulture)), ("$name", name), ("$kind", kind), ("$role", role), ("$ref", reference), ("$at", Iso.Text(clock.UtcNow)));
    }

    private static string Label(string text) => text.Length == 0 ? text : char.ToUpperInvariant(text[0]) + text[1..];

    // ---- what is posted --------------------------------------------------------------------------------------------------------

    /// <summary>One line of an entry before its account is looked up: a role (and reference), who it concerns, and a debit or a credit.</summary>
    private readonly record struct Line(string Role, string? Ref, long? Party, long Debit, long Credit);

    private sealed record DocRow(long Id, string Type, string Status, string Direction, long? PartyId, string? Number, DateTimeOffset? IssuedAt, int Decimals, string? Result);

    private static DocRow? LoadDoc(SqliteConnection c, SqliteTransaction t, long id) => HubDb.Query(c,
        "SELECT id, type, status, direction, party_id, number, issued_at, currency_decimals, result FROM documents WHERE id = $id",
        r => new DocRow(r.GetInt64(0), r.GetString(1), r.GetString(2), r.GetString(3), r.IsDBNull(4) ? null : r.GetInt64(4), r.IsDBNull(5) ? null : r.GetString(5),
            r.IsDBNull(6) ? null : DateTimeOffset.Parse(r.GetString(6), CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal), r.GetInt32(7), r.IsDBNull(8) ? null : r.GetString(8)), t, ("$id", id)).FirstOrDefault();

    private static string KindName(string type) => type switch
    {
        "invoice" => "Bill", "progress-bill" => "Progress bill", "credit-note" => "Credit note", "purchase" => "Purchase", _ => type,
    };

    private static bool IsPosted(string type) => type is "invoice" or "progress-bill" or "credit-note" or "purchase";

    private bool Exists(SqliteConnection c, SqliteTransaction t, string source, long sourceId) =>
        HubDb.Scalar(c, "SELECT 1 FROM journal_entries WHERE tenant_id = $t AND site_id = $s AND source = $src AND source_id = $id", t, ("$t", Tenant), ("$s", Site), ("$src", source), ("$id", sourceId)) is not null;

    /// <summary>
    /// What a final bill says, as lines. A sale: the customer owes the amount payable (and what is held back, and what was paid in advance and is now used), the shop has sales, the tax
    /// collected for each part of it, any tips to hand on and the rounding. The lines add up to nothing by the way the tax engine builds its totals (grand total = sub-total + rounding;
    /// payable = grand total + tips - advances - retention, and anything over is a credit kept for the customer). A credit note turns every line round; a purchase turns every line round
    /// and uses the supplier's accounts.
    /// </summary>
    private static List<Line> SaleLines(DocRow doc, TaxResult result)
    {
        var d = doc.Decimals;
        long Minor(string text) => (long)MoneyText.Parse(text, d);
        var totals = result.Totals;
        var tax = (totals.Components ?? new List<Component>()).Where(x => Minor(x.Amount) != 0).Select(x => (x.Name, Amount: Minor(x.Amount))).ToList();
        var cess = Minor(totals.Cess ?? "0");
        var subTotal = Minor(totals.SubTotal);
        var grand = Minor(totals.GrandTotal);
        var payable = Minor(totals.Payable);
        var credit = Minor(totals.Credit ?? "0");
        var tips = Minor(totals.Tips ?? "0");
        var advances = Minor(totals.Advances ?? "0");
        var retention = Minor(totals.Retention ?? "0");
        var lines = new List<Line>
        {
            new("receivable", null, doc.PartyId, payable, 0),
            new("retention-receivable", null, doc.PartyId, retention, 0),
            new("customer-advances", null, doc.PartyId, advances, 0),
            new("sales", null, null, 0, subTotal - tax.Sum(x => x.Amount) - cess),
            new("tips-payable", null, null, 0, tips),
            new("customer-advances", null, doc.PartyId, 0, credit),
        };
        foreach (var part in tax) lines.Add(new Line("tax-output", part.Name, null, 0, part.Amount));
        if (cess != 0) lines.Add(new Line("tax-output", "Cess", null, 0, cess));
        var rounding = grand - subTotal;
        lines.Add(rounding >= 0 ? new Line("rounding", null, null, 0, rounding) : new Line("rounding", null, null, -rounding, 0));
        return lines;
    }

    private static List<Line> LinesFor(DocRow doc, TaxResult result)
    {
        var lines = SaleLines(doc, result);
        if (doc.Type == "invoice" || doc.Type == "progress-bill") return lines;
        // a credit note turns every line round; a purchase too, and then speaks of the supplier and what was bought
        var turned = lines.Select(l => new Line(l.Role, l.Ref, l.Party, l.Credit, l.Debit)).ToList();
        if (doc.Type == "credit-note") return turned;
        return turned.Select(l => l.Role switch
        {
            "receivable" => l with { Role = "payable" },
            "sales" => l with { Role = "purchases" },
            "tax-output" => l with { Role = "tax-input" },
            "retention-receivable" => l with { Role = "retention-payable" },
            "customer-advances" => l with { Role = "supplier-advances" },
            _ => l,
        }).ToList();
    }

    /// <summary>Writes an entry. Zero lines are left out; lines that do not add up are made to by a line on "Needs checking" (and that is noted in the memo).</summary>
    private long Post(SqliteConnection c, SqliteTransaction t, DateTimeOffset at, string source, long sourceId, string memo, long? userId, IReadOnlyList<Line> lines)
    {
        var kept = lines.Where(l => l.Debit != 0 || l.Credit != 0).ToList();
        var difference = kept.Sum(l => l.Debit) - kept.Sum(l => l.Credit);
        if (difference != 0)
        {
            kept.Add(difference > 0 ? new Line("suspense", null, null, 0, difference) : new Line("suspense", null, null, -difference, 0));
            memo += " (did not add up; the difference is on \"Needs checking\")";
        }
        var entry = HubDb.Insert(c,
            "INSERT INTO journal_entries(tenant_id, site_id, at, source, source_id, memo, user_id, created_at) VALUES ($t, $s, $at, $src, $id, $memo, $u, $now)", t,
            ("$t", Tenant), ("$s", Site), ("$at", Iso.Text(at)), ("$src", source), ("$id", sourceId), ("$memo", memo), ("$u", userId), ("$now", Iso.Text(clock.UtcNow)));
        foreach (var l in kept)
            HubDb.Exec(c, "INSERT INTO journal_lines(tenant_id, site_id, entry_id, account_id, party_id, debit_minor, credit_minor) VALUES ($t, $s, $e, $a, $p, $d, $cr)", t,
                ("$t", Tenant), ("$s", Site), ("$e", entry), ("$a", Account(c, t, l.Role, l.Ref)), ("$p", l.Party), ("$d", l.Debit), ("$cr", l.Credit));
        return entry;
    }

    // ---- posting a bill and its payments ------------------------------------------------------------------------------------------

    /// <summary>
    /// Brings the books up to date for one bill, inside the transaction that changed it (<paramref name="historic"/>: the bill was cancelled long ago, so its reversal is dated like the bill): the bill itself when it has become final, the reversal when it has been cancelled, and every
    /// payment or refund on it. Does nothing for what is already posted.
    /// </summary>
    public void Sync(SqliteConnection c, SqliteTransaction t, long documentId, long? userId = null, bool historic = false)
    {
        var doc = LoadDoc(c, t, documentId);
        if (doc is null || !IsPosted(doc.Type)) return;
        var issuedAt = doc.IssuedAt ?? clock.UtcNow;
        var hasEntry = Exists(c, t, "bill", doc.Id);
        if (!hasEntry && (doc.Status is "issued" or "void") && doc.IssuedAt is not null && doc.Result is not null)
        {
            var result = NewtonJson.DeserializeObject<TaxResult>(doc.Result);
            if (result is not null)
            {
                Post(c, t, issuedAt, "bill", doc.Id, $"{KindName(doc.Type)} {doc.Number}", userId, LinesFor(doc, result));
                hasEntry = true;
            }
        }
        if (doc.Status == "void" && hasEntry && !Exists(c, t, "void", doc.Id))
        {
            var original = HubDb.Query(c,
                "SELECT l.account_id, l.party_id, l.debit_minor, l.credit_minor, a.role, a.ref FROM journal_lines l JOIN journal_entries e ON e.id = l.entry_id JOIN accounts a ON a.id = l.account_id " +
                "WHERE e.tenant_id = $t AND e.site_id = $s AND e.source = 'bill' AND e.source_id = $id ORDER BY l.id",
                r => new Line(r.GetString(4), r.IsDBNull(5) ? null : r.GetString(5), r.IsDBNull(1) ? null : r.GetInt64(1), r.GetInt64(3), r.GetInt64(2)), t, ("$t", Tenant), ("$s", Site), ("$id", doc.Id));
            Post(c, t, historic ? issuedAt : clock.UtcNow, "void", doc.Id, $"{KindName(doc.Type)} {doc.Number} cancelled", userId, original);
        }
        if (!hasEntry) return;
        foreach (var paymentId in HubDb.Query(c, "SELECT id FROM payments WHERE document_id = $d ORDER BY id", r => r.GetInt64(0), t, ("$d", doc.Id))) SyncPayment(c, t, paymentId, userId);
    }

    /// <summary>Posts one payment or refund (money in or out), if it is not posted yet. A payment that belongs to a bill is posted only after the bill is.</summary>
    public void SyncPayment(SqliteConnection c, SqliteTransaction t, long paymentId, long? userId = null)
    {
        if (Exists(c, t, "payment", paymentId)) return;
        var p = HubDb.Query(c, "SELECT id, document_id, party_id, method, amount_minor, kind, at, reference FROM payments WHERE id = $id",
            r => (Id: r.GetInt64(0), Doc: r.IsDBNull(1) ? (long?)null : r.GetInt64(1), Party: r.IsDBNull(2) ? (long?)null : r.GetInt64(2), Method: r.GetString(3), Amount: r.GetInt64(4), Kind: r.GetString(5),
                At: DateTimeOffset.Parse(r.GetString(6), CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal), Reference: r.IsDBNull(7) ? null : r.GetString(7)), t, ("$id", paymentId)).FirstOrDefault();
        if (p.Id == 0 || p.Amount == 0) return;
        if (p.Method == DocumentService.AccountCredit) return;     // credit already on the customer's account moves no money: the account itself already nets it
        DocRow? doc = null;
        if (p.Doc is { } docId)
        {
            doc = LoadDoc(c, t, docId);
            if (doc is null || !IsPosted(doc.Type) || !Exists(c, t, "bill", doc.Id)) return;    // the bill comes first
        }
        var (cashRole, cashRef) = p.Method == "cash" ? ("cash", (string?)null) : ("method", p.Method);
        var money = Math.Abs(p.Amount);
        var party = p.Party ?? doc?.PartyId;
        // the other side: what the money settles
        var other = doc is null ? ("customer-advances", p.Kind == "advance" ? party : null) : doc.Type == "purchase" ? ("payable", party) : ("receivable", party);
        var moneyIn = p.Amount > 0;
        // a purchase paid is money out; a refund (negative) turns it round
        var cashDebit = doc?.Type == "purchase" ? !moneyIn : moneyIn;
        var lines = new List<Line>
        {
            new(cashRole, cashRef, null, cashDebit ? money : 0, cashDebit ? 0 : money),
            new(other.Item1, null, other.Item2, cashDebit ? 0 : money, cashDebit ? money : 0),
        };
        var what = p.Kind switch { "refund" => "Refund", "advance" => "Advance", _ => "Payment" };
        var memo = $"{what} ({p.Method})" + (doc?.Number is { } number ? $" for {number}" : "");
        Post(c, t, p.At, "payment", p.Id, memo, userId, lines);
    }

    /// <summary>Posts everything that is final and not posted yet: bills, cancellations and payments made before the books existed, or whose posting was interrupted. Returns the number of entries made.</summary>
    public int CatchUp()
    {
        return db.InTransaction((c, t) =>
        {
            var before = Convert.ToInt32(HubDb.Scalar(c, "SELECT COUNT(*) FROM journal_entries", t) ?? 0);
            // Only what has no entry yet: a bill with no entry, or a bill whose payments are not all posted.
            foreach (var id in HubDb.Query(c,
                         "SELECT d.id FROM documents d WHERE d.status IN ('issued', 'void') AND d.issued_at IS NOT NULL AND d.type IN ('invoice', 'progress-bill', 'credit-note', 'purchase') AND (" +
                         "NOT EXISTS (SELECT 1 FROM journal_entries e WHERE e.tenant_id = $t AND e.site_id = $s AND e.source = 'bill' AND e.source_id = d.id) OR " +
                         "EXISTS (SELECT 1 FROM payments p WHERE p.document_id = d.id AND p.method <> $a AND p.amount_minor <> 0 AND NOT EXISTS (SELECT 1 FROM journal_entries e WHERE e.tenant_id = $t AND e.site_id = $s AND e.source = 'payment' AND e.source_id = p.id))) " +
                         "ORDER BY d.issued_at, d.id", r => r.GetInt64(0), t, ("$t", Tenant), ("$s", Site), ("$a", DocumentService.AccountCredit)))
                Sync(c, t, id, null, historic: true);
            foreach (var id in HubDb.Query(c, "SELECT id FROM payments WHERE document_id IS NULL AND method <> $a ORDER BY id", r => r.GetInt64(0), t, ("$a", DocumentService.AccountCredit))) SyncPayment(c, t, id);
            PostOpeningBalances(c, t);
            return Convert.ToInt32(HubDb.Scalar(c, "SELECT COUNT(*) FROM journal_entries", t) ?? 0) - before;
        });
    }

    /// <summary>
    /// What a customer owed the shop, or the shop owed a supplier, on the day the shop moved across from an older system (kept in <c>party_opening_balances</c> by the import). Posted once for
    /// each person against "Opening balances". The saved figure is positive when the person owes the shop and negative when the shop owes the person, for customers and suppliers alike.
    /// </summary>
    private void PostOpeningBalances(SqliteConnection c, SqliteTransaction t)
    {
        var rows = HubDb.Query(c,
            "SELECT b.party_id, b.balance_minor, b.as_of, p.kind FROM party_opening_balances b JOIN parties p ON p.id = b.party_id WHERE b.tenant_id = $t AND b.site_id = $s ORDER BY b.party_id",
            r => (Party: r.GetInt64(0), Balance: r.GetInt64(1), AsOf: DateTimeOffset.Parse(r.GetString(2), CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal), Kind: r.GetString(3)), t, ("$t", Tenant), ("$s", Site));
        foreach (var row in rows)
        {
            if (row.Balance == 0 || Exists(c, t, "opening", row.Party)) continue;
            var amount = Math.Abs(row.Balance);
            var owesUs = row.Balance > 0;
            var supplier = row.Kind == "supplier";
            var role = supplier ? (owesUs ? "supplier-advances" : "payable") : (owesUs ? "receivable" : "customer-advances");
            // somebody who owes the shop is a debit on their account; somebody the shop owes is a credit; "Opening balances" takes the other side
            var lines = new List<Line> { new(role, null, row.Party, owesUs ? amount : 0, owesUs ? 0 : amount), new("opening-balance", null, null, owesUs ? 0 : amount, owesUs ? amount : 0) };
            Post(c, t, row.AsOf, "opening", row.Party, "Balance brought across", null, lines);
        }
    }

    // ---- reading the books -----------------------------------------------------------------------------------------------------

    public sealed record TrialRow(string Code, string Name, string Kind, long DebitMinor, long CreditMinor)
    {
        /// <summary>Positive when the account stands on the debit side.</summary>
        public long BalanceMinor => DebitMinor - CreditMinor;
    }

    /// <summary>Each account with what has been debited and credited to it in the period (from the start, to the end, when not given). The debits and the credits always come to the same.</summary>
    public IReadOnlyList<TrialRow> TrialBalance(DateTimeOffset? from = null, DateTimeOffset? to = null) => db.Query(
        "SELECT a.code, a.name, a.kind, COALESCE(SUM(l.debit_minor), 0), COALESCE(SUM(l.credit_minor), 0) FROM journal_lines l " +
        "JOIN journal_entries e ON e.id = l.entry_id JOIN accounts a ON a.id = l.account_id " +
        "WHERE ($from IS NULL OR e.at >= $from) AND ($to IS NULL OR e.at < $to) GROUP BY a.id ORDER BY a.code",
        r => new TrialRow(r.GetString(0), r.GetString(1), r.GetString(2), r.GetInt64(3), r.GetInt64(4)),
        ("$from", from is { } f ? Iso.Text(f) : null), ("$to", to is { } o ? Iso.Text(o) : null));

    public sealed record StatementRow(string Code, string Name, long AmountMinor);

    /// <summary>What came in and what went out in a period, from the books. Purchases are counted as costs when bought; the value of stock still on the shelf is not yet counted, so this is not the final word on profit.</summary>
    public sealed record ProfitAndLoss(IReadOnlyList<StatementRow> Income, IReadOnlyList<StatementRow> Costs)
    {
        public long IncomeMinor => Income.Sum(x => x.AmountMinor);
        public long CostsMinor => Costs.Sum(x => x.AmountMinor);
        public long NetMinor => IncomeMinor - CostsMinor;
    }

    public ProfitAndLoss Profit(DateTimeOffset? from, DateTimeOffset? to)
    {
        var rows = TrialBalance(from, to);
        return new ProfitAndLoss(
            rows.Where(r => r.Kind == "income" && r.BalanceMinor != 0).Select(r => new StatementRow(r.Code, r.Name, -r.BalanceMinor)).ToList(),
            rows.Where(r => r.Kind == "expense" && r.BalanceMinor != 0).Select(r => new StatementRow(r.Code, r.Name, r.BalanceMinor)).ToList());
    }

    /// <summary>What the shop has, owes and is worth on a day (the day's end, so everything before <paramref name="before"/>). Profit so far is what income and costs have left over since the books began; it makes the two sides equal.</summary>
    public sealed record BalanceSheet(IReadOnlyList<StatementRow> Assets, IReadOnlyList<StatementRow> Liabilities, IReadOnlyList<StatementRow> Equity, long ProfitSoFarMinor)
    {
        public long AssetsMinor => Assets.Sum(x => x.AmountMinor);
        public long LiabilitiesMinor => Liabilities.Sum(x => x.AmountMinor);
        public long EquityMinor => Equity.Sum(x => x.AmountMinor) + ProfitSoFarMinor;
    }

    public BalanceSheet Position(DateTimeOffset? before)
    {
        var rows = TrialBalance(null, before);
        return new BalanceSheet(
            rows.Where(r => r.Kind == "asset" && r.BalanceMinor != 0).Select(r => new StatementRow(r.Code, r.Name, r.BalanceMinor)).ToList(),
            rows.Where(r => r.Kind == "liability" && r.BalanceMinor != 0).Select(r => new StatementRow(r.Code, r.Name, -r.BalanceMinor)).ToList(),
            rows.Where(r => r.Kind == "equity" && r.BalanceMinor != 0).Select(r => new StatementRow(r.Code, r.Name, -r.BalanceMinor)).ToList(),
            rows.Where(r => r.Kind == "income").Sum(r => -r.BalanceMinor) - rows.Where(r => r.Kind == "expense").Sum(r => r.BalanceMinor));
    }

    public sealed record LedgerRow(DateTimeOffset At, string Memo, long DebitMinor, long CreditMinor, long BalanceMinor);

    /// <summary>
    /// A customer's account, line by line, with what they owed after each line (positive: the customer owes the shop; negative: the shop owes the customer, for instance after a return that was kept as
    /// credit or an advance). A supplier's account is the same read the other way: use <see cref="SupplierLedger"/>.
    /// </summary>
    public IReadOnlyList<LedgerRow> CustomerLedger(long partyId) => Ledger(partyId, new[] { "receivable", "customer-advances" }, +1);

    public IReadOnlyList<LedgerRow> SupplierLedger(long partyId) => Ledger(partyId, new[] { "payable", "supplier-advances" }, -1);

    private IReadOnlyList<LedgerRow> Ledger(long partyId, string[] roles, int sign)
    {
        var rows = db.Query(
            "SELECT e.at, e.memo, a.role, l.debit_minor, l.credit_minor FROM journal_lines l JOIN journal_entries e ON e.id = l.entry_id JOIN accounts a ON a.id = l.account_id " +
            "WHERE l.party_id = $p AND a.role IN (" + string.Join(", ", roles.Select(r => "'" + r + "'")) + ") ORDER BY e.at, e.id, l.id",
            r => (At: DateTimeOffset.Parse(r.GetString(0), CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal), Memo: r.IsDBNull(1) ? "" : r.GetString(1), Role: r.GetString(2), Debit: r.GetInt64(3), Credit: r.GetInt64(4)),
            ("$p", partyId));
        var result = new List<LedgerRow>();
        long running = 0;
        foreach (var row in rows)
        {
            // a customer owes by debit; a supplier is owed by credit: both read as "what they have to give / we have to give" with the sign of the first
            var move = sign > 0 ? row.Debit - row.Credit : row.Credit - row.Debit;
            running += move;
            result.Add(new LedgerRow(row.At, row.Memo, row.Debit, row.Credit, running));
        }
        return result;
    }

    /// <summary>What the customer owes the shop now (negative when the shop owes the customer).</summary>
    public long CustomerBalance(long partyId) => CustomerLedger(partyId).LastOrDefault()?.BalanceMinor ?? 0;

    /// <summary>The same, read inside a transaction that is changing the books (the credit-limit check of a bill being made).</summary>
    public long CustomerBalance(SqliteConnection c, SqliteTransaction t, long partyId) => Convert.ToInt64(HubDb.Scalar(c,
        "SELECT COALESCE(SUM(l.debit_minor - l.credit_minor), 0) FROM journal_lines l JOIN accounts a ON a.id = l.account_id WHERE l.party_id = $p AND a.role IN ('receivable', 'customer-advances')", t, ("$p", partyId)) ?? 0L);

    /// <summary>What the shop owes the supplier now (negative when the supplier owes the shop).</summary>
    public long SupplierBalance(long partyId) => SupplierLedger(partyId).LastOrDefault()?.BalanceMinor ?? 0;
}
