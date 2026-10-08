using Microsoft.Data.Sqlite;

namespace NextGenOS.Hub.Data;

/// <summary>What looking at a shop database file found. <see cref="Healthy"/> when there is nothing to report.</summary>
public sealed record DatabaseReport(int Version, int Tables, IReadOnlyList<string> Problems)
{
    public bool Healthy => Problems.Count == 0;
}

/// <summary>
/// Looks at a shop database file without changing it: the file itself (SQLite's own integrity check and its foreign-key check) and, for a whole shop, the books (every entry adds up to nothing).
/// It is used on the copy made before an update, and by the restore check: a copy put back on a clean PC must pass it before the shop sells again.
/// </summary>
public static class DatabaseCheck
{
    /// <param name="path">The file to look at. It is opened read-only.</param>
    /// <param name="books">Also check the shop's own rules (the books balance). Off for the copy made before an update: a copy of a shop whose books are already wrong is still a copy worth having.</param>
    public static DatabaseReport Inspect(string path, bool books = true)
    {
        if (!File.Exists(path)) return new DatabaseReport(0, 0, new[] { "The file is not there." });
        var problems = new List<string>();
        try
        {
            var text = new SqliteConnectionStringBuilder { DataSource = path, Mode = SqliteOpenMode.ReadOnly, Cache = SqliteCacheMode.Private, Pooling = false }.ToString();
            using var connection = new SqliteConnection(text);
            connection.Open();

            var found = HubDb.Query(connection, "PRAGMA integrity_check", r => r.GetString(0));
            if (!(found.Count == 1 && found[0] == "ok")) problems.Add("The file is damaged: " + string.Join("; ", found.Take(3)) + ".");

            var orphans = HubDb.Query(connection, "PRAGMA foreign_key_check", r => r.GetString(0)).Count;
            if (orphans > 0) problems.Add($"{orphans} {(orphans == 1 ? "record points" : "records point")} at something that is not there.");

            var tables = Convert.ToInt32(HubDb.Scalar(connection, "SELECT COUNT(*) FROM sqlite_master WHERE type = 'table'") ?? 0);
            var hasVersion = Convert.ToInt32(HubDb.Scalar(connection, "SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = 'schema_version'") ?? 0) > 0;
            var version = hasVersion ? Convert.ToInt32(HubDb.Scalar(connection, "SELECT COALESCE(MAX(version), 0) FROM schema_version") ?? 0) : 0;
            if (!hasVersion) problems.Add("This is not a shop database (it has no version).");

            if (books && hasVersion && Convert.ToInt32(HubDb.Scalar(connection, "SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = 'journal_lines'") ?? 0) > 0)
            {
                var off = Convert.ToInt32(HubDb.Scalar(connection,
                    "SELECT COUNT(*) FROM (SELECT entry_id FROM journal_lines GROUP BY entry_id HAVING SUM(debit_minor) <> SUM(credit_minor))") ?? 0);
                if (off > 0) problems.Add($"{off} {(off == 1 ? "entry in the books does" : "entries in the books do")} not add up to nothing.");
            }
            return new DatabaseReport(version, tables, problems);
        }
        catch (SqliteException e)
        {
            problems.Add("The file cannot be read as a shop database (" + e.Message + ").");
            return new DatabaseReport(0, 0, problems);
        }
    }
}
