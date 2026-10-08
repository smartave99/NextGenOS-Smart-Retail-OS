using System.Globalization;
using System.Text.Json;
using NextGenOS.Hub.Backups;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Updates;

/// <summary>
/// How a copy of the Hub looks for updates: whom to trust and where to look (<see cref="Trust"/>, fixed when the program was built; null means this copy never looks), the folder on this PC
/// where a checked setup is kept, the version that is running, and how to reach the internet (the program passes one shared client; the tests pass a stand-in).
/// </summary>
public sealed record UpdateOptions(UpdateSettings? Trust, string Folder, Version Current, Func<HttpClient>? Http = null);

/// <summary>What the owner's page shows. <see cref="Summary"/> says it all in plain words; the rest lets the page offer the right buttons.</summary>
public sealed record UpdateView(bool Built, bool Looking, string State, string Current, string? Version, string? Notes, string? File, string? StagedPath,
    DateTimeOffset? CheckedAt, DateTimeOffset? ApprovedAt, string? Note, string? Problem, bool Skipped, string Summary);

/// <summary>
/// Updates through the main PC (blueprint REL-016, decision 7): the Hub looks, about once a day, for a newer version in the update folder online; before it downloads anything it checks that
/// GitHub signed the version for the project's own release; the downloaded setup is checked again against its SHA-256 and kept on this PC. <b>Nothing is installed without the owner:</b> the
/// owner reads what is new and presses <i>Approve</i>; the shop is copied first (to the owner's second place when there is one, else to a folder on this PC) and an approval is refused if
/// that copy cannot be made; then the page names the file and says how to run it. Running the setup itself (the Windows service has no rights to install a program, and a counter PC is a
/// browser that needs no update) is the one step that is not done here.
/// </summary>
public sealed class UpdateService(HubDb db, SettingsStore store, IClock clock, AuditService audit, BackupService backups, Access access, UpdateOptions? options)
{
    private const string RecordKey = "update.record";
    private const string SwitchKey = "update.look";   // "off" when the owner switched looking off; anything else is on
    private static readonly TimeSpan LookEvery = TimeSpan.FromHours(24);
    private static readonly TimeSpan LookAgainAfterFailure = TimeSpan.FromHours(6);
    private const int CopiesKept = 3;
    private static readonly JsonSerializerOptions Json = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    private static readonly Lazy<HttpClient> Shared = new(() => new HttpClient { Timeout = Timeout.InfiniteTimeSpan });

    private readonly SemaphoreSlim busy = new(1, 1);

    private sealed record Stored(string State, DateTimeOffset? CheckedAt, string? Available, string? File, string? Sha256, string? Notes, string? Problem,
        DateTimeOffset? ApprovedAt, long? ApprovedBy, string? Note, string? Skipped);

    private static readonly Stored Nothing = new(UpdateStates.None, null, null, null, null, null, null, null, null, null, null);

    /// <summary>True when this copy of the program was made to look for updates at all.</summary>
    public bool Built => options?.Trust is not null;

    private bool Looking => Built && store.GetText(SwitchKey) != "off";

    // ---- what the owner sees -------------------------------------------------------------------------------------------------------

    public UpdateView View()
    {
        access.Require(Perm.Settings);
        return Build(Refresh());
    }

    /// <summary>The owner switches looking for new versions on or off. Nothing is installed either way.</summary>
    public UpdateView SetLooking(bool on, long? userId)
    {
        access.Require(Perm.Settings);
        if (!Built) throw NotBuilt();
        store.SetText(SwitchKey, on ? "on" : "off");
        audit.Log(userId, "update.switch", "update", null, on ? "on" : "off");
        return Build(Refresh());
    }

    // ---- looking -------------------------------------------------------------------------------------------------------------------

    /// <summary>Looks now, when the owner asks.</summary>
    public async Task<UpdateView> LookNowAsync(long? userId, CancellationToken ct = default)
    {
        access.Require(Perm.Settings);
        if (!Built) throw NotBuilt();
        await LookAsync(userId, manual: true, ct);
        return Build(Refresh());
    }

    /// <summary>
    /// Called by the program's background worker: looks when it is switched on and about a day has passed since the last look (six hours after one that failed). It never throws for a
    /// problem with the internet: the look is written down as failed, with the reason in plain words, and the shop carries on selling.
    /// </summary>
    public async Task LookIfDueAsync(CancellationToken ct = default)
    {
        if (!Looking) return;
        var stored = Refresh();
        var every = stored.State == UpdateStates.Failed || stored.Problem is not null ? LookAgainAfterFailure : LookEvery;
        if (stored.CheckedAt is { } last && clock.UtcNow - last < every) return;
        await LookAsync(null, manual: false, ct);
    }

    private async Task LookAsync(long? userId, bool manual, CancellationToken ct)
    {
        if (!await busy.WaitAsync(0, ct))
        {
            if (manual) throw new HubException("update-busy", "A look for a new version is already going on. Try again in a moment.");
            return;
        }
        try
        {
            var before = Refresh();
            var checker = new UpdateChecker((options!.Http ?? (() => Shared.Value))(), options.Trust!, options.Folder, options.Current);
            var found = await checker.CheckAsync(clock.UtcNow, ct);
            var now = clock.UtcNow;
            Stored next;
            switch (found.State)
            {
                case UpdateStates.Ready:
                    var same = before.Available == found.Available && before.State is UpdateStates.Ready or UpdateStates.Approved;
                    next = new Stored(same ? before.State : UpdateStates.Ready, now, found.Available, found.File, found.Sha256, found.Notes, null,
                        same ? before.ApprovedAt : null, same ? before.ApprovedBy : null, same ? before.Note : null, before.Available == found.Available ? before.Skipped : null);
                    if (!same) audit.Log(userId, "update.found", "update", null, found.Available);
                    break;
                case UpdateStates.UpToDate:
                    next = Nothing with { State = UpdateStates.UpToDate, CheckedAt = now };
                    break;
                default:
                    // A look that failed does not take away an update that was already checked and kept: it only writes the problem down.
                    next = before.State is UpdateStates.Ready or UpdateStates.Approved ? before with { CheckedAt = now, Problem = found.Problem } : Nothing with { State = UpdateStates.Failed, CheckedAt = now, Problem = found.Problem };
                    break;
            }
            Save(next);
            if (manual) audit.Log(userId, "update.look", "update", null, next.State);
        }
        finally
        {
            busy.Release();
        }
    }

    // ---- saying yes, or not now ----------------------------------------------------------------------------------------------------

    /// <summary>
    /// The owner says yes to the version that was checked and kept. The kept file is checked once more, the shop is copied first, and only then is the approval written. If the copy cannot
    /// be made the approval is refused and nothing changes. Nothing is installed by this.
    /// </summary>
    public UpdateView Approve(long? userId)
    {
        access.Require(Perm.Settings);
        if (!Built) throw NotBuilt();
        var stored = Refresh();
        if (stored.State == UpdateStates.Approved) throw new HubException("update-approved", "This update is already approved.");
        if (stored.State != UpdateStates.Ready || stored.File is null || stored.Sha256 is null || stored.Available is null)
            throw new HubException("update-not-ready", "There is no update ready to approve.");

        var path = Path.Combine(options!.Folder, stored.File);
        if (!File.Exists(path) || UpdateChecker.Sha256Of(path) != stored.Sha256)
        {
            Save(Nothing with { CheckedAt = stored.CheckedAt, State = UpdateStates.None });
            DeleteSetups();
            throw new HubException("update-changed", "The downloaded update changed after it was checked, so it is not trusted and was removed. It is downloaded again at the next look.");
        }

        var note = CopyFirst(stored.Available, userId);   // throws, and nothing is approved, when the shop cannot be copied
        Save(stored with { State = UpdateStates.Approved, ApprovedAt = clock.UtcNow, ApprovedBy = userId, Note = note, Skipped = null });
        audit.Log(userId, "update.approve", "update", null, stored.Available);
        return Build(Refresh());
    }

    /// <summary>"Not now": the first screen stops reminding about this version. A newer version reminds again; the page keeps offering this one.</summary>
    public UpdateView Skip(long? userId)
    {
        access.Require(Perm.Settings);
        if (!Built) throw NotBuilt();
        var stored = Refresh();
        if (stored.State != UpdateStates.Ready || stored.Available is null) throw new HubException("update-not-ready", "There is no update waiting.");
        Save(stored with { Skipped = stored.Available });
        audit.Log(userId, "update.skip", "update", null, stored.Available);
        return Build(Refresh());
    }

    private string CopyFirst(string version, long? userId)
    {
        var settings = backups.Settings();
        if (!string.IsNullOrWhiteSpace(settings.Folder))
        {
            var run = backups.RunNow(BackupKinds.Manual, userId);
            if (!run.Good) throw new HubException("update-backup", "The shop could not be copied first, so the update was not approved. " + run.Error);
            return $"The shop was copied to {settings.Folder} first ({run.FileName}).";
        }

        var folder = Path.Combine(options!.Folder, "copies");
        try
        {
            Directory.CreateDirectory(folder);
            var made = db.CopyTo(folder, $"NextGenOS-shop-before-{version}.bak");
            foreach (var old in Directory.EnumerateFiles(folder, "NextGenOS-shop-before-*.bak").OrderByDescending(File.GetLastWriteTimeUtc).Skip(CopiesKept))
            {
                try { File.Delete(old); } catch (Exception e) when (e is IOException or UnauthorizedAccessException) { /* next time */ }
            }
            return $"No second place for copies is chosen yet, so the shop was copied to a folder on this PC ({made.FileName}). A copy on the same disk does not help if the disk is lost: choose a place under Settings, Backups.";
        }
        catch (Exception e) when (e is HubException or IOException or UnauthorizedAccessException)
        {
            throw new HubException("update-backup", "The shop could not be copied first, so the update was not approved. " + (e is HubException ? e.Message : "Nothing can be saved in the update folder on this PC (" + e.Message + ")."));
        }
    }

    // ---- housekeeping --------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// An update that was ready or approved is finished when the program that is running is that version or newer: the kept setup is removed and the page says it is the newest.
    /// </summary>
    private Stored Refresh()
    {
        var stored = Load();
        if (options is null || stored.State is not (UpdateStates.Ready or UpdateStates.Approved) || !UpdateManifest.IsVersion(stored.Available)) return stored;
        if (Version.Parse(stored.Available!) > options.Current) return stored;
        var installed = stored.Available;
        DeleteSetups();
        var next = Nothing with { State = UpdateStates.UpToDate, CheckedAt = stored.CheckedAt };
        Save(next);
        audit.Log(stored.ApprovedBy, "update.installed", "update", null, installed);
        return next;
    }

    private void DeleteSetups()
    {
        if (options is null || !Directory.Exists(options.Folder)) return;
        foreach (var path in Directory.EnumerateFiles(options.Folder).Where(p => UpdateManifest.IsKeptSetup(Path.GetFileName(p))).ToList())
        {
            try { File.Delete(path); } catch (Exception e) when (e is IOException or UnauthorizedAccessException) { /* next time */ }
        }
    }

    private Stored Load()
    {
        var text = store.GetText(RecordKey);
        if (string.IsNullOrWhiteSpace(text)) return Nothing;
        try { return JsonSerializer.Deserialize<Stored>(text, Json) ?? Nothing; }
        catch (JsonException) { return Nothing; }
    }

    private void Save(Stored stored) => store.SetText(RecordKey, JsonSerializer.Serialize(stored, Json));

    private static HubException NotBuilt() => new("update-not-built", "This copy of the program was not made to look for new versions.");

    private UpdateView Build(Stored s)
    {
        var current = options?.Current.ToString(3) ?? "";
        var kept = s.State is UpdateStates.Ready or UpdateStates.Approved && s.File is not null && options is not null ? Path.Combine(options.Folder, s.File) : null;
        var skipped = s.Skipped is not null && s.Skipped == s.Available;
        var when = s.CheckedAt is { } at ? at.ToLocalTime().ToString("d MMM yyyy, HH:mm", CultureInfo.InvariantCulture) : null;
        string summary;
        if (!Built) summary = "This copy of the program was not made to look for new versions. When a new version comes, your supplier gives you its setup file.";
        else if (s.State == UpdateStates.Approved)
            summary = $"Version {s.Available} is approved. {s.Note} It is not installed yet: the last step is to run the file named below, and then say Yes when Windows asks.";
        else if (s.State == UpdateStates.Ready)
            summary = $"Version {s.Available} is ready. It was made by the program's own release, downloaded and checked, and is kept on this PC. Nothing is installed until you approve it.";
        else if (s.State == UpdateStates.Failed)
            summary = $"The last look for a new version did not work: {s.Problem} The shop carries on as it is. It will try again later.";
        else if (s.State == UpdateStates.UpToDate)
            summary = $"You have the newest version ({current}). Last looked: {when}.";
        else summary = Looking ? "Not looked yet. It looks about once a day, or press Look now." : "Looking for new versions is switched off.";
        if (Built && !Looking && s.State != UpdateStates.None) summary += " Looking for new versions is switched off.";
        if (s.State is UpdateStates.Ready or UpdateStates.Approved && s.Problem is not null) summary += $" (The last look for a newer one did not work: {s.Problem})";
        return new UpdateView(Built, Looking, s.State, current, s.Available, s.Notes, s.File, kept, s.CheckedAt, s.ApprovedAt, s.Note, s.Problem, skipped, summary);
    }
}
