# Business Hub: what changed

The Business Hub is the part of the Smart Retail AI Ecosystem that runs any kind of business (see `README.md`). Newest first. (The older Windows programs keep their own list in the top-level `CHANGELOG.md`.)

## Unreleased

### Fixed
- **Taking a line off a bill could break the screen that showed the bill's amounts.** Line numbers keep a gap when a line is removed, and the till, the order screen and the printed bill found each line's amounts by its number. They now find them by the line's place in the list. A test pins it.
- **Setting up with the sample company could fail with "That document was not found."** The Hub's background tidying (which clears sales left open for more than a day) could start at the very moment the sample company was being made, and take its sales, which are dated days back. The tidying now waits until the shop's set-up has finished, and the sample company marks the shop as set up only when it is fully made. Tests pin both.

### New
- **Discounts at the till.** A line can be given a discount as a percent or as an amount (type `10%` or `25`), and a whole bill can be given one too. A discount on the whole bill is spread over the lines first and the tax is worked out on what is left, so the tax falls with the discount (the owner's decision 33; the older Windows POS left the tax unchanged). The bill shows "Discount given". Goods taken back from a discounted bill are credited at what was paid for them, whole or in parts. Owners and managers may always give a discount; a cashier only up to a limit set in *Settings → Business* (none until the owner sets one). New database step 5 adds only columns and has a tested way back.
- **Two looks: a list look for a monitor and a counter look for a touch screen.** *Settings → Look → The two looks*. The list look puts the menu along the top, shows the items as rows you scroll down and puts the bill below. The counter look has big buttons, the menu on the left, the items in the middle and the bill on the right. The owner chooses one for the shop, lets each screen decide (a touch screen gets the counter look, any other screen the list look), or gives one computer its own look. Nothing changes until the owner chooses. Only the selling screen has a different shape in the two looks so far.
- **AI helpers (optional, off by default)**: *Settings → AI helpers* for the owner. Eight switches, a description of the computer, AI services with permissions per kind of data, limits and a use record, keys kept in the system's safe, and a list of models with a way back. Needs the `ai` part in the licence. The shop's own screens do not use it and are unchanged.
- **Business event history (optional, off by default)**: *Settings → AI helpers → Business events* for the owner. What cameras and sensors saw is kept apart from what happened in the business; every event says who or what, where, when, how sure, why the system believes it and what it rests on; a wrong event is marked wrong or replaced and stays in the history. Records are forgotten when their time is up (short for what is private, biometric data not kept at all unless the owner says so, card details never), even with the switch off.
- **Business map (optional, off by default)**: *Settings → AI helpers → Business map* for the owner. The places (a shop, its areas, shelves) and devices (cameras, sensors) and how they connect to each other and to the shop's own products, people and bills. The shop's own records are only looked at, never copied; what they already say (a payment pays a bill) is worked out when asked.
- **Safer updates**: before an update changes an existing shop's database, the whole file is copied next to it (`shop.db.before-update-….bak`), and the new database step has a tested way back.

### Changed
- Only the owner has the new permission `ai`; the other roles are unchanged.

### Not yet
- Nothing in the shop writes business events yet (sales, voids and stock changes will, from the business map onwards).
- A durable queue for AI jobs (the waiting line there is lives in memory), removing names before text goes to an online service (an e-mail address or phone number already makes a text personal data), downloading or checking model files, the command-line assistants, cameras, events and the business map (Version 2, phases 2 to 8).

## 1.0.0 (release candidate)

First release of the Hub.

### New
- **Every kind of business**: retail store, restaurant and café, library, building contractor, salon and services, wholesale, and any other. Each has its own screens, a sample company, and a plain list of what works and what is not built yet.
- **Money and tax for 34 countries**, worked out in whole money units.
- **Devices**: receipt printers (ESC/POS), label printers (ZPL, TSPL, EPL, CPCL) by network, USB, Bluetooth, serial, the system print queue or the Windows spooler; keyboard-style and camera barcode scanning; price tags and posters.
- **Look**: the owner changes colours, logo, help details (and with a `full` licence the program's name) in *Settings → Look*, as far as the licence allows; a look file from the Brand Studio can be loaded.
- **Windows setup**: installs as a Windows service that starts with the PC, listens on this PC only, keeps the shop's data in its own protected folder, and never removes it on uninstall.
- **Signed licence**: the Hub starts only with a valid licence that includes the Hub; it shows the customer's own brand.
- **Protected build**: shipped compiled with its names hidden; every release is audited for source code, keys, databases, licences and secrets.

### Not yet
- Real-printer and real-Windows testing (see `README.md` and the release notes), several shops in one database, sync between PCs, a tax adviser's check of each country's rates.
