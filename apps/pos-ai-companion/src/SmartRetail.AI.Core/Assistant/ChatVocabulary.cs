using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SmartRetail.AI.Assistant
{
    /// <summary>The kinds of words the assistant recognises in what the owner writes.</summary>
    public enum WordKind
    {
        /// <summary>Names of what the shop's records hold (sales, bills, stock, people, money), beyond the English ones built in.</summary>
        Figures,

        /// <summary>The shape of a question about figures (how many, today, last week).</summary>
        AsksForFigures,

        /// <summary>Asking for advice, an idea, a plan or a draft.</summary>
        Advice,

        /// <summary>Asking to keep a project, a task, a reminder or a number.</summary>
        Work,

        /// <summary>A short reply that only carries on ("yes", "go on", "try again").</summary>
        Continue,

        /// <summary>Phrases that send the chat back to an earlier one ("what did we discuss last time?").</summary>
        Recall,

        /// <summary>Words about money.</summary>
        Money,

        /// <summary>Words that set a limit or a choice ("only", "must", "prefer").</summary>
        Limits,

        /// <summary>What the shop's marketing talk is about (a channel, a kind of offer).</summary>
        Topics,

        /// <summary>Words of wanting or deciding ("want", "plan", "goal").</summary>
        Wishes,
    }

    /// <summary>
    /// What the assistant recognises in the owner's words, besides the plain English built into the program. The program itself holds English only, with no language, currency or
    /// market written into it (CLAUDE.md, section 8); the words of the customer's own language, money and trade come from its profile (<c>profile/chat-words.json</c>, beside the
    /// program, in the same place as <c>ai.json</c>). With none, the assistant still works: a message it cannot place goes where any other question goes, and the AI reads it with the chat.
    /// </summary>
    public sealed class ChatVocabulary
    {
        public const string FileName = "chat-words.json";
        public const int MaxWordsPerKind = 300;
        private const long MaxBytes = 200 * 1024;

        // Not a letter, a mark or a digit: a boundary that works in every script (a word-boundary of the regex library breaks inside many Indic words).
        private const string Before = @"(?<![\p{L}\p{M}\p{N}_])";
        private const string After = @"(?![\p{L}\p{M}\p{N}_])";

        private readonly Dictionary<WordKind, string[]> _words = new Dictionary<WordKind, string[]>();
        private readonly Dictionary<WordKind, Regex> _regexes = new Dictionary<WordKind, Regex>();
        private readonly HashSet<string> _continue;

        /// <summary>English only: no extra words.</summary>
        public static ChatVocabulary Neutral { get; } = new ChatVocabulary(new Dictionary<WordKind, string[]>());

        public ChatVocabulary(IDictionary<WordKind, string[]> words)
        {
            foreach (var kind in Enum.GetValues(typeof(WordKind)).Cast<WordKind>())
            {
                var list = words != null && words.TryGetValue(kind, out var given) ? given : new string[0];
                _words[kind] = list.Where(w => !string.IsNullOrWhiteSpace(w)).Select(w => w.Trim().ToLowerInvariant()).Distinct().Take(MaxWordsPerKind).ToArray();
                if (_words[kind].Length > 0 && kind != WordKind.Continue)
                {
                    var alternatives = string.Join("|", _words[kind].OrderByDescending(w => w.Length).Select(w => Regex.Escape(w).Replace("\\ ", @"\s+")));
                    _regexes[kind] = new Regex(Before + "(" + alternatives + ")" + After, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
                }
            }

            _continue = new HashSet<string>(_words[WordKind.Continue], StringComparer.Ordinal);
        }

        /// <summary>True when the profile gave no extra words at all.</summary>
        public bool IsNeutral => _words.Values.All(w => w.Length == 0);

        public IReadOnlyList<string> Of(WordKind kind) => _words[kind];

        /// <summary>True when one of the profile's words of this kind is in <paramref name="text"/> (as a whole word, in any script).</summary>
        public bool Matches(WordKind kind, string text) => _regexes.TryGetValue(kind, out var regex) && regex.IsMatch(text ?? "");

        /// <summary>True when the whole (already tidied, lower-case) message is one of the profile's words for carrying on.</summary>
        public bool IsContinuation(string tidied) => _continue.Contains(tidied ?? "");

        /// <summary>True when <paramref name="text"/> has one of the profile's recall phrases in it.</summary>
        public bool AsksToGoBack(string text)
        {
            var lower = (text ?? "").ToLowerInvariant();
            return _words[WordKind.Recall].Any(phrase => lower.Contains(phrase));
        }

        /// <summary>The vocabulary in a folder of the program (or the one above it); neutral when there is no file.</summary>
        public static ChatVocabulary LoadNear(string baseDirectory, List<string> problems = null)
        {
            foreach (var folder in new[] { baseDirectory, baseDirectory == null ? null : Path.GetDirectoryName(baseDirectory.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)) })
            {
                if (string.IsNullOrEmpty(folder))
                {
                    continue;
                }

                try
                {
                    var file = new FileInfo(Path.Combine(folder, "profile", FileName));
                    if (file.Exists && file.Length <= MaxBytes && (file.Attributes & FileAttributes.ReparsePoint) == 0)
                    {
                        return Parse(File.ReadAllText(file.FullName, System.Text.Encoding.UTF8), problems);
                    }
                }
                catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                {
                    // as if it were not there
                }
            }

            return Neutral;
        }

        /// <summary>
        /// Reads the file's text: <c>{"schema": 1, "words": {"figures": [...], "asksForFigures": [...], "advice": [...], "work": [...], "continue": [...], "recall": [...], "money": [...],
        /// "limits": [...], "topics": [...], "wishes": [...]}}</c>. Tolerant: what cannot be used is left out and said in <paramref name="problems"/>. Words are plain text, matched as
        /// whole words; they are never patterns, so a file cannot make the matching slow or wrong.
        /// </summary>
        public static ChatVocabulary Parse(string json, List<string> problems = null)
        {
            problems = problems ?? new List<string>();
            JObject root;
            try
            {
                root = JToken.Parse(json ?? "") as JObject;
            }
            catch (JsonException)
            {
                root = null;
            }

            if (root == null || !(root["schema"] is JValue schema && schema.Type == JTokenType.Integer && schema.Value is long number && number == 1))
            {
                problems.Add("The chat words do not say \"schema\": 1; the plain English ones are used.");
                return Neutral;
            }

            var words = new Dictionary<WordKind, string[]>();
            var section = root["words"] as JObject;
            foreach (var pair in new[]
            {
                ("figures", WordKind.Figures), ("asksForFigures", WordKind.AsksForFigures), ("advice", WordKind.Advice), ("work", WordKind.Work), ("continue", WordKind.Continue),
                ("recall", WordKind.Recall), ("money", WordKind.Money), ("limits", WordKind.Limits), ("topics", WordKind.Topics), ("wishes", WordKind.Wishes),
            })
            {
                var list = new List<string>();
                foreach (var item in (section?[pair.Item1] as JArray ?? new JArray()))
                {
                    var text = item.Type == JTokenType.String ? ((string)item).Trim() : "";
                    if (text.Length == 0 || text.Length > 40 || text.Any(char.IsControl))
                    {
                        problems.Add("A word in \"" + pair.Item1 + "\" is not usable (empty, over 40 letters or with control characters); it is left out.");
                        continue;
                    }

                    list.Add(text);
                }

                words[pair.Item2] = list.ToArray();
            }

            return new ChatVocabulary(words);
        }
    }
}
