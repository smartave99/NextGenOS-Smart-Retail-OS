# Brand kits

A **brand kit** is everything that makes the software look like one customer's own: a folder with a `brand.json` and a logo.
It holds no code and no secrets. The same kit gives the website, the Android app, the Windows programs' screens, receipts, labels
and posters the customer's name, colours and logo.

```
brand-kits/
  example-shop/         <- NextGenOS's own neutral example: no company, no country, no address (the release builds from this unless told otherwise)
    brand.json
    logo.png
  smart-avenue-99/      <- a customer of NextGenOS; built into a release only when that customer's kit is chosen
    brand.json
    logo.png
```

Make or change a kit with the **Brand Studio** (see `docs/BRAND-STUDIO.md`); no coding is needed. How far a customer may change the
look on their own is decided by their licence (`white.level`: `none`, `theme` or `full`; see `licensing/spec/LICENCE-FORMAT.md`).

## brand.json (schema 1)

| Field | Meaning |
|---|---|
| `name`, `shortName`, `legalName` | The shop's name, a short form for small spaces, and the company's legal name |
| `tagline` | One line under the name |
| `primaryColor`, `accentColor` | `#rrggbb` colours |
| `theme` | `auto` (follows the device), `light` or `dark` |
| `logo` | The logo file in the same folder (PNG, JPEG or SVG) |
| `contact` | `email`, `phone`, `address` shown on the site, receipts and the app |
| `country`, `currency`, `language` | Country pack (for example `IN`, `PH`), currency code and language (`en-IN`, `en-PH`) |
| `storefront.siteUrl` | The public address of the customer's website |
| `android.appId`, `android.storefrontUrl` | The Android application id (`com.shopname.app`) and the website the app opens |
| `receipt.header`, `receipt.footer` | Extra lines on printed bills |
| `poweredBy` | Show "Powered by NextGenOS" (a `full` white-label licence may turn it off) |

## ai.json (optional, schema 1)

What the AI assistant's pictures and posters need to know about this customer: the country's name, the kind of business, who the three model photos show, the festivals of its shoppers and the second language of its posters (with ready-made lines). It is plain data of the same format the Setup Studio writes (see `docs/SETUP-STUDIO.md`, "The AI assistant's own settings"), and the program reads it from `profile\ai.json` beside the AI assistant's setup. With none, the assistant is neutral. It holds no secrets.

## chat-words.json and campaigns.json (optional, schema 1)

What the assistant recognises in the owner's own words, and the campaign plans the owner can start from. The program itself holds English only, with no language, currency or trade written into it (`CLAUDE.md`, section 8); the words of this customer's language, money and trade, and its own campaign templates, are plain data here. Both are read from `profile\` beside the AI assistant's setup, like `ai.json`. With none, the assistant still works in plain English and offers one neutral campaign plan. Neither holds a secret, a price or a promised result.

- `chat-words.json`: `{"schema": 1, "words": {...}}` with lists named `figures`, `asksForFigures`, `advice`, `work`, `continue`, `recall`, `money`, `limits`, `topics`, `wishes`. Words are plain text matched as whole words, never patterns (`apps/pos-ai-companion/src/SmartRetail.AI.Core/Assistant/ChatVocabulary.cs`).
- `campaigns.json`: `{"schema": 1, "templates": [{"id", "name", "channel", "summary", "days", "steps": [{"title", "afterDays", "detail"}], "signs": [...]}]}`; `afterDays` counts from the first day (before it is negative) (`.../Work/CampaignTemplates.cs`).

*Not yet carried by the Setup Studio or the AI add-on's setup program, which copy `ai.json` only: until they do, copy these two files into `profile\` next to `ai.json` by hand (`docs/OPEN-WORK.md`).*

