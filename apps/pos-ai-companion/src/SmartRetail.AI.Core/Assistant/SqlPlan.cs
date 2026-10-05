using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SmartRetail.AI.Assistant
{
    /// <summary>The AI's reply to a question: a query to run, or an explanation of why there is none.</summary>
    internal sealed class SqlPlan
    {
        private static readonly Regex Fence = new Regex(@"```[a-zA-Z]*\s*(.*?)```", RegexOptions.Singleline);
        private static readonly Regex StartsLikeSql = new Regex(@"^\s*(SELECT|WITH)\b", RegexOptions.IgnoreCase);

        public string Sql { get; private set; }

        public string Explanation { get; private set; }

        /// <summary>For a voice question: what the AI heard the owner say.</summary>
        public string Heard { get; private set; }

        public static SqlPlan Parse(string reply)
        {
            var text = (reply ?? "").Trim();
            var start = text.IndexOf('{');
            var end = text.LastIndexOf('}');
            if (start >= 0 && end > start)
            {
                try
                {
                    var json = JObject.Parse(text.Substring(start, end - start + 1));
                    var sql = json["sql"];
                    return new SqlPlan
                    {
                        Sql = sql == null || sql.Type == JTokenType.Null ? null : ((string)sql)?.Trim(),
                        Explanation = ((string)json["explanation"])?.Trim(),
                        Heard = json["heard"]?.Type == JTokenType.String ? ((string)json["heard"])?.Trim() : null,
                    };
                }
                catch (JsonException)
                {
                }
            }

            // Some models ignore the JSON instruction and send a fenced or bare query.
            var fenced = Fence.Match(text);
            var candidate = fenced.Success ? fenced.Groups[1].Value.Trim() : text;
            return StartsLikeSql.IsMatch(candidate)
                ? new SqlPlan { Sql = candidate }
                : new SqlPlan { Explanation = text };
        }
    }
}
