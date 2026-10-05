namespace SmartRetail.Pos.Core;

/// <summary>The Indian financial year, which runs from 1 April to 31 March.</summary>
public static class FinancialYear
{
    /// <summary>The calendar year in which the financial year containing <paramref name="date"/> starts.</summary>
    public static int StartYear(DateOnly date) => date.Month >= 4 ? date.Year : date.Year - 1;

    /// <summary>A short label such as "26-27" for 1 April 2026 – 31 March 2027.</summary>
    public static string ShortLabel(DateOnly date)
    {
        var start = StartYear(date);
        return $"{start % 100:00}-{(start + 1) % 100:00}";
    }
}
