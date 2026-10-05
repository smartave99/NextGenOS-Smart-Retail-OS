using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Assistant;

namespace SmartRetail.AI.Memory
{
    /// <summary>
    /// Ask AI with a memory: "Remember that…" is saved at once and "Forget…" removes the entry it points at, without
    /// asking an AI. Everything else goes to the chat it wraps, which is given what the assistant remembers.
    /// </summary>
    public sealed class MemoryChatBackend : IChatBackend, IAttachmentChat
    {
        private readonly IChatBackend _inner;
        private readonly IMemory _memory;
        private readonly Func<DateTime> _now;

        public MemoryChatBackend(IChatBackend inner, IMemory memory, Func<DateTime> now = null)
        {
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
            _now = now ?? (() => DateTime.Now);
        }

        public IReadOnlyList<ChatStarter> Starters => _inner.Starters;

        public Task<ChatMessage> AskAsync(string question, IProgress<string> progress, CancellationToken cancellationToken)
        {
            var reply = Remember(question) ?? Forget(question);
            return reply != null ? Task.FromResult(reply) : _inner.AskAsync(question, progress, cancellationToken);
        }

        /// <summary>A question with photos or voice notes goes to the AI: "Remember…" and "Forget…" are typed.</summary>
        public Task<ChatMessage> AskAsync(string question, IReadOnlyList<ChatAttachment> attachments, IProgress<string> progress, CancellationToken cancellationToken)
        {
            if (attachments == null || attachments.Count == 0)
            {
                return AskAsync(question, progress, cancellationToken);
            }

            return _inner is IAttachmentChat withAttachments
                ? withAttachments.AskAsync(question, attachments, progress, cancellationToken)
                : Task.FromResult(new ChatMessage(ChatRole.Assistant, "This chat cannot read photos or voice notes. Type the question instead.", _now()) { IsProblem = true });
        }

        public Task<ChatMessage> RunAsync(ChatStarter starter, IProgress<string> progress, CancellationToken cancellationToken) =>
            _inner.RunAsync(starter, progress, cancellationToken);

        private ChatMessage Remember(string question)
        {
            var change = MemoryCommands.RememberRequest(question);
            if (change == null)
            {
                return null;
            }

            var problem = Save(change);
            return problem == null
                ? Reply("I will remember that: “" + change.NewText + "” It is on the Memory page, where you can change or remove it.")
                : Reply("I could not remember that. " + problem, problem: true);
        }

        private ChatMessage Forget(string question)
        {
            var what = MemoryCommands.ForgetRequest(question);
            if (string.IsNullOrEmpty(what))
            {
                return null;
            }

            var matches = MemoryCommands.Matches(_memory.Load(), what);
            if (matches.Count == 0)
            {
                // Nothing remembered says it: a question for the AI, e.g. "forget the discount, what were sales?".
                return null;
            }

            if (matches.Count > 1)
            {
                return Reply("More than one thing I remember says that:\n"
                    + string.Join("\n", matches.Select(m => "- " + m.Entry.Text))
                    + "\nSay which one, or change them on the Memory page.");
            }

            var match = matches[0];
            var problem = Save(new MemoryChange { Op = MemoryOp.Remove, Part = match.Part, OldText = match.Entry.Text, Source = "Owner, in chat" });
            return problem == null
                ? Reply("Forgotten: “" + match.Entry.Text + "”")
                : Reply("I could not forget it. " + problem, problem: true);
        }

        private string Save(MemoryChange change)
        {
            try
            {
                return _memory.Change(change);
            }
            catch (InvalidOperationException ex)
            {
                // E.g. the data folder is being moved.
                return ex.Message;
            }
        }

        private ChatMessage Reply(string text, bool problem = false) =>
            new ChatMessage(ChatRole.Assistant, text, _now()) { Source = MemoryCommands.SourceName, IsProblem = problem };
    }
}
