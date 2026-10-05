using System.Globalization;
using System.Text;

namespace SmartRetail.Pos.Core.Labels;

/// <summary>
/// Code 128 barcodes, the kind every shop scanner reads and the POS's own stickers use. Numbers use code set C, two
/// digits a symbol, so the bars come out wide and scan easily (an odd last digit switches to set B); anything else
/// uses code set B (printable ASCII).
/// </summary>
public static class Code128
{
    /// <summary>As long as the POS's own barcode column; whether it fits a sticker is <see cref="Sticker.Fits"/>'s question.</summary>
    public const int MaxLength = 100;

    /// <summary>Blank modules kept on each side, so a scanner finds where the barcode starts.</summary>
    public const int QuietZone = 10;

    private const int CodeB = 100;
    private const int StartB = 104;
    private const int StartC = 105;
    private const int Stop = 106;

    // Bar, space, bar, space, bar, space widths of symbols 0 to 105; the stop symbol adds a final bar.
    private static readonly string[] Patterns =
    {
        "212222", "222122", "222221", "121223", "121322", "131222", "122213", "122312", "132212", "221213",
        "221312", "231212", "112232", "122132", "122231", "113222", "123122", "123221", "223211", "221132",
        "221231", "213212", "223112", "312131", "311222", "321122", "321221", "312212", "322112", "322211",
        "212123", "212321", "232121", "111323", "131123", "131321", "112313", "132113", "132311", "211313",
        "231113", "231311", "112133", "112331", "132131", "113123", "113321", "133121", "313121", "211331",
        "231131", "213113", "213311", "213131", "311123", "311321", "331121", "312113", "312311", "332111",
        "314111", "221411", "431111", "111224", "111422", "121124", "121421", "141122", "141221", "112214",
        "112412", "122114", "122411", "142112", "142211", "241211", "221114", "413111", "241112", "134111",
        "111242", "121142", "121241", "114212", "124112", "124211", "411212", "421112", "421211", "212141",
        "214121", "412121", "111143", "111341", "131141", "114113", "114311", "411113", "411311", "113141",
        "114131", "311141", "411131", "211412", "211214", "211232", "2331112",
    };

    /// <summary>True when <paramref name="text"/> can be printed: 1 to 100 printable ASCII characters.</summary>
    public static bool CanEncode(string? text) =>
        !string.IsNullOrEmpty(text) && text.Length <= MaxLength && text.All(c => c is >= ' ' and <= '~');

    /// <summary>The symbol values: start, data, check symbol, stop.</summary>
    public static IReadOnlyList<int> Symbols(string text)
    {
        if (!CanEncode(text))
        {
            throw new ArgumentException("A barcode takes 1 to 100 English letters, digits or signs.", nameof(text));
        }

        var symbols = new List<int>();
        if (text.Length >= 2 && text.All(char.IsAsciiDigit))
        {
            symbols.Add(StartC);
            var pairs = text.Length / 2 * 2;
            for (var i = 0; i < pairs; i += 2)
            {
                symbols.Add(int.Parse(text.AsSpan(i, 2), NumberStyles.None, CultureInfo.InvariantCulture));
            }

            if (pairs < text.Length)
            {
                symbols.Add(CodeB);
                symbols.Add(text[^1] - ' ');
            }
        }
        else
        {
            symbols.Add(StartB);
            symbols.AddRange(text.Select(c => c - ' '));
        }

        var check = symbols[0];
        for (var i = 1; i < symbols.Count; i++)
        {
            check += i * symbols[i];
        }

        symbols.Add(check % 103);
        symbols.Add(Stop);
        return symbols;
    }

    /// <summary>The widths of the bars and spaces in turn, starting with a bar, in modules.</summary>
    public static IReadOnlyList<int> Widths(string text) =>
        Symbols(text).SelectMany(symbol => Patterns[symbol]).Select(c => c - '0').ToList();

    /// <summary>The barcode's width in modules, quiet zones included.</summary>
    public static int Width(string text) => Widths(text).Sum() + 2 * QuietZone;

    /// <summary>
    /// The bars as an SVG path in a box <see cref="Width(string)"/> modules wide and 1 high, with a quiet zone of
    /// ten modules on each side. Draw it with <c>preserveAspectRatio="none"</c> at any height.
    /// </summary>
    public static (string Path, int Width) SvgPath(string text)
    {
        var path = new StringBuilder();
        var x = QuietZone;
        var bar = true;
        foreach (var width in Widths(text))
        {
            if (bar)
            {
                path.Append('M').Append(x.ToString(CultureInfo.InvariantCulture)).Append(" 0h")
                    .Append(width.ToString(CultureInfo.InvariantCulture)).Append("v1h-")
                    .Append(width.ToString(CultureInfo.InvariantCulture)).Append('z');
            }

            x += width;
            bar = !bar;
        }

        return (path.ToString(), x + QuietZone);
    }
}
