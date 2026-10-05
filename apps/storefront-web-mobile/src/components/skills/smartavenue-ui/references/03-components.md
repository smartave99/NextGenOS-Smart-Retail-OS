# Component catalog

## Contents

- Buttons, cards, rows, badges, segments, and filters
- Storefront header, mobile drawer, page heroes, and search
- Forms, progress, alerts, sheets, toasts, empty states, and skeletons
- Tables, charts, identity, and Genie/AI surfaces

Use this catalog to keep SmartAvenue coherent. Existing reusable UI lives under
`src/components/**`; not every semantic token shown here exists yet. **Inspect and reuse the
closest component before writing raw markup.** Add a new shared pattern only inside the repository
scope allowed by `AGENTS.md`.

Format: *anatomy → spec → states → rules*.

---

## Buttons

### Variants

| Variant | Background | Text | Use |
|---|---|---|---|
| `filled` | `bg-accent` | white | **The one** primary action on the screen |
| `filled-success` | `bg-success` | white | Save, mark available, confirm request received |
| `filled-danger` | `bg-danger` | white | Destructive commit (after confirmation) |
| `tinted` | `bg-accent-tint` | `text-accent` | Secondary actions; the common case |
| `gray` | `bg-fill-tertiary` | `text-label` | Neutral alternative ("Cancel", "Save draft") |
| `plain` | transparent | `text-accent` | Inline/tertiary; toolbar actions |
| `outline` | transparent + `border-separator` | `text-label` | Paired alternative to a filled button |

### Sizes

| Size | Height | Padding-x | Text | Radius | Icon |
|---|---|---|---|---|---|
| `sm` | 32 | 12 | `text-footnote` 600 | `rounded-sm` | 16 |
| `md` | 44 | 16 | `text-callout` 600 | `rounded-md` | 20 |
| `lg` | 52 | 20 | `text-headline` 600 | `rounded-md` | 22 |
| `xl` | 56 | 24 | `text-headline` 700 | `rounded-lg` | 24 |

`md` is the default. `sm` still needs a 44px hit area — expand with a `::after` or wrapper padding.

### States
- **hover** (pointer only, `@media (hover:hover)`) — background darkens one step
- **active** — `scale(0.97)`, 100ms
- **focus-visible** — `ring-2 ring-accent ring-offset-2 ring-offset-canvas`
- **disabled** — `opacity-40`, `pointer-events-none`, `aria-disabled="true"`. **Say why nearby.**
- **loading** — spinner replaces the icon, label stays, width is locked (`min-width` captured
  before swap so the button doesn't resize), `aria-busy="true"`

### Rules
- Label is a **verb phrase describing the outcome**: “Browse products”, “Clear filters”, “Send
  request”, “Check availability”. Never “Submit”, “OK”, or “Confirm” alone.
- Exactly one `filled` per screen viewport (Law 3).
- Full-width buttons only in sheets, forms, and phone-width primary actions. On desktop a
  full-width button reads as unfinished.
- Paired buttons: destructive/cancel on the **left**, confirming on the **right**. Equal widths
  when both are equally likely; the primary gets more width when it is clearly dominant.
- Icons sit **before** the label for actions, **after** for navigation/progression (`→`).

---

## Cards

### Standard card
```
bg-surface · rounded-xl (20) · p-4 or p-5 · shadow-e1 · no border in light mode
dark: bg-surface + border border-separator/40 (shadows don't read on black)
```
The default container for everything. On a tinted canvas it needs elevation, **not** a border
(a border plus a shadow reads as a 2010 web app).

### Hero card (navy)
```
bg-navy · rounded-2xl (24) · p-5 · text-white
optional: a subtle radial gradient or line-art motif at 6–10% opacity in the trailing area
```
Use for a page hero, a major current offer, or a Genie entry point. **One per screen, maximum.**

### Stat card
```
bg-surface · rounded-lg (16) · p-4 · shadow-e1
├─ icon tile: 36×36 rounded-md bg-{tone}-tint, glyph 18px text-{tone}
├─ value:     text-title-2 (22/700) tabular-nums, text-label
├─ label:     text-subhead text-label-secondary
└─ optional progress bar: h-1.5 rounded-full bg-fill-quaternary + bg-{tone} fill
```
Grid: 3-up on phone for compact stats, 2-up when values are long (currency). Never 4-up below
768px.

### Interactive card
Add: `cursor-pointer`, `active:scale-[0.98]`, `transition-transform duration-instant`, and on
pointer devices `hover:shadow-e2`. Must be a real `<button>` or `<a>`, never a `<div onClick>`.

### Rules
- Card padding is uniform (`p-4`) unless the card contains full-bleed media or a list, in which
  case padding goes on the *inner* elements and the media/rows go edge to edge.
- Concentric radii inside (Law 8): a `rounded-xl` card with `p-4` holds `rounded-sm` children.
- Never nest a shadowed card inside a shadowed card. The inner one uses `bg-surface-secondary`
  with no shadow.

---

## List rows

Use rows for filters, request queues, product metadata, and admin lists.

```
min-h-[56px] · px-4 · py-3 · flex items-center gap-3
├─ leading:  icon tile (40×40) | avatar (40) | thumbnail (48×48 rounded-lg)
├─ content:  title    text-headline text-label
│            subtitle text-subhead text-label-secondary  (max 1–2 lines, truncate)
└─ trailing: value | badge | chevron (16px text-label-tertiary) | button
separator: hairline, inset to align with the content start (not the card edge)
```

**Density variants:** `compact` (48px, `text-callout` title), `default` (56px), `comfortable`
(72px, two-line subtitle + metadata).

### Rules
- **The separator inset matters.** It starts where the *text* starts, not at the card edge — this
  is the single detail that makes a list look iOS-native. Last row has no separator.
- A chevron means "navigates to a new screen". Never put one on a row that expands in place
  (use a rotating disclosure caret) or does nothing.
- The whole row is the target, not just the title.
- Two-line truncation: `line-clamp-2`. Do not truncate the product name when it is the only way
  to identify the item; never truncate a barcode, price, or offer validity without another path to
  the full value.

---

## Badges / pills

```
h-6 (24) or h-7 (28) · px-2.5 · rounded-full
text-caption-1 (12/500)
bg-{tone}-tint · text-{tone}
optional leading dot (6px) or glyph (12px)
```

| Tone | Meaning in SmartAvenue |
|---|---|
| success | Available · Active · Saved · Request received |
| warning | Low stock · Expiring soon · Needs review · Availability uncertain |
| danger | Out of stock · Failed · Expired · Destructive |
| info / accent | Selected · New · Current · Store information |
| ai (indigo) | AI-generated content specifically |
| neutral (`bg-fill-tertiary` / `text-label-secondary`) | Draft · Archived · Unavailable |

**Rules**
- Badges **state a fact**, never an action. If it's tappable it's a chip or a button.
- Text is a noun or adjective, 1–3 words, sentence case.
- Never a saturated solid fill — tint only. The exception is a critical count badge on an icon
  (`bg-danger text-white`), which is a notification, not a status.
- A "Live" badge gets a pulsing dot; that's the only badge permitted to animate.

---

## Segmented control

```
container: h-9 (36) or h-11 (44) · p-1 · rounded-full · bg-fill-secondary
segment:   flex-1 · rounded-full · text-footnote 600
selected:  bg-surface · text-label · shadow-e1
unselected: text-label-secondary
indicator slides: transform 250ms ease-spring
```
2–4 segments only. Five means you need a filter sheet or a scrollable chip row instead. Labels are
one word where possible (“All / Available / Offers” or “Details / Reviews / Offers”).

## Filter chips (scrollable row)

```
h-9 · px-4 · rounded-full · text-footnote 600 · whitespace-nowrap
unselected: bg-surface text-label-secondary shadow-e1
selected:   bg-accent text-white   (or bg-{tone}-tint text-{tone} for tone-coded filters)
row: flex gap-2 overflow-x-auto, edge-to-edge with px-4 scroll padding, scrollbar hidden
```
Fade the trailing edge with a mask so it's obvious more chips exist off-screen.

---

## Storefront header and mobile drawer

SmartAvenue uses a fixed floating header rather than the copied project's bottom tab bar.

```
header: fixed top, centered max-width container, translucent/opaque surface as scroll changes
leading: logo + store name when space allows
desktop nav: Home · Products · Offers · Departments · About
utility actions: Request product · search/barcode · Genie entry where space allows
mobile: logo + compact utility actions + menu button
drawer: modal navigation with all destinations and one clear catalogue action
```

**Rules**
- Keep route names and order consistent between desktop navigation and the mobile drawer.
- Mark the current route with `aria-current="page"`.
- Every icon-only utility is at least 44×44px and has an accessible name.
- The drawer closes with Escape, prevents background scroll, traps focus, and returns focus to the
  menu trigger.
- Search supports text and barcode entry without letting utility controls crowd the brand.
- The “browse online, purchase in store” notice is readable but visually secondary to navigation.
- Do not add a bottom tab bar unless product strategy explicitly replaces the existing information
  architecture.

---

## Page hero / section header

```
Dark editorial page hero:
  enough top padding to clear the fixed header and retail notice
  optional background image with contrast-protecting overlay
  eyebrow: short and useful, not perpetual animation
  title: one h1 with responsive display scale
  subtitle: readable measure, strong contrast

Section header:
  noun title + optional one-line explanation + one trailing action
  space above exceeds space below
```
Keep product, offer, and department heroes recognizably related. A page hero must help orientation,
not merely consume vertical space.

---

## Search field

```
h-11 (44) · px-4 · rounded-md (12) · bg-fill-tertiary · no border
leading icon 18px text-label-tertiary · gap-2.5
input: text-body · placeholder text-label-tertiary
trailing: clear (×) when non-empty, filter glyph if applicable
focus: ring-2 ring-accent/30, background lightens to bg-surface
```
Debounce input by 300ms. Show results inline; never navigate away to a results page on a phone.
Empty results get an empty state, not a blank area.

---

## Form fields

```
label: text-caption-1 (12/500) text-label-secondary, mb-1.5
field: min-h-[48px] · px-3.5 · rounded-md (12) · bg-fill-tertiary
       text-body text-label
       trailing icon tile: 28×28 rounded-sm bg-accent-tint, glyph 16px text-accent
help:  text-footnote text-label-secondary, mt-1.5
error: text-footnote text-danger, mt-1.5, with a 14px warning glyph
```

**Rules**
- **Labels are always visible.** Placeholder-as-label is an accessibility failure — it disappears
  exactly when the user needs it, and it fails for screen readers.
- Group related fields in one surface or clearly labeled section rather than scattering loose
  inputs across the page.
- Correct `inputmode` / `type` / `autocomplete` on every field. A phone number field that opens a
  QWERTY keyboard is a defect.
- Validate on **blur**, not on every keystroke. Re-validate on change only *after* the field has
  errored once.
- Errors appear below the field, are announced (`aria-describedby` + `role="alert"`), and the
  field gets `aria-invalid="true"` and a `border-danger`.
- Never disable the submit button to enforce validation. Let the user submit and show them what's
  wrong — a disabled button with no explanation is a dead end.
- Required fields: mark the **optional** ones instead if most are required. Less visual noise.

---

## Progress

### Linear bar
```
track: h-1.5 rounded-full bg-fill-quaternary
fill:  h-full rounded-full bg-{tone}, transform: scaleX(), origin-left
       600ms ease-emphasis
```
Tone follows the value's meaning: success ≥80%, accent 40–79%, warning 20–39%, danger <20% — but
only where "higher is better". For risk scores, invert.

### Stepper (numbered flow)
```
step circle: 32×32 rounded-full
  done:    bg-accent text-white with a check glyph
  current: bg-accent text-white with the number, + 4px ring ring-accent/20
  upcoming: border border-separator text-label-tertiary
connector: 1px dashed separator (solid accent when the step is complete)
label: text-caption-1, current is text-accent 600, others text-label-secondary
```

### Timeline (request or admin workflow)
```
node: 28×28 rounded-full
  complete: bg-success + check glyph, connector before it is solid success
  current:  bg-accent + the step's glyph, with a soft ring
  upcoming: bg-fill-tertiary, connector is separator
label below: text-footnote 600 · timestamp text-caption-1 text-label-tertiary
```
Horizontal on phone when ≤5 steps; vertical when more or when each step has detail.

### Circular / indeterminate
Only for actions, never content. 20px stroke-2, `text-accent`, rotating 1s linear infinite. Under
reduced motion, replace with a pulsing opacity.

---

## Alert and admin-attention cards

```
rounded-xl · p-4 · bg-{tone}-tint (very light) · border-l-4 border-{tone}
├─ icon tile 44×44 rounded-md bg-{tone} with a white glyph
├─ eyebrow:   text-caption-2 uppercase text-{tone}
├─ title:     text-headline text-label
├─ detail:    text-subhead text-label-secondary
├─ timestamp: text-caption-1 text-label-tertiary, trailing
└─ actions:   two buttons — tinted (secondary) then filled-{tone} (primary)
```
Severity order: `danger` (Critical) → `warning` (Caution) → `accent` (Action required) →
`success` (Information). Sort by severity, then recency.

---

## Sheets & modals

```
Sheet (phone default):
  rounded-t-3xl (32) · bg-surface · shadow-e4
  grabber: 36×5 rounded-full bg-fill at top center, mt-2
  enter: translateY(100%→0) 400ms ease-decelerate
  detents: medium (50vh) and large (92vh); drag between them
  backdrop: bg-black/25, tap to dismiss

Modal (desktop ≥768px):
  centered · max-w-[520px] · rounded-2xl · shadow-e4
  enter: scale(0.96→1) + opacity 250ms ease-decelerate
```
- Focus traps inside; `Esc` closes; focus returns to the trigger on close.
- The page behind must not scroll (`overflow: hidden` on body, and preserve scroll position).
- Destructive confirmations name the specific thing: “Delete product ‘USB fan’?” not “Are you sure?”.
- Never a modal inside a modal. Never a modal for something that could be a page.

---

## Toast / snackbar

```
fixed bottom with safe viewport spacing · mx-4 · max-w-[420px]
rounded-lg · p-3.5 · material-thick · shadow-e3
leading glyph 20px text-{tone} · message text-subhead · optional action text-accent 600
auto-dismiss 4s (8s with an action) · swipe to dismiss
```
For confirmations and recoverable errors. Never for anything the user must act on — that's a
sheet. Stack at most 3; collapse the rest into "+2 more".

---

## Empty states

```
py-16 · text-center · max-w-[320px] mx-auto
├─ glyph: 48px text-label-tertiary (or a simple illustration at ≤40% opacity)
├─ title: text-title-3 text-label
├─ body:  text-subhead text-label-secondary
└─ action: one tinted or filled button
```
Three flavors, and they are **not** interchangeable:
- **Nothing yet** — encouraging, with the action that creates the first item.
- **No results** — states the active filter and offers to clear it.
- **Error** — says what failed, offers Retry, and never blames the user.

An empty area with no explanation is always a bug.

---

## Skeletons

```
bg-fill-quaternary · rounded-sm · animate-shimmer
shimmer: a 1.5s linear-infinite gradient sweep (disabled under reduced motion → static fill)
```
**Match the real content's dimensions exactly**, or the page jumps when data lands — which is
worse than showing nothing. Skeleton text lines are 12–14px tall with the last line at 60% width.

---

## Data tables (desktop) → cards (phone)

Below 768px a table becomes a stacked list of cards; each row's columns become label/value pairs.
Never a horizontally scrolling table on a phone.

```
Desktop table:
  header: text-caption-1 600 text-label-secondary, sticky, bg-surface, border-b separator
  cell:   text-callout, py-3, numbers tabular-nums and right-aligned
  row hover: bg-fill-quaternary
  zebra: no — use hairlines
```
Sortable headers get a direction glyph and `aria-sort`. Selection uses a leading checkbox column
with a header select-all that reflects the indeterminate state.

---

## Charts

Use an appropriate chart/visualization workflow before adding a chart. SmartAvenue charts mainly
belong in admin summaries; do not add them decoratively to storefront pages.

- Line charts (catalogue/request trend): 2px stroke `accent`, 4px dots at data points only when there
  are ≤12 points, a soft gradient fill beneath at 12% → 0% opacity.
- Axis labels `text-caption-1 text-label-tertiary`; gridlines `separator` at 40% opacity,
  horizontal only.
- Currency axes state the unit once in the corner (“₹ in Lakhs”) rather than repeating it per tick.
- Every chart needs a text alternative — a caption stating the takeaway, and a
  `<table class="sr-only">` with the underlying values.

---

## Avatars & identity

```
sizes: 28 (dense) · 40 (list) · 56 (header) · 96 (profile)
rounded-full · bg-accent-tint · initials text-accent 600 (uppercase, 2 chars max)
verified: 16px success check badge, bottom-trailing, with a 2px surface-colored ring
group: overlap by 40% with a surface-colored ring on each; cap at 3 + "+N"
```

---

## The AI surface

AI-produced content is always visually marked. Non-negotiable — it's a trust requirement, not
styling.

- **Entry point** — a consistent Genie card or button with a sparkle glyph and explicit purpose.
- **Inline suggestion** — `bg-ai-tint`, a 16px sparkle, `text-subhead`, with the model's reasoning
  one tap away.
- **Confidence** — always shown as a number when the model extracted data ("94% confidence"), with
  the low-confidence fields individually flagged for review.
- **Every consequential AI action is reviewable before it executes.** Recommendation flows let the
  shopper edit inputs, inspect catalogue products, and choose the next action.
- **Recommendations explain their fit** using budget, occasion, preference, and actual product
  attributes. Never fabricate stock, reviews, price, delivery, or certainty.
