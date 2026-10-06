using NextGenOS.Hub.Ai;

namespace NextGenOS.Hub.Tests;

/// <summary>An AI service that holds each request until the test lets it go, so that what runs at once and in what order can be seen.</summary>
public sealed class HeldService(string id, string location) : ILlmProvider
{
    private readonly object _lock = new();
    private readonly SemaphoreSlim _release = new(0);
    private int _now;

    public string Id => id;
    public string DisplayName => id;
    public string Location => location;
    public IReadOnlySet<string> Tasks { get; } = new HashSet<string> { AiTask.Generate };
    public List<string> Started { get; } = new();
    public int Peak { get; private set; }
    public int Cancelled { get; private set; }

    public Task<ProviderHealth> CheckAsync(CancellationToken cancel) => Task.FromResult(new ProviderHealth(true, "fine", [], TimeSpan.Zero));

    public async Task<LlmResponse> GenerateAsync(LlmRequest request, CancellationToken cancel)
    {
        lock (_lock) { Started.Add(request.Messages[0].Content); _now++; Peak = Math.Max(Peak, _now); }
        try
        {
            await _release.WaitAsync(cancel);
            return new LlmResponse("answer to " + request.Messages[0].Content, "m", 10, 5, TimeSpan.Zero);
        }
        catch (OperationCanceledException)
        {
            lock (_lock) Cancelled++;
            throw;
        }
        finally
        {
            lock (_lock) _now--;
        }
    }

    public void Let(int count = 1) => _release.Release(count);

    public string[] StartedNow { get { lock (_lock) return Started.ToArray(); } }
}

public class AiJobQueueTests
{
    private static AiContext Ctx() => new("assistant", DataClass.Internal, 1, FlagKey.AiAssistant);

    private static AiFixture Ready(out HeldService held)
    {
        var f = new AiFixture();
        f.Connect("held", ProviderLocation.Local);
        held = new HeldService("held", ProviderLocation.Local);
        f.Factory.Services["held"] = held;
        f.Allow(FlagKey.AiAssistant);
        return f;
    }

    private static Task<AiAnswer<LlmResponse>> Ask(AiJobQueue queue, string text, int priority = JobPriority.Normal, CancellationToken cancel = default) =>
        queue.GenerateAsync(Ctx(), new LlmRequest([new LlmMessage("user", text)]), priority, cancel);

    private static async Task Until(Func<bool> condition, string what)
    {
        for (var i = 0; i < 200 && !condition(); i++) await Task.Delay(25);
        Assert.True(condition(), "Gave up waiting for: " + what);
    }

    [Fact]
    public async Task Requests_are_answered_in_order_of_importance_and_in_the_order_they_came_within_one_importance()
    {
        using var f = Ready(out var held);
        using var queue = new AiJobQueue(f.Ai.Gateway, maxRunning: 1, maxWaiting: 10);

        var first = Ask(queue, "first");
        await Until(() => held.StartedNow.Length == 1, "the first request to start");
        var background = Ask(queue, "background", JobPriority.Background);
        var normal1 = Ask(queue, "normal-1", JobPriority.Normal);
        var normal2 = Ask(queue, "normal-2", JobPriority.Normal);
        var urgent = Ask(queue, "urgent", JobPriority.Interactive);
        Assert.Equal(4, queue.Waiting);

        for (var i = 0; i < 5; i++)
        {
            held.Let();
            await Until(() => held.StartedNow.Length >= Math.Min(i + 2, 5), "the next request to start");
        }

        var answers = await Task.WhenAll(first, background, normal1, normal2, urgent);
        Assert.All(answers, a => Assert.True(a.Ok));
        Assert.Equal(new[] { "first", "urgent", "normal-1", "normal-2", "background" }, held.StartedNow);
        Assert.Equal("answer to urgent", answers[4].Value!.Text);
        Assert.Equal((0, 0), (queue.Running, queue.Waiting));
    }

    [Fact]
    public async Task No_more_than_the_allowed_number_run_at_once_and_all_of_them_are_answered_in_the_end()
    {
        using var f = Ready(out var held);
        using var queue = new AiJobQueue(f.Ai.Gateway, maxRunning: 2, maxWaiting: 20);

        var all = Enumerable.Range(1, 7).Select(i => Ask(queue, "job-" + i)).ToList();
        await Until(() => held.StartedNow.Length == 2, "two to start");
        await Task.Delay(100);
        Assert.Equal(2, held.StartedNow.Length);
        Assert.Equal((2, 5), (queue.Running, queue.Waiting));

        held.Let(7);
        var answers = await Task.WhenAll(all);
        Assert.All(answers, a => Assert.True(a.Ok));
        Assert.Equal(2, held.Peak);
        Assert.Equal(7, held.StartedNow.Length);
    }

    [Fact]
    public async Task A_request_that_is_still_waiting_can_be_called_off_and_is_never_started()
    {
        using var f = Ready(out var held);
        using var queue = new AiJobQueue(f.Ai.Gateway, maxRunning: 1, maxWaiting: 10);
        var running = Ask(queue, "running");
        await Until(() => held.StartedNow.Length == 1, "the first to start");
        using var source = new CancellationTokenSource();
        var waiting = Ask(queue, "never", cancel: source.Token);
        var after = Ask(queue, "after");
        Assert.Equal(2, queue.Waiting);

        source.Cancel();
        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => waiting);
        Assert.Equal(1, queue.Waiting);

        held.Let(2);
        Assert.True((await running).Ok);
        Assert.True((await after).Ok);
        Assert.DoesNotContain("never", held.StartedNow);
    }

    [Fact]
    public async Task A_request_that_is_being_answered_can_be_called_off_and_its_place_goes_to_the_next()
    {
        using var f = Ready(out var held);
        using var queue = new AiJobQueue(f.Ai.Gateway, maxRunning: 1, maxWaiting: 10);
        using var source = new CancellationTokenSource();
        var running = Ask(queue, "running", cancel: source.Token);
        var next = Ask(queue, "next");
        await Until(() => held.StartedNow.Length == 1, "the first to start");

        source.Cancel();
        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => running);
        await Until(() => held.StartedNow.Length == 2, "the next to start");
        Assert.Equal(1, held.Cancelled);
        held.Let();
        Assert.True((await next).Ok);
        Assert.Equal(0, queue.Running);
    }

    [Fact]
    public async Task When_too_many_are_waiting_the_least_important_are_turned_away_with_a_plain_answer_instead_of_piling_up()
    {
        using var f = Ready(out var held);
        using var queue = new AiJobQueue(f.Ai.Gateway, maxRunning: 1, maxWaiting: 2);
        var running = Ask(queue, "running");
        await Until(() => held.StartedNow.Length == 1, "the first to start");
        var background = Ask(queue, "background", JobPriority.Background);
        var normal = Ask(queue, "normal", JobPriority.Normal);
        Assert.Equal(2, queue.Waiting);

        // A person is waiting: the background request makes room.
        var urgent = Ask(queue, "urgent", JobPriority.Interactive);
        var turned = await background;
        Assert.False(turned.Ok);
        Assert.Contains("not urgent", turned.Refusal);
        Assert.Equal(2, queue.Waiting);

        // Nobody waiting is less important than this one: it is turned away at once.
        var late = await Ask(queue, "late", JobPriority.Background);
        Assert.False(late.Ok);
        Assert.Contains("busy", late.Refusal);
        var equal = await Ask(queue, "equal", JobPriority.Normal);
        Assert.False(equal.Ok);
        Assert.Equal(2, queue.Waiting);

        held.Let(3);
        Assert.True((await running).Ok);
        Assert.True((await urgent).Ok);
        Assert.True((await normal).Ok);
        Assert.Equal(new[] { "running", "urgent", "normal" }, held.StartedNow);
    }

    [Fact]
    public async Task A_request_the_gateway_refuses_is_answered_with_the_reason_and_does_not_hold_up_the_line()
    {
        using var f = Ready(out var held);
        f.Ai.Flags.Set(FlagKey.AiAssistant, false, 1);
        using var queue = new AiJobQueue(f.Ai.Gateway, maxRunning: 1, maxWaiting: 10);

        var refused = await Ask(queue, "hello");
        Assert.False(refused.Ok);
        Assert.Contains("switched off", refused.Refusal);
        Assert.Empty(held.StartedNow);

        f.Ai.Flags.Set(FlagKey.AiAssistant, true, 1);
        held.Let();
        Assert.True((await Ask(queue, "again")).Ok);
        Assert.Equal((0, 0), (queue.Running, queue.Waiting));
    }

    [Fact]
    public async Task Embeddings_go_through_the_same_line()
    {
        using var f = new AiFixture();
        f.Connect("here", ProviderLocation.Local, tasks: [AiTask.Embed]);
        f.Allow(FlagKey.LocalEmbeddings);
        using var queue = new AiJobQueue(f.Ai.Gateway);
        var answer = await queue.EmbedAsync(new AiContext("search", DataClass.Internal, 1, FlagKey.LocalEmbeddings), new EmbeddingRequest(["rice", "sugar"]), JobPriority.Background, CancellationToken.None);
        Assert.True(answer.Ok);
        Assert.Equal(2, answer.Value!.Vectors.Count);
    }

    [Fact]
    public async Task Closing_the_line_calls_off_what_is_waiting_and_what_is_running_and_turns_new_requests_away()
    {
        using var f = Ready(out var held);
        var queue = new AiJobQueue(f.Ai.Gateway, maxRunning: 1, maxWaiting: 10);
        var running = Ask(queue, "running");
        await Until(() => held.StartedNow.Length == 1, "the first to start");
        var waiting = Ask(queue, "waiting");

        queue.Dispose();

        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => waiting);
        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => running);
        var after = await Ask(queue, "too late");
        Assert.False(after.Ok);
        Assert.Contains("shutting down", after.Refusal);
        queue.Dispose();   // closing twice is harmless
        Assert.Equal(new[] { "running" }, held.StartedNow);
    }

    [Fact]
    public async Task An_unknown_importance_is_a_mistake_in_the_program_and_is_refused_loudly()
    {
        using var f = Ready(out _);
        using var queue = new AiJobQueue(f.Ai.Gateway);
        Assert.Throws<ArgumentOutOfRangeException>(() => { _ = Ask(queue, "x", priority: 7); });
        Assert.Throws<ArgumentOutOfRangeException>(() => { _ = Ask(queue, "x", priority: -1); });
        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => Ask(queue, "x", cancel: new CancellationToken(canceled: true)));
        Assert.Equal((0, 0), (queue.Running, queue.Waiting));
        foreach (var p in new[] { JobPriority.Interactive, JobPriority.Normal, JobPriority.Background }) Assert.NotEqual("Unknown", JobPriority.Label(p));
    }

    [Fact]
    public void The_foundation_has_one_line_in_front_of_its_gateway()
    {
        using var f = new AiFixture();
        Assert.NotNull(f.Ai.Jobs);
        Assert.Equal((0, 0), (f.Ai.Jobs.Running, f.Ai.Jobs.Waiting));
    }
}
