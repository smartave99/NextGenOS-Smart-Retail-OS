# The older POS's database: which column means what, and what the Business Hub's reader does with it

Written on 7 October 2026 (decision 29: this is the one place for "which old column means what"). It comes from the study files (`01-selling-buying-stock.md`, `02-masters-accounting-reports.md`) and from `apps/pos-ai-companion/src/SmartRetail.AI.Core/Data/PosSchemaData.cs` (the table layout of the older POS, taken from its database script). **Nothing here was run against a real database: no SQL Server and no copy of the older POS's database was available.** Section 10 says exactly how a person checks it.

The code is in `apps/business-hub/src/NextGenOS.Hub.Core/Import/`:

| File | What it is |
|---|---|
| `OldSystem.cs` | `IOldSystemSource` (what any old system must hand over) and the typed records (`OldProduct`, `OldLot`, `OldCustomer`, `OldSupplier`, `OldLedgerTotal` ...). The records keep the old column names. |
| `PosSqlServerQueries.cs` | Every SQL statement the reader may send, and `ReadOnlySql`, the check that each one is a single SELECT. |
| `PosSqlServerSource.cs` | The reader of the older POS's SQL Server database. |
| `PosMapper.cs` | Old rows to Hub items, people, stock and balances, and the match report. Writes nothing. |
| `MatchReport.cs` | The report (lines, notes, rows left out). |
| `ImportService.cs` | `Check` (a dry run) and `Import` (one transaction after a copy of the database). |

## 1. How the reader reads (and why it cannot write)

- **Only SELECT.** Nine statements, all written in `PosSqlServerQueries.cs`, none with a value typed by a person (so nothing to inject). A test checks that each starts with `SELECT` and holds no word that writes (`INSERT UPDATE DELETE MERGE DROP ALTER CREATE TRUNCATE EXEC GRANT INTO ...`), and that no statement exists outside the list. The reader checks each again (`ReadOnlySql.Require`) before sending it.
- **The connection says "read only"** (`ApplicationIntent=ReadOnly`) and names itself `Business Hub: move from the older POS` (so the server's own trace shows who read). It is a signal to the server, not a lock: the real protection is the SELECT-only rule above and a database login that can only read (the AI add-on already has a script for one: `apps/pos-ai-companion/sql/create_readonly_login.sql`).
- **The password** is typed by the owner on the Settings screen each time. The reader copies it into a read-only `SecureString` and hands it to the driver as a credential: it is never put in a connection string, a file, the Hub's database, a log, the audit record or the report. `ToString()` shows only the server and database. The screen clears the box as soon as the check has finished. A test looks for the password in the Hub's database file, its backup copy, the audit rows and the report text. (A Windows login without a password is also possible: the account the Hub runs under.)
- **Encryption:** the driver encrypts by default and refuses a server certificate it does not trust. A shop's own SQL Server usually has a self-made certificate, so the screen has a box "Trust this server's security certificate" (off unless ticked), and the error message points at it.
- **Close the older program first.** The reader reads with the server's default isolation; the older program saves without transactions, so a read during a sale could see half a bill.

## 2. Tables the reader reads

| Table | Why |
|---|---|
| `Product` | one row per product: names, tax, units, default prices |
| `Temp_Stock` | **the live stock, one row per barcode (a "lot")**: the real barcode, the quantity, the prices the till reads |
| `Category`, `SubCategory` | the names; a sub-category holds the **name** of its category (not its id) |
| `Customer`, `Supplier` | the people |
| `CustomerLedgerBook`, `SupplierLedgerBook` | the running accounts; read as one row per `PartyID` (sum of `Debit`, sum of `Credit`, row count, how many rows are labelled "Opening Balance") |
| `INFORMATION_SCHEMA.COLUMNS` | to check that the tables and columns above exist, so that a wrong or different database gives a plain message and not a raw SQL error |

**Never read, on purpose:** `StockMovement` (it misses rows: damage, transfers, some touch-till flows; study 01, 6.1), `Product_OpeningStock` (the set-up record of a lot, not the live stock), `Invoice*`, `Stock*`, `Payment*`, `LedgerBook` and every other table. This step does not move the history of sales, purchases or payments.

## 3. Product (one row per product)

| Column | What it really holds | What the mapper does | Hub field |
|---|---|---|---|
| `PID` | number | key `product:<PID>` (only for a product with no stock row) | `import_id_map` |
| `ProductCode` | "P-0012" | trimmed | `items.sku` |
| `ProductName` | name, padded with spaces (`nchar`) | trimmed; empty name: row left out ("The product has no name.") | `items.name` |
| `SubCategoryID` | link to `SubCategory.ID` | category = the sub-category's category name; the sub-category's own name goes to `attrs.subCategory` | `items.category`, `attrs` |
| `HSNCode` | free text, as typed | kept as text | `attrs.hsn` |
| `CostPrice` | the **latest purchase price** | stock value uses it (as the old stock report does) | `items.cost_minor` |
| `SellingPrice` | the retail price (the product's default) | used when the stock row has no retail price | `items.price_minor` |
| **`ReorderPoint`** | **the WHOLESALE price** (the screen label "Wholesale Price" saves into this column) | used as the trade price when the stock row has none | `items.trade_price_minor` |
| `MRP` | the printed maximum price | kept as text | `attrs.mrp` |
| `CGST`, `SGST` | **half** of the tax rate each (a rate of 5 is stored as 2.5 and 2.5) | added together, then looked up in the shop's country list of rates by percent (an old rate the list still shows as "old" is found too); no match: the standard rate and a note | `items.tax_code` |
| `CESS` | an extra tax percent | **not moved** (the Hub has none); a note counts the items | |
| **`Barcode`** | **always the text "0"** for products made on the product screen | ignored; the real barcodes are in `Temp_Stock`. (A product with no stock row and a barcode other than "0" or empty keeps that barcode.) | |
| `SalesUnit` | the main unit sold in | text as it is | `items.unit` |
| **`MinStock`** | **the reorder level** (stock below it is "low stock") | thousandths; set on the first barcode of a product only | `items.reorder_milli` |
| `Status` | "Yes" in use, "No" switched off | "No": the item is added switched off | `items.active` |
| `STax` | "Inclusive", "Exclusive", "Exempt GST" or "No Taxes" | "Exempt GST": the shop's exempt class; "No Taxes": the shop's zero class; "Inclusive"/"Exclusive" is compared with the Hub's one setting for the whole shop and a note says how many items differ | |
| `OpeningStock` | always 0 | ignored | |
| `PTax`, `PurchaseUnit`, `SalesAltUnit`, `Conv`, `Discount`, `DefQty`, `GDown`, `Rack`, `Kitchen`, `LastPrice`, `loyality_*`, `Description`, `PartNo`, `AddDate` | | **not read** (the Hub has no place for them yet) | |

## 4. Temp_Stock (the live stock: one row per barcode)

| Column | Meaning | Mapper |
|---|---|---|
| `Id` | number | key `lot:<Id>` |
| `ProductID` | the product; a row whose product does not exist is left out ("... product number N, which does not exist") and its quantity is shown as left out | |
| `Barcode` | **the real barcode** | trimmed; "0" or empty is no barcode; a barcode already on another item (this move or the Hub) is dropped from the later item with a note | `items.barcode` |
| `Qty` | on hand, 3 decimals; **may be negative** | thousandths, exact; a negative count is moved as it is and listed | `stock_moves` (reason "opening stock", note "Moved from the older program") |
| `Damage` | damaged units, **still counted inside `Qty`** | not subtracted; a note counts the rows | |
| `SPrice`, `WPrice` | the retail and wholesale price **the till reads** | used before the product's own prices; a note counts the rows where they differ | `price_minor`, `trade_price_minor` |
| `MRP`, `Batch`, `Size`, `Colour` | | kept as text | `attrs` |
| `StLimit`, `PPrice`, `EPPrice`, `Mfgdate`, `Expdate`, `IMEI1`, `IMEI2`, `SuplName`, `Variant_id`, `Serial_no`, `QrBarcode`, `SalePrice`, `WSalePrice` | | **not read** (batch expiry, serial numbers and lot costs have no place in the Hub yet; `SalePrice`/`WSalePrice` are price cipher codes as text) | |

**A product with several barcodes** (sizes, colours, batches): the Hub keeps one barcode on an item and has no lots, so **each barcode becomes its own item**, named `Product (Size, Colour, Batch)` (or the barcode when there are none), with its own price and its own stock, so that scanning any old barcode works. The reorder level goes on the first barcode only. A note lists such products. A product with **no** stock row becomes one item with no barcode and no stock.

**Stock value in the report** is the old stock report's way: each row with a quantity above zero, quantity times `Product.CostPrice` (the latest cost, not the row's own `EPPrice`), added up. The Hub's side is the Hub's own rule (`ReportService.StockValues`: half-up per item, nothing for stock at or below zero). They agree to within a rounding of a minor unit per item; the report allows that and says so.

## 5. Customer and Supplier

| Column | What it really holds | Mapper |
|---|---|---|
| `CustomerID` / `SupplierID` | "C-0007" / "S-0003": **the key the ledger uses** (its `PartyID`) | `parties.code`; matches the ledger. A code used by two people: only the first keeps the balance, with a note |
| `Name` | name, padded | trimmed; names over 120 characters are cut with a note; **a customer named "Cash" is the walk-in customer** (sales to nobody in particular): not moved, shown as left out. A customer number 1 with another name is moved as an ordinary customer with a note |
| `Address`, `City`, `State`, `ZipCode` | | joined with commas into the address |
| `State` | a free-text region **name** | looked up by name (or code) in the country pack's list of regions; found: the region code (it decides local tax on a sale); not found: left empty and listed |
| `ContactNo`, `EmailID` | | phone, e-mail (an address without "@" is left out with a note) |
| `GSTIN` | the registered tax number | `parties.tax_id` |
| `Remarks` | | `parties.notes` |
| `CardNo` | the loyalty card number | `parties.card_barcode` (a number used twice: only the first person keeps it; "0" or empty is none) |
| **`Optype`, `Opbal`** | the typed opening balance and its side ("CR"/"DR") | **ignored for the amount**: the program already posted it as the first row of the ledger, so it is inside the ledger's total. Added again it would be counted twice. If it is typed but not in the ledger, a note says so and the ledger's total is moved |
| **`Limit`, `Lstatus`** | the credit limit and **its switch**: the limit counts only when `Lstatus` is "Yes"; "No" means the customer may owe any amount | enforced: the limit amount. **Not enforced: the Hub has no "no limit" and reads 0 as no credit at all, so the customer gets a very high limit** (1,000,000,000 whole units of the shop's currency) **and a note on the person's record and in the report.** Limit 0 with switch "Yes" stays 0 (no credit in both programs). A blank or odd switch counts as "not enforced" because the old program checks the limit only for "Yes" |
| `DiscPer`, `DiscStatus` | a fixed discount percent and its switch | **not moved** (the Hub has no customer discount yet); a note counts the customers |
| `Taround` (turn-around days) | how often the customer is expected back, **not** payment terms | not read; the Hub's `terms_days` stays 0 |
| supplier `Limit`, `Lstatus`, `SCode` | | not used |
| bank details, `PAN`, `CIN`, `Photo`, `Route`, `Tcs`, loyalty columns | | not read |

## 6. The ledgers: a balance is a running account

`CustomerLedgerBook` and `SupplierLedgerBook` have one row per event (`PartyID`, `Debit`, `Credit`, `Label`, ...). **The balance of a person = the sum of `Credit` minus the sum of `Debit`, over all dates.** For a customer this is normally negative (they owe), for a supplier normally positive (the shop owes).

The Hub stores **one number for both, with one sign: "what the person owes the shop"** = sum(Debit) − sum(Credit). Positive: the person owes the shop. Negative: the shop owes the person. It is saved in the new table `party_opening_balances` (not on the person's record, which the Hub's rules do not allow to change). **No screen of the Hub reads it yet** (it has no customer or supplier account): the figure is kept safely for the account view that is to be built (`docs/OPEN-WORK.md`).

Worked examples (from the study; they are the Hub's tests):

| Study | Ledger | Hub balance |
|---|---|---|
| C1: opening "DR" 500 | Debit 500 | +500.00 (owes the shop) |
| C2: opening "CR" 200 | Credit 200 | −200.00 (the shop owes them) |
| C4: bill 1,000, 400 paid in cash | Debit 1,000, Credit 400 | +600.00 |
| C10: no rows | none | 0, no balance row written |
| S3: credit purchase 5,900, 2,000 paid | Credit 5,900, Debit 2,000 | −3,900.00 |
| SM4: supplier opening "DR" 300 | Debit 300 | +300.00 (the supplier owes the shop) |
| S4 + SM3: opening CR 1,000 and a purchase of 5,900 | Credit 6,900 | −6,900.00 |

Rows of a code that is in no customer or supplier record are **not** moved and are shown as left out. A purchase total in the old program includes the supplier's previous due; the ledger row is written for the total minus that due (study 02, A3.0), so the ledger's sum is right and is what is read.

## 7. The match report

Built before anything is written. Each line: what the older program holds, what is added now, what an earlier move already brought across, what is left out (each left-out row has its reason), and what nothing explains (it must be zero). The Hub column is "added now + earlier".

| Line | Old figure | Notes |
|---|---|---|
| Items | products with no stock row + stock rows | a product with several barcodes counts once per barcode |
| Customers, Suppliers | rows (the walk-in customer is left out) | |
| Stock on hand | sum of `Qty` of all stock rows | includes negative rows and rows of missing products (left out) |
| Stock value at cost | see section 4 | rounding allowed: one minor unit per item with stock |
| Customers owe you / You owe customers | sum of the positive / negative balances | |
| Suppliers owe you / You owe suppliers | the same | |

A note has a level: **info** (nothing to do), **look** (the move is allowed, a person should read it: tax rates not in the country list, no credit limit in the old program, barcodes used twice, damaged units, regions not found ...) or **blocking** (the move is not allowed: a line does not add up, an amount has more decimals than the shop's currency can hold). A line that does not add up is blocking by itself. **Import is only possible when nothing blocks, there is something new to add, the person has ticked "I have read the report", and the numbers are still the ones that were read** (a short code of the report is compared again just before writing).

## 8. What the move writes (all or nothing)

After a copy of the Hub's database file (`shop.db.before-import-<time>.bak`, made with the same helper as the update copy; if it cannot be made, nothing is changed), in **one transaction**: items (`Catalog.Create`), a stock move per counted row (reason "opening stock"), people (`Parties.Create`), a row in `party_opening_balances` per non-zero balance, a row in `import_id_map` per old row (so a second run adds nothing twice), one row in `import_runs` (with the report as text) and one audit line. Before the commit the Hub's totals are read back and compared with the report; if they differ, nothing is kept. The way back is to put the copy back; the migration's own way back (`Data/Rollbacks/006_import_log.sql`) drops only the three memory tables and keeps the items and people.

## 9. Choices made where the study is silent (the owner can change them) and what is not understood

Choices (each shows in the report as a note, not silently):
1. One item per barcode for a product with several (section 4). Alternative: one item with summed stock and only one barcode working.
2. Category = the category's name; the sub-category in `attrs.subCategory` (the study left this to the owner).
3. The price of an item with a stock row is the **stock row's** price (what the till read), falling back to the product's.
4. "Not enforced" credit = a very high limit with a note (section 5). The better fix is a real "no limit" setting on a person; that changes the Hub's credit rule and needs the owner.
5. A tax rate that is not in the country's list gets the standard rate and a note; it is never guessed silently. The old program's "tax inside or on top of the price" per item cannot be kept (the Hub has one setting for the shop); the report counts the items where it differs.
6. A customer's discount, cess, batch expiry, serial numbers, loyalty points and coupons are not moved (the Hub has no place for them yet): the report says how many customers or items had them.

Not understood (the rule is: do the safe thing and list it; do not guess):
- Whether `Customer` number 1 is always the walk-in customer. The reader trusts the **name** "Cash" only.
- Whether the typed opening balance and the ledger's opening row can ever disagree in a real database (the reader moves the ledger's total).
- The real column types of the ledger tables (`PartyID`, `Debit`, `Credit`, `Label`): they are not in `PosSchemaData.cs`; they come from the study of the SQL strings (`ModFunc.vb:524-541, 663-680`) and are read leniently (any number or text type). The schema check names any missing column in plain words.
- Whether a real database still has padding spaces in `PartyID` between the two ledger tables and the person tables (the reader trims both and compares without case).
- The `StLimit` / minimum-stock mark of a stock row, which a purchase resets to 0 (study 01, 6.11): the reader uses `Product.MinStock`.
- How a real company database is named (the AI add-on says the older POS names them `Raintech_DB1`, `Raintech_DB2` ...; *Settings, Database, Pick company* in the older program shows the right one).

## 10. How a person verifies the reader against a real SQL Server (NOT VERIFIED until then)

Do this on a PC that has the older POS's database, with a **test copy of the Business Hub** (not the live shop's), and with the older program closed.

1. **Make a login that can only read.** Run `apps/pos-ai-companion/sql/create_readonly_login.sql` (it asks for a password and the database name) or make an equivalent. Never use the `sa` login.
2. **Write down control numbers straight from SQL Server** (Management Studio, SELECT only):
   - `SELECT COUNT(*) FROM Product; SELECT COUNT(*) FROM Temp_Stock;` -> the "Items" line should be (products with no stock row) + (stock rows whose product exists) + (stock rows whose product is missing).
   - `SELECT SUM(Qty) FROM Temp_Stock;` -> "Stock on hand".
   - `SELECT SUM(t.Qty * p.CostPrice) FROM Temp_Stock t JOIN Product p ON p.PID = t.ProductID WHERE t.Qty > 0;` -> "Stock value at cost".
   - `SELECT COUNT(*) FROM Customer; SELECT COUNT(*) FROM Supplier;`
   - `SELECT SUM(x) FROM (SELECT SUM(Debit) - SUM(Credit) AS x FROM CustomerLedgerBook GROUP BY RTRIM(PartyID)) a WHERE x > 0;` (and `< 0`, and the same for `SupplierLedgerBook`) -> the four balance lines.
3. **Compare with the older program's own screens**: *Current stock* (total quantity and value), *Customer outstanding* and *Supplier outstanding* for all dates, and the number of customers and suppliers.
4. In the Hub: *Settings, Move from the older POS*; type the server (as the older program shows it under its database settings), the database, the user and the password; press **Check**. If it says the certificate is not trusted and the server is your own, tick the box and check again.
5. **Compare every "In the older program" figure** of the report with step 2. They must be equal. Look at every "Please look" note and open five items, five customers and three suppliers in the older program and compare with the report's notes.
6. **Prove it only reads.** Start SQL Server Profiler (or an Extended Events session) filtered on the application name `Business Hub: move from the older POS` and press Check again: every batch must start with `SELECT`. Compare `SELECT CHECKSUM_AGG(CHECKSUM(*)) FROM Customer` (and `Product`, `Temp_Stock`, both ledgers) before and after: they must not change.
7. **Try the failures**: a wrong password, a wrong database name, a server that is switched off, a different database (for example a copy of another program). Each should give a plain sentence, never a raw SQL error and never the password.
8. Press **Move it** on the *test* Hub, then compare *Items*, *Reports -> Stock value* and the people list with the control numbers. Run the move again: it must add nothing.
9. **Know this first:** the Hub is built to run without the system's language data ("invariant globalization"), and **Microsoft.Data.SqlClient 7.1.0 refuses to open a connection in that mode** (found on 7 October 2026 by running it: "Globalization Invariant Mode is not supported"). Until the owner and an engineer settle this (`docs/OPEN-WORK.md`), the Check button answers: *"... cannot be read from this copy of the Business Hub yet ..."*. The reader was run here with the language data switched on against a refused connection only: it then gave the plain "server could not be reached" sentence. Nothing has connected to a real server.
