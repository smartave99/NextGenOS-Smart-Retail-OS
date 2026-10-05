using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using SmartRetail.AI.Storage;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Checks;

namespace SmartRetail.Pos.Web.Services;

/// <summary>A finding the owner meant, e.g. a clearance sale below cost: hidden until its figures change.</summary>
public sealed record OnPurposeNote
{
    public string Key { get; init; } = "";
    public FindingKind Kind { get; init; }
    public string Title { get; init; } = "";
    public DateTime At { get; init; }
    public string? Note { get; init; }
}

/// <summary>What the Fix now checks found last, less what the owner marked as on purpose.</summary>
public sealed record FixNowResult
{
    public IReadOnlyList<Finding> Open { get; init; } = Array.Empty<Finding>();

    /// <summary>Findings marked as on purpose, still there with the same figures.</summary>
    public IReadOnlyList<(Finding Finding, OnPurposeNote Note)> OnPurpose { get; init; } = Array.Empty<(Finding, OnPurposeNote)>();
    public DateTime CheckedAt { get; init; }

    /// <summary>Why the last check could not read the POS; the findings before it stay.</summary>
    public string? Problem { get; init; }

    public int FixNow => Open.Count(f => f.Level == FindingLevel.FixNow);
    public int CheckSoon => Open.Count(f => f.Level == FindingLevel.CheckSoon);
}

/// <summary>
/// The Fix now checks for every page: run at most once a minute, whoever asks, and shared, so the menu's count, the
/// Today page and the Fix now page agree. The owner's "on purpose" notes are kept in the data folder's Shop checks
/// folder, never in the POS. Each finding also says when it happened (<see cref="FindingTimes"/>): a bill's date and the time
/// from the POS log when it can be read, and for prices and stock, which the POS gives no date, when this app first noticed the
/// problem (<c>seen.json</c> beside the notes). Both only add words to a finding; nothing here writes to the POS.
/// </summary>
public sealed class FixNowService
{
    public static readonly TimeSpan FreshFor = TimeSpan.FromMinutes(1);

    /// <summary>Notes for findings gone for this long are dropped.</summary>
    private static readonly TimeSpan KeepGoneNotesFor = TimeSpan.FromDays(180);

    private const string NotesFileName = "on-purpose.json";
    private const string SeenFileName = "seen.json";

    /// <summary>A bill whose time was asked for and not found is asked for again after this long.</summary>
    private static readonly TimeSpan AskAgainAfter = TimeSpan.FromMinutes(10);

    /// <summary>Days of bills asked about at one check (the newest first): the others wait for the next, so a check stays quick.</summary>
    private const int MostDaysAsked = 8;

    private static readonly TimeSpan MostTimeAsking = TimeSpan.FromSeconds(10);

    private static readonly JsonSerializerOptions Json = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() },
    };

    private readonly IShopChecksRepository _checks;
    private readonly IInvoiceRepository _invoices;
    private readonly StorageService _storage;
    private readonly ShopOptions _shop;
    private readonly TimeProvider _clock;
    private readonly ILogger<FixNowService> _log;
    private readonly SemaphoreSlim _running = new(1, 1);
    private readonly object _notesGate = new();
    private IReadOnlyList<Finding> _findings = Array.Empty<Finding>();
    private DateTime _checkedAt;
    private string? _problem;
    private readonly Dictionary<long, DateTime> _savedAt = new();
    private readonly Dictionary<long, DateTime> _askedAbout = new();
    private SeenProblems? _seen;
    private string? _seenPath;
    private bool _seenUnsaved;

    public FixNowService(IShopChecksRepository checks, IInvoiceRepository invoices, StorageService storage, IOptions<ShopOptions> shop,
        TimeProvider clock, ILogger<FixNowService> log)
    {
        _checks = checks;
        _invoices = invoices;
        _storage = storage;
        _shop = shop.Value;
        _clock = clock;
        _log = log;
    }

    /// <summary>Something changed: a new check, or a note added or taken back.</summary>
    public event Action? Changed;

    public FixNowResult? Last { get; private set; }

    private DateTime Now => _clock.GetLocalNow().DateTime;

    private string NotesPath => Path.Combine(DataFolders.Checks(_storage.DataFolder), NotesFileName);

    private string SeenPath => Path.Combine(DataFolders.Checks(_storage.DataFolder), SeenFileName);

    /// <summary>The latest findings: the last check's when it is under a minute old, else a new one.</summary>
    public async Task<FixNowResult> CheckAsync(bool fresh = false, CancellationToken ct = default)
    {
        if (!fresh && Last is { } recent && Now - recent.CheckedAt < FreshFor)
        {
            return recent;
        }

        await _running.WaitAsync(ct).ConfigureAwait(false);
        FixNowResult result;
        try
        {
            if (!fresh && Last is { } meanwhile && Now - meanwhile.CheckedAt < FreshFor)
            {
                return meanwhile;
            }

            try
            {
                var facts = await _checks.LoadCheckFactsAsync(_invoices, DateOnly.FromDateTime(Now), _shop.PricesIncludeTax, ct).ConfigureAwait(false);
                var found = ShopChecks.Run(facts);
                await LookUpBillTimesAsync(found, ct).ConfigureAwait(false);
                var seen = NoteWhatIsSeen(found);
                _findings = found.Select(f => f with { When = FindingTimes.When(f, _savedAt, seen) }).ToList();
                _problem = null;
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                _log.LogWarning(ex, "Running the Fix now checks failed.");
                _problem = ex.Message;
            }

            _checkedAt = Now;
            result = Last = Compose();
        }
        finally
        {
            _running.Release();
        }

        Changed?.Invoke();
        return result;
    }

    /// <summary>Hides <paramref name="finding"/> until its figures change, e.g. a clearance sale meant below cost.</summary>
    public void MarkOnPurpose(Finding finding, string? note)
    {
        ArgumentNullException.ThrowIfNull(finding);
        RefuseWhileMoving();
        lock (_notesGate)
        {
            var current = _findings.Select(f => f.Key).ToHashSet(StringComparer.Ordinal);
            var notes = LoadNotes()
                .Where(n => n.Key != finding.Key)
                .Where(n => current.Contains(n.Key) || Now - n.At < KeepGoneNotesFor)
                .Append(new OnPurposeNote
                {
                    Key = finding.Key,
                    Kind = finding.Kind,
                    Title = finding.Title,
                    At = Now,
                    Note = string.IsNullOrWhiteSpace(note) ? null : note.Trim()[..Math.Min(note.Trim().Length, 200)],
                })
                .ToList();
            SaveNotes(notes);
            Last = Compose();
        }

        Changed?.Invoke();
    }

    /// <summary>Shows a finding marked as on purpose again.</summary>
    public void Undo(string key)
    {
        RefuseWhileMoving();
        lock (_notesGate)
        {
            SaveNotes(LoadNotes().Where(n => n.Key != key).ToList());
            Last = Compose();
        }

        Changed?.Invoke();
    }

    private FixNowResult Compose()
    {
        var notes = LoadNotes().ToDictionary(n => n.Key, StringComparer.Ordinal);
        return new FixNowResult
        {
            Open = _findings.Where(f => !notes.ContainsKey(f.Key)).ToList(),
            OnPurpose = _findings.Where(f => notes.ContainsKey(f.Key)).Select(f => (f, notes[f.Key])).ToList(),
            CheckedAt = _checkedAt,
            Problem = _problem,
        };
    }

    private IReadOnlyList<OnPurposeNote> LoadNotes()
    {
        try
        {
            var path = NotesPath;
            return File.Exists(path)
                ? JsonSerializer.Deserialize<List<OnPurposeNote>>(File.ReadAllText(path), Json) ?? new List<OnPurposeNote>()
                : Array.Empty<OnPurposeNote>();
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
        {
            _log.LogWarning(ex, "Reading the Fix now notes failed; showing every finding.");
            return Array.Empty<OnPurposeNote>();
        }
    }

    private void SaveNotes(IReadOnlyList<OnPurposeNote> notes)
    {
        var path = NotesPath;
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        var temporary = path + ".tmp";
        File.WriteAllText(temporary, JsonSerializer.Serialize(notes, Json));
        File.Move(temporary, path, overwrite: true);
    }

    /// <summary>
    /// When the POS saved the bills the findings are about, from its log (the bill list has it): the POS keeps only a bill's date. The
    /// bills of a day are asked for when a finding has a bill whose time is not known yet; a bill's time never changes, so it is kept, and
    /// one whose time was not there is asked for again after ten minutes. The lookup never stops the check: without it the findings show
    /// their dates only.
    /// </summary>
    private async Task LookUpBillTimesAsync(IReadOnlyList<Finding> found, CancellationToken ct)
    {
        try
        {
            var today = DateOnly.FromDateTime(Now);
            var wanted = found
                .SelectMany(f => f.Bills)
                .Where(b => !_savedAt.ContainsKey(b.Id))
                .Where(b => !_askedAbout.TryGetValue(b.Id, out var asked) || Now - asked >= AskAgainAfter)
                .DistinctBy(b => b.Id)
                .ToList();
            var days = wanted.Select(b => b.Day).Distinct().OrderDescending().Take(MostDaysAsked).ToList();
            using var limit = CancellationTokenSource.CreateLinkedTokenSource(ct);
            limit.CancelAfter(MostTimeAsking);
            try
            {
                foreach (var day in days)
                {
                    var page = await _invoices.SearchAsync(new BillQuery { From = day, To = day, Take = BillQuery.MaxTake }, limit.Token).ConfigureAwait(false);
                    foreach (var bill in page.Items)
                    {
                        if (bill.SavedAt is { } saved)
                        {
                            _savedAt[bill.Id] = saved;
                        }
                    }

                    foreach (var bill in wanted.Where(b => b.Day == day))
                    {
                        _askedAbout[bill.Id] = Now;
                    }
                }
            }
            catch (OperationCanceledException) when (!ct.IsCancellationRequested)
            {
                _log.LogInformation("Asking when the bills in Fix now were saved took too long; their dates are shown without a time for now.");
            }

            foreach (var gone in _savedAt.Where(kept => DateOnly.FromDateTime(kept.Value) < today.AddDays(-KeepBillTimesDays)).Select(kept => kept.Key).ToList())
            {
                _savedAt.Remove(gone);
            }

            foreach (var gone in _askedAbout.Where(asked => Now - asked.Value > TimeSpan.FromDays(KeepBillTimesDays)).Select(asked => asked.Key).ToList())
            {
                _askedAbout.Remove(gone);
            }
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            _log.LogInformation(ex, "Asking when the bills in Fix now were saved failed; their dates are shown without a time.");
        }
    }

    /// <summary>Bills older than the checks look at (30 days) are not kept.</summary>
    private const int KeepBillTimesDays = CheckFactsLoader.BillDays + 15;

    /// <summary>
    /// Adds the problems about prices and stock found now to what was kept (<c>seen.json</c>): the new ones are first noticed now, the
    /// ones gone are forgotten. The first check there ever is finds every problem already there. The file is not written while the data
    /// folder moves; it is written at the next check.
    /// </summary>
    private SeenProblems NoteWhatIsSeen(IReadOnlyList<Finding> found)
    {
        var path = SeenPath;
        if (_seenPath != path)
        {
            // The first check, or another data folder was chosen: what that folder kept (nothing, at the very first check).
            _seen = LoadSeen(path);
            _seenPath = path;
        }

        var next = FindingTimes.Seen(_seen, found.Select(f => f.Problem).OfType<string>(), Now);
        if (_seen is null || !SameSeen(_seen, next))
        {
            _seenUnsaved = true;
        }

        _seen = next;
        if (_seenUnsaved && !_storage.IsMoving)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path)!);
                var temporary = path + ".tmp";
                File.WriteAllText(temporary, JsonSerializer.Serialize(next, Json));
                File.Move(temporary, path, overwrite: true);
                _seenUnsaved = false;
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                _log.LogWarning(ex, "Saving when the Fix now problems were first noticed failed; it is tried again at the next check.");
            }
        }

        return next;
    }

    private SeenProblems? LoadSeen(string path)
    {
        try
        {
            return File.Exists(path) ? JsonSerializer.Deserialize<SeenProblems>(File.ReadAllText(path), Json) : null;
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
        {
            _log.LogWarning(ex, "Reading when the Fix now problems were first noticed failed; counting from now.");
            return null;
        }
    }

    private static bool SameSeen(SeenProblems a, SeenProblems b) =>
        a.Items.Count == b.Items.Count && a.Items.Zip(b.Items).All(pair => pair.First == pair.Second);

    private void RefuseWhileMoving()
    {
        if (_storage.IsMoving)
        {
            throw new InvalidOperationException("The data folder is being moved. Try again when the move is done.");
        }
    }
}
