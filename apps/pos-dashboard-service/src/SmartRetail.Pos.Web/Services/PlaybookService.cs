using System.Collections.Concurrent;
using System.Text.Json;
using SmartRetail.AI.Memory;
using SmartRetail.AI.Providers;
using SmartRetail.AI.Settings;
using SmartRetail.Pos.Core;
using SmartRetail.Pos.Core.Actions;
using SmartRetail.Pos.Core.Analytics;

namespace SmartRetail.Pos.Web.Services;

/// <summary>Everything in playbooks.json: the saved playbooks, one for each kind of action, those waiting for the owner,
/// and those set aside.</summary>
public sealed class PlaybookBook
{
    public List<Playbook> Saved { get; set; } = new();

    public List<Playbook> Waiting { get; set; } = new();

    /// <summary>Entries that broke the rules when the file was read, e.g. one edited by hand: kept for the owner to delete,
    /// never shown to an AI.</summary>
    public List<SetAsidePlaybook> SetAside { get; set; } = new();
}

/// <summary>A playbook that cannot be used, as it was found, and why.</summary>
public sealed class SetAsidePlaybook
{
    public Playbook? Playbook { get; set; }

    public string Why { get; set; } = "";

    /// <summary>What the page shows for it: its name, or that it is empty.</summary>
    [System.Text.Json.Serialization.JsonIgnore]
    public string Title => Playbook is null ? "An empty entry" : MemoryRules.Normalize(Playbook.Title) is { Length: > 0 } title ? title : "An entry without a name";

    /// <summary>Names it for Delete; the same for the same entry every time the file is read.</summary>
    [System.Text.Json.Serialization.JsonIgnore]
    public string Key => Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(
        System.Text.Encoding.UTF8.GetBytes(JsonSerializer.Serialize(Playbook)))).Substring(0, 12).ToLowerInvariant();
}

/// <summary>
/// The shop's playbooks (<see cref="Playbook"/>, after Hermes Agent's skills). The AI writes one from an action and what
/// came of it, improving the kind's playbook when there is one, and it waits for the owner's Save; saved ones go into
/// every AI prompt with the memory (<see cref="MemoryService.Snapshot"/>). Kept in playbooks.json in the data folder's
/// Memory folder, never in the POS, and never written while the data folder moves.
/// </summary>
public sealed class PlaybookService
{
    public const string FileName = PlaybookFile.FileName;

    private static readonly JsonSerializerOptions Json = new() { WriteIndented = true };

    /// <summary>The kinds of action a playbook can be for: those the Actions page has.</summary>
    private static readonly HashSet<string> Kinds = ActionKinds.All.Select(kind => kind.Name()).ToHashSet(StringComparer.Ordinal);

    private readonly StorageService _storage;
    private readonly TimeProvider _clock;
    private readonly ILogger<PlaybookService> _log;
    private readonly Func<AiRequest, CancellationToken, Task<string>> _ask;
    private readonly object _gate = new();
    // The kinds whose playbook the AI is writing now, with the action each is written from: one at a time for a kind.
    private readonly ConcurrentDictionary<string, string> _writing = new();

    public PlaybookService(StorageService storage, AiEnvironment ai, TimeProvider clock, ILogger<PlaybookService> log)
        : this(storage, clock, log, async (request, ct) => (await ai.CreateRouter(AiJob.Playbook).CompleteAsync(request, ProviderIds.Auto, ct)).Text)
    {
    }

    /// <param name="ask">Asks the AI; a stand-in in tests.</param>
    internal PlaybookService(StorageService storage, TimeProvider clock, ILogger<PlaybookService> log, Func<AiRequest, CancellationToken, Task<string>> ask)
    {
        _storage = storage;
        _clock = clock;
        _log = log;
        _ask = ask;
    }

    /// <summary>A playbook written, saved, changed or removed, or one being written.</summary>
    public event Action? Changed;

    public string Path => PlaybookFile.PathIn(_storage.DataFolder);

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

    private DateTime Now => _clock.GetLocalNow().DateTime;

    public PlaybookBook Load()
    {
        lock (_gate)
        {
            return Read();
        }
    }

    /// <summary>Whether the AI is writing the playbook for this kind of action now, e.g. "Advertising".</summary>
    public bool IsWritingFor(string kind) => _writing.ContainsKey(kind);

    /// <summary>
    /// What the AI writes the playbook from: the action as the owner noted it and what the app worked out from the POS.
    /// Long numbers in the owner's words (a phone number in a title or a note) are masked, as on summary screens.
    /// </summary>
    public static PlaybookSource SourceFrom(ShopAction action, ActionResult result)
    {
        ArgumentNullException.ThrowIfNull(action);
        ArgumentNullException.ThrowIfNull(result);
        var test = action.Test;
        return new PlaybookSource
        {
            ActionId = action.Id,
            Title = PersonalData.MaskNumbers(action.Title),
            Kind = action.Kind.Name(),
            // A new product's test runs to its review day.
            Dates = (action.End ?? test?.ReviewOn) is { } end ? ActionMeasure.Dates(new DateRange(action.Start, end)) : "from " + Formats.Date(action.Start),
            Cost = action.Cost,
            Products = action.ProductNames.Select(PersonalData.MaskNumbers).ToList(),
            Hoped = PersonalData.MaskNumbers(test is null
                ? action.Expected
                : $"{Money.FormatQty(test.Hoped)} sold of {Money.FormatQty(test.Bought)} bought, by {Formats.Date(test.ReviewOn)}"),
            Result = result.Test?.Summary ?? result.Summary,
            Lesson = PersonalData.MaskNumbers(result.Test?.Lesson ?? result.Lesson),
            Decision = test?.Decision is { } decided
                ? PersonalData.MaskNumbers(decided.Name() + (test.DecisionNote.Length > 0 ? ": " + test.DecisionNote : ""))
                : "",
        };
    }

    /// <summary>The saved playbook for a kind of action, e.g. "Advertising"; null when there is none.</summary>
    public Playbook? Saved(string kind) => Load().Saved.FirstOrDefault(p => p.Kind == kind);

    /// <summary>The playbook waiting for the owner's Save for a kind of action; null when there is none.</summary>
    public Playbook? Waiting(string kind) => Load().Waiting.FirstOrDefault(p => p.Kind == kind);

    /// <summary>
    /// Has the AI write the playbook for the action's kind, improving the one waiting or saved for it; the playbook then
    /// waits for the owner's Save. Null when written, else why not.
    /// </summary>
    public async Task<string?> WriteAsync(PlaybookSource source, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(source);
        if (!_writing.TryAdd(source.Kind, source.ActionId))
        {
            return $"The playbook for {source.Kind.ToLowerInvariant()} is being written already.";
        }

        Changed?.Invoke();
        try
        {
            var book = Load();
            var existing = book.Waiting.FirstOrDefault(p => p.Kind == source.Kind) ?? book.Saved.FirstOrDefault(p => p.Kind == source.Kind);
            string answer;
            try
            {
                answer = await _ask(PlaybookRules.Request(source, existing), ct);
            }
            catch (AiProviderException ex)
            {
                return ex.Message;
            }

            var playbook = PlaybookRules.Parse(answer, source, existing, Now, out var problem);
            if (playbook is null)
            {
                _log.LogWarning("The AI's playbook was not kept: {Problem}", problem);
                return problem;
            }

            return Write(saved =>
            {
                saved.Waiting.RemoveAll(p => p.Kind == playbook.Kind);
                saved.Waiting.Add(playbook);
                return null;
            });
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or InvalidOperationException)
        {
            _log.LogWarning(ex, "Keeping a playbook failed.");
            return ex.Message;
        }
        finally
        {
            _writing.TryRemove(source.Kind, out _);
            Changed?.Invoke();
        }
    }

    /// <summary>
    /// Saves a waiting playbook, as it is or with the owner's name, when to use it and steps, in place of its kind's
    /// saved one. What it gave before stays as the figures said. Null when saved, else why not.
    /// </summary>
    public string? Save(string id, string? title = null, string? when = null, IEnumerable<string>? steps = null) => Write(book =>
    {
        var waiting = book.Waiting.FirstOrDefault(p => p.Id == id);
        if (waiting is null)
        {
            return "That playbook is not waiting any more.";
        }

        var playbook = Edited(waiting, title, when, steps);
        if (PlaybookRules.Check(playbook) is { } problem)
        {
            return problem;
        }

        book.Waiting.Remove(waiting);
        book.Saved.RemoveAll(p => p.Kind == playbook.Kind || p.Id == playbook.Id);
        book.Saved.Add(playbook);
        return null;
    });

    /// <summary>Drops a waiting playbook; the kind's saved one stays as it was.</summary>
    public void Discard(string id) => Write(book =>
    {
        book.Waiting.RemoveAll(p => p.Id == id);
        return null;
    });

    /// <summary>Changes a saved playbook's name, when to use it and steps; null when saved, else why not.</summary>
    public string? Update(string id, string title, string when, IEnumerable<string> steps) => Write(book =>
    {
        var index = book.Saved.FindIndex(p => p.Id == id);
        if (index < 0)
        {
            return "That playbook is not there any more.";
        }

        var playbook = Edited(book.Saved[index], title, when, steps);
        if (PlaybookRules.Check(playbook) is { } problem)
        {
            return problem;
        }

        book.Saved[index] = playbook;
        return null;
    });

    public void Delete(string id) => Write(book =>
    {
        book.Saved.RemoveAll(p => p.Id == id);
        return null;
    });

    /// <summary>Deletes an entry that was set aside (<see cref="SetAsidePlaybook.Key"/>).</summary>
    public void DeleteSetAside(string key) => Write(book =>
    {
        book.SetAside.RemoveAll(entry => entry.Key == key);
        return null;
    });

    /// <summary>The saved playbooks for every prompt, within their share; empty when there are none.</summary>
    public string Snapshot() => PlaybookRules.Snapshot(Load().Saved);

    private Playbook Edited(Playbook playbook, string? title, string? when, IEnumerable<string>? steps)
    {
        var edited = playbook.Copy();
        edited.Title = MemoryRules.Normalize(title ?? playbook.Title);
        edited.WhenToUse = MemoryRules.Normalize(when ?? playbook.WhenToUse);
        edited.Steps = (steps ?? playbook.Steps).Select(MemoryRules.Normalize).Where(s => s.Length > 0).ToList();
        edited.Updated = Now;
        return edited;
    }

    private string? Write(Func<PlaybookBook, string?> change)
    {
        string? problem;
        lock (_gate)
        {
            if (_storage.IsMoving)
            {
                throw new InvalidOperationException("The data folder is being moved. Try again when the move is done.");
            }

            var book = Read();
            problem = change(book);
            if (problem is null)
            {
                var path = Path;
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path)!);
                var temporary = path + ".tmp";
                File.WriteAllText(temporary, JsonSerializer.Serialize(book, Json));
                File.Move(temporary, path, overwrite: true);
            }
        }

        if (problem is null)
        {
            Changed?.Invoke();
        }

        return problem;
    }

    private PlaybookBook Read()
    {
        var path = Path;
        if (!File.Exists(path))
        {
            return new PlaybookBook();
        }

        try
        {
            return Screen(JsonSerializer.Deserialize<PlaybookBook>(File.ReadAllText(path), Json));
        }
        catch (JsonException ex)
        {
            // A damaged file is kept aside, never overwritten, and the playbooks start again.
            _log.LogWarning(ex, "The playbooks file is damaged; it was kept as {File}.bad.", FileName);
            File.Copy(path, path + ".bad", overwrite: true);
            return new PlaybookBook();
        }
    }

    /// <summary>
    /// What a file, perhaps edited by hand, may give to the page and the prompts: every playbook that keeps the rules,
    /// with nothing missing in it; the rest is set aside with why. Nothing is lost, and nothing broken reaches an AI.
    /// </summary>
    internal static PlaybookBook Screen(PlaybookBook? found)
    {
        var book = new PlaybookBook { SetAside = (found?.SetAside ?? new()).Where(entry => entry is not null).ToList() };
        book.Saved = Screen(found?.Saved, book.SetAside);
        book.Waiting = Screen(found?.Waiting, book.SetAside);
        return book;
    }

    private static List<Playbook> Screen(List<Playbook>? playbooks, List<SetAsidePlaybook> setAside)
    {
        var kept = new List<Playbook>();
        var ids = new HashSet<string>(StringComparer.Ordinal);
        foreach (var found in playbooks ?? new List<Playbook>())
        {
            var playbook = found?.Copy();
            var why = playbook is null ? "It is empty."
                : playbook.Id.Length == 0 ? "It has no id."
                : !ids.Add(playbook.Id) ? "Another playbook has the same id."
                : !Kinds.Contains(playbook.Kind) ? "It is not for a kind of action that the Actions page has."
                : PlaybookRules.Check(playbook);
            if (why is null)
            {
                kept.Add(playbook!);
            }
            else
            {
                setAside.Add(new SetAsidePlaybook { Playbook = found, Why = why });
            }
        }

        return kept;
    }
}
