using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using NextGenOS.Hub.Ai;

namespace NextGenOS.Hub.Tests;

/// <summary>A web server on this computer that answers as the test says. It runs for real, so the adapter and its connection rules are tried for real.</summary>
public sealed class TinyServer : IDisposable
{
    public sealed record Seen(string Method, string Path, string Authorization, string Body);

    private readonly TcpListener _listener = new(IPAddress.Loopback, 0);
    private readonly Func<Seen, (int Status, string Body, string? Location)> _answer;
    private readonly CancellationTokenSource _stop = new();

    public TinyServer(Func<Seen, (int Status, string Body, string? Location)> answer)
    {
        _answer = answer;
        _listener.Start();
        _ = Task.Run(Loop);
    }

    public List<Seen> Requests { get; } = new();

    public string Address => "http://127.0.0.1:" + ((IPEndPoint)_listener.LocalEndpoint).Port;

    public static TinyServer Json(string body, int status = 200) => new(_ => (status, body, null));

    private async Task Loop()
    {
        while (!_stop.IsCancellationRequested)
        {
            TcpClient client;
            try { client = await _listener.AcceptTcpClientAsync(_stop.Token); }
            catch (Exception e) when (e is OperationCanceledException or ObjectDisposedException or SocketException) { return; }
            _ = Task.Run(() => Serve(client));
        }
    }

    private async Task Serve(TcpClient client)
    {
        using (client)
        {
            try
            {
                var stream = client.GetStream();
                var buffer = new List<byte>();
                var one = new byte[1];
                while (!(buffer.Count >= 4 && buffer[^4] == '\r' && buffer[^3] == '\n' && buffer[^2] == '\r' && buffer[^1] == '\n'))
                {
                    if (await stream.ReadAsync(one) == 0) return;
                    buffer.Add(one[0]);
                }

                var head = Encoding.ASCII.GetString(buffer.ToArray()).Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                var first = head[0].Split(' ');
                string Header(string name) => head.Skip(1).Select(h => h.Split(':', 2)).Where(p => p.Length == 2 && p[0].Equals(name, StringComparison.OrdinalIgnoreCase)).Select(p => p[1].Trim()).FirstOrDefault() ?? "";
                var length = int.TryParse(Header("Content-Length"), out var n) ? n : 0;
                var body = new byte[length];
                for (var read = 0; read < length;) { var got = await stream.ReadAsync(body.AsMemory(read)); if (got == 0) break; read += got; }

                var seen = new Seen(first[0], first[1], Header("Authorization"), Encoding.UTF8.GetString(body));
                lock (Requests) Requests.Add(seen);
                var (status, reply, location) = _answer(seen);
                var bytes = Encoding.UTF8.GetBytes(reply);
                var response = $"HTTP/1.1 {status} X\r\nContent-Type: application/json\r\nContent-Length: {bytes.Length}\r\nConnection: close\r\n" + (location is null ? "" : $"Location: {location}\r\n") + "\r\n";
                await stream.WriteAsync(Encoding.ASCII.GetBytes(response));
                await stream.WriteAsync(bytes);
            }
            catch (Exception e) when (e is IOException or SocketException or ObjectDisposedException) { }
        }
    }

    public void Dispose()
    {
        _stop.Cancel();
        _listener.Stop();
    }
}

public class OpenAiAdapterTests
{
    private static ProviderRecord Record(string address, string location = ProviderLocation.Local, string? secret = null, string? model = "llama") => new(
        "svc", "Test service", OpenAiCompatibleProvider.AdapterId, location, address, model, secret, new HashSet<string> { AiTask.Generate, AiTask.Embed }, true, null, null, new ProviderLimits(),
        DateTimeOffset.UnixEpoch, DateTimeOffset.UnixEpoch);

    private static OpenAiCompatibleProvider Adapter(ProviderRecord record, MemorySecretStore? safe = null) => (OpenAiCompatibleProvider)new ProviderFactory(safe ?? new MemorySecretStore()).Create(record)!;

    private const string ChatAnswer = """{"id":"x","model":"llama-3-8b","choices":[{"message":{"role":"assistant","content":"Rice sold best."}}],"usage":{"prompt_tokens":21,"completion_tokens":4}}""";

    [Fact]
    public async Task It_asks_a_chat_service_and_reads_the_answer_the_model_and_the_tokens_used()
    {
        using var server = TinyServer.Json(ChatAnswer);
        var answer = await Adapter(Record(server.Address)).GenerateAsync(new LlmRequest([new LlmMessage("system", "Be brief."), new LlmMessage("user", "What sold best?")], Temperature: 0.2, MaxTokens: 50), CancellationToken.None);

        Assert.Equal("Rice sold best.", answer.Text);
        Assert.Equal("llama-3-8b", answer.Model);
        Assert.Equal((21, 4), (answer.TokensIn, answer.TokensOut));
        var request = Assert.Single(server.Requests);
        Assert.Equal(("POST", "/v1/chat/completions"), (request.Method, request.Path));
        Assert.Contains("\"model\":\"llama\"", request.Body);
        Assert.Contains("\"stream\":false", request.Body);
        Assert.Contains("\"max_tokens\":50", request.Body);
        Assert.Contains("What sold best?", request.Body);
        Assert.Equal("", request.Authorization);   // no key was kept: none is sent
    }

    [Theory]
    [InlineData("http://127.0.0.1:1/v1/", "http://127.0.0.1:1/v1")]
    [InlineData("http://127.0.0.1:1", "http://127.0.0.1:1/v1")]
    [InlineData("http://127.0.0.1:1/", "http://127.0.0.1:1/v1")]
    [InlineData("https://api.example.com/v1", "https://api.example.com/v1")]
    public void The_address_may_be_typed_with_or_without_the_version_part(string typed, string used) => Assert.Equal(used, OpenAiCompatibleProvider.BaseUrl(typed));

    [Fact]
    public async Task The_key_is_sent_as_a_sign_in_header_and_comes_from_the_safe_at_the_moment_of_the_call()
    {
        using var server = TinyServer.Json(ChatAnswer);
        var safe = new MemorySecretStore();
        var adapter = Adapter(Record(server.Address, secret: "ai-provider/svc"), safe);

        await adapter.GenerateAsync(new LlmRequest([new LlmMessage("user", "hi")]), CancellationToken.None);
        safe.Set("ai-provider/svc", "sk-first-key-12345678");
        await adapter.GenerateAsync(new LlmRequest([new LlmMessage("user", "hi")]), CancellationToken.None);
        safe.Set("ai-provider/svc", "sk-second-key-1234567");
        await adapter.GenerateAsync(new LlmRequest([new LlmMessage("user", "hi")]), CancellationToken.None);

        Assert.Equal(new[] { "", "Bearer sk-first-key-12345678", "Bearer sk-second-key-1234567" }, server.Requests.Select(r => r.Authorization));
    }

    [Fact]
    public async Task It_makes_embeddings_in_the_order_asked_even_when_the_service_answers_in_another_order()
    {
        using var server = TinyServer.Json("""{"data":[{"index":1,"embedding":[0.5,0.6]},{"index":0,"embedding":[0.1,0.2]}],"usage":{"prompt_tokens":6}}""");
        var answer = await Adapter(Record(server.Address, model: "embed-small")).EmbedAsync(new EmbeddingRequest(["rice", "sugar"]), CancellationToken.None);

        Assert.Equal(2, answer.Dimensions);
        Assert.Equal(new[] { 0.1f, 0.2f }, answer.Vectors[0]);
        Assert.Equal(new[] { 0.5f, 0.6f }, answer.Vectors[1]);
        Assert.Equal(6, answer.TokensIn);
        Assert.Equal("/v1/embeddings", server.Requests.Single().Path);
    }

    [Fact]
    public async Task A_wrong_number_of_embeddings_or_of_different_sizes_is_a_bad_answer()
    {
        using var few = TinyServer.Json("""{"data":[{"index":0,"embedding":[0.1,0.2]}]}""");
        var ex = await Assert.ThrowsAsync<ProviderException>(() => Adapter(Record(few.Address)).EmbedAsync(new EmbeddingRequest(["a", "b"]), CancellationToken.None));
        Assert.Equal(ProviderException.BadAnswer, ex.Kind);

        using var uneven = TinyServer.Json("""{"data":[{"index":0,"embedding":[0.1,0.2]},{"index":1,"embedding":[0.3]}]}""");
        Assert.Equal(ProviderException.BadAnswer, (await Assert.ThrowsAsync<ProviderException>(() => Adapter(Record(uneven.Address)).EmbedAsync(new EmbeddingRequest(["a", "b"]), CancellationToken.None))).Kind);
    }

    [Fact]
    public async Task When_the_service_does_not_count_tokens_they_are_estimated_and_never_reported_as_nothing()
    {
        using var server = TinyServer.Json("""{"choices":[{"message":{"content":"twelve letters"}}]}""");
        var answer = await Adapter(Record(server.Address)).GenerateAsync(new LlmRequest([new LlmMessage("user", new string('x', 400))]), CancellationToken.None);
        Assert.Equal(100, answer.TokensIn);
        Assert.Equal(4, answer.TokensOut);
        Assert.Equal("llama", answer.Model);
    }

    [Theory]
    [InlineData(401, ProviderException.Unauthorized)]
    [InlineData(403, ProviderException.Unauthorized)]
    [InlineData(429, ProviderException.RateLimited)]
    [InlineData(500, ProviderException.BadAnswer)]
    [InlineData(404, ProviderException.BadAnswer)]
    public async Task A_refusal_from_the_service_becomes_one_of_a_few_kinds_a_screen_can_explain(int status, string kind)
    {
        using var server = TinyServer.Json("""{"error":"no"}""", status);
        var ex = await Assert.ThrowsAsync<ProviderException>(() => Adapter(Record(server.Address)).GenerateAsync(new LlmRequest([new LlmMessage("user", "hi")]), CancellationToken.None));
        Assert.Equal(kind, ex.Kind);
    }

    [Fact]
    public async Task What_a_service_says_back_in_an_error_never_shows_the_key_it_was_sent()
    {
        const string key = "sk-secret-ABCDEF123456";
        using var server = new TinyServer(r => (500, "{\"error\":\"bad header " + r.Authorization + " and " + key + "\"}", null));
        var safe = new MemorySecretStore();
        safe.Set("ai-provider/svc", key);
        var ex = await Assert.ThrowsAsync<ProviderException>(() => Adapter(Record(server.Address, secret: "ai-provider/svc"), safe).GenerateAsync(new LlmRequest([new LlmMessage("user", "hi")]), CancellationToken.None));
        Assert.DoesNotContain("ABCDEF123456", ex.Message);
        Assert.Contains("[hidden]", ex.Message);
    }

    [Fact]
    public async Task A_reply_that_is_not_what_was_expected_is_a_bad_answer_and_not_a_crash()
    {
        foreach (var body in new[] { "not json at all", "{}", """{"choices":[]}""", """{"choices":[{"message":{"content":5}}]}""", "[1,2,3]", "" })
        {
            using var server = TinyServer.Json(body);
            var ex = await Assert.ThrowsAsync<ProviderException>(() => Adapter(Record(server.Address)).GenerateAsync(new LlmRequest([new LlmMessage("user", "hi")]), CancellationToken.None));
            Assert.Equal(ProviderException.BadAnswer, ex.Kind);
        }
    }

    [Fact]
    public async Task A_service_that_is_not_there_is_reported_as_unreachable()
    {
        var port = FreePort();
        var ex = await Assert.ThrowsAsync<ProviderException>(() => Adapter(Record("http://127.0.0.1:" + port)).GenerateAsync(new LlmRequest([new LlmMessage("user", "hi")]), CancellationToken.None));
        Assert.Equal(ProviderException.Unreachable, ex.Kind);
        var health = await Adapter(Record("http://127.0.0.1:" + port)).CheckAsync(CancellationToken.None);
        Assert.False(health.Reachable);
    }

    [Fact]
    public async Task Asking_whether_a_service_is_there_lists_its_models_and_sends_nothing_else()
    {
        using var server = TinyServer.Json("""{"data":[{"id":"llama-3-8b"},{"id":"nomic-embed"}]}""");
        var health = await Adapter(Record(server.Address)).CheckAsync(CancellationToken.None);
        Assert.True(health.Reachable);
        Assert.Equal(new[] { "llama-3-8b", "nomic-embed" }, health.Models);
        Assert.Contains("2 models", health.Message);
        var request = Assert.Single(server.Requests);
        Assert.Equal(("GET", "/v1/models", ""), (request.Method, request.Path, request.Body));
    }

    [Fact]
    public async Task No_model_chosen_is_said_so_and_nothing_is_sent()
    {
        using var server = TinyServer.Json(ChatAnswer);
        var ex = await Assert.ThrowsAsync<ProviderException>(() => Adapter(Record(server.Address, model: null)).GenerateAsync(new LlmRequest([new LlmMessage("user", "hi")]), CancellationToken.None));
        Assert.Equal(ProviderException.NotSetUp, ex.Kind);
        Assert.Empty(server.Requests);
    }

    // ---- the connection rules ---------------------------------------------------------------------------------------------------

    [Fact]
    public async Task A_service_said_to_run_on_this_computer_cannot_be_reached_at_an_address_outside_it_so_nothing_is_sent()
    {
        // 203.0.113.0/24 is set aside for examples: it is not this computer, and nothing is connected to.
        var ex = await Assert.ThrowsAsync<ProviderException>(() => Adapter(Record("http://203.0.113.5:11434")).GenerateAsync(new LlmRequest([new LlmMessage("user", "the customer list")]), CancellationToken.None));
        Assert.Equal(ProviderException.Unreachable, ex.Kind);
        Assert.Contains("nothing was sent", ex.Message);
    }

    [Fact]
    public async Task A_service_said_to_be_in_the_shop_network_cannot_be_reached_at_an_address_on_the_internet()
    {
        var ex = await Assert.ThrowsAsync<ProviderException>(() => Adapter(Record("http://203.0.113.5:11434", ProviderLocation.Lan)).GenerateAsync(new LlmRequest([new LlmMessage("user", "hi")]), CancellationToken.None));
        Assert.Equal(ProviderException.Unreachable, ex.Kind);
        Assert.Contains("nothing was sent", ex.Message);
    }

    [Fact]
    public async Task A_service_that_answers_with_a_redirect_is_not_followed_to_wherever_it_points()
    {
        using var elsewhere = TinyServer.Json(ChatAnswer);
        using var server = new TinyServer(_ => (307, "", elsewhere.Address + "/v1/chat/completions"));
        var ex = await Assert.ThrowsAsync<ProviderException>(() => Adapter(Record(server.Address)).GenerateAsync(new LlmRequest([new LlmMessage("user", "secret words")]), CancellationToken.None));
        Assert.Equal(ProviderException.BadAnswer, ex.Kind);
        Assert.Empty(elsewhere.Requests);
    }

    [Fact]
    public void The_factory_builds_only_the_adapters_it_has()
    {
        var factory = new ProviderFactory(new MemorySecretStore());
        Assert.Equal(new[] { OpenAiCompatibleProvider.AdapterId }, factory.Adapters);
        Assert.Null(factory.Create(Record("http://127.0.0.1:1") with { Adapter = "something-else" }));
        Assert.NotNull(factory.Create(Record("http://127.0.0.1:1")));
    }

    private static int FreePort()
    {
        var probe = new TcpListener(IPAddress.Loopback, 0);
        probe.Start();
        var port = ((IPEndPoint)probe.LocalEndpoint).Port;
        probe.Stop();
        return port;
    }
}

public class SecretStoreTests : IDisposable
{
    private readonly string _folder = Path.Combine(Path.GetTempPath(), "hub-vault-" + Guid.NewGuid().ToString("N"));

    private EncryptedFileVault Vault() => new(Path.Combine(_folder, "ai-secrets.vault"), Path.Combine(_folder, "keys", "ai-secrets.key"));

    public void Dispose()
    {
        try { Directory.Delete(_folder, recursive: true); } catch (IOException) { }
    }

    [Fact]
    public void A_secret_is_kept_across_restarts_and_the_file_holds_nothing_readable()
    {
        const string value = "sk-live-VISIBLE-IF-NOT-ENCRYPTED";
        Vault().Set("ai-provider/a", value);
        Vault().Set("ai-provider/b", "another-secret-value");

        var again = Vault();
        Assert.Equal(value, again.Get("ai-provider/a"));
        Assert.True(again.Has("ai-provider/b"));
        Assert.False(again.Has("ai-provider/zzz"));
        Assert.Null(again.Get("ai-provider/zzz"));

        var bytes = File.ReadAllBytes(Path.Combine(_folder, "ai-secrets.vault"));
        Assert.DoesNotContain("VISIBLE", Encoding.Latin1.GetString(bytes));
        Assert.DoesNotContain("ai-provider", Encoding.Latin1.GetString(bytes));

        again.Delete("ai-provider/a");
        Assert.False(Vault().Has("ai-provider/a"));
        Assert.True(Vault().Has("ai-provider/b"));
    }

    [Fact]
    public void Each_save_uses_a_fresh_nonce_so_the_same_content_never_looks_the_same_twice()
    {
        var vault = Vault();
        vault.Set("k", "same value");
        var first = File.ReadAllBytes(Path.Combine(_folder, "ai-secrets.vault"));
        vault.Set("k", "same value");
        var second = File.ReadAllBytes(Path.Combine(_folder, "ai-secrets.vault"));
        Assert.NotEqual(first[..12], second[..12]);
        Assert.NotEqual(first, second);
    }

    [Fact]
    public void A_changed_file_or_a_lost_key_is_noticed_and_said_in_plain_words_never_read_as_empty()
    {
        Vault().Set("k", "value");
        var path = Path.Combine(_folder, "ai-secrets.vault");
        var bytes = File.ReadAllBytes(path);
        bytes[^1] ^= 0x01;
        File.WriteAllBytes(path, bytes);
        Assert.Equal("vault-damaged", Assert.Throws<HubException>(() => Vault().Get("k")).Code);

        File.WriteAllBytes(path, new byte[5]);
        Assert.Equal("vault-damaged", Assert.Throws<HubException>(() => Vault().Get("k")).Code);

        Directory.Delete(_folder, recursive: true);
        Vault().Set("k", "value");
        File.Delete(Path.Combine(_folder, "keys", "ai-secrets.key"));
        Assert.Equal("vault-damaged", Assert.Throws<HubException>(() => Vault().Get("k")).Code);
    }

    [Fact]
    public void On_a_system_with_file_permissions_the_key_file_can_be_read_by_its_owner_only()
    {
        if (OperatingSystem.IsWindows()) return;
        Vault().Set("k", "value");
        Assert.Equal(UnixFileMode.UserRead | UnixFileMode.UserWrite, File.GetUnixFileMode(Path.Combine(_folder, "keys", "ai-secrets.key")));
    }

    [Fact]
    public void A_huge_secret_is_refused()
    {
        Assert.Equal("secret-too-long", Assert.Throws<HubException>(() => Vault().Set("k", new string('x', Secrets.MaxLength + 1))).Code);
    }

    [Fact]
    public void The_memory_safe_forgets_when_the_program_stops_and_says_so()
    {
        var memory = new MemorySecretStore();
        memory.Set("a", "b");
        Assert.Equal("b", memory.Get("a"));
        memory.Delete("a");
        Assert.False(memory.Has("a"));
        Assert.Contains("memory", memory.Description);
    }

    [Fact]
    public void The_program_opens_the_safe_that_fits_the_system_and_says_where_secrets_are_kept()
    {
        var store = Secrets.Open(_folder);
        Assert.False(string.IsNullOrWhiteSpace(store.Description));
        Assert.Equal(OperatingSystem.IsWindows() ? "WindowsCredentialStore" : "EncryptedFileVault", store.GetType().Name);
    }

    [Fact]
    public void Showing_a_secret_hides_all_but_the_last_four_of_a_long_one_and_text_is_cleaned_of_any_secret_or_sign_in_header()
    {
        Assert.Equal("••••••••1234", Secrets.Mask("sk-abcdefghij1234"));
        Assert.Equal("••••••••", Secrets.Mask("tiny"));
        Assert.Equal("", Secrets.Mask(""));
        Assert.Equal("failed with [hidden] and Bearer [hidden]", Secrets.Redact("failed with sk-abcdefghij1234 and Bearer abcdefgh.ijkl-123", "sk-abcdefghij1234"));
        Assert.Equal("nothing to hide here", Secrets.Redact("nothing to hide here", "", null));
        Assert.Equal("", Secrets.Redact(null));
        // A very short "secret" is not replaced: it would mangle ordinary words.
        Assert.Equal("a cat", Secrets.Redact("a cat", "a"));
    }

    [Fact]
    public void The_key_for_the_file_is_random_and_not_the_same_on_two_computers()
    {
        var other = Path.Combine(Path.GetTempPath(), "hub-vault-" + Guid.NewGuid().ToString("N"));
        try
        {
            Vault().Set("k", "v");
            new EncryptedFileVault(Path.Combine(other, "v"), Path.Combine(other, "keys", "k")).Set("k", "v");
            Assert.NotEqual(File.ReadAllBytes(Path.Combine(_folder, "keys", "ai-secrets.key")), File.ReadAllBytes(Path.Combine(other, "keys", "k")));
            Assert.Equal(32, File.ReadAllBytes(Path.Combine(_folder, "keys", "ai-secrets.key")).Length);
        }
        finally { try { Directory.Delete(other, recursive: true); } catch (IOException) { } }
    }
}
