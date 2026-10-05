# Country packs

Every country has its own money, taxes, invoices and languages. NextGenOS keeps all of it in **one small file per country** (`packs/IN.json` for
India, `packs/PH.json` for the Philippines, and so on) instead of in program code. To sell to a shop in a new country you add a file; nobody changes a program.

This page is for the people who set customers up. Programmers: the full specification is `SPEC.md`.

## What is ready

Run `node country-packs/tools/cli.mjs list` to see every country. **No pack has yet been signed off by a local accountant.** Every pack was written from public knowledge of the law on the day in its `asOf` field; none was
checked by an adviser in that country, and nobody at NextGenOS has checked them against the tax office's own pages. Tax law changes.

* **India and the Philippines** are the most detailed packs (India: all state codes, the 2025 GST slabs, the old rates kept for old bills; the Philippines:
  VAT, senior citizen and disability discounts, the non-VAT shop). They are the first the product is built for.
* **All other packs** are starters: rates and invoice notes only.

Before the first real bill in any country the shop's accountant must confirm the pack, and their name is written in with the `review` command below.
Until then `list` shows "starter (not reviewed by a local adviser)" and the programs say so in Settings.

## Set up a shop in a country that has a pack

1. Open the shop's `.env` (the website) and set `NEXT_PUBLIC_COUNTRY=PH` (the two letters of the country). Optionally `NEXT_PUBLIC_SHOP_PLACE="Cebu City, Philippines"`.
2. The currency, the way numbers and dates are written, the language of the AI assistant and the tax words all follow from that.
3. In the Business Hub the same choice is made in *Settings → Shop → Country* during the first-run wizard.

## Add a country that has no pack yet

```
node country-packs/tools/cli.mjs new ZZ --name "Zedland" --currency ZZD --symbol "Z$" --tax VAT --rate 15
```

This writes `packs/ZZ.json` from a template. Open it and check every line against the tax office's website: the rates, the name of the tax, what an invoice must
show, the currency's symbol and decimals. Then:

```
node country-packs/tools/cli.mjs validate     # the tool says in plain words what is wrong
node country-packs/tools/cli.mjs vectors      # rebuilds the test cases
node country-packs/tools/cli.mjs sync         # copies the pack to the website
```

## After the accountant has checked it

```
node country-packs/tools/cli.mjs review PH --by "A. Reyes, Reyes & Co CPAs" --on 2026-11-02 --notes "Checked against BIR RR 16-2005 as amended"
```

The pack then shows the adviser's name instead of "starter".

## When a rate changes

Edit the rate in the pack, change `asOf` to today, clear `review` (set it to `null`) until the adviser has seen the change, and run `validate`, `vectors`, `sync`.
Old rates that are still on old bills stay in the file marked `"legacy": true`: programs hide them from new choices but still read old bills correctly.
A shop that must change one rate for itself (a special local rate, a US county) does it in its own settings; the pack file is never edited on a customer's PC.

## How the pieces fit

* `packs/` is the only place where country rules are written.
* `tools/reference.mjs` is a small, independent calculator. It makes `vectors/tax-vectors.json` (62 sample bills and 23 ways of writing money).
* The C# engine (`libs/dotnet/NextGenOS.Tax`, for Windows programs and the Business Hub) and the TypeScript engine (`apps/storefront-web-mobile/src/lib/region`, for the
  website and the Android app) must give the **same answer to the last cent** on every sample. The release check (`node scripts/verify-all.mjs --full`) runs both.
