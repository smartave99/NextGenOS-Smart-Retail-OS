# Project rules (read first, every session)

These rules apply to every person and every AI assistant that changes this repository. They are not suggestions.

## 1. Who and what

- **Company:** NextGenOS.  **Product:** Smart Retail POS.  **The whole:** the Smart Retail AI Ecosystem, created by NextGenOS.
- **Smart Avenue 99 is a customer** of NextGenOS, not the product. Its name, address, logo, e-mail and colours must never appear as a default in product code. A customer's identity lives only in that customer's brand kit (`brand-kits/<customer>/`) or in a licence's brand profile.
- Contact for licensing and security: smartave99@gmail.com, +91 6123115368.
- The software is proprietary (`LICENSE`, `EULA.txt`). It is never published, never open-sourced, and never copied into a public place, including AI services that train on what they receive.

## 2. The "all complete" rule (Definition of Done)

**Never write that work is "complete", "done", "finished", "ready", "ready to sell", "bug-free" or "secure" unless all of this is true in the same session:**

1. `node scripts/verify-all.mjs --full` was run and **exited with code 0**, and its summary table is quoted in the answer.
2. Every item the gate marks **NOT VERIFIED** is listed in the answer, in plain words, with what a person must do to verify it (for example: run the Windows installer on a real PC, print on a real printer, build the APK in CI, have counsel review the EULA).
3. Nothing in the answer says "no bugs" or "no security issues". Say what was tested and what was checked, and what was not. Testing shows the presence of problems, never their absence.
4. If a check could not be run (no Windows, no hardware, blocked network), say so. A skipped check is not a passed check. The gate refuses runs with skipped tests.

If the gate fails, the work is not complete. Fix it, or say exactly what is failing.

## 3. Security rules

- No secret in the repository: no API key, password, token, connection string, private key, licence-signing key, passphrase, `.env`, database or licence file. `scripts/verify-all.mjs` scans for them, in every file and in every commit the work is built on (`scripts/scan-history.mjs`): a key that was committed and then deleted is still a leaked key. If one is found, rotate it first, then remove it, then remove it from the history.
- **No licence bypass, ever.** No hard-coded licence, no "demo" fallback that returns a valid licence, no activation script that writes a licence, no key generator, no environment variable or setting that makes a release build trust another key or skip the check. Development shortcuts must be impossible in a production build (`NODE_ENV=production`, Release configuration).
- The Licence Studio, its keys and its data are **private**. They are never packaged with a customer build. See `licensing/spec/LICENCE-FORMAT.md` section 12.
- **No source code in anything a customer receives**: installers, zips, APKs, Docker images or documentation folders must hold compiled/bundled code only: no `.cs`, `.vb`, `.ts`, `.tsx`, `.map`, `.pdb`, `.sln`, `.csproj`, test or script files from `licensing/studio`. `scripts/audit-package.mjs` enforces it and fails the release.
- New dependencies must allow proprietary redistribution (MIT, BSD, Apache-2.0, and the like). GPL, AGPL, SSPL and non-commercial licences are not allowed. Add the notice to `THIRD-PARTY-NOTICES.md`.
- Web code: every response carries the security headers set in `apps/storefront-web-mobile/src/middleware.ts`; no `dangerouslySetInnerHTML` with user data; every admin route checks the session; every input is validated on the server.
- Windows code: SQL is parameterised; the POS database is read-only for the AI and the dashboard; no secret in a connection string in source.

## 4. Licensing changes

The format is a contract between the Studio, the .NET library and the TypeScript library. Change `licensing/spec/LICENCE-FORMAT.md` first, regenerate `licensing/testvectors/vectors.json` (`node licensing/studio/scripts/make-testvectors.js`), and make **all three** implementations pass the vectors before you finish. A change in only one is a bug.

## 5. How to check your work

| What | Command |
|---|---|
| Everything (the gate) | `node scripts/verify-all.mjs --full` |
| Quick checks while working | `node scripts/verify-all.mjs` |
| Licence Studio | `cd licensing/studio && npm test` |
| .NET licence library incl. live Studio tests | `node licensing/e2e/with-studio.mjs -- dotnet test licensing/clients/dotnet/NextGenOS.Licensing.Tests` |
| Storefront | `cd apps/storefront-web-mobile && npx vitest run && npx tsc --noEmit` |
| Storefront against a real Studio (production build) | `node licensing/e2e/with-studio.mjs -- node licensing/e2e/storefront-e2e.mjs` |

## 6. Installers carry everything they need (a factory-new machine must run it)

Every installer, package and app we make (the Business Hub for Windows and for Linux, the website bundle, the Android app, the Studios) must install and run on a **factory-fresh** machine of a supported system with nothing added by hand. A shop owner must never be told to "first install .NET / Visual C++ / Node / a library".

- **Bundle what is not part of the operating system.** The program runtime (self-contained .NET, a bundled Node), every native library, the Visual C++ runtime if any file needs it, ICU (so culture and number formats do not depend on the machine), and fonts the program needs to print. A prerequisite that must be installed first is a bug.
- **What the operating system itself is allowed to supply**, and nothing else, is the list in `docs/PREREQUISITES.md` (for example: Windows 10 22H2 or 11, 64-bit, with its own system DLLs and Microsoft Edge; Ubuntu 22.04 or 24.04 and Debian 12 desktops with their base libraries, OpenSSL 3 and a web browser). The list is short and exact; a new entry needs a reason written next to it.
- **It is checked by a program, not by hope.** `node scripts/audit-prerequisites.mjs <package> --os windows|linux` reads every program file in the package, lists what each needs from the machine, and fails on anything that is neither in the package nor on the allowed list. It runs in the gate for every package we build. A package without its `prerequisites.json` (what is bundled, what the system supplies) fails.
- **The installer checks the machine first** (right operating system and architecture, enough disk space, a browser present, the port free) and says in plain words what is wrong and what to do.
- When a check cannot be run here (for example the real Windows PC), say so under NOT VERIFIED, and make the release workflow run it on a clean machine.

## 7. Hand over the output at every milestone

When a major piece is finished and its gate passes, build the trial outputs (installers, packages, the Studio, the website bundle, the app when it can be built) and give them to the owner to test, with plain test steps: send the files in the conversation, and say where the same files are in GitHub (the release). Say what each file is, what was and was not verified, and what to try. Trial builds that have no licence keys inside say so on their face and are never given to a customer.

## 8. Nothing the customer sees is fixed (everything is a setting, white-labelled per customer)

Anything a customer, an owner, a cashier or a shopper can see, hear or print is **data that belongs to that customer**, never a value written into program code. This covers names, logos, pictures and illustrations, colours, shapes, fonts, wording, languages, the country, the town or "typical place", the kind of people shown in generated photos, the set of images an AI makes, receipt and poster wording, and the sample content.

- **Defaults are neutral and not a market.** No default may assume India, Hindi, a currency, a festival, a skin tone, a shop type or a company. The default comes from the country pack, the industry pack or the customer's profile; with nothing set, the result is plain and neutral, not "Indian" and not ours.
- **Every such value is read from the customer's profile** (`profile/setup.json`, `theme.json`, `brand.json`, and the `images`/`assets` parts as they are added) or from a pack, set by the Setup Studio, and changed by the owner only as far as the licence's white-label level allows (`licensing/spec/LICENCE-FORMAT.md` sections 5.1 to 5.3). A value that is fixed in code is a bug, even when it looks harmless.
- **Artwork is replaceable.** A built-in picture (an illustration, an icon, a splash) must either follow the brand (colours taken from the brand) or be replaceable by the customer's own file, or be absent when the customer has none. It may not carry a company's look as a fixed choice.
- **AI-made content takes its settings from the profile**: which images are made, who is shown, in which place and language, in which style, with which brand notes. The prompts are built from those settings; none of it is written into the prompt text.
- **New work is checked for this.** Before finishing any change that shows something to a person, ask: could another customer, in another country, in another trade, want this different? If so, it is a setting with a neutral default, with a test that changing the setting changes the result. `docs/WHITE-LABEL-AUDIT.md` lists what is still fixed; the list only shrinks.

## 10. Programs open like programs (no terminal, ever)

Everything a person starts on a laptop, a counter PC or a device (the Setup Studio, the Brand Studio, the website, the Business Hub's shortcuts, any new tool) opens **as a program of its own**:

- One icon or menu entry starts it. A window with no address bar opens. **No terminal or console window appears, at any time.** Nobody is told to open a terminal, type a command or "leave this window open".
- **One copy at a time:** starting it again brings up the window that is already open.
- **Closing the window stops it.** The one exception is a background service that the shop depends on (the Business Hub): it keeps running on purpose, and closing its window only closes the window. Say which kind a program is, in its guide.
- A start-up problem is written in a plain note that opens by itself, never left in a terminal nobody can see.
- A launcher that shows a terminal may exist only as a clearly named "(with a window, for problems)" helper, or for a server that staff run remotely.
- The window code is one file, `scripts/lib/app-window.mjs`; the Windows launcher is made by `scripts/lib/build-launcher.mjs`. A copy that travels with a program is the same file, unchanged (a test checks it).
- What cannot be checked here (a real Windows PC) is listed under NOT VERIFIED, and the release workflow checks it on a Windows runner.

## 9. Style

Plain words for the people who use the product: shop owners, cashiers, salespeople. No jargon in screens or messages. Match the code around you. Say what changed in `CHANGELOG.md` when a release is cut.

## 11. What the product is, and how a customer gets it

- **The Setup Studio is the one tool NextGenOS staff use** (the "super installer"). A non-technical person opens it, starts a new project for a new company, fills in the company's details, and gets that customer's output: the installer pack for the shop program, the website and the Android app. Staff never use a terminal, GitHub, Node.js or a build tool to do this. Every new feature for staff goes into the Studio, in plain words (§9, §10).
- **The Studio holds no source code and builds no program itself** (§3). Programs are built by the release workflow on GitHub from this repository, which holds the source. A customer's website and app have the customer's settings built into them, so they are built for that customer on GitHub, never on a staff PC. The Studio is where staff ask for them and where the results come back.
- **Say only what is true.** Where the Studio cannot yet do a step by itself, `docs/SETUP-STUDIO.md` and `docs/OPEN-WORK.md` say so in plain words, and no screen, page or answer says the Studio does what it does not. Closing that gap is listed in `docs/OPEN-WORK.md` until it is done.
- **A customer's identity and everything the customer sees is a setting** of that customer (§1, §8). The Studio, the brand kit and the licence carry it; program code never does.

## 12. Releases

- **Two kinds of release, one gate.** A **full release** (tag `v1.0.0`, or `v1.0.0-rc1` to try it first) is the shop program for Windows and Linux, the website, the Android app and the Studio, built with the owner's licence keys. A **Studio release** (tag `studio-v1.0.0`, or `studio-v1.0.0-rc1` first) is the Setup Studio alone; it needs no keys, because the Studio holds none. Both run the whole gate (`node scripts/verify-all.mjs --full`) first, and nothing is released if it fails. A **trial** (started from a branch by `.github/trial-release.json`) has no licence keys, says so on its face, and is never given to a customer.
- **The licence signing key belongs to the owner alone.** No AI assistant, build job or cloud session creates, holds, sees or stores it: a cloud session is deleted when it is idle, and a lost key means every licence ever issued is lost. A full release needs only the owner's **public** keys and the Licence Studio's address (repository variables `NGOS_PUBLIC_KEYS` and `NGOS_LICENCE_URL`, shown with Copy buttons in the Licence Studio under Settings, "For a release build"). An assistant that needs them says so and hands the owner the exact steps.
- **Every release page tells a person, in plain words, what to download and what to do with each file** (`scripts/make-release-notes.mjs`), what is not in it, and what was and was not verified. The owner and the team test from that page; they should never have to ask "what do I run?".
- **`main` is the line of record and never lags behind.** When a piece of work is finished and its gate passes, it is merged into `main` (a pull request with a merge commit, history kept) so that `main` and the working branch are the same commit; do not leave finished work only on a side branch. Tags for real releases are made on `main`. The owner has asked for this more than once: it is a rule, not a favour.
- **Nothing irreversible without the owner's word for that action:** no force-push, no rewriting of history, no deleting a release, tag or branch that the owner did not ask to be deleted. Secrets found in history are rotated first (§3).
- After a release, say where its files are (the release page) and what each is; send the owner the files that fit in the conversation (§7).

## 13. Working with the owner: every assistant and every person

- **Do your whole part.** Do everything that can be done with the tools and access you have, without asking permission for what is plainly part of the task. For what you cannot do (it needs the owner's accounts, machines, money, signing key, or a real PC), write exactly what it is, why you cannot, and the click-by-click steps, in `docs/OPEN-WORK.md` under "Needs the owner", and say it in your answer. The owner does those parts. Never stall on them, never ask the owner to do something you can do, and never fake a step that needs the owner.
- **The owner must never have to repeat a rule, a preference or a decision.** When the owner states one, write it into this file (or the guide it belongs to) in the same session, in plain words, and push it. A thing is not remembered until it is in the repository. Before you ask the owner a question, check this file, `docs/OPEN-WORK.md` and the guides: the answer may be there.
- **Say what you are doing, and what you are waiting for.** If work takes more than a minute, say in a few words what you are doing; if you are waiting for something (a build, a person), say what and for how long. Answer "is it done?" with what is done, what is not, and what you are waiting for; use the words "complete", "done" or "ready" only as §2 allows.
- **Plain words** in every message to the owner too (§9). Links, not bare numbers (a release, a pull request, a run).
- **Keep `docs/OPEN-WORK.md` true.** Whenever you finish, find or put off a piece of work, update that file in the same commit. Before you answer "what is left?", read it, and check it against the repository.
- **Work in parallel when the tools allow it** and the pieces are independent; if helpers fail (for example a usage limit), carry on yourself. Check a helper's result before you report it.
- **Do not work around a refused action.** If a permission or policy refuses something, say so and say what the owner can do; never find another way to the same result.

## 14. Everyone reads the same rules

`CLAUDE.md` is the one set of rules, for people and for every AI assistant, in any session, on any machine. `AGENTS.md` (read by Codex, Copilot's agent, Cursor and others), `GEMINI.md`, `.github/copilot-instructions.md` and `.cursor/rules/project-rules.mdc` exist only to send a reader here; they hold no rules of their own, so there is nothing to keep in step. The gate (`scripts/checks/rules.mjs`) fails if one of them is missing or stops pointing here, if a numbered section of this file is lost, or if `docs/OPEN-WORK.md` is missing. A new assistant or a new member of staff starts by reading this file, then `docs/OPEN-WORK.md`.
