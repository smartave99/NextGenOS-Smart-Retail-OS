# Open work

Read this before you answer "what is left?", and keep it true: update it in the same commit whenever you finish, find or put off a piece of work (`CLAUDE.md`, section 13).

Last updated: 6 October 2026.

## Needs the owner (an assistant cannot do these)

Each one needs the owner's own accounts, machines or decisions. They are listed with the exact steps so that nothing has to be explained again.

1. **Make the licence signing key and run the Licence Studio.** Why only the owner: the key must live on a PC or server that stays on, with a back-up, and nobody else may hold it (`CLAUDE.md`, section 12).
   - Needs Node.js 22.5 or newer on that PC or server, and for real use a web address with HTTPS (for example `https://licence.yourcompany.com`).
   - In the folder `licensing/studio`: `node src/cli.js init --admin-email you@yourcompany.com --admin-name "Your Name"`, then `node src/server.js`. Write down the temporary password it prints once. Back up `data/` every day: losing it loses every licence.
   - Full steps: `licensing/README.md`.
2. **Give the build the two public values.** Open the Licence Studio, **Settings**, fill in "This server's public address", save, and copy the two boxes under **For a release build (GitHub)**. In GitHub: Settings, Secrets and variables, Actions, **Variables**: create `NGOS_PUBLIC_KEYS` and `NGOS_LICENCE_URL` with them. (Public values only; no secret goes there.)
3. **Make the release tags.** `studio-v1.0.0-rc1` (the Setup Studio alone: needs no keys, can be done now) and, once step 2 is done, `v1.0.0-rc1` (the full release). On GitHub: Releases, Draft a new release, Choose a tag, type the name, target `main`, tick "Set as a pre-release", Publish. After the team's tests pass, the same without `-rc1`.
4. **Rotate the old secrets that are still in the git history:** the OpenAI key, the Neon database password, the Firebase secrets and the SQL Server `sa` password (`docs/SECURITY-MODEL.md`, "Known limits"). Then say "go" for cleaning the history; it needs the owner's word because it rewrites history.
5. **Signing:** a code-signing certificate for Windows (repository secrets `WINDOWS_CERT_B64`, `WINDOWS_CERT_PASSWORD`) and an Android release key (`ANDROID_KEYSTORE_B64`, `ANDROID_KEYSTORE_PASSWORD`, `ANDROID_KEY_ALIAS`, `ANDROID_KEY_PASSWORD`). Without them Windows says "unknown publisher" and the app is signed with a one-off test key.
6. **Legal and professional:** the legal name and governing law in `EULA.txt` and a lawyer's review; each country's tax rules checked by a local adviser; an independent security test; proof that NextGenOS may resell the decompiled Windows POS source (`apps/pos-desktop`).
7. **Try it on real machines:** a real Windows 10/11 PC (the Hub setup and its window shortcut, the Setup Studio, the website; look for a black window flashing), a real phone for the Android app, and each make of printer, scanner and cash drawer you sell.
8. **Old trial pages:** say which of `v1.0.0-trial7` and `v1.0.0-trial8` to remove; they are replaced by trial 9. (Deleting a release needs the owner's word.)

## Needs an engineer or an assistant (can be done in the repository)

1. **The Setup Studio does not yet build or fetch the website and the Android app for a customer by itself.** Today it makes the customer's pack and copies the programs from a release folder; the customer's website and app are built on GitHub by a person who can run the release workflow (`docs/SETUP-STUDIO.md`, "The website, one build per customer"). The goal (`CLAUDE.md`, section 11): staff press one button in the Studio; the Studio asks GitHub to build that customer's website and app from the customer's settings, and brings the files back into the pack. This needs a build workflow for one customer, and a GitHub access token that the owner creates and puts in the Studio (a new owner step: fine-grained, this repository only, permission to run workflows and read releases).
2. **The older Windows programs** (the POS, the AI add-on, the dashboard host) and the plain Hub zip can still show a console window when started (`CLAUDE.md`, section 10).
3. **Not yet in the Studio's customer pack:** the AI assistant's setup (built on a Windows PC, not by the release workflow yet).
4. **Things still fixed in code that a customer could want different:** `docs/WHITE-LABEL-AUDIT.md` (the list only shrinks).
5. **Several shops in one database, and sync between PCs** are not built. Fonts and a light/dark default from a brand kit are allowed by the licence but not applied by the Hub.

## What cannot be verified from a cloud session

The gate prints the list every time (`node scripts/verify-all.mjs`, "NOT VERIFIED"). Say it whenever you report on the work.

## Where things are

- The rules: `CLAUDE.md`. The release steps: `docs/RELEASE-GUIDE.md`. The Studio: `docs/SETUP-STUDIO.md`. The licensing: `licensing/README.md`.
- Latest release pages: GitHub, Releases. Trial pages say "TRIAL BUILD" at the top and are never for a customer.
