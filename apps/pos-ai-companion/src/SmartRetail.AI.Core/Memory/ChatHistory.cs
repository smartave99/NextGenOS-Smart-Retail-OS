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
        [JsonConverter(typeof(StringEnumConverter))]
        public ChatRole Role { get; set; }

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

        /// <summary>The owner's first question, cut short.</summary>
        public string Title { get; set; } = "";

        public DateTime Started { get; set; }

        public DateTime Ended { get; set; }

        public List<SavedMessage> Messages { get; set; } = new List<SavedMessage>();

        /// <summary>The owner's questions, in order.</summary>
        [JsonIgnore]
        public IEnumerable<string> Questions => Messages.Where(m => m.Role == ChatRole.Owner).Select(m => m.Text);
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

        private static string Describe(ChatTable table)
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
