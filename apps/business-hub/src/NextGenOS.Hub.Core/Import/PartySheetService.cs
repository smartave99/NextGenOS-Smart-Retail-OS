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

/// <summary>The result of reading a spreadsheet of customers and suppliers, before anything is written.</summary>
public sealed record PartySheetCheck(string FileName, int Rows, int ToAdd, int ToChange, int Same, IReadOnlyList<SheetProblem> Problems, IReadOnlyList<SheetLine> Lines, IReadOnlyList<string> Notes, string Fingerprint)
{
    internal string Text { get; init; } = "";
    public bool HasProblems => Problems.Count > 0;
    public bool NothingToDo => ToAdd + ToChange == 0;
}

public sealed record PartySheetResult(long RunId, int Added, int Changed, int Balances, string Backup);

/// <summary>
/// Bringing customers and suppliers in from a spreadsheet, and sending them out to one (the older POS's staff import launcher, docs/old-programs/04 C.1, which also brought in customer and supplier lists).
/// It works as the item sheet does: <see cref="Check"/> reads the file and writes nothing; <see cref="Import"/> makes a copy of the shop's data and writes everything in one transaction or nothing. A row is
/// matched with a person who is there already by phone number, else by name (the same kind of person); an empty cell leaves that field alone. What a new person owes (or is owed) is taken for new people
/// only, and goes into the books as an opening balance; the balance of somebody who is there is changed through their account, not from here.
/// </summary>
public sealed class PartySheetService(HubDb db, ShopContextProvider shop, IClock clock, AuditService audit, PartyService parties, BooksService books, Access access)
{
    private const int MaxRows = 5000;

    private static string Canon(string? text) => new string((text ?? "").Where(char.IsLetterOrDigit).ToArray()).ToLowerInvariant();

    /// <summary>The same number written with or without a country code or spaces: one ends with the other (and the shorter has at least 7 digits).</summary>
    private static bool SamePhone(string a, string b) => Math.Min(a.Length, b.Length) >= 7 && (a.EndsWith(b, StringComparison.Ordinal) || b.EndsWith(a, StringComparison.Ordinal));

    private static string Digits(string? text) => new string((text ?? "").Where(char.IsAsciiDigit).ToArray());

    private sealed record Columns(ShopContext Context)
    {
        public string TaxHeader => Context.Country.Tax.BusinessId?.Label ?? "";
        public string RegionHeader => Context.Country.Tax.Regions is { List.Count: > 1 } r ? r.Label ?? "Region" : "";

        public string[] Headers() => new[]
        {
            "Name", "Kind", "Phone", "Email", "Address", TaxHeader.Length > 0 ? TaxHeader : null, RegionHeader.Length > 0 ? RegionHeader : null, "Credit limit", "Days to pay", "Prices", "Balance", "Notes", "In use",
        }.Where(x => x is not null).Select(x => x!).ToArray();

        public string? KeyOf(string heading)
        {
            var c = Canon(heading);
            if (c.Length == 0) return null;
            if (TaxHeader.Length > 0 && c == Canon(TaxHeader)) return "tax";
            if (RegionHeader.Length > 0 && c == Canon(RegionHeader)) return "region";
            return c switch
            {
                "name" or "customername" or "suppliername" or "party" => "name",
                "kind" or "type" or "customertype" => "kind",
                "phone" or "mobile" or "contact" or "contactno" or "phonenumber" => "phone",
                "email" or "emailid" => "email",
                "address" => "address",
                "taxid" or "taxnumber" or "gstin" or "gst" or "vat" or "tin" => "tax",
                "state" or "region" or "province" => "region",
                "creditlimit" or "limit" => "limit",
                "daystopay" or "terms" or "termsdays" or "creditdays" => "days",
                "prices" or "pricelevel" or "pricelist" => "prices",
                "balance" or "openingbalance" or "outstanding" => "balance",
                "notes" or "remarks" => "notes",
                "inuse" or "active" => "active",
                _ => null,
            };
        }
    }

    // ---- going out ----------------------------------------------------------------------------------------------------------------------

    /// <summary>Everybody the shop deals with, in the columns <see cref="Check"/> reads, as a file for a spreadsheet (the balance column is left empty: it is for opening balances of new people).</summary>
    public string Export()
    {
        access.Require(Perm.Parties);
        var context = shop.Current;
        var columns = new Columns(context);
        var rows = new List<IReadOnlyList<object?>>();
        foreach (var p in parties.Search(null, null, 100_000, true))
        {
            var row = new List<object?> { p.Name, p.Kind, p.Phone, p.Email, p.Address };
            if (columns.TaxHeader.Length > 0) row.Add(p.TaxId);
            if (columns.RegionHeader.Length > 0) row.Add(RegionName(context, p.Region));
            row.Add(p.CreditLimitMinor > 0 ? context.Text(p.CreditLimitMinor) : "");
            row.Add(p.TermsDays > 0 ? p.TermsDays.ToString(CultureInfo.InvariantCulture) : "");
            row.Add(p.PriceLevel == "trade" ? "trade" : "");
            row.Add("");
            row.Add(p.Notes);
            row.Add(p.Active ? "yes" : "no");
            rows.Add(row);
        }
        return Csv.Build(columns.Headers(), rows);
    }

    public string Template()
    {
        access.Require(Perm.Parties);
        return Csv.Build(new Columns(shop.Current).Headers(), Array.Empty<IReadOnlyList<object?>>());
    }

    private static string? RegionName(ShopContext context, string? code) =>
        code is null ? null : context.Country.Tax.Regions?.List.FirstOrDefault(r => r.Code == code)?.Name ?? code;

    // ---- reading ------------------------------------------------------------------------------------------------------------------------

    private sealed record Plan(int Row, string Name, long? ExistingId, PartyInput Input, bool Active, long BalanceMinor, string Action, string Detail);

    private sealed record Planned(List<Plan> Plans, List<SheetProblem> Problems, List<string> Notes, int Rows);

    public PartySheetCheck Check(string fileName, string text)
    {
        access.Require(Perm.Parties);
        var planned = PlanFrom(text);
        return new PartySheetCheck(fileName, planned.Rows, planned.Plans.Count(p => p.Action == "add"), planned.Plans.Count(p => p.Action == "change"), planned.Plans.Count(p => p.Action == "same"),
            planned.Problems, planned.Plans.Select(p => new SheetLine(p.Row, p.Name, p.Action, p.Detail)).ToList(), planned.Notes, Fingerprint(planned)) { Text = text };
    }

    private static string Fingerprint(Planned planned)
    {
        var sb = new StringBuilder();
        foreach (var p in planned.Plans.OrderBy(x => x.Row))
            sb.Append(p.Row).Append('|').Append(p.Action).Append('|').Append(p.ExistingId).Append('|').Append(p.Name).Append('|').Append(p.Input.Kind).Append('|').Append(p.Input.Phone).Append('|')
              .Append(p.Input.CreditLimitMinor).Append('|').Append(p.BalanceMinor).Append('|').Append(p.Active).Append('\n');
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
        if (!index.ContainsKey("name")) { problems.Add(new(1, null, "The first line must have a column called Name, with the name of each person.")); return new(plans, problems, notes, rows.Count - 1); }
        if (rows.Count == 1) { problems.Add(new(0, null, "The file has the column names but nobody under them.")); return new(plans, problems, notes, 0); }
        if (rows.Count - 1 > MaxRows) { problems.Add(new(0, null, $"The file has more than {MaxRows} rows. Please bring them in in smaller files.")); return new(plans, problems, notes, rows.Count - 1); }

        var existing = parties.Search(null, null, 100_000, true);
        var seen = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        var kinds = context.Industry.PartyKinds;
        var defaultKind = kinds.FirstOrDefault(k => k.Id == "customer")?.Id ?? kinds[0].Id;

        for (var r = 1; r < rows.Count; r++)
        {
            var rowNo = r + 1;
            string Cell(string key) => index.TryGetValue(key, out var c) && c < rows[r].Length ? rows[r][c].Trim() : "";
            bool Has(string key) => Cell(key).Length > 0;
            var name = Cell("name");
            var before = problems.Count;
            void Bad(string message) => problems.Add(new(rowNo, name.Length == 0 ? null : name, message));
            if (name.Length == 0) { Bad("There is no name."); continue; }

            var kind = defaultKind;
            if (Has("kind"))
            {
                var typed = Cell("kind");
                var found = kinds.FirstOrDefault(k => string.Equals(k.Id, typed, StringComparison.OrdinalIgnoreCase) || string.Equals(k.Label, typed, StringComparison.OrdinalIgnoreCase)
                    || string.Equals(context.Plural(k.Id), typed, StringComparison.OrdinalIgnoreCase));
                if (found is null) Bad($"\"{typed}\" is not a kind of person this business keeps ({string.Join(", ", kinds.Select(k => k.Label))}).");
                else kind = found.Id;
            }

            var phone = Cell("phone");
            var phoneKey = Digits(phone);
            Party? match = null;
            if (phoneKey.Length >= 6) match = existing.FirstOrDefault(p => p.Kind == kind && SamePhone(Digits(p.Phone), phoneKey));
            if (match is null)
            {
                var sameName = existing.Where(p => p.Kind == kind && string.Equals(p.Name.Trim(), name, StringComparison.OrdinalIgnoreCase)).ToList();
                if (sameName.Count > 1 && phoneKey.Length < 6) Bad($"More than one person is called \"{name}\", so this row cannot say which one it means. Give the phone number.");
                else if (sameName.Count >= 1 && (phoneKey.Length < 6 || sameName[0].Phone is null)) match = sameName[0];
            }

            var key = kind + "|" + (phoneKey.Length >= 6 ? phoneKey[^Math.Min(10, phoneKey.Length)..] : name);
            if (seen.TryGetValue(key, out var firstRow)) Bad($"This person is also on row {firstRow}.");
            else seen[key] = rowNo;

            var input = match is null
                ? new PartyInput { Kind = kind, Name = name }
                : new PartyInput { Kind = match.Kind, Code = match.Code, Name = match.Name, Phone = match.Phone, Email = match.Email, Address = match.Address, TaxId = match.TaxId, Region = match.Region, MemberType = match.MemberType,
                                   PriceLevel = match.PriceLevel, CreditLimitMinor = match.CreditLimitMinor, TermsDays = match.TermsDays, CardBarcode = match.CardBarcode, Notes = match.Notes };
            var changes = new List<string>();
            void Set<T>(string label, T was, T now, Action apply, Func<T, string> show) where T : notnull
            {
                if (EqualityComparer<T>.Default.Equals(was, now)) return;
                apply();
                changes.Add($"{label} {show(was)} → {show(now)}");
            }
            string Plain(string? s) => string.IsNullOrEmpty(s) ? "none" : s;
            if (match is not null && !string.Equals(match.Name, name, StringComparison.Ordinal)) Set("Name", match.Name, name, () => input.Name = name, x => x);
            if (phone.Length > 0) Set("Phone", Plain(input.Phone), phone, () => input.Phone = phone, x => x);
            if (Has("email")) Set("Email", Plain(input.Email), Cell("email"), () => input.Email = Cell("email"), x => x);
            if (Has("address")) Set("Address", Plain(input.Address), Cell("address"), () => input.Address = Cell("address"), x => x);
            if (Has("tax") && columns.TaxHeader.Length > 0) Set(columns.TaxHeader, Plain(input.TaxId), Cell("tax"), () => input.TaxId = Cell("tax"), x => x);
            if (Has("region") && columns.RegionHeader.Length > 0)
            {
                var typed = Cell("region");
                var region = context.Country.Tax.Regions!.List.FirstOrDefault(x => string.Equals(x.Code, typed, StringComparison.OrdinalIgnoreCase) || string.Equals(x.Name, typed, StringComparison.OrdinalIgnoreCase));
                if (region is null) Bad($"\"{typed}\" is not one of the {columns.RegionHeader.ToLowerInvariant()}s of {context.Country.Name}.");
                else Set(columns.RegionHeader, Plain(RegionName(context, input.Region)), region.Name, () => input.Region = region.Code, x => x);
            }
            bool Parse(string k, int decimals, string label, out long value)
            {
                value = 0;
                if (!Has(k)) return false;
                if (ItemSheetService.Number(Cell(k), decimals, out value, out var why)) return true;
                Bad($"{label}: {why}");
                return false;
            }
            if (Parse("limit", context.Decimals, "The credit limit", out var limit)) Set("Credit limit", input.CreditLimitMinor, limit, () => input.CreditLimitMinor = limit, context.Money);
            if (Has("days"))
            {
                if (!int.TryParse(Cell("days"), NumberStyles.None, CultureInfo.InvariantCulture, out var days) || days > 365) Bad("Days to pay must be a whole number from 0 to 365.");
                else Set("Days to pay", input.TermsDays, days, () => input.TermsDays = days, d => d.ToString(CultureInfo.InvariantCulture));
            }
            if (Has("prices"))
            {
                var word = Canon(Cell("prices"));
                if (word is "trade" or "wholesale") Set("Prices", input.PriceLevel, "trade", () => input.PriceLevel = "trade", x => x);
                else if (word is "retail" or "normal" or "usual") Set("Prices", input.PriceLevel, "retail", () => input.PriceLevel = "retail", x => x);
                else Bad($"\"{Cell("prices")}\" is not retail or trade.");
            }
            if (Has("notes")) Set("Notes", Plain(input.Notes), Cell("notes"), () => input.Notes = Cell("notes"), x => x);
            var active = match?.Active ?? true;
            if (Has("active"))
            {
                var word = Canon(Cell("active"));
                if (word is "yes" or "y" or "true" or "1" or "on") { if (!active) changes.Add("In use no → yes"); active = true; }
                else if (word is "no" or "n" or "false" or "0" or "off") { if (active) changes.Add("In use yes → no"); active = false; }
                else Bad($"\"{Cell("active")}\" is not yes or no.");
            }

            long balance = 0;
            if (Has("balance"))
            {
                var negative = Cell("balance").TrimStart().StartsWith('-') || Cell("balance").TrimStart().StartsWith('−');
                var digits = Cell("balance").TrimStart().TrimStart('-', '−');
                if (!ItemSheetService.Number(digits, context.Decimals, out balance, out var why)) Bad($"The balance: {why}");
                else if (negative) balance = -balance;
                if (problems.Count == before)
                {
                    if (match is not null) { notes.Add($"Row {rowNo}: the balance of \"{match.Name}\" is not changed from here (the person is there already)."); balance = 0; }
                    else if (kind is not ("customer" or "client" or "supplier")) { notes.Add($"Row {rowNo}: \"{name}\" is not a customer or a supplier, so the balance is left out."); balance = 0; }
                    else if (kind == "supplier") balance = -balance;   // typed as "what you owe them"; kept as the books keep it: below nothing when the shop owes
                }
            }

            if (problems.Count == before)
            {
                try { PartyValidate(input); }
                catch (HubException ex) { Bad(ex.Message); }
            }
            if (problems.Count > before) continue;
            var action = match is null ? "add" : changes.Count > 0 ? "change" : "same";
            var detail = match is null ? "New" + (balance != 0 ? $", balance {context.Money(Math.Abs(balance))}" + (balance > 0 ? " owed to the shop" : " owed by the shop") : "") : changes.Count > 0 ? string.Join("; ", changes) : "As it is";
            plans.Add(new Plan(rowNo, name, match?.Id, input, active, balance, action, detail));
        }
        return new(plans, problems, notes, rows.Count - 1);
    }

    private void PartyValidate(PartyInput input)
    {
        if (input.Name.Trim().Length == 0) throw new HubException("name", "There is no name.");
        if (input.Name.Length > 120) throw new HubException("name", "That name is too long.");
    }

    // ---- writing ----------------------------------------------------------------------------------------------------------------------------

    public PartySheetResult Import(PartySheetCheck check, long? userId)
    {
        access.Require(Perm.Parties);
        var planned = PlanFrom(check.Text);
        if (Fingerprint(planned) != check.Fingerprint)
            throw new HubException("sheet-changed", "The shop's people changed since you checked the file, so nothing was written. Please check the file again and read the new list.");
        if (planned.Problems.Count > 0)
            throw new HubException("sheet-problems", "The file has rows that cannot be used, so nothing was written. Fix them in the spreadsheet and check it again.");
        if (planned.Plans.All(p => p.Action == "same"))
            throw new HubException("sheet-nothing", "Everybody in the file is in the shop already, exactly as they are. There is nothing to write.");

        var stamp = clock.UtcNow.UtcDateTime.ToString("yyyyMMdd'T'HHmmss'Z'", CultureInfo.InvariantCulture);
        var backup = db.BackupNow("before-people-sheet-" + stamp);
        var result = db.InTransaction((c, t) =>
        {
            int added = 0, changed = 0, balances = 0, customers = 0, suppliers = 0;
            foreach (var plan in planned.Plans.Where(p => p.Action != "same"))
            {
                try
                {
                    long id;
                    if (plan.ExistingId is { } existingId)
                    {
                        HubDb.Exec(c,
                            "UPDATE parties SET name=$name, phone=$phone, email=$email, address=$address, tax_id=$tax, region=$region, price_level=$pl, credit_limit_minor=$cl, terms_days=$td, notes=$notes, active=$a WHERE id=$id", t,
                            ("$id", existingId), ("$name", plan.Input.Name.Trim()), ("$phone", Blank(plan.Input.Phone)), ("$email", Blank(plan.Input.Email)), ("$address", Blank(plan.Input.Address)), ("$tax", Blank(plan.Input.TaxId)),
                            ("$region", Blank(plan.Input.Region)), ("$pl", plan.Input.PriceLevel), ("$cl", plan.Input.CreditLimitMinor), ("$td", plan.Input.TermsDays), ("$notes", Blank(plan.Input.Notes)), ("$a", plan.Active ? 1 : 0));
                        id = existingId; changed++;
                    }
                    else
                    {
                        id = parties.Create(c, t, plan.Input); added++;
                        if (!plan.Active) HubDb.Exec(c, "UPDATE parties SET active = 0 WHERE id = $id", t, ("$id", id));
                        if (plan.Input.Kind == "supplier") suppliers++; else customers++;
                    }
                    if (plan.ExistingId is null && plan.BalanceMinor != 0)
                    {
                        HubDb.Exec(c, "INSERT INTO party_opening_balances(party_id, balance_minor, as_of, run_id) VALUES ($p, $b, $at, $r)", t,
                            ("$p", id), ("$b", plan.BalanceMinor), ("$at", Iso.Text(clock.UtcNow)), ("$r", 0));
                        balances++;
                    }
                }
                catch (HubException ex) { throw new HubException(ex.Code, $"Row {plan.Row} (\"{plan.Name}\") could not be written, so nothing was written. {ex.Message}"); }
            }
            var runId = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MAX(id), 0) + 1 FROM import_runs WHERE tenant_id = 'local' AND site_id = 'main'", t), CultureInfo.InvariantCulture);
            HubDb.Exec(c, "UPDATE party_opening_balances SET run_id = $r WHERE run_id = 0", t, ("$r", runId));
            var file = check.FileName.Length > 80 ? check.FileName[..80] : check.FileName;
            HubDb.Exec(c,
                "INSERT INTO import_runs(id, at, user_id, source_kind, source_id, items_added, customers_added, suppliers_added, stock_moves_added, balances_added, backup_path, report) VALUES ($id, $at, $u, 'spreadsheet', $s, 0, $cu, $su, 0, $b, $bk, $rep)", t,
                ("$id", runId), ("$at", Iso.Text(clock.UtcNow)), ("$u", userId), ("$s", file), ("$cu", customers), ("$su", suppliers), ("$b", balances), ("$bk", backup),
                ("$rep", JsonSerializer.Serialize(new Dictionary<string, object?> { ["rows"] = planned.Rows, ["added"] = added, ["changed"] = changed, ["balances"] = balances, ["notes"] = planned.Notes })));
            audit.Log(c, t, userId, "import", "import", runId, $"From the spreadsheet {file}: {added} person(s) added, {changed} changed, {balances} opening balance(s). A copy of the shop's data was made first: {Path.GetFileName(backup)}.");
            return new PartySheetResult(runId, added, changed, balances, backup);
        });
        if (result.Balances > 0) books.CatchUp();   // the opening balances go into the books
        return result;
    }

    private static string? Blank(string? text) => string.IsNullOrWhiteSpace(text) ? null : text.Trim();
}
