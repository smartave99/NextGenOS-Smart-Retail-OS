# Customer builds: one button in the Setup Studio

*For the owner of NextGenOS, and for engineers. Staff only need the Setup Studio: they press one button and wait.*

A customer's **Android app** has that customer's own settings built into it, and building it needs the program source. The source never goes to a staff PC (`CLAUDE.md`, section 3), so the build runs where the source is: on GitHub. This page says how the Setup Studio asks for a build, what GitHub does, what comes back, and **what you, the owner, must set up once**.

**The website is different since 7 October 2026 (decisions 23 and 24).** It is **one program, the same for every customer**, built once per release with no customer's settings inside. Each customer's own settings are a **customer folder** that is read when the website starts. The first section below says how that works; the rest of the page still describes the build service, and says where the website part of it changed.

Staff never see GitHub, Node.js or a terminal. In the Studio this is called **the build service**.

## The website: one program for every customer, with the customer's own folder beside it

**What it is.** The website (`apps/storefront-web-mobile`) is built once per release as **THE website**: `website-windows.zip` and `website-linux.zip`. It holds no customer's name, address, country, colours, logo or licence, and a check refuses a package that does. Each customer's website is **THE website + the customer's folder + the customer's licence file**, put together by *assembling* (a copy of files and checks: no build, no network, no tool, no source code).

**What the website reads when it starts** (before this change every one of these was fixed when the program was built, from `NEXT_PUBLIC_*` values):

| What | Where it is read (storefront `src/`) | Before | Now |
|---|---|---|---|
| Shop name | `lib/shop-name.ts`, `types/site-config.ts` | `NEXT_PUBLIC_SITE_NAME`, default "our store" / "My Shop"; also the upload folder name | the customer's name |
| Web address | `lib/site-url.ts`, `types/site-config.ts`, `app/layout.tsx`, `lib/licence/manager.ts` | `NEXT_PUBLIC_SITE_URL` | the customer's address |
| Country: money, tax name, locale, languages | `lib/region/lite.ts`, `lib/region/server.ts` | `NEXT_PUBLIC_COUNTRY`, **default India (`IN`)** | the customer's country; **with none, neutral: no country, no money symbol** |
| Town or area, tax region | `lib/region/*` | `NEXT_PUBLIC_SHOP_PLACE`, `NEXT_PUBLIC_REGION_CODE` | the customer's |
| Kind of business (the words "Products", "Menu items") | `lib/industry/lite.ts` | `NEXT_PUBLIC_INDUSTRY`, default `retail` | the customer's; **with none, the general kind ("Items")** |
| Colours, tagline, contact lines of the starting design | `types/site-config.ts` | fixed neutral blue; empty contact; never from the customer's brand | the customer's `brand.json` |
| Language of the pages and of dates and numbers | `app/layout.tsx`, `lib/region/lite.ts` | `<html lang="en">` fixed | the customer's language, else the country's |
| Logo | `public/logo.png` | the build copied the customer's logo over it | served from the customer folder (`/customer-assets/<file>`); the built-in neutral logo when there is none |
| Live shop (Supabase), sign-in (Firebase), pictures (Cloudinary): the public parts | `lib/live-shop/config.ts`, `lib/firebase.ts`, `lib/firebase-admin.ts`, `app/admin/media/page.tsx` | `NEXT_PUBLIC_SUPABASE_*`, `NEXT_PUBLIC_FIREBASE_*`, `NEXT_PUBLIC_CLOUDINARY_*` | the same values, from `website-settings.env` in the customer folder |

`robots.txt`, the site map and the offer pages used to be made at build time; they are now made when asked.

**The customer folder** (`customer/`, beside `app/` and `node/` in the package; or the folder named by the setting `NGOS_CUSTOMER_DIR`; the start program sets it). Everything in it is optional and nothing in it is a secret:

| File | What it holds |
|---|---|
| `brand.json` | the brand kit's file: name, short name, tagline, colours (`primaryColor`, `accentColor`), `country`, `industry`, `language`, `contact`, `storefront.siteUrl`, `logo` (the name of a picture file) |
| `setup.json` | the shop program's setup file; the website uses `business.name`, `business.country`, `business.industry` (so one folder can serve the shop program too) |
| `website-settings.env` | the public settings the Setup Studio already writes (`NEXT_PUBLIC_*`); **wins over `brand.json`** where both say something |
| `theme.json` | the look of the shop program; allowed, **not used by the website yet** |
| `assets/` | pictures only: the logo (png, jpg, webp, svg) and `favicon.ico`; a logo beside `brand.json` (the brand kit's way) is also found |

**How a value is chosen:** `website-settings.env`, then `brand.json`, then `setup.json`, then (for a developer only) the old `NEXT_PUBLIC_*` values in the computer's own environment, then **neutral**. The checks are the ones the package maker has always made on these settings (moved, not weakened, into `apps/storefront-web-mobile/src/lib/customer/rules.mjs`): a name has no `<` or `>`, an address must be an address, a country needs its pack, a Supabase key must be the publishable one, a colour must be one white words can be read on, and so on. A value that fails is **left out and named in plain words** (the website writes it once in its log) and the rest still counts. The server reads the folder once, when it starts, and puts the checked values in every page (`window.__NGOS_SETTINGS__`) and at `/api/settings`; the browser never reads a file. To change a setting, replace the folder and start the website again.

**Assembling** (`tools/setup-studio/lib/website-assemble.mjs`, with a command, `scripts/assemble-website.mjs`):

    node scripts/assemble-website.mjs --program website-linux.zip --customer-folder <folder> --licence <licence.ngos> --customer luzon-fresh-mart --person "Asha Admin" --out dist --audit

**The Setup Studio calls the same library** (since 8 October 2026): the customer's step "Website and app" has "Make the website package", which takes THE website from the Studio's programs (the kit), makes the customer's folder from the approved release, and uses the licence file in the customer's licence slot if there is one (`tools/setup-studio/lib/website-local.mjs`, `docs/SETUP-STUDIO.md`). So the build service's website job is no longer needed for staff; it is kept until the build service has run for real once. The command takes THE website (zip or folder), the customer's folder and the customer's licence file, and writes `website-<customer>-<system>/` and its zip. The library lives in the Studio's own folder because the Studio travels without `scripts/` and holds no source; the command is for people who work on the repository and for the release workflow (the package audit lives in `scripts/`). It **refuses**, in plain words and before writing anything: a customer name that could leave the folder; a customer folder that holds anything but the files above (an environment file, source code, a source map, a database, a key, a licence, a script, a link, a folder inside a folder); a value in it that looks like a secret or that the website's own rules would leave out; a missing, too big or wrongly shaped licence file, or one for a PC instead of a website; a program that is not THE website (it must say so in `PACKAGE-INFO.json` and carry its rules file `customer-rules.mjs`, the same file the website reads the folder with). It writes the customer folder, `licence/licence.ngos`, the customer's name in `PACKAGE-INFO.json`, a few lines in front of `READ ME FIRST.txt`, and **a hidden mark** (decision 24): `app/.next/server/.build-info`, a line of JSON with the customer, the person who made it, the time, and a short fingerprint of the licence, so that a copy that leaks points back to where it was made. (The mark is plain data in a file the package audit accepts; it is easy to find for someone who looks, and easy to remove by someone who knows it is there. It makes a leak traceable, not impossible.)

The signature of the licence is **not** checked while assembling: the signing key is the owner's alone and is never on a staff computer. The website checks it every time it runs. Assembling only checks the licence's shape and reads what it says about itself to warn about the usual mistakes (another web address, a trial, an end date that has passed, a licence for PCs).

**What the GitHub build service still does for the website.** Nothing of the build service's steps changed for staff. Behind the button, the website job now builds THE website (`make-website-package.mjs --os ... --customer ... --settings ...`: the older command still works, and now means: build THE website, then put this customer's folder beside it, with no licence file yet) and the result is still `website-<customer>-linux.zip` and `website-<customer>-windows.zip`. Nothing of the customer is compiled in any more. Building the same program again for every customer is wasteful and is only kept so that the first real run of the build service (which has never run) is not changed at the same time; once the Studio assembles locally (decision 23) this job is not needed for the website.

**What the release workflow does for the website.** It builds THE website once per release (`website-windows.zip`, `website-linux.zip`), audits it, starts it from its zip (it must refuse to work without a licence) and puts both zips on the release. `base-kit.json` lists them with the role `website-generic`, apart from a website made for one customer (role `website`). The two inputs "Website customer" and "Website settings" still work, and now mean: **also** put that customer's settings beside the program this run made (assemble; nothing is built again) and add that customer's zip to the release.

## The pieces

| Piece | What it is |
|---|---|
| **The Studio** | Runs on a staff PC. Holds **no source**. Holds two tokens in its own secret store (never in a pack, a backup or the activity record). |
| **S, the source repository** | Your private repository that holds the programs' source. It holds the workflow `.github/workflows/build-customer.yml`. |
| **R, the results repository** | A second private repository that holds **no source**. For each build it holds one release called `customer-<name>-<number>`, with the customer's settings and, when the build is done, the finished files. Suggested name: `nextgenos-customer-builds`. |
| **The DISPATCH token** | Lets the Studio start a build and watch it. For repository S only, permission **Actions: read and write**, nothing else. It **cannot read the source**. |
| **The RESULTS token** | Lets the Studio leave the settings in R and fetch the finished files. For repository R only, permission **Contents: read and write**, nothing else. The same token is stored in S as the secret `RESULTS_TOKEN`, so the workflow can read the settings and put the files in R. |
| **Two public values in S** | `NGOS_PUBLIC_KEYS` and `NGOS_LICENCE_URL`, the same ones the full release uses (`docs/RELEASE-GUIDE.md`). They are built into the website so it can be licensed. **Without them the build is a trial** (see below). |

## What happens when staff press the button

1. The Studio makes a small bundle, `inputs.zip`, for that customer: their brand (`brand.json`), their logo (`logo.png`, if they have one), the public settings of their website (`website-settings.env`), and a description of what to build (`build.json`: the website, the app, or both). The Studio refuses to put anything that looks like a secret in it.
2. The Studio makes a **draft release** `customer-<name>-<number>` in R and puts `inputs.zip` on it. (The number is the Studio's own count of builds for that customer. A draft is seen only by people who can write to R.)
3. The Studio asks S to run the workflow *Build for one customer*, giving only three small things: the customer's short name, the number, and the name of R. No setting travels in that request. **Only one build per customer runs at a time**; a build that is running is never cancelled by a newer one.
4. The workflow takes `inputs.zip` from R and checks it again (the name, the sizes, the files, nothing that looks like a secret, no unknown part). Then it builds what was asked for:
   - **the website for Linux** and **the website for Windows**, each on its own kind of machine (the database engine and the picture library are different files for each system): THE website is built, and the customer's settings are put beside it as a folder (nothing of the customer is compiled in). Each is audited (no source, no key, no database, nothing a factory-new computer lacks), started from its zip (it must refuse to work without a licence), and the Windows one is opened the way a person opens it (double-click, one copy, closing the window stops it);
   - **the Android app**, with the customer's name, colour, logo and web address; the build number is the app's version code, so a phone takes each new build as an update.
5. Each part that worked puts its files on the draft release in R. The last job then writes `result.json` (also when a part failed, with plain words about it) and `SHA256SUMS.txt`, takes away any file that no successful part claims, and **publishes the release, last of all**. A published release with a `result.json` means "finished".
6. The Studio checks regularly (about every 20 seconds, for at most 90 minutes), downloads the files, checks each against `SHA256SUMS.txt`, puts them in the customer's pack, and writes the build in the activity record. If a part failed it says which one and why, in plain words, and offers *Try again* (a new build number).

You may delete old releases in R whenever you like: nothing depends on them once the Studio has the files.

### What comes back

On the release in R:

| File | What it is |
|---|---|
| `website-<name>-linux.zip`, `website-<name>-windows.zip` | The customer's website for each system: THE website with the customer's folder beside it (no licence file yet). Carries its own Node.js; nothing to install first. |
| `SmartRetailPOS-<name>-<version>.apk`, `.aab` | The Android app: the `.apk` to try on a phone, the `.aab` for a store. |
| `ANDROID-SIGNING.txt` | Says which key signed the app (see "Android signing" below). |
| `NO-LICENCE-KEYS-TRIAL-ONLY.txt` | Only on a **trial**. |
| `result.json` | What happened to each part (`success`, `failure` or `skipped`, and one sentence of plain words), whether it is a trial, the commit the programs were built from, when it began and ended. Written also when something failed. |
| `SHA256SUMS.txt` | The fingerprint of every file on the release (including `inputs.zip`, `result.json` and the trial marker). |
| `inputs.zip` | What the Studio sent. It holds only the customer's public settings and brand. |

The version in the file names is `1.0.<build number>`. The first two numbers are `PROGRAM_VERSION_BASE` at the top of the workflow file.

### A trial build

If `NGOS_PUBLIC_KEYS` and `NGOS_LICENCE_URL` are not both set in S, the build is a **trial**: the website is built without licence keys and refuses every visitor (it can never be licensed), `result.json` says `"trial": true`, and `NO-LICENCE-KEYS-TRIAL-ONLY.txt` is on the release. The Studio shows it as a trial and **never gives a trial to a customer**. If only one of the two values is set, the build stops and says which is missing (a half-set value would otherwise give a website that cannot be licensed and is not marked).

**A real build is only made from the `main` branch.** If a build with the licence keys is started from any other branch, it stops and says so: code that is not yet in `main` never gets the licence keys built in for a customer. (A trial may be made from any branch.)

### Android signing

Without the Android signing secrets (`ANDROID_KEYSTORE_B64`, `ANDROID_KEYSTORE_PASSWORD`, `ANDROID_KEY_ALIAS`, `ANDROID_KEY_PASSWORD`, the same ones as the full release) the app is signed with a **one-off test key**, new for every build. That is fine to try on a phone, but a phone will not accept a later build as an update, and a store will not take it. `ANDROID-SIGNING.txt` says which kind of key was used. Set the secrets before giving a customer an app (`docs/RELEASE-GUIDE.md`, step 3).

## What you set up once (click by click)

Do these in order. They need your GitHub account; nobody else can do them. The words on GitHub's buttons change now and then; the idea stays the same.

### 1. Make the results repository (R)

1. On GitHub, press the **+** at the top right, then **New repository**.
2. **Repository name:** `nextgenos-customer-builds` (any name will do; you give it to the Studio in step 5). **Owner:** the same account that owns the source repository.
3. Choose **Private**. (Customers' names and public settings will be in it. Never make it public.)
4. Tick **Add a README file** (a release needs something to point at). Write nothing about a customer in it.
5. Press **Create repository**. Put no source code in it, ever.

### 2. Make the DISPATCH token

1. Click your picture at the top right, **Settings**, then at the bottom of the left menu **Developer settings**, **Personal access tokens**, **Fine-grained tokens**, **Generate new token**.
2. **Token name:** `Setup Studio: start builds`. **Expiration:** choose a date and write it in your calendar; when it runs out, the Studio's button stops working and says so.
3. **Resource owner:** the account that owns the source repository (S).
4. **Repository access:** *Only select repositories*, then choose **the source repository (S) and nothing else**.
5. Under **Permissions**, **Repository permissions**, set **Actions** to **Read and write**. Leave everything else as it is: in particular **not** Contents. (GitHub adds *Metadata: read-only* by itself; that is fine.)
6. Press **Generate token** and **copy it now**: GitHub shows it only once. Keep it for step 5.

If the repository belongs to an organisation that approves tokens, an owner of the organisation must approve it (organisation Settings, *Personal access tokens*).

### 3. Make the RESULTS token

1. The same page: **Generate new token**.
2. **Token name:** `Setup Studio: builds' results`. Expiration: as above.
3. **Resource owner:** the account that owns R.
4. **Repository access:** *Only select repositories*, then choose **the results repository (R) and nothing else**.
5. Under **Repository permissions**, set **Contents** to **Read and write**. Nothing else.
6. Press **Generate token** and copy it. Keep it for steps 4 and 5.

### 4. Give the RESULTS token to the source repository, as a secret

1. Open the source repository (S), **Settings**, **Secrets and variables**, **Actions**, the **Secrets** tab, **New repository secret**.
2. **Name:** `RESULTS_TOKEN` (exactly). **Secret:** paste the RESULTS token. **Add secret**.

(Only the RESULTS token goes here. Never the DISPATCH token.)

### 5. Give both tokens to the Setup Studio

In the Studio open **Settings**, **Connect the build service**. Fill in the two boxes (the Studio's labels say which token goes where), the name of R (`owner/name`) and the name of S, then press **Test the connection**. It checks that the DISPATCH token can see the workflow and **cannot** read the source, and that the RESULTS token can read R, and says in plain words what is wrong.

### 6. Make sure the workflow is on the main branch

GitHub starts a workflow from outside only when its file is on the repository's default branch. Until the work that adds `.github/workflows/build-customer.yml` is merged into `main`, the Studio's button cannot start a build.

### 7. The public licence values (for real builds)

If you have not done it yet: in the Licence Studio, **Settings**, copy the two values under *For a release build*, and in S: **Settings**, **Secrets and variables**, **Actions**, the **Variables** tab, create `NGOS_PUBLIC_KEYS` and `NGOS_LICENCE_URL` (`docs/RELEASE-GUIDE.md`, "What you need once"). These are public values; no secret goes in a variable. Without them every customer build is a trial.

### 8. Optional but needed before a customer gets an app: the Android signing secrets

As in `docs/RELEASE-GUIDE.md`, step 3.

### When a token runs out, or you want to change it

Make a new token the same way, replace it in the Studio's Settings (and, for the RESULTS token, in the secret `RESULTS_TOKEN` too). Deleting a token on GitHub stops it at once.

## When something goes wrong

The Studio says it in plain words. These are the usual causes.

| What staff see | Likely cause | What to do |
|---|---|---|
| "Test the connection" says the workflow cannot be seen | The workflow is not on `main` yet, or the DISPATCH token is for another repository | Step 6 or step 2 above |
| "The build service has no build called …" | The Studio could not put the settings in R | Settings, Test the connection (the RESULTS token) |
| "The files the Setup Studio sent were not accepted. …" | A setting is missing or looks like a secret, the shop's name is longer than 40 letters or has a quote in it (the app uses it as its name), a logo that is not a PNG, … | Change it in the Studio and build again |
| "Only one of the two licence values is set …" | `NGOS_PUBLIC_KEYS` or `NGOS_LICENCE_URL` is missing | Step 7 |
| "A real build … is only made from the main branch" | The build was started from another branch | Start it from the main branch (the Studio always does) |
| One part failed (the message says which step it stopped at) | A real build problem, or a passing problem at GitHub | Look at that run in S, Actions; then *Try again* in the Studio (a new build number) |
| "The build service could not start the build: GitHub gave it no machine to build on, so nothing was built." | The GitHub account's build time or spending limit has run out, or Actions is switched off for S. Every job fails at once, before it starts | The owner opens GitHub, **Settings**, **Billing and plans**, and checks the Actions minutes and the spending limit (and S, **Settings**, **Actions**, that Actions is allowed). Then press *Try again* in the Studio |
| "The build service could not take this customer's settings: the key that lets it read the results place is missing, has run out, or is for the wrong place." | The secret `RESULTS_TOKEN` in S is missing, has expired, or is the token of another repository | Steps 3 and 4 above (a new RESULTS token, then the secret), then *Try again* |
| The build never finishes | GitHub is slow, or the run was stopped | The Studio waits at most 90 minutes, then says so. Look at the run in S, Actions |
| A token stopped working | It ran out (the date in step 2 or 3) | Make a new one |

A finished build is never changed: *Try again* always makes a new build number.

## The first build: a trial for a made-up customer

Do this once, after steps 1 to 6, **before** any real customer. It costs a few build minutes and shows whether the whole chain works on your GitHub. It needs no licence keys and no Android signing secrets, so it is a **trial** and is never given to anyone.

1. In the Setup Studio, make a new project called for example `Test Shop` (a made-up name, not a real customer). Fill in the company details as for a real one, and choose a logo that is a PNG.
2. Get the project's setup approved (the Studio's normal review step: the build is made from an approved setup). Then open the project's step **Website and app** and press the button **Build Test Shop's website and app** (it carries the project's name). Only a reviewer or an administrator sees the button work.
3. Watch the progress. The Studio shows each part (the website, the app) as waiting, building, built or failed, and keeps going if you close it: open the step again and it picks the build up. Expect something like 20 to 60 minutes the first time (a guess: nobody has timed it yet).
4. When it finishes, the Studio shows **trial** next to the build and puts the files in the project's folder. Make the project's pack again (it then holds them), and install the Android file on a test phone if you like.
5. If a part fails, the Studio says in words which part and what to do (see the table below). Fix that one thing and press **Try again**; every try is a new build number, and nothing a failed build made is kept.
6. When a trial works, set the public licence values (step 7) and the Android signing secrets (step 8), and build again: the result is then a real build, not marked trial.

Write what happened (how long it took, what it cost, what failed) into `docs/OPEN-WORK.md` so the next person knows.

## Limits you should know

- **One build per customer at a time.** If the Studio asks for a second build of the same customer while one runs, GitHub keeps the second one waiting; if a third arrives, the waiting one is dropped. The Studio does not ask for another build of a customer while one is running, so this should not happen. Different customers build at the same time.
- **Cost.** Every build uses minutes of your GitHub Actions allowance: the website is built twice (Windows minutes count for more than Linux ones) and the app once. Check your plan.
- **The DISPATCH token can start any workflow in S that has a *Run workflow* button**, not only this one: that is how GitHub's permission works. This is why the Studio keeps it in its secret store. It still cannot read the source.
- **`RESULTS_TOKEN` is a secret of S.** Anyone who can change workflows in S could make a workflow print it. It can only reach R, which holds no source and only customers' public settings and finished files, but keep the list of people who can write to S short.
- The workflow reads the Android signing secrets only in the step that makes the signing key, and the results token only in the steps that talk to R: never in a step that builds anything.

## Why it is built this way

- **No source leaves S.** R and the Studio hold only settings and finished programs. The programs are the same ones a customer is given; they carry no source (`scripts/audit-package.mjs` checks every website zip, and the app is checked for source files).
- **No secret travels.** The bundle is checked by the Studio and again by the workflow (the same secret patterns as the release gate). `result.json`, the messages and the logs hold no token; the helper scripts take the token out of any message before they print it, and only send it to GitHub's own address.
- **Nothing about a customer is written in the workflow file or in program code.** The customer's name, brand, logo and settings arrive in the bundle; a test checks that the workflow names no customer. For the website they stay data all the way: they are never compiled in, they are a folder beside the program.
- **A part that fails hands over nothing.** Its half-made files are taken away from R, and `result.json` says what happened in words a person can act on.

## What was checked, and what was NOT

**Checked here, by tests that run in the gate** (`node scripts/verify-all.mjs`, the check `package-audit-tests`):

- `scripts/tests/customer-build-validate.test.mjs`: what the workflow accepts from the Studio and what it refuses (names, build numbers, the results place, the zip: names that try to leave the folder, locked or damaged or oversized zips, a file that is not one of the four, secrets, unknown parts, missing settings, a logo that is not a picture, an app name the app set-up would refuse; the licence-key state that makes a trial).
- `scripts/tests/customer-build-result.test.mjs`: the words for each part, `result.json` (exactly the agreed fields), `SHA256SUMS.txt`, the report of a part and the file names each part may make.
- `scripts/tests/customer-build-results.test.mjs`: the real helper programs against a **stand-in for GitHub's web interface**: taking `inputs.zip` off the draft, refusing a build that is finished or missing, putting files on it (only this build service's own file names, only while it is a draft), writing `result.json` and the fingerprints with every part worked, with a part failed, with a part that left no report, with files that did not arrive whole, with a trial, and publishing **last**; that only the results token is ever sent and never printed.
- `scripts/tests/customer-build-workflow.test.mjs`: the **structure of the workflow file**: it starts only from the Studio's request; one build per customer without cancelling; the jobs and what each waits for; the publishing job always runs and is last; the results token is read only from secrets and only by the steps that talk to R; typed values reach scripts only through the environment; nothing about a customer or a token is written in it; the website steps, their order and the Windows try-out are there. The file was also read once by the workflow checker `actionlint` on the author's machine (no problem found); that is not part of the gate.

**The website as one program for every customer (7 October 2026). Checked by tests in the gate:**

- `apps/storefront-web-mobile/src/lib/customer/settings.test.ts` (17 tests, in `storefront-tests`): changing the customer folder changes the shop's name, web address, country and money, language, colours, tagline, contact lines, logo and kind of business; with no folder, or an empty one, the website is neutral (no country, no currency symbol, "Items", no company, none of India, rupees, Hindi or a kind of shop); a value that fails its rule is left out and named; a secret key and a private setting are dropped; the order of the files; the developer's fallback; the page carries the settings and cannot be broken out of; `/api/settings`; `/customer-assets/<picture>` refuses a name that leaves the folder and a file that is not a real picture; and **no source file reads a `NEXT_PUBLIC_` value from the build**.
- `scripts/tests/make-website-package.test.mjs` (26 tests): THE website holds no customer folder, name, settings or licence and is the same whatever the build was given; a customer folder or a licence file in it is refused; one customer's website (made by assembling) passes the package check and both audits; the start program points the website at `customer/`.
- `tools/setup-studio/tests/website-assemble.test.mjs` (11 tests) and `unzip.test.mjs` (4): a good folder and licence make the customer's website, from a folder or from the zip (the right to run survives); a missing licence, a planted environment file, source, map, database, key, script, link, folder or secret, a hostile customer name or zip name, a program that is not the generic one, and a licence of the wrong shape are each refused with nothing written; the mark is present and correct.
- `scripts/tests/make-base-kit.test.mjs`, `make-release-notes.test.mjs`: THE website is listed as `website-generic`, apart from a website made for one customer, and the release page says what it is.

**Also run here by hand, once (not part of the quick gate):** the real Linux package was built (a trial build, no licence keys), audited and started with its own Node.js: **THE website alone said nothing of a customer**; assembled with a made-up customer folder and a licence-shaped file (a wrong signature), audited (4,811 files), unpacked and started: **the page carried that customer's name, the logo came from the customer folder, a name that leaves the folder was not served, and the website refused the unsigned licence file** (`scripts/smoke-website.mjs` now makes these checks). The existing licence end-to-end test (`node licensing/e2e/with-studio.mjs -- node licensing/e2e/website-package-e2e.mjs`, which builds the package through the older command, with a real throw-away Licence Studio) passed all 14 checks: a real licence is accepted, an edited one and another web address are refused, a withdrawn one stops the website.

**NOT verified for the website change (a person must):**

- **A real Windows PC.** The Windows package, its launcher and an assembled Windows folder were not built or opened here (the release workflow does it on a Windows runner, which has never run with these changes).
- **A real customer folder made by the Setup Studio**, and the Studio putting it in: no screen of the Studio calls assemble yet. The tests use folders written by hand in the Studio's shape.
- **A real licence from the real Licence Studio put in by assembling**, and then the website run with it: the assemble step checks the licence's form only (the signing key is never on a staff computer). The licence end-to-end test above did put a real licence in the folder by hand.
- **The website in a real browser**: the pages carry the settings, and the production build and the server were run, but no browser opened a customer's page here.
- **The GitHub workflows** (the release workflow, whose website job was changed, and the build service): checked as files and by their tests, never run.
- A mistake in a customer folder is written once in the website's log; when the website opens as a program of its own nobody sees that log (`CLAUDE.md` section 10 wants a plain note). The assemble step catches the mistakes first, but a folder changed by hand afterwards is not reported to the person.

**NOT verified (a person must):**

- **A real run on GitHub, with your repositories and your tokens.** None was made: this work was done in a cloud session with no access to your GitHub, so the whole chain (the Studio starting the workflow, the workflow reading from R and writing to it, the Windows and Android builds, the Studio fetching the result) has **not** been run end to end. Whether GitHub accepts every setting in the workflow file exactly as written, how long a build takes, and what it costs are not known yet. **The first real build is the test.** Try a trial build for a made-up customer first.
- That the two tokens, with exactly the permissions above, can do what they should and no more, on your account or organisation (the Studio's *Test the connection* shows it).
- That GitHub keeps what the jobs hand on to each other as the workflow expects (the outputs of the first job, the small reports of the parts) when a job fails or is stopped.
- The Windows website opened as a window on a real Windows machine (the workflow does it at GitHub; it was not run); the Android app built from a customer's brand (the steps are those of the full release, with the brand taken from the settings; not run here).
- The Studio's side (the button, the progress, the download, the checking of the fingerprints, the plain messages) **is built and is tested against a stand-in for GitHub** (`tools/setup-studio/tests/builds.test.mjs`, in the gate). The stand-in is written from GitHub's documentation, not from a real run, so the Studio and the real GitHub have **not** yet been run together.

## For engineers: what the Setup Studio can rely on

- **Start it:** `POST /repos/<S>/actions/workflows/build-customer.yml/dispatches`, `ref` = the default branch, `inputs` = `{ customer, build, results_repo }`, all strings. The run is found afterwards from the run list of that workflow.
- **The release in R:** a **draft** with tag `customer-<customer>-<build>` and the asset `inputs.zip` before the run starts. A release that is already published, or already has `result.json`, is refused ("already finished").
- **`inputs.zip`** holds only these files (any other name is refused): `build.json` `{ "schema": 1, "customer", "build" (a number), "studioVersion" (optional, plain text up to 40), "parts": { "website": bool, "android": bool } }` (it must agree with the three inputs; at least one part true; no other part name), `brand.json` (needed for the app; checked with the Brand Studio's own rules, plus `android.appId`, `android.storefrontUrl` and `primaryColor` for the app; the name must be at most 40 letters with none of `< > & " '` or a backslash because it is also the app's name), `website-settings.env` (needed for the website; checked by `scripts/make-website-package.mjs`'s own rules and country and industry packs), `logo.png` (a PNG, up to 3 MB). Limits: the zip 8 MB, `build.json` 8 KB, `brand.json` 64 KB, `website-settings.env` 32 KB. Customer name: 2 to 41 small letters, digits and hyphens, not starting or ending with a hyphen. Build: a whole number from 1 to 9999999. `results_repo` must not be the repository the workflow runs in.
- **The jobs** (their names are the plain steps the Studio can show): `Reading the customer's settings`, `Building the website for Linux`, `Building the website for Windows`, `Building the Android app`, `Writing the result and publishing it`. A part that was not asked for is skipped.
- **Finished** = the release in R is **published** and has `result.json`. It is published last, after `result.json` and `SHA256SUMS.txt`.
- **`result.json`:** `{ schema: 1, customer, build, trial, sourceCommit, startedAt, finishedAt, parts: { "website-linux", "website-windows", "android": { status: "success" | "failure" | "skipped", message } } }`. `message` is one line of plain words, never names GitHub or its Actions, and holds nothing that looks like a secret. When the settings were refused, each part that was asked for says why and the others are `skipped`.
- **`SHA256SUMS.txt`:** one line per file in the form `sha256sum` writes (`<hash>  <name>`): every file on the release except itself, including `inputs.zip`, `result.json` and the trial marker.
- **File names:** `website-<customer>-linux.zip`, `website-<customer>-windows.zip`, `SmartRetailPOS-<customer>-<version>.apk` and `.aab` (the version is `1.0.<build>`), `ANDROID-SIGNING.txt`, `NO-LICENCE-KEYS-TRIAL-ONLY.txt`.
- **A part that did not work leaves no file** on the release. A `success` part's files are all there, whole.
- **Where the code is:** `.github/workflows/build-customer.yml`; `scripts/customer-build/validate-inputs.mjs` (the checks), `results.mjs` (talks to R: `download-inputs`, `upload`, `finish`), `result.mjs` (the words, `result.json`, the sums, the report of a part), `github-api.mjs` (the client; the token is never printed and is only sent to GitHub). The website and the app are built by the same scripts as the full release (`scripts/make-website-package.mjs`, `scripts/smoke-website.mjs`, `scripts/audit-package.mjs`, `scripts/audit-prerequisites.mjs`, `apps/storefront-web-mobile/scripts/android-config.mjs` and `make-icons.mjs`); nothing of their logic is repeated.
- **Not done in this workflow:** it does not run the whole gate (the Release workflow does that for every release of the programs); it builds the programs as they are in S at the commit it runs on, and `result.json` says which commit that was.
