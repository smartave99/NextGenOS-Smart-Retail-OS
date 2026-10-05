# Checkout workflow rebuild — 1 October 2026

The core selling interface now follows item entry → cart review → recorded payment → the original invoice Save action. This replaces the previous checkout's long, independently scrolling entry and payment panes. Sign-in and Home have also been simplified. This report describes the new candidate; earlier repair evidence and the 5.5/10 reassessment describe the preceding candidate.

## Implemented behavior

- Scan barcode and product search sit above the cart. Quantity, unit, price and Add item share a compact row. Four complete 48px item rows are visible at the actual 1024×720 outer window minimum, whose client area is 1008×681.
- Required customer name, phone and state stay in a shared side panel with the original totals. Phone and state each have a full-width field; long state names are readable. The original cart-driven customer locks remain intact.
- Review payment opens a dedicated step. Method, amount, date, bank account, recorded payments and the invoice action fit without an independently scrolling payment panel. Back retains the cart and totals.
- Save is presented after item and payment records exist. F2 opens payment from the cart, consumes the key when records are missing, and otherwise passes to the existing Save handler on payment. Original validation, calculation, SQL persistence and printing remain in the original handlers. The UI does not simulate success or a receipt.
- New sale remains visible in the cart header. A populated cart prompts before the original Reset handler can run; No is the default. The fixture proves that choosing No returns false and retains the cart, without invoking Reset or a database operation.
- Invoice tools are grouped into Invoice, Customer, Items, Charges, Utilities and More details. Invoice actions and salesperson selection are in Invoice. Existing function-key routes reveal the appropriate original action. Empty legacy wrappers are retained without occupying useful space.
- UPI requests open the original provider controls on payment. The overlay retains scrolling for provider details. Its controls and clipping were checked without creating or cancelling an actual provider transaction.
- Sign-in prioritises credentials, Sign in and recovery. Store management, password changes, language, keyboard and Exit are available under Store options. Show/Hide remains keyboard accessible.
- Home prioritises Start a sale, six everyday tasks and command search. Browse all commands exposes the original menu and its permission checks. Account status replaces the busy marketing footer on Home; the original status strip remains in Store tools.

Existing embedded AI storefront and empty-cart artwork remains available offline. No new image model output was needed for this workflow change.

## Architecture and preservation

RetailUI owns shared field, row, type, color and button components, including quiet actions whose role survives appearance changes. RetailLayouts builds the core entry screens. RetailCheckoutLayouts owns the sale's pages, customer context, payment guidance and navigation. RetailAdvancedLayouts adapts and groups existing advanced controls. RetailPageHost uses the native TabControl content rectangle while navigation is exposed through named buttons.

Every original named checkout Control instance, business enabled state and local visibility flag is retained, except the replaced captions and deliberately exercised overlays recorded by the existing proof. Wrappers control step visibility without rewriting the original Save permission flag. Business integration is limited to the early shortcut route and the New sale confirmation in frmPOS; calculation and persistence handlers were not replaced. Original line endings were retained.

## Verification

Both x86 Debug and Release full solution rebuilds completed successfully: 13 projects each. Existing warnings remain, including the missing .NET 4.8 targeting pack with GAC fallback, reference/architecture warnings and warnings in recovered business code.

| Final candidate check | Result |
|---|---:|
| Debug native matrix: light/dark, minimum/client windows, workflow and control-state checks | 504/504 passed |
| Release native matrix with the same coverage | 504/504 passed |
| Five-form light baseline, assets, appearance, contrast and menu permission checks | 56/56 passed |
| Five-form dark baseline | 56/56 passed |
| Total final assertion executions | **1,120 passed; 0 failed** |

The matrix includes actual native PrintWindow captures, four displayed cart rows, full payment-field visibility, back navigation, F2 readiness behavior, F1/F3–F8 routing, original-control retention, original permission/visibility retention, password keyboard access, options expansion, all six tools groups, UPI/history requests and the cancelled New sale dialog. Baseline snapshots use DrawToBitmap; native captures are the visual reference. Fixture records and summary values are synthetic and do not establish calculation correctness.

- Evidence root: `scratch/frontend-flow-redesign-20261001/`.
- Exact cases: `final-debug/cases.tsv` and `final-release/cases.tsv`.
- Build logs: `build-debug-final.log` and `build-release-final.log`.
- Binary/source hashes and final counts: `manifest.json`.
- Verified source and fixture copies: `verified-sources/`.
- Earlier failed/intermediate runs remain available as history; they are not substituted for the final checks.

Debug executable SHA256: `645CC58140F4A284C4DF52A97EE0BA6856CB92C6C99B374773DCCD0A2456197C`.

Release executable SHA256: `6FFD5318D5D28EB24D5EBBB2494C1CC89E649CB85460012C010090ECAAFA05E5`.

The generic craft checker does not support VB.NET. Its diagnostics for the two existing C# fixtures include long lines, fixture-lifetime functions, nesting and the five-field evidence writer; its result is not a clean structural-code gate. The native modules were reviewed for control ownership, one-way layout/component dependencies, event routing and scope of mutation. `git diff --check` passed. No unsupported checker pass is claimed.

## Figma handoff

[Editable workflow specification](https://www.figma.com/design/LRHAM9xfczdGmBjmxlMdDB?node-id=2-2).

The specification has eight component instances and 18 editable text layers within the review frame, no complete-UI raster, shared documentation styles and scoped token bindings. Its structure and composition were inspected. The Figma environment provides Inter but not the app's Segoe UI fonts. It is therefore a workflow document; pixel-faithful native UI reproduction in Figma is not verified. The native screenshots establish the implemented appearance. Construction code and the file/node ledger are saved alongside the evidence.

## Practical limit

This is a verified core UI candidate, not a production certification or a whole-product redesign. The 392 other main forms still have legacy layouts. Guarded offline fixtures do not establish normal authenticated startup, saved-invoice persistence, real permissions from a database, payment-provider behavior, printers or real customer usability. Those require an isolated seeded integration environment and real-user testing. No current installer was published or deployed, and no live transaction, message or print operation was performed.
