using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SmartRetail.AI.Storage
{
    /// <summary>Whether a folder can hold the add-on's data.</summary>
    public sealed class DataFolderCheck
    {
        /// <summary>The full path of the folder.</summary>
        public string Folder { get; set; } = "";

        /// <summary>Why it cannot be used, or null when it can.</summary>
        public string Problem { get; set; }

        /// <summary>It is the folder in use already.</summary>
        public bool IsCurrent { get; set; }

        /// <summary>It already holds the add-on's data, which will be used as it is; nothing is moved.</summary>
        public bool HasData { get; set; }

        /// <summary>Free space on its drive, or -1 when unknown.</summary>
        public long FreeBytes { get; set; } = -1;

        /// <summary>The data that would be moved there.</summary>
        public long NeededBytes { get; set; }

        public bool Ok => Problem == null;
    }

    public sealed class DataFolderMove
    {
        public int Files { get; set; }

        public long Bytes { get; set; }

        /// <summary>Set when the data was moved but some old files could not be deleted.</summary>
        public string Warning { get; set; }
    }

    /// <summary>Checks a new data folder and moves the data there without ever leaving it half in each place.</summary>
    public static class DataFolderMover
    {
        /// <summary>Room to leave free on the drive beyond the data itself.</summary>
        public const long SpareBytes = 200L * 1024 * 1024;

        private static bool IsWindows => Path.DirectorySeparatorChar == '\\';

        private static StringComparison PathComparison => IsWindows ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

        /// <summary>Checks that the folder is on this PC, can be written to, and has room for the data in the current folder.</summary>
        public static DataFolderCheck Check(string currentFolder, string folder)
        {
            var check = new DataFolderCheck();
            var text = (folder ?? "").Trim().Trim('"').Trim();
            if (text.Length == 0)
            {
                check.Problem = "Choose a folder.";
                return check;
            }

            if (text.StartsWith(@"\\", StringComparison.Ordinal) || text.StartsWith("//", StringComparison.Ordinal))
            {
                check.Problem = "Choose a folder on this PC, not a network folder.";
                return check;
            }

            if (!Path.IsPathRooted(text) || (IsWindows && !(text.Length >= 3 && char.IsLetter(text[0]) && text[1] == ':' && (text[2] == '\\' || text[2] == '/'))))
            {
                check.Problem = IsWindows ? @"Give the full path, for example D:\Smart Retail POS AI." : "Give the full path, starting with /.";
                return check;
            }

            try
            {
                check.Folder = Path.GetFullPath(text);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is NotSupportedException || ex is PathTooLongException)
            {
                check.Problem = "This is not a folder path Windows accepts.";
                return check;
            }

            var current = Path.GetFullPath(currentFolder);
            if (Same(check.Folder, current))
            {
                check.IsCurrent = true;
                return check;
            }

            if (DataFolders.Parts.Any(part => IsInside(check.Folder, Path.Combine(current, part))))
            {
                check.Problem = "Choose a folder outside the current data folder's " + DataFolders.PartNames + " folders.";
                return check;
            }

            var writeProblem = CanWrite(check.Folder);
            if (writeProblem != null)
            {
                check.Problem = "Cannot write to this folder: " + writeProblem;
                return check;
            }

            check.HasData = Directory.Exists(check.Folder) && DataFolders.HasData(check.Folder);
            check.NeededBytes = check.HasData ? 0 : DataFolders.Size(current).Bytes;
            check.FreeBytes = FreeBytes(check.Folder);
            if (check.FreeBytes >= 0 && check.FreeBytes < check.NeededBytes + SpareBytes)
            {
                check.Problem = "Not enough space: the data needs " + Describe(check.NeededBytes) + ", plus " + Describe(SpareBytes)
                    + " to spare, and the drive has " + Describe(check.FreeBytes) + " free.";
            }

            return check;
        }

        /// <summary>
        /// Copies the data to the new folder and checks every copy, then calls <paramref name="switchOver"/> (which makes
        /// the new folder the one in use), then deletes the old copies. If anything fails before the switch, the copies
        /// are removed and the old folder stays as it was.
        /// </summary>
        public static DataFolderMove Move(string currentFolder, string newFolder, Action switchOver, IProgress<string> progress = null)
        {
            var move = new DataFolderMove();
            if (Same(Path.GetFullPath(currentFolder), Path.GetFullPath(newFolder)))
            {
                switchOver?.Invoke();
                return move;
            }

            var made = new List<string>();
            try
            {
                foreach (var part in DataFolders.Parts)
                {
                    var from = Path.Combine(currentFolder, part);
                    if (!Directory.Exists(from))
                    {
                        continue;
                    }

                    var to = Path.Combine(newFolder, part);
                    if (Directory.Exists(to) && Directory.EnumerateFileSystemEntries(to).Any())
                    {
                        throw new IOException("The new folder already has a " + part + " folder with files in it.");
                    }

                    made.Add(to);
                    Directory.CreateDirectory(to);
                    foreach (var file in new DirectoryInfo(from).EnumerateFiles("*", SearchOption.AllDirectories))
                    {
                        var relative = file.FullName.Substring(from.Length).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                        var copy = Path.Combine(to, relative);
                        Directory.CreateDirectory(Path.GetDirectoryName(copy));
                        file.CopyTo(copy, false);
                        if (new FileInfo(copy).Length != file.Length)
                        {
                            throw new IOException("The copy of " + relative + " is incomplete.");
                        }

                        move.Files++;
                        move.Bytes += file.Length;
                        if (move.Files % 25 == 0)
                        {
                            progress?.Report("Copied " + move.Files + " files (" + Describe(move.Bytes) + ")…");
                        }
                    }
                }

                switchOver?.Invoke();
            }
            catch
            {
                foreach (var folder in made)
                {
                    TryDelete(folder);
                }

                throw;
            }

            foreach (var part in DataFolders.Parts)
            {
                var old = Path.Combine(currentFolder, part);
                if (Directory.Exists(old) && TryDelete(old) is string problem)
                {
                    move.Warning = "Everything was copied to the new folder, but some old files could not be deleted from " + old + ": " + problem;
                }
            }

            return move;
        }

        /// <summary>Free space on the drive that holds the folder, or -1 when unknown.</summary>
        public static long FreeBytes(string folder)
        {
            try
            {
                var full = Path.GetFullPath(folder);
                var drive = DriveInfo.GetDrives()
                    .Where(d => d.IsReady && (Same(full, d.RootDirectory.FullName) || IsInside(full, d.RootDirectory.FullName)))
                    .OrderByDescending(d => d.RootDirectory.FullName.Length)
                    .FirstOrDefault();
                return drive?.AvailableFreeSpace ?? -1;
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is ArgumentException)
            {
                return -1;
            }
        }

        /// <summary>Sizes as people read them: "850 MB", "12.4 GB".</summary>
        public static string Describe(long bytes)
        {
            if (bytes < 0)
            {
                return "unknown";
            }

            const double Kb = 1024, Mb = Kb * 1024, Gb = Mb * 1024;
            return bytes >= Gb ? (bytes / Gb).ToString(bytes >= 100 * Gb ? "0" : "0.0", System.Globalization.CultureInfo.InvariantCulture) + " GB"
                : bytes >= Mb ? (bytes / Mb).ToString("0", System.Globalization.CultureInfo.InvariantCulture) + " MB"
                : bytes >= Kb ? (bytes / Kb).ToString("0", System.Globalization.CultureInfo.InvariantCulture) + " KB"
                : bytes + " bytes";
        }

        public static bool Same(string a, string b) =>
            string.Equals(Trim(a), Trim(b), PathComparison);

        /// <summary>True when <paramref name="path"/> is inside <paramref name="folder"/>, at any depth.</summary>
        public static bool IsInside(string path, string folder)
        {
            var child = Trim(path);
            var parent = Trim(folder);
            if (parent.Length > 0 && parent[parent.Length - 1] != Path.DirectorySeparatorChar)
            {
                parent += Path.DirectorySeparatorChar;
            }

            return child.Length > parent.Length && child.StartsWith(parent, PathComparison);
        }

        private static string Trim(string path)
        {
            var full = Path.GetFullPath(path);
            var root = Path.GetPathRoot(full) ?? "";
            return full.Length > root.Length ? full.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) : full;
        }

        /// <summary>Makes the folder if needed and writes a file in it. Folders it made are removed again. Null when all is well.</summary>
        private static string CanWrite(string folder)
        {
            var firstMade = folder;
            while (!Directory.Exists(Path.GetDirectoryName(firstMade) ?? firstMade) && Path.GetDirectoryName(firstMade) != null)
            {
                firstMade = Path.GetDirectoryName(firstMade);
            }

            var existed = Directory.Exists(folder);
            try
            {
                Directory.CreateDirectory(folder);
                var probe = Path.Combine(folder, ".write-test-" + Guid.NewGuid().ToString("N"));
                File.WriteAllText(probe, "ok");
                File.Delete(probe);
                return null;
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is NotSupportedException || ex is ArgumentException)
            {
                return ex.Message;
            }
            finally
            {
                if (!existed && Directory.Exists(firstMade) && !Directory.EnumerateFiles(firstMade, "*", SearchOption.AllDirectories).Any())
                {
                    TryDelete(firstMade);
                }
            }
        }

        private static string TryDelete(string folder)
        {
            try
            {
                if (Directory.Exists(folder))
                {
                    Directory.Delete(folder, true);
                }

                return null;
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                return ex.Message;
            }
        }
    }
}
