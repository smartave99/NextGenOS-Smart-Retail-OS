# Contributing

Thank you for helping. This software sits beside a shop's POS and works with real sales, so a few rules matter more than speed. They are written down so that nobody has to guess.

This is a **private, proprietary codebase** of NextGen OS (see [`LICENSE`](LICENSE)). It may be read and changed only by people who have a written agreement with NextGen OS, and nothing in it may be copied, published or shared outside that group: not in a public repository, an issue, a forum, or an AI service that keeps or trains on what it receives.

## What is here

- [`SmartRetailAI/`](SmartRetailAI/README.md): the Windows app (WinForms on .NET Framework 4.8, showing the dashboard with WebView2), the AI Core library, the setup program and the release scripts.
- [`SmartRetailPOS/`](SmartRetailPOS/README.md): the dashboard (a .NET 10 Blazor Server app), the owner's web page and the Supabase scripts.
- [`AGENTS.md`](AGENTS.md): the working rules of the project in detail, for people and for coding assistants. Read the part about the area you change.

## Build and test

| What | How |
|---|---|
| The Windows app and AI Core | `dotnet test SmartRetailAI/SmartRetailAI.sln` (the .NET 8 SDK is enough, on Windows or Linux) |
| The dashboard | `dotnet test SmartRetailPOS/SmartRetailPOS.sln` (the .NET 10 SDK; `SmartRetailPOS/global.json` pins it). Set `POS_TEST_SQL` to a SQL Server connection string to run the SQL Server tests too. |
| The dashboard in a browser | `cd SmartRetailPOS/tests/e2e`, `npm install`, `npx playwright install chromium` (the first time), then `npm test` and the other `npm run test:*` scripts. `SmartRetailPOS/README.md` says which script covers which page. |
| A package | `SmartRetailAI/build.ps1` (PowerShell 7 or Windows PowerShell); `-Installer` also builds the setup with NSIS |

Try the dashboard without a shop's database: `Pos__Mode=Demo` starts it on made-up data. A change comes with tests, and the tests of the parts it touches pass. GitHub Actions runs both solutions on Windows for every pull request.

## The rules that keep a shop safe

1. **The POS database is read-only.** SQL uses only the tables and columns of the POS schema (`SmartRetailPOS/tests/SmartRetail.Pos.Tests/SqlServer/pos_schema_subset.sql`), every new query has a SQL Server test, and every query runs in a transaction that is rolled back, on top of `SqlGuard`. Keep both.
2. **Never take a price from an AI.** Prices, offers and barcodes come from the POS and the rules in Core. An AI may choose from a list and write words, and its answer is checked.
3. **What leaves the PC is small.** The AI gets figures and product names (`SalesBrief`), never a customer's name, phone number or bill. Keep the checks (`PiiMasker`, `PersonalData`, the memory and playbook rules) that say so.
4. **The dashboard listens on 127.0.0.1 only.**
5. **No secrets, no shop data.** Never commit API keys, passwords, connection strings, `appsettings.Local.json`, `settings.json`, logs, build output, or anything from a shop's own POS (its program files, installers, database backups, settings files). Never paste them into an issue or a pull request either; use the demo shop.
6. **Add-on data stays in the data folder** the owner chose, never anywhere else and never in the POS database.
7. **Keep the notices.** A library added to a project needs its line, with its licence, in [`THIRD-PARTY-NOTICES.md`](THIRD-PARTY-NOTICES.md) (a test fails without it), and its licence must allow it to be shipped inside closed, proprietary, commercially sold software (MIT, BSD, Apache-2.0 and the like are fine; GPL, AGPL, SSPL, "non-commercial" licences and anything that would make this software's source public are not, and an LGPL or MPL library needs a review first). When you change the version of WebView2, the SQL client, SkiaSharp, ONNX Runtime or the .NET runtime, replace the matching file in [`licenses/third-party/`](licenses/third-party) with the one inside the new package.

## Sending a change

- For anything bigger than a small fix, open an issue first and say what the shop owner or cashier will see change.
- One thing at a time, with the README or `AGENTS.md` lines that describe it. Match the code around it: naming, comments, idiom.
- Say what changed in [`CHANGELOG.md`](CHANGELOG.md), under the version being built, in plain words for the shop owner (new, improved or fixed). The owner reads that list in the app, under *What's new*, and a release is refused without its entry.
- A change is accepted only from a person who has a written agreement with NextGen OS (employment, contract or contributor agreement) that gives NextGen OS the ownership of it. By sending a change you confirm that you wrote it or have the right to give it, and that it holds no code copied from another project whose licence forbids this.
- To report a security problem, follow [`SECURITY.md`](SECURITY.md) and do not open a public issue.
