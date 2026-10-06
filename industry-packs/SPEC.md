# Industry packs (specification, version 1)

A **country pack** says how a *country* works. An **industry pack** says how a *kind of business* works: what its screens call things, which parts of the
Business Hub it needs, its everyday rules (how long a library book may be kept, how much a builder holds back) and some sample data. Nothing about a kind
of business is written in program code: a new kind of business is a new file.

An industry pack never contains tax or money rules of a country; those come from the country pack. The two are chosen separately: a restaurant in the
Philippines is `restaurant` + `PH`.

## 1. Honesty about what a pack does

Every pack lists `coverage.works` (what this version really does, tested) and `coverage.notYet` (what it does not). The Hub shows both lists in the
set-up wizard and in Settings, so a customer is told before they buy and after they set up. Never put a feature in `works` that has no test.

## 2. Format

```jsonc
{
  "schema": 1,
  "id": "restaurant",                    // letters, digits and dashes; equals the file name
  "name": "Restaurant, café and food service",
  "summary": "one sentence for the set-up wizard",
  "icon": "utensils",                    // a name from the Hub's icon set
  "vocabulary": {                        // [singular, plural] for every term the screens use
    "customer": ["Guest", "Guests"], "item": ["Menu item", "Menu items"], "sale": ["Order", "Orders"], "invoice": ["Bill", "Bills"],
    "staff": ["Server", "Servers"], "supplier": ["Supplier", "Suppliers"], "stock": ["Stock", "Stock"]
  },
  "features": {                          // which parts of the Hub are on (the owner can change them in Settings)
    "counterSale": true, "tables": true, "kitchen": true, "lending": false, "projects": false, "appointments": false,
    "credit": false, "purchases": true, "weighedItems": false, "stockTracking": "optional"      // "always" | "optional" | "never"
  },
  "itemKinds":  [ { "id": "menu", "label": "Menu item", "tracksStock": false } ],
  "partyKinds": [ { "id": "customer", "label": "Guest" } ],
  "defaults": {
    "adjustments": [ { "code": "SVC", "kind": "surcharge", "label": "Service charge", "percent": "10", "taxed": true, "optional": true } ],   // country-packs/SPEC.md section 9
    "paymentMethods": ["cash", "card", "wallet", "bank"]
  },
  "rules": { },                          // rules of the trade, see section 3
  "reports": [ "daily-sales", "top-items" ],   // report ids the Hub knows
  "demo": { },                           // sample company, section 4
  "aiContext": "a restaurant or café: tables, orders ...",   // one phrase the AI assistants use to describe the business
  "coverage": { "works": [ "..." ], "notYet": [ "..." ] }
}
```

`taxed` on a default adjustment means it is charged tax (the Hub gives it the country's `standard` class). `optional` means the cashier may switch it off for a bill.

## 3. Rules by trade

* `retail`: `returnDays`, `lowStockDefault`.
* `restaurant`: `stations` (names of kitchen screens), `tipPresets` (percents), `splitBill`.
* `library`: `memberTypes` (`id`, `label`, `loanDays`, `maxLoans`), `renewals`, `graceDays`, `finePerDay` and `fineCap` (amounts in the shop's currency; `"0.00"` is no cap),
  `reservationHoldDays`, `lostItemFeeMultiplier` (× the item's price).
* `construction`: `retentionPercent`, `retentionBase` (`"taxable"` or `"subTotal"`), `paymentTermsDays`, `quoteValidDays`, `costKinds`, `advancePercent`.
* `services`: `slotMinutes`, `openFrom`, `openTo`, `closedWeekdays` (0 is Sunday), `walkIns`.
* `wholesale`: `creditDays`, `tradePriceLabel`, `priceLevels`.
* `generic`: `creditDays`.

## 4. Demo company

`demo.company` and `demo.tagline` name a fictional business. `demo.items` list what it sells: `name`, `kind` (one of the pack's `itemKinds`), `category`, `price` (a decimal in
the shop's currency; sample numbers are written as if for rupees and rounded to the currency's decimals), `class` (`standard`, `reduced`, `zero` or `exempt`: resolved through the
country pack's `tax.classes`), `unit`, `stock`, `barcode`, and trade-specific extras (`station`, `author`, `isbn`, `copies`, `duration`, `tradePrice`). `demo.parties`,
`demo.tables` and `demo.projects` fill the other parts. The Hub's `demo` command builds a company from this, so every industry can be shown and tested end to end.

## 5. Files

```
industry-packs/
  packs/*.json            one file per kind of business (source of truth)
  tools/cli.mjs           validate | list | sync | check
  tools/validate.mjs
```

`cli.mjs sync` copies the vocabulary to the storefront (`apps/storefront-web-mobile/src/lib/industry/generated`) and the packs are built into the Hub from `packs/`.
