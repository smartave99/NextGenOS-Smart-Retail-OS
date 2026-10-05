using System.Reflection;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using SmartRetail.Pos.Core.Updates;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// The change log the dashboard carries (CHANGELOG.md, built into it, so it is always the log of this very version) and what the
/// owner has looked at: the newest version whose entry was opened is kept in whats-new.json beside the settings, so the sidebar
/// shows a dot after an update until What's new is opened. Nothing about it leaves this PC.
/// </summary>
public sealed class WhatsNewService
{
    public const string FileName = "whats-new.json";

    private readonly object _gate = new();
    private readonly string _path;
    private readonly ILogger<WhatsNewService> _log;
    private string _seen;

    public WhatsNewService(IOptions<AiOptions> options, ILogger<WhatsNewService> log)
        : this(ReadBuiltInLog(), CurrentVersionOfApp(), Path.Combine(Path.GetDirectoryName(options.Value.SettingsFilePath) ?? "", FileName), log)
    {
    }

    /// <summary>For tests and for a log that is not the built-in one.</summary>
    public WhatsNewService(string changeLog, string currentVersion, string stateFile, ILogger<WhatsNewService> log)
    {
        Releases = ChangeLog.Parse(changeLog);
        CurrentVersion = currentVersion;
        _path = stateFile;
        _log = log;
        _seen = ReadSeen();
    }

    /// <summary>The version of this copy of the app.</summary>
    public string CurrentVersion { get; }

    /// <summary>Every release, newest first.</summary>
    public IReadOnlyList<ChangeRelease> Releases { get; }

    /// <summary>The entry for this copy's version, or null when the log has none (a copy built from other files).</summary>
    public ChangeRelease? Current => Releases.FirstOrDefault(release => release.Version == CurrentVersion);

    /// <summary>The newest version whose entry the owner opened; empty when none was.</summary>
    public string Seen
    {
        get
        {
            lock (_gate)
            {
                return _seen;
            }
        }
    }

    /// <summary>This copy's version is one the owner has not looked at yet: the sidebar shows a dot.</summary>
    public bool HasUnseen => Current is not null && (Seen.Length == 0 || ChangeLog.IsNewer(CurrentVersion, Seen));

    /// <summary>
    /// The updates the owner has not looked at, newest first: the ones after the last one looked at, up to this version. When none
    /// was ever looked at (a new install) it is only this version's, not the whole history.
    /// </summary>
    public IReadOnlyList<ChangeRelease> UnseenReleases
    {
        get
        {
            if (Current is not { } current)
            {
                return [];
            }

            var seen = Seen;
            return seen.Length == 0
                ? [current]
                : ChangeLog.Since(Releases, seen).Where(release => !ChangeLog.IsNewer(release.Version, CurrentVersion)).ToList();
        }
    }

    /// <summary>The change log, or the owner's looking at it, changed.</summary>
    public event Action? Changed;

    /// <summary>The owner has opened What's new: this version's entry counts as seen.</summary>
    public void MarkSeen()
    {
        if (Current is null)
        {
            return;
        }

        lock (_gate)
        {
            if (_seen == CurrentVersion)
            {
                return;
            }

            _seen = CurrentVersion;
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
                var temporary = _path + ".tmp";
                File.WriteAllText(temporary, JsonSerializer.Serialize(new State { Seen = _seen }), new UTF8Encoding(false));
                File.Move(temporary, _path, overwrite: true);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                // The dot comes back at the next start; nothing else depends on this file.
                _log.LogWarning(ex, "Remembering that What's new was opened failed.");
            }
        }

        Changed?.Invoke();
    }

    private string ReadSeen()
    {
        try
        {
            if (File.Exists(_path) && JsonSerializer.Deserialize<State>(File.ReadAllText(_path, Encoding.UTF8))?.Seen is { } seen && Version.TryParse(seen, out _))
            {
                return seen;
            }
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
        {
            _log.LogWarning(ex, "Reading what was seen in What's new failed; it counts as not seen.");
        }

        return "";
    }

    private static string ReadBuiltInLog()
    {
        using var stream = typeof(WhatsNewService).Assembly.GetManifestResourceStream("CHANGELOG.md");
        if (stream is null)
        {
            return "";
        }

        using var reader = new StreamReader(stream, Encoding.UTF8);
        return reader.ReadToEnd();
    }

    private static string CurrentVersionOfApp() =>
        typeof(WhatsNewService).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion.Split('+')[0] ?? "";

    private sealed class State
    {
        public string Seen { get; set; } = "";
    }
}
