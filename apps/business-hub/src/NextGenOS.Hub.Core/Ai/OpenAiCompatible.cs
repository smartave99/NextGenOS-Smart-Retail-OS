using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace NextGenOS.Hub.Ai;

/// <summary>What an adapter needs to talk to one service.</summary>
public sealed record ProviderSettings(string Id, string Name, string Location, string BaseUrl, string? DefaultModel, IReadOnlySet<string> Tasks);

/// <summary>
/// The adapter for every service that speaks the common "OpenAI-compatible" web protocol: Ollama, LM Studio, the llama.cpp server, vLLM and most online services have it.
/// It writes and answers (chat) and makes embeddings. The vendor and the model are only a setting (an address, a model name and, for online services, a key), never code.
/// </summary>
public sealed class OpenAiCompatibleProvider(ProviderSettings settings, HttpClient http, Func<string?> apiKey) : ILlmProvider, IEmbeddingProvider
{
    public const string AdapterId = "openai-compatible";
    private static readonly TimeSpan CheckTimeout = TimeSpan.FromSeconds(8);
    private const int MaxErrorText = 200;

    public string Id => settings.Id;

    public string DisplayName => settings.Name;

    public string Location => settings.Location;

    public IReadOnlySet<string> Tasks => settings.Tasks;

    public async Task<ProviderHealth> CheckAsync(CancellationToken cancel)
    {
        var watch = Stopwatch.StartNew();
        try
        {
            using var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancel);
            timeout.CancelAfter(CheckTimeout);
            using var response = await SendAsync(HttpMethod.Get, "models", null, timeout.Token);
            using var body = await ReadAsync(response, timeout.Token);
            var models = new List<string>();
            if (body.RootElement.ValueKind == JsonValueKind.Object && body.RootElement.TryGetProperty("data", out var data) && data.ValueKind == JsonValueKind.Array)
                foreach (var item in data.EnumerateArray())
                    if (item.ValueKind == JsonValueKind.Object && item.TryGetProperty("id", out var id) && id.ValueKind == JsonValueKind.String) models.Add(id.GetString()!);
            return new ProviderHealth(true, models.Count == 0 ? "It answers, and lists no models." : "It answers and has " + models.Count + " model" + (models.Count == 1 ? "" : "s") + ".", models, watch.Elapsed);
        }
        catch (ProviderException e)
        {
            return new ProviderHealth(false, e.Message, [], watch.Elapsed);
        }
        catch (OperationCanceledException) when (!cancel.IsCancellationRequested)
        {
            return new ProviderHealth(false, "It did not answer in time.", [], watch.Elapsed);
        }
    }

    public async Task<LlmResponse> GenerateAsync(LlmRequest request, CancellationToken cancel)
    {
        var model = request.Model ?? settings.DefaultModel ?? throw new ProviderException(ProviderException.NotSetUp, "No model is chosen for " + settings.Name + ".");
        var payload = new Dictionary<string, object?>
        {
            ["model"] = model,
            ["messages"] = request.Messages.Select(m => new Dictionary<string, string> { ["role"] = m.Role, ["content"] = m.Content }).ToList(),
            ["stream"] = false,
        };
        if (request.Temperature is { } temperature) payload["temperature"] = temperature;
        if (request.MaxTokens is { } maxTokens) payload["max_tokens"] = maxTokens;

        var watch = Stopwatch.StartNew();
        using var response = await SendAsync(HttpMethod.Post, "chat/completions", payload, cancel);
        using var body = await ReadAsync(response, cancel);
        var root = body.RootElement;
        string? text = null;
        if (root.ValueKind == JsonValueKind.Object && root.TryGetProperty("choices", out var choices) && choices.ValueKind == JsonValueKind.Array && choices.GetArrayLength() > 0
            && choices[0].ValueKind == JsonValueKind.Object && choices[0].TryGetProperty("message", out var message) && message.ValueKind == JsonValueKind.Object
            && message.TryGetProperty("content", out var content) && content.ValueKind == JsonValueKind.String)
            text = content.GetString();
        if (text is null) throw new ProviderException(ProviderException.BadAnswer, settings.Name + " answered, but not in the expected form.");

        var (tokensIn, tokensOut) = Usage(root);
        if (tokensIn == 0) tokensIn = Estimate(request.Messages.Sum(m => m.Content.Length));
        if (tokensOut == 0) tokensOut = Estimate(text.Length);
        var answered = root.TryGetProperty("model", out var named) && named.ValueKind == JsonValueKind.String ? named.GetString()! : model;
        return new LlmResponse(text, answered, tokensIn, tokensOut, watch.Elapsed);
    }

    public async Task<EmbeddingResponse> EmbedAsync(EmbeddingRequest request, CancellationToken cancel)
    {
        var model = request.Model ?? settings.DefaultModel ?? throw new ProviderException(ProviderException.NotSetUp, "No model is chosen for " + settings.Name + ".");
        if (request.Inputs.Count == 0) return new EmbeddingResponse([], model, 0, 0, TimeSpan.Zero);
        var watch = Stopwatch.StartNew();
        using var response = await SendAsync(HttpMethod.Post, "embeddings", new Dictionary<string, object?> { ["model"] = model, ["input"] = request.Inputs }, cancel);
        using var body = await ReadAsync(response, cancel);
        var root = body.RootElement;
        if (root.ValueKind != JsonValueKind.Object || !root.TryGetProperty("data", out var data) || data.ValueKind != JsonValueKind.Array)
            throw new ProviderException(ProviderException.BadAnswer, settings.Name + " answered, but not in the expected form.");

        var rows = new SortedDictionary<int, float[]>();
        var position = 0;
        foreach (var item in data.EnumerateArray())
        {
            if (item.ValueKind != JsonValueKind.Object || !item.TryGetProperty("embedding", out var vector) || vector.ValueKind != JsonValueKind.Array)
                throw new ProviderException(ProviderException.BadAnswer, settings.Name + " answered, but not in the expected form.");
            var index = item.TryGetProperty("index", out var i) && i.ValueKind == JsonValueKind.Number && i.TryGetInt32(out var n) ? n : position;
            rows[index] = vector.EnumerateArray().Select(x => x.GetSingle()).ToArray();
            position++;
        }

        var vectors = rows.Values.ToList();
        if (vectors.Count != request.Inputs.Count || vectors.Any(v => v.Length == 0 || v.Length != vectors[0].Length))
            throw new ProviderException(ProviderException.BadAnswer, settings.Name + " gave back a different number of results than it was asked for.");
        var (tokensIn, _) = Usage(root);
        if (tokensIn == 0) tokensIn = Estimate(request.Inputs.Sum(t => t.Length));
        return new EmbeddingResponse(vectors, model, vectors[0].Length, tokensIn, watch.Elapsed);
    }

    // ---- the web call ---------------------------------------------------------------------------------------------------------

    private string Url(string path) => BaseUrl(settings.BaseUrl) + "/" + path;

    /// <summary>"http://host:11434" and "http://host:11434/v1/" both mean the same place.</summary>
    public static string BaseUrl(string address)
    {
        var trimmed = address.Trim().TrimEnd('/');
        return trimmed.EndsWith("/v1", StringComparison.OrdinalIgnoreCase) ? trimmed : trimmed + "/v1";
    }

    private async Task<HttpResponseMessage> SendAsync(HttpMethod method, string path, object? payload, CancellationToken cancel)
    {
        var key = apiKey();
        using var request = new HttpRequestMessage(method, Url(path));
        if (!string.IsNullOrEmpty(key)) request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", key);
        if (payload is not null) request.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
        HttpResponseMessage response;
        try
        {
            response = await http.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancel);
        }
        catch (OperationCanceledException) when (!cancel.IsCancellationRequested)
        {
            throw new ProviderException(ProviderException.Timeout, settings.Name + " did not answer in time.");
        }
        catch (HttpRequestException e)
        {
            throw new ProviderException(ProviderException.Unreachable, settings.Name + " cannot be reached: " + Secrets.Redact(e.InnerException?.Message ?? e.Message, key), e);
        }

        if (response.IsSuccessStatusCode) return response;
        using (response)
        {
            var status = (int)response.StatusCode;
            var text = Secrets.Redact(Shorten(await SafeText(response, cancel)), key);
            throw status switch
            {
                401 or 403 => new ProviderException(ProviderException.Unauthorized, settings.Name + " did not accept the key."),
                429 => new ProviderException(ProviderException.RateLimited, settings.Name + " says there have been too many requests. Try again later."),
                _ => new ProviderException(ProviderException.BadAnswer, settings.Name + " answered with an error (" + status + ")" + (text.Length > 0 ? ": " + text : ".")),
            };
        }
    }

    private async Task<JsonDocument> ReadAsync(HttpResponseMessage response, CancellationToken cancel)
    {
        try
        {
            using (response) return await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync(cancel), cancellationToken: cancel);
        }
        catch (JsonException)
        {
            throw new ProviderException(ProviderException.BadAnswer, settings.Name + " answered, but not with the expected kind of reply.");
        }
        catch (Exception e) when (e is HttpRequestException or IOException)
        {
            throw new ProviderException(ProviderException.Unreachable, settings.Name + " stopped answering.", e);
        }
    }

    private static async Task<string> SafeText(HttpResponseMessage response, CancellationToken cancel)
    {
        try { return await response.Content.ReadAsStringAsync(cancel); }
        catch (Exception e) when (e is HttpRequestException or IOException) { return ""; }
    }

    private static string Shorten(string text)
    {
        var line = text.Replace('\r', ' ').Replace('\n', ' ').Trim();
        return line.Length <= MaxErrorText ? line : line[..MaxErrorText] + "…";
    }

    private static (int In, int Out) Usage(JsonElement root)
    {
        if (root.ValueKind != JsonValueKind.Object || !root.TryGetProperty("usage", out var usage) || usage.ValueKind != JsonValueKind.Object) return (0, 0);
        return (Number(usage, "prompt_tokens"), Number(usage, "completion_tokens"));
    }

    private static int Number(JsonElement from, string name) => from.TryGetProperty(name, out var v) && v.ValueKind == JsonValueKind.Number && v.TryGetInt32(out var n) && n > 0 ? n : 0;

    /// <summary>A rough count when the service does not say: about four letters to a token.</summary>
    private static int Estimate(int characters) => Math.Max(1, (characters + 3) / 4);
}

/// <summary>Builds the adapter for a stored service. The only place that knows which adapters exist.</summary>
public interface IProviderFactory
{
    /// <summary>The adapters this program can run.</summary>
    IReadOnlyList<string> Adapters { get; }

    /// <summary>Null when the adapter is not one this program can run.</summary>
    IAiProvider? Create(ProviderRecord record);
}

public sealed class ProviderFactory(ISecretStore secrets) : IProviderFactory
{
    private static readonly TimeSpan RequestTimeout = TimeSpan.FromSeconds(120);
    private const long MaxAnswerBytes = 32 * 1024 * 1024;

    // One client for each kind of place, shared: a client is meant to be kept. The two that stay inside refuse to connect to anything outside, whatever a name turns out to mean.
    private readonly Lazy<HttpClient> _onThisComputer = new(() => Client(Handler(EndpointClassifier.Loopback)));
    private readonly Lazy<HttpClient> _inTheShop = new(() => Client(Handler(EndpointClassifier.Loopback, EndpointClassifier.PrivateNetwork)));
    private readonly Lazy<HttpClient> _online = new(() => Client(new SocketsHttpHandler { AllowAutoRedirect = false }));

    public IReadOnlyList<string> Adapters { get; } = [OpenAiCompatibleProvider.AdapterId];

    public IAiProvider? Create(ProviderRecord record)
    {
        if (record.Adapter != OpenAiCompatibleProvider.AdapterId) return null;
        var client = record.Location switch
        {
            ProviderLocation.Local or ProviderLocation.LocalOptimized => _onThisComputer.Value,
            ProviderLocation.Lan => _inTheShop.Value,
            _ => _online.Value,
        };
        var secretName = record.SecretName;
        return new OpenAiCompatibleProvider(
            new ProviderSettings(record.Id, record.Name, record.Location, record.BaseUrl, record.DefaultModel, record.Tasks),
            client,
            () => secretName is null ? null : secrets.Get(secretName));
    }

    private static HttpClient Client(HttpMessageHandler handler) => new(handler, disposeHandler: false) { Timeout = RequestTimeout, MaxResponseContentBufferSize = MaxAnswerBytes };

    /// <summary>
    /// A connection that only goes to the allowed places. The name is looked up here and only an address inside the allowed place is used, so a name that was changed to point
    /// somewhere else (or a redirect, which is never followed) cannot carry the shop's data out. No system proxy is used for a place inside the shop.
    /// </summary>
    private static SocketsHttpHandler Handler(params string[] allowed) => new()
    {
        AllowAutoRedirect = false,
        UseProxy = false,
        ConnectCallback = async (context, cancel) =>
        {
            var addresses = await Dns.GetHostAddressesAsync(context.DnsEndPoint.Host, cancel);
            var usable = addresses.Where(a => allowed.Contains(EndpointClassifier.Classify(a))).ToArray();
            if (usable.Length == 0) throw new HttpRequestException("The address does not lead inside the place this service is said to be in, so nothing was sent.");
            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp) { NoDelay = true };
            try
            {
                await socket.ConnectAsync(usable, context.DnsEndPoint.Port, cancel);
                return new NetworkStream(socket, ownsSocket: true);
            }
            catch
            {
                socket.Dispose();
                throw;
            }
        },
    };
}
