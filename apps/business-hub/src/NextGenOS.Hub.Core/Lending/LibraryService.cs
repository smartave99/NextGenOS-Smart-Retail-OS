using System.Text.Json;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Shop;
using NextGenOS.Tax;

namespace NextGenOS.Hub.Lending;

public sealed record Copy(long Id, long ItemId, string Barcode, string Status, string? Note);

public sealed record Loan(long Id, long CopyId, long PartyId, DateTimeOffset IssuedAt, DateTimeOffset DueAt, DateTimeOffset? ReturnedAt, int Renewals);

public sealed record LoanRow(Loan Loan, string Title, string CopyBarcode, string MemberName, string? MemberCard)
{
    public bool IsOpen => Loan.ReturnedAt is null;
}

public sealed record Reservation(long Id, long ItemId, long PartyId, DateTimeOffset At, string Status, long? CopyId, DateTimeOffset? HoldUntil);

public sealed record Fine(long Id, long? LoanId, long PartyId, long AmountMinor, string Reason, string Status, DateTimeOffset At, long? DocumentId);

public sealed record ReturnResult(Loan Loan, string Title, string MemberName, long FineMinor, int DaysLate, string? HeldForMember);

public sealed record OverdueRow(long LoanId, string Title, string CopyBarcode, long MemberId, string MemberName, string? Phone, DateOnly DueDate, int DaysLate, long FineSoFarMinor);

public sealed record ReservationRow(Reservation Reservation, string Title, string MemberName, string? MemberPhone);

public sealed record PopularTitle(long ItemId, string Title, int Loans, int Copies);

/// <summary>Members, copies of titles, lending and returning, due dates, renewals, reservations and fines, by the rules of the industry pack.</summary>
public sealed class LibraryService(HubDb db, ShopContextProvider shop, IClock clock, CatalogService catalog, PartyService parties, DocumentService documents, AuditService audit)
{
    // ---- member types ----------------------------------------------------------------------------------------------------------

    public sealed record MemberType(string Id, string Label, int LoanDays, int MaxLoans);

    public IReadOnlyList<MemberType> MemberTypes()
    {
        var rules = shop.Current.Industry.Rules;
        if (rules.ValueKind != JsonValueKind.Object || !rules.TryGetProperty("memberTypes", out var list)) return new[] { new MemberType("adult", "Member", 14, 5) };
        return list.EnumerateArray().Select(m => new MemberType(m.GetProperty("id").GetString()!, m.GetProperty("label").GetString()!, m.GetProperty("loanDays").GetInt32(), m.GetProperty("maxLoans").GetInt32())).ToList();
    }

    private MemberType TypeOf(Party member) => MemberTypes().FirstOrDefault(t => t.Id == member.MemberType) ?? MemberTypes()[0];

    // ---- titles and copies -----------------------------------------------------------------------------------------------------

    /// <summary>Adds a title to the catalogue. An ISBN, when given, must have a correct check digit.</summary>
    public Item AddTitle(string name, string? author = null, string? isbn = null, string? category = null, long priceMinor = 0, string? publisher = null, string? year = null)
    {
        var attrs = new Dictionary<string, string>();
        if (!string.IsNullOrWhiteSpace(author)) attrs["author"] = author.Trim();
        if (!string.IsNullOrWhiteSpace(publisher)) attrs["publisher"] = publisher.Trim();
        if (!string.IsNullOrWhiteSpace(year)) attrs["year"] = year.Trim();
        if (!string.IsNullOrWhiteSpace(isbn))
        {
            if (!Isbn.IsValid(isbn)) throw new HubException("isbn", $"\"{isbn.Trim()}\" is not a correct ISBN. Check the digits on the back of the book.");
            attrs["isbn"] = Isbn.Clean(isbn);
        }
        return catalog.Create(new ItemInput { Kind = "title", Name = name, Category = category, PriceMinor = priceMinor, TaxClass = "exempt", Barcode = attrs.GetValueOrDefault("isbn"), Attrs = attrs, Unit = "copy" });
    }

    /// <summary>Adds physical copies of a title, each with a barcode of its own (C-{title}-{number}).</summary>
    public IReadOnlyList<Copy> AddCopies(long itemId, int count, string? note = null)
    {
        if (count is < 1 or > 500) throw new HubException("count", "Add between 1 and 500 copies at a time.");
        var item = catalog.Get(itemId) ?? throw new HubException("not-found", "That title was not found.");
        if (item.Kind != "title") throw new HubException("not-title", "Copies belong to titles.");
        var ids = db.InTransaction((c, t) =>
        {
            var made = new List<long>();
            var existing = Convert.ToInt32(HubDb.Scalar(c, "SELECT COUNT(*) FROM copies WHERE item_id = $i", t, ("$i", itemId)) ?? 0);
            for (var n = 1; n <= count; n++)
            {
                var barcode = $"C{itemId:0000}-{existing + n:000}";
                made.Add(HubDb.Insert(c, "INSERT INTO copies(item_id, barcode, status, note) VALUES ($i, $b, 'available', $n)", t, ("$i", itemId), ("$b", barcode), ("$n", note)));
            }
            return made;
        });
        return ids.Select(id => CopyById(id)!).ToList();
    }

    private static Copy MapCopy(SqliteDataReader r) => new(r.Int("id"), r.Int("item_id"), r.Text("barcode"), r.Text("status"), r.TextOrNull("note"));

    public Copy? CopyById(long id) => db.QueryOne("SELECT id, item_id, barcode, status, note FROM copies WHERE id = $id", MapCopy, ("$id", id));

    public Copy? FindCopy(string barcode) => db.QueryOne("SELECT id, item_id, barcode, status, note FROM copies WHERE barcode = $b", MapCopy, ("$b", barcode.Trim()));

    public IReadOnlyList<Copy> CopiesOf(long itemId) => db.Query("SELECT id, item_id, barcode, status, note FROM copies WHERE item_id = $i ORDER BY barcode", MapCopy, ("$i", itemId));

    public int AvailableCopies(long itemId) => Convert.ToInt32(db.Scalar("SELECT COUNT(*) FROM copies WHERE item_id = $i AND status = 'available'", ("$i", itemId)) ?? 0);

    public void WithdrawCopy(long copyId, string reason, long? userId)
    {
        var copy = CopyById(copyId) ?? throw new HubException("not-found", "That copy was not found.");
        if (copy.Status == "on-loan") throw new HubException("on-loan", "That copy is on loan. Take it back first.");
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE copies SET status = 'withdrawn', note = $n WHERE id = $id", t, ("$n", reason), ("$id", copyId));
            audit.Log(c, t, userId, "copy-withdrawn", "copy", copyId, reason);
        });
    }

    // ---- lending ---------------------------------------------------------------------------------------------------------------

    /// <summary>The member by card number or by the number inside the system.</summary>
    public Party? FindMember(string cardOrName)
    {
        var text = cardOrName.Trim();
        return parties.FindByCard(text) ?? parties.Search(null, text, 5).FirstOrDefault(p => p.Kind is "member" or "staff");
    }

    /// <summary>Lends a copy to a member. Says in plain words why not when it cannot.</summary>
    public Loan Issue(long memberId, string copyBarcode, long? userId = null)
    {
        var context = shop.Current;
        ProcessHolds();
        var member = parties.Get(memberId) ?? throw new HubException("member-not-found", "That member was not found.");
        if (!member.Active) throw new HubException("member-off", $"{member.Name}'s membership is not active.");
        if (member.Kind is not ("member" or "staff")) throw new HubException("not-member", $"{member.Name} is not a member.");
        var copy = FindCopy(copyBarcode) ?? throw new HubException("copy-not-found", $"No copy has the barcode {copyBarcode.Trim()}.");
        var title = catalog.Get(copy.ItemId)!;
        var type = TypeOf(member);

        if (UnpaidFines(memberId).Sum(f => f.AmountMinor) > 0)
            throw new HubException("fines", $"{member.Name} has unpaid fines of {context.Money(UnpaidFines(memberId).Sum(f => f.AmountMinor))}. They are paid at the desk, or the librarian can waive them.");
        var open = OpenLoansOf(memberId);
        // The most useful reason first: an overdue item has to come back whatever the limit.
        if (open.Any(l => l.Loan.DueAt <= clock.UtcNow)) throw new HubException("overdue", $"{member.Name} has an item that is overdue. It has to come back first.");
        if (open.Count >= type.MaxLoans) throw new HubException("limit", $"{member.Name} already has {open.Count} items and may have {type.MaxLoans}.");

        switch (copy.Status)
        {
            case "on-loan":
                var who = db.QueryOne("SELECT p.name AS name FROM loans l JOIN parties p ON p.id = l.party_id WHERE l.copy_id = $c AND l.returned_at IS NULL", r => r.Text("name"), ("$c", copy.Id));
                throw new HubException("copy-on-loan", $"{title.Name} (copy {copy.Barcode}) is already on loan{(who is null ? "" : " to " + who)}.");
            case "held":
                var holder = db.Query("SELECT party_id FROM reservations WHERE copy_id = $c AND status = 'ready'", r => (long?)r.Int("party_id"), ("$c", copy.Id)).FirstOrDefault();
                if (holder is null || holder != memberId) throw new HubException("copy-held", $"That copy is kept for another member who reserved it.");
                break;
            case "lost" or "withdrawn":
                throw new HubException("copy-gone", $"That copy is not in the library any more ({copy.Status}).");
        }
        // A title other members are waiting for is not lent to someone further down the line while a held copy exists for them: handled by the hold above.
        var due = context.Time.StartOfNextDay(context.Time.LocalDate(clock.UtcNow).AddDays(type.LoanDays));
        var id = db.InTransaction((c, t) =>
        {
            var loanId = HubDb.Insert(c, "INSERT INTO loans(copy_id, party_id, issued_at, due_at, user_id) VALUES ($c, $p, $at, $due, $u)", t,
                ("$c", copy.Id), ("$p", memberId), ("$at", Iso.Text(clock.UtcNow)), ("$due", Iso.Text(due)), ("$u", userId));
            HubDb.Exec(c, "UPDATE copies SET status = 'on-loan' WHERE id = $id", t, ("$id", copy.Id));
            HubDb.Exec(c, "UPDATE reservations SET status = 'fulfilled' WHERE copy_id = $c AND party_id = $p AND status = 'ready'", t, ("$c", copy.Id), ("$p", memberId));
            return loanId;
        });
        return LoanById(id)!;
    }

    /// <summary>Takes a copy back. Works out the fine for late days, and keeps the copy for the next member waiting for it, if there is one.</summary>
    public ReturnResult Return(string copyBarcode, long? userId = null)
    {
        var context = shop.Current;
        var copy = FindCopy(copyBarcode) ?? throw new HubException("copy-not-found", $"No copy has the barcode {copyBarcode.Trim()}.");
        var loan = db.QueryOne("SELECT id, copy_id, party_id, issued_at, due_at, returned_at, renewals FROM loans WHERE copy_id = $c AND returned_at IS NULL", MapLoan, ("$c", copy.Id))
            ?? throw new HubException("not-on-loan", "That copy is not on loan.");
        var now = clock.UtcNow;
        var dueDate = context.Time.LocalDate(loan.DueAt.AddSeconds(-1));
        var today = context.Time.LocalDate(now);
        var late = Math.Max(0, today.DayNumber - dueDate.DayNumber);
        var chargeable = Math.Max(0, late - (int)context.Rule("graceDays", 0));
        var perDay = context.RuleMinor("finePerDay");
        var cap = context.RuleMinor("fineCap");
        var fine = chargeable * perDay;
        if (cap > 0 && fine > cap) fine = cap;
        var member = parties.Get(loan.PartyId)!;
        var title = catalog.Get(copy.ItemId)!;

        string? heldFor = null;
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE loans SET returned_at = $at WHERE id = $id", t, ("$at", Iso.Text(now)), ("$id", loan.Id));
            if (fine > 0)
                HubDb.Exec(c, "INSERT INTO fines(loan_id, party_id, amount_minor, reason, status, at) VALUES ($l, $p, $a, $r, 'unpaid', $at)", t,
                    ("$l", loan.Id), ("$p", loan.PartyId), ("$a", fine), ("$r", $"{title.Name}: {chargeable} day{(chargeable == 1 ? "" : "s")} late"), ("$at", Iso.Text(now)));
            var next = HubDb.Query(c, "SELECT id, party_id FROM reservations WHERE item_id = $i AND status = 'waiting' ORDER BY at, id LIMIT 1", r => (Id: r.Int("id"), Party: r.Int("party_id")), t, ("$i", copy.ItemId)).Cast<(long Id, long Party)?>().FirstOrDefault();
            if (next is { } n)
            {
                var hold = now.AddDays((double)context.Rule("reservationHoldDays", 3));
                HubDb.Exec(c, "UPDATE copies SET status = 'held' WHERE id = $id", t, ("$id", copy.Id));
                HubDb.Exec(c, "UPDATE reservations SET status = 'ready', copy_id = $c, hold_until = $h WHERE id = $id", t, ("$c", copy.Id), ("$h", Iso.Text(hold)), ("$id", n.Id));
                heldFor = parties.Get(n.Party)?.Name;
            }
            else HubDb.Exec(c, "UPDATE copies SET status = 'available' WHERE id = $id", t, ("$id", copy.Id));
            if (fine > 0) audit.Log(c, t, userId, "fine", "loan", loan.Id, context.Money(fine));
        });
        return new ReturnResult(LoanById(loan.Id)!, title.Name, member.Name, fine, chargeable, heldFor);
    }

    /// <summary>Gives the member more time with an item: not when the limit of renewals is reached, the item is overdue, or someone is waiting for it.</summary>
    public Loan Renew(long loanId, long? userId = null)
    {
        var context = shop.Current;
        var loan = LoanById(loanId) ?? throw new HubException("not-found", "That loan was not found.");
        if (loan.ReturnedAt is not null) throw new HubException("returned", "That item was already returned.");
        var max = (int)context.Rule("renewals", 2);
        if (loan.Renewals >= max) throw new HubException("renew-limit", $"This item has already been renewed {loan.Renewals} times, which is the most allowed.");
        if (loan.DueAt <= clock.UtcNow) throw new HubException("overdue", "This item is overdue and has to be returned.");
        var copy = CopyById(loan.CopyId)!;
        if (Convert.ToInt64(db.Scalar("SELECT COUNT(*) FROM reservations WHERE item_id = $i AND status = 'waiting'", ("$i", copy.ItemId)) ?? 0L) > 0)
            throw new HubException("reserved", "Another member is waiting for this title, so it cannot be renewed.");
        var type = TypeOf(parties.Get(loan.PartyId)!);
        var due = context.Time.StartOfNextDay(context.Time.LocalDate(clock.UtcNow).AddDays(type.LoanDays));
        db.InTransaction((c, t) => HubDb.Exec(c, "UPDATE loans SET due_at = $d, renewals = renewals + 1 WHERE id = $id", t, ("$d", Iso.Text(due)), ("$id", loanId)));
        return LoanById(loanId)!;
    }

    // ---- reservations ----------------------------------------------------------------------------------------------------------

    /// <summary>Puts a member in the queue for a title whose copies are all out.</summary>
    public Reservation Reserve(long itemId, long memberId)
    {
        var title = catalog.Get(itemId) ?? throw new HubException("not-found", "That title was not found.");
        var member = parties.Get(memberId) ?? throw new HubException("member-not-found", "That member was not found.");
        if (CopiesOf(itemId).All(c => c.Status is "lost" or "withdrawn")) throw new HubException("no-copies", $"The library has no copies of {title.Name} to reserve.");
        if (AvailableCopies(itemId) > 0) throw new HubException("available", $"A copy of {title.Name} is on the shelf now: lend it instead of reserving.");
        if (db.Scalar("SELECT 1 FROM loans l JOIN copies c ON c.id = l.copy_id WHERE c.item_id = $i AND l.party_id = $p AND l.returned_at IS NULL LIMIT 1", ("$i", itemId), ("$p", memberId)) is not null)
            throw new HubException("has-it", $"{member.Name} already has a copy of {title.Name}.");
        if (db.Scalar("SELECT 1 FROM reservations WHERE item_id = $i AND party_id = $p AND status IN ('waiting','ready') LIMIT 1", ("$i", itemId), ("$p", memberId)) is not null)
            throw new HubException("already-reserved", $"{member.Name} is already waiting for {title.Name}.");
        var id = db.InTransaction((c, t) => HubDb.Insert(c, "INSERT INTO reservations(item_id, party_id, at, status) VALUES ($i, $p, $at, 'waiting')", t, ("$i", itemId), ("$p", memberId), ("$at", Iso.Text(clock.UtcNow))));
        return ReservationById(id)!;
    }

    public void CancelReservation(long reservationId)
    {
        var r = ReservationById(reservationId) ?? throw new HubException("not-found", "That reservation was not found.");
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE reservations SET status = 'cancelled' WHERE id = $id AND status IN ('waiting','ready')", t, ("$id", reservationId));
            if (r.Status == "ready" && r.CopyId is { } copyId) PassCopyOn(c, t, copyId, r.ItemId);
        });
    }

    /// <summary>Holds that were not collected in time are released: the copy goes to the next member in the queue, or back on the shelf.</summary>
    public void ProcessHolds()
    {
        var expired = db.Query("SELECT id, item_id, copy_id FROM reservations WHERE status = 'ready' AND hold_until < $now", r => (Id: r.Int("id"), Item: r.Int("item_id"), Copy: r.IntOrNull("copy_id")), ("$now", Iso.Text(clock.UtcNow)));
        if (expired.Count == 0) return;
        db.InTransaction((c, t) =>
        {
            foreach (var e in expired)
            {
                HubDb.Exec(c, "UPDATE reservations SET status = 'expired' WHERE id = $id", t, ("$id", e.Id));
                if (e.Copy is { } copyId) PassCopyOn(c, t, copyId, e.Item);
            }
        });
    }

    private void PassCopyOn(SqliteConnection c, SqliteTransaction t, long copyId, long itemId)
    {
        var next = HubDb.Query(c, "SELECT id FROM reservations WHERE item_id = $i AND status = 'waiting' ORDER BY at, id LIMIT 1", r => r.Int("id"), t, ("$i", itemId)).Cast<long?>().FirstOrDefault();
        if (next is { } id)
        {
            var hold = clock.UtcNow.AddDays((double)shop.Current.Rule("reservationHoldDays", 3));
            HubDb.Exec(c, "UPDATE reservations SET status = 'ready', copy_id = $c, hold_until = $h WHERE id = $id", t, ("$c", copyId), ("$h", Iso.Text(hold)), ("$id", id));
            HubDb.Exec(c, "UPDATE copies SET status = 'held' WHERE id = $id", t, ("$id", copyId));
        }
        else HubDb.Exec(c, "UPDATE copies SET status = 'available' WHERE id = $id", t, ("$id", copyId));
    }

    public Reservation? ReservationById(long id) => db.QueryOne("SELECT id, item_id, party_id, at, status, copy_id, hold_until FROM reservations WHERE id = $id", MapReservation, ("$id", id));

    public IReadOnlyList<Reservation> ReservationsFor(long itemId) =>
        db.Query("SELECT id, item_id, party_id, at, status, copy_id, hold_until FROM reservations WHERE item_id = $i AND status IN ('waiting','ready') ORDER BY at, id", MapReservation, ("$i", itemId));

    /// <summary>Everyone waiting for a title or holding one that is kept for them, oldest first.</summary>
    public IReadOnlyList<ReservationRow> ActiveReservations() =>
        db.Query("SELECT r.id, r.item_id, r.party_id, r.at, r.status, r.copy_id, r.hold_until, i.name AS title, p.name AS member_name, p.phone AS phone FROM reservations r " +
                 "JOIN items i ON i.id = r.item_id JOIN parties p ON p.id = r.party_id WHERE r.status IN ('waiting','ready') ORDER BY r.at, r.id",
            r => new ReservationRow(MapReservation(r), r.Text("title"), r.Text("member_name"), r.TextOrNull("phone")));

    public IReadOnlyList<Reservation> ReservationsOf(long memberId) =>
        db.Query("SELECT id, item_id, party_id, at, status, copy_id, hold_until FROM reservations WHERE party_id = $p AND status IN ('waiting','ready') ORDER BY at, id", MapReservation, ("$p", memberId));

    private static Reservation MapReservation(SqliteDataReader r) => new(r.Int("id"), r.Int("item_id"), r.Int("party_id"), r.Time("at"), r.Text("status"), r.IntOrNull("copy_id"), r.TimeOrNull("hold_until"));

    // ---- loans -----------------------------------------------------------------------------------------------------------------

    private static Loan MapLoan(SqliteDataReader r) => new(r.Int("id"), r.Int("copy_id"), r.Int("party_id"), r.Time("issued_at"), r.Time("due_at"), r.TimeOrNull("returned_at"), (int)r.Int("renewals"));

    public Loan? LoanById(long id) => db.QueryOne("SELECT id, copy_id, party_id, issued_at, due_at, returned_at, renewals FROM loans WHERE id = $id", MapLoan, ("$id", id));

    private const string LoanRowSql =
        "SELECT l.id, l.copy_id, l.party_id, l.issued_at, l.due_at, l.returned_at, l.renewals, i.name AS title, c.barcode AS copy_barcode, p.name AS member_name, p.card_barcode AS card " +
        "FROM loans l JOIN copies c ON c.id = l.copy_id JOIN items i ON i.id = c.item_id JOIN parties p ON p.id = l.party_id ";

    private static LoanRow MapLoanRow(SqliteDataReader r) => new(MapLoan(r), r.Text("title"), r.Text("copy_barcode"), r.Text("member_name"), r.TextOrNull("card"));

    public IReadOnlyList<LoanRow> OpenLoansOf(long memberId) => db.Query(LoanRowSql + "WHERE l.party_id = $p AND l.returned_at IS NULL ORDER BY l.due_at", MapLoanRow, ("$p", memberId));

    public IReadOnlyList<LoanRow> History(long memberId, int limit = 50) => db.Query(LoanRowSql + "WHERE l.party_id = $p ORDER BY l.issued_at DESC LIMIT $n", MapLoanRow, ("$p", memberId), ("$n", limit));

    public IReadOnlyList<LoanRow> OpenLoans() => db.Query(LoanRowSql + "WHERE l.returned_at IS NULL ORDER BY l.due_at", MapLoanRow);

    // ---- fines -----------------------------------------------------------------------------------------------------------------

    private static Fine MapFine(SqliteDataReader r) => new(r.Int("id"), r.IntOrNull("loan_id"), r.Int("party_id"), r.Int("amount_minor"), r.Text("reason"), r.Text("status"), r.Time("at"), r.IntOrNull("document_id"));

    public IReadOnlyList<Fine> UnpaidFines(long memberId) =>
        db.Query("SELECT id, loan_id, party_id, amount_minor, reason, status, at, document_id FROM fines WHERE party_id = $p AND status = 'unpaid' ORDER BY at", MapFine, ("$p", memberId));

    public IReadOnlyList<Fine> AllFines(int limit = 200) =>
        db.Query("SELECT id, loan_id, party_id, amount_minor, reason, status, at, document_id FROM fines ORDER BY at DESC, id DESC LIMIT $n", MapFine, ("$n", limit));

    /// <summary>Charges a member (a copy lost or damaged, a membership fee) as an unpaid fine.</summary>
    public Fine Charge(long memberId, long amountMinor, string reason, long? userId)
    {
        if (amountMinor <= 0) throw new HubException("amount", "The amount must be more than zero.");
        if (string.IsNullOrWhiteSpace(reason)) throw new HubException("reason", "Please say what it is for.");
        _ = parties.Get(memberId) ?? throw new HubException("member-not-found", "That member was not found.");
        var id = db.InTransaction((c, t) => HubDb.Insert(c, "INSERT INTO fines(party_id, amount_minor, reason, status, at) VALUES ($p, $a, $r, 'unpaid', $at)", t,
            ("$p", memberId), ("$a", amountMinor), ("$r", reason.Trim()), ("$at", Iso.Text(clock.UtcNow))));
        audit.Log(userId, "charge", "fine", id, reason.Trim());
        return db.QueryOne("SELECT id, loan_id, party_id, amount_minor, reason, status, at, document_id FROM fines WHERE id = $id", MapFine, ("$id", id))!;
    }

    /// <summary>A lost copy: it is marked lost, the loan ends, and the member is charged the lost-item fee (the title's price times the fee factor).</summary>
    public Fine MarkLost(long loanId, long? userId)
    {
        var context = shop.Current;
        var loan = LoanById(loanId) ?? throw new HubException("not-found", "That loan was not found.");
        if (loan.ReturnedAt is not null) throw new HubException("returned", "That item was already returned.");
        var copy = CopyById(loan.CopyId)!;
        var title = catalog.Get(copy.ItemId)!;
        var fee = (long)Math.Round(title.PriceMinor * context.Rule("lostItemFeeMultiplier", 1m), 0, MidpointRounding.AwayFromZero);
        long fineId = 0;
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE loans SET returned_at = $at WHERE id = $id", t, ("$at", Iso.Text(clock.UtcNow)), ("$id", loanId));
            HubDb.Exec(c, "UPDATE copies SET status = 'lost' WHERE id = $id", t, ("$id", copy.Id));
            if (fee > 0)
                fineId = HubDb.Insert(c, "INSERT INTO fines(loan_id, party_id, amount_minor, reason, status, at) VALUES ($l, $p, $a, $r, 'unpaid', $at)", t,
                    ("$l", loanId), ("$p", loan.PartyId), ("$a", fee), ("$r", $"{title.Name}: lost"), ("$at", Iso.Text(clock.UtcNow)));
            audit.Log(c, t, userId, "copy-lost", "copy", copy.Id, title.Name);
        });
        return fineId == 0 ? new Fine(0, loanId, loan.PartyId, 0, $"{title.Name}: lost", "paid", clock.UtcNow, null)
            : db.QueryOne("SELECT id, loan_id, party_id, amount_minor, reason, status, at, document_id FROM fines WHERE id = $id", MapFine, ("$id", fineId))!;
    }

    public void Waive(long fineId, string reason, long? userId)
    {
        if (string.IsNullOrWhiteSpace(reason)) throw new HubException("reason", "Please say why.");
        var changed = db.InTransaction((c, t) =>
        {
            var n = HubDb.Exec(c, "UPDATE fines SET status = 'waived' WHERE id = $id AND status = 'unpaid'", t, ("$id", fineId));
            if (n > 0) audit.Log(c, t, userId, "fine-waived", "fine", fineId, reason.Trim());
            return n;
        });
        if (changed == 0) throw new HubException("not-unpaid", "That fine is not waiting to be paid.");
    }

    /// <summary>The member pays all their fines: a receipt is made (the fines as fees on it) and the fines are marked paid.</summary>
    public DocumentView PayFines(long memberId, IEnumerable<PaymentInput> payments, long? userId)
    {
        var fines = UnpaidFines(memberId);
        if (fines.Count == 0) throw new HubException("no-fines", "This member has no unpaid fines.");
        var adjustments = fines.Select(f => new TaxAdjustmentInput { Code = "FINE", Kind = "fee", Label = f.Reason, Amount = shop.Current.Text(f.AmountMinor) }).ToList();
        var view = documents.Checkout(new CheckoutRequest { PartyId = memberId, Adjustments = adjustments, Payments = payments.ToList(), UserId = userId, Notes = "Library fines" });
        db.InTransaction((c, t) => HubDb.Exec(c, "UPDATE fines SET status = 'paid', document_id = $d WHERE party_id = $p AND status = 'unpaid'", t, ("$d", view.Document.Id), ("$p", memberId)));
        return view;
    }

    // ---- reports ---------------------------------------------------------------------------------------------------------------

    public IReadOnlyList<OverdueRow> Overdue()
    {
        var context = shop.Current;
        var today = context.Time.LocalDate(clock.UtcNow);
        var perDay = context.RuleMinor("finePerDay");
        var cap = context.RuleMinor("fineCap");
        var grace = (int)context.Rule("graceDays", 0);
        return db.Query(LoanRowSql.Replace("p.card_barcode AS card", "p.card_barcode AS card, p.phone AS phone") + "WHERE l.returned_at IS NULL AND l.due_at <= $now ORDER BY l.due_at",
            r => (Row: MapLoanRow(r), Phone: r.TextOrNull("phone")), ("$now", Iso.Text(clock.UtcNow)))
            .Select(x =>
            {
                var dueDate = context.Time.LocalDate(x.Row.Loan.DueAt.AddSeconds(-1));
                var late = Math.Max(1, today.DayNumber - dueDate.DayNumber);
                var fine = Math.Max(0, late - grace) * perDay;
                if (cap > 0 && fine > cap) fine = cap;
                return new OverdueRow(x.Row.Loan.Id, x.Row.Title, x.Row.CopyBarcode, x.Row.Loan.PartyId, x.Row.MemberName, x.Phone, dueDate, late, fine);
            }).ToList();
    }

    public IReadOnlyList<PopularTitle> Popular(DateTimeOffset from, DateTimeOffset to, int limit = 20) => db.Query(
        "SELECT i.id, i.name, COUNT(l.id) AS loans, (SELECT COUNT(*) FROM copies c2 WHERE c2.item_id = i.id) AS copies FROM loans l JOIN copies c ON c.id = l.copy_id JOIN items i ON i.id = c.item_id " +
        "WHERE l.issued_at >= $f AND l.issued_at < $t GROUP BY i.id ORDER BY loans DESC, i.name LIMIT $n",
        r => new PopularTitle(r.Int("id"), r.Text("name"), (int)r.Int("loans"), (int)r.Int("copies")), ("$f", Iso.Text(from)), ("$t", Iso.Text(to)), ("$n", limit));

    public long FinesCollected(DateTimeOffset from, DateTimeOffset to) => Convert.ToInt64(db.Scalar(
        "SELECT COALESCE(SUM(f.amount_minor), 0) FROM fines f JOIN documents d ON d.id = f.document_id WHERE f.status = 'paid' AND d.issued_at >= $f AND d.issued_at < $t", ("$f", Iso.Text(from)), ("$t", Iso.Text(to))) ?? 0L);
}
