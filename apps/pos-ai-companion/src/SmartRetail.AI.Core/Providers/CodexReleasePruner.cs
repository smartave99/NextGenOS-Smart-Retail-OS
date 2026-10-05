using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SmartRetail.AI.Providers
{
    /// <summary>
    /// OpenAI's installer keeps every release it installed, each in its own folder, and never removes an old one: with an
    /// update every week or two they would fill the disk over the years. After an update, the folders of the older releases are
    /// removed, keeping the newest few and the versions named (the one now in use and the one before it, which a roll back needs).
    /// Only folders named like a release (<c>0.158.0-x86_64-pc-windows-msvc</c>) are ever touched; nothing else in Codex's folder is.
    /// </summary>
    public static class CodexReleasePruner
    {
        /// <summary>How many of the newest releases stay, whatever else.</summary>
        public const int KeepNewest = 3;

        private static readonly Regex ReleaseFolder = new Regex(
            @"^(?<v>\d{1,4}\.\d{1,4}\.\d{1,4})(?<pre>-(?:alpha|beta)[0-9A-Za-z.]*)?-[A-Za-z0-9_]+(?:-[A-Za-z0-9_]+)+$", RegexOptions.CultureInvariant);

        /// <summary>The folder the standalone installer keeps releases in, inside Codex's own folder (CODEX_HOME, or .codex in the user's folder).</summary>
        public static string ReleasesFolder(string codexHome) => Path.Combine(codexHome, "packages", "standalone", "releases");

        /// <summary>Codex's own folder, as Codex and its installer find it.</summary>
        public static string DefaultCodexHome()
        {
            var configured = Environment.GetEnvironmentVariable("CODEX_HOME");
            return string.IsNullOrWhiteSpace(configured)
                ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".codex")
                : configured.Trim();
        }

        /// <summary>
        /// Removes the folders of the older releases and says which. Nothing is removed unless the folder of one of the versions to
        /// keep is there (the layout is then the one that is expected), and a folder that is in use is left as it is.
        /// </summary>
        public static IReadOnlyList<string> Prune(string releasesFolder, IEnumerable<string> keepVersions, int keepNewest = KeepNewest)
        {
            var removed = new List<string>();
            if (string.IsNullOrWhiteSpace(releasesFolder) || !Directory.Exists(releasesFolder))
            {
                return removed;
            }

            var keep = new HashSet<string>((keepVersions ?? Enumerable.Empty<string>()).Where(v => !string.IsNullOrWhiteSpace(v)).Select(v => v.Trim()), StringComparer.Ordinal);
            var releases = new List<Release>();
            foreach (var directory in new DirectoryInfo(releasesFolder).GetDirectories())
            {
                var match = ReleaseFolder.Match(directory.Name);
                if (!match.Success || (directory.Attributes & FileAttributes.ReparsePoint) != 0)
                {
                    continue;
                }

                releases.Add(new Release(directory, Version.Parse(match.Groups["v"].Value), match.Groups["pre"].Success, match.Groups["v"].Value));
            }

            if (!releases.Any(release => keep.Contains(release.Text)))
            {
                return removed;
            }

            var newest = new HashSet<string>(
                releases.OrderByDescending(release => release.Version).ThenBy(release => release.Prerelease)
                    .Take(Math.Max(1, keepNewest)).Select(release => release.Directory.FullName),
                StringComparer.OrdinalIgnoreCase);
            foreach (var release in releases.Where(release => !keep.Contains(release.Text) && !newest.Contains(release.Directory.FullName)))
            {
                if (InUse(release.Directory))
                {
                    // Something (another Codex, say the one of an editor that was left open) still runs from this release.
                    continue;
                }

                try
                {
                    release.Directory.Delete(recursive: true);
                    removed.Add(release.Directory.Name);
                }
                catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                {
                    // In use, or not ours to remove: it stays, and is tried again after the next update.
                }
            }

            return removed;
        }

        /// <summary>
        /// True when a program of this release is running, or the folder cannot be looked at: Windows does not let a running program
        /// be opened for writing. The folder is then left as it is, whole, rather than emptied as far as Windows allows.
        /// </summary>
        private static bool InUse(DirectoryInfo directory)
        {
            try
            {
                foreach (var program in directory.EnumerateFiles("*.exe", SearchOption.AllDirectories))
                {
                    try
                    {
                        using (new FileStream(program.FullName, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                        {
                        }
                    }
                    catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                return true;
            }
        }

        private sealed class Release
        {
            public Release(DirectoryInfo directory, Version version, bool prerelease, string text)
            {
                Directory = directory;
                Version = version;
                Prerelease = prerelease;
                Text = text;
            }

            public DirectoryInfo Directory { get; }

            public Version Version { get; }

            public bool Prerelease { get; }

            public string Text { get; }
        }
    }
}
