# How Smart Retail POS protects its source code and its licence

Product: **Smart Retail POS by NextGenOS**, part of the **Smart Retail AI Ecosystem**. This page says what is protected, how, how it is checked, and what is **not** protected. It is written so an owner, a sales person and a buyer's security team can all read it. Nothing on it is a promise that the software cannot be broken.

## The honest starting point

**No program that runs on a customer's own PC can be made impossible to read or to change.** The customer owns the PC. A person with enough skill, time and tools can always look at what a program does and change it. This is true of every product, including the best-protected ones. So the aim is not "unbreakable". The aim is:

1. make casual copying and casual tampering **not work at all**;
2. make serious tampering **cost far more than a licence costs**;
3. keep what is **truly valuable out of the customer's reach** (the signing key, the licence records, anything that lives on our servers);
4. make every release **prove** that nothing it should not hold went into it.

The layers below do that. They are described with what each one really stops.

## Layer 1: the licence cannot be forged or copied

| What | How |
|---|---|
| A licence is a **signed statement** | ECDSA (P-256, SHA-256). The programs hold only the **public** key, so reading a program does not let anyone make a licence. |
| The private key stays with us | It lives only in the Licence Studio, stored encrypted (scrypt + AES-256-GCM), unlocked by a passphrase kept in the Studio's environment. It is never in this repository or in anything a customer receives. |
| A copy of the files does not work on another PC | A licence is **activated** for one PC. The activation is tied to a fingerprint of that PC (BIOS, board, disk, system id and CPU, as salted hashes; most must match). A licence file copied to another PC fails the match. |
| Licences can be switched off | A signed **revocation list** is fetched at check-in. Suspended, revoked and expired licences stop (a paid licence past its end date keeps working with a banner: the choice is signed into the licence, decision 15; a trial always stops). |
| Turning the clock back does not help | The programs remember the latest time they saw (with a code tied to the PC); a clock moved back more than a day stops the program until it checks in. |
| Work never stops because the internet is down | There is a grace period; offline PCs use an activation code. |
| It fails closed | Any unexpected problem reading the licence counts as "not licensed". |

The licence format is written down in `licensing/spec/LICENCE-FORMAT.md`. The Licence Studio, the .NET library and the TypeScript library all pass the same signed test vectors (`licensing/testvectors/`), so they agree.

**What this stops:** copying, sharing, installing on more PCs than paid for, using after expiry or after cancelling, making a licence without us.
**What it does not stop:** see "Known limits" (patching the program).

## Layer 2: the licence is checked first, and cannot be taken out by accident

- In the Business Hub, the licence gate is the **first** step of every request: with no usable licence **nothing** is served, not even a picture or a script (they answer "402, licence needed"). Background workers only run while the licence is usable. Open screens are stopped when it stops.
- The release check (`scripts/verify-all.mjs --full`) has tripwires: it fails if the gate is moved or removed, if a background worker is added without the gate, if a test stand-in for the licence is referred to from anything that ships, or if a hard-coded licence, key generator or activation script appears anywhere.
- There is **no** setting, environment variable or "demo mode" that makes a release build accept another key or skip the check. Test stand-ins exist only inside test programs, which are never packaged.

## Layer 3: only compiled, hidden code is shipped

What a customer receives (setup, zip, app package) holds **compiled** programs only: no `.cs`, `.vb`, `.ts`, `.tsx`, `.razor`, project or solution files, no symbols (`.pdb`) and no source maps.

On top of that, every NextGenOS program in the Hub's package (`NextGenOS.Hub`, `.Hub.Core`, `.Tax`, `.Devices`, `.Licensing`, `.Licensing.AspNetCore`) goes through a .NET obfuscator (Obfuscar, `scripts/protect-dotnet.mjs`):

- type, method, field and event names are replaced by meaningless short names, so a decompiler shows `A.B.C(D)` instead of `ReportService.Summary(range)`;
- text inside the programs is hidden (not stored as plain text);
- the programs are marked so common disassemblers refuse them;
- the web program keeps method and property names (the screens find them by name at run time), but its types and fields are renamed;
- the file that maps new names back to real ones is **not** shipped: it is kept privately (`--map-to`) to read a customer's crash report.

**Every release is audited** (`scripts/audit-package.mjs`) before it is written to a setup or zip, and the zip is audited again after:

- no source, project, symbol, map, test, Licence Studio, key, certificate, database, licence, environment or log file;
- no secret pattern (API keys, private keys, connection strings with passwords) in any file, and none inside the programs, as plain text or as .NET's own text format;
- each protected program shows **none** of the real type names taken from our source (172 names checked in the Hub package); one that does is "not obfuscated" and the release stops.

The same package is then **run**: the whole browser test suite is repeated against the protected program (hiding names can break things found by name at run time), and the real, protected Hub is brought into use with a real licence from a real Licence Studio.

**What this stops:** a customer or a competitor opening the program in a decompiler and reading our logic like source code; copying our code out of the installer.
**What it does not stop:** a determined person studying the obfuscated program. Name hiding turns "minutes" into "days of work", not into "impossible". String hiding in this tool is simple, not strong.

## Layer 4: what matters most is not on the customer's PC

- The **licence records, activations and the signing key** live only in the Licence Studio, which is private and never packaged.
- The storefront's server code runs on **our or the customer's server**, not on shoppers' phones. The Android app is only a shell around the licensed website: it holds no business code to copy.
- Updates and licences are signed; the programs trust only signatures from our keys.

## Layer 5: the products themselves are hardened

Security headers and a strict content policy on every response; no inline scripts; same-site cookies; anti-forgery tokens; sign-in lock after repeated wrong passwords; roles that really limit people (a cashier cannot open reports or settings, and cannot download them; and the Business Hub's own services refuse a command from a person who may not do it, whatever screen or caller it came from, looking the person up again at every command, so that someone switched off or given another role loses their rights at once: `Security/Access.cs`, `docs/ENGINEERING-BLUEPRINT.md` item SEC-004, with the commands not yet covered listed in `docs/OPEN-WORK.md`); every value checked on the server; SQL always with parameters; the POS database is read-only for the AI and the dashboard; no secret in a connection string in source; dependencies must allow proprietary redistribution, and are audited for known problems (`npm audit`, NuGet audit) by the release check. The Business Hub's service runs as the low-rights *Local Service* account, listens on **this PC only** (127.0.0.1), and keeps the shop's data in a folder only that service and administrators can read.

## Known limits (read these)

1. **Patching.** A skilled person can change the program file itself so that it skips the licence check. Name hiding makes finding the check harder, and code signing (below) makes a patched file say "unknown publisher", but neither makes it impossible. The defence that remains is that **licences are per PC, signed, revocable and expire**, and that the agreement (`EULA.txt`) forbids it and lets us audit.
2. **No tamper self-check or anti-debugging** is built in yet. The programs do not check their own files for changes or detect a debugger. (A commercial .NET protector can add this to the Windows programs; consider one for the highest-value builds.)
3. **No per-customer watermark** in the built files yet, so a leaked build cannot yet be traced to the customer it was made for. Licence-bound activation does limit the damage: a leaked build still needs a valid, activated licence.
4. **Cloned virtual machines.** A cloned VM with identical virtual hardware cannot be told from the original by the PC alone; the seat count, check-in history and contract cover that.
5. **Antivirus can be wary of hidden names.** Programs whose names are hidden are sometimes flagged by antivirus software as suspicious until they are code-signed and have a reputation. Sign the setup (next point) and report false alarms to the antivirus maker.
6. **Not code-signed.** Until a code-signing certificate is added (`WINDOWS_CERT_B64`, `WINDOWS_CERT_PASSWORD` in the release workflow), Windows warns that the publisher is unknown, and a changed file is not flagged by Windows.
7. **The older Windows POS (`apps/pos-desktop`) is recovered source** that the owner states is theirs (decision 27). Its installer and libraries do not yet go through the protection and audit above; the Business Hub does (they will, as its features are merged into the Hub: `docs/MERGE-PLAN.md`).
8. **Not independently tested.** No penetration test or code review by an outside security firm has been done. Testing shows problems; it never shows there are none.
9. **Secrets from the early history.** Credentials that were committed before this work (an OpenAI key, a database password, Firebase secrets, a SQL Server `sa` password) are in the repository history even though they are removed from the files. **They must be rotated** (changed at their provider); until then they must be treated as public.

## What a release proves, and what it does not

A release that passes `node scripts/verify-all.mjs --full` has shown, in that run: the tests of every part pass, the browser tests of every kind of business pass (also against the protected build), the real protected Hub works with a real licence, the package audit found no source, key, database, licence or secret, and the licence tripwires hold. The gate's own list of **NOT VERIFIED** items says what it could not do (real Windows PCs with real printers and scanners, real phones, signing, tax advice, legal review, a penetration test).

## Reporting a problem

Send security reports privately to smartave99@gmail.com or +91 6123115368 (see `SECURITY.md`).
