using SmartRetail.AI.Assistant;
using SmartRetail.AI.Data;
using SmartRetail.Pos.Web.Services;

namespace SmartRetail.Pos.Tests;

public class TableExportTests
{
    private static ChatTable Table() => ChatTable.From(new QueryResult(
        new[] { "Product", "Qty", "Sales", "Last sold", "Active" },
        new List<object[]>
        {
            new object[] { "Tea, 250 g", 4, 1234567.5m, new DateTime(2026, 9, 27, 18, 5, 0), true },
            new object[] { "=HYPERLINK(\"x\")", 2, 310m, new DateTime(2026, 9, 26), DBNull.Value },
            new object[] { "Oil \"Gold\"\n1 L", -3, double.NaN, null!, false },
        },
        truncated: false,
        TimeSpan.Zero))!;

    [Fact]
    public void Copy_gives_the_table_as_it_shows_one_row_a_line()
    {
        var lines = TableExport.Tabs(Table()).Split('\n');
        Assert.Equal("Product\tQty\tSales\tLast sold\tActive", lines[0]);
        Assert.StartsWith("Tea, 250 g\t4\t12,34,567.5\t", lines[1]);
        Assert.EndsWith("\tYes", lines[1]);
        Assert.StartsWith("Oil \"Gold\" 1 L\t-3\t", lines[3]);
    }

    [Fact]
    public void Csv_has_plain_values_quoted_where_needed_and_no_formulas()
    {
        var lines = TableExport.Csv(Table()).Split("\r\n");
        Assert.Equal("Product,Qty,Sales,Last sold,Active", lines[0]);
        Assert.Equal("\"Tea, 250 g\",4,1234567.5,2026-09-27 18:05,TRUE", lines[1]);
        Assert.Equal("\"'=HYPERLINK(\"\"x\"\")\",2,310,2026-09-26,", lines[2]);
        Assert.Equal("\"Oil \"\"Gold\"\"\n1 L\",-3,,,FALSE", lines[3]);
        Assert.Equal("Ask AI 2026-09-27 1843.csv", TableExport.FileName(new DateTime(2026, 9, 27, 18, 43, 10)));
    }
}
