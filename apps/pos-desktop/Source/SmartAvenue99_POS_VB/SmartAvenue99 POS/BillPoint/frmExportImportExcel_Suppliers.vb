Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000556 RID: 1366
	<DesignerGenerated()>
	Public Partial Class frmExportImportExcel_Suppliers
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010AB7 RID: 68279 RVA: 0x00073057 File Offset: 0x00071257
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmExportImportExcel_Suppliers_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmExportImportExcel_Suppliers_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006731 RID: 26417
		' (get) Token: 0x06010ABA RID: 68282 RVA: 0x00073089 File Offset: 0x00071289
		' (set) Token: 0x06010ABB RID: 68283 RVA: 0x00073093 File Offset: 0x00071293
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006732 RID: 26418
		' (get) Token: 0x06010ABC RID: 68284 RVA: 0x0007309C File Offset: 0x0007129C
		' (set) Token: 0x06010ABD RID: 68285 RVA: 0x009BD938 File Offset: 0x009BBB38
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006733 RID: 26419
		' (get) Token: 0x06010ABE RID: 68286 RVA: 0x000730A6 File Offset: 0x000712A6
		' (set) Token: 0x06010ABF RID: 68287 RVA: 0x000730B0 File Offset: 0x000712B0
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17006734 RID: 26420
		' (get) Token: 0x06010AC0 RID: 68288 RVA: 0x000730B9 File Offset: 0x000712B9
		' (set) Token: 0x06010AC1 RID: 68289 RVA: 0x009BD97C File Offset: 0x009BBB7C
		Private _txtCity As TextBox
		Friend Overridable Property txtCity As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCity
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCity_TextChanged
				Dim textBox As TextBox = Me._txtCity
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCity = value
				textBox = Me._txtCity
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006735 RID: 26421
		' (get) Token: 0x06010AC2 RID: 68290 RVA: 0x000730C3 File Offset: 0x000712C3
		' (set) Token: 0x06010AC3 RID: 68291 RVA: 0x000730CD File Offset: 0x000712CD
		Friend Overridable Property Label2 As Label

		' Token: 0x17006736 RID: 26422
		' (get) Token: 0x06010AC4 RID: 68292 RVA: 0x000730D6 File Offset: 0x000712D6
		' (set) Token: 0x06010AC5 RID: 68293 RVA: 0x000730E0 File Offset: 0x000712E0
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17006737 RID: 26423
		' (get) Token: 0x06010AC6 RID: 68294 RVA: 0x000730E9 File Offset: 0x000712E9
		' (set) Token: 0x06010AC7 RID: 68295 RVA: 0x009BD9C0 File Offset: 0x009BBBC0
		Private _txtSupplierName As TextBox
		Friend Overridable Property txtSupplierName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSupplierName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSupplierName_TextChanged
				Dim textBox As TextBox = Me._txtSupplierName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSupplierName = value
				textBox = Me._txtSupplierName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006738 RID: 26424
		' (get) Token: 0x06010AC8 RID: 68296 RVA: 0x000730F3 File Offset: 0x000712F3
		' (set) Token: 0x06010AC9 RID: 68297 RVA: 0x000730FD File Offset: 0x000712FD
		Friend Overridable Property Label3 As Label

		' Token: 0x17006739 RID: 26425
		' (get) Token: 0x06010ACA RID: 68298 RVA: 0x00073106 File Offset: 0x00071306
		' (set) Token: 0x06010ACB RID: 68299 RVA: 0x00073110 File Offset: 0x00071310
		Friend Overridable Property Label1 As Label

		' Token: 0x1700673A RID: 26426
		' (get) Token: 0x06010ACC RID: 68300 RVA: 0x00073119 File Offset: 0x00071319
		' (set) Token: 0x06010ACD RID: 68301 RVA: 0x00073123 File Offset: 0x00071323
		Friend Overridable Property lblSet As Label

		' Token: 0x1700673B RID: 26427
		' (get) Token: 0x06010ACE RID: 68302 RVA: 0x0007312C File Offset: 0x0007132C
		' (set) Token: 0x06010ACF RID: 68303 RVA: 0x009BDA04 File Offset: 0x009BBC04
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.DataGridView1_RowPostPaint
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700673C RID: 26428
		' (get) Token: 0x06010AD0 RID: 68304 RVA: 0x00073136 File Offset: 0x00071336
		' (set) Token: 0x06010AD1 RID: 68305 RVA: 0x009BDA48 File Offset: 0x009BBC48
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

		' Token: 0x1700673D RID: 26429
		' (get) Token: 0x06010AD2 RID: 68306 RVA: 0x00073140 File Offset: 0x00071340
		' (set) Token: 0x06010AD3 RID: 68307 RVA: 0x009BDA8C File Offset: 0x009BBC8C
		Private _LinkLabel1 As LinkLabel
		Friend Overridable Property LinkLabel1 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel1_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel1 = value
				linkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700673E RID: 26430
		' (get) Token: 0x06010AD4 RID: 68308 RVA: 0x0007314A File Offset: 0x0007134A
		' (set) Token: 0x06010AD5 RID: 68309 RVA: 0x00073154 File Offset: 0x00071354
		Friend Overridable Property FolderBrowserDialog1 As FolderBrowserDialog

		' Token: 0x1700673F RID: 26431
		' (get) Token: 0x06010AD6 RID: 68310 RVA: 0x0007315D File Offset: 0x0007135D
		' (set) Token: 0x06010AD7 RID: 68311 RVA: 0x00073167 File Offset: 0x00071367
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17006740 RID: 26432
		' (get) Token: 0x06010AD8 RID: 68312 RVA: 0x00073170 File Offset: 0x00071370
		' (set) Token: 0x06010AD9 RID: 68313 RVA: 0x0007317A File Offset: 0x0007137A
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006741 RID: 26433
		' (get) Token: 0x06010ADA RID: 68314 RVA: 0x00073183 File Offset: 0x00071383
		' (set) Token: 0x06010ADB RID: 68315 RVA: 0x0007318D File Offset: 0x0007138D
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006742 RID: 26434
		' (get) Token: 0x06010ADC RID: 68316 RVA: 0x00073196 File Offset: 0x00071396
		' (set) Token: 0x06010ADD RID: 68317 RVA: 0x000731A0 File Offset: 0x000713A0
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006743 RID: 26435
		' (get) Token: 0x06010ADE RID: 68318 RVA: 0x000731A9 File Offset: 0x000713A9
		' (set) Token: 0x06010ADF RID: 68319 RVA: 0x000731B3 File Offset: 0x000713B3
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17006744 RID: 26436
		' (get) Token: 0x06010AE0 RID: 68320 RVA: 0x000731BC File Offset: 0x000713BC
		' (set) Token: 0x06010AE1 RID: 68321 RVA: 0x000731C6 File Offset: 0x000713C6
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006745 RID: 26437
		' (get) Token: 0x06010AE2 RID: 68322 RVA: 0x000731CF File Offset: 0x000713CF
		' (set) Token: 0x06010AE3 RID: 68323 RVA: 0x000731D9 File Offset: 0x000713D9
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17006746 RID: 26438
		' (get) Token: 0x06010AE4 RID: 68324 RVA: 0x000731E2 File Offset: 0x000713E2
		' (set) Token: 0x06010AE5 RID: 68325 RVA: 0x000731EC File Offset: 0x000713EC
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17006747 RID: 26439
		' (get) Token: 0x06010AE6 RID: 68326 RVA: 0x000731F5 File Offset: 0x000713F5
		' (set) Token: 0x06010AE7 RID: 68327 RVA: 0x000731FF File Offset: 0x000713FF
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17006748 RID: 26440
		' (get) Token: 0x06010AE8 RID: 68328 RVA: 0x00073208 File Offset: 0x00071408
		' (set) Token: 0x06010AE9 RID: 68329 RVA: 0x00073212 File Offset: 0x00071412
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17006749 RID: 26441
		' (get) Token: 0x06010AEA RID: 68330 RVA: 0x0007321B File Offset: 0x0007141B
		' (set) Token: 0x06010AEB RID: 68331 RVA: 0x00073225 File Offset: 0x00071425
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x1700674A RID: 26442
		' (get) Token: 0x06010AEC RID: 68332 RVA: 0x0007322E File Offset: 0x0007142E
		' (set) Token: 0x06010AED RID: 68333 RVA: 0x00073238 File Offset: 0x00071438
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x1700674B RID: 26443
		' (get) Token: 0x06010AEE RID: 68334 RVA: 0x00073241 File Offset: 0x00071441
		' (set) Token: 0x06010AEF RID: 68335 RVA: 0x0007324B File Offset: 0x0007144B
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x1700674C RID: 26444
		' (get) Token: 0x06010AF0 RID: 68336 RVA: 0x00073254 File Offset: 0x00071454
		' (set) Token: 0x06010AF1 RID: 68337 RVA: 0x0007325E File Offset: 0x0007145E
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x1700674D RID: 26445
		' (get) Token: 0x06010AF2 RID: 68338 RVA: 0x00073267 File Offset: 0x00071467
		' (set) Token: 0x06010AF3 RID: 68339 RVA: 0x00073271 File Offset: 0x00071471
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x1700674E RID: 26446
		' (get) Token: 0x06010AF4 RID: 68340 RVA: 0x0007327A File Offset: 0x0007147A
		' (set) Token: 0x06010AF5 RID: 68341 RVA: 0x00073284 File Offset: 0x00071484
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x1700674F RID: 26447
		' (get) Token: 0x06010AF6 RID: 68342 RVA: 0x0007328D File Offset: 0x0007148D
		' (set) Token: 0x06010AF7 RID: 68343 RVA: 0x00073297 File Offset: 0x00071497
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17006750 RID: 26448
		' (get) Token: 0x06010AF8 RID: 68344 RVA: 0x000732A0 File Offset: 0x000714A0
		' (set) Token: 0x06010AF9 RID: 68345 RVA: 0x000732AA File Offset: 0x000714AA
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17006751 RID: 26449
		' (get) Token: 0x06010AFA RID: 68346 RVA: 0x000732B3 File Offset: 0x000714B3
		' (set) Token: 0x06010AFB RID: 68347 RVA: 0x000732BD File Offset: 0x000714BD
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17006752 RID: 26450
		' (get) Token: 0x06010AFC RID: 68348 RVA: 0x000732C6 File Offset: 0x000714C6
		' (set) Token: 0x06010AFD RID: 68349 RVA: 0x000732D0 File Offset: 0x000714D0
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17006753 RID: 26451
		' (get) Token: 0x06010AFE RID: 68350 RVA: 0x000732D9 File Offset: 0x000714D9
		' (set) Token: 0x06010AFF RID: 68351 RVA: 0x000732E3 File Offset: 0x000714E3
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17006754 RID: 26452
		' (get) Token: 0x06010B00 RID: 68352 RVA: 0x000732EC File Offset: 0x000714EC
		' (set) Token: 0x06010B01 RID: 68353 RVA: 0x000732F6 File Offset: 0x000714F6
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17006755 RID: 26453
		' (get) Token: 0x06010B02 RID: 68354 RVA: 0x000732FF File Offset: 0x000714FF
		' (set) Token: 0x06010B03 RID: 68355 RVA: 0x00073309 File Offset: 0x00071509
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17006756 RID: 26454
		' (get) Token: 0x06010B04 RID: 68356 RVA: 0x00073312 File Offset: 0x00071512
		' (set) Token: 0x06010B05 RID: 68357 RVA: 0x0007331C File Offset: 0x0007151C
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17006757 RID: 26455
		' (get) Token: 0x06010B06 RID: 68358 RVA: 0x00073325 File Offset: 0x00071525
		' (set) Token: 0x06010B07 RID: 68359 RVA: 0x009BDAD0 File Offset: 0x009BBCD0
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

		' Token: 0x17006758 RID: 26456
		' (get) Token: 0x06010B08 RID: 68360 RVA: 0x0007332F File Offset: 0x0007152F
		' (set) Token: 0x06010B09 RID: 68361 RVA: 0x009BDB14 File Offset: 0x009BBD14
		Private _GelButton2 As GelButton
		Friend Overridable Property GelButton2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click
				Dim gelButton As GelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton2 = value
				gelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006759 RID: 26457
		' (get) Token: 0x06010B0A RID: 68362 RVA: 0x00073339 File Offset: 0x00071539
		' (set) Token: 0x06010B0B RID: 68363 RVA: 0x009BDB58 File Offset: 0x009BBD58
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

		' Token: 0x1700675A RID: 26458
		' (get) Token: 0x06010B0C RID: 68364 RVA: 0x00073343 File Offset: 0x00071543
		' (set) Token: 0x06010B0D RID: 68365 RVA: 0x009BDB9C File Offset: 0x009BBD9C
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

		' Token: 0x06010B0E RID: 68366 RVA: 0x009BDBE0 File Offset: 0x009BBDE0
		Public Sub Getdata()
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				SqlConnection.ClearAllPools()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(SupplierID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(Remarks),RTRIM(AccountName),RTRIM(AccountNumber),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),RTRIM(GSTIN),RTRIM(PAN),RTRIM(CIN),RTRIM(OpeningBalanceType),RTRIM(OpeningBalance),RTRIM(Limit),RTRIM(Lstatus),RTRIM(SCode) from Supplier order by ID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim customerBalance As String = Me.GetCustomerBalance(Conversions.ToString(ModCommonClasses.rdr(1)))
					Dim array As String() = customerBalance.Split(New Char() { ","c })
					Dim text As String = array(1)
					Dim text2 As String = array(0)
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), text, text2, ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010B0F RID: 68367 RVA: 0x009BDE70 File Offset: 0x009BC070
		Private Function GetCustomerBalance(ID As String) As String
			Dim stringBuilder As StringBuilder = New StringBuilder()
			Try
				Me.num1 = 0D
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from SupplierLedgerBook where PartyID=@d1 group By PartyID"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", ID)
				ModCommonClasses.rdr1 = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr1.Read()
				If flag Then
					Me.num1 = Conversions.ToDecimal(ModCommonClasses.rdr1.GetValue(0))
					stringBuilder.Append(Me.num1.ToString() + ",")
				Else
					stringBuilder.Append("00,")
				End If
				ModCommonClasses.con.Close()
				Dim flag2 As Boolean = Conversion.Val(Me.num1) >= 0.0
				If flag2 Then
					Me.str = "Cr"
					stringBuilder.Append(Me.str)
				Else
					Dim flag3 As Boolean = Conversion.Val(Decimal.Compare(Me.num1, 0D) < 0) <> 0.0
					If flag3 Then
						Me.str = "Dr"
						stringBuilder.Append(Me.str)
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Return stringBuilder.ToString()
		End Function

		' Token: 0x06010B10 RID: 68368 RVA: 0x009BE01C File Offset: 0x009BC21C
		Private Sub txtCity_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				SqlConnection.ClearAllPools()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(SupplierID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(Remarks),RTRIM(AccountName),RTRIM(AccountNumber),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),RTRIM(GSTIN),RTRIM(PAN),RTRIM(CIN),RTRIM(OpeningBalanceType),RTRIM(OpeningBalance),RTRIM(Limit),RTRIM(Lstatus),RTRIM(SCode) from Supplier where City like N'%" + Me.txtCity.Text + "%' order by ID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim customerBalance As String = Me.GetCustomerBalance(Conversions.ToString(ModCommonClasses.rdr(1)))
					Dim array As String() = customerBalance.Split(New Char() { ","c })
					Dim text As String = array(1)
					Dim text2 As String = array(0)
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), text, text2, ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010B11 RID: 68369 RVA: 0x009BE2B4 File Offset: 0x009BC4B4
		Public Sub Reset()
			Me.txtSupplierName.Text = ""
			Me.DataGridView1.DataSource = Nothing
			Me.DataGridView1.Visible = False
			Me.txtCity.Text = ""
			Me.Getdata()
		End Sub

		' Token: 0x06010B12 RID: 68370 RVA: 0x009BE308 File Offset: 0x009BC508
		Private Sub dgw_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dgw.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.dgw.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x06010B13 RID: 68371 RVA: 0x009BE3F0 File Offset: 0x009BC5F0
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

		' Token: 0x06010B14 RID: 68372 RVA: 0x009BE4D8 File Offset: 0x009BC6D8
		Private Sub txtSupplierName_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				SqlConnection.ClearAllPools()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(SupplierID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(Remarks),RTRIM(AccountName),RTRIM(AccountNumber),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),RTRIM(GSTIN),RTRIM(PAN),RTRIM(CIN),RTRIM(OpeningBalanceType),RTRIM(OpeningBalance),RTRIM(Limit),RTRIM(Lstatus),RTRIM(SCode) from Supplier where Name like N'%" + Me.txtSupplierName.Text + "%' order by ID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim customerBalance As String = Me.GetCustomerBalance(Conversions.ToString(ModCommonClasses.rdr(1)))
					Dim array As String() = customerBalance.Split(New Char() { ","c })
					Dim text As String = array(1)
					Dim text2 As String = array(0)
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), text, text2, ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010B15 RID: 68373 RVA: 0x0007334D File Offset: 0x0007154D
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06010B16 RID: 68374 RVA: 0x009BE770 File Offset: 0x009BC970
		Private Sub frmExportImportExcel_Suppliers_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06010B17 RID: 68375 RVA: 0x009BE864 File Offset: 0x009BCA64
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

		' Token: 0x06010B18 RID: 68376 RVA: 0x009BE9DC File Offset: 0x009BCBDC
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

		' Token: 0x06010B19 RID: 68377 RVA: 0x009BEA98 File Offset: 0x009BCC98
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

		' Token: 0x06010B1A RID: 68378 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06010B1B RID: 68379 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06010B1C RID: 68380 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06010B1D RID: 68381 RVA: 0x009BEB64 File Offset: 0x009BCD64
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.dgw.Columns.Count = 0) Or (Me.dgw.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw.Columns
							Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
							dataTable.Columns.Add(dataGridViewColumn.HeaderText)
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataTable.Rows.Add(New Object(-1) {})
							Try
								For Each obj3 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
									dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
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
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag2 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag2 Then
						text = Me.SaveFileDialog1.FileName
					End If
					Using xlworkbook As XLWorkbook = New XLWorkbook()
						xlworkbook.Worksheets.Add(dataTable, "Sheet1")
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010B1E RID: 68382 RVA: 0x009BEE10 File Offset: 0x009BD010
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
				openFileDialog.Filter = "Excel Files | *.xlsx; *.xls;| All Files (*.*)| *.*"
				Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK AndAlso Operators.CompareString(openFileDialog.FileName, "", False) <> 0
				If flag Then
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					Dim fileName As String = openFileDialog.FileName
					Dim oleDbConnection As OleDbConnection = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=Excel 8.0;")
					Dim oleDbDataAdapter As OleDbDataAdapter = New OleDbDataAdapter("select * from [Sheet1$]", oleDbConnection)
					oleDbConnection.Open()
					Dim dataSet As DataSet = New DataSet()
					oleDbDataAdapter.Fill(dataSet)
					Me.DataGridView1.Visible = True
					Me.DataGridView1.DataSource = dataSet.Tables(0)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010B1F RID: 68383 RVA: 0x009BEF14 File Offset: 0x009BD114
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
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
				Try
					Dim flag3 As Boolean = Me.DataGridView1.RowCount = 0
					If flag3 Then
						MessageBox.Show("Sorry nothing to save.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Else
						Dim num As Integer = Me.DataGridView1.RowCount - 1
						For i As Integer = 0 To num
							Dim flag4 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(0).Value.ToString(), "", False) = 0
							If flag4 Then
								MessageBox.Show("ID Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num2 As Integer = Me.DataGridView1.RowCount - 1
						For j As Integer = 0 To num2
							Dim flag5 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(j).Cells(1).Value.ToString(), "", False) = 0
							If flag5 Then
								MessageBox.Show("Supplier ID Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num3 As Integer = Me.DataGridView1.RowCount - 1
						For k As Integer = 0 To num3
							Dim flag6 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(k).Cells(2).Value.ToString(), "", False) = 0
							If flag6 Then
								MessageBox.Show("Supplier Name Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num4 As Integer = Me.DataGridView1.RowCount - 1
						For l As Integer = 0 To num4
							Dim flag7 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(l).Cells(3).Value.ToString(), "", False) = 0
							If flag7 Then
								MessageBox.Show("Address Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num5 As Integer = Me.DataGridView1.RowCount - 1
						For m As Integer = 0 To num5
							Dim flag8 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(m).Cells(4).Value.ToString(), "", False) = 0
							If flag8 Then
								MessageBox.Show("City Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num6 As Integer = Me.DataGridView1.RowCount - 1
						For n As Integer = 0 To num6
							Dim flag9 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(n).Cells(5).Value.ToString(), "", False) = 0
							If flag9 Then
								MessageBox.Show("State Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num7 As Integer = Me.DataGridView1.RowCount - 1
						For num8 As Integer = 0 To num7
							Dim flag10 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(num8).Cells(7).Value.ToString(), "", False) = 0
							If flag10 Then
								MessageBox.Show("Contact No. Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num9 As Integer = Me.DataGridView1.RowCount - 1
						For num10 As Integer = 0 To num9
							Dim flag11 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(num10).Cells(18).Value.ToString(), "", False) = 0
							If flag11 Then
								MessageBox.Show("Opening Balance Type Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num11 As Integer = Me.DataGridView1.RowCount - 1
						For num12 As Integer = 0 To num11
							Dim flag12 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(num12).Cells(19).Value.ToString(), "", False) = 0
							If flag12 Then
								MessageBox.Show("Opening Balance Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num13 As Integer = Me.DataGridView1.RowCount - 1
						For num14 As Integer = 0 To num13
							Dim flag13 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(num14).Cells(20).Value.ToString(), "", False) = 0
							If flag13 Then
								MessageBox.Show("Credit Limit Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num15 As Integer = Me.DataGridView1.RowCount - 1
						For num16 As Integer = 0 To num15
							Dim flag14 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(num16).Cells(21).Value.ToString(), "", False) = 0
							If flag14 Then
								MessageBox.Show("Limit Status Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num17 As Integer = Me.DataGridView1.RowCount - 1
						For num18 As Integer = 0 To num17
							Dim flag15 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(num18).Cells(22).Value.ToString(), "", False) = 0
							If flag15 Then
								MessageBox.Show("Supplier Code Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Try
							For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
								Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
								Dim flag16 As Boolean = Not dataGridViewRow.IsNewRow
								If flag16 Then
									SqlConnection.ClearAllPools()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text2 As String = "select ID from Supplier Where ID=@d1"
									ModCommonClasses.cmd = New SqlCommand(text2)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag17 As Boolean = ModCommonClasses.rdr.Read()
									If flag17 Then
										MessageBox.Show("Same Supplier ID detected", "Check", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Return
									End If
									Dim flag18 As Boolean = Not ModCommonClasses.rdr.Read()
									If flag18 Then
										Me.Cursor = Cursors.WaitCursor
										Me.Timer1.Enabled = True
										SqlConnection.ClearAllPools()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text3 As String = "insert into Supplier(ID,SupplierID,[Name], Address,City,State,ZipCode, ContactNo, EmailID,Remarks,AccountName,AccountNumber,Bank,Branch,IFSCCode,GSTIN,PAN,CIN,OpeningBalanceType,OpeningBalance,Limit,Lstatus,SCode,Photo) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24)"
										ModCommonClasses.cmd = New SqlCommand(text3)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow.Cells(1).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow.Cells(2).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", dataGridViewRow.Cells(3).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", dataGridViewRow.Cells(4).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow.Cells(5).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", dataGridViewRow.Cells(6).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", dataGridViewRow.Cells(7).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow.Cells(8).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d10", dataGridViewRow.Cells(9).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d11", dataGridViewRow.Cells(10).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d12", dataGridViewRow.Cells(11).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d13", dataGridViewRow.Cells(12).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d14", dataGridViewRow.Cells(13).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d15", dataGridViewRow.Cells(14).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dataGridViewRow.Cells(15).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow.Cells(16).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d18", dataGridViewRow.Cells(17).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d19", dataGridViewRow.Cells(18).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d20", dataGridViewRow.Cells(19).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d21", dataGridViewRow.Cells(20).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d22", dataGridViewRow.Cells(21).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d23", dataGridViewRow.Cells(22).Value.ToString())
										Dim memoryStream As MemoryStream = New MemoryStream()
										Dim bitmap As Bitmap = New Bitmap(Resources.photo)
										bitmap.Save(memoryStream, ImageFormat.Jpeg)
										Dim buffer As Byte() = memoryStream.GetBuffer()
										Dim sqlParameter As SqlParameter = New SqlParameter("@d24", SqlDbType.Image)
										sqlParameter.Value = buffer
										ModCommonClasses.cmd.Parameters.Add(sqlParameter)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										Dim flag19 As Boolean = (Operators.CompareString(dataGridViewRow.Cells(18).Value.ToString(), "CR", False) = 0) And (Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(19).Value)) > 0.0)
										If flag19 Then
											ModFunc.LedgerSave(DateAndTime.Today, dataGridViewRow.Cells(2).Value.ToString(), dataGridViewRow.Cells(1).Value.ToString(), "Opening Balance", 0D, New Decimal(Conversion.Val(dataGridViewRow.Cells(19).Value.ToString())), dataGridViewRow.Cells(1).Value.ToString(), dataGridViewRow.Cells(2).Value.ToString())
											ModFunc.SupplierLedgerSave(DateAndTime.Today, dataGridViewRow.Cells(2).Value.ToString(), dataGridViewRow.Cells(1).Value.ToString(), "Opening Balance", 0D, New Decimal(Conversion.Val(dataGridViewRow.Cells(19).Value.ToString())), dataGridViewRow.Cells(1).Value.ToString(), dataGridViewRow.Cells(2).Value.ToString() + "-" + dataGridViewRow.Cells(1).Value.ToString(), "")
										End If
										Dim flag20 As Boolean = (Operators.CompareString(dataGridViewRow.Cells(18).Value.ToString(), "DR", False) = 0) And (Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(19).Value)) > 0.0)
										If flag20 Then
											ModFunc.LedgerSave(DateAndTime.Today, dataGridViewRow.Cells(2).Value.ToString(), dataGridViewRow.Cells(1).Value.ToString(), "Opening Balance", New Decimal(Conversion.Val(dataGridViewRow.Cells(19).Value.ToString())), 0D, dataGridViewRow.Cells(1).Value.ToString(), dataGridViewRow.Cells(2).Value.ToString())
											ModFunc.SupplierLedgerSave(DateAndTime.Today, dataGridViewRow.Cells(2).Value.ToString(), dataGridViewRow.Cells(1).Value.ToString(), "Opening Balance", New Decimal(Conversion.Val(dataGridViewRow.Cells(19).Value.ToString())), 0D, dataGridViewRow.Cells(1).Value.ToString(), dataGridViewRow.Cells(2).Value.ToString() + "-" + dataGridViewRow.Cells(1).Value.ToString(), "")
										End If
									End If
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.DataGridView1.DataSource = Nothing
						Me.Reset()
					End If
				Catch ex As SqlException
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x06010B20 RID: 68384 RVA: 0x00073369 File Offset: 0x00071569
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06010B21 RID: 68385 RVA: 0x009BFF2C File Offset: 0x009BE12C
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Dim folderBrowserDialog As FolderBrowserDialog = Me.FolderBrowserDialog1
			Dim flag As Boolean = Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK
			If flag Then
				Dim selectedPath As String = folderBrowserDialog.SelectedPath
				File.WriteAllBytes(selectedPath + "\Supplier_Format.xls", Resources.Supplier_Format)
				Dim flag2 As Boolean = MyProject.Computer.FileSystem.FileExists(selectedPath + "\Supplier_Format.xls")
				If flag2 Then
					File.Delete(selectedPath + "\Supplier_Format.xls")
					File.WriteAllBytes(selectedPath + "\Supplier_Format.xls", Resources.Supplier_Format)
					MessageBox.Show("Successfully Saved" & vbLf, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					MessageBox.Show("Not Saved" & vbLf, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			End If
		End Sub

		' Token: 0x06010B22 RID: 68386 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmExportImportExcel_Suppliers_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x040064AD RID: 25773
		Private num1 As Decimal

		' Token: 0x040064AE RID: 25774
		Private num2 As Decimal

		' Token: 0x040064AF RID: 25775
		Private num3 As Decimal

		' Token: 0x040064B0 RID: 25776
		Private str As String
	End Class
End Namespace
