using SmartRetail.AI.Assistant;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// The chat on the demo shop, which has no SQL Server behind it: the AI answers from the last 30 days' figures, the
/// same <see cref="SalesBrief"/> the growth plan uses (figures and product names only, never customer details), and
/// what the assistant remembers.
/// </summary>
public sealed class DemoChatBackend : IChatBackend, IAttachmentChat
{
    private readonly AiEnvironment _ai;
    private readonly ISalesFactsRepository _facts;
    private readonly ProductPhotoService _photos;
    private readonly MemoryService _memory;
    private readonly TimeProvider _clock;

    public DemoChatBackend(AiEnvironment ai, ISalesFactsRepository facts, ProductPhotoService photos, MemoryService memory, TimeProvider clock)
    {
        _ai = ai;
        _facts = facts;
        _photos = photos;
        _memory = memory;
        _clock = clock;
    }

    public IReadOnlyList<ChatStarter> Starters { get; } = new[]
    {
        new ChatStarter("This week", "How did sales go this week?"),
        new ChatStarter("Best sellers", "Which products sell best?"),
        new ChatStarter("What to reorder", "What should I reorder?"),
        new ChatStarter("Ideas", "Give me three ideas to sell more this month."),
    };

    public Task<ChatMessage> AskAsync(string question, IProgress<string> progress, CancellationToken cancellationToken) =>
        AskAsync(question, null, progress, cancellationToken);

    /// <summary>A question with photos or a voice note: the AI looks at them, and says what it heard.</summary>
    public async Task<ChatMessage> AskAsync(string question, IReadOnlyList<ChatAttachment>? attachments, IProgress<string> progress, CancellationToken cancellationToken)
    {
        var photos = (attachments ?? Array.Empty<ChatAttachment>()).Where(a => a.Kind == AttachmentKind.Photo).Select(a => a.Path).ToList();
        var voice = (attachments ?? Array.Empty<ChatAttachment>()).Where(a => a.Kind == AttachmentKind.Voice).Select(a => a.Path).ToList();
        progress?.Report("Reading the shop's figures…");
        var today = DateOnly.FromDateTime(_clock.GetLocalNow().DateTime);
        var end = SalesPeriods.EndDay(today, await _facts.GetBillSpanAsync(cancellationToken));
        var report = await _facts.LoadReportAsync(DateRange.Ending(end, 30), cancellationToken);
        var request = new AiRequest
        {
            SystemPrompt = ShopQuestionPrompt.SystemPrompt,
            UserPrompt = ShopQuestionPrompt.UserPrompt(SalesBrief.Write(report, _photos.WhatItIs), question, _memory.Snapshot(), photos.Count, voice.Count > 0),
            // The answer shows as it is written, when the AI tool can stream it.
            OnText = progress is IAnswerProgress answer ? answer.Draft : null,
        };

        request.Images.AddRange(photos);
        request.Audio.AddRange(voice);

        var router = _ai.CreateRouter(AiJob.Ask);
        var response = await router.CompleteAsync(request, ProviderIds.Auto, cancellationToken, progress);
        var name = router.Find(response.ProviderId)?.DisplayName ?? response.ProviderId;
        var (heard, text) = voice.Count > 0 ? ShopQuestionPrompt.SplitHeard(response.Text) : (null, response.Text.Trim());
        return new ChatMessage(ChatRole.Assistant, text, _clock.GetLocalNow().DateTime)
        {
            Source = ChatMessage.Describe(name, response.Duration),
            Heard = heard,
        };
    }

    public Task<ChatMessage> RunAsync(ChatStarter starter, IProgress<string> progress, CancellationToken cancellationToken) =>
        AskAsync(starter.Question, progress, cancellationToken);
}
