namespace NextGenOS.Hub.Import;

/// <summary>
/// Every SQL statement the reader of the older POS's database may send, written out here and nowhere else. Each is one SELECT with nothing typed in by a person (so there is
/// nothing to inject and no parameter to forget). <see cref="All"/> lists them all: a test proves that each one starts with SELECT and holds no word that writes, and the reader
/// checks each again (<see cref="ReadOnlySql"/>) before it is sent. Table and column names are the older program's own (docs/old-programs/DATABASE.md says what each means).
/// </summary>
public static class PosSqlServerQueries
{
    /// <summary>Which of the tables and columns this reader needs are really in the database (so that a wrong database gives a plain message, not a raw SQL error).</summary>
    public const string Schema =
        "SELECT TABLE_NAME, COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS " +
        "WHERE TABLE_NAME IN ('Product', 'Temp_Stock', 'Category', 'SubCategory', 'Customer', 'Supplier', 'CustomerLedgerBook', 'SupplierLedgerBook')";

    public const string Products =
        "SELECT PID, RTRIM(ProductCode), RTRIM(ProductName), SubCategoryID, RTRIM(HSNCode), CostPrice, SellingPrice, ReorderPoint, MRP, " +
        "CGST, SGST, CESS, " +   // white-label-ok: the older POS's own column names (docs/old-programs/DATABASE.md)
        "RTRIM(Barcode), RTRIM(SalesUnit), MinStock, RTRIM(Status), RTRIM(STax) FROM Product ORDER BY PID";

    public const string Lots =
        "SELECT Id, ProductID, RTRIM(Barcode), Qty, Damage, MRP, SPrice, WPrice, RTRIM(Batch), RTRIM(Size), RTRIM(Colour) FROM Temp_Stock ORDER BY Id";

    public const string Categories = "SELECT ID, RTRIM(CategoryName) FROM Category ORDER BY ID";

    public const string SubCategories = "SELECT ID, RTRIM(SubCategoryName), RTRIM(Category) FROM SubCategory ORDER BY ID";

    public const string Customers =
        "SELECT ID, RTRIM(CustomerID), RTRIM(Name), RTRIM(Address), RTRIM(City), RTRIM(State), RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID), Remarks, " +
        "RTRIM(GSTIN), " +   // white-label-ok: the older POS's own column name
        "RTRIM(Optype), Opbal, RTRIM(CardNo), [Limit], RTRIM(Lstatus), DiscPer, RTRIM(DiscStatus) FROM Customer ORDER BY ID";

    public const string Suppliers =
        "SELECT ID, RTRIM(SupplierID), RTRIM(Name), RTRIM(Address), RTRIM(City), RTRIM(State), RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID), Remarks, " +
        "RTRIM(GSTIN), " +   // white-label-ok: the older POS's own column name
        "RTRIM(OpeningBalanceType), OpeningBalance, [Limit], RTRIM(Lstatus) FROM Supplier ORDER BY ID";

    /// <summary>One row per customer code: what was debited and credited over all dates, how many rows, and how many of them are the posted opening balance.</summary>
    public const string CustomerLedger =
        "SELECT RTRIM(PartyID), ISNULL(SUM(Debit), 0), ISNULL(SUM(Credit), 0), COUNT(*), " +
        "SUM(CASE WHEN RTRIM(Label) = 'Opening Balance' THEN 1 ELSE 0 END) FROM CustomerLedgerBook GROUP BY RTRIM(PartyID)";

    public const string SupplierLedger =
        "SELECT RTRIM(PartyID), ISNULL(SUM(Debit), 0), ISNULL(SUM(Credit), 0), COUNT(*), " +
        "SUM(CASE WHEN RTRIM(Label) = 'Opening Balance' THEN 1 ELSE 0 END) FROM SupplierLedgerBook GROUP BY RTRIM(PartyID)";

    /// <summary>Every statement the reader may send. A new one must be added here, or the test that checks them all will not see it.</summary>
    public static IReadOnlyList<string> All { get; } = [Schema, Products, Lots, Categories, SubCategories, Customers, Suppliers, CustomerLedger, SupplierLedger];

    /// <summary>The tables and columns the statements above need (checked against the database before anything is read).</summary>
    public static IReadOnlyDictionary<string, string[]> RequiredColumns { get; } = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase)
    {
        ["Product"] = ["PID", "ProductCode", "ProductName", "SubCategoryID", "HSNCode", "CostPrice", "SellingPrice", "ReorderPoint", "MRP",
            "CGST", "SGST", "CESS", "Barcode", "SalesUnit", "MinStock", "Status", "STax"],   // white-label-ok: the older POS's own column names
        ["Temp_Stock"] = ["Id", "ProductID", "Barcode", "Qty", "Damage", "MRP", "SPrice", "WPrice", "Batch", "Size", "Colour"],
        ["Category"] = ["ID", "CategoryName"],
        ["SubCategory"] = ["ID", "SubCategoryName", "Category"],
        ["Customer"] = ["ID", "CustomerID", "Name", "Address", "City", "State", "ZipCode", "ContactNo", "EmailID", "Remarks",
            "GSTIN", "Optype", "Opbal", "CardNo", "Limit", "Lstatus", "DiscPer", "DiscStatus"],   // white-label-ok: the older POS's own column names
        ["Supplier"] = ["ID", "SupplierID", "Name", "Address", "City", "State", "ZipCode", "ContactNo", "EmailID", "Remarks",
            "GSTIN", "OpeningBalanceType", "OpeningBalance", "Limit", "Lstatus"],   // white-label-ok: the older POS's own column names
        ["CustomerLedgerBook"] = ["PartyID", "Debit", "Credit", "Label"],
        ["SupplierLedgerBook"] = ["PartyID", "Debit", "Credit", "Label"],
    };
}

/// <summary>
/// The rule that the reader never writes: a statement is accepted only if it is a single SELECT. It is checked here before every statement is sent, and again by a test over every
/// statement the reader has. It is one layer: the owner is also told to use a database login that can only read, and the connection says "read only" to the server.
/// </summary>
public static class ReadOnlySql
{
    private static readonly string[] Forbidden =
    [
        "INSERT", "UPDATE", "DELETE", "MERGE", "DROP", "ALTER", "CREATE", "TRUNCATE", "EXEC", "EXECUTE", "GRANT", "REVOKE", "DENY", "BACKUP", "RESTORE", "SHUTDOWN",
        "DBCC", "KILL", "RECONFIGURE", "OPENROWSET", "OPENQUERY", "OPENDATASOURCE", "OPENXML", "BULK", "INTO", "WAITFOR", "USE", "DECLARE", "SET", "GO", "RAISERROR", "THROW",
        "CHECKPOINT", "TRAN", "TRANSACTION", "COMMIT", "ROLLBACK", "SAVE", "REVERT", "SETUSER", "UPDLOCK", "XLOCK", "TABLOCK", "TABLOCKX", "HOLDLOCK",
    ];

    /// <summary>True when the statement is one SELECT and holds no word that writes, changes the structure, runs another program or asks for a lock. The reason says why not.</summary>
    public static bool IsReadOnly(string sql, out string reason)
    {
        reason = "";
        if (string.IsNullOrWhiteSpace(sql)) { reason = "The statement is empty."; return false; }
        var text = sql.Trim();
        if (!text.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase) || (text.Length > 6 && char.IsLetterOrDigit(text[6]))) { reason = "A statement must start with SELECT."; return false; }
        if (text.Contains(';') || text.Contains("--", StringComparison.Ordinal) || text.Contains("/*", StringComparison.Ordinal)) { reason = "A statement may not hold a semicolon or a comment."; return false; }
        // Words inside quotes ('Opening Balance') are data, not commands: leave them out before looking for words.
        var outside = System.Text.RegularExpressions.Regex.Replace(text, "'(?:[^']|'')*'", " ");
        foreach (var word in System.Text.RegularExpressions.Regex.Matches(outside, "[A-Za-z_][A-Za-z0-9_]*").Select(m => m.Value))
            if (Forbidden.Contains(word, StringComparer.OrdinalIgnoreCase)) { reason = "The word " + word.ToUpperInvariant() + " is not allowed: the reader only reads."; return false; }
        return true;
    }

    /// <summary>Throws if the statement is not read-only. The reader calls this for every statement, so a wrong one is stopped before it is sent.</summary>
    public static string Require(string sql)
    {
        if (!IsReadOnly(sql, out var reason)) throw new InvalidOperationException("Refused to send a statement to the old database: " + reason);
        return sql;
    }
}
