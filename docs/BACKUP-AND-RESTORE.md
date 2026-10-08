# Backups and putting a copy back (for the owner of a shop)

The Business Hub keeps your shop's data on one PC. If that PC is lost, stolen, broken or its disk fails, the data is gone unless there is a copy somewhere else. The Hub can make that copy by itself, every night. This page says how to set it up, how to see whether it worked, and how to put a copy back.

## 1. Choose where the copies go

You need a **second place**: a USB drive that stays plugged in, or a folder on another PC in the shop. Not the same disk as the shop's data.

1. Sign in as the owner. Open **Settings**, then the **Backups** tab.
2. Under **Where the copies go**, type the place, for example `E:\Backups` (a USB drive) or `\\OTHER-PC\Backups` (another PC).
3. Leave the time at 02:00, or choose a time when nobody is selling. Choose how many nightly copies to keep (14 is two weeks).
4. Tick **Make a copy every night** and press **Save**. The Hub tests that it can write there, and leaves a small marked file in the place so that it knows it is the right place later.
5. Press **Back up now** once. The screen says "The last good copy was made on ..." and the copy is listed.

If the shop is switched off at the chosen time, the copy is made as soon as it is switched on. Only the newest copies are kept; older nightly copies are deleted. Copies you made by hand are never deleted, and the Hub never touches any other file in that place.

## 2. See whether it worked

- The **Today** screen shows a message to the owner when copies are switched off, when the last try did not work, or when there is no good copy for a day and a half. When all is well it shows nothing.
- **Settings, Backups** says when the last good copy was made, and if the last try failed, why, in plain words ("the drive is not plugged in" and what to do).
- A failed copy never stops the till. The Hub tries again an hour later.

If you unplug the drive, take it away or put in a different one, the Hub will not copy "somewhere else" by mistake: it says "the place for the copies is not there, or is not the one chosen". Plug the right drive in, or choose the new one again in Settings, under Backups.

## 3. Put a copy back

You would do this on the same PC after something went wrong, or on a **new PC** after the old one was lost.

**On the same PC (Settings, Backups):** find the copy in the list under *Copies in that place* and press **Put this copy back**. Read what it says, tick **I understand** and press **Get it ready**. The copy is checked. Then **close the program and open it again** (or restart the PC). On starting, the Hub keeps the shop as it is now in a folder of its own (`before-restore-...`, next to the shop's data), puts the copy in its place, and shows what happened in Settings, Backups. Anything sold after the copy was made is not in it; it is in the kept folder. You can change your mind before restarting: press **Do not put it back**.

**On a new PC with nothing on it:** install the Hub, open it, and on the first screen open **I already have a copy of my shop (a backup)**. Plug the drive in, type where the copy is (for example `E:\Backups\NextGenOS-shop-....bak`) and press **Check the copy**. When it says the copy is ready, close the program and open it again: it starts with your shop as it was, with the same sales, stock, customers, books and bill numbers (the next bill carries on from the last number in the copy).

A copy that is damaged, whose books do not add up, that is not a shop at all, or that was made by a newer version of the program than the one you have, is refused, and nothing is changed.

## 4. Things to know

- A copy holds everything in the shop, including your customers' details. **It is not scrambled (encrypted) yet**, so keep the drive somewhere safe. Nothing is sent over the internet; an online copy is a separate thing, off, and not built yet.
- Try a restore once, now, on a spare PC, before you need it. A backup you have never put back is a hope, not a backup.
- When the program is updated, it first makes a copy of the shop. That copy goes to the same place you chose for your nightly copies; if there is none, it goes next to the shop's data.
- Making a copy while the shop is in use is safe: the Hub uses the database's own consistent copy, then opens the copy and checks it before it counts it as good.

## What has and has not been checked (CLAUDE.md section 2)

Checked by tests: the choices and their errors, a copy that is whole and checked, an unplugged or replaced drive, the nightly timing (once a day, catch-up after a night off, no repeated tries within the hour), only the newest copies kept and nothing else touched, a copy put back on an empty PC and over a working shop with the old shop kept, refusal of damaged, newer and non-shop files, only the owner may do any of it, the way back of the database step (`MigrationSafetyTests`, `BackupTests`, `e2e/backups.e2e.mjs`).

**Not verified:** a real USB drive being unplugged, a full drive, a network share (`\\OTHER-PC\...`) with real permissions, a real Windows PC, restarting the Hub service on a real PC to finish a restore (the Core part is tested; the owner must close and open the program), a real new PC.
