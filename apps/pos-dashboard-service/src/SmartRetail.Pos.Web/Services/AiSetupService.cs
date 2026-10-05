using SmartRetail.AI.Cli;
using SmartRetail.AI.Providers;

namespace SmartRetail.Pos.Web.Services;

public enum AiSetupStage
{
    /// <summary>Not looked at yet since the app started.</summary>
    Unknown,
    Checking,
    NotInstalled,
    Installing,
    NotSignedIn,
    SigningIn,
    Ready,
    Failed,
}

/// <param name="Code">While signing in: the page to open and the one-time code to type there.</param>
/// <param name="LastLine">While installing: the installer's latest line.</param>
public sealed record AiSetupState(AiSetupStage Stage, string Detail, DeviceCode? Code = null, string? LastLine = null)
{
    public bool Busy => Stage is AiSetupStage.Checking or AiSetupStage.Installing or AiSetupStage.SigningIn;
}

/// <summary>
/// Gets the shop's AI tool ready without typing commands: installs Codex CLI with OpenAI's official installer when it
/// is missing, and signs it in with ChatGPT using a one-time code, or with an OpenAI API key. One step runs at a time for
/// every open page, in the background; pages follow it through <see cref="Changed"/>.
/// </summary>
public sealed class AiSetupService
{
    private readonly AiEnvironment _ai;
    private readonly ICliRunner _runner;
    private readonly ILogger<AiSetupService> _log;
    private readonly object _gate = new();
    private AiSetupState _state = new(AiSetupStage.Unknown, "");
    private CancellationTokenSource? _work;
    private DateTime _checkedAt = DateTime.MinValue;

    /// <summary>A ready Codex is looked at again after this long; one that is not ready, every time a page opens
    /// (it may have been installed or signed in elsewhere, e.g. in a terminal or the app's settings).</summary>
    private static readonly TimeSpan ReadyFor = TimeSpan.FromMinutes(5);
    private static readonly TimeSpan NotReadyFor = TimeSpan.FromSeconds(5);

    public AiSetupService(AiEnvironment ai, ILogger<AiSetupService> log)
        : this(ai, new ProcessCliRunner(), log)
    {
    }

    internal AiSetupService(AiEnvironment ai, ICliRunner runner, ILogger<AiSetupService> log)
    {
        _ai = ai;
        _runner = runner;
        _log = log;
        _ai.CodexAnswered += OnCodexAnswered;
    }

    /// <summary>Raised on a background thread whenever <see cref="State"/> changes.</summary>
    public event Action? Changed;

    public AiSetupState State
    {
        get
        {
            lock (_gate)
            {
                return _state;
            }
        }
    }

    public bool CanInstall => new CodexInstaller(_runner).CanInstall;

    /// <summary>Looks at Codex again: installed or not, signed in or not. Does nothing while a step is running.</summary>
    public Task RefreshAsync() => RunAsync(CheckAsync);

    /// <summary>Looks at Codex again unless it was looked at a moment ago: pages call this when they open, so what they
    /// show is never an old answer.</summary>
    public Task RefreshIfStaleAsync()
    {
        var state = State;
        DateTime checkedAt;
        lock (_gate)
        {
            checkedAt = _checkedAt;
        }

        var maxAge = state.Stage == AiSetupStage.Ready ? ReadyFor : NotReadyFor;
        return state.Busy || DateTime.UtcNow - checkedAt < maxAge ? Task.CompletedTask : RefreshAsync();
    }

    /// <summary>Codex just finished a task, so it is installed and signed in, whatever an earlier check said.</summary>
    private void OnCodexAnswered()
    {
        lock (_gate)
        {
            if (_work is not null || _state.Stage == AiSetupStage.Ready)
            {
                return;
            }

            _checkedAt = DateTime.UtcNow;
        }

        Set(new AiSetupState(AiSetupStage.Ready, "Codex is working: it just answered."));
    }

    /// <summary>Installs Codex with OpenAI's installer, then checks it.</summary>
    public Task InstallAsync() => RunAsync(async ct =>
    {
        Set(new AiSetupState(AiSetupStage.Installing, "Downloading Codex from OpenAI…"));
        await new CodexInstaller(_runner).InstallAsync(line => Set(State with { LastLine = line }), ct);
        await CheckAsync(ct);
    });

    /// <summary>Signs Codex in with ChatGPT: the page shows the sign-in page and the one-time code until it is entered.</summary>
    public Task SignInAsync() => RunAsync(async ct =>
    {
        Set(new AiSetupState(AiSetupStage.SigningIn, "Asking OpenAI for a sign-in code…"));
        var status = await _ai.CreateCodex().SignInWithChatGptAsync(code => Set(State with { Code = code, Detail = "Waiting for the code to be entered…" }), ct);
        Set(new AiSetupState(status.IsReady ? AiSetupStage.Ready : AiSetupStage.NotSignedIn, status.Detail));
    });

    /// <summary>Signs Codex in with an OpenAI API key instead, which is billed per use.</summary>
    public Task SignInWithApiKeyAsync(string apiKey) => RunAsync(async ct =>
    {
        Set(new AiSetupState(AiSetupStage.SigningIn, "Saving the key in Codex…"));
        await _ai.CreateCodex().SignInWithApiKeyAsync(apiKey, ct);
        await CheckAsync(ct);
    });

    /// <summary>Stops an install or a sign-in that is waiting.</summary>
    public void Cancel()
    {
        lock (_gate)
        {
            _work?.Cancel();
        }
    }

    private async Task CheckAsync(CancellationToken ct)
    {
        Set(State with { Stage = AiSetupStage.Checking, Code = null });
        var codex = _ai.CreateCodex();
        if (codex.ResolveExecutable() is null)
        {
            lock (_gate)
            {
                _checkedAt = DateTime.UtcNow;
            }

            Set(new AiSetupState(AiSetupStage.NotInstalled, CanInstall
                ? "Codex, the AI tool from OpenAI, is not installed yet."
                : "Codex is not installed. On Windows this app installs it by itself."));
            return;
        }

        var status = await codex.CheckAsync(ct);
        if (!status.IsReady)
        {
            _log.LogInformation("Codex is not ready: {Detail}", status.Detail);
        }

        lock (_gate)
        {
            _checkedAt = DateTime.UtcNow;
        }

        Set(new AiSetupState(status.IsReady ? AiSetupStage.Ready : AiSetupStage.NotSignedIn, status.Detail));
    }

    private async Task RunAsync(Func<CancellationToken, Task> step)
    {
        CancellationTokenSource work;
        lock (_gate)
        {
            if (_work is not null)
            {
                return;
            }

            _work = work = new CancellationTokenSource();
        }

        var stopped = false;
        try
        {
            await Task.Run(() => step(work.Token));
        }
        catch (OperationCanceledException)
        {
            stopped = true;
        }
        catch (Exception ex)
        {
            _log.LogWarning(ex, "Setting up the AI tool failed.");
            Set(new AiSetupState(AiSetupStage.Failed, ex.Message));
        }
        finally
        {
            lock (_gate)
            {
                _work = null;
            }

            work.Dispose();
        }

        if (stopped)
        {
            // Show where things stand after the stop.
            await RunAsync(CheckAsync);
        }
    }

    private void Set(AiSetupState state)
    {
        lock (_gate)
        {
            _state = state;
        }

        try
        {
            Changed?.Invoke();
        }
        catch (Exception ex)
        {
            _log.LogWarning(ex, "A page could not follow the AI setup.");
        }
    }
}
