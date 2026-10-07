using System.Globalization;
using System.Security;
using Microsoft.Data.SqlClient;

namespace NextGenOS.Hub.Import;

/// <summary>
/// Reads the older Windows POS's SQL Server database. It only READS:
///   - every statement is a SELECT written in <see cref="PosSqlServerQueries"/> and is checked again by <see cref="ReadOnlySql"/> before it is sent;
///   - the connection says "read only" to the server (ApplicationIntent=ReadOnly), and the owner is told to use a login that can only read;
///   - the password is typed by the person each time and kept ONLY in memory, here, as a read-only SecureString that is handed to the driver as a credential (it is never put into a
///     connection string, a file, the Hub's database, a log or the audit record, and <see cref="ToString"/> never shows it). <see cref="Dispose"/> clears it.
/// KNOWN LIMIT: the SQL Server driver (Microsoft.Data.SqlClient 7.1.0) refuses to open a connection while the program runs in "invariant globalization" mode, which is how the Hub
/// is built (Directory.Build.props: no system language data needed). <see cref="InvariantGlobalization"/> says so, and <see cref="Read"/> then stops with a plain message instead of a
/// driver error. Until that is settled (docs/OPEN-WORK.md), the reader cannot connect from the shipped Hub. It is NOT worked around here.
/// It has been tested here only against a stand-in (there is no SQL Server in this environment): see docs/old-programs/DATABASE.md, "How a person verifies the reader".
/// </summary>
public sealed class PosSqlServerSource : IOldSystemSource, IDisposable
{
    public const string SourceKind = "pos-sqlserver";

    private readonly string _server;
    private readonly string _database;
    private readonly string? _user;
    private readonly SecureString? _password;
    private readonly bool _windowsLogin;
    private readonly bool _trustServerCertificate;

    /// <param name="server">The server name as the old program shows it ("PC1\SQLEXPRESS", "192.168.1.5,1433").</param>
    /// <param name="database">The old program's database name.</param>
    /// <param name="user">The SQL login (ignored with a Windows login).</param>
    /// <param name="password">The password just typed. Copied into a read-only SecureString; the caller should drop its own copy.</param>
    /// <param name="windowsLogin">Sign in as the Windows account the Hub runs under (no user or password).</param>
    /// <param name="trustServerCertificate">Accept the server's own (not publicly signed) security certificate. Off unless the person ticks it.</param>
    public PosSqlServerSource(string server, string database, string? user, string? password, bool windowsLogin = false, bool trustServerCertificate = false)
    {
        _server = (server ?? "").Trim();
        _database = (database ?? "").Trim();
        _user = string.IsNullOrWhiteSpace(user) ? null : user.Trim();
        _windowsLogin = windowsLogin;
        _trustServerCertificate = trustServerCertificate;
        if (!windowsLogin && !string.IsNullOrEmpty(password))
        {
            var secure = new SecureString();
            foreach (var ch in password) secure.AppendChar(ch);
            secure.MakeReadOnly();
            _password = secure;
        }
    }

    /// <summary>
    /// True when this program runs without the system's language data (the way the Hub is built). The SQL Server driver refuses to connect in that mode, by its own rule
    /// (it reads the same switch and environment variable as the runtime does).
    /// </summary>
    public static bool InvariantGlobalization =>
        (AppContext.TryGetSwitch("System.Globalization.Invariant", out var on) && on)
        || string.Equals(Environment.GetEnvironmentVariable("DOTNET_SYSTEM_GLOBALIZATION_INVARIANT"), "1", StringComparison.Ordinal)
        || string.Equals(Environment.GetEnvironmentVariable("DOTNET_SYSTEM_GLOBALIZATION_INVARIANT"), "true", StringComparison.OrdinalIgnoreCase);

    internal const string InvariantMessage =
        "The older program's database cannot be read from this copy of the Business Hub yet: this copy runs without the language data that the SQL Server connection needs. " +
        "Nothing was read and nothing was changed. Ask NextGenOS support for a version that can.";

    public string Kind => SourceKind;

    public string SourceId => (_server + "/" + _database).ToLowerInvariant();

    public string Describe => "SQL Server " + _server + ", database " + _database;

    /// <summary>Never shows the password (or the user): only the server and database.</summary>
    public override string ToString() => Describe;

    public void Dispose() => _password?.Dispose();

    public OldSystemData Read()
    {
        if (_server.Length == 0) throw new HubException("import-server", "Please type the name of the server the older program keeps its data on.");
        if (_database.Length == 0) throw new HubException("import-database", "Please type the name of the older program's database.");
        if (!_windowsLogin && (_user is null || _password is null)) throw new HubException("import-login", "Please type the user name and the password for the older program's database.");
        if (InvariantGlobalization) throw new HubException("import-globalization", InvariantMessage);
        try
        {
            using var connection = Open();
            CheckTables(connection);
            var data = new OldSystemData(
                Products: Query(connection, PosSqlServerQueries.Products, r => new OldProduct(
                    L(r, 0), S(r, 1), S(r, 2), r.IsDBNull(3) ? null : L(r, 3), S(r, 4), D(r, 5), D(r, 6), D(r, 7), D(r, 8), D(r, 9), D(r, 10), D(r, 11), S(r, 12), S(r, 13), D(r, 14), S(r, 15), S(r, 16))),
                Lots: Query(connection, PosSqlServerQueries.Lots, r => new OldLot(L(r, 0), L(r, 1), S(r, 2), D(r, 3), D(r, 4), D(r, 5), D(r, 6), D(r, 7), S(r, 8), S(r, 9), S(r, 10))),
                Categories: Query(connection, PosSqlServerQueries.Categories, r => new OldCategory(L(r, 0), S(r, 1))),
                SubCategories: Query(connection, PosSqlServerQueries.SubCategories, r => new OldSubCategory(L(r, 0), S(r, 1), S(r, 2))),
                Customers: Query(connection, PosSqlServerQueries.Customers, r => new OldCustomer(
                    L(r, 0), S(r, 1), S(r, 2), S(r, 3), S(r, 4), S(r, 5), S(r, 6), S(r, 7), S(r, 8), S(r, 9), S(r, 10), S(r, 11), D(r, 12), S(r, 13), D(r, 14), S(r, 15), S(r, 16), S(r, 17))),
                Suppliers: Query(connection, PosSqlServerQueries.Suppliers, r => new OldSupplier(
                    L(r, 0), S(r, 1), S(r, 2), S(r, 3), S(r, 4), S(r, 5), S(r, 6), S(r, 7), S(r, 8), S(r, 9), S(r, 10), S(r, 11), D(r, 12), D(r, 13), S(r, 14))),
                CustomerLedger: Query(connection, PosSqlServerQueries.CustomerLedger, Ledger),
                SupplierLedger: Query(connection, PosSqlServerQueries.SupplierLedger, Ledger));
            return data;
        }
        catch (SqlException ex)
        {
            throw Plain(ex);
        }
        catch (NotSupportedException ex) when (ex.Message.Contains("Invariant", StringComparison.OrdinalIgnoreCase))
        {
            throw new HubException("import-globalization", InvariantMessage);
        }
        catch (InvalidOperationException ex) when (!ex.Message.StartsWith("Refused to send", StringComparison.Ordinal))
        {
            // The driver's own complaint about the connection (a bad server name, for instance). A statement the guard refused is a bug in this program and is not hidden here.
            throw new HubException("import-connect", "The older program's database could not be reached: " + FirstLine(ex.Message));
        }
    }

    private SqlConnection Open()
    {
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = _server,
            InitialCatalog = _database,
            ApplicationIntent = ApplicationIntent.ReadOnly,
            ConnectTimeout = 15,
            ApplicationName = "Business Hub: move from the older POS",
            IntegratedSecurity = _windowsLogin,
            TrustServerCertificate = _trustServerCertificate,
        };
        // The password never goes into the connection string: a SQL login is handed over as a credential.
        var connection = _windowsLogin ? new SqlConnection(builder.ConnectionString) : new SqlConnection(builder.ConnectionString, new SqlCredential(_user!, _password!));
        try
        {
            connection.Open();
            return connection;
        }
        catch
        {
            connection.Dispose();
            throw;
        }
    }

    private static void CheckTables(SqlConnection connection)
    {
        var found = new Dictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);
        foreach (var (table, column) in Query(connection, PosSqlServerQueries.Schema, r => (S(r, 0) ?? "", S(r, 1) ?? "")))
        {
            if (!found.TryGetValue(table, out var set)) found[table] = set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            set.Add(column);
        }
        var missingTables = PosSqlServerQueries.RequiredColumns.Keys.Where(t => !found.ContainsKey(t)).ToList();
        if (missingTables.Count > 0)
            throw new HubException("import-not-pos", "This does not look like the older POS's database: these tables were not found: " + string.Join(", ", missingTables) + ". Check the database name, or ask the person who set up the older program.");
        var missing = PosSqlServerQueries.RequiredColumns
            .SelectMany(t => t.Value.Where(c => !found[t.Key].Contains(c)).Select(c => t.Key + "." + c)).ToList();
        if (missing.Count > 0)
            throw new HubException("import-version", "This copy of the older program's database is arranged differently from the one this move expects: these columns were not found: " + string.Join(", ", missing) + ". Nothing was read.");
    }

    private static List<T> Query<T>(SqlConnection connection, string sql, Func<SqlDataReader, T> map)
    {
        using var command = new SqlCommand(ReadOnlySql.Require(sql), connection) { CommandTimeout = 180 };
        using var reader = command.ExecuteReader();
        var rows = new List<T>();
        while (reader.Read()) rows.Add(map(reader));
        return rows;
    }

    private static OldLedgerTotal Ledger(SqlDataReader r) => new(S(r, 0) ?? "", D(r, 1), D(r, 2), (int)L(r, 3), (int)L(r, 4));

    private static string? S(SqlDataReader r, int i) => r.IsDBNull(i) ? null : Convert.ToString(r.GetValue(i), CultureInfo.InvariantCulture);

    private static decimal D(SqlDataReader r, int i) => r.IsDBNull(i) ? 0m : Convert.ToDecimal(r.GetValue(i), CultureInfo.InvariantCulture);

    private static long L(SqlDataReader r, int i) => r.IsDBNull(i) ? 0L : Convert.ToInt64(r.GetValue(i), CultureInfo.InvariantCulture);

    private static string FirstLine(string text) => text.Split('\n')[0].Trim();

    /// <summary>The server's complaint in words a shop owner can act on. The password is never in a message: the driver does not put it in one, and it is not in the connection string.</summary>
    private static HubException Plain(SqlException ex)
    {
        var text = ex.Message ?? "";
        if (ex.Number == 18456 || text.Contains("Login failed", StringComparison.OrdinalIgnoreCase))
            return new HubException("import-login-failed", "The server did not accept that user name and password. Check them, and that the user may read the older program's database.");
        if (ex.Number == 4060 || text.Contains("Cannot open database", StringComparison.OrdinalIgnoreCase))
            return new HubException("import-database-denied", "The server has no database with that name, or this user may not open it.");
        if (text.Contains("certificate", StringComparison.OrdinalIgnoreCase) || text.Contains("SSL", StringComparison.Ordinal))
            return new HubException("import-certificate", "The server's security certificate is not trusted by this computer. If this is your own shop's server, tick \"Trust this server's certificate\" and check again.");
        if (ex.Number == 53 || ex.Number == 40 || ex.Number == -1 || ex.Number == 2 || ex.Number == 10060 || text.Contains("network-related", StringComparison.OrdinalIgnoreCase) || text.Contains("server was not found", StringComparison.OrdinalIgnoreCase))
            return new HubException("import-unreachable", "The server could not be reached. Check its name, that it is switched on, and that this computer may connect to it.");
        return new HubException("import-read", "The older program's database could not be read: " + FirstLine(text));
    }
}
