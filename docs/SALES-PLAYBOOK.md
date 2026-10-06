# Selling Smart Retail POS: a playbook for the sales team

**Smart Retail POS by NextGenOS**, part of the **Smart Retail AI Ecosystem**. One program, many kinds of business, many countries, with the customer's own name on it.

## What you can say, because it is true and tested

- **One program for any kind of business**: shops, restaurants and cafés, libraries, building contractors, salons and clinics, wholesalers, and others (switch on only the parts needed, rename the words). Each kind has its own screens, and a sample company to demonstrate with.
- **Money and tax by country**: 34 countries have a tax pack (India GST, Philippines VAT, UK VAT, US sales tax, Singapore GST and more). Totals are worked out in whole money units so bills always add up.
- **It works on the shop's own PC**, opens in a browser, and keeps working when the internet is down.
- **Any printer and scanner** of the common kinds: receipt printers (ESC/POS), label printers (ZPL, TSPL, EPL, CPCL), by network, USB, Bluetooth or serial, and the Windows print queue; any barcode reader that types like a keyboard; any phone or tablet camera. Price tags and posters print to any printer.
- **The customer's own look**: name, colours, logo, as far as their licence allows (Brand Studio, `docs/BRAND-STUDIO.md`).
- **Licensed per PC**, signed and tied to the PC, with renewals, holds and revoking from the Licence Studio.
- **Security**: the program is shipped compiled with its names hidden, and the shop's data stays on the shop's PC, readable only by the program's service and administrators. Details and limits: `docs/SECURITY-MODEL.md`.

## What you must NOT say

- **Never** "unhackable", "cannot be copied", "military grade", "bug free", "no security issues". The honest line: *"Licences are signed, tied to the PC and can be withdrawn, the program is protected so it is hard to read, and every release is checked; no software on a customer's own PC can be made impossible to break."*
- **Never** "approved for tax in <country>". The tax packs are data that a **local tax adviser must check** before a shop relies on them. Say so, and say it is part of onboarding.
- **Never** promise a printer model works until it has been tried. Say: *"We have tested the printer languages; we test each make on a real PC before we promise it."*
- The older Windows POS, AI add-on and dashboard are **India GST** products. Do not offer them outside India.
- Several shops in one database, and sync between PCs, are **not built yet**. Each shop PC is its own.

## Pick the right demonstration

| Prospect | Demonstrate | Show |
|---|---|---|
| Grocery, general store, pharmacy | Retail sample | Scan a barcode, two bags of rice, cash with change, the bill with tax, a return, daily report |
| Restaurant, café | Restaurant sample | Tables, an order, the kitchen screen moving a ticket, the bill with service charge and tip, split bill |
| Library, school, club | Library sample | A member, lend, a late book with its fine, a reservation |
| Contractor | Construction sample | A project, its quote, a progress bill with retention, costs, a change to the contract |
| Salon, clinic, repair | Services sample | A booking, a walk-in, charging a visit with a product and a tip, staff sales |
| Distributor | Wholesale sample | A trade customer with a credit limit, a sale on credit, a part payment, what is owed |

Set the demo up in a few minutes: install, activate with a **trial** licence (Studio → New licence, term short), tick **Fill with a sample business**, choose the country of your prospect.

## From "yes" to live: the checklist

1. Studio: **customer** → **licence** (plan, number of PCs, term, brand, white-label level) → give the **key**.
2. Make the look if they want their own: Brand Studio → kit → files (`docs/BRAND-STUDIO.md`).
3. On their PC: run the setup, activate, run the setup wizard (country, kind of business). Do **not** tick the sample company.
4. Enter their products or people; set their printers (Settings → Printers → Test page).
5. Tax: have their **local tax adviser** check the rates under Settings → Tax.
6. Show them the **backup** (the data folder) in `docs/CUSTOMER-GUIDE.md`.
7. Write down the PC, the licence id and the date. When they change a PC: Studio → licence → **Free this PC**.

## Common questions

- *Can we change it ourselves later?* Colours, logo and help details: yes, in Settings → Look, if the licence allows. Words, tax rates, who may do what, printers: yes, in Settings.
- *What if the internet is down?* It keeps working; it asks to connect again after a grace period.
- *What if our PC breaks?* The data is in one folder: restore it on the new PC; ask us to free the old PC's place in the licence.
- *Can you copy our data to another shop?* Not yet (no sync).
- *Is our data sent anywhere?* Not by the Hub: it stays on the PC. The licence check sends only the licence and a PC fingerprint (hashes) to the Licence Studio.

## Price and terms

Set by NextGenOS (not decided in this document). The agreement the customer accepts is `EULA.txt` (its legal name and governing-law placeholders are completed with a lawyer before it is shown to a customer).
