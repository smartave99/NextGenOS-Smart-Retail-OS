namespace NextGenOS.Hub.Ai;

/// <summary>How soon a request should be answered. A person waiting is served before a report being prepared, which is served before background work.</summary>
public static class JobPriority
{
    public const int Interactive = 0;
    public const int Normal = 1;
    public const int Background = 2;

    public static bool IsKnown(int priority) => priority is >= Interactive and <= Background;

    public static string Label(int priority) => priority switch { Interactive => "A person is waiting", Normal => "Normal", Background => "In the background", _ => "Unknown" };
}

/// <summary>
/// A waiting line in front of the AI gateway, so that a flood of requests (a camera, a report) cannot starve a person who is waiting for an answer and cannot swamp this computer:
/// at most a few run at once, the rest wait in order of priority (and, within a priority, in the order they came), a waiting request can be cancelled, and when too many are
/// waiting the least important are turned away with a plain answer rather than piling up. It lives in memory: when the program stops, what was waiting is gone (nothing here is
/// kept for later; a durable line comes with the camera work, which needs one). Nothing in the shop's own screens waits on it.
/// </summary>
public sealed class AiJobQueue(AiGateway gateway, int maxRunning = 2, int maxWaiting = 100) : IDisposable
{
    private readonly object _gate = new();
    private readonly LinkedList<Job>[] _lanes = [new(), new(), new()];
    private readonly CancellationTokenSource _stopping = new();
    private int _running;
    private bool _disposed;

    private abstract class Job
    {
        public int Priority { get; init; }
        public LinkedListNode<Job>? Node { get; set; }
        public CancellationTokenSource Cancel { get; init; } = null!;
        public CancellationTokenRegistration Registration { get; set; }
        public abstract Task RunAsync();
        public abstract void Turn(string why);
        public abstract void Abandon();
    }

    private sealed class Job<T>(Func<CancellationToken, Task<AiAnswer<T>>> work) : Job where T : class
    {
        public TaskCompletionSource<AiAnswer<T>> Done { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

        public override async Task RunAsync()
        {
            try { Done.TrySetResult(await work(Cancel.Token)); }
            catch (OperationCanceledException) { Done.TrySetCanceled(Cancel.Token); }
            catch (Exception) { Done.TrySetResult(new AiAnswer<T>(null, null, "The AI helper stopped unexpectedly. Nothing was lost.", [])); }
        }

        public override void Turn(string why) => Done.TrySetResult(new AiAnswer<T>(null, null, why, []));

        public override void Abandon() => Done.TrySetCanceled();
    }

    /// <summary>How many requests are being answered now.</summary>
    public int Running { get { lock (_gate) return _running; } }

    /// <summary>How many requests are waiting for their turn.</summary>
    public int Waiting { get { lock (_gate) return _lanes.Sum(l => l.Count); } }

    public Task<AiAnswer<LlmResponse>> GenerateAsync(AiContext context, LlmRequest request, int priority, CancellationToken cancel) =>
        Submit(priority, cancel, token => gateway.GenerateAsync(context, request, token));

    public Task<AiAnswer<EmbeddingResponse>> EmbedAsync(AiContext context, EmbeddingRequest request, int priority, CancellationToken cancel) =>
        Submit(priority, cancel, token => gateway.EmbedAsync(context, request, token));

    private Task<AiAnswer<T>> Submit<T>(int priority, CancellationToken cancel, Func<CancellationToken, Task<AiAnswer<T>>> work) where T : class
    {
        if (!JobPriority.IsKnown(priority)) throw new ArgumentOutOfRangeException(nameof(priority), "Unknown priority.");
        if (cancel.IsCancellationRequested) return Task.FromCanceled<AiAnswer<T>>(cancel);
        Job<T> job;
        lock (_gate)
        {
            if (_disposed) return Task.FromResult(new AiAnswer<T>(null, null, "The AI helpers are shutting down.", []));
            var waiting = _lanes.Sum(l => l.Count);
            if (waiting >= maxWaiting)
            {
                // Too many are waiting. Someone less important than this request is turned away to make room; if there is nobody, this request is.
                var victimLane = Array.FindLastIndex(_lanes, l => l.Count > 0);
                if (victimLane <= priority) return Task.FromResult(new AiAnswer<T>(null, null, "The AI helpers are busy right now. Try again in a moment.", []));
                var victim = _lanes[victimLane].Last!.Value;
                Remove(victim);
                victim.Turn("The AI helpers are busy right now, and this was not urgent. Try again in a moment.");
            }

            job = new Job<T>(work) { Priority = priority, Cancel = CancellationTokenSource.CreateLinkedTokenSource(cancel, _stopping.Token) };
            job.Registration = cancel.Register(() => CancelJob(job));
            job.Node = _lanes[priority].AddLast(job);
        }

        Pump();
        return job.Done.Task;
    }

    private void CancelJob(Job job)
    {
        bool wasWaiting;
        lock (_gate)
        {
            wasWaiting = job.Node is not null;
            if (wasWaiting) Remove(job);
        }

        if (wasWaiting) job.Abandon();
        // A request that is already being answered is stopped through its own token (it is linked to the caller's), and ends in a cancelled task.
    }

    private void Remove(Job job)
    {
        if (job.Node is null) return;
        _lanes[job.Priority].Remove(job.Node);
        job.Node = null;
    }

    private void Pump()
    {
        while (true)
        {
            Job next;
            lock (_gate)
            {
                if (_disposed || _running >= maxRunning) return;
                var lane = Array.FindIndex(_lanes, l => l.Count > 0);
                if (lane < 0) return;
                next = _lanes[lane].First!.Value;
                Remove(next);
                _running++;
            }

            _ = Task.Run(async () =>
            {
                try { await next.RunAsync(); }
                finally
                {
                    next.Registration.Dispose();
                    next.Cancel.Dispose();
                    lock (_gate) _running--;
                    Pump();
                }
            });
        }
    }

    public void Dispose()
    {
        List<Job> abandoned = [];
        lock (_gate)
        {
            if (_disposed) return;
            _disposed = true;
            foreach (var lane in _lanes) { abandoned.AddRange(lane); lane.Clear(); }
            foreach (var job in abandoned) job.Node = null;
        }

        _stopping.Cancel();
        foreach (var job in abandoned) job.Abandon();
    }
}
