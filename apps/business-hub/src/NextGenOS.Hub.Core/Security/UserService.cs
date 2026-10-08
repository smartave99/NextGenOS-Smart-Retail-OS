using System.Security.Cryptography;
using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Data;

namespace NextGenOS.Hub.Security;

public sealed record User(long Id, string Username, string DisplayName, string Role, bool Active);

internal sealed record LoginRow(User User, string Hash, int Failed, DateTimeOffset? Locked);

/// <summary>People who sign in. Passwords are never stored: only a salted, deliberately slow hash (PBKDF2-SHA256). Repeated wrong passwords lock the account for a while.</summary>
public sealed class UserService(HubDb db, IClock clock, AuditService audit, Access access)
{
    private const int Iterations = 600_000;
    private const int MaxFailures = 5;
    private static readonly TimeSpan LockFor = TimeSpan.FromMinutes(15);

    private static User Map(SqliteDataReader r) => new(r.Int("id"), r.Text("username"), r.Text("display_name"), r.Text("role"), r.Flag("active"));

    public bool Any() => Convert.ToInt64(db.Scalar("SELECT COUNT(*) FROM users") ?? 0L) > 0;

    public User Create(string username, string displayName, string role, string password, long? byUser = null)
    {
        access.Require(Perm.Users);
        if (string.IsNullOrWhiteSpace(username) || username.Trim().Length < 3) throw new HubException("username", "A user name needs at least 3 characters.");
        if (username.Any(char.IsWhiteSpace)) throw new HubException("username", "A user name cannot contain spaces.");
        if (string.IsNullOrWhiteSpace(displayName)) throw new HubException("name-missing", "Please give a name.");
        if (!Roles.All.Contains(role)) throw new HubException("role", "That is not a role.");
        CheckPassword(username, password);
        try
        {
            var id = db.InTransaction((c, t) => HubDb.Insert(c,
                "INSERT INTO users(username, display_name, role, password_hash, created_at) VALUES ($u, $n, $r, $h, $at)", t,
                ("$u", username.Trim()), ("$n", displayName.Trim()), ("$r", role), ("$h", Hash(password)), ("$at", Iso.Text(clock.UtcNow))));
            audit.Log(byUser, "user-created", "user", id, username.Trim() + " (" + role + ")");
            return Get(id)!;
        }
        catch (SqliteException ex) when (ex.SqliteErrorCode == 19)
        {
            throw new HubException("username-taken", "That user name is already used.");
        }
    }

    public User? Get(long id) => db.QueryOne("SELECT id, username, display_name, role, active FROM users WHERE id = $id", Map, ("$id", id));

    public IReadOnlyList<User> List() => db.Query("SELECT id, username, display_name, role, active FROM users ORDER BY active DESC, display_name COLLATE NOCASE", Map);

    /// <summary>Checks a user name and password. Always says the same thing for a wrong name and a wrong password.</summary>
    public User Authenticate(string username, string password)
    {
        const string failure = "The user name or the password is not right.";
        var row = db.QueryOne("SELECT id, username, display_name, role, active, password_hash, failed_logins, locked_until FROM users WHERE username = $u",
            r => new LoginRow(Map(r), r.Text("password_hash"), (int)r.Int("failed_logins"), r.TimeOrNull("locked_until")), ("$u", (username ?? "").Trim()));
        if (row is null)
        {
            Verify(password ?? "", DummyHash); // the same time is spent, so a wrong name cannot be told from a wrong password
            throw new HubException("login", failure);
        }
        if (row.Locked is { } until && until > clock.UtcNow)
            throw new HubException("locked", $"Too many wrong passwords. Try again in {Math.Max(1, (int)Math.Ceiling((until - clock.UtcNow).TotalMinutes))} minutes, or ask the owner.");
        if (!row.User.Active) throw new HubException("login", failure);
        if (!Verify(password ?? "", row.Hash))
        {
            var failed = row.Failed + 1;
            db.InTransaction((c, t) => HubDb.Exec(c, "UPDATE users SET failed_logins = $f, locked_until = $l WHERE id = $id", t,
                ("$f", failed >= MaxFailures ? 0 : failed), ("$l", failed >= MaxFailures ? Iso.Text(clock.UtcNow + LockFor) : null), ("$id", row.User.Id)));
            if (failed >= MaxFailures) audit.Log(row.User.Id, "login-locked", "user", row.User.Id);
            throw new HubException("login", failure);
        }
        db.InTransaction((c, t) => HubDb.Exec(c, "UPDATE users SET failed_logins = 0, locked_until = NULL WHERE id = $id", t, ("$id", row.User.Id)));
        return row.User;
    }

    public void ChangePassword(long userId, string newPassword, long? byUser)
    {
        if (access.CurrentUserId != userId) access.Require(Perm.Users);   // your own password, or the owner's word for someone else's
        var user = Get(userId) ?? throw new HubException("not-found", "That user was not found.");
        CheckPassword(user.Username, newPassword);
        db.InTransaction((c, t) => HubDb.Exec(c, "UPDATE users SET password_hash = $h, failed_logins = 0, locked_until = NULL WHERE id = $id", t, ("$h", Hash(newPassword)), ("$id", userId)));
        audit.Log(byUser, "password-changed", "user", userId);
    }

    public void SetActive(long userId, bool active, long? byUser)
    {
        access.Require(Perm.Users);
        var user = Get(userId) ?? throw new HubException("not-found", "That user was not found.");
        if (!active && user.Role == Roles.Owner && db.Query("SELECT id FROM users WHERE role = 'owner' AND active = 1 AND id <> $id", r => r.Int("id"), ("$id", userId)).Count == 0)
            throw new HubException("last-owner", "The last owner cannot be switched off.");
        db.InTransaction((c, t) => HubDb.Exec(c, "UPDATE users SET active = $a WHERE id = $id", t, ("$a", active ? 1 : 0), ("$id", userId)));
        audit.Log(byUser, active ? "user-on" : "user-off", "user", userId);
    }

    public void SetRole(long userId, string role, long? byUser)
    {
        access.Require(Perm.Users);
        if (!Roles.All.Contains(role)) throw new HubException("role", "That is not a role.");
        var user = Get(userId) ?? throw new HubException("not-found", "That user was not found.");
        if (user.Role == Roles.Owner && role != Roles.Owner && db.Query("SELECT id FROM users WHERE role = 'owner' AND active = 1 AND id <> $id", r => r.Int("id"), ("$id", userId)).Count == 0)
            throw new HubException("last-owner", "The last owner cannot be made something else.");
        db.InTransaction((c, t) => HubDb.Exec(c, "UPDATE users SET role = $r WHERE id = $id", t, ("$r", role), ("$id", userId)));
        audit.Log(byUser, "role-changed", "user", userId, role);
    }

    // ---- passwords ---------------------------------------------------------------------------------------------------------------

    private static readonly string DummyHash = Hash("not-a-real-password-for-timing");

    public static void CheckPassword(string username, string? password)
    {
        if (string.IsNullOrEmpty(password) || password.Length < 8) throw new HubException("password-short", "A password needs at least 8 characters.");
        if (password.Length > 200) throw new HubException("password-long", "That password is too long.");
        if (password.Equals(username, StringComparison.OrdinalIgnoreCase)) throw new HubException("password-same", "The password cannot be the same as the user name.");
        if (password.Distinct().Count() < 4) throw new HubException("password-weak", "That password is too easy to guess.");
        if (new[] { "password", "12345678", "123456789", "qwertyui", "11111111" }.Any(p => password.Equals(p, StringComparison.OrdinalIgnoreCase)))
            throw new HubException("password-weak", "That password is too easy to guess.");
    }

    public static string Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(16);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, 32);
        return $"pbkdf2-sha256${Iterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
    }

    public static bool Verify(string password, string stored)
    {
        var parts = stored.Split('$');
        if (parts.Length != 4 || parts[0] != "pbkdf2-sha256" || !int.TryParse(parts[1], out var iterations)) return false;
        var salt = Convert.FromBase64String(parts[2]);
        var expected = Convert.FromBase64String(parts[3]);
        var actual = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, expected.Length);
        return CryptographicOperations.FixedTimeEquals(actual, expected);
    }
}
