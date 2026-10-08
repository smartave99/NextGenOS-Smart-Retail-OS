# Old POS study 03: India tax and compliance, and staff and salespeople

Status: every topic below is written (A1 to A7, B1 to B3, C); what was not understood or not read is listed in C.4. This is a reading study: nothing was built, run or tested.

Source studied: `apps/pos-desktop/Source/SmartAvenue99_POS_VB/SmartAvenue99 POS/BillPoint/` (the recovered VB.NET program; every "file:line" below is a file in that folder unless a path is given). The owner's own program (`CLAUDE.md` section 1).

## What to know first

1. **The old POS does all money in `Double` with VB `Math.Round`, which is half to even**; the Hub uses whole numbers and half up. For tax-**exclusive** prices they agree except at exact half paise (0.5% to 1.3% of small prices); for tax-**inclusive** prices they differ by a paisa or two in taxable and tax in **about half of all prices** (the line total is the same). Details and the sweep: A1.3, A1.7.
2. GST in the old POS is per product: a `CGST` and an `SGST` percent (half the rate each, kept to 2 decimals, so 0.25% breaks), a cess percent, and a per-line mode Inclusive, Exclusive, Exempt GST or No Taxes. IGST replaces CGST and SGST when the customer's state **name** differs from the company's; an empty customer state counts as the same state. A shop-wide GST or NON GST flag switches all tax off. The bill discount comes off **after** tax and does not change tax. Inclusive prices with cess are computed wrongly. (A1, A7)
3. GSTR-1 (B2B, B2CL, B2CS, CDNR, CDNUR, HSN), GSTR-3B and the registers are **read-only Excel-style lists**, with the B2CL limit fixed at 2,50,000, no portal file, no debit notes, no document summary, and 3B has no input-credit or payable maths. A purchase-return register repeats a return once per line. (A2 to A4)
4. TCS is one dated rule row (limit, rate with PAN, rate without PAN): `rate x (customer turnover incl. GST in the period + this bill - limit) - TCS already collected`; the result is only a label and the cashier types it as a bill sundry named TCS, stored as `FreightCharges`. Treat as data, off by default (the legal basis was withdrawn from 1 October 2024; outside knowledge). (A6)
5. E-way bill goes through a paid third-party web service typed in by the owner (URL, user, password kept in plain text in the database); no "when needed" rule exists; the request has a wrong pincode source; a failed try blocks a retry; update and extend are empty buttons. The recovered GSTIN validator is an empty stub; the GSTIN lookup scrapes a public web page. (A5, A7)
6. Salesman commission has **two methods** (invoice-level percent from the master; line-level percent per stock batch with a ledger, touch till only); a part return reverses the whole line's commission. Broker commission is a percent or amount on the grand total with or without tax, no balance. Payroll is `salary x present days / 30`, overtime from time spans, advance repayment as the only deduction, no statutory payroll. (B1 to B3)
7. **The Hub has none of it** except the engine and `TaxSummary`: no cess input, HSN, fixed or bill discount, reverse charge, TCS, e-way, GST returns, registers, or any staff, salesman, broker or payroll data. `parties.tax_id` and `region` exist. (C.1)
8. India rules must go into `country-packs/packs/IN.json` and an India module loaded only for `gst-india` (`CLAUDE.md` section 8); the old state **names** must be mapped to state codes; old stored tax amounts must be imported as stored, never recomputed. (C.3)
9. About 150 worked examples are in the tables (E1 to E11, I1 to I10, D1 to D2, B1 to B9 for GST lines and bills; G1 to G12, T1 to T14, R1 to R11, W1 to W11, X1 to X11, S1 to S15 for returns, registers, e-way, TCS and masters; M1 to M8, L1 to L7, K1 to K11, P1 to P18 for commission, brokers and payroll). Rows marked (H) sit on an exact half and were worked with 64-bit doubles: confirm on a real Windows PC.
10. Not run, not built, nothing tested on Windows: this is a reading study. Gaps (report layouts, database scripts, compiled libraries) are in C.4. Decisions the port needs are in C.2.

## Topic list and state

| # | Topic | State |
|---|---|---|
| A1 | GST calculation on sales and purchases (line level, inclusive and exclusive, CGST/SGST/IGST by state, cess, round-off) | written, saved |
| A2 | GSTR-1 and the HSN list | written, saved |
| A3 | GSTR-3B | written, saved |
| A4 | GST registers (sale, purchase, sale return, purchase return) | written, saved |
| A5 | E-way bill | written, saved |
| A6 | TCS | written, saved |
| A7 | Tax categories, default tax type, state master, GSTIN rules | written, saved |
| B1 | Salesman master, commission, ledger, payments | written, saved |
| B2 | Broker, transport and route | written, saved |
| B3 | Employees, attendance, salary slips, advances, employee payments | written, saved |
| C | What the Hub has today, porting notes, not understood | written, saved |

## A1. GST calculation on sales and purchases

### A1.1 What a person sees

At the till (`frmPOSNew`, and the same arithmetic in `frmPOS`, `frmPOSNewTuch`, `frmPOSTouch`, `frmPOSNewTuch_Service`, `frmPOSNewTuch_Quotation`: the `Calc` routines were compared and the tax part is identical; the touch forms only add loyalty-point lines) the cashier picks a product by barcode. The line shows: quantity, rate, discount % and discount amount, CGST %, CGST amount, SGST %, SGST amount, IGST %, IGST amount, CESS %, CESS amount, and "Total Amount". Under the grid are bill boxes: Sub Total, CGST, SGST, IGST, CESS, Freight (bill sundry), Bill Discount, Total, Round Off, Grand Total, Payment, Due. The shop owner chooses once, in "Tax Type" (`frmTaxSetting`), whether the shop sells under "GST" or "NON GST", and likewise for purchases. Each product carries its own "Sales tax" and "Purchase tax" mode: Inclusive, Exclusive, Exempt GST or No Taxes (`frmProduct.Designer.vb:752,760`).

### A1.2 Tables and columns

Read: `Setting(SalesTax, PurchaseTax)` (one row, values `GST` or `NON GST`; `frmPOSNew.vb:8438`), `Company(State, GSTIN, ...)` (`:8520`), `Customer(State, GSTIN, PAN, Tcs, ...)`, `Supplier(State, ...)`, `Product(HSNCode, CGST, SGST, CESS, STax, PTax)` and `Temp_Stock` (batch stock rows) (`:13347`), `TaxCat(ID, Rate, IsDefault)` (list of allowed GST rates), `Autoroundoff(c1)` (Yes or No), `tbl_state`.

Written for a sale (`frmPOSNew.vb:10693-10832`):
- `InvoiceInfo`: `TaxType` = `GST` or `NON GST` (not Inclusive/Exclusive), `SubTotal` = sum of line (taxable + CGST + SGST + IGST + CESS) i.e. line totals with tax, `TaxableAmt` = sum of line taxable, `CGST SGST IGST CESS` = sums of line amounts, `FreightCharges` = bill-sundry amount (this is also where TCS goes, with `BillSundry = 'TCS'`), `OtherCharges` = the bill discount (the register headings call these "Bill Sundry Charges" and "Total Bill Discount"), `Total`, `RoundOff`, `GrandTotal`, `TCSPer`, `Eway`, `CType` (Retail or Wholesale), `SalesmanID`.
- `Invoice_Product` (one row per line): `Qty, SalesRate, DiscountPer, Discount, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, TotalAmount, TaxableAmt, STaxType` (the line's Inclusive/Exclusive/Exempt GST/No Taxes), `PurchaseRate, Margin, MRP, ...`.
- Purchase (`frmPurchaseEntry.vb:11414-11455`): `Stock` (header: `SubTotal` = sum of taxable, `PreviousDue`, `FreightCharges`, `OtherCharges`, `Total`, `RoundOff`, `GrandTotal`, `TaxType` = `GST`/`NON GST`, **`ReferenceNo2` = the "Reverse charge" box (Yes or No)**, `CGST SGST IGST CESS`, `TaxableAmt`) and `Stock_Product` (`CGSTPer/Amt`, `SGSTPer/Amt`, `IGSTPer/Amt`, `CESSPer/Amt`, `TaxableAmt`, `PTaxType`).
- Returns: `SalesReturn`/`SalesReturn_Join` (`frmSalesReturn.vb:3152,3174`) and `PurchaseReturn`/`PurchaseReturn_Join` (`frmPurchaseReturn.vb:3280,3304`, with an `RCM` column).
- Two small tables mark which kind of invoice was made: `SaleGST(ID, InvNo)` and `SaleNoTax`, `PurcGST` (`:11077,11089`; `frmPurchaseEntry.vb:11526`); they are used to number the next GST or non-GST invoice.

### A1.3 Rules and formulas, step by step

All arithmetic is **floating point (`Double`) on text-box values read with `Conversion.Val`**, and every rounding is VB `Math.Round(x, 2)`, which in .NET Framework is **round half to even on the value multiplied by 100** (scale, round half even, unscale), not "half up". `Strings.Format(x, "0.00")` only formats.

Line (sale: `frmPOSNew.vb:12674-12880`; purchase: `frmPurchaseEntry.vb:7411-7630`, same steps with the product's purchase mode and the purchase price; sale return `frmSalesReturn.vb:2685-2738`; purchase return `frmPurchaseReturn.vb:2098-`):
1. **Which path.** If the shop's sales tax is `GST` (or empty) the GST path is used, else `NON GST` (`:12676`, `:12835`). NON GST: all rates forced to 0.00, total = value less discount (`:12854-12873`).
2. `gross = Round(qty * rate, 2)` (`:12682`).
3. **Discount** (`:12684-12686`): if the discount type is percent: `disc = Round(gross * disc% / 100, 2)`; if the cashier typed an amount: `disc% = Round(disc * 100 / gross, 4)` (the amount is kept as typed; the percent is only for display). `net = gross - disc` (not rounded, `:12697`).
4. **Which rates apply (decided when the product is picked, `frmPOSNew.vb:13418-13441`).** The product master holds two rates, `Product.CGST` and `Product.SGST` (each half of the GST rate; the product screen sets `CGST = Round(rate/2, 2)` and `SGST = CGST` from the chosen `TaxCat` rate, `frmProduct.vb:5851`). Customer state box empty, or equal (text, case-sensitive) to the company state: intra-state: `CGSTPer = Product.CGST`, `SGSTPer = Product.SGST`, `IGSTPer = 0`. Different state: `CGSTPer = SGSTPer = 0`, `IGSTPer = Product.CGST + Product.SGST`. The cess rate is `Product.CESS` in both cases. The state is **compared by name, not by the first two digits of the GSTIN**. Purchases use the same rule with the supplier state (`frmPurchaseEntry.vb:8443-8455`). There is no handler that re-works lines already on the bill when the customer is changed (`cmbCustomerState` has only a key-down handler), so a line keeps the split it was added with.
5. **Exclusive** (`:12678-12714`): `CGST = Round(net * CGSTPer / 100, 2)`; the same for SGST, IGST and CESS (each on `net`, each rounded on its own); `lineTotal = Round(net + CGST + SGST + IGST + CESS, 2)`. `taxable = Round(qty * rate - disc, 2)` (`TaxableAmt`, `:12883-12892`).
6. **Inclusive** (`:12796-12832`): `t = Round(net - net / (1 + (CGSTPer + SGSTPer)/100), 2)`; `CGST = Round(t / 2, 2)`; **`SGST` is computed the same way, so `SGST = CGST`** (the two are always equal); `IGST = Round(net - net / (1 + IGSTPer/100), 2)`; **`CESS = Round(net - net / (1 + CESSPer/100), 2)`** (taken out of the whole price on its own, see quirks); `lineTotal = Round(net, 2)`; `taxable = qty * rate - disc - (CGST + SGST + IGST + CESS)` (amounts as the 2-decimal text, `:12888`). The line is therefore internally consistent (taxable + taxes = price) but the tax is not always the rate times the taxable.
7. **Exempt GST** (`:12715-12754`): CGST, SGST and IGST percents are set to 0.00 and the exclusive arithmetic runs; **the cess percent is not cleared**, so a product with cess and mode Exempt GST still charges cess. **No Taxes** (`:12755-12795`): all four percents set to 0.00.
8. **Bill** (`Compute`, `:12508-12530`; `GridCalc` `:12533-12564`): `CGST = Round(sum of line CGST, 2)` (the same for SGST, IGST, CESS and for taxable = `TextBox11`); `Total = Round(taxableSum + CGST + SGST + IGST + CESS + Freight - BillDiscount, 2)`; **if the auto round-off tick is on** (`Autoroundoff` table, `:9069`): `RoundOff = Round(Round(Total, 0) - Total, 2)` where `Round(Total, 0)` is half-to-even; else 0; `GrandTotal = Round(Total + RoundOff, 2)`. **The bill discount is taken off after the tax is added** (it does not reduce the taxable value or the tax; see quirks).
9. **Purchase bill** (`frmPurchaseEntry.vb:6701-6750`): if "Reverse charge" = No: `Total = Round(taxableSum + Freight - Other + PreviousDue + CGST + SGST + IGST + CESS, 2)`; if Yes: the same without the four tax amounts (the buyer pays the tax himself). The previous supplier due is **added into the bill total** (see quirks). Round-off as for sales. Purchase return `Compute` (`frmPurchaseReturn.vb:1753`) has the same Yes/No reverse switch (without the previous due).
10. **Sales return** (`frmSalesReturn.vb:2685-2738`): rates are those of the original bill line; `Exclusive/Exempt/No Taxes` use the exclusive arithmetic on `returnQty * rate` less the discount at the original discount %; `Inclusive` uses the inclusive arithmetic but **leaves `CGST = t/2` and `SGST = t/2` unrounded** (7.625 stays 7.625 in the box, `:2722,2725`); the bill sums are rounded once at the end (`GridCalc` `:2672`) and SQL stores them into `decimal(18,2)`. The return line's taxable value is the original line's stored taxable pro rata: `Round(origTaxable / origQty * returnQty, 2)` (`:1956`).

### A1.4 Flow

Pick customer (state is mandatory: `btnAdd_Click` refuses without it, `:9947`) -> scan or pick product (rates and mode loaded, `Calc`) -> Add (line goes to the grid, bill totals recomputed by `Compute`) -> optional bill discount, freight/TCS bill sundry -> payment -> Save (`btnSave_Click_1`, `:10476`): one set of INSERTs for `InvoiceInfo`, `Invoice_Product`, `Invoice_Payment`, stock decrease, ledger entries (`ModFunc.LedgerSave`), loyalty, salesman commission, broker ledger. Nothing is re-derived on save: whatever the grid and the boxes hold is stored.

### A1.5 Quirks and probable bugs

| # | Quirk | Verdict |
|---|---|---|
| 1 | Rounding is half to even on doubles, not half up. Exact halves go to the even cent (7.625 becomes 7.62; 100.50 round-off goes to 100) | Do not copy. The Hub's half up is the legal norm; goldens below show both. |
| 2 | Inclusive CGST and SGST are always equal and each is half of an already rounded total: for 99.99 at 18% the old POS has 7.62 + 7.62 = 15.24 tax and taxable 84.75; the Hub has 7.63 + 7.62 = 15.25 and taxable 84.74 | Fix (use the Hub's). The old figure leaves the tax one paisa low and the taxable one paisa high. |
| 3 | **Inclusive with cess:** GST and cess are each cut out of the *whole* price separately. For 1400.00 at 28% + 12% cess the old POS gives CGST 153.12, SGST 153.12, cess 150.00, taxable 943.76; the correct (and the Hub's) answer is taxable 1000.00, CGST 140, SGST 140, cess 120 | Fix (use the Hub's). Cess is rare since 22 September 2025. |
| 4 | Bill discount comes off the grand total after tax; it does not lower the taxable value or the tax (a trade discount should) | Fix? Needs a decision: apportion over lines, or document as "post-tax discount". Not changed here. |
| 5 | `Exempt GST` mode keeps the cess percent | Fix (no tax of any kind on an exempt line). |
| 6 | Product CGST = Round(rate/2, 2): a 0.25% rate becomes 0.12 + 0.12 = 0.24, and IGST (= CGST + SGST) = 0.24 | Fix in the port: keep the rate as one number with three decimals. |
| 7 | Intra/inter-state is decided by comparing state names typed in two places; empty customer state counts as the same state; the GSTIN's own state code is never checked | Keep the empty = intra rule only as an option; use the GSTIN code and the pack's state list. |
| 8 | Purchase total adds `PreviousDue` into the bill `Total` and `GrandTotal` | Fix? The supplier balance is not part of the purchase value; the Hub never does this. |
| 9 | Customer change after lines were added does not re-rate the lines | Fix in the port: re-run the engine with the new buyer region on every change (the Hub does). |
| 10 | Doubles: results at an exact half (x.xx5) depend on how the binary value falls; the 32-bit program may use extended precision in places | Goldens that sit on an exact half are marked (H). |

### A1.6 Test vectors (worked from the code; each row is a golden)

How they were worked: the arithmetic above was run step by step with IEEE double numbers exactly as the code does (scale by 100, round half to even, unscale). "Old" is the old POS, "Hub" is `NextGenOS.Tax` with the India pack (`pricesIncludeTax` true or false as marked). Amounts in rupees. Intra-state means customer state equals the shop state (CGST + SGST). All lines have no discount unless stated.

Line, **exclusive prices**:

| # | Input | Old POS result | Hub result | Same? |
|---|---|---|---|---|
| E1 | 1 x 100.00, 18% (9+9) | taxable 100.00, CGST 9.00, SGST 9.00, total 118.00 | same | yes |
| E2 | 3 x 33.33, 5% (2.5+2.5) | gross 99.99, CGST 2.50, SGST 2.50, total 104.99 | same | yes |
| E3 | 1 x 0.30, 18% | CGST 0.03, SGST 0.03, total 0.36 | same | yes |
| E4 | 1 x 199.50, 10% discount, 12% (6+6) | disc 19.95, taxable 179.55, CGST 10.77, SGST 10.77, total 201.09 | same | yes |
| E5 | 1 x 1000.00, 18%, other state | IGST 180.00, total 1180.00 | same | yes |
| E6 | 1 x 1000.00, 28% (14+14) + cess 12% | CGST 140.00, SGST 140.00, cess 120.00, total 1400.00 | same (if the Hub were given cess) | yes |
| E7 (H) | 1 x 0.20, 5% (2.5+2.5) | `0.20 x 2.5 / 100 = 0.005` rounds half to even to 0.00: CGST 0.00, SGST 0.00, total 0.20 | CGST 0.01, SGST 0.01, total 0.22 | **no** |
| E8 (H) | 1 x 1.00, 5% (2.5+2.5) | `0.025` rounds to 0.02: CGST 0.02, SGST 0.02, total 1.04 | CGST 0.03, SGST 0.03, total 1.06 | **no** (the exact tax is 0.05; each engine is 0.01 off on its own side) |
| E9 | 1 x 1.00, 5%, other state | IGST 0.05, total 1.05 | same | yes |
| E10 | 3 x 10.30, 12% (6+6) | gross 30.90, CGST 1.85, SGST 1.85, total 34.60 | same | yes |
| E11 | 1 x 25.00, 5% discount, 18% (9+9) | disc 1.25, taxable 23.75, CGST 2.14, SGST 2.14, total 28.03 | same | yes |
| D1 | 1 x 99.99, 10.5% discount, 18% (9+9) | disc 10.50, taxable 89.49, CGST 8.05, SGST 8.05, total 105.59 | same | yes |
| D2 (H) | 1 x 25.00, 0.5% discount, 5% inclusive | `25 x 0.5 / 100 = 0.125` becomes **0.12** (even), net 24.88, taxable 23.70, CGST 0.59, SGST 0.59, total 24.88 | discount **0.13**, net 24.87, taxable 23.69, CGST 0.59, SGST 0.59, total 24.87 | **no** (the discount itself differs) |

Line, **inclusive prices**:

| # | Input | Old POS result | Hub result | Same? |
|---|---|---|---|---|
| I1 | 1 x 118.00, 18% | taxable 100.00, CGST 9.00, SGST 9.00 | same | yes |
| I2 (H) | 1 x 99.99, 18% | taxable 84.75, CGST 7.62, SGST 7.62 (tax 15.24) | taxable 84.74, CGST 7.63, SGST 7.62 (tax 15.25) | **no** |
| I3 (H) | 1 x 1.00, 5% | taxable 0.96, CGST 0.02, SGST 0.02 | taxable 0.95, CGST 0.03, SGST 0.02 | **no** |
| I4 (H) | 2.5 x 45.50, 10% discount, 5% | gross 113.75, disc 11.38, taxable 97.49, CGST 2.44, SGST 2.44, total 102.37 | taxable 97.50, CGST 2.44, SGST 2.43, total 102.37 | **no** |
| I5 | 1 x 1180.00, 18%, other state | taxable 1000.00, IGST 180.00 | same | yes |
| I6 | 1 x 1400.00, 28% + cess 12% | taxable 943.76, CGST 153.12, SGST 153.12, cess 150.00 | taxable 1000.00, CGST 140.00, SGST 140.00, cess 120.00 | **no** (old is wrong) |
| I7 | 3 x 33.33, 5% | taxable 95.23, CGST 2.38, SGST 2.38 | same | yes |
| I8 (H) | 1 x 250.00, 12% (6+6) | taxable 223.20, CGST 13.40, SGST 13.40 | taxable 223.21, CGST 13.40, SGST 13.39 | **no** |
| I9 | 1 x 10.00, 5% | taxable 9.52, CGST 0.24, SGST 0.24 | same | yes |
| I10 (H) | 1 x 55.00, 18% | taxable 46.60, CGST 4.20, SGST 4.20 | taxable 46.61, CGST 4.20, SGST 4.19 | **no** |

(H) = the old result depends on an exact half cent (for I2 the half is 7.625, which is exact in binary, so 7.62 is certain; for the others the half falls where the binary value puts it and was worked with SSE2 doubles). The Hub's own cases for I1, I2, I3, I4 ("weight and percent discount"), I5 ("inter-state included becomes IGST"), E1, E2, E5 and E6 are in `country-packs/vectors/tax-vectors.json`; I6 is the vector "old 28% rate with 12% cess, included".

Bill level (`Compute`, auto round-off on, `Math.Round(x, 0)` half to even):

| # | Input | Old POS | Hub (round to rupee, half up) |
|---|---|---|---|
| B1 | Taxable 1000.00, CGST 90.00, SGST 90.00, freight 0, discount 0 | Total 1180.00, round-off 0.00, grand 1180.00 | same |
| B2 | Same but Total 1050.47 | round-off -0.47, grand 1050.00 | same (vector "five-line grocery bill") |
| B3 | Total 100.50 | `Round(100.50, 0) = 100` so round-off -0.50, grand 100.00 | 101.00 (round-off +0.50) **differs** |
| B4 | Total 101.50 | `Round = 102`, round-off +0.50, grand 102.00 | 102.00 same |
| B5 | Total 0.50 | round-off -0.50, grand 0.00 | 1.00 **differs** |
| B6 | Taxable 1000.00, 18% (180.00), bill discount 50.00 | Total 1130.00 (tax stays 180.00) | the Hub has no bill-level discount |
| B7 | Taxable 1000.00, 18% (180.00), freight 20.00 | Total 1200.00 (freight is not taxed) | an untaxed "fee" adjustment gives the same 1200.00 |
| B8 | Purchase, taxable 5000.00, CGST 450.00, SGST 450.00, previous due 2000.00, reverse charge No | Total 7900.00 (the 2000.00 due is inside) | purchase total 5900.00 (no previous due) **differs** |
| B9 | Purchase, taxable 5000.00, 18% IGST 900.00, reverse charge Yes | Total 5000.00 (tax not added) | no reverse charge anywhere in `apps/business-hub/src` (searched); it would show 5900.00 |

### A1.7 What the Hub has today (compare)

`NextGenOS.Tax` (`libs/dotnet/NextGenOS.Tax/TaxEngine.cs`) works in integer minor units with half-up rounding, takes the rate from the pack (`GST0, GST5, GST18, GST40, GSTEX`, legacy `GST12, GST28`), decides CGST+SGST or IGST from `sellerRegion` and `buyerRegion` (two-digit state codes in the pack), splits an inclusive tax as CGST = half rounded up and SGST = the rest, and an exclusive tax as two equal halves. Per `docs/old-programs/06-hub-map.md` section 4.2 the Hub never passes cess, has no HSN on a line, no fixed-amount line discount and no bill discount, one include-tax switch per document, and rounds the total only when the shop turned it on. **Equal to the old POS:** exclusive lines (E1 to E6 as the Hub computes them), inter-state lines, inclusive lines where the tax splits evenly (I1, I5, I7, I9), line totals. **Different:** inclusive lines with an odd paisa of tax (I2, I3, I4, I8, I10: the Hub is one paisa different in taxable and in the CGST/SGST split, and is the legally better answer), inclusive with cess (I6: old wrong), round-off at an exact half (B3, B5), purchase total with previous due (B8), reverse charge (B9). **How often it differs (a sweep run for this study, double arithmetic exactly as the old code, against the Hub's integer algorithm; one unit per line, no discount):** for **tax-inclusive** prices from 1.00 to 1000.00 in steps of 0.01 (99,901 prices) the taxable value and the total tax differ in **about half of all prices** at every rate (5%: 50.0%, 12%: 50.9%, 18%: 50.0%, 28%: 50.3%), by one paisa (two paise at most, at 12% and 28%), and CGST differs in about a quarter and SGST in about a quarter. The cause is A1.3 step 6: the old POS halves an already rounded tax and rounds each half to even, so an odd paisa of tax is lost or gained. For **tax-exclusive** prices from 0.01 to 200.00 the old and Hub results differ in 0.5% to 1.3% of prices (18%: 0.51%, 12%: 1.00%, 28%: 1.00%, 5%: 1.26%), only where a half-tax lands exactly on half a paisa (E7, E8). The line **total** of an inclusive line is always the same (it is the price). So **a Hub that must reproduce old bills to the paisa cannot use its present engine for inclusive prices**; one that only needs correct tax can, and the Hub's answer is the legally cleaner one (A1.5 quirk 2). This needs an owner decision (see C.2).

**Hub now (8 October 2026, slice 1 of the India work).** Built: the extra tax (cess) per item and the item code (HSN or SAC) per item and per bill line, named by the country pack (`tax.itemCode`, `tax.extraTax`, `country-packs/SPEC.md` section 4a), so only a country that has them shows them; the line keeps a copy when it is made; the engine gets the extra tax as the line's `cessPercent` (E6 and I6 are tests: exclusive 1,400.00 and inclusive 1,400.00 at 28% with 12% extra tax give CGST 140, SGST 140, extra tax 120, taxable 1,000); the screen bill and the paper bill print the code and the extra tax under the pack's words; goods taken back, a bill made from a quote and free goods keep both. The fixed discount and the bill discount were built earlier (decision 33). Still missing: per-line Inclusive or Exclusive mode on one bill (the Hub has one switch per document; Exempt and No Taxes are the rate codes `GSTEX` and `GST0`), reverse charge on purchases, the buyer's tax number and state kept on the bill, the registers, GSTR-1 and GSTR-3B, TCS, e-way bill.

**Missing in the Hub:** cess input, HSN, fixed discount, bill discount, Exempt/No Taxes per-line modes (the Hub has a rate code instead), state mandatory rule, reverse charge, "NON GST" shop mode (the Hub's `registered = false` gives zero tax, which is the same idea).

## A2. GSTR-1 and the HSN list

Files: `frmGSTR1.vb` (screen "GSTR-1", 6 tabs) and `frmGSTR1_HSNC.vb` (the "HSN summary" screen). Neither makes a government-portal file: the only output is a grid and an **Excel export** (ClosedXML, "Export File" sheet; `frmGSTR1.vb:1131-1186` and the same block for each tab, `frmGSTR1_HSNC.vb:504-581`).

### A2.1 What a person sees

GSTR-1: a "from" date (filled with the company's financial-year start, `fyear`, `frmGSTR1.vb:988`) and a "to" date (today), a "Get Data" button and six tabs: **B2B, B2CL, B2CS, CDNR, CDNUR, HSN**, each a grid with its own "export to Excel" link. HSN summary: dates, an optional GST % filter (`TextBox1`) and an optional HSN-code filter (`TextBox2`), a grid and total labels (Total Qty, Total Taxable Value, IGST, CGST, SGST, Cess; `Calculate`, `:584-664`).

### A2.2 Tables read (nothing is written)

`InvoiceInfo`, `Customer`, `Salesman` (joined but unused), `SalesReturn`, `Invoice_Product`, `Product`, `Company(FYFrom, FYTo)`. All are plain SELECTs, parameterised on the dates. There is **no GSTR-1 table, no filing status, no document summary (Table 13), no nil/exempt/non-GST summary (Table 8), no purchase side**.

### A2.3 The rules (the full SQL is in the code; these are the filters that matter)

All six lists exclude invoices whose `InvoiceInfo.TaxType = 'NON GST'` (an invoice-level flag, see A1.2). Dates: `InvoiceDate BETWEEN @d1 AND @d2`, the picker's date part; invoices are stored with a date only, so the last day is included.

| Tab | Rows | Filter (source line) | Columns |
|---|---|---|---|
| B2B | one per invoice | customer GSTIN present: `RTRIM(Customer.GSTIN) > ''` (`frmGSTR1.vb:1046`) | Invoice No., Invoice Date, Tax Type, Customer Name, State, GSTIN, Taxable Amount, CGST, SGST/UTGST, IGST, CESS, Bill Sundry Charges (= `FreightCharges`), Total Bill Discount (= `OtherCharges`), Total, Round Off, Grand Total |
| B2CL | one per invoice | no GSTIN **and `GrandTotal >= 250000`** (`:1067`); **no check that the sale is between states** | same 16 columns |
| B2CS | one per invoice | no GSTIN **and `GrandTotal < 250000`** (`:1101`) | same 16 columns (an invoice list, not the portal's rate-wise summary) |
| CDNR | one per sales return | `SalesReturn` joined to its invoice and customer; customer has GSTIN; filtered on **the return's date** (`:1193`) | Sale Return No., Sale Return Date, Tax Type, Sales Invoice No., Sales Date, Customer Name, Customer State, Customer GSTIN, Taxable Amount (= `SalesReturn.SubTotal`, see quirks), CGST, SGST/UTGST, IGST, CESS, Bill Sundry Charges, Total Bill Discount, Total, Round Off, Grand Total |
| CDNUR | one per sales return | same, customer has **no** GSTIN (`:1213`); any amount | same as CDNR |
| HSN | one per **invoice line** | product has an HSN code (`HSNCode > ''`) (`:1259`) | HSN Code, Invoice No., Invoice Date, Tax Type, Customer Name, State, GSTIN/UID, Product Name, Sales Rate (= `(line TaxableAmt + line Discount) / Qty`), Qty., UOM, Discount %, Discount, CGST %, CGST, SGST %, SGST/UTGST, IGST %, IGST, CESS %, CESS, Total Amount |

HSN summary screen (`frmGSTR1_HSNC.vb:387`): one row per **(invoice date, HSN, product name, unit, GST %)** with `SUM(Qty)`, `SUM(TaxableAmt)`, `SUM(IGSTAmt)`, `SUM(CGSTAmt)`, `SUM(SGSTAmt)`, `SUM(CESSAmt)`, where `GST % = CGSTPer + SGSTPer + IGSTPer` of the line (so a 18% line shows 18 whether it was CGST+SGST or IGST). Product must have an HSN; `NON GST` invoices are excluded. The "UQC" column is simply the product's unit text (`SalesUnit`), not a government unit code. The portal wants one row per HSN and rate for the whole period; this screen is per day and per product and has to be added up by the user.

### A2.4 Flow

Open, the two dates are set, "Get Data" runs the six queries one after the other (`btnGetData_Click`, `:978`); "Reset" resets the dates and re-runs. Export per tab. Nothing is saved.

### A2.5 Quirks and probable bugs

| # | Quirk | Verdict |
|---|---|---|
| 1 | B2CL/B2CS cut-off is a fixed 250000 in the SQL text. The rule has since changed (for inter-state invoices to unregistered buyers the limit is now 1,00,000 from August 2024; this is outside knowledge, to be confirmed by an accountant) and the old test ignores whether the sale is between states | Fix: the cut-off and the "between states" test belong in the India pack as data. |
| 2 | `RTRIM(GSTIN) = ''` is false for a NULL GSTIN, so a customer saved with NULL GSTIN would appear in neither B2CL nor B2CS (not verified how the customer screen saves an empty GSTIN) | Port: treat NULL and empty alike. |
| 3 | B2CS is not grouped by state and rate as the portal needs | Fix: group by place of supply and rate. |
| 4 | Credit notes: CDNR/CDNUR "Taxable Amount" is `SalesReturn.SubTotal` which for a return is the sum of line **taxable** (`frmSalesReturn.vb:2616` sums cell 21) so it is the taxable value, but there are no debit notes at all | Keep the credit-note rows; add debit notes. |
| 5 | HSN rows are per day and per product and the "UQC" is free text | Fix: summarise per HSN and rate for the period, with the government unit code from a pack list. |
| 6 | Invoices with no HSN on the product silently drop out of the HSN list while staying in B2B/B2CS | Port: warn "n lines have no HSN". |
| 7 | No document summary, no nil-rated/exempt/non-GST outward summary | Add (India module). |
| 8 | Export is Excel only; nothing the GST portal accepts | Add a portal JSON or CSV later (needs the current portal format; not studied). |

### A2.6 Test vectors (classification, worked from the filters above)

Invoice = (GSTIN present?, invoice flag, grand total, state same?) -> tab:

| # | Input | Result |
|---|---|---|
| G1 | GSTIN present, `GST` invoice, 5,000.00, same state | B2B |
| G2 | GSTIN present, `NON GST` invoice | not in any tab |
| G3 | No GSTIN, 249,999.99 | B2CS |
| G4 | No GSTIN, 250,000.00, same state | B2CL (old rule; the state is not checked) |
| G5 | No GSTIN, 150,000.00, other state | B2CS (old rule). Under the 2024 rule it would be B2CL. |
| G6 | Return of a G1 invoice, dated in the report period | CDNR; the invoice's own date does not matter, the return's date does |
| G7 | Return of a G3 invoice | CDNUR (any amount) |
| G8 | Return of a G2 invoice | none |
| G9 | Invoice of 3 lines: two lines of product A (HSN 1006, 5%, same day, qty 2 and 3, taxable 100.00 and 150.00) and one of product B (no HSN) | HSN list: 2 line rows for A in the GSTR-1 HSN tab; HSN summary screen: 1 row for A with qty 5, taxable 250.00; B appears nowhere in the HSN views but its tax is in B2B/B2CS |
| G10 | The same product sold on two days | HSN summary: 2 rows (one per day); the portal wants 1 |
| G11 | One 18% line sold intra-state (CGST 9 + SGST 9) and one 18% line sold inter-state (IGST 18) of the same product, same day | HSN summary: 1 row, GST % 18, CGST and SGST amounts of the first, IGST amount of the second (the group key is the percent sum) |
| G12 | Line with Taxable 84.75, Discount 0.00, Qty 1 | HSN tab "Sales Rate" 84.75; with Discount 10.00 and Taxable 90.00, Qty 2: (90 + 10) / 2 = 50.00 |

### A2.7 What the Hub has today

No GSTR-1 and no HSN in the Hub (`docs/old-programs/06-hub-map.md` 4.2: no HSN anywhere in Core or Web; the tax report prints only components per rate code from the stored engine result). The Hub does keep each document's engine result JSON (`documents.result`: per line taxable, components, cess, `byCode` buckets), buyer region and seller region, so B2B/B2CL/B2CS and CDNR/CDNUR can be produced from it because the Hub's `parties` table has `tax_id` (where a GSTIN would go) and `region` (`apps/business-hub/src/NextGenOS.Hub.Core/Data/Migrations/001_initial.sql:9-10`). Not checked: whether any Hub screen validates or requires the GSTIN, or how the `region` of a customer is chosen (the old POS keeps the state **name**, the Hub the two-digit state **code**).

## A3. GSTR-3B

File: `frmGSTR3B.vb` (3,348 lines, almost all repeated grid code). It is **a read-only list of totals, not a return**: there is no input-tax-credit netting, no "tax payable", no interest, no filing and no file for the portal. Output: grids plus "Export To Excel" per grid (ClosedXML, same code as GSTR-1).

### A3.1 What a person sees

Title "GSTR-3B Returns", "Search by Date" (From = the company's financial-year start, To = today; `fyear`, `:1149`), "Get Data" and "Reset". Three tabs:
- **Sales**: five blocks, each a one-row grid with columns Head, **Taxable Value, CGST, SGST/UTGST, IGST, CESS, Sub Total Value** and a "Grand Total" row: "Within State Supplies to Registered and Unregistered Parties", "Outside State Supplies to Unregistered, Composition or UIN holders", "Outside State Supplies to Registered Party", "Other Outward Supplies (Nil Rated, Exempt)", "Non GST Outward Supplies (No Taxes)".
- **Purchase**: seven blocks with the same columns: "Inward Supplies / Purchases from Registered Parties", "... from Unregistered Parties with Reverse Charge", "... without Reverse Charge", "From a supplier under Composition Scheme, Exempt and Nil rated Supply within State", "... Outside State", "Non GST Supply within State", "Non GST Supply Outside State".
- **Statewise Outward Supply**: a list of inter-state invoices (columns Tax Type, State, Supplier Type = Registered or Unregistered, Taxable, IGST) with totals.

### A3.2 Tables read

`InvoiceInfo` + `Customer` (State, GSTIN) for sales; `Stock` + `Supplier` (State, GSTIN) for purchases; `Company(State, FYFrom)`. Only these columns: `TaxType, TaxableAmt, CGST, SGST, IGST, CESS, InvoiceDate / Stock.Date, ReferenceNo2` (the reverse-charge flag, see A1.2). Nothing is written. Sales returns and purchase returns are **not read at all**: the figures are gross of returns.

### A3.3 The rules (each block is one SQL `SUM`; `Sub Total Value = SUM(TaxableAmt) + SUM(CGST) + SUM(SGST) + SUM(IGST) + SUM(CESS)`, `:1202`)

`@state` = the company's state text. "Tax" = `CGST + SGST + IGST + CESS` of the invoice header.

| Block | Where | Filter |
|---|---|---|
| Within State | `Sale`, `:1202` | `TaxType='GST'` and Tax > 0 and customer state = @state |
| Outside State, Unregistered | `Sale2`, `:1224` | `TaxType='GST'` and Tax > 0 and customer state <> @state and customer GSTIN is empty |
| Outside State, Registered | `Sale4`, `:1246` | same but GSTIN present |
| Nil rated, Exempt | `Sale6`, `:1268` | `TaxType='GST'` and Tax = 0 (any customer, any state) |
| Non GST | `Sale7`, `:1290` | `TaxType='NON GST'` |
| Purchase from Registered | `Pur`, `:2175` | `Stock.TaxType='GST'`, Tax > 0, supplier GSTIN present |
| Unregistered with reverse charge | `Pur2`, `:2197` | `GST`, Tax > 0, GSTIN empty, `ReferenceNo2 = 'Yes'` |
| Unregistered without reverse charge | `Pur4`, `:2219` | `GST`, Tax > 0, GSTIN empty, `ReferenceNo2 = 'No'` |
| Composition/Exempt/Nil within State | `Pur6`, `:2241` | `GST`, Tax = 0, GSTIN present, supplier state = @state |
| Composition/Exempt/Nil outside State | `Pur7`, `:2263` | `GST`, Tax = 0, GSTIN present, supplier state <> @state |
| Non GST within State | `Pur8`, `:2285` | `NON GST`, Tax = 0, supplier state = @state |
| Non GST outside State | `Pur9`, `:2307` | `NON GST`, Tax = 0, supplier state <> @state |
| Statewise Outward | `SaleStatewise`, `:3211` | `GST`, CGST + SGST = 0 and IGST > 0, customer state <> @state; one row per invoice |

The block "Grand Total" rows (`Calculate` to `Calculate5`, `:1521-1880`, and `Calculate6` to `Calculate11`) add the six columns of the five (or seven) blocks, then `Math.Round(x, 2)`; `Calculate111` totals the statewise list. The reverse-charge tax the buyer owes is the CGST/SGST/IGST stored on the purchase header; it is stored even though the bill total leaves it out (A1.3 step 9).

### A3.4 Flow

Get Data runs all the queries in a fixed order (`btnGetData_Click`, `:1308`), fills the grids, then totals. No save.

### A3.5 Quirks and probable bugs

| # | Quirk | Verdict |
|---|---|---|
| 1 | The "Within State" block is the only taxable-outward block for same-state sales; taxable sales between states appear only in the two "Outside State" blocks, so GSTR-3B 3.1(a) has to be added up by hand | Fix: make 3.1(a) the sum of the three, and 3.1.1/3.2 from the statewise list. |
| 2 | Classification is by the **invoice header**: an invoice with one 18% line and one nil-rated line is entirely "taxable"; the nil-rated block only holds invoices whose total tax is zero. Nil, exempt and non-GST **lines** inside taxed invoices are not separated | Fix: classify per line (the Hub keeps per-line results). |
| 3 | "Composition" customers cannot be told apart (no flag); the block title says so but only GSTIN-empty is used | Keep the title only if a composition flag exists. |
| 4 | Customer or supplier with NULL state or NULL GSTIN falls out of a block (the SQL compares with `=` and `NOT ... =`) | Port: treat NULL as empty. |
| 5 | A GST purchase from an **unregistered** supplier with zero tax matches none of the seven blocks (`Pur2/4` need Tax > 0; `Pur6/7` need a GSTIN) | Add a block (inward from unregistered, exempt or nil). |
| 6 | Reverse charge is only reported for unregistered suppliers; a reverse-charge purchase from a registered supplier counts in "from Registered" | Fix with a per-bill reverse-charge flag in every block. |
| 7 | No input-tax-credit rule (blocked credits, reversal), no tax payable, no interest or late fee | Out of the old POS's scope; decide later if wanted. |
| 8 | Returns (sales, purchase) are not deducted | Fix: net the credit and debit notes into the same blocks. |
| 9 | Filter dates are compared with `between`, using the picker's date part; purchases and sales are stored date-only so the whole last day is included | Keep. |

### A3.6 Test vectors (classification; each invoice is `(TaxType, customer/supplier state vs shop state, GSTIN, tax)`)

Shop state = Maharashtra.

| # | Input | Block |
|---|---|---|
| T1 | Sale GST, customer Maharashtra, taxable 1,000.00, CGST 90.00, SGST 90.00 | Within State |
| T2 | Sale GST, customer Gujarat, no GSTIN, taxable 1,000.00, IGST 180.00 | Outside State, Unregistered (and one row in Statewise: GST, Gujarat, Unregistered, 1,000.00, 180.00) |
| T3 | Sale GST, customer Gujarat, GSTIN present, taxable 1,000.00, IGST 180.00 | Outside State, Registered (and Statewise: Registered) |
| T4 | Sale GST, customer Maharashtra, all lines nil rated, taxable 500.00, tax 0 | Nil rated, Exempt |
| T5 | Sale NON GST, taxable 700.00 | Non GST |
| T6 | Sale GST, customer Maharashtra, line A 18% taxable 1,000.00 (tax 180.00) and line B nil taxable 200.00 | Within State, taxable 1,200.00, CGST 90.00, SGST 90.00 (B is not separated) |
| T7 | Sale GST, customer Gujarat, GSTIN present, nil rated, taxable 300.00 | Nil rated, Exempt (the state is not looked at) |
| T8 | Purchase GST, supplier with GSTIN, taxable 5,000.00, CGST 450.00, SGST 450.00 | Purchase from Registered |
| T9 | Purchase GST, supplier with no GSTIN, reverse charge Yes, taxable 5,000.00, IGST 900.00 | Unregistered with Reverse Charge: taxable 5,000.00, IGST 900.00, sub total 5,900.00 (the bill itself totals 5,000.00) |
| T10 | Same, reverse charge No | Unregistered without Reverse Charge |
| T11 | Purchase GST, supplier with GSTIN, Maharashtra, tax 0, taxable 400.00 | Composition/Exempt/Nil within State |
| T12 | Purchase GST, supplier with no GSTIN, tax 0, taxable 250.00 | **no block** (quirk 5) |
| T13 | Purchase NON GST, supplier Karnataka | Non GST outside State |
| T14 | Sales returned later (credit note of T1) | block unchanged (returns are not read) |

### A3.7 What the Hub has today

Nothing equivalent. `ReportService.TaxSummary` (`apps/business-hub/src/NextGenOS.Hub.Core/Reports/ReportService.cs:92`) adds the stored engine result `byCode` buckets of issued **sales** documents (invoice types plus `credit-note` with a minus sign) per rate code: taxable, each component (CGST, SGST, IGST) and cess. So the Hub nets credit notes (the old screen does not), has per-line classification by rate code (better than the old header test), but has **no purchase-side summary, no registered/unregistered split, no state split, no nil/exempt/non-GST separation beyond the rate code, no reverse charge**. A GSTR-3B module needs the buyer GSTIN (`parties.tax_id`) and region (`parties.region`) from the document's party, which the Hub stores.

## A4. GST registers

Seven screens read the stored bills and list them; none writes. Each has "Get Data", a date range (financial-year start to today), a "Grand Total Summary" under the grid (the visible rows added up, `Math.Round(x, 2)`) and a Print button (Crystal report `rptGSTSale` / `rptGSTReport`).

### A4.1 The screens, tables and columns

| Screen (file) | Title on screen | Rows | Source and filter | Columns |
|---|---|---|---|---|
| `GSTSaleRegister.vb` (`:384`) | Sales Register (Bill Wise) | one per invoice | `InvoiceInfo` left-joined to `Customer`; `NOT TaxType='NON GST'` | Bill No, Date, Customer Name, GSTIN, **Bill Amount = GrandTotal**, Taxable Amount = `TaxableAmt`, CGST, SGST, IGST, CESS, **Other Amount = GrandTotal - (Taxable + CGST + SGST + IGST + CESS)** (so it is freight - bill discount + round-off) |
| `GSTSaleReturn.vb` (`:389`) | Sales Return Register (Bill Wise) | one per sales return | `SalesReturn` joined to its invoice and customer; not `NON GST` | same 11 columns, but **Taxable = (GrandTotal - FreightCharges + OtherCharges) - (CGST + SGST + IGST + CESS)** and Other = GrandTotal - (Taxable + taxes): the taxable value is worked back from the grand total, so the return's round-off ends up inside "taxable" |
| `GSTPurchaseRegister.vb` (`:389`) | Purchase Register (Bill Wise) | one per purchase | `Stock` joined to `Supplier`; not `NON GST` | Bill No, Date, Supplier Name, GSTIN, **Bill Amount = (Taxable + CGST + SGST + IGST + CESS + FreightCharges) - OtherCharges** (worked, not the stored `GrandTotal`: previous due and round-off are left out), Taxable, CGST, SGST, IGST, CESS, Other = Freight - OtherCharges |
| `GSTPurchaseReturn.vb` (`:389`) | Purchase Return Register (Bill Wise) | **one per returned line** (see quirks) | `PurchaseReturn` joined to `PurchaseReturn_Join`, `Product`, `Stock`, `Supplier`; not `NON GST` | same as the sales return register |
| `frmSalesInvoiceRecord_GSTR.vb` (`:490-727`) | Sales Register (item wise, with search) | one per invoice line | `InvoiceInfo` + `Invoice_Product` + `Product` + `Customer`; **no NON GST filter**; search by invoice no, customer name, product name, product code, barcode, IMEI 1 | Invoice No., Date, Tax Type, Customer Name, State, GSTIN/UID, Product Name, HSN Code, Sales Rate (= (line taxable + line discount) / qty), Qty., UOM, Discount %, Discount, CGST %, CGST, SGST %, SGST/UTGST, IGST %, IGST, CESS %, CESS, Total Amount, Product Code, Barcode, IMEI(1), IMEI(2), Description, Batch/Serial, Mfg Date, Exp Date, Size, Colour |
| `frmGSTDetails.vb` (`:360`) | Sales Register (Item Wise) | one per invoice line | same joins; not `NON GST`; optional filter on the line's GST % (`CGSTPer+SGSTPer+IGSTPer = x`) | the item columns above plus **Taxable Amt, Total GST %, Total GST Amt** |
| `frmGSTDetailsPur.vb` (`:370`) | Purchases Register (Item Wise) | one per purchase line | `Stock` + `Stock_Product` + `Supplier` + `Product`; not `NON GST`; optional GST % filter | Invoice No., Invoice Date, Tax Type, Supplier's Invoice No. and Date, Supplier Name, State, GSTIN, Product Name, HSN Code, Purchase Rate (= (taxable + discount) / qty), Qty., UOM, Discount %, Discount Amt, Taxable Amt, Total GST %, Total GST Amt, CGST %, CGST, SGST %, SGST/UTGST, IGST %, IGST, CESS %, CESS, Total Amount |
| `frmSalesReturnRecord_GSTR.vb`, `frmPurchaseRecord_GSTR.vb`, `frmPurchaseReturnRecord_GSTR.vb` | the item-wise records of returns and purchases | line level (assumed) | **Not read.** By name, size (870 to 994 lines) and sibling pattern they are the item-wise records of returns and purchases with the same search box | Not understood in detail; read them before porting those registers |
| `frmTaxReport.vb` (`:405-468`) | Tax Report | one per invoice with tax | `InvoiceInfo` + `Customer` where `CGST+SGST+IGST+CESS > 0`; also a list of an old service-tax column (`InvoiceInfo1.ServiceTax`) | InvoiceNo, InvoiceDate, CustomerID, Name, CGST, SGST, IGST, CESS |
| `frmGstNonGst.vb` | a one-column pick list "Select GST/NON GST" | n/a | a 140-line form with one grid column headed "Select GST/NON GST" | Not understood (who opens it was not traced) |

### A4.2 Rules (what makes the numbers)

No new arithmetic: every figure is a stored column (A1.2) or a difference of stored columns (the "Other Amount" and "Bill Amount" formulas above). The sum under each grid is a plain sum of the shown rows, rounded to 2 places.

### A4.3 Flow

Open, pick dates, Get Data, optional search, Print (report window) or read. Nothing else.

### A4.4 Quirks and probable bugs

| # | Quirk | Verdict |
|---|---|---|
| 1 | The purchase-return register joins to the return's line table and does not group, so a return with 3 lines appears 3 times with the same header totals and the "Grand Total Summary" triples it | Fix (list the header once). |
| 2 | Sales-return taxable is a back-calculation; it absorbs the round-off, so it can differ from the sum of the lines' taxable by up to 0.50 | Fix: store the return's taxable (the Hub stores per-document taxable). |
| 3 | The bill-wise purchase register recomputes "Bill Amount" and ignores the stored `GrandTotal` (previous due and round-off are not in it) | Fix: show the stored total and the round-off separately. |
| 4 | The item-wise sales register (`frmSalesInvoiceRecord_GSTR`) includes NON GST invoices, the GST ones do not | Keep as two reports; label them. |
| 5 | No register for sales or purchases by rate, no HSN-wise purchase summary (the portal wants it for GSTR-9 only) | Add if wanted. |
| 6 | State, GSTIN and names are read from the master **now**, not as at the invoice date (a customer who changes GSTIN changes old registers) | Fix: copy GSTIN and state onto the document when it is made (the Hub copies `buyer_region` but not the GSTIN). |

### A4.5 Test vectors

| # | Input (header columns) | Register row |
|---|---|---|
| R1 | Taxable 1,000.00, CGST 90.00, SGST 90.00, GrandTotal 1,180.00 | Bill Amount 1,180.00, Other 0.00 |
| R2 | Same but freight 20.00, GrandTotal 1,200.00 | Other 20.00 |
| R3 | Same but bill discount 50.00, GrandTotal 1,130.00 | Other -50.00 |
| R4 | Total 1,050.47, round-off -0.47, GrandTotal 1,050.00, taxable 890.23, tax 160.24 | Other -0.47 |
| R5 | Sales return: GrandTotal 590.00, freight 0, other 0, CGST 45.00, SGST 45.00 | Taxable 500.00, Other 0.00 |
| R6 | Sales return: true taxable 499.67, CGST 45.00, SGST 45.00, Total 589.67, round-off +0.33, GrandTotal 590.00 | Taxable **500.00** (not 499.67), Other 0.00 |
| R7 | Purchase: taxable 5,000.00, CGST 450.00, SGST 450.00, freight 100.00, other charges 50.00, previous due 2,000.00, stored GrandTotal 7,950.00 | Bill Amount 5,950.00 (not 7,950.00), Other 50.00 |
| R8 | Purchase return with 3 lines, header GrandTotal 1,180.00 | 3 rows of 1,180.00; summary Bill Amount 3,540.00 |
| R9 | Item line: qty 2, taxable 200.00, discount 20.00 | Sales Rate 110.00 |
| R10 | GST % filter 18 | lines whose CGST % + SGST % + IGST % = 18 (9 + 9 intra, or 18 inter) |
| R11 | A NON GST invoice | not in `GSTSaleRegister` or `frmGSTDetails`; present in `frmSalesInvoiceRecord_GSTR` |

### A4.6 What the Hub has today

`ReportService` (`apps/business-hub/src/NextGenOS.Hub.Core/Reports/ReportService.cs`) has `DailySales`, `Summary`, `TopItems`, `TaxSummary`, `Payments`, `Outstanding` (ageing), `TopCustomers`, `StockValues`, `Purchases` and a CSV builder (`Build`, `:170`). **No register**: no list of bills with party, GSTIN, taxable and each tax, and no item-wise register. The data is there (`documents` plus the stored engine `result` JSON per line); the register is a new report (`06-hub-map.md` recipe 6.1). The "Other Amount" idea (grand total less taxable and taxes) is `round-off + adjustments` in the Hub's totals and can be shown as two separate columns.

## A5. E-way bill

Files: `frmEwaysetting.vb` (the on/off switch), `frmEwayBillSetting.vb` (the provider connection), `frmEWayBill.vb` (generate and cancel), `ModFunc.vb:1070-1174` (the three web calls). The program does **not** talk to the government portal itself: it talks to **a paid third-party "GST suite" web service** whose address, user name and password the shop owner types in (stored in the shop's database, see quirk 1; none of those values are written here).

### A5.1 What a person sees

1. **E-Way Bill setting** (`frmEwaysetting`): "Do you want to Enable ? Yes/No" and a link "EWAY PORTAL". It writes one row `EwayBill(c1)` (`:536,586`). When it is `Yes`, the sale screen shows an extra text box for the e-way bill number (`frmPOSNew.vb:8627-8658`); that number is saved into `InvoiceInfo.Eway` (`:10715`) and printed on the invoice (report parameter "EWay", `:9438`). It is only a note: typing a number there calls nothing.
2. **Eway Bill Setting** (`frmEwayBillSetting`): list of provider records with API URL, IsEnabled, IsDefault, Username, password; New, Save, Update, Delete. Exactly one record can be default (`:538,627`). Table `EwaybillAPISetting(ID, APIURL, IsEnabled, IsDefault, username, password)`.
3. **E-Way Bill** (`frmEWayBill`): type an invoice number; a "Transportation Detail" box (transportation mode default "Road", vehicle type default "Regular", distance default 0, transporter GSTIN "Transporter ID (GSTIN)*", transporter name, transporter document number and date, vehicle number); buttons "Generat E-WayBill", "Cancel E-WayBill" (with a reason), "E-WayBill Download" (opens the link the provider returned); the result boxes E-Way Bill No., Valid Upto, E-Way Bill Date, Link. Two more tabs, "Extend Validity" and "Transporter ID", and a button "E-WayBill Update" exist on the form, but **the vehicle-update click handler is empty** (`:910`): they do nothing.

### A5.2 Tables

Read: `InvoiceInfo` joined to `Customer` (consignee name, GSTIN, address, city, state, zip), `Invoice_Product` joined to `Product` (name, description, HSN, qty, `AltUnit`, the four rate columns, `TaxableAmt`), `Company` (name, address, city, state, GSTIN and `CIN`), `EwaybillAPISetting`, `tbl_transportation`. Written: `tbl_transportation(transportation_mod, vehicle_type, transportation_distance, transporter_id, transporter_name, transporter_document_number, transporter_document_date, vehicle_number, invoice_no)` then, after the answer, `ewayBillNo, validUpto, ewayBillDate, url, requestId, is_deleted = 0, alert_message`; on cancel `is_deleted = 1, reason_of_cancel, cancelDate`.

### A5.3 Rules and flow, step by step

1. **When is an e-way bill needed?** The program has **no rule**: no 50,000-rupee check, no goods-movement test, no distance test. The user decides and opens the screen. (The rule belongs to the India module as data: threshold, exempt goods, distance; it was not in the old code.)
2. Pressing Generate (`btnEwaybill_Gen_Click`, `:333-403`) checks in this order: the invoice has no `tbl_transportation` row yet ("This Invoice have already Eway Bill"); transportation mode not blank; distance not blank; transporter ID not blank; **transporter ID matches the GSTIN pattern `^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$` after upper-casing** (`:364`); vehicle number not blank; no row for the invoice again.
3. `InsertTransportation_dtl` saves the transport row. `GenerateEwayBillJSONUsingDataTable` (`:446-544`) builds the request text by joining strings (no escaping of quotes in names or addresses). Fields: `userGstin` and `gstin_of_consignor` = company GSTIN; `supply_type "outward"`, `sub_supply_type "Supply"`, `document_type "Tax Invoice"`; `document_number` = invoice no.; `document_date` `dd/MM/yyyy`; consignor name, address (sent twice, as line 1 and line 2), city, **`pincode_of_consignor` = the company's `CIN` column (probable bug)**, state; consignee GSTIN, name, address (twice), city, zip, state; `transaction_type 3`; `other_value 0`; `total_invoice_value` = `GrandTotal`; `taxable_amount` = `InvoiceInfo.TaxableAmt`; `cgst_amount`, `sgst_amount`, `igst_amount`, `cess_amount` from the invoice header; `cess_nonadvol_value 0`; the transport fields; fixed `generate_status 1`, `data_source "erp"`, `auto_print "N"`; then an `itemList` of lines: product name, description, `hsn_code`, `quantity`, `unit_of_product` (= the line's alternate unit), the four rates, `cessNonAdvol 0`, `taxable_amount`.
4. `GenerateToken` (`:572`): checks for internet; reads the one record with `IsDefault='Yes' and IsEnabled='Yes'`; POSTs the user name and password as JSON to `<API URL>/token-auth/`; the answer's `token` is kept in memory.
5. `Ewaybill_Gen` (`:597`): POSTs the text to `<API URL>/ewayBillsGenerate/` with header `Authorization: JWT <token>`; reads `results.message.error`; if true: message "An error occurred ... check the details" and **the transport row stays**; if not: takes `ewayBillNo`, `validUpto`, `ewayBillDate`, `url`, `alert`, `status`, `code`, `requestId`; converts the two dates from `dd/MM/yyyy hh:mm:ss tt` to `yyyy-MM-dd HH:mm:ss`; updates the transport row (`:635`).
6. Cancel (`Ewaybill_Cancel`, `:669`; JSON `CancelEwayBillJSONUsingDataTable`, `:547`): body = `userGstin`, `eway_bill_number` (must parse as a number), `reason_of_cancel` (default text "Others"), `cancel_remark "Cancelled the order"`, `data_source "erp"`; POST to `<API URL>/ewayBillCancel/`; on success the row gets `is_deleted = 1`, the reason and the date. A note on the form says a bill can be cancelled within 24 hours; nothing checks it.

### A5.4 Quirks and probable bugs

| # | Quirk | Verdict |
|---|---|---|
| 1 | The provider's user name and password are stored as plain text in `EwaybillAPISetting` and shown in a grid. This breaks `CLAUDE.md` section 3/15 (secrets in the OS credential store) | Fix: credential store; never in the shop database. |
| 2 | Consignor pincode is filled from `Company.CIN` | Fix: use the company's postal code (needs a column; `Company` has none in the recovered schema subset). |
| 3 | A failed generation leaves a `tbl_transportation` row with no e-way number, and the "already has an e-way bill" check looks only for a row, so the user cannot retry that invoice (the row is deleted only when the token step throws) | Fix: delete or reuse a row that has no number. |
| 4 | Request text built with `String.Format`; a quote in a name or address breaks the JSON | Fix: build with a JSON library. |
| 5 | No rule for when an e-way bill is required; no check of the 24-hour cancel window; no vehicle update, validity extension or transporter change (empty handlers) | Add as India-module rules and calls. |
| 6 | Only outward supply of type "Supply", transaction type 3, one transporter; no bill for returns, inward supply, job work or to-state-different "bill to / ship to" | Known limits. |
| 7 | The unit sent is the product's alternate-unit text, not the government unit code | Fix: map to the code list. |

### A5.5 Test vectors (field mapping and checks, worked from the code)

| # | Input | Result |
|---|---|---|
| W1 | Transporter ID `27ABCDE1234F1Z5` | accepted |
| W2 | `27abcde1234f1z5` (small letters) | accepted (upper-cased first) |
| W3 | `27ABCDE1234F1Z` (14 characters) | "Invalid Transporter GSTIN format" |
| W4 | `27ABCDE1234F0Z5` (13th character `0`) | rejected (position 13 must be 1-9 or A-Z) |
| W5 | Invoice with GrandTotal 1,180.00, TaxableAmt 1,000.00, CGST 90.00, SGST 90.00, IGST 0, CESS 0 | `total_invoice_value 1180.00`, `taxable_amount 1000.00`, `cgst_amount 90.00`, `sgst_amount 90.00`, `igst_amount 0`, `cess_amount 0` |
| W6 | Invoice with a bill discount (A1.3 step 8): taxable 1,000.00, tax 180.00, discount 50.00, GrandTotal 1,130.00 | `taxable_amount 1000.00`, `total_invoice_value 1130.00`: taxable plus tax does not equal total, and the portal rejects totals that do not tally within its tolerance (outside knowledge, not tested) |
| W7 | Provider returns `validUpto "10/10/2026 11:59:00 PM"` | stored `2026-10-10 23:59:00` |
| W8 | Generate pressed twice for the same invoice | second time: "This Invoice have already Eway Bill" |
| W9 | Generate fails (provider answers `error: true`) then pressed again | blocked by W8's rule (quirk 3) |
| W10 | Cancel with `ewayBillNo` text "abc" | "Invalid Eway Bill Number." |
| W11 | Setting `EwayBill.c1 = 'No'` | sale screen hides the e-way box (`Visible = False`) |

### A5.6 What the Hub has today

Nothing: no e-way setting, no transport details, no provider call (searched the Hub's source for "eway" and "e-way": the only hit is the word "Gateway" in the AI settings page; the India pack only has the e-invoice note text in `invoice.eInvoice`). The Hub's `parties.tax_id` and the document totals are enough to fill the same JSON fields; the carrier, vehicle and distance fields and a credential vault are new.

## A6. TCS (tax collected at source)

Files: `frmTCSValidation.vb` (the one setting), the TCS code in the till (`frmPOSNew.vb:8662-8717, 15244-15295, 17175-17266, 17391-17476, 17397-17438`, the same in `frmPOS`, `frmPOSNewTuch`, `frmPOSTouch`), and four record screens: `frmTCSRcvd.vb` (sales), `frmTCSPurchase.vb`, `frmTCSSaleReturn.vb`, `frmTCSPurchaseReturn.vb`. The rule built is the Indian "TCS on sale of goods above a yearly limit" idea (turnover with one buyer over a limit; a percent that is higher when the buyer has no PAN). **Outside knowledge, to be confirmed by an accountant:** that legal TCS on sale of goods was withdrawn from 1 October 2024, so the feature must be a setting that is off by default and never a hard rule.

### A6.1 What a person sees

- **TCS Validation** (settings screen): "Period From / To", "Limit Exceeded Amount From", "Tax % Applied with PAN", "Tax % Applied without PAN" (3 decimals) and "Activate" Yes/No. Only **one** row can exist ("Record Already Exists ... update the information only", `:485`). Save, Update, Delete.
- At the till, the customer card carries `PAN` and a "TCS" Yes/No. After each line is added, a small label (`Label91`) shows the TCS that should be collected on this bill. The cashier then picks **"TCS"** in the bill-sundry list and types the amount in the freight/sundry box. **No code copies the label into the box** (searched all four till forms: the box is assigned only when a saved bill is loaded), so the TCS on the bill is what the cashier types.
- Four record screens, each a date range, a grid and "Total TCS Amount": "TCS Received Record (Sale)" (three lists: customers with PAN, without PAN, all), "TCS Payment Record (Purchase)", "TCS Payment Record (Sale Return)", "TCS Received Record (Purchase Return)".

### A6.2 Tables

`TCSValid(datefrom, dateto, limit, wpan, wopan, status)`; `Customer(PAN, Tcs)`; `InvoiceInfo(BillSundry, FreightCharges, TCSPer, SubTotal, Customer_ID, InvoiceDate)`; `Stock(BillSundry, FreightCharges)`; `SalesReturn(BillSundry, FreightCharges)`; `PurchaseReturn(BillSundry, FreightCharges)`. **The TCS amount of a bill is stored as `FreightCharges` with `BillSundry = 'TCS'`**, so it is added into the bill total as an untaxed charge (A1.3 step 8) and the record screens just filter on `BillSundry='TCS'` and show `FreightCharges` as "TCS Amount". `InvoiceInfo.TCSPer` stores the rate used (the "without PAN" rate if the customer's PAN box is empty, the "with PAN" rate if not, else 0; only when the bill sundry is "TCS" and the setting is Yes; `frmPOSNew.vb:10728-10737`).

### A6.3 Rules and formulas (sale)

Let `L = TCSValid.limit`, `rate` = `wpan` if the customer has a PAN else `wopan` (a percent), `From/To` = the TCSValid period.
1. `T` = the customer's earlier turnover in the period: `SUM(InvoiceInfo.SubTotal)` for this customer with `InvoiceDate` between From and To (`GetCustomerBalanceforTCS`, `:15271`). `InvoiceInfo.SubTotal` is the sum of line taxable plus taxes of each bill (A1.2), **not** freight, bill discount or round-off.
2. `G` = the total of this bill's grid lines (the "Total" column, with tax) (`Calculate143`, `:10197`; it adds only the "Total" column). `G0` = the sum of the "Total Amount" column of a second grid, `DataGridView3` (`Calculate12345`, `:10237`); that grid is probably the already-saved lines of a bill being edited (so the bill is not counted twice), 0 for a new bill. **Not confirmed** (what fills `DataGridView3` was not traced).
3. `base = T + (G - G0)`; `excess = base - L` (`txtbal1`, `txttcscal`, `:17183, 17260`). The excess can be negative.
4. If `TCSValid.status = 'Yes'` and the customer's TCS box is `Yes`: `totalDue = excess * rate / 100` (`tcsconn`, `:17397-17407`). No rounding. If either test fails, **nothing is reset**: the previous value of the box stays (see quirks).
5. `alreadyCollected` = `SUM(FreightCharges)` of this customer's bills with `BillSundry='TCS'` in the period (`InvoiceTCSinfo`, `:8692`) minus the TCS of the bill being edited (`txtTCSdbl`; 0 for a new bill).
6. `TCS for this bill = totalDue - alreadyCollected` (`txtTCSAmt`, `:17393`). The label shows it only when it is above 0, rounded `Math.Round(x, 2)` (`:17433-17436`).
7. Purchases, sale returns and purchase returns: **no calculation**; the amount is typed as a bill sundry named TCS and only listed by the record screens.

### A6.4 Flow

Pick customer (PAN and TCS flag load, `:15567, 15614`) -> add lines -> label updates -> cashier selects bill sundry TCS and types the amount -> save (the amount is in `FreightCharges`, the rate in `TCSPer`) -> the next bill of this customer sees it in `alreadyCollected`.

### A6.5 Quirks and probable bugs

| # | Quirk | Verdict |
|---|---|---|
| 1 | The turnover base is the sales value including GST, the limit test is on sales not on money received, and the period is whatever the single row says. The legal base (outside knowledge) was receipts above the limit | Fix as data: base choice, limit, rates, dates in the India pack or shop setting; off by default. |
| 2 | One row only in `TCSValid`: a change of rule or year overwrites the history; the records keep only `TCSPer` | Fix: a dated list of rules. |
| 3 | The TCS amount is not put on the bill automatically; it depends on the cashier typing it | Fix: add it as a tax-free "TCS" adjustment computed by the module (the Hub has a `fee` adjustment kind that can carry it). |
| 4 | When the status or customer flag is No, the earlier TCS text stays; the amount can leak from the previous customer on the same screen (not tested at run time) | Fix: always recompute, with 0 when not applicable. |
| 5 | A negative result (below the limit, or after earlier collection) is hidden by the label but the arithmetic carries it | Fix: `max(0, ...)`. |
| 6 | `Calculate143` declares its running sums inside the loop, so only the total column adds up (the other four declared sums do nothing) | Harmless; do not port. |
| 7 | Customer PAN is not checked for format (no PAN pattern found; not searched in every form) | Add the PAN pattern `^[A-Z]{5}[0-9]{4}[A-Z]$` as a pack rule. |
| 8 | TCS is shown as "freight" in the invoice register (the register header calls the column "Bill Sundry Charges") | Keep the column but name the charge. |

### A6.6 Test vectors (rates are set by the shop; L = 5,000,000.00; with PAN 0.1, without PAN 1)

| # | Customer | T (earlier turnover) | G (this bill) | alreadyCollected | Result for this bill |
|---|---|---|---|---|---|
| X1 | PAN, TCS Yes, status Yes | 4,900,000.00 | 200,000.00 | 0 | base 5,100,000.00, excess 100,000.00, due 100.00, this bill **100.00** |
| X2 | no PAN, same | 4,900,000.00 | 200,000.00 | 0 | due 1,000.00, this bill **1,000.00** |
| X3 | PAN | 4,000,000.00 | 200,000.00 | 0 | excess -800,000.00, due -800.00, label shows 0.00 (hidden) |
| X4 | PAN, second bill after X1 | 5,100,000.00 | 100,000.00 | 100.00 | excess 200,000.00, due 200.00, this bill **100.00** |
| X5 | PAN, bill exactly reaching the limit | 4,900,000.00 | 100,000.00 | 0 | excess 0, TCS 0.00 |
| X6 | customer's TCS box No | any | any | any | no new calculation (previous box text remains: quirk 4) |
| X7 | TCSValid.status No | any | any | any | none |
| X8 | PAN, T 4,999,999.99 | | 100,000.01 | 0 | excess 100,000.00 (base 5,100,000.00), due 100.00 |
| X9 | PAN, odd amount | 5,000,000.00 | 33,333.33 | 0 | due 33.33333 (not rounded), label shows 33.33 |
| X10 | Bill saved with TCS 100.00 on a total of 100,000.00 grand total | | | | `FreightCharges 100.00`, `BillSundry 'TCS'`, `TCSPer 0.1`; GrandTotal includes the 100.00 |
| X11 | Same bill, record screen "TCS Received Record (Sale)" | | | | one row, "TCS Amount 100.00", "TCS %" 0.1; appears in the "with PAN" list |

### A6.7 What the Hub has today

Nothing: no TCS setting, rule or report (searched the Hub's C#, razor and JSON sources and the India pack for "TCS": no match). The engine's `fee` adjustment (an untaxed fixed or percent amount added before rounding) can carry a TCS amount; the turnover base needs the customer's invoices in the period, which the Hub can read from `documents` (`party_id`, `issued_at`, stored `subtotal_minor` = taxable, `tax_minor`). Note that the Hub's `subtotal_minor` is the **taxable value**, while the old base is taxable plus tax; X1 to X9 would differ if ported with the wrong column.

## A7. Tax categories, default tax type, state master, GSTIN rules

### A7.1 What a person sees

- **Tax Category** (`frmTaxCategory.vb`, newer `frmTaxCategoryNew.vb`): a list of GST rates ("GST Rate", "Default" Yes/No) with Save and Delete. Table `TaxCat(ID, Rate, IsDefault)`. A rate can be added once (`select Rate from TaxCat where Rate=@d1`, `frmTaxCategoryNew.vb:704`) and only one rate can be the default (`:721`). The product screen offers these rates in its "GST" box, pre-selecting the default (`frmProduct.vb:5887`).
- **Tax Type / Tax Settings** (`frmTaxSetting.vb`, `frmTaxSettingsNew.vb`): two boxes "Purchase Tax" and "Sales Tax", each `GST` or `NON GST`; table `Setting(PurchaseTax, SalesTax)`, one row. The till refuses to add a line until this row exists ("Please configure Tax Type", `frmPOSNew.vb:9925-9938`).
- **Default tax type** (`frmProductDefault.vb:473, 835, 848`): table `Defaulttaxtype(id=1, stax_type, ptax_type)`: the default Sales and Purchase mode (Inclusive, Exclusive, Exempt GST, No Taxes) that a new product starts with.
- **State** (`frmState.vb`): a pick list of states read from `tbl_state(name)`; the customer, supplier, company and lead screens use it. **State is stored as a name** (e.g. "Maharashtra"), not a code. A 0/1 switch `tbl_Defalt_State_Setting.State_status` ticks a "default state" box on the customer quick-add panel of the touch till (`frmPOSTouch.vb:21748`); its exact effect (new customers get the company's state) is inferred from the names, not traced.
- **GSTIN validation**: see A7.3.

### A7.2 Rules and formulas

1. Product GST: the product screen takes the chosen rate `r` from `TaxCat` and sets `CGST = Round(r / 2, 2)` and `SGST = CGST` (`frmProduct.vb:5851,5910`; `Math.Round` half to even), stored in `Product.CGST` and `Product.SGST` (`decimal(18,2)`). The till later makes `IGST` = CGST + SGST (A1.3 step 4). So the effective percents are 2 x `Round(r/2, 2)`.
2. **Bulk GST change** (`frmProductBulkUpdate_GST.vb:2048-2078`): the user enters "FROM GST %" and "TO GST %" (both non-zero) and optionally an HSN code, ticks products, and presses "Apply GST": for each ticked product `UPDATE Product SET CGST = to/2, SGST = to/2 WHERE CGST = from/2 [and HSNCode = x] and ProductCode = <product>`. Values go into the SQL text (not parameters); there is no rounding of `to/2` here (the column rounds on storage).
3. Sales tax or purchase tax = `NON GST` makes the till and the purchase screen zero all rates for the whole bill (A1.3 step 1). The invoice remembers it in `TaxType`.
4. State matching is by exact text (case-sensitive, `Operators.CompareString(..., False)`), after the picker; empty customer state counts as the company's state (`frmPOSNew.vb:13418`).

### A7.3 GSTIN rules in the old program

- Shape check, used in three places with **two slightly different patterns**: the lookup screen `FrmValidate.vb:422` uses `^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[A-Z0-9]{1}[Z]{1}[A-Z0-9]{1}$`; the e-way screen (`frmEWayBill.vb:364`, after upper-casing) uses `^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$`; the India pack (`country-packs/packs/IN.json`, `tax.businessId.pattern`) uses the second. The customer, supplier and company screens do **not** check the shape when saving (the customer screen only opens the lookup screen, `frmCustomer.vb:1941`).
- **Online lookup** (`FrmValidate.vb:333-401`): checks internet, the shape above, then drives a hidden Chrome (Selenium) to a public third-party GSTIN search web page, waits up to 20 seconds for a table, and copies trade name, legal name, type, constitution of business, registration date, cancellation date, principal place of business and nature from the page cells **by position** (cells 1, 5, 9, 11, 17, 3, 13, 15). The state shown is looked up from the first two digits in a built-in table (`:438`). Fragile (breaks when the page changes) and it sends the GSTIN to an outside site: against `CLAUDE.md` section 15 (nothing leaves unless allowed).
- The company and supplier screens call `DevNet.GS.GSTINValidator.ValidateGSTINAsync` on every keystroke (`frmCompany.vb:1497`, `frmSupplier.vb:2234`) and show "Valid GSTIN." or "Invalid GSTIN!". **In the recovered source this validator is an empty stub that returns an empty answer** (`apps/pos-desktop/Source/Libraries/DevNet.GS/DevNet.GS/GSTINValidator.cs`, 19 lines), so the recovered program shows "Valid GSTIN." for any text (an empty answer has no "Error" key and no "Not Available" state). What the original compiled library did is **Not understood**.
- Built-in state table (`FrmValidate.vb:439`): 01 to 24, 25 Daman & Diu, 26 Dadra & Nagar Haveli, 27 Maharashtra, 28 Andhra Pradesh (old code), 29 to 36, 37 Andhra Pradesh, 38 Ladakh, 97 Other Territory, 99 Centre Jurisdiction. The Hub's India pack lists 01 to 24, 26 (merged "Dadra and Nagar Haveli and Daman and Diu"), 27, 29 to 38 and 97, **without 25, 28 and 99**.
- No check digit test (the 15th character of a GSTIN is a check character; outside knowledge) in the old code or in the pack pattern.

### A7.4 Quirks and probable bugs

| # | Quirk | Verdict |
|---|---|---|
| 1 | Rates are stored as half-rates with two decimals; 0.25% becomes 0.12 + 0.12 = 0.24 | Fix: keep one rate with three decimals (the pack does). |
| 2 | State is a free name, so "Orissa" and "Odisha" are different states and an inter-state sale can be charged as intra-state or the reverse | Fix: store the two-digit code (the Hub does, `parties.region`). |
| 3 | Two GSTIN patterns; no check digit | Use the pack pattern, add the check-digit test. |
| 4 | Lookup by headless browser on a public site | Do not port. A lookup service, if wanted, is an owner-allowed setting (nothing leaves unasked). |
| 5 | The recovered `GSTINValidator` is a stub, so "Valid GSTIN." is meaningless there | Do not port the screen text; validate shape and check digit locally. |
| 6 | Bulk GST change builds SQL text with typed values | Fix: parameters. It also changes only the product master, not stock-batch prices or open quotations. |
| 7 | One shop-wide `GST`/`NON GST` flag (and per-bill `TaxType`) is the only way to sell some bills without tax; mixed shops (some goods taxed, some not) must set the product mode to "No Taxes" | Keep as a per-line rate (the Hub's `GSTEX`/`GST0`). |

### A7.5 Test vectors

| # | Input | Result |
|---|---|---|
| S1 | Product GST rate 18 | CGST 9.00, SGST 9.00; inter-state IGST 18.00 |
| S2 | rate 12 | 6.00 + 6.00; IGST 12.00 |
| S3 | rate 5 | 2.50 + 2.50; IGST 5.00 |
| S4 | rate 3 | 1.50 + 1.50; IGST 3.00 |
| S5 | rate 0.25 | `Round(0.125, 2)` half to even gives 0.12; CGST 0.12, SGST 0.12, IGST 0.24 (should be 0.25) |
| S6 | rate 7.5 | 3.75 + 3.75; IGST 7.50 |
| S7 | rate 28 | 14.00 + 14.00 |
| S8 | Bulk change FROM 12 TO 18 on a ticked product with CGST 6.00 | its CGST and SGST become 9 (string `9`); a ticked product with CGST 2.50 is not changed (the WHERE does not match), yet the message counts it as updated |
| S9 | Bulk change FROM 0 | refused: "From GST value can't be empty or 0." |
| S10 | GSTIN `27ABCDE1234F1Z5` | valid under all three patterns |
| S11 | GSTIN `27ABCDE1234F0Z5` | valid under the lookup screen's pattern; invalid under the e-way pattern and the pack |
| S12 | GSTIN `27ABCDE1234F1X5` (14th char not Z) | invalid under all three |
| S13 | GSTIN `27abcde1234f1z5` | e-way screen: upper-cased, valid; lookup screen: invalid (not upper-cased, `FrmValidate.vb:342`) |
| S14 | Customer state "maharashtra" (small m) against company state "Maharashtra" | not equal (`Operators.CompareString(a, b, False)` is a binary, case-sensitive compare), so the line gets IGST. The names are normally picked from the `tbl_state` list and read with `RTRIM` (`frmPOSNew.vb:15596`), so a mismatch only happens with hand-typed or imported data (matters for the data move) |
| S15 | Customer state box empty | CGST + SGST (intra-state) |

### A7.6 What the Hub has today

The India pack has the 10 rate codes (A1.7), the state list with codes, the GSTIN pattern, `pricesIncludeTaxDefault: true` and the rounding rule. The shop's own rates can override a code (SPEC section 8). The Hub's `parties.region` holds the state code; whether any Hub screen validates the GSTIN or offers the state list at party entry was not checked. No bulk rate change, no default tax mode per product (a tax code per item instead), no `NON GST` per-bill flag (the shop-level `TaxRegistered` is the equivalent, per document), no state-name mapping from an old database (the data move in `docs/MERGE-PLAN.md` step 1 must map old names to codes: old names come from `tbl_state`, which is not in the repository).

## B1. Salesman master, commission, ledger, payments

A "salesman" here is a **person who earns a commission on bills**, not a login user. There are **two different commission methods** in the old program, and the reports do not agree between them (quirk 1).

### B1.1 What a person sees

- **Salesman Entry** (`frmSalesman.vb`): ID (auto, `0001`, `0002`..., last `SM_ID` + 1, `:784`), name, address, city, state (from the state list), postal code, contact no., email, **Commission %** (default 0.00), remarks, photo (file or webcam). New, Save, Update, Delete, search. Required: company profile exists, name, address, city, state, contact no.; the contact number must not already belong to a salesman (`:1474-1481`). Delete is refused when the salesman has bills (`:864`). Also: a record list (`frmSalesmanRecord`, search by name, city, contact), a bulk editor (`frmSalesmanBulkUpdate`, edits the columns in a list and runs one UPDATE per row built from text) and Excel import/export (`frmExportImportExcel_Salesman`, inserts rows from a "Sheet1" sheet).
- **At the till**: the cashier picks a salesman for the bill (`txtSM_ID`, `txtSalesman`); his commission percent loads from the master (`SalesmanCommn`, `frmPOSNew.vb:20246`).
- **Salesman Commission Report** (`frmSalesmanCommmissionReport`): dates; one row per salesman: Salesman ID, Name, City, Contact, **Sum of Commission** (`:211`).
- **Salesman Ledger** (menu item opens `frmSalesmanLedgerNew`, `frmMainMenu.vb:12804`): pick a salesman and dates; a Crystal report of the ledger lines (Date, Name, Ledger No, Label, Credit, Debit) with the balance shown as `x.xx Cr` or `Dr`. The older `frmSalesmanLedger` lists bills with commission instead (`:262`).
- **Salesman Payment** (`frmSalesManPayment.vb`): pay a salesman: transaction no., date, payment mode, bank account (when not cash), amount, remarks; shows the balance (`GetCustomerBalance`, `:1033`); Save, Update, Delete, Print receipt, WhatsApp/SMS. List screen `frmSalesManPaymentRecordNew`.

### B1.2 Tables

`SalesMan(SM_ID, SalesMan_ID, Name, Address, City, State, ZipCode, ContactNo, EmailID, Remarks, Photo, CommissionPer)`; `Salesman_Commission(ID, InvoiceID, CommissionPer, Commission)`; `InvoiceInfo.SalesmanID`; per line `Invoice_Product(SalesManID, SalesMan, SalesManPur, SalesManComm)`; per stock batch `Temp_Stock.SalesManPur`; `LedgerBooksalesman1(ID, Date, Name, LedgerNo, Label, Debit, Credit, PartyID, PartyName)`; `CreditSalesManPayment(T_ID, TransactionID, Date, PaymentMode, Customer_ID (this holds the SM_ID), Amount, Remarks, PaymentModeDetails, BankAcNo)`; `SrReceiptSalesMan(ID, InvNo)` (numbering helper for payment receipts). The type of `Salesman_Commission.Commission` is not in the recovered schema subset.

### B1.3 Rules and formulas

**Method 1: invoice-level (every till form).** When a salesman is chosen, on Save (`frmPOSNew.vb:10765-10786`; the Update path re-writes the row, `:11624`):
1. `base = SUM over lines of (qty * rate - discount amount)` using the grid cells 4, 5 and 7 (double arithmetic, no tax removed, **bill-level discount and freight not deducted**, `:10771`).
2. `Commission = base * CommissionPer / 100`, where `CommissionPer` is the salesman master's percent at that moment (no rounding in code; the database column rounds or truncates on store).
3. One row `Salesman_Commission(InvoiceID, CommissionPer, Commission)`; no ledger entry is made by this method. The commission report and the old `frmSalesmanLedger` read these rows.

**Method 2: line-level with ledger (only the touch till `frmPOSTouch`, 53 uses of `txtSalesManPur`).** The percent comes from the **stock batch** (`Temp_Stock.SalesManPur`, loaded with the item, `frmPOSTouch.vb:18955`), not from the salesman master. Per line (`:15340-15348`, `:15408-15415`):
1. `lineBase = qty * rate - discount amount`; `lineCommission = lineBase * SalesManPur / 100`; with no salesman chosen both are 0.
2. The line stores `SalesManID`, `SalesMan`, `SalesManPur` (the percent) and `SalesManComm` (the amount) (`Invoice_Product`).
3. On Save, for each line with a salesman: `ModFunc.LedgerSaveSalesman(date, salesman name, "invoice-product-barcode-qty" text, "Sales", Debit 0, Credit lineCommission, PartyID = SM_ID, PartyName = invoice no)` (`:30176-30179`, `ModFunc.vb:816`): **we owe the salesman**, so commission is a credit.
4. Deleting a bill deletes its ledger rows by invoice number and label (`LedgerDeleteSalesman`, `:31080`).
5. **Sales return** (`frmSalesReturn.vb:3217`): a **Debit** to the salesman, label "Sales Return", of the original line's `SalesManComm` as loaded (`txtSalesmanComm`, `:2270`), **not reduced to the returned quantity**.
6. **Payment** (`frmSalesManPayment.vb:2082-2098`): validations: company profile, a salesman retrieved, name matches, bank account when paying by bank, amount entered and above 0; then insert `CreditSalesManPayment` and `LedgerSaveSalesman(date, "Cash Account", transaction no, "SalesMan_Payment", Debit amount, Credit 0, PartyID = SM_ID, ...)`; update and delete re-write or remove the ledger row. **No check that the amount is within what is owed.**
7. **Balance** (`GetCustomerBalance`, `:1039`, also in `frmSalesmanLedgerNew:539`): `SUM(Credit) - SUM(Debit)` over all dates for the party; `>= 0` shows "Cr" (owed to the salesman), below 0 shows "Dr" (overpaid), displayed as the absolute value with 2 decimals. The opening balance and running balance of the printed ledger are inside the Crystal report file, which was not read (**Not understood**).

### B1.4 Flow

Master -> choose at the till -> (Method 1) commission row at Save, (Method 2) ledger credits at Save -> returns debit -> payments debit -> balance shows what is still owed.

### B1.5 Quirks and probable bugs

| # | Quirk | Verdict |
|---|---|---|
| 1 | Two methods that never meet: Method 1 feeds the Commission Report; Method 2 feeds the Ledger and balance. The touch till runs both (it also inserts `Salesman_Commission`, 2 uses), so the report and the ledger can disagree. The other tills have no ledger credit at all, so their commission is never in the balance that "Salesman Payment" shows | Decide one method; port both rows into one ledger. |
| 2 | Commission base is `qty x rate - discount` with the **price as entered**: for a tax-inclusive price the GST is inside the base, for an exclusive price it is not (the same item earns different commission by price mode) | Fix: define the base as taxable value (after line discount, before tax); document it. |
| 3 | Bill-level discount, freight and TCS are not in the base | Decide; probably keep (base = line taxable). |
| 4 | Returning part of a line reverses the **whole** line's commission | Fix: reverse `lineCommission * returnQty / soldQty`. |
| 5 | Payment can exceed the balance; no payment limit | Add a warning, not a block. |
| 6 | The percent is copied from the master at each bill (Method 1 stores it), so editing the master does not change old bills, but the bill **Update** recomputes with the percent then current | Keep for new bills; do not recompute on edit. |
| 7 | Payments are stored with the salesman id in a column named `Customer_ID` | Use a proper salesman reference. |
| 8 | Bulk editor and Excel import build SQL from text | Fix: parameters. |
| 9 | A salesman has no opening balance, target, slab, per-category rate or active flag | Out of scope here; note as a possible later feature. |

### B1.6 Test vectors

Method 1 (invoice-level; rates are percents; amounts in rupees):

| # | Lines (qty x rate, line discount) | Percent | Result |
|---|---|---|---|
| M1 | 2 x 100.00, 0 | 2.5 | base 200.00, commission 5.00 |
| M2 | 3 x 33.33, discount 10.00 | 2.5 | base 89.99, commission 2.24975 (stored as the column allows: 2.25 if `decimal(18,2)` rounds half away from zero) |
| M3 | 1 x 118.00 (price includes 18% GST), 0 | 2 | base 118.00, commission 2.36 |
| M4 | 1 x 100.00 (price excludes GST; bill adds 18.00 tax), 0 | 2 | base 100.00, commission 2.00 (same item, different commission: quirk 2) |
| M5 | 2 x 100.00, 0, with a bill discount of 50.00 and freight 20.00 | 2.5 | commission 5.00 (neither is in the base) |
| M6 | any lines, percent 0 | 0 | one row with commission 0.00 |
| M7 | any lines, no salesman chosen | n/a | no `Salesman_Commission` row |
| M8 | two lines 1 x 50.00 and 1 x 150.00, discounts 5.00 and 0 | 4 | base 195.00, commission 7.80 |

Method 2 (touch till; percent per batch):

| # | Event | Ledger result for the salesman |
|---|---|---|
| L1 | Line 5 x 40.00, discount 10.00, batch percent 3 | commission 190.00 x 3 / 100 = 5.70: Credit 5.70, Label "Sales" |
| L2 | Return 2 of the 5 units of L1 | Debit **5.70** (not 2.28), Label "Sales Return"; balance back to 0.00 |
| L3 | Pay 5.00 by cash after L1 | Debit 5.00, Label "SalesMan_Payment"; balance 0.70 Cr |
| L4 | After L3, pay 2.00 more | allowed; balance 1.30 Dr (overpaid; no check) |
| L5 | No salesman on the line | no ledger row |
| L6 | Bill deleted | its ledger rows removed (by invoice no. and "Sales" / "SalesMan_Payment" labels) |
| L7 | Report for a date range | Commission Report shows Method 1 rows only: it does not show L1 unless the same bill also has a `Salesman_Commission` row |

### B1.7 What the Hub has today

Nothing for salespeople (no commission, no ledger of a person, no salesman on a document: `documents` has the cashier `user_id`, not a salesperson; the Hub map section 6.3 lists "staff" as a new master). The Hub's `audit_log`, `users` and roles are for sign-in, not for commission. The engine and `DocumentService` keep the data a Method 1 or Method 2 port needs (line taxable and discount per line in the stored `result`), so the base can be the **line taxable value after discount**, which is the corrected rule above. Porting needs: a `salespeople` master, `document.salesperson_id`, a `commission` rule (percent on master, on item, or on batch), a person ledger table (with `tenant_id`, `site_id`), payments to a person, and the reports.

## B2. Broker, transport and route

Three small masters. Only the broker has money in it.

### B2.1 What a person sees

- **Broker Entry** (`frmBroker.vb`): Broker ID (auto, last `BR_ID` + 1), name, address, contact no. (unique, `:1142`), **Commission %** (default 0.00), photo; New, Save, Update, Delete, search by name or contact. Table `Broker(BR_ID, Broker_ID, Name, Address, ContactNo, CommissionPer, Photo)`.
- **At the till** (`frmPOSNew.vb`, boxes `ComboBox5` to `TextBox30`, `BrokerCalc` `:19779`): pick a broker (his address and contact fill in; his master percent is only **shown** as "Approved Comm % : x" next to the boxes, `ComboBox5_SelectedIndexChanged`, `:19987-20002`, and is **not** copied into the percent box, so the cashier types the percent and can differ from the approved one), then "Commission Applied On" = **Without Tax** or **With Tax**, "Commission Type" = **%** or **Amt**, "Commission%" and "Commission Amount". "Reset broker" clears them (`:19853`).
- **Broker Ledger** (`frmBrokerLedger.vb`): a list of the commission rows of a date range with search by invoice no., broker name or contact, and the total (sum of the Commission Amt column): ID, Invoice Date, Invoice No, Broker Name, Address, Contact, "Calculation on Total Amount", Commission Applied On, Commission Type, Commission %, Commission Amt, Customer Name, Customer Address. It has **no balance, no payments and no opening balance**.
- **Broker Payment** (`frmBrokerCalc.vb`): it is an **expense voucher** pre-filled with Details "Broker Payment" and Particulars "Expenses (Direct/Indirect)": name, date, amount, payment mode, note (`Voucher`, `Voucher_OtherDetails`, `:458, 472`). It does not look at what is owed to the broker.
- **Transporter** (`frmTransport.vb`): a master with Name, Address, City, PIN, State[Code], Contact No., Email, GSTIN, PAN, Vehicle Type, Vehicle No, Service; required: Name, Address, State, Contact no., Service (`:1325-1345`). Stored in `Transport(ID, c1 ... c12)` (the columns are numbered: c1 name ... c12 service; `:1352`). The till fills the bill's "Remarks" drop-down with one line per transporter (`FillTransport`, `frmPOSNew.vb:18949`), so a chosen transporter prints as bill remarks. It is **not** connected to the e-way bill screen, which has its own transport boxes (A5).
- **Customer Location Route** (`frmRoute.vb`): a list of route names (`Route(routename)`), New, Save (no duplicate names, `:516`), Update, Delete. A customer has one route (`Customer.Route`, chosen on the customer screen); the customer record list and the bulk-WhatsApp list show it (`frmCustomerRecord.vb:496`, `frmBulkWhatsappDoc.vb:639`). No route-wise delivery, sales or collection report was found.

### B2.2 Tables written

`Broker`, `BrokerLdr(ID, InvDate, InvNo, BName, BAddress, BContact, TotAmt, CommApl, CommType, CommPer, CommAmt, CustName, CustContact)` (one row per bill with a broker), `Voucher`, `Voucher_OtherDetails`, `Transport`, `Route`, `Customer.Route`.

### B2.3 Rules and formulas (broker commission)

Let `G = txtGrandTotal` of the bill (after round-off, so it includes freight and TCS and is net of the bill discount) and `T = TextBox12 = CGST + SGST + IGST + CESS` of the bill (`:16525`, rounded to 2).
1. Commission applied on **Without Tax**: `base = G - T`; on **With Tax**: `base = G`.
2. Type **%**: `CommAmt = Round(base * pct / 100, 2)` (VB `Math.Round`, half to even) (`:19784-19788`).
3. Type **Amt**: the user types `CommAmt` and the percent is shown: `pct = Round(CommAmt / base * 100, 3)` (`:19796-19800`); a base of 0 divides by zero (no guard).
4. On Save, **only if** a broker name is chosen and `CommAmt > 0` (`:11097`), one row is written to `BrokerLdr`: `TotAmt` = `G - T` for Without Tax, `G` for With Tax (otherwise 0), `CommApl` = the box text ("Without Tax" or "With Tax"), `CommType` = "%" or "Amt", `CommPer` = the percent text, `CommAmt`, and the customer's name and contact (`:11101-11127`). A bill delete removes its row by invoice number (`:10432`); a bill update rewrites it (`:11646`).
5. **A sales return does not touch the broker row** (no `BrokerLdr` code in `frmSalesReturn.vb`).

### B2.4 Quirks and probable bugs

| # | Quirk | Verdict |
|---|---|---|
| 1 | The broker's commission base starts from the grand total, so freight, TCS and the round-off are inside the base, and the bill-level discount is already out | Fix: base = line taxable value (or choose "with tax" as grand total minus freight and charges); keep the two options. |
| 2 | No broker balance: commission earned (ledger) and paid (a voucher) are not joined | Fix: one broker ledger (credit commission, debit payment), same as the salesman ledger in B1. |
| 3 | A sales return does not reduce the broker's commission | Fix: pro-rata reversal, as with the salesman (B1 quirk 4). |
| 4 | The transporter master is not linked to the e-way bill screen (the transporter's GSTIN must be typed again) | Fix: pick the transporter in the e-way screen. |
| 5 | Table `Transport` has numbered column names `c1` to `c12` | Use named columns in the port. |
| 6 | Dividing by a zero base in the Amt mode | Guard. |
| 7 | A route is a free name on the customer; nothing uses it for reports or delivery | Keep as a customer tag; add a route-wise report only if asked. |

### B2.5 Test vectors (broker; G is the grand total, T the tax)

| # | Input | Result |
|---|---|---|
| K1 | G 1,180.00, T 180.00, Without Tax, %, 2 | base 1,000.00, commission 20.00; ledger `TotAmt 1000.00` |
| K2 | same, With Tax, %, 2 | base 1,180.00, commission 23.60; `TotAmt 1180.00` |
| K3 | G 1,180.00, T 180.00, Without Tax, Amt, 25.00 | percent `25 / 1000 * 100 = 2.500` |
| K4 | same, With Tax, Amt, 25.00 | percent `25 / 1180 * 100 = 2.11864` shown as 2.119 |
| K5 | G 1,200.00 (freight 20.00 included), T 180.00, Without Tax, %, 2 | base 1,020.00, commission 20.40 (freight is in the base) |
| K6 | G 1,050.00 (after round-off from 1,050.47), T 160.24, Without Tax, %, 1.5 | base 889.76, commission `13.3464` shown as 13.35 |
| K7 | G 100.00, T 0.00, With Tax, %, 2.5 | base 100.00, commission 2.50 |
| K8 | commission 0.00, broker chosen | no ledger row |
| K9 | broker not chosen, commission typed | no ledger row |
| K10 | base 0.00, type Amt | divide by zero (no result; guard needed) |
| K11 | broker row, then the bill is returned in full | row stays (quirk 3) |

### B2.6 What the Hub has today

Nothing: no broker, transporter or route master, no commission. The Hub's `parties.kind` field is the only existing party typing (customer, supplier); a broker and a transporter would be new party kinds or new masters (`06-hub-map.md` recipe 6.3). The Hub's documents carry no remarks drop-down fed by transporters.

## B3. Employees, attendance, salary slips, advances, employee payments

A small monthly-salary payroll: register staff, mark present or absent with times, give advances, pay a salary for a date range, print a slip. **No statutory payroll** (no PF, ESI, professional tax, TDS, bonus, leave types, salary components). Money posts into the general ledger (`LedgerBook`, see `02-masters-accounting-reports.md` for how that ledger and the day book read it).

### B3.1 What a person sees

- **Employee Registration** (`frmEmployeeRegistration.vb`): Employee ID (auto `EMP-1`, `EMP-2` ... from `MAX(ID) + 1`, `:736-755`), name, gender (Male or Female), address, city, contact no., e-mail, blood group (A+, B+, AB+, O+, A-, B-, AB-, O-), department and designation (typed or picked from earlier ones), date of joining, **Basic Salary**, **Basic Working Time** (a time such as `08:00:00`), photo, "Status: Active". Required: company profile, name, gender, address, city, contact no., department, designation, basic salary, basic working time (`:1262-1311`). Delete is refused when the employee has an advance, an attendance row or a payment (`:1001-1048`). A rename also renames the employee in `LedgerBook` (`:1422`).
- **Attendance Entry** (`frmAttendance.vb`): search an active employee; pick the date, status **P** (present) or **A** (absent), In Time, Out Time; Overtime is filled in. One row per employee per day (`:908-915`: "Employee today's attendance is already saved"). List screen `frmAttendanceEntryRecord`.
- **Advance Payment Entry** (`frmAdvanceEntry.vb`): pick an employee (the list shows "Total Advance" = what is still owed back), date, amount ("Cash Only allowed"); Save, Update, Delete.
- **Employee Payment** (`frmEmployeePayment.vb`): pick an employee, "Date From" and "Date To", then the screen fills Present Days, Salary, Advance outstanding, Overtime time; the user enters Overtime Rate and Deduction, payment date, mode (cash, cheque, online) and bank account; shows Overtime Amount and Net Pay. Save (and print), Update, Delete, search.
- **Salary slip** (`frmSalaryslip.vb`) and **Salary Slips Report** (`frmSalarySlipsReport.vb`): print a slip by Payment ID, or the list of slips by payment date or by employee and date (Crystal reports `rptSalarySlip`, `rptSalarySlips`); **Employee Payment Report**, **Advance Report**: lists by date and employee.

### B3.2 Tables

`EmployeeRegistration(ID, EmployeeID, EmployeeName, Gender, Address, City, ContactNo, Email, BloodGroup, Department, Designation, DateOfJoining, Salary, BasicWorkingTime, Photo, Active)`; `EmployeeAttendance(ID, WorkingDate, EmployeeID, Status, InTime, OutTime, Overtime, BasicWorkingTime)` (times are stored as text); `AdvanceEntry(ID, WorkingDate, EmployeeID, Amount, Deduction)`; `EmployeePayment(ID, PaymentID, DateFrom, DateTo, EmployeeID, PresentDays, Salary, Advance, Deduction, OverTime, OverTimeRate, OverTimeAmount, PaymentDate, ModeOfPayment, PaymentModeDetails, NetPay, BankAccount)`; `LedgerBook` and `BankAccountLedger` for the money entries. In `EmployeeAttendance.EmployeeID` and the others the value is the employee's **row ID**, not the text "EMP-n".

### B3.3 Rules and formulas

1. **Overtime of a day** (`frmAttendance.vb:800-812`): `overtime = (OutTime - InTime) - BasicWorkingTime` as a time span; it is **negative** when the person worked less than the basic time (stored as text such as `-01:00:00`). Status A: in and out `00:00:00`, overtime `00:00:00` (`:777-796`). No half day, no leave, no holiday, no weekly off.
2. **Present days** (`frmEmployeePayment.vb:1055`): `COUNT` of that employee's `EmployeeAttendance` rows with status `P` and `WorkingDate` between Date From and Date To, **both days included**.
3. **Salary earned** (`Compute`, `:989-991`; also `:1062`): `Round(BasicSalary * PresentDays / 30, 2)` (VB half to even). The divisor is **always 30**, whatever the month.
4. **Overtime total** (`:1094-1108`): the day overtimes are added by parts: hours of all days, minutes of all days and seconds of all days are summed separately and then made into one time span `New TimeSpan(hours, minutes, seconds)` (so negative days reduce it).
5. **Overtime amount** (`:993-1006`): only if the Overtime Rate box parses as a **whole number** (`Integer.TryParse`): `OvertimeAmount = TotalMinutes * rate / 60`, then rounded to 2 and then to 3 places. A rate with decimals (12.5) does not parse and the amount is left as it was.
6. **Advance outstanding** (`:1070`): `SUM(AdvanceEntry.Amount) - SUM(AdvanceEntry.Deduction)` for that employee over all time.
7. **Net pay** (`:1007-1009`): `Round(Salary + OvertimeAmount - Deduction, 2)`. The "Advance" figure is **not** subtracted by the formula; only the typed **Deduction** is.
8. **Save checks** (`btnSave_Click`, `:1632-1796`): employee retrieved; overtime rate entered; payment mode chosen; bank account when not cash; `Advance >= Deduction` ("You can not deduct amount more than advance amount"); `NetPay > 0` ("Net pay should be more than 0"); Date To after Date From and **not equal** ("Selected 'Date From' is equal to 'Date To'"); no existing payment of that employee whose date range overlaps (`DateFrom <= new To and DateTo >= new From`, "Salary already paid..").
9. **What save writes** (`:1719-1773`): one `EmployeePayment` row; if `Deduction > 0` one `AdvanceEntry` row with `Amount 0` and `Deduction = typed deduction` (this repays the advance); ledger entries labelled "Payroll Payment" dated the payment date: by cash two `LedgerBook` rows (`Name "Cash Account"`, first money column = NetPay; and `Name` = the employee, second money column = NetPay, party id = the text employee id); by cheque or online the same with `Name "Bank Account"` plus `BankAccountLedger` ("Payroll Payment-By Cheque" or "...By Online Transfer").
10. **Advance entry save** (`frmAdvanceEntry.vb:685, 697-698`): `AdvanceEntry(Amount = typed, Deduction = 0)` and two `LedgerBook` rows labelled "Payroll Advance" (Cash Account and the employee). Required: employee retrieved and an amount (`:673-678`).
11. **Slip** = the stored `EmployeePayment` row joined to the employee (Crystal layout not read: **Not understood** how the printed slip lays out earnings and deductions).

### B3.4 Flow

Register -> daily attendance -> (any time) advance -> at payday: choose employee and dates -> the screen counts days and overtime -> type rate and deduction -> save and print slip. Ledger rows and the advance repayment are written by the same save.

### B3.5 Quirks and probable bugs

| # | Quirk | Verdict |
|---|---|---|
| 1 | Divisor 30 for every month and no weekly-off or paid-holiday rule; a person present on all 31 days of a 31-day month earns more than the monthly salary | Make it a setting (days in month, 26, 30), default to calendar days of the month. |
| 2 | Overtime rate must be a whole number; a decimal rate silently gives the old amount | Fix: decimal rate. |
| 3 | Negative overtime (short hours) reduces pay with no switch | Make "pay short time" a setting. |
| 4 | The only deduction allowed is a repayment of an advance (deduction cannot exceed the advance); fines, PF, ESI, tax cannot be deducted | Add typed deductions and statutory ones as pack rules (India module). |
| 5 | "Date From" may not equal "Date To", so a single-day payment is impossible; the day count includes both dates | Fix. |
| 6 | Attendance by text times; overtime stored as text, summed by parts | Store minutes as a whole number. |
| 7 | An attendance row can be added for a day when the payment for that range was already made; nothing locks it | Lock days already paid. |
| 8 | The "Advance" amount on the slip is the all-time outstanding before this payment; it is not shown reduced after the repayment | Show both. |
| 9 | Ledger entries use text employee ids (`EMP-n`) while the tables use the row ID | One key. |
| 10 | The party figure of the employee in the ledger nets to zero (both rows are on the same party id) | Use a real payable account if an employee payable is wanted. |

### B3.6 Test vectors (hand-worked; double arithmetic, `Math.Round` half to even; rupees)

| # | Input | Result |
|---|---|---|
| P1 | Salary 30,000.00; present 30; no overtime; deduction 0 | Salary 30,000.00; Net 30,000.00 |
| P2 | Salary 30,000.00; present 26 | `30000 * 26 / 30` = 26,000.00 |
| P3 | Salary 18,500.00; present 22 | `407000 / 30` = 13,566.666... -> 13,566.67 |
| P4 | Salary 10,000.00; present 15 | 5,000.00 |
| P5 | Salary 12,345.00; present 7 | `86415 / 30` = 2,880.50 |
| P6 | Overtime 5:30:00, rate 100 | 330 minutes x 100 / 60 = 550.00 |
| P7 | Day overtimes +01:15:00, -00:30:00, +02:00:00, rate 80 | hours 1+0+2 = 3, minutes 15-30+0 = -15, seconds 0 -> 02:45:00 = 165 minutes; 165 x 80 / 60 = 220.00 |
| P8 | Overtime rate typed 12.5 | does not parse; amount unchanged (0.00 for a new payment) |
| P9 | Salary 26,000.00 + overtime 550.00, deduction 2,000.00 (advance outstanding 5,000.00) | Net 24,550.00; an `AdvanceEntry` row (amount 0, deduction 2,000.00) is added; outstanding becomes 3,000.00 |
| P10 | Same, deduction 6,000.00 | refused: "You can not deduct amount more than advance amount" |
| P11 | Salary 100.00, deduction 100.00 (advance 100.00) | Net 0.00: refused "Net pay should be more than 0" |
| P12 | New payment 1 to 15 April when 10 to 20 April is already paid | refused "Salary already paid..." |
| P13 | Basic time 08:00:00, in 09:00, out 18:30 | overtime 01:30:00 |
| P14 | Basic time 08:00:00, in 09:00, out 16:00 | overtime `-01:00:00` |
| P15 | Status A | in `00:00:00`, out `00:00:00`, overtime `00:00:00`; counts as 0 present |
| P16 | Same employee, same date saved twice | second refused: "Employee today's attendance is already saved" |
| P17 | Advance entry 5,000.00 | `AdvanceEntry(5000, 0)`; two ledger rows "Payroll Advance" of 5,000.00 |
| P18 | Cash payment, Net 24,550.00 | `LedgerBook`: row 1 name "Cash Account" 24,550.00 (first money column), row 2 employee name 24,550.00 (second money column), label "Payroll Payment" |

### B3.7 What the Hub has today

Nothing: no employee master, attendance, payroll, advance or payment of staff (`06-hub-map.md` 6.3 lists "staff" as a new master). The Hub's `users` table is for sign-in and roles only. A port needs new tables (all with `tenant_id` and `site_id`), an India payroll rule set kept as pack data (PF, ESI, professional tax, TDS are **not** in the old code, so there is nothing to port for them), and decisions on the quirks above (the old figures P3, P5 depend on the fixed 30 and on half-to-even rounding, so goldens must say which rounding the port uses; the Hub's half-up rounding would give the same figures for P1 to P7 and P9 and differs only when a result is exactly on a half paisa).

## C. What the Hub has today, porting notes, not understood

### C.1 Hub against the old POS, in one table

| Area | Old POS | Hub today | Same numbers? |
|---|---|---|---|
| Line tax, exclusive prices | double arithmetic, each tax part rounded half-to-even | integer, half up, CGST = SGST = half of rate on its own | yes except at an exact half paisa (0.5% to 1.3% of small prices: E7, E8) |
| Line tax, inclusive prices | tax = price less price/(1+rate), halved, each half rounded half-to-even; CGST = SGST always | taxable rounded half up, tax = rest, CGST = half rounded up, SGST = rest | **no in about 50% of prices** (taxable and tax differ by 1 or 2 paise; line total the same) |
| Cess | per product percent; wrong when inclusive | engine supports; **no input path** | exclusive yes (E6); inclusive no (I6) |
| Line discount | percent or amount; half-to-even | percent only (the engine also takes an amount; not passed) | D2 differs at an exact half |
| Bill discount | taken off after tax; does not change tax | none | n/a |
| Round-off | half-to-even `Math.Round(x, 0)`; tick box per bill | half up; per-document flag | no at an exact .50 with an even rupee part (B3, B5) |
| Inter-state | by state name; empty = same state | by region code | same result when names map to codes |
| Reverse charge on purchases | yes (per bill) | none | n/a |
| TCS | rule, label, typed amount, 4 record screens | none | n/a |
| E-way bill | provider API; generate, cancel | none | n/a |
| GSTR-1 / 3B / registers / HSN | Excel-only lists as in A2 to A4 | `TaxSummary` by rate code only | n/a |
| Salesman, broker, transporter, route, employee | as in B1 to B3 | none | n/a |
| GSTIN | stored on customer, supplier, company; two patterns; scrape lookup; stub validator | `parties.tax_id`; pattern in the pack; no screen was checked | n/a |

### C.2 Decisions the porting work needs (not made here)

1. **Inclusive-price tax split.** The old POS and the Hub disagree on about half of all inclusive prices by a paisa or two. Options: (a) keep the Hub engine (legally cleaner; old bills re-read from the old database keep their stored amounts, new bills differ); (b) add an "old rounding" mode to the India pack for customers who must match old books to the paisa. The study recommends (a), with the stored old amounts imported as they are.
2. **Bill-level discount.** The old POS subtracts it after tax. The Hub has none. Decide: line allocation (tax falls too) or a post-tax adjustment.
3. **Round-off mode.** Half-to-even (old) or half up (Hub). Recommended: half up (A1.5 quirk 1).
4. **Commission base** (B1 quirk 2): taxable value after line discount is recommended.
5. **TCS and e-way bill**: both are rules that change by law; put them in the India pack as dated data and make them off until the owner turns them on (`CLAUDE.md` section 8). The e-way call leaves the machine, so it is an explicit opt-in feature (section 15), with its credentials in the operating system's credential store.

### C.3 Porting notes (how the India rules should live)

- **Country module, not neutral code** (`CLAUDE.md` section 8). Everything above except the engine arithmetic is India-only: state codes (including legacy 25, 28 and 99 for old GSTINs), GSTIN pattern and check digit, the B2CL cut-off and "between states" rule, the e-way threshold and goods rules, the TCS rule table, GSTR-1 and GSTR-3B layouts, the HSN digit rules, payroll statutory rules. Keep them in `country-packs/packs/IN.json` (data) and an India module (code) that loads only when the pack's `tax.model` is `gst-india`. A neutral shop must see none of it.
- **Extend the engine, not the screens**: pass `CessPercent`, `DiscountAmount` and an HSN code on each document line; store the buyer GSTIN and state on the document when it is made (A4 quirk 6); keep per-line classification (taxable, nil, exempt, non-GST) in the stored result so that GSTR-1 and GSTR-3B can be worked per line, which is what the portal needs and what the old code could not do.
- **Reports from stored results**: B2B, B2CL, B2CS, CDNR, CDNUR, HSN summary, registers and a GSTR-3B summary can be produced from `documents` and `documents.result` once the above fields exist; no new arithmetic is needed. The goldens are A2.6, A3.6, A4.5.
- **Port order that follows `docs/MERGE-PLAN.md` step 3**: (1) engine inputs (cess, fixed discount, HSN, bill discount rule); (2) the three registers and GSTR-1; (3) GSTR-3B and purchase-side reverse charge; (4) TCS; (5) e-way bill as an optional adapter; (6) the staff module (salesman, broker, then payroll).
- **The old data move** (`MERGE-PLAN.md` step 1) must map: `InvoiceInfo.TaxType` (GST or NON GST) to the document's registered flag; line `STaxType` (Inclusive, Exclusive, Exempt GST, No Taxes) to the document's include-tax flag and a rate code (`GSTEX`, `GST0`); `Product.CGST + SGST` to a rate code (a 0.25% product shows as 0.24 and needs a manual mapping); state names to two-digit codes (names come from `tbl_state`, not in the repository); `Invoice_Product.TaxableAmt` and the stored CGST/SGST/IGST amounts must be **imported as stored, never recomputed** (the Hub's inclusive split differs); `FreightCharges` with `BillSundry='TCS'` to a TCS adjustment; `SalesReturn` header taxable is not stored (A4 quirk 2), so rebuild it from the return lines.
- **Printed headings**: the sale title ("Tax Invoice" or "Bill of Supply") comes from the per-terminal table `InvoiceHead` (default `Bill of Supply` when the row is missing; `frmPOSNew.vb:8592-8624`), a setting not a rule; sales returns print a credit note (`rptCreditNote`); a debit-note report (`rptDebitNote`) exists but what opens it was not traced.
- **Composition scheme**: the old POS has no composition mode (the word appears only in a label of GSTR-3B).

### C.4 Not understood

1. The Crystal report layouts (`.rpt`): the printed salary slip, the salesman ledger's opening and running balance, the invoice print formulas. Only the data they receive was read.
2. What fills `DataGridView3` in the till (used by the TCS base) and exactly when the touch till's two commission mechanisms are both meant to run.
3. The compiled `DevNet.GS` validator (the recovered source is an empty stub) and the provider behind the e-way API (the program only knows a URL, a user name and a password that the owner types).
4. The three item-wise record screens for sales returns, purchases and purchase returns (`frmSalesReturnRecord_GSTR`, `frmPurchaseRecord_GSTR`, `frmPurchaseReturnRecord_GSTR`) were not read; `frmGstNonGst` was not traced; the cell-by-cell column map of the till grid was read only where the tax and commission code used it.
5. Column types of `Salesman_Commission`, `TCSValid` and `EwayBill` and the `tbl_state` names (the database script is not in the repository, `docs/MERGE-PLAN.md`): so how SQL Server rounds an unrounded commission on store is not known.
6. Whether the 32-bit program runs doubles at extended precision in the half-cent cases marked (H): the goldens marked (H) were worked with ordinary 64-bit doubles; confirm on a real Windows PC.
7. Offers, loyalty points, coupons and gift cards feed the bill discount (`alldiscountcalc`, `frmPOSNew.vb:17358`) that is taken off after tax (A1.3 step 8); their own rules were not studied here.

### C.5 What was checked and what was not

Checked: the source lines cited were read; every number in the vector tables was worked out by following the code's arithmetic step by step (a short throw-away script was used only to do the double arithmetic and the Hub's integer arithmetic; it lives only in the session's scratch folder, not in the repository, and no repository file other than this one was written). Not checked: nothing was run, built or tested; no Windows PC, no database and no printer were used; no run of the old program confirmed any figure; the legal statements marked "outside knowledge" (B2CL limit, TCS withdrawal, GSTIN check digit, e-way tolerance) come from general knowledge, not from the repository, and need an accountant's confirmation. This is a study, not finished product work.
