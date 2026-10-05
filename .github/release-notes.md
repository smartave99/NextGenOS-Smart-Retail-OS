**Smart Retail POS by NextGenOS** (part of the Smart Retail AI Ecosystem). Proprietary software: see `EULA.txt`. Nothing in this release works without a licence key from the NextGenOS Licence Studio.

### What is in this release

| File | What it is |
|---|---|
| `SmartRetailPOS-Hub-Setup-<version>.exe` | **Business Hub** for Windows 10/11 (64-bit): the counter, stock, bills and reports for a shop, restaurant, library, builder, salon or wholesaler, in any of the supported countries. Installs as a Windows service and opens in the browser at `http://127.0.0.1:5280`. |
| `SmartRetailPOS-Hub-<version>-win-x64.zip` | The same program as a plain folder, for a person who deploys by hand. |
| `smart-retail-pos-hub_<version>-1_amd64.deb` / `_arm64.deb` | **Business Hub** for Ubuntu 22.04/24.04, Linux Mint 21+ and Debian 12+ (Intel/AMD or ARM). Installs a background service with its own account, keeps the shop's data in `/var/lib/nextgenos` (never removed), and adds a menu entry and a full-screen entry for touch tills. |
| `SmartRetailPOS-<kit>-<version>.apk` / `.aab` | The Android app: a shell around the customer's licensed website. |
| `base-kit.json` | The list the NextGenOS **Setup Studio** reads: which file is which, with fingerprints. Download every file of the release into one folder and give that folder to the Studio, which adds a customer's own set-up beside the programs. |
| `SHA256SUMS.txt`, `BUILD-STATUS.txt` | Check your download; which parts were built. |

### Read this before you test

- **Test build.** A person has not yet run this on a real Windows PC, with real printers, scanners, cash drawers or a real phone. The release workflow installs the setup on a Windows runner and checks the service, but that is not a shop.
- **Tax.** Each country's rates and invoice wording are data, not legal advice. A local tax adviser must check them before a shop uses them.
- **Not signed** unless `WINDOWS-SIGNING.txt` says it was: Windows will warn that the publisher is unknown. The Android file is signed with a one-off test key unless `ANDROID-SIGNING.txt` says otherwise.
- **Source code protection** makes the programs costly to read; it cannot make code on a customer's PC impossible to read. The licence is signed, tied to the PC and can be revoked; that is the real protection.
- The older Windows POS, AI add-on and dashboard (India GST editions) are not part of this release's installers yet.
- Legal text (`EULA.txt`) has placeholders for the company's legal name and governing law, to be completed with counsel.

### Support

smartave99@gmail.com, +91 6123115368
