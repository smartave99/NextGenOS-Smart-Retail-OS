using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Settings;
using SmartRetail.AI.Work;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>
    /// The program recognises plain English only. The words of a customer's own language, money and trade, and its campaign plans, come from its profile (CLAUDE.md, section 8):
    /// with none the assistant still answers (a message it cannot place goes where any question goes), and with them it recognises more.
    /// </summary>
    public class ChatVocabularyTests : IDisposable
    {
        private readonly TempFolder _folder = new TempFolder();

        public void Dispose() => _folder.Dispose();

        private static string Repo()
        {
            var dir = new DirectoryInfo(AppContext.BaseDirectory);
            while (dir != null && !File.Exists(Path.Combine(dir.FullName, "CLAUDE.md")))
            {
                dir = dir.Parent;
            }

            Assert.NotNull(dir);
            return dir.FullName;
        }

        /// <summary>The words one customer of NextGenOS has in its brand kit: Hindi and Hinglish, rupees and e-rickshaws. Data, not program code.</summary>
        private static ChatVocabulary Customers()
        {
            var problems = new List<string>();
            var words = ChatVocabulary.Parse(File.ReadAllText(Path.Combine(Repo(), "brand-kits", "smart-avenue-99", "chat-words.json")), problems);
            Assert.Empty(problems);
            return words;
        }

        [Fact]
        public void Without_a_profile_the_program_knows_English_only_and_still_places_every_message()
        {
            var neutral = ChatVocabulary.Neutral;

            Assert.True(neutral.IsNeutral);
            Assert.False(Continuations.IsOnlyContinuing("haan"));
            Assert.False(Continuations.IsOnlyContinuing("haan", neutral));
            Assert.True(Continuations.IsOnlyContinuing("go on", neutral));

            // Not recognised as a question about figures or as advice: it goes where an unplaced question goes, and the AI reads it with the chat.
            var decision = RequestRouter.Decide("Aaj kitna cash aaya?", ConversationContext.Empty, words: neutral);
            Assert.Equal(RequestKind.Data, decision.Kind);
            Assert.Contains("not clearly advice", decision.Reason);
            Assert.Equal(RequestKind.Data, RequestRouter.Decide("Rickshaw ke baare mein sujhav do", ConversationContext.Empty, words: neutral).Kind);
        }

        [Fact]
        public void With_the_customers_words_its_own_language_money_and_trade_are_recognised()
        {
            var words = Customers();

            Assert.True(Continuations.IsOnlyContinuing("haan", words));
            Assert.True(Continuations.IsOnlyContinuing("ठीक है", words));
            Assert.False(Continuations.IsOnlyContinuing("haan batao kya karein", words));
            Assert.Equal(RequestKind.General, RequestRouter.Decide("haan", ConversationContext.Empty, words: words).Kind);
            Assert.Equal(RequestKind.Data, RequestRouter.Decide("Aaj kitna cash aaya?", ConversationContext.Empty, words: words).Kind);
            Assert.Equal(RequestKind.Data, RequestRouter.Decide("बिक्री कितनी हुई", ConversationContext.Empty, words: words).Kind);
            Assert.Equal(RequestKind.General, RequestRouter.Decide("Rickshaw ke baare mein sujhav do", ConversationContext.Empty, words: words).Kind);
            Assert.Equal(RequestKind.Work, RequestRouter.Decide("Yaad dilao ki printer ko call karna hai", ConversationContext.Empty, words: words).Kind);
            Assert.Equal(RequestKind.Hybrid, RequestRouter.Decide("Is mahine ki sales kitni hai, aur kya karna chahiye?", ConversationContext.Empty, words: words).Kind);
        }

        [Fact]
        public void A_word_is_found_whole_in_any_script_and_not_inside_a_longer_word()
        {
            var words = ChatVocabulary.Parse("{\"schema\":1,\"words\":{\"limits\":[\"sirf\",\"सिर्फ़\"],\"recall\":[\"pichli baar\"]}}");

            Assert.True(words.Matches(WordKind.Limits, "Sirf 5000 ka budget hai"));
            Assert.True(words.Matches(WordKind.Limits, "सिर्फ़ पांच हज़ार"));
            Assert.False(words.Matches(WordKind.Limits, "asirfa"));
            Assert.True(words.AsksToGoBack("Pichli baar jo baat hui thi"));
            Assert.False(words.AsksToGoBack("Next time"));
        }

        [Fact]
        public void The_customers_words_help_the_summary_keep_a_budget_in_their_own_language()
        {
            var line = "Mera kharcha sirf 5000 rupees hai";

            Assert.True(ChatSummarizer.Score(line) < 3);   // not kept for lack of words, though the number is seen
            Assert.True(ChatSummarizer.Score(line, Customers()) >= 6);
        }

        [Fact]
        public void A_profile_that_cannot_be_used_is_said_and_the_plain_English_words_are_kept_and_nothing_is_a_pattern()
        {
            var problems = new List<string>();

            Assert.True(ChatVocabulary.Parse("not json", problems).IsNeutral);
            Assert.True(ChatVocabulary.Parse("{\"schema\":2}", problems).IsNeutral);
            Assert.Equal(2, problems.Count);

            problems.Clear();
            var words = ChatVocabulary.Parse("{\"schema\":1,\"words\":{\"advice\":[\"a.*b\",\"\",\"" + new string('x', 41) + "\",\"bad\\u0007\",7]}}", problems);
            Assert.Equal(new[] { "a.*b" }, words.Of(WordKind.Advice));
            Assert.Equal(4, problems.Count);
            Assert.True(words.Matches(WordKind.Advice, "what about a.*b"));
            Assert.False(words.Matches(WordKind.Advice, "aaaaab"));   // a word is text: ".*" is not a pattern
        }

        [Fact]
        public void The_words_come_from_the_profile_folder_beside_the_program_with_or_without_the_pictures_profile()
        {
            Directory.CreateDirectory(Path.Combine(_folder.Path, "profile"));
            File.WriteAllText(Path.Combine(_folder.Path, "profile", ChatVocabulary.FileName), "{\"schema\":1,\"words\":{\"continue\":[\"haan\"]}}");

            // No ai.json: neutral pictures profile, but the words are there.
            Assert.True(ShopProfile.LoadNear(_folder.Path).ChatWords.IsContinuation("haan"));

            File.WriteAllText(Path.Combine(_folder.Path, "profile", ShopProfile.FileName), "{\"schema\":1,\"country\":{\"name\":\"the Philippines\"}}");
            var both = ShopProfile.LoadNear(_folder.Path);
            Assert.Equal("the Philippines", both.CountryName);
            Assert.True(both.ChatWords.IsContinuation("haan"));

            // None at all: English only.
            using (var empty = new TempFolder())
            {
                Assert.True(ShopProfile.LoadNear(empty.Path).ChatWords.IsNeutral);
            }
        }

        [Fact]
        public void The_conversation_uses_the_profiles_words_when_it_builds_what_the_AI_is_shown()
        {
            var backend = new RecordingContextBackend();
            var now = new DateTime(2026, 10, 12, 12, 0, 0);
            var chat = new Conversation(backend, () => now, words: Customers);
            Assert.True(chat.Ask("Rickshaw poster ka idea hai, sirf 5000 rupees ka budget hai"));
            chat.Current.Wait();
            Assert.True(chat.Ask("haan"));
            chat.Current.Wait();

            var context = backend.Contexts.Last();
            Assert.Contains("Rickshaw poster ka idea hai", context.Topic);   // "haan" only carries on, so the topic is still the idea
        }

        [Fact]
        public void The_customers_campaign_plans_in_its_brand_kit_are_valid_and_are_not_the_built_in_one()
        {
            var problems = new List<string>();
            var templates = CampaignTemplates.Parse(File.ReadAllText(Path.Combine(Repo(), "brand-kits", "smart-avenue-99", "campaigns.json")), problems);

            Assert.Empty(problems);
            Assert.Equal(new[] { "e-rickshaw-posters", "pamphlets" }, templates.Select(t => t.Id).ToArray());
            var rickshaw = templates[0];
            Assert.Equal("posters on e-rickshaws", rickshaw.Channel);
            Assert.Contains(rickshaw.Steps, s => s.Title.Contains("quotations") && s.AfterDays < 0);
            Assert.Contains(rickshaw.Signs, s => s.Contains("people counted"));
            // No price, no reach, no promised result in either plan.
            foreach (var template in templates)
            {
                var all = template.Summary + " " + string.Join(" ", template.Steps.Select(s => s.Title + " " + s.Detail)) + " " + string.Join(" ", template.Signs);
                Assert.DoesNotMatch(@"\d+\s*(%|rs|₹|rupees|people will|customers will)|will (increase|double|bring|guarantee)|guarantee", all.ToLowerInvariant());
            }
        }

        private sealed class RecordingContextBackend : IChatBackend, IContextChat
        {
            public IReadOnlyList<ChatStarter> Starters { get; } = new ChatStarter[0];

            public List<ConversationContext> Contexts { get; } = new List<ConversationContext>();

            public System.Threading.Tasks.Task<ChatMessage> AskAsync(string question, IProgress<string> progress, System.Threading.CancellationToken cancellationToken) =>
                AskAsync(new AskRequest { Question = question }, progress, cancellationToken);

            public System.Threading.Tasks.Task<ChatMessage> AskAsync(AskRequest request, IProgress<string> progress, System.Threading.CancellationToken cancellationToken)
            {
                Contexts.Add(request.Context);
                return System.Threading.Tasks.Task.FromResult(new ChatMessage(ChatRole.Assistant, "Answer to: " + request.Question, DateTime.Now));
            }

            public System.Threading.Tasks.Task<ChatMessage> RunAsync(ChatStarter starter, IProgress<string> progress, System.Threading.CancellationToken cancellationToken) =>
                AskAsync(starter.Question, progress, cancellationToken);
        }
    }
}
