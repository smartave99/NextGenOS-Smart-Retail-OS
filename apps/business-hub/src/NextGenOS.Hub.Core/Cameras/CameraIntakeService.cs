using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Events;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Cameras;

/// <summary>
/// How a camera program tells the Hub what it saw (Version 2, Phase 7, step 2). The Hub itself still reads no picture and no video: a separate program on this same computer does that one day (how
/// video is decoded and which detection model it uses are the owner's decisions and are not made here), and sends only <i>counts</i> to the Hub, which writes them into the business event history as
/// observations, like any other sensor.
/// <list type="bullet">
/// <item><b>A key for each camera.</b> The owner makes a key for a registered camera; it is shown once and only its fingerprint is kept. A message without the right key, or with the key of a camera that
/// was retired, is refused with one plain answer that says nothing more.</item>
/// <item><b>Only what the owner switched on.</b> Nothing is kept unless "Camera analytics" and "Business events" are both on, and that camera is switched on.</item>
/// <item><b>Only what the camera is set to look for, and only if it is sure enough.</b> The kinds of thing and the least confidence are the camera's own settings; the sender cannot widen them.
/// The place the observation is about is the camera's place, not something the sender says.</item>
/// <item><b>A strict message.</b> Only the kind of thing, how many, how sure and when are accepted (see <see cref="IntakeBatch"/>). Anything else is refused, so a picture, a face, a name or a track of
/// one person cannot be sent in.</item>
/// <item><b>Not too fast.</b> A camera can send at most <see cref="MaxPerMinute"/> observations a minute; more is refused whole.</item>
/// <item><b>Written as video-derived data.</b> The observations are kept with the data class <c>VIDEO</c> (short retention, owner's eyes only) and never leave the computer.</item>
/// </list>
/// The messages are accepted only from this computer itself (the web door checks that); this class does not know about the network.
/// </summary>
public sealed partial class CameraIntakeService(HubDb db, IClock clock, AuditService audit, FeatureFlagService flags, CameraService cameras, EventStore events, Access access)
{
    private const string Tenant = FeatureFlagService.Tenant;
    private const string Site = FeatureFlagService.Site;

    /// <summary>The kind of observation a camera program writes.</summary>
    public const string ObservationKind = "object.detected";

    /// <summary>How many observations one camera may send in a minute (a test lowers it on its own copy so that it need not write hundreds of rows).</summary>
    public const int DefaultMaxPerMinute = 600;

    public int MaxPerMinute { get; internal set; } = DefaultMaxPerMinute;
    public const int MaxCount = 1000;
    public static readonly TimeSpan MaxAge = TimeSpan.FromHours(1);

    [GeneratedRegex(@"^ngc-([0-9]{1,9})-([A-Za-z0-9_\-]{43})$", RegexOptions.CultureInvariant)]
    private static partial Regex KeyPattern();

    private readonly object gate = new();
    private readonly Dictionary<long, Queue<(DateTimeOffset At, int Number)>> recent = new();

    // ---- the key ---------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Makes a new key for a camera (an old one stops working at once) and returns it. It is shown to the owner this one time: only a fingerprint of it is kept. The owner gives it to the camera
    /// program.
    /// </summary>
    public string MakeKey(long cameraId, long? userId)
    {
        access.Require(Perm.Ai);
        cameras.RequireOn();
        var camera = cameras.Get(cameraId);
        if (camera.Retired) throw new HubException("retired", "That camera was retired.");
        var key = "ngc-" + camera.Id.ToString(CultureInfo.InvariantCulture) + "-" + Base64Url(RandomNumberGenerator.GetBytes(32));
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "DELETE FROM camera_intake_keys WHERE tenant_id = $t AND site_id = $s AND camera_id = $id", t, ("$t", Tenant), ("$s", Site), ("$id", camera.Id));
            HubDb.Exec(c, "INSERT INTO camera_intake_keys(tenant_id, site_id, camera_id, key_hash, created_at, created_by) VALUES ($t, $s, $id, $h, $at, $u)", t,
                ("$t", Tenant), ("$s", Site), ("$id", camera.Id), ("$h", Fingerprint(key)), ("$at", Iso.Text(clock.UtcNow)), ("$u", userId));
            audit.Log(c, t, userId, "camera.key", "camera", camera.Id, camera.Name);
        });
        lock (gate) recent.Remove(camera.Id);
        return key;
    }

    /// <summary>Removes a camera's key: the camera program that had it is refused from now on.</summary>
    public void RemoveKey(long cameraId, long? userId)
    {
        access.Require(Perm.Ai);
        var camera = cameras.Get(cameraId);
        db.InTransaction((c, t) =>
        {
            if (HubDb.Exec(c, "DELETE FROM camera_intake_keys WHERE tenant_id = $t AND site_id = $s AND camera_id = $id", t, ("$t", Tenant), ("$s", Site), ("$id", camera.Id)) > 0)
                audit.Log(c, t, userId, "camera.key-removed", "camera", camera.Id, camera.Name);
        });
    }

    /// <summary>Which cameras have a key, since when, and how much each camera program has sent. Never the key.</summary>
    public IReadOnlyList<IntakeKeyInfo> Keys()
    {
        access.Require(Perm.Ai);
        return db.Query("SELECT camera_id, created_at, last_used_at, accepted_total, rejected_total FROM camera_intake_keys WHERE tenant_id = $t AND site_id = $s ORDER BY camera_id",
            r => new IntakeKeyInfo(r.Int("camera_id"), r.Time("created_at"), r.TimeOrNull("last_used_at"), r.Int("accepted_total"), r.Int("rejected_total")), ("$t", Tenant), ("$s", Site));
    }

    // ---- a message ---------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Judges a message and keeps what passes. There is no signed-in person: the key says which camera is speaking. Refusals of the whole message are a <see cref="HubException"/> with a code
    /// (<c>bad-key</c>, <c>not-licensed</c>, <c>cameras-off</c>, <c>events-off</c>, <c>camera-off</c>, <c>too-fast</c>, <c>bad-batch</c>); a single observation that is not kept is listed in the answer.
    /// </summary>
    public IntakeResult Accept(string? key, IntakeBatch? batch) => Accept(Authenticate(key), batch);

    /// <summary>The same, from the text of the message. The key is checked first, so a wrong key learns nothing about how the message is read.</summary>
    public IntakeResult AcceptJson(string? key, string? json)
    {
        var cameraId = Authenticate(key);
        return Accept(cameraId, IntakeBatch.Parse(json));
    }

    private IntakeResult Accept(long cameraId, IntakeBatch? batch)
    {
        if (!flags.Licensed) throw new HubException("not-licensed", "Cameras are not part of this shop's licence.");
        if (!cameras.On) throw new HubException("cameras-off", "Camera analytics is switched off, so nothing is kept.");
        if (!events.Recording) throw new HubException("events-off", "The business event history is switched off, so nothing is kept.");
        var camera = cameras.ForIntake(cameraId);
        if (camera is null || camera.Retired) throw new HubException("bad-key", "The key is not valid.");
        if (!camera.Enabled) throw new HubException("camera-off", "That camera is switched off, so what it sees is not kept.");
        if (batch is null || batch.Detections.Count is 0 or > IntakeBatch.MaxDetections) throw new HubException("bad-batch", "A message holds from 1 to " + IntakeBatch.MaxDetections + " observations.");
        var model = batch.Model is null ? null : EventRules.Id(batch.Model, "model");
        var version = batch.Version is null ? null : EventRules.Id(batch.Version, "model version");
        TakeRate(camera.Id, batch.Detections.Count);

        var now = clock.UtcNow;
        var minimum = camera.MinConfidencePercent / 100.0;
        var rejected = new List<IntakeReject>();
        var passing = new List<(int Index, ObservationInput Input)>();
        for (var i = 0; i < batch.Detections.Count; i++)
        {
            var seen = batch.Detections[i];
            if (Judge(seen, camera, minimum, now) is { } problem) rejected.Add(new IntakeReject(i, problem));
            else
                passing.Add((i, new ObservationInput(ObservationKind, SourceType.Model, camera.Ref, DataClass.Video, seen.At ?? now, seen.Confidence!.Value, model, version, camera.ZoneRef, null, seen.Class,
                    JsonSerializer.Serialize(new { @class = seen.Class, count = seen.Count ?? 1 }))));
        }

        // All that passed are written in one step; the event history's own rules are the last word (for example: it cannot have happened in the future).
        var written = events.ObserveMany(passing.Select(p => p.Input).ToList());
        var accepted = 0;
        for (var n = 0; n < passing.Count; n++)
        {
            if (written[n].Problem is { } why) rejected.Add(new IntakeReject(passing[n].Index, why));
            else accepted++;
        }

        rejected.Sort((a, b) => a.Index.CompareTo(b.Index));
        db.InTransaction((c, t) => HubDb.Exec(c,
            "UPDATE camera_intake_keys SET last_used_at = $at, accepted_total = accepted_total + $a, rejected_total = rejected_total + $r WHERE tenant_id = $t AND site_id = $s AND camera_id = $id", t,
            ("$at", Iso.Text(now)), ("$a", accepted), ("$r", rejected.Count), ("$t", Tenant), ("$s", Site), ("$id", camera.Id)));
        return new IntakeResult(accepted, rejected);
    }

    /// <summary>Why one observation is not kept, in plain words, or null when it passes.</summary>
    private static string? Judge(IntakeDetection seen, Camera camera, double minimum, DateTimeOffset now)
    {
        if (seen.Problem is not null) return seen.Problem;
        if (string.IsNullOrWhiteSpace(seen.Class)) return "Name what was seen ('class').";
        if (!camera.Classes.Contains(seen.Class))
            return (SafeWord(seen.Class) is { } word ? "'" + word + "'" : "That") + " is not something this camera is set to look for.";
        if (seen.Confidence is not { } confidence || double.IsNaN(confidence) || confidence < 0 || confidence > 1) return "How sure ('confidence') must be a number from 0 to 1.";
        if (confidence < minimum) return "The program was less sure than this camera's setting (at least " + IntakeBatch.Percent(minimum) + " percent).";
        if (seen.Count is { } count && (count < 1 || count > MaxCount)) return "The count must be a whole number from 1 to " + MaxCount + ".";
        if (seen.At is { } at && at < now - MaxAge) return "It is too old (more than an hour ago).";
        return null;
    }

    private static string? SafeWord(string text) => Regex.IsMatch(text, @"^[a-z_]{1,30}$", RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(250)) ? text : null;

    // ---- the key check -----------------------------------------------------------------------------------------------------------------

    private long Authenticate(string? key)
    {
        var match = key is null || key.Length > 80 ? null : KeyPattern().Match(key);
        long id = 0;
        string? stored = null;
        if (match is { Success: true } && long.TryParse(match.Groups[1].Value, NumberStyles.None, CultureInfo.InvariantCulture, out id))
            stored = db.Scalar("SELECT key_hash FROM camera_intake_keys WHERE tenant_id = $t AND site_id = $s AND camera_id = $id", ("$t", Tenant), ("$s", Site), ("$id", id)) as string;

        // The same work is done whatever was wrong, and the answer never says which part was.
        var given = SHA256.HashData(Encoding.UTF8.GetBytes(key ?? ""));
        var expected = stored is { Length: 64 } ? Convert.FromHexString(stored) : new byte[32];
        var same = CryptographicOperations.FixedTimeEquals(given, expected);
        if (!same || stored is null) throw new HubException("bad-key", "The key is not valid.");
        return id;
    }

    private static string Fingerprint(string key) => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(key))).ToLowerInvariant();

    private static string Base64Url(byte[] bytes) => Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');

    // ---- not too fast ------------------------------------------------------------------------------------------------------------------

    /// <summary>One camera can send at most <see cref="MaxPerMinute"/> observations in any minute. A message that would go over is refused whole, so a camera program that is too chatty is told.</summary>
    private void TakeRate(long cameraId, int number)
    {
        var now = clock.UtcNow;
        lock (gate)
        {
            if (!recent.TryGetValue(cameraId, out var queue)) recent[cameraId] = queue = new Queue<(DateTimeOffset, int)>();
            while (queue.Count > 0 && queue.Peek().At <= now - TimeSpan.FromMinutes(1)) queue.Dequeue();
            if (queue.Sum(x => x.Number) + number > MaxPerMinute) throw new HubException("too-fast", "This camera sent too much in the last minute (at most " + MaxPerMinute + " observations). Send fewer, and add up what is seen at the same moment ('count').");
            queue.Enqueue((now, number));
        }
    }
}
