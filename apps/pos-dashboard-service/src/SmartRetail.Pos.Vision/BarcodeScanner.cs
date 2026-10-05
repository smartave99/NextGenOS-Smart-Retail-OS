using ZXing;
using ZXing.Common;

namespace SmartRetail.Pos.Vision;

/// <summary>A barcode read in a photo: its digits or text, and its kind, e.g. EAN_13.</summary>
public sealed record ScannedCode(string Text, string Format);

/// <summary>
/// Reads the barcodes in a photo, on this PC (ZXing.Net): the makers' EAN and UPC codes, and the Code 128 and Code 39
/// the shop's own stickers use. It looks hard, turned both ways and light on dark too, since a phone photo of a pack is
/// rarely straight.
/// </summary>
public static class BarcodeScanner
{
    private static readonly IList<BarcodeFormat> Formats = new[]
    {
        BarcodeFormat.EAN_13, BarcodeFormat.EAN_8, BarcodeFormat.UPC_A, BarcodeFormat.UPC_E,
        BarcodeFormat.CODE_128, BarcodeFormat.CODE_39, BarcodeFormat.ITF,
    };

    /// <summary>The codes found, each once; none when there are none.</summary>
    public static IReadOnlyList<ScannedCode> Read(VisionImage image)
    {
        ArgumentNullException.ThrowIfNull(image);
        var source = new RGBLuminanceSource(image.Rgba, image.Width, image.Height, RGBLuminanceSource.BitmapFormat.RGBA32);
        var reader = new BarcodeReaderGeneric
        {
            AutoRotate = true,
            Options = new DecodingOptions { TryHarder = true, TryInverted = true, PossibleFormats = Formats },
        };

        var results = reader.DecodeMultiple(source) ?? (reader.Decode(source) is { } one ? new[] { one } : Array.Empty<Result>());
        return results
            .Where(result => result?.Text is { Length: > 0 and <= 50 })
            .Select(result => new ScannedCode(result.Text.Trim(), result.BarcodeFormat.ToString()))
            .Where(code => code.Text.Length > 0 && code.Text.All(c => c >= ' ' && c <= '~'))
            .DistinctBy(code => code.Text)
            .ToList();
    }

    /// <summary>
    /// The ways a code may be kept in the POS: as read, and for a UPC-A also as the EAN-13 it is (a leading 0), and
    /// for an EAN-13 starting with 0 also as its UPC-A.
    /// </summary>
    public static IReadOnlyList<string> Forms(ScannedCode code)
    {
        ArgumentNullException.ThrowIfNull(code);
        var forms = new List<string> { code.Text };
        if (code.Text.Length == 12 && code.Text.All(char.IsAsciiDigit))
        {
            forms.Add("0" + code.Text);
        }
        else if (code.Text.Length == 13 && code.Text[0] == '0' && code.Text.All(char.IsAsciiDigit))
        {
            forms.Add(code.Text[1..]);
        }

        return forms;
    }
}
