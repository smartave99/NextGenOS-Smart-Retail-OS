using NextGenOS.Hub.Data;

namespace NextGenOS.Hub.Security;

/// <summary>Who is doing a command: a signed-in person, or the program itself (its own tidying, the sample company, the tests).</summary>
public sealed record Actor(long? UserId, string Role, string Name, bool IsSystem = false)
{
    public static readonly Actor System = new(null, "system", "the program", true);

    /// <summary>True for the program itself, or for a person whose role allows at least one of these.</summary>
    public bool CanAny(IEnumerable<string> permissions) => IsSystem || permissions.Any(p => Roles.Can(Role, p));
}

/// <summary>
/// The check that stands in front of every command that changes money, stock, people or settings (blueprint SEC-004, invariant 6): nobody gets round it by calling a service directly,
/// skipping a page or replaying an old approval. A screen hides what a person may not do, but that is a courtesy; this is the lock.
/// <para>
/// <b>How it works.</b> The place where a request enters (a screen's event, a device's request, one day an assistant's tool) opens a scope with <see cref="As"/> naming the signed-in
/// person. A command then asks <see cref="Require"/> for the permission it needs. The person is looked up <i>again</i> at every command, so a person who was switched off, or given another
/// role, loses their rights at once, even in the middle of a session. A refusal is written to the audit log.
/// </para>
/// <para>
/// <b>No scope means refused</b> (the shop opened the normal way): a new entry point that forgets to say who is asking fails closed instead of working for everybody. The only ways round it
/// are written in the open: <see cref="AsSystem"/> for the program's own work (it is searched for in the tests so that it never appears in a screen or an endpoint), the shop that has no users
/// yet (the first-run set-up, for settings and users only), and a shop opened for tests or for filling the sample company (<c>HubApp.OpenTrusted</c>, which the program cannot reach).
/// </para>
/// </summary>
public sealed class Access
{
    // One per shop (not shared by every shop opened in the same program): the sample company is filled by its own shop object while a person is signed in, and must not be judged as that person.
    private readonly AsyncLocal<Frame?> Current = new();

    /// <summary>Who is acting. For a person it is asked each time (a screen learns who is signed in a moment after it starts), so a scope can be opened before the person is known.</summary>
    private sealed record Frame(Func<long?>? Who, bool System);

    private sealed class Pop(AsyncLocal<Frame?> slot, Frame? before) : IDisposable
    {
        public void Dispose() => slot.Value = before;
    }

    private readonly HubDb db;
    private readonly AuditService audit;
    private readonly bool trusted;

    internal Access(HubDb db, AuditService audit, bool trusted)
    {
        this.db = db;
        this.audit = audit;
        this.trusted = trusted;
    }

    private IDisposable Push(Frame frame)
    {
        var before = Current.Value;
        Current.Value = frame;
        return new Pop(Current, before);
    }

    /// <summary>Everything done until the returned scope is disposed is done on behalf of this signed-in person. A null id is a scope with nobody in it (commands are refused).</summary>
    public IDisposable As(long? userId) => Push(new Frame(() => userId, false));

    /// <summary>The same, when the person is learned a moment later (a screen opens its scope first and finds out who is signed in as it starts). Asked at every command.</summary>
    public IDisposable As(Func<long?> who) => Push(new Frame(who, false));

    /// <summary>The program's own work. Never used by a screen or an endpoint (a test searches for it).</summary>
    public IDisposable AsSystem() => Push(new Frame(null, true));

    /// <summary>For the tests: the rest of this test is done as the program itself. Not reachable from the program.</summary>
    internal void EnterSystemForTests() => Current.Value = new Frame(null, true);

    /// <summary>The person doing the current command, as the scope says (null: nobody, or the program itself).</summary>
    public long? CurrentUserId => Current.Value is { System: false } f ? f.Who?.Invoke() : null;

    /// <summary>Allowed to do this? Throws a plain <see cref="HubException"/> (<c>not-signed-in</c> or <c>forbidden</c>) when not.</summary>
    public Actor Require(string permission) => RequireAny(permission);

    /// <summary>
    /// Who is asking, for a read that shows different things to different people (the business map, one day an assistant's questions). The person is looked up again each time, so a person
    /// who was switched off, or given another role, is judged as they are now. Nobody named in the normal shop is refused (<c>not-signed-in</c>), like a command; the program itself, and a
    /// shop opened for tests, are the program.
    /// </summary>
    public Actor Who()
    {
        var frame = Current.Value;
        if (frame is { System: true }) return Actor.System;
        if (frame?.Who?.Invoke() is { } id)
        {
            var user = db.Query("SELECT display_name, role, active FROM users WHERE id = $id", r => (Name: r.Text("display_name"), Role: r.Text("role"), Active: r.Flag("active")), ("$id", id)).FirstOrDefault();
            if (user.Name is null || !user.Active) throw new HubException("not-signed-in", "Please sign in again.");
            return new Actor(id, user.Role, user.Name);
        }

        if (trusted) return Actor.System;
        throw new HubException("not-signed-in", "Please sign in first.");
    }

    /// <summary>Allowed when the person may do at least one of these.</summary>
    public Actor RequireAny(params string[] permissions)
    {
        var frame = Current.Value;
        if (frame is { System: true }) return Actor.System;
        if (frame?.Who?.Invoke() is { } id)
        {
            var user = db.Query("SELECT display_name, role, active FROM users WHERE id = $id", r => (Name: r.Text("display_name"), Role: r.Text("role"), Active: r.Flag("active")), ("$id", id)).FirstOrDefault();
            if (user.Name is null || !user.Active) throw new HubException("not-signed-in", "Please sign in again.");
            if (permissions.Any(p => Roles.Can(user.Role, p))) return new Actor(id, user.Role, user.Name);
            audit.Log(id, "access-denied", "permission", null, string.Join("|", permissions));
            throw new HubException("forbidden", "You are not allowed to do that. Ask the owner or a manager.");
        }

        if (trusted) return Actor.System;
        // The first-run set-up: until the shop has a person who can sign in, the set-up page makes the settings and the owner (and nothing else).
        if (permissions.Any(p => p is Perm.Settings or Perm.Users) && !AnyUsers()) return Actor.System;
        throw new HubException("not-signed-in", "Please sign in first.");
    }

    /// <summary>True when the person in the current scope may do this (no refusal, no audit line). Used to decide what a command may do for different people, never to skip <see cref="Require"/>.</summary>
    public bool Can(string permission)
    {
        var frame = Current.Value;
        if (frame is { System: true }) return true;
        if (frame?.Who?.Invoke() is { } id)
        {
            var user = db.Query("SELECT role, active FROM users WHERE id = $id", r => (Role: r.Text("role"), Active: r.Flag("active")), ("$id", id)).FirstOrDefault();
            return user.Role is not null && user.Active && Roles.Can(user.Role, permission);
        }

        return trusted;
    }

    private bool AnyUsers() => Convert.ToInt64(db.Scalar("SELECT COUNT(*) FROM users") ?? 0L) > 0;
}
