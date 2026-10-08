using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using NextGenOS.Hub.Catalog;
using NextGenOS.Hub.Data;
using NextGenOS.Hub.Documents;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// Blueprint item DB-001: an update of a shop that already has data never starts without a safe, checked copy, and a step that fails leaves the shop exactly as it was.
/// A copy put back on a clean PC opens, passes the checks and holds the same money.
/// </summary>
public class MigrationSafetyTests : IDisposable
{
    private readonly string folder = Path.Combine(Path.GetTempPath(), "hub-migration-" + Guid.NewGuid().ToString("N"));

    public MigrationSafetyTests() => Directory.CreateDirectory(folder);

    public void Dispose()
    {
        try { Directory.Delete(folder, recursive: true); } catch (IOException) { }
    }

    /// <summary>One hash over the structure and every row of every table: equal before and after means nothing was touched.</summary>
    private static string Fingerprint(string path)
    {
        var db = new HubDb(path);
        using var c = db.Open();
        var text = new StringBuilder();
        text.Append(string.Join("|", HubDb.Query(c, "SELECT COALESCE(sql, '') FROM sqlite_master ORDER BY type, name", r => r.GetString(0))));
        foreach (var table in HubDb.Query(c, "SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%' ORDER BY name", r => r.GetString(0)))
        {
            text.Append('\n').Append(table).Append(':');
            text.Append(string.Join(";", HubDb.Query(c, $"SELECT * FROM \"{table}\" ORDER BY 1",
                r => string.Join(",", Enumerable.Range(0, r.FieldCount).Select(i => r.IsDBNull(i) ? "~" : Convert.ToString(r.GetValue(i), CultureInfo.InvariantCulture))))));
        }
        return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(text.ToString())));
    }

    /// <summary>A shop with a bill in it, taken back to its first structure, as a shop that has not been updated for a long time.</summary>
    private string OldShopWithData(out HubFixture fixture)
    {
        fixture = new HubFixture();
        var rice = fixture.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice", PriceMinor = 11800, TaxClass = "standard" });
        fixture.App.Catalog.Adjust(rice.Id, 10_000, "delivery");
        fixture.App.Documents.Checkout(new CheckoutRequest
        {
            Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 2000 } },
            Payments = { new PaymentInput { Method = "cash", AmountMinor = 23_600 } },
        });
        var path = fixture.App.Db.Path;
        fixture.App.Db.Rollback(1);
        return path;
    }

    [Fact]
    public void An_update_with_no_place_for_the_safe_copy_stops_and_leaves_the_shop_exactly_as_it_was()
    {
        var path = OldShopWithData(out var f);
        using var _ = f;
        var before = Fingerprint(path);

        // The folder for copies is "under" a plain file, so it can never be made.
        var blocker = Path.Combine(folder, "blocker");
        File.WriteAllText(blocker, "not a folder");
        var db = new HubDb(path, Path.Combine(blocker, "copies"));

        var ex = Assert.Throws<HubException>(() => db.Migrate());
        Assert.Equal("backup", ex.Code);
        Assert.Contains("was not changed", ex.Message);
        Assert.Contains("start the program again", ex.Message);   // says what to do
        Assert.Null(db.LastBackup);

        Assert.Equal(new long[] { 1 }, db.Query("SELECT version FROM schema_version", r => r.GetInt64(0)).ToArray());   // no step was recorded
        Assert.Null(db.Scalar("SELECT name FROM sqlite_master WHERE name = 'ai_providers'"));                            // no step ran
        Assert.Equal(before, Fingerprint(path));                                                                         // not one row or table changed
    }

    [Fact]
    public void An_update_puts_its_safe_copy_in_the_folder_chosen_for_copies_and_the_copy_passes_the_checks()
    {
        var path = OldShopWithData(out var f);
        using var _ = f;
        var copies = Path.Combine(folder, "second-disk", "copies");   // does not exist yet: it is made
        var db = new HubDb(path, copies);

        db.Migrate();

        Assert.NotNull(db.LastBackup);
        Assert.Equal(copies, Path.GetDirectoryName(db.LastBackup));
        Assert.Contains($"before-update-1-to-{HubDb.LatestVersion}", db.LastBackup);
        var report = DatabaseCheck.Inspect(db.LastBackup!);
        Assert.True(report.Healthy, string.Join("; ", report.Problems));
        Assert.Equal(1, report.Version);                       // the copy is the shop as it was before
        Assert.Equal(HubDb.LatestVersion, Convert.ToInt32(db.Scalar("SELECT MAX(version) FROM schema_version")));
    }

    [Fact]
    public void A_step_that_fails_in_the_middle_undoes_the_steps_before_it_and_the_shop_stays_as_it_was()
    {
        using var f = new HubFixture();
        var path = f.App.Db.Path;
        var before = Fingerprint(path);
        var latest = HubDb.LatestVersion;
        var db = new HubDb(path);

        var steps = new[]
        {
            new HubDb.MigrationStep(latest + 1, "CREATE TABLE later_a (id INTEGER PRIMARY KEY, note TEXT); INSERT INTO later_a(note) VALUES ('one');"),
            new HubDb.MigrationStep(latest + 2, "THIS IS NOT A STEP"),
        };
        Assert.ThrowsAny<Exception>(() => db.Migrate(steps));

        Assert.Equal(latest, Convert.ToInt32(db.Scalar("SELECT MAX(version) FROM schema_version")));
        Assert.Null(db.Scalar("SELECT name FROM sqlite_master WHERE name = 'later_a'"));   // the good step before the bad one was undone too
        Assert.Equal(before, Fingerprint(path));
        Assert.NotNull(db.LastBackup);                                                       // and a checked copy was made first
        Assert.True(DatabaseCheck.Inspect(db.LastBackup!).Healthy);
    }

    [Fact]
    public void A_new_shop_has_nothing_to_lose_so_it_makes_no_copy_and_a_shop_that_is_up_to_date_makes_none_either()
    {
        var db = new HubDb(Path.Combine(folder, "fresh.db"), Path.Combine(folder, "copies"));
        db.Migrate();
        Assert.Null(db.LastBackup);
        Assert.False(Directory.Exists(Path.Combine(folder, "copies")));
        db.Migrate();
        Assert.Null(db.LastBackup);
    }

    [Fact]
    public void A_copy_put_back_on_a_clean_PC_opens_passes_the_checks_and_holds_the_same_money()
    {
        using var f = new HubFixture();
        var rice = f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice", PriceMinor = 11800, TaxClass = "standard" });
        f.App.Catalog.Adjust(rice.Id, 10_000, "delivery");
        f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 3000 } }, Payments = { new PaymentInput { Method = "cash", AmountMinor = 35_400 } } });
        f.App.Documents.Checkout(new CheckoutRequest { Lines = { new LineInput { ItemId = rice.Id, QtyMilli = 1000 } }, Payments = { new PaymentInput { Method = "card", AmountMinor = 11_800 } } });
        f.App.Books.CatchUp();

        var made = f.App.Db.BackupNow("drill");

        // "A clean PC": a new folder, the copy as the only file.
        var clean = Path.Combine(folder, "clean-pc");
        Directory.CreateDirectory(clean);
        var restored = Path.Combine(clean, "shop.db");
        File.Copy(made, restored);

        var report = DatabaseCheck.Inspect(restored);
        Assert.True(report.Healthy, string.Join("; ", report.Problems));
        Assert.Equal(HubDb.LatestVersion, report.Version);

        var again = HubApp.Open(restored, f.Clock);
        long Sum(HubApp a, string sql) => Convert.ToInt64(a.Db.Scalar(sql) ?? 0L);
        foreach (var sql in new[]
        {
            "SELECT COUNT(*) FROM documents", "SELECT COALESCE(SUM(total_minor), 0) FROM documents", "SELECT COALESCE(SUM(debit_minor), 0) FROM journal_lines",
            "SELECT COALESCE(SUM(credit_minor), 0) FROM journal_lines", "SELECT COUNT(*) FROM items", "SELECT COALESCE(SUM(qty_milli), 0) FROM stock_moves",
        })
            Assert.Equal(Sum(f.App, sql), Sum(again, sql));
        Assert.Equal(Sum(again, "SELECT COALESCE(SUM(debit_minor), 0) FROM journal_lines"), Sum(again, "SELECT COALESCE(SUM(credit_minor), 0) FROM journal_lines"));   // the trial balance balances
        Assert.True(Sum(again, "SELECT COUNT(*) FROM documents") >= 2);
    }

    [Fact]
    public void The_check_finds_a_damaged_file_a_file_that_is_not_a_shop_a_missing_file_and_books_that_do_not_balance()
    {
        // Missing.
        Assert.False(DatabaseCheck.Inspect(Path.Combine(folder, "nothing.db")).Healthy);

        // Not a database at all.
        var junk = Path.Combine(folder, "junk.db");
        File.WriteAllText(junk, "this is not a database, it is a note someone saved by mistake and it is long enough to be a page");
        Assert.False(DatabaseCheck.Inspect(junk).Healthy);

        // A real shop with a piece cut off the end.
        using var f = new HubFixture();
        f.App.Catalog.Create(new ItemInput { Kind = "stock", Name = "Rice", PriceMinor = 11800, TaxClass = "standard" });
        var good = f.App.Db.BackupNow("check");
        Assert.True(DatabaseCheck.Inspect(good).Healthy);
        var cut = Path.Combine(folder, "cut.db");
        var bytes = File.ReadAllBytes(good);
        File.WriteAllBytes(cut, bytes[..(bytes.Length / 2)]);
        Assert.False(DatabaseCheck.Inspect(cut).Healthy);

        // Books that do not add up: one line with no other side. The books checker names it; the copy-before-update check (books: false) does not stop on it.
        var off = Path.Combine(folder, "off.db");
        File.Copy(good, off);
        var offDb = new HubDb(off);
        offDb.InTransaction((c, t) =>
        {
            var account = HubDb.Insert(c, "INSERT INTO accounts(code, name, kind, created_at) VALUES ('9999', 'Test', 'asset', '2026-10-05T00:00:00Z')", t);
            var entry = HubDb.Insert(c, "INSERT INTO journal_entries(at, source, source_id, created_at) VALUES ('2026-10-05T00:00:00Z', 'test', 1, '2026-10-05T00:00:00Z')", t);
            HubDb.Exec(c, "INSERT INTO journal_lines(entry_id, account_id, debit_minor, credit_minor) VALUES ($e, $a, 500, 0)", t, ("$e", entry), ("$a", account));
        });
        var report = DatabaseCheck.Inspect(off);
        Assert.False(report.Healthy);
        Assert.Contains(report.Problems, p => p.Contains("do not add up") || p.Contains("does not add up"));
        Assert.True(DatabaseCheck.Inspect(off, books: false).Healthy);
    }
}
