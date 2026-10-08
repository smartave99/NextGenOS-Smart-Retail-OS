using System.Globalization;
using System.Security.Cryptography;
using System.Text.Json;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Security;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Backups;

/// <summary>
/// Where, when and how many copies. <see cref="Folder"/> is a second place (a USB drive, another PC on the shop's network); null means none chosen yet. <see cref="PlaceId"/> is the mark
/// left in that place when it was chosen: a copy is made only where the mark is found, so an unplugged drive whose folder name still exists on the PC's own disk, or a different drive,
/// is not mistaken for the place.
/// </summary>
public sealed record BackupSettings(bool Enabled, string? Folder, string TimeLocal, int Keep, string? PlaceId = null)
{
    public static readonly BackupSettings None = new(false, null, "02:00", 14);
}

/// <summary>One try at a copy, good or not. A failed try keeps its reason in plain words.</summary>
public sealed record BackupRun(long Id, DateTimeOffset At, string Kind, string Status, string? Folder, string? FileName, long SizeBytes, string? Sha256, int SchemaVersion, string? Error)
{
    public bool Good => Status == BackupStatuses.Ok;
}

public static class BackupKinds
{
    public const string Nightly = "nightly";
    public const string Manual = "manual";
}

public static class BackupStatuses
{
    public const string Ok = "ok";
    public const string Failed = "failed";
}

/// <summary>What the owner sees: whether the last copy worked, when the next is due, and what to do if it did not.</summary>
public sealed record BackupStatus(BackupSettings Settings, BackupRun? LastGood, BackupRun? LastFailed, bool Overdue, DateTimeOffset? NextDue, string Summary);

/// <summary>A copy found in the backup folder.</summary>
public sealed record BackupFileInfo(string Path, string FileName, DateTimeOffset Modified, long SizeBytes);

/// <summary>
/// The shop's own copies, made every night to a second place the owner chose (blueprint OPS-002, decision 11). Each copy is made with SQLite's own consistent copy (safe while the shop is in
/// use) and then <b>checked</b> (<see cref="DatabaseCheck"/>), and its fingerprint is kept so that a copy that changes on the drive can be told. A copy that fails is written down with
/// the reason in plain words and the shop carries on selling: a backup never stops the till. Nothing leaves the shop; an online copy is a separate, later, opt-in thing.
/// </summary>
public sealed class BackupService(HubDb db, ShopContextProvider shop, SettingsStore store, IClock clock, AuditService audit, Access access)
{
    private const string Key = "backup";
    private const string FolderKey = "backup.folder";
    private const string MarkerName = ".nextgenos-backup-place";
    private static readonly JsonSerializerOptions Json = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    private static readonly TimeSpan RetryAfterFailure = TimeSpan.FromHours(1);
    private static readonly TimeSpan OverdueAfter = TimeSpan.FromHours(36);

    // ---- the owner's choices ---------------------------------------------------------------------------------------------------------

    public BackupSettings Settings()
    {
        var text = store.GetText(Key);
        if (string.IsNullOrWhiteSpace(text)) return BackupSettings.None;
        try { return JsonSerializer.Deserialize<BackupSettings>(text, Json) ?? BackupSettings.None; }
        catch (JsonException) { return BackupSettings.None; }
    }

    /// <summary>Keeps the owner's choices. Switching on needs a folder that can really be written to (a small test file is made and removed).</summary>
    public BackupSettings Save(BackupSettings next, long? userId)
    {
        access.Require(Perm.Settings);
        var folder = string.IsNullOrWhiteSpace(next.Folder) ? null : next.Folder.Trim();
        if (!TimeOnly.TryParseExact(next.TimeLocal, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            throw new HubException("backup-time", "Please give the time as hours and minutes, like 02:00.");
        if (next.Keep is < 1 or > 365) throw new HubException("backup-keep", "Keep at least 1 copy and at most 365.");
        if (next.Enabled && folder is null) throw new HubException("backup-folder", "Choose the place for the copies first (a USB drive, or a folder on another PC).");
        string? placeId = null;
        if (folder is not null)
        {
            CheckWritable(folder);
            var before = Settings();
            placeId = before.Folder == folder && before.PlaceId is not null ? before.PlaceId : Guid.NewGuid().ToString("N");
            try { File.WriteAllText(Path.Combine(folder, MarkerName), placeId); }
            catch (Exception e) when (e is IOException or UnauthorizedAccessException) { throw new HubException("backup-folder", $"Nothing can be saved in \"{folder}\" ({e.Message})."); }
        }

        var saved = new BackupSettings(next.Enabled, folder, next.TimeLocal, next.Keep, placeId);
        store.SetText(Key, JsonSerializer.Serialize(saved, Json));
        store.SetText(FolderKey, folder ?? "");                                                    // also read by an update before the shop is opened: its safe copy goes to the same place
        audit.Log(userId, "backup-settings", "backup", null, saved.Enabled ? $"on {saved.TimeLocal}, keep {saved.Keep}, {saved.Folder}" : "off");
        return saved;
    }

    private static void CheckWritable(string folder)
    {
        try
        {
            Directory.CreateDirectory(folder);
            var probe = Path.Combine(folder, ".nextgenos-write-test-" + Guid.NewGuid().ToString("N"));
            File.WriteAllText(probe, "ok");
            File.Delete(probe);
        }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException or NotSupportedException or ArgumentException)
        {
            throw new HubException("backup-folder", $"Nothing can be saved in \"{folder}\" ({e.Message}). Check that the drive is plugged in and the folder can be written to.");
        }
    }

    // ---- making a copy ---------------------------------------------------------------------------------------------------------------

    /// <summary>Makes a copy now, whatever the time. Never throws for a drive problem: the run is recorded as failed, with the reason, and returned.</summary>
    public BackupRun RunNow(string kind = BackupKinds.Manual, long? userId = null)
    {
        if (kind == BackupKinds.Manual) access.Require(Perm.Settings);
        var settings = Settings();
        var now = clock.UtcNow;
        if (string.IsNullOrWhiteSpace(settings.Folder))
            return Record(now, kind, BackupStatuses.Failed, null, null, 0, null, 0, "No place for the copies has been chosen yet. Choose one in Settings, under Backups.");
        try
        {
            CheckPlace(settings);
            CheckFreeSpace(settings.Folder);
            var fileName = $"NextGenOS-shop-{now.UtcDateTime.ToString("yyyyMMdd'T'HHmm'Z'", CultureInfo.InvariantCulture)}-{kind}.bak";
            var made = db.CopyTo(settings.Folder, fileName);
            var hash = Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(made.Path))).ToLowerInvariant();
            var run = Record(now, kind, BackupStatuses.Ok, settings.Folder, made.FileName, made.SizeBytes, hash, made.SchemaVersion, null);
            if (kind == BackupKinds.Nightly) Prune(settings);
            return run;
        }
        catch (HubException e) when (e.Code == "backup")
        {
            return Record(now, kind, BackupStatuses.Failed, settings.Folder, null, 0, null, 0, e.Message);
        }
    }

    private static void CheckPlace(BackupSettings settings)
    {
        var folder = settings.Folder!;
        string? found = null;
        try
        {
            var marker = Path.Combine(folder, MarkerName);
            if (Directory.Exists(folder) && File.Exists(marker)) found = File.ReadAllText(marker).Trim();
        }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException) { /* treated as not found */ }
        if (settings.PlaceId is null || found != settings.PlaceId)
            throw new HubException("backup", $"The place for the copies (\"{folder}\") is not there, or is not the one chosen. Check that the drive is plugged in; if it is a new drive, choose it again in Settings, under Backups.");
    }

    private static void CheckFreeSpace(string folder)
    {
        try
        {
            var root = Path.GetPathRoot(Path.GetFullPath(folder));
            if (string.IsNullOrEmpty(root)) return;
            var free = new DriveInfo(root).AvailableFreeSpace;
            if (free < 50L * 1024 * 1024) throw new HubException("backup", $"The drive for the copies has only {free / (1024 * 1024)} MB free. Make room on it, or choose another place.");
        }
        catch (Exception e) when (e is ArgumentException or IOException or UnauthorizedAccessException or NotSupportedException)
        {
            // a network share or a drive that cannot say how much is free: try the copy and see
        }
    }

    private BackupRun Record(DateTimeOffset at, string kind, string status, string? folder, string? fileName, long size, string? hash, int version, string? error)
    {
        var id = db.InTransaction((c, t) => HubDb.Insert(c,
            "INSERT INTO backup_runs(started_at, kind, status, folder, file_name, size_bytes, sha256, schema_version, error) VALUES ($at, $kind, $status, $folder, $file, $size, $hash, $version, $error)", t,
            ("$at", Iso.Text(at)), ("$kind", kind), ("$status", status), ("$folder", folder), ("$file", fileName), ("$size", size), ("$hash", hash), ("$version", version), ("$error", error)));
        return new BackupRun(id, at, kind, status, folder, fileName, size, hash, version, error);
    }

    /// <summary>Keeps the newest <see cref="BackupSettings.Keep"/> nightly copies that this service made; older ones are deleted. Manual copies and any other file in the folder are never touched.</summary>
    private void Prune(BackupSettings settings)
    {
        if (settings.Folder is null) return;
        var old = db.Query("SELECT id, file_name FROM backup_runs WHERE kind = 'nightly' AND status = 'ok' AND kept = 1 AND folder = $f ORDER BY started_at DESC, id DESC",
            r => (Id: r.Int("id"), File: r.Text("file_name")), ("$f", settings.Folder)).Skip(settings.Keep).ToList();
        foreach (var (id, file) in old)
        {
            try
            {
                var path = Path.Combine(settings.Folder, file);
                if (Path.GetFileName(path) == file && File.Exists(path)) File.Delete(path);   // a name from our own record, never a path
            }
            catch (Exception e) when (e is IOException or UnauthorizedAccessException) { continue; }   // a copy that cannot be removed now is tried again next time
            db.InTransaction((c, t) => HubDb.Exec(c, "UPDATE backup_runs SET kept = 0 WHERE id = $id", t, ("$id", id)));
        }
    }

    // ---- the nightly round -----------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Called by the shop's own upkeep every few minutes. Makes the night's copy when it is due: copies are switched on, the time of day has come, and there is no good copy since then.
    /// If the PC was off at that time it is made as soon as the PC is on. After a failure it tries again an hour later, not every few minutes. Returns true when it made a try.
    /// </summary>
    public bool RunIfDue()
    {
        var settings = Settings();
        if (!settings.Enabled || string.IsNullOrWhiteSpace(settings.Folder)) return false;
        var due = DueSince(settings);
        if (due is null) return false;
        var last = Latest(any: true);
        if (last is { Good: false } failed && clock.UtcNow - failed.At < RetryAfterFailure && failed.At >= due) return false;
        RunNow(BackupKinds.Nightly);
        return true;
    }

    /// <summary>The moment today's copy became due, when no good copy has been made since then; null when nothing is due.</summary>
    private DateTimeOffset? DueSince(BackupSettings settings)
    {
        var context = shop.Current;
        var now = clock.UtcNow;
        var local = context.Time.ToLocal(now);
        var at = TimeOnly.ParseExact(settings.TimeLocal, "HH:mm", CultureInfo.InvariantCulture);
        var scheduledLocal = new DateTimeOffset(local.Year, local.Month, local.Day, at.Hour, at.Minute, 0, local.Offset);
        // Before today's time: yesterday's slot is the one that counts (a PC that was off overnight catches up when it is switched on, whichever side of the clock it is).
        if (scheduledLocal > local) scheduledLocal = scheduledLocal.AddDays(-1);
        var scheduled = scheduledLocal.ToUniversalTime();
        var good = Latest(any: false);
        return good is null || good.At < scheduled ? scheduled : null;
    }

    private BackupRun? Latest(bool any) => db.QueryOne(
        "SELECT id, started_at, kind, status, folder, file_name, size_bytes, sha256, schema_version, error FROM backup_runs " + (any ? "" : "WHERE status = 'ok' ") + "ORDER BY started_at DESC, id DESC LIMIT 1", Map);

    private static BackupRun Map(Microsoft.Data.Sqlite.SqliteDataReader r) =>
        new(r.Int("id"), r.Time("started_at"), r.Text("kind"), r.Text("status"), r.TextOrNull("folder"), r.TextOrNull("file_name"), r.Int("size_bytes"), r.TextOrNull("sha256"), (int)r.Int("schema_version"), r.TextOrNull("error"));

    public IReadOnlyList<BackupRun> Runs(int limit = 30) => db.Query(
        "SELECT id, started_at, kind, status, folder, file_name, size_bytes, sha256, schema_version, error FROM backup_runs ORDER BY started_at DESC, id DESC LIMIT $n", Map, ("$n", limit));

    // ---- what the owner sees ----------------------------------------------------------------------------------------------------------

    public BackupStatus Status()
    {
        var settings = Settings();
        var now = clock.UtcNow;
        var good = Latest(any: false);
        var failedSince = Latest(any: true) is { Good: false } f && (good is null || f.At > good.At) ? f : null;
        var overdue = settings.Enabled && (good is null || now - good.At > OverdueAfter);
        DateTimeOffset? next = null;
        if (settings.Enabled && !string.IsNullOrWhiteSpace(settings.Folder))
        {
            var local = shop.Current.Time.ToLocal(now);
            var at = TimeOnly.ParseExact(settings.TimeLocal, "HH:mm", CultureInfo.InvariantCulture);
            var candidate = new DateTimeOffset(local.Year, local.Month, local.Day, at.Hour, at.Minute, 0, local.Offset);
            next = (candidate > local ? candidate : candidate.AddDays(1)).ToUniversalTime();
        }

        return new BackupStatus(settings, good, failedSince, overdue, next, Say(settings, good, failedSince, overdue));
    }

    private string Say(BackupSettings settings, BackupRun? good, BackupRun? failed, bool overdue)
    {
        string When(DateTimeOffset at) => shop.Current.Time.ToLocal(at).ToString("d MMM yyyy, HH:mm", CultureInfo.InvariantCulture);
        if (!settings.Enabled) return good is null ? "Copies are switched off. Choose a place for them and switch them on, so that the shop can be put back if this PC is lost or broken." : $"Copies are switched off. The last good copy was made on {When(good.At)}.";
        if (failed is not null) return $"The last try did not work ({failed.Error}). " + (good is null ? "There is no good copy yet." : $"The last good copy was made on {When(good.At)}.");
        if (good is null) return "No copy has been made yet. The first one is made at " + settings.TimeLocal + ", or press Back up now.";
        return overdue ? $"The last good copy is from {When(good.At)}, which is too long ago. Check that the drive is plugged in." : $"The last good copy was made on {When(good.At)}.";
    }

    // ---- the copies in the folder, and putting one back ---------------------------------------------------------------------------------

    /// <summary>The copies this service can see in the folder (by their names), newest first.</summary>
    public IReadOnlyList<BackupFileInfo> Copies()
    {
        var folder = Settings().Folder;
        if (string.IsNullOrWhiteSpace(folder) || !Directory.Exists(folder)) return Array.Empty<BackupFileInfo>();
        try
        {
            return new DirectoryInfo(folder).EnumerateFiles("NextGenOS-shop-*.bak")
                .OrderByDescending(f => f.Name, StringComparer.Ordinal)
                .Select(f => new BackupFileInfo(f.FullName, f.Name, new DateTimeOffset(f.LastWriteTimeUtc, TimeSpan.Zero), f.Length)).ToList();
        }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException) { return Array.Empty<BackupFileInfo>(); }
    }

    /// <summary>
    /// Checks a copy and prepares it to be put back the next time the program starts (the running shop cannot swap its own file). Refuses a copy that is damaged, whose books do not add up,
    /// or that was made by a newer program. Only the owner. The shop as it is now is kept, not deleted, when the copy is put back.
    /// </summary>
    public RestoreStaged StageRestore(string backupFile, long? userId)
    {
        access.Require(Perm.Settings);
        var staged = PendingRestore.Stage(Path.GetDirectoryName(Path.GetFullPath(db.Path))!, backupFile);
        audit.Log(userId, "restore-staged", "backup", null, staged.SourceName);
        return staged;
    }

    /// <summary>Takes back a copy that was set aside but not yet put back (the owner changed their mind). Only the owner.</summary>
    public void CancelRestore(long? userId)
    {
        access.Require(Perm.Settings);
        PendingRestore.Cancel(Path.GetDirectoryName(Path.GetFullPath(db.Path))!);
        audit.Log(userId, "restore-cancelled", "backup", null, null);
    }
}
