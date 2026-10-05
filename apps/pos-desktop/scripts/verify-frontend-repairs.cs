using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class FrontendRepairProof {
    [DllImport("user32.dll")] static extern bool PrintWindow(IntPtr hwnd, IntPtr dc, uint flags);
    delegate bool WindowVisitor(IntPtr hwnd, IntPtr parameter);
    [DllImport("kernel32.dll")] static extern uint GetCurrentThreadId();
    [DllImport("user32.dll")] static extern bool EnumThreadWindows(uint thread, WindowVisitor visitor, IntPtr parameter);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)] static extern int GetWindowText(IntPtr hwnd, System.Text.StringBuilder text, int limit);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)] static extern int GetClassName(IntPtr hwnd, System.Text.StringBuilder text, int limit);
    [DllImport("user32.dll")] static extern IntPtr SendMessage(IntPtr hwnd, uint message, IntPtr value, IntPtr parameter);
    static readonly BindingFlags Members = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
    static Type theme, ui, advanced;
    static string output;
    static StreamWriter cases;
    static int failures;

    static IEnumerable<Control> Tree(Control parent) {
        yield return parent;
        foreach (Control child in parent.Controls) foreach (Control item in Tree(child)) yield return item;
    }
    static Control Get(Form form, string name) { return (Control)form.GetType().GetProperty(name, Members).GetValue(form, null); }
    static string Name(Control control) { return control.Name.Length > 0 ? control.Name : control.GetType().Name; }
    static Color Tone(string name) { return (Color)ui.GetMethod("Tone").Invoke(null, new object[] { name }); }
    static bool OwnVisible(Control control) { return (bool)advanced.GetMethod("OwnVisible").Invoke(null, new object[] { control }); }
    static string Clean(string value) { return value.Replace("\r", " ").Replace("\n", " ").Replace("\t", " "); }
    static void Claim(string id, bool pass, string expected, string actual, string artifact) {
        if (!pass) failures++;
        cases.WriteLine(Clean(id) + "\t" + (pass ? "passed" : "failed") + "\t" + Clean(expected) + "\t" + Clean(actual) + "\t" + artifact);
        cases.Flush();
        Console.WriteLine((pass ? "PASS " : "FAIL ") + id + ": " + actual);
    }
    static void Capture(Form form, string file) {
        Application.DoEvents();
        using (var bitmap = new Bitmap(form.Width, form.Height)) using (var graphics = Graphics.FromImage(bitmap)) {
            var dc = graphics.GetHdc();
            bool ok = PrintWindow(form.Handle, dc, 2);
            graphics.ReleaseHdc(dc);
            if (!ok) throw new InvalidOperationException("Native PrintWindow failed");
            bitmap.Save(file);
        }
    }
    static bool FitsViewport(Control control) {
        var bounds = control.RectangleToScreen(control.ClientRectangle);
        for (Control parent = control.Parent; parent != null; parent = parent.Parent)
            if (!parent.ClientRectangle.Contains(parent.RectangleToClient(bounds))) return false;
        return true;
    }
    static bool FitsContent(Control control) {
        var bounds = control.RectangleToScreen(control.ClientRectangle);
        for (Control parent = control.Parent; parent != null; parent = parent.Parent) {
            var scroll = parent as ScrollableControl;
            if (scroll != null && scroll.AutoScroll) return true;
            if (!parent.ClientRectangle.Contains(parent.RectangleToClient(bounds))) return false;
        }
        return true;
    }
    static Control HitArea(Control control) {
        for (Control ancestor = control.Parent; ancestor != null; ancestor = ancestor.Parent)
            if (ancestor.GetType().Name == "FieldFrame") return ancestor;
        return control;
    }
    static void Targets(Control parent, string prefix, string artifact) {
        foreach (Control control in Tree(parent)) {
            if (!control.Visible || !control.Enabled || !(control is Button || control is LinkLabel || control is TextBoxBase || control is ComboBox || control is DateTimePicker || control is CheckBox || control is RadioButton)) continue;
            var text = control as TextBoxBase;
            if (text != null && text.ReadOnly) continue;
            Control hit = HitArea(control);
            Claim(prefix + ".target." + Name(control), hit.Width >= 44 && hit.Height >= 44,
                  "Effective target >=44x44 logical pixels", Name(control) + " effective " + hit.Width + "x" + hit.Height, artifact);
        }
    }
    static List<Control> TabCycle(Form form) {
        var sequence = new List<Control>();
        form.ActiveControl = null;
        for (int i = 0; i < 40; i++) {
            if (!form.SelectNextControl(form.ActiveControl, true, true, true, true)) break;
            Control focused = Tree(form).FirstOrDefault(c => c.Focused);
            if (focused == null || sequence.Contains(focused)) break;
            sequence.Add(focused);
        }
        return sequence;
    }
    static void Prepare(Form form) {
        foreach (var property in form.GetType().GetProperties(Members)) if (property.PropertyType == typeof(System.Windows.Forms.Timer)) {
            var timer = (System.Windows.Forms.Timer)property.GetValue(form, null);
            if (timer != null) timer.Stop();
        }
        form.ShowInTaskbar = false;
        form.WindowState = FormWindowState.Normal;
        form.Show();
    }
    static void Login(Assembly assembly, string mode) {
        using (var form = (Form)Activator.CreateInstance(assembly.GetType("BillPoint.frmLogin"))) {
            Prepare(form);
            theme.GetMethod("RebuildForm").Invoke(null, new object[] { form });
            var show = (Button)Get(form, "Button5");
            var hide = (Button)Get(form, "Button4");
            var sequence = TabCycle(form);
            string trace = Path.Combine(output, "login-" + mode + "-keyboard.txt");
            File.WriteAllLines(trace, sequence.Select(c => Name(c)).ToArray());
            Claim("frmLogin." + mode + ".show_password_keyboard", sequence.Contains(show), "Show password reachable using Tab", "Tab reached Show=" + sequence.Contains(show), trace);
            show.PerformClick();
            sequence = TabCycle(form);
            File.AppendAllLines(trace, new[] { "Hide cycle:" }.Concat(sequence.Select(c => Name(c))).ToArray());
            Claim("frmLogin." + mode + ".hide_password_keyboard", sequence.Contains(hide), "Hide password reachable using Tab", "Tab reached Hide=" + sequence.Contains(hide), trace);
            hide.PerformClick();
            string shot = Path.Combine(output, "login-" + mode + "-native.png");
            Capture(form, shot);
            var options = (Button)form.Controls.Find("RetailToggleStoreOptions", true)[0];
            var settings = form.Controls.Find("RetailStoreOptions", true)[0];
            Claim("frmLogin." + mode + ".simple_entry", !settings.Visible && Get(form, "OK").Visible && Get(form, "btnRecoveryPassword").Visible,
                  "Sign in and recovery visible, store administration collapsed", "options visible=" + settings.Visible, shot);
            options.PerformClick();
            Application.DoEvents();
            Claim("frmLogin." + mode + ".store_options_reachable", settings.Visible && Get(form, "btnCompany").Visible && Get(form, "cmbLang").Visible,
                  "Store options reveal original administration and language controls", "options visible=" + settings.Visible, shot);
            Targets(settings, "frmLogin_options." + mode, shot);
            Capture(form, Path.Combine(output, "login-" + mode + "-options-native.png"));
        }
    }
    static void CartStyles(DataGridView grid, DataGridViewRow row, string mode, string artifact) {
        var token = (Font)ui.GetMethod("TypeFont").Invoke(null, new object[] { "subhead" });
        foreach (string column in new[] { "Column3", "Column4", "Column5", "Column6" }) {
            var style = row.Cells[column].InheritedStyle;
            Claim("grid." + mode + "." + column + ".font", style.Font.Equals(token), "Inherited font matches declared subhead token", style.Font.ToString(), artifact);
            bool colors = style.BackColor == Tone("surface") && style.ForeColor == Tone("label") && style.SelectionBackColor == Tone("selection") && style.SelectionForeColor == Tone("label");
            Claim("grid." + mode + "." + column + ".palette", colors, "Inherited colors match active surface/label/selection", "back=" + style.BackColor + "; fore=" + style.ForeColor + "; selected=" + style.SelectionBackColor, artifact);
        }
    }
    static void Home(Assembly assembly, string mode) {
        using (var form = (Form)Activator.CreateInstance(assembly.GetType("BillPoint.frmMainMenu"))) {
            Prepare(form);
            var menu = (MenuStrip)Get(form, "MenuStrip2");
            ToolStripItem[] originals = menu.Items.Cast<ToolStripItem>().ToArray();
            var flags = originals.ToDictionary(item => item, item => Tuple.Create(item.Available, item.Enabled));
            theme.GetMethod("RebuildForm").Invoke(null, new object[] { form });
            form.Size = form.MinimumSize;
            Application.DoEvents();
            var tabs = (TabControl)form.Controls.Find("RetailWorkspace", true)[0];
            var cards = form.Controls.Find("RetailTaskResults", true)[0];
            string shot = Path.Combine(output, "home-" + mode + "-minimum-native.png");
            Capture(form, shot);
            Claim("home." + mode + ".focused_entry", tabs.SelectedIndex == 0 && cards.Controls.Count == 6 && !menu.Visible,
                  "Home opens with six tasks and one command navigation action", "tasks=" + cards.Controls.Count + "; menu visible=" + menu.Visible, shot);
            foreach (Control card in cards.Controls) Claim("home." + mode + ".card_" + card.Name, FitsViewport(card), "Everyday task visible at minimum window", card.Bounds.ToString(), shot);
            Targets(tabs.TabPages[0], "home." + mode, shot);
            ((Button)form.Controls.Find("RetailAllCommands", true)[0]).PerformClick();
            Application.DoEvents();
            Claim("home." + mode + ".all_commands", tabs.SelectedIndex == 1 && menu.Visible && FitsViewport(menu),
                  "Browse all commands reveals the original menu", "menu visible=" + menu.Visible + "; tab=" + tabs.SelectedIndex, shot);
            Claim("home." + mode + ".original_menu_roles", originals.All(item => menu.Items.Contains(item) && item.Available == flags[item].Item1 && item.Enabled == flags[item].Item2),
                  "Original top-level command instances and permission flags retained", "items=" + originals.Length, shot);
            Capture(form, Path.Combine(output, "home-" + mode + "-commands-native.png"));
            ((Button)form.Controls.Find("RetailBackHome", true)[0]).PerformClick();
            Claim("home." + mode + ".return_home", tabs.SelectedIndex == 0 && cards.Visible, "Back to Home restores the task launcher", "tab=" + tabs.SelectedIndex, shot);
        }
    }
    static void Sale(Assembly assembly, string mode, bool minimum) {
        string scenario = mode + (minimum ? "-minimum" : "-client");
        using (var form = (Form)Activator.CreateInstance(assembly.GetType("BillPoint.frmPOS"))) {
            Prepare(form);
            var originals = Tree(form).Where(c => c.Name.Length > 0).ToArray();
            var visibility = originals.ToDictionary(c => c, OwnVisible);
            var enabled = originals.ToDictionary(c => c, c => c.Enabled);
            theme.GetMethod("RebuildForm").Invoke(null, new object[] { form });
            var layoutEnabledChanges = originals.Where(c => c.Enabled != enabled[c]).ToArray();
            if (minimum) form.Size = form.MinimumSize; else form.ClientSize = new Size(1024, 720);
            Application.DoEvents();
            string trace = Path.Combine(output, "sale-" + scenario + "-trace.txt");
            File.WriteAllText(trace, "Outer=" + form.Size + "; client=" + form.ClientSize + "\n");
            var tabs = (TabControl)form.Controls.Find("RetailWorkspace", true)[0];
            var grid = (DataGridView)Get(form, "DataGridView1");
            ((ComboBox)Get(form, "cmbCustomerName")).Items.Add("Sample customer");
            ((ComboBox)Get(form, "cmbCustomerName")).SelectedIndex = 0;
            Get(form, "txtContactNo").Text = "9876543210";
            ((ComboBox)Get(form, "cmbCustomerState")).Items.Add("Sample state");
            ((ComboBox)Get(form, "cmbCustomerState")).SelectedIndex = 0;
            int index = grid.Rows.Add();
            var row = grid.Rows[index];
            row.Cells["Column3"].Value = "Synthetic product with a long descriptive name";
            row.Cells["Column4"].Value = 12;
            row.Cells["Column5"].Value = "12,345.67";
            row.Cells["Column6"].Value = "1,48,148.04";
            for (int added = 0; added < 3; added++) {
                int next = grid.Rows.Add();
                grid.Rows[next].Cells["Column3"].Value = "Sample item " + (added + 2);
                grid.Rows[next].Cells["Column4"].Value = 1;
                grid.Rows[next].Cells["Column5"].Value = "100.00";
                grid.Rows[next].Cells["Column6"].Value = "100.00";
            }
            Get(form, "txtGrandTotal").Text = "1,48,448.04";
            Get(form, "txtSubTotal").Text = "1,48,448.04";
            Get(form, "txtPaymentDue").Text = "1,48,448.04";
            Get(form, "txtTotalPayment").Text = "0.00";
            grid.ClearSelection();
            string shot = Path.Combine(output, "sale-" + scenario + "-populated-native.png");
            Capture(form, shot);
            // The original CellFormatting handler locks customer details when a cart is painted.
            var populatedEnabled = originals.ToDictionary(c => c, c => c.Enabled);
            int visibleRow = grid.GetRowDisplayRectangle(index, true).Height;
            Claim("frmPOS." + scenario + ".populated_cart", grid.Visible && visibleRow >= 48 && FitsViewport(grid), "Complete 48px cart row visible", "visible row=" + visibleRow + "; grid=" + grid.Bounds, trace);
            Claim("frmPOS." + scenario + ".four_cart_rows", grid.ClientSize.Height - grid.ColumnHeadersHeight >= 48 * 4 && Enumerable.Range(0, 4).All(item => grid.GetRowDisplayRectangle(item, true).Height == 48),
                  "Cart has room for at least four complete 48px rows", "grid client=" + grid.ClientSize + "; header=" + grid.ColumnHeadersHeight, trace);
            Flow(form, tabs, grid, scenario, trace);
            CartStyles(grid, row, mode + (minimum ? "-minimum" : ""), trace);
            var history = Get(form, "dgwsale");
            history.Visible = true;
            Application.DoEvents();
            Claim("frmPOS." + scenario + ".price_history_visible", history.Visible && FitsViewport(history) && history.Parent == tabs.TabPages[0], "Requested history appears and fits on New sale", "visible=" + history.Visible + "; bounds=" + history.Bounds, trace);
            Capture(form, Path.Combine(output, "sale-" + scenario + "-history-native.png"));
            history.Visible = false;
            tabs.SelectedIndex = 2;
            Get(form, "PanelUPI").Visible = true;
            Application.DoEvents();
            var upi = Get(form, "PanelUPI");
            Claim("frmPOS." + scenario + ".upi_from_tools", tabs.SelectedIndex == 1 && upi.Visible && FitsViewport(upi), "UPI request from Invoice tools opens visible fitting payment overlay", "tab=" + tabs.SelectedIndex + "; visible=" + upi.Visible + "; bounds=" + upi.Bounds, trace);
            Targets(upi, "frmPOS_upi." + scenario, trace);
            var clipped = Tree(upi).Where(c => c.Visible && (c.GetType().Name == "FieldFrame" || c is Button || c is LinkLabel || c is Label)).Where(c => !FitsContent(c)).ToArray();
            string clippedDetails = string.Join("; ", clipped.Select(c => Name(c) + " input=" + string.Join(",", Tree(c).Select(Name).ToArray()) + " bounds=" + c.Bounds + " parent=" + c.Parent.ClientRectangle).ToArray());
            File.AppendAllText(trace, "UPI clipping: " + clippedDetails + "\n");
            Claim("frmPOS." + scenario + ".upi_content_fits", clipped.Length == 0, "UPI fields and actions fit non-scrolling containers", clippedDetails, trace);
            Capture(form, Path.Combine(output, "sale-" + scenario + "-upi-native.png"));
            upi.Visible = false;
            tabs.SelectedIndex = 2;
            Application.DoEvents();
            var groups = (TabControl)form.Controls.Find("RetailToolGroups", true)[0];
            foreach (TabPage group in groups.TabPages) {
                groups.SelectedTab = group;
                Application.DoEvents();
                Targets(group, "frmPOS_tools." + scenario + "." + group.Text.Replace(" ", "_"), trace);
                clipped = Tree(group).Where(c => c.Visible && (c is Label || c is Button || c.GetType().Name == "FieldFrame")).Where(c => !FitsContent(c)).ToArray();
                Claim("frmPOS." + scenario + ".tools_" + group.Text.Replace(" ", "_") + "_content_fits", clipped.Length == 0, "Advanced captions and targets fit non-scrolling containers", string.Join(", ", clipped.Select(Name).ToArray()), trace);
                File.AppendAllLines(trace, Tree(group).Where(c => c.Visible && c.Name.Length > 0).Select(c => Name(c) + " | " + c.Bounds + " | " + c.AccessibleName));
                Capture(form, Path.Combine(output, "sale-" + scenario + "-tools-" + group.Text.Replace(" ", "-") + "-native.png"));
            }
            var current = new HashSet<Control>(Tree(form));
            var missing = originals.Where(c => c.IsDisposed || !current.Contains(c)).ToArray();
            Claim("frmPOS." + scenario + ".original_controls_retained", missing.Length == 0, "Every original named control instance retained", "missing=" + string.Join(", ", missing.Select(Name).ToArray()), trace);
            Claim("frmPOS." + scenario + ".original_enabled_retained", layoutEnabledChanges.Length == 0, "Layout retains original business enabled states before synthetic cart events", string.Join(", ", layoutEnabledChanges.Select(Name).ToArray()), trace);
            var overlayEnabledChanges = originals.Where(c => c.Enabled != populatedEnabled[c]).ToArray();
            Claim("frmPOS." + scenario + ".overlay_enabled_retained", overlayEnabledChanges.Length == 0, "Opening and closing overlays retains populated cart business enabled states", string.Join(", ", overlayEnabledChanges.Select(Name).ToArray()), trace);
            var allowedHidden = new HashSet<string>(new[] { "Label3", "Label9", "Label19", "Label21", "Label18", "lblUnit", "Label17", "Label31", "Label35", "Label34", "Label59", "Label61", "Label100", "Label37", "Label113", "Label114", "Label115" });
            var changed = originals.Where(c => OwnVisible(c) != visibility[c] && !allowedHidden.Contains(c.Name) && c != upi && c != history && c != grid).ToArray();
            Claim("frmPOS." + scenario + ".original_visibility_retained", changed.Length == 0, "Original business visibility retained except replaced captions and tested overlays", string.Join(", ", changed.Select(Name).ToArray()), trace);
            // Capture the same 1280x720 client geometry as the original native advanced proof.
            if (!minimum) { form.ClientSize = new Size(1280, 720); tabs.SelectedIndex = 0; Application.DoEvents(); Capture(form, Path.Combine(output, "sale-" + mode + "-wide-native.png")); }
        }
    }
    static void Flow(Form form, TabControl tabs, DataGridView grid, string scenario, string trace) {
        var review = (Button)form.Controls.Find("RetailReviewPayment", true)[0];
        var save = Get(form, "btnSave");
        Claim("flow." + scenario + ".entry", review.Visible && !save.Visible && Get(form, "txtBarcode").Visible && Get(form, "TextBox20").Visible,
              "Cart has item entry and a payment review action", "review=" + review.Visible + "; save=" + save.Visible, trace);
        int count = grid.Rows.Count;
        string item = Convert.ToString(grid.Rows[0].Cells["Column3"].Value);
        string total = Get(form, "txtGrandTotal").Text;
        review.PerformClick();
        Application.DoEvents();
        Claim("flow." + scenario + ".save_requires_payment", !save.Visible && form.Controls.Find("RetailPaymentRequired", true)[0].Visible,
              "Payment must be recorded before Save is shown", "save visible=" + save.Visible, trace);
        Capture(form, Path.Combine(output, "sale-" + scenario + "-payment-required-native.png"));
        var payments = (DataGridView)Get(form, "DataGridView2");
        int paymentRow = payments.Rows.Add("By Cash", "100.00", DateTime.Today, "");
        Get(form, "txtTotalPayment").Text = "100.00";
        Get(form, "txtPaymentDue").Text = "1,48,348.04";
        string[] fields = { "cmbPaymentMode", "txtPayment", "dtpPaymentDate", "cmbAccountNo", "btnAdd1", "btnRemove1", "DataGridView2", "btnSave" };
        foreach (string name in fields) Claim("flow." + scenario + ".payment_" + name, Get(form, name).Visible && FitsViewport(Get(form, name)),
              "Payment control visible without scrolling", "visible=" + Get(form, name).Visible + "; bounds=" + Get(form, name).Bounds, trace);
        foreach (string name in new[] { "cmbCustomerName", "txtContactNo", "cmbCustomerState", "txtGrandTotal" })
            Claim("flow." + scenario + ".context_" + name, Get(form, name).Visible && FitsViewport(Get(form, name)), "Original customer and total remain visible during payment", "visible=" + Get(form, name).Visible, trace);
        Targets(tabs.TabPages[1], "payment." + scenario, trace);
        Capture(form, Path.Combine(output, "sale-" + scenario + "-payment-native.png"));
        ((Button)form.Controls.Find("RetailBackToCart", true)[0]).PerformClick();
        Claim("flow." + scenario + ".back_preserves_sale", tabs.SelectedIndex == 0 && grid.Rows.Count == count && Convert.ToString(grid.Rows[0].Cells["Column3"].Value) == item && Get(form, "txtGrandTotal").Text == total,
              "Back to cart retains item values and total", "tab=" + tabs.SelectedIndex + "; rows=" + grid.Rows.Count, trace);
        var shortcut = form.GetType().Assembly.GetType("BillPoint.RetailCheckoutLayouts").GetMethod("HandleShortcut");
        var key = new KeyEventArgs(Keys.F2);
        bool handled = (bool)shortcut.Invoke(null, new object[] { form, key });
        Claim("flow." + scenario + ".f2_review", handled && key.SuppressKeyPress && tabs.SelectedIndex == 1, "F2 from cart opens payment and consumes key", "handled=" + handled + "; tab=" + tabs.SelectedIndex, trace);
        handled = (bool)shortcut.Invoke(null, new object[] { form, new KeyEventArgs(Keys.F2) });
        Claim("flow." + scenario + ".f2_original_save", !handled && save.Visible, "F2 on payment is passed to the original Save handler", "handled=" + handled + "; save=" + save.Visible, trace);
        payments.Rows.RemoveAt(paymentRow);
        handled = (bool)shortcut.Invoke(null, new object[] { form, new KeyEventArgs(Keys.F2) });
        Claim("flow." + scenario + ".f2_missing_payment", handled && !save.Visible, "F2 cannot bypass the missing payment step", "handled=" + handled + "; save=" + save.Visible, trace);
        // Call only navigation: never invoke Save, payment providers or database actions.
        shortcut.Invoke(null, new object[] { form, new KeyEventArgs(Keys.F8) });
        Claim("flow." + scenario + ".f8_original_target", tabs.SelectedIndex == 2 && Get(form, "btnSelectSalesman").Visible, "F8 reveals the original salesperson action", "tab=" + tabs.SelectedIndex + "; visible=" + Get(form, "btnSelectSalesman").Visible, trace);
        foreach (var route in new[] { Tuple.Create(Keys.F3, "btnUpdate"), Tuple.Create(Keys.F4, "btnDelete"), Tuple.Create(Keys.F5, "btnGetData"), Tuple.Create(Keys.F6, "btnPrint"), Tuple.Create(Keys.F7, "btnScanItems") }) {
            shortcut.Invoke(null, new object[] { form, new KeyEventArgs(route.Item1) });
            Claim("flow." + scenario + ".shortcut_" + route.Item1, tabs.SelectedIndex == 2 && Get(form, route.Item2).Visible,
                  "Shortcut reveals its original invoice action", route.Item2 + " visible=" + Get(form, route.Item2).Visible, trace);
        }
        Claim("flow." + scenario + ".tools_return", form.Controls.Find("RetailBackToCart", true)[0].Visible && FitsViewport(form.Controls.Find("RetailBackToCart", true)[0]),
              "Tools provide a visible return action", "back visible=" + form.Controls.Find("RetailBackToCart", true)[0].Visible, trace);
        shortcut.Invoke(null, new object[] { form, new KeyEventArgs(Keys.F1) });
        Claim("flow." + scenario + ".shortcut_F1", tabs.SelectedIndex == 0 && Get(form, "btnNew").Visible,
              "F1 reveals the original New sale action on the cart", "tab=" + tabs.SelectedIndex + "; new visible=" + Get(form, "btnNew").Visible, trace);
        ConfirmStartOver(form, grid, scenario, trace);
        tabs.SelectedIndex = 0;
    }
    static void ConfirmStartOver(Form form, DataGridView grid, string scenario, string trace) {
        // Reply only to the fixture's own current-thread dialog; no keyboard/mouse injection.
        uint thread = GetCurrentThreadId();
        int count = grid.Rows.Count;
        bool answered = false;
        using (var timer = new System.Windows.Forms.Timer { Interval = 100 }) {
            timer.Tick += (sender, args) => EnumThreadWindows(thread, (window, unused) => {
                var title = new System.Text.StringBuilder(64);
                var type = new System.Text.StringBuilder(32);
                GetWindowText(window, title, title.Capacity);
                GetClassName(window, type, type.Capacity);
                if (title.ToString() != "New sale" || type.ToString() != "#32770") return true;
                timer.Stop();
                answered = true;
                SendMessage(window, 0x111, new IntPtr(7), IntPtr.Zero); // WM_COMMAND / IDNO
                return false;
            }, IntPtr.Zero);
            timer.Start();
            bool clear = (bool)form.GetType().Assembly.GetType("BillPoint.RetailCheckoutLayouts").GetMethod("ConfirmNewSale").Invoke(null, new object[] { form });
            Claim("flow." + scenario + ".cancel_new_sale", answered && !clear && grid.Rows.Count == count,
                  "Choosing No prevents the reset and retains the populated cart", "answered=" + answered + "; clear=" + clear + "; rows=" + grid.Rows.Count, trace);
        }
    }
    [STAThread] public static int Main(string[] args) {
        string root = Path.GetFullPath(args[0]);
        output = Path.GetFullPath(args[1]);
        if (Directory.Exists(output)) throw new InvalidOperationException("Choose a new proof directory; existing evidence is preserved");
        Directory.CreateDirectory(output);
        AppDomain.CurrentDomain.AssemblyResolve += (sender, eventArgs) => {
            string name = new AssemblyName(eventArgs.Name).Name + ".dll";
            foreach (string folder in new[] { root, Path.GetFullPath("Original_Binaries") }) {
                string path = Path.Combine(folder, name);
                if (File.Exists(path)) return Assembly.LoadFrom(path);
            }
            return null;
        };
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        var assembly = Assembly.LoadFrom(Path.Combine(root, "SmartAvenue99 POS.exe"));
        theme = assembly.GetType("BillPoint.AppleUITheme");
        ui = assembly.GetType("BillPoint.RetailUI");
        advanced = assembly.GetType("BillPoint.RetailAdvancedLayouts");
        theme.GetProperty("IsCapturing").SetValue(null, true, null);
        using (cases = new StreamWriter(Path.Combine(output, "cases.tsv"))) {
            cases.WriteLine("id\tstatus\texpected\tactual\tartifact");
            foreach (bool dark in new[] { false, true }) {
                string mode = dark ? "dark" : "light";
                ui.GetProperty("IsDark").SetValue(null, dark, null);
                Login(assembly, mode);
                Home(assembly, mode);
                Sale(assembly, mode, false);
                Sale(assembly, mode, true);
            }
        }
        Console.WriteLine("Repair regression failures=" + failures);
        return failures == 0 ? 0 : 1;
    }
}
