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
    private readonly string? _backupFolder;

    /// <param name="path">The shop database file.</param>
    /// <param name="backupFolder">Where the copies made before an update (or an undo, or an import) go. Null: next to the file. A second disk or a USB drive is better than the same one.</param>
    public HubDb(string path, string? backupFolder = null)
    {
        Path = path;
        _backupFolder = string.IsNullOrWhiteSpace(backupFolder) ? null : backupFolder;
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
    /// Brings the file up to the newest structure. Safe to run on every start. Before an update of an existing shop database, the whole file is copied (see <see cref="Backup"/>)
    /// and the copy is checked; if it cannot be made or does not check out, the update does not start and nothing is changed (<see cref="HubException"/> "backup"). Then every step runs
    /// in one transaction: either the shop is at the newest structure or it is exactly as it was.
    /// </summary>
    public void Migrate() => Migrate(Steps(MigrationPrefix));

    /// <summary>The same, with the steps given (the tests use it to prove that a step that fails leaves the shop as it was).</summary>
    internal void Migrate(IReadOnlyList<MigrationStep> all)
    {
        using var connection = Open();
        Exec(connection, "CREATE TABLE IF NOT EXISTS schema_version (version INTEGER NOT NULL)");
        var current = Convert.ToInt32(Scalar(connection, "SELECT COALESCE(MAX(version), 0) FROM schema_version") ?? 0);
        var pending = all.Where(s => s.Version > current).OrderBy(s => s.Version).ToList();
        if (pending.Count == 0) return;
        if (current > 0)
        {
            var problem = Backup(connection, $"before-update-{current}-to-{pending[^1].Version}");
            if (problem is not null)
                throw new HubException("backup", "The shop's data was not changed. The update needs a safe copy of it first, and that copy could not be made. " + problem +
                    " Make sure the folder for copies exists, has free space and can be written to, then start the program again.");
        }

        using var transaction = connection.BeginTransaction();
        try
        {
            foreach (var step in pending)
            {
                Exec(connection, step.Sql, transaction);
                Exec(connection, "INSERT INTO schema_version(version) VALUES (" + step.Version + ")", transaction);
            }
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    internal readonly record struct MigrationStep(int Version, string Sql);

    private static List<MigrationStep> Steps(string prefix)
    {
        var assembly = typeof(HubDb).Assembly;
        return assembly.GetManifestResourceNames()
            .Where(n => n.StartsWith(prefix, StringComparison.Ordinal) && n.EndsWith(".sql", StringComparison.Ordinal))
            .OrderBy(n => n, StringComparer.Ordinal)
            .Select(n =>
            {
                using var stream = assembly.GetManifestResourceStream(n)!;
                using var reader = new StreamReader(stream);
                return new MigrationStep(VersionOf(n, prefix), reader.ReadToEnd());
            })
            .ToList();
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
        using var transaction = connection.BeginTransaction();
        try
        {
            for (var version = current; version > toVersion; version--)
            {
                using var stream = assembly.GetManifestResourceStream(ways[version])!;
                using var reader = new StreamReader(stream);
                Exec(connection, reader.ReadToEnd(), transaction);
                Exec(connection, "DELETE FROM schema_version WHERE version = " + version, transaction);
            }
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    /// <summary>Where the copy of the last backup went (null: none was made since this object was made).</summary>
    public string? LastBackup { get; private set; }

    /// <summary>
    /// A consistent copy of the whole file (<c>shop.db.before-update-1-to-2.bak</c>, next to the file or in the backup folder), made with SQLite's own VACUUM INTO, which is safe while the
    /// file is in use, and then <b>checked</b>: the copy is opened and must pass SQLite's own integrity check, be at the same structure version and have the same tables as the file it
    /// came from. A copy that fails the check is deleted, so a bad copy is never left lying about looking like a good one.
    /// Returns null when it worked, or a sentence about what went wrong (it never throws for a disk problem: the caller decides whether to go on).
    /// </summary>
    private string? Backup(SqliteConnection connection, string label)
    {
        string? target = null;
        try
        {
            var folder = _backupFolder ?? System.IO.Path.GetDirectoryName(System.IO.Path.GetFullPath(Path))!;
            Directory.CreateDirectory(folder);
            var name = System.IO.Path.GetFileName(Path) + "." + label;
            target = System.IO.Path.Combine(folder, name + ".bak");
            if (File.Exists(target)) target = System.IO.Path.Combine(folder, name + "-" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture) + ".bak");
            Exec(connection, "VACUUM INTO $target", null, ("$target", target));

            var expectedVersion = Convert.ToInt32(Scalar(connection, "SELECT COALESCE(MAX(version), 0) FROM schema_version") ?? 0);
            var expectedTables = Convert.ToInt32(Scalar(connection, "SELECT COUNT(*) FROM sqlite_master WHERE type = 'table'") ?? 0);
            var report = DatabaseCheck.Inspect(target, books: false);
            if (!report.Healthy || report.Version != expectedVersion || report.Tables != expectedTables)
            {
                TryDelete(target);
                return "The copy was written but did not pass the check (" + (report.Healthy ? $"it has {report.Tables} tables at version {report.Version}, the shop has {expectedTables} at {expectedVersion}" : string.Join("; ", report.Problems)) + ").";
            }

            LastBackup = target;
            return null;
        }
        catch (Exception e) when (e is SqliteException or IOException or UnauthorizedAccessException or NotSupportedException or ArgumentException)
        {
            if (target is not null) TryDelete(target);
            return "The safe copy of the shop's data could not be written (" + e.Message + ").";
        }
    }

    private static void TryDelete(string file)
    {
        try { if (File.Exists(file)) File.Delete(file); }
        catch (Exception e) when (e is IOException or UnauthorizedAccessException) { /* a copy that cannot be removed is reported by the caller's message; it must not hide the real problem */ }
    }

    /// <summary>The number of the newest step of the shop database that this program knows.</summary>
    public static int LatestVersion { get; } = typeof(HubDb).Assembly.GetManifestResourceNames()
        .Where(n => n.StartsWith(MigrationPrefix, StringComparison.Ordinal) && n.EndsWith(".sql", StringComparison.Ordinal))
        .Select(n => VersionOf(n, MigrationPrefix)).DefaultIfEmpty(0).Max();
    /// <summary>
    /// A consistent copy of the whole file made on request, for a change that is bigger than one save (moving a shop across from an older system). It is the same copy the update
    /// makes (<c>shop.db.before-import-....bak</c>, VACUUM INTO, safe while the file is in use). Unlike the update, it stops the caller: if the copy cannot be written this throws,
    /// and the caller must not go on to change anything. Returns where the copy is.
    /// </summary>
    public string BackupNow(string label)
    {
        using var connection = Open();
        var problem = Backup(connection, label);
        if (problem is not null || LastBackup is null) throw new HubException("backup", "A copy of the shop's data could not be made first, so nothing was changed. " + problem);
        return LastBackup;
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
