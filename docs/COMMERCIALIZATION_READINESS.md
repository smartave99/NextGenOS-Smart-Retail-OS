# Commercialisation readiness: what must be done to sell this as a white-label platform

Product: **Smart Retail POS by NextGenOS** (the four apps in `apps/`). Goal: sell it, white-labelled, to retail businesses of any type and in any country, single shops and chains, with strong protection so that nobody can resell it without NextGenOS's permission.

Audit date: 5 October 2026. Method: a read-through of the whole repository (structure, licences, secrets, licensing code, installers, build scripts, auth, schema, localisation, dependencies), `npm audit` and a licence scan of the storefront's lockfile. **Not done:** building or running the Windows apps (no .NET SDK or Windows here), a penetration test, or legal review. Nothing here is legal advice; items marked *for counsel* need a lawyer who knows the countries you will sell in.

---

## 0. Verdict

**Not ready to sell yet.** Three things block a sale, and they come before any feature work:

1. **Ownership (section 2.1).** The Windows POS in `apps/pos-desktop` is decompiler output from compiled programs, including libraries that a vendor had protected with a commercial obfuscator. A decompiled copy does not give you the right to relicense or resell it. You need proof that NextGenOS owns, or is licensed to resell, the original.
2. **Nothing enforces a licence (section 2.2).** The licence check is switched off in code, a keygen script ships in the repository, and the installer runs it for every customer. Today anyone can copy and resell the POS.
3. **Secrets and shared backends are in the code (sections 2.3 and 2.4).** Live credentials are committed, and every installed copy talks to the same Firebase projects with an admin secret.

After those come white-label branding, multi-tenant and chain support, localisation for other countries, security hardening and productisation (sections 3 to 6). Section 8 puts it all in order.

---

## 0a. Status now (updated after the licensing, Hub and release work)

The audit below was written first; this table says where each finding stands today. "Checked by" is the part of `node scripts/verify-all.mjs --full` that covers it. Anything marked **open** is still true.

| Finding | State | Where / checked by |
|---|---|---|
| Licence not enforced; keygen; fixed AES key; installer runs an activation script (2.2) | **Fixed in the code.** Signed (ECDSA) licences tied to the PC, revocable, with grace and offline activation, enforced in the Windows POS, AI add-on, dashboard, website and the Business Hub. The keygen and activation scripts are gone, and tripwires fail the gate if one comes back. | `licensing/`, checks `bypass`, `enforcement`, `hub-enforcement`, `dotnet-live`, `hub-release` |
| Secrets in the files (2.3) | **Removed from the files; a scan fails the gate if one returns.** The back-door super-admin e-mail is removed. | check `secrets` |
| Secrets in the git **history** (2.3) | **Open.** The OpenAI key, the Neon password, the Firebase secrets and the SQL Server `sa` password are still readable in the history. **Rotate every one**, or start a fresh repository from the cleaned tree. | you |
| Who owns the decompiled Windows POS (2.1) | **Open. Needs a lawyer and the original paperwork.** Not a coding task. | you, counsel |
| Third-party licences for the old POS (2.1) | **Open** for `apps/pos-desktop`. The Business Hub's own packages are checked and noticed (`THIRD-PARTY-NOTICES.md`; the gate refuses GPL-type licences in the new work). | check `nuget-audit`, `npm-audit` |
| Shared Firebase backends of the old POS (2.4) | **Open** for `apps/pos-desktop`. The Business Hub has no shared backend: each shop's data is on its own PC. | |
| White-label (3.1) | **Done:** the brand rides inside the licence; the Brand Studio makes brand kits; the Hub's *Look* page lets an owner change colours and logo within the licence's white-label level (one rule, shared test vectors in .NET and TypeScript). **Open:** fonts and a light/dark default are allowed but not applied; no way yet to make a Windows setup under a customer's own file name. | `docs/BRAND-STUDIO.md`, checks `brand-studio`, `brand-studio-wizard`, `hub-e2e`, `dotnet-live` |
| Any country (3.3) | **Done for the Business Hub and the website:** 34 country packs (tax, money, formats) through one tax engine, tested in every country. **Open:** the older Windows POS, AI add-on and dashboard remain India-GST; no country pack has been checked by a local tax adviser; no fiscal-printer or e-invoicing integrations. | checks `country-packs`, `dotnet-tax`, `dotnet-hub` |
| Any kind of business | **Done in the Business Hub:** retail, restaurant, library, construction, services, wholesale and generic, each worked through in a real browser; honest "works / not yet" list per business. | check `hub-e2e` |
| Hardware (printers, scanners) | **Built and tested against stand-ins:** ESC/POS, ZPL, TSPL, EPL, CPCL; network, serial, USB file, CUPS, Windows spooler; camera scanning. **Open:** not tried on real hardware. | check `dotnet-hub` |
| Source-code protection | **Built for the Business Hub:** compiled code only, names hidden, symbols removed, every package audited, the protected build tested in a browser and with a real licence. **Open:** no integrity self-check, no per-customer watermark, not code-signed; the old Windows POS is not yet packaged this way. Name hiding is a deterrent, not a lock. | `docs/SECURITY-MODEL.md`, checks `package-audit-tests`, `hub-release`, `hub-protected-e2e` |
| Installers and release | **Business Hub:** Windows setup (service, protected data folder, clean uninstall) tested under Wine here and on a real Windows machine by the release workflow; Android app built and signed by the workflow. **Open:** the old Windows programs have their own installers, which this workflow does not build; nothing is code-signed until you add a certificate. | `docs/RELEASE-GUIDE.md`, check `hub-installer` |
| Chains and several shops (3.2) | **Open.** Not built: each shop PC is its own. | |
| Independent security test, legal review | **Open.** | you |

---

## 1. Done in this change (licence conversion)

| Change | Where |
|---|---|
| MIT replaced by a proprietary licence notice (all rights reserved; no use, copying, sharing, resale, hosting, rebranding, reverse engineering or licence tampering without a written agreement) | `LICENSE` |
| Customer End User Licence Agreement: per-store licence, no resale/sublicense/rental/service-bureau, no rebranding except as an appointed reseller, no reverse engineering, no tampering with licence checks, activation and licence-data consent, reseller/white-label clause, third-party and AI-service terms, tax/legal compliance, audit right, termination, liability limits | `EULA.txt` (new) |
| Duplicate MIT licence in the POS app removed | `apps/pos-desktop/LICENSE` (deleted) |
| `package.json` licence set to `UNLICENSED`; .NET copyright now "All rights reserved" | `package.json`, `apps/storefront-web-mobile/package.json`, both `Directory.Build.props` |
| "Free, open source" wording removed from the app's About page, READMEs, notices and contributing guide; contributions now require a written agreement that assigns ownership; new libraries must allow proprietary redistribution | `Settings.razor`, `README.md`, `apps/*/README.md`, `THIRD-PARTY-NOTICES.md`, `CONTRIBUTING.md` |
| Installers now show or carry the EULA instead of the MIT text (the POS setup shows it as its licence page; the AI add-on package copies it) | `apps/pos-desktop/installer/SmartRetailOS_Setup.iss`, `apps/pos-ai-companion/build.ps1` |
| Licence tests now assert the proprietary terms, the EULA's key clauses and `UNLICENSED` | `LicenceTests.cs` |
| SignPath Foundation row removed: it signs only public open-source projects | `apps/pos-ai-companion/README.md` |

**To fill in before the EULA is shown to a customer** (search for `TO BE COMPLETED`): your legal entity name and registered address, the licensing contact e-mail, and the governing law and courts (*for counsel*).

**What this does not change.** Copies that someone already received under the MIT licence stay under it. This repository was created on 5 October 2026, is **private**, has one commit and no forks, which is the best case. But the README says its code was merged from three earlier sources (`Smart-Retail-POS-by-NextGen-OS`, `Test`, `demo_shop`). **Check whether any of those were ever public under MIT, make them private, and keep the history of what was released.**

Not changed on purpose (needs your decision, see section 2): the licence check, the activation script and the secrets. The `CHANGELOG.md` was left alone because its tooling is strict about headings; add a line about the licence when you cut the next version.

---

## 2. Stop-ship blockers (P0)

### 2.1 Who owns the Windows POS?

What the repository shows:

- `apps/pos-desktop/Documentation/RECOVERY_REPORT.md` says the source was **recovered by decompiling** compiled binaries, installers and databases ("Original Files Provided: `D:\Test\POS\`") of a product formerly called "DemoMart99 POS". The code still carries decompiler markers (`Token: 0x… RID: … RVA: …`) in about 2,400 `.vb` and `.cs` files, original-product names such as `BillPoint`, and a database table called `RaintechMaster` that the start-up screen reads.
- Seven helper libraries (`DevNet.ChromeDriverManager`, `DevNet.GS`, `DevNet.PhonePe`, `DevNet.QImage`, `DevNet.Translitration`, `DevNet.WhatsApp.V2`, `DevNetTRLN`) were protected with **Eziriz .NET Reactor and Agile.NET**, which a vendor uses to stop copying. What is in the repository for them was rebuilt from their public signatures, and hundreds of randomly named obfuscator files are still in the tree.
- The POS project builds against `..\..\..\Original_Binaries\*.dll` (60 references). Those original binaries are not in the repository, so **the POS cannot be built from this repository alone**, and its real behaviour comes from files you did not write.
- It talks to Firebase projects named `androidbillsoftreport`, `sdata-d4757`, `update-89a0d` and `softwarelicensemanager-a9582`. Whoever owns those projects can read, change or switch off every install that uses them.

What to do (*for counsel*): collect the paper that shows NextGenOS owns the original source and every library in it, or holds a licence that allows modifying and reselling it (a purchase or source-code agreement, an IP assignment from the developers). If you do not hold it, you cannot lawfully sell this as proprietary, and the options are to obtain the rights or to rewrite those parts. A buyer's lawyer will ask for this first.

The rest of the suite (`pos-ai-companion`, `pos-dashboard-service`, `storefront-web-mobile`) reads as written for NextGenOS; confirm that the people who wrote it assigned their rights to the company.

**Third-party components to confirm for commercial redistribution.** The existing `THIRD-PARTY-NOTICES.md` covers only the AI add-on and the dashboard. It has nothing for the desktop POS or the storefront. Verify each licence (a tool such as ScanCode, FOSSA or ClearlyDefined helps) and add notices:

| Component | Why it needs a look |
|---|---|
| `Bunifu_UI_v1.5.3`, `SautinSoft.PdfFocus` | Commercial components: a redistribution licence is needed |
| `CrystalDecisions.*` (SAP Crystal Reports runtime) | SAP's licence terms apply to redistribution. The two `Setup\CR13SP32MSI*.MSI` files are 134-byte placeholders, so the real runtime installers are missing |
| `MySql.Data` | Oracle's driver is GPL-2.0 with a FOSS exception: a proprietary product needs Oracle's commercial licence, or switch to an MIT-licensed driver |
| `AForge.Video*` | LGPL-3.0: keep it as a replaceable DLL and ship the notices |
| `GelButtons`, `CButtonLib`, `GDClient`, `RulerControl`, `TouchlessLib`, `MessagingToolkit.QRCode` | Origin and licence not stated: identify them |
| `Microsoft.Office.Interop.Excel` | Needs Excel on the customer's PC |
| `Drivers\POS Printer Driver V7.17` (13 MB vendor installer), `Fonts\code128.ttf`, `Fonts\IDAutomationHC39M.ttf` | Confirm you may redistribute them |
| ClosedXML, MailKit/MimeKit, FireSharp, FluentFTP, SSH.NET, NPOI, QRCoder, ZXing, PdfPig, Selenium WebDriver, Google APIs, SharpZipLib, Nancy | Normally permissive, but each needs its notice in the package |
| Storefront npm tree (1,560 packages) | No GPL/AGPL found. 14 MPL-2.0 (for example `lightningcss`, `axe-core`, `@vercel/analytics`) and about 10 LGPL-3.0 (`sharp-libvips` native files) need to be kept replaceable and noticed, above all when bundled in the Electron or Capacitor apps. `limiter` has no licence stated |

**Features that carry their own legal risk when sold in other countries:** WhatsApp Web automation through Selenium and ChromeDriver (`DevNet.WhatsApp.V2`, `DevNet.ChromeDriverManager`) goes against WhatsApp's terms and gets accounts banned: use the official WhatsApp Business API. `DevNet.QImage` fetches product photos from the web (copyright and terms of use). `DevNet.GS` validates GSTINs online: confirm it uses an official, licensed data source.

### 2.2 The licence system is off, and a keygen ships with it

| Finding | Where |
|---|---|
| `Validate()` returns a hard-coded licence ("Smart Retail POS", key `ACTV99-…`, valid for 50 years) whenever the registry has none, with `ShowActivation = false`. **The check is never enforced.** | `apps/pos-desktop/Source/Libraries/DevNetLM/DevNetLM/DevNet.cs` |
| Because `Validate()` always returns a licence, the start-up screen goes straight to the login: **the activation screen can never appear** | `…/BillPoint/frmSplash.vb` (around line 180) |
| `Activate_POS.ps1` is a **licence generator**: it writes a permanent "2020 to 2099" licence for any PC, with the AES key inside the script, and prints the login `admin` / `admin` | `apps/pos-desktop/Activate_POS.ps1`, `Activate_POS.bat` |
| The installer **runs that script on every customer's PC** ("Auto-activate permanent license during installation") | `apps/pos-desktop/installer/SmartRetailOS_Setup.iss`, `[Run]` section |
| The licence is encrypted with one fixed AES key and a zero IV, the same key in the library and the script, and stored in `HKCU` (writable by the user). Anyone can make a valid licence | `DevNetLM/Classes/Encryption.cs` |
| The hardware ID is an MD5 of the first disk's serial number: it changes with hardware and is easy to fake | `DevNetLM/Classes/Utility.cs`, `Activate_POS.ps1` |
| The old licence store is a public Firebase Realtime Database (`softwarelicensemanager-…`) that is not yours to control (see 2.1) | `DevNetLM/Classes/GlobalValues.cs` |
| The installer packages `bin\Debug`, not a Release build | `SmartRetailOS_Setup.iss`, `[Files]` |

Do **not** sell this build. The fix is a new licensing core (section 4). Until then, the activation script and the installer's `[Run]` line must go, and no installer should leave the building. I did not remove them in this change because the product's current build and demos depend on them, and the right replacement is your decision (see section 9).

### 2.3 Secrets in the repository: rotate all of them now

Values are not repeated here. The repository's history keeps them, so removing the lines is not enough: **revoke and replace each one**, then keep secrets out of code (environment variables, a secret store, or the per-tenant licence service).

| What | Where | Do |
|---|---|---|
| An **OpenAI API key** (`sk-proj-…`) | `apps/pos-desktop/Source/DemoMart99_POS_VB/DemoMart99 POS/BillPoint/frmImageReader.vb:28` | Revoke it at OpenAI. Customers' AI calls must go through your own gateway (section 4) or their own key |
| A **Neon PostgreSQL connection string with its password** | `apps/storefront-web-mobile/tmp/wake_primary.mjs:4` | Reset the database password; delete the `tmp/` folder |
| **Firebase database secrets** (full admin access) in the POS: `Form.vb:605`, `Receiver.vb:488`, `frmCustomerMobileRpt.vb:988`, `frmGodownInward.vb:398`, `frmGodownOutward.vb:826`, `frmGodownConfig.vb:246`, `frmInfoBrodcast.vb:289`, `ModFunc.vb:64,70`, and `Libraries/DevNetFB/DevNetFB/FirebaseService.cs:72,148` | `apps/pos-desktop/Source/…/BillPoint/` | Revoke on the Firebase projects you control; replace with per-tenant, short-lived credentials |
| A hard-coded **password** in `Me.password` | `frmCategory.vb:37`, `frmLead_Product.vb:38` | Find what it unlocks and change it |
| The **admin account password** in the user-creation scripts (one of them is trivially guessable), and the admin e-mail `admin@demomart99.com` that the code treats as super-admin | `apps/storefront-web-mobile/scripts/create-admin.ts:42`, `create-admin.js:52`, `recreate-admin.ts:35`, `recreate-admin.js` | Change the password on the live Firebase project now, remove it from the scripts, read it from the environment |
| The **AES licence key** | `DevNetLM/Classes/Encryption.cs`, `Activate_POS.ps1` | Retire it; the new licence uses signatures (section 4) |

Because the history is a single commit, the cleanest way to get rid of the old secrets in git is to make the fixes, rotate, and **start a fresh repository from the cleaned tree**. Turn on GitHub secret scanning with push protection so this cannot recur.

### 2.4 Every install shares your vendors' backends

The POS reads and writes four Firebase projects with an admin secret that is the same for every shop. For a product sold to many customers this means one leaked secret exposes all customers' data, and the owner of those projects can disable every install. Replace them with **a backend NextGenOS owns, with one isolated tenant per customer and per-tenant credentials**. The same rule applies to the update feed (below) and to anything that phones home.

---

## 3. Make it a white-label, multi-tenant, any-country platform (P1)

### 3.1 White-label branding

State today: the product identity is spread across the code. "Demo Mart" appears in 74 files, "NextGen" in 65, "SmartRetail" in 460 (mostly code namespaces, which can stay). The identity strings that must become configuration:

- Display name, logo, colours, support contact and legal text; the app and package IDs (`com.demomart.app`, `productName: "Demo Mart"` in the storefront; `AppId` GUID, `AppName`, `OutputBaseFilename`, `MyAppURL` in the Inno script; `Branding.cs` in the AI add-on, which already holds `Company`, `Product` and `AppFolderName`).
- The executable name `DemoMart99 POS.exe`, registry keys `Software\SLM\…` and `Software\hdc\…`, the session cookie `demo_shop_session`, the manifest and `llms.txt`, AI prompts that name "Demo Mart".
- The built-in super-admin e-mail `admin@demomart99.com`, which is **hard-coded in five places** (`src/lib/auth-server.ts:26`, `src/app/actions.ts:454` and `:1364`, `src/app/api/auth/session/route.ts:21,24`, `src/lib/data.ts:170`) and bypasses the e-mail-verified check. This is a back door that also carries your own shop's identity: remove it, and create the first admin per tenant at install time.

Build a **brand profile** (one signed JSON per customer or partner: names, logos, colours, domains, legal text, support links, update channel, feature flags) that every app reads at start, and a build pipeline that stamps it into the installer, the Electron/Capacitor shells and the storefront. Put the brand-profile ID **inside the signed licence** (section 4) so a partner can use only the branding you approved. The storefront already has `/admin/branding` and `/admin/appearance`; the POS and the installers have nothing.

### 3.2 Tenancy and chains

- **Storefront:** no tenant concept at all (`prisma/schema.prisma` has no store or organisation id; one PostgreSQL database; admin roles are global). Start with **one deployment and one database per customer** (strongest isolation, simplest to reason about), automated by a provisioning script; consider a pooled design with a `tenantId` on every table and row-level security later.
- **A chain needs a model the suite does not have:** organisation, then brand, then store; a central catalogue with per-store overrides; price lists per store or region; stock transfers between stores; roles that span stores (HQ, regional manager, store manager, cashier); consolidated reports; central settings pushed to every store. Today the dashboard listens on `127.0.0.1` for one shop, the owner's live view is one Supabase project per shop, and multi-PC shops have a "main PC" concept. A cloud **Chain Hub** has to be built on top of those.
- Owner and customer data: keep each tenant's data separate in storage, backups, logs and AI memory.

### 3.3 Any country

The suite is built for India. Indian assumptions found: GST/GSTIN/HSN fields and `GstMode` (`appsettings.json`, `Core/Billing/`), `RoundToNearestRupee`, ₹ and `en-IN` formatting (`live-shop/format.ts`, `Services/Formats.cs`, `Money.cs`, `Billing.razor`, posters, price tags), the Indian financial year (`FinancialYear.cs`), PhonePe/UPI, WhatsApp as the main message channel, `+91` phone handling and Hindi. There is **no localisation framework** (no resource files, `next-intl` or `i18next`). To sell elsewhere:

| Area | What is needed |
|---|---|
| Currency and number formats | Per-tenant currency, symbol position, decimals, grouping; cash-rounding rules (some countries round to 0.05 or 0.10) |
| Tax | A tax-engine abstraction: VAT, GST, sales tax; inclusive or exclusive prices; several rates per line; zero-rated and exempt items; reverse charge; per-region rules. India becomes one "country pack" |
| Invoices and receipts | Per-country templates, mandatory fields, numbering, and e-invoicing or fiscal-device rules where they apply (for example India's e-invoice, EU and Gulf e-invoicing, fiscal printers in several European countries) |
| Payments | A gateway interface with local providers per market (cards, wallets, bank transfers); keep card data out of the product (use the gateway's hosted fields or terminals) to stay out of heavy PCI-DSS scope |
| Language | Resource files for every screen and AI prompt; right-to-left layouts; AI answers in the shop's language |
| Formats | Dates, calendars, addresses, phone numbers, units of measure, time zones, financial-year start |
| Law | Data-protection law per market (for example GDPR, India's DPDP Act 2023); consent, retention, deletion and export tools |

Build **country packs** (data plus rules plus templates): start with India as it is today, then the first two markets you actually sell in.

### 3.4 Any type of retail

Batches and expiry exist in the POS. Make the rest configurable as **industry packs**: grocery (weighing scales, loose items, expiry), pharmacy (batches, prescriptions, controlled items, regulator reports), apparel and footwear (size and colour variants, matrix entry), electronics (serial numbers or IMEI, warranty), hardware and building supplies (units, conversions), and so on. Restaurants (tables, kitchen orders) are a different product and need their own module.

### 3.5 Platform reach

The POS, AI add-on and dashboard are **Windows-only** (.NET Framework 4.8 x86 WinForms, WPF/WebView2, Windows DPAPI). That is fine to start with, but Mac, Linux, tablets and phones will not run it. Plan a cross-platform or web POS later, reusing the storefront stack, and keep the Windows POS as the first product.

---

## 4. Anti-piracy and anti-resale design (P0 for the core, P1 for the rest)

Goal: customers can use only what they bought, nobody can resell or rebrand without your permission, and a leaked copy can be traced and switched off. Be clear about the limit: nothing that runs on a customer's own PC can be made unbreakable. The aim is to make copying hard, expensive and traceable, and to keep the valuable parts on your side.

1. **Signed licence files.** Replace the AES and registry scheme with licences signed with an asymmetric key (ECDSA P-256, which .NET Framework 4.8, .NET 8 and Node all support). The licence holds: licence ID, customer and organisation, edition and modules, number of stores/terminals/users, validity dates, hardware or domain binding, reseller ID and **brand-profile ID**. Apps carry only the **public** key and verify the signature. The private key lives in a KMS or HSM (or offline), in a **separate private repository for the licence server**, and never in this repository. Support a key ID so you can rotate keys.
2. **Online activation and check-in.** Activate against your licence service; check in regularly (for example weekly); allow an offline grace period (for example 14 to 30 days); support revocation and transfers; limit activations per licence. Bind to several hardware signals, not one disk serial, and tolerate hardware changes through support.
3. **Keep value on the server.** This is the strongest protection, because client checks can be patched out. Route the **AI calls, updates, catalogue sync, the owner's live view and any cloud features through services you run**, authenticated by the licence. Then a cracked or resold copy loses those features. For the storefront, prefer **hosting it yourself as SaaS** (one tenant per customer); if a customer must self-host, ship a compiled bundle with a licence check bound to the domain.
4. **Protect what you ship.** Ship binaries only, never source. Strong-name and Authenticode-sign them. Obfuscate the .NET assemblies with a maintained commercial obfuscator, put licence checks in several places (not one `if`), and add integrity self-checks. Build releases in CI from a protected branch.
5. **Make leaks traceable.** Per-customer builds or licence-ID watermarks in the UI footer, reports and receipts; canary values in demo data; activation audit logs; alerts for one licence on many machines.
6. **Contracts.** The EULA (done, needs counsel), a **reseller and white-label agreement**, a partner programme with approved brand profiles, NDAs, and IP-assignment agreements for every developer and contractor. Register the trademarks in your target countries.
7. **Repository security.** Keep the repository private; two-factor authentication and branch protection; code owners; secret scanning and push protection; Dependabot; no licence-signing keys anywhere in it.

The existing updater is a good start (a public feed plus a check that GitHub signed the release for this exact repository: `UpdateChecker.cs`, `GitHubStatement.cs`) but the feed address and the repository, owner and workflow it trusts are **settings** (`UpdateSettings.cs`), not values fixed by you, and it expects a `.github/workflows/installer.yml` that is not in the repository. For white-label sales the update channel must be **set by you, signed, and carried in the brand profile**.

---

## 5. Security hardening backlog (P2)

**Storefront (`apps/storefront-web-mobile`)**

- `npm audit` on the lockfile: **62 vulnerabilities (3 critical, 43 high, 15 moderate, 1 low)**. Critical: `next`, `tar`, `vitest`. High includes `electron`, `electron-builder`, `firebase`, `prisma`, `sharp`, `postcss`, `@grpc/grpc-js` and `xlsx`. Update, re-run the tests, and run `npm audit` in CI. `xlsx` 0.18.5 is the last version published to npm and has open high-severity advisories: move to a maintained build or another library.
- Remove from production builds: `src/app/debug-simple`, `src/app/debug-test`, `src/app/test-firebase`, and the one-off routes `api/migrate-to-blob` and `api/seed-blobs`. Delete the scratch files that are tracked: `tmp/`, `build_log.txt`, `test-output.txt`, `compare-output.txt`, `verification_result.txt`, `implementation_plan.md.resolved`, `test_merge_logic.ts`.
- `api/assistant/settings` and `api/assistant/recommend` have no admin check: confirm they are public by design and cannot leak settings or be abused for free AI use.
- Add a Content-Security-Policy and HSTS to `next.config.ts` (it has the other standard headers); lower `serverActions.bodySizeLimit` from 100 MB.
- The `ApiKey` table stores provider keys: encrypt them at rest and keep them per tenant.

**Windows POS**

- Remove the default `admin` / `admin` login and force a new password at first start.
- Decompiled VB code builds SQL and web requests by joining strings in places (for example the SMS settings screen and the connection strings in `ModCS.vb`). It needs a security review for SQL injection and for secrets in logs and connection strings.
- Install a Release build only (the Inno script packages `bin\Debug`), without PDBs.
- Remove debug instrumentation: the start-up screen (`frmSplash.vb`) appends a `tick_trace.txt` file next to the program on every start.

**AI add-on and dashboard**

- Already strong: read-only SQL with `SqlGuard` and rollback, masking of personal data, DPAPI for keys, local-only dashboard, row-level security in the Supabase script. Keep these tests green and re-verify them after the multi-tenant work.
- `SECURITY.md` tells people to report through the repository's Security tab, which a customer cannot open on a private repository: publish a security contact address and a disclosure process.

**Build and supply chain**

- There is **no working CI**. The only workflow is `apps/storefront-web-mobile/.github/workflows/android.yml`, which GitHub does not run from a subfolder, and it builds a debug APK. Add `.github/workflows` at the repository root: build, test, `npm audit`, dependency and licence checks, secret scanning, signed releases, an SBOM.
- Code-sign the installers (an organisation certificate or Microsoft's Artifact Signing); add the EULA as a page in the NSIS setup (`apps/pos-ai-companion/installer/SmartRetailAI.nsi` has none).

---

## 6. Productisation and housekeeping (P3)

- **Docs are out of date after the merge.** `CONTRIBUTING.md`, `SECURITY.md` and several READMEs point at `SmartRetailAI/`, `SmartRetailPOS/` and a root `AGENTS.md` that do not exist (now `apps/pos-ai-companion`, `apps/pos-dashboard-service`; `AGENTS.md` is only in the storefront). The root README says the dashboard is .NET 8, the projects target `net10.0`. `build.ps1` still has a `../SmartRetailPOS` path after the licence lines were fixed.
- **Tests do not run.** `Repository.Root()` in `TestDoubles.cs` looks for `.github/workflows/installer.yml`; without it every test that uses it throws. Many tests also use the old paths. Fix the root marker and paths, then run all suites.
- **Internal material that must not reach customers:** `apps/pos-desktop/Documentation/` (including `RECOVERY_REPORT.md`, which describes the decompilation), `UI_Proofs`, `test_screen.png`; the AI-assistant rule files in the storefront (`.cursorrules`, `.clinerules`, `.windsurfrules`, `AGENTS.md`); the provenance lines in the root README. Keep the source private and ship binaries and customer documentation only.
- **Customer documentation:** installation, administration, upgrade, backup and restore, troubleshooting, a data-protection and security summary; support and SLA policy; a price and edition sheet (which modules, how many stores).
- **Operations:** a provisioning runbook for a new customer (database, storefront, brand profile, licence, first admin), backup and disaster-recovery, monitoring, an incident process.

---

## 7. Legal and commercial checklist (*for counsel*)

- Proof of ownership of the POS and of every library (section 2.1); IP assignments from all developers and contractors.
- The EULA reviewed for each country you sell in; a **reseller and white-label agreement**; a privacy policy and a data-processing agreement; terms for any hosted service.
- Trademark search and registration for "NextGenOS" and "Smart Retail POS" in your target countries (check for clashes first).
- Open-source compliance for the LGPL and MPL parts; notices for the desktop POS and storefront added to `THIRD-PARTY-NOTICES.md`.
- Tax, fiscal and e-invoicing rules for each market you enter; payment-card rules (keep card data out of scope); export-control and sanctions checks.
- Earlier public copies under the MIT licence (the three source repositories named above).

---

## 8. Suggested order of work

**Phase 0, this week**
1. Confirm ownership paper for the POS and its libraries (2.1). Make the three earlier repositories private.
2. Rotate every secret in 2.3. Start a fresh repository from the cleaned tree. Turn on secret scanning.
3. Stop distributing the current installer. Remove `Activate_POS.*` and the installer's `[Run]` line, and the hard-coded licence in `DevNet.Validate()`.
4. Fill in the `TO BE COMPLETED` fields of the EULA and have counsel review it.

**Phase 1, weeks 2 to 6**
5. Licensing core: signed licence files, a small private licence service (issue, activate, check-in, revoke), verifiers for the POS (.NET Framework 4.8), the add-on and dashboard (.NET) and the storefront (Node).
6. Brand profile and the stamping pipeline; remove the hard-coded admin and the "Demo Mart" identity; create the first admin per tenant.
7. Root CI, dependency updates, removal of debug routes and scratch files, working tests.

**Phase 2, months 2 to 3**
8. One-tenant-per-customer provisioning; your own backend replacing the shared Firebase projects; the AI gateway.
9. Localisation framework, tax-engine and payment abstractions; India as a country pack, then the first two target markets.
10. Code-signed, obfuscated, Release-build installers with the EULA page; customer documentation; reseller agreement and partner brand profiles.

**Phase 3, later**
11. Chain Hub (organisation, brands, stores, central catalogue, transfers, consolidated reports). Industry packs. A cross-platform POS. A partner portal for reseller licences.

---

## 9. Decisions only you can make

1. **Licence model:** per store, per terminal, or per organisation; subscription or perpetual; which modules (POS, AI, Dashboard, Storefront, Chain Hub) are separate. Recommendation: per-store subscription with module flags.
2. **Where the licence service lives and who runs it** (you, on a small cloud service). Recommendation: online activation with a 14-day offline grace period.
3. **Hosted or self-hosted storefront.** Recommendation: you host it (SaaS, one tenant per customer) at first; offer self-hosting later, domain-bound.
4. **First target countries,** so the first country packs can be built.
5. **Whether partners may resell** and under which agreement. Recommendation: invite-only partners with approved brand profiles and a signed reseller agreement.
