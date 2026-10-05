using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SmartRetail.AI.Storage;

namespace SmartRetail.AI.Memory
{
    /// <summary>
    /// The assistant's memory as the chat uses it: <see cref="MemoryStore"/>, or the dashboard's service around it,
    /// which refuses changes while the data folder is being moved.
    /// </summary>
    public interface IMemory
    {
        MemoryBook Load();

        /// <summary>The owner's own change, saved at once: null when saved, else why not.</summary>
        string Change(MemoryChange change);

        /// <summary>The AI's suggestions, saved at once or kept for the owner's Save.</summary>
        IReadOnlyList<MemoryOutcome> Propose(IEnumerable<MemoryChange> changes, bool askFirst);
    }

    /// <summary>What happened to one proposed change.</summary>
    public sealed class MemoryOutcome
    {
        public MemoryChange Change { get; set; }

        /// <summary>Null when it was saved or set aside for the owner; else why not.</summary>
        public string Problem { get; set; }
    }

    /// <summary>
    /// The assistant's memory, kept in the data folder's Memory\memory.json, never in the POS. Changes the AI proposes
    /// wait for the owner unless the owner lets it save without asking; the owner's own edits save at once. Every
    /// saved change is kept in the journey, where it can be undone.
    /// </summary>
    public sealed class MemoryStore : IMemory
    {
        public const string FileName = "memory.json";

        /// <summary>The journey keeps this many changes.</summary>
        public const int JourneyLength = 300;

        private static readonly JsonSerializerSettings Json = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            Converters = { new StringEnumConverter() },
        };

        private readonly Func<string> _dataFolder;
        private readonly Func<DateTime> _now;
        private readonly object _gate = new object();

        public MemoryStore(Func<string> dataFolder, Func<DateTime> now)
        {
            _dataFolder = dataFolder ?? throw new ArgumentNullException(nameof(dataFolder));
            _now = now ?? throw new ArgumentNullException(nameof(now));
        }

        public string Path => System.IO.Path.Combine(DataFolders.Memory(_dataFolder()), FileName);

        public MemoryBook Load()
        {
            lock (_gate)
            {
                return Read();
            }
        }

        /// <summary>
        /// The AI's proposals: each is checked against memory as it would stand, then saved at once when
        /// <paramref name="askFirst"/> is false, else kept for the owner's Save or Don't save.
        /// </summary>
        public IReadOnlyList<MemoryOutcome> Propose(IEnumerable<MemoryChange> changes, bool askFirst)
        {
            var outcomes = new List<MemoryOutcome>();
            lock (_gate)
            {
                var book = Read();
                foreach (var change in changes ?? Enumerable.Empty<MemoryChange>())
                {
                    change.Id = NewId();
                    change.At = _now();
                    change.NewText = MemoryRules.Normalize(change.NewText);

                    // Checked against a copy, so a proposal that cannot apply never reaches the owner.
                    var trial = Copy(book);
                    foreach (var pending in book.Pending)
                    {
                        MemoryRules.Apply(trial, Copy(pending), change.At);
                    }

                    var problem = MemoryRules.Apply(trial, Copy(change), change.At);
                    if (problem == null)
                    {
                        if (askFirst)
                        {
                            change.Status = MemoryChangeStatus.Pending;
                            book.Pending.Add(change);
                        }
                        else
                        {
                            MemoryRules.Apply(book, change, change.At);
                            Record(book, change, MemoryChangeStatus.Saved);
                        }
                    }

                    outcomes.Add(new MemoryOutcome { Change = change, Problem = problem });
                }

                Write(book);
            }

            return outcomes;
        }

        /// <summary>Saves a pending change; null when saved, else why not (e.g. memory filled up meanwhile).</summary>
        public string Approve(string id, string editedText = null)
        {
            lock (_gate)
            {
                var book = Read();
                var change = book.Pending.FirstOrDefault(c => c.Id == id);
                if (change == null)
                {
                    return "That suggestion is no longer waiting.";
                }

                if (!string.IsNullOrWhiteSpace(editedText) && change.Op != MemoryOp.Remove)
                {
                    change.NewText = MemoryRules.Normalize(editedText);
                }

                var problem = MemoryRules.Apply(book, change, _now());
                if (problem != null)
                {
                    return problem;
                }

                book.Pending.Remove(change);
                Record(book, change, MemoryChangeStatus.Saved);
                Write(book);
                return null;
            }
        }

        public void Reject(string id)
        {
            lock (_gate)
            {
                var book = Read();
                var change = book.Pending.FirstOrDefault(c => c.Id == id);
                if (change != null)
                {
                    book.Pending.Remove(change);
                    Record(book, change, MemoryChangeStatus.Rejected);
                    Write(book);
                }
            }
        }

        /// <summary>The owner's own change: saved at once, and kept in the journey like the AI's.</summary>
        public string Change(MemoryChange change)
        {
            if (change == null)
            {
                throw new ArgumentNullException(nameof(change));
            }

            lock (_gate)
            {
                var book = Read();
                change.Id = NewId();
                change.At = _now();
                change.Source = string.IsNullOrEmpty(change.Source) ? "Owner" : change.Source;
                var problem = MemoryRules.Apply(book, change, change.At);
                if (problem != null)
                {
                    return problem;
                }

                Record(book, change, MemoryChangeStatus.Saved);
                Write(book);
                return null;
            }
        }

        /// <summary>Removes an entry that was set aside when the file was read.</summary>
        public void RemoveSetAside(MemoryPart part, string text)
        {
            lock (_gate)
            {
                var book = Read();
                if (book.SetAside.RemoveAll(s => s.Part == part && s.Text == text) > 0)
                {
                    Write(book);
                }
            }
        }

        /// <summary>Takes a saved change back; null when done, else why not (e.g. the entry changed since).</summary>
        public string Undo(string id)
        {
            lock (_gate)
            {
                var book = Read();
                var saved = book.Journey.FirstOrDefault(c => c.Id == id && c.Status == MemoryChangeStatus.Saved);
                if (saved == null)
                {
                    return "That change cannot be undone.";
                }

                var reverse = MemoryRules.Reverse(saved);
                var problem = MemoryRules.Apply(book, reverse, _now());
                if (problem != null)
                {
                    return problem;
                }

                saved.Status = MemoryChangeStatus.Undone;
                Write(book);
                return null;
            }
        }

        private static void Record(MemoryBook book, MemoryChange change, MemoryChangeStatus status)
        {
            change.Status = status;
            book.Journey.Insert(0, change);
            if (book.Journey.Count > JourneyLength)
            {
                book.Journey.RemoveRange(JourneyLength, book.Journey.Count - JourneyLength);
            }
        }

        private MemoryBook Read()
        {
            var path = Path;
            if (!File.Exists(path))
            {
                return new MemoryBook();
            }

            MemoryBook book;
            try
            {
                book = JsonConvert.DeserializeObject<MemoryBook>(File.ReadAllText(path), Json) ?? new MemoryBook();
            }
            catch (JsonException)
            {
                // A damaged file is kept aside, never overwritten, and memory starts again empty.
                File.Copy(path, path + ".bad", overwrite: true);
                book = new MemoryBook();
            }

            book.Normalize();
            MemoryRules.Screen(book, _now());
            return book;
        }

        private void Write(MemoryBook book)
        {
            var path = Path;
            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
            var temporary = path + ".tmp";
            File.WriteAllText(temporary, JsonConvert.SerializeObject(book, Json));
            if (File.Exists(path))
            {
                File.Replace(temporary, path, null);
            }
            else
            {
                File.Move(temporary, path);
            }
        }

        private static MemoryBook Copy(MemoryBook book) =>
            JsonConvert.DeserializeObject<MemoryBook>(JsonConvert.SerializeObject(book, Json), Json);

        private static MemoryChange Copy(MemoryChange change) =>
            JsonConvert.DeserializeObject<MemoryChange>(JsonConvert.SerializeObject(change, Json), Json);

        private static string NewId() => Guid.NewGuid().ToString("N").Substring(0, 12);
    }
}
