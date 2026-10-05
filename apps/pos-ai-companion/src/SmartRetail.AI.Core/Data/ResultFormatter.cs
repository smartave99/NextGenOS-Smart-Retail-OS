using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SmartRetail.AI.Data
{
    public static class ResultFormatter
    {
        private const int MaxCellLength = 80;

        /// <summary>A compact pipe-separated table for prompts. Culture-invariant, so numbers mean the same to every model.</summary>
        public static string ToPromptTable(QueryResult result, int maxRows)
        {
            if (result.Columns.Count == 0)
            {
                return "(no columns)";
            }

            var builder = new StringBuilder();
            builder.AppendLine(string.Join(" | ", result.Columns));
            var shown = result.Rows.Take(Math.Max(0, maxRows)).ToList();
            foreach (var row in shown)
            {
                builder.AppendLine(string.Join(" | ", row.Select(FormatCell)));
            }

            if (result.Rows.Count == 0)
            {
                builder.AppendLine("(no rows)");
            }
            else if (shown.Count < result.Rows.Count || result.Truncated)
            {
                builder.AppendLine("(showing the first " + shown.Count + " rows; the query returned more)");
            }

            return builder.ToString();
        }

        public static string FormatCell(object value)
        {
            string text;
            switch (value)
            {
                case null:
                    text = "NULL";
                    break;
                case DateTime date:
                    text = date.TimeOfDay == TimeSpan.Zero
                        ? date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                        : date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
                    break;
                case decimal number:
                    text = number.ToString("0.##", CultureInfo.InvariantCulture);
                    break;
                case double number:
                    text = number.ToString("0.##", CultureInfo.InvariantCulture);
                    break;
                case float number:
                    text = number.ToString("0.##", CultureInfo.InvariantCulture);
                    break;
                case IFormattable formattable:
                    text = formattable.ToString(null, CultureInfo.InvariantCulture);
                    break;
                default:
                    text = value.ToString();
                    break;
            }

            text = text.Replace("\r", " ").Replace("\n", " ").Replace("|", "/").Trim();
            return text.Length > MaxCellLength ? text.Substring(0, MaxCellLength) + "…" : text;
        }
    }
}
