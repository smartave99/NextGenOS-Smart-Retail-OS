using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Memory;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>"Remember that…" and "Forget…" in the chat, and the review after a chat.</summary>
    public class MemoryChatBackendTests : IDisposable
    {
        private static readonly DateTime Noon = new DateTime(2026, 9, 26, 12, 0, 0);
        private readonly TempFolder _folder = new TempFolder();
        private readonly EchoBackend _ai = new EchoBackend();
        private readonly MemoryStore _store;
        private readonly MemoryChatBackend _chat;

        public MemoryChatBackendTests()
        {
            _store = new MemoryStore(() => _folder.Path, () => Noon);
            _chat = new MemoryChatBackend(_ai, _store, () => Noon);
        }

        public void Dispose() => _folder.Dispose();

        [Fact]
        public async Task Remember_that_is_saved_at_once_without_asking_the_ai()
        {
            var reply = await _chat.AskAsync("Remember that bhujia sells best on Sundays", null, CancellationToken.None);

            Assert.Equal("I will remember that: “Bhujia sells best on Sundays.” It is on the Memory page, where you can change or remove it.", reply.Text);
            Assert.Equal((MemoryCommands.SourceName, false), (reply.Source, reply.IsProblem));
            Assert.Empty(_ai.Questions);
            var saved = _store.Load();
            Assert.Equal("Bhujia sells best on Sundays.", Assert.Single(saved.Shop).Text);
            Assert.Equal("Owner, in chat", Assert.Single(saved.Journey).Source);
        }

        [Fact]
        public async Task What_memory_may_not_keep_is_refused_in_the_chat()
        {
            var reply = await _chat.AskAsync("Remember that Priya's number is 98765 43210", null, CancellationToken.None);

            Assert.True(reply.IsProblem);
            Assert.Equal("I could not remember that. Memory does not keep phone or account numbers.", reply.Text);
            Assert.Empty(_store.Load().Shop);
        }

        [Fact]
        public async Task Forget_removes_the_one_entry_it_points_at()
        {
            await _chat.AskAsync("Remember that bhujia sells best on Sundays", null, CancellationToken.None);
            await _chat.AskAsync("Remember that I prefer answers in Hinglish", null, CancellationToken.None);

            var reply = await _chat.AskAsync("Forget that bhujia sells on Sundays", null, CancellationToken.None);

            Assert.Equal("Forgotten: “Bhujia sells best on Sundays.”", reply.Text);
            Assert.Empty(_store.Load().Shop);
            Assert.Single(_store.Load().Owner);
        }

        [Fact]
        public async Task Forget_asks_which_one_when_several_entries_say_it()
        {
            await _chat.AskAsync("Remember that bhujia sells best on Sundays", null, CancellationToken.None);
            await _chat.AskAsync("Remember that bhujia 200 g is the best seller", null, CancellationToken.None);

            var reply = await _chat.AskAsync("forget bhujia", null, CancellationToken.None);

            Assert.StartsWith("More than one thing I remember says that:\n- Bhujia sells best on Sundays.\n- Bhujia 200 g is the best seller.", reply.Text);
            Assert.Equal(2, _store.Load().Shop.Count);
        }

        [Fact]
        public async Task Everything_else_goes_to_the_ai()
        {
            var question = await _chat.AskAsync("How were sales today?", null, CancellationToken.None);
            var notInMemory = await _chat.AskAsync("Forget the discount, what were sales?", null, CancellationToken.None);
            var aQuestion = await _chat.AskAsync("Remember what we sold last Diwali?", null, CancellationToken.None);

            Assert.Equal(new[] { "How were sales today?", "Forget the discount, what were sales?", "Remember what we sold last Diwali?" }, _ai.Questions);
            Assert.Equal("Answer to: How were sales today?", question.Text);
            Assert.Equal("Answer to: Forget the discount, what were sales?", notInMemory.Text);
            Assert.Equal("Answer to: Remember what we sold last Diwali?", aQuestion.Text);
        }

        [Fact]
        public async Task A_change_refused_while_the_data_moves_says_why()
        {
            var chat = new MemoryChatBackend(_ai, new MovingMemory(), () => Noon);

            var reply = await chat.AskAsync("Remember that bhujia sells best on Sundays", null, CancellationToken.None);

            Assert.True(reply.IsProblem);
            Assert.Equal("I could not remember that. The data folder is being moved.", reply.Text);
        }

        private sealed class MovingMemory : IMemory
        {
            public MemoryBook Load() => new MemoryBook();

            public string Change(MemoryChange change) => throw new InvalidOperationException("The data folder is being moved.");

            public IReadOnlyList<MemoryOutcome> Propose(IEnumerable<MemoryChange> changes, bool askFirst) =>
                throw new InvalidOperationException("The data folder is being moved.");
        }
    }

    public class MemoryReviewerTests : IDisposable
    {
        private readonly TempFolder _folder = new TempFolder();
        private readonly FakeProvider _ai = new FakeProvider(ProviderIds.CodexCli);
        private readonly AssistantSettings _settings = new AssistantSettings();
        private readonly MemoryStore _store;
        private readonly Conversation _chat;
        private readonly MemoryReviewer _reviewer;
        private DateTime _now = new DateTime(2026, 9, 26, 12, 0, 0);

        public MemoryReviewerTests()
        {
            _store = new MemoryStore(() => _folder.Path, () => _now);
            _chat = new Conversation(new MemoryChatBackend(new EchoBackend(), _store, () => _now), () => _now);
            _reviewer = new MemoryReviewer(_chat, _store, () => new ProviderRouter(new IAiProvider[] { _ai }, () => _settings), () => _settings, () => _now);
        }

        public void Dispose() => _folder.Dispose();

        private const string Suggestion = "{\"changes\": [{\"op\": \"add\", \"part\": \"owner\", \"text\": \"Prefers answers in Hinglish.\", \"why\": \"Asked for it\"}]}";

        private async Task AskAsync(string question)
        {
            Assert.True(_chat.Ask(question));
            await _chat.Current;
        }

        [Fact]
        public async Task A_quiet_chat_is_reviewed_once_and_its_suggestions_wait_for_the_owner()
        {
            _ai.Answers(Suggestion);
            await AskAsync("Reply in Hinglish please. How were sales today?");

            Assert.Empty(await _reviewer.ReviewDueAsync(CancellationToken.None)); // not quiet yet
            _now += MemoryReviewer.QuietFor;
            var outcomes = await _reviewer.ReviewDueAsync(CancellationToken.None);
            var again = await _reviewer.ReviewDueAsync(CancellationToken.None);

            Assert.Null(Assert.Single(outcomes).Problem);
            Assert.Empty(again);
            var request = Assert.Single(_ai.Requests);
            Assert.Contains("long-term memory", request.SystemPrompt);
            Assert.Contains("Owner: Reply in Hinglish please. How were sales today?", request.UserPrompt);
            var book = _store.Load();
            Assert.Equal("Prefers answers in Hinglish.", Assert.Single(book.Pending).NewText);
            Assert.Empty(book.Owner);
        }

        [Fact]
        public async Task A_new_chat_has_the_one_before_reviewed_at_once()
        {
            _ai.Answers(Suggestion);
            var due = 0;
            _reviewer.Due += (sender, args) => due++;
            await AskAsync("Reply in Hinglish please. How were sales today?");

            _chat.Clear();
            var outcomes = await _reviewer.ReviewDueAsync(CancellationToken.None);

            Assert.Equal(1, due);
            Assert.Single(outcomes);
            Assert.Single(_store.Load().Pending);
        }

        [Fact]
        public async Task What_the_shop_is_doing_to_sell_more_is_passed_on_to_track()
        {
            _ai.Answers("{\"changes\": [], \"actions\": [{\"title\": \"E-rickshaw ads around the market\", \"kind\": \"advert\", \"cost\": 6000}]}");
            IReadOnlyList<ActionSuggestion> suggested = null;
            _reviewer.ActionsSuggested += (sender, actions) => suggested = actions;
            await AskAsync("This month we are running e-rickshaw ads for ₹6,000. Which products should they show?");

            _chat.Clear();
            var outcomes = await _reviewer.ReviewDueAsync(CancellationToken.None);

            Assert.Empty(outcomes);
            var action = Assert.Single(suggested);
            Assert.Equal(("E-rickshaw ads around the market", 6000m, _now.Date), (action.Title, action.Cost, action.Start));
        }

        [Fact]
        public async Task Only_what_came_after_the_last_review_is_reviewed()
        {
            _ai.Answers("{\"changes\": []}", "{\"changes\": []}");
            await AskAsync("How were sales today?");
            _now += MemoryReviewer.QuietFor;
            await _reviewer.ReviewDueAsync(CancellationToken.None);

            await AskAsync("And yesterday?");
            _chat.Clear();
            await _reviewer.ReviewDueAsync(CancellationToken.None);

            Assert.Equal(2, _ai.Requests.Count);
            Assert.DoesNotContain("How were sales today?", _ai.Requests[1].UserPrompt);
            Assert.Contains("And yesterday?", _ai.Requests[1].UserPrompt);
        }

        [Fact]
        public async Task A_chat_of_only_remember_that_needs_no_review()
        {
            await AskAsync("Remember that bhujia sells best on Sundays");
            _chat.Clear();
            _now += MemoryReviewer.QuietFor;

            Assert.Empty(await _reviewer.ReviewDueAsync(CancellationToken.None));
            Assert.Empty(_ai.Requests);
        }

        [Fact]
        public async Task The_owner_can_turn_learning_off_or_let_it_save_without_asking()
        {
            _settings.Memory.LearnFromChats = false;
            await AskAsync("Reply in Hinglish please.");
            _chat.Clear();
            Assert.Empty(await _reviewer.ReviewDueAsync(CancellationToken.None));
            Assert.Empty(_ai.Requests);

            _settings.Memory.LearnFromChats = true;
            _settings.Memory.AskBeforeSaving = false;
            _ai.Answers(Suggestion);
            await AskAsync("Reply in Hinglish please.");
            _chat.Clear();
            await _reviewer.ReviewDueAsync(CancellationToken.None);

            var book = _store.Load();
            Assert.Empty(book.Pending);
            Assert.Equal("Prefers answers in Hinglish.", Assert.Single(book.Owner).Text);
        }
    }

    /// <summary>Answers every question at once with "Answer to: …".</summary>
    internal sealed class EchoBackend : IChatBackend
    {
        public List<string> Questions { get; } = new List<string>();

        public IReadOnlyList<ChatStarter> Starters { get; } = Array.Empty<ChatStarter>();

        public Task<ChatMessage> AskAsync(string question, IProgress<string> progress, CancellationToken cancellationToken)
        {
            Questions.Add(question);
            return Task.FromResult(new ChatMessage(ChatRole.Assistant, "Answer to: " + question, new DateTime(2026, 9, 26, 12, 0, 0)));
        }

        public Task<ChatMessage> RunAsync(ChatStarter starter, IProgress<string> progress, CancellationToken cancellationToken) =>
            AskAsync(starter.Question, progress, cancellationToken);
    }
}
