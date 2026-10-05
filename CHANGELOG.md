# Change log

What changed in each update of Smart Retail POS, newest first. The same list is in the app, under **What's new**.

Every update adds its entry here before it is released, so this list is the whole story: what is new, what works better, and what was fixed. (Version numbers that were never released on their own, such as 1.6.0, are listed inside the update that carried them.)

## 2.18.0 · 4 October 2026

This PC can now offer your finished products to your website for your approval, each with a category of your website, and a shop with several PCs has one main PC that speaks for it.

### New
- **Offer finished products to your website.** Turn on *Settings → Owner's live view → Offer finished products to your website*, and every product whose photos and listing are finished is offered to your website with its listing, its five photos and its price from the POS. Nothing is published by this PC: the product waits in your Supabase project, at most 25 at a time, until you approve it on your website's Live shop (that page comes with the website's own update). The price is always the POS's, never the AI's, and a new POS price or listing comes back for your approval again. Photos stay in your project only until you decide.
- **A category of your website for every product.** A product on your website needs a category, which its name cannot give. After the photos and the listing are made, the AI files each product under one of your website's own categories (it can only choose from your website's list, never make one up), and you can change it on the product's page, under Listings, Your website, or let the AI choose again. A product with no category is not offered. Your website sends its list of categories when you open *From the shop*.
- **One main PC for a shop with several PCs.** All your counters use the same POS database, but each PC keeps its own photos, listings and decisions, so only one PC speaks for the shop to your Supabase project: the first one you connect is the main PC. The others say *This PC is a counter PC*, name the main PC, and send nothing. *Make this the main PC* on a counter takes the role, and if the main PC is disconnected on the website the next PC to ask takes it.
- **A new job in Settings, Website category,** so you can choose its model and thinking level like the other AI jobs.

### Improved
- **The owner's page marks the main PC** under *Shop PCs* when the shop has more than one.
- **Run `supabase-owner-view.sql` once more** in your Supabase project's SQL Editor (it is on the release page, and safe to run again): it adds the waiting list for products and the main PC. Until you do, the live figures go on as before, and Settings says what is missing.

## 2.17.1 · 4 October 2026

The SQL scripts you may need to run are now separate downloads on every release page, which says what each is for and when to run it.

### Improved
- **The SQL scripts are separate files on the release page**, not only inside a zip: `supabase-owner-view.sql` (the owner's live view, with Last week) and `supabase-app-updates.sql` (automatic updates) for your Supabase project's SQL Editor, and `create_readonly_login.sql` for SQL Server on the shop PC. The release text says where to run each and when. The app itself is the same as 2.17.0.

## 2.17.0 · 3 October 2026

The shop PC now sends last week's Monday review to your Supabase project, and the owner's page shows it under Last week.

### New
- **Last week, on the owner's page.** From anywhere, see last week's sales, bills, average bill and profit against the week before and the same week a year before, the regular sellers that are running out and the stock that has not sold for 8 weeks, and whether you marked the week as reviewed at the shop. The shop PC sends it once an hour, when the week turns and when you mark the week as reviewed. Only figures and product names leave the shop: never customers, and never your decisions or their notes. To see it, run the updated `supabase-owner-view.sql` once more in your Supabase project's SQL Editor (running it again is safe); until then the live figures go on as before. The website's Live shop shows it once that page is updated.

### Improved
- **Settings → Owner's live view says when the Monday review was sent**, or what is missing, for example that the Supabase script needs to be run again.

## 2.16.0 · 3 October 2026

A shorter creative form, a red star on what must be filled in, and a better model for finding products by their look, which you choose when you want it.

### New
- **A better camera search model.** Settings → Camera search says which model finds products by their look, and offers DINOv2-base: it sees more detail, so it tells look-alike packs apart better (347 MB; the first one is 88 MB). Nothing changes until you press *Use this model*. It downloads once while the first one keeps working, your products' photos are learned again with it in the background, and the old model is deleted once the new one works. Meanwhile a photo finds by look the products learned so far, and barcodes always work. Going back to the smaller model is the same button. When a still better model comes in a later update, Settings offers it the same way and *What's new* says so.

### Improved
- **The creative form is short, in three steps.** Nothing in it is compulsory: say what the picture is for, what it should show and what it should say, and the AI fills in what you leave empty. The style, the call to action and the other extras are under *More choices*, closed until you need them.
- **A red star marks what must be filled in.** On every form where something cannot be left empty, that field has a star, and a line on the form says what the star means; screen readers say "required". This covers adding an action and a new product's test, the data folder, the live view's connection details, a playbook's name and steps, the words for changing a photo or a picture, the reason for choosing something else on the Monday review, an OpenAI key, and a model typed by name. A field without a star can be left empty.

## 2.15.0 · 3 October 2026

Fix now says when each problem happened, each product has one name for your website and Amazon, and the model list shows new Codex models sooner and lets you type a model's name.

### New
- **Type a model's name.** In a job's AI panel, *Another model…* takes a model by its name, like gpt-6.1-sol, for the days when a new model works for your account but Codex's list does not show it yet. A name that cannot be used is refused before it is saved.
- **Refresh the list.** The panel says which Codex listed how many models and when, and *Refresh the list* asks Codex again at once. The list is Codex's own answer for your account: a new model shows only when OpenAI has turned it on for you, which takes some days.

### Improved
- **Fix now says when each problem happened.** Every problem has a line with the date and time: a bill's date and the time it was saved, the two bills a missing bill number was made between, or the oldest unpaid bill. Prices and stock have no date in the POS, so for those it says when this app first noticed the problem (or that it was already there when it first checked).
- **New Codex models show sooner.** The list is asked again after five minutes (it was thirty), and at once after Codex is updated or signed in. Refreshing also clears the copy of the list that an older Codex saved on this PC, which could hide the newest models.
- **The panel says when a newer Codex is out**, since a new model sometimes needs it, and links to Settings → Updates.
- **With Claude Code or Antigravity chosen**, the panel names the model they use and where to type a newer one.
- **One name for your website and Amazon.** The AI writes one display name for each product, used on both, up to 120 letters. The name in your POS stays as it is and is shown beside it, and *Copy the name* copies the one for the shops. Products that already have listings are brought to one name when they are opened.

## 2.14.0 · 3 October 2026

When Codex's usage limit is reached, photos, listings, posters' artwork and creatives wait and carry on by themselves from where they stopped.

### Fixed
- **Work no longer stops for good when Codex's usage limit is reached.** Before, the photos or the picture that met the limit stopped and waited for you to press Continue (or Make it again) after the limit had been reset. Now nothing is marked as failed: the page says *Paused: Codex's usage limit was reached* and when it carries on by itself (the time Codex gives). When that time comes the work goes on from the photo it stopped at, and the photos already made are not made again. Everything that uses Codex waits together, and *Try now* tries at once, for example after you get more usage.
- **A creative's picture waiting for the limit is still waited for after you close and open the app**, and photos that an earlier version stopped on the limit carry on by themselves when the app starts.

### Improved
- The Product photos list and the sidebar show when the photos are paused and until when, and the Storage page says why a move has to wait.

## 2.13.0 · 3 October 2026

A change log in the app, Google Lens search with a product's own photo, pages for long lists, a camera in every search box, product photos you can change with a note and that keep the shape of your photo, and a shop name that may have a number in it.

### New
- **A change log.** What's new, in the sidebar, lists what changed in every update: new things, things that work better, and fixes. It shows a dot when you have updated and have not looked yet, and Settings → Updates links to it.
- **Google Lens, one click per product.** A product's page, the Product photos list, the Products list and each product in Price check have a Google Lens button. It searches with the product's own photo, which finds the same product more exactly than its name and uses none of the AI's limit. The photo goes from your browser straight to Google, made smaller and without the place and camera details a phone puts in a photo; nothing about your prices, sales or customers is sent.
- **Pages for long lists.** Product photos and Products show 10, 25, 50 or 100 products to a page, with Previous, Next and the page numbers. The page is kept in the address, so Back from a product comes to the same page.
- **Find a product with the camera from any page.** The search box in the top bar (and in the sidebar of a browser) has a camera button. What it finds shows as a card over the page; Show opens Products on that product.
- **Change one photo with a note.** Under each product photo that is made, *Change it* lets you say in a few words what to change (a clearer label, a warmer light). The AI makes that photo again from the one it replaces and keeps the rest the same; the new photo shows what you asked for, and the photo before is kept. Text, prices and offers are still never added.
- **See what is being made, and what is next.** The product's page, the Product photos list and the sidebar say which photo of which product is being made now, what comes next, and which products are waiting, with the number of photos left. They update by themselves.

### Improved
- **Photos keep the shape of your photo.** A tall phone photo gives tall photos and a wide one wide photos, trimmed from the middle to exactly your shape (never stretched), so each fills the same place on your website or on Amazon. Under each photo the page says its size and whether it has your photo's shape.
- **A calmer search box.** Clicking into it draws one thin blue line instead of a thick glow.
- **The shop's name may have a number in it**, like Smart Avenue 99, on the Creatives page. Only a price sign in the name (₹, % or a money word) is still refused, because only the app draws prices. The message says where to change the name.
- **Mistyped addresses are safe.** A page or size in the address that is not a number shows the first page instead of stopping the screen.

## 2.12.0 · 3 October 2026

Starts by itself with Windows, waits for SQL Server, open source under the MIT licence, and the Windows install warning explained.

### New
- **Starts with Windows.** The setup ticks *Start with Windows* for a new install and an update keeps your choice. Settings has a switch, and says so when Windows' own list of start-up apps has switched it off.
- **Waits for the POS database.** When Windows starts the app and SQL Server is still starting, the app waits up to 3 minutes for the database before it opens, instead of showing the demo shop all day. If the database comes later, the dashboard starts again by itself, once.
- **Free, open source software under the MIT licence**, with a notice for every library inside it, a security policy and a guide for people who want to help. Settings → About says so.
- **The "Windows protected your PC" box is explained** in the README and in every release's text: why it comes, how to go past it, and the ways to remove it for good.

## 2.11.0 · 30 September 2026

### New
- **Codex is kept up to date by itself, safely.** The app checks OpenAI's releases, lets a new one settle for a day, installs it only when nothing is running, and puts the old one back if the new one does not work. Settings → Updates has the card and a switch; *Update now* skips the wait.

## 2.10.0 · 29 September 2026

### New
- **Automatic updates.** The app looks in your own update folder, checks that GitHub signed the new version as made by this project's release, downloads it, and installs it when you say so. Settings → Updates shows what it found, and the bell tells you when one is ready.

## 2.9.0 · 29 September 2026

### New
- **Price check.** For a product you follow, Codex looks for the same product on listed online shops; you confirm which pages are the same product, and the app compares them with your price and the lowest safe price (purchase price plus GST). It only informs: it never changes the POS price.

## 2.8.0 · 29 September 2026

Includes 2.7.0.

### New
- **Playbooks.** After an action with a lesson, the AI writes or improves one playbook for that kind of action; it is used in later plans and chats only after you Save it.
- **New products as tests.** A product you add can be tracked as a test: why you bought it, how many, and how many you hope to sell by its review day. It is judged on its own sales on that day, and you decide what to do next.
- **Remove a photo added by mistake.** A phone photo, or a whole set, can be deleted from the product's page, even while the AI is making the photos.

### Improved
- The app is tidier inside: unused code and files were removed, and the screenshots in the guide are current.

## 2.6.1 · 28 September 2026

Includes 2.6.0.

### New
- **The Monday review.** Stock-out and dead-stock alerts, with your decision on each (accept, do something else, not now) checked against the POS two to four weeks later, so you can see whether following the rules paid off.

### Improved
- **Short AI errors.** A usage limit now says in one sentence when the AI can answer again.
- **Chats are kept after every answer**, not only when they end.
- **The top bar stays at the top** on long pages.

## 2.5.0 · 28 September 2026

### New
- **Creatives.** Codex designs a whole advertisement (a post, a story, a banner) from your brief, with your products' photos and brand. The app draws every price tag itself, from the POS, so no price ever comes from an AI. Change a picture with a short note, and export it at the right size.

### Improved
- Nothing of the shop is left in Codex's working folder after a picture is made.

## 2.4.0 · 28 September 2026

### New
- **The camera finds products.** On the Products page, the Barcodes page and the side panel, a photo of a barcode finds the product at once, on this PC. Turned on in Settings, it also finds products by their look. You always pick the product.
- **Take product photos with the camera** on a product's page.

## 2.3.0 · 28 September 2026

### New
- **A new Ask AI.** Answers are laid out like documents and appear as they are written. You can add photos, take one with the camera, or send a voice note, where the chosen model can use them.
- **Product listings.** Titles, bullet points, descriptions and details for Amazon and for your website, written once from the product's photos and checked so no price or promise comes from the AI.

## 2.2.0 · 27 September 2026

### New
- **Ask the shop's AI from the website's Live shop.** The question goes to your shop PC, which answers with its own checks (read-only queries, contact details hidden) and sends back words and at most 100 rows.

## 2.1.0 · 27 September 2026

### New
- **The website's Live shop**, with its own sign-in through your Supabase account.
- **An optional authenticator app** for the owner's sign-in, held by the database itself.
- Settings shows the three steps to connect your shop.

### Improved
- A PC that did not find the POS database never sends the demo shop's figures.

## 2.0.0 · 27 September 2026

### New
- **The owner's live view.** Today's figures, bills with their times, the hours, the week, the last 60 days, best sellers, low stock and the Fix now list, on a web page you can open from anywhere, through your own Supabase project. Only figures leave the shop PC.

## 1.7.0 · 27 September 2026

Includes 1.6.0.

### New
- **The real time of every bill**, read from the POS's own log, with a live Today page that follows today's bills and compares them with last week by this time.
- **The app window's own top bar**, in place of the empty Windows title bar, with search, the bell and the window buttons.

## 1.5.0 · 26 September 2026

### New
- **Each AI job has its own model and thinking level**, and Codex's usage shows in the app.

## 1.4.1 · 26 September 2026

### New
- **Past chats**, found by their words and asked again.

## 1.4.0 · 26 September 2026

### New
- **The assistant's memory.** What it should always know about the shop and about you, which you can read, change and undo. "Remember that…" and "Forget…" work in the chat.
- **Actions and their results.** Track something you did (a discount, a new supplier) and see what it did to sales.

## 1.3.3 · 26 September 2026

### New
- **Fix now.** Pricing mistakes and other problems in the POS (selling below cost, a deleted bill, a big discount) with what to do about each.

## 1.3.2 · 26 September 2026

### New
- **Barcode stickers and a counter book**, with the code the POS bills by.
- **A barcode finder beside the POS** in the side panel, and the Products page shows the code the till scans.

## 1.3.1 · 26 September 2026

### Fixed
- Codex shows as ready when it is.

### New
- **Every bill from the first**, live, with a page for each bill and a CSV download.

## 1.3.0 · 26 September 2026

### New
- **A4 sale posters.** The AI picks the products and writes the words, Codex makes artwork without text, and the app prints the names and prices exactly as the POS has them. Offers are whole rupees, never below the purchase price plus GST.

## 1.2.0 · 26 September 2026

### New
- **A real app window**, with the dashboard in it and the side panel beside the POS.
- **A new look**, light or dark, with fonts that come with the app.
- **Ask AI inside the app**, and in the side panel.

## 1.1.0 · 25 September 2026

### New
- **Choose where to install.**
- **Codex is installed and signed in from the app**, on the Get started page.

## 1.0.0 · 25 September 2026

### New
- **Smart Retail POS AI.** Ask the shop's AI questions in plain words; it reads the POS database read-only, and every query is checked and rolled back.
- **A side panel** beside the POS, which finds the POS database by itself.
- **A sales dashboard** (Today, sales, low stock, products, bills) and an AI plan to grow sales that uses only figures and product names.
- **Product photos.** Add phone photos and the AI makes five photos (white background, in use, and three with models) and learns what the product is.
- **Choose where photos and plans are kept**, and a setup program.
