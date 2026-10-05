# Smart Retail POS Business Hub

The part of the **Smart Retail AI Ecosystem** that runs *any* kind of business: a shop, a café or restaurant, a library, a building contractor, a salon or clinic, a wholesaler, or anything else. It runs on the shop's own PC and is opened in a browser. It is NextGenOS's proprietary software (see `LICENSE`); it starts only with a valid signed licence that includes the `hub` module.

## What it does today (tested)

| Kind of business | Screens and workflows | Tested in a real browser |
|---|---|---|
| Retail store | Counter sale with barcode scanning, weighed items, returns (credit notes), stock, suppliers and purchase orders, daily reports | `e2e/retail.e2e.mjs` |
| Restaurant / café | Tables, orders, kitchen screen by station, service charge, tips, split bills, takeaway | `e2e/restaurant.e2e.mjs` |
| Library | Members with cards, titles with copies, lend / return / renew, fines, reservations | `e2e/library.e2e.mjs` |
| Construction | Projects, bill of quantities, quotes, progress bills with retention and advance recovery, costs, changes to the contract, payments | `e2e/construction.e2e.mjs` |
| Salon / services | Bookings by staff with free times, walk-ins, charging a visit with products and a tip, staff sales | `e2e/services.e2e.mjs` |
| Wholesale | Trade prices, credit sales with limits, part payments, what is owed, buying stock | `e2e/wholesale.e2e.mjs` |
| Any other business | Items, parties, invoices, payments; switch on only the parts you need and rename the words | `e2e/foundation.e2e.mjs` |

Money and tax come from the **country packs** (`country-packs/`, 33 countries) through the same integer tax engine the other NextGenOS programs use; the words, screens and rules of each business come from the **industry packs** (`industry-packs/`). Each industry pack lists, in plain words, what works and what is not built yet (`coverage`); the setup wizard shows that list to the person choosing.

## What it does not do yet

- Printing straight to receipt printers and label printers (today: print from the browser; the Device Hub is separate work).
- Several shops in one database, or syncing between PCs.
- The tax rules of any country have **not been checked by a local tax adviser**: the Hub says so on the setup, tax and report screens.
- The Windows POS desktop program and the dashboard are separate programs and remain India-GST editions.

## Run it (developers)

```
dotnet run --project apps/business-hub/src/NextGenOS.Hub.Web      # http://127.0.0.1:5280, needs a licence with the hub module
```

Data lives in one SQLite file per shop (`shop.db`) in the data folder (`Hub:DataFolder`; default `%ProgramData%\NextGenOS\Hub` on Windows). The program listens on `127.0.0.1` only. If you expose it on a network, finish the first-run setup on the shop PC first and put it behind HTTPS.

## Test it

```
dotnet test apps/business-hub/NextGenOS.Hub.slnx                   # domain tests (every industry, every country) and web tests
node apps/business-hub/e2e/hub.e2e.mjs                             # real browser, after: cd apps/business-hub/e2e && npm install
node scripts/verify-all.mjs --only hub-enforcement,dotnet-hub,hub-e2e
```

The browser tests start `tests/NextGenOS.Hub.E2EHost`, which builds the Hub exactly as the program does but stands in for the licence (as the licence gate tests do). That host is a test tool: it is never packaged, and the Hub program itself has **no** switch, setting or environment variable that skips the licence.

## Layout

- `src/NextGenOS.Hub.Core` — the domain: settings, catalogue, documents with the tax engine, restaurant, library, projects, appointments, purchasing, reports, the demo company builder.
- `src/NextGenOS.Hub.Web` — the Blazor program: licence gate, sign-in, setup wizard, screens.
- `tests/` — domain tests, web tests, and the browser-test host.
- `e2e/` — browser tests (Playwright).

## Demo company

`DemoCompany.Fill(dbPath, new DemoOptions { Industry, Country })` makes a sample business from the industry pack (items, people, tables, projects, bookings and two weeks of trading) through the same services the screens use. The setup wizard offers it with a plain warning that it cannot be taken out later.
