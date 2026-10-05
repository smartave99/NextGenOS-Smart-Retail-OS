using SmartRetail.AI.Memory;
using SmartRetail.AI.Settings;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// The assistant's memory for every page and the chat: kept in the data folder's Memory folder, never in the POS,
/// changed one at a time, and never while the data folder is being moved.
/// </summary>
public sealed class MemoryService : IMemory
{
    private readonly StorageService _storage;
    private readonly AiEnvironment _ai;
    private readonly ILogger<MemoryService> _log;
    private readonly MemoryStore _store;
    private readonly PlaybookService? _playbooks;
    private readonly object _gate = new();

    /// <param name="playbooks">The shop's playbooks, which go into every prompt with the memory.</param>
    public MemoryService(StorageService storage, AiEnvironment ai, TimeProvider clock, ILogger<MemoryService> log, PlaybookService? playbooks = null)
    {
        _storage = storage;
        _ai = ai;
        _log = log;
        _playbooks = playbooks;
        _store = new MemoryStore(() => storage.DataFolder, () => clock.GetLocalNow().DateTime);
    }

    /// <summary>Memory changed: an entry saved or removed, a suggestion waiting, saved or turned down.</summary>
    public event Action? Changed;

    public string Path => _store.Path;

    /// <summary>True for the moment a change is being written; the Storage page waits for it before moving data.</summary>
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

    public MemoryBook Load()
    {
        try
        {
            return _store.Load();
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            _log.LogWarning(ex, "Reading the assistant's memory failed.");
            return new MemoryBook();
        }
    }

    /// <summary>All of memory, then the shop's playbooks, for a prompt; empty when there is nothing yet.</summary>
    public string Snapshot() => MemoryRules.Snapshot(Load()) + PlaybookSnapshot();

    private string PlaybookSnapshot()
    {
        try
        {
            return _playbooks?.Snapshot() ?? "";
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            _log.LogWarning(ex, "Reading the playbooks failed.");
            return "";
        }
    }

    public string? Change(MemoryChange change) => Write(() => _store.Change(change));

    public IReadOnlyList<MemoryOutcome> Propose(IEnumerable<MemoryChange> changes, bool askFirst) =>
        Write(() => _store.Propose(changes, askFirst));

    /// <summary>Saves a waiting suggestion, as it is or as the owner edited it; null when saved, else why not.</summary>
    public string? Approve(string id, string? editedText = null) => Write(() => _store.Approve(id, editedText));

    public void Reject(string id) => Write(() =>
    {
        _store.Reject(id);
        return true;
    });

    public string? Undo(string id) => Write(() => _store.Undo(id));

    public void RemoveSetAside(MemoryPart part, string text) => Write(() =>
    {
        _store.RemoveSetAside(part, text);
        return true;
    });

    public MemorySettings Settings => _ai.LoadSettings().Memory;

    public void SaveSettings(Action<MemorySettings> change)
    {
        ArgumentNullException.ThrowIfNull(change);
        var store = new SettingsStore(_ai.SettingsFile);
        var all = store.Load();
        change(all.Memory);
        store.Save(all);
        Changed?.Invoke();
    }

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
