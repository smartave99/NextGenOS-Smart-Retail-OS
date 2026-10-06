using System.Globalization;
using System.Text;
using NextGenOS.Devices.Barcodes;

namespace NextGenOS.Devices.Printing;

/// <summary>The languages of label printers. Each turns a <see cref="LabelDoc"/> into the bytes the printer wants.</summary>
public static class Zpl
{
    /// <summary>Zebra and compatible printers (ZPL II).</summary>
    public static byte[] Encode(LabelDoc doc, ITextRasterizer? rasterizer = null)
    {
        var sb = new StringBuilder();
        sb.Append("^XA^CI28^PW").Append(doc.Dots(doc.WidthMm)).Append("^LL").Append(doc.Dots(doc.HeightMm)).Append("^LH0,0\n");
        foreach (var item in doc.Items)
        {
            switch (item)
            {
                case LabelText t:
                    var height = Math.Max(10, doc.Dots(t.HeightMm));
                    var x = doc.Dots(t.X); var y = doc.Dots(t.Y);
                    var block = t.MaxWidthMm > 0 ? $"^FB{doc.Dots(t.MaxWidthMm)},2,0,L,0" : string.Empty;
                    sb.Append($"^FO{x},{y}^A0N,{height},{height}{block}^FD{Clean(t.Text)}^FS\n");
                    break;
                case LabelBarcode b:
                    var bh = Math.Max(20, doc.Dots(b.HeightMm));
                    sb.Append($"^FO{doc.Dots(b.X)},{doc.Dots(b.Y)}^BY2,3,{bh}");
                    sb.Append(b.Kind switch
                    {
                        BarcodeKind.Ean13 => $"^BEN,{bh},{Hri(b)},N",
                        BarcodeKind.Ean8 => $"^B8N,{bh},{Hri(b)},N",
                        BarcodeKind.UpcA => $"^BUN,{bh},{Hri(b)},N,Y",
                        BarcodeKind.Code39 => $"^B3N,N,{bh},{Hri(b)},N",
                        _ => $"^BCN,{bh},{Hri(b)},N,N",
                    });
                    sb.Append($"^FD{Clean(b.Data)}^FS\n");
                    break;
                case LabelQr q:
                    var mag = Math.Clamp((int)Math.Round(doc.Dots(q.SizeMm) / 29.0), 1, 10);
                    sb.Append($"^FO{doc.Dots(q.X)},{doc.Dots(q.Y)}^BQN,2,{mag}^FDQA,{Clean(q.Data)}^FS\n");
                    break;
                case LabelBox bx:
                    sb.Append($"^FO{doc.Dots(bx.X)},{doc.Dots(bx.Y)}^GB{doc.Dots(bx.WidthMm)},{doc.Dots(bx.HeightMm)},{Math.Max(1, doc.Dots(bx.ThicknessMm))}^FS\n");
                    break;
            }
        }
        sb.Append("^PQ").Append(Math.Max(1, doc.Copies)).Append("^XZ\n");
        return Encoding.UTF8.GetBytes(sb.ToString());
    }

    private static string Hri(LabelBarcode b) => b.ShowText ? "Y" : "N";

    /// <summary>^ and ~ start commands in ZPL: they cannot appear inside text.</summary>
    internal static string Clean(string text) => text.Replace('^', ' ').Replace('~', ' ').Replace("\r", " ").Replace("\n", " ");
}

public static class Tspl
{
    /// <summary>TSC and compatible printers (TSPL / TSPL2): most low-cost label printers sold for shop labels.</summary>
    public static byte[] Encode(LabelDoc doc)
    {
        var sb = new StringBuilder();
        sb.Append($"SIZE {Mm(doc.WidthMm)} mm,{Mm(doc.HeightMm)} mm\r\nGAP {Mm(doc.GapMm)} mm,0 mm\r\nDIRECTION 1\r\nREFERENCE 0,0\r\nCODEPAGE 1252\r\nCLS\r\n");
        foreach (var item in doc.Items)
        {
            switch (item)
            {
                case LabelText t:
                    var mul = Math.Clamp((int)Math.Round(doc.Dots(t.HeightMm) / 24.0), 1, 10);
                    sb.Append($"TEXT {doc.Dots(t.X)},{doc.Dots(t.Y)},\"3\",0,{mul},{mul},\"{Quote(Latin(t.Text))}\"\r\n");
                    break;
                case LabelBarcode b:
                    var kind = b.Kind switch { BarcodeKind.Ean13 => "EAN13", BarcodeKind.Ean8 => "EAN8", BarcodeKind.UpcA => "UPCA", BarcodeKind.Code39 => "39", _ => "128" };
                    sb.Append($"BARCODE {doc.Dots(b.X)},{doc.Dots(b.Y)},\"{kind}\",{Math.Max(20, doc.Dots(b.HeightMm))},{(b.ShowText ? 1 : 0)},0,2,2,\"{Quote(b.Data)}\"\r\n");
                    break;
                case LabelQr q:
                    var cell = Math.Clamp((int)Math.Round(doc.Dots(q.SizeMm) / 29.0), 1, 10);
                    sb.Append($"QRCODE {doc.Dots(q.X)},{doc.Dots(q.Y)},M,{cell},A,0,\"{Quote(q.Data)}\"\r\n");
                    break;
                case LabelBox bx:
                    sb.Append($"BOX {doc.Dots(bx.X)},{doc.Dots(bx.Y)},{doc.Dots(bx.X + bx.WidthMm)},{doc.Dots(bx.Y + bx.HeightMm)},{Math.Max(1, doc.Dots(bx.ThicknessMm))}\r\n");
                    break;
            }
        }
        sb.Append($"PRINT {Math.Max(1, doc.Copies)},1\r\n");
        return Encoding.GetEncoding(1252, EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback).GetBytes(sb.ToString());
    }

    private static string Mm(double mm) => mm.ToString("0.##", CultureInfo.InvariantCulture);

    private static string Quote(string text) => text.Replace("\"", "'").Replace("\r", " ").Replace("\n", " ");

    /// <summary>Text this printer's character set can write (Latin-1 with the usual spellings).</summary>
    private static string Latin(string text) => ToLatin(text);

    private static string ToLatin(string text)
    {
        var bytes = TextEncoding.Encode(text, PrinterCodePage.Wpc1252);
        return Encoding.GetEncoding(1252).GetString(bytes);
    }
}

public static class Epl
{
    /// <summary>Older Zebra / Eltron printers (EPL2).</summary>
    public static byte[] Encode(LabelDoc doc)
    {
        var sb = new StringBuilder();
        sb.Append($"\r\nN\r\nq{doc.Dots(doc.WidthMm)}\r\nQ{doc.Dots(doc.HeightMm)},{Math.Max(1, doc.Dots(doc.GapMm))}\r\n");
        foreach (var item in doc.Items)
        {
            switch (item)
            {
                case LabelText t:
                    var mul = Math.Clamp((int)Math.Round(doc.Dots(t.HeightMm) / 20.0), 1, 6);
                    sb.Append($"A{doc.Dots(t.X)},{doc.Dots(t.Y)},0,3,{mul},{mul},N,\"{Quote(Latin(t.Text))}\"\r\n");
                    break;
                case LabelBarcode b:
                    var code = b.Kind switch { BarcodeKind.Ean13 => "E30", BarcodeKind.Ean8 => "E80", BarcodeKind.UpcA => "UA0", BarcodeKind.Code39 => "3", _ => "1" };
                    sb.Append($"B{doc.Dots(b.X)},{doc.Dots(b.Y)},0,{code},2,5,{Math.Max(20, doc.Dots(b.HeightMm))},{(b.ShowText ? "B" : "N")},\"{Quote(b.Data)}\"\r\n");
                    break;
                case LabelQr:
                    throw new NotSupportedException("This printer language (EPL) has no QR code. Use a barcode, or another printer.");
                case LabelBox bx:
                    sb.Append($"X{doc.Dots(bx.X)},{doc.Dots(bx.Y)},{Math.Max(1, doc.Dots(bx.ThicknessMm))},{doc.Dots(bx.X + bx.WidthMm)},{doc.Dots(bx.Y + bx.HeightMm)}\r\n");
                    break;
            }
        }
        sb.Append($"P{Math.Max(1, doc.Copies)}\r\n");
        return Encoding.ASCII.GetBytes(sb.ToString());
    }

    private static string Quote(string text) => text.Replace("\"", "'").Replace("\\", "/").Replace("\r", " ").Replace("\n", " ");

    private static string Latin(string text) => new(TextEncoding.Encode(text, PrinterCodePage.Pc437).Select(b => b < 0x80 ? (char)b : '?').ToArray());
}

public static class Cpcl
{
    /// <summary>Mobile (battery, Bluetooth) label and receipt printers that speak CPCL: Zebra, Honeywell and others.</summary>
    public static byte[] Encode(LabelDoc doc)
    {
        var sb = new StringBuilder();
        sb.Append($"! 0 {doc.Dpi} {doc.Dpi} {doc.Dots(doc.HeightMm)} {Math.Max(1, doc.Copies)}\r\nPAGE-WIDTH {doc.Dots(doc.WidthMm)}\r\n");
        foreach (var item in doc.Items)
        {
            switch (item)
            {
                case LabelText t:
                    var size = Math.Clamp((int)Math.Round(doc.Dots(t.HeightMm) / 24.0) - 1, 0, 5);
                    sb.Append($"TEXT 4 {size} {doc.Dots(t.X)} {doc.Dots(t.Y)} {Clean(Latin(t.Text))}\r\n");
                    break;
                case LabelBarcode b:
                    var kind = b.Kind switch { BarcodeKind.Ean13 => "EAN13", BarcodeKind.Ean8 => "EAN8", BarcodeKind.UpcA => "UPCA", BarcodeKind.Code39 => "39", _ => "128" };
                    sb.Append($"BARCODE {kind} 1 1 {Math.Max(20, doc.Dots(b.HeightMm))} {doc.Dots(b.X)} {doc.Dots(b.Y)} {Clean(b.Data)}\r\n");
                    break;
                case LabelQr q:
                    var unit = Math.Clamp((int)Math.Round(doc.Dots(q.SizeMm) / 29.0), 1, 32);
                    sb.Append($"BARCODE QR {doc.Dots(q.X)} {doc.Dots(q.Y)} M 2 U {unit}\r\nMA,{Clean(q.Data)}\r\nENDQR\r\n");
                    break;
                case LabelBox bx:
                    sb.Append($"BOX {doc.Dots(bx.X)} {doc.Dots(bx.Y)} {doc.Dots(bx.X + bx.WidthMm)} {doc.Dots(bx.Y + bx.HeightMm)} {Math.Max(1, doc.Dots(bx.ThicknessMm))}\r\n");
                    break;
            }
        }
        sb.Append("FORM\r\nPRINT\r\n");
        return Encoding.ASCII.GetBytes(sb.ToString());
    }

    private static string Clean(string text) => text.Replace("\r", " ").Replace("\n", " ");

    private static string Latin(string text) => new(TextEncoding.Encode(text, PrinterCodePage.Pc437).Select(b => b < 0x80 ? (char)b : '?').ToArray());
}
