using Microsoft.Extensions.Options;
using SmartRetail.AI.Updates;

namespace SmartRetail.Pos.Web.Services;

/// <summary>Where the app keeps what its update checks found, for the dashboard to show. Empty: the app's own default folder.</summary>
public sealed class UpdateOptions
{
    public const string SectionName = "Updates";

    public string Folder { get; set; } = "";

    /// <summary>How often the status file is looked at, in seconds (a look is one small file's time stamp).</summary>
    public int PollSeconds { get; set; } = 5;

    public string FolderPath => string.IsNullOrWhiteSpace(Folder) ? UpdateFolder.Default : Folder;
}

/// <summary>
/// What the Windows app found the last time it looked for a newer version (status.json in its Updates folder), for the
/// bell and Settings. The app checks, downloads and installs; the dashboard only reads and shows, and asks the app to check
/// or install by a message (<c>srpos.send</c>). Read again every few seconds, so a check that just finished shows at once.
/// </summary>
public sealed class UpdateStatusService : IDisposable
{
    private readonly string _folder;
    private readonly ILogger<UpdateStatusService> _log;
    private readonly Timer _timer;
    private readonly object _gate = new();
    private UpdateStatus _status;
    private DateTime _seenWrite = DateTime.MinValue;

    public UpdateStatusService(IOptions<UpdateOptions> options, ILogger<UpdateStatusService> log)
    {
        _folder = options.Value.FolderPath;
        _log = log;
        _status = Read();
        var every = TimeSpan.FromSeconds(Math.Clamp(options.Value.PollSeconds, 1, 300));
        _timer = new Timer(_ => Look(), null, every, every);
    }

    /// <summary>The status changed on disk: a check ended, or an update is ready. Raised on any thread.</summary>
    public event Action? Changed;

    /// <summary>What the app last found; "not checked yet" when it has not written anything.</summary>
    public UpdateStatus Status
    {
        get
        {
            lock (_gate)
            {
                return _status;
            }
        }
    }

    /// <summary>The version that is ready to install, or null.</summary>
    public string? Ready => Status is { State: UpdateState.Ready } ready && UpdateManifest.IsVersion(ready.Available) ? ready.Available : null;

    private UpdateStatus Read()
    {
        _seenWrite = WrittenAt();
        return UpdateFolder.Load(_folder);
    }

    private DateTime WrittenAt()
    {
        try
        {
            var path = Path.Combine(_folder, UpdateFolder.StatusFileName);
            return File.Exists(path) ? File.GetLastWriteTimeUtc(path) : DateTime.MinValue;
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            return DateTime.MinValue;
        }
    }

    private void Look()
    {
        try
        {
            Refresh();
        }
        catch (Exception ex)
        {
            // A timer must never end the app; the next look tries again.
            _log.LogWarning(ex, "Reading the update status failed.");
        }
    }

    /// <summary>Reads the file again when it was written since the last look.</summary>
    public void Refresh()
    {
        if (WrittenAt() == _seenWrite)
        {
            return;
        }

        lock (_gate)
        {
            _status = Read();
        }

        Changed?.Invoke();
    }

    public void Dispose() => _timer.Dispose();
}
