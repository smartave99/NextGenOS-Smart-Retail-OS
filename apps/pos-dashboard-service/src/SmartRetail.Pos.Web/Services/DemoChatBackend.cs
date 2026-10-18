using SmartRetail.AI.Assistant;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using SmartRetail.AI.Work;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// The chat on the demo shop, which has no SQL Server behind it: the AI answers from the last 30 days' figures, the
/// same <see cref="SalesBrief"/> the growth plan uses (figures and product names only, never customer details), and
/// what the assistant remembers.
/// </summary>
public sealed class DemoChatBackend : IChatBackend, IAttachmentChat, IContextChat
{
    private readonly AiEnvironment _ai;
    private readonly ISalesFactsRepository _facts;
    private readonly ProductPhotoService _photos;
    private readonly MemoryService _memory;
    private readonly WorkService _work;
    private readonly TimeProvider _clock;

    public DemoChatBackend(AiEnvironment ai, ISalesFactsRepository facts, ProductPhotoService photos, MemoryService memory, WorkService work, TimeProvider clock)
    {
        _work = work;
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
        AskAsync(new AskRequest { Question = question }, progress, cancellationToken);

    /// <summary>A question with photos or a voice note: the AI looks at them, and says what it heard.</summary>
    public Task<ChatMessage> AskAsync(string question, IReadOnlyList<ChatAttachment>? attachments, IProgress<string> progress, CancellationToken cancellationToken) =>
        AskAsync(new AskRequest { Question = question, Attachments = attachments ?? Array.Empty<ChatAttachment>() }, progress, cancellationToken);

    /// <summary>
    /// The question with the chat so far: advice, ideas and plans are answered as a conversation (the shop's figures are not even read),
    /// and a question about the figures is answered from the last 30 days' figures, with the chat in the prompt either way.
    /// </summary>
    public async Task<ChatMessage> AskAsync(AskRequest ask, IProgress<string> progress, CancellationToken cancellationToken)
    {
        var question = ask.Question;
        var photos = ask.Attachments.Where(a => a.Kind == AttachmentKind.Photo).Select(a => a.Path).ToList();
        var voice = ask.Attachments.Where(a => a.Kind == AttachmentKind.Voice).Select(a => a.Path).ToList();
        var now = _clock.GetLocalNow().DateTime;
        var route = RequestRouter.Decide(question, ask.Context, photos.Count + voice.Count > 0, _ai.Shop.ChatWords);
        if (route.Kind == RequestKind.Work && voice.Count == 0)
        {
            return await KeepWorkAsync(question, ask.Context, now, progress, cancellationToken);
        }

        AiRequest request;
        if (route.NeedsData || voice.Count > 0)
        {
            progress?.Report("Reading the shop's figures…");
            var today = DateOnly.FromDateTime(now);
            var end = SalesPeriods.EndDay(today, await _facts.GetBillSpanAsync(cancellationToken));
            var report = await _facts.LoadReportAsync(DateRange.Ending(end, 30), cancellationToken);
            request = new AiRequest
            {
                SystemPrompt = ShopQuestionPrompt.SystemPrompt,
                UserPrompt = ShopQuestionPrompt.UserPrompt(SalesBrief.Write(report, _photos.WhatItIs), question, _memory.Snapshot(), photos.Count, voice.Count > 0, ask.Context.ToPrompt()),
            };
        }
        else
        {
            progress?.Report("Thinking it through…");
            request = Prompts.AdviceRequest(question, now, _memory.Snapshot(), ask.Context, photos.Count, _ai.Shop, WorkKeeper.PlanText(_work, now));
        }

        // The answer shows as it is written, when the AI tool can stream it.
        request.OnText = progress is IAnswerProgress answer ? answer.Draft : null;
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
            Route = route.Kind == RequestKind.Work ? RequestKind.General : route.Kind,
        };
    }

    /// <summary>The owner asks to keep some work: the AI says what it would put in the plan, the plan decides what fits, and the owner decides what is kept.</summary>
    private async Task<ChatMessage> KeepWorkAsync(string question, ConversationContext context, DateTime now, IProgress<string> progress, CancellationToken cancellationToken)
    {
        progress?.Report("Working out what to put in your plan…");
        var settings = _ai.LoadSettings();
        var request = WorkExtraction.Request(question, now, _memory.Snapshot(), WorkKeeper.PlanText(_work, now), context, _ai.Shop);
        var router = _ai.CreateRouter(AiJob.Ask);
        var response = await router.CompleteAsync(request, ProviderIds.Auto, cancellationToken, progress);
        var suggestion = WorkExtraction.Parse(response.Text, now);
        var answer = new AssistantAnswer { Question = question, Answer = suggestion.Words(), Work = suggestion, Route = RequestKind.Work };
        var proposalId = WorkKeeper.Keep(answer, _work, settings.Memory.AskBeforeSaving);
        var name = router.Find(response.ProviderId)?.DisplayName ?? response.ProviderId;
        return new ChatMessage(ChatRole.Assistant, answer.Answer.Trim(), _clock.GetLocalNow().DateTime)
        {
            Source = ChatMessage.Describe(name, response.Duration),
            Route = RequestKind.Work,
            WorkProposalId = proposalId,
        };
    }

    public Task<ChatMessage> RunAsync(ChatStarter starter, IProgress<string> progress, CancellationToken cancellationToken) =>
        AskAsync(starter.Question, progress, cancellationToken);
}
