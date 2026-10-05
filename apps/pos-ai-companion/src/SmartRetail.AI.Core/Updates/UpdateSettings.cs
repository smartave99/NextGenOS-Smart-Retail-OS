using System;
using System.Text.RegularExpressions;

namespace SmartRetail.AI.Updates
{
    /// <summary>
    /// Where a copy of the app looks for updates and whose statement it trusts. Both are fixed when the app is built
    /// (build.ps1 -UpdateFeed …, which the release workflow gives its own repository's ids), never read from a setting
    /// or a file on the PC that something else could change: a copy built without them never checks.
    /// </summary>
    public sealed class UpdateSettings
    {
        private static readonly Regex Digits = new Regex(@"^\d{1,20}$", RegexOptions.CultureInvariant);

        private static readonly Regex BranchRef = new Regex(@"^refs/heads/[A-Za-z0-9._/-]{1,100}$", RegexOptions.CultureInvariant);

        private static readonly Regex WorkflowFile = new Regex(@"^\.github/workflows/[A-Za-z0-9._-]{1,100}\.ya?ml$", RegexOptions.CultureInvariant);

        public UpdateSettings(Uri feed, ReleaseSource source)
        {
            Feed = feed ?? throw new ArgumentNullException(nameof(feed));
            Source = source ?? throw new ArgumentNullException(nameof(source));
        }

        /// <summary>The public online folder that holds latest.json and the setup (https, ending in /).</summary>
        public Uri Feed { get; }

        /// <summary>The release workflow whose statement is accepted.</summary>
        public ReleaseSource Source { get; }

        /// <summary>The names the build keeps in the app (AssemblyMetadata).</summary>
        public const string FeedKey = "UpdateFeed";

        public const string RepositoryIdKey = "ReleaseRepositoryId";

        public const string OwnerIdKey = "ReleaseOwnerId";

        public const string RefKey = "ReleaseRef";

        public const string WorkflowKey = "ReleaseWorkflow";

        /// <summary>
        /// The settings from what the build kept in the app, or null when this copy does not check for updates: no folder,
        /// or anything about it or the release workflow missing or not in the form GitHub uses.
        /// </summary>
        public static UpdateSettings From(Func<string, string> metadata)
        {
            if (metadata == null)
            {
                return null;
            }

            var feed = Get(metadata, FeedKey);
            var repository = Get(metadata, RepositoryIdKey);
            var owner = Get(metadata, OwnerIdKey);
            var branch = Get(metadata, RefKey);
            var workflow = Get(metadata, WorkflowKey);
            if (!Uri.TryCreate(feed, UriKind.Absolute, out var folder) || !UpdateChecker.IsUsable(folder)
                || !Digits.IsMatch(repository) || !Digits.IsMatch(owner)
                || !BranchRef.IsMatch(branch) || !WorkflowFile.IsMatch(workflow))
            {
                return null;
            }

            return new UpdateSettings(folder, new ReleaseSource(repository, owner, branch, workflow));
        }

        private static string Get(Func<string, string> metadata, string key) => (metadata(key) ?? "").Trim();
    }
}
