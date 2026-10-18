using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Data;
using SmartRetail.AI.Storage;

namespace SmartRetail.AI.Memory
{
    /// <summary>One message of a past chat, as kept: its words, and for a result table only its size and columns.</summary>
    public sealed class SavedMessage
    {
        /// <summary>The message's own id: a chat that is kept and resumed keeps its turns' names and order. Empty in chats kept before ids.</summary>
        public string Id { get; set; } = "";

        [JsonConverter(typeof(StringEnumConverter))]
        public ChatRole Role { get; set; }

        /// <summary>For an answer: whether it came from the shop's figures, from a conversation or both, so that a resumed chat goes on the same way.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public RequestKind? Route { get; set; }

        public string Text { get; set; } = "";

        public DateTime At { get; set; }

        public string Source { get; set; }

        public bool IsProblem { get; set; }

        /// <summary>E.g. "A table of 12 rows: Name, Balance", when the answer had one; its rows are not kept.</summary>
        public string Table { get; set; }
    }

    public sealed class SavedChat
    {
        public string Id { get; set; } = "";

        /// <summary>The owner's first question, cut short; or the name the owner gave the chat (see <see cref="Renamed"/>).</summary>
        public string Title { get; set; } = "";

        /// <summary>The owner gave this chat a name, which a later save of the same chat keeps.</summary>
        public bool Renamed { get; set; }

        public DateTime Started { get; set; }

        public DateTime Ended { get; set; }

        public List<SavedMessage> Messages { get; set; } = new List<SavedMessage>();

        /// <summary>The owner's questions, in order.</summary>
        [JsonIgnore]
        public IEnumerable<string> Questions => Messages.Where(m => m.Role == ChatRole.Owner).Select(m => m.Text);

        /// <summary>The six hex digits after the date in <see cref="Id"/>: the key the chat is kept under, and the key a resumed chat keeps.</summary>
        [JsonIgnore]
        public string Key => Id.Length > 7 && Id[Id.Length - 7] == '-' ? Id.Substring(Id.Length - 6) : "";

        /// <summary>
        /// The chat as messages again, to go on with it: the words (with phone numbers and e-mail addresses already hidden, as they were
        /// kept), who said them, when, and where each answer came from. Result tables and photos are not kept, so an answer's table is
        /// named in its words ("A table of 12 rows: ..."), and a message that carried a photo or a voice note says so in words.
        /// </summary>
        public IReadOnlyList<ChatMessage> ToMessages() => Messages.Select(m =>
        {
            var text = m.Text ?? "";
            if (!string.IsNullOrEmpty(m.Table))
            {
                text = text.Length == 0 ? "[" + m.Table + "]" : text + " [" + m.Table + "]";
            }

            return new ChatMessage(m.Role, text, m.At)
            {
                Id = string.IsNullOrEmpty(m.Id) ? Guid.NewGuid().ToString("N") : m.Id,
                Source = m.Source,
                IsProblem = m.IsProblem,
                Route = m.Route,
            };
        }).ToList();
    }

    /// <summary>A past chat that matches a search, with the words around the first match.</summary>
    public sealed class ChatSearchHit
    {
        public SavedChat Chat { get; set; }

        public string Snippet { get; set; } = "";
    }

    /// <summary>
    /// Past chats, like Hermes Agent's session search: kept in the data folder's Memory\Chats folder, a file a month,
    /// for <see cref="KeepMonths"/> months (older ones are never shown, and go with <see cref="DeleteExpired"/>), so the
    /// owner can find and ask them again. Only the words are kept, with phone numbers and e-mail addresses hidden: a
    /// result table is noted by its size and columns, as its rows may hold customers' details.
    /// </summary>
    public sealed class ChatHistory
    {
        public const string FolderName = "Chats";

        /// <summary>Chats older than this many months are not shown, and are deleted.</summary>
        public const int KeepMonths = 6;

        public const int TitleLength = 80;

        private const int SnippetRadius = 60;

        private static readonly Regex IdPattern = new Regex(@"^(?<month>\d{6})\d{8}-[0-9a-f]{6}$", RegexOptions.Compiled);

        private static readonly Regex KeyPattern = new Regex(@"^[0-9a-f]{6}$", RegexOptions.Compiled);

        // A month's file, or a copy of it: a damaged one kept aside, or one left half written.
        private static readonly Regex FilePattern = new Regex(@"^chats-(?<month>\d{4}-\d{2})\.json(?<copy>\.bad|\.tmp)?$", RegexOptions.Compiled);

        private static readonly JsonSerializerSettings Json = new JsonSerializerSettings { Formatting = Formatting.Indented };

        private readonly Func<string> _dataFolder;
        private readonly Func<DateTime> _now;
        private readonly object _gate = new object();

        public ChatHistory(Func<string> dataFolder, Func<DateTime> now)
        {
            _dataFolder = dataFolder ?? throw new ArgumentNullException(nameof(dataFolder));
            _now = now ?? throw new ArgumentNullException(nameof(now));
        }

        public string Folder => Path.Combine(DataFolders.Memory(_dataFolder()), FolderName);

        /// <summary>Keeps a chat that ended; null when it had no question to keep.</summary>
        public SavedChat Save(IReadOnlyList<ChatMessage> messages) => Save(messages, null);

        /// <summary>
        /// Keeps a chat, or the chat so far. Saved again with the same <paramref name="key"/> (six hex digits, from <see
        /// cref="NewKey"/>), it replaces the copy kept before, so a chat kept after every answer is one past chat.
        /// Null when it had no question to keep.
        /// </summary>
        public SavedChat Save(IReadOnlyList<ChatMessage> messages, string key)
        {
            // A question sent as a photo or voice note is kept in words: the files go when the chat ends.
            var all = messages ?? Array.Empty<ChatMessage>();
            var kept = all
                .Select((m, i) => (Message: m, Words: ChatMessage.Words(all, i)))
                .Where(x => x.Words.Length > 0)
                .Select(x => new SavedMessage
                {
                    Id = x.Message.Id,
                    Route = x.Message.Route,
                    Role = x.Message.Role,
                    Text = PiiMasker.MaskText(x.Words),
                    At = x.Message.At,
                    Source = x.Message.Source,
                    IsProblem = x.Message.IsProblem,
                    Table = Describe(x.Message.Table),
                })
                .ToList();
            var first = kept.FirstOrDefault(m => m.Role == ChatRole.Owner);
            if (first == null)
            {
                return null;
            }

            var started = kept[0].At == default ? _now() : kept[0].At;
            var chat = new SavedChat
            {
                Id = started.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture) + "-" + (key != null && KeyPattern.IsMatch(key) ? key : NewKey()),
                Title = Cut(MemoryRules.Normalize(first.Text), TitleLength),
                Started = started,
                Ended = _now(),
                Messages = kept,
            };

            lock (_gate)
            {
                var path = MonthFile(started);
                var month = Read(path);
                var before = month.FirstOrDefault(c => c.Id == chat.Id);
                if (before != null && before.Renamed)
                {
                    // A name the owner gave is kept when the chat is saved again after the next answer.
                    chat.Title = before.Title;
                    chat.Renamed = true;
                }

                month.RemoveAll(c => c.Id == chat.Id);
                month.Add(chat);
                Write(path, month);
                DeleteExpired();
            }

            return chat;
        }

        /// <summary>A key for one chat's copies (<see cref="Save(IReadOnlyList{ChatMessage}, string)"/>).</summary>
        public static string NewKey() => Guid.NewGuid().ToString("N").Substring(0, 6);

        /// <summary>The latest chats, newest first.</summary>
        public IReadOnlyList<SavedChat> Latest(int limit = 50)
        {
            lock (_gate)
            {
                return Months().SelectMany(path => Read(path).OrderByDescending(c => c.Started)).Take(Math.Max(1, limit)).ToList();
            }
        }

        public SavedChat Get(string id)
        {
            var match = IdPattern.Match(id ?? "");
            if (!match.Success)
            {
                return null;
            }

            var month = DateTime.ParseExact(match.Groups["month"].Value, "yyyyMM", CultureInfo.InvariantCulture);
            if (IsExpired(MonthName(month)))
            {
                return null;
            }

            lock (_gate)
            {
                return Read(MonthFile(month)).FirstOrDefault(c => c.Id == id);
            }
        }

        /// <summary>Chats with every word of <paramref name="text"/> in them, newest first.</summary>
        public IReadOnlyList<ChatSearchHit> Search(string text, int limit = 30)
        {
            var words = (text ?? "").Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => w.Length > 1)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
            if (words.Count == 0)
            {
                return Array.Empty<ChatSearchHit>();
            }

            var hits = new List<ChatSearchHit>();
            lock (_gate)
            {
                foreach (var path in Months())
                {
                    foreach (var chat in Read(path).OrderByDescending(c => c.Started))
                    {
                        var texts = new[] { chat.Title }.Concat(chat.Messages.Select(m => m.Text)).ToList();
                        if (words.All(w => texts.Any(t => Contains(t, w))))
                        {
                            hits.Add(new ChatSearchHit { Chat = chat, Snippet = Snippet(chat, words[0]) });
                            if (hits.Count == limit)
                            {
                                return hits;
                            }
                        }
                    }
                }
            }

            return hits;
        }

        private static readonly HashSet<string> RecallStopWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "what", "when", "where", "which", "did", "does", "have", "had", "was", "were", "will", "would", "could", "should", "discuss", "discussed", "talk", "talked", "spoke", "spoken",
            "about", "last", "week", "month", "year", "yesterday", "earlier", "before", "remember", "remind", "again", "that", "this", "these", "those", "with", "from", "into", "over",
            "your", "yours", "ours", "chat", "plan", "tell", "said", "says", "told", "know", "time", "back", "there", "then", "than", "they", "them", "just", "also", "kya", "humne", "baat",
            "pichli", "pichle", "baar", "hafte", "mahine", "kal", "hum", "aap", "mujhe", "batao",
        };

        /// <summary>
        /// A few words from the past chats that match what the owner asks to go back to ("what did we discuss about e-rickshaws last week?"),
        /// for the next prompt: the date and title of each chat and the lines in it that name the same things. Chats are scored by how many of the
        /// question's own words they hold, newest first among equals; the chat going on (<paramref name="exceptKey"/>) is left out, and so is
        /// everything else: a chat that shares no word with the question is not brought in. Empty when nothing matches.
        /// </summary>
        public string Recall(string question, string exceptKey = "", int maxChars = 1200, int maxChats = 2)
        {
            // The question's own words, as stems: "e-rickshaws" is "rickshaw" (a hyphen splits a word, and a plural "s" is dropped), so that
            // it finds "rickshaw" in the chat that was kept.
            var words = (question ?? "").Split(new[] { ' ', '\t', '\r', '\n', '.', ',', '?', '!', ';', ':', '"', '(', ')', '-', '/' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.Trim('\'', '‘', '’', '“', '”'))
                .Where(w => w.Length > 3 && !RecallStopWords.Contains(w))
                .Select(w => w.Length > 4 && w.EndsWith("s", StringComparison.OrdinalIgnoreCase) ? w.Substring(0, w.Length - 1) : w)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Take(8)
                .ToList();
            var all = new List<SavedChat>();
            lock (_gate)
            {
                foreach (var path in Months())
                {
                    all.AddRange(Read(path));
                }
            }

            var candidates = all.Where(c => string.IsNullOrEmpty(exceptKey) || c.Key != exceptKey).ToList();
            var scored = candidates
                .Select(c => new { Chat = c, Score = words.Count(w => Contains(c.Title, w) || c.Messages.Any(m => Contains(m.Text, w))) })
                .Where(x => words.Count == 0 ? false : x.Score > 0)
                .OrderByDescending(x => x.Score).ThenByDescending(x => x.Chat.Started)
                .Take(Math.Max(1, maxChats))
                .ToList();
            if (scored.Count == 0 && words.Count == 0)
            {
                // Nothing to look for ("what did we talk about?"): the latest other chat.
                var latest = candidates.OrderByDescending(c => c.Started).FirstOrDefault();
                scored = latest == null ? scored : new[] { new { Chat = latest, Score = 0 } }.ToList();
            }

            var text = new System.Text.StringBuilder();
            foreach (var hit in scored)
            {
                var lines = hit.Chat.Messages
                    .Where(m => !m.IsProblem && (words.Count == 0 || words.Any(w => Contains(m.Text, w))))
                    .Take(4)
                    .Select(m => (m.Role == ChatRole.Owner ? "Owner: " : "You: ") + Cut(MemoryRules.Normalize(m.Text), 200));
                var block = "Chat of " + hit.Chat.Started.ToString("d MMMM yyyy", CultureInfo.InvariantCulture) + " (" + hit.Chat.Title + "):\n" + string.Join("\n", lines);
                if (text.Length + block.Length > maxChars && text.Length > 0)
                {
                    break;
                }

                text.AppendLine(block);
            }

            return Cut(text.ToString().Trim(), maxChars);
        }

        /// <summary>
        /// Gives a past chat a name of the owner's own (empty goes back to the first question). Personal details are hidden in it as in the chat's words.
        /// False when there is no such chat or the name cannot be kept.
        /// </summary>
        public bool Rename(string id, string title)
        {
            var chat = Get(id);
            if (chat == null)
            {
                return false;
            }

            var name = MemoryRules.Normalize(PiiMasker.MaskText(title ?? ""));
            if (name.Any(char.IsControl))
            {
                return false;
            }

            lock (_gate)
            {
                var path = MonthFile(chat.Started);
                var month = Read(path);
                var found = month.FirstOrDefault(c => c.Id == id);
                if (found == null)
                {
                    return false;
                }

                if (name.Length == 0)
                {
                    var first = found.Messages.FirstOrDefault(m => m.Role == ChatRole.Owner);
                    found.Title = first == null ? found.Title : Cut(MemoryRules.Normalize(first.Text), TitleLength);
                    found.Renamed = false;
                }
                else
                {
                    found.Title = Cut(name, TitleLength);
                    found.Renamed = true;
                }

                Write(path, month);
            }

            return true;
        }

        public bool Delete(string id)
        {
            var chat = Get(id);
            if (chat == null)
            {
                return false;
            }

            lock (_gate)
            {
                var path = MonthFile(chat.Started);
                var month = Read(path);
                month.RemoveAll(c => c.Id == id);
                Write(path, month);
            }

            return true;
        }

        /// <summary>Deletes every past chat, with any copies; returns how many chats there were.</summary>
        public int DeleteAll()
        {
            lock (_gate)
            {
                // Counted first: reading a damaged month keeps a copy aside, which goes too.
                var count = Months().Sum(path => Read(path).Count);
                foreach (var file in Files())
                {
                    File.Delete(file.Path);
                }

                return count;
            }
        }

        /// <summary>Deletes the months older than <see cref="KeepMonths"/>, with any copies; returns how many files
        /// went. They are never shown, even before they are deleted.</summary>
        public int DeleteExpired()
        {
            lock (_gate)
            {
                var expired = Files().Where(f => IsExpired(f.Month)).ToList();
                foreach (var file in expired)
                {
                    File.Delete(file.Path);
                }

                return expired.Count;
            }
        }

        /// <summary>"A table of 12 rows: Product, Qty" for a result table kept in words, or null.</summary>
        public static string Describe(ChatTable table)
        {
            if (table == null)
            {
                return null;
            }

            var rows = table.TotalRows == 1 ? "1 row" : table.TotalRows.ToString("N0", CultureInfo.InvariantCulture) + " rows";
            return "A table of " + rows + ": " + string.Join(", ", table.Columns);
        }

        private static string Snippet(SavedChat chat, string word)
        {
            var text = chat.Messages.Select(m => m.Text).FirstOrDefault(t => Contains(t, word)) ?? chat.Title;
            var flat = MemoryRules.Normalize(text);
            var at = flat.IndexOf(word, StringComparison.OrdinalIgnoreCase);
            var from = Math.Max(0, at - SnippetRadius);
            var to = Math.Min(flat.Length, Math.Max(at, 0) + word.Length + SnippetRadius);
            return (from > 0 ? "…" : "") + flat.Substring(from, to - from) + (to < flat.Length ? "…" : "");
        }

        private static bool Contains(string text, string word) => (text ?? "").IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0;

        private static string MonthName(DateTime day) => day.ToString("yyyy-MM", CultureInfo.InvariantCulture);

        private string MonthFile(DateTime day) => Path.Combine(Folder, "chats-" + MonthName(day) + ".json");

        /// <summary>True for a month ("yyyy-MM") older than <see cref="KeepMonths"/>.</summary>
        private bool IsExpired(string month) => string.CompareOrdinal(month, MonthName(_now().AddMonths(-KeepMonths))) < 0;

        /// <summary>The month files still kept, newest first.</summary>
        private IEnumerable<string> Months() =>
            Files().Where(f => !f.IsCopy && !IsExpired(f.Month)).Select(f => f.Path).OrderByDescending(p => p, StringComparer.Ordinal).ToList();

        /// <summary>Every file of past chats, with its month.</summary>
        private List<(string Path, string Month, bool IsCopy)> Files()
        {
            var folder = Folder;
            if (!Directory.Exists(folder))
            {
                return new List<(string Path, string Month, bool IsCopy)>();
            }

            return Directory.EnumerateFiles(folder, "chats-*")
                .Select(path => (Path: path, Match: FilePattern.Match(Path.GetFileName(path))))
                .Where(f => f.Match.Success)
                .Select(f => (f.Path, Month: f.Match.Groups["month"].Value, IsCopy: f.Match.Groups["copy"].Success))
                .ToList();
        }

        private static List<SavedChat> Read(string path)
        {
            if (!File.Exists(path))
            {
                return new List<SavedChat>();
            }

            try
            {
                return JsonConvert.DeserializeObject<List<SavedChat>>(File.ReadAllText(path), Json) ?? new List<SavedChat>();
            }
            catch (JsonException)
            {
                // A damaged month is kept aside, never overwritten.
                File.Copy(path, path + ".bad", overwrite: true);
                return new List<SavedChat>();
            }
        }

        private static void Write(string path, List<SavedChat> month)
        {
            if (month.Count == 0)
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(path));
            var temporary = path + ".tmp";
            File.WriteAllText(temporary, JsonConvert.SerializeObject(month, Json));
            if (File.Exists(path))
            {
                File.Replace(temporary, path, null);
            }
            else
            {
                File.Move(temporary, path);
            }
        }

        private static string Cut(string text, int max) =>
            text.Length <= max ? text : text.Substring(0, max - 1).TrimEnd() + "…";
    }
}
