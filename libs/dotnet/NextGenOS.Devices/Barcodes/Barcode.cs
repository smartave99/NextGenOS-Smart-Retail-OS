using System.Globalization;

namespace NextGenOS.Devices.Barcodes;

public enum BarcodeKind { Ean13, Ean8, UpcA, Code128, Code39, Qr }

/// <summary>Checking and making the numbers inside product barcodes. A mistyped or damaged number is found before it reaches a label or a sale.</summary>
public static class Barcode
{
    /// <summary>The check digit that goes after the first digits of an EAN-13, EAN-8 or UPC-A (the same calculation for all three).</summary>
    public static int CheckDigit(string digitsWithoutCheck)
    {
        if (digitsWithoutCheck.Length == 0 || digitsWithoutCheck.Any(c => c is < '0' or > '9')) throw new ArgumentException("Only digits can have a check digit.", nameof(digitsWithoutCheck));
        var sum = 0;
        for (var i = 0; i < digitsWithoutCheck.Length; i++)
        {
            var d = digitsWithoutCheck[digitsWithoutCheck.Length - 1 - i] - '0';
            sum += i % 2 == 0 ? d * 3 : d;
        }
        return (10 - sum % 10) % 10;
    }

    public static bool IsValidEan13(string text) => text.Length == 13 && IsValidWithCheck(text);

    public static bool IsValidEan8(string text) => text.Length == 8 && IsValidWithCheck(text);

    public static bool IsValidUpcA(string text) => text.Length == 12 && IsValidWithCheck(text);

    private static bool IsValidWithCheck(string text) => text.All(c => c is >= '0' and <= '9') && CheckDigit(text[..^1]) == text[^1] - '0';

    /// <summary>Which kind of barcode a number is, by its length and check digit: the kind to print when a label has only the number.</summary>
    public static BarcodeKind KindFor(string text)
    {
        if (IsValidEan13(text)) return BarcodeKind.Ean13;
        if (IsValidUpcA(text)) return BarcodeKind.UpcA;
        if (IsValidEan8(text)) return BarcodeKind.Ean8;
        return BarcodeKind.Code128;
    }

    /// <summary>An ISBN-10 or ISBN-13 with hyphens or spaces, as its 13 digits; null when it is not a valid ISBN.</summary>
    public static string? Isbn13(string text)
    {
        var s = new string(text.Where(c => c != '-' && c != ' ').ToArray()).ToUpperInvariant();
        if (s.Length == 13 && s.All(char.IsDigit) && IsValidEan13(s) && (s.StartsWith("978", StringComparison.Ordinal) || s.StartsWith("979", StringComparison.Ordinal))) return s;
        if (s.Length != 10 || !s[..9].All(char.IsDigit) || !(char.IsDigit(s[9]) || s[9] == 'X')) return null;
        var sum = 0;
        for (var i = 0; i < 10; i++) sum += (10 - i) * (s[i] == 'X' ? 10 : s[i] - '0');
        if (sum % 11 != 0) return null;
        var core = "978" + s[..9];
        return core + CheckDigit(core).ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>A number for an item that has no barcode: an EAN-13 in the range 200-299 that stores may use for their own goods ("in-store" numbers), from a counter.</summary>
    public static string InStore(long counter, string prefix = "200")
    {
        if (prefix.Length != 3 || !prefix.StartsWith('2')) throw new ArgumentException("In-store numbers start with 2.", nameof(prefix));
        var body = prefix + counter.ToString("D9", CultureInfo.InvariantCulture);
        if (body.Length != 12) throw new ArgumentOutOfRangeException(nameof(counter));
        return body + CheckDigit(body).ToString(CultureInfo.InvariantCulture);
    }
}
