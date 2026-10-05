# The SQL scripts

Smart Retail POS by NextGen OS. Every script the owner has to run is also a **separate file on each GitHub release** (the release page lists them with a line each), so nothing has to be taken out of a zip or looked for in the repository. All three are safe to run again, and none changes the POS's own data.

| Script | Where to run it | What it is for | When |
|---|---|---|---|
| `supabase-owner-view.sql` | Your Supabase project: SQL Editor, New query, paste, Run | The owner's live view: Today, the weekly screens such as Last week, the products waiting for the owner's approval on the website, and which of the shop's PCs is the main one. One file covers everything, so an older one is never needed. | Once. Again after an update whose notes say so (version 2.17.0 added the weekly review; 2.18.0 added the products for the website and the main PC). |
| `supabase-app-updates.sql` | Your Supabase project: SQL Editor | The folder for automatic updates (`SmartRetailAI/README.md`, *Automatic updates*). | Once, only for automatic updates. Make the uploader user first and put its e-mail on the line marked `CHANGE THIS`. |
| `create_readonly_login.sql` (in `SmartRetailAI/sql/`) | SQL Server Management Studio on the shop PC, not Supabase | A login that can only read the POS database, for the assistant. | Once, strongly recommended. Put a long password and your company database names in it first. Again if the login was made with version 1.6 or earlier, so that bills show their times. |

`test/` holds the checks of the two Supabase scripts (`run.sh` with Docker); they are not run by the owner.

When a new script is added for the owner, it goes into three places together: `.github/workflows/installer.yml` (the release's files and its text), this table, and `AGENTS.md`.
