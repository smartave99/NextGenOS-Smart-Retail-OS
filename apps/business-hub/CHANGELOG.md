# Business Hub: what changed

The Business Hub is the part of the Smart Retail AI Ecosystem that runs any kind of business (see `README.md`). Newest first. (The older Windows programs keep their own list in the top-level `CHANGELOG.md`.)

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
