# Business Hub: what changed

The Business Hub is the part of the Smart Retail AI Ecosystem that runs any kind of business (see `README.md`). Newest first. (The older Windows programs keep their own list in the top-level `CHANGELOG.md`.)

## Unreleased

### Fixed
- **Setting up with the sample company could fail with "That document was not found."** The Hub's background tidying (which clears sales left open for more than a day) could start at the very moment the sample company was being made, and take its sales, which are dated days back. The tidying now waits until the shop's set-up has finished, and the sample company marks the shop as set up only when it is fully made. Tests pin both.

### New
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
