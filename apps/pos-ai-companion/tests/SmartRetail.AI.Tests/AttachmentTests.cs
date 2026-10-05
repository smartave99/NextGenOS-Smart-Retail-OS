using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SmartRetail.AI.Assistant;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Memory;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    /// <summary>Questions sent with photos and voice notes: the chat, the assistant, the router and the AI tools.</summary>
    public class AttachmentTests : IDisposable
    {
        private readonly TempFolder _temp = new TempFolder();
        private readonly AssistantSettings _settings = TestSettings.Create().Settings;

        public AttachmentTests()
        {
            _settings.Codex.ExecutablePath = _temp.File("codex-tool");
            _settings.CustomCli.ExecutablePath = _temp.File("custom-tool");
        }

        public void Dispose() => _temp.Dispose();

        private string Photo(string name = "shelf.jpg")
        {
            var path = Path.Combine(_temp.Path, name);
            File.WriteAllBytes(path, new byte[] { 0xFF, 0xD8, 0xFF, 0xE0, 1, 2, 3 });
            return path;
        }

        private string Voice()
        {
            var path = Path.Combine(_temp.Path, "voice.wav");
            File.WriteAllBytes(path, new byte[] { (byte)'R', (byte)'I', (byte)'F', (byte)'F', 1, 2, 3 });
            return path;
        }

        [Fact]
        public async Task The_chat_sends_photos_with_the_question_and_keeps_them_on_the_question()
        {
            var backend = new RecordingBackend();
            var chat = new Conversation(backend);
            var photo = new ChatAttachment(AttachmentKind.Photo, Photo());

            Assert.True(chat.Ask("  What is this?  ", new[] { photo }));
            await chat.Current;

            Assert.Equal(("What is this?", 1), (backend.Question, backend.Attachments.Count));
            var asked = chat.Messages.First();
            Assert.Equal(ChatRole.Owner, asked.Role);
            Assert.Same(photo, asked.Attachments.Single());
            Assert.Equal("shelf.jpg", photo.Name);
        }

        [Fact]
        public async Task A_photo_alone_is_a_question_but_nothing_at_all_is_not()
        {
            var chat = new Conversation(new RecordingBackend());
            Assert.False(chat.Ask("   ", null));
            Assert.True(chat.Ask("", new[] { new ChatAttachment(AttachmentKind.Photo, Photo()) }));
            await chat.Current;
            Assert.Equal("", chat.Messages.First().Text);
        }

        [Fact]
        public async Task A_chat_that_cannot_read_photos_says_so()
        {
            var chat = new Conversation(new TextOnlyBackend());
            chat.Ask("What is this?", new[] { new ChatAttachment(AttachmentKind.Photo, Photo()) });
            await chat.Current;
            var reply = chat.Messages.Last();
            Assert.True(reply.IsProblem);
            Assert.Contains("cannot read photos", reply.Text);
        }

        [Fact]
        public async Task Remember_is_typed_so_a_voice_note_goes_to_the_ai()
        {
            var inner = new RecordingBackend();
            var memory = new MemoryChatBackend(inner, new NoMemory());
            await memory.AskAsync("", new[] { new ChatAttachment(AttachmentKind.Voice, Voice()) }, null, CancellationToken.None);
            Assert.Equal(AttachmentKind.Voice, inner.Attachments.Single().Kind);
        }

        [Fact]
        public async Task The_router_skips_a_tool_that_cannot_read_photos()
        {
            var claude = new FakeProvider(ProviderIds.ClaudeCli) { ReadsAttachments = false };
            var codex = new FakeProvider(ProviderIds.CodexCli).Answers("It is tea.");
            _settings.ProviderOrder = new List<string> { ProviderIds.ClaudeCli, ProviderIds.CodexCli };
            var router = new ProviderRouter(new IAiProvider[] { claude, codex }, () => _settings);
            var request = new AiRequest { UserPrompt = "What is this?" };
            request.Images.Add(Photo());

            var reply = await router.CompleteAsync(request, ProviderIds.Auto, CancellationToken.None);

            Assert.Equal(("It is tea.", 0), (reply.Text, claude.Requests.Count));
            var chosen = await Assert.ThrowsAsync<AiProviderException>(() => router.CompleteAsync(request, ProviderIds.ClaudeCli, CancellationToken.None));
            Assert.Contains("cannot read photos", chosen.Message);
        }

        [Fact]
        public async Task The_assistant_shows_the_photo_to_both_steps_and_takes_the_words_heard_from_a_voice_note()
        {
            var codex = new FakeProvider(ProviderIds.CodexCli).Answers(
                "{\"sql\": \"SELECT COUNT(*) AS Bills FROM InvoiceInfo\", \"explanation\": \"Bills\", \"heard\": \"aaj kitne bill bane\"}",
                "Aaj 18 bill bane.");
            var database = new FakeQueryExecutor
            {
                Handler = sql => sql.Contains("INFORMATION_SCHEMA")
                    ? FakeQueryExecutor.Table(new[] { "TABLE_NAME", "COLUMN_NAME", "DATA_TYPE", "CHARACTER_MAXIMUM_LENGTH" }, new object[] { "InvoiceInfo", "Inv_ID", "int", null })
                    : FakeQueryExecutor.Table(new[] { "Bills" }, new object[] { 18 }),
            };
            var photo = Photo();
            var attachments = new[] { new ChatAttachment(AttachmentKind.Photo, photo), new ChatAttachment(AttachmentKind.Voice, Voice()) };

            var answer = await new BusinessAssistant(new ProviderRouter(new IAiProvider[] { codex }, () => _settings), database, () => _settings)
                .AskAsync("", ProviderIds.Auto, null, CancellationToken.None, attachments);

            Assert.Equal(("Aaj 18 bill bane.", "aaj kitne bill bane"), (answer.Answer, answer.Heard));
            var sql = codex.Requests[0];
            Assert.Equal(new[] { photo }, sql.Images);
            Assert.Single(sql.Audio);
            Assert.Contains("sent a photo", sql.UserPrompt);
            Assert.Contains("asked by voice", sql.UserPrompt);
            Assert.Contains("\"heard\"", sql.SystemPrompt);
            var written = codex.Requests[1];
            Assert.Equal(new[] { photo }, written.Images);
            Assert.Empty(written.Audio);
            Assert.Contains("aaj kitne bill bane", written.UserPrompt);
        }

        [Fact]
        public async Task Codex_gets_copies_of_the_photos_first_on_its_command_line()
        {
            var runner = new FakeCliRunner
            {
                Handler = call =>
                {
                    Assert.True(File.Exists(call.Arguments[2]), "the copy is in the run's folder while Codex runs");
                    File.WriteAllText(FakeCliRunner.ArgumentAfter(call, "--output-last-message"), "It is tea.");
                    return new CliResult { ExitCode = 0 };
                },
            };
            var codex = new CodexCliProvider(runner, () => _settings, Path.Combine(_temp.Path, "runs"));
            var request = new AiRequest { UserPrompt = "What is this?" };
            request.Images.Add(Photo());

            Assert.Null(codex.CannotRead(request));
            var reply = await codex.CompleteAsync(request, CancellationToken.None);

            var call = runner.Calls.Single();
            Assert.Equal("It is tea.", reply.Text);
            Assert.Equal(new[] { "exec", "--image", Path.Combine(call.WorkingDirectory, "photo-1.jpg"), "--skip-git-repo-check" }, call.Arguments.Take(4));
            Assert.Equal("-", call.Arguments.Last());
        }

        [Fact]
        public async Task A_voice_note_goes_to_Codex_through_its_app_server()
        {
            var fake = new FakeAppServer { Chatty = false };
            fake.Answers["thread/start"] = _ => JObject.Parse("{\"thread\":{\"id\":\"th-1\"}}");
            fake.Answers["turn/start"] = _ =>
            {
                fake.Say("{\"method\":\"item/completed\",\"params\":{\"threadId\":\"th-1\",\"item\":{\"type\":\"agentMessage\",\"id\":\"m1\",\"text\":\"Aaj 18 bill bane.\"}}}");
                fake.Say("{\"method\":\"turn/completed\",\"params\":{\"threadId\":\"th-1\",\"turn\":{\"id\":\"tu-1\",\"status\":\"completed\"}}}");
                return JObject.Parse("{\"turn\":{\"id\":\"tu-1\"}}");
            };
            var runner = new FakeCliRunner();
            var codex = new CodexCliProvider(runner, () => _settings, Path.Combine(_temp.Path, "runs")) { StartChannel = _ => fake };
            var request = new AiRequest { UserPrompt = "Voice question" };
            request.Audio.Add(Voice());

            var reply = await codex.CompleteAsync(request, CancellationToken.None);

            Assert.Equal("Aaj 18 bill bane.", reply.Text);
            Assert.Empty(runner.Calls);
            var input = (JArray)fake.Received.Single(m => (string)m["method"] == "turn/start")["params"]["input"];
            Assert.Equal("localAudio", (string)input[1]["type"]);
            Assert.EndsWith("voice-1.wav", (string)input[1]["path"]);
        }

        [Fact]
        public async Task A_voice_note_that_Codex_cannot_take_says_to_type_instead()
        {
            var codex = new CodexCliProvider(new FakeCliRunner(), () => _settings, Path.Combine(_temp.Path, "runs"))
            {
                StartChannel = _ => throw new CliStartException("Could not start codex app-server", null),
            };
            var request = new AiRequest { UserPrompt = "Voice question" };
            request.Audio.Add(Voice());

            var failure = await Assert.ThrowsAsync<AiProviderException>(() => codex.CompleteAsync(request, CancellationToken.None));
            Assert.Contains("Type the question instead", failure.Message);
        }

        [Fact]
        public async Task A_custom_tool_gets_the_files_only_where_its_command_asks_for_them()
        {
            var runner = new FakeCliRunner { Handler = call => new CliResult { ExitCode = 0, StandardOutput = "I see a photo." } };
            var custom = new CustomCliProvider(runner, () => _settings, Path.Combine(_temp.Path, "runs"));
            var request = new AiRequest { UserPrompt = "What is this?" };
            request.Images.Add(Photo("one.jpg"));
            request.Images.Add(Photo("two.png"));

            _settings.CustomCli.Arguments = "{prompt_file}";
            Assert.Contains("{image_files}", custom.CannotRead(request));

            _settings.CustomCli.Arguments = "--prompt {prompt_file} --images {image_files} --end";
            Assert.Null(custom.CannotRead(request));
            await custom.CompleteAsync(request, CancellationToken.None);

            var call = runner.Calls.Single();
            var images = call.Arguments.SkipWhile(a => a != "--images").Skip(1).TakeWhile(a => a != "--end").ToList();
            Assert.Equal(new[] { "photo-1.jpg", "photo-2.png" }, images.Select(Path.GetFileName));
            var voice = new AiRequest();
            voice.Audio.Add(Voice());
            Assert.Contains("{audio_files}", custom.CannotRead(voice));
        }

        private sealed class RecordingBackend : IChatBackend, IAttachmentChat
        {
            public string Question { get; private set; }

            public IReadOnlyList<ChatAttachment> Attachments { get; private set; } = new ChatAttachment[0];

            public IReadOnlyList<ChatStarter> Starters => new ChatStarter[0];

            public Task<ChatMessage> AskAsync(string question, IProgress<string> progress, CancellationToken cancellationToken) =>
                AskAsync(question, null, progress, cancellationToken);

            public Task<ChatMessage> AskAsync(string question, IReadOnlyList<ChatAttachment> attachments, IProgress<string> progress, CancellationToken cancellationToken)
            {
                Question = question;
                Attachments = attachments ?? new ChatAttachment[0];
                return Task.FromResult(new ChatMessage(ChatRole.Assistant, "ok", DateTime.Now));
            }

            public Task<ChatMessage> RunAsync(ChatStarter starter, IProgress<string> progress, CancellationToken cancellationToken) =>
                AskAsync(starter.Question, progress, cancellationToken);
        }

        private sealed class NoMemory : IMemory
        {
            public MemoryBook Load() => new MemoryBook();

            public string Change(MemoryChange change) => null;

            public IReadOnlyList<MemoryOutcome> Propose(IEnumerable<MemoryChange> changes, bool askFirst) => new MemoryOutcome[0];
        }

        private sealed class TextOnlyBackend : IChatBackend
        {
            public IReadOnlyList<ChatStarter> Starters => new ChatStarter[0];

            public Task<ChatMessage> AskAsync(string question, IProgress<string> progress, CancellationToken cancellationToken) =>
                Task.FromResult(new ChatMessage(ChatRole.Assistant, "ok", DateTime.Now));

            public Task<ChatMessage> RunAsync(ChatStarter starter, IProgress<string> progress, CancellationToken cancellationToken) =>
                AskAsync(starter.Question, progress, cancellationToken);
        }
    }
}
