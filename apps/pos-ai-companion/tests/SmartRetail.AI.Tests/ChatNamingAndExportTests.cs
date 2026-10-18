using System;
using System.Linq;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Memory;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>A past chat can be given a name that stays, and a chat can be taken out as plain words (to copy or keep) with personal details hidden.</summary>
    public class ChatNamingAndExportTests : IDisposable
    {
        private readonly TempFolder _folder = new TempFolder();
        private DateTime _now = new DateTime(2026, 10, 12, 12, 0, 0);

        private ChatHistory History => new ChatHistory(() => _folder.Path, () => _now);

        public void Dispose() => _folder.Dispose();

        private ChatMessage Owner(string text) => new ChatMessage(ChatRole.Owner, text, _now);

        private ChatMessage Answer(string text) => new ChatMessage(ChatRole.Assistant, text, _now) { Source = "Codex CLI · 4.2 s" };

        [Fact]
        public void A_name_the_owner_gives_a_chat_is_kept_found_by_search_and_survives_the_chat_being_saved_again()
        {
            var key = ChatHistory.NewKey();
            var saved = History.Save(new[] { Owner("I was thinking of e-rickshaw posters"), Answer("A small pilot would show whether they work.") }, key);

            Assert.True(History.Rename(saved.Id, "  E-rickshaw pilot   idea "));

            var renamed = History.Get(saved.Id);
            Assert.Equal(("E-rickshaw pilot idea", true), (renamed.Title, renamed.Renamed));
            Assert.Equal(saved.Id, History.Search("pilot idea").Single().Chat.Id);

            // The chat goes on and is kept again after the next answer: the name stays.
            History.Save(new[] { Owner("I was thinking of e-rickshaw posters"), Answer("A small pilot would show whether they work."), Owner("And pamphlets?"), Answer("Cheaper to try.") }, key);
            var again = History.Get(saved.Id);
            Assert.Equal(("E-rickshaw pilot idea", true, 4), (again.Title, again.Renamed, again.Messages.Count));
            Assert.Single(History.Latest());
        }

        [Fact]
        public void An_empty_name_goes_back_to_the_first_question_and_a_chat_that_is_not_there_is_not_renamed()
        {
            var saved = History.Save(new[] { Owner("Which products sold most?"), Answer("Rice.") });
            History.Rename(saved.Id, "Best sellers");

            Assert.True(History.Rename(saved.Id, "   "));

            Assert.Equal(("Which products sold most?", false), (History.Get(saved.Id).Title, History.Get(saved.Id).Renamed));
            Assert.False(History.Rename("20260101000000-abcdef", "Nothing"));
            Assert.False(History.Rename("not an id", "Nothing"));
        }

        [Fact]
        public void A_name_is_cut_short_has_personal_details_hidden_and_cannot_hold_control_characters()
        {
            var saved = History.Save(new[] { Owner("Hello"), Answer("Hi") });

            Assert.True(History.Rename(saved.Id, new string('x', 200)));
            Assert.Equal(ChatHistory.TitleLength, History.Get(saved.Id).Title.Length);

            Assert.True(History.Rename(saved.Id, "Call priya@example.com about credit"));
            Assert.DoesNotContain("priya@example.com", History.Get(saved.Id).Title);

            Assert.False(History.Rename(saved.Id, "bad\u0007name"));
            Assert.DoesNotContain(History.Get(saved.Id).Title, char.IsControl);
        }

        [Fact]
        public void A_chat_taken_out_as_text_says_who_spoke_and_when_names_tables_and_problems_and_hides_personal_details()
        {
            var table = ChatTable.From(FakeQueryExecutor.Table(new[] { "Name", "Balance" }, new object[] { "Priya Sharma", 400m }, new object[] { "Ramesh Kumar", 250m }));
            var answer = Answer("Two customers owe money. Priya: 98765 43210, priya@example.com.");
            answer.Table = table;
            var problem = new ChatMessage(ChatRole.Assistant, "Something went wrong.", _now) { IsProblem = true };

            var text = ChatExport.ToText("Who owes money", new[] { Owner("Who owes me money?"), answer, Owner("Again please"), problem });

            Assert.StartsWith("Who owes money\n".Replace("\n", Environment.NewLine) + "12 October 2026, 12:00", text);
            Assert.Contains("You, 12:00:", text);
            Assert.Contains("Assistant (Codex CLI · 4.2 s), 12:00:", text);
            Assert.Contains("[A table of 2 rows: Name, Balance]", text);
            Assert.Contains("Problem, 12:00:", text);
            Assert.DoesNotContain("priya@example.com", text);
            Assert.DoesNotContain("98765 43210", text);
            Assert.DoesNotContain("Ramesh Kumar", text);   // the rows of a table are never in it
            Assert.EndsWith(Environment.NewLine, text);
        }

        [Fact]
        public void An_empty_chat_gives_a_title_only()
        {
            Assert.Equal("Chat" + Environment.NewLine, ChatExport.ToText(null, new ChatMessage[0]).TrimEnd() + Environment.NewLine);
        }
    }
}
