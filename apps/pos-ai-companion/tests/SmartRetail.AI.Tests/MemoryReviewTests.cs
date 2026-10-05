using System;
using System.Linq;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Data;
using SmartRetail.AI.Memory;
using Xunit;

namespace SmartRetail.AI.Tests
{
    public class MemoryReviewTests
    {
        private static readonly DateTime Now = new DateTime(2026, 9, 26, 12, 0, 0);

        [Fact]
        public void The_review_shows_the_ai_its_memory_with_room_left_and_the_conversation_without_contact_details()
        {
            var book = new MemoryBook();
            MemoryRules.Apply(book, new MemoryChange { Op = MemoryOp.Add, Part = MemoryPart.Shop, NewText = "Bhujia sells best on Sundays." }, Now);
            var messages = new[]
            {
                new ChatMessage(ChatRole.Owner, "Reply in Hinglish please. Call Priya on 9876543210 about her credit.", Now),
                new ChatMessage(ChatRole.Assistant, "Theek hai, main Hinglish mein jawab dunga.", Now),
            };

            var request = MemoryReview.Request(book, messages, Now);

            Assert.Contains("Never keep: one-off questions", request.SystemPrompt);
            Assert.Contains("At most 3 changes", request.SystemPrompt);
            Assert.Contains("Memory \"shop\" (30 of 2,200 characters used):\n- Bhujia sells best on Sundays.", request.UserPrompt.Replace("\r\n", "\n"));
            Assert.Contains("Memory \"owner\" (0 of 1,375 characters used):\n(empty)", request.UserPrompt.Replace("\r\n", "\n"));
            Assert.Contains("Owner: Reply in Hinglish please.", request.UserPrompt);
            Assert.DoesNotContain("9876543210", request.UserPrompt);
        }

        [Fact]
        public void The_ais_answer_is_read_in_the_shape_asked_for_and_nothing_else()
        {
            var answer = "Here you go:\n```json\n{\"changes\": [" +
                "{\"op\": \"add\", \"part\": \"owner\", \"text\": \"Prefers answers in Hinglish.\", \"why\": \"Asked for it\"}," +
                "{\"op\": \"replace\", \"part\": \"shop\", \"old\": \"Bhujia\", \"text\": \"Bhujia and namkeen sell best on Sundays.\"}," +
                "{\"op\": \"delete\", \"part\": \"shop\", \"old\": \"x\"}," +
                "{\"op\": \"add\", \"part\": \"customers\", \"text\": \"x\"}," +
                "{\"op\": \"remove\", \"part\": \"shop\", \"old\": \"coffee\"}," +
                "{\"op\": \"add\", \"part\": \"shop\", \"text\": \"a fourth good one\"}]}\n```";

            var changes = MemoryReview.Parse(answer);

            Assert.Equal(new[] { (MemoryOp.Add, MemoryPart.Owner), (MemoryOp.Replace, MemoryPart.Shop), (MemoryOp.Remove, MemoryPart.Shop) },
                changes.Select(c => (c.Op, c.Part)));
            Assert.Equal("Prefers answers in Hinglish.", changes[0].NewText);
            Assert.Equal("Asked for it", changes[0].Why);
            Assert.Equal("Bhujia", changes[1].OldText);
            Assert.All(changes, c => Assert.Equal("Chat", c.Source));
            Assert.Empty(MemoryReview.Parse("Nothing to remember."));
            Assert.Empty(MemoryReview.Parse("{\"changes\": []}"));
            Assert.Empty(MemoryReview.Parse("{ broken"));
        }

        [Theory]
        [InlineData("Remember that I prefer answers in Hinglish", MemoryPart.Owner, "I prefer answers in Hinglish.")]
        [InlineData("please remember: bhujia sells more on Sundays.", MemoryPart.Shop, "Bhujia sells more on Sundays.")]
        [InlineData("yaad rakho ki mujhe chhote jawab pasand hain", MemoryPart.Owner, "Mujhe chhote jawab pasand hain.")]
        [InlineData("याद रखो कि दिवाली में मिठाई ज़्यादा बिकती है।", MemoryPart.Shop, "दिवाली में मिठाई ज़्यादा बिकती है।")]
        [InlineData("Remember, we close early on Tuesdays", MemoryPart.Shop, "We close early on Tuesdays.")]
        [InlineData("Keep in mind that the milk van comes at 7 am!", MemoryPart.Shop, "The milk van comes at 7 am.")]
        [InlineData("note down: my budget for ads is ₹5,000 a month", MemoryPart.Owner, "My budget for ads is ₹5,000 a month.")]
        public void Remember_that_is_kept_as_the_owner_said_it(string text, MemoryPart part, string fact)
        {
            var change = MemoryCommands.RememberRequest(text);

            Assert.Equal((MemoryOp.Add, part, fact), (change.Op, change.Part, change.NewText));
        }

        [Theory]
        [InlineData("What do you remember about Diwali?")]
        [InlineData("Remember what we sold last Diwali?")]
        [InlineData("How were sales yesterday")]
        [InlineData("Remember to order sugar tomorrow")]
        [InlineData("remember when we ran the Holi offer")]
        [InlineData("Note the price of sugar")]
        [InlineData("Remembering last year, what should I stock for Diwali")]
        public void Questions_are_not_remember_commands(string text) =>
            Assert.Null(MemoryCommands.RememberRequest(text));

        [Theory]
        [InlineData("Forget that bhujia sells on Sundays.", "bhujia sells on Sundays")]
        [InlineData("bhool jao Hinglish wali baat", "Hinglish wali baat")]
        [InlineData("How do I forget nothing", null)]
        public void Forget_says_what_to_forget(string text, string what) =>
            Assert.Equal(what, MemoryCommands.ForgetRequest(text));

        [Fact]
        public void The_review_leaves_out_what_was_done_already_and_what_the_owner_declined()
        {
            var book = new MemoryBook();
            book.Journey.Add(new MemoryChange { Op = MemoryOp.Add, Part = MemoryPart.Shop, NewText = "Bread sells out by noon.", Status = MemoryChangeStatus.Rejected });
            var messages = new[]
            {
                new ChatMessage(ChatRole.Owner, "Remember that bhujia sells best on Sundays", Now),
                new ChatMessage(ChatRole.Assistant, "I will remember that: “Bhujia sells best on Sundays.”", Now) { Source = MemoryCommands.SourceName },
                new ChatMessage(ChatRole.Owner, "Which snacks sold most this week?", Now),
                new ChatMessage(ChatRole.Assistant, "Bhujia 200 g, then chips.", Now),
            };

            var request = MemoryReview.Request(book, messages, Now).UserPrompt.Replace("\r\n", "\n");

            Assert.Contains("do not suggest them again:\n- Bread sells out by noon.", request);
            Assert.DoesNotContain("Remember that", request);
            Assert.DoesNotContain("I will remember", request);
            Assert.Contains("Owner: Which snacks sold most this week?\n\nAssistant: Bhujia 200 g, then chips.", request);
        }

        [Fact]
        public void The_review_reads_a_voice_question_as_the_words_the_ai_heard()
        {
            var answer = new ChatMessage(ChatRole.Assistant, "Tea sells best in the morning.", Now) { Heard = "chai kab sabse zyada bikti hai, mera number 98765 43210" };
            var messages = new[]
            {
                new ChatMessage(ChatRole.Owner, "", Now) { Attachments = new[] { new ChatAttachment(AttachmentKind.Voice, "voice-1.wav") } },
                answer,
            };

            var request = MemoryReview.Request(new MemoryBook(), messages, Now).UserPrompt.Replace("\r\n", "\n");

            Assert.Contains("Owner: (voice note) chai kab sabse zyada bikti hai, mera number 98******10\n\nAssistant: Tea sells best in the morning.", request);
        }

        [Fact]
        public void Actions_the_owner_spoke_of_are_read_for_tracking()
        {
            var answer = "{\"changes\": [], \"actions\": ["
                + "{\"title\": \"E-rickshaw ads around the market\", \"kind\": \"advert\", \"start\": \"2026-10-01\", \"end\": \"2026-10-31\", \"cost\": \"₹6,000\", \"products\": [], \"expected\": \"More bills from the market side\"},"
                + "{\"title\": \"Maggi at the counter\", \"kind\": \"display\", \"start\": \"soon\", \"end\": \"2020-01-01\", \"cost\": 0, \"products\": [\"Maggi 70 g\", \" \", \"maggi 70 g\"]},"
                + "{\"title\": \" \", \"kind\": \"offer\"},"
                + "{\"title\": \"A third one\"}]}";

            var actions = MemoryReview.ParseActions(answer, Now);

            Assert.Equal(new[] { "E-rickshaw ads around the market", "Maggi at the counter" }, actions.Select(a => a.Title));
            Assert.Equal(("advert", new DateTime(2026, 10, 1), (DateTime?)new DateTime(2026, 10, 31), 6000m), (actions[0].Kind, actions[0].Start, actions[0].End, actions[0].Cost));
            Assert.Empty(actions[0].Products);
            Assert.Equal("More bills from the market side", actions[0].Expected);
            // No start date said: today. An end before the start is dropped.
            Assert.Equal((Now.Date, (DateTime?)null), (actions[1].Start, actions[1].End));
            Assert.Equal(new[] { "Maggi 70 g" }, actions[1].Products);
            Assert.Empty(MemoryReview.ParseActions("{\"changes\": []}", Now));
            Assert.Contains("never your own ideas", MemoryReview.Request(new MemoryBook(), Array.Empty<ChatMessage>(), Now).SystemPrompt);
        }

        [Theory]
        [InlineData("Call Priya on 9876543210 today", "Call Priya on 98******10 today")]
        [InlineData("Call Priya on 98765 43210 today", "Call Priya on 98******10 today")]
        [InlineData("Call Priya on 98765-43210 today", "Call Priya on 98******10 today")]
        [InlineData("Call +91 98765 43210", "Call +9******10")]
        [InlineData("Call 09876543210", "Call 09******10")]
        [InlineData("Call 0091 98765 43210", "Call 0091 98******10")]
        [InlineData("The office is 011-23456789.", "The office is 01******89.")]
        [InlineData("The office is 011 2345 6789.", "The office is 01******89.")]
        [InlineData("The office is (0124) 456 7890.", "The office is (0******90.")]
        [InlineData("The office is +91 11 2345 6789.", "The office is +9******89.")]
        [InlineData("The office is +91-11-23456789.", "The office is +9******89.")]
        [InlineData("Sold 25 on 12-10-2026 for 12345", "Sold 25 on 12-10-2026 for 12345")]
        [InlineData("Bill 00012345678 of 05-09-2026 1234", "Bill 00012345678 of 05-09-2026 1234")]
        [InlineData("Barcodes 0123456789012 and 012345678905", "Barcodes 0123456789012 and 012345678905")]
        public void Phone_numbers_are_hidden_however_they_are_written(string text, string masked) =>
            Assert.Equal(masked, PiiMasker.MaskText(text));

        [Fact]
        public void Forget_finds_the_entry_by_its_words()
        {
            var book = new MemoryBook();
            MemoryRules.Apply(book, new MemoryChange { Op = MemoryOp.Add, Part = MemoryPart.Shop, NewText = "Bhujia sells best on Sundays." }, Now);
            MemoryRules.Apply(book, new MemoryChange { Op = MemoryOp.Add, Part = MemoryPart.Owner, NewText = "Prefers answers in Hinglish." }, Now);

            Assert.Equal("Bhujia sells best on Sundays.", Assert.Single(MemoryCommands.Matches(book, "bhujia sells on Sundays")).Entry.Text);
            Assert.Equal(MemoryPart.Owner, Assert.Single(MemoryCommands.Matches(book, "hinglish")).Part);
            Assert.Empty(MemoryCommands.Matches(book, "the discount, what were sales"));
            Assert.Empty(MemoryCommands.Matches(book, " "));
        }

        [Fact]
        public void The_assistants_prompts_carry_the_memory_snapshot()
        {
            var memory = "What you remember from earlier conversations:\nAbout the owner:\n- Prefers Hinglish.\n";

            var sql = Prompts.SqlRequest("Product(PID)", "Best sellers?", Now, 50, null, null, memory);
            var answer = Prompts.AnswerRequest("Best sellers?", "SELECT 1", "x", Now, memory);
            var none = Prompts.AnswerRequest("Best sellers?", "SELECT 1", "x", Now);

            Assert.Contains("- Prefers Hinglish.", sql.SystemPrompt);
            Assert.Contains("- Prefers Hinglish.", answer.SystemPrompt);
            Assert.DoesNotContain("remember", none.SystemPrompt, StringComparison.OrdinalIgnoreCase);
        }
    }
}
