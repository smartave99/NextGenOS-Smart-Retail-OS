using Microsoft.Extensions.Options;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Providers;

namespace SmartRetail.Pos.Web.Services;

/// <summary>How the dashboard keeps Codex up to date. The defaults are what shops use; a test can set the others.</summary>
public sealed class CodexUpdateOptions
{
    public const string SectionName = "CodexUpdate";

    /// <summary>Where the newest Codex is asked, when not OpenAI's own release channel: https, or this PC (for tests).</summary>
    public string ChannelUrl { get; set; } = "";

    /// <summary>The second place asked, when not GitHub's list of Codex releases.</summary>
    public string GitHubUrl { get; set; } = "";

    /// <summary>How long after the app starts Codex is looked at first, in seconds.</summary>
    public int FirstLookSeconds { get; set; } = 120;

    /// <summary>How often Codex is looked at, in seconds: six hours.</summary>
    public int EverySeconds { get; set; } = 6 * 60 * 60;
}

/// <summary>
/// Keeps Codex, the AI tool, up to date (<see cref="CodexUpdater"/>). Codex only looks for a newer version in its own terminal
/// screen, which this app never opens, so nothing else would update it. The dashboard looks at what is newest every few hours;
/// unless the owner turned it off, a release that has settled for a day is installed at a moment when no AI task is running,
/// with OpenAI's own installer, and taken off again (the one that worked is put back) if the new Codex lacks something this app
/// needs. Every run of Codex goes in through one <see cref="AiRunGate"/>, which is what makes the moment a safe one.
/// The owner can look or update at once from Settings. Nothing here touches the POS or the shop's data.
/// </summary>
public sealed class CodexUpdateService
{
    private static readonly HttpClient Http = new() { Timeout = Timeout.InfiniteTimeSpan };

    private readonly CodexUpdater _updater;
    private readonly Func<string> _releasesFolder;
    private readonly ILogger<CodexUpdateService> _log;
    private readonly object _sync = new();
    private int _running;
    private string _doing = "";
    private string _progress = "";
    private CodexUpdateResult? _last;

    public CodexUpdateService(AiEnvironment ai, AiRunGate gate, IOptions<CodexUpdateOptions> options, TimeProvider clock, ILogger<CodexUpdateService> log)
        : this(Build(ai, gate, options.Value, clock), options.Value, log)
    {
    }

    /// <summary>For tests: an updater with stand-ins, and the folder the installer keeps its releases in.</summary>
    internal CodexUpdateService(CodexUpdater updater, CodexUpdateOptions options, ILogger<CodexUpdateService> log, Func<string>? releasesFolder = null)
    {
        _updater = updater;
        Options = options;
        _log = log;
        _releasesFolder = releasesFolder ?? (() => CodexReleasePruner.ReleasesFolder(CodexReleasePruner.DefaultCodexHome()));
    }

    private static CodexUpdater Build(AiEnvironment ai, AiRunGate gate, CodexUpdateOptions options, TimeProvider clock)
    {
        var folder = Path.GetDirectoryName(Path.GetFullPath(ai.SettingsFile)) ?? "";
        var feed = string.IsNullOrWhiteSpace(options.ChannelUrl)
            ? new CodexReleaseFeed(Http)
            : new CodexReleaseFeed(Http, options.ChannelUrl, string.IsNullOrWhiteSpace(options.GitHubUrl) ? CodexReleaseFeed.GitHubUrl : options.GitHubUrl);

        // Codex is asked and installed through runners that are not behind the gate: the gate is closed while it is replaced.
        var tool = new CodexTool(ai.LoadSettings, new ProcessCliRunner(), new CodexInstaller(new ProcessCliRunner()));
        return new CodexUpdater(tool, feed, gate, new CodexUpdateFile(folder), () => clock.GetLocalNow().DateTime);
    }

    public CodexUpdateOptions Options { get; }

    /// <summary>A look or an update started, moved on or ended. Raised on any thread.</summary>
    public event Action? Changed;

    /// <summary>What the owner chose, and what was kept of the last look and update.</summary>
    public CodexUpdateState State => _updater.State;

    /// <summary>What the last look or update since the app started said; null before the first.</summary>
    public CodexUpdateResult? Last
    {
        get
        {
            lock (_sync)
            {
                return _last;
            }
        }
    }

    public bool IsBusy => Volatile.Read(ref _running) == 1;

    /// <summary>"Looking for a newer Codex…" or "Updating Codex…" while one is going on, else empty.</summary>
    public string Doing
    {
        get
        {
            lock (_sync)
            {
                return _doing;
            }
        }
    }

    /// <summary>The last line the installer printed during an update.</summary>
    public string Progress
    {
        get
        {
            lock (_sync)
            {
                return _progress;
            }
        }
    }

    /// <summary>Something the bell shows: a newer Codex is out and the owner turned automatic updates off; otherwise null.</summary>
    public (string Title, string Detail)? NeedsYou =>
        Last is { Outcome: CodexUpdateOutcome.Available } available && !State.Automatic
            ? ($"Codex {available.Latest} is out", "Automatic updates are off. Update it in Settings.")
            : null;

    public void SetAutomatic(bool automatic)
    {
        _updater.SetAutomatic(automatic);
        Changed?.Invoke();
    }

    /// <summary>Looks at what is installed and what is newest; changes nothing on the PC.</summary>
    public Task<CodexUpdateResult> CheckAsync(CancellationToken cancellationToken) =>
        RunAsync(Looking, () => _updater.CheckAsync(cancellationToken));

    /// <summary>
    /// Updates Codex now, at a moment when no AI task is running. <paramref name="ownerAsked"/>: the owner pressed the button, so a
    /// release only hours old, or one an earlier try showed does not fit, is tried too.
    /// </summary>
    public Task<CodexUpdateResult> UpdateAsync(bool ownerAsked, CancellationToken cancellationToken) =>
        RunAsync(Looking, () => _updater.UpdateAsync(ownerAsked, SetProgress, cancellationToken, replacing: () => SetDoing(Updating)));

    /// <summary>What the worker does every few hours: look, and update too unless the owner turned that off.</summary>
    public Task<CodexUpdateResult> RunScheduledAsync(CancellationToken cancellationToken) =>
        State.Automatic ? UpdateAsync(false, cancellationToken) : CheckAsync(cancellationToken);

    private const string Looking = "Looking for a newer Codex…";

    /// <summary>What <see cref="Doing"/> says while Codex is really being replaced, and AI tasks wait.</summary>
    public const string Updating = "Updating Codex…";

    private void SetDoing(string doing)
    {
        lock (_sync)
        {
            _doing = doing;
        }

        Changed?.Invoke();
    }

    private void SetProgress(string line)
    {
        lock (_sync)
        {
            _progress = line;
        }

        Changed?.Invoke();
    }

    private async Task<CodexUpdateResult> RunAsync(string doing, Func<Task<CodexUpdateResult>> work)
    {
        if (Interlocked.CompareExchange(ref _running, 1, 0) != 0)
        {
            return new CodexUpdateResult { Outcome = CodexUpdateOutcome.Waiting, Message = "Codex is being looked at now." };
        }

        lock (_sync)
        {
            _doing = doing;
            _progress = "";
        }

        Changed?.Invoke();
        try
        {
            var result = await work().ConfigureAwait(false);
            lock (_sync)
            {
                _last = result;
            }

            if (result.Outcome == CodexUpdateOutcome.Updated)
            {
                RemoveOldReleases(result);
            }

            return result;
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            _log.LogWarning(ex, "Looking at Codex failed.");
            var failed = new CodexUpdateResult { Outcome = CodexUpdateOutcome.Failed, Message = "Codex could not be looked at: " + ex.Message };
            lock (_sync)
            {
                _last = failed;
            }

            return failed;
        }
        finally
        {
            lock (_sync)
            {
                _doing = "";
            }

            Volatile.Write(ref _running, 0);
            Changed?.Invoke();
        }
    }

    /// <summary>OpenAI's installer keeps every release it installed; the old ones are removed, keeping the newest few and the one just replaced.</summary>
    private void RemoveOldReleases(CodexUpdateResult result)
    {
        try
        {
            var removed = CodexReleasePruner.Prune(_releasesFolder(), new[] { result.Installed, result.Previous });
            if (removed.Count > 0)
            {
                _log.LogInformation("Removed {Count} old Codex releases: {Names}", removed.Count, string.Join(", ", removed));
            }
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            _log.LogInformation(ex, "Old Codex releases could not be removed.");
        }
    }
}

/// <summary>When Codex is looked at again, by what the last look found. Pure and tested.</summary>
public static class CodexUpdateSchedule
{
    /// <summary>A moment when no AI task was running has to come: soon.</summary>
    public static readonly TimeSpan WhenBusy = TimeSpan.FromMinutes(10);

    /// <summary>Nothing could be asked (no internet, say), or a release is still settling: an hour.</summary>
    public static readonly TimeSpan AfterProblem = TimeSpan.FromHours(1);

    /// <summary>An update was tried and did not work: each try closes the gate for a moment, so not every hour.</summary>
    public static readonly TimeSpan AfterFailure = TimeSpan.FromHours(3);

    public static TimeSpan Next(CodexUpdateOutcome outcome, TimeSpan every) => outcome switch
    {
        CodexUpdateOutcome.Waiting => WhenBusy,
        CodexUpdateOutcome.Failed => AfterFailure < every ? AfterFailure : every,
        CodexUpdateOutcome.Unknown => AfterProblem < every ? AfterProblem : every,
        // A release settles for a day: it is looked at again in an hour or the usual time, whichever is sooner.
        CodexUpdateOutcome.Settling => AfterProblem < every ? AfterProblem : every,
        _ => every,
    };
}
