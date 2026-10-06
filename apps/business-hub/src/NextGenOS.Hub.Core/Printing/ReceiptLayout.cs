using NextGenOS.Devices.Barcodes;
using NextGenOS.Devices.Printing;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Restaurant;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Printing;

/// <summary>What goes on paper: a bill or receipt, a kitchen ticket, a shelf label. The same words and figures as the screen, laid out for narrow paper.</summary>
public static class ReceiptLayout
{
    public static ReceiptDoc Bill(DocumentView view, ShopContext shop, int columns)
    {
        var doc = new ReceiptDoc { Columns = columns };
        var s = shop.Settings;
        doc.Text(s.Name, Align.Center, true, columns >= 40 ? 2 : 1);
        if (!string.IsNullOrWhiteSpace(s.Address)) doc.Text(s.Address, Align.Center);
        if (!string.IsNullOrWhiteSpace(s.Phone)) doc.Text(s.Phone, Align.Center);
        if (!string.IsNullOrWhiteSpace(s.TaxId)) doc.Text($"{shop.Country.Tax.BusinessId?.Label ?? "Tax no."}: {s.TaxId}", Align.Center);
        doc.Line();
        doc.Text(Title(view, shop), Align.Center, true);
        var when = shop.Time.ToLocal(view.Document.IssuedAt ?? view.Document.CreatedAt).ToString("d MMM yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        doc.Split("No. " + (view.Document.Number ?? "Draft"), when);
        if (view.Party is { } party)
        {
            doc.Text(party.Name + (string.IsNullOrWhiteSpace(party.TaxId) ? "" : " " + party.TaxId));
            if (!string.IsNullOrWhiteSpace(party.Address)) doc.Text(party.Address);
        }
        if (view.Document.Status == DocStatus.Void) doc.Text("VOID", Align.Center, true, 2);
        doc.Line();
        for (var i = 0; i < view.Lines.Count; i++)
        {
            var line = view.Lines[i];
            var result = view.Result?.Lines.ElementAtOrDefault(i);
            doc.Text(line.Description);
            var qty = ShopContext.Qty(line.QtyMilli).TrimEnd('0').TrimEnd('.');
            doc.Split($"  {qty} x {shop.Money(line.UnitPriceMinor)}", result is null ? "" : shop.Money(shop.Minor(result.LineTotal)));
            if (!string.IsNullOrWhiteSpace(line.Note)) doc.Text("  " + line.Note);
        }
        doc.Line();
        if (view.Result is { } r)
        {
            var t = r.Totals;
            doc.Split(shop.Settings.PricesIncludeTax ? "Before tax" : "Subtotal", shop.Money(shop.Minor(t.Taxable)));
            foreach (var c in t.Components ?? new List<NextGenOS.Tax.Component>())
                if (shop.Minor(c.Amount) != 0) doc.Split(c.Name, shop.Money(shop.Minor(c.Amount)));
            if (!string.IsNullOrEmpty(t.Cess) && shop.Minor(t.Cess) != 0) doc.Split("Cess", shop.Money(shop.Minor(t.Cess)));
            foreach (var a in r.Adjustments ?? new List<NextGenOS.Tax.AdjustmentResult>()) doc.Split(a.Label, shop.Money(shop.Minor(a.Amount)));
            if (shop.Minor(t.RoundOff) != 0) doc.Split("Rounding", shop.Money(shop.Minor(t.RoundOff)));
            doc.Split("TOTAL", shop.Money(view.Document.PayableMinor), true);
        }
        foreach (var p in view.Payments.Where(p => p.Kind == "payment"))
            doc.Split(char.ToUpperInvariant(p.Method[0]) + p.Method[1..], shop.Money(p.AmountMinor));
        if (view.Document.Meta.TryGetValue("changeGiven", out var change) && long.TryParse(change, out var given) && given > 0) doc.Split("Change", shop.Money(given));
        if (view.Document.BalanceMinor > 0) doc.Split("Balance due", shop.Money(view.Document.BalanceMinor), true);
        doc.Line();
        if (!string.IsNullOrWhiteSpace(s.ReceiptFooter)) doc.Text(s.ReceiptFooter, Align.Center);
        doc.Blank(1).Cut();
        return doc;
    }

    private static string Title(DocumentView view, ShopContext shop) => view.Document.Type switch
    {
        DocTypes.CreditNote => "Credit note",
        DocTypes.Quote => "Quote",
        DocTypes.Purchase => "Purchase order",
        DocTypes.ProgressBill => "Progress bill",
        DocTypes.Order => "Order",
        _ => shop.Settings.TaxRegistered && !string.IsNullOrWhiteSpace(shop.Country.Invoice?.Title) ? shop.Country.Invoice.Title : "Bill",
    };

    /// <summary>A ticket for the kitchen or the bar: big, plain, no prices. Notes stand out.</summary>
    public static ReceiptDoc Ticket(KitchenTicket ticket, ShopContext shop, int columns)
    {
        var doc = new ReceiptDoc { Columns = columns };
        doc.Text(ticket.Station.ToUpperInvariant(), Align.Center, true, 2);
        doc.Text(ticket.TableName is { Length: > 0 } ? "Table " + ticket.TableName : ticket.OrderNumber, Align.Center, true, 2);
        doc.Split(ticket.OrderNumber, shop.Time.ToLocal(ticket.FiredAt).ToString("HH:mm", System.Globalization.CultureInfo.InvariantCulture));
        doc.Line();
        foreach (var line in ticket.Lines)
        {
            doc.Text($"{ShopContext.Qty(line.QtyMilli).TrimEnd('0').TrimEnd('.')} x {line.Description}", Align.Left, true, 2);
            if (!string.IsNullOrWhiteSpace(line.Note)) doc.Text("  >> " + line.Note, Align.Left, true);
        }
        doc.Blank(1).Cut();
        return doc;
    }

    /// <summary>A shelf or price label for an item. Without a barcode of its own, the label carries the name and price only.</summary>
    public static LabelDoc Label(Item item, ShopContext shop, double widthMm, double heightMm, int dpi, int copies) =>
        LabelTemplates.PriceTag(item.Name, shop.Money(item.PriceMinor), item.Barcode ?? item.Sku, widthMm, heightMm, dpi, copies);
}
