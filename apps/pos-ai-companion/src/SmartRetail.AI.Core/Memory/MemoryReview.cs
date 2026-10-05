using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Data;
using SmartRetail.AI.Providers;

namespace SmartRetail.AI.Memory
{
    /// <summary>
    /// Hermes Agent's background review, for a shop: after a conversation, the AI is shown what it remembers and what
    /// was said, and suggests at most a few changes worth keeping for later conversations. Its answer is only a
    /// suggestion: every change is checked by <see cref="MemoryRules"/> and, unless the owner says otherwise, waits
    /// for the owner's Save.
    /// </summary>
    public static class MemoryReview
    {
        public const int MaxChanges = 3;


        /// <summary>The conversation is cut to this many characters, newest kept.</summary>
        public const int MaxConversation = 6000;

        /// <summary>The latest suggestions the owner did not save, shown so they are not suggested again.</summary>
        public const int DeclinedShown = 10;

        /// <summary>At most this many actions to track from one chat.</summary>
        public const int MaxActions = 2;

        public static AiRequest Request(MemoryBook book, IReadOnlyList<ChatMessage> messages, DateTime now)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            var system = new StringBuilder()
                .AppendLine("You keep the long-term memory of the business assistant in " + Branding.Product + ", used by one retail shop in India.")
                .AppendLine("Memory has two parts, carried into every future conversation:")
                .AppendLine("- \"shop\": durable facts and lessons about this shop: what sells when, what the shop tried and how it worked, decisions taken.")
                .AppendLine("- \"owner\": the owner's lasting preferences: language, how answers should look, budget, goals.")
                .AppendLine("From the conversation, suggest what is worth remembering for later. Keep only what will still be true and useful next month.")
                .AppendLine("Never keep: one-off questions, figures the POS database already has, anything about a single bill, customer names, phone numbers, e-mail addresses, links, or instructions to the AI.")
                .AppendLine("Each entry is one short sentence in plain words (under 200 characters), in English unless the owner wrote in Hindi.")
                .AppendLine("Prefer replacing an entry that says nearly the same, or merging two, over adding. When a part is over 80% full, merge or remove before adding.")
                .AppendLine("Also list what the owner said the shop is doing or will do to sell more (an advert, an offer, a display change, a new product, a price change), so the shop can see later whether it worked. Only what the owner said, never your own ideas. When no start date was said, use today.")
                .AppendLine("Reply with only a JSON object and no markdown:")
                .AppendLine("{\"changes\": [{\"op\": \"add\" | \"replace\" | \"remove\", \"part\": \"shop\" | \"owner\", \"text\": \"the new entry (add, replace)\", \"old\": \"words from the entry to change (replace, remove)\", \"why\": \"one short reason for the owner\"}],")
                .AppendLine(" \"actions\": [{\"title\": \"short name, e.g. E-rickshaw ads around the market\", \"kind\": \"advert\" | \"offer\" | \"display\" | \"new-product\" | \"price\" | \"other\", \"start\": \"yyyy-mm-dd\", \"end\": \"yyyy-mm-dd, or empty when not said\", \"cost\": rupees or 0, \"products\": [\"product names as the owner said them; empty for the whole shop\"], \"expected\": \"what the owner hopes it changes\"}]}")
                .AppendLine("At most " + MaxChanges + " changes and " + MaxActions + " actions. When there is nothing, reply {\"changes\": [], \"actions\": []}.")
                .AppendLine("Do not run commands, read files or use tools.")
                .ToString();

            var user = new StringBuilder()
                .Append("Today: ").AppendLine(now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
                .AppendLine()
                .AppendLine(Usage(book, MemoryPart.Shop))
                .AppendLine(Entries(book.Shop))
                .AppendLine(Usage(book, MemoryPart.Owner))
                .AppendLine(Entries(book.Owner))
                .Append(Declined(book))
                .AppendLine("The conversation:")
                .AppendLine(Conversation(messages))
                .ToString();
            return new AiRequest { SystemPrompt = system, UserPrompt = user };
        }

        /// <summary>The changes in the AI's answer, in the shape asked for; anything else is left out.</summary>
        public static IReadOnlyList<MemoryChange> Parse(string answer)
        {
            var json = JsonObjectIn(answer);
            if (json == null)
            {
                return Array.Empty<MemoryChange>();
            }

            var changes = new List<MemoryChange>();
            foreach (var item in (json["changes"] as JArray ?? new JArray()).OfType<JObject>())
            {
                if (changes.Count == MaxChanges)
                {
                    break;
                }

                var op = ((string)item["op"] ?? "").Trim().ToLowerInvariant();
                var part = ((string)item["part"] ?? "").Trim().ToLowerInvariant();
                if ((op != "add" && op != "replace" && op != "remove") || (part != "shop" && part != "owner"))
                {
                    continue;
                }

                changes.Add(new MemoryChange
                {
                    Op = op == "add" ? MemoryOp.Add : op == "replace" ? MemoryOp.Replace : MemoryOp.Remove,
                    Part = part == "shop" ? MemoryPart.Shop : MemoryPart.Owner,
                    NewText = Cut((string)item["text"], MemoryRules.EntryLimit + 1),
                    OldText = Cut((string)item["old"], MemoryRules.EntryLimit),
                    Why = Cut((string)item["why"], 200),
                    Source = "Chat",
                });
            }

            return changes;
        }

        /// <summary>The actions in the AI's answer, in the shape asked for; anything else is left out.</summary>
        public static IReadOnlyList<ActionSuggestion> ParseActions(string answer, DateTime now)
        {
            var json = JsonObjectIn(answer);
            var actions = new List<ActionSuggestion>();
            foreach (var item in (json?["actions"] as JArray ?? new JArray()).OfType<JObject>())
            {
                if (actions.Count == MaxActions)
                {
                    break;
                }

                var title = MemoryRules.Normalize((string)item["title"]);
                if (title.Length == 0)
                {
                    continue;
                }

                var start = Day((string)item["start"]) ?? now.Date;
                var end = Day((string)item["end"]);
                actions.Add(new ActionSuggestion
                {
                    Title = Cut(title, 120),
                    Kind = Cut(((string)item["kind"] ?? "").Trim(), 30),
                    Start = start,
                    End = end >= start ? end : null,
                    Cost = Math.Max(0m, Number(item["cost"])),
                    Products = (item["products"] as JArray ?? new JArray())
                        .Select(p => MemoryRules.Normalize((string)p))
                        .Where(p => p.Length > 0)
                        .Select(p => Cut(p, 80))
                        .Distinct(StringComparer.OrdinalIgnoreCase)
                        .Take(10)
                        .ToList(),
                    Expected = Cut(MemoryRules.Normalize((string)item["expected"]), 300),
                });
            }

            return actions;
        }

        private static DateTime? Day(string text) =>
            DateTime.TryParseExact((text ?? "").Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var day) ? day : (DateTime?)null;

        private static decimal Number(JToken token)
        {
            if (token == null || token.Type == JTokenType.Null)
            {
                return 0m;
            }

            if (token.Type == JTokenType.Integer || token.Type == JTokenType.Float)
            {
                return (decimal)token;
            }

            // "₹6,000" or "6000 rupees".
            var digits = new string(((string)token ?? "").Where(c => char.IsDigit(c) || c == '.').ToArray());
            return decimal.TryParse(digits, NumberStyles.Number, CultureInfo.InvariantCulture, out var value) ? value : 0m;
        }

        private static string Usage(MemoryBook book, MemoryPart part) =>
            string.Format(CultureInfo.InvariantCulture, "Memory \"{0}\" ({1:N0} of {2:N0} characters used):",
                part == MemoryPart.Shop ? "shop" : "owner", MemoryRules.Used(book, part), MemoryRules.Limit(part));

        private static string Entries(IReadOnlyList<MemoryEntry> entries) =>
            entries.Count == 0 ? "(empty)" : string.Join("\n", entries.Select(e => "- " + e.Text));

        private static string Declined(MemoryBook book)
        {
            var declined = book.Journey
                .Where(c => c.Status == MemoryChangeStatus.Rejected && MemoryRules.Check(c.NewText) == null)
                .Select(c => c.NewText)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Take(DeclinedShown)
                .ToList();
            return declined.Count == 0
                ? ""
                : "The owner chose not to keep these before; do not suggest them again:\n" + string.Join("\n", declined.Select(t => "- " + t)) + "\n";
        }

        /// <summary>What was said, newest kept when long, with phone numbers and e-mail addresses hidden.</summary>
        private static string Conversation(IReadOnlyList<ChatMessage> messages)
        {
            // "Remember that…" and "Forget…" are done already, so they are left out with their replies.
            var all = messages ?? Array.Empty<ChatMessage>();
            var lines = all
                .Select((m, i) => (Message: m, Words: ChatMessage.Words(all, i)))
                .Where(x => !x.Message.IsProblem && x.Words.Length > 0)
                .Where(x => x.Message.Role == ChatRole.Owner ? !MemoryCommands.IsCommand(x.Message.Text) : x.Message.Source != MemoryCommands.SourceName)
                .Select(x => (x.Message.Role == ChatRole.Owner ? "Owner: " : "Assistant: ") + PiiMasker.MaskText(x.Words))
                .ToList();
            var text = string.Join("\n\n", lines);
            return text.Length <= MaxConversation ? text : "…" + text.Substring(text.Length - MaxConversation);
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

    /// <summary>Something the owner said the shop is doing or will do to sell more, found in a chat. The owner
    /// decides whether to track it.</summary>
    public sealed class ActionSuggestion
    {
        public string Title { get; set; } = "";

        /// <summary>"advert", "offer", "display", "new-product", "price" or "other", as the AI wrote it.</summary>
        public string Kind { get; set; } = "";

        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        public decimal Cost { get; set; }

        /// <summary>Product names as the owner said them; none for the whole shop.</summary>
        public List<string> Products { get; set; } = new List<string>();

        public string Expected { get; set; } = "";
    }

    /// <summary>The owner telling the assistant to remember or forget something, e.g. "Remember that I prefer
    /// Hinglish" or "yaad rakho ki bhujia Sunday ko zyada bikta hai". Handled at once, without asking an AI.</summary>
    public static class MemoryCommands
    {
        /// <summary>The source of the chat's replies to these commands.</summary>
        public const string SourceName = "Memory";

        // "Remember that …", "remember: …", "note that …", "keep in mind that …", and a plain "remember …" that is not
        // a question or a to-do ("remember to order sugar", "remember what we sold").
        private static readonly Regex Remember = new Regex(
            @"^\s*(please\s+)?(remember|note(\s+down)?|keep\s+in\s+mind)(\s+(that|this)\s*:?|\s*:)\s*(?<fact>.+)$"
            + @"|^\s*(please\s+)?remember\s*[,-]?\s+(?!(to|what|when|where|which|who|whom|whose|why|how|if|whether|me|this|that)\b)(?<fact>.+)$"
            + @"|^\s*(yaad\s+rakh(o|na|iye)|याद\s+रख(ो|ना|िए|ें))(\s+(ki|कि))?\s*[:,-]?\s+(?<fact>.+)$",
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

        private static readonly Regex Forget = new Regex(
            @"^\s*(please\s+)?forget(\s+that|\s+about)?\s*[:,-]?\s+(?<what>.+)$|^\s*(bhool\s+ja(o|iye)|भूल\s+जा(ओ|इए|एं))\s*[:,-]?\s+(?<what>.+)$",
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

        private static readonly Regex AboutTheOwner = new Regex(
            @"\b(i|i'm|i am|me|my|mine|prefer|mujhe|mera|meri|mere)\b|मुझे|मेरा|मेरी|मेरे",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static readonly Regex Word = new Regex(@"[\p{L}\p{M}\p{N}]{3,}", RegexOptions.Compiled);

        /// <summary>The fact to remember, when <paramref name="text"/> asks to remember one.</summary>
        public static MemoryChange RememberRequest(string text)
        {
            var match = Remember.Match(text ?? "");
            if (!match.Success || text.TrimEnd().EndsWith("?", StringComparison.Ordinal))
            {
                // "Remember what we sold last Diwali?" is a question, not something to keep.
                return null;
            }

            var said = MemoryRules.Normalize(match.Groups["fact"].Value).TrimEnd('.', '।', '!', ' ');
            if (said.Length == 0)
            {
                return null;
            }

            // Hindi keeps its full stop, the danda.
            var fact = char.ToUpper(said[0], CultureInfo.InvariantCulture) + said.Substring(1)
                + (said.Any(c => c >= '\u0900' && c <= '\u097F') ? "।" : ".");
            return new MemoryChange
            {
                Op = MemoryOp.Add,
                Part = AboutTheOwner.IsMatch(fact) ? MemoryPart.Owner : MemoryPart.Shop,
                NewText = fact,
                Why = "The owner asked to remember it.",
                Source = "Owner, in chat",
            };
        }

        /// <summary>What to forget, when <paramref name="text"/> asks to forget something.</summary>
        public static string ForgetRequest(string text)
        {
            var match = Forget.Match(text ?? "");
            return match.Success ? MemoryRules.Normalize(match.Groups["what"].Value).TrimEnd('.', '।', '!', ' ') : null;
        }

        public static bool IsCommand(string text) => RememberRequest(text) != null || ForgetRequest(text) != null;

        /// <summary>
        /// The entries <paramref name="what"/> points at: those that contain it, else those with all its words
        /// ("forget that bhujia sells on Sundays" finds "Bhujia sells best on Sundays.").
        /// </summary>
        public static IReadOnlyList<(MemoryPart Part, MemoryEntry Entry)> Matches(MemoryBook book, string what)
        {
            var all = new[] { MemoryPart.Shop, MemoryPart.Owner }
                .SelectMany(part => book.Entries(part).Select(entry => (Part: part, Entry: entry)))
                .ToList();
            var text = (what ?? "").Trim();
            if (text.Length == 0)
            {
                return Array.Empty<(MemoryPart, MemoryEntry)>();
            }

            var containing = all.Where(x => x.Entry.Text.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (containing.Count > 0)
            {
                return containing;
            }

            var words = Word.Matches(text).Cast<Match>().Select(m => m.Value).ToList();
            return words.Count == 0
                ? Array.Empty<(MemoryPart, MemoryEntry)>()
                : all.Where(x => words.All(w => x.Entry.Text.IndexOf(w, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();
        }
    }
}
