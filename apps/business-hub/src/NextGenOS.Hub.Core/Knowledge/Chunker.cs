using System.Text;
using System.Text.RegularExpressions;

namespace NextGenOS.Hub.Knowledge;

/// <summary>
/// Cuts a note into short pieces so that a search can point at the part that matches. It keeps paragraphs together while they fit, cuts a long paragraph at the end of a sentence where it can
/// (at a space, or at the limit, where it cannot), and never makes a piece longer than <see cref="MaxChars"/>. It is a plain function of the text: the same text always gives the same pieces.
/// </summary>
public static partial class Chunker
{
    public const int MaxChars = 800;

    [GeneratedRegex(@"\n[ \t]*\n+", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 250)]
    private static partial Regex ParagraphBreak();

    public static IReadOnlyList<string> Split(string? text)
    {
        if (string.IsNullOrWhiteSpace(text)) return [];
        var paragraphs = ParagraphBreak().Split(text.Replace("\r\n", "\n", StringComparison.Ordinal).Replace('\r', '\n').Trim())
            .Select(p => string.Join(' ', p.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries)))
            .Where(p => p.Length > 0);

        var pieces = new List<string>();
        var current = new StringBuilder();
        foreach (var paragraph in paragraphs)
        {
            foreach (var part in Fit(paragraph))
            {
                if (current.Length > 0 && current.Length + 2 + part.Length > MaxChars)
                {
                    pieces.Add(current.ToString());
                    current.Clear();
                }

                if (current.Length > 0) current.Append("\n\n");
                current.Append(part);
            }
        }

        if (current.Length > 0) pieces.Add(current.ToString());
        return pieces;
    }

    /// <summary>One paragraph as parts of at most <see cref="MaxChars"/>: whole if it fits, else cut after a sentence, else at a space, else at the limit.</summary>
    private static IEnumerable<string> Fit(string paragraph)
    {
        var rest = paragraph;
        while (rest.Length > MaxChars)
        {
            var window = rest[..MaxChars];
            var cut = LastSentenceEnd(window);
            if (cut < MaxChars / 4) cut = window.LastIndexOf(' ');
            if (cut < MaxChars / 4) cut = MaxChars;
            yield return rest[..cut].Trim();
            rest = rest[cut..].TrimStart();
        }

        if (rest.Length > 0) yield return rest;
    }

    /// <summary>The place just after the last full stop, question mark or exclamation mark that is followed by a space, or 0 when there is none.</summary>
    private static int LastSentenceEnd(string window)
    {
        for (var i = window.Length - 2; i > 0; i--)
            if (window[i] is '.' or '!' or '?' && window[i + 1] == ' ') return i + 1;
        return 0;
    }
}
