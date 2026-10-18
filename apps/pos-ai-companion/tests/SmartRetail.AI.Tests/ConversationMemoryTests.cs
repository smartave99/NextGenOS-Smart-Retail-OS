using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Data;
using SmartRetail.AI.Memory;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>
    /// The chat remembers itself: every question is asked with the chat so far in its prompt (the AI tools keep no chat of their own),
    /// a follow-up such as "yes, tell me" is understood, and only a question about the shop's figures goes to the shop's database.
    /// These tests read what each prompt really contained.
    /// </summary>
    public class ConversationMemoryTests : IDisposable
    {
        private static readonly DateTime Noon = new DateTime(2026, 10, 12, 12, 0, 0);

        private const string BillsQuery = "{\"sql\": \"SELECT COUNT(*) AS Bills, SUM(GrandTotal) AS Sales FROM InvoiceInfo WHERE CAST(InvoiceDate AS date) = '2026-10-12'\", \"explanation\": \"Bills this week\"}";

        private readonly TempFolder _folder = new TempFolder();
        private readonly AssistantSettings _settings = TestSettings.Create().Settings;
        private readonly FakeProvider _codex = new FakeProvider(ProviderIds.CodexCli);
        private readonly FakeProvider _claude = new FakeProvider(ProviderIds.ClaudeCli);
        private readonly FakeQueryExecutor _database = new FakeQueryExecutor();

        public ConversationMemoryTests()
        {
            _database.Handler = sql => sql.Contains("INFORMATION_SCHEMA")
                ? FakeQueryExecutor.Table(new[] { "TABLE_NAME", "COLUMN_NAME", "DATA_TYPE", "CHARACTER_MAXIMUM_LENGTH" },
                    new object[] { "InvoiceInfo", "Inv_ID", "int", null },
                    new object[] { "InvoiceInfo", "GrandTotal", "decimal", null })
                : FakeQueryExecutor.Table(new[] { "Bills", "Sales" }, new object[] { 352, 91000.5m });
        }

        public void Dispose() => _folder.Dispose();

        private Conversation NewChat(ContextBudget budget = null, Func<string, string> recall = null)
        {
            var backend = new BusinessChatBackend(() => new ProviderRouter(new IAiProvider[] { _codex, _claude }, () => _settings), _database, () => _settings, () => Noon);
            return new Conversation(backend, () => Noon, budget, recall);
        }

        private static async Task Say(Conversation chat, string text)
        {
            Assert.True(chat.Ask(text), "the question was not taken: " + text);
            await chat.Current;
        }

        private IEnumerable<string> ShopQueries => _database.Queries.Where(q => !q.Contains("INFORMATION_SCHEMA"));

        [Fact]
        public async Task The_owners_real_conversation_goes_on_instead_of_asking_what_the_question_is()
        {
            // "I was thinking of e-rickshaw poster advertising ... What do you think?" then "Yes, tell me": the second used to be answered as a new question.
            _codex.Answers(
                "E-rickshaw posters reach people who pass your market every day, but only a small test can show whether they bring buyers.",
                "Start with a pilot: three rickshaws on the two busiest routes for two weeks, and ask each new customer how they heard of the shop.");
            var chat = NewChat();

            await Say(chat, "I was thinking of doing e-rickshaw poster advertising because our early sales were high when we had distributed pamphlets. What do you think?");
            await Say(chat, "Yes, tell me");

            Assert.Empty(ShopQueries);
            Assert.Empty(_database.Queries);   // advice needs no query, and not even the database's layout
            Assert.Equal(2, _codex.Requests.Count);
            var second = _codex.Requests[1];
            Assert.Contains("Owner: I was thinking of doing e-rickshaw poster advertising", second.UserPrompt);
            Assert.Contains("You: E-rickshaw posters reach people who pass your market", second.UserPrompt);
            Assert.Contains("Owner's new message: Yes, tell me", second.UserPrompt);
            Assert.Contains("Before the new message the owner was talking about: I was thinking of doing e-rickshaw poster advertising", second.UserPrompt);
            Assert.DoesNotContain("data analyst", second.SystemPrompt);
            Assert.Contains("Never ask the owner to repeat what is already in the conversation", second.SystemPrompt);
            Assert.StartsWith("Start with a pilot", chat.Messages.Last().Text);
            Assert.Equal(RequestKind.General, chat.Messages.Last().Route);
        }

        [Fact]
        public async Task A_ten_message_chat_carries_every_earlier_point_into_the_last_prompt()
        {
            _codex.Answers(
                BillsQuery, "Bills fell from 410 to 352 week on week; the average bill is about the same.",       // 1: sales are falling (the shop's figures)
                "{\"sql\": null, \"explanation\": \"This is about visitors, which bills do not measure.\"}",       // 2: fewer customers (the AI sees no query is needed)
                "Bills are not visitors: fewer bills may mean fewer people, or the same people buying less often.",
                "E-rickshaw posters give steady local sight for a small fee, but they are hard to trace to a sale.",   // 3: e-rickshaws
                "Pamphlets reach one lane at a time and can carry an offer; posters carry only the name.",             // 4: compare with pamphlets
                "Test the pamphlets with an offer code first: they are cheaper and traceable.",                        // 5: which first
                "30-day plan: week 1 print and brief, weeks 2 to 3 distribute, week 4 count the codes and the bills.");   // 6: a plan

            var chat = NewChat();
            await Say(chat, "Our sales are falling.");
            await Say(chat, "I think fewer customers are coming.");
            await Say(chat, "What about advertising on e-rickshaws?");
            await Say(chat, "Compare it with pamphlets.");
            await Say(chat, "Which should we test first?");
            await Say(chat, "Make a 30-day plan for it.");

            Assert.Single(ShopQueries);   // only the first message was a question about the shop's figures
            var plan = _codex.Requests.Last().UserPrompt;
            Assert.Contains("Our sales are falling.", plan);
            Assert.Contains("I think fewer customers are coming.", plan);
            Assert.Contains("What about advertising on e-rickshaws?", plan);
            Assert.Contains("Compare it with pamphlets.", plan);
            Assert.Contains("Test the pamphlets with an offer code first", plan);
            Assert.Contains("Owner's new message: Make a 30-day plan for it.", plan);
            Assert.Equal(12, chat.Messages.Count);
            Assert.StartsWith("30-day plan", chat.Messages.Last().Text);

            // The second message was not a figures question and not clearly advice: the AI said no query was needed, and it was then answered as a conversation.
            Assert.StartsWith("Bills are not visitors", chat.Messages[3].Text);
            Assert.Contains("Our sales are falling.", _codex.Requests[2].UserPrompt);   // the planner of message 2 also had the chat so far
        }

        [Fact]
        public async Task A_question_about_the_figures_still_goes_to_the_database_and_has_the_chat_in_both_prompts()
        {
            _codex.Answers(
                "Pamphlets reach one lane at a time.",
                BillsQuery, "352 bills this week, ₹91,000 in sales.");
            var chat = NewChat();
            await Say(chat, "What do you think about pamphlets for the shop?");
            await Say(chat, "How many bills did we make this week?");

            Assert.Single(ShopQueries);
            Assert.Contains("Pamphlets reach one lane at a time.", _codex.Requests[1].UserPrompt);   // the query-writing prompt
            Assert.Contains("Pamphlets reach one lane at a time.", _codex.Requests[2].UserPrompt);   // the answer-writing prompt
            Assert.Equal(RequestKind.Data, chat.Messages.Last().Route);
            Assert.NotNull(chat.Messages.Last().Table);
        }

        [Fact]
        public async Task What_the_figures_mean_is_asked_of_the_AI_with_the_figures_and_told_to_keep_facts_and_causes_apart()
        {
            _codex.Answers("Pamphlets worked at the opening.", BillsQuery, "Bills fell 14%. That does not show why.");
            var chat = NewChat();
            await Say(chat, "We used pamphlets at the opening, what do you think of them?");
            await Say(chat, "Why are our sales falling? Compare this month with last month.");

            var answerPrompt = _codex.Requests[2];
            Assert.Contains("keeping the two apart", answerPrompt.SystemPrompt);
            Assert.Contains("fewer bills do not prove fewer visitors", answerPrompt.SystemPrompt);
            Assert.Equal(RequestKind.Hybrid, chat.Messages.Last().Route);
        }

        [Fact]
        public async Task When_the_AI_says_no_query_is_needed_the_question_is_answered_as_a_conversation_and_not_refused()
        {
            _codex.Answers("{\"sql\": null, \"explanation\": \"Not a question about the shop's data.\"}", "You could start with the lane nearest the shop.");
            var chat = NewChat();
            await Say(chat, "Hmm, nearby people do not know us");

            Assert.Equal("You could start with the lane nearest the shop.", chat.Messages.Last().Text);
            Assert.Contains("business assistant", _codex.Requests[1].SystemPrompt);
            Assert.DoesNotContain("data analyst", _codex.Requests[1].SystemPrompt);
        }

        [Fact]
        public async Task If_that_second_step_cannot_be_reached_what_the_first_one_said_is_the_answer()
        {
            _codex.AnswersWith(request =>
            {
                // The first call (the query-writing one) answers that no query is needed; the tool then stops for the next call.
                _codex.Failure = new AiProviderException(ProviderIds.CodexCli, "the tool stopped", canFallback: false);
                return "{\"sql\": null, \"explanation\": \"This is about advertising, not figures.\"}";
            });
            var chat = NewChat();
            await Say(chat, "Hmm, nearby people do not know us");
            Assert.Equal("This is about advertising, not figures.", chat.Messages.Last().Text);
            Assert.False(chat.Messages.Last().IsProblem);
        }

        [Fact]
        public async Task A_failed_question_stays_in_the_chat_as_a_question_and_its_failure_is_never_shown_to_the_AI_as_an_answer()
        {
            _codex.Failure = new AiProviderException(ProviderIds.CodexCli, "CODEX-DOWN-9731");
            _claude.Failure = new AiProviderException(ProviderIds.ClaudeCli, "CLAUDE-DOWN-4412");
            var chat = NewChat();
            await Say(chat, "How can we make more people know about the shop?");
            Assert.True(chat.Messages.Last().IsProblem);

            _codex.Failure = null;
            _codex.Answers("Let us start with the lane nearest the shop.");
            await Say(chat, "Please try again");

            var prompt = _codex.Requests.Last().UserPrompt;
            Assert.Contains("Owner: How can we make more people know about the shop?", prompt);
            Assert.Contains("got no answer", prompt);
            Assert.DoesNotContain("CODEX-DOWN-9731", prompt);
            Assert.DoesNotContain("CLAUDE-DOWN-4412", prompt);
            Assert.Equal("Let us start with the lane nearest the shop.", chat.Messages.Last().Text);
        }

        [Fact]
        public async Task When_the_owner_stops_a_question_it_stays_in_the_chat_and_the_word_Stopped_is_not_an_answer()
        {
            var backend = new HangingBackend();
            var chat = new Conversation(backend, () => Noon);
            Assert.True(chat.Ask("Make a poster plan for the e-rickshaws"));
            await backend.Started.Task;
            chat.Stop();
            await chat.Current;
            Assert.Equal("Stopped.", chat.Messages.Last().Text);

            Assert.True(chat.Ask("Sorry, go on"));
            await chat.Current;

            var prompt = backend.Contexts.Last().ToPrompt();
            Assert.Contains("Owner: Make a poster plan for the e-rickshaws", prompt);
            Assert.Contains("got no answer", prompt);
            Assert.DoesNotContain("Stopped.", prompt);
        }

        [Fact]
        public async Task Another_AI_tool_taking_over_is_given_the_same_chat()
        {
            _codex.Answers("Pamphlets reach one lane at a time.");
            var chat = NewChat();
            await Say(chat, "What do you think about pamphlets?");

            _codex.Failure = new AiProviderException(ProviderIds.CodexCli, "limit reached");
            _claude.Answers("Posters carry only the name; pamphlets can carry an offer.");
            await Say(chat, "And what about posters instead?");

            Assert.Equal("Posters carry only the name; pamphlets can carry an offer.", chat.Messages.Last().Text);
            var taken = _claude.Requests.Single().UserPrompt;
            Assert.Contains("Owner: What do you think about pamphlets?", taken);
            Assert.Contains("You: Pamphlets reach one lane at a time.", taken);
        }

        [Fact]
        public async Task A_chat_kept_and_resumed_after_the_app_restarted_goes_on_with_what_was_said()
        {
            _codex.Answers("E-rickshaw posters give steady local sight.", "Pamphlets can carry an offer; posters only the name.");
            var first = NewChat();
            await Say(first, "What about advertising on e-rickshaws?");
            await Say(first, "And pamphlets?");
            var key = first.Key;
            var kept = new ChatHistory(() => _folder.Path, () => Noon).Save(first.Messages, key);

            // The app is closed and opened again: a new chat object, a new history object, the same folder.
            var reopened = new ChatHistory(() => _folder.Path, () => Noon).Get(kept.Id);
            Assert.Equal(key, reopened.Key);
            var second = NewChat();
            Assert.NotEqual(key, second.Key);
            second.Resume(reopened.Key, reopened.ToMessages());
            Assert.Equal(key, second.Key);
            Assert.Equal(4, second.Messages.Count);

            _codex.Answers("Pamphlets first: they can carry a code.");
            await Say(second, "Compare both and tell me which first");

            var prompt = _codex.Requests.Last().UserPrompt;
            Assert.Contains("Owner: What about advertising on e-rickshaws?", prompt);
            Assert.Contains("You: E-rickshaw posters give steady local sight.", prompt);
            Assert.Contains("Owner: And pamphlets?", prompt);
            Assert.Equal(key, second.Key);
        }

        [Fact]
        public async Task A_new_chat_starts_with_nothing_of_the_one_before()
        {
            _codex.Answers("E-rickshaw posters give steady local sight.", "A festival offer can bring people back.");
            var chat = NewChat();
            await Say(chat, "What about advertising on e-rickshaws?");
            var before = chat.Key;
            chat.Clear();
            Assert.NotEqual(before, chat.Key);
            Assert.Empty(chat.Messages);

            await Say(chat, "Any idea for Diwali?");
            var prompt = _codex.Requests.Last().UserPrompt;
            Assert.DoesNotContain("e-rickshaw", prompt);
            Assert.DoesNotContain("Conversation so far", prompt);
        }

        [Fact]
        public async Task Going_back_to_an_earlier_chat_brings_in_words_from_it_and_nothing_else_does()
        {
            var asked = new List<string>();
            _codex.Answers("Last week we looked at pamphlets and e-rickshaw posters.", "Fine.");
            var chat = NewChat(recall: q => { asked.Add(q); return "Earlier chat (5 October): the owner liked pamphlets with an offer code."; });

            await Say(chat, "What did we discuss last week about advertising?");
            Assert.Single(asked);
            Assert.Contains("the owner liked pamphlets with an offer code", _codex.Requests[0].UserPrompt);
            Assert.Contains("which the owner asked to go back to", _codex.Requests[0].UserPrompt);

            await Say(chat, "Which lane should the pamphlets go to?");
            Assert.Single(asked);   // an ordinary question does not search the old chats
        }

        [Fact]
        public void An_earlier_chat_is_recalled_only_by_what_it_shares_with_the_question_and_never_the_chat_going_on()
        {
            var history = new ChatHistory(() => _folder.Path, () => Noon);
            var rickshaw = history.Save(new[]
            {
                new ChatMessage(ChatRole.Owner, "Should we try e-rickshaw posters for the shop?", Noon.AddDays(-7)),
                new ChatMessage(ChatRole.Assistant, "A small pilot of three rickshaws for two weeks would show whether they bring buyers.", Noon.AddDays(-7)),
            }, "aaaaaa");
            history.Save(new[]
            {
                new ChatMessage(ChatRole.Owner, "Which biscuits should I reorder?", Noon.AddDays(-3)),
                new ChatMessage(ChatRole.Assistant, "Parle-G and Good Day are running low.", Noon.AddDays(-3)),
            }, "bbbbbb");
            var going = history.Save(new[] { new ChatMessage(ChatRole.Owner, "Thinking again about e-rickshaw posters", Noon) }, "cccccc");

            var recalled = history.Recall("What did we discuss about the e-rickshaw posters last week?", going.Key);

            Assert.Contains("Should we try e-rickshaw posters", recalled);
            Assert.Contains("A small pilot of three rickshaws", recalled);
            Assert.DoesNotContain("biscuits", recalled);
            Assert.DoesNotContain("Thinking again", recalled);   // the chat going on is left out
            Assert.Equal("", history.Recall("What did we discuss about Diwali sweets?", going.Key));
            Assert.NotEqual(rickshaw.Id, going.Id);
        }

        [Fact]
        public void A_long_chat_keeps_its_goal_and_its_limits_in_a_short_summary_inside_the_budget()
        {
            var messages = new List<ChatMessage>
            {
                new ChatMessage(ChatRole.Owner, "We want to bring more nearby customers to the shop.", Noon),
                new ChatMessage(ChatRole.Assistant, "A small local test is the safest start. Which lanes are nearest?", Noon),
                new ChatMessage(ChatRole.Owner, "Our budget is only ₹5,000 for the first month.", Noon),
                new ChatMessage(ChatRole.Assistant, "Then keep the pilot under ₹5,000: print little and count the results.", Noon),
                new ChatMessage(ChatRole.Owner, "We can only run it on weekends.", Noon),
                new ChatMessage(ChatRole.Assistant, "Weekend-only suits pamphlets better than posters.", Noon),
            };
            for (var i = 0; i < 30; i++)
            {
                messages.Add(new ChatMessage(ChatRole.Owner, "Another thought number " + i + " about colours and wording of the notice, nothing decided yet. " + new string('x', 200), Noon));
                messages.Add(new ChatMessage(ChatRole.Assistant, "Reply number " + i + " with some general thoughts on wording and layout. " + new string('y', 400), Noon));
            }

            var budget = new ContextBudget { MaxChars = 5000, MaxRecentChars = 2500, MaxSummaryChars = 1200 };
            var context = ConversationContextBuilder.Build(messages, "Make the plan now", "abc123", budget);

            var prompt = context.ToPrompt();
            Assert.True(prompt.Length <= 5000, "the block is " + prompt.Length + " characters");
            Assert.True(context.TurnsSummarized > 0);
            Assert.Contains("We want to bring more nearby customers", context.Summary);
            Assert.Contains("₹5,000", context.Summary);
            Assert.Contains("only run it on weekends", context.Summary);
            Assert.Equal("Reply number 29 with some general thoughts on wording and layout. " + new string('y', 400), context.Recent.Last().Text);
            Assert.True(context.Recent.Count >= 2);
        }

        [Fact]
        public void The_same_older_messages_always_give_the_same_summary()
        {
            var turns = Enumerable.Range(0, 10).Select(i => new ContextTurn(i % 2 == 0 ? ChatRole.Owner : ChatRole.Assistant, "Message " + i + " about the budget of ₹" + (i * 100))).ToList();
            Assert.Equal(ChatSummarizer.Summarize(turns, 2000), ChatSummarizer.Summarize(turns, 2000));
            // Words are matched whole: "colours and" is not money, and a filler message does not outrank a budget.
            Assert.True(ChatSummarizer.Score("Our budget is only ₹5,000 for the first month.") >= 6);
            Assert.True(ChatSummarizer.Score("Another thought about colours and wording of the notice, nothing decided yet.") < 3);
            Assert.True(ChatSummarizer.Score("We can only run it on weekends.") >= 3);
            Assert.Equal("", ChatSummarizer.Summarize(new ContextTurn[0], 2000));
        }

        [Fact]
        public async Task What_went_into_a_prompt_is_reported_in_numbers_and_never_in_words()
        {
            var reports = new List<ContextReport>();
            _codex.Answers("Posters carry only the name.", "Pamphlets can carry an offer.");
            var chat = NewChat();
            chat.ContextBuilt += (sender, report) => reports.Add(report);
            await Say(chat, "Tell me about e-rickshaw posters for Priya Traders 9876543210");
            await Say(chat, "And pamphlets?");

            Assert.Equal(2, reports.Count);
            Assert.Equal(0, reports[0].TurnsShown);
            Assert.Equal(2, reports[1].TurnsShown);
            Assert.Equal(chat.Key, reports[1].ChatKey);
            var text = reports[1].ToString();
            Assert.Contains("2 messages shown", text);
            Assert.DoesNotContain("Priya", text);
            Assert.DoesNotContain("9876543210", text);
            Assert.DoesNotContain("rickshaw", text);
        }

        [Theory]
        [InlineData("Do you think e-rickshaw advertising is worth testing?", RequestKind.General)]
        [InlineData("How can we attract more nearby customers?", RequestKind.General)]
        [InlineData("Write a marketing strategy for next month", RequestKind.General)]
        [InlineData("Help me decide what to do tomorrow", RequestKind.General)]
        [InlineData("Compare these two advertising ideas", RequestKind.General)]
        [InlineData("Prepare a campaign checklist", RequestKind.General)]
        [InlineData("Draft a message for our customers about the Diwali offer", RequestKind.General)]
        [InlineData("Compare it with pamphlets.", RequestKind.General)]
        [InlineData("Which should we test first?", RequestKind.General)]
        [InlineData("Make a 30-day plan for it.", RequestKind.General)]
        [InlineData("How much should we spend on posters?", RequestKind.General)]
        [InlineData("Aaj kitni sale hui?", RequestKind.Data)]
        [InlineData("How many bills did we make this week?", RequestKind.Data)]
        [InlineData("Which products sold most this month?", RequestKind.Data)]
        [InlineData("Our sales are falling.", RequestKind.Data)]
        [InlineData("Why are our sales falling?", RequestKind.Hybrid)]
        [InlineData("What should I reorder? Check the stock.", RequestKind.Hybrid)]
        [InlineData("Compare sales since the campaign started.", RequestKind.Hybrid)]
        [InlineData("Make a budget of ₹5,000 for the pilot", RequestKind.Work)]
        [InlineData("Remind me to talk to the vendor", RequestKind.Work)]
        [InlineData("What happened to our advertising plan?", RequestKind.Work)]
        public void A_message_goes_where_it_belongs(string message, RequestKind expected)
        {
            Assert.Equal(expected, RequestRouter.Decide(message, ConversationContext.Empty).Kind);
        }

        [Fact]
        public void A_bare_yes_goes_where_the_chat_was_going()
        {
            var afterAdvice = ConversationContextBuilder.Build(new[]
            {
                new ChatMessage(ChatRole.Owner, "What do you think about pamphlets?", Noon),
                new ChatMessage(ChatRole.Assistant, "They can carry an offer.", Noon) { Route = RequestKind.General },
            }, "Yes, tell me");
            var afterFigures = ConversationContextBuilder.Build(new[]
            {
                new ChatMessage(ChatRole.Owner, "How many bills today?", Noon),
                new ChatMessage(ChatRole.Assistant, "18 bills.", Noon) { Route = RequestKind.Data },
            }, "yes");

            Assert.Equal(RequestKind.General, RequestRouter.Decide("Yes, tell me", afterAdvice).Kind);
            Assert.Equal(RequestKind.Data, RequestRouter.Decide("yes", afterFigures).Kind);
            Assert.Equal(RequestKind.General, RequestRouter.Decide("go on", ConversationContext.Empty).Kind);
        }

        [Theory]
        [InlineData("yes", true)]
        [InlineData("Yes, tell me", true)]
        [InlineData("  Continue.  ", true)]
        [InlineData("go on", true)]
        [InlineData("Go on, tell me more", false)]
        [InlineData("compare both", true)]
        [InlineData("Compare both and tell me which first", false)]
        [InlineData("Make a plan for the e-rickshaw posters", false)]
        [InlineData("", false)]
        public void Only_the_short_replies_that_carry_on_are_recognised(string message, bool expected)
        {
            Assert.Equal(expected, Continuations.IsOnlyContinuing(message));
        }

        [Fact]
        public async Task A_photo_or_voice_question_still_goes_to_the_data_path()
        {
            _codex.Answers(BillsQuery, "The photo shows a biscuit pack: 12 sold this week.");
            var chat = NewChat();
            var photo = new ChatAttachment(AttachmentKind.Photo, _folder.File("shelf.jpg", "x"));
            Assert.True(chat.Ask("How is this selling?", new[] { photo }));
            await chat.Current;
            Assert.Single(ShopQueries);
        }

        /// <summary>A chat backend that waits until it is stopped, then records the context of every later question.</summary>
        private sealed class HangingBackend : IChatBackend, IContextChat
        {
            public IReadOnlyList<ChatStarter> Starters { get; } = new ChatStarter[0];

            public TaskCompletionSource<bool> Started { get; } = new TaskCompletionSource<bool>();

            public List<ConversationContext> Contexts { get; } = new List<ConversationContext>();

            public Task<ChatMessage> AskAsync(string question, IProgress<string> progress, CancellationToken cancellationToken) =>
                AskAsync(new AskRequest { Question = question }, progress, cancellationToken);

            public async Task<ChatMessage> AskAsync(AskRequest request, IProgress<string> progress, CancellationToken cancellationToken)
            {
                Contexts.Add(request.Context);
                if (Contexts.Count == 1)
                {
                    Started.TrySetResult(true);
                    await Task.Delay(Timeout.Infinite, cancellationToken);
                }

                return new ChatMessage(ChatRole.Assistant, "ok", Noon);
            }

            public Task<ChatMessage> RunAsync(ChatStarter starter, IProgress<string> progress, CancellationToken cancellationToken) =>
                AskAsync(starter.Question, progress, cancellationToken);
        }
    }
}
