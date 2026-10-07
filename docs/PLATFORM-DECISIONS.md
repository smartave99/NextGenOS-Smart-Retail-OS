# Platform decisions: the owner's questions and answers

Recorded on 7 October 2026, from a conversation in which an assistant asked the owner one question at a time about how the platform must work, and the owner answered. **These are the owner's decisions. They are not asked again.** A person or assistant who thinks one is wrong says so and gives the reason; it changes only when the owner says so, and the change is written here in the same session (`CLAUDE.md`, sections 13 and 16).

How to read each entry: **Asked** (the question, with the choices offered), **Answer** (the owner's words, exactly), **Rule** (what it means for the work), **Today** (what exists, said honestly; "not built" means no code exists yet).

## The picture, in the owner's own words

> There will be 1st a super studio which has details of remaining studio so remaining studio is used by non technical staff to create or change project aka project. Are new client to which we are selling.
>
> In project they will add logo and business details and based on that they will change the look how clients want using ai and then when everything is ok they will click on reproduce output which will produce the output aka installer for software so that client can run it on their device how great software works and it releases apk so that client can share it also and it releases codebase only of website updated one so that it can be deployed.

In plain words: one main Studio for staff. Staff make a **project** for each new client, add the logo and business details, shape the look with AI, and when it is right press **one button** that makes the client's outputs: the **installer** for the shop's PCs, the **Android app** the client can share, and the **website**, ready to be put online. The word "codebase" for the website means the ready-to-run package (decision 1), never the source code.

## Decisions

### 1. What the client receives for the website

- **Asked:** A ready-to-run package, the real source code, hosted by us, or package for most and source for a special paid licence.
- **Answer:** "A ready-to-run package (Recommended)".
- **Rule:** The client gets built, compiled files with their own name, colours and settings inside, plus a start program, and the licence check stays in force. **No readable source code ever goes to a client** (`CLAUDE.md` section 3). A change to this needs the owner's word, the EULA and the licence terms first.
- **Today:** Built: the website package per customer, made by the build service on GitHub (`docs/CUSTOMER-BUILDS.md`). The build service has never run on the real GitHub (see `docs/OPEN-WORK.md`).

### 2. How the client's licence is made

- **Asked:** The button asks the Licence Studio, a separate step by sales, only the owner issues, or the licence built into each installer.
- **Answer:** "1 but I don't want client to buy for 1 system and then using or reselling to other".
- **Rule:** The output button asks the Licence Studio (on the owner's own always-on server) for the client's licence, with the plan, number of PCs and features chosen in the project. Staff get this only if their role allows it and **never see the signing key** (`CLAUDE.md` sections 3 and 12). **A purchase must not be usable on more PCs than were bought, and must not be passed on or resold.** The client enters an activation code on first start.
- **Today:** The protection exists: a licence is tied to the PC (a copy on another PC fails), seats are counted, a licence can be switched off, a PC that cannot reach the Studio keeps working for a grace period (`licensing/spec/LICENCE-FORMAT.md`, sections 7 to 10). **Not built:** the button that asks the Licence Studio (today sales issue the licence as a separate step); a screen for staff that shows which PCs use each licence. Known limit: a cloned virtual machine looks the same as the original, so only the contract covers that case.

### 3. Moving a licence to a new PC

- **Asked:** Client a few times a year, always through staff, unlimited, or staff approve with a temporary licence.
- **Answer:** "1st but in one store there are many system so they should be able to sync data locally without any leakage of data or data being send to cloud without user explicit permission".
- **Rule:** The client frees the old PC themselves, **at most 2 times a year**. More moves need staff approval. The Licence Studio keeps a visible history. (The second half of the answer is decision 4.)
- **Today:** The protocol has a "free this PC" step (`deactivate`) and the Studio has "Free this PC". **Not built:** the limit of 2 a year, the plain screen in the shop program, the history view.

### 4. A store with many PCs: one main PC, many counter PCs

- **Asked:** One main PC with counters connecting to it, a main PC with a standby, every PC with its own copy that syncs, or a small store server box.
- **Answer:** "1 and since in every store there is one mother aka main pc and other daughter aka subordinate pc".
- **Rule:** **One main PC per store holds the store's data** (the owner calls it the "mother"). The other counters, tablets and phones (the "daughters"; in screens and guides they are called **counter PCs**) connect to the main PC over the **shop's own network**, paired with that store. **Nothing goes to the cloud, and no data leaves the shop, unless the owner explicitly allows it, in plain words, for that purpose.** There is one true copy, so stock and bill numbers cannot clash. A standby copy of the main PC is a later step, not the first.
- **Today:** **Not built.** The Business Hub runs on one PC and listens only on that PC (`127.0.0.1`), so a store with more than one counter does not work yet. Needs: secure connections inside the shop (the shop's own certificates, not an outside service), pairing a counter PC with the store, which user may sign in where, and what a counter PC does when the main PC is off.

### 5. What the AI may change

- **Asked:** Settings only with a preview, settings plus special client screens, or settings now and special requests as paid projects.
- **Answer:** "1 but I wanted it to change other things also new design but not backend at any cost".
- **Rule:** The AI changes **how things look**, with a preview, undo and approval by staff. **It never touches anything behind the screen, at any cost:** not sales, money, tax, stock, the licence, the database, nor any program logic. Every client runs the same program, so one fix reaches every client. The Studio holds no source code (`CLAUDE.md` section 3).
- **Today:** The look is a fixed set of named choices (`licensing/spec/LICENCE-FORMAT.md` section 6); the Setup Studio and Brand Studio use AI for proposals. How far a new design may go is decision 6.

### 6. How far a "new design" may go

- **Asked:** Hybrid (tight till, free shop window), data only everywhere, or the AI writes style code everywhere.
- **Answer:** "Hybrid: tight till, free shop window (Recommended)".
- **Rule:** The **cashier and back-office screens stay data-only** (colours, fonts, shapes, layouts, artwork), so the till stays fast and cannot be broken. The **shopper-facing website and Android app get much more design freedom** through checked, presentation-only styling: no scripts, nothing that hides a required control, nothing that reaches the backend. The Studio checks it before it is used.
- **Today:** Till screens: data-only theme choices exist. **Not built:** the checked styling layer for the website and app, and the checks.

### 7. How changes reach a client after delivery

- **Asked:** The main PC offers it and the owner approves, staff send a new installer each time, or silent automatic updates.
- **Answer:** "Main PC offers it, owner approves (Recommended)".
- **Rule:** The store's main PC asks NextGenOS whether a new **signed** version or a new look for this client exists. **It sends only the version number, never shop data.** The store owner sees a plain message and presses Update. The main PC updates the counter PCs over the shop's own network. **A backup is made first, and it can go back.** Nothing installs without the owner's approval.
- **Today:** **Not built.** The Hub setup can update itself in place and copies the database before an update; there is no update offer, no signed update feed, and no way for the main PC to update counter PCs.

### 8. Who puts the website online

- **Asked:** Both (bring your own, or we host), the client only, or we host every client.
- **Answer:** "Both: bring your own, or we host (Recommended)".
- **Rule:** Technical clients get the package and a plain guide and put it on their own server. For the rest, NextGenOS hosts the website for a monthly fee, started by staff with one button in the Studio. The Android app is a shell that opens the client's website address, so the website must be online for the app to show anything.
- **Today:** The package and its guide exist (`private-settings.example.env` lists what the person who puts it online must fill in). **Not built:** the hosting service and the button for it. Hosting means NextGenOS runs servers, backs them up and gives support; that cost and duty are the owner's to plan.

### 9. Who starts client projects in the Studio

- **Asked:** Your staff now and partners later, staff and partners from day one, or small shops sign up themselves.
- **Answer:** "Your staff now; partners later (Recommended)".
- **Rule:** At launch only NextGenOS staff use the Studio. Partner resellers come later: each partner sees only their own clients, and their own brand can replace ours if the owner allows it.
- **Today:** Studio roles exist (Sales, Reviewer, Administrator). The licence has a reseller field. **Not built:** partner accounts and the separation between partners.

### 10. What may be sent to an outside AI service

- **Asked:** Only public details with the client's agreement in the contract, ask the client each time, or local AI only.
- **Answer:** "Only public details, and the client agrees in the contract (Recommended)".
- **Rule:** Only what is already public goes out: the logo, the shop name, colours, trade and public wording. **Never** customer records, sales, staff names, prices, passwords or payment data. The contract or order form says so. The Studio shows staff exactly what is sent and which AI service gets it.
- **Today:** The Studio refuses anything in the build bundle that looks like a secret and shows what it sends to the build service. **Not checked here:** that every AI design step shows exactly what leaves; a sentence for the contract is not written (counsel).

### 11. Backup of a store's data

- **Asked:** Local automatic with optional online backup, local automatic only, or the owner does it by hand.
- **Answer:** "Local automatic; cloud only if owner turns it on (Recommended)".
- **Rule:** Every night the main PC copies the data to a second place the owner chooses (a USB drive, or another PC in the store). The owner sees whether the last backup worked; restoring is a few clicks. An **encrypted online backup exists but is off until the owner turns it on**, and says in plain words what goes out and where.
- **Today:** **Not built.** Only the copy made before an update exists.

### 12. A client with several stores

- **Asked:** An opt-in summary to a head-office view, stores fully separate, or one central online database.
- **Answer:** "Opt-in summary to a head-office view (Recommended)".
- **Rule:** Each store keeps its own data on its own main PC. If the owner turns it on, each store sends **only totals** (sales, stock levels, takings) to a head-office screen: no customer records, no payment details, no staff data. It is off until the owner switches it on, says in plain words what is sent and where, and can be switched off. The figures travel over the internet, so a relay is needed; that is why it is opt-in.
- **Today:** **Not built.** "Several shops in one database" is also not built (`docs/OPEN-WORK.md`).

### 13. Card and online payments

- **Asked:** Record only now and certified providers later, take cards inside the software, or cash and manual record only.
- **Answer:** "Record only now; certified providers later (Recommended)".
- **Rule:** The software records the amount and the method; the payment itself is taken on the shop's own bank terminal or payment app. **The software never sees or stores a card number.** Later, for each country, we connect to a payment provider's certified terminal, which reports only "paid" or "not paid". Payment data is the `PAYMENT_SENSITIVE` class and never leaves the device (`CLAUDE.md` section 15).
- **Today:** The Business Hub records payment amount and method. Provider connections: not built.

### 14. Pricing (the first answer, then replaced)

- **Asked:** Setup fee plus a yearly licence per store, a one-time purchase plus paid support, or monthly per store.
- **Answer:** "Setup fee plus a yearly licence per store (Recommended)". **Replaced a moment later by the owner** (decision 15): "since my company is new we are starting with one time fee and software forever".
- **Rule:** **For now: one-time fee, and the software works forever (a licence with no end date).** A yearly licence stays a later option. Do not build yearly renewal now.
- **Today:** The licence format allows no end date (`exp` may be `null`). The Licence Studio's issue screen was not re-checked for it.

### 15. When a licence ends, and what the team can do

- **Asked:** Warn, then sell-only, then read-only; stop selling straight after the end date; or keep working and only show a banner.
- **Answer:** "3 but my team can stop it problem is since my company is new we are starting with one time fee and software forever".
- **Rule:** The software **keeps working and only shows a banner** for a licence that has ended (for example a trial or a later yearly plan); it does not stop the till on an end date. **The owner's team can still stop a licence** (switch it off), and that always works (decision 16). The owner's own data is never locked away or deleted. The "keep working" behaviour must be written in the signed licence, **never a local setting** (`CLAUDE.md` section 3: no switch that skips the check).
- **Trials (asked next, answered):** *Should a trial licence for a sales demo really stop at its end date, even though a paid licence never stops on a date?* **Answer:** "Yes: a trial stops, a paid licence only warns (Recommended)". **Rule:** each licence says in itself, in its signed content, **what happens at its end date**: a paid licence shows a banner, a **trial stops**. A trial runs for 14 days by default (staff can change the length per client), shows a clear "Trial" banner, and when it ends the till stops selling; the owner can still see and export their own data. Staff can extend a trial or turn it into a full licence in one click in the Licence Studio. The "when it ends" choice is set only by staff in the Licence Studio, never by the client's program or a local setting.
- **Today:** **Not built.** The licence rules today say that an ended licence stops the program (`licensing/spec/LICENCE-FORMAT.md` section 10, "Expired"), for every licence. Changing it is a change to the licence format (a signed "when it ends" choice, banner or stop): the spec first, new test vectors, and **all three** implementations (`CLAUDE.md` section 4).

### 16. How often a PC checks in, and what happens when it cannot

- **Asked:** About monthly with 60 days of warnings then an offline code, never stop for a missed check-in, or weekly with 7 days of grace.
- **Answer:** "About monthly, 60 days of warnings, then offline code (Recommended)".
- **Rule:** Each PC checks in with the Licence Studio about once a month, silently, when it has internet. If it cannot, the owner gets a plain warning for 60 days; after that the software asks for a check-in or an **offline code that staff give by phone** (so shops with no internet are fine). **A stop by the owner's team takes effect within about a month at most.** A written promise about what happens if NextGenOS ever closes (a final unlock for every client) is to be settled with a lawyer.
- **Today:** The check-in, the grace period and offline activation exist and are tested (`licensing/spec/LICENCE-FORMAT.md` sections 8 to 10); the values used when the Studio issues a licence were not re-checked against "monthly and 60 days".

### 17. A client's old data (items, customers, history of sales)

- **Asked:** First: a start list now with the owner importing more later, also the full sales history, or start from nothing. Then, because the answer was open: which old systems should the automatic import read first, and does the owner accept a match report before a shop goes live.
- **Answer:** First: "Everything automatically". Then: "All type and since many pos are sql based". (The owner did not answer the match-report half; it was not declined.)
- **Rule:** The goal is to bring **everything** from the client's old system across **automatically**: items and prices, customers and suppliers, stock, balances owed, and the history of sales, **from any type of old system, and many old POS systems keep their data in an SQL database**, so the importer must be able to read those directly as well as spreadsheet and CSV files. The importer must follow these limits, which come from other decisions and rules: it connects to the old database **read-only** and never writes to it; the owner's database password lives in the operating system's credential store and **never leaves the computer** (`CLAUDE.md` sections 3, 15 and 16); nothing about the old shop goes to an outside AI service except what decision 10 allows (so the AI may help guess which column is which from the column names and a few made-up-looking rows only if the owner allows it, otherwise the mapping is done without it). **A match report before go-live** (sales per day, stock value, balances owed, old against new) is kept as a rule for money data until the owner says otherwise; the shop goes live only when it matches. "All types" is a direction, not a day-one promise: a system whose data is locked, cloud-only or has no export cannot be read until the vendor gives an export, and the answer to the owner says so (`CLAUDE.md` section 11).
- **Today:** A **starter list of items and people** can be pasted from a spreadsheet in the Studio and is applied when the shop is first set up (`docs/SETUP-STUDIO.md`). **Built in the Business Hub (7 October 2026, not verified against a real SQL Server):** *Settings → Move from the older POS*, a read-only reader of the older Windows POS's SQL Server database for items, stock, customers, suppliers and balances owed, with a match report before anything is saved and a separate all-or-nothing move (`docs/OPEN-WORK.md` item 1f, `docs/old-programs/DATABASE.md`). In this build the SQL driver cannot connect (it refuses to work while the Hub runs without the system's language data): an open decision. **Not built:** the import of sales history and stock movements; readers for other SQL databases (MySQL or MariaDB, PostgreSQL, SQLite) and for spreadsheet and CSV files; the mapping helper. The Windows POS in this repository (`apps/pos-desktop`) is the owner's own old system and the first SQL reader.

### 18. How a client's problem reaches the team

- **Asked:** A Help button that makes a safe support file, phone and messaging only, or remote access to the client's PC.
- **Answer:** "Help button that makes a safe support file (Recommended)".
- **Rule:** The shop program has a **Help button**. It describes the problem in plain words and, **only if the owner agrees**, attaches a support file with versions, the licence state, the last errors and the backup status. The support file holds **no sales, customers or passwords**, and the owner can read it before it is sent. It arrives on that client's page in the Studio, so staff see everything about the client in one place. Phone and messaging stay as a fallback. **No remote control of a client's PC** is part of the plan; if it is ever wanted it needs the owner's word, the client's permission each time, and a recorded session.
- **Today:** **Not built:** the Help button, the support file, and the client's page in the Studio. (The audit log and the Hub's own logs exist but are not gathered into a support file.)

### 19. One window for staff: the main Studio and the private Licence Studio

- **Asked:** One window that talks to the private Licence Studio, two separate tools, or the Licence Studio merged into the main Studio.
- **Answer:** "One window; it talks to the private Licence Studio (Recommended)".
- **Rule:** The main Studio (the "super studio" in the owner's words, today the Setup Studio) gets a **Licences section on each client's page**: the licence, the PCs in use, free a PC, extend a trial, switch off. It does this by calling the **Licence Studio's server** with its own **limited staff login**, so each person sees only what their role allows. **The Licence Studio stays a separate private program on the owner's server and keeps the signing key; the main Studio never holds or sees a key** (`CLAUDE.md` sections 3 and 12). The whole client (project, outputs, licence, PCs, version, backups, support) is on one page. The Licence Studio is never merged into the main Studio.
- **Today:** **Not built.** The Licence Studio has roles and a web interface of its own (`licensing/README.md`); the Setup Studio does not call it.

### 20. How the Android app reaches shoppers and staff

- **Asked:** An APK to share plus a Play Store package, an APK only, or every app published on NextGenOS's own store account.
- **Answer:** "APK to share, plus a Play Store package (Recommended)".
- **Rule:** Every build gives **two files**: the **APK**, for quick sharing by link or message (the client's own staff, trials; phones warn about installing from outside the store, so it is not for the general public), and the **Play Store package (`.aab`)**, to be published under **the client's own Google Play account**, which the client or NextGenOS staff set up once. Updates then reach shoppers through the store. **The signing keys stay with NextGenOS in a protected place, never on staff PCs and never in the repository** (`CLAUDE.md` section 3). The Studio says in plain words which file goes to whom. The app is a shell around the client's website address, so the website must be online (decision 8).
- **Today:** Built: the build service makes the signed APK and AAB for a client's brand (`docs/CUSTOMER-BUILDS.md`); it has never run on the real GitHub, and a build with no signing secrets is signed with a one-off test key that a phone will not accept as an update. **Not built:** the Studio's plain explanation of which file goes to whom, and anything for setting up the client's Play account.

### 21. Languages at launch

- **Asked:** English first with client wording and translations as a setting, English plus the local language of each launch country, or many languages from day one by AI translation.
- **Answer:** "English first; client wording and translations as a setting (Recommended)".
- **Rule:** At launch the screens are in plain English. **Every piece of wording a client sees** (receipts, labels, button names, posters) **is a setting of that client's project** (`CLAUDE.md` section 8), so a shop can already show its own words. Full translations of the screens come **country by country** as each market opens, made with AI and **checked by a local speaker before release**. No unchecked machine translation on a cashier's screen, especially not on money or tax screens.
- **Today:** Wording settings and country packs exist; there is no translation system for the screens themselves.

### 22. How features and extra PCs are priced (the shape)

- **Asked:** A few plans plus add-ons, fully a la carte, or one price for everything.
- **Answer:** "3 for start later 1" (3 = one price for everything, 1 = a few plans plus add-ons).
- **Rule:** **At the start: one price for everything, per store.** **Later: a few simple plans plus add-ons** (extra counter PCs, the AI helpers, the website, the Android app, hosting). The licence already carries a plan and a list of modules, so the later step needs no new format. The owner sets the actual prices.
- **Today:** The licence has a plan and modules (`licensing/spec/LICENCE-FORMAT.md`). **Not decided:** how many PCs the one price covers; until the owner says, staff set the number of PCs in each licence at sale time (and decision 4's counter-PC count is checked against it).

### 23. Everything is done locally on the staff laptop; no GitHub for staff

- **Asked / said (the owner, in their own words):** "you are making this complex i want everything to be done locally and no need of github and so and even if everything is [on the] company staff laptop how can they leak it or copy it when there will be security so solve it".
- **Rule:** Staff finish a customer's installer pack, website package and Android app **on their own laptop, with the Studio alone**: no GitHub account, no access codes, no results repository, no internet needed for the build. This replaces the build-service route as the way staff work (`docs/CUSTOMER-BUILDS.md` stays as an optional route, not needed once local assembly exists). The way: **assemble, never build**. The website and the app are made once per release, as finished compiled programs that are **the same for every customer**; each customer's name, colours, settings and design pack are **data read when the program starts** (a customer folder placed beside it), so the Studio only places that folder and zips (`CLAUDE.md` section 8: everything a customer sees is a setting). **Source code is never on a staff laptop** (`CLAUDE.md` section 3, kept): the laptops hold only the compiled, name-hidden programs, the same as a customer receives. The finished programs for a release are made once by the owner or an engineer (the release workflow, or the owner's own PC) and handed to the Studio as a **kit**.
- **Security against leaking and copying (honest: copying cannot be made impossible; this makes it hard, traceable and useless to the copier):** (1) no source code, no signing key and no licence-signing key on any staff laptop; (2) the kit is **stored encrypted** and opens only for a licensed Studio on that laptop; a Studio licence is device-bound and the owner switches it off when a person leaves; (3) every output carries a **hidden mark** (customer, person, time) so a leaked copy points to where it came from; every action is in the Studio's activity record; (4) the programs themselves are name-hidden and need a valid licence, so a copy on another PC does not run; (5) disk encryption, no administrator rights and no USB sticks are the company's own IT rules and cannot be enforced by the software.
- **Today:** **Not built.** The website still takes its settings at build time (about 13 source files read `NEXT_PUBLIC_*` values); the Studio's one-button route for the website and app goes through GitHub (written and merged, never run for real); the Android app needs per-customer changes to a compiled app (name, icon, package name, address, signing) and a local way to do that is not built yet; there is no encrypted kit and no hidden mark. The Hub's installer pack is already assembled locally from a release's files.
- **Open (to be decided with the owner when it matters):** the Android route (a small local patching tool bundled in the Studio, or a one-time extra download for the person who makes apps).

### 24. The Studio carries the programs inside it (a kit), so staff need no download

- **Said (the owner, in their own words):** "make the studio have inbuilt installer then no need of github or any cloud service while build everything run and tested locally and when final then pos and addon ai goes to customer laptop website to online and apk to customer".
- **Rule:** One Studio installer for the staff laptop that **already contains every program a customer can receive**: the shop program (Windows and Linux), the AI add-on's Windows setup, the website package and the Android files, with a `base-kit.json` of fingerprints. Staff do not download a release or choose a "programs folder"; the Studio uses its built-in kit unless an administrator points it at a newer one. Staff try each customer's setup locally. **At hand-over:** the POS and the AI add-on go to the customer's laptop, the website goes online, the APK (and the Play package) goes to the customer. The kit is made once per release by the owner or an engineer. No licence bypass for testing (`CLAUDE.md` section 3): a test PC uses a test licence from the Licence Studio.
- **Today:** **Not built.** Three helper agents were started on it and stopped before they made any commit (7 October 2026). The Studio still needs a programs folder from a release, and the AI add-on's installer is made by hand on a Windows PC (it is not built by the release workflow).

### 25. Reuse first: edit and use the existing programs; never build a new one instead without the owner's yes

- **Said (the owner, in their own words):** "then what are you doing i wanted you to edit and use it or else i will be wasting resources to create from start" and "if we create everything from start and write the codebase will it not waste resource and time thats why i wanted to reuse old one made the appropriate changes and make it great and you did opposite or else why would i have all of it added in codebase explain it that why i wanted a file with full rule and what i wanted so you do no hallucinate".
- **Rule:** The existing programs in this repository (the Windows POS `apps/pos-desktop`, the AI add-on `apps/pos-ai-companion`, the dashboard `apps/pos-dashboard-service`, the website and Android app `apps/storefront-web-mobile`) are the owner's product and **the starting point of every change**. Before anything new is built, an assistant looks for the existing program that does the job, says what it found, and **reuses and edits it**. A new program that replaces or sits beside an old one is built **only after the owner has said yes to that**, having been told in plain words what exists, why it is not enough, what the new one costs and what would be lost. "Continue" is not a yes. `CLAUDE.md` section 17 says this; `docs/OWNER-REQUESTS.md` keeps the owner's own messages so nothing depends on an assistant's memory.
- **What the record shows (7 October 2026):** the owner asked, on 5 October, for the product to be sellable to "any type" of retail store in any country, and later that it "works for each and every business whether retail store, restaurant or library or construction company". **There is no message in which the owner asked for a new shop program, and none in which an assistant asked first.** The Business Hub (`apps/business-hub`) was built by an assistant as a new program for every kind of business and country, beside the old Windows POS, because the old POS is a retail till for Indian GST. That decision should have been put to the owner first.
- **What the old programs got instead of a rewrite:** the signed licence is enforced in them (the gate's "enforcement" check: every product entry point checks the licence); the brand comes from the licence; the shared tax libraries; the AI add-on's pictures follow the customer's profile and it has the model list, thinking levels and CLI updates; the website and the Android app are the old code with a licence and a brand kit. They were edited, not replaced. Only the shop program for other trades and countries is new.
- **The question this raised, and the owner's answer:** which program is the shop program that customers get? The owner answered with decision 26.

### 26. One shop program: merge the older Windows POS and the Business Hub, delete the rest

- **Asked:** Which program should be the shop program that customers get: both (old POS for Indian retail, Hub for the rest), the old POS edited, or the Hub with the old POS kept for existing customers?
- **Answer:** "merge it fool make the best out of it and delete rest instead of wasting the token".
- **Rule:** **One shop program.** The Business Hub is the host (it is the one that builds by itself, makes a new customer's database, runs on Windows and Linux, serves every trade and country, and has the licence and white-label); **the older Windows POS's features and business rules are brought into it, screen by screen, from the recovered source** (397 screens, grouped in `docs/MERGE-PLAN.md`), with a test that pins every money rule, and with the old POS's own way kept where it is better. **The rest is deleted** from the repository: each piece of the older POS is removed **only after the Hub does the same job and a test shows it**, one commit per group so any of them can be undone; history is kept; nothing is deleted first. The order of work, the delete list and what is needed from the owner (the database scripts or a backup of a working database; the screens used every day) are in `docs/MERGE-PLAN.md`. Releases and tags are deleted only when the owner says so for that action (`CLAUDE.md` section 12).
- **Today:** **Nothing is ported or deleted yet.** The plan is written. The first step is a reader for the older POS's SQL Server database (decision 17).

### 27. The recovered Windows POS software is the owner's: never ask again

- **Said (the owner, in their own words):** "and that recovered software is mine dont fucking ask me again after wasting so much resource".
- **Rule:** The recovered Windows POS source (`apps/pos-desktop` and its companion libraries) **belongs to the owner. This is settled. No assistant and no document asks the owner for proof of ownership, a lawyer's opinion or original paperwork about it, and none lists it as an open item or as something "not verified".** It was removed from the gate's NOT VERIFIED list and from `docs/OPEN-WORK.md`. (Separate and still in force: the licences of third-party libraries are listed and noticed as `CLAUDE.md` section 3 says; that is a duty of the build, not a question to the owner.)
- **Today:** Done: removed from the gate's list and from the documents that called it open (`docs/OPEN-WORK.md`, `docs/COMMERCIALIZATION_READINESS.md`, `docs/SECURITY-MODEL.md`, `docs/MERGE-PLAN.md`).

### 28. The repository holds only four things; the rest is deleted, and the history too

- **Said (the owner, in their own words):** "there should be only 4 thing in codebase one supper installer aka studio 2nd offline software all merged and greatest and user freindly as if created by apple for design and microsft for enterprises 3rd the website 4th the apk rest delete and delete git history nothing to be traced clean and smooth resporitory and dont waste my time and resource any doubt ask one by one".
- **Rule:** The repository ends up with **four things**: (1) the **super installer, the Studio**; (2) the **offline software**, all merged (the older Windows POS, the Business Hub, the AI add-on and the dashboard become one program), with Apple-like design and Microsoft-like enterprise strength; (3) the **website**; (4) the **Android app (APK)**. Everything else is deleted, and **the git history is deleted so that nothing old can be traced**. Doubts are asked **one at a time**, and not repeated.
- **Two steps cannot be undone** (deleting the older programs once their features are merged, and deleting the history), so they are done **last**, only after the owner has answered the questions below, and **the history is deleted only when the owner says "go" for that step** (`CLAUDE.md` section 12). The questions are asked one by one in the conversation and the answers are added here.
- **Answers to the questions, one by one (7 October 2026):**
  1. *Do you keep your own copy of the old POS, the AI add-on and the dashboard outside this repository?* **"Yes, I keep my own copy".** So deleting them from the repository, and the history, loses nothing for good.
  2. *Where should the Licence Studio live, since it is not one of the four things?* **"Inside the Studio's folder, for you only".** The final tree has four things; the Studio's folder holds the staff Studio and the owner's licence part. **The staff installer never contains the licence part or any key.**
  3. *How should the history be deleted so that nothing old can be traced?* **"A new empty repository with one first commit".** The owner creates a new private repository and gives the assistant access; the clean four-part code goes in as one first commit, with no history, no old releases, no old pull requests and no old branches; the owner then deletes or archives this repository. This step is done **last**, and the old repository is only touched by the owner.
- **Order of work:** (1) merge the older programs' features into the one offline software, in this repository, using its present folders (`docs/MERGE-PLAN.md`); (2) delete each older program once it is merged and tested (git history still holds it until the end); (3) move to the final four-folder layout (`studio/`, `software/`, `website/`, `apk/`, plus the rules and a few documents) **as the first commit of the new repository**, so nothing is moved twice.
- **Today:** Nothing is deleted yet. The merge (decision 26) is the work before any deletion: removing a program before its features are merged would lose them for good.

### 29. Learn from the old programs first, once, and write it down

- **Said (the owner, in their own words):** "yes but first learn from old one so that you do not waste resource rethinking rewriting and retesting it thats why i wanted to merge and upgrade it".
- **Rule:** Before an older program's feature is ported, it is **studied once** and written into a knowledge file in `docs/old-programs/`: what a person sees, the tables and columns, **the rules and formulas step by step with source file and line**, the flow, quirks and probable bugs, **worked test examples** (they become golden tests in the Hub, so nothing is retested from scratch), what the Hub already has and where the numbers would differ, porting notes, and what is not understood. **Porting reads those files and not the raw source again;** a person who learns something new adds it to the file. The files: `01-selling-buying-stock.md`, `02-masters-accounting-reports.md`, `03-india-tax-and-staff.md`, `04-settings-messaging-system.md`, `05-ai-addon-and-dashboard.md`, `06-hub-map.md` (where a new feature plugs into the Hub), `DATABASE.md` (which column means what). The old programs' existing tests (the AI add-on has about 540) are reused as characterization tests where they apply. Same rule as `CLAUDE.md` section 17.
- **Today:** The study is being written (started 7 October 2026). Nothing is ported until the file of its area exists.

### 30. Two looks: a tall one and a wide one

- **Said (the owner, in their own words):** "make sure software has longitudnal and well as lateral look because when people using software they like longitudnal and when using touch screen then latitudnal".
- **Asked:** what does "longitudinal" mean? **Answer (the owner chose):** "A vertical, list-style look on a normal monitor".
- **Rule:** the offline software has **two looks**. The **vertical look ("longitudinal")** is for people using a normal PC or laptop monitor: the menu at the top, and the screens laid out as long vertical lists and forms that are scrolled down (the bill below the items). The **wide look ("lateral/latitudinal")** is for **touch counter screens**: big touch targets, the menu on the left, the items in the middle and the bill on the right, all visible at once. Every screen works and looks right in **both**; none is usable in only one. The look is a **setting** of the device (the theme already has density, menu position and bill position settings; the two looks are presets of them plus the screen layouts): **automatic** (touch screen: wide; otherwise: vertical) and **changeable by the owner per device**. The website and the Android app follow the same idea for the shopper's screen shape. Tested in both looks.
- **Today:** **Built in the Business Hub (7 October 2026), with these limits.** *Settings → Look → The two looks*: the owner picks **As it was**, **Each screen decides** (a touch screen gets the wide look, any other screen the vertical look), **List look** or **Counter look** for the whole shop; and each computer can have its own look (**On this computer only**, kept in that browser). The vertical look is the menu along the top, the items as rows you scroll down, the bill below; the wide look is big buttons (touch size), the menu on the left, the items in the middle, the bill on the right. A look is a bundle of the settings the theme already had (button size, menu place, bill place, text size), so **no licence-format change was needed**. Tests: `ShopLookTests` (the values in code and in `theme.js` are equal; the choice is kept) and the browser test `e2e/looks.e2e.mjs` (both looks on the sell screen, "each screen decides" on a mouse screen and on a touch screen, the per-computer choice, going back). **Not done yet:** (1) the default is still **As it was** until the owner chooses; making "each screen decides" the default for new shops is a one-line change but moves the existing shop's screens, so it needs the owner's word; (2) only the sell screen has a different shape in the two looks, the other screens follow the menu, button-size and bill-place settings and are not yet checked one by one in both looks; (3) a customer's profile (`theme.json`) cannot yet carry the look; (4) the website and the Android app do not have the two looks yet. The older Windows POS's touch till (`frmPOSNewTuch`) remains the model for the wide look.

### 31. Loyalty points: per item, with a money value per point

- **Asked (7 October 2026):** The older POS has two ways to give loyalty points (a percent of the whole bill; or points per item with a money value per point, kept in a points ledger). Which one should customers get? (`docs/old-programs/02-masters-accounting-reports.md`, A1.6)
- **Answer (the owner chose):** "Points per item, with a money value per point (Recommended)".
- **Rule:** The shop program has **one** loyalty scheme: each product earns its own points, a point is worth a set amount of money when spent, and every customer has a points ledger. The percent-of-the-bill scheme is not ported. The traps the study lists (a cancelled bill must not burn a voucher; gift expiry must expire; a coupon's start date must be checked) are fixed, not copied. Old customers' points come across as opening points (decision 17).
- **Today:** Not built. Study 02 has the formulas and test vectors.

### 32. Accounting books: proper double entry

- **Asked (7 October 2026):** The older POS keeps accounts as one line per event and its trial balance does not add up (the study's worked example is out by 4,900). Copy the old books, build proper double-entry books, or leave the books for last?
- **Answer (the owner chose):** "Proper double-entry books (Recommended)".
- **Rule:** The Hub gets **real double-entry books**: every sale, purchase, receipt, payment, return and stock change is posted so that debits equal credits, and the trial balance, profit and loss and balance sheet always agree. Old customers' and suppliers' balances and the stock value come across as **opening entries**; old bills are never re-posted or recalculated. The old books' reports (day book, bank, contra, income and expense and the rest) are rebuilt on the new books, with the old POS's numbers as test examples only where they are right.
- **Today:** Not built. The Hub has no accounting module (`docs/old-programs/06-hub-map.md`).

### 33. A discount on the whole bill lowers the tax too

- **Asked (7 October 2026):** The older POS takes a bill discount off the total after tax and leaves the tax unchanged (bill 194.19 with 34.20 tax stays 34.20). What should the new program do?
- **Answer (the owner chose):** "Discount lowers the tax too (Recommended)".
- **Rule:** A discount on the whole bill is **spread over the items first, and the tax is worked out on what is left.** Line discounts (percent or amount) work the same way. Old bills are not recalculated. A test pins the example from the study (`docs/old-programs/01-selling-buying-stock.md`, B4).
- **Today:** **Built (7 October 2026).** Line discount by percent or amount, and a whole-bill discount by amount or percent, spread over the lines before tax with the largest-remainder rule so the parts add up exactly (`DocumentService.Allocate`); the tax engine is unchanged, it is given each line's discount as an amount. Credit notes give back a line's exact share of what was taken off. Cashiers need the owner's limit (*Settings → Business*); owners and managers do not. Tested by `DiscountTests` (the study's examples L2, L3, L13 and the bill example B4 with the new rule: 165.19 where the old POS gave 174.19) and the browser scenario `e2e/discounts.e2e.mjs`. **Not done:** discount by a customer's standing discount, an offer or a coupon (customers work package); a 'discount' wording setting per customer; the same discount on purchases; cess and per-item tax mode (separate gaps in study 01, 7.1).

### 34. Returns: the cashier chooses cash back or credit on the account

- **Asked (7 October 2026):** A customer brings goods back: always cash back, always credit on the account, or the cashier chooses?
- **Answer (the owner chose):** "Cashier chooses: cash back or credit on the account (Recommended)".
- **Rule:** Every return asks **cash back now, or keep it as credit on the customer's account** for a later bill. Both are written in the customer's account and in the books. A return on an unpaid credit sale **lowers what the customer owes** (today a Hub credit note does not). Credit on the account needs a named customer.
- **Today:** Not built. The Hub's credit note exists but does not touch what a customer owes.

### 35. An estimate shows the tax, so the bill matches

- **Asked (7 October 2026):** In the older POS an estimate shows no tax, so the bill made from it is dearer (estimate 180.00 became bill 212.40). What should an estimate do?
- **Answer (the owner chose):** "Show the tax, so the bill matches (Recommended)".
- **Rule:** An estimate (quotation) for a shop sale is worked out **exactly like a bill, with the same tax**; turning it into a bill gives the same total unless prices changed. Estimates for shop sales are new in the Hub (today it has quotes for construction projects only).
- **Today:** Not built.

## Still to ask, and open items

- Pricing details: how many PCs the one price covers; the price of extra PCs and extra features such as AI; what the one-time fee includes (updates and support for how long).
- Languages and training; who answers the phone and in which hours; whether the match report before go-live (decision 17) is accepted.
- A sentence for the contract about what may go to an outside AI service (decision 10) and about the final unlock (decision 16): counsel.

## The order the assistant proposed (the owner has not changed it)

1. Run the first real trial build of a made-up customer on GitHub (the owner's set-up steps are in `docs/CUSTOMER-BUILDS.md`).
2. A store with a main PC and counter PCs on the shop's own network (decision 4): the biggest gap.
3. The licence button and the 2-a-year move (decisions 2 and 3).
4. Nightly local backup (decision 11).
5. Updates through the main PC (decision 7).
6. The styling layer for the website and app (decision 6).
7. The hosting service (decision 8).

Ideas the assistant offered that the owner has not turned down or asked for yet: one page per client in the Studio (licence, PCs, version, last backup, last build); starting a project from a trade template; a hand-over page per client with the activation code and a QR code for the app; a time-limited trial licence for sales demos; counter PCs paired by QR code; a support file a client can send that holds no shop data.
