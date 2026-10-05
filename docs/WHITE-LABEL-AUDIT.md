# What is still fixed in code (white-label audit)

Rule: `CLAUDE.md`, section 8. **Nothing a customer sees may be fixed in program code.** This page says where that is not yet true, in plain words. It is kept honest by
`node scripts/white-label-audit.mjs` (in the gate as `white-label`): it counts the fixed spots it can recognise, per file, and **fails when any file gets more**. The list only
shrinks. `node scripts/white-label-audit.mjs --report` prints the current table; `--update` locks in an improvement.

A passing check means *nothing new is fixed*. It does **not** mean nothing is fixed: the audit only recognises certain words (India, Hindi, rupees, Indian tax words, festival
names, a company's name, a default country, a picture built into a program), and it ignores comments, tests, documents, packs and brand kits (those are data).

## State by program

| Program | What is fixed today | Plan |
|---|---|---|
| **Business Hub** (Windows and Linux) | The audit finds **nothing**. No country is chosen for the owner (set-up asks, or the customer's prepared profile names it). The sample company needs a named country. | Keep it at zero. Remaining gaps the audit cannot see are listed below. |
| **Setup Studio** | Nothing: every customer-facing value is in the intake and the proposal. | Add the `images` part (below). |
| **AI add-on: product photos** (`pos-ai-companion`) | The set of five photos (white background, in use, European model, Indian model, East Asian model), the look of the people, "a typical place in India", the Hindi name, English-and-Hindi wording. | Task 25: make it a setting from the profile (`images.json`), neutral by default. |
| **AI add-on: posters and creatives** (`pos-dashboard-service`, `pos-ai-companion`) | "a small shop in India", English headline plus a Hindi line, Indian festival offers, rupee and GST wording in the prompts. The shop's own name, colours, notes and logo are already per shop. | Task 25: festivals, language, place and money wording from the profile and the country pack. |
| **Windows desktop POS (the older VB program)** | Built for Indian GST billing: GST words, rupees and WhatsApp flows throughout (thousands of spots), and two pictures built in (a storefront and an empty bag, in one blue palette) shown at start-up, sign-in and an empty basket. | The Business Hub is the program that sells everywhere. The older POS stays for existing Indian shops; its pictures and company name move to the brand kit, its country-specific parts are not made global. Said plainly to buyers. |
| **Website** (`storefront-web-mobile`) | A few default country and rupee spots in its region helpers; Hindi in its AI settings. | Move to the brand kit and country pack. |
| **Android app** | Takes name, colours, logo and web address from the brand kit (built by the release workflow). | Keep. |

## Gaps the audit cannot see

- **The Hub's own wording is English.** The words for things (customer, item, sale ...) are settable per customer, but sentences such as "Nothing added yet." are in English only. A language setting needs the screens' text moved into language files.
- **Default words** such as the bill footer "Thank you!" are English.
- **Pictures made by the AI** follow the customer only after task 25.

Each of these gets a line here when found, and is removed only when a test shows that changing the setting changes the result.
