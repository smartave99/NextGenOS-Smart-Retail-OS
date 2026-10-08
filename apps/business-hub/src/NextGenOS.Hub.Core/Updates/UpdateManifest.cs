using System.Text.Json;
using System.Text.RegularExpressions;

namespace NextGenOS.Hub.Updates;

/// <summary>
/// A new version, as the release workflow publishes it beside its setup (hub-latest.json): the version, the setup's file name, size and SHA-256, and GitHub's signed statement that the
/// project's own release made it. A setup bigger than the online folder allows for one file is kept in pieces of <see cref="PartSize"/> bytes, which the Hub joins and checks as a whole.
/// The same shape as the AI add-on's update description (blueprint REL-016: reuse first), with the Hub's own names, so a statement made for the add-on can never pass for a Hub update.
/// </summary>
public sealed class UpdateManifest
{
    /// <summary>The description's name in the online folder (the add-on's is latest.json, beside it).</summary>
    public const string FeedFile = "hub-latest.json";

    /// <summary>The largest setup accepted; the Hub's is about 80 MB.</summary>
    public const long MaxSize = 500L * 1024 * 1024;

    public const long MinPartSize = 1024L * 1024;
    public const long MaxPartSize = 64L * 1024 * 1024;
    public const int MaxParts = 64;
    public const int MaxNotes = 300;

    private static readonly Regex Hex = new("^[0-9a-f]{64}$", RegexOptions.CultureInvariant);
    private static readonly Regex VersionText = new(@"^\d{1,4}\.\d{1,4}\.\d{1,4}$", RegexOptions.CultureInvariant);
    private static readonly JsonSerializerOptions Options = new() { PropertyNameCaseInsensitive = true };

    public string Version { get; set; } = "";

    /// <summary>Always "SmartRetailHub-Setup-{Version}.exe": the setup as it is run, whole.</summary>
    public string File { get; set; } = "";

    /// <summary>Lower-case hex, of the whole setup.</summary>
    public string Sha256 { get; set; } = "";

    public long Size { get; set; }

    /// <summary>0: the setup is one file. Otherwise the size of its pieces (the last one is what is left).</summary>
    public long PartSize { get; set; }

    public string Notes { get; set; } = "";

    /// <summary>GitHub's signed statement: see <see cref="ReleaseStatement"/>.</summary>
    public string Statement { get; set; } = "";

    public System.Version ParsedVersion => System.Version.Parse(Version);

    /// <summary>What GitHub signed for this setup: its version and SHA-256, and a word that only the Hub's updates carry.</summary>
    public string Audience => AudienceFor(Version, Sha256);

    public int PartCount => PartSize <= 0 ? 1 : (int)((Size + PartSize - 1) / PartSize);

    public static bool IsVersion(string? text) => VersionText.IsMatch(text ?? "");

    public static bool IsSha256(string? text) => Hex.IsMatch(text ?? "");

    public static string AudienceFor(string version, string sha256) => "smartretail-hub-update:" + version + ":" + sha256;

    public static string SetupFileName(string version) => "SmartRetailHub-Setup-" + version + ".exe";

    /// <summary>True for the name of any Hub setup the Hub itself keeps in its updates folder (and its pieces and half-finished downloads).</summary>
    public static bool IsKeptSetup(string fileName) => fileName.StartsWith("SmartRetailHub-Setup-", StringComparison.Ordinal);

    /// <summary>The online file name of piece <paramref name="number"/> (from 1): the setup's own name when it is one file.</summary>
    public string PartName(int number) => PartSize <= 0 ? File : File + "." + number.ToString("000", System.Globalization.CultureInfo.InvariantCulture);

    /// <summary>How many bytes piece <paramref name="number"/> (from 1) must have.</summary>
    public long PartLength(int number) => PartSize <= 0 ? Size : number < PartCount ? PartSize : Size - PartSize * (PartCount - 1);

    /// <summary>Reads hub-latest.json, refusing anything that is not exactly what the release workflow writes.</summary>
    public static UpdateManifest Parse(string json)
    {
        UpdateManifest? manifest;
        try { manifest = JsonSerializer.Deserialize<UpdateManifest>(json ?? "", Options); }
        catch (JsonException e) { throw new HubException("update", "The update's description could not be read: " + e.Message.Split('.')[0] + "."); }

        if (manifest is null
            || !VersionText.IsMatch(manifest.Version ?? "")
            || manifest.File != SetupFileName(manifest.Version!)
            || !Hex.IsMatch(manifest.Sha256 ?? "")
            || manifest.Size <= 0 || manifest.Size > MaxSize
            || string.IsNullOrWhiteSpace(manifest.Statement)
            || !PartsAreSensible(manifest))
            throw new HubException("update", "The update's description is not complete.");

        var notes = (manifest.Notes ?? "").Trim();
        manifest.Notes = notes.Length > MaxNotes ? notes[..MaxNotes] : notes;
        return manifest;
    }

    private static bool PartsAreSensible(UpdateManifest manifest) =>
        manifest.PartSize == 0
        || (manifest.PartSize >= MinPartSize && manifest.PartSize <= MaxPartSize && manifest.PartCount <= MaxParts);
}
