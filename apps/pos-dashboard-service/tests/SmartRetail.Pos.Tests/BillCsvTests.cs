using SmartRetail.Pos.Core.Abstractions;
using SmartRetail.Pos.Core.Bills;

namespace SmartRetail.Pos.Tests;

public class BillCsvTests
{
    [Fact]
    public void A_bill_is_one_row_with_plain_dates_and_amounts()
    {
        var bill = new InvoiceSummary
        {
            Id = 2,
            Number = "SR/26-27/0002",
            Date = new DateTime(2026, 9, 24, 9, 30, 0),
            CustomerName = "Priya Sharma",
            GrandTotal = 1000m,
            Balance = 400m,
        };

        Assert.Equal("Bill no.,Date,Time,Customer,Total,Paid,Balance", BillCsv.Header);
        Assert.Equal("SR/26-27/0002,2026-09-24,09:30,Priya Sharma,1000.00,600.00,400.00", BillCsv.Row(bill));
        Assert.Equal("SR/26-27/0003,2026-09-25,,Cash,56.50,56.50,0.00",
            BillCsv.Row(bill with { Number = "SR/26-27/0003", Date = new DateTime(2026, 9, 25), CustomerName = "Cash", GrandTotal = 56.5m, Balance = 0m }));
    }

    [Theory]
    [InlineData("Sharma, Priya", "\"Sharma, Priya\"")]
    [InlineData("Ramu \"Kaka\"", "\"Ramu \"\"Kaka\"\"\"")]
    [InlineData("=HYPERLINK(\"x\")", "\"'=HYPERLINK(\"\"x\"\")\"")]
    [InlineData("+91 98765 43210", "'+91 98765 43210")]
    [InlineData("-5", "'-5")]
    [InlineData("@home", "'@home")]
    [InlineData(" spaced ", "\" spaced \"")]
    [InlineData("सीता देवी", "सीता देवी")]
    [InlineData(null, "")]
    public void Text_is_quoted_when_needed_and_never_read_as_a_formula(string? text, string expected) =>
        Assert.Equal(expected, BillCsv.Cell(text));

    [Fact]
    public void The_file_is_named_after_the_dates_it_covers()
    {
        Assert.Equal("bills.csv", BillCsv.FileName(new BillQuery()));
        Assert.Equal("bills 2026-09-24.csv", BillCsv.FileName(new BillQuery { From = new DateOnly(2026, 9, 24), To = new DateOnly(2026, 9, 24) }));
        Assert.Equal("bills 2026-09-01 to 2026-09-30.csv", BillCsv.FileName(new BillQuery { From = new DateOnly(2026, 9, 1), To = new DateOnly(2026, 9, 30) }));
        Assert.Equal("bills from 2026-09-01.csv", BillCsv.FileName(new BillQuery { From = new DateOnly(2026, 9, 1) }));
        Assert.Equal("bills to 2026-09-30.csv", BillCsv.FileName(new BillQuery { To = new DateOnly(2026, 9, 30) }));
        Assert.Equal(new byte[] { 0xEF, 0xBB, 0xBF }, BillCsv.Encoding.GetPreamble());
    }

    [Fact]
    public void A_search_is_kept_to_sane_values()
    {
        var checkedQuery = new BillQuery
        {
            From = new DateOnly(2026, 9, 30),
            To = new DateOnly(2026, 9, 1),
            Text = "  " + new string('a', 150) + "  ",
            Skip = -5,
            Take = 100_000,
        }.Checked();

        Assert.Equal((new DateOnly(2026, 9, 1), new DateOnly(2026, 9, 30)), (checkedQuery.From, checkedQuery.To));
        Assert.Equal(BillQuery.MaxText, checkedQuery.Text!.Length);
        Assert.Equal((0, BillQuery.MaxTake), (checkedQuery.Skip, checkedQuery.Take));
        Assert.Null(new BillQuery { Text = "   " }.Checked().Text);
        var farOut = new BillQuery { From = DateOnly.MinValue, To = DateOnly.MaxValue }.Checked();
        Assert.Equal((BillQuery.EarliestDate, BillQuery.LatestDate), (farOut.From, farOut.To));
        Assert.Equal(1, new BillQuery { Take = 0 }.Checked().Take);
    }
}
