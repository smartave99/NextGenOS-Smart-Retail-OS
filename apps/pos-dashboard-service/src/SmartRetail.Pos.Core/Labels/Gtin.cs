using SmartRetail.Pos.Core.Models;

namespace SmartRetail.Pos.Core.Labels;

/// <summary>
/// The maker's barcodes (GTIN: EAN-8, UPC-A, EAN-13 and GTIN-14), which Amazon asks for when a product is listed: a
/// number of the right length whose last digit checks the others, outside the numbers GS1 keeps for shops' own stickers.
/// </summary>
public static class Gtin
{
    public static bool IsValid(string? code)
    {
        var digits = (code ?? "").Trim();
        if (digits.Length is not (8 or 12 or 13 or 14) || !digits.All(char.IsAsciiDigit))
        {
            return false;
        }

        // From the right, leaving out the check digit, the digits are weighed 3, 1, 3, 1…
        var sum = 0;
        var weight = 3;
        for (var i = digits.Length - 2; i >= 0; i--)
        {
            sum += (digits[i] - '0') * weight;
            weight = 4 - weight;
        }

        return (10 - sum % 10) % 10 == digits[^1] - '0';
    }

    /// <summary>
    /// A number GS1 keeps for shops' own stickers (restricted circulation: EAN-13 starting with 2, or 02 and 04; UPC-A
    /// starting with 2 or 4; EAN-8 starting with 0 or 2). It scans at the shop's till, but it is never a maker's barcode.
    /// </summary>
    public static bool IsInStore(string? code)
    {
        var d = (code ?? "").Trim();
        return IsValid(d) && d.Length switch
        {
            8 => d[0] is '0' or '2',
            12 => d[0] is '2' or '4',
            13 => d[0] == '2' || (d[0] == '0' && d[1] is '2' or '4'),
            _ => d[1] == '2' || (d[1] == '0' && d[2] is '2' or '4'),
        };
    }

    /// <summary>"EAN-13", "UPC-A"…, or null for a code that is not a maker's barcode (a shop's own code, even when it
    /// has the right number of digits, is not).</summary>
    public static string? Kind(string? code) => !IsValid(code) || IsInStore(code) ? null : code!.Trim().Length switch
    {
        8 => "EAN-8",
        12 => "UPC-A",
        13 => "EAN-13",
        _ => "GTIN-14",
    };

    /// <summary>
    /// The maker's barcode among a product's stock batches, the batch with the most stock first: one batch may carry the
    /// shop's own sticker and another the maker's, and a search for the same product elsewhere needs the maker's. Empty
    /// when no batch has one.
    /// </summary>
    public static string MakerCode(IEnumerable<StockBatch>? batches) => (batches ?? Enumerable.Empty<StockBatch>())
        .Where(batch => Kind(batch.Code) is not null)
        .OrderByDescending(batch => batch.Qty)
        .Select(batch => batch.Code.Trim())
        .FirstOrDefault() ?? "";
}
