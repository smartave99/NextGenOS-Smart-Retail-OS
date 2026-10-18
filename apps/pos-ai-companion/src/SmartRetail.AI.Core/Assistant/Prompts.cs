using System;
using System.Globalization;
using System.Text;
using SmartRetail.AI.Data;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Assistant
{
    public static class Prompts
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

        /// <summary>The chat so far, as a block for the user prompt; nothing for a new chat.</summary>
        /// <summary>The assistant's own plan (projects, tasks, reminders the owner kept), so that advice fits what is already under way.</summary>
        internal static string PlanBlock(string plan) =>
            string.IsNullOrWhiteSpace(plan) ? "" : "What is in the owner's plan now (kept by the owner; do not repeat it back):\n" + plan.TrimEnd() + "\n\n";

        internal static string ConversationBlock(ConversationContext context) =>
            context == null || context.IsEmpty ? "" : context.ToPrompt() + Environment.NewLine;

        public static AiRequest SqlRequest(string schema, string question, DateTime now, int maxRows, string previousSql, string feedback, string memory = "",
            int photos = 0, bool voice = false, ConversationContext context = null)
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
                .AppendLine("- The conversation so far may be given before the question. The question may refer to it (\"yes\", \"that\", \"compare both\", \"and last week?\"): read it as the owner means it, and write the query for what they mean.")
                .AppendLine("- If the question cannot be answered from this data, or is not about the shop's figures (advice, ideas, plans), set \"sql\" to null and say in one short sentence in \"explanation\" what the question is about; it will then be answered as a conversation.")
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

            user.Append(ConversationBlock(context));
            user.Append(Attached(photos, voice));
            user.Append("Question: ").AppendLine(question.Trim().Length > 0 ? question.Trim() : voice ? "(asked by voice)" : "(only the photo: say what it shows and what the shop's data says about it)");
            return new AiRequest { SystemPrompt = system, UserPrompt = user.ToString() };
        }

        /// <summary>A conversation with the owner: advice, ideas, plans, drafts. No query is run, and the shop's figures are not in the prompt.</summary>
        public static AiRequest AdviceRequest(string question, DateTime now, string memory = "", ConversationContext context = null, int photos = 0, ShopProfile shop = null, string plan = "")
        {
            // Who the owner is and where, from the customer's profile (CLAUDE.md section 8): with none, the shop is a small shop and no country is assumed.
            shop = shop ?? ShopProfile.Neutral;
            var system = new StringBuilder()
                .AppendLine("You are the business assistant inside " + Branding.Product + " by " + Branding.Company + ", talking with the owner of " + shop.Shop + ". Help them run, market and grow the business: discuss ideas, compare options, make plans, budgets and checklists, and write messages and advertisement copy.")
                .AppendLine("- The conversation so far is given. Carry on from it: \"yes\", \"that\", \"it\", \"this idea\", \"compare both\" and \"make a plan\" mean what was just discussed. Never ask the owner to repeat what is already in the conversation.")
                .AppendLine("- You have NOT been given the shop's figures in this reply. Never state or invent figures about the shop. If the figures would help, say which ones, and tell the owner they can ask for them (for example: \"How many bills did we make each week this month?\").")
                .AppendLine("- Never invent local prices, reach, impressions or expected sales. Where a number is needed, say it is an estimate, or ask the owner for a quotation. Prefer a small test that can be measured before spending much.")
                .AppendLine("- Sales going up or down after something is not proof that it caused them: say what would show whether it worked.")
                .AppendLine("- Ask a question only when you cannot go on without the answer; otherwise make a sensible assumption, say it, and go on.")
                .AppendLine("- Spending money, printing, publishing, and contacting people are for the owner to decide: propose them, and never say they are done.")
                .AppendLine("- Answer in the language the owner writes in" + (shop.HasLocalLanguage ? " (the owner may mix in " + shop.LocalLanguage + ")" : "") + ". Use the currency and the number style the owner uses in the conversation; if the owner has not shown one, name the currency in words rather than guessing a symbol.")
                .AppendLine("- Simple Markdown is fine (short lists, **bold**, a small table when it helps to compare). Begin your visible answer immediately.")
                .AppendLine("Do not run commands, read files or use tools.")
                .Append(WithMemory(memory))
                .ToString();

            var user = new StringBuilder()
                .Append("Today: ").AppendLine(now.ToString("yyyy-MM-dd (dddd)", CultureInfo.InvariantCulture))
                .Append(PlanBlock(plan))
                .Append(ConversationBlock(context))
                .Append(Attached(photos, voice: false))
                .Append("Owner's new message: ").AppendLine(question.Trim().Length > 0 ? question.Trim() : "(only the photo)")
                .ToString();
            return new AiRequest { SystemPrompt = system, UserPrompt = user };
        }

        public static AiRequest AnswerRequest(string question, string sql, string resultTable, DateTime now, string memory = "", int photos = 0,
            ConversationContext context = null, bool hybrid = false)
        {
            var system = new StringBuilder()
                .AppendLine("You are the business assistant inside " + Branding.Product + " by " + Branding.Company + ". You answer a shop owner's question using only the query result you are given.")
                .AppendLine("- Lead with the direct answer, in a few short sentences or a short list.")
                .AppendLine("- Show money as Indian Rupees with the ₹ sign and Indian digit grouping, for example ₹1,25,000.50.")
                .AppendLine("- Say which period the numbers cover. If the result has no rows, say no matching records were found.")
                .AppendLine("- Never invent numbers that are not in the result. Values shown with * are hidden for privacy; do not guess them.")
                .AppendLine("- Answer in the same language as the question (English, Hindi or Hinglish).")
                .AppendLine("- Simple Markdown is fine where it helps (a short list, **bold** for the key figure); no tables and no code: the app shows the result's table under your answer.")
                .AppendLine("- The conversation so far may be given. The question may refer to it; answer what the owner means, and do not repeat the conversation back.")
                .AppendLine(hybrid
                    ? "- The owner is also asking what the figures mean or what to do. First say what the figures show. Then say what they do NOT show, and give your advice, keeping the two apart. Never state a cause the figures cannot show: fewer bills do not prove fewer visitors, and a rise after an advertisement does not prove the advertisement caused it. Offer a way to test an explanation."
                    : "- Say only what the result shows.")
                .AppendLine("Do not run commands, read files or use tools. Latency-sensitive; begin your visible answer immediately.")
                .Append(WithMemory(memory))
                .ToString();

            var user = new StringBuilder()
                .Append("Today: ").AppendLine(now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
                .Append(ConversationBlock(context))
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
