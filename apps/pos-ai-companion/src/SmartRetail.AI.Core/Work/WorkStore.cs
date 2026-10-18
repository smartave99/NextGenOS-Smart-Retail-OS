using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SmartRetail.AI.Data;
using SmartRetail.AI.Storage;

namespace SmartRetail.AI.Work
{
    /// <summary>The assistant's own store of projects, tasks, reminders and notes as the chat and the screens use it.</summary>
    public interface IWork
    {
        WorkBook Load();

        /// <summary>The owner's own change, saved at once: null when saved, else why not.</summary>
        string Change(WorkChange change);

        /// <summary>
        /// The assistant's suggestions from one answer: each is checked as it would stand once the ones before it are kept, and what can be kept
        /// is saved at once (<paramref name="askFirst"/> false) or waits for the owner's Save. Nothing is ever applied to the shop's database.
        /// </summary>
        WorkProposal Propose(IEnumerable<WorkChange> changes, string summary, bool askFirst);
    }

    /// <summary>What came of saving a proposal.</summary>
    public sealed class WorkSaveResult
    {
        public int Saved { get; set; }

        /// <summary>For a plan made in one go: the id that takes the whole plan back with <see cref="WorkStore.Undo"/>.</summary>
        public string GroupId { get; set; } = "";

        /// <summary>Changes that no longer fit (for example a project the owner dropped meanwhile), with the reason.</summary>
        public List<string> Problems { get; } = new List<string>();
    }

    /// <summary>
    /// The assistant's own work, kept in the data folder's Memory\work.json: a file of the add-on, apart from the shop's database, which the
    /// assistant never writes to. What the assistant proposes waits for the owner unless the owner lets it save without asking; the owner's
    /// own edits save at once. Every change, kept or not, stays in the journey, and a kept change can be undone.
    /// </summary>
    public sealed class WorkStore : IWork
    {
        public const string FileName = "work.json";

        private static readonly JsonSerializerSettings Json = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            Converters = { new StringEnumConverter() },
        };

        private readonly Func<string> _dataFolder;
        private readonly Func<DateTime> _now;
        private readonly object _gate = new object();

        public WorkStore(Func<string> dataFolder, Func<DateTime> now)
        {
            _dataFolder = dataFolder ?? throw new ArgumentNullException(nameof(dataFolder));
            _now = now ?? throw new ArgumentNullException(nameof(now));
        }

        public string Path => System.IO.Path.Combine(DataFolders.Memory(_dataFolder()), FileName);

        public WorkBook Load()
        {
            lock (_gate)
            {
                return Read();
            }
        }

        public string Change(WorkChange change)
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
                var problem = WorkRules.Apply(book, change, change.At);
                if (problem != null)
                {
                    return problem;
                }

                Record(book, change, WorkChangeStatus.Saved);
                Write(book);
                return null;
            }
        }

        /// <summary>
        /// The owner's own plan, made in one go (for example from a campaign template): every change is saved as the owner's, and all can be taken back together with the
        /// returned group id. What does not fit is reported and the rest is kept.
        /// </summary>
        public WorkSaveResult AddPlan(IEnumerable<WorkChange> changes)
        {
            var result = new WorkSaveResult { GroupId = NewId() };
            lock (_gate)
            {
                var book = Read();
                var at = _now();
                foreach (var change in changes ?? Enumerable.Empty<WorkChange>())
                {
                    change.Id = NewId();
                    change.At = at;
                    change.Source = "Owner";
                    change.GroupId = result.GroupId;
                    var problem = WorkRules.Apply(book, change, at);
                    if (problem != null)
                    {
                        result.Problems.Add(Describe(change) + ": " + problem);
                        continue;
                    }

                    Record(book, change, WorkChangeStatus.Saved);
                    result.Saved++;
                }

                if (result.Saved > 0)
                {
                    Write(book);
                }
            }

            return result;
        }

        public WorkProposal Propose(IEnumerable<WorkChange> changes, string summary, bool askFirst)
        {
            var proposal = new WorkProposal { Id = NewId(), At = _now(), Summary = Shorten(PiiMasker.MaskText(WorkRules.Normalize(summary ?? "")), 600) };
            lock (_gate)
            {
                var book = Read();

                // What waits already counts as kept, so the same suggestion is not made twice.
                var trial = Copy(book);
                foreach (var waiting in book.Pending.SelectMany(p => p.Changes))
                {
                    WorkRules.Apply(trial, waiting.Copy(), proposal.At);
                }

                foreach (var change in changes ?? Enumerable.Empty<WorkChange>())
                {
                    change.Id = NewId();
                    change.At = proposal.At;
                    change.Source = "Chat";
                    change.GroupId = proposal.Id;
                    var attempt = change.Copy();
                    var problem = WorkRules.Apply(trial, attempt, proposal.At);
                    if (problem != null)
                    {
                        proposal.LeftOut.Add(Describe(change) + ": " + problem);
                        continue;
                    }

                    proposal.Changes.Add(change);
                }

                if (proposal.Changes.Count == 0)
                {
                    return proposal;
                }

                if (askFirst)
                {
                    foreach (var change in proposal.Changes)
                    {
                        change.Status = WorkChangeStatus.Pending;
                    }

                    book.Pending.Insert(0, proposal);
                }
                else
                {
                    var result = SaveAll(book, proposal);
                    proposal.LeftOut.AddRange(result.Problems);
                }

                Write(book);
            }

            return proposal;
        }

        /// <summary>Saves what the assistant proposed, as the owner approved it.</summary>
        public WorkSaveResult Approve(string proposalId)
        {
            lock (_gate)
            {
                var book = Read();
                var proposal = book.Pending.FirstOrDefault(p => p.Id == proposalId);
                var result = new WorkSaveResult();
                if (proposal == null)
                {
                    result.Problems.Add("That suggestion is no longer waiting.");
                    return result;
                }

                book.Pending.Remove(proposal);
                var done = SaveAll(book, proposal);
                Write(book);
                return done;
            }
        }

        public void Reject(string proposalId)
        {
            lock (_gate)
            {
                var book = Read();
                var proposal = book.Pending.FirstOrDefault(p => p.Id == proposalId);
                if (proposal == null)
                {
                    return;
                }

                book.Pending.Remove(proposal);
                foreach (var change in proposal.Changes)
                {
                    Record(book, change, WorkChangeStatus.Rejected);
                }

                Write(book);
            }
        }

        /// <summary>Takes back what one answer of the assistant (or one change of the owner) saved: null when done, else why not.</summary>
        public string Undo(string changeIdOrGroup)
        {
            lock (_gate)
            {
                var book = Read();
                var group = book.Journey.Where(c => c.Status == WorkChangeStatus.Saved && (c.Id == changeIdOrGroup || c.GroupId == changeIdOrGroup)).ToList();
                if (group.Count == 0)
                {
                    return "That change cannot be undone.";
                }

                // Newest first in the journey is the right order to take back.
                foreach (var saved in group)
                {
                    var problem = WorkRules.Undo(book, saved, _now());
                    if (problem != null)
                    {
                        Write(book);
                        return problem;
                    }

                    saved.Status = WorkChangeStatus.Undone;
                }

                Write(book);
                return null;
            }
        }

        private WorkSaveResult SaveAll(WorkBook book, WorkProposal proposal)
        {
            var result = new WorkSaveResult();
            foreach (var change in proposal.Changes)
            {
                var problem = WorkRules.Apply(book, change, _now());
                if (problem != null)
                {
                    result.Problems.Add(Describe(change) + ": " + problem);
                    continue;
                }

                Record(book, change, WorkChangeStatus.Saved);
                result.Saved++;
            }

            return result;
        }

        private static string Describe(WorkChange change)
        {
            var words = change.Op == WorkOp.Add ? change.Item?.Title : (!string.IsNullOrWhiteSpace(change.ItemWords) ? change.ItemWords : change.Item?.Title);
            return change.Op + " “" + WorkRules.Normalize(words ?? "").Replace('\n', ' ') + "”";
        }

        private static void Record(WorkBook book, WorkChange change, WorkChangeStatus status)
        {
            change.Status = status;
            book.Journey.Insert(0, change);
            if (book.Journey.Count > WorkRules.JourneyLength)
            {
                book.Journey.RemoveRange(WorkRules.JourneyLength, book.Journey.Count - WorkRules.JourneyLength);
            }
        }

        private WorkBook Read()
        {
            var path = Path;
            if (!File.Exists(path))
            {
                return new WorkBook();
            }

            WorkBook book;
            try
            {
                book = JsonConvert.DeserializeObject<WorkBook>(File.ReadAllText(path), Json) ?? new WorkBook();
            }
            catch (JsonException)
            {
                // A damaged file is kept aside, never overwritten, and the plan starts again empty.
                File.Copy(path, path + ".bad", overwrite: true);
                book = new WorkBook();
            }

            book.Normalize();
            return book;
        }

        private void Write(WorkBook book)
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

        private static string Shorten(string text, int max) => text.Length <= max ? text : text.Substring(0, max).TrimEnd() + "…";

        private static WorkBook Copy(WorkBook book) => JsonConvert.DeserializeObject<WorkBook>(JsonConvert.SerializeObject(book, Json), Json);

        private static string NewId() => Guid.NewGuid().ToString("N").Substring(0, 12);
    }
}
