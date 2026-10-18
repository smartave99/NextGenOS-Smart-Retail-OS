using SmartRetail.AI.Work;

namespace SmartRetail.Pos.Web.Services;

/// <summary>
/// The assistant's own plan (projects, tasks, reminders, notes) for every page and the chat: kept in the data folder's Memory folder (work.json), never in the POS,
/// changed one at a time, and never while the data folder is being moved.
/// </summary>
public sealed class WorkService : IWork
{
    private readonly StorageService _storage;
    private readonly ILogger<WorkService> _log;
    private readonly WorkStore _store;
    private readonly object _gate = new();

    public WorkService(StorageService storage, TimeProvider clock, ILogger<WorkService> log)
    {
        _storage = storage;
        _log = log;
        _store = new WorkStore(() => storage.DataFolder, () => clock.GetLocalNow().DateTime);
    }

    /// <summary>The plan changed: something saved, suggested, turned down or undone.</summary>
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

    public WorkBook Load()
    {
        try
        {
            return _store.Load();
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            _log.LogWarning(ex, "Reading the assistant's plan failed.");
            return new WorkBook();
        }
    }

    public string? Change(WorkChange change) => Write(() => _store.Change(change));

    public WorkProposal Propose(IEnumerable<WorkChange> changes, string summary, bool askFirst) =>
        Write(() => _store.Propose(changes, summary, askFirst));

    /// <summary>The owner's own plan made in one go (for example from a campaign template); all of it can be taken back with the returned group id.</summary>
    public WorkSaveResult AddPlan(IEnumerable<WorkChange> changes) => Write(() => _store.AddPlan(changes));

    /// <summary>Saves what the assistant suggested, as the owner approved it.</summary>
    public WorkSaveResult Approve(string proposalId) => Write(() => _store.Approve(proposalId));

    public void Reject(string proposalId) => Write(() =>
    {
        _store.Reject(proposalId);
        return true;
    });

    /// <summary>Takes back one change, or all the changes that one answer made; null when done, else why not.</summary>
    public string? Undo(string changeIdOrGroup) => Write(() => _store.Undo(changeIdOrGroup));

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
