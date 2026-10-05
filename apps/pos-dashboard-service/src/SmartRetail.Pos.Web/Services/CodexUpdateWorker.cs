using Microsoft.Extensions.Options;
using SmartRetail.AI.Providers;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// Looks at Codex two minutes after the app starts and then every few hours (<see cref="CodexUpdateService.RunScheduledAsync"/>):
/// a newer release is installed by itself, at a quiet moment, unless the owner turned that off. When an AI task is running, it
/// tries again in ten minutes.
/// </summary>
public sealed class CodexUpdateWorker : BackgroundService
{
    private readonly CodexUpdateService _service;
    private readonly CodexUpdateOptions _options;
    private readonly ILogger<CodexUpdateWorker> _log;

    public CodexUpdateWorker(CodexUpdateService service, IOptions<CodexUpdateOptions> options, ILogger<CodexUpdateWorker> log)
    {
        _service = service;
        _options = options.Value;
        _log = log;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            await Task.Delay(TimeSpan.FromSeconds(Math.Max(1, _options.FirstLookSeconds)), stoppingToken);
            var every = TimeSpan.FromSeconds(Math.Max(5, _options.EverySeconds));
            while (!stoppingToken.IsCancellationRequested)
            {
                var next = CodexUpdateSchedule.Next(CodexUpdateOutcome.Unknown, every);
                try
                {
                    var result = await _service.RunScheduledAsync(stoppingToken);
                    next = CodexUpdateSchedule.Next(result.Outcome, every);
                }
                catch (Exception ex) when (ex is not OperationCanceledException)
                {
                    _log.LogWarning(ex, "Looking at Codex failed.");
                }

                await Task.Delay(next, stoppingToken);
            }
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
            // The app is closing.
        }
    }
}
