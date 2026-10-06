using Microsoft.Extensions.Options;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// The AI tools as the side panel has set them up: its settings file (read fresh each time, so a tool set up a
/// minute ago is used) and its saved keys, decrypted with Windows DPAPI for the same Windows user.
/// </summary>
public sealed class AiEnvironment : IDisposable
{
    private readonly AiOptions _options;
    private readonly AiRunGate? _gate;
    private readonly HttpClient _http = new() { Timeout = Timeout.InfiniteTimeSpan };

    /// <param name="gate">Every run of Codex goes in through it, so Codex can be replaced by a newer one between runs.</param>
    public AiEnvironment(IOptions<AiOptions> options, AiRunGate? gate = null)
    {
        _options = options.Value;
        _gate = gate;
    }

    public string SettingsFile => _options.SettingsFilePath;

    /// <summary>
    /// Where the account's usage limit stands. Photos, listings, posters' artwork and creatives all use the one Codex account: when one of
    /// them meets the limit they all wait until Codex can answer again and carry on from where they stopped.
    /// </summary>
    public UsageLimitPause LimitPause { get; } = new();

    public AssistantSettings LoadSettings() => new SettingsStore(SettingsFile).Load();

    /// <summary>Raised when Codex finished a task well, which proves it is installed and signed in.</summary>
    public event Action? CodexAnswered;

    /// <summary>Each job's model or thinking level changed.</summary>
    public event Action? JobsChanged;

    /// <summary>A router with the AI tools as they are set up, e.g. to check them.</summary>
    public ProviderRouter CreateRouter() => Create(null);

    /// <summary>A router for one job: Codex with the job's model and thinking level (<see cref="AiJobs"/>).</summary>
    public ProviderRouter CreateRouter(AiJob job) => Create(job);

    /// <summary>Saves the owner's model and thinking level for a job; an empty choice goes back to the recommended one.</summary>
    public void SaveJobChoice(AiJob job, AiJobChoice choice)
    {
        var store = new SettingsStore(SettingsFile);
        var settings = store.Load();
        settings.SetChoice(job, choice);
        store.Save(settings);
        JobsChanged?.Invoke();
    }

    private ProviderRouter Create(AiJob? job)
    {
        var settings = LoadSettings();
        if (job is { } forJob)
        {
            AiJobs.Apply(settings, forJob);
        }

        ISecretProtector protector = OperatingSystem.IsWindows() ? new DpapiSecretProtector() : new NoSecretProtector();
        var secrets = new SecretStore(() => settings, protector);
        var runner = new ObservingCliRunner(new ProcessCliRunner(), (invocation, result) =>
        {
            if (ObservingCliRunner.IsCodexAnswer(invocation, result))
            {
                CodexAnswered?.Invoke();
            }
        });
        return new ProviderRouter(ProviderCatalog.CreateAll(() => settings, secrets, runner, _http, gate: _gate), () => settings);
    }

    /// <summary>Looks after Claude Code and Antigravity: their models and thinking levels, their version, and bringing them up to date. Reads the settings and the saved Anthropic key fresh each time.</summary>
    public ICliToolCare CreateToolCare()
    {
        var settings = LoadSettings();
        ISecretProtector protector = OperatingSystem.IsWindows() ? new DpapiSecretProtector() : new NoSecretProtector();
        return new CliToolCare(new ProcessCliRunner(), () => settings, new SecretStore(() => settings, protector), _http);
    }

    /// <summary>Codex CLI as set up in the side panel; it is the tool that can make images.</summary>
    public CodexCliProvider CreateCodex() => CreateRouter().Providers.OfType<CodexCliProvider>().First();

    /// <summary>Codex CLI with a job's model and thinking level, e.g. for photos.</summary>
    public CodexCliProvider CreateCodex(AiJob job) => CreateRouter(job).Providers.OfType<CodexCliProvider>().First();

    public void Dispose() => _http.Dispose();
}
