using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Posters;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    public class PosterArtworkTests : IDisposable
    {
        private readonly TempFolder _temp = new TempFolder();
        private readonly FakeCliRunner _runner = new FakeCliRunner();
        private readonly AssistantSettings _settings;

        public PosterArtworkTests()
        {
            (_settings, _) = TestSettings.Create();
            _settings.Codex.ExecutablePath = _temp.File("codex-tool");
        }

        public void Dispose() => _temp.Dispose();

        private CodexCliProvider Codex() =>
            new CodexCliProvider(_runner, () => _settings, Path.Combine(_temp.Path, "runs")) { CodexHome = Path.Combine(_temp.Path, "codex-home") };

        private static PosterArtworkRequest Clearance => new PosterArtworkRequest { Theme = "a clearance sale: energetic red, coral and orange." };

        [Fact]
        public async Task Codex_makes_artwork_without_text_in_an_empty_folder()
        {
            string[] filesAtStart = null;
            _runner.Handler = call =>
            {
                filesAtStart = Directory.GetFiles(call.WorkingDirectory);
                File.WriteAllBytes(Path.Combine(call.WorkingDirectory, PosterArtworkPrompt.ResultFileName), ProductPhotoTests.Png);
                return new CliResult { ExitCode = 0, Duration = TimeSpan.FromSeconds(50) };
            };
            var messages = new List<string>();

            var result = await Codex().MakePosterArtworkAsync(Clearance, new ListProgress(messages), CancellationToken.None);

            Assert.Equal(ProductPhotoTests.Png, result.Image);
            Assert.Equal("Codex CLI (OpenAI)", result.ProviderName);
            Assert.Equal(TimeSpan.FromSeconds(50), result.Duration);
            Assert.Contains("poster's artwork", Assert.Single(messages));
            Assert.Empty(filesAtStart);

            var call = _runner.Calls.Single();
            Assert.Equal("exec", call.Arguments[0]);
            Assert.DoesNotContain("--image", call.Arguments);
            Assert.DoesNotContain("--output-schema", call.Arguments);
            Assert.Equal("image_generation", FakeCliRunner.ArgumentAfter(call, "--enable"));
            Assert.Equal("workspace-write", FakeCliRunner.ArgumentAfter(call, "--sandbox"));
            Assert.Equal("-", call.Arguments.Last());
            Assert.Contains("with this theme: a clearance sale: energetic red, coral and orange.\n", call.StandardInput);
            Assert.Contains("Strictly no text of any kind", call.StandardInput);
            Assert.Contains("No products, packages", call.StandardInput);
            Assert.Contains("Save the image as poster-art.png", call.StandardInput);
            Assert.True(call.Timeout >= CodexCliProvider.MinimumPhotoTimeout);
            Assert.False(Directory.Exists(call.WorkingDirectory), "the working folder is cleaned up");
        }

        [Fact]
        public async Task No_image_is_a_clear_problem()
        {
            _runner.Handler = call => new CliResult { ExitCode = 0 };

            var error = await Assert.ThrowsAsync<AiProviderException>(() => Codex().MakePosterArtworkAsync(Clearance, null, CancellationToken.None));

            Assert.Contains("made no image", error.Message);
        }

        [Fact]
        public async Task A_poster_needs_a_theme()
        {
            await Assert.ThrowsAsync<AiProviderException>(() => Codex().MakePosterArtworkAsync(new PosterArtworkRequest(), null, CancellationToken.None));

            Assert.Empty(_runner.Calls);
        }

        private sealed class ListProgress : IProgress<string>
        {
            private readonly List<string> _messages;

            public ListProgress(List<string> messages) => _messages = messages;

            public void Report(string value) => _messages.Add(value);
        }
    }
}
