using NextGenOS.Hub.Reports;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Web;

/// <summary>Reports as files for a spreadsheet: /export/{report}.csv?from=2026-10-01&amp;to=2026-10-31. Only for people allowed to see reports.</summary>
public static class ExportEndpoint
{
    public static IResult Handle(string report, string? from, string? to, HubApp app)
    {
        var shop = app.Shop.Current;
        var today = shop.Time.LocalDate(app.Clock.UtcNow);
        var start = DateOnly.TryParse(from, out var f) ? f : today.AddDays(-29);
        var end = DateOnly.TryParse(to, out var t) ? t : today;
        if (end < start || end.DayNumber - start.DayNumber > 800) return Results.BadRequest("Choose a period of up to two years.");
        string M(long minor) => shop.Text(minor);
        string text;
        switch (report)
        {
            case "sales":
                text = Csv.Build(new[] { "Date", "Documents", "Net", "Tax", "Total", "Refunds", "Tips" },
                    app.Reports.DailySales(start, end).Select(d => (IReadOnlyList<object?>)new object?[] { d.Day.ToString("yyyy-MM-dd"), d.Documents, M(d.NetMinor), M(d.TaxMinor), M(d.TotalMinor), M(d.RefundsMinor), M(d.TipsMinor) }));
                break;
            case "items":
                text = Csv.Build(new[] { "Item", "Quantity", "Revenue" },
                    app.Reports.TopItems(start, end, 1000).Select(i => (IReadOnlyList<object?>)new object?[] { i.Name, ShopContext.Qty(i.QtyMilli), M(i.RevenueMinor) }));
                break;
            case "tax":
                text = Csv.Build(new[] { "Code", "Rate", "Taxable", "Tax parts", "Tax" },
                    app.Reports.TaxSummary(start, end).Select(r => (IReadOnlyList<object?>)new object?[] { r.Code, r.Percent, M(r.TaxableMinor), string.Join("; ", r.Components.Select(c => c.Name + " " + M(c.AmountMinor))), M(r.TaxMinor) }));
                break;
            case "payments":
                text = Csv.Build(new[] { "Method", "Amount" }, app.Reports.Payments(start, end).Select(p => (IReadOnlyList<object?>)new object?[] { p.Method, M(p.AmountMinor) }));
                break;
            case "owed":
                text = Csv.Build(new[] { "Name", "Not yet due", "1-30 days late", "31-60", "61-90", "Over 90", "Total" },
                    app.Reports.Outstanding().Select(a => (IReadOnlyList<object?>)new object?[] { a.Name, M(a.CurrentMinor), M(a.Days30Minor), M(a.Days60Minor), M(a.Days90Minor), M(a.Over90Minor), M(a.TotalMinor) }));
                break;
            case "customers":
                text = Csv.Build(new[] { "Name", "Documents", "Total" },
                    app.Reports.TopCustomers(start, end, 1000).Select(c => (IReadOnlyList<object?>)new object?[] { c.Name, c.Documents, M(c.TotalMinor) }));
                break;
            case "stock":
                text = Csv.Build(new[] { "Item", "On hand", "Average cost each", "Value" },
                    app.Reports.StockValues().Select(s => (IReadOnlyList<object?>)new object?[] { s.Name, ShopContext.Qty(s.OnHandMilli), M(s.CostMinor), M(s.ValueMinor) }));
                break;
            case "register-sales" or "register-credits" or "register-purchases":
            {
                var kind = report["register-".Length..];
                text = Csv.Build(new[] { "Number", "Date", "Name", shop.Country.Tax.BusinessId?.Label ?? "Tax number", shop.Country.Tax.Regions?.Label ?? "Place", "Before tax", "Tax parts", "Extra tax", "Tax", "Other", "Total" },
                    app.TaxRegisters.Register(kind, start, end).Select(r => (IReadOnlyList<object?>)new object?[]
                    {
                        r.Number, r.Day.ToString("yyyy-MM-dd"), r.PartyName, r.PartyTaxId, r.PartyRegion, M(r.TaxableMinor), string.Join("; ", r.Parts.Select(p => p.Name + " " + M(p.AmountMinor))), M(r.ExtraTaxMinor), M(r.TaxMinor), M(r.OtherMinor), M(r.TotalMinor),
                    }));
                break;
            }
            case var list when list.StartsWith("list-", StringComparison.Ordinal):
            {
                var found = app.TaxRegisters.ReturnLists(start, end).FirstOrDefault(l => l.Id == list["list-".Length..]);
                if (found is null) return Results.NotFound();
                text = Csv.Build(new[] { "Number", "Date", "Name", shop.Country.Tax.BusinessId?.Label ?? "Tax number", shop.Country.Tax.Regions?.Label ?? "Place", "Before tax", "Tax parts", "Extra tax", "Tax", "Other", "Total" },
                    found.Rows.Select(r => (IReadOnlyList<object?>)new object?[]
                    {
                        r.Number, r.Day.ToString("yyyy-MM-dd"), r.PartyName, r.PartyTaxId, r.PartyRegion, M(r.TaxableMinor), string.Join("; ", r.Parts.Select(p => p.Name + " " + M(p.AmountMinor))), M(r.ExtraTaxMinor), M(r.TaxMinor), M(r.OtherMinor), M(r.TotalMinor),
                    }));
                break;
            }
            case "summary":
            {
                var sum = app.TaxRegisters.SupplySummary(start, end);
                text = Csv.Build(new[] { "Side", "Block", "Lines", "Before tax", "Tax parts", "Extra tax", "Tax" },
                    sum.Blocks.Select(b => (IReadOnlyList<object?>)new object?[] { b.Side, b.Label, b.Lines, M(b.ValueMinor), string.Join("; ", b.Parts.Select(p => p.Name + " " + M(p.AmountMinor))), M(b.ExtraTaxMinor), M(b.TaxMinor) }));
                break;
            }
            case "codes":
            {
                var codes = app.TaxRegisters.CodesSold(start, end);
                var label = shop.Country.Tax.ItemCode?.Label ?? "Code";
                text = Csv.Build(new[] { label, "Rate", "Quantity", "Before tax", "Tax parts", "Extra tax", "Tax" },
                    codes.Rows.Select(r => (IReadOnlyList<object?>)new object?[] { r.Code, r.TaxLabel, ShopContext.Qty(r.QtyMilli), M(r.TaxableMinor), string.Join("; ", r.Parts.Select(p => p.Name + " " + M(p.AmountMinor))), M(r.ExtraTaxMinor), M(r.TaxMinor) }));
                break;
            }
            default:
                return Results.NotFound();
        }

        // A byte order mark so Excel reads accents and non-Latin names properly.
        var bytes = new System.Text.UTF8Encoding(true).GetPreamble().Concat(System.Text.Encoding.UTF8.GetBytes(text)).ToArray();
        return Results.File(bytes, "text/csv; charset=utf-8", $"{report}-{start:yyyyMMdd}-{end:yyyyMMdd}.csv");
    }
}
