using System.Reflection;
using System.Text.RegularExpressions;
using NextGenOS.Hub.Updates;

namespace NextGenOS.Hub.Web.Updates;

/// <summary>
/// Turns what the build kept in the program into the Hub's update options (blueprint REL-016). The online folder and the release workflow to trust are written into the program when it is
/// built (assembly metadata, from the release workflow's own numbers), never read from a setting or a file on the PC. A copy built without them, a copy not on Windows (the setup that
/// is kept is the Windows one) and the sample builds used for tests never look for updates.
/// </summary>
public static class UpdateHost
{
    private static readonly Lazy<HttpClient> Client = new(() => new HttpClient { Timeout = Timeout.InfiniteTimeSpan });   // the checker sets its own limits for each request
    private static readonly Regex LeadingVersion = new(@"^(\d{1,4})\.(\d{1,4})\.(\d{1,4})", RegexOptions.CultureInvariant);

    /// <summary>The options for the program that is running, or null when it does not look for updates.</summary>
    public static UpdateOptions? FromBuild(string dataFolder)
    {
        if (!OperatingSystem.IsWindows()) return null;
        var assembly = Assembly.GetEntryAssembly() ?? typeof(UpdateHost).Assembly;
        var metadata = assembly.GetCustomAttributes<AssemblyMetadataAttribute>().GroupBy(a => a.Key, StringComparer.Ordinal).ToDictionary(g => g.Key, g => g.Last().Value, StringComparer.Ordinal);
        var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? assembly.GetName().Version?.ToString();
        return Make(key => metadata.GetValueOrDefault(key), version, dataFolder);
    }

    /// <summary>The same from what was kept, as a plain function (so that it can be tried on any system): null unless the folder, the repository and the workflow are all there and well formed, and the running version is known.</summary>
    public static UpdateOptions? Make(Func<string, string?> metadata, string? runningVersion, string dataFolder)
    {
        var trust = UpdateSettings.From(metadata);
        if (trust is null) return null;
        var match = LeadingVersion.Match(runningVersion ?? "");
        if (!match.Success) return null;
        var current = new Version(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value));
        return new UpdateOptions(trust, Path.Combine(dataFolder, "updates"), current, () => Client.Value);
    }
}
