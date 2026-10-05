# Frontend UX reassessment — 1 October 2026

Historical assessment of the pre-workflow-rebuild candidate. The subsequent implementation and its verification are recorded in [Checkout workflow rebuild](FRONTEND_FLOW_REBUILD_2026-10-01.md). The score below is not a new score for that implementation.

The current frontend still falls short of a world-class retail experience. The previous seven repairs improved specific controls and layout failures. They did not establish a fast, understandable cashier workflow. The earlier 7.5/10 core visual rating gave too much weight to those repairs for the broader standard requested.

My revised overall design judgment is approximately **5.5/10** for the reviewed frontend. This is a subjective assessment of the rendered interface and its interaction structure, not a usability-study score. Live transaction UX remains untested.

This review applies apple-grade-ui and design-critique to the final Release checkout, All tools, home and sign-in captures, checked against RetailLayouts.vb and RetailAdvancedLayouts.vb. It does not overwrite the earlier audit, test results or candidate-build evidence. No product code was changed during this reassessment.

## The most consequential problems

| Finding | Observed evidence | Effect on the user | Redesign direction |
|---|---|---|---|
| Item entry does not dominate checkout | Customer, Phone and State precede Barcode and Product; Quantity, Unit and Price are separate fields followed by three commands | A cashier must interpret a general form before locating the repeated sale action | Make scanning/product search the strongest input. Keep required customer selection compact; show additional details contextually while retaining validation rules |
| The cart is given too little space | At the 1024×720 outer minimum, the 48px first row fits, but only one full item row is visible beneath the large entry stack | Reviewing a multi-item basket requires frequent scrolling and loses context | Give the cart most of the selling workspace. Compact item entry; move advanced item information into an explicit detail area |
| Payment has its own long form | The minimum-size capture shows Payment date partially below the visible payment area; bank/payment allocation controls are lower in a separately scrolling pane | The fixed Save action is visible while details needed to assess payment may require scrolling | Use a focused payment view with total, method, received amount and outstanding/change information visible together. Reveal account/date/allocation details when applicable |
| Advanced navigation is a command collection | All tools gives Copy quotation, SMS, reminders, scale, calculator and lock-screen commands similar weight; F8, DateTime and an icon-only WhatsApp command remain | Users must read and remember the collection rather than find a clearly named task | Group existing commands by Invoice, Customer, Item and Payment tasks. Put occasional utilities in a secondary menu with clear labels and preserve original permission checks |
| Sign-in exposes too much secondary work | Exit, Recover password, Change password, Manage stores, Open keyboard and Language surround the main sign-in form | Secondary choices add reading and Tab stops before a routine action | Keep authentication and recovery prominent. Place setup and administration in a clearly named secondary area; keep accessible keyboard support available |
| Home has two navigation systems competing for attention | Twelve top-level legacy menu groups remain above the Home/All tools tabs and six everyday cards | A new user must learn the original module taxonomy and the new task taxonomy | Establish a consistent application shell with everyday destinations and command search. Preserve access to original commands and role restrictions |
| The product has inconsistent depth | Five main forms have rebuilt layouts; 392 other main forms retain legacy layouts | A polished entry point can lead into screens with a different interaction model | Apply the same workflow and component patterns to the highest-frequency downstream screens in order, rather than claiming whole-product consistency |

These are observed presentation and navigation problems. The captures use guarded offline fixtures. Empty totals or placeholder account/status values in those fixtures are not evidence that live calculations or authentication fail.

## What should leave the primary workflow

- Repeated explanatory text that consumes cart space once the operator understands the screen.
- Permanently exposed customer, invoice and payment metadata that is not required for the current sale condition.
- Duplicate product-entry decisions that force a user to distinguish Barcode, Product and Browse before starting. A unified visual entry point can retain the existing underlying controls and routes.
- Equal-weight utility buttons and administrative actions beside everyday work.
- Unexplained F-key-only labels, DateTime placeholders and unclear bitmap-only actions.

Removing a control from the primary viewport must preserve its original function and make its location clear. Required tax/customer fields cannot be hidden past a validation boundary. A customer or payment default must come from existing store rules, not an invented frontend assumption.

## The workflow to design around

**Find or scan an item → review the cart → take payment → confirm the saved invoice and next action.**

The selling view should prioritize one scan/search area, a large legible cart, a compact customer context, and a stable total/next-step area. Quantity changes and item removal should be located with the selected item. Where direct grid editing is unsupported by the original business code, use the existing handlers in a clearly associated item editor.

Payment should be a deliberate step. Each method should expose the fields it needs; a cash sale should not visually resemble bank-account configuration. Preserve the original save/payment contracts. Do not label an action as completed payment or successful checkout until the real business outcome is confirmed.

The saved state should explain what happened and offer the actual supported next actions, such as printing, viewing the invoice or beginning another sale. Rejected saves, incomplete payments and provider timeouts need specific recovery paths. Their behavior must be verified on an isolated store/provider fixture.

## The next implementation order

1. **Redesign checkout at the real minimum window.** Prioritize scanning and the cart, reduce persistent metadata, and prevent independently scrolling entry/payment panes from hiding essential information. First review it with an empty cart, a multi-item cart and a long product name.
2. **Separate payment into a focused task.** Reuse existing controls and handlers, show method-specific fields, and verify that required data remains reachable. Review cash, bank and UPI states separately.
3. **Replace All tools with meaningful task groups.** Establish useful grouping, clear names and predictable return paths. Verify each relocated command against its existing handler and authorization state.
4. **Simplify the application shell and sign-in.** Use a consistent navigation vocabulary, keep routine work prominent and reduce setup/administrative choices in normal flows.
5. **Carry the patterns into common downstream screens.** Prioritize product lookup, customers, invoice history, returns and stock over rarely used administration. Their normal routes require an isolated seeded store.

AI artwork is useful for branding and empty states. Additional artwork will not resolve the observed workflow and navigation problems. Use it only where it clarifies the product or state.

## How to judge the next version

Keep the existing build, contrast, target-size and control-preservation checks. Add criteria that reflect the user's work:

- A new operator can identify the item-entry action and payment step without reading an explanation of the application.
- At the actual 1024×720 outer minimum, ordinary selling and payment expose their essential information without competing scroll areas. Aim to review at least four cart rows; measure this on the implemented design.
- Required customer/tax/payment data remains clearly reachable when applicable. Navigation must not bypass validators or permission checks.
- Real scanner and keyboard flows preserve predictable focus through adding, correcting, saving and starting the next sale.
- Each payment state explains its result and next action, including rejection, timeout and cancellation.
- A novice operator can find an invoice and correct a basket without opening a collection of unrelated utilities.
- Success is verified through actual saved data and provider outcomes on an isolated environment. Synthetic rendering does not establish these results.

Record task completion, wrong turns, recoveries and hesitation during a real operator walkthrough. Do not claim a world-class result from a screenshot rating or a count of passing geometry checks.

## Evidence

- [Minimum-window checkout](/D:/smartavenue/Smart-Retail-POS-by-NextGen-OS/scratch/frontend-recheck-20261001-a/final/release-repairs/sale-light-minimum-populated-native.png)
- [All tools](/D:/smartavenue/Smart-Retail-POS-by-NextGen-OS/scratch/frontend-recheck-20261001-a/final/release-repairs/sale-light-all-tools-matched-native.png)
- [Home](/D:/smartavenue/Smart-Retail-POS-by-NextGen-OS/scratch/frontend-recheck-20261001-a/final/release-light-baseline/frmMainMenu.png)
- [Sign-in](/D:/smartavenue/Smart-Retail-POS-by-NextGen-OS/scratch/frontend-recheck-20261001-a/final/release-light-baseline/frmLogin.png)
- [Core layout](</D:/smartavenue/Smart-Retail-POS-by-NextGen-OS/Source/SmartAvenue99_POS_VB/SmartAvenue99 POS/BillPoint/RetailLayouts.vb>)
- [Verified repair history](FRONTEND_REPAIRS_2026-10-01.md)
