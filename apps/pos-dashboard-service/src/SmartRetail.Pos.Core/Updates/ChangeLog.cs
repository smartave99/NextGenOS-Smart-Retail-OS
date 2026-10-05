using System.Globalization;
using System.Text.RegularExpressions;

namespace SmartRetail.Pos.Core.Updates;

/// <summary>The kinds of change an update lists, as the owner reads them.</summary>
public enum ChangeKind
{
    New,
    Improved,
    Fixed,
}

/// <summary>The changes of one kind in an update, each a sentence or two (plain words, with **bold** for a lead-in).</summary>
public sealed record ChangeSection(ChangeKind Kind, IReadOnlyList<string> Items);

/// <summary>One released version: its number, its day, a sentence on it, and what changed.</summary>
public sealed record ChangeRelease(string Version, DateOnly? Date, string Summary, IReadOnlyList<ChangeSection> Sections)
{
    public int Changes => Sections.Sum(section => section.Items.Count);

    /// <summary>Versions that were never released on their own and came inside this one ("Includes 1.6.0."), or empty.</summary>
    public string Includes { get; init; } = "";
}

/// <summary>
/// The change log (CHANGELOG.md): what changed in each update, newest first. Written in a fixed shape so the app can show it
/// and a release cannot go out without its entry:
/// <code>
/// ## 2.13.0 · 3 October 2026
/// A sentence on the update.
/// ### New
/// - **A lead-in.** What it does, in plain words.
/// ### Improved
/// ### Fixed
/// </code>
/// Reading never throws: a line that does not fit the shape is left out.
/// </summary>
public static partial class ChangeLog
{
    private static readonly string[] DateFormats = ["d MMMM yyyy", "d MMM yyyy", "yyyy-MM-dd"];

    [GeneratedRegex(@"^##\s+(\d{1,4}\.\d{1,4}\.\d{1,4})\s*(?:[·\-–—]\s*(.+?))?\s*$")]
    private static partial Regex ReleaseHeading();

    [GeneratedRegex(@"^###\s+(.+?)\s*$")]
    private static partial Regex SectionHeading();

    [GeneratedRegex(@"^Includes\s+(\d{1,4}\.\d{1,4}\.\d{1,4}(?:\s*,\s*\d{1,4}\.\d{1,4}\.\d{1,4})*)\.?\s*$")]
    private static partial Regex IncludesLine();

    /// <summary>The releases in the text, in the order written (newest first).</summary>
    public static IReadOnlyList<ChangeRelease> Parse(string? markdown)
    {
        var releases = new List<ChangeRelease>();
        if (string.IsNullOrWhiteSpace(markdown))
        {
            return releases;
        }

        string? version = null;
        DateOnly? date = null;
        var summary = new List<string>();
        var includes = "";
        var sections = new List<(ChangeKind Kind, List<string> Items)>();
        List<string>? items = null;

        void Finish()
        {
            if (version is not null)
            {
                releases.Add(new ChangeRelease(version, date, string.Join(' ', summary), sections.Select(s => new ChangeSection(s.Kind, s.Items)).ToList())
                {
                    Includes = includes,
                });
            }

            version = null;
            date = null;
            summary = new List<string>();
            includes = "";
            sections = new List<(ChangeKind, List<string>)>();
            items = null;
        }

        foreach (var raw in markdown.Replace("\r\n", "\n").Split('\n'))
        {
            var line = raw.TrimEnd();
            if (ReleaseHeading().Match(line) is { Success: true } heading)
            {
                Finish();
                version = heading.Groups[1].Value;
                date = DateOnly.TryParseExact(heading.Groups[2].Value.Trim(), DateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var day) ? day : null;
                continue;
            }

            if (line.StartsWith("## ", StringComparison.Ordinal) || line.StartsWith("# ", StringComparison.Ordinal))
            {
                // Another heading (the title, or notes that are not a release): what follows is not part of a release.
                Finish();
                continue;
            }

            if (version is null)
            {
                continue;
            }

            if (SectionHeading().Match(line) is { Success: true } section)
            {
                items = Enum.TryParse<ChangeKind>(section.Groups[1].Value, ignoreCase: true, out var kind) && Enum.IsDefined(kind)
                    ? NewSection(kind)
                    : null;
                continue;
            }

            var text = line.Trim();
            if (text.Length == 0)
            {
                continue;
            }

            if (text.StartsWith("- ", StringComparison.Ordinal) || text.StartsWith("* ", StringComparison.Ordinal))
            {
                items?.Add(text[2..].Trim());
            }
            else if (items is null)
            {
                if (IncludesLine().Match(text) is { Success: true } included)
                {
                    includes = included.Groups[1].Value.Replace(" ", "", StringComparison.Ordinal).Replace(",", ", ", StringComparison.Ordinal);
                }
                else if (sections.Count == 0)
                {
                    summary.Add(text);
                }
            }
            else if (items.Count > 0)
            {
                // A sentence carried on the next line.
                items[^1] += " " + text;
            }
        }

        Finish();
        return releases;

        List<string> NewSection(ChangeKind kind)
        {
            var added = new List<string>();
            sections.Add((kind, added));
            return added;
        }
    }

    /// <summary>True when version <paramref name="a"/> is newer than <paramref name="b"/>; false when either is not a version.</summary>
    public static bool IsNewer(string? a, string? b) =>
        Version.TryParse(a, out var left) && Version.TryParse(b, out var right) && left > right;

    /// <summary>The releases newer than <paramref name="seen"/> (all of them when it is not a version), newest first.</summary>
    public static IReadOnlyList<ChangeRelease> Since(IReadOnlyList<ChangeRelease> releases, string? seen) =>
        Version.TryParse(seen, out _) ? releases.Where(release => IsNewer(release.Version, seen)).ToList() : releases;
}
