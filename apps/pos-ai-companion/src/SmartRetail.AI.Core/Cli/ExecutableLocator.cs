using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SmartRetail.AI.Cli
{
    public static class ExecutableLocator
    {
        public static bool IsWindows => Environment.OSVersion.Platform == PlatformID.Win32NT;

        /// <summary>Finds a tool: the configured path if one is set, otherwise PATH and then the extra folders.</summary>
        /// <returns>The full path, or null when the tool cannot be found.</returns>
        public static string Resolve(string configuredPath, string commandName, IEnumerable<string> extraDirectories = null)
        {
            if (!string.IsNullOrWhiteSpace(configuredPath))
            {
                var path = Environment.ExpandEnvironmentVariables(configuredPath.Trim().Trim('"'));
                if (path.IndexOf(Path.DirectorySeparatorChar) < 0 && path.IndexOf(Path.AltDirectorySeparatorChar) < 0)
                {
                    // A bare name such as "ollama": look it up like a command.
                    return Resolve(null, path, extraDirectories);
                }

                return File.Exists(path) ? Path.GetFullPath(path) : null;
            }

            if (string.IsNullOrWhiteSpace(commandName))
            {
                return null;
            }

            var pathDirectories = (Environment.GetEnvironmentVariable("PATH") ?? "").Split(Path.PathSeparator);
            foreach (var directory in pathDirectories.Concat(extraDirectories ?? Enumerable.Empty<string>()))
            {
                if (string.IsNullOrWhiteSpace(directory))
                {
                    continue;
                }

                foreach (var name in CandidateFileNames(commandName))
                {
                    string candidate;
                    try
                    {
                        candidate = Path.Combine(Environment.ExpandEnvironmentVariables(directory.Trim().Trim('"')), name);
                    }
                    catch (ArgumentException)
                    {
                        break;
                    }

                    if (File.Exists(candidate))
                    {
                        return Path.GetFullPath(candidate);
                    }
                }
            }

            return null;
        }

        /// <summary>On Windows only real launchers count: npm also writes an extensionless shell script.</summary>
        public static IEnumerable<string> CandidateFileNames(string commandName)
        {
            if (!IsWindows || Path.HasExtension(commandName))
            {
                return new[] { commandName };
            }

            return new[] { ".exe", ".cmd", ".bat", ".com" }.Select(extension => commandName + extension);
        }

        /// <summary>Where the official installers put these tools when PATH has not been refreshed yet.</summary>
        public static IEnumerable<string> CommonUserToolDirectories()
        {
            var profile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var directories = new List<string>();
            if (!string.IsNullOrEmpty(local))
            {
                // OpenAI's standalone Codex installer (chatgpt.com/codex/install.ps1). Its PATH change only reaches
                // programs started after it, so the assistant looks here itself.
                directories.Add(Path.Combine(local, "Programs", "OpenAI", "Codex", "bin"));
            }

            if (!string.IsNullOrEmpty(profile))
            {
                // Native installers for Claude Code and the Antigravity CLI.
                directories.Add(Path.Combine(profile, ".local", "bin"));
            }

            if (!string.IsNullOrEmpty(roaming))
            {
                // npm global installs, e.g. `npm i -g @openai/codex`.
                directories.Add(Path.Combine(roaming, "npm"));
            }

            return directories;
        }
    }
}
