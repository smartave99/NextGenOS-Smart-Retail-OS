using NextGenOS.Devices.Printing;
using NextGenOS.Devices.Transport;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Documents;
using NextGenOS.Hub.Restaurant;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Printing;

/// <summary>Printing for the shop: bills to the receipt printer, tickets to the kitchen, labels to the label printer. A printer that is off never loses a sale: the message says what to check.</summary>
public sealed class HubPrinting(PrinterStore printers, PrintService service, DocumentService documents, CatalogService catalog, ShopContextProvider shop, AuditService audit, NextGenOS.Hub.Offers.OffersService offers, NextGenOS.Hub.Loyalty.LoyaltyService loyalty)
{
    public PrinterStore Printers => printers;

    private PrinterProfile Choose(string role, string? id, string? station = null)
    {
        var profile = id is not null ? printers.Get(id) : printers.For(role, station);
        return profile ?? throw new HubException("no-printer", role switch
        {
            PrinterRole.Label => "No label printer is set up. Add one in Settings, under Printers.",
            PrinterRole.Kitchen => "No kitchen printer is set up. Add one in Settings, under Printers.",
            _ => "No receipt printer is set up. Add one in Settings, under Printers.",
        });
    }

    private static HubException Failed(PrinterException ex) => new("printer-failed", ex.Message);

    public async Task PrintBillAsync(long documentId, string? printerId = null, long? userId = null, CancellationToken ct = default)
    {
        var view = documents.Get(documentId) ?? throw new HubException("not-found", "That bill was not found.");
        var printer = Choose(PrinterRole.Receipt, printerId);
        var points = view.Party is { } who && loyalty.Enabled ? loyalty.ForDocument(documentId, who.Id) : null;
        try { await service.PrintReceiptAsync(printer, ReceiptLayout.Bill(view, shop.Current, printer.Columns, offers.ForDocument(documentId), points), ct); }
        catch (PrinterException ex) { throw Failed(ex); }
        audit.Log(userId, "bill-printed", "document", documentId, printer.Name);
    }

    /// <summary>The receipt printer set to print every bill by itself, if there is one.</summary>
    public PrinterProfile? AutoPrinter() => printers.List().FirstOrDefault(p => p.Role == PrinterRole.Receipt && p.AutoPrint);

    public async Task OpenDrawerAsync(string? printerId = null, long? userId = null, CancellationToken ct = default)
    {
        var printer = Choose(PrinterRole.Receipt, printerId);
        try { await service.OpenDrawerAsync(printer, ct); }
        catch (PrinterException ex) { throw Failed(ex); }
        audit.Log(userId, "drawer-opened", "printer", null, printer.Name);
    }

    /// <summary>Prints the tickets for a kitchen or bar, each on the printer of its station. Returns the ones that could not be printed (with why), so the order still goes ahead.</summary>
    public async Task<IReadOnlyList<string>> PrintTicketsAsync(IEnumerable<KitchenTicket> tickets, CancellationToken ct = default)
    {
        var problems = new List<string>();
        foreach (var ticket in tickets)
        {
            var printer = printers.For(PrinterRole.Kitchen, ticket.Station);
            if (printer is null) continue;                                   // no kitchen printer: the kitchen screen is enough
            try { await service.PrintReceiptAsync(printer, ReceiptLayout.Ticket(ticket, shop.Current, printer.Columns), ct); }
            catch (PrinterException ex) { problems.Add($"{ticket.Station}: {ex.Message}"); }
        }
        return problems;
    }

    public async Task PrintLabelsAsync(long itemId, int copies, string? printerId = null, long? userId = null, CancellationToken ct = default)
    {
        var item = catalog.Get(itemId) ?? throw new HubException("item-not-found", "That item was not found.");
        if (copies is < 1 or > 500) throw new HubException("copies", "Print between 1 and 500 labels at a time.");
        var printer = Choose(PrinterRole.Label, printerId);
        try { await service.PrintLabelAsync(printer, ReceiptLayout.Label(item, shop.Current, printer.LabelWidthMm, printer.LabelHeightMm, printer.Dpi, copies), ct); }
        catch (PrinterException ex) { throw Failed(ex); }
        catch (NotSupportedException ex) { throw new HubException("printer-failed", ex.Message); }
        audit.Log(userId, "labels-printed", "item", itemId, $"{copies} on {printer.Name}");
    }

    public async Task TestAsync(string printerId, CancellationToken ct = default)
    {
        var printer = printers.Get(printerId) ?? throw new HubException("no-printer", "That printer was not found.");
        try { await service.PrintTestAsync(printer, shop.Current.Settings.Name, ct); }
        catch (PrinterException ex) { throw Failed(ex); }
    }

    /// <summary>A number for an item that has no barcode: an in-store EAN-13 (starting with 2) not used by any other item.</summary>
    public string NewBarcode()
    {
        var start = Convert.ToInt64(catalog.Search(null, null, null, 100_000, true).Count) + 1;
        for (var n = start; n < start + 100_000; n++)
        {
            var candidate = Devices.Barcodes.Barcode.InStore(n);
            if (catalog.FindByCode(candidate) is null) return candidate;
        }
        throw new HubException("barcode", "No free barcode number was found.");
    }
}
