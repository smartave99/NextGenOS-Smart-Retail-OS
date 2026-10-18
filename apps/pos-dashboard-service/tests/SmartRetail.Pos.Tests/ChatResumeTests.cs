using System.Text.Json;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Providers;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

/// <summary>A discussion goes on after the app is closed and opened: the chat is kept under its own key, comes back on its own
/// when the app starts again soon after, can be gone on with from the Past chats page, and is never mixed with another chat.</summary>
public sealed class ChatResumeTests : IDisposable
{
    private readonly string _root = Directory.CreateTempSubdirectory("chat-resume-").FullName;
    private readonly StorageService _storage;
    private readonly IOptions<AiOptions> _options;
    private DateTimeOffset _now = new(2026, 10, 12, 18, 0, 0, TimeSpan.FromHours(5.5));

    public ChatResumeTests()
    {
        File.WriteAllText(Path.Combine(_root, SmartRetail.AI.Storage.StorageSettingsStore.FileName), JsonSerializer.Serialize(new { DataFolder = Path.Combine(_root, "data") }));
        _options = Options.Create(new AiOptions { SettingsFile = Path.Combine(_root, "settings.json") });
        _storage = new StorageService(_options);
    }

    public void Dispose() => Directory.Delete(_root, recursive: true);

    private FixedClock Clock => new(_now);

    /// <summary>The app as it is when it starts: new services over the same data folder.</summary>
    private (ChatHistoryService History, Conversation Chat, RecordingBackend Backend) Start()
    {
        var clock = Clock;
        var memory = new MemoryService(_storage, new AiEnvironment(_options), clock, NullLogger<MemoryService>.Instance);
        var history = new ChatHistoryService(_storage, memory, clock, NullLogger<ChatHistoryService>.Instance);
        var backend = new RecordingBackend();
        var chat = new Conversation(backend, () => clock.GetLocalNow().DateTime);
        chat.Changed += (_, _) =>
        {
            if (!chat.Busy)
            {
                history.KeepSoFar(chat.Messages, chat.Key);
            }
        };
        chat.Ended += (_, ended) => history.Keep(ended, chat.EndedKey);
        return (history, chat, backend);
    }

    private static async Task Say(Conversation chat, string text)
    {
        Assert.True(chat.Ask(text));
        await chat.Current;
    }

    [Fact]
    public async Task After_the_app_is_closed_and_opened_soon_after_the_discussion_goes_on_with_what_was_said()
    {
        var (history1, chat1, _) = Start();
        await Say(chat1, "I want to try e-rickshaw posters for the shop");
        await Say(chat1, "And how about pamphlets?");
        var key = chat1.Key;
        history1.Keep(chat1.Messages, key);   // the app closing

        _now = _now.AddHours(10);
        var (history2, chat2, backend2) = Start();
        Assert.Empty(chat2.Messages);
        Assert.True(history2.ResumeLatest(chat2, TimeSpan.FromHours(24)));

        Assert.Equal(key, chat2.Key);
        Assert.Equal(4, chat2.Messages.Count);
        await Say(chat2, "Compare both");
        var prompt = backend2.Contexts.Single().ToPrompt();
        Assert.Contains("Owner: I want to try e-rickshaw posters for the shop", prompt);
        Assert.Contains("Owner: And how about pamphlets?", prompt);
        Assert.Contains("You: Answer to: I want to try e-rickshaw posters", prompt);

        // What was said next is kept in the same past chat, not in another one.
        Assert.Single(history2.History.Latest());
        Assert.Contains(history2.History.Get(history2.History.Latest()[0].Id)!.Messages, m => m.Text == "Compare both");
    }

    [Fact]
    public async Task A_chat_long_ago_is_not_brought_back_by_itself_and_New_chat_starts_a_fresh_one()
    {
        var (history1, chat1, _) = Start();
        await Say(chat1, "I want to try e-rickshaw posters for the shop");
        history1.Keep(chat1.Messages, chat1.Key);

        _now = _now.AddDays(3);
        var (history2, chat2, _) = Start();
        Assert.False(history2.ResumeLatest(chat2, TimeSpan.FromHours(24)));
        Assert.Empty(chat2.Messages);

        // And after a restart within a day, the owner may still start fresh: nothing of the old chat is in the next prompt.
        _now = _now.AddHours(1);
        var (history3, chat3, backend3) = Start();
        await Say(chat3, "Something else entirely");
        history3.Keep(chat3.Messages, chat3.Key);
        _now = _now.AddHours(1);
        var (history4, chat4, backend4) = Start();
        Assert.True(history4.ResumeLatest(chat4, TimeSpan.FromHours(24)));
        chat4.Clear();
        await Say(chat4, "A new question");
        var prompt = backend4.Contexts.Single().ToPrompt();
        Assert.DoesNotContain("Something else entirely", prompt);
        Assert.DoesNotContain("e-rickshaw", prompt);
        // The old chats are all still kept, and the fresh one is a chat of its own.
        Assert.Equal(3, history4.History.Latest().Count);
    }

    [Fact]
    public async Task A_kept_chat_can_be_gone_on_with_from_the_past_chats_page_and_the_chat_going_on_is_kept_first()
    {
        var (history, chat, backend) = Start();
        await Say(chat, "First chat about e-rickshaw posters");
        var firstId = history.History.Latest().Single().Id;
        chat.Clear();
        await Say(chat, "Second chat about Diwali sweets");
        var secondKey = chat.Key;

        Assert.True(history.Resume(firstId, chat));
        Assert.NotEqual(secondKey, chat.Key);
        Assert.Equal(2, chat.Messages.Count);

        // The second chat was kept when it was left, and the first goes on under its own key.
        Assert.Equal(2, history.History.Latest().Count);
        await Say(chat, "Back to the posters: what next?");
        var prompt = backend.Contexts.Last().ToPrompt();
        Assert.Contains("First chat about e-rickshaw posters", prompt);
        Assert.DoesNotContain("Diwali", prompt);
        Assert.False(history.Resume("20200101000000-abcdef", chat));
    }

    [Fact]
    public async Task Going_back_to_an_earlier_chat_brings_in_its_words_and_the_chat_going_on_is_left_out()
    {
        var (history, chat, _) = Start();
        await Say(chat, "Should we try e-rickshaw posters?");
        chat.Clear();
        await Say(chat, "Which biscuits should I reorder?");
        chat.Clear();
        await Say(chat, "Thinking about e-rickshaw posters again");

        var recalled = history.Recall("What did we discuss about the e-rickshaw posters?", chat.Key);
        Assert.Contains("Should we try e-rickshaw posters?", recalled);
        Assert.DoesNotContain("biscuits", recalled);
        Assert.DoesNotContain("Thinking about", recalled);
    }

    /// <summary>A chat backend that answers "Answer to: ..." and records the chat so far of every question.</summary>
    private sealed class RecordingBackend : IChatBackend, IContextChat
    {
        public IReadOnlyList<ChatStarter> Starters { get; } = Array.Empty<ChatStarter>();

        public List<ConversationContext> Contexts { get; } = new();

        public Task<ChatMessage> AskAsync(string question, IProgress<string> progress, CancellationToken cancellationToken) =>
            AskAsync(new AskRequest { Question = question }, progress, cancellationToken);

        public Task<ChatMessage> AskAsync(AskRequest request, IProgress<string> progress, CancellationToken cancellationToken)
        {
            Contexts.Add(request.Context);
            return Task.FromResult(new ChatMessage(ChatRole.Assistant, "Answer to: " + request.Question, new DateTime(2026, 10, 12, 18, 0, 0)) { Route = RequestKind.General });
        }

        public Task<ChatMessage> RunAsync(ChatStarter starter, IProgress<string> progress, CancellationToken cancellationToken) =>
            AskAsync(starter.Question, progress, cancellationToken);
    }

    [Fact]
    public async Task A_name_given_to_a_past_chat_stays_when_the_discussion_goes_on_and_is_kept_again()
    {
        var (history1, chat1, _) = Start();
        await Say(chat1, "I want to try e-rickshaw posters for the shop");
        var id = history1.History.Latest()[0].Id;
        Assert.True(history1.Rename(id, "E-rickshaw pilot idea"));

        _now = _now.AddHours(2);
        var (history2, chat2, _) = Start();
        Assert.True(history2.Resume(id, chat2));
        await Say(chat2, "And how about pamphlets?");

        var kept = history2.History.Get(id)!;
        Assert.Equal("E-rickshaw pilot idea", kept.Title);
        Assert.Equal(4, kept.Messages.Count);
        Assert.Single(history2.History.Latest());
        Assert.False(history2.Rename("20200101000000-abcdef", "Nothing"));
    }
}
