using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>Runs a test only where bash can run the release scripts (Linux, and the release workflow).</summary>
    public sealed class BashFactAttribute : FactAttribute
    {
        public BashFactAttribute()
        {
            if (Environment.OSVersion.Platform != PlatformID.Unix)
            {
                Skip = "the release scripts run on Linux (bash)";
            }
            else if (!(Environment.GetEnvironmentVariable("PATH") ?? "").Split(':').Any(folder => folder.Length > 0 && File.Exists(Path.Combine(folder, "bash"))))
            {
                Skip = "needs bash";
            }
        }
    }

    /// <summary>
    /// A release is made under the version the code is built with, or an app that updated to it would still report the old
    /// number and be offered the same update again after every install. check-version.sh, which the release workflow runs before
    /// it builds anything, refuses any other version; and the two Directory.Build.props files of the code always agree.
    /// </summary>
    public sealed class CheckVersionScriptTests : IDisposable
    {
        private readonly TempFolder _tree = new TempFolder();

        public void Dispose() => _tree.Dispose();

        /// <summary>A change log whose newest entry is this version, with a change listed.</summary>
        private static string Log(string newest) =>
            "# Change log\n\n## " + newest + " · 3 October 2026\n\nWhat the update is.\n\n### New\n- A change.\n\n## 1.0.0 · 25 September 2026\n\n### New\n- First.\n";

        /// <summary>A copy of the two props files, the change log and the script, laid out as in the repository, with these versions.</summary>
        private string Tree(string appVersion, string dashboardVersion, string changeLog = null)
        {
            Directory.CreateDirectory(Path.Combine(_tree.Path, "SmartRetailAI"));
            Directory.CreateDirectory(Path.Combine(_tree.Path, "SmartRetailPOS"));
            File.WriteAllText(Path.Combine(_tree.Path, "SmartRetailAI", "Directory.Build.props"), Props(appVersion));
            File.WriteAllText(Path.Combine(_tree.Path, "SmartRetailPOS", "Directory.Build.props"), Props(dashboardVersion));
            File.WriteAllText(Path.Combine(_tree.Path, "CHANGELOG.md"), changeLog ?? Log(appVersion));
            var script = Path.Combine(_tree.Path, "SmartRetailAI", "check-version.sh");
            File.Copy(Path.Combine(Repository.Root(), "SmartRetailAI", "check-version.sh"), script, overwrite: true);
            File.Copy(Path.Combine(Repository.Root(), "SmartRetailAI", "changelog-entry.sh"), Path.Combine(_tree.Path, "SmartRetailAI", "changelog-entry.sh"), overwrite: true);
            return script;
        }

        private static string Props(string version) =>
            "<Project>\n  <PropertyGroup>\n    <Company>NextGenOS</Company>\n    <Version>" + version + "</Version>\n    <Deterministic>true</Deterministic>\n  </PropertyGroup>\n</Project>\n";

        private static (int ExitCode, string Output, string Error) Run(string script, string version)
        {
            var start = new ProcessStartInfo("bash") { RedirectStandardOutput = true, RedirectStandardError = true, UseShellExecute = false };
            start.ArgumentList.Add(script);
            start.ArgumentList.Add(version);
            using (var process = Process.Start(start))
            {
                var output = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();
                process.WaitForExit();
                return (process.ExitCode, output.Trim(), error.Trim());
            }
        }

        [BashFact]
        public void A_release_under_the_version_of_the_code_passes()
        {
            var (code, output, error) = Run(Tree("2.10.0", "2.10.0"), "2.10.0");

            Assert.Equal((0, "The release 2.10.0 is the version of the code, and CHANGELOG.md says what changed (1 change).", ""), (code, output, error));
        }

        [BashFact]
        public void A_release_needs_its_entry_as_the_newest_one_in_the_change_log()
        {
            // The owner reads that list in the app and in the release: the version must be its newest entry.
            var older = Run(Tree("2.10.0", "2.10.0", Log("2.9.0")), "2.10.0");
            Assert.Equal(1, older.ExitCode);
            Assert.Contains("the newest entry of CHANGELOG.md is 2.9.0: add '## 2.10.0 · <day>' with what changed", older.Error);

            var none = Run(Tree("2.10.0", "2.10.0", "# Change log\n\nNothing yet.\n"), "2.10.0");
            Assert.Equal(1, none.ExitCode);
            Assert.Contains("the newest entry of CHANGELOG.md is missing", none.Error);

            File.Delete(Path.Combine(_tree.Path, "CHANGELOG.md"));
            var missing = Run(Path.Combine(_tree.Path, "SmartRetailAI", "check-version.sh"), "2.10.0");
            Assert.Equal(1, missing.ExitCode);
            Assert.Contains("CHANGELOG.md is not there", missing.Error);
        }

        [BashFact]
        public void An_entry_that_lists_no_change_is_refused_and_several_are_counted()
        {
            var empty = Run(Tree("2.10.0", "2.10.0", "# Change log\n\n## 2.10.0 · 3 October 2026\n\nA sentence.\n\n## 1.0.0 · 25 September 2026\n\n### New\n- First.\n"), "2.10.0");
            Assert.Equal(1, empty.ExitCode);
            Assert.Contains("the entry for 2.10.0 in CHANGELOG.md lists no change", empty.Error);

            // Changes under the older entry do not count for this one.
            var many = Run(Tree("2.10.0", "2.10.0", "## 2.10.0 · 3 October 2026\n### New\n- One.\n* Two.\n### Fixed\n- Three.\n## 2.9.0 · 1 October 2026\n### New\n- Old.\n"), "2.10.0");
            Assert.Equal(0, many.ExitCode);
            Assert.Contains("(3 changes)", many.Output);
        }

        [BashFact]
        public void Any_other_version_is_refused_and_the_file_that_differs_is_named()
        {
            var script = Tree("2.10.0", "2.10.0");

            var typed = Run(script, "2.10.1");
            Assert.Equal(1, typed.ExitCode);
            Assert.Contains("asked for as 2.10.1, but SmartRetailAI/Directory.Build.props builds 2.10.0", typed.Error);

            // The two props files must agree with each other as well.
            var other = Run(Tree("2.10.0", "2.9.0"), "2.10.0");
            Assert.Equal(1, other.ExitCode);
            Assert.Contains("SmartRetailPOS/Directory.Build.props builds 2.9.0", other.Error);
        }

        [BashFact]
        public void A_props_file_that_is_missing_or_has_no_version_is_said()
        {
            var script = Tree("2.10.0", "2.10.0");
            File.WriteAllText(Path.Combine(_tree.Path, "SmartRetailPOS", "Directory.Build.props"), "<Project />\n");
            var none = Run(script, "2.10.0");
            Assert.Equal(1, none.ExitCode);
            Assert.Contains("SmartRetailPOS/Directory.Build.props builds no version", none.Error);

            File.Delete(Path.Combine(_tree.Path, "SmartRetailPOS", "Directory.Build.props"));
            var missing = Run(script, "2.10.0");
            Assert.Equal(1, missing.ExitCode);
            Assert.Contains("SmartRetailPOS/Directory.Build.props is not there", missing.Error);
        }

        [BashTheory]
        [InlineData("")]
        [InlineData("latest")]
        [InlineData("2.10")]
        [InlineData("2.10.0.1")]
        [InlineData("v2.10.0")]
        [InlineData("2.10.0; touch pwned")]
        [InlineData("$(touch pwned)")]
        public void Only_three_numbers_are_taken_as_a_version_and_nothing_else_is_run(string version)
        {
            var (code, _, error) = Run(Tree("2.10.0", "2.10.0"), version);

            Assert.Equal(2, code);
            Assert.Contains("the version must be three numbers", error);
            Assert.False(File.Exists(Path.Combine(_tree.Path, "pwned")));
            Assert.False(File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "pwned")));
        }

        [BashFact]
        public void The_real_code_has_one_version_in_both_props_files()
        {
            var root = Repository.Root();
            var version = System.Text.RegularExpressions.Regex.Match(
                File.ReadAllText(Path.Combine(root, "SmartRetailAI", "Directory.Build.props")), "<Version>([^<]+)</Version>").Groups[1].Value;

            var (code, output, error) = Run(Path.Combine(root, "SmartRetailAI", "check-version.sh"), version);

            Assert.True(code == 0, "SmartRetailAI and SmartRetailPOS build different versions, or CHANGELOG.md does not start with this version: " + error);
            Assert.StartsWith("The release " + version + " is the version of the code, and CHANGELOG.md says what changed (", output);
        }

        [Fact]
        public void The_release_workflow_checks_the_version_in_a_first_job_that_everything_waits_for_and_never_puts_the_input_in_the_script_text()
        {
            var workflow = File.ReadAllText(Path.Combine(Repository.Root(), ".github", "workflows", "installer.yml"));

            // The check is the only thing in the first job, and the Windows tests (which the installer job waits for) need that job.
            Assert.Matches(@"(?m)^jobs:\s*\n(\s*#.*\n)*  version:\s*\n    runs-on: ubuntu-latest\s*\n", workflow);
            Assert.Matches(@"(?m)^  test-on-windows:\s*\n    needs: version\s*\n", workflow);
            Assert.Matches(@"(?m)^  installer:\s*\n    needs: test-on-windows\s*\n", workflow);
            Assert.Equal(1, workflow.Split(new[] { "check-version.sh" }, StringSplitOptions.None).Length - 1);
            Assert.True(workflow.IndexOf("check-version.sh", StringComparison.Ordinal) < workflow.IndexOf("  test-on-windows:", StringComparison.Ordinal), "the check comes first");
            Assert.Contains("INPUT_VERSION: ${{ inputs.version }}", workflow);
            Assert.DoesNotContain("check-version.sh \"${{", workflow);
        }
    }

    /// <summary>
    /// What CHANGELOG.md says about a version, for the text of the GitHub Release and the notes the owner reads before installing an
    /// update (changelog-entry.sh, run by the release workflow).
    /// </summary>
    public sealed class ChangelogEntryScriptTests : IDisposable
    {
        private const string Log = "# Change log\n\nWords about the file.\n\n"
            + "## 2.1.10 · 10 October 2026\n\nThe tenth.\n\n### New\n- Ten.\n\n"
            + "## 2.1.1 · 3 October 2026\n\nThe first of the line.\nIt goes on.\n\n### New\n- **One.** Something.\n### Fixed\n- Two.\n\n"
            + "## 2.0.0 · 1 October 2026\n\nIncludes 1.9.0.\n\n### New\n- Old.\n";

        private readonly TempFolder _tree = new TempFolder();

        public void Dispose() => _tree.Dispose();

        private string Script(string changeLog = Log)
        {
            Directory.CreateDirectory(Path.Combine(_tree.Path, "SmartRetailAI"));
            File.WriteAllText(Path.Combine(_tree.Path, "CHANGELOG.md"), changeLog);
            var script = Path.Combine(_tree.Path, "SmartRetailAI", "changelog-entry.sh");
            File.Copy(Path.Combine(Repository.Root(), "SmartRetailAI", "changelog-entry.sh"), script, overwrite: true);
            return script;
        }

        private static (int ExitCode, string Output, string Error) Run(string script, params string[] arguments)
        {
            var start = new ProcessStartInfo("bash") { RedirectStandardOutput = true, RedirectStandardError = true, UseShellExecute = false };
            start.ArgumentList.Add(script);
            foreach (var argument in arguments)
            {
                start.ArgumentList.Add(argument);
            }

            using (var process = Process.Start(start))
            {
                var output = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();
                process.WaitForExit();
                return (process.ExitCode, output.Trim(), error.Trim());
            }
        }

        [BashFact]
        public void The_whole_entry_is_its_sentence_and_its_changes_and_nothing_of_the_others()
        {
            var (code, output, error) = Run(Script(), "2.1.1");

            Assert.Equal(0, code);
            Assert.Equal("", error);
            Assert.Equal("The first of the line.\nIt goes on.\n\n### New\n- **One.** Something.\n### Fixed\n- Two.", output.Replace("\r\n", "\n"));
        }

        [BashFact]
        public void A_version_is_matched_whole_so_2_1_1_never_finds_2_1_10()
        {
            Assert.Equal("The tenth.\n\n### New\n- Ten.", Run(Script(), "2.1.10").Output.Replace("\r\n", "\n"));
            Assert.Equal("The first of the line.", Run(Script(), "2.1.1", "--summary").Output);
            Assert.Equal("The tenth.", Run(Script(), "2.1.10", "--summary").Output);
        }

        [BashFact]
        public void The_sentence_alone_skips_the_includes_line_and_is_cut_at_300_letters()
        {
            Assert.Equal("", Run(Script(), "2.0.0", "--summary").Output);
            Assert.Equal("Includes 1.9.0.", Run(Script(), "2.0.0").Output.Split('\n')[0]);

            var long300 = new string('a', 320);
            var summary = Run(Script("## 3.0.0 · 1 October 2026\n\n" + long300 + "\n\n### New\n- x\n"), "3.0.0", "--summary").Output;
            Assert.Equal(300, summary.Length);
        }

        [BashFact]
        public void A_version_the_log_does_not_have_gives_nothing()
        {
            var (code, output, _) = Run(Script(), "9.9.9");

            Assert.Equal((0, ""), (code, output));
            Assert.Equal("", Run(Script(), "9.9.9", "--summary").Output);
        }

        [BashTheory]
        [InlineData("")]
        [InlineData("latest")]
        [InlineData("2.1")]
        [InlineData("2.1.1; touch pwned")]
        [InlineData("$(touch pwned)")]
        public void Only_three_numbers_are_taken_as_a_version_and_nothing_else_is_run(string version)
        {
            var (code, _, error) = Run(Script(), version);

            Assert.Equal(2, code);
            Assert.Contains("the version must be three numbers", error);
            Assert.False(File.Exists(Path.Combine(_tree.Path, "pwned")));
            Assert.False(File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "pwned")));
        }

        [BashFact]
        public void Only_the_summary_choice_is_known_and_a_missing_log_is_said()
        {
            var script = Script();
            var other = Run(script, "2.1.1", "--everything");
            Assert.Equal(2, other.ExitCode);
            Assert.Contains("the only choice is --summary", other.Error);

            File.Delete(Path.Combine(_tree.Path, "CHANGELOG.md"));
            var missing = Run(script, "2.1.1");
            Assert.Equal(1, missing.ExitCode);
            Assert.Contains("CHANGELOG.md is not there", missing.Error);
        }

        [BashFact]
        public void The_real_log_has_a_short_sentence_for_the_version_the_code_is_built_as()
        {
            var root = Repository.Root();
            var version = System.Text.RegularExpressions.Regex.Match(
                File.ReadAllText(Path.Combine(root, "SmartRetailAI", "Directory.Build.props")), "<Version>([^<]+)</Version>").Groups[1].Value;

            var (code, summary, _) = Run(Path.Combine(root, "SmartRetailAI", "changelog-entry.sh"), version, "--summary");

            Assert.Equal(0, code);
            Assert.True(summary.Length > 20 && summary.Length <= 300, "write one sentence under the newest heading of CHANGELOG.md: '" + summary + "'");
        }

        [Fact]
        public void The_release_workflow_makes_the_releases_text_and_the_notes_from_the_log()
        {
            var workflow = File.ReadAllText(Path.Combine(Repository.Root(), ".github", "workflows", "installer.yml"));

            // The text of the Release starts with the version's entry; no text of its own is typed in the publishing step.
            Assert.Contains("echo \"## What is new in $version\"", workflow);
            Assert.Contains("body_path: ${{ runner.temp }}/release-body.md", workflow);
            Assert.DoesNotContain("body: |", workflow);

            // The update's notes are what was typed, else the entry's sentence.
            Assert.Contains("if [ -z \"$NOTES\" ]; then", workflow);
            Assert.Contains("changelog-entry.sh \"$VERSION\" --summary", workflow);
            Assert.Contains("changelog-entry.sh \"$version\"", workflow);

            // A version, or notes, typed by a person are never put into the text of a script.
            Assert.DoesNotContain("changelog-entry.sh \"${{", workflow);
            Assert.Contains("RELEASE_VERSION: ${{ inputs.version != '' && inputs.version || github.ref_name }}", workflow);
        }
    }

    /// <summary>A theory that runs only where bash can run the release scripts.</summary>
    public sealed class BashTheoryAttribute : TheoryAttribute
    {
        public BashTheoryAttribute()
        {
            if (Environment.OSVersion.Platform != PlatformID.Unix)
            {
                Skip = "the release scripts run on Linux (bash)";
            }
        }
    }
}
