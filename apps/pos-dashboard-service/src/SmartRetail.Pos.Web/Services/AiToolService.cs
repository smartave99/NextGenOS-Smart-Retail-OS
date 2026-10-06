using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// Claude Code and Antigravity, the two AI tools besides Codex, as the screens see them: the models each takes (kept for a few minutes, so opening a panel is quick),
/// the last look at their version, and updating one. Codex has its own service (<see cref="CodexUpdateService"/>). An update changes this PC, so it is only done when the owner asks,
/// and one at a time.
/// </summary>
public sealed class AiToolService
{
    private static readonly TimeSpan KeepModels = TimeSpan.FromMinutes(5);

    private readonly Func<ICliToolCare> _care;
    private readonly Func<DateTime> _now;
    private readonly Dictionary<string, (DateTime At, CliModelList List)> _models = new();
    private readonly Dictionary<string, CliUpdateCheck> _checks = new();
    private readonly object _gate = new();

    public AiToolService(AiEnvironment ai)
        : this(ai.CreateToolCare, () => DateTime.Now)
    {
    }

    public AiToolService(Func<ICliToolCare> care, Func<DateTime> now)
    {
        _care = care;
        _now = now;
    }

    /// <summary>What it is doing now ("Looking at Claude Code…", "Updating Claude Code…"); empty when idle.</summary>
    public string Doing { get; private set; } = "";

    public bool IsBusy => Doing.Length > 0;

    /// <summary>The last look at each tool (by provider id), or null when it was not looked at yet.</summary>
    public CliUpdateCheck? LastCheck(string tool)
    {
        lock (_gate)
        {
            return _checks.TryGetValue(tool, out var check) ? check : null;
        }
    }

    public CliUpdateResult? LastUpdate { get; private set; }

    public string? LastProblem { get; private set; }

    public event Action? Changed;

    /// <summary>The models a tool takes. <paramref name="fresh"/>: ask again now, not the list kept a few minutes ago.</summary>
    public async Task<CliModelList> ModelsAsync(string tool, bool fresh, CancellationToken cancellationToken)
    {
        lock (_gate)
        {
            if (!fresh && _models.TryGetValue(tool, out var kept) && _now() - kept.At < KeepModels)
            {
                return kept.List;
            }
        }

        var list = await _care().ModelsAsync(tool, cancellationToken);
        lock (_gate)
        {
            _models[tool] = (_now(), list);
        }

        return list;
    }

    /// <summary>Looks at the tool's version and whether a newer one is out. Changes nothing.</summary>
    public async Task<CliUpdateCheck?> CheckAsync(string tool, CancellationToken cancellationToken)
    {
        if (!Begin("Looking at the version…"))
        {
            return LastCheck(tool);
        }

        try
        {
            var check = await _care().CheckUpdateAsync(tool, cancellationToken);
            lock (_gate)
            {
                _checks[tool] = check;
            }

            LastProblem = null;
            return check;
        }
        catch (CliToolException ex)
        {
            LastProblem = ex.Message;
            return null;
        }
        finally
        {
            End();
        }
    }

    /// <summary>Brings the tool up to date, when the owner asked. The version is looked at again afterwards.</summary>
    public async Task<CliUpdateResult?> UpdateAsync(string tool, CancellationToken cancellationToken)
    {
        if (!Begin("Updating…"))
        {
            return null;
        }

        try
        {
            var result = await _care().UpdateAsync(tool, cancellationToken);
            LastUpdate = result;
            LastProblem = null;
            lock (_gate)
            {
                _checks.Remove(tool);
                _models.Remove(tool);
            }

            return result;
        }
        catch (CliToolException ex)
        {
            LastProblem = ex.Message;
            return null;
        }
        finally
        {
            End();
        }
    }

    private bool Begin(string doing)
    {
        lock (_gate)
        {
            if (IsBusy)
            {
                return false;
            }

            Doing = doing;
        }

        Changed?.Invoke();
        return true;
    }

    private void End()
    {
        lock (_gate)
        {
            Doing = "";
        }

        Changed?.Invoke();
    }
}
