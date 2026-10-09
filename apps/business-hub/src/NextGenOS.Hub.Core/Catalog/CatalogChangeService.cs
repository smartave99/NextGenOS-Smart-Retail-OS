using System.Text.Json;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Catalog;

/// <summary>One item's price, as it is now and as the change would make it.</summary>
public sealed record PriceChange(long ItemId, string Name, string? Category, string Field, long? OldMinor, long NewMinor);

/// <summary>An item a change did not touch, and why (in words for a person).</summary>
public sealed record LeftAlone(long ItemId, string Name, string Why);

/// <summary>What a price change would do, before anything is saved: the items it would change and the ones it leaves, with the sentence the record will carry.</summary>
public sealed record PricePreview(string Template, IReadOnlyList<PriceChange> Changes, IReadOnlyList<LeftAlone> Left)
{
    /// <summary>The sentence the record will carry ("The price of 12 items raised by 5 percent").</summary>
    public string Summary => Sentence(Template, Changes.Count);

    internal static string Sentence(string template, int count) => template.Replace("{n} {items}", count + " " + (count == 1 ? "item" : "items"), StringComparison.Ordinal);
}

/// <summary>One item's tax code, as it is now and as the change would make it.</summary>
public sealed record TaxChange(long ItemId, string Name, string? Category, string OldCode, string NewCode);

public sealed record TaxPreview(string Template, IReadOnlyList<TaxChange> Changes)
{
    public string Summary => PricePreview.Sentence(Template, Changes.Count);
}

/// <summary>What a saved change did: its number in the record (0 when nothing needed changing), how many items it changed, and the ones it left.</summary>
public sealed record ChangeResult(long ChangeId, int Changed, IReadOnlyList<LeftAlone> Left);

/// <summary>One line of the record of changes.</summary>
public sealed record ChangeEntry(long Id, DateTimeOffset At, string? Who, string Kind, string Summary, int ItemCount, bool Undone, long? Undoes);

/// <summary>One item's value before and after, in a change of the record. The values are shown the way a person reads them.</summary>
public sealed record ChangeLine(long ItemId, string Name, string Field, string Before, string After);

/// <summary>
/// Changing many items at once, and taking it back (docs/old-programs/02-masters-accounting-reports.md, A2.6: bulk price change, bulk GST change, items on and off sale). Ported with the
/// older program's own worked examples (BP1 to BP5, GB1 to GB4) as tests, and with what it lacked: every change is kept in a record that says who, when and what each item was before,
/// the preview shows exactly what would change before anything is saved, and a change can be taken back while the items are still as it left them.
/// <para>
/// Old bills never change: a bill keeps the price and tax it was made with. Only items change here. Every change is checked and written in one step: all of it or none of it.
/// </para>
/// </summary>
public sealed class CatalogChangeService(HubDb db, ShopContextProvider shop, IClock clock, AuditService audit, Access access)
{
    private const string PriceColumn = "price_minor";
    private const string TradeColumn = "trade_price_minor";

    // ---- prices ------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// What raising or lowering the price of the chosen items would do. <paramref name="rule"/> is <c>percent</c> (<paramref name="value"/> "5" raises by 5 percent, "-10" lowers by 10) or
    /// <c>amount</c> (money: "10" adds 10, "-2.50" takes off 2.50). The result can be rounded to the nearest <paramref name="roundStepMinor"/> (5 in a currency with 2 decimals rounds to 0.05).
    /// <paramref name="field"/> is <c>price</c> or <c>trade</c> (the trade price; an item with no trade price is left alone). Nothing is saved.
    /// </summary>
    public PricePreview PreviewPrices(IReadOnlyCollection<long> itemIds, string field, string rule, string value, long roundStepMinor = 1)
    {
        access.Require(Perm.Catalog);
        var column = ColumnOf(field);
        if (roundStepMinor < 1) throw new HubException("round", "The rounding step must be at least 1.");
        var context = shop.Current;
        decimal pct = 0;
        long amount = 0;
        string what;
        switch (rule)
        {
            case "percent":
                var milli = PercentMilli(value);
                pct = milli;
                what = milli > 0 ? $"raised by {Trimmed(milli)} percent" : $"lowered by {Trimmed(-milli)} percent";
                break;
            case "amount":
                amount = SignedMinor(context, value);
                what = amount > 0 ? $"raised by {context.Money(amount)}" : $"lowered by {context.Money(-amount)}";
                break;
            default:
                throw new HubException("rule", "Please choose how to change the price: by a percent or by an amount.");
        }

        var changes = new List<PriceChange>();
        var left = new List<LeftAlone>();
        foreach (var item in LoadForPrices(itemIds, column))
        {
            if (item.Old is null) { left.Add(new(item.Id, item.Name, "It has no " + FieldWords(field) + " to change.")); continue; }
            var old = item.Old.Value;
            decimal next = rule == "percent" ? old + Math.Round(old * pct / 100_000m, 0, MidpointRounding.AwayFromZero) : old + amount;
            if (roundStepMinor > 1) next = Math.Round(next / roundStepMinor, 0, MidpointRounding.AwayFromZero) * roundStepMinor;
            if (next < 0) { left.Add(new(item.Id, item.Name, "The " + FieldWords(field) + " would be below nothing, so it is left as it is.")); continue; }
            if (next > 1_000_000_000_000m) { left.Add(new(item.Id, item.Name, "The new " + FieldWords(field) + " would be too large, so it is left as it is.")); continue; }
            var rounded = (long)next;
            if (rounded == old) { left.Add(new(item.Id, item.Name, "The " + FieldWords(field) + " stays the same.")); continue; }
            changes.Add(new(item.Id, item.Name, item.Category, field, old, rounded));
        }
        var step = roundStepMinor > 1 ? $", rounded to the nearest {context.Money(roundStepMinor)}" : "";
        return new PricePreview($"The {FieldWords(field)} of {{n}} {{items}} {what}{step}", changes, left);
    }

    /// <summary>
    /// What setting each chosen item's price to the one typed for it would do (the older program's way: type the new price beside each item). A blank or nothing typed leaves the item
    /// alone, and so does a price equal to the one it has. Nothing is saved.
    /// </summary>
    public PricePreview PreviewSetPrices(IReadOnlyDictionary<long, string> typed, string field)
    {
        access.Require(Perm.Catalog);
        var column = ColumnOf(field);
        var context = shop.Current;
        var wanted = new Dictionary<long, long>();
        foreach (var (id, text) in typed)
        {
            if (string.IsNullOrWhiteSpace(text)) continue;
            long minor;
            try { minor = context.Minor(text.Trim().Replace(',', '.')); }
            catch (Exception ex) when (ex is FormatException or OverflowException)
            {
                throw new HubException("amount", $"\"{text.Trim()}\" is not a price. Please type a number, like 250 or 99.50.");
            }
            if (minor > 0) wanted[id] = minor;   // nothing, or 0, leaves the item as it is (the older program's rule)
        }
        if (wanted.Count == 0) throw new HubException("nothing-typed", "Please type a new price beside at least one item.");

        var changes = new List<PriceChange>();
        var left = new List<LeftAlone>();
        foreach (var item in LoadForPrices(wanted.Keys.ToList(), column))
        {
            var next = wanted[item.Id];   // (an item with no trade price can be given one)
            if (item.Old == next) { left.Add(new(item.Id, item.Name, "The " + FieldWords(field) + " stays the same.")); continue; }
            changes.Add(new(item.Id, item.Name, item.Category, field, item.Old, next));
        }
        return new PricePreview($"The {FieldWords(field)} of {{n}} {{items}} set to the price typed beside each", changes, left);
    }

    /// <summary>Saves what <see cref="PreviewPrices"/> or <see cref="PreviewSetPrices"/> showed. An item changed by someone else since the preview is left alone and reported.</summary>
    public ChangeResult ApplyPrices(PricePreview preview)
    {
        var actor = access.Require(Perm.Catalog);
        if (preview.Changes.Count == 0) return new ChangeResult(0, 0, preview.Left);
        return db.InTransaction((c, t) =>
        {
            var left = new List<LeftAlone>(preview.Left);
            var done = new List<(PriceChange Change, string Column)>();
            foreach (var change in preview.Changes)
            {
                var column = ColumnOf(change.Field);
                var found = HubDb.Query(c, $"SELECT {column} AS v FROM items WHERE id = $id", r => r.IntOrNull("v"), t, ("$id", change.ItemId));
                if (found.Count == 0) { left.Add(new(change.ItemId, change.Name, "It is no longer in the list.")); continue; }
                var current = found[0];   // null: an item with no trade price yet
                if (current != change.OldMinor) { left.Add(new(change.ItemId, change.Name, "It was changed by someone else after you looked, so it is left as it is.")); continue; }
                HubDb.Exec(c, $"UPDATE items SET {column} = $v WHERE id = $id", t, ("$v", change.NewMinor), ("$id", change.ItemId));
                done.Add((change, column));
            }
            if (done.Count == 0) return new ChangeResult(0, 0, left);
            var summary = PricePreview.Sentence(preview.Template, done.Count);
            var id = NewChange(c, t, "price", summary, actor.UserId, null);
            foreach (var (change, column) in done) LogLine(c, t, id, change.ItemId, column, change.OldMinor?.ToString() ?? "", change.NewMinor.ToString());
            audit.Log(c, t, actor.UserId, "catalog.prices", "catalog_change", id, summary);
            return new ChangeResult(id, done.Count, left);
        });
    }

    // ---- tax -----------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Which items would move from one tax rate to another (the older program's bulk GST change, GB1 to GB4): only items that have exactly the old rate change, and an item that already has
    /// the new rate or any other is not touched and not counted. The choice can be narrowed to some items, to a category, or to one item code (the code the country's tax uses for the goods, if any).
    /// Nothing is saved.
    /// </summary>
    public TaxPreview PreviewTax(string fromCode, string toCode, IReadOnlyCollection<long>? itemIds = null, string? category = null, string? itemCode = null)
    {
        access.Require(Perm.Catalog);
        if (string.IsNullOrWhiteSpace(fromCode) || string.IsNullOrWhiteSpace(toCode)) throw new HubException("tax", "Please choose the tax to change from and the tax to change to.");
        var context = shop.Current;
        string from, to;
        try { from = context.TaxCode(fromCode.Trim()); to = context.TaxCode(toCode.Trim()); }
        catch (ArgumentException ex) { throw new HubException("tax", ex.Message); }
        if (from == to) throw new HubException("tax", "Those are the same tax. Please choose two different ones.");

        var rows = db.Query(
            "SELECT id, name, category, attrs FROM items WHERE tax_code = $from AND ($cat IS NULL OR category = $cat) AND ($ids IS NULL OR id IN (SELECT value FROM json_each($ids))) ORDER BY name COLLATE NOCASE, id",
            r => (Id: r.Int("id"), Name: r.Text("name"), Category: r.TextOrNull("category"), Attrs: r.Text("attrs")),
            ("$from", from), ("$cat", string.IsNullOrWhiteSpace(category) ? null : category.Trim()), ("$ids", itemIds is null ? null : JsonSerializer.Serialize(itemIds)));
        var wantedCode = string.IsNullOrWhiteSpace(itemCode) ? null : itemCode.Trim();
        var changes = new List<TaxChange>();
        foreach (var row in rows)
        {
            if (wantedCode is not null)
            {
                var attrs = JsonSerializer.Deserialize<Dictionary<string, string>>(row.Attrs) ?? new Dictionary<string, string>();
                if (!attrs.TryGetValue(ItemAttrs.Code, out var have) || !string.Equals(have.Trim(), wantedCode, StringComparison.OrdinalIgnoreCase)) continue;
            }
            changes.Add(new(row.Id, row.Name, row.Category, from, to));
        }
        var label = (string code) => context.Country.Tax.Rates.FirstOrDefault(x => x.Code == code)?.Label ?? code;
        return new TaxPreview($"The tax of {{n}} {{items}} changed from {label(from)} to {label(to)}", changes);
    }

    /// <summary>Saves what <see cref="PreviewTax"/> showed. An item whose tax is no longer the old one is left alone.</summary>
    public ChangeResult ApplyTax(TaxPreview preview)
    {
        var actor = access.Require(Perm.Catalog);
        if (preview.Changes.Count == 0) return new ChangeResult(0, 0, Array.Empty<LeftAlone>());
        return db.InTransaction((c, t) =>
        {
            var left = new List<LeftAlone>();
            var done = new List<TaxChange>();
            foreach (var change in preview.Changes)
            {
                var now = HubDb.Scalar(c, "SELECT tax_code FROM items WHERE id = $id", t, ("$id", change.ItemId)) as string;
                if (now is null) { left.Add(new(change.ItemId, change.Name, "It is no longer in the list.")); continue; }
                if (now != change.OldCode) { left.Add(new(change.ItemId, change.Name, "Its tax was changed by someone else after you looked, so it is left as it is.")); continue; }
                HubDb.Exec(c, "UPDATE items SET tax_code = $new WHERE id = $id", t, ("$new", change.NewCode), ("$id", change.ItemId));
                done.Add(change);
            }
            if (done.Count == 0) return new ChangeResult(0, 0, left);
            var summary = PricePreview.Sentence(preview.Template, done.Count);
            var id = NewChange(c, t, "tax", summary, actor.UserId, null);
            foreach (var change in done) LogLine(c, t, id, change.ItemId, "tax_code", change.OldCode, change.NewCode);
            audit.Log(c, t, actor.UserId, "catalog.tax", "catalog_change", id, summary);
            return new ChangeResult(id, done.Count, left);
        });
    }

    // ---- on and off sale -----------------------------------------------------------------------------------------------------------------

    /// <summary>Takes the chosen items off sale (or puts them back). An item already as asked is not counted.</summary>
    public ChangeResult SetOnSale(IReadOnlyCollection<long> itemIds, bool onSale)
    {
        var actor = access.Require(Perm.Catalog);
        if (itemIds.Count == 0) throw new HubException("nothing-chosen", "Please choose the items to change.");
        return db.InTransaction((c, t) =>
        {
            var rows = HubDb.Query(c, "SELECT id, name, active FROM items WHERE id IN (SELECT value FROM json_each($ids)) ORDER BY name COLLATE NOCASE, id",
                r => (Id: r.Int("id"), Name: r.Text("name"), Active: r.Flag("active")), t, ("$ids", JsonSerializer.Serialize(itemIds)));
            var todo = rows.Where(x => x.Active != onSale).ToList();
            var left = rows.Where(x => x.Active == onSale).Select(x => new LeftAlone(x.Id, x.Name, onSale ? "It is on sale already." : "It is off sale already.")).ToList();
            if (todo.Count == 0) return new ChangeResult(0, 0, left);
            var summary = $"{todo.Count} {Items(todo.Count)} {(onSale ? "put back on sale" : "taken off sale")}";
            var id = NewChange(c, t, "sale", summary, actor.UserId, null);
            foreach (var item in todo)
            {
                HubDb.Exec(c, "UPDATE items SET active = $a WHERE id = $id", t, ("$a", onSale ? 1 : 0), ("$id", item.Id));
                LogLine(c, t, id, item.Id, "active", item.Active ? "1" : "0", onSale ? "1" : "0");
            }
            audit.Log(c, t, actor.UserId, "catalog.sale", "catalog_change", id, summary);
            return new ChangeResult(id, todo.Count, left);
        });
    }

    // ---- the record, and taking a change back --------------------------------------------------------------------------------------------

    /// <summary>The latest changes, newest first.</summary>
    public IReadOnlyList<ChangeEntry> Recent(int limit = 30)
    {
        access.Require(Perm.Catalog);
        return db.Query(
            "SELECT c.id, c.at, u.display_name AS who, c.kind, c.summary, c.undone_by, c.undoes, (SELECT COUNT(*) FROM catalog_change_items i WHERE i.change_id = c.id) AS n " +
            "FROM catalog_changes c LEFT JOIN users u ON u.id = c.user_id ORDER BY c.id DESC LIMIT $n",
            r => new ChangeEntry(r.Int("id"), r.Time("at"), r.TextOrNull("who"), r.Text("kind"), r.Text("summary"), (int)r.Int("n"), r.IntOrNull("undone_by") is not null, r.IntOrNull("undoes")), ("$n", Math.Clamp(limit, 1, 500)));
    }

    /// <summary>What a change did, item by item, as a person reads it.</summary>
    public IReadOnlyList<ChangeLine> Lines(long changeId)
    {
        access.Require(Perm.Catalog);
        var context = shop.Current;
        return db.Query("SELECT i.item_id, it.name, i.field, i.old_value, i.new_value FROM catalog_change_items i JOIN items it ON it.id = i.item_id WHERE i.change_id = $c ORDER BY it.name COLLATE NOCASE, i.id",
            r => new ChangeLine(r.Int("item_id"), r.Text("name"), FieldLabel(r.Text("field")), Shown(context, r.Text("field"), r.Text("old_value")), Shown(context, r.Text("field"), r.Text("new_value"))), ("$c", changeId));
    }

    /// <summary>
    /// Takes a change back: every item that is still exactly as the change left it goes back to what it was; an item that has been changed again since is left as it is and reported. A change
    /// can be taken back once. Nothing is lost: the undo is itself in the record.
    /// </summary>
    public ChangeResult Undo(long changeId)
    {
        var actor = access.Require(Perm.Catalog);
        return db.InTransaction((c, t) =>
        {
            var change = HubDb.Query(c, "SELECT kind, summary, undone_by FROM catalog_changes WHERE id = $id", r => (Kind: r.Text("kind"), Summary: r.Text("summary"), Undone: r.IntOrNull("undone_by") is not null), t, ("$id", changeId)).FirstOrDefault();
            if (change == default) throw new HubException("not-found", "That change was not found.");
            if (change.Kind == "undo") throw new HubException("undo-undo", "A change that took something back cannot be taken back. Make the change again instead.");
            if (change.Undone) throw new HubException("undone", "That change has been taken back already.");
            var lines = HubDb.Query(c, "SELECT i.item_id, it.name, i.field, i.old_value, i.new_value FROM catalog_change_items i JOIN items it ON it.id = i.item_id WHERE i.change_id = $c ORDER BY it.name COLLATE NOCASE, i.id",
                r => (Item: r.Int("item_id"), Name: r.Text("name"), Field: r.Text("field"), Old: r.Text("old_value"), New: r.Text("new_value")), t, ("$c", changeId));
            var left = new List<LeftAlone>();
            var restore = new List<(long Item, string Field, string Now, string Back)>();
            foreach (var line in lines)
            {
                var current = HubDb.Scalar(c, $"SELECT {line.Field} FROM items WHERE id = $id", t, ("$id", line.Item));
                var text = current is null or DBNull ? null : Convert.ToString(current, System.Globalization.CultureInfo.InvariantCulture);
                if (text != line.New) { left.Add(new(line.Item, line.Name, "It was changed again after this change, so it is left as it is.")); continue; }
                restore.Add((line.Item, line.Field, line.New, line.Old));
            }
            if (restore.Count == 0) throw new HubException("undo-impossible", "Every item in that change has been changed again since, so there is nothing left to take back.");
            var id = NewChange(c, t, "undo", "Taken back: " + change.Summary, actor.UserId, changeId);
            foreach (var r in restore)
            {
                if (r.Field is PriceColumn or TradeColumn or "active")
                    HubDb.Exec(c, $"UPDATE items SET {r.Field} = $v WHERE id = $id", t, ("$v", r.Back.Length == 0 ? null : long.Parse(r.Back, System.Globalization.CultureInfo.InvariantCulture)), ("$id", r.Item));
                else HubDb.Exec(c, "UPDATE items SET tax_code = $v WHERE id = $id", t, ("$v", r.Back), ("$id", r.Item));
                LogLine(c, t, id, r.Item, r.Field, r.Now, r.Back);
            }
            HubDb.Exec(c, "UPDATE catalog_changes SET undone_by = $u WHERE id = $id", t, ("$u", id), ("$id", changeId));
            audit.Log(c, t, actor.UserId, "catalog.undo", "catalog_change", changeId, change.Summary);
            return new ChangeResult(id, restore.Count, left);
        });
    }

    // ---- helpers -------------------------------------------------------------------------------------------------------------------------

    private static string ColumnOf(string field) => field switch
    {
        "price" => PriceColumn,
        "trade" => TradeColumn,
        _ => throw new HubException("field", "Please choose which price to change."),
    };

    private static string FieldWords(string field) => field == "trade" ? "trade price" : "price";

    private static string Items(int n) => n == 1 ? "item" : "items";

    private sealed record PriceRow(long Id, string Name, string? Category, long? Old);

    private List<PriceRow> LoadForPrices(IReadOnlyCollection<long> ids, string column)
    {
        if (ids.Count == 0) throw new HubException("nothing-chosen", "Please choose the items to change.");
        return db.Query($"SELECT id, name, category, {column} AS v FROM items WHERE id IN (SELECT value FROM json_each($ids)) ORDER BY name COLLATE NOCASE, id",
            r => new PriceRow(r.Int("id"), r.Text("name"), r.TextOrNull("category"), r.IntOrNull("v")), ("$ids", JsonSerializer.Serialize(ids)));
    }

    private long NewChange(SqliteConnection c, SqliteTransaction t, string kind, string summary, long? userId, long? undoes) =>
        HubDb.Insert(c, "INSERT INTO catalog_changes(kind, summary, at, user_id, undoes) VALUES ($k, $s, $at, $u, $undoes)", t,
            ("$k", kind), ("$s", summary), ("$at", Iso.Text(clock.UtcNow)), ("$u", userId), ("$undoes", undoes));

    private static void LogLine(SqliteConnection c, SqliteTransaction t, long changeId, long itemId, string field, string before, string after) =>
        HubDb.Exec(c, "INSERT INTO catalog_change_items(change_id, item_id, field, old_value, new_value) VALUES ($c, $i, $f, $o, $n)", t,
            ("$c", changeId), ("$i", itemId), ("$f", field), ("$o", before), ("$n", after));

    /// <summary>"5", "+5", "-10", "2.5%" → thousandths of a percent. Not 0, and not below -100 percent or above 1000 percent.</summary>
    private static long PercentMilli(string text)
    {
        var (negative, digits) = Sign(text);
        digits = digits.TrimEnd('%').Trim().Replace(',', '.');
        long milli;
        try { milli = (long)NextGenOS.Tax.MoneyText.Parse(digits, 3); }
        catch (Exception ex) when (ex is FormatException or OverflowException) { throw new HubException("percent", "Please type the percent as a number, like 5 or -10 or 2.5."); }
        if (negative) milli = -milli;
        if (milli == 0) throw new HubException("percent", "A change of 0 percent changes nothing. Please type a percent like 5 or -10.");
        if (milli < -100_000) throw new HubException("percent", "A price cannot be lowered by more than 100 percent.");
        if (milli > 1_000_000) throw new HubException("percent", "A price cannot be raised by more than 1000 percent in one go.");
        return milli;
    }

    private static long SignedMinor(ShopContext context, string text)
    {
        var (negative, digits) = Sign(text);
        long minor;
        try { minor = context.Minor(digits.Replace(',', '.')); }
        catch (Exception ex) when (ex is FormatException or OverflowException) { throw new HubException("amount", "Please type the amount as a number, like 10 or -2.50."); }
        if (minor == 0) throw new HubException("amount", "A change of nothing changes nothing. Please type an amount like 10 or -2.50.");
        return negative ? -minor : minor;
    }

    private static (bool Negative, string Digits) Sign(string text)
    {
        var s = (text ?? "").Trim();
        var negative = s.StartsWith('-') || s.StartsWith('−');
        if (negative || s.StartsWith('+')) s = s[1..].Trim();
        return (negative, s);
    }

    private static string Trimmed(long milli)
    {
        var text = NextGenOS.Tax.MoneyText.Minor(milli, 3).TrimEnd('0').TrimEnd('.');
        return text.Length == 0 ? "0" : text;
    }

    private static string FieldLabel(string field) => field switch
    {
        PriceColumn => "Price", TradeColumn => "Trade price", "tax_code" => "Tax", "active" => "On sale", _ => field,
    };

    private static string Shown(ShopContext context, string field, string value)
    {
        switch (field)
        {
            case PriceColumn or TradeColumn:
                if (value.Length == 0) return "none";
                return long.TryParse(value, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out var minor) ? context.Money(minor) : value;
            case "tax_code":
                return context.Country.Tax.Rates.FirstOrDefault(x => x.Code == value)?.Label ?? value;
            case "active":
                return value == "1" ? "Yes" : "No";
            default:
                return value;
        }
    }
}
