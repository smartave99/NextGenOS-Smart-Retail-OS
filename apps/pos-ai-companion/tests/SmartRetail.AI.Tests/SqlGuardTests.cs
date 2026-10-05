using SmartRetail.AI.Data;
using SmartRetail.AI.Settings;
using Xunit;

namespace SmartRetail.AI.Tests
{
    public class SqlGuardTests
    {
        private static SqlGuardResult Check(string sql) => SchemaCatalog.CreateGuard(new PrivacySettings()).Check(sql);

        [Theory]
        [InlineData("SELECT COUNT(*) FROM InvoiceInfo")]
        [InlineData("select count(*) from invoiceinfo")]
        [InlineData("SELECT TOP (5) RTRIM(p.ProductName) AS Product, SUM(ip.Qty) AS Qty FROM Invoice_Product ip JOIN Product p ON p.PID = ip.ProductID GROUP BY RTRIM(p.ProductName) ORDER BY Qty DESC;")]
        [InlineData("WITH s AS (SELECT Customer_ID, SUM(GrandTotal) AS Total FROM InvoiceInfo GROUP BY Customer_ID) SELECT TOP 10 RTRIM(c.Name) AS Name, s.Total FROM s JOIN Customer c ON c.ID = s.Customer_ID ORDER BY s.Total DESC")]
        [InlineData("WITH a (x) AS (SELECT 1), b AS (SELECT GrandTotal FROM InvoiceInfo) SELECT * FROM a, b")]
        [InlineData("SELECT ProductCode, SUM(Temp_Stock.Qty) FROM Temp_Stock,Product WHERE Product.PID=Temp_Stock.ProductID GROUP BY ProductCode")]
        [InlineData("SELECT i.GrandTotal FROM dbo.InvoiceInfo i")]
        [InlineData("SELECT [GrandTotal] FROM [dbo].[InvoiceInfo]")]
        [InlineData("SELECT x.Total FROM (SELECT SUM(GrandTotal) AS Total FROM InvoiceInfo) AS x")]
        [InlineData("SELECT COUNT(*) FROM InvoiceInfo WITH (NOLOCK)")]
        [InlineData("SELECT COUNT(*) FROM InvoiceInfo i LEFT JOIN Customer c ON c.ID = i.Customer_ID WHERE c.ID IS NULL")]
        [InlineData("SELECT 1 /* a /* nested */ b */ FROM InvoiceInfo")]
        [InlineData("SELECT RTRIM(Name) FROM Customer WHERE Name LIKE N'%राम%'")]
        [InlineData("SELECT InvoiceNo FROM InvoiceInfo ORDER BY InvoiceDate DESC OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY")]
        [InlineData("SELECT RTRIM(Name) AS Name FROM Customer UNION ALL SELECT RTRIM(Name) FROM Supplier")]
        public void Allows_single_read_only_selects(string sql)
        {
            var result = Check(sql);
            Assert.True(result.IsAllowed, result.Reason);
        }

        [Fact]
        public void Keywords_inside_strings_are_allowed_and_the_string_is_kept()
        {
            var result = Check("SELECT COUNT(*) FROM InvoiceInfo WHERE Remarks = 'please delete; drop table x'");
            Assert.True(result.IsAllowed, result.Reason);
            Assert.Contains("'please delete; drop table x'", result.Sql);
        }

        [Fact]
        public void Comments_and_trailing_semicolons_are_removed_from_the_statement_to_run()
        {
            var result = Check("SELECT GrandTotal -- DROP TABLE Product\nFROM InvoiceInfo;;");
            Assert.True(result.IsAllowed, result.Reason);
            Assert.DoesNotContain("DROP", result.Sql);
            Assert.EndsWith("InvoiceInfo", result.Sql);
        }

        [Theory]
        [InlineData("DELETE FROM InvoiceInfo", "Only SELECT")]
        [InlineData("/* hi */ UPDATE InvoiceInfo SET GrandTotal = 0", "Only SELECT")]
        [InlineData("EXEC xp_cmdshell 'dir'", "Only SELECT")]
        [InlineData("SELECT * FROM InvoiceInfo; DROP TABLE Product", "one SQL statement")]
        [InlineData("SELECT 1; SELECT 2", "one SQL statement")]
        [InlineData("SELECT * INTO Backup FROM InvoiceInfo", "INTO")]
        [InlineData("WITH x AS (DELETE FROM InvoiceInfo) SELECT 1", "DELETE")]
        [InlineData("SELECT * FROM InvoiceInfo WAITFOR DELAY '00:00:10'", "WAITFOR")]
        [InlineData("SELECT * FROM Registration", "Registration")]
        [InlineData("SELECT Password FROM Customer", "Password")]
        [InlineData("SELECT RTRIM(AccountNumber) FROM Customer", "AccountNumber")]
        [InlineData("SELECT * FROM sys.objects", "System")]
        [InlineData("SELECT * FROM sysobjects", "System")]
        [InlineData("SELECT * FROM dbo.sysdatabases", "System")]
        [InlineData("SELECT * FROM INFORMATION_SCHEMA.TABLES", "INFORMATION_SCHEMA")]
        [InlineData("SELECT * FROM OPENROWSET('SQLNCLI', 'x', 'y')", "OPENROWSET")]
        [InlineData("SELECT * FROM master..sysdatabases", "sysdatabases")]
        [InlineData("SELECT * FROM OtherDb..InvoiceInfo", "..")]
        [InlineData("SELECT * FROM OtherDb.dbo.InvoiceInfo", "Three-part")]
        [InlineData("SELECT * FROM Estimate", "Estimate")]
        [InlineData("SELECT * FROM NotATable", "NotATable")]
        [InlineData("SELECT @@VERSION", "Variables")]
        [InlineData("SELECT * FROM #temp", "temporary")]
        [InlineData("SELECT value FROM STRING_SPLIT('a,b', ',')", "Functions")]
        [InlineData("SELECT * FROM Customer c CROSS APPLY dbo.fn_x(c.ID)", "fn_x")]
        [InlineData("SELECT * FROM InvoiceInfo WHERE Remarks = 'unterminated", "not closed")]
        [InlineData("SELECT * FROM InvoiceInfo /* unclosed", "not closed")]
        [InlineData("SELECT * FROM archive.InvoiceInfo", "dbo schema")]
        [InlineData("SELECT * FROM InvoiceInfo WITH (TABLOCKX, HOLDLOCK)", "TABLOCKX")]
        [InlineData("SELECT * FROM Product p WITH (UPDLOCK) WHERE p.PID = 1", "UPDLOCK")]
        [InlineData("SELECT NEXT VALUE FOR dbo.InvoiceSeq", "NEXT VALUE FOR")]
        [InlineData("SELECT Remarks FROM InvoiceInfo UNION SELECT Password FROM Registration", "Password")]
        [InlineData("SELECT * FROM InvoiceInfo WHERE EXISTS (SELECT 1 FROM Activation)", "Activation")]
        [InlineData("   ", "empty")]
        public void Refuses_anything_else(string sql, string expectedReason)
        {
            var result = Check(sql);
            Assert.False(result.IsAllowed);
            Assert.Contains(expectedReason, result.Reason, System.StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void Extra_tables_can_be_allowed_but_denied_tables_never()
        {
            var privacy = new PrivacySettings();
            privacy.ExtraAllowedTables.Add("Estimate");
            privacy.ExtraAllowedTables.Add("Registration");
            var guard = SchemaCatalog.CreateGuard(privacy);

            Assert.True(guard.Check("SELECT * FROM Estimate").IsAllowed);
            Assert.False(guard.Check("SELECT * FROM Registration").IsAllowed);
        }
    }
}
