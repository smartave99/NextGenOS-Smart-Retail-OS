using System.Text;

namespace NextGenOS.Devices.Printing;

/// <summary>The character sets receipt printers understand, with the number the printer is told (ESC t) and the matching Windows code page.</summary>
public enum PrinterCodePage
{
    Pc437 = 0,
    Pc850 = 2,
    Wpc1252 = 16,
    Pc866 = 17,
    Pc852 = 18,
    Pc858 = 19,
}

/// <summary>Turns text into the bytes of a printer's character set. What the set has not got is written another way (₹ as "Rs") or, if it cannot be, reported so it can be printed as a picture instead.</summary>
public static class TextEncoding
{
    static TextEncoding() => Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

    private static readonly Dictionary<char, string> Spelling = new()
    {
        ['₹'] = "Rs", ['€'] = "EUR", ['£'] = "GBP", ['¥'] = "JPY", ['₱'] = "PHP", ['₩'] = "KRW", ['₫'] = "VND", ['฿'] = "THB", ['₦'] = "NGN", ['₨'] = "Rs", ['₪'] = "ILS", ['₺'] = "TRY",
        ['“'] = "\"", ['”'] = "\"", ['‘'] = "'", ['’'] = "'", ['–'] = "-", ['—'] = "-", ['…'] = "...", ['•'] = "*", ['×'] = "x", ['−'] = "-", [' '] = " ", ['·'] = "-",
    };

    public static int WindowsCodePage(PrinterCodePage page) => page switch
    {
        PrinterCodePage.Pc437 => 437, PrinterCodePage.Pc850 => 850, PrinterCodePage.Wpc1252 => 1252, PrinterCodePage.Pc866 => 866, PrinterCodePage.Pc852 => 852, PrinterCodePage.Pc858 => 858, _ => 437,
    };

    private static Encoding Strict(PrinterCodePage page) => Encoding.GetEncoding(WindowsCodePage(page), EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);

    /// <summary>True when every character can be printed in the character set, possibly after spelling it another way.</summary>
    public static bool CanPrint(string text, PrinterCodePage page) => !text.Any(c => Resolve(c, Strict(page)) is null);

    /// <summary>The bytes of the text in this character set; anything that cannot be written is printed as a question mark (use <see cref="CanPrint"/> first to print it as a picture instead).</summary>
    public static byte[] Encode(string text, PrinterCodePage page)
    {
        var enc = Strict(page);
        var bytes = new List<byte>(text.Length);
        foreach (var c in text.EnumerateRunes().SelectMany(r => r.ToString().ToCharArray()))
            bytes.AddRange(Resolve(c, enc) ?? new[] { (byte)'?' });
        return bytes.ToArray();
    }

    private static byte[]? Resolve(char c, Encoding enc)
    {
        if (c is '\r' or '\n') return new[] { (byte)' ' };
        if (c < 0x20) return Array.Empty<byte>();
        if (TryEncode(c.ToString(), enc, out var bytes)) return bytes;
        if (Spelling.TryGetValue(c, out var other) && TryEncode(other, enc, out bytes)) return bytes;
        // Letters with marks the set lacks: the plain letter (é → e).
        var plain = new string(c.ToString().Normalize(NormalizationForm.FormD).Where(x => System.Globalization.CharUnicodeInfo.GetUnicodeCategory(x) != System.Globalization.UnicodeCategory.NonSpacingMark).ToArray());
        if (plain.Length > 0 && plain[0] < 0x80 && TryEncode(plain, enc, out bytes)) return bytes;
        return null;
    }

    private static bool TryEncode(string s, Encoding enc, out byte[] bytes)
    {
        try
        {
            bytes = enc.GetBytes(s);
            return true;
        }
        catch (EncoderFallbackException)
        {
            bytes = Array.Empty<byte>();
            return false;
        }
    }

    /// <summary>The text cut into lines no wider than the paper, at spaces where possible.</summary>
    public static IEnumerable<string> Wrap(string text, int width)
    {
        if (width < 1) throw new ArgumentOutOfRangeException(nameof(width));
        foreach (var paragraph in text.Replace("\r", "").Split('\n'))
        {
            var line = paragraph;
            while (line.Length > width)
            {
                var cut = line.LastIndexOf(' ', width);
                if (cut <= 0) cut = width;
                yield return line[..cut].TrimEnd();
                line = line[cut..].TrimStart();
            }
            yield return line;
        }
    }
}
