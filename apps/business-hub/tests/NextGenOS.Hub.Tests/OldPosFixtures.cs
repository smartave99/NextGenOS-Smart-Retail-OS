using NextGenOS.Hub.Import;

namespace NextGenOS.Hub.Tests;

/// <summary>
/// A small old database held in memory, taken from the worked examples of docs/old-programs (01 and 02): the product with the wholesale price in ReorderPoint (M8), stock rows with real
/// barcodes while Product.Barcode is "0" (A2.0), stock value (S12), a negative stock row (S2), customer and supplier ledgers (C1, C2, C4, SM3, SM4, S3, S4), credit limits (L1, L3, L7).
/// It stands in for the SQL Server database: it only reads, and it can be told to hold a password so that tests can look for it afterwards.
/// </summary>
public sealed class FakeOldSystem(OldSystemData data, string? password = null, string id = "pc1/shopdata") : IOldSystemSource
{
    public string Kind => "pos-sqlserver";
    public string SourceId => id;
    public string Describe => "SQL Server " + id.Split('/')[0] + ", database " + id.Split('/')[1];
    public int Reads { get; private set; }

    /// <summary>The password the person typed, held in memory like the real source holds it. Nothing may ever copy it anywhere.</summary>
    public string? Password => password;

    public OldSystemData Read() { Reads++; return data; }
}

public static class OldPos
{
    /// <summary>
    /// The study's small shop. Counts: 11 old item rows (2 left out), 6 customers (the walk-in is left out), 3 suppliers.
    /// Money (in the shop's currency): stock at cost 2,870.00; customers owe 1,110.00 (10.00 of it belongs to a code nobody has); one customer is in credit 200.00;
    /// suppliers owe the shop 300.00; the shop owes suppliers 10,800.00.
    /// </summary>
    public static OldSystemData Study() => new(
        Products:
        [
            // M8: cost 100, MRP 150, retail 130, WHOLESALE 120 (kept in ReorderPoint); the reorder level is MinStock 5. Two half rates of 2.5 are a 5 percent tax. The name is padded like the old nchar column.
            new(1, "P-0001   ", "Basmati rice 5 kg                  ", 1, "1006", 100m, 130m, 120m, 150m, 2.5m, 2.5m, 0m, "0", "Pcs", 5m, "Yes", "Inclusive"),
            // S12: stock 7 at cost 50 is worth 350.00.
            new(2, "P-0002", "Sugar 1 kg", 1, null, 50m, 80m, 0m, 0m, 9m, 9m, 0m, "0", "Kg", 0m, "Yes", "Inclusive"),
            // Two barcodes (sizes and colours) of one product.
            new(3, "P-0003", "T-shirt", 2, null, 200m, 400m, 300m, 0m, 6m, 6m, 0m, "0", "Pcs", 2m, "Yes", "Inclusive"),
            // Switched off, nothing on the shelf.
            new(4, "P-0004", "Old tin", null, null, 10m, 15m, 0m, 0m, 0m, 0m, 0m, "0", "Pcs", 0m, "No", "Inclusive"),
            // S2: the old program lets stock go below zero.
            new(5, "P-0005", "Overdrawn item", null, null, 10m, 20m, 0m, 0m, 9m, 9m, 0m, "0", "Pcs", 0m, "Yes", "Inclusive"),
            // No stock row at all (a charge, not a thing on a shelf).
            new(6, "P-0006", "Delivery charge", null, null, 0m, 30m, 0m, 0m, 9m, 9m, 0m, "0", "", 0m, "Yes", "Inclusive"),
            // Exempt of tax by the old sale-tax type.
            new(7, "P-0007", "Plain flour", null, null, 20m, 30m, 0m, 0m, 0m, 0m, 0m, "0", "Kg", 0m, "Yes", "Exempt GST"),
            // No name: cannot be moved.
            new(8, "P-0008", "     ", null, null, 1m, 1m, 0m, 0m, 0m, 0m, 0m, "0", "Pcs", 0m, "Yes", "Inclusive"),
            // A stock row that uses the same barcode as product 1: the second must not get it.
            new(9, "P-0009", "Copy-barcode item", null, null, 20m, 30m, 0m, 0m, 9m, 9m, 0m, "0", "Pcs", 0m, "Yes", "Inclusive"),
        ],
        Lots:
        [
            new(11, 1, "8901000000019 ", 10m, 0m, 150m, 130m, 120m, null, null, null),
            new(12, 2, "8901000000026", 7m, 0m, 0m, 80m, 0m, null, null, null),
            new(13, 3, "T-M-BLU", 4m, 0m, 0m, 400m, 300m, "B1", "M", "Blue"),
            new(14, 3, "T-L-RED", 3m, 0m, 0m, 450m, 320m, null, "L", "Red"),
            new(15, 4, "TIN-1", 0m, 0m, 0m, 15m, 0m, null, null, null),
            new(16, 5, "NEG-1", -2m, 0m, 0m, 20m, 0m, null, null, null),
            new(17, 9, "8901000000019", 6m, 1m, 0m, 30m, 0m, null, null, null),
            new(99, 77, "ORPHAN", 5m, 0m, 0m, 10m, 0m, null, null, null),
        ],
        Categories: [new(1, "Grocery"), new(2, "Apparel")],
        SubCategories: [new(1, "Rice and sugar", "Grocery "), new(2, "Shirts", "Apparel")],
        Customers:
        [
            new(1, "C-0001", "Cash", null, null, null, null, null, null, null, null, null, 0m, null, 0m, "No", null, null),
            // L1/C4: limit 1,000 and the switch is Yes; bill 1,000 with 400 paid in cash.
            new(2, "C-0002", "Asha", "12 Market Road", "Pune", "Maharashtra", "411001", "9000000001", "asha@example.com", "good customer", "TAXNO-1", null, 0m, "CARD-1", 1000m, "Yes", "5", "No"),
            // C1/L3: opening balance DR 500; the limit amount is 1,000 but the switch says No: NOT enforced.
            new(3, "C-0003", "Bilal", null, null, null, null, null, null, null, null, "DR", 500m, null, 1000m, "No", "10", "Yes"),
            // C2/L7: opening balance CR 200; limit 0 with the switch Yes means no credit at all.
            new(4, "C-0004", "Chen", null, null, null, null, null, "not-an-address", null, null, "CR", 200m, null, 0m, "Yes", null, null),
            // A state the country list does not have, and a card number someone else already has.
            new(5, "C-0005", "Dana", "5 Hill Street", null, "Narnia", null, null, null, null, null, null, 0m, "CARD-1", 0m, "Yes", null, null),
            // A typed opening balance that is nowhere in the ledger.
            new(6, "C-0006", "Eli", null, null, null, null, null, null, null, null, "DR", 50m, null, 0m, "Yes", null, null),
        ],
        Suppliers:
        [
            new(1, "S-0001", "Mill Co", "1 Mill Lane", "Pune", "Maharashtra", null, "9000000101", null, null, null, null, 0m, 0m, "No"),
            new(2, "S-0002", "Dairy Ltd", null, null, null, null, null, null, null, null, "DR", 300m, 0m, "No"),
            new(3, "S-0003", "Trader", null, null, null, null, null, null, null, null, "CR", 1000m, 5000m, "Yes"),
        ],
        CustomerLedger:
        [
            new("C-0002", 1000m, 400m, 2, 0),    // C4: Sales D 1,000 and Receipt C 400: owes 600
            new("C-0003", 500m, 0m, 1, 1),       // C1: Opening Balance D 500: owes 500
            new("C-0004", 0m, 200m, 1, 1),       // C2: Opening Balance C 200: in credit 200
            new("C-0099", 10m, 0m, 1, 0),        // a code that is in no customer record
        ],
        SupplierLedger:
        [
            new("S-0001", 2000m, 5900m, 2, 0),   // S3: Purchase C 5,900 and Payment D 2,000: the shop owes 3,900
            new("S-0002", 300m, 0m, 1, 1),       // SM4: Opening Balance D 300: the supplier owes the shop 300
            new("S-0003", 0m, 6900m, 2, 1),      // S4 with SM3: opening C 1,000 and a purchase C 5,900: the shop owes 6,900
        ]);

    public static OldSystemData Only(Func<OldSystemData, OldSystemData> change) => change(Study());
}
