using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NextGenOS.Licensing.Windows
{
    /// <summary>
    /// What a NextGenOS desktop program does about its licence, in one place so every program does it the same way:
    /// look at the licence at start-up, show the activation window when there is none, keep looking while the program runs,
    /// and stop the program when the licence is withdrawn or ends. The licence files are shared by all programs on the PC.
    /// </summary>
    public sealed class LicenceGuard : IDisposable
    {
        private readonly LicenceManager _manager;
        private readonly string _productName;
        private readonly Action _stop;
        private LicenceHeartbeat _heartbeat;
        private int _closing;

        /// <param name="manager">The licence manager, built with the module this program needs (for example "ai").</param>
        /// <param name="productName">The name in message titles, for example "Smart Retail POS AI Assistant".</param>
        /// <param name="stop">What stops the program when the licence is lost. Defaults to Environment.Exit(0).</param>
        public LicenceGuard(LicenceManager manager, string productName, Action stop = null)
        {
            if (manager == null) throw new ArgumentNullException("manager");
            _manager = manager;
            _productName = productName;
            _stop = stop ?? (() => Environment.Exit(0));
        }

        public LicenceManager Manager { get { return _manager; } }

        /// <summary>
        /// Call before the program shows anything. Returns true when it may go on. When there is no usable licence it opens the
        /// activation window; the answer is true only if that ended with a usable licence. With <paramref name="interactive"/>
        /// false (a program started quietly with Windows) it never opens a window and just says whether it may go on.
        /// </summary>
        public bool EnsureLicensed(bool interactive = true)
        {
            var state = _manager.Evaluate();
            if (!state.IsUsable && interactive)
            {
                using (var window = new ActivationForm(_manager))
                {
                    window.ShowDialog();
                    state = _manager.Evaluate();
                }
            }

            if (!state.IsUsable) return false;
            StartWatching();
            return true;
        }

        /// <summary>Checks in quietly now and then and tells the person when the licence is lost. The program never waits for the network.</summary>
        private void StartWatching()
        {
            if (_heartbeat != null) return;
            _heartbeat = new LicenceHeartbeat(_manager, OnLost);
            _heartbeat.Start();
            Task.Run(async () => { try { await _manager.CheckInAsync().ConfigureAwait(false); } catch (Exception) { } });
        }

        private void OnLost(LicenceState state)
        {
            if (Interlocked.Exchange(ref _closing, 1) == 1) return;
            try
            {
                MessageBox.Show(state.Message + "\n\nThe program will close now.", _productName + " licence", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception) { }
            _stop();
        }

        public void Dispose()
        {
            if (_heartbeat != null) _heartbeat.Dispose();
        }
    }
}
