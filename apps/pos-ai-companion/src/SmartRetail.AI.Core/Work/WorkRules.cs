using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SmartRetail.AI.Data;

namespace SmartRetail.AI.Work
{
    /// <summary>
    /// What the assistant's own store may hold and how it changes. Everything the AI suggests passes through here before it is kept,
    /// because what is kept goes back into later prompts: text that reads like an instruction to the AI is refused, sizes are limited,
    /// a task can only sit in a project that exists, and a duplicate is not added twice. These rules are about the assistant's own
    /// store only. Nothing here, and nothing that uses it, can reach the shop's database.
    /// </summary>
    public static class WorkRules
    {
        public const int TitleLimit = 120;

        public const int DetailLimit = 600;

        public const int ChannelLimit = 80;

        /// <summary>Items that are not dropped; a larger plan is a sign of a runaway answer, not of a shop.</summary>
        public const int MaxItems = 400;

        public const int MaxPerProject = 60;

        /// <summary>The owner's own numbers (counts, spending, quotations) have a room of their own: a campaign counted every day must not fill the plan.</summary>
        public const int MaxRecords = 600;

        public const decimal MaxBudget = 1_000_000_000m;

        public const int JourneyLength = 500;

        private static readonly Regex LooksLikeAnInstruction = new Regex(
            @"ignore\s+(all\s+|the\s+|any\s+)?(previous|prior|above|earlier)|disregard\s+(all|the|previous|prior|any)|forget\s+(all|everything|your)\s|system\s*prompt|you\s+are\s+now|developer\s+mode|jailbreak|act\s+as\s+(an?\s+)?(ai|assistant|system)|<\||\|>|```|begin\s+(system|prompt)|api[\s_-]?key|password|secret\s+key|run\s+this\s+command|curl\s+|powershell|drop\s+table|delete\s+from|update\s+\w+\s+set|insert\s+into",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static readonly Regex Spaces = new Regex(@"[ \t]+", RegexOptions.Compiled);

        /// <summary>Trimmed, with runs of spaces made one; new lines stay in a detail.</summary>
        public static string Normalize(string text)
        {
            var lines = (text ?? "").Replace("\r\n", "\n").Replace('\r', '\n').Split('\n').Select(l => Spaces.Replace(l, " ").Trim());
            return string.Join("\n", lines).Trim();
        }

        private static string OneLine(string text) => Normalize(text).Replace('\n', ' ');

        /// <summary>Why <paramref name="text"/> cannot be kept as words of a plan, or null when it can.</summary>
        public static string CheckWords(string text, int limit, string what)
        {
            if (text == null)
            {
                return null;
            }

            if (text.Any(c => char.IsControl(c) && c != '\n' && c != '\r' && c != '\t' || c == '​' || c == '‮' || c == '⁦' || c == '⁧' || c == '⁨'))
            {
                return "The " + what + " has hidden characters.";
            }

            if (Normalize(text).Length > limit)
            {
                return "The " + what + " is too long: keep it under " + limit + " characters.";
            }

            if (LooksLikeAnInstruction.IsMatch(text))
            {
                return "The " + what + " reads like an instruction to the AI or to a database, not like a piece of the plan.";
            }

            return null;
        }

        /// <summary>
        /// Applies <paramref name="change"/> to <paramref name="book"/>, or says why it cannot be applied. On success the change keeps what it
        /// replaced (<see cref="WorkChange.Before"/>) and, for an Add, the item as added, so that it can be undone.
        /// </summary>
        public static string Apply(WorkBook book, WorkChange change, DateTime now)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (change == null)
            {
                throw new ArgumentNullException(nameof(change));
            }

            switch (change.Op)
            {
                case WorkOp.Add:
                    return Add(book, change, now);
                case WorkOp.Update:
                    return Update(book, change, now);
                case WorkOp.Complete:
                case WorkOp.Drop:
                case WorkOp.Reopen:
                    return Move(book, change, now);
                default:
                    return "That kind of change is not known.";
            }
        }

        /// <summary>Takes back a saved change: null when done, else why not.</summary>
        public static string Undo(WorkBook book, WorkChange saved, DateTime now)
        {
            if (saved.Op == WorkOp.Add)
            {
                var id = saved.Before?.Id;
                var item = book.Find(id);
                if (item == null)
                {
                    return "That item is no longer there.";
                }

                if (book.Items.Any(i => i.ProjectId == id))
                {
                    return "Other work was added to it since. Drop it instead.";
                }

                book.Items.Remove(item);
                return null;
            }

            var target = book.Find(saved.Before?.Id);
            if (target == null)
            {
                return "That item is no longer there.";
            }

            // Only the latest change of an item can be taken back: restoring an older picture would also wipe what was done to it since.
            if (saved.After != null && (target.Updated != saved.After.Updated || target.Status != saved.After.Status || target.Title != saved.After.Title))
            {
                return "It was changed again after that. Take back the later change first.";
            }

            // Put back exactly as it was (also when it was last changed), so that the change before this one can be taken back in turn.
            book.Items[book.Items.IndexOf(target)] = saved.Before.Copy();
            return null;
        }

        private static string Add(WorkBook book, WorkChange change, DateTime now)
        {
            var item = change.Item;
            if (item == null)
            {
                return "There is nothing to add.";
            }

            var title = OneLine(item.Title);
            if (title.Length == 0)
            {
                return "It has no title.";
            }

            var problem = CheckWords(item.Title, TitleLimit, "title") ?? CheckWords(item.Detail, DetailLimit, "note")
                ?? CheckWords(item.Channel, ChannelLimit, "channel") ?? CheckWords(item.Area, ChannelLimit, "place");
            if (problem != null)
            {
                return problem;
            }

            if (item.Kind == WorkKind.Record)
            {
                if (book.Items.Count(i => i.Kind == WorkKind.Record && i.Status != WorkStatus.Dropped) >= MaxRecords)
                {
                    return "There are already " + MaxRecords + " numbers entered. Remove old ones first.";
                }
            }
            else if (book.Items.Count(i => i.Kind != WorkKind.Record && i.Status != WorkStatus.Dropped) >= MaxItems)
            {
                return "The plan is full (" + MaxItems + " items). Finish or drop some first.";
            }

            // What the assistant suggests goes back into later prompts: it may not carry a phone number or an e-mail address. The owner may enter one by hand.
            if (change.Source == "Chat")
            {
                problem = ContactProblem(item.Title, item.Detail, item.Channel, item.Area);
                if (problem != null)
                {
                    return problem;
                }
            }

            if (item.Kind == WorkKind.Reminder && !item.Due.HasValue)
            {
                return "A reminder needs a date.";
            }

            problem = CheckRecord(item) ?? CheckDue(item.Due, now, item.Kind) ?? CheckBudget(item) ?? CheckCampaign(item, now);
            if (problem != null)
            {
                return problem;
            }

            string projectId = "";
            if (item.Kind == WorkKind.Project)
            {
                if (!string.IsNullOrEmpty(item.ProjectId) || !string.IsNullOrWhiteSpace(item.ProjectName))
                {
                    return "A project cannot sit inside another project.";
                }
            }
            else if (!string.IsNullOrEmpty(item.ProjectId) || !string.IsNullOrWhiteSpace(item.ProjectName))
            {
                var project = !string.IsNullOrEmpty(item.ProjectId) ? book.Find(item.ProjectId) : FindByWords(book, item.ProjectName, WorkKind.Project, out problem);
                if (project == null || project.Kind != WorkKind.Project)
                {
                    return problem ?? "There is no such project.";
                }

                if (project.Status == WorkStatus.Dropped)
                {
                    return "That project was dropped.";
                }

                if (item.Kind != WorkKind.Record && book.Items.Count(i => i.ProjectId == project.Id && i.Kind != WorkKind.Record && i.Status != WorkStatus.Dropped) >= MaxPerProject)
                {
                    return "That project already has " + MaxPerProject + " items.";
                }

                projectId = project.Id;
            }

            var label = (item.Label ?? "").Trim().ToLowerInvariant();
            var same = book.Items.FirstOrDefault(i => i.Kind == item.Kind && i.ProjectId == projectId && i.Status == WorkStatus.Open
                && string.Equals(OneLine(i.Title), title, StringComparison.OrdinalIgnoreCase)
                && (item.Kind != WorkKind.Record || (i.Label == label && i.Due == item.Due?.Date && i.Amount == item.Amount)));
            if (same != null)
            {
                return "“" + title + "” is already in the plan.";
            }

            var added = new WorkItem
            {
                Id = string.IsNullOrEmpty(item.Id) ? NewId() : item.Id,
                TenantId = string.IsNullOrWhiteSpace(item.TenantId) ? "local" : item.TenantId,
                SiteId = string.IsNullOrWhiteSpace(item.SiteId) ? "main" : item.SiteId,
                Kind = item.Kind,
                Title = title,
                Detail = Normalize(item.Detail),
                ProjectId = projectId,
                Status = WorkStatus.Open,
                Due = item.Due?.Date,
                Starts = item.Starts?.Date,
                Budget = item.Budget,
                Label = item.Kind == WorkKind.Record ? label : "",
                Amount = item.Kind == WorkKind.Record ? item.Amount : null,
                Channel = OneLine(item.Channel),
                Area = OneLine(item.Area),
                ActionId = item.ActionId ?? "",
                Created = now,
                Updated = now,
                Source = string.IsNullOrEmpty(change.Source) ? "Owner" : change.Source,
            };
            book.Items.Add(added);
            change.Item = added.Copy();
            change.Before = added.Copy();
            change.ItemId = added.Id;
            return null;
        }

        private static string Update(WorkBook book, WorkChange change, DateTime now)
        {
            var target = Target(book, change, out var problem);
            if (target == null)
            {
                return problem;
            }

            if (target.Status != WorkStatus.Open)
            {
                return target.Status == WorkStatus.Done ? "It is already done." : "It was dropped.";
            }

            var patch = change.Item ?? new WorkItem();
            problem = CheckWords(patch.Title, TitleLimit, "title") ?? CheckWords(patch.Detail, DetailLimit, "note")
                ?? CheckWords(patch.Channel, ChannelLimit, "channel") ?? CheckWords(patch.Area, ChannelLimit, "place");
            if (problem != null)
            {
                return problem;
            }

            if (change.Source == "Chat")
            {
                problem = ContactProblem(patch.Title, patch.Detail, patch.Channel, patch.Area);
                if (problem != null)
                {
                    return problem;
                }
            }

            var copy = target.Copy();
            if (OneLine(patch.Title).Length > 0)
            {
                copy.Title = OneLine(patch.Title);
            }

            if (!string.IsNullOrWhiteSpace(patch.Detail))
            {
                copy.Detail = Normalize(patch.Detail);
            }

            if (patch.Due.HasValue)
            {
                // A date left as it was is not checked again (a campaign that has ended keeps its last day).
                if (patch.Due.Value.Date != target.Due?.Date)
                {
                    problem = CheckDue(patch.Due, now, copy.Kind);
                    if (problem != null)
                    {
                        return problem;
                    }
                }

                copy.Due = patch.Due.Value.Date;
            }

            if (patch.Starts.HasValue)
            {
                copy.Starts = patch.Starts.Value.Date;
            }

            if (OneLine(patch.Channel).Length > 0)
            {
                copy.Channel = OneLine(patch.Channel);
            }

            if (OneLine(patch.Area).Length > 0)
            {
                copy.Area = OneLine(patch.Area);
            }

            if (!string.IsNullOrEmpty(patch.ActionId))
            {
                copy.ActionId = patch.ActionId.Trim();
            }

            if (patch.Amount.HasValue)
            {
                if (copy.Kind != WorkKind.Record)
                {
                    return "Only a record has an amount.";
                }

                copy.Amount = patch.Amount;
            }

            problem = (copy.Kind == WorkKind.Record ? CheckRecord(copy) : null) ?? CheckCampaign(copy, now);
            if (problem != null)
            {
                return problem;
            }

            if (patch.Budget.HasValue)
            {
                if (copy.Kind != WorkKind.Project && copy.Kind != WorkKind.Task)
                {
                    return "Only a project or a task has a budget.";
                }

                copy.Budget = patch.Budget;
                problem = CheckBudget(copy);
                if (problem != null)
                {
                    return problem;
                }
            }

            if (copy.Title == target.Title && copy.Detail == target.Detail && copy.Due == target.Due && copy.Budget == target.Budget
                && copy.Starts == target.Starts && copy.Channel == target.Channel && copy.Area == target.Area && copy.ActionId == target.ActionId && copy.Amount == target.Amount)
            {
                return "It would not change anything.";
            }

            copy.Updated = now;
            change.Before = target.Copy();
            change.After = copy.Copy();
            change.ItemId = target.Id;
            book.Items[book.Items.IndexOf(target)] = copy;
            return null;
        }

        private static string Move(WorkBook book, WorkChange change, DateTime now)
        {
            var target = Target(book, change, out var problem);
            if (target == null)
            {
                return problem;
            }

            var status = change.Op == WorkOp.Complete ? WorkStatus.Done : change.Op == WorkOp.Drop ? WorkStatus.Dropped : WorkStatus.Open;
            if (change.Op == WorkOp.Complete && target.Status == WorkStatus.Dropped)
            {
                return "It was dropped.";
            }

            if (target.Status == status)
            {
                return "It is already " + (status == WorkStatus.Open ? "open" : status == WorkStatus.Done ? "done" : "dropped") + ".";
            }

            var copy = target.Copy();
            copy.Status = status;
            copy.Updated = now;
            change.Before = target.Copy();
            change.After = copy.Copy();
            change.ItemId = target.Id;
            book.Items[book.Items.IndexOf(target)] = copy;
            return null;
        }

        private static WorkItem Target(WorkBook book, WorkChange change, out string problem)
        {
            problem = null;
            if (!string.IsNullOrEmpty(change.ItemId))
            {
                var found = book.Find(change.ItemId);
                if (found == null)
                {
                    problem = "That item is no longer there.";
                }

                return found;
            }

            return FindByWords(book, change.ItemWords, null, out problem);
        }

        /// <summary>The one item whose title says <paramref name="words"/>; open ones first, any when nothing open matches.</summary>
        public static WorkItem FindByWords(WorkBook book, string words, WorkKind? kind, out string problem)
        {
            problem = null;
            var wanted = OneLine(words);
            if (wanted.Length == 0)
            {
                problem = "It does not say which item.";
                return null;
            }

            var pool = book.Items.Where(i => !kind.HasValue || i.Kind == kind.Value).ToList();
            foreach (var step in new Func<WorkItem, bool>[]
            {
                i => string.Equals(OneLine(i.Title), wanted, StringComparison.OrdinalIgnoreCase),
                i => OneLine(i.Title).IndexOf(wanted, StringComparison.OrdinalIgnoreCase) >= 0,
            })
            {
                foreach (var openOnly in new[] { true, false })
                {
                    var matches = pool.Where(i => (!openOnly || i.Status == WorkStatus.Open) && step(i)).ToList();
                    if (matches.Count == 1)
                    {
                        return matches[0];
                    }

                    if (matches.Count > 1)
                    {
                        problem = "More than one item says “" + wanted + "”.";
                        return null;
                    }
                }
            }

            problem = "No item says “" + wanted + "”.";
            return null;
        }

        private static string CheckDue(DateTime? due, DateTime now, WorkKind kind)
        {
            if (!due.HasValue)
            {
                return null;
            }

            // A record is about a day that has been (or is today); a plan's dates look ahead.
            if (kind == WorkKind.Record)
            {
                if (due.Value.Date < now.Date.AddYears(-2) || due.Value.Date > now.Date.AddDays(1))
                {
                    return "The date " + due.Value.ToString("d MMM yyyy", CultureInfo.InvariantCulture) + " is too far back, or in the future, for something already counted.";
                }

                return null;
            }

            if (due.Value.Date < now.Date.AddDays(-1) || due.Value.Date > now.Date.AddYears(3))
            {
                return "The date " + due.Value.ToString("d MMM yyyy", CultureInfo.InvariantCulture) + " is too far back or too far ahead.";
            }

            return null;
        }

        /// <summary>Why words the assistant suggested cannot be kept (a phone number or an e-mail address in them), or null.</summary>
        private static string ContactProblem(params string[] texts)
        {
            foreach (var text in texts)
            {
                if (!string.IsNullOrEmpty(text) && PiiMasker.MaskText(text) != text)
                {
                    return "The assistant may not keep a phone number or an e-mail address in the plan. Add it yourself if you want it kept.";
                }
            }

            return null;
        }

        /// <summary>The rules of a record: a known kind, a day it is about, and the number the owner entered.</summary>
        private static string CheckRecord(WorkItem item)
        {
            if (item.Kind != WorkKind.Record)
            {
                return string.IsNullOrWhiteSpace(item.Label) && !item.Amount.HasValue ? null : "Only a record has a kind of number and an amount.";
            }

            if (!RecordLabels.Known(item.Label))
            {
                return "A record is one of: " + string.Join(", ", RecordLabels.All) + ".";
            }

            if (!item.Due.HasValue)
            {
                return "A record needs the day it is about.";
            }

            if (!item.Amount.HasValue && item.Label.Trim().ToLowerInvariant() != RecordLabels.Other)
            {
                return "A record needs the number the owner gave. It is never estimated.";
            }

            if (item.Amount.HasValue && (item.Amount.Value < 0 || item.Amount.Value > MaxBudget))
            {
                return "The amount is not a usable number.";
            }

            return null;
        }

        /// <summary>The campaign fields of a project: its channel and place are words, and it starts before it ends.</summary>
        private static string CheckCampaign(WorkItem item, DateTime now)
        {
            if (item.Kind != WorkKind.Project)
            {
                return item.Starts.HasValue || !string.IsNullOrWhiteSpace(item.Channel) || !string.IsNullOrWhiteSpace(item.Area)
                    ? "Only a project has a start day, a channel or a place."
                    : null;
            }

            if (item.Starts.HasValue)
            {
                if (item.Starts.Value.Date < now.Date.AddYears(-1) || item.Starts.Value.Date > now.Date.AddYears(3))
                {
                    return "The start day " + item.Starts.Value.ToString("d MMM yyyy", CultureInfo.InvariantCulture) + " is too far back or too far ahead.";
                }

                if (item.Due.HasValue && item.Due.Value.Date < item.Starts.Value.Date)
                {
                    return "It ends before it starts.";
                }
            }

            return null;
        }

        private static string CheckBudget(WorkItem item)
        {
            if (!item.Budget.HasValue)
            {
                return null;
            }

            if (item.Kind != WorkKind.Project && item.Kind != WorkKind.Task)
            {
                return "Only a project or a task has a budget.";
            }

            if (item.Budget.Value < 0 || item.Budget.Value > MaxBudget)
            {
                return "The budget is not a usable amount.";
            }

            return null;
        }

        /// <summary>
        /// The plan as the AI is shown it: open projects (a campaign with its days, channel and place) with their open items and the numbers the owner entered, then loose items;
        /// at most <paramref name="maxChars"/> characters. Numbers the owner entered are named as such, so the AI never takes them for the POS's figures.
        /// </summary>
        public static string ForPrompt(WorkBook book, DateTime now, int maxChars = 2500)
        {
            var text = new StringBuilder();
            void Line(string line)
            {
                if (text.Length + line.Length + 1 <= maxChars)
                {
                    text.AppendLine(line);
                }
            }

            foreach (var project in book.Projects.Where(p => p.Status == WorkStatus.Open))
            {
                Line("- Project: " + project.Title + (project.Budget.HasValue ? " (budget set by the owner: " + project.Budget.Value.ToString("0.##", CultureInfo.InvariantCulture) + ")" : "")
                    + CampaignText(project) + DueText(project, now));
                foreach (var item in book.In(project.Id).Where(i => i.Status == WorkStatus.Open && i.Kind != WorkKind.Record))
                {
                    Line("    - " + item.Kind + ": " + item.Title + DueText(item, now));
                }

                foreach (var record in book.In(project.Id).Where(i => i.Status == WorkStatus.Open && i.Kind == WorkKind.Record).OrderByDescending(i => i.Due).Take(MaxRecordsInPrompt))
                {
                    Line("    - " + RecordText(record));
                }
            }

            foreach (var item in book.Open.Where(i => i.Kind != WorkKind.Project && string.IsNullOrEmpty(i.ProjectId)))
            {
                Line("- " + (item.Kind == WorkKind.Record ? RecordText(item) : item.Kind + ": " + item.Title + DueText(item, now)));
            }

            // Whatever the owner typed, phone numbers and e-mail addresses do not go to an AI tool.
            return PiiMasker.MaskText(text.ToString());
        }

        /// <summary>A number the owner entered, as a line: "Number entered by the owner (not from the POS): Money spent on 14 Oct: 4000 (Printer A deposit)".</summary>
        public static string RecordText(WorkItem record) =>
            "Number entered by the owner (not from the POS): " + RecordLabels.Name(record.Label)
            + (record.Due.HasValue ? " on " + record.Due.Value.ToString("d MMM", CultureInfo.InvariantCulture) : "")
            + (record.Amount.HasValue ? ": " + record.Amount.Value.ToString("0.##", CultureInfo.InvariantCulture) : "")
            + " (" + record.Title + ")";

        private static string CampaignText(WorkItem project)
        {
            var parts = new[] { project.Channel, project.Area }.Where(p => !string.IsNullOrWhiteSpace(p)).ToList();
            if (project.Starts.HasValue)
            {
                parts.Add("from " + project.Starts.Value.ToString("d MMM", CultureInfo.InvariantCulture));
            }

            return parts.Count == 0 ? "" : " [" + string.Join("; ", parts) + "]";
        }

        public const int MaxRecordsInPrompt = 8;

        private static string DueText(WorkItem item, DateTime now)
        {
            if (!item.Due.HasValue)
            {
                return "";
            }

            var days = (item.Due.Value.Date - now.Date).Days;
            return days < 0 ? " (was due " + item.Due.Value.ToString("d MMM", CultureInfo.InvariantCulture) + ", overdue)"
                : days == 0 ? " (due today)"
                : " (due " + item.Due.Value.ToString("d MMM", CultureInfo.InvariantCulture) + ")";
        }

        private static string NewId() => Guid.NewGuid().ToString("N").Substring(0, 12);
    }
}
