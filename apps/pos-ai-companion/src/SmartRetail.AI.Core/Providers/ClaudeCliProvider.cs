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
    /// <summary>Anthropic's Claude Code CLI in print mode. Runs with <c>--bare</c> and the shop's own
    /// Anthropic API key: Anthropic does not allow third-party products to use a Claude.ai subscription
    /// login, and bare mode never reads it.</summary>
    public sealed class ClaudeCliProvider : CliProviderBase
    {
        internal const string SystemPromptFile = "system-prompt.md";

        private readonly SecretStore _secrets;

        public ClaudeCliProvider(ICliRunner runner, Func<AssistantSettings> settings, SecretStore secrets, string workspaceRoot = null)
            : base(runner, settings, workspaceRoot)
        {
            _secrets = secrets ?? throw new ArgumentNullException(nameof(secrets));
        }

        public override string Id => ProviderIds.ClaudeCli;

        public override string DisplayName => "Claude CLI (Anthropic)";

        protected override string CommandName => "claude";

        protected override CliProviderSettings ProviderSettings => Settings().ClaudeCli;

        protected override string InstallHint => "Install Claude Code from https://claude.com/product/claude-code (PowerShell: irm https://claude.ai/install.ps1 | iex).";

        private const string MissingKeyHelp = "Claude CLI needs an Anthropic API key (Settings → API keys). Anthropic does not allow apps to use a Claude.ai subscription sign-in.";

        public override async Task<AiResponse> CompleteAsync(AiRequest request, CancellationToken cancellationToken)
        {
            var executable = RequireExecutable();
            var apiKey = _secrets.Get(SecretNames.AnthropicApiKey)
                ?? throw new AiProviderException(Id, MissingKeyHelp);

            using (var workspace = new RunWorkspace(WorkspaceRoot))
            {
                var systemPromptPath = string.IsNullOrWhiteSpace(request.SystemPrompt)
                    ? null
                    : workspace.WriteFile(SystemPromptFile, request.SystemPrompt);

                var invocation = new CliInvocation
                {
                    FileName = executable,
                    WorkingDirectory = workspace.DirectoryPath,
                    StandardInput = request.UserPrompt,
                    Timeout = PromptTimeout,
                };
                invocation.Arguments.AddRange(BuildArguments(systemPromptPath));
                invocation.Environment["NO_COLOR"] = "1";
                invocation.Environment["ANTHROPIC_API_KEY"] = apiKey;
                invocation.Environment["ANTHROPIC_AUTH_TOKEN"] = null;
                invocation.Environment["CLAUDE_CODE_OAUTH_TOKEN"] = null;

                var result = await RunPromptAsync(invocation, cancellationToken).ConfigureAwait(false);
                var output = ParseOutput(result.StandardOutput);
                if (result.TimedOut || result.ExitCode != 0 || output.IsError || string.IsNullOrWhiteSpace(output.Text))
                {
                    if (output.IsError && !string.IsNullOrWhiteSpace(output.Text) && !result.TimedOut)
                    {
                        throw new AiProviderException(Id, "Claude CLI: " + Tail(output.Text));
                    }

                    throw Failure(result, "Claude rejected the Anthropic API key. Check it in Settings → API keys.");
                }

                return new AiResponse(Id, output.Text.Trim(), result.Duration);
            }
        }

        internal List<string> BuildArguments(string systemPromptPath)
        {
            var settings = Settings().ClaudeCli;
            var arguments = new List<string>
            {
                "-p",
                "--bare",
                "--output-format", "json",
                "--tools", "",
                "--no-session-persistence",
                "--disable-slash-commands",
                "--strict-mcp-config",
            };

            if (systemPromptPath != null)
            {
                arguments.Add("--system-prompt-file");
                arguments.Add(systemPromptPath);
            }

            var model = CheckToken(settings.Model, "Claude model");
            if (model != null)
            {
                arguments.Add("--model");
                arguments.Add(model);
            }

            var effort = CheckToken(settings.Effort, "Claude effort level");
            if (effort != null)
            {
                arguments.Add("--effort");
                arguments.Add(effort.ToLowerInvariant());
            }

            return arguments;
        }

        /// <summary>Reads the single JSON object printed by <c>--output-format json</c>.</summary>
        internal static (string Text, bool IsError) ParseOutput(string standardOutput)
        {
            var text = (standardOutput ?? "").Trim();
            var start = text.IndexOf('{');
            var end = text.LastIndexOf('}');
            if (start >= 0 && end > start)
            {
                try
                {
                    var json = JObject.Parse(text.Substring(start, end - start + 1));
                    return ((string)json["result"] ?? "", (bool?)json["is_error"] ?? false);
                }
                catch (JsonException)
                {
                }
            }

            return (text, false);
        }

        protected override Task<ProviderStatus> CheckReadinessAsync(string executable, string version, CancellationToken cancellationToken)
        {
            return Task.FromResult(_secrets.Has(SecretNames.AnthropicApiKey)
                ? ProviderStatus.Ready("Installed; uses your saved Anthropic API key.", version)
                : ProviderStatus.NotReady("Installed, but no Anthropic API key is saved (Settings → API keys).", version));
        }
    }
}
