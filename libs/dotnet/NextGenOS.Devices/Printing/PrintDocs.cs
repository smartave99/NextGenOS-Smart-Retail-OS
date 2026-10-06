namespace NextGenOS.Devices.Printing;

public enum Align { Left, Center, Right }

/// <summary>One thing on a receipt. The same list is turned into the commands of any receipt printer, or into a picture for printers that need one.</summary>
public abstract record ReceiptElement;

/// <summary>A line of text, with its look. <see cref="Size"/> 1 is normal, 2 is double width and height, up to 4.</summary>
public sealed record TextLine(string Text, Align Align = Align.Left, bool Bold = false, int Size = 1, bool Underline = false) : ReceiptElement;

/// <summary>Two pieces of text on one line, one at each edge (a name and its amount).</summary>
public sealed record SplitLine(string Left, string Right, bool Bold = false) : ReceiptElement;

public sealed record Rule(char Character = '-') : ReceiptElement;

public sealed record Feed(int Lines = 1) : ReceiptElement;

public sealed record BarcodeElement(Barcodes.BarcodeKind Kind, string Data, int Height = 60, bool ShowText = true) : ReceiptElement;

public sealed record QrElement(string Data, int Size = 6) : ReceiptElement;

/// <summary>A black-and-white picture, one bit for each dot, row after row, the widest first (a logo).</summary>
public sealed record BitmapElement(int Width, int Height, byte[] Bits) : ReceiptElement;

public sealed record CutElement(bool Full = false) : ReceiptElement;

public sealed record DrawerElement : ReceiptElement;

/// <summary>A receipt to print: how wide the paper is in characters (32 for 58 mm paper, 42 or 48 for 80 mm), and what goes on it.</summary>
public sealed class ReceiptDoc
{
    public int Columns { get; set; } = 42;
    public List<ReceiptElement> Items { get; } = new();

    public ReceiptDoc Add(ReceiptElement element)
    {
        Items.Add(element);
        return this;
    }

    public ReceiptDoc Text(string text, Align align = Align.Left, bool bold = false, int size = 1) => Add(new TextLine(text, align, bold, size));

    public ReceiptDoc Split(string left, string right, bool bold = false) => Add(new SplitLine(left, right, bold));

    public ReceiptDoc Line() => Add(new Rule());

    public ReceiptDoc Blank(int lines = 1) => Add(new Feed(lines));

    public ReceiptDoc Cut() => Add(new CutElement());
}

public abstract record LabelElement;

/// <summary>Positions are in millimetres from the top left of the label.</summary>
public sealed record LabelText(double X, double Y, string Text, double HeightMm = 3.5, bool Bold = false, double MaxWidthMm = 0) : LabelElement;

public sealed record LabelBarcode(double X, double Y, Barcodes.BarcodeKind Kind, string Data, double HeightMm = 10, bool ShowText = true) : LabelElement;

public sealed record LabelQr(double X, double Y, string Data, double SizeMm = 14) : LabelElement;

public sealed record LabelBox(double X, double Y, double WidthMm, double HeightMm, double ThicknessMm = 0.3) : LabelElement;

/// <summary>A label: its size, the printer's dots per inch (203 or 300 are usual) and what goes on it.</summary>
public sealed class LabelDoc
{
    public double WidthMm { get; set; } = 50;
    public double HeightMm { get; set; } = 30;
    public int Dpi { get; set; } = 203;
    public double GapMm { get; set; } = 3;
    public int Copies { get; set; } = 1;
    public List<LabelElement> Items { get; } = new();

    public int Dots(double mm) => (int)Math.Round(mm * Dpi / 25.4);

    public LabelDoc Add(LabelElement e)
    {
        Items.Add(e);
        return this;
    }
}

/// <summary>Ready-made labels.</summary>
public static class LabelTemplates
{
    /// <summary>A shelf or price label: the name, a big price and the barcode.</summary>
    public static LabelDoc PriceTag(string name, string price, string? barcode, double widthMm = 50, double heightMm = 30, int dpi = 203, int copies = 1)
    {
        var doc = new LabelDoc { WidthMm = widthMm, HeightMm = heightMm, Dpi = dpi, Copies = copies };
        var pad = 2.0;
        doc.Add(new LabelText(pad, 1.5, name, 3.4, false, widthMm - 2 * pad));
        doc.Add(new LabelText(pad, 8.5, price, 6.5, true, widthMm - 2 * pad));
        if (!string.IsNullOrWhiteSpace(barcode)) doc.Add(new LabelBarcode(pad, heightMm - 12.5, Barcodes.Barcode.KindFor(barcode), barcode, 8, true));
        return doc;
    }
}
