# New versions of the Business Hub (updates through the main PC)

Blueprint ticket REL-016; the owner's decision 7 in `docs/PLATFORM-DECISIONS.md`. Written in plain words for the owner and for NextGenOS staff.

**The short version.** About once a day the main PC of a shop looks, in a public online folder, for a newer version of the Business Hub. If there is one, it checks that the makers' own release made it, keeps it on the PC, and tells the owner on the first screen. **Nothing is installed until the owner says so.** When the owner approves, the program first copies the shop; then the page names the checked file and the last step, which the owner does: run it, and press Yes when Windows asks.

## What the owner sees

1. **Settings, Updates.** One line says where things stand ("You have the newest version (1.0.0). Last looked: 8 Oct 2026, 10:30."). *Look now* looks at once. *Look for new versions* switches the daily look on or off.
2. **When a newer version is found** the first screen shows a note ("A new version (1.2.0) is ready. Nothing changes until you say so.") and the Updates page shows what is new, written by the makers, as plain text.
3. **Approve, and copy the shop first.** The program copies the shop to the place chosen under *Settings, Backups* (or, when none is chosen, to a folder on the PC, and says that this is not a real backup). **If the copy cannot be made, nothing is approved.** *Not now* stops the reminder for that version; a newer version reminds again.
4. **The last step**, in four lines on the page: finish open sales; press the Windows key and R, paste the address shown, press Enter; say Yes when Windows asks; open the page again, which now says you have the newest version. The setup keeps all the shop's data and starts the program again.
5. **The other counters need nothing.** A counter PC is a browser looking at the main PC (`docs/STORE-NETWORK.md`); it shows the new version as soon as the main PC has it.

## What is sent, and what is not

Looking asks the online folder for two public files (a short description, and the setup when there is a newer one) and asks GitHub for the key it signs with. The request says only that it is **Smart Retail POS Hub and which version** (the usual "user agent" line) and carries a time stamp so that an old copy is not read. **Nothing about the shop is sent**, not its name, its licence, its address or its sales; the browser's cookies and the licence are not part of it. A test checks every request that a look makes (`UpdateTests`).

## Why a downloaded version can be trusted

The online folder is public, so anyone who got into it could put a file there. The Hub therefore takes a version only when its description carries a **statement signed by GitHub** (an Actions OIDC token) that:

- is for this version and this very file (its audience carries the version and the file's SHA-256, and a word only the Hub's updates use, so a statement made for the AI add-on can never pass for a Hub update);
- was made by **this repository's** release workflow (named by GitHub's own numbers, which a rename does not change; fixed in the program when it is built, never read from a setting or file on the PC);
- was started by a **version tag** such as `v1.2.3`, and that tag names the same version: not a branch, not a try (`v1.2.3-rc1`), not the Setup Studio's tag, not a run started by hand.

The statement is checked **before** anything is downloaded. The file must then have exactly the size and SHA-256 that was signed; it is checked again when it is kept, and again just before the owner is asked to approve. A version that was "approved" and then found changed on the disk is removed and not trusted.

Because GitHub signs, **nobody has to hold an update-signing key** (a key kept by one person is lost with that person; the licence signing key already is the owner's alone, `CLAUDE.md` section 12).

## What is not done by the program, and why

- **The install itself.** The Hub runs as a Windows service with the low rights of `Local Service`, which cannot install a program, and a service cannot show Windows' "do you allow this" question on the owner's screen. Making that automatic needs a small helper that runs for the signed-in person; it can only be designed and tried on a real Windows PC. Until then the last step is the owner's, and the page says so.
- **Linux.** The Linux package is installed by the person who runs that server; no update is offered there.
- **Updating a counter's look** ("a new look for this client", decision 7) and an owner's choice of a quiet hour: not built.

## Setting it up, once (NextGenOS staff or the owner)

The same online folder and the same account serve the AI add-on and the Hub; if the add-on's update folder is already set up (`apps/pos-ai-companion/README.md`, "Automatic updates"), the Hub needs nothing more.

1. In Supabase, make the *uploader* user and run `apps/pos-dashboard-service/cloud/supabase-app-updates.sql` (it makes the public folder `app-updates`).
2. In GitHub, **Settings → Secrets and variables → Actions**: *Variables* `UPDATE_FEED_URL` (`https://<your project>.supabase.co/storage/v1/object/public/app-updates/`, ending in `/`) and `UPDATE_ANON_KEY` (the project's public key); *Secrets* `UPDATE_UPLOAD_EMAIL` and `UPDATE_UPLOAD_PASSWORD`.
3. Push a version tag as usual (`v1.1.0`). The release workflow: builds the Hub with the folder and the repository's numbers written in (`installer/build.mjs`, only for a real version tag, never `-rc`, a trial or a run by hand), tries the setup on a Windows PC, publishes the release, and then **publishes the setup to the online folder** (`publish-update` job, `apps/pos-ai-companion/publish-update.sh --product hub`). Only the last two versions stay online.
4. A shop that has a Hub built that way finds the new version within a day. The first Hub with a folder in it must be put on the shop PC by hand, as always.

Without step 2 nothing changes: the Hub is built without a folder and never looks.

**Found while wiring this, and fixed:** a release started by pushing a tag was always built as version 1.0.0, whatever the tag said (the version was taken from the hand-started run's field, which a tag push does not have). The version now comes from the tag (`v1.2.0` and `v1.2.0-rc1` both carry 1.2.0), in the `prepare` job of `release.yml`.

**Also found, by the first trial that carried this change:** a workflow that calls the Release workflow (the trial release does) has to give it every permission any of its jobs asks for, here `id-token: write` for the signed statement; otherwise GitHub does not start the run at all. The trial caller now gives it (the job that uses it still runs only for a real version tag, never for a trial), and `scripts/tests/release-workflow-permissions.test.mjs` is part of the gate.

## What was tested, and what was not

Tested here: the description and the signed statement from every side (`UpdateTests`: a statement for another file, repository, owner, branch, try-tag, Studio tag, version, workflow or event; a wrong key; a changed claim; junk); the checker against an online folder that goes wrong in every way (no answer, 404, a redirect to plain http, GitHub's key from another host, a piece too short, one byte changed, more bytes than said); the daily rhythm; approval with the copy first and its refusal; "not now"; the installed version cleaning up; the build settings (`UpdateHostTests`, `hub-update-properties.test.mjs`); the publishing script against the Hub's own checker, with a stand-in for GitHub's signing (`PublishHubUpdateScriptTests`); the owner's page in a real browser, also against the program with its names hidden (`e2e/updates.e2e.mjs`).

**Not verified (needs you or a real PC):** a real online folder with a real uploader; the signed statement from the real GitHub (the tests sign the way GitHub signs, with their own key); the first real update on a real Windows PC (the last step, UAC, the service restarting, the data kept); Windows' view of the setup file in `ProgramData` (who may change it between "checked" and "run" — the setup is checked again by the owner only through Windows' own prompt, so a code-signing certificate for the setup, `WINDOWS_CERT_B64`, is what finally protects that step).
