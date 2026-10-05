# Security policy

## Reporting a problem

Please report a security problem privately, not in a public issue:

- On GitHub, open this repository's **Security** tab and choose **Report a vulnerability**.
- Say what you found, how to repeat it, and the version (Settings → About in the app shows it).
- Do not include real shop data, keys or passwords. A made-up example, or the demo shop (`Pos__Mode=Demo`), is enough.

Every report is read and answered as soon as possible. A fix goes out as a new release, which the app's automatic updates offer to the shop.

## Which versions

Only the newest release gets fixes. Update first (the app offers it in the bell and in Settings → Updates), then check whether the problem is still there.

## What matters most

These are the places where a mistake would hurt a shop, so reports about them are especially welcome:

- **The POS database stays read-only.** `SqlGuard` checks every query the AI writes, and every query runs in a transaction that is rolled back.
- **What leaves the PC.** The AI gets figures and product names only, never a customer's name, phone number or bill; contact details in query results are masked.
- **Keys and passwords** are encrypted with Windows DPAPI for the Windows user, and are never logged.
- **The dashboard listens on 127.0.0.1 only,** and only the dashboard's own pages may talk to the Windows app.
- **Automatic updates.** The app installs only a setup that GitHub signed as made by this repository's release workflow, with exactly the size and SHA-256 that was signed.
- **The owner's live view.** Row-level security on every table of the Supabase script, and figures only.
- **Photos, voice notes and files** the owner sends to the AI: they are checked by their first bytes and size, kept only while the chat lasts, and served only by names the app made.

## Out of scope

- The POS software itself, Windows, SQL Server, Microsoft Edge WebView2, Supabase, and the AI tools the app runs (Codex, Claude Code, Antigravity): report those to their makers.
- A problem that needs the attacker to already control the shop PC's Windows account.
- The message *Windows protected your PC* when installing: the setup is not code-signed yet. See `SmartRetailAI/README.md`, *The Windows warning when installing*.
