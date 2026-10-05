using System.Text.Json;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Shop;
using NextGenOS.Tax;

namespace NextGenOS.Hub.Restaurant;

public sealed record DiningTable(long Id, string Name, int Seats, string? Zone, bool Active);

/// <summary>A table as the floor plan shows it: free, or with an order open and how much it stands at.</summary>
public sealed record FloorTable(DiningTable Table, long? OrderId, string? OrderNumber, long TotalMinor, int ItemCount, int Guests, DateTimeOffset? Since)
{
    public bool Occupied => OrderId is not null;
}

public sealed record KitchenLine(long LineId, string Description, long QtyMilli, string? Note);

public sealed record KitchenTicket(long Id, long DocumentId, string OrderNumber, string? TableName, string Station, string Status, DateTimeOffset FiredAt, DateTimeOffset? ReadyAt, DateTimeOffset? ServedAt, int Seq, IReadOnlyList<KitchenLine> Lines);

/// <summary>Tables, open orders, the kitchen screen, service charge and tips, split bills.</summary>
public sealed class RestaurantService(HubDb db, ShopContextProvider shop, IClock clock, DocumentService documents, AuditService audit)
{
    public static readonly string[] TicketFlow = { "new", "preparing", "ready", "served" };

    // ---- tables ----------------------------------------------------------------------------------------------------------------

    public DiningTable AddTable(string name, int seats = 2, string? zone = null)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new HubException("name-missing", "Please give the table a name.");
        if (seats is < 1 or > 100) throw new HubException("seats", "Seats must be between 1 and 100.");
        try
        {
            var id = db.InTransaction((c, t) => HubDb.Insert(c, "INSERT INTO tables(name, seats, zone) VALUES ($n, $s, $z)", t, ("$n", name.Trim()), ("$s", seats), ("$z", string.IsNullOrWhiteSpace(zone) ? null : zone.Trim())));
            return Tables().First(x => x.Id == id);
        }
        catch (SqliteException ex) when (ex.SqliteErrorCode == 19)
        {
            throw new HubException("duplicate-table", $"There is already a table called {name.Trim()}.");
        }
    }

    public IReadOnlyList<DiningTable> Tables(bool includeInactive = false) => db.Query(
        "SELECT id, name, seats, zone, active FROM tables WHERE ($all = 1 OR active = 1) ORDER BY zone COLLATE NOCASE, length(name), name COLLATE NOCASE",
        r => new DiningTable(r.Int("id"), r.Text("name"), (int)r.Int("seats"), r.TextOrNull("zone"), r.Flag("active")), ("$all", includeInactive ? 1 : 0));

    public void RemoveTable(long tableId)
    {
        if (Convert.ToInt64(db.Scalar("SELECT COUNT(*) FROM documents WHERE table_id = $t AND status = 'open'", ("$t", tableId)) ?? 0L) > 0)
            throw new HubException("table-busy", "That table has an order open.");
        db.InTransaction((c, t) => HubDb.Exec(c, "UPDATE tables SET active = 0 WHERE id = $id", t, ("$id", tableId)));
    }

    /// <summary>The floor plan: every table with its open order, if any.</summary>
    public IReadOnlyList<FloorTable> Floor()
    {
        var open = db.Query(
            "SELECT d.id, d.number, d.table_id, d.total_minor, d.created_at, d.meta, (SELECT COUNT(*) FROM document_lines l WHERE l.document_id = d.id) AS n FROM documents d WHERE d.type = 'order' AND d.status = 'open' AND d.table_id IS NOT NULL",
            r => (Id: r.Int("id"), Number: r.TextOrNull("number"), Table: r.Int("table_id"), Total: r.Int("total_minor"), At: r.Time("created_at"), Meta: r.Text("meta"), Count: (int)r.Int("n")));
        return Tables().Select(table =>
        {
            var order = open.Where(o => o.Table == table.Id).OrderBy(o => o.Id).FirstOrDefault();
            if (order.Id == 0) return new FloorTable(table, null, null, 0, 0, 0, null);
            var meta = JsonSerializer.Deserialize<Dictionary<string, string>>(order.Meta) ?? new();
            return new FloorTable(table, order.Id, order.Number, open.Where(o => o.Table == table.Id).Sum(o => o.Total), order.Count, int.TryParse(meta.GetValueOrDefault("guests"), out var g) ? g : 0, order.At);
        }).ToList();
    }

    // ---- orders ----------------------------------------------------------------------------------------------------------------

    /// <summary>Seats guests at a table. If the table already has an order, that order is returned.</summary>
    public DocumentView OpenOrder(long tableId, int guests = 1, long? userId = null, long? partyId = null)
    {
        var table = Tables(true).FirstOrDefault(x => x.Id == tableId) ?? throw new HubException("table-not-found", "That table was not found.");
        if (!table.Active) throw new HubException("table-off", $"Table {table.Name} is not in use.");
        var existing = db.Query("SELECT id FROM documents WHERE type = 'order' AND status = 'open' AND table_id = $t ORDER BY id LIMIT 1", r => r.Int("id"), ("$t", tableId));
        if (existing.Count > 0) return documents.Get(existing[0])!;
        var view = documents.CreateDraft(new DraftOptions
        {
            Type = DocTypes.Order, TableId = tableId, UserId = userId, PartyId = partyId, Adjustments = DefaultAdjustments(),
            Meta = new Dictionary<string, string> { ["guests"] = Math.Max(1, guests).ToString(System.Globalization.CultureInfo.InvariantCulture) },
        });
        return view;
    }

    /// <summary>An order with no table: counter or takeaway.</summary>
    public DocumentView OpenTakeaway(string? name = null, long? userId = null)
    {
        var meta = new Dictionary<string, string> { ["takeaway"] = "1" };
        if (!string.IsNullOrWhiteSpace(name)) meta["name"] = name.Trim();
        return documents.CreateDraft(new DraftOptions { Type = DocTypes.Order, UserId = userId, Meta = meta, Adjustments = new List<TaxAdjustmentInput>() });
    }

    public DocumentView AddItem(long orderId, long itemId, long qtyMilli = 1000, string? note = null) =>
        documents.AddLine(orderId, new LineInput { ItemId = itemId, QtyMilli = qtyMilli, Note = note });

    public IReadOnlyList<DocumentView> OpenOrders() =>
        db.Query("SELECT id FROM documents WHERE type = 'order' AND status = 'open' ORDER BY id", r => r.Int("id")).Select(id => documents.Get(id)!).ToList();

    public DocumentView Transfer(long orderId, long toTableId)
    {
        var order = documents.GetHeader(orderId) ?? throw new HubException("not-found", "That order was not found.");
        if (order.Status != DocStatus.Open) throw new HubException("not-open", "That order is already closed.");
        if (db.Query("SELECT id FROM documents WHERE type = 'order' AND status = 'open' AND table_id = $t", r => r.Int("id"), ("$t", toTableId)).Count > 0)
            throw new HubException("table-busy", "That table already has an order. Move the guests there, or pick a free table.");
        db.InTransaction((c, t) => HubDb.Exec(c, "UPDATE documents SET table_id = $t WHERE id = $id", t, ("$t", toTableId), ("$id", orderId)));
        return documents.Get(orderId)!;
    }

    /// <summary>Cancels an open order. Tickets already sent to the kitchen are marked as served (so the kitchen screen clears) and the reason is kept.</summary>
    public void CancelOrder(long orderId, string reason, long? userId)
    {
        if (string.IsNullOrWhiteSpace(reason)) throw new HubException("reason", "Please say why.");
        var order = documents.GetHeader(orderId) ?? throw new HubException("not-found", "That order was not found.");
        if (order.Status != DocStatus.Open) throw new HubException("not-open", "That order is already closed.");
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE kitchen_tickets SET status = 'served', served_at = $at WHERE document_id = $id AND status <> 'served'", t, ("$at", Iso.Text(clock.UtcNow)), ("$id", orderId));
            HubDb.Exec(c, "UPDATE documents SET status = 'void', notes = COALESCE(notes || char(10), '') || $why WHERE id = $id", t, ("$why", "Cancelled: " + reason.Trim()), ("$id", orderId));
            audit.Log(c, t, userId, "order-cancelled", "document", orderId, reason.Trim());
        });
    }

    // ---- the kitchen -----------------------------------------------------------------------------------------------------------

    /// <summary>Sends the lines not yet sent to the kitchen: one ticket for each station (kitchen, bar). Returns the tickets made.</summary>
    public IReadOnlyList<KitchenTicket> Fire(long orderId, long? userId = null)
    {
        var context = shop.Current;
        var stations = context.Industry.Rules.ValueKind == JsonValueKind.Object && context.Industry.Rules.TryGetProperty("stations", out var s)
            ? s.EnumerateArray().Select(x => x.GetString() ?? "").Where(x => x.Length > 0).ToList() : new List<string> { "Kitchen" };
        var ids = db.InTransaction((c, t) =>
        {
            var status = HubDb.Scalar(c, "SELECT status FROM documents WHERE id = $id", t, ("$id", orderId)) as string ?? throw new HubException("not-found", "That order was not found.");
            if (status != DocStatus.Open) throw new HubException("not-open", "That order is already closed.");
            var unsent = HubDb.Query(c, "SELECT id, description, qty_milli, note, station, item_id FROM document_lines WHERE document_id = $id AND fired = 0 ORDER BY line_no",
                r => (Id: r.Int("id"), Desc: r.Text("description"), Qty: r.Int("qty_milli"), Note: r.TextOrNull("note"), Station: r.TextOrNull("station"), Item: r.IntOrNull("item_id")), t, ("$id", orderId));
            // Only dishes and drinks go to the kitchen: an item that keeps stock (a packet of coffee beans) is sold over the counter.
            var kitchenLines = unsent.Where(l => l.Item is null || Convert.ToInt64(HubDb.Scalar(c, "SELECT track_stock FROM items WHERE id = $i", t, ("$i", l.Item)) ?? 0L) == 0).ToList();
            if (kitchenLines.Count == 0) throw new HubException("nothing-new", "There is nothing new to send to the kitchen.");
            var made = new List<long>();
            var now = Iso.Text(clock.UtcNow);
            foreach (var group in kitchenLines.GroupBy(l => string.IsNullOrEmpty(l.Station) || !stations.Contains(l.Station!) ? stations[0] : l.Station!))
            {
                var seq = Convert.ToInt32(HubDb.Scalar(c, "SELECT COALESCE(MAX(seq), 0) + 1 FROM kitchen_tickets WHERE substr(fired_at, 1, 10) = substr($now, 1, 10)", t, ("$now", now)) ?? 1);
                var ticket = HubDb.Insert(c, "INSERT INTO kitchen_tickets(document_id, station, status, fired_at, seq) VALUES ($d, $s, 'new', $at, $seq)", t, ("$d", orderId), ("$s", group.Key), ("$at", now), ("$seq", seq));
                foreach (var l in group)
                    HubDb.Exec(c, "INSERT INTO kitchen_ticket_lines(ticket_id, line_id, description, qty_milli, note) VALUES ($t, $l, $d, $q, $n)", t, ("$t", ticket), ("$l", l.Id), ("$d", l.Desc), ("$q", l.Qty), ("$n", l.Note));
                made.Add(ticket);
            }
            HubDb.Exec(c, "UPDATE document_lines SET fired = 1 WHERE document_id = $id AND fired = 0", t, ("$id", orderId));
            return made;
        });
        return ids.Select(id => Ticket(id)!).ToList();
    }

    public KitchenTicket? Ticket(long id) => Tickets(null, true).FirstOrDefault(t => t.Id == id);

    /// <summary>Tickets for the kitchen screen, oldest first. Served tickets are left out unless asked for.</summary>
    public IReadOnlyList<KitchenTicket> Tickets(string? station = null, bool includeServed = false)
    {
        var rows = db.Query(
            "SELECT k.id, k.document_id, k.station, k.status, k.fired_at, k.ready_at, k.served_at, k.seq, d.number, d.meta, tb.name AS table_name " +
            "FROM kitchen_tickets k JOIN documents d ON d.id = k.document_id LEFT JOIN tables tb ON tb.id = d.table_id " +
            "WHERE ($s IS NULL OR k.station = $s) AND ($all = 1 OR k.status <> 'served') ORDER BY k.fired_at, k.id",
            r => (Id: r.Int("id"), Doc: r.Int("document_id"), Station: r.Text("station"), Status: r.Text("status"), Fired: r.Time("fired_at"), Ready: r.TimeOrNull("ready_at"),
                Served: r.TimeOrNull("served_at"), Seq: (int)r.Int("seq"), Number: r.TextOrNull("number"), Table: r.TextOrNull("table_name"), Meta: r.Text("meta")),
            ("$s", station), ("$all", includeServed ? 1 : 0));
        var lines = db.Query("SELECT ticket_id, line_id, description, qty_milli, note FROM kitchen_ticket_lines ORDER BY ticket_id, line_id",
            r => (Ticket: r.Int("ticket_id"), Line: new KitchenLine(r.Int("line_id"), r.Text("description"), r.Int("qty_milli"), r.TextOrNull("note"))));
        return rows.Select(r =>
        {
            var meta = JsonSerializer.Deserialize<Dictionary<string, string>>(r.Meta) ?? new();
            var label = r.Table ?? (meta.TryGetValue("name", out var n) ? "Takeaway: " + n : "Takeaway");
            return new KitchenTicket(r.Id, r.Doc, r.Number ?? "", label, r.Station, r.Status, r.Fired, r.Ready, r.Served, r.Seq, lines.Where(l => l.Ticket == r.Id).Select(l => l.Line).ToList());
        }).ToList();
    }

    /// <summary>Moves a ticket one step along: new → preparing → ready → served. Going back is not allowed; a mistake is fixed by a new ticket.</summary>
    public KitchenTicket Advance(long ticketId)
    {
        var ticket = Ticket(ticketId) ?? throw new HubException("not-found", "That ticket was not found.");
        var next = TicketFlow.ElementAtOrDefault(Array.IndexOf(TicketFlow, ticket.Status) + 1) ?? throw new HubException("ticket-done", "That ticket is already served.");
        db.InTransaction((c, t) => HubDb.Exec(c,
            "UPDATE kitchen_tickets SET status = $s, ready_at = CASE WHEN $s = 'ready' THEN $at ELSE ready_at END, served_at = CASE WHEN $s = 'served' THEN $at ELSE served_at END WHERE id = $id", t,
            ("$s", next), ("$at", Iso.Text(clock.UtcNow)), ("$id", ticketId)));
        return Ticket(ticketId)!;
    }

    // ---- the bill --------------------------------------------------------------------------------------------------------------

    /// <summary>The service charge the shop adds to a dine-in bill, as the tax engine takes it. Empty when the shop has none.</summary>
    public List<TaxAdjustmentInput> DefaultAdjustments() =>
        shop.Current.DefaultAdjustments().Where(a => a.Kind == "surcharge").Select(a => shop.Current.ToInput(a)).ToList();

    /// <summary>Sets what is added to the bill: the service charge on or off (a percent may be given to change it for this bill) and a tip.</summary>
    public DocumentView SetBillOptions(long orderId, bool serviceCharge, long tipMinor = 0, string? serviceChargePercent = null)
    {
        var adjustments = new List<TaxAdjustmentInput>();
        if (serviceCharge)
        {
            adjustments.AddRange(DefaultAdjustments());
            if (serviceChargePercent is not null) foreach (var a in adjustments.Where(a => a.Kind == "surcharge")) a.Percent = serviceChargePercent;
        }
        if (tipMinor < 0) throw new HubException("tip", "A tip cannot be negative.");
        if (tipMinor > 0) adjustments.Add(new TaxAdjustmentInput { Code = "TIP", Kind = "tip", Label = "Tip", Amount = shop.Current.Text(tipMinor) });
        return documents.SetAdjustments(orderId, adjustments);
    }

    /// <summary>A tip of a percent of the bill before tax, in minor units.</summary>
    public long TipFromPercent(long orderId, decimal percent)
    {
        var view = documents.Get(orderId) ?? throw new HubException("not-found", "That order was not found.");
        var taxable = view.Document.SubtotalMinor;
        return (long)Math.Round(taxable * percent / 100m, 0, MidpointRounding.AwayFromZero);
    }

    /// <summary>Closes the bill: the order becomes a numbered invoice, the payments are recorded, the table is free again.</summary>
    public DocumentView Pay(long orderId, IEnumerable<PaymentInput> payments, long? userId = null) =>
        documents.Issue(orderId, new IssueOptions { Payments = payments.ToList(), UserId = userId });

    /// <summary>Splits a payment equally between people: the amounts add up to exactly the total (the first people pay the odd cents).</summary>
    public static IReadOnlyList<long> EqualParts(long amountMinor, int people)
    {
        if (people < 1) throw new HubException("people", "At least one person pays.");
        var each = amountMinor / people;
        var extra = (int)(amountMinor % people);
        return Enumerable.Range(0, people).Select(i => each + (i < extra ? 1 : 0)).ToList();
    }

    /// <summary>Splits by items: each group of lines becomes an order of its own at the same table, to be paid separately.</summary>
    public IReadOnlyList<DocumentView> SplitByLines(long orderId, IReadOnlyList<IReadOnlyList<long>> groups, long? userId = null)
    {
        if (groups.Count == 0 || groups.Any(g => g.Count == 0)) throw new HubException("empty-group", "Every part of the bill needs at least one item.");
        var all = groups.SelectMany(g => g).ToList();
        if (all.Distinct().Count() != all.Count) throw new HubException("line-twice", "An item can be on one part of the bill only.");
        var created = new List<long>();
        db.InTransaction((c, t) =>
        {
            var header = HubDb.Query(c, "SELECT table_id, party_id, meta, adjustments FROM documents WHERE id = $id AND type = 'order' AND status = 'open'",
                r => (Table: r.IntOrNull("table_id"), Party: r.IntOrNull("party_id"), Meta: r.Text("meta"), Adj: r.Text("adjustments")), t, ("$id", orderId)).SingleOrDefault();
            if (header.Meta is null) throw new HubException("not-open", "That order is not open.");
            var own = HubDb.Query(c, "SELECT id FROM document_lines WHERE document_id = $id", r => r.Int("id"), t, ("$id", orderId)).ToHashSet();
            if (all.Any(l => !own.Contains(l))) throw new HubException("line", "One of those items is not on this order.");
            foreach (var group in groups)
            {
                var id = documents.CreateDraft(c, t, new DraftOptions
                {
                    Type = DocTypes.Order, TableId = header.Table, PartyId = header.Party, UserId = userId,
                    Adjustments = JsonSerializer.Deserialize<List<TaxAdjustmentInput>>(header.Adj, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }) ?? new(),
                    Meta = new Dictionary<string, string>(JsonSerializer.Deserialize<Dictionary<string, string>>(header.Meta) ?? new()) { ["splitFrom"] = orderId.ToString(System.Globalization.CultureInfo.InvariantCulture) },
                });
                foreach (var lineId in group)
                    HubDb.Exec(c, "UPDATE document_lines SET document_id = $new WHERE id = $l", t, ("$new", id), ("$l", lineId));
                documents.Recalculate(c, t, id);
                created.Add(id);
            }
            if (HubDb.Scalar(c, "SELECT COUNT(*) FROM document_lines WHERE document_id = $id", t, ("$id", orderId)) is long n && n == 0)
                HubDb.Exec(c, "UPDATE documents SET status = 'void', notes = 'Split into separate bills' WHERE id = $id", t, ("$id", orderId));
            else documents.Recalculate(c, t, orderId);
        });
        return created.Select(id => documents.Get(id)!).ToList();
    }

    // ---- reports ---------------------------------------------------------------------------------------------------------------

    /// <summary>For each table: how many bills were paid in the period and how long they stayed on average.</summary>
    public IReadOnlyList<TableTurnover> Turnover(DateTimeOffset from, DateTimeOffset to) => db.Query(
        "SELECT tb.name, COUNT(*) AS bills, COALESCE(SUM(d.total_minor), 0) AS sales, AVG((julianday(d.issued_at) - julianday(d.created_at)) * 24 * 60) AS minutes " +
        "FROM documents d JOIN tables tb ON tb.id = d.table_id WHERE d.type = 'invoice' AND d.status = 'issued' AND d.issued_at >= $f AND d.issued_at < $t GROUP BY tb.id ORDER BY sales DESC",
        r => new TableTurnover(r.Text("name"), (int)r.Int("bills"), r.Int("sales"), r.IsDBNull(r.GetOrdinal("minutes")) ? 0 : (int)Math.Round(r.GetDouble(r.GetOrdinal("minutes")))),
        ("$f", Iso.Text(from)), ("$t", Iso.Text(to)));
}

public sealed record TableTurnover(string Table, int Bills, long SalesMinor, int AverageMinutes);
