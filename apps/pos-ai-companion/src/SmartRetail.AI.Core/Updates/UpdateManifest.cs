using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace SmartRetail.AI.Updates
{
    /// <summary>Why an update could not be checked, downloaded or trusted, in words for the owner.</summary>
    public sealed class UpdateException : Exception
    {
        public UpdateException(string message, Exception inner = null)
            : base(message, inner)
        {
        }
    }

    /// <summary>
    /// A new version, as the release workflow publishes it beside its setup (latest.json): the version, the setup's
    /// file name, size and SHA-256, and GitHub's signed statement that the project's own release made it. A setup
    /// bigger than the online folder allows for one file (the free plan of Supabase: 50 MB) is kept in pieces of
    /// <see cref="PartSize"/> bytes, which the app joins and checks as a whole.
    /// </summary>
    public sealed class UpdateManifest
    {
        /// <summary>The largest setup accepted; it is about 60 MB.</summary>
        public const long MaxSize = 500L * 1024 * 1024;

        /// <summary>A setup in pieces: the smallest and the largest piece, and at most this many of them.</summary>
        public const long MinPartSize = 1024L * 1024;

        public const long MaxPartSize = 64L * 1024 * 1024;

        public const int MaxParts = 64;

        public const int MaxNotes = 300;

        private static readonly Regex Hex = new Regex("^[0-9a-f]{64}$", RegexOptions.CultureInvariant);

        private static readonly Regex VersionText = new Regex(@"^\d{1,4}\.\d{1,4}\.\d{1,4}$", RegexOptions.CultureInvariant);

        public string Version { get; set; } = "";

        /// <summary>Always "SmartRetailAI-Setup-{Version}.exe": the setup as it is run, whole.</summary>
        public string File { get; set; } = "";

        /// <summary>Lower-case hex, of the whole setup.</summary>
        public string Sha256 { get; set; } = "";

        /// <summary>The whole setup's size in bytes.</summary>
        public long Size { get; set; }

        /// <summary>0: the setup is one file. Otherwise the size of its pieces (the last one is what is left).</summary>
        public long PartSize { get; set; }

        public string Notes { get; set; } = "";

        /// <summary>GitHub's signed statement (an Actions OIDC token): see <see cref="GitHubStatement"/>.</summary>
        public string Statement { get; set; } = "";

        [JsonIgnore]
        public Version ParsedVersion => System.Version.Parse(Version);

        /// <summary>What GitHub signed for this setup: its version and SHA-256.</summary>
        [JsonIgnore]
        public string Audience => AudienceFor(Version, Sha256);

        /// <summary>How many files the setup is kept in online.</summary>
        [JsonIgnore]
        public int PartCount => PartSize <= 0 ? 1 : (int)((Size + PartSize - 1) / PartSize);

        /// <summary>True for a version written as the release workflow writes it: three numbers, e.g. 2.9.0.</summary>
        public static bool IsVersion(string text) => VersionText.IsMatch(text ?? "");

        /// <summary>True for a SHA-256 written as the release workflow writes it: 64 lower-case hex digits.</summary>
        public static bool IsSha256(string text) => Hex.IsMatch(text ?? "");

        public static string AudienceFor(string version, string sha256) => "smartretail-update:" + version + ":" + sha256;

        public static string SetupFileName(string version) => "SmartRetailAI-Setup-" + version + ".exe";

        /// <summary>The online file name of piece <paramref name="number"/> (from 1): the setup's own name when it is one file.</summary>
        public string PartName(int number) => PartSize <= 0 ? File : File + "." + number.ToString("000", CultureInfo.InvariantCulture);

        /// <summary>How many bytes piece <paramref name="number"/> (from 1) must have.</summary>
        public long PartLength(int number) => PartSize <= 0 ? Size : number < PartCount ? PartSize : Size - PartSize * (PartCount - 1);

        /// <summary>Reads latest.json, refusing anything that is not exactly what the release workflow writes.</summary>
        public static UpdateManifest Parse(string json)
        {
            UpdateManifest manifest;
            try
            {
                manifest = JsonConvert.DeserializeObject<UpdateManifest>(json ?? "");
            }
            catch (JsonException ex)
            {
                throw new UpdateException("The update's description could not be read.", ex);
            }

            if (manifest == null
                || !VersionText.IsMatch(manifest.Version ?? "")
                || manifest.File != SetupFileName(manifest.Version)
                || !Hex.IsMatch(manifest.Sha256 ?? "")
                || manifest.Size <= 0 || manifest.Size > MaxSize
                || string.IsNullOrWhiteSpace(manifest.Statement)
                || !PartsAreSensible(manifest))
            {
                throw new UpdateException("The update's description is not complete.");
            }

            var notes = (manifest.Notes ?? "").Trim();
            manifest.Notes = notes.Length > MaxNotes ? notes.Substring(0, MaxNotes) : notes;
            return manifest;
        }

        private static bool PartsAreSensible(UpdateManifest manifest) =>
            manifest.PartSize == 0
            || (manifest.PartSize >= MinPartSize && manifest.PartSize <= MaxPartSize && manifest.PartCount <= MaxParts);

        public override string ToString() => string.Format(CultureInfo.InvariantCulture, "{0} ({1:N0} bytes)", File, Size);
    }
}
