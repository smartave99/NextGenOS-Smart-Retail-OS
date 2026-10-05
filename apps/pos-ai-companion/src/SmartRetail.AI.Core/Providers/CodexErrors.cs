using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace SmartRetail.AI.Providers
{
    /// <summary>
    /// Codex's errors in a few words. <c>codex exec</c> writes its errors on lines that start "ERROR:", often twice, after
    /// an echo of the prompt; only those lines are kept, each once. A usage limit becomes one plain sentence that says
    /// when Codex can answer again.
    /// </summary>
    public static class CodexErrors
    {
        /// <summary>Where the owner sees Codex's usage and can get more.</summary>
        public const string UsagePage = "chatgpt.com/codex/settings/usage";

        /// <summary>An error longer than this is cut.</summary>
        public const int MaxLength = 300;

        // Lines end in "\n" or, on Windows, "\r\n": "$" in multiline mode stops only before "\n".
        private static readonly Regex ErrorLine = new Regex(@"^[ \t]*ERROR:[ \t]*(?<text>\S[^\r\n]*?)[ \t]*\r?$", RegexOptions.Multiline);

        private static readonly Regex TryAgain = new Regex(@"try again (?<when>(?:at|in|after|on) [^\r\n]+?)\s*\.?\s*$",
            RegexOptions.IgnoreCase | RegexOptions.Multiline);

        /// <summary>The errors Codex wrote, each once, in order.</summary>
        public static IReadOnlyList<string> Errors(string output) =>
            ErrorLine.Matches(output ?? "").Cast<Match>().Select(m => m.Groups["text"].Value).Distinct(StringComparer.Ordinal).ToList();

        /// <summary>
        /// A usage-limit error in plain words, e.g. "Codex has reached its usage limit. It can answer again at 7:33 PM.
        /// For more now, see chatgpt.com/codex/settings/usage."; null for any other error.
        /// </summary>
        /// <param name="error">One error from Codex: an "ERROR:" line, or its app server's message.</param>
        public static string UsageLimit(string error)
        {
            if (string.IsNullOrWhiteSpace(error) || error.IndexOf("usage limit", StringComparison.OrdinalIgnoreCase) < 0)
            {
                return null;
            }

            var when = TryAgain.Match(error);
            return "Codex has reached its usage limit. "
                + (when.Success ? "It can answer again " + when.Groups["when"].Value.Trim() + ". " : "It can answer again later. ")
                + "For more now, see " + UsagePage + ".";
        }

        /// <summary>The usage limit among what Codex wrote, in plain words; null when it did not hit one.</summary>
        public static string UsageLimitIn(string output) => Errors(output).Select(UsageLimit).FirstOrDefault(message => message != null);

        /// <summary>
        /// A usage-limit error with the time Codex gave for answering again, when it gave one in words that are understood
        /// (<see cref="ResetTime"/>); null for any other error.
        /// </summary>
        /// <param name="error">One error from Codex: an "ERROR:" line, or its app server's message.</param>
        /// <param name="now">The time now, which "in 2 hours" and "7:33 PM" are counted from; the clock when not given.</param>
        public static UsageLimitInfo UsageLimitOf(string error, DateTimeOffset? now = null)
        {
            var message = UsageLimit(error);
            if (message == null)
            {
                return null;
            }

            var when = TryAgain.Match(error);
            return new UsageLimitInfo(message, when.Success ? ResetTime(when.Groups["when"].Value, now ?? DateTimeOffset.Now) : (DateTimeOffset?)null);
        }

        /// <summary>The usage limit among what Codex wrote, with its time; null when it did not hit one.</summary>
        public static UsageLimitInfo UsageLimitInfoIn(string output, DateTimeOffset? now = null) =>
            Errors(output).Select(error => UsageLimitOf(error, now)).FirstOrDefault(limit => limit != null);

        /// <summary>True for the sentence <see cref="UsageLimit"/> makes: a set or listing that stopped with it (before the work waited for the
        /// limit by itself) is carried on when the app starts.</summary>
        public static bool IsUsageLimitMessage(string message) =>
            message != null && message.StartsWith("Codex has reached its usage limit.", StringComparison.Ordinal);

        private static readonly Regex Duration = new Regex(
            @"(?<n>\d+(?:\.\d+)?|an?)\s*(?<unit>weeks?|days?|hours?|hrs?|minutes?|mins?|seconds?|secs?)\b",
            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        private static readonly Regex Ordinal = new Regex(@"(?<=\d)(?:st|nd|rd|th)\b", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        private static readonly string[] TimeOnly = { "h:mm tt", "h:mmtt", "H:mm", "h tt", "htt" };

        private static readonly string[] DateAndTime =
        {
            "MMM d yyyy h:mm tt", "MMMM d yyyy h:mm tt", "MMM d yyyy H:mm", "MMMM d yyyy H:mm", "MMM d yyyy h:mmtt", "MMMM d yyyy h:mmtt",
            "d MMM yyyy h:mm tt", "d MMMM yyyy h:mm tt", "d MMM yyyy H:mm", "d MMMM yyyy H:mm", "d MMM yyyy h:mmtt", "d MMMM yyyy h:mmtt",
            "yyyy-MM-dd H:mm", "yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd h:mm tt", "yyyy-MM-dd'T'HH:mm:ss", "yyyy-MM-dd'T'HH:mm",
        };

        private static readonly string[] DateAndTimeThisYear =
        {
            "MMM d h:mm tt", "MMMM d h:mm tt", "MMM d H:mm", "MMMM d H:mm", "MMM d h:mmtt", "MMMM d h:mmtt",
            "d MMM h:mm tt", "d MMMM h:mm tt", "d MMM H:mm", "d MMMM H:mm", "d MMM h:mmtt", "d MMMM h:mmtt",
        };

        /// <summary>
        /// When Codex says it can answer again: "at 7:33 PM" (the next 7:33 PM), "at Oct 7th, 2026 9:15 AM", "in 2 hours" or
        /// "in 3 days 4 hours 12 minutes". Null when the words are not understood, so the caller waits a while instead.
        /// </summary>
        /// <param name="when">The words after "try again", e.g. "at 7:33 PM".</param>
        /// <param name="now">The time now, with the offset the clock times are read in.</param>
        public static DateTimeOffset? ResetTime(string when, DateTimeOffset now)
        {
            var text = (when ?? "").Trim().TrimEnd('.').Trim();
            var lead = Regex.Match(text, @"^(?<word>at|in|after|on)\s+(?<rest>.+)$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            if (!lead.Success)
            {
                return null;
            }

            var rest = lead.Groups["rest"].Value.Trim();
            var word = lead.Groups["word"].Value.ToLowerInvariant();
            return word == "in" || word == "after" ? After(rest, now) : At(rest, now);
        }

        private static DateTimeOffset? After(string text, DateTimeOffset now)
        {
            var total = TimeSpan.Zero;
            foreach (Match part in Duration.Matches(text))
            {
                var count = part.Groups["n"].Value;
                var n = count.Equals("a", StringComparison.OrdinalIgnoreCase) || count.Equals("an", StringComparison.OrdinalIgnoreCase)
                    ? 1d
                    : double.Parse(count, CultureInfo.InvariantCulture);
                var unit = part.Groups["unit"].Value.ToLowerInvariant();
                total += unit.StartsWith("w", StringComparison.Ordinal) ? TimeSpan.FromDays(7 * n)
                    : unit.StartsWith("d", StringComparison.Ordinal) ? TimeSpan.FromDays(n)
                    : unit.StartsWith("h", StringComparison.Ordinal) ? TimeSpan.FromHours(n)
                    : unit.StartsWith("m", StringComparison.Ordinal) ? TimeSpan.FromMinutes(n)
                    : TimeSpan.FromSeconds(n);
            }

            return total > TimeSpan.Zero ? now + total : (DateTimeOffset?)null;
        }

        private static DateTimeOffset? At(string text, DateTimeOffset now)
        {
            var clean = Regex.Replace(Ordinal.Replace(text, "").Replace(",", " "), @"\s+", " ").Trim();
            const DateTimeStyles styles = DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.NoCurrentDateDefault;
            if (DateTime.TryParseExact(clean, TimeOnly, CultureInfo.InvariantCulture, styles, out var time))
            {
                // A time of day: the next one.
                var today = new DateTimeOffset(now.Date + time.TimeOfDay, now.Offset);
                return today > now ? today : today.AddDays(1);
            }

            if (DateTime.TryParseExact(clean, DateAndTime, CultureInfo.InvariantCulture, styles, out var dated))
            {
                return new DateTimeOffset(dated, now.Offset);
            }

            if (DateTime.TryParseExact(clean, DateAndTimeThisYear, CultureInfo.InvariantCulture, styles, out var undated))
            {
                // No year: this year's, or next year's when that has passed.
                var thisYear = new DateTimeOffset(new DateTime(now.Year, undated.Month, undated.Day) + undated.TimeOfDay, now.Offset);
                return thisYear > now ? thisYear : thisYear.AddYears(1);
            }

            return DateTimeOffset.TryParse(clean, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces, out var parsed)
                ? parsed
                : (DateTimeOffset?)null;
        }

        /// <summary>The errors Codex wrote, joined and cut short; empty when it wrote none.</summary>
        public static string Short(string output)
        {
            var text = string.Join(" ", Errors(output));
            return text.Length <= MaxLength ? text : text.Substring(0, MaxLength).TrimEnd() + "…";
        }
    }
}
