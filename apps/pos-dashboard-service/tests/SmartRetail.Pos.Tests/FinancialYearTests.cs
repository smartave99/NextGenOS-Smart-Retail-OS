using SmartRetail.Pos.Core;

namespace SmartRetail.Pos.Tests;

public class FinancialYearTests
{
    [Theory]
    [InlineData(2026, 3, 31, 2025, "25-26")]
    [InlineData(2026, 4, 1, 2026, "26-27")]
    [InlineData(2026, 9, 24, 2026, "26-27")]
    [InlineData(2099, 12, 31, 2099, "99-00")]
    [InlineData(2000, 1, 1, 1999, "99-00")]
    public void Financial_year_runs_from_april_to_march(int year, int month, int day, int startYear, string label)
    {
        var date = new DateOnly(year, month, day);

        Assert.Equal(startYear, FinancialYear.StartYear(date));
        Assert.Equal(label, FinancialYear.ShortLabel(date));
    }
}
