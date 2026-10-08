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
| **Setup Studio** | Nothing: every customer-facing value is in the intake and the proposal. The AI assistant's own settings (country, kind of business, who the model photos show, festivals, second language and its ready-made poster lines) are the intake's optional `images` part, checked by the same rules as the program reads them, and written as `profile/ai.json` into the customer pack. Nothing is suggested from code: the country and industry packs carry no festivals and no looks of people, so those are typed. | Keep it at zero. |
| **AI add-on: product photos** (`pos-ai-companion`) | Read from the customer's profile (`profile/ai.json`) and neutral without one: who the three model photos show and what they are called, the typical place, the country, the second language's name. **Still fixed (the audit counts them):** Hindi and rupee wording in the product listing text (`ProductListing.cs`) and a few other spots in this program. The first customer's old values live in its brand kit as `ai.json`. | Move the listing wording to the profile and the country pack. |
| **AI add-on: posters and creatives** (`pos-dashboard-service`, `pos-ai-companion`) | The business and country in the prompts, the festivals, the second language and its ready-made lines are read from the same profile and neutral without one. The shop's own name, colours, notes and logo are per shop. **Still fixed (the audit counts them):** rupee and Hindi words in some prompts and screens (for example `CreativeArt.cs`, `PosterPrompt.cs`, `Plan.razor`, `GrowthPlanPrompt.cs`, `MemoryReview.cs`, the money formats in `Formats.cs`) and India wording in the dashboard's checks (`ActionMeasure.cs`, `ShopChecks.cs`, `FindingTimes.cs`). | Money wording from the country pack; the rest from the profile. |
| **Windows desktop POS (the older VB program)** | Built for Indian GST billing: GST words, rupees and WhatsApp flows throughout (thousands of spots), and two pictures built in (a storefront and an empty bag, in one blue palette) shown at start-up, sign-in and an empty basket. | The Business Hub is the program that sells everywhere. The older POS stays for existing Indian shops; its pictures and company name move to the brand kit, its country-specific parts are not made global. Said plainly to buyers. |
| **Website** (`storefront-web-mobile`) | One program for every customer: the name, address, country and money, kind of business, language, colours, contact lines, logo and the public Supabase, Firebase and Cloudinary values are read when it starts from the customer's folder, and are neutral without one (no default country, currency, kind of shop, Hindi or company). **Still fixed:** the Live shop's words and function names are written for rupees (`rupees()` in `lib/live-shop/format.ts` uses the customer's currency but is named for one), the picture kind "Indian model" in `lib/live-shop/shop-products.ts`, the English wording of the pages, and the built-in neutral logo and icons (`public/logo.png`, `src/app/icon.png`: replaceable by the customer's logo for the logo, not yet for the browser icons). | Rename the Live shop's helpers; let the customer's folder carry the browser icons and the wording. |
| **Android app** | Takes name, colours, logo and web address from the brand kit (built by the release workflow). | Keep. |

## Gaps the audit cannot see

- **The Hub's own wording is English.** The words for things (customer, item, sale ...) are settable per customer, but sentences such as "Nothing added yet." are in English only. A language setting needs the screens' text moved into language files.
- **Default words** such as the bill footer "Thank you!" are English.
- **Pictures and posters made by the AI** follow the customer's profile for what the rows above say they read. Whether a description gives good, fitting pictures cannot be checked by a program; a person tries a few products at the first visit.

Each of these gets a line here when found, and is removed only when a test shows that changing the setting changes the result.
