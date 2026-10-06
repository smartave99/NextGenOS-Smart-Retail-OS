using NextGenOS.Devices.Transport;

namespace NextGenOS.Devices.Printing;

/// <summary>Sends receipts and labels to the shop's printers: the right language for each, the right way of reaching it, and a plain message when something is wrong.</summary>
public sealed class PrintService(Func<PrinterProfile, IPrinterTransport>? transportFor = null)
{
    private readonly Func<PrinterProfile, IPrinterTransport> _transportFor = transportFor ?? PrinterTransports.For;
    private static readonly SkiaTextRasterizer Rasterizer = new();

    public static byte[] ReceiptBytes(PrinterProfile printer, ReceiptDoc doc, bool canRasterise = true)
    {
        if (printer.Language != PrinterLanguage.EscPos) throw new PrinterException($"{printer.Name} is a label printer: receipts need a receipt printer.");
        var copy = new ReceiptDoc { Columns = printer.Columns };
        foreach (var item in doc.Items.Where(i => printer.Cut || i is not CutElement)) copy.Add(item);
        if (printer.OpenDrawer && !copy.Items.Any(i => i is DrawerElement)) copy.Add(new DrawerElement());
        return EscPos.Encode(copy, new EscPosOptions { CodePage = printer.CodePage, PaperDots = printer.PaperDots, Rasterizer = canRasterise ? Rasterizer : null });
    }

    public static byte[] LabelBytes(PrinterProfile printer, LabelDoc doc)
    {
        doc.Dpi = printer.Dpi;
        return printer.Language switch
        {
            PrinterLanguage.Zpl => Zpl.Encode(doc),
            PrinterLanguage.Tspl => Tspl.Encode(doc),
            PrinterLanguage.Epl => Epl.Encode(doc),
            PrinterLanguage.Cpcl => Cpcl.Encode(doc),
            _ => throw new PrinterException($"{printer.Name} is a receipt printer: labels need a label printer (ZPL, TSPL, EPL or CPCL)."),
        };
    }

    private async Task Send(PrinterProfile printer, byte[] bytes, CancellationToken ct)
    {
        if (printer.Problem() is { } problem) throw new PrinterException(problem);
        await _transportFor(printer).SendAsync(bytes, ct).ConfigureAwait(false);
    }

    public Task PrintReceiptAsync(PrinterProfile printer, ReceiptDoc doc, CancellationToken ct = default) => Send(printer, ReceiptBytes(printer, doc), ct);

    public Task PrintLabelAsync(PrinterProfile printer, LabelDoc doc, CancellationToken ct = default) => Send(printer, LabelBytes(printer, doc), ct);

    public Task OpenDrawerAsync(PrinterProfile printer, CancellationToken ct = default) =>
        Send(printer, EscPos.Encode(new ReceiptDoc { Columns = printer.Columns }.Add(new DrawerElement()), new EscPosOptions { CodePage = printer.CodePage }), ct);

    /// <summary>A short page that shows the printer works: the name, the paper width, text in two sizes, a barcode and a QR code (or, for a label printer, a label).</summary>
    public Task PrintTestAsync(PrinterProfile printer, string shopName, CancellationToken ct = default)
    {
        if (printer.Role == PrinterRole.Label)
            return PrintLabelAsync(printer, LabelTemplates.PriceTag("Test label", "123.45", "5901234123457", printer.LabelWidthMm, printer.LabelHeightMm, printer.Dpi), ct);
        var doc = new ReceiptDoc { Columns = printer.Columns };
        doc.Text(shopName, Align.Center, true, 2).Text("Printer test", Align.Center).Line()
            .Text($"{printer.Name}: {printer.Columns} characters across")
            .Text("0123456789 ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz".Substring(0, Math.Min(62, printer.Columns * 2)))
            .Split("Left", "Right").Text("Bold text", bold: true).Add(new BarcodeElement(Barcodes.BarcodeKind.Ean13, "5901234123457")).Add(new QrElement("https://example.invalid/test"))
            .Blank(1).Text("If you can read this, the printer works.", Align.Center).Cut();
        return PrintReceiptAsync(printer, doc, ct);
    }
}
