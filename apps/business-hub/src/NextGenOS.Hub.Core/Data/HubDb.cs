using System.Reflection;
using Microsoft.Data.Sqlite;

namespace NextGenOS.Hub.Data;

/// <summary>
/// The shop's SQLite database. Every operation opens its own short connection (SQLite keeps it cheap); writes that belong together go through
/// <see cref="InTransaction{T}"/>. The file is in WAL mode with foreign keys on, so readers never wait for a writer.
/// </summary>
public sealed class HubDb
{
    private readonly string _connectionString;

    public HubDb(string path)
    {
        Path = path;
        var directory = System.IO.Path.GetDirectoryName(System.IO.Path.GetFullPath(path));
        if (!string.IsNullOrEmpty(directory)) Directory.CreateDirectory(directory);
        _connectionString = new SqliteConnectionStringBuilder { DataSource = path, Mode = SqliteOpenMode.ReadWriteCreate, Cache = SqliteCacheMode.Private, Pooling = false }.ToString();
    }

    /// <summary>An in-memory database for tests: lives as long as the returned object.</summary>
    public static HubDb InMemory() => new(System.IO.Path.Combine(System.IO.Path.GetTempPath(), "hub-test-" + Guid.NewGuid().ToString("N") + ".db"));

    public string Path { get; }

    public SqliteConnection Open()
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        using var pragma = connection.CreateCommand();
        pragma.CommandText = "PRAGMA journal_mode=WAL; PRAGMA foreign_keys=ON; PRAGMA busy_timeout=5000; PRAGMA synchronous=NORMAL;";
        pragma.ExecuteNonQuery();
        return connection;
    }

    /// <summary>Brings the file up to the newest structure. Safe to run on every start; each step runs once.</summary>
    public void Migrate()
    {
        using var connection = Open();
        Exec(connection, "CREATE TABLE IF NOT EXISTS schema_version (version INTEGER NOT NULL)");
        var current = Convert.ToInt32(Scalar(connection, "SELECT COALESCE(MAX(version), 0) FROM schema_version") ?? 0);
        var assembly = typeof(HubDb).Assembly;
        var steps = assembly.GetManifestResourceNames()
            .Where(n => n.StartsWith("NextGenOS.Hub.migrations.", StringComparison.Ordinal) && n.EndsWith(".sql", StringComparison.Ordinal))
            .OrderBy(n => n, StringComparer.Ordinal)
            .ToList();
        foreach (var name in steps)
        {
            var version = int.Parse(name["NextGenOS.Hub.migrations.".Length..].Split('_')[0], System.Globalization.CultureInfo.InvariantCulture);
            if (version <= current) continue;
            using var stream = assembly.GetManifestResourceStream(name)!;
            using var reader = new StreamReader(stream);
            using var transaction = connection.BeginTransaction();
            Exec(connection, reader.ReadToEnd(), transaction);
            Exec(connection, "INSERT INTO schema_version(version) VALUES (" + version + ")", transaction);
            transaction.Commit();
        }
    }

    public T InTransaction<T>(Func<SqliteConnection, SqliteTransaction, T> work)
    {
        using var connection = Open();
        using var transaction = connection.BeginTransaction();
        try
        {
            var result = work(connection, transaction);
            transaction.Commit();
            return result;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public void InTransaction(Action<SqliteConnection, SqliteTransaction> work) => InTransaction<int>((c, t) => { work(c, t); return 0; });

    // ---- small helpers used by every repository ------------------------------------------------------------------------------

    public static int Exec(SqliteConnection connection, string sql, SqliteTransaction? transaction = null, params (string Name, object? Value)[] parameters)
    {
        using var command = Command(connection, sql, transaction, parameters);
        return command.ExecuteNonQuery();
    }

    public static object? Scalar(SqliteConnection connection, string sql, SqliteTransaction? transaction = null, params (string Name, object? Value)[] parameters)
    {
        using var command = Command(connection, sql, transaction, parameters);
        var value = command.ExecuteScalar();
        return value is DBNull ? null : value;
    }

    public static long Insert(SqliteConnection connection, string sql, SqliteTransaction? transaction = null, params (string Name, object? Value)[] parameters)
    {
        using var command = Command(connection, sql + "; SELECT last_insert_rowid();", transaction, parameters);
        return Convert.ToInt64(command.ExecuteScalar(), System.Globalization.CultureInfo.InvariantCulture);
    }

    public static List<T> Query<T>(SqliteConnection connection, string sql, Func<SqliteDataReader, T> map, SqliteTransaction? transaction = null, params (string Name, object? Value)[] parameters)
    {
        using var command = Command(connection, sql, transaction, parameters);
        using var reader = command.ExecuteReader();
        var rows = new List<T>();
        while (reader.Read()) rows.Add(map(reader));
        return rows;
    }

    public List<T> Query<T>(string sql, Func<SqliteDataReader, T> map, params (string Name, object? Value)[] parameters)
    {
        using var connection = Open();
        return Query(connection, sql, map, null, parameters);
    }

    public T? QueryOne<T>(string sql, Func<SqliteDataReader, T> map, params (string Name, object? Value)[] parameters) where T : class
    {
        using var connection = Open();
        return Query(connection, sql, map, null, parameters).FirstOrDefault();
    }

    public object? Scalar(string sql, params (string Name, object? Value)[] parameters)
    {
        using var connection = Open();
        return Scalar(connection, sql, null, parameters);
    }

    private static SqliteCommand Command(SqliteConnection connection, string sql, SqliteTransaction? transaction, (string Name, object? Value)[] parameters)
    {
        var command = connection.CreateCommand();
        command.Transaction = transaction;
        command.CommandText = sql;
        foreach (var (name, value) in parameters) command.Parameters.AddWithValue(name, value ?? DBNull.Value);
        return command;
    }
}
