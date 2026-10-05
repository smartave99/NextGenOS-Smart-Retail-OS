# Smart Retail POS — AI Assistant

*by NextGen OS*

A Windows app for a shop that runs Smart Retail POS: today's sales at a glance, **Ask AI** for questions about sales, stock, customers, suppliers, payments and expenses (in English, Hindi or Hinglish), the plan to grow sales, and product photos made by AI. It runs **beside the existing POS** on the same PC and only **reads** the POS database; it never changes anything. The POS keeps doing all the billing, printing and barcode work, with all its features and hardware, exactly as before.

For example: *"What were my top 5 products last week?"*, *"Aaj kitna cash aaya?"*, *"Which items are below minimum stock?"*

## The app

Smart Retail POS opens in its own window, from the Start menu or the taskbar, in light or dark (it follows Windows, or choose in *Settings*). The sidebar has:

- **Today**: sales so far against the same day last week, the last 7 days, suggestions (what to reorder, which best sellers need photos, stock that does not sell, the busiest day) and what is running low.
- **Ask AI**: the chat. Ask anything, or tap a built-in report such as *Today's sales*. Answers come with their table, and *How this was found* shows the read-only query. A question can bring photos (a file, a paste, or the camera) and, with a Codex model that listens, a voice note; otherwise the microphone button starts Windows voice typing. See [Photos and voice notes in Ask AI](../SmartRetailPOS/README.md#photos-and-voice-notes-in-ask-ai).
- **Posters**: A4 sale posters to print (Clearance, New arrivals, Best sellers, Festival offer). The AI picks the products and writes the words, Codex makes the artwork, and the app prints the names and prices exactly as the POS has them, with offers that never go below cost.
- **Sales**, **Grow sales**, **Bills**, **Products**, **Low stock**, **Product photos**, **Storage** and **Settings**. The search box (**Ctrl+K**) finds products.

The screens are the dashboard's pages (see [`SmartRetailPOS/`](../SmartRetailPOS/README.md)), shown by **Microsoft Edge WebView2**, the browser engine built into Windows 11 and into most Windows 10 PCs; setup installs it where it is missing. Without WebView2 the app still works as before: the earlier side panel, with the dashboard in the browser.

- The dashboard is in the `Dashboard` folder of this package. The app starts it without a window and stops it when the app quits. It only answers on this PC (`http://127.0.0.1:5080/`); *Settings → Side panel → Sales dashboard* can change the address or the program's path.
- It uses the same database connection and the same AI tools as the app, from the app's settings, so there is nothing to set up twice. Links to other websites, such as the ChatGPT sign-in page, open in the browser.
- Closing the window in side panel mode does not quit the app: it waits beside the POS as the AI tab and the tray icon. Quit from the tray icon's menu.
- **Its own top bar.** In place of the empty Windows title bar, the top bar holds:
  - the name and the search (**Ctrl+K**);
  - the shop's data (*Live · read-only* or *Demo data*);
  - the AI (*AI ready*, with how much of Codex's 5-hour limit is used);
  - a bell for what needs the owner: mistakes to fix, what the AI learned, actions heard in chats;
  - the minimise, maximise and close buttons.

  Drag the bar to move the window, and double-click it to maximise. The edges resize the window, and Windows snap works as before. While the app starts, or when the page cannot be shown, the Windows title bar comes back, so the window can always be moved and closed. With a WebView2 Runtime too old for it, the Windows title bar simply stays.

## The side panel beside the POS

By default the app also has a slim panel on the right edge of the screen that stays above the POS. It shows today's sales and bills, and Ask AI: the same conversation as in the app window.

- **Open it** with the small **AI** tab on the screen edge, the tray icon, or the shortcut **Ctrl+Shift+Space**, which works while the POS is in front. The cursor is in the question box, ready to type.
- **Close it** with **Esc**, the shortcut again, or its close button. You are put straight back in the POS window you were using.
- Its buttons: **Settings**, **Wider** (room for big tables), **Open the full app** and **Hide**.
- Opening the app again, for example from its desktop shortcut, brings the running copy forward.

*Settings → Side panel* chooses the screen edge (right or left), the width, the AI tab, the shortcut (it must use Ctrl, Alt or Win, so typing in the POS is never affected) and **Start with Windows**, which is also a switch on the dashboard's own *Settings* page. It can also turn the side panel off, so the app is only a window.

## Product photos and storage

- **Product photos** turns phone photos of a product into five photos for a website and Amazon, made one by one by ChatGPT Images through Codex:
  - white background;
  - in use;
  - with a European, an Indian and an East Asian model.

  The AI also says what the product is, so the growth plan knows products the POS names only by a code. It needs Codex signed in with a ChatGPT plan that includes images, or with an OpenAI API key. See [Product photos](../SmartRetailPOS/README.md#product-photos).
- **Posters** makes A4 posters from the POS figures, with the product photos on them. See [Posters](../SmartRetailPOS/README.md#posters).
- **Storage** chooses where photos, plans and posters are kept, by the drives' free space, and moves them safely. See [Storage](../SmartRetailPOS/README.md#storage).

## How Ask AI works

1. The shop owner types a question, in the app window or the side panel, perhaps with photos or a voice note (the AI reads them first, and says what it heard).
2. The chosen AI writes one SQL query for it.
3. A built-in safety check (`SqlGuard`) accepts only a single read-only `SELECT` on approved business tables. If it refuses the query, or SQL Server rejects it, the AI gets one chance to correct it.
4. The query runs on the POS database. It uses no locks, so billing is never blocked, and it runs inside a transaction that is always rolled back, so it cannot change anything.
5. The AI explains the result in plain words. Phone numbers, e-mail, addresses and tax IDs are hidden from it first.
   Both steps are given what the assistant remembers about the shop and the owner, and the shop's saved playbooks (see [Memory](../SmartRetailPOS/README.md#memory)). "Remember that…" and "Forget…" change memory at once, without an AI.
6. The answer, the result table and the exact SQL used are all shown on screen.

Seven **built-in reports**, shown as buttons above the question box, use fixed, reviewed SQL and work even with no AI set up:

* Today's sales
* Last 7 days
* Top products this month
* Low stock (items with a reorder level that are below it)
* Stock to correct (negative stock: sold before the purchase was entered)
* Payments today
* Sales vs expenses this month

## AI providers

The assistant talks to AI through **command-line tools installed on the PC** (primary) or **directly with an API key**. In *Auto* mode it uses the first ready provider in the configured order: **Codex CLI first**, then the others. If one fails, it moves to the next. The shop can reorder the list or pick one provider in *Settings → AI provider*.

| Provider | Install (on the shop PC) | Signs in with | How it is run |
|---|---|---|---|
| **Codex CLI (OpenAI)** — default | **Automatic:** the dashboard's *Get started* page runs OpenAI's official Windows installer (`chatgpt.com/codex/install.ps1`, no Node.js needed), and the dashboard keeps it up to date (see *Keeping Codex up to date*). By hand: that installer, or `npm install -g @openai/codex` | **Sign in with ChatGPT** on *Get started*, with a one-time code (`codex login --device-auth`), **or** an OpenAI API key (*Get started*, or *Settings → CLI tools → Sign in Codex with the OpenAI API key*) | `codex exec --sandbox read-only --ephemeral`, prompt on stdin, in an empty temporary folder. For product photos: one `codex exec --image … --enable image_generation --sandbox workspace-write` run per photo, in an empty folder holding only copies of the photos |
| **Claude CLI (Anthropic)** | PowerShell: `irm https://claude.ai/install.ps1 \| iex` | **Anthropic API key** (required, see below) | `claude -p --bare --tools ""` (all tools off), key passed only to that process |
| **Antigravity CLI (Google)** | PowerShell: `irm https://antigravity.google/cli/install.ps1 \| iex` | Run `agy` once to sign in with Google, **or** tick *Use the Gemini API key* | `agy -p --sandbox --output-format json` |
| **OpenAI API** | — | OpenAI API key | Responses API, default model `gpt-6-sol`, `store: false` |
| **Claude API (Anthropic)** | — | Anthropic API key | Official Anthropic C# SDK, default model `claude-opus-5`, Anthropic's server-side fallback if a request is declined |
| **Gemini API (Google)** | — | Gemini API key | `generateContent`, default model `gemini-3.5-flash` |
| **OpenAI-compatible** | e.g. [Ollama](https://ollama.com) | optional key | `/v1/chat/completions`; a local model keeps everything on the PC |
| **Custom CLI** | any tool | its own | command and arguments from Settings (`{model}`, `{prompt_file}`, `{system_file}`, `{workdir}`) |

**Whose accounts:** every shop uses **its own** AI accounts and keys, entered on its own PC. Never ship NextGen OS keys or sign-ins with the app.

**Account rules to respect:**
- **Anthropic** does not allow third-party apps to use a Claude.ai (Free/Pro/Max) *subscription* sign-in. So the Claude CLI provider always runs in `--bare` mode with an Anthropic API key from [platform.claude.com](https://platform.claude.com), and never touches a subscription login.
- **OpenAI** supports both ChatGPT sign-in and API keys for Codex, and recommends API keys for automated use. A shop that uses the assistant heavily should prefer an API key.

**Model names** can be changed in Settings. Leave a CLI model empty to use the tool's own default.

## Installing at a shop

1. **Install the app.** Run `SmartRetailAI-Setup.exe`, from the repository's **Releases** page on GitHub (or see *Building* below), signed in to Windows as the user who works at the POS.
   - **SmartScreen:** Windows may say *Windows protected your PC*, because the setup is not code-signed yet. Click **More info**, then **Run anyway** (see *The Windows warning when installing*, just below).
   - **For whom:** *Install for anyone using this computer* puts it in `C:\Program Files\NextGen OS\Smart Retail POS AI` and asks for administrator rights. *Install just for me* needs no administrator and uses `%LOCALAPPDATA%\Programs\NextGen OS\Smart Retail POS AI`.
   - **Folder:** any folder or drive. Type it or click **Browse**. If the folder already holds other files, setup offers a new folder inside it; if it cannot write there, it says so.
   - **Options:** a desktop shortcut, and **Start with Windows**, which is the same as *Settings → Start with Windows*. Both are on by default. The start-up entry is made for the Windows user who runs the setup: if Windows asks for an administrator's password and that administrator is not the user who works at the POS, sign in as the POS user after setup and check that *Settings → Start with Windows* is on.
   - **Requirements:** Windows 10 or 11 (64-bit) and .NET Framework 4.8, which the POS already requires; setup checks for it. The app's windows use the Microsoft Edge WebView2 Runtime: if the PC does not have it, setup downloads it from Microsoft (it needs the internet for a minute).
   - **Silent install:** `SmartRetailAI-Setup.exe /S /AllUsers` (or `/CurrentUser`), optionally with `/D=D:\Apps\Smart Retail POS AI` as the last option, without quotes.
   - **Updating:** run a newer setup the same way. It removes the earlier copy first, wherever it was, and keeps settings, photos and plans. Or let the app do it by itself: see *Automatic updates*.
   - **Uninstalling:** Windows *Settings → Apps*. It removes exactly the files it installed and keeps settings, photos and plans.
   - **Without the setup:** unzip `SmartRetailAI.zip` to a folder instead and start `SmartRetailAI.exe`.
   - **First start:** the app finds the POS database, then opens on **Get started**. It installs Codex by itself and has a **Sign in with ChatGPT** button: open the page it shows, on the PC or a phone, and type the one-time code. See step 3.
2. **Connect the database: usually nothing to do.** On its first start the assistant finds the POS database by itself and says what it found (shop name, number of bills, date of the last bill). It looks for:
   - the POS program: open now, recorded by its installer, or in Program Files or the drives' top folders;
   - the POS's own connection settings (`SQLSettings.dat`, `TempDBSettings.dat`);
   - every SQL Server installed on the PC, keeping the databases that have the POS tables. The one the POS uses comes first, then the one with the latest bill.

   To check or change it later: *Settings → Database → **Find automatically***, then **Test connection**. If it cannot find the POS (for example, SQL Server is on another PC), choose the POS folder or type the server there and click *Find automatically* again.
   - The POS itself signs in to SQL Server as `sa` (full administrator), and the assistant can borrow that login. It is strongly recommended to run `sql\create_readonly_login.sql` (also a separate file of each Release) as an administrator once, then use the `smartretail_ai` login it creates. *Find automatically* tries a saved read-only login first and says whether the login it used could change data.
   - That login can only read, and cannot see password, API-key or bank-detail data. It can read the POS's own log (`Logs`), where the times of bills are; the AI never reads it. If you ran the script before version 1.7, run it again so the dashboard can show the times of bills.
3. **Sign in to the AI** on **Get started**: Codex is installed by itself, then **Sign in with ChatGPT**, or paste an OpenAI API key. The other providers in the table above are set up in *Settings → Advanced settings* (the settings dialog, also in the tray menu).
4. **Check it end to end.** In **Ask AI**, tap *Today's sales*, then ask a question.
5. **Check it beside the POS.** With the POS open and in front, press **Ctrl+Shift+Space**, ask something, then press **Esc** and type in the POS: the typing must land in the POS. *Start with Windows* is ticked by the setup, so after a restart the app starts by itself when this Windows user signs in, waiting as the AI tab beside the POS (with the dashboard ready in the background); the switch is in *Settings → Start with Windows*, which also says so when Windows itself has the app switched off in its list of start-up apps (Task Manager or *Settings → Apps → Startup*), where an entry does not start although it is there; turning the switch on switches it on there again. It starts when Windows starts *and someone has signed in*: for a PC that should start it after a power cut, also set Windows to sign in by itself (Start → run `netplwiz`, untick *Users must enter a user name and password*). Right after Windows starts, SQL Server can need a minute or two before the POS database answers, and the dashboard looks for the database only once, when it starts (and shows the demo shop if it finds nothing). So when Windows starts the app, it first waits, up to three minutes, for the saved POS database (or another one on the PC) to answer, and the window says *Waiting for the POS database to start…*. If the database comes later than that, the app notices (it looks every 30 seconds for ten minutes, then every two minutes) and starts the dashboard again by itself, so the demo shop does not stay on screen.
6. **Look at Today** in the app window. The first start takes a few seconds; the bottom of the sidebar shows the shop's name and **Live · read-only**.

## The Windows warning when installing

**What you see.** The first time the setup is run, Windows may show a blue box, *Windows protected your PC*, saying that Microsoft Defender SmartScreen prevented an unrecognized app from starting. After **More info** it names the file and the publisher, *Unknown publisher*, and offers **Run anyway**.

**What it means.** It is not a virus report, and nothing was found in the file. SmartScreen warns about any program that came from the internet and is either not *code-signed* (signed with a certificate that says who made it) or not yet known to Windows from many other PCs. This setup is not code-signed yet, and each new version is a new file Windows has never seen, so the box can come back with every release. It is the same box for every small program that is not from a big company.

**What to do, once for each download.**
1. Click **More info**, then **Run anyway**.
2. If Windows blocks the file in another way, right-click `SmartRetailAI-Setup.exe`, choose **Properties**, tick **Unblock** at the bottom, click **OK**, and run it again (or in PowerShell: `Unblock-File .\SmartRetailAI-Setup.exe`). This removes the *came from the internet* mark that starts the check.
3. To be sure the file is the one that was published, compare its fingerprint with the SHA-256 the Releases page shows beside the file: `Get-FileHash .\SmartRetailAI-Setup.exe -Algorithm SHA256`.

**Updates made by the app** do not show this box. The app downloads the update itself, checks GitHub's signed statement and the file's fingerprint (see *Automatic updates*), and only then starts the setup. Windows may still ask *Do you want to allow this app to make changes to your device?* when the app is installed for everyone on the PC.

**Making the warning go away for good** needs the setup to be code-signed. The ways, from the least to the most work (prices and rules change, so check them before buying anything):

| Way | What it takes | What it gives |
|---|---|---|
| **SignPath Foundation** (free signing for open source) | The code must be public with an open-source licence (this one is MIT), have a page that says who may sign a release and how (a *code signing policy*), and someone to approve each release. The Foundation checks the project and signs from its own service. | The setup carries a signature and a publisher name (the Foundation's). Windows still learns to trust a new file slowly, so a few early downloads may still see the box. |
| **A certificate in the company's name** from a certificate authority (DigiCert, Sectigo, SSL.com and others) | Usually a few hundred US dollars a year and papers that prove the company exists. Since 2023 the certificate's key must stay on a hardware token or in the authority's cloud signing service, so it cannot be kept as a secret file in GitHub; the release workflow then needs a signing step for that service. | *Verified publisher: NextGen OS* in the box. SmartScreen still warns until enough people have installed the same signed program without trouble (weeks); after that the box stops. |
| **Microsoft's own signing service** (Artifact Signing, earlier called Trusted Signing) | About 10 US dollars a month; open to companies and individuals in only some countries. | The same as above, with Microsoft doing the checks and the signing. |
| **The Microsoft Store** | Packaging the app as MSIX and passing the store's review. | No box at all, because Microsoft vouches for the app. It does not fit this app today: it installs another program (Codex) and runs a local dashboard. |

Until then, the release page tells the shop what to click, and updates made by the app go around the box.

## Automatic updates

Once the owner has set up an update folder (below), the app looks for a newer version two minutes after it starts and then every six hours, downloads it in the background, checks it, and tells the owner: an entry in the bell, a card in *Settings → Updates* (what is new, *Install now*, *Check now*) and, where the dashboard is in a browser (no WebView2), which cannot start the setup, a line in the assistant window's status bar (*Version x is ready: install…*), and, with the side panel, a message from the tray icon and an *Install update* item in its menu. **It installs only when the owner says so.** Then the app closes, the setup updates it quietly (Windows may ask for permission, as for any setup that installs for everyone), and the app opens again by itself. Settings, photos and plans are kept, a desktop shortcut or *Start with Windows* the owner had turned off does not come back, and a copy that was not put where it runs by the setup (unzipped by hand) does not update itself.

**Why it is safe.** The update folder is public, so anything could be put in it by someone who got in. The app therefore takes a version only when `latest.json` carries a statement signed by GitHub (an Actions OIDC token, checked against the keys GitHub publishes at `token.actions.githubusercontent.com`) that is for this version and this very SHA-256, and was made by this repository's `installer.yml`, started by hand on `main`. The repository and its owner are named by their numbers, which a rename does not change, and are fixed in the app when it is built (`build.ps1 -UpdateFeed`, which the workflow gives its own), never read from a file on the PC. The download must have exactly the size and SHA-256 that was signed, it is checked again just before it runs, and the app installs only what it checked itself since it started, never a status or a file found on disk. Answers must stay on https. If any check fails the update is not downloaded or not installed, and the card says why in words.

**Setting it up, once.** It needs your Supabase project (the one for the owner's live view will do) and this repository's settings on GitHub. Until you do, nothing changes: the app is built without an update folder and never looks.

1. In Supabase, **Authentication → Users → Add user**: make an *uploader* (any e-mail, a long password, *Auto Confirm User* ticked). It is used by nothing but the release workflow.
2. Open **SQL Editor**, paste `supabase-app-updates.sql` (a file of the Release, and in `SmartRetailPOS/cloud/`), put the uploader's e-mail on the line marked *CHANGE THIS*, and run it. It makes a public folder `app-updates` (a file at most 40 MB, only setups and descriptions) that only the uploader can write to. It is not the project's service key, and it can do nothing else in your project. Running it again is safe.
3. In GitHub, **Settings → Secrets and variables → Actions**: under *Variables* add `UPDATE_FEED_URL` (`https://<your project>.supabase.co/storage/v1/object/public/app-updates/`, ending in `/`) and `UPDATE_ANON_KEY` (the project's public *anon* key), and under *Secrets* add `UPDATE_UPLOAD_EMAIL` and `UPDATE_UPLOAD_PASSWORD`.
4. Publish a release as usual: **Actions → Installer → Run workflow** on `main`, with the version, and optionally a sentence of *notes* (what is new, shown to the owner before installing; left empty, it is the sentence under that version in `CHANGELOG.md`). That release is built with the folder in it and is also put in the folder. The version must be the one in the code (`Directory.Build.props` of both `SmartRetailAI` and `SmartRetailPOS`) **and the newest entry of `CHANGELOG.md`, with at least one change listed**: the workflow's first job stops the whole run when it is not (not even the tests start), since an app that updated to a setup with another number would report the old one and be offered the same update again, and an owner must be able to read what an update changes. Install that one by hand on the shop PC; from then on each release made this way is offered by itself.

**What changed, in the app and in the release.** Every update has its entry in `CHANGELOG.md`: what is new, improved and fixed, in plain words. The dashboard carries it and shows it under *What's new* (a dot in the menu and a banner on Today after an update, and a link in *Settings → Updates*); the release workflow puts the entry at the top of the GitHub Release's text.

The free Supabase plan takes no file over 50 MB and the setup is about 53 MB, so the setup is put online in pieces of 32 MB (`SmartRetailAI-Setup-x.y.z.exe.001`, `.002`) that the app joins and checks as a whole; only the last two versions stay in the folder.

Checked by tests: `dotnet test` (`UpdatesTests`: the statement, the pieces, https, the status files; `PublishUpdateScriptTests`: what `publish-update.sh` writes is accepted by the app's own checker, with a real RS256 statement), `installer/test-update.sh` (the setup's quiet update under Wine: the wait for the app, the owner's choices kept, giving up, uninstalling), `tests/publish/run.sh` (the script's upload, headers, order and clean-up against a stand-in for Supabase over https), `../SmartRetailPOS/cloud/test/run.sh` (the folder's script on Supabase's own database image, Docker), and `npm run test:updates` in the dashboard (the card, the bell and the messages to the app). **Not checked before release:** the part that needs Windows and an installed copy, that is, Windows' permission prompt, the app closing, the setup running and the app opening again. Watch the first update on a real PC.

## Keeping Codex up to date

Codex only looks for a newer version of itself in its own terminal screen, which this app never opens (it runs Codex in the background), so nothing else would ever update it. The dashboard does, in *Settings → Updates → Codex, the AI tool*. Only Codex, the default AI tool, is updated this way; the other command-line tools are left as they are.

- **It looks** two minutes after the app starts and then every six hours, at OpenAI's release channel (`releases.openai.com/codex/channels/latest`, then GitHub's list of Codex releases, https only). Only a stable release counts; an alpha or a beta never does.
- **A new release settles for a day.** A release that turns out bad is usually replaced within hours, so a release the PC first saw less than a day ago is not installed by itself. *Update now* installs it at once.
- **It installs at a quiet moment.** Every run of Codex (a chat answer, a photo, a poster, the usage meter) goes in through one gate. The update starts only when nothing is running, and while Codex is replaced, which takes a minute or so, a new AI task waits for it and goes on when it is done. If a task is running, it tries again in ten minutes. Nothing that started is ever cut off.
- **It uses OpenAI's own installer** (the same `install.ps1` that *Get started* runs, for the newest release), so the download is checked by the installer's own SHA-256 check, and only for a Codex that installer put in `%LOCALAPPDATA%\Programs\OpenAI\Codex\bin`. A Codex that came another way (for example `npm install -g`) is left alone, and the card says to update it the way it was installed.
- **It checks the new Codex, and puts the old one back if it does not fit.** Codex's own help (`codex --help`, `codex exec --help`, `codex login --help`) must still show every part of the command line the app uses (`CodexCompatibility`) that the Codex that worked showed, and the new Codex must still be signed in. If not, the version that worked is installed again (the installer keeps each release, so this is quick), the newer one is not tried again until a still newer one comes out, and the card says why in words. If even putting the old one back fails, the card says so, and *Get started* can install Codex again.
- **It removes the old releases.** The installer never removes an old release, so after an update the folders of the older ones are removed, keeping the newest three and the version replaced. Only folders named like a release (`0.158.0-x86_64-pc-windows-msvc`) are touched.
- **The owner decides.** The switch *Update Codex by itself* is on unless turned off; off, the bell tells the owner when a newer Codex is out, and *Update now* still works. What it remembers (the choice, what it saw and did) is in `codex-update.json` beside `settings.json`.

Checked by tests: `dotnet test` (`CodexUpdateTests`: the versions, the release channel, the gate, the flags the app uses (which fail when `CodexCliProvider` uses one the list does not name), the updater with stand-ins for every case above, the installer's version argument, old releases) and `npm run test:codexupdate` in the dashboard (the card, the switch, the bell, and what the worker finds by itself, with a stand-in Codex and a stand-in release channel). **Not checked before release:** an update to a real newer Codex on a real PC (the installer, the new Codex's own help, the roll back). Watch the first one.

## Privacy and safety

- **Read-only, three times over.** `SqlGuard` refuses anything but one `SELECT`/`WITH` over approved tables. That rules out `INSERT`, `UPDATE`, `DELETE`, `EXEC`, `INTO`, system views, variables, temporary tables, other databases and comment tricks. Every query also runs in a transaction that is rolled back, never committed. The recommended SQL login is read-only as well.
- **Finding the database only reads.** It lists folders, reads the POS's settings files and the registry, and asks each SQL Server for its database names, bill count, last bill date and shop name. Passwords are never shown or logged.
- **Never shared with any AI:**
  - Tables holding passwords, API keys, licence data, sync state or logs (`Registration`, `EmailSetting`, `WappApi`, `SMSSetting`, `Activation`, …).
  - Bank-account and PAN columns.
- **Masked by default:** phone numbers, e-mail, addresses, GSTIN/PAN in query results. They still show on screen, just not to the AI. You can turn this off in *Settings → Privacy*.
- **What an AI provider receives:**
  - The question.
  - The names of the business tables and columns.
  - At most *Rows shared per answer* result rows (default 50), masked as above.
  - For product photos (Codex only): the phone photos, the white-background photo and the AI's own description of the product, and the product's name, code and category.
  - For posters: the kind of poster and, for each product that fits, its name, category, price, the biggest offer allowed, stock and recent sales. For a poster's artwork (Codex only): its theme, nothing else.
- **CLI tools are boxed in.** Each request runs in a new, empty temporary folder that is deleted afterwards. Codex runs in its read-only sandbox, Claude has every tool switched off, and Antigravity runs sandboxed. To make a product photo or a poster's artwork, Codex may write, but only in its own temporary folder, which holds nothing but copies of the photos (or nothing at all, for artwork).
- **Keys and passwords are encrypted** with Windows DPAPI for the current Windows user, in `%APPDATA%\NextGen OS\Smart Retail POS AI\settings.json`. A copy of that file is useless on another PC or account.
- **The log** (`%LOCALAPPDATA%\NextGen OS\Smart Retail POS AI\logs\assistant.log`) records errors only, never questions, answers or data.

## Troubleshooting

| Symptom | Fix |
|---|---|
| Codex: *not signed in* | Open the dashboard's **Get started** page and click **Sign in with ChatGPT**, or paste an API key there. |
| *Get started* cannot install Codex | It needs the internet for a minute or two, to reach chatgpt.com and releases.openai.com. Try again, or run `irm https://chatgpt.com/codex/install.ps1 \| iex` in PowerShell. |
| Codex fails with a Windows sandbox error | *Settings → CLI tools → Codex → Sandbox* = `workspace-write`. It still runs only in an empty temporary folder. |
| A CLI tool is *not installed* although it is | Set its full path in *Settings → CLI tools* (npm tools live in `%APPDATA%\npm`, Claude/agy in `%USERPROFILE%\.local\bin`). |
| Claude: *Authentication error* | Check the Anthropic API key and that the Console account has credit. |
| Product photos: *Codex answered but made no image* | Codex must be signed in with a ChatGPT plan that includes images, or with an OpenAI API key; check with `codex login status`. Update an old Codex with `npm install -g @openai/codex@latest`. |
| *Could not find the POS database by itself* | The panel lists what it checked. Make sure the SQL Server service is running, then in *Settings → Database* choose the POS folder (or type the server, e.g. `SHOP-PC\SQLEXPRESS`) and click *Find automatically*. |
| *Cannot reach the POS database* | Use *Test connection*, and make sure the SQL Server service is running. If the POS's password changed, click *Find automatically* again. |
| Slow answers | Each question needs two AI calls; CLI tools add a few seconds of start-up. Try lower reasoning effort, or an API provider. |
| The shortcut does nothing | Another program already uses it (the app says so by the tray icon). Choose a different one in *Settings → Side panel*. |
| The app shows the old side panel and opens the dashboard in the browser | The Microsoft Edge WebView2 Runtime is missing. Run the setup again with the internet on, or install it from [Microsoft](https://go.microsoft.com/fwlink/p/?LinkId=2124703), then start the app again. |
| The window says the dashboard did not start | Another program may be using its address, 127.0.0.1:5080. Click **Try again**; if it keeps happening, change the address in *Settings → Side panel → Sales dashboard* and in the Dashboard folder's `appsettings.json`. |
| The dashboard says *Demo data* after the PC started | The POS database was not answering yet when the dashboard started. The app looks again by itself and restarts the dashboard when the database answers (within seconds to two minutes of SQL Server coming up). If it stays, check that the SQL Server service is running, then *Settings → Database → **Test connection*** and choose *Find automatically*; closing and opening Smart Retail POS from the tray menu also looks again. |
| The panel covers part of the POS | Hide it with Esc or the shortcut, move it to the other edge, make it narrower, or turn the side panel off for a normal window. |

## Building

The panel needs the **.NET 8 SDK** (Windows, Linux or macOS; the .NET Framework 4.8 app builds on any of them). The package also carries the sales dashboard, a .NET 10 app, so `build.ps1` needs the **.NET 10 SDK** unless you pass `-SkipDashboard`.

```powershell
./build.ps1                     # runs both apps' tests, writes dist\SmartRetailAI.zip with the dashboard in Dashboard\
./build.ps1 -Installer          # the same, plus dist\SmartRetailAI-Setup.exe (needs NSIS 3: nsis.sourceforge.io, or apt-get install nsis)
./build.ps1 -SkipDashboard      # the panel only (.NET 8 SDK is enough)
./build.ps1 -Installer -UpdateFeed <the public folder> -ReleaseRepositoryId <id> -ReleaseOwnerId <id>   # an app that looks for updates there (the workflow does this)
dotnet test SmartRetailAI.sln   # tests only
```

On GitHub, the **Installer** workflow (`.github/workflows/installer.yml`) runs both apps' tests on Windows, then checks the app's windows there for real: `SmartRetailAI.exe --smoke-test report.json` opens the app window and the side panel on the demo shop, checks that Today, the panel and Ask AI load and that the pages can talk to the app, and exits with a report. It also checks the window's own top bar: it replaces the Windows title bar, dragging it moves the window (with the mouse, for real), and a double-click or its button maximises and restores it. Pictures of the window are kept with the run as `smoke-shots`. Then it builds the package and the setup on Linux (the Windows NSIS has no 64-bit setup stub). It runs for every pull request. Pushing a tag such as `v1.0.1` publishes the setup as a Release; running it by hand from the Actions tab with a version, e.g. `1.0.1`, does the same.

Layout:

```
src/SmartRetail.AI.Core/       providers, CLI runner, SqlGuard, schema, assistant, finding the POS database,
                               opening the dashboard, product photos with Codex (Products/), the data folder (Storage/)
                               (net48 + net8.0; the dashboard uses the net8.0 build)
src/SmartRetail.AI.Desktop/    the Windows app (net48) -> SmartRetailAI.exe: the app window and the side panel (WebView2, AppHost),
                               AI tab, tray and shortcut, settings; the earlier WinForms panel when WebView2 is missing
tests/SmartRetail.AI.Tests/    xUnit tests (net8.0)
sql/create_readonly_login.sql  read-only SQL login for the assistant
installer/SmartRetailAI.nsi    the Windows setup (NSIS): for everyone or one user, any folder, WebView2 when missing,
                               shortcuts, Start with Windows, uninstaller, and a quiet update mode (/S /UPDATE)
installer/test-update.sh       checks that quiet update mode under Wine
publish-update.sh              puts a release in the update folder (run by the release workflow)
tests/publish/                 checks that script's upload against a stand-in for Supabase
```

**Trying the Windows app on Linux.** Wine has no WebView2, so under [Wine](https://www.winehq.org) the app runs its earlier WinForms side panel; the new windows are checked on Windows by the workflow's smoke test, and their pages in any browser (the dashboard's browser tests). Wine with wine-mono is enough to check that panel's layouts and most behaviour; wine-mono uses Mono's WinForms, so fonts and a few details (focus, minimum window sizes) differ from Windows.

```bash
apt-get install wine64 xvfb openbox xdotool imagemagick
# Wine 9.0 needs wine-mono 8.1.0 in ~/.cache/wine (github.com/madewokherd/wine-mono/releases)
Xvfb :99 -screen 0 1366x768x24 & export DISPLAY=:99; openbox &
wine start /max notepad.exe                     # a stand-in for the POS
wine src/SmartRetail.AI.Desktop/bin/Release/net48/SmartRetailAI.exe
import -window root screen.png                  # screenshot
```

Always check the side panel's keyboard focus on a real Windows PC as well (step 5 of *Installing at a shop*).

To add a provider: implement `IAiProvider` (or derive from `CliProviderBase` / `HttpApiProviderBase`), add its id to `ProviderIds.DefaultOrder`, and register it in `ProviderCatalog.CreateAll`.

## Handover checklist

- [ ] Build from a clean checkout with `build.ps1 -Installer`, and ship `dist\SmartRetailAI-Setup.exe` (or `dist\SmartRetailAI.zip`) only, with no `settings.json`, logs or keys.
- [ ] The client creates their own AI accounts and keys, and signs in on their own PC.
- [ ] The client's administrator runs `sql\create_readonly_login.sql` with their own strong password.
- [ ] On the shop PC: on first start the panel says it found the POS database, with the right shop name and a recent last bill. Then switch it to the read-only login (*Find automatically* uses it once its password is saved).
- [ ] On the shop PC: *Get started* shows the AI as signed in, *Test connection* (Settings → Advanced settings → Database) succeeds, and in Ask AI a built-in report and a typed question both work.
- [ ] Beside the POS: the shortcut opens the panel over the POS, Esc returns to the POS and typing lands there, and the AI tab appears by itself after a restart (*Start with Windows* is on unless it was unticked in the setup).
- [ ] The app window opens on Today with the shop's name and **Live · read-only** in the sidebar, and *Grow sales* shows the AI tool as ready.
- [ ] The app window's top bar: drag it, double-click it, snap the window to a side and resize it from the top edge; the bell lists what needs the owner.
- [ ] *Storage*: choose a data folder on a drive with plenty of free space (e.g. `D:\Smart Retail POS AI`), and add it to the shop's backups.
- [ ] *Product photos*: with Codex signed in on the shop PC, add a phone photo of a best seller and check the five photos and the description as they arrive. This has not been run with a real Codex sign-in before handover.
- [ ] *Posters*: make a clearance poster, check its prices against the POS, and print it on the shop's A4 printer. Choose the biggest offer the owner allows in *Settings → Posters*.
- [ ] *Automatic updates* (once the update folder is set up): with an older version installed on the shop PC and a newer release published, the bell offers it within hours (or *Settings → Updates → Check now*), *Install now* asks Windows for permission, the app closes and opens again by itself on the new version, and the settings, photos and plans are still there. This has not been run on a real PC before handover.
- [ ] *Codex updates*: in *Settings → Updates* the Codex card says which version this PC has and when it looked. When a newer Codex is out, *Update now* replaces it (an AI task asked meanwhile waits and then answers), and afterwards a chat answer and *Settings → The AI* still show Codex ready and signed in. This has not been run with a real newer Codex before handover.
- [ ] Walk the client through *Privacy and safety* above, so they know what is sent to the AI provider they choose.

## Scope

The assistant and its dashboard are separate programs that sit beside the POS. They do not modify the POS executable, its database or its installer, and they never touch the POS's printers or scanners. Putting AI inside the POS's own screens, or renaming the POS program itself, would need the POS source code or a new build from the POS vendor; the side panel gives the cashier the assistant without either.

## Licence

Smart Retail POS is free, open source software under the [MIT License](../LICENSE): anyone may use, copy, change and share it, in a shop or a business, as long as the licence text stays with it. It comes without any warranty. The licences of the software it is built from are in [`THIRD-PARTY-NOTICES.md`](../THIRD-PARTY-NOTICES.md); the MIT License covers this project's own code, and a few libraries in the binary downloads (Microsoft's SQL Server network library, for one) have their own terms. The setup and the zip carry `LICENSE.txt`, `THIRD-PARTY-NOTICES.md` and `licenses\` (the Apache 2.0 text, and the vendors' own notices in `licenses\third-party\`) in the app's folder (`build.ps1` refuses to package without them, and a test checks that every library a project names has its notice). To help, see [`CONTRIBUTING.md`](../CONTRIBUTING.md); to report a security problem, see [`SECURITY.md`](../SECURITY.md).
