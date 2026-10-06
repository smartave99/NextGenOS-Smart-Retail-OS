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
| **Sales** | Add customers, fill in details, prepare and improve the set-up, send it for approval. |
| **Reviewer** | Everything Sales may, and approve or send back, make the customer pack, record the hand-over. |
| **Administrator** | Everything, and the team, Settings (the programs folder, the AI tool, keys), backups. |

The person who prepared or sent a set-up **cannot approve it**. An administrator may approve their own work only by writing a reason (at least a few words), which goes in the activity record. Every action is in the **activity record**, a chain in which each line holds the fingerprint of the one before; **Activity** shows whether it still proves itself unchanged.

## The journey of one customer

1. **Details**: who they are, country, kind of business, bills and money, their own words, a first list of items or people (pasted from a spreadsheet), and whether they also get a website, an Android app or the AI assistant.
2. **Look and screens**: colours, logo, style, and the machine (laptop, touch-screen till, tablet, kiosk), with a real picture of the program beside the choices.
3. **Prepare**: the Studio makes the set-up from the details and explains it in plain words. An AI tool may improve it (below); you see every change and accept or refuse.
4. **Review**: a second person checks and approves. Approval makes a **numbered release** that never changes (its files are fingerprinted; the Studio refuses to use one that was altered afterwards).
5. **Installer**: the Studio makes the customer pack from that release and the programs folder.
6. **Hand over**: a page for the customer, then the hand-over is recorded.

## The programs folder, and what the Studio does and does not build

**The Studio does not build programs.** NextGenOS builds and releases them (the release workflow on GitHub). To make packs you need the files of one release in one folder:

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
| `3 - Website` | If wanted: the website's public settings (`website-settings.env`) and a page of steps. When the programs folder holds a website **built for this customer** (`website-<customer>-windows.zip` and/or `website-<customer>-linux.zip`), it is copied as released, with its fingerprint written on the page, and it carries its own Node.js. A website built for another customer is never used. When there is none, the page says how to make one (see "The website, one build per customer" below). |
| `4 - Android app` | If wanted: the customer's brand kit (what the release workflow reads) and the steps to build the app; or the signed app itself when you have added it to the programs folder. |
| `PACK-CONTENTS.json` | Every file with its SHA-256 fingerprint, the release number, the programs' version, and who made the pack and when. |

### The website, one build per customer

The website's name, address, country and kind of business are compiled into its pages, so **each customer needs a website of their own**, and the file is named for them: `website-<customer>-<windows|linux>.zip`, where `<customer>` is the customer's short name in the Studio (the same name as their brand kit). The Studio only copies it (after checking its fingerprint in `base-kit.json`); it never builds one. Inside the zip: its own Node.js, the built server, the libraries it needs, the database engine and picture library **for that system**, `Start Website.bat` or `start-website.sh` (listens on this computer only, on port 3000 unless told otherwise), a plain `READ ME FIRST.txt`, `private-settings.example.env` (the list of the database address, passwords and keys that the person who puts it online must fill in; none of them is in the package) and `prerequisites.json`. It holds no source, no `.env`, no key, no database and no licence, and the licence check stays in force: with no licence it shows a plain "not available" page.

To make one for a customer, in either of two ways:

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
- the **website package for Linux**, really built on the machine running the gate (`next build`, its own Node.js from nodejs.org checked against its fingerprint): both audits pass, it is unpacked and started with its own Node.js, refuses visitors and programme calls without a licence, and with a licence from a real Licence Studio serves its pages in the licence's brand, and refuses another web address, an edited licence file and a withdrawn licence.

**NOT checked** (a person must): the Windows setup on a real Windows 10/11 PC; the Linux package under a real systemd and a real desktop, and on Mint or Debian (only the Ubuntu-family tooling of the build machine was used); a real printer, scanner, cash drawer or touch screen; the Android app; the **website package for Windows** (it is built, audited and started by the release workflow on a Windows machine, never on a real shop PC) and the website's pages with a real database, sign-in and picture storage (the package is started with none of them); the AI tools' real services (stand-in programs and services were used); code signing; whether a customer's PC has the internet the licence activation needs. The list in `PREREQUISITES.md` says what each machine needs.
