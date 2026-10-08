using System.Reflection;
using System.Text.RegularExpressions;
using NextGenOS.Hub.Import;

namespace NextGenOS.Hub.Tests;

/// <summary>Step 6 of the shop database (the memory of a move from an older system), and the rule that the reader of the older POS's database only reads.</summary>
public class ImportLogTests
{
    private static readonly string[] ImportTables = ["import_id_map", "import_runs", "party_opening_balances"];

    private static string[] Tables(HubApp app) => app.Db.Query("SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%' ORDER BY name", r => r.GetString(0)).ToArray();

    [Fact]
    public void The_import_tables_exist_are_empty_and_carry_tenant_and_site()
    {
        using var f = new HubFixture();
        Assert.Subset(Tables(f.App).ToHashSet(), ImportTables.ToHashSet());
        foreach (var table in ImportTables)
        {
            var columns = f.App.Db.Query($"SELECT name FROM pragma_table_info('{table}')", r => r.GetString(0));
            Assert.Contains("tenant_id", columns);
            Assert.Contains("site_id", columns);
            Assert.Equal(0L, Convert.ToInt64(f.App.Db.Scalar($"SELECT COUNT(*) FROM {table}")));
        }
        // The defaults are the ones the rest of the database uses.
        var defaults = f.App.Db.Query("SELECT name, dflt_value FROM pragma_table_info('import_runs') WHERE name IN ('tenant_id', 'site_id') ORDER BY name", r => (r.GetString(0), r.GetString(1)));
        Assert.Equal([("site_id", "'main'"), ("tenant_id", "'local'")], defaults);
        // A password has nowhere to go: no column of the import tables is named for one.
        foreach (var table in ImportTables)
            Assert.DoesNotContain(f.App.Db.Query($"SELECT name FROM pragma_table_info('{table}')", r => r.GetString(0)), c => c.Contains("pass", StringComparison.OrdinalIgnoreCase) || c.Contains("secret", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void Undoing_step_6_removes_only_its_tables_keeps_the_shops_records_and_can_be_run_forward_again()
    {
        using var f = new HubFixture();
        f.App.Catalog.Create(new NextGenOS.Hub.Catalog.ItemInput { Kind = "stock", Name = "Rice", PriceMinor = 42500, TaxClass = "standard" });
        f.App.Parties.Create(new NextGenOS.Hub.Catalog.PartyInput { Kind = "customer", Name = "Asha" });
        var before = Tables(f.App).Except(ImportTables).Except(new[] { "accounts", "journal_entries", "journal_lines", "loyalty_ledger", "offers", "vouchers", "document_offers", "party_discounts" }).ToArray();

        f.App.Db.Rollback(5);

        Assert.Equal(before, Tables(f.App));
        Assert.Equal(new long[] { 1, 2, 3, 4, 5 }, f.App.Db.Query("SELECT version FROM schema_version ORDER BY version", r => r.GetInt64(0)).ToArray());
        Assert.Equal("Rice", f.App.Db.Scalar("SELECT name FROM items"));
        Assert.Equal("Asha", f.App.Db.Scalar("SELECT name FROM parties"));
        Assert.True(File.Exists(f.App.Db.LastBackup));

        var again = HubApp.OpenTrusted(f.App.Db.Path, f.Clock);
        Assert.Subset(Tables(again).ToHashSet(), ImportTables.ToHashSet());
        Assert.Equal(Enumerable.Range(1, NextGenOS.Hub.Data.HubDb.LatestVersion).Select(v => (long)v).ToArray(), again.Db.Query("SELECT version FROM schema_version ORDER BY version", r => r.GetInt64(0)).ToArray());
        Assert.Equal("Rice", again.Db.Scalar("SELECT name FROM items"));
    }

    [Fact]
    public void A_copy_of_the_database_can_be_made_on_request_and_holds_the_shop_as_it_was()
    {
        using var f = new HubFixture();
        f.App.Catalog.Create(new NextGenOS.Hub.Catalog.ItemInput { Kind = "stock", Name = "Sugar", PriceMinor = 5000, TaxClass = "standard" });
        var copy = f.App.Db.BackupNow("before-import-test");
        Assert.True(File.Exists(copy));
        Assert.Contains("before-import-test", copy);
        f.App.Catalog.Create(new NextGenOS.Hub.Catalog.ItemInput { Kind = "stock", Name = "Tea", PriceMinor = 9000, TaxClass = "standard" });
        var old = new NextGenOS.Hub.Data.HubDb(copy);
        Assert.Equal(1L, Convert.ToInt64(old.Scalar("SELECT COUNT(*) FROM items")));
    }

    // ---- the reader only reads -------------------------------------------------------------------------------------------------

    /// <summary>A second, separate list of what must never appear (so the test does not trust the reader's own list).</summary>
    private static readonly string[] WriteWords =
    [
        "INSERT", "UPDATE", "DELETE", "MERGE", "DROP", "ALTER", "CREATE", "TRUNCATE", "EXEC", "EXECUTE", "GRANT", "REVOKE", "DENY", "BACKUP", "RESTORE", "INTO", "BULK",
        "DBCC", "SHUTDOWN", "KILL", "SET", "DECLARE", "OPENROWSET", "OPENQUERY", "OPENDATASOURCE", "WAITFOR", "USE", "GO", "TRAN", "TRANSACTION", "COMMIT", "ROLLBACK",
    ];

    [Fact]
    public void Every_statement_the_reader_can_send_starts_with_SELECT_and_holds_no_word_that_writes()
    {
        Assert.NotEmpty(PosSqlServerQueries.All);
        foreach (var sql in PosSqlServerQueries.All)
        {
            Assert.StartsWith("SELECT ", sql.TrimStart(), StringComparison.OrdinalIgnoreCase);
            Assert.DoesNotContain(';', sql);
            Assert.DoesNotContain("--", sql);
            Assert.DoesNotContain("/*", sql);
            var outsideQuotes = Regex.Replace(sql, "'(?:[^']|'')*'", " ");
            var words = Regex.Matches(outsideQuotes, "[A-Za-z_][A-Za-z0-9_]*").Select(m => m.Value.ToUpperInvariant()).ToHashSet();
            Assert.Empty(words.Intersect(WriteWords));
            Assert.True(ReadOnlySql.IsReadOnly(sql, out var reason), reason);
        }
    }

    [Fact]
    public void No_statement_escapes_the_list_every_text_constant_of_the_query_class_is_in_it()
    {
        var constants = typeof(PosSqlServerQueries).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(f => f.IsLiteral && f.FieldType == typeof(string)).Select(f => (string)f.GetRawConstantValue()!).ToList();
        Assert.True(constants.Count >= 9);
        Assert.Equivalent(constants, PosSqlServerQueries.All);
    }

    [Theory]
    [InlineData("UPDATE Product SET CostPrice = 0")]
    [InlineData("DELETE FROM Customer")]
    [InlineData("SELECT * FROM Product; DROP TABLE Product")]
    [InlineData("SELECT * INTO Copy FROM Product")]
    [InlineData("SELECT 1 -- then something else")]
    [InlineData("SELECT * FROM Product /* x */")]
    [InlineData("EXEC sp_who")]
    [InlineData("  insert into Product values (1)")]
    [InlineData("SELECTED FROM Product")]
    [InlineData("SELECT * FROM Product WITH (UPDLOCK)")]
    [InlineData("")]
    public void A_statement_that_is_not_one_plain_SELECT_is_refused_before_it_is_sent(string sql)
    {
        Assert.False(ReadOnlySql.IsReadOnly(sql, out var reason));
        Assert.NotEmpty(reason);
        Assert.Throws<InvalidOperationException>(() => ReadOnlySql.Require(sql));
    }

    [Fact]
    public void A_word_inside_a_quoted_text_is_data_not_a_command()
    {
        Assert.True(ReadOnlySql.IsReadOnly("SELECT PartyID FROM CustomerLedgerBook WHERE Label = 'Update it'", out _));
    }

    // ---- the password stays in memory -----------------------------------------------------------------------------------------

    [Fact]
    public void A_server_that_cannot_be_reached_gives_a_plain_message_that_never_holds_the_password_or_the_user()
    {
        const string password = "Zq9!-secret-never-seen";
        using var source = new PosSqlServerSource("127.0.0.1,1", "ShopData", "reader_account", password);
        var shown = source.ToString() + source.Describe + source.SourceId + source.Kind;
        Assert.DoesNotContain(password, shown);
        Assert.DoesNotContain("reader_account", shown);

        var ex = Assert.Throws<HubException>(() => source.Read());
        // In a program built like the Hub (no system language data) the driver refuses to connect at all, and the reader says so in plain words (docs/OPEN-WORK.md: not settled).
        // In a program that has the language data, a refused connection gives one of the other plain "import-" messages. Either way: plain words, no secrets.
        Assert.Equal(PosSqlServerSource.InvariantGlobalization, ex.Code == "import-globalization");
        Assert.StartsWith("import-", ex.Code);
        Assert.DoesNotContain(password, ex.Message);
        Assert.DoesNotContain(password, ex.ToString());
        Assert.DoesNotContain("reader_account", ex.Message);
        Assert.DoesNotContain("SqlException", ex.Message);
    }

    [Fact]
    public void Missing_details_are_asked_for_in_plain_words_before_any_connection_is_tried()
    {
        using var noServer = new PosSqlServerSource("", "db", "u", "p");
        Assert.Equal("import-server", Assert.Throws<HubException>(() => noServer.Read()).Code);
        using var noDatabase = new PosSqlServerSource("srv", " ", "u", "p");
        Assert.Equal("import-database", Assert.Throws<HubException>(() => noDatabase.Read()).Code);
        using var noPassword = new PosSqlServerSource("srv", "db", "u", "");
        Assert.Equal("import-login", Assert.Throws<HubException>(() => noPassword.Read()).Code);
    }
}
