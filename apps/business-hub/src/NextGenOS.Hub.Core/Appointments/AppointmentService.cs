using System.Globalization;
using System.Text.Json;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Shop;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Appointments;

public sealed record Appointment(long Id, long? PartyId, long StaffId, long ItemId, DateTimeOffset Start, DateTimeOffset End, string Status, long? DocumentId, string? Notes);

public sealed record AppointmentRow(Appointment Appointment, string ClientName, string StaffName, string Service);

public sealed record StaffSales(long StaffId, string Name, int Visits, long SalesMinor);

/// <summary>Bookings for staff and services: no double booking, opening hours, walk-ins, and turning a finished visit into an invoice.</summary>
public sealed class AppointmentService(HubDb db, ShopContextProvider shop, IClock clock, CatalogService catalog, PartyService parties, DocumentService documents, Access access)
{
    private static Appointment Map(SqliteDataReader r) => new(r.Int("id"), r.IntOrNull("party_id"), r.Int("staff_id"), r.Int("item_id"), r.Time("start_at"), r.Time("end_at"), r.Text("status"), r.IntOrNull("document_id"), r.TextOrNull("notes"));

    private const string Columns = "id, party_id, staff_id, item_id, start_at, end_at, status, document_id, notes";

    public IReadOnlyList<Party> Staff() => parties.Search("staff", null, 200);

    private (TimeOnly From, TimeOnly To, HashSet<int> ClosedDays, int Slot) Hours()
    {
        var industry = shop.Current.Industry;
        return (TimeOnly.Parse(industry.RuleText("openFrom", "09:00"), CultureInfo.InvariantCulture), TimeOnly.Parse(industry.RuleText("openTo", "18:00"), CultureInfo.InvariantCulture),
            industry.Rules.ValueKind == JsonValueKind.Object && industry.Rules.TryGetProperty("closedWeekdays", out var closed) ? closed.EnumerateArray().Select(x => x.GetInt32()).ToHashSet() : new HashSet<int>(),
            (int)industry.RuleNumber("slotMinutes", 30));
    }

    private int DurationOf(Item service) => service.DurationMin is > 0 ? service.DurationMin.Value : Hours().Slot;

    /// <summary>Books a service with a staff member at a local date and time. Refuses the past, closed hours and clashes in plain words.</summary>
    public Appointment Book(long? clientId, long staffId, long serviceId, DateOnly date, TimeOnly time, string? notes = null, bool walkIn = false)
    {
        access.Require(Perm.Appointments);
        var context = shop.Current;
        var staff = parties.Get(staffId) ?? throw new HubException("staff-not-found", "That staff member was not found.");
        if (staff.Kind != "staff" || !staff.Active) throw new HubException("staff", $"{staff.Name} cannot take bookings.");
        var service = catalog.Get(serviceId) ?? throw new HubException("service-not-found", "That service was not found.");
        if (service.Kind != "service") throw new HubException("not-service", $"{service.Name} is not a service.");
        if (clientId is { } cid && parties.Get(cid) is null) throw new HubException("client-not-found", "That client was not found.");
        var (from, to, closed, _) = Hours();
        if (closed.Contains((int)date.DayOfWeek)) throw new HubException("closed", $"The business is closed on {date.DayOfWeek}s.");
        var start = context.Time.At(date, time);
        var end = start.AddMinutes(DurationOf(service));
        var closing = context.Time.At(date, to);
        if (time < from || end > closing) throw new HubException("hours", $"Bookings are between {from:HH\\:mm} and {to:HH\\:mm}, and this one would run past closing.");
        if (!walkIn && start < clock.UtcNow.AddMinutes(-1)) throw new HubException("past", "That time has already passed.");
        var clash = db.QueryOne($"SELECT {Columns} FROM appointments WHERE staff_id = $s AND status IN ('booked','arrived') AND start_at < $end AND end_at > $start", Map, ("$s", staffId), ("$start", Iso.Text(start)), ("$end", Iso.Text(end)));
        if (clash is not null)
            throw new HubException("clash", $"{staff.Name} is busy from {context.Time.ToLocal(clash.Start):HH\\:mm} to {context.Time.ToLocal(clash.End):HH\\:mm}.");
        var id = db.InTransaction((c, t) => HubDb.Insert(c, "INSERT INTO appointments(party_id, staff_id, item_id, start_at, end_at, status, notes, created_at) VALUES ($p, $s, $i, $st, $en, $status, $n, $at)", t,
            ("$p", clientId), ("$s", staffId), ("$i", serviceId), ("$st", Iso.Text(start)), ("$en", Iso.Text(end)), ("$status", walkIn ? "arrived" : "booked"), ("$n", notes), ("$at", Iso.Text(clock.UtcNow))));
        return Get(id)!;
    }

    public Appointment? Get(long id) => db.QueryOne($"SELECT {Columns} FROM appointments WHERE id = $id", Map, ("$id", id));

    /// <summary>Every booking of a local day, in order, with names.</summary>
    public IReadOnlyList<AppointmentRow> Day(DateOnly date, long? staffId = null)
    {
        var context = shop.Current;
        var from = context.Time.StartOfDay(date);
        var to = context.Time.StartOfNextDay(date);
        return db.Query(
            "SELECT a.id, a.party_id, a.staff_id, a.item_id, a.start_at, a.end_at, a.status, a.document_id, a.notes, COALESCE(c.name, 'Walk-in') AS client, s.name AS staff, i.name AS service " +
            "FROM appointments a LEFT JOIN parties c ON c.id = a.party_id JOIN parties s ON s.id = a.staff_id JOIN items i ON i.id = a.item_id " +
            "WHERE a.start_at >= $f AND a.start_at < $t AND ($s IS NULL OR a.staff_id = $s) ORDER BY a.start_at, a.id",
            r => new AppointmentRow(Map(r), r.Text("client"), r.Text("staff"), r.Text("service")), ("$f", Iso.Text(from)), ("$t", Iso.Text(to)), ("$s", staffId));
    }

    /// <summary>The start times that are free for a staff member on a day, for a service of the length given, every slot of the day.</summary>
    public IReadOnlyList<TimeOnly> FreeSlots(long staffId, long serviceId, DateOnly date)
    {
        var context = shop.Current;
        var service = catalog.Get(serviceId) ?? throw new HubException("service-not-found", "That service was not found.");
        var (from, to, closed, slot) = Hours();
        if (closed.Contains((int)date.DayOfWeek)) return Array.Empty<TimeOnly>();
        var busy = Day(date, staffId).Where(a => a.Appointment.Status is "booked" or "arrived").Select(a => (a.Appointment.Start, a.Appointment.End)).ToList();
        var length = DurationOf(service);
        var slots = new List<TimeOnly>();
        for (var t = from; t.AddMinutes(length) <= to && t >= from; t = t.AddMinutes(slot))
        {
            var start = context.Time.At(date, t);
            var end = start.AddMinutes(length);
            if (start < clock.UtcNow) continue;
            if (busy.All(b => b.End <= start || b.Start >= end)) slots.Add(t);
            if (t.AddMinutes(slot) <= t) break;
        }
        return slots;
    }

    public Appointment SetStatus(long id, string status)
    {
        access.Require(Perm.Appointments);
        var a = Get(id) ?? throw new HubException("not-found", "That booking was not found.");
        var allowed = a.Status switch
        {
            "booked" => new[] { "arrived", "cancelled", "no-show" },
            "arrived" => new[] { "done", "cancelled" },
            _ => Array.Empty<string>(),
        };
        if (!allowed.Contains(status)) throw new HubException("status", $"A booking that is {a.Status} cannot become {status}.");
        db.InTransaction((c, t) => HubDb.Exec(c, "UPDATE appointments SET status = $s WHERE id = $id", t, ("$s", status), ("$id", id)));
        return Get(id)!;
    }

    /// <summary>The visit is over: an invoice is made for the service (and anything else sold), paid at once, and the booking is marked done.</summary>
    public DocumentView Invoice(long appointmentId, IEnumerable<LineInput>? extras, IEnumerable<PaymentInput> payments, IEnumerable<Tax.TaxAdjustmentInput>? adjustments = null, long? userId = null)
    {
        access.Require(Perm.Appointments);
        var a = Get(appointmentId) ?? throw new HubException("not-found", "That booking was not found.");
        if (a.DocumentId is not null) throw new HubException("invoiced", "This visit was already invoiced.");
        if (a.Status is "cancelled" or "no-show") throw new HubException("status", "A cancelled booking has nothing to invoice.");
        var lines = new List<LineInput> { new() { ItemId = a.ItemId } };
        if (extras is not null) lines.AddRange(extras);
        var view = documents.Checkout(new CheckoutRequest { PartyId = a.PartyId, Lines = lines, Payments = payments.ToList(), Adjustments = adjustments?.ToList() ?? new(), UserId = userId, Notes = "Visit " + shop.Current.Time.ToLocal(a.Start).ToString("d MMM HH:mm", CultureInfo.InvariantCulture) });
        db.InTransaction((c, t) => HubDb.Exec(c, "UPDATE appointments SET status = 'done', document_id = $d WHERE id = $id", t, ("$d", view.Document.Id), ("$id", appointmentId)));
        return view;
    }

    /// <summary>What the visit would come to with these extras and adjustments (a tip), worked out by the tax engine, without keeping anything.</summary>
    public DocumentView Preview(long appointmentId, IEnumerable<LineInput>? extras, IEnumerable<Tax.TaxAdjustmentInput>? adjustments = null)
    {
        var a = Get(appointmentId) ?? throw new HubException("not-found", "That booking was not found.");
        var lines = new List<LineInput> { new() { ItemId = a.ItemId } };
        if (extras is not null) lines.AddRange(extras);
        var draft = documents.CreateDraft(new DraftOptions { PartyId = a.PartyId, Lines = lines, Adjustments = adjustments?.ToList() ?? new() });
        documents.Discard(draft.Document.Id);
        return draft;
    }

    public IReadOnlyList<StaffSales> SalesByStaff(DateTimeOffset from, DateTimeOffset to) => db.Query(
        "SELECT s.id, s.name, COUNT(*) AS visits, COALESCE(SUM(d.total_minor), 0) AS sales FROM appointments a JOIN parties s ON s.id = a.staff_id JOIN documents d ON d.id = a.document_id " +
        "WHERE d.status = 'issued' AND d.issued_at >= $f AND d.issued_at < $t GROUP BY s.id ORDER BY sales DESC",
        r => new StaffSales(r.Int("id"), r.Text("name"), (int)r.Int("visits"), r.Int("sales")), ("$f", Iso.Text(from)), ("$t", Iso.Text(to)));
}
