using System.Globalization;
using System.Numerics;
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
public sealed class DocumentService(HubDb db, ShopContextProvider shop, IClock clock, Numbering numbering, CatalogService catalog, PartyService parties, AuditService audit, NextGenOS.Hub.Books.BooksService books, NextGenOS.Hub.Loyalty.LoyaltyService loyalty)
{
    /// <summary>The "way of paying" that uses credit a customer already has with the shop (an advance, or a return kept as credit). It moves no money and is not in the shop's list of ways of paying.</summary>
    public const string AccountCredit = "account";

    private const string DocColumns =
        "id, type, number, status, direction, party_id, issued_at, created_at, due_at, currency_decimals, prices_include_tax, seller_region, buyer_region, round_total, registered, " +
        "subtotal_minor, tax_minor, total_minor, payable_minor, paid_minor, tips_minor, retention_minor, advance_minor, table_id, project_id, ref_document_id, user_id, notes, meta, " +
        "bill_discount_minor, bill_discount_pct_milli, loyalty_points_used_cent, loyalty_discount_minor";

    private const string LineColumns = "id, line_no, item_id, description, qty_milli, unit, unit_price_minor, discount_pct_milli, tax_code, customer_discount, fired, note, station, boq_id, discount_amount_minor, ref_line_id";

    private static readonly JsonSerializerOptions Json = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    // ---- reading ---------------------------------------------------------------------------------------------------------------

    private static Document MapDoc(SqliteDataReader r) => new(
        r.Int("id"), r.Text("type"), r.TextOrNull("number"), r.Text("status"), r.Text("direction"), r.IntOrNull("party_id"), r.TimeOrNull("issued_at"), r.Time("created_at"),
        r.TimeOrNull("due_at"), (int)r.Int("currency_decimals"), r.Flag("prices_include_tax"), r.TextOrNull("seller_region"), r.TextOrNull("buyer_region"), r.Flag("round_total"),
        r.Flag("registered"), r.Int("subtotal_minor"), r.Int("tax_minor"), r.Int("total_minor"), r.Int("payable_minor"), r.Int("paid_minor"), r.Int("tips_minor"),
        r.Int("retention_minor"), r.Int("advance_minor"), r.IntOrNull("table_id"), r.IntOrNull("project_id"), r.IntOrNull("ref_document_id"), r.IntOrNull("user_id"),
        r.TextOrNull("notes"), JsonSerializer.Deserialize<Dictionary<string, string>>(r.Text("meta")) ?? new Dictionary<string, string>(),
        r.Int("bill_discount_minor"), r.Int("bill_discount_pct_milli"), r.Int("loyalty_points_used_cent"), r.Int("loyalty_discount_minor"));

    private static DocLine MapLine(SqliteDataReader r) => new(
        r.Int("id"), (int)r.Int("line_no"), r.IntOrNull("item_id"), r.Text("description"), r.Int("qty_milli"), r.TextOrNull("unit"), r.Int("unit_price_minor"),
        r.Int("discount_pct_milli"), r.Text("tax_code"), r.TextOrNull("customer_discount"), r.Flag("fired"), r.TextOrNull("note"), r.TextOrNull("station"), r.IntOrNull("boq_id"),
        r.Int("discount_amount_minor"), r.IntOrNull("ref_line_id"));

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
        CheckBillDiscount(options.BillDiscountMinor, options.BillDiscountPctMilli);
        var now = clock.UtcNow;
        var number = options.Type is DocTypes.Order or DocTypes.Quote or DocTypes.Purchase ? numbering.Next(c, t, options.Type, now) : null;
        var meta = new Dictionary<string, string>(options.Meta);
        var id = HubDb.Insert(c,
            "INSERT INTO documents(type, number, status, direction, party_id, created_at, currency_decimals, prices_include_tax, seller_region, buyer_region, round_total, registered, " +
            "adjustments, table_id, project_id, ref_document_id, user_id, notes, meta, bill_discount_minor, bill_discount_pct_milli) " +
            "VALUES ($type, $number, 'open', $dir, $party, $at, $dec, $incl, $seller, $buyer, $round, $reg, $adj, $table, $project, $ref, $user, $notes, $meta, $bda, $bdp)", t,
            ("$type", options.Type), ("$number", number), ("$dir", options.Direction), ("$party", options.PartyId), ("$at", Iso.Text(now)), ("$dec", context.Decimals),
            ("$incl", (options.PricesIncludeTax ?? context.Settings.PricesIncludeTax) ? 1 : 0), ("$seller", Blank(context.Settings.Region)), ("$buyer", Blank(party?.Region)),
            ("$round", context.Settings.RoundTotal ? 1 : 0), ("$reg", context.Settings.TaxRegistered ? 1 : 0),
            ("$adj", JsonSerializer.Serialize(options.Adjustments, Json)), ("$table", options.TableId), ("$project", options.ProjectId), ("$ref", options.RefDocumentId),
            ("$user", options.UserId), ("$notes", options.Notes), ("$meta", JsonSerializer.Serialize(meta)),
            ("$bda", options.BillDiscountMinor), ("$bdp", options.BillDiscountPctMilli));
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
        CheckLineDiscount(input.DiscountPctMilli, input.DiscountAmountMinor, input.QtyMilli, price);
        string taxCode;
        try { taxCode = context.TaxCode(input.TaxCode ?? item?.TaxCode ?? "standard"); }
        catch (ArgumentException ex) { throw new HubException("tax", ex.Message); }
        if (!string.IsNullOrEmpty(input.CustomerDiscount) && !(context.Country.Tax.CustomerDiscounts ?? new()).Any(d => d.Code == input.CustomerDiscount))
            throw new HubException("customer-discount", $"\"{input.CustomerDiscount}\" is not a discount of {context.Country.Name}.");
        var lineNo = Convert.ToInt32(HubDb.Scalar(c, "SELECT COALESCE(MAX(line_no), 0) + 1 FROM document_lines WHERE document_id = $id", t, ("$id", documentId)) ?? 1);
        HubDb.Exec(c,
            "INSERT INTO document_lines(document_id, line_no, item_id, description, qty_milli, unit, unit_price_minor, discount_pct_milli, discount_amount_minor, ref_line_id, tax_code, customer_discount, note, station, boq_id) " +
            "VALUES ($d, $n, $item, $desc, $q, $unit, $price, $disc, $damt, $refline, $tax, $cd, $note, $station, $boq)", t,
            ("$d", documentId), ("$n", lineNo), ("$item", item?.Id), ("$desc", description), ("$q", input.QtyMilli), ("$unit", input.Unit ?? item?.Unit), ("$price", price),
            ("$disc", input.DiscountPctMilli), ("$damt", input.DiscountAmountMinor), ("$refline", input.RefLineId), ("$tax", taxCode), ("$cd", Blank(input.CustomerDiscount)), ("$note", Blank(input.Note)), ("$station", input.Station ?? item?.Station), ("$boq", input.BoqId));
    }

    public DocumentView UpdateLine(long documentId, long lineId, long? qtyMilli = null, long? discountPctMilli = null, string? note = null, string? customerDiscount = null, bool clearCustomerDiscount = false, long? discountAmountMinor = null)
    {
        db.InTransaction((c, t) =>
        {
            RequireOpen(c, t, documentId);
            if (qtyMilli is <= 0) throw new HubException("qty", "The quantity must be more than zero.");
            if (discountPctMilli is < 0 or > 100_000) throw new HubException("discount", "A discount must be between 0 and 100 percent.");
            if (discountAmountMinor is < 0) throw new HubException("discount", "A discount cannot be less than nothing.");
            if (discountPctMilli is > 0 && discountAmountMinor is > 0) throw new HubException("discount", "Give the discount as a percent or as an amount, not both.");
            // Giving one kind of discount takes the other kind off the line.
            HubDb.Exec(c,
                "UPDATE document_lines SET qty_milli = COALESCE($q, qty_milli), " +
                "discount_pct_milli = CASE WHEN COALESCE($a, 0) > 0 THEN 0 ELSE COALESCE($d, discount_pct_milli) END, " +
                "discount_amount_minor = CASE WHEN COALESCE($d, 0) > 0 THEN 0 ELSE COALESCE($a, discount_amount_minor) END, note = COALESCE($n, note), " +
                "customer_discount = CASE WHEN $clear = 1 THEN NULL ELSE COALESCE($cd, customer_discount) END WHERE id = $id AND document_id = $doc", t,
                ("$q", qtyMilli), ("$d", discountPctMilli), ("$a", discountAmountMinor), ("$n", note), ("$cd", Blank(customerDiscount)), ("$clear", clearCustomerDiscount ? 1 : 0), ("$id", lineId), ("$doc", documentId));
            var now = HubDb.Query(c, "SELECT qty_milli, unit_price_minor, discount_amount_minor FROM document_lines WHERE id = $id AND document_id = $doc", r => (Qty: r.Int("qty_milli"), Price: r.Int("unit_price_minor"), Amount: r.Int("discount_amount_minor")), t, ("$id", lineId), ("$doc", documentId)).FirstOrDefault();
            if (now.Amount > Gross(now.Qty, now.Price)) throw new HubException("discount", "A discount cannot be more than the line comes to.");
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

    /// <summary>
    /// A discount on the whole bill, as an amount or as a percent of what the lines come to (give one; both zero takes it off). It is spread over the lines before the tax is
    /// worked out, so the tax falls with it (decision 33).
    /// </summary>
    public DocumentView SetBillDiscount(long documentId, long amountMinor, long pctMilli)
    {
        CheckBillDiscount(amountMinor, pctMilli);
        db.InTransaction((c, t) =>
        {
            RequireOpen(c, t, documentId);
            HubDb.Exec(c, "UPDATE documents SET bill_discount_minor = $a, bill_discount_pct_milli = $p WHERE id = $id", t, ("$a", amountMinor), ("$p", pctMilli), ("$id", documentId));
            var lines = HubDb.Query(c, $"SELECT {LineColumns} FROM document_lines WHERE document_id = $id ORDER BY line_no", MapLine, t, ("$id", documentId));
            var loyaltyValue = Convert.ToInt64(HubDb.Scalar(c, "SELECT loyalty_discount_minor FROM documents WHERE id = $id", t, ("$id", documentId)) ?? 0L);
            if (amountMinor + loyaltyValue > lines.Sum(NetOf)) throw new HubException("discount", "The discount is more than the bill comes to.");
            Recalculate(c, t, documentId);
        });
        return Get(documentId)!;
    }

    /// <summary>
    /// The customer uses some of their loyalty points on this bill (in hundredths of a point; 0 takes it off). They are worth the shop's value for a point and are taken off the bill like a
    /// discount, before tax. Refused when the customer has fewer points, when the bill has no named customer, and when the points are worth more than the bill.
    /// </summary>
    public DocumentView SetLoyaltyPoints(long documentId, long pointsCent)
    {
        if (pointsCent < 0) throw new HubException("loyalty", "Points cannot be less than nothing.");
        db.InTransaction((c, t) =>
        {
            RequireOpen(c, t, documentId);
            long value = 0;
            if (pointsCent > 0)
            {
                if (!loyalty.Enabled) throw new HubException("loyalty", "Loyalty points are not switched on.");
                var partyId = HubDb.Scalar(c, "SELECT party_id FROM documents WHERE id = $id", t, ("$id", documentId)) as long? ?? throw new HubException("loyalty", "Choose the customer first: points belong to a customer.");
                var balance = loyalty.Balance(c, t, partyId);
                if (pointsCent > balance) throw new HubException("loyalty", $"This customer has only {balance / 100m:0.##} points.");
                value = loyalty.ValueOf(pointsCent);
                if (value <= 0) throw new HubException("loyalty", "A point has no value yet: set it in Settings first.");
            }
            HubDb.Exec(c, "UPDATE documents SET loyalty_points_used_cent = $p, loyalty_discount_minor = $v WHERE id = $id", t, ("$p", pointsCent), ("$v", value), ("$id", documentId));
            var header = HubDb.Query(c, $"SELECT {DocColumns} FROM documents WHERE id = $id", MapDoc, t, ("$id", documentId)).Single();
            var lines = HubDb.Query(c, $"SELECT {LineColumns} FROM document_lines WHERE document_id = $id ORDER BY line_no", MapLine, t, ("$id", documentId));
            var total = lines.Sum(NetOf);
            var typed = header.BillDiscountPctMilli > 0 ? (long)((2 * (BigInteger)total * header.BillDiscountPctMilli + 100_000) / 200_000) : header.BillDiscountMinor;
            if (typed + value > total) throw new HubException("loyalty", "Those points are worth more than the bill. Use fewer.");
            Recalculate(c, t, documentId);
        });
        return Get(documentId)!;
    }

    private static void CheckBillDiscount(long amountMinor, long pctMilli)
    {
        if (amountMinor < 0) throw new HubException("discount", "A discount cannot be less than nothing.");
        if (pctMilli is < 0 or > 100_000) throw new HubException("discount", "A discount must be between 0 and 100 percent.");
        if (amountMinor > 0 && pctMilli > 0) throw new HubException("discount", "Give the discount as a percent or as an amount, not both.");
    }

    private static void CheckLineDiscount(long pctMilli, long amountMinor, long qtyMilli, long priceMinor)
    {
        if (pctMilli is < 0 or > 100_000) throw new HubException("discount", "A discount must be between 0 and 100 percent.");
        if (amountMinor < 0) throw new HubException("discount", "A discount cannot be less than nothing.");
        if (pctMilli > 0 && amountMinor > 0) throw new HubException("discount", "Give the discount as a percent or as an amount, not both.");
        if (amountMinor > Gross(qtyMilli, priceMinor)) throw new HubException("discount", "A discount cannot be more than the line comes to.");
    }

    public DocumentView SetParty(long documentId, long? partyId)
    {
        db.InTransaction((c, t) =>
        {
            RequireOpen(c, t, documentId);
            var party = partyId is { } p ? parties.Get(p) ?? throw new HubException("party-not-found", "That customer was not found.") : null;
            // Points belong to a customer: a different customer starts without points used.
            HubDb.Exec(c, "UPDATE documents SET party_id = $p, buyer_region = $r, loyalty_points_used_cent = 0, loyalty_discount_minor = 0 WHERE id = $id", t, ("$p", partyId), ("$r", Blank(party?.Region)), ("$id", documentId));
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
        // A discount on the whole bill is spread over the lines first, as an amount on each line, and the engine then works the tax out on what is left.
        var shares = BillDiscountShares(header, lines);
        var input = lines.Select((l, i) => new TaxLineInput
        {
            Name = l.Description, Qty = MoneyText.Minor(l.QtyMilli, 3), UnitPrice = MoneyText.Minor(l.UnitPriceMinor, d), TaxCode = l.TaxCode,
            DiscountPercent = shares[i] == 0 && l.DiscountAmountMinor == 0 && l.DiscountPctMilli > 0 ? MoneyText.Minor(l.DiscountPctMilli, 3) : null,
            DiscountAmount = shares[i] > 0 ? MoneyText.Minor(LineDiscountOf(l) + shares[i], d) : l.DiscountAmountMinor > 0 ? MoneyText.Minor(LineDiscountOf(l), d) : null,
            CustomerDiscount = l.CustomerDiscount,
        }).ToList();
        // A regional country (Canada, the US) needs a region to tax by: the shop's own when the buyer's is not known.
        if (context.Country.Tax.Model == "regional" && string.IsNullOrEmpty(taxContext.SellerRegion) && string.IsNullOrEmpty(taxContext.BuyerRegion))
            taxContext.SellerRegion = context.Country.Tax.Regions?.List?.FirstOrDefault()?.Code;
        return TaxEngine.Calculate(context.Country, taxContext, input, adjustments.ToList());
    }

    // ---- discounts (the same steps as the tax engine, so that what is spread is exactly what the engine takes off) --------------------------------

    /// <summary>Quantity times price, rounded half up, as the tax engine does it (quantity in thousandths, price in minor units).</summary>
    public static long Gross(long qtyMilli, long priceMinor) => (long)((2 * (BigInteger)qtyMilli * priceMinor + 1000) / 2000);

    /// <summary>What a line's own discount comes to: the amount if there is one, else the percent of the line, never more than the line.</summary>
    public static long LineDiscountOf(DocLine line)
    {
        var gross = Gross(line.QtyMilli, line.UnitPriceMinor);
        var discount = line.DiscountAmountMinor > 0 ? line.DiscountAmountMinor : (long)((2 * (BigInteger)gross * line.DiscountPctMilli + 100_000) / 200_000);
        return Math.Min(discount, gross);
    }

    /// <summary>What a line comes to after its own discount.</summary>
    public static long NetOf(DocLine line) => Gross(line.QtyMilli, line.UnitPriceMinor) - LineDiscountOf(line);

    /// <summary>How much of the bill's discount falls on each line (in the order of the lines). Nothing when the bill has no discount.</summary>
    public static long[] BillDiscountShares(Document header, IReadOnlyList<DocLine> lines)
    {
        var nets = lines.Select(NetOf).ToArray();
        var total = nets.Sum();
        var typed = header.BillDiscountPctMilli > 0 ? (long)((2 * (BigInteger)total * header.BillDiscountPctMilli + 100_000) / 200_000) : header.BillDiscountMinor;
        return Allocate(nets, Math.Min(typed + header.LoyaltyDiscountMinor, total));   // loyalty points used on the bill are part of its discount
    }

    /// <summary>
    /// Divides an amount in proportion to the weights, in whole minor units, so that the parts add up to exactly the amount: each gets the rounded-down share, and the
    /// units left over go one each to the biggest fractions (the first line wins a tie). A line with no weight gets nothing, and no part is more than its weight.
    /// </summary>
    public static long[] Allocate(IReadOnlyList<long> weights, long amount)
    {
        var shares = new long[weights.Count];
        var total = weights.Aggregate(BigInteger.Zero, (a, w) => a + w);
        if (amount <= 0 || total.IsZero) return shares;
        if (amount > total) amount = (long)total;
        var fractions = new (BigInteger Fraction, int Index)[weights.Count];
        long given = 0;
        for (var i = 0; i < weights.Count; i++)
        {
            var product = (BigInteger)amount * weights[i];
            shares[i] = (long)(product / total);
            fractions[i] = (product % total, i);
            given += shares[i];
        }
        foreach (var (_, index) in fractions.OrderByDescending(f => f.Fraction).ThenBy(f => f.Index).Take((int)(amount - given))) shares[index]++;
        return shares;
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
        var accountPaid = tendered.Where(p => p.Method == AccountCredit).Sum(p => p.AmountMinor);
        if (accountPaid > 0)
        {
            if (header.Direction != "out" || type is not (DocTypes.Invoice or DocTypes.ProgressBill) || header.PartyId is not { } creditParty)
                throw new HubException("account-credit", "Credit on an account can only pay a bill made out to that customer.");
            var credit = Math.Max(0, -books.CustomerBalance(c, t, creditParty));
            if (accountPaid > credit) throw new HubException("account-credit", $"This customer's account has only {context.Money(credit)} of credit.");
        }
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
            // What the customer owes is read from the customer's account in the books (so that opening balances, money paid in advance and returns kept as credit all count),
            // and the new debt is the part of the bill not paid in money (credit the customer already had is not money and is taken off by the account itself).
            var owed = books.CustomerBalance(c, t, party.Id);
            var after = owed + (payable - (paid - accountPaid));
            if (after > party.CreditLimitMinor)
                throw new HubException("over-limit", $"{party.Name} would owe {context.Money(after)}, above the credit limit of {context.Money(party.CreditLimitMinor)}.");
            due = now.AddDays(party.TermsDays > 0 ? party.TermsDays : (int)context.Rule("creditDays", 30));
        }

        HubDb.Exec(c,
            "UPDATE documents SET type = $type, number = $number, status = 'issued', issued_at = $at, due_at = $due, meta = $meta, user_id = COALESCE($user, user_id) WHERE id = $id", t,
            ("$type", type), ("$number", number), ("$at", Iso.Text(now)), ("$due", due is { } dv ? Iso.Text(dv) : null), ("$meta", JsonSerializer.Serialize(meta)), ("$user", options.UserId), ("$id", documentId));

        foreach (var p in tendered) InsertPayment(c, t, documentId, header.PartyId, header.ProjectId, p, options.UserId, "payment", now);
        HubDb.Exec(c, "UPDATE documents SET paid_minor = $paid WHERE id = $id", t, ("$paid", tendered.Sum(p => p.AmountMinor)), ("$id", documentId));

        if (type == DocTypes.Invoice && header.Direction == "out") MoveStock(c, t, header.Id, lines, -1, "sale", options.UserId, now);
        if (type == DocTypes.Purchase) MoveStock(c, t, header.Id, lines, +1, "purchase", options.UserId, now);
        books.Sync(c, t, documentId, options.UserId);
        loyalty.OnIssued(c, t, documentId, options.UserId);
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
                BillDiscountMinor = request.BillDiscountMinor, BillDiscountPctMilli = request.BillDiscountPctMilli,
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
            if (payment.Method == AccountCredit) throw new HubException("account-credit", "Credit on an account is used when the bill is made. Take the payment in money, or put the credit on the next bill.");
            if (payment.AmountMinor > header.BalanceMinor) throw new HubException("too-much", $"Only {shop.Current.Money(header.BalanceMinor)} is still owed on this document.");
            InsertPayment(c, t, documentId, header.PartyId, header.ProjectId, payment, userId, "payment", clock.UtcNow);
            HubDb.Exec(c, "UPDATE documents SET paid_minor = paid_minor + $a WHERE id = $id", t, ("$a", payment.AmountMinor), ("$id", documentId));
            books.Sync(c, t, documentId, userId);
        });
        return Get(documentId)!;
    }

    /// <summary>What happened to money a customer paid on account: the bills it settled (oldest first) and what was left over and is now kept as credit.</summary>
    public sealed record AccountReceipt(IReadOnlyList<(long DocumentId, string? Number, long AmountMinor)> Settled, long KeptMinor);

    /// <summary>
    /// Takes money from a customer who is paying what they owe (or paying in advance), without naming a bill: it settles the customer's unpaid bills, oldest first, and anything over is kept
    /// on the customer's account as credit for a later bill. All in one step, and every payment is written in the books.
    /// </summary>
    public AccountReceipt ReceiveOnAccount(long partyId, long amountMinor, string method, string? reference = null, long? userId = null)
    {
        if (amountMinor <= 0) throw new HubException("amount", "The amount must be more than zero.");
        if (method == AccountCredit || !shop.Current.PaymentMethods.Contains(method))
            throw new HubException("method", $"\"{method}\" is not a way of paying here. Choose one of: {string.Join(", ", shop.Current.PaymentMethods)}.");
        return db.InTransaction((c, t) =>
        {
            var party = parties.Get(partyId) ?? throw new HubException("party-not-found", "That customer was not found.");
            var now = clock.UtcNow;
            var left = amountMinor;
            var settled = new List<(long, string?, long)>();
            var open = HubDb.Query(c,
                "SELECT id, number, payable_minor - paid_minor FROM documents WHERE party_id = $p AND direction = 'out' AND status = 'issued' AND type IN ('invoice', 'progress-bill') AND paid_minor < payable_minor " +
                "ORDER BY COALESCE(issued_at, created_at), id", r => (Id: r.Int("id"), Number: r.TextOrNull("number"), Due: r.GetInt64(2)), t, ("$p", partyId));
            foreach (var bill in open)
            {
                if (left <= 0) break;
                var take = Math.Min(left, bill.Due);
                InsertPayment(c, t, bill.Id, partyId, null, new PaymentInput { Method = method, AmountMinor = take, Reference = reference }, userId, "payment", now);
                HubDb.Exec(c, "UPDATE documents SET paid_minor = paid_minor + $a WHERE id = $id", t, ("$a", take), ("$id", bill.Id));
                books.Sync(c, t, bill.Id, userId);
                settled.Add((bill.Id, bill.Number, take));
                left -= take;
            }
            if (left > 0)
            {
                // nothing more is owed on a bill: the rest is the customer's credit, used on the next bill
                var paymentId = HubDb.Insert(c, "INSERT INTO payments(document_id, party_id, method, amount_minor, reference, at, user_id, kind) VALUES (NULL, $p, $m, $a, $r, $at, $u, 'advance')", t,
                    ("$p", partyId), ("$m", method), ("$a", left), ("$r", reference), ("$at", Iso.Text(now)), ("$u", userId));
                books.SyncPayment(c, t, paymentId, userId);
            }
            audit.Log(c, t, userId, "receive", "party", partyId, $"{party.Name}: {shop.Current.Money(amountMinor)} by {method}");
            return new AccountReceipt(settled, left);
        });
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
                    // Money paid is refunded in the way given; credit from the customer's account that paid part of the bill goes back to the account (nothing to hand over).
                    var fromAccount = Math.Min(header.PaidMinor, Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(SUM(amount_minor), 0) FROM payments WHERE document_id = $id AND method = $m AND kind = 'payment'", t, ("$id", documentId), ("$m", AccountCredit)) ?? 0L));
                    if (header.PaidMinor - fromAccount > 0)
                        InsertPayment(c, t, documentId, header.PartyId, header.ProjectId, new PaymentInput { Method = refundMethod, AmountMinor = header.PaidMinor - fromAccount, Reference = "void" }, userId, "refund", clock.UtcNow, negative: true);
                    if (fromAccount > 0)
                        InsertPayment(c, t, documentId, header.PartyId, header.ProjectId, new PaymentInput { Method = AccountCredit, AmountMinor = fromAccount, Reference = "void" }, userId, "refund", clock.UtcNow, negative: true);
                    HubDb.Exec(c, "UPDATE documents SET paid_minor = 0 WHERE id = $id", t, ("$id", documentId));
                }
            }
            HubDb.Exec(c, "UPDATE documents SET status = 'void', notes = COALESCE(notes || char(10), '') || $why WHERE id = $id", t, ("$why", "Void: " + reason.Trim()), ("$id", documentId));
            books.Sync(c, t, documentId, userId);
            if (header.Status == DocStatus.Issued) loyalty.OnVoid(c, t, documentId, userId);
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
            // What was already given back: counted by the invoice line each credit line points to (older credit notes, made before lines remembered that, by what they look like).
            var already = HubDb.Query(c,
                "SELECT l.ref_line_id, l.description, l.unit_price_minor, l.discount_pct_milli, SUM(l.qty_milli) AS q, SUM(l.discount_amount_minor) AS da FROM document_lines l JOIN documents d ON d.id = l.document_id " +
                "WHERE d.ref_document_id = $id AND d.type = 'credit-note' AND d.status = 'issued' GROUP BY l.ref_line_id, l.description, l.unit_price_minor, l.discount_pct_milli",
                r => (RefLine: r.IntOrNull("ref_line_id"), Description: r.Text("description"), Price: r.Int("unit_price_minor"), Disc: r.Int("discount_pct_milli"), Qty: r.Int("q"), Amount: r.Int("da")), t, ("$id", invoiceId));
            var invoiceResultText = HubDb.Scalar(c, "SELECT result FROM documents WHERE id = $id", t, ("$id", invoiceId)) as string;
            var invoiceResult = invoiceResultText is null ? null : NewtonJson.DeserializeObject<TaxResult>(invoiceResultText);
            var noteLines = new List<LineInput>();
            foreach (var (lineId, qty) in credits.Where(x => x.QtyMilli > 0))
            {
                var line = original.FirstOrDefault(l => l.Id == lineId) ?? throw new HubException("line", "That line is not on the invoice.");
                var given = already.Where(a => a.RefLine == line.Id || (a.RefLine is null && a.Description == line.Description && a.Price == line.UnitPriceMinor && a.Disc == line.DiscountPctMilli)).ToList();
                var done = given.Sum(a => a.Qty);
                if (qty + done > line.QtyMilli) throw new HubException("too-many", $"Only {ShopContext.Qty(line.QtyMilli - done)} of {line.Description} can still be credited.");
                // A line that had an amount discount, or any line of a bill that had a discount on the whole bill, gives back exactly its share of what was taken off (the last
                // part gives back what is left, so the pieces add up to the whole). Any other line is given back at its percent, as before.
                var position = original.ToList().FindIndex(l => l.Id == lineId);
                var taken = invoiceResult is not null && position >= 0 && position < invoiceResult.Lines.Count ? (long)MoneyText.Parse(invoiceResult.Lines[position].Discount, invoice.CurrencyDecimals) : 0;
                var byAmount = taken > 0 && (line.DiscountAmountMinor > 0 || invoice.HasBillDiscount);
                long creditDiscount = 0;
                if (byAmount)
                {
                    var left = taken - given.Sum(a => a.Amount);
                    creditDiscount = qty + done == line.QtyMilli ? left : Math.Min(left, (long)((2 * (BigInteger)taken * qty + line.QtyMilli) / (2 * (BigInteger)line.QtyMilli)));
                    creditDiscount = Math.Min(creditDiscount, Gross(qty, line.UnitPriceMinor));
                }
                noteLines.Add(new LineInput
                {
                    ItemId = line.ItemId, Description = line.Description, QtyMilli = qty, Unit = line.Unit, UnitPriceMinor = line.UnitPriceMinor, DiscountPctMilli = byAmount ? 0 : line.DiscountPctMilli,
                    DiscountAmountMinor = creditDiscount, RefLineId = line.Id, TaxCode = line.TaxCode, CustomerDiscount = line.CustomerDiscount,
                });
            }
            if (noteLines.Count == 0) throw new HubException("empty", "Choose what is being returned.");
            var noteId = CreateDraft(c, t, new DraftOptions { Type = DocTypes.CreditNote, PartyId = invoice.PartyId, RefDocumentId = invoiceId, UserId = userId, Notes = reason.Trim(), Lines = noteLines, PricesIncludeTax = invoice.PricesIncludeTax });
            // The credit note is worked out like the invoice: same tax position, same rounding of the original (a credit note never rounds).
            var note = HubDb.Query(c, $"SELECT {DocColumns} FROM documents WHERE id = $id", MapDoc, t, ("$id", noteId)).Single();
            var noteDocLines = HubDb.Query(c, $"SELECT {LineColumns} FROM document_lines WHERE document_id = $id ORDER BY line_no", MapLine, t, ("$id", noteId));
            var now = clock.UtcNow;
            var number = numbering.Next(c, t, DocTypes.CreditNote, now);
            // Money is given back only from what was paid in money; what was paid from the customer's account stays on the account.
            var paidFromAccount = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(SUM(amount_minor), 0) FROM payments WHERE document_id = $id AND method = $m AND kind = 'payment'", t, ("$id", invoiceId), ("$m", AccountCredit)) ?? 0L);
            var refundable = refundPaid ? Math.Min(note.TotalMinor, Math.Max(0, invoice.PaidMinor - paidFromAccount)) : 0;
            HubDb.Exec(c, "UPDATE documents SET type = 'credit-note', number = $n, status = 'issued', issued_at = $at, paid_minor = $paid, registered = $reg, buyer_region = $br, seller_region = $sr WHERE id = $id", t,
                ("$n", number), ("$at", Iso.Text(now)), ("$paid", refundable), ("$reg", invoice.Registered ? 1 : 0), ("$br", invoice.BuyerRegion), ("$sr", invoice.SellerRegion), ("$id", noteId));
            if (refundable > 0) InsertPayment(c, t, noteId, invoice.PartyId, null, new PaymentInput { Method = refundMethod, AmountMinor = refundable, Reference = "refund of " + invoice.Number }, userId, "refund", now, negative: true);
            // What the customer paid is kept honest on the invoice: the refund lowers what counts as paid there.
            HubDb.Exec(c, "UPDATE documents SET paid_minor = MAX(0, paid_minor - $r) WHERE id = $id", t, ("$r", refundable), ("$id", invoiceId));
            MoveStock(c, t, noteId, noteDocLines, +1, "return", userId, now);
            books.Sync(c, t, noteId, userId);
            loyalty.OnCreditNote(c, t, noteId, invoiceId, userId);
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
        if (p.Method != AccountCredit && !methods.Contains(p.Method)) throw new HubException("method", $"\"{p.Method}\" is not a way of paying here. Choose one of: {string.Join(", ", methods)}.");
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
