using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace SmartRetail.Pos.Tests.SqlServer;

/// <summary>
/// A throwaway database built from the real POS table definitions (pos_schema_subset.sql) and filled
/// with a few made-up rows. Created once per test class and dropped afterwards.
/// </summary>
public sealed class PosTestDatabase : IAsyncLifetime
{
    public const string EnvironmentVariable = "POS_TEST_SQL";

    private const string Seed = @"
INSERT INTO Category (CategoryName) VALUES (N'Staples'), (N'Dairy');
INSERT INTO SubCategory (ID, SubCategoryName, Category) VALUES (1, N'Rice', N'Staples'), (2, N'Milk', N'Dairy');
INSERT INTO Product (PID, ProductCode, ProductName, SubCategoryID, HSNCode, CostPrice, SellingPrice, Discount, CGST, SGST, Barcode, MinStock, MRP) VALUES
    (1, N'1001', N'Basmati Rice 5 kg', 1, N'1006', 480, 549, 0, 2.5, 2.5, N'2000000000011', 10, 599),
    (2, N'1002', N'Toned Milk 500 ml', 2, N'0401', 25, 28, 0, 0, 0, N'2000000000028', 24, 28),
    (3, N'1003', N'Cashback 50% Pack', 1, NULL, 90, 100, 0, 9, 9, NULL, 0, 110),
    (4, N'10_4', N'Under_score Item', 1, NULL, 10, 12, 0, NULL, NULL, NULL, NULL, 12);
INSERT INTO Temp_Stock (ProductID, Qty, Barcode) VALUES (1, 4, N'RICE-BATCH-A'), (1, 3, NULL), (2, 30, NULL), (3, 5, NULL);
INSERT INTO Customer (ID, Name, ContactNo) VALUES (1, N'Cash', NULL), (2, N'Priya Sharma', N'9000000102'), (3, N'Ramesh Kumar', N'9000000101');
INSERT INTO InvoiceInfo (Inv_ID, InvoiceNo, InvoiceDate, Customer_ID, GrandTotal, TotalPaid, Balance) VALUES
    (1, N'SR/26-27/0001', '2026-09-23T10:00:00', 1, 549, 549, 0),
    (2, N'SR/26-27/0002', '2026-09-24T09:30:00', 2, 1000, 600, 400),
    (3, N'SR/26-27/0003', '2026-09-24T18:45:00', 3, 56, 56, 0),
    (4, N'SR/26-27/0004', '2026-09-25T00:00:00', 1, 99, 99, 0);
INSERT INTO Invoice_Product (InvoiceID, ProductID, SalesRate, Qty, DiscountPer, Discount, CGSTPer, CGSTAmt, TotalAmount, TaxableAmt, PurchaseRate, Margin) VALUES
    (1, 1, 549, 1, 0, 0, 2.5, 13.07, 549, 522.86, 480, 42.86),
    (2, 1, 549, 1, 0, 0, 2.5, 13.07, 549, 522.86, 480, 42.86),
    (2, 3, 112.75, 4, 0, 0, 9, 34.40, 451, 382.20, 0, 382.20),
    (3, 2, 28, 2, 0, 0, 0, 0, 56, NULL, 25, 6),
    (4, 4, 12, 8.25, 0, 0, 0, 0, 99, 99, 10, 16.50);
INSERT INTO Invoice_Payment (InvoiceID, PaymentDate, TotalPaid, PaymentMode) VALUES
    (1, '2026-09-23T10:00:00', 549, N'By Cash'),
    (2, '2026-09-24T09:30:00', 600, N'Google Pay'),
    (3, '2026-09-24T18:45:00', 56, N'By Cash'),
    (4, '2026-09-25T00:00:00', 99, N'By Credit Card');
UPDATE InvoiceInfo SET SubTotal = 1000, CGST = 47.47, SGST = 0, RoundOff = 0, Operator = N'counter1', Remarks = N'Pays the rest on Friday' WHERE Inv_ID = 2;
UPDATE Invoice_Product SET Descr = N'Cashback Pack (old name)', MainUnit = N'PCS', MRP = 110 WHERE InvoiceID = 2 AND ProductID = 3;
INSERT INTO SalesReturn (SR_ID, SRNo, [Date], SalesID, GrandTotal, PaymentMode) VALUES
    (1, N'SRN/1', '2026-09-24T12:00:00', 2, 100, N'Cash');
-- When the bills were saved, as the POS logs it. Bill 2's number was used, deleted and used again; bill 3 was typed
-- in two days after its date; bill 4 is only a held bill in the log.
INSERT INTO Logs (UserID, Operation, [Date]) VALUES
    (N'admin', N'Successfully logged in', '2026-09-23T09:55:00'),
    (N'admin', N'added the new bill (Products) having invoice no. ''SR/26-27/0001''', '2026-09-23T10:02:11'),
    (N'admin', N'added the new customer ''Ramesh Kumar''', '2026-09-24T09:00:00'),
    (N'admin', N'added the new bill (Products) having invoice no. ''SR/26-27/0002''', '2026-09-24T09:31:00'),
    (N'admin', N'deleted the bill (Products) having invoice no. ''SR/26-27/0002''', '2026-09-24T09:40:00'),
    (N'admin', N'added the new bill (Products) having invoice no. ''SR/26-27/0002''', '2026-09-24T11:15:30'),
    (N'admin', N'updated the bill (Products) having invoice no. ''SR/26-27/0001''', '2026-09-24T12:00:00'),
    (N'admin', N'added the new hold bill (Products) having invoice no. ''SR/26-27/0004''', '2026-09-25T08:00:00'),
    (N'admin', N'added the new bill (Products) having invoice no. ''SR/26-27/0003''', '2026-09-26T10:05:00');";

    private string? _serverConnectionString;

    public string DatabaseName { get; } = "PosTest_" + Guid.NewGuid().ToString("N")[..12];
    public string ConnectionString { get; private set; } = "";

    public async Task InitializeAsync()
    {
        _serverConnectionString = Environment.GetEnvironmentVariable(EnvironmentVariable);
        if (string.IsNullOrWhiteSpace(_serverConnectionString))
        {
            return;
        }

        await ExecuteAsync(_serverConnectionString, $"CREATE DATABASE [{DatabaseName}]");
        ConnectionString = new SqlConnectionStringBuilder(_serverConnectionString) { InitialCatalog = DatabaseName }.ConnectionString;

        foreach (var batch in SchemaBatches())
        {
            await ExecuteAsync(ConnectionString, batch);
        }
        await ExecuteAsync(ConnectionString, Seed);
    }

    public async Task DisposeAsync()
    {
        if (string.IsNullOrWhiteSpace(_serverConnectionString))
        {
            return;
        }

        SqlConnection.ClearAllPools();
        await ExecuteAsync(_serverConnectionString,
            $"ALTER DATABASE [{DatabaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [{DatabaseName}];");
    }

    /// <summary>Runs <paramref name="sql"/> on this database: rows only one test class needs.</summary>
    public Task ExecuteAsync(string sql) => ExecuteAsync(ConnectionString, sql);

    private static IEnumerable<string> SchemaBatches()
    {
        using var stream = typeof(PosTestDatabase).Assembly.GetManifestResourceStream("pos_schema_subset.sql")
            ?? throw new InvalidOperationException("pos_schema_subset.sql is not embedded in the test assembly.");
        using var reader = new StreamReader(stream);
        return Regex.Split(reader.ReadToEnd(), @"^\s*GO\s*$", RegexOptions.Multiline)
            .Select(b => b.Trim())
            .Where(b => b.Length > 0)
            .ToList();
    }

    private static async Task ExecuteAsync(string connectionString, string sql)
    {
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        await using var command = connection.CreateCommand();
        command.CommandText = sql;
        await command.ExecuteNonQueryAsync();
    }
}
