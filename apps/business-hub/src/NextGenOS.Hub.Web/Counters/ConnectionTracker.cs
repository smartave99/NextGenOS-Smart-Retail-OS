namespace NextGenOS.Hub.Web.Counters;

/// <summary>
/// The long-lived connections of counter PCs (the live screen is one open connection per window), so that removing a counter PC, or switching counter PCs off, ends them at once instead of
/// letting an open screen go on working until its window is closed. Only connections of counter PCs on the shop's network are tracked; the main PC's own windows never are.
/// </summary>
public sealed class ConnectionTracker
{
    private readonly object _gate = new();
    private readonly Dictionary<long, List<HttpContext>> _open = new();

    /// <summary>Notes an open connection of a counter PC. Dispose it when the request ends (before the request's context is handed back).</summary>
    public IDisposable Track(long counterId, HttpContext context)
    {
        lock (_gate)
        {
            if (!_open.TryGetValue(counterId, out var list)) _open[counterId] = list = new List<HttpContext>();
            list.Add(context);
        }

        return new Lease(this, counterId, context);
    }

    /// <summary>Ends every open connection of one counter PC.</summary>
    public int Cut(long counterId)
    {
        lock (_gate)
        {
            if (!_open.TryGetValue(counterId, out var list)) return 0;
            return Abort(list);
        }
    }

    /// <summary>Ends the open connections of every counter PC.</summary>
    public int CutAll()
    {
        lock (_gate) return _open.Values.Sum(Abort);
    }

    public int Open(long counterId)
    {
        lock (_gate) return _open.TryGetValue(counterId, out var list) ? list.Count : 0;
    }

    // Done while holding the lock: a request leaves the list (in Lease.Dispose, which needs the lock) before its context can be reused, so a context in the list is always still in use.
    private static int Abort(List<HttpContext> list)
    {
        var cut = 0;
        foreach (var context in list.ToArray())
        {
            try
            {
                context.Abort();
                cut++;
            }
            catch (Exception ex) when (ex is InvalidOperationException or ObjectDisposedException)
            {
                // Already gone.
            }
        }

        return cut;
    }

    private void Release(long counterId, HttpContext context)
    {
        lock (_gate)
        {
            if (!_open.TryGetValue(counterId, out var list)) return;
            list.Remove(context);
            if (list.Count == 0) _open.Remove(counterId);
        }
    }

    private sealed class Lease(ConnectionTracker owner, long counterId, HttpContext context) : IDisposable
    {
        private int _done;

        public void Dispose()
        {
            if (Interlocked.Exchange(ref _done, 1) == 0) owner.Release(counterId, context);
        }
    }
}
