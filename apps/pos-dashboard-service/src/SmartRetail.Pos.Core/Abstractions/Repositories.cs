using SmartRetail.Pos.Core.Analytics;
using SmartRetail.Pos.Core.Checks;
using SmartRetail.Pos.Core.Models;

namespace SmartRetail.Pos.Core.Abstractions;

public interface IProductRepository
{
    /// <summary>Products whose name, code or barcode contains <paramref name="term"/> (all when empty).</summary>
    Task<IReadOnlyList<Product>> SearchAsync(string? term, int limit, CancellationToken ct = default);

    /// <summary>The product with exactly this code or barcode, e.g. from a scanner.</summary>
    Task<Product?> FindByCodeAsync(string codeOrBarcode, CancellationToken ct = default);

    /// <summary>The products' stock batches with the codes the till scans, one per batch; a product without a
    /// batch code gets its own barcode or product code. At most 500 products at a time.</summary>
    Task<IReadOnlyList<StockBatch>> GetBatchesAsync(IReadOnlyCollection<int> productIds, CancellationToken ct = default);
}

public interface ICustomerRepository
{
    Task<IReadOnlyList<Customer>> SearchAsync(string? term, int limit, CancellationToken ct = default);
}

public interface IStockRepository
{
    /// <summary>Products below their reorder level, biggest shortfall first.</summary>
    Task<IReadOnlyList<StockLevel>> GetLowStockAsync(int limit, CancellationToken ct = default);
}

public interface IInvoiceRepository
{
    Task<SavedInvoice> SaveAsync(NewInvoice invoice, CancellationToken ct = default);

    /// <summary>Latest bills first.</summary>
    Task<IReadOnlyList<InvoiceSummary>> GetRecentAsync(int limit, CancellationToken ct = default);

    /// <summary>Every bill since the first, newest first, a page at a time, with what the search adds up to.</summary>
    Task<BillPage> SearchAsync(BillQuery query, CancellationToken ct = default);

    /// <summary>One bill with its items and payments, or null.</summary>
    Task<BillDetails?> GetAsync(long id, CancellationToken ct = default);

    Task<SalesSummary> GetSalesForDayAsync(DateOnly day, CancellationToken ct = default);
}

/// <summary>Sales history for the sales dashboard and the AI growth plan. Read-only.</summary>
public interface ISalesFactsRepository
{
    /// <summary>The days of the first and the latest bill, or null when there are no bills.</summary>
    Task<BillSpan?> GetBillSpanAsync(CancellationToken ct = default);

    Task<SalesFacts> GetFactsAsync(DateRange range, CancellationToken ct = default);

    /// <summary>Every product with its stock as it stands now.</summary>
    Task<IReadOnlyList<ProductFacts>> GetProductsAsync(CancellationToken ct = default);

    /// <summary>Each bill of the days in <paramref name="range"/> with its total and when the POS saved it.</summary>
    Task<IReadOnlyList<BillTime>> GetBillTimesAsync(DateRange range, CancellationToken ct = default);

    /// <summary>The bills of the days in <paramref name="range"/> with any of <paramref name="productIds"/> on them,
    /// each counted once however many of the products it has; 0 for no products.</summary>
    Task<int> CountBillsWithAsync(DateRange range, IReadOnlyCollection<int> productIds, CancellationToken ct = default);
}

public sealed record BillSpan(DateOnly First, DateOnly Last);

/// <summary>What the Fix now checks read: every price as the till charges it, and recent bills and their lines.</summary>
public interface IShopChecksRepository
{
    /// <summary>Every active product's stock batches (the product itself when it has none) with price, MRP,
    /// purchase price, GST and stock.</summary>
    Task<IReadOnlyList<PriceFacts>> GetPricesAsync(CancellationToken ct = default);

    /// <summary>The items on the bills of the days in <paramref name="range"/>.</summary>
    Task<IReadOnlyList<SoldLine>> GetSoldLinesAsync(DateRange range, CancellationToken ct = default);

    /// <summary>The bills of the days in <paramref name="range"/>: id, number and date.</summary>
    Task<IReadOnlyList<BillStub>> GetBillsAsync(DateRange range, CancellationToken ct = default);
}
