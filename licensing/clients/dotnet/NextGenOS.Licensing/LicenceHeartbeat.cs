using System;
using System.Threading;
using System.Threading.Tasks;

namespace NextGenOS.Licensing
{
    /// <summary>
    /// Looks at the licence again while the program runs (every half hour by default), checks in with the Licence Studio when
    /// it is time, and tells the program when the licence is no longer usable. So a withdrawn or ended licence stops the
    /// program in a running shop too, and the check is not one single "if" at start-up that can be patched out.
    /// </summary>
    public sealed class LicenceHeartbeat : IDisposable
    {
        private readonly LicenceManager _manager;
        private readonly Action<LicenceState> _onLost;
        private readonly Timer _timer;
        private readonly TimeSpan _interval;
        private int _busy;

        public LicenceHeartbeat(LicenceManager manager, Action<LicenceState> onLost, TimeSpan? interval = null)
        {
            _manager = manager;
            _onLost = onLost;
            _interval = interval ?? TimeSpan.FromMinutes(30);
            _timer = new Timer(_ => { try { TickAsync().GetAwaiter().GetResult(); } catch (Exception) { } }, null, Timeout.Infinite, Timeout.Infinite);
        }

        public LicenceState Last { get; private set; }

        public void Start()
        {
            _timer.Change(_interval, _interval);
        }

        /// <summary>One look: check in if due, evaluate, and call the "lost" action when the program may not go on.</summary>
        public async Task<LicenceState> TickAsync()
        {
            if (Interlocked.Exchange(ref _busy, 1) == 1) return Last;
            try
            {
                var state = await _manager.CheckInAsync().ConfigureAwait(false);
                Last = state;
                if (!state.IsUsable) _onLost(state);
                return state;
            }
            finally
            {
                Interlocked.Exchange(ref _busy, 0);
            }
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
