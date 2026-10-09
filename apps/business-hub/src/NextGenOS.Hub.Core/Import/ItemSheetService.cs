using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using NextGenOS.Hub.Books;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Reports;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Import;

/// <summary>A row of the spreadsheet that cannot be used, and why, in words for the person who made the sheet. Row 1 is the line with the column names.</summary>
public sealed record SheetProblem(int Row, string? Name, string Message);

/// <summary>What one row of the spreadsheet would do: <c>add</c> a new item, <c>change</c> an item that is there, or leave it as it is (<c>same</c>).</summary>
public sealed record SheetLine(int Row, string Name, string Action, string Detail);

/// <summary>
/// The result of reading a spreadsheet, before anything is written: what it would add and change, what is wrong with it, and a fingerprint of the shop's items as they are now.
/// </summary>
public sealed record SheetCheck(string FileName, int Rows, int ToAdd, int ToChange, int Same, IReadOnlyList<SheetProblem> Problems, IReadOnlyList<SheetLine> Lines, IReadOnlyList<string> Notes, string Fingerprint)
{
    internal string Text { get; init; } = "";
    public bool HasProblems => Problems.Count > 0;
    public bool NothingToDo => ToAdd + ToChange == 0;
}

public sealed record SheetResult(long RunId, int Added, int Changed, int StockCounts, string Backup);

/// <summary>
/// Bringing items in from a spreadsheet, and sending them out to one (the older POS's "staff import launcher" and its Excel product screens, docs/old-programs/04-settings-messaging-system.md C.1,
/// and 01 section 6.6 for the opening stock). It is for any new shop, not only one moving from the older program: a person fills in the columns (a file saved as text from any spreadsheet:
/// the sheet goes out with the same columns, so the same file can be changed there and brought back).
/// <para>
/// Two steps, like the move from an older program: <see cref="Check"/> reads the file and writes NOTHING (it lists what would be added and changed, and every row that cannot be used); then
/// <see cref="Import"/> makes a copy of the shop's data and writes everything in one transaction, or nothing. A row is matched with an item that is already there by its barcode, else its SKU, else
/// its name; a column that is left empty leaves that field alone on an item that is there. Opening stock is taken for new items only (a count of an item that exists is made on the Products screen,
/// where it is valued and kept in the books).
/// </para>
/// </summary>
public sealed class ItemSheetService(HubDb db, ShopContextProvider shop, IClock clock, AuditService audit, CatalogService catalog, BooksService books, Access access)
{
    private const int MaxRows = 5000;

    // ---- the columns ----------------------------------------------------------------------------------------------------------------------

    private static string Canon(string? text) => new string((text ?? "").Where(char.IsLetterOrDigit).ToArray()).ToLowerInvariant();

    private sealed record Columns(ShopContext Context)
    {
        public string[] Headers() => new[]
        {
            "Name", "Category", "Barcode", "SKU", "Unit", "Price", "Trade price", "Cost price", "Tax",
            Context.Country.Tax.ItemCode?.Label, Context.Country.Tax.ExtraTax?.Label, "Reorder level", "Opening stock", "Kind", "On sale",
        }.Where(x => x is not null).Select(x => x!).ToArray();

        public string ItemCodeHeader => Context.Country.Tax.ItemCode?.Label ?? "";
        public string ExtraTaxHeader => Context.Country.Tax.ExtraTax?.Label ?? "";

        /// <summary>The key of a column heading: the names a spreadsheet might use for it, without capitals, spaces or marks.</summary>
        public string? KeyOf(string heading)
        {
            var c = Canon(heading);
            if (c.Length == 0) return null;
            if (ItemCodeHeader.Length > 0 && c == Canon(ItemCodeHeader)) return "itemcode";
            if (ExtraTaxHeader.Length > 0 && c == Canon(ExtraTaxHeader)) return "extratax";
            return c switch
            {
                "name" or "itemname" or "product" or "productname" or "title" => "name",
                "category" or "group" => "category",
                "barcode" or "ean" or "upc" => "barcode",
                "sku" => "sku",
                "unit" or "uom" or "soldby" => "unit",
                "price" or "sellingprice" or "retailprice" or "saleprice" => "price",
                "tradeprice" or "wholesaleprice" or "wholesale" => "trade",
                "cost" or "costprice" or "purchaseprice" => "cost",
                "tax" or "taxclass" or "taxrate" or "taxcode" => "tax",
                "itemcode" => "itemcode",
                "extratax" or "extrataxpercent" => "extratax",
                "reorderlevel" or "reorder" or "minstock" or "minimumstock" or "lowstock" => "reorder",
                "openingstock" or "stock" or "onhand" or "quantity" or "qty" => "stock",
                "kind" or "type" => "kind",
                "onsale" or "active" or "forsale" => "onsale",
                _ => null,
            };
        }
    }

    // ---- going out ----------------------------------------------------------------------------------------------------------------------

    /// <summary>Every item, in the columns <see cref="Check"/> reads, as a file for a spreadsheet (the stock column holds what is on the shelf now).</summary>
    public string Export()
    {
        access.Require(Perm.Catalog);
        var context = shop.Current;
        var columns = new Columns(context);
        var items = catalog.Search(null, null, null, 100_000, includeInactive: true);
        var rows = new List<IReadOnlyList<object?>>();
        foreach (var i in items)
        {
            var row = new List<object?>
            {
                i.Name, i.Category, i.Barcode, i.Sku, i.Unit, context.Text(i.PriceMinor), i.TradePriceMinor is { } t ? context.Text(t) : "", context.Text(i.CostMinor), i.TaxCode,
            };
            if (context.Country.Tax.ItemCode is not null) row.Add(i.Attrs.GetValueOrDefault(ItemAttrs.Code) ?? "");
            if (context.Country.Tax.ExtraTax is not null) row.Add(i.Attrs.GetValueOrDefault(ItemAttrs.ExtraTax) ?? "");
            row.Add(i.ReorderMilli > 0 ? ShopContext.Qty(i.ReorderMilli).TrimEnd('0').TrimEnd('.') : "");
            row.Add(i.TrackStock ? ShopContext.Qty(catalog.OnHandMilli(i.Id)).TrimEnd('0').TrimEnd('.') : "");
            row.Add(i.Kind);
            row.Add(i.Active ? "yes" : "no");
            rows.Add(row);
        }
        return Csv.Build(columns.Headers(), rows);
    }

    /// <summary>The column names only, to fill in.</summary>
    public string Template()
    {
        access.Require(Perm.Catalog);
        return Csv.Build(new Columns(shop.Current).Headers(), Array.Empty<IReadOnlyList<object?>>());
    }

    // ---- reading ------------------------------------------------------------------------------------------------------------------------

    private sealed record Plan(int Row, string Name, long? ExistingId, ItemInput Input, bool Active, long OpeningMilli, string Action, string Detail);

    private sealed record Planned(List<Plan> Plans, List<SheetProblem> Problems, List<string> Notes, int Rows);

    /// <summary>Reads the file and says what it would do. Nothing is written.</summary>
    public SheetCheck Check(string fileName, string text)
    {
        access.Require(Perm.Catalog);
        var planned = PlanFrom(text);
        return new SheetCheck(fileName, planned.Rows, planned.Plans.Count(p => p.Action == "add"), planned.Plans.Count(p => p.Action == "change"), planned.Plans.Count(p => p.Action == "same"),
            planned.Problems, planned.Plans.Select(p => new SheetLine(p.Row, p.Name, p.Action, p.Detail)).ToList(), planned.Notes, Fingerprint(planned)) { Text = text };
    }

    private static string Fingerprint(Planned planned)
    {
        var sb = new StringBuilder();
        foreach (var p in planned.Plans.OrderBy(x => x.Row))
            sb.Append(p.Row).Append('|').Append(p.Action).Append('|').Append(p.ExistingId).Append('|').Append(p.Name).Append('|').Append(p.Input.PriceMinor).Append('|').Append(p.Input.TradePriceMinor)
              .Append('|').Append(p.Input.CostMinor).Append('|').Append(p.Input.TaxClass).Append('|').Append(p.OpeningMilli).Append('|').Append(p.Active).Append('\n');
        foreach (var q in planned.Problems) sb.Append("P|").Append(q.Row).Append('|').Append(q.Message).Append('\n');
        return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(sb.ToString())));
    }

    private Planned PlanFrom(string text)
    {
        var context = shop.Current;
        var columns = new Columns(context);
        var problems = new List<SheetProblem>();
        var notes = new List<string>();
        var plans = new List<Plan>();
        var rows = Csv.Read(text ?? "");
        if (rows.Count == 0) { problems.Add(new(0, null, "The file is empty.")); return new(plans, problems, notes, 0); }

        var index = new Dictionary<string, int>();
        for (var c = 0; c < rows[0].Length; c++)
        {
            var key = columns.KeyOf(rows[0][c]);
            if (key is null) { if (rows[0][c].Trim().Length > 0) notes.Add($"The column \"{rows[0][c].Trim()}\" is not used."); continue; }
            if (!index.TryAdd(key, c)) problems.Add(new(1, null, $"The column \"{rows[0][c].Trim()}\" is there twice."));
        }
        if (!index.ContainsKey("name") && !index.ContainsKey("barcode") && !index.ContainsKey("sku"))
        {
            problems.Add(new(1, null, "The first line must have a column called Name, with the name of each item (or a column called Barcode or SKU, to change items that are there)."));
            return new(plans, problems, notes, rows.Count - 1);
        }
        if (rows.Count == 1) { problems.Add(new(0, null, "The file has the column names but no items under them.")); return new(plans, problems, notes, 0); }
        if (rows.Count - 1 > MaxRows) { problems.Add(new(0, null, $"The file has more than {MaxRows} items. Please bring them in in smaller files.")); return new(plans, problems, notes, rows.Count - 1); }

        var existing = catalog.Search(null, null, null, 100_000, includeInactive: true);
        var byBarcode = existing.Where(i => i.Barcode is not null).ToDictionary(i => i.Barcode!, StringComparer.Ordinal);
        var bySku = existing.Where(i => i.Sku is not null).GroupBy(i => i.Sku!, StringComparer.OrdinalIgnoreCase).ToDictionary(g => g.Key, g => g.ToList(), StringComparer.OrdinalIgnoreCase);
        var byName = existing.GroupBy(i => i.Name.Trim(), StringComparer.OrdinalIgnoreCase).ToDictionary(g => g.Key, g => g.ToList(), StringComparer.OrdinalIgnoreCase);
        var seen = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        var defaultKind = context.Industry.ItemKinds.FirstOrDefault(k => k.TracksStock)?.Id ?? context.Industry.ItemKinds[0].Id;

        for (var r = 1; r < rows.Count; r++)
        {
            var rowNo = r + 1;   // the line in the spreadsheet; the column names are line 1
            string Cell(string key) => index.TryGetValue(key, out var c) && c < rows[r].Length ? rows[r][c].Trim() : "";
            bool Has(string key) => Cell(key).Length > 0;
            var name = Cell("name");
            var rowProblems = problems.Count;
            void Bad(string message) => problems.Add(new(rowNo, name.Length == 0 ? null : name, message));

            var barcode = Cell("barcode");
            var sku = Cell("sku");
            // Which item is this? The barcode first, then the SKU, then the name.
            Item? match = null;
            if (barcode.Length > 0 && byBarcode.TryGetValue(barcode, out var byB)) match = byB;
            if (sku.Length > 0 && bySku.TryGetValue(sku, out var bySk))
            {
                if (bySk.Count > 1) Bad($"More than one item has the SKU \"{sku}\", so this row cannot say which one it means.");
                else if (match is not null && match.Id != bySk[0].Id) Bad($"The barcode and the SKU are of two different items ({match.Name} and {bySk[0].Name}).");
                else match ??= bySk[0];
            }
            if (match is null && barcode.Length == 0 && sku.Length == 0 && name.Length > 0 && byName.TryGetValue(name, out var byN))
            {
                if (byN.Count > 1) Bad($"More than one item is called \"{name}\", so this row cannot say which one it means. Give its barcode or SKU.");
                else match = byN[0];
            }

            if (name.Length == 0)
            {
                if (match is null) { Bad(barcode.Length > 0 || sku.Length > 0 ? "There is no name, and no item with that barcode or SKU is in the shop yet." : "There is no name."); continue; }
                name = match.Name;
            }

            // The same item twice in the file.
            var key = barcode.Length > 0 ? "b:" + barcode : sku.Length > 0 ? "s:" + sku : "n:" + name;
            if (seen.TryGetValue(key, out var firstRow)) Bad($"This item is also on row {firstRow}.");
            else seen[key] = rowNo;

            var input = match is null
                ? new ItemInput { Kind = defaultKind, Name = name, TaxClass = "standard" }
                : new ItemInput { Kind = match.Kind, Sku = match.Sku, Barcode = match.Barcode, Name = match.Name, Category = match.Category, Unit = match.Unit, PriceMinor = match.PriceMinor, TradePriceMinor = match.TradePriceMinor,
                                  CostMinor = match.CostMinor, TaxClass = match.TaxCode, TrackStock = match.TrackStock, ReorderMilli = match.ReorderMilli, Station = match.Station, DurationMin = match.DurationMin, Attrs = new Dictionary<string, string>(match.Attrs) };
            var changes = new List<string>();
            void Set<T>(string label, T before, T after, Action apply, Func<T, string> show) where T : notnull
            {
                if (EqualityComparer<T>.Default.Equals(before, after)) return;
                apply();
                changes.Add($"{label} {show(before)} → {show(after)}");
            }
            string Plain(string? s) => string.IsNullOrEmpty(s) ? "none" : s;
            string Money(long minor) => context.Money(minor);
            bool Parse(string key, int decimals, string label, out long value)
            {
                value = 0;
                if (!Has(key)) return false;
                if (Number(Cell(key), decimals, out value, out var why)) return true;
                Bad($"{label}: {why}");
                return false;
            }

            if (match is null) input.Name = name; else if (!string.Equals(match.Name, name, StringComparison.Ordinal)) Set("Name", match.Name, name, () => input.Name = name, Plain);
            if (Has("category")) Set("Category", Plain(input.Category), Cell("category"), () => input.Category = Cell("category"), x => x);
            if (barcode.Length > 0) Set("Barcode", Plain(input.Barcode), barcode, () => input.Barcode = barcode, x => x);
            if (sku.Length > 0) Set("SKU", Plain(input.Sku), sku, () => input.Sku = sku, x => x);
            if (Has("unit")) Set("Sold by", input.Unit, Cell("unit"), () => input.Unit = Cell("unit"), x => x);
            if (Parse("price", context.Decimals, "The price", out var price)) Set("Price", input.PriceMinor, price, () => input.PriceMinor = price, Money);
            if (Parse("trade", context.Decimals, "The trade price", out var trade)) Set("Trade price", input.TradePriceMinor ?? -1, trade, () => input.TradePriceMinor = trade, v => v < 0 ? "none" : Money(v));
            if (Parse("cost", context.Decimals, "The cost price", out var cost)) Set("Cost price", input.CostMinor, cost, () => input.CostMinor = cost, Money);
            if (Parse("reorder", 3, "The reorder level", out var reorder)) Set("Reorder level", input.ReorderMilli, reorder, () => input.ReorderMilli = reorder, v => ShopContext.Qty(v).TrimEnd('0').TrimEnd('.'));
            if (Has("tax"))
            {
                var resolved = ResolveTax(context, Cell("tax"));
                if (resolved is null) Bad($"\"{Cell("tax")}\" is not a tax of {context.Country.Name}. Use the name or the percent as it is on the Products screen.");
                else Set("Tax", TaxName(context, context.TaxCode(input.TaxClass)), TaxName(context, resolved), () => input.TaxClass = resolved, x => x);
            }
            if (Has("itemcode") && context.Country.Tax.ItemCode is not null) Set(context.Country.Tax.ItemCode.Label, input.Attrs.GetValueOrDefault(ItemAttrs.Code) ?? "none", Cell("itemcode"), () => input.Attrs[ItemAttrs.Code] = Cell("itemcode"), x => x);
            if (Has("extratax") && context.Country.Tax.ExtraTax is not null)
            {
                var extraLabel = context.Country.Tax.ExtraTax.Label;
                if (Parse("extratax", 3, "The " + extraLabel.ToLowerInvariant(), out var extra))
                {
                    if (extra > 100_000) Bad($"The {extraLabel.ToLowerInvariant()} must be between 0 and 100 percent.");
                    else Set(extraLabel, input.Attrs.GetValueOrDefault(ItemAttrs.ExtraTax) ?? "none", Cell("extratax"), () => input.Attrs[ItemAttrs.ExtraTax] = Cell("extratax"), x => x);
                }
            }
            if (Has("kind"))
            {
                var kind = context.Industry.ItemKinds.FirstOrDefault(k => string.Equals(k.Id, Cell("kind"), StringComparison.OrdinalIgnoreCase) || string.Equals(k.Label, Cell("kind"), StringComparison.OrdinalIgnoreCase));
                if (kind is null) Bad($"\"{Cell("kind")}\" is not a kind of item this business keeps ({string.Join(", ", context.Industry.ItemKinds.Select(k => k.Label))}).");
                else Set("Kind", input.Kind, kind.Id, () => input.Kind = kind.Id, x => x);
            }

            var active = match?.Active ?? true;
            if (Has("onsale"))
            {
                var word = Canon(Cell("onsale"));
                if (word is "yes" or "y" or "true" or "1" or "on") { if (!active) { changes.Add("On sale no → yes"); } active = true; }
                else if (word is "no" or "n" or "false" or "0" or "off") { if (active) { changes.Add("On sale yes → no"); } active = false; }
                else Bad($"\"{Cell("onsale")}\" is not yes or no.");
            }

            long opening = 0;
            if (Has("stock"))
            {
                if (!Parse("stock", 3, "The opening stock", out opening)) { /* said above */ }
                else if (match is not null) notes.Add($"Row {rowNo}: the stock of \"{match.Name}\" is not changed from here (the item is there already). Count it on the Products screen.");
                else if (opening > 0 && catalog.WouldTrackStock(input.Kind, null) != true) { notes.Add($"Row {rowNo}: \"{name}\" is a kind of item that keeps no stock, so its opening stock is left out."); opening = 0; }
            }

            if (problems.Count == rowProblems && catalog.Problem(input) is { } why) Bad(why);
            if (problems.Count > rowProblems) continue;
            var action = match is null ? "add" : changes.Count > 0 ? "change" : "same";
            var detail = match is null ? $"New: price {Money(input.PriceMinor)}" + (opening > 0 ? $", {ShopContext.Qty(opening).TrimEnd('0').TrimEnd('.')} in stock" : "") : changes.Count > 0 ? string.Join("; ", changes) : "As it is";
            plans.Add(new Plan(rowNo, name, match?.Id, input, active, opening, action, detail));
        }
        return new(plans, problems, notes, rows.Count - 1);
    }

    private static string TaxName(ShopContext context, string code) => context.Country.Tax.Rates.FirstOrDefault(r => r.Code == code)?.Label ?? code;

    /// <summary>A tax as a spreadsheet may have it: the class or code the Hub uses, the label on the Products screen, or just the percent ("18" or "18%"). Null when it means nothing, or more than one.</summary>
    private static string? ResolveTax(ShopContext context, string text)
    {
        var typed = text.Trim();
        var sameCode = context.Country.Tax.Rates.FirstOrDefault(r => string.Equals(r.Code, typed, StringComparison.OrdinalIgnoreCase));
        if (sameCode is not null) return sameCode.Code;
        try { return context.TaxCode(typed.ToLowerInvariant()); } catch (ArgumentException) { /* try the other ways */ }
        var live = context.Country.Tax.Rates.Where(r => !r.Legacy).ToList();
        var byLabel = live.Where(r => string.Equals(r.Label, text.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
        if (byLabel.Count == 1) return byLabel[0].Code;
        var percent = text.Trim().TrimEnd('%').Trim().Replace(',', '.');
        if (decimal.TryParse(percent, NumberStyles.Number, CultureInfo.InvariantCulture, out var p))
        {
            var byPercent = live.Where(r => decimal.TryParse(r.Percent, NumberStyles.Number, CultureInfo.InvariantCulture, out var q) && q == p).ToList();
            if (byPercent.Count == 1) return byPercent[0].Code;
        }
        return null;
    }

    /// <summary>
    /// A number as a spreadsheet writes it, to whole thousandths of the unit (or minor units): "1299.5", "1,299.50", "1.299,50" and "₹ 1299" all work. A separator followed by more digits than the unit
    /// can have is a thousands separator. Nothing below zero. <paramref name="why"/> says what is wrong in words.
    /// </summary>
    internal static bool Number(string text, int decimals, out long scaled, out string why)
    {
        scaled = 0; why = "";
        var s = text.Trim();
        if (s.StartsWith('-') || s.StartsWith('−') || s.StartsWith('(')) { why = "it cannot be below nothing."; return false; }
        var firstDigit = s.ToList().FindIndex(char.IsAsciiDigit);
        if (firstDigit < 0) { why = $"\"{text.Trim()}\" is not a number."; return false; }
        // Whatever comes before the first digit is a currency mark ("Rs. 99", "₹ 1299"); only a point or comma right at the start belongs to the number (".5").
        s = s[(firstDigit == 1 && s[0] is '.' or ',' ? 0 : firstDigit)..];
        s = new string(s.Where(ch => char.IsAsciiDigit(ch) || ch == '.' || ch == ',').ToArray());
        var lastDot = s.LastIndexOf('.');
        var lastComma = s.LastIndexOf(',');
        char? point = null;
        if (lastDot >= 0 && lastComma >= 0) point = lastDot > lastComma ? '.' : ',';
        else if (lastDot >= 0 || lastComma >= 0)
        {
            var sep = lastDot >= 0 ? '.' : ',';
            var parts = s.Split(sep);
            if (parts.Length == 2 && parts[1].Length <= decimals && parts[1].Length > 0) point = sep;   // one separator and few digits after it: a decimal point
            else if (parts.Length == 2 && parts[1].Length == 0) { s = parts[0]; }                         // "12." : just the whole part
            // otherwise the separators are thousands separators and are taken out below
        }
        var whole = new StringBuilder();
        var fraction = new StringBuilder();
        var afterPoint = false;
        foreach (var ch in s)
        {
            if (point is not null && ch == point.Value && !afterPoint) { afterPoint = true; continue; }
            if (!char.IsAsciiDigit(ch)) continue;
            (afterPoint ? fraction : whole).Append(ch);
        }
        if (fraction.Length > decimals) { why = $"\"{text.Trim()}\" has more than {decimals} digits after the point."; return false; }
        try { scaled = (long)NextGenOS.Tax.MoneyText.Parse((whole.Length == 0 ? "0" : whole.ToString()) + (fraction.Length > 0 ? "." + fraction : ""), decimals); }
        catch (Exception ex) when (ex is FormatException or OverflowException) { why = $"\"{text.Trim()}\" is not a number."; return false; }
        return true;
    }

    // ---- writing ----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Writes what <see cref="Check"/> showed: it reads the file again against the shop as it is NOW and refuses if the report is not the same or anything in it is wrong. A copy of the shop's data
    /// is made first (if it cannot be made, nothing is changed). Then everything is written in one transaction, or nothing is.
    /// </summary>
    public SheetResult Import(SheetCheck check, long? userId)
    {
        access.Require(Perm.Catalog);
        var planned = PlanFrom(check.Text);
        if (Fingerprint(planned) != check.Fingerprint)
            throw new HubException("sheet-changed", "The shop's items changed since you checked the file, so nothing was written. Please check the file again and read the new list.");
        if (planned.Problems.Count > 0)
            throw new HubException("sheet-problems", "The file has rows that cannot be used, so nothing was written. Fix them in the spreadsheet and check it again.");
        if (planned.Plans.All(p => p.Action == "same"))
            throw new HubException("sheet-nothing", "Everything in the file is in the shop already, exactly as it is. There is nothing to write.");

        var stamp = clock.UtcNow.UtcDateTime.ToString("yyyyMMdd'T'HHmmss'Z'", CultureInfo.InvariantCulture);
        var backup = db.BackupNow("before-sheet-" + stamp);   // throws, and nothing changes, if the copy cannot be made
        return db.InTransaction((c, t) =>
        {
            int added = 0, changed = 0, counts = 0;
            foreach (var plan in planned.Plans.Where(p => p.Action != "same"))
            {
                try
                {
                    long id;
                    if (plan.ExistingId is { } existingId) { catalog.Update(c, t, existingId, plan.Input); id = existingId; changed++; }
                    else { id = catalog.Create(c, t, plan.Input); added++; }
                    HubDb.Exec(c, "UPDATE items SET active = $a WHERE id = $id", t, ("$a", plan.Active ? 1 : 0), ("$id", id));
                    if (plan.ExistingId is null && plan.OpeningMilli > 0)
                    {
                        var move = StockCost.Insert(c, t, id, plan.OpeningMilli, "opening stock", null, "Brought in from a spreadsheet", clock.UtcNow, userId, StockCost.Worth(plan.OpeningMilli, plan.Input.CostMinor));
                        books.SyncStockMove(c, t, move, userId);
                        counts++;
                    }
                }
                catch (HubException ex) { throw new HubException(ex.Code, $"Row {plan.Row} (\"{plan.Name}\") could not be written, so nothing was written. {ex.Message}"); }
            }
            var runId = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MAX(id), 0) + 1 FROM import_runs WHERE tenant_id = 'local' AND site_id = 'main'", t), CultureInfo.InvariantCulture);
            var file = check.FileName.Length > 80 ? check.FileName[..80] : check.FileName;
            HubDb.Exec(c,
                "INSERT INTO import_runs(id, at, user_id, source_kind, source_id, items_added, customers_added, suppliers_added, stock_moves_added, balances_added, backup_path, report) VALUES ($id, $at, $u, 'spreadsheet', $s, $i, 0, 0, $m, 0, $bk, $rep)", t,
                ("$id", runId), ("$at", Iso.Text(clock.UtcNow)), ("$u", userId), ("$s", file), ("$i", added), ("$m", counts), ("$bk", backup),
                ("$rep", JsonSerializer.Serialize(new Dictionary<string, object?> { ["rows"] = planned.Rows, ["added"] = added, ["changed"] = changed, ["stockCounts"] = counts, ["notes"] = planned.Notes })));
            audit.Log(c, t, userId, "import", "import", runId, $"From the spreadsheet {file}: {added} item(s) added, {changed} changed, {counts} opening stock count(s). A copy of the shop's data was made first: {Path.GetFileName(backup)}.");
            return new SheetResult(runId, added, changed, counts, backup);
        });
    }
}
