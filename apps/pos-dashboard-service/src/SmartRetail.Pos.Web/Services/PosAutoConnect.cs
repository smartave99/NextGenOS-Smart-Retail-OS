using Microsoft.Data.SqlClient;
using SmartRetail.AI.Data;
using SmartRetail.AI.Settings;
using SmartRetail.Pos.Data;

namespace SmartRetail.Pos.Web.Services;

/// <summary>How the app found its data, for the header and the notice shown when nothing was found.</summary>
public sealed record PosConnectionReport(bool Automatic, bool Found, string Description, string CompanyName, IReadOnlyList<string> Steps)
{
    public static PosConnectionReport Configured(bool sqlServer) => new(false, sqlServer, "", "", Array.Empty<string>());
}

/// <summary>
/// Pos:Mode = Auto. Uses the database the AI side panel is connected to, if it still answers; otherwise searches
/// this PC the way the side panel does (the POS's own settings files, then every SQL Server on the PC). Falls
/// back to the demo shop when nothing is found. Only reads.
/// </summary>
public static class PosAutoConnect
{
    public static async Task<(PosDataOptions Options, PosConnectionReport Report)> ResolveAsync(
        PosDataOptions configured, string aiSettingsFile, CancellationToken ct)
    {
        if (configured.Mode != PosDataMode.Auto)
        {
            return (configured, PosConnectionReport.Configured(configured.Mode == PosDataMode.SqlServer));
        }

        var settings = new SettingsStore(aiSettingsFile).Load();
        var secrets = new SecretStore(() => settings, OperatingSystem.IsWindows() ? new DpapiSecretProtector() : new NoSecretProtector());
        var database = settings.Database;
        var password = secrets.Get(SecretNames.DatabasePassword);
        var savedLogin = !database.UseWindowsAuthentication && !string.IsNullOrWhiteSpace(database.UserName) && !string.IsNullOrEmpty(password)
            ? new SqlLogin(database.UserName, password, $"the side panel's login \"{database.UserName.Trim()}\"")
            : null;
        var sidePanelReady = !string.IsNullOrWhiteSpace(database.Server) && !string.IsNullOrWhiteSpace(database.Database);

        if (sidePanelReady && (database.UseWindowsAuthentication || savedLogin is not null))
        {
            var target = new SqlTarget(database.Server, database.Database, database.UseWindowsAuthentication ? SqlLogin.Windows : savedLogin);
            if (await AnswersAsync(target, ct) is { } company)
            {
                return (Live(configured, target), new PosConnectionReport(true, true,
                    $"{target.Database} on {target.Server}, as set up in the AI side panel", company, Array.Empty<string>()));
            }
        }

        var finder = new PosDatabaseFinder(new WindowsPosMachine(), target => new SqlClientQueryExecutor(ConnectionString(target, 5)));
        var search = await finder.FindAsync(new PosSearchHints
        {
            PosFolder = database.PosFolder ?? "",
            Server = sidePanelReady ? database.Server : "",
            Login = savedLogin,
        }, ct);

        if (search.Best is { } best)
        {
            var target = new SqlTarget(best.Server, best.Database, best.Login);
            return (Live(configured, target), new PosConnectionReport(true, true, best.Describe(), best.CompanyName, search.Steps));
        }

        return (new PosDataOptions { Mode = PosDataMode.Demo, CommandTimeoutSeconds = configured.CommandTimeoutSeconds },
            new PosConnectionReport(true, false, "", "", search.Steps));
    }

    public static string ConnectionString(SqlTarget target, int connectTimeoutSeconds = 15)
    {
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = target.Server,
            InitialCatalog = target.Database,
            IntegratedSecurity = target.Login.UseWindowsAuthentication,
            ApplicationName = "Smart Retail POS",
            ConnectTimeout = connectTimeoutSeconds,
            // Like the POS itself: a shop's SQL Server usually has no certificate a PC would trust.
            Encrypt = SqlConnectionEncryptOption.Optional,
            TrustServerCertificate = true,
        };

        if (!target.Login.UseWindowsAuthentication)
        {
            builder.UserID = target.Login.UserName;
            builder.Password = target.Login.Password;
        }

        return builder.ConnectionString;
    }

    private static PosDataOptions Live(PosDataOptions configured, SqlTarget target) => new()
    {
        Mode = PosDataMode.SqlServer,
        ConnectionString = ConnectionString(target),
        CommandTimeoutSeconds = configured.CommandTimeoutSeconds,
    };

    /// <summary>The shop's name ("" if the POS has none) when the database answers as a POS database; otherwise null.</summary>
    private static async Task<string?> AnswersAsync(SqlTarget target, CancellationToken ct)
    {
        var executor = new SqlClientQueryExecutor(ConnectionString(target, 5));
        try
        {
            await executor.QueryAsync("SELECT COUNT_BIG(*) FROM dbo.InvoiceInfo", null!, 1, ct);
        }
        catch (QueryExecutionException)
        {
            return null;
        }

        try
        {
            var company = await executor.QueryAsync("SELECT TOP (1) RTRIM(CompanyName) FROM dbo.Company ORDER BY ID", null!, 1, ct);
            return company.Rows.Count > 0 ? Convert.ToString(company.Rows[0][0])?.Trim() ?? "" : "";
        }
        catch (QueryExecutionException)
        {
            // The name is only for the header.
            return "";
        }
    }
}
