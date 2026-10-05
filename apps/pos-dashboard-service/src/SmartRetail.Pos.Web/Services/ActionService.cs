using System.Collections.Concurrent;
using System.Text.Json;
using System.Text.Json.Serialization;
using SmartRetail.AI.Memory;
using SmartRetail.AI.Storage;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Actions;
using SmartRetail.Pos.Core.Analytics;

namespace SmartRetail.Pos.Web.Services;

/// <summary>An action the AI heard of in a chat, waiting for the owner to track it or not.</summary>
public sealed record SuggestedAction
{
    public string Id { get; init; } = "";
    public string Title { get; init; } = "";
    public ActionKind Kind { get; init; }
    public DateOnly Start { get; init; }
    public DateOnly? End { get; init; }
    public decimal Cost { get; init; }

    /// <summary>Product names as the owner said them; none for the whole shop.</summary>
    public IReadOnlyList<string> Products { get; init; } = Array.Empty<string>();
    public string Expected { get; init; } = "";
    public DateTime At { get; init; }
}

/// <summary>Everything in actions.json.</summary>
public sealed record ActionBook
{
    public List<ShopAction> Actions { get; init; } = new();
    public List<SuggestedAction> Suggested { get; init; } = new();
}

/// <summary>
/// What the shop tried to sell more and what it did to sales: the decision ledger. Kept in the data folder's Memory
/// folder beside what the assistant remembers, never in the POS. Actions are entered by the owner, or heard in a
/// chat and tracked when the owner says so. Their figures are read from the POS, read-only, and the lesson can be
/// kept in memory.
/// </summary>
public sealed class ActionService
{
    public const string FileName = "actions.json";

    /// <summary>At most this many actions heard in chats wait at a time; the oldest go.</summary>
    public const int MaxSuggested = 10;

    private static readonly TimeSpan KeepResultsFor = TimeSpan.FromMinutes(10);

    private static readonly JsonSerializerOptions Json = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() },
    };

    private readonly StorageService _storage;
    private readonly ISalesFactsRepository _facts;
    private readonly MemoryService _memory;
    private readonly TimeProvider _clock;
    private readonly ILogger<ActionService> _log;
    private readonly object _gate = new();
    private readonly ConcurrentDictionary<string, (DateTime At, ActionResult Result)> _results = new();

    public ActionService(StorageService storage, ISalesFactsRepository facts, MemoryService memory, TimeProvider clock, ILogger<ActionService> log)
    {
        _storage = storage;
        _facts = facts;
        _memory = memory;
        _clock = clock;
        _log = log;
    }

    /// <summary>An action added, changed or removed, or one heard in a chat.</summary>
    public event Action? Changed;

    public string Path => System.IO.Path.Combine(DataFolders.Memory(_storage.DataFolder), FileName);

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

    public DateOnly Today => DateOnly.FromDateTime(Now);

    public ActionBook Load()
    {
        lock (_gate)
        {
            return Read();
        }
    }

    /// <summary>Saves a new action; null when saved, else why not.</summary>
    public string? Add(ShopAction action)
    {
        ArgumentNullException.ThrowIfNull(action);
        return Write(book =>
        {
            var clean = Clean(action) with { Id = NewId(), Added = Now };
            if (clean.Problem() is { } problem)
            {
                return problem;
            }

            book.Actions.Add(clean);
            return null;
        });
    }

    /// <summary>Tracks an action heard in a chat, as the owner checked it on the form.</summary>
    public string? Track(string suggestionId, ShopAction action)
    {
        ArgumentNullException.ThrowIfNull(action);
        return Write(book =>
        {
            var clean = Clean(action) with { Id = NewId(), Added = Now, Source = "Chat" };
            if (clean.Problem() is { } problem)
            {
                return problem;
            }

            book.Suggested.RemoveAll(s => s.Id == suggestionId);
            book.Actions.Add(clean);
            return null;
        });
    }

    public void Dismiss(string suggestionId) => Write(book =>
    {
        book.Suggested.RemoveAll(s => s.Id == suggestionId);
        return null;
    });

    /// <summary>Changes a saved action, e.g. ends it or cancels it; null when saved, else why not.</summary>
    public string? Update(string id, Func<ShopAction, ShopAction> change)
    {
        ArgumentNullException.ThrowIfNull(change);
        return Write(book =>
        {
            var index = book.Actions.FindIndex(a => a.Id == id);
            if (index < 0)
            {
                return "That action is not there any more.";
            }

            var changed = Clean(change(book.Actions[index])) with { Id = id };
            if (changed.Problem() is { } problem)
            {
                return problem;
            }

            book.Actions[index] = changed;
            return null;
        });
    }

    public void Remove(string id) => Write(book =>
    {
        book.Actions.RemoveAll(a => a.Id == id);
        return null;
    });

    /// <summary>What the AI heard in a chat: kept for the owner to track or not, once each.</summary>
    public void Suggest(IEnumerable<ActionSuggestion> heard)
    {
        ArgumentNullException.ThrowIfNull(heard);
        try
        {
            Write(book =>
            {
                foreach (var action in heard)
                {
                    var title = (action.Title ?? "").Trim();
                    if (title.Length == 0
                        || book.Actions.Any(a => string.Equals(a.Title, title, StringComparison.OrdinalIgnoreCase))
                        || book.Suggested.Any(s => string.Equals(s.Title, title, StringComparison.OrdinalIgnoreCase)))
                    {
                        continue;
                    }

                    book.Suggested.Add(new SuggestedAction
                    {
                        Id = NewId(),
                        Title = title.Length > ShopAction.MaxTitle ? title[..ShopAction.MaxTitle] : title,
                        Kind = ActionKinds.Parse(action.Kind),
                        Start = DateOnly.FromDateTime(action.Start),
                        End = action.End is { } end ? DateOnly.FromDateTime(end) : null,
                        Cost = Math.Max(0m, action.Cost),
                        Products = action.Products.ToList(),
                        Expected = action.Expected ?? "",
                        At = Now,
                    });
                }

                if (book.Suggested.Count > MaxSuggested)
                {
                    book.Suggested.RemoveRange(0, book.Suggested.Count - MaxSuggested);
                }

                return null;
            });
        }
        catch (InvalidOperationException ex)
        {
            _log.LogWarning(ex, "Keeping the actions heard in a chat failed.");
        }
    }

    /// <summary>What the shop is doing now or starts within a month, one line each, for the growth plan.</summary>
    public IReadOnlyList<string> DoingNow()
    {
        var today = Today;
        return Load().Actions
            .Where(a => !a.Cancelled && a.Start <= today.AddDays(30) && (a.End is not { } end || end >= today))
            .OrderBy(a => a.Start)
            .Select(a => $"{a.Title} ({a.Kind.Name().ToLowerInvariant()}, "
                + (a.End is { } end ? ActionMeasure.Dates(new DateRange(a.Start, end)) : "from " + a.Start.ToString("d MMM yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-IN")))
                + (a.Cost > 0 ? ", " + SmartRetail.Pos.Core.Money.FormatCompact(a.Cost) : "")
                + (a.IsWholeShop ? "" : ", for " + string.Join(", ", a.ProductNames))
                + ")")
            .ToList();
    }

    /// <summary>
    /// Keeps the owner's decision on a new product whose test was judged; null when kept, else why not. The result
    /// kept for the page is dropped, so its lesson shows at once.
    /// </summary>
    public string? DecideTest(string id, TestDecision decision, string? note)
    {
        var text = MemoryRules.Normalize(note ?? "");
        if (text.Length > ProductTest.MaxNote)
        {
            return $"Keep the note under {ProductTest.MaxNote} characters.";
        }

        var today = Today;
        if (Load().Actions.FirstOrDefault(a => a.Id == id)?.Test is not { } due)
        {
            return "That new product's test is not there any more.";
        }

        if (today < due.ReviewOn)
        {
            return $"Its test is judged on {Formats(due.ReviewOn)}: decide then.";
        }

        var problem = Update(id, action => action with { Test = action.Test! with { Decision = decision, DecisionNote = text, DecidedOn = today } });
        if (problem is null)
        {
            foreach (var key in _results.Keys.Where(key => key.StartsWith(id + "|", StringComparison.Ordinal)).ToList())
            {
                _results.TryRemove(key, out _);
            }
        }

        return problem;
    }

    private static string Formats(DateOnly day) => day.ToString("d MMM yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-IN"));

    /// <summary>The new products whose test was judged and waits for the owner's decision.</summary>
    public IReadOnlyList<ShopAction> TestsToDecide()
    {
        var today = Today;
        return Load().Actions
            .Where(a => !a.Cancelled && a.Test is { Decision: null } test && today >= test.ReviewOn)
            .OrderBy(a => a.Test!.ReviewOn)
            .ToList();
    }

    /// <summary>Keeps the lesson in memory, in its part about the shop, and notes it on the action.</summary>
    public string? KeepLesson(string id, string lesson)
    {
        var problem = _memory.Change(new MemoryChange { Op = MemoryOp.Add, Part = MemoryPart.Shop, NewText = lesson, Source = "Actions" });
        return problem ?? Update(id, action => action with { Lesson = MemoryRules.Normalize(lesson) });
    }

    /// <summary>
    /// What the figures say: the action's days so far against the same number of days before it, and, when the POS
    /// has bills from a year before, the same dates last year for the season. Kept for a few minutes.
    /// </summary>
    public async Task<ActionResult> MeasureAsync(ShopAction action, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(action);
        var today = Today;
        var key = string.Join("|", action.Id, today, action.Start, action.End, action.Cost, string.Join(",", action.ProductIds), action.Test);
        if (_results.TryGetValue(key, out var kept) && Now - kept.At < KeepResultsFor)
        {
            return kept.Result;
        }

        var result = await MeasureNowAsync(action, today, ct);
        _results[key] = (Now, result);
        return result;
    }

    private async Task<ActionResult> MeasureNowAsync(ShopAction action, DateOnly today, CancellationToken ct)
    {
        if (action.Test is { } test)
        {
            // A new product is judged by its own units, from its start to its review day.
            var last = today < test.ReviewOn ? today : test.ReviewOn;
            var lines = last < action.Start
                ? Array.Empty<ProductDaySales>()
                : (await _facts.GetFactsAsync(new DateRange(action.Start, last), ct)).ProductDays;
            var tested = ProductTests.Judge(action, lines, today);
            return new ActionResult
            {
                Verdict = tested.Verdict == TestVerdict.NotStarted ? ActionVerdict.Planned : ActionVerdict.TooEarly,
                Summary = tested.Summary,
                Lesson = tested.Lesson,
                Test = tested,
            };
        }

        if (ActionMeasure.DaysSoFar(action, today) is not { } days)
        {
            return ActionMeasure.Judge(action, today, null, null);
        }

        var span = await _facts.GetBillSpanAsync(ct);
        if (span is null)
        {
            return new ActionResult { Verdict = ActionVerdict.NothingToCompare, Summary = "The POS has no bills yet." };
        }

        var during = await FiguresAsync(days);
        if (days.Days < ActionMeasure.MinDays)
        {
            return ActionMeasure.Judge(action, today, during, null);
        }

        // Only whole windows the POS has bills for: a window cut short by the first bill would mislead.
        var before = days.Previous.From >= span.First ? await FiguresAsync(days.Previous) : null;
        var lastYear = ActionMeasure.YearBefore(days);
        WindowFigures? year = null, yearBefore = null;
        if (lastYear.Previous.From >= span.First)
        {
            year = await FiguresAsync(lastYear);
            yearBefore = await FiguresAsync(lastYear.Previous);
        }

        return ActionMeasure.Judge(action, today, during, before, year, yearBefore);

        // For some products, the bills with any of them are counted by the POS, so a bill with two counts once.
        async Task<WindowFigures> FiguresAsync(DateRange range) =>
            WindowFigures.From(await _facts.GetFactsAsync(range, ct), action.ProductIds,
                action.IsWholeShop ? null : await _facts.CountBillsWithAsync(range, action.ProductIds, ct));
    }

    private static ShopAction Clean(ShopAction action) => action with
    {
        Title = MemoryRules.Normalize(action.Title),
        Expected = MemoryRules.Normalize(action.Expected),
        ProductIds = action.ProductIds.Distinct().ToList(),
        ProductNames = action.ProductNames.ToList(),
    };

    private string? Write(Func<ActionBook, string?> change)
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

    private ActionBook Read()
    {
        var path = Path;
        if (!File.Exists(path))
        {
            return new ActionBook();
        }

        try
        {
            return JsonSerializer.Deserialize<ActionBook>(File.ReadAllText(path), Json) ?? new ActionBook();
        }
        catch (JsonException ex)
        {
            // A damaged file is kept aside, never overwritten, and the list starts again.
            _log.LogWarning(ex, "The actions file is damaged; it was kept as {File}.bad.", FileName);
            File.Copy(path, path + ".bad", overwrite: true);
            return new ActionBook();
        }
    }

    private static string NewId() => Guid.NewGuid().ToString("N")[..12];
}
