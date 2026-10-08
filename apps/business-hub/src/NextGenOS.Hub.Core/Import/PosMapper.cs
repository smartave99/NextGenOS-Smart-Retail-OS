using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Import;

/// <summary>What the Hub already holds from an earlier move of the same old database, and which barcodes and cards are taken. The mapper never adds twice and never takes a taken barcode.</summary>
public sealed record ExistingState(
    IReadOnlySet<string> ItemKeys, IReadOnlySet<string> CustomerKeys, IReadOnlySet<string> SupplierKeys, IReadOnlySet<string> Barcodes, IReadOnlySet<string> Cards)
{
    public static ExistingState None { get; } = new(new HashSet<string>(), new HashSet<string>(), new HashSet<string>(), new HashSet<string>(StringComparer.Ordinal), new HashSet<string>(StringComparer.Ordinal));
}

/// <summary>An item to add, with its opening stock (thousandths; written only when <see cref="MovesStock"/>).</summary>
public sealed record PlannedItem(string OldKey, ItemInput Input, bool Active, long StockMilli, bool MovesStock);

/// <summary>A customer or supplier to add, with what they owed the shop on the day (negative: what the shop owed them).</summary>
public sealed record PlannedParty(string Entity, string OldKey, PartyInput Input, long BalanceMinor, long DiscountPctMilli = 0);

public sealed class ImportPlan
{
    public List<PlannedItem> Items { get; } = [];
    public List<PlannedParty> Parties { get; } = [];
    public MatchReport Report { get; set; } = new();
}

/// <summary>
/// Turns the older POS's rows into what the Hub holds, and builds the match report, WITHOUT writing anything. It follows the maps and the traps of
/// docs/old-programs/02-masters-accounting-reports.md and 01-selling-buying-stock.md (8.2) exactly; where those say a thing is not understood, it does the safe thing and says
/// "a person should look" in the report. docs/old-programs/DATABASE.md is the one page for which old column means what.
/// The important traps: ReorderPoint is the WHOLESALE price (the reorder level is MinStock); the product's Barcode is always "0" (real barcodes are stock rows: Temp_Stock); the tax is two half
/// rates; a balance is the running ledger (credit minus debit, the typed opening balance is already inside it); a credit limit counts only when its switch says Yes; stock comes from
/// Temp_Stock and never from StockMovement.
/// </summary>
public static class PosMapper
{
    /// <summary>The walk-in customer of the older program (sales to nobody in particular). It is not a customer record here: a sale with no customer is the Hub's way.</summary>
    private const string WalkInName = "Cash";

    private const string OpeningReason = "opening stock";

    public static ImportPlan Plan(string sourceKind, string sourceId, string describe, OldSystemData data, ShopContext shop, ExistingState existing, Func<string, bool?, bool?> wouldTrackStock)
    {
        var plan = new ImportPlan();
        var notes = new Notes();
        var skipped = new List<SkippedRow>();
        var decimals = shop.Decimals;

        // ---- items -------------------------------------------------------------------------------------------------------------------------
        var kind = shop.Industry.ItemKinds.FirstOrDefault(k => k.TracksStock) ?? shop.Industry.ItemKinds.FirstOrDefault();
        var subById = data.SubCategories.GroupBy(s => s.Id).ToDictionary(g => g.Key, g => g.First());
        var lotsByProduct = data.Lots.ToLookup(l => l.ProductId);
        var productIds = data.Products.Select(p => p.Id).ToHashSet();
        var takenBarcodes = new HashSet<string>(existing.Barcodes, StringComparer.Ordinal);

        long oldItems = 0, addedItems = 0, beforeItems = 0, skippedItems = 0;
        long oldQty = 0, addedQty = 0, beforeQty = 0, skippedQty = 0;
        decimal oldValueExact = 0m;
        long addedValue = 0, beforeValue = 0, skippedValue = 0;
        long rowsWithStock = 0;

        foreach (var p in data.Products.OrderBy(p => p.Id))
        {
            var lots = lotsByProduct[p.Id].OrderBy(l => l.Id).ToList();
            if (lots.Count > 1) notes.Add(FindingLevels.Look, "several-barcodes", "{n} product(s) have several barcodes (sizes, colours or batches). The Hub keeps one barcode on an item, so each barcode became its own item, with its own price and stock.", T(p.Name));
            var candidates = lots.Count == 0 ? [(Lot: (OldLot?)null, First: true)] : lots.Select((l, i) => (Lot: (OldLot?)l, First: i == 0)).ToList();
            foreach (var (lot, first) in candidates)
            {
                oldItems++;
                var key = lot is null ? "product:" + p.Id : "lot:" + lot.Id;
                var qtyMilli = 0L;
                var qtyExact = lot is null || TryScale(lot.Qty, 3, out qtyMilli);
                var costMinor = 0L;
                var costExact = TryScale(p.CostPrice, decimals, out costMinor);
                if (lot is not null) { oldQty += qtyMilli; if (lot.Qty > 0) { oldValueExact += lot.Qty * p.CostPrice; rowsWithStock++; } }
                var hubValue = HubValue(qtyMilli, costMinor);

                if (existing.ItemKeys.Contains(key)) { beforeItems++; beforeQty += qtyMilli; beforeValue += hubValue; continue; }

                var name = T(p.Name);
                string? reason = null;
                if (name.Length == 0) reason = "The product has no name.";
                else if (!qtyExact) reason = "The stock quantity has more than three decimals.";
                else if (!costExact) reason = "The purchase price has more decimals than this shop's currency can hold.";

                var retail = lot is not null && lot.SPrice > 0 ? lot.SPrice : p.SellingPrice;
                // THE TRAP: the column ReorderPoint holds the wholesale price, not the reorder level.
                decimal? wholesale = lot is not null && lot.WPrice > 0 ? lot.WPrice : p.ReorderPoint > 0 ? p.ReorderPoint : null;
                var retailMinor = 0L;
                var wholesaleMinor = 0L;
                if (reason is null && (retail < 0 || p.CostPrice < 0 || wholesale < 0)) reason = "A price is below zero.";
                else if (reason is null && (!TryScale(retail, decimals, out retailMinor) || (wholesale.HasValue && !TryScale(wholesale.Value, decimals, out wholesaleMinor)))) reason = "A price has more decimals than this shop's currency can hold.";
                if (reason is null && kind is null) reason = "This kind of business keeps no items.";

                if (reason is not null)
                {
                    skippedItems++; skippedQty += qtyMilli; skippedValue += hubValue;
                    skipped.Add(new SkippedRow("item", key, name.Length > 0 ? name : "(no name)", reason));
                    continue;
                }

                var reorderMilli = 0L;
                if (first) _ = TryScale(p.MinStock, 3, out reorderMilli);   // the reorder level is MinStock, set once for a product with several barcodes

                var barcode = lot is null ? Real(p.Barcode) : Real(lot.Barcode);   // the product's own Barcode is "0": real barcodes are stock rows
                if (barcode is not null && !takenBarcodes.Add(barcode))
                {
                    notes.Add(FindingLevels.Look, "barcode-twice", "{n} barcode(s) were already on another item, so those items were moved without a barcode.", name + " (" + barcode + ")");
                    barcode = null;
                }

                var attrs = new Dictionary<string, string>();
                if (subById.TryGetValue(p.SubCategoryId ?? -1, out var sub) && T(sub.Name).Length > 0) attrs["subCategory"] = T(sub.Name);
                if (T(p.HsnCode).Length > 0) attrs[ItemAttrs.Code] = T(p.HsnCode);
                var mrp = lot is not null && lot.Mrp > 0 ? lot.Mrp : p.Mrp;
                if (mrp > 0 && TryScale(mrp, decimals, out var mrpMinor)) attrs["mrp"] = shop.Text(mrpMinor);
                if (lot is not null) { if (T(lot.Size).Length > 0) attrs["size"] = T(lot.Size); if (T(lot.Colour).Length > 0) attrs["colour"] = T(lot.Colour); if (T(lot.Batch).Length > 0) attrs["batch"] = T(lot.Batch); }

                var itemName = name;
                if (lots.Count > 1)
                {
                    var tail = string.Join(", ", new[] { T(lot!.Size), T(lot.Colour), T(lot.Batch) }.Where(x => x.Length > 0));
                    if (tail.Length == 0) tail = barcode ?? Real(lot.Barcode) ?? "stock row " + lot.Id.ToString(CultureInfo.InvariantCulture);
                    itemName = name + " (" + tail + ")";
                }
                if (itemName.Length > 160) { notes.Add(FindingLevels.Look, "name-long", "{n} item name(s) were longer than the Hub allows and were cut short.", itemName); itemName = itemName[..160]; }

                var taxClass = TaxClassFor(p, shop, notes, T(p.Name));
                if (p.Cess > 0)
                {
                    if (shop.Country.Tax.ExtraTax is { } extra && p.Cess <= 100)
                    {
                        attrs[ItemAttrs.ExtraTax] = p.Cess.ToString("0.###", CultureInfo.InvariantCulture);
                        notes.Add(FindingLevels.Info, "cess", "{n} item(s) carry an extra tax (" + extra.Label + ") in the older program. It was kept as the item's own extra tax.", name);
                    }
                    else notes.Add(FindingLevels.Look, "cess", "{n} item(s) carry an extra tax in the older program that this shop's country does not use (or that is above 100 percent), so it was not moved.", name);
                }
                CheckTaxMode(p, shop, notes, name);
                if (lot is not null && ((lot.SPrice > 0 && lot.SPrice != p.SellingPrice) || (lot.WPrice > 0 && p.ReorderPoint > 0 && lot.WPrice != p.ReorderPoint)))
                    notes.Add(FindingLevels.Info, "price-differs", "{n} item(s) have a different price in the stock row than on the product. The stock row's price (the one the till used) was moved.", name);

                var input = new ItemInput
                {
                    Kind = kind!.Id, Sku = Blank(T(p.Code)), Barcode = barcode, Name = itemName, Category = CategoryOf(p, subById, data.Categories),
                    Unit = T(p.SalesUnit), PriceMinor = retailMinor, TradePriceMinor = wholesale.HasValue ? wholesaleMinor : null, CostMinor = costMinor, TaxClass = taxClass,
                    TrackStock = null, ReorderMilli = reorderMilli, Attrs = attrs,
                };
                var tracked = wouldTrackStock(kind.Id, null) == true;
                var moves = tracked && qtyMilli != 0;
                if (!tracked && qtyMilli != 0)
                {
                    notes.Add(FindingLevels.Look, "stock-not-kept", "{n} item(s) had stock in the older program, but this kind of business does not keep a stock count, so the stock was not moved.", name);
                    skippedQty += qtyMilli; skippedValue += hubValue;
                }
                else if (moves) { addedQty += qtyMilli; addedValue += hubValue; }
                if (lot is not null && qtyMilli < 0) notes.Add(FindingLevels.Look, "negative-stock", "{n} stock row(s) are below zero in the older program (the old program lets stock go below zero). They were moved as they are.", name + " (" + ShopContext.Qty(qtyMilli) + ")");
                if (lot is not null && lot.Damage > 0) notes.Add(FindingLevels.Look, "damaged", "{n} stock row(s) have damaged units. The older program counts them inside the stock; so does the Hub, so they will look available.", name);
                plan.Items.Add(new PlannedItem(key, input, !T(p.Status).Equals("No", StringComparison.OrdinalIgnoreCase), qtyMilli, moves));
                addedItems++;
            }
        }
        // Stock rows whose product is gone: stock the older program still counts, with nothing to attach it to.
        foreach (var l in data.Lots.Where(l => !productIds.Contains(l.ProductId)).OrderBy(l => l.Id))
        {
            oldItems++;
            _ = TryScale(l.Qty, 3, out var q);
            oldQty += q;
            if (existing.ItemKeys.Contains("lot:" + l.Id)) { beforeItems++; beforeQty += q; continue; }
            skippedItems++; skippedQty += q;
            skipped.Add(new SkippedRow("item", "lot:" + l.Id, "(stock row " + l.Id.ToString(CultureInfo.InvariantCulture) + ")", "The stock row belongs to product number " + l.ProductId.ToString(CultureInfo.InvariantCulture) + ", which does not exist."));
        }

        // ---- customers and suppliers -------------------------------------------------------------------------------------------------------
        var customerLedger = Ledgers(data.CustomerLedger);
        var supplierLedger = Ledgers(data.SupplierLedger);
        var customerBucket = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var supplierBucket = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var cards = new HashSet<string>(existing.Cards, StringComparer.Ordinal);
        var noLimitCeiling = ScaleUp(1_000_000_000m, decimals);

        long oldCustomers = 0, addedCustomers = 0, beforeCustomers = 0, skippedCustomers = 0;
        foreach (var c in data.Customers.OrderBy(c => c.Id))
        {
            oldCustomers++;
            var name = T(c.Name);
            var code = T(c.Code);
            var key = "customer:" + c.Id;
            if (c.Id == 1 && !name.Equals(WalkInName, StringComparison.OrdinalIgnoreCase)) notes.Add(FindingLevels.Look, "customer-one", "Customer number 1 is not named \"" + WalkInName + "\". Is it the walk-in customer? It was moved as an ordinary customer.", name);
            if (name.Equals(WalkInName, StringComparison.OrdinalIgnoreCase))
            {
                skippedCustomers++;
                skipped.Add(new SkippedRow("customer", key, name, "This is the walk-in customer of the older program (sales to nobody in particular). The Hub needs no record for that."));
                if (code.Length > 0) customerBucket.TryAdd(code, "skipped");
                if (code.Length > 0 && customerLedger.TryGetValue(code, out var walk) && walk.Debit != walk.Credit)
                    notes.Add(FindingLevels.Look, "walk-in-balance", "The walk-in customer has an amount in the older program's ledger. It was not moved.", name);
                continue;
            }
            if (existing.CustomerKeys.Contains(key)) { beforeCustomers++; if (code.Length > 0) customerBucket.TryAdd(code, "before"); continue; }
            if (name.Length == 0) { skippedCustomers++; skipped.Add(new SkippedRow("customer", key, "(no name)", "The customer has no name.")); if (code.Length > 0) customerBucket.TryAdd(code, "skipped"); continue; }

            var party = NewParty("customer", c.Code, name, c.ContactNo, c.EmailId, c.Address, c.City, c.State, c.ZipCode, c.TaxNumber, c.Remarks, shop, notes);
            // The credit limit counts only when its switch says Yes. "Not enforced" means the customer may owe any amount, and the Hub reads a limit of 0 as no credit at all.
            var enforced = T(c.LimitSwitch).Equals("Yes", StringComparison.OrdinalIgnoreCase);
            var limitSwitch = T(c.LimitSwitch);
            if (limitSwitch.Length > 0 && !enforced && !limitSwitch.Equals("No", StringComparison.OrdinalIgnoreCase))
                notes.Add(FindingLevels.Look, "limit-switch", "{n} customer(s) have a credit-limit switch that is neither Yes nor No. The older program treats that as not enforced, and so was it here.", name);
            if (enforced)
            {
                if (c.Limit > 0 && TryScale(c.Limit, decimals, out var limit)) party.CreditLimitMinor = limit;
                else if (c.Limit > 0) notes.Add(FindingLevels.Blocking, "limit-fraction", "{n} credit limit(s) have more decimals than this shop's currency can hold.", name);
            }
            else
            {
                party.CreditLimitMinor = noLimitCeiling;
                party.Notes = JoinNotes(party.Notes, "Credit limit: not enforced in the older program, so " + shop.Money(noLimitCeiling) + " was set here to keep credit sales working. Change it if you want a limit.");
                notes.Add(FindingLevels.Look, "no-limit", "{n} customer(s) had no credit limit in the older program (they could owe any amount). The Hub has no \"no limit\" setting, so each was given a very high limit (" + shop.Money(noLimitCeiling) + "), and a note says so. Change it on the person's record if you want a real limit.", name);
            }
            // The older program's fixed percent for a customer counts only when its switch says Yes; the Hub keeps it as the customer's own discount, given on every line.
            long discountMilli = 0;
            if (T(c.DiscountSwitch).Equals("Yes", StringComparison.OrdinalIgnoreCase) && decimal.TryParse(T(c.DiscountPercent), NumberStyles.Number, CultureInfo.InvariantCulture, out var discount) && discount > 0)
            {
                if (discount <= 100) { discountMilli = (long)Math.Round(discount * 1000m, MidpointRounding.AwayFromZero); notes.Add(FindingLevels.Look, "customer-discount", "{n} customer(s) had a fixed discount in the older program. It was kept as the customer's own discount (People), given on every line.", name); }
                else notes.Add(FindingLevels.Look, "customer-discount", "{n} customer(s) had a fixed discount above 100 percent in the older program. It does not make sense, so it was not moved.", name);
            }
            var card = Real(c.CardNo);
            if (card is not null && !cards.Add(card)) { notes.Add(FindingLevels.Look, "card-twice", "{n} loyalty card number(s) were used twice. Only the first person kept it.", name + " (" + card + ")"); card = null; }
            party.CardBarcode = card;

            var balance = 0L;
            if (code.Length == 0) notes.Add(FindingLevels.Look, "no-code", "{n} person(s) have no code in the older program, so what they owe could not be found and was not moved.", name);
            else if (!customerBucket.TryAdd(code, "added")) notes.Add(FindingLevels.Look, "code-twice", "{n} person(s) share a code with another in the older program. Only the first kept the balance.", name + " (" + code + ")");
            else if (customerLedger.TryGetValue(code, out var ledger))
            {
                if (!TryScale(ledger.Debit - ledger.Credit, decimals, out balance)) notes.Add(FindingLevels.Blocking, "balance-fraction", "{n} balance(s) have more decimals than this shop's currency can hold.", name);
                if (c.OpeningBalance != 0 && ledger.OpeningRows == 0) notes.Add(FindingLevels.Look, "opening-missing", "{n} person(s) have a typed opening balance that is not in the ledger. The ledger's total was moved, as the older program counts it.", name);
            }
            else if (c.OpeningBalance != 0) notes.Add(FindingLevels.Look, "opening-missing", "{n} person(s) have a typed opening balance that is not in the ledger. The ledger's total was moved, as the older program counts it.", name);
            plan.Parties.Add(new PlannedParty("customer", key, party, balance, discountMilli));
            addedCustomers++;
        }

        long oldSuppliers = 0, addedSuppliers = 0, beforeSuppliers = 0, skippedSuppliers = 0;
        foreach (var s in data.Suppliers.OrderBy(s => s.Id))
        {
            oldSuppliers++;
            var name = T(s.Name);
            var code = T(s.Code);
            var key = "supplier:" + s.Id;
            if (existing.SupplierKeys.Contains(key)) { beforeSuppliers++; if (code.Length > 0) supplierBucket.TryAdd(code, "before"); continue; }
            if (name.Length == 0) { skippedSuppliers++; skipped.Add(new SkippedRow("supplier", key, "(no name)", "The supplier has no name.")); if (code.Length > 0) supplierBucket.TryAdd(code, "skipped"); continue; }
            var party = NewParty("supplier", s.Code, name, s.ContactNo, s.EmailId, s.Address, s.City, s.State, s.ZipCode, s.TaxNumber, s.Remarks, shop, notes);
            var balance = 0L;
            if (code.Length == 0) notes.Add(FindingLevels.Look, "no-code", "{n} person(s) have no code in the older program, so what they owe could not be found and was not moved.", name);
            else if (!supplierBucket.TryAdd(code, "added")) notes.Add(FindingLevels.Look, "code-twice", "{n} person(s) share a code with another in the older program. Only the first kept the balance.", name + " (" + code + ")");
            else if (supplierLedger.TryGetValue(code, out var ledger))
            {
                if (!TryScale(ledger.Debit - ledger.Credit, decimals, out balance)) notes.Add(FindingLevels.Blocking, "balance-fraction", "{n} balance(s) have more decimals than this shop's currency can hold.", name);
                if (s.OpeningBalance != 0 && ledger.OpeningRows == 0) notes.Add(FindingLevels.Look, "opening-missing", "{n} person(s) have a typed opening balance that is not in the ledger. The ledger's total was moved, as the older program counts it.", name);
            }
            else if (s.OpeningBalance != 0) notes.Add(FindingLevels.Look, "opening-missing", "{n} person(s) have a typed opening balance that is not in the ledger. The ledger's total was moved, as the older program counts it.", name);
            plan.Parties.Add(new PlannedParty("supplier", key, party, balance));
            addedSuppliers++;
        }

        // Ledger rows of people who are not in the customer or supplier list: money with nobody to attach it to.
        var unknownCustomers = customerLedger.Where(x => !customerBucket.ContainsKey(x.Key) && x.Value.Debit != x.Value.Credit).Select(x => x.Key).ToList();
        if (unknownCustomers.Count > 0) notes.Add(FindingLevels.Look, "ledger-unknown-customer", "{n} customer code(s) have an amount in the older program's ledger but are not in its customer list. That money was not moved.", string.Join(", ", unknownCustomers.Take(3)), unknownCustomers.Count);
        var unknownSuppliers = supplierLedger.Where(x => !supplierBucket.ContainsKey(x.Key) && x.Value.Debit != x.Value.Credit).Select(x => x.Key).ToList();
        if (unknownSuppliers.Count > 0) notes.Add(FindingLevels.Look, "ledger-unknown-supplier", "{n} supplier code(s) have an amount in the older program's ledger but are not in its supplier list. That money was not moved.", string.Join(", ", unknownSuppliers.Take(3)), unknownSuppliers.Count);

        // ---- the report --------------------------------------------------------------------------------------------------------------------
        var lines = new List<ReportLine>
        {
            Line("items", "Items (a product with several barcodes becomes several items)", LineUnits.Count, oldItems, addedItems, beforeItems, skippedItems, 0),
            Line("customers", "Customers", LineUnits.Count, oldCustomers, addedCustomers, beforeCustomers, skippedCustomers, 0),
            Line("suppliers", "Suppliers", LineUnits.Count, oldSuppliers, addedSuppliers, beforeSuppliers, skippedSuppliers, 0),
            Line("stock-quantity", "Stock on hand, all items together", LineUnits.Quantity, oldQty, addedQty, beforeQty, skippedQty, 0),
        };
        _ = TryScale(oldValueExact, decimals, out var oldValueMinor, round: true);
        lines.Add(Line("stock-value", "Stock value at cost (items with stock above zero)", LineUnits.Money, oldValueMinor, addedValue, beforeValue, skippedValue, rowsWithStock + 1));
        lines.Add(BalanceLine("customers-owe", "Customers owe you", customerLedger, customerBucket, decimals, owedToShop: true, positive: true));
        lines.Add(BalanceLine("customers-credit", "You owe customers (credit balances)", customerLedger, customerBucket, decimals, owedToShop: true, positive: false));
        lines.Add(BalanceLine("suppliers-owe", "Suppliers owe you", supplierLedger, supplierBucket, decimals, owedToShop: true, positive: true));
        lines.Add(BalanceLine("suppliers-owed", "You owe suppliers", supplierLedger, supplierBucket, decimals, owedToShop: true, positive: false));

        foreach (var l in lines.Where(l => !l.Matches))
            notes.Add(FindingLevels.Blocking, "no-match-" + l.Key, "\"" + l.Label + "\" does not add up: " + Describe(l, shop) + " is not explained by anything in this report. Nothing was moved.");
        notes.Add(FindingLevels.Info, "not-moved", "This step moves items, stock, customers, suppliers and what each owes. It does not move the history of sales, purchases or payments. The older program is not changed.");

        var report = plan.Report;
        report.SourceKind = sourceKind; report.SourceId = sourceId; report.Source = describe;
        report.Lines = lines;
        report.Findings = notes.ToList();
        report.Skipped = skipped.Take(500).ToList();
        if (skipped.Count > 500) report.Findings.Add(new Finding(FindingLevels.Info, "skipped-more", (skipped.Count - 500).ToString(CultureInfo.InvariantCulture) + " more row(s) were left out; only the first 500 are listed.", skipped.Count - 500, []));
        report.ItemsToAdd = plan.Items.Count;
        report.CustomersToAdd = plan.Parties.Count(x => x.Entity == "customer");
        report.SuppliersToAdd = plan.Parties.Count(x => x.Entity == "supplier");
        report.StockMovesToAdd = plan.Items.Count(x => x.MovesStock);
        report.BalancesToAdd = plan.Parties.Count(x => x.BalanceMinor != 0);
        report.Fingerprint = Fingerprint(plan);
        return plan;
    }

    // ---- pieces ---------------------------------------------------------------------------------------------------------------------

    private static PartyInput NewParty(string kind, string? code, string name, string? phone, string? email, string? address, string? city, string? state, string? zip, string? taxNumber, string? remarks, ShopContext shop, Notes notes)
    {
        if (name.Length > 120) { notes.Add(FindingLevels.Look, "name-long", "{n} name(s) were longer than the Hub allows and were cut short.", name); name = name[..120]; }
        var mail = T(email);
        if (mail.Length > 0 && !mail.Contains('@')) { notes.Add(FindingLevels.Look, "email", "{n} e-mail address(es) did not look right and were left out.", name + " (" + mail + ")"); mail = ""; }
        var stateText = T(state);
        string? region = null;
        if (stateText.Length > 0 && shop.Country.Tax.Regions?.List is { Count: > 0 } regions)
        {
            region = regions.FirstOrDefault(r => string.Equals(r.Name?.Trim(), stateText, StringComparison.OrdinalIgnoreCase) || string.Equals(r.Code, stateText, StringComparison.OrdinalIgnoreCase))?.Code;
            if (region is null) notes.Add(FindingLevels.Look, "region", "{n} person(s) have a " + (shop.Country.Tax.Regions.Label ?? "region").ToLowerInvariant() + " that is not in this country's list. It stays in the address, but the " + (shop.Country.Tax.Regions.Label ?? "region").ToLowerInvariant() + " field is empty (it decides the tax on a sale).", name + " (" + stateText + ")");
        }
        return new PartyInput
        {
            Kind = kind, Code = Blank(T(code)), Name = name, Phone = Blank(T(phone)), Email = Blank(mail),
            Address = Blank(string.Join(", ", new[] { T(address), T(city), stateText, T(zip) }.Where(x => x.Length > 0))),
            TaxId = Blank(T(taxNumber)), Region = region, Notes = Blank(T(remarks)),
        };
    }

    private static string JoinNotes(string? existing, string extra) => string.IsNullOrWhiteSpace(existing) ? extra : existing + "\n" + extra;

    /// <summary>The Hub's tax class for an old product: from the two half rates added together, looked up in this shop's country list; "exempt" and "no tax" by the old sale-tax type.</summary>
    private static string TaxClassFor(OldProduct p, ShopContext shop, Notes notes, string name)
    {
        var type = T(p.SaleTaxType);
        if (type.Equals("Exempt GST", StringComparison.OrdinalIgnoreCase)) return shop.TaxCode("exempt");   // white-label-ok: the older POS's own stored value
        if (type.Equals("No Taxes", StringComparison.OrdinalIgnoreCase)) return shop.TaxCode("zero");
        var total = p.TaxHalf1 + p.TaxHalf2;   // the older program stores a rate as two equal halves
        var rates = shop.Country.Tax.Rates.Where(r => !r.Exempt && r.Percent != null && decimal.TryParse(r.Percent, NumberStyles.Number, CultureInfo.InvariantCulture, out var d) && d == total)
            .OrderBy(r => r.Legacy).ToList();
        if (rates.Count > 0) return rates[0].Code;
        if (total == 0) return shop.TaxCode("zero");
        notes.Add(FindingLevels.Look, "tax-rate", "{n} item(s) have a tax rate (" + total.ToString("0.##", CultureInfo.InvariantCulture) + "% or another) that is not in this country's tax list. They were given the standard rate. Please check them.", name + " (" + total.ToString("0.##", CultureInfo.InvariantCulture) + "%)");
        return "standard";
    }

    private static void CheckTaxMode(OldProduct p, ShopContext shop, Notes notes, string name)
    {
        var type = T(p.SaleTaxType);
        var includes = shop.Settings.PricesIncludeTax;
        if ((type.Equals("Exclusive", StringComparison.OrdinalIgnoreCase) && includes) || (type.Equals("Inclusive", StringComparison.OrdinalIgnoreCase) && !includes))
            notes.Add(FindingLevels.Look, "tax-mode", "{n} item(s) had their tax " + (includes ? "added on top of" : "inside") + " the price in the older program, but this shop's prices are set the other way round (Settings, Business). The Hub sets that for the whole shop, not for each item, so the price may need changing.", name);
    }

    private static string? CategoryOf(OldProduct p, Dictionary<long, OldSubCategory> subById, IReadOnlyList<OldCategory> categories)
    {
        if (!subById.TryGetValue(p.SubCategoryId ?? -1, out var sub)) return null;
        var category = T(sub.CategoryName);
        // The sub-category holds the NAME of its category; use the category's own spelling when it exists.
        var named = categories.FirstOrDefault(c => string.Equals(T(c.Name), category, StringComparison.OrdinalIgnoreCase));
        var text = named is not null ? T(named.Name) : category;
        return text.Length > 0 ? text : null;
    }

    private static ReportLine BalanceLine(string key, string label, Dictionary<string, (decimal Debit, decimal Credit, int Rows, int OpeningRows)> ledger, Dictionary<string, string> bucket, int decimals, bool owedToShop, bool positive)
    {
        long old = 0, added = 0, before = 0, skippedSum = 0;
        foreach (var (code, l) in ledger)
        {
            var net = owedToShop ? l.Debit - l.Credit : l.Credit - l.Debit;
            if (positive ? net <= 0 : net >= 0) continue;
            _ = TryScale(Math.Abs(net), decimals, out var amount, round: true);
            old += amount;
            switch (bucket.TryGetValue(code, out var b) ? b : "skipped")
            {
                case "added": added += amount; break;
                case "before": before += amount; break;
                default: skippedSum += amount; break;
            }
        }
        return Line(key, label, LineUnits.Money, old, added, before, skippedSum, 0);
    }

    private static ReportLine Line(string key, string label, string unit, long old, long added, long before, long skipped, long tolerance) =>
        new(key, label, unit, old, added, before, skipped, old - added - before - skipped, tolerance);

    private static string Describe(ReportLine l, ShopContext shop)
    {
        string Show(long v) => l.Unit switch { LineUnits.Money => shop.Money(v), LineUnits.Quantity => ShopContext.Qty(v), _ => v.ToString(CultureInfo.InvariantCulture) };
        return "the older program holds " + Show(l.Old) + ", the Hub would hold " + Show(l.Hub) + " and " + Show(l.Skipped) + " was left out on purpose";
    }

    private static Dictionary<string, (decimal Debit, decimal Credit, int Rows, int OpeningRows)> Ledgers(IEnumerable<OldLedgerTotal> rows)
    {
        var result = new Dictionary<string, (decimal, decimal, int, int)>(StringComparer.OrdinalIgnoreCase);
        foreach (var r in rows)
        {
            var key = T(r.PartyId);
            if (key.Length == 0) continue;
            result[key] = result.TryGetValue(key, out var x) ? (x.Item1 + r.Debit, x.Item2 + r.Credit, x.Item3 + r.Rows, x.Item4 + r.OpeningRows) : (r.Debit, r.Credit, r.Rows, r.OpeningRows);
        }
        return result;
    }

    /// <summary>What the Hub's own stock report would show for stock of this size at this cost: half-up, and nothing for stock at or below zero (the same rule as ReportService.StockValues).</summary>
    public static long HubValue(long qtyMilli, long costMinor) => qtyMilli <= 0 ? 0 : (long)(((Int128)2 * qtyMilli * costMinor + 1000) / 2000);

    private static decimal Pow10(int n) { var r = 1m; for (var i = 0; i < n; i++) r *= 10m; return r; }

    private static long ScaleUp(decimal major, int decimals) => (long)(major * Pow10(decimals));

    /// <summary>A number as whole units: money in minor units, a quantity in thousandths. False when it has more decimals than that (with <paramref name="round"/> it is rounded half up instead, for totals).</summary>
    private static bool TryScale(decimal value, int decimals, out long scaled, bool round = false)
    {
        var x = value * Pow10(decimals);
        var whole = decimal.Truncate(x);
        scaled = (long)(round ? Math.Round(x, 0, MidpointRounding.AwayFromZero) : whole);
        return x == whole;
    }

    private static string T(string? text) => (text ?? "").Trim();

    private static string? Blank(string text) => text.Length == 0 ? null : text;

    /// <summary>A real barcode: not empty and not the old program's placeholder "0".</summary>
    private static string? Real(string? barcode)
    {
        var t = T(barcode);
        return t.Length == 0 || t == "0" ? null : t;
    }

    private static string Fingerprint(ImportPlan plan)
    {
        var sb = new StringBuilder();
        sb.Append(plan.Report.SourceKind).Append('|').Append(plan.Report.SourceId).Append('\n');
        foreach (var l in plan.Report.Lines) sb.Append(l.Key).Append('|').Append(l.Old).Append('|').Append(l.Added).Append('|').Append(l.Before).Append('|').Append(l.Skipped).Append('|').Append(l.Unexplained).Append('\n');
        foreach (var f in plan.Report.Findings) sb.Append(f.Level).Append('|').Append(f.Code).Append('|').Append(f.Count).Append('\n');
        foreach (var i in plan.Items) sb.Append("i|").Append(i.OldKey).Append('|').Append(i.Input.Name).Append('|').Append(i.Input.PriceMinor).Append('|').Append(i.StockMilli).Append('\n');
        foreach (var p in plan.Parties) sb.Append("p|").Append(p.OldKey).Append('|').Append(p.Input.Name).Append('|').Append(p.BalanceMinor).Append('|').Append(p.Input.CreditLimitMinor).Append('|').Append(p.DiscountPctMilli).Append('\n');
        return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(sb.ToString())))[..24];
    }

    /// <summary>Collects the notes: the same note from many rows becomes one note with a count and a few examples.</summary>
    private sealed class Notes
    {
        private readonly List<string> _order = [];
        private readonly Dictionary<string, (string Level, string Text, int Count, List<string> Examples)> _by = [];

        public void Add(string level, string code, string text, string? example = null, int times = 1)
        {
            if (!_by.TryGetValue(code, out var entry)) { _by[code] = entry = (level, text, 0, []); _order.Add(code); }
            entry.Count += times;
            if (example is not null && entry.Examples.Count < 5 && !entry.Examples.Contains(example)) entry.Examples.Add(example);
            _by[code] = entry;
        }

        public List<Finding> ToList() => _order.Select(code =>
        {
            var e = _by[code];
            return new Finding(e.Level, code, e.Text.Replace("{n}", e.Count.ToString(CultureInfo.InvariantCulture), StringComparison.Ordinal), e.Count, e.Examples);
        }).OrderBy(f => f.Level switch { FindingLevels.Blocking => 0, FindingLevels.Look => 1, _ => 2 }).ToList();
    }
}
