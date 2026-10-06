using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Providers;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>Keeping Codex up to date: the versions, the release feed, the gate, the command line the app needs, and the updater.</summary>
    public class CodexUpdateTests : IDisposable
    {
        private readonly TempFolder _folder = new TempFolder();

        public void Dispose() => _folder.Dispose();

        // ---- versions

        [Theory]
        [InlineData("codex-cli 0.158.0", "0.158.0", false)]
        [InlineData("codex 0.158.0\n", "0.158.0", false)]
        [InlineData("codex-cli 0.160.0-alpha.3", "0.160.0", true)]
        [InlineData("codex-cli 0.160.0-beta.1", "0.160.0", true)]
        [InlineData("WARNING: proxy set\ncodex-cli 1.2.30", "1.2.30", false)]
        [InlineData("codex-cli 0.158", null, false)]
        [InlineData("", null, false)]
        [InlineData(null, null, false)]
        public void The_version_is_read_from_what_codex_prints(string printed, string version, bool prerelease)
        {
            var parsed = CodexVersions.Installed(printed, out var pre);

            Assert.Equal(version, parsed?.ToString());
            Assert.Equal(prerelease, pre);
        }

        [Theory]
        [InlineData("rust-v0.159.0", "0.159.0")]
        [InlineData(" rust-v10.2.3 ", "10.2.3")]
        [InlineData("rust-v0.160.0-alpha.1", null)]
        [InlineData("rust-v0.160.0-beta.2", null)]
        [InlineData("v0.159.0", null)]
        [InlineData("0.159.0", null)]
        [InlineData("latest", null)]
        [InlineData("rust-v0.159", null)]
        [InlineData("", null)]
        [InlineData(null, null)]
        public void Only_a_stable_release_tag_is_a_release(string tag, string version) =>
            Assert.Equal(version, CodexVersions.OfTag(tag)?.ToString());

        [Theory]
        [InlineData("0.159.0", "codex-cli 0.158.0", true)]
        [InlineData("0.159.0", "codex-cli 0.159.0", false)]
        [InlineData("0.159.0", "codex-cli 0.160.0", false)]
        [InlineData("0.159.0", "codex-cli 0.159.0-alpha.2", true)]
        [InlineData("0.159.0", "codex-cli 0.160.0-alpha.2", false)]
        [InlineData("0.159.0", "nothing", false)]
        [InlineData("0.159.0", null, false)]
        public void A_release_is_newer_only_when_it_really_is(string latest, string printed, bool newer) =>
            Assert.Equal(newer, CodexVersions.IsNewer(Version.Parse(latest), printed));

        [Fact]
        public void No_release_is_never_newer()
        {
            Assert.False(CodexVersions.IsNewer(null, "codex-cli 0.1.0"));
            Assert.Equal("", CodexVersions.ForInstaller(null));
            Assert.Equal("0.158.0", CodexVersions.ForInstaller(new Version(0, 158, 0)));
        }

        // ---- the release feed

        private static string Channel(string tag) => "{\"assets\":[{\"name\":\"codex\",\"digest\":\"sha256:00\"}],\"tag_name\":" + (tag == null ? "null" : "\"" + tag + "\"") + "}";

        private static CodexReleaseFeed Feed(RoutedHttpHandler web) => new CodexReleaseFeed(new HttpClient(web), "https://releases.example.com/codex/channels/latest", "https://api.example.com/releases/latest");

        [Fact]
        public async Task The_release_channel_says_which_codex_is_newest()
        {
            var web = new RoutedHttpHandler().On("/codex/channels/latest", Channel("rust-v0.159.0"));

            Assert.Equal(new Version(0, 159, 0), await Feed(web).LatestAsync(CancellationToken.None));
            Assert.Equal(new[] { "releases.example.com" }, web.Asked.Select(u => u.Host).Distinct());
        }

        [Fact]
        public async Task GitHub_is_asked_when_the_channel_does_not_answer_or_is_not_a_release_and_nothing_when_neither_is()
        {
            var github = new RoutedHttpHandler().On("/releases/latest", Channel("rust-v0.158.0"));
            Assert.Equal(new Version(0, 158, 0), await Feed(github).LatestAsync(CancellationToken.None));

            var alpha = new RoutedHttpHandler().On("/codex/channels/latest", Channel("rust-v0.160.0-alpha.1")).On("/releases/latest", Channel("rust-v0.158.0"));
            Assert.Equal(new Version(0, 158, 0), await Feed(alpha).LatestAsync(CancellationToken.None));

            Assert.Null(await Feed(new RoutedHttpHandler()).LatestAsync(CancellationToken.None));
            Assert.Null(await Feed(new RoutedHttpHandler().On("/codex/channels/latest", "not json").On("/releases/latest", "[]")).LatestAsync(CancellationToken.None));
            Assert.Null(await Feed(new RoutedHttpHandler().On("/codex/channels/latest", Channel(null)).On("/releases/latest", Channel(null))).LatestAsync(CancellationToken.None));
        }

        [Fact]
        public async Task An_answer_that_came_over_http_or_is_far_too_big_is_not_a_release()
        {
            var plain = new RoutedHttpHandler().On("/codex/channels/latest", Channel("rust-v0.159.0"))
                .Redirected("/codex/channels/latest", "http://releases.example.com/codex/channels/latest");
            Assert.Null(await Feed(plain).LatestAsync(CancellationToken.None));

            var huge = new RoutedHttpHandler().On("/codex/channels/latest", "{\"tag_name\":\"rust-v0.159.0\",\"x\":\"" + new string('a', 3 * 1024 * 1024) + "\"}");
            Assert.Null(await Feed(huge).LatestAsync(CancellationToken.None));
        }

        // ---- the gate

        [Fact]
        public async Task The_gate_closes_only_when_no_run_is_going_and_holds_new_runs_until_it_opens()
        {
            var gate = new AiRunGate();
            var first = await gate.EnterAsync(CancellationToken.None);
            Assert.Equal(1, gate.Running);
            Assert.False(gate.TryClose(), "a run is going: the gate stays open, nothing changed");
            Assert.False(gate.IsClosed);

            first.Dispose();
            first.Dispose();
            Assert.Equal(0, gate.Running);
            Assert.True(gate.TryClose());
            Assert.False(gate.TryClose(), "it is closed already");

            var waiting = gate.EnterAsync(CancellationToken.None);
            await Task.Delay(50);
            Assert.False(waiting.IsCompleted, "a run that asks while it is closed waits");
            Assert.Equal(0, gate.Running);

            gate.Open();
            using (await waiting)
            {
                Assert.Equal(1, gate.Running);
            }

            Assert.Equal(0, gate.Running);
        }

        [Fact]
        public async Task A_run_that_waits_at_a_closed_gate_can_be_cancelled()
        {
            var gate = new AiRunGate();
            Assert.True(gate.TryClose());
            using (var cancel = new CancellationTokenSource())
            {
                var waiting = gate.EnterAsync(cancel.Token);
                cancel.Cancel();

                await Assert.ThrowsAnyAsync<OperationCanceledException>(() => waiting);
            }

            Assert.Equal(0, gate.Running);
            gate.Open();
            gate.Open();
            Assert.False(gate.IsClosed);
        }

        private sealed class FakeRunner : ICliRunner
        {
            public int InFlight;
            public int MostAtOnce;
            public TaskCompletionSource<bool> Release = new TaskCompletionSource<bool>();

            public async Task<CliResult> RunAsync(CliInvocation invocation, CancellationToken cancellationToken)
            {
                var now = Interlocked.Increment(ref InFlight);
                MostAtOnce = Math.Max(MostAtOnce, now);
                await Release.Task;
                Interlocked.Decrement(ref InFlight);
                return new CliResult();
            }
        }

        [Fact]
        public async Task A_run_through_the_gated_runner_counts_as_going_until_it_ends()
        {
            var gate = new AiRunGate();
            var inner = new FakeRunner();
            var runner = new GatedCliRunner(inner, gate);

            var run = runner.RunAsync(new CliInvocation(), CancellationToken.None);
            await Task.Delay(50);
            Assert.Equal(1, gate.Running);
            Assert.False(gate.TryClose());

            inner.Release.SetResult(true);
            await run;
            Assert.Equal(0, gate.Running);
            Assert.True(gate.TryClose());
        }

        // ---- the command line the app needs

        private static string TopHelp(bool search = true) =>
            "Codex CLI\n\nUsage: codex [OPTIONS] [PROMPT]\n       codex [OPTIONS] <COMMAND>\n\nCommands:\n  exec        Run Codex non-interactively [aliases: e]\n  login       Manage login\n  app-server  Run the app server\n  mcp         Run as MCP\n\nOptions:\n  -m, --model <MODEL>\n" + (search ? "      --search   Enable live web search\n" : "");

        private static string ExecHelp(params string[] without)
        {
            var flags = new[] { "--image", "--skip-git-repo-check", "--ephemeral", "--sandbox", "--color", "--cd", "--output-last-message", "--output-schema", "--model", "--config", "--enable" };
            return "Run Codex non-interactively\n\nOptions:\n" + string.Concat(flags.Where(flag => !without.Contains(flag)).Select(flag => "      " + flag + " <VALUE>  something\n"));
        }

        private static string LoginHelp(bool status = true) =>
            "Manage login\n\nUsage: codex login [OPTIONS] [COMMAND]\n\nCommands:\n" + (status ? "  status  Show login status\n" : "") + "\nOptions:\n      --device-auth\n      --with-api-key\n";

        [Fact]
        public void The_help_of_a_codex_that_has_everything_shows_everything_the_app_uses()
        {
            var seen = CodexCompatibility.Visible(new CodexHelp(TopHelp(), ExecHelp(), LoginHelp()));

            Assert.Equal(CodexCompatibility.Required().OrderBy(x => x, StringComparer.Ordinal), seen.OrderBy(x => x, StringComparer.Ordinal));
        }

        [Fact]
        public void What_an_update_took_away_or_renamed_is_found_and_what_was_never_listed_is_not_asked_for()
        {
            var before = new CodexHelp(TopHelp(), ExecHelp(), LoginHelp());

            var renamed = new CodexHelp(TopHelp(), ExecHelp("--output-schema", "--enable").Replace("--model <VALUE>", "--model-name <VALUE>"), LoginHelp(status: false));
            Assert.Equal(new[] { "exec --enable", "exec --model", "exec --output-schema", "login status" }, CodexCompatibility.Lost(before, renamed));

            // A flag the working Codex did not list (hidden) is not missed after an update either.
            var hiddenBefore = new CodexHelp(TopHelp(search: false), ExecHelp("--enable"), LoginHelp());
            var hiddenAfter = new CodexHelp(TopHelp(search: false), ExecHelp("--enable"), LoginHelp());
            Assert.Empty(CodexCompatibility.Lost(hiddenBefore, hiddenAfter));

            // Nothing lost when nothing changed, and a new flag is no loss.
            Assert.Empty(CodexCompatibility.Lost(before, before));
            Assert.Empty(CodexCompatibility.Lost(before, new CodexHelp(TopHelp() + "      --new-thing\n", ExecHelp() + "      --another\n", LoginHelp())));
        }

        [Fact]
        public void A_word_inside_a_longer_one_is_not_the_flag()
        {
            var help = new CodexHelp(TopHelp(), ExecHelp("--model").Replace("--sandbox", "--sandbox-mode-extra --sandboxed"), LoginHelp());

            var seen = CodexCompatibility.Visible(help);

            Assert.DoesNotContain("exec --model", seen);
            Assert.DoesNotContain("exec --sandbox", seen);
            Assert.Contains("exec --cd", seen);
        }

        [Fact]
        public void Every_flag_the_provider_uses_is_on_the_list_of_what_an_update_must_keep()
        {
            var source = File.ReadAllText(Path.Combine(Repo("SmartRetailAI"), "src", "SmartRetail.AI.Core", "Providers", "CodexCliProvider.cs"));
            var used = new HashSet<string>(System.Text.RegularExpressions.Regex.Matches(source, "\"(--[a-z][a-z-]*)\"").Cast<System.Text.RegularExpressions.Match>().Select(m => m.Groups[1].Value));

            var known = new HashSet<string>(CodexCompatibility.TopFlags.Concat(CodexCompatibility.ExecFlags).Concat(CodexCompatibility.LoginParts.Where(part => part.StartsWith("--", StringComparison.Ordinal))));
            var missing = used.Where(flag => !known.Contains(flag)).OrderBy(flag => flag, StringComparer.Ordinal).ToList();
            Assert.True(missing.Count == 0, "CodexCompatibility does not list: " + string.Join(", ", missing));
        }

        private static string Repo(string folderName)
        {
            for (var folder = new DirectoryInfo(AppContext.BaseDirectory); folder != null; folder = folder.Parent)
            {
                if ((folder.Name == folderName || (folderName == "SmartRetailAI" && folder.Name == "pos-ai-companion")) && Directory.Exists(Path.Combine(folder.FullName, "src")))
                {
                    return folder.FullName;
                }
            }

            throw new DirectoryNotFoundException(folderName + " was not found above " + AppContext.BaseDirectory);
        }

        // ---- the updater

        private sealed class FakeTool : ICodexTool
        {
            public string Printed = "codex-cli 0.158.0";
            public string InstalledByUpdate = "codex-cli 0.159.0";
            public CodexHelp Before = new CodexHelp(TopHelp(), ExecHelp(), LoginHelp());
            public CodexHelp After = new CodexHelp(TopHelp(), ExecHelp(), LoginHelp());
            public bool? SignedIn = true;
            public bool? SignedInWithNewCodex = true;
            public bool? SignedInAfterPutBack = true;
            public bool Managed = true;
            public bool InstallFails;
            public bool RollbackFails;
            public bool UpdateChangesNothing;
            public readonly List<string> Installs = new List<string>();
            public Func<bool> DuringInstall = () => true;

            public Task<string> VersionAsync(CancellationToken cancellationToken) => Task.FromResult(Printed);

            public Task<CodexHelp> HelpAsync(CancellationToken cancellationToken) => Task.FromResult(Printed != null && Printed.Contains("0.158") ? Before : After);

            public Task<bool?> SignedInAsync(CancellationToken cancellationToken)
            {
                if (Installs.Count == 0)
                {
                    return Task.FromResult(SignedIn);
                }

                return Task.FromResult(Installs.Last().Length == 0 ? SignedInWithNewCodex : SignedInAfterPutBack);
            }

            public bool IsInstallerManaged() => Managed;

            public Task InstallAsync(string release, Action<string> progress, CancellationToken cancellationToken)
            {
                Installs.Add(release);
                DuringInstall();
                progress?.Invoke("Downloading Codex CLI");
                if (release.Length == 0)
                {
                    if (InstallFails)
                    {
                        throw new InvalidOperationException("Codex could not be installed: releases.openai.com is not reachable.");
                    }

                    if (!UpdateChangesNothing)
                    {
                        Printed = InstalledByUpdate;
                    }
                }
                else
                {
                    if (RollbackFails)
                    {
                        throw new InvalidOperationException("disk full");
                    }

                    Printed = "codex-cli " + release;
                }

                return Task.CompletedTask;
            }
        }

        private sealed class FakeReleases : ICodexReleases
        {
            public Version Latest = new Version(0, 159, 0);

            /// <summary>Something that happens while OpenAI is being asked, which takes seconds.</summary>
            public Action OnAsked = () => { };

            public Task<Version> LatestAsync(CancellationToken cancellationToken)
            {
                OnAsked();
                return Task.FromResult(Latest);
            }
        }

        private DateTime _now = new DateTime(2026, 9, 29, 12, 0, 0);

        private (CodexUpdater Updater, FakeTool Tool, FakeReleases Releases, AiRunGate Gate, CodexUpdateFile File) Make()
        {
            var tool = new FakeTool();
            var releases = new FakeReleases();
            var gate = new AiRunGate();
            var file = new CodexUpdateFile(_folder.Path);
            return (new CodexUpdater(tool, releases, gate, file, () => _now), tool, releases, gate, file);
        }

        /// <summary>The updater has seen the newest release long enough ago for it to be installed by itself.</summary>
        private async Task Settled(CodexUpdater updater)
        {
            await updater.CheckAsync(CancellationToken.None);
            _now += CodexUpdater.Settle + TimeSpan.FromMinutes(1);
        }

        [Fact]
        public async Task A_codex_that_is_not_installed_is_left_to_Get_started_and_the_newest_one_is_up_to_date()
        {
            var (updater, tool, releases, _, _) = Make();
            tool.Printed = null;
            Assert.Equal(CodexUpdateOutcome.NotInstalled, (await updater.UpdateAsync(true, null, CancellationToken.None)).Outcome);
            Assert.Empty(tool.Installs);

            tool.Printed = "codex-cli 0.159.0";
            var current = await updater.CheckAsync(CancellationToken.None);
            Assert.Equal((CodexUpdateOutcome.UpToDate, "0.159.0", "0.159.0"), (current.Outcome, current.Installed, current.Latest));
            Assert.Equal(_now, updater.State.CheckedAt);

            releases.Latest = null;
            var unknown = await updater.CheckAsync(CancellationToken.None);
            Assert.Equal(CodexUpdateOutcome.Unknown, unknown.Outcome);
            Assert.Equal("0.159.0", updater.State.SeenVersion);

            tool.Printed = "codex-cli nothing to read";
            releases.Latest = new Version(0, 159, 0);
            Assert.Equal(CodexUpdateOutcome.Unknown, (await updater.CheckAsync(CancellationToken.None)).Outcome);
        }

        [Fact]
        public async Task A_newer_codex_is_reported_and_only_installed_when_asked_to()
        {
            var (updater, tool, _, _, _) = Make();

            var check = await updater.CheckAsync(CancellationToken.None);

            Assert.Equal((CodexUpdateOutcome.Available, "0.158.0", "0.159.0"), (check.Outcome, check.Installed, check.Latest));
            Assert.Empty(tool.Installs);
        }

        [Fact]
        public async Task A_release_that_came_out_a_moment_ago_settles_for_a_day_before_it_is_installed_by_itself()
        {
            var (updater, tool, releases, _, _) = Make();

            var first = await updater.UpdateAsync(false, null, CancellationToken.None);
            Assert.Equal(CodexUpdateOutcome.Settling, first.Outcome);
            Assert.Contains("after a day, or now if you choose Update now", first.Message);
            Assert.Empty(tool.Installs);
            Assert.Equal(("0.159.0", _now), (updater.State.SeenVersion, updater.State.SeenAt.Value));

            _now += TimeSpan.FromHours(23);
            Assert.Equal(CodexUpdateOutcome.Settling, (await updater.UpdateAsync(false, null, CancellationToken.None)).Outcome);
            Assert.Empty(tool.Installs);

            // A still newer release starts the day again.
            releases.Latest = new Version(0, 160, 0);
            tool.InstalledByUpdate = "codex-cli 0.160.0";
            _now += TimeSpan.FromHours(2);
            Assert.Equal(CodexUpdateOutcome.Settling, (await updater.UpdateAsync(false, null, CancellationToken.None)).Outcome);
            Assert.Equal("0.160.0", updater.State.SeenVersion);

            _now += CodexUpdater.Settle;
            var result = await updater.UpdateAsync(false, null, CancellationToken.None);
            Assert.Equal((CodexUpdateOutcome.Updated, "0.160.0"), (result.Outcome, result.Installed));
        }

        [Fact]
        public async Task The_caller_is_told_when_the_replacing_really_begins_and_not_before()
        {
            var (updater, tool, releases, gate, _) = Make();
            var told = 0;
            tool.DuringInstall = () =>
            {
                Assert.Equal(1, told);
                return true;
            };

            // Settling: nothing to replace yet.
            await updater.UpdateAsync(false, null, CancellationToken.None, () => told++);
            Assert.Equal(0, told);

            // An AI task is running: it waits.
            using (await gate.EnterAsync(CancellationToken.None))
            {
                await updater.UpdateAsync(true, null, CancellationToken.None, () => told++);
                Assert.Equal(0, told);
            }

            // Up to date: nothing to replace.
            releases.Latest = new Version(0, 158, 0);
            await updater.UpdateAsync(true, null, CancellationToken.None, () => told++);
            Assert.Equal(0, told);

            releases.Latest = new Version(0, 159, 0);
            Assert.Equal(CodexUpdateOutcome.Updated, (await updater.UpdateAsync(true, null, CancellationToken.None, () => told++)).Outcome);
            Assert.Equal(1, told);
        }

        [Fact]
        public async Task The_owner_can_install_a_release_at_once()
        {
            var (updater, tool, _, _, _) = Make();

            var result = await updater.UpdateAsync(true, null, CancellationToken.None);

            Assert.Equal(CodexUpdateOutcome.Updated, result.Outcome);
            Assert.Equal(new[] { "" }, tool.Installs);
        }

        [Fact]
        public async Task An_update_replaces_codex_when_it_is_quiet_and_the_new_one_still_has_everything()
        {
            var (updater, tool, _, gate, _) = Make();
            var lines = new List<string>();
            tool.DuringInstall = () =>
            {
                Assert.True(gate.IsClosed, "new AI tasks wait while Codex is replaced");
                return true;
            };
            await Settled(updater);

            var result = await updater.UpdateAsync(false, lines.Add, CancellationToken.None);

            Assert.Equal((CodexUpdateOutcome.Updated, "0.159.0", "0.158.0"), (result.Outcome, result.Installed, result.Previous));
            Assert.Equal(new[] { "" }, tool.Installs);
            Assert.Equal(new[] { "Downloading Codex CLI" }, lines);
            Assert.False(gate.IsClosed, "and go on afterwards");
            var state = updater.State;
            Assert.Equal(("0.159.0", "0.158.0", "", _now), (state.UpdatedTo, state.UpdatedFrom, state.Problem, state.UpdatedAt.Value));
        }

        [Fact]
        public async Task An_update_waits_while_an_AI_task_is_running_and_touches_nothing()
        {
            var (updater, tool, _, gate, _) = Make();
            await Settled(updater);
            using (await gate.EnterAsync(CancellationToken.None))
            {
                var result = await updater.UpdateAsync(false, null, CancellationToken.None);

                Assert.Equal(CodexUpdateOutcome.Waiting, result.Outcome);
                Assert.Empty(tool.Installs);
                Assert.False(gate.IsClosed);
            }

            Assert.Equal(CodexUpdateOutcome.Updated, (await updater.UpdateAsync(false, null, CancellationToken.None)).Outcome);
        }

        [Fact]
        public async Task A_newer_codex_that_lacks_what_the_app_uses_is_taken_off_and_the_one_that_worked_is_put_back_and_skipped()
        {
            var (updater, tool, releases, gate, file) = Make();
            tool.After = new CodexHelp(TopHelp(), ExecHelp("--output-schema"), LoginHelp());
            await Settled(updater);

            var result = await updater.UpdateAsync(false, null, CancellationToken.None);

            Assert.Equal(CodexUpdateOutcome.RolledBack, result.Outcome);
            Assert.Equal(new[] { "", "0.158.0" }, tool.Installs);
            Assert.Equal("codex-cli 0.158.0", tool.Printed);
            Assert.Contains("no longer has exec --output-schema", result.Message);
            Assert.Contains("Codex 0.158.0 was put back", result.Message);
            Assert.Equal("0.159.0", file.Load().SkippedVersion);
            Assert.False(gate.IsClosed);

            // Not tried again until a newer one comes, unless the owner asks.
            tool.Installs.Clear();
            Assert.Equal(CodexUpdateOutcome.Skipped, (await updater.UpdateAsync(false, null, CancellationToken.None)).Outcome);
            Assert.Empty(tool.Installs);
            releases.Latest = new Version(0, 160, 0);
            tool.InstalledByUpdate = "codex-cli 0.160.0";
            tool.After = new CodexHelp(TopHelp(), ExecHelp(), LoginHelp());
            await Settled(updater);
            Assert.Equal(CodexUpdateOutcome.Updated, (await updater.UpdateAsync(false, null, CancellationToken.None)).Outcome);
            Assert.Equal("", file.Load().SkippedVersion);
        }

        [Fact]
        public async Task A_newer_codex_that_is_not_signed_in_any_more_is_taken_off_too()
        {
            var (updater, tool, _, _, file) = Make();
            tool.SignedInWithNewCodex = false;

            var result = await updater.UpdateAsync(true, null, CancellationToken.None);

            Assert.Equal(CodexUpdateOutcome.RolledBack, result.Outcome);
            Assert.Equal(new[] { "", "0.158.0" }, tool.Installs);
            Assert.StartsWith("Codex 0.159.0 is not signed in any more, so Codex 0.158.0 was put back.", result.Message);
            Assert.Equal("0.159.0", file.Load().SkippedVersion);

            // A missing flag and the lost sign-in are both said.
            var (other, otherTool, _, _, _) = Make();
            otherTool.After = new CodexHelp(TopHelp(), ExecHelp("--sandbox"), LoginHelp());
            otherTool.SignedInWithNewCodex = null;
            var both = await other.UpdateAsync(true, null, CancellationToken.None);
            Assert.StartsWith("Codex 0.159.0 no longer has exec --sandbox, which this app needs, and is not signed in any more, so Codex 0.158.0 was put back.", both.Message);
        }

        [Fact]
        public async Task A_codex_that_was_not_signed_in_before_is_not_blamed_for_it()
        {
            var (updater, tool, _, _, _) = Make();
            tool.SignedIn = false;
            tool.SignedInWithNewCodex = false;

            Assert.Equal(CodexUpdateOutcome.Updated, (await updater.UpdateAsync(true, null, CancellationToken.None)).Outcome);
        }

        [Fact]
        public async Task When_the_sign_in_is_gone_after_the_old_codex_is_put_back_that_is_told_and_the_version_is_skipped()
        {
            var (updater, tool, _, _, file) = Make();
            tool.SignedInWithNewCodex = false;
            tool.SignedInAfterPutBack = false;

            var result = await updater.UpdateAsync(true, null, CancellationToken.None);

            Assert.Equal(CodexUpdateOutcome.Failed, result.Outcome);
            Assert.Contains("is not signed in either after it was put back: sign in again on the Get started page.", result.Message);
            Assert.Equal("0.159.0", file.Load().SkippedVersion);
        }

        [Fact]
        public async Task A_codex_the_installer_did_not_put_there_is_left_to_be_updated_the_way_it_came()
        {
            var (updater, tool, _, _, _) = Make();
            tool.Managed = false;

            var check = await updater.CheckAsync(CancellationToken.None);
            Assert.Equal(CodexUpdateOutcome.Manual, check.Outcome);
            Assert.Contains("was not put here by OpenAI's installer, so it is updated the way it was installed (for example with npm)", check.Message);

            var result = await updater.UpdateAsync(true, null, CancellationToken.None);
            Assert.Equal(CodexUpdateOutcome.Manual, result.Outcome);
            Assert.Empty(tool.Installs);

            tool.Printed = "codex-cli 0.159.0";
            Assert.Equal(CodexUpdateOutcome.UpToDate, (await updater.CheckAsync(CancellationToken.None)).Outcome);
        }

        [Fact]
        public async Task Without_the_help_of_the_working_codex_nothing_is_tried()
        {
            var (updater, tool, _, gate, file) = Make();
            tool.Before = new CodexHelp("", "", "");

            var result = await updater.UpdateAsync(true, null, CancellationToken.None);

            Assert.Equal(CodexUpdateOutcome.Failed, result.Outcome);
            Assert.StartsWith("Codex did not show its own help, so it could not be checked that a newer Codex still fits this app. Codex 0.158.0 stays.", result.Message);
            Assert.Empty(tool.Installs);
            Assert.False(gate.IsClosed);
            Assert.Equal(result.Message, file.Load().Problem);
        }

        [Fact]
        public async Task The_owner_can_have_a_skipped_version_tried_again()
        {
            var (updater, tool, _, _, file) = Make();
            file.Save(new CodexUpdateState { SkippedVersion = "0.159.0" });

            Assert.Equal(CodexUpdateOutcome.Skipped, (await updater.UpdateAsync(false, null, CancellationToken.None)).Outcome);
            Assert.Equal(CodexUpdateOutcome.Updated, (await updater.UpdateAsync(true, null, CancellationToken.None)).Outcome);
            Assert.Equal(new[] { "" }, tool.Installs);
        }

        [Fact]
        public async Task An_installer_that_fails_changes_nothing_and_says_why_and_the_gate_opens()
        {
            var (updater, tool, _, gate, file) = Make();
            tool.InstallFails = true;

            var result = await updater.UpdateAsync(true, null, CancellationToken.None);

            Assert.Equal(CodexUpdateOutcome.Failed, result.Outcome);
            Assert.StartsWith("Codex could not be updated, so 0.158.0 stays: Codex could not be installed: releases.openai.com is not reachable.", result.Message);
            Assert.Equal(result.Message, file.Load().Problem);
            Assert.Equal("", file.Load().SkippedVersion);
            Assert.False(gate.IsClosed);
        }

        [Fact]
        public async Task An_installer_that_ran_but_left_the_old_version_is_a_failure_not_an_update()
        {
            var (updater, tool, _, _, _) = Make();
            tool.UpdateChangesNothing = true;

            var result = await updater.UpdateAsync(true, null, CancellationToken.None);

            Assert.Equal(CodexUpdateOutcome.Failed, result.Outcome);
            Assert.Equal("The installer ran, but Codex is still 0.158.0.", result.Message);
            Assert.Equal(new[] { "" }, tool.Installs);
        }

        [Fact]
        public async Task When_the_old_version_cannot_be_put_back_that_is_told_plainly()
        {
            var (updater, tool, _, gate, _) = Make();
            tool.After = new CodexHelp(TopHelp(), ExecHelp("--sandbox"), LoginHelp());
            tool.RollbackFails = true;

            var result = await updater.UpdateAsync(true, null, CancellationToken.None);

            Assert.Equal(CodexUpdateOutcome.Failed, result.Outcome);
            Assert.Contains("no longer has exec --sandbox", result.Message);
            Assert.Contains("Codex 0.158.0 could not be put back: disk full", result.Message);
            Assert.False(gate.IsClosed);
        }

        [Fact]
        public async Task The_owners_switch_is_not_put_back_by_an_update_that_was_going_on_when_it_was_turned_off()
        {
            var (updater, tool, releases, _, file) = Make();
            tool.DuringInstall = () =>
            {
                updater.SetAutomatic(false);
                return true;
            };

            var result = await updater.UpdateAsync(true, null, CancellationToken.None);

            Assert.Equal(CodexUpdateOutcome.Updated, result.Outcome);
            var state = file.Load();
            Assert.False(state.Automatic, "the owner turned it off during the update");
            Assert.Equal(("0.159.0", "0.158.0"), (state.UpdatedTo, state.UpdatedFrom));

            // The same while it only looks (the network answer takes seconds), and while an update fails or is rolled back.
            var (looking, _, lookingReleases, _, lookingFile) = Make();
            lookingReleases.OnAsked = () => looking.SetAutomatic(false);
            await looking.CheckAsync(CancellationToken.None);
            Assert.False(lookingFile.Load().Automatic);
            Assert.NotNull(lookingFile.Load().CheckedAt);

            var (failing, failingTool, _, _, failingFile) = Make();
            failingTool.InstallFails = true;
            failingTool.DuringInstall = () =>
            {
                failing.SetAutomatic(false);
                return true;
            };
            await failing.UpdateAsync(true, null, CancellationToken.None);
            Assert.False(failingFile.Load().Automatic);
            Assert.Contains("could not be updated", failingFile.Load().Problem);

            var (rolling, rollingTool, _, _, rollingFile) = Make();
            rollingTool.After = new CodexHelp(TopHelp(), ExecHelp("--sandbox"), LoginHelp());
            rollingTool.DuringInstall = () =>
            {
                rolling.SetAutomatic(false);
                return true;
            };
            Assert.Equal(CodexUpdateOutcome.RolledBack, (await rolling.UpdateAsync(true, null, CancellationToken.None)).Outcome);
            Assert.False(rollingFile.Load().Automatic);
            Assert.Equal("0.159.0", rollingFile.Load().SkippedVersion);
        }

        [Fact]
        public void An_update_of_the_file_reads_changes_and_writes_together_and_returns_the_result()
        {
            var file = new CodexUpdateFile(_folder.Path);

            var result = file.Update(state => state.SkippedVersion = "0.159.0");

            Assert.Equal("0.159.0", result.SkippedVersion);
            Assert.Equal("0.159.0", new CodexUpdateFile(_folder.Path).Load().SkippedVersion);
            Assert.True(new CodexUpdateFile(_folder.Path).Load().Automatic, "what was not changed is as it was");
        }

        [Fact]
        public async Task Cancelling_an_update_opens_the_gate_again()
        {
            var (updater, tool, _, gate, _) = Make();
            tool.DuringInstall = () => throw new OperationCanceledException();

            await Assert.ThrowsAsync<OperationCanceledException>(() => updater.UpdateAsync(true, null, CancellationToken.None));

            Assert.False(gate.IsClosed);
        }

        [Fact]
        public void The_owners_choice_and_what_happened_are_kept_and_a_damaged_file_starts_again()
        {
            var (updater, _, _, _, file) = Make();
            Assert.True(updater.State.Automatic, "Codex updates by itself unless the owner turns it off");

            updater.SetAutomatic(false);
            Assert.False(new CodexUpdateFile(_folder.Path).Load().Automatic);

            File.WriteAllText(file.FilePath, "{ not json");
            Assert.True(file.Load().Automatic);
            Assert.True(File.Exists(file.FilePath + ".bad"));

            File.WriteAllText(file.FilePath, "{\"SkippedVersion\":null,\"SeenVersion\":null,\"Problem\":null,\"UpdatedTo\":null,\"UpdatedFrom\":null}");
            var normal = file.Load();
            Assert.Equal(("", "", "", "", ""), (normal.SkippedVersion, normal.SeenVersion, normal.Problem, normal.UpdatedTo, normal.UpdatedFrom));
        }

        // ---- the installer's version argument

        [Theory]
        [InlineData("", "")]
        [InlineData(null, "")]
        [InlineData(" 0.158.0 ", "0.158.0")]
        [InlineData("10.20.30", "10.20.30")]
        public void The_installer_takes_the_newest_or_a_version_of_three_numbers(string given, string argument) =>
            Assert.Equal(argument, CodexInstaller.ReleaseArgument(given));

        [Theory]
        [InlineData("latest")]
        [InlineData("0.158")]
        [InlineData("0.158.0-alpha.1")]
        [InlineData("rust-v0.158.0")]
        [InlineData("0.158.0; calc")]
        [InlineData("0.158.0\n$env:X")]
        [InlineData("1.2.3.4")]
        public void Anything_else_is_not_passed_to_the_installer(string given) =>
            Assert.Throws<ArgumentException>(() => CodexInstaller.ReleaseArgument(given));

        [Fact]
        public void The_installer_is_told_the_version_or_that_the_newest_is_wanted()
        {
            var newest = CodexInstaller.CreateInvocation(@"C:\temp\i.ps1", null, "");
            var pinned = CodexInstaller.CreateInvocation(@"C:\temp\i.ps1", null, "0.158.0");

            Assert.Equal(("", "1"), (newest.Environment["CODEX_RELEASE"], newest.Environment["CODEX_NON_INTERACTIVE"]));
            Assert.Equal("0.158.0", pinned.Environment["CODEX_RELEASE"]);
            Assert.DoesNotContain("0.158.0", string.Join(" ", pinned.Arguments));
        }

        [Fact]
        public async Task An_installer_asked_for_a_bad_version_does_not_run_anything()
        {
            var runner = new FakeCliRunner();
            var installer = new CodexInstaller(runner, windows: true);

            await Assert.ThrowsAsync<ArgumentException>(() => installer.InstallAsync("latest; calc", null, CancellationToken.None));
            Assert.Empty(runner.Calls);

            await installer.InstallAsync("0.158.0", null, CancellationToken.None);
            Assert.Equal("0.158.0", runner.Calls.Single().Environment["CODEX_RELEASE"]);
        }

        // ---- the Codex on this PC

        private (CodexTool Tool, FakeCliRunner Runner) RealTool(string executable, string installFolder = null)
        {
            var settings = new SmartRetail.AI.Settings.AssistantSettings();
            settings.Codex.ExecutablePath = executable;
            var runner = new FakeCliRunner();
            return (new CodexTool(() => settings, runner, new CodexInstaller(runner, windows: true), installFolder ?? _folder.Path), runner);
        }

        [Fact]
        public async Task The_tool_asks_codex_for_its_version_its_help_and_its_sign_in_without_the_gate()
        {
            var codex = _folder.File("codex-tool");
            var (tool, runner) = RealTool(codex);
            runner.Handler = call =>
            {
                var words = string.Join(" ", call.Arguments);
                switch (words)
                {
                    case "--version": return new CliResult { ExitCode = 0, StandardOutput = "codex-cli 0.158.0\n" };
                    case "--help": return new CliResult { ExitCode = 0, StandardOutput = TopHelp() };
                    case "exec --help": return new CliResult { ExitCode = 0, StandardOutput = ExecHelp() };
                    case "login --help": return new CliResult { ExitCode = 0, StandardError = LoginHelp() };
                    case "login status": return new CliResult { ExitCode = 0, StandardOutput = "Logged in using ChatGPT" };
                    default: return new CliResult { ExitCode = 2 };
                }
            };

            Assert.Equal("codex-cli 0.158.0", await tool.VersionAsync(CancellationToken.None));
            var help = await tool.HelpAsync(CancellationToken.None);
            Assert.Equal(CodexCompatibility.Required().Count(), CodexCompatibility.Visible(help).Count);
            Assert.True(await tool.SignedInAsync(CancellationToken.None));
            Assert.All(runner.Calls, call => Assert.Equal(codex, call.FileName));
            Assert.All(runner.Calls, call => Assert.Equal("1", call.Environment["NO_COLOR"]));
            Assert.All(runner.Calls, call => Assert.Equal(TimeSpan.FromSeconds(30), call.Timeout));
        }

        [Fact]
        public async Task A_codex_that_fails_or_does_not_start_shows_nothing_and_is_not_signed_in()
        {
            var (tool, runner) = RealTool(_folder.File("codex-tool"));
            runner.Handler = call => new CliResult { ExitCode = 1, StandardError = "boom" };
            Assert.Equal("", await tool.VersionAsync(CancellationToken.None));
            Assert.Empty(CodexCompatibility.Visible(await tool.HelpAsync(CancellationToken.None)));
            Assert.False(await tool.SignedInAsync(CancellationToken.None));

            runner.Handler = call => new CliResult { ExitCode = 0, TimedOut = true };
            Assert.Equal("", await tool.VersionAsync(CancellationToken.None));
            Assert.False(await tool.SignedInAsync(CancellationToken.None));

            runner.Handler = call => throw new CliStartException("cannot start", null);
            Assert.Equal("", await tool.VersionAsync(CancellationToken.None));
            Assert.Empty(CodexCompatibility.Visible(await tool.HelpAsync(CancellationToken.None)));
            Assert.Null(await tool.SignedInAsync(CancellationToken.None));
        }

        [Fact]
        public async Task With_no_codex_on_the_pc_the_tool_says_so()
        {
            var (tool, runner) = RealTool(Path.Combine(_folder.Path, "missing", "codex"));

            Assert.Null(await tool.VersionAsync(CancellationToken.None));
            Assert.Empty(CodexCompatibility.Visible(await tool.HelpAsync(CancellationToken.None)));
            Assert.Null(await tool.SignedInAsync(CancellationToken.None));
            Assert.False(tool.IsInstallerManaged());
            Assert.Empty(runner.Calls);
        }

        [Fact]
        public void Only_a_codex_in_the_installers_folder_is_the_installers_to_replace()
        {
            var installFolder = Path.Combine(_folder.Path, "Programs", "OpenAI", "Codex", "bin");
            Directory.CreateDirectory(installFolder);
            var inside = Path.Combine(installFolder, "codex-tool");
            File.WriteAllText(inside, "x");
            var outside = _folder.File("npm-codex");

            Assert.True(RealTool(inside, installFolder).Tool.IsInstallerManaged());
            Assert.True(RealTool(inside, installFolder + Path.DirectorySeparatorChar).Tool.IsInstallerManaged());
            Assert.False(RealTool(outside, installFolder).Tool.IsInstallerManaged());
        }

        // ---- the old releases the installer leaves

        private string Release(string releases, string name)
        {
            var folder = Path.Combine(releases, name);
            Directory.CreateDirectory(Path.Combine(folder, "bin"));
            File.WriteAllText(Path.Combine(folder, "bin", "codex.exe"), "x");
            return folder;
        }

        private const string Target = "x86_64-pc-windows-msvc";

        [Fact]
        public void The_older_releases_go_and_the_newest_three_and_the_named_versions_stay()
        {
            var releases = Path.Combine(_folder.Path, "packages", "standalone", "releases");
            foreach (var version in new[] { "0.150.0", "0.155.0", "0.156.1", "0.157.0", "0.158.0", "0.159.0" })
            {
                Release(releases, version + "-" + Target);
            }

            var removed = CodexReleasePruner.Prune(releases, new[] { "0.159.0", "0.155.0" });

            Assert.Equal(new[] { "0.150.0-" + Target, "0.156.1-" + Target }.OrderBy(x => x), removed.OrderBy(x => x));
            Assert.Equal(
                new[] { "0.155.0-" + Target, "0.157.0-" + Target, "0.158.0-" + Target, "0.159.0-" + Target },
                Directory.GetDirectories(releases).Select(Path.GetFileName).OrderBy(x => x));
        }

        [Fact]
        public void Only_folders_named_like_a_release_are_ever_touched_and_nothing_goes_when_the_layout_is_not_the_expected_one()
        {
            var releases = Path.Combine(_folder.Path, "releases");
            foreach (var name in new[] { "0.150.0-" + Target, "0.157.0-" + Target, "0.158.0-" + Target, "0.159.0-" + Target, ".staging.0.160.0." + Target + ".42", "notes", "0.160.0", "current" })
            {
                Release(releases, name);
            }

            // The version in use is not among the folders: this is not the layout that is known, so nothing is removed.
            Assert.Empty(CodexReleasePruner.Prune(releases, new[] { "0.161.0" }));
            Assert.Equal(8, Directory.GetDirectories(releases).Length);

            var removed = CodexReleasePruner.Prune(releases, new[] { "0.159.0" });

            Assert.Equal(new[] { "0.150.0-" + Target }, removed);
            Assert.All(new[] { ".staging.0.160.0." + Target + ".42", "notes", "0.160.0", "current" }, name => Assert.True(Directory.Exists(Path.Combine(releases, name)), name));
        }

        [Fact]
        public void A_missing_folder_or_no_versions_named_removes_nothing_and_a_release_in_use_stays()
        {
            Assert.Empty(CodexReleasePruner.Prune(Path.Combine(_folder.Path, "nothing"), new[] { "0.159.0" }));
            Assert.Empty(CodexReleasePruner.Prune(null, new[] { "0.159.0" }));

            var releases = Path.Combine(_folder.Path, "releases");
            foreach (var version in new[] { "0.150.0", "0.157.0", "0.158.0", "0.159.0" })
            {
                Release(releases, version + "-" + Target);
            }

            Assert.Empty(CodexReleasePruner.Prune(releases, null));
            Assert.Empty(CodexReleasePruner.Prune(releases, new string[0]));
            Assert.Equal(4, Directory.GetDirectories(releases).Length);

        }

        [Fact]
        public void A_release_with_a_program_running_from_it_stays_whole_and_the_others_still_go()
        {
            var releases = Path.Combine(_folder.Path, "releases");
            foreach (var version in new[] { "0.150.0", "0.151.0", "0.157.0", "0.158.0", "0.159.0" })
            {
                Release(releases, version + "-" + Target);
            }

            File.WriteAllText(Path.Combine(releases, "0.150.0-" + Target, "bin", "notes.txt"), "kept with it");

            // A program that runs cannot be opened for writing: this stands in for one.
            using (new FileStream(Path.Combine(releases, "0.150.0-" + Target, "bin", "codex.exe"), FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                var removed = CodexReleasePruner.Prune(releases, new[] { "0.159.0" });

                Assert.Equal(new[] { "0.151.0-" + Target }, removed);
                Assert.True(File.Exists(Path.Combine(releases, "0.150.0-" + Target, "bin", "notes.txt")), "nothing of it was taken, not even the files that could have been");
            }

            // Once nothing runs from it, it goes with the next update.
            Assert.Equal(new[] { "0.150.0-" + Target }, CodexReleasePruner.Prune(releases, new[] { "0.159.0" }));
        }

        [Fact]
        public void Codex_keeps_its_folder_where_the_installer_puts_it()
        {
            Assert.Equal(Path.Combine("home", "packages", "standalone", "releases"), CodexReleasePruner.ReleasesFolder("home"));
            Assert.False(string.IsNullOrWhiteSpace(CodexReleasePruner.DefaultCodexHome()));
        }

        // ---- the release addresses

        [Theory]
        [InlineData("https://releases.example.com/codex/channels/latest", true)]
        [InlineData("http://127.0.0.1:5999/channels/latest", true)]
        [InlineData("http://localhost:5999/channels/latest", true)]
        [InlineData("http://releases.example.com/codex/channels/latest", false)]
        [InlineData("ftp://releases.example.com/x", false)]
        [InlineData("releases.openai.com/codex", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void A_release_address_is_https_or_on_this_pc(string address, bool allowed)
        {
            if (allowed)
            {
                Assert.NotNull(new CodexReleaseFeed(new HttpClient(new RoutedHttpHandler()), address, "https://api.example.com/x"));
            }
            else
            {
                Assert.Throws<ArgumentException>(() => new CodexReleaseFeed(new HttpClient(new RoutedHttpHandler()), address, "https://api.example.com/x"));
            }
        }

        // ---- the gate in the app server

        [Fact]
        public async Task A_conversation_with_the_app_server_holds_a_place_in_the_gate_until_it_is_closed()
        {
            var gate = new AiRunGate();
            var codex = new CodexCliProvider(new FakeCliRunner(), () => Settings(_folder.File("codex-tool")), Path.Combine(_folder.Path, "runs"))
            {
                StartChannel = _ => new FakeAppServer(),
                Gate = gate,
            };

            using (await codex.OpenAppServerAsync(CancellationToken.None))
            {
                Assert.Equal(1, gate.Running);
                Assert.False(gate.TryClose(), "Codex is not replaced while something talks to it");
            }

            Assert.Equal(0, gate.Running);
            Assert.True(gate.TryClose());

            // While the gate is closed a new conversation waits for it to open; it can be given up on.
            using (var cancel = new CancellationTokenSource(TimeSpan.FromMilliseconds(100)))
            {
                await Assert.ThrowsAnyAsync<OperationCanceledException>(() => codex.OpenAppServerAsync(cancel.Token));
            }

            gate.Open();
            Assert.Equal(0, gate.Running);

            var broken = new CodexCliProvider(new FakeCliRunner(), () => Settings(_folder.File("codex-tool")), Path.Combine(_folder.Path, "runs"))
            {
                StartChannel = _ => throw new CliStartException("Could not start codex app-server", null),
                Gate = gate,
            };
            await Assert.ThrowsAsync<CliStartException>(() => broken.OpenAppServerAsync(CancellationToken.None));
            Assert.Equal(0, gate.Running);
        }

        [Fact]
        public async Task Without_a_gate_the_app_server_opens_as_before()
        {
            var codex = new CodexCliProvider(new FakeCliRunner(), () => Settings(_folder.File("codex-tool")), Path.Combine(_folder.Path, "runs"))
            {
                StartChannel = _ => new FakeAppServer(),
            };

            using (var server = await codex.OpenAppServerAsync(CancellationToken.None))
            {
                Assert.NotNull(server);
            }
        }

        private static SmartRetail.AI.Settings.AssistantSettings Settings(string codexPath)
        {
            var settings = TestSettings.Create().Settings;
            settings.Codex.ExecutablePath = codexPath;
            return settings;
        }
    }
}
