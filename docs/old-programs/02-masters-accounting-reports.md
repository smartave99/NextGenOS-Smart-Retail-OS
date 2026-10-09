# Old Windows POS, study 02: masters, accounting books and reports

Status: first pass of every topic is written (A1 customers, A2 products, A3 suppliers, B accounting books, C reports). Nothing here was run: it was read from the source. Section D lists what was not understood; it is the work list for a second pass.

Written 7 October 2026 by reading the recovered source of `apps/pos-desktop` (read-only study; nothing was built or run). The source is the owner's own (`docs/PLATFORM-DECISIONS.md`, decision 27). File and line numbers are of the files as they were on that day. Where a thing was not understood it says "Not understood".

## 0. What to know first

1. **Money position is a running account per party** (`CustomerLedgerBook`, `SupplierLedgerBook`): balance = sum(Credit) - sum(Debit). Customer normally negative (they owe), supplier normally positive (we owe). The Hub works per unpaid document; add an account view and golden tests A1.2, A3.2.
2. **Credit limit has an on/off flag** (`Lstatus`); "No" means unlimited. Check: refuse when (balance - credit on this bill) < 0 and its size > limit and flag Yes. The Hub treats limit 0 as no credit. Tests L1 to L10 (A1.3).
3. **The books are not double entry.** One row or a pair of rows per event; Cash, Bank, expense and income names use a mirrored sign (Credit = money in). The trial balance does not balance; the balance sheet is built from windowed sums (B). Rebuild on a real journal; convert signs on import.
4. **Profit and loss is cash-style** (sales + income - purchases - expenses - payroll - opening stock; no closing stock). The real cost profit is `sum(Margin)` per bill line, using the last purchase price snapshot (`EPPrice`). The Hub keeps no line cost: add it (B6).
5. **Loyalty has two schemes** (percent of bill into `LPoint`; per-line points into a ledger with `Company.Loyality_perpoint` money value). The owner must pick one for the Hub (A1.6). Coupons and gift vouchers are marked used **before** the bill is saved, and gift expiry is tested wrongly (A1.7, A1.8).
6. **Several columns hold the wrong thing by name:** `Product.ReorderPoint` = wholesale price; `Gift.DiscPerc` and `CustomerOffer.DiscPerc` = money amounts; `Product.Barcode` = "0" (real barcodes are per stock row in `Temp_Stock`). Import with the maps in this file.
7. **Discount that wins on a line:** customer percent (if on) > item offer (`Offer2`) > product discount; the quantity bands (`Product_discount`) then override on a quantity change, and a quantity outside every band gets the **largest** band discount (probable bug) (A1.9, A2.8).
8. **GST is stored as two half rates** (CGST = SGST = rate / 2); bulk GST change matches on the old half rate; .NET banker's rounding breaks odd rates (A2.1, A2.6).
9. **Stock movement report is fragile:** opening figure is saved at event time and goes stale for back-dated entries; purchase `GrandTotal` includes the supplier's previous due, so it must be subtracted in any total (C3, C7).
10. **Not read:** every Crystal report layout (`rpt*.rpt`). Section D lists the open questions; the data import should check balances against the old ledgers (sum Credit - sum Debit per party) before go-live.

## 0.1 How to read this file

- `B/` means `apps/pos-desktop/Source/SmartAvenue99_POS_VB/SmartAvenue99 POS/BillPoint/`. A reference like `B/ModFunc.vb:254` is a file and a line in that folder. The recovered code is decompiled, so lines are many and names like `flag21` mean nothing.
- "Table" names are those of the old SQL Server database (`apps/pos-ai-companion/src/SmartRetail.AI.Core/Data/PosSchemaData.cs` lists them; it holds the columns of only 22 of the 190 tables, the rest are read from the SQL strings in the code).
- Every ledger table has the same columns: `Date, Name, LedgerNo, Label, Debit, Credit, PartyID` plus a party-name column. "Dr" means Debit, "Cr" means Credit.
- Money is `decimal(18,2)`. Rates are `decimal(18,2)`. Quantities are `decimal(18,3)`.
- "Keep" or "Fix?" in a quirk means: keep the old behaviour in the Hub, or the old behaviour looks wrong and the owner or a lead should decide.
- Worked examples are called TV (test vector) and numbered per topic. They were worked by hand from the code, not run.

## A. Masters

### A1. Customers

Status of this topic: written (first pass). Covers the master, the customer ledger and balance, credit limit and terms, receipts, outstanding and debtors, turn-around days, loyalty (two schemes), coupons, gift vouchers, bill-range offers, item offers, buy-X-get-Y promotions, customer discount, wallet.

#### A1.0 The four things to know

1. **A customer's money position is a running account, not a list of unpaid invoices.** `CustomerLedgerBook` has one row per event. Balance = sum(Credit) minus sum(Debit). Positive means the shop owes the customer (shown "Cr"); negative means the customer owes the shop (shown "Dr"); zero shows "Cr" (`B/frmCustomerLedger.vb:534-557`). The Hub works the other way round: per unpaid document (`DocumentService.Outstanding`).
2. **The credit limit has an on/off flag.** `Customer.Lstatus` = "Yes" turns the limit on; with "No" the customer has unlimited credit whatever `Customer.Limit` says (`B/frmPOSNew.vb:10614`). In the Hub a limit of 0 means no credit at all (`DocumentService.cs:299`). Opposite meaning.
3. **There are two loyalty schemes in the code.** The older till `frmPOSNew` earns points as a percent of the whole bill (table `LPoint`). The touch tills `frmPOSTouch` and `frmPOSNewTuch` earn points per product line and keep a points ledger (`CustomerLedgerBook_Loyality`). The touch tills still carry the old fields too. The owner must say which one the Hub should follow (section A1.6).
4. **Several amount columns are mis-named.** `Gift.DiscPerc`, `CustomerOffer.DiscPerc` hold money amounts, not percents. `Product.ReorderPoint` holds the wholesale price (see A2). Do not trust a column name; use the tables below.

#### A1.1 Customer master

**What a person sees.** Screen `frmCustomer` (`B/frmCustomer.vb`): name, address, city, state (a fixed list of Indian states and territories), zip, contact number, e-mail, remarks, GSTIN, PAN, CIN, bank details (account name, number, bank, branch, IFSC), photo, "TCS applied" (Yes or No), "credit limit" Yes or No plus an amount, "route", "turn-around days", "discount %" with Yes or No, opening balance with CR or DR, opening loyalty points with CR or DR, a "loyalty on" tick box, and a shipping ("permanent") address. A customer picker (`frmCustomerRecord`) and quick-add inside the tills (`B/frmPOSNew.vb:19661`, `B/frmPOSNewTuch.vb:21313`) use the same table.

**Table `Customer`** (all columns are in `PosSchemaData.cs`; meaning added here):

| Column | Meaning |
|---|---|
| `ID` | Number, set by the program as highest ID plus 1 (not an identity column) |
| `CustomerID` | Code "C-" plus the ID padded to 4 digits ("C-0007") |
| `Name`, `Address`, `City`, `State`, `ZipCode`, `ContactNo`, `EmailID`, `Remarks` | As typed. Name and contact number must each be unique |
| `GSTIN`, `PAN`, `CIN`, `AccountName`, `AccountNumber`, `Bank`, `Branch`, `IFSCCode` | As typed |
| `Optype`, `Opbal` | Opening balance type ("CR" or "DR") and amount |
| `Photo`, `QrCustomer` | Photo saved as JPEG; QR image made from the contact number or card number |
| `Tcs` | "Yes" or "No": TCS (tax collected at source) applies to this customer |
| `CardNo`, `Status` | Loyalty card number and "Activated" or "Deactivated" |
| `Limit`, `Lstatus` | Credit limit amount, and "Yes" or "No" for whether the limit is enforced |
| `Route` | Delivery route name (table `Route`) |
| `Taround` | Turn-around days: how often the customer is expected to come back |
| `Lvisitdate` | Date of the last bill; set when a bill is saved (`B/frmPOSNewTuch.vb:24958`) |
| `DiscPer`, `DiscStatus` | Fixed discount percent for this customer, "Yes" or "No" |
| `OpLoyalitytype`, `OpbalLoyality` | Opening loyalty points and "CR" or "DR" |
| `is_loyalityDisable` | 0 = loyalty works for this customer, 1 = switched off (the screen tick box ticked gives 0) |
| `shippingAddress` | Second address |

**Rules** (`B/frmCustomer.vb`):
1. New ID and code: read the highest `Customer.ID`, add 1, pad with zeros to 4 digits when the number is up to 999 (`:1604-1650`). Code is "C-" plus that text.
2. Required on save: name, address, city, state, contact number, "TCS applied" chosen, turn-around days not blank (`:2881-2913`). Company profile must exist first (`:2867`).
3. Refused: a name already used, a contact number already used (`:2919-2943`).
4. The customer named "Cash" is the walk-in customer; it may not be edited (`:3148`), gets no loyalty card (`B/frmLCardIssue.vb:869`), no coupon (`B/frmCouponGenerate.vb:1460`) and no gift voucher (`B/frmPOSNewTuch.vb:27212`).
5. Delete is refused when the customer appears in receipts (`CreditCustomerPayment`), bills (`InvoiceInfo`), quotations, services, estimates or journal entries (`:1693-1773`).
6. Renaming rewrites the name in `LedgerBook`, `CustomerLedgerBook` (both `Name` and `CustNameid`), the two loyalty ledgers and `Journal` (`:3239-3297`), so old rows follow the new name. Rows are matched by `PartyID` (the code), which never changes.
7. Opening balance: written into both `LedgerBook` and `CustomerLedgerBook` with the date **today** (not the start of the financial year): "DR" gives Debit = amount, "CR" gives Credit = amount, label "Opening Balance", ledger number = customer code (`:3011-3020`). Opening loyalty points are written the same way into the two loyalty ledgers (`:3021-3030`): "DR" gives Debit, "CR" gives Credit.
8. A trial copy refused the sixth customer (`:2845-2863`). This is a licence thing; the Hub does not copy it.

**Quirks.** Keep: code format "C-0007". Fix?: the code is built from "highest ID plus 1", so two counters saving together can collide; the Hub should use a sequence. Fix?: opening balance dated "today" means a report over an earlier window leaves it out; the Hub should date it at the opening date the owner gives.

#### A1.2 Customer ledger, balance and statement

**Tables.**
- `CustomerLedgerBook(ID, Date, Name, LedgerNo, Label, Debit, Credit, PartyID, CustNameid, Remarks)` (insert at `B/ModFunc.vb:663-680`). `PartyID` = customer code. `CustNameid` = name + "-" + code. `LedgerNo` = the document number (bill, receipt, return). `Name` = the customer's name for sales, but "Cash Account" or "Bank Account" for receipts. `Remarks` = narration.
- `LedgerBook` (the general ledger, section B) gets a mirror row for every event (`ModFunc.LedgerSave`, `:251-267`).
- Loyalty ledgers: A1.6.

**What posts to `CustomerLedgerBook`** (each is Debit D or Credit C, from the code lines shown):

| Event | Label | Side | Amount | Source |
|---|---|---|---|---|
| Opening balance DR / CR | Opening Balance | D / C | opening amount | `frmCustomer.vb:3013-3019` |
| Bill saved | Sales | D | bill grand total | `frmPOSNew.vb:10870` |
| Each payment line of a bill: By Cash | Receipt (name "Cash Account") | C | the line amount | `frmPOSNew.vb:10900` |
| Each payment line of a bill: By Cheque, By Credit Card, By Debit Card, PhonePe, Google Pay, Paytm, E-Wallet | Receipt (name "Bank Account") | C | the line amount | `frmPOSNew.vb:10901-10910` |
| Payment line "Credit Terms - 7 / 15 / 30 / 60 / 90 / 120 / 180 days" or "Credit Terms - Adjust" | nothing | none | the amount simply stays owing | `frmPOSNew.vb:18243` (the list); no ledger call for it |
| Receipt from a credit customer | Receipt (name "Cash Account" or "Bank Account") | C | receipt amount | `frmCreditCustomerReceipt.vb:2148-2152` |
| Receipt from the service desk | Receipt | C | amount | `frmCustomerSupport.vb:2323` |
| Sales return | Sales Return | C | return grand total | `frmSalesReturn.vb:3292` |
| Sales return paid back in cash | Cash Return | D | return grand total (nets the line above) | `frmSalesReturn.vb:3297` |
| Service bill | Services (D, total) then Receipt (C, paid) | | | `frmServiceBilling.vb:1370-1371` |
| Refund / receive journal ("frmRefundAmt") | Journal | C for "Receive", D for "Payment" | amount | `frmRefundAmt.vb:1687-1706` |

**Balance rule** (the single rule for the whole program): `balance = isnull(sum(Credit),0) - isnull(sum(Debit),0)` over **all dates** for one `PartyID` (`B/frmCustomerLedger.vb:534`, same in `frmPOSNew.vb:16797`, `frmCreditCustomerReceipt.vb:1060`). Display: `abs(balance)` with two decimals and "Cr" when balance >= 0 (blue), "Dr" when balance < 0 (red) (`frmCustomerLedger.vb:545-557`).

**Statement** (`frmCustomerLedger`, `:445-505`): rows of one customer in a date window, ordered by `ID, Date, LedgerNo`: `Date, Name, LedgerNo, Label, Credit, Debit, Remarks`. The running balance and the opening balance of the window are worked out inside the Crystal report file, which could not be read here. **Not understood:** whether the report adds the balance before the window as an opening line. The Hub must decide this and test it (see TV in A1.2).

**Edit and delete.** Editing a bill or a receipt does not add reversing rows: it calls `CustomerLedgerUpdate` or `LedgerUpdate` to change the matching row by `LedgerNo` + `Label` (`ModFunc.vb:487-521, 695-730`), and deleting calls `CustomerLedgerDelete(LedgerNo)` which deletes **every** row with that ledger number (`ModFunc.vb:683-692`). So history is not append-only. The Hub's invoices and credit notes are append-only, which is better; keep the Hub's way.

**Test vectors A1.2** (all by hand from the rules above; "today" is irrelevant):

| # | Inputs | Rows written to `CustomerLedgerBook` | Balance shown |
|---|---|---|---|
| C1 | New customer, opening "DR" 500.00 | Opening Balance, Debit 500.00, Credit 0 | -500.00, "500.00 Dr" |
| C2 | New customer, opening "CR" 200.00 | Opening Balance, Debit 0, Credit 200.00 | +200.00, "200.00 Cr" |
| C3 | Bill 1,000.00, paid By Cash 1,000.00 | Sales D 1,000.00; Receipt (Cash Account) C 1,000.00 | 0.00, shown "0.00 Cr" |
| C4 | Bill 1,000.00, By Cash 400.00 + "Credit Terms - 30 days" 600.00 | Sales D 1,000.00; Receipt (Cash Account) C 400.00 | -600.00, "600.00 Dr" |
| C5 | Bill 1,000.00, By Cash 300.00 + PhonePe 200.00 + "Credit Terms - 7 days" 500.00 | Sales D 1,000.00; Receipt (Cash Account) C 300.00; Receipt (Bank Account) C 200.00 (plus a `BankAccountLedger` row "Sale-PhonePe" Credit 200.00) | -500.00, "500.00 Dr" |
| C6 | After C4, receipt 500.00 by cash | Receipt (Cash Account) C 500.00 | -100.00, "100.00 Dr" |
| C7 | After C4, receipt 800.00 by cash (more than owed; nothing stops it) | Receipt C 800.00 | +200.00, "200.00 Cr" |
| C8 | After C4, sales return 250.00 not paid back | Sales Return C 250.00 | -350.00, "350.00 Dr" |
| C9 | After C4, sales return 250.00 paid back in cash | Sales Return C 250.00; Cash Return D 250.00 | -600.00, "600.00 Dr" |
| C10 | Customer with no rows at all | none | the query returns no row, so the program keeps 0: "0.00 Cr" |

**Hub today.** The Hub has no running customer account. `DocumentService.Outstanding(partyId)` sums `payable_minor - paid_minor` over issued invoices and progress bills (`DocumentService.cs:456-465`). Credit notes and advance payments are not an account balance. A customer cannot be "in credit" with the shop except through a credit note refund choice. **Port:** add a read-only "customer account" view computed from documents and payments (so nothing is double written), and decide with the owner what an unallocated receipt does (the old POS lets it sit as a credit; the Hub refuses with "too-much", `DocumentService.cs:374`).

#### A1.3 Credit limit and credit terms

**Where it is set.** `Customer.Limit` (amount) and `Customer.Lstatus` ("Yes" or "No") in the master; payment modes "Credit Terms - N days" are chosen on the bill.

**Credit modes on a bill.** The list is fixed in code: "Credit Terms - 7 days", "- 15 days", "- 30 days", "- 60 days", "- 90 days", "- 120 days", "- 180 days", "- Adjust" (`B/frmPOSNew.vb:18243`). `CreditAmount()` adds up the payment lines in these modes into `TextBox17` (`:18236-18258`). The number of days is only a label on the payment line: nothing in the code due-dates the amount from it. The Credit Terms Statement report lists bills with a payment mode "like 'Credit Terms%'" in a window (`B/frmCreditTermsStatements.vb:294`) and does not age them. **Not understood:** whether the Crystal report ages them by the days in the mode name.

**The check on saving a bill** (`B/frmPOSNew.vb:10591-10619`, repeated in the other save paths `:11353`, `:22723`, `:23400`, and in the touch tills):
1. Credit on the bill (sum of credit-mode lines) must not be more than the grand total, else "Payment/Credit can not be more than grand total".
2. `newBalance = currentBalance - creditOnThisBill`, where `currentBalance` = the Cr minus Dr balance of A1.2 (`TextBox18`), and `TextBox19 = TextBox18 - TextBox17`.
3. If `newBalance < 0` **and** `abs(newBalance) > Limit` **and** `Lstatus = "Yes"`: stop with "Customer Credit limit is exceeded".
4. Equal to the limit is allowed (strictly greater is refused).

**Quirk A (probable bug in one place).** There are two functions that fill `TextBox18`: `CustomerBalance` stores the **signed** balance (`:16861`) and `GetCustomerBalance` stores the **absolute** value (`:16820`). With the absolute version a customer who owes 300 looks like a customer with 300 in credit, and the limit check is wrong. Which one ran last before the check was not traced. **Hub rule:** use the signed version (step 2 above).

**Quirk B.** Step 3 runs even when the bill adds no credit. A customer who is already over the limit cannot buy even for full cash (his `newBalance` is unchanged and still over the limit). "Fix?" The Hub test below shows the intended Hub behaviour; the owner decides whether to keep the old block (it forces old dues to be paid first).

**Test vectors A1.3** (limit rule; `current` is Cr minus Dr, `credit` is the credit on the bill):

| # | Limit, flag | current | credit on bill | newBalance | Result |
|---|---|---|---|---|---|
| L1 | 1,000, Yes | -300 | 700 | -1,000 | allowed (not strictly greater) |
| L2 | 1,000, Yes | -300 | 701 | -1,001 | refused: "Customer Credit limit is exceeded" |
| L3 | 1,000, No | -5,000 | 100 | -5,100 | allowed (flag off) |
| L4 | 1,000, Yes | +500 | 400 | +100 | allowed (not negative) |
| L5 | 1,000, Yes | +500 | 1,600 | -1,100 | refused |
| L6 | 1,000, Yes | -1,500 | 0 (all paid in cash) | -1,500 | refused (quirk B) |
| L7 | 0, Yes | 0 | 1 | -1 | refused (limit 0 with flag on means no credit) |
| L8 | 0, No | 0 | 5,000 | -5,000 | allowed (flag off, any amount) |
| L9 | 1,000, Yes | -999.99 | 0.01 | -1,000.00 | allowed |
| L10 | 1,000, Yes | -999.99 | 0.02 | -1,000.01 | refused |

**Hub today.** `DocumentService.Issue` (`DocumentService.cs:289-304`): when payments are short and the sale is on credit it requires `context.Features.Credit`, a party, and `CreditLimitMinor > 0` (else error "no-credit"), then refuses when `owed + (payable - paid) > CreditLimitMinor` ("over-limit"); due date = issue date + party terms days (else rule `creditDays` default 30). Test: `CoreTests.cs:91-116` ("A_bill_must_be_paid_in_full_unless_the_customer_has_credit_and_room", limit 500,000 minor units, terms 15 days). **Differences:** the Hub has no on/off flag (limit 0 = no credit); the Hub counts only unpaid invoices of the same customer (not advance credit); the Hub gives a real due date from terms days (the old POS did not); the Hub does not stop a cash sale for a customer already over limit (quirk B). **Port:** to match the old numbers add a `credit_limit_on` setting on the party, treat "limit 0 and flag off" as unlimited (owner to confirm), and add tests L1 to L10 as golden tests on `Issue`.

#### A1.4 Receipts from credit customers

**What a person sees.** `frmCreditCustomerReceipt` (`B/frmCreditCustomerReceipt.vb`): pick a customer, see the last ledger lines and the balance (`getdata1`, `:1744`), enter date, payment mode (cash, cheque, online transfer, PhonePe, Google Pay, Paytm, E-wallet), amount, optional bank account (required for every mode except cash), remarks. Save prints a receipt and may send an SMS (`:2190-2213`).

**Tables.** `CreditCustomerPayment(T_ID, TransactionID, Date, PaymentMode, Customer_ID, Amount, Remarks, PaymentModeDetails, BankAcNo)`; `SrReceipt(ID, InvNo)` (the number counter); ledgers `LedgerBook`, `CustomerLedgerBook`, `BankAccountLedger(Date, AccNo, LedgerNo, Label, Debit, Credit)`.

**Rules** (`:2050-2230`):
1. Receipt number `TransactionID` = prefix + "-" + next `SrReceipt` number padded to 4 digits + "-" + suffix. Prefix and suffix come from table `Invcode` (`c6`, `c16`); default prefix "RCPT" and default suffix "year1/year2" of the financial year (`:1171-1212`).
2. Refused: no customer, empty amount, amount 0, bank mode without a bank account number. There is **no** check against the balance (an over-payment makes the customer "Cr").
3. Writes: one `CreditCustomerPayment` row; for cash a `LedgerBook` row (Name "Cash Account", Label "Receipt", Credit = amount, PartyID = customer code) and a `CustomerLedgerBook` row (Name "Cash Account", Credit = amount); for every bank-type mode the same with Name "Bank Account"; for bank-type modes also a `BankAccountLedger` row with Label "Receipt-By Cheque", "Receipt-By Online Transfer", "Receipt-PhonePe", "Receipt-Google Pay", "Receipt-Paytm" or "Receipt-E Wallet", Credit = amount, `AccNo` = the chosen account.
4. Update (`:2232-2330`) rewrites the same rows in place (`LedgerUpdate`, `CustomerLedgerUpdate`) and deletes then re-inserts the bank rows. Delete (`:1281-1302`) removes the receipt and its ledger rows.
5. Receipts are not matched to bills. They reduce the running balance only.

**Test vectors A1.4:**

| # | Inputs | Result |
|---|---|---|
| R1 | Customer balance -600, cash receipt 500.00, prefix/suffix default, `SrReceipt` last = 7, financial year 25/26 | Receipt "RCPT-0008-25/26" (assuming the suffix shows as typed in `F1/F2`; see not understood), ledger Credit 500.00, balance -100.00 |
| R2 | Cheque receipt 1,000.00, account "ACC-1" | `CustomerLedgerBook` Name "Bank Account" Credit 1,000.00; `BankAccountLedger` AccNo "ACC-1", Label "Receipt-By Cheque", Credit 1,000.00 |
| R3 | Bank-type mode with no account chosen | refused: "Please select bank account number" |
| R4 | Amount 0 | refused: "Transaction amount must be greater than zero" |
| R5 | Over-payment: balance -600, receipt 800 | allowed; balance +200 "Cr" |
| R6 | Delete a cash receipt | `CreditCustomerPayment` row removed; all ledger rows with that number and label "Receipt" removed |

**Hub today.** `DocumentService.AddPayment` (`:367-380`) takes a payment on one issued document and refuses more than the balance of that document. There is no receipt number series for receipts alone (a payment belongs to a document), no bank-account ledger. **Port:** a "customer receipt" action that allocates oldest invoice first, with the unallocated rest kept as customer credit (new table), prints a receipt, and numbers receipts through the `Numbering` helper (`Documents/Numbering.cs`).

#### A1.5 Outstanding, debtors and turn-around

- **Customer outstanding** (`B/frmCustomerOutstanding.vb:483-501`): per `CustNameid` in a date window: `sum(Credit)`, `sum(Debit)`, outstanding = `sum(Debit) - sum(Credit)`. Positive (customer owes) is red; negative (customer in credit) is blue; zero is green. Five filter buttons show: owing only, in credit only, zero only, all, and one more (`Condition1..5`, `:517-700`; the fifth was not read). The window is "Date between from and to" with no time, so it works only because dates are stored without a time. **Quirk:** a window report gives the balance **of the window**, not the balance of the customer; the old balances before the window are left out. The customer's true balance is the all-dates rule in A1.2.
- **Debtors report** (`B/frmDebtorsReport.vb:434-464`): same grouping; "customers who owe" = `having sum(Credit) - sum(Debit) < 0` and shows the number as `Credit - Debit` (so negative numbers), "customers in credit" = `> 0`. For suppliers the signs are reversed: `Debit - Credit < 0` and `> 0` (`:494-524`). **Not understood:** the supplier "owed to" list has the test `Debit - Credit < 0` where the supplier balance elsewhere is Credit minus Debit; it looks reversed. See A3.
- **Turn-around days** (`B/frmCustomerRoundover.vb:410-457`): for each customer with `Taround > 0`: `daysSince = today - Lvisitdate`; `overdue = 0` when `daysSince < Taround`, else `daysSince - Taround`. It is a "customer has not come back" list, not money.

**Test vectors A1.5:**

| # | Inputs | Result |
|---|---|---|
| O1 | Window rows: Sales D 1,000.00; Receipt C 400.00 | Credit 400.00, Debit 1,000.00, outstanding 600.00 (red) |
| O2 | Window rows: Opening C 200.00 | outstanding -200.00 (blue) |
| O3 | Customer owed 600 before the window, nothing in the window | row does not appear at all (window excludes the old rows) |
| O4 | `Taround` 30, last visit 20 days ago | overdue 0 |
| O5 | `Taround` 30, last visit 45 days ago | overdue 15 |
| O6 | `Taround` 30, last visit exactly 30 days ago | overdue 0 (`daysSince - Taround` = 0, same as the first branch) |

**Hub today.** `ReportService.Outstanding()` (`ReportService.cs:123-143`) gives ageing buckets (current, 1-30, 31-60, 61-90, over 90 days past due date) per party from unpaid invoices. This is better than the old window report; keep it. Missing: a "not visited for N days" list; `TopCustomers` exists (`:145`). **Port:** add `Taround` as a party setting and the overdue list.

#### A1.6 Loyalty points

There are two schemes. Both write to different tables. A shop uses whichever its till uses; the data of an old shop may hold both.

**Scheme 1: percent of the bill (older till `frmPOSNew`, and the "apply point" box that is still in the touch tills).**

Setup screen `frmLoyaltyvalid` writes one row to `Lpointstatus(c1, c2, c3)`: `c1` = the percent ("Point", labelled "% of Total Bill Amount"), `c2` = "Enable" or "Disable", `c3` = "WITH GST" or "WITHOUT GST" (`B/frmLoyaltyvalid.vb:557-632`). Only one row is allowed ("Record Already Exists", `:592`).

Card issue `frmLCardIssue` sets `Customer.CardNo` and `Customer.Status` ("Activated" or "Deactivated"), makes a QR, refuses the "Cash" customer and an empty card number (`B/frmLCardIssue.vb:868-911`).

Rules (`B/frmPOSNew.vb`):
1. On opening the till: `rate = c1 * 0.01` when `c2 = "Enable"`, else 0 (`:8468-8482`).
2. Points earned on the bill = `GrandTotal * rate` when "WITH GST"; `(GrandTotal - totalGST) * rate` when "WITHOUT GST", where `totalGST = CGST + SGST + IGST + CESS` of the bill (`:16558-16582`, `:17269-17293`). No rounding in the code.
3. On save a row goes to `LPoint(Invno, Invdate, Custid, Custname, Custcontact, Grandtotal, Perc, Addpoint, Usepoint, Coupon)`: `Perc` = rate, `Addpoint` = points earned **only if the customer's card status is "Activated"**, else 0, `Usepoint` = the points used on this bill, `Coupon` = the card number (`:11044-11060`).
4. Balance of points = `sum(Addpoint) - sum(Usepoint)` for `Custid` (`:17304`).
5. Redeeming: the cashier types an amount in "apply point" (`txtApplyPoint`); it is refused with "Loyalty Points can not greater total earn points" when it is more than the balance (`:10552-10555`). One point is worth exactly one currency unit: the same number is used as the discount (`LoyaAmt` on `InvoiceInfo`), see `alldiscountcalc` below.
6. Editing or deleting a bill deletes its `LPoint` rows by `Invno` and writes new ones (`:10301-10353`, `:11845`).

**Scheme 2: per product line, with a points ledger (touch tills `frmPOSTouch`, `frmPOSNewTuch`).**

Setup: `tbl_loyalty_setting` (one row, `id = 1`): `mode` ("per" or "point") and `points` (a number). It is the **default for a new product** and is copied into `Product.loyality_mode` and `Product.loyality_value` when the product is created (`B/frmProduct.vb:7351-7362, 7411-7412`, `frmLSetDefault.vb:75-114`). The value of one point in money is `Company.Loyality_perpoint`.

Rules (`B/frmPOSNewTuch.vb`):
1. Points on a line (`Calc`, `:13392-13410`): mode "per": `x1 = round(rate * qty, 2)`; `points = round(x1 * value / 100, 2)`. Mode "point": `x1 = round(qty, 2)`; `points = round(x1 * value, 2)`. The base is the price times quantity **before line discount and before tax added** (for "Exclusive" tax) and, for "Inclusive" tax, the rate already holds the tax (same formula, `:13447-13456`). The same happens in the other tax branches.
2. Points of the bill = sum of the line points (`:13253`, `:13276`), saved in `InvoiceInfo.TotalLoyalityPoints` and per line in `Invoice_Product.LoyalityPoints`.
3. Points balance = `sum(Credit) - sum(Debit)` of `CustomerLedgerBook_Loyality` for the customer (`:18887`). Money value = balance * `Company.Loyality_perpoint` (`:18906`).
4. Redeeming (`alldiscountcalc_Loyality`, `:18978-18996`), input box `TextBox43`: if the tick box "redeem in points" is ticked, the input is **points**: remaining points = balance - input, and the bill discount (`txtbilldisc`) = input * perPoint. If not ticked, the input is **money**: bill discount = input, remaining points = balance - input / perPoint. The remaining money value = remaining points * perPoint.
5. On save, when the customer's loyalty is on (`is_loyalityDisable = 0`): a **Credit** row of the points earned (label = bill number, remarks "Sale") and, when points were used, a **Debit** row of `balanceBefore - remaining` points (`:24715-24733`). Loyalty ledger rows use the customer **code** as `LedgerNo` and the bill number as `Label` (the reverse of the money ledger). `InvoiceInfo.LoyalityReedemPoints` = points used, `LoyalityReedemAmt` = money value used (`:24585-24587`).
6. The redeemed money is part of the bill discount (A1.9 shows the order of adding).
7. Editing a bill deletes the two loyalty rows of that bill number and writes new ones (`:25716-25730`, `LedgerDelete_Loyality1`, `CustomerLedgerDelete_Loyality1`).
8. I found **no** check that the points redeemed in scheme 2 do not exceed the balance (the message exists only for the old "apply point" box, `:24374-24377`). Not fully traced.

**Quirks.** The earn base ignores discounts, so a discounted line still earns on the full price. Keep or fix? Default keep; the owner decides. Points are not rounded in scheme 1 but are in scheme 2. A card status "Deactivated" stops earning in scheme 1 but not in scheme 2 (which looks only at `is_loyalityDisable`).

**Test vectors A1.6** (all numbers by hand):

Scheme 1 (rate c1 = 2, so 0.02):

| # | Inputs | Result |
|---|---|---|
| P1 | Bill 1,180.00 including GST 180.00, "WITH GST", card Activated | earned 23.60 |
| P2 | Same bill, "WITHOUT GST" | earned (1,180.00 - 180.00) * 0.02 = 20.00 |
| P3 | Same bill, card "Deactivated" | `Addpoint` saved as 0 (the screen still shows 23.60) |
| P4 | `c2` = "Disable" | rate 0, earned 0 |
| P5 | Balance 23.60, apply 30 | refused "Loyalty Points can not greater total earn points" |
| P6 | Balance 23.60, apply 20 | allowed; `Usepoint` 20; discount 20.00; new balance 3.60 |

Scheme 2 (`Company.Loyality_perpoint` = 0.50):

| # | Inputs | Result |
|---|---|---|
| Q1 | Product mode "per" value 5, rate 200.00, qty 3 | `x1` 600.00, points 30.00 |
| Q2 | Product mode "point" value 2, qty 4 | points 8.00 |
| Q3 | Mode "per" value 2.5, rate 100.00, qty 1.5 | `x1` 150.00, points 3.75 |
| Q4 | Bill with Q1 + Q2 + Q3 lines | bill points 41.75; Credit row 41.75 to the loyalty ledger |
| Q5 | Balance 120 points; money value | 120 * 0.50 = 60.00 |
| Q6 | Redeem 50 in **points** | remaining 70; bill discount 25.00; remaining value 35.00; Debit row 50; `LoyalityReedemAmt` 25.00 |
| Q7 | Redeem 25.00 in **money** | bill discount 25.00; remaining points 120 - 25/0.5 = 70.00 (same result as Q6) |
| Q8 | Customer with `is_loyalityDisable` = 1 | no loyalty ledger rows are written |
| Q9 | Product mode "per" value 0 | points 0 |
| Q10 | Redeem 130 points with balance 120 (scheme 2) | not refused by the code that was read (see quirk); remaining -10 |

**Hub today.** Nothing: no loyalty tables or code in `NextGenOS.Hub.Core` (the Hub has `Party.CardBarcode`, `MemberType`, `PriceLevel` only). **Port:** one scheme only, chosen by the owner. Recommended: scheme 2's ledger (append-only points ledger per party, `earn` and `redeem` rows with the bill number), per-item mode and value with a shop default, a points value setting, and a hard stop when redeeming more than the balance (the old scheme 2 has none). Keep both formulas of the line points as written (golden tests Q1 to Q10).

#### A1.7 Coupons

**What a person sees.** `frmCouponGenerate`: tick customers from a list (not "Cash"), type an amount, choose valid-from and valid-to dates and whether the offer is enabled, save. One coupon is made per ticked customer, with a QR image; the coupon can be sent by WhatsApp or SMS. At the till `frmCouponApply` takes the code.

**Table `Coupondb`:** `ID, CID, CustomerID, Name, Address, Contact, DiscType, DiscPernAmt, OfferAmt, ValidFrom, ValidUpto, OfferStatus, CouponCode, CouponStatus, IssueDate, CouponCodeQr`.

**Rules:**
1. Amount must be above 0 and at least one customer ticked (`B/frmCouponGenerate.vb:1649-1655`). `DiscType` is always "Amt"; `DiscPernAmt` and `OfferAmt` both hold the typed amount; `OfferStatus` is "Enabled" or "Disabled"; `CouponStatus` starts "NOT USED"; `IssueDate` = now (`:1705-1727`).
2. Code: 6 characters, each different from the others, drawn from the digits 0-9, the letters A-Z and the two digits of the current seconds (`Auto_Couopon_Generate`, `:1488-1506`). Saving stops with "Coupon Code Already Exists" when a code is already in the table (`:1665-1677`). Because no character repeats, the code space is smaller than 36 over 6.
3. At the till `frmCouponApply` (`:147-237`) checks in this order and says which failed: expired when `ValidUpto < today` ("Coupon Code has already been expired !"); then `CouponStatus = "USED"`; then `OfferStatus = "Disabled"`; then shows name, contact, amount, status, issue date; if no row, "Coupon Code Not Found !". A coupon is valid **on** its `ValidUpto` day.
4. **`ValidFrom` is not checked at the till.** A coupon can be used before its start date.
5. Confirming ("If you once confirm, Coupon code will be Invalid") sets `CouponStatus = "USED"` at once, then puts the amount into the bill's coupon box `txtCoupAmt` and the narration "Used Coupen Code : CODE, Amount : 0.00" (`:349-385`). The status is changed **before the bill is saved**: cancelling the bill afterwards burns the coupon.
6. Amount must be above 0 ("Coupon Code has no sufficient balance !"). The whole amount is added to the bill discount; the code read does not cap it at the bill total. **Not understood:** whether a later step caps the discount at the bill total.
7. The bill saves `InvoiceInfo.CouponAmt`.

**Test vectors A1.7** (today = 10 Oct):

| # | Coupon | Result |
|---|---|---|
| K1 | Amount 0 at generate | refused "Please enter offer amount" |
| K2 | Valid 1 Oct to 9 Oct, status NOT USED, enabled | "already been expired" |
| K3 | Valid 1 Oct to 10 Oct | accepted (last day counts) |
| K4 | Valid 15 Oct to 20 Oct | accepted (start date not checked) |
| K5 | Status USED | "already been Used" |
| K6 | Offer disabled, not used, in date | "Offer has already been disabled" |
| K7 | Order of tests: expired + used + disabled | message is "expired" (first test wins) |
| K8 | Unknown code | "Coupon Code Not Found !" |
| K9 | Accepted coupon of 100.00, confirmed | status USED at once; `txtCoupAmt` 100.00; narration set |
| K10 | Two ticked customers, amount 50 | two rows, two different codes, both "NOT USED" |

**Hub today.** Nothing (no coupon table). **Port:** a `coupons` table with the same fields; check start and end dates both; mark the coupon used **when the bill is issued, in the same transaction**, not before; cap the discount at the bill total (owner to confirm).

**Hub now (8 October 2026, `Offers/OffersService.cs`, database step 9, `OffersTests` K1 to K10 and more).** Done as the port line says. A coupon is made for each chosen customer with its own 8-character code (letters and digits without 0, O, 1, I, drawn from the system's secure generator; the older POS's 6 characters with no repeats were a smaller space), amount, optional first and last day, on or off. At the till the cashier types the code (any case, with or without the dash). The checks are told in the older order (ran out, used, switched off) and a first day still to come is refused too. The coupon is **used when the bill is made, in the same step**, never before: a thrown-away sale leaves it good; two tills with the same code cannot both finish (the second saves nothing); a cancelled bill gives it back. The discount of a coupon is part of the bill discount (spread over the lines before tax) and never goes above the bill. The whole coupon is used even when the bill is smaller (as the older POS did; no change is kept). **Chosen without asking, easy to change:** the coupon shows who it was made for but does not stop another person using the code (the older POS did not check either); nothing is sent to anyone from the Hub (sending a message out of the shop needs the owner's permission, CLAUDE.md section 15). **Not done:** sending a coupon by message, a QR picture on the coupon, a coupon that keeps a balance.

#### A1.8 Gift vouchers

**What a person sees.** `frmGift` (a rule list): "Sale Amount From", "Sale Amount To", "Discount Amount", "From Date", "To Date". When a bill falls into a rule, the till prints a voucher text: "Redeem this Gift on your next purchase having Coupon No. CODE, Amount : X, Valid From : A To : B" (`B/frmPOSNewTuch.vb:26836`). At the next visit `frmGiftApply` takes the code.

**Tables.** `Gift(OfferId, SellAmountFrom, SellAmountTo, DiscPerc, FromDate, ToDate)` (**`DiscPerc` holds the amount in money**: the screen label is "Discount Amount", `B/frmGift.vb:331`; the till reads it into `giftamt`, `:26832`). `GiftInfo(CID, CustID, CustName, InvNo, InvDate, BillAmt, GiftCode, GiftAmt, Validfrom, Validto, Status, Contact, GiftCodeQr)`.

**Rules:**
1. On each bill the till finds the first `Gift` row with `SellAmountFrom <= grandTotal <= SellAmountTo` and `FromDate <= invoiceDate <= ToDate`; `giftamt` = its `DiscPerc` (`:26817-26839`). Only the first row read counts (no "best" rule); overlapping rules are not blocked.
2. At save, when `giftamt > 0` and the customer is not "Cash", a `GiftInfo` row is written: code of 8 characters made the same way as coupon codes (`Auto_Gift_Generate`, `:27085`), `GiftAmt` = `giftamt`, `Validfrom`/`Validto` = the rule's dates, `Status` = "NOT USED", `BillAmt` = grand total (`:27205-27245`). Editing the bill deletes and rewrites the voucher unless it is already used (`:27281-27330`).
3. At the next visit `frmGiftApply` (`:154-215`): "already expired" when `(Validto - Validfrom).Days <= 0`; then "already been Used" when `Status = "USED"`; then shows name, contact, amount, validity, bill number; confirming sets `Status = "USED"` at once and puts the amount into `txtgiftamt` (`:331-376`).
4. `txtgiftamt` is added to the bill discount and saved in `InvoiceInfo.GiftAmt`.

**Quirk (bug, fix).** The expiry test compares the voucher's own two dates (`Validto - Validfrom`), not today. Any voucher whose window is at least one day long never expires, and can be used before its start. The Hub must test `today` against both dates. As with coupons, the status is set before the bill is saved.

**Test vectors A1.8:**

| # | Inputs | Result |
|---|---|---|
| G1 | Rule 1,000 to 4,999, amount 100, dates 1 Oct to 31 Oct; bill 2,500 on 10 Oct, named customer | voucher of 100.00, code of 8 characters, valid 1 Oct to 31 Oct |
| G2 | Same bill, customer "Cash" | no voucher |
| G3 | Bill 999.99 | no rule matches, no voucher |
| G4 | Rule 1,000 to 4,999; bills of 4,999, 4,999.50 and 5,000 | 4,999 gets the voucher (the to-amount is inclusive); 4,999.50 and 5,000 do not (a gap between bands is not covered) |
| G5 | Two rules both match | the first row returned by the database is used |
| G6 | Voucher valid 1 Oct to 31 Oct, used on 20 Nov (window 30 days) | accepted in the old POS (bug) |
| G7 | Voucher valid 5 Oct to 5 Oct (window 0 days) | refused "expired" even on 5 Oct (bug) |
| G8 | Voucher already USED | "already been Used" |
| G9 | Confirmed voucher of 100.00 | `GiftInfo.Status` "USED" at once; `txtgiftamt` 100.00 |

**Hub today.** Nothing. **Port:** a gift-voucher table; rules by amount band and dates; voucher is issued when the bill is issued; redeem test: today inside the validity (both ends), not used; set "used" in the transaction that issues the bill that uses it.

**Hub now (8 October 2026, same files, G1 to G9).** Voucher rules (*Offers → Add an offer → A gift voucher with a bill*): a bill to a **named customer** whose total falls between two amounts (the top may be left empty, which also fixes the gap above the top that the older POS left) earns a voucher of the rule's value for the rule's days, in the same step as the bill. If two rules fit, the bigger voucher is given (the older POS took the first row). The voucher's words on the bill come from *Settings → Words printed when a bill earns a gift voucher* (neutral starting text; `{code}`, `{amount}`, `{valid}` are filled in). A voucher is tested against **today at both ends** (the older POS compared its own two dates, so a long voucher never ran out and a one-day voucher was refused even on its day: G6, G7 differ on purpose) and is used once, when the bill that uses it is made. A cancelled bill switches off the voucher it earned if nobody used it yet. **Not done:** editing a bill (the Hub makes bills final), a QR picture, sending the voucher.

#### A1.9 Offers, item discounts, promotions and customer discount

Four different things feed a bill's discount. All are in the till (`B/frmPOSNewTuch.vb` and the other tills).

1. **Bill-range offer (`CustomerOffer`).** Screen `frmCustomerValid` (labels "Sale Amount From", "Sale Amount To", "Discount Amount", dates; `B/frmCustomerValid.vb:557-577`). The till (`offerstatus`, `:16504-16525`) takes `DiscPerc` (an **amount**) of the first row with `SellAmountFrom <= grandTotal <= SellAmountTo` and the date window containing the invoice date, rounds it to 2 places, puts it in `txtOffer`, then also looks for a gift (A1.8).
2. **Item offer (`Offer2`).** Screen `fromItemoffervalid`: per product, a discount **percent** `DiscPerc` for a date window (`:853-940`). Till (`itemofferstatus`, `:16528-16549`) puts it in `txtItemOffer`.
3. **Buy X get Y free (`Promotion`).** Screen `frmPromotionalOffers` ("Promotional Offer (Buy 'X' and Get 'X')"): `Promotion(ID, EntryDate, ProductID, MinQty, FreeQty, IsExpired, ExpiryDate, Active)`. A product can have one live promotion: a second is refused while one is active or not yet expired (`B/frmPromotionalOffers.vb:1536`). Buttons deactivate all, delete all inactive, delete all expired.
4. **Customer discount.** `Customer.DiscPer` with `DiscStatus = "Yes"`.

Note: the screen `frmCustomerOffer` is **not** a discount rule. It is a customer list for sending an offer message: per customer in a date window it shows name, contact, state, GSTIN, number of bills and total sale (`B/frmCustomerOffer.vb:691`, `sum(GrandTotal)` and `count` of `InvoiceInfo`), with tick boxes and "Send Bulk SMS" / WhatsApp. Sending anything out of the shop needs the owner's permission in the Hub (rule 15). Bill-range offers are saved by `frmCustomerValid`, item offers by `fromItemoffervalid`.

**Line discount percent: which one wins** (`B/frmPOSNewTuch.vb:14406-14418`, repeated at every product pick): 
1. the customer's `DiscPer` when it is above 0 and `DiscStatus = "Yes"`;
2. else the item offer percent (`Offer2`) when above 0;
3. else the product's own `Discount` (`Product.Discount`).
Only one of them is used; they do not add up.

**Promotion rule** (`:12075-12094`, new line `:12140-12167`): a promotion applies when `Active = "Yes"` and `ExpiryDate >= today`. For a line with paid quantity `q`: when `q >= MinQty` the line quantity becomes `q + floor(FreeQty * q / MinQty)` and the free part is saved in `Invoice_Product.PromoQty` (the grid column 29). When a second scan merges into an existing line, the code recomputes from the paid quantity `paid = qty - PromoQty` and **does not** repeat the `q >= MinQty` test, so with FreeQty larger than MinQty the free goods can appear below the minimum (quirk, keep or fix? fix: apply the same test). `Active` and `IsExpired` are separate; the till uses `Active` and the date only.

**Order of adding to the bill discount** (`alldiscountcalc`, `:18955-18975`): `BillDiscount = billDiscountBox (txtbilldisc, which also receives the loyalty redemption in scheme 2) + [applyPoint (scheme 1) if tick 1] + [offer (txtOffer) if tick 2] + coupon + gift`, rounded to 2 places. Ticks 1 and 2 are cashier choices. The coupon and the gift are always added. Saved: `OfferAmt` = offer, `LoyaAmt` = apply point, `BillDiscount` = the typed or loyalty discount, `CouponAmt`, `GiftAmt` (`B/frmPOSNewTuch.vb:24514`, params `:24565-24595`).

**Test vectors A1.9:**

| # | Inputs | Result |
|---|---|---|
| D1 | Customer `DiscPer` 5, `DiscStatus` Yes; item offer 10 %; product discount 2 % | line discount 5 % |
| D2 | Customer `DiscPer` 5, `DiscStatus` No; item offer 10 %; product 2 % | 10 % |
| D3 | Customer `DiscPer` 0, Yes; no item offer; product 2 % | 2 % |
| D4 | Customer `DiscPer` 5 Yes, item offer 0, product 2 % | 5 % |
| B1 | Bill 2,500; `CustomerOffer` 2,000 to 2,999 amount 50, dates cover the day; tick 2 on | offer 50.00 added to the bill discount |
| B2 | Same, tick 2 off | not added (but `OfferAmt` is still saved as shown) - **not understood** whether `OfferAmt` is saved when untick |
| B3 | billDisc 10.00, applyPoint 20.00 (tick 1), offer 50.00 (tick 2), coupon 100.00, gift 30.00 | 10 + 20 + 50 + 100 + 30 = 210.00 |
| B4 | Same with both ticks off | 10 + 100 + 30 = 140.00 |
| Y1 | Promotion Min 3, Free 1; buy 7 | line qty 7 + floor(1*7/3) = 9; PromoQty 2 |
| Y2 | Promotion Min 3, Free 1; buy 2 (new line) | no free goods; qty 2 |
| Y3 | Promotion Min 5, Free 2; buy 12 | 12 + floor(2*12/5) = 12 + 4 = 16; PromoQty 4 |
| Y4 | Promotion Min 3, Free 5; a line already holds 1 paid, a second scan adds 1 (paid now 2) | the merge branch does not test the minimum: floor(5*2/3) = 3 free; line qty 5 (quirk: below the minimum). A first scan of 2 on a new line gets nothing |
| Y5 | Expired yesterday | no promotion; today is last valid day: `ExpiryDate >= today` is true |

**Hub today.** Price levels (`Party.PriceLevel` retail or trade; `Item.PriceFor`) and a per-line discount percent (`document_lines.discount_pct_milli`, 0 to 100 percent in thousandths, error "discount" outside that, `DocumentService.cs:129`). A line also has `customer_discount`, but that is a **country-pack code** checked against `context.Country.Tax.CustomerDiscounts` (`DocumentService.cs:133`), not the old "customer percent". No offers, promotions, coupons, gifts, customer percent or quantity bands. **Port:** these are separate small tables and one "discount resolver" with the priority above and golden tests D1 to D4, Y1 to Y5, B3, B4.

**Hub now (8 October 2026, same files; D1 to D4, Y1 to Y5, B1 to B4).** Built: the customer's standing discount (*People → edit → Always give this much off*, on or off; the older program's customer discount is carried by the data reader), item offers (percent for some days), buy-X-get-Y, and the bill offer. The line percent follows the older order: the customer's rate, else the item offer, else none (they never add up; the Hub has no discount of its own on an item, so the older "product discount" has no place yet: **open**). A line whose discount a person typed keeps it; choosing or changing the customer works the automatic ones out again. Free goods are **a separate line** of the same item at the full discount (stock moves for both, the tax is on nothing, the receipt says "free"); they follow the quantity of the line they came with and are given only when the paid quantity reaches the minimum (the older POS skipped that test when two scans were merged: Y4 differs on purpose). One free-goods offer at a time per item, as before. The bill offer is worked from what the items come to after line discounts and before tax, so that the bands read the same in every country; it is used by itself and the cashier can leave it out and take it again; when two bands fit the bigger one wins. Offers, coupons, vouchers and points all add up as the older B3 sum shows and never exceed the bill. A cashier needs no discount right for any of these, and they do not count against a cashier's limit. A bill made from a quote works offers out again on the day (an offer that ended meanwhile is not applied). **Not done:** quantity bands on an item (A2.8, with the "largest band" quirk to ask about), the message list "customers to send an offer to" (it sends out of the shop: owner's permission first).

#### A1.10 Wallet

`frmWalletList` is **not** a stored-value wallet. It lists the shop's UPI QR codes from `POSPrinterSetting` (`UPIID`, `BrandName`) (`B/frmWalletList.vb:227-236`). "E-Wallet" is only a payment method name that posts to the bank account (A1.2). There is no customer wallet balance in the old POS.

#### A1.11 Porting notes for customers

1. Build the customer account view first (A1.2), then credit limit tests L1 to L10 (A1.3), then receipts with allocation (A1.4), then discounts (A1.9), then the one loyalty scheme the owner chooses (A1.6), then coupons and gifts with the fixes in A1.7 and A1.8.
2. Data import: `Customer.Opbal/Optype` plus all `CustomerLedgerBook` rows give the balance; import the balance as one opening row per customer in the Hub, dated at the day of migration, and keep the old ledger as history. Sum check: `sum(Credit) - sum(Debit)` per `PartyID` must equal the imported balance; report any difference.
3. Do not import `Customer.Limit` as a hard limit when `Lstatus` is "No".
4. Photo and QR image columns can be dropped or kept as files.
5. The two codes "Cash" (walk-in customer) and rows with `ID = 1` should become the Hub's walk-in (no party).

#### A1.12 Not understood (customers)

- Whether the Crystal report of a customer statement shows an opening line for a window, and how it computes the running balance (the `.rpt` files are binary).
- Which of `GetCustomerBalance` (absolute) and `CustomerBalance` (signed) fills `TextBox18` just before the limit check in each till.
- Whether the credit-term day count is used to age bills anywhere.
- The fifth outstanding filter (`Condition5`).
- Whether the discount from a coupon or gift is capped at the bill total.
- Exact column types of `LPoint`, `Lpointstatus`, `Coupondb`, `GiftInfo`, `Promotion` (not in `PosSchemaData.cs`; names come from the SQL).
- The text shown in `F1` and `F2` that makes the receipt-number suffix.

### A2. Products and the product tools

Status of this topic: written (first pass). Covers the product master and its stock rows, categories, units, tax rates, price margins, barcodes and labels, bulk price and bulk GST change, bulk edit, variants, serial numbers, combo packs, quantity discounts, images.

#### A2.0 The five things to know

1. **A product is three layers.** `Product` (one row per product: names, tax, units, default prices), `Product_OpeningStock` (one row per barcode: the stock typed at set-up, with batch, size, colour and its own prices) and `Temp_Stock` (one row per barcode: the live stock and the prices the till reads). The real barcode is **not** in `Product.Barcode` (it is saved as the text "0", `B/frmProduct.vb:7384`); it is in `Product_OpeningStock.Barcode` and `Temp_Stock.Barcode`. A product with several sizes or colours has several barcode rows (`A2.9`).
2. **`Product.ReorderPoint` is the wholesale price.** The screen label "Wholesale Price" saves into that column (`B/frmProduct.vb:7401`, load `:5330`). The reorder level is `Product.MinStock`. `Product.SellingPrice` is the retail price, `Product.MRP` the printed price, `Product.CostPrice` the purchase price, `Product.OpeningStock` is always saved as 0.
3. **Margin is a mark-up on cost**, not a margin on the selling price: `price = cost + cost * percent / 100`; `percent = price * 100 / cost - 100` (`B/frmProduct.vb:8610-8625`).
4. **Prices live in three places and the till reads `Temp_Stock`.** Changing a price in the product screen or in bulk price change writes `Product`, `Temp_Stock` and `Product_OpeningStock` (A2.6).
5. **GST is stored as a half rate.** The screen picks one GST % from the table `TaxCat`; the product stores `CGST = GST/2` and `SGST = GST/2`. IGST is shown as CGST + SGST and is **not** stored on the product (`B/frmProduct.vb:5833-5851`, `:5909`).

#### A2.1 Product master

**What a person sees.** `frmProduct` ("Product Entry", `B/frmProduct.vb`; `frmProductSmart` and `frmProductNew` are other front ends on the same tables): product name (and a second-language name), product code, category, sub-category or brand, HSN code with a link "Check HSN Online", part or group, features (description), purchase price, MRP, retail price, wholesale price, margin percents with an on/off tick box, sales discount %, GST %, CGST, SGST, CESS, tax type on sale and on purchase, purchase main unit, sales main unit, alternate unit with conversion value, minimum stock, default sale quantity, rack, godown (store), kitchen (restaurant), up to a limit of images, active or inactive, opening stock rows (quantity, MRP, prices, batch, manufacturing and expiry date, size, colour, barcode, IMEI 1 and 2, cipher codes) and "loyalty mode and value" (A1.6).

**Tables and columns** (`Product` is fully listed in `PosSchemaData.cs`):

| Column | Meaning |
|---|---|
| `PID` | Number: highest `PID` + 1 (not an identity column) |
| `ProductCode` | "P-" + `PID` padded to 4 digits ("P-0012") |
| `ProductName` | Name. Name plus `PartNo` is checked for a duplicate but the person may carry on (a warning only, `:7244-7260`) |
| `SubCategoryID` | Link to `SubCategory.ID`; the category comes through the sub-category |
| `HSNCode`, `PartNo`, `Description` | Description defaults to the product name when no features are typed (`:7375-7380`) |
| `CostPrice` | Purchase price |
| `SellingPrice` | Retail sale price |
| `ReorderPoint` | **Wholesale sale price** (see A2.0) |
| `MRP` | Printed maximum price |
| `Discount` | Default sales discount percent |
| `CGST`, `SGST`, `CESS` | Half GST rate each, and cess percent |
| `Barcode` | Always "0" for new products |
| `OpeningStock` | Always "0" |
| `PurchaseUnit`, `SalesUnit`, `SalesAltUnit`, `Conv` | Units (A2.3); `Conv` = number of alternate units in one main unit |
| `MinStock` | Reorder level (stock below it is "low stock") |
| `Status` | "Yes" active, "No" inactive (`:7394`) |
| `STax`, `PTax` | Tax type on sale and on purchase: "Inclusive", "Exclusive", "Exempt GST" or "No Taxes" |
| `GDown`, `Rack`, `Kitchen` | Store, rack and kitchen section names |
| `DefQty` | Default sale quantity; "0" or empty is saved as "1" (`:7404-7409`) |
| `AddDate` | Date added |
| `LastPrice` | The **last sales rate charged** for the product: set when a bill is saved (`update Product set LastPrice = rate`, `B/frmPOSNewTuch.vb:24876`, `frmPOSNew.vb:10985`) and shown on the till as "last price"; not set on this screen |
| `loyality_mode`, `loyality_value` | Loyalty rule of this product, copied from `tbl_loyalty_setting` at creation (A1.6) |

**Validation on save** (`:7140-7230`, in this order, first failure stops): company profile exists; product name; category; sub-category; sale tax type; purchase tax type; purchase price typed; discount % typed; GST % chosen; minimum stock typed; purchase unit; sales main unit; alternate unit; conversion value; default sale quantity; MRP above 0; retail price above 0; wholesale price above 0; barcode typed. A barcode that already exists in `Product_OpeningStock` or `Temp_Stock` is refused (`:7270-7340`). A trial copy was limited to 5 products.

**Writes on creating a product** (`:7369-7710`): one `Product` row; one `Product_Join` row per image (JPEG); one `Product_OpeningStock` row per opening-stock grid row (or one row from the main fields when the grid is empty: quantity = typed opening stock, prices from the screen, `PPrice` = cost, `OPSValue` = `round(PPrice * quantity, 2)`); one `Temp_Stock` row per barcode with `Qty`, `Barcode`, `SPrice` (retail), `WPrice` (wholesale), `StLimit` (= min stock), `MRP`, batch, dates, size, colour, `SalePrice`, `WSalePrice`, `SuplName` = "Opening Stock", IMEI, `PPrice` and `EPPrice` (= cost), a QR image, `SalesManPur` 0 and `Variant_id` = the product id; and, for each barcode with quantity above 0, a `StockMovement(ProductID, OpeningStock, StockIn, StockOut, Date, TransID)` row: `OpeningStock` = the movement balance before today (0 the first time), `StockIn` = the quantity, `StockOut` 0, `Date` today, `TransID` = product code (`ModFunc.ProductSMSave`, `:119-139`). Two rows are also written to `ExtDB1(a1, a2)`: the product id with the sales unit and with the alternate unit (`:7695-7710`); what reads this table was not found (**not understood**).

**Update** (`:3446-4153`, `:7767-8479`): rewrites the `Product` row; rewrites price fields of every `Temp_Stock` row of the product (`SalePrice`, `WSalePrice`, `StLimit`); rewrites the stock and opening-stock rows by barcode; and, **when a barcode changes, rewrites the old barcode in every transaction table** (`Invoice_Product`, `Stock_Product`, `Quotation_Join`, `Estimate_Join`, `PurchaseOrder_Join`, `SalesReturn_Join`, `PurchaseReturn_Join`, `Stock_Store_Join`, `StockAdjustment_Store`) so history follows the new barcode (`:3777-4059`). The Hub keeps history by item id, so it does not need this.

**Delete** (`:3255-3411`): refused when the product appears in a stock adjustment, store stock, purchase order, purchase, invoice, quotation or estimate; otherwise deletes its `StockMovement`, `Product_OpeningStock` and `ExtDB1` rows and then the `Product`. (`Temp_Stock` and `Product_Join` rows are not deleted in the code read: **not understood**, maybe database cascades.)

**Test vectors A2.1:**

| # | Inputs | Result |
|---|---|---|
| M1 | Highest `PID` 0 (empty table) | new `PID` 1, code "P-0001" |
| M2 | Highest `PID` 9 | `PID` 10, code "P-0010" |
| M3 | Highest `PID` 999 | `PID` 1000, code "P-1000" |
| M4 | Highest `PID` 9999 | `PID` 10000, code "P-10000" (no cut) |
| M5 | GST % 18 | CGST 9.00, SGST 9.00, IGST shown 18.00 |
| M6 | GST % 5 | CGST 2.50, SGST 2.50 |
| M7 | GST % 0.25 | CGST = `round(0.125, 2)` = 0.12 with .NET's round-half-to-even (so CGST + SGST = 0.24, not 0.25). The Hub must not copy this |
| M8 | Cost 100, MRP margin 50, retail margin 30, wholesale margin 20, margin switch on | MRP 150.00, retail 130.00, wholesale 120.00 |
| M9 | Cost 80, retail price 100 typed | retail margin shown `100*100/80 - 100` = 25 |
| M10 | Cost 0, price typed | division by zero in the margin box (VB gives infinity, no message): the Hub must guard |
| M11 | Default sale quantity left empty or "0" | saved as "1" |
| M12 | Retail price 0 | refused "Please enter Retail Sale Price" |
| M13 | Opening stock 10 at cost 12.50, no grid rows | `Temp_Stock.Qty` 10, `Product_OpeningStock.OPSValue` 125.00, `StockMovement` row (0, 10, 0) dated today |
| M14 | Barcode already used by another product | refused |
| M15 | Same name and part no as another product | warning with Yes/No, may continue |

**Hub today.** `CatalogService` (`Catalog/CatalogService.cs`) and `Item`/`ItemInput` (`Catalog/Models.cs`): `Create`, `Update`, `Get`, `FindByCode` (by barcode or SKU), `Search`, `Categories`, `SetActive`, `OnHandMilli`, `Adjust`, `StockList`. One barcode per item (unique, error "duplicate-barcode"), `PriceMinor`, `TradePriceMinor` (trade price = the old wholesale price; `Item.PriceFor` picks it for a trade customer), `CostMinor`, `TaxClass` (a country tax code, not a half-rate pair), `ReorderMilli`, units as free text "pc" default, quantities in thousandths. **Differences:** no part number or HSN field on its own (the Hub has `Attrs`), no second language name, no per-barcode batch, size, colour or expiry (A2.9), no alternate unit and conversion (A2.3), no per-product discount percent, no loyalty fields, no rack or godown, no images (maybe in Web), no stock movement "opening" row (the Hub has `stock_moves`). **Port:** add `part_no`, `hsn_code`, `discount_pct`, `loyalty_mode`, `loyalty_value`, `min_stock` (use `ReorderMilli`), `alt_unit` and `conversion_milli`; map `Product.ReorderPoint` to the trade price on import, **never** to the reorder level.

#### A2.2 Categories and sub-categories

- **Tables.** `Category(ID, CategoryName, CPhoto)`; `SubCategory(ID, SubCategoryName, Category [the category's name, not its id], SCPhoto, IsDefault)`. A product points to a sub-category by `SubCategoryID`; its category is found through `SubCategory.Category = Category.CategoryName`.
- **Rules.** A category name must be new (`B/frmCategory.vb:913`). A category with sub-categories cannot be deleted (`:477`). A sub-category needs a category and its name plus category must be new (`B/frmSubCategory.vb:1082`); it cannot be deleted while products use it (`:649`); only one sub-category may be the default ("Sub Category is already set as default", `:1103-1109`). Renaming a category rewrites the name in `SubCategory.Category`? **Not understood:** the update statement `:971` changes only `category`; the link `SubCategory.Category` holds the name, so a rename may orphan sub-categories unless the code updates them elsewhere.
- **Test vectors:** CT1 delete a category that has one sub-category: refused. CT2 add sub-category "Milk" under "Dairy" twice: second refused. CT3 add sub-category "Milk" under "Dairy" and "Milk" under "Drinks": both allowed. CT4 two defaults: second refused.
- **Hub today:** `Item.Category` is free text (`CatalogService.Categories()` lists distinct names). No category table, no sub-category. **Port:** keep the Hub's free-text category; import `Category/SubCategory` as `Category > SubCategory` text or add a `sub_category` attribute (owner decides).

#### A2.3 Units and unit buttons

- **Tables.** `UnitMaster(Unit, Description, IsDefault)`. The product holds `PurchaseUnit`, `SalesUnit` (main), `SalesAltUnit`, `Conv`.
- **Rules.** A unit name must be new; only one default unit (`B/frmUnit.vb:658-695`). A unit cannot be deleted when a product uses it as purchase or sales unit (`:353-369`); **the alternate unit is not checked** (quirk, fix). Renaming a unit rewrites `Product.PurchaseUnit` and `Product.SalesUnit` (`:760-778`) but **not** `SalesAltUnit` (quirk, fix).
- **Conversion at the till** (`B/frmPOSNewTuch.vb:17077-17084`): the cashier picks a unit in the unit box. `quantityInMainUnit = typedQuantity / Conv` when the picked unit equals the alternate unit, else `typedQuantity`. The line is priced and stock is taken in main units. The line also keeps `AltQty = mainQuantity * Conv` (`:12063`). Product screen text: "Conversion Value = No(s) of Alter Unit Per Main Unit".
- **Unit buttons** (`frmUnitButton`): a touch pop-up for a scanned barcode with buttons for the main and alternate unit and the default quantity; `calvalue = 1 / Conv * DefQty` is the main-unit quantity of the default quantity (`:303-306`).
- **Test vectors:** U1 main "Box", alt "Pc", Conv 12, sell 6 Pc: main quantity 0.5 Box, line = 0.5 * price per box, `AltQty` 6. U2 sell 2 Box: main 2, `AltQty` 24. U3 Conv 0 and alternate unit picked: division by zero (guard in the Hub). U4 unit "Kg" is used as sales unit: delete refused. U5 unit "Pc" is only used as an alternate unit: delete is **allowed** (bug).
- **Hub today:** `Item.Unit` free text and quantities in thousandths (`qty_milli`); no conversion. **Port:** add `alt_unit` + `conv`; do the division with integers in thousandths and round once (decide rounding).
- **Hub now (9 October 2026):** built the Hub's way, as **two linked items** (the loose item is opened from its box) instead of a conversion, so stock stays exact (`docs/OPEN-WORK.md` item 12p). U1 and the margin example M4 are tests; U3 cannot happen (a pack holds two or more whole pieces).

#### A2.4 Tax rates, tax types, HSN

- **Tables.** `TaxCat(ID, Rate, IsDefault)`: the list of GST percents offered on the product screen; `Setting(PurchaseTax, SalesTax)`: the default tax type for new products; `Defaulttaxtype`; `tbl_state`, `tbl_Defalt_State_Setting` (states and the home state, for CGST/SGST against IGST; read in the till, not traced here).
- **Rules.** A rate may be added once ("GST Rate Already Exists"); only one default ("GST Rate is already set as default"); the product screen fills its GST box from the table and preselects the default (`B/frmProduct.vb:5855-5905`). Tax type words: "Inclusive" (price already holds the tax), "Exclusive" (tax added), "Exempt GST", "No Taxes" (`B/frmProduct.Designer.vb:752,760`). Till arithmetic for these types is in the selling study; the product screen only stores them.
- **HSN.** A free text code on the product (`HSNCode`); no check of length or digits. The link "Check HSN Online" opens a web page. The GST returns group by HSN (reports study).
- **Test vectors:** TX1 add rate 18 twice: second refused. TX2 set rate 12 default while 18 is default: refused on a new rate; on update the code first sets every row to "No" (`B/frmTaxCategory.vb:650`) then saves the chosen row as default (when the "make default" box is ticked).
- **Hub today:** tax by country pack (`ItemInput.TaxClass`, `libs/dotnet/NextGenOS.Tax`); no HSN field. **Port:** HSN as an item attribute used by the India module only.

#### A2.5 Barcodes and label printing

- **Barcode creation.** Typed or scanned, or made by the program: `barcode = Company.BCode + (1000 + nextOpeningStockId)` where `nextOpeningStockId` is the highest `Product_OpeningStock.ID` + 1 padded to 4 digits (`B/frmProduct.vb:2977-3008`, `GenerateID1` `:2928-2965`). Made codes are remembered in `GenerateBarcode(Barcode)` and the last one is used for the next (`:6719-6785`). The prefix `Company.BCode` is a setting of the company.
- **Label printing** (`frmBarcodeLabelPrinting`, `B/frmBarcodeLabelPrinting.vb`): search products by name, category, barcode, part number, HSN, batch, size or colour, or by a purchase invoice number, or by product ids; the list shows product code, name, category, barcode, available quantity, copies (starts at "1"), part no, HSN, MRP, sale price, wholesale price, batch, manufacturing date, expiry date, size, colour, GST % (`CGST + SGST` for stock rows, `CGSTPer + SGSTPer + IGSTPer` for a purchase), purchase invoice number, QR, discount (`:732-995`, grid columns `Designer :219-263`). The person ticks rows, chooses a template, and prints; "No(s) of Copy for All Products" sets one number for all rows. Templates are Crystal files named `BarcodeT1` to `BarcodeT18` and others; the list in the box "Template Type" holds "Standard A4 Size (2 x 1)", "Standard (L) Single (2 x 1)", "TVS Printer Dual (2 x 1)", "Standard Single (1 x 0.5)", "Standard (C) Single (2 x 1)", "Standard Single (1.5x1.5)", "Standard Single (3 x 1.5)" and more; the active one is stored in `BarcodePreview(BarcodeStyleId, BarcodeStyleName, PrintPreviewType, BarcodeStyleImage, is_active)` (`:1027-1200`, `:2235-2245`). Barcode symbol: Code 128 (`Barcode128.rpt`).
- **Test vectors:** BC1 `BCode` "SA", highest opening-stock id 5: next id text "0006", barcode "SA" + 1006 = "SA1006". BC2 highest id 0: "0001", barcode "SA1001". BC3 copies 3 on two rows: 6 labels. BC4 nothing ticked: "Please select Barcode list". BC5 no template chosen: "Please select Barcode Template".
- **Hub today (9 October 2026):** `Item.Barcode`, "Make a number for me" (an in-store EAN-13 not used by any item) and the price label of one item already existed; **built now:** labels for many items (each its own copies) and for a delivery (`HubPrinting.PrintLabelBatchAsync`, `LabelsFor`; BC3 to BC5 are its tests). Not done: the older program's many designs and fields (MRP, batch, dates, size, colour, QR), an A4 sheet for an ordinary printer. **Port:** label printing as a Hub print job (barcode, name, price, copies); label sizes as settings; no Crystal.

#### A2.6 Bulk price change, bulk GST change and bulk edit

- **Bulk price change** (`frmBulkPriceChange`, `B/frmBulkPriceChange.vb`). The person picks a sub-category. The list shows each active product (`Status = 'Yes'`) of that sub-category that has stock (`Temp_Stock.Qty > 0`), one row per barcode: product id, code, name, barcode, MRP, current sale price, and a box "Update Sell Price" (`:126-152`). On "Update Price", every row whose new price is above 0 runs three statements built as text: `UPDATE Product SET SellingPrice = new WHERE PID = id AND ProductCode = code`; `UPDATE Temp_Stock SET SPrice = new WHERE ProductID = id AND Barcode = barcode`; `UPDATE Product_OpeningStock SET SalePrice = new WHERE ProductID = id AND Barcode = barcode` (`:155-200`). If no row had a price: "Enter sell price to update". There is no percent change, no history, no undo, and only the **retail** price changes (not MRP, not wholesale).
  - Quirk: when one product has several barcode rows, `Product.SellingPrice` ends with the last row's price.
  - Test vectors: BP1 two products A (stock 5, price 100) and B (stock 0, price 50) in the sub-category: only A is listed. BP2 enter 120 for A: `Product.SellingPrice` 120, `Temp_Stock.SPrice` 120, `Product_OpeningStock.SalePrice` 120. BP3 enter 0 or leave empty: A unchanged. BP4 nothing entered: message and nothing written. BP5 A has two barcodes with prices 130 and 140: `Product.SellingPrice` = 140 (last row).
- **Bulk GST change** (`frmProductBulkUpdate_GST`, `UpdatelistdataGST_Rate`, `:2037-2090`). Pick "from GST" X and "to GST" Y (both must be above 0) and optionally an HSN; tick products. For each ticked product the program runs `UPDATE Product SET CGST = Y/2, SGST = Y/2 WHERE CGST = X/2 [AND HSNCode = hsn] AND ProductCode = code`. So a product changes only if its current CGST equals X/2. The message "Total Status Record(s) Updated N" counts **ticked** products, even those the `WHERE` did not match. Nothing is written for `Temp_Stock` or past bills. The "GST" tick box must be on first.
  - Test vectors: GB1 X 12, Y 18, product CGST 6: CGST and SGST become 9. GB2 product CGST 9 (so GST 18): unchanged but counted. GB3 X 12, Y 18, HSN "1234", product HSN "5678": unchanged. GB4 Y empty or 0: refused "To GST value can't be empty or 0."
- **Bulk edit** (`frmProductBulkUpdate`, `B/frmProductBulkUpdate.vb`): a grid of many products; the person edits cells and the program runs one `UPDATE Product ...` for the changed columns: name, HSN, part no, description, cost, MRP, selling price, wholesale price (column `ReorderPoint`), discount, CGST, SGST, CESS, units, alternate unit, conversion, min stock, store, rack, default quantity, loyalty mode and value (`:1169`), plus `Temp_Stock` prices and `Product_OpeningStock` prices by barcode (`:1170-1171`). Separate buttons switch products active or inactive (`UPDATE Product SET Status = 'Yes'/'No'`, `:1485-1488`), change the description to another language (`:1682`) and set loyalty mode and value (`:1767`). The change-barcode button is `frmChangeBarcode` (rewrites barcodes in all tables as in A2.1). A confirmation "Are you sure to update record" comes first.
- **Hub today (9 October 2026): BUILT** as `Catalog/CatalogChangeService.cs` and the page *Products → Change many at once*: price by percent or amount or typed beside each item, trade price, tax rate change (BP2 to BP5 and GB1 to GB4 are its tests; only items really changed are counted), on and off sale, a record of every change and an undo. Not done: bulk edit of every other column (name, units, rack ...), the change-barcode tool (the Hub keeps history by item id, so a new barcode needs no rewrite). **Port (done):** one "price list change" action (set, or raise by percent or amount, per category), with a log of old and new price; one "change tax rate" action matching on the old rate (copy rule GB1 to GB4); bulk active/inactive.

#### A2.7 Combo packs

- **Tables.** `Combopack(ID, ComboCategoryName, CBarcode, QRCBarcode)` (the combo's name and its own barcode), `ComboPack_Product(ComboCategoryName, ProductID, Barcode, DefaultQty)` (the members with a default quantity), and `ComboPackPost(ComboID, ComboPackName)` with `ComboPack_Product(ComboID, ...)` (a second way of saving, `B/frmComboPack.vb:1450-1502`; which one the till reads is the first: **not understood** for the second).
- **Rules.** A combo name must be new ("ComboPack Already Exists", `B/frmComboPackMaster.vb:702`). Members are added by barcode and default quantity (`B/frmComboPack.vb:1329`), updated and removed. The screen is titled "Item / Combo Offer Validation".
- **At the till** (`B/frmPOSNewTuch.vb:14123`): choosing a combo shows its member products as tiles with their photo, barcode, retail price (`Temp_Stock.SPrice`), stock and `DefaultQty`. Each member is sold on its own at its own price. **There is no combo price or discount**: a combo is a quick way to add a group of items, not a bundle price.
- **Test vectors:** CB1 combo "Breakfast" with Bread (default 1) and Milk (default 2): picking it offers both tiles with quantity 1 and 2, each at its own price. CB2 create "Breakfast" twice: second refused. CB3 delete the combo: `ComboPack` row removed (members removed? **not understood**).
- **Hub today:** none. **Port:** a "quick group" of items with default quantities (low priority); if the owner wants true bundle prices that is new design.
- **Hub now (9 October 2026):** built as **quick groups** (`docs/OPEN-WORK.md` item 12n); CB1 to CB3 are tests; no bundle price, as the older program had none.

#### A2.8 Quantity discounts (per barcode)

- **Table.** `Product_discount(IPo_ID, ProductID, Barcode, MinQty, MaxQty, DiscountPur)`: bands of quantity with a discount percent (`B/frmProductDiscount.vb:1205`, screen "Item / Product Discount").
- **Rule at the till** (`B/frmPOSNewTuch.vb:13281-13333`, `16046-16056`): when the quantity changes: take the first band of that barcode with `MinQty <= quantity <= MaxQty` (quantity rounded to 3 places) and use its percent as the line discount. When no band matches, the discount is `MAX(DiscountPur)` over **all** bands of the barcode (not zero); when the barcode has no bands at all it keeps the percent already in the box. Bands may overlap and are read without an order.
- **Quirk (probable bug).** A quantity outside every band (below the first minimum, or above the last maximum) gets the **largest** discount of the barcode. Fix?: Yes, ask the owner; the likely intent is zero or the product default. Also the band discount **replaces** the percent chosen by the customer discount or item offer rule of A1.9 whenever the quantity box changes (order of events not fully traced).
- **Test vectors** (bands 1-4: 0 %, 5-9: 5 %, 10-999: 10 %): QD1 quantity 3: 0 %. QD2 quantity 7: 5 %. QD3 quantity 10: 10 %. QD4 quantity 1000: no band, so MAX = 10 %. QD5 quantity 0.5: no band, 10 %. QD6 barcode with no bands: keeps the box value.
- **Hub today (9 October 2026): BUILT** (`OffersService` bands, *Offers → By quantity*; QD1 to QD6 are its tests). The probable bug is fixed: a quantity in no band gets no discount. A quantity change re-works a program-given discount and never replaces one a person typed.

#### A2.9 Variants, batches and serial numbers

- **Variants (size, colour, batch).** There is no variant table. A variant is one more **barcode row** of the same product in `Product_OpeningStock` and `Temp_Stock`, each with its own `Size`, `Colour`, `Batch`, `Mfgdate`, `Expdate`, `MRP`, `SPrice`, `WPrice`, `PPrice`, `IMEI1`, `IMEI2` and quantity. `Temp_Stock.Variant_id` holds the product id (`B/frmProduct.vb:7522`). The screen `frmProductRec_variant` lists them. At the till a variant is chosen by scanning its barcode.
- **Batch and expiry.** Stored as text in `Temp_Stock` and `Stock_Product` (`Batch`, `Mfgdate`, `Expdate` are `nvarchar(50)`). Reports on expiry read these text fields (reports study). Stock is not picked by first-expiry-first-out by the code read: **not understood**.
- **Serial numbers** (`frmProductRec_serial`, `frmSerialno_popup`, `frmSerialwiseReport`): tables `tbl_product_serial` (a per-user working list: `productid, barcode, serialno1, serialno2, status, sys_user, invoice_no`), `tbl_product_serial_final` (the stock of serials with status "PURCHASE" or "SALE"), `tbl_product_serial_sale(productid, barcode, serialno, status, sys_user, invoice_no)`, plus purchase-return and sale-return versions. Flow: on a purchase the typed serials (one or two per unit, for example IMEI 1 and 2) go to the working list and then to the final table with status "PURCHASE" (`B/frmPOSNewTuch.vb:12342`); on a sale each serial is added to `tbl_product_serial_sale` and the final row is set to "SALE" where `serialno1` or `serialno2` matches (`:25166-25176`); when a bill is edited or deleted the serials go back to "PURCHASE" and are re-sold (`:25905-25942`).
- **Test vectors:** SN1 purchase 2 phones, serials A1 and A2: two final rows "PURCHASE". SN2 sell the phone with serial A1: sale row, final row "SALE". SN3 delete that bill: A1 back to "PURCHASE". SN4 sell a serial that is already "SALE": **not understood** (no check found in the part read).
- **Hub today:** the Hub core has no variant, batch or serial tables (`grep` found none in `NextGenOS.Hub.Core`); the merge plan's "Have: variants, serial numbers" is **not confirmed** by the code read. **Port:** serial numbers as an `item_serials` table with status and document links; variants as separate items with a shared "family" attribute (simple) or a variant table.

#### A2.10 Product images

- `Product_Join(ProductID, Photo)`: several JPEG blobs per product (`B/frmProduct.vb:7418-7440`); `Category.CPhoto` and `SubCategory.SCPhoto`; the till shows the first image on touch tiles (`Product_Join.Photo` is joined at `B/frmPOSNewTuch.vb:14123`). A product can get images from the web through `DevNet.QImage` ("Online Image Library" link, `frmOnlineImage`, `frmProductImageMaker`, `frmProductImageUpdator`). Limit "Image Limit" per product is a screen setting.
- **Hub today:** none in Core. **Port:** store images as files with a path column, not blobs; online image search needs the owner's permission (rule 15: nothing leaves the shop unasked).
- **Hub now (9 October 2026):** built (`docs/OPEN-WORK.md` item 12l), kept in the shop's database rather than as files so that backups carry them; online image search is not ported.

#### A2.11 Porting notes for products

1. Import order: units, tax rates, categories and sub-categories, products, then one stock row per `Temp_Stock` barcode (quantity, prices, batch, size, colour). Map `Product.ReorderPoint` to the trade price. `Product.Barcode` "0" means no product-level barcode.
2. Opening stock is the sum of `Temp_Stock.Qty` per product at the cut-over day; do not import `Product_OpeningStock` as stock (it is the original set-up record).
3. Golden tests: M1 to M15 (codes, GST split, margin, validation), U1 to U5 (units), BP1 to BP5, GB1 to GB4, QD1 to QD6, BC1 to BC5, SN1 to SN3.
4. Keep for the Hub: mark-up margin as a helper on the price screen only; unit conversion; quantity bands; bulk price and GST change with a log. Fix: GST half rate rounding, bulk change counting, alternate unit checks, the "max discount outside bands" rule.

#### A2.12 Not understood (products)

- The second combo save path (`ComboPackPost`) and what the till reads.
- Whether deleting a product removes `Temp_Stock` and `Product_Join` rows (by cascade).
- What `frmProductSmart`, `frmProductPlus`, `frmProductNew`, `frmProductEntry` do differently from `frmProduct` (they write the same tables; the differences were not read).
- Expiry and batch picking rules at sale (first-expiry-first-out) were not found.
- Whether a category rename updates `SubCategory.Category`.
- The text of the second-language product name column (`frmProduct` "Product Name (2nd Language)") and where it is saved.

### A3. Suppliers

Status of this topic: written (first pass). Covers the supplier master, the supplier ledger and balance, purchases and payments as they post, credit limit, outstanding, returns.

#### A3.0 The three things to know

1. **Supplier balance = sum(Credit) minus sum(Debit)** of `SupplierLedgerBook` for the supplier code (`B/frmPurchaseEntry.vb:7773`, `B/frmSupplierLedger.vb:537`). Positive means the shop owes the supplier ("Cr"). This is the **same formula** as for customers, but here a positive number is the normal case (a customer's normal case is negative).
2. **The purchase bill's grand total includes the supplier's previous due.** The ledger row for the purchase is written for `GrandTotal - PreviousDue`, so the old balance is not counted twice (`B/frmPurchaseEntry.vb:11706`).
3. **Paying a supplier is checked against the absolute balance**, which hides the sign (A3.4 quirk).

#### A3.1 Supplier master

**What a person sees.** `frmSupplier` (`B/frmSupplier.vb`): name, address, city, state, zip, contact number, e-mail, remarks, GSTIN, PAN, CIN, bank details, photo, credit limit on/off (Yes or No) with an amount, a short "supplier code" of up to 4 characters (`txtSCode`, `:2129-2143`), opening balance and type CR or DR.

**Table `Supplier`** (columns in `PosSchemaData.cs`): `ID`, `SupplierID` ("S-" + ID padded to 4 digits, `:1431-1438`, same padding rule as customers), `Name`, address fields, `ContactNo`, `EmailID`, `Remarks`, bank fields, `GSTIN`, `PAN`, `CIN`, `OpeningBalanceType` ("CR" or "DR"), `OpeningBalance`, `Photo`, `Limit`, `Lstatus` ("Yes" or "No"), `SCode`.

**Rules** (`:2700-2883`):
1. Required: company profile, name, address, city, state, contact number, opening balance typed. Refused: a name already used, a supplier code already used ("Duplicate Supplier Code Found !"), a contact number already used.
2. Opening balance posts to `LedgerBook` and `SupplierLedgerBook` dated **today**, label "Opening Balance": "CR" (index 0) gives **Credit** = amount (we owe the supplier); "DR" (index 1) gives **Debit** = amount (the supplier owes us) (`:2867-2876`).
3. Rename rewrites `LedgerBook.Name`, `SupplierLedgerBook.Name` and `SuplNameid`, and `Journal.Name` (`:2603-2632`). Delete is refused when the supplier is used (`:1441-1520`, same family of checks as the customer).
4. A trial copy limited suppliers to 5.

**Test vectors A3.1:** SM1 highest ID 0: code "S-0001". SM2 highest ID 12: "S-0013". SM3 opening "CR" 1,000.00: ledger Credit 1,000.00, balance +1,000.00 (we owe). SM4 opening "DR" 300.00: Debit 300.00, balance -300.00 (they owe us). SM5 opening balance left empty: refused "Please Enter Opening Balance". SM6 supplier code "ABCD" used twice: second refused.

**Hub today.** `PartyService` with `Kind = "supplier"` (`Catalog/PartyService.cs`); fields name, phone, e-mail, address, tax id, region, terms days, notes. **No** opening balance, no supplier credit limit use (credit limit on a party is read only for customers' sales), no short code, no bank fields. **Port:** opening balance as a first "opening" purchase-like entry or an `opening_balance_minor` on the party; bank details as a note or fields for payment advice (owner decides); supplier short code only if labels need it (it prints in purchase labels as the cost cipher, see A3.6).

#### A3.2 Supplier ledger and statement

**Table.** `SupplierLedgerBook(ID, Date, Name, LedgerNo, Label, Debit, Credit, PartyID, SuplNameid, Remarks)` (`B/ModFunc.vb:524-541`). `PartyID` = supplier code, `SuplNameid` = name + "-" + code.

**What posts** (Debit D, Credit C):

| Event | Label | Side | Amount | Source |
|---|---|---|---|---|
| Opening balance | Opening Balance | C ("CR") or D ("DR") | opening amount | `frmSupplier.vb:2867` |
| Purchase saved (any type) | Purchase | C | `GrandTotal - PreviousDue` | `frmPurchaseEntry.vb:11706,11714,11724` |
| Purchase paid at once, cash type | Payment (name "Cash Account") | D | `TotalPaid` | `:11715` |
| Purchase paid at once, bank type | Payment (name "Bank Account") | D | `TotalPaid` | `:11725` |
| Payment screen: cash | Payment (name "Cash Account") | D | amount | `frmPayment.vb:1605` |
| Payment screen: cheque, online transfer, PhonePe, Google Pay, Paytm, E-wallet | Payment (name "Bank Account") | D | amount | `frmPayment.vb:1609` |
| Purchase return | Purchase Return | D | return grand total | `frmPurchaseReturn.vb:3416` |
| Purchase return refunded in cash | Cash Return | C | return grand total (nets the line above) | `:3421` |
| Journal "receive" from a supplier | Journal | C | amount | `frmRefundAmt.vb:1718` |

The "purchase type" box on the purchase screen has three values: index 0 = cash purchase (a `Payment` row to "Cash Account"), index 1 = credit purchase (no payment row), index 2 = bank purchase (a `Payment` row to "Bank Account" and a bank ledger row "Purchase-Bank" with Debit = `TotalPaid`, `:11727-11735`).

**The statement** (`frmSupplierLedger`, `:450-513`): rows in a date window for one supplier ordered by `ID, Date, LedgerNo`, columns `Date, Name, LedgerNo, Label, Credit, Debit, Remarks`; running balance in the Crystal report (not read). The quick balance view `frmSuplBalanceLedger` lists `Date, Name, LedgerNo, Label, Debit, Credit` ordered by date (`:129`).

**Test vectors A3.2:**

| # | Inputs | Rows | Balance |
|---|---|---|---|
| S1 | Credit purchase, grand total 5,900.00, previous due 0 | Purchase C 5,900.00 | +5,900.00 (we owe) |
| S2 | Cash purchase, grand total 5,900.00, paid 5,900.00 | Purchase C 5,900.00; Payment (Cash Account) D 5,900.00 | 0.00 |
| S3 | Cash purchase 5,900.00, paid 2,000.00 | Purchase C 5,900.00; Payment D 2,000.00 | +3,900.00 |
| S4 | Previous balance +1,000.00; new credit purchase sub-total gives grand total 6,900.00 (it includes the 1,000.00) | Purchase C `6,900.00 - 1,000.00` = 5,900.00 | +6,900.00 |
| S5 | After S3, payment screen cash 3,900.00 | Payment D 3,900.00 | 0.00 |
| S6 | After S3, payment screen 4,000.00 | refused "Transaction amount can not be more than balance" | +3,900.00 |
| S7 | Purchase return 590.00, no refund | Purchase Return D 590.00 | reduces by 590.00 |
| S8 | Purchase return 590.00 refunded in cash | Purchase Return D 590.00; Cash Return C 590.00 | unchanged |
| S9 | Bank purchase 5,900.00 paid 5,900.00 to account "ACC-1" | Purchase C; Payment (Bank Account) D; `BankAccountLedger` AccNo "ACC-1" label "Purchase-Bank" Debit 5,900.00 | 0.00 |
| S10 | Supplier with no rows | none | 0.00 |

**Hub today.** `PurchaseService.CreateOrder`, `Receive`, `Pay`, `Payable()` (`Purchasing/PurchaseService.cs`) and `ReportService.Purchases(from, to)` (received total and unpaid total). Payable = purchase documents issued and not fully paid (`documents.List(... OnlyUnpaid)`). There is **no supplier running account**, no previous-due carry, no purchase-return posting to a supplier balance (check `CreateCreditNote` is for sales invoices only). `Receive` also sets each item's cost to the latest line cost (`:34-50`). **Port:** add a supplier account view like the customer one (A1.2), supplier payments that allocate to the oldest unpaid purchase and keep an unallocated credit, and purchase returns as a supplier credit.

#### A3.3 Supplier credit limit

**Rule** (`B/frmPurchaseEntry.vb:11407-11409`, again at `:11810`): before saving, `txtBalance = GrandTotal - TotalPaid` (the amount still unpaid, which includes the previous due because `GrandTotal` includes it, `:6705-6722`). If `txtBalance > Limit` **and** `Lstatus = "Yes"`: stop with "Supplier Credit limit is exceeded". Equal is allowed.

**Test vectors A3.3:** SL1 limit 10,000 Yes, previous due 6,000, new bill 5,000 unpaid: balance 11,000 > 10,000, refused. SL2 same, paid 1,000 now: 10,000, allowed (not strictly more). SL3 limit flag No: never refused. SL4 limit 10,000 Yes, previous due 0, bill 12,000 paid in full: balance 0, allowed (the limit applies to what stays unpaid, not to the bill size).

**Hub today:** none for suppliers. **Port:** apply the same check when receiving an order if the owner wants it (feature flag).

**Hub now (9 October 2026):** built (`docs/OPEN-WORK.md` item 12i): the check is made when goods are received (`DocumentService.Issue`, a purchase), reading what is owed from the books (`BooksService.SupplierBalance`), with SL1 to SL4 as tests (`SupplierLimitTests`). A limit of nothing means no limit (the older flag "No"). Not a feature flag: a supplier with no limit is never refused, so a shop that sets none sees no change.

#### A3.4 Supplier payments

**What a person sees.** `frmPayment` (`B/frmPayment.vb`): pick a supplier, see the current balance, enter date, payment mode (cash, cheque, online transfer, PhonePe, Google Pay, Paytm, E-wallet), amount, optional bank account (required for the bank modes), remarks.

**Table.** `Payment(T_ID, TransactionID, Date, PaymentMode, SupplierID, Amount, Remarks, PaymentModeDetails, BankAcN)`; number counter `SrPayment(ID, InvNo)`.

**Rules** (`:1560-1650`):
1. Payment number = prefix + "-" + counter padded to 4 digits + "-" + suffix; defaults "PYMT" and "year1/year2"; `Invcode.c7` and `c17` override (`:834-858`).
2. Refused: amount empty, amount 0, amount **more than the balance shown** (`txtTransactionAmount > lblBalance`, `:1573`). `lblBalance` is the **absolute** balance (`:740`).
3. Writes: `Payment` row; `LedgerBook` Name "Cash Account" or "Bank Account", Label "Payment", **Debit** = amount, PartyID = supplier code; `SupplierLedgerBook` same, Debit = amount; for the bank modes a `BankAccountLedger` row with Label "Payment-By Cheque", "Payment-By Online Transfer", "Payment-PhonePe", "Payment-Google Pay", "Payment-Paytm" or "Payment-E Wallet" and **Debit** = amount on the chosen account.

**Quirk (fix).** Because the check uses the absolute balance, a supplier who **owes the shop** 300 (balance -300) can be "paid" 200: the check passes and the supplier then owes 500. The Hub must refuse a payment when nothing is owed.

**Test vectors A3.4:** PY1 balance +3,900, pay 1,000 cash: `Payment` row, Debit 1,000 to supplier and "Cash Account" in both ledgers, balance +2,900. PY2 pay 5,000 on +3,900: refused. PY3 pay 0: refused. PY4 pay 1,000 by cheque on account "ACC-1": bank ledger row "Payment-By Cheque" Debit 1,000. PY5 balance -300 (supplier owes), pay 200: allowed by the old code (bug), balance becomes -500.

**Hub today:** `PurchaseService.Pay(orderId, amount, method, reference)` → `DocumentService.AddPayment` refuses more than the balance of **that** order ("too-much"). No payment number series for payments alone. **Port:** keep the Hub's per-order payment and add an account-level payment that allocates; number payments through `Numbering`.

#### A3.5 Supplier outstanding and report

- **Supplier outstanding** (`B/frmSupplierOutstanding.vb:473-500`): per `SuplNameid` in a date window: `sum(Credit)`, `sum(Debit)`, outstanding = `sum(Credit) - sum(Debit)` (positive: we owe; the opposite order of the customer screen). Same five filters and the same window caveat as customers.
- **Debtors report, supplier part** (`B/frmDebtorsReport.vb:494-524`): "suppliers" use `having sum(Debit) - sum(Credit) < 0` for one list and `> 0` for the other. With the balance defined as Credit minus Debit, `Debit - Credit < 0` means we **owe** the supplier, so the list that the screen names by its label must be checked on a real screen. **Not understood** which label the screen puts on which list.
- **Supplier-wise purchase report** (`frmSupplierwise_report`): purchase lines per supplier with taxable value, discount, tax and totals; see C for columns.
- **Supplier contact list** `frmSupplierContactList`, **bulk update** `frmSupplierBulkUpdate`, **Excel import and export** `frmExportImportExcel_Suppliers`: list, edit many, load from a sheet. Not read in detail.

**Test vectors A3.5:** SO1 window rows: Purchase C 5,900.00; Payment D 2,000.00: outstanding 3,900.00. SO2 only a Payment D 500.00 in the window: outstanding -500.00. SO3 supplier with an opening balance dated before the window: not shown (window).

**Hub today:** `ReportService.Purchases` returns one number for unpaid; `Payable()` lists unpaid orders. No per-supplier ageing like `Outstanding()` has for customers. **Port:** supplier ageing by due date (copy `ReportService.Outstanding` for purchases).

#### A3.6 Supplier code on labels (cipher)

`Supplier.SCode` (up to 4 characters) is saved with each purchase line (`Stock_Product.SCode`) and prints on barcode labels together with the **cost cipher**: `CipherCode(c0..c14)` maps digits to letters so the shop can read the cost price on a label without showing it (`B/frmProduct.vb:5465-5520`, "R.Sale Price Cipher Code", "W.Sale Price Cipher Code"; `Stock_Product.RCipher`, `WCipher`). It is a retail-trade habit. **Not read in detail.** **Port:** low priority; only if a customer asks.

#### A3.7 Porting notes for suppliers

1. Import: suppliers, then the balance per supplier from `SupplierLedgerBook` (`sum(Credit) - sum(Debit)` by `PartyID`) as one opening entry per supplier in the Hub; keep unpaid purchase documents as real purchase documents if they can be matched (`Stock.PaymentDue`), else a single opening entry. Report any supplier whose imported balance differs from the sum of its `Stock.PaymentDue` rows.
2. Golden tests: S1 to S10 (ledger), SL1 to SL4 (limit), PY1 to PY5 (payments, with PY5 fixed to a refusal).
3. Keep the Hub's invoice-style payable list; add the account view over it.

#### A3.8 Not understood (suppliers)

- Which list the supplier part of the debtors report shows under which heading (A3.5).
- The cipher code details (A3.6) and the supplier short code rules beyond "unique, 4 characters".
- Whether `Stock.PreviousDue` is the stored copy of `PreviousDue` on the purchase (`PosSchemaData.cs` lists it) and how editing an old purchase treats it.
- Supplier delete checks (assumed like the customer's).

## B. Accounting books

Status of this topic: written (first pass). Covers how every book is fed, the general ledger, day book, cash book, bank book, trial balance, expense and income vouchers, account heads, contra, fund transfer and deposit, bank accounts, journal vouchers, advances, profit and loss, and the two balance sheet screens.

### B0. The five things to know

1. **There is no chart of accounts and no double entry.** The books are tables of rows (`LedgerBook`, `CustomerLedgerBook`, `SupplierLedgerBook`, `BankAccountLedger`, two loyalty ledgers, one salesman ledger). A program event writes **one row, or a pair of rows**, by a helper call (`ModFunc.LedgerSave`, `B/ModFunc.vb:251`). There is no "Sales" account row and no "Purchases" account row. A credit sale writes only the customer's row.
2. **In `LedgerBook` the account named "Cash Account" or "Bank Account" and the expense and income names use a mirrored sign:** for these, **Credit means money in and Debit means money out** (`B/frmCashLedger.vb:475-496` computes cash as Credit minus Debit). Customers and suppliers use the normal side (customer owes = Debit; we owe supplier = Credit). Do not copy the mirrored sign into the Hub; convert on import (B2).
3. **The trial balance does not balance** except for events that wrote both rows (B7). It is a net per name, nothing more.
4. **"Profit and Loss" is cash-style:** sales plus other income less purchases and expenses of the period, with **no closing stock** (B8). It is not the "billwise profit", which uses cost of goods sold.
5. **Two forms are called balance sheet.** `frmBalancesheet` is really a period list of receipts and payments; `BalanceSheetForm` is the assets and liabilities view with a stock figure worked from purchases and sales (B9). Neither is built to balance.

### B1. Tables of the books

| Table | Columns | Used for |
|---|---|---|
| `LedgerBook` | `ID, Date, Name, LedgerNo, Label, Debit, Credit, PartyID, PartyName` | Everything: general ledger, day book, cash book, bank book (by `Name`), trial balance |
| `CustomerLedgerBook` | `ID, Date, Name, LedgerNo, Label, Debit, Credit, PartyID, CustNameid, Remarks` | Customer accounts (A1.2) |
| `SupplierLedgerBook` | same with `SuplNameid` | Supplier accounts (A3.2) |
| `BankAccountLedger` | `Id, Date, AccNo, LedgerNo, Label, Debit, Credit` | One book per bank account; Credit = money in, Debit = money out (`B/frmBankAccountStatements.vb:362`) |
| `BankAccountRegistration` | `AccountNo, AccountName, AccountType, OpeningDate, BalanceAmount, Active, BranchID, ID` | The shop's bank accounts. `Bank(BankName)`, `BankBranch(Id, BankName, BranchName, SwiftCode, IFSCCode)` hold the bank names |
| `Voucher`, `Voucher_OtherDetails` | `Voucher(Id, VoucherNo, Name, Date, Details, GrandTotal, PMode, BankAcNumber)`; lines `(VoucherID, Particulars, Amount, Note, Date, PModeD)` | Expense vouchers |
| `Income`, `Income_OtherDetails` | `Income(Id, IncomeNo, Name, Date, Details, GrandTotal, PMode, BankAcNum)`; lines `(IncomeID, Particulars, Amount, Note, Date, PModeD)` | Income vouchers (also capital and loans taken) |
| `AccountHead` | `ID, a1 (head name), a2 (group), a3 (type code)` | The list of heads for vouchers |
| `Contra` | `ID, Date, ConID, Type, BankAc, BenfName, Amount` | Cash to bank and bank to cash |
| `FundDeposit` | `Id, DepositerName, Amount, Date, AccNo, Notes` | Money paid into a bank account |
| `FundTransfer` | `Id, AccountTransFrom, AccountTransTo, Amount, Date, Operator, Notes` | Between two bank accounts |
| `Journal` | `ID, Date, JID, NameType, Name, CSID, Amt, PayRec, AmtType, BankAcc, Note` | Journal vouchers to a customer or supplier |
| `AdvanceEntry` | `ID, workingdate, employeeid, amount, deduction` | Salary advances |
| `EmployeePayment` | `... NetPay, Modeofpayment, Paymentdate` | Salary paid |
| `CreditCustomerPayment`, `Payment` | A1.4, A3.4 | Money received from customers, paid to suppliers |

Number series for vouchers use prefix and suffix from `Invcode` and a counter table (`SrExpenses`, `SrIncome`, `SrReceipt`, `SrPayment`): "prefix-0001-suffix" (A1.4 rule 1). Default prefixes seen: receipts "RCPT" (`Invcode.c6`), payments "PYMT" (`c7`), expenses `c9`; others not read.

### B2. The posting catalogue (which event writes which rows)

`LedgerSave(date, name, ledgerNo, label, debit, credit, partyId, partyName)`. "Dr/Cr" are the stored columns. "In/Out" tells what the row means for cash or bank (mirrored sign). `GT` = grand total.

**General `LedgerBook` rows**

| Event (source) | Row 1 | Row 2 |
|---|---|---|
| Customer bill (`frmPOSNew.vb:10869-10882`) | Customer name, "Sales", Dr GT | for each payment line: "Cash Account" (mode By Cash) or "Bank Account" (cheque, cards, UPI wallets), "Receipt", Cr amount |
| Credit customer receipt (`frmCreditCustomerReceipt.vb:2140-2144`) | "Cash Account" or "Bank Account", "Receipt", Cr amount | none |
| Sales return (`frmSalesReturn.vb:3301-3306`) | Customer, "Sales Return", Cr GT | when paid back in cash: "Cash Account", "Sales Return", Dr GT |
| Purchase, credit type (`frmPurchaseEntry.vb:11710`) | Supplier, "Purchase", Cr `GT - PreviousDue` | none |
| Purchase, cash type (`:11719-11720`) | Supplier, "Purchase", Cr `GT - PreviousDue` | "Cash Account", "Payment", Dr TotalPaid |
| Purchase, bank type (`:11729-11730`) | Supplier, "Purchase", Cr `GT - PreviousDue` | "Bank Account", "Payment", Dr TotalPaid |
| Supplier payment (`frmPayment.vb:1597-1601`) | "Cash Account" or "Bank Account", "Payment", Dr amount | none |
| Purchase return (`frmPurchaseReturn.vb:3407-3412`) | Supplier, "Purchase Return", Dr GT | when cash refund: "Cash Account", "Purchase Return", Cr GT |
| Expense voucher, cash (`frmVoucher.vb:2024-2025`) | "Cash Account", "Expenses", Dr GT | payee name, "Expenses", Cr GT |
| Expense voucher, bank (`:2029-2030`) | "Bank Account", "Expenses", Dr GT | payee name, "Expenses", Cr GT |
| Income voucher, cash (`frmIncome.vb:1987-1988`) | "Cash Account", "Income", Cr GT | payer name, "Income", Dr GT |
| Income voucher, bank (`:1992-1993`) | "Bank Account", "Income", Cr GT | payer name, "Income", Dr GT |
| Contra cash to bank (`frmContra.vb:1286-1287`) | "Bank Account", "Contra", Cr amount | "Cash Account", "Contra", Dr amount |
| Contra bank to cash (`:1293-1294`) | "Cash Account", "Contra", Cr amount | "Bank Account", "Contra", Dr amount |
| Fund deposit (`frmFundDeposit.vb:1262`) | "Bank Account", "Fund Deposit", Cr amount | none |
| Fund transfer (`frmFundTransfer.vb:1289-1290`) | "Bank Account", "To Transfer-Withdraw", Dr amount | "Bank Account", "By Transfer-Diposit", Cr amount (both rows carry the **from** account number as `PartyID`; probable slip) |
| Bank account opening (`frmBankAccountRegistration.vb:1436`) | "Bank Account", "A/c Opening Balance", Cr balance, dated the opening date | none |
| Payroll advance (`frmAdvanceEntry.vb:697-698`) | "Cash Account", "Payroll Advance", Dr amount | employee name, "Payroll Advance", Cr amount |
| Payroll payment (`frmEmployeePayment.vb:1595-1601`) | "Cash Account" or "Bank Account", "Payroll Payment", Dr NetPay | employee name, "Payroll Payment", Cr NetPay |
| Journal voucher, customer or supplier (`frmRefundAmt.vb:1686-1900`) | "Cash Account" or "Bank Account", "Journal", Cr (Receive) or Dr (Payment) | the party's own ledger row (A1.2 / A3.2) |
| Customer or supplier opening balance | A1.1 / A3.1 | |

**Bank account book `BankAccountLedger`** (`BankAccountLedgerSave(date, accNo, ledgerNo, label, debit, credit)`):

| Event | Label | Side |
|---|---|---|
| Account opened | Opening Balance | Cr |
| Sale paid by cheque, credit card, debit card, PhonePe, Google Pay, Paytm, E-Wallet (account chosen on the payment line) | "Sale-By Cheque", "Sale-By Credit Card", "Sale-By Debit Card", "Sale-PhonePe", "Sale-Google Pay", "Sale-Paytm", "Sale-E-Wallet" | Cr |
| Customer receipt by a bank mode | "Receipt-By Cheque", "Receipt-By Online Transfer", "Receipt-PhonePe", "Receipt-Google Pay", "Receipt-Paytm", "Receipt-E Wallet" | Cr |
| Supplier payment by a bank mode | "Payment-By Cheque", ... same six | Dr |
| Bank-type purchase | "Purchase-Bank" | Dr |
| Expense voucher, bank | "Expenses-Bank" | Dr |
| Income voucher, bank | "Income-Bank" | Cr |
| Payroll payment, cheque or online | "Payroll Payment-By Cheque", "Payroll Payment-By Online Transfer" | Dr |
| Journal voucher by bank | "Journal-Bank Account" | Cr (receive) or Dr (payment) |
| Contra | "Contra" | Cr (cash to bank) or Dr (bank to cash) |
| Fund deposit | "Fund Deposit" | Cr |
| Fund transfer | "Fund To Transfer" (from account) / "Fund By Transfer" (to account) | Dr / Cr |

**Not posted to the bank book:** a sales return paid back by bank, a purchase return refunded by bank (only cash is handled), a bank-paid service bill.

**Edits and deletes.** Edit calls update-by-(`LedgerNo`, `Label`) helpers; delete removes all rows with that `LedgerNo` and `Label` (`ModFunc.LedgerDelete`, `:270-280`). So a document's books can be rewritten in place: history is not append-only.

**Test vectors B2** (as stored; `Dr`/`Cr` columns):

| # | Event | `LedgerBook` | `CustomerLedgerBook` / `SupplierLedgerBook` / `BankAccountLedger` |
|---|---|---|---|
| X1 | Cash sale 1,000 to Asha, paid By Cash 1,000 | Asha Sales Dr 1,000; Cash Account Receipt Cr 1,000 | Asha: Sales Dr 1,000; Receipt (Cash Account) Cr 1,000 |
| X2 | Sale 1,000 paid PhonePe 1,000 to account ACC-1 | Asha Sales Dr 1,000; Bank Account Receipt Cr 1,000 | Asha rows as X1 with name "Bank Account"; bank book ACC-1 "Sale-PhonePe" Cr 1,000 |
| X3 | Credit sale 1,000 ("Credit Terms - 30 days") | Asha Sales Dr 1,000 only | Asha: Sales Dr 1,000 only |
| X4 | Cash expense voucher 500 to "Shop Rent" | Cash Account Expenses Dr 500; Shop Rent Expenses Cr 500 | none |
| X5 | Bank expense voucher 500, ACC-1 | Bank Account Expenses Dr 500; Shop Rent Expenses Cr 500 | bank book "Expenses-Bank" Dr 500 |
| X6 | Cash income voucher 700 "Interest" | Cash Account Income Cr 700; Interest Income Dr 700 | none |
| X7 | Contra cash to bank 300, ACC-1 | Bank Account Contra Cr 300; Cash Account Contra Dr 300 | bank book "Contra" Cr 300 |
| X8 | Contra bank to cash 200, ACC-1 | Cash Account Contra Cr 200; Bank Account Contra Dr 200 | bank book "Contra" Dr 200 |
| X9 | Fund transfer 1,000 ACC-1 to ACC-2 | Bank Account To Transfer-Withdraw Dr 1,000; By Transfer-Diposit Cr 1,000 | bank book ACC-1 "Fund To Transfer" Dr 1,000; ACC-2 "Fund By Transfer" Cr 1,000 |
| X10 | Fund deposit 2,000 into ACC-1 | Bank Account Fund Deposit Cr 2,000 | bank book ACC-1 "Fund Deposit" Cr 2,000 |
| X11 | Bank account ACC-1 opened with 5,000 on 1 Apr | Bank Account "A/c Opening Balance" Cr 5,000 | bank book ACC-1 "Opening Balance" Cr 5,000 |
| X12 | Cash purchase 5,900, previous due 0, paid 5,900 | Supplier Purchase Cr 5,900; Cash Account Payment Dr 5,900 | Supplier: Purchase Cr 5,900; Payment (Cash Account) Dr 5,900 |
| X13 | Sales return 250 paid back in cash | Asha Sales Return Cr 250; Cash Account Sales Return Dr 250 | Asha: Sales Return Cr 250; Cash Return Dr 250 |
| X14 | Payroll advance 400 to employee "Ravi" | Cash Account Payroll Advance Dr 400; Ravi Payroll Advance Cr 400 | none |

**Hub today:** nothing. The Hub keeps `documents`, `document_lines`, `payments(method, amount_minor, kind, at, document_id, party_id)`, `stock_moves`. A cash book can be built from `payments` by method; there is no expense, income, contra, transfer or bank account record. **Port:** a new `accounts` module with real double entry (account, debit, credit, date, source document), posted by the same events; see B11.

### B3. Account heads and the two voucher screens

**Account heads** (`frmAccountHead`, `B/frmAccountHead.vb`): table `AccountHead(ID, a1, a2, a3)`. `a1` is the head name; `a2` is its group; `a3` is a short type code set from the group chosen (`:396-436`):

| Group (`a2`) | Code (`a3`) | Meaning |
|---|---|---|
| Goods and Services Tax | Tax | tax paid to the government |
| Statutory Taxes | Tax | |
| Expenses (Direct/Indirect) | Exp | |
| Fixed Assets | Exp | an asset bought |
| Security & Deposit (Assets) | Exp | |
| Loan & Advance (Assets) | Exp | money lent |
| Income (Direct/Indirect) | Inc | |
| Loan (Liability) | Inc | money borrowed |
| Capital Account | Inc | owner's money put in |

A head name must be new (`:803`); the same head in the same group is refused (`:784`). The expense voucher offers heads with code Exp or Tax (`B/frmVoucher.vb:1460`); the income voucher offers the Inc heads (read by symmetry, not checked). The default list of heads came with the database script, which is not in the repository (**not understood**).

**Expense voucher** (`frmVoucher`, "Expenses Voucher Entry"): payee name, date, details, payment mode Cash or Bank (bank needs an account number), and a grid of lines: head (`Particulars`), amount, and the head's group (`Note`, filled from `AccountHead.a2`, `:1503-1530`). Grand total = sum of lines (`:949`). Save writes `Voucher`, one `Voucher_OtherDetails` row per line (with `Date` and `PModeD` = Cash or Bank), the two `LedgerBook` rows for the **total** (B2), and for Bank a bank book row. Refused: no payee, empty grid, no payment mode, bank mode without account (`:1947-1963`). Edit deletes and re-inserts the detail rows (`:2094-2102`) and rewrites the ledger rows. Number = prefix `Invcode.c9` + counter `SrExpenses` + suffix `c19`. Quirk: the ledger sees only the payee name, not the heads, so the general ledger cannot tell rent from tax; the P&L and balance sheet read `Voucher_OtherDetails.Note` instead.

**Income voucher** (`frmIncome`): the same shape with `Income` and `Income_OtherDetails`; money in. Capital put in and loans taken are entered here too, as heads in the groups "Capital Account" and "Loan (Liability)".

**Test vectors B3:**

| # | Inputs | Result |
|---|---|---|
| V1 | Voucher to "City Landlord", cash, lines Rent 2,000 (group Expenses) and GST paid 1,500 (group Goods and Services Tax) | grand total 3,500; ledger Cash Account Dr 3,500, City Landlord Cr 3,500; two detail rows |
| V2 | Same with mode Bank and no account | refused "Please select bank account number" |
| V3 | Voucher with an empty grid | refused "sorry no data added to grid" |
| V4 | Add head "Rent" in group "Expenses (Direct/Indirect)" | code Exp; saving "Rent" again refused |
| V5 | Add head "Owner Capital" in group "Capital Account" | code Inc |
| V6 | Income voucher, bank mode, 700 | Bank Account Cr 700, name Dr 700, bank book "Income-Bank" Cr 700 |

**Hub today:** none. **Port:** `expense` and `income` documents with lines (head, amount), payment method and optional bank account; account heads as a table with a fixed set of group types (expense, tax, asset, liability, capital, income) so reports do not depend on the group's English name.

### B4. Cash book, bank book, contra, fund transfer, bank accounts

- **Cash in hand** = `sum(Credit) - sum(Debit)` of `LedgerBook` rows named "Cash Account", all dates (`B/frmContra.vb:849`, `frmRefundAmt.vb:1056`). There is **no opening cash entry**; opening cash can be given only by an income voucher in the group Capital Account paid in cash.
- **Bank balance of one account** = `sum(Credit) - sum(Debit)` of `BankAccountLedger` for the account number, all dates (`B/frmBankAccountStatements.vb:362`, `frmContra.vb:824`).
- **Cash book** (`frmCashLedger`, `B/frmCashLedger.vb`): rows of `LedgerBook` named "Cash Account" in a window, shown as `Date, PartyName, LedgerNo, Label, Debit, Credit`; the footer is `sum(Credit) - sum(Debit)` of the **window** (not including the balance before the window) (`:475-496`). Print passes `Date, PartyName as Name, LedgerNo, Label, Credit, Debit` to the report (`:540`). **Bank ledger** (`frmBankLedger`) is the same for the name "Bank Account" (all bank accounts together); **bank account statement** (`frmBankAccountStatements`) is per account from `BankAccountLedger` (`:258-362`).
- **Contra** (`frmContra`, "Contra Voucher Entry"): type "Cash-In-Hand to Bank Account" or "Bank Account to Cash-In-Hand"; fields: bank account, beneficiary name, amount, date; screen shows cash in hand and bank balance. Refused: no account, no name, no amount. **Warning only** (Yes/No): cash to bank above cash in hand, or bank to cash above the bank balance ("Transferred amount must be less than or equal to ... Do you really want to proceed ?", `:1245-1262`). Writes `Contra` and the rows in B2 (X7, X8). Edit: delete ledger rows and re-save (`:1285-1295`).
- **Fund transfer** (`frmFundTransfer`): between two different bank accounts; **hard refusal** when amount is above the from-account balance ("Transferred Amount must be less than or equal to balance amount") or the accounts are the same (`:1255-1270`). Writes `FundTransfer`, two bank book rows and two ledger rows (X9).
- **Fund deposit** (`frmFundDeposit`): money paid into a bank account by a named depositor; writes `FundDeposit`, one bank book row and one ledger row (X10). It does **not** debit cash, so it is "new money in" (owner capital, loan or other).
- **Bank account registration** (`frmBankAccountRegistration`): account number, account name, type, opening date, opening balance, active flag, branch. Saving with an opening balance above 0 writes X11. A bank account with postings cannot be removed (not read).

**Test vectors B4:**

| # | Inputs | Result |
|---|---|---|
| K1 | Cash rows: Receipt Cr 1,000; Expenses Dr 500 | cash in hand `1,000 - 500` = 500.00 |
| K2 | Contra cash to bank 300 with cash in hand 500 | allowed; cash in hand 200.00; bank +300.00 |
| K3 | Contra cash to bank 800 with cash in hand 500 | warning "Transferred amount must be less than or equal to Cash-in-Hand amount"; the person may still continue (cash in hand becomes -300.00) |
| K4 | Fund transfer 1,000 from ACC-1 (balance 1,500) to ACC-2 | ACC-1 500.00; ACC-2 +1,000.00 |
| K5 | Fund transfer 2,000 from ACC-1 (balance 1,500) | refused |
| K6 | Fund transfer from ACC-1 to ACC-1 | refused "Both the accounts must be different" |
| K7 | Bank rows ACC-1: Opening Cr 5,000; Sale-PhonePe Cr 1,000; Payment-By Cheque Dr 2,000 | balance `6,000 - 2,000` = 4,000.00 |
| K8 | Cash book window 1 Oct to 31 Oct, rows in the window Cr 400, Dr 100 (cash before the window 50) | footer 300.00 (not 350.00) |

**Hub today:** none (no bank accounts, no cash book). `ReportService.Payments(from, to)` totals the payment methods of a window. **Port:** cash in hand = sum of cash-method payments and cash vouchers, with an opening cash setting (fix the old gap); bank balance per bank account with the movements above; contra, transfer and deposit as simple documents; warn (do not forbid) on contra above balance; forbid transfer above balance.

### B5. General ledger, day book, trial balance

- **General ledger** (`frmGeneralLedger`, `B/frmGeneralLedger.vb:144-188`): all `LedgerBook` rows in a window ordered by `ID, Date, LedgerNo`, columns `Date, Name, LedgerNo, Label, Credit, Debit`, grouped and totalled by the report file (not read). It lists names including "Cash Account" and "Bank Account", customers, suppliers and expense or income names, side by side.
- **Day book** (`frmGeneralDayBook`, `B/frmGeneralDayBook.vb:316-342`): the same rows for **one date** (the "from" date: from midnight to 23:59:59), ordered by `ID, LedgerNo`. The "to" date is ignored.
- **Trial balance** (`frmTrialBalance`, `B/frmTrialBalance.vb:348-392`): per `Name` in a window: `Debit = sum(Debit) - sum(Credit)` when that is above 0 else 0; `Credit = sum(Credit) - sum(Debit)` when above 0 else 0; ordered by name. The result is sent to the report "rptBalancesheet" (the same Crystal file as the receipts statement). It is windowed: no opening balances before the window.

**Why it does not balance.** Pair rows exist for expenses, income, contra, transfers, payroll and cash events, but a sale or a purchase on credit writes one row. And the sign of cash is mirrored while customers and suppliers are not.

**Test vectors B5** (events: X1 cash sale 1,000; X3 credit sale 1,000; X4 cash expense 500; X12-style credit purchase 5,900 from "Mehta Traders" with no payment):

| # | Rows (window) | Trial balance rows | Totals |
|---|---|---|---|
| T1 | Asha: Dr 1,000 (X1), Dr 1,000 (X3); Cash Account: Cr 1,000 (X1), Dr 500 (X4); Shop Rent: Cr 500 (X4); Mehta Traders: Cr 5,900 | Asha Debit 2,000; Cash Account Credit 500; Shop Rent Credit 500; Mehta Traders Credit 5,900 | Debit 2,000; Credit 6,900; difference 4,900 |
| T2 | Only X1 | Asha Debit 1,000; Cash Account Credit 1,000 | balanced 1,000 and 1,000 |
| T3 | Only X4 | Cash Account Debit 500; Shop Rent Credit 500 | balanced |
| T4 | Day book for 10 Oct with rows on 10 and 11 Oct | rows of 10 Oct only | |
| T5 | General ledger 1 to 31 Oct | every row of October, no balances | |

**Hub today:** none. **Port:** a real trial balance over a double-entry journal where debit total equals credit total by construction and a test asserts it; keep the day book and ledger views.

### B6. Profit and loss

**What a person sees.** `frmProfitloss` ("PROFIT AND LOSS", `B/frmProfitloss.vb`), from and to dates, button Generate, two columns DEBIT and CREDIT, and "Net Profit :" or "Net Loss :" (`cal3`, `:1404-1426`). A second button "Billwise P/L Report" opens `frmBIllwise_ProfitReport` (C). `BalanceSheetForm` repeats the same P&L at its top with the same boxes.

**The rule** (windowed by the dates; every query is `date between from and to` with date-only values):

CREDIT side (`cal2`, `:1367`):
1. **Sales** = `sum(GrandTotal) - (sum(CGST) + sum(SGST) + sum(IGST) + sum(CESS))` of `InvoiceInfo` by `InvoiceDate` (`:1065`). Freight, other charges and round-off stay inside it.
2. **Purchase return (debit note)** = `sum(GrandTotal)` of `PurchaseReturn` minus its tax where `RCM = 'No'` (`:1087`, `:1109`, box `TextBox2 = TextBox15 - TextBox16`).
3. **Service (advance)** = `sum(AdvanceDeposit)` of `Service` by `ServiceCreationDate` (`:1153`).
4. **Service (bill)** = `sum(RepairCharges) - sum(Upfront)` of `InvoiceInfo1` (`:1175`).
5. **Income** = `sum(Amount)` of `Income_OtherDetails` where `Note = 'Income (Direct/Indirect)'` (`:1131`): capital and loans taken are not income.

DEBIT side (`cal1`, `:1334`):
1. **Purchase** = `sum(GrandTotal) - sum(PreviousDue)` of `Stock` minus `sum(CGST + SGST + IGST + CESS)` of `Stock` where `ReferenceNo2 = 'No'` (`:1197`, `:1219`, box `TextBox6 = TextBox13 - TextBox14`). When `ReferenceNo2` is 'Yes' (reverse charge) the tax is **not** removed.
2. **Sale return (credit note)** = `sum(GrandTotal) - taxes` of `SalesReturn` (`:1241`).
3. **Expenses** = misc expenses + payroll advance + payroll payment, where misc = `sum(Amount)` of `Voucher_OtherDetails` whose `Note` is **not** in ('Goods and Services Tax', 'Loan & Advance (Assets)', 'Fixed Assets') (`:1264`), payroll advance = `sum(Amount)` of `AdvanceEntry` by working date (`:1289`), payroll payment = `sum(NetPay)` of `EmployeePayment` by payment date (`:1314`).
4. **Opening stock value** = `sum(PPrice * Qty)` of `Product_OpeningStock` rows whose `PAddDate` is in the window (`:1043`): products added in the window, at purchase price. There is **no closing stock** on the credit side.

`Profit = TotalCredit - TotalDebit`: positive "Net Profit", negative "Net Loss", zero "Profit / Loss". In `BalanceSheetForm` the formula is `TextBox10 - (TextBox9 + TextBox50)`, the same with the opening stock as a separate box (`:2304`).

**Quirks.** (1) No closing stock: money spent on stock still on the shelf reduces profit; a shop that buys more than it sells shows a loss. (2) Cost of sales is not used; purchases stand in for it. (3) `Security & Deposit (Assets)` and `Statutory Taxes` count as expenses (only GST, loans-and-advances and fixed assets are excluded). (4) Sales include freight, other charges and round-off. (5) Purchase tax is removed only when `ReferenceNo2 = 'No'`. Fix?: yes for 1 to 3 when the Hub builds a real P&L: use cost of goods sold (below) and closing stock; **keep** this "cash-style" view as an option named plainly, because owners know its numbers.

**Profit by cost of goods sold (what the old POS already has per bill):**
- Each bill line stores `Invoice_Product.Margin` at sale time (`B/frmPOSNewTuch.vb:13443-13652`). Tax types **Exclusive, Exempt GST, No Taxes and NON GST**: `Margin = round(mainQty * (SalesRate - PurchaseRate) - LineDiscount, 2)`. Tax type **Inclusive**: `Margin = round(mainQty * SalesRate - LineDiscount - (CGSTAmt + SGSTAmt + IGSTAmt + CESSAmt) - PurchaseRate * mainQty, 2)`. `PurchaseRate` is `Temp_Stock.EPPrice` of the barcode: the **effective purchase price per main unit of the last purchase**, `TaxableAmt / Qty` of the purchase line, set on every purchase (`B/frmPurchaseEntry.vb:11551-11600`, `Stock_Product` column order `:11455`). So the cost is the **latest purchase cost, snapshotted on the sale line**: not average cost, not first-in-first-out.
- Bill profit (`B/frmBIllwise_ProfitReport.vb:146`): `Cost_Price = sum(PurchaseRate * Qty)`, `Profit = sum(Margin)`, `Actual_Profit = sum(Margin) - BillDiscount`, `actual = GrandTotal - tax - Cost_Price`.

**Test vectors B6:**

| # | Inputs (window) | Result |
|---|---|---|
| P1 | Invoices grand total 11,800 with taxes 1,800 | Sales 10,000.00 |
| P2 | Stock: grand total 6,000, previous due 0, non-reverse-charge tax 900 | Purchase 5,100.00 |
| P3 | Sales return GT 1,180 tax 180 | 1,000.00 (debit side) |
| P4 | Purchase return GT 590, tax (RCM No) 90 | 500.00 (credit side) |
| P5 | Vouchers: Rent 2,000 (Expenses); GST paid 1,500; Fixed asset 10,000; Loan given 500; Security deposit 300 | misc expenses 2,000 + 300 = 2,300.00 |
| P6 | Payroll advance 400; payroll payment 3,000; opening stock added 4,000; income 700; service advance 200; service bill 300 | |
| P7 | All of the above together | Credit = 10,000 + 500 + 200 + 300 + 700 = 11,700.00; Debit = 5,100 + 1,000 + (2,300 + 400 + 3,000) + 4,000 = 15,800.00; result -4,100.00, "Net Loss : 4,100.00" |
| P8 | Same with opening stock 0 | Debit 11,800.00; result -100.00 |
| P9 | Nothing in the window | 0.00, "Profit / Loss :" |
| M1 | Line Exclusive: qty 2, rate 100, cost 60, discount 10 | margin 2 * 40 - 10 = 70.00 |
| M2 | Line Inclusive: qty 1, rate 118, tax 18 (9 + 9), cost 70, discount 0 | margin 118 - 0 - 18 - 70 = 30.00 |
| M3 | Bill of M1 + M2, bill discount 15 | Profit 100.00; Actual_Profit 85.00; Cost_Price 2 * 60 + 70 = 190.00 |
| M4 | Unit conversion: sold 6 pieces of a box of 12, rate per box 600, cost per box 400, no discount, Exclusive | main qty 0.5; margin 0.5 * (600 - 400) = 100.00 |
| M5 | Purchase line: taxable 1,180 for qty 10 (after discount) | `EPPrice` 118.00 per unit |

**Hub today.** `ReportService` has `DailySales`, `Summary`, `TopItems` (revenue), `TaxSummary`, `Payments`, `Outstanding`, `TopCustomers`, `StockValues` (`on hand * cost`), `Purchases`. **No profit report and no per-line cost snapshot** (the document line has `unit_price_minor` and discount only). **Port:** store `cost_minor` on each document line at issue (the item's cost then), then profit by bill, by item, by day = line revenue ex tax minus cost times quantity; add the "cash-style" P&L as a separate report if the owner wants old numbers; tests P1 to P9, M1 to M5.

### B7. Balance sheet screens

**B7.1 `frmBalancesheet` ("receipts and payments of the period")** (`B/frmBalancesheet.vb`, wired in `GelButton1_Click` `:4622-4668`). It reads one query per box, windowed by the dates (default: financial-year start to today), and adds boxes:

- Sales block from `InvoiceInfo`: net (`GrandTotal - tax - freight - round-off + other charges`), CGST, SGST, IGST, CESS, freight, other charges, round-off, grand total, total paid (`:3061`).
- Purchase block from `Stock` (`GT - PreviousDue`, charges, round-off) and non-reverse-charge taxes (`:3106`, `:3138-3210`); purchase tax under reverse charge from `Stock_Product` tax amounts (`:3932`).
- Sales return block (all and cash-paid), purchase return block (all, cash-paid, reverse charge yes or no), service (repair) block, credit customer receipts (cash, non-cash), supplier payments (cash, non-cash), service advances, voucher amounts by group and by cash or bank (`PModeD`): fixed assets, loan and advance (assets), expenses, GST paid; income, loan (liability) and capital by cash or bank; payroll advance, payroll payment by cash and by bank (`:3343-4078`).
- Receipts by mode from bills: `sum(TotalPaid)` of `Invoice_Payment` where mode in the bank modes, and where mode is 'By Cash' (`:3972-3994`).
- Boxes add up in groups: cash receipts `TextBox46 = TextBox44 + TextBox45 + TextBox47 + TextBox41 + TextBox83` (bill cash receipts, service advance, service paid, customer cash receipts, cash purchase-return refunds) and bank receipts `TextBox90 = TextBox72 + TextBox84`; total receipts `TextBox103 = TextBox90 + TextBox46`; cash payments `TextBox51 = TextBox50 + TextBox82 + TextBox40` (supplier cash payments, cash sales-return refunds, `sum(TotalPayment)` of purchases whose `Stock.PurchaseType = 'Cash'`, `:4398`), bank payments `TextBox89 = TextBox88 + TextBox85` (`sum(TotalPayment)` of purchases with `PurchaseType = 'Bank'`, `:4420`, plus supplier payments by non-cash modes); total payments `TextBox102 = TextBox89 + TextBox51`; other receipts `TextBox101 = TextBox94 + TextBox65` (income, loan taken, capital: cash and bank); other payments `TextBox100 = TextBox98 + TextBox99` (fixed assets, loans given, expenses, payroll: cash and bank) (`:4079-4545`).
- The tax lines: output tax = sales tax minus sales-return tax; input tax = purchase tax minus purchase-return tax; net by head (`TextBox57 = TextBox9 - (TextBox2 + TextBox3 + TextBox4 + TextBox5)` and similar).
It is a statement of what came in and went out by type, **without** an opening cash or bank balance. **Not understood:** the last boxes and what the Crystal print shows as "closing".

**B7.2 `BalanceSheetForm` ("Balance Sheet": LIBILITIES and ASSETS, `B/BalanceSheetForm.vb`)**:
- Profit and loss block as B6 (`TextBox11`).
- **Cash in hand** `TextBox12` = `sum(Credit) - sum(Debit)` of `LedgerBook` named "Cash Account" in the window (`:2530`). **Bank balance** `TextBox13` = the same for "Bank Account" in `LedgerBook` (`:2574`; a second function reads the bank book `:2552` and writes the same box: the last one run wins, **not understood** which).
- **Sundry debtors** `TextBox14` = `sum(Debit) - sum(Credit)` of `CustomerLedgerBook` in the window (`:2596`). **Sundry creditors** `TextBox15` = `sum(Credit) - sum(Debit)` of `SupplierLedgerBook` in the window (`:2618`).
- **Fixed assets** `TextBox31` = `Voucher_OtherDetails` group Fixed Assets; **Loan and advance (assets)** `TextBox32`; **Capital account** `TextBox33` and **Loan (liability)** `TextBox34` from `Income_OtherDetails` (`:2705-2749`, `:2006-2028`).
- **Taxes:** `Output = SaleGST - SaleReturnGST + (OutputCESS - SaleReturnCESS) + ServiceTax`; `Input = InputGST + RCM GST net + RCM CESS net + InputCESS - PurchaseReturn GST + PurchaseReturn CESS`; `Duties and Taxes (TextBox27) = Output - Input - GST paid to the government (TextBox16)` (`:2792-2849`). A positive number is a liability, negative an asset.
- **Stock in hand** `TextBox47` = opening stock value + (purchases ex tax + tax on purchases) - (cost of goods sold + tax on that cost), where cost of goods sold = `sum(Invoice_Product.PurchaseRate * Qty)` of the bills and its tax = that cost times the line's tax percents (`:3055-3150`). It ignores returns, damage and adjustments, so it can differ from the real stock.
- **Liabilities total** `TextBox38 = ProfitLoss + SundryCreditors + (DutiesAndTaxes + Capital + LoanLiability)` (`:2331`); **Assets total** `TextBox37 = Cash + Bank + (Debtors + FixedAssets + LoanAsset + StockInHand)` (`:2892`). A "Difference in Opening Balance" label sits under them; the formulas for the box beside it (`:2860-2894`) add the totals together instead of subtracting, so the screen's intent is **not understood**. A chart button shows the boxes.

**Quirks.** The balance sheet is built from windowed sums, so it is right only for a window that starts when the books start; opening balances dated "today" at master creation fall in or out of the window. Nothing forces assets to equal liabilities. Sundry debtors can be negative. Fix?: yes, rebuild on the double-entry journal; keep the layout (liabilities left, assets right).

**Test vectors B7:**

| # | Inputs | Result |
|---|---|---|
| S1 | Cash Account rows: Cr 1,000, Dr 500 | Cash in hand 500.00 |
| S2 | Customer ledger window: Dr 2,000, Cr 1,000 | Sundry debtors 1,000.00 |
| S3 | Supplier ledger window: Cr 5,900, Dr 2,000 | Sundry creditors 3,900.00 |
| S4 | Sales GST 1,800; sales-return GST 180; no CESS; service tax 0; purchase input GST 900; purchase-return GST 90; GST paid 400 | Output 1,620; Input 810; Duties and Taxes = 1,620 - 810 - 400 = 410.00 (a liability) |
| S5 | Opening stock 4,000; purchases ex tax 5,100 with tax 900; cost of goods sold 3,000 with tax 540 | Stock in hand = 4,000 + 5,100 + 900 - 3,000 - 540 = 6,460.00 |
| S6 | Net loss 4,100 (P7), creditors 3,900, duties and taxes 410, capital 10,000, loan 0 | Liabilities = -4,100 + 3,900 + 410 + 10,000 + 0 = 10,210.00 |
| S7 | Cash 500, bank 4,000, debtors 1,000, fixed assets 10,000, loan given 500, stock 6,460 | Assets = 500 + 4,000 + 1,000 + 10,000 + 500 + 6,460 = 22,460.00 (does not equal S6: no balance is forced) |

### B8. Advance entries and payroll (feed only)

`AdvanceEntry(ID, workingdate, employeeid, amount, deduction)`: an advance paid to an employee: `amount` is the advance; `deduction` is taken back when salary is paid. The employee's advance balance = `sum(Amount) - sum(Deduction)` (`B/frmAdvanceEntry.vb:342`). Saving writes the cash rows in B2 (X14) with label "Payroll Advance". Salary payment (`frmEmployeePayment`) writes "Payroll Payment" to cash or bank. The staff module belongs to another study; here it only matters that **both feed the P&L expenses** (B6) and the cash book.

### B9. Porting notes for the books

1. Build the books as **views over documents, payments and vouchers** plus a small journal table, not as the old pair-of-rows tables. Post by event with the table in B2, but store each row with a **normal sign** (cash and bank as assets: Dr for money in, Cr for money out) and write a conversion for imported `LedgerBook` rows: for names "Cash Account" and "Bank Account" and for expense or income names swap Debit and Credit; keep customers and suppliers as they are.
2. Import: balances only (A1.11, A3.7, bank accounts' `BankAccountLedger` sums, cash from `LedgerBook`), not every old row, unless the owner asks for history.
3. Golden tests: X1 to X14 (postings), K1 to K8 (cash and bank), V1 to V6 (vouchers), T1 to T5 (trial balance; the Hub's version must balance), P1 to P9 and M1 to M5 (profit), S1 to S7 (balance sheet figures).
4. Do not copy: windowed balances (use all-time balances plus a period total), the "today" opening dates, the mirrored sign, delete-then-reinsert edits.
5. Decide with the owner: keep the cash-style P&L as "Income and Expense statement" and add a proper "Profit (cost of sales)" report; keep the debtors, creditors, cash, bank, stock, tax lines in the balance sheet.

### B10. Not understood (books)

- Crystal report files (`rpt*.rpt`) were not read: running balances, grouping and totals of the General Ledger, Day Book, Cash Book, Customer and Supplier ledgers and the Trial Balance print are not known.
- Which of the two bank balance functions in `BalanceSheetForm` runs last (`:2552`, `:2574`).
- The final boxes of `frmBalancesheet` and the "Difference in Opening Balance" box of `BalanceSheetForm`.
- The default `AccountHead` rows, the income voucher's list of heads (assumed the Inc group), the bank account removal checks.
- `Invcode` columns other than `c6`, `c7`, `c9`, `c16`, `c17`, `c19` (prefix and suffix of other numbers).
- The `LedgerBooksalesman1` ledger (salesman commission and payments) and `frmBrokerCalc`/`frmBrokerLedger` (broker commission): only their existence was noted; the staff study covers them.

## C. Reports

Status of this topic: written (first pass, the reports named in the owner's list, with the rule behind every number). The printed layouts are Crystal Reports files (`rpt*.rpt`, binary, **not read**); what is known here comes from the screen code and its SQL, so grouping, running totals and page totals that the report file adds are listed under "Not understood".

### C0. How every old report works

1. A screen asks for a date window (and sometimes a customer, supplier, product, operator, till or tax type). It runs one SQL text and fills a table. A button then sends the table to a Crystal file with parameters `p1`, `p2` (the dates) and so on, and shows it in `frmReport` (a viewer with print and export).
2. Windows are `date between from and to` with **date-only** values (dates are saved without a time of day), or `date >= from and date < to + 1 day`. Both give the same result when dates have no time. Keep: a window includes both end days.
3. Amounts shown are the stored columns; there is no re-calculation except where a rule is written below.
4. Most screens also have "Export" to Excel (`ClosedXML`) of the grid.
5. The Hub's way: `ReportService` returns typed rows and `Csv.Build` exports (`Reports/ReportService.cs:168`).

### C1. The list of reports and where each is described

| Report | Screen | Described in |
|---|---|---|
| Sales (summary 1, 2, 3, details by date, customer, till, operator; net sale; D-sale; multi-payment) | `frmSalesReport` | C2 |
| Purchase (summary and details, by supplier, category, product) | `frmPurchaseReport` | C3 |
| Profit by bill | `frmBIllwise_ProfitReport` | B6 (rule), C4 |
| Profit by product | `frmProductwiseProfit` | C4 |
| Profit and loss | `frmProfitloss` | B6 |
| Best and low selling items | `frmBestAndLowSellingItemsReport` | C5 |
| Stock in and stock out lists | `frmStockInAndOutReport` | C6 |
| Current stock (stock in hand, expiry) | `frmCurrentStock` | C6 |
| Stock movement | `frmStockMovementReport` | C7 |
| Customer outstanding, debtors, supplier outstanding | `frmCustomerOutstanding`, `frmDebtorsReport`, `frmSupplierOutstanding` | A1.5, A3.5 |
| Customer ledger, supplier ledger, credit terms statement | `frmCustomerLedger`, `frmSupplierLedger`, `frmCreditTermsStatements` | A1.2, A3.2 |
| Supplier-wise purchase | `frmSupplierwise_report` | C3 |
| Tax report | `frmTaxReport` | C8 |
| Salesman commission | `frmSalesmanCommmissionReport` | C9 |
| Product sales history | `frmSales_ProductHistory` | C2 |
| Serial-wise report | `frmSerialwiseReport` | A2.9 |
| General ledger, day book, cash book, bank book, trial balance, balance sheet | | B4, B5, B7 |
| GSTR-1, GSTR-3B, HSN summary, GST registers, e-way bill, TCS | `frmGSTR1`, `frmGSTR3B`, `frmGSTR1_HSNC`, `frmGSTDetails*`, `GSTSaleRegister`... | India module study (not this file) |

### C2. Sales report (`frmSalesReport`, `B/frmSalesReport.vb`)

**Filters.** Date window (invoice date); sale type All, Retail or Wholesale (column `InvoiceInfo.CType`, `:832-837`); tax type GST or NON GST; operator; terminal (till) id; customer name. A note on the screen: "If you retrieve Details Report, may be delayed."

**Buttons.** "Summary Report-1, -2, -3", three pairs of "Summary Report / Details Report" (by date, by customer, by terminal, by operator, by tax type), "Net Sale", "D-Sale", "Sale Report (Multi_Payment)". Each pair runs a different Crystal file (`rptSales`, `rptSales1`, `rptSalesD`, `rptOverallSales`, `rptSaleDayBook`, `rptProfitAndLoss` for the margin version).

**Rules and columns seen in the code:**
1. **Summary** rows come from `InvoiceInfo` (one row per bill, joined to `Customer`): bill number, date, tax type, customer, sales-man, sub-total, CGST, SGST, IGST, CESS, freight, other charges, total, round-off, grand total, total paid, balance, bill discount, offer, loyalty, coupon, gift (the `InvoiceInfo` columns).
2. **Totals line** (`:947-952`): `sum(GrandTotal)`, `sum(TotalPaid)`, `sum(Balance)` of the bills in the window (and sale type).
3. **Margin total** (`:975-980`): `sum(Invoice_Product.Margin)` over the same bills (the line margin rule, B6).
4. **Details** add the lines (`Invoice_Product`) of every bill; they join three tables and are slow, hence the note.
5. **Year totals** for the chart: `sum(GrandTotal)` grouped by `YEAR(InvoiceDate)` (`:1037`).
6. **Net Sale** (`GelButton15`, `:1839-1910`, `rptSaleDayBook`): the bills of the window plus the sum of payments by mode: `sum(Invoice_Payment.TotalPaid)` grouped by `PaymentMode` for the window (`:1876`). It does **not** subtract sales returns in the code read (the name suggests it should): **not understood**.
7. **D-Sale** (`GelButton14`): the same list from a **different table**, `InvoiceInfoD` (`:1805`). It looks like an archive or a "deleted bills" table; **not understood**.
8. **Bills are not cancelled by a flag:** a deleted bill is removed (with its ledger rows), so these reports have no "cancelled" column.

**Test vectors C2:**

| # | Inputs | Result |
|---|---|---|
| R1 | Bills in window: GT 1,180 paid 1,180; GT 590 paid 500 | totals GrandTotal 1,770.00; TotalPaid 1,680.00; Balance 90.00 |
| R2 | Same, sale type Retail where the second bill is Wholesale | GrandTotal 1,180.00 |
| R3 | Bills with lines margins 70.00 + 30.00 and 20.00 | margin total 120.00 |
| R4 | Window with no bill | "Sorry...No record found" |
| R5 | Payments in the window: By Cash 1,000, PhonePe 500, Credit Terms - 7 days 300 | Net Sale payment table: By Cash 1,000.00; Credit Terms - 7 days 300.00; PhonePe 500.00 (ordered by mode name) |

**Multi-payment sale report** (`frmSaleReport_Multi_Payment`, `B/frmSaleReport_Multi_Payment.vb:244-415`). Filter: date window **and cashier (operator)**. One row per bill: invoice number, date, customer name, grand total, then one column per payment mode: `ByCash` (mode 'By Cash'), `ByCheque`, `ByCreditCard`, `ByDebitCard`, `PhonePe`, `GooglePay`, `Paytm`, `EWallet` ('E-Wallet'), `ByReturn` (mode 'ByReturn': a sales return used as payment), `CreditTerms` (every mode `like 'Credit Terms%'`, summed), then `TotalPaid` = the sum of all those columns (so it **includes the credit amount**), and the operator.

| # | Inputs | Result |
|---|---|---|
| R6 | One bill GT 1,000: By Cash 300, PhonePe 200, Credit Terms - 7 days 500 | ByCash 300; PhonePe 200; CreditTerms 500; TotalPaid 1,000 |
| R7 | Bill paid with By Cash 600 + ByReturn 400 | ByCash 600; ByReturn 400; TotalPaid 1,000 |
| R8 | Operator "anu", bills of another operator in the window | only "anu" bills appear |

**Product sales history** (`frmSales_ProductHistory`, `:270`): last N lines (top N) for a product or all: bill number, date, tax type, customer, state, GSTIN, product, HSN, unit price `(TaxableAmt + Discount) / Qty` (price before discount, ex tax), quantity, unit, discount % and amount, each tax percent and amount, line total; footer = sum of line totals (`:483-500`).

**Hub today:** `DailySales` (documents, net, tax, total, refunds, tips per local day, credit notes subtracted), `Summary` (totals and average per document), `Payments` (totals by method, refunds taken off), `TopCustomers` (credit notes subtracted). **Differences:** the Hub nets credit notes and splits net and tax; it has no sale type (retail or wholesale; the Hub has `price_level` on the customer), no operator filter, no till, no per-bill payment-mode columns, no margin. **Port:** add operator and till filters, a per-bill "payments by method" table (R6, R7) and the margin figures from line cost (B6).

### C3. Purchase report (`frmPurchaseReport`, `B/frmPurchaseReport.vb`)

**Filters.** Date window (`Stock.Date`), supplier, category, product. **Summary** rows are `Stock` columns: system number, purchase type (Cash, Bank or Credit), reference numbers 1 and 2 (`ReferenceNo2` is the reverse-charge flag 'Yes' or 'No'), date, supplier, supplier invoice number and date, tax type, SGST, CGST, IGST, CESS, sub-total, previous due, freight, other charges, total, round-off, grand total, total payment, payment due, remarks (`:666`). **Detail** rows are purchase lines: invoice no, date, product, quantity, MRP, **`Price = (TaxableAmt + DiscountAmt) / Qty`** (unit price before discount, ex tax), CGST, SGST, IGST and CESS amounts, discount amount, total amount, category (`:609`). Year totals: `sum(GrandTotal)` of `Stock` by year (`:670`). `Stock.GrandTotal` **includes the previous due** (A3.0); a report that adds grand totals counts earlier dues again. **Quirk (fix):** the Hub report must subtract `PreviousDue` (as the P&L does, B6).

| # | Inputs | Result |
|---|---|---|
| U1 | Purchase line taxable 1,180, discount 20, qty 10 | Price 120.00 per unit |
| U2 | Two purchases: GT 5,900 (previous due 0) and GT 6,900 (previous due 1,000) | sum of `GrandTotal` 12,800.00 but real new purchases 11,800.00 |
| U3 | Category filter "Dairy" | lines of products in that category |

**Supplier-wise report** (`frmSupplierwise_report`): the same detail rows plus supplier name, state and GSTIN and supplier invoice number and date, filtered by supplier; `Calculate` totals the line amounts (`:696`).

**Hub today:** `ReportService.Purchases(from, to)` gives two numbers (received total and unpaid total). **Port:** a purchase register (header and lines) with the columns above, with the previous-due fix.

### C4. Profit by bill and by product

**By bill** (`frmBIllwise_ProfitReport`, `:146-175`): one row per bill in the window, joined to its lines: date, bill number, customer, product discount total (`sum(Invoice_Product.Discount)`), grand total, total paid, balance, cost price (`sum(PurchaseRate * Qty)`), total tax (`sum` of the four tax amounts of the lines), bill discount, profit (`sum(Margin)`), actual profit (`sum(Margin) - BillDiscount`), and "actual" (`GrandTotal - tax - cost`). The grid has a status PROFIT or LOSS from the sign of the profit and totals of profit and loss amounts. Rules: B6 (line margin; cost = last purchase price snapshot).

**By product** (`frmProductwiseProfit`, `BindData` `:255-330`): the same style of grid for lines, filled by another form's table; adds the column "Status" = "LOSS" when the profit column is below 0, else "PROFIT", and sums two columns (index 16 and 18). The source table's SQL was not found in this form: **not understood** which screen feeds it (probably the sales report details). The per-line profit is `Invoice_Product.Margin`.

| # | Inputs | Result |
|---|---|---|
| F1 | Two lines margin 70.00 and 30.00, bill discount 15 | Profit 100.00; Actual_Profit 85.00; PROFIT |
| F2 | One line margin -5.00, no bill discount | Profit -5.00; Actual_Profit -5.00; LOSS |
| F3 | Bill with grand total 342.20, tax 52.20 (34.20 + 18.00), cost 190 | actual = 342.20 - 52.20 - 190.00 = 100.00 |

**Hub today:** none (no cost on the line). **Port:** B6.

### C5. Best and low selling items (`frmBestAndLowSellingItemsReport`, `:383-424`)

One query, two sort orders: `SUM(Invoice_Product.Qty)` per product (code, name, category, sub-category) for bills in the window, **only products with total above 0**, ordered by quantity **descending** (best selling, `rptBestSellingItems`) or **ascending** (low selling, `rptLowSellingItems`). No "top N" limit in the code; the report file may limit. Quantity is in main units including free promotion quantity and is **not** reduced by sales returns.

| # | Inputs | Result |
|---|---|---|
| E1 | Window sales: A 10 and 5, B 3, C none | Best: A 15, B 3. Low: B 3, A 15. C absent |
| E2 | A sold 10, returned 4 | still 10 |
| E3 | Two products with 7 each | order between them not defined |

**Hub today:** `TopItems` orders by **revenue** (line total from the tax result), nets credit notes, limit 20. Differences: ranking key and returns; the Hub has no "low selling". **Port:** add a quantity option and a low-selling list; keep credit-note netting (better than the old).

### C6. Stock reports

- **Stock in / stock out lists** (`frmStockInAndOutReport`, `:385-478`): "Stock in" lists every barcode row with `Qty > 0` of an **active** product (`Product.Status = 'Yes'`): supplier name (shown under the heading "ProductCode"), HSN, name, barcode, quantity, **value at cost** `Product.CostPrice * Qty`, **value at sale** `Temp_Stock.SPrice * Qty`. "Stock out" lists the barcode rows of active products with `Qty <= 0` (zero and negative). Optional supplier filter by `Temp_Stock.SuplName`. Note: the cost value uses `Product.CostPrice` (the typed cost on the product), not the effective purchase price used for profit (`EPPrice`).
- **Current stock** (`frmCurrentStock`, `:578-1198`): one row per barcode of active products (`Qty > 0` or all): product id, code, name, HSN, part no, barcode, purchase price (`PPrice`), sale price (`SPrice`), discount, CGST, SGST, CESS, quantity, unit, wholesale price (`WPrice`), MRP, category, sub-category, last price, `Qty - Damage` (usable quantity), `Damage`, description, minimum stock, sale and purchase tax type, godown, rack, batch, manufacturing and expiry dates, size, colour, default quantity, IMEI 1 and 2, effective purchase price (`EPPrice`). Filters by name, category, expiry window ("Expiry Date Detected"), manufacturing window. Totals: sum of quantity (to 3 decimals) and number of rows (`Calculate`, `:875-899`). There is no money total on this screen.
- **Low stock:** `rptLowStock` (a report file; the rule is in the AI companion notes: `Product.MinStock > 0` and `sum(Temp_Stock.Qty) < MinStock`). The screen code for it was not read.

| # | Inputs | Result |
|---|---|---|
| T1 | Barcode rows: B1 qty 5, `CostPrice` 20, `SPrice` 30; B2 qty 0; B3 qty -2; B4 qty 3 of an inactive product | Stock in: B1 (cost value 100.00, sale value 150.00). Stock out: B2, B3. B4 in neither |
| T2 | Row qty 10, damage 2 | usable 8; quantity total counts 10 |
| T3 | Two rows qty 4.500 and 2.250 | total 6.750 |

**Hub today:** `StockValues()` = items with stock above 0 with `on hand * cost` rounded half up (`(2 * on * cost + 1000) / 2000`); `StockList(lowOnly)` with reorder level. No damage, no supplier, no expiry. **Port:** keep the Hub's rounding; add damage and expiry only with batches (A2.9).

### C7. Stock movement (`frmStockMovementReport`, `:417-483`)

Per day and product from `StockMovement(ProductID, OpeningStock, StockIn, StockOut, Date, TransID)`: `Date, PID, ProductName, Max(OpeningStock), Sum(StockIn), Sum(StockOut), ClosingStock = Max(OpeningStock) + Sum(StockIn) - Sum(StockOut)` for rows in the window (`Date >= from and Date < to + 1`), for one product (by name) or all.

**How rows get their `OpeningStock`:** every program event that moves stock saves a row by `ProductSMSave` with `OpeningStock` = `sum(StockIn - StockOut)` of that product's rows dated **before** the event's date (`B/frmProduct.vb:7631`, purchase `B/frmPurchaseEntry.vb:11692`). So all movements of one day share the same opening figure. **Quirk:** entering a movement dated earlier than existing rows does not update the later rows' opening figures; `Max(...)` per day then shows a stale opening. A sale or purchase saved later with a past date makes the report disagree with `Temp_Stock.Qty`. Fix in the Hub: compute the opening as a running sum at report time from `stock_moves`.

| # | Inputs | Result |
|---|---|---|
| G1 | 10 Oct rows: (Open 10, In 5, Out 0), (Open 10, In 0, Out 3) | one row: Open 10, In 5, Out 3, Closing 12 |
| G2 | Product with first movement the opening stock 20 on 1 Apr, then sale 4 on 2 Apr | 1 Apr: Open 0, In 20, Out 0, Closing 20; 2 Apr: Open 20, In 0, Out 4, Closing 16 |
| G3 | A purchase of 10 entered later but dated 1 Apr, existing 2 Apr row (Open 20) | the 2 Apr row still shows Open 20 (stale; should be 30) |

**Hub today:** `stock_moves(item_id, qty_milli, ...)` with `OnHandMilli` = sum; `CatalogService.Adjust`. No movement report. **Port:** a movement report from `stock_moves` with running balance (G1, G2 as tests; G3 fixed).

### C8. Tax report (`frmTaxReport`, `:405-470`)

Bills with tax: `InvoiceInfo` joined to `Customer` where `(CGST + SGST + IGST + CESS) > 0` in the window: invoice number, date, customer code, customer name, CGST, SGST, IGST, CESS, ordered by date. A second list for repair-service bills: `InvoiceInfo1` joined to `Service` and `Customer` where `ServiceTax > 0`: invoice, date, customer code, name, service tax, ordered by name. Totals are added by the report file. Sales tax per rate (GSTR-1, HSN summary, 3B) are in the India module study.

| # | Inputs | Result |
|---|---|---|
| H1 | Bill with CGST 9, SGST 9 | listed |
| H2 | Bill with zero tax (exempt or "No Taxes") | not listed |
| H3 | Bill with IGST 18 | listed, CGST and SGST 0 |

**Hub today:** `TaxSummary(from, to)` by tax code and percent with taxable value, components and cess. It is by rate, not by bill. **Port:** add the bill-wise tax list as an option.

### C9. Salesman commission (`frmSalesmanCommmissionReport`, `:195-211`)

`Salesman_Commission(InvoiceID, CommissionPer, Commission)` has one row per bill that had a salesman. At the till (`B/frmPOSNew.vb:10765-10782`): `base = sum over lines of (Qty * SalesRate - LineDiscountAmount)` (net of line discount, before tax; **bill discount ignored**) and `Commission = base * CommissionPer / 100`, where `CommissionPer` comes from the salesman's master (`SalesMan.CommissionPer`). The report groups by salesman for bills in the window: salesman id, name, city, contact, `sum(Commission)`. Payments to salesmen and their ledger (`frmSalesManPayment`, `LedgerBooksalesman1`) belong to the staff study.

| # | Inputs | Result |
|---|---|---|
| W1 | Lines: qty 2, rate 100, discount 10; qty 1, rate 50, discount 0; commission 5 % | base 240.00; commission 12.00 |
| W2 | Same, bill discount 20 | commission still 12.00 |
| W3 | Two bills of the same salesman, 12.00 and 8.00, one in the window | report 12.00 (the bill outside is left out) |
| W4 | Bill with no salesman | no commission row |

**Hub today:** none. **Port:** staff module.

### C10. Debtors, outstanding and ledgers (summary)

Rules are in A1.5 and A3.5 (grouping by `CustNameid` / `SuplNameid`, sign rules, window). One extra rule from `frmDebtorsReport` (`:434-524`): it prints `Sum(Credit)` under the heading "City" and `Sum(Debit)` under "ContactNo" (column names reused for the print), then `Balance`. **Keep out of the Hub** (a naming accident).

### C11. Porting notes for reports

1. Port the **numbers**, not the Crystal layouts. Each report becomes a typed query with a CSV export and a print view built in the Hub's print layer.
2. Golden tests: R1 to R8, U1 to U3, F1 to F3, E1 to E3, T1 to T3, G1 to G3, H1 to H3, W1 to W4, plus the book tests in B (P1 to P9, M1 to M5, S1 to S7) and the customer tests in A1.5.
3. Where the old report has a quirk (stale opening in the stock movement; purchase grand total includes previous due; best sellers ignore returns), the Hub uses the corrected rule, with the old figure kept in the test as a "differs from old on purpose" note.
4. Cost for profit: store the cost on the document line at issue (Hub change), because the old program's profit depends on it.

**Hub now (9 October 2026, reports wave 3, `docs/OPEN-WORK.md` item 12q).** Built: R6 and R8 (bills with payment columns, cashier filter), F1 to F3 (profit by bill from the stock moves' values), profit by item, E1 to E3 (by quantity, returns taken off: E2 differs on purpose), U1 and U2 (purchase list), the product sales history and the out-of-stock list (T1). Not built: sale type and till filters, Net Sale, D-Sale, the summary 1 to 3 variants, printed layouts.

### C12. Not understood (reports)

- All `rpt*.rpt` layouts and what totals, groups and running balances they add.
- What `frmSalesReport` "D-Sale" (`InvoiceInfoD`) lists, and whether "Net Sale" subtracts sales returns.
- Which screen feeds `frmProductwiseProfit`, and which two columns it totals.
- The low stock report screen and the exact filters of the expiry report.
- The remaining three summary-report variants of `frmSalesReport` (which columns differ between "Summary Report-1, -2, -3").

## D. Not understood (all topics)

This is the consolidated list. The topic sections hold the detail.

**Customers (A1.12):** statement opening line and running balance (Crystal); which of two functions fills `TextBox18` before the limit check; whether credit-term days age bills; the fifth outstanding filter; whether coupon or gift discount is capped at the bill total; column types of `LPoint`, `Lpointstatus`, `Coupondb`, `GiftInfo`, `Promotion`; the receipt-number suffix text.

**Products (A2.12):** the second combo save path; whether deleting a product removes its stock and image rows; what the other product screens (`frmProductSmart`, `frmProductPlus`, `frmProductNew`, `frmProductEntry`) do differently; expiry-first picking at sale; whether a category rename updates its sub-categories; where the second-language name is saved.

**Suppliers (A3.8):** which list the supplier part of the debtors report shows under which heading; cipher code details; `Stock.PreviousDue` on edit; supplier delete checks.

**Books (B10):** the Crystal layouts; which bank balance function runs last in `BalanceSheetForm`; the last boxes of `frmBalancesheet` and the "difference" box; default account heads and the income voucher's head list; other `Invcode` columns; salesman and broker ledgers.

**Reports (C12):** layouts and totals; "D-Sale" and "Net Sale"; the feeder of the product-wise profit screen; low stock and expiry screens; the three summary variants.

**Not looked at at all in this study (the list asked for them but the time went to the rules above):** coupon and gift SMS or WhatsApp sending; customer contact list, bulk update and Excel import or export screens for customers, suppliers and products (`frmCustomerBulkUpdate`, `frmSupplierBulkUpdate`, `frmExportImportExcel_*`); `frmCustomerMobileRpt`; product image maker; `frmProductListWeigh` (weighing scale list); `frmKeyBordProduct`; the GST return forms. Each is a small screen over the tables in this file; read it when its port starts.

**Found while building the data reader (7 October 2026; the reader and its maps are in `docs/old-programs/DATABASE.md`).** Each was handled the safe way and is listed in the match report as "please look":
- Whether customer number 1 is always the walk-in customer: A1.11 note 5 says "the two codes 'Cash' and rows with ID = 1". The reader trusts only the **name** "Cash".
- Whether the typed `Opbal`/`Optype` can differ from the ledger's "Opening Balance" row in a real database. The reader moves the ledger's total (the typed opening balance is already inside it, A1.1 rule 7) and notes a person whose typed balance is not in the ledger.
- Which of a product's prices is right when `Temp_Stock.SPrice`/`WPrice` differ from `Product.SellingPrice`/`ReorderPoint`. The reader uses the stock row's (the till reads `Temp_Stock`, A2.0 item 4) and counts the items where they differ.
- The column types of `CustomerLedgerBook` and `SupplierLedgerBook` (`PartyID`, `Debit`, `Credit`, `Label`): not in `PosSchemaData.cs`; the reader accepts any number or text type.
- A product with several barcodes: the Hub keeps one barcode and no lots, so each barcode became its own item (an owner decision to confirm).
- "Not enforced" credit (A1.3): the Hub has no "no limit"; a very high limit and a note were used (an owner decision to confirm).

## E. Porting notes (all topics)

**Order of work, smallest safe step first (a proposal; the owner decides):**
1. Golden-test file for the Hub from the test vectors here (one test class per topic; inputs and outputs as written). Start with A1.3 (credit limit), A3.3 (supplier limit), A2.1 M1 to M15 (codes, GST split, margins), B6 M1 to M5 and P1 to P9 (profit), C2 R6 to R7 (payments by mode).
2. Put the cost on the document line (needed for profit), then profit by bill, by item and by day.
3. Customer account view and receipts with allocation; supplier account view and payments (A1.2, A1.4, A3.2, A3.4).
4. The discount resolver (A1.9) with the owner's choice on the quantity bands (A2.8).
5. Loyalty (one scheme), coupons, gift vouchers with the fixes (A1.6 to A1.8).
6. Product tools: units and conversion, bulk price and bulk tax-rate change with a log, barcode labels, quick groups (combos), serials (A2.3 to A2.9).
7. The accounts module on a double-entry journal (B2 posting table, B3 vouchers, B4 cash and bank, B5 trial balance that balances, B7 balance sheet).
8. Reports from C that the Hub lacks: purchase register, stock movement with running balance, multi-payment per bill, salesman commission (with the staff module).

**Data import (the old SQL Server database, read-only, decision 17):**
- Parties: `Customer` and `Supplier` rows, then the balance per party from the ledger tables (sum Credit - sum Debit by `PartyID`); report any difference to the typed opening balance plus movements.
- Products: map `Product` + `Temp_Stock` per barcode; `ReorderPoint` is the wholesale price; `MinStock` is the reorder level; ignore `Product.Barcode` "0"; GST = `CGST + SGST`.
- Money books: import opening balances and the cash and bank balances, not every old ledger row; keep the old rows as read-only history if the owner wants them.
- Loyalty: points balance per customer from `CustomerLedgerBook_Loyality` (scheme 2) or `LPoint` (scheme 1); unused coupons and gift vouchers with dates.
- Check list after import: customer balances, supplier balances, stock quantities per barcode, bank balances per account, cash in hand, all against the old screens.

**Rules for anyone using this file:** do not re-read the old code to find these rules; if something here is wrong, fix it here with the line that proves it. Add what you learn at the end of the topic. Do not call any part of this file verified by a run: it was read, not run.
