using SmartRetail.AI.Assistant;
using SmartRetail.AI.Memory;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// Past chats for Ask AI, unless the owner turned keeping them off on the Memory page. The chat going on is kept after
/// every answer, as one past chat saved again each time, so closing the app loses nothing, even when it is stopped
/// suddenly; a new chat starts another. Kept in the data folder's Memory\Chats folder, words only, never in the POS,
/// and never written while the data folder is being moved.
/// </summary>
public sealed class ChatHistoryService
{
    private readonly StorageService _storage;
    private readonly MemoryService _memory;
    private readonly ILogger<ChatHistoryService> _log;
    private readonly object _gate = new();

    /// <summary>The past chat the chat going on is kept as, and what was kept of it.</summary>
    private string _key = ChatHistory.NewKey();
    private string? _keptAs;

    public ChatHistoryService(StorageService storage, MemoryService memory, TimeProvider clock, ILogger<ChatHistoryService> log)
    {
        _storage = storage;
        _memory = memory;
        _log = log;
        History = new ChatHistory(() => storage.DataFolder, () => clock.GetLocalNow().DateTime);
    }

    /// <summary>For reading: the latest chats, one chat, a search.</summary>
    public ChatHistory History { get; }

    /// <summary>A chat kept or deleted.</summary>
    public event Action? Changed;

    /// <summary>True for the moment a chat is being written; the Storage page waits for it before moving data.</summary>
    public bool IsWriting
    {
        get
        {
            if (!Monitor.TryEnter(_gate))
            {
                return true;
            }

            Monitor.Exit(_gate);
            return false;
        }
    }

    /// <summary>Keeps the chat going on, after an answer: as the same past chat each time, and only when it changed.</summary>
    public void KeepSoFar(IReadOnlyList<ChatMessage> messages) => Keep(messages, ended: false);

    /// <summary>Keeps a chat that ended (New chat, or the app closing); the next chat is another past chat.</summary>
    public void Keep(IReadOnlyList<ChatMessage> messages) => Keep(messages, ended: true);

    private void Keep(IReadOnlyList<ChatMessage> messages, bool ended)
    {
        var kept = false;
        try
        {
            lock (_gate)
            {
                try
                {
                    var seen = Signature(messages);
                    if (!_memory.Settings.KeepChats || seen == _keptAs)
                    {
                        return;
                    }

                    if (_storage.IsMoving)
                    {
                        _log.LogWarning("The chat could not be kept while the data folder was being moved; it is kept after the next answer.");
                        return;
                    }

                    if (History.Save(messages, _key) is not null)
                    {
                        _keptAs = seen;
                        kept = true;
                    }
                }
                finally
                {
                    if (ended)
                    {
                        _key = ChatHistory.NewKey();
                        _keptAs = null;
                    }
                }
            }
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            _log.LogWarning(ex, "Keeping a past chat failed.");
        }

        if (kept)
        {
            Changed?.Invoke();
        }
    }

    /// <summary>What was kept of the chat going on: its messages and their words, so the same is not written twice.</summary>
    private static string Signature(IReadOnlyList<ChatMessage> messages) =>
        messages.Count + "|" + string.Join("|", messages.Select(m => m.At.Ticks + ":" + (m.Text ?? "").Length));

    /// <summary>Deletes chats older than six months, unless the data folder is being moved; they are never shown
    /// either way.</summary>
    public void DeleteExpired()
    {
        try
        {
            lock (_gate)
            {
                if (_storage.IsMoving)
                {
                    return;
                }

                var deleted = History.DeleteExpired();
                if (deleted > 0)
                {
                    _log.LogInformation("Deleted {Count} files of past chats older than {Months} months.", deleted, ChatHistory.KeepMonths);
                }
            }
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            _log.LogWarning(ex, "Deleting old past chats failed.");
        }
    }

    public bool Delete(string id) => Write(() => History.Delete(id));

    public int DeleteAll() => Write(History.DeleteAll);

    private T Write<T>(Func<T> write)
    {
        T result;
        lock (_gate)
        {
            if (_storage.IsMoving)
            {
                throw new InvalidOperationException("The data folder is being moved. Try again when the move is done.");
            }

            result = write();
        }

        Changed?.Invoke();
        return result;
    }
}
