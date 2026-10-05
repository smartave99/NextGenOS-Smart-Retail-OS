namespace SmartRetail.Pos.Tests.SqlServer;

/// <summary>A test that needs a SQL Server; skipped unless POS_TEST_SQL holds a connection string.</summary>
public sealed class SqlServerFactAttribute : FactAttribute
{
    public SqlServerFactAttribute() => Skip = SqlServerTests.SkipReason;
}

/// <summary>A data-driven test that needs a SQL Server; skipped unless POS_TEST_SQL is set.</summary>
public sealed class SqlServerTheoryAttribute : TheoryAttribute
{
    public SqlServerTheoryAttribute() => Skip = SqlServerTests.SkipReason;
}

internal static class SqlServerTests
{
    /// <summary>Null when a SQL Server is configured for the tests.</summary>
    public static string? SkipReason =>
        string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(PosTestDatabase.EnvironmentVariable))
            ? $"Set {PosTestDatabase.EnvironmentVariable} to a SQL Server connection string to run this test."
            : null;
}
