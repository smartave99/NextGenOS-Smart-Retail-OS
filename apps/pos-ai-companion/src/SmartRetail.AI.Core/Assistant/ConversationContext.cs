using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SmartRetail.AI.Assistant
{
    /// <summary>One earlier message as the AI is shown it.</summary>
    public sealed class ContextTurn
    {
        public ContextTurn(ChatRole role, string text, bool unanswered = false, RequestKind? route = null)
        {
            Role = role;
            Text = text ?? "";
            Unanswered = unanswered;
            Route = route;
        }

        /// <summary>For an answer: where it came from (the shop's figures, or a conversation), so that a following "yes" goes the same way.</summary>
        public RequestKind? Route { get; }

        public ChatRole Role { get; }

        public string Text { get; }

        /// <summary>For an owner's message: no usable answer came (the AI tool failed, or the owner pressed Stop).</summary>
        public bool Unanswered { get; }
    }

    /// <summary>How much of a chat is put into each prompt. The numbers are characters, not tokens (a token is about
    /// four characters of English, fewer of Hindi), kept well under what every provider takes.</summary>
    public sealed class ContextBudget
    {
        /// <summary>The whole conversation block: the summary, the recent messages and what was recalled.</summary>
        public int MaxChars { get; set; } = 12000;

        /// <summary>The recent messages, word for word.</summary>
        public int MaxRecentChars { get; set; } = 8000;

        public int MaxRecentTurns { get; set; } = 16;

        public int MaxOwnerTurnChars { get; set; } = 800;

        public int MaxAssistantTurnChars { get; set; } = 1500;

        /// <summary>Older messages, said in short.</summary>
        public int MaxSummaryChars { get; set; } = 2400;

        /// <summary>What is recalled from earlier chats, when the owner asks for it.</summary>
        public int MaxRecalledChars { get; set; } = 1200;

        public static ContextBudget Default => new ContextBudget();
    }

    /// <summary>What went into one prompt, in numbers and never in words, so a lost context can be found in a log
    /// without a customer's details or the owner's questions being written down.</summary>
    public sealed class ContextReport
    {
        public string ChatKey { get; set; } = "";

        public int TurnsShown { get; set; }

        /// <summary>Older messages that are in the summary only.</summary>
        public int TurnsSummarized { get; set; }

        public int Characters { get; set; }

        public bool HasSummary { get; set; }

        public bool HasRecalled { get; set; }

        public bool LastQuestionUnanswered { get; set; }

        public override string ToString() =>
            "chat " + ChatKey + ": " + TurnsShown + " messages shown, " + TurnsSummarized + " summarized, " + Characters + " characters"
            + (HasRecalled ? ", recalled from an earlier chat" : "") + (LastQuestionUnanswered ? ", the last question had no answer" : "");
    }

    /// <summary>
    /// What the AI is told about the chat so far, with each question. The AI tools keep no chat of their own (Codex runs
    /// without saving a session, and that is how it stays private), so the application keeps the chat and puts what
    /// matters into every prompt: the recent messages word for word, the older ones in a short summary, and, when the
    /// owner asks for it, a few words from an earlier chat. Built by <see cref="ConversationContextBuilder"/>.
    /// </summary>
    public sealed class ConversationContext
    {
        public static readonly ConversationContext Empty = new ConversationContext("", "", "", "", new ContextTurn[0], 0);

        public ConversationContext(string chatKey, string summary, string topic, string recalled, IReadOnlyList<ContextTurn> recent, int turnsSummarized)
        {
            ChatKey = chatKey ?? "";
            Summary = summary ?? "";
            Topic = topic ?? "";
            Recalled = recalled ?? "";
            Recent = recent ?? new ContextTurn[0];
            TurnsSummarized = turnsSummarized;
        }

        public string ChatKey { get; }

        /// <summary>The older messages, said in short; empty while the whole chat fits.</summary>
        public string Summary { get; }

        /// <summary>What the owner was talking about before the new message: the last thing they said that was not only
        /// "yes" or "continue".</summary>
        public string Topic { get; }

        /// <summary>Words from earlier chats, only when the owner asked to go back to them.</summary>
        public string Recalled { get; }

        /// <summary>The recent messages, oldest first, without the new one.</summary>
        public IReadOnlyList<ContextTurn> Recent { get; }

        public int TurnsSummarized { get; }

        public bool IsEmpty => Recent.Count == 0 && Summary.Length == 0 && Recalled.Length == 0;

        /// <summary>Where the last answer in the chat came from; null when the chat has none.</summary>
        public RequestKind? LastAnswerRoute
        {
            get
            {
                for (var i = Recent.Count - 1; i >= 0; i--)
                {
                    if (Recent[i].Role == ChatRole.Assistant)
                    {
                        return Recent[i].Route;
                    }
                }

                return null;
            }
        }

        /// <summary>The owner's last message before the new one got no usable answer.</summary>
        public bool LastQuestionUnanswered => Recent.Count > 0 && Recent[Recent.Count - 1].Role == ChatRole.Owner && Recent[Recent.Count - 1].Unanswered;

        /// <summary>The block that goes into a prompt, before the new question; empty for a new chat.</summary>
        public string ToPrompt()
        {
            if (IsEmpty)
            {
                return "";
            }

            var text = new StringBuilder();
            text.AppendLine("Conversation so far, in this chat only. Use it to understand what the owner means by \"it\", \"that\", \"this idea\", \"yes\", \"continue\", \"compare both\" or \"make a plan\", and carry on from it. Do not repeat it back.");
            if (Summary.Length > 0)
            {
                text.AppendLine("Earlier in this chat, in short:");
                text.AppendLine(Summary);
            }

            if (Recalled.Length > 0)
            {
                text.AppendLine("From an earlier chat, which the owner asked to go back to:");
                text.AppendLine(Recalled);
            }

            foreach (var turn in Recent)
            {
                text.Append(turn.Role == ChatRole.Owner ? "Owner: " : "You: ").AppendLine(turn.Text);
            }

            if (LastQuestionUnanswered)
            {
                text.AppendLine("(The owner's message above got no answer: the AI tool failed or the owner stopped it. Answer it together with the new message.)");
            }

            if (Topic.Length > 0)
            {
                text.AppendLine("Before the new message the owner was talking about: " + Topic);
            }

            return text.ToString();
        }

        public ContextReport Report() => new ContextReport
        {
            ChatKey = ChatKey,
            TurnsShown = Recent.Count,
            TurnsSummarized = TurnsSummarized,
            Characters = ToPrompt().Length,
            HasSummary = Summary.Length > 0,
            HasRecalled = Recalled.Length > 0,
            LastQuestionUnanswered = LastQuestionUnanswered,
        };
    }

    /// <summary>What the chat backend is asked: the question, what came with it, and the chat so far.</summary>
    public sealed class AskRequest
    {
        public string Question { get; set; } = "";

        public IReadOnlyList<ChatAttachment> Attachments { get; set; } = new ChatAttachment[0];

        public ConversationContext Context { get; set; } = ConversationContext.Empty;
    }

    /// <summary>A backend that is given the chat so far with each question, so a follow-up such as "yes, tell me" can be
    /// understood. A backend without it is asked the question alone, as before.</summary>
    public interface IContextChat
    {
        System.Threading.Tasks.Task<ChatMessage> AskAsync(AskRequest request, IProgress<string> progress, System.Threading.CancellationToken cancellationToken);
    }

    /// <summary>The short replies that only carry on ("yes", "go on", "tell me more", "compare both"), in English, and in the customer's own language when its profile has words for it.</summary>
    public static class Continuations
    {
        private static readonly string[] Words =
        {
            "yes", "yeah", "yep", "yup", "ok", "okay", "sure", "right", "correct", "fine", "go ahead", "go on", "carry on", "continue", "proceed", "next",
            "tell me", "tell me more", "tell me then", "yes tell me", "yes please", "please", "more", "explain", "explain more", "explain it", "say more", "elaborate", "details",
            "both", "compare both", "compare them", "that one", "this one", "do it", "do that", "why", "how", "and", "then", "so",
            "try again", "please try again", "retry", "again", "once more", "one more time",
        };

        private static readonly char[] Trim = { ' ', '.', '!', '?', ',', ';', ':', '-', '"', '\'', '“', '”', '‘', '’', '\t', '\r', '\n' };

        /// <summary>True for a message that has nothing of its own to say and only goes on with the chat.</summary>
        /// <param name="words">What the customer's profile adds to the English words; null for English only.</param>
        public static bool IsOnlyContinuing(string message, ChatVocabulary words = null)
        {
            // Punctuation inside the message ("Yes, tell me") counts as a space, so that it is the same as "yes tell me".
            var text = new string((message ?? "").ToLowerInvariant().Select(c => Array.IndexOf(Trim, c) >= 0 ? ' ' : c).ToArray());
            text = string.Join(" ", text.Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
            return text.Length > 0 && (Words.Contains(text, StringComparer.Ordinal) || (words != null && words.IsContinuation(text)));
        }
    }

    /// <summary>Makes the <see cref="ConversationContext"/> for a new message from the messages so far.</summary>
    public static class ConversationContextBuilder
    {
        private static readonly string[] RecallPhrases =
        {
            "earlier", "yesterday", "last week", "last month", "last time", "before", "we discussed", "we talked", "we spoke", "our discussion", "our talk", "our chat", "our plan", "our campaign",
            "remember our", "remember what", "remind me what", "previous chat", "old chat",
        };

        /// <summary>The context for <paramref name="question"/>, from the messages of this chat so far (without that question).</summary>
        /// <param name="recall">Gives words from earlier chats for a question that goes back to them; may be null.</param>
        /// <param name="words">What the customer's profile adds to the English words the context recognises; null for English only.</param>
        public static ConversationContext Build(IReadOnlyList<ChatMessage> messages, string question, string chatKey = "", ContextBudget budget = null, Func<string, string> recall = null, ChatVocabulary words = null)
        {
            budget = budget ?? ContextBudget.Default;
            var turns = ToTurns(messages ?? new ChatMessage[0], budget);

            // The recent messages, newest first, until they no longer fit; the last two are always kept (cut short).
            var chars = 0;
            var firstRecent = turns.Count;
            for (var i = turns.Count - 1; i >= 0; i--)
            {
                var keep = turns.Count - i <= 2 || (turns.Count - i <= budget.MaxRecentTurns && chars + turns[i].Text.Length <= budget.MaxRecentChars);
                if (!keep)
                {
                    break;
                }

                chars += turns[i].Text.Length;
                firstRecent = i;
            }

            var older = turns.Take(firstRecent).ToList();
            var recent = turns.Skip(firstRecent).ToList();
            var summary = older.Count == 0 ? "" : ChatSummarizer.Summarize(older, budget.MaxSummaryChars, words);
            var recalled = "";
            if (recall != null && AsksToGoBack(question, words))
            {
                recalled = Cut(recall(question) ?? "", budget.MaxRecalledChars);
            }

            var topic = Topic(turns, words);
            var context = new ConversationContext(chatKey, summary, topic, recalled, recent, older.Count);

            // Over the whole budget: the oldest recent messages go into the summary's place first (the last two stay).
            while (context.ToPrompt().Length > budget.MaxChars && recent.Count > 2)
            {
                recent.RemoveAt(0);
                older = turns.Take(turns.Count - recent.Count).ToList();
                summary = ChatSummarizer.Summarize(older, budget.MaxSummaryChars, words);
                context = new ConversationContext(chatKey, summary, topic, recalled, recent, older.Count);
            }

            return context;
        }

        /// <summary>True when the owner asks to go back to an earlier chat ("what did we discuss yesterday?").</summary>
        public static bool AsksToGoBack(string question, ChatVocabulary words = null)
        {
            var text = (question ?? "").ToLowerInvariant();
            return RecallPhrases.Any(phrase => text.Contains(phrase)) || (words != null && words.AsksToGoBack(text));
        }

        /// <summary>The last thing the owner said that was not only "yes" or "continue".</summary>
        public static string Topic(IReadOnlyList<ContextTurn> turns, ChatVocabulary words = null)
        {
            for (var i = turns.Count - 1; i >= 0; i--)
            {
                var turn = turns[i];
                if (turn.Role == ChatRole.Owner && !Continuations.IsOnlyContinuing(turn.Text, words) && turn.Text.Split(' ').Length >= 3)
                {
                    return Cut(turn.Text, 160);
                }
            }

            return "";
        }

        private static List<ContextTurn> ToTurns(IReadOnlyList<ChatMessage> messages, ContextBudget budget)
        {
            var turns = new List<ContextTurn>();
            for (var i = 0; i < messages.Count; i++)
            {
                var message = messages[i];
                if (message.Role == ChatRole.Owner)
                {
                    var words = ChatMessage.Words(messages, i);
                    if (words.Length == 0)
                    {
                        continue;
                    }

                    var next = i + 1 < messages.Count ? messages[i + 1] : null;
                    var unanswered = next == null || next.Role != ChatRole.Assistant || next.IsProblem || next.WasStopped;
                    turns.Add(new ContextTurn(ChatRole.Owner, Cut(words, budget.MaxOwnerTurnChars), unanswered));
                    continue;
                }

                // A failure or a stop is not an answer: it is never shown to the AI as one.
                if (message.IsProblem || message.WasStopped)
                {
                    continue;
                }

                var text = message.Text.Trim();
                if (message.Table != null)
                {
                    text += " [A table of " + message.Table.TotalRows.ToString(CultureInfo.InvariantCulture) + (message.Table.TotalRows == 1 ? " row: " : " rows: ") + string.Join(", ", message.Table.Columns) + "]";
                }

                if (text.Length > 0)
                {
                    turns.Add(new ContextTurn(ChatRole.Assistant, Cut(text, budget.MaxAssistantTurnChars), false, message.Route));
                }
            }

            return turns;
        }

        /// <summary>Marks that end a sentence in scripts other than the Latin one (the danda of Devanagari, the full stop of Chinese and Japanese, the Arabic question mark, full-width ! and ?).</summary>
        internal static readonly char[] SentenceEnds = { '\u0964', '\u0965', '\u3002', '\uFF01', '\uFF1F', '\u061F' };

        internal static string Cut(string text, int max)
        {
            text = (text ?? "").Trim();
            if (text.Length <= max)
            {
                return text;
            }

            var cut = text.Substring(0, Math.Max(1, max - 1));
            var space = cut.LastIndexOfAny(new[] { ' ', '\n', '.' }.Concat(SentenceEnds).ToArray());
            return (space > max / 2 ? cut.Substring(0, space) : cut).TrimEnd() + "…";
        }
    }

    /// <summary>
    /// Older messages, said in short, without a model and without guessing: what the owner started with, what they said
    /// that sets a limit or a number (a budget, a date, a choice), what the AI concluded, and what is still open. The
    /// same older messages always give the same summary, and the parts that carry the goal and the limits are cut last.
    /// </summary>
    public static class ChatSummarizer
    {
        private const RegexOptions Options = RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled;

        // Whole words only: "pay" must not be found inside "payload". Any currency symbol counts as money, whatever the currency.
        private static readonly Regex Money = new Regex(@"\p{Sc}|\b(budget|cost|costs|price|prices|spend|spent|pay|paid|fee|fees|expenses?|quotes?|quotations?|estimates?)\b", Options);

        // A limit, a choice or a promise: what a later answer must not break.
        private static readonly Regex Constraint = new Regex(
            @"\b(budget|only|must|cannot|can't|cant|don't|dont|won't|wont|never|at most|at least|no more than|not (more|less) than|per (day|week|month)|deadline|limit|agreed|approved|confirmed|we will|we'll|prefer|instead of)\b", Options);

        // What the shop's marketing talk is about, which is why it is worth keeping.
        private static readonly Regex Topical = new Regex(
            @"\b(pamphlets?|flyers?|leaflets?|banners?|signage|stall|posters?|campaigns?|offers?|discounts?|vendors?|printers?|quotations?|quotes?|weekends?|weekdays?|festival|season|footfall)\b", Options);

        private static readonly Regex Wish = new Regex(@"\b(want|need|plan|goal|target|decide|decided|let's|lets)\b", Options);

        /// <param name="older">The messages that are not shown word for word, oldest first.</param>
        public static string Summarize(IReadOnlyList<ContextTurn> older, int maxChars, ChatVocabulary words = null)
        {
            if (older == null || older.Count == 0)
            {
                return "";
            }

            var owner = older.Where(t => t.Role == ChatRole.Owner).ToList();
            var parts = new List<List<string>>();

            // 1. What the owner started with: the first thing they said that was more than "hello".
            var first = owner.FirstOrDefault(t => !Continuations.IsOnlyContinuing(t.Text, words));
            parts.Add(first == null ? new List<string>() : new List<string> { "The owner started with: " + ConversationContextBuilder.Cut(first.Text, 240) });

            // 2. What they said that sets a number or a limit or a choice, best first but in the order said.
            var matters = owner
                .Select((t, i) => new { t, i, score = Score(t.Text, words) })
                .Where(x => x.score >= 3 && !ReferenceEquals(x.t, first))
                .OrderByDescending(x => x.score).ThenByDescending(x => x.i)
                .Take(7)
                .OrderBy(x => x.i)
                .Select(x => "- " + ConversationContextBuilder.Cut(x.t.Text, 220))
                .ToList();
            parts.Add(matters.Count == 0 ? new List<string>() : new[] { "What the owner said that matters:" }.Concat(matters).ToList());

            // 3. What the AI concluded or advised: the first sentence of its latest older answers.
            var concluded = older
                .Where(t => t.Role == ChatRole.Assistant)
                .Select(t => FirstSentence(t.Text, 180))
                .Where(s => s.Length > 0)
                .Reverse().Take(4).Reverse()
                .Select(s => "- " + s)
                .ToList();
            parts.Add(concluded.Count == 0 ? new List<string>() : new[] { "What you answered or advised:" }.Concat(concluded).ToList());

            // 4. What is still open: older questions that never got an answer.
            var open = owner.Where(t => t.Unanswered && !Continuations.IsOnlyContinuing(t.Text, words)).Take(3).Select(t => "- " + ConversationContextBuilder.Cut(t.Text, 160)).ToList();
            parts.Add(open.Count == 0 ? new List<string>() : new[] { "Asked and not answered yet:" }.Concat(open).ToList());

            // Put together part by part, whole lines only, the first part (the goal) and the limits before the rest.
            var order = new[] { 0, 1, 3, 2 };
            var kept = new Dictionary<int, List<string>>();
            var used = 0;
            foreach (var index in order)
            {
                var lines = new List<string>();
                foreach (var line in parts[index])
                {
                    if (used + line.Length + 1 > maxChars)
                    {
                        break;
                    }

                    lines.Add(line);
                    used += line.Length + 1;
                }

                kept[index] = lines;
            }

            return string.Join("\n", new[] { 0, 1, 2, 3 }.SelectMany(i => kept[i]));
        }

        /// <summary>How much a message of the owner's sets a number, a limit or a choice (3 or more: it is kept in the summary).</summary>
        internal static int Score(string text, ChatVocabulary words = null)
        {
            words = words ?? ChatVocabulary.Neutral;
            var line = (text ?? "").Trim();
            if (line.Length == 0 || Continuations.IsOnlyContinuing(line, words))
            {
                return -5;
            }

            var score = 0;
            if (line.Any(char.IsDigit))
            {
                score += 1;
            }

            if (Money.IsMatch(line) || words.Matches(WordKind.Money, line))
            {
                score += 3;
            }

            if (Constraint.IsMatch(line) || words.Matches(WordKind.Limits, line))
            {
                score += 3;
            }

            if (Topical.IsMatch(line) || words.Matches(WordKind.Topics, line))
            {
                score += 1;
            }

            if (Wish.IsMatch(line) || words.Matches(WordKind.Wishes, line))
            {
                score += 1;
            }

            if (line.TrimEnd().EndsWith("?", StringComparison.Ordinal))
            {
                score -= 1;
            }

            return score;
        }

        private static string FirstSentence(string text, int max)
        {
            text = (text ?? "").Trim();
            var end = text.IndexOfAny(new[] { '.', '!', '?', '\n' }.Concat(ConversationContextBuilder.SentenceEnds).ToArray());
            var sentence = end > 20 ? text.Substring(0, end) : text;
            return ConversationContextBuilder.Cut(sentence, max);
        }
    }
}
