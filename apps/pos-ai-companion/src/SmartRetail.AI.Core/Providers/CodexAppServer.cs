using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartRetail.AI.Cli;

namespace SmartRetail.AI.Providers
{
    /// <summary>How Codex is signed in, as Codex itself says.</summary>
    public sealed class CodexSignIn
    {
        public bool SignedIn => !string.IsNullOrEmpty(Method);

        /// <summary>"chatgpt", "apikey", … or null when not signed in.</summary>
        public string Method { get; set; }

        public string Email { get; set; }

        /// <summary>The ChatGPT plan, e.g. "plus"; null for an API key.</summary>
        public string Plan { get; set; }

        /// <summary>For people: "Signed in with ChatGPT (Plus)" or "Signed in with an OpenAI API key".</summary>
        public string Describe()
        {
            if (!SignedIn)
            {
                return "Not signed in.";
            }

            if (string.Equals(Method, "apikey", StringComparison.OrdinalIgnoreCase))
            {
                return "Signed in with an OpenAI API key.";
            }

            var plan = string.IsNullOrWhiteSpace(Plan) || Plan == "unknown" ? "" : " (" + PlanName(Plan) + ")";
            return Method.StartsWith("chatgpt", StringComparison.OrdinalIgnoreCase)
                ? "Signed in with ChatGPT" + plan + "."
                : "Signed in.";
        }

        private static string PlanName(string plan) => plan.Replace('_', ' ') switch
        {
            var p when p.Length > 0 => CultureInfo.InvariantCulture.TextInfo.ToTitleCase(p),
            _ => plan,
        };
    }

    public sealed class CodexReasoningOption
    {
        public string Effort { get; set; } = "";

        public string Description { get; set; } = "";
    }

    /// <summary>A model Codex offers, with the thinking levels it supports.</summary>
    public sealed class CodexModel
    {
        public string Id { get; set; } = "";

        public string DisplayName { get; set; } = "";

        public string Description { get; set; } = "";

        public bool IsDefault { get; set; }

        public string DefaultReasoningEffort { get; set; }

        public List<CodexReasoningOption> ReasoningEfforts { get; set; } = new List<CodexReasoningOption>();

        /// <summary>What the model takes in: "text", "image", "audio". Empty when Codex does not say (older versions).</summary>
        public List<string> InputModalities { get; set; } = new List<string>();

        /// <summary>The speeds the model offers besides the usual one, e.g. Fast (Codex's service tiers).</summary>
        public List<CodexServiceTier> ServiceTiers { get; set; } = new List<CodexServiceTier>();
    }

    /// <summary>A speed a model offers, e.g. Fast.</summary>
    public sealed class CodexServiceTier
    {
        public string Id { get; set; } = "";

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";
    }

    /// <summary>How much of one usage window is used, e.g. the 5-hour or the weekly limit.</summary>
    public sealed class CodexUsageWindow
    {
        public double UsedPercent { get; set; }

        public int? WindowMinutes { get; set; }

        public DateTimeOffset? ResetsAt { get; set; }
    }

    /// <summary>The account's usage limits, as Codex reports them.</summary>
    public sealed class CodexUsage
    {
        public CodexUsageWindow Primary { get; set; }

        public CodexUsageWindow Secondary { get; set; }

        public string Plan { get; set; }

        /// <summary>False when the limit is reached; null when Codex does not say.</summary>
        public bool? Allowed { get; set; }
    }

    /// <summary>What to ask Codex in one turn of a new thread that is never saved.</summary>
    public sealed class CodexTurnRequest
    {
        /// <summary>The whole prompt, as <c>codex exec</c> would read it from standard input.</summary>
        public string Prompt { get; set; } = "";

        /// <summary>The empty folder Codex works in.</summary>
        public string WorkingDirectory { get; set; } = "";

        /// <summary>"read-only" (the default) or "workspace-write"; never full access.</summary>
        public string Sandbox { get; set; } = "read-only";

        public string Model { get; set; }

        public string ReasoningEffort { get; set; }

        /// <summary>A speed the model lists (its <c>serviceTiers</c>), e.g. Fast; null for the usual speed.</summary>
        public string ServiceTier { get; set; }

        /// <summary>Pictures attached to the question (paths in the working folder).</summary>
        public List<string> Images { get; } = new List<string>();

        /// <summary>Voice recordings attached to the question, for a model that takes audio.</summary>
        public List<string> Audio { get; } = new List<string>();
    }

    public sealed class CodexAppServerException : Exception
    {
        public CodexAppServerException(string message, int? code = null)
            : base(message)
        {
            Code = code;
        }

        /// <summary>The JSON-RPC error code, when Codex answered with an error.</summary>
        public int? Code { get; }
    }

    /// <summary>
    /// A short conversation with <c>codex app-server</c> (JSON-RPC, one JSON object per line): what Codex knows about
    /// itself (how it is signed in, its models and their thinking levels, the account's usage limits), and one turn of
    /// a thread that is never saved, whose answer arrives word by word (<see cref="RunTurnAsync"/>). Dispose it to
    /// stop Codex.
    /// </summary>
    public sealed class CodexAppServer : IDisposable
    {
        public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(20);

        private readonly IJsonLineChannel _channel;
        private IDisposable _lease;
        private readonly TimeSpan _timeout;
        private Task<string> _pendingRead;
        private int _nextId;

        private CodexAppServer(IJsonLineChannel channel, TimeSpan timeout)
        {
            _channel = channel;
            _timeout = timeout;
        }

        /// <summary>Introduces the app to Codex; the channel is disposed if that fails.</summary>
        public static async Task<CodexAppServer> StartAsync(IJsonLineChannel channel, string appVersion, TimeSpan? timeout = null, CancellationToken cancellationToken = default)
        {
            if (channel == null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            var server = new CodexAppServer(channel, timeout ?? DefaultTimeout);
            try
            {
                await server.CallAsync("initialize", new
                {
                    clientInfo = new { name = "smart_retail_pos", title = "Smart Retail POS", version = appVersion ?? "" },
                }, cancellationToken).ConfigureAwait(false);
                await server.NotifyAsync("initialized").ConfigureAwait(false);
                return server;
            }
            catch
            {
                server.Dispose();
                throw;
            }
        }

        public async Task<CodexSignIn> GetSignInAsync(CancellationToken cancellationToken = default)
        {
            var status = await CallAsync("getAuthStatus", new { includeToken = false, refreshToken = false }, cancellationToken).ConfigureAwait(false);
            var signIn = new CodexSignIn { Method = (string)status["authMethod"] };
            if (!signIn.SignedIn)
            {
                return signIn;
            }

            try
            {
                var account = (await CallAsync("account/read", new { }, cancellationToken).ConfigureAwait(false))["account"] as JObject;
                signIn.Email = (string)account?["email"];
                signIn.Plan = (string)account?["planType"];
            }
            catch (CodexAppServerException)
            {
                // The plan is a nicety; signed in is what counts.
            }

            return signIn;
        }

        /// <summary>The models Codex offers in its picker, default first.</summary>
        public async Task<IReadOnlyList<CodexModel>> ListModelsAsync(CancellationToken cancellationToken = default)
        {
            var models = new List<CodexModel>();
            string cursor = null;
            for (var page = 0; page < 10; page++)
            {
                var result = await CallAsync("model/list", cursor == null ? (object)new { } : new { cursor }, cancellationToken).ConfigureAwait(false);
                foreach (var item in result["data"] as JArray ?? new JArray())
                {
                    if (item is JObject model && (bool?)model["hidden"] != true && !string.IsNullOrWhiteSpace((string)model["model"] ?? (string)model["id"]))
                    {
                        models.Add(new CodexModel
                        {
                            Id = (string)model["model"] ?? (string)model["id"],
                            DisplayName = (string)model["displayName"] ?? (string)model["model"] ?? "",
                            Description = (string)model["description"] ?? "",
                            IsDefault = (bool?)model["isDefault"] == true,
                            DefaultReasoningEffort = (string)model["defaultReasoningEffort"],
                            ReasoningEfforts = (model["supportedReasoningEfforts"] as JArray ?? new JArray())
                                .OfType<JObject>()
                                .Select(option => new CodexReasoningOption { Effort = (string)option["reasoningEffort"] ?? "", Description = (string)option["description"] ?? "" })
                                .Where(option => option.Effort.Length > 0)
                                .ToList(),
                            InputModalities = (model["inputModalities"] as JArray ?? new JArray())
                                .Select(kind => kind.Type == JTokenType.String ? (string)kind : null)
                                .Where(kind => !string.IsNullOrWhiteSpace(kind))
                                .ToList(),
                            ServiceTiers = (model["serviceTiers"] as JArray ?? new JArray())
                                .OfType<JObject>()
                                .Select(tier => new CodexServiceTier { Id = (string)tier["id"] ?? "", Name = (string)tier["name"] ?? "", Description = (string)tier["description"] ?? "" })
                                .Where(tier => tier.Id.Length > 0)
                                .ToList(),
                        });
                    }
                }

                cursor = (string)result["nextCursor"];
                if (string.IsNullOrEmpty(cursor))
                {
                    break;
                }
            }

            return models.OrderByDescending(model => model.IsDefault).ToList();
        }

        /// <summary>The account's usage windows. Needs Codex signed in with ChatGPT.</summary>
        public async Task<CodexUsage> ReadUsageAsync(CancellationToken cancellationToken = default)
        {
            var result = await CallAsync("account/rateLimits/read", null, cancellationToken).ConfigureAwait(false);
            var snapshot = result["rateLimits"] as JObject;
            return new CodexUsage
            {
                Primary = Window(snapshot?["primary"] as JObject),
                Secondary = Window(snapshot?["secondary"] as JObject),
                Plan = (string)snapshot?["planType"],
                Allowed = (bool?)result["ordinaryUsageAllowed"],
            };
        }

        /// <summary>
        /// Asks one question on a new thread that is never saved (<c>ephemeral</c>), in a sandbox that may not change
        /// anything outside the working folder, with no approvals asked: anything Codex asks permission for is declined.
        /// <paramref name="onText"/> gets the answer so far as it is written; the result is the last message, as
        /// <c>codex exec --output-last-message</c> gives it.
        /// </summary>
        public async Task<string> RunTurnAsync(CodexTurnRequest turn, Action<string> onText, TimeSpan timeout, CancellationToken cancellationToken)
        {
            if (turn == null)
            {
                throw new ArgumentNullException(nameof(turn));
            }

            var sandbox = turn.Sandbox == "workspace-write" ? "workspace-write" : "read-only";
            var config = string.IsNullOrWhiteSpace(turn.ReasoningEffort)
                ? null
                : new Dictionary<string, object> { ["model_reasoning_effort"] = turn.ReasoningEffort };
            var started = await CallAsync("thread/start", new Dictionary<string, object>
            {
                ["model"] = string.IsNullOrWhiteSpace(turn.Model) ? null : turn.Model,
                ["cwd"] = turn.WorkingDirectory,
                ["approvalPolicy"] = "never",
                ["sandbox"] = sandbox,
                ["ephemeral"] = true,
                ["config"] = config,
                ["serviceTier"] = string.IsNullOrWhiteSpace(turn.ServiceTier) ? null : turn.ServiceTier,
            }, cancellationToken).ConfigureAwait(false);
            var threadId = (string)started["thread"]?["id"];
            if (string.IsNullOrEmpty(threadId))
            {
                throw new CodexAppServerException("Codex did not start a thread.");
            }

            var input = new List<object> { new Dictionary<string, object> { ["type"] = "text", ["text"] = turn.Prompt ?? "", ["text_elements"] = new object[0] } };
            input.AddRange(turn.Images.Select(path => new Dictionary<string, object> { ["type"] = "localImage", ["path"] = path }));
            input.AddRange(turn.Audio.Select(path => new Dictionary<string, object> { ["type"] = "localAudio", ["path"] = path }));
            var id = Interlocked.Increment(ref _nextId);
            await _channel.WriteLineAsync(JsonConvert.SerializeObject(new
            {
                jsonrpc = "2.0",
                id,
                method = "turn/start",
                @params = new Dictionary<string, object> { ["threadId"] = threadId, ["input"] = input },
            })).ConfigureAwait(false);

            // The words arrive per message (an item); the answer is the last message, as it is written.
            var messages = new Dictionary<string, StringBuilder>();
            string latest = null;
            string problem = null;
            var deadline = DateTime.UtcNow + timeout;
            while (true)
            {
                var message = await ReadMessageAsync(deadline, "the question", cancellationToken).ConfigureAwait(false);
                var method = (string)message["method"];
                var parameters = message["params"] as JObject ?? new JObject();
                if (method != null && message["id"] != null)
                {
                    await DeclineAsync(message["id"], method).ConfigureAwait(false);
                    continue;
                }

                if (method == null)
                {
                    if (message["id"]?.Type == JTokenType.Integer && (int)message["id"] == id && message["error"] is JObject refused)
                    {
                        throw new CodexAppServerException((string)refused["message"] ?? "Codex refused the question.", (int?)refused["code"]);
                    }

                    continue;
                }

                if ((string)parameters["threadId"] is string thread && thread != threadId)
                {
                    continue;
                }

                switch (method)
                {
                    case "item/agentMessage/delta":
                    {
                        var item = (string)parameters["itemId"] ?? "";
                        if (!messages.TryGetValue(item, out var text))
                        {
                            messages[item] = text = new StringBuilder();
                        }

                        text.Append((string)parameters["delta"] ?? "");
                        latest = item;
                        Tell(onText, text.ToString());
                        break;
                    }

                    case "item/completed" when parameters["item"] is JObject done && (string)done["type"] == "agentMessage":
                    {
                        var item = (string)done["id"] ?? "";
                        messages[item] = new StringBuilder((string)done["text"] ?? "");
                        latest = item;
                        Tell(onText, messages[item].ToString());
                        break;
                    }

                    case "error" when (bool?)parameters["willRetry"] != true:
                        problem = (string)parameters["error"]?["message"] ?? problem;
                        break;

                    case "turn/completed":
                    {
                        var status = (string)parameters["turn"]?["status"];
                        if (status == "completed")
                        {
                            return latest != null && messages.TryGetValue(latest, out var answer) ? answer.ToString() : "";
                        }

                        throw new CodexAppServerException((string)parameters["turn"]?["error"]?["message"] ?? problem ?? "Codex stopped before answering (" + (status ?? "no reason") + ").");
                    }
                }
            }
        }

        /// <summary>The place this conversation holds in <see cref="SmartRetail.AI.Cli.AiRunGate"/>, given back when it is closed.</summary>
        internal void Attach(IDisposable lease) => _lease = lease;

        public void Dispose()
        {
            try
            {
                _channel.Dispose();
            }
            finally
            {
                System.Threading.Interlocked.Exchange(ref _lease, null)?.Dispose();
            }
        }

        private static void Tell(Action<string> onText, string text)
        {
            try
            {
                onText?.Invoke(text);
            }
            catch (Exception)
            {
                // Showing the words must never stop them being read.
            }
        }

        /// <summary>Answers a request from Codex: permission is declined, and anything else is not offered.</summary>
        private Task DeclineAsync(JToken id, string method)
        {
            object reply = method is "item/commandExecution/requestApproval" or "item/fileChange/requestApproval"
                ? new { jsonrpc = "2.0", id, result = new { decision = "decline" } }
                : new { jsonrpc = "2.0", id, error = new { code = -32601, message = "Smart Retail POS does not offer " + method + "." } };
            return _channel.WriteLineAsync(JsonConvert.SerializeObject(reply));
        }

        private static CodexUsageWindow Window(JObject window)
        {
            if (window == null)
            {
                return null;
            }

            DateTimeOffset? resets = null;
            if (window["resetsAt"] is JValue value && value.Type is JTokenType.Integer or JTokenType.Float)
            {
                var number = value.Value<double>();
                // Seconds since 1970; milliseconds if it is that large.
                resets = number > 1e12 ? DateTimeOffset.FromUnixTimeMilliseconds((long)number) : DateTimeOffset.FromUnixTimeSeconds((long)number);
            }

            return new CodexUsageWindow
            {
                UsedPercent = Math.Max(0, Math.Min(100, (double?)window["usedPercent"] ?? 0)),
                WindowMinutes = (int?)window["windowDurationMins"],
                ResetsAt = resets,
            };
        }

        private Task NotifyAsync(string method) =>
            _channel.WriteLineAsync(JsonConvert.SerializeObject(new { jsonrpc = "2.0", method }));

        /// <summary>Sends a request and waits for its answer, skipping Codex's notifications meanwhile.</summary>
        internal async Task<JObject> CallAsync(string method, object parameters, CancellationToken cancellationToken)
        {
            var id = Interlocked.Increment(ref _nextId);
            var request = parameters == null
                ? JsonConvert.SerializeObject(new { jsonrpc = "2.0", id, method })
                : JsonConvert.SerializeObject(new { jsonrpc = "2.0", id, method, @params = parameters });
            await _channel.WriteLineAsync(request).ConfigureAwait(false);

            var deadline = DateTime.UtcNow + _timeout;
            while (true)
            {
                var message = await ReadMessageAsync(deadline, method, cancellationToken).ConfigureAwait(false);
                if (message["method"] is JToken asked && message["id"] != null)
                {
                    await DeclineAsync(message["id"], (string)asked).ConfigureAwait(false);
                    continue;
                }

                if (message["id"]?.Type != JTokenType.Integer || (int)message["id"] != id || message["method"] != null)
                {
                    continue; // A notification.
                }

                if (message["error"] is JObject error)
                {
                    throw new CodexAppServerException((string)error["message"] ?? "Codex refused " + method + ".", (int?)error["code"]);
                }

                return message["result"] as JObject ?? new JObject();
            }
        }

        /// <summary>The next JSON message from Codex, skipping lines that are not; fails at the deadline.</summary>
        private async Task<JObject> ReadMessageAsync(DateTime deadline, string what, CancellationToken cancellationToken)
        {
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var remaining = deadline - DateTime.UtcNow;
                if (remaining <= TimeSpan.Zero)
                {
                    throw new CodexAppServerException("Codex did not answer " + what + " in time.");
                }

                // A read left waiting by a call that gave up is the one to wait on: a reader takes one read at a time.
                var read = _pendingRead ?? _channel.ReadLineAsync();
                _pendingRead = read;
                var first = await Task.WhenAny(read, Task.Delay(remaining, cancellationToken)).ConfigureAwait(false);
                if (first != read)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    throw new CodexAppServerException("Codex did not answer " + what + " in time.");
                }

                _pendingRead = null;
                var line = await read.ConfigureAwait(false);
                if (line == null)
                {
                    throw new CodexAppServerException("Codex stopped before answering " + what + ".");
                }

                try
                {
                    return JObject.Parse(line);
                }
                catch (JsonReaderException)
                {
                    // Not a protocol line.
                }
            }
        }
    }
}
