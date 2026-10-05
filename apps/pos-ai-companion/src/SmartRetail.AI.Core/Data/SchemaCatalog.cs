using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using SmartRetail.AI.Settings;

namespace SmartRetail.AI.Data
{
    public sealed class ColumnInfo
    {
        public ColumnInfo(string table, string name, string sqlType)
        {
            Table = table;
            Name = name;
            SqlType = sqlType;
        }

        public string Table { get; }

        public string Name { get; }

        public string SqlType { get; }
    }

    /// <summary>Which POS tables and columns the AI may see, and how they are described to it.</summary>
    public static class SchemaCatalog
    {
        /// <summary>Sales, purchases, stock, parties, payments and expenses.</summary>
        public static readonly IReadOnlyList<string> BusinessTables = new[]
        {
            "InvoiceInfo", "Invoice_Product", "Invoice_Payment", "Product", "Category", "SubCategory", "Temp_Stock",
            "Customer", "Supplier", "Stock", "Stock_Product", "SalesReturn", "SalesReturn_Join", "PurchaseReturn",
            "PurchaseReturn_Join", "Payment", "CreditCustomerPayment", "SalesMan", "Voucher", "Income", "UnitMaster", "Company",
        };

        /// <summary>Tables holding passwords, API keys, licence data, sync state or logs. Never available,
        /// even if listed in the extra tables setting.</summary>
        public static readonly IReadOnlyList<string> DeniedTables = new[]
        {
            "Registration", "Activation", "EmailSetting", "EmailSetting_login", "EwaybillAPISetting", "FTP_Category",
            "WappApi", "tbl_api_setting", "SMSSetting", "GSheet_setting", "Autobackup", "UserControl", "RaintechMaster",
            "AutoMigrationControl", "DataMigration_Logs", "CustomerSupportForm", "Logs", "Android_Apps",
            "ExtDB", "ExtDB1", "ExtDB2",
        };

        private static readonly Regex SecretColumn = new Regex(
            @"pass(word)?|pwd|secret|token|api_?key|apiurl|hardwareid|activationid|admincode|(^|_)otp($|_)",
            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        private static readonly HashSet<string> BankAndIdentityColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "AccountNumber", "AccountName", "Bank", "Branch", "IFSCCode", "PAN", "CIN", "Bankholder", "Bankacno",
            "Bankname", "Bankifsc", "BankAc", "BankAcN", "BankAcNo", "BankAcNum", "BankAcNumber", "BankAccount",
            "AndroidID", "BCode",
        };

        private static readonly HashSet<string> BinaryTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "image", "binary", "varbinary", "timestamp", "rowversion",
        };

        private static readonly HashSet<string> KnownTableSet = new HashSet<string>(PosSchemaData.AllTables, StringComparer.OrdinalIgnoreCase);

        public static IReadOnlyCollection<string> KnownTables => KnownTableSet;

        /// <summary>Passwords, keys and bank details: hidden from the schema and refused in queries.</summary>
        public static bool IsDeniedColumn(string name)
        {
            return !string.IsNullOrEmpty(name) && (SecretColumn.IsMatch(name) || BankAndIdentityColumns.Contains(name));
        }

        public static IReadOnlyList<string> AllowedTables(PrivacySettings privacy)
        {
            var denied = new HashSet<string>(DeniedTables, StringComparer.OrdinalIgnoreCase);
            return BusinessTables
                .Concat(privacy?.ExtraAllowedTables ?? new List<string>())
                .Select(t => (t ?? "").Trim())
                .Where(t => t.Length > 0 && !denied.Contains(t))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        public static SqlGuard CreateGuard(PrivacySettings privacy)
        {
            var allowed = AllowedTables(privacy);
            return new SqlGuard(allowed, KnownTableSet.Concat(allowed), DeniedTables, IsDeniedColumn);
        }

        /// <summary>The columns captured from the POS database script, for when the live database cannot be read.</summary>
        public static IReadOnlyList<ColumnInfo> BuiltInColumns(IEnumerable<string> tables)
        {
            var wanted = new HashSet<string>(tables, StringComparer.OrdinalIgnoreCase);
            return PosSchemaData.Columns
                .Where(c => wanted.Contains(c[0]))
                .Select(c => new ColumnInfo(c[0], c[1], c[2]))
                .ToList();
        }

        /// <summary>Reads the live column list so the prompt matches this shop's POS version.</summary>
        public static async Task<IReadOnlyList<ColumnInfo>> LoadColumnsAsync(IQueryExecutor database, IReadOnlyList<string> tables, CancellationToken cancellationToken)
        {
            var parameters = new Dictionary<string, object>();
            for (var i = 0; i < tables.Count; i++)
            {
                parameters["@t" + i] = tables[i];
            }

            var sql = "SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS "
                + "WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME IN (" + string.Join(", ", parameters.Keys) + ") "
                + "ORDER BY TABLE_NAME, ORDINAL_POSITION";
            var result = await database.QueryAsync(sql, parameters, 10000, cancellationToken).ConfigureAwait(false);

            var columns = new List<ColumnInfo>();
            foreach (var row in result.Rows)
            {
                var type = Convert.ToString(row[2], CultureInfo.InvariantCulture);
                if (row[3] != null)
                {
                    var length = Convert.ToInt64(row[3], CultureInfo.InvariantCulture);
                    type += "(" + (length < 0 ? "max" : length.ToString(CultureInfo.InvariantCulture)) + ")";
                }

                columns.Add(new ColumnInfo(Convert.ToString(row[0], CultureInfo.InvariantCulture), Convert.ToString(row[1], CultureInfo.InvariantCulture), type));
            }

            return columns;
        }

        /// <summary>One line per table ("Table: col type, …"), without private or binary columns.</summary>
        public static string DescribeForPrompt(IEnumerable<ColumnInfo> columns)
        {
            var builder = new StringBuilder();
            foreach (var table in columns.GroupBy(c => c.Table, StringComparer.OrdinalIgnoreCase))
            {
                var visible = table
                    .Where(c => !IsDeniedColumn(c.Name) && !BinaryTypes.Contains(c.SqlType.Split('(')[0]))
                    .Select(c => c.Name + " " + c.SqlType)
                    .ToList();
                if (visible.Count > 0)
                {
                    builder.Append(table.Key).Append(": ").AppendLine(string.Join(", ", visible));
                }
            }

            return builder.ToString();
        }

        /// <summary>How the POS uses its tables; checked against the POS's own queries.</summary>
        public const string BusinessNotes = @"- Sales bills: InvoiceInfo, one row per bill. Key Inv_ID. InvoiceDate is the bill date only, with no time of day, so these tables cannot split sales by hour: for busy hours, point the owner to 'Sales by hour of day' on the Sales page of the dashboard, which reads the times from the POS log. GrandTotal is the bill total including tax; TotalPaid is what was paid on the bill; Balance is the unpaid part. CGST, SGST, IGST and CESS are tax amounts; TaxableAmt is the value before tax. InvoiceInfo.Customer_ID = Customer.ID. InvoiceInfo.SalesmanID = SalesMan.SM_ID.
- Bill lines: Invoice_Product. Invoice_Product.InvoiceID = InvoiceInfo.Inv_ID; Invoice_Product.ProductID = Product.PID. Qty, SalesRate, Discount, TotalAmount (line total incl. tax), PurchaseRate, Margin.
- Payments on bills: Invoice_Payment. Invoice_Payment.InvoiceID = InvoiceInfo.Inv_ID. PaymentMode holds values such as 'By Cash' (most bills), 'Google Pay', 'PhonePe', 'Paytm', 'Credit Terms - 7 days', 'By Credit Card', 'By Debit Card', 'By Cheque' and 'E-Wallet' (some shops write 'Cash'), so find cash with PaymentMode LIKE '%Cash%'; TotalPaid; PaymentDate.
- Products: Product (key PID; ProductName, ProductCode, Barcode, SellingPrice, CostPrice, MRP, HSNCode; MinStock = reorder level). Many products sit in the GENERAL category. Product.SubCategoryID = SubCategory.ID; SubCategory.Category holds the category name (Category.CategoryName).
- Current stock: Temp_Stock. Temp_Stock.ProductID = Product.PID. A product can have several rows (batches, prices), so stock in hand = SUM(Temp_Stock.Qty) per product. Low stock = the product has a reorder level (Product.MinStock > 0) and SUM(Temp_Stock.Qty) < Product.MinStock. Negative stock means sales were billed before the stock was entered: a record to correct, not low stock.Qty) < Product.MinStock.
- Customers: bills without a named customer use a default walk-in customer (usually Customer.ID = 1, named like 'Cash'); leave it out when counting repeat or top customers.
- Purchases: Stock, one row per purchase bill (key ST_ID; Date; GrandTotal; TotalPayment; PaymentDue). Stock.SupplierID = Supplier.ID. Lines: Stock_Product.StockID = Stock.ST_ID; Stock_Product.ProductID = Product.PID; Qty, Price, TotalAmount.
- Returns: SalesReturn.SalesID = InvoiceInfo.Inv_ID; SalesReturn_Join.SalesReturnID = SalesReturn.SR_ID. PurchaseReturn.PurchaseID = Stock.ST_ID; PurchaseReturn_Join.PurchaseReturnID = PurchaseReturn.PR_ID.
- Money: CreditCustomerPayment = money received from customers (CreditCustomerPayment.Customer_ID = Customer.ID; Amount; Date). Payment = money paid to suppliers (Payment.SupplierID = Supplier.ID; Amount; Date). Voucher = expenses (Date, Name, GrandTotal). Income = other income.
- Text columns are fixed-width nchar: use RTRIM() when showing, grouping or comparing text.
- Amounts are Indian Rupees. The Indian financial year runs from 1 April to 31 March.";
    }
}
