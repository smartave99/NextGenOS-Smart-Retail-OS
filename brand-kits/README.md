# Brand kits

A **brand kit** is everything that makes the software look like one customer's own: a folder with a `brand.json` and a logo.
It holds no code and no secrets. The same kit gives the website, the Android app, the Windows programs' screens, receipts, labels
and posters the customer's name, colours and logo.

```
brand-kits/
  smart-avenue-99/      <- a customer of NextGenOS (the demo company)
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
