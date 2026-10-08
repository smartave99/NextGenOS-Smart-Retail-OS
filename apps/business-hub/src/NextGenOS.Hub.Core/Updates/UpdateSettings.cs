using System.Text.RegularExpressions;

namespace NextGenOS.Hub.Updates;

/// <summary>
/// Where a copy of the Hub looks for updates and whose statement it trusts. Both are fixed when the Hub is built (the release workflow gives its own repository's numbers), never read
/// from a setting or a file on the PC that something else could change: a copy built without them never looks.
/// </summary>
public sealed class UpdateSettings
{
    private static readonly Regex Digits = new(@"^\d{1,20}$", RegexOptions.CultureInvariant);
    private static readonly Regex WorkflowFile = new(@"^\.github/workflows/[A-Za-z0-9._-]{1,100}\.ya?ml$", RegexOptions.CultureInvariant);

    /// <summary>The names the build keeps in the program (assembly metadata).</summary>
    public const string FeedKey = "UpdateFeed";
    public const string RepositoryIdKey = "ReleaseRepositoryId";
    public const string OwnerIdKey = "ReleaseOwnerId";
    public const string WorkflowKey = "ReleaseWorkflow";

    public UpdateSettings(Uri feed, ReleaseSource source)
    {
        Feed = feed ?? throw new ArgumentNullException(nameof(feed));
        Source = source ?? throw new ArgumentNullException(nameof(source));
    }

    /// <summary>The public online folder that holds hub-latest.json and the setup (https, ending in /).</summary>
    public Uri Feed { get; }

    /// <summary>The release workflow whose statement is accepted.</summary>
    public ReleaseSource Source { get; }

    /// <summary>True for an https address ending in / (a folder), with no sign-in details, query or fragment.</summary>
    public static bool IsUsable(Uri? feed) =>
        feed is { IsAbsoluteUri: true } && feed.Scheme == Uri.UriSchemeHttps && feed.AbsolutePath.EndsWith('/') && feed.UserInfo.Length == 0 && feed.Query.Length == 0 && feed.Fragment.Length == 0;

    /// <summary>The settings from what the build kept in the program, or null when this copy does not look for updates: no folder, or anything about it or the release workflow missing or not in the form GitHub uses.</summary>
    public static UpdateSettings? From(Func<string, string?>? metadata)
    {
        if (metadata is null) return null;
        string Get(string key) => (metadata(key) ?? "").Trim();
        var feed = Get(FeedKey);
        var repository = Get(RepositoryIdKey);
        var owner = Get(OwnerIdKey);
        var workflow = Get(WorkflowKey);
        if (!Uri.TryCreate(feed, UriKind.Absolute, out var folder) || !IsUsable(folder) || !Digits.IsMatch(repository) || !Digits.IsMatch(owner) || !WorkflowFile.IsMatch(workflow)) return null;
        return new UpdateSettings(folder, new ReleaseSource(repository, owner, workflow));
    }
}
