# The Help button and the support file

The owner's decision 18 (`docs/PLATFORM-DECISIONS.md`): when a client has a problem, the shop program makes a **safe support file** that the owner reads and sends; no remote control of a client's PC. Code: `apps/business-hub/src/NextGenOS.Hub.Core/Diagnostics/SupportFile.cs` (the shop's facts and the cleaning), `NextGenOS.Hub.Web/Diagnostics/` (the program, the licence, the recent problems), the page `Components/Pages/Help.razor`.

## For the owner

*Help* is in the menu (the owner only). Type what went wrong if you like, press **Make the support file**, read it, press **Save it as a file**, and send the file yourself (e-mail, a message from your phone) to the person who looks after your system. The program never sends it. You can make as many as you like; each is written in the activity list ("a support file was made, nothing was sent").

## What is in it, and what is not

| In it | Not in it |
|---|---|
| The program's version, the PC's operating system, how long the program has run, memory in use | Sales, bills, amounts, prices, stock figures |
| The licence: state, number, trial or paid, end date, parts included, PCs allowed | The licence key or any signing key |
| The data: its size, the database step, a check that the file is sound and the books add up | Customers, suppliers, staff, their names, addresses, telephone numbers, e-mail addresses |
| The copies: on or off, the last good one, the last failed one (folder removed) | The folder or drive of the copies |
| Counter PCs: on or off, how many are paired | The names of the counter PCs or their network addresses |
| AI helpers: which switches are on, how many services are connected and where they run, how the waiting lines stand | Any key, any text sent to or received from a service |
| Counts of a few important events in the activity record for 7 days (refused actions, locked sign-ins, voids …) | Who did them, or what they touched |
| The kind of business and the country | The shop's name |
| The last warnings and errors since the program started, with personal details removed | Passwords (a `password=…` is hidden), cookies and keys, long codes |

## How the cleaning works

Everything that goes into the file from the program's own words (errors, notes about a failed copy, what the owner typed) is passed through `SupportRedaction.Clean`: folders on the PC, e-mail addresses, network addresses, telephone and other long numbers (card numbers included), passwords/keys/tokens written as `name=value` or after `Bearer`, long codes, and **every name or address the shop keeps** (customers, suppliers, staff; first names and surnames of several-word names too) are replaced by a short note in brackets. It is a safety net: a stranger's name typed into the message that the shop does not know cannot be recognised, which is why the page asks the owner not to type customers' details.

## Tested

`SupportFileTests` (the cleaning, the contents, a shop full of private details with none of them in the file, owner only) and `SupportFileWebTests` (the running program's file, the last problems recorded in memory only and cleaned, where to send it comes from the licence or the owner's brand and is never built in), `e2e/help.e2e.mjs` (the page in a browser, a manager has no Help).

## Not built

The client's page in the Setup Studio that receives the file; Help in the older Windows programs; a Help button for roles other than the owner (a cashier asks the owner); a longer memory of problems (the recorder is in memory, so it starts empty when the program starts).
