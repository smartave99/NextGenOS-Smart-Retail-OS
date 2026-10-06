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

    /// <summary>
    /// Brings the file up to the newest structure. Safe to run on every start; each step runs once. Before the first step of an update to an existing shop
    /// database, the whole file is copied (see <see cref="Backup"/>), so that an update can always be undone by putting the copy back.
    /// </summary>
    public void Migrate()
    {
        using var connection = Open();
        Exec(connection, "CREATE TABLE IF NOT EXISTS schema_version (version INTEGER NOT NULL)");
        var current = Convert.ToInt32(Scalar(connection, "SELECT COALESCE(MAX(version), 0) FROM schema_version") ?? 0);
        var assembly = typeof(HubDb).Assembly;
        var steps = assembly.GetManifestResourceNames()
            .Where(n => n.StartsWith(MigrationPrefix, StringComparison.Ordinal) && n.EndsWith(".sql", StringComparison.Ordinal))
            .OrderBy(n => n, StringComparer.Ordinal)
            .Select(n => (Name: n, Version: VersionOf(n, MigrationPrefix)))
            .Where(s => s.Version > current)
            .ToList();
        if (steps.Count > 0 && current > 0) BackupProblem = Backup(connection, $"before-update-{current}-to-{steps[^1].Version}");
        foreach (var (name, version) in steps)
        {
            using var stream = assembly.GetManifestResourceStream(name)!;
            using var reader = new StreamReader(stream);
            using var transaction = connection.BeginTransaction();
            Exec(connection, reader.ReadToEnd(), transaction);
            Exec(connection, "INSERT INTO schema_version(version) VALUES (" + version + ")", transaction);
            transaction.Commit();
        }
    }

    /// <summary>
    /// Takes the file back to an earlier structure by running the way back of every newer step, newest first (Data/Rollbacks). It copies the database first, because a way
    /// back drops what the step made. The first step (the shop's own tables) has no way back and is refused. Nothing in the program calls this: it is for the person who
    /// looks after the computer, and for the tests that prove that every step can be undone.
    /// </summary>
    public void Rollback(int toVersion)
    {
        if (toVersion < 1) throw new InvalidOperationException("The first structure of the shop database cannot be undone.");
        using var connection = Open();
        var current = Convert.ToInt32(Scalar(connection, "SELECT COALESCE(MAX(version), 0) FROM schema_version") ?? 0);
        if (toVersion >= current) return;
        var assembly = typeof(HubDb).Assembly;
        var ways = assembly.GetManifestResourceNames().Where(n => n.StartsWith(RollbackPrefix, StringComparison.Ordinal) && n.EndsWith(".sql", StringComparison.Ordinal))
            .ToDictionary(n => VersionOf(n, RollbackPrefix));
        for (var version = current; version > toVersion; version--)
            if (!ways.ContainsKey(version)) throw new InvalidOperationException($"Step {version} of the shop database has no way back, so nothing was changed.");
        var problem = Backup(connection, $"before-undo-{current}-to-{toVersion}");
        if (problem is not null) throw new InvalidOperationException("The shop database could not be copied first, so nothing was changed. " + problem);
        for (var version = current; version > toVersion; version--)
        {
            using var stream = assembly.GetManifestResourceStream(ways[version])!;
            using var reader = new StreamReader(stream);
            using var transaction = connection.BeginTransaction();
            Exec(connection, reader.ReadToEnd(), transaction);
            Exec(connection, "DELETE FROM schema_version WHERE version = " + version, transaction);
            transaction.Commit();
        }
    }

    /// <summary>The copy made before the last update, or why none could be made (null: all well, or nothing needed copying).</summary>
    public string? BackupProblem { get; private set; }

    /// <summary>Where the copy of the last backup went (null: none was made since this object was made).</summary>
    public string? LastBackup { get; private set; }

    /// <summary>
    /// A consistent copy of the whole file next to it (<c>shop.db.before-update-1-to-2.bak</c>), made with SQLite's own VACUUM INTO, which is safe while the file is in use.
    /// Returns null when it worked, or a sentence about what went wrong (it never throws: the update itself runs in steps that are each all-or-nothing).
    /// </summary>
    private string? Backup(SqliteConnection connection, string label)
    {
        try
        {
            var target = Path + "." + label + ".bak";
            if (File.Exists(target)) target = Path + "." + label + "-" + DateTime.UtcNow.ToString("yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture) + ".bak";
            Exec(connection, "VACUUM INTO $target", null, ("$target", target));
            LastBackup = target;
            return null;
        }
        catch (Exception e) when (e is SqliteException or IOException or UnauthorizedAccessException)
        {
            return "The copy of the shop database made before an update could not be written (" + e.Message + ").";
        }
    }

    private const string MigrationPrefix = "NextGenOS.Hub.migrations.";
    private const string RollbackPrefix = "NextGenOS.Hub.rollbacks.";

    private static int VersionOf(string resourceName, string prefix) =>
        int.Parse(resourceName[prefix.Length..].Split('_')[0], System.Globalization.CultureInfo.InvariantCulture);

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
