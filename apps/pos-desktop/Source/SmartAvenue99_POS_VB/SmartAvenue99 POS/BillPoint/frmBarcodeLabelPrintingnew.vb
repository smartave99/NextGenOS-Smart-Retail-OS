Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports CrystalDecisions.CrystalReports.Engine
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x02000016 RID: 22
	<DesignerGenerated()>
	Public Partial Class frmBarcodeLabelPrintingnew
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060004F4 RID: 1268 RVA: 0x000883B0 File Offset: 0x000865B0
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBarcodeLabelPrinting_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmBarcodeLabelPrinting_KeyDown
			AddHandler MyBase.Closed, AddressOf Me.frmBarcodeLabelPrinting_Closed
			Me.ds_labels = New DataSet()
			Me.MyDS = New DataSet()
			Me.number = 1
			Me.numberPb = 1
			Me.mPageNumber = 1
			Me.dt1 = New DataTable()
			Me.InitializeComponent()
		End Sub

		' Token: 0x170002E6 RID: 742
		' (get) Token: 0x060004F7 RID: 1271 RVA: 0x0000947F File Offset: 0x0000767F
		' (set) Token: 0x060004F8 RID: 1272 RVA: 0x00009489 File Offset: 0x00007689
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x170002E7 RID: 743
		' (get) Token: 0x060004F9 RID: 1273 RVA: 0x00009492 File Offset: 0x00007692
		' (set) Token: 0x060004FA RID: 1274 RVA: 0x0000949C File Offset: 0x0000769C
		Friend Overridable Property ColumnHeader10 As ColumnHeader

		' Token: 0x170002E8 RID: 744
		' (get) Token: 0x060004FB RID: 1275 RVA: 0x000094A5 File Offset: 0x000076A5
		' (set) Token: 0x060004FC RID: 1276 RVA: 0x000094AF File Offset: 0x000076AF
		Friend Overridable Property ColumnHeader11 As ColumnHeader

		' Token: 0x170002E9 RID: 745
		' (get) Token: 0x060004FD RID: 1277 RVA: 0x000094B8 File Offset: 0x000076B8
		' (set) Token: 0x060004FE RID: 1278 RVA: 0x000094C2 File Offset: 0x000076C2
		Friend Overridable Property ColumnHeader12 As ColumnHeader

		' Token: 0x170002EA RID: 746
		' (get) Token: 0x060004FF RID: 1279 RVA: 0x000094CB File Offset: 0x000076CB
		' (set) Token: 0x06000500 RID: 1280 RVA: 0x000094D5 File Offset: 0x000076D5
		Friend Overridable Property ColumnHeader13 As ColumnHeader

		' Token: 0x170002EB RID: 747
		' (get) Token: 0x06000501 RID: 1281 RVA: 0x000094DE File Offset: 0x000076DE
		' (set) Token: 0x06000502 RID: 1282 RVA: 0x000094E8 File Offset: 0x000076E8
		Friend Overridable Property ColumnHeader14 As ColumnHeader

		' Token: 0x170002EC RID: 748
		' (get) Token: 0x06000503 RID: 1283 RVA: 0x000094F1 File Offset: 0x000076F1
		' (set) Token: 0x06000504 RID: 1284 RVA: 0x000094FB File Offset: 0x000076FB
		Friend Overridable Property ColumnHeader15 As ColumnHeader

		' Token: 0x170002ED RID: 749
		' (get) Token: 0x06000505 RID: 1285 RVA: 0x00009504 File Offset: 0x00007704
		' (set) Token: 0x06000506 RID: 1286 RVA: 0x0000950E File Offset: 0x0000770E
		Friend Overridable Property ColumnHeader16 As ColumnHeader

		' Token: 0x170002EE RID: 750
		' (get) Token: 0x06000507 RID: 1287 RVA: 0x00009517 File Offset: 0x00007717
		' (set) Token: 0x06000508 RID: 1288 RVA: 0x00009521 File Offset: 0x00007721
		Friend Overridable Property ColumnHeader17 As ColumnHeader

		' Token: 0x170002EF RID: 751
		' (get) Token: 0x06000509 RID: 1289 RVA: 0x0000952A File Offset: 0x0000772A
		' (set) Token: 0x0600050A RID: 1290 RVA: 0x00009534 File Offset: 0x00007734
		Friend Overridable Property ColumnHeader18 As ColumnHeader

		' Token: 0x170002F0 RID: 752
		' (get) Token: 0x0600050B RID: 1291 RVA: 0x0000953D File Offset: 0x0000773D
		' (set) Token: 0x0600050C RID: 1292 RVA: 0x00009547 File Offset: 0x00007747
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170002F1 RID: 753
		' (get) Token: 0x0600050D RID: 1293 RVA: 0x00009550 File Offset: 0x00007750
		' (set) Token: 0x0600050E RID: 1294 RVA: 0x0008A53C File Offset: 0x0008873C
		Private _GelButton1 As GelButton
		Friend Overridable Property GelButton1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
				Dim gelButton As GelButton = Me._GelButton1
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton1 = value
				gelButton = Me._GelButton1
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170002F2 RID: 754
		' (get) Token: 0x0600050F RID: 1295 RVA: 0x0000955A File Offset: 0x0000775A
		' (set) Token: 0x06000510 RID: 1296 RVA: 0x0008A580 File Offset: 0x00088780
		Private _GelButton3 As GelButton
		Friend Overridable Property GelButton3 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click
				Dim gelButton As GelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton3 = value
				gelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170002F3 RID: 755
		' (get) Token: 0x06000511 RID: 1297 RVA: 0x00009564 File Offset: 0x00007764
		' (set) Token: 0x06000512 RID: 1298 RVA: 0x0008A5C4 File Offset: 0x000887C4
		Private _RadioButton2 As RadioButton
		Friend Overridable Property RadioButton2 As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._RadioButton2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.RadioButton2_CheckedChanged
				Dim radioButton As RadioButton = Me._RadioButton2
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._RadioButton2 = value
				radioButton = Me._RadioButton2
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170002F4 RID: 756
		' (get) Token: 0x06000513 RID: 1299 RVA: 0x0000956E File Offset: 0x0000776E
		' (set) Token: 0x06000514 RID: 1300 RVA: 0x0008A608 File Offset: 0x00088808
		Private _RadioButton1 As RadioButton
		Friend Overridable Property RadioButton1 As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._RadioButton1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.RadioButton1_CheckedChanged
				Dim radioButton As RadioButton = Me._RadioButton1
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._RadioButton1 = value
				radioButton = Me._RadioButton1
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170002F5 RID: 757
		' (get) Token: 0x06000515 RID: 1301 RVA: 0x00009578 File Offset: 0x00007778
		' (set) Token: 0x06000516 RID: 1302 RVA: 0x0008A64C File Offset: 0x0008884C
		Private _txtNoOfCopies As TextBox
		Friend Overridable Property txtNoOfCopies As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtNoOfCopies
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtNoOfCopies_KeyPress
				Dim textBox As TextBox = Me._txtNoOfCopies
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._txtNoOfCopies = value
				textBox = Me._txtNoOfCopies
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x170002F6 RID: 758
		' (get) Token: 0x06000517 RID: 1303 RVA: 0x00009582 File Offset: 0x00007782
		' (set) Token: 0x06000518 RID: 1304 RVA: 0x0008A690 File Offset: 0x00088890
		Private _CheckBox1 As CheckBox
		Friend Overridable Property CheckBox1 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox1_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox1
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox1 = value
				checkBox = Me._CheckBox1
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170002F7 RID: 759
		' (get) Token: 0x06000519 RID: 1305 RVA: 0x0000958C File Offset: 0x0000778C
		' (set) Token: 0x0600051A RID: 1306 RVA: 0x00009596 File Offset: 0x00007796
		Friend Overridable Property txtCompany As TextBox

		' Token: 0x170002F8 RID: 760
		' (get) Token: 0x0600051B RID: 1307 RVA: 0x0000959F File Offset: 0x0000779F
		' (set) Token: 0x0600051C RID: 1308 RVA: 0x000095A9 File Offset: 0x000077A9
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x170002F9 RID: 761
		' (get) Token: 0x0600051D RID: 1309 RVA: 0x000095B2 File Offset: 0x000077B2
		' (set) Token: 0x0600051E RID: 1310 RVA: 0x0008A6D4 File Offset: 0x000888D4
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox1_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_LostFocus
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.LostFocus, eventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.LostFocus, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170002FA RID: 762
		' (get) Token: 0x0600051F RID: 1311 RVA: 0x000095BC File Offset: 0x000077BC
		' (set) Token: 0x06000520 RID: 1312 RVA: 0x000095C6 File Offset: 0x000077C6
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x170002FB RID: 763
		' (get) Token: 0x06000521 RID: 1313 RVA: 0x000095CF File Offset: 0x000077CF
		' (set) Token: 0x06000522 RID: 1314 RVA: 0x0008A734 File Offset: 0x00088934
		Private _listView1 As ListView
		Friend Overridable Property listView1 As ListView
			<CompilerGenerated()>
			Get
				Return Me._listView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ListView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.LV
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.listView1_MouseDoubleClick
				Dim listView As ListView = Me._listView1
				If listView IsNot Nothing Then
					RemoveHandler listView.KeyDown, keyEventHandler
					RemoveHandler listView.MouseDoubleClick, mouseEventHandler
				End If
				Me._listView1 = value
				listView = Me._listView1
				If listView IsNot Nothing Then
					AddHandler listView.KeyDown, keyEventHandler
					AddHandler listView.MouseDoubleClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x170002FC RID: 764
		' (get) Token: 0x06000523 RID: 1315 RVA: 0x000095D9 File Offset: 0x000077D9
		' (set) Token: 0x06000524 RID: 1316 RVA: 0x000095E3 File Offset: 0x000077E3
		Friend Overridable Property columnHeader1 As ColumnHeader

		' Token: 0x170002FD RID: 765
		' (get) Token: 0x06000525 RID: 1317 RVA: 0x000095EC File Offset: 0x000077EC
		' (set) Token: 0x06000526 RID: 1318 RVA: 0x000095F6 File Offset: 0x000077F6
		Friend Overridable Property columnHeader3 As ColumnHeader

		' Token: 0x170002FE RID: 766
		' (get) Token: 0x06000527 RID: 1319 RVA: 0x000095FF File Offset: 0x000077FF
		' (set) Token: 0x06000528 RID: 1320 RVA: 0x00009609 File Offset: 0x00007809
		Friend Overridable Property Category As ColumnHeader

		' Token: 0x170002FF RID: 767
		' (get) Token: 0x06000529 RID: 1321 RVA: 0x00009612 File Offset: 0x00007812
		' (set) Token: 0x0600052A RID: 1322 RVA: 0x0000961C File Offset: 0x0000781C
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x17000300 RID: 768
		' (get) Token: 0x0600052B RID: 1323 RVA: 0x00009625 File Offset: 0x00007825
		' (set) Token: 0x0600052C RID: 1324 RVA: 0x0000962F File Offset: 0x0000782F
		Friend Overridable Property ColumnHeader4 As ColumnHeader

		' Token: 0x17000301 RID: 769
		' (get) Token: 0x0600052D RID: 1325 RVA: 0x00009638 File Offset: 0x00007838
		' (set) Token: 0x0600052E RID: 1326 RVA: 0x00009642 File Offset: 0x00007842
		Friend Overridable Property ColumnHeader5 As ColumnHeader

		' Token: 0x17000302 RID: 770
		' (get) Token: 0x0600052F RID: 1327 RVA: 0x0000964B File Offset: 0x0000784B
		' (set) Token: 0x06000530 RID: 1328 RVA: 0x00009655 File Offset: 0x00007855
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x17000303 RID: 771
		' (get) Token: 0x06000531 RID: 1329 RVA: 0x0000965E File Offset: 0x0000785E
		' (set) Token: 0x06000532 RID: 1330 RVA: 0x0008A794 File Offset: 0x00088994
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

		' Token: 0x17000304 RID: 772
		' (get) Token: 0x06000533 RID: 1331 RVA: 0x00009668 File Offset: 0x00007868
		' (set) Token: 0x06000534 RID: 1332 RVA: 0x00009672 File Offset: 0x00007872
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17000305 RID: 773
		' (get) Token: 0x06000535 RID: 1333 RVA: 0x0000967B File Offset: 0x0000787B
		' (set) Token: 0x06000536 RID: 1334 RVA: 0x0008A7D8 File Offset: 0x000889D8
		Private _btnAddCustomer As GelButton
		Friend Overridable Property btnAddCustomer As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnAddCustomer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnAddCustomer_Click
				Dim gelButton As GelButton = Me._btnAddCustomer
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnAddCustomer = value
				gelButton = Me._btnAddCustomer
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000306 RID: 774
		' (get) Token: 0x06000537 RID: 1335 RVA: 0x00009685 File Offset: 0x00007885
		' (set) Token: 0x06000538 RID: 1336 RVA: 0x0000968F File Offset: 0x0000788F
		Friend Overridable Property Label1 As Label

		' Token: 0x17000307 RID: 775
		' (get) Token: 0x06000539 RID: 1337 RVA: 0x00009698 File Offset: 0x00007898
		' (set) Token: 0x0600053A RID: 1338 RVA: 0x0008A81C File Offset: 0x00088A1C
		Private _cmbLayouts As ComboBox
		Friend Overridable Property cmbLayouts As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbLayouts
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbLayouts_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbLayouts
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbLayouts = value
				comboBox = Me._cmbLayouts
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000308 RID: 776
		' (get) Token: 0x0600053B RID: 1339 RVA: 0x000096A2 File Offset: 0x000078A2
		' (set) Token: 0x0600053C RID: 1340 RVA: 0x0008A860 File Offset: 0x00088A60
		Private _txtSearch As TextBox
		Friend Overridable Property txtSearch As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSearch
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSearch_KeyDown
				Dim textBox As TextBox = Me._txtSearch
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtSearch = value
				textBox = Me._txtSearch
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000309 RID: 777
		' (get) Token: 0x0600053D RID: 1341 RVA: 0x000096AC File Offset: 0x000078AC
		' (set) Token: 0x0600053E RID: 1342 RVA: 0x0008A8A4 File Offset: 0x00088AA4
		Private _txtPInv As TextBox
		Friend Overridable Property txtPInv As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPInv
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPInv_KeyUp
				Dim textBox As TextBox = Me._txtPInv
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyUp, keyEventHandler
				End If
				Me._txtPInv = value
				textBox = Me._txtPInv
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyUp, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700030A RID: 778
		' (get) Token: 0x0600053F RID: 1343 RVA: 0x000096B6 File Offset: 0x000078B6
		' (set) Token: 0x06000540 RID: 1344 RVA: 0x000096C0 File Offset: 0x000078C0
		Friend Overridable Property ComboBox1 As ComboBox

		' Token: 0x1700030B RID: 779
		' (get) Token: 0x06000541 RID: 1345 RVA: 0x000096C9 File Offset: 0x000078C9
		' (set) Token: 0x06000542 RID: 1346 RVA: 0x0008A8E8 File Offset: 0x00088AE8
		Private _txtBCode As TextBox
		Friend Overridable Property txtBCode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBCode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtBCode_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBCode_KeyUp
				Dim textBox As TextBox = Me._txtBCode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyUp, keyEventHandler
				End If
				Me._txtBCode = value
				textBox = Me._txtBCode
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyUp, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700030C RID: 780
		' (get) Token: 0x06000543 RID: 1347 RVA: 0x000096D3 File Offset: 0x000078D3
		' (set) Token: 0x06000544 RID: 1348 RVA: 0x0008A948 File Offset: 0x00088B48
		Private _txtPCode As TextBox
		Friend Overridable Property txtPCode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPCode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPCode_KeyUp
				Dim textBox As TextBox = Me._txtPCode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyUp, keyEventHandler
				End If
				Me._txtPCode = value
				textBox = Me._txtPCode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyUp, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700030D RID: 781
		' (get) Token: 0x06000545 RID: 1349 RVA: 0x000096DD File Offset: 0x000078DD
		' (set) Token: 0x06000546 RID: 1350 RVA: 0x000096E7 File Offset: 0x000078E7
		Friend Overridable Property Label2 As Label

		' Token: 0x1700030E RID: 782
		' (get) Token: 0x06000547 RID: 1351 RVA: 0x000096F0 File Offset: 0x000078F0
		' (set) Token: 0x06000548 RID: 1352 RVA: 0x000096FA File Offset: 0x000078FA
		Friend Overridable Property Label3 As Label

		' Token: 0x1700030F RID: 783
		' (get) Token: 0x06000549 RID: 1353 RVA: 0x00009703 File Offset: 0x00007903
		' (set) Token: 0x0600054A RID: 1354 RVA: 0x0008A98C File Offset: 0x00088B8C
		Private _chkSelectAll As CheckBox
		Friend Overridable Property chkSelectAll As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chkSelectAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkSelectAll_CheckedChanged
				Dim checkBox As CheckBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chkSelectAll = value
				checkBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000310 RID: 784
		' (get) Token: 0x0600054B RID: 1355 RVA: 0x0000970D File Offset: 0x0000790D
		' (set) Token: 0x0600054C RID: 1356 RVA: 0x00009717 File Offset: 0x00007917
		Friend Overridable Property PrintDialog1 As PrintDialog

		' Token: 0x17000311 RID: 785
		' (get) Token: 0x0600054D RID: 1357 RVA: 0x00009720 File Offset: 0x00007920
		' (set) Token: 0x0600054E RID: 1358 RVA: 0x0008A9D0 File Offset: 0x00088BD0
		Private _PrintDocument1 As PrintDocument
		Friend Overridable Property PrintDocument1 As PrintDocument
			<CompilerGenerated()>
			Get
				Return Me._PrintDocument1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As PrintDocument)
				Dim printPageEventHandler As PrintPageEventHandler = AddressOf Me.PrintDocument1_PrintPage
				Dim printDocument As PrintDocument = Me._PrintDocument1
				If printDocument IsNot Nothing Then
					RemoveHandler printDocument.PrintPage, printPageEventHandler
				End If
				Me._PrintDocument1 = value
				printDocument = Me._PrintDocument1
				If printDocument IsNot Nothing Then
					AddHandler printDocument.PrintPage, printPageEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000312 RID: 786
		' (get) Token: 0x0600054F RID: 1359 RVA: 0x0000972A File Offset: 0x0000792A
		' (set) Token: 0x06000550 RID: 1360 RVA: 0x00009734 File Offset: 0x00007934
		Friend Overridable Property PrintPreviewDialog1 As PrintPreviewDialog

		' Token: 0x17000313 RID: 787
		' (get) Token: 0x06000551 RID: 1361 RVA: 0x0000973D File Offset: 0x0000793D
		' (set) Token: 0x06000552 RID: 1362 RVA: 0x00009747 File Offset: 0x00007947
		Friend Overridable Property pnlCheque As Panel

		' Token: 0x17000314 RID: 788
		' (get) Token: 0x06000553 RID: 1363 RVA: 0x00009750 File Offset: 0x00007950
		' (set) Token: 0x06000554 RID: 1364 RVA: 0x0000975A File Offset: 0x0000795A
		Friend Overridable Property lblHidden As Label

		' Token: 0x17000315 RID: 789
		' (get) Token: 0x06000555 RID: 1365 RVA: 0x00009763 File Offset: 0x00007963
		' (set) Token: 0x06000556 RID: 1366 RVA: 0x0000976D File Offset: 0x0000796D
		Friend Overridable Property gbxChequeSize As GroupBox

		' Token: 0x17000316 RID: 790
		' (get) Token: 0x06000557 RID: 1367 RVA: 0x00009776 File Offset: 0x00007976
		' (set) Token: 0x06000558 RID: 1368 RVA: 0x00009780 File Offset: 0x00007980
		Friend Overridable Property btnBgColor_Layout As Button

		' Token: 0x17000317 RID: 791
		' (get) Token: 0x06000559 RID: 1369 RVA: 0x00009789 File Offset: 0x00007989
		' (set) Token: 0x0600055A RID: 1370 RVA: 0x00009793 File Offset: 0x00007993
		Friend Overridable Property lnklblSetDefault As LinkLabel

		' Token: 0x17000318 RID: 792
		' (get) Token: 0x0600055B RID: 1371 RVA: 0x0000979C File Offset: 0x0000799C
		' (set) Token: 0x0600055C RID: 1372 RVA: 0x000097A6 File Offset: 0x000079A6
		Friend Overridable Property lblChequeHeight As Label

		' Token: 0x17000319 RID: 793
		' (get) Token: 0x0600055D RID: 1373 RVA: 0x000097AF File Offset: 0x000079AF
		' (set) Token: 0x0600055E RID: 1374 RVA: 0x000097B9 File Offset: 0x000079B9
		Friend Overridable Property lblChequeWidth As Label

		' Token: 0x1700031A RID: 794
		' (get) Token: 0x0600055F RID: 1375 RVA: 0x000097C2 File Offset: 0x000079C2
		' (set) Token: 0x06000560 RID: 1376 RVA: 0x0008AA14 File Offset: 0x00088C14
		Private _nudChequeLeafWidth As NumericUpDown
		Friend Overridable Property nudChequeLeafWidth As NumericUpDown
			<CompilerGenerated()>
			Get
				Return Me._nudChequeLeafWidth
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As NumericUpDown)
				Dim eventHandler As EventHandler = AddressOf Me.nudChequeLeafWidth_ValueChanged
				Dim numericUpDown As NumericUpDown = Me._nudChequeLeafWidth
				If numericUpDown IsNot Nothing Then
					RemoveHandler numericUpDown.ValueChanged, eventHandler
				End If
				Me._nudChequeLeafWidth = value
				numericUpDown = Me._nudChequeLeafWidth
				If numericUpDown IsNot Nothing Then
					AddHandler numericUpDown.ValueChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700031B RID: 795
		' (get) Token: 0x06000561 RID: 1377 RVA: 0x000097CC File Offset: 0x000079CC
		' (set) Token: 0x06000562 RID: 1378 RVA: 0x0008AA58 File Offset: 0x00088C58
		Private _nudChequeHeight As NumericUpDown
		Friend Overridable Property nudChequeHeight As NumericUpDown
			<CompilerGenerated()>
			Get
				Return Me._nudChequeHeight
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As NumericUpDown)
				Dim eventHandler As EventHandler = AddressOf Me.nudChequeHeight_ValueChanged
				Dim numericUpDown As NumericUpDown = Me._nudChequeHeight
				If numericUpDown IsNot Nothing Then
					RemoveHandler numericUpDown.ValueChanged, eventHandler
				End If
				Me._nudChequeHeight = value
				numericUpDown = Me._nudChequeHeight
				If numericUpDown IsNot Nothing Then
					AddHandler numericUpDown.ValueChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700031C RID: 796
		' (get) Token: 0x06000563 RID: 1379 RVA: 0x000097D6 File Offset: 0x000079D6
		' (set) Token: 0x06000564 RID: 1380 RVA: 0x000097E0 File Offset: 0x000079E0
		Friend Overridable Property txtLayoutName As TextBox

		' Token: 0x1700031D RID: 797
		' (get) Token: 0x06000565 RID: 1381 RVA: 0x000097E9 File Offset: 0x000079E9
		' (set) Token: 0x06000566 RID: 1382 RVA: 0x000097F3 File Offset: 0x000079F3
		Friend Overridable Property PageSetupDialog1 As PageSetupDialog

		' Token: 0x1700031E RID: 798
		' (get) Token: 0x06000567 RID: 1383 RVA: 0x000097FC File Offset: 0x000079FC
		' (set) Token: 0x06000568 RID: 1384 RVA: 0x00009806 File Offset: 0x00007A06
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x1700031F RID: 799
		' (get) Token: 0x06000569 RID: 1385 RVA: 0x0000980F File Offset: 0x00007A0F
		' (set) Token: 0x0600056A RID: 1386 RVA: 0x00009819 File Offset: 0x00007A19
		Friend Overridable Property lblHiddenImage As Label

		' Token: 0x17000320 RID: 800
		' (get) Token: 0x0600056B RID: 1387 RVA: 0x00009822 File Offset: 0x00007A22
		' (set) Token: 0x0600056C RID: 1388 RVA: 0x0000982C File Offset: 0x00007A2C
		Private Property number As Integer

		' Token: 0x17000321 RID: 801
		' (get) Token: 0x0600056D RID: 1389 RVA: 0x00009835 File Offset: 0x00007A35
		' (set) Token: 0x0600056E RID: 1390 RVA: 0x0000983F File Offset: 0x00007A3F
		Private Property numberPb As Integer

		' Token: 0x0600056F RID: 1391 RVA: 0x0008AA9C File Offset: 0x00088C9C
		Public Sub GetData()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 order by Productname", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add("1")
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06000570 RID: 1392 RVA: 0x0008AE18 File Offset: 0x00089018
		Public Sub SearchbyPCode()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and ProductCode like N'" + Me.txtPCode.Text + "%' order by Productname", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add("1")
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06000571 RID: 1393 RVA: 0x0008B1A8 File Offset: 0x000893A8
		Public Sub SearchbyBCode()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Temp_Stock.Barcode like N'" + Me.txtBCode.Text + "%' ", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add("1")
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06000572 RID: 1394 RVA: 0x0008B538 File Offset: 0x00089738
		Public Sub GetDataPINV()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Stock_Product.Category),RTRIM(Stock_Product.Barcode),Temp_Stock.Qty, Stock_Product.qty, RTRIM(Product.PartNo),RTRIM(HSNCode),(Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice),(Stock_Product.Batch),(Stock_Product.Mfgdate),(Stock_Product.Expdate),(Stock_Product.Size),(Stock_Product.Color),((Stock_Product.CGSTPer)+(Stock_Product.SGSTPer)+(Stock_Product.IGSTPer)),RTRIM(Stock.InvoiceNo),QrBarcode from Product,Stock,Stock_Product,Temp_Stock where Stock.St_ID=Stock_Product.StockID and Product.PID=Stock_Product.ProductID and Temp_Stock.Barcode=Stock_Product.Barcode and InvoiceNo like N'" + Me.txtPInv.Text + "%' order by ProductCode", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(5)))))
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06000573 RID: 1395 RVA: 0x0008B8DC File Offset: 0x00089ADC
		Public Sub Reset()
			Me.ComboBox1.SelectedIndex = -1
			Me.cmbLayouts.SelectedIndex = 0
			Me.txtSearch.Text = ""
			Me.txtNoOfCopies.Text = Conversions.ToString(1)
			Me.GetData()
			Me.chkSelectAll.Checked = True
			Me.txtPCode.Text = ""
			Me.txtBCode.Text = ""
			Me.txtPInv.Text = ""
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.Checked = False
			Me.RadioButton1.Checked = True
		End Sub

		' Token: 0x06000574 RID: 1396 RVA: 0x0008B998 File Offset: 0x00089B98
		Public Sub FillCompany()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Select RTRIM(CompanyName) from Company"
			ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			If flag Then
				Me.txtCompany.Text = ModCommonClasses.rdr.GetString(0)
			End If
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x06000575 RID: 1397 RVA: 0x0008BA1C File Offset: 0x00089C1C
		Private Sub frmBarcodeLabelPrinting_Load(sender As Object, e As EventArgs)
			Me.connString = ModCS.ReadCS()
			Dim chequeLayoutInfo As ChequeLayoutInfo = New ChequeLayoutInfo()
			Me.BindLayouts()
			Me.FillCompany()
			Dim flag As Boolean = Me.txtPCode.Text.Length > 0
			If flag Then
				Me.SearchbyPCode()
			Else
				Dim flag2 As Boolean = Me.txtBCode.Text.Length > 0
				If flag2 Then
					Me.SearchbyBCode()
				Else
					Dim flag3 As Boolean = Me.txtPInv.Text.Length > 0
					If flag3 Then
						Me.GetDataPINV()
					Else
						Me.txtPCode.Text = ""
						Me.txtBCode.Text = ""
						Me.txtPInv.Text = ""
					End If
				End If
			End If
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.Checked = False
			Me.RadioButton1.Checked = True
			Me.RadioButton2.Checked = False
			Me.RadioButton1.TabStop = False
			Me.RadioButton2.TabStop = False
			Me.ComboBox1.SelectedIndex = -1
			Me.txtSearch.Text = ""
			Me.Convert_Language()
		End Sub

		' Token: 0x06000576 RID: 1398 RVA: 0x0008BB54 File Offset: 0x00089D54
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
						Me.UpdateAllHeaders(Me)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x06000577 RID: 1399 RVA: 0x0008BCCC File Offset: 0x00089ECC
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
			If flag Then
				Dim text As String = ctrl.Text
				Dim flag2 As Boolean = translations.ContainsKey(text)
				If flag2 Then
					ctrl.Text = translations(text)
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

		' Token: 0x06000578 RID: 1400 RVA: 0x0008BD88 File Offset: 0x00089F88
		Private Sub UpdateAllHeaders(container As Control)
			Try
				For Each obj As Object In container.Controls
					Dim control As Control = CType(obj, Control)
					Dim flag As Boolean = TypeOf control Is DataGridView
					If flag Then
						Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
					Else
						Dim flag2 As Boolean = TypeOf control Is ListView
						If flag2 Then
							Me.UpdateListViewHeaders(CType(control, ListView))
						Else
							Dim flag3 As Boolean = TypeOf control Is TabControl
							If flag3 Then
								Me.UpdateTabControlHeaders(CType(control, TabControl))
							End If
						End If
					End If
					Dim hasChildren As Boolean = control.HasChildren
					If hasChildren Then
						Me.UpdateAllHeaders(control)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06000579 RID: 1401 RVA: 0x00086F78 File Offset: 0x00085178
		Private Sub UpdateListViewHeaders(listView As ListView)
			Try
				For Each obj As Object In listView.Columns
					Dim columnHeader As ColumnHeader = CType(obj, ColumnHeader)
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(columnHeader.Text)
					If flag Then
						columnHeader.Text = GlobalVariables.translations(columnHeader.Text)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600057A RID: 1402 RVA: 0x00087000 File Offset: 0x00085200
		Private Sub UpdateTabControlHeaders(tabControl As TabControl)
			Try
				For Each obj As Object In tabControl.TabPages
					Dim tabPage As TabPage = CType(obj, TabPage)
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(tabPage.Text)
					If flag Then
						tabPage.Text = GlobalVariables.translations(tabPage.Text)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600057B RID: 1403 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600057C RID: 1404 RVA: 0x0008BE54 File Offset: 0x0008A054
		Private Sub txtNoOfCopies_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = ((e.KeyChar < "0"c) Or (e.KeyChar > "9"c)) And (e.KeyChar <> vbBack)
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600057D RID: 1405 RVA: 0x00009848 File Offset: 0x00007A48
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600057E RID: 1406 RVA: 0x0008BE94 File Offset: 0x0008A094
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkSelectAll.Checked
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim num As Integer = 0
				Dim num2 As Integer = Me.listView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag3 As Boolean = num4 > num5
					If flag3 Then
						Exit While
					End If
					Me.listView1.Items(num3).Checked = True
					num3 += 1
				End While
			Else
				flag = Not Me.chkSelectAll.Checked
				Dim flag4 As Boolean = flag
				If flag4 Then
					Dim num6 As Integer = 0
					Dim num7 As Integer = Me.listView1.Items.Count - 1
					Dim num8 As Integer = num6
					While True
						Dim num9 As Integer = num8
						Dim num10 As Integer = num7
						Dim flag5 As Boolean = num9 > num10
						If flag5 Then
							Exit While
						End If
						Me.listView1.Items(num8).Checked = False
						num8 += 1
					End While
				End If
			End If
		End Sub

		' Token: 0x0600057F RID: 1407 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmBarcodeLabelPrinting_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06000580 RID: 1408 RVA: 0x00009864 File Offset: 0x00007A64
		Private Sub txtBCode_TextChanged(sender As Object, e As EventArgs)
			Me.SearchbyBCode()
		End Sub

		' Token: 0x06000581 RID: 1409 RVA: 0x0008BF80 File Offset: 0x0008A180
		Private Sub LV(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = Me.listView1.SelectedItems.Count = 0
			If Not flag Then
				Dim keyCode As Keys = e.KeyCode
				If keyCode = Keys.F2 Then
					e.Handled = True
					Me.BeginEditListItem(Me.listView1.SelectedItems(0), 2)
				End If
			End If
		End Sub

		' Token: 0x06000582 RID: 1410 RVA: 0x0008BFDC File Offset: 0x0008A1DC
		Private Sub listView1_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Me.CurrentItem = Me.listView1.GetItemAt(e.X, e.Y)
			Dim flag As Boolean = Me.CurrentItem Is Nothing
			If Not flag Then
				Me.CurrentSB = Me.CurrentItem.GetSubItemAt(e.X, e.Y)
				Dim num As Integer = Me.CurrentItem.SubItems.IndexOf(Me.CurrentSB)
				If num = 5 Then
					Dim flag2 As Boolean = num = 0
					If flag2 Then
						Me.CurrentItem.BeginEdit()
					Else
						Dim num2 As Integer = Me.CurrentSB.Bounds.Left + 2
						Dim width As Integer = Me.CurrentSB.Bounds.Width
						Dim textBox As TextBox = Me.TextBox1
						textBox.SetBounds(num2 + Me.listView1.Left, Me.CurrentSB.Bounds.Top + Me.listView1.Top, width, Me.CurrentSB.Bounds.Height)
						textBox.Text = Me.CurrentSB.Text
						textBox.Show()
						textBox.Focus()
					End If
				End If
			End If
		End Sub

		' Token: 0x06000583 RID: 1411 RVA: 0x0008C120 File Offset: 0x0008A320
		Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			If keyChar <> vbCr Then
				If keyChar = ChrW(27) Then
					Me.bCancelEdit = True
					e.Handled = True
					Me.TextBox1.Hide()
				End If
			Else
				Me.bCancelEdit = False
				e.Handled = True
				Me.TextBox1.Hide()
			End If
		End Sub

		' Token: 0x06000584 RID: 1412 RVA: 0x0008C184 File Offset: 0x0008A384
		Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs)
			Me.TextBox1.Hide()
			Dim flag As Boolean = Not Me.bCancelEdit
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.TextBox1.Text.Trim(), "", False) <> 0
				If flag2 Then
					Dim flag3 As Boolean = Not Versioned.IsNumeric(Me.TextBox1.Text)
					If flag3 Then
						Interaction.MsgBox("Please enter a numeric value in this field.", MsgBoxStyle.Exclamation, Nothing)
						Return
					End If
					Dim flag4 As Boolean = Conversion.Val(Me.TextBox1.Text) = 0.0
					If flag4 Then
						Interaction.MsgBox("Not allowed to enter 0 value in this field.", MsgBoxStyle.Exclamation, Nothing)
						Return
					End If
					Me.CurrentSB.Text = Conversions.ToInteger(Me.TextBox1.Text).ToString()
				End If
			Else
				Me.bCancelEdit = False
			End If
			Me.listView1.Focus()
		End Sub

		' Token: 0x06000585 RID: 1413 RVA: 0x0008C268 File Offset: 0x0008A468
		Private Sub BeginEditListItem(iTm As ListViewItem, SubItemIndex As Integer)
			Dim location As Point = iTm.SubItems(SubItemIndex).Bounds.Location
			Dim e As MouseEventArgs = New MouseEventArgs(MouseButtons.Left, 2, location.X, location.Y, 0)
			Me.listView1_MouseDoubleClick(Me.listView1, e)
		End Sub

		' Token: 0x06000586 RID: 1414 RVA: 0x0008C2BC File Offset: 0x0008A4BC
		Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox1.Checked
			If checked Then
				Me.txtNoOfCopies.Focus()
			End If
		End Sub

		' Token: 0x06000587 RID: 1415 RVA: 0x0008C2E8 File Offset: 0x0008A4E8
		Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.RadioButton1.Checked
			If checked Then
				Me.RadioButton2.Checked = False
			Else
				Dim flag As Boolean = Not Me.RadioButton1.Checked
				If flag Then
					Me.RadioButton2.Checked = True
				End If
			End If
		End Sub

		' Token: 0x06000588 RID: 1416 RVA: 0x0008C2E8 File Offset: 0x0008A4E8
		Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.RadioButton1.Checked
			If checked Then
				Me.RadioButton2.Checked = False
			Else
				Dim flag As Boolean = Not Me.RadioButton1.Checked
				If flag Then
					Me.RadioButton2.Checked = True
				End If
			End If
		End Sub

		' Token: 0x06000589 RID: 1417 RVA: 0x0000986E File Offset: 0x00007A6E
		Private Sub txtPCode_KeyUp(sender As Object, e As KeyEventArgs)
			Me.SearchbyPCode()
		End Sub

		' Token: 0x0600058A RID: 1418 RVA: 0x00009864 File Offset: 0x00007A64
		Private Sub txtBCode_KeyUp(sender As Object, e As KeyEventArgs)
			Me.SearchbyBCode()
		End Sub

		' Token: 0x0600058B RID: 1419 RVA: 0x00009878 File Offset: 0x00007A78
		Private Sub txtPInv_KeyUp(sender As Object, e As KeyEventArgs)
			Me.GetDataPINV()
		End Sub

		' Token: 0x0600058C RID: 1420 RVA: 0x00009882 File Offset: 0x00007A82
		Private Sub frmBarcodeLabelPrinting_Closed(sender As Object, e As EventArgs)
			Me.txtPCode.Text = ""
			Me.txtBCode.Text = ""
			Me.txtPInv.Text = ""
		End Sub

		' Token: 0x0600058D RID: 1421 RVA: 0x0008C338 File Offset: 0x0008A538
		Public Sub Print()
			Dim flag As Boolean = Me.listView1.Items.Count = 0
			If flag Then
				MessageBox.Show("Barcode list not found", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim flag2 As Boolean = Me.listView1.CheckedItems.Count = 0
				If flag2 Then
					MessageBox.Show("Please select Barcode list", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag3 As Boolean = Me.cmbLayouts.SelectedIndex = -1
					If flag3 Then
						MessageBox.Show("Please select Barcode Template", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Try
							Dim dataTable As DataTable = New DataTable()
							Dim dataTable2 As DataTable = dataTable
							dataTable2.Columns.Add("PCode")
							dataTable2.Columns.Add("ProductName")
							dataTable2.Columns.Add("Category")
							dataTable2.Columns.Add("Barcode")
							dataTable2.Columns.Add("AvlQty")
							dataTable2.Columns.Add("NoCopy")
							dataTable2.Columns.Add("PartNo")
							dataTable2.Columns.Add("HSNC")
							dataTable2.Columns.Add("MRP")
							dataTable2.Columns.Add("SalePrice")
							dataTable2.Columns.Add("WholesalePrice")
							dataTable2.Columns.Add("Batch")
							dataTable2.Columns.Add("Mfg")
							dataTable2.Columns.Add("Exp")
							dataTable2.Columns.Add("Size")
							dataTable2.Columns.Add("Colour")
							dataTable2.Columns.Add("GST")
							dataTable2.Columns.Add("PurInv")
							dataTable2.Columns.Add("QrBarcode")
							Dim dictionary As Dictionary(Of String, List(Of DataTable)) = New Dictionary(Of String, List(Of DataTable))()
							Dim text As String = ""
							Dim list As List(Of Integer) = New List(Of Integer)()
							Dim list2 As List(Of DataTable) = New List(Of DataTable)()
							Dim num As Integer
							Try
								For Each obj As Object In Me.listView1.CheckedItems
									Dim listViewItem As ListViewItem = CType(obj, ListViewItem)
									Me.MyDS = Me.printCustomBarcode("'" + listViewItem.SubItems(3).Text + "'")
									Me.dt1 = Me.MyDS.Tables(0).Clone()
									Dim checked As Boolean = Me.CheckBox1.Checked
									If checked Then
										num = Integer.Parse(Conversions.ToString(Conversion.Val(Me.txtNoOfCopies.Text)))
										text = "A"
									Else
										text = "I"
										num = Integer.Parse(Conversions.ToString(Conversion.Val(listViewItem.SubItems(5).Text)))
									End If
									Dim num2 As Integer = num - 1
									For i As Integer = 0 To num2
										Dim text2 As String = listViewItem.SubItems(0).Text
										Dim text3 As String = listViewItem.SubItems(1).Text
										Dim text4 As String = listViewItem.SubItems(2).Text
										Dim text5 As String = listViewItem.SubItems(3).Text
										Dim text6 As String = listViewItem.SubItems(4).Text
										Dim text7 As String = listViewItem.SubItems(5).Text
										Dim text8 As String = listViewItem.SubItems(6).Text
										Dim text9 As String = listViewItem.SubItems(7).Text
										Dim text10 As String = listViewItem.SubItems(8).Text
										Dim text11 As String = listViewItem.SubItems(9).Text
										Dim text12 As String = listViewItem.SubItems(10).Text
										Dim text13 As String = listViewItem.SubItems(11).Text
										Dim text14 As String = listViewItem.SubItems(12).Text
										Dim text15 As String = listViewItem.SubItems(13).Text
										Dim text16 As String = listViewItem.SubItems(14).Text
										Dim text17 As String = listViewItem.SubItems(15).Text
										Dim text18 As String = listViewItem.SubItems(16).Text
										Dim text19 As String = listViewItem.SubItems(17).Text
										dataTable.Rows.Add(New Object() { text2, listViewItem.SubItems(1).Text, listViewItem.SubItems(2).Text, listViewItem.SubItems(3).Text, listViewItem.SubItems(4).Text, listViewItem.SubItems(5).Text, listViewItem.SubItems(6).Text, listViewItem.SubItems(7).Text, listViewItem.SubItems(8).Text, listViewItem.SubItems(9).Text, listViewItem.SubItems(10).Text, listViewItem.SubItems(11).Text, listViewItem.SubItems(12).Text, listViewItem.SubItems(13).Text, listViewItem.SubItems(14).Text, listViewItem.SubItems(15).Text, listViewItem.SubItems(16).Text, listViewItem.SubItems(17).Text })
									Next
									list.Add(num - 1)
									list2.Add(Me.MyDS.Tables(0))
								Next
							Finally
								Dim enumerator As IEnumerator
								If TypeOf enumerator Is IDisposable Then
									TryCast(enumerator, IDisposable).Dispose()
								End If
							End Try
							Dim checked2 As Boolean = Me.CheckBox1.Checked
							If checked2 Then
								num = Integer.Parse(Conversions.ToString(Conversion.Val(Me.txtNoOfCopies.Text)))
							End If
							Dim flag4 As Boolean = Operators.CompareString(text, "A", False) = 0
							If flag4 Then
								Dim num3 As Integer = num - 1
								For j As Integer = 0 To num3
									Try
										For Each dataTable3 As DataTable In list2
											Try
												For Each obj2 As Object In dataTable3.Rows
													Dim dataRow As DataRow = CType(obj2, DataRow)
													Me.dt1.ImportRow(dataRow)
												Next
											Finally
												Dim enumerator3 As IEnumerator
												If TypeOf enumerator3 Is IDisposable Then
													TryCast(enumerator3, IDisposable).Dispose()
												End If
											End Try
										Next
									Finally
										Dim enumerator2 As List(Of DataTable).Enumerator
										CType(enumerator2, IDisposable).Dispose()
									End Try
								Next
							Else
								Dim flag5 As Boolean = Operators.CompareString(text, "I", False) = 0
								If flag5 Then
									Dim count As Integer = list2.Count
									Dim num4 As Integer = 0
									Try
										For Each num5 As Integer In list
											Dim flag6 As Boolean = num5 = 0
											If flag6 Then
												Dim dataTable4 As DataTable = list2(num4)
												Dim flag7 As Boolean = dataTable4.Rows.Count > 0
												If flag7 Then
													Try
														For Each obj3 As Object In dataTable4.Rows
															Dim dataRow2 As DataRow = CType(obj3, DataRow)
															Me.dt1.ImportRow(dataRow2)
														Next
													Finally
														Dim enumerator5 As IEnumerator
														If TypeOf enumerator5 Is IDisposable Then
															TryCast(enumerator5, IDisposable).Dispose()
														End If
													End Try
												End If
											Else
												Dim num6 As Integer = num5
												For k As Integer = 0 To num6
													Dim dataTable5 As DataTable = list2(num4)
													Try
														For Each obj4 As Object In dataTable5.Rows
															Dim dataRow3 As DataRow = CType(obj4, DataRow)
															Me.dt1.ImportRow(dataRow3)
														Next
													Finally
														Dim enumerator6 As IEnumerator
														If TypeOf enumerator6 Is IDisposable Then
															TryCast(enumerator6, IDisposable).Dispose()
														End If
													End Try
												Next
											End If
											num4 += 1
										Next
									Finally
										Dim enumerator4 As List(Of Integer).Enumerator
										CType(enumerator4, IDisposable).Dispose()
									End Try
								End If
							End If
							Me.CustomPrint1()
							Me.Reset()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x0600058E RID: 1422 RVA: 0x0008CD48 File Offset: 0x0008AF48
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 70, .Height = 70 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x0600058F RID: 1423 RVA: 0x0008CDC8 File Offset: 0x0008AFC8
		Public Sub PrintQRBarcode()
			Dim dataSet As DataSet = New DataSet()
			Dim flag As Boolean = Me.listView1.Items.Count = 0
			If flag Then
				MessageBox.Show("Barcode list not found", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim flag2 As Boolean = Me.listView1.CheckedItems.Count = 0
				If flag2 Then
					MessageBox.Show("Please select Barcode list", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag3 As Boolean = Me.cmbLayouts.SelectedIndex = -1
					If flag3 Then
						MessageBox.Show("Please select Barcode Template", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Try
							Try
								For Each obj As Object In Me.listView1.CheckedItems
									Dim listViewItem As ListViewItem = CType(obj, ListViewItem)
									Dim checked As Boolean = Me.CheckBox1.Checked
									Dim num As Integer
									If checked Then
										num = Integer.Parse(Conversions.ToString(Conversion.Val(Me.txtNoOfCopies.Text))) - 1
									Else
										num = Integer.Parse(Conversions.ToString(Conversion.Val(listViewItem.SubItems(5).Text))) - 1
									End If
									Dim num2 As Integer = num
									For i As Integer = 0 To num2
										dataSet = Me.printCustomBarcode(listViewItem.SubItems(3).Text)
									Next
								Next
							Finally
								Dim enumerator As IEnumerator
								If TypeOf enumerator Is IDisposable Then
									TryCast(enumerator, IDisposable).Dispose()
								End If
							End Try
							Dim reportDocument As ReportDocument = New ReportDocument()
							reportDocument = New BarcodeCustomise1()
							reportDocument.SetDataSource(dataSet)
							reportDocument.SetParameterValue("P1", Me.txtCompany.Text)
							MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
							MyProject.Forms.frmReport.ShowDialog()
							MyProject.Forms.frmReport.Dispose()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x06000590 RID: 1424 RVA: 0x0008D000 File Offset: 0x0008B200
		Private Function printCustomBarcode(barcode As String) As DataSet
			Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
			Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
			Dim sqlCommand As SqlCommand = New SqlCommand()
			Dim sqlCommand2 As SqlCommand = New SqlCommand()
			Dim dataSet As DataSet = New DataSet()
			Dim dataSet2 As DataSet = New DataSet()
			Try
				Dim text As String = "Select ProductCode,ProductName,(Category),Temp_Stock.Barcode,Temp_Stock.Qty,(PartNo),(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),(Product.CGST),(Product.SGST),QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and Temp_Stock.barcode in(" + barcode + ")"
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = ModCommonClasses.con
				sqlCommand.CommandText = text
				sqlCommand.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				ModCommonClasses.con.Open()
				sqlDataAdapter.Fill(dataSet, "DataTable2")
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Return dataSet
		End Function

		' Token: 0x06000591 RID: 1425 RVA: 0x0008D0E8 File Offset: 0x0008B2E8
		Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.ComboBox1.SelectedIndex = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and ProductName like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 1
				If flag2 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and Category like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 2
				If flag3 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and Temp_Stock.Barcode like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 3
				If flag4 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and PartNo like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag5 As Boolean = Me.ComboBox1.SelectedIndex = 4
				If flag5 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and HSNCode like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag6 As Boolean = Me.ComboBox1.SelectedIndex = 5
				If flag6 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and Temp_Stock.Batch like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag7 As Boolean = Me.ComboBox1.SelectedIndex = 6
				If flag7 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and Temp_Stock.Size like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag8 As Boolean = Me.ComboBox1.SelectedIndex = 7
				If flag8 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and Temp_Stock.Colour like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add("1")
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06000592 RID: 1426 RVA: 0x000098B8 File Offset: 0x00007AB8
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06000593 RID: 1427 RVA: 0x0008D65C File Offset: 0x0008B85C
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.RadioButton1.Checked
			If checked Then
				Process.Start(MyProject.Application.Info.DirectoryPath + "\CryReport\BarcodeCustomise1.rpt")
			Else
				Dim checked2 As Boolean = Me.RadioButton2.Checked
				If checked2 Then
					Process.Start(MyProject.Application.Info.DirectoryPath + "\CryReport\BarcodeCustomise2.rpt")
				End If
			End If
		End Sub

		' Token: 0x06000594 RID: 1428 RVA: 0x000098C2 File Offset: 0x00007AC2
		Private Sub btnAddCustomer_Click(sender As Object, e As EventArgs)
			Me.Print()
		End Sub

		' Token: 0x06000595 RID: 1429 RVA: 0x0008D6CC File Offset: 0x0008B8CC
		Private Sub CustomPrint()
			Try
				Dim num As Single = Convert.ToSingle(Decimal.Divide(New Decimal(Me.pnlCheque.Size.Width), 38D)) * 39.3701F
				Dim num2 As Single = Convert.ToSingle(Decimal.Divide(New Decimal(Me.pnlCheque.Size.Height), 38D)) * 39.3701F
				Dim num3 As Integer = CInt(CDbl(num)) + 7
				Dim num4 As Integer = CInt(CDbl(num2)) + 8
				Me.PrintDocument1.DefaultPageSettings.PaperSize = New PaperSize("Cheque", num4, num3)
				Me.PrintPreviewDialog1.Size = New Size(800, 500)
				Me.PrintPreviewDialog1.PrintPreviewControl.Zoom = 1.0
				Me.PrintDocument1.DefaultPageSettings.Landscape = True
				Me.PrintPreviewDialog1.Document = Me.PrintDocument1
				Me.PrintPreviewDialog1.ShowDialog()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06000596 RID: 1430 RVA: 0x0008D7F0 File Offset: 0x0008B9F0
		Private Sub CustomPrint1()
			Try
				Me.PageSetupDialog1.Document = Me.PrintDocument1
				Dim flag As Boolean = Me.PrintDialog1.ShowDialog() = DialogResult.OK
				If flag Then
					Dim num As Single = Convert.ToSingle(Decimal.Divide(New Decimal(Me.pnlCheque.Size.Width), 38D)) * 39.3701F
					Dim num2 As Single = Convert.ToSingle(Decimal.Divide(New Decimal(Me.pnlCheque.Size.Height), 38D)) * 39.3701F
					Dim num3 As Integer = CInt(CDbl(num)) + 7
					Dim num4 As Integer = CInt(CDbl(num2)) + 8
					Me.PrintDocument1.DefaultPageSettings.PaperSize = New PaperSize("Cheque", num4, num3)
					Me.PrintDocument1.DefaultPageSettings.Landscape = True
					Me.PageSetupDialog1.Document = Me.PrintDocument1
					Me.PageSetupDialog1.ShowDialog()
					Me.PrintDocument1.Print()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06000597 RID: 1431 RVA: 0x0008D918 File Offset: 0x0008BB18
		Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs)
			Dim num As Integer = 15
			Dim text As String = "Item".PadRight(30)
			Dim text2 As String = "Price".PadRight(8)
			Dim text3 As String = "Qty".PadRight(5)
			Dim text4 As String = "Amount"
			Dim text5 As String = text + text2 + text3 + text4
			Dim num2 As Integer = Me.ds_labels.Tables(0).Rows.Count - 1
			Dim i As Integer = 0
			While i <= num2
				Dim label As Label = New Label()
				Dim text6 As String = Me.ds_labels.Tables("layout_labels").Rows(i)("label_text").ToString()
								Select Case text6
					Case "NoCopy"
						label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(5))
					Case "PartNo"
						label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(6))
					Case "HSNC"
						label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(7))
					Case "PurInv"
						label.Text = Convert.ToString(RuntimeHelpers.GetObjectValue(Me.dt1.Rows(Me.mPageNumber - 1)(17)))
					Case "Mfg"
						label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(12))
					Case "Colour"
						label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(15))
					Case "PCode"
						label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(0))
					Case "MRP"
						label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(8))
					Case "QrBarcode"
						label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(3))
					Case "ProductName"
						label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(1))
					Case "Barcode"
						label.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("*", Me.dt1.Rows(Me.mPageNumber - 1)(3)), "*"))
					Case "AvlQty"
						label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(4))
					Case "Category"
						label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(2))
					Case "Size"
						label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(14))
					Case "WholesalePrice"
						label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(10))
					Case "SalePrice"
						label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(9))
					Case "Batch"
						label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(11))
					Case "GST"
						label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(16))
					Case "Exp"
						label.Text = Conversions.ToString(Me.dt1.Rows(Me.mPageNumber - 1)(13))
					Case Else
						label.Text = Me.ds_labels.Tables("layout_labels").Rows(i)("label_text").ToString()
				End Select
				IL_07B9:
				label.Size = New Size(Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_width").ToString()), Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_height").ToString()))
				label.Location = New Point(Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_X").ToString()), Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_Y").ToString()))
				Dim flag As Boolean = (Operators.CompareString(Me.ds_labels.Tables("layout_labels").Rows(i)("label_name").ToString(), "QrBarcode", False) <> 0) And (Me.ds_labels.Tables("layout_labels").Rows(i)("label_name").ToString().IndexOf("Generic") = -1)
				If flag Then
					Dim fontConverter As FontConverter = New FontConverter()
					Dim text7 As String = Conversions.ToString(Me.ds_labels.Tables("layout_labels").Rows(i)("lbl_font_style"))
					If Operators.CompareString(text7, "Bold", False) <> 0 Then
						If Operators.CompareString(text7, "Italic", False) <> 0 Then
							If Operators.CompareString(text7, "Underline", False) <> 0 Then
								If Operators.CompareString(text7, "Bold, Italic, Underline", False) <> 0 Then
									If Operators.CompareString(text7, "Bold, Underline ", False) <> 0 Then
										If Operators.CompareString(text7, "Italic, Underline ", False) <> 0 Then
											text7 = Conversions.ToString(0)
										Else
											text7 = Conversions.ToString(6)
										End If
									Else
										text7 = Conversions.ToString(5)
									End If
								Else
									text7 = Conversions.ToString(7)
								End If
							Else
								text7 = Conversions.ToString(4)
							End If
						Else
							text7 = Conversions.ToString(2)
						End If
					Else
						text7 = Conversions.ToString(1)
					End If
					label.Font = New Font(Me.ds_labels.Tables("layout_labels").Rows(i)("label_font_name").ToString(), Conversions.ToSingle(Me.ds_labels.Tables("layout_labels").Rows(i)("label_font_size").ToString()), CType(Conversions.ToInteger(text7), FontStyle), GraphicsUnit.Point, 0)
					label.ForeColor = Color.FromArgb(CInt(Convert.ToInt64(Me.ds_labels.Tables("layout_labels").Rows(i)("label_text_color").ToString())))
					label.SendToBack()
					label.AutoSize = False
					e.Graphics.DrawString(label.Text, label.Font, Brushes.Black, CSng(label.Location.X), CSng(label.Location.Y))
					num += 10
					Dim font As Font = New Font("Courier New", 8F, FontStyle.Regular)
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.ds_labels.Tables("layout_labels").Rows(i)("label_name").ToString(), "QrBarcode", False) = 0
					If flag2 Then
						Dim text8 As String = label.Text
						Me.Generate_GiftQR(text8)
						e.Graphics.DrawImage(Me.pbgiftqr.Image, label.Location.X, label.Location.Y)
						num += 10
					Else
						Dim flag3 As Boolean = Me.ds_labels.Tables("layout_labels").Rows(i)("label_name").ToString().IndexOf("Generic") <> -1
						If flag3 Then
							Dim pictureBox As PictureBox = New PictureBox()
							pictureBox.Name = Me.ds_labels.Tables("layout_labels").Rows(i)("label_name").ToString()
							pictureBox.Location = New Point(Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_X").ToString()), Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_Y").ToString()))
							Dim array As Byte() = CType(Me.ds_labels.Tables("layout_labels").Rows(i)("image"), Byte())
							Dim image As Image = Me.ByteArrayToImage(array)
							pictureBox.Image = image
							pictureBox.SendToBack()
							pictureBox.SizeMode = PictureBoxSizeMode.StretchImage
							pictureBox.Size = New Size(CInt(Convert.ToInt16(Me.ds_labels.Tables("layout_labels").Rows(i)("label_width").ToString())), CInt(Convert.ToInt16(Me.ds_labels.Tables("layout_labels").Rows(i)("label_height").ToString())))
							Me.pnlCheque.Controls.Add(pictureBox)
							Me.numberPb += 1
							Me.lblHiddenImage.Tag = pictureBox.Name
							Dim num4 As Integer = CInt(Convert.ToInt16(Me.ds_labels.Tables("layout_labels").Rows(i)("label_width").ToString()))
							Dim num5 As Integer = CInt(Convert.ToInt16(Me.ds_labels.Tables("layout_labels").Rows(i)("label_height").ToString()))
							Using bitmap As Bitmap = New Bitmap(num4, num5)
								Using graphics As Graphics = Graphics.FromImage(bitmap)
									graphics.DrawImage(image, New Rectangle(0, 0, num4, num5))
								End Using
								e.Graphics.DrawImage(bitmap, New Point(pictureBox.Location.X, pictureBox.Location.Y))
							End Using
						Else
							e.Graphics.DrawString(label.Text, label.Font, Brushes.Black, CSng(label.Location.X), CSng(label.Location.Y))
							num += 10
						End If
					End If
				End If
				i += 1
				Continue While

			End While
			Dim flag4 As Boolean = Me.mPageNumber < Me.dt1.Rows.Count
			If flag4 Then
				e.HasMorePages = True
				Me.mPageNumber = Me.mPageNumber + 1
			Else
				e.HasMorePages = False
			End If
		End Sub

		' Token: 0x06000598 RID: 1432 RVA: 0x0008E8AC File Offset: 0x0008CAAC
		Private Function ByteArrayToImage(byteArrayIn As Byte()) As Image
			Dim image2 As Image
			Using memoryStream As MemoryStream = New MemoryStream(byteArrayIn)
				Dim image As Image = Image.FromStream(memoryStream)
				image2 = image
			End Using
			Return image2
		End Function

		' Token: 0x06000599 RID: 1433 RVA: 0x0008E8EC File Offset: 0x0008CAEC
		Public Sub BindLayouts()
			Dim text As String = "Select distinct layout_name,layout_id from tbl_layout order by 1"
			Dim sqlConnection As SqlConnection = New SqlConnection(Me.connString)
			Try
				sqlConnection.Open()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "layouts")
				Dim dataTable As DataTable = dataSet.Tables("layouts")
				Dim dataRow As DataRow = dataTable.NewRow()
				dataRow(0) = "Select"
				dataTable.Rows.InsertAt(dataRow, 0)
				Me.cmbLayouts.DataSource = dataTable
				Me.cmbLayouts.DisplayMember = "layout_name"
				Me.cmbLayouts.ValueMember = "layout_id"
				Me.cmbLayouts.SelectedIndex = 0
			Catch ex As Exception
				Interaction.MsgBox("Error : " + ex.Message, MsgBoxStyle.OkOnly, Nothing)
			Finally
				sqlConnection.Close()
			End Try
		End Sub

		' Token: 0x0600059A RID: 1434 RVA: 0x0008E9F8 File Offset: 0x0008CBF8
		Private Sub cmbLayouts_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbLayouts.SelectedIndex <> 0
			If flag Then
				Me.LoadSelectedLayout(Me.cmbLayouts.SelectedValue.ToString())
			End If
		End Sub

		' Token: 0x0600059B RID: 1435 RVA: 0x0008EA34 File Offset: 0x0008CC34
		Private Sub LoadSelectedLayout(selectedValue As Object)
			Me.pnlCheque.Controls.Clear()
			Dim text As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Select * from tbl_layout where layout_id='", selectedValue), "'"))
			Dim sqlConnection As SqlConnection = New SqlConnection(Me.connString)
			Try
				sqlConnection.Open()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "layouts_detail")
				Me.txtLayoutName.Text = dataSet.Tables("layouts_detail").Rows(0)("layout_name").ToString()
				Me.nudChequeLeafWidth.Text = dataSet.Tables("layouts_detail").Rows(0)("layout_width").ToString()
				Me.nudChequeHeight.Text = dataSet.Tables("layouts_detail").Rows(0)("layout_height").ToString()
				Me.pnlCheque.BackColor = Color.FromArgb(CInt(Convert.ToInt64(dataSet.Tables("layouts_detail").Rows(0)("layout_bg_color").ToString())))
				Me.LoadSelectedLayoutLabels(dataSet.Tables("layouts_detail").Rows(0)("layout_id").ToString())
			Catch ex As Exception
				Interaction.MsgBox("Error : " + ex.Message, MsgBoxStyle.OkOnly, Nothing)
			Finally
				sqlConnection.Close()
			End Try
		End Sub

		' Token: 0x0600059C RID: 1436 RVA: 0x0008EC1C File Offset: 0x0008CE1C
		Public Function ConvertToRbg(HexColor As String) As Color
			HexColor = Strings.Replace(HexColor, "#", "", 1, -1, CompareMethod.Binary)
			Dim text As String = Conversions.ToString(Conversion.Val("&H" + Strings.Mid(HexColor, 1, 2)))
			Dim text2 As String = Conversions.ToString(Conversion.Val("&H" + Strings.Mid(HexColor, 3, 2)))
			Dim text3 As String = Conversions.ToString(Conversion.Val("&H" + Strings.Mid(HexColor, 5, 2)))
			Return Color.FromArgb(Conversions.ToInteger(text), Conversions.ToInteger(text2), Conversions.ToInteger(text3))
		End Function

		' Token: 0x0600059D RID: 1437 RVA: 0x0008ECB4 File Offset: 0x0008CEB4
		Private Sub LoadSelectedLayoutLabels(selectedValue As Object)
			Dim text As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Select * from tbl_layout_label  where layout_id='", selectedValue), "'"))
			Dim sqlConnection As SqlConnection = New SqlConnection(Me.connString)
			Try
				sqlConnection.Open()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
				Me.ds_labels.Clear()
				sqlDataAdapter.Fill(Me.ds_labels, "layout_labels")
				Dim num As Integer = Me.ds_labels.Tables("layout_labels").Rows.Count - 1
				For i As Integer = 0 To num
					Dim flag As Boolean = Operators.CompareString(Me.ds_labels.Tables("layout_labels").Rows(i)("image").ToString(), "", False) = 0
					If flag Then
						Dim label As Label = New Label()
						label.Name = Me.ds_labels.Tables("layout_labels").Rows(i)("label_name").ToString()
						label.Size = New Size(Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_width").ToString()), Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_height").ToString()))
						label.Location = New Point(Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_X").ToString()), Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_Y").ToString()))
						Dim fontConverter As FontConverter = New FontConverter()
						Dim text2 As String = Conversions.ToString(Me.ds_labels.Tables("layout_labels").Rows(i)("lbl_font_style"))
						If Operators.CompareString(text2, "Bold", False) <> 0 Then
							If Operators.CompareString(text2, "Italic", False) <> 0 Then
								If Operators.CompareString(text2, "Underline", False) <> 0 Then
									If Operators.CompareString(text2, "Bold, Italic, Underline", False) <> 0 Then
										If Operators.CompareString(text2, "Bold, Underline ", False) <> 0 Then
											If Operators.CompareString(text2, "Italic, Underline ", False) <> 0 Then
												text2 = Conversions.ToString(0)
											Else
												text2 = Conversions.ToString(6)
											End If
										Else
											text2 = Conversions.ToString(5)
										End If
									Else
										text2 = Conversions.ToString(7)
									End If
								Else
									text2 = Conversions.ToString(4)
								End If
							Else
								text2 = Conversions.ToString(2)
							End If
						Else
							text2 = Conversions.ToString(1)
						End If
						label.Font = New Font(Me.ds_labels.Tables("layout_labels").Rows(i)("label_font_name").ToString(), Conversions.ToSingle(Me.ds_labels.Tables("layout_labels").Rows(i)("label_font_size").ToString()), CType(Conversions.ToInteger(text2), FontStyle), GraphicsUnit.Point, 0)
						label.ForeColor = Color.FromArgb(CInt(Convert.ToInt64(Me.ds_labels.Tables("layout_labels").Rows(i)("label_text_color").ToString())))
						label.Text = Me.ds_labels.Tables("layout_labels").Rows(i)("label_text").ToString()
						label.SendToBack()
						label.AutoSize = False
						Me.pnlCheque.Controls.Add(label)
						Me.number += 1
						Me.lblHidden.Tag = label.Name
					Else
						Dim pictureBox As PictureBox = New PictureBox()
						pictureBox.Name = Me.ds_labels.Tables("layout_labels").Rows(i)("label_name").ToString()
						pictureBox.Size = New Size(Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_width").ToString()), Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_height").ToString()))
						pictureBox.Location = New Point(Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_X").ToString()), Conversions.ToInteger(Me.ds_labels.Tables("layout_labels").Rows(i)("label_Y").ToString()))
						Dim array As Byte() = CType(Me.ds_labels.Tables("layout_labels").Rows(i)("image"), Byte())
						pictureBox.Image = Image.FromStream(New MemoryStream(array))
						pictureBox.SendToBack()
						pictureBox.SizeMode = PictureBoxSizeMode.Zoom
						Me.pnlCheque.Controls.Add(pictureBox)
						Me.numberPb += 1
						Me.lblHiddenImage.Tag = pictureBox.Name
						AddHandler pictureBox.Click, AddressOf Me.pb_Click
						AddHandler pictureBox.Resize, AddressOf Me.pb_Resize
					End If
				Next
			Catch ex As Exception
				Interaction.MsgBox("Error : " + ex.Message, MsgBoxStyle.OkOnly, Nothing)
			Finally
				sqlConnection.Close()
			End Try
		End Sub

		' Token: 0x0600059E RID: 1438 RVA: 0x000098CC File Offset: 0x00007ACC
		Private Sub pb_Resize(sender As Object, e As EventArgs)
			Throw New NotImplementedException()
		End Sub

		' Token: 0x0600059F RID: 1439 RVA: 0x000098CC File Offset: 0x00007ACC
		Private Sub pb_Click(sender As Object, e As EventArgs)
			Throw New NotImplementedException()
		End Sub

		' Token: 0x060005A0 RID: 1440 RVA: 0x0008F338 File Offset: 0x0008D538
		Private Sub nudChequeLeafWidth_ValueChanged(sender As Object, e As EventArgs)
			Try
				Me.pnlCheque.Width = Convert.ToInt32(Decimal.Multiply(Me.nudChequeLeafWidth.Value, 38D))
			Catch ex As Exception
				MessageBox.Show("CH:25" + ex.Message)
			End Try
		End Sub

		' Token: 0x060005A1 RID: 1441 RVA: 0x0008F3A8 File Offset: 0x0008D5A8
		Private Sub nudChequeHeight_ValueChanged(sender As Object, e As EventArgs)
			Try
				Me.pnlCheque.Height = Convert.ToInt32(Decimal.Multiply(Me.nudChequeHeight.Value, 38D))
			Catch ex As Exception
				MessageBox.Show("CH:26" + ex.Message)
			End Try
		End Sub

		' Token: 0x04000218 RID: 536
		Private st As String

		' Token: 0x04000219 RID: 537
		Private connString As String

		' Token: 0x0400021A RID: 538
		Private ds_labels As DataSet

		' Token: 0x0400021B RID: 539
		Private MyDS As DataSet

		' Token: 0x0400021E RID: 542
		Private mPageNumber As Integer

		' Token: 0x0400021F RID: 543
		Private dt1 As DataTable

		' Token: 0x04000220 RID: 544
		Private bCancelEdit As Boolean

		' Token: 0x04000221 RID: 545
		Private CurrentSB As ListViewItem.ListViewSubItem

		' Token: 0x04000222 RID: 546
		Private CurrentItem As ListViewItem
	End Class
End Namespace
