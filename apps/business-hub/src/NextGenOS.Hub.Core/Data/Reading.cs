using Microsoft.Data.Sqlite;

namespace NextGenOS.Hub.Data;

/// <summary>Reading columns by name, with the null and type handling written once.</summary>
public static class Reading
{
    public static long Int(this SqliteDataReader r, string column) => r.IsDBNull(r.GetOrdinal(column)) ? 0 : r.GetInt64(r.GetOrdinal(column));

    public static long? IntOrNull(this SqliteDataReader r, string column) => r.IsDBNull(r.GetOrdinal(column)) ? null : r.GetInt64(r.GetOrdinal(column));

    public static string Text(this SqliteDataReader r, string column) => r.IsDBNull(r.GetOrdinal(column)) ? string.Empty : r.GetString(r.GetOrdinal(column));

    public static string? TextOrNull(this SqliteDataReader r, string column) => r.IsDBNull(r.GetOrdinal(column)) ? null : r.GetString(r.GetOrdinal(column));

    public static bool Flag(this SqliteDataReader r, string column) => r.Int(column) != 0;

    public static DateTimeOffset Time(this SqliteDataReader r, string column) => DateTimeOffset.Parse(r.GetString(r.GetOrdinal(column)), System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal);

    public static DateTimeOffset? TimeOrNull(this SqliteDataReader r, string column) => r.IsDBNull(r.GetOrdinal(column)) ? null : r.Time(column);
}
