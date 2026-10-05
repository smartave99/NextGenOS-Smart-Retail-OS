using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

public class WorkspaceProof {
    static readonly BindingFlags Instance = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
    static readonly MethodInfo State = typeof(Control).GetMethod("GetState", Instance);
    static StreamWriter cases;
    static string output;
    static int failures;
    [DllImport("user32.dll")] static extern bool PrintWindow(IntPtr window, IntPtr dc, uint flags);
    delegate bool WindowVisitor(IntPtr window, IntPtr parameter);
    [DllImport("kernel32.dll")] static extern uint GetCurrentThreadId();
    [DllImport("user32.dll")] static extern bool EnumThreadWindows(uint thread, WindowVisitor visitor, IntPtr parameter);
    [DllImport("user32.dll", CharSet=CharSet.Unicode)] static extern int GetClassName(IntPtr window, StringBuilder text, int capacity);
    [DllImport("user32.dll")] static extern IntPtr SendMessage(IntPtr window, uint message, IntPtr first, IntPtr second);
    static IEnumerable<Control> Tree(Control parent) {
        yield return parent;
        foreach (Control child in parent.Controls)
            foreach (Control descendant in Tree(child)) yield return descendant;
    }
    static bool Local(Control control, int state) { return (bool)State.Invoke(control, new object[] {state}); }
    static void Record(string id, bool pass, string detail) {
        cases.WriteLine(id + "\t" + (pass ? "passed" : "failed") + "\t" + detail.Replace('\t',' ').Replace('\n',' ').Replace('\r',' '));
        cases.Flush();
        if (!pass) { failures++; Console.WriteLine("FAIL " + id + " " + detail); }
    }
    static void RemoveDesignerEvents(Form form) {
        foreach (Control control in Tree(form)) {
            var events = (EventHandlerList)typeof(Component).GetProperty("Events", Instance).GetValue(control, null);
            events.Dispose(); // Clears only this fixture instance's original business event list.
        }
        var container = form.GetType().GetField("components", Instance);
        if (container == null) return;
        var components = container.GetValue(form) as IContainer;
        if (components == null) return;
        foreach (var timer in components.Components.OfType<System.Windows.Forms.Timer>()) timer.Stop();
    }
    static void Capture(Form form, string path) {
        Application.DoEvents();
        using (var bitmap = new Bitmap(form.Width, form.Height)) {
            using (var graphics = Graphics.FromImage(bitmap)) {
                IntPtr dc = graphics.GetHdc();
                bool rendered;
                try { rendered = PrintWindow(form.Handle, dc, 2); }
                finally { graphics.ReleaseHdc(dc); }
                Record(form.Name + ".native_capture." + Path.GetFileName(path), rendered, "PrintWindow on fixture-owned window");
            }
            bitmap.Save(path);
        }
    }
    static void ActivateTabs(Control control) {
        for (Control parent = control.Parent; parent != null; parent = parent.Parent) {
            var page = parent as TabPage;
            if (page != null && page.Parent is TabControl) ((TabControl)page.Parent).SelectedTab = page;
        }
        Application.DoEvents();
    }
    static bool Allowed(Control control) {
        for (Control parent = control; parent != null; parent = parent.Parent) {
            if (!(parent is TabPage) && !Local(parent, 2)) return false;
        }
        return true;
    }
    static bool Fits(Control control) {
        var bounds = control.RectangleToScreen(control.ClientRectangle);
        for (Control parent = control.Parent; parent != null; parent = parent.Parent)
            if (!parent.ClientRectangle.Contains(parent.RectangleToClient(bounds))) return false;
        return true;
    }
    static void BringIntoView(Control control) {
        for (Control parent = control.Parent; parent != null; parent = parent.Parent) {
            var scroll = parent as ScrollableControl;
            if (scroll != null && scroll.AutoScroll) scroll.ScrollControlIntoView(control);
        }
        Application.DoEvents();
    }
    static bool IsTarget(Control control) {
        return control is Button || control is TextBoxBase || control is ComboBox || control is DateTimePicker ||
               control is NumericUpDown || control is CheckBox || control is RadioButton || control is LinkLabel;
    }
    static void CheckSurface(Assembly assembly, Type type, string mode, string scale) {
        string id = type.Name + "." + mode + "." + scale;
        Console.WriteLine("BEGIN " + id);
        int dialogs=0;
        uint thread=GetCurrentThreadId();
        using(var watchdog=new System.Windows.Forms.Timer()) {
        watchdog.Interval=100;
        watchdog.Tick+=(sender,e)=>EnumThreadWindows(thread,(window,parameter)=> {
            var name=new StringBuilder(128);GetClassName(window,name,name.Capacity);
            if(name.ToString()=="#32770") {
                dialogs++;Console.WriteLine("BLOCKED INITIALIZER DIALOG "+id);
                SendMessage(window,0x10,IntPtr.Zero,IntPtr.Zero); // Cancel only the fixture's current-thread dialog.
            }
            return true;
        },IntPtr.Zero);
        watchdog.Start();
        // Designer-surface proof deliberately never runs the application's constructor or Load path.
        using (var form = (Form)FormatterServices.GetUninitializedObject(type)) {
            typeof(Form).GetConstructor(Type.EmptyTypes).Invoke(form, BindingFlags.Default, null, new object[0], null);
            // In-memory model defaults needed by designer callbacks; no COM voice, database or provider constructor.
            foreach (var field in type.GetFields(Instance | BindingFlags.DeclaredOnly)) {
                if (field.IsInitOnly || field.IsStatic) continue;
                if (field.FieldType == typeof(string)) field.SetValue(form, "");
                else if (field.FieldType == typeof(System.Data.DataSet)) field.SetValue(form, new System.Data.DataSet());
                else if (field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                    field.SetValue(form, Activator.CreateInstance(field.FieldType));
            }
            type.GetMethod("InitializeComponent", Instance).Invoke(form, null);
            Console.WriteLine("INITIALIZED " + id);
            watchdog.Stop();
            Record(id+".initializer_dialog_free",dialogs==0,"Unexpected own dialogs="+dialogs+"; callbacks before Load need isolated configuration");
            RemoveDesignerEvents(form);
            var originals = Tree(form).Where(c => c.Name.Length > 0).ToArray();
            var visible = originals.ToDictionary(c => c, c => Local(c, 2));
            var enabled = originals.ToDictionary(c => c, c => Local(c, 4));
            var columns = originals.OfType<DataGridView>().SelectMany(g => g.Columns.Cast<DataGridViewColumn>()).ToArray();
            var formats = columns.ToDictionary(c => c, c => c.DefaultCellStyle.Format);
            assembly.GetType("BillPoint.RetailLayouts").GetMethod("Apply").Invoke(null, new object[] {form});
            Console.WriteLine("APPLIED " + id);
            form.WindowState = FormWindowState.Normal;
            form.Size = new Size(1024, 720);
            if (scale != "100") form.Scale(new SizeF(float.Parse(scale) / 100f, float.Parse(scale) / 100f));
            form.ShowInTaskbar = false;
            form.Show(); Application.DoEvents();
            Console.WriteLine("SHOWN " + id);
            var tree = Tree(form).ToArray();
            Record(id + ".controls_retained", originals.All(c => tree.Contains(c)), originals.Length + " original named controls");
            var visibilityChanges = originals.Where(c => !(c is TabPage) && !(c is Form) && Local(c,2) != visible[c]).ToArray();
            Record(id + ".visibility_retained", visibilityChanges.Length == 0, "Changed: " + string.Join(",", visibilityChanges.Select(c => c.Name)));
            Record(id + ".permissions_retained", originals.All(c => Local(c,4) == enabled[c]), "Original local enabled flags");
            Record(id + ".columns_retained", columns.All(c => c.DataGridView != null && c.DefaultCellStyle.Format == formats[c]), columns.Length + " original column identities and formats");
            string shot = Path.Combine(output, id + ".png");
            Capture(form, shot);
            foreach (var control in originals.Where(c => IsTarget(c) && Allowed(c))) {
                ActivateTabs(control);
                if (!control.Visible) { Record(id + ".target_visible." + control.Name, false, "Locally visible control lost through wrapper"); continue; }
                Control hit = control.Parent != null && control.Parent.GetType().Name == "FieldFrame" ? control.Parent : control;
                BringIntoView(hit);
                Record(id + ".target_size." + control.Name, hit.Width >= 44 && hit.Height >= 44, hit.Width + "x" + hit.Height);
                Record(id + ".target_reachable." + control.Name, Fits(hit), "Fits after scroll/tab activation: " + hit.Bounds);
                Record(id + ".accessible_name." + control.Name, !string.IsNullOrWhiteSpace(control.AccessibilityObject.Name), "Native accessible name: " + control.AccessibilityObject.Name);
            }
            Console.WriteLine("SURFACE " + id + " " + originals.Length);
        }
        }
    }
    [STAThread] public static int Main(string[] args) {
        string root = Path.GetFullPath(args[0]);
        output = Path.GetFullPath(args[1]); Directory.CreateDirectory(output);
        AppDomain.CurrentDomain.AssemblyResolve += (sender,e) => {
            string file = new AssemblyName(e.Name).Name + ".dll";
            foreach (string dir in new[] {root, Path.Combine(Environment.CurrentDirectory,"Original_Binaries")}) {
                string path = Path.Combine(dir, file);
                if (File.Exists(path)) return Assembly.LoadFrom(path);
            }
            return null;
        };
        Application.EnableVisualStyles(); Application.SetCompatibleTextRenderingDefault(false);
        var assembly = Assembly.LoadFrom(Path.Combine(root,"SmartAvenue99 POS.exe"));
        assembly.GetType("BillPoint.AppleUITheme").GetProperty("IsCapturing").SetValue(null,true,null);
        var types = assembly.GetTypes().Where(t => t.Namespace == "BillPoint" && t.IsSubclassOf(typeof(Form)) &&
            t.GetMethod("InitializeComponent",Instance) != null).OrderBy(t => t.Name).ToArray();
        File.WriteAllLines(Path.Combine(output,"surface-inventory.txt"), types.Select(t => t.FullName));
        string filter = args.Length > 2 ? args[2] : "";
        using (cases = new StreamWriter(Path.Combine(output,"cases.tsv"))) {
            cases.WriteLine("id\tstatus\tdetail");
            foreach (string mode in new[] {"light", "dark"}) {
                assembly.GetType("BillPoint.RetailUI").GetProperty("IsDark").SetValue(null,mode == "dark",null);
                foreach (Type type in types.Where(t => filter.Length == 0 || (filter.StartsWith("=") ? t.Name == filter.Substring(1) : t.Name.IndexOf(filter,StringComparison.OrdinalIgnoreCase) >= 0))) {
                    if (new[] {"frmSplash","frmLogin","frmMainMenu","frmPOS","frmSqlServerSetting"}.Contains(type.Name)) continue;
                    try { CheckSurface(assembly,type,mode,"100"); }
                    catch (Exception e) {
                        Record(type.Name + "." + mode + ".render", false, e.GetBaseException().Message);
                        File.WriteAllText(Path.Combine(output,type.Name + "-" + mode + "-exception.txt"),e.ToString());
                    }
                }
            }
        }
        Console.WriteLine("FAILED " + failures);
        return failures == 0 ? 0 : 1;
    }
}
