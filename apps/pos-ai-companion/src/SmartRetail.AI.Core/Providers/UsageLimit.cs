using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRetail.AI.Providers
{
    /// <summary>The account's usage limit, as Codex reported it: in plain words for the owner, and when it can answer again, if it said.</summary>
    public sealed class UsageLimitInfo
    {
        public UsageLimitInfo(string message, DateTimeOffset? resetsAt = null)
        {
            Message = message ?? "";
            ResetsAt = resetsAt;
        }

        /// <summary>E.g. "Codex has reached its usage limit. It can answer again at 7:33 PM. For more now, see chatgpt.com/codex/settings/usage."</summary>
        public string Message { get; }

        /// <summary>When Codex said it can answer again; null when it did not say, or not in words that are understood.</summary>
        public DateTimeOffset? ResetsAt { get; }
    }

    /// <summary>
    /// Where the account's usage limit stands. Everything that makes things in the background with Codex (photos, listings, posters'
    /// artwork, creatives) goes in one account, so when one of them meets the limit they all wait until it can answer again, and
    /// then carry on from where they stopped: nothing is marked as failed, and nobody has to press Continue. The time is the one
    /// Codex gave (a minute later, so it has surely passed); without one, a try is made every half hour.
    /// </summary>
    public sealed class UsageLimitPause
    {
        /// <summary>Added to the time Codex gave, so that the limit has surely lifted when it is asked again.</summary>
        public static readonly TimeSpan Margin = TimeSpan.FromMinutes(1);

        /// <summary>How long to wait when Codex did not say when it can answer again.</summary>
        public static readonly TimeSpan UnknownWait = TimeSpan.FromMinutes(30);

        /// <summary>The longest wait: Codex's limits reset within a week.</summary>
        public static readonly TimeSpan LongestWait = TimeSpan.FromDays(8);

        private readonly object _gate = new object();
        private readonly Func<DateTimeOffset> _now;
        private readonly Func<TimeSpan, CancellationToken, Task> _delay;
        private DateTimeOffset? _until;
        private string _message = "";
        private TaskCompletionSource<bool> _changed = NewSignal();

        /// <param name="now">The time now; the clock when not given.</param>
        /// <param name="delay">Waits that long, until cancelled; <see cref="Task.Delay(TimeSpan, CancellationToken)"/> when not given.</param>
        public UsageLimitPause(Func<DateTimeOffset> now = null, Func<TimeSpan, CancellationToken, Task> delay = null)
        {
            _now = now ?? (() => DateTimeOffset.Now);
            _delay = delay ?? ((time, token) => Task.Delay(time, token));
        }

        /// <summary>Raised, on any thread, when the pause begins, is moved or ends.</summary>
        public event Action Changed;

        /// <summary>True while Codex is waited for.</summary>
        public bool IsPaused => Until != null;

        /// <summary>When the work carries on; null when it is not paused.</summary>
        public DateTimeOffset? Until
        {
            get
            {
                lock (_gate)
                {
                    return CurrentUntil();
                }
            }
        }

        /// <summary>What Codex said, in plain words; empty when it is not paused.</summary>
        public string Message
        {
            get
            {
                lock (_gate)
                {
                    return CurrentUntil() == null ? "" : _message;
                }
            }
        }

        /// <summary>Codex answered that the account is at its limit: everything waits. Returns when the work carries on.</summary>
        public DateTimeOffset Hit(UsageLimitInfo limit)
        {
            if (limit == null)
            {
                throw new ArgumentNullException(nameof(limit));
            }

            DateTimeOffset until;
            lock (_gate)
            {
                var now = _now();
                var wait = limit.ResetsAt.HasValue && limit.ResetsAt.Value > now ? limit.ResetsAt.Value - now + Margin : UnknownWait;
                until = now + (wait > LongestWait ? LongestWait : wait);
                _until = until;
                _message = limit.Message;
                Release();
            }

            Changed?.Invoke();
            return until;
        }

        /// <summary>Stops waiting now, e.g. because the owner bought more usage: the work tries again at once.</summary>
        public void Clear()
        {
            bool was;
            lock (_gate)
            {
                was = _until != null;
                _until = null;
                _message = "";
                Release();
            }

            if (was)
            {
                Changed?.Invoke();
            }
        }

        /// <summary>Returns when Codex is no longer waited for: at once when it is not paused, else when the time has come or
        /// <see cref="Clear"/> is called. Waits again when a new limit moves the time meanwhile.</summary>
        public async Task WaitAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                Task signal;
                TimeSpan wait;
                lock (_gate)
                {
                    var until = CurrentUntil();
                    if (until == null)
                    {
                        return;
                    }

                    wait = until.Value - _now();
                    signal = _changed.Task;
                }

                var timeCame = false;
                using (var stop = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
                {
                    var delay = _delay(wait < TimeSpan.Zero ? TimeSpan.Zero : wait, stop.Token);
                    timeCame = await Task.WhenAny(delay, signal).ConfigureAwait(false) == delay;
                    stop.Cancel();
                    try
                    {
                        await delay.ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                        // Stopped waiting for the time: it is looked at again.
                        timeCame = false;
                    }
                }

                if (timeCame && !IsPaused)
                {
                    // The pause ended by itself: whoever shows it learns that the work carries on.
                    Changed?.Invoke();
                }
            }
        }

        /// <summary>The time as the owner reads it: "7:33 PM", "tomorrow 7:33 PM", or "Mon 7 Oct, 9:15 AM" when further away.</summary>
        public static string Describe(DateTimeOffset when, DateTimeOffset now)
        {
            var culture = CultureInfo.GetCultureInfo("en-IN");
            var local = when.ToOffset(now.Offset);
            var time = local.ToString("h:mm tt", culture);
            var days = (local.Date - now.Date).Days;
            if (days <= 0)
            {
                return time;
            }

            return days == 1 ? "tomorrow " + time : local.ToString("ddd d MMM, ", culture) + time;
        }

        /// <summary>Called with the lock held: the time, or null when it has passed (which ends the pause).</summary>
        private DateTimeOffset? CurrentUntil()
        {
            if (_until != null && _until.Value <= _now())
            {
                _until = null;
                _message = "";
            }

            return _until;
        }

        /// <summary>Called with the lock held: everyone waiting looks at the time again.</summary>
        private void Release()
        {
            var old = _changed;
            _changed = NewSignal();
            old.TrySetResult(true);
        }

        private static TaskCompletionSource<bool> NewSignal() => new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
    }
}
