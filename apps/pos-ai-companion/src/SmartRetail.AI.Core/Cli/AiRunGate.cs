using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRetail.AI.Cli
{
    /// <summary>
    /// Lets the AI tool be replaced by a newer one without a run of it meeting a half-replaced tool. Every run of the tool
    /// goes in through the gate (<see cref="GatedCliRunner"/>); the updater closes the gate only at a moment when no run is
    /// in progress, so nothing that started is ever cut off, and runs that ask while it is closed wait for the few moments
    /// the replacing takes and go on when it opens again.
    /// </summary>
    public sealed class AiRunGate
    {
        private readonly object _lock = new object();
        private int _running;
        private bool _closed;
        private TaskCompletionSource<bool> _opened = Opened();

        /// <summary>Runs of the tool in progress now.</summary>
        public int Running
        {
            get
            {
                lock (_lock)
                {
                    return _running;
                }
            }
        }

        public bool IsClosed
        {
            get
            {
                lock (_lock)
                {
                    return _closed;
                }
            }
        }

        /// <summary>A run begins: waits while the gate is closed. Dispose the result when the run has ended.</summary>
        public async Task<IDisposable> EnterAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                Task waiting;
                lock (_lock)
                {
                    if (!_closed)
                    {
                        _running++;
                        return new Leaving(this);
                    }

                    waiting = _opened.Task;
                }

                await Cancellable(waiting, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>Closes the gate when no run is in progress and it is not closed already; false, and nothing changed, otherwise.</summary>
        public bool TryClose()
        {
            lock (_lock)
            {
                if (_closed || _running > 0)
                {
                    return false;
                }

                _closed = true;
                _opened = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                return true;
            }
        }

        /// <summary>Opens the gate again: the runs that waited go on.</summary>
        public void Open()
        {
            TaskCompletionSource<bool> opened;
            lock (_lock)
            {
                if (!_closed)
                {
                    return;
                }

                _closed = false;
                opened = _opened;
            }

            opened.TrySetResult(true);
        }

        private void Left()
        {
            lock (_lock)
            {
                if (_running > 0)
                {
                    _running--;
                }
            }
        }

        private static TaskCompletionSource<bool> Opened()
        {
            var opened = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            opened.SetResult(true);
            return opened;
        }

        private static async Task Cancellable(Task task, CancellationToken cancellationToken)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                await task.ConfigureAwait(false);
                return;
            }

            var cancelled = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            using (cancellationToken.Register(() => cancelled.TrySetResult(true)))
            {
                if (await Task.WhenAny(task, cancelled.Task).ConfigureAwait(false) == cancelled.Task)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }
        }

        private sealed class Leaving : IDisposable
        {
            private readonly AiRunGate _gate;
            private int _left;

            public Leaving(AiRunGate gate) => _gate = gate;

            public void Dispose()
            {
                if (Interlocked.Exchange(ref _left, 1) == 0)
                {
                    _gate.Left();
                }
            }
        }
    }

    /// <summary>Runs a tool only through <see cref="AiRunGate"/>, so it can be replaced between runs.</summary>
    public sealed class GatedCliRunner : ICliRunner
    {
        private readonly ICliRunner _inner;
        private readonly AiRunGate _gate;

        public GatedCliRunner(ICliRunner inner, AiRunGate gate)
        {
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
            _gate = gate ?? throw new ArgumentNullException(nameof(gate));
        }

        public async Task<CliResult> RunAsync(CliInvocation invocation, CancellationToken cancellationToken)
        {
            using (await _gate.EnterAsync(cancellationToken).ConfigureAwait(false))
            {
                return await _inner.RunAsync(invocation, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
