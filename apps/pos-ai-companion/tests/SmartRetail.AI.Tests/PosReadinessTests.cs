using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Data;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>
    /// The app started by Windows waits for the POS database before it starts the dashboard, which looks for the database only
    /// once and shows the demo shop if it finds nothing.
    /// </summary>
    public class PosReadinessTests
    {
        private sealed class Clock
        {
            public DateTime Now { get; private set; } = new DateTime(2026, 9, 30, 8, 0, 0, DateTimeKind.Utc);

            public List<TimeSpan> Rests { get; } = new List<TimeSpan>();

            public void Pass(TimeSpan time) => Now += time;

            public Task Delay(TimeSpan time, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();
                Rests.Add(time);
                Pass(time);
                return Task.CompletedTask;
            }
        }

        private sealed class Said : IProgress<string>
        {
            public List<string> Lines { get; } = new List<string>();

            public void Report(string value) => Lines.Add(value);
        }

        [Fact]
        public async Task A_database_that_answers_at_once_is_not_waited_for()
        {
            var clock = new Clock();
            var said = new Said();

            var answered = await PosReadiness.WaitAsync(_ => Task.FromResult(true), TimeSpan.FromMinutes(3), said, CancellationToken.None, () => clock.Now, clock.Delay);

            Assert.True(answered);
            Assert.Empty(clock.Rests);
            Assert.Empty(said.Lines);
        }

        [Fact]
        public async Task It_asks_again_until_the_database_answers_and_says_once_that_it_is_waiting()
        {
            var clock = new Clock();
            var said = new Said();
            var asked = 0;

            var answered = await PosReadiness.WaitAsync(_ => Task.FromResult(++asked == 4), TimeSpan.FromMinutes(3), said, CancellationToken.None, () => clock.Now, clock.Delay);

            Assert.True(answered);
            Assert.Equal(4, asked);
            Assert.Equal(new[] { PosReadiness.Every, PosReadiness.Every, PosReadiness.Every }, clock.Rests);
            Assert.Equal(new[] { "Waiting for the POS database to start…" }, said.Lines);
        }

        [Fact]
        public async Task It_gives_up_when_the_patience_has_passed_on_the_clock_however_long_each_question_takes()
        {
            var clock = new Clock();
            var started = clock.Now;
            var patience = TimeSpan.FromSeconds(60);
            var question = TimeSpan.FromSeconds(5); // a server that does not answer keeps the connection waiting

            var answered = await PosReadiness.WaitAsync(
                _ =>
                {
                    clock.Pass(question);
                    return Task.FromResult(false);
                },
                patience, null, CancellationToken.None, () => clock.Now, clock.Delay);

            Assert.False(answered);
            var spent = clock.Now - started;
            Assert.True(spent >= patience, "it waited the whole patience: " + spent);
            Assert.True(spent < patience + question + PosReadiness.Every, "and not much longer: " + spent);
        }

        [Fact]
        public async Task The_last_rest_is_cut_short_and_the_database_is_asked_once_more_at_the_end()
        {
            var clock = new Clock();
            var asked = 0;

            var answered = await PosReadiness.WaitAsync(
                _ =>
                {
                    asked++;
                    return Task.FromResult(false);
                },
                TimeSpan.FromSeconds(4), null, CancellationToken.None, () => clock.Now, clock.Delay);

            Assert.False(answered);
            Assert.Equal(new[] { TimeSpan.FromSeconds(3), TimeSpan.FromSeconds(1) }, clock.Rests);
            Assert.Equal(3, asked); // at 0, 3 and 4 seconds
        }

        [Fact]
        public async Task No_patience_asks_once_and_waits_for_nothing()
        {
            var clock = new Clock();
            var said = new Said();
            var asked = 0;

            var answered = await PosReadiness.WaitAsync(
                _ =>
                {
                    asked++;
                    return Task.FromResult(false);
                },
                TimeSpan.Zero, said, CancellationToken.None, () => clock.Now, clock.Delay);

            Assert.False(answered);
            Assert.Equal(1, asked);
            Assert.Empty(clock.Rests);
            Assert.Empty(said.Lines);
        }

        [Fact]
        public async Task Cancelling_stops_the_wait()
        {
            var clock = new Clock();
            using (var cancel = new CancellationTokenSource())
            {
                var asked = 0;

                await Assert.ThrowsAnyAsync<OperationCanceledException>(() => PosReadiness.WaitAsync(
                    _ =>
                    {
                        if (++asked == 2)
                        {
                            cancel.Cancel();
                        }

                        return Task.FromResult(false);
                    },
                    TimeSpan.FromMinutes(3), null, cancel.Token, () => clock.Now, clock.Delay));

                Assert.Equal(2, asked);
            }
        }

        [Fact]
        public void A_start_with_Windows_waits_longer_than_one_the_owner_made_by_hand()
        {
            Assert.True(PosReadiness.AtSignIn > PosReadiness.WhenOpenedByHand);
            Assert.True(PosReadiness.WhenOpenedByHand > TimeSpan.Zero);
        }
    }
}
