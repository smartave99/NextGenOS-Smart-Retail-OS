# Brand Studio: make the software look like the customer's own

**Smart Retail POS by NextGenOS** can wear a customer's name, colours and logo. You make the look once, in a **brand kit**, and every place that needs it gets it from there. No coding.

There are two ways to change the look, for two kinds of person:

| Who | Where | What it changes |
|---|---|---|
| **You, a reseller or a sales person** (making a customer's setup) | The **Brand Studio** (this page) | Makes the kit: name, colours, logo, contact, country, website, Android app. Makes the files for the licence, the Hub, the website and the app. |
| **The shop owner** (on their own PC) | The Business Hub: **Settings → Look** | Colours, logo, help details (and, with a `full` licence, the program's name), **only as far as the licence allows**. |

## How much may a customer change? The licence decides

The licence carries a *brand* (the starting look) and a **white-label level** (`licensing/spec/LICENCE-FORMAT.md`, sections 5.1 and 5.2):

| Level | The owner may change on their own PC |
|---|---|
| `none` | Nothing. The Look page says the licence has a fixed look. |
| `theme` | Main and second colour, logo, help email and phone. The program's name and the "by NextGenOS" line stay. |
| `full` | All of that, and the program's name, short name and the "by NextGenOS" line (a reseller licence). |

A colour that white words cannot be read on is refused, a logo must be a real small PNG or JPEG (at most 100 KB), and a bad value never stops the shop: it is ignored and the licence's own value is used. The rule is the same in every program (shared test vectors).

## Open the Brand Studio

**For NextGenOS staff, the look of a customer is made inside the Setup Studio** (its "look" step, with a live preview): that program carries everything it needs and opens as a program of its own. This stand-alone Brand Studio is for people who work from the source copy of the repository: it needs **Node.js 22 or newer** (https://nodejs.org), which is why it is not part of the staff bundle.

```
node tools/brand-studio/brand.mjs serve --app      a window of its own (no address bar, no terminal behind it); closing the window stops it
node tools/brand-studio/brand.mjs serve --open     in this terminal, and a tab in your usual browser
```

- It opens in the PC's own Edge (Windows always has it), or Chrome or Chromium, as a window of its own with a profile of its own. On a PC with none of these it does not open in your usual browser: a note opens that says what to install (Microsoft Edge is free), and the Brand Studio stops.
- **One at a time:** opening it again while it is open brings up the same window. To stop it: close the window, or press **Quit** (top right). The page says plainly when it has stopped. A problem at start-up is written in a note, `Brand Studio problem.txt`, which opens by itself.
- `Brand Studio (with a window, for developers).bat` and `brand-studio.sh` start it from the source copy with a terminal, on purpose (for people who work on it; the words are in the name so that nobody takes it for the normal way). Staff never need them.
- The address only works on this PC and changes every time.

On the left: the business's name, colours, logo, contact, country and kind of business, website, Android app id, and the words on bills. On the right: **how it will look**, light and dark, updating as you type. Press **Save the kit** (writes `brand-kits/<name>/`) and then **Make the files** (writes `brand-exports/<name>/`).

## Or use the command line

```
node tools/brand-studio/brand.mjs new luzon-fresh --name "Luzon Fresh Mart" --primary "#0f6cbd" --logo logo.png \
     --country PH --industry retail --site https://shop.luzonfresh.example --android-id com.luzonfresh.shop
node tools/brand-studio/brand.mjs set luzon-fresh --primary "#aa2233" --receipt-footer "Salamat po!"
node tools/brand-studio/brand.mjs check luzon-fresh        # says what is wrong, in words
node tools/brand-studio/brand.mjs export luzon-fresh       # makes brand-exports/luzon-fresh/
node tools/brand-studio/brand.mjs list
```

## What "Make the files" gives you (`brand-exports/<kit>/`, never committed)

| File | Use it for |
|---|---|
| `preview.html` | See the look in a browser: side menu, a sale, a bill, the sign-in card, the app icon, light and dark. |
| `hub-look.json` | The shop owner opens the Hub, **Settings → Look**, **Load a look file**, checks it, presses **Save**. (The Hub shows as much as the licence allows.) |
| `licence-brand.txt` | The brand for the customer's licence in the Licence Studio: the form values, or one command. |
| `website.env` | The website's name, address, country and kind of business, and how to make its icons from the logo. |
| `ANDROID.txt` | How to build the customer's Android app (easiest: commit the kit and run the *Release* workflow with that kit). |

The kit itself, `brand-kits/<name>/brand.json` and the logo, holds **no code and no secrets**. A customer's identity (name, address, logo) lives **only** in a kit or a licence, never in the product's own code.

## What is and is not done

- **Done and tested:** the kit rules, the command line, the wizard in a real browser, the files above, the Hub's Look page and its limits by licence level (also against the protected program with a real licence from a real Licence Studio).
- **Not done yet:** fonts and a light/dark default are allowed by the licence levels but the Hub does not apply them; receipts print the shop's name, address and footer set in *Settings → Business* (the kit's bill words are for the website and are not yet loaded into the Hub); the older Windows POS, AI add-on and dashboard read the licence's brand but have no Look page; the wizard has no way to make the Windows setup under a customer's own name (a `full` reseller licence changes the name shown inside the program, not the setup file's name).
