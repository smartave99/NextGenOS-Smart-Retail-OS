using System.Diagnostics;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Security;

namespace NextGenOS.Hub.Ai;

/// <summary>Who is asking, for what, with what kind of data.</summary>
/// <param name="Feature">The name of the feature (for the record, and for the permissions the owner gave "only for this feature").</param>
/// <param name="DataClass">What kind of data the request holds (<see cref="DataClass"/>). When in doubt the caller names the more private kind.</param>
/// <param name="Flag">The switch the feature belongs to (<see cref="FlagKey"/>). It must be on.</param>
/// <param name="PreferredProvider">A service to try first, when it is allowed.</param>
public sealed record AiContext(string Feature, string DataClass, long? UserId = null, string? Flag = null, string? PreferredProvider = null);

/// <summary>The answer to an AI request, or the reason there is none. A feature always has to cope with "no answer": nothing in the shop depends on one.</summary>
public sealed record AiAnswer<T>(T? Value, string? ProviderId, string? Refusal, IReadOnlyList<RouteStep> Trace) where T : class
{
    public bool Ok => Value is not null && Refusal is null;
}

/// <summary>
/// The one door to AI services. A feature gives it the request, what kind of data it holds and which switch it belongs to; the gateway checks the licence and the switch, applies the privacy
/// rules (<see cref="Routing"/>), keeps to the limits, tries the allowed services best first, and writes down what happened. Business code never calls a service itself.
/// </summary>
public sealed class AiGateway(ProviderService providers, FeatureFlagService flags, UsageService usage, IProviderFactory factory, EgressLog egress, PersonalValues people)
{
    private sealed record Called<T>(T Value, string Model, int TokensIn, int TokensOut);

    public Task<AiAnswer<LlmResponse>> GenerateAsync(AiContext context, LlmRequest request, CancellationToken cancel)
    {
        var texts = request.Messages.Select(m => m.Content).ToList();
        return RunAsync<LlmResponse, ILlmProvider>(AiTask.Generate, context, texts, EstimateTokens(texts) + (request.MaxTokens ?? 0), cancel,
            async p => { var r = await p.GenerateAsync(request, cancel); return new Called<LlmResponse>(r, r.Model, r.TokensIn, r.TokensOut); });
    }

    public Task<AiAnswer<EmbeddingResponse>> EmbedAsync(AiContext context, EmbeddingRequest request, CancellationToken cancel) =>
        RunAsync<EmbeddingResponse, IEmbeddingProvider>(AiTask.Embed, context, request.Inputs, EstimateTokens(request.Inputs), cancel,
            async p => { var r = await p.EmbedAsync(request, cancel); return new Called<EmbeddingResponse>(r, r.Model, r.TokensIn, 0); });

    /// <summary>
    /// Asks a service to do one of the closed list of purposes (blueprint AI-014). The text sent is built here from the purpose's fixed instruction and its allowed fields only; whatever else was
    /// supplied is left out, and a value that is not the shape its field allows (or is a card number, a contact detail, a link, an instruction, or a name or address the shop keeps for a person)
    /// stops the whole request before anything is sent. What was sent is written down field by field, with the version of the owner's permission it relied on; never the values and never the reply.
    /// </summary>
    public Task<AiAnswer<LlmResponse>> GenerateAsync(EgressRequest request, long? userId, CancellationToken cancel)
    {
        var purpose = EgressPurposes.Find(request.Purpose);
        if (purpose is null)
        {
            var note = new EgressNote(Clip(request.Purpose), [], request.Fields.Keys.Order(StringComparer.Ordinal).ToList());
            return Task.FromResult(Refuse<LlmResponse>(new AiContext("egress", DataClass.Public, userId), AiTask.Generate, DataClass.Public, "The program does not know that reason for sending anything to an AI service, so nothing was sent.", [], note));
        }

        var built = EgressGuard.Build(purpose, request.Fields, people.Known());
        var summary = new EgressNote(purpose.Id, built.Sent, built.Dropped);
        var context = new AiContext(purpose.Feature, built.Ok ? built.DataClass : purpose.MostPrivateClass, userId, purpose.Flag);
        if (!built.Ok) return Task.FromResult(Refuse<LlmResponse>(context, purpose.Task, context.DataClass, built.Refusal!, [], summary));
        var texts = new[] { built.Text };
        return RunAsync<LlmResponse, ILlmProvider>(purpose.Task, context, texts, EstimateTokens(texts) + purpose.MaxTokens, cancel,
            async p => { var r = await p.GenerateAsync(new LlmRequest([new LlmMessage("user", built.Text)], MaxTokens: purpose.MaxTokens), cancel); return new Called<LlmResponse>(r, r.Model, r.TokensIn, r.TokensOut); }, summary);
    }

    private static string Clip(string? text) => text is { Length: > 60 } ? text[..60] : text ?? "";

    /// <summary>Asks a service whether it is there. Nothing of the shop is sent; it is not counted as a use.</summary>
    public async Task<ProviderHealth> CheckAsync(string providerId, CancellationToken cancel)
    {
        if (!flags.Licensed) return new ProviderHealth(false, "The AI features are not part of this shop's licence.", [], TimeSpan.Zero);
        var record = providers.Find(providerId);
        if (record is null) return new ProviderHealth(false, "That AI service does not exist.", [], TimeSpan.Zero);
        if (EndpointClassifier.Mismatch(record.Location, record.BaseUrl) is { } mismatch) return new ProviderHealth(false, mismatch, [], TimeSpan.Zero);
        var provider = factory.Create(record);
        return provider is null ? new ProviderHealth(false, "This program cannot talk to that kind of service yet.", [], TimeSpan.Zero) : await provider.CheckAsync(cancel);
    }

    private async Task<AiAnswer<T>> RunAsync<T, TProvider>(string task, AiContext context, IEnumerable<string> texts, long estimatedTokens, CancellationToken cancel,
        Func<TProvider, Task<Called<T>>> call, EgressNote? egressNote = null) where T : class where TProvider : class, IAiProvider
    {
        // What the text itself shows counts, whatever the caller called it: a card number makes it payment data (that never leaves this computer), an e-mail address or a phone
        // number makes anything that was called public, internal or confidential personal data (which an online service gets only with the owner's permission).
        var dataClass = Strictest(context.DataClass, texts);

        if (!flags.Licensed) return Refuse<T>(context, task, dataClass, "The AI features are not part of this shop's licence.", [], egressNote);
        if (context.Flag is not null && !flags.IsEnabled(context.Flag)) return Refuse<T>(context, task, dataClass, "This feature is switched off. The owner can switch it on in the AI settings.", [], egressNote);

        var decision = Routing.Decide(new RouteQuestion(task, dataClass, context.Feature, flags.IsEnabled(FlagKey.RemoteAi), context.PreferredProvider), providers.Facts());
        if (!decision.Allowed) return Refuse<T>(context, task, dataClass, decision.Refusal ?? "No AI service may do this.", decision.Trace, egressNote);

        var trace = decision.Trace.ToList();
        string? last = null;
        foreach (var id in decision.Order)
        {
            var record = providers.Find(id);
            if (record is null) continue;
            if (factory.Create(record) is not TProvider provider)
            {
                last = record.Name + " cannot do this kind of work.";
                trace.Add(new RouteStep(id, record.Name, false, last));
                continue;
            }

            var over = Budget.Check(record.Name, record.Limits, usage.Today(id), usage.ThisMonth(id), estimatedTokens);
            if (over is not null)
            {
                usage.Record(new UsageEntry(id, record.DefaultModel, task, context.Feature, dataClass, 0, 0, 0, 0, Outcome.OverBudget, over, context.UserId));
                LogEgress(egressNote, context, dataClass, record, record.DefaultModel, Outcome.OverBudget, 0, 0, 0, over);
                trace.Add(new RouteStep(id, record.Name, false, over));
                last = over;
                continue;
            }

            var watch = Stopwatch.StartNew();
            try
            {
                var done = await call(provider);
                var cost = Budget.Cost(done.TokensIn, done.TokensOut, record.PriceInMicrosPer1k, record.PriceOutMicrosPer1k);
                usage.Record(new UsageEntry(id, done.Model, task, context.Feature, dataClass, done.TokensIn, done.TokensOut, cost, watch.ElapsedMilliseconds, Outcome.Ok, null, context.UserId));
                LogEgress(egressNote, context, dataClass, record, done.Model, Outcome.Ok, done.TokensIn, done.TokensOut, cost, null);
                return new AiAnswer<T>(done.Value, id, null, trace);
            }
            catch (OperationCanceledException) when (cancel.IsCancellationRequested)
            {
                throw;
            }
            catch (Exception e)
            {
                // A service that fails is not the end: the next allowed one is tried. The record keeps the reason (a key in it is hidden first).
                last = e is ProviderException ? e.Message : record.Name + " failed unexpectedly.";
                var why = Secrets.Redact(e is ProviderException p ? p.Kind + ": " + e.Message : e.GetType().Name);
                usage.Record(new UsageEntry(id, record.DefaultModel, task, context.Feature, dataClass, 0, 0, 0, watch.ElapsedMilliseconds, Outcome.Failed, why, context.UserId));
                LogEgress(egressNote, context, dataClass, record, record.DefaultModel, Outcome.Failed, 0, 0, 0, why);
                trace.Add(new RouteStep(id, record.Name, false, last));
            }
        }

        return new AiAnswer<T>(null, null, "No AI service could do this just now. " + last, trace);
    }

    private AiAnswer<T> Refuse<T>(AiContext context, string task, string dataClass, string reason, IReadOnlyList<RouteStep> trace, EgressNote? egressNote = null) where T : class
    {
        usage.Record(new UsageEntry(null, null, task, context.Feature, dataClass, 0, 0, 0, 0, Outcome.Refused, reason, context.UserId));
        LogEgress(egressNote, context, dataClass, null, null, Outcome.Refused, 0, 0, 0, reason);
        return new AiAnswer<T>(null, null, reason, trace);
    }

    /// <summary>Writes down, for a request made through a purpose, which fields it carried, where it went and which permission of the owner it relied on. Never a value.</summary>
    private void LogEgress(EgressNote? note, AiContext context, string dataClass, ProviderRecord? provider, string? model, string outcome, int tokensIn, int tokensOut, long cost, string? detail)
    {
        if (note is null) return;
        string? consent = null;
        if (provider is not null && Routing.NeedsConsent(dataClass, provider.Location))
            consent = providers.Consents(provider.Id).FirstOrDefault(c => c.DataClass == dataClass && (c.Features == "*" || c.Features.Split(',').Contains(context.Feature)))?.GrantedAt.UtcDateTime.ToString("O", System.Globalization.CultureInfo.InvariantCulture);
        // Only a request that reached a service sent anything (a service that then failed was still sent it); a request that was refused, or stopped by a limit, sent nothing.
        var sent = outcome is Outcome.Ok or Outcome.Failed ? note : note with { Sent = [] };
        egress.Record(sent, context.Feature, dataClass, provider, consent, model, outcome, tokensIn, tokensOut, cost, detail, context.UserId);
    }

    private static string Strictest(string given, IEnumerable<string> texts)
    {
        var all = texts.ToList();
        if (all.Any(TextGuard.ContainsCardNumber)) return DataClass.PaymentSensitive;
        if (given is DataClass.Public or DataClass.Internal or DataClass.Confidential && all.Any(TextGuard.ContainsContactDetails)) return DataClass.Personal;
        return given;
    }

    /// <summary>About four letters to a token. It is only used to keep to a limit before a call; the real count is written down after.</summary>
    public static long EstimateTokens(IEnumerable<string> texts) => Math.Max(1, texts.Sum(t => (long)t.Length) / 4);
}

/// <summary>
/// The AI foundation as the program holds it. It is made with the shop's database, and does nothing until the owner switches something on: no service, no model and no camera is
/// started, and nothing is downloaded or sent anywhere.
/// </summary>
public sealed class AiFoundation
{
    public AiFoundation(HubDb db, IClock clock, AuditService audit, string dataFolder, Access access, AiOptions? options = null)
    {
        options ??= new AiOptions();
        Entitlements = options.Entitlements ?? new NoEntitlements();
        Secrets = options.Secrets ?? Ai.Secrets.Open(dataFolder);
        var factory = options.Factory ?? new ProviderFactory(Secrets);
        Flags = new FeatureFlagService(db, clock, audit, Entitlements, access);
        Providers = new ProviderService(db, clock, audit, Secrets, factory, access);
        Models = new ModelRegistry(db, clock, audit, access);
        Usage = new UsageService(db, clock);
        Egress = new EgressLog(db, clock, access);
        Hardware = new HardwareService(options.Probe ?? new SystemHardwareProbe(), dataFolder, clock);
        Gateway = new AiGateway(Providers, Flags, Usage, factory, Egress, new PersonalValues(db));
        Jobs = new AiJobQueue(Gateway);
    }

    public IEntitlements Entitlements { get; }
    public ISecretStore Secrets { get; }
    public FeatureFlagService Flags { get; }
    public ProviderService Providers { get; }
    public ModelRegistry Models { get; }
    public UsageService Usage { get; }
    /// <summary>What was sent to AI services, field by field (never values).</summary>
    public EgressLog Egress { get; }
    public HardwareService Hardware { get; }
    public AiGateway Gateway { get; }
    /// <summary>The waiting line in front of the gateway, for work that should not crowd out a person who is waiting (reports, cameras).</summary>
    public AiJobQueue Jobs { get; }
}

/// <summary>What the program that hosts the Hub gives the AI foundation. Anything not given is the safe choice: no licence for AI, the computer's own secret store, the real machine.</summary>
public sealed record AiOptions(IEntitlements? Entitlements = null, ISecretStore? Secrets = null, IProviderFactory? Factory = null, IHardwareProbe? Probe = null);
