using Microsoft.Data.Sqlite;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Shop;

namespace NextGenOS.Hub.Documents;

/// <summary>Document numbers that never skip and never repeat: INV-2026-000001. The year part is the fiscal year the document belongs to in the shop's country.</summary>
public sealed class Numbering(ShopContextProvider shop)
{
    private static readonly Dictionary<string, string> Prefixes = new()
    {
        ["invoice"] = "INV", ["quote"] = "QUO", ["order"] = "ORD", ["credit-note"] = "CN", ["purchase"] = "PO", ["progress-bill"] = "PB", ["receipt"] = "RCT",
    };

    public static string PrefixOf(string type) => Prefixes.TryGetValue(type, out var p) ? p : type.ToUpperInvariant();

    /// <summary>Takes the next number of a type, inside the caller's transaction so that a rolled-back document gives its number back.</summary>
    public string Next(SqliteConnection connection, SqliteTransaction transaction, string type, DateTimeOffset when)
    {
        var context = shop.Current;
        var year = context.YearKey(context.Time.LocalDate(when));
        var next = Convert.ToInt64(HubDb.Scalar(connection, "SELECT next_no FROM number_series WHERE type = $t AND year_key = $y", transaction, ("$t", type), ("$y", year)) ?? 1L);
        HubDb.Exec(connection, "INSERT INTO number_series(type, year_key, next_no) VALUES ($t, $y, $n) ON CONFLICT(type, year_key) DO UPDATE SET next_no = excluded.next_no", transaction,
            ("$t", type), ("$y", year), ("$n", next + 1));
        return $"{PrefixOf(type)}-{year}-{next:000000}";
    }
}
