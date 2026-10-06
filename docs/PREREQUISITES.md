# Prerequisites: what a machine needs before our installers run

The rule (`CLAUDE.md`, section 6): **every installer carries everything it needs.** A shop owner with a factory-new laptop or counter PC runs the installer and it works. This page is the short, exact list of what the **operating system itself** must supply. Nothing else may be required; `node scripts/audit-prerequisites.mjs` checks it for every package we build.

## Supported systems

| System | Version | Notes |
|---|---|---|
| Windows | 10 (22H2) and 11, 64-bit; Server 2019 and later | Laptops, desktops and touch-screen counters. Windows on ARM is not supported yet. |
| Ubuntu, Linux Mint, Debian and their derivatives | Ubuntu 22.04 and 24.04, Mint 21 and later, Debian 12 and later; 64-bit Intel/AMD (`x64`) or ARM (`arm64`, for example a Raspberry Pi 4/5 or an ARM touch terminal) | Desktop installs. glibc 2.35 or newer. |

## What the system supplies (and our installer checks before it installs)

| Item | System | Why it is allowed |
|---|---|---|
| `windows-10-22h2-or-11-x64` | Windows | The operating system itself. |
| `windows-system-dlls` | Windows | Our native files import only DLLs that every Windows 10/11 has in `System32` (kernel, user, security, networking, graphics). The audit lists each one; the Visual C++ runtime is **not** needed (our native files carry it inside themselves). |
| `web-browser-edge` | Windows | Microsoft Edge is part of Windows 10/11. The Hub is used in a browser. |
| `glibc-2.35-or-newer` | Linux | The C library every Linux has. Nothing we ship asks for a newer one. |
| `libstdc++6-libgcc-s1` | Linux | The C++ runtime that comes with every Debian/Ubuntu desktop. |
| `openssl-3` | Linux | Needed for secure connections (activating the licence over HTTPS). Every Debian 12 / Ubuntu 22.04+ desktop has it. The installer checks and says plainly if it is missing. |
| `web-browser` | Linux | A desktop browser (Firefox is on Ubuntu; Chromium and Chrome also work). The installer checks. |
| `systemd` | Linux | Runs the Hub in the background and starts it with the PC. |

## What we carry inside the installer (never asked of the customer)

- The program runtime: **self-contained .NET** (no .NET to install).
- Every native library: the database engine, the picture and barcode library, the printer libraries.
- Culture and number formats: the Hub does not depend on the system's ICU (it formats money, dates and numbers itself, from the country pack).
- For the website package: its own Node.js runtime (an official build, checked against nodejs.org's fingerprint), the built server and static files, the libraries it needs, the database engine (Prisma) and the picture library (sharp, libvips) **for that system**, and nothing else. For the Android app: everything inside the package.

## What is checked on the packages we build today

| Package | How it is checked | Result |
|---|---|---|
| Hub for Windows (setup and zip) | `scripts/audit-prerequisites.mjs` runs inside `apps/business-hub/installer/build.mjs` on the published folder: every native file imports only DLLs that are in the folder or in Windows' own list | Passes (19 native files) |
| Hub for Linux (`.deb`) | The same audit runs inside `build-linux.mjs`, and `test-linux-package.mjs` installs the package with real `dpkg`, starts it as its own unprivileged account and removes it | Passes. The runtime's tracing library (`libcoreclrtraceptprovider.so`, which asks for a library no desktop has) and its debugging and memory-dump helpers are taken out of the package |
| AI assistant, dashboard, old POS | Not audited by this script yet | **Not checked** |
| Website for Linux (`website-<customer>-linux.zip`) | `scripts/audit-prerequisites.mjs` runs inside `scripts/make-website-package.mjs` on the finished folder (Node.js, the database engine and the picture library), `scripts/audit-package.mjs --node-app` checks it for source, secrets and licences, and the gate builds one, starts it with its own Node.js and shows it refuses without a licence. The database engine asks for OpenSSL 3, so the package says `openssl-3` and the start script checks for it first | Passes (5 program files) |
| Website for Windows (`website-<customer>-windows.zip`) | The same audits run on a Windows machine of the release workflow, which also starts it from the zip. The Windows parts were read with the audit from Linux (node.exe, the database engine and the picture library import only what Windows has) | **Not run on a real PC** |
| Android app | The Android app is self-contained but is built only by the release workflow | **Not checked** |

A static audit reads what a file *says* it needs. It cannot prove a program runs on a machine; only running it on a clean machine of that kind does (`docs/SETUP-STUDIO.md`, "What was and was not checked").

## What the audit checks

- every program file in the package, and everything it imports or needs, is **in the package or on the lists above**;
- no file is made for the wrong processor (`x64` vs `arm64`);
- no file asks for a newer glibc than Ubuntu 22.04 has;
- a .NET program carries its runtime (it is not "framework-dependent");
- the package has a `prerequisites.json` that says what it carries, what it relies on the system for (only the items above) and the minimum system in words.

A new entry on the list above needs a reason written next to it and a matching check in the installer.

## The website package

A website is a Node.js server, so its package is a folder with its own `node` (or `node.exe`), `app/` (the server, `.next/static`, `public` and a trimmed `node_modules`), the start script and `prerequisites.json`. What it relies on the system for:

| System | Relies on | Checked by |
|---|---|---|
| Linux | glibc 2.35 or newer (the files ask for 2.28), the C++ runtime, **OpenSSL 3** (`libssl.so.3`, `libcrypto.so.3`: the database engine links to them; Ubuntu 22.04 and later and Debian 12 and later have it) | `audit-prerequisites.mjs` allows these two libraries only when `prerequisites.json` says `openssl-3`; `start-website.sh` checks for them and says in plain words what to install |
| Windows | Windows 10 (22H2) or 11, 64-bit, and its own system DLLs | `audit-prerequisites.mjs`: `node.exe`, the engine and the picture library import only DLLs on the list; the Visual C++ runtime is not needed |

The start program also checks that the port is free and that there is room on the disk, and says what to do. It needs no browser; people who use the website have their own. Only 64-bit Intel/AMD websites are built; an ARM website would need an ARM build machine and is not made yet.

## Launchers: the one 32-bit program that is allowed in a 64-bit Windows package

The small program a person double-clicks to open one of our programs with no terminal window (`Start Website.exe`, `Setup Studio.exe`; made with NSIS by `scripts/lib/build-launcher.mjs`) is a **32-bit** Windows program. **Reason:** the free NSIS for Windows has no 64-bit stub, and every 64-bit Windows 10 and 11 runs 32-bit programs (WoW64 is part of Windows). It only starts the 64-bit Node.js beside it. The audit accepts such a file only when `prerequisites.json` names it in `"launchers"` (a `.exe` at the top of the package), and it still checks that the launcher imports nothing but Windows' own libraries.
