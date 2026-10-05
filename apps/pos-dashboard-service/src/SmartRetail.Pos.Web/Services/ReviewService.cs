using System.Text.Json;
using System.Text.Json.Serialization;
using SmartRetail.AI.Storage;
using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Core.Review;

namespace SmartRetail.Pos.Web.Services;

/// <summary>A week the owner marked as reviewed.</summary>
public sealed record ReviewedWeek(DateOnly Monday, DateTime At);

/// <summary>Everything in decisions.json.</summary>
public sealed record DecisionBook
{
    public List<AlertDecision> Decisions { get; init; } = new();
    public List<ReviewedWeek> Reviewed { get; init; } = new();
}

/// <summary>The weekly review as it stands now.</summary>
/// <param name="YearBefore">The same weekdays a year before; null when the POS has no bills then.</param>
/// <param name="Alerts">What the rules recommend now and the owner has not decided.</param>
/// <param name="Decisions">The owner's decisions, newest first, with their outcomes once due.</param>
/// <param name="Reviewed">When the week was marked as reviewed; null while it is not.</param>
public sealed record ReviewData(
    DateRange Week,
    SalesTotals ThisWeek,
    SalesTotals WeekBefore,
    SalesTotals? YearBefore,
    IReadOnlyList<ShopAlert> Alerts,
    IReadOnlyList<AlertDecision> Decisions,
    DateTime? Reviewed);

/// <summary>
/// The Monday review: last week against the week before and the same week a year before, the stock-out and dead-stock
/// alerts the rules raise, and the owner's decision on each, whose outcome is judged later from the POS's figures (the
/// plan's decision events). Decisions and reviewed weeks are kept in the data folder's Memory folder, never in the POS;
/// the POS is only read.
/// </summary>
public sealed class ReviewService
{
    public const string FileName = "decisions.json";

    /// <summary>Decisions kept at most; the oldest go.</summary>
    public const int MaxDecisions = 500;

    private static readonly JsonSerializerOptions Json = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() },
    };

    private readonly StorageService _storage;
    private readonly ISalesFactsRepository _facts;
    private readonly TimeProvider _clock;
    private readonly ILogger<ReviewService> _log;
    private readonly object _gate = new();

    public ReviewService(StorageService storage, ISalesFactsRepository facts, TimeProvider clock, ILogger<ReviewService> log)
    {
        _storage = storage;
        _facts = facts;
        _clock = clock;
        _log = log;
    }

    /// <summary>A decision taken or a week marked as reviewed.</summary>
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

    public DecisionBook Load()
    {
        lock (_gate)
        {
            return Read();
        }
    }

    /// <summary>The review for today: last week's figures, the open alerts and every decision, with outcomes now due.
    /// With <paramref name="judgeDue"/> off nothing is written: the owner's live view only reads it.</summary>
    public async Task<ReviewData> LoadAsync(CancellationToken ct, bool judgeDue = true)
    {
        var today = Today;
        var week = ReviewWeeks.LastWeek(today);
        var products = await _facts.GetProductsAsync(ct);
        var thisWeek = await _facts.GetFactsAsync(week, ct);
        var weekBefore = await _facts.GetFactsAsync(week.Previous, ct);
        var report = SalesAnalysis.Analyse(thisWeek, weekBefore, products);
        var yearFacts = await _facts.GetFactsAsync(ReviewWeeks.YearBefore(week), ct);
        var yearBefore = yearFacts.Days.Any(d => d.Bills > 0)
            ? SalesAnalysis.Analyse(yearFacts, new SalesFacts { Range = ReviewWeeks.YearBefore(week).Previous }, products).Current
            : null;

        if (judgeDue)
        {
            try
            {
                await JudgeDueAsync(ct);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or InvalidOperationException)
            {
                _log.LogWarning(ex, "Saving the decisions' outcomes failed.");
            }
        }

        var book = Load();
        var alerts = ShopAlerts.Find(await _facts.GetFactsAsync(DateRange.Ending(today, ShopAlerts.DeadAfterDays), ct), products, today);

        return new ReviewData(
            week,
            report.Current,
            report.Previous,
            yearBefore,
            AlertDecisions.Open(alerts, book.Decisions, today),
            book.Decisions.OrderByDescending(d => d.Decided).ToList(),
            book.Reviewed.FirstOrDefault(r => r.Monday == week.From)?.At);
    }

    /// <summary>
    /// Judges the decisions whose review day came, from the POS, and keeps what came of them (<see
    /// cref="AlertDecisions.Outcome"/>). <see cref="ReviewWorker"/> does it every hour, so while the app runs each is
    /// judged on its review day itself. Nothing is judged while the data folder moves. Gives how many were judged.
    /// </summary>
    public async Task<int> JudgeDueAsync(CancellationToken ct)
    {
        var today = Today;
        var due = Load().Decisions.Where(d => d.Outcome is null && today >= d.ReviewOn).ToList();
        if (due.Count == 0 || _storage.IsMoving)
        {
            return 0;
        }

        var catalog = (await _facts.GetProductsAsync(ct)).GroupBy(p => p.Id).ToDictionary(g => g.Key, g => g.First());
        var sales = await _facts.GetFactsAsync(new DateRange(due.Min(d => DateOnly.FromDateTime(d.Decided)), due.Max(d => d.ReviewOn)), ct);
        var outcomes = due.ToDictionary(d => d.Id, d =>
        {
            // Sold from the day of the decision to its review day, never after.
            var decided = DateOnly.FromDateTime(d.Decided);
            var sold = sales.ProductDays.Where(p => p.ProductId == d.ProductId && p.Day >= decided && p.Day <= d.ReviewOn).Sum(p => p.Qty);
            return AlertDecisions.Outcome(d, catalog.GetValueOrDefault(d.ProductId), sold, today);
        });

        var judged = 0;
        Write(saved =>
        {
            for (var i = 0; i < saved.Decisions.Count; i++)
            {
                if (saved.Decisions[i].Outcome is null && outcomes.TryGetValue(saved.Decisions[i].Id, out var outcome) && outcome is not null)
                {
                    saved.Decisions[i] = saved.Decisions[i] with { Outcome = outcome.Text, OutcomeOn = today, WentWell = outcome.WentWell };
                    judged++;
                }
            }

            return null;
        });
        return judged;
    }

    /// <summary>Keeps the owner's decision on an alert; null when kept, else why not.</summary>
    public string? Decide(ShopAlert alert, DecisionChoice choice, string? note)
    {
        ArgumentNullException.ThrowIfNull(alert);
        if (AlertDecisions.Problem(choice, note) is { } problem)
        {
            return problem;
        }

        return Write(book =>
        {
            book.Decisions.Add(AlertDecisions.Decide(alert, choice, note, Now, Guid.NewGuid().ToString("N")[..12]));
            if (book.Decisions.Count > MaxDecisions)
            {
                book.Decisions.RemoveRange(0, book.Decisions.Count - MaxDecisions);
            }

            return null;
        });
    }

    /// <summary>Marks the week as reviewed.</summary>
    public void MarkReviewed(DateRange week) => Write(book =>
    {
        if (!book.Reviewed.Any(r => r.Monday == week.From))
        {
            book.Reviewed.Add(new ReviewedWeek(week.From, Now));
        }

        return null;
    });

    /// <summary>Whether the owner reviewed last week already (for the reminder on Today).</summary>
    public bool LastWeekReviewed()
    {
        var monday = ReviewWeeks.LastWeek(Today).From;
        return Load().Reviewed.Any(r => r.Monday == monday);
    }

    private string? Write(Func<DecisionBook, string?> change)
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

    private DecisionBook Read()
    {
        var path = Path;
        if (!File.Exists(path))
        {
            return new DecisionBook();
        }

        try
        {
            return JsonSerializer.Deserialize<DecisionBook>(File.ReadAllText(path), Json) ?? new DecisionBook();
        }
        catch (JsonException ex)
        {
            // A damaged file is kept aside, never overwritten, and the log starts again.
            _log.LogWarning(ex, "The decisions file is damaged; it was kept as {File}.bad.", FileName);
            File.Copy(path, path + ".bad", overwrite: true);
            return new DecisionBook();
        }
    }
}
