using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Memory
{
    /// <summary>
    /// Hermes Agent's background review, for the shop's chat: when a new chat starts, or the chat has been quiet for
    /// <see cref="QuietFor"/>, the messages not reviewed yet go to the AI (made to think briefly), and what it
    /// suggests is proposed to memory: kept for the owner's Save, or saved at once when the owner chose that. What
    /// the owner said the shop is doing to sell more is passed on, to track (<see cref="ActionsSuggested"/>).
    /// </summary>
    public sealed class MemoryReviewer
    {
        public static readonly TimeSpan QuietFor = TimeSpan.FromMinutes(2);

        private static readonly IReadOnlyList<MemoryOutcome> Nothing = Array.Empty<MemoryOutcome>();

        private readonly Conversation _chat;
        private readonly IMemory _memory;
        private readonly Func<ProviderRouter> _router;
        private readonly Func<AssistantSettings> _settings;
        private readonly Func<DateTime> _now;
        private readonly object _gate = new object();
        private readonly Queue<IReadOnlyList<ChatMessage>> _ended = new Queue<IReadOnlyList<ChatMessage>>();
        private int _reviewed;
        private int _running;

        /// <param name="router">Made for each review; the app makes it think briefly, as the job is small.</param>
        public MemoryReviewer(Conversation chat, IMemory memory, Func<ProviderRouter> router, Func<AssistantSettings> settings, Func<DateTime> now = null)
        {
            _chat = chat ?? throw new ArgumentNullException(nameof(chat));
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
            _router = router ?? throw new ArgumentNullException(nameof(router));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _now = now ?? (() => DateTime.Now);
            _chat.Ended += OnEnded;
        }

        /// <summary>Raised when a chat ends with something to review, so the app can review it now.</summary>
        public event EventHandler Due;

        /// <summary>Raised after a review with what the owner said the shop is doing to sell more, to track.</summary>
        public event EventHandler<IReadOnlyList<ActionSuggestion>> ActionsSuggested;

        /// <summary>A review is running: it will write to memory when the AI answers.</summary>
        public bool Busy => Volatile.Read(ref _running) == 1;

        /// <summary>
        /// Reviews one chat that is due, if any: an ended one first, else the current one once it has been quiet.
        /// Returns what came of each suggestion (nothing when no review was due or the AI suggested nothing).
        /// </summary>
        public async Task<IReadOnlyList<MemoryOutcome>> ReviewDueAsync(CancellationToken cancellationToken)
        {
            if (Interlocked.CompareExchange(ref _running, 1, 0) != 0)
            {
                return Nothing;
            }

            try
            {
                var messages = TakeDue();
                var settings = _settings();
                if (messages == null || !settings.Memory.LearnFromChats)
                {
                    return Nothing;
                }

                var request = MemoryReview.Request(_memory.Load(), messages, _now());
                var response = await _router().CompleteAsync(request, ProviderIds.Auto, cancellationToken).ConfigureAwait(false);
                var actions = MemoryReview.ParseActions(response.Text, _now());
                if (actions.Count > 0)
                {
                    ActionsSuggested?.Invoke(this, actions);
                }

                var changes = MemoryReview.Parse(response.Text);
                return changes.Count == 0 ? Nothing : _memory.Propose(changes, settings.Memory.AskBeforeSaving);
            }
            finally
            {
                Volatile.Write(ref _running, 0);
            }
        }

        private void OnEnded(object sender, IReadOnlyList<ChatMessage> messages)
        {
            bool due;
            lock (_gate)
            {
                var unreviewed = messages.Skip(_reviewed).ToList();
                _reviewed = 0;
                due = WorthReviewing(unreviewed);
                if (due)
                {
                    _ended.Enqueue(unreviewed);
                }
            }

            if (due)
            {
                Due?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>The messages to review, marked as reviewed; null when none are due.</summary>
        private IReadOnlyList<ChatMessage> TakeDue()
        {
            lock (_gate)
            {
                if (_ended.Count > 0)
                {
                    return _ended.Dequeue();
                }

                var messages = _chat.Messages;
                if (_chat.Busy || messages.Count <= _reviewed || _now() - messages[messages.Count - 1].At < QuietFor)
                {
                    return null;
                }

                var unreviewed = messages.Skip(_reviewed).ToList();
                _reviewed = messages.Count;
                return WorthReviewing(unreviewed) ? unreviewed : null;
            }
        }

        /// <summary>Something the AI answered: not only "Remember that…" and problems.</summary>
        private static bool WorthReviewing(IReadOnlyList<ChatMessage> messages) =>
            messages.Any(m => m.Role == ChatRole.Assistant && !m.IsProblem && m.Source != MemoryCommands.SourceName);
    }
}
