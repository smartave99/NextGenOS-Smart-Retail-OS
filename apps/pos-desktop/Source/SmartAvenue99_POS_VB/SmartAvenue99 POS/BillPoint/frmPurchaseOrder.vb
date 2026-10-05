Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001EF RID: 495
	<DesignerGenerated()>
	Public Partial Class frmPurchaseOrder
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060089BC RID: 35260 RVA: 0x006573AC File Offset: 0x006555AC
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmStock_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmPurchaseOrder_KeyDown
			Me.a = 0.0
			Me.ntid = ""
			Me.Dst = New DataSet()
			Me.voice = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("SAPI.spvoice", ""))
			Me.InitializeComponent()
		End Sub

		' Token: 0x170032A3 RID: 12963
		' (get) Token: 0x060089BF RID: 35263 RVA: 0x00043430 File Offset: 0x00041630
		' (set) Token: 0x060089C0 RID: 35264 RVA: 0x0004343A File Offset: 0x0004163A
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170032A4 RID: 12964
		' (get) Token: 0x060089C1 RID: 35265 RVA: 0x00043443 File Offset: 0x00041643
		' (set) Token: 0x060089C2 RID: 35266 RVA: 0x0004344D File Offset: 0x0004164D
		Friend Overridable Property Label3 As Label

		' Token: 0x170032A5 RID: 12965
		' (get) Token: 0x060089C3 RID: 35267 RVA: 0x00043456 File Offset: 0x00041656
		' (set) Token: 0x060089C4 RID: 35268 RVA: 0x00043460 File Offset: 0x00041660
		Friend Overridable Property txtPONo As TextBox

		' Token: 0x170032A6 RID: 12966
		' (get) Token: 0x060089C5 RID: 35269 RVA: 0x00043469 File Offset: 0x00041669
		' (set) Token: 0x060089C6 RID: 35270 RVA: 0x00043473 File Offset: 0x00041673
		Friend Overridable Property Panel3 As Panel

		' Token: 0x170032A7 RID: 12967
		' (get) Token: 0x060089C7 RID: 35271 RVA: 0x0004347C File Offset: 0x0004167C
		' (set) Token: 0x060089C8 RID: 35272 RVA: 0x0065F3B0 File Offset: 0x0065D5B0
		Private _btnClose As Button
		Friend Overridable Property btnClose As Button
			<CompilerGenerated()>
			Get
				Return Me._btnClose
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnClose_Click
				Dim button As Button = Me._btnClose
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnClose = value
				button = Me._btnClose
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170032A8 RID: 12968
		' (get) Token: 0x060089C9 RID: 35273 RVA: 0x00043486 File Offset: 0x00041686
		' (set) Token: 0x060089CA RID: 35274 RVA: 0x00043490 File Offset: 0x00041690
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170032A9 RID: 12969
		' (get) Token: 0x060089CB RID: 35275 RVA: 0x00043499 File Offset: 0x00041699
		' (set) Token: 0x060089CC RID: 35276 RVA: 0x000434A3 File Offset: 0x000416A3
		Friend Overridable Property Label1 As Label

		' Token: 0x170032AA RID: 12970
		' (get) Token: 0x060089CD RID: 35277 RVA: 0x000434AC File Offset: 0x000416AC
		' (set) Token: 0x060089CE RID: 35278 RVA: 0x000434B6 File Offset: 0x000416B6
		Friend Overridable Property Label2 As Label

		' Token: 0x170032AB RID: 12971
		' (get) Token: 0x060089CF RID: 35279 RVA: 0x000434BF File Offset: 0x000416BF
		' (set) Token: 0x060089D0 RID: 35280 RVA: 0x0065F3F4 File Offset: 0x0065D5F4
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView1_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.DataGridView1_RowPostPaint
				Dim dataGridViewCellFormattingEventHandler As DataGridViewCellFormattingEventHandler = AddressOf Me.DataGridView1_CellFormatting
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.CellFormatting, dataGridViewCellFormattingEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.CellFormatting, dataGridViewCellFormattingEventHandler
				End If
			End Set
		End Property

		' Token: 0x170032AC RID: 12972
		' (get) Token: 0x060089D1 RID: 35281 RVA: 0x000434C9 File Offset: 0x000416C9
		' (set) Token: 0x060089D2 RID: 35282 RVA: 0x000434D3 File Offset: 0x000416D3
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170032AD RID: 12973
		' (get) Token: 0x060089D3 RID: 35283 RVA: 0x000434DC File Offset: 0x000416DC
		' (set) Token: 0x060089D4 RID: 35284 RVA: 0x0065F470 File Offset: 0x0065D670
		Private _btnRemove As Button
		Friend Overridable Property btnRemove As Button
			<CompilerGenerated()>
			Get
				Return Me._btnRemove
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnRemove_Click
				Dim button As Button = Me._btnRemove
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnRemove = value
				button = Me._btnRemove
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170032AE RID: 12974
		' (get) Token: 0x060089D5 RID: 35285 RVA: 0x000434E6 File Offset: 0x000416E6
		' (set) Token: 0x060089D6 RID: 35286 RVA: 0x000434F0 File Offset: 0x000416F0
		Friend Overridable Property txtTotalAmount As TextBox

		' Token: 0x170032AF RID: 12975
		' (get) Token: 0x060089D7 RID: 35287 RVA: 0x000434F9 File Offset: 0x000416F9
		' (set) Token: 0x060089D8 RID: 35288 RVA: 0x0065F4B4 File Offset: 0x0065D6B4
		Private _txtPricePerQty As TextBox
		Friend Overridable Property txtPricePerQty As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPricePerQty
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtPricePerQty_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtPricePerQty_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPricePerQty_KeyDown
				Dim eventHandler2 As EventHandler = AddressOf Me.txtPricePerQty_GotFocus
				Dim eventHandler3 As EventHandler = AddressOf Me.txtPricePerQty_LostFocus
				Dim textBox As TextBox = Me._txtPricePerQty
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.GotFocus, eventHandler2
					RemoveHandler textBox.LostFocus, eventHandler3
				End If
				Me._txtPricePerQty = value
				textBox = Me._txtPricePerQty
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.GotFocus, eventHandler2
					AddHandler textBox.LostFocus, eventHandler3
				End If
			End Set
		End Property

		' Token: 0x170032B0 RID: 12976
		' (get) Token: 0x060089D9 RID: 35289 RVA: 0x00043503 File Offset: 0x00041703
		' (set) Token: 0x060089DA RID: 35290 RVA: 0x0065F574 File Offset: 0x0065D774
		Private _txtQty As TextBox
		Friend Overridable Property txtQty As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtQty
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtQty_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtQty_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtQty_KeyDown
				Dim eventHandler2 As EventHandler = AddressOf Me.txtQty_Leave
				Dim textBox As TextBox = Me._txtQty
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Leave, eventHandler2
				End If
				Me._txtQty = value
				textBox = Me._txtQty
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Leave, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x170032B1 RID: 12977
		' (get) Token: 0x060089DB RID: 35291 RVA: 0x0004350D File Offset: 0x0004170D
		' (set) Token: 0x060089DC RID: 35292 RVA: 0x00043517 File Offset: 0x00041717
		Friend Overridable Property Label9 As Label

		' Token: 0x170032B2 RID: 12978
		' (get) Token: 0x060089DD RID: 35293 RVA: 0x00043520 File Offset: 0x00041720
		' (set) Token: 0x060089DE RID: 35294 RVA: 0x0004352A File Offset: 0x0004172A
		Friend Overridable Property Label6 As Label

		' Token: 0x170032B3 RID: 12979
		' (get) Token: 0x060089DF RID: 35295 RVA: 0x00043533 File Offset: 0x00041733
		' (set) Token: 0x060089E0 RID: 35296 RVA: 0x0004353D File Offset: 0x0004173D
		Friend Overridable Property Label4 As Label

		' Token: 0x170032B4 RID: 12980
		' (get) Token: 0x060089E1 RID: 35297 RVA: 0x00043546 File Offset: 0x00041746
		' (set) Token: 0x060089E2 RID: 35298 RVA: 0x0065F614 File Offset: 0x0065D814
		Private _btnAdd As Button
		Friend Overridable Property btnAdd As Button
			<CompilerGenerated()>
			Get
				Return Me._btnAdd
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnAdd_Click
				Dim button As Button = Me._btnAdd
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnAdd = value
				button = Me._btnAdd
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170032B5 RID: 12981
		' (get) Token: 0x060089E3 RID: 35299 RVA: 0x00043550 File Offset: 0x00041750
		' (set) Token: 0x060089E4 RID: 35300 RVA: 0x0065F658 File Offset: 0x0065D858
		Private _Button1 As Button
		Friend Overridable Property Button1 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click
				Dim button As Button = Me._Button1
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button1 = value
				button = Me._Button1
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170032B6 RID: 12982
		' (get) Token: 0x060089E5 RID: 35301 RVA: 0x0004355A File Offset: 0x0004175A
		' (set) Token: 0x060089E6 RID: 35302 RVA: 0x0065F69C File Offset: 0x0065D89C
		Private _txtProductName As TextBox
		Friend Overridable Property txtProductName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtProductName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtProductName_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.txtProductName_TextChanged
				Dim keyEventHandler2 As KeyEventHandler = AddressOf Me.txtProductName_KeyUp
				Dim textBox As TextBox = Me._txtProductName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyUp, keyEventHandler2
				End If
				Me._txtProductName = value
				textBox = Me._txtProductName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyUp, keyEventHandler2
				End If
			End Set
		End Property

		' Token: 0x170032B7 RID: 12983
		' (get) Token: 0x060089E7 RID: 35303 RVA: 0x00043564 File Offset: 0x00041764
		' (set) Token: 0x060089E8 RID: 35304 RVA: 0x0004356E File Offset: 0x0004176E
		Friend Overridable Property txtHSNCode As TextBox

		' Token: 0x170032B8 RID: 12984
		' (get) Token: 0x060089E9 RID: 35305 RVA: 0x00043577 File Offset: 0x00041777
		' (set) Token: 0x060089EA RID: 35306 RVA: 0x00043581 File Offset: 0x00041781
		Friend Overridable Property Label7 As Label

		' Token: 0x170032B9 RID: 12985
		' (get) Token: 0x060089EB RID: 35307 RVA: 0x0004358A File Offset: 0x0004178A
		' (set) Token: 0x060089EC RID: 35308 RVA: 0x00043594 File Offset: 0x00041794
		Friend Overridable Property Label8 As Label

		' Token: 0x170032BA RID: 12986
		' (get) Token: 0x060089ED RID: 35309 RVA: 0x0004359D File Offset: 0x0004179D
		' (set) Token: 0x060089EE RID: 35310 RVA: 0x000435A7 File Offset: 0x000417A7
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x170032BB RID: 12987
		' (get) Token: 0x060089EF RID: 35311 RVA: 0x000435B0 File Offset: 0x000417B0
		' (set) Token: 0x060089F0 RID: 35312 RVA: 0x0065F718 File Offset: 0x0065D918
		Private _dtpPODate As DateTimePicker
		Friend Overridable Property dtpPODate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpPODate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim eventHandler As EventHandler = AddressOf Me.dtpPODate_LostFocus
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpPODate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpPODate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.LostFocus, eventHandler
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpPODate = value
				dateTimePicker = Me._dtpPODate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.LostFocus, eventHandler
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170032BC RID: 12988
		' (get) Token: 0x060089F1 RID: 35313 RVA: 0x000435BA File Offset: 0x000417BA
		' (set) Token: 0x060089F2 RID: 35314 RVA: 0x0065F778 File Offset: 0x0065D978
		Private _txtTermsAndConditions As RichTextBox
		Friend Overridable Property txtTermsAndConditions As RichTextBox
			<CompilerGenerated()>
			Get
				Return Me._txtTermsAndConditions
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RichTextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtTermsAndConditions_KeyDown
				Dim richTextBox As RichTextBox = Me._txtTermsAndConditions
				If richTextBox IsNot Nothing Then
					RemoveHandler richTextBox.KeyDown, keyEventHandler
				End If
				Me._txtTermsAndConditions = value
				richTextBox = Me._txtTermsAndConditions
				If richTextBox IsNot Nothing Then
					AddHandler richTextBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170032BD RID: 12989
		' (get) Token: 0x060089F3 RID: 35315 RVA: 0x000435C4 File Offset: 0x000417C4
		' (set) Token: 0x060089F4 RID: 35316 RVA: 0x000435CE File Offset: 0x000417CE
		Friend Overridable Property Label12 As Label

		' Token: 0x170032BE RID: 12990
		' (get) Token: 0x060089F5 RID: 35317 RVA: 0x000435D7 File Offset: 0x000417D7
		' (set) Token: 0x060089F6 RID: 35318 RVA: 0x000435E1 File Offset: 0x000417E1
		Friend Overridable Property txtSup_ID As TextBox

		' Token: 0x170032BF RID: 12991
		' (get) Token: 0x060089F7 RID: 35319 RVA: 0x000435EA File Offset: 0x000417EA
		' (set) Token: 0x060089F8 RID: 35320 RVA: 0x000435F4 File Offset: 0x000417F4
		Friend Overridable Property txtPO_ID As TextBox

		' Token: 0x170032C0 RID: 12992
		' (get) Token: 0x060089F9 RID: 35321 RVA: 0x000435FD File Offset: 0x000417FD
		' (set) Token: 0x060089FA RID: 35322 RVA: 0x00043607 File Offset: 0x00041807
		Friend Overridable Property lblUser As Label

		' Token: 0x170032C1 RID: 12993
		' (get) Token: 0x060089FB RID: 35323 RVA: 0x00043610 File Offset: 0x00041810
		' (set) Token: 0x060089FC RID: 35324 RVA: 0x0004361A File Offset: 0x0004181A
		Friend Overridable Property lblSet As Label

		' Token: 0x170032C2 RID: 12994
		' (get) Token: 0x060089FD RID: 35325 RVA: 0x00043623 File Offset: 0x00041823
		' (set) Token: 0x060089FE RID: 35326 RVA: 0x0004362D File Offset: 0x0004182D
		Friend Overridable Property lblUserType As Label

		' Token: 0x170032C3 RID: 12995
		' (get) Token: 0x060089FF RID: 35327 RVA: 0x00043636 File Offset: 0x00041836
		' (set) Token: 0x06008A00 RID: 35328 RVA: 0x00043640 File Offset: 0x00041840
		Friend Overridable Property txtProductID As TextBox

		' Token: 0x170032C4 RID: 12996
		' (get) Token: 0x06008A01 RID: 35329 RVA: 0x00043649 File Offset: 0x00041849
		' (set) Token: 0x06008A02 RID: 35330 RVA: 0x00043653 File Offset: 0x00041853
		Friend Overridable Property gbPartyInfo As GroupBox

		' Token: 0x170032C5 RID: 12997
		' (get) Token: 0x06008A03 RID: 35331 RVA: 0x0004365C File Offset: 0x0004185C
		' (set) Token: 0x06008A04 RID: 35332 RVA: 0x0065F7BC File Offset: 0x0065D9BC
		Private _btnSelection As Button
		Friend Overridable Property btnSelection As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSelection
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
				Dim button As Button = Me._btnSelection
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSelection = value
				button = Me._btnSelection
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170032C6 RID: 12998
		' (get) Token: 0x06008A05 RID: 35333 RVA: 0x00043666 File Offset: 0x00041866
		' (set) Token: 0x06008A06 RID: 35334 RVA: 0x00043670 File Offset: 0x00041870
		Friend Overridable Property Label10 As Label

		' Token: 0x170032C7 RID: 12999
		' (get) Token: 0x06008A07 RID: 35335 RVA: 0x00043679 File Offset: 0x00041879
		' (set) Token: 0x06008A08 RID: 35336 RVA: 0x00043683 File Offset: 0x00041883
		Friend Overridable Property txtSupplierID As TextBox

		' Token: 0x170032C8 RID: 13000
		' (get) Token: 0x06008A09 RID: 35337 RVA: 0x0004368C File Offset: 0x0004188C
		' (set) Token: 0x06008A0A RID: 35338 RVA: 0x00043696 File Offset: 0x00041896
		Friend Overridable Property lblBalance As Label

		' Token: 0x170032C9 RID: 13001
		' (get) Token: 0x06008A0B RID: 35339 RVA: 0x0004369F File Offset: 0x0004189F
		' (set) Token: 0x06008A0C RID: 35340 RVA: 0x000436A9 File Offset: 0x000418A9
		Friend Overridable Property Label11 As Label

		' Token: 0x170032CA RID: 13002
		' (get) Token: 0x06008A0D RID: 35341 RVA: 0x000436B2 File Offset: 0x000418B2
		' (set) Token: 0x06008A0E RID: 35342 RVA: 0x000436BC File Offset: 0x000418BC
		Friend Overridable Property txtContactNo As TextBox

		' Token: 0x170032CB RID: 13003
		' (get) Token: 0x06008A0F RID: 35343 RVA: 0x000436C5 File Offset: 0x000418C5
		' (set) Token: 0x06008A10 RID: 35344 RVA: 0x000436CF File Offset: 0x000418CF
		Friend Overridable Property txtState As TextBox

		' Token: 0x170032CC RID: 13004
		' (get) Token: 0x06008A11 RID: 35345 RVA: 0x000436D8 File Offset: 0x000418D8
		' (set) Token: 0x06008A12 RID: 35346 RVA: 0x000436E2 File Offset: 0x000418E2
		Friend Overridable Property txtAddress As TextBox

		' Token: 0x170032CD RID: 13005
		' (get) Token: 0x06008A13 RID: 35347 RVA: 0x000436EB File Offset: 0x000418EB
		' (set) Token: 0x06008A14 RID: 35348 RVA: 0x000436F5 File Offset: 0x000418F5
		Friend Overridable Property Label26 As Label

		' Token: 0x170032CE RID: 13006
		' (get) Token: 0x06008A15 RID: 35349 RVA: 0x000436FE File Offset: 0x000418FE
		' (set) Token: 0x06008A16 RID: 35350 RVA: 0x00043708 File Offset: 0x00041908
		Friend Overridable Property Label29 As Label

		' Token: 0x170032CF RID: 13007
		' (get) Token: 0x06008A17 RID: 35351 RVA: 0x00043711 File Offset: 0x00041911
		' (set) Token: 0x06008A18 RID: 35352 RVA: 0x0004371B File Offset: 0x0004191B
		Friend Overridable Property Label30 As Label

		' Token: 0x170032D0 RID: 13008
		' (get) Token: 0x06008A19 RID: 35353 RVA: 0x00043724 File Offset: 0x00041924
		' (set) Token: 0x06008A1A RID: 35354 RVA: 0x0004372E File Offset: 0x0004192E
		Friend Overridable Property Label36 As Label

		' Token: 0x170032D1 RID: 13009
		' (get) Token: 0x06008A1B RID: 35355 RVA: 0x00043737 File Offset: 0x00041937
		' (set) Token: 0x06008A1C RID: 35356 RVA: 0x00043741 File Offset: 0x00041941
		Friend Overridable Property pnlCalc As Panel

		' Token: 0x170032D2 RID: 13010
		' (get) Token: 0x06008A1D RID: 35357 RVA: 0x0004374A File Offset: 0x0004194A
		' (set) Token: 0x06008A1E RID: 35358 RVA: 0x0065F800 File Offset: 0x0065DA00
		Private _txtDisc As TextBox
		Friend Overridable Property txtDisc As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDisc
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtDisc_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtDisc_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtDisc_KeyDown
				Dim textBox As TextBox = Me._txtDisc
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtDisc = value
				textBox = Me._txtDisc
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170032D3 RID: 13011
		' (get) Token: 0x06008A1F RID: 35359 RVA: 0x00043754 File Offset: 0x00041954
		' (set) Token: 0x06008A20 RID: 35360 RVA: 0x0004375E File Offset: 0x0004195E
		Friend Overridable Property Label45 As Label

		' Token: 0x170032D4 RID: 13012
		' (get) Token: 0x06008A21 RID: 35361 RVA: 0x00043767 File Offset: 0x00041967
		' (set) Token: 0x06008A22 RID: 35362 RVA: 0x00043771 File Offset: 0x00041971
		Friend Overridable Property Label46 As Label

		' Token: 0x170032D5 RID: 13013
		' (get) Token: 0x06008A23 RID: 35363 RVA: 0x0004377A File Offset: 0x0004197A
		' (set) Token: 0x06008A24 RID: 35364 RVA: 0x0065F87C File Offset: 0x0065DA7C
		Private _txtDiscPer As TextBox
		Friend Overridable Property txtDiscPer As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDiscPer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtDiscPer_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtDiscPer_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtDiscPer_KeyDown
				Dim textBox As TextBox = Me._txtDiscPer
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtDiscPer = value
				textBox = Me._txtDiscPer
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170032D6 RID: 13014
		' (get) Token: 0x06008A25 RID: 35365 RVA: 0x00043784 File Offset: 0x00041984
		' (set) Token: 0x06008A26 RID: 35366 RVA: 0x0004378E File Offset: 0x0004198E
		Friend Overridable Property Label16 As Label

		' Token: 0x170032D7 RID: 13015
		' (get) Token: 0x06008A27 RID: 35367 RVA: 0x00043797 File Offset: 0x00041997
		' (set) Token: 0x06008A28 RID: 35368 RVA: 0x000437A1 File Offset: 0x000419A1
		Friend Overridable Property txtGrandTotal As TextBox

		' Token: 0x170032D8 RID: 13016
		' (get) Token: 0x06008A29 RID: 35369 RVA: 0x000437AA File Offset: 0x000419AA
		' (set) Token: 0x06008A2A RID: 35370 RVA: 0x0065F8F8 File Offset: 0x0065DAF8
		Private _txtSubTotal As TextBox
		Friend Overridable Property txtSubTotal As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSubTotal
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSubTotal_TextChanged
				Dim textBox As TextBox = Me._txtSubTotal
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSubTotal = value
				textBox = Me._txtSubTotal
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170032D9 RID: 13017
		' (get) Token: 0x06008A2B RID: 35371 RVA: 0x000437B4 File Offset: 0x000419B4
		' (set) Token: 0x06008A2C RID: 35372 RVA: 0x000437BE File Offset: 0x000419BE
		Friend Overridable Property Label31 As Label

		' Token: 0x170032DA RID: 13018
		' (get) Token: 0x06008A2D RID: 35373 RVA: 0x000437C7 File Offset: 0x000419C7
		' (set) Token: 0x06008A2E RID: 35374 RVA: 0x000437D1 File Offset: 0x000419D1
		Friend Overridable Property txtCGST As TextBox

		' Token: 0x170032DB RID: 13019
		' (get) Token: 0x06008A2F RID: 35375 RVA: 0x000437DA File Offset: 0x000419DA
		' (set) Token: 0x06008A30 RID: 35376 RVA: 0x000437E4 File Offset: 0x000419E4
		Friend Overridable Property Label14 As Label

		' Token: 0x170032DC RID: 13020
		' (get) Token: 0x06008A31 RID: 35377 RVA: 0x000437ED File Offset: 0x000419ED
		' (set) Token: 0x06008A32 RID: 35378 RVA: 0x000437F7 File Offset: 0x000419F7
		Friend Overridable Property lblUnit As Label

		' Token: 0x170032DD RID: 13021
		' (get) Token: 0x06008A33 RID: 35379 RVA: 0x00043800 File Offset: 0x00041A00
		' (set) Token: 0x06008A34 RID: 35380 RVA: 0x0004380A File Offset: 0x00041A0A
		Friend Overridable Property txtSGST As TextBox

		' Token: 0x170032DE RID: 13022
		' (get) Token: 0x06008A35 RID: 35381 RVA: 0x00043813 File Offset: 0x00041A13
		' (set) Token: 0x06008A36 RID: 35382 RVA: 0x0004381D File Offset: 0x00041A1D
		Friend Overridable Property Label23 As Label

		' Token: 0x170032DF RID: 13023
		' (get) Token: 0x06008A37 RID: 35383 RVA: 0x00043826 File Offset: 0x00041A26
		' (set) Token: 0x06008A38 RID: 35384 RVA: 0x00043830 File Offset: 0x00041A30
		Friend Overridable Property txtIGST As TextBox

		' Token: 0x170032E0 RID: 13024
		' (get) Token: 0x06008A39 RID: 35385 RVA: 0x00043839 File Offset: 0x00041A39
		' (set) Token: 0x06008A3A RID: 35386 RVA: 0x00043843 File Offset: 0x00041A43
		Friend Overridable Property Label27 As Label

		' Token: 0x170032E1 RID: 13025
		' (get) Token: 0x06008A3B RID: 35387 RVA: 0x0004384C File Offset: 0x00041A4C
		' (set) Token: 0x06008A3C RID: 35388 RVA: 0x00043856 File Offset: 0x00041A56
		Friend Overridable Property txtCESS As TextBox

		' Token: 0x170032E2 RID: 13026
		' (get) Token: 0x06008A3D RID: 35389 RVA: 0x0004385F File Offset: 0x00041A5F
		' (set) Token: 0x06008A3E RID: 35390 RVA: 0x0065F93C File Offset: 0x0065DB3C
		Private _cmbTaxType As ComboBox
		Friend Overridable Property cmbTaxType As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbTaxType
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbTaxType_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbTaxType
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbTaxType = value
				comboBox = Me._cmbTaxType
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170032E3 RID: 13027
		' (get) Token: 0x06008A3F RID: 35391 RVA: 0x00043869 File Offset: 0x00041A69
		' (set) Token: 0x06008A40 RID: 35392 RVA: 0x00043873 File Offset: 0x00041A73
		Friend Overridable Property Label13 As Label

		' Token: 0x170032E4 RID: 13028
		' (get) Token: 0x06008A41 RID: 35393 RVA: 0x0004387C File Offset: 0x00041A7C
		' (set) Token: 0x06008A42 RID: 35394 RVA: 0x00043886 File Offset: 0x00041A86
		Friend Overridable Property Label43 As Label

		' Token: 0x170032E5 RID: 13029
		' (get) Token: 0x06008A43 RID: 35395 RVA: 0x0004388F File Offset: 0x00041A8F
		' (set) Token: 0x06008A44 RID: 35396 RVA: 0x00043899 File Offset: 0x00041A99
		Friend Overridable Property txtCESSAmt As TextBox

		' Token: 0x170032E6 RID: 13030
		' (get) Token: 0x06008A45 RID: 35397 RVA: 0x000438A2 File Offset: 0x00041AA2
		' (set) Token: 0x06008A46 RID: 35398 RVA: 0x000438AC File Offset: 0x00041AAC
		Friend Overridable Property Label41 As Label

		' Token: 0x170032E7 RID: 13031
		' (get) Token: 0x06008A47 RID: 35399 RVA: 0x000438B5 File Offset: 0x00041AB5
		' (set) Token: 0x06008A48 RID: 35400 RVA: 0x000438BF File Offset: 0x00041ABF
		Friend Overridable Property Label42 As Label

		' Token: 0x170032E8 RID: 13032
		' (get) Token: 0x06008A49 RID: 35401 RVA: 0x000438C8 File Offset: 0x00041AC8
		' (set) Token: 0x06008A4A RID: 35402 RVA: 0x0065F980 File Offset: 0x0065DB80
		Private _txtCESSPer As TextBox
		Friend Overridable Property txtCESSPer As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCESSPer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtCESSPer_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtCESSPer_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCESSPer_KeyDown
				Dim textBox As TextBox = Me._txtCESSPer
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCESSPer = value
				textBox = Me._txtCESSPer
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170032E9 RID: 13033
		' (get) Token: 0x06008A4B RID: 35403 RVA: 0x000438D2 File Offset: 0x00041AD2
		' (set) Token: 0x06008A4C RID: 35404 RVA: 0x000438DC File Offset: 0x00041ADC
		Friend Overridable Property txtIGSTAmt As TextBox

		' Token: 0x170032EA RID: 13034
		' (get) Token: 0x06008A4D RID: 35405 RVA: 0x000438E5 File Offset: 0x00041AE5
		' (set) Token: 0x06008A4E RID: 35406 RVA: 0x000438EF File Offset: 0x00041AEF
		Friend Overridable Property Label34 As Label

		' Token: 0x170032EB RID: 13035
		' (get) Token: 0x06008A4F RID: 35407 RVA: 0x000438F8 File Offset: 0x00041AF8
		' (set) Token: 0x06008A50 RID: 35408 RVA: 0x00043902 File Offset: 0x00041B02
		Friend Overridable Property Label35 As Label

		' Token: 0x170032EC RID: 13036
		' (get) Token: 0x06008A51 RID: 35409 RVA: 0x0004390B File Offset: 0x00041B0B
		' (set) Token: 0x06008A52 RID: 35410 RVA: 0x0065F9FC File Offset: 0x0065DBFC
		Private _txtIGSTPer As TextBox
		Friend Overridable Property txtIGSTPer As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtIGSTPer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtIGSTPer_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtIGSTPer_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtIGSTPer_KeyDown
				Dim textBox As TextBox = Me._txtIGSTPer
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtIGSTPer = value
				textBox = Me._txtIGSTPer
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170032ED RID: 13037
		' (get) Token: 0x06008A53 RID: 35411 RVA: 0x00043915 File Offset: 0x00041B15
		' (set) Token: 0x06008A54 RID: 35412 RVA: 0x0004391F File Offset: 0x00041B1F
		Friend Overridable Property txtSGSTAmt As TextBox

		' Token: 0x170032EE RID: 13038
		' (get) Token: 0x06008A55 RID: 35413 RVA: 0x00043928 File Offset: 0x00041B28
		' (set) Token: 0x06008A56 RID: 35414 RVA: 0x00043932 File Offset: 0x00041B32
		Friend Overridable Property Label28 As Label

		' Token: 0x170032EF RID: 13039
		' (get) Token: 0x06008A57 RID: 35415 RVA: 0x0004393B File Offset: 0x00041B3B
		' (set) Token: 0x06008A58 RID: 35416 RVA: 0x00043945 File Offset: 0x00041B45
		Friend Overridable Property Label33 As Label

		' Token: 0x170032F0 RID: 13040
		' (get) Token: 0x06008A59 RID: 35417 RVA: 0x0004394E File Offset: 0x00041B4E
		' (set) Token: 0x06008A5A RID: 35418 RVA: 0x0065FA78 File Offset: 0x0065DC78
		Private _txtSGSTPer As TextBox
		Friend Overridable Property txtSGSTPer As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSGSTPer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtSGSTPer_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtSGSTPer_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSGSTPer_KeyDown
				Dim textBox As TextBox = Me._txtSGSTPer
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtSGSTPer = value
				textBox = Me._txtSGSTPer
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170032F1 RID: 13041
		' (get) Token: 0x06008A5B RID: 35419 RVA: 0x00043958 File Offset: 0x00041B58
		' (set) Token: 0x06008A5C RID: 35420 RVA: 0x00043962 File Offset: 0x00041B62
		Friend Overridable Property txtCGSTAmt As TextBox

		' Token: 0x170032F2 RID: 13042
		' (get) Token: 0x06008A5D RID: 35421 RVA: 0x0004396B File Offset: 0x00041B6B
		' (set) Token: 0x06008A5E RID: 35422 RVA: 0x00043975 File Offset: 0x00041B75
		Friend Overridable Property Label22 As Label

		' Token: 0x170032F3 RID: 13043
		' (get) Token: 0x06008A5F RID: 35423 RVA: 0x0004397E File Offset: 0x00041B7E
		' (set) Token: 0x06008A60 RID: 35424 RVA: 0x00043988 File Offset: 0x00041B88
		Friend Overridable Property Label25 As Label

		' Token: 0x170032F4 RID: 13044
		' (get) Token: 0x06008A61 RID: 35425 RVA: 0x00043991 File Offset: 0x00041B91
		' (set) Token: 0x06008A62 RID: 35426 RVA: 0x0065FAF4 File Offset: 0x0065DCF4
		Private _txtCGSTPer As TextBox
		Friend Overridable Property txtCGSTPer As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCGSTPer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtCGSTPer_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtCGSTPer_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCGSTPer_KeyDown
				Dim textBox As TextBox = Me._txtCGSTPer
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCGSTPer = value
				textBox = Me._txtCGSTPer
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170032F5 RID: 13045
		' (get) Token: 0x06008A63 RID: 35427 RVA: 0x0004399B File Offset: 0x00041B9B
		' (set) Token: 0x06008A64 RID: 35428 RVA: 0x000439A5 File Offset: 0x00041BA5
		Friend Overridable Property lblQty_S As Label

		' Token: 0x170032F6 RID: 13046
		' (get) Token: 0x06008A65 RID: 35429 RVA: 0x000439AE File Offset: 0x00041BAE
		' (set) Token: 0x06008A66 RID: 35430 RVA: 0x000439B8 File Offset: 0x00041BB8
		Friend Overridable Property Label5 As Label

		' Token: 0x170032F7 RID: 13047
		' (get) Token: 0x06008A67 RID: 35431 RVA: 0x000439C1 File Offset: 0x00041BC1
		' (set) Token: 0x06008A68 RID: 35432 RVA: 0x0065FB70 File Offset: 0x0065DD70
		Private _cmbTerms As ComboBox
		Friend Overridable Property cmbTerms As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbTerms
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbTerms_KeyDown
				Dim comboBox As ComboBox = Me._cmbTerms
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbTerms = value
				comboBox = Me._cmbTerms
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170032F8 RID: 13048
		' (get) Token: 0x06008A69 RID: 35433 RVA: 0x000439CB File Offset: 0x00041BCB
		' (set) Token: 0x06008A6A RID: 35434 RVA: 0x000439D5 File Offset: 0x00041BD5
		Friend Overridable Property Label15 As Label

		' Token: 0x170032F9 RID: 13049
		' (get) Token: 0x06008A6B RID: 35435 RVA: 0x000439DE File Offset: 0x00041BDE
		' (set) Token: 0x06008A6C RID: 35436 RVA: 0x0065FBB4 File Offset: 0x0065DDB4
		Private _Timer1 As Timer
		Friend Overridable Property Timer1 As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick
				Dim timer As Timer = Me._Timer1
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer1 = value
				timer = Me._Timer1
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170032FA RID: 13050
		' (get) Token: 0x06008A6D RID: 35437 RVA: 0x000439E8 File Offset: 0x00041BE8
		' (set) Token: 0x06008A6E RID: 35438 RVA: 0x0065FBF8 File Offset: 0x0065DDF8
		Private _cmbDiscountType As ComboBox
		Friend Overridable Property cmbDiscountType As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbDiscountType
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbDiscountType_SelectedIndexChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbDiscountType_KeyDown
				Dim comboBox As ComboBox = Me._cmbDiscountType
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbDiscountType = value
				comboBox = Me._cmbDiscountType
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170032FB RID: 13051
		' (get) Token: 0x06008A6F RID: 35439 RVA: 0x000439F2 File Offset: 0x00041BF2
		' (set) Token: 0x06008A70 RID: 35440 RVA: 0x000439FC File Offset: 0x00041BFC
		Friend Overridable Property Label17 As Label

		' Token: 0x170032FC RID: 13052
		' (get) Token: 0x06008A71 RID: 35441 RVA: 0x00043A05 File Offset: 0x00041C05
		' (set) Token: 0x06008A72 RID: 35442 RVA: 0x00043A0F File Offset: 0x00041C0F
		Friend Overridable Property Label48 As Label

		' Token: 0x170032FD RID: 13053
		' (get) Token: 0x06008A73 RID: 35443 RVA: 0x00043A18 File Offset: 0x00041C18
		' (set) Token: 0x06008A74 RID: 35444 RVA: 0x00043A22 File Offset: 0x00041C22
		Friend Overridable Property txtInvCode1 As TextBox

		' Token: 0x170032FE RID: 13054
		' (get) Token: 0x06008A75 RID: 35445 RVA: 0x00043A2B File Offset: 0x00041C2B
		' (set) Token: 0x06008A76 RID: 35446 RVA: 0x00043A35 File Offset: 0x00041C35
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x170032FF RID: 13055
		' (get) Token: 0x06008A77 RID: 35447 RVA: 0x00043A3E File Offset: 0x00041C3E
		' (set) Token: 0x06008A78 RID: 35448 RVA: 0x00043A48 File Offset: 0x00041C48
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x17003300 RID: 13056
		' (get) Token: 0x06008A79 RID: 35449 RVA: 0x00043A51 File Offset: 0x00041C51
		' (set) Token: 0x06008A7A RID: 35450 RVA: 0x00043A5B File Offset: 0x00041C5B
		Friend Overridable Property txtSuffix As TextBox

		' Token: 0x17003301 RID: 13057
		' (get) Token: 0x06008A7B RID: 35451 RVA: 0x00043A64 File Offset: 0x00041C64
		' (set) Token: 0x06008A7C RID: 35452 RVA: 0x0065FC58 File Offset: 0x0065DE58
		Private _cmbSupplierName As ComboBox
		Friend Overridable Property cmbSupplierName As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSupplierName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbSupplierName_SelectedIndexChanged
				Dim eventHandler2 As EventHandler = AddressOf Me.cmbSupplierName_Validated
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbSupplierName_KeyDown
				Dim comboBox As ComboBox = Me._cmbSupplierName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.Validated, eventHandler2
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbSupplierName = value
				comboBox = Me._cmbSupplierName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.Validated, eventHandler2
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003302 RID: 13058
		' (get) Token: 0x06008A7D RID: 35453 RVA: 0x00043A6E File Offset: 0x00041C6E
		' (set) Token: 0x06008A7E RID: 35454 RVA: 0x0065FCD4 File Offset: 0x0065DED4
		Private _txtNP As TextBox
		Friend Overridable Property txtNP As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtNP
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtNP_KeyDown
				Dim textBox As TextBox = Me._txtNP
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtNP = value
				textBox = Me._txtNP
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003303 RID: 13059
		' (get) Token: 0x06008A7F RID: 35455 RVA: 0x00043A78 File Offset: 0x00041C78
		' (set) Token: 0x06008A80 RID: 35456 RVA: 0x0065FD18 File Offset: 0x0065DF18
		Private _btnNext As Button
		Friend Overridable Property btnNext As Button
			<CompilerGenerated()>
			Get
				Return Me._btnNext
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnNext_Click
				Dim button As Button = Me._btnNext
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnNext = value
				button = Me._btnNext
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003304 RID: 13060
		' (get) Token: 0x06008A81 RID: 35457 RVA: 0x00043A82 File Offset: 0x00041C82
		' (set) Token: 0x06008A82 RID: 35458 RVA: 0x0065FD5C File Offset: 0x0065DF5C
		Private _btnFirst As Button
		Friend Overridable Property btnFirst As Button
			<CompilerGenerated()>
			Get
				Return Me._btnFirst
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnFirst_Click
				Dim button As Button = Me._btnFirst
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnFirst = value
				button = Me._btnFirst
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003305 RID: 13061
		' (get) Token: 0x06008A83 RID: 35459 RVA: 0x00043A8C File Offset: 0x00041C8C
		' (set) Token: 0x06008A84 RID: 35460 RVA: 0x0065FDA0 File Offset: 0x0065DFA0
		Private _txtPrev As Button
		Friend Overridable Property txtPrev As Button
			<CompilerGenerated()>
			Get
				Return Me._txtPrev
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.txtPrev_Click
				Dim button As Button = Me._txtPrev
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._txtPrev = value
				button = Me._txtPrev
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003306 RID: 13062
		' (get) Token: 0x06008A85 RID: 35461 RVA: 0x00043A96 File Offset: 0x00041C96
		' (set) Token: 0x06008A86 RID: 35462 RVA: 0x0065FDE4 File Offset: 0x0065DFE4
		Private _btnLast As Button
		Friend Overridable Property btnLast As Button
			<CompilerGenerated()>
			Get
				Return Me._btnLast
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnLast_Click
				Dim button As Button = Me._btnLast
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnLast = value
				button = Me._btnLast
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003307 RID: 13063
		' (get) Token: 0x06008A87 RID: 35463 RVA: 0x00043AA0 File Offset: 0x00041CA0
		' (set) Token: 0x06008A88 RID: 35464 RVA: 0x0065FE28 File Offset: 0x0065E028
		Private _Button34 As Button
		Friend Overridable Property Button34 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button34
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button34_Click
				Dim button As Button = Me._Button34
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button34 = value
				button = Me._Button34
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003308 RID: 13064
		' (get) Token: 0x06008A89 RID: 35465 RVA: 0x00043AAA File Offset: 0x00041CAA
		' (set) Token: 0x06008A8A RID: 35466 RVA: 0x00043AB4 File Offset: 0x00041CB4
		Friend Overridable Property txtRsToWords As Label

		' Token: 0x17003309 RID: 13065
		' (get) Token: 0x06008A8B RID: 35467 RVA: 0x00043ABD File Offset: 0x00041CBD
		' (set) Token: 0x06008A8C RID: 35468 RVA: 0x0065FE6C File Offset: 0x0065E06C
		Private _Button35 As Button
		Friend Overridable Property Button35 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button35
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button35_Click
				Dim button As Button = Me._Button35
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button35 = value
				button = Me._Button35
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700330A RID: 13066
		' (get) Token: 0x06008A8D RID: 35469 RVA: 0x00043AC7 File Offset: 0x00041CC7
		' (set) Token: 0x06008A8E RID: 35470 RVA: 0x00043AD1 File Offset: 0x00041CD1
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x1700330B RID: 13067
		' (get) Token: 0x06008A8F RID: 35471 RVA: 0x00043ADA File Offset: 0x00041CDA
		' (set) Token: 0x06008A90 RID: 35472 RVA: 0x00043AE4 File Offset: 0x00041CE4
		Friend Overridable Property F2 As TextBox

		' Token: 0x1700330C RID: 13068
		' (get) Token: 0x06008A91 RID: 35473 RVA: 0x00043AED File Offset: 0x00041CED
		' (set) Token: 0x06008A92 RID: 35474 RVA: 0x00043AF7 File Offset: 0x00041CF7
		Friend Overridable Property F1 As TextBox

		' Token: 0x1700330D RID: 13069
		' (get) Token: 0x06008A93 RID: 35475 RVA: 0x00043B00 File Offset: 0x00041D00
		' (set) Token: 0x06008A94 RID: 35476 RVA: 0x00043B0A File Offset: 0x00041D0A
		Friend Overridable Property Label18 As Label

		' Token: 0x1700330E RID: 13070
		' (get) Token: 0x06008A95 RID: 35477 RVA: 0x00043B13 File Offset: 0x00041D13
		' (set) Token: 0x06008A96 RID: 35478 RVA: 0x00043B1D File Offset: 0x00041D1D
		Friend Overridable Property txtTaxType As TextBox

		' Token: 0x1700330F RID: 13071
		' (get) Token: 0x06008A97 RID: 35479 RVA: 0x00043B26 File Offset: 0x00041D26
		' (set) Token: 0x06008A98 RID: 35480 RVA: 0x00043B30 File Offset: 0x00041D30
		Friend Overridable Property Label19 As Label

		' Token: 0x17003310 RID: 13072
		' (get) Token: 0x06008A99 RID: 35481 RVA: 0x00043B39 File Offset: 0x00041D39
		' (set) Token: 0x06008A9A RID: 35482 RVA: 0x00043B43 File Offset: 0x00041D43
		Friend Overridable Property txtTaxableAmt As TextBox

		' Token: 0x17003311 RID: 13073
		' (get) Token: 0x06008A9B RID: 35483 RVA: 0x00043B4C File Offset: 0x00041D4C
		' (set) Token: 0x06008A9C RID: 35484 RVA: 0x00043B56 File Offset: 0x00041D56
		Friend Overridable Property txtCompanyState As TextBox

		' Token: 0x17003312 RID: 13074
		' (get) Token: 0x06008A9D RID: 35485 RVA: 0x00043B5F File Offset: 0x00041D5F
		' (set) Token: 0x06008A9E RID: 35486 RVA: 0x0065FEB0 File Offset: 0x0065E0B0
		Private _CheckBox7 As CheckBox
		Friend Overridable Property CheckBox7 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox7_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox7
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox7 = value
				checkBox = Me._CheckBox7
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003313 RID: 13075
		' (get) Token: 0x06008A9F RID: 35487 RVA: 0x00043B69 File Offset: 0x00041D69
		' (set) Token: 0x06008AA0 RID: 35488 RVA: 0x0065FEF4 File Offset: 0x0065E0F4
		Private _CheckBox6 As CheckBox
		Friend Overridable Property CheckBox6 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox6_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox6
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox6 = value
				checkBox = Me._CheckBox6
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003314 RID: 13076
		' (get) Token: 0x06008AA1 RID: 35489 RVA: 0x00043B73 File Offset: 0x00041D73
		' (set) Token: 0x06008AA2 RID: 35490 RVA: 0x00043B7D File Offset: 0x00041D7D
		Friend Overridable Property TextBox8 As TextBox

		' Token: 0x17003315 RID: 13077
		' (get) Token: 0x06008AA3 RID: 35491 RVA: 0x00043B86 File Offset: 0x00041D86
		' (set) Token: 0x06008AA4 RID: 35492 RVA: 0x00043B90 File Offset: 0x00041D90
		Friend Overridable Property TextBox7 As TextBox

		' Token: 0x17003316 RID: 13078
		' (get) Token: 0x06008AA5 RID: 35493 RVA: 0x00043B99 File Offset: 0x00041D99
		' (set) Token: 0x06008AA6 RID: 35494 RVA: 0x0065FF38 File Offset: 0x0065E138
		Private _TextBox10 As TextBox
		Friend Overridable Property TextBox10 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox10
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox10_TextChanged
				Dim textBox As TextBox = Me._TextBox10
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox10 = value
				textBox = Me._TextBox10
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003317 RID: 13079
		' (get) Token: 0x06008AA7 RID: 35495 RVA: 0x00043BA3 File Offset: 0x00041DA3
		' (set) Token: 0x06008AA8 RID: 35496 RVA: 0x0065FF7C File Offset: 0x0065E17C
		Private _TextBox9 As TextBox
		Friend Overridable Property TextBox9 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox9
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox9_TextChanged
				Dim textBox As TextBox = Me._TextBox9
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox9 = value
				textBox = Me._TextBox9
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003318 RID: 13080
		' (get) Token: 0x06008AA9 RID: 35497 RVA: 0x00043BAD File Offset: 0x00041DAD
		' (set) Token: 0x06008AAA RID: 35498 RVA: 0x0065FFC0 File Offset: 0x0065E1C0
		Private _txtWholesale As TextBox
		Friend Overridable Property txtWholesale As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtWholesale
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtWholesale_TextChanged
				Dim textBox As TextBox = Me._txtWholesale
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtWholesale = value
				textBox = Me._txtWholesale
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003319 RID: 13081
		' (get) Token: 0x06008AAB RID: 35499 RVA: 0x00043BB7 File Offset: 0x00041DB7
		' (set) Token: 0x06008AAC RID: 35500 RVA: 0x00660004 File Offset: 0x0065E204
		Private _txtRetail As TextBox
		Friend Overridable Property txtRetail As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtRetail
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtRetail_TextChanged
				Dim textBox As TextBox = Me._txtRetail
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtRetail = value
				textBox = Me._txtRetail
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700331A RID: 13082
		' (get) Token: 0x06008AAD RID: 35501 RVA: 0x00043BC1 File Offset: 0x00041DC1
		' (set) Token: 0x06008AAE RID: 35502 RVA: 0x00043BCB File Offset: 0x00041DCB
		Friend Overridable Property Label21 As Label

		' Token: 0x1700331B RID: 13083
		' (get) Token: 0x06008AAF RID: 35503 RVA: 0x00043BD4 File Offset: 0x00041DD4
		' (set) Token: 0x06008AB0 RID: 35504 RVA: 0x00043BDE File Offset: 0x00041DDE
		Friend Overridable Property Label20 As Label

		' Token: 0x1700331C RID: 13084
		' (get) Token: 0x06008AB1 RID: 35505 RVA: 0x00043BE7 File Offset: 0x00041DE7
		' (set) Token: 0x06008AB2 RID: 35506 RVA: 0x00660048 File Offset: 0x0065E248
		Private _dgw4 As DataGridView
		Friend Overridable Property dgw4 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw4_KeyUp
				Dim keyEventHandler2 As KeyEventHandler = AddressOf Me.dgw4_KeyDown
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw4_MouseClick
				Dim dataGridView As DataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyUp, keyEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler2
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw4 = value
				dataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyUp, keyEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler2
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700331D RID: 13085
		' (get) Token: 0x06008AB3 RID: 35507 RVA: 0x00043BF1 File Offset: 0x00041DF1
		' (set) Token: 0x06008AB4 RID: 35508 RVA: 0x00043BFB File Offset: 0x00041DFB
		Friend Overridable Property Label37 As Label

		' Token: 0x1700331E RID: 13086
		' (get) Token: 0x06008AB5 RID: 35509 RVA: 0x00043C04 File Offset: 0x00041E04
		' (set) Token: 0x06008AB6 RID: 35510 RVA: 0x00043C0E File Offset: 0x00041E0E
		Friend Overridable Property Label32 As Label

		' Token: 0x1700331F RID: 13087
		' (get) Token: 0x06008AB7 RID: 35511 RVA: 0x00043C17 File Offset: 0x00041E17
		' (set) Token: 0x06008AB8 RID: 35512 RVA: 0x00043C21 File Offset: 0x00041E21
		Friend Overridable Property Label24 As Label

		' Token: 0x17003320 RID: 13088
		' (get) Token: 0x06008AB9 RID: 35513 RVA: 0x00043C2A File Offset: 0x00041E2A
		' (set) Token: 0x06008ABA RID: 35514 RVA: 0x00043C34 File Offset: 0x00041E34
		Friend Overridable Property txtBarcode As TextBox

		' Token: 0x17003321 RID: 13089
		' (get) Token: 0x06008ABB RID: 35515 RVA: 0x00043C3D File Offset: 0x00041E3D
		' (set) Token: 0x06008ABC RID: 35516 RVA: 0x00043C47 File Offset: 0x00041E47
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17003322 RID: 13090
		' (get) Token: 0x06008ABD RID: 35517 RVA: 0x00043C50 File Offset: 0x00041E50
		' (set) Token: 0x06008ABE RID: 35518 RVA: 0x00043C5A File Offset: 0x00041E5A
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17003323 RID: 13091
		' (get) Token: 0x06008ABF RID: 35519 RVA: 0x00043C63 File Offset: 0x00041E63
		' (set) Token: 0x06008AC0 RID: 35520 RVA: 0x00043C6D File Offset: 0x00041E6D
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17003324 RID: 13092
		' (get) Token: 0x06008AC1 RID: 35521 RVA: 0x00043C76 File Offset: 0x00041E76
		' (set) Token: 0x06008AC2 RID: 35522 RVA: 0x00043C80 File Offset: 0x00041E80
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17003325 RID: 13093
		' (get) Token: 0x06008AC3 RID: 35523 RVA: 0x00043C89 File Offset: 0x00041E89
		' (set) Token: 0x06008AC4 RID: 35524 RVA: 0x00043C93 File Offset: 0x00041E93
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17003326 RID: 13094
		' (get) Token: 0x06008AC5 RID: 35525 RVA: 0x00043C9C File Offset: 0x00041E9C
		' (set) Token: 0x06008AC6 RID: 35526 RVA: 0x00043CA6 File Offset: 0x00041EA6
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17003327 RID: 13095
		' (get) Token: 0x06008AC7 RID: 35527 RVA: 0x00043CAF File Offset: 0x00041EAF
		' (set) Token: 0x06008AC8 RID: 35528 RVA: 0x00043CB9 File Offset: 0x00041EB9
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17003328 RID: 13096
		' (get) Token: 0x06008AC9 RID: 35529 RVA: 0x00043CC2 File Offset: 0x00041EC2
		' (set) Token: 0x06008ACA RID: 35530 RVA: 0x00043CCC File Offset: 0x00041ECC
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17003329 RID: 13097
		' (get) Token: 0x06008ACB RID: 35531 RVA: 0x00043CD5 File Offset: 0x00041ED5
		' (set) Token: 0x06008ACC RID: 35532 RVA: 0x00043CDF File Offset: 0x00041EDF
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x1700332A RID: 13098
		' (get) Token: 0x06008ACD RID: 35533 RVA: 0x00043CE8 File Offset: 0x00041EE8
		' (set) Token: 0x06008ACE RID: 35534 RVA: 0x00043CF2 File Offset: 0x00041EF2
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x1700332B RID: 13099
		' (get) Token: 0x06008ACF RID: 35535 RVA: 0x00043CFB File Offset: 0x00041EFB
		' (set) Token: 0x06008AD0 RID: 35536 RVA: 0x00043D05 File Offset: 0x00041F05
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x1700332C RID: 13100
		' (get) Token: 0x06008AD1 RID: 35537 RVA: 0x00043D0E File Offset: 0x00041F0E
		' (set) Token: 0x06008AD2 RID: 35538 RVA: 0x00043D18 File Offset: 0x00041F18
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x1700332D RID: 13101
		' (get) Token: 0x06008AD3 RID: 35539 RVA: 0x00043D21 File Offset: 0x00041F21
		' (set) Token: 0x06008AD4 RID: 35540 RVA: 0x00043D2B File Offset: 0x00041F2B
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x1700332E RID: 13102
		' (get) Token: 0x06008AD5 RID: 35541 RVA: 0x00043D34 File Offset: 0x00041F34
		' (set) Token: 0x06008AD6 RID: 35542 RVA: 0x00043D3E File Offset: 0x00041F3E
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x1700332F RID: 13103
		' (get) Token: 0x06008AD7 RID: 35543 RVA: 0x00043D47 File Offset: 0x00041F47
		' (set) Token: 0x06008AD8 RID: 35544 RVA: 0x00043D51 File Offset: 0x00041F51
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17003330 RID: 13104
		' (get) Token: 0x06008AD9 RID: 35545 RVA: 0x00043D5A File Offset: 0x00041F5A
		' (set) Token: 0x06008ADA RID: 35546 RVA: 0x00043D64 File Offset: 0x00041F64
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17003331 RID: 13105
		' (get) Token: 0x06008ADB RID: 35547 RVA: 0x00043D6D File Offset: 0x00041F6D
		' (set) Token: 0x06008ADC RID: 35548 RVA: 0x00043D77 File Offset: 0x00041F77
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17003332 RID: 13106
		' (get) Token: 0x06008ADD RID: 35549 RVA: 0x00043D80 File Offset: 0x00041F80
		' (set) Token: 0x06008ADE RID: 35550 RVA: 0x00043D8A File Offset: 0x00041F8A
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17003333 RID: 13107
		' (get) Token: 0x06008ADF RID: 35551 RVA: 0x00043D93 File Offset: 0x00041F93
		' (set) Token: 0x06008AE0 RID: 35552 RVA: 0x00043D9D File Offset: 0x00041F9D
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17003334 RID: 13108
		' (get) Token: 0x06008AE1 RID: 35553 RVA: 0x00043DA6 File Offset: 0x00041FA6
		' (set) Token: 0x06008AE2 RID: 35554 RVA: 0x00043DB0 File Offset: 0x00041FB0
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17003335 RID: 13109
		' (get) Token: 0x06008AE3 RID: 35555 RVA: 0x00043DB9 File Offset: 0x00041FB9
		' (set) Token: 0x06008AE4 RID: 35556 RVA: 0x00043DC3 File Offset: 0x00041FC3
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17003336 RID: 13110
		' (get) Token: 0x06008AE5 RID: 35557 RVA: 0x00043DCC File Offset: 0x00041FCC
		' (set) Token: 0x06008AE6 RID: 35558 RVA: 0x006600C4 File Offset: 0x0065E2C4
		Private _NumericUpDown1 As NumericUpDown
		Friend Overridable Property NumericUpDown1 As NumericUpDown
			<CompilerGenerated()>
			Get
				Return Me._NumericUpDown1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As NumericUpDown)
				Dim eventHandler As EventHandler = AddressOf Me.NumericUpDown1_ValueChanged
				Dim numericUpDown As NumericUpDown = Me._NumericUpDown1
				If numericUpDown IsNot Nothing Then
					RemoveHandler numericUpDown.ValueChanged, eventHandler
				End If
				Me._NumericUpDown1 = value
				numericUpDown = Me._NumericUpDown1
				If numericUpDown IsNot Nothing Then
					AddHandler numericUpDown.ValueChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003337 RID: 13111
		' (get) Token: 0x06008AE7 RID: 35559 RVA: 0x00043DD6 File Offset: 0x00041FD6
		' (set) Token: 0x06008AE8 RID: 35560 RVA: 0x00043DE0 File Offset: 0x00041FE0
		Friend Overridable Property DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn

		' Token: 0x17003338 RID: 13112
		' (get) Token: 0x06008AE9 RID: 35561 RVA: 0x00043DE9 File Offset: 0x00041FE9
		' (set) Token: 0x06008AEA RID: 35562 RVA: 0x00043DF3 File Offset: 0x00041FF3
		Friend Overridable Property DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn

		' Token: 0x17003339 RID: 13113
		' (get) Token: 0x06008AEB RID: 35563 RVA: 0x00043DFC File Offset: 0x00041FFC
		' (set) Token: 0x06008AEC RID: 35564 RVA: 0x00043E06 File Offset: 0x00042006
		Friend Overridable Property DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn

		' Token: 0x1700333A RID: 13114
		' (get) Token: 0x06008AED RID: 35565 RVA: 0x00043E0F File Offset: 0x0004200F
		' (set) Token: 0x06008AEE RID: 35566 RVA: 0x00043E19 File Offset: 0x00042019
		Friend Overridable Property DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn

		' Token: 0x1700333B RID: 13115
		' (get) Token: 0x06008AEF RID: 35567 RVA: 0x00043E22 File Offset: 0x00042022
		' (set) Token: 0x06008AF0 RID: 35568 RVA: 0x00043E2C File Offset: 0x0004202C
		Friend Overridable Property DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn

		' Token: 0x1700333C RID: 13116
		' (get) Token: 0x06008AF1 RID: 35569 RVA: 0x00043E35 File Offset: 0x00042035
		' (set) Token: 0x06008AF2 RID: 35570 RVA: 0x00043E3F File Offset: 0x0004203F
		Friend Overridable Property DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn

		' Token: 0x1700333D RID: 13117
		' (get) Token: 0x06008AF3 RID: 35571 RVA: 0x00043E48 File Offset: 0x00042048
		' (set) Token: 0x06008AF4 RID: 35572 RVA: 0x00043E52 File Offset: 0x00042052
		Friend Overridable Property DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn

		' Token: 0x1700333E RID: 13118
		' (get) Token: 0x06008AF5 RID: 35573 RVA: 0x00043E5B File Offset: 0x0004205B
		' (set) Token: 0x06008AF6 RID: 35574 RVA: 0x00043E65 File Offset: 0x00042065
		Friend Overridable Property DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn

		' Token: 0x1700333F RID: 13119
		' (get) Token: 0x06008AF7 RID: 35575 RVA: 0x00043E6E File Offset: 0x0004206E
		' (set) Token: 0x06008AF8 RID: 35576 RVA: 0x00043E78 File Offset: 0x00042078
		Friend Overridable Property DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn

		' Token: 0x17003340 RID: 13120
		' (get) Token: 0x06008AF9 RID: 35577 RVA: 0x00043E81 File Offset: 0x00042081
		' (set) Token: 0x06008AFA RID: 35578 RVA: 0x00043E8B File Offset: 0x0004208B
		Friend Overridable Property DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn

		' Token: 0x17003341 RID: 13121
		' (get) Token: 0x06008AFB RID: 35579 RVA: 0x00043E94 File Offset: 0x00042094
		' (set) Token: 0x06008AFC RID: 35580 RVA: 0x00043E9E File Offset: 0x0004209E
		Friend Overridable Property DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn

		' Token: 0x17003342 RID: 13122
		' (get) Token: 0x06008AFD RID: 35581 RVA: 0x00043EA7 File Offset: 0x000420A7
		' (set) Token: 0x06008AFE RID: 35582 RVA: 0x00043EB1 File Offset: 0x000420B1
		Friend Overridable Property DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn

		' Token: 0x17003343 RID: 13123
		' (get) Token: 0x06008AFF RID: 35583 RVA: 0x00043EBA File Offset: 0x000420BA
		' (set) Token: 0x06008B00 RID: 35584 RVA: 0x00043EC4 File Offset: 0x000420C4
		Friend Overridable Property DataGridViewTextBoxColumn35 As DataGridViewTextBoxColumn

		' Token: 0x17003344 RID: 13124
		' (get) Token: 0x06008B01 RID: 35585 RVA: 0x00043ECD File Offset: 0x000420CD
		' (set) Token: 0x06008B02 RID: 35586 RVA: 0x00043ED7 File Offset: 0x000420D7
		Friend Overridable Property DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn

		' Token: 0x17003345 RID: 13125
		' (get) Token: 0x06008B03 RID: 35587 RVA: 0x00043EE0 File Offset: 0x000420E0
		' (set) Token: 0x06008B04 RID: 35588 RVA: 0x00043EEA File Offset: 0x000420EA
		Friend Overridable Property DataGridViewTextBoxColumn37 As DataGridViewTextBoxColumn

		' Token: 0x17003346 RID: 13126
		' (get) Token: 0x06008B05 RID: 35589 RVA: 0x00043EF3 File Offset: 0x000420F3
		' (set) Token: 0x06008B06 RID: 35590 RVA: 0x00043EFD File Offset: 0x000420FD
		Friend Overridable Property DataGridViewTextBoxColumn38 As DataGridViewTextBoxColumn

		' Token: 0x17003347 RID: 13127
		' (get) Token: 0x06008B07 RID: 35591 RVA: 0x00043F06 File Offset: 0x00042106
		' (set) Token: 0x06008B08 RID: 35592 RVA: 0x00043F10 File Offset: 0x00042110
		Friend Overridable Property DataGridViewTextBoxColumn39 As DataGridViewTextBoxColumn

		' Token: 0x17003348 RID: 13128
		' (get) Token: 0x06008B09 RID: 35593 RVA: 0x00043F19 File Offset: 0x00042119
		' (set) Token: 0x06008B0A RID: 35594 RVA: 0x00043F23 File Offset: 0x00042123
		Friend Overridable Property DataGridViewTextBoxColumn40 As DataGridViewTextBoxColumn

		' Token: 0x17003349 RID: 13129
		' (get) Token: 0x06008B0B RID: 35595 RVA: 0x00043F2C File Offset: 0x0004212C
		' (set) Token: 0x06008B0C RID: 35596 RVA: 0x00043F36 File Offset: 0x00042136
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x1700334A RID: 13130
		' (get) Token: 0x06008B0D RID: 35597 RVA: 0x00043F3F File Offset: 0x0004213F
		' (set) Token: 0x06008B0E RID: 35598 RVA: 0x00043F49 File Offset: 0x00042149
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x1700334B RID: 13131
		' (get) Token: 0x06008B0F RID: 35599 RVA: 0x00043F52 File Offset: 0x00042152
		' (set) Token: 0x06008B10 RID: 35600 RVA: 0x00043F5C File Offset: 0x0004215C
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x1700334C RID: 13132
		' (get) Token: 0x06008B11 RID: 35601 RVA: 0x00043F65 File Offset: 0x00042165
		' (set) Token: 0x06008B12 RID: 35602 RVA: 0x00043F6F File Offset: 0x0004216F
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x1700334D RID: 13133
		' (get) Token: 0x06008B13 RID: 35603 RVA: 0x00043F78 File Offset: 0x00042178
		' (set) Token: 0x06008B14 RID: 35604 RVA: 0x00043F82 File Offset: 0x00042182
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x1700334E RID: 13134
		' (get) Token: 0x06008B15 RID: 35605 RVA: 0x00043F8B File Offset: 0x0004218B
		' (set) Token: 0x06008B16 RID: 35606 RVA: 0x00043F95 File Offset: 0x00042195
		Friend Overridable Property lblCPhone As Label

		' Token: 0x1700334F RID: 13135
		' (get) Token: 0x06008B17 RID: 35607 RVA: 0x00043F9E File Offset: 0x0004219E
		' (set) Token: 0x06008B18 RID: 35608 RVA: 0x00043FA8 File Offset: 0x000421A8
		Friend Overridable Property dgwsale As DataGridView

		' Token: 0x17003350 RID: 13136
		' (get) Token: 0x06008B19 RID: 35609 RVA: 0x00043FB1 File Offset: 0x000421B1
		' (set) Token: 0x06008B1A RID: 35610 RVA: 0x00043FBB File Offset: 0x000421BB
		Friend Overridable Property DataGridViewTextBoxColumn54 As DataGridViewTextBoxColumn

		' Token: 0x17003351 RID: 13137
		' (get) Token: 0x06008B1B RID: 35611 RVA: 0x00043FC4 File Offset: 0x000421C4
		' (set) Token: 0x06008B1C RID: 35612 RVA: 0x00043FCE File Offset: 0x000421CE
		Friend Overridable Property DataGridViewTextBoxColumn55 As DataGridViewTextBoxColumn

		' Token: 0x17003352 RID: 13138
		' (get) Token: 0x06008B1D RID: 35613 RVA: 0x00043FD7 File Offset: 0x000421D7
		' (set) Token: 0x06008B1E RID: 35614 RVA: 0x00043FE1 File Offset: 0x000421E1
		Friend Overridable Property DataGridViewTextBoxColumn56 As DataGridViewTextBoxColumn

		' Token: 0x17003353 RID: 13139
		' (get) Token: 0x06008B1F RID: 35615 RVA: 0x00043FEA File Offset: 0x000421EA
		' (set) Token: 0x06008B20 RID: 35616 RVA: 0x00043FF4 File Offset: 0x000421F4
		Friend Overridable Property DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn

		' Token: 0x17003354 RID: 13140
		' (get) Token: 0x06008B21 RID: 35617 RVA: 0x00043FFD File Offset: 0x000421FD
		' (set) Token: 0x06008B22 RID: 35618 RVA: 0x00660108 File Offset: 0x0065E308
		Private _btnGetData As GelButton
		Friend Overridable Property btnGetData As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
				Dim gelButton As GelButton = Me._btnGetData
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnGetData = value
				gelButton = Me._btnGetData
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003355 RID: 13141
		' (get) Token: 0x06008B23 RID: 35619 RVA: 0x00044007 File Offset: 0x00042207
		' (set) Token: 0x06008B24 RID: 35620 RVA: 0x0066014C File Offset: 0x0065E34C
		Private _btnPrint As GelButton
		Friend Overridable Property btnPrint As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnPrint
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnPrint_Click
				Dim gelButton As GelButton = Me._btnPrint
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnPrint = value
				gelButton = Me._btnPrint
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003356 RID: 13142
		' (get) Token: 0x06008B25 RID: 35621 RVA: 0x00044011 File Offset: 0x00042211
		' (set) Token: 0x06008B26 RID: 35622 RVA: 0x00660190 File Offset: 0x0065E390
		Private _btnUpdate As GelButton
		Friend Overridable Property btnUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim gelButton As GelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnUpdate = value
				gelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003357 RID: 13143
		' (get) Token: 0x06008B27 RID: 35623 RVA: 0x0004401B File Offset: 0x0004221B
		' (set) Token: 0x06008B28 RID: 35624 RVA: 0x006601D4 File Offset: 0x0065E3D4
		Private _btnDelete As GelButton
		Friend Overridable Property btnDelete As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
				Dim gelButton As GelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDelete = value
				gelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003358 RID: 13144
		' (get) Token: 0x06008B29 RID: 35625 RVA: 0x00044025 File Offset: 0x00042225
		' (set) Token: 0x06008B2A RID: 35626 RVA: 0x00660218 File Offset: 0x0065E418
		Private _btnNew As GelButton
		Friend Overridable Property btnNew As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton4_Click
				Dim gelButton As GelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnNew = value
				gelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003359 RID: 13145
		' (get) Token: 0x06008B2B RID: 35627 RVA: 0x0004402F File Offset: 0x0004222F
		' (set) Token: 0x06008B2C RID: 35628 RVA: 0x0066025C File Offset: 0x0065E45C
		Private _btnSave As GelButton
		Friend Overridable Property btnSave As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSave = value
				gelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x06008B2D RID: 35629 RVA: 0x006602A0 File Offset: 0x0065E4A0
		Private Sub GetPurchaseTaxType()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(PurchaseTax) from Setting", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbTaxType.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbTaxType.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.cmbTaxType.SelectedIndex = 0
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06008B2E RID: 35630 RVA: 0x006603CC File Offset: 0x0065E5CC
		Public Sub GetQty_S()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select IsNull(Sum(Qty),0) from Temp_Stock where Temp_Stock.ProductID=@d1 and Temp_Stock.Barcode=@d2"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcode.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.lblQty_S.Visible = True
					Me.lblQty_S.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008B2F RID: 35631 RVA: 0x00660520 File Offset: 0x0065E720
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 PO_ID FROM PurchaseOrder ORDER BY PO_ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("PO_ID"))
				End If
				ModCommonClasses.rdr.Close()
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag Then
					text = "000" + text
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag2 Then
						text = "00" + text
					Else
						Dim flag3 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag3 Then
							text = "0" + text
						End If
					End If
				End If
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x06008B30 RID: 35632 RVA: 0x0066068C File Offset: 0x0065E88C
		Private Function GenerateIDSr() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP 1 ID FROM SrPurOrder ORDER BY ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ID"))
				End If
				ModCommonClasses.rdr.Close()
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag Then
					text = "000" + text
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag2 Then
						text = "00" + text
					Else
						Dim flag3 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag3 Then
							text = "0" + text
						End If
					End If
				End If
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x06008B31 RID: 35633 RVA: 0x006607F8 File Offset: 0x0065E9F8
		Private Sub Invoicecode()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select RTRIM(c5),RTRIM(c15) from Invcode"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtInvCode1.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtSuffix.Text = Me.F1.Text + "/" + Me.F2.Text
				Else
					Me.txtInvCode1.Text = "PO"
					Me.txtSuffix.Text = DateAndTime.Now.ToString("yyyy")
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				Dim flag4 As Boolean = Operators.CompareString(Me.txtInvCode1.Text, "", False) = 0
				If flag4 Then
					Me.txtInvCode1.Text = "PO"
				End If
				Dim flag5 As Boolean = Operators.CompareString(Me.txtSuffix.Text, "", False) = 0
				If flag5 Then
					Me.txtSuffix.Text = Me.F1.Text + "/" + Me.F2.Text
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008B32 RID: 35634 RVA: 0x006609D4 File Offset: 0x0065EBD4
		Public Sub auto()
			Try
				Me.txtPO_ID.Text = Me.GenerateID()
				Me.ntid = Me.GenerateIDSr()
				Me.txtPONo.Text = String.Concat(New String() { Me.txtInvCode1.Text, "-", Me.GenerateIDSr(), "-", Me.txtSuffix.Text })
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008B33 RID: 35635 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnClose_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x06008B34 RID: 35636 RVA: 0x00044039 File Offset: 0x00042239
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplierRecord.lblSet.Text = "PO"
			MyProject.Forms.frmSupplierRecord.Reset()
			MyProject.Forms.frmSupplierRecord.ShowDialog()
		End Sub

		' Token: 0x06008B35 RID: 35637 RVA: 0x00660A84 File Offset: 0x0065EC84
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtSupplierID.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please retrieve supplier info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbSupplierName.Focus()
			Else
				MyProject.Forms.frmProductRecord.lblSet.Text = "PO"
				MyProject.Forms.frmProductRecord.Reset()
				MyProject.Forms.frmProductRecord.ShowDialog()
				Me.txtQty.Focus()
			End If
		End Sub

		' Token: 0x06008B36 RID: 35638 RVA: 0x00660B18 File Offset: 0x0065ED18
		Public Sub Reset()
			Me.txtAddress.Text = ""
			Me.txtState.Text = ""
			Me.txtContactNo.Text = ""
			Me.txtSubTotal.Text = ""
			Me.txtSupplierID.Text = ""
			Me.cmbSupplierName.Text = ""
			Me.cmbSupplierName.SelectedIndex = -1
			Me.txtSup_ID.Text = ""
			Me.txtCGST.Text = "0.00"
			Me.txtSGST.Text = "0.00"
			Me.txtIGST.Text = "0.00"
			Me.txtCESS.Text = "0.00"
			Me.txtGrandTotal.Text = ""
			Me.txtPONo.Text = ""
			Me.txtTermsAndConditions.Text = ""
			Me.cmbTaxType.SelectedIndex = -1
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.DataGridView1.Enabled = True
			Me.btnAdd.Enabled = True
			Me.pnlCalc.Enabled = True
			Me.lblBalance.Text = "0.00"
			Me.DataGridView1.Rows.Clear()
			Me.btnSelection.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.lblUnit.Text = "Unit"
			Me.GetPurchaseTaxType()
			Me.cmbTaxType.Enabled = False
			Me.cmbTerms.SelectedIndex = 0
			Me.btnPrint.Enabled = False
			Me.Clear()
			Me.auto()
			Me.dtpPODate.Focus()
			Me.cmbNP.SelectedIndex = -1
			Me.customerdetailenable()
			Me.NumericUpDown1.Value = Conversions.ToDecimal("30")
		End Sub

		' Token: 0x06008B37 RID: 35639 RVA: 0x00660D3C File Offset: 0x0065EF3C
		Private Sub btnAdd_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbTaxType.Text)) = 0
			If flag Then
				MessageBox.Show("Please configure Tax Type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Try
					Dim flag2 As Boolean = Operators.CompareString(Me.txtProductName.Text, "", False) = 0
					If flag2 Then
						MessageBox.Show("Please retrieve product info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtProductName.Focus()
					Else
						Dim flag3 As Boolean = Operators.CompareString(Me.txtQty.Text, "", False) = 0
						If flag3 Then
							MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtQty.Focus()
						Else
							Dim flag4 As Boolean = Conversions.ToDouble(Me.txtQty.Text) = 0.0
							If flag4 Then
								MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtQty.Focus()
							Else
								Dim flag5 As Boolean = Operators.CompareString(Me.txtPricePerQty.Text, "", False) = 0
								If flag5 Then
									MessageBox.Show("Please enter price per qty.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtPricePerQty.Focus()
								Else
									Try
										For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
											Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
											Dim flag6 As Boolean = Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dataGridViewRow.Cells(0).Value, Conversion.Val(Me.txtProductID.Text), False), Operators.CompareObjectEqual(dataGridViewRow.Cells(20).Value, Me.txtBarcode.Text, False)))
											If flag6 Then
												MessageBox.Show("Same Product already added to grid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
												Me.Clear()
												Return
											End If
										Next
									Finally
										Dim enumerator As IEnumerator
										If TypeOf enumerator Is IDisposable Then
											TryCast(enumerator, IDisposable).Dispose()
										End If
									End Try
									Me.DataGridView1.Rows.Add(New Object() { Me.txtProductID.Text, Me.txtHSNCode.Text, Me.txtProductName.Text, Conversion.Val(Me.txtQty.Text), Conversion.Val(Me.txtPricePerQty.Text), Conversion.Val(Me.txtDiscPer.Text), Conversion.Val(Me.txtDisc.Text), Conversion.Val(Me.txtCGSTPer.Text), Conversion.Val(Me.txtCGSTAmt.Text), Conversion.Val(Me.txtSGSTPer.Text), Conversion.Val(Me.txtSGSTAmt.Text), Conversion.Val(Me.txtIGSTPer.Text), Conversion.Val(Me.txtIGSTAmt.Text), Conversion.Val(Me.txtCESSPer.Text), Conversion.Val(Me.txtCESSAmt.Text), Conversion.Val(Me.txtTotalAmount.Text), Me.txtTaxType.Text, Conversion.Val(Me.txtTaxableAmt.Text), Me.TextBox7.Text, Me.TextBox8.Text, Me.txtBarcode.Text })
									Dim num As Double = Me.SubTotal()
									num = Math.Round(num, 2)
									Me.txtSubTotal.Text = Conversions.ToString(num)
									Me.Compute()
									Me.Clear()
									Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(2)
									Me.Button1.Focus()
								End If
							End If
						End If
					End If
				Catch ex As Exception
					Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
				End Try
			End If
		End Sub

		' Token: 0x06008B38 RID: 35640 RVA: 0x00661208 File Offset: 0x0065F408
		Public Function SubTotal() As Double
			Dim num As Double = 0.0
			Try
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(17).Value))
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Return num
		End Function

		' Token: 0x06008B39 RID: 35641 RVA: 0x006612C8 File Offset: 0x0065F4C8
		Public Sub Clear()
			Me.txtHSNCode.Text = ""
			Me.txtProductName.Text = ""
			Me.txtBarcode.Text = ""
			Me.txtQty.Text = Conversions.ToString(1)
			Me.txtPricePerQty.Text = ""
			Me.txtDiscPer.Text = "0.00"
			Me.txtDisc.Text = "0.00"
			Me.txtCESSPer.Text = "0.00"
			Me.txtCESSAmt.Text = "0.00"
			Me.txtCESSAmt.Text = "0.00"
			Me.txtCGSTPer.Text = "0.00"
			Me.txtCGSTAmt.Text = "0.00"
			Me.txtSGSTPer.Text = "0.00"
			Me.txtSGSTAmt.Text = "0.00"
			Me.txtIGSTPer.Text = "0.00"
			Me.txtIGSTAmt.Text = "0.00"
			Me.txtTotalAmount.Text = "0.00"
			Me.lblQty_S.Visible = False
			Me.lblUnit.Text = "Unit"
			Me.txtProductID.Text = ""
			Me.cmbDiscountType.SelectedIndex = 0
			Me.txtDisc.Enabled = False
			Me.txtTotalAmount.Text = "0.00"
			Me.txtTaxType.Text = ""
			Me.txtTaxableAmt.Text = "0.00"
			Me.txtProductName.Focus()
		End Sub

		' Token: 0x06008B3A RID: 35642 RVA: 0x00661480 File Offset: 0x0065F680
		Private Sub btnRemove_Click(sender As Object, e As EventArgs)
			Try
				Try
					For Each obj As Object In Me.DataGridView1.SelectedRows
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Me.DataGridView1.Rows.Remove(dataGridViewRow)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim num As Double = Me.SubTotal()
				num = Math.Round(num, 2)
				Me.txtSubTotal.Text = Conversions.ToString(num)
				Me.Compute()
				Me.Clear()
				Me.DataGridView1.ClearSelection()
				Me.btnRemove.Enabled = False
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Dim flag As Boolean = Me.DataGridView1.RowCount = 0
			If flag Then
				Me.customerdetailenable()
			End If
		End Sub

		' Token: 0x06008B3B RID: 35643 RVA: 0x00661598 File Offset: 0x0065F798
		Public Sub Compute()
			Me.GridCalc()
			Me.num1 = Conversion.Val(Me.txtSubTotal.Text) + Conversion.Val(Me.txtCGST.Text) + Conversion.Val(Me.txtSGST.Text) + Conversion.Val(Me.txtIGST.Text) + Conversion.Val(Me.txtCESS.Text)
			Me.num1 = Math.Round(Me.num1, 2)
			Me.txtGrandTotal.Text = Conversions.ToString(Me.num1)
		End Sub

		' Token: 0x06008B3C RID: 35644 RVA: 0x00661630 File Offset: 0x0065F830
		Public Sub GridCalc()
			Dim num As Double = 0.0
			Dim num2 As Double = 0.0
			Dim num3 As Double = 0.0
			Dim num4 As Double = 0.0
			Try
				For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					num = Conversions.ToDouble(Operators.AddObject(num, dataGridViewRow.Cells(8).Value))
					num2 = Conversions.ToDouble(Operators.AddObject(num2, dataGridViewRow.Cells(10).Value))
					num3 = Conversions.ToDouble(Operators.AddObject(num3, dataGridViewRow.Cells(12).Value))
					num4 = Conversions.ToDouble(Operators.AddObject(num4, dataGridViewRow.Cells(14).Value))
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			num = Math.Round(num, 2)
			num2 = Math.Round(num2, 2)
			num3 = Math.Round(num3, 2)
			num4 = Math.Round(num4, 2)
			Me.txtCGST.Text = Conversions.ToString(num)
			Me.txtSGST.Text = Conversions.ToString(num2)
			Me.txtIGST.Text = Conversions.ToString(num3)
			Me.txtCESS.Text = Conversions.ToString(num4)
		End Sub

		' Token: 0x06008B3D RID: 35645 RVA: 0x006617BC File Offset: 0x0065F9BC
		Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
			If flag Then
				Me.btnRemove.Enabled = True
			End If
		End Sub

		' Token: 0x06008B3E RID: 35646 RVA: 0x006617F0 File Offset: 0x0065F9F0
		Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.DataGridView1.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.DataGridView1.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x06008B3F RID: 35647 RVA: 0x006618D8 File Offset: 0x0065FAD8
		Private Sub frmStock_Load(sender As Object, e As EventArgs)
			Me.GetCompanyState()
			Me.DataforNP()
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.Invoicecode()
			Me.auto()
			Me.GetPurchaseTaxType()
			Me.fillSupplierName()
			Me.fillPOrderID()
			Me.CipherCode()
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06008B40 RID: 35648 RVA: 0x006619A0 File Offset: 0x0065FBA0
		Public Sub Convert_Language()
			Dim text As String = "SELECT default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin= '" + GlobalVariables.LoggedInLang_code + "'"
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
						Dim dataTable As DataTable = New DataTable()
						sqlDataAdapter.Fill(dataTable)
						GlobalVariables.translations.Clear()
						Try
							For Each obj As Object In dataTable.Rows
								Dim dataRow As DataRow = CType(obj, DataRow)
								Dim text2 As String = dataRow("default_lang_eng").ToString()
								Dim text3 As String = dataRow("other_lang").ToString()
								Dim flag As Boolean = Not GlobalVariables.translations.ContainsKey(text2)
								If flag Then
									GlobalVariables.translations.Add(text2, text3)
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						Me.UpdateAllControls(Me, GlobalVariables.translations)
						Try
							For Each obj2 As Object In MyBase.Controls
								Dim control As Control = CType(obj2, Control)
								Dim flag2 As Boolean = TypeOf control Is DataGridView
								If flag2 Then
									Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
								End If
								Try
									For Each obj3 As Object In control.Controls
										Dim control2 As Control = CType(obj3, Control)
										Dim flag3 As Boolean = TypeOf control2 Is DataGridView
										If flag3 Then
											Me.UpdateDataGridViewHeaders(CType(control2, DataGridView))
										End If
									Next
								Finally
									Dim enumerator3 As IEnumerator
									If TypeOf enumerator3 Is IDisposable Then
										TryCast(enumerator3, IDisposable).Dispose()
									End If
								End Try
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x06008B41 RID: 35649 RVA: 0x00661C40 File Offset: 0x0065FE40
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim visible As Boolean = ctrl.Visible
			If visible Then
				Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
				If flag Then
					Dim text As String = ctrl.Text
					Dim flag2 As Boolean = translations.ContainsKey(text)
					If flag2 Then
						ctrl.Text = translations(text)
					End If
				End If
			End If
			Try
				For Each obj As Object In ctrl.Controls
					Dim control As Control = CType(obj, Control)
					Me.UpdateAllControls(control, translations)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06008B42 RID: 35650 RVA: 0x00087088 File Offset: 0x00085288
		Private Sub UpdateDataGridViewHeaders(dgv As DataGridView)
			Try
				For Each obj As Object In dgv.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim headerText As String = dataGridViewColumn.HeaderText
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(headerText)
					If flag Then
						dataGridViewColumn.HeaderText = GlobalVariables.translations(headerText)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06008B43 RID: 35651 RVA: 0x00661D0C File Offset: 0x0065FF0C
		Public Sub GetCompanyState()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo),State,CompanyName from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.DTP1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.DTP2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.F1.Text = ModCommonClasses.rdr.GetValue(0).ToString().Substring(7, 4)
					Me.F2.Text = ModCommonClasses.rdr.GetValue(1).ToString().Substring(9, 2)
					Me.txtCompanyState.Text = Strings.RTrim(ModCommonClasses.rdr.GetValue(2).ToString())
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008B44 RID: 35652 RVA: 0x00044076 File Offset: 0x00042276
		Private Sub txtPricePerQty_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x06008B45 RID: 35653 RVA: 0x00661E90 File Offset: 0x00660090
		Public Sub Calc()
			Dim flag As Boolean = Operators.CompareString(Me.txtTaxType.Text, "Exclusive", False) = 0
			If flag Then
				Dim flag2 As Boolean = (Me.cmbDiscountType.SelectedIndex = 0) And (Operators.CompareString(Me.txtProductName.Text, "", False) <> 0)
				If flag2 Then
					Me.num1 = Conversion.Val(Me.txtQty.Text) * Conversion.Val(Me.txtPricePerQty.Text)
					Me.num1 = Math.Round(Me.num1, 2)
					Me.num7 = Conversion.Val(Me.num1 * Conversion.Val(Me.txtDiscPer.Text) / 100.0)
					Me.num7 = Math.Round(Me.num7, 2)
					Me.txtDisc.Text = Conversions.ToString(Me.num7)
				Else
					Dim flag3 As Boolean = (Me.cmbDiscountType.SelectedIndex = 1) And (Operators.CompareString(Me.txtProductName.Text, "", False) <> 0)
					If flag3 Then
						Me.num1 = Conversion.Val(Me.txtQty.Text) * Conversion.Val(Me.txtPricePerQty.Text)
						Me.num1 = Math.Round(Me.num1, 2)
						Me.num7 = Conversion.Val(Me.txtDisc.Text) * 100.0 / Conversion.Val(Me.num1)
						Me.num7 = Math.Round(Me.num7, 4)
						Me.txtDiscPer.Text = Conversions.ToString(Me.num7)
					End If
				End If
				Me.num8 = Me.num1 - Conversion.Val(Me.txtDisc.Text)
				Me.num2 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCGSTPer.Text) / 100.0)
				Me.num2 = Math.Round(Me.num2, 2)
				Me.txtCGSTAmt.Text = Strings.Format(Math.Round(Me.num2, 2), "0.00")
				Me.num3 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtSGSTPer.Text) / 100.0)
				Me.num3 = Math.Round(Me.num3, 2)
				Me.txtSGSTAmt.Text = Strings.Format(Math.Round(Me.num3, 2), "0.00")
				Me.num4 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtIGSTPer.Text) / 100.0)
				Me.num4 = Math.Round(Me.num4, 2)
				Me.txtIGSTAmt.Text = Strings.Format(Math.Round(Me.num4, 2), "0.00")
				Me.num5 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCESSPer.Text) / 100.0)
				Me.num5 = Math.Round(Me.num5, 2)
				Me.txtCESSAmt.Text = Strings.Format(Math.Round(Me.num5, 2), "0.00")
				Me.num6 = Me.num8 + Me.num2 + Me.num3 + Me.num4 + Me.num5
				Me.num6 = Math.Round(Me.num6, 2)
				Me.txtTotalAmount.Text = Conversions.ToString(Me.num6)
			End If
			Dim flag4 As Boolean = Operators.CompareString(Me.txtTaxType.Text, "Inclusive", False) = 0
			If flag4 Then
				Me.num1 = Conversion.Val(Me.txtQty.Text) * Conversion.Val(Me.txtPricePerQty.Text)
				Me.num1 = Math.Round(Me.num1, 2)
				Dim flag5 As Boolean = (Me.cmbDiscountType.SelectedIndex = 0) And (Operators.CompareString(Me.txtProductName.Text, "", False) <> 0)
				If flag5 Then
					Me.num7 = Conversion.Val(Me.num1 * Conversion.Val(Me.txtDiscPer.Text) / 100.0)
					Me.num7 = Math.Round(Me.num7, 2)
					Me.txtDisc.Text = Conversions.ToString(Me.num7)
				Else
					Dim flag6 As Boolean = (Me.cmbDiscountType.SelectedIndex = 1) And (Operators.CompareString(Me.txtProductName.Text, "", False) <> 0)
					If flag6 Then
						Me.num7 = Conversion.Val(Conversion.Val(Me.txtDisc.Text) * 100.0 / Me.num1)
						Me.num7 = Math.Round(Me.num7, 4)
						Me.txtDiscPer.Text = Conversions.ToString(Me.num7)
					End If
				End If
				Me.num8 = Me.num1 - Conversion.Val(Me.txtDisc.Text)
				Me.num2 = Me.num8 - Conversion.Val(Me.num8 / (1.0 + (Conversion.Val(Me.txtCGSTPer.Text) + Conversion.Val(Me.txtSGSTPer.Text)) / 100.0))
				Me.num2 = Math.Round(Me.num2, 2)
				Me.txtCGSTAmt.Text = Strings.Format(Math.Round(Me.num2 / 2.0, 2), "0.00")
				Me.num3 = Me.num8 - Conversion.Val(Me.num8 / (1.0 + (Conversion.Val(Me.txtCGSTPer.Text) + Conversion.Val(Me.txtSGSTPer.Text)) / 100.0))
				Me.num3 = Math.Round(Me.num3, 2)
				Me.txtSGSTAmt.Text = Strings.Format(Math.Round(Me.num3 / 2.0, 2), "0.00")
				Me.num4 = Me.num8 - Conversion.Val(Me.num8 / (1.0 + Conversion.Val(Me.txtIGSTPer.Text) / 100.0))
				Me.num4 = Math.Round(Me.num4, 2)
				Me.txtIGSTAmt.Text = Strings.Format(Math.Round(Me.num4, 2), "0.00")
				Me.num5 = Me.num8 - Conversion.Val(Me.num8 / (1.0 + Conversion.Val(Me.txtCESSPer.Text) / 100.0))
				Me.num5 = Math.Round(Me.num5, 2)
				Me.txtCESSAmt.Text = Strings.Format(Math.Round(Me.num5, 2), "0.00")
				Me.num6 = Me.num8
				Me.num6 = Math.Round(Me.num6, 2)
				Me.txtTotalAmount.Text = Conversions.ToString(Me.num6)
			End If
			Dim flag7 As Boolean = Operators.CompareString(Me.txtTaxType.Text, "Exempt GST", False) = 0
			If flag7 Then
				Dim flag8 As Boolean = (Me.cmbDiscountType.SelectedIndex = 0) And (Operators.CompareString(Me.txtProductName.Text, "", False) <> 0)
				If flag8 Then
					Me.num1 = Conversion.Val(Me.txtQty.Text) * Conversion.Val(Me.txtPricePerQty.Text)
					Me.num1 = Math.Round(Me.num1, 2)
					Me.num7 = Conversion.Val(Me.num1 * Conversion.Val(Me.txtDiscPer.Text) / 100.0)
					Me.num7 = Math.Round(Me.num7, 2)
					Me.txtDisc.Text = Conversions.ToString(Me.num7)
				Else
					Dim flag9 As Boolean = (Me.cmbDiscountType.SelectedIndex = 1) And (Operators.CompareString(Me.txtProductName.Text, "", False) <> 0)
					If flag9 Then
						Me.num1 = Conversion.Val(Me.txtQty.Text) * Conversion.Val(Me.txtPricePerQty.Text)
						Me.num1 = Math.Round(Me.num1, 2)
						Me.num7 = Conversion.Val(Me.txtDisc.Text) * 100.0 / Conversion.Val(Me.num1)
						Me.num7 = Math.Round(Me.num7, 4)
						Me.txtDiscPer.Text = Conversions.ToString(Me.num7)
					End If
				End If
				Me.txtCGSTPer.Text = "0.00"
				Me.txtSGSTPer.Text = "0.00"
				Me.txtIGSTPer.Text = "0.00"
				Me.num8 = Me.num1 - Conversion.Val(Me.txtDisc.Text)
				Me.num2 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCGSTPer.Text) / 100.0)
				Me.num2 = Math.Round(Me.num2, 2)
				Me.txtCGSTAmt.Text = Strings.Format(Math.Round(Me.num2, 2), "0.00")
				Me.num3 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtSGSTPer.Text) / 100.0)
				Me.num3 = Math.Round(Me.num3, 2)
				Me.txtSGSTAmt.Text = Strings.Format(Math.Round(Me.num3, 2), "0.00")
				Me.num4 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtIGSTPer.Text) / 100.0)
				Me.num4 = Math.Round(Me.num4, 2)
				Me.txtIGSTAmt.Text = Strings.Format(Math.Round(Me.num4, 2), "0.00")
				Me.num5 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCESSPer.Text) / 100.0)
				Me.num5 = Math.Round(Me.num5, 2)
				Me.txtCESSAmt.Text = Strings.Format(Math.Round(Me.num5, 2), "0.00")
				Me.num6 = Me.num8 + Me.num2 + Me.num3 + Me.num4 + Me.num5
				Me.num6 = Math.Round(Me.num6, 2)
				Me.txtTotalAmount.Text = Conversions.ToString(Me.num6)
			End If
			Dim flag10 As Boolean = Operators.CompareString(Me.txtTaxType.Text, "No Taxes", False) = 0
			If flag10 Then
				Dim flag11 As Boolean = (Me.cmbDiscountType.SelectedIndex = 0) And (Operators.CompareString(Me.txtProductName.Text, "", False) <> 0)
				If flag11 Then
					Me.num1 = Conversion.Val(Me.txtQty.Text) * Conversion.Val(Me.txtPricePerQty.Text)
					Me.num1 = Math.Round(Me.num1, 2)
					Me.num7 = Conversion.Val(Me.num1 * Conversion.Val(Me.txtDiscPer.Text) / 100.0)
					Me.num7 = Math.Round(Me.num7, 2)
					Me.txtDisc.Text = Conversions.ToString(Me.num7)
				Else
					Dim flag12 As Boolean = (Me.cmbDiscountType.SelectedIndex = 1) And (Operators.CompareString(Me.txtProductName.Text, "", False) <> 0)
					If flag12 Then
						Me.num1 = Conversion.Val(Me.txtQty.Text) * Conversion.Val(Me.txtPricePerQty.Text)
						Me.num1 = Math.Round(Me.num1, 2)
						Me.num7 = Conversion.Val(Me.txtDisc.Text) * 100.0 / Conversion.Val(Me.num1)
						Me.num7 = Math.Round(Me.num7, 4)
						Me.txtDiscPer.Text = Conversions.ToString(Me.num7)
					End If
				End If
				Me.txtCGSTPer.Text = "0.00"
				Me.txtSGSTPer.Text = "0.00"
				Me.txtIGSTPer.Text = "0.00"
				Me.txtCESSPer.Text = "0.00"
				Me.num8 = Me.num1 - Conversion.Val(Me.txtDisc.Text)
				Me.num2 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCGSTPer.Text) / 100.0)
				Me.num2 = Math.Round(Me.num2, 2)
				Me.txtCGSTAmt.Text = Strings.Format(Math.Round(Me.num2, 2), "0.00")
				Me.num3 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtSGSTPer.Text) / 100.0)
				Me.num3 = Math.Round(Me.num3, 2)
				Me.txtSGSTAmt.Text = Strings.Format(Math.Round(Me.num3, 2), "0.00")
				Me.num4 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtIGSTPer.Text) / 100.0)
				Me.num4 = Math.Round(Me.num4, 2)
				Me.txtIGSTAmt.Text = Strings.Format(Math.Round(Me.num4, 2), "0.00")
				Me.num5 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCESSPer.Text) / 100.0)
				Me.num5 = Math.Round(Me.num5, 2)
				Me.txtCESSAmt.Text = Strings.Format(Math.Round(Me.num5, 2), "0.00")
				Me.num6 = Me.num8 + Me.num2 + Me.num3 + Me.num4 + Me.num5
				Me.num6 = Math.Round(Me.num6, 2)
				Me.txtTotalAmount.Text = Conversions.ToString(Me.num6)
			End If
			Me.num11 = Conversion.Val(Me.txtQty.Text) * Conversion.Val(Me.txtPricePerQty.Text)
			Dim flag13 As Boolean = Operators.CompareString(Me.txtTaxType.Text, "Inclusive", False) = 0
			Dim num As Double
			If flag13 Then
				num = Me.num11 - Conversion.Val(Me.txtDisc.Text) - (Conversion.Val(Me.txtCGSTAmt.Text) + Conversion.Val(Me.txtSGSTAmt.Text) + Conversion.Val(Me.txtIGSTAmt.Text) + Conversion.Val(Me.txtCESSAmt.Text))
			Else
				num = Me.num11 - Conversion.Val(Me.txtDisc.Text)
			End If
			Me.txtTaxableAmt.Text = Strings.Format(Math.Round(num, 2), "0.00")
		End Sub

		' Token: 0x06008B46 RID: 35654 RVA: 0x00044076 File Offset: 0x00042276
		Private Sub txtQty_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x06008B47 RID: 35655 RVA: 0x00662F40 File Offset: 0x00661140
		Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtQty.Text
					Dim selectionStart As Integer = Me.txtQty.SelectionStart
					Dim selectionLength As Integer = Me.txtQty.SelectionLength
					text = text.Substring(0, selectionStart) + Conversions.ToString(keyChar) + text.Substring(selectionStart + selectionLength)
					Dim text2 As String = text
					Dim num As Integer = 0
					Dim flag3 As Boolean = Integer.TryParse(text2, num) AndAlso text.Length > 16
					If flag3 Then
						e.Handled = True
					Else
						Dim text3 As String = text
						Dim num2 As Double = 0.0
						Dim flag4 As Boolean = Double.TryParse(text3, num2) AndAlso text.IndexOf("."c) < text.Length - 3
						If flag4 Then
							e.Handled = False
						End If
					End If
				Else
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x06008B48 RID: 35656 RVA: 0x00663038 File Offset: 0x00661238
		Private Sub txtPricePerQty_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtPricePerQty.Text
					Dim selectionStart As Integer = Me.txtPricePerQty.SelectionStart
					Dim selectionLength As Integer = Me.txtPricePerQty.SelectionLength
					text = text.Substring(0, selectionStart) + Conversions.ToString(keyChar) + text.Substring(selectionStart + selectionLength)
					Dim text2 As String = text
					Dim num As Integer = 0
					Dim flag3 As Boolean = Integer.TryParse(text2, num) AndAlso text.Length > 16
					If flag3 Then
						e.Handled = True
					Else
						Dim text3 As String = text
						Dim num2 As Double = 0.0
						Dim flag4 As Boolean = Double.TryParse(text3, num2) AndAlso text.IndexOf("."c) < text.Length - 3
						If flag4 Then
							e.Handled = False
						End If
					End If
				Else
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x06008B49 RID: 35657 RVA: 0x00044080 File Offset: 0x00042280
		Private Sub txtTotalPayment_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x06008B4A RID: 35658 RVA: 0x00663130 File Offset: 0x00661330
		Public Sub fillSupplierName()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Name) FROM Supplier", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbSupplierName.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbSupplierName.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008B4B RID: 35659 RVA: 0x00663264 File Offset: 0x00661464
		Public Sub GetSupplierBalance()
			Try
				Me.num1 = 0.0
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from SupplierLedgerBook where PartyID=@d1 group By PartyID"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSupplierID.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.num1 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
				End If
				ModCommonClasses.con.Close()
				Me.lblBalance.Text = Conversions.ToString(Me.num1)
				Me.lblBalance.ForeColor = Color.DarkGreen
				Dim flag2 As Boolean = Conversion.Val(Me.lblBalance.Text) >= 0.0
				If flag2 Then
					Me.str = "Cr"
					Me.lblBalance.ForeColor = Color.Red
				Else
					Dim flag3 As Boolean = Conversion.Val(Conversions.ToDouble(Me.lblBalance.Text) < 0.0) <> 0.0
					If flag3 Then
						Me.str = "Dr"
						Me.lblBalance.ForeColor = Color.Blue
					End If
				End If
				Me.lblBalance.Text = Conversions.ToString(Math.Abs(Conversion.Val(Me.lblBalance.Text)))
				Me.lblBalance.Text = (Me.lblBalance.Text + " " + Me.str).ToString()
				Me.Compute()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008B4C RID: 35660 RVA: 0x00663470 File Offset: 0x00661670
		Public Sub GetSupplierInfo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT SupplierID,Name,Address,State,ContactNo from Supplier Where ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtSup_ID.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtSupplierID.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.cmbSupplierName.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.txtAddress.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					Me.txtState.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(3))
					Me.txtContactNo.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(4))
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008B4D RID: 35661 RVA: 0x006635D8 File Offset: 0x006617D8
		Public Sub GetSupplierBalance1()
			Try
				Try
					Me.num1 = 0.0
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from SupplierLedgerBook where PartyID=@d1 group By PartyID"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSupplierID.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Dim flag As Boolean = ModCommonClasses.rdr.Read()
					If flag Then
						Me.num1 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
					End If
					ModCommonClasses.con.Close()
					Me.lblBalance.Text = Conversions.ToString(Me.num1)
					Dim flag2 As Boolean = Conversion.Val(Me.lblBalance.Text) >= 0.0
					If flag2 Then
						Me.str = "CR"
					Else
						Dim flag3 As Boolean = Conversion.Val(Conversions.ToDouble(Me.lblBalance.Text) < 0.0) <> 0.0
						If flag3 Then
							Me.str = "DR"
						End If
					End If
					Me.lblBalance.Text = Conversions.ToString(Math.Abs(Conversion.Val(Me.lblBalance.Text)))
					Me.lblBalance.Text = (Me.lblBalance.Text + " " + Me.str).ToString()
					Me.Compute()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008B4E RID: 35662 RVA: 0x006637F0 File Offset: 0x006619F0
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from PurchaseOrder where PO_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtPO_ID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					ModFunc.SrPurOrderDelete(Me.txtPONo.Text)
					ModFunc.LogFunc(Me.lblUser.Text, "deleted the purchase order having PO No. '" + Me.txtPONo.Text + "'")
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillPOrderID()
					Me.Reset()
				Else
					MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillPOrderID()
					Me.Reset()
				End If
				Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.DataforNP()
		End Sub

		' Token: 0x06008B4F RID: 35663 RVA: 0x00663968 File Offset: 0x00661B68
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplierRecord.lblSet.Text = "PO"
			MyProject.Forms.frmSupplierRecord.Label5.Text = Me.lblUser.Text
			MyProject.Forms.frmSupplierRecord.Reset()
			MyProject.Forms.frmSupplierRecord.ShowDialog()
			MyProject.Forms.frmSupplierRecord.Dispose()
		End Sub

		' Token: 0x06008B50 RID: 35664 RVA: 0x00044076 File Offset: 0x00042276
		Private Sub txtDiscPer_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x06008B51 RID: 35665 RVA: 0x00044080 File Offset: 0x00042280
		Private Sub txtSubTotal_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x06008B52 RID: 35666 RVA: 0x00044080 File Offset: 0x00042280
		Private Sub txtFreightCharges_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x06008B53 RID: 35667 RVA: 0x00044080 File Offset: 0x00042280
		Private Sub txtOtherCharges_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x06008B54 RID: 35668 RVA: 0x00044080 File Offset: 0x00042280
		Private Sub txtPreviousDue_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x06008B55 RID: 35669 RVA: 0x00044080 File Offset: 0x00042280
		Private Sub txtRoundOff_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x06008B56 RID: 35670 RVA: 0x00044080 File Offset: 0x00042280
		Private Sub txtTotalPaid_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x06008B57 RID: 35671 RVA: 0x00044080 File Offset: 0x00042280
		Private Sub txtVATPer_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x06008B58 RID: 35672 RVA: 0x006639E0 File Offset: 0x00661BE0
		Private Sub txtCGSTPer_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtCGSTPer.Text
					Dim selectionStart As Integer = Me.txtCGSTPer.SelectionStart
					Dim selectionLength As Integer = Me.txtCGSTPer.SelectionLength
					text = text.Substring(0, selectionStart) + Conversions.ToString(keyChar) + text.Substring(selectionStart + selectionLength)
					Dim text2 As String = text
					Dim num As Integer = 0
					Dim flag3 As Boolean = Integer.TryParse(text2, num) AndAlso text.Length > 16
					If flag3 Then
						e.Handled = True
					Else
						Dim text3 As String = text
						Dim num2 As Double = 0.0
						Dim flag4 As Boolean = Double.TryParse(text3, num2) AndAlso text.IndexOf("."c) < text.Length - 3
						If flag4 Then
							e.Handled = False
						End If
					End If
				Else
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x06008B59 RID: 35673 RVA: 0x00663AD8 File Offset: 0x00661CD8
		Private Sub txtSGSTPer_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtSGSTPer.Text
					Dim selectionStart As Integer = Me.txtSGSTPer.SelectionStart
					Dim selectionLength As Integer = Me.txtSGSTPer.SelectionLength
					text = text.Substring(0, selectionStart) + Conversions.ToString(keyChar) + text.Substring(selectionStart + selectionLength)
					Dim text2 As String = text
					Dim num As Integer = 0
					Dim flag3 As Boolean = Integer.TryParse(text2, num) AndAlso text.Length > 16
					If flag3 Then
						e.Handled = True
					Else
						Dim text3 As String = text
						Dim num2 As Double = 0.0
						Dim flag4 As Boolean = Double.TryParse(text3, num2) AndAlso text.IndexOf("."c) < text.Length - 3
						If flag4 Then
							e.Handled = False
						End If
					End If
				Else
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x06008B5A RID: 35674 RVA: 0x00663BD0 File Offset: 0x00661DD0
		Private Sub txtIGSTPer_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtIGSTPer.Text
					Dim selectionStart As Integer = Me.txtIGSTPer.SelectionStart
					Dim selectionLength As Integer = Me.txtIGSTPer.SelectionLength
					text = text.Substring(0, selectionStart) + Conversions.ToString(keyChar) + text.Substring(selectionStart + selectionLength)
					Dim text2 As String = text
					Dim num As Integer = 0
					Dim flag3 As Boolean = Integer.TryParse(text2, num) AndAlso text.Length > 16
					If flag3 Then
						e.Handled = True
					Else
						Dim text3 As String = text
						Dim num2 As Double = 0.0
						Dim flag4 As Boolean = Double.TryParse(text3, num2) AndAlso text.IndexOf("."c) < text.Length - 3
						If flag4 Then
							e.Handled = False
						End If
					End If
				Else
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x06008B5B RID: 35675 RVA: 0x00663CC8 File Offset: 0x00661EC8
		Private Sub txtCESSPer_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtCESSPer.Text
					Dim selectionStart As Integer = Me.txtCESSPer.SelectionStart
					Dim selectionLength As Integer = Me.txtCESSPer.SelectionLength
					text = text.Substring(0, selectionStart) + Conversions.ToString(keyChar) + text.Substring(selectionStart + selectionLength)
					Dim text2 As String = text
					Dim num As Integer = 0
					Dim flag3 As Boolean = Integer.TryParse(text2, num) AndAlso text.Length > 16
					If flag3 Then
						e.Handled = True
					Else
						Dim text3 As String = text
						Dim num2 As Double = 0.0
						Dim flag4 As Boolean = Double.TryParse(text3, num2) AndAlso text.IndexOf("."c) < text.Length - 3
						If flag4 Then
							e.Handled = False
						End If
					End If
				Else
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x06008B5C RID: 35676 RVA: 0x0004408A File Offset: 0x0004228A
		Private Sub cmbTaxType_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.Calc()
			Me.Compute()
			Me.cmbTaxType.Enabled = False
		End Sub

		' Token: 0x06008B5D RID: 35677 RVA: 0x00044076 File Offset: 0x00042276
		Private Sub txtCGSTPer_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x06008B5E RID: 35678 RVA: 0x00044076 File Offset: 0x00042276
		Private Sub txtSGSTPer_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x06008B5F RID: 35679 RVA: 0x00044076 File Offset: 0x00042276
		Private Sub txtIGSTPer_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x06008B60 RID: 35680 RVA: 0x00044076 File Offset: 0x00042276
		Private Sub txtCESSPer_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x06008B61 RID: 35681 RVA: 0x000440A8 File Offset: 0x000422A8
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06008B62 RID: 35682 RVA: 0x00044076 File Offset: 0x00042276
		Private Sub txtDisc_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x06008B63 RID: 35683 RVA: 0x00663DC0 File Offset: 0x00661FC0
		Private Sub cmbDiscountType_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbDiscountType.SelectedIndex = 0
			If flag Then
				Me.txtDisc.Enabled = False
				Me.txtDiscPer.Enabled = True
			Else
				Dim flag2 As Boolean = Me.cmbDiscountType.SelectedIndex = 1
				If flag2 Then
					Me.txtDiscPer.Enabled = False
					Me.txtDisc.Enabled = True
				End If
			End If
			Me.Calc()
		End Sub

		' Token: 0x06008B64 RID: 35684 RVA: 0x00663E34 File Offset: 0x00662034
		Private Sub txtDiscPer_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtDiscPer.Text
					Dim selectionStart As Integer = Me.txtDiscPer.SelectionStart
					Dim selectionLength As Integer = Me.txtDiscPer.SelectionLength
					text = text.Substring(0, selectionStart) + Conversions.ToString(keyChar) + text.Substring(selectionStart + selectionLength)
					Dim text2 As String = text
					Dim num As Integer = 0
					Dim flag3 As Boolean = Integer.TryParse(text2, num) AndAlso text.Length > 16
					If flag3 Then
						e.Handled = True
					Else
						Dim text3 As String = text
						Dim num2 As Double = 0.0
						Dim flag4 As Boolean = Double.TryParse(text3, num2) AndAlso text.IndexOf("."c) < text.Length - 3
						If flag4 Then
							e.Handled = False
						End If
					End If
				Else
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x06008B65 RID: 35685 RVA: 0x00663F2C File Offset: 0x0066212C
		Private Sub txtDisc_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtDisc.Text
					Dim selectionStart As Integer = Me.txtDisc.SelectionStart
					Dim selectionLength As Integer = Me.txtDisc.SelectionLength
					text = text.Substring(0, selectionStart) + Conversions.ToString(keyChar) + text.Substring(selectionStart + selectionLength)
					Dim text2 As String = text
					Dim num As Integer = 0
					Dim flag3 As Boolean = Integer.TryParse(text2, num) AndAlso text.Length > 16
					If flag3 Then
						e.Handled = True
					Else
						Dim text3 As String = text
						Dim num2 As Double = 0.0
						Dim flag4 As Boolean = Double.TryParse(text3, num2) AndAlso text.IndexOf("."c) < text.Length - 3
						If flag4 Then
							e.Handled = False
						End If
					End If
				Else
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x06008B66 RID: 35686 RVA: 0x00664024 File Offset: 0x00662224
		Private Sub dtpPODate_LostFocus(sender As Object, e As EventArgs)
			Dim flag As Boolean = DateTime.Compare(Me.dtpPODate.Value, Me.DTP1.Value) < 0
			If flag Then
				Me.dtpPODate.Value = DateAndTime.Today
				MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				MyBase.Close()
			Else
				Dim flag2 As Boolean = DateTime.Compare(Me.dtpPODate.Value, Me.DTP2.Value) > 0
				If flag2 Then
					Me.dtpPODate.Value = DateAndTime.Today
					MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06008B67 RID: 35687 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpPODate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008B68 RID: 35688 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbTerms_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008B69 RID: 35689 RVA: 0x006640D0 File Offset: 0x006622D0
		Private Sub cmbSupplierName_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtSup_ID.Text = ""
				Me.txtSupplierID.Text = ""
				Me.txtAddress.Text = ""
				Me.txtState.Text = ""
				Me.txtContactNo.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT ID, RTRIM(SupplierID),RTRIM(Address),RTRIM(State),RTRIM(ContactNo),RTRIM(GSTIN), RTRIM(Limit), RTRIM(Lstatus) from Supplier where Name=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbSupplierName.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtSup_ID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtSupplierID.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.txtAddress.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.txtState.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.txtContactNo.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.GetSupplierBalance()
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008B6A RID: 35690 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtQty_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008B6B RID: 35691 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtPricePerQty_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008B6C RID: 35692 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbDiscountType_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008B6D RID: 35693 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtDiscPer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008B6E RID: 35694 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtDisc_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008B6F RID: 35695 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCGSTPer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008B70 RID: 35696 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtSGSTPer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008B71 RID: 35697 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtIGSTPer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008B72 RID: 35698 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCESSPer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008B73 RID: 35699 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtTermsAndConditions_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008B74 RID: 35700 RVA: 0x006642BC File Offset: 0x006624BC
		Private Sub cmbSupplierName_Validated(sender As Object, e As EventArgs)
			Dim focused As Boolean = Me.cmbSupplierName.Focused
			If focused Then
				Dim flag As Boolean = Me.cmbSupplierName.SelectedIndex = -1
				If flag Then
					MessageBox.Show("Please select correct supplier name", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.cmbSupplierName.Focus()
				End If
			End If
		End Sub

		' Token: 0x06008B75 RID: 35701 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbSupplierName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008B76 RID: 35702 RVA: 0x00664310 File Offset: 0x00662510
		Public Sub fillPOrderID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(PO_ID) FROM PurchaseOrder order by PO_ID ASC", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbNP.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbNP.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008B77 RID: 35703 RVA: 0x0066444C File Offset: 0x0066264C
		Public Sub NextPrev()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd = New SqlCommand("SELECT PO_ID, RTRIM(PONo), Date,RTRIM(TaxType),RTRIM(Terms),Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name), SubTotal, CGST,SGST,IGST,CESS, GrandTotal, RTRIM(TermsAndConditions) from Supplier,PurchaseOrder where Supplier.ID=PurchaseOrder.SupplierID and PurchaseOrder.PO_ID=@d1", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtPO_ID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtPONo.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.dtpPODate.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.cmbTaxType.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.cmbTerms.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.txtSup_ID.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.txtSupplierID.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.cmbSupplierName.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.txtSubTotal.Text = ModCommonClasses.rdr.GetValue(8).ToString()
					Me.txtCGST.Text = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.txtSGST.Text = ModCommonClasses.rdr.GetValue(10).ToString()
					Me.txtIGST.Text = ModCommonClasses.rdr.GetValue(11).ToString()
					Me.txtCESS.Text = ModCommonClasses.rdr.GetValue(12).ToString()
					Me.txtGrandTotal.Text = ModCommonClasses.rdr.GetValue(13).ToString()
					Me.txtTermsAndConditions.Text = ModCommonClasses.rdr.GetValue(14).ToString()
					Me.btnSave.Enabled = False
					Me.btnUpdate.Enabled = True
					Me.GetSupplierBalance1()
					Me.btnDelete.Enabled = True
					Me.GetSupplierInfo()
					Me.btnSelection.Enabled = False
					Me.cmbTaxType.Enabled = False
					Me.btnPrint.Enabled = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT PID,RTRIM(Product.HSNCode),RTRIM(Productname),Qty, Price,DiscountPer,DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,TotalAmount,RTRIM(PurchaseOrder_Join.PTaxType),PurchaseOrder_Join.TaxableAmt,RTRIM(PurchaseOrder_Join.RCipher),RTRIM(PurchaseOrder_Join.WCipher),RTRIM(PurchaseOrder_Join.Barcode) from Product,PurchaseOrder,PurchaseOrder_Join where product.PID=PurchaseOrder_Join.ProductID and PurchaseOrder.PO_ID=PurchaseOrder_Join.PurchaseOrderID and PurchaseOrder.PO_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20) })
					End While
					ModCommonClasses.con.Close()
					Me.DataGridView1.ClearSelection()
					Me.GridCalc()
					Me.Compute()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06008B78 RID: 35704 RVA: 0x000440C4 File Offset: 0x000422C4
		Private Sub txtNP_KeyDown(sender As Object, e As KeyEventArgs)
			Me.NextPrev()
			Me.NextPrev()
			Me.NextPrev()
		End Sub

		' Token: 0x06008B79 RID: 35705 RVA: 0x00664934 File Offset: 0x00662B34
		Private Sub Button35_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmReminder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmReminder.ShowDialog()
			MyProject.Forms.frmReminder.Dispose()
		End Sub

		' Token: 0x06008B7A RID: 35706 RVA: 0x00664984 File Offset: 0x00662B84
		Private Sub DataforNP()
			ModCommonClasses.con.Close()
			Me.CurrentRow = 0
			ModCommonClasses.con.Open()
			Me.Dad = New SqlDataAdapter("Select * FROM PurchaseOrder", ModCommonClasses.con)
			Me.Dad.Fill(Me.Dst, "PurchaseOrder")
			Try
				Me.txtNP.Text = Conversions.ToString(Me.Dst.Tables("PurchaseOrder").Rows(Conversions.ToInteger(Me.CurrentRow))("PO_ID"))
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x06008B7B RID: 35707 RVA: 0x00664A60 File Offset: 0x00662C60
		Private Sub btnNext_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtPO_ID.Text))
				Dim flag As Boolean = Me.cmbNP.SelectedIndex < Me.cmbNP.Items.Count - 1
				If flag Then
					Me.cmbNP.SelectedIndex = Me.cmbNP.SelectedIndex + 1
					Me.NextPrev()
					Me.NextPrev()
					Me.NextPrev()
				Else
					MessageBox.Show("Last Record is Reached", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06008B7C RID: 35708 RVA: 0x00664B1C File Offset: 0x00662D1C
		Private Sub txtPrev_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtPO_ID.Text))
				Dim flag As Boolean = Me.cmbNP.SelectedIndex > 0
				If flag Then
					' The following expression was wrapped in a checked-expression
					Me.cmbNP.SelectedIndex = Me.cmbNP.SelectedIndex - 1
					Me.NextPrev()
					Me.NextPrev()
					Me.NextPrev()
				Else
					MessageBox.Show("First Record is Reached", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06008B7D RID: 35709 RVA: 0x00664BC8 File Offset: 0x00662DC8
		Private Sub btnLast_Click(sender As Object, e As EventArgs)
			Try
				' The following expression was wrapped in a checked-expression
				Me.CurrentRow = Me.Dst.Tables("PurchaseOrder").Rows.Count - 1
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("PurchaseOrder").Rows(Conversions.ToInteger(Me.CurrentRow))("PO_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06008B7E RID: 35710 RVA: 0x00664C80 File Offset: 0x00662E80
		Private Sub btnFirst_Click(sender As Object, e As EventArgs)
			Try
				Me.CurrentRow = 0
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("PurchaseOrder").Rows(Conversions.ToInteger(Me.CurrentRow))("PO_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06008B7F RID: 35711 RVA: 0x00664D18 File Offset: 0x00662F18
		Public Sub Speaker()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.DataGridView1.Rows.Count - 1
				For i As Integer = 0 To num
					Dim num2 As Double = Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("Column6").Value))
					Me.txtRsToWords.Text = Conversions.ToString(RupModule1.RupeesToWord(Conversion.Val(num2)))
					Me.a1 = Me.DataGridView1.Rows(i).Cells("Column3").Value.ToString()
					Me.a2 = Conversions.ToString(Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("Column4").Value)))
					NewLateBinding.LateCall(Me.voice, Nothing, "speak", New Object() { String.Concat(New String() { Me.a1, " ", Me.a2, "Main Unit ", Me.txtRsToWords.Text }) }, Nothing, Nothing, Nothing, True)
				Next
				NewLateBinding.LateCall(Me.voice, Nothing, "speak", New Object() { "Thank You" }, Nothing, Nothing, Nothing, True)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06008B80 RID: 35712 RVA: 0x00664EB8 File Offset: 0x006630B8
		Private Sub Button34_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.DataGridView1.Rows.Count = 0
			If flag Then
				MessageBox.Show("You have not added the products into grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Me.Speaker()
			End If
		End Sub

		' Token: 0x06008B81 RID: 35713 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmPurchaseOrder_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06008B82 RID: 35714 RVA: 0x00664EFC File Offset: 0x006630FC
		Public Sub InvoiceHead()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(LIDS) from InvoiceHead"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.InvDateSts = ModCommonClasses.rdr.GetValue(0).ToString()
				Else
					Me.InvDateSts = "No"
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008B83 RID: 35715 RVA: 0x00664FF4 File Offset: 0x006631F4
		Public Sub LastBillDate()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT Top 1 Date from PurchaseOrder order by PO_ID DESC"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.prevdate = Conversions.ToDate(ModCommonClasses.rdr.GetValue(0).ToString())
				Else
					Me.prevdate = DateAndTime.Today
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				Dim flag4 As Boolean = Operators.CompareString(Me.InvDateSts, "Yes", False) = 0
				If flag4 Then
					Me.dtpPODate.Value = Me.prevdate
				Else
					Me.dtpPODate.Value = DateAndTime.Today
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008B84 RID: 35716 RVA: 0x000440DC File Offset: 0x000422DC
		Public Sub customerdetaildisable()
			Me.cmbSupplierName.Enabled = False
			Me.btnSelection.Enabled = False
		End Sub

		' Token: 0x06008B85 RID: 35717 RVA: 0x000440F9 File Offset: 0x000422F9
		Public Sub customerdetailenable()
			Me.cmbSupplierName.Enabled = True
			Me.btnSelection.Enabled = True
		End Sub

		' Token: 0x06008B86 RID: 35718 RVA: 0x00665134 File Offset: 0x00663334
		Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
			Dim flag As Boolean = Me.DataGridView1.RowCount > 0
			If flag Then
				Me.customerdetaildisable()
			End If
		End Sub

		' Token: 0x06008B87 RID: 35719 RVA: 0x00665160 File Offset: 0x00663360
		Public Sub CipherCode()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(c0),RTRIM(c1),RTRIM(c2),RTRIM(c3),RTRIM(c4),RTRIM(c5),RTRIM(c6),RTRIM(c7),RTRIM(c8),RTRIM(c9),RTRIM(c12),RTRIM(c13),RTRIM(c14) from CipherCode", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.b0 = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
					Me.b1 = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.b2 = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.b3 = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.b4 = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.b5 = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.b6 = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.b7 = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.b8 = ModCommonClasses.rdr.GetValue(8).ToString()
					Me.b9 = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.b12 = ModCommonClasses.rdr.GetValue(10).ToString()
					Me.b13 = ModCommonClasses.rdr.GetValue(11).ToString()
					Me.b14 = ModCommonClasses.rdr.GetValue(12).ToString()
				Else
					Me.b0 = Conversions.ToString(0)
					Me.b1 = Conversions.ToString(1)
					Me.b2 = Conversions.ToString(2)
					Me.b3 = Conversions.ToString(3)
					Me.b4 = Conversions.ToString(4)
					Me.b5 = Conversions.ToString(5)
					Me.b6 = Conversions.ToString(6)
					Me.b7 = Conversions.ToString(7)
					Me.b8 = Conversions.ToString(8)
					Me.b9 = Conversions.ToString(9)
					Me.b12 = Conversions.ToString(0)
					Me.b13 = Conversions.ToString(0)
					Me.b14 = "No"
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				Me.b0 = Conversions.ToString(0)
				Me.b1 = Conversions.ToString(1)
				Me.b2 = Conversions.ToString(2)
				Me.b3 = Conversions.ToString(3)
				Me.b4 = Conversions.ToString(4)
				Me.b5 = Conversions.ToString(5)
				Me.b6 = Conversions.ToString(6)
				Me.b7 = Conversions.ToString(7)
				Me.b8 = Conversions.ToString(8)
				Me.b9 = Conversions.ToString(9)
				Me.b12 = Conversions.ToString(0)
				Me.b13 = Conversions.ToString(0)
				Me.b14 = "No"
			End Try
		End Sub

		' Token: 0x06008B88 RID: 35720 RVA: 0x00665464 File Offset: 0x00663664
		Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox6.Checked
			If checked Then
				Me.TextBox7.Text = Me.TextBox9.Text
				Dim i As Integer = 0
				While i < 1000
					i += 1
					Dim flag As Boolean = Strings.InStr(Me.TextBox7.Text, "0", CompareMethod.Binary) <> 0
					If flag Then
						Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(0), Me.b0, 1, -1, CompareMethod.Binary)
					Else
						Dim flag2 As Boolean = Strings.InStr(Me.TextBox7.Text, "1", CompareMethod.Binary) <> 0
						If flag2 Then
							Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(1), Me.b1, 1, -1, CompareMethod.Binary)
						Else
							Dim flag3 As Boolean = Strings.InStr(Me.TextBox7.Text, "2", CompareMethod.Binary) <> 0
							If flag3 Then
								Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(2), Me.b2, 1, -1, CompareMethod.Binary)
							Else
								Dim flag4 As Boolean = Strings.InStr(Me.TextBox7.Text, "3", CompareMethod.Binary) <> 0
								If flag4 Then
									Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(3), Me.b3, 1, -1, CompareMethod.Binary)
								Else
									Dim flag5 As Boolean = Strings.InStr(Me.TextBox7.Text, "4", CompareMethod.Binary) <> 0
									If flag5 Then
										Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(4), Me.b4, 1, -1, CompareMethod.Binary)
									Else
										Dim flag6 As Boolean = Strings.InStr(Me.TextBox7.Text, "5", CompareMethod.Binary) <> 0
										If flag6 Then
											Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(5), Me.b5, 1, -1, CompareMethod.Binary)
										Else
											Dim flag7 As Boolean = Strings.InStr(Me.TextBox7.Text, "6", CompareMethod.Binary) <> 0
											If flag7 Then
												Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(6), Me.b6, 1, -1, CompareMethod.Binary)
											Else
												Dim flag8 As Boolean = Strings.InStr(Me.TextBox7.Text, "7", CompareMethod.Binary) <> 0
												If flag8 Then
													Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(7), Me.b7, 1, -1, CompareMethod.Binary)
												Else
													Dim flag9 As Boolean = Strings.InStr(Me.TextBox7.Text, "8", CompareMethod.Binary) <> 0
													If flag9 Then
														Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(8), Me.b8, 1, -1, CompareMethod.Binary)
													Else
														Dim flag10 As Boolean = Strings.InStr(Me.TextBox7.Text, "9", CompareMethod.Binary) <> 0
														If flag10 Then
															Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(9), Me.b9, 1, -1, CompareMethod.Binary)
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
					Dim flag11 As Boolean = Operators.CompareString(Me.TextBox7.Text, "", False) = 0
					If flag11 Then
						Me.TextBox7.Text = Me.TextBox9.Text
					End If
				End While
			Else
				Dim flag12 As Boolean = Not Me.CheckBox6.Checked
				If flag12 Then
					Me.TextBox7.Text = Me.TextBox9.Text
				End If
			End If
		End Sub

		' Token: 0x06008B89 RID: 35721 RVA: 0x00665834 File Offset: 0x00663A34
		Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.b14, "Yes", False) = 0
			If flag Then
				Me.TextBox9.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.txtRetail.Text)) + Conversions.ToDouble(Me.b12))
			Else
				Me.TextBox9.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.txtRetail.Text)))
			End If
			Dim checked As Boolean = Me.CheckBox6.Checked
			If checked Then
				Me.TextBox7.Text = Me.TextBox9.Text
				Dim i As Integer = 0
				While i < 1000
					i += 1
					Dim flag2 As Boolean = Strings.InStr(Me.TextBox7.Text, "0", CompareMethod.Binary) <> 0
					If flag2 Then
						Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(0), Me.b0, 1, -1, CompareMethod.Binary)
					Else
						Dim flag3 As Boolean = Strings.InStr(Me.TextBox7.Text, "1", CompareMethod.Binary) <> 0
						If flag3 Then
							Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(1), Me.b1, 1, -1, CompareMethod.Binary)
						Else
							Dim flag4 As Boolean = Strings.InStr(Me.TextBox7.Text, "2", CompareMethod.Binary) <> 0
							If flag4 Then
								Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(2), Me.b2, 1, -1, CompareMethod.Binary)
							Else
								Dim flag5 As Boolean = Strings.InStr(Me.TextBox7.Text, "3", CompareMethod.Binary) <> 0
								If flag5 Then
									Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(3), Me.b3, 1, -1, CompareMethod.Binary)
								Else
									Dim flag6 As Boolean = Strings.InStr(Me.TextBox7.Text, "4", CompareMethod.Binary) <> 0
									If flag6 Then
										Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(4), Me.b4, 1, -1, CompareMethod.Binary)
									Else
										Dim flag7 As Boolean = Strings.InStr(Me.TextBox7.Text, "5", CompareMethod.Binary) <> 0
										If flag7 Then
											Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(5), Me.b5, 1, -1, CompareMethod.Binary)
										Else
											Dim flag8 As Boolean = Strings.InStr(Me.TextBox7.Text, "6", CompareMethod.Binary) <> 0
											If flag8 Then
												Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(6), Me.b6, 1, -1, CompareMethod.Binary)
											Else
												Dim flag9 As Boolean = Strings.InStr(Me.TextBox7.Text, "7", CompareMethod.Binary) <> 0
												If flag9 Then
													Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(7), Me.b7, 1, -1, CompareMethod.Binary)
												Else
													Dim flag10 As Boolean = Strings.InStr(Me.TextBox7.Text, "8", CompareMethod.Binary) <> 0
													If flag10 Then
														Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(8), Me.b8, 1, -1, CompareMethod.Binary)
													Else
														Dim flag11 As Boolean = Strings.InStr(Me.TextBox7.Text, "9", CompareMethod.Binary) <> 0
														If flag11 Then
															Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(9), Me.b9, 1, -1, CompareMethod.Binary)
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
					Dim flag12 As Boolean = Operators.CompareString(Me.TextBox7.Text, "", False) = 0
					If flag12 Then
						Me.TextBox7.Text = Me.TextBox9.Text
					End If
				End While
			Else
				Dim flag13 As Boolean = Not Me.CheckBox6.Checked
				If flag13 Then
					Me.TextBox7.Text = Me.TextBox9.Text
				End If
			End If
		End Sub

		' Token: 0x06008B8A RID: 35722 RVA: 0x00665C7C File Offset: 0x00663E7C
		Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox7.Checked
			If checked Then
				Me.TextBox8.Text = Me.TextBox10.Text
				Dim i As Integer = 0
				While i < 1000
					i += 1
					Dim flag As Boolean = Strings.InStr(Me.TextBox8.Text, "0", CompareMethod.Binary) <> 0
					If flag Then
						Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(0), Me.b0, 1, -1, CompareMethod.Binary)
					Else
						Dim flag2 As Boolean = Strings.InStr(Me.TextBox8.Text, "1", CompareMethod.Binary) <> 0
						If flag2 Then
							Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(1), Me.b1, 1, -1, CompareMethod.Binary)
						Else
							Dim flag3 As Boolean = Strings.InStr(Me.TextBox8.Text, "2", CompareMethod.Binary) <> 0
							If flag3 Then
								Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(2), Me.b2, 1, -1, CompareMethod.Binary)
							Else
								Dim flag4 As Boolean = Strings.InStr(Me.TextBox8.Text, "3", CompareMethod.Binary) <> 0
								If flag4 Then
									Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(3), Me.b3, 1, -1, CompareMethod.Binary)
								Else
									Dim flag5 As Boolean = Strings.InStr(Me.TextBox8.Text, "4", CompareMethod.Binary) <> 0
									If flag5 Then
										Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(4), Me.b4, 1, -1, CompareMethod.Binary)
									Else
										Dim flag6 As Boolean = Strings.InStr(Me.TextBox8.Text, "5", CompareMethod.Binary) <> 0
										If flag6 Then
											Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(5), Me.b5, 1, -1, CompareMethod.Binary)
										Else
											Dim flag7 As Boolean = Strings.InStr(Me.TextBox8.Text, "6", CompareMethod.Binary) <> 0
											If flag7 Then
												Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(6), Me.b6, 1, -1, CompareMethod.Binary)
											Else
												Dim flag8 As Boolean = Strings.InStr(Me.TextBox8.Text, "7", CompareMethod.Binary) <> 0
												If flag8 Then
													Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(7), Me.b7, 1, -1, CompareMethod.Binary)
												Else
													Dim flag9 As Boolean = Strings.InStr(Me.TextBox8.Text, "8", CompareMethod.Binary) <> 0
													If flag9 Then
														Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(8), Me.b8, 1, -1, CompareMethod.Binary)
													Else
														Dim flag10 As Boolean = Strings.InStr(Me.TextBox8.Text, "9", CompareMethod.Binary) <> 0
														If flag10 Then
															Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(9), Me.b9, 1, -1, CompareMethod.Binary)
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
					Dim flag11 As Boolean = Operators.CompareString(Me.TextBox8.Text, "", False) = 0
					If flag11 Then
						Me.TextBox8.Text = Me.TextBox10.Text
					End If
				End While
			Else
				Dim flag12 As Boolean = Not Me.CheckBox7.Checked
				If flag12 Then
					Me.TextBox8.Text = Me.TextBox10.Text
				End If
			End If
		End Sub

		' Token: 0x06008B8B RID: 35723 RVA: 0x0066604C File Offset: 0x0066424C
		Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.b14, "Yes", False) = 0
			If flag Then
				Me.TextBox10.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.txtWholesale.Text)) + Conversions.ToDouble(Me.b13))
			Else
				Me.TextBox10.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.txtWholesale.Text)))
			End If
			Dim checked As Boolean = Me.CheckBox7.Checked
			If checked Then
				Me.TextBox8.Text = Me.TextBox10.Text
				Dim i As Integer = 0
				While i < 1000
					i += 1
					Dim flag2 As Boolean = Strings.InStr(Me.TextBox8.Text, "0", CompareMethod.Binary) <> 0
					If flag2 Then
						Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(0), Me.b0, 1, -1, CompareMethod.Binary)
					Else
						Dim flag3 As Boolean = Strings.InStr(Me.TextBox8.Text, "1", CompareMethod.Binary) <> 0
						If flag3 Then
							Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(1), Me.b1, 1, -1, CompareMethod.Binary)
						Else
							Dim flag4 As Boolean = Strings.InStr(Me.TextBox8.Text, "2", CompareMethod.Binary) <> 0
							If flag4 Then
								Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(2), Me.b2, 1, -1, CompareMethod.Binary)
							Else
								Dim flag5 As Boolean = Strings.InStr(Me.TextBox8.Text, "3", CompareMethod.Binary) <> 0
								If flag5 Then
									Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(3), Me.b3, 1, -1, CompareMethod.Binary)
								Else
									Dim flag6 As Boolean = Strings.InStr(Me.TextBox8.Text, "4", CompareMethod.Binary) <> 0
									If flag6 Then
										Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(4), Me.b4, 1, -1, CompareMethod.Binary)
									Else
										Dim flag7 As Boolean = Strings.InStr(Me.TextBox8.Text, "5", CompareMethod.Binary) <> 0
										If flag7 Then
											Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(5), Me.b5, 1, -1, CompareMethod.Binary)
										Else
											Dim flag8 As Boolean = Strings.InStr(Me.TextBox8.Text, "6", CompareMethod.Binary) <> 0
											If flag8 Then
												Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(6), Me.b6, 1, -1, CompareMethod.Binary)
											Else
												Dim flag9 As Boolean = Strings.InStr(Me.TextBox8.Text, "7", CompareMethod.Binary) <> 0
												If flag9 Then
													Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(7), Me.b7, 1, -1, CompareMethod.Binary)
												Else
													Dim flag10 As Boolean = Strings.InStr(Me.TextBox8.Text, "8", CompareMethod.Binary) <> 0
													If flag10 Then
														Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(8), Me.b8, 1, -1, CompareMethod.Binary)
													Else
														Dim flag11 As Boolean = Strings.InStr(Me.TextBox8.Text, "9", CompareMethod.Binary) <> 0
														If flag11 Then
															Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(9), Me.b9, 1, -1, CompareMethod.Binary)
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
					Dim flag12 As Boolean = Operators.CompareString(Me.TextBox8.Text, "", False) = 0
					If flag12 Then
						Me.TextBox8.Text = Me.TextBox10.Text
					End If
				End While
			Else
				Dim flag13 As Boolean = Not Me.CheckBox7.Checked
				If flag13 Then
					Me.TextBox8.Text = Me.TextBox10.Text
				End If
			End If
		End Sub

		' Token: 0x06008B8C RID: 35724 RVA: 0x00666494 File Offset: 0x00664694
		Private Sub txtRetail_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.b14, "Yes", False) = 0
			If flag Then
				Me.TextBox9.Text = Conversions.ToString(Conversion.Val(Me.txtRetail.Text) + Conversions.ToDouble(Me.b12))
			Else
				Me.TextBox9.Text = Conversions.ToString(Conversion.Val(Me.txtRetail.Text))
			End If
		End Sub

		' Token: 0x06008B8D RID: 35725 RVA: 0x00044116 File Offset: 0x00042316
		Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs)
			Me.txtProductName.Text = ""
		End Sub

		' Token: 0x06008B8E RID: 35726 RVA: 0x00666510 File Offset: 0x00664710
		Private Sub txtWholesale_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.b14, "Yes", False) = 0
			If flag Then
				Me.TextBox10.Text = Conversions.ToString(Conversion.Val(Me.txtWholesale.Text) + Conversions.ToDouble(Me.b13))
			Else
				Me.TextBox10.Text = Conversions.ToString(Conversion.Val(Me.txtWholesale.Text))
			End If
		End Sub

		' Token: 0x06008B8F RID: 35727 RVA: 0x0066658C File Offset: 0x0066478C
		Private Sub txtProductName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.txtProductName.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Enter the valid product name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Me.getgriditemdata()
					Me.dgw4.Visible = True
					Dim flag3 As Boolean = Me.dgw4.Rows.Count = 1
					If flag3 Then
						Me.dgw4.Focus()
						Me.RetrieveData1()
					Else
						Dim flag4 As Boolean = Me.dgw4.Rows.Count > 1
						If flag4 Then
							Me.dgw4.Focus()
							SendKeys.Send("{ENTER}")
						End If
					End If
					e.SuppressKeyPress = True
				End If
			End If
		End Sub

		' Token: 0x06008B90 RID: 35728 RVA: 0x00666658 File Offset: 0x00664858
		Private Sub btnPrint_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmReport.TextBox2.Text = Me.txtContactNo.Text.TrimEnd(New Char(-1) {})
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim rptPurchaseOrder As rptPurchaseOrder = New rptPurchaseOrder()
				Dim sqlCommand As SqlCommand = New SqlCommand()
				Dim sqlCommand2 As SqlCommand = New SqlCommand()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
				Dim dataSet As DataSet = New DataSet()
				Dim dataSet2 As DataSet = New DataSet()
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = sqlConnection
				sqlCommand2.Connection = sqlConnection
				sqlCommand.CommandText = If(("SELECT PurchaseOrder.PO_ID, PurchaseOrder.PONo, PurchaseOrder.Date, PurchaseOrder.SupplierID, PurchaseOrder.TaxType, PurchaseOrder.SGST, PurchaseOrder.CGST, PurchaseOrder.IGST, PurchaseOrder.CESS, PurchaseOrder.SubTotal, PurchaseOrder.GrandTotal, PurchaseOrder.TermsAndConditions, PurchaseOrder.Terms, PurchaseOrder_Join.POJ_ID, PurchaseOrder_Join.PurchaseOrderID, PurchaseOrder_Join.ProductID, PurchaseOrder_Join.Qty, PurchaseOrder_Join.Price, PurchaseOrder_Join.CGSTPer, PurchaseOrder_Join.CGSTAmt, PurchaseOrder_Join.SGSTPer, PurchaseOrder_Join.SGSTAmt,  PurchaseOrder_Join.IGSTPer, PurchaseOrder_Join.IGSTAmt, PurchaseOrder_Join.CESSPer, PurchaseOrder_Join.CESSAmt, PurchaseOrder_Join.DiscountPer, PurchaseOrder_Join.DiscountAmt,PurchaseOrder_Join.TotalAmount, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, PurchaseOrder_Join.TaxableAmt as PartNo, Product.Description, Product.CostPrice, Product.PurchaseUnit,Product.SalesUnit, Supplier.ID, Supplier.SupplierID AS Expr4, Supplier.Name, Supplier.Address, Supplier.City, Supplier.State, Supplier.ZipCode, Supplier.ContactNo, Supplier.EmailID, Supplier.Remarks,Supplier.AccountName, Supplier.AccountNumber, Supplier.Bank, Supplier.Branch, Supplier.IFSCCode, Supplier.GSTIN, Supplier.PAN, Supplier.CIN, Supplier.OpeningBalanceType, Supplier.OpeningBalance FROM PurchaseOrder INNER JOIN PurchaseOrder_Join ON PurchaseOrder.PO_ID = PurchaseOrder_Join.PurchaseOrderID INNER JOIN Product ON PurchaseOrder_Join.ProductID = Product.PID INNER JOIN Supplier ON PurchaseOrder.SupplierID = Supplier.ID where PO_ID=" + Conversions.ToString(Conversion.Val(Me.txtPO_ID.Text))), "")
				sqlCommand2.CommandText = "SELECT * from Company"
				sqlCommand.CommandType = CommandType.Text
				sqlCommand2.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				sqlDataAdapter2.SelectCommand = sqlCommand2
				sqlDataAdapter.Fill(dataSet, "PurchaseOrder")
				sqlDataAdapter.Fill(dataSet, "PurchaseOrder_join")
				sqlDataAdapter.Fill(dataSet, "Supplier")
				sqlDataAdapter.Fill(dataSet, "Product")
				sqlDataAdapter2.Fill(dataSet, "Company")
				rptPurchaseOrder.SetDataSource(dataSet)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = If(("SELECT Sum((TaxableAmt) + (DiscountAmt)) from PurchaseOrder_Join where PurchaseOrderID=" + Conversions.ToString(Conversion.Val(Me.txtPO_ID.Text))), "")
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.a = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				rptPurchaseOrder.SetParameterValue("P1", Me.a)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptPurchaseOrder
				MyProject.Forms.frmReport.ShowDialog()
				rptPurchaseOrder.Close()
				rptPurchaseOrder.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008B91 RID: 35729 RVA: 0x00666904 File Offset: 0x00664B04
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Me.Reset()
			MyProject.Forms.frmPurchaseOrderRecord.lblSet.Text = "PO"
			MyProject.Forms.frmPurchaseOrderRecord.Reset()
			MyProject.Forms.frmPurchaseOrderRecord.ShowDialog()
			MyProject.Forms.frmPurchaseOrderRecord.Dispose()
		End Sub

		' Token: 0x06008B92 RID: 35730 RVA: 0x00666964 File Offset: 0x00664B64
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008B93 RID: 35731 RVA: 0x006669CC File Offset: 0x00664BCC
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtSupplierID.Text)) = 0
			If flag Then
				MessageBox.Show("Please retrieve supplier details", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtSupplierID.Focus()
			Else
				Dim flag2 As Boolean = Me.cmbSupplierName.SelectedIndex = -1
				If flag2 Then
					MessageBox.Show("Please select correct supplier name", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.cmbSupplierName.Focus()
				Else
					Dim flag3 As Boolean = Me.DataGridView1.Rows.Count = 0
					If flag3 Then
						MessageBox.Show("Sorry no product info added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "Update PurchaseOrder set PONo=@d2, Date=@d3, SupplierID=@d4, TaxType=@d5,SubTotal=@d6, SGST=@d7, CGST=@d8, IGST=@d9, CESS=@d10, GrandTotal=@d11, TermsAndConditions=@d12,Terms=@d13 where PO_ID=@d1"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtPO_ID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtPONo.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpPODate.Value.[Date])
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.txtSup_ID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.cmbTaxType.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtSubTotal.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtSGST.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtCGST.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(Me.txtIGST.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(Me.txtCESS.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(Me.txtGrandTotal.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.txtTermsAndConditions.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.cmbTerms.Text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = If(("Delete from PurchaseOrder_Join where PurchaseOrderID=" + Conversions.ToString(Conversion.Val(Me.txtPO_ID.Text))), "")
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = "insert into PurchaseOrder_Join(PurchaseOrderID, ProductID, Qty, Price,DiscountPer,DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,TotalAmount,PTaxType,TaxableAmt,RCipher,WCipher,Barcode) VALUES (" + Me.txtPO_ID.Text + ",@d1,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20)"
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Prepare()
							Try
								For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
									Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
									Dim flag4 As Boolean = Not dataGridViewRow.IsNewRow
									If flag4 Then
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(5).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(7).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(8).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(11).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(12).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(13).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(14).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(15).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(16).Value))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(17).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d18", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(18).Value))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d19", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(19).Value))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d20", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(20).Value))
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.cmd.Parameters.Clear()
									End If
								Next
							Finally
								Dim enumerator As IEnumerator
								If TypeOf enumerator Is IDisposable Then
									TryCast(enumerator, IDisposable).Dispose()
								End If
							End Try
							ModCommonClasses.con.Close()
							ModFunc.LogFunc(Me.lblUser.Text, "Updated the Purchase Order having PO No. '" + Me.txtPONo.Text + "'")
							MessageBox.Show("Successfully Updated", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.btnUpdate.Enabled = False
							ModCommonClasses.con.Close()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x06008B94 RID: 35732 RVA: 0x006672C8 File Offset: 0x006654C8
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCPhone.Text, "Trial", False) <> 0
			If Not flag Then
				Dim value As DateTime = Me.dtpPODate.Value
				Dim dateTime As DateTime = New DateTime(value.Year, value.Month, 1)
				Dim dateTime2 As DateTime = dateTime.AddMonths(1).AddDays(-1.0)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(*) from PurchaseOrder where Date between @d1 and @d2 having count(*) >= 5"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dateTime
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dateTime2
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
				If flag2 Then
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					MessageBox.Show("You are not allowed to enter more than 5 vouchers for current month in trial version, Please buy register version to use without any limitation." & vbCrLf & "Thank You !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Return
				End If
				ModCommonClasses.con.Close()
			End If
			Me.auto()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text2 As String = "select * from Company"
			ModCommonClasses.cmd = New SqlCommand(text2)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag4 As Boolean = Not ModCommonClasses.rdr.Read()
			If flag4 Then
				MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag5 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
			Else
				Dim flag6 As Boolean = Strings.Len(Strings.Trim(Me.txtSupplierID.Text)) = 0
				If flag6 Then
					MessageBox.Show("Please retrieve supplier details", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbSupplierName.Focus()
				Else
					Dim flag7 As Boolean = Me.cmbSupplierName.SelectedIndex = -1
					If flag7 Then
						MessageBox.Show("Please select correct supplier name", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.cmbSupplierName.Focus()
					Else
						Dim flag8 As Boolean = Me.DataGridView1.Rows.Count = 0
						If flag8 Then
							MessageBox.Show("Sorry no product info added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							Try
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "select PONo from PurchaseOrder where PONo=@d1"
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtPONo.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag9 As Boolean = ModCommonClasses.rdr.Read()
								If flag9 Then
									MessageBox.Show("Purchase Order No. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Me.txtPONo.Text = ""
									Me.txtPONo.Focus()
									Dim flag10 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag10 Then
										ModCommonClasses.rdr.Close()
									End If
								Else
									ModCommonClasses.con.Close()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text4 As String = "insert into PurchaseOrder(PO_ID, PONo, Date, SupplierID, TaxType,SubTotal, SGST, CGST, IGST, CESS, GrandTotal, TermsAndConditions,Terms) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)"
									ModCommonClasses.cmd = New SqlCommand(text4)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtPO_ID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtPONo.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpPODate.Value.[Date])
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.txtSup_ID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.cmbTaxType.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtSubTotal.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtSGST.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtCGST.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(Me.txtIGST.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(Me.txtCESS.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(Me.txtGrandTotal.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.txtTermsAndConditions.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.cmbTerms.Text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteNonQuery()
									ModCommonClasses.con.Close()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text5 As String = "insert into PurchaseOrder_Join(PurchaseOrderID, ProductID, Qty, Price,DiscountPer,DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,TotalAmount,PTaxType,TaxableAmt,RCipher,WCipher,Barcode) VALUES (" + Me.txtPO_ID.Text + ",@d1,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20)"
									ModCommonClasses.cmd = New SqlCommand(text5)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.Prepare()
									Try
										For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
											Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
											Dim flag11 As Boolean = Not dataGridViewRow.IsNewRow
											If flag11 Then
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(5).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(7).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(8).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(11).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(12).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(13).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(14).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(15).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(16).Value))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(17).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d18", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(18).Value))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d19", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(19).Value))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d20", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(20).Value))
												ModCommonClasses.cmd.ExecuteNonQuery()
												ModCommonClasses.cmd.Parameters.Clear()
											End If
										Next
									Finally
										Dim enumerator As IEnumerator
										If TypeOf enumerator Is IDisposable Then
											TryCast(enumerator, IDisposable).Dispose()
										End If
									End Try
									ModCommonClasses.con.Close()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text6 As String = "insert into SrPurOrder(ID, InvNo) Values (@d1,@d2)"
									ModCommonClasses.cmd = New SqlCommand(text6)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.ntid))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtPONo.Text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteReader()
									ModCommonClasses.con.Close()
									Me.DataforNP()
									ModFunc.LogFunc(Me.lblUser.Text, "added the new Purchase Order having PO No. '" + Me.txtPONo.Text + "'")
									MessageBox.Show("Successfully Saved", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.fillPOrderID()
									Me.btnSave.Enabled = False
									ModCommonClasses.con.Close()
									Me.btnPrint.Enabled = True
								End If
							Catch ex As Exception
								MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06008B95 RID: 35733 RVA: 0x0004412A File Offset: 0x0004232A
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Reset()
		End Sub

		' Token: 0x06008B96 RID: 35734 RVA: 0x00667EE0 File Offset: 0x006660E0
		Private Sub txtProductName_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtProductName.Text.TrimEnd(New Char(-1) {}), "", False) > 0
			If flag Then
				Me.getgriditemdata()
			Else
				Me.dgw4.Visible = False
			End If
		End Sub

		' Token: 0x06008B97 RID: 35735 RVA: 0x00667F30 File Offset: 0x00666130
		Private Sub getgriditemdata()
			Try
				Me.dgw4.Visible = True
				Me.dgw4.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw4.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), "  PID, RTRIM(Product.ProductCode),RTRIM(Product.ProductName),RTRIM(Product.HSNCode),RTRIM(Product.PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.MRP),(Product.Discount),Product.CGST,Product.SGST,Product.CESS,Product.CESS,RTRIM(Product.SalesUnit),(Temp_Stock.WPrice),(Temp_Stock.SPrice),RTRIM(Product.SalesAltUnit),RTRIM(Product.Conv),RTRIM(Product.SalesAltUnit),RTRIM(Product.Conv),RTRIM(Temp_Stock.Damage),RTRIM(Product.MinStock),RTRIM(Product.PTax) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and ProductName like N'", Me.txtProductName.Text, "%' order by ProductName" }), ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw4.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw4.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06008B98 RID: 35736 RVA: 0x006681BC File Offset: 0x006663BC
		Private Sub txtProductName_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Down
			If flag Then
				Dim visible As Boolean = Me.dgw4.Visible
				If visible Then
					Me.dgw4.Focus()
					SendKeys.Send("{DOWN}")
				End If
			End If
		End Sub

		' Token: 0x06008B99 RID: 35737 RVA: 0x00668204 File Offset: 0x00666404
		Private Sub dgw4_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				Me.dgw4.Visible = False
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = ""
			Else
				Dim flag2 As Boolean = e.KeyCode = Keys.Back
				If flag2 Then
					Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
					Me.txtProductName.Focus()
					Me.txtProductName.ScrollToCaret()
					Dim flag3 As Boolean = Operators.CompareString(Me.txtProductName.Text, "", False) > 0
					If flag3 Then
						' The following expression was wrapped in a checked-expression
						Me.txtProductName.Text = Me.txtProductName.Text.Remove(Me.txtProductName.Text.Length - 1, 1)
						Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
						Me.txtProductName.Focus()
						Me.txtProductName.ScrollToCaret()
					End If
				End If
			End If
			Dim flag4 As Boolean = e.KeyCode = Keys.A
			If flag4 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "a"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag5 As Boolean = e.KeyCode = Keys.B
			If flag5 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "b"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag6 As Boolean = e.KeyCode = Keys.C
			If flag6 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "c"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag7 As Boolean = e.KeyCode = Keys.D
			If flag7 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "d"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag8 As Boolean = e.KeyCode = Keys.E
			If flag8 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "e"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag9 As Boolean = e.KeyCode = Keys.F
			If flag9 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "f"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag10 As Boolean = e.KeyCode = Keys.G
			If flag10 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "g"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag11 As Boolean = e.KeyCode = Keys.H
			If flag11 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "h"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag12 As Boolean = e.KeyCode = Keys.I
			If flag12 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "i"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag13 As Boolean = e.KeyCode = Keys.J
			If flag13 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "j"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag14 As Boolean = e.KeyCode = Keys.K
			If flag14 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "k"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag15 As Boolean = e.KeyCode = Keys.L
			If flag15 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "l"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag16 As Boolean = e.KeyCode = Keys.M
			If flag16 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "m"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag17 As Boolean = e.KeyCode = Keys.N
			If flag17 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "n"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag18 As Boolean = e.KeyCode = Keys.O
			If flag18 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "o"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag19 As Boolean = e.KeyCode = Keys.P
			If flag19 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "p"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag20 As Boolean = e.KeyCode = Keys.Q
			If flag20 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "q"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag21 As Boolean = e.KeyCode = Keys.R
			If flag21 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "r"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag22 As Boolean = e.KeyCode = Keys.S
			If flag22 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "s"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag23 As Boolean = e.KeyCode = Keys.T
			If flag23 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "t"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag24 As Boolean = e.KeyCode = Keys.U
			If flag24 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "u"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag25 As Boolean = e.KeyCode = Keys.V
			If flag25 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "v"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag26 As Boolean = e.KeyCode = Keys.W
			If flag26 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "w"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag27 As Boolean = e.KeyCode = Keys.X
			If flag27 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "x"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag28 As Boolean = e.KeyCode = Keys.Y
			If flag28 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "y"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag29 As Boolean = e.KeyCode = Keys.Z
			If flag29 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "z"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag30 As Boolean = e.KeyCode = Keys.D0
			If flag30 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "0"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag31 As Boolean = e.KeyCode = Keys.D1
			If flag31 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "1"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag32 As Boolean = e.KeyCode = Keys.D2
			If flag32 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "2"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag33 As Boolean = e.KeyCode = Keys.D3
			If flag33 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "3"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag34 As Boolean = e.KeyCode = Keys.D4
			If flag34 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "4"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag35 As Boolean = e.KeyCode = Keys.D5
			If flag35 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "5"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag36 As Boolean = e.KeyCode = Keys.D6
			If flag36 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "6"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag37 As Boolean = e.KeyCode = Keys.D7
			If flag37 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "7"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag38 As Boolean = e.KeyCode = Keys.D8
			If flag38 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "8"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag39 As Boolean = e.KeyCode = Keys.D9
			If flag39 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "9"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag40 As Boolean = e.KeyCode = Keys.Oemplus
			If flag40 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "+"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag41 As Boolean = e.KeyCode = Keys.OemMinus
			If flag41 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "-"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag42 As Boolean = e.KeyCode = Keys.OemBackslash
			If flag42 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + "\"
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
			Dim flag43 As Boolean = e.KeyCode = Keys.Oemcomma
			If flag43 Then
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
				Me.txtProductName.Text = Me.txtProductName.Text + ","
				Me.txtProductName.[Select](Me.txtProductName.Text.Length, 0)
				Me.txtProductName.Focus()
				Me.txtProductName.ScrollToCaret()
			End If
		End Sub

		' Token: 0x06008B9A RID: 35738 RVA: 0x0004413B File Offset: 0x0004233B
		Private Sub txtQty_Leave(sender As Object, e As EventArgs)
			Me.dgw4.Visible = False
		End Sub

		' Token: 0x06008B9B RID: 35739 RVA: 0x00669C4C File Offset: 0x00667E4C
		Private Sub dgw4_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData1()
			End If
		End Sub

		' Token: 0x06008B9C RID: 35740 RVA: 0x0004414B File Offset: 0x0004234B
		Private Sub dgw4_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData1()
		End Sub

		' Token: 0x06008B9D RID: 35741 RVA: 0x00669C74 File Offset: 0x00667E74
		Public Sub RetrieveData1()
			Try
				Dim flag As Boolean = Operators.CompareString(Me.txtSupplierID.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please retrieve supplier info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.dgw4.Visible = False
					Me.cmbSupplierName.Focus()
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "select * from Company"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
					If flag2 Then
						MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag3 Then
							ModCommonClasses.rdr.Close()
						End If
					Else
						Dim dataGridViewRow As DataGridViewRow = Me.dgw4.SelectedRows(0)
						Me.txtProductID.Text = dataGridViewRow.Cells(0).Value.ToString()
						Me.txtTaxType.Text = dataGridViewRow.Cells(22).Value.ToString()
						Me.txtProductName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Me.txtHSNCode.Text = dataGridViewRow.Cells(3).Value.ToString()
						Me.txtBarcode.Text = dataGridViewRow.Cells(5).Value.ToString()
						Me.txtPricePerQty.Text = dataGridViewRow.Cells(6).Value.ToString()
						Me.txtDiscPer.Text = "0.00"
						Me.lblUnit.Text = dataGridViewRow.Cells(13).Value.ToString()
						Dim flag4 As Boolean = Operators.CompareString(Me.txtState.Text, Me.txtCompanyState.Text, False) = 0
						If flag4 Then
							Me.txtCGSTPer.Text = dataGridViewRow.Cells(9).Value.ToString()
							Me.txtSGSTPer.Text = dataGridViewRow.Cells(10).Value.ToString()
							Me.txtIGSTPer.Text = Conversions.ToString(0)
						Else
							Dim flag5 As Boolean = Operators.CompareString(Me.txtState.Text, Me.txtCompanyState.Text, False) <> 0
							If flag5 Then
								Me.txtCGSTPer.Text = Conversions.ToString(0)
								Me.txtSGSTPer.Text = Conversions.ToString(0)
								Me.txtIGSTPer.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
							End If
						End If
						Me.txtCESSPer.Text = dataGridViewRow.Cells(11).Value.ToString()
						Me.txtRetail.Text = dataGridViewRow.Cells(15).Value.ToString()
						Me.txtWholesale.Text = dataGridViewRow.Cells(14).Value.ToString()
						Me.txtQty.Text = Conversions.ToString(1)
						Me.txtQty.Focus()
						Me.GetQty_S()
						Me.dgw4.Visible = False
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06008B9E RID: 35742 RVA: 0x0066A058 File Offset: 0x00668258
		Private Sub txtPricePerQty_GotFocus(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(*) from Stock Having count(*) >= 1 and " + Conversions.ToString(Conversion.Val(Me.txtProductID.Text)) + " > 0"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dgwsale.Visible = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT TOP 5 Stock.Date, RTRIM(Stock.InvoiceNo), RTRIM(Supplier.Name), Stock_Product.Price FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock_Product.ProductID = " + Conversions.ToString(Conversion.Val(Me.txtProductID.Text)) + " order by Stock.Date DESC", ModCommonClasses.con)
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgwsale.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgwsale.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
					End While
					Me.dgwsale.ClearSelection()
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008B9F RID: 35743 RVA: 0x00044155 File Offset: 0x00042355
		Private Sub txtPricePerQty_LostFocus(sender As Object, e As EventArgs)
			Me.dgwsale.Visible = False
		End Sub

		' Token: 0x04003D91 RID: 15761
		Private str As String

		' Token: 0x04003D92 RID: 15762
		Private OBType As String

		' Token: 0x04003D93 RID: 15763
		Private num1 As Double

		' Token: 0x04003D94 RID: 15764
		Private num2 As Double

		' Token: 0x04003D95 RID: 15765
		Private num3 As Double

		' Token: 0x04003D96 RID: 15766
		Private num4 As Double

		' Token: 0x04003D97 RID: 15767
		Private num5 As Double

		' Token: 0x04003D98 RID: 15768
		Private num6 As Double

		' Token: 0x04003D99 RID: 15769
		Private num7 As Double

		' Token: 0x04003D9A RID: 15770
		Private num8 As Double

		' Token: 0x04003D9B RID: 15771
		Private num9 As Double

		' Token: 0x04003D9C RID: 15772
		Private num10 As Double

		' Token: 0x04003D9D RID: 15773
		Private num11 As Double

		' Token: 0x04003D9E RID: 15774
		Private a As Double

		' Token: 0x04003D9F RID: 15775
		Private ntid As String

		' Token: 0x04003DA0 RID: 15776
		Private Dad As SqlDataAdapter

		' Token: 0x04003DA1 RID: 15777
		Private Dst As DataSet

		' Token: 0x04003DA2 RID: 15778
		Private CurrentRow As Object

		' Token: 0x04003DA3 RID: 15779
		Private voice As Object

		' Token: 0x04003DA4 RID: 15780
		Private a1 As String

		' Token: 0x04003DA5 RID: 15781
		Private a2 As String

		' Token: 0x04003DA6 RID: 15782
		Private InvDateSts As String

		' Token: 0x04003DA7 RID: 15783
		Private prevdate As DateTime

		' Token: 0x04003DA8 RID: 15784
		Private b0 As String

		' Token: 0x04003DA9 RID: 15785
		Private b1 As String

		' Token: 0x04003DAA RID: 15786
		Private b2 As String

		' Token: 0x04003DAB RID: 15787
		Private b3 As String

		' Token: 0x04003DAC RID: 15788
		Private b4 As String

		' Token: 0x04003DAD RID: 15789
		Private b5 As String

		' Token: 0x04003DAE RID: 15790
		Private b6 As String

		' Token: 0x04003DAF RID: 15791
		Private b7 As String

		' Token: 0x04003DB0 RID: 15792
		Private b8 As String

		' Token: 0x04003DB1 RID: 15793
		Private b9 As String

		' Token: 0x04003DB2 RID: 15794
		Private b12 As String

		' Token: 0x04003DB3 RID: 15795
		Private b13 As String

		' Token: 0x04003DB4 RID: 15796
		Private b14 As String
	End Class
End Namespace
