using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SmartRetail.AI.Storage;

namespace SmartRetail.AI.Updates
{
    public enum UpdateState
    {
        /// <summary>This copy has no update folder set, or checking is off.</summary>
        Off,

        /// <summary>Not checked yet.</summary>
        Unknown,

        UpToDate,

        /// <summary>A newer version is downloaded and checked: installing waits for the owner.</summary>
        Ready,

        /// <summary>The last check failed; see <see cref="UpdateStatus.Problem"/>.</summary>
        Failed,
    }

    /// <summary>What the last check found. The app writes it; the dashboard shows it (the bell, Settings).</summary>
    public sealed class UpdateStatus
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public UpdateState State { get; set; } = UpdateState.Unknown;

        /// <summary>The version running when it was checked.</summary>
        public string Current { get; set; } = "";

        /// <summary>The newer version, when <see cref="UpdateState.Ready"/>.</summary>
        public string Available { get; set; } = "";

        public string File { get; set; } = "";

        public string Sha256 { get; set; } = "";

        public string Notes { get; set; } = "";

        public DateTime? CheckedAt { get; set; }

        public string Problem { get; set; } = "";

        /// <summary>Nothing missing, whatever a file edited by hand said: text that is null counts as empty.</summary>
        public UpdateStatus Normalize()
        {
            Current = Current ?? "";
            Available = Available ?? "";
            File = File ?? "";
            Sha256 = Sha256 ?? "";
            Notes = Notes ?? "";
            Problem = Problem ?? "";
            return this;
        }
    }

    /// <summary>
    /// The Updates folder, beside the logs in the Windows user's local app data (never in the data folder, which is the
    /// shop's): the downloaded setup and status.json.
    /// </summary>
    public static class UpdateFolder
    {
        public const string StatusFileName = "status.json";

        public static string Default => Path.Combine(DataFolders.Default, "Updates");

        public static UpdateStatus Load(string folder)
        {
            var path = Path.Combine(folder, StatusFileName);
            try
            {
                return File.Exists(path)
                    ? (JsonConvert.DeserializeObject<UpdateStatus>(File.ReadAllText(path, Encoding.UTF8)) ?? new UpdateStatus()).Normalize()
                    : new UpdateStatus();
            }
            catch (Exception ex) when (ex is JsonException || ex is IOException || ex is UnauthorizedAccessException)
            {
                return new UpdateStatus();
            }
        }

        public static void Save(string folder, UpdateStatus status)
        {
            Directory.CreateDirectory(folder);
            var path = Path.Combine(folder, StatusFileName);
            var temporary = path + ".tmp";
            File.WriteAllText(temporary, JsonConvert.SerializeObject(status, Formatting.Indented), new UTF8Encoding(false));
            if (File.Exists(path))
            {
                File.Replace(temporary, path, null);
            }
            else
            {
                File.Move(temporary, path);
            }
        }
    }
}
