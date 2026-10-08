# Old Windows POS, study 04: users, printing, backup, settings, language, messages, small CRM, branches, extras

**Status (7 October 2026): IN PROGRESS. The skeleton is saved; topics are filled one at a time and saved after each. Topics done so far: A, B, C, D, E, F, G, H, I.** Nothing here was run: it was read from the source (a read-only study; nothing was built or run). The source is the owner's own (`docs/PLATFORM-DECISIONS.md`, decision 27).

## What to know first (10 lines)

(written last)

## 0. How to read this file

- `B/` means `apps/pos-desktop/Source/SmartAvenue99_POS_VB/SmartAvenue99 POS/BillPoint/`. A reference like `B/frmLogin.vb:560` is a file in that folder and a line number. The recovered code is decompiled: names like `flag21` or `text3` mean nothing, and every `If flag Then` is a decompiler's rewrite of the original `If`.
- Tables are those of the old SQL Server database. `PosSchemaData.cs` lists only some; the columns below were read from the SQL strings in the code. The two database scripts are **not** in the repository, so a column type or a default is "not known" unless the code shows it.
- "Keep or fix?" marks a quirk: keep means the Hub should copy the old behaviour, fix means the old behaviour is probably a mistake and the owner (or a lead) should decide.
- Worked examples are called **TV** (test vector), numbered per topic. They were worked by hand from the code. **None was run against the old program** (it cannot be built or run here). Where a one-line calculation (for example a Base64 text) was checked with a small script, it says so.
- A secret that the code stores or reads (a password, an API key, a connection string) is described as "a secret is stored here". No secret is copied into this file.

## A. Users, roles, permissions and sign-in

Status of this topic: written. Covers sign-in, the user master, roles, the three separate permission layers, the screen lock and its "security check", password change and recovery, the log, and the security problems.

### A.0 The five things to know

1. **There are four roles in a drop-down list and three different permission systems that do not agree.** (a) The role itself (`Registration.UserType`: Admin, Moderator, Sales Person, Inventory Manager) decides a few buttons and what the tile menu shows. (b) A per-user list of **51 Enable/Disable switches** (`UserControl.c1` to `c51`) hides top-menu items. (c) A per-user list of **4 Yes/No till rights** (`CashierSetting`) says whether a non-admin may change a discount, a bill discount, a price or the invoice date. None of the three is checked by the screens themselves except (c) and a few Admin/Moderator checks; most are only "hide the menu entry".
2. **A password is "encrypted" with Base64, which is not encryption.** `ModFunc.Encrypt` turns the text into UTF-8 bytes and then into Base64; `Decrypt` turns it back (`B/ModFunc.vb:128-147`). Anyone who can read the table can read every password. The user screen even fills the password box with the plain password when a row is clicked (`B/frmRegistration.vb:966`), and "Password Recovery" **e-mails the plain password** (`B/frmRecoveryPassword.vb:239`). The Hub must not copy any of this.
3. **There is a hidden super user.** The user type `*****` is left out of every user list (`B/frmUserControl.vb:1051`, `B/frmUserMenu_Control.vb:170`) and gets every menu entry (`B/frmMainMenu.vb:8195` onward). A fixed user id `sadmin` is used for a password re-check ("Security Checked") before branch administration, the customer and supplier outstanding Excel import, the stock list and the SMS switch (`B/frmMainMenu.vb:14104`, `B/frmCustomerOutstanding.vb:791`, `B/frmSupplierOutstanding.vb:781`, `B/frmCurrentStock.vb:1372`, `B/frmPOSTouch.vb:36004`). How such a user is created is not in the code (see A.9).
4. **Sign-in is also the choice of shop (company).** The first box on the sign-in screen is the company; it reads a separate master database and writes the chosen database name into a small file next to the program (`TempDBSettings.dat`) that every later screen reads (`B/frmLogin.vb:869-908`, `B/ModCS.vb:11-22`). A second file, `SQLSettings.dat`, holds the SQL Server name, the SQL user and its password in plain lines: a secret is stored here.
5. **Wrong passwords do not lock anything.** The sign-in screen counts three tries in a program variable (`frmLogin.counter = 3`) and disables the OK button at zero; restarting the program resets it. Failed tries are not logged; only success is (`B/frmLogin.vb:645-650`, `B/ModFunc.vb:105`).

### A.1 What a person sees (screens)

| Screen | File | Purpose |
|---|---|---|
| Sign-in | `frmLogin` | Company box, user id, password (show/hide eye button), language box (`cmbLang`), "Remember me" tick box (**not used by any code found**), on-screen keyboard button (starts `osk.exe`), "Create company", "Change password", "Password recovery", "Help" (opens the support-log report), a good-morning line. Shows the licence holder's name and logo. |
| Change password | `frmChangePassword` | User id, old password, new password twice. Reachable from the sign-in screen, before anyone is signed in. |
| Password recovery | `frmRecoveryPassword` | Type an e-mail address; the program mails the password to it. |
| User master | `frmRegistration` | The list of users and the form: user id, user type, password, name, e-mail, contact number, photo (file or webcam), signature image path, Active tick box. Buttons New, Save, Update, Delete, Check availability. |
| User control (51 switches) | `frmUserControl` | Pick a user id, set 51 drop-downs to Enable or Disable, Save/Update/Delete. |
| Menu rights by role | `frmUserMenu_Control` | A grid of tile-menu entries with four tick columns (Admin, Moderator, Sales Person, Inventory Manager); only the column of the chosen user's own role can be edited. |
| Menu master | `frmMenu_update`, `frmMenuHeader_update` | Edit the tile menu itself: category header (name, order, icon), entry (name, icon, form name, "not active", "visible in forms S or P"). |
| Cashier rights | `frmOtherSettings` (a tab of it) | Per user, four Yes/No rights; see D. |
| Screen lock | `frmScreenlock` | Full-screen, no border, no task-bar entry. User id and password to unlock; Exit button ends the program. Also used as the "Security Checked" re-check. |
| Logs | `frmLogs` | List of log lines for one user or all, by date range; export to Excel; "Delete all Logs". |

### A.2 Tables and columns

| Table | Columns (as the code uses them) | What they mean and traps |
|---|---|---|
| `Registration` | `userid, UserType, Password, Name, ContactNo, EmailID, JoiningDate, Active, Photo, Sign` | The user master. `Password` holds the Base64 text. `Active` is the text "Yes" or "No". `Photo` is a JPEG as bytes. `Sign` is a file path text. `JoiningDate` is the day the row was made (the screen sorts by it). User id and e-mail must each be new when saving (`B/frmRegistration.vb:1290-1330`); no unique key was seen in code (the table script is missing). |
| `UserControl` | `ID, UserID, c1 ... c51` | One row per user id; each `cN` is the text "Enable" or "Disable". Saving a second row for the same user id is refused ("Record already exists"). |
| `CashierSetting` | `ID, UserID, ATEID, ATGBD, ATCR, INVD` | Four Yes/No till rights per user (D.2). |
| `tbl_master_menu_header` | `id, category_name, orderby, icon_img, is_deleted` | The big tiles of the new menu. |
| `tbl_master_menu` | `id, category_name, sub_category_name, form_name, icon_img, is_deleted, visual_status, for_admin, for_Moderator, for_SalesPerson, for_InventoryManager` | The small tiles. The four `for_` columns are bits (1/0). `form_name` is the name of a method in the main menu; `visual_status` is a letter list ("S" for sale, "P" for purchase) used by the sale and purchase tills to show a shortcut. |
| `Logs` | `UserID, Date, Operation` | One line per event. Text only ("Successfully logged in", "added the new user 'x'", "deleted the user 'x'", "Screen Locked", "Screen Unlocked", "Exit Successfully", "Successfully changed the password", and many more written by the tills). The date has a time part; the POS dashboard uses these lines to find a bill's time (`docs/old-programs/05-ai-addon-and-dashboard.md`). |
| `AuditM`, `AuditI` | `Mastername, Type, Tillid, Userid, Dateandtime, Action` and `Tillid, Userid, Dateandtime, Action, Type, Voucherno, Voucherdate, Particulars, Itemname, Qty, Price, TotAmt` | Audit tables for masters and for stock. The functions that write them (`ModFunc.AuditTrial_Master`, `AuditTrial_Inventory`, `B/ModFunc.vb:1030-1068`) are **never called** from any screen (searched all files). Dead code. |
| `Language_set` | `default_lang_eng, other_lang, lang_hin` | Used at sign-in to fill the language box (E). |
| `RaintechMaster` (other database `RaintechMaster_DB`) | `CompanyName, DBName, Online_DBName` | The list of shops (companies) a PC can open; each shop is its own database (H). The name "Raintech" is a leftover from the older owner of the program and is an example of a name that must not survive into the merged program. |

### A.3 Sign-in: the exact flow (`B/frmLogin.vb:525-662`)

1. If no company is chosen: "Choose a store to sign in." Choosing a company reads `RaintechMaster` and writes its `DBName` into `TempDBSettings.dat` (`:869-908`).
2. User id empty (or the grey prompt text "Enter the User Name"): message. Password empty (or "Enter the Password"): message.
3. Query 1 (parameterised, good): `SELECT UserID, Password FROM Registration WHERE UserID=@d1 AND Password=@d2 AND Active='Yes'` with `@d2 = Encrypt(typed password)` (`:560-562`). A password is therefore compared as Base64 text. Whether letter case matters depends on the database's collation (the SQL Server default is case-insensitive). See TV A1 and "Not understood".
4. No row: "Login is Failed...Try again !"; both boxes cleared; company box cleared; `counter = counter - 1`; label "Attempt : n"; at 0 the OK button is disabled (`:637-651`).
5. Row found: query 2 reads `UserType` for the same user and password (`:569-576`; it does not check `Active` again, harmless).
6. The user type then picks what happens (four separate `If` blocks, `:585-636`):
   - **Admin:** enables the System-info button, shows "User Permission Settings", puts the user id and type on the main menu, **saves the chosen language in the Windows registry** under the product name (`DefaultLanguage`) and into `GlobalVariables.LoggedInLang_code`, writes the log line "Successfully logged in", hides the sign-in screen, shows the main menu.
   - **Moderator:** same, but does not save the language choice.
   - **Sales Person:** enables the System-info button, hides "User Permission Settings".
   - **Inventory Manager:** disables the System-info button, hides "User Permission Settings".
   - **Any other type (for example `*****`):** none of the four blocks runs, so nothing happens: the screen stays and no message is shown. So the hidden super user cannot sign in through this screen (see A.9).
7. The main menu then runs `UserControlSettings` (reads the 51 switches for this user id) and `UserControlValidation` (hides menu entries) and `HomeButtonControl`/`FillCategory` (the tile menu) (`B/frmMainMenu.vb:9364-9365`, `10138`, `10205`).

### A.4 The three permission layers, in detail

**Layer 1: the role (`Registration.UserType`).** Four values in the user-master drop-down (`B/frmRegistration.Designer.vb:337`). What the role alone controls:

| Thing | Admin | Moderator | Sales Person | Inventory Manager | Source |
|---|---|---|---|---|---|
| Top "Administrator" menu (user registration and similar) | yes | no | no | no | `frmMainMenu.vb:9453-9476` |
| "User Permission Settings" menu entry | yes | yes | no | no | `frmLogin.vb:585-636`, `frmMainMenu.vb:9453-9476` |
| "User Registration" menu entry | yes | hidden | (not set) | (not set) | `frmMainMenu.vb:9467` |
| System-info button | yes | yes | no | no | same |
| Edit or delete a saved bill (Update and Delete buttons after opening it from the invoice list) | yes | yes | no | no | `frmSalesInvoiceRecord.vb:1188`, `1337`, `1491` |
| Change a line discount, the bill discount, the sale rate or the invoice date on the till | always | always | only if the user's `CashierSetting` right is "Yes" | same as Sales Person | `frmPOS.vb:13719`, `14793-14840` |
| Update or delete a saved stock-transfer record (opened from the record list) | yes | yes | no | no | `frmStock_TransferRecord.vb:838` |
| Delete in the online godown settings screen (it talks to an outside cloud database); start or stop "Auto Data Synchronization" | Admin only | no | no | no | `frmGodownConfig.vb:241`, `frmAuto_Migrate.vb:690` |
| Which tiles of the new menu show | the `for_admin = 1` rows | `for_Moderator = 1` | `for_SalesPerson = 1` | `for_InventoryManager = 1` | `frmMainMenu.vb:10138-10345` |

The role does **not** limit which reports a Sales Person may open, or whether they can reach the cash book, unless the top-menu switches (layer 2) or the tile rows (the tile menu) are set.

**Layer 2: 51 switches per user (`UserControl`).** The 51 drop-downs on `frmUserControl` map to columns `c1` to `c51`. I matched each drop-down to its caption by position in the designer file (`B/frmUserControl.Designer.vb`, the label on the same row) and to the top-menu item it hides (`B/frmMainMenu.vb:8195-8760`, menu captions from `frmMainMenu.Designer.vb`). The order in which the columns are filled differs from the order on screen for the last nine (see the note after the table).

| Column | Caption on the user-control screen | What "Disable" hides or disables (main menu) |
|---|---|---|
| c1 | Company Information | "Company Information" menu |
| c2 | Sale Entry | "Sale" and "Point of Sale" menu, and the main button 10 |
| c3 | Sale Return | "Sale Return (Cr.Note)" and its main button |
| c4 | Quotation | "Quotation" |
| c5 | Purchase Entry | "Purchase Entry" and main button 11 |
| c6 | Purchase Return | "Purchase Return (Dr.Note)" and its button |
| c7 | Purchase Order | "Purchase Order" |
| c8 | Receipt | "Receipt (From Customer)" and button 12 |
| c9 | Payment | "Payment (To Supplier)" and button 13 |
| c10 | Income | "Income Voucher" |
| c11 | Expense | "Expense Voucher" and button 17 |
| c12 | Estimate | "Estimate / Delivery Note" |
| c13 | Product Catalogue | "Product Catalogue - cum - Image Update" |
| c14 | Gallery | "Gallery" |
| c15 | Bulk Editor | the four bulk editors (product, customer, supplier, salesman) |
| c16 | Customer Entry | "Customer" and button 14 |
| c17 | Supplier Entry | "Supplier" and button 15 |
| c18 | Sales Man Entry | "Salesman" |
| c19 | Product Entry | "Products" and button 16 |
| c20 | Inventory | the menu whose caption is "Inventory" (the menu item is named `AboutToolStripMenuItem`; **misleading name**) |
| c21 | UPI QR Code | "UPI QR Code Image" |
| c22 | Banking | "Banking" |
| c23 | Records | "Records" |
| c24 | Reports | "Reports" |
| c25 | Tax Report | "Tax Report" |
| c26 | Export / Import | "Export/Import" |
| c27 | Contra Voucher | "Contra Voucher" |
| c28 | Offer Validation | five offer menus: offer validation, offer messenger, promotional offer (buy X get Y), coupon management, gift offer validation |
| c29 | Setting | the menu whose caption is "Settings" (the menu item is named `LogoutToolStripMenuItem`; **misleading name**) |
| c30 | Messenger | "Messenger" |
| c31 | Cheque Print | "Cheque Print" |
| c32 | Main Screen Dashboard | the charts and tables on the main screen |
| c33 | Balance Sheet | **nothing** (the test is there but its body is empty) |
| c34 | Loyalty Management | loyalty card issue, loyalty validation, loyalty card |
| c35 | Service | "Services" |
| c36 | Android App + M.Branch | switches the Android-app sync service off at start (`frmMainMenu.vb:9366`); no menu item |
| c37 | Journal Voucher | "Journal Voucher" |
| c38 | Damage / Recover Item | "Damage / Recover Product Management" |
| c39 | Payroll Management | "Payroll" (menu item named `ContactToolStripMenuItem`, misleading) |
| c40 | Cloud Backup Mgmt | "Cloud Backup Management" |
| c41 | Virtual Company Info | "Vitual Company Info for Estimate Bill" |
| c42 | Customer Route | "Customer Location Route" |
| c43 | Auto Backup | "Auto Backup" |
| c44 | Reminder Record | **nothing found** that reads it |
| c45 | Logs Activity | **nothing found** that reads it |
| c46 | General Barcode | "General Barcode" |
| c47 | Cipher Barcode | "Cipher Barcode" and one separator |
| c48 | Pre/Suf Invoice Code | "Prefix and Suffix Invoice Code" |
| c49 | Transporter | "Transporter" |
| c50 | Weight Scale | "Weighing Machine Control" |
| c51 | WhatsApp Feature | "Configuration WhatsApp" |

Note on the order: on the screen the last nine drop-downs are numbered ComboBox43 to ComboBox51 but they are saved into `c43` to `c51` in a different order (ComboBox46 goes into `c43`, ComboBox45 into `c44`, ComboBox49 into `c45`, ComboBox43 into `c46`, ComboBox44 into `c47`, ComboBox50 into `c48`, ComboBox48 into `c49`, ComboBox47 into `c50`, ComboBox51 into `c51`; `B/frmUserControl.vb:1346-1357` for save and `1530-1537` for the grid click). The table above already uses the saved column order.

Rules: `Disable` hides the entry **unless** the user type is the hidden `*****`, which always sees everything (`:8195` onward: each `If c = "Disable" And type <> "*****"`). A user with **no row** in `UserControl` has every `cN` empty, so nothing is disabled: a new user sees everything until an admin saves their row (`B/frmMainMenu.vb:8147-8182`). The screen only fills a user list that excludes `*****`. Nothing blocks a Disable-d entry from being reached by other routes (a main-menu button, a keyboard shortcut, the tile menu, or another form that opens it); the code hides the entry and does not check inside the target form.

**Layer 3: the tile menu by role (`tbl_master_menu`).** The new main screen shows big category tiles and small entry tiles (`FillCategory`, `FillSubCategory`, `B/frmMainMenu.vb:10205-10325`). A tile shows when `is_deleted = 'false'` and the user's role column is 1. Clicking a tile reads its `form_name`, adds "1" to it and **calls that method of the main menu by name** (`btnSubCategory_Click`, `:10327-10345`; for example `frmStockTransfer1`, `frmBranchAdmin1`, `frmUserControl1`). There is no second check at the click. `HomeButtonControl` (`:10138`) also hides some of the main-screen buttons the same way by counting `tbl_master_menu` rows for the form name and the role. The role grid screen (`frmUserMenu_Control`) writes one bit per click (`UPDATE tbl_master_menu SET <column> = @Value WHERE id = @Id`, where the column name comes from the grid's column, `:317-329`).

### A.5 The user master, rules (`B/frmRegistration.vb`)

1. Required for Save: user id, user type, password, name, e-mail, contact number (`:1269-1330`). **Password at least 5 characters** (`:1280`). User id must not exist; e-mail must not exist (`:1290`, `1318`).
2. Password stored as `Encrypt(typed.Trim())`. `Active` = "Yes" if the tick box is on. Photo saved as JPEG bytes (the default picture is the program's own `photo` resource).
3. Update (`:1390-1500`): rewrites user id, type, password (re-encoded from the box, which was filled by decoding the stored one), name, contact, e-mail, active, photo and sign. Note: it can change the user id (the `where` uses the old one in `@d7`); the user-control and cashier-setting rows are keyed by user id **text**, so renaming a user silently detaches their switches (they keep the old id). **Fix?**
4. Delete: refused for the user who is signed in ("Currently logged in user can not be deleted") and for the ids `admin` and `Admin` (exact two spellings, `:727-745`). A deleted user's `UserControl` and `CashierSetting` rows stay behind. Writes the log line "deleted the user 'x'" under the signed-in user.
5. The e-mail box blocks typing most characters and checks the shape on leaving it (`:1044-1073`; not read in detail). The contact number box allows digits only (`:1074`).
6. Webcam capture and file browse set the photo; "Signature Image Path" is a text path to a picture used on printed forms (not followed up).

### A.6 Screen lock and the "Security Checked" re-check

- The lock (`B/frmMainMenu.vb:12266-12275`): copies the signed-in user id to the lock screen, writes "Screen Locked", shows the lock as a dialog. To leave it the person must type the password of that user id (`B/frmScreenlock.vb:406-488`, the same Base64 comparison against `Registration` and `Active='Yes'`), which writes "Screen Unlocked", or press Exit, which writes "Exit Successfully" and ends the program (`:525-529`). The lock form has no border, no close box and is not shown in the task bar (`B/frmScreenlock.Designer.vb:224-228`). Whether Alt+F4 closes it was not checked.
- The same dialog is used with the fixed id `sadmin` and the caption "Security Checked" before: branch administration (`B/frmMainMenu.vb:14102-14127`), importing an outstanding list from Excel in the customer and supplier outstanding screens (`B/frmCustomerOutstanding.vb:791`, `B/frmSupplierOutstanding.vb:781`), the stock list's Excel import (`B/frmCurrentStock.vb:1372`), and the SMS/WhatsApp status switch in the touch till (`B/frmPOSTouch.vb:36004`). So these actions need the password of a user whose id is literally `sadmin`. If no such user exists, nobody can get past that dialog except by Exit (which ends the program). **Keep or fix?** Keep the idea (a re-check for a risky action) but make it "ask the signed-in owner for their password", not a hard-coded name.
- The dialog does not tell the caller whether the unlock succeeded. A caller continues after `ShowDialog` returns, but the dialog can only close after a good password or the program ends, so the result is the same in practice.

### A.7 Change password and recovery

- **Change password** (`B/frmChangePassword.vb:33-109`): needs user id, old password, new password and confirmation; new password at least 5 characters; the two new entries must match; new must differ from old. One statement `UPDATE Registration SET password=@new WHERE userid=@u AND password=@old` (parameterised); zero rows changed gives "Invalid user name or password". On success it writes "Successfully changed the password" and shows the sign-in again. It does not check that the user is `Active`, and it works before anyone is signed in (like every old program's "change password" link).
- **Password recovery** (`B/frmRecoveryPassword.vb:193-276`): needs the shop's e-mail settings to exist (`EmailSetting` row with `IsDefault='Yes'` and `IsActive='Yes'`, else a dialog says to set e-mail up first). The address typed must be in `Registration.EmailID`. Needs internet. Then it builds a second query by **joining the typed e-mail into the SQL text** (`SELECT Password FROM Registration Where EmailID='...'`, `:239`), decodes the Base64 password and sends **"Your Password: <the password in plain text>"** to that address through the shop's own mail account (`ModFunc.SendMail`). The first, parameterised lookup must find the exact address before the unsafe query runs, which blocks an injection in practice, but the code is fragile. **Fix, do not keep:** the Hub must send a one-time reset link or ask the owner to set a new password, never the password.

### A.8 The log and its limits

- `ModFunc.LogFunc(user, text)` inserts one line (`B/ModFunc.vb:105-118`). Written by sign-in, user changes, screen lock, bill save, update and delete, stock operations and many other screens (the tills write 7 to 9 each).
- The log screen can **delete all logs** with one button and a yes/no question (`B/frmLogs.vb:500-520`, `634`). The deletion writes one line afterwards, but anyone who may open the log screen (it is behind c45, which does nothing, so anyone who finds it) can wipe the audit trail. **Fix:** the Hub's audit log is append-only (`AuditService`); keep it that way and never port "delete all".
- Failed sign-ins are not logged.

### A.9 Probable problems (security and logic), each with "keep or fix?"

1. **Passwords readable (Base64).** Anyone with the database can read all of them; recovery mails them. **Fix.**
2. **Secrets next to the program in plain files:** `SQLSettings.dat` (server, SQL user, password) and `TempDBSettings.dat` (database name); `Ext` (a cloud address and key for the Android sync, read at `B/frmMainMenu.vb:9378`). A secret is stored here. **Fix:** nothing like this in the Hub (it uses its own database file, and secrets belong in the operating system's store, `CLAUDE.md` section 15).
3. **No lock-out, no log of failures, restart resets the three-try counter.** **Fix** (the Hub already locks for 15 minutes after 5 failures).
4. **The role check is mostly menu hiding.** A menu hidden for a role can still be reached through another button, a shortcut, or the tile menu's reflection call. **Fix:** in the Hub the permission must be checked in the service or page that does the work (the Hub says its services do not check permissions either, `docs/old-programs/06-hub-map.md` section 5.3, so this is a gap to close on both sides).
5. **Dead or empty switches:** c33 (Balance Sheet), c44 (Reminder Record), c45 (Logs Activity) do nothing. **Do not port the dead ones.**
6. **Hard-coded names:** user ids `admin`/`Admin` (cannot be deleted), `sadmin` (re-check), user type `*****` (sees everything), and the company master database name `RaintechMaster_DB`. **Fix** (a hard-coded super-user name is a bypass risk and a name that must not survive, `CLAUDE.md` section 3 and section 8).
7. **Renaming a user detaches their switches** because the switches are keyed by the user id text. **Fix:** key by an id number.
8. **The `*****` user cannot sign in through the sign-in screen** (none of the four role blocks accepts it), so either an older sign-in path made it or it was never usable. **Not understood.**
9. **Case sensitivity of passwords and user ids** depends on the database collation, which is not in the repository. If it is the SQL Server default (case-insensitive), `ADMIN` signs in as `admin`, and two passwords whose Base64 text differs only in letter case would be accepted. Not verified.

### A.10 Worked test examples (by hand; none run through the old program)

- **TV-A1 (storage).** Password "Pass@123" is stored as `UGFzc0AxMjM=`; "abcde" as `YWJjZGU=`; "admin" as `YWRtaW4=`; "12345" as `MTIzNDU=` (the Base64 of the UTF-8 bytes; checked with a one-line script, not with the program). Decrypt of `YWJjZGU=` gives "abcde". The Hub must **not** reproduce this; an importer must not carry passwords across (A.11).
- **TV-A2 (new user, short password).** Save with password "abcd" (4 characters): refused with "The Password Should be of Atleast 5 Characters" and the box is cleared. With "abcde": accepted by the old program, **refused by the Hub** (minimum 8, at least 4 different characters, not equal to the user name, not in a short list).
- **TV-A3 (three tries).** Wrong password three times: after the first, label "Attempt : 2"; after the third, "Attempt : 0" and the OK button is disabled; closing and reopening the program gives "Attempt : 3" again. The Hub: 5 wrong tries lock the account for 15 minutes, and the lock is stored.
- **TV-A4 (switch).** User "ravi" has `c24 = "Disable"` and is a Sales Person: the "Reports" menu is hidden for ravi; the same user, if given type `*****`, sees it. A user with no `UserControl` row sees all menus.
- **TV-A5 (till rights).** Sales Person with `CashierSetting.ATGBD = "No"`: the bill-discount box is disabled; with "Yes": enabled. An Admin or Moderator always has it enabled (`B/frmPOS.vb:14793-14802`). (The old formula `(C="Yes" And type<>"Admin") Or (C="Yes" And type<>"Moderator")` is true for anyone with "Yes", so it is simply "Yes" or the user is Admin/Moderator.)
- **TV-A6 (delete a user).** Deleting "Admin" or "admin" is refused ("Admin account can not be deleted"); deleting your own id is refused; deleting "ravi" removes only his `Registration` row (his `UserControl` and `CashierSetting` rows stay).

### A.11 What the Hub has and how it differs

- **Hub:** `users(id, username, display_name, role, active, password_hash, failed_logins, locked_until)`; password stored with PBKDF2-SHA256 (600,000 rounds, a random salt), at least 8 characters, 5 failures lock for 15 minutes, the cookie is re-checked on every request so a role change or switching a person off takes effect at the next click; five fixed roles that are code (`Owner, Manager, Cashier, Kitchen, Librarian`) with 15 permissions; every sign-in problem and user change goes to an append-only audit log. (`apps/business-hub/src/NextGenOS.Hub.Core/Security/UserService.cs`, `Roles.cs`; `docs/old-programs/06-hub-map.md` section 5.3.)
- **Mapping of roles:** Admin to Owner; Moderator to Manager (but the old Moderator also had "User permission settings" and could edit saved bills; the Hub's Manager has no `users` permission); Sales Person to Cashier; **Inventory Manager has no match** (it needs `stock`, `purchases` and `catalog` but not `sell`; the Hub has no such role because roles are code).
- **Differences that need an owner decision before porting:**
  1. Whether roles stay a fixed list of five (code) or become data an owner can edit (the old POS lets an admin set 51 switches per user). The white-label rule (`CLAUDE.md` section 8) and "nothing customer-visible is fixed" argue for role names and which permissions each role has being a customer's data; the Hub's current design is the opposite.
  2. Whether per-user overrides are needed at all, or only a role per person plus a few "may change a price / give a discount" rights (the old `CashierSetting`). A smaller port: add four permissions `change-price`, `item-discount`, `bill-discount`, `back-date` (`D.2`), and give them to roles.
  3. **Passwords are not imported.** The old table holds reversible text, and the old minimum (5) is below the Hub's (8). The importer (`docs/old-programs/DATABASE.md`) should create each user with a random one-time password shown once to the owner, or none and a forced reset on first sign-in.
- **Port in this order (smallest safe):** (1) import users without passwords, map Admin/Moderator/Sales Person, ask about Inventory Manager; (2) the four till rights as Hub permissions with tests that a Cashier without `bill-discount` cannot set one (the Hub's discount code, decision 33, is the place to check it **in the service**); (3) a "confirm with your password" step for risky actions, replacing `sadmin`; (4) a log screen (read-only) over the audit table with a date filter and a CSV export; (5) the per-user switches only if the owner says so after seeing (1) and (2).

### A.12 Not understood (topic A)

- How the `*****` user type and the `sadmin` id are created (no code found; maybe the database script, which is not in the repository, or a vendor tool).
- The database collation (case rules) and whether `Registration.userid` has a unique key.
- Whether Alt+F4 or the Windows task manager can close the screen lock without the password.
- Why `HomeButtonControl` hides buttons by `form_name` (its dictionary of button to form name was only partly read, `B/frmMainMenu.vb:10138`).
- What the "Remember me" tick box and the signature image path are for.
- `FrmValidate` and `FrmValidate1` turned out to be GSTIN/validation dialogs, not sign-in (see `docs/old-programs/03-india-tax-and-staff.md`); `frmLoyaltyvalid`, `frmCustomerValid` and `fromItemoffervalid` are validation dialogs of other topics.

## B. Printing

Status of this topic: written. Covers bill printing (3 inch and 4 inch rolls, A4, A5), printer choice per PC, the template families and the 192 Crystal report files, barcode labels (the 20 ready styles, the cipher label, the drag-and-drop layout designer), kitchen and token slips, the cash drawer, and what each takes as data. Layouts of the `.rpt` files were not read.

### B.0 The five things to know

1. **Everything is printed by Crystal Reports** (a Windows-only .NET Framework reporting engine, 32-bit in this program). The program fills a small in-memory table plus about 50 named values ("parameters") and hands them to a report file; the report file holds the layout. No layout is written in code. The Hub must not use Crystal Reports (Windows only; its runtime has its own licence terms; `CLAUDE.md` section 3 on new dependencies). The data model below is what to keep.
2. **192 `.rpt` files exist but only about 137 are reached by any screen** (searched by name in every `.vb` file); the rest are old variants. The sales bill has **38 choices** in the touch tills (4 built-in, 4 "customise" copies read from a folder, 30 numbered styles: 3Inch 1-10, A4 1-10, A5 1-10). Labels have **20 styles**.
3. **A printer belongs to the PC's Windows name.** Printer, drawer, customer display, scale port, UPI id and brand name are kept per `TillID`, which is `Dns.GetHostName()` (the computer name), in table `PosPrinterSetting`. Rename the PC and every printer setting is lost (`B/frmPOS.vb:8398`, `10213`). The Hub's "counter PC" model (decision 4) needs a different key.
4. **A bill is printed from what is on the screen, not from the saved bill.** The line table is built from the grid rows (33 columns), the totals from text boxes (`B/frmPOS.vb:8173-8470`). Reprinting a saved bill reloads it into the till first. The Hub prints from the stored document (a better design to keep).
5. **If no printer of the right type is set for this PC, nothing happens and nothing is said.** The program builds the whole report, then looks for a printer row of the type the template needs (Laser for A4/A5, Thermal for the rolls). No row: the code simply skips both branches (`B/frmPOS.vb:8397-8470`). A shop owner sees "nothing printed".

### B.1 What a person sees (screens)

| Screen | File | Purpose |
|---|---|---|
| Printer settings | `frmPrinterSettings` (tabs "Bill Design" and "Bill Setting") | Per PC: printer name, printer type (Laser or Thermal), terminal id, invoice template type (A4/A5/3 inch with a picture of each style), cash drawer yes/no, customer display (port, baud rate, second monitor), QR display port, weight machine port, UPI id, brand name, "Show menu item images in POS". Buttons Update, Delete, Apply. |
| Bill style chooser | `frmBillStyle` | A grid of styles (picture + name) filtered by All/A4/A5/3 inch, "Apply" and "Printer Setting". Reads `BillPreview`. |
| Invoice header setting | `frmInvoiceHeader` | A named "Sales Invoice Template Header" with a "previous invoice date show" flag and a default template, per terminal (`InvoiceHead`). |
| Terms and conditions | `frmTermsandCondn` | One free-text block printed on bills (table `Terms`; only one row is allowed, `:494`). |
| Prefix and suffix invoice code | `frmInvCode` | Invoice numbering text (see D). |
| Template editor | `frmTempleteEdit` | Four buttons that open the A4, A5, 3-inch or 4-inch `.rpt` in the Windows default program (it says Visual Studio 2010 or newer is needed). It is not usable by a shop owner. |
| General barcode label printing | `frmBarcodeLabelPrinting` | Pick products or lots from a list, set copies, pick a template, preview. |
| Barcode label designer | `frmBarcodeMain` (5,100 lines; reused from a cheque-printing designer: fields called `nudChequeLeafWidth`) | Drag text and barcode boxes on a sheet of a chosen size, set font, colour, alignment, tick which product fields appear (MRP, batch, mfg, exp, size, colour, GST, QR, purchase invoice, wholesale price), "Test Print", save as a named layout. |
| Layout label printing | `frmBarcodeLabelPrintingnew` | Same product picker; template box `cmbLayouts` lists saved layouts; prints with `PrintDocument` and ZXing for QR. |
| Cipher barcode label printing | `frmCustomiseBarcode` | Labels with a coded price ("sticker code") so the customer cannot read the cost: columns Product Code, Product Name, Supplier Code, Barcode, Sticker Code, Sale Price; sizes "A4 Size - Single", "A4 Size - Quadrat", "Thermal Size - Single", "Thermal Size - Double". |
| Other print screens | `frmBanarCreate` and `frmProductImageMaker` (catalogue `CryCatalogue`), `frmPrintLoyaltyCard` (`rptLoyaltyCard`), `frmCompanyupdate`, `frmCustomer`, `frmSupplier` (address envelope reports) | |

### B.2 Tables and columns

| Table | Columns | Meaning and traps |
|---|---|---|
| `PosPrinterSetting` | `TillID, PrinterName, PrinterType, CashDrawer, WSPort, ActiveWS, CDPort, CustomerDisplay, SecDisplay, QRDisplayPort, ActiveQR, BundRate, UPIID, BrandName, PT, BillStyleId` | One row per computer name. `PrinterType` is the text "Laser Printer" or "Thermal Printer". `CashDrawer`, `ActiveWS`, `CustomerDisplay`, `SecDisplay`, `ActiveQR` are "Yes"/"No" text. `WSPort` is the weight-machine serial port; `CDPort` the customer-display port; `BundRate` (sic) the baud rate (default text "115200" in the form). **`PT` means "show menu item images in POS" ("Yes"/"No"), not what its name suggests** (`B/frmPrinterSettings.vb:677`, `:115` caption). `BillStyleId` is the chosen bill style; a new PC gets 21 by default (`:1011-1030`: the first-run insert uses "Thermal Printer", drawer "No", PT "Yes", style 21). `UPIID` and `BrandName` are the shop's UPI address and a name for the payment QR (see I); both are customer data held in a printer table. |
| `BillPreview` | `BillStyleId, BillStyleName, PrintPreviewType, BillStyleImage` | The list of bill styles with a picture each. `PrintPreviewType` is "A4", "A5" or "3Inch". The picture file is read from a folder next to the program (`Bill_Barcode\`, `:2218`). |
| `BarcodePreview` | `BarcodeStyleId, BarcodeStyleName, PrintPreviewType, BarcodeStyleImage, is_active` | The 20 label styles. **Exactly one is "active"**: choosing a style sets `is_active = 0` for all and then 1 for the chosen id (`B/frmBarcodeLabelPrinting.vb:2235-2242`). So the style is a shop-wide choice, not per PC. |
| `CatalogStyle` | `BillStyleId, BillStyleName, BillStyleImage, isdisplay` | Same idea for the product catalogue page (`B/frmCatlogStyle.vb:105-144`). |
| `InvoiceHead` | `Name, LIDS, DefInvTemp, TID` | Header name, "previous invoice date show" (`LIDS`), default template, terminal id. What `LIDS` does on the till was not followed up. |
| `Terms` | `ID, c1` | The one terms-and-conditions text (`c1`), loaded into the till as `TAC` and printed as report value `P7`. |
| `Kitchen` | `KitchenName, Printer, IsEnabled` | A kitchen section and the Windows printer for it; `Product.Kitchen` links a product to a section. |
| `tbl_layout` | `layout_id, layout_name, layout_width, layout_height, layout_bg_color, layout_bg_color_status` | A saved label layout: paper size (stored truncated to 2 decimals), background colour. |
| `tbl_layout_label` | `layout_id, label_name, label_text, label_width, label_height, label_X, label_Y, label_font_name, label_font_size, lbl_font_style, label_text_color, label_is_fixed` | One text or barcode box of a layout. `label_is_fixed` separates fixed text from a product field. |

### B.3 The bill: data model, template choice and printer choice

**Line table** passed to a bill template (33 text columns, in this order): `PID, ProductName, HSNC, MainQty, AltQty, AltUnit, MRP, Rate, Total, DiscPer, Disc, TaxableAmt, CGSTPer, CGST, SGSTPer, SGST, IGSTPer, IGST, CESSPer, CESS, Amount, Barcode, PurchaseRate, Margin, Description, IM1, IM2, MainUnit, Batch, Mfg, Exp, Size, Colour` (`B/frmPOS.vb:8199-8231`). Note that **`PurchaseRate` and `Margin` are in the table**: a template that shows them would print the shop's cost and profit on the customer's bill. The Hub's bill data must never carry the cost to a customer-facing template.

**Values passed by name** (`SetParameterValue`, `B/frmPOS.vb:8362-8415`; the touch till adds `ByReturn` and four loyalty values): `PaidAmt, PendingAmt, P2` (copy label), `P3` (invoice type text), `P5` (bill sundry name), `UPI` ("UPI PAY :" or empty), `TendAmt, RefundAmt` (cash tendered and change; if nothing was tendered, tendered = bill amount and change = 0.00), `P7` (terms text), `P10` (notes box), `Bill Sundry` (freight), `Bill Discount, Grand Total, Roundoff, Net Total, Invoice No, Date, Tax Type, EWay, Salesman, Company, CompAddress, CompContact, CompEmail, CompGSTIN, CompState, CustomerName, CustomerAddress, CustomerMobile, CustomerGSTIN, CustomerState, CustomerBalance, CGSTTot, SGSTTot, IGSTTot, CESSTot, Transport, Naration, Coupon` and a value named `"0"` (the text of a box, `TextBox9`; purpose not understood). Because `Grand Total`, `Net Total`, `Bill Discount` come from different boxes, the names are misleading; mapping used by the till: `Grand Total = txtTotal`, `Net Total = txtGTBA` (the amount after round-off), `Roundoff = txtRoundOff` (see `docs/old-programs/01-selling-buying-stock.md` section 1.4 for which is which).

**Two images** are written to **fixed paths** `C:\Temp\Company.jpg` (the company logo) and `C:\Temp\QRImage.jpg` (the UPI QR) before every print (`B/frmPOS.vb:8173-8190`; the touch till writes `QRImage.png` but saves JPEG data into it, `frmPOSNewTuch.vb:10756`). The templates read them from there. Two tills printing at once on one PC, or a PC where the program has no right to `C:\`, break each other. **Do not port.**

**Which template** (`ComboBox1.SelectedIndex`, items in `frmPOSNewTuch.Designer.vb:2468`):

| Index | Name | Report |
|---|---|---|
| 0 | Laser Printer-A4 | `A4POS` (compiled in) |
| 1 | Laser Printer-A5 | `A5POS` |
| 2 | Thermal Printer-3Inch | `T3InchPOS` (the classic till) or `T3InchPOS1` (the touch till; the two tills use different classes for this name, `frmPOS.vb:8318`, `frmPOSNewTuch.vb:10896`) |
| 3 | Thermal Printer-4Inch | `T4InchPOS` |
| 4 to 7 | Customise-A4, -A5, -3Inch, -4Inch | the same four names read from the folder `CryReport\` next to the program, so a person can edit the file |
| 8 to 17 | 3Inch-Style1 to 10 | `T3InchPOS1` to `T3InchPOS10` from `CryReport\` |
| 18 to 27 | A4-Style1 to 10 | `A4POS1` to `A4POS10` |
| 28 to 37 | A5-Style1 to 10 | `A5POS1` to `A5POS10` |

The classic till `frmPOS` only offers the first 8. The same 38-way choice, with copies of the same print code, sits in six other screens (`frmPOSNew`, `frmPOSNewTuch`, `_Quotation`, `_Service`, `_StockInward`, `_StockTransfer`, `frmPOSTouch`) which print their documents through the same bill reports.

**Which printer.** After the template is built, if the index is one of the roll types (2, 3, 6, 7, 8 to 17) the program reads `PrinterName` from `PosPrinterSetting` where `TillID = this PC` and `PrinterType = 'Thermal Printer'`; for A4/A5 types where `PrinterType = 'Laser Printer'`. The preview/direct choice is a drop-down with the items "Enable" and "Disable" (`frmPOS.Designer.vb:2699`): index 0 shows the report in a viewer window (`frmReport`), index 1 prints straight to the named printer with `PrintToPrinter(1 copy, no collate, all pages)` and `DissociatePageSizeAndPrinterPaperSize = True` (`B/frmPOS.vb:8400-8470`). One copy is sent; the number of copies the cashier sees (`cmbprintcopy`: ORIGINAL COPY, DUPLICATE COPY, TRIPLICATE COPY, EXTRA COPY) is only a label printed on the paper (`P2`).

**Particulars on the name line** (tick box `chkpara`): if a line has a batch, mfg or exp, the name column becomes "name, new line, Batch: ...", with an IMEI, "IMEI(1): ...", with a size or colour, "Size: ...". If the language tick box `chkLang` is on, the local-language name (grid column 19) is shown instead of the product name (E).

**Cash drawer.** `OpenCashdrawer` sends the five raw bytes `ESC p 0 @ @` (`1B 70 30 40 40`, a drawer pulse) to the Windows printer named in `PosPrinterSetting` for this PC where `CashDrawer = 'Yes'` (`B/frmPOS.vb:10205-10227`, `B/ModCashDrawer.vb`). No row: it sends to an empty printer name and shows no message.

**Kitchen slips.** `PrintKOT` (`B/frmPOS.vb:20749`): for each distinct `Kitchen.KitchenName` used by the bill's products, fill a data set (`Product`, `InvoiceInfo`, `Invoice_Product`, `Kitchen`, `Company`), set parameter `p1` to the section name, and print `rptKOT` to `Kitchen.Printer` if `IsEnabled = 'Yes'`. The query timeout is set to unlimited. Tokens: `CryToken` (all tills), `CryToken1` (`frmEstimate`).

### B.4 The report families (what exists, what screen uses it, what data it takes)

| Family | Files | Used by | Data it takes (as far as the calling code shows) |
|---|---|---|---|
| Sales bill, 3-inch and 4-inch roll | `T3InchPOS`, `T3InchPOS1` to `10`, `T3InchPOSD` (touch till only), `T4InchPOS` | all tills | the line table and parameters above |
| Sales bill, A4 | `A4POS`, `A4POS1` to `10` | all tills | same |
| Sales bill, A5 | `A5POS`, `A5POS1` to `10` | all tills | same |
| Purchase bill, return, order | `A4PurchaseInv`, `A4PurchaseReturnInv`, `rptPurchaseOrder` | `frmPurchaseEntry`, `frmPurchaseReturn`, `frmPurchaseOrder` | tables of the document and `Company` |
| Credit note | `rptCreditNote` | `frmSalesReturn` | return header and lines |
| Quotation, estimate | `rptQuotation1`; `rptEstimateA4`, `A4V`, `A5`, `A5A`, `A5Economical`, `A5EconomicalV` | `frmQuotation`, `frmEstimate` | document tables |
| Service | `rptServiceBillingInvoice`, `rptServiceReceipt`, `rptServiceBilling` (report) | `frmServiceBilling`, `frmServices`, `frmServiceDoneReport` | service tables |
| Receipts and vouchers | `rptCustomerPaid`, `rptVoucher`, `rptPayment_WithdrawalReceipt`, `rptFundDepositReceipt`, `rptAdvanceEntry` | receipt, voucher, fund screens | voucher rows |
| Pay | `rptSalarySlip`, `rptSalarySlips`, `rptSalarySlips1`, `rptEmployeePayment`, `rptEmployeePayment1`, `rptSalesManPayment`, `rptSalesmanCommission` | payroll and salesman screens | see `docs/old-programs/03-india-tax-and-staff.md` |
| Kitchen and tokens | `rptKOT`, `CryToken`, `CryToken1` | tills, estimate | kitchen data set |
| Loyalty and gifts | `rptLoyaltyCard`, `CryGift`, `CryPrivilege` | `frmPrintLoyaltyCard`, gift sender, tills | card and gift rows |
| Product labels | `BarcodeT1` to `BarcodeT18`, `BarcodeCustomise1`, `BarcodeCustomise2`, `CBarcode` (combo pack), `rptBarcodeCipher`, `rptBarcodeCipher2_1`, `rptBarcodeCipher2_2`, `rptCipherA4_4` | label screens, `frmProductRec` | the 20-column label table (B.5) |
| Catalogue page, envelopes | `CryCatalogue`; `rptCompanyEnvolve`, `rptCustomerEnvolve`, `rptSupplierEnvolve` | catalogue maker; company, customer, supplier screens | product list; address |
| Accounting and other reports (about 55) | `rptBalancesheet`, `rptTrialBalance`, `rptCashBook`, `rptGeneralLedger`, `rptGeneralDayBook`, `rptCustomerLedger1`, `rptSupplierLedger1`, `rptDebtors`, `rptOutSupl`, `rptStockMovement`, `rptGSTReport`, `rptGSTSale`, and so on | the reports screens | see `docs/old-programs/02-masters-accounting-reports.md` section C |
| No reference found (about 55) | `A4SaleCustomise*`, `A5SaleCustomise*`, `A5CustomiseNew`, `Thermal3Inch*`, `Thermal4InchSaleCustomise`, `rptInvoiceTP*` (five variants including a 58 mm one), `rptSalesInvoice*` (about 15), `rptDebitNote`, `rptCreditors`, `rptQuotation`, `rptPurchaseC1/C3`, `Barcode128`, `BarcodeCustomise`, `BarcodeCustomiseNew/X`, `BarcodeT111`, `BarcodeT2x`, `rptBarcodeLabelPrinting*`, `Crybar*`, `CrystalReport1`, `a.rpt`, `rptTrialBalance` | nothing found | Older bill and label variants. A 58 mm roll template exists only among them (`rptInvoiceTP58`). **Junk, but a source of ideas for paper sizes.** |

The layouts were not opened. To know exactly which field a given style prints, a person must open the `.rpt` in Crystal Reports; that was not done.

### B.5 Barcode labels

- **Data** (`B/frmBarcodeLabelPrinting.vb:2068`, the query, built from the lots in stock): `ProductCode, ProductName, Category, Barcode, Qty (available), PartNo, HSNCode, MRP, SPrice (sale), WPrice (wholesale), Batch, Mfgdate, Expdate, Size, Colour, GST (CGST + SGST as stored), QrBarcode, Discount`. Only lots with `Temp_Stock.Qty > 0` and `Product.Status = 'Yes'` appear. A lot with no stock cannot be labelled (the same barcode is silently dropped). Label table columns passed on: `PCode, ProductName, Category, Barcode, AvlQty, NoCopy, PartNo, HSNC, MRP, SalePrice, WholesalePrice, Batch, Mfg, Exp, Size, Colour, GST, PurInv, QrBarcode, Discount` (20).
- **Search types:** Product Name, Category, Barcode, Part No, HSNC, Batch, Size, Colour (a drop-down, `Designer:170`). Two radio buttons "B-1" and "B-2" (their meaning was not followed up).
- **Copies.** Two modes: per product (the "No(s) of Copy" column on each row) or one number for all products (tick box "No(s) of Copy for All Products"). After the rows are repeated, the table is **sorted by barcode**, so copies of different products can mix with equal barcodes grouped (`:1798`).
- **Template.** 14 shape names in `ComboBox2` ("Standard A4 Size (2 x 1)", "Standard (L) Single (2 x 1)", "TVS Printer Dual (2 x 1)", "Standard Single (1 x 0.5)", "Standard (C) Single (2 x 1)", "Standard Single (1.5x1.5)", "Standard Single (3 x 1.5)", "Double Size Dual (2 x 1)", "Standard Dual (2 x 1)", "Standard Single (1.5 x 3)", "Standard A4 4PCS(2 x 1)", "Standard A4 8PCS(2 x 1)", "Barcode Customise Single", "Barcode Customise A4"; sizes are inches) are only picture previews read from `Bill_barcode\<name>.JPG`. The real choice is the **active style** in `BarcodePreview` (20 styles): style 1 to 5 are compiled reports (`BarcodeT1` to `T5`), 6 to 12 and 15 to 20 are `BarcodeT6` to `BarcodeT18` loaded from `CryReport\`, 13 and 14 are `BarcodeCustomise1` and `2` (`B/frmBarcodeLabelPrinting.vb:1808-1990`). Parameter `P1` is the company name text.
- **Cipher labels** (`frmCustomiseBarcode`): the "sticker code" is a coded price. Where the code table lives was not read.
- **Layout designer:** a person drags text boxes and a barcode on a sheet of any size; boxes are stored by position and font; a layout can then be chosen on `frmBarcodeLabelPrintingnew`, which draws with `PrintDocument` and makes QR images with ZXing (`:1491`). The designer was written first for printing cheques (`ChequePrint` menu entry, switch c31) and reused: the field and button names still say "Cheque".

### B.6 Quirks and probable bugs (keep or fix?)

1. Silent no-print when the printer row is missing or of the wrong type (A4 chosen but only a thermal printer set up). **Fix:** say so in plain words.
2. Fixed `C:\Temp` image files (above). **Fix.**
3. The printer key is the PC name. **Fix** (key by the Hub's counter id).
4. Two bill classes share the name `T3InchPOS`/`T3InchPOS1` in the two tills, so "3 inch" prints differently from the classic and the touch till. **Not understood** whether on purpose.
5. The copy count is a label; the code always sends one copy. **Keep** (a printed word); real extra copies can be done by sending twice.
6. `PurchaseRate` and `Margin` ride along in the bill table. **Fix:** never pass cost to a template.
7. Print before save: if a person prints and then the save fails (the save chain is not one transaction, `01` section 0), a paper bill exists that is not in the books. **Fix** (print only after the document is stored).
8. A "Template Editor" that needs Visual Studio. **Drop;** replace by choosing among the Hub's own layouts plus data (logo, terms, footer text) and, later, a layout designer for labels.
9. The label query joins `Category`, `SubCategory` and `Product` with the text of the barcodes put inside `IN (...)` (`:2078`). A barcode with a quote in it would break or alter the query. **Fix** (parameters).
10. `Integer.Parse(Val(text))` for copies: a copy count typed as "2.5" gives text "2.5", which `Integer.Parse` rejects (an error box); not run. **Fix:** whole numbers only.

### B.7 Worked test examples (by hand; none run)

- **TV-B1 (which printer).** PC "COUNTER1" has one `PosPrinterSetting` row: PrinterType "Thermal Printer", PrinterName "RP-80". The cashier picks "Laser Printer-A4" and print mode "Disable" (direct). The code looks for PrinterType 'Laser Printer' for this PC, finds nothing, and prints nothing, with no message. With template "Thermal Printer-3Inch" and the same row it prints one copy on RP-80.
- **TV-B2 (copies per product).** Rows: A (barcode 200, copies 3), B (barcode 100, copies 2), "same number for all" off. Rows built: A,A,A,B,B. After the sort by barcode: B,B,A,A,A (5 labels). If B has stock 0 it is dropped: A,A,A.
- **TV-B3 (copies for all).** Same rows, tick box on, number 2: each product twice; result B,B,A,A (4 labels), whatever the per-row copy numbers were.
- **TV-B4 (drawer).** The bytes sent are `1B 70 30 40 40`; sent only to the Windows printer name stored on this PC's row where `CashDrawer = 'Yes'`.
- **TV-B5 (cash tendered).** Tendered box 0 and bill amount 1,180.00: the parameters are `TendAmt = 1180.00` and `RefundAmt = 0.00`. Tendered 2,000 and refund 820.00: `TendAmt = 2000`, `RefundAmt = 820.00`.
- **TV-B6 (name line).** A line "Phone X" with IMEI(1) 123 and IMEI(2) 456, with the particulars tick box on, gives the name column the text "Phone X", a line break, "IMEI(1): 123", a line break, "IMEI(2): 456" (`B/frmPOS.vb:8247`). In the same row the report columns `Total` and `Amount` both receive the grid's line total (grid column 16), so they are always equal; `IM1` and `IM2` also carry the two numbers separately.

### B.8 What the Hub has and how it differs

- **Hub:** `libs/dotnet/NextGenOS.Devices` (`Printing/EscPos.cs`, `LabelLanguages.cs` for ZPL, TSPL, EPL, CPCL, `PrintService.cs`, `PrinterProfile.cs`, `Transport/Transports.cs`: network, serial, USB device file, system queue and the Windows spooler sent raw) and `Hub.Core/Printing` (`PrinterStore` keeps printer profiles as JSON in `settings`; `HubPrinting` prints a bill to the receipt printer from the **stored document**, kitchen tickets per station, labels, opens the drawer, auto-print). On screen and on paper the bill is `Receipt.razor` (80 mm wide in print; A4 is not styled in `hub.css`); shelf labels and posters print from the browser (`Posters.razor`, 24 labels or 8 cards per A4 page). Printer roles are receipt, label, kitchen.
- **Gaps against the old POS:** (1) no A4/A5 tax invoice with the full line columns, HSN, tax-by-part table and amount in words; (2) no template styles (38 bill and 20 label styles) and no choice per customer; (3) no thermal "customise" file route (rightly); (4) labels carry no MRP, batch, expiry, size or colour (the Hub has no lots, `06-hub-map.md` 3.2); (5) no cipher price label; (6) no label layout designer; (7) no credit note, quotation, estimate, purchase, receipt-voucher or salary-slip print; (8) the printer is chosen per role, not per counter PC (a counter PC model is decision 4's future work); (9) no print-preview choice; (10) no second copy words (ORIGINAL/DUPLICATE/TRIPLICATE).
- **Differences that matter:** the Hub already prints from the saved document and treats a missing printer as a plain message (`HubPrinting.Choose`); the Hub's receipt is a text layout (ESC/POS), the old one is a graphic report. A shop that wants its old A4 look needs HTML/CSS bill templates.
- **White-label (`CLAUDE.md` section 8):** bill words, terms text, brand name, UPI id and logo must come from the customer's profile; every old report file has the old customer's words and tax-invoice wording inside it, which is why they cannot be copied; templates must be data (a layout plus the customer's text).
- **Port in this order (smallest safe):** (1) an A4/A5 tax invoice and a 3-inch/80 mm receipt as two HTML templates fed by one **bill data model** (the 33 line columns minus cost and margin, plus the named values; use the old names as the model's field names so the old reports can be compared); (2) the "printer per counter" key and the plain message when no printer fits; (3) MRP/batch/expiry/size/colour on labels once lots exist; (4) credit note and estimate prints with the same model; (5) a list of 3 to 5 invoice styles stored as data (a style = template + fonts + what to show); (6) a label layout designer only if customers ask. Tests: take TV-B1 to TV-B5 as rules; compare the printed totals with the stored document.

### B.9 Not understood (topic B)

- The captions of the Enable/Disable print-mode drop-down and of the "B-1/B-2" buttons on the label screen.
- What `InvoiceHead.LIDS` ("previous invoice date show") does on the till, and what the parameter named `"0"` carries.
- Whether `T3InchPOS` vs `T3InchPOS1` differ on purpose; what `T3InchPOSD` is (named "D", used by `frmPOSTouch` only).
- The layouts and field lists of all `.rpt` files; the cipher price code; where the layout designer gets its units.
- How `Print_WhatsApp` makes its file (that is topic F).

## C. Backup and restore, database tools

Status of this topic: written. Covers manual backup, restore, "auto backup" (it runs only when someone logs out), the cloud (Google Drive) copy, SQL Server connection setup, and the data-moving tools (Excel import and export, staff import launcher, online synchronisation). Company creation and deletion are in H.

### C.0 The five things to know

1. **Backup is the SQL Server `BACKUP DATABASE` command run by the SQL Server itself.** The program only sends the text `backup database <name> to disk='<path>' with format`; the path is on the **server's** disk, not the PC the person sits at (`B/frmMainMenu.vb:8754`). If SQL Server is on another PC, "Save as" shows that PC's disks only by luck of the shared drive letters. The Hub's data is one file the program can copy itself.
2. **"Auto backup" is not automatic in time: it runs only at logout.** There is no timer. Closing the main window is blocked with "Please Logout the application" (`B/frmMainMenu.vb:8915`), so the backup is tied to the logout menu. A shop that switches the PC off without logging out has no backup that day.
3. **The fixed place is `D:\SBPE_DATA\`.** One path in the code is the drive D: and a folder named after the older vendor (SBPE). A PC with no D: drive gets an error box at every logout (`B/frmMainMenu.vb:8788`, `13829`). **Do not port the name or the drive.**
4. **The cloud backup sends the whole database to a Google Drive.** Through a compiled library `GDClient.dll` that is **not in the repository** (`SmartAvenue99 POS.vbproj:114`, `Original_Binaries\GDClient.dll`). Whose Drive account it is, and the key it uses, are inside that library: a secret is stored there and cannot be read here. That is every sale, customer, supplier and price leaving the shop (compare `CLAUDE.md` section 15 and decision 11). It must be off unless the owner turned it on; in the old program it is a status in one table.
5. **Restore overwrites without a safety copy.** It forces the database to single-user mode (throwing every other connection off, `ROLLBACK IMMEDIATE`) and restores `WITH REPLACE` from any `.bak` file chosen, after one yes/no warning that the names "should be the same" (`B/frmMainMenu.vb:10956-11010`). It takes no copy of the current data first, does not check that the file is a backup of this shop, and does not verify the file. **The Hub must do the opposite** (decision 11: a few clicks, a copy first).

### C.1 What a person sees

| Screen or menu | What it does |
|---|---|
| Menu: Backup | A save-file dialog (file name = database name + ".bak"), then the server writes the backup there; writes "Sucessfully Performed the Backup" to `Logs`. |
| Menu: Restore | Warning, open-file dialog (`*.bak`), restore as above; then reads the company name again and updates the master list. Refused in "Trial" mode (the company name shown is "Trial"). |
| Auto Backup Configuration (`frmAutobackup`) | One row: destination folder path (a "Select Folder" button), "Auto Offline Backup Status" (Enable/Disable), "Auto Cloud Backup Status" (Enable/Disable). Save, Update, Delete, New. Only one row is allowed ("Record Already Exists, please update the information only", `B/frmAutobackup.vb:666`). |
| Menu: Cloud Backup Management (c40) | Needs internet and not "Trial" mode; opens `FrmGDClientSample`, a list of the shop's backups on the Drive (with a browse button and a grid), the screen from which a cloud restore (`Restoredata`) is started. Not read in detail (its logic is inside `GDClient.dll`). |
| SQL Server Setting (`frmSqlServerSetting`) | Server name (a "Search Servers" link lists servers on the network), SQL user name, SQL password, "Test Data Base Connection", "Save SQL Server Setting". Writes `SQLSettings.dat` next to the program: three plain lines, server, user, password. A secret is stored here. |
| Staff import launcher (`frmPostImport`) | Labelled "This page only for [the company's name] staff software updation purpose": seven buttons that open the Excel import screens for category, sub-category, customers, suppliers, products, customer outstanding, supplier outstanding. |
| Excel import and export | `frmExportImportExcel_Customers`, `_Suppliers`, `_Salesman`, `_OpeningStock`, `_ProductsRecord` (+`1`), `frmImportPro` (products): each has "Download Sample Format", upload an `.xlsx` or `.xls` (the customer, supplier, salesman, opening-stock and product screens use the ClosedXML library for `.xlsx` and an OLE DB driver for old `.xls`, which need no Excel; **only `frmImportPro` (products) uses Microsoft Office interop, so Microsoft Excel must be installed for that one**), a grid to check, then save. The two outstanding imports ask for the `sadmin` password first (A.6). |
| Manual Data Synchronization (`frmAuto_Migrate`, with the engine `MigratePendingRows` in the same file and a near-copy in the main menu, `B/frmMainMenu.vb:10120` area) | Admin only. "Start/Stop Auto Data Synchronization" and a "Last synchronization (date and time)". It copies changed rows of many tables from the shop's SQL Server database to a **second, online SQL Server database** (the `Online_DBName` of the shop in the company master list, reached through `RaintechMaster_Online_connection`), matching rows by a `SyncGuid` column and a `Version`, marking local rows `is_remote = 1`, and deleting remote rows whose guid is no longer local (`B/frmAuto_Migrate.vb:371-580`). A table `AutoMigrationControl(ID, IsEnabled, UpdatedOn, UpdatedBy)` holds the on/off. Part of the Android-app and multi-branch feature (c36); see F and H. |
| Google Sheet setting and report (`frmGSheet_Setting`, `frmGSheet_Report`) | Spreadsheet id, "IsEnabled", a G_Id; a report called "Google Sheet Customer" with a From date. It sends customer data to a Google Sheet. See F. |
| Logs (`frmLogs`) | The audit list (A.8). |

### C.2 Tables

| Table | Columns | Meaning |
|---|---|---|
| `Autobackup` | `ID, c1, c2, c3` | `c1` = destination folder, `c2` = "Enabled"/"Disabled" for the offline backup, `c3` = same for the cloud backup. Read into the main menu's text boxes `TextBox1` to `TextBox3` at sign-in (`Autobackupstatusdisplay`, `B/frmMainMenu.vb:12543`). The screen's own switch for each is a drop-down with "Enable"/"Disable" but the code compares with "Enabled": the saved value must therefore be the word "Enabled" (how the drop-down value turns into that word was not followed). |
| `AutoMigrationControl` | `ID, IsEnabled, UpdatedOn, UpdatedBy` | On/off of the online synchronisation (one row, `ID = 1`). |
| `GSheet_setting` | `ID, spreadsheetId, gid, IsEnabled` | The Google Sheet that receives customer rows; only one row is enabled at a time (`B/frmGSheet_Setting.vb:510`, `586`). |

### C.3 The flows, step by step

**Manual backup** (`B/frmMainMenu.vb:8754-8785`): read the database name from `TempDBSettings.dat`; show a save dialog; if the person picks a file, run `backup database <name> to disk='<file>' with format`; write a `Logs` line and a message. The database name and the file name are put into the SQL text by joining strings; a file name with a quote in it breaks or changes the command. The database name comes from a file, not typed, so it is not an injection source; the file name is. **Fix** (use the Hub's own copy; parameters).

**Logout, two variants.** Two main-screen layouts have two near-copies of the logout (`btnTA0_Click` at `:11576` and `btnAT0_Click` at `:13722`). Both first ask "Do you really want to logout from application?". Then:

| Variant | Offline status | Cloud status | What happens |
|---|---|---|---|
| A (`:11576`) | not "Enabled" | any | Run the cloud step if the cloud is enabled (`cloud()` checks its own status); ask "Do you want take offline backup database before logout?"; if yes, `Backup()` (a save dialog). Then exit. |
| A | "Enabled" | not "Enabled" | `autoBackup()`: write `D:\SBPE_DATA\<db>.bak` silently. Exit. |
| A | "Enabled" | "Enabled" | the cloud step only (`cloud()`: write to `<program folder>\SBPE_DATA\`, run `icacls ... /grant Users:(OI)(CI)RW` on that folder through `cmd.exe`, back up, upload to Drive, show the file id, then **delete every file** in `D:\SBPE_DATA\`). No folder copy. |
| B (`:13722`) | any | "Enabled" and internet | `cloudbackup_anil`: empty `D:\SBPE_DATA`, back up there, upload, show the file id, empty the folder again; then also write the offline copy to the configured folder (`TextBox1`, name `<db>.bak`, creating the folder if missing). |
| B | "Enabled" | not "Enabled" | the offline copy to the configured folder. |
| B | "Enabled" | no internet | ask first, then the offline copy. |

Every offline copy file has the same name (`<db>.bak`), so each logout **overwrites yesterday's backup**: there is no history of backups, only the last. A bad day's data can replace a good backup.

**Restore** (`:10956`): described above. A second form of it (`Restore1`, `:11005`) reads the server's default data path (`SERVERPROPERTY('InstanceDefaultDataPath')`) so the restore can move the files there, which suggests restoring a backup made on another PC; and a third (`Restoredata`, `:11062`) is the "cloud restore" without the trial check and without updating the master list.

**Connection setup** (`frmSqlServerSetting`): test opens a connection with the typed server, user and password to `master`; save writes the three lines to `SQLSettings.dat`. `CreateDB` (a separate sub) can make the demo database using Windows login (`Integrated Security=True`). The connection string for each later statement is rebuilt from these files each time (`B/ModCS.vb`).

**Excel import** (for example `frmImportPro`): ask for a file, refuse anything but `.xls`/`.xlsx`, read it with Excel, check each row, show errors in a list, then insert. The detailed column maps are in the screens' "sample format" files; not read.

### C.4 Quirks and probable bugs (keep or fix?)

1. Logout-only backup; one file overwritten each time; server-side path. **Fix:** the Hub makes a dated copy on a schedule to a place the owner chooses, and keeps several (decision 11: every night).
2. `D:\SBPE_DATA` and the delete-all of that folder after upload (it removes any other file a person put there). **Fix.**
3. `icacls ... grant Users` gives every Windows user write access to the backup folder (`B/frmMainMenu.vb:8830`; the `runas` setting is ignored because `UseShellExecute = False`, so it works only if the program already runs as an administrator). **Fix:** never loosen folder rights.
4. Cloud copy goes to an account hidden in a binary. **Fix:** off by default; when the owner turns it on, say in plain words what goes out and where, encrypt it, and keep the key with the owner (decision 11; `CLAUDE.md` section 15).
5. Restore: no copy first, no verify, no check of which shop the file belongs to, kicks everyone off. **Fix.**
6. One import screen (`frmImportPro`) needs Microsoft Excel on the PC (Office interop); the others use ClosedXML and OLE DB. **Fix:** read `.xlsx` with a library that does not need Office (the Hub already reads and writes CSV for reports; check the licence of any library before adding, CLAUDE.md section 3).
7. Errors are shown as a raw message box with the SQL error text. **Fix** (plain words).
8. The status words "Enable"/"Disable" in the drop-down and "Enabled" in the comparison. **Not understood** how they are joined.

### C.5 Worked test examples (by hand; none run)

- **TV-C1 (backup command).** Database name `ShopA` (from `TempDBSettings.dat`), chosen file `E:\Back\ShopA.bak`. Text sent to the server: `backup database ShopA to disk='E:\Back\ShopA.bak'with format` (no space before `with`; SQL Server accepts it). The command runs on the server: the file lands on the server's E: drive.
- **TV-C2 (the second day).** Offline status "Enabled", folder `F:\Safe`: Monday logout writes `F:\Safe\ShopA.bak`; Tuesday logout runs the same statement `WITH FORMAT`, which replaces the media set, so Monday's backup is gone and only Tuesday's remains.
- **TV-C3 (D: missing).** Offline "Enabled", cloud "Disabled", variant A, PC without D: the statement `backup database ShopA to disk='D:\SBPE_DATA\ShopA.bak'` fails on the server; the program shows the server's error text and still logs out.
- **TV-C4 (restore).** The person restores `old.bak` made from database `ShopB` while connected to `ShopA`: the program only shows the "names should be the same" warning; it then runs `RESTORE DATABASE ShopA FROM disk='...' WITH REPLACE`. If `old.bak` holds a different company, `ShopA` now holds the other company's data and the master list's company name is updated from it.
- **TV-C5 (what leaves the shop).** Cloud status "Enabled" and internet present at logout: a full copy of the database, named `<db>.bak`, is uploaded; the number of rows is whatever the database holds (all sales, customers, suppliers). Nothing of this is filtered.

### C.6 What the Hub has and how it differs

- **Hub:** only a safety copy before a schema update (`VACUUM INTO`, `shop.db.before-update-<from>-to-<to>.bak`, `BackupNow(label)` exists in `HubDb`), a rollback tool for the person who looks after the PC, and CSV export of reports. **No nightly backup, no restore screen, no history, no "is the last backup good?" status** (decision 11: Not built). `docs/old-programs/06-hub-map.md` 3.4 says the same.
- **Differences that need the owner's word:** the old program uploads to a Google Drive when asked; decision 11 says the online copy is **encrypted, off until the owner turns it on, with a plain-words notice** and the key stays with the owner. The old cloud copy is the opposite on all four points.
- **Port in this order (smallest safe):** (1) a "Back up now" button and a "Restore from a copy" screen in Settings for the owner, using `HubDb.BackupNow` and a restore that first makes a copy of the current file and checks the chosen file opens as a Hub database of the same shop (tests: back up, change, restore, data is as at backup; restore of a wrong file is refused); (2) a nightly job through `HubApp.Upkeep` to a folder the owner picks, keeping the last N copies with the date in the name, and a status on the Today page ("last backup: ... worked/failed"); (3) the optional encrypted online copy (not before the owner decides the provider); (4) Excel/CSV import of items and customers for onboarding (the old "staff import launcher") only as part of the move-from-old-POS tool (`docs/old-programs/DATABASE.md`).

### C.7 Not understood (topic C)

- Where `GDClient.dll` gets its Google account from, and how files are named and listed in Drive; what the "Cloud Backup Management" screen lists.
- Whether `frmMigratedb_auto` (1,166 lines) and `frmFileupload` are used at all (no caller found in the main menu).
- What the helper programs `MoneyLeaf.exe` and `RECEIPT_PRINTER.exe` are: the logout code kills any process by those names and deletes the files from the program folder (`B/frmMainMenu.vb:11570-11600`). They are not in this repository.
- How the Enable/Disable drop-down turns into the word "Enabled" in `Autobackup`.
- The exact Excel column maps of the import screens (the "sample format" files).

## D. Shortcut keys and the till's settings screens

Status of this topic: written. Covers the function keys of the four till screens, the shortcut help list, and every settings screen that changes how the till behaves (what it is, its table and column, its effect). The tax and total arithmetic that some of these switches drive is in `docs/old-programs/01-selling-buying-stock.md`; here only the switch is described.

### D.0 The five things to know

1. **The same key does different jobs in different tills.** F2 is **Save** in the classic till (`frmPOS`) but **Add** in the touch tills (`frmPOSNew`, `frmPOSNewTuch`, `frmPOSTouch`); F12 is **Save** in `frmPOSNewTuch`/`frmPOSNew` but **payment mode** in `frmPOSTouch`. A cashier trained on one till presses the wrong key on another (D.2).
2. **The shortcut "help" list is only a list.** The table `tbl_formwise_shortcut_key(form_name, shortcut_key, details)` is shown by the help button of a till (`frmFormwise_Shortcutkey`); the keys that really work are written in each till's key handler, so the list can disagree with the code (`B/frmFormwise_Shortcutkey.vb:42`, `B/frmPOS.vb:13810`).
3. **There is no settings screen for tax rules; there are about 20 small ones.** Each is a table with one row (or a few) and one or two columns, read when the till opens: round-off, tax mode, default tax mode of new items, default loyalty, default item discount, default category/unit/GST, cursor start field, payment modes shown, invoice code prefix and suffix, cipher price code, product-screen menu switches. Most store the words "Yes"/"No" or "Enable"/"Enabled" as text and compare text (D.3).
4. **Until a row exists, the till uses a built-in default** (round-off No; tax "GST"; invoice prefix "GST" and suffix "<year>/<year>"). Those built-in defaults are India words in code (CLAUDE.md section 8: they must come from a country pack in the Hub).
5. **Several rights are default-deny, which is good.** A Sales Person with no `CashierSetting` row cannot change a line discount, a bill discount, a rate or the invoice date (A.4, D.3 item 1). Keep that default.

### D.1 What a person sees

The settings are spread over the Settings menu (c29) and the main screen. The screens: User Permission Settings (`frmOtherSettings`, cashier rights), Auto Roundoff, Tax Type (`frmTaxSetting`), Prefix and Suffix Invoice Code (`frmInvCode`), Terminal Setting (`frmTerminalSetting`, also in B), Pos Cursor Setting, Multi-payment mode settings, Product Default Setting (`frmProductDefault`), Cipher Code Setting (`frmCipherSetting`), the product-menu switches (`frmProductSeting`, `frmBulkProductSeting`), Loyalty Point Validation (`frmLoyaltyvalid`), Loyalty default (`frmLSetDefault`), Kitchen Section (`frmKitchen_Section`), E-Way Bill settings (`frmEwaysetting`, `frmEwayBillSetting`), SMS and e-mail settings (F), the E-Com configuration (I), System Info (`frmSystemInfo`, a read-only viewer of this PC's processor, motherboard and public IP; "Save to file" writes `temp.txt`; the public IP is fetched over plain HTTP from an outside site, `B/frmSystemInfo.vb:508`).

### D.2 The function keys, till by till (from the key-down handlers)

| Key | `frmPOS` (classic) `:13810` | `frmPOSNew` `:15120` and `frmPOSNewTuch` `:16279` | `frmPOSTouch` |
|---|---|---|---|
| F1 | New bill | New | New |
| F2 | **Save** | **Add** (add the line) | **Add** |
| F3 | Update (a saved bill) | Update | Update |
| F4 | Delete | Delete | **Cash sale** |
| F5 | Get data (retrieve a bill) | Get data | Get data |
| F6 | Print | Print | Print |
| F7 | Scan items | **Cash** (payment row) | Cash |
| F8 | Select salesman | Credit card | Credit card |
| F9 | Customer selection | Debit card | Debit card |
| F10 | Product selection | Wallet | Wallet |
| F11 | Add | Credit customer | Credit customer |
| F12 | Add (second add button) | **Save** | **Payment mode** |
| Ctrl+P | focus the product search box | focus the product box in `frmPOSNew`; in `frmPOSNewTuch` also the product-selection button (Ctrl+P is handled twice) | focus the product box **and** click product selection (two handlers for one key) |
| Ctrl+C | focus the customer box | focus the customer box | focus the customer box **and** click customer selection (two handlers) |
| Ctrl+S | | scan items | scan items |
| Ctrl+B | | select salesman | select salesman |
| Esc | "Do you want to close?" | same | same |
| Others | letters and digits type into the product box while the result list is open (`:16857-17260`) | Ctrl+W webcam, Ctrl+H last-sold history, Ctrl+M, Ctrl+U | Ctrl+Q quantity change dialog, Ctrl+D discount dialog, Ctrl+A |

The table is read from the handlers; `frmPOSNewTuch_Quotation`, `_Service`, `_StockInward`, `_StockTransfer` are copies of the touch till and were assumed to share its keys (not read key by key). The classic till also calls a helper (`RetailCheckoutLayouts.HandleShortcut`, `B/RetailCheckoutLayouts.vb:429`) that only switches tab pages: it belongs to the 2026 look-and-feel rewrap of the recovered program, not to the original and not to port.

### D.3 Every setting that changes behaviour (table, column, effect)

| # | Setting (screen) | Table and column | Values | Effect |
|---|---|---|---|---|
| 1 | Cashier rights (`frmOtherSettings`) | `CashierSetting(ID, UserID, ATEID, ATGBD, ATCR, INVD)` | "Yes"/"No" each | `ATEID` allow to edit item discount, `ATGBD` allow to give bill discount, `ATCR` allow to change rate, `INVD` allow to change invoice date. Only users of type Sales Person are offered (`:263`). The till reads them at open (`GetSalesPersonSettings`, `B/frmPOS.vb:15869`) and enables or disables the discount box, the bill-discount box, the rate box and the date picker (`CheckValidations`, `:14793`); Admin and Moderator are always allowed. No row, nothing allowed. |
| 2 | Auto Roundoff | `Autoroundoff(ID, c1)` | "Yes"/"No" | One row only (`Select count(*) ... Having count(*) >= 1` blocks a second, `B/frmAutoRoundoff.vb:491`). "Yes" ticks the till's round-off box (`frmPOS.vb:8020`); the total is then rounded to a whole number, half to even (01 section 1.5). |
| 3 | Tax Type | `Setting(PurchaseTax, SalesTax)` | "GST" / "NON GST" | A shop-wide mode for purchases and for sales; "NON GST" puts zero tax on every line and uses its own invoice series "SINV-" (01 section 1.2). Also a "Select GST/NON GST" pop-up (`frmGstNonGst`) in the tills. |
| 4 | Default tax type of new items (`frmProductDefault`) | `Defaulttaxtype(stax_type, ptax_type)`, one row `id = 1` | "Inclusive", "Exclusive", "Exempt GST", "No Taxes" | What a new product gets as its sale and purchase tax mode (`B/frmProductDefault.vb:475`, `835`, `848`; the quick-add product in the touch till reads them, `frmPOSNewTuch.vb:28661`). |
| 5 | Default loyalty of new items | `tbl_loyalty_setting(id=1, mode, points)` | mode "per" or "point"; points a number | The `Product.loyality_mode` / value a new product starts with (`frmProductDefault.vb:866`, `frmPOSNewTuch.vb:28676`, and the Excel product import). "per" = percent of the line, "point" = points per unit. Compare 02 section A1.6. |
| 6 | Loyalty point validation | `Lpointstatus(ID, c1, c2, c3)` | `c1` point (percent of the bill), `c2` status "Enable"/..., `c3` "Calculate on" (WITH GST or not) | The older, percent-of-bill scheme used by the classic till (`B/frmPOS.vb:7438`). One row only. |
| 7 | Default discount | `tbl_DiscountDefault(id=1, Rate)` | a percent | The discount a new product starts with (`frmProductDefault.vb:434`, `883`). |
| 8 | Default sub category, unit, GST rate | `SubCategory.IsDefault`, `UnitMaster.IsDefault`, `TaxCat.IsDefault` | "Yes"/"No" | Exactly one row of each is "Yes" (the screen sets all to "No" and then one to "Yes", `:700-726`; the unit is matched by its text). The product entry screen pre-fills them (`frmProduct.vb:5887`). Note the three statements are sent as one text with two commands, not in a transaction. |
| 9 | Bill style / barcode style default | `BillPreview` / `PosPrinterSetting.BillStyleId`; `BarcodePreview.is_active` (and `GorillaBarcodePreview` for a second product form) | style id | Which bill and label template is used (B.3, B.5). |
| 10 | Pos Cursor Setting | `tbl_form_cursor(id, form_itemname, is_default)` | "Product Name", "Barcode", "Customer", "Mobile Number" | Which box has the focus when a touch till opens (`cursor_default`, `frmPOSNewTuch.vb:16706-16735`). One default at a time. Used by the touch tills only. |
| 11 | Payment modes shown | `tbl_BillPaymentMode(id, Mode_Index, paymentmode, amount, status)` | `status` 1/0 | The multi-payment screen lists the modes with `status = 1` in `Mode_Index` order, then two fixed rows "By Return" and "Change" (`B/frmMultiBillPayment.vb:184`, `frmMultiPaymentModeSettings.vb:81-120`). A tick in the settings grid saves at once. Saving also reloads the payment screen. The modes themselves (16 of them, 01 section 2.1) are rows in this table. |
| 12 | Invoice prefix and suffix | `Invcode(ID, Code, c1 ... c21)` | text | 11 document types x (prefix, suffix) = 22 values. By the code: `Code` = sale prefix, `c1` to `c9` = prefixes of purchase, sale return, purchase return, quotation, purchase order, receipt, payment, income, expense (expense prefix `c9` read by `frmBrokerCalc.vb:262`), `c10` = sale suffix (`frmPOS.vb:7970`), `c11` to `c19` = the matching suffixes (expense suffix `c19`), then `c20` and `c21` by elimination the estimate prefix and suffix. **The mapping of `c1` to `c8` and `c11` to `c18` to document names is from the on-screen order and the two columns that were checked; not checked column by column.** |
| 13 | Terminal and printer | `PosPrinterSetting` | see B.2 | Printer, drawer, scale, displays, UPI id, brand name, "show images" per PC. |
| 14 | Cipher price code | `CipherCode(ID, c0 ... c14)` | `c0` to `c9` the code character for digits 0 to 9; `c10`, `c11` retail and wholesale price +/-; `c12`, `c13` the first and second dummy numbers; `c14` Activate "Yes"/"No" | Builds the coded price printed on cipher labels (D.5). |
| 15 | Product-screen menu switches | `product_menu_setting(menu_name, is_active)`, `Bulk_product_menu_setting(menu_name, is_active)` | 1/0 | Which fields or buttons the product entry and the bulk editor show. The bulk editor reads the flag **inverted** (`case when is_active=0 then 1 else 0`, `B/frmProductBulkUpdate.vb:768`). |
| 16 | Kitchen / order sections | `Kitchen(KitchenName, Printer, IsEnabled)`; `Product.Kitchen` | "Yes"/"No" | A product's section and the printer for its slip (B.3). A shared network printer is typed as `\\Server\Printer`. |
| 17 | E-way bill | `EwayBill(c1)` "Enable"; `EwayBillAPISetting(ID, API URL, IsEnabled, IsDefault, Username, password)` | | Turns the e-way bill field on the till and keeps the API address and **login** of the government-portal service. A secret is stored here (the grid even shows the password column). See `docs/old-programs/03-india-tax-and-staff.md`. |
| 18 | Auto backup | `Autobackup` | | C.2. |
| 19 | User control (51 switches) | `UserControl` | | A.4. |
| 20 | Language | `Language_set`, registry `DefaultLanguage` | | E. |

### D.4 Quirks and probable bugs (keep or fix?)

1. **Keys differ by till** (D.0 item 1). **Fix:** one key map for the Hub's sell screen, shown on the screen, stored as data so a customer can change it (CLAUDE.md section 8: a visible hint like "F2" is customer-visible).
2. **Settings kept as the words "Yes"/"No"/"Enabled"/"Disable"** and compared with text, in several spellings (C.4 item 8). A typo or a changed word silently turns a setting off. **Fix:** a real on/off value.
3. **One-row tables enforced by a count check in the screen, not by the table.** Two screens open at once can add two rows; which one wins when reading (`Read` takes the first row returned, with no `ORDER BY`) is not defined. **Fix.**
4. **Defaults for the shop are India words in code:** "GST", the suffix built from the two year boxes ("25/26" style), the NON GST series "SINV-". **Do not copy;** the Hub gets them from the country pack and the customer's profile.
5. **`Setting`, `Defaulttaxtype` and the others are read on every till open** with a new database connection each time and no cache, with errors shown as raw message boxes.
6. **The "particulars", "language" and "copy" tick boxes of the till are not saved settings** (they are per-bill toggles), so a cashier sets them again every bill.
7. **Cipher code can lose information** (D.5, TV-D4).
8. **Renaming a user detaches the user's `CashierSetting`** (it is keyed by the user id text, A.9 item 7).

### D.5 The cipher price code, step by step

Used on cipher labels so the customer cannot read the shop's price code. When "Activate" (`c14`) is "Yes", the retail code starts from the selling price plus the first dummy number (`c12`), and the wholesale code from the wholesale price (the column `Product.ReorderPoint`) plus the second dummy (`c13`) (`B/frmProduct.vb:5519-5525`, `5678-5681`; a rounded variant adds the dummy to `Round(price)`, `:5602`). With a tick box "Num Code / Char Code" the text is then passed through a loop (`:5535-5600`): up to 1000 times, look for the first digit in the order 0, 1, 2, ... 9 that is still in the text and replace **one** occurrence of it with the code character stored for that digit; stop when no digit is left. Result saved in `Product_OpeningStock.RCipher` and `WCipher`. If the table has no row, each digit maps to itself (0 to 0, ..., 9 to 9) and "Activate" is "No".

### D.6 Worked test examples (by hand; none run)

- **TV-D1 (invoice number).** Prefix `Code` = "INV", suffix `c10` = "25/26"; the last row of `SaleGST` has ID 41. Next sale number = "INV" + "-" + "0042" + "-" + "25/26" = `INV-0042-25/26`. With no `Invcode` row: prefix "GST", suffix "<F1>/<F2>" (the two year boxes of the till), so `GST-0042-25/26` if the boxes say 25 and 26. The number is `ID + 1`, padded to 4 digits up to 9999 (`GenerateIDGST`, `B/frmPOS.vb:7887-7940`; at 10 000 and above the padding code was not read, assumed none). For NON GST: `SINV-<NoTax counter>-<suffix>`.
- **TV-D2 (cashier rights).** Sales Person "ravi" has a row with `ATEID = "Yes"`, `ATGBD = "No"`, `ATCR = "No"`, `INVD = "No"`: the line-discount boxes are editable; the bill-discount box, the rate box and the invoice date are disabled. With no row: all four disabled. An Admin: all four enabled.
- **TV-D3 (round-off switch).** `Autoroundoff.c1 = "Yes"`, total 100.50: rounded 100.00 (half to even), round-off -0.50, grand total 100.00. With "No" or no row: 100.50. (The Hub rounds half up and would give 101.00, 01 vector R.)
- **TV-D4 (cipher).** Mapping 0 to "Z", 1 to "A", 5 to "X", others default; price 150 with Activate "No": text "150". Iteration 1 replaces the "0": "15Z"; iteration 2 "1": "A5Z"; iteration 3 "5": "AXZ". Result `AXZ`. **Loss case:** mapping 1 to "5" and 5 to "X"; price 15: iteration 1 (digit 1) gives "55"; iteration 2 (first "5") gives "X5"; iteration 3 gives "XX". The price 15 and the price 55 both give `XX` and the code cannot be read back. **Fix:** map all digits at once (one pass) and refuse a code that uses a digit.
- **TV-D5 (cursor).** `tbl_form_cursor` has "Barcode" as default: a touch till opens with the cursor in the barcode box. With none marked default: no focus is set.
- **TV-D6 (payment modes).** Modes with `status = 1` are listed in `Mode_Index` order; the two rows "By Return" and "Change" are always appended and read-only (`:184-205`).

### D.7 What the Hub has and how it differs

- **Hub:** one JSON object `ShopSettings` in `settings` row `shop` (`Shop/ShopSettings.cs`): `PricesIncludeTax`, `TaxRegistered`, `RoundTotal`, `AllowNegativeStock`, `CashierDiscountPctMilli` (the biggest discount a cashier may give, as a percent of the bill; owners and managers have no limit), `ReceiptFooter`, loyalty (`LoyaltyOn`, `LoyaltyDefaultMode` "none"/"per"/"point", value, point value), `PaymentMethods`, feature switches, vocabulary and rate overrides. Settings tabs: Business, Tax, Parts and words, Look, Printers, People, AI, Licence, Activity. Printers as profiles (B.8). Roles are fixed (A.11).
- **Hub has no function-key map** on the sell screen (key handlers exist only on search and scan inputs).
- **Differences:** the old rights are four yes/no flags per Sales Person; the Hub has one limit (a percent) for every cashier, and no rate-change or back-date right (a Hub bill is dated by the server clock). The old switch "NON GST" is the Hub's `TaxRegistered = false`. The old default tax mode per item maps to the per-document `PricesIncludeTax` (the Hub has no tax mode per item, `06-hub-map.md` 4.2). Default category, unit, GST and discount for a new item have no Hub setting (the Hub's item form has its own defaults from the pack). Invoice prefix and suffix: the Hub numbers documents itself (`06-hub-map.md` 4.5); a customer-chosen prefix and a year suffix are not offered.
- **Port in this order (smallest safe):** (1) three more permissions or limits: change price, back-date, bill discount beyond the percent limit, with tests that a cashier without them is refused **in the service**; (2) a keyboard map for the sell screen as data in the profile, with a hint line on screen, one map for all counters; (3) invoice prefix/suffix per document type as customer settings with the country pack's neutral default (no "GST"); (4) a "starting values for a new item" screen (tax mode, discount, loyalty, unit, category); (5) the cursor start field and the list of payment methods shown, both already near what the Hub has; (6) drop the cipher code unless a customer asks, and if so, one pass per digit and a check that the code uses no digit.

### D.8 Not understood (topic D)

- The exact mapping of `Invcode.c1` to `c8` and `c11` to `c18` to document types (checked only the sale and expense columns).
- Whether `Setting` has one row or one per company, and its column order (read by name in other studies).
- The captions and effect of the touch tills' quantity and discount dialogs (`frmPOS_Update`, `frmPOS_Update2`) and of Ctrl+A, Ctrl+M, Ctrl+U.
- Which text the Enable/Disable drop-downs store for the status words (C.4 item 8).
- `frmGodownConfig`, `frmBagBox` (a piece/box chooser), `frmUnitButton` (main unit and alternate unit with a default quantity) were not read beyond their captions.

## E. Language conversion and transliteration

Status of this topic: written. Covers the screen-word translation table, the language chosen at sign-in, the "Language Conversion" screen, the transliteration libraries, and the local-language product name printed on bills.

### E.0 The five things to know

1. **"Language" means two different things here.** (a) **Screen words:** every screen, when it opens, replaces its captions with the words stored for the signed-in language in table `Language_set`. (b) **Local-language product names:** a second name for each product (a transliteration of the English name) that a bill can print instead of the English one. They are separate mechanisms with separate tables and columns.
2. **The screen-word table matches on the exact English caption text.** `Language_set(id, default_lang_eng, other_lang, lang_hin)`: `default_lang_eng` is the English caption as written in code, `other_lang` the replacement, and **`lang_hin` holds the language name (for example "Hindi"), not Hindi text**. A control changes only if its current `Text` equals a stored English caption character for character (`B/frmUserControl.vb:1073-1128`, the same method is copied into 227 forms). Message-box texts, drop-down items, tool tips, grid cell values and every report (`.rpt`) are never translated.
3. **In the recovered source the transliteration does nothing.** Both libraries are stubs: `DevNet.Translitration`'s `DoWork` returns the input word unchanged with `Success = true`; `DevNetTRLN.Transliterator.Translate` returns its text unchanged (`Source/Libraries/DevNet.Translitration/.../Translitration.cs`, `Source/Libraries/DevNetTRLN/.../Transliterator.cs`). The real compiled library is `Original_Binaries\DevNetTRLN.dll`, which is not in the repository, so **what service did the real work, and what data it sent out, is not known**. The code checks for an internet connection before converting, which suggests an online service. Not verified.
4. **It is transliteration (sound written in another script), not translation.** "Sale" would become the sound of "Sale" in Devanagari, not the word for selling. The response object has the fields `at, error, input, result[], success`, the shape of an online input-method service. A shop that wants real translated words has to type them (or import them from Excel).
5. **All the language names are Indian.** The enum has 21 (Assamese, Bangla, Boro, Gujarati, Hindi, Kannada, Kashmiri, Konkani, Maithili, Malayalam, Manipuri, Marathi, Nepali, Oriya, Panjabi, Sanskrit, Sindhi, Sinhala, Tamil, Telugu, Urdu); the product screen offers 9 (Hindi `hi`, Bengali `bn`, Gujarati `gu`, Marathi `mr`, Tamil `ta`, Telugu `te`, Kannada `kn`, Malayalam `ml`, Punjabi `pa`); the conversion screen starts with "Hindi" selected (`B/frmConvert_Language.vb:373`). CLAUDE.md section 8: no default may assume India or Hindi.

### E.1 What a person sees

| Screen | File | Purpose |
|---|---|---|
| Sign-in language box | `frmLogin` (`cmbLang`) | Lists `SELECT DISTINCT lang_hin FROM Language_set` plus "ENGLISH" (added by code, selected by default, `B/frmLogin.vb:677-707`). The choice is kept in `GlobalVariables.LoggedInLang_code` and, **only when an Admin signs in**, saved to the Windows registry (`HKEY_CURRENT_USER\Software\<product>`, value `DefaultLanguage`) and read back next time (`:595`, `665-674`). For other roles the box starts at "ENGLISH" again each time unless the registry value is already there. |
| Language Conversion | `frmConvert_Language` (menu entry, `B/frmMainMenu.vb:14422`) | A language box (all 21), a search box, two lists: English captions and the other-language text; links "Convert Lang" and "Store Marked Data"; "Import" and "Export Excel" (ClosedXML); a bottom list of everything stored (`loadAll`); a pair of boxes (English, other) with Save/Update for typing one entry by hand. |
| Product entry: "Convert Lang" link | `frmProduct` (and the two bulk editors) | A language drop-down of the 9 above and a link that puts the "converted" product name into the box `txtFeatures`, saved as `Product.Description` (`B/frmProduct.vb:7062-7090`, `3623`, `7377`). Needs internet. Refuses an empty name. |
| Bill language tick box | the tills (`chkLang`) | When ticked, the bill's name column shows the local name instead of the English one (B.3). |

### E.2 Tables and columns

| Table.column | Meaning |
|---|---|
| `Language_set.default_lang_eng` | The English caption exactly as in the program. Primary lookup key. |
| `Language_set.other_lang` | The text to show. |
| `Language_set.lang_hin` | The **language name** (misleading name; "hin" is a leftover of the first language, Hindi). |
| `Product.Description` | The product's **local-language name** (not a description; the product form's box is called `txtFeatures`). Grid column 19 of the till holds it; the bill reads it when `chkLang` is ticked. |
| Registry `DefaultLanguage` | The last language an Admin signed in with, per Windows user and per PC. |

The seed rows of `Language_set` are not in the repository (the database scripts are missing), so which captions and languages the real program shipped with is not known.

### E.3 The flows, step by step

**Applying the words** (`Convert_Language` in each form): read all rows of `Language_set` where `lang_hin` equals the signed-in language (the value is joined into the SQL text, `...WHERE lang_hin= '<name>'`; it comes from a drop-down filled from the same table, so not typed by a person); build a dictionary English to other (the **first** row wins when an English caption appears twice); walk every control of the form: for labels, buttons, group boxes, check boxes and radio buttons whose `Text` is a key, replace it; then do the same for the column headers of grids and list views and the pages of tab controls (`UpdateAllHeaders`, `UpdateDataGridViewHeaders` and the like). With "ENGLISH" there are no rows, so nothing changes. Each form runs this in its own load event; a form that forgot to call it stays English.

**Typing one entry** (`Button1_Click`, `:782-820`): English text and other text both required; if a row id is loaded it is updated (`update Language_set set other_lang=@d1 where id=@d2`), else a new row is inserted with the language of the drop-down. There is no check that the English caption exists in the program, or that the same caption is not already stored for this language.

**Automatic conversion** (`LinkLabel3_LinkClicked`, `:408-480`): needs internet and a chosen language. For each row of the left list: remove the punctuation characters (the slashes, ! @ # $ % ^ & * ( ) _ + = brackets and braces, ; : quotes, | < > , . ? and the back-tick and tilde) and squeeze spaces; look the **original** English text up in `Language_set` by `default_lang_eng` only; if **any** language already has a row for it, skip it; otherwise split on spaces, transliterate every word separately, join with spaces and add a row to the right list. "Store Marked Data" (`Button8_Click`) inserts the ticked rows with the chosen language name. **The left list is filled from `ReceivedDataTable`, which nothing in the recovered code sets** (the only caller is the main-menu entry, `:14422-14429`), so opened from the menu the left list is empty and the automatic route cannot run. The routes that work are typing, Excel import and the search.

**Excel import** (`:640-710`): choose a workbook; the first row is skipped; columns taken by position become `Englsih`, `Other Language`, `Language_code` (sic); for each row the program counts matching rows and then inserts **if the count is `>= 0`**, which is always true, so the duplicate check never works (`:687-695`). Importing the same file twice stores every row twice (harmless on screen because the first wins, but the table grows).

**Local product name on a bill:** in the product screen "Convert Lang" puts the result in `txtFeatures`; saving writes it to `Product.Description` (the insert statement lists `Description` fourth after the sub-category). In the till the grid keeps it in column 19; with `chkLang` ticked the print routine feeds column 19 into the bill's name column instead of the product name (`B/frmPOS.vb:8173` onward, the branch taken when `chkLang` is ticked). **If a product has no local name the name column is empty on the bill.**

### E.4 Quirks and probable bugs (keep or fix?)

1. Caption matching on exact English text: any change of a caption in code silently loses its translation, and a caption used on two screens with different meanings gets one translation. **Fix:** the Hub uses stable keys, not the English text.
2. The same caption can have only one automatic conversion across all languages (the existence test ignores the language). **Fix.**
3. Duplicate check on import never blocks (`>= 0`). **Fix.**
4. Empty local name prints a blank line on the bill. **Fix:** fall back to the normal name.
5. The language chosen is remembered only for Admins and only on that PC and Windows user. **Fix:** a per-person (or per-counter) setting kept with the shop's data.
6. `lang_hin` joined into SQL; low risk (from a drop-down) but **fix** with a parameter.
7. Transliteration is not translation (E.0 item 4); the recovered libraries do nothing. **Do not port the libraries.** An outside service must never be called with product names unless the owner allowed it (decision 10 and CLAUDE.md section 15); a local model or typed names are the safe routes.
8. A bill printed in a local script needs a font and a printer that can draw it; the reports use the Windows fonts of the PC (`Fonts` folder at the top of `apps/pos-desktop` ships some). Not checked per template.

### E.5 Worked test examples (by hand; none run)

- **TV-E1 (apply).** `Language_set` has (Sale, X1, Hindi), (Sale, X2, Tamil), (Sale, X3, Hindi). Signed in as "Hindi": a label with text `Sale` becomes `X1` (the first Hindi row wins, `X3` is ignored). A label `Sale ` (trailing space) or `sale` stays English. Signed in as "ENGLISH": nothing changes.
- **TV-E2 (cleaning).** English caption `Sale Return (Cr.Note)`: cleaned text is `Sale Return CrNote`; the words `Sale`, `Return`, `CrNote` are converted one by one and joined with single spaces; the row stored under the original `Sale Return (Cr.Note)` has no brackets or dot in its other-language text.
- **TV-E3 (stub).** With the recovered libraries `Translate("Rice", "Hindi")` returns `Rice`; `DoWork("Rice", Hindi)` returns success with result `["Rice"]`.
- **TV-E4 (import twice).** A workbook of 3 data rows (plus a header) imported twice leaves 6 rows in `Language_set`.
- **TV-E5 (bill).** Product "Rice" with `Description` = local name Y and `chkLang` ticked: the bill's name column shows Y; with `Description` empty: empty. With `chkLang` off: "Rice".
- **TV-E6 (sign-in).** An Admin signs in with "Tamil": registry `DefaultLanguage = Tamil`. A Sales Person signing in afterwards on the same PC and Windows user finds the box on Tamil too (read from the registry at load) but their own choice is not saved.

### E.6 What the Hub has and how it differs

- **Hub:** screens in plain English. `ShopSettings.VocabularyOverrides` lets the owner rename industry words (singular and plural, for example "customer" to "Member"), `ShopContext.Singular/Plural` read them. Country packs carry currency, tax and time zone. There is **no screen translation, no second name for an item, no language choice**. Decision 21: English first; client wording as a setting; translations country by country, made with AI and checked by a local speaker; no unchecked machine translation on money or tax screens.
- **Differences:** the old program translated captions of the program itself from a shop-editable table; the Hub's rule is that all customer-visible words are the customer's settings and the program's own screens are translated later, per country, under review. The old local product name is a real, useful feature for shops whose customers read another script.
- **Port in this order (smallest safe):** (1) an optional **second name for an item** (kept in the item's loose-facts JSON, so no schema change), a "print second name on bills" option in the shop settings, and a bill that falls back to the normal name when the second name is empty (tests: second name printed when on; fallback when empty; off prints the normal name); (2) the list of offered languages comes from the country pack, with no Indian default; (3) later, when a country opens, screen translations as keyed resource files (not English-text matching) reviewed by a local speaker; (4) transliteration only through a local model or by typing, never an outside call without the owner's yes.

### E.7 Not understood (topic E)

- What the original `DevNetTRLN.dll` and `DevNet.Translitration` really did, and where they sent text.
- Who is meant to fill `ReceivedDataTable` of the conversion screen (perhaps an older menu path).
- `Configuration.defaultLanguage()` (used for the label of the conversion screen; the class is in another library, `DevNetSR`, not read for this).
- The seed contents of `Language_set` and whether the shipped database had any rows.
- Whether report templates have language variants (none found by name).

## F. Messages: WhatsApp, SMS, email, chat, broadcast

Status of this topic: written. Covers SMS, the two WhatsApp routes, e-mail (send, bulk, inbox), the AI helper that drafts e-mails, the customer "mobile notification" feed, the LAN chat and the contact book. For each: what a person sees, the tables, **what leaves the shop, to whom, through which service, and which customer data goes**, and how that compares with `CLAUDE.md` section 15 and `docs/PLATFORM-DECISIONS.md` decisions 4 and 10. Two of the three messaging libraries in the recovered source are empty stand-ins (F.0 item 3), so the real behaviour of one route cannot be seen.

### F.0 The five things to know

1. **Every message route sends the customer's phone number and name outside the shop, and most also send amounts.** A sale message holds the customer's name, invoice number, date, the amount and the shop name; a debtor message holds the **amount the customer owes**; a WhatsApp bill is the **whole invoice as a PDF** (customer, items, prices, tax). Nothing is marked with a data class, nothing asks the customer's consent, and nothing records who was sent what (only the SMS text is logged, without the number).
2. **The WhatsApp "API" route uploads the bill PDF to a web server over plain FTP and gives the sender a public link.** `clswhatsApp.CreateFtpFolder` copies the PDF to a temporary folder, uploads it with the FTP user and password stored in table `WappApi`, builds a link from the stored file address plus a folder named after an instance id or token, and asks a relay service to fetch that link and send it on WhatsApp (`B/clswhatsApp.vb`). The code does not delete the uploaded file afterwards (not found). Plain FTP sends the password and the file unencrypted.
3. **The three recovered messaging libraries are not alike.** `DevNetWP` is real, readable code: a client for a WhatsApp relay service reached by web requests, with the library's built-in base address pointing at the previous vendor's own server (not copied here) and a built-in access token (a secret is stored here). It also registers, for every new connection, a **public webhook-testing website** as the place incoming events are posted (`Source/Libraries/DevNetWP/.../clsWhatsapp.cs:87`): anyone who knows that address could read what the relay posts there. `DevNet.WhatsApp.V2` (the "Chrome" route) is an **empty stand-in**: `CurrentState` always says `READY` and `Send` always returns `Success` without sending anything (`Source/Libraries/DevNet.WhatsApp.V2/.../WhatsApp.cs`); the real compiled library is not in the repository, so how it worked (it used the Chrome driver library, `DevNet.ChromeDriverManager`, to drive WhatsApp Web on the shop PC after a QR sign-in) is inferred from names only. `DevNetFB` (Firebase) is real code (1,925 lines) and is the channel of the owner-phone and customer-phone feeds.
4. **Everything that needs an address or a key reads it from tables or from a file next to the program, in plain text.** The SMS web address (with a gateway user and password inside it), the WhatsApp text and media addresses (with the token inside), the FTP password, the e-mail password (`EmailSetting.Password`), the OpenAI key (`tbl_api_setting`), the second WhatsApp service's id file (`2ndW.txt`). A secret is stored in each of these places. Cloud addresses and keys of the Firebase feeds were already moved out of the source into `cloud.json` in the licence folder by the owner's earlier edit (`libs`/`licensing/clients/dotnet/NextGenOS.Licensing/CloudSettings.cs`: nothing set means "not configured", which the programs treat as no internet), which is the right pattern.
5. **Messages are in English words with Indian money words fixed in code.** "Dear Sir/Madam, <name>, Thank you for purchasing from us. Your Invoice No. ..., Date. ..., Amount is Rs.<amount>, Best wishes from <shop>." and "Your pending amount is Rs. ...". The country code box defaults to "+91". CLAUDE.md section 8: all of this must be the customer's own template and the country pack's currency.

### F.1 What a person sees

| Screen | File | Purpose |
|---|---|---|
| SMS Setting | `frmSMSSetting` | The web address of an SMS gateway with two place-holders `@MobileNo` and `@Message` (the on-screen example is a gateway app on the same PC at `127.0.0.1`, with a user and password written inside the address); tick boxes IsEnabled, IsDefault, "Auto SMS Enabled". |
| SMS sender | `frmSendSMS_Sales`, `frmSendSMS_Services` | After a sale or a service: a mobile number box and a message box filled with the standard text; Send. |
| Bulk SMS to debt customers | `frmCreditCustomerSMS` | Tick customers with an amount owed, an editable ending sentence (default "Please pay as soon as possible."), send to all ticked. |
| Loyalty SMS | `frmLoyaltySMS` | Points message to a customer by SMS or WhatsApp (both the SMS address and `WappApi` are read). |
| Offer message | `frmOfferMessage` | Stores one offer text (`OfferMsg.Msg`) used by the offer sender. |
| WhatsApp configuration | `frmWAppAPIServer` (relay route, with FTP and API addresses, Initialize, Reconnect, Reset instance, Reboot instance, Logout) and `frmWAppAPIServer2` (browser route: "Download Chrome Driver", Headless, Initialize, Terminate; status "Engine : Not Ready", "Sender Id") | Sets up the route; the main menu also shows "WhatsApp : Ready". |
| WhatsApp instant message | `frmWhatsappMessage` | Type a number and a text, send. |
| Bulk WhatsApp documents | `frmBulkWhatsappDoc` | Lists customers (all except the walk-in "Cash") with search by name, number or address, for a bulk document send. (Purpose from its caption and its queries; the send flow was not read line by line.) |
| Bulk WhatsApp to debt customers | `frmBulkWapp2CrCustomer` | Same idea for customers who owe money (caption "Bulk WhatsApp Messenger to Debt Customer"; not read line by line). |
| Gift voucher sender | `frmGiftCodeSender` | Reads unused gift vouchers (customer name, contact, amount, validity, code) to send them by WhatsApp (caption "Digital Gift Voucher Sender"). |
| Mobile APK sender | `frmCustomerMobileAppSender` | Lists customers (name, state, phone) to send the shop's customer-app download by WhatsApp (caption "WhatsApp Bulk Mobile Apk Sender to Customers"). |
| Customer mobile notification | `frmCustomerMobileRpt`, `frmInfoBrodcast` | Pushes one customer's name, address, GSTIN, phone, coupon and points to a cloud database path so the customer's phone app can show them (F.3). |
| E-mail settings | `frmEmailSetting` (SMTP: server, SMTP address, e-mail id, password, port, TLS/SSL) and `frmEmailSetting_login` (a second account with an application password for the inbox) | |
| E-mail dashboard | `frmEmailDashboard` (+ `2`, `3`: older copies) | Inbox read over IMAP, sent list, compose (To, CC, BCC, attachments), Reply, and a tick box "AI Message". |
| Bulk e-mail | `frmSendEmail` | Pick customers that have an e-mail address, a subject, a body and one attachment, send to each. |
| E-Mail Sender | `frmEmailsender` | A single-mail sender (username and password boxes on the form). |
| LAN chat | `frmLanChat` | Type a text; it is sent to another PC's IP address. |
| Contacts | `frmContacts`, `frmCustomerContactList`, `frmSupplierContactList` | A small phone book of persons and numbers, and lists of customers or suppliers with photos. |
| SMS record | `frmSMS` | List of sent SMS texts. |

### F.2 Tables and columns

| Table | Columns | Meaning |
|---|---|---|
| `SMSSetting` | `ID, APIURL, IsDefault, IsEnabled, AutoSMS` | The gateway web address and switches ("Yes"/"No" text). Only the row with `IsDefault='Yes'` and `IsEnabled='Yes'` is used. The address holds the gateway's user and password. |
| `SMS` | `Message, Date` | Log of sent texts. **No recipient, no status.** |
| `WappApi` | `ID, c1, c2, WApi, FtpUrl, FtpUser, FtpPassword, FileUrl, ApiMsg` | `c1` = country-code prefix typed by the shop ("+91" when the row is missing, `B/frmPOS.vb:14740`); `c2` = "Enabled"; `ApiMsg` = text-message address with `{No}` and `{Msg}`; `WApi` = media address with `{No}`, `{Msg}`, `{url}` and the instance id and token; `FtpUrl/FtpUser/FtpPassword` the upload place; `FileUrl` the public address of the uploaded files. One row (`Select count(*) ... Having count(*) >= 1`). |
| `FTP_Category` | `c2, FtpUrl, FtpUser, FtpPassword, FileUrl` | The same FTP idea for the online shop (I). |
| `tbl_Whatsapp_Status_Setting` | `ID=1, SMS_status` ... | A switch row the touch till toggles with the `sadmin` password check (A.6). |
| `EmailSetting` | `ID, ServerName, SMTPAddress, Username, Password, Port, TLS_SSL_Required, IsDefault, IsActive, inbox_json_file` | The shop's mail account. Password in plain text. `inbox_json_file` is where the dashboard keeps a copy of the inbox. |
| `EmailSetting_login` | same columns | A second account whose "Password(App)" is a mail provider's application password. |
| `tbl_api_setting` | `id, url, apikey, isDefault, isEnabled` | The address and key of the AI text service (OpenAI-style) used to draft e-mails and by the readers in I. |
| `OfferMsg` | `ID, Msg` | One stored offer text. |
| `Company_Contacts` | `ID, ContactPerson, ContactNo` | The phone book. |
| `GSheet_setting` | `ID, spreadsheetId, gid, IsEnabled` | The Google Sheet that receives customer rows (C.2). |
| Files | `2ndW.txt` (second WhatsApp service id), `Ext` (the Android feed's cloud address and key), `cloud.json` (licence folder) | Plain files beside the program. |

### F.3 What leaves the shop, channel by channel

| Channel | Triggered by | To whom / which service | Customer data sent | Notes against section 15 |
|---|---|---|---|---|
| SMS | a button after a sale, the "Auto SMS" switch on a sale or a customer receipt, bulk screens | the gateway named in `SMSSetting.APIURL` (could be a phone app on the same PC, or an online SMS company); an ordinary web request, `http` unless the shop typed `https` | phone number, customer name, invoice or receipt number, date, amount (or the amount owed), shop name | no consent flag; user and password inside the address; the number goes into the address as typed, the text is URL-encoded (`ModFunc.SMSFunc`, `B/ModFunc.vb:119`) |
| WhatsApp, relay route | buttons on the sale and receipt screens, bulk screens, gift and APK senders | the relay named in `WappApi` (the library's own default is the previous vendor's server) and an FTP host of the shop's choosing | phone number, text, and the **bill PDF** (uploaded first) | plain FTP, public link, file not deleted, token in the address |
| WhatsApp, second relay | `CreateFtpFolder2`: reads an id from `2ndW.txt` | `api.ultramsg.com` (a commercial WhatsApp relay), with a token | phone number, filename, link to the uploaded document, caption text | same |
| WhatsApp, browser route | the stand-in `WhatsApp.Send` | WhatsApp Web driven by Chrome on the shop PC | phone number, text, attachment | unofficial automation of a consumer app; the account can be blocked by WhatsApp; the real code is missing |
| E-mail | bulk e-mail, bill e-mail, password recovery, the dashboard | the shop's own SMTP account (`EmailSetting`) with SSL; IMAP inbox (MailKit) read from the same provider | customer name and address, the body, attachments, **the user's own password in the recovery mail (A.7)** | password stored in plain text; a failed send opens a message box per recipient |
| AI draft of an e-mail | tick "AI Message" in the dashboard | OpenAI chat service, model `gpt-3.5-turbo`, key from `tbl_api_setting` | the **subject line** and a fixed instruction (the subject only; no customer data) | outside AI service; the subject is typed by the shop. Compare decision 10 (public details only): a subject line can contain a name |
| Customer mobile feed | opening `frmCustomerMobileRpt`; then a one-second timer rewrites values | a Firebase database whose address and key come from `cloud.json` ("reports") | customer name, address, GSTIN, contact number, coupon amounts and dates, loyalty points, written under a path built from an Android id | a live customer record in a cloud database, refreshed every second; needs the owner's explicit permission under decision 4 |
| Owner-phone feed | the main menu's Android service (c36, `AID` "Enabled") | the Firebase service in `DevNetFB`, address and key from the `Ext` file | company details and the shop's report figures and stock (what exactly was not read line by line) | company id = a hash of the database name and the **disk serial number** of the PC |
| Google Sheet | `frmGSheet_*` | Google Sheets | customer rows | inside a compiled library; not read |
| LAN chat | the LAN chat form | another PC in the shop on TCP port 44444, plain text | whatever is typed, with the sender's terminal name and IP | no sign-in; the listener runs while the form is open |

### F.4 The flows that matter

**Sale message (classic till).** After a bill is saved, if the internet is reachable and the till's "SMS" tick box is on (it starts on when `SMSSetting.AutoSMS = 'Yes'`), the till reads the default enabled `APIURL`, builds the standard text, calls `SMSFunc(mobile, text, url)` (a web request that replaces `@MobileNo` with the number as typed and `@Message` with the URL-encoded text), writes the text to `SMS`, and shows "Successfully SMS Sent" **without checking the gateway's answer** (`B/frmPOS.vb:10165-10200`). A gateway error shows "SMS is not sent" only if the request itself throws. There is no queue and no retry: the web request runs inside the save flow, on the cashier's screen, so a slow gateway makes the till wait (`WebClient.DownloadString` has no timeout set). This is the opposite of `CLAUDE.md` section 15 ("AI work never runs in the checkout path"; the same reasoning applies to any outside call).

**Phone number.** The WhatsApp phone is `WappApi.c1 + contact number` (prefix box plus the number stored for the customer); a stored number that already begins with a country code or a leading zero becomes a wrong number. SMS uses the number exactly as stored.

**WhatsApp text.** Template from `WappApi.ApiMsg` or `WApi` with `{No}`, `{Msg}`, `{url}` replaced by plain text replacement (the message is **not** URL-encoded in the WhatsApp functions, `B/clswhatsApp.vb`), then a web request: a message with `&`, `#`, `%` or a new line cuts or breaks the address.

**WhatsApp bill.** `Print_WhatsApp` makes a PDF `WhatsApp\Report.pdf` in the program folder; each time the main menu starts, the program deletes the files in that folder (`B/frmMainMenu.vb:9491-9500`), so a PDF lives until the next start. The PDF is then uploaded as above.

**Bulk sends.** The debtor, loyalty, offer and document screens loop over ticked customers and call the same single-send functions one by one on the screen thread (no delay, no limit, no "stop" seen), so a long list blocks the window. Customers who never agreed to be messaged are included (the customer record has no consent column; the only related switch is `is_loyalityDisable`).

**E-mail.** `ModFunc.SendMail` builds one message per recipient (so recipients do not see each other), HTML body, SSL on, any failure shows a message box (`B/ModFunc.vb:581-612`). The inbox is read with IMAP over SSL with the stored password.

### F.5 Quirks and probable bugs (keep or fix?)

1. No consent, no opt-out, no record of recipient or result. **Fix:** a per-customer permission, a message log (who, when, channel, result, template, not the full text of private amounts), see F.8.
2. Passwords and tokens in tables and in web addresses in plain text. **Fix:** names only in the database and values in the secret store (`ISecretStore`), shown masked (CLAUDE.md section 15).
3. Plain FTP and a public link for bill PDFs. **Do not port.**
4. A public webhook-testing site registered for incoming events. **Do not port.**
5. Calls in the save path with no timeout. **Fix:** a background queue; a failure says "message not sent" quietly and never stops a sale.
6. English text and "Rs." fixed in code. **Fix:** templates are the customer's data with fields for name, number, date, amount; the currency comes from the country pack.
7. Unofficial WhatsApp automation and third-party relays. **Do not port;** if WhatsApp is wanted, use the provider's official business interface for the country, later, as a provider interface.
8. The chat forms `frmChat`, `frmChat1` to `frmChat4` are 40-line chart windows (a `Chart` control), not chat; junk.
9. LAN chat has no sign-in and listens on all addresses of the PC while open. **Drop** or fold into the Hub's counter-to-counter notes later.
10. Success is reported without checking the gateway's reply. **Fix.**

### F.6 Worked test examples (by hand; none run)

- **TV-F1 (SMS text).** Customer "Anil", invoice "GST-0042-25/26", date "07-10-2026", grand total 1,180.00, shop "ABC Store": the text is `Dear Sir/Madam, Anil , Thank you for purchasing from us. Your Invoice No. GST-0042-25/26, Date. 07-10-2026 , Amount is Rs.1180.00, Best wishes from ABC Store.` (the code joins the pieces with exactly these spaces and commas, `B/frmPOS.vb:10182`). The amount is `Format(Round(value, 2), "0.00")` with half-to-even rounding; on a stored two-decimal total this changes nothing.
- **TV-F2 (gateway address).** Template `http://127.0.0.1:9500/api?action=sendmessage&recipient=@MobileNo&messagetype=SMS:TEXT&Message=@Message`, number `9876543210`, text `Dear Sir, Rs.50`: the address becomes `...recipient=9876543210&messagetype=SMS:TEXT&Message=Dear+Sir%2c+Rs.50` (space as `+`, comma as `%2c`).
- **TV-F3 (WhatsApp number).** Prefix `+91`, stored number `9876543210` gives `+919876543210`. Stored `09876543210` gives `+9109876543210` (wrong); stored `+919876543210` gives `+91+919876543210` (wrong).
- **TV-F4 (message with an ampersand).** WhatsApp text `Tea & Sugar offer` replaces `{Msg}` unchanged, so the request address contains `Msg=Tea & Sugar offer`; everything after `&` is read as a new parameter and the delivered message is `Tea ` (by the way the address is split; not run).
- **TV-F5 (debtor SMS).** Customer "ravi", balance 1,500.00, ending sentence default: `Dear Sir/Madam RAVI, Your pending amount is Rs. 1500.00, Please pay as soon as possible. , Best wishes from : ABC Store ` (name upper-cased, note the space before the comma and the trailing space, `B/frmCreditCustomerSMS.vb:563`).
- **TV-F6 (gate).** An automatic SMS after a customer receipt needs all of: internet reachable, a `SMSSetting` row with `IsDefault='Yes'`, `IsEnabled='Yes'` and `AutoSMS='Yes'`. With `AutoSMS='No'` the sale screen's tick box starts off but a cashier can tick it; the receipt screen sends nothing.
- **TV-F7 (bulk e-mail).** 3 customers with an e-mail address and 1 without: the list shows 3 (the query keeps `EmailID is NOT NULL and EmailID <> ''`, `B/frmSendEmail.vb:228`); if the second address is rejected by the server a message box appears and the loop goes on to the third.

### F.7 What the Hub has and how it differs

- **Hub today:** no message sending at all (`docs/old-programs/06-hub-map.md` 2.3, "no message sending"), no customer consent field, no templates, no contacts. It has the building blocks: an `ISecretStore` (names in the database, values in the operating system's store), `DataClass` values `PERSONAL` and `FINANCIAL`, a pure routing rule (`Ai/Routing.cs`) written for AI services that fails closed, feature flags off by default, an append-only audit log, and the licensed background worker for non-checkout work (`HubWorker`, 6.6 of the map).
- **Differences:** the old program sent first and had no rules; the Hub's rules say a feature is off by default, local first, the owner told in plain words what leaves, to whom, for which feature, and each kind of data classed. Customer name, number and amounts are `PERSONAL` and `FINANCIAL`: they may go to a messaging provider only if the owner turned that provider on for that purpose (decision 4).
- **Port in this order (smallest safe), each behind a flag that is off by default:**
  1. **Message templates as the customer's data** (profile/setup) with named fields (customer name, document number, date, amount, shop name) and the currency from the country pack; a preview screen that shows the exact text and says in plain words which service would receive it. Tests: changing the template changes the text; no default text names a country or a currency.
  2. **A `message_log` table** (new table, `tenant_id`/`site_id`, rolled back by a rollback file) with who, when, channel, status, template id and the document id; no full text of amounts, no secrets.
  3. **A per-customer "may be contacted by" permission** (a new side table keyed by customer id, as the map suggests for new customer facts), default off; every bulk screen sends only to customers with it on.
  4. **A channel interface** (`IMessageChannel`: send, status) with the first implementations the owner can run on their own: e-mail through the owner's SMTP account, and SMS through the owner's own gateway address (including a phone-app gateway on the shop network). Secrets in `ISecretStore`. Sends happen from a queue in the background worker, never in the sale transaction; a failure shows "message not sent" and nothing else.
  5. **"Send this bill"** buttons (manual) before any automatic sending; automatic after-sale sending last, with the owner's switch.
  6. **Debtor reminders** only after the Hub has a customer ledger (the first gap in `06-hub-map.md` and `02` A1), so the amount owed is correct.
  7. **WhatsApp** only through the provider's official business interface for the country, as another channel behind the same interface, once the owner chooses a provider; the FTP-upload and browser-automation routes are not ported.
  8. The cloud feeds (customer app, owner app) are a separate decision (decision 12's opt-in totals-only head office view is the only cloud view the owner has allowed).

### F.8 Not understood (topic F)

- How the real `DevNet.WhatsApp.V2` library worked (it is replaced by a stand-in), what it sent, and whether it kept a session on disk.
- The exact contents of the owner-phone feed (`DevNetFB.FirebaseService`, 1,925 lines): which tables and fields it publishes. Only its start-up wiring was read (`B/frmMainMenu.vb:9366-9400`).
- What `frmSMS_AutoDetect`, `frmEmailsender` (a form with username and password boxes) and the `frmEmailDashboard2/3` copies add over `frmEmailDashboard`.
- How phone numbers are validated before sending (no check was found in the screens read).
- The Google Sheet write path (inside a compiled library).

## G. Leads, follow-up, support, reminders (small CRM)

Status of this topic: written. Covers sales leads and their products, follow-ups, the link from a quotation to a lead, converting a lead into a customer, the after-sales support tickets and call log, and the reminder notes. Read for the rules and tables; the long screens (1,000 to 3,000 lines each) are mostly grids and filters.

### G.0 The five things to know

1. **It is a small sales-lead book plus a help-desk, built round four tables:** `tbl_lead_master` (the lead), `tbl_followup_lead` (every contact with it), `CustomerSupportForm` (a support ticket) and `Reminder` (a dated note). A lead is a person who has not bought yet; the support ticket is for a customer who has.
2. **Lead status is a three-word list: NEW LEAD, FOLLOW-UP, FINISHED** (`B/frmFollowUp_Lead.Designer.vb`, `cmbStatus`). Interest is Low/Medium/High; follow-up rating 1 to 5. A bill made from a quotation that carries a lead id **closes the lead by itself** with the remark "Bill Generated" (`B/frmPOSNewTuch.vb:25034`).
3. **The reminder date typed on a follow-up is only stored and listed.** No timer or start-up check reads `tbl_followup_lead.reminder_date` (searched: only the follow-up screens and the quotation till). The only reminder that pops up is the plain `Reminder` table, counted on the main screen at start-up (`B/frmMainMenu.vb:15605`), switch c44 ("Reminder Record") does nothing (A.4).
4. **Column names mislead:** `coordinate_mode` holds "GPS" or "Manual" in the lead screen (how the location was entered) but the follow-up screen's drop-down of the same name holds "Owner, Salesman, Accountant, Manager, Clerk" (who coordinates); the support table has `SoftwareName` and `SoftwareValidity` columns that come from the older vendor's own help desk and are filled with the licence holder's company name (`B/frmCustomerSupport1.vb:2399`); the "Help" button on the sign-in screen opens the support-log report (`B/frmLogin.vb:975`), which is the shop's own call log, not a way to reach NextGenOS.
5. **All lead and support data is personal data** (name, phone, address, what the person asked for). The screens send nothing outside by themselves; the only outside step is the optional bulk message screens (F). Under CLAUDE.md section 15 it is `PERSONAL` and stays on the main PC.

### G.1 What a person sees

| Screen | File | Purpose |
|---|---|---|
| Lead Generate | `frmLead2` (1,798 lines; the main screen), `frmLeadGenerate` (322 lines, an older simple entry) | Mobile number, customer or company name, state (a fixed list of Indian states and territories), address, coordinate mode, interest mode, product (from the lead-product list), remarks, allotted user; list below; Excel import (the grid carries a `lead_id` column); lead id shown as `L-` plus a number. |
| Lead Product | `frmLead_Product` | The list of products leads can ask about: name and a photo (`tbl_lead_product(ID, product_name, CPhoto)`), Export. |
| List of Leads | `frmLeadGenerateRecord` (1,615 lines) | Search and filters by date, status, allotted user and text; each row shows its latest follow-up status; open for update. Admin and Moderator see more buttons (15 role checks, `B/frmLeadGenerateRecord.vb`). |
| Lead Follow-Up Entry | `frmFollowUp_Lead` | Choose a lead; add a remark, follow-up date, status, reminder date and time, "follow-up by", rating; see earlier follow-ups; a button builds a quotation for this lead. |
| FollowUp Lead Records | `frmFollowUp_LeadRecords` | List of follow-ups with the lead's details. |
| Lead Update | `frmLead_Update` | Edit a lead; **"Gen. Quotation"** opens the quotation till with the lead carried over; **make a customer** (`InsertCustomer`) copies the lead into the `Customer` master (see G.3). |
| Support Form | `frmCustomerSupport1` (3,377 lines; `frmCustomerSupport`, 2,750 lines, is an older version tied to receipts) | Pick a customer (shows the account balance, first and last invoice date, the number of earlier tickets), type "Current Issue", choose Support type (FIX SUPPORT or GENERAL SUPPORT) and the user it is assigned to, save; a list of open tickets. |
| Support dashboard | `frmCustomerSupportForm_Dashboard` | List and close tickets with date filters; close sets the status and the date. |
| Support log | `frmCustomerSupportLog`, `_Dashboard`, `_Report` | A call log: "Calling No." and the call's details; a dashboard marks entries successful or failed. |
| Set Reminder | `frmReminder`, `frmReminderRecord`, `frmReminderShow` | Type a message and a date; list; show today's. |

### G.2 Tables and columns

| Table | Columns | Meaning and traps |
|---|---|---|
| `tbl_lead_master` | `id, lead_id, lead_date, customer_name, coordinate_mode, mobile, state, address, interest_mode, productname, remarks, alloted_user` | `id` is a number made by the program (the screen inserts it explicitly); `lead_id` is the text `L-<number>` shown to people; `alloted_user` is a user id text from `Registration` (the same renaming trap as A.9 item 7). The state is chosen from a fixed list of Indian states and union territories (`B/frmLead2.Designer.vb`; the table `tbl_State` is also read). |
| `tbl_followup_lead` | `lead_id (the id number), remarks, followup_date, lead_status, reminder_date, reminder_time, followup_by, rating` | One row per contact. The follow-up keeps the **integer** `id` while the master's text `lead_id` is `L-n`; the join is on the integer (`b.lead_id` vs `a.lead_id` in the list queries). |
| `tbl_lead_product` | `ID, product_name, CPhoto` | Lead products; inserted with `SET IDENTITY_INSERT ON` and an explicit ID. |
| `CustomerSupportForm` | `LogID, LogTimestamp, support_token_no, CustomerName, RegisteredMobileNumber, CallingNumber, CurrentIssue, SoftwareName, SoftwareValidity, Status, Remark, Feedback, Rating, EmailAddress, SupportType, CustomerId, join_user, Close_date` | A ticket. `Status` is "Open" when made and "Closed" when closed (`Close_date` set to now). `support_token_no` is a ticket number typed into a box (how it is generated was not followed; the screen also counts earlier tickets by customer, `B/frmCustomerSupport1.vb:2230-2245`). `join_user` is the assigned user. |
| `CustomerSupportLog` | `support_token_no, CustomerName, RegisteredMobileNumber, CallingNumber, CurrentIssue, SoftwareName, SoftwareValidity, Status, Remark, Feedback, Rating, EmailAddress` | Same shape; the call log. |
| `CustomerSupportLog_Dashboard` | (not listed) | Status updates for log rows ("successful", "failed"). |
| `Reminder` | `msg, mdate` | A note and its date; no id column seen in the insert. |

### G.3 The flows

**New lead** (`frmLead2`): the number part of `L-n` comes from `GenerateID()` (the next number, `:848`); required fields are checked by the screen (customer name, mobile, state); the insert lists all twelve columns. A mobile number may repeat (the duplicate check that was read is against `Customer`, not against leads).

**Follow-up** (`frmFollowUp_Lead`, `:863`): insert a row with the lead's integer id, the remark, the follow-up date (now), the chosen status, the reminder date only if the date picker is ticked (`dtpReminderDate.Checked`, else null), the reminder time from a drop-down, the user and the rating; update re-writes the same fields. The latest follow-up status is shown in the lead list.

**Quotation from a lead** (`Gen. Quotation` in `frmLead_Update`, `frmFollowUp_Lead` reads `InvoiceInfo_Quotation` and its product rows to show earlier quotations): the quotation till receives the lead id in a hidden label (`lblLead_Id`). When that quotation is converted to a bill in the till and the quotation number and a non-zero lead id are present, the till inserts a follow-up row: remark "Bill Generated", status FINISHED, reminder date today, time now, "follow-up by" the signed-in user (`B/frmPOSNewTuch.vb:25030-25050`, also in `frmPOSNewTuch_Quotation` and `frmPOSTouch`).

**Lead to customer** (`InsertCustomer`, `frmLead_Update:701-780`): needs customer name, state and mobile; refuses if the mobile already exists in `Customer` (the second check, name plus `_` plus mobile, sits inside a branch that runs only when the name box is empty, which was refused a few lines earlier, so it never runs); then inserts a `Customer` row with the new `ID`/`CustomerID` (from `autoCust`) and **invented values**: the name becomes `<typed name>_<mobile>` (for example `Anil_9812345678`), the address is the word `local`, the city `localcity`, the e-mail `abc@gmail.com`, and GSTIN, PAN, bank fields and the rest are empty or default; a gift QR image is made from the mobile number (`Generate_GiftQR`). The numbering is that of the customer master (02 A1.1). The lead's real address is not copied (the insert passes `local`), which loses data. The lead is not deleted and is not marked converted by this step (the quotation-to-bill step is what closes it).

**Support ticket** (`DataInsert`, `:2540-2580`): required: customer, issue, support type, assigned user; inserts with `Status = 'Open'` and the customer id; the ticket list shows the open ones; the dashboard closes a ticket: `UPDATE CustomerSupportForm SET Status='Closed', Close_date=GETDATE(), Remark=@Remark WHERE LogId=@LogId`. A short update changes only name, number, issue, type, customer and user.

**Reminder** (`frmReminder`): `insert into Reminder(msg, mdate) Values (@d1,@d2)`; at the start of the main menu `SELECT COUNT(*) FROM Reminder WHERE mdate=@today`; if more than zero a number badge and an enabled icon appear; clicking opens `frmReminderShow` with the day's messages (`SELECT msg from Reminder where mdate=@d1`). Only the **exact date** matches: a reminder dated yesterday and not seen is never shown again unless someone opens the record list.

### G.4 Quirks and probable bugs (keep or fix?)

1. Lead reminders never fire (G.0 item 3). **Fix** (the Hub's Today page can list "follow-ups due today and overdue").
2. Reminder matches the exact date only; missed days vanish from the badge. **Fix:** show due and overdue.
3. Two id forms for a lead (`L-n` text and the integer) joined across tables; support tickets use a typed token number. **Fix:** one id, the display text made from it.
4. Lead state list is the Indian list in code. **Fix:** regions come from the country pack (CLAUDE.md section 8).
5. Converting to a customer does not record which customer a lead became, writes invented values (`local`, `localcity`, `abc@gmail.com`, a name with the mobile glued on) and drops the real address. A later bulk e-mail would go to the invented address. **Fix:** copy the real fields, leave unknown ones empty (never invent), and keep a link.
6. Support-ticket columns for a software vendor (`SoftwareName`, `SoftwareValidity`) are filled with the licence holder's company name. **Drop.**
7. Names in `alloted_user` and `join_user` are user-id texts (detach on rename). **Fix** (A.9).
8. The ticket and lead screens run long queries with the filter text joined into the SQL (`like N'%...%'` built by string joining, as in the customer lists). **Fix** (parameters).
9. Role checks in the lead list (Admin and Moderator see more) are the only permission; no user can be stopped from reading all leads. **Keep the idea,** decide the roles in the Hub.

### G.5 Worked test examples (by hand; none run)

- **TV-G1 (lead to bill).** Lead 7 (`L-7`, status NEW LEAD). Follow-up 1: status FOLLOW-UP, reminder 10 October 10:30. A quotation is made for lead 7, then turned into a bill by the quotation till: a new follow-up row (lead 7, "Bill Generated", FINISHED, reminder = today, time = now) is added. The list now shows FINISHED for lead 7 (the latest follow-up wins). If the quotation was made without the lead id (`lblLead_Id` = 0 or empty) nothing is added.
- **TV-G2 (reminders).** Three reminders dated today and one dated yesterday: the badge shows 3; the screen opened from the badge lists the 3 messages; yesterday's is never counted again.
- **TV-G3 (support ticket).** A new ticket for customer 12 with 2 earlier tickets: the screen shows "tickets so far: 2" and, after saving, the customer has 3 (`COUNT(support_token_no) ... WHERE CustomerId = 12`); the new row's status is "Open"; closing sets "Closed", the close date to the server's current time and the remark typed at closing.
- **TV-G4 (lead to customer).** Lead "Anil", mobile 9812345678, state Kerala, address "12 Market Road": if no customer has that number, a customer is created named `Anil_9812345678`, address `local`, city `localcity`, e-mail `abc@gmail.com`, state Kerala. If a customer already has the number: refused, no row. Two different leads with the same name and different numbers give two customers with different names (because of the `_mobile` suffix).
- **TV-G5 (reminder time).** A follow-up with the reminder box unticked stores a null date; with the box ticked and no time chosen the time is null (the code stores null when the time box is empty); both are shown blank in the list.

### G.6 What the Hub has and how it differs

- **Hub:** none of these. `parties` has kinds (customer, supplier, staff, member); `Appointments` (bookings by staff and day, check in, charge, cancel) and `Projects` (quotes for construction) exist; the `quote` document type exists only for projects. There is no lead, no follow-up, no ticket, no reminder. The Today page is where a "due today" list would go (`06-hub-map.md` 5.4).
- **Differences:** the old CRM is tied to the quotation till (a lead's quote becomes its bill and closes it); the Hub has no shop quotation yet (MERGE-PLAN row "Estimates and quotations" and decision 35), so the link comes after that.
- **Port in this order (smallest safe):** (1) **reminders** first, as a new table `reminders(due_date, text, done, created_by)` with a "due today and overdue" card on the Today page (small, useful on its own); (2) **leads and follow-ups** as three new tables (`leads`, `lead_followups`, a `lead_products` list that can simply be the item list), with the statuses as data (NEW, FOLLOW-UP, FINISHED, but customer-renamable), regions from the country pack, a due list for follow-ups, and a "make a customer" button that records the link; (3) the **quotation link** after the Hub has shop quotations; (4) **service tickets** for after-sales (open, closed, assigned user, close date, remark) with no vendor columns, and a rating only if the owner wants it; (5) no outgoing messages from any of these unless the owner turns the message feature on (F.7). All new tables carry `tenant_id` and `site_id` and a rollback file (`06-hub-map.md` 3.5).
- **Tests to write:** closing a lead when its quotation becomes a bill; a reminder shows on its date and stays on the overdue list until marked done; a follow-up with no reminder date never appears on the due list; converting a lead refuses a number already used by a customer.

### G.7 Not understood (topic G)

- How `support_token_no` is made (a text box on the form; its automatic fill was not found).
- What `CustomerSupportLog_Dashboard` stores beyond the status updates, and what "successful/failed" mean for a call.
- Whether the Excel import of leads (`frmLead2`) updates existing rows by `lead_id` or only inserts.
- `frmCustomerSupport` (older) is tied to the credit-customer receipt and an automatic SMS (F.4) after a payment; its ticket flow was not read.
- What `coordinate_mode = GPS` does (no map or location call was found in the screens read).

## H. Branches, companies, financial-year change, transfers

Status of this topic: written. Covers what a "company" is, how one is created and deleted, the company master, the branch registry, the multi-branch reports, the financial-year change, the virtual company for estimates, and where stock transfers between branches fit (their arithmetic and tokens are in `docs/old-programs/01-selling-buying-stock.md` section 6.5 and are not repeated).

### H.0 The five things to know

1. **One company is one SQL Server database.** A PC can hold many companies; sign-in starts by choosing one from a list in a separate "master" database (`RaintechMaster`), and the program then talks to that database only (A.0 item 4). A "branch" is just another company database that has been linked to a group. There is no branch column inside the sales tables.
2. **Creating a company runs a script and closes the program.** The sign-in screen's "Create company" button (open to anyone at the sign-in screen, before any sign-in) makes a new database, runs `DBScript.sql` through SQL Management Objects, inserts the company row, registers it in the master list and then ends the program ("Application will be closed, please start it again", `B/frmCompany.vb:760-870`). **`DBScript.sql` is not in the repository**, so the table definitions and the seed rows (the walk-in customer "Cash" with ID 1, the first users, tax tables) cannot be read here (`docs/MERGE-PLAN.md` says the same).
3. **Deleting a company drops the database.** `frmCompanyDelete` runs `ALTER DATABASE ... SET Single_User WITH Rollback Immediate` then `DROP DATABASE` and removes the master-list row, after one yes/no question, with no backup first and no administrator password re-check (`B/frmCompanyDelete.vb:421-445`, reached from three menu entries in `frmMainMenu.vb:12640`, `14375`).
4. **The branch group lives in an online MySQL database.** "Admin Code", "Branch Code", the branch list and the cloud stock registry are rows in a **MySQL** server whose address and login come from a file next to the program (`TempDB.dat`, read by `ModCS.ReadCS1`, `B/ModCS.vb:25`); a secret is stored there. Branch-to-branch stock documents and the "Auto Data Synchronization" copy rows between SQL Server databases through an online one (C.1). Decision 4 and decision 12 replace all of this.
5. **The financial-year change does not close the year.** It stores two dates on the company row and **resets the invoice counters** (deletes the counter tables), so numbering starts again; sales, purchases and ledgers stay in the same database and the ledger balances simply run on (A running balance needs no year-end carry-forward, 02 section B). No stock valuation, no closing entries, no lock on the old year.

### H.1 What a person sees

| Screen | File | Purpose |
|---|---|---|
| Create Company | `frmCompany` (sign-in screen button) | Company name, address, city, state (a fixed Indian list), contact number, e-mail, GSTIN, CIN, web address, logo, financial-year dates, currency symbol (the form starts with the rupee sign, set in code at `B/frmCompany.vb:677`), loyalty value per point (default 0.10). |
| Company Master | `frmCompanyupdate` (menu, switch c1) | The same fields later, plus bank details (account name, number, IFSC, branch), a "Company ID" with Copy, "Barcode Code", "Admin Code", **"Branch Update"** and **"Upgrade Online"**, the "Mobile Android App and Multi Branch Status" (`Company.AndroidID` "Enabled"/"Disabled"), and an "Envelope Print" button. |
| Delete Company | `frmCompanyDelete` | List of companies; delete one (drops its database). |
| Branch Admin | `frmBranchAdmin` | Protected by the `sadmin` password check (A.6). Admin branch code, name, address, mobile; branch list with code, state, address, mobile, city, GST number, status. |
| Branch Add Master | `frmBranch_AddMaster` | Links two companies: a list of branches with "Local DB", "Online Db", "Status", "Company Id"; Add and delete (`Branch_Relation(from_company_id, to_company_id)`). |
| Branch entry (bank) | `frmBranchMaster_Bank` | **Not a company branch:** it is the *bank branch* master (`BankBranch`) used by bank accounts (02). The name misleads. |
| Branch / multi-branch reports | `frmBranchReport_Dashboard`, `frmMultiBranchReport` | The first lists companies from the master list; the second keeps a list of "Android apps" (`Android_Apps(ID, c1, c2, c3)`): the phones registered to see the branches' figures. Report content is fetched through the online feed (F.3). |
| Financial Year Change | `frmFYChange` | FY begins/ends dates, "Starting POS Number Series", Apply (set the first number), Save (set the dates and reset all counters). |
| Virtual Company Info for Estimate Bill | `frmVirtualCompany` (switch c41) | A second set of company details (name, address, contact, e-mail, GSTIN, CIN, state, "Activate") kept in table `VCompany`; printed on estimate or delivery-note bills instead of the real company when activated (`frmEstimate.vb:2827`). |
| Stock transfer screens | `frmStockTransfer`, `frmStock_TransferRecord`, `frmPOSNewTuch_StockTransfer`, `frmPOSNewTuch_StockInward`, `frmStock_Inward_Record`, `frmStock_Inward_Notification`, `frmStock_Settlement`, `frmGodownInward`, `frmGodownOutward`, `frmGodownConfig` | See 01 section 6.5: a token or a sale-like document from one company to another, settlement into the receiver's stock, and the cloud godown. `frmGodownConfig` ("Multi Branch Cloud Stock Storage Configuration") stores a web address and a secret in table `Activation`. |
| Token in/out/settlement | `frmTokenIn`, `frmTokenOut`, `frmTokenSettlement` | The token flow of the same transfers (01). |
| State list | `frmState` | The pick-list of Indian states used by customers, suppliers, companies and leads. |

### H.2 Tables and columns

| Table (database) | Columns | Meaning and traps |
|---|---|---|
| `RaintechMaster` (database `RaintechMaster_DB`, the master) | `ID, CompanyName, DBName, Online_DBName, company_id` | One row per company. `DBName` = `Raintech_DB<ID>` (the previous vendor's name inside every database name; must not survive); `Online_DBName` = `DBName` + `_` + a timestamp `yyyyMMddHHmmss` (the name of its online copy); `company_id` = MD5 of the database name joined to the **reversed serial number of the PC's disk** (so a company is tied to the first disk found; the same code is used as the id of the owner-phone feed, F.3). Created at `B/frmCompany.vb:826-855`. |
| `Company` (inside each company database) | `ID, companyName, Address, ContactNo, EmailID, GSTIN, State, CIN, Logo, FYFrom, FYTo, City, Web, Bankholder, Bankacno, Bankname, Bankifsc, AndroidID, CurSym, Loyality_perpoint, BCode` | The company's identity (one row). `FYFrom`, `FYTo` are the financial year; `CurSym` the currency symbol text; `Loyality_perpoint` the money value of one loyalty point (the touch tills; decision 31); `BCode` the branch code used in transfer-token numbers (01 section 6.5; probably the box the company master calls "Barcode Code", not confirmed); `AndroidID` is a text "Enabled"/"Disabled" switch, not an id (misleading name). The company state decides CGST/SGST versus IGST (01 section 1.2). |
| `Branch_Relation` | `from_company_id, to_company_id`, plus names | Which companies may send stock documents to which. |
| `Branch_Admin`, `Branch` (online MySQL) | `admin_code, admin_address, admin_mobno, admin_name`; `branchcode, admincode, branchname, branchstate, branchaddress, branchmobno, branchcity, branchgst, branchstatus` | The online registry of the group. |
| `Activation` | not listed here | The cloud-godown connection (address and secret). |
| `VCompany` | company name, address, contact, e-mail, GSTIN, CIN, state, activate | The virtual identity for estimates. |
| `SaleGST`, `SaleNoTax`, `PurcGST`, `PurcNoTax`, `SrEstimate`, `SrSaleReturn`, `SrQuotation`, `SrPurReturn`, `SrPurOrder`, `SrReceipt`, `SrPayment`, `SrIncome`, `SrExpenses`, `SrService`, `SrSerBill` | `ID, InvNo` | The **counter tables**: the highest `ID` is the last number used; the next number is that plus 1 (D.6 TV-D1). The year change empties them. |
| Registry `HKCU\SOFTWARE\NextGenOS\iCB` value `Starting_Number` | (text) | The starting invoice number the person typed, remembered per Windows user and PC (an older key `Raintech\iCB` is read if the new one is missing, `B/ModFunc.vb:780-815`). |

### H.3 The flows

**Create company** (`Button3_Click`, `:677-870`): needs currency symbol, company name, address, state, contact number and e-mail (all required; the GSTIN is not). Refuses a name already in `RaintechMaster`. Then in order: take the next `ID` (highest + 1, `:644-660`); write `TempDBSettings.dat` with the new database name; `CREATE DATABASE Raintech_DB<ID>`; run `DBScript.sql` with `USE` prepended; set the database READ_WRITE; insert the `Company` row with the typed values, the two year dates, bank fields empty, `AndroidID = "Disabled"`, the currency symbol and the loyalty value (blank means 0); register the company in `RaintechMaster` with the online name and the disk-based `company_id`; copy the company state onto the walk-in customer (`update Customer set State=... where ID='1' and Name='Cash'`, so a cash sale is same-state); show the message and end the program. No transaction wraps these steps: a failure half way leaves a database without a master row or the reverse.

**Delete company** (`DeleteRecord`): drops the database (single-user, kicks everyone off) and deletes the master row; ends the program. A copy of the data is not taken. The text of the question says the application will close.

**Join a branch group** (`btnbranchUpdate_Click`, `frmCompanyupdate.vb:1403-1470`): type the admin code; the program asks the online MySQL registry whether such an admin code exists ("Invalid Admin Code" if not); then checks that the branch code is not already registered ("Branch Already Exists") and inserts the branch row (`insBranch`) and updates the admin row (`OflineUpdateAdmin`). Errors are swallowed (`Catch ex As Exception` with nothing in it), so a failed network call looks like nothing happened.

**Change the financial year** (`frmFYChange`): on load it reads `Company.FYFrom/FYTo` and the saved starting number; the "starting number" box is **read-only if any sale already exists** (`SaleGST` or `SaleNoTax` has a row, `:248-268`), and Apply refuses ("You are not allowed. Sales Record found"). Apply (first-number set): refuses empty or 0, deletes `SaleGST` and `SaleNoTax`, saves the number in the registry and inserts one row `(ID = number - 1, InvNo = "Opening Serial No")` into each so that the next bill gets `number` (`:514-570`). Save (`GelButton1_Click`, `:584-619`): writes `FYFrom/FYTo` on the company row, logs "Financial Year has been Saved from ... to ...", **asks "Do you want to reset voucher numbering?" and, if yes, deletes the 15 counter tables**, clears the saved starting number, and closes; any error at the end is swallowed.

**Stock between branches:** by the three mechanisms in 01 section 6.5 (token, sale-like transfer document, cloud godown), each moving rows through an online service that the recovered code names in the screens above. **Not to be ported as they are** (01); the Hub's way is decided by decisions 4 and 12.

### H.4 Quirks and probable bugs (keep or fix?)

1. Company creation is available before sign-in, to anyone; deletion drops the database with no re-check. **Fix:** only the owner, after a password re-check and a backup copy (decision 11), and the Hub's equivalent is a new shop database made by the Setup Studio, not by a till.
2. The previous vendor's name is in every database name and in the master database name. **Do not port;** an importer maps the old database to a Hub shop and ignores the names.
3. The company id depends on the disk serial number: a replaced disk or a restore on another PC gives a different id and the feeds (owner phone, branch) lose the link. **Do not port.**
4. Year change = counters reset, nothing else. A new year therefore **repeats invoice numbers** if the suffix (the "25/26" part, D.6) is not changed; the suffix comes from `FYFrom`/`FYTo`, so it changes with the dates, which is what keeps numbers unique. **Keep the idea** (the Hub numbers per type and fiscal year automatically, `06-hub-map.md` 4.5) **and fix** the missing safeguards: a year cannot be saved with a hole or an overlap, and a new year must not erase the counters of the old one.
5. The starting number is held in the registry of the Windows user, not with the data; another Windows user or PC sees none. **Fix:** keep it with the shop's data.
6. No transaction across company creation or deletion. **Fix.**
7. The virtual company prints another firm name and a GSTIN on estimate bills. Its legitimate uses (a trading name, a separate unregistered business) cannot be told from misuse (cash bills under a name that is not the registered taxpayer). **Needs the owner's decision before any port;** if ported, it must be a labelled "second business identity" with the real tax number or none, visible in audit, never a hidden switch.
8. `frmBranchMaster_Bank` is a bank-branch list called "Branch Entry". **Do not confuse;** port with banks (02), not with company branches.
9. The branch calls to MySQL swallow errors; the sign-in "Create company" and "Branch update" steps have no log lines. **Fix** (log and plain messages).

### H.5 Worked test examples (by hand; none run)

- **TV-H1 (new company).** `RaintechMaster` has IDs 1 and 2. Creating a third company with name "Shop C": next ID 3; database `Raintech_DB3`; `Online_DBName` such as `Raintech_DB3_20261007101500`; `company_id` = MD5 of `Raintech_DB3` joined to the reversed disk serial. The walk-in customer ID 1 gets the company's state. If the table is empty the first ID is 1. Two companies with the same name: refused ("Company name already exists").
- **TV-H2 (set the first invoice number).** No sale yet; the person types 501 and presses Apply: `SaleGST` and `SaleNoTax` each hold one row `(500, "Opening Serial No")`; the next GST bill is numbered with `500 + 1 = 501` padded to 4 digits: `GST-0501-<suffix>`. With any sale present: refused.
- **TV-H3 (year change).** FY changed from 01-04-2025 to 31-03-2026 to 01-04-2026 to 31-03-2027, with "reset voucher numbering" answered yes: all 15 counter tables are empty, so the next sale is number 1: `GST-0001-26/27`. Answered no: the dates change but the counters go on (`GST-0043-26/27` if 42 was the last), which is allowed and makes the suffix the only difference.
- **TV-H4 (delete).** Deleting "Shop B" (`Raintech_DB2`): after the yes, the database is dropped even if another PC is signed in to it (the other PC is thrown off), the master row is removed, the program closes. Nothing can be undone from inside the program.
- **TV-H5 (branch join).** An admin code that is not in `branch_admin`: message "Invalid Admin Code", nothing else happens. A valid code and an unused branch code: one row in `branch` and the admin row updated. A branch code already in `branch`: "Branch Already Exists".

### H.6 What the Hub has and how it differs

- **Hub:** one database file is one shop (`06-hub-map.md` 3, `docs/OPEN-WORK.md`); the shop's identity is `ShopSettings` (name, address, phone, e-mail, tax id, country, region, industry); the **fiscal year starts from the country pack** (India 1 April) and **numbers run per document type and fiscal year automatically, in the sale's own transaction, with no gaps** (`Numbering.Next`); there is no counter reset step and no year-change screen; **no custom prefix or suffix and no starting number**. New shops are made by the Setup Studio and the set-up wizard, not by a till. Several stores and head-office views are decisions 4 and 12 and are **not built**.
- **Differences:** the old year change needs a person to remember it and can repeat numbers; the Hub cannot repeat a number within a year but also cannot continue a customer's old numbering. The Hub has nothing like a branch registry, a transfer between branches, a cloud godown or a virtual company.
- **Port in this order (smallest safe):** (1) a **starting number per document type** (and optional prefix) in the shop settings, used by `Numbering.Next` for the first document of a year, so a shop that moves from the old program in the middle of a year keeps its numbers (test: starting number 501 gives `INV-2026-000501`; a rolled-back document returns the number); (2) the **data mover** maps *one old company database to one Hub shop* (ignore `Raintech_DB` names, take `Company` fields into `ShopSettings`, `FYFrom`/`FYTo` into the fiscal-year check, `Company.State` into the region, `Loyality_perpoint` into `LoyaltyPointValueMilli`, `CurSym` ignored in favour of the country pack's currency); (3) for several stores, follow decisions 4 and 12 (main PC per store; opt-in totals-only head-office view) and **do not** port the online MySQL registry or the SQL-to-SQL synchronisation; (4) stock transfer between two stores of one owner only after the store-network work, as a document pair (send, receive) on the shop network, not through a cloud (01 section 6.5 and 8); (5) the virtual company only after the owner's decision (H.4 item 7).
- **Tests to write:** starting number then rolled-back sale; fiscal-year boundary (31 March and 1 April) with a starting number; importer maps `Company` to settings and refuses a database without a `Company` row.

### H.7 Not understood (topic H)

- The contents of `DBScript.sql` (not in the repository): the seed users, the walk-in customer, default tax rows, the counter tables' exact columns.
- The columns of `Activation` and `Android_Apps` beyond `c1`, `c2`, `c3`; what the "Upgrade Online" button (`frmCompanyupdate.vb:1519`) uploads.
- How a notification of a transfer reaches the receiving branch (`frmStock_Inward_Notification` reads `InvoiceInfo_StockInward` and `InvoiceInfo_StockTransfer` from the other company's data; the transport was not followed).
- Whether `Online_DBName` is a real second SQL Server database on the vendor's server or a name inside the group registry.
- What `frmBagBox` (a "Select Psc/Box" pick-list) and `frmState` do beyond the lists they show.

## I. UPI QR, online-shop link, gallery, camera, image reader, calculator and other extras

Status of this topic: written. One short section per extra: what it is, the tables, what leaves the shop, and whether it is worth porting. Customer-visible words and images here are the customer's data (CLAUDE.md section 8).

### I.0 The five things to know

1. **Most extras are small and local.** The calculators, the cash-denomination counter, the cash-refund calculator, the camera and the gallery read no outside service. The ones that talk to the outside are the e-commerce push, the AI readers (image, PDF) and the online image library.
2. **The UPI QR is built on the PC from the shop's own payment details and shown on the customer's second screen.** The payment itself is not seen by the program: the cashier confirms it by hand. This matches decision 13 ("the software records the amount and the method; it never sees a card number"). The "PhonePe UPI gateway" screen is a 114-line shell around a compiled library that is not in the repository (`DevNet.PhonePe`, obfuscated); its behaviour is unknown.
3. **The AI readers send pictures to an outside AI service.** `frmImageReader` (a product photo, to get a product name), `frmPdfReader` (a supplier invoice, to get its lines), the quick-add product in the touch till, and the customer and supplier forms (a visiting-card or invoice image, to fill the buyer or seller details) post the picture to `api.openai.com` with the shop's key from `tbl_api_setting`. A supplier invoice or a buyer's invoice image holds names, addresses, tax numbers and prices. Under decision 10 and CLAUDE.md section 15 this is `PERSONAL`/`FINANCIAL` data to an outside service and needs the owner's explicit yes for that purpose, per feature.
4. **The e-commerce screens are a one-way catalogue push to a website API of the previous vendor's design**, not an order system (I.2).
5. **Defaults are India's:** the denominations (2000, 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1), the rupee sign, "UPI", the GST calculator, state lists. All must come from the country pack in the Hub.

### I.1 UPI QR

| Item | Detail |
|---|---|
| Screens | `frmAutoUPI` ("UPI Gateway"), `frmUPIQRCodeImg` ("UPI QR Code Image": a stored picture of the shop's own QR with a name; rotate, browse), `QRGenerator` (a general QR maker), `frmPhonePeUPI` (shell). |
| Tables | `UPIImg` (the stored QR pictures by UPI name; read and written by `frmUPIQRCodeImg`), `PosPrinterSetting.UPIID` and `BrandName` (B.2), and the bill value `UPI` ("UPI PAY :" printed when a UPI amount is more than zero and the tick box is on, B.3). |
| How it works | `frmAutoUPI_Load` fills a `Bank` object (account number, IFSC code, payee name, amount, note) and calls `UPI.Generate(bank)`, which returns a picture; the picture goes to a box on the cashier screen and to `Form2.PictureBox1`, the customer-facing window shown on the second monitor if `PosPrinterSetting.SecDisplay = "Yes"` (`B/frmAutoUPI.vb:80-130`). The same call is in `frmPOSNew`, `frmQuotation`, `frmPOSNewTuch_StockInward`. The QR text format comes from a library outside the repository; the project references `QRCoder` to draw QR images (`SmartAvenue99 POS.vbproj:171`). |
| Leaves the shop | nothing by itself. |
| Rules | The amount in the QR is the amount due at the time; a failed `Double.Parse` leaves the amount empty (the customer types it). Payment is confirmed by the cashier adding a UPI/online payment row (01 section 2.1). |
| Port | A "show payment code to the customer" step is useful anywhere with a static payment address; keep it **as data**: the payment-address format belongs to the country pack, the address and payee name to the shop's profile (decision 13 says certified provider connections come later, per country). Not before the second-screen customer display exists. |

### I.2 Online shop ("E-Com")

| Item | Detail |
|---|---|
| Screens | `frmEComSeting` (settings), `frmECategory`, `frmESubCategory`, `frmEProduct` (the main one, 1,470 lines), `frmEMain` (a 301-line shell). |
| Table | `FTP_Category(c2 "Enabled", FtpUrl, FtpUser, FtpPassword, FileUrl, WebUrl)`: one row; **the FTP user and password are stored in plain text** (a secret is stored here). |
| Flow | For each product the screen lists local products beside the online ones and "Post" or "Bulk Post". Post builds one web address `<WebUrl>/api/ins-product?id=..&pname=..&sname=..&cid=..&sid=..&psdesc=..&pgms=..&pprice=..&sprice=..&status=..&stock=..&pimg=..&prel=..&date=..&discount=..&popular=..&barcode=..&mode=..` (the values joined unencoded) and calls it with GET; if the reply contains the word `true` it uploads the product picture to the FTP server (`B/frmEProduct.vb:1060-1100`). Categories and sub-categories are pushed the same way, with a choice of FTP or SFTP (`frmECategory.vb:457-500`). Fields: seller or shop name, publish or unpublish, "make popular", "send notification", stock, small description, quantity unit text (gms, kg, ltr, ml, pcs), sale price, MRP, discount. |
| Leaves the shop | product names, descriptions, **stock quantities, prices, discounts, barcodes** and pictures, to the website named in `WebUrl` over a plain GET and an FTP upload. |
| Quirks | Unencoded values break on `&`, `#` or non-Latin letters; success is detected by looking for the text `true` in the reply; plain FTP. |
| Hub | The storefront program (`apps/storefront-web-mobile`) has its own product data (Prisma); there is no feed from the Hub. A catalogue feed from the Hub to the storefront is a design question (the shop's stock quantity and prices are `INTERNAL`; a public catalogue is `PUBLIC` data). **Do not port the push as it is;** design a feed under decision 4 (nothing leaves unless the owner allows it) when the storefront is tied to the shop program. |

### I.3 Gallery and customer display

`frmGallery` ("Gallery") stores pictures in table `Gallery(ID, c1 = SN, c2 = image id, c3 = image bytes, c4 = "Display Screen Image" yes/no)`; the pictures marked for the display screen are shown on the customer-facing second monitor between sales (a slideshow of the shop's adverts), together with the bill lines and the UPI QR (`B/frmAutoUPI.vb`, `Form2`, `frmScrDsply`). `frmWalletList` lists the wallet payment names set for a till (read from `PosPrinterSetting`). Switch c14 hides the gallery menu. **Port:** a customer-display page (bill lines, total, payment code, shop pictures) is a good Hub feature for a touch counter: pictures are the customer's own files (no stock pictures), the layout is a look setting (decision 30), nothing leaves the PC.

### I.4 Camera

`FormCamera` ("Camera") and `frmCamera` ("Webcam", "Picture Preview"): capture a still from a webcam with the AForge video libraries (`SmartAvenue99 POS.vbproj:57-60`) for a customer photo, a user photo (A.5), a signature or a product picture; also used by `Ctrl+W` in the touch till. Nothing leaves the PC. **Hub:** the Hub already has a camera barcode scan page (`CameraScan.razor`, `scan.js`); a photo capture for items and people can use the same browser permission; a person's photo is `PERSONAL`, kept on the main PC.

### I.5 Image reader and PDF reader (AI)

| Screen | What it sends | Model | Result |
|---|---|---|---|
| `frmImageReader` (314 lines) | one product photo as base64 | OpenAI `gpt-4o` | the product name only ("extracts product names from images") |
| `frmPdfReader` (1,369 lines) | an invoice image or a PDF page as base64 | `gpt-4o` | a JSON list of items (serial no, product name, HSN code, quantity, rate and so on) to fill a purchase entry; fields "MRP(%) of Rate" help set the MRP |
| Quick add in the touch till (`frmPOSNewTuch.vb:27925`) | a product photo | `gpt-4o-mini` | text on the image or, if none, the main object's name |
| Customer and supplier forms (`frmCustomer.vb:3470`, `frmSupplier.vb:2947`) | an invoice image | `gpt-4o-mini` | the buyer (or seller) details extracted from the invoice |
| E-mail dashboard | the subject line | `gpt-3.5-turbo` | a drafted letter (F.3) |

All use the key and address in `tbl_api_setting` (`GetApiDtl`: `id, url, apikey, isDefault, isEnabled`); the key is in plain text in the table. **Port rule:** these become Hub tasks through the existing AI routing (`Ai/Routing.cs`): a supplier-invoice image is `FINANCIAL` and `PERSONAL`, so it runs on a local model by default and goes online only if the owner turned on an online service and gave permission for that data class and feature; never in the checkout path; the result is a proposal the person confirms (CLAUDE.md section 15: the assistant only recommends). A prompt that names a country's tax code (HSN) belongs in the country pack.

### I.6 Calculators and cash tools

| Tool | File | What it does |
|---|---|---|
| Calculator | `Calculator` (1,195 lines) | An on-screen four-function calculator. Junk to port (the operating system has one). |
| GST Calculator | `GSTCalculator` | Amount and GST % in, two columns out: **tax included in the amount** and **tax excluded** (rule below). |
| Output Tax (Sales), Input Tax (Purchase) | `frmGSTCalc`, `frmGSTCalc1` | "Search by Sales Invoice Date" (From, To), GetData, Export Excel: a rate-wise tax table for the date range built by one dynamic pivot query (`B/frmGSTCalc.vb:343`); the purchase twin does the same for purchases. Not read line by line; the tax reports and GSTR forms are in `docs/old-programs/03-india-tax-and-staff.md`. |
| Cash Refund Calculator | `Cashrefund` | Received cash minus the bill amount = change to give (`TextBox3 = Val(TextBox1) - Val(TextBox2)`). |
| Cash Denominator | `Denomination` | Count notes and coins: for each of 2000, 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1 a count box, the amount (count times denomination), and a grand total of the notes and of the currency. Nothing is saved. |
| Sale amount adjuster | `frmSaleAmtCal` ("Item's Adjustable Amount") | A small dialog on the till: shows price, tax type, total tax % and total discount, and lets the cashier enter an adjustable line amount (not read further). |
| Broker calculator | `frmBrokerCalc` | A voucher number (default prefix "EXP" from the invoice-code table, D.3 row 12) and a broker commission figure; ties to the broker ledger (`frmBroker`, `frmBrokerLedger`, 02). |
| On-screen keyboards | `frmKeyBord`, `frmKeyBordProduct`, and the sign-in "OnScreen Keyboard" button (starts `osk.exe`) | Touch input. The Hub is a browser page: the browser or the operating system supplies the keyboard. Junk. |

### I.7 Catalogue, banner and image tools

`frmBanarCreate` and `frmProductImageMaker` (both captioned "Product Catalogue - cum - Image Update") build a printed or shareable catalogue page from `Temp_Stock` lots with a chosen catalogue style (`CatalogStyle`, B.2) and the report `CryCatalogue`; `frmProductImageUpdator` and `frmOnlineImage` ("Online Image Library") update a product's picture in `Product_Join` from the computer's files (a file-open filter for images was seen; an internet image search was not found in the code read). `frmInvoicePhoto` stores a picture against a bill (`Update InvImg set Image=@d1 where ID=@d2`). **Port:** product pictures per item and a printable catalogue are Hub-sized features for later; the catalogue style and wording are the customer's data.

### I.8 Staff-only and legacy screens met here

`FrmApp` ("Auto WhatsApp Launcher (Rel. 17)", 463 lines, F), `Receiver` (2,034 lines, "Company ID": the **head-office view**, below), `frmMine` (1,042 lines, caption "Form1"; a text-formatting editor with font, alignment and colour menus; purpose not found), `frmAbout` ("License Registered To", a Download link), `frmSplash` (the start-up window with the licence read, edited by the owner earlier), `frmLoading`, `frmYesNo`, `frmCustomDialog`, `frmCustomDialog1` to `3` (59-line pop-ups with an image), `frmSystemInfo` (D.1).

**Head-office view (`Receiver`).** Given a company id it reads the other company's name, address, state and GSTIN, and its figures from the cloud feed (F.3) and shows **Today's** sales, purchase, sale return, purchase return, receipt, payment, service advance, service amount, income, expenses, cash-in-hand and cash-in-bank, and the same **Total** for the financial year (`B/Receiver.vb:488-520`, titles `TodayTitle1..12`, `FYTitle..`). This is a **totals-only** multi-store view, the same shape as decision 12; the old way sends it through a cloud database the previous vendor ran.

### I.9 Worked test examples (by hand; none run)

- **TV-I1 (GST calculator, tax included).** Amount 118.00, GST 18%: base = 118 x 100 / 118 = 100.00; tax = 118 - 100 = 18.00; CGST = 9.00; SGST = 9.00; IGST = 18.00. Tax excluded for the same amount: total = 118 + 118 x 18 / 100 = 139.24; tax = 21.24; CGST = SGST = 10.62 (`B/GSTCalculator.vb:252-290`; every figure is rounded to 2 places with half-to-even on the unrounded double, then shown as "0.00").
- **TV-I2 (rounding of the halves).** Amount 100.00, GST 5%, tax included: base = 100 x 100 / 105 = 95.238095, shown 95.24; tax = 100 - 95.238095 = 4.761905, shown 4.76; CGST and SGST are each 2.380952 shown 2.38 (so 2.38 + 2.38 = 4.76, equal to the tax here; with other amounts the two halves can differ from the tax by 0.01 because each is rounded separately; not worked for a tie because double-precision ties depend on the binary form).
- **TV-I3 (denominations).** 3 notes of 500, 2 of 100 and 4 of 10: 1,500 + 200 + 40 = 1,740 grand total (count x denomination, summed).
- **TV-I4 (cash refund).** Received 500, bill 463.50: change 36.5 (shown without a fixed number of decimals).
- **TV-I5 (E-com address).** Product "Tea 250 g" with a name containing a space and price 125.00: the address contains `pname=Tea 250 g` unencoded; a name with `&` would cut the parameters (as in F.6 TV-F4).
- **TV-I6 (AI reader gate).** In the old program the only gate is that `tbl_api_setting` has a row with `isDefault = "Yes"` and `isEnabled = "Yes"`; nothing asks per picture, nothing records which picture was sent.

### I.10 What the Hub has and what to port

| Extra | Hub today | Verdict |
|---|---|---|
| UPI QR | none (payments recorded by method) | Later, as a country-pack payment-code format shown on a customer display; not a provider (decision 13). |
| E-Com push | storefront has its own data | Do not port; design a feed under decision 4. |
| Gallery and second-screen display | none | Worth porting (customer display). |
| Camera | camera barcode scan exists | Port photo capture for items and people later. |
| Image / PDF reader | AI routing foundation exists | Port as local-first AI tasks with owner consent, after purchases can be saved as drafts. |
| GST calculator | none (the tax engine does the same arithmetic per line) | Drop; the engine is the one source. |
| Cash refund calculator | change is shown on the sell screen | Already covered. |
| Denomination counter | none | Small useful tool for day close; denominations from the country pack. |
| Calculator, keyboards | browser/OS | Drop. |
| Head-office view | none | Decision 12 (opt-in totals only), not built. |

### I.11 Not understood (topic I)

- The QR text built by `UPI.Generate` and which library provides it.
- What `DevNet.PhonePe` called (the screen is a shell around an obfuscated library).
- Whether `frmOnlineImage` fetches images from the internet (no address was found in the code read).
- What `frmSaleAmtCal` changes on the till line; what `frmMine` is for; what `frmKeyBord` and `frmKeyBordProduct` look like and where they open from.
- The exact columns of the pivot tables in `frmGSTCalc` and `frmGSTCalc1` (they were read only by caption and the shape of the query).

## J. The "left over, not grouped" screens (not yet written)

## K. Not understood (whole file) and what was not read

(written last)
