# Smart Retail OS UI profile

Native VB.NET WinForms / .NET Framework 4.8, x86. The apple-grade-ui skill is the design standard; there are no approved mockups. This profile maps its concepts onto native controls rather than adding a web frontend.

- Token and component layer: `BillPoint/RetailUI.vb`. Core layouts: `BillPoint/RetailLayouts.vb`; advanced invoice tools and UPI layout: `BillPoint/RetailAdvancedLayouts.vb`. Existing `AppleUITheme` entry points delegate to them.
- Decorative asset layer: `BillPoint/RetailAssets.vb`; generated originals: `Assets/Retail/storefront-v1.png` and `empty-bag-v1.png`. Both are embedded resources, with no runtime network dependency. Prompts and provenance are in `AI_ASSETS.md`. Render proportionally; omit artwork in high contrast and from keyboard navigation.
- Eleven typography tokens map to the skill's 34/28/22/20/17/17/16/15/13/12/11 logical-pixel scale, converted to native font points. Segoe UI Variable Text falls back to Segoe UI. Fonts are cached.
- Light/dark semantic colors: canvas, surface, fill, hover, label, secondary, accent, accent-hover, accent-text, selection, control, separator, danger, warning, on-accent. Text and control boundaries are measured by `scripts/verify-ui.ps1` using the live native token values.
- Spacing: 8-pixel unit, 24-pixel inset. Hit areas: 44 minimum. Fields: 76; rows: 48. Button/field radius: 12; grouped surface radius: 20. Native panels and legacy geometry are documented platform exceptions to the CSS checker.
- Primary device: Windows desktop with keyboard, barcode scanner, mouse, or touch. Minimum window: 1024 × 720. Tested client size: 1024 × 720; desktop proofs also use the actual display work area. Mobile browsers are outside this product's current platform.
- Archetypes: grouped form (sign-in, store connection), split view (sale), grouped commands (home), startup status (splash).
- Appearance follows the Windows app theme at startup. Home provides an in-session light/dark toggle. Windows high contrast uses system colors. There are no new animations or translucent materials, so reduced-motion and reduced-transparency settings require no effects to disable.
- Rebuilt canvas containers register their semantic surface role. Appearance changes update the color without flattening the grouped layout. Task buttons retain their category description and two-level typography through theme changes.
- Navigation uses original menu commands and checks the availability/enabled state of every ancestor. Never duplicate a business command or widen role permissions for a new shortcut.
- Retail vocabulary: store, customer, product, barcode, cart, sale, invoice, payment, balance due, hold sale. “Save sale” accurately names the existing invoice-saving operation.
- Transactional number, date, currency, and tax parsing remain owned by the existing business code. The frontend does not rewrite them or introduce a new currency. INR/en-IN presentation is a future formatting audit, not a verified property of the existing code.

| Screen | Layout status |
|---|---|
| Startup | Rebuilt using actual startup status controls |
| Sign-in | Rebuilt; existing authentication and password visibility handlers retained |
| Store connection | Rebuilt; existing save/test/reset commands retained |
| Home | Rebuilt; illustrated welcome, six everyday tasks, category-aware search, original menus and role-aware commands |
| Sale | Rebuilt; illustrated empty cart, populated cart grid, payment summary, fixed Save footer, search/UPI overlays |
| Remaining screens | Shared appearance at runtime; legacy layouts remain |

Native verification: run `scripts/verify-ui.ps1` with **32-bit Windows PowerShell, STA**, from the repository root after a Debug build. The web-only skill checker cannot validate VB.NET. Full keyboard traversal, screen-reader output, high-DPI text scaling, real database errors, payment processing, and printer behavior still require end-to-end verification on a configured store.

The repair regression is `scripts/verify-frontend-repairs.ps1`. Give it a new `OutputDirectory`; existing evidence is preserved. `BuildDirectory` selects Debug or Release dependencies. It exercises both appearances, a 1024×720 client and the actual 1024×720 outer minimum, native popup composition, Show/Hide password Tab access, wrapped compound targets, and original control instances/visibility/enabled states. The cart normalizer removes retained row/column appearance overrides while retaining alignment and formats. Customer details still lock through the original populated-cart formatting handler.
