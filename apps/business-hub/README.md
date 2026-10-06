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

Money and tax come from the **country packs** (`country-packs/`, 34 countries) through the same integer tax engine the other NextGenOS programs use; the words, screens and rules of each business come from the **industry packs** (`industry-packs/`). Each industry pack lists, in plain words, what works and what is not built yet (`coverage`); the setup wizard shows that list to the person choosing.

## What it does not do yet

- Printing on receipt printers and label printers is built and tested against stand-in printers on this PC; it has **not** been tried on real printers (see Devices below).
- Several shops in one database, or syncing between PCs.
- The tax rules of any country have **not been checked by a local tax adviser**: the Hub says so on the setup, tax and report screens.
- The Windows POS desktop program and the dashboard are separate programs and remain India-GST editions.

## AI helpers (optional, off until the owner switches them on)

*Settings → AI helpers* (owner only; needs the `ai` part in the licence) is the start of Version 2 (`docs/VERSION-2.md`). The shop **works in full without any of it**: the shop's own screens never call an AI service, and nothing is downloaded, started or sent anywhere until the owner connects a service and allows it.

What is there: eight switches (all off); a description of the computer and what it can run; AI services (on this computer, on the shop's network, or an online account) with a **Test** button, limits (requests a day, tokens and spending a month) and a record of every use; the kinds of data each service may receive (card details and biometric data **never** leave this computer, whatever is allowed); keys kept in the Windows Credential Manager or an encrypted file, never in the database; a list of models that move from candidate through testing to in use, with a way back. What is not there yet, and the details: `docs/V2-ARCHITECTURE-ASSESSMENT.md`, section 6.

## Devices

`libs/dotnet/NextGenOS.Devices` speaks the languages of shop printers: **ESC/POS** (nearly every receipt printer), **ZPL**, **TSPL**, **EPL** and **CPCL** (label printers), and reaches them over the **network** (port 9100), a **serial or Bluetooth port**, a **USB device file**, the **system print queue (CUPS)** or the **Windows spooler** (raw). Letters a printer's character set lacks (other alphabets, Chinese, Japanese, Korean) are printed as pictures; receipt currency signs it cannot write are spelled (₹ as Rs). Scanners: USB and Bluetooth scanners that type like a keyboard work in every box; any camera (phone, tablet, webcam) reads barcodes through the browser or, where the browser cannot, through the Hub. Price tags and posters (shelf labels, A4 and A3) print from the browser to any printer. Set it all up in **Settings → Printers**.

Tested: the encoders byte by byte, the transports against a stand-in network printer, a stand-in print command and device files, the camera path in a real browser with a fake camera showing a barcode. **Not tested here: real printers, real Bluetooth or USB hardware, the Windows spooler** — so test each make of printer you sell once, and say so in the sales material.

## Look and brand

The program wears the customer's brand from their licence. In **Settings → Look** the owner changes colours, the logo and the help details (and, with a `full` licence, the program's name) **only as far as the licence's white-label level allows**; a look file made with the Brand Studio can be loaded there. See `docs/BRAND-STUDIO.md` and `licensing/spec/LICENCE-FORMAT.md` section 5.2.

## Install on Windows

`installer/build.mjs` makes the setup (`node apps/business-hub/installer/build.mjs --version 1.0.0`): it publishes the Hub as one self-contained folder, hides the names in our programs (`scripts/protect-dotnet.mjs`), audits the folder (`scripts/audit-package.mjs`), and writes the NSIS setup and a zip. The setup installs a Windows service (`NextGenOSHub`, Local Service account, starts with the PC, restarts after a crash) that listens on `127.0.0.1:5280` only, keeps the shop's data in `%ProgramData%\NextGenOS\Hub` (readable only by the service and administrators), and **never removes that data** on uninstall. The Start menu entry and the desktop icon open the Hub in a window of its own (Microsoft Edge in app mode, no address bar, no terminal); closing that window leaves the service running, on purpose. The plain zip of the same folder (`SmartRetailPOS-Hub-<version>-win-x64.zip`, for a person who sets things up by hand) carries **Start Business Hub** beside the program: a small hidden launcher (`installer/zip-launcher.mjs`, made by `scripts/lib/build-launcher.mjs`) that starts the Hub in the background once and opens the same window, so double-clicking `NextGenOS.Hub.exe` (which would show a black window) is never the way in; its `READ ME FIRST.txt` says the setup is the normal way. `installer/test-installer.sh` runs the setup under Wine with a stand-in program (install, update, uninstall). The release workflow builds it on a real Windows machine, installs it, checks the service and uninstalls it. How to make a release: `docs/RELEASE-GUIDE.md`; what the protection does and does not do: `docs/SECURITY-MODEL.md`.

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
node scripts/verify-all.mjs --full --only hub-release,hub-protected-e2e,hub-installer   # the shipped build: protected, audited, run with a real licence, installed
```

The browser tests start `tests/NextGenOS.Hub.E2EHost`, which builds the Hub exactly as the program does but stands in for the licence (as the licence gate tests do). That host is a test tool: it is never packaged, and the Hub program itself has **no** switch, setting or environment variable that skips the licence.

## Layout

- `src/NextGenOS.Hub.Core` — the domain: settings, catalogue, documents with the tax engine, restaurant, library, projects, appointments, purchasing, reports, the demo company builder.
- `src/NextGenOS.Hub.Web` — the Blazor program: licence gate, sign-in, setup wizard, screens. In the shipped build the names in `Hub.Core` are hidden and the names of methods in `Hub.Web` are kept (`scripts/protect-dotnet.mjs`), so **the web program must not implement an interface that `Hub.Core` defines** (the name hiding stops with "inconsistent virtual method"): hand `Hub.Core` a function instead (see `DelegateEntitlements`). Only the full gate's `hub-release` check catches this.
- `tests/` — domain tests, web tests, and the browser-test host.
- `e2e/` — browser tests (Playwright); `e2e/protected.mjs` runs them all against the protected build; `e2e/licensed.e2e.mjs` is run by `licensing/e2e/hub-e2e.mjs` with a real licence.
- `installer/` — the Windows setup (NSIS), its build script and its test.

## Demo company

`DemoCompany.Fill(dbPath, new DemoOptions { Industry, Country })` makes a sample business from the industry pack (items, people, tables, projects, bookings and two weeks of trading) through the same services the screens use. The setup wizard offers it with a plain warning that it cannot be taken out later.
