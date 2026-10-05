namespace SmartRetail.Pos.Core.Abstractions;

/// <summary>
/// The POS keeps only the date on a bill (<c>InvoiceInfo.InvoiceDate</c> is midnight), but its own log
/// (<c>Logs</c>) says when each bill was saved. A bill saved on its own date was made then; one saved on a later
/// day was typed in afterwards, so the time it was sold is not known.
/// </summary>
public static class BillTimes
{
    /// <summary>The time of day a bill dated <paramref name="day"/> was made, or null.</summary>
    public static TimeOnly? TimeOf(DateOnly day, DateTime? savedAt) =>
        savedAt is { } saved && DateOnly.FromDateTime(saved) == day ? TimeOnly.FromDateTime(saved) : null;

    public static bool EnteredLater(DateOnly day, DateTime? savedAt) =>
        savedAt is { } saved && DateOnly.FromDateTime(saved) > day;
}
