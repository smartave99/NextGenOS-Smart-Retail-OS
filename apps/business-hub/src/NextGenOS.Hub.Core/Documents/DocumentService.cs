using System.Globalization;
using System.Text.Json;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Shop;
using NextGenOS.Tax;
using NewtonJson = Newtonsoft.Json.JsonConvert;

namespace NextGenOS.Hub.Documents;

/// <summary>
/// Invoices, quotes, orders, credit notes, purchases and progress bills. One place does the money: it builds the lines, asks the tax engine for the
/// amounts (so every country is right to the last cent), keeps the answer with the document, takes payments, moves stock and numbers the document.
/// </summary>
public sealed class DocumentService(HubDb db, ShopContextProvider shop, IClock clock, Numbering numbering, CatalogService catalog, PartyService parties, AuditService audit)
{
    private const string DocColumns =
        "id, type, number, status, direction, party_id, issued_at, created_at, due_at, currency_decimals, prices_include_tax, seller_region, buyer_region, round_total, registered, " +
        "subtotal_minor, tax_minor, total_minor, payable_minor, paid_minor, tips_minor, retention_minor, advance_minor, table_id, project_id, ref_document_id, user_id, notes, meta";

    private const string LineColumns = "id, line_no, item_id, description, qty_milli, unit, unit_price_minor, discount_pct_milli, tax_code, customer_discount, fired, note, station, boq_id";

    private static readonly JsonSerializerOptions Json = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    // ---- reading ---------------------------------------------------------------------------------------------------------------

    private static Document MapDoc(SqliteDataReader r) => new(
        r.Int("id"), r.Text("type"), r.TextOrNull("number"), r.Text("status"), r.Text("direction"), r.IntOrNull("party_id"), r.TimeOrNull("issued_at"), r.Time("created_at"),
        r.TimeOrNull("due_at"), (int)r.Int("currency_decimals"), r.Flag("prices_include_tax"), r.TextOrNull("seller_region"), r.TextOrNull("buyer_region"), r.Flag("round_total"),
        r.Flag("registered"), r.Int("subtotal_minor"), r.Int("tax_minor"), r.Int("total_minor"), r.Int("payable_minor"), r.Int("paid_minor"), r.Int("tips_minor"),
        r.Int("retention_minor"), r.Int("advance_minor"), r.IntOrNull("table_id"), r.IntOrNull("project_id"), r.IntOrNull("ref_document_id"), r.IntOrNull("user_id"),
        r.TextOrNull("notes"), JsonSerializer.Deserialize<Dictionary<string, string>>(r.Text("meta")) ?? new Dictionary<string, string>());

    private static DocLine MapLine(SqliteDataReader r) => new(
        r.Int("id"), (int)r.Int("line_no"), r.IntOrNull("item_id"), r.Text("description"), r.Int("qty_milli"), r.TextOrNull("unit"), r.Int("unit_price_minor"),
        r.Int("discount_pct_milli"), r.Text("tax_code"), r.TextOrNull("customer_discount"), r.Flag("fired"), r.TextOrNull("note"), r.TextOrNull("station"), r.IntOrNull("boq_id"));

    public Document? GetHeader(long id) => db.QueryOne($"SELECT {DocColumns} FROM documents WHERE id = $id", MapDoc, ("$id", id));

    public Document? GetHeaderByNumber(string number) => db.QueryOne($"SELECT {DocColumns} FROM documents WHERE number = $n", MapDoc, ("$n", number));

    public DocumentView? Get(long id)
    {
        var header = GetHeader(id);
        if (header is null) return null;
        var lines = db.Query($"SELECT {LineColumns} FROM document_lines WHERE document_id = $id ORDER BY line_no", MapLine, ("$id", id));
        var payments = Payments(id);
        var adjustments = JsonSerializer.Deserialize<List<TaxAdjustmentInput>>(db.Scalar("SELECT adjustments FROM documents WHERE id = $id", ("$id", id)) as string ?? "[]", Json) ?? new List<TaxAdjustmentInput>();
        var resultText = db.Scalar("SELECT result FROM documents WHERE id = $id", ("$id", id)) as string;
        var result = resultText is null ? null : NewtonJson.DeserializeObject<TaxResult>(resultText);
        var party = header.PartyId is { } pid ? parties.Get(pid) : null;
        return new DocumentView(header, party, lines, adjustments, result, payments);
    }

    public IReadOnlyList<PaymentRow> Payments(long documentId) => db.Query(
        "SELECT id, document_id, method, amount_minor, reference, at, kind, user_id FROM payments WHERE document_id = $id ORDER BY id",
        r => new PaymentRow(r.Int("id"), r.IntOrNull("document_id"), r.Text("method"), r.Int("amount_minor"), r.TextOrNull("reference"), r.Time("at"), r.Text("kind"), r.IntOrNull("user_id")), ("$id", documentId));

    public IReadOnlyList<Document> List(DocumentFilter filter)
    {
        var text = (filter.Text ?? "").Trim();
        var like = "%" + text.Replace("%", "\\%").Replace("_", "\\_") + "%";
        return db.Query(
            $"SELECT {DocColumns} FROM documents d WHERE ($type IS NULL OR type = $type) AND ($status IS NULL OR status = $status) AND ($party IS NULL OR party_id = $party) " +
            "AND ($project IS NULL OR project_id = $project) AND ($from IS NULL OR COALESCE(issued_at, created_at) >= $from) AND ($to IS NULL OR COALESCE(issued_at, created_at) < $to) " +
            "AND ($unpaid = 0 OR (status = 'issued' AND paid_minor < payable_minor)) " +
            "AND ($t = '' OR number LIKE $like ESCAPE '\\' OR EXISTS (SELECT 1 FROM parties p WHERE p.id = d.party_id AND p.name LIKE $like ESCAPE '\\')) " +
            "ORDER BY COALESCE(issued_at, created_at) DESC, id DESC LIMIT $limit", MapDoc,
            ("$type", filter.Type), ("$status", filter.Status), ("$party", filter.PartyId), ("$project", filter.ProjectId),
            ("$from", filter.From is { } f ? Iso.Text(f) : null), ("$to", filter.To is { } to ? Iso.Text(to) : null), ("$unpaid", filter.OnlyUnpaid ? 1 : 0),
            ("$t", text), ("$like", like), ("$limit", filter.Limit));
    }

    // ---- drafts ----------------------------------------------------------------------------------------------------------------

    /// <summary>Starts an open document (an order, a quote, a bill being built). Lines and adjustments may be given at once.</summary>
    public DocumentView CreateDraft(DraftOptions options)
    {
        var id = db.InTransaction((c, t) => CreateDraft(c, t, options));
        return Get(id)!;
    }

    public long CreateDraft(SqliteConnection c, SqliteTransaction t, DraftOptions options)
    {
        var context = shop.Current;
        var party = options.PartyId is { } pid ? parties.Get(pid) ?? throw new HubException("party-not-found", "That customer was not found.") : null;
        var now = clock.UtcNow;
        var number = options.Type is DocTypes.Order or DocTypes.Quote or DocTypes.Purchase ? numbering.Next(c, t, options.Type, now) : null;
        var meta = new Dictionary<string, string>(options.Meta);
        var id = HubDb.Insert(c,
            "INSERT INTO documents(type, number, status, direction, party_id, created_at, currency_decimals, prices_include_tax, seller_region, buyer_region, round_total, registered, " +
            "adjustments, table_id, project_id, ref_document_id, user_id, notes, meta) " +
            "VALUES ($type, $number, 'open', $dir, $party, $at, $dec, $incl, $seller, $buyer, $round, $reg, $adj, $table, $project, $ref, $user, $notes, $meta)", t,
            ("$type", options.Type), ("$number", number), ("$dir", options.Direction), ("$party", options.PartyId), ("$at", Iso.Text(now)), ("$dec", context.Decimals),
            ("$incl", (options.PricesIncludeTax ?? context.Settings.PricesIncludeTax) ? 1 : 0), ("$seller", Blank(context.Settings.Region)), ("$buyer", Blank(party?.Region)),
            ("$round", context.Settings.RoundTotal ? 1 : 0), ("$reg", context.Settings.TaxRegistered ? 1 : 0),
            ("$adj", JsonSerializer.Serialize(options.Adjustments, Json)), ("$table", options.TableId), ("$project", options.ProjectId), ("$ref", options.RefDocumentId),
            ("$user", options.UserId), ("$notes", options.Notes), ("$meta", JsonSerializer.Serialize(meta)));
        foreach (var line in options.Lines) AddLine(c, t, id, line, party);
        Recalculate(c, t, id);
        return id;
    }

    public DocumentView AddLine(long documentId, LineInput input)
    {
        db.InTransaction((c, t) =>
        {
            RequireOpen(c, t, documentId);
            var partyId = HubDb.Scalar(c, "SELECT party_id FROM documents WHERE id = $id", t, ("$id", documentId)) as long?;
            AddLine(c, t, documentId, input, partyId is { } p ? parties.Get(p) : null);
            Recalculate(c, t, documentId);
        });
        return Get(documentId)!;
    }

    private void AddLine(SqliteConnection c, SqliteTransaction t, long documentId, LineInput input, Party? party)
    {
        var context = shop.Current;
        Item? item = null;
        if (input.ItemId is { } iid) item = catalog.Get(iid) ?? throw new HubException("item-not-found", "That item was not found.");
        if (item is { Active: false }) throw new HubException("item-inactive", $"{item.Name} is no longer sold.");
        var description = !string.IsNullOrWhiteSpace(input.Description) ? input.Description.Trim() : item?.Name ?? throw new HubException("description-missing", "Please describe the line.");
        if (input.QtyMilli <= 0) throw new HubException("qty", "The quantity must be more than zero.");
        if (input.QtyMilli % 1000 != 0 && !context.Features.WeighedItems && input.ItemId is not null && item?.Unit is "pc" or "plate" or "cup" or "glass")
            throw new HubException("qty-whole", $"{description} is sold in whole numbers.");
        var price = input.UnitPriceMinor ?? item?.PriceFor(party?.PriceLevel ?? "retail") ?? throw new HubException("price-missing", "Please give a price.");
        if (price < 0) throw new HubException("price", "A price cannot be negative.");
        if (input.DiscountPctMilli is < 0 or > 100_000) throw new HubException("discount", "A discount must be between 0 and 100 percent.");
        string taxCode;
        try { taxCode = context.TaxCode(input.TaxCode ?? item?.TaxCode ?? "standard"); }
        catch (ArgumentException ex) { throw new HubException("tax", ex.Message); }
        if (!string.IsNullOrEmpty(input.CustomerDiscount) && !(context.Country.Tax.CustomerDiscounts ?? new()).Any(d => d.Code == input.CustomerDiscount))
            throw new HubException("customer-discount", $"\"{input.CustomerDiscount}\" is not a discount of {context.Country.Name}.");
        var lineNo = Convert.ToInt32(HubDb.Scalar(c, "SELECT COALESCE(MAX(line_no), 0) + 1 FROM document_lines WHERE document_id = $id", t, ("$id", documentId)) ?? 1);
        HubDb.Exec(c,
            "INSERT INTO document_lines(document_id, line_no, item_id, description, qty_milli, unit, unit_price_minor, discount_pct_milli, tax_code, customer_discount, note, station, boq_id) " +
            "VALUES ($d, $n, $item, $desc, $q, $unit, $price, $disc, $tax, $cd, $note, $station, $boq)", t,
            ("$d", documentId), ("$n", lineNo), ("$item", item?.Id), ("$desc", description), ("$q", input.QtyMilli), ("$unit", input.Unit ?? item?.Unit), ("$price", price),
            ("$disc", input.DiscountPctMilli), ("$tax", taxCode), ("$cd", Blank(input.CustomerDiscount)), ("$note", Blank(input.Note)), ("$station", input.Station ?? item?.Station), ("$boq", input.BoqId));
    }

    public DocumentView UpdateLine(long documentId, long lineId, long? qtyMilli = null, long? discountPctMilli = null, string? note = null, string? customerDiscount = null, bool clearCustomerDiscount = false)
    {
        db.InTransaction((c, t) =>
        {
            RequireOpen(c, t, documentId);
            if (qtyMilli is <= 0) throw new HubException("qty", "The quantity must be more than zero.");
            if (discountPctMilli is < 0 or > 100_000) throw new HubException("discount", "A discount must be between 0 and 100 percent.");
            HubDb.Exec(c,
                "UPDATE document_lines SET qty_milli = COALESCE($q, qty_milli), discount_pct_milli = COALESCE($d, discount_pct_milli), note = COALESCE($n, note), " +
                "customer_discount = CASE WHEN $clear = 1 THEN NULL ELSE COALESCE($cd, customer_discount) END WHERE id = $id AND document_id = $doc", t,
                ("$q", qtyMilli), ("$d", discountPctMilli), ("$n", note), ("$cd", Blank(customerDiscount)), ("$clear", clearCustomerDiscount ? 1 : 0), ("$id", lineId), ("$doc", documentId));
            Recalculate(c, t, documentId);
        });
        return Get(documentId)!;
    }

    public DocumentView RemoveLine(long documentId, long lineId)
    {
        db.InTransaction((c, t) =>
        {
            RequireOpen(c, t, documentId);
            if (Convert.ToInt64(HubDb.Scalar(c, "SELECT fired FROM document_lines WHERE id = $id AND document_id = $doc", t, ("$id", lineId), ("$doc", documentId)) ?? 0L) != 0)
                throw new HubException("already-sent", "That line was already sent to the kitchen. Void the bill, or tell the kitchen, instead.");
            HubDb.Exec(c, "DELETE FROM document_lines WHERE id = $id AND document_id = $doc", t, ("$id", lineId), ("$doc", documentId));
            Recalculate(c, t, documentId);
        });
        return Get(documentId)!;
    }

    public DocumentView SetAdjustments(long documentId, IEnumerable<TaxAdjustmentInput> adjustments)
    {
        db.InTransaction((c, t) =>
        {
            RequireOpen(c, t, documentId);
            HubDb.Exec(c, "UPDATE documents SET adjustments = $a WHERE id = $id", t, ("$a", JsonSerializer.Serialize(adjustments.ToList(), Json)), ("$id", documentId));
            Recalculate(c, t, documentId);
        });
        return Get(documentId)!;
    }

    public DocumentView SetParty(long documentId, long? partyId)
    {
        db.InTransaction((c, t) =>
        {
            RequireOpen(c, t, documentId);
            var party = partyId is { } p ? parties.Get(p) ?? throw new HubException("party-not-found", "That customer was not found.") : null;
            HubDb.Exec(c, "UPDATE documents SET party_id = $p, buyer_region = $r WHERE id = $id", t, ("$p", partyId), ("$r", Blank(party?.Region)), ("$id", documentId));
            // Prices follow the customer's price level: lines taken from an item are priced again for the new customer.
            if (party is not null)
            {
                foreach (var (lineId, itemId) in HubDb.Query(c, "SELECT id, item_id FROM document_lines WHERE document_id = $id AND item_id IS NOT NULL", r => (r.Int("id"), r.Int("item_id")), t, ("$id", documentId)))
                {
                    var item = catalog.Get(itemId);
                    if (item is not null) HubDb.Exec(c, "UPDATE document_lines SET unit_price_minor = $p WHERE id = $id", t, ("$p", item.PriceFor(party.PriceLevel)), ("$id", lineId));
                }
            }
            Recalculate(c, t, documentId);
        });
        return Get(documentId)!;
    }

    // ---- the money -------------------------------------------------------------------------------------------------------------

    /// <summary>Works the amounts out again with the tax engine and keeps them (and the engine's full answer) with the document.</summary>
    public void Recalculate(SqliteConnection c, SqliteTransaction t, long documentId)
    {
        var context = shop.Current;
        var header = HubDb.Query(c, $"SELECT {DocColumns} FROM documents WHERE id = $id", MapDoc, t, ("$id", documentId)).Single();
        var lines = HubDb.Query(c, $"SELECT {LineColumns} FROM document_lines WHERE document_id = $id ORDER BY line_no", MapLine, t, ("$id", documentId));
        var adjustments = JsonSerializer.Deserialize<List<TaxAdjustmentInput>>(HubDb.Scalar(c, "SELECT adjustments FROM documents WHERE id = $id", t, ("$id", documentId)) as string ?? "[]", Json) ?? new();
        var result = Calculate(context, header, lines, adjustments);
        var totals = result.Totals;
        long Minor(string text) => (long)MoneyText.Parse(text, header.CurrencyDecimals);
        var tax = totals.Components.Sum(x => Minor(x.Amount)) + Minor(totals.Cess);
        HubDb.Exec(c,
            "UPDATE documents SET result = $r, subtotal_minor = $sub, tax_minor = $tax, total_minor = $total, payable_minor = $pay, tips_minor = $tips, retention_minor = $ret, advance_minor = $adv WHERE id = $id", t,
            ("$r", NewtonJson.SerializeObject(result)), ("$sub", Minor(totals.Taxable)), ("$tax", tax), ("$total", Minor(totals.GrandTotal)), ("$pay", Minor(totals.Payable)),
            ("$tips", Minor(totals.Tips)), ("$ret", Minor(totals.Retention)), ("$adv", Minor(totals.Advances)), ("$id", documentId));
    }

    /// <summary>The tax engine's answer for a document's lines (also used to show a total before anything is saved).</summary>
    public static TaxResult Calculate(ShopContext context, Document header, IReadOnlyList<DocLine> lines, IReadOnlyList<TaxAdjustmentInput> adjustments)
    {
        var d = header.CurrencyDecimals;
        var taxContext = new TaxContext
        {
            PricesIncludeTax = header.PricesIncludeTax, SellerRegion = header.SellerRegion, BuyerRegion = header.BuyerRegion, Registered = header.Registered, RoundTotal = header.RoundTotal,
        };
        var input = lines.Select(l => new TaxLineInput
        {
            Name = l.Description, Qty = MoneyText.Minor(l.QtyMilli, 3), UnitPrice = MoneyText.Minor(l.UnitPriceMinor, d), TaxCode = l.TaxCode,
            DiscountPercent = l.DiscountPctMilli > 0 ? MoneyText.Minor(l.DiscountPctMilli, 3) : null, CustomerDiscount = l.CustomerDiscount,
        }).ToList();
        // A regional country (Canada, the US) needs a region to tax by: the shop's own when the buyer's is not known.
        if (context.Country.Tax.Model == "regional" && string.IsNullOrEmpty(taxContext.SellerRegion) && string.IsNullOrEmpty(taxContext.BuyerRegion))
            taxContext.SellerRegion = context.Country.Tax.Regions?.List?.FirstOrDefault()?.Code;
        return TaxEngine.Calculate(context.Country, taxContext, input, adjustments.ToList());
    }

    // ---- issuing ---------------------------------------------------------------------------------------------------------------

    /// <summary>Makes an open document final: numbers it, takes the payments, moves the stock. After this its amounts never change.</summary>
    public DocumentView Issue(long documentId, IssueOptions? options = null)
    {
        options ??= new IssueOptions();
        var id = db.InTransaction((c, t) => Issue(c, t, documentId, options));
        return Get(id)!;
    }

    public long Issue(SqliteConnection c, SqliteTransaction t, long documentId, IssueOptions options)
    {
        var context = shop.Current;
        var header = HubDb.Query(c, $"SELECT {DocColumns} FROM documents WHERE id = $id", MapDoc, t, ("$id", documentId)).SingleOrDefault()
            ?? throw new HubException("not-found", "That document was not found.");
        if (header.Status != DocStatus.Open) throw new HubException("not-open", "That document is already final.");
        var lines = HubDb.Query(c, $"SELECT {LineColumns} FROM document_lines WHERE document_id = $id ORDER BY line_no", MapLine, t, ("$id", documentId));
        var adjustments = JsonSerializer.Deserialize<List<TaxAdjustmentInput>>(HubDb.Scalar(c, "SELECT adjustments FROM documents WHERE id = $id", t, ("$id", documentId)) as string ?? "[]", Json) ?? new();
        var hasValue = lines.Count > 0 || adjustments.Any(a => a.Kind is "surcharge" or "fee");
        if (!hasValue) throw new HubException("empty", "There is nothing on this bill yet.");
        Recalculate(c, t, documentId);
        header = HubDb.Query(c, $"SELECT {DocColumns} FROM documents WHERE id = $id", MapDoc, t, ("$id", documentId)).Single();

        var type = header.Type == DocTypes.Order ? DocTypes.Invoice : header.Type;
        var now = clock.UtcNow;
        var meta = new Dictionary<string, string>(header.Meta);
        if (header.Type == DocTypes.Order && header.Number is not null) meta["orderNumber"] = header.Number;
        // A quote and a purchase order keep the number they were given when they were started.
        var number = type is DocTypes.Quote or DocTypes.Purchase ? header.Number : numbering.Next(c, t, type, now);

        // payments
        var payable = header.PayableMinor;
        var tendered = options.Payments.Where(p => p.AmountMinor > 0).ToList();
        var paid = tendered.Sum(p => p.AmountMinor);
        long change = 0;
        if (paid > payable)
        {
            change = paid - payable;
            var cash = tendered.Where(p => p.Method == "cash").Sum(p => p.AmountMinor);
            if (change > cash) throw new HubException("overpaid", "More was paid than the bill, and the extra is not in cash, so there is no change to give.");
            ReduceCash(tendered, change);
            paid = payable;
            meta["changeGiven"] = change.ToString(CultureInfo.InvariantCulture);
            meta["tendered"] = (paid + change).ToString(CultureInfo.InvariantCulture);
        }

        DateTimeOffset? due = null;
        if (header.Direction == "out" && type != DocTypes.Quote && paid < payable && options.OnAccount)
        {
            var client = header.PartyId is { } cid ? parties.Get(cid) : null;
            if (client is null) throw new HubException("no-party", "A bill on account needs a client.");
            due = now.AddDays(options.TermsDays ?? (client.TermsDays > 0 ? client.TermsDays : (int)context.Rule("paymentTermsDays", context.Rule("creditDays", 30))));
        }
        else if (header.Direction == "out" && type != DocTypes.Quote && paid < payable)
        {
            if (!options.OnCredit) throw new HubException("short", $"The payments ({context.Money(paid)}) do not cover the bill ({context.Money(payable)}).");
            var party = header.PartyId is { } pid ? parties.Get(pid) : null;
            if (!context.Features.Credit || party is null || party.CreditLimitMinor <= 0)
                throw new HubException("no-credit", "This customer has no credit. Take the full payment, or give the customer a credit limit first.");
            var owed = Outstanding(c, t, party.Id);
            if (owed + (payable - paid) > party.CreditLimitMinor)
                throw new HubException("over-limit", $"{party.Name} would owe {context.Money(owed + payable - paid)}, above the credit limit of {context.Money(party.CreditLimitMinor)}.");
            due = now.AddDays(party.TermsDays > 0 ? party.TermsDays : (int)context.Rule("creditDays", 30));
        }

        HubDb.Exec(c,
            "UPDATE documents SET type = $type, number = $number, status = 'issued', issued_at = $at, due_at = $due, meta = $meta, user_id = COALESCE($user, user_id) WHERE id = $id", t,
            ("$type", type), ("$number", number), ("$at", Iso.Text(now)), ("$due", due is { } dv ? Iso.Text(dv) : null), ("$meta", JsonSerializer.Serialize(meta)), ("$user", options.UserId), ("$id", documentId));

        foreach (var p in tendered) InsertPayment(c, t, documentId, header.PartyId, header.ProjectId, p, options.UserId, "payment", now);
        HubDb.Exec(c, "UPDATE documents SET paid_minor = $paid WHERE id = $id", t, ("$paid", tendered.Sum(p => p.AmountMinor)), ("$id", documentId));

        if (type == DocTypes.Invoice && header.Direction == "out") MoveStock(c, t, header.Id, lines, -1, "sale", options.UserId, now);
        if (type == DocTypes.Purchase) MoveStock(c, t, header.Id, lines, +1, "purchase", options.UserId, now);
        audit.Log(c, t, options.UserId, "issue", "document", documentId, number);
        return documentId;
    }

    /// <summary>Builds and finishes a counter sale in one step: the lines, the adjustments (service charge ...) and the payments.</summary>
    public DocumentView Checkout(CheckoutRequest request)
    {
        var id = db.InTransaction((c, t) =>
        {
            var draftId = CreateDraft(c, t, new DraftOptions
            {
                Type = request.Type, PartyId = request.PartyId, UserId = request.UserId, Notes = request.Notes, Lines = request.Lines, Adjustments = request.Adjustments,
            });
            return Issue(c, t, draftId, new IssueOptions { Payments = request.Payments, UserId = request.UserId, OnCredit = request.OnCredit });
        });
        return Get(id)!;
    }

    /// <summary>Throws away a sale that was started and never finished. Only an open invoice or quote with nothing sent to a kitchen can go; anything else is voided or cancelled by its own screen.</summary>
    public void Discard(long documentId)
    {
        db.InTransaction((c, t) =>
        {
            var row = HubDb.Query(c, "SELECT type, status, number FROM documents WHERE id = $id", r => (Type: r.Text("type"), Status: r.Text("status"), Number: r.TextOrNull("number")), t, ("$id", documentId)).FirstOrDefault();
            if (row.Type is null) return;
            if (row.Status != DocStatus.Open || row.Number is not null || row.Type is not (DocTypes.Invoice or DocTypes.Quote))
                throw new HubException("not-draft", "Only a sale that was never finished can be thrown away.");
            HubDb.Exec(c, "DELETE FROM document_lines WHERE document_id = $id", t, ("$id", documentId));
            HubDb.Exec(c, "DELETE FROM documents WHERE id = $id", t, ("$id", documentId));
        });
    }

    /// <summary>Clears sales left open for more than a day (the till was closed in the middle of one). Returns how many went.</summary>
    public int DiscardStaleDrafts()
    {
        var cutoff = Iso.Text(clock.UtcNow.AddDays(-1));
        return db.InTransaction((c, t) =>
        {
            var ids = HubDb.Query(c, "SELECT id FROM documents WHERE status = 'open' AND number IS NULL AND type IN ('invoice','quote') AND project_id IS NULL AND created_at < $cut", r => r.Int("id"), t, ("$cut", cutoff));
            foreach (var id in ids)
            {
                HubDb.Exec(c, "DELETE FROM document_lines WHERE document_id = $id", t, ("$id", id));
                HubDb.Exec(c, "DELETE FROM documents WHERE id = $id", t, ("$id", id));
            }
            return ids.Count;
        });
    }

    // ---- payments, voiding, credit notes ---------------------------------------------------------------------------------------

    /// <summary>Takes a payment on an issued document (a customer settling an invoice). Returns the document with the payment added.</summary>
    public DocumentView AddPayment(long documentId, PaymentInput payment, long? userId = null)
    {
        db.InTransaction((c, t) =>
        {
            var header = HubDb.Query(c, $"SELECT {DocColumns} FROM documents WHERE id = $id", MapDoc, t, ("$id", documentId)).SingleOrDefault() ?? throw new HubException("not-found", "That document was not found.");
            if (header.Status != DocStatus.Issued) throw new HubException("not-final", "Payments are taken on final documents only.");
            if (payment.AmountMinor <= 0) throw new HubException("amount", "The amount must be more than zero.");
            if (payment.AmountMinor > header.BalanceMinor) throw new HubException("too-much", $"Only {shop.Current.Money(header.BalanceMinor)} is still owed on this document.");
            InsertPayment(c, t, documentId, header.PartyId, header.ProjectId, payment, userId, "payment", clock.UtcNow);
            HubDb.Exec(c, "UPDATE documents SET paid_minor = paid_minor + $a WHERE id = $id", t, ("$a", payment.AmountMinor), ("$id", documentId));
        });
        return Get(documentId)!;
    }

    /// <summary>Cancels a document. Stock comes back; money that was paid is refunded by the method given.</summary>
    public DocumentView Void(long documentId, string reason, long? userId, string refundMethod = "cash")
    {
        if (string.IsNullOrWhiteSpace(reason)) throw new HubException("reason", "Please say why.");
        db.InTransaction((c, t) =>
        {
            var header = HubDb.Query(c, $"SELECT {DocColumns} FROM documents WHERE id = $id", MapDoc, t, ("$id", documentId)).SingleOrDefault() ?? throw new HubException("not-found", "That document was not found.");
            if (header.Status == DocStatus.Void) throw new HubException("already-void", "That document is already void.");
            if (HubDb.Scalar(c, "SELECT 1 FROM documents WHERE ref_document_id = $id AND type = 'credit-note' AND status = 'issued' LIMIT 1", t, ("$id", documentId)) is not null)
                throw new HubException("has-credit-note", "A credit note was already made for this document. Cancel it through another credit note.");
            if (header.Status == DocStatus.Issued)
            {
                var lines = HubDb.Query(c, $"SELECT {LineColumns} FROM document_lines WHERE document_id = $id ORDER BY line_no", MapLine, t, ("$id", documentId));
                var sign = header.Type == DocTypes.Invoice && header.Direction == "out" ? 1 : header.Type == DocTypes.Purchase ? -1 : 0;
                if (sign != 0) MoveStock(c, t, documentId, lines, sign, "void", userId, clock.UtcNow);
                if (header.PaidMinor > 0)
                {
                    InsertPayment(c, t, documentId, header.PartyId, header.ProjectId, new PaymentInput { Method = refundMethod, AmountMinor = header.PaidMinor, Reference = "void" }, userId, "refund", clock.UtcNow, negative: true);
                    HubDb.Exec(c, "UPDATE documents SET paid_minor = 0 WHERE id = $id", t, ("$id", documentId));
                }
            }
            HubDb.Exec(c, "UPDATE documents SET status = 'void', notes = COALESCE(notes || char(10), '') || $why WHERE id = $id", t, ("$why", "Void: " + reason.Trim()), ("$id", documentId));
            audit.Log(c, t, userId, "void", "document", documentId, reason.Trim());
        });
        return Get(documentId)!;
    }

    /// <summary>A credit note for some or all of an issued invoice: the lines go back, stock returns, and the money is refunded or kept as a balance.</summary>
    public DocumentView CreateCreditNote(long invoiceId, IReadOnlyList<(long LineId, long QtyMilli)> credits, string reason, string refundMethod, long? userId, bool refundPaid = true)
    {
        if (string.IsNullOrWhiteSpace(reason)) throw new HubException("reason", "Please say why.");
        var id = db.InTransaction((c, t) =>
        {
            var invoice = HubDb.Query(c, $"SELECT {DocColumns} FROM documents WHERE id = $id", MapDoc, t, ("$id", invoiceId)).SingleOrDefault() ?? throw new HubException("not-found", "That document was not found.");
            if (invoice is not { Type: DocTypes.Invoice, Status: DocStatus.Issued }) throw new HubException("not-invoice", "A credit note can be made for a final invoice only.");
            var original = HubDb.Query(c, $"SELECT {LineColumns} FROM document_lines WHERE document_id = $id ORDER BY line_no", MapLine, t, ("$id", invoiceId));
            var already = HubDb.Query(c,
                "SELECT l.item_id, l.description, l.unit_price_minor, l.discount_pct_milli, SUM(l.qty_milli) AS q FROM document_lines l JOIN documents d ON d.id = l.document_id " +
                "WHERE d.ref_document_id = $id AND d.type = 'credit-note' AND d.status = 'issued' GROUP BY l.description, l.unit_price_minor, l.discount_pct_milli",
                r => (Description: r.Text("description"), Price: r.Int("unit_price_minor"), Disc: r.Int("discount_pct_milli"), Qty: r.Int("q")), t, ("$id", invoiceId));
            var noteLines = new List<LineInput>();
            foreach (var (lineId, qty) in credits.Where(x => x.QtyMilli > 0))
            {
                var line = original.FirstOrDefault(l => l.Id == lineId) ?? throw new HubException("line", "That line is not on the invoice.");
                var done = already.Where(a => a.Description == line.Description && a.Price == line.UnitPriceMinor && a.Disc == line.DiscountPctMilli).Sum(a => a.Qty);
                if (qty + done > line.QtyMilli) throw new HubException("too-many", $"Only {ShopContext.Qty(line.QtyMilli - done)} of {line.Description} can still be credited.");
                noteLines.Add(new LineInput
                {
                    ItemId = line.ItemId, Description = line.Description, QtyMilli = qty, Unit = line.Unit, UnitPriceMinor = line.UnitPriceMinor, DiscountPctMilli = line.DiscountPctMilli,
                    TaxCode = line.TaxCode, CustomerDiscount = line.CustomerDiscount,
                });
            }
            if (noteLines.Count == 0) throw new HubException("empty", "Choose what is being returned.");
            var noteId = CreateDraft(c, t, new DraftOptions { Type = DocTypes.CreditNote, PartyId = invoice.PartyId, RefDocumentId = invoiceId, UserId = userId, Notes = reason.Trim(), Lines = noteLines, PricesIncludeTax = invoice.PricesIncludeTax });
            // The credit note is worked out like the invoice: same tax position, same rounding of the original (a credit note never rounds).
            var note = HubDb.Query(c, $"SELECT {DocColumns} FROM documents WHERE id = $id", MapDoc, t, ("$id", noteId)).Single();
            var noteDocLines = HubDb.Query(c, $"SELECT {LineColumns} FROM document_lines WHERE document_id = $id ORDER BY line_no", MapLine, t, ("$id", noteId));
            var now = clock.UtcNow;
            var number = numbering.Next(c, t, DocTypes.CreditNote, now);
            var refundable = refundPaid ? Math.Min(note.TotalMinor, invoice.PaidMinor) : 0;
            HubDb.Exec(c, "UPDATE documents SET type = 'credit-note', number = $n, status = 'issued', issued_at = $at, paid_minor = $paid, registered = $reg, buyer_region = $br, seller_region = $sr WHERE id = $id", t,
                ("$n", number), ("$at", Iso.Text(now)), ("$paid", refundable), ("$reg", invoice.Registered ? 1 : 0), ("$br", invoice.BuyerRegion), ("$sr", invoice.SellerRegion), ("$id", noteId));
            if (refundable > 0) InsertPayment(c, t, noteId, invoice.PartyId, null, new PaymentInput { Method = refundMethod, AmountMinor = refundable, Reference = "refund of " + invoice.Number }, userId, "refund", now, negative: true);
            // What the customer paid is kept honest on the invoice: the refund lowers what counts as paid there.
            HubDb.Exec(c, "UPDATE documents SET paid_minor = MAX(0, paid_minor - $r) WHERE id = $id", t, ("$r", refundable), ("$id", invoiceId));
            MoveStock(c, t, noteId, noteDocLines, +1, "return", userId, now);
            audit.Log(c, t, userId, "credit-note", "document", noteId, number + " for " + invoice.Number + ": " + reason.Trim());
            return noteId;
        });
        return Get(id)!;
    }

    // ---- helpers ---------------------------------------------------------------------------------------------------------------

    /// <summary>How much a party owes on issued sales documents.</summary>
    public long Outstanding(long partyId)
    {
        using var c = db.Open();
        return Outstanding(c, null, partyId);
    }

    private static long Outstanding(SqliteConnection c, SqliteTransaction? t, long partyId) => Convert.ToInt64(HubDb.Scalar(c,
        "SELECT COALESCE(SUM(payable_minor - paid_minor), 0) FROM documents WHERE party_id = $p AND direction = 'out' AND status = 'issued' AND type IN ('invoice','progress-bill') AND paid_minor < payable_minor",
        t, ("$p", partyId)) ?? 0L);

    private void InsertPayment(SqliteConnection c, SqliteTransaction t, long documentId, long? partyId, long? projectId, PaymentInput p, long? userId, string kind, DateTimeOffset at, bool negative = false)
    {
        var methods = shop.Current.PaymentMethods;
        if (!methods.Contains(p.Method)) throw new HubException("method", $"\"{p.Method}\" is not a way of paying here. Choose one of: {string.Join(", ", methods)}.");
        HubDb.Exec(c, "INSERT INTO payments(document_id, party_id, project_id, method, amount_minor, reference, at, user_id, kind) VALUES ($d, $p, $pr, $m, $a, $r, $at, $u, $k)", t,
            ("$d", documentId), ("$p", partyId), ("$pr", projectId), ("$m", p.Method), ("$a", negative ? -p.AmountMinor : p.AmountMinor), ("$r", p.Reference), ("$at", Iso.Text(at)), ("$u", userId), ("$k", kind));
    }

    private static void ReduceCash(List<PaymentInput> payments, long change)
    {
        for (var i = payments.Count - 1; i >= 0 && change > 0; i--)
        {
            if (payments[i].Method != "cash") continue;
            var take = Math.Min(change, payments[i].AmountMinor);
            payments[i] = new PaymentInput { Method = "cash", AmountMinor = payments[i].AmountMinor - take, Reference = payments[i].Reference };
            change -= take;
        }
        payments.RemoveAll(p => p.AmountMinor <= 0);
    }

    private void MoveStock(SqliteConnection c, SqliteTransaction t, long documentId, IReadOnlyList<DocLine> lines, int direction, string reason, long? userId, DateTimeOffset at)
    {
        var context = shop.Current;
        foreach (var group in lines.Where(l => l.ItemId is not null).GroupBy(l => l.ItemId!.Value))
        {
            var tracked = Convert.ToInt64(HubDb.Scalar(c, "SELECT track_stock FROM items WHERE id = $i", t, ("$i", group.Key)) ?? 0L) != 0;
            if (!tracked) continue;
            var qty = group.Sum(l => l.QtyMilli) * direction;
            if (qty < 0 && !context.Settings.AllowNegativeStock)
            {
                var onHand = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(SUM(qty_milli), 0) FROM stock_moves WHERE item_id = $i", t, ("$i", group.Key)) ?? 0L);
                if (onHand + qty < 0)
                {
                    var name = Convert.ToString(HubDb.Scalar(c, "SELECT name FROM items WHERE id = $i", t, ("$i", group.Key)));
                    throw new HubException("stock", $"Only {ShopContext.Qty(onHand)} of {name} left.");
                }
            }
            HubDb.Exec(c, "INSERT INTO stock_moves(item_id, qty_milli, reason, document_id, at, user_id) VALUES ($i, $q, $r, $d, $at, $u)", t,
                ("$i", group.Key), ("$q", qty), ("$r", reason), ("$d", documentId), ("$at", Iso.Text(at)), ("$u", userId));
        }
    }

    private static void RequireOpen(SqliteConnection c, SqliteTransaction t, long documentId)
    {
        var status = HubDb.Scalar(c, "SELECT status FROM documents WHERE id = $id", t, ("$id", documentId)) as string ?? throw new HubException("not-found", "That document was not found.");
        if (status != DocStatus.Open) throw new HubException("not-open", "That document is final and cannot be changed.");
    }

    private static string? Blank(string? text) => string.IsNullOrWhiteSpace(text) ? null : text.Trim();
}
