# The owner's live view

*Smart Retail POS by NextGenOS*

On the Demo Mart website this view is **Live shop** in the admin panel (`/admin/live`), with an optional
authenticator app for signing in; its setup is in that website's README. This folder is the same view as a plain web
page, for a shop without such a website. It does not ask for an authenticator app's code: an owner who turned one on
in Live shop uses Live shop.

See the shop from anywhere, on a phone or a computer:

- today's sales against the same day last week by this time;
- every bill today, with the time it was made;
- today hour by hour;
- the last 7 days, and the last 60 days, each with its hours and best sellers;
- today's best sellers, what is running low, and the Fix now list;
- on the *Last week* tab, the Monday review: last week's sales, bills, average bill and profit against the week before and the same week a year before, the regular sellers running out and the stock that has not sold for 8 weeks, and whether the week was marked as reviewed at the shop. The shop PC sends it once an hour, when the week turns and when the week is marked as reviewed. If the tab says the weekly review needs a newer script, run the updated [`supabase-owner-view.sql`](../cloud/supabase-owner-view.sql) once more in the SQL Editor; running it again is safe.

The shop PC sends the figures to your own Supabase project every minute, and within 20 seconds of a new bill. This page shows them the moment they arrive.

**Only figures leave the shop.** Never a customer's name or phone number, nor what was on a bill. The live POS database is never touched: the shop PC reads it, as it always does.

## Set it up once

It takes about 15 minutes.

1. **Make a Supabase project** at [supabase.com](https://supabase.com). The free plan is enough, and the shop PC's sending keeps it awake. Choose the region nearest the shop, e.g. *Mumbai*.
2. **Load the owner view into it.** In the project, open *SQL Editor*, then *New query*. Paste all of [`../cloud/supabase-owner-view.sql`](../cloud/supabase-owner-view.sql) (each release also has it as a separate file, `supabase-owner-view.sql`) and press *Run*. Running it again later is safe.
3. **Copy two things** from the project's settings (*Project Settings*, then *Data API* and *API Keys*):
   - the **Project URL**, like `https://abcd.supabase.co`;
   - the **publishable** key (or, in older projects, the **anon public** key).

   Never copy the secret or `service_role` key anywhere: the shop PC and this page refuse it.
4. **Put this page online** with those two things in `config.js`. Each release has this folder and the script as `SmartRetail-OwnerView.zip`.
   Put it:
   - **on your website:** copy this folder into the website's `public/owner/` folder. It then opens at `https://your-website/owner/index.html`. It needs no change to the website's code, packages or settings. If the website sends a Content-Security-Policy, it must allow connections to your project's `https://…supabase.co` and `wss://…supabase.co` addresses.
   - **on its own:** on any static host, such as Vercel, Netlify or Cloudflare Pages.

   Then in Supabase, go to *Authentication*, then *URL Configuration*, and set the *Site URL* to the page's address. The sign-up and new-password e-mails then link back to it.
5. **Create your account** on the page with *Create an account*. Confirm the e-mail, sign in, and name the shop. Only the first account can create the shop.

   To keep strangers out, go to *Authentication*, then *Sign In / Providers*, and turn off *Allow new users to sign up*. Strangers could not see anything anyway.
6. **Connect the shop PC.**
   1. On this page, under *Shop PCs*, press *Connect a shop PC*. It shows a code like `ABCD-EFGH`.
   2. On the shop PC, open Smart Retail POS, then *Settings*, then *Owner's live view*.
   3. Paste the Project URL and the public key, type the code, and press *Connect*.

   The page says when it is connected, and the figures show within a minute.

   **A shop with several PCs.** Connect each PC the same way, with a code of its own. The first PC connected is the shop's **main PC**: only it sends the figures, the Monday review and the products, and answers your questions, because each PC keeps its own photos and decisions. The list under *Shop PCs* marks the main PC, and the others as counters; a counter PC says so in its Settings and has a *Make this the main PC* button. All of them use the same POS database, so the shop's bills and stock are the same everywhere.

## Safe by design

- **The shop PC holds only the public key and its own key.** Its key is made when it connects. Supabase keeps only a hash of it, and Windows protects it on the PC (DPAPI). With these two keys the PC can send figures, and nothing else: it cannot read anything back.
- **The page holds only the public key.** A person sees the shop only as its member. Supabase's row-level security checks every read.
- **A connection code works once, for 15 minutes.**
- **Disconnecting stops a PC at once.** Disconnect it on this page, or on the PC itself, and its key stops working.
- **The page loads only its own files.** Its Content-Security-Policy allows nothing else. Supabase's JavaScript library is kept in `vendor/` (version 2.117.2, MIT licence), so no other site is involved.

## Testing it

- **The database script:** `../cloud/test/run.sh` runs it twice on Supabase's own database image, then tries every rule: the owner, a stranger, the shop PC's key, expired codes, too much data. Needs Docker.
- **The shop PC's side:** `npm run test:owner` in `../tests/e2e`. It uses Supabase's database with PostgREST, in Docker.
- **The Last week tab and the list of PCs:** `npm run test:owner-review` in `../tests/e2e`. It needs no Docker or Supabase: the shop PC talks to a stand-in for the project, and this page is served with a stand-in for supabase-js.
- **This page:** `npm run test:owner-app` in `../tests/e2e`. It needs a local Supabase with sign-in and live updates; the top of `owner-app.e2e.js` says how to start one.
