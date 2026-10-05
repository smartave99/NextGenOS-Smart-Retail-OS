using NextGenOS.Licensing;

namespace NextGenOS.Licensing.AspNetCore;

/// <summary>
/// The licence of this PC as a NextGenOS web program sees it. The licence files are shared with the Windows app and the POS (one
/// licence per PC), so activating in any one is enough. The state is looked at again every half minute, not on every
/// request, because reading the PC's identity is not free.
/// </summary>
public sealed class ProductLicence
{
    private static readonly TimeSpan MaxAge = TimeSpan.FromSeconds(30);

    private readonly Func<LicenceState> _evaluate;
    private readonly TimeProvider _time;
    private readonly object _gate = new();
    private LicenceState? _state;
    private DateTimeOffset _readAt;

    public ProductLicence(Func<LicenceState> evaluate, TimeProvider? time = null)
    {
        _evaluate = evaluate;
        _time = time ?? TimeProvider.System;
    }

    /// <summary>The licence manager of a program: it needs the given module ("dashboard", "hub", ...). The licence files are shared by all NextGenOS programs on the PC.</summary>
    public static LicenceManager CreateManager(string module, string appVersion = "0.0.0") => new(new LicenceOptions
    {
        RequiredModule = module,
        AppVersion = appVersion,
    });

    public LicenceState State
    {
        get
        {
            lock (_gate)
            {
                var now = _time.GetUtcNow();
                if (_state is null || now - _readAt >= MaxAge)
                {
                    Refresh(now);
                }

                return _state!;
            }
        }
    }

    /// <summary>True when the program may run.</summary>
    public bool IsUsable => State.IsUsable;

    /// <summary>Looks at the licence again now (after a check-in, or when the person pressed "Check again").</summary>
    public LicenceState Reload()
    {
        lock (_gate)
        {
            Refresh(_time.GetUtcNow());
            return _state!;
        }
    }

    private void Refresh(DateTimeOffset now)
    {
        try
        {
            _state = _evaluate();
        }
        catch (Exception)
        {
            // A licence that cannot be read is not a licence: stop, never carry on.
            _state = new LicenceState { Status = LicenceStatus.Invalid };
        }

        _readAt = now;
    }
}
