using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SmartRetail.AI.Cli;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Providers
{
    /// <summary>One model a tool offers, and how hard it can think.</summary>
    public sealed class CliModel
    {
        public string Id { get; set; } = "";

        public string Label { get; set; } = "";

        /// <summary>The thinking levels this model takes, lowest first; empty when it has none.</summary>
        public List<string> Efforts { get; set; } = new List<string>();

        public string DefaultEffort { get; set; } = "";

        /// <summary>"anthropic" (the live list for the shop's key), "tool" (the tool's own name for it) or "built-in" (written into this program, can be out of date).</summary>
        public string Source { get; set; } = "";

        public string Notes { get; set; } = "";
    }

    public sealed class CliModelList
    {
        public List<CliModel> Models { get; set; } = new List<CliModel>();

        /// <summary>"anthropic", "built-in" or "none".</summary>
        public string Source { get; set; } = "none";

        /// <summary>A sentence for the screen: where the list came from, or why it is the short one.</summary>
        public string Note { get; set; } = "";

        /// <summary>The thinking levels the tool takes when no model is chosen.</summary>
        public List<string> DefaultEfforts { get; set; } = new List<string>();
    }

    public sealed class CliToolStatus
    {
        public string ProviderId { get; set; } = "";

        public string Name { get; set; } = "";

        public bool Found { get; set; }

        public string Path { get; set; }

        /// <summary>"2.1.289", or empty when the tool does not say.</summary>
        public string Version { get; set; } = "";

        public string InstallHint { get; set; } = "";
    }

    public sealed class CliUpdateCheck
    {
        public CliToolStatus Status { get; set; }

        /// <summary>The newest released version, or empty when it could not be found out.</summary>
        public string Latest { get; set; } = "";

        /// <summary>"available", "current", "unknown" (no way to tell) or "install" (the tool is not on this PC).</summary>
        public string Update { get; set; } = "unknown";

        /// <summary>What an update would do, in words.</summary>
        public string How { get; set; } = "";

        public bool CanUpdate { get; set; }
    }

    public sealed class CliUpdateResult
    {
        public string Before { get; set; } = "";

        public string After { get; set; } = "";

        public bool Changed { get; set; }

        public string Output { get; set; } = "";
    }

    /// <summary>A tool update that could not be done, with a sentence for the screen.</summary>
    public sealed class CliToolException : Exception
    {
        public CliToolException(string message)
            : base(message)
        {
        }
    }

    public interface ICliToolCare
    {
        /// <summary>Whether the tool is on this PC, where, and which version. Never changes anything.</summary>
        Task<CliToolStatus> StatusAsync(string providerId, CancellationToken cancellationToken);

        /// <summary>Every model the tool takes, with the thinking levels each takes.</summary>
        Task<CliModelList> ModelsAsync(string providerId, CancellationToken cancellationToken);

        /// <summary>Whether a newer version is out, and how it would be installed. Never changes anything.</summary>
        Task<CliUpdateCheck> CheckUpdateAsync(string providerId, CancellationToken cancellationToken);

        /// <summary>Brings the tool up to date. Only when the owner asks, one tool at a time. The result is checked by asking the tool its version again.</summary>
        Task<CliUpdateResult> UpdateAsync(string providerId, CancellationToken cancellationToken);
    }

    /// <summary>
    /// Looking after Claude Code and Antigravity, the two command-line tools besides Codex (which has its own, <see cref="CodexUpdater"/>): the models each takes, every thinking
    /// level of each model, the version on this PC, whether a newer one is out, and bringing it up to date. Looking is free; an update changes the PC and is done only when the owner asks.
    /// </summary>
    public sealed class CliToolCare : ICliToolCare
    {
        private static readonly TimeSpan AskTimeout = TimeSpan.FromSeconds(20);
        private static readonly TimeSpan UpdateTimeout = TimeSpan.FromMinutes(10);
        private const long MaxAnswerBytes = 2_000_000;

        internal const string ClaudeRegistry = "https://registry.npmjs.org/@anthropic-ai/claude-code/latest";
        internal const string AnthropicApi = "https://api.anthropic.com";
        internal const string AntigravityInstaller = "https://antigravity.google/cli/install.ps1";

        private static readonly Regex VersionPattern = new Regex(@"(\d+\.\d+\.\d+)", RegexOptions.Compiled);

        private static readonly string[] AnthropicLevels = { "low", "medium", "high", "xhigh", "max" };

        private readonly ICliRunner _runner;
        private readonly Func<AssistantSettings> _settings;
        private readonly SecretStore _secrets;
        private readonly HttpClient _http;
        private readonly string _registryUrl;

        public CliToolCare(ICliRunner runner, Func<AssistantSettings> settings, SecretStore secrets, HttpClient http, string claudeRegistryUrl = null)
        {
            _runner = runner ?? throw new ArgumentNullException(nameof(runner));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _secrets = secrets ?? throw new ArgumentNullException(nameof(secrets));
            _http = http ?? throw new ArgumentNullException(nameof(http));
            _registryUrl = claudeRegistryUrl ?? ClaudeRegistry;
        }

        // ---- the models --------------------------------------------------------------------------------------------------------------

        /// <summary>Models of Claude, by id, with the levels each takes. Written when this program was made; the live list for the shop's key replaces it when there is a key.</summary>
        internal static readonly CliModel[] ClaudeBuiltIn =
        {
            Built("claude-fable-5-1", "Claude Fable 5.1 (most capable)", "high", "low", "medium", "high", "xhigh", "max"),
            Built("claude-opus-5-5", "Claude Opus 5.5", "medium", "low", "medium", "high", "xhigh", "max"),
            Built("claude-opus-5", "Claude Opus 5", "high", "low", "medium", "high", "xhigh", "max"),
            Built("claude-opus-4-8", "Claude Opus 4.8", "high", "low", "medium", "high", "xhigh", "max"),
            Built("claude-opus-4-7", "Claude Opus 4.7", "high", "low", "medium", "high", "xhigh", "max"),
            Built("claude-opus-4-6", "Claude Opus 4.6", "high", "low", "medium", "high", "max"),
            Built("claude-sonnet-5-5", "Claude Sonnet 5.5", "high", "low", "medium", "high", "xhigh", "max"),
            Built("claude-sonnet-5", "Claude Sonnet 5", "high", "low", "medium", "high", "xhigh", "max"),
            Built("claude-sonnet-4-6", "Claude Sonnet 4.6", "high", "low", "medium", "high", "max"),
            Built("claude-haiku-4-5", "Claude Haiku 4.5 (fastest, no thinking level)", ""),
        };

        /// <summary>The short names Claude Code itself understands: they always mean the newest model of that kind.</summary>
        internal static readonly CliModel[] ClaudeAliases =
        {
            new CliModel { Id = "fable", Label = "Claude Code's \"fable\" (the newest Fable)", Efforts = AnthropicLevels.ToList(), Source = "tool" },
            new CliModel { Id = "opus", Label = "Claude Code's \"opus\" (the newest Opus)", Efforts = AnthropicLevels.ToList(), Source = "tool" },
            new CliModel { Id = "sonnet", Label = "Claude Code's \"sonnet\" (the newest Sonnet)", Efforts = AnthropicLevels.ToList(), Source = "tool" },
        };

        private static CliModel Built(string id, string label, string defaultEffort, params string[] efforts) =>
            new CliModel { Id = id, Label = label, DefaultEffort = defaultEffort, Efforts = efforts.ToList(), Source = "built-in" };

        public async Task<CliModelList> ModelsAsync(string providerId, CancellationToken cancellationToken)
        {
            switch (providerId)
            {
                case ProviderIds.ClaudeCli:
                case ProviderIds.AnthropicApi:
                    return await AnthropicModelsAsync(providerId == ProviderIds.ClaudeCli, cancellationToken).ConfigureAwait(false);
                case ProviderIds.AntigravityCli:
                    return await AntigravityModelsAsync(cancellationToken).ConfigureAwait(false);
                default:
                    throw new CliToolException("This program looks after the models of Claude Code and Antigravity. Codex has its own list.");
            }
        }

        private static readonly Regex ModelWord = new Regex(@"^[A-Za-z0-9][A-Za-z0-9._:/-]{1,79}$", RegexOptions.Compiled);

        private static readonly string[] NotModels = { "models", "model", "available", "name", "names", "id", "ids", "usage", "default", "error", "no", "none" };

        /// <summary>Antigravity's own list, from <c>agy models</c> (the first word of each line is the model's name). Antigravity has one set of thinking levels for all its models.</summary>
        private async Task<CliModelList> AntigravityModelsAsync(CancellationToken cancellationToken)
        {
            var levels = AiJobs.Efforts(ProviderIds.AntigravityCli).ToList();
            var none = new CliModelList
            {
                Source = "none",
                Note = "Antigravity's list of models could not be read. Leave the model empty for Antigravity's own choice, or type the model name.",
                DefaultEfforts = levels,
            };
            var path = ExecutableLocator.Resolve(ConfiguredPath(ProviderIds.AntigravityCli), "agy", ExecutableLocator.CommonUserToolDirectories());
            if (path == null)
            {
                none.Note = "Antigravity is not on this PC. " + InstallHint(ProviderIds.AntigravityCli);
                return none;
            }

            var result = await AskAsync(path, new[] { "models" }, AskTimeout, cancellationToken).ConfigureAwait(false);
            if (result == null || result.ExitCode != 0 || result.TimedOut)
            {
                return none;
            }

            var models = new List<CliModel>();
            foreach (var raw in (result.StandardOutput ?? "").Split('\n'))
            {
                var line = raw.Trim().TrimStart('-', '*', '•', ' ').Trim();
                if (line.Length == 0)
                {
                    continue;
                }

                var parts = line.Split(new[] { ' ', '\t' }, 2, StringSplitOptions.RemoveEmptyEntries);
                var id = parts[0].TrimEnd(':', ',');
                if (!ModelWord.IsMatch(id) || NotModels.Contains(id.ToLowerInvariant()) || models.Any(m => m.Id == id))
                {
                    continue;
                }

                models.Add(new CliModel { Id = id, Label = parts.Length > 1 && parts[1].Trim().Length > 0 ? id + ": " + parts[1].Trim().Trim('(', ')') : id, Efforts = levels.ToList(), Source = "tool" });
                if (models.Count >= 100)
                {
                    break;
                }
            }

            if (models.Count == 0)
            {
                return none;
            }

            return new CliModelList { Models = models, Source = "tool", Note = "The list is Antigravity's own (from \"agy models\").", DefaultEfforts = levels };
        }

        private async Task<CliModelList> AnthropicModelsAsync(bool withAliases, CancellationToken cancellationToken)
        {
            var aliases = withAliases ? ClaudeAliases.Select(Copy).ToList() : new List<CliModel>();
            string why;
            List<CliModel> live = null;
            try
            {
                live = await ReadAnthropicAsync(cancellationToken).ConfigureAwait(false);
                why = live == null ? "There is no Anthropic key saved (Settings → API keys), so this is the list built into this program, which can be out of date." : null;
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException || ex is OperationCanceledException || ex is Newtonsoft.Json.JsonException || ex is InvalidOperationException)
            {
                why = "Anthropic's live list could not be read (" + Reason(ex) + "), so this is the list built into this program, which can be out of date.";
            }

            if (live != null && live.Count > 0)
            {
                aliases.AddRange(live);
                return new CliModelList { Models = aliases, Source = "anthropic", Note = "The list comes live from Anthropic for your key.", DefaultEfforts = AnthropicLevels.ToList() };
            }

            aliases.AddRange(ClaudeBuiltIn.Select(Copy));
            return new CliModelList { Models = aliases, Source = "built-in", Note = why ?? "The list built into this program.", DefaultEfforts = AnthropicLevels.ToList() };
        }

        /// <summary>Every model Anthropic lists for the saved key, with the thinking levels each says it takes; null when there is no key.</summary>
        private async Task<List<CliModel>> ReadAnthropicAsync(CancellationToken cancellationToken)
        {
            var key = _secrets.Get(SecretNames.AnthropicApiKey);
            if (string.IsNullOrWhiteSpace(key))
            {
                return null;
            }

            var baseUrl = (_settings().Anthropic?.BaseUrl ?? "").Trim();
            if (baseUrl.Length == 0 || !baseUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                baseUrl = AnthropicApi;
            }

            var models = new List<CliModel>();
            string after = null;
            for (var page = 0; page < 3; page++)
            {
                var url = baseUrl.TrimEnd('/') + "/v1/models?limit=100" + (after == null ? "" : "&after_id=" + Uri.EscapeDataString(after));
                using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                using (var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
                {
                    request.Headers.Add("x-api-key", key.Trim());
                    request.Headers.Add("anthropic-version", "2023-06-01");
                    timeout.CancelAfter(AskTimeout);
                    using (var response = await _http.SendAsync(request, timeout.Token).ConfigureAwait(false))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            throw new HttpRequestException("status " + (int)response.StatusCode);
                        }

                        var text = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        if (text.Length > MaxAnswerBytes)
                        {
                            throw new InvalidOperationException("the answer was far too long");
                        }

                        var json = JObject.Parse(text);
                        foreach (var item in json["data"] as JArray ?? new JArray())
                        {
                            var id = (string)item["id"];
                            if (string.IsNullOrWhiteSpace(id))
                            {
                                continue;
                            }

                            var effort = item["capabilities"]?["effort"];
                            var levels = new List<string>();
                            if (effort != null && (bool?)effort["supported"] == true)
                            {
                                levels.AddRange(AnthropicLevels.Where(level => (bool?)effort[level]?["supported"] == true));
                            }

                            models.Add(new CliModel { Id = id, Label = (string)item["display_name"] ?? id, Efforts = levels, Source = "anthropic" });
                        }

                        after = (bool?)json["has_more"] == true ? (string)json["last_id"] : null;
                    }
                }

                if (after == null || models.Count >= 200)
                {
                    break;
                }
            }

            return models;
        }

        private static CliModel Copy(CliModel m) => new CliModel { Id = m.Id, Label = m.Label, Efforts = m.Efforts.ToList(), DefaultEffort = m.DefaultEffort, Source = m.Source, Notes = m.Notes };

        private static string Reason(Exception ex)
        {
            var message = ex.Message ?? "";
            if (message.Contains("401") || message.Contains("403"))
            {
                return "Anthropic did not accept the key";
            }

            if (message.Contains("429"))
            {
                return "too many requests just now";
            }

            return ex is TaskCanceledException || ex is OperationCanceledException ? "it took too long" : "the service could not be reached";
        }

        // ---- is it there, and is it current ------------------------------------------------------------------------------------------

        private static string CommandOf(string providerId)
        {
            switch (providerId)
            {
                case ProviderIds.ClaudeCli: return "claude";
                case ProviderIds.AntigravityCli: return "agy";
                default: throw new CliToolException("This program looks after Claude Code and Antigravity. Codex has its own updater.");
            }
        }

        private string ConfiguredPath(string providerId) =>
            providerId == ProviderIds.ClaudeCli ? _settings().ClaudeCli?.ExecutablePath : _settings().Antigravity?.ExecutablePath;

        private static string NameOf(string providerId) => providerId == ProviderIds.ClaudeCli ? "Claude Code" : "Antigravity";

        private static string InstallHint(string providerId) =>
            providerId == ProviderIds.ClaudeCli
                ? "Install Claude Code from https://claude.com/product/claude-code (PowerShell: irm https://claude.ai/install.ps1 | iex)."
                : "Install it in PowerShell with: irm " + AntigravityInstaller + " | iex, then run agy once to sign in.";

        public async Task<CliToolStatus> StatusAsync(string providerId, CancellationToken cancellationToken)
        {
            var command = CommandOf(providerId);
            var status = new CliToolStatus { ProviderId = providerId, Name = NameOf(providerId), InstallHint = InstallHint(providerId) };
            var path = ExecutableLocator.Resolve(ConfiguredPath(providerId), command, ExecutableLocator.CommonUserToolDirectories());
            if (path == null)
            {
                return status;
            }

            status.Found = true;
            status.Path = path;
            var result = await AskAsync(path, new[] { "--version" }, AskTimeout, cancellationToken).ConfigureAwait(false);
            var match = result == null ? null : VersionPattern.Match((result.StandardOutput ?? "") + "\n" + (result.StandardError ?? ""));
            status.Version = match != null && match.Success ? match.Groups[1].Value : "";
            return status;
        }

        public async Task<CliUpdateCheck> CheckUpdateAsync(string providerId, CancellationToken cancellationToken)
        {
            var status = await StatusAsync(providerId, cancellationToken).ConfigureAwait(false);
            var check = new CliUpdateCheck { Status = status };
            if (!status.Found)
            {
                check.Update = "install";
                check.How = status.InstallHint;
                return check;
            }

            var how = HowToUpdate(providerId);
            check.How = how.Text;
            check.CanUpdate = how.CanRun;
            if (providerId == ProviderIds.ClaudeCli && status.Version.Length > 0)
            {
                check.Latest = await LatestClaudeAsync(cancellationToken).ConfigureAwait(false) ?? "";
            }

            if (check.Latest.Length > 0 && status.Version.Length > 0)
            {
                check.Update = IsNewer(check.Latest, status.Version) ? "available" : "current";
            }

            return check;
        }

        /// <summary>The newest Claude Code version, as npm lists it; null when it could not be found out.</summary>
        private async Task<string> LatestClaudeAsync(CancellationToken cancellationToken)
        {
            try
            {
                if (!_registryUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    return null;
                }

                using (var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
                using (var request = new HttpRequestMessage(HttpMethod.Get, _registryUrl))
                {
                    timeout.CancelAfter(AskTimeout);
                    request.Headers.Add("accept", "application/json");
                    using (var response = await _http.SendAsync(request, timeout.Token).ConfigureAwait(false))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            return null;
                        }

                        var text = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        if (text.Length > MaxAnswerBytes)
                        {
                            return null;
                        }

                        var match = VersionPattern.Match((string)JObject.Parse(text)["version"] ?? "");
                        return match.Success ? match.Groups[1].Value : null;
                    }
                }
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException || ex is OperationCanceledException || ex is Newtonsoft.Json.JsonException)
            {
                return null;
            }
        }

        private static (string Text, bool CanRun) HowToUpdate(string providerId)
        {
            if (providerId == ProviderIds.ClaudeCli)
            {
                return ("Runs \"claude update\", Claude Code's own updater.", true);
            }

            return ExecutableLocator.IsWindows
                ? ("Runs Google's official installer again (" + AntigravityInstaller + "), which brings Antigravity up to date. It changes only Antigravity's own folder and your PATH.", true)
                : ("Update Antigravity the way you installed it. This program only updates it on Windows.", false);
        }

        public async Task<CliUpdateResult> UpdateAsync(string providerId, CancellationToken cancellationToken)
        {
            var how = HowToUpdate(providerId);
            if (!how.CanRun)
            {
                throw new CliToolException(how.Text);
            }

            var before = await StatusAsync(providerId, cancellationToken).ConfigureAwait(false);
            if (!before.Found)
            {
                throw new CliToolException(NameOf(providerId) + " is not on this PC. " + before.InstallHint);
            }

            CliInvocation invocation;
            if (providerId == ProviderIds.ClaudeCli)
            {
                invocation = new CliInvocation { FileName = before.Path, Timeout = UpdateTimeout };
                invocation.Arguments.Add("update");
            }
            else
            {
                var powershell = System.IO.Path.Combine(Environment.GetEnvironmentVariable("SystemRoot") ?? @"C:\Windows", "System32", "WindowsPowerShell", "v1.0", "powershell.exe");
                invocation = new CliInvocation { FileName = powershell, Timeout = UpdateTimeout };
                invocation.Arguments.AddRange(new[]
                {
                    "-NoProfile", "-NonInteractive", "-ExecutionPolicy", "Bypass", "-Command",
                    "$ProgressPreference='SilentlyContinue'; Invoke-RestMethod -UseBasicParsing -Uri '" + AntigravityInstaller + "' | Invoke-Expression",
                });
            }

            invocation.Environment["NO_COLOR"] = "1";
            var result = await _runner.RunAsync(invocation, cancellationToken).ConfigureAwait(false);
            var output = Tail(((result.StandardOutput ?? "") + "\n" + (result.StandardError ?? "")).Trim());
            if (result.TimedOut)
            {
                throw new CliToolException("The update took too long and was stopped. Check the internet connection and try again.");
            }

            if (result.ExitCode != 0)
            {
                throw new CliToolException("The update did not finish (it stopped with code " + result.ExitCode + "). " + Tail(output, 300));
            }

            var after = await StatusAsync(providerId, cancellationToken).ConfigureAwait(false);
            return new CliUpdateResult { Before = before.Version, After = after.Version, Changed = before.Version.Length > 0 && after.Version.Length > 0 && before.Version != after.Version, Output = output };
        }

        // ---- small helpers -----------------------------------------------------------------------------------------------------------

        private async Task<CliResult> AskAsync(string executable, IEnumerable<string> arguments, TimeSpan timeout, CancellationToken cancellationToken)
        {
            var invocation = new CliInvocation { FileName = executable, Timeout = timeout };
            invocation.Arguments.AddRange(arguments);
            invocation.Environment["NO_COLOR"] = "1";
            try
            {
                return await _runner.RunAsync(invocation, cancellationToken).ConfigureAwait(false);
            }
            catch (CliStartException)
            {
                return null;
            }
        }

        private static string Tail(string text, int max = 1500)
        {
            var lines = (text ?? "").Split('\n').Select(l => l.TrimEnd('\r')).Where(l => l.Length > 0).ToArray();
            var joined = string.Join("\n", lines.Skip(Math.Max(0, lines.Length - 12)));
            return joined.Length > max ? joined.Substring(joined.Length - max) : joined;
        }

        internal static bool IsNewer(string a, string b)
        {
            var x = a.Split('.').Select(p => int.TryParse(p, out var n) ? n : 0).ToArray();
            var y = b.Split('.').Select(p => int.TryParse(p, out var n) ? n : 0).ToArray();
            for (var i = 0; i < Math.Max(x.Length, y.Length); i++)
            {
                var left = i < x.Length ? x[i] : 0;
                var right = i < y.Length ? y[i] : 0;
                if (left != right)
                {
                    return left > right;
                }
            }

            return false;
        }
    }
}
