using System;
using System.Globalization;
using System.Text;
using SmartRetail.AI.Data;
using SmartRetail.AI.Providers;

namespace SmartRetail.AI.Assistant
{
    internal static class Prompts
    {
        /// <summary>The memory snapshot after a blank line, or nothing when memory is empty.</summary>
        internal static string WithMemory(string memory) =>
            string.IsNullOrWhiteSpace(memory) ? "" : Environment.NewLine + memory.Trim() + Environment.NewLine;

        /// <summary>What to tell the AI about photos and a voice note sent with the question; empty without them.</summary>
        internal static string Attached(int photos, bool voice)
        {
            var text = new StringBuilder();
            if (photos > 0)
            {
                text.AppendLine("The owner sent " + (photos == 1 ? "a photo" : photos + " photos") + " with the question (attached to this message). Look at "
                    + (photos == 1 ? "it" : "them") + ": " + (photos == 1 ? "it" : "they") + " may show a product, a shelf, a bill or a note. Use what you can read in "
                    + (photos == 1 ? "it" : "them") + ", such as a product's name, brand or size, and never guess what you cannot read.");
            }

            if (voice)
            {
                text.AppendLine("The owner asked by voice (a recording is attached): listen to it. What they said is the question.");
            }

            return text.ToString();
        }

        public static AiRequest SqlRequest(string schema, string question, DateTime now, int maxRows, string previousSql, string feedback, string memory = "",
            int photos = 0, bool voice = false)
        {
            var today = now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            var weekday = now.ToString("dddd", CultureInfo.InvariantCulture);
            var system = new StringBuilder()
                .AppendLine("You are the data analyst inside " + Branding.Product + " by " + Branding.Company + ", a billing and inventory system used by a retail shop in India.")
                .AppendLine("Turn the shop owner's question into ONE read-only Microsoft SQL Server query (T-SQL, SQL Server 2017) over the tables described below.")
                .AppendLine()
                .AppendLine("Rules:")
                .AppendLine("- A single SELECT statement; common table expressions (WITH) are fine. Never change data.")
                .AppendLine("- Use only the tables and columns listed. No system views, variables, temporary tables or other databases.")
                .AppendLine("- Refer to columns as alias.column; never use database- or schema-qualified column names.")
                .AppendLine("- Wrap text columns in RTRIM() when you show, group or compare them.")
                .AppendLine("- For a single day compare CAST(date_column AS date). Today is " + today + " (" + weekday + ").")
                .AppendLine("- Return at most " + maxRows + " rows (use TOP) and prefer totals or grouped results over raw rows.")
                .AppendLine("- Give result columns short, readable names.")
                .AppendLine("- If the question cannot be answered from this data, or is not about the shop, set \"sql\" to null and explain why in \"explanation\".")
                .AppendLine()
                .AppendLine(voice
                    ? "Reply with only a JSON object and no markdown: {\"sql\": \"...\", \"explanation\": \"one short sentence\", \"heard\": \"what the owner said, in their words and language\"}"
                    : "Reply with only a JSON object and no markdown: {\"sql\": \"...\", \"explanation\": \"one short sentence\"}")
                .AppendLine("Do not run commands, read files or use tools.")
                .Append(WithMemory(memory))
                .ToString();

            var user = new StringBuilder()
                .AppendLine("Database tables:")
                .AppendLine(schema.Trim())
                .AppendLine()
                .AppendLine("How the shop uses these tables:")
                .AppendLine(SchemaCatalog.BusinessNotes)
                .AppendLine();
            if (feedback != null)
            {
                user.AppendLine("Your previous query:")
                    .AppendLine(previousSql)
                    .AppendLine("It could not be used: " + feedback)
                    .AppendLine("Write a corrected query.")
                    .AppendLine();
            }

            user.Append(Attached(photos, voice));
            user.Append("Question: ").AppendLine(question.Trim().Length > 0 ? question.Trim() : voice ? "(asked by voice)" : "(only the photo: say what it shows and what the shop's data says about it)");
            return new AiRequest { SystemPrompt = system, UserPrompt = user.ToString() };
        }

        public static AiRequest AnswerRequest(string question, string sql, string resultTable, DateTime now, string memory = "", int photos = 0)
        {
            var system = new StringBuilder()
                .AppendLine("You are the business assistant inside " + Branding.Product + " by " + Branding.Company + ". You answer a shop owner's question using only the query result you are given.")
                .AppendLine("- Lead with the direct answer, in a few short sentences or a short list.")
                .AppendLine("- Show money as Indian Rupees with the ₹ sign and Indian digit grouping, for example ₹1,25,000.50.")
                .AppendLine("- Say which period the numbers cover. If the result has no rows, say no matching records were found.")
                .AppendLine("- Never invent numbers that are not in the result. Values shown with * are hidden for privacy; do not guess them.")
                .AppendLine("- Answer in the same language as the question (English, Hindi or Hinglish).")
                .AppendLine("- Simple Markdown is fine where it helps (a short list, **bold** for the key figure); no tables and no code: the app shows the result's table under your answer.")
                .AppendLine("Do not run commands, read files or use tools. Latency-sensitive; begin your visible answer immediately.")
                .Append(WithMemory(memory))
                .ToString();

            var user = new StringBuilder()
                .Append("Today: ").AppendLine(now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
                .Append(Attached(photos, voice: false))
                .Append("Question: ").AppendLine(question.Trim().Length > 0 ? question.Trim() : "(only the photo)")
                .AppendLine()
                .AppendLine("SQL that produced the result:")
                .AppendLine(sql.Trim())
                .AppendLine()
                .AppendLine("Result:")
                .Append(resultTable)
                .ToString();
            return new AiRequest { SystemPrompt = system, UserPrompt = user };
        }
    }
}
