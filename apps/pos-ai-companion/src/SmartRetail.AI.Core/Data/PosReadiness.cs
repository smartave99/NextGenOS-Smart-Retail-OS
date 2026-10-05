using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRetail.AI.Data
{
    /// <summary>
    /// When Windows starts the app at sign-in, SQL Server may not answer yet: a shop PC that signs in by itself after a power cut
    /// does so a few seconds after it starts, and the POS database takes a while to come up. The dashboard looks for the POS
    /// database once, when it starts, and shows the demo shop for the whole run if it finds nothing, so the app first gives the
    /// database time to answer. Only reads.
    /// </summary>
    public static class PosReadiness
    {
        /// <summary>How long the app started by Windows waits before it starts the dashboard anyway (the database may be on a PC that is off).</summary>
        public static readonly TimeSpan AtSignIn = TimeSpan.FromMinutes(3);

        /// <summary>How long the app opened by hand waits: the PC has been running for a while, so the database answers or is really down.</summary>
        public static readonly TimeSpan WhenOpenedByHand = TimeSpan.FromSeconds(10);

        /// <summary>How long to rest between two questions.</summary>
        public static readonly TimeSpan Every = TimeSpan.FromSeconds(3);

        public const string Waiting = "Waiting for the POS database to start…";

        /// <summary>
        /// Asks <paramref name="answers"/> until it says yes or <paramref name="patience"/> has passed on the clock, however long each
        /// question took. Returns whether the database answered; when it did not, the caller goes on as it always did.
        /// </summary>
        /// <param name="now">The clock; a test moves it.</param>
        /// <param name="delay">The rest between two questions; a test moves the clock with it.</param>
        public static async Task<bool> WaitAsync(
            Func<CancellationToken, Task<bool>> answers,
            TimeSpan patience,
            IProgress<string> progress,
            CancellationToken cancellationToken,
            Func<DateTime> now = null,
            Func<TimeSpan, CancellationToken, Task> delay = null)
        {
            if (answers == null)
            {
                throw new ArgumentNullException(nameof(answers));
            }

            now = now ?? (() => DateTime.UtcNow);
            delay = delay ?? Task.Delay;
            var started = now();
            var told = false;
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (await answers(cancellationToken).ConfigureAwait(false))
                {
                    return true;
                }

                var left = patience - (now() - started);
                if (left <= TimeSpan.Zero)
                {
                    return false;
                }

                if (!told)
                {
                    told = true;
                    progress?.Report(Waiting);
                }

                await delay(left < Every ? left : Every, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
