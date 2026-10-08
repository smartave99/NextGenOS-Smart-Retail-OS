namespace NextGenOS.Hub.Counters;

/// <summary>
/// Counts wrong attempts, per name (an address) and in all, inside a sliding window, and says when a name is locked out. Kept in memory: a restart forgives everyone, and nobody on the
/// network can restart the Hub. The number of names it remembers is capped, so that nobody can make it grow without end.
/// </summary>
internal sealed class AttemptLimiter(IClock clock, int perName, int inAll, TimeSpan window, int maxNames = 2000)
{
    private readonly object _gate = new();
    private readonly Dictionary<string, List<DateTimeOffset>> _byName = new(StringComparer.Ordinal);
    private readonly List<DateTimeOffset> _all = new();

    /// <summary>How long this name must still wait, or null when it may try.</summary>
    public TimeSpan? WaitFor(string name)
    {
        lock (_gate)
        {
            var now = clock.UtcNow;
            Prune(_all, now);
            TimeSpan? wait = null;
            if (_all.Count >= inAll) wait = _all[0] + window - now;
            if (_byName.TryGetValue(name, out var mine))
            {
                Prune(mine, now);
                if (mine.Count >= perName)
                {
                    var own = mine[0] + window - now;
                    if (wait is null || own > wait) wait = own;
                }
            }

            return wait is { } w && w > TimeSpan.Zero ? w : null;
        }
    }

    public void Fail(string name)
    {
        lock (_gate)
        {
            var now = clock.UtcNow;
            Prune(_all, now);
            _all.Add(now);
            if (!_byName.TryGetValue(name, out var mine))
            {
                if (_byName.Count >= maxNames) Trim(now);
                _byName[name] = mine = new List<DateTimeOffset>();
            }

            Prune(mine, now);
            mine.Add(now);
        }
    }

    /// <summary>Forgives one name (it did something right).</summary>
    public void Forgive(string name)
    {
        lock (_gate) _byName.Remove(name);
    }

    private void Prune(List<DateTimeOffset> times, DateTimeOffset now) => times.RemoveAll(t => t + window <= now);

    /// <summary>Makes room: drops the names whose attempts are all old, and, when every name is recent, the oldest quarter.</summary>
    private void Trim(DateTimeOffset now)
    {
        foreach (var key in _byName.Where(p => p.Value.All(t => t + window <= now)).Select(p => p.Key).ToList()) _byName.Remove(key);
        if (_byName.Count < maxNames) return;
        foreach (var key in _byName.OrderBy(p => p.Value.Count == 0 ? DateTimeOffset.MinValue : p.Value[^1]).Take(Math.Max(1, maxNames / 4)).Select(p => p.Key).ToList()) _byName.Remove(key);
    }
}

/// <summary>
/// Decides whether a refusal may be written to the audit log. The log is only ever added to, so a computer on the network that keeps knocking must not be able to fill it: each address is
/// written once in a while (with how many tries were skipped), and the whole program writes only so many refusals in an hour.
/// </summary>
internal sealed class RefusalThrottle(IClock clock, TimeSpan perAddress, int perHour)
{
    private readonly object _gate = new();
    private readonly Dictionary<string, (DateTimeOffset At, int Skipped)> _last = new(StringComparer.Ordinal);
    private readonly Queue<DateTimeOffset> _hour = new();

    /// <summary>True when this one may be written; <paramref name="skipped"/> is how many like it were left out since the last one written for this address.</summary>
    public bool May(string address, out int skipped)
    {
        lock (_gate)
        {
            var now = clock.UtcNow;
            while (_hour.Count > 0 && _hour.Peek() + TimeSpan.FromHours(1) <= now) _hour.Dequeue();
            skipped = 0;
            if (_last.TryGetValue(address, out var seen))
            {
                if (seen.At + perAddress > now)
                {
                    _last[address] = (seen.At, seen.Skipped + 1);
                    return false;
                }

                skipped = seen.Skipped;
            }

            if (_hour.Count >= perHour)
            {
                _last[address] = (_last.TryGetValue(address, out var s2) ? s2.At : now, skipped + 1);
                return false;
            }

            if (_last.Count > 2000) foreach (var key in _last.Where(p => p.Value.At + perAddress <= now).Select(p => p.Key).ToList()) _last.Remove(key);
            if (_last.Count > 2000) _last.Clear();
            _last[address] = (now, 0);
            _hour.Enqueue(now);
            return true;
        }
    }
}
