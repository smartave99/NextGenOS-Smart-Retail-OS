using NextGenOS.Devices.Barcodes;

namespace NextGenOS.Devices.Printing;

/// <summary>How to talk to one receipt printer.</summary>
public sealed class EscPosOptions
{
    public PrinterCodePage CodePage { get; set; } = PrinterCodePage.Pc858;
    /// <summary>Dots across the paper: 384 for 58 mm paper, 576 for 80 mm (what pictures and text-as-picture are sized to).</summary>
    public int PaperDots { get; set; } = 576;
    /// <summary>Print a line as a picture when its text has characters the character set lacks (Cyrillic on a Latin printer, Chinese, ...). Needs a <see cref="ITextRasterizer"/>.</summary>
    public ITextRasterizer? Rasterizer { get; set; }
    /// <summary>Lines to feed before cutting, so the cut is below the last line.</summary>
    public int FeedBeforeCut { get; set; } = 4;
}

/// <summary>Something that draws text as a picture of dots (using the fonts of this PC).</summary>
public interface ITextRasterizer
{
    BitmapElement Render(string text, int widthDots, int size, bool bold, Align align);
}

/// <summary>Receipt printers that speak ESC/POS: Epson and nearly every other make of receipt printer, wired, network or Bluetooth.</summary>
public static class EscPos
{
    private const byte Esc = 0x1B, Gs = 0x1D, Lf = 0x0A;

    public static byte[] Encode(ReceiptDoc doc, EscPosOptions? options = null)
    {
        var o = options ?? new EscPosOptions();
        var w = new List<byte> { Esc, (byte)'@', Esc, (byte)'t', (byte)o.CodePage };
        foreach (var item in doc.Items) Write(w, item, doc.Columns, o);
        return w.ToArray();
    }

    private static void Write(List<byte> w, ReceiptElement item, int columns, EscPosOptions o)
    {
        switch (item)
        {
            case TextLine t:
                Style(w, t.Align, t.Bold, t.Size, t.Underline);
                var wide = Math.Max(1, columns / Math.Max(1, t.Size));
                foreach (var line in TextEncoding.Wrap(t.Text, wide)) Line(w, line, t.Align, t.Bold, t.Size, wide, o);
                Style(w, Align.Left, false, 1, false);
                break;
            case SplitLine s:
                Style(w, Align.Left, s.Bold, 1, false);
                var space = Math.Max(1, columns - s.Left.Length - s.Right.Length);
                var text = s.Left.Length + s.Right.Length >= columns
                    ? s.Left[..Math.Max(0, columns - s.Right.Length - 1)] + " " + s.Right
                    : s.Left + new string(' ', space) + s.Right;
                Line(w, text, Align.Left, s.Bold, 1, columns, o);
                Style(w, Align.Left, false, 1, false);
                break;
            case Rule r:
                Line(w, new string(r.Character, columns), Align.Left, false, 1, columns, o);
                break;
            case Feed f:
                w.AddRange(new byte[] { Esc, (byte)'d', (byte)Math.Clamp(f.Lines, 0, 255) });
                break;
            case BarcodeElement b:
                WriteBarcode(w, b);
                break;
            case QrElement q:
                WriteQr(w, q);
                break;
            case BitmapElement bm:
                WriteBitmap(w, bm);
                break;
            case CutElement c:
                w.AddRange(new byte[] { Esc, (byte)'d', (byte)o.FeedBeforeCut });
                w.AddRange(c.Full ? new byte[] { Gs, (byte)'V', 0 } : new byte[] { Gs, (byte)'V', 66, 0 });
                break;
            case DrawerElement:
                w.AddRange(new byte[] { Esc, (byte)'p', 0, 25, 250 });
                break;
        }
    }

    private static void Style(List<byte> w, Align align, bool bold, int size, bool underline)
    {
        w.AddRange(new byte[] { Esc, (byte)'a', (byte)align });
        w.AddRange(new byte[] { Esc, (byte)'E', (byte)(bold ? 1 : 0) });
        w.AddRange(new byte[] { Esc, (byte)'-', (byte)(underline ? 1 : 0) });
        var s = (byte)(Math.Clamp(size, 1, 4) - 1);
        w.AddRange(new byte[] { Gs, (byte)'!', (byte)((s << 4) | s) });
    }

    private static void Line(List<byte> w, string text, Align align, bool bold, int size, int columns, EscPosOptions o)
    {
        if (o.Rasterizer is not null && !TextEncoding.CanPrint(text, o.CodePage))
        {
            WriteBitmap(w, o.Rasterizer.Render(text, o.PaperDots, size, bold, align));
            return;
        }
        w.AddRange(TextEncoding.Encode(text, o.CodePage));
        w.Add(Lf);
    }

    private static void WriteBarcode(List<byte> w, BarcodeElement b)
    {
        w.AddRange(new byte[] { Esc, (byte)'a', 1 });                                  // centred
        w.AddRange(new byte[] { Gs, (byte)'h', (byte)Math.Clamp(b.Height, 1, 255) });  // height
        w.AddRange(new byte[] { Gs, (byte)'w', 2 });                                   // module width
        w.AddRange(new byte[] { Gs, (byte)'H', (byte)(b.ShowText ? 2 : 0) });          // number below
        byte type;
        string data = b.Data;
        switch (b.Kind)
        {
            case BarcodeKind.UpcA: type = 65; break;
            case BarcodeKind.Ean13: type = 67; break;
            case BarcodeKind.Ean8: type = 68; break;
            case BarcodeKind.Code39: type = 69; data = b.Data.ToUpperInvariant(); break;
            default: type = 73; data = "{B" + b.Data; break;                             // Code 128, set B (letters and digits)
        }
        var bytes = System.Text.Encoding.ASCII.GetBytes(data);
        if (bytes.Length > 255) throw new ArgumentException("That barcode text is too long.");
        w.AddRange(new byte[] { Gs, (byte)'k', type, (byte)bytes.Length });
        w.AddRange(bytes);
        w.Add(Lf);
        w.AddRange(new byte[] { Esc, (byte)'a', 0 });
    }

    private static void WriteQr(List<byte> w, QrElement q)
    {
        var data = System.Text.Encoding.UTF8.GetBytes(q.Data);
        if (data.Length is 0 or > 700) throw new ArgumentException("The QR code needs between 1 and 700 characters.");
        w.AddRange(new byte[] { Esc, (byte)'a', 1 });
        w.AddRange(new byte[] { Gs, (byte)'(', (byte)'k', 4, 0, 49, 65, 50, 0 });                          // model 2
        w.AddRange(new byte[] { Gs, (byte)'(', (byte)'k', 3, 0, 49, 67, (byte)Math.Clamp(q.Size, 1, 16) }); // module size
        w.AddRange(new byte[] { Gs, (byte)'(', (byte)'k', 3, 0, 49, 69, 49 });                              // error correction M
        var len = data.Length + 3;
        w.AddRange(new byte[] { Gs, (byte)'(', (byte)'k', (byte)(len & 0xFF), (byte)(len >> 8), 49, 80, 48 });
        w.AddRange(data);
        w.AddRange(new byte[] { Gs, (byte)'(', (byte)'k', 3, 0, 49, 81, 48 });                              // print it
        w.Add(Lf);
        w.AddRange(new byte[] { Esc, (byte)'a', 0 });
    }

    private static void WriteBitmap(List<byte> w, BitmapElement b)
    {
        var rowBytes = (b.Width + 7) / 8;
        if (b.Bits.Length != rowBytes * b.Height) throw new ArgumentException("The picture's size does not match its dots.");
        w.AddRange(new byte[] { Esc, (byte)'a', 1 });
        w.AddRange(new byte[] { Gs, (byte)'v', (byte)'0', 0, (byte)(rowBytes & 0xFF), (byte)(rowBytes >> 8), (byte)(b.Height & 0xFF), (byte)(b.Height >> 8) });
        w.AddRange(b.Bits);
        w.AddRange(new byte[] { Esc, (byte)'a', 0 });
    }
}
