# Licensing: the Licence Studio and the licence libraries

This folder is **private**. It makes, hands out and withdraws the licences of **Smart Retail POS by NextGenOS**. Only the *public* key and the Studio's address are built into what customers receive. The Studio, its data and its keys are never packaged with a customer build (`docs/SECURITY-MODEL.md`).

| Folder | What it is |
|---|---|
| `studio/` | The **Licence Studio**: a small web program for your sales and support people, plus a command line for you. Node.js, no outside packages. |
| `spec/LICENCE-FORMAT.md` | The written rules of a licence. Change this first if a rule must change. |
| `clients/dotnet/` | The licence library for the Windows programs and the Business Hub (`NextGenOS.Licensing`, `.AspNetCore`, `.Windows`) and its tests. |
| `testvectors/` | Signed examples every library must agree with. |
| `e2e/` | Tests that run the real Hub and the real storefront against a real Studio. |

## Set the Studio up (once, about 15 minutes)

You need **Node.js 22.5 or newer** (https://nodejs.org) on a PC or server that stays on, and for real use a web address with HTTPS (for example `https://licence.yourcompany.com`) pointing at it.

**What kind of program the Licence Studio is:** a *server* that you run on a machine that stays on and look after yourself, like any web server; it is not a program that opens in a window on a counter PC, so it has no icon and is started from a terminal on purpose (`CLAUDE.md`, section 10 allows this for a server that staff run remotely). Your sales and support people use it only in their browser, at its address. It is never given to a customer.

```
cd licensing/studio
node src/cli.js init --admin-email you@yourcompany.com --admin-name "Your Name"
```

This makes the **signing key** (kept encrypted in `licensing/studio/data/keys`, with its passphrase in `data/passphrase.txt`) and the first administrator. It prints a temporary password **once**: write it down; you choose your own at the first sign-in.

Then start it:

```
node src/server.js          # http://127.0.0.1:8080
```

For real use, put it behind HTTPS (a reverse proxy such as Caddy or nginx), and set `HOST=127.0.0.1`, `TRUST_PROXY=1` and `STUDIO_PASSPHRASE=...` in the environment (move the passphrase out of `data/passphrase.txt`). Back it up every day: Studio **Backup** page, or `node src/cli.js backup`. **Losing `data/` loses every licence and the signing key; there is no way to rebuild them.**

### Build your public key into the products (before every release)

```
node src/cli.js sync-clients --url https://licence.yourcompany.com
```

This writes the **public** key and your Studio's address into the licence library and the storefront. Commit those two files (they hold only public data), or give the same text to the release workflow: see `docs/RELEASE-GUIDE.md`. Without it every licence is refused.

## What your sales people do (no technical knowledge needed)

Sign in to the Studio in a browser. Each person sees only what their role allows (*sales*, *support*, *admin*).

1. **Customers → New customer**: name, country, email.
2. **Licences → New licence**: choose the customer, the **plan** (which parts of the ecosystem: Hub, AI, dashboard, storefront ...), how many PCs, for how long, and the **brand** (see `docs/BRAND-STUDIO.md`) and the **white-label level** (`none`, `theme`, `full`: how much of the look the customer may change on their own).
3. The licence page shows the **licence key** (`NGOS-XXXXX-XXXXX-XXXXX-XXXXX`). Give it to the customer. They type it into the program's first screen (`docs/CUSTOMER-GUIDE.md`).
4. A PC with no internet: **Offline activation**: paste the customer's request code, send back the answer code.
5. Changes later: **Renew**, **Change** (PCs, plan), **Hold** / **Resume** (for example for non-payment), **Revoke**, **Free this PC** (the customer got a new computer).

Every action is written to the **Audit** page.

## Rules for people who change the code

- Change `spec/LICENCE-FORMAT.md` first, regenerate the vectors (`node studio/scripts/make-testvectors.js`), and make **all** implementations pass them (the .NET library and the TypeScript library). A change in only one is a bug.
- Never put a private key, a passphrase, a licence database or `studio/data/` in a repository or a customer package. The release gate scans for it.
- There is no demo licence, no key generator and no setting that skips the check, and there must never be one in anything that ships.

## Check it

```
cd licensing/studio && npm test
node licensing/e2e/with-studio.mjs -- dotnet test licensing/clients/dotnet/NextGenOS.Licensing.Tests
node licensing/e2e/with-studio.mjs -- node licensing/e2e/storefront-e2e.mjs
node licensing/e2e/with-studio.mjs -- node licensing/e2e/hub-e2e.mjs
```

or all of it, with everything else: `node scripts/verify-all.mjs --full`.
