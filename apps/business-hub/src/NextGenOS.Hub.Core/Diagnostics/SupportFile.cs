using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Backups;
using NextGenOS.Hub.Counters;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Diagnostics;

/// <summary>One part of the support file: a heading and the lines under it, in plain words.</summary>
public sealed record SupportSection(string Heading, IReadOnlyList<string> Lines);

/// <summary>
/// Takes out of a piece of text everything that must not be in a support file: folders on the PC, addresses, telephone numbers and long numbers, card numbers, passwords and keys written as
/// "name=value", long codes, network addresses, and the names and addresses the shop keeps for its people. What is left is for a person at the supplier to read.
/// </summary>
public static partial class SupportRedaction
{
    [GeneratedRegex(@"(?:[A-Za-z]:\\|\\\\)[^\s""'<>|]*|(?:/(?:home|Users|root|var|opt|tmp|mnt|media|srv|etc|usr|ProgramData)/)[^\s""'<>|]*", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 250)]
    private static partial Regex Folder();

    [GeneratedRegex(@"[A-Za-z0-9._%+\-]{1,64}@[A-Za-z0-9\-]{1,63}(?:\.[A-Za-z0-9\-]{1,63})+", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 250)]
    private static partial Regex Email();

    [GeneratedRegex(@"\b(?:\d{1,3}\.){3}\d{1,3}\b", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 250)]
    private static partial Regex Ip();

    [GeneratedRegex(@"\+?\d(?:[\s().\-]?\d){6,}", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 250)]
    private static partial Regex LongNumber();

    [GeneratedRegex(@"(?i)\b(password|passwd|pwd|passphrase|secret|token|api[_-]?key|key|authorization|bearer|cookie|connectionstring)\b\s*[=:]\s*\S+", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 250)]
    private static partial Regex Secret();

    [GeneratedRegex(@"(?i)\b(?:bearer|basic)\s+[A-Za-z0-9._~+/=\-]+", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 250)]
    private static partial Regex BearerToken();

    [GeneratedRegex(@"[A-Za-z0-9+/_\-]{32,}={0,2}", RegexOptions.CultureInvariant, matchTimeoutMilliseconds: 250)]
    private static partial Regex LongCode();

    /// <summary>The text with all of that replaced by a short note in brackets, kept to a sensible length.</summary>
    public static string Clean(string? text, IReadOnlyCollection<string>? knownPeople = null, int max = 400)
    {
        if (string.IsNullOrWhiteSpace(text)) return "";
        var t = Regex.Replace(text, @"\s+", " ", RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(250)).Trim();
        try
        {
            t = BearerToken().Replace(t, "[hidden]");
            t = Secret().Replace(t, m => m.Groups[1].Value + "=[hidden]");
            t = Folder().Replace(t, "[folder]");
            t = Email().Replace(t, "[address]");
            t = Ip().Replace(t, "[network address]");
            t = LongNumber().Replace(t, "[number]");
            t = LongCode().Replace(t, "[hidden]");
        }
        catch (RegexMatchTimeoutException)
        {
            return "[could not be cleaned, so it is left out]";
        }

        if (knownPeople is not null)
            foreach (var known in knownPeople.Where(k => k.Trim().Length >= 3).OrderByDescending(k => k.Length))
                t = t.Replace(known.Trim(), "[a person]", StringComparison.OrdinalIgnoreCase);
        return t.Length > max ? t[..max] + "…" : t;
    }
}

/// <summary>
/// The facts about the shop that a support file holds (the Help button; owner's decision 18 in <c>docs/PLATFORM-DECISIONS.md</c>): the state of the data, the copies, the counter PCs, the AI
/// helpers and the waiting lines, and what the audit record counts. Figures about the machine, the program and the licence are added by the program that hosts the Hub. Nothing here reads a sale,
/// a customer, a staff name, an amount, a password or a key, and nothing leaves the PC: the owner reads the file and decides whether to send it.
/// </summary>
public sealed class SupportService(HubApp app)
{
    /// <summary>The parts of the file that the shop itself can speak for. Owner only (it is a look at how the shop is set up).</summary>
    public IReadOnlyList<SupportSection> Sections()
    {
        app.Access.Require(Perm.Settings);
        var people = new PersonalValues(app.Db).Known();
        string Clean(string? text) => SupportRedaction.Clean(text, people);
        var sections = new List<SupportSection>();

        // The data.
        var data = new List<string>();
        var size = File.Exists(app.Db.Path) ? new FileInfo(app.Db.Path).Length : 0;
        var versions = app.Db.Query("SELECT MAX(version) FROM schema_version", r => r.IsDBNull(0) ? 0 : r.GetInt32(0)).FirstOrDefault();
        data.Add($"Shop file: {size / 1024 / 1024.0:0.#} MB, database step {versions} of {HubDb.LatestVersion}.");
        var check = DatabaseCheck.Inspect(app.Db.Path, books: true);
        data.Add(check.Healthy ? "File check: no problem found (the file is sound and the books add up)." : "File check found: " + string.Join(" ", check.Problems.Select(Clean)));
        data.Add("Backup made before the last update: " + (app.Db.LastBackup is null ? "none this time" : "yes"));
        sections.Add(new SupportSection("Your shop's data", data));

        // The copies.
        var copies = new List<string>();
        var status = app.Backups.Status();
        copies.Add("Nightly copies: " + (status.Settings.Enabled ? "on, " + status.Settings.TimeLocal + ", keeping " + status.Settings.Keep : "off") + "; place " + (string.IsNullOrWhiteSpace(status.Settings.Folder) ? "not chosen" : "chosen"));
        copies.Add("Last good copy: " + (status.LastGood is { } good ? good.At.UtcDateTime.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture) + " UTC, " + good.SizeBytes / 1024 + " KB" : "none"));
        if (status.LastFailed is { } bad) copies.Add("Last failed copy: " + bad.At.UtcDateTime.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture) + " UTC: " + Clean(bad.Error));
        copies.Add(status.Overdue ? "A copy is overdue." : "No copy is overdue.");
        sections.Add(new SupportSection("Copies of your shop", copies));

        // Counter PCs.
        var net = app.Network.Status();
        var paired = Convert.ToInt64(app.Db.Scalar("SELECT COUNT(*) FROM network_devices WHERE revoked_at IS NULL") ?? 0L);
        sections.Add(new SupportSection("Counter PCs", [
            $"Counter PCs: chosen {(net.Chosen ? "on" : "off")}, listening {(net.Running ? "yes" : "no")}, {paired} paired PC(s)." + (net.RestartNeeded ? " A restart is needed." : ""),
            net.Problem is { } p ? "Problem: " + Clean(p) : "No problem reported.",
        ]));

        // Updates: which version, whether it looks, and how the last look went (no address of the online folder; nothing about the shop is sent by looking).
        var update = app.Updates.View();
        var updates = new List<string>
        {
            update.Built ? "Looks for new versions: " + (update.Looking ? "yes" : "switched off") : "This copy was not made to look for new versions.",
            "Last look: " + (update.CheckedAt is { } looked ? looked.UtcDateTime.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture) + " UTC" : "never"),
            "Where it stands: " + (update.State switch
            {
                "up-to-date" => "the newest version is running",
                "ready" => "version " + update.Version + " is ready and waiting for the owner",
                "approved" => "version " + update.Version + " is approved and waiting to be run",
                "failed" => "the last look did not work",
                _ => "not looked yet",
            }) + ".",
        };
        if (update.Problem is { } updateProblem) updates.Add("Problem: " + Clean(updateProblem));
        sections.Add(new SupportSection("New versions of the program", updates));

        // AI helpers, queue, actions.
        var ai = new List<string>();
        ai.Add("AI part in the licence: " + (app.Ai.Flags.Licensed ? "yes" : "no"));
        var on = app.Ai.Flags.All().Where(f => f.Chosen).Select(f => f.Key).ToList();
        ai.Add("Switches on: " + (on.Count == 0 ? "none" : string.Join(", ", on)));
        var providers = app.Ai.Providers.List();
        ai.Add("Services connected: " + providers.Count + (providers.Count == 0 ? "" : " (" + string.Join(", ", providers.GroupBy(x => x.Location).OrderBy(g => g.Key).Select(g => g.Count() + " " + g.Key)) + ")"));
        var queue = app.Outbox.Stats();
        ai.Add($"Business-event messages: {queue.Waiting} waiting, {queue.Failed} could not be written, {queue.Delivered} written.");
        var waitingActions = Convert.ToInt64(app.Db.Scalar("SELECT COUNT(*) FROM actions WHERE status = 'awaiting_approval'") ?? 0L);
        var failedActions = Convert.ToInt64(app.Db.Scalar("SELECT COUNT(*) FROM actions WHERE status = 'failed'") ?? 0L);
        ai.Add($"Suggested actions: {waitingActions} waiting for approval, {failedActions} that could not be done.");
        var refused = Convert.ToInt64(app.Db.Scalar("SELECT COUNT(*) FROM ai_usage WHERE outcome = 'refused'") ?? 0L);
        var failedUse = Convert.ToInt64(app.Db.Scalar("SELECT COUNT(*) FROM ai_usage WHERE outcome = 'failed'") ?? 0L);
        ai.Add($"AI requests not allowed: {refused}; that did not work: {failedUse}.");
        sections.Add(new SupportSection("AI helpers and waiting lines", ai));

        // What the record counts (numbers only, never who or what).
        var week = Iso.Text(app.Clock.UtcNow.AddDays(-7));
        var counts = app.Db.Query(
            "SELECT action, COUNT(*) FROM audit_log WHERE at >= $since AND action IN ('access-denied', 'login-locked', 'restore', 'restore-failed', 'action.failed', 'action.done', 'insight.run', 'void') GROUP BY action ORDER BY action",
            r => r.GetString(0) + ": " + r.GetInt64(1), ("$since", week));
        sections.Add(new SupportSection("Last 7 days in the activity record (counts only)", counts.Count == 0 ? ["Nothing of note."] : counts));

        // What kind of shop this is (no name).
        var settings = app.Shop.Settings;
        sections.Add(new SupportSection("The kind of shop", [$"Kind of business: {settings.Industry}; country: {settings.Country}; set-up finished: {(settings.SetupDone ? "yes" : "no")}."]));
        return sections;
    }

    /// <summary>The whole file as text: a note on what it is and is not, the owner's own words, then the parts.</summary>
    public static string Render(string title, DateTimeOffset at, string? message, IEnumerable<SupportSection> sections, IReadOnlyCollection<string>? knownPeople = null)
    {
        var text = new StringBuilder();
        text.Append(title.ToUpperInvariant()).Append(" — SUPPORT FILE").AppendLine();
        text.Append("Made on ").Append(at.UtcDateTime.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture)).AppendLine(" (universal time).");
        text.AppendLine();
        text.AppendLine("Read this before you send it. It holds versions and settings, the state of your licence, of your data and of your copies, and the last problems the program noticed. It holds no sales, no customers, no staff names, no amounts, no passwords and no keys. The program has not sent it anywhere: you decide whether to.");
        text.AppendLine();
        text.AppendLine("WHAT YOU SAID");
        text.AppendLine(string.IsNullOrWhiteSpace(message) ? "(nothing was written)" : SupportRedaction.Clean(message, knownPeople, 1000));
        foreach (var section in sections)
        {
            text.AppendLine();
            text.AppendLine(section.Heading.ToUpperInvariant());
            foreach (var line in section.Lines) text.Append("- ").AppendLine(line);
        }

        return text.ToString();
    }
}
