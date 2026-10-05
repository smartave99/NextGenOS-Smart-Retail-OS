using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SmartRetail.AI.Providers
{
    /// <summary>
    /// Codex keeps a copy of its model list in its own folder (<c>models_cache.json</c>), with the version of the Codex that
    /// fetched it. A copy from an older Codex can go on being shown after Codex was updated, and then the newest models are
    /// missing from the list (openai/codex issue 33146). That one file is all this ever removes, and only when it names another
    /// version than the one installed: Codex then fetches its list again by itself. Nothing else in Codex's folder is touched.
    /// </summary>
    public static class CodexModelsCache
    {
        public const string FileName = "models_cache.json";

        /// <summary>A copy of a model list is some tens of kilobytes; anything much bigger is not one.</summary>
        private const long MaxBytes = 5 * 1024 * 1024;

        /// <summary>The Codex version that fetched the copy, e.g. "0.142.3"; empty when there is no copy or it does not say.</summary>
        public static string VersionOf(string codexHome)
        {
            var path = PathOf(codexHome);
            if (path == null)
            {
                return "";
            }

            try
            {
                var info = new FileInfo(path);
                if (!info.Exists || info.Length > MaxBytes || (info.Attributes & FileAttributes.ReparsePoint) != 0)
                {
                    return "";
                }

                var parsed = JToken.Parse(File.ReadAllText(path, Encoding.UTF8));
                return Clean((parsed as JObject)?["client_version"]?.Type == JTokenType.String ? (string)parsed["client_version"] : "");
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is JsonException)
            {
                return "";
            }
        }

        /// <summary>
        /// Removes the copy when another Codex version fetched it than <paramref name="installedVersion"/>; true when it did. A copy
        /// that does not name its version, cannot be read, or is not a plain file is left as it is, and so is everything else.
        /// </summary>
        public static bool RemoveIfFromOtherVersion(string codexHome, string installedVersion)
        {
            var installed = Clean(installedVersion);
            var copy = VersionOf(codexHome);
            if (installed.Length == 0 || copy.Length == 0 || string.Equals(installed, copy, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            try
            {
                File.Delete(PathOf(codexHome));
                return true;
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                return false;
            }
        }

        private static string PathOf(string codexHome) =>
            string.IsNullOrWhiteSpace(codexHome) ? null : Path.Combine(codexHome.Trim(), FileName);

        /// <summary>"0.158.0" from " v0.158.0 ".</summary>
        private static string Clean(string version)
        {
            var text = (version ?? "").Trim();
            return text.Length > 1 && (text[0] == 'v' || text[0] == 'V') && char.IsDigit(text[1]) ? text.Substring(1) : text;
        }
    }
}
