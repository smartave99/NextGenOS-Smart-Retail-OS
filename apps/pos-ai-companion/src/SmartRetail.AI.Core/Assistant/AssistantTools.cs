using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRetail.AI.Assistant
{
    /// <summary>What a tool of the assistant can reach.</summary>
    public enum ToolReach
    {
        /// <summary>Reads the assistant's own data (its memory, its plan, earlier chats).</summary>
        OwnRead,

        /// <summary>Writes the assistant's own data. It never writes anything of the shop.</summary>
        OwnWrite,

        /// <summary>Reads the shop's database, through the guard, in a transaction that is rolled back.</summary>
        ShopRead,

        /// <summary>Would change the shop's database, files or settings. No tool may have this reach: the value exists so that the rule is written in one place and a tool that asks for it is refused.</summary>
        ShopWrite,

        /// <summary>Does something outside the computer: sends, publishes, orders, prints for others. None exists yet; one needs the owner's approval each time.</summary>
        External,

        /// <summary>Spends the owner's money, or an outside provider's paid quota beyond the owner's limit. None exists yet; one needs the owner's approval each time.</summary>
        Spends,
    }

    /// <summary>One thing the assistant is allowed to do, and what keeps it safe.</summary>
    public sealed class ToolInfo
    {
        public ToolInfo(string name, string description, ToolReach reaches, bool needsOwnerApproval, string guardedBy)
        {
            Name = name;
            Description = description;
            Reaches = reaches;
            NeedsOwnerApproval = needsOwnerApproval;
            GuardedBy = guardedBy ?? "";
        }

        public string Name { get; }

        /// <summary>In plain words, for the owner.</summary>
        public string Description { get; }

        public ToolReach Reaches { get; }

        /// <summary>Whether the owner's OK is needed before it takes effect. For a tool that keeps something of the assistant's own, the owner may let it save without asking (Settings); that is the owner's choice and is audited.</summary>
        public bool NeedsOwnerApproval { get; }

        /// <summary>What protects it, in the code's own words (for the tests and the review).</summary>
        public string GuardedBy { get; }
    }

    /// <summary>
    /// The assistant's tools: a short list written down here and nowhere else. The AI never runs a command, reads a file or opens a connection of its own;
    /// the application runs one of these on a route it has chosen. Anything not on the list does not exist for the assistant. The list cannot contain a
    /// tool that changes the shop (<see cref="Refuse"/>), and one that goes outside the computer or spends money always waits for the owner.
    /// </summary>
    public static class AssistantTools
    {
        public static IReadOnlyList<ToolInfo> All { get; } = Build();

        /// <summary>Why <paramref name="tool"/> may not be on the list, or null when it may.</summary>
        public static string Refuse(ToolInfo tool)
        {
            if (tool == null)
            {
                throw new ArgumentNullException(nameof(tool));
            }

            if (tool.Reaches == ToolReach.ShopWrite)
            {
                return "“" + tool.Name + "” would change the shop's database, files or settings. The assistant never does that.";
            }

            if ((tool.Reaches == ToolReach.External || tool.Reaches == ToolReach.Spends) && !tool.NeedsOwnerApproval)
            {
                return "“" + tool.Name + "” goes outside the computer or spends money, so it needs the owner's approval each time.";
            }

            if (tool.Reaches == ToolReach.ShopRead && string.IsNullOrWhiteSpace(tool.GuardedBy))
            {
                return "“" + tool.Name + "” reads the shop's database and must say what guards it.";
            }

            return null;
        }

        private static IReadOnlyList<ToolInfo> Build()
        {
            var tools = new List<ToolInfo>
            {
                new ToolInfo("shop_query", "Reads the shop's figures: one SELECT, checked by the safety check, run read-only, with personal details hidden.", ToolReach.ShopRead, false,
                    "SqlGuard; a transaction that is rolled back; PiiMasker; a database login that can only read (sql/create_readonly_login.sql)"),
                new ToolInfo("chat_recall", "Looks back in the owner's earlier chats for what was said about a topic.", ToolReach.OwnRead, false, "ChatHistory; personal details were hidden when it was saved"),
                new ToolInfo("memory_read", "Reads what the assistant remembers about the shop and the owner.", ToolReach.OwnRead, false, "MemoryStore"),
                new ToolInfo("memory_propose", "Suggests something worth remembering. It is kept when the owner says so.", ToolReach.OwnWrite, true, "MemoryRules; the owner's Save; an undo"),
                new ToolInfo("plan_read", "Reads the owner's projects, tasks and reminders.", ToolReach.OwnRead, false, "WorkStore"),
                new ToolInfo("plan_propose", "Suggests projects, tasks, reminders and notes for the owner's plan. They are kept when the owner says so.", ToolReach.OwnWrite, true, "WorkRules; the owner's Save; an undo"),
            };

            foreach (var tool in tools)
            {
                var problem = Refuse(tool);
                if (problem != null)
                {
                    throw new InvalidOperationException(problem);
                }
            }

            return tools.AsReadOnly();
        }
    }
}
