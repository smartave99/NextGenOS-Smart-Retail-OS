namespace NextGenOS.Hub.Import;

/// <summary>How serious a note in the match report is. Stored as these words (never as an enum name, which the name hiding would change).</summary>
public static class FindingLevels
{
    /// <summary>Good to know. Nothing to do.</summary>
    public const string Info = "info";

    /// <summary>A person should look at it: the move is allowed, but something may need a decision or a correction afterwards.</summary>
    public const string Look = "look";

    /// <summary>The move is not allowed until it is settled: something does not add up.</summary>
    public const string Blocking = "blocking";
}

/// <summary>The kind of number on a report line, so a screen can write it the right way (a count, money in the shop's currency, a quantity).</summary>
public static class LineUnits
{
    public const string Count = "count";
    public const string Money = "money";
    public const string Quantity = "quantity";
}

/// <summary>
/// One line of the match report: what the old system holds, next to what the Hub would hold after the move. Every number is whole units (a count, minor units of money, thousandths).
/// What the old system holds is <see cref="Old"/>. It becomes <see cref="Added"/> (moved now) + <see cref="Before"/> (moved by an earlier run, counted at the old system's present figure)
/// + <see cref="Skipped"/> (not moved, each with its reason in the report) + <see cref="Unexplained"/> (what nothing accounts for: it should be zero, up to <see cref="Tolerance"/>).
/// </summary>
public sealed record ReportLine(string Key, string Label, string Unit, long Old, long Added, long Before, long Skipped, long Unexplained, long Tolerance)
{
    /// <summary>What the Hub would hold after the move.</summary>
    public long Hub => Added + Before;

    /// <summary>Old minus Hub.</summary>
    public long Difference => Old - Hub;

    /// <summary>True when nothing is unexplained (within the rounding the line allows).</summary>
    public bool Matches => Math.Abs(Unexplained) <= Tolerance;
}

/// <summary>A note for the person: what was found, how serious, how many, and a few examples (never all of them).</summary>
public sealed record Finding(string Level, string Code, string Text, int Count, IReadOnlyList<string> Examples);

/// <summary>A row of the old system that was not moved, with the reason in plain words.</summary>
public sealed record SkippedRow(string Entity, string OldKey, string Name, string Reason);

/// <summary>
/// What a check found, before anything is written: the numbers side by side, the notes, and the rows left out. It holds no password and nothing secret (it is stored with the move).
/// </summary>
public sealed class MatchReport
{
    public string SourceKind { get; set; } = "";
    public string SourceId { get; set; } = "";
    public string Source { get; set; } = "";
    public List<ReportLine> Lines { get; set; } = [];
    public List<Finding> Findings { get; set; } = [];
    public List<SkippedRow> Skipped { get; set; } = [];

    /// <summary>What this move would add: items, customers, suppliers, stock moves, opening balances.</summary>
    public int ItemsToAdd { get; set; }
    public int CustomersToAdd { get; set; }
    public int SuppliersToAdd { get; set; }
    public int StockMovesToAdd { get; set; }
    public int BalancesToAdd { get; set; }

    /// <summary>A short code of the numbers and rows above. A move is only done when the numbers are the same as when the person read the report.</summary>
    public string Fingerprint { get; set; } = "";

    public bool HasBlocking => Findings.Any(f => f.Level == FindingLevels.Blocking) || Lines.Any(l => !l.Matches);

    public bool NothingToAdd => ItemsToAdd + CustomersToAdd + SuppliersToAdd + BalancesToAdd + StockMovesToAdd == 0;

    /// <summary>True when the move may go ahead: nothing blocks it and there is something to add.</summary>
    public bool CanImport => !HasBlocking && !NothingToAdd;
}

/// <summary>What a check read and found. The data stays in memory (it holds no password) so that the move writes exactly what the person read.</summary>
public sealed record ImportCheck(string SourceKind, string SourceId, string Describe, OldSystemData Data, MatchReport Report);

/// <summary>What a finished move added.</summary>
public sealed record ImportResult(long RunId, int Items, int Customers, int Suppliers, int StockMoves, int Balances, string BackupPath);

/// <summary>An earlier move, for the list on the screen.</summary>
public sealed record ImportRun(long Id, DateTimeOffset At, string? Who, string Source, int Items, int Customers, int Suppliers, int Balances);
