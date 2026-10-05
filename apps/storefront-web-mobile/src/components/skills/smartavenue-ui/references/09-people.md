# The people who use Smart Avenue 99

Read this before designing or scoring a screen. Smart Avenue is an offline retail store with an
online discovery catalogue. The UI must work for a wide Patna customer base, not only young,
English-fluent shoppers using expensive phones.

## 1. Core users

| Person | Context | Design consequence |
|---|---|---|
| **Everyday shopper** | Comparing low- and mid-priced goods on a phone | Show product, price, availability, department, and in-store next step without jargon |
| **Parent/caregiver** | One hand free, frequently interrupted | Keep actions large, preserve progress, avoid long flows |
| **Older shopper** | Larger text, lower contrast sensitivity, Hindi/Bhojpuri first | Use readable copy, strong contrast, predictable controls, and 200% zoom support |
| **Student/young shopper** | Fast scanning, budget- and offer-driven | Make search, filters, current offers, and prices fast to compare |
| **Gift shopper** | Uncertain what to buy | Ask simple questions, show why a product fits, and allow manual browsing |
| **Store visitor** | Checking the website while already near/in the shop | Surface location, store-only purchase model, current availability, and easy contact |
| **Catalogue staff** | Repeated desktop/mobile admin work | Favor dense but legible forms, keyboard support, clear save state, and accurate previews |
| **Store manager** | Reviewing requests, content, offers, and branding | Summaries must lead to actionable, auditable detail |

## 2. The retail environment is a constraint

| Condition | What it forces |
|---|---|
| **Bright outdoor light** | High contrast; no essential low-opacity gray text |
| **Budget Android device** | Phone-first layout, reserved image space, light animation, no heavy decorative effects |
| **Slow or unstable data** | Skeletons, retry, cached/stale explanation, preserved form input |
| **One-handed use** | 44–48px targets, primary actions in easy reach, no precision gestures |
| **Mixed language/literacy** | Short concrete labels, familiar product terms, icons that support rather than replace words |
| **Store-only purchase** | Repeatedly prevent delivery/checkout assumptions at decision points |
| **Changing stock and offers** | Make freshness, availability, dates, and uncertainty visible |

If the catalogue works only on a fast laptop, it does not work for the main customer.

## 3. Age and vision

- Use 11px only for non-essential metadata; meaningful text should normally be 15px or larger.
- Maintain WCAG 2.2 AA contrast and visible focus.
- Support 200% zoom without clipping or inaccessible controls.
- Do not rely on disappearing placeholders, hover-only actions, fast toasts, or hidden gestures.
- Make price and availability visually distinct and readable at a glance.
- Use predictable words such as “Products”, “Offers”, “Departments”, and “Request a product”.

## 4. Language and comprehension

- Use short sentences and concrete retail nouns.
- Explain unfamiliar AI behavior; never require the shopper to understand “model”, “prompt”, or
  “semantic search”.
- Support Hindi or other localized content with correct `lang` attributes when present.
- Format INR and dates through `Intl`; use Indian grouping.
- Design for labels that can grow by at least 40% after translation.
- Icons must reinforce labels, not become a private visual code.

## 5. Trust, privacy, and safety

- Never imply that a product is reserved, ordered, shipped, or delivered when it is not.
- Do not expose customer request details, phone numbers, or contact information outside the
  necessary staff context.
- Explain why optional personal information improves Genie recommendations.
- Avoid gendered recommendations unless the shopper explicitly requests them; preference, size,
  budget, occasion, and style are usually more useful.
- Do not manufacture urgency. Offers need real validity dates and conditions.
- Make report/contact/help routes easy to find when content or availability appears wrong.

## 6. Device and performance

- Assume 4–6GB RAM, a 320–375px viewport, and intermittent mobile data.
- Animate only properties that stay smooth; honor reduced motion.
- Reserve product image dimensions and use appropriately sized modern images.
- Avoid multiple autoplaying carousels, permanent compositor layers, and unnecessary polling.
- Preserve search/filter state on back navigation.
- Keep the catalogue useful even when an image is unavailable.

## 7. Staff-specific needs

- Exact product names, barcodes, prices, quantities, dates, and offer terms matter more than visual
  flourish.
- Forms need visible labels, error summaries, stable save behavior, and protection against losing
  changes.
- Tables must support keyboard navigation, clear sorting, and mobile alternatives.
- Preview storefront-impacting changes before publishing when the current flow supports it.
- Destructive actions name the exact item and require deliberate confirmation.

## 8. Four-person test

Before calling a surface finished, walk it as:

1. **A 58-year-old shopper:** budget Android, largest text setting, sunlight, Hindi first. Can they
   find the price, availability, store-only purchase rule, and next step?
2. **A busy parent:** one hand, interrupted mid-flow, slow network. Is their search/request
   preserved and can they recover from failure?
3. **A gift shopper:** unsure what to choose. Does Genie explain recommendations without inventing
   stock, delivery, or certainty, and can they switch to manual browsing?
4. **A catalogue administrator:** desktop, keyboard, long product names, exact barcodes and prices.
   Can they complete the task without ambiguity or accidental data loss?

If any one is blocked, the surface is not finished. The fastest usability test remains: hand the
screen to someone unfamiliar with it and do not coach them. Their confusion is evidence about the
interface, not about the person.
