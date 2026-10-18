using SmartRetail.AI.Assistant;
using SmartRetail.AI.Memory;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// Past chats for Ask AI, unless the owner turned keeping them off on the Memory page. The chat going on is kept after
/// every answer, as one past chat (under the chat's own key) saved again each time, so closing the app loses nothing,
/// even when it is stopped suddenly; a new chat starts another. A kept chat can be gone on with: the owner's choice on
/// the Past chats page, and the app does it by itself when it starts again soon after (<see cref="ResumeLatest"/>), so
/// that a discussion goes on after the app is closed and opened. Kept in the data folder's Memory\Chats folder, words
/// only, never in the POS, and never written while the data folder is being moved.
/// </summary>
public sealed class ChatHistoryService
{
    private readonly StorageService _storage;
    private readonly MemoryService _memory;
    private readonly ILogger<ChatHistoryService> _log;
    private readonly TimeProvider _clock;
    private readonly object _gate = new();

    /// <summary>What was kept of which chat: so that the same words are not written twice, and a chat that was only gone on with is not
    /// written again.</summary>
    private string? _keptKey;
    private string? _keptAs;

    public ChatHistoryService(StorageService storage, MemoryService memory, TimeProvider clock, ILogger<ChatHistoryService> log)
    {
        _storage = storage;
        _memory = memory;
        _log = log;
        _clock = clock;
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

    /// <summary>Keeps the chat going on, after an answer: as the same past chat each time (its <paramref name="key"/>), and only when it changed.</summary>
    public void KeepSoFar(IReadOnlyList<ChatMessage> messages, string key) => Keep(messages, key);

    /// <summary>Keeps a chat that ended (New chat, or the app closing).</summary>
    public void Keep(IReadOnlyList<ChatMessage> messages, string key)
    {
        var kept = false;
        try
        {
            lock (_gate)
            {
                var seen = Signature(messages);
                if (!_memory.Settings.KeepChats || (key == _keptKey && seen == _keptAs))
                {
                    return;
                }

                if (_storage.IsMoving)
                {
                    _log.LogWarning("The chat could not be kept while the data folder was being moved; it is kept after the next answer.");
                    return;
                }

                if (History.Save(messages, key) is not null)
                {
                    _keptKey = key;
                    _keptAs = seen;
                    kept = true;
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

    /// <summary>
    /// Goes on with a kept chat in the chat: its messages come back, under the key it was kept as, so that what is said next is kept in
    /// the same past chat, and the next question is answered with what was said before in its prompt. False when there is no such chat,
    /// or a question is being answered.
    /// </summary>
    public bool Resume(string id, Conversation chat)
    {
        if (chat.Busy || History.Get(id) is not { } saved || saved.Key.Length == 0)
        {
            return false;
        }

        return ResumeAs(saved, chat);
    }

    /// <summary>
    /// When the app starts, goes on with the latest kept chat if it was last gone on with within <paramref name="within"/>, so that a
    /// discussion is not lost to closing the app. The owner's New chat starts another. Nothing when keeping chats is off, or the chat
    /// going on already has messages.
    /// </summary>
    public bool ResumeLatest(Conversation chat, TimeSpan within)
    {
        if (!_memory.Settings.KeepChats || chat.Busy || chat.Messages.Count > 0)
        {
            return false;
        }

        var latest = History.Latest(1).FirstOrDefault();
        if (latest is null || latest.Key.Length == 0 || _clock.GetLocalNow().DateTime - latest.Ended > within)
        {
            return false;
        }

        return ResumeAs(latest, chat);
    }

    private bool ResumeAs(SavedChat saved, Conversation chat)
    {
        var messages = saved.ToMessages();
        lock (_gate)
        {
            // What comes back is what was kept: it is not written again until something new is said.
            _keptKey = saved.Key;
            _keptAs = Signature(messages);
        }

        chat.Resume(saved.Key, messages);
        return true;
    }

    /// <summary>Words from the kept chats that match what the owner asks to go back to; empty when none do. The chat going on is left out.</summary>
    public string Recall(string question, string exceptKey)
    {
        try
        {
            return _memory.Settings.KeepChats ? History.Recall(question, exceptKey) : "";
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            _log.LogWarning(ex, "Looking in the past chats failed.");
            return "";
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

    /// <summary>Gives a past chat a name of the owner's own (empty: back to the first question); false when there is no such chat or the name cannot be kept.</summary>
    public bool Rename(string id, string title) => Write(() => History.Rename(id, title));

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
