using SmartRetail.AI.Cli;
using SmartRetail.AI.Providers;

namespace SmartRetail.Pos.Web.Services;

/// <summary>What the kept list of Codex's models was made from: when it was read, by which Codex, and how many models it has.</summary>
public sealed record CodexModelsInfo(DateTime At, string CodexVersion, int Count);

/// <summary>
/// What Codex says about the account, through its app server: the models it offers, with the thinking levels each
/// supports, and how much of the usage limits is used. The list of models is Codex's own answer, nothing is added to it here:
/// a new model shows only when Codex lists it, which depends on the account (OpenAI turns a new model on for accounts over
/// days) and on the Codex version. It is kept for a few minutes, so pages do not start Codex each time, and forgotten when
/// Codex is updated or signed in again; <c>fresh</c> asks again at once, and first removes Codex's own saved copy of the list when
/// an older Codex fetched it (<see cref="CodexModelsCache"/>).
/// </summary>
public sealed class CodexAccountService : IDisposable
{
    /// <summary>A few minutes: a new model shows soon after Codex knows it.</summary>
    public static readonly TimeSpan KeepModelsFor = TimeSpan.FromMinutes(5);

    private static readonly TimeSpan KeepUsageFor = TimeSpan.FromMinutes(3);

    private readonly AiEnvironment _ai;
    private readonly CodexUpdateService? _updates;
    private readonly AiSetupService? _setup;
    private readonly TimeProvider _clock;
    private readonly ILogger<CodexAccountService> _log;
    private readonly Func<CancellationToken, Task<string>> _installedVersion;
    private readonly string _codexHome;
    private readonly SemaphoreSlim _asking = new(1, 1);
    private (DateTime At, IReadOnlyList<CodexModel> Models, string Version)? _models;
    private (DateTime At, CodexUsage? Usage, string? Problem)? _usage;
    private CodexUpdateResult? _handledUpdate;
    private bool _wasReady;

    public CodexAccountService(AiEnvironment ai, CodexUpdateService updates, AiSetupService setup, TimeProvider clock, ILogger<CodexAccountService> log)
        : this(ai, updates, setup, clock, log, null, null)
    {
    }

    /// <summary>For tests: the way the installed version is read, and Codex's folder.</summary>
    internal CodexAccountService(AiEnvironment ai, CodexUpdateService? updates, AiSetupService? setup, TimeProvider clock, ILogger<CodexAccountService> log,
        Func<CancellationToken, Task<string>>? installedVersion, string? codexHome)
    {
        _ai = ai;
        _updates = updates;
        _setup = setup;
        _clock = clock;
        _log = log;
        _installedVersion = installedVersion ?? ReadInstalledVersionAsync;
        _codexHome = codexHome ?? CodexReleasePruner.DefaultCodexHome();
        if (_updates is not null)
        {
            _handledUpdate = _updates.Last;
            _updates.Changed += OnCodexUpdated;
        }

        if (_setup is not null)
        {
            _wasReady = _setup.State.Stage == AiSetupStage.Ready;
            _setup.Changed += OnSetupChanged;
        }
    }

    /// <summary>The usage was read again.</summary>
    public event Action? UsageChanged;

    /// <summary>The list of models was read again or forgotten.</summary>
    public event Action? ModelsChanged;

    private DateTime Now => _clock.GetLocalNow().DateTime;

    /// <summary>The usage last read, if any, and why it could not be read, if it could not.</summary>
    public (CodexUsage? Usage, string? Problem) LastUsage => _usage is { } last ? (last.Usage, last.Problem) : (null, null);

    /// <summary>What the kept list of models was made from; null when there is none.</summary>
    public CodexModelsInfo? ModelsInfo => _models is { } kept ? new CodexModelsInfo(kept.At, kept.Version, kept.Models.Count) : null;

    /// <summary>
    /// The models Codex offers, its default first; none when Codex cannot be asked. The list kept from a few minutes ago is used
    /// unless <paramref name="fresh"/>: Codex is asked now, after its own saved copy of the list has been removed if an older Codex fetched it.
    /// </summary>
    public async Task<IReadOnlyList<CodexModel>> ModelsAsync(CancellationToken ct, bool fresh = false)
    {
        if (!fresh && _models is { } kept && Now - kept.At < KeepModelsFor)
        {
            return kept.Models;
        }

        IReadOnlyList<CodexModel> models;
        await _asking.WaitAsync(ct);
        try
        {
            if (!fresh && _models is { } meanwhile && Now - meanwhile.At < KeepModelsFor)
            {
                return meanwhile.Models;
            }

            var version = await VersionOrEmptyAsync(ct);
            if (fresh)
            {
                RemoveOldCopy(version);
            }

            using var server = await _ai.CreateCodex().OpenAppServerAsync(ct);
            models = await server.ListModelsAsync(ct);
            _models = (Now, models, version);
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            _log.LogInformation(ex, "Codex's models could not be listed.");
            return Array.Empty<CodexModel>();
        }
        finally
        {
            _asking.Release();
        }

        ModelsChanged?.Invoke();
        return models;
    }

    /// <summary>Forgets the kept list, so the next question asks Codex.</summary>
    public void Forget()
    {
        _models = null;
        ModelsChanged?.Invoke();
    }

    /// <summary>How much of the usage limits is used, read again when older than a few minutes or when
    /// <paramref name="fresh"/>; null with the reason when Codex cannot say (e.g. signed in with an API key).</summary>
    public async Task<(CodexUsage? Usage, string? Problem)> UsageAsync(bool fresh, CancellationToken ct)
    {
        if (!fresh && _usage is { } kept && Now - kept.At < KeepUsageFor)
        {
            return (kept.Usage, kept.Problem);
        }

        await _asking.WaitAsync(ct);
        try
        {
            if (!fresh && _usage is { } meanwhile && Now - meanwhile.At < KeepUsageFor)
            {
                return (meanwhile.Usage, meanwhile.Problem);
            }

            try
            {
                using var server = await _ai.CreateCodex().OpenAppServerAsync(ct);
                _usage = (Now, await server.ReadUsageAsync(ct), null);
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                // Not installed, not signed in, or signed in with an API key, which has no such limits.
                _log.LogDebug(ex, "Codex's usage could not be read.");
                _usage = (Now, null, ex is CodexAppServerException ? ex.Message : "Codex is not ready.");
            }
        }
        finally
        {
            _asking.Release();
        }

        UsageChanged?.Invoke();
        return (_usage.Value.Usage, _usage.Value.Problem);
    }

    public void Dispose()
    {
        if (_updates is not null)
        {
            _updates.Changed -= OnCodexUpdated;
        }

        if (_setup is not null)
        {
            _setup.Changed -= OnSetupChanged;
        }
    }

    /// <summary>A new Codex was installed: its list of models may be longer, so the old one is forgotten, and so is a copy an older Codex saved.</summary>
    private void OnCodexUpdated()
    {
        var last = _updates?.Last;
        if (last is not { Outcome: CodexUpdateOutcome.Updated } || ReferenceEquals(last, _handledUpdate))
        {
            return;
        }

        _handledUpdate = last;
        RemoveOldCopy(last.Installed);
        Forget();
    }

    /// <summary>Codex was set up or signed in just now: the models depend on the account, so the list is read again.</summary>
    private void OnSetupChanged()
    {
        var ready = _setup?.State.Stage == AiSetupStage.Ready;
        var justNow = ready && !_wasReady;
        _wasReady = ready;
        if (justNow)
        {
            Forget();
        }
    }

    private void RemoveOldCopy(string version)
    {
        try
        {
            if (CodexModelsCache.RemoveIfFromOtherVersion(_codexHome, version))
            {
                _log.LogInformation("Removed the list of models an older Codex saved, so Codex {Version} fetches its own.", version);
            }
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            _log.LogDebug(ex, "Codex's saved list of models could not be checked.");
        }
    }

    private async Task<string> VersionOrEmptyAsync(CancellationToken ct)
    {
        try
        {
            return await _installedVersion(ct) ?? "";
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            _log.LogDebug(ex, "Codex's version could not be read.");
            return "";
        }
    }

    /// <summary>What <c>codex --version</c> says, as "0.158.0"; empty when Codex is not installed or does not say.</summary>
    private async Task<string> ReadInstalledVersionAsync(CancellationToken ct)
    {
        var tool = new CodexTool(_ai.LoadSettings, new ProcessCliRunner(), new CodexInstaller(new ProcessCliRunner()));
        var printed = await tool.VersionAsync(ct);
        return printed is null ? "" : CodexVersions.ForInstaller(CodexVersions.Installed(printed, out _));
    }
}
