namespace SmartRetail.Pos.Data;

public enum PosDataMode
{
    /// <summary>A built-in sample shop kept in memory. Nothing touches a database.</summary>
    Demo,

    /// <summary>Find the shop's POS database on this PC, read-only; the demo shop when none is found.
    /// The web app resolves this at startup (see PosAutoConnect) into <see cref="SqlServer"/> or <see cref="Demo"/>.</summary>
    Auto,

    /// <summary>The shop's existing POS database on SQL Server, read-only for now.</summary>
    SqlServer,
}

/// <summary>The "Pos" section of appsettings.json.</summary>
public sealed class PosDataOptions
{
    public const string SectionName = "Pos";

    public PosDataMode Mode { get; set; } = PosDataMode.Demo;

    /// <summary>
    /// Connection string for <see cref="PosDataMode.SqlServer"/>. Keep it out of source control: set it in
    /// the git-ignored appsettings.Local.json or the <c>Pos__ConnectionString</c> environment variable.
    /// </summary>
    public string? ConnectionString { get; set; }

    public int CommandTimeoutSeconds { get; set; } = 15;
}
