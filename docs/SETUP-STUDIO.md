# The Setup Studio

*For NextGenOS staff only. It is never packaged with anything a customer receives.*

The Setup Studio turns what you learn about a customer (their business, country, look, machine, words and first items) into **one customer pack**: the programs they need, with their own set-up beside them, and a hand-over page. A salesperson fills in the details, an AI tool can help improve the set-up, a second person approves it, and the Studio makes the pack. Nothing is installed on the customer's machine by the Studio; the pack is what you give them.

## Starting it

| Where | How |
|---|---|
| Windows | Double-click **Setup Studio** (the icon with the blue box) in the unpacked folder. If something goes wrong, open `Setup Studio (with a window, for problems)` and read what it says. |
| Linux | Run `./setup-studio.sh` once (the terminal can be closed at once). `./setup-studio.sh --install-menu` puts "NextGenOS Setup Studio" in the applications menu; `./setup-studio.sh --show` runs it in the terminal for finding a problem. |
| From the repository | `node tools/setup-studio/studio.mjs serve --app` (a window of its own) or `serve --open` (in this terminal, and a tab in your usual browser) |

**It opens as a program of its own: a window with no address bar and no black terminal window behind it.** The window is the PC's own Edge (every Windows 10 and 11 has it), or Chrome or Chromium on Linux, opened in "app" mode with a profile of its own, so it never touches your own browsing. On a PC with none of these it opens in your usual browser, as a tab.

- **One Studio at a time.** Opening it again while it is open brings up its window; it never starts a second Studio on the same files.
- **To stop it:** close its window, or press the power button at the bottom left of the Studio. A Studio that nobody has had open for ten minutes stops by itself (a sleeping PC is not counted). The page says plainly when the Studio has stopped.
- **A problem at start-up** is written in a note, `Setup Studio problem.txt`, which opens by itself (there is no terminal to show it).
- Staff who want a particular browser can set `SETUP_STUDIO_BROWSER` to its full path (it must be a Chromium-based one).

The page is served by a small program **on your own PC only** (`127.0.0.1`); the address holds a secret that is new every time the Studio starts, so nothing else on the PC or the network can use it.

The first time, it asks you to make the administrator account. The Studio keeps its files in `Documents/NextGenOS Setup Studio` (`node tools/setup-studio/studio.mjs where` tells you). **Back it up** from Settings; the backup is one zip of everything that cannot be made again.

## Who can do what

| Role | May |
|---|---|
| **Sales** | Add customers, fill in details, prepare and improve the set-up, send it for approval, and see what would be built for the website and app (and exactly what would be sent). |
| **Reviewer** | Everything Sales may, and approve or send back, start the website and app build, make the customer pack, record the hand-over. |
| **Administrator** | Everything, and the team, Settings (the programs folder, connect the build service, the AI tool, keys), backups. |

The person who prepared or sent a set-up **cannot approve it**. An administrator may approve their own work only by writing a reason (at least a few words), which goes in the activity record. Every action is in the **activity record**, a chain in which each line holds the fingerprint of the one before; **Activity** shows whether it still proves itself unchanged.

## The journey of one customer

1. **Details**: who they are, country, kind of business, bills and money, their own words, a first list of items or people (pasted from a spreadsheet), and whether they also get a website, an Android app or the AI assistant.
2. **Look and screens**: colours, logo, style, and the machine (laptop, touch-screen till, tablet, kiosk), with a real picture of the program beside the choices.
3. **Prepare**: the Studio makes the set-up from the details and explains it in plain words. An AI tool may improve it (below); you see every change and accept or refuse.
4. **Review**: a second person checks and approves. Approval makes a **numbered release** that never changes (its files are fingerprinted; the Studio refuses to use one that was altered afterwards).
5. **Website and app**: if the customer gets a website or an Android app, a reviewer or administrator presses one button and the Studio gets them made for this customer and brings them back (below).
6. **Installer**: the Studio makes the customer pack from that release, the programs folder, and the website and app from step 5.
7. **Hand over**: a page for the customer, then the hand-over is recorded.

## The programs folder, and what the Studio does and does not build

**The Studio does not build programs.** NextGenOS builds and releases them (the release workflow on GitHub). The one thing made *for a customer*, the website and the Android app, is made by the build service and fetched by the Studio ("Website and app", below). To make packs you need the files of one release in one folder:

1. On GitHub, open the release and download **every file** into one folder (including `base-kit.json`).
2. In the Studio: **Settings, The programs folder**, type the folder, press *Check and save*.

The Studio checks each file against its fingerprint in `base-kit.json` and says in plain words what is missing, incomplete or damaged. **This protects against a damaged or incomplete download. It is not a signature**: it cannot tell an authentic list from one someone forged, so only download from the real release page. (A signed list is not built yet.)

A release made without the licence keys (a *trial* build) is marked, and the Studio refuses to make a customer's pack from it unless you tick *only to try it*.

## What is in a customer pack

One folder and one zip, `<customer>-pack-release-<n>.zip`, saved in the Studio's `builds` folder and downloadable from the Installer step:

| Part | Contents |
|---|---|
| `START HERE.html` | The hand-over page: what they get, how to put it in place, what the licence allows, who to call. Opens in any browser and prints cleanly. |
| `1 - Shop PC (Windows)` | The Hub's Windows setup, exactly as released, with a `profile` folder **beside it** (their set-up, look and brand, a small `install.ini`, a note) and a page of steps. A touch-screen till or kiosk also opens full screen when the PC starts. |
| `1 - Shop PC (Linux)` | The Hub's Linux packages (Intel/AMD and ARM), a small **profile package** for this customer, `install.sh` (`sudo ./install.sh`), and a page of steps. |
| `2 - AI assistant (Windows)` | If wanted: the AI assistant's setup, with a `profile` folder **beside it** that holds `ai.json` (the customer's own settings for its pictures and posters: see "The AI assistant's own settings" below). **It reads the Windows POS database, not yet the new Hub's data.** It is built on a Windows PC (`apps/pos-ai-companion/build.ps1 -Installer`) and is not part of the release workflow yet, so it is "not in the programs folder" until you add it. |
| `3 - Website` | If wanted: the website's public settings (`website-settings.env`) and a page of steps. The website **built for this customer** (`website-<customer>-windows.zip` and `website-<customer>-linux.zip`) is copied as made, with its fingerprint written on the page, and it carries its own Node.js. It comes from the step "Website and app" (the build service), or from the programs folder when someone put it there. A website built for another customer is never used. When there is none, the page says how to make one. |
| `4 - Android app` | If wanted: the customer's brand kit (what the build reads), and the app itself (the `.apk` to try on a phone, and the `.aab` that the Google Play Store takes) when the step "Website and app" has made it. Without it, the steps to make it. |
| `PACK-CONTENTS.json` | Every file with its SHA-256 fingerprint, the release number, the programs' version, and who made the pack and when. |

### What the Studio still needs, shown on its first screen

The first screen (Customers) shows a card, "Before the Studio can give a customer their outputs", as long as something is missing: **the programs of a release** (the installer comes from a full release's files; a trial release only makes a pack "to try"), **the build service** (each customer's website and Android app are built on GitHub), and **the customer's licence** (made in the Licence Studio by the person who sells; making it from the Studio's output button is planned and not in this version). It says the same in plain words for each, and an administrator opens Settings from it.

### What the Studio does, and what it does not do

Staff open the Studio, start a new project for a new company, fill in its details and make the customer's **pack**: the shop program's setup with the customer's profile beside it, the website's settings and steps, the app's brand kit and steps, and the hand-over sheet. The Studio never builds a program and holds no source code (`CLAUDE.md`, sections 3 and 11).

The customer's **website** and **Android app** have the customer's own name, colours and settings built into them, and making them needs the programs' source code, which never comes to a staff PC. So they are made by a **build service** (a private place where the source is), and the Studio does the asking and the fetching: a reviewer or administrator presses one button in the customer's step **Website and app**, and the Studio gets the files back into the customer's own folder. Staff never open GitHub, a terminal or a build tool for this. **It is written, and tried against a stand-in, but it has not yet been run against the real build service**: see "What was and was not checked".

### Website and app: how it works for staff

1. **An administrator connects the build service once** (Settings, **Connect the build service**; the steps are below).
2. **A reviewer or administrator opens the customer's step "Website and app"** (it opens once a setup is approved; a customer who is to get a website or an app is sent there as the next thing to do). The page says what will be made (the website for Windows and for Linux, the Android app), what is made already, and shows exactly what would be sent, so a salesperson can check it too.
3. **They press the build button.** The Studio sends the build service only this customer's *public* details (their name, colours, contact, logo and the website's public settings, as a small bundle) and asks it to build. **If anything in those details looks like a password or a key, nothing is sent**, and the page says what to take out.
4. **The page shows each step in plain words** (for example "Building the website for Linux", "Building the Android app", "Checking every file against its fingerprint") while it goes on. It can take a good while. **You may close the Studio; the build carries on**, and the Studio picks it up when a reviewer or administrator opens the step again. One build at a time for a customer.
5. **When it is finished** the Studio brings back the files, checks every one against the list of fingerprints the build wrote (a file that does not match is never kept), and puts them in this customer's own folder, from where the installer step takes them into the pack. The activity record says who asked for it and what came back.
6. **If a part did not work**, the page says which one and why, in the words the build wrote. The parts that worked are kept. **Try again** starts a new build (a new number) of what is missing. If the Studio stopped waiting (the internet went, or the build took more than 90 minutes), **Look again** picks it up without starting another.
7. **A trial** (the build service has no licence keys) is marked as one everywhere, and the pack refuses it unless the box "only to try" is ticked. **A trial is never given to a customer.**

What the page also says early, so that nobody waits for a long build to find out: a shop name of more than 40 letters, or with a quote, an &, a < or > or a backslash in it (for example *Joe's Shop*), cannot become an Android app name (the website can still be made); a logo that is not a PNG is left out of the website and the app; the Android app needs the website's name.

Who may do what: **Sales** may see the page and what would be sent; **Reviewer** and **Administrator** start a build and look again; only an **Administrator** connects the build service and changes its codes.

### Connect the build service (once, by the owner or an administrator)

You need: two private places (the repository that holds the programs' source, which exists already, and a second one that holds **no source**, for the results), and two **access codes**, one for each place. Where each code is made, and every click, is in **`docs/CUSTOMER-BUILDS.md`**; in short:

1. Make the results place: a new **private** repository (suggested name `nextgenos-customer-builds`) with a short README, owned by the same account.
2. Make the code for **starting builds**: allowed for the programs' place only, with the permission to run builds and **nothing else** (in particular it must not be able to read the code).
3. Make the code for **keeping the results**: allowed for the results place only, with the permission to read and write its contents and nothing else. The same code is also stored in the programs' place as the secret `RESULTS_TOKEN`, so that the build can read the settings and leave the files (the Studio cannot do this for you).
4. In the Studio: **Settings, Connect the build service**: type the two names (`owner/name`), paste the two codes into their two labelled boxes (a code is kept only in your own user folder on this PC, never in the Studio's files, a pack or a backup, and is never shown again), press **Save** for each, then **Test the connection**.
5. The test says in plain words what is wrong: that the codes are accepted, that the build is there and switched on, that the first code may start builds but **cannot** read the programs' source, that the second can read and write the results place but **cannot** reach the source, and that neither code can see the other's place. A code that is stronger than it should be is reported, not hidden.
6. For real (not trial) builds the programs' place also needs the two public licence values (`NGOS_PUBLIC_KEYS`, `NGOS_LICENCE_URL`), as for a full release. Without them every build is a trial and says so. For an app a customer may keep, the Android signing secrets must be there too (otherwise the app is signed with a one-off test key, which the Studio says).
7. The build must be on the programs' main branch before the Studio can start it.

A code that runs out stops working and the Studio says so; make a new one the same way and replace it in Settings (and the stored copy for the second code).

What the build service must never get, and does not: the Studio's passwords, the AI keys, the licence signing key, a pack, or anything about another customer. What the Studio must never get: the source.

### The website, one build per customer

The website's name, address, country and kind of business are compiled into its pages, so **each customer needs a website of their own**, and the file is named for them: `website-<customer>-<windows|linux>.zip`, where `<customer>` is the customer's short name in the Studio (the same name as their brand kit). The Studio never builds one itself: the build service makes it (step "Website and app"), or the file is put in the programs folder (the Studio checks its fingerprint in `base-kit.json`). Inside the zip: its own Node.js, the built server, the libraries it needs, the database engine and picture library **for that system**, `Start Website` (Windows: a small launcher, no black window) or `start-website.sh` (Linux), which open the website in a window of its own (it listens on this computer only, on port 3000 unless told otherwise), a plain `READ ME FIRST.txt`, `private-settings.example.env` (the list of the database address, passwords and keys that the person who puts it online must fill in; none of them is in the package) and `prerequisites.json`. It holds no source, no `.env`, no key, no database and no licence, and the licence check stays in force: with no licence it shows a plain "not available" page.

The Studio's button does this for any customer. **By hand**, without the Studio, there are still two ways:

1. **The customer is in `brand-kits/`** (the repository holds their brand kit): on GitHub open *Actions, Release, Run workflow* and choose the kit. The workflow builds the website for Linux and for Windows (each on its own system) and puts `website-<kit>-linux.zip` and `website-<kit>-windows.zip` on the release.
2. **The customer is not in the repository** (nothing about them is added to it): on the same page type their short name in *Website customer* and, in *Website settings*, the one line that their pack's `3 - Website\READ ME FIRST.txt` shows (their public settings, separated by semicolons; it holds no password or key). The workflow then builds the website from those settings.

Two honest limits. **GitHub shows the *Run workflow* button only for a workflow file that is on the repository's default branch**, so until this work is merged, it cannot be started by hand from the page; and a run by hand builds the whole release (the Hub, the app, the Studio bundles) as well, from which you take only the website files. From a computer with Node.js 22 and the repository you can also make one directly: `node scripts/make-website-package.mjs --os linux --version 1.0.0 --customer <name> --settings website-settings.env --download-node 22.22.0` (a Windows website must be made on Windows). The licence keys must have been built in first (the workflow does it with `apply-public-keys`); without them only a **trial** build can be made (`--allow-no-key`), marked on its face with `NO-LICENCE-KEYS-TRIAL-ONLY.txt`, which can never be licensed and is never given to a customer.

A public value that looks like a secret key (a Firebase web key starts with `AIza`, for instance) is refused when the package is made, because the package check refuses any value that looks like a key: such a website needs that setting entered another way, and the owner must decide how.

The **profile** is only data: `setup.json` (how the business is set up, read at the Hub's first run), `theme.json` (the look) and `brand.json` (the name, colours, logo). The licence still decides how much of the look the owner can change.

**The pack never holds a licence key**, a signing key, a database or any source code. The Studio runs the package audit over every pack in its tests.

### Putting a pack in place

- **Windows:** keep the folder together, double-click the setup, say Yes to Windows' permission question, open the browser window it shows, type the licence key. Windows warns about an unknown publisher until the setup is signed with the owner's certificate (the page of steps tells the customer what to click).
- **Linux (Ubuntu 22.04/24.04, Mint 21+, Debian 12+):** `sudo ./install.sh`, or open both `.deb` files in the software centre. The Hub runs as a background service under its own account; the shop's information is in `/var/lib/nextgenos` and is **never** removed, even when the program is uninstalled or purged.
- Nothing has to be installed first. Each package carries its own .NET runtime and native libraries; the system supplies only what [PREREQUISITES.md](PREREQUISITES.md) lists.

## The AI assistant's own settings (`profile/ai.json`)

The AI assistant makes product photos, posters and ads. What those show is the customer's, never the program's (`CLAUDE.md`, section 8): the country, the kind of business, who the three model photos show, the festivals of the shop's customers and the second language of its posters. With nothing set, the assistant is neutral: no country, no festival, no second language, and models with no look asked for ("Model 1", "Model 2", "Model 3").

**What the salesperson fills in.** In *Details*, *Extras and licence*, switch on *The AI assistant (Windows)*: a section appears, and everything in it is optional.

- **The business.** The country's name comes from the country list and the kind of business from the kind of business chosen, as a suggestion shown in the box. Type over it to say it differently ("the Philippines" instead of "Philippines").
- **People in the product photos.** Photos 3, 4 and 5 of each product show a person. Give each a name for the screen and, if wanted, a few words on who the person looks like.
- **Festivals.** The ones this shop's customers keep. Up to 24.
- **A second language on posters.** The country list names a country's languages; the ones other than English are offered as buttons, and another can be typed (a name and a short code like `hi` or `fil`). Ready-made lines for the four poster kinds (clearance, new arrivals, best sellers, festival offer) are optional; where one is empty, the line is written when the poster is made.

A box on the page says, live, what the settings change. **The country and industry lists carry no festivals and no looks of people**, so those are always typed; the Studio never suggests them from code.

**The file.** The Studio writes `ai.json` (schema 1: `country.name`, `shopKind`, and under `images`: `models`, `festivals`, `localLanguage` with its `name`, `tag` and `lines`) from the approved release into `2 - AI assistant (Windows)/profile/`. The AI assistant's setup copies a `profile\ai.json` that sits beside it into its install folder; the program and its dashboard read it from there. A quiet update that the app starts itself has no such folder beside it, so the file already installed is kept; a new `profile` folder replaces it; uninstalling removes it (the shop's own settings are kept). The file holds no password or key.

**One set of rules on both sides.** The Studio refuses what the program would leave out (length, `< > " \` and line breaks, the language tag, 24 festivals, 3 models), and the file the Studio writes is read back by the same rules before the pack is made. Both sides read the same cases: `apps/pos-ai-companion/tests/vectors/ai-profile.json` (made by `node tools/setup-studio/scripts/make-ai-profile-vectors.mjs`), checked by the Studio's tests and by the AI assistant's own tests.

**A customer whose pictures and posters used to be fixed in the program** keeps them as data: its brand kit holds an `ai.json` of the same format (`brand-kits/<customer>/ai.json`). The Studio has no way to import a brand kit, so the salesperson types the same values in the section above, or the file is put by hand in a `profile` folder beside the AI assistant's setup.

**NOT checked** (a person must): that a description gives good, fitting or respectful pictures (the AI makes them; try a few products at the first visit); that a festival or language is named correctly for the shop's customers; the AI assistant's setup copying the file on a real Windows PC and keeping it through a real update (the setup compiles here, and `apps/pos-ai-companion/installer/test-update.sh` checks it under Wine, but Wine is not part of the gate and was not available when this was written).

## Before it goes to the customer

- Make their **licence key** in the Licence Studio (number of PCs, white-label level, brand). The key is private to you and never in the pack.
- Open `START HERE.html` and the page of steps for their machine and check they say the right things.
- If you can, try the pack once on a clean computer of the same kind. **The Studio cannot do that for you** (see below).

## What the AI tools may and may not do

An AI tool is optional. You choose one in **Settings** (Claude Code, Codex, Antigravity, any other command-line tool, or the Claude, OpenAI or Gemini services with a key). For each you can pick **any model it offers** and **any thinking level it offers**, and look at its **version and whether an update exists** (and update it, for the tools that can).

- **What is sent:** only what the Studio shows under *Show exactly what would be sent*: the business's name and tagline, kind, country, look, machine, payment ways, words and choices, how many items and people were brought in, and **the notes staff wrote** (so do not write private things in the notes). **Phone numbers, emails, addresses, the lists of items and people, and keys are not sent.** The AI service or tool you choose then handles that text under its own terms.
- **What it may do:** answer in words. The Studio never passes options that let a tool run commands, change files, browse, or skip its safety questions (`--dangerously-skip-permissions`, tool lists, extra folders, remote or background modes, and the like are refused whoever asks).
- **What its answer is:** untrusted text. It is read again by the same rules as everything else; the customer's name, country, kind of business, items and people are **locked** and cannot be changed by it; anything the program does not understand is left out and said. You see a list of changes and **accept or refuse**. A person accepts; the second person still approves.
- **Keys** live in your own user folder (never in the workspace, a backup or the activity record) and are never shown again.

## What was and was not checked

Checked here, by tests that run in the release gate (`node scripts/verify-all.mjs --full`):

- the rules the Studio and the Hub share (test vectors), the roles and the approval rule, the activity record, the release fingerprints;
- the whole journey in a real browser (Chromium), from first sign-in to a downloaded pack;
- the pack: the programs folder checks, what is copied and what is added, trial refusal, names that try to escape the folder, the audit of a finished pack;
- the Hub's **Windows setup** under Wine with a stand-in program (install, update, uninstall, the profile folder, the full-screen shortcut) and the Windows Hub's prerequisites (every native file imports only what Windows itself has);
- the Hub's **Linux package** with real `dpkg` on the machine running the gate: installed, started as its own unprivileged account, refused without a licence, given a profile package, removed, the shop's data kept;
- the **website and app step** against a stand-in for the build service on the machine running the gate (it speaks only what the Studio uses, and plays the build): a build that works and its files kept, a part that failed, a trial, a wrong access code, the internet dropping, a build that takes too long, a file that does not match its fingerprint, a bundle that holds something that looks like a secret (nothing is sent), no access code in any file the Studio writes, any message or the activity record, who may do what, a Studio closed in the middle of a build, and the whole walk through a real browser (connect, test, build, watch, pack);
- the **website package for Linux**, really built on the machine running the gate (`next build`, its own Node.js from nodejs.org checked against its fingerprint): both audits pass, it is unpacked and started with its own Node.js, refuses visitors and programme calls without a licence, and with a licence from a real Licence Studio serves its pages in the licence's brand, and refuses another web address, an edited licence file and a withdrawn licence.

**NOT checked** (a person must): **the build service for real**: the Studio's button, the build and the fetching have not been run against the real build service with the owner's repositories and access codes (nothing here can reach them), so whether the real service accepts every request exactly as written, what the two codes really allow, how long a build takes and what it costs are not known until the first real build; try a trial build for a made-up customer first; that the list of fingerprints the build writes is not a signature (it protects against a damaged download, not against someone who can write in the results place); the Windows setup on a real Windows 10/11 PC; the Linux package under a real systemd and a real desktop, and on Mint or Debian (only the Ubuntu-family tooling of the build machine was used); a real printer, scanner, cash drawer or touch screen; the Android app; the **website package for Windows** (it is built, audited and started by the release workflow on a Windows machine, never on a real shop PC) and the website's pages with a real database, sign-in and picture storage (the package is started with none of them); the AI tools' real services (stand-in programs and services were used); code signing; whether a customer's PC has the internet the licence activation needs. The list in `PREREQUISITES.md` says what each machine needs.
