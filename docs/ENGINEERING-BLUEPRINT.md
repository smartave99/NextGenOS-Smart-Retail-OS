# The engineering blueprint: what it says, what the repository already has, and the order of work

The owner gave the team a 15-page plan on 8 October 2026: **`NextGenOS_Developer_Engineering_Blueprint.pdf`** (this folder; the owner's file, kept as received). The owner's words were: "read and save the attach file and execute it as and when best" (`docs/OWNER-REQUESTS.md`). This page is the working copy of it: it says in plain words what each part asks for, what the repository already does (checked in the code on the day), what is new, and in which order it is being done. When this page and the PDF differ, this page is the one that is kept true (`CLAUDE.md` section 13).

**The plan itself says** that it is a proposal and that the repository's decisions win where they differ (`docs/PLATFORM-DECISIONS.md`, `CLAUDE.md`). Its own rule: *operational correctness beats AI novelty*: sales, stock and money first; intelligence reads authorised records and proposes typed, audited actions; a model never writes to the database directly.

## 1. Where the plan and the repository's decisions differ (the repository wins)

| The plan says | The repository says | What is done |
|---|---|---|
| One list of seven data classes (`PUBLIC_BRAND`, `SHOP_OPERATIONS`, `CUSTOMER_PERSONAL`, `EMPLOYEE_PERSONAL`, `PAYMENT_SENSITIVE`, `SECRETS`, `BIOMETRIC`) | `CLAUDE.md` section 15 and `Ai/Vocabulary.cs` already have one list of nine (`PUBLIC`, `INTERNAL`, `CONFIDENTIAL`, `PERSONAL`, `FINANCIAL`, `VIDEO`, `AUDIO`, `BIOMETRIC`, `PAYMENT_SENSITIVE`), enforced by the routing | **The nine stay; no second list is made.** The plan's words map onto them: public brand = `PUBLIC`; shop operations = `INTERNAL` (anonymous totals) or `CONFIDENTIAL` (sales detail) or `FINANCIAL` (money records); customer and employee personal = `PERSONAL`; payment = `PAYMENT_SENSITIVE`; biometric = `BIOMETRIC`. "Secrets" is not a data class: a secret is never given to any AI task at all (the secret store keeps it; the field allow-list of item AI-014 must refuse it) |
| "Do not delete history or source during parity work" | Same (decision 28): the clean four-folder repository is made **last**, from a new private repository, only on the owner's "go" | Nothing deleted. Consistent |
| The first counter may be "only a browser client or also a packaged desktop counter shell" (decision needed) | The Hub is a web program; counters connect to the main PC (decision 4) | Proposal for the owner: **a browser (or the Hub's own app window) first**, no second shell. Asked when the store network is built |
| Payment-provider capture is out of scope | Decision 13, same | Consistent |
| Studio design AI sends public branding only | Decisions 5, 6 and 10, same | Consistent |
| "Inventory valuation: weighted average or first-in-first-out" | Not decided. The Hub today values stock at the **last purchase price** and keeps no cost on a bill line, so there is no cost of goods sold | **One question to the owner** (asked when the cost work starts; a recommendation goes with it) |

## 2. The twenty tickets: what exists, what is new, what happens

Status words: **built** (code and tests in the repository), **part** (some of it), **not built**, **owner** (needs the owner's accounts, machines or word). "Built" never means "verified on a real PC": `docs/OPEN-WORK.md`, "What cannot be verified from a cloud session".

| Ticket | The plan asks for | What the repository has (8 October 2026) | Status and next step |
|---|---|---|---|
| **DB-001** P0 | An update of an existing shop must stop if its safe copy cannot be made or checked; a restore drill | Before this session: the copy was tried, a failure was only noted and the update went on. | **Built 8 October 2026.** `HubDb.Migrate` stops with a plain message and changes nothing; the copy is opened and checked (SQLite's integrity check, same version, same tables) and thrown away if it fails; all steps run in one transaction, so a step that fails leaves the shop as it was; the folder for copies is a setting (`Hub:BackupFolder`); `DatabaseCheck` also checks that the books balance, for the restore drill. Tests: `MigrationSafetyTests` (6), `UpdateSafetyWebTests` (1). **Not verified:** a really full disk, an unplugged drive, a real Windows PC |
| **OPS-002** P0 | Nightly backup to a second place, last-good status, a restore screen | `HubDb.BackupNow` and the copy before an update; the folder setting and the check from DB-001 | **Part.** Next: the nightly run inside the shop's own upkeep, keep the last N copies, a record of the last good copy and of failures (shown to the owner), a restore that checks the copy before it puts it back, tests with an unplugged destination |
| **FIN-003** P0 | Books and customer invoices agree; stock valuation and cost of goods sold | Double-entry books exist and are tested (`BooksTests`, 17); no cost of goods sold, no stock value in the books; cost = last purchase price | **Part; needs the owner's word on the valuation method.** Then: cost on each bill line, stock value and cost of goods sold in the books, the accounting vectors from the blueprint's five scenarios as tests |
| **SEC-004** P0 | Permission checks at the command boundary, not only in screens; no cross-store access | Roles are checked in the screens and the web layer; the services do not check (`OPEN-WORK.md` item 8 of the engineer list) | **Not built.** Next: an acting person (user, role, device, store) given to every service call that changes money, stock, people or settings, with negative tests that call the services directly |
| **SEC-005** P0 | Rotate leaked credentials, scan Git and artefacts | The gate scans every file and every commit (`scripts/scan-history.mjs`) | **Owner** for the rotation (`OPEN-WORK.md`, Needs the owner, item 4); the scan stays in the gate |
| **NET-006** P0 | Main PC and counter PCs with pairing and local TLS | Not built. The Hub listens on its own PC only. An unmerged draft of the Core part exists in a helper's work folder | **Not built.** Do after NET-007 and SEC-004 (pairing is worthless if the services do not check who is calling) |
| **NET-007** P0 | 25 concurrent sales; the same request twice makes one sale; two counters selling the last unit | The database waits up to 5 seconds when busy. Before 8 October 2026 there was no request key and no test of selling at the same moment | **Built (the main PC's side), 8 October 2026.** Database step 12 (`documents.request_key`, unique); `Checkout` and `Issue` take a `RequestKey` and give back the first bill on a repeat; the Sell screen sends one per sale; the write transaction waits its turn on purpose. Tests: `ConcurrencyAndRetryTests` (10): 25 at once, ten with one key at once, the last unit at two counters, bad keys, the way back. A deferred transaction was tried as a check and the tests failed with "database is locked", so they have teeth. **Not done:** the counters' side of retry and the "disconnected" screen (needs NET-006); restaurant, library and booking calls do not send a key yet |
| **MIG-008** P0 | Read-only import from the older POS's SQL Server with a dated reconciliation report | Built on a stand-in (`Import/`, report, one transaction, second run adds nothing); never connected to a real SQL Server | **Part.** The report is not yet "signed and dated by an authorised person" and cannot block go-live by itself; a real SQL Server is the owner's PC (`docs/old-programs/DATABASE.md` section 10) |
| **EVT-009** P1 | A durable outbox written in the same transaction as the sale; a dispatcher; replay | `Events/EventStore` (events, observations, evidence, retention, an idempotency key) exists; **nothing in the shop writes events yet** | **Part.** Next: an outbox table written inside the sale's transaction, a dispatcher in the shop's upkeep, one effective update per event even if delivered twice, a kill-and-restart test |
| **ONT-010** P1 | Stable typed identities and permissioned reads | `Ontology/` (kinds, links, shop records read in place) exists with stable ids | **Part.** The caller's role and the information class are not yet applied to what comes back |
| **INS-011** P1 | Low stock against supplier lead time, with evidence | Not built | **Not built** (needs EVT-009 for evidence and a lead time on suppliers) |
| **ACT-012** P1 | Typed action registry with approval, expiry, replay protection | Not built (the assistant only recommends: `CLAUDE.md` section 15) | **Not built** (needs SEC-004) |
| **ACT-013** P1 | A draft purchase order as the first approved action | Not built | **Not built** |
| **AI-014** P1 | Field-level control of what leaves the shop, consent log, injection tests | The AI foundation has the classes, routing, a use log with cost, budgets, a secret store and a masking step for e-mail and phone; names are not yet removed (`OPEN-WORK.md` item 7) | **Part.** Next: a field allow-list for each outgoing task, a log of what class and which fields left, tests that put names, addresses, free text and payment numbers in and capture what reaches a fake remote service |
| **LIC-015** P1 | Paid licence keeps working with a warning, trial stops; all three implementations | Decision 15 is written; the format change is not made | **Not built.** Spec first, then vectors, then all three implementations (`CLAUDE.md` section 4) |
| **REL-016** P1 | Signed updates offered on the main PC, approved, backed up first, reversible | Not built. The backup-first and the way back exist in the Hub's database steps (DB-001) | **Not built** (needs NET-006) |
| **KIT-017** P1 | One tested base kit per release; two customers from one release | The website part is built (`assembleWebsite`); Android and the encrypted kit are not | **Part** (`OPEN-WORK.md` item 1c) |
| **WEB-018** P2 | Opt-in product snapshots to the website with freshness | Not built; the website has its own catalogue | **Not built** |
| **QA-019** P0 | Real hardware and Windows certification matrix | The gate runs here on Linux; the Windows runner in the release workflow | **Owner** (real PCs, printers, scanners) |
| **GT-020** P1 | Privacy-safe pilot measures | Not built | **Owner** with a pilot shop |

## 3. The order of work ("as and when best")

The plan's own ten first tasks, matched to what can be done from here, in this order. Each step ends with its tests and the gate, is written into `docs/OPEN-WORK.md`, and is pushed before the next begins.

1. **Run the whole gate and say honestly what was not run** (plan task 1). Done at every milestone (`CLAUDE.md` section 2).
2. **DB-001** (plan task 2): built; see above.
3. **NET-007 first half: one sale per request key, and the concurrency tests** (plan task 7; it is the cheapest proof that the Hub can be put on a network at all).
4. **FIN-003 invariants as executable tests** (plan task 3): the books balance for every kind of sale, return and payment; stock on hand equals the moves; a trial balance after a restore. Then, after the owner's answer on valuation, cost of goods sold.
5. **SEC-004 command-boundary permissions** (plan task 4), then the owner's credential rotation (**SEC-005**).
6. **OPS-002 nightly backup and the restore screen** (plan task 5).
7. **NET-006 pairing and local TLS** with the two-counter acceptance tests (plan task 8).
8. **EVT-009 outbox**, then **ONT-010**, **INS-011** (low stock rule), **ACT-012/013** (typed actions and the draft order) (plan tasks 9 and 10).
9. **AI-014**, **LIC-015**, **REL-016**, **KIT-017** as their dependencies are met.

The merge of the older Windows POS into the Hub (`docs/MERGE-PLAN.md`; the plan calls it the "parity register") **continues alongside**: the plan's first wave (checkout, discount and tax modes, customer and supplier accounts, coupons and vouchers, stock adjustments, price and variant meaning, the tax reports of India after a local review) is what has been built so far; the second wave (purchase returns, barcode labels, stock transfers, day, cash and bank books, loyalty as a debt) is next in the merge plan. The plan asks for a **parity register** per old workflow (old screen, behaviour, hidden effects, where it went in the Hub, tests, the owner's choice, retirement). `docs/MERGE-PLAN.md` and the study files in `docs/old-programs/` are that register; they are kept in step as each screen is ported.

## 4. The plan's seven decisions "before deeper coding": who answers, and when

The plan asks that a technical lead propose each with a short note and that the owner decide where product behaviour is affected. They are put to the owner **one at a time, when the work that needs them starts**, each with a recommendation. Nothing here has been decided for the owner.

1. **Stock valuation, opening stock, closing a period** — needed for FIN-003. *Recommendation to put to the owner:* weighted average cost (one cost per item, updated on each purchase), opening stock entered as an opening entry; lot-by-lot cost only for items that are tracked by lot.
2. **First counter: a browser or a packaged counter app** — needed for NET-006. *Recommendation:* the browser, or the Hub's own window; no second program.
3. **Pairing, certificates and revoking a device** — NET-006. *Recommendation:* a one-time code shown on the main PC, the owner approves on the main PC, the main PC makes the key and the Studio never sees it.
4. **What the one-time price includes (support, updates), extra PCs and modules** — the owner's business decision (already listed in `docs/PLATFORM-DECISIONS.md`, "Still to ask").
5. **What may leave the shop for optional AI and for product publishing** — AI-014, WEB-018. *Recommendation:* the nine classes of section 1, with the owner's switch per feature and per class.
6. **Which old workflows make the minimum retail and wholesale launch** — the merge plan's first and second waves, to be confirmed.
7. **Country-by-country tax words in marketing and who reviews them** — the country packs carry a "reviewed" flag; no page says "tax compliant" until a local adviser has confirmed it.

## 5. The plan's definition of done, and how it fits the gate

The plan's definition of done (tests of money, stock, authorisation and licence including bad cases; core shop work works offline and under a main-PC failure; switches, privacy, consent, permissions and audit tested at the service boundary; customer documents and backup/restore instructions; the artefact passes the release gates on the supported systems) is what `node scripts/verify-all.mjs --full` plus the NOT VERIFIED list already stands for (`CLAUDE.md` section 2). Where the plan asks for something the gate does not check yet, the check is added with the work (for example, DB-001 added its tests to the Hub's domain tests, which the gate runs).

## 6. The plan's pilot measures

A real pilot shop should be able to: sell safely on the main PC and a counter PC, recover its records from the last backup, reconcile money and stock, and approve a draft order that is backed by evidence, with no hidden transfer to the cloud. The pilot scorecard (failed or duplicated transactions, end-of-day reconciliation, restore time and loss, counter speed, whether low-stock alerts can be recomputed by hand, setup effort, value felt) is for the owner and a pilot shop; nothing here can be measured from a cloud session.
