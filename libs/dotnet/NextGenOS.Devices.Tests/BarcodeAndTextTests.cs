using NextGenOS.Devices.Barcodes;
using NextGenOS.Devices.Printing;

namespace NextGenOS.Devices.Tests;

public class BarcodeAndTextTests
{
    [Theory]
    [InlineData("5901234123457", true)]
    [InlineData("4006381333931", true)]
    [InlineData("5901234123458", false)]
    [InlineData("590123412345", false)]
    [InlineData("59012341234579", false)]
    [InlineData("59012341234AB", false)]
    public void An_EAN13_is_valid_only_with_the_right_length_and_check_digit(string text, bool valid) => Assert.Equal(valid, Barcode.IsValidEan13(text));

    [Fact]
    public void Check_digits_are_worked_out_for_all_three_numbers_the_same_way()
    {
        Assert.Equal(7, Barcode.CheckDigit("590123412345"));
        Assert.Equal(4, Barcode.CheckDigit("9638507"));          // EAN-8 96385074
        Assert.True(Barcode.IsValidEan8("96385074"));
        Assert.True(Barcode.IsValidUpcA("036000291452"));
        Assert.Throws<ArgumentException>(() => Barcode.CheckDigit("12A"));
    }

    [Theory]
    [InlineData("5901234123457", BarcodeKind.Ean13)]
    [InlineData("036000291452", BarcodeKind.UpcA)]
    [InlineData("96385074", BarcodeKind.Ean8)]
    [InlineData("ABC-123", BarcodeKind.Code128)]
    [InlineData("5901234123458", BarcodeKind.Code128)]          // a number with a wrong check digit is not printed as an EAN
    public void The_kind_of_barcode_follows_the_number(string text, BarcodeKind expected) => Assert.Equal(expected, Barcode.KindFor(text));

    [Theory]
    [InlineData("0-306-40615-2", "9780306406157")]
    [InlineData("0306406152", "9780306406157")]
    [InlineData("978-0-306-40615-7", "9780306406157")]
    [InlineData("080442957X", "9780804429573")]
    [InlineData("0-306-40615-3", null)]
    [InlineData("hello", null)]
    public void ISBNs_are_checked_and_made_into_13_digits(string text, string? expected) => Assert.Equal(expected, Barcode.Isbn13(text));

    [Fact]
    public void In_store_numbers_are_valid_EAN13_that_start_with_2()
    {
        var a = Barcode.InStore(1);
        var b = Barcode.InStore(2);
        Assert.StartsWith("200", a);
        Assert.True(Barcode.IsValidEan13(a));
        Assert.NotEqual(a, b);
        Assert.Throws<ArgumentException>(() => Barcode.InStore(1, "300"));
    }

    [Fact]
    public void Currency_signs_a_printer_lacks_are_written_with_letters()
    {
        Assert.Equal("Rs 118.00", System.Text.Encoding.ASCII.GetString(TextEncoding.Encode("₹ 118.00", PrinterCodePage.Pc437)));
        Assert.Equal("Rs118", System.Text.Encoding.ASCII.GetString(TextEncoding.Encode("₹118", PrinterCodePage.Pc437)));
        Assert.Equal("PHP5", System.Text.Encoding.ASCII.GetString(TextEncoding.Encode("₱5", PrinterCodePage.Pc437)));
        Assert.Equal(new byte[] { 0xD5 }, TextEncoding.Encode("€", PrinterCodePage.Pc858));      // PC858 has the euro
        Assert.Equal("EUR", System.Text.Encoding.ASCII.GetString(TextEncoding.Encode("€", PrinterCodePage.Pc437)));
    }

    [Fact]
    public void Letters_with_marks_are_kept_when_the_set_has_them_and_simplified_when_it_does_not()
    {
        Assert.Equal(new byte[] { 0x82 }, TextEncoding.Encode("é", PrinterCodePage.Pc437));
        Assert.Equal(new byte[] { 0xE9 }, TextEncoding.Encode("é", PrinterCodePage.Wpc1252));
        Assert.Equal("e", System.Text.Encoding.ASCII.GetString(TextEncoding.Encode("ě", PrinterCodePage.Pc437)));  // no such letter in PC437: plain e
    }

    [Theory]
    [InlineData("Price list", PrinterCodePage.Pc858, true)]
    [InlineData("₹ 99", PrinterCodePage.Pc858, true)]
    [InlineData("Привет", PrinterCodePage.Pc858, false)]
    [InlineData("Привет", PrinterCodePage.Pc866, true)]
    [InlineData("你好", PrinterCodePage.Pc858, false)]
    public void Text_that_a_character_set_cannot_write_is_found_out_beforehand(string text, PrinterCodePage page, bool expected) => Assert.Equal(expected, TextEncoding.CanPrint(text, page));

    [Fact]
    public void Long_text_is_cut_at_spaces_to_the_width_of_the_paper()
    {
        var lines = TextEncoding.Wrap("Basmati rice 5 kg family pack with a very long name indeed", 20).ToList();
        Assert.All(lines, l => Assert.True(l.Length <= 20, l));
        Assert.Equal("Basmati rice 5 kg family pack with a very long name indeed", string.Join(" ", lines));
        Assert.Equal(new[] { "abcde", "fghij" }, TextEncoding.Wrap("abcdefghij", 5));       // no space to cut at
        Assert.Equal(new[] { "a", "b" }, TextEncoding.Wrap("a\nb", 10));
    }
}
