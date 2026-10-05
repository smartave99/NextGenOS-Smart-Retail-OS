# Fresh frontend review and rebuild — updated 1 October 2026

The later [whole-app recheck](FRONTEND_RECHECK_2026-10-01.md) and [verified repair report](FRONTEND_REPAIRS_2026-10-01.md) supersede this initial rebuild's verification status. Seven confirmed UI defects were repaired; production workflows remain blocked pending an isolated store environment.

**Baseline judgment against apple-grade-ui: UI 4/10; UX 5/10.** These are design judgments based on rendered startup, sign-in, main navigation, checkout, and database setup, plus a static inventory of the other designers. They are not usability-study results. The earlier 8.9/10 claim is superseded.

The existing theme changed some colors and buttons while retaining crowded absolute positioning, mixed fonts, tiny targets, image-dependent commands, clipped table headings, and competing action treatments. Increasing the total's font without rebuilding its container introduced clipping. Rendering the earlier theme confirmed these problems.

The initial preview path also depended on database configuration during construction, and its sample cart values used incorrect column indexes and inconsistent totals. Offline capture now suppresses field-triggered business operations and avoids service initialization in the main-menu preview constructor. Production behavior uses the existing handlers when capture is off. Capture succeeds only after every requested screen renders.

## What has been rebuilt

- A native semantic token and component layer, with eleven type styles, measured text/control contrast, rounded fields/buttons, focus/pressed/disabled states, system high-contrast colors, and light/dark appearances.
- Startup, sign-in, store connection, home, and sale layouts. Authentication, invoice saving, payments, tax calculations, database operations, shortcuts, and printers keep their existing commands.
- Sign-in has visible field labels, meaningful actions, accessible names, Enter-to-sign-in, and working show/hide password controls. The old placeholder-as-value behavior is removed.
- Home searches existing commands. Shortcuts observe both the command and its ancestors' enabled/available states. Disabled or hidden ancestors cannot be invoked through the new UI. Old subscriptions are removed when search buttons are disposed.
- Checkout exposes the actual product-search textbox and the customer fields required by the existing validator. The cart's compact view keeps product, quantity, price, and total visible; item details restores additional columns. Payment method, amount, date, and bank account reuse the original fields. Save stays in a fixed footer.
- Remaining business controls are reachable through All tools. Product suggestions and UPI retain their original controls and are placed over the new sale workspace when shown.
- Other open BillPoint forms inherit shared colors, menu styling, and table treatment. Legacy bitmap icons, geometry, and text sizes are retained where an explicit screen rebuild has not happened.
- Two ChatGPT-generated transparent illustrations are embedded in the executable for offline use. Welcome screens share the storefront; checkout shows an empty shopping bag with guidance until items exist. Native drawing preserves their proportions. The artwork has no keyboard focus and is omitted in high contrast. The exact prompts, files, and tool limitations are recorded in [AI_ASSETS.md](AI_ASSETS.md).
- Home now starts with six everyday tasks: manage products, manage customers, find invoices, review stock, record a purchase, and view the sales dashboard. Each uses an existing command and shows its original menu path. Search includes task captions and categories. All six cards fit at a 1024 × 720 client size. Appearance changes preserve the grouped canvas and task context.
- Startup hides the retired picture and labels that covered the new header, while retaining the actual progress and status controls. Checkout swaps its empty state and populated grid so the grid cannot paint over the guidance.

## Scope and remaining work

There are 399 designer files across the main project, including **397 directly under BillPoint**. Five main layouts are rebuilt. The remaining **392 BillPoint layouts** are inventoried in `UI_SCREEN_INVENTORY.csv`; they have not received individual layout rebuilds or runtime workflow walkthroughs.

The static inventory finds **6,136 legacy designer targets smaller than 44 pixels**, **3,796 font definitions below 8 points**, and **4,348 direct color definitions** in those 397 designer files. These are source-definition counts, not unique visible controls or a runtime accessibility result. Rebuilt screens override relevant designer geometry at runtime; the inventory deliberately records the retained designer source.

**Current assessment: the rebuilt main screens are approximately 7.5/10 visually. Whole-product UX remains provisional.** Shared appearance alone does not make hundreds of retained layouts Apple-grade. There is no claim that the complete frontend now meets every skill law.

The remaining work is individual layout and copy review of product/customer entry, stock management, purchase and return flows, reporting, configuration, and the other dialogs. Live database failure states, bank/payment integrations, tax/tender correctness, receipt printing, long product names and amounts, dense carts, role-specific workflows, high DPI, full keyboard traversal, and screen-reader operation must also be verified.

## Verification

Native proofs and checks are in `UI_Proofs/light` and `UI_Proofs/dark`. The verification harness runs in x86 Windows PowerShell and uses the actual compiled WinForms controls; it does not connect to store databases or execute retail transactions.

There are 56 checks per verification run. They cover password visibility, Enter binding, no-result search, visible Save at a 1024 × 720 client size, 44-pixel Save target, cart visibility, expanded/compact columns, a 500-row cart, long total fitting, UPI overlay placement, All tools navigation, and proxies respecting disabled/hidden ancestors. The additional asset pass checks embedded PNGs and transparent corners, decorative artwork's keyboard behavior, six everyday tasks fitting every ancestor's viewport, search across categories, category descriptions, appearance changes, and the empty/populated cart transitions. Pixel checks on the actual rendered form confirm that the startup and cart illustrations appear; bounds-only checks had missed legacy controls painting over them. Contrast is computed from the native palette in both appearances for labels, secondary text, primary normal/hover states, links, boundaries, danger, and warning text. The long-total check found and fixed a font/resize feedback loop.

The dark proofs show the remaining platform limitation: Windows-drawn tab headers, dropdown arrows, date pickers, and the title bar retain native OS chrome. Palette contrast passing does not certify a completely custom dark appearance. The screenshot fixture uses empty store data and restores customer controls after exercising the UPI overlay; it does not represent a signed-in store session.

Build output includes pre-existing framework-targeting, assembly-conflict, and decompiled-code warnings. A successful build is not a clean bill of health for those dependencies. The code-craft checker reports VB.NET as unsupported; no automated craft or CSS-checker pass is claimed.

Final local result: Debug and Release builds both exit successfully with no errors. Both light and dark runs pass all 56 checks and render all five screens. Verification output is saved alongside the screenshots as `verification.log`; existing build warnings remain.

To reproduce from the repository root:

```powershell
& 'C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe' 'Source\SmartAvenue99_POS_VB\SmartAvenue99 POS\SmartAvenue99 POS.vbproj' /p:Configuration=Debug /p:Platform=x86 /verbosity:minimal
& 'C:\Windows\SysWOW64\WindowsPowerShell\v1.0\powershell.exe' -NoProfile -STA -File scripts\verify-ui.ps1 -OutputDirectory Documentation\UI_Proofs\light -Mode rebuild-small
& 'C:\Windows\SysWOW64\WindowsPowerShell\v1.0\powershell.exe' -NoProfile -STA -File scripts\verify-ui.ps1 -OutputDirectory Documentation\UI_Proofs\dark -Mode rebuild-dark-small
```

This change is local. It has not been published, installed, or released.
