namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// Deletes past chats older than six months when the app starts and twice a day, so they go even when no new chat is
/// kept, e.g. after the owner turned keeping chats off.
/// </summary>
public sealed class ChatHistoryCleaner : BackgroundService
{
    private static readonly TimeSpan Every = TimeSpan.FromHours(12);

    private readonly ChatHistoryService _chats;

    public ChatHistoryCleaner(ChatHistoryService chats) => _chats = chats;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Not while the app is starting.
        await Task.Yield();
        using var timer = new PeriodicTimer(Every);
        try
        {
            do
            {
                _chats.DeleteExpired();
            }
            while (await timer.WaitForNextTickAsync(stoppingToken));
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
            // The app is closing.
        }
    }
}
