# Country packs and the tax engine (specification, version 1)

A **country pack** is one JSON file (`packs/<ISO-3166 alpha-2>.json`) that tells every NextGenOS product how a country
works: its money, language, tax rules and invoice requirements. Nothing about a country is written in program code. To
support a new country you add a file, you do not change a program.

The **tax engine** turns bill lines and a pack into money. It exists twice, in C# (`libs/dotnet/NextGenOS.Tax`, for the
Windows programs) and in TypeScript (`apps/storefront-web-mobile/src/lib/region`, for the web and the Android app), and both
must give **exactly** the same answer to the last unit of currency. `vectors/tax-vectors.json` is the contract: each
implementation runs every vector and must match. The vectors are produced by an independent reference
(`tools/reference.mjs`). Changing a rule means: change this file, change the reference, regenerate the vectors
(`node country-packs/tools/cli.mjs vectors`), and make C# and TypeScript pass before you finish.

## 1. Honesty about tax law

Tax law changes. A pack records the day it was written (`asOf`) and whether a local adviser has checked it (`review`). A pack with
`review: null` is a **starter**: its rates are the best public knowledge on `asOf`, and the shop's accountant must confirm
them before the first bill. The programs show this on the Settings page. A shop can always change a rate for itself (section 8).

## 2. Files

```
country-packs/
  packs/IN.json PH.json ...      one file per country (source of truth)
  schema/pack.schema.json        JSON Schema, for editors and for the validator
  vectors/tax-vectors.json       the engine contract (generated)
  tools/cli.mjs                  validate | list | new | review | vectors | sync
  tools/reference.mjs            exact reference implementation (BigInt integers)
```

`cli.mjs sync` copies the packs and vectors where the programs need them (the storefront); the release gate fails when a copy is stale.

## 3. Pack format

```jsonc
{
  "schema": 1,
  "country": "IN",                       // ISO 3166-1 alpha-2, upper case, equals the file name
  "name": "India",
  "asOf": "2026-10-05",                  // the day the rules were written down
  "review": null,                        // or { "by": "Name, firm", "on": "2026-10-20", "notes": "" }
  "currency": {
    "code": "INR", "symbol": "₹", "decimals": 2,
    "symbolPosition": "before",          // "before" | "after"
    "symbolSpace": false,                // a space between the symbol and the number
    "grouping": "indian",                // "indian" (12,34,567.89) | "standard" (1,234,567.89) | "none"
    "decimalSeparator": ".",             // "." or ","
    "groupSeparator": ","                // "," or "." or a (non-breaking) space
  },
  "locale": "en-IN",                     // BCP 47, for dates and names of months
  "languages": ["en", "hi"],             // the languages the programs offer first
  "timezone": "Asia/Kolkata",
  "phoneCode": "+91",
  "fiscalYearStart": { "month": 4, "day": 1 },
  "units": { "weight": "kg", "length": "cm" },
  "tax": {
    "name": "GST",                       // what the country calls it
    "model": "gst-india",                // "gst-india" | "vat" | "regional" | "none"   (section 5)
    "pricesIncludeTaxDefault": true,     // do shelf prices already include the tax?
    "rates": [ { "code": "GST18", "label": "GST 18%", "percent": "18" } ],   // section 4
    "classes": { "standard": "GST18", "reduced": "GST5", "zero": "GST0", "exempt": "GSTEX" },   // section 4, "tax classes"
    "regions": { "label": "State", "list": [ { "code": "27", "name": "Maharashtra" } ] },
    "businessId": { "label": "GSTIN", "pattern": "^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z][1-9A-Z]Z[0-9A-Z]$" },
    "customerDiscounts": [ ],            // section 6
    "rounding": { "total": "nearest", "increment": "1", "defaultOn": false }   // section 7
  },
  "invoice": {
    "title": "Tax Invoice",
    "requiredFields": [ "Seller name and address", "GSTIN" ],
    "eInvoice": "short note on electronic invoicing duties, or null",
    "retentionYears": 8
  },
  "notes": [ "anything a reader should know" ]
}
```

## 4. Rates

`rates[]` are the tax codes a product can carry. Each has a `code` (letters and digits), a `label` for people, and either
`percent` (a decimal string with at most 3 decimals, `"7.5"`) or `exempt: true` / `zero: true`:

* `percent` – taxed at that percent.
* `zero: true` – taxable at 0 % (the seller may reclaim input tax; shown on invoices as a taxable sale at 0).
* `exempt: true` – outside the tax (shown as exempt sales). The engine treats it as 0 % and reports it in `exemptSales`.
* `legacy: true` – an old rate that is no longer sold but is still found on old stock and old bills. Programs hide it from new choices.

For `model: "regional"` a rate has no percent of its own: it is `"taxable": true` and the percent comes from the region (section 5).
A region lists `components: [ { "name": "GST", "percent": "5" }, { "name": "PST", "percent": "7" } ]`; a component with `"editable": true`
is one the shop sets itself (for example a combined sales tax that depends on the street the shop is in).

**Tax classes.** Shop staff should not have to know rate codes. A pack names four everyday classes and the rate code each one means:
`standard` (the main rate), `reduced` (the usual lower rate, if the country has one), `zero` and `exempt`. Products carry a class or a code; demo data and
product import use classes. Each class names a code that exists in `rates`; `standard` is required.

## 5. Models

All money is worked in **minor units** (the smallest unit of the currency: paise, centavos, cents; `decimals` says how many
digits). All percents are worked in **milli-percent** (`"7.5"` is 7500; `"0.25"` is 250). Quantity is worked in thousandths.
Rounding is always `round half up` of a non-negative integer ratio, written `R(a, b)` = `floor((2a + b) / (2b))`.

Inputs:

```
context: { pricesIncludeTax: bool, sellerRegion?: code, buyerRegion?: code, registered?: bool (default true),
           roundTotal?: bool (default pack.tax.rounding.defaultOn) }
line:    { name?, qty: "2.5", unitPrice: "199.50", discountPercent?: "10", discountAmount?: "5.00",
           taxCode: "GST18", cessPercent?: "12", customerDiscount?: "SENIOR" }
```

**Per line** (`Q` = quantity in thousandths, `P` = unit price in minor units, `r` = rate in milli-percent, `c` = cess in milli-percent):

1. `gross = R(Q × P, 1000)`.
2. `discount` = `discountAmount` in minor units if given, else `R(gross × discountMilli, 100000)` where `discountMilli` = discountPercent × 1000. Clamp to `[0, gross]`. `net = gross − discount`.
3. If the seller is not `registered`, or the code is `exempt` or `zero`: `r = 0` and `c = 0` (an unregistered seller charges no tax).
4. **Customer discount** (section 6), when the line has one: handled first, and the tax steps below are skipped.
5. Taxable value:
   * prices include tax: `taxable = R(net × 100000, 100000 + r + c)`; `taxTotal = net − taxable`.
   * prices do not include tax: `taxable = net`.
6. Cess: `cess = R(taxable × c, 100000)` (inclusive: this is carved out of `taxTotal`, the rest is the main tax `tax = taxTotal − cess`;
   exclusive: `tax` is worked below, and the cess is added on top).
7. Main tax split by model:
   * `vat` (one component, named by the rate's component name, default the pack's `tax.name`):
     exclusive `tax = R(taxable × r, 100000)`.
   * `gst-india`: when `buyerRegion` is absent or equals `sellerRegion` the supply is **intra-state**: components CGST and SGST.
     Inclusive: `CGST = R(tax, 2)`, `SGST = tax − CGST`. Exclusive: `CGST = R(taxable × r, 200000)`, `SGST = CGST`.
     Otherwise **inter-state**: one component IGST = `tax` (exclusive: `R(taxable × r, 100000)`).
   * `regional`: `r` is the sum of the region's component percents (if `r` is 0 every component is 0). Exclusive: every component but the last is `R(taxable × pᵢ, 100000)`;
     the last is `R(taxable × r, 100000) − (sum of the others)`. Inclusive: `tax` is known (step 5); every component but the last is
     `R(tax × pᵢ, r)`; the last is `tax` minus the others. The region is `buyerRegion`, else `sellerRegion`.
   * `none`: no tax.
   Exclusive: `tax` = sum of the components.
8. `lineTotal = taxable + tax + cess` (inclusive: equals `net` exactly).

**Totals:** sums of every field; `subTotal = Σ lineTotal`. If `roundTotal` and the pack rounds totals:
`grandTotal = R(subTotal, inc) × inc` (`inc` = increment in minor units), `roundOff = grandTotal − subTotal`; else `grandTotal = subTotal`, `roundOff = 0`.

**Exempt amount of a line** (`exemptAmount`): if the line's customer discount is `vatExempt`: `base` (section 6); else if the code is `exempt`: `taxable`; else 0.
`totals.exemptSales = Σ exemptAmount`.

**By code:** `byCode[]` sums `taxable`, each component and `cess` per tax code, in order of first appearance.

## 6. Customer discounts (for example Philippines: senior citizen and person with disability)

A pack lists `customerDiscounts[]`: `{ "code": "SENIOR", "label": "Senior citizen", "percent": "20", "vatExempt": true, "law": "..." }`.
The program decides which lines qualify (the law covers certain goods only) and marks them with `customerDiscount`. For such a line:

* `base` = prices include tax: `R(net × 100000, 100000 + r)`; else `net`. (The sale is first worked out without the tax.)
* `customerDiscount = R(base × percent × 1000, 100000)`.
* If `vatExempt`: `taxable = 0`, no tax, `exemptAmount = base`, `lineTotal = base − customerDiscount`.
  If not `vatExempt`: the discount comes off `base`, the tax is then charged on `base − customerDiscount` as in step 5/7 with prices not including tax,
  and `lineTotal` is the sum.

## 7. Rounding of the total

`"rounding": { "total": "nearest" | "none", "increment": "0.05", "defaultOn": true }`. Many countries round cash totals to the nearest 5 cents;
the shop switches it on or off (`roundTotal`); `defaultOn` is the pack's default.

## 8. A shop's own rates

A shop may change a rate or add a code in its own settings file (`rates` override by `code`). The engine receives the merged pack; a changed rate
is shown with a mark on invoices. The pack file itself is never edited in a customer's copy.

## 9. Document adjustments (service charge, tip, retention, advance, fee)

Businesses other than a plain shop add amounts that are not goods: a restaurant's service charge and tip, a builder's retention
and advance, a library's fine. They are **adjustments** of the whole document, given after the lines:

```
adjustment: { code: "SVC", kind: "surcharge" | "fee" | "tip" | "retention" | "advance", label?: "Service charge",
              percent?: "10", amount?: "50.00",           // one of the two (percent of the base, or a fixed amount)
              base?: "taxable" | "subTotal",              // for a percent: of what (default "taxable": the lines' value before tax)
              taxCode?: "VAT20" }                         // surcharge and fee only: tax charged on it (omit: untaxed)
```

* `surcharge` (service charge) and `fee` (fine, delivery): `amount = percent ? R(baseValue × percentMilli, 100000) : fixed`. If `taxCode` is given it is taxed
  like an extra line **not including tax** (steps 5 and 7 with `net = amount`) and joins the totals and `byCode`. It is added **before** the rounding of the total.
* `tip`: a fixed `amount`, never taxed, never rounded; added after the rounding of the total.
* `advance`: a fixed `amount` already paid; taken off what is payable.
* `retention`: a percent withheld from what is payable now (builders hold back 5 or 10 percent until the work is signed off).
  `retention = R(baseValue × percentMilli, 100000)` with `base` default `"taxable"` (the value of the work before tax: the tax is charged in full on the invoice).

`baseValue` is worked from the **lines only** (adjustments never compound on each other): `Σ taxable` of the lines when `base` is `"taxable"`, `Σ lineTotal` when `"subTotal"`.

Result: `totals.subTotal` = `Σ lineTotal` + the total (amount plus its tax) of every surcharge and fee; `totals.taxable`, the components and `byCode` include the taxed ones.
`totals.grandTotal` is `subTotal` rounded as in section 7. Then
`payable = grandTotal + Σ tips − Σ advances − Σ retention` (never below zero: a negative result is shown as `0.00` and the excess in `credit`).
The output lists every adjustment with its `amount` (and, when taxed, its `taxable` and `components`).

## 10. Output

```
{ lines: [ { gross, discount, taxable, components: [ { name, amount } ], cess, customerDiscount, exemptAmount, lineTotal } ],
  adjustments: [ { code, kind, label, amount, taxable, components: [ { name, amount } ] } ],
  totals: { gross, discount, taxable, components: [ { name, amount } ], cess, customerDiscount, exemptSales, subTotal, roundOff, grandTotal,
            tips, advances, retention, payable, credit },
  byCode: [ { code, percent, taxable, components: [ { name, amount } ], cess } ] }
```

All amounts are **strings in major units with exactly `decimals` digits** (`"1234.50"`), so no program can lose a digit to floating point.
Components keep the order of the model (CGST, SGST / IGST / the regional order). A component that is zero is kept (so tables line up).
