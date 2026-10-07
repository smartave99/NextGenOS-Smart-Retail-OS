# Old Windows POS, study 04: users, printing, backup, settings, language, messages, small CRM, branches, extras

**Status (7 October 2026): IN PROGRESS. The skeleton is saved; topics are filled one at a time and saved after each. Topics done so far: A.** Nothing here was run: it was read from the source (a read-only study; nothing was built or run). The source is the owner's own (`docs/PLATFORM-DECISIONS.md`, decision 27).

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
- **Search types:** Product Name, Category, Barcode, Part No, HSNC, Batch, Size, Colour (a drop-down, `Designer:170`). Buttons "B-1" and "B-2" (the second reads a different barcode source; not followed up).
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
- **TV-B6 (name line).** A line "Phone X" with IMEI(1) 123 and IMEI(2) 456 prints as "Phone X", new line, "IMEI(1): 123" and the second IMEI as the code builds it (the exact join text was cut off in the read; not copied).

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

## C. Backup and restore, database tools (not yet written)

## D. Shortcut keys and the till's settings screens (not yet written)

## E. Language conversion and transliteration (not yet written)

## F. Messages: WhatsApp, SMS, email, chat, broadcast (not yet written)

## G. Leads, follow-up, support, reminders (not yet written)

## H. Branches, companies, financial-year change, transfers (not yet written)

## I. UPI QR, online-shop link, gallery, camera, image reader, calculator and other extras (not yet written)

## J. The "left over, not grouped" screens (not yet written)

## K. Not understood (whole file) and what was not read

(written last)
