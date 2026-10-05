using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Providers
{
    /// <summary>Google's Antigravity CLI (<c>agy</c>) in headless print mode. Signs in with the Google
    /// account used in <c>agy</c>, or with a Gemini API key when that option is on.</summary>
    public sealed class AntigravityCliProvider : CliProviderBase
    {
        /// <summary>Longer prompts go through a file: the prompt is otherwise a command-line argument,
        /// and Windows caps a command line at 32,767 characters.</summary>
        internal const int MaxInlinePromptLength = 24000;

        internal const string PromptFile = "prompt.md";

        internal const string FileHandOffPrompt =
            "Read the file prompt.md in the current directory and follow the instructions in it exactly. Reply with only the final answer.";

        private readonly SecretStore _secrets;

        public AntigravityCliProvider(ICliRunner runner, Func<AssistantSettings> settings, SecretStore secrets, string workspaceRoot = null)
            : base(runner, settings, workspaceRoot)
        {
            _secrets = secrets ?? throw new ArgumentNullException(nameof(secrets));
        }

        public override string Id => ProviderIds.AntigravityCli;

        public override string DisplayName => "Antigravity CLI (Google)";

        protected override string CommandName => "agy";

        protected override CliProviderSettings ProviderSettings => Settings().Antigravity;

        protected override string InstallHint => "Install it in PowerShell with: irm https://antigravity.google/cli/install.ps1 | iex — then run agy once to sign in.";

        public override async Task<AiResponse> CompleteAsync(AiRequest request, CancellationToken cancellationToken)
        {
            var executable = RequireExecutable();
            var settings = Settings().Antigravity;
            using (var workspace = new RunWorkspace(WorkspaceRoot))
            {
                var prompt = PromptText.Combine(request.SystemPrompt, request.UserPrompt);
                string promptArgument;
                // A .cmd launcher would pass the prompt through cmd.exe, which cannot carry arbitrary text safely.
                if (prompt.Length <= MaxInlinePromptLength && !ProcessCliRunner.IsBatchFile(executable) && prompt.IndexOf('\0') < 0)
                {
                    promptArgument = prompt;
                }
                else
                {
                    workspace.WriteFile(PromptFile, prompt);
                    promptArgument = FileHandOffPrompt;
                }

                var invocation = new CliInvocation
                {
                    FileName = executable,
                    WorkingDirectory = workspace.DirectoryPath,
                    // agy has its own --print-timeout; give it a little longer to report before we stop it.
                    Timeout = PromptTimeout + TimeSpan.FromSeconds(15),
                };
                invocation.Arguments.AddRange(BuildArguments(promptArgument));
                invocation.Environment["NO_COLOR"] = "1";
                if (settings.UseGeminiApiKey)
                {
                    invocation.Environment["GEMINI_API_KEY"] = _secrets.Get(SecretNames.GeminiApiKey)
                        ?? throw new AiProviderException(Id, "\"Use Gemini API key\" is on, but no Gemini API key is saved (Settings → API keys).");
                }

                var result = await RunPromptAsync(invocation, cancellationToken).ConfigureAwait(false);
                var output = ParseOutput(result.StandardOutput);
                if (!result.TimedOut && output.Error != null)
                {
                    throw new AiProviderException(Id, "Antigravity CLI: " + Tail(output.Error));
                }

                if (result.TimedOut || result.ExitCode != 0 || string.IsNullOrWhiteSpace(output.Text))
                {
                    throw Failure(result, "Antigravity is not signed in. Run \"agy\" once in a terminal to sign in, or turn on \"Use Gemini API key\" in Settings.");
                }

                return new AiResponse(Id, output.Text.Trim(), result.Duration);
            }
        }

        internal List<string> BuildArguments(string promptArgument)
        {
            var settings = Settings().Antigravity;
            var arguments = new List<string>
            {
                "-p", promptArgument,
                "--output-format", "json",
                "--disable-slash-commands",
                "--sandbox",
                "--print-timeout", (int)PromptTimeout.TotalSeconds + "s",
            };

            var model = CheckToken(settings.Model, "Antigravity model");
            if (model != null)
            {
                arguments.Add("--model");
                arguments.Add(model);
            }

            var effort = CheckToken(settings.Effort, "Antigravity effort level");
            if (effort != null)
            {
                arguments.Add("--effort");
                arguments.Add(effort.ToLowerInvariant());
            }

            return arguments;
        }

        /// <summary>Reads <c>{"status": "SUCCESS", "response": "…", "error": …}</c> from <c>--output-format json</c>.</summary>
        internal static (string Text, string Error) ParseOutput(string standardOutput)
        {
            var text = (standardOutput ?? "").Trim();
            var start = text.IndexOf('{');
            var end = text.LastIndexOf('}');
            if (start >= 0 && end > start)
            {
                try
                {
                    var json = JObject.Parse(text.Substring(start, end - start + 1));
                    var status = (string)json["status"] ?? "";
                    var error = json["error"];
                    var errorText = error == null || error.Type == JTokenType.Null
                        ? null
                        : error.Type == JTokenType.Object ? (string)error["message"] ?? error.ToString(Formatting.None) : error.ToString();
                    if (errorText == null && status.Length > 0 && !status.Equals("SUCCESS", StringComparison.OrdinalIgnoreCase))
                    {
                        errorText = "finished with status " + status;
                    }

                    return ((string)json["response"] ?? "", string.IsNullOrWhiteSpace(errorText) ? null : errorText);
                }
                catch (JsonException)
                {
                }
            }

            return (text, null);
        }

        protected override Task<ProviderStatus> CheckReadinessAsync(string executable, string version, CancellationToken cancellationToken)
        {
            var settings = Settings().Antigravity;
            if (settings.UseGeminiApiKey)
            {
                return Task.FromResult(_secrets.Has(SecretNames.GeminiApiKey)
                    ? ProviderStatus.Ready("Installed; uses your saved Gemini API key.", version)
                    : ProviderStatus.NotReady("\"Use Gemini API key\" is on, but no Gemini API key is saved.", version));
            }

            return Task.FromResult(ProviderStatus.Ready("Installed. Uses the Google account signed in to agy (run \"agy\" once in a terminal to sign in).", version));
        }
    }
}
