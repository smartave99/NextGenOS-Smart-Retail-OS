using System.Text;
using NextGenOS.Devices.Barcodes;
using NextGenOS.Devices.Printing;

namespace NextGenOS.Devices.Tests;

public class PrinterLanguageTests
{
    private static bool Contains(byte[] haystack, params byte[] needle)
    {
        for (var i = 0; i + needle.Length <= haystack.Length; i++)
            if (haystack.AsSpan(i, needle.Length).SequenceEqual(needle)) return true;
        return false;
    }

    private static string Ascii(byte[] bytes) => Encoding.Latin1.GetString(bytes);

    [Fact]
    public void A_receipt_starts_by_resetting_the_printer_and_choosing_the_character_set()
    {
        var bytes = EscPos.Encode(new ReceiptDoc().Text("Hello"), new EscPosOptions { CodePage = PrinterCodePage.Pc858 });
        Assert.Equal(new byte[] { 0x1B, 0x40, 0x1B, 0x74, 19 }, bytes[..5]);
        Assert.Contains("Hello\n", Ascii(bytes));
    }

    [Fact]
    public void Text_style_is_set_for_the_line_and_put_back_after()
    {
        var bytes = EscPos.Encode(new ReceiptDoc().Text("TOTAL", Align.Right, true, 2));
        Assert.True(Contains(bytes, 0x1B, 0x61, 2));                 // right
        Assert.True(Contains(bytes, 0x1B, 0x45, 1));                 // bold on
        Assert.True(Contains(bytes, 0x1D, 0x21, 0x11));              // double size
        Assert.True(Contains(bytes, 0x1B, 0x61, 0));                 // left again
        Assert.True(Contains(bytes, 0x1D, 0x21, 0x00));              // normal size again
    }

    [Fact]
    public void A_line_with_a_name_and_an_amount_fills_the_paper_exactly()
    {
        var bytes = EscPos.Encode(new ReceiptDoc { Columns = 32 }.Split("Basmati rice 5 kg", "425.00"));
        var line = Ascii(bytes).Split('\n').First(l => l.Contains("Basmati"));
        var text = line[line.IndexOf("Basmati", StringComparison.Ordinal)..];
        Assert.Equal(32, text.Length);
        Assert.EndsWith("425.00", text);
    }

    [Fact]
    public void A_name_too_long_for_the_line_is_shortened_so_the_amount_always_shows()
    {
        var bytes = EscPos.Encode(new ReceiptDoc { Columns = 24 }.Split("Extra long product name that does not fit", "1,299.00"));
        var line = Ascii(bytes).Split('\n').First(l => l.Contains("1,299.00"));
        var text = line[line.IndexOf("Extra", StringComparison.Ordinal)..];
        Assert.EndsWith(" 1,299.00", text);
        Assert.True(text.Length <= 24, text);
    }

    [Fact]
    public void Double_size_text_wraps_at_half_the_width()
    {
        var bytes = EscPos.Encode(new ReceiptDoc { Columns = 20 }.Text("ABCDEFGHIJKLMNOPQRST", size: 2));
        var lines = Ascii(bytes).Split('\n').Where(l => l.Contains("ABCDE") || l.Contains("KLMNO")).ToList();
        Assert.Equal(2, lines.Count);
    }

    [Fact]
    public void Cutting_feeds_the_paper_first_and_a_cash_drawer_is_kicked_with_the_standard_pulse()
    {
        var bytes = EscPos.Encode(new ReceiptDoc().Text("x").Cut().Add(new DrawerElement()), new EscPosOptions { FeedBeforeCut = 5 });
        Assert.True(Contains(bytes, 0x1B, 0x64, 5, 0x1D, 0x56, 66, 0));
        Assert.True(Contains(bytes, 0x1B, 0x70, 0, 25, 250));
        var full = EscPos.Encode(new ReceiptDoc().Add(new CutElement(true)));
        Assert.True(Contains(full, 0x1D, 0x56, 0));
    }

    [Fact]
    public void Barcodes_are_sent_with_their_type_and_the_number_printed_below()
    {
        var ean = EscPos.Encode(new ReceiptDoc().Add(new BarcodeElement(BarcodeKind.Ean13, "5901234123457", 80)));
        Assert.True(Contains(ean, 0x1D, 0x68, 80));                                       // height
        Assert.True(Contains(ean, 0x1D, 0x48, 2));                                        // number below
        Assert.True(Contains(ean, new byte[] { 0x1D, 0x6B, 67, 13 }.Concat(Encoding.ASCII.GetBytes("5901234123457")).ToArray()));
        var c128 = EscPos.Encode(new ReceiptDoc().Add(new BarcodeElement(BarcodeKind.Code128, "AB12", 60, false)));
        Assert.True(Contains(c128, 0x1D, 0x48, 0));
        Assert.True(Contains(c128, new byte[] { 0x1D, 0x6B, 73, 6 }.Concat(Encoding.ASCII.GetBytes("{BAB12")).ToArray()));
    }

    [Fact]
    public void A_QR_code_is_sent_as_the_five_steps_the_printers_expect()
    {
        var bytes = EscPos.Encode(new ReceiptDoc().Add(new QrElement("https://example.com/r/1", 5)));
        Assert.True(Contains(bytes, 0x1D, 0x28, 0x6B, 4, 0, 49, 65, 50, 0));              // model 2
        Assert.True(Contains(bytes, 0x1D, 0x28, 0x6B, 3, 0, 49, 67, 5));                  // size
        var store = new byte[] { 0x1D, 0x28, 0x6B, 26, 0, 49, 80, 48 }.Concat(Encoding.ASCII.GetBytes("https://example.com/r/1")).ToArray();
        Assert.True(Contains(bytes, store));
        Assert.True(Contains(bytes, 0x1D, 0x28, 0x6B, 3, 0, 49, 81, 48));                 // print
        Assert.Throws<ArgumentException>(() => EscPos.Encode(new ReceiptDoc().Add(new QrElement(""))));
    }

    [Fact]
    public void A_logo_picture_is_sent_as_raster_dots_and_a_wrong_size_is_refused()
    {
        var bits = new byte[3 * 4];
        var bytes = EscPos.Encode(new ReceiptDoc().Add(new BitmapElement(24, 4, bits)));
        Assert.True(Contains(bytes, 0x1D, 0x76, 0x30, 0, 3, 0, 4, 0));
        Assert.Throws<ArgumentException>(() => EscPos.Encode(new ReceiptDoc().Add(new BitmapElement(24, 4, new byte[5]))));
    }

    [Fact]
    public void Text_in_a_language_the_character_set_lacks_is_printed_as_a_picture_when_a_rasterizer_is_given()
    {
        var plain = EscPos.Encode(new ReceiptDoc().Text("Привет"), new EscPosOptions { CodePage = PrinterCodePage.Pc858 });
        Assert.Contains("??????", Ascii(plain));                                         // without help: question marks
        var picture = EscPos.Encode(new ReceiptDoc().Text("Привет"), new EscPosOptions { CodePage = PrinterCodePage.Pc858, Rasterizer = new SkiaTextRasterizer(), PaperDots = 384 });
        Assert.True(Contains(picture, 0x1D, 0x76, 0x30, 0, 48, 0));                       // 384 dots = 48 bytes across
        var chinese = EscPos.Encode(new ReceiptDoc().Text("谢谢惠顾"), new EscPosOptions { Rasterizer = new SkiaTextRasterizer() });
        Assert.True(Contains(chinese, 0x1D, 0x76, 0x30));
    }

    [Fact]
    public void The_rasterizer_draws_black_dots_and_aligns_text()
    {
        var r = new SkiaTextRasterizer();
        var left = r.Render("Hello", 384, 1, false, Align.Left);
        var right = r.Render("Hello", 384, 1, false, Align.Right);
        Assert.Equal(384, left.Width);
        Assert.Equal(left.Width / 8 * left.Height, left.Bits.Length);
        Assert.Contains(left.Bits, b => b != 0);
        static bool Black(BitmapElement e, int x) => Enumerable.Range(0, e.Height).Any(y => (e.Bits[y * (e.Width / 8) + x / 8] & (0x80 >> (x % 8))) != 0);
        static int LastBlack(BitmapElement e) => Enumerable.Range(0, e.Width).Last(x => Black(e, x));
        static int FirstBlack(BitmapElement e) => Enumerable.Range(0, e.Width).First(x => Black(e, x));
        Assert.True(LastBlack(right) > 300, "right-aligned text ends near the right edge");
        Assert.True(FirstBlack(left) < 20 && LastBlack(left) < 150, "left-aligned text stays at the left");
    }

    // ---- labels ----------------------------------------------------------------------------------------------------------------

    private static LabelDoc Sample() => LabelTemplates.PriceTag("Basmati rice 5 kg", "425.00", "5901234123457", 50, 30, 203, 2);

    [Fact]
    public void A_ZPL_label_has_the_size_in_dots_the_text_the_barcode_and_the_number_of_copies()
    {
        var text = Encoding.UTF8.GetString(Zpl.Encode(Sample()));
        Assert.StartsWith("^XA^CI28^PW400^LL240", text);
        Assert.Contains("^FD" + "Basmati rice 5 kg" + "^FS", text);
        Assert.Contains("^BEN,", text);
        Assert.Contains("^FD5901234123457^FS", text);
        Assert.EndsWith("^PQ2^XZ\n", text);
    }

    [Fact]
    public void Characters_that_start_ZPL_commands_cannot_get_into_the_label_text()
    {
        var doc = new LabelDoc().Add(new LabelText(1, 1, "Fish ^FS~JA & chips"));
        var text = Encoding.UTF8.GetString(Zpl.Encode(doc));
        Assert.DoesNotContain("^FS~", text);
        Assert.Contains("Fish  FS JA & chips", text);
        Assert.Contains("^FD", text);
    }

    [Fact]
    public void A_TSPL_label_has_the_size_in_millimetres_and_a_barcode_of_the_right_kind()
    {
        var text = Encoding.Latin1.GetString(Tspl.Encode(Sample()));
        Assert.Contains("SIZE 50 mm,30 mm\r\n", text);
        Assert.Contains("GAP 3 mm,0 mm\r\n", text);
        Assert.Contains("\"EAN13\"", text);
        Assert.Contains("\"5901234123457\"", text);
        Assert.EndsWith("PRINT 2,1\r\n", text);
        var code = Encoding.Latin1.GetString(Tspl.Encode(LabelTemplates.PriceTag("x", "1", "AB-12")));
        Assert.Contains("\"128\"", code);
    }

    [Fact]
    public void A_quote_inside_label_text_cannot_end_the_text_early()
    {
        var text = Encoding.Latin1.GetString(Tspl.Encode(new LabelDoc().Add(new LabelText(1, 1, "He said \"hi\""))));
        Assert.Contains("\"He said 'hi'\"", text);
    }

    [Fact]
    public void EPL_and_CPCL_labels_are_made_and_EPL_says_plainly_it_has_no_QR_code()
    {
        var epl = Encoding.ASCII.GetString(Epl.Encode(Sample()));
        Assert.Contains("\r\nN\r\nq400\r\nQ240,", epl);
        Assert.Contains("E30", epl);
        Assert.EndsWith("P2\r\n", epl);
        var ex = Assert.Throws<NotSupportedException>(() => Epl.Encode(new LabelDoc().Add(new LabelQr(1, 1, "x"))));
        Assert.Contains("no QR", ex.Message);
        var cpcl = Encoding.ASCII.GetString(Cpcl.Encode(new LabelDoc { Copies = 1 }.Add(new LabelQr(2, 2, "hello", 14)).Add(new LabelBox(0, 0, 10, 10))));
        Assert.StartsWith("! 0 203 203 240 1\r\nPAGE-WIDTH 400\r\n", cpcl);
        Assert.Contains("BARCODE QR", cpcl);
        Assert.Contains("MA,hello", cpcl);
        Assert.EndsWith("FORM\r\nPRINT\r\n", cpcl);
    }

    [Fact]
    public void Dots_follow_the_printers_resolution()
    {
        Assert.Equal(400, new LabelDoc { Dpi = 203 }.Dots(50));
        Assert.Equal(591, new LabelDoc { Dpi = 300 }.Dots(50));
    }
}
