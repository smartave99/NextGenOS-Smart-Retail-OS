using NextGenOS.Hub.Ai;

namespace NextGenOS.Hub.Tests;

/// <summary>A licence that can be given and taken away while a test runs.</summary>
public sealed class Entitled(bool allowed = true) : IEntitlements
{
    public bool Allowed { get; set; } = allowed;

    public bool Has(string module) => Allowed && module == FeatureFlagService.LicenceModule;
}

/// <summary>An AI service that does what the test says: it answers, or fails, and it counts how often it was asked.</summary>
public sealed class FakeService(string id, string location) : ILlmProvider, IEmbeddingProvider
{
    public string Id => id;
    public string DisplayName => id;
    public string Location => location;
    public IReadOnlySet<string> Tasks { get; } = new HashSet<string> { AiTask.Generate, AiTask.Embed };

    public int Calls { get; private set; }
    public List<string> Seen { get; } = new();
    public ProviderException? Fails { get; set; }
    public int TokensIn { get; set; } = 100;
    public int TokensOut { get; set; } = 50;

    public Task<ProviderHealth> CheckAsync(CancellationToken cancel) => Task.FromResult(new ProviderHealth(Fails is null, Fails?.Message ?? "fine", ["model-a"], TimeSpan.Zero));

    public Task<LlmResponse> GenerateAsync(LlmRequest request, CancellationToken cancel)
    {
        Calls++;
        Seen.AddRange(request.Messages.Select(m => m.Content));
        if (Fails is not null) throw Fails;
        return Task.FromResult(new LlmResponse("answer from " + id, "model-" + id, TokensIn, TokensOut, TimeSpan.FromMilliseconds(5)));
    }

    public Task<EmbeddingResponse> EmbedAsync(EmbeddingRequest request, CancellationToken cancel)
    {
        Calls++;
        Seen.AddRange(request.Inputs);
        if (Fails is not null) throw Fails;
        return Task.FromResult(new EmbeddingResponse(request.Inputs.Select(_ => new[] { 0.1f, 0.2f }).ToList(), "embed-" + id, 2, TokensIn, TimeSpan.FromMilliseconds(5)));
    }
}

public sealed class FakeFactory : IProviderFactory
{
    public Dictionary<string, IAiProvider> Services { get; } = new();

    public IReadOnlyList<string> Adapters { get; } = [OpenAiCompatibleProvider.AdapterId];

    public IAiProvider? Create(ProviderRecord record) => Services.GetValueOrDefault(record.Id);
}

/// <summary>A shop with the AI foundation, a licence that can be switched, a memory-only safe and stand-in services.</summary>
public sealed class AiFixture : IDisposable
{
    public AiFixture(bool licensed = true)
    {
        Entitled = new Entitled(licensed);
        Secrets = new MemorySecretStore();
        _options = new AiOptions(Entitled, Secrets, Factory, new FixedProbe());
        Shop = new HubFixture(ai: _options);
    }

    private readonly AiOptions _options;

    public Entitled Entitled { get; }
    public MemorySecretStore Secrets { get; }
    public FakeFactory Factory { get; } = new();
    public HubFixture Shop { get; }
    public HubApp App => Shop.App;
    public AiFoundation Ai => App.Ai;

    /// <summary>The same shop file opened again with the same licence, safe and services, as after the program was stopped and started.</summary>
    public HubApp Reopen() => HubApp.OpenTrusted(App.Db.Path, Shop.Clock, null, _options);

    /// <summary>Connects a stand-in service, switched on, at an address that fits its place.</summary>
    public FakeService Connect(string id, string location, bool on = true, string[]? tasks = null, ProviderLimits? limits = null, long? priceIn = null, long? priceOut = null)
    {
        var service = new FakeService(id, location);
        Factory.Services[id] = service;
        var url = location switch
        {
            ProviderLocation.Local or ProviderLocation.LocalOptimized => "http://127.0.0.1:11434",
            ProviderLocation.Lan => "http://192.168.1.20:11434",
            _ => "https://api.example.com/v1",
        };
        Ai.Providers.Save(new ProviderInput(id, id, OpenAiCompatibleProvider.AdapterId, location, url, "m", tasks ?? [AiTask.Generate, AiTask.Embed], priceIn, priceOut, limits), 1);
        if (on) Ai.Providers.SetEnabled(id, true, 1);
        return service;
    }

    /// <summary>Switches on what a feature needs (the licence is already given).</summary>
    public void Allow(params string[] flags)
    {
        foreach (var flag in flags) Ai.Flags.Set(flag, true, 1);
    }

    public void Dispose() => Shop.Dispose();

    private sealed class FixedProbe : IHardwareProbe
    {
        public RawHardware Probe(string dataFolder) => new("x64", 4, 8, 16, 8, [], null,
            new Accelerators(Support.Unknown, Support.Unknown, Support.Unknown, Support.Unknown, Support.Unknown, Support.Unknown, Support.Unknown), 100, "test", true, false, []);
    }
}
