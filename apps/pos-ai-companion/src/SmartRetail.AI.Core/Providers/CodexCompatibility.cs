using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SmartRetail.AI.Providers
{
    /// <summary>What <c>codex --help</c>, <c>codex exec --help</c> and <c>codex login --help</c> print.</summary>
    public sealed class CodexHelp
    {
        public CodexHelp(string top, string exec, string login)
        {
            Top = top ?? "";
            Exec = exec ?? "";
            Login = login ?? "";
        }

        public string Top { get; }

        public string Exec { get; }

        public string Login { get; }
    }

    /// <summary>
    /// The parts of Codex's command line this app uses (<see cref="CodexCliProvider"/>), and a way to see, from Codex's own
    /// help, whether a newer Codex still has them. The help of the Codex that works now is read first, so a flag it does not
    /// list (a hidden one) is never asked for after: only what the update took away or renamed is found. Pure and tested.
    /// </summary>
    public static class CodexCompatibility
    {
        /// <summary>Commands in <c>codex --help</c>.</summary>
        public static readonly IReadOnlyList<string> Commands = new[] { "exec", "login", "app-server" };

        /// <summary>Flags before the command: <c>codex --search exec …</c>.</summary>
        public static readonly IReadOnlyList<string> TopFlags = new[] { "--search" };

        /// <summary>Flags of <c>codex exec</c>.</summary>
        public static readonly IReadOnlyList<string> ExecFlags = new[]
        {
            "--image", "--skip-git-repo-check", "--ephemeral", "--sandbox", "--color", "--cd", "--output-last-message",
            "--output-schema", "--model", "--config", "--enable",
        };

        /// <summary>Flags and words of <c>codex login</c>.</summary>
        public static readonly IReadOnlyList<string> LoginParts = new[] { "--device-auth", "--with-api-key", "status" };

        /// <summary>Every command line part above, named the way a problem is told: "exec --output-schema".</summary>
        public static IEnumerable<string> Required()
        {
            foreach (var command in Commands)
            {
                yield return "codex " + command;
            }

            foreach (var flag in TopFlags)
            {
                yield return "codex " + flag;
            }

            foreach (var flag in ExecFlags)
            {
                yield return "exec " + flag;
            }

            foreach (var part in LoginParts)
            {
                yield return "login " + part;
            }
        }

        /// <summary>The parts of the list that this help shows.</summary>
        public static ISet<string> Visible(CodexHelp help)
        {
            var seen = new HashSet<string>(StringComparer.Ordinal);
            if (help == null)
            {
                return seen;
            }

            foreach (var command in Commands.Where(command => Listed(help.Top, command, isCommand: true)))
            {
                seen.Add("codex " + command);
            }

            foreach (var flag in TopFlags.Where(flag => Listed(help.Top, flag, isCommand: false)))
            {
                seen.Add("codex " + flag);
            }

            foreach (var flag in ExecFlags.Where(flag => Listed(help.Exec, flag, isCommand: false)))
            {
                seen.Add("exec " + flag);
            }

            foreach (var part in LoginParts)
            {
                if (Listed(help.Login, part, isCommand: !part.StartsWith("--", StringComparison.Ordinal)))
                {
                    seen.Add("login " + part);
                }
            }

            return seen;
        }

        /// <summary>What the Codex before showed and the Codex after does not: what an update took away or renamed.</summary>
        public static IReadOnlyList<string> Lost(CodexHelp before, CodexHelp after)
        {
            var now = Visible(after);
            return Visible(before).Where(part => !now.Contains(part)).OrderBy(part => part, StringComparer.Ordinal).ToList();
        }

        private static bool Listed(string help, string word, bool isCommand)
        {
            // A flag is a whole word after a space, comma, bracket or line start; a command is listed at the start of a line.
            var pattern = isCommand
                ? @"(?m)^[ \t]{1,12}" + Regex.Escape(word) + @"(?![A-Za-z0-9-])"
                : @"(?<![A-Za-z0-9-])" + Regex.Escape(word) + @"(?![A-Za-z0-9-])";
            return Regex.IsMatch(help ?? "", pattern, RegexOptions.CultureInvariant);
        }
    }
}
