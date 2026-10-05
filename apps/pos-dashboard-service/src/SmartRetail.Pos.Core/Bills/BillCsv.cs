using System.Globalization;
using System.Text;
using SmartRetail.Pos.Core.Abstractions;

namespace SmartRetail.Pos.Core.Bills;

/// <summary>Bills as a CSV file for a spreadsheet: one row per bill, dates as dates and amounts as plain numbers.</summary>
public static class BillCsv
{
    /// <summary>With a byte order mark, so Excel reads names in Hindi and other scripts correctly.</summary>
    public static Encoding Encoding { get; } = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true);

    public const string Header = "Bill no.,Date,Time,Customer,Total,Paid,Balance";

    public static string Row(InvoiceSummary bill)
    {
        ArgumentNullException.ThrowIfNull(bill);
        return string.Join(",",
            Cell(bill.Number),
            bill.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
            bill.Time is { } time ? time.ToString("HH:mm", CultureInfo.InvariantCulture)
                : bill.Date.TimeOfDay == TimeSpan.Zero ? "" : bill.Date.ToString("HH:mm", CultureInfo.InvariantCulture),
            Cell(bill.CustomerName),
            Amount(bill.GrandTotal),
            Amount(bill.GrandTotal - bill.Balance),
            Amount(bill.Balance));
    }

    /// <summary>A text cell, quoted when it needs to be, that a spreadsheet never runs as a formula.</summary>
    public static string Cell(string? text)
    {
        var value = text ?? "";
        if (value.Length > 0 && value[0] is '=' or '+' or '-' or '@' or '\t' or '\r')
        {
            value = "'" + value;
        }

        return value.IndexOfAny(new[] { ',', '"', '\n', '\r' }) >= 0 || value != value.Trim()
            ? "\"" + value.Replace("\"", "\"\"") + "\""
            : value;
    }

    /// <summary>"bills.csv", or "bills 2026-09-01 to 2026-09-30.csv" for a date range.</summary>
    public static string FileName(BillQuery query)
    {
        ArgumentNullException.ThrowIfNull(query);
        var from = query.From?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        var to = query.To?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        return (from, to) switch
        {
            (null, null) => "bills.csv",
            ({ } f, { } t) when f == t => $"bills {f}.csv",
            ({ } f, { } t) => $"bills {f} to {t}.csv",
            ({ } f, null) => $"bills from {f}.csv",
            (null, { } t) => $"bills to {t}.csv",
        };
    }

    private static string Amount(decimal amount) => amount.ToString("0.00", CultureInfo.InvariantCulture);
}
