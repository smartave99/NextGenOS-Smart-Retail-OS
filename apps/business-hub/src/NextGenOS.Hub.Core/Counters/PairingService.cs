using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Data;

namespace NextGenOS.Hub.Counters;

/// <summary>A counter PC that was paired with this shop. The token that proves it is never kept here (only a hash of it is kept in the database).</summary>
public sealed record CounterPc(long Id, string Name, DateTimeOffset PairedAt, DateTimeOffset? LastSeenAt, string? LastAddress, DateTimeOffset? RemovedAt)
{
    public bool Active => RemovedAt is null;
}

/// <summary>A pairing code for the owner to read out once. It cannot be shown again: only a hash of it is kept.</summary>
public sealed record NewPairingCode(string Code, DateTimeOffset ExpiresAt);

/// <summary>A counter PC that has just been paired, with the token it must keep. The token is shown once (it goes into the counter PC's cookie) and is not kept in readable form.</summary>
public sealed record PairedCounter(CounterPc Counter, string Token);

/// <summary>A counter PC that was recognised on a request. <see cref="CookieIsOld"/> means it has not been seen for a day, so the cookie may be given a fresh life.</summary>
public sealed record RecognisedCounter(CounterPc Counter, bool CookieIsOld);

/// <summary>How many PCs the licence allows and how many are in use: the main PC and the counter PCs together.</summary>
public sealed record PcUse(int Counters, int? Limit)
{
    /// <summary>The main PC and its counter PCs.</summary>
    public int InUse => Counters + 1;

    public bool Full => Limit is > 0 && InUse >= Limit;
}

/// <summary>
/// Pairing a counter PC with this shop. The owner makes a short one-time code (a new one replaces the old; it works once, runs out after ten minutes, and only a salted hash of it is
/// kept). A counter PC types the code and a name and gets a long random token, of which only a hash is kept; the counter PC keeps the token in a cookie. Wrong codes are counted per
/// address and in all, and too many lock pairing for a while, so a code cannot be guessed. The licence's number of PCs is respected: the main PC and the counter PCs together may not
/// be more than <c>limits.devices</c> when the licence gives one. Everything that matters is written to the audit log, and a computer that keeps knocking cannot flood it.
/// </summary>
public sealed class PairingService
{
    private const string Tenant = "local";
    private const string Site = "main";
    private const string Alphabet = "ABCDEFGHJKMNPQRSTUVWXYZ23456789";   // no I, L, O, 0 or 1: nothing that can be misread
    public const int CodeLength = 8;
    public const int MaxNameLength = 40;
    public static readonly TimeSpan CodeLife = TimeSpan.FromMinutes(10);
    /// <summary>Wrong codes one address may try inside the window before it is locked.</summary>
    public const int WrongPerAddress = 5;
    /// <summary>Wrong tries against one code, from anywhere, before the code is cancelled.</summary>
    public const int WrongPerCode = 5;
    /// <summary>Wrong tries from all addresses together inside the window before pairing is locked for everybody.</summary>
    public const int WrongInAll = 20;
    public static readonly TimeSpan Window = TimeSpan.FromMinutes(10);

    private readonly HubDb _db;
    private readonly IClock _clock;
    private readonly AuditService _audit;
    private readonly Security.Access _access;
    private readonly Func<int> _deviceLimit;
    private readonly Func<bool> _accepting;
    private readonly AttemptLimiter _attempts;
    private readonly RefusalThrottle _refusals;

    /// <param name="deviceLimit">The number of PCs the licence allows; 0 or less means the licence gives no limit. Asked every time (a licence can change).</param>
    /// <param name="accepting">True while counter PCs are served at all.</param>
    public PairingService(HubDb db, IClock clock, AuditService audit, Security.Access access, Func<int> deviceLimit, Func<bool> accepting)
    {
        _db = db;
        _clock = clock;
        _audit = audit;
        _access = access;
        _deviceLimit = deviceLimit;
        _accepting = accepting;
        _attempts = new AttemptLimiter(clock, WrongPerAddress, WrongInAll, Window);
        _refusals = new RefusalThrottle(clock, TimeSpan.FromMinutes(10), 40);
    }

    /// <summary>Raised after a counter PC was removed (its number). The web program uses it to end that counter PC's open connections at once.</summary>
    public event Action<long>? CounterRemoved;

    // ---- the owner's side -------------------------------------------------------------------------------------------------------

    /// <summary>Makes a one-time pairing code. Refused when counter PCs are not switched on, or when the licence's PCs are all in use.</summary>
    public NewPairingCode NewCode(long? userId)
    {
        _access.Require(Security.Perm.Network);
        EnsureAccepting();
        var use = Use();
        if (use.Full) throw LimitReached(use.Limit!.Value);
        var code = Generate();
        var salt = RandomNumberGenerator.GetBytes(16);
        var now = _clock.UtcNow;
        var expires = now + CodeLife;
        _db.InTransaction((c, t) =>
        {
            // One live code at a time: a new one replaces the old.
            HubDb.Exec(c, "UPDATE network_pairing_codes SET cancelled_at = $now WHERE tenant_id = $t AND site_id = $s AND used_at IS NULL AND cancelled_at IS NULL", t, ("$now", Iso.Text(now)), ("$t", Tenant), ("$s", Site));
            var id = NextId(c, t, "network_pairing_codes");
            HubDb.Exec(c, "INSERT INTO network_pairing_codes(tenant_id, site_id, id, code_hash, salt, created_at, created_by, expires_at) VALUES ($t, $s, $id, $h, $salt, $at, $by, $exp)", t,
                ("$t", Tenant), ("$s", Site), ("$id", id), ("$h", HashCode(salt, code)), ("$salt", Convert.ToHexString(salt)), ("$at", Iso.Text(now)), ("$by", userId), ("$exp", Iso.Text(expires)));
            _audit.Log(c, t, userId, "network.code", "network_code", id, "A pairing code was made. It works once and runs out after 10 minutes.");
        });
        return new NewPairingCode(Format(code), expires);
    }

    /// <summary>When the code that is waiting runs out, or null when there is none (it was used, cancelled or ran out). The code itself is not kept in readable form and cannot be shown again.</summary>
    public DateTimeOffset? WaitingCodeRunsOutAt()
    {
        var text = _db.Scalar("SELECT MAX(expires_at) FROM network_pairing_codes WHERE tenant_id = $t AND site_id = $s AND used_at IS NULL AND cancelled_at IS NULL AND expires_at > $now",
            ("$t", Tenant), ("$s", Site), ("$now", Iso.Text(_clock.UtcNow))) as string;
        return text is null ? null : Iso.Parse(text);
    }

    /// <summary>The counter PCs paired and not removed, newest first.</summary>
    public IReadOnlyList<CounterPc> List() => _db.Query(Select + " AND revoked_at IS NULL ORDER BY paired_at DESC, id DESC", Map, ("$t", Tenant), ("$s", Site));

    /// <summary>The counter PCs that were removed, newest first (the history stays).</summary>
    public IReadOnlyList<CounterPc> Removed(int limit = 20) => _db.Query(Select + " AND revoked_at IS NOT NULL ORDER BY revoked_at DESC, id DESC LIMIT $n", Map, ("$t", Tenant), ("$s", Site), ("$n", limit));

    public CounterPc? Find(long id) => _db.QueryOne(Select + " AND id = $id", Map, ("$t", Tenant), ("$s", Site), ("$id", id));

    /// <summary>The PCs in use and the licence's limit.</summary>
    public PcUse Use()
    {
        var limit = _deviceLimit();
        return new PcUse(ActiveCount(), limit > 0 ? limit : null);
    }

    /// <summary>Removes a counter PC. Its token stops working with the very next request, and its open connections are ended.</summary>
    public void Remove(long id, long? userId)
    {
        _access.Require(Security.Perm.Network);
        var counter = Find(id) ?? throw new HubException("no-counter", "That counter PC was not found.");
        if (!counter.Active) return;
        var changed = _db.InTransaction((c, t) =>
        {
            var n = HubDb.Exec(c, "UPDATE network_devices SET revoked_at = $now, revoked_by = $by WHERE tenant_id = $t AND site_id = $s AND id = $id AND revoked_at IS NULL", t,
                ("$now", Iso.Text(_clock.UtcNow)), ("$by", userId), ("$t", Tenant), ("$s", Site), ("$id", id));
            if (n == 1) _audit.Log(c, t, userId, "network.revoke", "network_device", id, "The counter PC \"" + Plain(counter.Name, MaxNameLength) + "\" was removed.");
            return n;
        });
        if (changed == 1) Announce(id);
    }

    // ---- the counter PC's side --------------------------------------------------------------------------------------------------

    /// <summary>
    /// A counter PC gives the code it was told and a name for itself. Returns the token it must keep. Every refusal is a <see cref="HubException"/> with words for the person at the counter PC;
    /// a wrong code, an old code and a used code all say the same thing.
    /// </summary>
    public PairedCounter Redeem(string? code, string? name, string? address)
    {
        EnsureAccepting();
        var who = AddressKey(address);
        var now = _clock.UtcNow;
        if (_attempts.WaitFor(who) is { } wait)
        {
            Refused("network.pair-refused", who, "Pairing is locked for this address after too many wrong codes.");
            throw new HubException("pair-locked", $"Too many wrong codes were tried. Wait {Minutes(wait)}, then try again, or ask the owner for a new code.");
        }

        var cleanName = CleanName(name);   // a name that is not allowed is not a wrong code: nothing is counted, and the code is not used up
        var clean = Normalize(code);
        var live = _db.QueryOne("SELECT id, code_hash, salt FROM network_pairing_codes WHERE tenant_id = $t AND site_id = $s AND used_at IS NULL AND cancelled_at IS NULL AND expires_at > $now ORDER BY id DESC LIMIT 1",
            r => new LiveCode(r.Int("id"), r.Text("code_hash"), r.Text("salt")), ("$t", Tenant), ("$s", Site), ("$now", Iso.Text(now)));
        // The same work is done whether or not there is a code and whether or not it is right, so the time taken tells nothing.
        var salt = live is null ? new byte[16] : Convert.FromHexString(live.Salt);
        var expected = live?.Hash ?? new string('0', 64);
        var matched = CryptographicOperations.FixedTimeEquals(Encoding.ASCII.GetBytes(HashCode(salt, clean ?? new string('-', CodeLength))), Encoding.ASCII.GetBytes(expected)) && live is not null && clean is not null;
        if (!matched)
        {
            _attempts.Fail(who);
            Refused("network.pair-refused", who, "A wrong pairing code was tried.");
            if (live is not null) WrongAgainstCode(live.Id);
            throw new HubException("pair-wrong", "That code is not right, or it has run out. Check it, or ask the owner for a new one.");
        }

        var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32)).TrimEnd('=').Replace('+', '-').Replace('/', '_');
        var codeId = live!.Id;
        long id = 0;
        _db.InTransaction((c, t) =>
        {
            // Used exactly once, even if two counter PCs type it at the same moment: the one that changes the row wins.
            var used = HubDb.Exec(c, "UPDATE network_pairing_codes SET used_at = $now WHERE tenant_id = $t AND site_id = $s AND id = $id AND used_at IS NULL AND cancelled_at IS NULL AND expires_at > $now", t,
                ("$now", Iso.Text(now)), ("$t", Tenant), ("$s", Site), ("$id", codeId));
            if (used != 1) throw new HubException("pair-wrong", "That code is not right, or it has run out. Check it, or ask the owner for a new one.");
            var active = Convert.ToInt32(HubDb.Scalar(c, "SELECT COUNT(*) FROM network_devices WHERE tenant_id = $t AND site_id = $s AND revoked_at IS NULL", t, ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);
            var limit = _deviceLimit();
            if (limit > 0 && active + 1 >= limit) throw LimitReached(limit);   // rolls the whole step back: the code stays valid
            var taken = Convert.ToInt32(HubDb.Scalar(c, "SELECT COUNT(*) FROM network_devices WHERE tenant_id = $t AND site_id = $s AND revoked_at IS NULL AND name = $n COLLATE NOCASE", t, ("$t", Tenant), ("$s", Site), ("$n", cleanName)), CultureInfo.InvariantCulture);
            if (taken > 0) throw new HubException("pair-name-taken", "Another counter PC already has that name. Choose a different one.");
            id = NextId(c, t, "network_devices");
            HubDb.Exec(c, "INSERT INTO network_devices(tenant_id, site_id, id, name, token_hash, paired_at, paired_with_code, last_seen_at, last_address) VALUES ($t, $s, $id, $n, $h, $at, $code, $at, $a)", t,
                ("$t", Tenant), ("$s", Site), ("$id", id), ("$n", cleanName), ("$h", HashToken(token)), ("$at", Iso.Text(now)), ("$code", codeId), ("$a", address));
            HubDb.Exec(c, "UPDATE network_pairing_codes SET used_by_device = $d WHERE tenant_id = $t AND site_id = $s AND id = $id", t, ("$d", id), ("$t", Tenant), ("$s", Site), ("$id", codeId));
            _audit.Log(c, t, null, "network.pair", "network_device", id, "The counter PC \"" + cleanName + "\" was paired" + (address is null ? "." : " from " + Plain(address, 64) + "."));
        });
        _attempts.Forgive(who);
        return new PairedCounter(Find(id)!, id.ToString(CultureInfo.InvariantCulture) + "." + token);
    }

    /// <summary>
    /// Recognises a counter PC from the value of its cookie. Null for anything that is not a live token: no cookie, a cookie that is made up, a token that was never given, one that was
    /// removed. Looked at in the database on every call, so a removal takes effect with the very next request.
    /// </summary>
    public RecognisedCounter? Recognise(string? cookie, string? address)
    {
        if (!TryParse(cookie, out var id, out var secret)) return null;
        var row = _db.QueryOne("SELECT id, name, paired_at, last_seen_at, last_address, revoked_at, token_hash FROM network_devices WHERE tenant_id = $t AND site_id = $s AND id = $id AND revoked_at IS NULL",
            r => new TokenRow(Map(r), r.Text("token_hash")), ("$t", Tenant), ("$s", Site), ("$id", id));
        // A token that does not exist is hashed against a dummy so the time taken is the same.
        var ok = CryptographicOperations.FixedTimeEquals(Encoding.ASCII.GetBytes(HashToken(secret)), Encoding.ASCII.GetBytes(row?.Hash ?? new string('0', 64)));
        if (!ok || row is null) return null;
        var now = _clock.UtcNow;
        var old = row.Counter.LastSeenAt is null || row.Counter.LastSeenAt.Value + TimeSpan.FromDays(1) <= now;
        try
        {
            // "Last seen" is written at most once a minute for a counter PC (and when its address changes), so looking at the screen does not write to the database on every click.
            _db.InTransaction((c, t) => HubDb.Exec(c,
                "UPDATE network_devices SET last_seen_at = $now, last_address = $a WHERE tenant_id = $t AND site_id = $s AND id = $id AND (last_seen_at IS NULL OR last_seen_at <= $before OR COALESCE(last_address, '') <> COALESCE($a, ''))", t,
                ("$now", Iso.Text(now)), ("$a", address), ("$t", Tenant), ("$s", Site), ("$id", id), ("$before", Iso.Text(now - TimeSpan.FromMinutes(1)))));
        }
        catch (SqliteException)
        {
            // Not being able to note the time must never stop a counter PC that is allowed in.
        }

        return new RecognisedCounter(row.Counter, old);
    }

    /// <summary>
    /// Writes "this computer was turned away" to the audit log, at most once in a while for each address and at most so many an hour in all (the rest are only counted, and the next entry says how many).
    /// Never throws.
    /// </summary>
    public void NoteTurnedAway(string? address, string what) => Refused("network.refused", AddressKey(address), what);

    // ---- helpers ----------------------------------------------------------------------------------------------------------------

    private void EnsureAccepting()
    {
        if (!_accepting())
            throw new HubException("network-off", "Counter PCs cannot connect to this shop PC right now. The owner has to switch on \"Let counter PCs connect\" in Settings and restart the Hub.");
    }

    private int ActiveCount() => Convert.ToInt32(_db.Scalar("SELECT COUNT(*) FROM network_devices WHERE tenant_id = $t AND site_id = $s AND revoked_at IS NULL", ("$t", Tenant), ("$s", Site)) ?? 0L, CultureInfo.InvariantCulture);

    private static HubException LimitReached(int limit)
    {
        var message = limit == 1
            ? "This licence is for 1 PC, and the main PC uses it, so no counter PC can be added. Ask your supplier for a licence with more PCs."
            : $"This licence is for {limit} PCs: the main PC and {limit - 1} counter {(limit - 1 == 1 ? "PC" : "PCs")}. All {limit} are in use. Remove a counter PC you no longer use, or ask your supplier for a licence with more PCs.";
        return new HubException("device-limit", message);
    }

    private void WrongAgainstCode(long codeId)
    {
        try
        {
            _db.InTransaction((c, t) =>
            {
                HubDb.Exec(c, "UPDATE network_pairing_codes SET wrong_attempts = wrong_attempts + 1 WHERE tenant_id = $t AND site_id = $s AND id = $id", t, ("$t", Tenant), ("$s", Site), ("$id", codeId));
                var n = HubDb.Exec(c, "UPDATE network_pairing_codes SET cancelled_at = $now WHERE tenant_id = $t AND site_id = $s AND id = $id AND wrong_attempts >= $max AND used_at IS NULL AND cancelled_at IS NULL", t,
                    ("$now", Iso.Text(_clock.UtcNow)), ("$t", Tenant), ("$s", Site), ("$id", codeId), ("$max", WrongPerCode));
                if (n == 1) _audit.Log(c, t, null, "network.code-cancelled", "network_code", codeId, "The pairing code was cancelled after " + WrongPerCode + " wrong tries. The owner has to make a new one.");
            });
        }
        catch (SqliteException)
        {
            // The count is a safeguard; failing to write it must not break the answer.
        }
    }

    private void Refused(string action, string address, string what)
    {
        try
        {
            if (!_refusals.May(address, out var skipped)) return;
            var more = skipped > 0 ? $" ({skipped} more tries since the last note)" : "";
            _audit.Log(null, action, "network_address", null, Plain(address, 64) + ": " + Plain(what, 120) + more);
        }
        catch (SqliteException)
        {
            // The audit log is a record, not a gate: a busy database must not turn a refusal into an error.
        }
    }

    private static string AddressKey(string? address) => string.IsNullOrWhiteSpace(address) ? "unknown" : Plain(address, 64);

    /// <summary>Text from outside, made safe for the audit log: no control characters, cut to length.</summary>
    internal static string Plain(string? text, int max)
    {
        var clean = new string((text ?? "").Where(ch => !char.IsControl(ch)).ToArray()).Trim();
        return clean.Length <= max ? clean : clean[..max];
    }

    /// <summary>A computer's name from a form: trimmed, 1 to 40 characters, no control characters.</summary>
    private static string CleanName(string? name)
    {
        var clean = Plain(name, 400);
        if (clean.Length == 0) throw new HubException("pair-name", "Give this computer a name, for example Counter 2.");
        if (clean.Length > MaxNameLength) throw new HubException("pair-name", $"Use a shorter name: at most {MaxNameLength} characters.");
        return clean;
    }

    private static string Generate()
    {
        var chars = new char[CodeLength];
        for (var i = 0; i < chars.Length; i++) chars[i] = Alphabet[RandomNumberGenerator.GetInt32(Alphabet.Length)];
        return new string(chars);
    }

    /// <summary>The code as people read it: <c>ABCD-EFGH</c>.</summary>
    public static string Format(string code) => code.Length == CodeLength ? code[..4] + "-" + code[4..] : code;

    /// <summary>What a person typed, as the code it stands for (capitals, no spaces or hyphens), or null when it cannot be a code.</summary>
    public static string? Normalize(string? typed)
    {
        if (typed is null || typed.Length > 40) return null;
        var clean = new string(typed.Where(ch => ch is not (' ' or '-' or '\t')).Select(char.ToUpperInvariant).ToArray());
        return clean.Length == CodeLength && clean.All(ch => Alphabet.Contains(ch, StringComparison.Ordinal)) ? clean : null;
    }

    private static string HashCode(byte[] salt, string code)
    {
        var bytes = new byte[salt.Length + code.Length];
        salt.CopyTo(bytes, 0);
        Encoding.ASCII.GetBytes(code, 0, code.Length, bytes, salt.Length);
        return Convert.ToHexString(SHA256.HashData(bytes));
    }

    private static string HashToken(string secret) => Convert.ToHexString(SHA256.HashData(Encoding.ASCII.GetBytes(secret)));

    /// <summary>A cookie value is <c>number.secret</c>, the secret being 43 characters of URL-safe letters; anything else is refused before the database is asked.</summary>
    public static bool TryParse(string? cookie, out long id, out string secret)
    {
        id = 0;
        secret = "";
        if (string.IsNullOrEmpty(cookie) || cookie.Length > 80) return false;
        var dot = cookie.IndexOf('.');
        if (dot < 1 || dot > 12 || !long.TryParse(cookie.AsSpan(0, dot), NumberStyles.None, CultureInfo.InvariantCulture, out id) || id < 1) return false;
        secret = cookie[(dot + 1)..];
        return secret.Length == 43 && secret.All(ch => char.IsAsciiLetterOrDigit(ch) || ch is '-' or '_');
    }

    private static long NextId(SqliteConnection c, SqliteTransaction t, string table) =>
        Convert.ToInt64(HubDb.Scalar(c, "SELECT COALESCE(MAX(id), 0) + 1 FROM " + table + " WHERE tenant_id = $t AND site_id = $s", t, ("$t", Tenant), ("$s", Site)), CultureInfo.InvariantCulture);

    private static string Minutes(TimeSpan wait)
    {
        var minutes = Math.Max(1, (int)Math.Ceiling(wait.TotalMinutes));
        return minutes == 1 ? "a minute" : minutes + " minutes";
    }

    private void Announce(long id)
    {
        try { CounterRemoved?.Invoke(id); }
        catch (Exception ex) when (ex is InvalidOperationException or ObjectDisposedException) { }
    }

    private sealed record LiveCode(long Id, string Hash, string Salt);

    private sealed record TokenRow(CounterPc Counter, string Hash);

    private const string Select = "SELECT id, name, paired_at, last_seen_at, last_address, revoked_at FROM network_devices WHERE tenant_id = $t AND site_id = $s";

    private static CounterPc Map(SqliteDataReader r) => new(r.Int("id"), r.Text("name"), r.Time("paired_at"), r.TimeOrNull("last_seen_at"), r.TextOrNull("last_address"), r.TimeOrNull("revoked_at"));
}
