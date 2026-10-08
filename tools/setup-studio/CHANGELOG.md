# Setup Studio: Change log

What changed in each version of the Setup Studio, newest first.

## Next version · not yet released (set the number and the date when it is cut)

### New
- **Make the website package, on this PC.** In a customer's step "Website and app", a reviewer or administrator presses **Make the website package**. The Studio puts the website program (the one finished program that is the same for every customer) together with that customer's own folder (name, colours, logo, settings, made from the approved setup) and, if you have put it in place, the customer's licence file, and makes one file. It needs **no internet and no GitHub**; nothing is built. The file is kept in the Studio's folder with its fingerprint written in the customer's list, the Installer step, the customer's pack and the hand-over sheet; a file that is changed afterwards is refused.
- **The customer's licence file.** A place on the customer's page to put the website's licence file (choose the file or paste its text). Without one the package is still made and says plainly: no licence yet, the website will not start until the licence file is added. The Studio cannot ask the Licence Studio for the file yet, and cannot check its signature (the website does that every time it starts). The file is kept on this PC only and is not in the Studio's backup file.
- **The kit that comes with the Studio.** If a folder called `kit` (with `base-kit.json` and the release files) sits beside the Studio's program, the Studio uses it, and staff do not choose a programs folder. An administrator can still choose another folder; an empty box goes back to the kit. Without a `kit` folder nothing changes. Nothing copies a kit into a delivered Studio yet.
- **A truthful first screen.** The card now says what is there: the shop program, the website program, the Android app (still made by the build service) and how many customers have a licence file in place; and it says that the Studio cannot ask the Licence Studio for a licence yet.

### Changed
- The build service is now needed only for the Android app. It can still make the website, but a website package made on this PC takes its place.
- The first page and Settings read the programs quickly (a file whose size and time are unchanged is not read in full again); everything that uses a file still reads it in full.
- A damaged file in the programs is named in plain words instead of stopping the page.

### Not done
- The Android app is not made on this PC.
- The kit is not stored encrypted, the Studio has no licence of its own, and the Studio does not ask the Licence Studio for licences.
- The new page was run against a small stand-in for the page, not in a real browser; the Windows website program was never built or run here.

## 1.0.0 · 7 October 2026

First general release of NextGenOS Setup Studio for NextGenOS staff.

### New
- **1-Click Windows Setup Installer (`.exe`)**: `NextGenOS-Setup-Studio-Setup-1.0.0.exe` provides a 1-click setup wizard with Desktop and Start Menu shortcuts, and clean uninstaller.
- **Customer pack generation**: turns business details, country packs, tax rules, look and branding into a ready-to-deliver customer setup pack.
- **Automated customer build service**: 1-click trigger on GitHub Actions to build custom websites and Android APKs for customers without manual CLI tools.
- **Embedded runtime**: packaged with its own dedicated Node.js runtime—no system dependencies or pre-installed software required.
- **No-terminal app window**: runs cleanly in a standalone window with zero terminal windows or consoles.
