using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Providers
{
    /// <summary>Shared plumbing for providers that run a locally installed AI command-line tool.
    /// Each request runs in a fresh empty folder with a single prompt; the tool is used only to
    /// generate text, never to run commands or edit files.</summary>
    public abstract class CliProviderBase : IAiProvider
    {
        private static readonly Regex SafeToken = new Regex(@"^[A-Za-z0-9][A-Za-z0-9._:/@+-]{0,99}$");

        private static readonly string[] AuthFailureMarkers =
        {
            "not logged in", "please log in", "please login", "codex login", "unauthorized", "401",
            "authentication", "invalid api key", "invalid_api_key", "invalid x-api-key", "sign in", "signin",
        };

        protected CliProviderBase(ICliRunner runner, Func<AssistantSettings> settings, string workspaceRoot)
        {
            Runner = runner ?? throw new ArgumentNullException(nameof(runner));
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
            WorkspaceRoot = workspaceRoot;
        }

        public abstract string Id { get; }

        public abstract string DisplayName { get; }

        public ProviderKind Kind => ProviderKind.Cli;

        protected ICliRunner Runner { get; }

        protected Func<AssistantSettings> Settings { get; }

        protected string WorkspaceRoot { get; }

        protected abstract string CommandName { get; }

        protected abstract CliProviderSettings ProviderSettings { get; }

        /// <summary>One sentence telling the shop how to install the tool.</summary>
        protected abstract string InstallHint { get; }

        public string ResolveExecutable()
        {
            return ExecutableLocator.Resolve(ProviderSettings.ExecutablePath, CommandName, ExecutableLocator.CommonUserToolDirectories());
        }

        public async Task<ProviderStatus> CheckAsync(CancellationToken cancellationToken)
        {
            var executable = ResolveExecutable();
            if (executable == null)
            {
                return ProviderStatus.NotReady(string.IsNullOrWhiteSpace(ProviderSettings.ExecutablePath)
                    ? "Not installed (or not on PATH). " + InstallHint
                    : "Not found at " + ProviderSettings.ExecutablePath + ".");
            }

            string version;
            try
            {
                var result = await RunToolAsync(executable, new[] { "--version" }, null, TimeSpan.FromSeconds(30), cancellationToken).ConfigureAwait(false);
                version = FirstLine(result.StandardOutput) ?? FirstLine(result.StandardError) ?? "";
            }
            catch (CliStartException ex)
            {
                return ProviderStatus.NotReady(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return ProviderStatus.NotReady(ex.Message);
            }

            return await CheckReadinessAsync(executable, version, cancellationToken).ConfigureAwait(false);
        }

        public abstract Task<AiResponse> CompleteAsync(AiRequest request, CancellationToken cancellationToken);

        /// <summary>Sign-in or configuration check after the tool was found; the default only reports it installed.</summary>
        protected virtual Task<ProviderStatus> CheckReadinessAsync(string executable, string version, CancellationToken cancellationToken)
        {
            return Task.FromResult(ProviderStatus.Ready("Installed.", version));
        }

        protected string RequireExecutable()
        {
            return ResolveExecutable()
                ?? throw new AiProviderException(Id, DisplayName + " is not installed (or not on PATH). " + InstallHint);
        }

        protected Task<CliResult> RunToolAsync(
            string executable,
            IEnumerable<string> arguments,
            string standardInput,
            TimeSpan timeout,
            CancellationToken cancellationToken,
            string workingDirectory = null,
            IDictionary<string, string> environment = null)
        {
            var invocation = new CliInvocation
            {
                FileName = executable,
                StandardInput = standardInput,
                Timeout = timeout,
                WorkingDirectory = workingDirectory ?? Path.GetTempPath(),
            };
            invocation.Arguments.AddRange(arguments);
            invocation.Environment["NO_COLOR"] = "1";
            if (environment != null)
            {
                foreach (var pair in environment)
                {
                    invocation.Environment[pair.Key] = pair.Value;
                }
            }

            return Runner.RunAsync(invocation, cancellationToken);
        }

        protected async Task<CliResult> RunPromptAsync(CliInvocation invocation, CancellationToken cancellationToken)
        {
            try
            {
                return await Runner.RunAsync(invocation, cancellationToken).ConfigureAwait(false);
            }
            catch (CliStartException ex)
            {
                throw new AiProviderException(Id, ex.Message, canFallback: true, innerException: ex);
            }
            catch (ArgumentException ex)
            {
                throw new AiProviderException(Id, ex.Message, canFallback: true, innerException: ex);
            }
        }

        protected TimeSpan PromptTimeout => TimeSpan.FromSeconds(Math.Max(15, ProviderSettings.TimeoutSeconds));

        /// <summary>Returns null for an empty value; rejects anything that is not a plain model/effort name.</summary>
        protected string CheckToken(string value, string what)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            value = value.Trim();
            if (!SafeToken.IsMatch(value))
            {
                throw new AiProviderException(Id, "The " + what + " \"" + value + "\" contains characters that are not allowed.", canFallback: false);
            }

            return value;
        }

        protected AiProviderException Failure(CliResult result, string signInHelp)
        {
            if (result.TimedOut)
            {
                return new AiProviderException(Id, DisplayName + " did not answer within " + (int)PromptTimeout.TotalSeconds + " seconds.");
            }

            if (KnownFailure(result) is AiProviderException known)
            {
                return known;
            }

            var output = ErrorText(result).ToLowerInvariant();
            if (AuthFailureMarkers.Any(output.Contains))
            {
                return new AiProviderException(Id, signInHelp);
            }

            var detail = FailureDetail(result);
            return new AiProviderException(Id, DisplayName + " failed (exit code " + result.ExitCode + ")" + (detail.Length > 0 ? ": " + detail : "."));
        }

        /// <summary>A failure the tool reports in its own way, e.g. a usage limit, in plain words; null for the usual handling.</summary>
        protected virtual AiProviderException KnownFailure(CliResult result) => null;

        /// <summary>What is searched for a sign-in problem: everything the tool wrote.</summary>
        protected virtual string ErrorText(CliResult result) => result.StandardError + "\n" + result.StandardOutput;

        /// <summary>What went wrong, for the message: the end of what the tool wrote.</summary>
        protected virtual string FailureDetail(CliResult result) =>
            Tail(string.IsNullOrWhiteSpace(result.StandardError) ? result.StandardOutput : result.StandardError);

        protected static string FirstLine(string text)
        {
            var line = (text ?? "").Split('\n').Select(l => l.Trim()).FirstOrDefault(l => l.Length > 0);
            return line;
        }

        protected static string Tail(string text, int maxLength = 500)
        {
            text = (text ?? "").Trim();
            return text.Length <= maxLength ? text : "…" + text.Substring(text.Length - maxLength);
        }
    }

    internal static class PromptText
    {
        /// <summary>For tools without a separate system-prompt option: instructions first, then the task.</summary>
        public static string Combine(string systemPrompt, string userPrompt)
        {
            if (string.IsNullOrWhiteSpace(systemPrompt))
            {
                return userPrompt ?? "";
            }

            return "<instructions>\n" + systemPrompt.Trim() + "\n</instructions>\n\n" + (userPrompt ?? "");
        }
    }
}
