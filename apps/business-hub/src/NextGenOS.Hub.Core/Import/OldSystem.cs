namespace NextGenOS.Hub.Import;

/// <summary>
/// Where an older system's data comes from. A source only READS: it never writes to the old system. The first source is the older Windows POS's SQL Server database
/// (<see cref="PosSqlServerSource"/>). Other old systems are added later by writing another source that hands over the same typed records: a spreadsheet or CSV source
/// (items, people and balances typed into columns) is the next one named, and it is NOT built yet.
/// Keep every implementation inside Core: the web program is name-hidden differently and must not implement an interface of Core (docs/old-programs/06-hub-map.md, 1.3).
/// </summary>
public interface IOldSystemSource
{
    /// <summary>A short stable word for the kind of old system ("pos-sqlserver"). Stored with every old-to-new id, so two kinds never mix.</summary>
    string Kind { get; }

    /// <summary>Which old database this is (server and database name, lower case). Stored, so a second company's database is not mistaken for the first. Never holds a password.</summary>
    string SourceId { get; }

    /// <summary>Plain words for the report: "SQL Server MYPC\SHOP, database Shop1".</summary>
    string Describe { get; }

    /// <summary>Reads everything the move needs, once. Throws <see cref="HubException"/> with plain words when the old system cannot be read.</summary>
    OldSystemData Read();
}

/// <summary>
/// Everything read from an old system, as typed records. The records keep the old column names (so that a person can follow each one back to the old program): where a name
/// misleads, the comment says what the column really holds (docs/old-programs/DATABASE.md is the one place for "which column means what"). Nothing here is interpreted: that is the mapper's job.
/// Text may still carry the padding of the old fixed-width columns; the mapper trims it.
/// </summary>
public sealed record OldSystemData(
    IReadOnlyList<OldProduct> Products,
    IReadOnlyList<OldLot> Lots,
    IReadOnlyList<OldCategory> Categories,
    IReadOnlyList<OldSubCategory> SubCategories,
    IReadOnlyList<OldCustomer> Customers,
    IReadOnlyList<OldSupplier> Suppliers,
    IReadOnlyList<OldLedgerTotal> CustomerLedger,
    IReadOnlyList<OldLedgerTotal> SupplierLedger)
{
    public static OldSystemData Empty { get; } = new([], [], [], [], [], [], [], []);
}

/// <summary>Table Product: one row per product. NOT per barcode: the real barcodes and the live stock are in <see cref="OldLot"/>.</summary>
/// <param name="Id">Column PID.</param>
/// <param name="Code">Column ProductCode ("P-0012").</param>
/// <param name="SubCategoryId">Column SubCategoryID; the category is found through the sub-category.</param>
/// <param name="HsnCode">The product's tax classification code, as typed.</param>
/// <param name="CostPrice">The latest purchase price.</param>
/// <param name="SellingPrice">The retail price.</param>
/// <param name="ReorderPoint">MISLEADING NAME: this column holds the WHOLESALE price. The reorder level is <see cref="MinStock"/>.</param>
/// <param name="Mrp">The printed maximum price.</param>
/// <param name="TaxHalf1">Half of the tax rate (the old program stores a rate as two equal halves).</param>
/// <param name="TaxHalf2">The other half.</param>
/// <param name="Cess">An extra tax percent.</param>
/// <param name="Barcode">MISLEADING: always the text "0" for products made on the product screen; the real barcodes are rows of <see cref="OldLot"/>.</param>
/// <param name="SalesUnit">The main unit sold in ("Kg", "Pcs").</param>
/// <param name="MinStock">The reorder level (stock below it is "low stock").</param>
/// <param name="Status">"Yes" for a product in use, "No" for one switched off.</param>
/// <param name="SaleTaxType">Column STax: "Inclusive", "Exclusive", "Exempt GST" or "No Taxes".</param>
public sealed record OldProduct(
    long Id, string? Code, string? Name, long? SubCategoryId, string? HsnCode, decimal CostPrice, decimal SellingPrice, decimal ReorderPoint, decimal Mrp,
    decimal TaxHalf1, decimal TaxHalf2, decimal Cess, string? Barcode, string? SalesUnit, decimal MinStock, string? Status, string? SaleTaxType);

/// <summary>Table Temp_Stock: the LIVE stock, one row per barcode ("a lot"). This is where the real barcode, the quantity on hand and the prices the till uses are. (StockMovement is not reliable and is never read.)</summary>
/// <param name="Id">Column Id.</param>
/// <param name="ProductId">Column ProductID.</param>
/// <param name="Qty">On hand, thousandths exact (decimal 18,3). May be negative: the old program lets stock go below zero.</param>
/// <param name="Damage">Damaged units, still counted inside <see cref="Qty"/>.</param>
/// <param name="SPrice">The retail price the till reads.</param>
/// <param name="WPrice">The wholesale price the till reads.</param>
public sealed record OldLot(
    long Id, long ProductId, string? Barcode, decimal Qty, decimal Damage, decimal Mrp, decimal SPrice, decimal WPrice, string? Batch, string? Size, string? Colour);

/// <summary>Table Category.</summary>
public sealed record OldCategory(long Id, string? Name);

/// <summary>Table SubCategory. <paramref name="CategoryName"/> is the NAME of the category (not its id).</summary>
public sealed record OldSubCategory(long Id, string? Name, string? CategoryName);

/// <summary>Table Customer.</summary>
/// <param name="Code">Column CustomerID ("C-0007"): the key the ledger uses (its PartyID).</param>
/// <param name="TaxNumber">The customer's registered tax number, as typed.</param>
/// <param name="OpeningType">"CR" or "DR": which side the typed opening balance is on. Already posted into the ledger as its first row: never add it again.</param>
/// <param name="OpeningBalance">The typed opening amount. Already inside the ledger's total.</param>
/// <param name="CardNo">The loyalty card number.</param>
/// <param name="Limit">The credit limit amount. It counts only when <see cref="LimitSwitch"/> is "Yes".</param>
/// <param name="LimitSwitch">"Yes": the limit is enforced. "No": the customer may owe any amount, whatever <see cref="Limit"/> says.</param>
/// <param name="DiscountPercent">Column DiscPer (text): the customer's fixed discount percent.</param>
/// <param name="DiscountSwitch">Column DiscStatus: "Yes" when that discount is on.</param>
public sealed record OldCustomer(
    long Id, string? Code, string? Name, string? Address, string? City, string? State, string? ZipCode, string? ContactNo, string? EmailId, string? Remarks,
    string? TaxNumber, string? OpeningType, decimal OpeningBalance, string? CardNo, decimal Limit, string? LimitSwitch, string? DiscountPercent, string? DiscountSwitch);

/// <summary>Table Supplier.</summary>
/// <param name="Code">Column SupplierID ("S-0003"): the key the ledger uses (its PartyID).</param>
public sealed record OldSupplier(
    long Id, string? Code, string? Name, string? Address, string? City, string? State, string? ZipCode, string? ContactNo, string? EmailId, string? Remarks,
    string? TaxNumber, string? OpeningType, decimal OpeningBalance, decimal Limit, string? LimitSwitch);

/// <summary>
/// The running account of one customer or supplier, added up over ALL dates (tables CustomerLedgerBook and SupplierLedgerBook). The old program's balance is
/// "sum of Credit minus sum of Debit". <paramref name="OpeningRows"/> is how many of the rows are the posted opening balance.
/// </summary>
public sealed record OldLedgerTotal(string PartyId, decimal Debit, decimal Credit, int Rows, int OpeningRows);
