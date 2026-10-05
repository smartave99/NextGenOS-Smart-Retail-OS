# Foundations — type, color, space, shape, depth

## Contents

1. Grid
2. Typography
3. Color
4. Shape
5. Depth
6. Iconography
7. Layout archetypes

Everything visual resolves to one of six systems. Learn these and most design decisions stop being
decisions.

This document defines the quality target. It does **not** assert that every token or utility below
already exists. SmartAvenue currently defines Tailwind v4 theme values and global utilities in
`src/app/globals.css`. Inspect that file first; introduce or migrate tokens only when the task
explicitly includes design-system work.

---

## 1. The grid

Apple's interfaces resolve to a **4pt base grid**, with 8pt as the dominant rhythm. Every gap,
padding, and offset is a multiple of 4.

| Token | px | Use |
|---|---|---|
| `0.5` | 2 | Hairline offsets, optical nudges only |
| `1` | 4 | Icon-to-label in a dense chip |
| `2` | 8 | Inside a control; between a label and its value |
| `3` | 12 | Between sibling cards; list row vertical padding |
| `4` | 16 | Card padding; screen edge margin on phone |
| `5` | 20 | Generous card padding |
| `6` | 24 | Section gap; screen edge margin on tablet |
| `8` | 32 | Major section break; screen margin on desktop |
| `10` | 40 | Above a page's first section |
| `12` | 48 | Between unrelated regions |
| `16` | 64 | Empty-state vertical breathing room |

**Screen margins** — `px-4` (phone, 375–767) → `px-6` (tablet, 768–1023) → `px-8` (desktop, 1024+).
Content inside a centered container maxes at `max-w-[1120px]`.

**Readable measure** — body paragraphs cap at **60–75 characters** (`max-w-[68ch]`). Form fields
cap at `max-w-[520px]` unless the field genuinely holds long content (address, notes).

**Vertical rhythm** — the space *above* a heading is always larger than the space below it. A
section title has `mt-8 mb-3`. This is what makes a long page scannable.

---

## 2. Typography

### 2.1 The font stack

```css
font-family: -apple-system, BlinkMacSystemFont, "SF Pro Text", "SF Pro Display",
             "Inter var", Inter, "Segoe UI Variable", "Segoe UI", Roboto,
             "Helvetica Neue", Arial, sans-serif;
```

**Why `-apple-system` first and not a webfont:** on iPhone, iPad, and Mac this resolves to real
**SF Pro**, with Apple's optical sizing, real Dynamic Type metrics, and correct tracking — the
genuine article, zero bytes downloaded, zero layout shift. SF Pro's license does not permit
serving it as a webfont, and shipping a lookalike to Apple devices would be *worse* than the real
font. Inter is the fallback for Windows/Android/Linux because its metrics are the closest
available match (same x-height ratio, near-identical cap height), so the layout does not reflow
across platforms.

**Numerals:** use `font-variant-numeric: tabular-nums` on anything that updates in place or sits in
a column — prices, counts, percentages, timers, table cells. Use proportional (default) for
numbers inside running prose. Tabular numerals prevent the horizontal jitter that instantly reads
as amateur.

```css
.tabular { font-variant-numeric: tabular-nums; font-feature-settings: 'tnum' 1; }
```

### 2.2 The scale

Apple's stock iOS Dynamic Type at the default (Large) content size:

| Text style | Size | Stock weight | Line height | Tracking |
|---|---|---|---|---|
| Large Title | 34 | Regular | 41 | +0.37 |
| Title 1 | 28 | Regular | 34 | +0.36 |
| Title 2 | 22 | Regular | 28 | +0.35 |
| Title 3 | 20 | Regular | 25 | +0.38 |
| Headline | 17 | **Semibold** | 22 | −0.41 |
| Body | 17 | Regular | 22 | −0.41 |
| Callout | 16 | Regular | 21 | −0.32 |
| Subheadline | 15 | Regular | 20 | −0.24 |
| Footnote | 13 | Regular | 18 | −0.08 |
| Caption 1 | 12 | Regular | 16 | 0 |
| Caption 2 | 11 | Regular | 13 | +0.06 |

Note the tracking sign flip: **negative above ~13pt, positive below**. Small text needs air; large
text needs tightening. This single detail is most of why hand-rolled type scales look wrong.

### 2.3 Recommended SmartAvenue scale

Use a limited scale with bold display titles and legible catalogue text. The class names below are
the preferred semantic vocabulary **after they are defined in `globals.css`**. Until then, map
existing Tailwind sizes consistently rather than inventing one-offs per component.

| Class | Size/LH | Weight | Tracking | Use |
|---|---|---|---|---|
| `text-display` | 34/40 | 700 | −0.4px | Storefront/page hero title |
| `text-title-1` | 28/34 | 700 | −0.5px | Product/offer title, prominent price |
| `text-title-2` | 22/28 | 700 | −0.4px | Card group headings |
| `text-title-3` | 20/25 | 600 | −0.3px | Card titles, modal titles |
| `text-headline` | 17/22 | 600 | −0.2px | List row primary text, emphasized body |
| `text-body` | 17/24 | 400 | −0.2px | Paragraphs, field values |
| `text-callout` | 16/21 | 400 | −0.2px | Secondary body, dense list rows |
| `text-subhead` | 15/20 | 400 | −0.1px | Row subtitles, helper text |
| `text-footnote` | 13/18 | 400 | 0 | Metadata, timestamps, captions under charts |
| `text-caption-1` | 12/16 | 500 | +0.1px | Badge text, field labels, tab bar labels |
| `text-caption-2` | 11/14 | 600 | +0.4px | Overline/eyebrow labels (uppercase) |

**Rules:**
- These classes already carry weight, line-height, and tracking. **Never** add `leading-*` or
  `tracking-*` on top. If you need a different line-height, the string is the wrong style.
- Weight may be raised one step for emphasis (`font-semibold` on `text-body`), never lowered.
- Uppercase is permitted **only** on `text-caption-2`, and always with its positive tracking.
  Uppercasing anything larger is a 2014 dashboard tell.
- Minimum readable size anywhere in the product is **11px**. No exceptions, including legal text.
- Never more than **three** distinct styles visible in one card. Four means the card is doing too
  much.

### 2.4 Dynamic Type / user zoom

Never set font sizes in `px` at the root. The scale above is defined in `rem` against a 16px root,
so browser zoom and OS text-size settings scale it. Do not disable zoom
(`user-scalable=no` is banned). Layouts must survive 200% text scaling without clipping — use
`min-height` not `height`, and let text wrap rather than truncate wherever the string is meaningful.

---

## 3. Color

### 3.1 Current implementation and target

The current token layer lives in `src/app/globals.css` and exposes `--primary`, `--secondary`,
`--accent`, background/foreground values, and legacy `brand-*` Tailwind colors. Some legacy names
do not describe their actual values: the current “brand-blue” resolves to black and “brand-lime”
resolves to blue. Treat that mismatch as design debt.

- For a focused component task, reuse current values consistently without expanding the mismatch.
- For an explicit design-system task, migrate toward semantic roles such as `canvas`, `surface`,
  `label`, `accent`, `success`, `warning`, and `danger` in `globals.css`.
- Never hardcode a reusable color separately in many components.

### 3.2 Apple system palette (verbatim)

Community-measured from the OS; Apple does not publish guaranteed hex values because the rendered
color depends on the trait environment. Treat these as accurate-to-render, not contractual.

| Color | Light | Dark |
|---|---|---|
| systemBlue | `#007AFF` | `#0A84FF` |
| systemGreen | `#34C759` | `#30D158` |
| systemIndigo | `#5856D6` | `#5E5CE6` |
| systemOrange | `#FF9500` | `#FF9F0A` |
| systemPink | `#FF2D55` | `#FF375F` |
| systemPurple | `#AF52DE` | `#BF5AF2` |
| systemRed | `#FF3B30` | `#FF453A` |
| systemTeal | `#5AC8FA` | `#64D2FF` |
| systemYellow | `#FFCC00` | `#FFD60A` |
| systemGray | `#8E8E93` | `#8E8E93` |
| systemGray2 | `#AEAEB2` | `#636366` |
| systemGray3 | `#C7C7CC` | `#48484A` |
| systemGray4 | `#D1D1D6` | `#3A3A3C` |
| systemGray5 | `#E5E5EA` | `#2C2C2E` |
| systemGray6 | `#F2F2F7` | `#1C1C1E` |

Note the gray ramp **inverts** between modes — gray6 is the lightest in light mode and the darkest
in dark mode. This is why you must use semantic tokens: `bg-surface` is correct in both, `bg-gray-6`
is correct in one.

### 3.3 Label tiers (text)

Text color is **alpha over the background**, not a fixed gray. This is critical: it means text
composites correctly on white, on a tinted card, and on a material.

| Token | Light | Dark | Use |
|---|---|---|---|
| `label` | `#000000` | `#FFFFFF` | Primary text, headings, values |
| `label-secondary` | `rgba(60,60,67,0.60)` | `rgba(235,235,245,0.60)` | Subtitles, descriptions |
| `label-tertiary` | `rgba(60,60,67,0.30)` | `rgba(235,235,245,0.30)` | Placeholders, disabled |
| `label-quaternary` | `rgba(60,60,67,0.18)` | `rgba(235,235,245,0.16)` | Decorative glyphs only |

**Contrast note:** `label-tertiary` at 30% fails 4.5:1. It is legal only for genuinely
non-essential text (placeholder that duplicates a visible label, decorative separators). If a user
must read it, it is `label-secondary` or higher.

### 3.4 Backgrounds and fills

SmartAvenue commonly uses light slate canvases, white cards, and dark editorial heroes. Keep those
surface roles consistent across storefront routes.

| Token | Light | Dark | Use |
|---|---|---|---|
| `canvas` | `#F2F4F8` | `#000000` | The page behind everything |
| `surface` | `#FFFFFF` | `#1C1C1E` | Cards, sheets, list containers |
| `surface-secondary` | `#F2F4F8` | `#2C2C2E` | Nested panel inside a card |
| `surface-elevated` | `#FFFFFF` | `#2C2C2E` | Popovers, menus, modals |
| `fill` | `rgba(120,120,128,0.20)` | `rgba(120,120,128,0.36)` | Large control backgrounds |
| `fill-secondary` | `rgba(120,120,128,0.16)` | `rgba(120,120,128,0.32)` | Segmented control track |
| `fill-tertiary` | `rgba(118,118,128,0.12)` | `rgba(118,118,128,0.24)` | Input field, search bar |
| `fill-quaternary` | `rgba(116,116,128,0.08)` | `rgba(118,118,128,0.18)` | Subtle zebra, progress track |
| `separator` | `rgba(60,60,67,0.29)` | `rgba(84,84,88,0.60)` | Hairline between rows |
| `separator-opaque` | `#C6C6C8` | `#38383A` | Full-bleed divider |

Fills are **translucent by design** — they pick up whatever is behind them, so the same token works
on white and on a tinted card. Never substitute a solid gray.

**Hairlines:** a separator is `1px` at 1× but should be a true hairline on retina. Use
`border-width: 0.5px` guarded by a `min-resolution: 2dppx` media query, or the `.hairline` utility.

### 3.5 SmartAvenue brand semantics

Ground brand roles in the current storefront, then improve naming only as an intentional migration.

| Role | Target treatment | Use |
|---|---|---|
| `primary` | Near-black | Dark hero, strongest neutral action, high-emphasis text |
| `secondary/accent-blue` | Blue | Primary links/actions, selection, focus |
| `success` | Emerald | Available/complete/successful states |
| `warning` | Amber | Limited stock, expiring/conditional offer, caution |
| `danger` | Red | Failure and destructive actions only |
| `ai` | Indigo/violet or a consistent Genie treatment | AI-generated/suggested content only |
| `canvas/surface` | Light slate / white | Page background and content containers |

Give semantic status colors a low-emphasis tint for badges and icon tiles. Measure text contrast
on the actual composite rather than assuming a percentage is safe.

**The AI color rule:** indigo/violet is reserved for content the model produced or suggested — AI
picks, inferred fields, confidence scores, the assistant entry point. Never use it decoratively.
When a user sees indigo they should know a model was involved. This is a trust affordance, not a
palette choice.

### 3.6 Using color correctly

- **Status is never color alone** (Law 5). "Delayed" is orange *and* says "Delayed" *and* has a
  clock glyph. Roughly 1 in 12 men cannot distinguish your red from your green.
- **Tint, don't fill.** A status badge is `bg-{tone}-tint` + `text-{tone}`, not a saturated solid.
  Solid fills are reserved for the single primary action and for critical alerts.
- **One accent per screen.** If three things are blue and prominent, none of them are primary.
- **Dark mode is not an inversion.** Surfaces get *lighter* as they get closer to the user
  (`#1C1C1E` → `#2C2C2E` → `#3A3A3C`), the opposite of light mode's shadow-based depth. Saturated
  colors must be *desaturated and brightened* in dark mode or they vibrate against black — that is
  exactly what the dark column of every table above does.
- **Never pure black text on pure white** at body size for long reading. `label` is `#000` because
  it's used sparingly and at weight; running prose sits at `label` on `surface` which is fine, but
  a wall of `#000` on `#FFF` is fatiguing.

---

## 4. Shape

### 4.1 The radius scale

| Token | px | Use |
|---|---|---|
| `rounded-xs` | 6 | Badges, tags, tiny chips |
| `rounded-sm` | 8 | Inner elements inside a padded card |
| `rounded-md` | 12 | Buttons, inputs, icon tiles |
| `rounded-lg` | 16 | Small cards, list containers, images |
| `rounded-xl` | 20 | Standard product, offer, and content card |
| `rounded-2xl` | 24 | Hero cards, sheets, modals |
| `rounded-3xl` | 32 | Full-screen sheet top corners |
| `rounded-full` | 9999 | Pills, avatars, FABs, segmented controls |

### 4.2 Concentricity (Law 8)

When one rounded shape sits inside another:

```
inner_radius = outer_radius − padding
```

A `rounded-xl` (20) card with `p-3` (12) padding holds a `rounded-sm` (8) child. Get this wrong and
the gap between the two curves visibly pinches or bulges — the eye catches it even when the mind
doesn't. iOS 26 exposes this as `.containerConcentric`; on the web you do the arithmetic.

If `outer − padding` would go below 4, use a square inner element instead. A 3px radius reads as a
rendering artifact.

### 4.3 Continuous corners (the squircle)

Apple uses a **superellipse**, not a circular arc — the curvature ramps in smoothly rather than
starting abruptly at the tangent point. CSS `border-radius` gives you the circular arc.

- For most elements the difference is imperceptible; use `border-radius` and move on.
- It becomes visible at **large radii on large shapes** — hero cards, app-icon-like marks, anything
  over ~24px radius at over ~200px wide. There, the circular arc looks slightly "pinched".
- For those cases use the `.squircle` utility (SVG/mask based) defined in `globals.css`. Do not
  hand-roll superellipse math inline.
- App-icon-shaped marks (like the `BB` tile in the splash mockup) use radius = **22.37%** of the
  side length, which is Apple's current icon shape ratio.

### 4.4 Shape conveys affordance

- **Pill** (`rounded-full`) — filters, chips, toggles, status. Reads as "selectable, ephemeral".
- **Rounded rect** (`rounded-md`) — buttons and inputs. Reads as "committed action".
- **Card** (`rounded-xl`) — a container of related content. Reads as "an object".
- **Circle** — identity (avatar) or a single-purpose control (FAB, radio).

Don't mix: a pill-shaped primary submit button next to a rounded-rect one is visual noise.

---

## 5. Depth

### 5.1 The elevation ladder

Apple shadows are **large, soft, and nearly invisible**. The single most common mistake is a
shadow that is too dark and too tight.

| Token | Value | Use |
|---|---|---|
| `shadow-e0` | `none` | Flush content, list rows inside a card |
| `shadow-e1` | `0 1px 2px rgba(16,24,40,.04), 0 4px 12px rgba(16,24,40,.06)` | Resting card |
| `shadow-e2` | `0 2px 4px rgba(16,24,40,.04), 0 8px 24px rgba(16,24,40,.08)` | Raised / hovered card, sticky bar |
| `shadow-e3` | `0 4px 8px rgba(16,24,40,.05), 0 16px 40px rgba(16,24,40,.12)` | Popover, dropdown, toast |
| `shadow-e4` | `0 8px 16px rgba(16,24,40,.06), 0 32px 64px rgba(16,24,40,.16)` | Modal, sheet |

Two layers each: a tight one for the contact edge, a wide one for the ambient falloff. That
two-layer construction is what makes it read as light rather than as a gray rectangle.

The shadow color is a desaturated navy (`16,24,40`), not black. Pure-black shadows go muddy over
tinted canvases.

**Dark mode:** shadows barely work on black. Depth comes from **surface lightness** instead —
`#1C1C1E` → `#2C2C2E` → `#3A3A3C` as elements come forward. Keep a much-reduced shadow (opacity
~0.4 of the light value) for the contact edge only, and add a `1px` top inner highlight
(`inset 0 1px 0 rgba(255,255,255,0.04)`) on elevated surfaces.

### 5.2 Materials (translucency)

Materials blur and tint what's behind them. Used for **chrome that floats over content**: tab bars,
nav bars, sheets, popovers.

| Token | Blur | Light tint | Dark tint |
|---|---|---|---|
| `material-thin` | 20px | `rgba(255,255,255,0.72)` | `rgba(30,30,32,0.72)` |
| `material-regular` | 30px | `rgba(255,255,255,0.82)` | `rgba(30,30,32,0.82)` |
| `material-thick` | 40px | `rgba(255,255,255,0.92)` | `rgba(30,30,32,0.92)` |
| `material-chrome` | 30px | `rgba(246,246,248,0.86)` | `rgba(20,20,22,0.86)` |

Each also carries `backdrop-filter: saturate(180%)` — the saturation boost is what makes iOS
translucency look alive rather than like a gray wash.

**Rules:**
- Material is for **chrome only**. Never put content on a material; put content on `surface`.
- **Material never stacks on material.** A blurred popover inside a blurred sheet turns to mud.
  One layer of translucency per stacking context.
- Always provide the opaque fallback: `@supports not (backdrop-filter: blur(1px))` → solid
  `surface` at full opacity.
- Under `prefers-reduced-transparency: reduce`, collapse every material to its opaque equivalent.
- Text on a material needs its own contrast check against the *worst-case* content behind it. If
  you can't guarantee it, use `material-thick` or a solid surface.

### 5.3 Liquid Glass (iOS 26)

Apple's current design language renders navigation-layer chrome as a refractive glass material with
specular highlights and light bending at the edges. SmartAvenue currently has `.glass-panel` and
`.glass-header` utilities. Use translucency for navigation/overlay chrome only, and add semantic
material tokens only during an explicit system cleanup. A characteristic light rim may use:

```css
box-shadow: inset 0 1px 0 rgba(255,255,255,0.55),   /* top specular */
            inset 0 -1px 0 rgba(255,255,255,0.12);  /* bottom bounce */
```

The three-layer discipline that comes with it is the part that actually matters:

1. **Content layer** — no glass, ever. Cards, text, images.
2. **Navigation layer** — glass. Tab bar, nav bar, floating toolbars.
3. **Overlay layer** — vibrancy and fills *on* the glass. Labels and icons in the tab bar.

Glass cannot sample glass. If two glass elements are adjacent, they belong to one container.

---

## 6. Iconography

- **Stroke weight scales with text.** Beside `text-body` (17px), icons are 20–22px at 1.5–1.75px
  stroke. Beside `text-footnote`, 16px at 1.5px. The icon should read at the same ink density as
  the text next to it.
- **Optical alignment** — center the icon on the text's **cap height**, not its bounding box.
  In practice this means a `-mt-px` nudge on most inline icons.
- **Icon tiles** — use a tinted rounded square behind a colored glyph: `rounded-md`,
  `bg-{tone}-tint`, glyph in `text-{tone}` at 20px, tile 40×40 (or 36×36 in dense rows). This is
  a useful SmartAvenue pattern for departments, filters, offers, and admin summaries.
- **One icon family.** Do not mix outline and filled sets, or two different corner treatments.
  Filled is for *selected* states, outline for unselected — that's the only permitted mix, and it's
  exactly what the tab bar does.
- **Never an icon-only control without an accessible name.** `aria-label` on every one.
- **No emoji as UI icons.** They render differently on every platform and can't be recolored.

---

## 7. Layout archetypes

SmartAvenue uses the following archetypes. Name the closest one before writing markup.

1. **Marketing home** — media hero, one discovery action, highlights/promotions, useful proof, CTA.
2. **Catalogue grid** — page hero, search/filter controls, results count, product-card grid.
3. **Product detail** — media gallery, product facts, price/availability, offer and store action.
4. **Offer feed/detail** — current offer cards or one offer with validity and conditions.
5. **Department grid** — visual category cards leading into filtered catalogue results.
6. **Guided AI flow** — focused questions, progress, catalogue-backed recommendations, review.
7. **Request form** — short visible-label form with clear expectation and confirmation.
8. **Content page** — readable editorial or policy content with minimal decoration.
9. **Admin workspace** — sidebar, dense forms/tables, status/save feedback, preview context.

**Responsive rule:** design phone-first for customers. Desktop may add columns or persistent admin
navigation, but must preserve route names, task order, and mental model.
