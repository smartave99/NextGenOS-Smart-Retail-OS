namespace SmartRetail.Pos.Data.SqlServer;

/// <summary>
/// When bills were saved, from the POS's own log. The POS keeps only the date on a bill (<c>InvoiceInfo.InvoiceDate</c>
/// is midnight), but each time it saves one it writes a <c>Logs</c> row such as "added the new bill (Products) having
/// invoice no. 'GST-2081-2026/27'" with the time. A bill number is used again when the latest bill is deleted, so a
/// number's latest entry is the bill that has it now.
/// </summary>
internal static class PosLog
{
    // "invoice no. '" is 13 characters; the number runs from after it to the closing quote.
    private const string Number =
        "CAST(SUBSTRING(l.Operation, CHARINDEX(N'invoice no. ''', l.Operation) + 13, " +
        "CASE WHEN LEN(l.Operation) > CHARINDEX(N'invoice no. ''', l.Operation) + 13 " +
        "THEN LEN(l.Operation) - CHARINDEX(N'invoice no. ''', l.Operation) - 13 ELSE 0 END) AS nvarchar(60))";

    /// <summary>A bill can be given a date a little after the day it is saved, so its entry is looked for from this
    /// many days before.</summary>
    public const int DaysBefore = 7;

    /// <summary>
    /// A common table expression <c>saved (Number, SavedAt)</c>: when each bill number was last saved, from the log
    /// entries since <paramref name="firstBillDate"/> less <see cref="DaysBefore"/> days. Join it on
    /// <c>RTRIM(InvoiceNo)</c>.
    /// </summary>
    /// <param name="readable">Whether this login may read the log (<see cref="SqlDb.CanReadLogAsync"/>); when not, the
    /// expression is empty and every bill's time is unknown.</param>
    /// <param name="firstBillDate">A SQL expression written in this code (never text from outside): the date of the
    /// earliest bill that needs its time.</param>
    public static string SavedBills(bool readable, string firstBillDate) => !readable ? NoLog : @"saved AS (
    SELECT " + Number + @" AS Number, MAX(l.[Date]) AS SavedAt
    FROM Logs l
    WHERE l.[Date] >= DATEADD(day, -" + DaysBefore.ToString(System.Globalization.CultureInfo.InvariantCulture) + ", " + firstBillDate + @")
      AND l.Operation LIKE N'added the new bill (%) having invoice no. ''%'''
    GROUP BY " + Number + @"
)";

    private const string NoLog = @"saved AS (
    SELECT CAST(NULL AS nvarchar(60)) AS Number, CAST(NULL AS datetime) AS SavedAt WHERE 1 = 0
)";
}
