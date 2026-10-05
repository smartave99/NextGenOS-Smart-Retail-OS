using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Dashboard;
using SmartRetail.AI.Data;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    public class DashboardTests
    {
        private static readonly Uri Home = new Uri("http://127.0.0.1:5080/");
        private static readonly string Program = Path.Combine(Path.GetTempPath(), "Dashboard", "SmartRetail.Pos.Web.exe");

        [Fact]
        public async Task A_running_dashboard_just_opens_the_page()
        {
            var host = new FakeHost { AnswersFromCheck = 1 };

            var result = await Launcher(host).OpenAsync(Program, Home, "sales", null, CancellationToken.None);

            Assert.True(result.Opened);
            Assert.False(result.Started);
            Assert.Empty(host.Started);
            Assert.Equal(new[] { new Uri("http://127.0.0.1:5080/sales") }, host.Opened);
        }

        [Fact]
        public async Task A_stopped_dashboard_is_started_then_opened_once_it_answers()
        {
            var host = new FakeHost { AnswersFromCheck = 4, Files = { Program } };
            var messages = new List<string>();

            var result = await Launcher(host).OpenAsync(Program, Home, "/plan", new SyncProgress(messages), CancellationToken.None);

            Assert.True(result.Opened && result.Started);
            Assert.Equal(new[] { Program }, host.Started);
            Assert.Equal(new[] { new Uri("http://127.0.0.1:5080/plan") }, host.Opened);
            Assert.Equal(3, host.Waits);
            Assert.Equal(new[] { "Starting the sales dashboard…" }, messages);
        }

        [Fact]
        public async Task The_app_window_starts_the_dashboard_without_a_browser()
        {
            var host = new FakeHost { AnswersFromCheck = 2, Files = { Program } };

            var result = await Launcher(host).EnsureRunningAsync(Program, Home, null, CancellationToken.None);
            var again = await Launcher(host).EnsureRunningAsync(Program, Home, null, CancellationToken.None);

            Assert.True(result.Opened && result.Started);
            Assert.True(again.Opened);
            Assert.False(again.Started);
            Assert.Equal(new[] { Program }, host.Started);
            Assert.Empty(host.Opened);
        }

        [Fact]
        public async Task A_missing_dashboard_is_explained_and_nothing_starts()
        {
            var host = new FakeHost();

            var result = await Launcher(host).OpenAsync(Program, Home, "sales", null, CancellationToken.None);

            Assert.False(result.Opened);
            Assert.Contains("not installed", result.Problem);
            Assert.Contains(Program, result.Problem);
            Assert.Empty(host.Started);
            Assert.Empty(host.Opened);
        }

        [Fact]
        public async Task A_dashboard_that_never_answers_gives_up_with_a_hint()
        {
            var host = new FakeHost { Files = { Program } };

            var result = await Launcher(host).OpenAsync(Program, Home, "sales", null, CancellationToken.None);

            Assert.False(result.Opened);
            Assert.True(result.Started);
            Assert.Contains("did not start within 45 seconds", result.Problem);
            Assert.Contains("Another program may be using its address", result.Problem);
            Assert.Equal(90, host.Waits);
            Assert.Empty(host.Opened);
        }

        [Fact]
        public async Task An_address_off_this_pc_is_refused()
        {
            var host = new FakeHost { AnswersFromCheck = 1 };

            var result = await Launcher(host).OpenAsync(Program, new Uri("http://192.168.1.20:5080/"), "sales", null, CancellationToken.None);

            Assert.False(result.Opened);
            Assert.Equal(0, host.Checks);
        }

        [Theory]
        [InlineData("http://127.0.0.1:5080", "http://127.0.0.1:5080/")]
        [InlineData(" http://localhost:6000/pos ", "http://localhost:6000/pos/")]
        [InlineData("https://[::1]:5443/", "https://[::1]:5443/")]
        [InlineData("http://192.168.1.20:5080/", DashboardSettings.DefaultUrl)]
        [InlineData("ftp://127.0.0.1/", DashboardSettings.DefaultUrl)]
        [InlineData("", DashboardSettings.DefaultUrl)]
        [InlineData(null, DashboardSettings.DefaultUrl)]
        public void The_dashboard_address_must_stay_on_this_pc(string saved, string expected)
        {
            var settings = new AssistantSettings();
            settings.Dashboard.Url = saved;

            settings.Normalize();

            Assert.Equal(expected, settings.Dashboard.Url);
        }

        [Fact]
        public void The_dashboard_program_is_looked_for_next_to_this_app()
        {
            var settings = new DashboardSettings();
            var appFolder = Path.Combine(Path.GetTempPath(), "SmartRetailAI");

            Assert.Equal(Path.Combine(appFolder, "Dashboard", "SmartRetail.Pos.Web.exe"), settings.ResolveExecutable(appFolder));

            settings.ExecutablePath = "\"" + Program + "\"";
            Assert.Equal(Program, settings.ResolveExecutable(appFolder));
        }

        [Fact]
        public void An_older_settings_file_gets_the_dashboard_defaults()
        {
            using (var folder = new TempFolder())
            {
                var path = folder.File("settings.json", "{}");

                var dashboard = new SettingsStore(path).Load().Dashboard;

                Assert.Equal(DashboardSettings.DefaultUrl, dashboard.Url);
                Assert.Equal("", dashboard.ExecutablePath);
            }
        }

        // ----- Starting with Windows: the dashboard looks for the POS database once, so it waits for SQL Server -----

        [Fact]
        public async Task The_dashboard_waits_for_the_pos_database_before_it_starts()
        {
            var host = new LiveHost();
            var messages = new List<string>();
            var asked = 0;

            var result = await Timed(host, new TestClock()).StartAsync(
                Program, Home, new SyncProgress(messages), CancellationToken.None, TimeSpan.FromMinutes(3),
                _ =>
                {
                    host.Events.Add("asks");
                    return Task.FromResult(++asked == 3);
                });

            Assert.True(result.Opened && result.Started);
            Assert.False(result.StartedWithoutPos);
            Assert.Equal(new[] { "asks", "asks", "asks", "start" }, host.Events);
            Assert.Equal(new[] { PosReadiness.Waiting, "Starting the sales dashboard…" }, messages);
        }

        [Fact]
        public async Task A_database_that_never_answers_still_gets_the_dashboard_and_the_result_says_so()
        {
            var host = new LiveHost();
            var clock = new TestClock();

            var result = await Timed(host, clock).StartAsync(Program, Home, null, CancellationToken.None, TimeSpan.FromMinutes(3), _ => Task.FromResult(false));

            Assert.True(result.Opened && result.Started);
            Assert.True(result.StartedWithoutPos);
            Assert.Equal(new[] { "start" }, host.Events);
            Assert.True(clock.Elapsed >= TimeSpan.FromMinutes(3), "it waited the whole patience first: " + clock.Elapsed);
        }

        [Fact]
        public async Task A_dashboard_that_is_already_running_is_not_waited_for_and_not_marked()
        {
            var host = new LiveHost { Up = true };
            var asked = 0;

            var result = await Timed(host, new TestClock()).StartAsync(
                Program, Home, null, CancellationToken.None, TimeSpan.FromMinutes(3),
                _ =>
                {
                    asked++;
                    return Task.FromResult(false);
                });

            Assert.True(result.Opened);
            Assert.False(result.Started);
            Assert.False(result.StartedWithoutPos);
            Assert.Equal(0, asked);
            Assert.Empty(host.Events);
        }

        [Fact]
        public async Task Nothing_saved_or_no_patience_means_nothing_to_wait_for()
        {
            var noDatabase = new LiveHost();
            var first = await Timed(noDatabase, new TestClock()).StartAsync(Program, Home, null, CancellationToken.None, TimeSpan.FromMinutes(3), posAnswers: null);

            var noPatience = new LiveHost();
            var asked = 0;
            var second = await Timed(noPatience, new TestClock()).StartAsync(
                Program, Home, null, CancellationToken.None, TimeSpan.Zero,
                _ =>
                {
                    asked++;
                    return Task.FromResult(false);
                });

            Assert.True(first.Started && second.Started);
            Assert.False(first.StartedWithoutPos);
            Assert.False(second.StartedWithoutPos);
            Assert.Equal(0, asked);
        }

        [Fact]
        public async Task A_restart_stops_the_dashboard_and_starts_it_again_once_the_database_answers()
        {
            var host = new LiveHost { Up = true };

            var result = await Timed(host, new TestClock()).StartAsync(
                Program, Home, null, CancellationToken.None, PosReadiness.WhenOpenedByHand,
                _ =>
                {
                    host.Events.Add("asks");
                    return Task.FromResult(true);
                },
                restart: true);

            Assert.True(result.Opened && result.Started);
            Assert.False(result.StartedWithoutPos);
            Assert.Equal(new[] { "stop", "asks", "start" }, host.Events);
        }

        [Fact]
        public async Task A_dashboard_that_will_not_stop_is_left_running_after_a_short_wait()
        {
            var host = new LiveHost { Up = true, StopsWhenAsked = false };
            var clock = new TestClock();

            var result = await Timed(host, clock).StartAsync(
                Program, Home, null, CancellationToken.None, PosReadiness.WhenOpenedByHand, _ => Task.FromResult(true), restart: true);

            Assert.True(result.Opened);
            Assert.False(result.Started);
            Assert.Equal(new[] { "stop" }, host.Events);
            Assert.Equal(20, clock.Rests.Count(rest => rest == TimeSpan.FromMilliseconds(250)));
        }

        [Fact]
        public async Task An_address_off_this_pc_is_refused_before_anything_is_stopped_or_waited_for()
        {
            var host = new LiveHost { Up = true };

            var result = await Timed(host, new TestClock()).StartAsync(
                Program, new Uri("http://192.168.1.20:5080/"), null, CancellationToken.None, TimeSpan.FromMinutes(3), _ => Task.FromResult(false), restart: true);

            Assert.False(result.Opened);
            Assert.Empty(host.Events);
        }

        private static DashboardLauncher Timed(LiveHost host, TestClock clock) => new DashboardLauncher(host, clock.Delay, () => clock.Now);

        /// <summary>A clock that only moves when something rests, so waiting minutes takes no time.</summary>
        private sealed class TestClock
        {
            private readonly DateTime _start = new DateTime(2026, 9, 30, 8, 0, 0, DateTimeKind.Utc);

            public DateTime Now { get; private set; } = new DateTime(2026, 9, 30, 8, 0, 0, DateTimeKind.Utc);

            public TimeSpan Elapsed => Now - _start;

            public List<TimeSpan> Rests { get; } = new List<TimeSpan>();

            public Task Delay(TimeSpan time, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();
                Rests.Add(time);
                Now += time;
                return Task.CompletedTask;
            }
        }

        /// <summary>A dashboard that answers while it is up: starting brings it up, and stopping takes it down (unless it will not stop).</summary>
        private sealed class LiveHost : IDashboardHost
        {
            public bool Up { get; set; }

            public bool StopsWhenAsked { get; set; } = true;

            public List<string> Events { get; } = new List<string>();

            public Task<bool> RespondsAsync(Uri url, CancellationToken cancellationToken) => Task.FromResult(Up);

            public bool FileExists(string path) => true;

            public void Start(string executable)
            {
                Events.Add("start");
                Up = true;
            }

            public void OpenBrowser(Uri url) => Events.Add("browser");

            public void StopStarted()
            {
                Events.Add("stop");
                if (StopsWhenAsked)
                {
                    Up = false;
                }
            }
        }

        private static DashboardLauncher Launcher(FakeHost host) => new DashboardLauncher(host, (wait, ct) =>
        {
            host.Waits++;
            return Task.CompletedTask;
        });

        private sealed class FakeHost : IDashboardHost
        {
            /// <summary>The first check that finds the dashboard answering; 0 = never.</summary>
            public int AnswersFromCheck { get; set; }

            public int Checks { get; private set; }

            public int Waits { get; set; }

            public HashSet<string> Files { get; } = new HashSet<string>();

            public List<string> Started { get; } = new List<string>();

            public List<Uri> Opened { get; } = new List<Uri>();

            public Task<bool> RespondsAsync(Uri url, CancellationToken cancellationToken)
            {
                Checks++;
                return Task.FromResult(AnswersFromCheck > 0 && Checks >= AnswersFromCheck);
            }

            public bool FileExists(string path) => Files.Contains(path);

            public void Start(string executable) => Started.Add(executable);

            public void OpenBrowser(Uri url) => Opened.Add(url);

            public void StopStarted()
            {
            }
        }

        /// <summary>Reports straight away, unlike Progress&lt;T&gt;, which posts to a synchronisation context.</summary>
        private sealed class SyncProgress : IProgress<string>
        {
            private readonly List<string> _messages;

            public SyncProgress(List<string> messages) => _messages = messages;

            public void Report(string value) => _messages.Add(value);
        }
    }
}
