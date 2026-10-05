using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
public class RenderUi {
 static string root;
 static BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
 static object Get(object o, string name) { var p=o.GetType().GetProperty(name, flags); return p==null ? null : p.GetValue(o,null); }
 static void Dump(Control c, StreamWriter w, string path) { w.WriteLine(path+"/"+c.Name+" | "+c.GetType().Name+" | "+c.Bounds+" | "+c.Visible+" | "+c.Text.Replace("\r", " ").Replace("\n", " ")); foreach(Control child in c.Controls) Dump(child,w,path+"/"+c.Name); }
 static Control Find(Control c, string text) { if(c.Text==text) return c; foreach(Control child in c.Controls) { var result=Find(child,text);if(result!=null)return result; }return null; }
 static void Check(bool pass,string description) { if(!pass) throw new Exception(description);Console.WriteLine("CHECK PASS "+description); }
 static bool InViewport(Control control) { Rectangle screen=control.RectangleToScreen(control.ClientRectangle);for(Control parent=control.Parent;parent!=null;parent=parent.Parent)if(!parent.ClientRectangle.Contains(parent.RectangleToClient(screen)))return false;return true; }
 static bool ArtworkRendered(Form form, Bitmap capture, string name) { var artwork=form.Controls.Find(name,true)[0];Rectangle bounds=form.RectangleToClient(artwork.RectangleToScreen(artwork.ClientRectangle));Point origin=form.PointToScreen(Point.Empty);bounds.Offset(origin.X-form.Left,origin.Y-form.Top);for(int y=Math.Max(0,bounds.Top);y<Math.Min(capture.Height,bounds.Bottom);y++)for(int x=Math.Max(0,bounds.Left);x<Math.Min(capture.Width,bounds.Right);x++){Color pixel=capture.GetPixel(x,y);if(pixel.B>pixel.R*1.2 && pixel.B>pixel.G*1.1)return true;}return false; }
 static double Luminance(Color c) { double[] values={c.R/255d,c.G/255d,c.B/255d};for(int i=0;i<3;i++)values[i]=values[i]<=0.04045?values[i]/12.92:Math.Pow((values[i]+0.055)/1.055,2.4);return values[0]*0.2126+values[1]*0.7152+values[2]*0.0722; }
 static void Contrast(Type ui,string foreground,string background,double minimum) { double a=Luminance((Color)ui.GetMethod("Tone").Invoke(null,new object[]{foreground})),b=Luminance((Color)ui.GetMethod("Tone").Invoke(null,new object[]{background})); double ratio=(Math.Max(a,b)+0.05)/(Math.Min(a,b)+0.05);Check(ratio>=minimum,foreground+" on "+background+" contrast "+ratio.ToString("F2")+":1"); }
 [STAThread] public static int Main(string[] args) {
  root=Path.GetFullPath(args[0]); string outDir=Path.GetFullPath(args[1]); Directory.CreateDirectory(outDir);
  AppDomain.CurrentDomain.AssemblyResolve += (s,e) => { string n=new AssemblyName(e.Name).Name+".dll"; foreach(string d in new[]{root,Path.Combine(Environment.CurrentDirectory,"Original_Binaries")}) { string p=Path.Combine(d,n); if(File.Exists(p)) return Assembly.LoadFrom(p); } return null; };
  Application.EnableVisualStyles(); Application.SetCompatibleTextRenderingDefault(false);
  var asm=Assembly.LoadFrom(args.Length>3?Path.GetFullPath(args[3]):Path.Combine(root,"SmartAvenue99 POS.exe")); var theme=asm.GetType("BillPoint.AppleUITheme"); theme.GetProperty("IsCapturing").SetValue(null,true,null);
  if(args.Length>2 && args[2].StartsWith("rebuild")) asm.GetType("BillPoint.RetailUI").GetProperty("IsDark").SetValue(null,args[2].Contains("dark"),null);
  int failures=0;
  if(args.Length>2 && args[2].StartsWith("rebuild")) {
   foreach(string resource in new[]{"SmartRetail.Assets.Storefront.png","SmartRetail.Assets.EmptyBag.png"}) {
    using(var stream=asm.GetManifestResourceStream(resource)) { Check(stream!=null,resource+" is embedded for offline use");using(var bitmap=new Bitmap(stream))Check(bitmap.GetPixel(0,0).A==0 && bitmap.GetPixel(bitmap.Width-1,bitmap.Height-1).A==0,resource+" preserves transparent corners"); }
   }
  }
  foreach(string name in new[]{"frmSplash","frmLogin","frmMainMenu","frmPOS","frmSqlServerSetting"}) {
   try { Console.WriteLine("Rendering "+name); using(var f=(Form)Activator.CreateInstance(asm.GetType("BillPoint."+name))) {
    f.WindowState=FormWindowState.Normal;
    foreach(var p in f.GetType().GetProperties(flags)) if(p.PropertyType==typeof(System.Windows.Forms.Timer)) { var timer=(System.Windows.Forms.Timer)p.GetValue(f,null); if(timer!=null) timer.Stop(); }
    f.ShowInTaskbar=false; f.Show(); f.PerformLayout(); Application.DoEvents();
    if(args.Length>2 && args[2].StartsWith("rebuild")) { theme.GetMethod("RebuildForm").Invoke(null,new object[]{f}); f.PerformLayout(); Application.DoEvents(); }
    if(args.Length>2 && args[2].Contains("small") && (name=="frmPOS" || name=="frmMainMenu")) { f.ClientSize=new Size(1024,720);f.PerformLayout();Application.DoEvents(); }
    if(args.Length>2 && args[2].StartsWith("rebuild")) {
     if(name=="frmPOS") {
      var tabs=(TabControl)f.Controls.Find("RetailWorkspace",true)[0]; tabs.SelectedIndex=1; var save=f.Controls.Find("RetailPaymentRequired",true)[0];Rectangle saveBounds=f.RectangleToClient(save.RectangleToScreen(save.ClientRectangle));
      Check(f.ClientRectangle.Contains(saveBounds),"Payment continuation remains visible in the viewport");
      Check(save.Visible && save.Height>=44,"Payment continuation target is visible and at least 44 pixels"); tabs.SelectedIndex=0;
      var grid=(DataGridView)Get(f,"DataGridView1");var cartBody=f.Controls.Find("RetailCartBody",true)[0];Check(cartBody.Height>=100 && InViewport(cartBody),"Cart remains visible");
      var emptyCart=f.Controls.Find("RetailEmptyCart",true)[0];Check(emptyCart.Visible && InViewport(emptyCart),"Empty cart guidance is visible within the cart");
      bool customerEnabled=((Control)Get(f,"cmbCustomerName")).Enabled,stateEnabled=((Control)Get(f,"cmbCustomerState")).Enabled;
      var details=(Button)Find(f,"Item details");int compact=grid.Columns.GetColumnCount(DataGridViewElementStates.Visible);details.PerformClick();Check(grid.Columns.GetColumnCount(DataGridViewElementStates.Visible)>compact,"Item details reveals preserved columns");details.PerformClick();
      Check(grid.Columns.GetColumnCount(DataGridViewElementStates.Visible)==compact,"Compact cart restores column visibility");
      for(int i=0;i<500;i++) { int row=grid.Rows.Add();grid.Rows[row].Cells["Column3"].Value="Preview item with a long descriptive product name "+i;grid.Rows[row].Cells["Column4"].Value=1;grid.Rows[row].Cells["Column5"].Value="1,00,000.00";grid.Rows[row].Cells["Column6"].Value="1,00,000.00"; }
      Check(grid.Rows.Count>=500 && grid.Rows[499].Height>=44,"500-row cart retains readable row targets");Check(grid.Visible && grid.Height>=100 && InViewport(grid),"Populated cart remains visible in its viewport");Check(!emptyCart.Visible,"Cart artwork disappears when items exist");grid.Rows.Clear();Check(emptyCart.Visible,"Clearing items restores empty cart guidance");
      var total=(TextBox)Get(f,"txtGrandTotal");string originalTotal=total.Text;total.Text="1,23,45,678.90";Check(TextRenderer.MeasureText(total.Text,total.Font).Width<=total.ClientSize.Width,"Long total fits its display");total.Text=originalTotal;
      var upi=(Panel)Get(f,"PanelUPI");upi.Visible=true;Check(upi.Visible && upi.Parent==tabs.TabPages[1],"UPI overlay appears on the payment page");upi.Visible=false;
      ((Button)f.Controls.Find("RetailOpenTools",true)[0]).PerformClick(); Check(tabs.SelectedIndex==2,"Invoice tools navigation works"); tabs.SelectedIndex=0;
      ((Control)Get(f,"cmbCustomerName")).Enabled=customerEnabled;((Control)Get(f,"cmbCustomerState")).Enabled=stateEnabled;
     }
     if(name=="frmLogin") { var password=(TextBox)Get(f,"Password");password.Text="Preview password";((Button)Get(f,"Button5")).PerformClick();Check(password.PasswordChar=='\0',"Show password works");((Button)Get(f,"Button4")).PerformClick();Check(password.PasswordChar!='\0',"Hide password works");password.Clear();Check(Get(f,"OK")==f.AcceptButton,"Enter is bound to sign in");Check(!f.Controls.Find("RetailBrandArtwork",true)[0].CanSelect,"Decorative sign-in artwork does not enter keyboard navigation"); }
     if(name=="frmMainMenu") {
      var search=(TextBox)f.Controls.Find("RetailTaskSearch",true)[0];var results=f.Controls.Find("RetailTaskResults",true)[0];
      Check(results.Controls.Count==6 && Find(results,"Manage products")!=null && Find(results,"Find invoices")!=null,"Home starts with six everyday tasks");
      foreach(Control card in results.Controls) Check(InViewport(card),card.Text+" remains visible in the home viewport");
      search.Text="products";Check(results.Controls.Count>=2,"Search finds product commands across categories");bool contexts=true;foreach(Control card in results.Controls) contexts=contexts && !string.IsNullOrEmpty(card.AccessibleDescription);Check(contexts,"Task results expose category context");
      search.Text="zzzz-no-such-task";Check(Find(f,"No matching task. Try a different name or browse all commands.")!=null,"Search has a recovery empty state");search.Text="";
      var ui=asm.GetType("BillPoint.RetailUI");bool originalDark=(bool)ui.GetProperty("IsDark").GetValue(null,null);var appearance=(Button)f.Controls.Find("RetailAppearance",true)[0];appearance.PerformClick();Check((bool)ui.GetProperty("IsDark").GetValue(null,null)!=originalDark,"Appearance toggle updates the native theme");appearance.PerformClick();Check(!string.IsNullOrEmpty(results.Controls[0].AccessibleDescription),"Appearance changes preserve task context");var tabs=(TabControl)f.Controls.Find("RetailWorkspace",true)[0];Check(tabs.TabPages[0].BackColor==(Color)ui.GetMethod("Tone").Invoke(null,new object[]{"canvas"}),"Appearance changes preserve the grouped canvas");
     }
    }
    if(args.Length>2 && args[2]=="polished") {
     if(name=="frmLogin") theme.GetMethod("PolishLoginForm").Invoke(null,new object[]{f,Get(f,"Panel1"),Get(f,"OK"),Get(f,"Cancel"),Get(f,"UserID"),Get(f,"Password"),Get(f,"Label1")});
     if(name=="frmPOS") { var names=new[]{"DataGridView1","dgw4","txtGrandTotal","txtSubTotal","txtPaymentDue","btnSave","btnCheckout","btnInit","btnUpdate","btnGetData","btnPrint","btnNew","btnDelete","btnhold","btnunhold","btnScanItems","btnGift","PanelUPI"}; var values=new object[names.Length+1];values[0]=f;for(int i=0;i<names.Length;i++) values[i+1]=Get(f,names[i]); theme.GetMethod("PolishPOSForm").Invoke(null,values); }
     f.PerformLayout();
    }
    using(var w=new StreamWriter(Path.Combine(outDir,name+".txt"))) Dump(f,w,"");
    using(var b=new Bitmap(f.Width,f.Height)) { f.DrawToBitmap(b,new Rectangle(0,0,b.Width,b.Height));if(args.Length>2 && args[2].StartsWith("rebuild")){if(name=="frmPOS")Check(ArtworkRendered(f,b,"RetailEmptyCartArtwork"),"Empty cart artwork appears in the rendered screen");if(name=="frmSplash")Check(ArtworkRendered(f,b,"RetailBrandArtwork"),"Startup artwork appears in the rendered screen");} b.Save(Path.Combine(outDir,name+".png")); }
    Console.WriteLine("PASS "+name+" "+f.ClientSize);
   }} catch(Exception ex) { failures++; File.WriteAllText(Path.Combine(outDir,name+"-error.txt"),ex.ToString()); Console.WriteLine("FAIL "+name+" "+ex.GetBaseException().Message); }
  }
  if(args.Length>2 && args[2].StartsWith("rebuild")) {
   var ui=asm.GetType("BillPoint.RetailUI");bool originalDark=(bool)ui.GetProperty("IsDark").GetValue(null,null);
   foreach(bool dark in new[]{false,true}) { ui.GetProperty("IsDark").SetValue(null,dark,null);Console.WriteLine(dark?"Dark contrast":"Light contrast");Contrast(ui,"label","surface",4.5);Contrast(ui,"secondary","surface",4.5);Contrast(ui,"on-accent","accent",4.5);Contrast(ui,"on-accent","accent-hover",4.5);Contrast(ui,"accent-text","surface",4.5);Contrast(ui,"control","surface",3);Contrast(ui,"danger","surface",4.5);Contrast(ui,"warning","surface",4.5); }
   ui.GetProperty("IsDark").SetValue(null,originalDark,null);
   var parent=new ToolStripMenuItem("Parent");var command=new ToolStripMenuItem("Test command");parent.DropDownItems.Add(command);int clicks=0;command.Click+=(s,e)=>clicks++;
   var method=asm.GetType("BillPoint.RetailLayouts").GetMethod("MenuAction",BindingFlags.NonPublic|BindingFlags.Static);
   using(var proxy=(Button)method.Invoke(null,new object[]{command,"Test command",false})) { proxy.PerformClick();Check(clicks==1,"Navigation proxy uses original command");parent.Enabled=false;Check(!proxy.Enabled,"Disabled parent disables proxy");proxy.PerformClick();Check(clicks==1,"Disabled parent cannot be invoked");parent.Enabled=true;parent.Available=false;Check(!proxy.Enabled,"Hidden parent disables proxy"); }
  }
  return failures==0?0:1;
 }
}
