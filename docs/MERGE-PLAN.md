# Merge plan: one shop program, the best of the older Windows POS and the Business Hub

Written on 7 October 2026. This page is a **plan and a list of facts, not finished work**. Nothing has been ported, built or deleted yet. The owner's decision is in `docs/PLATFORM-DECISIONS.md` (decisions 25 and 26) and the owner's own words are in `docs/OWNER-REQUESTS.md`.

## What the owner said

> merge it fool make the best out of it and delete rest instead of wasting the token

(7 October 2026, in answer to: which program should be the shop program that customers get?)

## How this plan reads it (if the reading is wrong, the owner says so and this page is changed)

- **One shop program, not two.** Customers get one program.
- **The Business Hub is the host.** The older Windows POS's features and business rules are **brought into it, screen by screen, from the recovered source**: not rewritten from nothing, and not guessed. Where the old POS does something better, its way is kept.
- **"Delete the rest" is done carefully:** a piece of the old POS is removed from the repository only **after** the Hub does the same job and a test shows it. Git history keeps everything that is deleted, and a deletion is one commit that can be undone. Nothing is deleted before then.

## Why the Hub is the host (facts, checked on 7 October 2026)

| | Older Windows POS (`apps/pos-desktop`) | Business Hub (`apps/business-hub`) |
|---|---|---|
| Builds by itself | **No.** Only on a Windows PC with MSBuild; no workflow builds it | Yes (the release workflow; 38 gate checks) |
| Can make a new customer's database | **No.** `DBscript.sql` and `CompanyMasterDBScript.sql` are named in its guide but are **not in the repository** | Yes (migrations; sample company) |
| Runs on | Windows only, 32-bit, needs SQL Server | Windows and Linux, own database file |
| Trades and countries | Retail, Indian GST (rupees, GST words, WhatsApp flows in thousands of places) | Retail, restaurant, library, construction, services, wholesale; country packs |
| White-label, licence | Licence enforced and brand from the licence (edited already) | Built in |
| Source | Recovered from compiled files; **the owner states it is theirs** (decision 27) | Written new, owned |

The old POS has what the Hub does not yet have: **397 screens** of Indian retail and accounting features. That is what is worth bringing across.

## What the older POS has, and what the Hub has today

The old POS's screens (`apps/pos-desktop/Documentation/UI_SCREEN_INVENTORY.csv`) grouped by what they do. The counts come from the screens' names (a screen can be counted in one group only, so they are approximate). The "Hub today" column comes from the Hub's screens and a search of its code. **Each row is checked line by line when its turn comes; until then it is a first reading.**

| Group (old POS screens) | Hub today | To bring across |
|---|---|---|
| Selling at the till: bills, touch till, hold, returns, refunds, multi-payment (27) | Have: sell, bill, hold, split payments, credit notes, void. **Missing (found by reading the Hub's code, `docs/old-programs/06-hub-map.md`):** no screen offers even a line discount; no bill-level discount; no fixed-amount discount; cess and HSN are never passed to the tax engine; a credit note does not reduce what a customer owes | Line and bill discounts, cess and HSN, India touch-till variants, cash refund details, customer ledger effects of returns |
| Estimates and quotations (6) | **Partly:** quotes exist only for construction projects (`ProjectService.CreateQuote`), not for shop sales | Estimates and quotations for shop sales, retrieve and convert to an invoice |
| Buying: purchase entry, orders, returns, stock inward (23) | Partly: purchases, receive, pay | Purchase returns, GST purchase registers, inward notices |
| Stock: entry, adjust, transfer, godown, damage, settlement, movement (20) | Partly: items and stock adjustment | Transfers between godowns and branches, damage, settlement, movement report |
| Products: categories, units, bulk change, variants, serial numbers, combo packs, labels, import and export (61) | Partly: items and barcodes. **Corrected after reading the code (study 02): the Hub has no variant, batch or serial-number tables** | Variants, batches and serial numbers, bulk price and product change, combo packs, barcode label printing, Excel import and export, product images |
| Customers: ledger, outstanding, receipts, loyalty, coupons, offers, gifts (39) | Partly: customers, credit and terms, balances | **Loyalty, coupons, gifts, offers, customer receipts and statements** |
| Suppliers (8) | Partly | Supplier ledger and outstanding |
| Accounting books: general ledger, day book, vouchers, bank, contra, income and expense, balance sheet, trial balance, profit and loss (41) | **Not found** | The accounting books, as a module |
| India tax and compliance: GSTR-1, GSTR-3B, HSN, e-way bill, TCS, GST registers (21) | Partly: tax rates through the country pack | **GST returns and registers, e-way bill, TCS**, as the India country module |
| Staff and salespeople: employees, attendance, salary, commission (13) | **Not found** | A staff and salesperson module |
| Restaurant and kitchen: tables, kitchen section, orders, tokens (3) | Have | Token flows, if different |
| Services and job billing (7) | Have: services, appointments | Service-done reports |
| Branches, companies, year change (9) | Not built (one database is one shop; head-office view is decision 12) | Branch master and branch reports; financial-year change |
| Messages: WhatsApp, SMS, email, chat, broadcast (21) | **Not found** as shop features | Only with the owner's permission for what leaves the shop (decision 4 and `CLAUDE.md` section 15) |
| Leads, follow-up, support, reminders (10) | **Not found** | A small CRM module |
| Reports (8) | Partly: reports page | The old POS's report set, one by one |
| Settings, users, printing, backup, language, system (34) | Partly: users and roles, printing, theme | Backup (decision 11), shortcut keys, language conversion |
| Extras: online shop link, gallery, camera, image reader, calculator, UPI QR (15) | The website and the dashboard are separate programs that already exist | UPI QR only as a payment provider later (decision 13); the rest as asked |
| Left over, not grouped (31) | n/a | Look one by one (many are tests and dialogs) |

## What reading the Hub's code added (7 October 2026)

- **There is no customer ledger, no customer receipt and no loyalty in the Hub**, and a credit note does not reduce what a customer owes. These are the first things to build for an Indian retail shop.
- **Money lives in one class (`DocumentService`) with no hook in it.** Anything that must happen together with a sale (loyalty points, a ledger line) needs a callback inside the sale's single database transaction (suggested name `OnIssued`).
- **With several counters on one main PC, a sale could fail with a database "busy" error** (`HubDb.InTransaction` starts a read-then-write transaction). Two simultaneous checkouts must be tested before the store network is built.
- **Every India word in program code fails the white-label check** (the Hub's baseline is zero), so the India module's words and rules live in data (packs, profile) or on a line marked as allowed with a reason.
- **The two looks (decision 30):** density, menu place, bill place and font size already exist as settings on the page and are styled by `hub.css`; a touch-counter combination is already tested. The look is stored once per shop, not per screen, and the sell screen shows tiles only, with no list view. Three ways in: (A) named presets made of the existing settings, no licence-format change; (B) a per-browser choice; (C) a new token, which needs the licence-format change. A is the smallest and is the one to build first.

## What reading the older POS's masters, books and reports added (study 02, 7 October 2026)

1. **A customer's or supplier's money is a running account, not a list of unpaid bills:** balance = sum of credits minus sum of debits (`CustomerLedgerBook`, `SupplierLedgerBook`). The credit limit has an on/off flag: with "No" the customer has unlimited credit. **The Hub treats a limit of 0 as no credit at all, the opposite meaning.** The old check can also refuse a customer who is already over the limit on a full cash sale (test vectors L1 to L10 in the study).
2. **The old books are not double entry:** one row (or a pair) per event, a credit sale writes only the customer's row, the trial balance does not balance (worked example out by 4,900), and edits rewrite rows in place. The Hub has no accounting module at all. **Decision for the owner (to ask): copy the old books as they are, or build proper double-entry books?**
3. **Profit and loss in the old POS is cash-style** (no closing stock), and a per-line cost profit uses the last purchase price saved on the sale line. The Hub does not save a cost on the document line, so it can produce neither figure yet.
4. **Column names mislead:** `Product.ReorderPoint` holds the wholesale price (the reorder level is `MinStock`); `Gift.DiscPerc` and `CustomerOffer.DiscPerc` hold money amounts; `Product.Barcode` is always "0" (the real barcodes are rows in `Temp_Stock` and `Product_OpeningStock`); GST is stored as two half rates. The data reader must use the study's maps, not the column names.
5. **Loyalty, coupons and gifts have traps the Hub must not copy:** two loyalty schemes exist (percent of the bill in the older till, per-line points with a money value per point in the touch tills; **the owner picks one**); coupons and gifts are marked used when the cashier confirms, before the bill is saved, so a cancelled bill burns the voucher; gift expiry never expires; a coupon's start date is never checked; a quantity outside every discount band gets the largest band's discount; purchase totals include the supplier's previous due; a supplier who owes the shop can be "paid". Each has test vectors and a "keep or fix?" note in the study.

## Order of work (a proposal; the owner can change it)

1. **Move the data first.** A reader for the old POS's SQL Server database, so a customer who has the old POS can move to the merged program with their items, customers, balances and history (decision 17). The old POS's table layout survives in `apps/pos-ai-companion` (`Data/PosSchemaData.cs`); the owner can also give the database scripts or a backup, which would make it exact.
2. **Customers: loyalty, coupons, gifts, offers, receipts, statements.**
3. **India module: GST returns, registers, e-way bill, TCS.**
4. **Products and stock tools:** bulk change, combo packs, labels, import and export, transfers, damage, settlement.
5. **Accounting books.**
6. **Staff and salespeople.**
7. **Branches and the head-office view; messages (with permission); leads and reminders; the rest.**

Each step: look at the old screen and its recovered code, port the rule with the old POS's numbers, write a test that pins the money, run the gate, then remove that part of the old POS in its own commit.

## What is deleted, and when (nothing is deleted yet)

| What | When |
|---|---|
| The helper agents' working folders (not product code) | **Done on 7 October 2026.** Their unfinished work is saved as commits on branches `worktree-agent-*` and nothing is lost. |
| The old POS's screens and code, group by group | After the Hub does the same job and a test shows it (one commit per group, so each can be undone). |
| The old POS's companion libraries (Firebase licence manager, ChromeDriver, WhatsApp automation, PhonePe, speech, transliteration...) | With the part of the old POS that uses them. The Firebase licence manager goes first: the signed licence replaces it. |
| The whole of `apps/pos-desktop` | Last, once the data reader works on a real customer's database and every group is ported or dropped by the owner. |
| The old trial releases `v1.0.0-trial7` and `v1.0.0-trial8` on GitHub (replaced by trial 9) | **Only when the owner says so**: deleting a release needs the owner's word for that action (`CLAUDE.md`, section 12). |
| Git history | **Never.** One exception only, with the owner's word: removing old secrets from history (`docs/OPEN-WORK.md`, item 4). |

**Keep outside the repository:** the owner's own copy of the old POS installers and a backup of a working database (the repository does not have them). Deleting code from the repository does not touch a customer's installed old POS.

## What is needed from the owner

- The two database scripts, or a backup of a working database of the old POS (a copy with no real customer data is fine).
- The order in step "Order of work", if it is not right.
- A list of the three or four screens of the old POS that customers use every day, so that those come first and are checked against how people really work.
