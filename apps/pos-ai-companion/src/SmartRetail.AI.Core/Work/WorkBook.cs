using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRetail.AI.Work
{
    /// <summary>What a piece of the assistant's own work is.</summary>
    public enum WorkKind
    {
        /// <summary>A goal with a name, an optional budget and the tasks that belong to it (for example "Pilot: e-rickshaw advertising").</summary>
        Project,

        /// <summary>A step to do, perhaps in a project, perhaps with a date.</summary>
        Task,

        /// <summary>Something to be reminded of on a date. The reminder shows in the app; it is not sent to anybody.</summary>
        Reminder,

        /// <summary>A note worth keeping with a project (a decision, a quotation the owner got, a lesson).</summary>
        Note,

        /// <summary>
        /// A number the owner entered by hand about a project or campaign: people counted at the stall, enquiries, an expense, a quotation. It is the owner's own entry,
        /// kept apart from the POS's figures and always shown as entered by the owner. It is never estimated by the assistant.
        /// </summary>
        Record,
    }

    /// <summary>The kinds of <see cref="WorkKind.Record"/> (the words in <see cref="WorkItem.Label"/>).</summary>
    public static class RecordLabels
    {
        public const string Footfall = "footfall";
        public const string Leads = "leads";
        public const string Expense = "expense";
        public const string Quote = "quote";
        public const string Other = "other";

        public static readonly string[] All = { Footfall, Leads, Expense, Quote, Other };

        public static bool Known(string label) => System.Array.IndexOf(All, (label ?? "").Trim().ToLowerInvariant()) >= 0;

        /// <summary>"People counted", "Enquiries", "Money spent", "Quotation", "Other", for the screens.</summary>
        public static string Name(string label)
        {
            switch ((label ?? "").Trim().ToLowerInvariant())
            {
                case Footfall: return "People counted";
                case Leads: return "Enquiries";
                case Expense: return "Money spent";
                case Quote: return "Quotation";
                default: return "Other";
            }
        }
    }

    public enum WorkStatus
    {
        Open,
        Done,
        Dropped,
    }

    public enum WorkOp
    {
        Add,

        /// <summary>Changes the words, the date or the budget of an item.</summary>
        Update,

        Complete,
        Drop,
        Reopen,
    }

    public enum WorkChangeStatus
    {
        /// <summary>Proposed by the assistant, waiting for the owner.</summary>
        Pending,

        Saved,
        Rejected,
        Undone,
    }

    /// <summary>
    /// One project, task, reminder or note. It belongs to the assistant's own store (<see cref="WorkStore"/>), a file of the add-on's own data
    /// folder, and never to the shop's database. <see cref="TenantId"/> and <see cref="SiteId"/> scope it (CLAUDE.md section 15).
    /// </summary>
    public sealed class WorkItem
    {
        public string Id { get; set; } = "";

        public string TenantId { get; set; } = "local";

        public string SiteId { get; set; } = "main";

        public WorkKind Kind { get; set; }

        public string Title { get; set; } = "";

        public string Detail { get; set; } = "";

        /// <summary>The project a task or a note belongs to; empty for a project, a loose task or a reminder.</summary>
        public string ProjectId { get; set; } = "";

        /// <summary>The words of the project the assistant named, which become <see cref="ProjectId"/> when the change is applied.</summary>
        public string ProjectName { get; set; } = "";

        public WorkStatus Status { get; set; }

        /// <summary>When a task is due or a reminder is to show; for a project, the day it ends; for a record, the day it is about.</summary>
        public DateTime? Due { get; set; }

        /// <summary>For a project: the day it starts (with <see cref="Due"/> as its last day, they are a campaign's days).</summary>
        public DateTime? Starts { get; set; }

        /// <summary>For a record: what kind (see <see cref="RecordLabels"/>).</summary>
        public string Label { get; set; } = "";

        /// <summary>For a record: the number the owner entered (people, enquiries, money). Never an estimate.</summary>
        public decimal? Amount { get; set; }

        /// <summary>For a project: how it reaches people, in the owner's words (for example "pamphlets", "posters on e-rickshaws"). Free words, not a fixed list.</summary>
        public string Channel { get; set; } = "";

        /// <summary>For a project: where, in the owner's words (for example "the market road").</summary>
        public string Area { get; set; } = "";

        /// <summary>What the owner set aside for a project or a task, in the shop's own money. Never a price from outside: it is the owner's figure.</summary>
        public decimal? Budget { get; set; }

        /// <summary>The shop action (the Actions page) this project is the plan of, when the owner started it; empty otherwise.</summary>
        public string ActionId { get; set; } = "";

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        /// <summary>"Owner" for a change the owner made, "Chat" for one the assistant proposed.</summary>
        public string Source { get; set; } = "Owner";

        public WorkItem Copy() => (WorkItem)MemberwiseClone();
    }

    /// <summary>One change to the work, and what it replaced, so that it can be undone.</summary>
    public sealed class WorkChange
    {
        public string Id { get; set; } = "";

        public WorkOp Op { get; set; }

        /// <summary>For anything but Add: the item it changes (or words of its title, when the assistant named it).</summary>
        public string ItemId { get; set; } = "";

        public string ItemWords { get; set; } = "";

        /// <summary>For Add: the new item. For Update: the new words, date and budget (empty or null leaves a field as it is).</summary>
        public WorkItem Item { get; set; } = new WorkItem();

        /// <summary>The item as it was before (Update, Complete, Drop, Reopen), or as it was added (so that undoing an Add can find it).</summary>
        public WorkItem Before { get; set; }

        /// <summary>The item as this change left it (Update, Complete, Drop, Reopen): a change is taken back only while the item is still as it left it.</summary>
        public WorkItem After { get; set; }

        public WorkChangeStatus Status { get; set; }

        public string Source { get; set; } = "Owner";

        /// <summary>One short reason, for the owner.</summary>
        public string Why { get; set; } = "";

        public DateTime At { get; set; }

        /// <summary>Changes proposed together (one answer of the assistant) share a group, and are saved or turned down together.</summary>
        public string GroupId { get; set; } = "";

        public WorkChange Copy()
        {
            var copy = (WorkChange)MemberwiseClone();
            copy.Item = Item?.Copy();
            copy.Before = Before?.Copy();
            copy.After = After?.Copy();
            return copy;
        }
    }

    /// <summary>A set of changes the assistant proposed in one answer, waiting for the owner's Save or Don't save.</summary>
    public sealed class WorkProposal
    {
        public string Id { get; set; } = "";

        public DateTime At { get; set; }

        /// <summary>Where it came from, for the owner: "Chat".</summary>
        public string Source { get; set; } = "Chat";

        /// <summary>What the assistant said it was for, in a line.</summary>
        public string Summary { get; set; } = "";

        public List<WorkChange> Changes { get; set; } = new List<WorkChange>();

        /// <summary>What was left out of the assistant's suggestion, and why (so the owner can see nothing was lost silently).</summary>
        public List<string> LeftOut { get; set; } = new List<string>();
    }

    /// <summary>Everything in the assistant's own store: the items, what waits for the owner, and the record of every change.</summary>
    public sealed class WorkBook
    {
        public List<WorkItem> Items { get; set; } = new List<WorkItem>();

        public List<WorkProposal> Pending { get; set; } = new List<WorkProposal>();

        /// <summary>Every change saved, turned down or undone, newest first: the audit trail of the assistant's work.</summary>
        public List<WorkChange> Journey { get; set; } = new List<WorkChange>();

        public void Normalize()
        {
            Items = Items ?? new List<WorkItem>();
            Pending = Pending ?? new List<WorkProposal>();
            Journey = Journey ?? new List<WorkChange>();
        }

        public IEnumerable<WorkItem> Open => Items.Where(i => i.Status == WorkStatus.Open);

        public IEnumerable<WorkItem> Projects => Items.Where(i => i.Kind == WorkKind.Project);

        public IEnumerable<WorkItem> In(string projectId) => Items.Where(i => i.ProjectId == projectId);

        public WorkItem Find(string id) => string.IsNullOrEmpty(id) ? null : Items.FirstOrDefault(i => i.Id == id);
    }
}
