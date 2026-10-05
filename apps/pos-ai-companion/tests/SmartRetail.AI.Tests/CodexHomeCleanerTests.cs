using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Creatives;
using SmartRetail.AI.Posters;
using SmartRetail.AI.Providers;
using Xunit;

namespace SmartRetail.AI.Tests
{
    public class CodexHomeCleanerTests : IDisposable
    {
        private const string OwnSession = "0199aaaa-1111-7000-8000-000000000001";
        private const string OtherSession = "0199bbbb-2222-7000-8000-000000000002";

        private readonly TempFolder _temp = new TempFolder();
        private readonly string _home;
        private readonly string _run;
        private readonly DateTime _started = DateTime.UtcNow.AddSeconds(-1);

        public CodexHomeCleanerTests()
        {
            _home = Path.Combine(_temp.Path, "codex-home");
            _run = Path.Combine(_temp.Path, "runs", "20260928-110000-a1b2c3d4");
            Directory.CreateDirectory(_run);
            Write("auth.json", "{\"tokens\":\"secret\"}");
            Write("config.toml", "model = \"gpt-5\"");
        }

        public void Dispose() => _temp.Dispose();

        private string Write(string relative, string text)
        {
            var path = Path.Combine(_home, relative);
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllText(path, text);
            return path;
        }

        private string WriteBytes(string relative, byte[] bytes)
        {
            var path = Path.Combine(_home, relative);
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllBytes(path, bytes);
            return path;
        }

        /// <summary>A session log as Codex writes it: the session's details first, then what happened.</summary>
        internal static string Session(string codexHome, string id, string cwd)
        {
            var path = Path.Combine(codexHome, "sessions", "2026", "09", "28", "rollout-2026-09-28T11-00-00-" + id + ".jsonl");
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            var meta = JsonConvert.SerializeObject(new { timestamp = "2026-09-28T11:00:00Z", type = "session_meta", payload = new { id, timestamp = "2026-09-28T11:00:00Z", cwd, originator = "codex_exec" } });
            File.WriteAllText(path, meta + "\n{\"type\":\"response_item\",\"payload\":{\"text\":\"the shop's words\"}}\n");
            return path;
        }

        [Fact]
        public void Only_this_runs_session_log_and_pictures_are_removed()
        {
            var own = Session(_home, OwnSession, _run + Path.DirectorySeparatorChar);
            var other = Session(_home, OtherSession, Path.Combine(_temp.Path, "runs", "20260928-110001-ffffffff"));
            var older = Session(_home, "0199cccc-3333-7000-8000-000000000003", _run);
            File.SetLastWriteTimeUtc(older, _started.AddHours(-2));
            var kept = new byte[] { 1, 2, 3, 4 };
            var ownPicture = WriteBytes(Path.Combine("generated_images", OwnSession, "ig_1.png"), new byte[] { 9, 9 });
            var copy = WriteBytes(Path.Combine("generated_images", "ig_loose.png"), kept);
            var otherPicture = WriteBytes(Path.Combine("generated_images", OtherSession, "ig_2.png"), new byte[] { 8 });
            var unrelated = WriteBytes(Path.Combine("generated_images", "ig_other.png"), new byte[] { 1, 2, 3, 5 });

            var removed = CodexHomeCleaner.Clean(_home, _run, _started, kept);

            Assert.Equal(3, removed);
            Assert.False(File.Exists(own));
            Assert.False(File.Exists(ownPicture));
            Assert.False(Directory.Exists(Path.GetDirectoryName(ownPicture)), "the run's emptied folder stays");
            Assert.False(File.Exists(copy));
            Assert.True(File.Exists(other));
            Assert.True(File.Exists(older), "a log from before the run is not this run's");
            Assert.True(File.Exists(otherPicture));
            Assert.True(File.Exists(unrelated));
            Assert.Equal("{\"tokens\":\"secret\"}", File.ReadAllText(Path.Combine(_home, "auth.json")));
            Assert.True(File.Exists(Path.Combine(_home, "config.toml")));
        }

        [Fact]
        public void Logs_that_are_not_sessions_and_missing_folders_are_left_alone()
        {
            var notJson = Write(Path.Combine("sessions", "rollout-bad.jsonl"), "not json\n");
            var notMeta = Write(Path.Combine("sessions", "rollout-turn.jsonl"), "{\"type\":\"response_item\",\"payload\":{\"cwd\":\"" + _run.Replace("\\", "\\\\") + "\"}}\n");

            Assert.Equal(0, CodexHomeCleaner.Clean(_home, _run, _started, null));
            Assert.True(File.Exists(notJson));
            Assert.True(File.Exists(notMeta));
            Assert.Equal(0, CodexHomeCleaner.Clean(Path.Combine(_temp.Path, "no-home"), _run, _started, new byte[] { 1 }));
            Assert.Equal(0, CodexHomeCleaner.Clean(_home, "", _started, null));
            Assert.Empty(CodexHomeCleaner.SessionIds(_home, _run, _started));
        }

        [Fact]
        public void A_folder_is_the_same_however_it_is_written()
        {
            Assert.True(CodexHomeCleaner.SamePath(_run, _run + Path.DirectorySeparatorChar));
            Assert.True(CodexHomeCleaner.SamePath(_run, Path.Combine(_temp.Path, "runs", "x", "..", "20260928-110000-a1b2c3d4")));
            Assert.False(CodexHomeCleaner.SamePath(_run, _run + "-2"));
            Assert.False(CodexHomeCleaner.SamePath(_run, "\0"));
        }

        [Fact]
        public async Task A_creative_run_leaves_nothing_of_the_shop_in_Codexs_folder()
        {
            var (settings, _) = TestSettings.Create();
            settings.Codex.ExecutablePath = _temp.File("codex-tool");
            var runner = new FakeCliRunner();
            var codex = new CodexCliProvider(runner, () => settings, Path.Combine(_temp.Path, "runs")) { CodexHome = _home };
            string log = null, picture = null;
            runner.Handler = call =>
            {
                // Codex keeps a log of the run and its own copy of the picture, besides the one saved as asked.
                log = Session(_home, OwnSession, call.WorkingDirectory);
                picture = WriteBytes(Path.Combine("generated_images", OwnSession, "ig_1.png"), ProductPhotoTests.Png);
                File.WriteAllBytes(Path.Combine(call.WorkingDirectory, CreativeArtPrompt.ResultFileName), ProductPhotoTests.Png);
                return new CliResult { ExitCode = 0 };
            };

            var result = await codex.MakeCreativeAsync(new CreativeArtRequest { FormatName = "Square post", Width = 1080, Height = 1080, Headline = "Fresh stock" }, null, CancellationToken.None);

            Assert.Equal(ProductPhotoTests.Png, result.Image);
            Assert.False(File.Exists(log), "the run's session log is still in Codex's folder");
            Assert.False(File.Exists(picture), "Codex's copy of the picture is still there");
            Assert.True(File.Exists(Path.Combine(_home, "auth.json")));
        }

        [Fact]
        public async Task A_picture_not_surely_the_runs_is_used_but_never_removed()
        {
            var (settings, _) = TestSettings.Create();
            settings.Codex.ExecutablePath = _temp.File("codex-tool");
            var runner = new FakeCliRunner();
            var codex = new CodexCliProvider(runner, () => settings, Path.Combine(_temp.Path, "runs")) { CodexHome = _home };
            string loose = null;
            runner.Handler = call =>
            {
                // No session log names the run, and the picture is only in Codex's folder.
                loose = WriteBytes(Path.Combine("generated_images", "ig_loose.png"), new byte[] { 0x89, 0x50, 0x4E, 0x47, 7 });
                return new CliResult { ExitCode = 0 };
            };

            var result = await codex.MakePosterArtworkAsync(new PosterArtworkRequest { Theme = "a sale" }, null, CancellationToken.None);

            Assert.Equal(new byte[] { 0x89, 0x50, 0x4E, 0x47, 7 }, result.Image);
            Assert.True(File.Exists(loose), "a picture that may be another run's was removed");
        }

        [Fact]
        public async Task A_picture_that_was_there_before_the_run_is_never_taken()
        {
            var (settings, _) = TestSettings.Create();
            settings.Codex.ExecutablePath = _temp.File("codex-tool");
            var runner = new FakeCliRunner();
            var codex = new CodexCliProvider(runner, () => settings, Path.Combine(_temp.Path, "runs")) { CodexHome = _home };
            // Left moments ago by a run that failed; this run's Codex saves nothing.
            var earlier = WriteBytes(Path.Combine("generated_images", "ig_earlier.png"), new byte[] { 0x89, 0x50, 0x4E, 0x47, 3 });
            runner.Handler = call => new CliResult { ExitCode = 0 };

            var error = await Assert.ThrowsAnyAsync<AiProviderException>(() =>
                codex.MakePosterArtworkAsync(new PosterArtworkRequest { Theme = "a sale" }, null, CancellationToken.None));

            Assert.Contains("made no image", error.Message);
            Assert.True(File.Exists(earlier));
        }

        [Fact]
        public async Task Image_runs_with_one_Codex_folder_go_one_at_a_time()
        {
            var (settings, _) = TestSettings.Create();
            settings.Codex.ExecutablePath = _temp.File("codex-tool");
            var runner = new FakeCliRunner();
            var running = 0;
            var most = 0;
            var waiting = new ManualResetEventSlim();
            runner.Handler = call =>
            {
                var now = Interlocked.Increment(ref running);
                InterlockedMax(ref most, now);
                // The first run keeps its turn until another is waiting for it.
                waiting.Wait(TimeSpan.FromSeconds(10));
                File.WriteAllBytes(Path.Combine(call.WorkingDirectory, PosterArtworkPrompt.ResultFileName), ProductPhotoTests.Png);
                Interlocked.Decrement(ref running);
                return new CliResult { ExitCode = 0 };
            };
            var said = new ConcurrentQueue<string>();
            var progress = new Said(text =>
            {
                said.Enqueue(text);
                if (text.StartsWith("Waiting", StringComparison.Ordinal))
                {
                    waiting.Set();
                }
            });

            // Each job has its own provider, all with the same Codex folder.
            await Task.WhenAll(Enumerable.Range(0, 3).Select(_ => Task.Run(() =>
                new CodexCliProvider(runner, () => settings, Path.Combine(_temp.Path, "runs")) { CodexHome = _home }
                    .MakePosterArtworkAsync(new PosterArtworkRequest { Theme = "a sale" }, progress, CancellationToken.None))));

            Assert.Equal(1, most);
            Assert.Equal(3, runner.Calls.Count);
            Assert.Contains("Waiting for the picture Codex is making now…", said);
        }

        private static void InterlockedMax(ref int target, int value)
        {
            int seen;
            while ((seen = Volatile.Read(ref target)) < value && Interlocked.CompareExchange(ref target, value, seen) != seen)
            {
            }
        }

        private sealed class Said : IProgress<string>
        {
            private readonly Action<string> _said;

            public Said(Action<string> said) => _said = said;

            public void Report(string value) => _said(value);
        }

        [Fact]
        public async Task A_failed_run_leaves_no_log_and_the_fallback_picture_is_the_runs_own()
        {
            var (settings, _) = TestSettings.Create();
            settings.Codex.ExecutablePath = _temp.File("codex-tool");
            var runner = new FakeCliRunner();
            var codex = new CodexCliProvider(runner, () => settings, Path.Combine(_temp.Path, "runs")) { CodexHome = _home };
            string log = null;
            runner.Handler = call =>
            {
                log = Session(_home, OwnSession, call.WorkingDirectory);
                return new CliResult { ExitCode = 1, StandardError = "failed" };
            };
            await Assert.ThrowsAnyAsync<AiProviderException>(() => codex.MakePosterArtworkAsync(new PosterArtworkRequest { Theme = "a sale" }, null, CancellationToken.None));
            Assert.False(File.Exists(log), "a failed run's log stays");

            // Codex saved no picture in the run's folder: of two it made meanwhile, the run takes the one filed under its session,
            // though another run's is newer.
            runner.Handler = call =>
            {
                Session(_home, OwnSession, call.WorkingDirectory);
                var own = WriteBytes(Path.Combine("generated_images", OwnSession, "ig_own.png"), new byte[] { 0x89, 0x50, 0x4E, 0x47, 1 });
                File.SetLastWriteTimeUtc(own, DateTime.UtcNow.AddSeconds(-1));
                WriteBytes(Path.Combine("generated_images", OtherSession, "ig_other.png"), new byte[] { 0x89, 0x50, 0x4E, 0x47, 2 });
                return new CliResult { ExitCode = 0 };
            };
            var result = await codex.MakePosterArtworkAsync(new PosterArtworkRequest { Theme = "a sale" }, null, CancellationToken.None);

            Assert.Equal(new byte[] { 0x89, 0x50, 0x4E, 0x47, 1 }, result.Image);
            Assert.False(File.Exists(Path.Combine(_home, "generated_images", OwnSession, "ig_own.png")));
            Assert.True(File.Exists(Path.Combine(_home, "generated_images", OtherSession, "ig_other.png")), "another run's picture was taken or removed");
        }
    }
}
