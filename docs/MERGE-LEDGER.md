# The merge ledger: what the older Windows POS did, and where each part stands in the Hub

Last updated: 9 October 2026.

This is the one page that answers "what happened to learning from the old program and adding it to the new one?" (decision 25, 26 and 29; `CLAUDE.md` sections 16 and 17). It is a list, not a promise: nothing here says a part is finished for a customer. The gate (`node scripts/verify-all.mjs --full`) and `docs/OPEN-WORK.md` say what was and was not verified.

**How it was done, every time:** (1) the older program's code was studied once and written into a knowledge file in `docs/old-programs/` (rules, formulas with source lines, worked examples); (2) the Hub's code was read for the same topic; (3) the rule was built in the Hub (the host, decision 26) with the study's worked examples as the Hub's tests; (4) `docs/OPEN-WORK.md` and the Hub's `CHANGELOG.md` say what was reused and what is new. **Nothing of the older program has been deleted yet** (`docs/MERGE-PLAN.md`, "What is deleted, and when"): that waits for a real customer's database to be read and for the owner's word.

**Words used below.** *Done*: built in the Hub, tested with the study's examples, a browser test where there is a screen. *Partly*: some of it is built; the rest is named. *Open*: nothing built, and no decision against it. *Not built, decided*: a reason is written down and the owner can change it. *Dropped*: the Hub does it another way, or the old way is wrong. *Owner*: needs the owner's answer, account or a real machine (`docs/OPEN-WORK.md`, "Needs the owner").

"Study" means a file in `docs/old-programs/`: 01 selling, buying, stock; 02 masters, books, reports; 03 India tax and staff; 04 settings, messages, system; 05 AI add-on and dashboard; 06 the Hub's own map; `DATABASE.md` the old database.

## 1. Selling, buying and stock (study 01)

| Old POS topic | State in the Hub | Reused | New | Where |
|---|---|---|---|---|
| Till lines, tax, round-off | Done | The shared tax engine (kept as it was) | Half-up rounding rule pinned by tests | OPEN-WORK 11, 12f; study 01 section 7.1 |
| Line and bill discounts, cashier limit | Done (decision 33: spread over the items, tax on what is left) | `DocumentService` | `Perm.Discount`, limit setting, `DiscountTests` | OPEN-WORK 11 |
| Payments, split payment, hold, edit, delete, bill numbers | Done | The Hub's own sell flow | Credit-limit check on the books | study 01 section 7.2; OPEN-WORK 12a |
| Returns and refunds (cash back or credit, the cashier chooses) | Done (decision 34) | Credit notes | Credit on the customer's account, part-line returns | OPEN-WORK 12a, 12e |
| Estimates and quotations (shop sales), turn into a bill | Done (decision 35) | The quote document type | `SaveAsEstimate`, `BillFromEstimate` | OPEN-WORK 12d |
| Services and job billing | Done (the Hub already had services and appointments) | Hub | none | study 01 section 7.4 |
| Purchases, goods arrived, pay, purchase return ("debit note") | Done | Hub purchases | Purchase returns, purchase list report | OPEN-WORK 12q; study 01 section 7.5 |
| Supplier credit limit | Done (checked when goods arrive; SL1 to SL4 are the tests) | Books balances, the supplier on the People screen | `SupplierBalance` inside the receive, a field on the supplier | OPEN-WORK 12i; study 02 A3.3 |
| Inward notice, payment at receipt | Open | | | MERGE-PLAN group "Buying" |
| Stock entry, adjustment, damage, count | Done (valued stock moves with a reason) | `StockCost` (decision 36, average cost) | | OPEN-WORK 12y; study 01 section 7.6 |
| Stock movement report and stock card | Done | | `ReportService.StockMovement/StockCard` | OPEN-WORK 12y |
| Batch numbers and expiry dates | Done | `StockCost` | `StockBatches`, `BatchService`, step 24, the Batches page | OPEN-WORK 12r; study 01 section 6.2 and 6.8 |
| Serial numbers | **Not built, decided** (designed: table `item_serials`, a flag `track_serials`, count must equal quantity, scan the serial at the till, states in stock / sold / sent back) | | | below, "Decided but not built" |
| Variants (size, colour) | Open | | | study 02 A2.9 |
| Transfers between rooms or branches | **Dropped** (the old way used an online service) | | | study 01 section 6.5; OPEN-WORK 1d |
| Settlement | Dropped (the old way used the same online service) | | | MERGE-PLAN order, step 4 |

## 2. Customers, suppliers, products (study 02, A)

| Old POS topic | State in the Hub | Reused | New | Where |
|---|---|---|---|---|
| Customer and supplier accounts as a running balance | Done | | The books' accounts, statements, receive money, credit | OPEN-WORK 12, 12a |
| Credit limit | Done in the sale (`DocumentService`): a limit of 0 or none means no limit is enforced, a limit above 0 refuses a credit sale that would go over it. Not decided: whether a customer already over the limit may still buy for cash (the older program refused) | | | MERGE-PLAN "Not yet asked"; study 02 A1.3 |
| Loyalty points (per item, money value per point; decision 31) | Done | The item's loose facts | `LoyaltyService`, step 8 | OPEN-WORK 12b |
| Coupons, gift vouchers, offers, customer standing discount, buy X get Y | Done, with the old traps fixed (a cancelled bill no longer burns a voucher; expiry works) | The bill discount | `OffersService`, step 9 | OPEN-WORK 12e |
| Wallet | Dropped by the assistant, not asked: customer credit on account does the job; the owner can say otherwise | | | study 02 A1.10 |
| Customers and suppliers in a spreadsheet | Done | The CSV reader | `PartySheetService`, page, fingerprint, opening balance for new people | OPEN-WORK 12o |
| Products: bulk change with record and undo | Done | | `CatalogChangeService`, step 20 | OPEN-WORK 12x |
| Quantity discounts | Done | The bill-discount path | `OffersService.AddBand` and friends, step 21 | OPEN-WORK 12w |
| Labels for many items, and for a delivery | Done | The label printing in `libs/dotnet` | `LabelsFor`, `PrintLabelBatchAsync` | OPEN-WORK 12u |
| Items in and out as a spreadsheet, opening stock | Done | | `ItemSheetService` | OPEN-WORK 12v |
| Selling loose from a box (alternate unit) | Done, the Hub's way: two linked items, whole boxes opened without losing value | `StockCost` | `StockPacks`, step 25 | OPEN-WORK 12p |
| Combo packs | Done as quick groups (no bundle price) | | `GroupService`, step 26 | OPEN-WORK 12n |
| Product pictures | Done (kept in the shop's database, not on the web) | | `ImageService`, step 27 | OPEN-WORK 12l |
| Categories, sub-categories, units as masters | Open (the Hub keeps them as plain item facts) | | | study 02 A2.2, A2.3 |
| Second name for an item (local language) | Open | | | study 04 E.6 |
| Supplier master details and supplier code on labels (cipher price code) | Open | | | study 02 A3.6; study 04 D.5 |

## 3. The books and the reports (study 02, B and C)

| Old POS topic | State in the Hub | Reused | New | Where |
|---|---|---|---|---|
| Double-entry books, trial balance, profit and loss, position | Done (decision 32; the old books were not double entry) | | `BooksService`, step 7, the Books page | OPEN-WORK 12, 12c |
| Day book, cash book, bank book | Done | | `BooksService.DayBook/MoneyBook` | OPEN-WORK 12y |
| Old balances as opening entries | Done for customers and suppliers (new people from a spreadsheet, and the move from the older POS) | | `party_opening_balances`, `CatchUp` | OPEN-WORK 1f, 12o |
| Hand-typed vouchers, contra, fund transfer, bank accounts | Open | | | study 02 B3, B4 |
| Stock value and cost of goods sold in the profit figure | Open (profit is still cash-styled there; the Bills and Profit-by-item reports use the cost kept on each line) | | | OPEN-WORK 12c |
| Year close, balance sheet screens | Open | | | study 02 B7 |
| Sales report, purchase report, profit by bill and by item, most and least sold, out of stock, item history | Done (wave 3) | The report screen's pattern, the CSV export | `ReportService.Bills/ProfitByItem/PurchaseRegister/ProductHistory/OutOfStock/TopItems`, page *More reports* | OPEN-WORK 12q |
| Debtors and outstanding | Done (customer and supplier statements) | | | OPEN-WORK 12a |
| Salesman commission report | Done (the Staff summary) | | | OPEN-WORK 12t |
| The remaining old report screens | Open, one by one | | | study 02 C1, C12 |

## 4. India tax (study 03, A)

| Old POS topic | State in the Hub | Where |
|---|---|---|
| Tax calculation, cess, item code (HSN) | Done, in the country pack, not in program code | OPEN-WORK 12f |
| Registers (sales, purchases, returns), lists by the pack's rules | Done; **a local adviser must confirm the lists** | OPEN-WORK 12g |
| Summary of sales and purchases for the periodic return | Done as a summary; reverse charge on purchases **not built** | OPEN-WORK 12h |
| The portal file for the return, B2CS by state, item-wise registers, debit notes, document summary | Open | OPEN-WORK 12g |
| E-way bill | **Not built, decided** (below) | study 03 A5 |
| TCS | **Not built, decided** (below) | study 03 A6 |
| Tax categories, state master | Partly (the pack carries rates and regions) | study 03 A7 |
| GSTIN check digit | **Not built, decided** (below) | study 03 A7.3 |

## 5. Staff and salespeople (study 03, B)

| Old POS topic | State in the Hub | Where |
|---|---|---|
| Salesperson and broker, commission, what the shop owes, paying | Done (one method, on the value before tax; reversed in proportion on a return) | OPEN-WORK 12t |
| Employees, attendance, pay in advance, monthly pay, printable slip | Done (days of the month as the divisor by default; short time not deducted by default; slips cancelled, never deleted) | OPEN-WORK 12s |
| Transporter and route masters | Open (only needed with the e-way bill) | study 03 B2 |

## 6. Settings, printing, backup, language, messages (study 04)

| Old POS topic | State in the Hub | Where |
|---|---|---|
| Users, roles, permissions | Partly: five fixed roles and the discount right; whether roles become data the owner edits, and the other till rights, wait for the owner | study 04 A.11 |
| Till keys | Done (the shop chooses; the screen shows them) | OPEN-WORK 12m |
| Receipt, labels, kitchen ticket, drawer, auto-print | Done (the Hub already had them) | study 04 B.8 |
| A4 or A5 tax invoice with code and tax columns, tax by rate, amount in words, terms, signature | Done (one component beside the receipt; the money's words are in the pack) | OPEN-WORK 12j; study 04 B.8 gap 1 |
| A choice of bill styles, second-copy words (original, duplicate) | Open | study 04 B.8 gaps 2, 10 |
| Backup and restore | Done (the Backups page, the notice on Today); the online copy stays off until the owner turns it on | `Backups/` in the Hub; decision 11 |
| Language conversion and screen translation | Open (English first; translations come country by country, decision 21) | study 04 E.6 |
| Messages (WhatsApp, SMS, email, broadcast) | Not built: what leaves the shop needs the owner's permission, in plain words (decision 4, `CLAUDE.md` section 15) | study 04 F |
| Leads, follow-up, reminders | Open | study 04 G |
| Branches, companies | Not built (one database is one shop; head office is an opt-in summary of totals, decision 12) | MERGE-PLAN group "Branches" |

## 7. The AI add-on and the dashboard (study 05)

Reused and edited, not replaced: the add-on and the dashboard are the older code with the licence and the brand kit added; the Hub's AI foundation (Version 2, `CLAUDE.md` section 15) is the place their features plug in. What remains is in `docs/OPEN-WORK.md` items 6 and 7.

## Decided but not built (the owner can change any of these)

- **E-way bill.** It sends goods and party details out of the shop to a government portal, so it needs the owner's permission, credentials in the system's store, and a route choice: a paid third-party provider, or a file the person uploads to the portal. Both are bigger than the rest and neither can be tried here. *Asked of the owner in OPEN-WORK 10b.*
- **TCS.** The rule in the older program is dated and its legal status has been reported to have changed. If it is ever built it is dated data in the country pack and off until the owner turns it on. *A local adviser first.*
- **GSTIN check digit.** The check belongs in the country pack as data, with an adviser's confirmation; the Hub keeps the tax number as typed until then.
- **Serial numbers.** Designed as above; not built, because a mistake in the stock count (count must equal quantity) touches every sale. Build when a customer needs it.
- **Stock transfers between rooms.** The older program used an online service; dropped.

## What this page is not

It is not a statement that the merged program is finished or ready to sell. Open rows exist, every "Done" row was verified here only as far as the Hub's own tests and browser scenarios go, and the real Windows PC, a real printer and the real SQL Server reader are not verified (`docs/OPEN-WORK.md`, "What cannot be verified from a cloud session").
