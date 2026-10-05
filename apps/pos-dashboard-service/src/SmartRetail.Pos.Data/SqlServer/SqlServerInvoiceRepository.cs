using System.Data;
using Microsoft.Data.SqlClient;
using SmartRetail.Pos.Core.Abstractions;

namespace SmartRetail.Pos.Data.SqlServer;

/// <summary>
/// Bills from the POS <c>InvoiceInfo</c> table. Read-only for now: when the existing POS saves a bill it
/// also moves Temp_Stock batches, ledger and audit rows and its own invoice numbering. Writing bills here
/// is switched off until that path has been rebuilt and checked against a restored copy of the database.
/// </summary>
public sealed class SqlServerInvoiceRepository : IInvoiceRepository
{
    public const string SavingDisabledMessage =
        "Saving bills to the live POS database is switched off in this version. " +
        "It will be enabled once bill saving has been verified against a copy of the database.";

    private readonly SqlDb _db;

    public SqlServerInvoiceRepository(SqlDb db) => _db = db;

    public Task<SavedInvoice> SaveAsync(NewInvoice invoice, CancellationToken ct = default) =>
        throw new NotSupportedException(SavingDisabledMessage);

    private static readonly string[] RecentSql = { RecentQuery(false), RecentQuery(true) };

    private static string RecentQuery(bool log) => @"
WITH recent AS (
    SELECT TOP (@limit) i.Inv_ID, i.InvoiceNo, i.InvoiceDate, c.Name, i.GrandTotal, i.Balance
    FROM InvoiceInfo i
    LEFT JOIN Customer c ON c.ID = i.Customer_ID
    ORDER BY i.InvoiceDate DESC, i.Inv_ID DESC
), " + PosLog.SavedBills(log, "(SELECT MIN(InvoiceDate) FROM recent)") + @"
SELECT r.Inv_ID, RTRIM(r.InvoiceNo), r.InvoiceDate, RTRIM(r.Name), ISNULL(r.GrandTotal, 0), ISNULL(r.Balance, 0), s.SavedAt
FROM recent r
LEFT JOIN saved s ON s.Number = RTRIM(r.InvoiceNo)
ORDER BY r.InvoiceDate DESC, r.Inv_ID DESC";

    public async Task<IReadOnlyList<InvoiceSummary>> GetRecentAsync(int limit, CancellationToken ct = default)
    {
        var sql = RecentSql[await _db.CanReadLogAsync(ct).ConfigureAwait(false) ? 1 : 0];
        return await _db.QueryAsync(sql, ps => ps.Add("@limit", SqlDbType.Int).Value = limit, r => ReadSummary(r, 6), ct).ConfigureAwait(false);
    }

    // Bills matching a BillQuery. The POS keeps no time of day on its bills, so the bill id breaks ties.
    private const string BillFilter = @"
FROM InvoiceInfo i
LEFT JOIN Customer c ON c.ID = i.Customer_ID
WHERE (@from IS NULL OR i.InvoiceDate >= @from)
  AND (@to IS NULL OR i.InvoiceDate < @to)
  AND (@owed = 0 OR i.Balance > 0)
  AND (@upTo IS NULL OR i.Inv_ID <= @upTo)
  AND (@pattern IS NULL OR i.InvoiceNo LIKE @pattern OR c.Name LIKE @pattern OR c.ContactNo LIKE @pattern)";

    public async Task<BillPage> SearchAsync(BillQuery query, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(query);
        query = query.Checked();

        const string totalsSql = @"
SELECT COUNT(*), ISNULL(SUM(i.GrandTotal), 0), ISNULL(SUM(CASE WHEN i.Balance > 0 THEN i.Balance ELSE 0 END), 0),
       MIN(i.InvoiceDate), MAX(i.InvoiceDate), MAX(i.Inv_ID)" + BillFilter;

        var totals = (await _db.QueryAsync(totalsSql, ps => BindFilter(ps, query), r => new BillPage
        {
            Total = r.GetInt32(0),
            TotalAmount = SqlDb.Number(r, 1),
            TotalOwed = SqlDb.Number(r, 2),
            First = r.IsDBNull(3) ? null : r.GetDateTime(3),
            Last = r.IsDBNull(4) ? null : r.GetDateTime(4),
            NewestId = r.IsDBNull(5) ? null : r.GetInt32(5),
        }, ct).ConfigureAwait(false))[0];
        if (query.Skip >= totals.Total)
        {
            return totals;
        }

        var sql = PageSql[await _db.CanReadLogAsync(ct).ConfigureAwait(false) ? 1 : 0];
        var items = await _db.QueryAsync(sql, ps =>
        {
            BindFilter(ps, query);
            ps.Add("@skip", SqlDbType.Int).Value = query.Skip;
            ps.Add("@take", SqlDbType.Int).Value = query.Take;
        }, r => ReadSummary(r, 6), ct).ConfigureAwait(false);
        return totals with { Items = items };
    }

    // ROW_NUMBER rather than OFFSET/FETCH, which older SQL Server editions at shops do not have.
    private static readonly string[] PageSql = { PageQuery(false), PageQuery(true) };

    private static string PageQuery(bool log) => @"
WITH matching AS (
    SELECT i.Inv_ID, i.InvoiceNo, i.InvoiceDate, c.Name, i.GrandTotal, i.Balance,
           ROW_NUMBER() OVER (ORDER BY i.InvoiceDate DESC, i.Inv_ID DESC) AS RowNo" + BillFilter + @"
), page AS (
    SELECT * FROM matching WHERE RowNo > @skip AND RowNo <= @skip + @take
), " + PosLog.SavedBills(log, "(SELECT MIN(InvoiceDate) FROM page)") + @"
SELECT p.Inv_ID, RTRIM(p.InvoiceNo), p.InvoiceDate, RTRIM(p.Name), ISNULL(p.GrandTotal, 0), ISNULL(p.Balance, 0), s.SavedAt
FROM page p
LEFT JOIN saved s ON s.Number = RTRIM(p.InvoiceNo)
ORDER BY p.RowNo";

    public async Task<BillDetails?> GetAsync(long id, CancellationToken ct = default)
    {
        if (id is <= 0 or > int.MaxValue)
        {
            return null;
        }

        var billSql = BillSql[await _db.CanReadLogAsync(ct).ConfigureAwait(false) ? 1 : 0];
        var bills = await _db.QueryAsync(billSql, ps => ps.Add("@id", SqlDbType.Int).Value = (int)id, r => new BillDetails
        {
            Summary = ReadSummary(r, 16),
            CustomerPhone = SqlDb.Text(r, 6),
            SubTotal = SqlDb.Number(r, 7),
            Discount = SqlDb.Number(r, 8),
            Cgst = SqlDb.Number(r, 9),
            Sgst = SqlDb.Number(r, 10),
            Igst = SqlDb.Number(r, 11),
            RoundOff = SqlDb.Number(r, 12),
            Paid = SqlDb.Number(r, 13),
            Operator = SqlDb.Text(r, 14),
            Remarks = SqlDb.Text(r, 15),
        }, ct).ConfigureAwait(false);
        if (bills.Count == 0)
        {
            return null;
        }

        // The name printed on the bill, which stays as it was if the product is renamed later.
        const string itemsSql = @"
SELECT ip.ProductID, COALESCE(NULLIF(RTRIM(CAST(ip.Descr AS nvarchar(400))), N''), RTRIM(p.ProductName), N''), ISNULL(RTRIM(p.ProductCode), N''),
       ip.Qty, ISNULL(RTRIM(ip.MainUnit), N''), ip.SalesRate, ISNULL(ip.MRP, 0), ip.Discount,
       ip.CGSTPer + ISNULL(ip.SGSTPer, 0) + ISNULL(ip.IGSTPer, 0), ip.CGSTAmt + ISNULL(ip.SGSTAmt, 0) + ISNULL(ip.IGSTAmt, 0), ip.TotalAmount
FROM Invoice_Product ip
LEFT JOIN Product p ON p.PID = ip.ProductID
WHERE ip.InvoiceID = @id
ORDER BY ip.IPo_ID";

        var items = await _db.QueryAsync(itemsSql, ps => ps.Add("@id", SqlDbType.Int).Value = (int)id, r => new BillItem
        {
            ProductId = r.GetInt32(0),
            Name = SqlDb.Text(r, 1) ?? "",
            Code = SqlDb.Text(r, 2) ?? "",
            Qty = SqlDb.Number(r, 3),
            Unit = SqlDb.Text(r, 4) ?? "",
            Rate = SqlDb.Number(r, 5),
            Mrp = SqlDb.Number(r, 6),
            Discount = SqlDb.Number(r, 7),
            TaxPercent = SqlDb.Number(r, 8),
            Tax = SqlDb.Number(r, 9),
            Amount = SqlDb.Number(r, 10),
        }, ct).ConfigureAwait(false);

        const string paymentsSql = @"
SELECT pay.PaymentDate, RTRIM(pay.PaymentMode), pay.TotalPaid
FROM Invoice_Payment pay
WHERE pay.InvoiceID = @id
ORDER BY pay.IP_ID";

        var payments = await _db.QueryAsync(paymentsSql, ps => ps.Add("@id", SqlDbType.Int).Value = (int)id, r => new BillPayment(
            r.IsDBNull(0) ? null : r.GetDateTime(0),
            SqlDb.Text(r, 1) ?? "",
            SqlDb.Number(r, 2)), ct).ConfigureAwait(false);

        return bills[0] with { Items = items, Payments = payments };
    }

    private static readonly string[] BillSql = { OneBillQuery(false), OneBillQuery(true) };

    private static string OneBillQuery(bool log) => @"
WITH bill AS (
    SELECT i.InvoiceNo, i.InvoiceDate FROM InvoiceInfo i WHERE i.Inv_ID = @id
), " + PosLog.SavedBills(log, "(SELECT MIN(InvoiceDate) FROM bill)") + @"
SELECT i.Inv_ID, RTRIM(i.InvoiceNo), i.InvoiceDate, RTRIM(c.Name), ISNULL(i.GrandTotal, 0), ISNULL(i.Balance, 0),
       RTRIM(c.ContactNo), ISNULL(i.SubTotal, 0), ISNULL(i.BillDiscount, 0) + ISNULL(i.OfferAmt, 0),
       ISNULL(i.CGST, 0), ISNULL(i.SGST, 0), ISNULL(i.IGST, 0), ISNULL(i.RoundOff, 0), ISNULL(i.TotalPaid, 0),
       RTRIM(i.Operator), CAST(i.Remarks AS nvarchar(1000)), s.SavedAt
FROM InvoiceInfo i
LEFT JOIN Customer c ON c.ID = i.Customer_ID
LEFT JOIN saved s ON s.Number = RTRIM(i.InvoiceNo)
WHERE i.Inv_ID = @id";

    private static void BindFilter(SqlParameterCollection ps, BillQuery query)
    {
        ps.Add("@from", SqlDbType.DateTime).Value = query.From is { } from ? from.ToDateTime(TimeOnly.MinValue) : DBNull.Value;
        ps.Add("@to", SqlDbType.DateTime).Value = query.To is { } to ? to.AddDays(1).ToDateTime(TimeOnly.MinValue) : DBNull.Value;
        ps.Add("@owed", SqlDbType.Bit).Value = query.OnlyOwed;
        ps.Add("@upTo", SqlDbType.BigInt).Value = query.UpToId is { } upTo ? upTo : DBNull.Value;
        ps.Add("@pattern", SqlDbType.NVarChar, 210).Value = (object?)SqlDb.ContainsPattern(query.Text) ?? DBNull.Value;
    }

    /// <param name="savedAt">The column with when the POS saved the bill (<see cref="PosLog"/>).</param>
    private static InvoiceSummary ReadSummary(SqlDataReader r, int savedAt) => new()
    {
        Id = r.GetInt32(0),
        Number = SqlDb.Text(r, 1) ?? r.GetInt32(0).ToString(System.Globalization.CultureInfo.InvariantCulture),
        Date = r.IsDBNull(2) ? DateTime.MinValue : r.GetDateTime(2),
        CustomerName = SqlDb.Text(r, 3) ?? "Walk-in customer",
        GrandTotal = SqlDb.Number(r, 4),
        Balance = SqlDb.Number(r, 5),
        SavedAt = r.IsDBNull(savedAt) ? null : r.GetDateTime(savedAt),
    };

    public async Task<SalesSummary> GetSalesForDayAsync(DateOnly day, CancellationToken ct = default)
    {
        const string sql = @"
SELECT COUNT(*), ISNULL(SUM(i.GrandTotal), 0), ISNULL(SUM(i.Balance), 0)
FROM InvoiceInfo i
WHERE i.InvoiceDate >= @from AND i.InvoiceDate < @to";

        var rows = await _db.QueryAsync(sql, ps =>
        {
            ps.Add("@from", SqlDbType.DateTime).Value = day.ToDateTime(TimeOnly.MinValue);
            ps.Add("@to", SqlDbType.DateTime).Value = day.AddDays(1).ToDateTime(TimeOnly.MinValue);
        }, r => new SalesSummary
        {
            Day = day,
            BillCount = r.GetInt32(0),
            Total = SqlDb.Number(r, 1),
            Outstanding = SqlDb.Number(r, 2),
        }, ct).ConfigureAwait(false);
        return rows[0];
    }
}
