using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Shop;
using NextGenOS.Tax;
using NewtonJson = Newtonsoft.Json.JsonConvert;

namespace NextGenOS.Hub.Reports;

public static class RegisterKinds
{
    /// <summary>Bills made out to customers (invoices and progress bills).</summary>
    public const string Sales = "sales";
    /// <summary>Credit notes given to customers.</summary>
    public const string Credits = "credits";
    /// <summary>Purchases from suppliers.</summary>
    public const string Purchases = "purchases";
}

/// <summary>One bill, credit note or purchase as a line of a register: who, when, how much before tax, each tax part, the total, and what else made up the total.</summary>
public sealed record RegisterRow(
    long DocumentId, string Number, DateOnly Day, string Kind, string? PartyName, string? PartyTaxId, string? PartyRegion, bool BetweenRegions,
    long TotalMinor, long TaxableMinor, IReadOnlyList<(string Name, long AmountMinor)> Parts, long ExtraTaxMinor, long OtherMinor, bool TaxCharged)
{
    public long TaxMinor => Parts.Sum(p => p.AmountMinor) + ExtraTaxMinor;
}

/// <summary>A list a country's tax return is made from (the country's pack names it), with the bills that fall in it.</summary>
public sealed record ReturnListResult(string Id, string Label, string Kind, IReadOnlyList<RegisterRow> Rows)
{
    public long TaxableMinor => Rows.Sum(r => r.TaxableMinor);
    public long TaxMinor => Rows.Sum(r => r.TaxMinor);
    public long TotalMinor => Rows.Sum(r => r.TotalMinor);
}

/// <summary>For one code of goods or services and one rate: what was sold in the period (credit notes taken off).</summary>
public sealed record CodeSummaryRow(string Code, string TaxCode, string TaxLabel, long QtyMilli, long TaxableMinor, IReadOnlyList<(string Name, long AmountMinor)> Parts, long ExtraTaxMinor)
{
    public long TaxMinor => Parts.Sum(p => p.AmountMinor) + ExtraTaxMinor;
}

public sealed record CodeSummary(IReadOnlyList<CodeSummaryRow> Rows, int LinesWithoutCode);

/// <summary>
/// The registers a shop's accountant asks for, read from what was stored when each bill was made (nothing is worked out again, so a register always agrees with the bills): a register of bills, of
/// credit notes and of purchases, the lists a country's tax return is made from (the pack says which bills go in which list: <c>tax.returns</c>), and a summary by the code of what was sold. Cancelled
/// bills are left out; so is every bill of a shop that is not registered for the tax (no tax was charged on it). The buyer's number is the one that was on the bill when it was made.
/// </summary>
public sealed class TaxRegisterService(HubDb db, ShopContextProvider shop)
{
    private sealed record Raw(long Id, string Type, string Number, DateTimeOffset At, string? PartyName, string? PartyTaxId, string? BuyerRegion, string? SellerRegion, bool Registered,
        long SubtotalMinor, long TotalMinor, string? Result);

    private IReadOnlyList<Raw> Read(string types, string direction, DateOnly from, DateOnly to)
    {
        var time = shop.Current.Time;
        return db.Query(
            "SELECT d.id, d.type, d.number, d.issued_at, p.name AS party_name, d.party_tax_id, d.buyer_region, d.seller_region, d.registered, d.subtotal_minor, d.total_minor, d.result " +
            "FROM documents d LEFT JOIN parties p ON p.id = d.party_id " +
            $"WHERE d.status = 'issued' AND d.direction = $dir AND d.type IN ({types}) AND d.issued_at >= $f AND d.issued_at < $t ORDER BY d.issued_at, d.id",
            r => new Raw(r.Int("id"), r.Text("type"), r.Text("number"), r.Time("issued_at"), r.TextOrNull("party_name"), r.TextOrNull("party_tax_id"), r.TextOrNull("buyer_region"), r.TextOrNull("seller_region"),
                r.Flag("registered"), r.Int("subtotal_minor"), r.Int("total_minor"), r.TextOrNull("result")),
            ("$dir", direction), ("$f", Iso.Text(time.StartOfDay(from))), ("$t", Iso.Text(time.StartOfNextDay(to))));
    }

    private static long Minor(string? text, int decimals) => string.IsNullOrEmpty(text) ? 0 : (long)MoneyText.Parse(text, decimals);

    private RegisterRow ToRow(Raw d, string kind)
    {
        var decimals = shop.Current.Decimals;
        var totals = d.Result is null ? null : NewtonJson.DeserializeObject<TaxResult>(d.Result)?.Totals;
        var parts = (totals?.Components ?? new List<Component>()).Where(c => Minor(c.Amount, decimals) != 0).Select(c => (c.Name, Minor(c.Amount, decimals))).ToList();
        var extra = Minor(totals?.Cess, decimals);
        var tax = parts.Sum(p => p.Item2) + extra;
        var between = !string.IsNullOrEmpty(d.BuyerRegion) && d.BuyerRegion != d.SellerRegion;
        return new RegisterRow(d.Id, d.Number, shop.Current.Time.LocalDate(d.At), kind, d.PartyName, string.IsNullOrWhiteSpace(d.PartyTaxId) ? null : d.PartyTaxId, d.BuyerRegion, between,
            d.TotalMinor, d.SubtotalMinor, parts, extra, d.TotalMinor - d.SubtotalMinor - tax, d.Registered);
    }

    /// <summary>The bills, credit notes or purchases issued on the days from the first to the last (both included), oldest first.</summary>
    public IReadOnlyList<RegisterRow> Register(string kind, DateOnly from, DateOnly to) => kind switch
    {
        RegisterKinds.Sales => Read("'invoice','progress-bill'", "out", from, to).Select(d => ToRow(d, "bill")).ToList(),
        RegisterKinds.Credits => Read("'credit-note'", "out", from, to).Select(d => ToRow(d, "credit")).ToList(),
        RegisterKinds.Purchases => Read("'purchase'", "in", from, to).Select(d => ToRow(d, "purchase")).ToList(),
        _ => throw new HubException("register", "That register does not exist."),
    };

    /// <summary>True when the pack names return lists and the shop charges the tax (a shop that is not registered files nothing).</summary>
    public bool HasReturnLists => shop.Current.Settings.TaxRegistered && shop.Current.Country.Tax.Returns is { Lists.Count: > 0 };

    /// <summary>
    /// The lists of the country's return for the days chosen: each bill (or credit note) is put in the first list of its kind whose rule it meets, in the order the pack gives. A bill that meets no rule is
    /// in no list. Empty when the pack names no lists.
    /// </summary>
    public IReadOnlyList<ReturnListResult> ReturnLists(DateOnly from, DateOnly to)
    {
        var rules = shop.Current.Country.Tax.Returns;
        if (!HasReturnLists) return Array.Empty<ReturnListResult>();
        var decimals = shop.Current.Decimals;
        var rows = Register(RegisterKinds.Sales, from, to).Concat(Register(RegisterKinds.Credits, from, to)).Where(r => r.TaxCharged).ToList();
        var placed = rules!.Lists.ToDictionary(l => l.Id, _ => new List<RegisterRow>());
        foreach (var row in rows)
            foreach (var list in rules.Lists.Where(l => l.Kind == row.Kind))
                if (Meets(list.When, row, decimals)) { placed[list.Id].Add(row); break; }
        return rules.Lists.Select(l => new ReturnListResult(l.Id, l.Label, l.Kind, placed[l.Id])).ToList();
    }

    /// <summary>True when the row meets everything the rule names (what the rule does not name does not matter).</summary>
    public static bool Meets(ReturnWhen? when, RegisterRow row, int decimals)
    {
        if (when is null) return true;
        if (when.PartyHasTaxId is { } hasId && hasId != (row.PartyTaxId is not null)) return false;
        if (when.BetweenRegions is { } between && between != row.BetweenRegions) return false;
        if (!string.IsNullOrEmpty(when.TotalOver) && !(row.TotalMinor > (long)MoneyText.Parse(when.TotalOver, decimals))) return false;
        return true;
    }

    /// <summary>
    /// What was sold, by the code the line carried and the rate it was taxed at, for the days chosen: the quantity, the amount before tax and each tax part (credit notes are taken off). The study's old
    /// list was one row for each day and each product; a summary for the whole period, as a return wants it, is what is made here. Lines that carry no code are counted, so that they can be put right.
    /// Empty when the country has no item code.
    /// </summary>
    public CodeSummary CodesSold(DateOnly from, DateOnly to)
    {
        var context = shop.Current;
        if (context.Country.Tax.ItemCode is null) return new CodeSummary(Array.Empty<CodeSummaryRow>(), 0);
        var decimals = context.Decimals;
        var time = context.Time;
        var groups = new Dictionary<(string Code, string Tax), (long Qty, long Taxable, Dictionary<string, long> Parts, long Extra)>();
        var withoutCode = 0;
        var documents = db.Query(
            "SELECT id, type, result FROM documents WHERE status = 'issued' AND direction = 'out' AND type IN ('invoice','progress-bill','credit-note') AND registered = 1 AND issued_at >= $f AND issued_at < $t ORDER BY issued_at, id",
            r => (Id: r.Int("id"), Type: r.Text("type"), Result: r.TextOrNull("result")), ("$f", Iso.Text(time.StartOfDay(from))), ("$t", Iso.Text(time.StartOfNextDay(to))));
        foreach (var d in documents)
        {
            if (d.Result is null) continue;
            var result = NewtonJson.DeserializeObject<TaxResult>(d.Result);
            if (result is null) continue;
            var sign = d.Type == DocTypes.CreditNote ? -1 : 1;
            var lines = db.Query("SELECT qty_milli, tax_code, item_code FROM document_lines WHERE document_id = $id ORDER BY line_no", r => (Qty: r.Int("qty_milli"), Tax: r.Text("tax_code"), Code: r.TextOrNull("item_code")), ("$id", d.Id));
            for (var i = 0; i < lines.Count && i < result.Lines.Count; i++)
            {
                var code = string.IsNullOrWhiteSpace(lines[i].Code) ? "" : lines[i].Code!.Trim();
                if (code.Length == 0) { withoutCode++; continue; }
                var key = (code, lines[i].Tax);
                groups.TryGetValue(key, out var g);
                g.Parts ??= new Dictionary<string, long>();
                g.Qty += sign * lines[i].Qty;
                g.Taxable += sign * Minor(result.Lines[i].Taxable, decimals);
                g.Extra += sign * Minor(result.Lines[i].Cess, decimals);
                foreach (var c in result.Lines[i].Components ?? new List<Component>()) g.Parts[c.Name] = g.Parts.GetValueOrDefault(c.Name) + sign * Minor(c.Amount, decimals);
                groups[key] = g;
            }
        }
        var rows = groups.OrderBy(g => g.Key.Code, StringComparer.Ordinal).ThenBy(g => g.Key.Tax, StringComparer.Ordinal).Select(g =>
        {
            var rate = context.Country.Tax.Rates.FirstOrDefault(r => r.Code == g.Key.Tax);
            return new CodeSummaryRow(g.Key.Code, g.Key.Tax, rate?.Label ?? g.Key.Tax, g.Value.Qty, g.Value.Taxable,
                g.Value.Parts.Where(p => p.Value != 0).Select(p => (p.Key, p.Value)).ToList(), g.Value.Extra);
        }).ToList();
        return new CodeSummary(rows, withoutCode);
    }
}
