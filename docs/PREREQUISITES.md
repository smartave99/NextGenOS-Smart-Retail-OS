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
- For the website bundle: its own Node.js runtime and everything it needs to start. For the Android app: everything inside the package.

## What the audit checks

- every program file in the package, and everything it imports or needs, is **in the package or on the lists above**;
- no file is made for the wrong processor (`x64` vs `arm64`);
- no file asks for a newer glibc than Ubuntu 22.04 has;
- a .NET program carries its runtime (it is not "framework-dependent");
- the package has a `prerequisites.json` that says what it carries, what it relies on the system for (only the items above) and the minimum system in words.

A new entry on the list above needs a reason written next to it and a matching check in the installer.
