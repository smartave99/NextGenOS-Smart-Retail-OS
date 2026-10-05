using System;
using System.Collections.Generic;

namespace SmartRetail.AI.Memory
{
    /// <summary>The two parts of the assistant's memory, as in Hermes Agent: what it knows about the shop, and about
    /// the owner.</summary>
    public enum MemoryPart
    {
        /// <summary>Lessons and facts about the shop: what sells when, what worked and what did not.</summary>
        Shop,

        /// <summary>The owner's preferences: language, how answers should be, budget, goals.</summary>
        Owner,
    }

    public enum MemoryOp
    {
        Add,
        Replace,
        Remove,
    }

    public enum MemoryChangeStatus
    {
        /// <summary>Proposed by the AI; waits for the owner's Save or Don't save.</summary>
        Pending,
        Saved,
        Rejected,
        Undone,
    }

    public sealed class MemoryEntry
    {
        public string Text { get; set; } = "";

        public DateTime Added { get; set; }

        /// <summary>Where it came from, e.g. "Chat", "Owner", "Action: E-rickshaw ads".</summary>
        public string Source { get; set; } = "";
    }

    /// <summary>An entry found in the memory file that breaks memory's rules, e.g. after the file was edited by hand:
    /// kept aside, out of every prompt, until the owner removes it.</summary>
    public sealed class SetAsideEntry
    {
        public MemoryPart Part { get; set; }

        public string Text { get; set; } = "";

        /// <summary>Why it was set aside.</summary>
        public string Reason { get; set; } = "";

        public DateTime At { get; set; }
    }

    /// <summary>One change to memory: proposed, saved, rejected or undone. Saved ones make the learning journey.</summary>
    public sealed class MemoryChange
    {
        public string Id { get; set; } = "";

        public MemoryOp Op { get; set; }

        public MemoryPart Part { get; set; }

        /// <summary>For replace and remove: text that picks out the one entry to change.</summary>
        public string OldText { get; set; } = "";

        /// <summary>For add and replace: the new entry.</summary>
        public string NewText { get; set; } = "";

        /// <summary>Why the AI wants this, shown to the owner.</summary>
        public string Why { get; set; } = "";

        public string Source { get; set; } = "";

        public DateTime At { get; set; }

        public MemoryChangeStatus Status { get; set; }

        /// <summary>For a saved replace or remove: the entry as it was, so it can be undone.</summary>
        public string Before { get; set; } = "";
    }

    /// <summary>Everything the memory holds, as kept in the data folder's Memory\memory.json.</summary>
    public sealed class MemoryBook
    {
        public List<MemoryEntry> Shop { get; set; } = new List<MemoryEntry>();

        public List<MemoryEntry> Owner { get; set; } = new List<MemoryEntry>();

        public List<MemoryChange> Pending { get; set; } = new List<MemoryChange>();

        /// <summary>Saved, rejected and undone changes, newest first.</summary>
        public List<MemoryChange> Journey { get; set; } = new List<MemoryChange>();

        /// <summary>Entries from the file that break memory's rules; never in a prompt.</summary>
        public List<SetAsideEntry> SetAside { get; set; } = new List<SetAsideEntry>();

        public List<MemoryEntry> Entries(MemoryPart part) => part == MemoryPart.Shop ? Shop : Owner;

        public void Normalize()
        {
            Shop = Shop ?? new List<MemoryEntry>();
            Owner = Owner ?? new List<MemoryEntry>();
            Pending = Pending ?? new List<MemoryChange>();
            Journey = Journey ?? new List<MemoryChange>();
            SetAside = SetAside ?? new List<SetAsideEntry>();
            SetAside.RemoveAll(e => e == null || string.IsNullOrWhiteSpace(e.Text));
            Shop.RemoveAll(e => e == null || string.IsNullOrWhiteSpace(e.Text));
            Owner.RemoveAll(e => e == null || string.IsNullOrWhiteSpace(e.Text));
            Pending.RemoveAll(c => c == null);
            Journey.RemoveAll(c => c == null);
        }
    }
}
