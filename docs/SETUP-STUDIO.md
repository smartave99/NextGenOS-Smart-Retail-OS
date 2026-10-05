# The Setup Studio

*For NextGenOS staff only. It is never packaged with anything a customer receives.*

The Setup Studio turns what you learn about a customer (their business, country, look, machine, words and first items) into **one customer pack**: the programs they need, with their own set-up beside them, and a hand-over page. A salesperson fills in the details, an AI tool can help improve the set-up, a second person approves it, and the Studio makes the pack. Nothing is installed on the customer's machine by the Studio; the pack is what you give them.

## Starting it

| Where | How |
|---|---|
| Windows | Double-click `Setup Studio.bat` |
| Linux or macOS | Run `./setup-studio.sh` |
| From the repository | `node tools/setup-studio/studio.mjs serve --open` |

It opens a page in your web browser. The page is served by a small program **on your own PC only** (`127.0.0.1`); the address holds a secret that is new every time the Studio starts, so nothing else on the PC or the network can use it. Close the window and the Studio stops.

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
| `2 - AI assistant (Windows)` | If wanted: the AI assistant's setup. **It reads the Windows POS database, not yet the new Hub's data.** It is built on a Windows PC (`apps/pos-ai-companion/build.ps1 -Installer`) and is not part of the release workflow yet, so it is "not in the programs folder" until you add it. |
| `3 - Website` | If wanted: the website's public settings (`website-settings.env`) and a page of steps. **No built website is included yet**: the release does not build one (its public settings are compiled in, so each customer needs their own build). |
| `4 - Android app` | If wanted: the customer's brand kit (what the release workflow reads) and the steps to build the app; or the signed app itself when you have added it to the programs folder. |
| `PACK-CONTENTS.json` | Every file with its SHA-256 fingerprint, the release number, the programs' version, and who made the pack and when. |

The **profile** is only data: `setup.json` (how the business is set up, read at the Hub's first run), `theme.json` (the look) and `brand.json` (the name, colours, logo). The licence still decides how much of the look the owner can change.

**The pack never holds a licence key**, a signing key, a database or any source code. The Studio runs the package audit over every pack in its tests.

### Putting a pack in place

- **Windows:** keep the folder together, double-click the setup, say Yes to Windows' permission question, open the browser window it shows, type the licence key. Windows warns about an unknown publisher until the setup is signed with the owner's certificate (the page of steps tells the customer what to click).
- **Linux (Ubuntu 22.04/24.04, Mint 21+, Debian 12+):** `sudo ./install.sh`, or open both `.deb` files in the software centre. The Hub runs as a background service under its own account; the shop's information is in `/var/lib/nextgenos` and is **never** removed, even when the program is uninstalled or purged.
- Nothing has to be installed first. Each package carries its own .NET runtime and native libraries; the system supplies only what [PREREQUISITES.md](PREREQUISITES.md) lists.

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
- the Hub's **Linux package** with real `dpkg` on the machine running the gate: installed, started as its own unprivileged account, refused without a licence, given a profile package, removed, the shop's data kept.

**NOT checked** (a person must): the Windows setup on a real Windows 10/11 PC; the Linux package under a real systemd and a real desktop, and on Mint or Debian (only the Ubuntu-family tooling of the build machine was used); a real printer, scanner, cash drawer or touch screen; the Android app; the website; the AI tools' real services (stand-in programs and services were used); code signing; whether a customer's PC has the internet the licence activation needs. The list in `PREREQUISITES.md` says what each machine needs.
