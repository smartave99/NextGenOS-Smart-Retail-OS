This is a [Next.js](https://nextjs.org) project bootstrapped with [`create-next-app`](https://nextjs.org/docs/app/api-reference/cli/create-next-app).

## AI provider routing

Text workloads use two providers:

- Groq handles basic assistance such as customer chat, short summaries, deal copy, and alerts.
- Lightning AI handles advanced intent analysis, product ranking, review analysis, styling, gift recommendations, comparisons, and semantic filters.
- Lightning AI image search uses Gemma 4 31B first, then Nemotron 3 Nano Omni 30B as its model fallback.

Copy `.env.example` to `.env.local` and add at least one `GROQ_API_KEY` and one `LIGHTNING_API_KEY`. Lightning uses the OpenAI-compatible `https://lightning.ai/api/v1/` base and `lightning-ai/deepseek-v4-pro` by default. Backup keys can be added with `_1` through `_10`. A Groq key rotates on HTTP 429; a Lightning key rotates on HTTP 402 or 429. If every key for the preferred provider is unavailable, the request falls back to the other text provider, then Gemini when configured.

Vision model routing is controlled by `LIGHTNING_VISION_MODEL` (default `lightning-ai/gemma-4-31B-it`) and `LIGHTNING_VISION_FALLBACK_MODEL` (default `lightning-ai/nvidia-nemotron-3-nano-omni-30b-a3b`). These use the same Lightning API keys as the text models.

Keys can also be stored from **Admin → API Keys**. Keep **AI Settings → Provider Priority** set to **Workload routing** to use the Groq/Lightning split.

After configuring environment keys, run `npm run verify:ai`. The verifier sends a five-token request through every Groq and Lightning key, reports rotation readiness, and never prints key values.

## Getting Started

First, run the development server:

```bash
npm run dev
# or
yarn dev
# or
pnpm dev
# or
bun dev
```

Open [http://localhost:3000](http://localhost:3000) with your browser to see the result.

You can start editing the page by modifying `app/page.tsx`. The page auto-updates as you edit the file.

This project uses [`next/font`](https://nextjs.org/docs/app/building-your-application/optimizing/fonts) to automatically optimize and load [Geist](https://vercel.com/font), a new font family for Vercel.

## Learn More

To learn more about Next.js, take a look at the following resources:

- [Next.js Documentation](https://nextjs.org/docs) - learn about Next.js features and API.
- [Learn Next.js](https://nextjs.org/learn) - an interactive Next.js tutorial.

You can check out [the Next.js GitHub repository](https://github.com/vercel/next.js) - your feedback and contributions are welcome!

## Deploy on Vercel

The easiest way to deploy your Next.js app is to use the [Vercel Platform](https://vercel.com/new?utm_medium=default-template&filter=next.js&utm_source=create-next-app&utm_campaign=create-next-app-readme) from the creators of Next.js.

Check out our [Next.js deployment documentation](https://nextjs.org/docs/app/building-your-application/deploying) for more details.

## Live shop (the owner's live view)

`/admin/live`, linked as **Live shop** in the admin menu, shows the shop's figures from the POS, live, from anywhere:
today's sales against last week, every bill with its time, the hours, the week, the last 60 days, best sellers, low
stock and the Fix now list. A second screen, **Last week**, shows the Monday review, and a third, **From the shop**,
holds the products the shop PC has made ready for this website, to approve. The shop PC running Smart Retail POS
sends all of it to the owner's own Supabase project; the website only reads it there, in the browser, with the
owner's Supabase sign-in.

- **Last week:** the *Last week* button next to *Today* (`/admin/live#review` opens it directly, so it can be
  bookmarked). It shows last week, Monday to Sunday, against the week before and the same week a year before: sales,
  bills, the average bill and the profit before GST (when purchase prices are recorded), then the products that are
  running out and the ones that have not sold in 8 weeks. The shop PC sends it once an hour from Smart Retail POS
  2.17.0 or later, as the `review` row of the `shop_reports` table: figures and product names only, never customers,
  bills, the owner's decisions or their notes. The rules only suggest; nothing is changed from here. A project whose
  script is older than 2.17.0 shows what to run, and the live figures carry on meanwhile.
- **From the shop:** the *From the shop* button (`/admin/live#shop`; the number on it is how many products wait).
  Smart Retail POS 2.18.0 or later can offer each finished product (its photos and listing are made) to the owner's
  Supabase project, if the owner turned that on in its Settings. **Nothing is on this website until the owner
  approves it here**, one product at a time:
  - *Review* opens a product: its five photos (tick the ones to use; the first ticked is the main picture), its words
    (name, description, highlights, specifications, tags) and its price and MRP **from the POS**, never an AI's.
    The category is the one the shop PC chose from this website's own list; the owner can change it. Stock is not
    copied: the product keeps this website's own stock level.
  - *Approve and publish* uploads the photos to Cloudinary (as the admin's product form does), then makes the product
    with `createProduct`, or updates it with `updateProduct`, so it is indexed, cached and announced like any other
    product (`src/app/actions/shop-products.ts`). It needs the admin sign-in with the *products* permission; without
    it the owner can still look and decline. The project is told only after the website has the product, and its
    copy of the photos is deleted at once.
  - A product has a fixed place on this website, worked out from the shop and the POS product's number
    (`src/lib/live-shop/product-id.ts`), so a new price or a repeated approval updates it and never makes a second
    one. If another product has the same barcode, the owner chooses to update it or to add a new one. An update keeps
    the product's stock, offer, video and reviews, and keeps its pictures unless new photos are ticked.
  - *Decline* puts nothing on the website; the owner can offer the product again from its page on the shop PC.
  - Opening Live shop (any screen) tells the project this website's categories (`save_site_categories`, only when they
    differ from the ones it has), which the shop PC needs to choose one for each product. A project whose script is
    older than 2.18.0 shows what to run.
  - *Shop PCs* marks the main PC when the shop has more than one: only the main PC sends figures and products.
- **Ask the shop's AI:** the owner can type a question on Live shop (in English or Hindi). The shop PC answers with
  its own AI, from the POS, and the answer (words and a table) shows by itself. Only the owner sees the questions and
  answers. Answers are shown as text only.
- **Sign-in:** the owner's Supabase account (e-mail and password). The first account creates the shop; nobody else
  can see it. An authenticator app (6-digit codes) can be turned on under *Two-step sign-in*: from then on Supabase
  itself refuses the shop's data to the password alone. Live shop also opens without the website's admin sign-in.
- **Set up once:**
  1. In Supabase, run `supabase-owner-view.sql` from the Smart Retail POS repository (`SmartRetailPOS/cloud/`; a
     separate file of every release from 2.17.1, and also in each release's `SmartRetail-OwnerView.zip`) in the SQL
     Editor. Running it again is safe, and needed after an update (2.2.0 added the questions to the shop's AI, 2.17.0
     the weekly review, 2.18.0 the products for this website and the main PC).
  2. Add `NEXT_PUBLIC_SUPABASE_URL` and `NEXT_PUBLIC_SUPABASE_PUBLISHABLE_KEY` to the website's environment (see
     `.env.example`), then deploy again. Never the secret key: the page refuses it.
  3. In Supabase, *Authentication*, then *URL Configuration*: set the Site URL to `https://smartavenue99.com/admin/live`
     (and add it to the Redirect URLs), so the sign-up and new-password e-mails come back to Live shop.
  4. Open Live shop, create the owner's account and name the shop. Then, in Supabase, *Authentication*, then
     *Sign In / Providers*: turn off *Allow new users to sign up*.
  5. Under *Shop PCs*, press *Connect a shop PC* and type the code into Smart Retail POS on the shop PC
     (*Settings*, then *Owner's live view*), with the project URL and public key it shows.
- **Code:** `src/app/admin/live`, `src/components/admin/live`, `src/lib/live-shop`, `src/app/actions/shop-products.ts`
  (tested with `npm test`).

## Features

### AI Shopping Assistant
Smart Avenue includes a suite of intelligent assistants under the **Genie** brand (e.g., Genie Stylist, Genie Gift Finder) that help users find products and handle requests.
-   [AI Naming Guidelines](docs/assistant-guidelines.md)
-   [AI Product Request System Documentation](docs/ai-product-requests.md)

### Automated Tracking System
The codebase includes an automated system for tracking development progress and generating reports.
- **Start a task**: `npm run track init <task-id>`
- **Log work**: `npm run track log "message"`
- **Finish task**: `npm run track stop`
- **Documentation**: [Tracking System Design](docs/tracking_system/README.md)
