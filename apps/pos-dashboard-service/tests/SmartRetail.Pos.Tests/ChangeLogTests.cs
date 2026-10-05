using System.Text.RegularExpressions;
using SmartRetail.Pos.Core.Updates;

namespace SmartRetail.Pos.Tests;

public sealed class ChangeLogTests
{
    private const string Sample = """
        # Change log

        Some words about the file, which belong to no release.

        ## 2.13.0 · 3 October 2026

        A sentence on the update,
        carried on a second line.

        ### New
        - **A lead-in.** What it does.
        - A second change, written over
          two lines.

        ### Fixed
        * A fix with a star.

        ## 2.8.0 · 29 September 2026

        Includes 2.7.0.

        ### Improved
        - Tidier.

        ## Notes

        ### New
        - Not a release.

        ## 1.0.0 · 2026-09-25
        ### New
        - First.
        ### Surprise
        - Not a kind of change.
        """;

    private static string Root()
    {
        var folder = new DirectoryInfo(AppContext.BaseDirectory);
        while (folder is not null && !(File.Exists(Path.Combine(folder.FullName, "CHANGELOG.md")) && Directory.Exists(Path.Combine(folder.FullName, "SmartRetailAI"))))
        {
            folder = folder.Parent;
        }

        return folder?.FullName ?? throw new DirectoryNotFoundException("The repository folder with CHANGELOG.md was not found above " + AppContext.BaseDirectory);
    }

    private static string BuiltVersion(string props) =>
        Regex.Match(File.ReadAllText(Path.Combine(Root(), props)), "<Version>([^<]+)</Version>").Groups[1].Value;

    [Fact]
    public void Each_release_has_its_number_day_sentence_and_changes_of_each_kind()
    {
        var releases = ChangeLog.Parse(Sample);

        Assert.Equal(new[] { "2.13.0", "2.8.0", "1.0.0" }, releases.Select(r => r.Version));
        var newest = releases[0];
        Assert.Equal(new DateOnly(2026, 10, 3), newest.Date);
        Assert.Equal("A sentence on the update, carried on a second line.", newest.Summary);
        Assert.Equal(new[] { ChangeKind.New, ChangeKind.Fixed }, newest.Sections.Select(s => s.Kind));
        Assert.Equal(new[] { "**A lead-in.** What it does.", "A second change, written over two lines." }, newest.Sections[0].Items);
        Assert.Equal(new[] { "A fix with a star." }, newest.Sections[1].Items);
        Assert.Equal(3, newest.Changes);
        Assert.Equal("", newest.Includes);
    }

    [Fact]
    public void A_version_that_came_inside_another_is_named_and_is_not_taken_for_the_sentence()
    {
        var release = ChangeLog.Parse(Sample)[1];

        Assert.Equal("2.7.0", release.Includes);
        Assert.Equal("", release.Summary);
        Assert.Equal(new DateOnly(2026, 9, 29), release.Date);
        Assert.Equal(new[] { "Tidier." }, Assert.Single(release.Sections).Items);
        Assert.Equal("2.5.0, 2.6.0", ChangeLog.Parse("## 2.6.1 · 28 September 2026\nIncludes 2.5.0,2.6.0.\n### New\n- x")[0].Includes);
    }

    [Fact]
    public void Other_headings_end_a_release_and_unknown_kinds_of_change_are_left_out()
    {
        var releases = ChangeLog.Parse(Sample);

        Assert.DoesNotContain(releases.SelectMany(r => r.Sections).SelectMany(s => s.Items), item => item.Contains("Not a release", StringComparison.Ordinal));
        var first = releases[2];
        Assert.Equal(new DateOnly(2026, 9, 25), first.Date);
        Assert.Equal(new[] { "First." }, Assert.Single(first.Sections).Items);
        Assert.Equal("", first.Summary);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   \n  ")]
    [InlineData("just some words\n- a bullet\n### New\n- another")]
    [InlineData("## not a version\n- x")]
    [InlineData("## 1.2 · 1 May 2026\n### New\n- two numbers is not a version")]
    [InlineData("## 1.2.3 · the day after tomorrow\n### New\n- a day that is not a day")]
    public void Reading_never_throws_and_leaves_out_what_does_not_fit(string? text)
    {
        var releases = ChangeLog.Parse(text);

        Assert.All(releases, release => Assert.Matches(@"^\d+\.\d+\.\d+$", release.Version));
        if (text?.StartsWith("## 1.2.3", StringComparison.Ordinal) == true)
        {
            Assert.Null(Assert.Single(releases).Date);
        }
    }

    [Fact]
    public void Versions_are_compared_as_numbers_and_what_has_not_been_seen_is_what_is_newer()
    {
        Assert.True(ChangeLog.IsNewer("2.13.0", "2.12.0"));
        Assert.True(ChangeLog.IsNewer("2.10.0", "2.9.0"), "ten is more than nine");
        Assert.False(ChangeLog.IsNewer("2.9.0", "2.10.0"));
        Assert.False(ChangeLog.IsNewer("2.9.0", "2.9.0"));
        Assert.False(ChangeLog.IsNewer("abc", "2.9.0"));
        Assert.False(ChangeLog.IsNewer("2.9.0", null));

        var releases = ChangeLog.Parse("## 2.10.0 · 1 May 2026\n### New\n- a\n## 2.9.0 · 1 April 2026\n### New\n- b\n## 2.8.0 · 1 March 2026\n### New\n- c");
        Assert.Equal(new[] { "2.10.0", "2.9.0" }, ChangeLog.Since(releases, "2.8.0").Select(r => r.Version));
        Assert.Empty(ChangeLog.Since(releases, "2.10.0"));
        Assert.Equal(3, ChangeLog.Since(releases, "").Count);
        Assert.Equal(3, ChangeLog.Since(releases, "nonsense").Count);
    }

    // ----- The real change log -----

    [Fact]
    public void The_change_log_of_the_project_is_whole_and_in_order()
    {
        var text = File.ReadAllText(Path.Combine(Root(), "CHANGELOG.md"));
        var releases = ChangeLog.Parse(text);

        Assert.True(releases.Count >= 24, "every release since 1.0.0 is in the log");
        Assert.Equal(releases.Count, releases.Select(r => r.Version).Distinct().Count());
        Assert.Equal(releases.Select(r => r.Version).OrderByDescending(v => Version.Parse(v)), releases.Select(r => r.Version));
        Assert.All(releases, release =>
        {
            Assert.True(release.Date is not null, $"{release.Version} has no day: write it as '## {release.Version} · 3 October 2026'");
            Assert.True(release.Changes > 0, $"{release.Version} lists no change");
            Assert.All(release.Sections.SelectMany(s => s.Items), item => Assert.False(string.IsNullOrWhiteSpace(item)));
        });

        // Newest first by day, too.
        Assert.Equal(releases.Select(r => r.Date!.Value).OrderByDescending(d => d), releases.Select(r => r.Date!.Value));

        // Every ### heading in the file is one of the three kinds, so no change is silently left out.
        var kinds = Regex.Matches(text, @"(?m)^###\s+(.+?)\s*$").Select(m => m.Groups[1].Value);
        Assert.All(kinds, kind => Assert.Contains(kind, new[] { "New", "Improved", "Fixed" }));
    }

    [Fact]
    public void The_newest_entry_is_the_version_the_code_is_built_as()
    {
        var newest = ChangeLog.Parse(File.ReadAllText(Path.Combine(Root(), "CHANGELOG.md")))[0].Version;

        // A release cannot go out without its entry: the log names what the app and the dashboard are built as.
        Assert.Equal(BuiltVersion("SmartRetailAI/Directory.Build.props"), newest);
        Assert.Equal(BuiltVersion("SmartRetailPOS/Directory.Build.props"), newest);
    }

    [Fact]
    public void The_newest_entry_says_in_a_sentence_what_the_update_is()
    {
        var newest = ChangeLog.Parse(File.ReadAllText(Path.Combine(Root(), "CHANGELOG.md")))[0];

        // The sentence is what the owner reads before installing (the update's notes), so it is short.
        Assert.False(string.IsNullOrWhiteSpace(newest.Summary), "write one sentence under the newest heading");
        Assert.True(newest.Summary.Length <= 300, $"the sentence is {newest.Summary.Length} letters; the update's notes take at most 300");
    }
}
