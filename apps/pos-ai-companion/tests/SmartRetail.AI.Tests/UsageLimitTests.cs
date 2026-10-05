using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Products;
using SmartRetail.AI.Providers;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>A clock the tests move by hand: waits end when it is moved past their time.</summary>
    internal sealed class FakeTime
    {
        private readonly object _gate = new object();
        private readonly List<(DateTimeOffset At, TaskCompletionSource<bool> Done)> _waiting = new List<(DateTimeOffset, TaskCompletionSource<bool>)>();

        public DateTimeOffset Now { get; private set; } = new DateTimeOffset(2026, 10, 3, 10, 0, 0, TimeSpan.FromHours(5.5));

        public Func<DateTimeOffset> Clock => () => Now;

        /// <summary>How many waits have not ended.</summary>
        public int Waiting
        {
            get
            {
                lock (_gate)
                {
                    return _waiting.Count(wait => !wait.Done.Task.IsCompleted);
                }
            }
        }

        public Task Delay(TimeSpan time, CancellationToken token)
        {
            var done = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            lock (_gate)
            {
                _waiting.Add((Now + time, done));
            }

            token.Register(() => done.TrySetCanceled(token));
            return done.Task;
        }

        public void Advance(TimeSpan by)
        {
            List<(DateTimeOffset At, TaskCompletionSource<bool> Done)> due;
            lock (_gate)
            {
                Now += by;
                due = _waiting.Where(wait => wait.At <= Now || wait.Done.Task.IsCompleted).ToList();
                _waiting.RemoveAll(wait => due.Contains(wait));
            }

            foreach (var wait in due)
            {
                wait.Done.TrySetResult(true);
            }
        }
    }

    /// <summary>When Codex says it can answer again, read from its own words, and the pause everything waits in.</summary>
    public class UsageLimitTests : IDisposable
    {
        private static readonly DateTimeOffset Morning = new DateTimeOffset(2026, 10, 3, 10, 0, 0, TimeSpan.FromHours(5.5));

        private const string Error = "You've hit your usage limit. Upgrade to Pro (https://chatgpt.com/explore/pro) or try again at 7:33 PM.";

        private readonly TempFolder _temp = new TempFolder();
        private readonly FakeTime _time = new FakeTime();

        public void Dispose() => _temp.Dispose();

        private UsageLimitPause Pause() => new UsageLimitPause(_time.Clock, _time.Delay);

        private static UsageLimitInfo Limit(DateTimeOffset? resetsAt) => new UsageLimitInfo("Codex has reached its usage limit.", resetsAt);

        // ----- Reading the time -----

        [Theory]
        [InlineData("at 7:33 PM", "2026-10-03T19:33:00+05:30")]
        [InlineData("at 7:33 PM.", "2026-10-03T19:33:00+05:30")]
        [InlineData("at 7:33pm", "2026-10-03T19:33:00+05:30")]
        [InlineData("at 19:33", "2026-10-03T19:33:00+05:30")]
        [InlineData("at 9:15 AM", "2026-10-04T09:15:00+05:30")]
        [InlineData("at 7 PM", "2026-10-03T19:00:00+05:30")]
        [InlineData("at Oct 7th, 2026 9:15 AM", "2026-10-07T09:15:00+05:30")]
        [InlineData("at Oct 7 2026 9:15 AM", "2026-10-07T09:15:00+05:30")]
        [InlineData("at October 7th, 2026 9:15 AM.", "2026-10-07T09:15:00+05:30")]
        [InlineData("at 7 Oct 2026 21:05", "2026-10-07T21:05:00+05:30")]
        [InlineData("at Oct 21st 9:15 AM", "2026-10-21T09:15:00+05:30")]
        [InlineData("at Oct 1st 9:15 AM", "2027-10-01T09:15:00+05:30")]
        [InlineData("at 2026-10-07 09:15", "2026-10-07T09:15:00+05:30")]
        [InlineData("on Oct 7th, 2026 9:15 AM", "2026-10-07T09:15:00+05:30")]
        [InlineData("in 2 hours", "2026-10-03T12:00:00+05:30")]
        [InlineData("in 2 hours.", "2026-10-03T12:00:00+05:30")]
        [InlineData("in 45 minutes", "2026-10-03T10:45:00+05:30")]
        [InlineData("in 3 days 4 hours 12 minutes", "2026-10-06T14:12:00+05:30")]
        [InlineData("in 1 day", "2026-10-04T10:00:00+05:30")]
        [InlineData("in an hour", "2026-10-03T11:00:00+05:30")]
        [InlineData("in 1 week", "2026-10-10T10:00:00+05:30")]
        [InlineData("in 30 seconds", "2026-10-03T10:00:30+05:30")]
        [InlineData("after 1 hr 30 mins", "2026-10-03T11:30:00+05:30")]
        public void The_time_Codex_gives_is_read(string when, string expected)
        {
            var reset = CodexErrors.ResetTime(when, Morning);

            Assert.Equal(DateTimeOffset.Parse(expected), reset);
        }

        [Theory]
        [InlineData("at some point")]
        [InlineData("in a while")]
        [InlineData("later")]
        [InlineData("at")]
        [InlineData("in 0 minutes")]
        [InlineData("")]
        [InlineData(null)]
        public void Words_that_are_not_a_time_give_none(string when) => Assert.Null(CodexErrors.ResetTime(when, Morning));

        [Fact]
        public void A_usage_limit_carries_its_plain_words_and_the_time_it_gave()
        {
            var limit = CodexErrors.UsageLimitOf(Error, Morning);

            Assert.Equal("Codex has reached its usage limit. It can answer again at 7:33 PM. For more now, see chatgpt.com/codex/settings/usage.", limit.Message);
            Assert.Equal(DateTimeOffset.Parse("2026-10-03T19:33:00+05:30"), limit.ResetsAt);
            Assert.Null(CodexErrors.UsageLimitOf("You've hit your usage limit.", Morning).ResetsAt);
            Assert.Null(CodexErrors.UsageLimitOf("You've hit your usage limit. Try again soon.", Morning).ResetsAt);
            Assert.Null(CodexErrors.UsageLimitOf("stream disconnected before completion", Morning));
            Assert.Null(CodexErrors.UsageLimitOf("", Morning));
            Assert.Equal(DateTimeOffset.Parse("2026-10-03T12:00:00+05:30"), CodexErrors.UsageLimitOf("You've hit your usage limit. Try again in 2 hours.", Morning).ResetsAt);
        }

        [Fact]
        public void Among_what_Codex_wrote_only_its_error_lines_count()
        {
            var echoed = "Question: what is the usage limit, try again at 9:00 AM?\n";
            Assert.Null(CodexErrors.UsageLimitInfoIn(echoed + "ERROR: stream disconnected before completion\n", Morning));

            var limit = CodexErrors.UsageLimitInfoIn(CodexErrorsTests.UsageLimitOutput, Morning);
            Assert.Equal(DateTimeOffset.Parse("2026-10-03T19:33:00+05:30"), limit.ResetsAt);
        }

        [Fact]
        public void The_sentence_of_a_usage_limit_is_known_again()
        {
            Assert.True(CodexErrors.IsUsageLimitMessage(CodexErrors.UsageLimit(Error)));
            Assert.True(CodexErrors.IsUsageLimitMessage("Codex has reached its usage limit. It can answer again later. For more now, see chatgpt.com/codex/settings/usage."));
            Assert.False(CodexErrors.IsUsageLimitMessage("Codex failed (exit code 1): stream disconnected"));
            Assert.False(CodexErrors.IsUsageLimitMessage("Stopped."));
            Assert.False(CodexErrors.IsUsageLimitMessage(null));
        }

        [Fact]
        public async Task A_usage_limit_from_a_run_of_Codex_carries_the_time_for_the_work_that_waits()
        {
            var settings = TestSettings.Create().Settings;
            settings.Codex.ExecutablePath = _temp.File("codex-tool");
            var runner = new FakeCliRunner { Handler = _ => new CliResult { ExitCode = 1, StandardError = CodexErrorsTests.UsageLimitOutput } };
            var codex = new CodexCliProvider(runner, () => settings, Path.Combine(_temp.Path, "runs"))
            {
                StartChannel = _ => throw new CliStartException("Could not start codex app-server", null),
            };

            var error = await Assert.ThrowsAsync<AiProviderException>(() => codex.CompleteAsync(new AiRequest { UserPrompt = "Q" }, CancellationToken.None));

            Assert.NotNull(error.UsageLimit);
            Assert.Equal(error.Message, error.UsageLimit.Message);
            Assert.NotNull(error.UsageLimit.ResetsAt);
            Assert.Null(new AiProviderException("x", "plain failure").UsageLimit);
        }

        // ----- The pause -----

        [Fact]
        public void The_pause_ends_a_minute_after_the_time_Codex_gave()
        {
            var pause = Pause();
            var changes = 0;
            pause.Changed += () => changes++;
            Assert.False(pause.IsPaused);
            Assert.Null(pause.Until);

            var until = pause.Hit(Limit(Morning.AddHours(2)));

            Assert.Equal(Morning.AddHours(2).AddMinutes(1), until);
            Assert.True(pause.IsPaused);
            Assert.Equal(until, pause.Until);
            Assert.Equal("Codex has reached its usage limit.", pause.Message);
            Assert.Equal(1, changes);
        }

        [Fact]
        public void Without_a_time_or_with_one_that_has_passed_it_is_tried_again_in_half_an_hour()
        {
            var pause = Pause();

            Assert.Equal(Morning.AddMinutes(30), pause.Hit(Limit(null)));
            Assert.Equal(Morning.AddMinutes(30), pause.Hit(Limit(Morning.AddMinutes(-5))));
        }

        [Fact]
        public void A_time_further_away_than_Codex_ever_asks_for_is_cut_to_eight_days()
        {
            Assert.Equal(Morning.AddDays(8), Pause().Hit(Limit(Morning.AddDays(40))));
        }

        [Fact]
        public void The_pause_is_over_when_the_time_has_come_and_Clear_ends_it_at_once()
        {
            var pause = Pause();
            pause.Hit(Limit(Morning.AddHours(1)));

            _time.Advance(TimeSpan.FromMinutes(59));
            Assert.True(pause.IsPaused);
            _time.Advance(TimeSpan.FromMinutes(2));
            Assert.False(pause.IsPaused);
            Assert.Equal("", pause.Message);

            var changes = 0;
            pause.Changed += () => changes++;
            pause.Clear();
            Assert.Equal(0, changes);

            pause.Hit(Limit(Morning.AddDays(1)));
            Assert.Equal(1, changes);
            pause.Clear();
            Assert.False(pause.IsPaused);
            Assert.Equal(2, changes);
        }

        [Fact]
        public async Task Work_that_waits_goes_on_when_the_time_has_come()
        {
            var pause = Pause();
            await pause.WaitAsync(CancellationToken.None);

            pause.Hit(Limit(Morning.AddHours(1)));
            var wait = pause.WaitAsync(CancellationToken.None);
            await Task.Delay(50);
            Assert.False(wait.IsCompleted);

            _time.Advance(TimeSpan.FromMinutes(61));
            await wait.WaitAsync(TimeSpan.FromSeconds(10));
            Assert.False(pause.IsPaused);
        }

        [Fact]
        public async Task The_pause_tells_when_it_ended_by_itself()
        {
            var pause = Pause();
            var ended = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            pause.Hit(Limit(Morning.AddHours(1)));
            pause.Changed += () =>
            {
                if (!pause.IsPaused)
                {
                    ended.TrySetResult(true);
                }
            };

            var wait = pause.WaitAsync(CancellationToken.None);
            _time.Advance(TimeSpan.FromMinutes(61));

            await wait.WaitAsync(TimeSpan.FromSeconds(10));
            Assert.True(await ended.Task.WaitAsync(TimeSpan.FromSeconds(10)));
        }

        [Fact]
        public async Task Clear_lets_waiting_work_go_on_at_once()
        {
            var pause = Pause();
            pause.Hit(Limit(Morning.AddDays(2)));
            var wait = pause.WaitAsync(CancellationToken.None);
            await Task.Delay(50);
            Assert.False(wait.IsCompleted);

            pause.Clear();

            await wait.WaitAsync(TimeSpan.FromSeconds(10));
        }

        [Fact]
        public async Task A_new_limit_met_meanwhile_moves_the_time_and_the_work_keeps_waiting()
        {
            var pause = Pause();
            pause.Hit(Limit(Morning.AddHours(1)));
            var wait = pause.WaitAsync(CancellationToken.None);
            await Task.Delay(50);

            pause.Hit(Limit(Morning.AddHours(5)));
            _time.Advance(TimeSpan.FromMinutes(70));
            await Task.Delay(100);
            Assert.False(wait.IsCompleted, "the first time is no longer the one waited for");

            _time.Advance(TimeSpan.FromHours(4));
            await wait.WaitAsync(TimeSpan.FromSeconds(10));
        }

        [Fact]
        public async Task Waiting_can_be_cancelled_and_leaves_nothing_running()
        {
            var pause = Pause();
            pause.Hit(Limit(Morning.AddDays(1)));
            using (var cancel = new CancellationTokenSource())
            {
                var wait = pause.WaitAsync(cancel.Token);
                await Task.Delay(50);
                cancel.Cancel();

                await Assert.ThrowsAnyAsync<OperationCanceledException>(() => wait.WaitAsync(TimeSpan.FromSeconds(10)));
            }

            Assert.Equal(0, _time.Waiting);
        }

        [Fact]
        public void The_time_is_written_as_the_owner_reads_it()
        {
            // The clock is written as the rest of the app writes it (Indian English).
            string Clock(string time) => DateTime.Parse(time, System.Globalization.CultureInfo.InvariantCulture).ToString("h:mm tt", System.Globalization.CultureInfo.GetCultureInfo("en-IN"));

            Assert.Equal(Clock("19:33"), UsageLimitPause.Describe(DateTimeOffset.Parse("2026-10-03T19:33:00+05:30"), Morning));
            Assert.Equal("tomorrow " + Clock("09:15"), UsageLimitPause.Describe(DateTimeOffset.Parse("2026-10-04T09:15:00+05:30"), Morning));
            Assert.Equal("Wed 7 Oct, " + Clock("09:15"), UsageLimitPause.Describe(DateTimeOffset.Parse("2026-10-07T09:15:00+05:30"), Morning));
            // A time given in another zone is told in the owner's.
            Assert.Equal(Clock("19:33"), UsageLimitPause.Describe(DateTimeOffset.Parse("2026-10-03T14:03:00+00:00"), Morning));
        }
    }
}
