# Old Windows POS: selling, buying and stock (what it does, with numbers)

**Status: all sections written on 7 October 2026 (a reading of the code; nothing was built or run).** About 105 worked examples are included; each was worked by hand from the code and none was run against the old program or the Hub. Section 9 lists what was not understood. This file is written once so that nobody has to read the old VB code again for these jobs; add what you learn when you port.

Related: `docs/old-programs/06-hub-map.md` (what the Hub is), `docs/old-programs/02-masters-accounting-reports.md` (masters, accounting, reports), `docs/MERGE-PLAN.md`, `docs/OWNER-REQUESTS.md`.

Source: `apps/pos-desktop/Source/SmartAvenue99_POS_VB/SmartAvenue99 POS/BillPoint/*.vb` (recovered from compiled files; decompiler markers ignored). In this file `frmPOS.vb:11563` means that file, that line. Line numbers are of the recovered text and can be used to jump straight to the code.

## What to know first (10 lines)

1. **Rounding:** the old POS works in `double` and rounds with `Math.Round(x, 2)`, which is **half to even**; the Hub works in whole minor units and rounds **half up**. They agree on every example except exact half-paisa ties: round-off of a total of 100.50 gives 100.00 in the old POS and 101.00 in the Hub; 5% GST on an exclusive 0.20 gives 0.00 + 0.00 against 0.01 + 0.01 (1.7, 7.1).
2. **One set of till rules** (same in all four till screens): `gross = R2(qty x rate)`; discount by percent (R2) or by amount (kept as a percent to 4 places); tax on the discounted base; Exclusive adds tax, Inclusive carves it out (`gst = base - base/(1+r)`, CGST = SGST = R2(gst/2)); bill `total = taxable + taxes + freight - bill discount` (the bill discount comes **off after tax and does not reduce tax**), round-off half to even, grand total (1.3, 1.4).
3. **Hub gaps in the money layer:** no bill discount, no discount by amount, no tax mode per item (one flag per document), no cess on documents (the tax engine already supports cess and amount discounts; `DocumentService` does not pass them), no estimate, no "convert quote to invoice" (7.1, 7.4).
4. **Names that mislead when importing:** `InvoiceInfo.OtherCharges` = the bill discount; `SubTotal` = taxable plus tax (the Hub's `subtotal_minor` is taxable only); `Product.ReorderPoint` = the wholesale price; service `GrandTotal` is net of the upfront; an estimate adds no tax, so the bill made from it is dearer (8.2, 4.4).
5. **Balances are ledgers, not invoices:** customer and supplier balance = credits minus debits in `CustomerLedgerBook` / `SupplierLedgerBook` (opening balance, advance, receipts on account); later receipts never change `InvoiceInfo.Balance`. The Hub has no ledger, no advance, no opening balance, and a credit note appears not to reduce what a customer owes (2.8, 7.2, 7.3).
6. **Payments:** 16 payment modes (8 paid, 8 credit); all rows together must equal the grand total; credit limit applies only when the customer's switch is "Yes"; the Hub refuses credit for a customer with limit 0 (so import "not enforced" as a flag) (2.1, 2.2, 7.2).
7. **Stock is per lot** (`Temp_Stock`: one row per barcode with MRP, prices, batch, expiry, size, colour, IMEI, cost per unit `EPPrice` = line taxable / qty). A sale only warns about low or negative stock (two switches); a purchase into an existing barcode overwrites that lot's prices and resets its minimum-stock mark. **The Hub has item-level stock only** (no lots, batch, expiry, serial, variant): the biggest gap (6.1, 5.4, 7.6).
8. **Purchases:** the supplier's previous due is **added into the bill total**; reverse charge drops the tax from the total; payments to suppliers are on account; the Hub has no purchase return, no purchase discount or freight, no supplier ledger (5.3, 5.5, 7.5).
9. **Returns, damage, transfers:** a sales return is recalculated from the original rate and discount percent, taxable value proportional, stock back into the same lot, Cash or Credit (the Hub's credit note copies the line exactly: same numbers except ties). Damage is only a counter. Branch transfers and godown use an online service and are **not to be ported as they are**. `StockMovement` can miss rows: take stock from `Temp_Stock` (3.2, 6.4, 6.5).
10. **How to use this file:** write the vectors (L, B, P, R, U, S, E, Q, SV) as Hub tests; vectors marked "differ" need an owner decision first (8.1 step 2); read section 9 before trusting a rule that is not in a table.

## 0. How the old program is built (DONE)

- **One database, SQL Server, no transactions.** Every statement opens its own connection (`ModCS.cs`, a connection string kept outside this file; not copied). Saving a bill is a long chain of separate inserts and updates (`frmPOS.vb:9662` to `10124`). If the program or the PC stops half way, the bill can be half saved. The Hub should save a bill in one transaction (keep the same results, not the same weakness).
- **All money is double arithmetic on text boxes.** Every number is read from a text box with `Conversion.Val(text)` (always a dot as the decimal mark, stops at the first character that is not a number) and rounded with `Math.Round(x, 2)`. In .NET Framework `Math.Round` rounds **half to even** ("banker's rounding"): 0.125 becomes 0.12, 0.135 becomes 0.14, 2.5 becomes 2, 3.5 becomes 4. Test vectors below use exact decimals; use `decimal` and `MidpointRounding.ToEven` in the Hub to match. `Strings.Format(x, "0.00")` is only used on values that are already rounded, so it changes nothing.
- **Four till screens share one set of rules.** I extracted the `Calc`, `Compute` and `GridCalc` functions of every till screen and compared them after removing variable names (`diff` of the extracted text). Result: the tax and total rules are the same in `frmPOS`, `frmPOSNew`, `frmPOSNewTuch` and `frmPOSTouch`. The differences are only these:
  - `frmPOSNew`: same as `frmPOS` but `Calc` is wrapped in a try block that shows "CALC" plus the error.
  - `frmPOSNewTuch` (touch layout): adds a loyalty-points amount per line (`Product.loyality_mode` = "per" means value is a percent of the line, otherwise value per unit; `frmPOSNewTuch.vb` Calc, variables `x1`, `x2`) and adds sums of margin, loyalty points and total MRP in `GridCalc`.
  - `frmPOSTouch`: same as `frmPOSNewTuch` plus a "By Return" amount: payment due = grand total minus payments minus `txtByReturn` (`frmPOSTouch.vb:17305`).
  - `frmPOSNewTuch_Quotation`, `_Service`, `_StockInward`, `_StockTransfer` have a `Calc` that is **identical** to the one in `frmPOSNewTuch` (same text once leading spaces are removed). They are copies of the touch till used for other documents (quotation, service bill, stock inward, stock transfer). Only what they save differs (sections 4 and 6).
  - Menu entry points: `frmMainMenu.vb:11672` (`frmPOS`), `13556` and `13906` (`frmPOSTouch`), `14205` and `14217` (`frmPOSNewTuch`), `11765` (`_Quotation`), `14231` (`_StockTransfer`), `14243` (`_Service`).
- **Stock lives in `Temp_Stock`, one row per lot.** A lot is identified by its barcode and carries its own prices, MRP, batch, dates, size, colour and IMEI. Selling a line reduces `Temp_Stock.Qty` for that product and barcode. Purchases are in `Stock` (header) and `Stock_Product` (lines). Sales are in `InvoiceInfo` (header), `Invoice_Product` (lines) and `Invoice_Payment` (payment rows).
- **Money books** written by sales and purchases: `LedgerBook` (general), `CustomerLedgerBook`, `SupplierLedgerBook`, `BankAccountLedger`, each with Date, Name, LedgerNo (the document number), Label ("Sales", "Receipt"...), Debit, Credit, PartyID. (`ModFunc.vb:251`, `524`, `663`, `733`.) `StockMovement` (ProductID, OpeningStock, StockIn, StockOut, Date, TransID) is a separate in/out history used by the movement report (`ModFunc.vb:75`).
- **Table columns** are listed in `apps/pos-ai-companion/src/SmartRetail.AI.Core/Data/PosSchemaData.cs` for 22 tables (InvoiceInfo, Invoice_Product, Invoice_Payment, Product, Temp_Stock, Customer, Supplier, Stock, Stock_Product, SalesReturn, SalesReturn_Join, PurchaseReturn, PurchaseReturn_Join, Payment, CreditCustomerPayment, SalesMan, Voucher, Income, UnitMaster, Company, Category, SubCategory). The other tables only have a name there; their columns are given in this file where the code showed them.

## 1. Selling: till lines, tax, discount, bill totals, round-off (the arithmetic) (DONE; hand-worked, not run)

Notation: **R2(x)** = round to 2 decimals, half to even. **R4** = to 4 decimals. **R0** = to a whole number, half to even. All examples below were worked by hand from the code; none was run against the old program (it cannot be built or run here). Treat them as the Hub's golden tests, and as the first thing to compare if a real old database becomes available.

### 1.1 What the cashier sees (screen to purpose)

- `frmPOS` (classic till), `frmPOSNew`, `frmPOSNewTuch` and `frmPOSTouch` (touch tills): scan or pick items, set quantity, price and discount, add payment rows, save, print.
- Bill-level helpers on the till: customer box (walk-in "Cash" customer), salesman box, bill sundry box, freight, narration, remarks, e-way bill number, loyalty points use, coupon, gift card, offer.
- `frmSetBillDiscount` (mis-named; it is a small "change a number" dialog with five choices): Item Discount, Item Price, Item Quantity, Bill Discount, Loyalty Discount. "Bill Discount" puts a **flat amount** into the till's bill-discount box `txtbilldisc` (`frmSetBillDiscount.vb:592`).
- Round-off check box on the till (`CheckBox1`), set from the table `Autoroundoff` when the till opens (`frmPOS.vb:8020`): column `c1` = "Yes" turns it on; no row means "No".

### 1.2 Settings that change the arithmetic (where each comes from)

| Setting | Source | Values and effect |
|---|---|---|
| Bill tax mode | `Setting.SalesTax` (read by `GetSalesTaxType`, `frmPOS.vb:7403`) into `txtGSTNonGST` | "GST" (or blank, treated as GST) or "NON GST" (no tax at all, own invoice series; see 2.7) |
| Item tax mode | `Product.STax` into `txtTaxType` at barcode entry (`frmPOS.vb:12077`) | "Exclusive" (blank counts as Exclusive), "Inclusive", "Exempt GST", "No Taxes" |
| Tax split | customer state against company state (`frmPOS.vb:12109` to `12128`) | customer state blank or same as `Company.State`: CGST % and SGST % are the product's `CGST` and `SGST`, IGST % is 0. Different state: CGST % = 0, SGST % = 0, **IGST % = product CGST + product SGST**. CESS % is the product's `CESS` in both cases. |
| Price tier | radio buttons `RadioButton1` (Retail) and `RadioButton2` (Wholesale) | Retail uses `Temp_Stock.SPrice`, Wholesale uses `Temp_Stock.WPrice` (`frmPOS.vb:12082`). Neither selected: Retail. The tier is saved on the invoice as `InvoiceInfo.CType` ("Retail" or "Wholesale"). After the first line is added the choice is locked (`frmPOS.vb:8953`). |
| Purchase rate for margin | `Temp_Stock.EPPrice` | cost of this lot as the shop booked it |
| Discount % at entry | order of precedence at barcode entry (`frmPOS.vb:12093` to `12102`) | 1. customer discount % if the customer has discount on (`DiscStatus` = "Yes" and `DiscPer` > 0); 2. else the item offer % (`Offer2.DiscPerc` for this product and today); 3. else `Product.Discount`. |
| Round-off on | `Autoroundoff.c1` | see 1.5 |

### 1.3 One line: exact arithmetic order (`Calc`, `frmPOS.vb:11563` to `11765`)

Inputs: `qty` (text box `TextBox2`, see unit rule below), `rate` (`txtSalesRate`), `discPer` (`txtDiscPer`), `disc` (`txtDisc`, amount), `cgstPer`, `sgstPer`, `igstPer`, `cessPer`, `purchaseRate` (`txtPurchaseRate`). Discount type box `cmbDiscountType`: index 0 = percent drives the amount, index 1 = amount drives the percent.

**Unit rule** (`frmPOS.vb:14372`): if the chosen unit is the product's alternate unit, `qty = enteredQty / Conv` (quantity in the main unit); otherwise `qty = enteredQty`. The grid keeps `qty` in the main unit and `AltQty = qty * Conv`. The price `rate` is per main unit.

**Step A, gross and discount (all tax modes):**
1. `gross = R2(qty * rate)`  (`frmPOS.vb:11570`)
2. Percent mode: `disc = R2(gross * discPer / 100)`  (`11572`). Amount mode: `discPer = R4(disc * 100 / gross)` and `disc` stays as typed  (`11580`).
3. `base = gross - disc` (not rounded again) (`11585`).

**Exclusive (`txtTaxType` = "Exclusive" or blank), lines `11566` to `11602`:**
4. `cgst = R2(base * cgstPer / 100)`, `sgst = R2(base * sgstPer / 100)`, `igst = R2(base * igstPer / 100)`, `cess = R2(base * cessPer / 100)`, each rounded on its own.
5. `lineTotal = R2(base + cgst + sgst + igst + cess)`.
6. `margin = R2(qty * (rate - purchaseRate) - disc)`.
7. `taxableAmt = R2(qty * rate - disc)` (`TaxableAmt`, `11768`; uses the **unrounded** `qty * rate`, not `gross`).

**Inclusive (`txtTaxType` = "Inclusive"), lines `11684` to `11720`:** `rate` already contains the tax.
4. `base = gross - disc`.
5. `gst = R2(base - base / (1 + (cgstPer + sgstPer) / 100))`; `cgst = R2(gst / 2)`; `sgst = R2(gst / 2)` (the same `gst` is used for both, so CGST always equals SGST).
6. `igst = R2(base - base / (1 + igstPer / 100))`; `cess = R2(base - base / (1 + cessPer / 100))`. Each tax is carved from the same `base` independently.
7. `lineTotal = R2(base)`. Tax is not added on top.
8. `taxableAmt = R2(qty * rate - disc - (cgst + sgst + igst + cess))` (uses the already rounded amounts).
9. `margin = R2(qty * rate - disc - (cgst + sgst + igst + cess) - purchaseRate * qty)`.

**Exempt GST (`txtTaxType` = "Exempt GST"), lines `11603` to `11642`:** CGST %, SGST % and IGST % are forced to 0.00; **CESS % is not reset**, so `cess = R2(base * cessPer / 100)` is still charged and added (quirk, see 1.8). Everything else as Exclusive.

**No Taxes (`txtTaxType` = "No Taxes"), lines `11643` to `11683`:** all four percents forced to 0.00; total = base.

**NON GST bill (`txtGSTNonGST` = "NON GST"), lines `11723` to `11764`:** all four percents forced to 0.00, whatever the item says; total = base; `TaxableAmt` is computed as for Exclusive.

**What a till line keeps** (grid columns, `frmPOS.vb:9076`): 0 product id, 1 HSN, 2 name, 3 barcode, 4 qty, 5 rate, 6 discount %, 7 discount amount, 8 CGST %, 9 CGST amount, 10 SGST %, 11 SGST amount, 12 IGST %, 13 IGST amount, 14 CESS %, 15 CESS amount, 16 line total, 17 purchase rate, 18 margin, 19 description, 20 temp qty, 21 IMEI 1, 22 IMEI 2, 23 MRP, 24 taxable amount, 25 alt qty, 26 alt unit, 27 tax mode of the item, 28 total MRP (qty x MRP), 29 free promo qty, 30 main unit, 31 batch, 32 mfg, 33 exp, 34 size, 35 colour.

**Adding the same item twice** (`frmPOS.vb:8985` to `9068`): if product id, barcode, MRP, purchase rate, sale rate, batch, mfg, exp, size and colour are all equal to an existing row, the new line is **merged**: qty, discount amount, each tax amount, line total, margin and taxable amount are added to the existing row; the discount % shown is the new one; descriptions are joined with " and ". Otherwise a new row is added. Merging does **not** recompute from the new totals; it adds the already rounded line values (so a merged row can differ by a paisa from one line of the combined quantity).

**Free quantity promotion** (`Promotion` table: `MinQty`, `FreeQty`, `Active` = "Yes", `ExpiryDate` today or later, per `ProductID`; `frmPOS.vb:9021` and `9085`): new row with `qty >= MinQty`: `qty = qty + Floor(FreeQty * qty / MinQty)`; the free part is saved in column 29 (`PromoQty`) and in the `qty` column; **the line's money is for the paid quantity only**. Stock is reduced by the full `qty` (paid plus free).

**Expired lot** (`frmPOS.vb:8971`): if the lot has an expiry date and the bill date is on or after it, the line is refused ("You are not allowed to sale the expired product").

**Zero and negative quantity:** zero is refused (`8965`); no check against a negative quantity was found (a negative line would be accepted and reduce the bill). Not verified further.

**Last price memory:** on saving, `Product.LastPrice` is set to each line's sale rate (`frmPOS.vb:9954`). Adding a line also writes the typed sale rate back to the product master when it differs from it (`autoupdatesaleprice`, `frmPOS.vb:8810`): Retail tier writes `Product.SellingPrice`, Wholesale tier writes **`Product.ReorderPoint`, which is the default wholesale price column** (confirmed by the purchase screen, 5.2). It does so only when the till variables `b0` to `b9` are all empty (what they hold was not studied) and the rate is more than zero.

### 1.4 Bill totals: exact order (`GridCalc`, `SubTotal`, `alldiscountcalc`, `Compute`)

1. `GridCalc` (`frmPOS.vb:11529`): `sumCGST`, `sumSGST`, `sumIGST`, `sumCESS` = sums of grid columns 9, 11, 13, 15; `sumTaxable` = sum of column 24; each is `R2`. `sumTaxable` goes to `TextBox11` and is saved as `InvoiceInfo.TaxableAmt`.
2. `SubTotal` (`frmPOS.vb:11483`, called when a line is added or removed): `R2( sum over lines of (col24 + col9 + col11 + col13 + col15) )` = taxable plus taxes. Saved as `InvoiceInfo.SubTotal`. (So "SubTotal" is **not** before tax; in Exclusive it is the sum of line totals, in Inclusive it is the sum of the tax-inclusive prices after discount.)
3. `alldiscountcalc` (`frmPOS.vb:16476`): `billDiscount = R2( txtbilldisc + (cb1 ? txtApplyPoint : 0) + (cb2 ? txtOffer : 0) + txtCoupAmt + txtgiftamt )`. `txtbilldisc` = flat amount typed by the cashier; `txtApplyPoint` = money value of loyalty points redeemed (only if check box `cb1`); `txtOffer` = bill offer (only if `cb2`); coupon and gift amounts always count.
4. `Compute` (`frmPOS.vb:11504`):
   - `total = R2( sumTaxable + sumCGST + sumSGST + sumIGST + sumCESS + freight - billDiscount )`. Freight (`txtFreightCharges`) is **not taxed**. **The bill discount is taken off after tax, and tax is not reduced by it.**
   - `rounded = R0(total)` (half to even).
   - `roundOff = R2(rounded - total)` if the round-off box is checked, else 0.00.
   - `grand = R2(total + roundOff)`.
   - `payment suggestion = grand` (box `txtPayment`).
   - `due = R2(grand - totalPaid)`, where `totalPaid` is the sum of the payment rows of the paid kinds only (see 2.1). In `frmPOSTouch`: `due = R2(grand - totalPaid - byReturn)`.
5. Loyalty points earned on the bill (`frmPOS.vb:16388`): `Round(grand * pointsPerUnit)` when "calculate on" = "WITH GST"; otherwise `Round(grand - totalTax) * pointsPerUnit` (`totalTax` = `TextBox12` = sum of CGST + SGST + IGST + CESS). Left to the customers work package; noted here because it uses `grand`.

### 1.5 Round-off (exact)

- Switch: `Autoroundoff.c1` = "Yes". Default (no row) = No.
- `R0` is half-to-even on the **total**, not half up: 100.50 becomes 100, 101.50 becomes 102, 102.50 becomes 102.
- Round-off is stored in `InvoiceInfo.RoundOff` (can be negative). `GrandTotal = Total + RoundOff`.

### 1.6 What is saved for a sale (`btnSave_Click`, `frmPOS.vb:9444`; columns in `PosSchemaData.cs`)

`InvoiceInfo` (`frmPOS.vb:9662`): `Inv_ID` (next number), `InvoiceNo` (see 2.7), `InvoiceDate` (the date picker, date only), `TaxType` ("GST" or "NON GST"), `Customer_ID`, `SalesmanID`, `SubTotal` (1.4 step 2), `CGST`, `SGST`, `IGST`, `CESS` (sums), `GrandTotal`, `TotalPaid` (paid kinds only), `Balance` (= due), `Remarks`, `FreightCharges`, **`OtherCharges` = the bill discount (`txtBillDiscount`)** (the column name is misleading; the total bill discount is stored here), `Total`, `RoundOff`, `Narration`, `Eway`, `TillID` (the till number text), `Operator` (user), `BillSundry` (text, e.g. "TCS"), `OfferAmt` (= `txtOffer` if `cb2` ticked, else 0), `LoyaAmt` (= `txtApplyPoint`), **`BillDiscount` = only the cashier-typed part (`txtbilldisc`)**, `AddLpoint` (points earned), `TCSPer` (see below), `TaxableAmt` (= `sumTaxable`), `CType` (Retail or Wholesale), `Tender`, `Refund`, `BillCash`, `CouponAmt`, `GiftAmt`.
  - `Tender`/`Refund`/`BillCash` (`frmPOS.vb:9720` to `9728`): if the "tendered" box is 0 or less: `Tender = BillAmt`, `Refund = 0`; otherwise `Tender = TendAmt`, `Refund = RefAmt` (cash given and change returned). `BillCash = BillAmt`. How `BillAmt` is derived from the cash row: see Not understood.
  - `TCSPer`: "TCS" bill sundry (tax collected at source) with "Yes" status: the "without PAN" percent if the customer has no PAN, else the "with PAN" percent; otherwise 0. TCS is **not** added in `Compute`; the amount is handled by `tcsconn` (`frmPOS.vb:16516`) and shown separately. Not studied further (India tax module).
`Invoice_Product` (`frmPOS.vb:9759`): one row per grid line with the columns above; `InvoiceID` = `Inv_ID`.
`Invoice_Payment` (`frmPOS.vb:9814`): one row per payment row: `PaymentMode` (text), `TotalPaid`, `PaymentDate`, `BankAc` (account text).

### 1.7 Test vectors (hand-worked; copy these into the Hub's tests)

All GST 18% = CGST 9 + SGST 9 unless stated. "Total" is the line total.

**Lines**

| # | Case | Inputs | Arithmetic | Result |
|---|---|---|---|---|
| L1 | Exclusive, plain | qty 1, rate 100.00, no discount, 9+9; purchase rate 60 | gross 100.00; cgst R2(9.0000)=9.00; sgst 9.00; total R2(100+9+9)=118.00; taxable R2(100-0)=100.00; margin R2(1x(100-60)-0)=40.00 | CGST 9.00, SGST 9.00, total 118.00, taxable 100.00, margin 40.00 |
| L2 | Exclusive, percent discount | qty 3, rate 33.33, disc 10%, 9+9 | gross R2(99.99)=99.99; disc R2(9.999)=10.00; base 89.99; cgst R2(8.0991)=8.10; sgst 8.10; total R2(89.99+8.10+8.10)=106.19; taxable R2(99.99-10.00)=89.99 | disc 10.00, CGST 8.10, SGST 8.10, total 106.19, taxable 89.99 |
| L3 | Exclusive, amount discount | qty 2, rate 250.00, disc amount 37.50, GST 12% (6+6) | gross 500.00; discPer R4(37.50x100/500)=7.5000; base 462.50; cgst R2(27.75)=27.75; sgst 27.75; total R2(462.50+55.50)=518.00; taxable 462.50 | disc % 7.5000, CGST 27.75, SGST 27.75, total 518.00 |
| L4 | Inclusive, plain | qty 1, rate 118.00, 9+9 | base 118.00; gst R2(118-118/1.18)=R2(18.00)=18.00; cgst R2(9.00)=9.00; sgst 9.00; total 118.00; taxable R2(118-(9+9))=100.00 | CGST 9.00, SGST 9.00, total 118.00, taxable 100.00 |
| L5 | Inclusive, odd price | qty 2, rate 99.99, GST 5% (2.5+2.5) | gross R2(199.98)=199.98; 199.98/1.05=190.45714...; gst R2(9.52286)=9.52; cgst R2(4.76)=4.76; sgst 4.76; total 199.98; taxable R2(199.98-9.52)=190.46 | CGST 4.76, SGST 4.76, total 199.98, taxable 190.46 |
| L6 | Inclusive, small | qty 1, rate 10.00, 5% (2.5+2.5) | 10/1.05=9.52381; gst R2(0.47619)=0.48; cgst R2(0.24)=0.24; sgst 0.24; taxable R2(10.00-0.48)=9.52 | CGST 0.24, SGST 0.24, total 10.00, taxable 9.52 |
| L7 | Inclusive, **midpoint**: tax of one paisa vanishes | qty 1, rate 0.21, 5% (2.5+2.5) | 0.21/1.05=0.20; gst R2(0.01)=0.01; cgst R2(0.005)=**0.00** (half to even); sgst 0.00; taxable R2(0.21-0)=0.21 | CGST 0.00, SGST 0.00, total 0.21, taxable 0.21 (the old rule loses 0.01 of tax; see 1.8) |
| L8 | Inclusive, other state | qty 1, rate 118.00, IGST 18 (CGST and SGST 0) | gst R2(118-118/1.00)=0.00; cgst 0.00; sgst 0.00; igst R2(118-118/1.18)=18.00; taxable R2(118-18)=100.00 | IGST 18.00, total 118.00, taxable 100.00 |
| L9 | Exclusive, other state | qty 1, rate 100.00, IGST 18 | igst R2(18.00)=18.00; total 118.00 | IGST 18.00, total 118.00 |
| L10 | Exempt GST with CESS | qty 2, rate 100.00, item "Exempt GST", CESS 5% | CGST/SGST/IGST % forced 0; cess R2(200x5/100)=10.00; total R2(200+10)=210.00 | CESS 10.00, total **210.00** (quirk 1.8) |
| L11 | No Taxes with CESS | qty 2, rate 100.00, item "No Taxes", CESS 5% | all % forced 0 | total 200.00 |
| L12 | NON GST bill | any item with 18%, qty 1, rate 100.00 | all % forced 0 | total 100.00, taxable 100.00 |
| L13 | Percent discount rounding | qty 1, rate 99.95, disc 12.5%, 9+9 exclusive | disc R2(12.49375)=12.49; base 87.46; cgst R2(7.8714)=7.87; sgst 7.87; total R2(87.46+15.74)=103.20; taxable R2(99.95-12.49)=87.46 | disc 12.49, total 103.20 |
| L14 | Weight sale | qty 0.250, rate 399.00, 5% excl (2.5+2.5) | gross R2(99.75)=99.75; cgst R2(2.49375)=2.49; sgst 2.49; total R2(99.75+4.98)=104.73 | CGST 2.49, SGST 2.49, total 104.73 |
| L15 | Alternate unit | product per kg, rate 80.00, alt unit gram, Conv 1000; customer buys 250 gram; 5% excl | qty 250/1000=0.25; gross R2(20.00)=20.00; cgst R2(0.50)=0.50; sgst 0.50; total 21.00; AltQty 0.25x1000=250 | qty 0.25 kg, total 21.00, alt qty 250 |
| L16 | Free quantity | buy 5 get 1 free, qty 12 new row | free = Floor(1x12/5)=2; saved qty 14; PromoQty 2; money for 12 units; stock falls by 14 | qty 14, promo 2 |

**Bills**

| # | Case | Arithmetic | Result |
|---|---|---|---|
| B1 | L1 + L2 (exclusive), round-off OFF | sumTaxable 100.00+89.99=189.99; sumCGST 9.00+8.10=17.10; sumSGST 17.10; SubTotal 189.99+17.10+17.10=224.19; total R2(224.19)=224.19; roundOff 0.00 | grand 224.19 |
| B2 | same, round-off ON | R0(224.19)=224; roundOff R2(224-224.19)=-0.19; grand R2(224.19-0.19)=224.00 | RoundOff -0.19, grand 224.00 |
| B3 | round-off midpoints, ON | total 100.50: R0=100, roundOff -0.50, grand 100.00. Total 101.50: R0=102, +0.50, grand 102.00. Total 102.50: R0=102, -0.50, grand 102.00. Total 0.50: R0=0, -0.50, grand 0.00. Total 99.49: R0=99, -0.49, grand 99.00. Total 99.51: R0=100, +0.49, grand 100.00 | as listed |
| B4 | freight and bill discount (B1 lines) | total R2(189.99+17.10+17.10+0+0 + 20.00 - 50.00)=194.19; round-off ON: R0=194; roundOff -0.19; grand 194.00. Tax stays 34.20 although the bill is cheaper by 50 | total 194.19, grand 194.00, tax 34.20 |
| B5 | bill discount made of parts | txtbilldisc 25.00, points redeemed 10.00 (cb1 ticked), offer 3.00 (cb2 not ticked), coupon 5.00, gift 2.50: R2(25+10+5+2.50)=42.50. With cb2 ticked: R2(25+10+3+5+2.50)=45.50 | 42.50 and 45.50 |
| B6 | inclusive lines L4 + L5 | sumTaxable 100.00+190.46=290.46; sumCGST 9.00+4.76=13.76; sumSGST 13.76; SubTotal 290.46+13.76+13.76=317.98 (= 118.00+199.98); total 317.98 | grand 317.98 (round-off OFF) |
| B7 | other-state lines L8 + L9 | sumTaxable 100.00+100.00=200.00; sumIGST 18.00+18.00=36.00; SubTotal 236.00; total 236.00 | grand 236.00 |
| B8 | payments and balance (B4's grand 194.00) | rows: By Cash 100.00, PhonePe 50.00, Credit Terms - 30 days 44.00. Sum of all rows 194.00 so save is allowed. totalPaid (paid kinds only) = 150.00; due R2(194.00-150.00)=44.00. InvoiceInfo.TotalPaid 150.00, Balance 44.00. Next payment suggestion R2(194.00-194.00)=0.00 | TotalPaid 150.00, Balance 44.00 |
| B9 | save checks | rows summing to 193.99: refused "Payment/Credit can not be less than grand total". Rows summing to 194.01: refused "can not be more than grand total". | refused both ways |

### 1.8 Quirks and probable bugs (keep or fix?)

1. **Banker's rounding everywhere** (`Math.Round`). Keep: it decides real paise on real bills and old reports. The Hub must round half to even at the same steps. Note: with doubles, a value like 1.005 is stored as 1.00499999999999989..., so even "ideal" half-way cases can go either way in the old program; decimals in the Hub will differ on such rare cases. Keep decimals (fix?, accept as a safer rule).
2. **Inclusive CGST/SGST split loses or gains a paisa** (L7): `gst` is rounded first, then halved and rounded again. Keep for now (same numbers as old bills); fix? only with the owner's word because old printed invoices would differ.
3. **Inclusive CESS** is carved from the same base as GST, independently, so taxable value is overstated when CESS is present (true taxable = base / (1 + (GST% + CESS%)/100)). fix? with the owner's word (affects GST returns).
4. **Exempt GST items still pay CESS** (L10). Looks like a bug (Exempt should be zero tax). fix? Probably; confirm with owner.
5. **Bill discount is taken after tax and tax is not reduced** (B4). It matches how this program reports; many tax rules want discount allocated across lines before tax. fix? Ask owner; keep for matching old data.
6. **`SubTotal` is taxable + tax**, not the pre-tax sum; **`OtherCharges` holds the bill discount** while `BillDiscount` holds only the typed part. Keep for reading old data; the Hub should name these properly and map when importing.
7. **Merged rows add rounded values**, so one merged row can differ by a paisa from a single line of the combined quantity. Keep.
8. **No negative-quantity check** found at the till. fix? Probably yes (use a return instead), but old bills may rely on it.
9. **Quantity compared as a whole number when checking stock** (`CInt(Math.Round(qty))` at `frmPOS.vb:9606` and `9639`): selling 2.4 against stock 2.3 is not warned. fix?
10. **Customer offer** adds `CustomerOffer.DiscPerc` to the bill discount as an **amount** (`frmPOS.vb:16479`) although the column name says percent. Unknown which is meant (see Not understood). Do not port until clarified.
11. **Payment total check uses floating compare** of two rounded values (`frmPOS.vb:9556`). Harmless with 2-decimal text; use decimals in the Hub.



## 2. Selling: payments, balances, ledgers, hold, edit, delete, bill numbers (DONE; hand-worked, not run)

All line numbers are in `frmPOS.vb` unless another file is named. The other till screens do the same with the same SQL (checked for `frmPOSTouch` by search; not line by line).

### 2.1 Payment rows (what the cashier sees: a small grid under the bill)

Sixteen payment modes, in this order (`frmPOS.Designer.vb:3513`; the list index is used in the code):

| Index | Mode text (stored as is in `Invoice_Payment.PaymentMode`) | Kind | Needs bank account |
|---|---|---|---|
| 0 | By Cash | **paid** | no |
| 1 | By Cheque | paid | yes |
| 2 | By Credit Card | paid | yes |
| 3 | By Debit Card | paid | yes |
| 4 | PhonePe | paid | yes |
| 5 | Google Pay | paid | yes |
| 6 | Paytm | paid | yes |
| 7 | E-Wallet | paid | yes |
| 8 to 14 | Credit Terms - 7 days, 15, 30, 60, 90, 120, 180 days | **credit** (customer will pay later) | no |
| 15 | Credit Terms - Adjust | **credit** (use the customer's advance balance) | no |

Rules when a row is added (`btnAdd1_Click`, `10942`):
1. The bill must have at least one line, a mode must be chosen, a bank account chosen for index 1 to 7, and the amount must be more than zero.
2. "Credit Terms - Adjust" can be added **once** per bill, and its amount may not be more than the customer's signed balance (`TextBox18`: positive when the customer has an advance). A customer who owes money cannot "adjust".
3. The amount is stored as text with two decimals: `R2(amount)`.
4. After adding: `totalPaid = R2( sum of rows of the eight paid kinds only )` (`TotalPayment`, `8053`); `Compute` runs; the suggestion box shows `R2(grand - sum of ALL rows)` (`caldgv2`, `8101`).
5. Cash and "other" amounts for the till drawer (`OPCode2`, `8123`): `BillAmt` = sum of "By Cash" rows; `UpiAmt` = sum of every other row (credit rows included). Change: `Refund = R2(Tender - BillAmt)` where `Tender` is the cash handed over (typed on the number pad).
6. Touch tills: the "By Return" button adds a row "ByReturn" (see section 3).

### 2.2 Checks when Save is pressed (`btnSave_Click`, `9444`), in order

1. Trial mode only: more than 5 bills in the bill's month is refused (a licence rule of the old program; do not port).
2. Invoice number is made unless the manual-number box is ticked (`auto`, see 2.7).
3. Customer name must not be empty. If the name is not a saved customer it must not already exist (by name or by phone) and a new customer is created on the spot (`NewWalkInCustomer`).
4. Loyalty points to use must not be more than the points the customer has (`txtApplyPoint` against `txtusepoint`, where points = sum of `LPoint.Addpoint` minus sum of `LPoint.Usepoint` for the customer).
5. Contact number must not be empty; bill sundry box must not be empty; the cart must have a line; there must be a payment row.
6. `sum of ALL payment rows` (including credit rows) must **equal** `grand` exactly: less is refused ("Payment/Credit can not be less than grand total"), more is refused ("... more than grand total").
7. Credit limit (`9581` to `9588`): let `balance` = customer's signed balance read before this bill (= sum of ledger credits minus sum of debits, `CustomerBalance`, `15953`), `credit` = sum of the credit-kind rows (`CreditAmount`, `17344`). `TextBox19 = balance - credit` (`16610`). If `TextBox19 < 0` and `|TextBox19| > Customer.Limit` and `Customer.Lstatus = "Yes"`, the bill is refused ("Customer Credit limit is exceeded").
8. Optional warnings (the cashier may answer Yes to go on): "minimum stock limit crossed" when `CInt(Round(qty)) > Temp_Stock.Qty - Temp_Stock.StLimit` (switch `CheckBox8`), and "added qty are more than available qty" when `CInt(Round(qty)) > Temp_Stock.Qty` (switch `CheckBox6`). **If the switch is off there is no stock check at all: stock can go negative.** Neither check blocks; they only ask.
9. A company profile row must exist.

### 2.3 What Save writes, in order (`9660` to `10124`; no transaction)

1. `InvoiceInfo` row (columns in 1.6).
2. If a salesman is chosen: `Salesman_Commission(InvoiceID, CommissionPer, Commission)` with `Commission = Val( sum over lines of (qty x rate - discountAmount) x CommissionPer / 100 )` (`9738` to `9751`; no rounding; note it ignores tax and bill discount).
3. `Invoice_Product` rows (one per grid line), `Invoice_Payment` rows (one per payment row).
4. Ledgers (2.4).
5. Stock: for each line `Temp_Stock.Qty = Qty - line qty` where product and barcode match (`9932`); `Product.LastPrice = line rate` (`9954`).
6. `StockMovement` for lines with qty > 0 (`9970` to `10009`): if the product has **no** movement row: insert (OpeningStock 0, StockIn 0, StockOut = qty, Date = bill date, TransID = invoice number). If it has rows: the code reads a second row from the same reader, so the insert happens only when the product has **two or more** rows; then OpeningStock = sum of (StockIN - StockOUT) for earlier dates. As recovered, a product with exactly one earlier row gets no row for this sale. This may be an artefact of the recovery; see Not understood.
7. `LPoint(Invno, Invdate, Custid, Custname, Custcontact, Grandtotal, Perc, Addpoint, Usepoint, Coupon)` (`10018`): `Addpoint` = points earned only when the customer's loyalty is "Activated", else 0; `Usepoint` = points used.
8. `Customer.Lvisitdate = bill date`.
9. `SaleGST(ID, InvNo)` for a GST bill, or `SaleNoTax(ID, InvNo)` for a NON GST bill: this is the invoice-number counter (`10047` to `10070`).
10. If a broker (agent) is chosen and the broker commission is more than zero: `BrokerLdr` (commission = chosen %, or amount) (`10071`). Not studied further.
11. `DeleteHoldRecord` (the hold this bill came from is removed), then SMS if switched on (`smssender`), cash drawer opens when `totalPaid > 0`, gift card and loyalty updates, "print the invoice?" question.

### 2.4 Ledger postings for a sale (exact)

For invoice number `INV`, customer `C` (id `P`):
- `LedgerBook`: (bill date, `C`, `INV`, "Sales", Debit = grand, Credit = 0, PartyID `P`).
- `CustomerLedgerBook`: the same, with `CustNameid` = "name-id" and the narration as remarks.
- For each payment row: **By Cash**: `LedgerBook` (payment date, "Cash Account", `INV`, "Receipt", Debit 0, Credit = amount) and the same in `CustomerLedgerBook`. **Cheque, cards, PhonePe, Google Pay, Paytm, E-Wallet**: same with account name "Bank Account". Credit and Adjust rows post **nothing**.
- For each bank-type row: `BankAccountLedger` (the till's payment-date box, **not the row's date**, account number text, `INV`, label "Sale-<mode>", Debit 0, Credit = amount).
- Customer balance shown at the till = `sum(Credit) - sum(Debit)` over `CustomerLedgerBook` for the customer (`15913`): **positive means the shop holds the customer's advance ("Cr"), negative means the customer owes ("Dr")**.

### 2.5 Hold and retrieve (`Btnhold_Click`, `15610`; `frmHoldrecord.vb`)

- Needs at least one line. A new customer name is created as in save.
- Writes `InvoiceHold` (header: `Hold_ID` "H-0001" counted from the highest `HID`, date, tax type, customer, salesman, totals, freight, `OtherCharges` = bill discount, narration, till id, operator, offers, loyalty, tier, ...) and `InvoiceHoldProduct` (lines, same columns as `Invoice_Product`). **TotalPaid = 0; no payment rows are kept; stock does not move; no ledger rows; no invoice number is used.**
- Retrieve (`frmHoldrecord`): the list shows holds of this till (`InvoiceHold.TillID` = the PC's host name) or all; picking one loads the lines back into the till grid; the hold is deleted when the bill is saved (`DeleteHoldRecord`, `15791`) or when someone deletes it in the list. "Delete all hold records" exists.
- Purchase has its own hold (`frmHoldrecord_Purchase`).

### 2.6 Edit and delete a saved bill

- **Edit** (`btnUpdate_Click`, `10234`): refused if the bill has a sales return ("Unable to update..Already in use in Sales Return"). Same checks as save. Then: `InvoiceInfo` updated in place (the invoice number stays); old payment rows deleted and rewritten; **stock: for each line of the original bill (kept in `DataGridView3`) `Temp_Stock.Qty += old qty`, then for each current line `Temp_Stock.Qty -= new qty`** (`10486`, `10508`); `Invoice_Product` deleted and rewritten; commission and broker rows updated; `StockMovement.StockOUT` and date updated; ledgers: `LedgerBook` "Sales" and "Receipt" rows and all `CustomerLedgerBook` rows with the invoice number are deleted and written again; bank ledger rows deleted and rewritten; loyalty row rewritten.
- **Delete** (`DeleteRecord`, `9285`): refused if a sales return exists. Otherwise: `LPoint` row deleted; `InvoiceInfo` deleted; stock added back (`Temp_Stock.Qty += qty`); `Invoice_Product`, `Invoice_Payment`, `StockMovement` rows of the invoice deleted; `Customer.Lvisitdate` set; broker row, all ledger rows (general, customer, bank), discount record and the number row (`SaleGST` or `SaleNoTax`) deleted; the action is written to the log (`LogFunc`: user and text, e.g. "deleted the bill (Products) having invoice no. ..."). **Deleting the highest-numbered bill frees its number again** because the next number is read as the highest remaining one plus 1; deleting a bill in the middle leaves a permanent gap.

### 2.7 Bill numbering (exact)

- Code: `Invcode` table, columns `Code` (prefix) and `c10` (suffix), read by `Invoicecode` (`7965`). Defaults when no row or blank: prefix "GST"; suffix = `F1 + "/" + F2` where `F1` = 4 characters taken from the company's financial-year-start text (`Substring(7, 4)`) and `F2` = 2 characters from the year-end text (`Substring(9, 2)`) (`7499`). So a default suffix looks like "2025/26" (assuming the dates are stored as `dd/MM/yyyy`; not verified, see Not understood).
- GST bill: `Code + "-" + N + "-" + suffix` where `N` = (highest `SaleGST.ID`) + 1, shown with at least 4 digits ("0001", "0010", "0999", "1000", "10000"). (`GenerateIDGST`, `7887`; `auto`, `8002`.)
- NON GST bill: `"SINV-" + N + "-" + suffix` with its own counter `SaleNoTax.ID` (`7926`).
- `InvoiceInfo.Inv_ID` is a separate counter: (highest `Inv_ID`) + 1, same 4-digit padding (`7848`).
- Hold: `"H-" + N` from `InvoiceHold.HID` (`15562`).
- Nothing locks the counters: two tills saving at the same moment can get the same number. The number is made when the cashier presses Save, so a number is not "used up" by an abandoned bill.

### 2.8 Customer payments later (receipts on account) (`frmCreditCustomerReceipt.vb:2124` to `2176`)

- Writes `CreditCustomerPayment(T_ID, TransactionID, Date, PaymentMode, Customer_ID, Amount, Remarks, PaymentModeDetails, BankAcNo)`, `LedgerBook` ("Cash Account" or "Bank Account", label "Receipt", Credit = amount), `CustomerLedgerBook` (same), and for bank modes `BankAccountLedger` (labels "Receipt-By Cheque", "Receipt-By Online Transfer", "Receipt-PhonePe", "Receipt-Google Pay", "Receipt-Paytm", "Receipt-E Wallet"). Number series `SrReceipt`, code from `Invcode`.
- **It never touches `InvoiceInfo.TotalPaid` or `Balance`**. Balances of the old POS live in the customer ledger, not on each invoice. A receipt is "on account", not tied to a bill.

### 2.9 Test vectors (hand-worked)

| # | Case | Arithmetic | Result |
|---|---|---|---|
| P1 | Cash only | grand 118.00; rows: By Cash 118.00 | sum rows 118.00 = grand: saved. TotalPaid 118.00, Balance 0.00. Ledger: Sales Dr 118.00; Cash Receipt Cr 118.00; customer balance 0.00 |
| P2 | Split with credit (B8) | grand 194.00; Cash 100.00, PhonePe 50.00, Credit Terms - 30 days 44.00 | TotalPaid 150.00, Balance 44.00. LedgerBook/CustomerLedgerBook: Sales Dr 194.00; Cash Receipt Cr 100.00; Bank Account Receipt Cr 50.00. BankAccountLedger: "Sale-PhonePe" Cr 50.00. Customer balance (if it was 0) = 150.00 - 194.00 = -44.00, shown "44.00 Dr" |
| P3 | Credit limit passes | balance -500.00 (owes 500), limit 1000.00 enforced, bill credit 400.00 | TextBox19 = -500 - 400 = -900; 900 is not more than 1000: allowed |
| P4 | Credit limit stops | same, credit 600.00 | TextBox19 = -1100; 1100 > 1000: refused |
| P5 | Adjust against advance | balance +200.00, bill 200.00, row Credit Terms - Adjust 200.00 | 200 is not more than 200: row allowed; TextBox19 = 200 - 200 = 0: no limit check. Ledger: Sales Dr 200.00, no receipt; balance 200 - 200 = 0 |
| P6 | Adjust too big | balance +200.00, Adjust 250.00 | refused "not allowed to adjust excess amount than balance" |
| P7 | Customer owes, tries Adjust | balance -50.00, Adjust 10.00 | 10 is more than -50: refused |
| P8 | Limit not enforced | `Lstatus` not "Yes", any credit | no limit check |
| P9 | Change from cash | grand 194.00, By Cash 194.00, tendered 200.00 | Refund R2(200.00 - 194.00) = 6.00; saved `Tender` 200.00, `Refund` 6.00, `BillCash` 194.00 |
| P10 | Tender box empty | tendered 0 | `Tender` = BillAmt, `Refund` 0 |
| P11 | First GST bill of a new shop | `SaleGST` empty, default prefix and suffix, FY 2025/26 | `GST-0001-2025/26` (Inv_ID "0001") |
| P12 | Number padding | last ID 9, 99, 999, 9999 | next "0010", "0100", "1000", "10000" |
| P13 | NON GST | `SaleNoTax` has 41 rows (highest ID 41) | `SINV-0042-2025/26` |
| P14 | Own prefix | `Invcode` Code "TAX", c10 "B", last GST ID 6 | `TAX-0007-B` |
| P15 | Delete last bill | highest ID 7 deleted | next bill number 0007 again; delete ID 5 instead: next stays 0008, 0005 is a permanent gap |
| P16 | Edit stock | original line qty 3, edited to qty 5, same barcode | stock += 3 then -= 5: net -2 |
| P17 | Delete stock | line qty 3 | stock += 3 |
| P18 | Commission | salesman 2.5%, lines: 2 x 100.00 - 10.00 and 1 x 50.00 - 0.00 | basis (200-10)+(50-0) = 240.00; commission 240.00 x 2.5 / 100 = 6.00 (not rounded in code) |
| P19 | Loyalty earned | grand 1000.00, 0.01 point per rupee, "calculate on" = WITH GST | Round(1000.00 x 0.01) = 10 points |

### 2.10 Quirks and probable bugs (keep or fix?)

1. **No transaction** around the save chain (keep the results, fix the weakness: fix).
2. **Numbers are max + 1 without a lock** (duplicates possible with two tills). fix (the Hub's `number_series` inside a transaction already does this right).
3. **Per-invoice balances are never reduced by later receipts**; only the customer ledger moves. Keep when importing; the Hub ties payments to documents, so importing needs an allocation rule (oldest bill first is the usual one; owner to confirm).
4. **Credit rows post nothing to ledgers**; the customer balance is correct only because the full grand total is debited. Keep.
5. **Credit limit test uses the signed balance read before the bill**; a customer with an advance plus a credit sale larger than the advance is treated as owing only the difference. Correct in effect; keep.
6. **`BankAccountLedger` uses the payment-date box**, not each row's own date. fix? (minor).
7. **Cash drawer opens and SMS goes out inside the save chain**; failures there can stop later steps. fix: do such things after commit in the Hub.
8. **Stock is only a warning** (switch off: nothing at all). The Hub has a shop setting `AllowNegativeStock` (`ShopSettings.cs:23`) that is **on by default**, so by default the Hub also lets stock go negative; when the owner turns it off the Hub refuses the sale ("Only N of X left", `DocumentService.cs:494`). Add a "warn and ask" choice if the owner wants the old till's behaviour.
9. **Commission** ignores tax and bill discount and is not rounded. Keep for compatibility; decide for the Hub (salesperson module).
10. **StockMovement second-read** (2.3 step 6). Do not port; the Hub's `stock_moves` is one row per movement.



## 3. Returns and refunds (sales return, cash refund, "by return", previous sales) (DONE; hand-worked, not run)

### 3.1 Screens (screen to purpose)

- `frmSalesReturn`: pick the sold bill, pick lines and quantities to take back, choose Cash or Credit, save. List screens: `frmSalesReturnRecord`, `frmSalesReturnRecord_GSTR` (register). No edit: only delete and enter again (`DeleteRecord`, `frmSalesReturn.vb:2056`).
- **Cash Refund** (`Cashrefund.vb`): only a calculator: `Refund = Received cash - Billed cash` (`Cashrefund.vb:171`). It saves nothing.
- **By Return** (touch tills only, `frmPOSTouch.vb:32935` and `33037`): the cashier types a sales return number (more than 5 characters); the till refuses it if that number is already stored on any invoice (`InvoiceInfo.SRNumber`); otherwise `txtByReturn = SalesReturn.GrandTotal` of that return and a payment row "ByReturn" with that amount is added. The invoice stores `ByReturn` and `SRNumber`. `due = R2(grand - totalPaid - byReturn)` (`frmPOSTouch.vb:17305`); `totalPaid` does not include the ByReturn row.
- `frmPrevSales` (`frmPrevSales.vb:196`): list of previous bills for the financial year (from `Company.FYFrom` to `FYTo`): invoice no, date, customer name, `GrandTotal`, `TotalPaid`, `Balance`, newest first (`Inv_ID` descending). Read only.
- `frmMultiBillPayment` (touch till payment dialog, `frmMultiBillPayment.vb:164` to `219`): a grid with one row per enabled payment mode (table `tbl_BillPaymentMode`: `Mode_Index`, `paymentmode`, `amount`, `status` = 1, set in `frmMultiPaymentModeSettings`) plus two fixed rows "By Return" and "Change". The cashier types an amount against each mode in one go. `Paid = sum of the typed amounts (not By Return, not Change)`; `Change = Paid - NetAmount` (`CalculateByCashToChange`); typing more than `NetAmount` is refused ("Cannot enter greater than ..."); the same checks as in 2.1 apply (bank account, Adjust once, Adjust not above the balance, credit limit `Customer.Limit` with "Your Credit Limit is Cross"). It then hands each non-zero row to the touch till's payment box.
- **Sell by amount** (`frmSaleAmtCal.vb:TotQtyCal`, opened from the till): the cashier says "give me this much money's worth" and the till finds the quantity: Exclusive item: `qty = amount * 100 / (100 + taxPercent) / (price - discountAmount)`; Inclusive item: `qty = amount / (price - discountAmount)`. The quantity is **not rounded** and goes into the quantity box.
- `frmRefundAmt`: looks like a journal-voucher screen (reads `Journal`, bank accounts, `LedgerBook` cash balance), not a customer refund. Not studied (see Not understood).

### 3.2 Sales return: rules (exact)

Return a line (`Calc`, `frmSalesReturn.vb:2685`), using the **original sale's** rate, discount % and tax percents, and the quantity to take back `rq`:
1. `gross = R2(rq * rate)`; `disc = R2(gross * discPer / 100)` (always from the saved discount **percent**, even if the original discount was typed as an amount; `discPer` was saved to 4 decimals); `base = gross - disc`.
2. Exclusive, Exempt GST and No Taxes items: `cgst, sgst, igst, cess = R2(base * percent / 100)` each; `total = R2(base + all four)`. (No special handling of Exempt or No Taxes: the percents saved on the sale are used, they were already 0.)
3. Inclusive: `gst = R2(base - base / (1 + (cgstPer + sgstPer) / 100))`; **`CGST = gst / 2` and `SGST = gst / 2` (not rounded again; can be a half paisa such as 0.005)**; `igst`, `cess` as on a sale; `total = R2(base)`.
4. **Taxable amount of the returned line** (`frmSalesReturn.vb:1956`): `R2( originalLineTaxableAmt / originalQty * rq )`: proportional to the original line, not recomputed.
5. Bill: `GridCalc` sums CGST, SGST, IGST and CESS amounts and rounds each sum to 2 decimals; `SubTotal` = sum of the returned lines' taxable amounts (grid column 21); then as on a sale: `total = R2(SubTotal + taxes + freight - billDiscount)`, round-off if switched on (same `R0`, half to even), `grand = R2(total + roundOff)` (`Compute`, `frmSalesReturn.vb:2631`).
6. Limits when a line is added: return quantity must be more than zero, not more than the quantity sold (`txtQty`), not more than the remaining returnable quantity: `remaining = CInt(Round(soldQty - sum of ReturnQty of earlier returns of this invoice and this product))` (`frmSalesReturn.vb:2226`; **a whole number**, summed per product, not per barcode; if sold is not more than returned: "This product already returned"), free quantity returned not more than free quantity sold; **one return line per barcode** ("Same barcode already added in grid"). For serial-numbered items the number of chosen serial numbers must equal the return quantity ("Quantity mismatch!").
7. Payment mode of the return: only **Cash** or **Credit** (`cmbPmtMode`).

What save writes (`btnSave_Click`, `frmSalesReturn.vb:3088`):
- `SalesReturn` header (`SR_ID`, `SRNo`, `Date`, `SalesID` = the invoice's `Inv_ID`, `SubTotal`, `CGST`, `SGST`, `IGST`, `CESS`, `GrandTotal`, `FreightCharges`, `OtherCharges`, `Total`, `RoundOff`, `PaymentMode`, `BillSundry`, `TotalLoyalityPoints`) and `SalesReturn_Join` lines (`SalesReturnID`, `ProductID`, `Barcode`, `Qty` sold, `SalesRate`, `DiscPer`, `DiscAmt`, tax percents and amounts, `ReturnQty`, `TotalAmount`, `PurchaseRate`, `Margin`, `STaxType`, `TaxableAmt`, salesman columns, `LoyalityPoints`).
- Stock: `Temp_Stock.Qty = Qty + returnQty` for the same product and barcode, i.e. back into the **same lot** (`frmSalesReturn.vb:3231`); `StockMovement` row with StockIn = return qty (same two-read quirk as in 2.3 step 6).
- Ledgers: **Credit**: `CustomerLedgerBook` and `LedgerBook` "Sales Return" with **Credit = grand** (the customer is owed that much, or owes that much less). **Cash**: the same Credit row, plus a "Cash Return" **Debit = grand** in `CustomerLedgerBook` and a "Cash Account" "Sales Return" Debit = grand in `LedgerBook` (net effect on the customer: zero; cash goes out of the drawer).
- Loyalty points are taken back through `LedgerBook_Loyality` and `CustomerLedgerBook_Loyality` (points of the returned part: `lblLoyality / soldQty * returnQty`, formatted to 2 decimals).
- Salesman: for a returned line that has a salesman, a row in `LedgerBooksalesman1` with label "Sales Return" (`frmSalesReturn.vb:3217`; amount = grid column 25, `SalesManPur`, written in the Debit column; columns Date, Name, LedgerNo, Label, Debit, Credit, PartyID, PartyName as in `ModFunc.vb:816`).
- Number: `SRNo = Invcode.c2 + "-" + N + "-" + Invcode.c12`, defaults "SR" and the year suffix as in 2.7, with `N` = (highest `SrSaleReturn.ID`) + 1, 4 digits at least; `SR_ID` is its own counter. Row inserted into `SrSaleReturn(ID, InvNo)`.
- Serial numbers: `tbl_product_serial_saleReturn` row per serial and the serial's status in `tbl_product_serial_final` is set back to 'PURCHASE' (in stock) (`frmSalesReturn.vb:3356` to `3366`).
- Delete: `Temp_Stock.Qty = Qty - returnQty`, `StockMovement` rows deleted, ledgers deleted (note `CustomerLedgerDelete` removes **every** customer-ledger row with that number whatever its label), number row deleted, log line written.
- The original bill is **not changed** (its `TotalPaid` and `Balance` stay); a bill with a return cannot be edited or deleted (2.6).

### 3.3 Test vectors (hand-worked)

Base sale line L2 (qty 3 x 33.33, 10% percent discount, GST 9+9 exclusive; taxable 89.99, CGST 8.10, SGST 8.10, total 106.19).

| # | Case | Arithmetic | Result |
|---|---|---|---|
| R1 | Return 1 of 3 | gross R2(33.33)=33.33; disc R2(3.333)=3.33; base 30.00; cgst R2(2.70)=2.70; sgst 2.70; total R2(30.00+5.40)=35.40. Taxable R2(89.99/3x1)=R2(29.9967)=30.00 | taxable 30.00, CGST 2.70, SGST 2.70, grand 35.40 |
| R2 | Return 2 of 3 | gross R2(66.66)=66.66; disc R2(6.666)=6.67; base 59.99; cgst R2(5.3991)=5.40; sgst 5.40; taxable R2(89.99/3x2)=R2(59.9933)=59.99; total 59.99+5.40+5.40=70.79 | grand 70.79 |
| R3 | Return all 3 | gross 99.99; disc 10.00; base 89.99; cgst 8.10; taxable R2(89.99/3x3)=89.99; total 106.19 | grand 106.19 (equals the sale) |
| R4 | Inclusive line L5 (2 x 99.99, 5%), return 1 | gross 99.99; gst R2(99.99-99.99/1.05)=R2(4.7614)=4.76; CGST = 4.76/2 = 2.38 (kept as 2.38); SGST 2.38; total 99.99; taxable R2(190.46/2x1)=R2(95.23)=95.23; bill: 95.23 + 2.38 + 2.38 = 99.99 | grand 99.99 |
| R5 | Inclusive half paisa (L7: 0.21 at 5%, sale saved taxable 0.21, CGST 0, SGST 0), return 1 | gst R2(0.21-0.20)=0.01; CGST cell 0.005, SGST cell 0.005; `GridCalc` column sums R2(0.005)=0.00 (half to even) for CGST and 0.00 for SGST; line taxable = R2(0.21/1x1) = 0.21 (from the sale); SubTotal 0.21; total R2(0.21+0+0)=0.21 | CGST 0.00, SGST 0.00, grand 0.21 (same as the sale) |
| R6 | Cash return of R1 | grand 35.40. CustomerLedgerBook: "Sales Return" Cr 35.40, "Cash Return" Dr 35.40. LedgerBook: customer "Sales Return" Cr 35.40; "Cash Account" "Sales Return" Dr 35.40. Stock +1 on the same barcode | customer balance unchanged; cash out 35.40 |
| R7 | Credit return of R1 | CustomerLedgerBook "Sales Return" Cr 35.40, LedgerBook the same | customer balance +35.40 (owes 35.40 less, or has 35.40 advance) |
| R8 | Refused: too many | sold 3, return 4 | "Return Quantity can not be greater than purchased quantity" |
| R9 | Refused: already returned | return 2 saved; try 2 more of the 3 sold | remaining = CInt(Round(3 - 2)) = 1; asking for 2 is refused ("Return Quantity can not be greater than purchased quantity") |
| R10 | By Return on a new bill | new bill grand 236.00, return no. total 35.40, cash 200.60 | due = R2(236.00 - 200.60 - 35.40) = 0.00; invoice `ByReturn` 35.40, `TotalPaid` 200.60, `Balance` 0.00; the same return number cannot be used on another invoice |
| R11 | Sell by amount, Inclusive | amount 50.00, price 80.00 per kg, discount amount 0 | qty 50/80 = 0.625; gross R2(0.625 x 80) = 50.00 |
| R12 | Sell by amount, Exclusive 5% | amount 50.00, price 80.00 | qty 50 x 100 / 105 / 80 = 0.5952381; gross R2(47.619048) = 47.62; CGST R2(1.1905)=1.19; SGST 1.19; total R2(47.62+2.38) = 50.00 |
| R13 | Cash refund calculator | received 500.00, billed 463.50 | refund 36.50 |

### 3.4 Quirks and probable bugs (keep or fix?)

1. **Inclusive return halves the tax without rounding** (R4, R5): a line can carry 0.005. The sums are rounded, so the bill is right to the paisa. keep for matching old data; the Hub's exact split is better (fix in the new code).
2. **Return uses the saved discount percent** (4 decimals), not the original discount amount: a return of the whole quantity can differ by a paisa from the sale if the sale's discount was typed as an amount. keep; the Hub credit note copies the line exactly (better).
3. **The original bill's balance is not reduced** by a credit return; only the customer ledger moves. keep when importing (see 2.10 item 3).
4. **"By Return" and a Cash return can pay twice**: a return paid out in cash (R6) can still be typed into "By Return" on a new bill, as far as the code shows (it only checks that the number was not used before). fix? ask the owner (restrict By Return to Credit returns).
5. **`CustomerLedgerDelete` removes every row with the number, any label**; returns and invoices use different counters but can share the same text pattern only if the prefix is the same (default "SR" vs "GST", so normally not). keep; the Hub does not use text-keyed deletes.
6. **Return `Calc` is the same code as the sale's but written separately**: the two can drift (they already differ on the Inclusive halving). The Hub has one engine (good).



## 4. Estimates, quotations, service billing (DONE; hand-worked, not run)

### 4.1 Screens (screen to purpose)

- `frmEstimate` (title "ESTIMATE / DELIVERY NOTE"): a priced list for a customer that **adds no tax**. Lists: `frmEstimateRecord`; pick one to bill: `frmEstimateRetrieve`.
- `frmQuotation` ("QUOTATION"): a priced offer **with tax** like a bill. Lists: `frmQuotationRecord`; pick one to bill: `frmQuotationRetrieve`.
- `frmPOSNewTuch_Quotation` (touch till used as a quotation maker): the sale till's arithmetic (identical `Calc`), saved to `InvoiceInfo_Quotation` and `Invoiceinfo_Product_Quotation`; no stock movement (no stock update on save was found; one helper at `:28108` reduces stock for a barcode, its use was not traced); list screen `frmPOSNewTuch_QuotationRecord`.
- `frmServices` (a repair or service job), `frmServiceBilling` (the bill for a job), `frmServiceBillingRecord`, `frmServiceDoneReport`, and the touch till `frmPOSNewTuch_Service` (a sale-style bill saved to `InvoiceInfo_Service` and `Invoice_Product_Service`).

### 4.2 Estimate: exact rules (`frmEstimate.vb`)

- **Line** (`Calc`, `frmEstimate.vb:3766`): `gross = R2(qty * price)`, `disc` percent or amount (R2 and R4 as on a sale), `base = gross - disc`. Tax amounts are worked out and **shown** (Exclusive: `R2(base * % / 100)`; Inclusive: carved out as on a sale, `R2(gst / 2)` each) but **the line total is `base`** in both Exclusive and Inclusive (`frmEstimate_Calc` line `num6 = num8`; extracted text lines 34 and 70). Exempt GST and NON GST add the four amounts, which are 0.
- **Bill** (`SubTotal`, `frmEstimate.vb:2976`; `Compute`): `SubTotal = sum over lines of (qty * price - discountAmount)` with `qty * price` **not rounded** per line; `total = R2(SubTotal)`; round-off box as on a sale (`R0` half to even); `grand = R2(total + roundOff)`. **No tax, no freight, no bill discount.**
- **Save** (`frmEstimate.vb:6766` to `6891`): needs customer details and at least one line (and the company profile). Writes `Estimate(Q_ID, QuotationNo, Date, TaxType, CustomerID, SubTotal, CGST, SGST, IGST, CESS, Total, RoundOff, GrandTotal, Remarks, CType, KP)` with **`TaxType` always "NON GST"**, `CType` Retail or Wholesale (from the till's price-tier choice), **`KP` always "P"**, and `Estimate_Join(QuotationID, ProductID, Barcode, Qty, Price, DiscountPer, DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, TotalAmount, AltQty, AltUnit, STaxType)`. Header tax columns hold the sums of the shown (not added) tax. **No stock, no ledger, no payment.** Counter row `SrEstimate`.
- **Number**: `Invcode.c20` prefix (default "ESTM") + "-" + N + "-" + `Invcode.c21` suffix (default year suffix, 2.7); N from `SrEstimate`.
- Trial rule: more than 5 estimates in a month refused (a licence rule; do not port).
- Delete removes `Estimate`, `Estimate_Join` and the counter row (`frmEstimate.vb:3954` to `3969`).

### 4.3 Quotation: exact rules (`frmQuotation.vb`)

- **Line** (`Calc`, `frmQuotation.vb:2830`; compared with the sale's `Calc` by extracting both): the same arithmetic per tax type as the sale (section 1.3): Exclusive adds the tax; Inclusive carves it out; Exempt GST forces CGST, SGST, IGST % to 0 and, as on a sale, **leaves CESS % in force**; No Taxes forces all four to 0. Differences from the sale: a blank item tax type is **not** treated as Exclusive, and there is no "NON GST" branch (a quotation always follows the item's tax type).
- **Bill** (`Compute`, 18 lines): `total = R2( SubTotal + sumCGST + sumSGST + sumIGST + sumCESS )` where `SubTotal` = sum of column 20 (**taxable amount**); round-off as on a sale; `grand = R2(total + roundOff)`. **No freight and no bill discount** (unlike a sale).
- **Save** (`frmQuotation.vb:5029` to `5103`): `Quotation(Q_ID, QuotationNo, Date, TaxType, CustomerID, SubTotal, CGST, SGST, IGST, CESS, Total, RoundOff, GrandTotal, Remarks, CType)` and `Quotation_Join` lines (as the estimate's plus `TaxableAmt`, `MainUnit`). No stock, ledger or payment. Counter `SrQuotation`. Number: `Invcode.c4` prefix (default "Q") + "-" + N + "-" + `Invcode.c14` suffix.

### 4.4 Convert an estimate or a quotation into a bill (exact)

1. In `frmEstimateRetrieve` or `frmQuotationRetrieve` the cashier opens a document by its number and **double-clicks one line**; the till (classic or touch) receives:
   - the customer name (`cmbCustomerName`);
   - the price tier (Retail or Wholesale, from `Estimate.CType`);
   - the narration **"Ref : <estimate or quotation number>"** (`txtNar`);
   - the line's barcode, then the till runs its normal barcode entry for that line (`BarcodeProgram1` for estimates, `BarcodeProgram2` for quotations; `frmPOS.vb:12928`, `13254`) which **takes from the document line: sale rate, discount %, quantity, unit, and the tax percents** (CGST % and SGST % are taken from the SGST and CGST columns respectively, which is harmless when they are equal; IGST % when the customer's state differs from the company's, `frmPOS.vb:13043` to `13066`), and **takes from stock and the product**: the item's tax type (`Product.STax`), the lot's MRP, batch, dates, size, colour, IMEI, purchase rate (`EPPrice`) and alt-unit data.
   - The line is removed from the retrieve list on the screen.
2. The till then works the line with the **sale's rules** (1.3). So **an estimate for an Exclusive item (which added no tax) becomes a bill with tax added on top** (vector E5).
3. **The estimate or quotation is not marked as billed** (no update of it was found); it stays in the list and can be billed again. One line is pulled per double-click (the cashier repeats for each line).

### 4.5 Service job and service bill (`frmServices`, `frmServiceBilling`)

- **Job** (`frmServices.vb:1567`): `Service(S_ID, ServiceCode, CustomerID, ServiceType, ServiceCreationDate, ItemDescription, ProblemDescription, ChargesQuote, AdvanceDeposit, EstimatedRepairDate, Remarks, Status)`; Status is one of "Resolved", "Under Processing", "Unresolved"; counter `SrService`. If an upfront (advance) is taken, the job posts: `LedgerBook` and `CustomerLedgerBook` "Service Upfront" **Debit = upfront** for the customer and "Cash Account" "Receipt" **Credit = upfront** (`frmServices.vb` save). Optional SMS.
- **Bill** (`Compute1`, `frmServiceBilling.vb:877`):
  - `serviceTax = R2( repairCharges * taxPercent / 100 )` (one percent, **no CGST/SGST split**);
  - `grand = R2( repairCharges + serviceTax - upfront )` (**the grand total is what is left to pay after the upfront**);
  - `due = R2( grand - totalPayment )`.
  - Checks: job chosen, charges entered, tax % entered, `totalPayment` not more than `grand`.
  - Saves `InvoiceInfo1(Inv_ID, InvoiceNo, InvoiceDate, ServiceID, RepairCharges, Upfront, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, Remarks)` and counter `SrSerBill`; ledgers: `LedgerBook` and `CustomerLedgerBook` "Services" **Debit = grand** and "Cash Account" "Receipt" **Credit = total payment** (`frmServiceBilling.vb:1351` to `1374`). **No stock, no parts**: parts are sold on a normal bill.
- **Touch service till** (`frmPOSNewTuch_Service`): the sale's `Calc` and totals (identical code); saved to `InvoiceInfo_Service` and `Invoice_Product_Service`; reduces stock (`:24638`) and writes a `StockMovement` row like a sale.

### 4.6 Test vectors (hand-worked)

| # | Case | Arithmetic | Result |
|---|---|---|---|
| E1 | Estimate, Exclusive line, discount | qty 2, price 100.00, disc 10%, 9+9 | gross R2(200.00)=200.00; disc R2(20.00)=20.00; base 180.00; shown CGST R2(16.20)=16.20, SGST 16.20 (not added); line total 180.00; SubTotal = 2x100.00 - 20.00 = 180.00 |
| E2 | Estimate, Inclusive line | qty 1, price 118.00, 9+9 | base 118.00; shown CGST 9.00, SGST 9.00; line total 118.00; SubTotal 118.00 |
| E3 | Estimate bill, two lines, round-off OFF | E1 + E2 | SubTotal 180.00 + 118.00 = 298.00; total 298.00; grand 298.00 |
| E4 | Estimate round-off ON, ties | total 180.40 -> R0 180, -0.40, grand 180.00; total 180.50 -> R0 180 (even), -0.50, grand 180.00; total 181.50 -> R0 182, +0.50, grand 182.00 | as listed |
| E5 | Convert E1's line to a bill (item is Exclusive, 18%, retail price unchanged) | till gets price 100.00, qty 2, disc % 10.0000, 9+9: gross 200.00; disc 20.00; base 180.00; cgst R2(16.20)=16.20; sgst 16.20; total R2(180.00+32.40)=212.40 | bill total **212.40** against the estimate's 180.00 (the tax is added) |
| E6 | Convert E2's line (item Inclusive, 18%) | gst R2(118-118/1.18)=18.00; total 118.00 | bill 118.00 = estimate 118.00 |
| E7 | Convert, item now costs more | stock lot `SPrice` changed since | the bill uses the **estimate's** price (copied), not the new lot price |
| Q1 | Quotation, same lines as B1 | taxable 100.00 + 89.99 = 189.99; CGST 9.00 + 8.10 = 17.10; SGST 17.10; total R2(189.99+17.10+17.10) = 224.19 | grand 224.19 (round-off OFF); with ON: 224.00 |
| Q2 | Quotation has no freight or discount | any | total is only taxable + taxes |
| SV1 | Service bill with upfront | charges 1000.00, tax 18%, upfront 300.00 | tax R2(180.00)=180.00; grand R2(1000.00+180.00-300.00)=880.00; pay 880.00: due 0.00. Pay 500.00: due R2(880.00-500.00)=380.00 |
| SV2 | Service tax rounding | charges 99.99, 18%, upfront 0 | tax R2(17.9982)=18.00; grand 117.99 |
| SV3 | Service tax tie | charges 12.50, 1% | tax R2(0.125) = 0.12 (half to even; 0.125 is exact in binary); grand 12.62 |
| SV4 | Service payment too high | grand 880.00, payment 880.01 | refused "Total payment can not be more than grand total" |
| SV5 | Service ledger, whole story | upfront 300.00 at job; bill charges 1000.00, tax 18%, pay 880.00 | job: customer Dr 300.00 ("Service Upfront"), Cr 300.00 (Receipt); bill: Dr 880.00 ("Services"), Cr 880.00 (Receipt); customer balance 0.00; revenue (repair + tax) = 1180.00 |

### 4.7 Quirks and probable bugs (keep or fix?)

1. **An estimate for a taxable item is cheaper than the bill made from it** (E5). The estimate screen is titled "Delivery Note"; users may quote the estimate price. fix? ask the owner whether an estimate should show tax or the conversion should carry the estimate's total.
2. **Estimate `TaxType` is always "NON GST"** whatever the shop's mode. keep (it marks "not a tax document").
3. **Estimates and quotations are never marked as billed**; no link from the bill to the estimate except the text "Ref : <number>" in the narration (E7). fix: the Hub should link `ref_document_id`.
4. **Conversion works one line at a time** and re-reads current stock data. keep the idea of "copy price, quantity, discount", fix the one-by-one click (copy all lines).
5. **The service bill's `GrandTotal` is net of the upfront** (SV1): a report that sums `GrandTotal` under-counts service sales by the upfronts, and the full value is `RepairCharges + ServiceTax`. keep when importing; the Hub keeps the full total and the advance apart.
6. **Service tax is one percent**, never split into CGST and SGST. keep for old data; the Hub engine splits.
7. **The touch quotation screen is a copy of the sale till**, so it carries all the sale code (hold, payments, loyalty) although it saves only a quotation. Do not port the copy; port the quotation.



## 5. Buying: purchase entry, orders, purchase return, MRP update, supplier payments (DONE; hand-worked, not run)

All line numbers are in `frmPurchaseEntry.vb` unless another file is named. A purchase is the only way (besides stock entry, opening stock and inward) that new lots come into `Temp_Stock`.

### 5.1 Screens (screen to purpose)

- `frmPurchaseEntry`: the purchase bill from a supplier. Pick supplier, pick products, set quantity, MRP, purchase price, discount, selling prices, batch and dates, then save. Has Hold and Unhold (`Stock_Hold`, `Stock_Product_Hold`; `btnHold_Click`, `13663`), print, export, record list (`frmPurchaseRecord`, `frmPurchaseRecord_GSTR` register).
- `frmPurchaseOrder` and `frmPurchaseOrderRecord` / `frmPurcOrderRetrieve`: an order to the supplier. No stock, no money.
- `frmPurchaseReturn` and `frmPurchaseReturnRecord` (register `_GSTR`): goods sent back.
- `frmPayment`, `frmPaymentRecord`: pay the supplier (on account).
- `frmSupplierLedger`, `frmSupplierOutstanding`, `frmSupplierwise_report`: balances and statements (read the ledger).
- `frmMRP_Purchase_Update` (columns MRP, retail rate, wholesale rate, purchase rate, purchase rate + GST, barcode, colour, size; "Customer Type" label): a lot picker over earlier purchase lots. How it is used was not studied (see Not understood).

### 5.2 A purchase line: exact arithmetic (`Calc`, `frmPurchaseEntry.vb:7411`)

The line rules are **the same as the sale's** (section 1.3), with these names: quantity `qty` (`TextBox2`, in the main unit; alt unit conversion as in the sale), price `price` (`txtPricePerQty`, per main unit, **before discount and before tax unless the item's purchase tax type is Inclusive**), discount type percent or amount (R2 and R4 as on a sale), purchase tax type from `Product.PTax` ("Exclusive", "Inclusive", "Exempt GST", "No Taxes"; blank counts as Exclusive), bill purchase tax mode `Setting.PurchaseTax` ("GST" or "NON GST"; separate from the sales setting).
- Exclusive: `gross = R2(qty * price)`; `disc`; `base = gross - disc`; `cgst`, `sgst`, `igst`, `cess` = `R2(base * % / 100)`; `total = R2(base + taxes)`.
- Inclusive: `gst = R2(base - base / (1 + (cgst% + sgst%) / 100))`; `CGST = R2(gst / 2)`, `SGST = R2(gst / 2)`; `igst`, `cess` carved the same way; `total = R2(base)`.
- Exempt GST: CGST, SGST, IGST % forced 0; **CESS % not reset**, still charged (same quirk as the sale). No Taxes and NON GST: all four % forced 0.
- `taxableAmt = R2(qty * price - disc)`; if Inclusive: `R2(qty * price - disc - (cgst + sgst + igst + cess))`.
- Tax split by supplier state against company state (`frmPurchaseEntry.vb:8443` and `8449`): **same state** = CGST and SGST from the product, IGST 0; **any other state, including a blank supplier state**, = CGST 0, SGST 0, IGST = product CGST + SGST. (On a sale a blank customer state counts as the same state; on a purchase it does not.)
- A new line must have: product, barcode (a lot id), quantity not zero, price, **retail sale price and wholesale sale price** (both are required: "Please enter Retail Sale Price"). If the purchase price is **more than the MRP** the program asks "You have entered the MRP less than Sales Price, do you want to proceed?" (a Yes/No question, not a block). The same product with the same barcode cannot be added twice in one bill ("Same Product already added to grid").
- On adding a line the product master is **overwritten** (`autoupdatepurchaseprice`, `autoupdateMRP`, `autoupdateretailsaleprice`, `autoupdatewholesalesaleprice`, `6194` to `6337`), each only when the value differs: `Product.CostPrice` = line `price`; `Product.MRP` = line MRP; `Product.SellingPrice` = retail sale price; **`Product.ReorderPoint` = wholesale sale price** (the old program stores the default wholesale price in the column called `ReorderPoint`; `Product.MinStock` is the real minimum stock). The till's price-memory option in 1.3 uses the same columns.
- What picking a product fills in (`frmPurchaseEntry.vb:8402`): barcode = `Product.Barcode` (so the first lot of a product uses the product's own barcode), price = `Product.CostPrice`, MRP = `Product.MRP`, discount 0, tax percents from the product, unit = `Product.PurchaseUnit`, purchase tax type = `Product.PTax`.

Grid columns kept per line (`frmPurchaseEntry.vb:6486`): 0 product id, 1 HSN, 2 name, 3 barcode, 4 qty (main unit), 5 MRP, 6 price per main unit, 7 discount %, 8 discount amount, 9 CGST %, 10 CGST amt, 11 SGST %, 12 SGST amt, 13 IGST %, 14 IGST amt, 15 CESS %, 16 CESS amt, 17 line total, 18 entered qty, 19 taxable amount, 20 alt qty, 21 alt unit, 22 tax type, 23 retail price, 24 wholesale price, 25 colour, 26 size, 27 info, 28 batch, 29 mfg date, 30 exp date, 31 retail price cipher code, 32 wholesale price cipher code, 33 category, 34 main unit, 35 IMEI 1, 36 IMEI 2.

### 5.3 Purchase bill totals: exact order (`Compute`, `6701`; `GridCalc`, `6753`; `SubTotal`, `6509`)

1. `GridCalc`: `sumCGST`, `sumSGST`, `sumIGST`, `sumCESS` = `R2` of column sums 10, 12, 14, 16.
2. `SubTotal` = sum of column 19 (**taxable amount**; unlike the sale it does not include tax), shown as the sub total and saved as `Stock.SubTotal` and `Stock.TaxableAmt`.
3. Reverse charge (`cmbReverse`) = "No" (normal): `total = R2( SubTotal + freight - billDiscount + previousDue + sumCGST + sumSGST + sumIGST + sumCESS )`. **"Yes"** (the buyer pays the tax to the government): `total = R2( SubTotal + freight - billDiscount + previousDue )` (taxes left out). `billDiscount` is the box `txtOtherCharges` (the screen says "Bill Discount"; the database column is `OtherCharges`). `previousDue` = the supplier's balance read before this bill (see 5.5): **the old balance is added into this bill's total.**
4. `roundOff = R2(R0(total) - total)` if the round-off box is checked (half to even), else 0; `grand = R2(total + roundOff)`.
5. `balance = R2(grand - totalPaid)` (`txtBalance`, saved as `Stock.PaymentDue`).
6. `txtCurAmt` (shown "this purchase" amount) = `R2( SubTotal + freight - billDiscount + taxes )`, without previous due and without round-off.

### 5.4 Save checks and writes (`btnSave_Click`, `11274`)

Purchase type box: Cash, Credit or Bank (`cmbPurchaseType`; `Stock.PurchaseType` keeps the word).
Checks in order: company profile exists; supplier picked and a real supplier; at least one line; bill sundry, freight, bill discount and round-off boxes not empty; **Cash**: total paid not empty, more than zero, not more than `grand`; **Bank**: a bank account chosen, total paid more than zero and not more than `grand`; **Credit**: total paid is forced to 0 and not editable (`cmbPurchaseType_SelectedIndexChanged`, `8037`); supplier credit: **if `balance > Supplier.Limit` and `Supplier.Lstatus` = "Yes": "Supplier Credit limit is exceeded"** (`balance` includes the previous due).
Writes, in order (no transaction):
1. `Stock` header: `ST_ID`, `InvoiceNo`, `Date`, `PurchaseType`, `SupplierID`, `SubTotal`, `PreviousDue`, `FreightCharges`, `OtherCharges` (= bill discount), `Total`, `RoundOff`, `GrandTotal`, `TotalPayment` (= paid), `PaymentDue` (= balance), `Remarks`, `ReferenceNo1` (own reference), `ReferenceNo2` (= the reverse-charge "Yes"/"No"), `TaxType` ("GST"/"NON GST"), `SupplierInvoiceNo`, `SupplierInvoiceDate`, `CGST`, `SGST`, `IGST`, `CESS`, `BillSundry`, `TaxableAmt`, `BankAccount`, `Doc` (a scanned bill image).
2. `Stock_Product` rows (one per grid line; columns as in `PosSchemaData.cs`: `Qty`, `MRP`, `Price`, discount, tax %s and amounts, `TotalAmount`, `TaxableAmt`, `AltQty`, `AltUnit`, `PTaxType`, `RPrice`, `WPrice`, `Color`, `Size`, `Info`, `Batch`, `Mfgdate`, `Expdate`, `RCipher`, `WCipher`, `Category`, `MainUnit`, `IMEI1`, `IMEI2`).
3. Number counter row `PurcGST(ID, InvNo)` or `PurcNoTax(ID, InvNo)`.
4. **Stock lots** (`11541` to `11660`): for each line look up `Temp_Stock` by (product, barcode):
   - found: `Qty = Qty + line qty` and the lot's attributes are **overwritten by this line** (`StLimit` set to 0, `MRP`, `Batch`, `Mfgdate`, `Expdate`, `Size`, `Colour`, `SPrice` = retail price, `WPrice` = wholesale price, `SalePrice`/`WSalePrice` = the price cipher codes, `SuplName` = supplier name, `IMEI1`, `IMEI2`, `PPrice` = price per main unit, `EPPrice` = see below). This means **units already in stock under that barcode take the new MRP and prices** too.
   - not found: a new `Temp_Stock` row with the same values.
   - **`EPPrice` (effective cost per unit) = `line taxable amount / line qty`** (`Cells(19) / Cells(4)`), i.e. price after line discount, without tax, per main unit. It is stored in a `decimal(18,2)` column, so SQL Server rounds it to 2 decimals on the way in. The sale uses `EPPrice` as the purchase rate for margin (1.3).
   - `Product_OpeningStock` (the lot's master record: MRP, batch, dates, size, colour, prices, ciphers, `PPrice`, `OPSValue` = 0.00, `PAddDate` = today, IMEI) is inserted with `Qty` 0 for a new lot, or updated when the lot exists.
5. `StockMovement` for each line (same two-read quirk as in 2.3 step 6; StockIn = line qty).
6. Ledgers: `SupplierLedgerBook` and `LedgerBook`: **"Purchase" row with Credit = `grand - previousDue`** (what this bill adds to what we owe; the previous due is already in the ledger). Cash: plus a "Payment" row to "Cash Account" with **Debit = total paid** in both books. Bank: plus "Payment" to "Bank Account" and `BankAccountLedger` ("Purchase-Bank", the account number, **Debit = total paid**, Credit 0). Credit: only the Purchase row.
7. Serial numbers (`InsertSerial_final`, `11762`) for items sold by serial number (see section 6).
8. Log line "added the New Purchase having Invoice No. ...".

**Number**: prefix `Invcode.c1` (default "PGST") + "-" + N + "-" + suffix `Invcode.c11` (default year suffix as in 2.7); N = highest `PurcGST.ID` + 1 (4 digits at least). Purchases on a NON GST shop: `"PINV-" + N + "-" + suffix` from `PurcNoTax`. `Stock.ST_ID` is its own counter.

**Edit** (`btnUpdate_Click`, `11809`): refused if a purchase return exists ("Unable to update..Already in use in Purchase Return"); same checks; `Stock` updated in place; `Stock_Product` deleted and rewritten; `Temp_Stock.Qty` reduced by the old quantities (`12022`) then increased by the new ones (`12055`, with the same overwrite of lot attributes); `StockMovement.StockIn` updated; ledger rows for "Payment" and "Purchase" (and every supplier-ledger row with that number) deleted and written again.
**Delete** (`DeleteRecord`, `7869`): refused if a purchase return exists; `Stock` and `Stock_Product` rows deleted; `Temp_Stock.Qty` reduced by each line's quantity (the lot row stays even at 0); `StockMovement` rows, counter row, ledger rows ("Payment", "Purchase", all supplier-ledger rows with the number, "Purchase-Bank") deleted; log line written. **Nothing stops a purchase from being deleted after its goods were sold**: stock can go negative.

### 5.5 Supplier balance and payments

- Supplier balance (`GetSupplierBalance`, `7768`) = `sum(Credit) - sum(Debit)` over `SupplierLedgerBook` for the supplier (`PartyID`). **Positive = we owe the supplier.** On a new purchase it becomes `previousDue` (added into the total, see 5.3).
- Supplier payment (`frmPayment.vb:1581` to `1637`): modes "By Cash", "By Cheque", "By Online Transfer", "PhonePe", "Google Pay", "Paytm", "E-Wallet" (a bank account is chosen for all but cash); amount must be more than zero and **not more than the supplier balance** ("Transaction amount can not be more than balance"). Writes `Payment(T_ID, TransactionID, Date, PaymentMode, SupplierID, Amount, Remarks, PaymentModeDetails, BankAcN)`, `LedgerBook` and `SupplierLedgerBook` row ("Cash Account" or "Bank Account", label "Payment", **Debit = amount**), and for bank modes `BankAccountLedger` ("Payment-By Cheque", "Payment-By Online Transfer", "Payment-PhonePe", "Payment-Google Pay", "Payment-Paytm", "Payment-E Wallet", Debit = amount). Counter row in `SrPayment`. Like customer receipts (2.8), **a payment is on account and is not tied to a purchase bill**; `Stock.TotalPayment` and `PaymentDue` are not updated by it.

### 5.6 Purchase order (`frmPurchaseOrder.vb:4248` to `4394`)

- Saves `PurchaseOrder(PO_ID, PONo, Date, SupplierID, TaxType, SubTotal, SGST, CGST, IGST, CESS, GrandTotal, TermsAndConditions, Terms)` and `PurchaseOrder_Join` lines (`ProductID`, `Qty`, `Price`, discount, tax, `TotalAmount`, `PTaxType`, `TaxableAmt`, `RCipher`, `WCipher`, `Barcode`), counter `SrPurOrder`. The order number must be new ("Purchase Order No. Already Exists").
- `GrandTotal = R2(SubTotal + CGST + SGST + IGST + CESS)` (`frmPurchaseOrder.vb` `Compute`): **no freight, no discount, no round-off**.
- No stock movement, no ledger, no payment. A product that is on an order cannot be deleted from the product list ("Unable to delete..Already in use in Purchase Order").
- **Order to purchase:** `frmPurcOrderRetrieve` loads an order's lines into the purchase entry grid (`frmPurcOrderRetrieve.vb:312`: product, barcode, qty, price, discount, taxes, total). I found no code that marks the order as received or links the purchase to it; the order stays as it was.

### 5.7 Purchase return (`frmPurchaseReturn`)

- Line: `Calc` is the sale-return pattern (3.2): `gross = R2(returnQty * price)`, `disc = R2(gross * discPer / 100)` using the original percent, taxes as on the purchase; **Inclusive halves the tax without rounding again** (`frmPurchaseReturn.vb` `Calc`). Taxable per returned line is proportional to the original, as in 3.2.
- Bill: `total = R2(SubTotal + taxes + freight - billDiscount)` if reverse charge is "No", without taxes if "Yes" (`Compute`), no previous due; round-off as on a sale; `grand`.
- Mode: **Cash** or **Credit** (`cmbPmtMode`).
- Writes `PurchaseReturn(PR_ID, PRNo, Date, PurchaseID, SubTotal, CGST, SGST, IGST, CESS, Total, RoundOff, GrandTotal, FreightCharges, OtherCharges, RCM, PaymentMode, BillSundry)` and `PurchaseReturn_Join` lines; **`Temp_Stock.Qty = Qty - returnQty`** for the same lot (`frmPurchaseReturn.vb:3348`); `StockMovement` with StockOut; ledgers: `LedgerBook` "Purchase Return" **Debit = grand** (and for Cash: "Cash Account" "Purchase Return" Credit = grand); `SupplierLedgerBook` "Purchase Return" Debit = grand (and for Cash: "Cash Return" Credit = grand, so the supplier balance does not change); counter `SrPurReturn`.
- Returns are refused for a purchase that is later edited or deleted (5.4).

### 5.8 Test vectors (hand-worked)

| # | Case | Arithmetic | Result |
|---|---|---|---|
| U1 | Exclusive line | qty 10, price 50.00, GST 9+9, retail 80.00, wholesale 70.00, MRP 100.00 | gross 500.00; cgst R2(45.00)=45.00; sgst 45.00; total 590.00; taxable 500.00; EPPrice 500.00/10 = 50.00 |
| U2 | With percent discount | qty 12, price 33.33, disc 5%, 9+9 | gross R2(399.96)=399.96; disc R2(19.998)=20.00; base 379.96; cgst R2(34.1964)=34.20; sgst 34.20; total R2(379.96+68.40)=448.36; taxable R2(399.96-20.00)=379.96; EPPrice = 379.96/12 = 31.6633... stored 31.66 |
| U3 | Inclusive line | qty 4, price 59.00 (tax included), 9+9 | gross 236.00; gst R2(236-236/1.18)=R2(36.00)=36.00; CGST R2(18.00)=18.00; SGST 18.00; total 236.00; taxable R2(236.00-36.00)=200.00; EPPrice 200.00/4 = 50.00 |
| U4 | Bill with previous due, round-off ON | lines U1 + U2; freight 25.00; bill discount 10.00; previous due 1000.00 | SubTotal 500.00+379.96=879.96; sumCGST 45.00+34.20=79.20; sumSGST 79.20; total R2(879.96+25.00-10.00+1000.00+79.20+79.20)=2053.36; R0=2053; roundOff -0.36; grand 2053.00 |
| U5 | Paid cash 1053.00 on U4 | balance R2(2053.00-1053.00)=1000.00. Ledger: Purchase Cr R2(2053.00-1000.00)=1053.00; Payment (Cash Account) Dr 1053.00. Supplier balance after = 1000.00 (before) + 1053.00 - 1053.00 = 1000.00 | PaymentDue 1000.00 |
| U6 | Same bill, reverse charge "Yes" | total R2(879.96+25.00-10.00+1000.00)=1894.96; round-off ON: R0=1895; roundOff +0.04; grand 1895.00 | grand 1895.00 |
| U7 | Credit purchase | type Credit: paid 0.00; grand 1053.00 (no previous due): balance 1053.00; ledger: Purchase Cr 1053.00 only | PaymentDue 1053.00 |
| U8 | Credit limit | balance (incl. previous due) 1000.00, supplier limit 800.00 enforced ("Yes") | refused "Supplier Credit limit is exceeded"; limit not enforced: allowed |
| U9 | Paid too much | Cash type, paid 2054.00 on grand 2053.00 | refused "Total paid can not be more than grand total" |
| U10 | Lot merge | `Temp_Stock` (product 5, barcode 1004) qty 7, MRP 100; purchase line same barcode, qty 3, MRP 120 | qty 10, MRP 120 for all 10 units |
| U11 | New lot | purchase line with a new barcode 1005, qty 3 | new `Temp_Stock` row qty 3; `Product_OpeningStock` row (Qty 0) |
| U12 | Product master overwrite | line price 31.66, MRP 100, retail 80, wholesale 70, master had 30.00, 100.00, 75.00, 65.00 | CostPrice 31.66, MRP unchanged (equal), SellingPrice 80.00, ReorderPoint(wholesale) 70.00 |
| U13 | Purchase return, credit | return 1 of U2's 12 units (price 33.33, disc 5%, 9+9, exclusive): gross R2(33.33)=33.33; disc R2(1.6665)=1.67; base 31.66; cgst R2(2.8494)=2.85; sgst 2.85; total R2(31.66+5.70)=37.36; returned taxable R2(379.96/12x1)=R2(31.6633)=31.66; bill total R2(31.66+2.85+2.85)=37.36 | grand 37.36; ledger: Purchase Return Dr 37.36 (we owe 37.36 less) |
| U14 | Cash purchase return | grand G | `SupplierLedgerBook`: "Purchase Return" Dr G, "Cash Return" Cr G (net 0); `LedgerBook`: Purchase Return Dr G, Cash Account Cr G |
| U15 | Supplier payment | balance 1000.00, pay 400.00 by cheque | allowed (400 <= 1000); `SupplierLedgerBook` Payment Dr 400.00; balance 600.00. Pay 1000.01: refused |
| U16 | Purchase order total | lines taxable 500.00 and 379.96, taxes 79.20 + 79.20 + 0 | GrandTotal R2(879.96+79.20+79.20)=1038.36 (no freight, no discount, no round-off) |
| U17 | Purchase tax mode | `Setting.PurchaseTax` = "NON GST" | all % forced 0; number `PINV-0001-<suffix>` |

### 5.9 Quirks and probable bugs (keep or fix?)

1. **Receiving into an existing barcode overwrites the lot's MRP and prices for the old units** (U10). Probably intended for "same lot, same price" but wrong when the price changed. fix: in the Hub, a new price should make a new lot (or move to an average cost); decide with the owner. Old data: keep as stored.
2. **`Product.ReorderPoint` holds the wholesale price** (and `MinStock` the minimum). keep when importing (map `ReorderPoint` to the wholesale price, never to a reorder level).
3. **Previous due is added into the bill total and into the credit-limit test** (U4, U8). This makes "grand total" mean "total to settle", not "value of this purchase". Keep for reading old data; the Hub keeps the value of the purchase and the supplier balance apart (fix, clearer).
4. **Payments to suppliers are on account**, not tied to bills (5.5). Same as 2.10 item 3.
5. **No check when deleting a purchase whose goods were already sold** (5.4). fix.
6. **Exempt GST items still pay CESS** (same as the sale, 1.8 item 4). fix.
7. **`EPPrice` rounded by SQL Server to 2 decimals** (U2: 31.6633 becomes 31.66), so cost per unit times quantity does not equal the line's taxable amount. keep; the Hub should keep cost per unit with more decimals or keep the line taxable amount.
8. **Order retrieval does not close the order** (5.6). fix? ask the owner (an order status "received" is the usual idea).
9. **Both selling prices are mandatory on every purchase line.** Annoying for a purchase of goods that are not for sale. fix?
10. **"MRP less than sales price" message is the wrong way round**: it triggers when purchase price is **more than MRP** (`frmPurchaseEntry.vb:6456`). keep the check, fix the words.



## 6. Stock: entry, adjustment, transfer, godown, damage, settlement, movement, opening, serial numbers, variants, negative stock (DONE; hand-worked, not run)

### 6.1 The model: what "stock" is in the old POS

- **`Temp_Stock` is the live stock: one row per lot** (a lot = a product plus a barcode). Columns that matter (`PosSchemaData.cs`): `ProductID`, `Barcode`, **`Qty`** (on hand; decimal with 3 places), `Damage` (damaged units that are still counted inside `Qty`), `StLimit` (the lot's minimum-stock mark), `MRP`, `SPrice` (retail price), `WPrice` (wholesale price), `PPrice` (purchase price per main unit), **`EPPrice`** (effective cost per unit = purchase line taxable amount / qty, 5.4), `SalePrice`/`WSalePrice` (price cipher codes, text), `Batch`, `Mfgdate`, `Expdate`, `Size`, `Colour`, `IMEI1`, `IMEI2`, `SuplName` (the supplier, or "Opening Stock"), `Variant_id`, `QrBarcode` (an image), `SalesManPur`, `Serial_no`.
- **A product's stock** = the sum of `Qty` over its lots (`frmStockAdjustment_Store.vb:1036` sums for one product and barcode). **Good stock = `Qty - Damage`** (`frmCurrentStock.vb:578`). **A sale does not look at `Damage`**: it only reduces `Qty` (and warns against `Qty`, `StLimit`).
- **`Product_OpeningStock`** is the lot's master record (MRP, prices, ciphers, batch, dates, size, colour, IMEI, `PPrice`, `OPSValue`, `PAddDate`), written when a lot is first made (by a purchase, a product with opening stock, or the Excel opening-stock import).
- **`StockMovement`** (`ProductID`, `OpeningStock`, `StockIn`, `StockOut`, `Date`, `TransID`) is an in/out history per product for the movement report. `OpeningStock` on a row is `sum(StockIn - StockOut)` of the product's rows with an **earlier date** (0 for the first row). Written (checked by searching each form for `ProductSMSave`) by: sale (`frmPOS`, touch tills), sale return, purchase, purchase return, stock entry, adjustment, opening stock (product screen and Excel import), godown outward and inward, the touch service bill, and settlement when it creates a new product. **Not written by**: damage, the transfer token, the touch branch stock-transfer and stock-inward screens, the touch quotation. So after a transfer the movement report no longer agrees with `Temp_Stock`. The "first row" and "second read" behaviour is in 2.3 step 6.
- Documents of stock work: `Stock_Store` and `Stock_Store_Join` (stock entry), `StockAdjustment_Store` (adjustments), `P_Transfer`, `p_transfer_in` (transfer tokens), `InvoiceInfo_StockTransfer`, `InvoiceInfo_Product_StockTransfer`, `InvoiceInfo_StockInward`, `InvoiceInfo_Product_StockInward` (branch transfers), `tbl_product_serial*` (serial numbers), `Branch_Relation` (which branches may exchange stock).

### 6.2 Stock entry (`frmStockEntry`, "Stock Entry": add quantity to an existing lot by barcode, no money)

- The cashier gives a barcode (it must be a lot that already exists: the product name and unit are read from `Temp_Stock` by barcode, `frmStockEntry.vb:993`), a quantity (not empty, not zero), a date (inside the current financial year, else "Your selected date is not between current financial year"), remarks.
- Save (`frmStockEntry.vb:1022`): for each line `Temp_Stock.Qty = Qty + qty` (if the lot is missing a bare lot row with only product, qty and barcode is inserted); `StockMovement` StockIn = qty (date = entry date); `Stock_Store(ST_ID, Date, Remarks)` and `Stock_Store_Join(StockID, ProductID, Qty, Barcode)`. **No ledger, no price, no tax.**
- Delete (`frmStockEntry.vb:844`): `Temp_Stock.Qty = Qty - qty`, movement rows and the record deleted. Nothing stops this from making stock negative.

### 6.3 Stock adjustment (`frmStockAdjustment_Store`)

- Fields: product and barcode, date, **Plus or Minus**, quantity (not empty, not zero), **reason (required)**. The screen shows "Qty. Available in Store" (the lot's `Qty`) and loads the lot's prices, MRP, batch, dates, size, colour, IMEI, damage and minimum stock.
- Save (`frmStockAdjustment_Store.vb:895` to `1000`): `StockAdjustment_Store(SA_ID, ProductID, Barcode, Date, AdjustmentType, Qty, Reason)`; Plus: `Qty = Qty + q`, `StockMovement` StockIn = q; Minus: `Qty = Qty - q`, StockOut = q. **No check that a Minus leaves the lot at zero or more.** No money, no ledger.
- Edit (`:1172` to `1264`): reverses the old effect and applies the new (`Qty + old`/`- old`, then the new sign and quantity) and updates the movement row. Delete (`:769` to `820`): reverses the effect (`Plus` becomes `Qty - q`, `Minus` becomes `Qty + q`) and deletes the movement row.

### 6.4 Damage and recover (`frmDamageProduct`)

- **Damage is a counter on the lot, not a movement:** `Temp_Stock.Damage`. On-hand `Qty` does not change; good stock = `Qty - Damage`.
- Add damage `d` (`btnSave_Click`, `frmDamageProduct.vb:1027`): new damage = `Damage + d` (`TextBox8`, `:736`). Refused ("Damage quantities are exceeded than avaliable quantities") when `d > Qty - Damage`, unless the override box `CheckBox2` is ticked.
- Recover `r` (`:1067`): new damage = `Damage - r` (`TextBox10`, `:742`). Refused when `r > Damage`, unless the override is ticked.
- Writes only `Temp_Stock.Damage` and a log line ("Damage qty ... are added in Product name ..."). **No `StockMovement`, no ledger, no loss value.** Totals shown: damage = `Sum(Damage)`, good = `Sum(Qty) - Sum(Damage)`, total = `Sum(Qty)` (`frmDamageProduct.vb:994`).

### 6.5 Transfers between stores and branches (three different mechanisms)

**A. Transfer token (`frmStockTransfer`)**: send chosen lots to another branch as a "token".
- Token number = `Company.BCode` (branch code) + `(1000 + (highest P_Transfer.ID + 1))` (`GenerateTokan`, `frmStockTransfer.vb:845`).
- Per chosen lot and quantity `T_Qty` it writes a **full copy of the product and lot** into `P_Transfer` (product code, name, HSN, part no, description, `CostPrice`, `MRP`, `SellingPrice`, `ReorderPoint`, `Discount`, `CGST`, `SGST`, `CESS`, units, `Conv`, `MinStock`, `GDown`, `Rack`, `DefQty`, lot prices, batch, dates, colour, size, IMEI, category, sub-category, `TocknNo`, `T_Qty`, `PStatus` = "p" = pending) (`frmStockTransfer.vb:753`) and **immediately reduces the sending lot: `Temp_Stock.Qty = Qty - T_Qty`** (`CheckBarcodeExists`, `:837`). No check against `Qty`. No movement row, no money.
- The receiving branch loads the token into `p_transfer_in`; accepting it is "Settlement" (below), which sets `PStatus` to "f" (finished).

**B. Branch stock-transfer document (`frmPOSNewTuch_StockTransfer`, touch till)**: a **sale-like bill** from this company to another branch (`Branch_Relation`: `to_company_id`, `CompanyName`): same lines, same tax and total arithmetic as a sale (section 1; the `Calc` is the same code), saved to `InvoiceInfo_StockTransfer` (with `from_company_id`, `to_company_id`, status 0) and `InvoiceInfo_Product_StockTransfer` (`frmPOSNewTuch_StockTransfer.vb:24096`, `24595`); sending lot `Temp_Stock.Qty = Qty - qty` (`:24316`); the same optional stock warnings as a sale. On the other side `frmStock_Inward_Notification` lists the documents addressed to this branch (status 0); "Stock Inward" (`frmPOSNewTuch_StockInward`) saves `InvoiceInfo_StockInward` and `InvoiceInfo_Product_StockInward` and **adds** `Temp_Stock.Qty = Qty + qty` (`:12281`), and the sender's document is set to status 1 (`frmStock_Inward_Notification.vb:1346`).
**C. Settlement (`frmStock_Settlement`)**: takes in the lines of a token or an inward document into this branch's stock: if the barcode is already a lot here: `Temp_Stock.Qty = Qty + T_Qty` (`:1146`); if not, it **creates the missing category, sub-category, product (with its photo) and the lot** (`InsertProduct`, `:815` to `960`: `Product`, `Product_Join`, `Temp_Stock` with the prices from the token, a `StockMovement` row, a QR image for the barcode) and then sets statuses: `p_transfer_in.PStatus` = "f", `InvoiceInfo_StockTransfer.status` = 2, `InvoiceInfo_StockInward.status` = 1 (`:981` to `1019`).
- Status codes seen: token `PStatus` p (pending) and f (finished); transfer document status 0 (sent), 1 (taken in by the receiver), 2 (settled); inward status 1.
- **These flows move the documents between branches through an online service** (the receiving screens fetch documents from other companies; `frmGodownConfig` is titled "Multi Branch Cloud Stock Storage Configuration" with a web address field and a credential field; no credential value is in this file). Which exact channel carries each document was not traced (see Not understood). The owner's rule is that nothing goes to the cloud unless allowed (`CLAUDE.md` section 16), so this is **not to be ported as is**; the Hub's way for several counters is the main PC with the counters on the shop network, and for several stores a head-office summary of totals only.

**D. Godown Outward and Inward (`frmGodownOutward`, `frmGodownInward`)**: "Outward Stock Transfer" and "Inward Stock Transfer" through the cloud (a pushed record per lot, `FirebaseCRUDData`). Outward (`frmGodownOutward.vb:1380` to `1545`): needs product, barcode, quantity, a receiver company or branch id different from this company, an internet connection and **sufficient stock** ("Sufficient stock is not available !" is a **hard block** here, unlike a sale); makes a new barcode `oldBarcode + "*" + token`; `Temp_Stock.Qty = Qty - qty`; movement StockOut. Inward (`frmGodownInward.vb:824` to `1030`): finds the lot by the new barcode: `Qty = Qty + qty`, or creates the product (from the pushed record) with its lot (`Temp_Stock`, `Product_OpeningStock`, `Product_Join`) and a movement StockIn. Cloud again: not to be ported.

### 6.6 Opening stock

- **With a new product** (`frmProduct`): the lots typed on the product screen become `Product_OpeningStock` and `Temp_Stock` rows (`SuplName` = "Opening Stock", `StLimit` = the product's `MinStock`) and one `StockMovement` StockIn row dated today (`frmProduct.vb:7448`, `7522`, `7670`).
- **Excel import** (`frmExportImportExcel_OpeningStock`): reads `Sheet1` with columns product id, opening qty, MRP, sale price, wholesale price, batch, mfg, exp, size, colour, barcode, purchase price, IMEI 1, IMEI 2. Every row must have id, qty, MRP, sale price, wholesale price, barcode and purchase price (else "... Cell Blank Found"). **A barcode that already exists in `Product_OpeningStock` or `Temp_Stock` is refused** ("Barcode ... Already Exists"). Per row: `Product_OpeningStock` with `OPSValue = qty x purchase price` (`:594`, params `d16`), `Temp_Stock` with `Qty` = opening qty, `PPrice` = `EPPrice` = the typed purchase price (so cost per unit = typed price, no tax split), `SuplName` "Opening Stock"; a `StockMovement` StockIn row (date = today).

### 6.7 Reports that read stock

- **Stock movement report** (`frmStockMovementReport.vb:435` and `483`): for a date range (`Date >= from and Date < to`), grouped by `Date, product`: `Opening = Max(OpeningStock of that day's rows)`, `In = Sum(StockIn)`, `Out = Sum(StockOut)`, **`Closing = Opening + In - Out`**. For one product or all.
- **Stock in and out report** (`frmStockInAndOutReport.vb:385`, `412`): in stock = lots with `Qty > 0` of products with `Product.Status = "Yes"`, with **cost value = `Product.CostPrice x Qty`** (the master's latest purchase price, not the lot's `EPPrice`) and **sale value = `Temp_Stock.SPrice x Qty`**; out of stock = lots with `Qty <= 0`; filter by supplier name (`SuplName`).
- **Current stock** (`frmCurrentStock`): lot list with `Qty`, `Damage`, `Qty - Damage`, `PPrice`, `EPPrice`, `SPrice`, `WPrice`, `MRP`, batch, dates, size, colour, IMEI, product minimum stock, tax types, godown and rack.

### 6.8 Serial numbers and variants

- **Serial numbers exist only in the touch tills** (`frmPOSTouch`, `frmPOSNewTuch`; no serial code in `frmPOS.vb`) and in purchase entry, sales return and purchase return. Each unit can carry **two numbers** (`serialno1`, `serialno2`, for example a serial and an IMEI).
- **Purchase** (`frmPurchaseEntry.vb:6618` to `6660`, `11762`): while entering, serials are kept in the working table `tbl_product_serial(productid, barcode, serialno1, serialno2, status, sys_user, invoice_no)`; **the number of serials for a barcode must equal the line's quantity** ("Quantity mismatch"). On Save they are copied to **`tbl_product_serial_final`** with the invoice number and the working rows are deleted. Status "PURCHASE" = in stock. Delete or edit of the purchase clears the final rows of that invoice (`:12267`).
- **Sale** (`frmPOSTouch.vb:30688` to `30698`, `31526` to `31543`; the same in `frmPOSNewTuch.vb`): per sold serial a row in `tbl_product_serial_sale(productid, barcode, serialno, status, sys_user, invoice_no)` and `tbl_product_serial_final.status = "SALE"`.
- **Sales return** (`frmSalesReturn.vb:3356`, `3366`): the returned serials go into `tbl_product_serial_saleReturn` and the final row's status goes back to "PURCHASE". The number of chosen serials must equal the return quantity.
- **Purchase return** has `tbl_product_serial_purchaseReturn` (how it sets the status was not read).
- Reports: `frmSerialwiseReport` (by serial number), `frmProductRec_serial`, `frmProductRec_serial_sale` (serial lists).
- **Older, simpler way for one-unit items (phones)**: a lot of quantity 1 with `Temp_Stock.IMEI1`/`IMEI2` (copied onto the bill line, `Invoice_Product.IM1`/`IM2`).
- **Variants**: `Temp_Stock.Variant_id` (text) groups several barcodes (lots, for example sizes and colours of one article); the purchase screen can load every barcode of a variant at once (`frmPurchaseEntry.vb:8586` to `8660`, from `Temp_product(variant_id, PID, qty, barcode)`); the variant screen is `frmProductRec_variant` (not read: see Not understood).

### 6.9 Negative stock and the checks, in one place

| Where | Check | Effect |
|---|---|---|
| Till sale and edit (all till screens) | `CInt(Round(qty)) > Qty` if switch `CheckBox6` is on; `CInt(Round(qty)) > Qty - StLimit` if switch `CheckBox8` is on | A Yes/No question only. With the switches off **nothing is checked**. Stock can go negative. |
| Branch transfer document (touch) | same as a sale | question only |
| Sale of an expired lot | bill date on or after `Expdate` | **blocked** (1.3) |
| Godown outward | `qty > Qty` | **blocked** |
| Token transfer, stock adjustment Minus, stock entry delete, purchase delete, purchase return | none found | stock may go negative |
| Damage | `d > Qty - Damage` (override box) | blocked unless override |
| Reports | lots with `Qty <= 0` are listed as out of stock | negative lots appear there |
| Purchase | resets `StLimit` to 0 for the lot | later minimum-stock warnings stop |

### 6.10 Test vectors (hand-worked)

| # | Case | Arithmetic | Result |
|---|---|---|---|
| S1 | Stock entry | lot (P5, barcode 1004) Qty 7; entry qty 3 | Qty 10; StockMovement In 3, Opening = sum of earlier In - Out |
| S2 | Adjustment minus below zero | Qty 10, Minus 12 | Qty -2 (no check); movement Out 12 |
| S3 | Adjustment edit | saved Plus 5 (Qty 15), edited to Minus 2 | reverse: Qty 15 - 5 = 10; apply: 10 - 2 = 8; movement row updated to Out 2 |
| S4 | Damage add | Qty 10, Damage 1, add 3 | check 3 > 10-1=9? no: Damage 4; good = 10-4 = 6; Qty stays 10 |
| S5 | Damage refused | Qty 10, Damage 1, add 10 | 10 > 9: refused (unless override) |
| S6 | Recover | Damage 4, recover 3 | Damage 1; recover 5 refused (5 > 4) |
| S7 | Token transfer | Qty 10, transfer 4, last P_Transfer.ID 9, BCode "AB" | Qty 6; `P_Transfer` row `T_Qty` 4, `PStatus` p; token = "AB" + (1000 + 10) = "AB1010" |
| S8 | Settlement, lot exists | receiving lot Qty 3, token T_Qty 4 | Qty 7; `PStatus` f |
| S9 | Settlement, new product | token lot unknown here, T_Qty 4 | product, lot (Qty 4) created; **StockMovement StockIn = 10, not 4** (the code writes a fixed 10, `frmStock_Settlement.vb:921` and `938`; fix) |
| S10 | Opening stock value | import row: qty 20, purchase price 12.50 | `OPSValue` R2(20 x 12.50) = 250.00; lot `EPPrice` 12.50 |
| S11 | Movement report, one day | product rows on day D: (Opening 20, In 0, Out 5), (Opening 20, In 10, Out 0) | Opening Max = 20; In 10; Out 5; Closing 20 + 10 - 5 = 25 |
| S12 | Stock value | lot Qty 7, `Product.CostPrice` 50.00, `SPrice` 80.00 | cost value 350.00; sale value 560.00; a lot with Qty 0 or less is not in the value list |
| S13 | Minimum-stock warning | Qty 8, `StLimit` 5, sale qty 4, switch on | 4 > 8 - 5 = 3: asks; after a purchase of the same barcode `StLimit` = 0: 4 > 12? no question |
| S14 | Fraction check | Qty 2.3, sale 2.4, switch on | `CInt(Round(2.4))` = 2; 2 > 2.3? no question although 2.4 > 2.3 |
| S15 | Serial count | purchase qty 3, 2 serials entered | refused (count must equal quantity) |
| S16 | Serial lifecycle | purchase of 3 serial units | final rows status PURCHASE; sale of 1: that row SALE and a `tbl_product_serial_sale` row; return of it: row back to PURCHASE |
| S17 | Godown outward block | Qty 2, send 5 | refused "Sufficient stock is not available !" |

### 6.11 Quirks and probable bugs (keep or fix?)

1. **Damage is not a stock movement** (6.4): reports and the movement history miss it, and a damaged unit can still be sold (sale only looks at `Qty`). fix: in the Hub a damage is a stock move with a reason and a cost value.
2. **Settlement writes a fixed StockIn of 10** for a product created from a token (S9). fix.
3. **A purchase resets the lot's `StLimit` to 0 and overwrites the lot's prices and MRP** (5.4, S13). fix? decide with the owner (a new price should be a new lot).
4. **Adjustment and transfer-out have no stock check**; godown outward does. keep the freedom to adjust, add a check for transfers (fix).
5. **Whole-number stock check for fractions** (S14). fix.
6. **Transfer flows depend on an online channel** and on `ExtDB*` tables whose use was not read. Do not port; design the Hub's own way (shop network, head-office summary).
7. **`Product.OpeningStock`** (master column) is only a typed number; the live stock is `Temp_Stock`. When importing, read lots, not that column.
8. **Stock value uses `Product.CostPrice`** (latest price), not the lot's cost: the same lot is valued differently here and in `EPPrice`-based margin. Keep for matching old reports; choose one in the Hub.



## 7. What the Hub has today, topic by topic, and where the numbers differ

Hub code read: `apps/business-hub/src/NextGenOS.Hub.Core/Documents/DocumentService.cs`, `Documents/Models.cs`, `Documents/Numbering.cs`, `Shop/ShopContext.cs`, and the shared tax engine `libs/dotnet/NextGenOS.Tax/TaxEngine.cs` (the Hub's `DocumentService.Calculate` hands every bill to it). Country pack `country-packs/packs/IN.json` for the India rates and rounding. I read the code; I did not run it.

### 7.1 Till lines, tax, discount, totals, round-off (status: DONE)

**Update, 7 October 2026: D3 and D4 are closed in the Hub** (line discount by amount; bill discount spread over the lines before tax, decision 33; credit notes carry the exact share). Tests: `apps/business-hub/tests/NextGenOS.Hub.Tests/DiscountTests.cs` (L2, L3, L13, B4 with the new rule). D5 (tax mode per item), D6 (cess) and D12 (free-quantity promotion) are still open.

**What the Hub does** (`DocumentService.Recalculate`, `DocumentService.cs:207`; `TaxEngine.Calculate`, `TaxEngine.cs:21`):
- Money is whole minor units (a `long`), quantity is in thousandths (`qty_milli`), percentages are in thousandths of a percent (`discount_pct_milli`). The engine uses `BigInteger` and **rounds half up** (`R(a, b) = (2a + b) / 2b`, `TaxEngine.cs:17`) at every step. There is no floating point.
- Per line: `gross = R(qty * price, 1000)`; percent discount `= R(gross * pct, 100000)` (capped at gross); `net = gross - discount` (`TaxEngine.cs:41` to `46`).
- Exclusive (`TaxLine`, `TaxEngine.cs:228`): `tax = R(net * rate, 100)`; for India CGST `= R(net * rate, 200)` and SGST = CGST (`TaxEngine.cs:244`); cess `= R(net * cess%, 100)`.
- Inclusive: `taxable = R(net * 100 / (100 + rate + cess))` (the divisor **includes cess**), `taxTotal = net - taxable`, `cess = R(taxable * cess%)`, `tax = taxTotal - cess`; India `CGST = R(tax / 2)`, **`SGST = tax - CGST`** (`TaxEngine.cs:221` to `246`). So CGST plus SGST always equals the tax exactly.
- Bill: sums of lines, then adjustments (service charge, fee, tip, advance, retention); `grand = subtotal`, or `R(subtotal / increment) * increment` when "round total" is on (`TaxEngine.cs:184`); `payable = grand + tips - advances - retention`.
- The document keeps `subtotal_minor` = **taxable total** (not taxable plus tax), `tax_minor`, `total_minor` = grand total, `payable_minor`, `paid_minor`; the engine's full answer (including `RoundOff`) is kept as JSON in `documents.result`.
- India pack: `pricesIncludeTaxDefault: true`, `rounding = nearest, increment 1, defaultOn false` (same default as the old POS: round-off off).
- Number of a final invoice: `INV-<fiscal year>-000001` (`Numbering.cs`).

**Where the numbers differ from the old POS** (each is a decision for the owner before porting; the first two matter every day):

| # | Old POS | Hub | Example (see 1.7) | Verdict |
|---|---|---|---|---|
| D1 | Rounding half to even (100.50 -> 100; 0.005 -> 0.00) | Half up (100.50 -> 101; 0.005 -> 0.01) | B3: total 100.50 with round-off on: old grand 100.00, Hub grand 101.00. Exclusive 5% GST on 0.20: old CGST 0.00 + SGST 0.00; Hub 0.01 + 0.01 | Differences only at exact half-paisa ties. The Hub's rule is the usual one in tax law; the old rule was an accident of .NET. Recommend: keep the Hub's rounding, tell the owner, import old bills as they were saved (never recompute old bills). |
| D2 | Inclusive split: `gst = R2(base - base/(1+r))`, then CGST = SGST = R2(gst/2) each (can lose or gain a paisa) | CGST = R(tax/2), SGST = tax - CGST (exact) | L7 (0.21 at 5% inclusive): old CGST 0.00, SGST 0.00, taxable 0.21; Hub CGST 0.01, SGST 0.00, taxable 0.20, total 0.21 | Hub is better. With no tie, old and Hub agree (L4, L5, L6, L8 give the same numbers in both). |
| D3 | **Bill-level discount**: flat amount (typed, loyalty points, offer, coupon, gift) taken off the total **after tax** | **No bill discount.** Adjustments are surcharge, fee, tip, advance, retention only. | B4, B5 | **GAP.** Must be added (see porting notes). Decide whether the discount should reduce tax (spread over the lines before tax) or not (old way). |
| D4 | Line discount by **percent or by amount** (percent kept to 4 decimals when typed as an amount) | Percent only, in thousandths of a percent; the engine can take an amount (`DiscountAmount`) but `DocumentService.Calculate` does not pass one and `document_lines` has no column for it | L3 | **GAP.** Add a discount-amount column, or an amount typed by the cashier will lose exactness (7.5% is fine; 30.003% is not exact). |
| D5 | Tax mode **per item** (Exclusive, Inclusive, Exempt GST, No Taxes) | Prices include tax is **per document** (`prices_include_tax`) | one bill with L1 and L4 | **GAP.** The old shop could mix; the Hub cannot on one bill. Decide: per-item flag on the item, applied per line. |
| D6 | CESS % per item, carved or added | Engine supports cess (`CessPercent`), but `DocumentService.Calculate` does not pass it, and the item has no cess field | L10 | **GAP** at the document layer. |
| D7 | Exempt GST item still pays CESS (probable bug) | Exempt = no tax at all | L10: old total 210.00, Hub 200.00 | Hub is right. Do not port the old behaviour. |
| D8 | CGST % and SGST % can differ per item | One rate; CGST = SGST (half each) | n/a | Only matters for odd old items; import maps CGST + SGST to one rate code. |
| D9 | `InvoiceInfo.SubTotal` = taxable + tax; `Total` = before round-off; `GrandTotal` = after | `subtotal_minor` = taxable; `total_minor` = grand | all bills | **Mapping trap** when importing: old `TaxableAmt` -> Hub `subtotal_minor`; old `GrandTotal` -> `total_minor`; old `RoundOff` -> kept in the result JSON. |
| D10 | Price tier (Retail/Wholesale) chosen at the till | Chosen by the customer's price level (`item.PriceFor(party.PriceLevel)`) | n/a | Different idea; keep the Hub's, add a till switch if the owner wants the old one. |
| D11 | Quantity can be negative at the till (no check found) | Quantity must be more than zero (`DocumentService.cs:124`) | n/a | Hub is safer; returns go through credit notes. |
| D12 | Free-quantity promotion per product (`Promotion`) | Not found | L16 | **GAP** (offers module). |
| D13 | Customer-state tax split from text names | Region codes (`BuyerRegion`, `SellerRegion`); blank buyer = same state | n/a | Same behaviour when blank. Import must map state names to the pack's two-digit codes. |

**Worked examples that the Hub should pass as they are** (same answers old and Hub, no tie involved): L1, L2, L3 (if D4 is closed), L4, L5, L6, L8, L9, L12 (as unregistered shop), L13, L14, B1, B6, B7. **Examples that differ and need the owner's decision**: L7, L10, B2/B3 (tie), exclusive 5% on 0.20 (D1), and every bill with a bill discount (B4, B5).

### 7.2 Payments, balances, hold, edit, delete, numbering (status: DONE)

**What the Hub does** (`DocumentService.Issue`, `DocumentService.cs:252`; `AddPayment`, `367`; `Void`, `382`; `Numbering.cs`):
- A bill is built as an `open` document (this is the Hub's "hold": it stays open, `Discard` removes it, stale open bills are cleared after a day, `DiscardStaleDrafts`). `Issue` is one database transaction: it recalculates, numbers the bill (`INV-<fiscal year>-000001`, per type and fiscal year, in the same transaction so an abandoned bill leaves no gap), takes the payments, moves stock, writes the audit log. After issue, **amounts never change**; there is no edit of an issued bill.
- Payments: each payment row has a method that must be one of the country's methods (`shop.Current.PaymentMethods`); rows with amount more than zero count. **Paying more than the bill** is allowed only if the extra is in cash; the extra is taken off the cash rows as change and stored in the document's `meta` (`changeGiven`, `tendered`) (`DocumentService.cs:277` to `286`). **Paying less**: refused ("short") unless `OnCredit` (the customer must have `Features.Credit` and a credit limit above zero, and `outstanding + unpaid part <= limit`) or `OnAccount` (due after the customer's terms; no limit check; for progress bills).
- Later payment on an issued document: `AddPayment` (cannot be more than the balance).
- Outstanding of a customer = sum of (`payable_minor - paid_minor`) over issued unpaid invoices and progress bills (`Outstanding`, `462`). Ageing report: `ReportService.Outstanding`.
- Cancel: `Void` (reason needed): stock comes back, the money paid is refunded as a negative payment, status "void". Part-return: credit note (7.3).
- There are **no ledger tables**: no `LedgerBook`, no customer ledger, no bank ledger. Balances come from documents and payments.

**Where it differs from the old POS**

| # | Old POS | Hub | Verdict |
|---|---|---|---|
| E1 | Edit a saved bill in place (stock re-adjusted, ledgers rewritten) | No edit after issue; void, then make a new bill | Keep the Hub's rule (safer, auditable). The cashier's "edit" becomes "void and re-issue"; decide whether the new bill keeps the old number (old POS did; Hub gives a new one). |
| E2 | Delete a bill, which frees the number if it was the last | Void keeps the number and the document | Hub is right (numbers never reused). |
| E3 | Customer balance is a **ledger** (advance as positive, owing as negative) that includes receipts on account and an opening balance (`Customer.Opbal`, `Optype`) | Balance per document only; no customer-level advance; no opening balance field; receipts on account have no home | **GAP.** Needed for old customers: opening balance, advance (credit) balance, "receipt on account" that is allocated to bills (oldest first) or kept as advance. |
| E4 | Credit limit enforced only when the customer's `Lstatus` = "Yes"; otherwise credit is unlimited | Credit needs a limit above zero; zero means no credit at all | **Mapping trap:** import "not enforced" as a flag or a very large limit, not as 0. |
| E5 | Credit terms picked per bill ("Credit Terms - 30 days") | Terms per customer (`terms_days`) or the pack's rule | Add a per-bill choice if wanted; the due date is `bill date + days` in both. |
| E6 | Payment mode list is fixed text (cash, cheque, cards, PhonePe, Google Pay, Paytm, E-Wallet, credit terms) | Methods come from the country pack and shop settings | Map old mode names to the Hub's codes when importing (keep the old text in `reference`). |
| E7 | Sum of all payment rows must equal the grand total exactly; change is a separate "tender/refund" figure kept on the invoice | Overpay is accepted only as cash change; tender and change are in `meta` | Same idea; keep `Tender`, `Refund` in meta for printing. |
| E8 | Bill number `GST-0001-2025/26` (prefix and suffix are settings; separate `SINV-` series for NON GST) | `INV-2025-000001` (prefix by type, fiscal-year key, 6 digits) | Not the same text. Old numbers must be kept as given when importing (store the old number as the document number; the series continues from the Hub's own counter, or set the counter so the next number follows the old one). Prefix and suffix as settings: **GAP** if the owner wants the old look. |
| E9 | Hold list per till (host name), "H-0001" | One open document per bill, no per-till filter | Add a till/user filter to the open bills list. |
| E10 | Salesman commission saved per bill | Not found | Salesperson module (merge plan step 6). |
| E11 | Loyalty points, coupons, gift cards, offers per bill | Not found in `DocumentService` | Customers work package (merge plan step 2). |
| E12 | Each save is many separate statements (no transaction) | One transaction | Hub is right. |
| E13 | Per-bill salesman, broker, TCS, e-way bill, narration | Notes and `meta` only | India module and salesperson module. |

**Test vectors for the Hub** (from 2.9): P1, P2 (as `OnCredit` with a credit limit of at least 44.00), P3 and P4 (credit limit; the Hub also needs the customer's outstanding to be -500 expressed as owed 500.00), P9 (as cash change: tendered 200.00 on 194.00 gives change 6.00 in `meta`), P11 to P15 (only after the numbering text is decided in E8), P16 and P17 (void gives stock back; edit has no Hub equivalent).

### 7.3 Returns and refunds (status: DONE)

**What the Hub does** (`DocumentService.CreateCreditNote`, `DocumentService.cs:409`; `Void`, `382`):
- A credit note is made **from an issued invoice**: the cashier names lines (by line id) and quantities; each line is copied with the **same unit price, discount %, tax code and customer discount**, so the same engine works it out (`CreateDraft` with `RefDocumentId`); quantity per line cannot exceed what was invoiced minus what earlier credit notes already took back (grouped by description, price and discount) (`DocumentService.cs:417` to `426`).
- Number `CN-<fiscal year>-000001`. Stock goes back with `MoveStock(+1, "return")` (`DocumentService.cs:446`); item level, no lot.
- Money: `refundable = min(credit note total, invoice paid)` when `refundPaid` is true; paid out by the chosen method as a **negative payment**; the invoice's `paid_minor` is lowered by the same amount (`DocumentService.cs:440` to `445`).
- Code comment says "a credit note never rounds", but `CreateDraft` takes the shop's current round-total setting for every new document, so a credit note appears to round when the shop rounds. I read this and did not run it; it must be tested.

**Where it differs from the old POS**

| # | Old POS | Hub | Verdict |
|---|---|---|---|
| F1 | Return amount worked from the original line's rate and **discount %**, Inclusive tax halved without rounding (R4, R5) | Same engine as the sale; CGST = R(tax/2), SGST = tax - CGST | Hub is exact. For R1 to R3 the numbers are the same (35.40, 70.79, 106.19). R4 (1 of 2 units of L5): old CGST 2.38, SGST 2.38, taxable 95.23, grand 99.99; Hub taxable R(9999 x 100000 / 105000) = 9523 -> 95.23, tax 4.76, CGST 2.38, SGST 2.38, total 99.99 (same). They differ only at half-paisa ties (R5). |
| F2 | Return mode **Cash** or **Credit** (customer ledger credit) | Refund by any method up to what was paid; **no customer credit balance** | **GAP** (E3): "Credit" has nowhere to go. A credit note for an unpaid credit sale appears not to reduce the customer's outstanding at all, because `Outstanding` only counts invoices and progress bills (`DocumentService.cs:462`). To be tested; if confirmed it is a bug to fix before porting. |
| F3 | Return line limited per product across all returns, as a whole number | Per line, in thousandths | Hub is better. |
| F4 | Serial-numbered items: returned serials chosen and put back in stock | No serial numbers | **GAP** (see 7.6). |
| F5 | Loyalty points and salesman ledger rows taken back | None | Customers and salesperson work packages. |
| F6 | "By Return": a return can pay for a later bill | Not found | **GAP.** In the Hub the natural form is a customer credit balance used as a payment method (needs E3). |
| F7 | Return of a bill is refused to edit/delete the original | Original is never edited; void is refused when a credit note exists (`has-credit-note`) | Same idea. |
| F8 | Cash refund calculator, sell-by-amount, multi-payment dialog | Not found | Till conveniences; port as screens later. Sell-by-amount and change calculation are simple (formulas in 3.1). |

**Hub tests that should use the old vectors:** R1, R2, R3 (credit note of 1, 2 and 3 of 3 units of L2: 35.40, 70.79, 106.19; the Hub engine gives the same numbers, hand check: 1 unit: gross 33.33, discount R(3333 x 10000, 100000) = 333 -> 3.33, net 30.00, CGST R(3000 x 18000, 200000) = 270, total 35.40), R6 and R7 only after F2 is decided.

### 7.4 Estimates, quotations, service billing (status: DONE)

**What the Hub does**
- A document type `quote` exists in the money code: `CreateDraft` numbers it at once (`QUO-<fiscal year>-000001`, `DocumentService.cs:89`); `Issue` keeps that number, takes no payment, moves no stock (stock moves only for `invoice` out and `purchase`, `DocumentService.cs:314`), and the Documents list and receipt can show it. **The only place that creates one is `ProjectService.CreateQuote` (construction projects)** (`Projects/ProjectService.cs:117`); there is no retail quote screen, no estimate, no "convert a quote to an invoice" (no code copies a quote's lines into an invoice; a credit note is the only document that points back with `ref_document_id`).
- Totals of a quote are the same as an invoice's (same engine: tax added or carved out by `prices_include_tax`, round-total setting), so a Hub quote matches the old **quotation** (not the old estimate, which adds no tax).
- Service: items of a kind with a duration (`duration_min`), `appointments` (`Appointments` module), and ordinary invoice lines. **No repair job, no job status, no advance taken at the job and netted at the bill, no job number.** The engine has an `advance` adjustment (reduces `payable`, not `total`).

**Where it differs from the old POS**

| # | Old POS | Hub | Verdict |
|---|---|---|---|
| K1 | Estimate: no tax added, total = qty x price - discount (E1 to E4) | None | **GAP.** Decide: an estimate is a quote with prices that include whatever the customer is told (tax flagged off), or a document with its own rule. Vectors E1 to E4 pin the old numbers. |
| K2 | Quotation with tax (Q1) | Quote type exists with the same engine | Port: retail quote screen. Vector Q1 gives the same answer as the engine (hand check: Hub 189.99 taxable + 34.20 tax = 224.19). |
| K3 | Convert: copy price, discount %, quantity, tax %; items re-read from stock; "Ref : number" text; the source is not marked | Not found | **GAP.** In the Hub: copy all lines into an invoice draft and set `ref_document_id` to the quote; mark the quote "billed". Keep the old **price copy** (E7). Decide E5 (tax added on top for an Exclusive item) together with K1. |
| K4 | Service job with upfront, status, charges quote, estimated repair date; bill nets the upfront; one service-tax percent | None | **GAP.** Needs a job record (number, status, quote, advance) that becomes an invoice; with the Hub's rule the invoice total is the full value and the advance is a payment already taken (so `GrandTotal` differs from old `GrandTotal` by the upfront, SV1). Tax split per country pack, not one percent. |
| K5 | Touch quotation and touch service tills are copies of the sale till | One billing screen | Do not port the copies. |

**Hub tests that should use the old vectors**: Q1 (a quote of the B1 lines: 224.19; with round-total on 224.00; the Hub rounds half up so 224.19 -> 224 is the same here), SV1 as an invoice of 1180.00 with an advance payment of 300.00 and a balance of 880.00 once the job record exists; E1 to E6 only after K1 is decided.

### 7.5 Buying (status: DONE)

**What the Hub does** (`PurchaseService.cs`, 59 lines; `DocumentService.Issue` for `purchase`):
- `CreateOrder(supplierId, lines)`: a draft document of type `purchase`, direction "in", numbered at creation `PO-<fiscal year>-000001` (`DocumentService.cs:89`). A line is item, quantity (thousandths), cost per unit. **No line discount, no bill discount, no freight, no previous due, no reverse charge, no selling prices.**
- `Receive(orderId)`: `DocumentService.Issue` (the number is kept; no payment taken; stock goes **up** by each tracked item's quantity: `MoveStock(+1, "purchase")`, `DocumentService.cs:315`); then each item's `cost_minor` is set to the line's unit price (`PurchaseService.cs:36` to `47`). The price is the entered unit price, **before** discount and tax (no discount exists), and the same price whether the shop's prices include tax or not.
- `Pay(orderId, amount, method)`: `AddPayment` on the issued purchase; cannot be more than the balance. `Payable()`: issued, unpaid purchases.
- Tax on a purchase goes through the same engine as a sale, with the document's `prices_include_tax`; the result is kept in `documents.result`.

**Where it differs from the old POS**

| # | Old POS | Hub | Verdict |
|---|---|---|---|
| H1 | Line discount (percent or amount), bill discount, freight, reverse charge, previous due, round-off on a purchase | None of these on a purchase | **GAP** (discount and amount discount: same gap as D3, D4; freight and reverse charge: `fee` adjustment exists but `PurchaseService` does not pass one). |
| H2 | Each purchase line is a **lot**: barcode, MRP, retail and wholesale price, batch, mfg and exp dates, size, colour, IMEI, supplier | Item level only: no lot, no MRP, no batch, no expiry | **GAP** (see section 6 and the Hub map `docs/old-programs/06-hub-map.md`: no variant, batch or serial tables). |
| H3 | Purchase overwrites `Product.CostPrice`, `MRP`, `SellingPrice` and the wholesale price; the lot keeps `EPPrice` = taxable / qty | Overwrites only `cost_minor` with the gross unit price | **Differs.** Hub cost = price entered; old lot cost = price after discount, without tax. Decide the meaning of "cost" (margin and stock value use it: `ReportService` stock value = on hand x `cost_minor`). |
| H4 | Purchase types Cash, Credit, Bank with a paid amount on the bill; supplier credit limit | Receive takes no payment; pay later with `Pay`; no supplier credit limit | **GAP:** payment at receipt; supplier limit. |
| H5 | **Purchase return** (cash or credit; stock goes out; supplier ledger debited) | **Built 8 October 2026 (merge wave 2):** `DocumentService.CreateDebitNote` (document type `debit-note`, number `DN-`, direction in, no database change), *Send goods back* on a received purchase's page (`Bill.razor`), books (`BooksService`: the sale's lines renamed for the supplier, not turned; stock at what the returned lines cost, `purchase-return` moves), the purchase report, the tax summary and a *Goods sent back* register and export. Tests: `PurchaseReturnTests` 12 (U13 exactly: 33.33 less 1.67 is 31.66, tax 2.85 + 2.85, total 37.36; U14's cash return nets to nothing owed; a part-paid purchase; amount discounts that add up in parts; a long random mixture), `AccessTests`, `e2e/wholesale.e2e.mjs`. **Differs on purpose:** the credit is first put against what is still unpaid on that purchase (it then counts as paid there), and only the rest can come back as money (the older POS paid the whole return back in cash even if nothing had been paid); a return that would take more than is on the shelf is refused when negative stock is not allowed (the older POS let stock go below nothing); a return is final (no cancelling it), and a purchase that was sent back cannot be cancelled. **Not built:** serial numbers on a return, reverse charge on a return, returning to a lot, "previous due" and freight on a return. |
| H6 | Supplier ledger: balance = credits - debits, includes opening balance; payments on account | No supplier ledger; payment is against one purchase; opening balance not found | **GAP** (same as E3, for suppliers). |
| H7 | Purchase order is a separate paper with terms and conditions; becomes a purchase by "retrieve" (order stays) | The order **is** the purchase document; "receive" makes it final | Hub is simpler. Terms text and "order stays open after partial receipt" not found. |
| H8 | Purchase tax mode separate from the sales mode; supplier state (blank = other state) decides IGST | One tax registration setting; supplier region code; a blank buyer region counts as the same region (`ComponentNames`, `TaxEngine.cs:279`) | Blank-state behaviour differs (see 5.2). Import maps state names to codes. |
| H9 | Purchase numbering `PGST-0001-2025/26` | `PO-2026-000001` (the same number from draft to final) | Keep old numbers when importing. |
| H10 | Hold purchase (`Stock_Hold`) | An open document | Same idea. |

**Test vectors for the Hub:** U1, U2, U3 line amounts (hand check of U2 in the Hub engine: gross R(12000 x 3333, 1000) = 39996; discount R(39996 x 5000, 100000) = 2000; net 37996; CGST R(37996 x 18000, 200000) = 3420; total 44836 minor = 448.36; same as old) but only after H1 is closed; U4 to U9 after H1, H4 and H6 are decided.

### 7.6 Stock (status: DONE)

**What the Hub does** (`CatalogService.cs:89` to `109`, `DocumentService.MoveStock`, `DocumentService.cs:486`; table `stock_moves(item_id, qty_milli, reason, document_id, note, at, user_id)`):
- Stock is **one number per item**: `on hand = sum(qty_milli)` of its moves. An item keeps stock only when `track_stock` is on (set by the item, the industry's `StockTracking` rule "never / always / optional").
- Moves are added by: a sale (`-`, reason "sale"), a purchase receipt (`+`, "purchase"), a void (`+` or `-`), a credit note (`+`, "return"), and **`CatalogService.Adjust(item, delta, reason, note, user)`** for a count, damage or delivery (one signed number with a reason; the Items screen calls it, `Items.razor:416`). **The Hub has no separate adjustment document, no damage column, no transfer, no godown, no stock entry document.**
- Negative stock: `ShopSettings.AllowNegativeStock` is **true by default** (`ShopSettings.cs:23`); if the owner sets it to false a sale or a purchase void that would leave less than zero is refused with "Only N of X left". `Adjust` never checks.
- Low stock: `StockList(lowOnly)`: on hand at or below `reorder_milli` (an item field; the old `Product.MinStock`).
- Report: `StockValue` = on hand x `cost_minor` (half-up rounding of the product, `ReportService.cs:154`), only items with on hand more than 0.
- **No lots, no batch, no expiry, no MRP, no size or colour per lot, no serial numbers, no variants, no IMEI** (confirmed by the schema: `items`, `stock_moves`; the Hub map says the same). **No stock movement report by day; no opening-stock import** (the demo builder uses `Adjust(..., "opening stock")`).

**Where it differs from the old POS**

| # | Old POS | Hub | Verdict |
|---|---|---|---|
| T1 | Lot-level stock (`Temp_Stock` per barcode): price, MRP, batch, expiry, size, colour, IMEI per lot; sale picks a lot | Item-level stock; one price per item (per price level) | **Biggest gap for the owner's customers.** A lot table (`item_lots`) and lot-aware sale and purchase are needed; old data has real lots to import. |
| T2 | Expired lot cannot be sold | Not found | Needs lots with expiry. |
| T3 | Damage as a counter inside on-hand | Adjust with a reason | Better to keep the Hub's moves, with reason "damage" and a cost value. |
| T4 | Transfer token, branch transfer document, settlement, godown | None | Decision needed (online channel vs the shop-network model). |
| T5 | Stock entry document, adjustment document with ID and reason | One move with reason and note | Same facts; add a numbered adjustment document if auditors want one. |
| T6 | Movement report (opening, in, out, closing per day) | Not found (moves exist, report does not) | Easy to build from `stock_moves`: opening = sum before the day. Vector S11. |
| T7 | Stock value at `Product.CostPrice` x lot qty, and at sale price x qty | At `cost_minor` x on hand | Differences come from T1 (cost per lot) and the cost meaning (H3). |
| T8 | Serial numbers on touch tills, purchase, returns | None | **GAP** (needs a serial table; per-unit status in stock / sold / returned). |
| T9 | Negative stock allowed with a warning switch | Allowed by default; refused when turned off | Similar. |
| T10 | `StockMovement` can miss rows (2.3 step 6) | Every move is one row | Hub is right. |

**What the Hub does about cost (8 October 2026, decision 36, `StockCostTests`).** The owner chose **average cost per item**, so the Hub values stock without lots: every move of stock carries its value (`stock_moves.value_minor`), the average is value divided by quantity, a sale takes its quantity at the average of that moment (the last unit takes what is left), goods brought back return at the cost they left at (T3, T7, and the cost meaning of H3 are settled this way: the old cost per lot becomes the item's average; stock value in the report is the sum of the moves). **Lots, batches and expiry (T1, T2) are built as of 9 October 2026 (batches and expiry only; see `docs/OPEN-WORK.md` item 12r): the average cost stays per item and a move is shared among batches afterwards.** (Before that they were a gap; the cost of a lot-tracked item uses the same average.) Worked examples used as the Hub's tests: 10 at 100.00 then 10 at 120.00 hold 2,200.00 for 20 (average 110.00); selling 5 costs 550.00; 7 at 10.00 then 2 at 10.01 hold 90.02 for 9, selling 4 costs 40.01 (half-up of 40.0088) and the last 5 take the 50.01 that is left.

**Test vectors for the Hub** after T1 is decided: S1, S2, S4 to S6, S10 to S14, S15 to S17. Before T1: S2 (`Adjust` -12 on 10 gives -2), S11 (a movement report over `stock_moves`), S12 with `cost_minor`.

## 8. Porting notes (order and traps)

### 8.1 Order of work (smallest safe step first)

1. **Pin the money first.** Write the vectors of this file as `HubFixture` tests. Three groups: (a) vectors where old and Hub agree (list in 7.1, 7.3, 7.5): write them as ordinary passing tests; (b) vectors where they differ only at a half-paisa tie (L7, B3, the 5% on 0.20 example, R5): write them with the **Hub's** answer and a comment naming the old answer; (c) vectors that need a missing feature (bill discount, amount discount, mixed tax modes, cess, estimate, service): write them as the target for that feature, skipped **by name with a reason** until the feature exists (the gate refuses silent skips, so keep them out of the test run until built, or keep them as a list in `docs/OPEN-WORK.md`).
2. **Ask the owner once** (recorded in `docs/PLATFORM-DECISIONS.md` when answered): (a) rounding: keep the Hub's half-up (recommended) or copy the old half-to-even; (b) should a bill discount reduce tax (spread over lines before tax) or be taken off the total as the old POS did; (c) should an estimate show tax; (d) is a credit return a customer credit balance.
3. **Close the gaps in the money layer** in this order, each with its vectors: (i) line discount by amount and per-line tax mode and cess in `DocumentService.Calculate` (the engine already supports all three; only the document layer and the line columns are missing); (ii) bill-level discount; (iii) customer and supplier balance (opening balance, advance, receipts on account with allocation oldest first, credit notes that reduce what is owed); (iv) purchase: discount, freight, reverse charge, supplier credit limit, **purchase return**; (v) quotes and estimates and "convert to invoice" with `ref_document_id`; (vi) service job.
4. **Then stock:** lots first (`item_lots`: barcode, MRP, prices, batch, mfg, exp, size, colour, IMEI, cost per unit) with lot-aware sale, purchase, return and expiry block; then adjustment documents, damage as a move with a reason, the movement report (S11) over `stock_moves`, the opening-stock import (6.6), serial numbers; transfers last and only after the owner decides how stores talk to each other.
5. **Import last:** the data reader (merge plan step 1) uses the mapping traps below; **never recompute an old bill**: store it as it was saved (taxes, round-off, totals) and only compute new bills with the Hub's engine.

### 8.2 Traps when reading the old database

- **Names that mislead**: `InvoiceInfo.OtherCharges` is the **bill discount**; `InvoiceInfo.BillDiscount` is only the part the cashier typed; `InvoiceInfo.SubTotal` is taxable plus tax; `Stock.OtherCharges` is the purchase bill discount; `Product.ReorderPoint` is the **wholesale price**; `Product.MinStock` is the minimum stock; `Stock.ReferenceNo2` holds the reverse-charge flag; `Stock.TaxableAmt` and `Stock.SubTotal` are the same figure; service `GrandTotal` is net of the upfront; `SalesReturn.PaymentMode` is "Cash" or "Credit".
- **Text columns are padded** (`nchar`): the code trims everything with `RTRIM`. Trim on import, and compare trimmed.
- **Balances live in the ledgers** (`CustomerLedgerBook`, `SupplierLedgerBook`: credit minus debit), not on invoices: `InvoiceInfo.Balance` is stale after later receipts. Import ledger rows or computed balances; do not rebuild from invoices.
- **A deleted bill leaves nothing** (rows are physically deleted), so number gaps are normal; the last bill's number can be reused.
- **`StockMovement` is not reliable** (2.3 step 6, 6.1). Rebuild history from documents if needed; take **stock from `Temp_Stock`**.
- **Negative lots exist.** Import them as they are and report them in the match report.
- **Invoice numbers**: keep `InvoiceNo` text exactly; the Hub's own counter must continue from a number that cannot clash (its numbers look different, so no clash, but a shop may want the old look: E8).
- **Dates**: invoice dates are dates without time (`.Date`); payment rows carry their own date; the financial-year suffix is text.
- **State names** are free text in `Customer.State`, `Supplier.State`, `Company.State`; map them to the country pack's region codes and list the ones that do not match.
- **`PTax` and `STax` per product** decide Inclusive or Exclusive per item; the Hub has one flag per document, so import needs the per-item flag first (D5).
- **Payment mode names** are the 16 texts in 2.1 (plus "ByReturn" on touch tills, "Cash"/"Credit" on returns, "By Online Transfer" on supplier payments).
- **Trial-mode rules** (five vouchers a month) and `lblCPhone = "Trial"` are licence code; ignore them.

### 8.3 Behaviours not to carry over

Cloud transfers and the Firebase code, SMS and WhatsApp sends inside the save chain, text-keyed ledger deletes, the second read of `StockMovement`, the fixed `10` in settlement, the one-by-one estimate conversion, `ModFunc` global connection objects (`ModCommonClasses.con`, `cmd`, `rdr` are shared across screens), per-statement connections without a transaction.

### 8.4 Where each piece of the old logic should live in the Hub (a suggestion)

Tax and totals stay in `NextGenOS.Tax` (add nothing there unless a rule is wrong); document rules in `DocumentService`; lots, stock documents and the movement report in `CatalogService` or a new `StockService`; balances in a new `LedgerService` over `payments` plus a new `party_balances` side table (new tables need `tenant_id`, `site_id`, a rollback file and a test; see the Hub map).

## 9. Not understood (honest list)

**About this file**
- **Every example is worked by hand from the code. None was run** (the old program cannot be built or run here, and no old database was available). Floating-point effects (the old program uses `double`, this file uses exact decimals) were reasoned about only at the half-paisa ties flagged above.
- The till screens were compared by extracting and comparing `Calc`, `Compute` and `GridCalc` (identical rules in `frmPOS`, `frmPOSNew`, `frmPOSNewTuch`, `frmPOSTouch`). The **save, hold, edit and delete code was read line by line only in `frmPOS.vb`**; for the touch tills I confirmed by search that the same SQL and ledger calls exist (and found the extra `ByReturn`, serial-number and loyalty-per-line code) but did not read their save handlers line by line.
- Decompiled code can lose or reshape `If/Else` blocks. The one place where it matters here: the second `rdr.Read()` before the `StockMovement` insert on a sale (2.3 step 6, 6.1). In stock adjustment the same job came out as a proper `If ... Else`, so the sale code may be a recovery artefact. A real database would show whether sales produce movement rows.

**Selling**
- **What `CustomerOffer.DiscPerc` holds** (percent or amount) and **which screen creates a bill offer**: the till adds the value as an amount (`frmPOS.vb:16479`); `frmCustomerOffer` is a customer sales report; the form that writes the offers (possibly `frmPromotionalOffers` or `fromItemoffervalid`) was not read. Item offers (`Offer2.DiscPerc` by product and date) and free-quantity promotions (`Promotion`) were read only where the till uses them.
- Loyalty points (rate `txtLpoint`, "calculate on", `LPoint` table, `Company.Loyality_perpoint`), coupons, gift cards (`giftstatus`, `giftamtsave`), and customer discount (`Customer.DiscPer`, `CustDiscApply`) were read only for how they enter the bill discount and the saved columns.
- **TCS** (tax collected at source: `tcsconn`, `TCSValid`, `TCSPer`) and the **e-way bill** were not worked through.
- **Broker (agent) commission** (`BrokerCalc`, `BrokerLdr`) formulas are in `frmPOS.vb:18943` (percent of `grand - tax` or of `grand`, or a typed amount) but the saved rows and reports were not checked.
- Hardware: customer display, weighing scale (`ReadWeightPORT`), cash drawer, KOT (`PrintKOT`), UPI QR, WhatsApp and SMS sends.
- **`Tender`/`Refund`/`BillCash` for a mixed bill**: `BillAmt` is the sum of "By Cash" rows only (2.1 item 5); what the till shows for `Tender` when the cashier uses only cards was not checked.
- The default **invoice suffix** (`F1/F2`) assumes the company's financial-year dates are text in `dd/MM/yyyy` form; the real stored format was not seen.
- `Invcode` columns: known `Code`, `c1`, `c2`, `c4`, `c10`, `c11`, `c12`, `c14`, `c20`, `c21` roles from the screens above; the other columns (`c3`, `c5` to `c9`, `c13`, `c15` to `c19`) were not read (probably the other document types).
- `InvTemp` and `InvTempEst` (settings that hold a text `c1` per ID), `txtTempQty` (grid column 20) and the `b0` to `b9` variables of the till: purpose not traced.
- Which user may edit or delete a saved bill (the `UserControl` table, `UserControlSettings`): not read.
- **`By Return` on the touch till**: that `ByReturn` is excluded from `TotalPayment` was concluded from a search (it is not in the list of paid modes); `SalePOS_DGrandTotal`, called by the touch `Compute`, was not found in `frmPOSTouch.vb`.
- `frmRefundAmt` (reads `Journal`): a voucher screen for refunds of money to customers or suppliers; not studied.
- `frmMRP_Purchase_Update`, `frmMRPShow`, `frmMRPShow_Serial`: lot pickers over earlier purchases (MRP, rates, barcode, colour, size); their role in the sale was not traced.

**Buying and stock**
- **Who sets the barcode of a new lot** on the purchase screen: picking a product fills `Product.Barcode` (5.2); `GenerateBarcode` makes `1000 + next Product_OpeningStock.ID` into `tempbarcode`, which is not used anywhere in `frmPurchaseEntry.vb`.
- **Purchase order to purchase**: `frmPurcOrderRetrieve` loads lines; no code marks the order as received (5.6).
- `Stock_Hold` and `Stock_Product_Hold` (purchase hold): mirrored from the sale hold; not read line by line.
- **Variants**: `Variant_id`, `Temp_product`, `frmProductRec_variant` (6.8) were only seen from the purchase screen.
- **Transfers between branches**: the exact channel (`ExtDB`, `ExtDB1`, `ExtDB2`, the cloud storage configured in `frmGodownConfig`, `Inward_StockOnline`, `updatetoOffline`), how `Branch_Relation` is filled, and the check "Value not matched in local and online" in the touch transfer save were not traced. The status codes in 6.5 are as seen in the update statements.
- `Estimate.KP` (only the value "P" was seen), and `Estimate.CType` use.
- **Product master and tax setup screens** (`frmProduct`, `frmTaxSetting`, `Setting`, `Defaulttaxtype`, `TaxCat`, `BillSundry` types other than TCS, `cmbBSundry`) were not studied in this file (see `docs/old-programs/02-masters-accounting-reports.md` if it covers them).
- The report screens beyond stock movement, stock in and out, and current stock (sales, purchase, GST registers, ledgers) were not read here.

**The Hub**
- I read the Hub's code, did not run it. Two behaviours must be tested before anyone relies on them: (1) a credit note on an unpaid credit sale appears not to reduce the customer's outstanding (`Outstanding` counts invoices only); (2) a credit note seems to follow the shop's round-total setting although a code comment says it never rounds.
- `AllowNegativeStock` default true (`ShopSettings.cs:23`) was read from the settings class; whether the set-up wizard or the industry pack changes it was not checked.

