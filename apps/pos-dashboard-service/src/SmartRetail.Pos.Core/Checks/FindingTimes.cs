using System.Globalization;
using SmartRetail.Pos.Core.Abstractions;

namespace SmartRetail.Pos.Core.Checks;

/// <summary>A problem about prices or stock, and when this app first noticed it.</summary>
public sealed record SeenProblem
{
    /// <summary><see cref="Finding.Problem"/>.</summary>
    public string Problem { get; init; } = "";
    public DateTime At { get; init; }

    /// <summary>It was already there at the very first check, so when it arrived is not known.</summary>
    public bool AtStart { get; init; }
}

/// <summary>What the checks found each time: for every problem about prices or stock that is still there, when it was first seen.</summary>
public sealed record SeenProblems
{
    public IReadOnlyList<SeenProblem> Items { get; init; } = Array.Empty<SeenProblem>();
}

/// <summary>
/// When each finding happened, in words for the Fix now page. A finding about bills says the date and time of its bill: the POS
/// keeps only the date on a bill, and the time comes from its own log when it can be read (<see cref="BillTimes"/>; a bill typed in on a
/// later day has no time of sale, so only its date is said). Prices, MRPs and stock have no date in the POS at all, so for those it says
/// when this app first noticed the problem, and says plainly when it was already there at the very first check. Pure and tested.
/// </summary>
public static class FindingTimes
{
    private static readonly CultureInfo India = CultureInfo.GetCultureInfo("en-IN");

    /// <summary>
    /// The problems still there, each with when it was first seen: <paramref name="kept"/> (null at the very first check, when every
    /// problem was already there) with the new ones added at <paramref name="now"/> and the ones that are gone dropped, so a problem
    /// that comes back later is new again.
    /// </summary>
    public static SeenProblems Seen(SeenProblems? kept, IEnumerable<string> problems, DateTime now)
    {
        ArgumentNullException.ThrowIfNull(problems);
        var before = (kept?.Items ?? Array.Empty<SeenProblem>())
            .Where(i => i.Problem.Length > 0)
            .GroupBy(i => i.Problem, StringComparer.Ordinal)
            .ToDictionary(g => g.Key, g => g.First(), StringComparer.Ordinal);
        var items = problems
            .Where(p => !string.IsNullOrEmpty(p))
            .Distinct(StringComparer.Ordinal)
            .Select(p => before.TryGetValue(p, out var known) ? known : new SeenProblem { Problem = p, At = now, AtStart = kept is null })
            .OrderBy(i => i.At).ThenBy(i => i.Problem, StringComparer.Ordinal)
            .ToList();
        return new SeenProblems { Items = items };
    }

    /// <summary>
    /// When <paramref name="finding"/> happened or was first noticed; empty when that is not known. <paramref name="savedAt"/> says when the
    /// POS saved bills (by bill id), from its log, for the ones known.
    /// </summary>
    public static string When(Finding finding, IReadOnlyDictionary<long, DateTime> savedAt, SeenProblems? seen)
    {
        ArgumentNullException.ThrowIfNull(finding);
        ArgumentNullException.ThrowIfNull(savedAt);

        if (finding.Kind == FindingKind.OwedLong)
        {
            return finding.Since is { } since ? "Oldest unpaid bill is from " + Date(since) : "";
        }

        if (finding.Kind == FindingKind.MissingBills && finding.Bills.Count == 2)
        {
            return Between(finding.Bills[0], finding.Bills[1], savedAt);
        }

        if (finding.Bills.Count > 0)
        {
            return Billed(finding.Bills, savedAt);
        }

        if (finding.Problem is { Length: > 0 } problem && seen?.Items.FirstOrDefault(i => i.Problem == problem) is { } item)
        {
            return item.AtStart
                ? "Already there when this app first checked, on " + Date(item.At)
                : "First noticed " + Date(item.At) + ", " + Time(item.At);
        }

        return "";
    }

    private static string Billed(IReadOnlyList<FindingBill> bills, IReadOnlyDictionary<long, DateTime> savedAt)
    {
        var ordered = bills.OrderByDescending(b => b.Day).ThenByDescending(b => b.Id).ToList();
        var latest = ordered[0];
        if (ordered.Count == 1)
        {
            return "Billed " + Moment(latest, savedAt);
        }

        var first = ordered[^1];
        var rest = first.Day == latest.Day ? $"{ordered.Count} bills that day" : "the first on " + Date(first.Day);
        return $"Latest bill {Moment(latest, savedAt)}; {rest}";
    }

    /// <summary>A bill number missing between two bills was made after the first and before the second.</summary>
    private static string Between(FindingBill one, FindingBill other, IReadOnlyDictionary<long, DateTime> savedAt)
    {
        var (before, after) = one.Id <= other.Id ? (one, other) : (other, one);
        var from = TimeOf(before, savedAt);
        var to = TimeOf(after, savedAt);
        if (before.Day == after.Day)
        {
            return from is { } a && to is { } b && a <= b
                ? $"Between {Time(a)} and {Time(b)} on {Date(before.Day)}"
                : "On " + Date(before.Day);
        }

        return from is { } start && to is { } end
            ? $"Between {Date(before.Day)}, {Time(start)} and {Date(after.Day)}, {Time(end)}"
            : $"Between {Date(before.Day)} and {Date(after.Day)}";
    }

    private static TimeOnly? TimeOf(FindingBill bill, IReadOnlyDictionary<long, DateTime> savedAt) =>
        savedAt.TryGetValue(bill.Id, out var saved) ? BillTimes.TimeOf(bill.Day, saved) : null;

    private static string Moment(FindingBill bill, IReadOnlyDictionary<long, DateTime> savedAt) =>
        TimeOf(bill, savedAt) is { } time ? Date(bill.Day) + ", " + Time(time) : Date(bill.Day);

    private static string Date(DateOnly day) => day.ToString("d MMM yyyy", India);

    private static string Date(DateTime at) => at.ToString("d MMM yyyy", India);

    private static string Time(TimeOnly time) => time.ToString("h:mm tt", India);

    private static string Time(DateTime at) => at.ToString("h:mm tt", India);
}
