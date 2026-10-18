using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Work
{
    /// <summary>What the AI answered when asked to keep some work: the words for the owner, and the changes it suggests.</summary>
    public sealed class WorkSuggestion
    {
        public string Reply { get; set; } = "";

        public List<WorkChange> Changes { get; } = new List<WorkChange>();

        /// <summary>Suggestions that could not be read (an unknown kind, no title), so the owner is told.</summary>
        public List<string> Unreadable { get; } = new List<string>();

        /// <summary>What to tell the owner: the AI's own words, else a plain sentence that says what there is.</summary>
        public string Words() =>
            !string.IsNullOrWhiteSpace(Reply) ? Reply : Changes.Count > 0 ? "Here is what I suggest putting in your plan." : "I did not find anything to put in your plan.";
    }

    /// <summary>
    /// The one "tool" through which the AI keeps work: it describes the changes it would make in a fixed shape, and the application checks every one
    /// (<see cref="WorkRules"/>) before it is kept. The AI is given no way to run a command, read a file or reach a database from here.
    /// The shape cannot express an action on the shop's database or on anything outside the assistant's own store.
    /// </summary>
    public static class WorkExtraction
    {
        public const int MaxChanges = 12;

        public static AiRequest Request(string question, DateTime now, string memory, string plan, ConversationContext context, ShopProfile shop)
        {
            shop = shop ?? ShopProfile.Neutral;
            var system = new StringBuilder()
                .AppendLine("You are the business assistant inside " + Branding.Product + " by " + Branding.Company + ", helping the owner of " + shop.Shop + " keep track of projects, tasks and reminders.")
                .AppendLine("You do not change the shop's billing, stock or any shop record. You only suggest entries for the assistant's own plan, which the owner can read, change and remove.")
                .AppendLine("Reply with only a JSON object and no markdown:")
                .AppendLine("{\"reply\": \"what to tell the owner, in the owner's language: what you suggest putting in the plan, in plain words\",")
                .AppendLine(" \"changes\": [")
                .AppendLine("   {\"op\": \"add\", \"kind\": \"project\" | \"task\" | \"reminder\" | \"note\" | \"record\", \"title\": \"short, under 100 characters\", \"detail\": \"optional, under 500 characters\", \"project\": \"the title of the project it belongs to (one already in the plan, or one added earlier in this list); empty for none\", \"due\": \"yyyy-mm-dd or empty (for a project: its last day; for a record: the day the number is about)\", \"budget\": a number ONLY when the owner gave that amount, else null, \"starts\": \"yyyy-mm-dd, projects only\", \"channel\": \"how a project reaches people, in the owner's words, projects only\", \"area\": \"where, in the owner's words, projects only\", \"label\": \"records only: footfall | leads | expense | quote | other\", \"amount\": \"records only: the number the owner gave\", \"why\": \"one short reason\"},")
                .AppendLine("   {\"op\": \"update\" | \"complete\" | \"drop\" | \"reopen\", \"item\": \"words from the title of an item already in the plan\", \"title\": \"new title (update only)\", \"detail\": \"\", \"due\": \"\", \"budget\": null, \"starts\": \"\", \"channel\": \"\", \"area\": \"\", \"amount\": null, \"why\": \"\"}]}")
                .AppendLine("Rules:")
                .AppendLine("- At most " + MaxChanges + " changes. When the owner only asks a question about the plan, reply with the answer and \"changes\": [].")
                .AppendLine("- A reminder needs a date. When the owner gave no date and one is needed, say so in \"reply\" and leave the reminder out.")
                .AppendLine("- Never invent a budget, a price, a quotation, a reach or a result. A budget is only an amount the owner said; a task may say \"get a quotation\" instead of a cost.")
                .AppendLine("- Never say that something was printed, paid for, published or sent. You only suggest entries; the owner does the rest.")
                .AppendLine("- A \"record\" is a number the OWNER told you in this conversation: a quotation, an amount spent, how many people were counted, how many enquiries came. Never estimate, guess or work one out. When the owner gave no number, do not add a record; ask for it in \"reply\".")
                .AppendLine("- Numbers in the plan marked \"entered by the owner\" are not the shop's figures from the POS. Never present them as sales, bills or stock.")
                .AppendLine("- Do not repeat what is already in the plan. Do not put customer names, phone numbers or e-mail addresses in the plan.")
                .AppendLine("- Dates: today is given. Use real dates, never \"next week\".")
                .Append(Prompts.WithMemory(memory))
                .ToString();

            var user = new StringBuilder()
                .Append("Today: ").AppendLine(now.ToString("yyyy-MM-dd (dddd)", CultureInfo.InvariantCulture))
                .AppendLine("What is in the plan now:")
                .AppendLine(string.IsNullOrWhiteSpace(plan) ? "(nothing yet)" : plan.TrimEnd())
                .AppendLine()
                .Append(Prompts.ConversationBlock(context))
                .Append("Owner's new message: ").AppendLine((question ?? "").Trim())
                .ToString();
            return new AiRequest { SystemPrompt = system, UserPrompt = user };
        }

        /// <summary>The reply and the changes in the AI's answer, in the shape asked for; anything else is left out and named.</summary>
        public static WorkSuggestion Parse(string answer, DateTime now)
        {
            var suggestion = new WorkSuggestion();
            var json = JsonObjectIn(answer);
            if (json == null)
            {
                // Not in the shape asked for: the words are still an answer for the owner, and nothing is kept.
                suggestion.Reply = (answer ?? "").Trim();
                return suggestion;
            }

            suggestion.Reply = Cut(((string)json["reply"] ?? "").Trim(), 4000);
            foreach (var item in (json["changes"] as JArray ?? new JArray()).OfType<JObject>())
            {
                if (suggestion.Changes.Count == MaxChanges)
                {
                    suggestion.Unreadable.Add("More than " + MaxChanges + " changes were suggested; the rest were left out.");
                    break;
                }

                var op = ((string)item["op"] ?? "").Trim().ToLowerInvariant();
                var change = new WorkChange { Why = Cut(((string)item["why"] ?? "").Trim(), 200) };
                switch (op)
                {
                    case "add":
                        var kind = ((string)item["kind"] ?? "").Trim().ToLowerInvariant();
                        if (!TryKind(kind, out var workKind))
                        {
                            suggestion.Unreadable.Add("An entry of an unknown kind (“" + Cut(kind, 20) + "”) was left out.");
                            continue;
                        }

                        change.Op = WorkOp.Add;
                        change.Item = new WorkItem
                        {
                            Kind = workKind,
                            Title = Cut((string)item["title"], WorkRules.TitleLimit + 1),
                            Detail = Cut((string)item["detail"], WorkRules.DetailLimit + 1),
                            ProjectName = Cut(((string)item["project"] ?? "").Trim(), WorkRules.TitleLimit),
                            Due = Day((string)item["due"]) ?? Day((string)item["date"]),
                            Budget = Amount(item["budget"]),
                            Starts = Day((string)item["starts"]),
                            Channel = Cut(((string)item["channel"] ?? "").Trim(), WorkRules.ChannelLimit + 1),
                            Area = Cut(((string)item["area"] ?? "").Trim(), WorkRules.ChannelLimit + 1),
                            Label = workKind == WorkKind.Record ? Cut(((string)item["label"] ?? "").Trim().ToLowerInvariant(), 20) : "",
                            Amount = workKind == WorkKind.Record ? Amount(item["amount"]) : null,
                            Source = "Chat",
                        };
                        break;
                    case "update":
                    case "complete":
                    case "drop":
                    case "reopen":
                        change.Op = op == "update" ? WorkOp.Update : op == "complete" ? WorkOp.Complete : op == "drop" ? WorkOp.Drop : WorkOp.Reopen;
                        change.ItemWords = Cut(((string)item["item"] ?? "").Trim(), WorkRules.TitleLimit);
                        change.Item = new WorkItem
                        {
                            Title = Cut((string)item["title"], WorkRules.TitleLimit + 1),
                            Detail = Cut((string)item["detail"], WorkRules.DetailLimit + 1),
                            Due = Day((string)item["due"]),
                            Budget = Amount(item["budget"]),
                            Starts = Day((string)item["starts"]),
                            Channel = Cut(((string)item["channel"] ?? "").Trim(), WorkRules.ChannelLimit + 1),
                            Area = Cut(((string)item["area"] ?? "").Trim(), WorkRules.ChannelLimit + 1),
                            Amount = Amount(item["amount"]),
                        };
                        break;
                    default:
                        suggestion.Unreadable.Add("An entry of an unknown kind of change (“" + Cut(op, 20) + "”) was left out.");
                        continue;
                }

                suggestion.Changes.Add(change);
            }

            return suggestion;
        }

        /// <summary>A plain note for the end of the answer: what was kept, what waits for the owner, and what was left out.</summary>
        public static string Note(WorkProposal proposal, bool askedFirst, IReadOnlyList<string> unreadable)
        {
            var text = new StringBuilder();
            if (proposal != null && proposal.Changes.Count > 0)
            {
                text.AppendLine().AppendLine();
                text.AppendLine(askedFirst
                    ? "**Waiting for your OK** (nothing is saved yet). Open “Plan & tasks” to save or turn down:"
                    : "**Saved to your plan:**");
                foreach (var change in proposal.Changes)
                {
                    text.AppendLine("- " + Line(change));
                }
            }

            var left = (proposal?.LeftOut ?? new List<string>()).Concat(unreadable ?? new string[0]).ToList();
            if (left.Count > 0)
            {
                text.AppendLine().AppendLine("Not added:");
                foreach (var why in left)
                {
                    text.AppendLine("- " + why);
                }
            }

            return text.ToString().TrimEnd();
        }

        /// <summary>One change in a line: "Add task: Get three quotations (due 20 Oct)".</summary>
        public static string Line(WorkChange change)
        {
            var due = change.Item?.Due;
            var tail = due.HasValue ? " (due " + due.Value.ToString("d MMM", CultureInfo.InvariantCulture) + ")" : "";
            switch (change.Op)
            {
                case WorkOp.Add:
                    if (change.Item?.Kind == WorkKind.Record)
                    {
                        return "Add a number you gave (" + RecordLabels.Name(change.Item.Label).ToLowerInvariant() + (change.Item.Amount.HasValue ? ": " + change.Item.Amount.Value.ToString("0.##", CultureInfo.InvariantCulture) : "")
                            + (due.HasValue ? ", on " + due.Value.ToString("d MMM", CultureInfo.InvariantCulture) : "") + "): " + change.Item.Title;
                    }

                    return "Add " + (change.Item?.Kind.ToString().ToLowerInvariant() ?? "item") + ": " + change.Item?.Title + tail;
                case WorkOp.Update:
                    return "Change “" + change.ItemWords + "”" + (string.IsNullOrWhiteSpace(change.Item?.Title) ? "" : " to “" + change.Item.Title + "”") + tail;
                case WorkOp.Complete:
                    return "Mark done: " + change.ItemWords;
                case WorkOp.Drop:
                    return "Drop: " + change.ItemWords;
                default:
                    return "Reopen: " + change.ItemWords;
            }
        }

        private static bool TryKind(string text, out WorkKind kind)
        {
            switch (text)
            {
                case "project": kind = WorkKind.Project; return true;
                case "task": kind = WorkKind.Task; return true;
                case "reminder": kind = WorkKind.Reminder; return true;
                case "note": kind = WorkKind.Note; return true;
                case "record": kind = WorkKind.Record; return true;
                default: kind = WorkKind.Task; return false;
            }
        }

        private static DateTime? Day(string text) =>
            DateTime.TryParseExact((text ?? "").Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var day) ? day : (DateTime?)null;

        private static decimal? Amount(JToken token)
        {
            if (token == null || token.Type == JTokenType.Null)
            {
                return null;
            }

            if (token.Type == JTokenType.Integer || token.Type == JTokenType.Float)
            {
                return (decimal)token;
            }

            return decimal.TryParse(((string)token ?? "").Replace(",", ""), NumberStyles.Number, CultureInfo.InvariantCulture, out var amount) ? amount : (decimal?)null;
        }

        private static JObject JsonObjectIn(string answer)
        {
            if (string.IsNullOrWhiteSpace(answer))
            {
                return null;
            }

            var start = answer.IndexOf('{');
            var end = answer.LastIndexOf('}');
            if (start < 0 || end <= start)
            {
                return null;
            }

            try
            {
                return JObject.Parse(answer.Substring(start, end - start + 1));
            }
            catch (JsonException)
            {
                return null;
            }
        }

        private static string Cut(string text, int max) =>
            string.IsNullOrEmpty(text) ? "" : text.Length <= max ? text : text.Substring(0, max);
    }
}
