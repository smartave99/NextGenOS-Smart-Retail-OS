using System;
using System.IO;
using System.Linq;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Memory;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>Past chats: kept by the month, found by their words, and without customers' rows.</summary>
    public class ChatHistoryTests : IDisposable
    {
        private readonly TempFolder _folder = new TempFolder();
        private DateTime _now = new DateTime(2026, 9, 26, 12, 0, 0);

        private ChatHistory History => new ChatHistory(() => _folder.Path, () => _now);

        public void Dispose() => _folder.Dispose();

        private ChatMessage Owner(string text) => new ChatMessage(ChatRole.Owner, text, _now);

        private ChatMessage Answer(string text) => new ChatMessage(ChatRole.Assistant, text, _now) { Source = "Codex CLI · 4.2 s" };

        [Fact]
        public void A_chat_is_kept_with_its_words_and_only_the_size_of_a_table()
        {
            var table = FakeQueryExecutor.Table(new[] { "Name", "Phone", "Balance" },
                new object[] { "Priya Sharma", "9000000102", 400m }, new object[] { "Ramesh Kumar", "9000000101", 250m });
            var answer = Answer("Two customers owe money.");
            answer.Table = ChatTable.From(table);

            var saved = History.Save(new[] { Owner("  Who owes me money?  "), answer });

            var kept = History.Get(saved.Id);
            Assert.Equal("Who owes me money?", kept.Title);
            Assert.Equal(new[] { "Who owes me money?", "Two customers owe money." }, kept.Messages.Select(m => m.Text));
            Assert.Equal("A table of 2 rows: Name, Phone, Balance", kept.Messages[1].Table);
            Assert.Equal("Codex CLI · 4.2 s", kept.Messages[1].Source);
            var file = File.ReadAllText(Path.Combine(_folder.Path, "Memory", "Chats", "chats-2026-09.json"));
            Assert.DoesNotContain("Priya", file);
            Assert.DoesNotContain("9000000102", file);
        }

        [Fact]
        public void Phone_numbers_and_e_mail_addresses_are_hidden_in_what_is_kept()
        {
            var saved = History.Save(new[] { Owner("What is Priya's number?"), Answer("Priya Sharma: 98765 43210, priya@example.com.") });

            Assert.Equal("Priya Sharma: 98******10, pr******om.", History.Get(saved.Id).Messages[1].Text);
        }

        [Fact]
        public void A_question_sent_as_a_photo_or_voice_note_is_kept_in_words()
        {
            var photo = new ChatAttachment(AttachmentKind.Photo, Path.Combine(_folder.Path, "photo-1.jpg"));
            var voice = new ChatAttachment(AttachmentKind.Voice, Path.Combine(_folder.Path, "voice-1.wav"));
            var heard = Answer("Cash today: ₹5,723.");
            heard.Heard = "aaj kitna cash aaya";

            var saved = History.Save(new[]
            {
                new ChatMessage(ChatRole.Owner, "", _now) { Attachments = new[] { voice } },
                heard,
                new ChatMessage(ChatRole.Owner, " ", _now) { Attachments = new[] { photo, photo } },
                Answer("Two packs of tea."),
                new ChatMessage(ChatRole.Owner, "Is this selling?", _now) { Attachments = new[] { photo } },
                Answer("Yes, 12 this week."),
                new ChatMessage(ChatRole.Owner, "", _now) { Attachments = new[] { voice } },
                new ChatMessage(ChatRole.Assistant, "The AI could not listen.", _now) { IsProblem = true },
            });

            var kept = History.Get(saved.Id);
            Assert.Equal("(voice note) aaj kitna cash aaya", kept.Title);
            Assert.Equal(
                new[] { "(voice note) aaj kitna cash aaya", "Cash today: ₹5,723.", "(2 photos)", "Two packs of tea.", "Is this selling? (photo)", "Yes, 12 this week.", "(voice note)", "The AI could not listen." },
                kept.Messages.Select(m => m.Text));
            Assert.DoesNotContain("photo-1.jpg", File.ReadAllText(Path.Combine(_folder.Path, "Memory", "Chats", "chats-2026-09.json")));
        }

        [Fact]
        public void A_chat_without_a_question_is_not_kept() =>
            Assert.Null(History.Save(new[] { Answer("Hello.") }));

        [Fact]
        public void Chats_are_found_by_all_their_words_newest_first()
        {
            var history = History;
            history.Save(new[] { Owner("How much sugar did we sell in Diwali week?"), Answer("About 120 kg of sugar, twice a normal week.") });
            _now = _now.AddDays(1);
            history.Save(new[] { Owner("Which snacks sell on Sundays?"), Answer("Bhujia and chips sell most on Sundays.") });
            _now = _now.AddDays(1);
            history.Save(new[] { Owner("Sugar price this week?"), Answer("Sugar sells at ₹48 a kg.") });

            Assert.Equal(new[] { "Sugar price this week?", "How much sugar did we sell in Diwali week?" }, history.Search("SUGAR").Select(h => h.Chat.Title));
            var diwali = Assert.Single(history.Search("sugar diwali"));
            Assert.Equal("How much sugar did we sell in Diwali week?", diwali.Snippet);
            Assert.Equal("Bhujia and chips sell most on Sundays.", Assert.Single(history.Search("bhujia")).Snippet);
            Assert.Empty(history.Search("coffee"));
            Assert.Empty(history.Search(" "));
            Assert.Equal(new[] { "Sugar price this week?", "Which snacks sell on Sundays?", "How much sugar did we sell in Diwali week?" }, history.Latest().Select(c => c.Title));
        }

        [Fact]
        public void A_long_match_is_cut_around_the_word()
        {
            var history = History;
            history.Save(new[] { Owner("Tell me about the week"), Answer(new string('a', 100) + " paneer " + new string('b', 100)) });

            var snippet = Assert.Single(history.Search("paneer")).Snippet;

            Assert.StartsWith("…", snippet);
            Assert.EndsWith("…", snippet);
            Assert.Contains(" paneer ", snippet);
        }

        [Fact]
        public void A_chat_saved_again_with_its_key_replaces_the_copy_kept_before()
        {
            // The chat so far is kept after each answer, as one past chat.
            var key = ChatHistory.NewKey();
            var asked = Owner("Aaj kitni sale hui?");
            var first = History.Save(new[] { asked, Answer("₹12,500.") }, key);
            _now = _now.AddMinutes(3);
            var second = History.Save(new[] { asked, Answer("₹12,500."), Owner("Aur kal?"), Answer("₹9,800.") }, key);
            var other = History.Save(new[] { Owner("Stock?") }, ChatHistory.NewKey());

            Assert.Equal(first.Id, second.Id);
            Assert.NotEqual(first.Id, other.Id);
            Assert.Equal(2, History.Latest().Count);
            Assert.Equal(4, History.Get(first.Id).Messages.Count);
            Assert.Matches("^[0-9a-f]{6}$", ChatHistory.NewKey());
        }

        [Fact]
        public void Chats_can_be_deleted_one_or_all()
        {
            var history = History;
            var first = history.Save(new[] { Owner("First question") });
            history.Save(new[] { Owner("Second question") });

            Assert.True(history.Delete(first.Id));
            Assert.False(history.Delete(first.Id));
            Assert.Equal(new[] { "Second question" }, history.Latest().Select(c => c.Title));
            Assert.Equal(1, history.DeleteAll());
            Assert.Empty(history.Latest());
        }

        [Theory]
        [InlineData("../../settings")]
        [InlineData("20260926120000-ABCDEF")]
        [InlineData("")]
        public void Only_ids_the_history_made_are_looked_up(string id) =>
            Assert.Null(History.Get(id));

        [Fact]
        public void Chats_older_than_six_months_are_deleted()
        {
            History.Save(new[] { Owner("An old question") });
            _now = _now.AddMonths(7);

            History.Save(new[] { Owner("A new question") });

            Assert.Equal(new[] { "A new question" }, History.Latest().Select(c => c.Title));
            Assert.False(File.Exists(Path.Combine(_folder.Path, "Memory", "Chats", "chats-2026-09.json")));
        }

        [Fact]
        public void Chats_older_than_six_months_are_never_shown_even_before_they_are_deleted()
        {
            var old = History.Save(new[] { Owner("An old question about sugar") });
            var folder = Path.Combine(_folder.Path, "Memory", "Chats");
            File.WriteAllText(Path.Combine(folder, "chats-2026-09.json.bad"), "[ a damaged copy");
            _now = _now.AddMonths(6);
            Assert.Single(History.Latest());
            Assert.Equal(0, History.DeleteExpired());

            // A month later, with no new chat kept since.
            _now = _now.AddMonths(1);

            Assert.Empty(History.Latest());
            Assert.Empty(History.Search("sugar"));
            Assert.Null(History.Get(old.Id));
            Assert.Equal(2, History.DeleteExpired());
            Assert.Empty(Directory.GetFiles(folder));
        }

        [Fact]
        public void A_damaged_month_is_kept_aside_until_all_chats_are_deleted()
        {
            var folder = Path.Combine(_folder.Path, "Memory", "Chats");
            Directory.CreateDirectory(folder);
            File.WriteAllText(Path.Combine(folder, "chats-2026-09.json"), "[ not json");

            History.Save(new[] { Owner("A question") });

            Assert.True(File.Exists(Path.Combine(folder, "chats-2026-09.json.bad")));
            Assert.Single(History.Latest());
            Assert.Equal(1, History.DeleteAll());
            Assert.Empty(Directory.GetFiles(folder));
        }
    }
}
