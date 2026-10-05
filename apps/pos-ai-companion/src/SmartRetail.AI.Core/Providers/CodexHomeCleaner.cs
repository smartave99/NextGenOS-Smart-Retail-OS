using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SmartRetail.AI.Providers
{
    /// <summary>
    /// Clears what one image run left in Codex's own folder (CODEX_HOME, normally ~/.codex), so the shop's photos, words
    /// and pictures are kept only in the data folder. Image runs cannot use <c>--ephemeral</c> (the image tool may not work
    /// without a saved session), so Codex keeps a session log of the run and copies of the pictures it made. Only this
    /// run's files go:
    /// <list type="bullet">
    /// <item>its session log: a <c>sessions/**/rollout-*.jsonl</c> written during the run whose first line
    /// (<c>session_meta</c>) names the run's own empty working folder, which no other run ever uses;</item>
    /// <item>the pictures it made under <c>generated_images</c>: those in a file or folder named after its session, and
    /// those with exactly the bytes of the picture the app took.</item>
    /// </list>
    /// auth.json, config.toml and every other file there are never touched, and a failure never fails the run.
    /// </summary>
    public static class CodexHomeCleaner
    {
        /// <summary>A session's first line is read up to this size; a longer one is left alone.</summary>
        private const int MaxFirstLine = 4 * 1024 * 1024;

        /// <summary>Files written this long before the run began still count as the run's (clocks and file times differ).</summary>
        private static readonly TimeSpan Slack = TimeSpan.FromSeconds(5);

        /// <summary>Removes the run's files; gives how many were removed.</summary>
        /// <param name="codexHome">Codex's folder.</param>
        /// <param name="workingDirectory">The run's own working folder, as Codex was given it.</param>
        /// <param name="startedUtc">When the run began.</param>
        /// <param name="keptImage">The picture the app took from the run, or null.</param>
        public static int Clean(string codexHome, string workingDirectory, DateTime startedUtc, byte[] keptImage)
        {
            if (string.IsNullOrWhiteSpace(codexHome) || string.IsNullOrWhiteSpace(workingDirectory) || !Directory.Exists(codexHome))
            {
                return 0;
            }

            var removed = 0;
            var sessionIds = new List<string>();
            var since = startedUtc - Slack;
            foreach (var (log, id) in Sessions(codexHome, workingDirectory, since))
            {
                if (TryDelete(log))
                {
                    removed++;
                    if (id != null)
                    {
                        sessionIds.Add(id);
                    }
                }
            }

            var images = Path.Combine(codexHome, "generated_images");
            var keptHash = keptImage == null || keptImage.Length == 0 ? null : Hash(keptImage);
            foreach (var picture in RecentFiles(images, "*", since))
            {
                var relative = picture.Substring(images.Length);
                var ofThisRun = sessionIds.Any(id => relative.IndexOf(id, StringComparison.OrdinalIgnoreCase) >= 0)
                    || (keptHash != null && SameBytes(picture, keptImage.Length, keptHash));
                if (ofThisRun && TryDelete(picture))
                {
                    removed++;
                }
            }

            // Folders of this run's session, emptied just now.
            if (Directory.Exists(images) && sessionIds.Count > 0)
            {
                foreach (var folder in SafeDirectories(images).OrderByDescending(path => path.Length))
                {
                    var name = folder.Substring(images.Length);
                    if (sessionIds.Any(id => name.IndexOf(id, StringComparison.OrdinalIgnoreCase) >= 0) && IsEmpty(folder))
                    {
                        try
                        {
                            Directory.Delete(folder);
                        }
                        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                        {
                            // Left for Codex.
                        }
                    }
                }
            }

            return removed;
        }

        /// <summary>The ids of the sessions Codex saved for the run: the logs written since it began that name its working folder.</summary>
        public static IReadOnlyList<string> SessionIds(string codexHome, string workingDirectory, DateTime startedUtc) =>
            string.IsNullOrWhiteSpace(codexHome) || string.IsNullOrWhiteSpace(workingDirectory) || !Directory.Exists(codexHome)
                ? new string[0]
                : Sessions(codexHome, workingDirectory, startedUtc - Slack).Select(session => session.Id).Where(id => id != null).ToList();

        /// <summary>The run's session logs, each with its id (null when it has none worth matching).</summary>
        private static IEnumerable<(string Log, string Id)> Sessions(string codexHome, string workingDirectory, DateTime sinceUtc)
        {
            foreach (var log in RecentFiles(Path.Combine(codexHome, "sessions"), "rollout-*.jsonl", sinceUtc))
            {
                var (id, cwd) = SessionOf(log);
                if (cwd != null && SamePath(cwd, workingDirectory))
                {
                    yield return (log, !string.IsNullOrWhiteSpace(id) && id.Trim().Length >= 8 ? id.Trim() : null);
                }
            }
        }

        /// <summary>A session log's id and working folder, from its first line; nulls when it is not one.</summary>
        internal static (string Id, string Cwd) SessionOf(string path)
        {
            try
            {
                using (var reader = new StreamReader(path, Encoding.UTF8))
                {
                    var buffer = new StringBuilder();
                    int next;
                    while ((next = reader.Read()) >= 0 && next != '\n')
                    {
                        if (buffer.Length >= MaxFirstLine)
                        {
                            return (null, null);
                        }

                        buffer.Append((char)next);
                    }

                    var line = JObject.Parse(buffer.ToString());
                    if (line.Value<string>("type") != "session_meta" || !(line["payload"] is JObject payload))
                    {
                        return (null, null);
                    }

                    return (payload.Value<string>("id"), payload.Value<string>("cwd"));
                }
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is JsonException || ex is InvalidCastException)
            {
                return (null, null);
            }
        }

        /// <summary>The same folder, however it is written (slashes, a trailing slash, Windows' \\?\ prefix, case on Windows).</summary>
        internal static bool SamePath(string one, string other)
        {
            string Clean(string path)
            {
                var text = path.Trim();
                if (text.StartsWith(@"\\?\", StringComparison.Ordinal))
                {
                    text = text.Substring(4);
                }

                try
                {
                    text = Path.GetFullPath(text);
                }
                catch (Exception ex) when (ex is ArgumentException || ex is NotSupportedException || ex is PathTooLongException)
                {
                    return null;
                }

                return text.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            }

            var a = Clean(one);
            var b = Clean(other);
            return a != null && b != null && string.Equals(a, b,
                Path.DirectorySeparatorChar == '\\' ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }

        private static IEnumerable<string> RecentFiles(string folder, string pattern, DateTime sinceUtc)
        {
            if (!Directory.Exists(folder))
            {
                return new string[0];
            }

            try
            {
                return Directory.EnumerateFiles(folder, pattern, SearchOption.AllDirectories)
                    .Where(file => File.GetLastWriteTimeUtc(file) >= sinceUtc)
                    .ToList();
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                return new string[0];
            }
        }

        private static IEnumerable<string> SafeDirectories(string folder)
        {
            try
            {
                return Directory.EnumerateDirectories(folder, "*", SearchOption.AllDirectories).ToList();
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                return new string[0];
            }
        }

        private static bool IsEmpty(string folder)
        {
            try
            {
                return !Directory.EnumerateFileSystemEntries(folder).Any();
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                return false;
            }
        }

        private static bool SameBytes(string path, int length, string hash)
        {
            try
            {
                return new FileInfo(path).Length == length && Hash(File.ReadAllBytes(path)) == hash;
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                return false;
            }
        }

        private static string Hash(byte[] bytes)
        {
            using (var sha = SHA256.Create())
            {
                return Convert.ToBase64String(sha.ComputeHash(bytes));
            }
        }

        private static bool TryDelete(string path)
        {
            try
            {
                File.Delete(path);
                return true;
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                return false;
            }
        }
    }
}
