using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Providers
{
    /// <summary>Any other AI command-line tool the shop wants to use (for example a local Ollama).
    /// The command and its arguments come from Settings.</summary>
    public sealed class CustomCliProvider : CliProviderBase, IReadsAttachments
    {
        internal const string PromptFile = "prompt.md";
        internal const string SystemFile = "system.md";

        public CustomCliProvider(ICliRunner runner, Func<AssistantSettings> settings, string workspaceRoot = null)
            : base(runner, settings, workspaceRoot)
        {
        }

        public override string Id => ProviderIds.CustomCli;

        public override string DisplayName
        {
            get
            {
                var name = Settings().CustomCli.DisplayName;
                return string.IsNullOrWhiteSpace(name) ? "Custom CLI" : name.Trim();
            }
        }

        // The command comes only from ExecutablePath; there is no default to search for.
        protected override string CommandName => null;

        protected override CliProviderSettings ProviderSettings => Settings().CustomCli;

        protected override string InstallHint => "Set the command and its arguments in Settings → CLI tools → Custom CLI.";

        /// <summary>The tool gets photos and voice notes only where its arguments ask for them: {image_files} and
        /// {audio_files}, each becoming the files' paths.</summary>
        public string CannotRead(AiRequest request)
        {
            var arguments = Settings().CustomCli.Arguments ?? "";
            if (request.Images.Count > 0 && !arguments.Contains(ImageFiles))
            {
                return "its command takes no photos (" + ImageFiles + ")";
            }

            return request.Audio.Count > 0 && !arguments.Contains(AudioFiles) ? "its command takes no voice notes (" + AudioFiles + ")" : null;
        }

        private const string ImageFiles = "{image_files}";
        private const string AudioFiles = "{audio_files}";

        public override async Task<AiResponse> CompleteAsync(AiRequest request, CancellationToken cancellationToken)
        {
            var settings = Settings().CustomCli;
            var executable = RequireExecutable();
            using (var workspace = new RunWorkspace(WorkspaceRoot))
            {
                var prompt = PromptText.Combine(request.SystemPrompt, request.UserPrompt);
                var promptPath = workspace.WriteFile(PromptFile, prompt);
                var systemPath = workspace.WriteFile(SystemFile, request.SystemPrompt);
                var model = settings.Model?.Trim() ?? "";

                var invocation = new CliInvocation
                {
                    FileName = executable,
                    WorkingDirectory = workspace.DirectoryPath,
                    StandardInput = settings.PromptViaStdin ? prompt : null,
                    Timeout = PromptTimeout,
                };
                var images = Copies(workspace, request.Images, "photo");
                var audio = Copies(workspace, request.Audio, "voice");
                invocation.Arguments.AddRange(CommandLine.Split(settings.Arguments).SelectMany<string, string>(argument =>
                    argument == ImageFiles ? images
                    : argument == AudioFiles ? audio
                    : new[]
                    {
                        argument
                            .Replace("{model}", model)
                            .Replace("{prompt_file}", promptPath)
                            .Replace("{system_file}", systemPath)
                            .Replace("{workdir}", workspace.DirectoryPath),
                    }));
                invocation.Environment["NO_COLOR"] = "1";
                if (request.OnText != null && string.IsNullOrWhiteSpace(settings.JsonResultField))
                {
                    // The tool prints its answer: show it as it comes.
                    var written = new StringBuilder();
                    invocation.StandardOutputLine = line => request.OnText(written.AppendLine(line).ToString().Trim());
                }

                var result = await RunPromptAsync(invocation, cancellationToken).ConfigureAwait(false);
                if (result.TimedOut || result.ExitCode != 0)
                {
                    throw Failure(result, DisplayName + " reported a sign-in or API key problem: " + Tail(result.StandardError));
                }

                var answer = ExtractAnswer(result.StandardOutput, settings.JsonResultField);
                if (string.IsNullOrWhiteSpace(answer))
                {
                    throw new AiProviderException(Id, DisplayName + " returned no answer.");
                }

                return new AiResponse(Id, answer.Trim(), result.Duration);
            }
        }

        private static List<string> Copies(RunWorkspace workspace, IEnumerable<string> files, string prefix)
        {
            var copies = new List<string>();
            foreach (var file in files)
            {
                var copy = workspace.PathOf(prefix + "-" + (copies.Count + 1) + System.IO.Path.GetExtension(file).ToLowerInvariant());
                System.IO.File.Copy(file, copy);
                copies.Add(copy);
            }

            return copies;
        }

        internal static string ExtractAnswer(string standardOutput, string jsonPath)
        {
            if (string.IsNullOrWhiteSpace(jsonPath))
            {
                return standardOutput;
            }

            var text = (standardOutput ?? "").Trim();
            var start = text.IndexOf('{');
            var end = text.LastIndexOf('}');
            if (start < 0 || end <= start)
            {
                return null;
            }

            try
            {
                var token = JObject.Parse(text.Substring(start, end - start + 1)).SelectToken(jsonPath.Trim());
                return token == null || token.Type == JTokenType.Null ? null : token.Type == JTokenType.String ? (string)token : token.ToString(Formatting.None);
            }
            catch (JsonException)
            {
                return null;
            }
        }
    }
}
