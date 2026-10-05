using System.Collections.Generic;

namespace SmartRetail.AI.Assistant
{
    public sealed class QuickInsight
    {
        public QuickInsight(string title, string question, string sql)
        {
            Title = title;
            Question = question;
            Sql = sql;
        }

        public string Title { get; }

        /// <summary>The question the AI answers when it summarises the result.</summary>
        public string Question { get; }

        public string Sql { get; }
    }

    /// <summary>Everyday reports with fixed, reviewed SQL. They work even with no AI provider set up.</summary>
    public static class QuickInsights
    {
        public static readonly IReadOnlyList<QuickInsight> All = new[]
        {
            new QuickInsight(
                "Today's sales",
                "How did sales go today?",
                "SELECT COUNT(*) AS Bills, ISNULL(SUM(GrandTotal), 0) AS Sales, ISNULL(SUM(TotalPaid), 0) AS Collected, ISNULL(SUM(Balance), 0) AS Unpaid "
                + "FROM InvoiceInfo WHERE CAST(InvoiceDate AS date) = CAST(GETDATE() AS date)"),
            new QuickInsight(
                "Last 7 days",
                "How were sales over the last 7 days?",
                "SELECT CAST(InvoiceDate AS date) AS Day, COUNT(*) AS Bills, SUM(GrandTotal) AS Sales "
                + "FROM InvoiceInfo WHERE InvoiceDate >= DATEADD(day, -6, CAST(GETDATE() AS date)) "
                + "GROUP BY CAST(InvoiceDate AS date) ORDER BY Day"),
            new QuickInsight(
                "Top products this month",
                "Which products sold the most this month?",
                "SELECT TOP (10) RTRIM(p.ProductName) AS Product, SUM(ip.Qty) AS Quantity, SUM(ip.TotalAmount) AS Amount "
                + "FROM Invoice_Product ip JOIN InvoiceInfo i ON i.Inv_ID = ip.InvoiceID JOIN Product p ON p.PID = ip.ProductID "
                + "WHERE i.InvoiceDate >= DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1) "
                + "GROUP BY RTRIM(p.ProductName) ORDER BY Amount DESC"),
            new QuickInsight(
                "Low stock",
                "Which items with a reorder level are below it?",
                "SELECT TOP (50) RTRIM(p.ProductCode) AS Code, RTRIM(p.ProductName) AS Product, p.MinStock AS ReorderLevel, SUM(ts.Qty) AS InStock "
                + "FROM Product p JOIN Temp_Stock ts ON ts.ProductID = p.PID WHERE p.MinStock > 0 "
                + "GROUP BY p.PID, p.ProductCode, p.ProductName, p.MinStock HAVING SUM(ts.Qty) >= 0 AND SUM(ts.Qty) < p.MinStock "
                + "ORDER BY SUM(ts.Qty) - p.MinStock"),
            new QuickInsight(
                "Stock to correct",
                "Which products show negative stock, so their purchases or stock were never entered?",
                "SELECT TOP (50) RTRIM(p.ProductCode) AS Code, RTRIM(p.ProductName) AS Product, SUM(ts.Qty) AS InStock "
                + "FROM Product p JOIN Temp_Stock ts ON ts.ProductID = p.PID "
                + "GROUP BY p.PID, p.ProductCode, p.ProductName HAVING SUM(ts.Qty) < 0 "
                + "ORDER BY SUM(ts.Qty)"),
            new QuickInsight(
                "Payments today",
                "How were today's bills paid?",
                "SELECT RTRIM(pay.PaymentMode) AS PaymentMode, COUNT(*) AS Payments, SUM(pay.TotalPaid) AS Amount "
                + "FROM Invoice_Payment pay WHERE CAST(pay.PaymentDate AS date) = CAST(GETDATE() AS date) "
                + "GROUP BY RTRIM(pay.PaymentMode) ORDER BY Amount DESC"),
            new QuickInsight(
                "This month: sales vs expenses",
                "How do this month's sales compare with this month's expenses?",
                "SELECT (SELECT ISNULL(SUM(GrandTotal), 0) FROM InvoiceInfo WHERE InvoiceDate >= DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) AS Sales, "
                + "(SELECT ISNULL(SUM(GrandTotal), 0) FROM Voucher WHERE Date >= DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) AS Expenses"),
        };
    }
}
