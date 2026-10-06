# Making and testing a release

For the owner of **NextGenOS**. A release is built by GitHub, not on your PC: the *Release* workflow (`.github/workflows/release.yml`) runs every check, then builds the Windows setup of the Business Hub and the Android app, and attaches them to a GitHub Release.

## What you need once

1. **The Licence Studio running** with its signing key made (`licensing/README.md`). Without it nothing can be licensed.
2. **Your public keys given to the build.** Open the Licence Studio, **Settings**, and fill in "This server's public address" (save it). The box **For a release build (GitHub)** below it shows the two values with a *Copy* button each; no command is needed. (The command `node src/cli.js export-public-keys`, in the Studio folder, prints the same keys.)
   In GitHub: *Settings → Secrets and variables → Actions → Variables* (the **Variables** tab, not Secrets: these are public by design):
   - `NGOS_PUBLIC_KEYS` = the first box (the whole text);
   - `NGOS_LICENCE_URL` = your Studio's address, for example `https://licence.yourcompany.com`. For a trial on your own PC use `http://127.0.0.1:8080` (the Studio on the same PC that tests the setup).
3. *(Optional, for stores and for no Windows warning)* **Secrets**: `ANDROID_KEYSTORE_B64`, `ANDROID_KEYSTORE_PASSWORD`, `ANDROID_KEY_ALIAS`, `ANDROID_KEY_PASSWORD` (a release key for the Android app; without them a one-off test key signs it) and `WINDOWS_CERT_B64`, `WINDOWS_CERT_PASSWORD` (a code-signing certificate as a base64 `.pfx`; without it the Windows setup is unsigned and Windows shows "unknown publisher").
4. **The repository stays private.** Anyone who can open it can read the source.

## Make a release

Either push a tag:

```
git tag v1.0.0-rc1
git push origin v1.0.0-rc1
```

or run the *Release* workflow by hand (*Actions → Release → Run workflow*) and choose the brand kit and version. A tag with `-rc`, `-beta` or `-alpha` in it becomes a **pre-release**.

The workflow does, in order:

1. **Gate**: `node scripts/verify-all.mjs --full`: every test, the browser tests, the licence checks, the package audit, the protected-build tests, the installer test. **If it fails, nothing is released.**
2. **Windows** (a real Windows machine at GitHub): builds the Hub, hides its names, audits it, writes the setup and a zip, starts the program from the zip, then **installs the setup on that Windows machine, checks the service starts and answers, uninstalls it, and checks the shop's data stays**.
3. **Android**: builds and signs the `.apk` and `.aab`.
3b. **Website**: builds the customer's website for Linux and for Windows (each on its own system), audits it, starts it from the zip and checks that it refuses to work without a licence, and puts `website-<customer>-linux.zip` and `website-<customer>-windows.zip` on the release (see `docs/SETUP-STUDIO.md`, "The website, one build per customer").
4. **Publish**: the files, `SHA256SUMS.txt` and `BUILD-STATUS.txt` go on the release. If the Windows or the Android part failed, the release still goes out with what was built, and `BUILD-STATUS.txt` and the notes say which part failed.

If the Windows job stops with *"The licence keys are not built in yet"*, step 2 above is not done. After you add the two variables, open the failed run and choose **Re-run failed jobs**: the Windows part is built and added to the same release.

**Trying the Windows setup before you have keys.** Make the tag `v1.0.0-trial1` (a tag with `-trial` in its name). The workflow builds the same setup with **no licence key inside**, installs it on the Windows machine at GitHub, checks the service and the uninstall, and publishes a pre-release marked **TRIAL BUILD**. That setup can never be activated, so it only shows that installing, the service and uninstalling work. **Never give it to a customer.** (You can also run the workflow by hand and tick *trial_without_keys*; GitHub only shows the *Run workflow* button once the workflow is on the `main` branch.)

**Making the tag.** Pushing a tag needs permission to create tags. If your tools cannot push one, make it on GitHub: *Releases → Draft a new release → Choose a tag → type `v1.0.0-rc1` → Create new tag*, set **Target** to the branch `claude/happy-fermat-jv4lg8` (or `main` once merged), tick *Set as a pre-release*, and *Publish release*. Publishing makes the tag, and the workflow starts; it then adds its files to that release.

## Removing old trial pages

Every trial leaves a page on the Releases list and a tag. When you no longer need old ones, the *Remove old trial releases* workflow (`.github/workflows/remove-trial-releases.yml`) takes them away. There are two ways to ask for it:

- **From a `claude/*` branch.** Put the tags in the list in `.github/remove-trial-releases.json`, for example `{"tags": ["v1.0.0-trial5", "v1.0.0-trial6"]}`, and push. The workflow starts by itself, removes those pages and their tags, and shows one line for each thing it removed in its log. Afterwards put the list back to `{"tags": []}`; an empty list does nothing.
- **By hand.** *Actions → Remove old trial releases → Run workflow*, and type the tags with a space between them. GitHub only shows the *Run workflow* button once the workflow is on the `main` branch.

**Only trial pre-releases can be removed this way.** A tag must look like `v1.0.0-trial5`, and its release must be marked as a pre-release (a draft that is marked as a pre-release counts too). Anything else, such as `v1.0.0`, `v1.0.0-rc1`, or a trial page that is not marked as a pre-release, is refused with a plain message, and **then nothing at all is removed for any tag of that request**, so fix the list and ask again. A tag that has no page, or a page whose tag is already gone, is not an error. A removed page and its files cannot be brought back; make a new trial instead.

## Test it yourself (about 30 minutes)

1. On a Windows 10/11 PC, download `SmartRetailPOS-Hub-Setup-<version>.exe` from the release and run it. (Windows will warn about an unknown publisher unless the setup is signed: *More info → Run anyway*.)
2. Open **Smart Retail POS** from the Start menu or desktop (`http://127.0.0.1:5280`). It asks for a licence key: it is working as designed.
3. In your Studio: make a customer and a licence with the **Business** plan (it includes the Hub) and a brand. Copy the key.
4. Type the key in the Hub's screen. It activates and shows the setup wizard. Choose a country and a kind of business and tick the sample company so you have something to look at.
5. Try a sale, a return, a report, **Settings → Printers**, **Settings → Look**.
6. Uninstall it from *Settings → Apps*. Your data stays in `C:\ProgramData\NextGenOS\Hub`.
7. Android: install the `.apk` on a phone (allow installs from your browser, if asked). It opens the website set in the brand kit.

Tell me, or the person who supports you, **exactly** what you did and saw for anything that looks wrong.

## After the first release

- **Rotate the old secrets** (OpenAI key, the Neon database password, Firebase secrets, the SQL Server `sa` password): they are still in the repository's history. See `docs/SECURITY-MODEL.md`, "Known limits".
- **`main` now holds the proprietary licence** (the first pull request was merged into it): the proprietary licence applies to everything from there on. Copies that someone received earlier under the old MIT file stay under it.
- Fill in the placeholders in `EULA.txt` (legal name and address, governing law) with your lawyer.
- Have the tax rules of each country you sell in checked by a local tax adviser.
- Test each make of printer you sell once, on a real Windows PC.
