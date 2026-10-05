Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000140 RID: 320
	<DesignerGenerated()>
	Public Partial Class frmPhonePeUPI
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060035BB RID: 13755 RVA: 0x00020CE1 File Offset: 0x0001EEE1
		Public Sub New()
			Me.InitializeComponent()
		End Sub

		' Token: 0x170014B5 RID: 5301
		' (get) Token: 0x060035BE RID: 13758 RVA: 0x00020CEF File Offset: 0x0001EEEF
		' (set) Token: 0x060035BF RID: 13759 RVA: 0x00020CF9 File Offset: 0x0001EEF9
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170014B6 RID: 5302
		' (get) Token: 0x060035C0 RID: 13760 RVA: 0x00020D02 File Offset: 0x0001EF02
		' (set) Token: 0x060035C1 RID: 13761 RVA: 0x00020D0C File Offset: 0x0001EF0C
		Friend Overridable Property btnCheckout As Button

		' Token: 0x170014B7 RID: 5303
		' (get) Token: 0x060035C2 RID: 13762 RVA: 0x00020D15 File Offset: 0x0001EF15
		' (set) Token: 0x060035C3 RID: 13763 RVA: 0x00020D1F File Offset: 0x0001EF1F
		Friend Overridable Property LinkLabel2 As LinkLabel

		' Token: 0x170014B8 RID: 5304
		' (get) Token: 0x060035C4 RID: 13764 RVA: 0x00020D28 File Offset: 0x0001EF28
		' (set) Token: 0x060035C5 RID: 13765 RVA: 0x00020D32 File Offset: 0x0001EF32
		Friend Overridable Property LinkLabel1 As LinkLabel

		' Token: 0x170014B9 RID: 5305
		' (get) Token: 0x060035C6 RID: 13766 RVA: 0x00020D3B File Offset: 0x0001EF3B
		' (set) Token: 0x060035C7 RID: 13767 RVA: 0x00020D45 File Offset: 0x0001EF45
		Friend Overridable Property btnLastTxns As Button

		' Token: 0x170014BA RID: 5306
		' (get) Token: 0x060035C8 RID: 13768 RVA: 0x00020D4E File Offset: 0x0001EF4E
		' (set) Token: 0x060035C9 RID: 13769 RVA: 0x00020D58 File Offset: 0x0001EF58
		Friend Overridable Property tBoxLog As TextBox

		' Token: 0x170014BB RID: 5307
		' (get) Token: 0x060035CA RID: 13770 RVA: 0x00020D61 File Offset: 0x0001EF61
		' (set) Token: 0x060035CB RID: 13771 RVA: 0x00020D6B File Offset: 0x0001EF6B
		Friend Overridable Property Label115 As Label

		' Token: 0x170014BC RID: 5308
		' (get) Token: 0x060035CC RID: 13772 RVA: 0x00020D74 File Offset: 0x0001EF74
		' (set) Token: 0x060035CD RID: 13773 RVA: 0x00020D7E File Offset: 0x0001EF7E
		Friend Overridable Property tBoxConfirmation As TextBox

		' Token: 0x170014BD RID: 5309
		' (get) Token: 0x060035CE RID: 13774 RVA: 0x00020D87 File Offset: 0x0001EF87
		' (set) Token: 0x060035CF RID: 13775 RVA: 0x00020D91 File Offset: 0x0001EF91
		Friend Overridable Property btnCancel As Button

		' Token: 0x170014BE RID: 5310
		' (get) Token: 0x060035D0 RID: 13776 RVA: 0x00020D9A File Offset: 0x0001EF9A
		' (set) Token: 0x060035D1 RID: 13777 RVA: 0x00020DA4 File Offset: 0x0001EFA4
		Friend Overridable Property pBoxQR As PictureBox

		' Token: 0x170014BF RID: 5311
		' (get) Token: 0x060035D2 RID: 13778 RVA: 0x00020DAD File Offset: 0x0001EFAD
		' (set) Token: 0x060035D3 RID: 13779 RVA: 0x00020DB7 File Offset: 0x0001EFB7
		Friend Overridable Property tBoxAmount As TextBox

		' Token: 0x170014C0 RID: 5312
		' (get) Token: 0x060035D4 RID: 13780 RVA: 0x00020DC0 File Offset: 0x0001EFC0
		' (set) Token: 0x060035D5 RID: 13781 RVA: 0x00020DCA File Offset: 0x0001EFCA
		Friend Overridable Property Label113 As Label

		' Token: 0x170014C1 RID: 5313
		' (get) Token: 0x060035D6 RID: 13782 RVA: 0x00020DD3 File Offset: 0x0001EFD3
		' (set) Token: 0x060035D7 RID: 13783 RVA: 0x00020DDD File Offset: 0x0001EFDD
		Friend Overridable Property Label114 As Label

		' Token: 0x170014C2 RID: 5314
		' (get) Token: 0x060035D8 RID: 13784 RVA: 0x00020DE6 File Offset: 0x0001EFE6
		' (set) Token: 0x060035D9 RID: 13785 RVA: 0x00020DF0 File Offset: 0x0001EFF0
		Friend Overridable Property tBoxOrderId As TextBox

		' Token: 0x170014C3 RID: 5315
		' (get) Token: 0x060035DA RID: 13786 RVA: 0x00020DF9 File Offset: 0x0001EFF9
		' (set) Token: 0x060035DB RID: 13787 RVA: 0x00020E03 File Offset: 0x0001F003
		Friend Overridable Property buttonReloadUPIId As Button

		' Token: 0x170014C4 RID: 5316
		' (get) Token: 0x060035DC RID: 13788 RVA: 0x00020E0C File Offset: 0x0001F00C
		' (set) Token: 0x060035DD RID: 13789 RVA: 0x00020E16 File Offset: 0x0001F016
		Friend Overridable Property lblValUPIId As Label

		' Token: 0x170014C5 RID: 5317
		' (get) Token: 0x060035DE RID: 13790 RVA: 0x00020E1F File Offset: 0x0001F01F
		' (set) Token: 0x060035DF RID: 13791 RVA: 0x00020E29 File Offset: 0x0001F029
		Friend Overridable Property lblMyUPIID As Label

		' Token: 0x170014C6 RID: 5318
		' (get) Token: 0x060035E0 RID: 13792 RVA: 0x00020E32 File Offset: 0x0001F032
		' (set) Token: 0x060035E1 RID: 13793 RVA: 0x00020E3C File Offset: 0x0001F03C
		Friend Overridable Property btnInit As Button

		' Token: 0x170014C7 RID: 5319
		' (get) Token: 0x060035E2 RID: 13794 RVA: 0x00020E45 File Offset: 0x0001F045
		' (set) Token: 0x060035E3 RID: 13795 RVA: 0x00020E4F File Offset: 0x0001F04F
		Friend Overridable Property TextBox1 As TextBox
	End Class
End Namespace
