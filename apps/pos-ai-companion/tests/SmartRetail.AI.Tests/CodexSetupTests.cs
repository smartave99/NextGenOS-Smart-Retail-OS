using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    public class CodexSetupTests : IDisposable
    {
        // What codex-cli 0.156.1 prints for "codex login --device-auth", colours and all.
        private static readonly string[] DeviceAuthOutput =
        {
            "",
            "Welcome to Codex [v\u001b[90m0.156.1\u001b[0m]",
            "Follow these steps to sign in with ChatGPT using device code authorization:",
            "",
            "1. Open this link in your browser and sign in to your account",
            "   \u001b[94mhttps://auth.openai.com/codex/device\u001b[0m",
            "",
            "2. Enter this one-time code \u001b[90m(expires in 15 minutes)\u001b[0m",
            "   \u001b[94mWRB5-1KWS7\u001b[0m",
        };

        private readonly TempFolder _temp = new TempFolder();
        private readonly FakeCliRunner _runner = new FakeCliRunner();
        private readonly AssistantSettings _settings;

        public CodexSetupTests()
        {
            (_settings, _) = TestSettings.Create();
            _settings.Codex.ExecutablePath = _temp.File("codex-tool");
        }

        public void Dispose() => _temp.Dispose();

        private CodexCliProvider Codex() => new CodexCliProvider(_runner, () => _settings, Path.Combine(_temp.Path, "runs"));

        [Fact]
        public void The_sign_in_page_and_code_are_read_once_both_are_printed()
        {
            var reader = new DeviceCodeReader();
            var found = DeviceAuthOutput.Select(reader.Read).Where(code => code != null).ToList();

            var code = Assert.Single(found);
            Assert.Equal("https://auth.openai.com/codex/device", code.Url);
            Assert.Equal("WRB5-1KWS7", code.Code);
            Assert.Null(reader.Read("   ABCD-EFGH"));
        }

        [Fact]
        public void Only_a_page_on_openai_sites_is_offered()
        {
            var reader = new DeviceCodeReader();

            Assert.Null(reader.Read("Open https://auth.openai.com.evil.example/codex/device"));
            Assert.Null(reader.Read("   WRB5-1KWS7"));
            Assert.Null(reader.Read("Open http://auth.openai.com/codex/device"));
            Assert.Equal("https://chatgpt.com/device", reader.Read("Open https://chatgpt.com/device.").Url);
        }

        [Fact]
        public async Task Signing_in_shows_the_code_at_once_and_ends_signed_in()
        {
            DeviceCode shown = null;
            var loggedIn = false;
            _runner.Handler = call =>
            {
                if (call.Arguments.SequenceEqual(new[] { "login", "--device-auth" }))
                {
                    foreach (var line in DeviceAuthOutput)
                    {
                        call.OutputLine?.Invoke(line);
                    }

                    // The code is on screen while Codex still waits for it to be entered.
                    Assert.Equal("WRB5-1KWS7", shown?.Code);
                    loggedIn = true;
                    return new CliResult { ExitCode = 0, StandardOutput = string.Join("\n", DeviceAuthOutput) + "\nSuccessfully logged in" };
                }

                if (call.Arguments.SequenceEqual(new[] { "--version" }))
                {
                    return new CliResult { ExitCode = 0, StandardOutput = "codex-cli 0.157.0" };
                }

                return loggedIn
                    ? new CliResult { ExitCode = 0, StandardOutput = "Logged in using ChatGPT" }
                    : new CliResult { ExitCode = 1, StandardError = "Not logged in" };
            };

            var status = await Codex().SignInWithChatGptAsync(code => shown = code, CancellationToken.None);

            Assert.True(status.IsReady);
            Assert.Equal("Logged in using ChatGPT", status.Detail);
            var signIn = _runner.Calls.First();
            Assert.Equal("1", signIn.Environment["NO_COLOR"]);
            Assert.True(signIn.Timeout >= TimeSpan.FromMinutes(15));
        }

        [Fact]
        public async Task A_failed_or_expired_sign_in_says_what_happened()
        {
            _runner.Handler = call => new CliResult { ExitCode = 1, StandardError = "Error: device code was declined" };
            var failed = await Assert.ThrowsAsync<AiProviderException>(() => Codex().SignInWithChatGptAsync(null, CancellationToken.None));
            Assert.Contains("device code was declined", failed.Message);

            _runner.Handler = call => new CliResult { TimedOut = true, ExitCode = -1 };
            var expired = await Assert.ThrowsAsync<AiProviderException>(() => Codex().SignInWithChatGptAsync(null, CancellationToken.None));
            Assert.Contains("expired", expired.Message);
        }

        [Fact]
        public async Task Codex_is_installed_with_openais_own_installer_without_questions()
        {
            var lines = new List<string>();
            _runner.Handler = call =>
            {
                call.OutputLine?.Invoke("==> Installing Codex CLI");
                call.OutputLine?.Invoke("  ");
                call.OutputLine?.Invoke("Codex CLI 0.157.0 installed successfully.");
                return new CliResult { ExitCode = 0 };
            };

            await new CodexInstaller(_runner, windows: true).InstallAsync(lines.Add, CancellationToken.None);

            var call = _runner.Calls.Single();
            Assert.EndsWith("powershell.exe", call.FileName);
            Assert.Equal(new[] { "-NoProfile", "-NonInteractive", "-ExecutionPolicy", "Bypass", "-Command" }, call.Arguments.Take(5));
            Assert.Contains("-Uri 'https://chatgpt.com/codex/install.ps1' -OutFile '", call.Arguments.Last());
            Assert.Equal("1", call.Environment["CODEX_NON_INTERACTIVE"]);
            Assert.Equal(new[] { "==> Installing Codex CLI", "Codex CLI 0.157.0 installed successfully." }, lines);

            _runner.Handler = c => new CliResult { ExitCode = 1, StandardError = "Could not reach releases.openai.com" };
            var error = await Assert.ThrowsAsync<InvalidOperationException>(() => new CodexInstaller(_runner, windows: true).InstallAsync(null, CancellationToken.None));
            Assert.Contains("Could not reach releases.openai.com", error.Message);
            await Assert.ThrowsAsync<PlatformNotSupportedException>(() => new CodexInstaller(_runner, windows: false).InstallAsync(null, CancellationToken.None));
        }

        [Fact]
        public void A_path_with_a_quote_cannot_break_out_of_the_installer_command()
        {
            var command = CodexInstaller.CreateInvocation(@"C:\Users\O'Brien\Temp\codex-install.ps1", null).Arguments.Last();

            Assert.Contains(@"-OutFile 'C:\Users\O''Brien\Temp\codex-install.ps1'; & 'C:\Users\O''Brien\Temp\codex-install.ps1'", command);
        }

        [Fact]
        public void The_standalone_codex_folder_is_searched()
        {
            Assert.Contains(CodexInstaller.InstallFolder, ExecutableLocator.CommonUserToolDirectories());
        }
    }
}
