using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRetail.AI.Cli
{
    public static class CommandLine
    {
        private static readonly char[] CharsNeedingQuotes = { ' ', '\t', '\n', '\v', '"' };
        private static readonly char[] CharsUnsafeForBatch = { '"', '%', '!', '\r', '\n', '\0' };

        /// <summary>Quotes one argument so the Microsoft C runtime (and CommandLineToArgvW) parses it back unchanged.</summary>
        public static string Quote(string argument)
        {
            argument = argument ?? "";
            if (argument.Length > 0 && argument.IndexOfAny(CharsNeedingQuotes) < 0)
            {
                return argument;
            }

            return QuoteAlways(argument);
        }

        public static string QuoteAlways(string argument)
        {
            var builder = new StringBuilder("\"");
            var backslashes = 0;
            foreach (var c in argument ?? "")
            {
                if (c == '\\')
                {
                    backslashes++;
                    continue;
                }

                if (c == '"')
                {
                    builder.Append('\\', (backslashes * 2) + 1);
                }
                else
                {
                    builder.Append('\\', backslashes);
                }

                builder.Append(c);
                backslashes = 0;
            }

            // Backslashes before the closing quote must be doubled or they would escape it.
            builder.Append('\\', backslashes * 2);
            builder.Append('"');
            return builder.ToString();
        }

        public static string Join(IEnumerable<string> arguments) => string.Join(" ", arguments.Select(Quote));

        /// <summary>cmd.exe expands % and ! even inside quotes, and a " would end the quoting.</summary>
        public static bool IsSafeForBatchFile(string argument) => (argument ?? "").IndexOfAny(CharsUnsafeForBatch) < 0;

        /// <summary>Splits a user-typed argument string on whitespace, keeping "quoted parts" together.</summary>
        public static List<string> Split(string text)
        {
            var result = new List<string>();
            var current = new StringBuilder();
            var inQuotes = false;
            var hasToken = false;
            foreach (var c in text ?? "")
            {
                if (c == '"')
                {
                    inQuotes = !inQuotes;
                    hasToken = true;
                }
                else if (char.IsWhiteSpace(c) && !inQuotes)
                {
                    if (hasToken)
                    {
                        result.Add(current.ToString());
                        current.Clear();
                        hasToken = false;
                    }
                }
                else
                {
                    current.Append(c);
                    hasToken = true;
                }
            }

            if (hasToken)
            {
                result.Add(current.ToString());
            }

            return result;
        }
    }
}
