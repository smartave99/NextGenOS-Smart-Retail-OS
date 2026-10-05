using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Data;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Assistant
{
    public enum ChatRole
    {
        Owner,
        Assistant,
    }

    /// <summary>A result table in the chat: the first rows of a query result, and how many there were.</summary>
    public sealed class ChatTable
    {
        public const int MaxRowsShown = 100;

        private ChatTable(IReadOnlyList<string> columns, IReadOnlyList<object[]> rows, int totalRows, bool moreInDatabase)
        {
            Columns = columns;
            Rows = rows;
            TotalRows = totalRows;
            MoreInDatabase = moreInDatabase;
        }

        /// <summary>Column names, made unique ("Sales", "Sales (2)") and never empty.</summary>
        public IReadOnlyList<string> Columns { get; }

        public IReadOnlyList<object[]> Rows { get; }

        /// <summary>The rows the query returned, of which <see cref="Rows"/> are shown.</summary>
        public int TotalRows { get; }

        /// <summary>The database had even more rows than were read.</summary>
        public bool MoreInDatabase { get; }

        public static ChatTable From(QueryResult result)
        {
            if (result == null || result.Columns.Count == 0)
            {
                return null;
            }

            var used = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var columns = new List<string>();
            for (var i = 0; i < result.Columns.Count; i++)
            {
                var name = string.IsNullOrWhiteSpace(result.Columns[i]) ? "Column " + (i + 1) : result.Columns[i].Trim();
                var unique = name;
                for (var n = 2; !used.Add(unique); n++)
                {
                    unique = name + " (" + n + ")";
                }

                columns.Add(unique);
            }

            return new ChatTable(columns, result.Rows.Take(MaxRowsShown).ToList(), result.Rows.Count, result.Truncated);
        }

        /// <summary>True when every value in the column is a number (or empty), so it lines up on the right.</summary>
        public bool IsNumeric(int column) =>
            Rows.Any(row => column < row.Length && row[column] != null)
            && Rows.All(row => column >= row.Length || row[column] == null || IsNumber(row[column]));

        private static bool IsNumber(object value) =>
            value is byte || value is short || value is int || value is long || value is decimal || value is double || value is float;
    }

    public enum AttachmentKind
    {
        Photo,
        Voice,
    }

    /// <summary>A photo or voice note sent with a question: a temporary file on this PC, kept while the chat lasts.</summary>
    public sealed class ChatAttachment
    {
        public ChatAttachment(AttachmentKind kind, string path, string name = null)
        {
            Kind = kind;
            Path = path ?? throw new ArgumentNullException(nameof(path));
            Name = string.IsNullOrWhiteSpace(name) ? System.IO.Path.GetFileName(path) : name;
        }

        public AttachmentKind Kind { get; }

        public string Path { get; }

        /// <summary>The file's name, for the screen and the address it is shown at.</summary>
        public string Name { get; }
    }

    /// <summary>One message in the chat.</summary>
    public sealed class ChatMessage
    {
        public ChatMessage(ChatRole role, string text, DateTime at)
        {
            Role = role;
            Text = text ?? "";
            At = at;
        }

        public ChatRole Role { get; }

        public string Text { get; }

        public DateTime At { get; }

        /// <summary>The report or query result, when the answer came from the POS database.</summary>
        public ChatTable Table { get; set; }

        /// <summary>The read-only query that was run, to show on request.</summary>
        public string Sql { get; set; }

        /// <summary>Who answered, e.g. "Codex CLI · 4.2 s".</summary>
        public string Source { get; set; }

        public bool IsProblem { get; set; }

        /// <summary>The owner pressed Stop before the answer came.</summary>
        public bool WasStopped { get; set; }

        /// <summary>Photos and voice notes sent with a question.</summary>
        public IReadOnlyList<ChatAttachment> Attachments { get; set; } = new ChatAttachment[0];

        /// <summary>For an answer to a voice note: what the AI heard, so the owner can check it.</summary>
        public string Heard { get; set; }

        /// <summary>The message for an <see cref="AssistantAnswer"/>, as the side panel always wrote it.</summary>
        public static ChatMessage FromAnswer(AssistantAnswer answer, string sourceName, DateTime at)
        {
            string text;
            if (!string.IsNullOrWhiteSpace(answer.Answer))
            {
                text = answer.Answer.Trim();
            }
            else if (answer.Result != null && answer.Result.Rows.Count == 0)
            {
                text = "No matching records.";
            }
            else
            {
                text = "Here is the report. No AI tool is ready, so there is no written summary.";
            }

            return new ChatMessage(ChatRole.Assistant, text, at)
            {
                Table = ChatTable.From(answer.Result),
                Sql = string.IsNullOrWhiteSpace(answer.Sql) ? null : answer.Sql,
                Source = Describe(sourceName, answer.Duration),
                Heard = string.IsNullOrWhiteSpace(answer.Heard) ? null : answer.Heard.Trim(),
            };
        }

        /// <summary>
        /// What the message at <paramref name="index"/> says in words, for past chats and the memory review: a
        /// question's photos and voice notes are named, with the words the AI heard in a voice note (its answer, the
        /// next message, says them). Other messages are their text.
        /// </summary>
        public static string Words(IReadOnlyList<ChatMessage> messages, int index)
        {
            var message = messages[index];
            var text = message.Text.Trim();
            if (message.Role != ChatRole.Owner || message.Attachments.Count == 0)
            {
                return text;
            }

            var reply = index + 1 < messages.Count && messages[index + 1].Role == ChatRole.Assistant ? messages[index + 1] : null;
            var photos = message.Attachments.Count(a => a.Kind == AttachmentKind.Photo);
            var parts = new List<string>();
            if (text.Length > 0)
            {
                parts.Add(text);
            }

            if (message.Attachments.Any(a => a.Kind == AttachmentKind.Voice))
            {
                parts.Add(string.IsNullOrWhiteSpace(reply?.Heard) ? "(voice note)" : "(voice note) " + reply.Heard.Trim());
            }

            if (photos > 0)
            {
                parts.Add(photos == 1 ? "(photo)" : "(" + photos.ToString(CultureInfo.InvariantCulture) + " photos)");
            }

            return string.Join(" ", parts);
        }

        public static string Describe(string sourceName, TimeSpan duration)
        {
            var took = duration.TotalSeconds.ToString("0.0", CultureInfo.InvariantCulture) + " s";
            return string.IsNullOrWhiteSpace(sourceName) ? took : sourceName + " · " + took;
        }
    }

    /// <summary>A question the chat offers to start with. With a <see cref="Report"/> it runs that built-in report.</summary>
    public sealed class ChatStarter
    {
        public ChatStarter(string title, string question, QuickInsight report = null)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Question = question ?? throw new ArgumentNullException(nameof(question));
            Report = report;
        }

        public string Title { get; }

        public string Question { get; }

        public QuickInsight Report { get; }
    }

    /// <summary>What answers the chat: the POS database (<see cref="BusinessChatBackend"/>), or the demo shop's figures.</summary>
    public interface IChatBackend
    {
        IReadOnlyList<ChatStarter> Starters { get; }

        Task<ChatMessage> AskAsync(string question, IProgress<string> progress, CancellationToken cancellationToken);

        Task<ChatMessage> RunAsync(ChatStarter starter, IProgress<string> progress, CancellationToken cancellationToken);
    }

    /// <summary>A backend that also answers questions sent with photos or voice notes.</summary>
    public interface IAttachmentChat
    {
        Task<ChatMessage> AskAsync(string question, IReadOnlyList<ChatAttachment> attachments, IProgress<string> progress, CancellationToken cancellationToken);
    }

    /// <summary>
    /// Progress that also takes the answer while it is written, and the table found for it, so the chat can show both
    /// before the answer is finished. A backend that gets one (as <see cref="IProgress{T}"/>) may use it or not.
    /// </summary>
    public interface IAnswerProgress : IProgress<string>
    {
        /// <summary>The answer's words so far; called again with more as they arrive.</summary>
        void Draft(string textSoFar);

        /// <summary>The query's result, found before the answer is written.</summary>
        void Found(QueryResult result);
    }

    /// <summary>
    /// The chat with the assistant, shared by every screen that shows it (the app window and the side panel). One
    /// question at a time; the answer arrives even when the screen that asked has been closed. While it is written, its
    /// words so far are <see cref="Draft"/>.
    /// </summary>
    public sealed class Conversation
    {
        public const int MaxQuestionLength = 1000;

        /// <summary>A streaming answer redraws the screens at most this often.</summary>
        public static readonly TimeSpan DraftUpdateInterval = TimeSpan.FromMilliseconds(120);

        private readonly IChatBackend _backend;
        private readonly Func<DateTime> _now;
        private readonly object _gate = new object();
        private readonly List<ChatMessage> _messages = new List<ChatMessage>();
        private CancellationTokenSource _running;
        private Task _work = Task.CompletedTask;
        private int _generation;
        private string _status = "";
        private string _draft = "";
        private ChatTable _draftTable;
        private int _draftUpdatePending;

        public Conversation(IChatBackend backend, Func<DateTime> now = null)
        {
            _backend = backend ?? throw new ArgumentNullException(nameof(backend));
            _now = now ?? (() => DateTime.Now);
        }

        /// <summary>Raised on any thread when the messages, the status or <see cref="Busy"/> change.</summary>
        public event EventHandler Changed;

        /// <summary>Raised for failures that are not the AI's or the database's usual problems, for the log.</summary>
        public event EventHandler<Exception> Failed;

        /// <summary>Raised by <see cref="Clear"/> with the chat that ended, e.g. for the memory review.</summary>
        public event EventHandler<IReadOnlyList<ChatMessage>> Ended;

        public IReadOnlyList<ChatMessage> Messages
        {
            get
            {
                lock (_gate)
                {
                    return _messages.ToArray();
                }
            }
        }

        public bool Busy
        {
            get
            {
                lock (_gate)
                {
                    return _running != null;
                }
            }
        }

        /// <summary>What the running question is doing, e.g. "Running the query on the shop database…".</summary>
        public string Status
        {
            get
            {
                lock (_gate)
                {
                    return _status;
                }
            }
        }

        /// <summary>The running answer's words so far, when the AI streams them; empty otherwise.</summary>
        public string Draft
        {
            get
            {
                lock (_gate)
                {
                    return _draft;
                }
            }
        }

        /// <summary>The table found for the running answer, before its words are finished; null otherwise.</summary>
        public ChatTable DraftTable
        {
            get
            {
                lock (_gate)
                {
                    return _draftTable;
                }
            }
        }

        public IReadOnlyList<ChatStarter> Starters => _backend.Starters;

        /// <summary>The running question's work (a finished task when idle).</summary>
        public Task Current
        {
            get
            {
                lock (_gate)
                {
                    return _work;
                }
            }
        }

        /// <summary>Most photos and voice notes one question can carry.</summary>
        public const int MaxAttachments = 4;

        /// <returns>False when the question is empty or another one is still being answered.</returns>
        public bool Ask(string question) => Ask(question, null);

        /// <summary>Asks with photos or voice notes (the question may then be empty).</summary>
        /// <returns>False when there is nothing to ask or another question is still being answered.</returns>
        public bool Ask(string question, IReadOnlyList<ChatAttachment> attachments)
        {
            question = (question ?? "").Trim();
            var sent = (attachments ?? new ChatAttachment[0]).Where(a => a != null).Take(MaxAttachments).ToList();
            if (question.Length == 0 && sent.Count == 0)
            {
                return false;
            }

            if (question.Length > MaxQuestionLength)
            {
                question = question.Substring(0, MaxQuestionLength);
            }

            if (sent.Count == 0)
            {
                return Start(question, null, (progress, token) => _backend.AskAsync(question, progress, token));
            }

            return Start(question, sent, (progress, token) => _backend is IAttachmentChat withAttachments
                ? withAttachments.AskAsync(question, sent, progress, token)
                : Task.FromResult(Problem("This chat cannot read photos or voice notes. Type the question instead.")));
        }

        public bool Run(ChatStarter starter)
        {
            if (starter == null)
            {
                throw new ArgumentNullException(nameof(starter));
            }

            return Start(starter.Question, null, (progress, token) => _backend.RunAsync(starter, progress, token));
        }

        public void Stop()
        {
            lock (_gate)
            {
                _running?.Cancel();
            }
        }

        /// <summary>A new chat: forgets the messages, and stops a question that is still running.</summary>
        public void Clear()
        {
            ChatMessage[] ended;
            lock (_gate)
            {
                _generation++;
                _running?.Cancel();
                ended = _messages.ToArray();
                _messages.Clear();
            }

            if (ended.Length > 0)
            {
                Ended?.Invoke(this, ended);
            }

            RaiseChanged();
        }

        private bool Start(string question, IReadOnlyList<ChatAttachment> attachments, Func<IProgress<string>, CancellationToken, Task<ChatMessage>> work)
        {
            CancellationTokenSource running;
            int generation;
            lock (_gate)
            {
                if (_running != null)
                {
                    return false;
                }

                running = _running = new CancellationTokenSource();
                generation = _generation;
                _status = "Thinking…";
                _draft = "";
                _draftTable = null;
                _messages.Add(new ChatMessage(ChatRole.Owner, question, _now()) { Attachments = attachments ?? new ChatAttachment[0] });
                _work = Task.Run(() => RunAsync(work, running, generation));
            }

            RaiseChanged();
            return true;
        }

        private async Task RunAsync(Func<IProgress<string>, CancellationToken, Task<ChatMessage>> work, CancellationTokenSource running, int generation)
        {
            var progress = new StatusProgress(this, generation);
            ChatMessage reply;
            try
            {
                reply = await work(progress, running.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (running.IsCancellationRequested)
            {
                reply = new ChatMessage(ChatRole.Assistant, "Stopped.", _now()) { WasStopped = true };
            }
            catch (AiProviderException ex)
            {
                reply = Problem(ex.Message);
            }
            catch (AssistantException ex)
            {
                reply = Problem(ex.Message);
                reply.Sql = string.IsNullOrWhiteSpace(ex.LastSql) ? null : ex.LastSql;
            }
            catch (Exception ex)
            {
                Failed?.Invoke(this, ex);
                reply = Problem("Something went wrong: " + ex.Message);
            }

            lock (_gate)
            {
                if (generation == _generation && reply != null)
                {
                    _messages.Add(reply);
                }

                if (_running == running)
                {
                    _running = null;
                    _status = "";
                    _draft = "";
                    _draftTable = null;
                }
            }

            running.Dispose();
            RaiseChanged();
        }

        private ChatMessage Problem(string text) => new ChatMessage(ChatRole.Assistant, text, _now()) { IsProblem = true };

        private void RaiseChanged() => Changed?.Invoke(this, EventArgs.Empty);

        /// <summary>Raises <see cref="Changed"/> once a little later for any number of calls meanwhile, so a fast stream of
        /// words does not redraw the screens for each one.</summary>
        private void RaiseChangedSoon()
        {
            if (Interlocked.Exchange(ref _draftUpdatePending, 1) == 1)
            {
                return;
            }

            _ = Task.Delay(DraftUpdateInterval).ContinueWith(_ =>
            {
                Interlocked.Exchange(ref _draftUpdatePending, 0);
                RaiseChanged();
            }, TaskScheduler.Default);
        }

        /// <summary>Progress straight to <see cref="Status"/> and <see cref="Draft"/>: there is no UI thread to post to.</summary>
        private sealed class StatusProgress : IAnswerProgress
        {
            private readonly Conversation _owner;
            private readonly int _generation;

            public StatusProgress(Conversation owner, int generation)
            {
                _owner = owner;
                _generation = generation;
            }

            public void Report(string value)
            {
                lock (_owner._gate)
                {
                    if (_owner._generation != _generation || _owner._running == null)
                    {
                        return;
                    }

                    _owner._status = value ?? "";
                }

                _owner.RaiseChanged();
            }

            public void Draft(string textSoFar)
            {
                lock (_owner._gate)
                {
                    if (_owner._generation != _generation || _owner._running == null)
                    {
                        return;
                    }

                    _owner._draft = textSoFar ?? "";
                }

                _owner.RaiseChangedSoon();
            }

            public void Found(QueryResult result)
            {
                var table = ChatTable.From(result);
                lock (_owner._gate)
                {
                    if (_owner._generation != _generation || _owner._running == null)
                    {
                        return;
                    }

                    _owner._draftTable = table;
                }

                _owner.RaiseChanged();
            }
        }
    }

    /// <summary>
    /// Answers from the POS database, the way the side panel always has: the AI writes one read-only query,
    /// <see cref="SqlGuard"/> checks it, and it runs in a transaction that is rolled back. The built-in reports run
    /// their fixed queries, even with no AI tool set up.
    /// </summary>
    public sealed class BusinessChatBackend : IChatBackend, IAttachmentChat
    {
        private readonly Func<ProviderRouter> _router;
        private readonly IQueryExecutor _database;
        private readonly Func<AssistantSettings> _settings;
        private readonly Func<DateTime> _now;
        private readonly Func<string> _memory;

        /// <param name="router">Made fresh for each question, so an AI tool set up a minute ago is used.</param>
        /// <param name="memory">What the assistant remembers, taken for each question; may be null.</param>
        public BusinessChatBackend(Func<ProviderRouter> router, IQueryExecutor database, Func<AssistantSettings> settings, Func<DateTime> now = null, Func<string> memory = null)
        {
            _router = router ?? throw new ArgumentNullException(nameof(router));
            _database = database ?? throw new ArgumentNullException(nameof(database));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _now = now ?? (() => DateTime.Now);
            _memory = memory ?? (() => "");
            Starters = QuickInsights.All.Select(insight => new ChatStarter(insight.Title, insight.Question, insight)).ToList();
        }

        public IReadOnlyList<ChatStarter> Starters { get; }

        public Task<ChatMessage> AskAsync(string question, IProgress<string> progress, CancellationToken cancellationToken) =>
            AskAsync(question, null, progress, cancellationToken);

        public async Task<ChatMessage> AskAsync(string question, IReadOnlyList<ChatAttachment> attachments, IProgress<string> progress, CancellationToken cancellationToken)
        {
            var router = _router();
            var settings = _settings();
            var memory = _memory();
            var answer = await new BusinessAssistant(router, _database, () => settings, _now, () => memory)
                .AskAsync(question, ProviderIds.Auto, progress, cancellationToken, attachments).ConfigureAwait(false);
            return ChatMessage.FromAnswer(answer, NameOf(router, answer.ProviderId), _now());
        }

        public async Task<ChatMessage> RunAsync(ChatStarter starter, IProgress<string> progress, CancellationToken cancellationToken)
        {
            if (starter.Report == null)
            {
                return await AskAsync(starter.Question, progress, cancellationToken).ConfigureAwait(false);
            }

            var router = _router();
            var settings = _settings();
            var summarize = await AnyReadyAsync(router, cancellationToken).ConfigureAwait(false);
            var memory = _memory();
            var answer = await new BusinessAssistant(router, _database, () => settings, _now, () => memory)
                .RunInsightAsync(starter.Report, ProviderIds.Auto, summarize, progress, cancellationToken).ConfigureAwait(false);
            return ChatMessage.FromAnswer(answer, answer.ProviderId == null ? "Report" : NameOf(router, answer.ProviderId), _now());
        }

        private static string NameOf(ProviderRouter router, string providerId) =>
            providerId == null ? "" : router.Find(providerId)?.DisplayName ?? providerId;

        private static async Task<bool> AnyReadyAsync(ProviderRouter router, CancellationToken cancellationToken)
        {
            foreach (var provider in router.PlanOrder(ProviderIds.Auto))
            {
                if ((await router.GetStatusAsync(provider, refresh: false, cancellationToken).ConfigureAwait(false)).IsReady)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
