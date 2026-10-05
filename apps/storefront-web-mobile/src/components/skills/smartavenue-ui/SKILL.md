---
name: smartavenue-ui
description: >-
  Design, review, and improve Smart Avenue 99 storefront and admin user interfaces. Use before
  writing or editing React/Next.js components, Tailwind classes, src/app/globals.css, responsive
  layouts, navigation, search and filters, product or offer cards, product details, request-product
  flows, Genie AI surfaces, forms, dialogs, loading/empty/error states, accessibility, motion, or
  user-facing copy. Also use for UI audits and scores. Keep work within repository AGENTS.md
  boundaries and preserve Smart Avenue's browse-online, purchase-in-store business model.
---

# SmartAvenue UI

Treat this skill as the project-specific UI contract for Smart Avenue 99. The product is a
mobile-first catalogue for an offline Patna retail store: customers discover products and offers
online, then purchase in store. It also contains staff-facing administration and Genie-assisted
shopping flows.

## Non-negotiable laws

1. **Respect repository scope.** Read `AGENTS.md` first. UI work is restricted to the paths it
   allows. Do not cross into backend, data, routing, dependencies, or configuration.
2. **Inspect before inventing.** Read the affected component, `src/app/globals.css`, and the
   closest existing surface before choosing classes or patterns.
3. **One clear primary action.** Use one visually dominant action per viewport. Everything else
   must be secondary, neutral, or plain.
4. **Use 44×44 minimum targets.** Preserve at least 8px between adjacent touch targets.
5. **Use semantic design decisions.** Prefer project tokens and reusable component patterns. Do
   not add raw one-off values when an existing token or pattern expresses the intent.
6. **Design every state.** Cover default, hover, pressed, focus-visible, disabled, loading,
   empty, error, stale/partial, and overflow/long-content behavior.
7. **Make status independent of color.** Pair color with a word or icon and meet WCAG 2.2 AA.
8. **Use motion to explain causality.** Name transitioned properties, keep interactive motion at
   400ms or less, and support reduced motion. Never use `transition-all`.
9. **Tell the retail truth.** Never imply delivery, online checkout, shipping, or remote ordering.
   Use language such as “Browse products”, “Check availability”, and “Purchase in store”.
10. **Label AI honestly.** Genie recommendations must be recognizable as AI-assisted, grounded in
    available store products, and reviewable before any consequential action.

## Required workflow

### 1. Orient

- Read `AGENTS.md` and confirm the allowed scope.
- Read `references/09-people.md` for the customer or staff persona.
- Read `references/07-smartavenue-surfaces.md` and identify the closest existing route/surface.
- Inspect `src/app/globals.css` and the affected files. Do not assume tokens or utilities exist.

### 2. Name the pattern

Choose one existing archetype: marketing home, catalogue grid, product detail, offer feed,
department grid, guided AI flow, request form, policy/content page, or admin workspace. Reuse the
corresponding navigation, density, spacing, and state behavior.

### 3. Compose within the current system

Reuse components under `src/components/**` before creating another pattern. New shared UI belongs
under that same allowed subtree. Keep data contracts and server behavior unchanged unless the user
has explicitly provided the repository override required by `AGENTS.md`.

The current codebase uses Tailwind v4 through `src/app/globals.css`. Some legacy `brand-*`,
`slate-*`, raw colors, arbitrary values, and broad transition utilities exist. Treat them as audit
findings, not automatic precedents. For a focused task, avoid widening the change into an
unrequested design-system migration.

### 4. Fill every state

Build the loading, empty, error, long-text, out-of-stock/unavailable, slow-network, keyboard, and
small-screen behavior alongside the happy path. Preserve user input after errors.

### 5. Verify the rendered result

- Review at 320, 375, 768, 1024, and 1440px.
- Test keyboard-only operation, 200% zoom, grayscale, and reduced motion.
- Check light surfaces and every dark hero/footer surface actually used.
- Run the repository's existing relevant checks without changing dependencies or configuration.
- Do not claim visual quality from source inspection alone; distinguish code evidence from
  rendered/manual evidence.

### 6. Gate and score

Walk `references/08-review-checklist.md`. For audits, score each section using its published
weights and cite concrete file/component evidence. Do not inflate a score for feature breadth:
visual coherence, accessibility, interaction reliability, and honest retail messaging matter
more than the number of screens.

## Project conventions

- **Brand:** Smart Avenue 99; Genie names AI-assisted shopping experiences.
- **Business model:** browse online, purchase in store; no delivery or remote orders.
- **Primary surfaces:** `/`, `/products`, `/products/[id]`, `/offers`, `/offers/[id]`,
  `/departments`, `/request-product`, `/stylist`, `/gift-finder`, `/about`, and `/admin/**`.
- **Primary UI locations:** `src/components/**` and `src/app/globals.css`, subject to `AGENTS.md`.
- **Navigation:** fixed floating header on the storefront, mobile drawer on small screens, and
  sidebar-based navigation in admin. Do not import the copied project's bottom-tab architecture.
- **Typography and colors:** use the foundations reference as the quality target, but verify what
  is implemented in `globals.css` before using a class.
- **Images:** preserve aspect ratio, reserve space, provide accurate alt behavior, and avoid
  degrading uploaded product imagery.
- **Currency:** format INR through `Intl.NumberFormat('en-IN')`.

## References

| File | Read when |
|---|---|
| `references/01-foundations.md` | Choosing type, color, spacing, radius, elevation, material, or layout |
| `references/02-motion.md` | Anything moves, appears, disappears, loads, or responds to touch |
| `references/03-components.md` | Building or reviewing a component or reusable pattern |
| `references/04-interaction.md` | Touch, pointer, keyboard, forms, dialogs, scrolling, or slow networks |
| `references/05-accessibility.md` | Every task before completion |
| `references/06-writing.md` | Any visible string, including AI, errors, empty states, and calls to action |
| `references/07-smartavenue-surfaces.md` | Mapping work to actual storefront/admin routes and patterns |
| `references/08-review-checklist.md` | Auditing, scoring, or reporting UI work complete |
| `references/09-people.md` | Starting a new screen or evaluating usability for real customers/staff |

## Scope discipline

Improve the requested interface without adding unrelated features. Do not silently redesign the
whole product during a local fix. In an audit, report evidence and priorities only unless the user
also asks for implementation.
