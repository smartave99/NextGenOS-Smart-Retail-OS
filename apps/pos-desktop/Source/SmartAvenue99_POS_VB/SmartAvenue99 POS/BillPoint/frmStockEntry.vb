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
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000557 RID: 1367
	<DesignerGenerated()>
	Public Partial Class frmStockEntry
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010B23 RID: 68387 RVA: 0x00073373 File Offset: 0x00071573
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmPurchase_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmStockEntry_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700675B RID: 26459
		' (get) Token: 0x06010B26 RID: 68390 RVA: 0x000733A5 File Offset: 0x000715A5
		' (set) Token: 0x06010B27 RID: 68391 RVA: 0x000733AF File Offset: 0x000715AF
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700675C RID: 26460
		' (get) Token: 0x06010B28 RID: 68392 RVA: 0x000733B8 File Offset: 0x000715B8
		' (set) Token: 0x06010B29 RID: 68393 RVA: 0x000733C2 File Offset: 0x000715C2
		Friend Overridable Property Label3 As Label

		' Token: 0x1700675D RID: 26461
		' (get) Token: 0x06010B2A RID: 68394 RVA: 0x000733CB File Offset: 0x000715CB
		' (set) Token: 0x06010B2B RID: 68395 RVA: 0x000733D5 File Offset: 0x000715D5
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700675E RID: 26462
		' (get) Token: 0x06010B2C RID: 68396 RVA: 0x000733DE File Offset: 0x000715DE
		' (set) Token: 0x06010B2D RID: 68397 RVA: 0x000733E8 File Offset: 0x000715E8
		Friend Overridable Property Label1 As Label

		' Token: 0x1700675F RID: 26463
		' (get) Token: 0x06010B2E RID: 68398 RVA: 0x000733F1 File Offset: 0x000715F1
		' (set) Token: 0x06010B2F RID: 68399 RVA: 0x000733FB File Offset: 0x000715FB
		Friend Overridable Property Label2 As Label

		' Token: 0x17006760 RID: 26464
		' (get) Token: 0x06010B30 RID: 68400 RVA: 0x00073404 File Offset: 0x00071604
		' (set) Token: 0x06010B31 RID: 68401 RVA: 0x009C1E94 File Offset: 0x009C0094
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
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006761 RID: 26465
		' (get) Token: 0x06010B32 RID: 68402 RVA: 0x0007340E File Offset: 0x0007160E
		' (set) Token: 0x06010B33 RID: 68403 RVA: 0x00073418 File Offset: 0x00071618
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17006762 RID: 26466
		' (get) Token: 0x06010B34 RID: 68404 RVA: 0x00073421 File Offset: 0x00071621
		' (set) Token: 0x06010B35 RID: 68405 RVA: 0x009C1EF4 File Offset: 0x009C00F4
		Private _txtQty As TextBox
		Friend Overridable Property txtQty As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtQty
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtQty_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtQty_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtQty
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtQty = value
				textBox = Me._txtQty
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006763 RID: 26467
		' (get) Token: 0x06010B36 RID: 68406 RVA: 0x0007342B File Offset: 0x0007162B
		' (set) Token: 0x06010B37 RID: 68407 RVA: 0x00073435 File Offset: 0x00071635
		Friend Overridable Property Label4 As Label

		' Token: 0x17006764 RID: 26468
		' (get) Token: 0x06010B38 RID: 68408 RVA: 0x0007343E File Offset: 0x0007163E
		' (set) Token: 0x06010B39 RID: 68409 RVA: 0x00073448 File Offset: 0x00071648
		Friend Overridable Property Label8 As Label

		' Token: 0x17006765 RID: 26469
		' (get) Token: 0x06010B3A RID: 68410 RVA: 0x00073451 File Offset: 0x00071651
		' (set) Token: 0x06010B3B RID: 68411 RVA: 0x0007345B File Offset: 0x0007165B
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17006766 RID: 26470
		' (get) Token: 0x06010B3C RID: 68412 RVA: 0x00073464 File Offset: 0x00071664
		' (set) Token: 0x06010B3D RID: 68413 RVA: 0x009C1F70 File Offset: 0x009C0170
		Private _dtpDate As DateTimePicker
		Friend Overridable Property dtpDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim eventHandler As EventHandler = AddressOf Me.dtpDate_LostFocus
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.LostFocus, eventHandler
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpDate = value
				dateTimePicker = Me._dtpDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.LostFocus, eventHandler
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006767 RID: 26471
		' (get) Token: 0x06010B3E RID: 68414 RVA: 0x0007346E File Offset: 0x0007166E
		' (set) Token: 0x06010B3F RID: 68415 RVA: 0x009C1FD0 File Offset: 0x009C01D0
		Private _txtRemarks As RichTextBox
		Friend Overridable Property txtRemarks As RichTextBox
			<CompilerGenerated()>
			Get
				Return Me._txtRemarks
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RichTextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtRemarks_KeyDown
				Dim richTextBox As RichTextBox = Me._txtRemarks
				If richTextBox IsNot Nothing Then
					RemoveHandler richTextBox.KeyDown, keyEventHandler
				End If
				Me._txtRemarks = value
				richTextBox = Me._txtRemarks
				If richTextBox IsNot Nothing Then
					AddHandler richTextBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006768 RID: 26472
		' (get) Token: 0x06010B40 RID: 68416 RVA: 0x00073478 File Offset: 0x00071678
		' (set) Token: 0x06010B41 RID: 68417 RVA: 0x00073482 File Offset: 0x00071682
		Friend Overridable Property Label12 As Label

		' Token: 0x17006769 RID: 26473
		' (get) Token: 0x06010B42 RID: 68418 RVA: 0x0007348B File Offset: 0x0007168B
		' (set) Token: 0x06010B43 RID: 68419 RVA: 0x009C2014 File Offset: 0x009C0214
		Private _txtST_ID As TextBox
		Friend Overridable Property txtST_ID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtST_ID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtST_ID_TextChanged
				Dim textBox As TextBox = Me._txtST_ID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtST_ID = value
				textBox = Me._txtST_ID
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700676A RID: 26474
		' (get) Token: 0x06010B44 RID: 68420 RVA: 0x00073495 File Offset: 0x00071695
		' (set) Token: 0x06010B45 RID: 68421 RVA: 0x0007349F File Offset: 0x0007169F
		Friend Overridable Property lblUser As Label

		' Token: 0x1700676B RID: 26475
		' (get) Token: 0x06010B46 RID: 68422 RVA: 0x000734A8 File Offset: 0x000716A8
		' (set) Token: 0x06010B47 RID: 68423 RVA: 0x000734B2 File Offset: 0x000716B2
		Friend Overridable Property lblSet As Label

		' Token: 0x1700676C RID: 26476
		' (get) Token: 0x06010B48 RID: 68424 RVA: 0x000734BB File Offset: 0x000716BB
		' (set) Token: 0x06010B49 RID: 68425 RVA: 0x000734C5 File Offset: 0x000716C5
		Friend Overridable Property lblUserType As Label

		' Token: 0x1700676D RID: 26477
		' (get) Token: 0x06010B4A RID: 68426 RVA: 0x000734CE File Offset: 0x000716CE
		' (set) Token: 0x06010B4B RID: 68427 RVA: 0x000734D8 File Offset: 0x000716D8
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x1700676E RID: 26478
		' (get) Token: 0x06010B4C RID: 68428 RVA: 0x000734E1 File Offset: 0x000716E1
		' (set) Token: 0x06010B4D RID: 68429 RVA: 0x009C2058 File Offset: 0x009C0258
		Private _cmbProductName As ComboBox
		Friend Overridable Property cmbProductName As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbProductName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim listControlConvertEventHandler As ListControlConvertEventHandler = AddressOf Me.cmbProductName_Format
				Dim eventHandler As EventHandler = AddressOf Me.cmbItemName_SelectedIndexChanged
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbProductName_KeyDown
				Dim comboBox As ComboBox = Me._cmbProductName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.Format, listControlConvertEventHandler
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbProductName = value
				comboBox = Me._cmbProductName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.Format, listControlConvertEventHandler
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.Validating, cancelEventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700676F RID: 26479
		' (get) Token: 0x06010B4E RID: 68430 RVA: 0x000734EB File Offset: 0x000716EB
		' (set) Token: 0x06010B4F RID: 68431 RVA: 0x000734F5 File Offset: 0x000716F5
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006770 RID: 26480
		' (get) Token: 0x06010B50 RID: 68432 RVA: 0x000734FE File Offset: 0x000716FE
		' (set) Token: 0x06010B51 RID: 68433 RVA: 0x00073508 File Offset: 0x00071708
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006771 RID: 26481
		' (get) Token: 0x06010B52 RID: 68434 RVA: 0x00073511 File Offset: 0x00071711
		' (set) Token: 0x06010B53 RID: 68435 RVA: 0x0007351B File Offset: 0x0007171B
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006772 RID: 26482
		' (get) Token: 0x06010B54 RID: 68436 RVA: 0x00073524 File Offset: 0x00071724
		' (set) Token: 0x06010B55 RID: 68437 RVA: 0x0007352E File Offset: 0x0007172E
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006773 RID: 26483
		' (get) Token: 0x06010B56 RID: 68438 RVA: 0x00073537 File Offset: 0x00071737
		' (set) Token: 0x06010B57 RID: 68439 RVA: 0x00073541 File Offset: 0x00071741
		Friend Overridable Property lblUnit As Label

		' Token: 0x17006774 RID: 26484
		' (get) Token: 0x06010B58 RID: 68440 RVA: 0x0007354A File Offset: 0x0007174A
		' (set) Token: 0x06010B59 RID: 68441 RVA: 0x00073554 File Offset: 0x00071754
		Friend Overridable Property txtBarcode As TextBox

		' Token: 0x17006775 RID: 26485
		' (get) Token: 0x06010B5A RID: 68442 RVA: 0x0007355D File Offset: 0x0007175D
		' (set) Token: 0x06010B5B RID: 68443 RVA: 0x00073567 File Offset: 0x00071767
		Friend Overridable Property txtProductID As TextBox

		' Token: 0x17006776 RID: 26486
		' (get) Token: 0x06010B5C RID: 68444 RVA: 0x00073570 File Offset: 0x00071770
		' (set) Token: 0x06010B5D RID: 68445 RVA: 0x0007357A File Offset: 0x0007177A
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x17006777 RID: 26487
		' (get) Token: 0x06010B5E RID: 68446 RVA: 0x00073583 File Offset: 0x00071783
		' (set) Token: 0x06010B5F RID: 68447 RVA: 0x0007358D File Offset: 0x0007178D
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x17006778 RID: 26488
		' (get) Token: 0x06010B60 RID: 68448 RVA: 0x00073596 File Offset: 0x00071796
		' (set) Token: 0x06010B61 RID: 68449 RVA: 0x009C20F8 File Offset: 0x009C02F8
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_TextChanged
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006779 RID: 26489
		' (get) Token: 0x06010B62 RID: 68450 RVA: 0x000735A0 File Offset: 0x000717A0
		' (set) Token: 0x06010B63 RID: 68451 RVA: 0x000735AA File Offset: 0x000717AA
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x1700677A RID: 26490
		' (get) Token: 0x06010B64 RID: 68452 RVA: 0x000735B3 File Offset: 0x000717B3
		' (set) Token: 0x06010B65 RID: 68453 RVA: 0x000735BD File Offset: 0x000717BD
		Friend Overridable Property Label5 As Label

		' Token: 0x1700677B RID: 26491
		' (get) Token: 0x06010B66 RID: 68454 RVA: 0x000735C6 File Offset: 0x000717C6
		' (set) Token: 0x06010B67 RID: 68455 RVA: 0x009C213C File Offset: 0x009C033C
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

		' Token: 0x1700677C RID: 26492
		' (get) Token: 0x06010B68 RID: 68456 RVA: 0x000735D0 File Offset: 0x000717D0
		' (set) Token: 0x06010B69 RID: 68457 RVA: 0x009C2180 File Offset: 0x009C0380
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

		' Token: 0x1700677D RID: 26493
		' (get) Token: 0x06010B6A RID: 68458 RVA: 0x000735DA File Offset: 0x000717DA
		' (set) Token: 0x06010B6B RID: 68459 RVA: 0x009C21C4 File Offset: 0x009C03C4
		Private _btnNew As GelButton
		Friend Overridable Property btnNew As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
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

		' Token: 0x1700677E RID: 26494
		' (get) Token: 0x06010B6C RID: 68460 RVA: 0x000735E4 File Offset: 0x000717E4
		' (set) Token: 0x06010B6D RID: 68461 RVA: 0x009C2208 File Offset: 0x009C0408
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

		' Token: 0x1700677F RID: 26495
		' (get) Token: 0x06010B6E RID: 68462 RVA: 0x000735EE File Offset: 0x000717EE
		' (set) Token: 0x06010B6F RID: 68463 RVA: 0x009C224C File Offset: 0x009C044C
		Private _btnAdd As GelButton
		Friend Overridable Property btnAdd As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnAdd
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnAdd_Click
				Dim gelButton As GelButton = Me._btnAdd
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnAdd = value
				gelButton = Me._btnAdd
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006780 RID: 26496
		' (get) Token: 0x06010B70 RID: 68464 RVA: 0x000735F8 File Offset: 0x000717F8
		' (set) Token: 0x06010B71 RID: 68465 RVA: 0x009C2290 File Offset: 0x009C0490
		Private _btnRemove As GelButton
		Friend Overridable Property btnRemove As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnRemove
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnRemove_Click
				Dim gelButton As GelButton = Me._btnRemove
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnRemove = value
				gelButton = Me._btnRemove
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x06010B72 RID: 68466 RVA: 0x009C22D4 File Offset: 0x009C04D4
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ST_ID FROM Stock_Store ORDER BY ST_ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ST_ID"))
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

		' Token: 0x06010B73 RID: 68467 RVA: 0x009C2440 File Offset: 0x009C0640
		Public Sub auto()
			Try
				Me.txtST_ID.Text = Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010B74 RID: 68468 RVA: 0x009C2498 File Offset: 0x009C0698
		Public Sub Reset()
			Me.dtpDate.Text = Conversions.ToString(DateAndTime.Today)
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.DataGridView1.Enabled = True
			Me.btnAdd.Enabled = True
			Me.btnRemove.Enabled = False
			Me.DataGridView1.Rows.Clear()
			Me.lblSet.Text = ""
			Me.Clear()
			Me.auto()
		End Sub

		' Token: 0x06010B75 RID: 68469 RVA: 0x009C2530 File Offset: 0x009C0730
		Public Sub Clear()
			Me.cmbProductName.Text = ""
			Me.txtProductID.Text = ""
			Me.txtBarcode.Text = ""
			Me.lblUnit.Text = "Unit"
			Me.txtQty.Text = ""
			Me.cmbProductName.Focus()
		End Sub

		' Token: 0x06010B76 RID: 68470 RVA: 0x009C25A0 File Offset: 0x009C07A0
		Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Not allowed", False) = 0
				If flag2 Then
					Me.btnRemove.Enabled = False
				Else
					Me.btnRemove.Enabled = True
				End If
			End If
		End Sub

		' Token: 0x06010B77 RID: 68471 RVA: 0x009C2604 File Offset: 0x009C0804
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

		' Token: 0x06010B78 RID: 68472 RVA: 0x009C26EC File Offset: 0x009C08EC
		Private Sub frmPurchase_Load(sender As Object, e As EventArgs)
			Me.fillItem()
			Me.GetCompanyname()
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06010B79 RID: 68473 RVA: 0x009C277C File Offset: 0x009C097C
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

		' Token: 0x06010B7A RID: 68474 RVA: 0x009C28F4 File Offset: 0x009C0AF4
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

		' Token: 0x06010B7B RID: 68475 RVA: 0x009C29B0 File Offset: 0x009C0BB0
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

		' Token: 0x06010B7C RID: 68476 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06010B7D RID: 68477 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06010B7E RID: 68478 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06010B7F RID: 68479 RVA: 0x009C2A7C File Offset: 0x009C0C7C
		Private Sub GetCompanyname()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.DTP1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.DTP2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
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
			End Try
		End Sub

		' Token: 0x06010B80 RID: 68480 RVA: 0x009C2B74 File Offset: 0x009C0D74
		Private Sub DeleteRecord()
			Try
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "select ProductID from Temp_Stock where ProductID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag As Boolean = ModCommonClasses.rdr.Read()
						If flag Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "Update Temp_Stock set Qty=Qty - " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value))) + " where ProductID=@d1 and Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow.Cells(2).Value.ToString())
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Try
					For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
						Dim flag2 As Boolean = Not dataGridViewRow2.IsNewRow
						If flag2 Then
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = "select ProductID from StockMovement where ProductID=@d1 and TransID=@d2"
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox1.Text)
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
							If flag3 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text4 As String = "delete from StockMovement where ProductID=@d1 and TransID=@d2"
								ModCommonClasses.cmd = New SqlCommand(text4)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox1.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.con.Close()
							End If
						End If
					Next
				Finally
					Dim enumerator2 As IEnumerator
					If TypeOf enumerator2 Is IDisposable Then
						TryCast(enumerator2, IDisposable).Dispose()
					End If
				End Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text5 As String = "delete from Stock_Store where ST_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text5)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtST_ID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag4 As Boolean = num > 0
				If flag4 Then
					ModFunc.LogFunc(Me.lblUser.Text, "deleted the item stock record having Stock ID '" + Me.txtST_ID.Text + "'")
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
					ModFunc.RefreshRecords()
				Else
					MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				End If
				Dim flag5 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag5 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010B81 RID: 68481 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbProductName_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x06010B82 RID: 68482 RVA: 0x009A8308 File Offset: 0x009A6508
		Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), ".", False) <> 0 AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
			Dim flag2 As Boolean = Conversions.ToBoolean(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, Nothing, "text", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "contains", New Object() { "." }, Nothing, Nothing, Nothing))
			If flag2 Then
				Dim flag3 As Boolean = Operators.CompareString(Conversions.ToString(e.KeyChar), ".", False) = 0
				If flag3 Then
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x06010B83 RID: 68483 RVA: 0x00131C7C File Offset: 0x0012FE7C
		Public Sub fillItem()
			Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010B84 RID: 68484 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub cmbItemName_SelectedIndexChanged(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06010B85 RID: 68485 RVA: 0x009C3080 File Offset: 0x009C1280
		Private Sub dtpDate_LostFocus(sender As Object, e As EventArgs)
			Dim flag As Boolean = DateTime.Compare(Me.dtpDate.Value, Me.DTP1.Value) < 0
			If flag Then
				Me.dtpDate.Value = DateAndTime.Today
				MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				MyBase.Close()
			Else
				Dim flag2 As Boolean = DateTime.Compare(Me.dtpDate.Value, Me.DTP2.Value) > 0
				If flag2 Then
					Me.dtpDate.Value = DateAndTime.Today
					MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06010B86 RID: 68486 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06010B87 RID: 68487 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtRemarks_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06010B88 RID: 68488 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtQty_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06010B89 RID: 68489 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmStockEntry_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06010B8A RID: 68490 RVA: 0x009C312C File Offset: 0x009C132C
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox1.Text = "SE-" + Conversion.Val(Me.txtST_ID.Text).ToString() + "-X"
		End Sub

		' Token: 0x06010B8B RID: 68491 RVA: 0x009C312C File Offset: 0x009C132C
		Private Sub txtST_ID_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox1.Text = "SE-" + Conversion.Val(Me.txtST_ID.Text).ToString() + "-X"
		End Sub

		' Token: 0x06010B8C RID: 68492 RVA: 0x009C3170 File Offset: 0x009C1370
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtQty.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtQty, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtQty, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.cmbProductName.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.cmbProductName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbProductName, String.Empty)
			End If
		End Sub

		' Token: 0x06010B8D RID: 68493 RVA: 0x009C3218 File Offset: 0x009C1418
		Private Sub cmbProductName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
					ModCommonClasses.cmd.CommandText = "SELECT PID,RTRIM(PurchaseUnit),RTRIM(ProductName) from Product,Temp_Stock where Product.PID=Temp_Stock.ProductID and Temp_Stock.Barcode=@d1"
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbProductName.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
					If flag2 Then
						Me.txtProductID.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
						Me.lblUnit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
						Me.txtBarcode.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					End If
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag4 Then
						ModCommonClasses.con.Close()
					End If
					Me.txtQty.Focus()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x06010B8E RID: 68494 RVA: 0x00073602 File Offset: 0x00071802
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06010B8F RID: 68495 RVA: 0x009C3390 File Offset: 0x009C1590
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Me.auto()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "select * from Company"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
			If flag Then
				MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
			Else
				Dim flag3 As Boolean = Me.DataGridView1.Rows.Count = 0
				If flag3 Then
					MessageBox.Show("Sorry no item info added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Try
						Try
							For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
								Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text2 As String = "select ProductID from temp_Stock where ProductID=@d1 and Barcode=@d2"
								ModCommonClasses.cmd = New SqlCommand(text2)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow.Cells(2).Value.ToString())
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
								If flag4 Then
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text3 As String = "Update Temp_Stock set Qty=Qty + " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value))) + " where ProductID=@d1 and Barcode=@d2"
									ModCommonClasses.cmd = New SqlCommand(text3)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow.Cells(2).Value.ToString())
									ModCommonClasses.cmd.ExecuteReader()
									ModCommonClasses.con.Close()
								Else
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text4 As String = "Insert Into Temp_Stock(ProductID,Qty,Barcode,SalesManPur) values (@d1,@d2,@d3,@d4)"
									ModCommonClasses.cmd = New SqlCommand(text4)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value)))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow.Cells(2).Value.ToString())
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", 0.0)
									ModCommonClasses.cmd.ExecuteReader()
									ModCommonClasses.con.Close()
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						Try
							For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
								Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
								Dim flag5 As Boolean = Not dataGridViewRow2.IsNewRow
								If flag5 Then
									Dim flag6 As Boolean = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(3).Value)) > 0.0
									If flag6 Then
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text5 As String = "select ProductID from StockMovement where ProductID=@d1"
										ModCommonClasses.cmd = New SqlCommand(text5)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
										ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
										Dim flag7 As Boolean = Not ModCommonClasses.rdr.Read()
										If flag7 Then
											ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))), 0D, New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(3).Value))), 0D, Me.dtpDate.Value.[Date], Me.TextBox1.Text)
										Else
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text6 As String = "select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 and Date < @d3"
											ModCommonClasses.cmd = New SqlCommand(text6)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpDate.Value.[Date])
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
											Dim num As Double
											If flag8 Then
												num = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
											Else
												num = 0.0
											End If
											ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))), New Decimal(num), New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(3).Value))), 0D, Me.dtpDate.Value.[Date], Me.TextBox1.Text)
										End If
										ModCommonClasses.con.Close()
									End If
								End If
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text7 As String = "insert into Stock_Store(ST_ID,Date,Remarks) VALUES (@d1,@d2,@d3)"
						ModCommonClasses.cmd = New SqlCommand(text7)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtST_ID.Text))
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.dtpDate.Value.[Date])
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtRemarks.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteNonQuery()
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text8 As String = "insert into Stock_Store_Join(StockID,ProductID,Qty,Barcode) VALUES (" + Me.txtST_ID.Text + ",@d1,@d2,@d3)"
						ModCommonClasses.cmd = New SqlCommand(text8)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Prepare()
						Try
							For Each obj3 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
								Dim dataGridViewRow3 As DataGridViewRow = CType(obj3, DataGridViewRow)
								Dim flag9 As Boolean = Not dataGridViewRow3.IsNewRow
								If flag9 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(3).Value)))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(2).Value))
									ModCommonClasses.cmd.ExecuteNonQuery()
									ModCommonClasses.cmd.Parameters.Clear()
								End If
							Next
						Finally
							Dim enumerator3 As IEnumerator
							If TypeOf enumerator3 Is IDisposable Then
								TryCast(enumerator3, IDisposable).Dispose()
							End If
						End Try
						ModCommonClasses.con.Close()
						ModFunc.LogFunc(Me.lblUser.Text, "added the new Item Stock having Stock ID '" + Me.txtST_ID.Text + "'")
						MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.btnSave.Enabled = False
						ModCommonClasses.con.Close()
						ModFunc.RefreshRecords()
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x06010B90 RID: 68496 RVA: 0x009C3DB0 File Offset: 0x009C1FB0
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

		' Token: 0x06010B91 RID: 68497 RVA: 0x0007360C File Offset: 0x0007180C
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Me.Reset()
			MyProject.Forms.frmStockEntryRecord.Reset()
			MyProject.Forms.frmStockEntryRecord.ShowDialog()
			MyProject.Forms.frmStockEntryRecord.Dispose()
		End Sub

		' Token: 0x06010B92 RID: 68498 RVA: 0x009C3E18 File Offset: 0x009C2018
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
				Me.btnRemove.Enabled = False
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010B93 RID: 68499 RVA: 0x009C3ECC File Offset: 0x009C20CC
		Private Sub btnAdd_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.cmbProductName.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please select Barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbProductName.Focus()
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.txtQty.Text, "", False) = 0
					If flag2 Then
						MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtQty.Focus()
					Else
						Dim flag3 As Boolean = Conversion.Val(Conversions.ToDouble(Me.txtQty.Text) = 0.0) <> 0.0
						If flag3 Then
							MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtQty.Focus()
						Else
							Dim flag4 As Boolean = Me.DataGridView1.Rows.Count = 0
							If flag4 Then
								Me.DataGridView1.Rows.Add(New Object() { Conversion.Val(Me.txtProductID.Text), Me.txtBarcode.Text, Me.cmbProductName.Text, Conversion.Val(Me.txtQty.Text) })
								Me.Clear()
							Else
								Try
									For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
										Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
										Dim flag5 As Boolean = Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dataGridViewRow.Cells(0).Value, Me.txtProductID.Text, False), Operators.CompareObjectEqual(dataGridViewRow.Cells(1).Value, Me.cmbProductName.Text, False)))
										If flag5 Then
											dataGridViewRow.Cells(0).Value = Me.txtProductID.Text
											dataGridViewRow.Cells(1).Value = Me.txtBarcode.Text
											dataGridViewRow.Cells(2).Value = Me.cmbProductName.Text
											dataGridViewRow.Cells(3).Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value)) + Conversion.Val(Me.txtQty.Text)
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
								Me.DataGridView1.Rows.Add(New Object() { Conversion.Val(Me.txtProductID.Text), Me.txtBarcode.Text, Me.cmbProductName.Text, Conversion.Val(Me.txtQty.Text) })
								Me.Clear()
							End If
						End If
					End If
				End If
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x040064D8 RID: 25816
		Private str As String

		' Token: 0x040064D9 RID: 25817
		Private st As String
	End Class
End Namespace
