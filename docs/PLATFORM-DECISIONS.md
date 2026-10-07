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
- **Today:** A **starter list of items and people** can be pasted from a spreadsheet in the Studio and is applied when the shop is first set up (`docs/SETUP-STUDIO.md`). **Not built:** the import of sales history, balances owed and stock movements; the reader of SQL databases (SQL Server, MySQL or MariaDB, PostgreSQL, SQLite); the mapping helper; the match report. The Windows POS in this repository (`apps/pos-desktop`) is the owner's own old system and the natural first SQL reader.

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
