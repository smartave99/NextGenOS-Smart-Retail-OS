using NextGenOS.Licensing;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// The licence of this PC as the dashboard sees it. The licence files are shared with the Windows app and the POS (one
/// licence per PC), so activating in either one is enough. The state is looked at again every half minute, not on every
/// request, because reading the PC's identity is not free.
/// </summary>
public sealed class DashboardLicence
{
    /// <summary>The module of the licence this program needs.</summary>
    public const string Module = "dashboard";

    private static readonly TimeSpan MaxAge = TimeSpan.FromSeconds(30);

    private readonly Func<LicenceState> _evaluate;
    private readonly TimeProvider _time;
    private readonly object _gate = new();
    private LicenceState? _state;
    private DateTimeOffset _readAt;

    public DashboardLicence(Func<LicenceState> evaluate, TimeProvider? time = null)
    {
        _evaluate = evaluate;
        _time = time ?? TimeProvider.System;
    }

    /// <summary>The licence manager for the dashboard (module "dashboard").</summary>
    public static LicenceManager CreateManager() => new(new LicenceOptions
    {
        RequiredModule = Module,
        AppVersion = typeof(DashboardLicence).Assembly.GetName().Version?.ToString() ?? "0.0.0",
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

    /// <summary>True when the dashboard may run.</summary>
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
