using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Windows.Forms;

public class CommandBrowserProof {
    static readonly BindingFlags Instance = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
    static IEnumerable<ToolStripMenuItem> Items(ToolStripMenuItem item) {
        yield return item;
        foreach (ToolStripMenuItem child in item.DropDownItems.OfType<ToolStripMenuItem>())
            foreach (var descendant in Items(child)) yield return descendant;
    }
    static bool CanRun(ToolStripItem item) {
        return item != null && item.Available && item.Enabled && (item.OwnerItem == null || CanRun(item.OwnerItem));
    }
    static void ClearEvents(Component component) {
        ((EventHandlerList)typeof(Component).GetProperty("Events",Instance).GetValue(component,null)).Dispose();
    }
    static int failures;
    static StreamWriter cases;
    static void Check(string id, bool result, string detail) {
        cases.WriteLine(id + "\t" + (result ? "passed" : "failed") + "\t" + detail.Replace('\t',' ')); cases.Flush();
        if (!result) { failures++; Console.WriteLine("FAIL " + id + " " + detail); }
    }
    [STAThread] public static int Main(string[] args) {
        string root=Path.GetFullPath(args[0]), output=Path.GetFullPath(args[1]); Directory.CreateDirectory(output);
        AppDomain.CurrentDomain.AssemblyResolve += (s,e) => {
            string file=new AssemblyName(e.Name).Name+".dll";
            foreach (string dir in new[]{root,Path.Combine(Environment.CurrentDirectory,"Original_Binaries")}) {
                string path=Path.Combine(dir,file); if(File.Exists(path)) return Assembly.LoadFrom(path);
            }
            return null;
        };
        Application.EnableVisualStyles(); Application.SetCompatibleTextRenderingDefault(false);
        var assembly=Assembly.LoadFrom(Path.Combine(root,"SmartAvenue99 POS.exe"));
        assembly.GetType("BillPoint.AppleUITheme").GetProperty("IsCapturing").SetValue(null,true,null);
        using(cases=new StreamWriter(Path.Combine(output,"cases.tsv"))) {
            cases.WriteLine("id\tstatus\tdetail");
            foreach(string mode in new[]{"light","dark"}) {
                assembly.GetType("BillPoint.RetailUI").GetProperty("IsDark").SetValue(null,mode=="dark",null);
                using(var form=(Form)Activator.CreateInstance(assembly.GetType("BillPoint.frmMainMenu"))) {
                    var menu=(MenuStrip)form.GetType().GetProperty("MenuStrip2",Instance).GetValue(form,null);
                    var all=menu.Items.OfType<ToolStripMenuItem>().SelectMany(i=>Items(i)).ToArray();
                    var leaves=all.Where(i=>i.DropDownItems.Count==0).ToArray();
                    foreach(var item in all) ClearEvents(item); // Prevent SQL, printing or provider effects in the routing fixture.
                    var calls=leaves.ToDictionary(i=>i,i=>0);
                    foreach(var item in leaves) { var original=item; item.Click+=(s,e)=>calls[original]++; }
                    assembly.GetType("BillPoint.RetailLayouts").GetMethod("Apply").Invoke(null,new object[]{form});
                    form.WindowState=FormWindowState.Normal;form.Size=new Size(1024,720);form.ShowInTaskbar=false;
                    form.Show();Application.DoEvents();
                    ((Button)form.Controls.Find("RetailAllCommands",true)[0]).PerformClick();
                    var grid=(DataGridView)form.Controls.Find("RetailCommandList",true)[0];
                    var open=(Button)form.Controls.Find("RetailOpenCommand",true)[0];
                    var search=(TextBox)form.Controls.Find("RetailCommandSearch",true)[0];
                    var category=(ComboBox)form.Controls.Find("RetailCommandCategory",true)[0];
                    Func<ToolStripMenuItem,bool> contains=item=>grid.Rows.Cast<DataGridViewRow>().Any(r=>r.Tag==item);
                    Check(mode+".full_inventory",grid.Rows.Count==leaves.Count(CanRun),"original leaves="+leaves.Length+"; available="+grid.Rows.Count);
                    foreach(var item in leaves) {
                        string id=mode+"."+item.Name;
                        bool enabled=item.Enabled,available=item.Available;
                        Check(id+".discoverable",contains(item)==CanRun(item),"Original command identity appears exactly when its ancestry permits");
                        if(CanRun(item)) {
                            var row=grid.Rows.Cast<DataGridViewRow>().First(r=>r.Tag==item);
                            grid.CurrentCell=row.Cells[0];Application.DoEvents();
                            int before=calls[item];open.PerformClick();
                            Check(id+".routes_to_original",calls[item]==before+1,"Before="+before+"; after="+calls[item]+"; Open enabled="+open.Enabled+"; visible="+open.Visible+"; selected="+(grid.CurrentRow == null ? "none" : ((ToolStripMenuItem)grid.CurrentRow.Tag).Name));
                        }
                        item.Enabled=false;Application.DoEvents();
                        Check(id+".disabled_excluded",!contains(item),"Disabled command removed immediately");
                        item.Enabled=enabled;item.Available=false;Application.DoEvents();
                        Check(id+".unavailable_excluded",!contains(item),"Unavailable command removed immediately");
                        item.Available=available;
                    }
                    foreach(var parent in all.Where(i=>i.DropDownItems.Count>0)) {
                        bool was=parent.Enabled;parent.Enabled=false;Application.DoEvents();
                        Check(mode+"."+parent.Name+".ancestor_denial",Items(parent).Where(i=>i.DropDownItems.Count==0).All(i=>!contains(i)),"Disabled parent excludes all descendant commands");
                        parent.Enabled=was;
                    }
                    var permissionSnapshot=all.ToDictionary(i=>i,i=>Tuple.Create(i.Enabled,i.Available));
                    foreach(var item in all) { item.Enabled=true;item.Available=true; }
                    Application.DoEvents();
                    Check(mode+".synthetic_allow_all_inventory",grid.Rows.Count==leaves.Length,"Fixture-only allow-all flags; original business handlers removed");
                    foreach(var item in leaves) {
                        var row=grid.Rows.Cast<DataGridViewRow>().First(r=>r.Tag==item);
                        grid.CurrentCell=row.Cells[0];Application.DoEvents();
                        int before=calls[item];open.PerformClick();
                        Check(mode+"."+item.Name+".synthetic_allowed_route",calls[item]==before+1,"Original command instance routes once under fixture permission flags");
                    }
                    foreach(var item in all) { item.Enabled=permissionSnapshot[item].Item1;item.Available=permissionSnapshot[item].Item2; }
                    search.Text="zzzz-no-command";Application.DoEvents();
                    Check(mode+".empty_search",grid.Rows.Count==0&&!open.Enabled,"No results and Open disabled");
                    search.Text="";
                    foreach(var option in category.Items.Cast<object>().Skip(1).ToArray()) {
                        category.SelectedItem=option;Application.DoEvents();
                        Check(mode+".category."+option,grid.Rows.Cast<DataGridViewRow>().All(r=>Convert.ToString(r.Cells[1].Value).StartsWith(option.ToString()+" · ")),"Category contains only its commands");
                    }
                    category.SelectedIndex=0;
                    Check(mode+".restored_inventory",grid.Rows.Count==leaves.Count(CanRun),"Original state restored after all permission cases");
                    using(var image=new Bitmap(form.Width,form.Height)) {
                        form.DrawToBitmap(image,new Rectangle(Point.Empty,image.Size));image.Save(Path.Combine(output,"commands-"+mode+".png"));
                    }
                    Console.WriteLine("COMMANDS "+mode+" "+leaves.Length);
                }
            }
        }
        Console.WriteLine("FAILED "+failures);return failures==0?0:1;
    }
}
