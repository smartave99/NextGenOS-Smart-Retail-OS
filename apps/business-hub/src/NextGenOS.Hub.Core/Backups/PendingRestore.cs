using System.Text.Json;
using NextGenOS.Hub.Data;

namespace NextGenOS.Hub.Backups;

/// <summary>A copy checked and made ready to be put back the next time the program starts.</summary>
public sealed record RestoreStaged(string SourceName, int Version, DateTimeOffset StagedAt);

/// <summary>What happened when the program started and found a copy waiting. <see cref="KeptAs"/> is where the shop as it was before has been kept.</summary>
public sealed record RestoreOutcome(bool Done, string Message, string? KeptAs, string? SourceName, DateTimeOffset At);

/// <summary>
/// Putting a copy back (blueprint OPS-002 and the restore drill). A running shop cannot swap its own file, so putting a copy back is two steps: <see cref="Stage"/> checks the copy and
/// sets it aside with a note; the next time the program starts, <see cref="ApplyIfPending"/> (before the shop is opened) keeps the shop as it is, puts the copy in its place and
/// removes the note. The same works on a clean PC with no shop at all: choose the copy, start the program. Nothing is ever deleted: the shop as it was stays in a folder of its own.
/// </summary>
public static class PendingRestore
{
    private const string FolderName = "restore";
    private static readonly JsonSerializerOptions Json = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true };

    private sealed record Marker(string SourceName, int Version, DateTimeOffset StagedAt);

    private static string Dir(string dataFolder) => Path.Combine(dataFolder, FolderName);

    /// <summary>Checks the copy and sets it aside to be put back at the next start. Throws a <see cref="HubException"/> (<c>restore</c>) in plain words when the copy cannot be used.</summary>
    public static RestoreStaged Stage(string dataFolder, string backupFile)
    {
        if (string.IsNullOrWhiteSpace(backupFile) || !File.Exists(backupFile)) throw new HubException("restore", "That copy is not there. Check that the drive is plugged in and the file name is right.");
        var report = DatabaseCheck.Inspect(backupFile, books: true);
        if (!report.Healthy) throw new HubException("restore", "That copy cannot be used, so nothing was changed: " + string.Join(" ", report.Problems));
        if (report.Version > HubDb.LatestVersion)
            throw new HubException("restore", $"That copy was made by a newer version of this program (structure {report.Version}; this program knows {HubDb.LatestVersion}). Update the program first, then put the copy back.");
        try
        {
            var dir = Dir(dataFolder);
            Directory.CreateDirectory(dir);
            var temporary = Path.Combine(dir, "pending.db.part");
            File.Copy(backupFile, temporary, overwrite: true);
            var again = DatabaseCheck.Inspect(temporary, books: false);   // what was copied is what was checked
            if (!again.Healthy || again.Version != report.Version) { File.Delete(temporary); throw new HubException("restore", "The copy changed while it was being set aside, so nothing was changed. Try again."); }
            File.Move(temporary, Path.Combine(dir, "pending.db"), overwrite: true);
            var marker = new Marker(Path.GetFileName(backupFile), report.Version, DateTimeOffset.UtcNow);
            File.WriteAllText(Path.Combine(dir, "pending.json"), JsonSerializer.Serialize(marker, Json));
            return new RestoreStaged(marker.SourceName, marker.Version, marker.StagedAt);
        }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException)
        {
            throw new HubException("restore", "The copy could not be set aside (" + e.Message + "), so nothing was changed. Check that this PC has room.");
        }
    }

    /// <summary>True when a copy is waiting to be put back at the next start.</summary>
    public static bool IsPending(string dataFolder) => File.Exists(Path.Combine(Dir(dataFolder), "pending.json"));

    /// <summary>Takes back a copy that was set aside but not yet put back (the owner changed their mind).</summary>
    public static void Cancel(string dataFolder)
    {
        foreach (var name in new[] { "pending.json", "pending.db", "pending.db.part" })
        {
            try { File.Delete(Path.Combine(Dir(dataFolder), name)); }
            catch (Exception e) when (e is IOException or UnauthorizedAccessException) { /* removed at the next start by Apply, which refuses a note without a good copy */ }
        }
    }

    /// <summary>
    /// Called when the program starts, before the shop is opened. When a copy is waiting: checks it once more, keeps the shop as it is (in <c>before-restore-...</c> next to it), puts the copy in
    /// its place and removes the note. If anything goes wrong, the shop is left exactly as it was and the reason is returned (and written down for the screen). Returns null when nothing was waiting.
    /// </summary>
    public static RestoreOutcome? ApplyIfPending(string dataFolder, string shopFile)
    {
        var dir = Dir(dataFolder);
        var markerFile = Path.Combine(dir, "pending.json");
        var staged = Path.Combine(dir, "pending.db");
        if (!File.Exists(markerFile)) return null;
        var now = DateTimeOffset.UtcNow;
        Marker? marker = null;
        var movedAway = new List<(string From, string To)>();
        try
        {
            marker = JsonSerializer.Deserialize<Marker>(File.ReadAllText(markerFile), Json);
            if (!File.Exists(staged)) return Finish(dir, new RestoreOutcome(false, "The copy that was set aside is gone, so the shop was left as it is.", null, marker?.SourceName, now), markerFile);
            var report = DatabaseCheck.Inspect(staged, books: true);
            if (!report.Healthy || report.Version > HubDb.LatestVersion)
                return Finish(dir, new RestoreOutcome(false, "The copy that was set aside did not pass its check when the program started, so the shop was left as it is: " + string.Join(" ", report.Problems), null, marker?.SourceName, now), markerFile);

            string? keptAs = null;
            if (File.Exists(shopFile))
            {
                keptAs = Path.Combine(dataFolder, "before-restore-" + now.UtcDateTime.ToString("yyyyMMdd'T'HHmmss'Z'", System.Globalization.CultureInfo.InvariantCulture));
                Directory.CreateDirectory(keptAs);
                foreach (var extra in new[] { "", "-wal", "-shm" })
                {
                    var from = shopFile + extra;
                    if (!File.Exists(from)) continue;
                    var to = Path.Combine(keptAs, Path.GetFileName(from));
                    File.Move(from, to);
                    movedAway.Add((from, to));
                }
            }

            File.Move(staged, shopFile);
            var done = new RestoreOutcome(true, $"The shop was put back from the copy \"{marker?.SourceName}\".", keptAs, marker?.SourceName, now);
            return Finish(dir, done, markerFile);
        }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException or JsonException)
        {
            foreach (var (from, to) in movedAway.AsEnumerable().Reverse())   // put the shop back exactly as it was
            {
                try { if (File.Exists(to) && !File.Exists(from)) File.Move(to, from); }
                catch (Exception) { /* the shop as it was is still in its kept folder, and the message says where */ }
            }

            var kept = movedAway.Count > 0 ? Path.GetDirectoryName(movedAway[0].To) : null;
            return Finish(dir, new RestoreOutcome(false, "The copy could not be put back (" + e.Message + "), so the shop was left as it was.", kept, marker?.SourceName, now), markerFile);
        }
    }

    private static RestoreOutcome Finish(string dir, RestoreOutcome outcome, string markerFile)
    {
        try { File.WriteAllText(Path.Combine(dir, "last.json"), JsonSerializer.Serialize(outcome, Json)); }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException) { /* the screen simply has nothing to show */ }
        try { File.Delete(markerFile); }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException) { /* a note that cannot be removed is refused again next time */ }
        if (!outcome.Done)
        {
            try { File.Delete(Path.Combine(dir, "pending.db")); }
            catch (Exception e) when (e is IOException or UnauthorizedAccessException) { /* left; harmless */ }
        }

        return outcome;
    }

    /// <summary>What happened the last time a copy was put back (or could not be), for the screen. Null: never.</summary>
    public static RestoreOutcome? Last(string dataFolder)
    {
        try
        {
            var file = Path.Combine(Dir(dataFolder), "last.json");
            return File.Exists(file) ? JsonSerializer.Deserialize<RestoreOutcome>(File.ReadAllText(file), Json) : null;
        }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException or JsonException)
        {
            return null;
        }
    }
}
