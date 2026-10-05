# SmartAvenue UI review gate and 100-point rubric

## Contents

1. Visual foundations
2. Responsive consistency
3. Retail discovery
4. Interaction and states
5. Accessibility
6. Motion and performance
7. Content, trust, and Genie
8. Admin and maintainability
9. Scoring interpretation and reporting gate

Use this before reporting UI work complete or assigning a score. Separate:

- **Code evidence:** what the repository proves.
- **Rendered evidence:** what was actually viewed and tested.
- **Unknown:** anything that cannot be validated in the current environment.

Do not award full credit for an untested claim. Do not treat feature count as design quality.

## 1. Visual foundations — 15 points

- [ ] Colors have understandable semantic roles and do not conflict with token names.
- [ ] Typography has a limited, consistent scale with readable line height and hierarchy.
- [ ] Spacing follows a stable 4/8px rhythm.
- [ ] Radius, border, and elevation choices express hierarchy instead of decoration.
- [ ] Raw colors/arbitrary values are rare, justified, and centralized when reusable.
- [ ] Icons come from one family and align optically with adjacent text.
- [ ] Dark heroes/footer and light content surfaces feel like one product.

## 2. Consistency and responsive layout — 15 points

- [ ] Storefront header, mobile drawer, page heroes, catalogue cards, and footer share one system.
- [ ] The same information architecture survives phone, tablet, and desktop.
- [ ] Tested at 320, 375, 768, 1024, and 1440px.
- [ ] Product grids, filters, forms, admin tables, and dialogs adapt without clipping.
- [ ] Body copy stays within a readable measure.
- [ ] Long product names, barcodes, prices, and translated labels remain usable.
- [ ] No debug/test route is used as a public design precedent.

## 3. Retail and product-discovery clarity — 15 points

- [ ] Search, barcode search, departments, offers, filters, and clear-filter actions are findable.
- [ ] Product cards make image, name, price, availability, and next step scannable.
- [ ] Product details provide enough trustworthy evidence for an in-store decision.
- [ ] Selected filters are visible and removable; no-result behavior explains recovery.
- [ ] Offers show validity and conditions and do not manufacture urgency.
- [ ] The site consistently says browse online and purchase in store.
- [ ] Request/WhatsApp/contact actions never masquerade as checkout, reservation, or delivery.

## 4. Interaction and states — 15 points

- [ ] Every target is at least 44×44px with adequate separation.
- [ ] Hover is pointer-only; press feedback appears within 100ms.
- [ ] Focus-visible is obvious and focus order follows visual order.
- [ ] Loading, empty, error, unavailable, stale, and overflow states exist.
- [ ] Forms preserve input, announce validation, and explain what happens next.
- [ ] Dialogs/drawers close with Escape, trap focus where required, and restore focus.
- [ ] Carousels expose manual controls and do not force motion.
- [ ] Back navigation restores meaningful search/filter/scroll state.

## 5. Accessibility — 15 points

- [ ] WCAG 2.2 AA contrast is measured on actual surfaces.
- [ ] Native elements are used; no clickable non-semantic containers.
- [ ] Headings and landmarks are ordered and labeled.
- [ ] Icon-only controls have accessible names.
- [ ] Fields have visible labels and linked errors/help.
- [ ] Results counts and important async updates use appropriate live regions.
- [ ] 200% zoom and a 320px viewport preserve function.
- [ ] Status does not depend on color alone.
- [ ] Keyboard-only and screen-reader paths are manually tested.

## 6. Motion and perceived performance — 10 points

- [ ] Interactive transitions name properties; no `transition-all`.
- [ ] Enter/exit timing explains origin and stays at or below 400ms.
- [ ] Reduced motion is implemented for global and component-level motion.
- [ ] Skeletons match final layout and do not create shifts.
- [ ] Images reserve space, use appropriate sizes, and preserve source quality.
- [ ] Autoplay/loops pause appropriately and avoid wasting battery/data.
- [ ] Slow-network behavior offers progress, retry, and recovery.

## 7. Content, trust, and Genie — 10 points

- [ ] Copy is sentence case, concrete, and free of internal jargon.
- [ ] Buttons name outcomes rather than “Submit”, “OK”, or vague “Learn more”.
- [ ] Errors say what happened and what to do.
- [ ] Prices use INR/Indian grouping consistently.
- [ ] Availability, freshness, and offer dates are honest.
- [ ] Genie results are clearly AI-assisted and grounded in catalogue products.
- [ ] Genie expresses uncertainty, never invents stock/delivery, and supports manual review.
- [ ] Placeholder links or misleading social/contact actions are not shown.

## 8. Admin usability and maintainability — 5 points

- [ ] Admin navigation is consistent and reachable by keyboard.
- [ ] Repeated editing workflows use visible labels, stable save state, and useful validation.
- [ ] Tables/forms support long real-world content and mobile fallback.
- [ ] Storefront-impacting settings make their effect understandable.
- [ ] Shared UI patterns are reused instead of copied into divergent variants.

## Scoring interpretation

| Score | Meaning |
|---|---|
| 90–100 | Exceptional and comprehensively verified |
| 80–89 | Strong, coherent, with limited non-blocking gaps |
| 70–79 | Competent but inconsistent; important improvement work remains |
| 60–69 | Functional, with visible system/accessibility debt |
| 50–59 | Usable in parts; major reliability or coherence problems |
| Below 50 | High-friction or misleading; requires foundational work |

## Before reporting done

- [ ] State exactly which routes/components were reviewed.
- [ ] State whether the application was rendered or only source-inspected.
- [ ] Report category scores and show the arithmetic to 100.
- [ ] Cite at least three strengths and three material weaknesses.
- [ ] Separate observed defects from reasonable inferences.
- [ ] Do not edit application code during an audit-only request.
