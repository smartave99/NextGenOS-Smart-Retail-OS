using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Data;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Assistant
{
    public sealed class AssistantAnswer
    {
        public string Question { get; set; }

        /// <summary>The AI's answer; null when a quick insight ran without an AI summary.</summary>
        public string Answer { get; set; }

        public string Sql { get; set; }

        public QueryResult Result { get; set; }

        /// <summary>The provider that answered; null when no AI was used.</summary>
        public string ProviderId { get; set; }

        public TimeSpan Duration { get; set; }

        /// <summary>For a voice question: what the AI heard.</summary>
        public string Heard { get; set; }
    }

    public sealed class AssistantException : Exception
    {
        public AssistantException(string message, string lastSql = null, Exception innerException = null)
            : base(message, innerException)
        {
            LastSql = lastSql;
        }

        public string LastSql { get; }
    }

    /// <summary>Answers questions about the shop: the AI writes one read-only query, <see cref="SqlGuard"/>
    /// checks it, it runs on the POS database, and the AI explains the (masked) result.</summary>
    public sealed class BusinessAssistant
    {
        /// <summary>Rows kept for the on-screen grid; the AI sees at most MaxRowsSharedWithAi of them.</summary>
        public const int MaxDisplayRows = 500;

        private const int MaxQueryAttempts = 2;
        private static readonly TimeSpan SchemaCacheDuration = TimeSpan.FromMinutes(30);

        private readonly ProviderRouter _router;
        private readonly IQueryExecutor _database;
        private readonly Func<AssistantSettings> _settings;
        private readonly Func<DateTime> _now;
        private readonly Func<string> _memory;
        private string _schemaText;
        private string _schemaKey;
        private DateTime _schemaLoadedAt;

        /// <param name="memory">What the assistant remembers from earlier conversations, for the prompts; may be null.</param>
        public BusinessAssistant(ProviderRouter router, IQueryExecutor database, Func<AssistantSettings> settings, Func<DateTime> now = null, Func<string> memory = null)
        {
            _router = router ?? throw new ArgumentNullException(nameof(router));
            _database = database ?? throw new ArgumentNullException(nameof(database));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _now = now ?? (() => DateTime.Now);
            _memory = memory ?? (() => "");
        }

        /// <param name="attachments">Photos and voice notes sent with the question, which the AI looks at or listens to
        /// when it writes the query and the answer; the question may then be empty.</param>
        public async Task<AssistantAnswer> AskAsync(string question, string providerSelection, IProgress<string> progress, CancellationToken cancellationToken,
            IReadOnlyList<ChatAttachment> attachments = null)
        {
            var photos = (attachments ?? new ChatAttachment[0]).Where(a => a.Kind == AttachmentKind.Photo).Select(a => a.Path).ToList();
            var voice = (attachments ?? new ChatAttachment[0]).Where(a => a.Kind == AttachmentKind.Voice).Select(a => a.Path).ToList();
            if (string.IsNullOrWhiteSpace(question) && photos.Count == 0 && voice.Count == 0)
            {
                throw new ArgumentException("Type a question first.", nameof(question));
            }

            question = question ?? "";

            var stopwatch = Stopwatch.StartNew();
            var settings = _settings();
            if (!settings.Privacy.AllowAiWrittenQueries)
            {
                return new AssistantAnswer
                {
                    Question = question,
                    Answer = "Questions that need a new database query are turned off in Settings → Privacy. The quick insights still work.",
                    Duration = stopwatch.Elapsed,
                };
            }

            progress?.Report("Reading the shop's database layout…");
            var schema = await GetSchemaAsync(settings.Privacy, cancellationToken).ConfigureAwait(false);
            var guard = SchemaCatalog.CreateGuard(settings.Privacy);
            var selection = providerSelection;
            string previousSql = null;
            string feedback = null;
            string heard = null;

            for (var attempt = 1; attempt <= MaxQueryAttempts; attempt++)
            {
                var request = Prompts.SqlRequest(schema, question, _now(), settings.Privacy.MaxRowsSharedWithAi, previousSql, feedback, _memory(), photos.Count, voice.Count > 0);
                request.Images.AddRange(photos);
                request.Audio.AddRange(voice);
                var reply = await _router.CompleteAsync(request, selection, cancellationToken, progress).ConfigureAwait(false);

                // Keep the provider that wrote the query for the rest of this question.
                selection = reply.ProviderId;
                var plan = SqlPlan.Parse(reply.Text);
                if (voice.Count > 0 && !string.IsNullOrWhiteSpace(plan.Heard))
                {
                    // The words heard are the question from here on, for the answer and the screen.
                    heard = plan.Heard.Trim();
                }

                if (string.IsNullOrWhiteSpace(plan.Sql))
                {
                    return new AssistantAnswer
                    {
                        Question = question,
                        Answer = string.IsNullOrWhiteSpace(plan.Explanation) ? reply.Text : plan.Explanation,
                        ProviderId = reply.ProviderId,
                        Duration = stopwatch.Elapsed,
                        Heard = heard,
                    };
                }

                var check = guard.Check(plan.Sql);
                if (!check.IsAllowed)
                {
                    previousSql = plan.Sql;
                    feedback = check.Reason;
                    progress?.Report("The safety check refused the query (" + check.Reason + ") — asking for a corrected one…");
                    continue;
                }

                QueryResult result;
                try
                {
                    progress?.Report("Running the query on the shop database…");
                    result = await _database.QueryAsync(check.Sql, null, MaxDisplayRows, cancellationToken).ConfigureAwait(false);
                    (progress as IAnswerProgress)?.Found(result);
                }
                catch (QueryExecutionException ex) when (!ex.IsConnectionProblem)
                {
                    previousSql = check.Sql;
                    feedback = "SQL Server returned an error: " + ex.Message;
                    progress?.Report("The database rejected the query — asking for a corrected one…");
                    continue;
                }
                catch (QueryExecutionException ex)
                {
                    throw new AssistantException("Cannot reach the POS database: " + ex.Message, check.Sql, ex);
                }

                var asked = heard != null ? (question.Length > 0 ? question + " (said: " + heard + ")" : heard) : question;
                var answer = await SummarizeAsync(asked, check.Sql, result, selection, settings, progress, cancellationToken, photos).ConfigureAwait(false);
                return new AssistantAnswer
                {
                    Question = question,
                    Answer = answer.Text,
                    Sql = check.Sql,
                    Result = result,
                    ProviderId = answer.ProviderId,
                    Duration = stopwatch.Elapsed,
                    Heard = heard,
                };
            }

            throw new AssistantException("The AI could not write a usable query for this question. Last problem: " + feedback, previousSql);
        }

        /// <summary>Runs a built-in report; with <paramref name="summarize"/> the AI also explains it.</summary>
        public async Task<AssistantAnswer> RunInsightAsync(QuickInsight insight, string providerSelection, bool summarize, IProgress<string> progress, CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();
            progress?.Report("Running \"" + insight.Title + "\"…");
            QueryResult result;
            try
            {
                result = await _database.QueryAsync(insight.Sql, null, MaxDisplayRows, cancellationToken).ConfigureAwait(false);
            }
            catch (QueryExecutionException ex)
            {
                throw new AssistantException((ex.IsConnectionProblem ? "Cannot reach the POS database: " : "The report failed: ") + ex.Message, insight.Sql, ex);
            }

            (progress as IAnswerProgress)?.Found(result);

            var answer = new AssistantAnswer { Question = insight.Question, Sql = insight.Sql, Result = result };
            if (summarize)
            {
                var summary = await SummarizeAsync(insight.Question, insight.Sql, result, providerSelection, _settings(), progress, cancellationToken).ConfigureAwait(false);
                answer.Answer = summary.Text;
                answer.ProviderId = summary.ProviderId;
            }

            answer.Duration = stopwatch.Elapsed;
            return answer;
        }

        /// <summary>Drops the cached schema, e.g. after switching to another company database.</summary>
        public void ForgetSchema()
        {
            _schemaText = null;
        }

        private Task<AiResponse> SummarizeAsync(string question, string sql, QueryResult result, string selection, AssistantSettings settings, IProgress<string> progress, CancellationToken cancellationToken,
            IReadOnlyList<string> photos = null)
        {
            progress?.Report("Writing the answer…");
            var shared = settings.Privacy.MaskContactDetails ? PiiMasker.Mask(result) : result;
            var table = ResultFormatter.ToPromptTable(shared, settings.Privacy.MaxRowsSharedWithAi);
            var request = Prompts.AnswerRequest(question, sql, table, _now(), _memory(), photos?.Count ?? 0);
            if (photos != null)
            {
                request.Images.AddRange(photos);
            }

            if (progress is IAnswerProgress answer)
            {
                // The answer's words show as they are written (the query itself never does).
                request.OnText = answer.Draft;
            }

            return _router.CompleteAsync(request, selection, cancellationToken, progress);
        }

        private async Task<string> GetSchemaAsync(PrivacySettings privacy, CancellationToken cancellationToken)
        {
            var tables = SchemaCatalog.AllowedTables(privacy);
            var key = string.Join(",", tables);
            if (_schemaText != null && _schemaKey == key && DateTime.UtcNow - _schemaLoadedAt < SchemaCacheDuration)
            {
                return _schemaText;
            }

            IReadOnlyList<ColumnInfo> columns;
            try
            {
                columns = await SchemaCatalog.LoadColumnsAsync(_database, tables, cancellationToken).ConfigureAwait(false);
            }
            catch (QueryExecutionException ex) when (ex.IsConnectionProblem)
            {
                throw new AssistantException("Cannot reach the POS database: " + ex.Message, null, ex);
            }
            catch (QueryExecutionException)
            {
                // No permission to read INFORMATION_SCHEMA: fall back to the layout shipped with the app.
                columns = new ColumnInfo[0];
            }

            if (columns.Count == 0)
            {
                columns = SchemaCatalog.BuiltInColumns(tables);
            }

            _schemaText = SchemaCatalog.DescribeForPrompt(columns);
            _schemaKey = key;
            _schemaLoadedAt = DateTime.UtcNow;
            return _schemaText;
        }
    }
}
