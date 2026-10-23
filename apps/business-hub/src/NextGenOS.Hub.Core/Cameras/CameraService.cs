using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using NextGenOS.Hub.Ai;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Cameras;

/// <summary>
/// The register of the shop's cameras (Version 2, Phase 7, step 1). It keeps which cameras there are, where they are on the shop's own network, what each may look for and how sure the program
/// must be, and whether the owner has switched each one on, and it can ask "does the camera answer?". <b>It reads no picture and no video.</b> Nothing here watches anything: the steps that
/// follow (taking a picture from a stream, finding people and trolleys in it, writing what was found as observations) are separate, each behind its own test.
/// <list type="bullet">
/// <item><b>Off until the owner says so.</b> The feature switch "Camera analytics" is off at the start; every camera is off until the owner switches that camera on, and a camera can be switched on
/// only after the program has reached it (or, for a camera plugged into this computer, because that cannot be checked from here). Changing a camera's kind or address switches it off again.</item>
/// <item><b>The shop's own network only.</b> A camera's address must be on this computer or on the shop's network; a camera at an internet address is refused, and so is one whose name turns out
/// to point outside. Video stays in the shop (<c>docs/VERSION-2.md</c>, "local first"); nothing in the register is ever sent to an AI service.</item>
/// <item><b>No password in the register.</b> An address with a user name or password in it is refused; the camera's password is typed in its own box and kept in the computer's secret store, never in
/// the database, the audit trail or on a screen.</item>
/// <item><b>No faces.</b> What a camera may look for is a short closed list (people, trolleys, baskets, products); a person is only "someone is there". There is no list entry for a face, and none
/// can be added from a screen.</item>
/// <item><b>Only the owner.</b> The AI helpers' permission (owners), and the licence's AI part, are needed to add, change, test or switch on a camera.</item>
/// </list>
/// </summary>
public sealed class CameraService(HubDb db, IClock clock, AuditService audit, FeatureFlagService flags, ISecretStore secrets, Access access)
{
    private const string Tenant = FeatureFlagService.Tenant;
    private const string Site = FeatureFlagService.Site;

    public const int MaxCameras = 64;
    public const int MaxNameChars = 80;
    public const int MaxAddressChars = 300;
    public const int MaxPasswordChars = Secrets.MaxLength;
    public const int DefaultMinConfidence = 50;
    public const int LowestMinConfidence = 10;
    public const int HighestMinConfidence = 99;
    public static readonly TimeSpan CheckTimeout = TimeSpan.FromSeconds(3);

    private static readonly string[] PictureFiles = [".mp4", ".avi", ".mkv", ".mov", ".mjpeg", ".jpg", ".jpeg", ".png"];

    /// <summary>True while a camera can be added or tested: the licence has the AI part and "Camera analytics" is on.</summary>
    public bool On => flags.IsEnabled(FlagKey.CameraAnalytics);

    private void RequireOn()
    {
        if (!flags.Licensed) throw new HubException("not-licensed", "Cameras are not part of this shop's licence.");
        if (!flags.IsEnabled(FlagKey.CameraAnalytics)) throw new HubException("cameras-off", "Camera analytics is switched off. The owner can switch it on under Settings, AI helpers.");
    }

    // ---- the cameras ------------------------------------------------------------------------------------------------------------

    public Camera Register(CameraInput input, long? userId)
    {
        access.Require(Perm.Ai);
        RequireOn();
        var made = Check(input);
        if (Convert.ToInt64(db.Scalar("SELECT COUNT(*) FROM cameras WHERE tenant_id = $t AND site_id = $s AND retired_at IS NULL", ("$t", Tenant), ("$s", Site)) ?? 0L, CultureInfo.InvariantCulture) >= MaxCameras)
            throw new HubException("too-many", "There can be at most " + MaxCameras + " cameras. Retire one that is not used any more.");
        var now = clock.UtcNow;
        var id = db.InTransaction((c, t) =>
        {
            var next = Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MAX(id), 0) + 1 FROM cameras WHERE tenant_id = $t AND site_id = $s", t, ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);
            var slug = Slug(made.Name);
            var key = slug;
            for (var n = 2; HubDb.Scalar(c, "SELECT 1 FROM cameras WHERE tenant_id = $t AND site_id = $s AND ref = $r", t, ("$t", Tenant), ("$s", Site), ("$r", "camera:" + key)) is not null; n++) key = slug + "-" + n;
            HubDb.Exec(c,
                "INSERT INTO cameras(tenant_id, site_id, id, ref, name, kind, address, zone_ref, classes, min_confidence, enabled, created_at, created_by, updated_at, updated_by) " +
                "VALUES ($t, $s, $id, $ref, $name, $kind, $addr, $zone, $cls, $conf, 0, $at, $u, $at, $u)", t,
                ("$t", Tenant), ("$s", Site), ("$id", next), ("$ref", "camera:" + key), ("$name", made.Name), ("$kind", made.Kind), ("$addr", made.Address), ("$zone", made.ZoneRef),
                ("$cls", string.Join(",", made.Classes)), ("$conf", made.MinConfidencePercent), ("$at", Iso.Text(now)), ("$u", userId));
            audit.Log(c, t, userId, "camera.add", "camera", next, made.Name);
            return next;
        });
        return Get(id);
    }

    /// <summary>Changes what is written about a camera. A new kind or address means it is a different thing to reach, so the camera is switched off again and its check is forgotten.</summary>
    public Camera Update(long id, CameraInput input, long? userId)
    {
        access.Require(Perm.Ai);
        RequireOn();
        var before = Get(id);
        if (before.Retired) throw new HubException("retired", "That camera was retired.");
        var made = Check(input);
        var moved = before.Kind != made.Kind || before.Address != made.Address;
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c,
                "UPDATE cameras SET name = $name, kind = $kind, address = $addr, zone_ref = $zone, classes = $cls, min_confidence = $conf, " +
                "enabled = CASE WHEN $moved = 1 THEN 0 ELSE enabled END, checked_at = CASE WHEN $moved = 1 THEN NULL ELSE checked_at END, check_status = CASE WHEN $moved = 1 THEN NULL ELSE check_status END, " +
                "check_note = CASE WHEN $moved = 1 THEN NULL ELSE check_note END, updated_at = $at, updated_by = $u WHERE tenant_id = $t AND site_id = $s AND id = $id", t,
                ("$name", made.Name), ("$kind", made.Kind), ("$addr", made.Address), ("$zone", made.ZoneRef), ("$cls", string.Join(",", made.Classes)), ("$conf", made.MinConfidencePercent),
                ("$moved", moved ? 1 : 0), ("$at", Iso.Text(clock.UtcNow)), ("$u", userId), ("$t", Tenant), ("$s", Site), ("$id", id));
            audit.Log(c, t, userId, "camera.update", "camera", id, made.Name + (moved && before.Enabled ? " (switched off: it moved)" : ""));
        });
        return Get(id);
    }

    /// <summary>
    /// The owner switches a camera on or off. Switching on needs the feature to be on and the camera to have been reached by the program (or to be one that cannot be checked from here); switching
    /// off is always possible. In this step a camera that is on is still not read: the switch records the owner's choice for the steps that follow.
    /// </summary>
    public Camera SetEnabled(long id, bool enabled, long? userId)
    {
        access.Require(Perm.Ai);
        var camera = Get(id);
        if (camera.Retired) throw new HubException("retired", "That camera was retired.");
        if (enabled)
        {
            RequireOn();
            if (camera.CheckStatus is not (CameraCheckStatus.Ok or CameraCheckStatus.NotCheckable))
                throw new HubException("not-checked", camera.CheckStatus == CameraCheckStatus.Failed ? "The program could not reach this camera, so it cannot be switched on. Fix the address and test it again." : "Test the camera first: it can be switched on once the program has reached it.");
        }

        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE cameras SET enabled = $e, updated_at = $at, updated_by = $u WHERE tenant_id = $t AND site_id = $s AND id = $id", t,
                ("$e", enabled ? 1 : 0), ("$at", Iso.Text(clock.UtcNow)), ("$u", userId), ("$t", Tenant), ("$s", Site), ("$id", id));
            audit.Log(c, t, userId, enabled ? "camera.enable" : "camera.disable", "camera", id, camera.Name);
        });
        return Get(id);
    }

    /// <summary>A camera that is not used any more. It is switched off, its password is deleted from the secret store and it leaves the list; the row stays so that the record of what it saw stays understandable.</summary>
    public void Retire(long id, long? userId)
    {
        access.Require(Perm.Ai);
        var camera = Get(id);
        if (camera.Retired) return;
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE cameras SET enabled = 0, retired_at = $at, updated_at = $at, updated_by = $u WHERE tenant_id = $t AND site_id = $s AND id = $id", t,
                ("$at", Iso.Text(clock.UtcNow)), ("$u", userId), ("$t", Tenant), ("$s", Site), ("$id", id));
            audit.Log(c, t, userId, "camera.retire", "camera", id, camera.Name);
        });
        TryDeleteSecret(id);
    }

    public IReadOnlyList<Camera> List(bool includeRetired = false)
    {
        access.Require(Perm.Ai);
        return db.Query(Select + (includeRetired ? "" : " AND retired_at IS NULL") + " ORDER BY id", Map, ("$t", Tenant), ("$s", Site));
    }

    public Camera Get(long id)
    {
        access.Require(Perm.Ai);
        return db.QueryOne(Select + " AND id = $id", Map, ("$t", Tenant), ("$s", Site), ("$id", id)) ?? throw new HubException("no-camera", "That camera was not found.");
    }

    // ---- the password -------------------------------------------------------------------------------------------------------------

    /// <summary>Keeps the camera's password in the computer's secret store. It is never written to the database, the audit trail or a message, and never shown again.</summary>
    public void SetPassword(long id, string? password, long? userId)
    {
        access.Require(Perm.Ai);
        var camera = Get(id);
        if (camera.Retired) throw new HubException("retired", "That camera was retired.");
        if (string.IsNullOrWhiteSpace(password)) throw new HubException("no-password", "Type the password.");
        var text = password.Trim();
        if (text.Length > MaxPasswordChars) throw new HubException("password-too-long", "That password is too long.");
        if (text.Any(char.IsControl)) throw new HubException("bad-password", "The password has characters that cannot be used.");
        secrets.Set(SecretName(id), text);
        audit.Log(userId, "camera.password", "camera", id, camera.Name);
    }

    public void ClearPassword(long id, long? userId)
    {
        access.Require(Perm.Ai);
        var camera = Get(id);
        TryDeleteSecret(id);
        audit.Log(userId, "camera.password-removed", "camera", id, camera.Name);
    }

    /// <summary>The program's own use, later: the password of a camera, for the part that will read its stream. Never shown to a person.</summary>
    internal string? PasswordFor(long id)
    {
        try { return secrets.Get(SecretName(id)); }
        catch (HubException) { return null; }
    }

    private static string SecretName(long id) => "camera/" + id.ToString(CultureInfo.InvariantCulture);

    private bool HasPassword(long id)
    {
        try { return secrets.Has(SecretName(id)); }
        catch (HubException) { return false; }   // a damaged safe means "no password"
    }

    private void TryDeleteSecret(long id)
    {
        try { secrets.Delete(SecretName(id)); }
        catch (HubException) { /* a damaged safe has nothing to delete */ }
    }

    // ---- "does it answer?" ----------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Asks whether the program can reach the camera, and writes the answer down. A network camera is only <i>connected to</i> and let go (nothing is sent and no picture is asked for); a file is only
    /// looked for; a camera plugged into this computer cannot be checked from here. It is the only thing that can make a camera switchable on.
    /// </summary>
    public async Task<CameraCheck> TestAsync(long id, long? userId, CancellationToken cancel = default)
    {
        access.Require(Perm.Ai);
        RequireOn();
        var camera = Get(id);
        if (camera.Retired) throw new HubException("retired", "That camera was retired.");
        var answer = camera.Kind switch
        {
            CameraKind.Rtsp or CameraKind.Onvif => await ReachAsync(camera, cancel),
            CameraKind.File => LookForFile(camera.Address),
            _ => new CameraCheck(CameraCheckStatus.NotCheckable, "A camera plugged into this computer cannot be checked from here. It is checked when it is first used."),
        };
        db.InTransaction((c, t) =>
        {
            HubDb.Exec(c, "UPDATE cameras SET checked_at = $at, check_status = $st, check_note = $note, updated_at = $at WHERE tenant_id = $t AND site_id = $s AND id = $id", t,
                ("$at", Iso.Text(clock.UtcNow)), ("$st", answer.Status), ("$note", answer.Note), ("$t", Tenant), ("$s", Site), ("$id", id));
            audit.Log(c, t, userId, "camera.test", "camera", id, camera.Name + ": " + CameraCheckStatus.Label(answer.Status));
        });
        return answer;
    }

    private static async Task<CameraCheck> ReachAsync(Camera camera, CancellationToken cancel)
    {
        var (host, port) = HostAndPort(camera.Kind, camera.Address);
        using var limit = CancellationTokenSource.CreateLinkedTokenSource(cancel);
        limit.CancelAfter(CheckTimeout);
        try
        {
            using var client = new TcpClient();
            await client.ConnectAsync(host, port, limit.Token);
            // A name can point anywhere: what it really connected to must also be on the shop's own network.
            var reached = (client.Client.RemoteEndPoint as IPEndPoint)?.Address;
            if (reached is null || EndpointClassifier.Classify(reached) is not (EndpointClassifier.Loopback or EndpointClassifier.PrivateNetwork))
                return new CameraCheck(CameraCheckStatus.Failed, "The address leads outside the shop's own network, so it is not used. Cameras must be on the shop's network.");
            return new CameraCheck(CameraCheckStatus.Ok, "The camera answered at " + host + ":" + port.ToString(CultureInfo.InvariantCulture) + ". No picture was read.");
        }
        catch (OperationCanceledException) when (!cancel.IsCancellationRequested)
        {
            return new CameraCheck(CameraCheckStatus.Failed, "The camera did not answer within " + (int)CheckTimeout.TotalSeconds + " seconds. Check that it is switched on and that the address is right.");
        }
        catch (SocketException)
        {
            return new CameraCheck(CameraCheckStatus.Failed, "The camera could not be reached at " + host + ":" + port.ToString(CultureInfo.InvariantCulture) + ". Check that it is switched on, on the shop's network, and that the address is right.");
        }
    }

    private static CameraCheck LookForFile(string path)
    {
        try
        {
            var file = new FileInfo(path);
            return file.Exists
                ? new CameraCheck(CameraCheckStatus.Ok, "The file is there (" + (file.Length / 1024 + 1).ToString(CultureInfo.InvariantCulture) + " KB). No picture was read.")
                : new CameraCheck(CameraCheckStatus.Failed, "There is no file at that place on this computer.");
        }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException or NotSupportedException or ArgumentException)
        {
            return new CameraCheck(CameraCheckStatus.Failed, "That file cannot be opened from here.");
        }
    }

    // ---- what is allowed ----------------------------------------------------------------------------------------------------------

    private sealed record Made(string Name, string Kind, string Address, string? ZoneRef, IReadOnlyList<string> Classes, int MinConfidencePercent);

    private static Made Check(CameraInput? input)
    {
        if (input is null) throw new HubException("bad-camera", "Fill in the camera.");
        var name = Regex.Replace((input.Name ?? "").Trim(), @"\s+", " ");
        if (name.Length == 0) throw new HubException("bad-name", "Give the camera a name.");
        if (name.Length > MaxNameChars) throw new HubException("bad-name", "The name is too long (at most " + MaxNameChars + " letters).");
        if (name.Any(char.IsControl)) throw new HubException("bad-name", "The name has characters that cannot be used.");
        if (!CameraKind.IsKnown(input.Kind)) throw new HubException("bad-kind", "Choose how the camera is reached.");

        var zone = string.IsNullOrWhiteSpace(input.ZoneRef) ? null : input.ZoneRef.Trim();
        if (zone is not null && !Regex.IsMatch(zone, @"^zone:[a-z0-9][a-z0-9._-]{0,60}$", RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(250)))
            throw new HubException("bad-place", "The place must be written like zone:aisle-3 (the short name of an area on the business map).");

        var asked = (input.Classes ?? []).Select(c => (c ?? "").Trim()).Where(c => c.Length > 0).Distinct().ToList();
        if (asked.Count == 0) throw new HubException("bad-classes", "Choose at least one thing the camera may look for.");
        var unknown = asked.FirstOrDefault(c => !CameraClass.IsKnown(c));
        if (unknown is not null) throw new HubException("bad-classes", "'" + Clip(unknown, 30) + "' is not something a camera can be asked to look for. The program only counts people, trolleys, baskets and products, and never recognises anyone.");
        var classes = CameraClass.All.Where(asked.Contains).ToList();

        if (input.MinConfidencePercent < LowestMinConfidence || input.MinConfidencePercent > HighestMinConfidence)
            throw new HubException("bad-confidence", "How sure the program must be is a percentage from " + LowestMinConfidence + " to " + HighestMinConfidence + ".");

        return new Made(name, input.Kind, Address(input.Kind, input.Address), zone, classes, input.MinConfidencePercent);
    }

    /// <summary>Checks an address for its kind and writes it the one way the program keeps it. Throws a plain refusal.</summary>
    internal static string Address(string kind, string? written)
    {
        var text = (written ?? "").Trim();
        if (text.Length == 0) throw new HubException("bad-address", "Write where the camera is.");
        if (text.Length > MaxAddressChars) throw new HubException("bad-address", "The address is too long (at most " + MaxAddressChars + " letters).");
        if (text.Any(char.IsControl)) throw new HubException("bad-address", "The address has characters that cannot be used.");
        switch (kind)
        {
            case CameraKind.Rtsp:
            {
                if (!Uri.TryCreate(text, UriKind.Absolute, out var uri) || uri.Scheme is not ("rtsp" or "rtsps") || string.IsNullOrEmpty(uri.Host))
                    throw new HubException("bad-address", "Write it like rtsp://192.168.1.50:554/stream1.");
                NoPasswordInAddress(uri);
                OnTheShopNetwork(uri.Host);
                return text;
            }

            case CameraKind.Onvif:
            {
                var full = text.Contains("://", StringComparison.Ordinal) ? text : "http://" + text + (text.Contains('/') ? "" : "/onvif/device_service");
                if (!Uri.TryCreate(full, UriKind.Absolute, out var uri) || uri.Scheme is not ("http" or "https") || string.IsNullOrEmpty(uri.Host))
                    throw new HubException("bad-address", "Write it like 192.168.1.50 or http://192.168.1.50/onvif/device_service.");
                NoPasswordInAddress(uri);
                OnTheShopNetwork(uri.Host);
                return full;
            }

            case CameraKind.Usb:
                if (text.Length > 80 || !Regex.IsMatch(text, @"^[\p{L}\p{N} ._:()/\-]+$", RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(250)) || text.Contains("..", StringComparison.Ordinal))
                    throw new HubException("bad-address", "Write the name the computer gives the camera, in letters and numbers (at most 80).");
                return text;

            case CameraKind.File:
                if (text.StartsWith("\\\\", StringComparison.Ordinal) || text.StartsWith("//", StringComparison.Ordinal)) throw new HubException("bad-address", "A file on another computer cannot be used: put it on this computer.");
                if (text.Split('/', '\\').Contains("..")) throw new HubException("bad-address", "Write the whole place of the file, without '..'.");
                if (!PictureFiles.Contains(Path.GetExtension(text).ToLowerInvariant())) throw new HubException("bad-address", "That kind of file cannot be used. It must be a video or picture file (" + string.Join(", ", PictureFiles) + ").");
                return text;

            default:
                throw new HubException("bad-kind", "Choose how the camera is reached.");
        }
    }

    private static void NoPasswordInAddress(Uri uri)
    {
        if (!string.IsNullOrEmpty(uri.UserInfo))
            throw new HubException("password-in-address", "Do not put a user name or password in the address. Type the password in its own box after the camera is added; it is kept in a safe place.");
    }

    private static void OnTheShopNetwork(string host)
    {
        if (EndpointClassifier.Classify("http://" + host) is not (EndpointClassifier.Loopback or EndpointClassifier.PrivateNetwork))
            throw new HubException("outside-network", "A camera must be on this computer or on the shop's own network. An address on the internet is not used: pictures stay in the shop.");
    }

    private static (string Host, int Port) HostAndPort(string kind, string address)
    {
        var uri = new Uri(address, UriKind.Absolute);
        var port = uri.IsDefaultPort ? (kind == CameraKind.Rtsp ? 554 : uri.Scheme == "https" ? 443 : 80) : uri.Port;
        return (uri.Host.Trim('[', ']'), port);
    }

    private static string Slug(string name)
    {
        var slug = new string(name.ToLowerInvariant().Select(c => char.IsAsciiLetterOrDigit(c) ? c : '-').ToArray()).Trim('-');
        while (slug.Contains("--", StringComparison.Ordinal)) slug = slug.Replace("--", "-", StringComparison.Ordinal);
        if (slug.Length == 0) slug = "camera";
        return slug.Length > 30 ? slug[..30].TrimEnd('-') : slug;
    }

    private static string Clip(string text, int chars) => text.Length <= chars ? text : text[..chars] + "…";

    // ---- reading ------------------------------------------------------------------------------------------------------------------

    private const string Select =
        "SELECT id, ref, name, kind, address, zone_ref, classes, min_confidence, enabled, checked_at, check_status, check_note, created_at, updated_at, retired_at FROM cameras WHERE tenant_id = $t AND site_id = $s";

    private Camera Map(Microsoft.Data.Sqlite.SqliteDataReader r) => new(r.Int("id"), r.Text("ref"), r.Text("name"), r.Text("kind"), r.Text("address"), r.TextOrNull("zone_ref"),
        r.Text("classes").Split(',', StringSplitOptions.RemoveEmptyEntries), (int)r.Int("min_confidence"), r.Flag("enabled"), HasPassword(r.Int("id")), r.TimeOrNull("checked_at"), r.TextOrNull("check_status"),
        r.TextOrNull("check_note"), r.Time("created_at"), r.Time("updated_at"), r.TimeOrNull("retired_at"));
}
