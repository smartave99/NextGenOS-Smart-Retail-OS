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
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001F5 RID: 501
	<DesignerGenerated()>
	Public Partial Class frmSerialwiseReport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06008E68 RID: 36456 RVA: 0x00045803 File Offset: 0x00043A03
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalesInvoiceRecord_GSTR_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17003487 RID: 13447
		' (get) Token: 0x06008E6B RID: 36459 RVA: 0x00045835 File Offset: 0x00043A35
		' (set) Token: 0x06008E6C RID: 36460 RVA: 0x0004583F File Offset: 0x00043A3F
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17003488 RID: 13448
		' (get) Token: 0x06008E6D RID: 36461 RVA: 0x00045848 File Offset: 0x00043A48
		' (set) Token: 0x06008E6E RID: 36462 RVA: 0x0068A074 File Offset: 0x00688274
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
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseDoubleClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseDoubleClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseDoubleClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003489 RID: 13449
		' (get) Token: 0x06008E6F RID: 36463 RVA: 0x00045852 File Offset: 0x00043A52
		' (set) Token: 0x06008E70 RID: 36464 RVA: 0x0004585C File Offset: 0x00043A5C
		Friend Overridable Property Panel5 As Panel

		' Token: 0x1700348A RID: 13450
		' (get) Token: 0x06008E71 RID: 36465 RVA: 0x00045865 File Offset: 0x00043A65
		' (set) Token: 0x06008E72 RID: 36466 RVA: 0x0004586F File Offset: 0x00043A6F
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x1700348B RID: 13451
		' (get) Token: 0x06008E73 RID: 36467 RVA: 0x00045878 File Offset: 0x00043A78
		' (set) Token: 0x06008E74 RID: 36468 RVA: 0x00045882 File Offset: 0x00043A82
		Friend Overridable Property Label2 As Label

		' Token: 0x1700348C RID: 13452
		' (get) Token: 0x06008E75 RID: 36469 RVA: 0x0004588B File Offset: 0x00043A8B
		' (set) Token: 0x06008E76 RID: 36470 RVA: 0x00045895 File Offset: 0x00043A95
		Friend Overridable Property Label4 As Label

		' Token: 0x1700348D RID: 13453
		' (get) Token: 0x06008E77 RID: 36471 RVA: 0x0004589E File Offset: 0x00043A9E
		' (set) Token: 0x06008E78 RID: 36472 RVA: 0x000458A8 File Offset: 0x00043AA8
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x1700348E RID: 13454
		' (get) Token: 0x06008E79 RID: 36473 RVA: 0x000458B1 File Offset: 0x00043AB1
		' (set) Token: 0x06008E7A RID: 36474 RVA: 0x000458BB File Offset: 0x00043ABB
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x1700348F RID: 13455
		' (get) Token: 0x06008E7B RID: 36475 RVA: 0x000458C4 File Offset: 0x00043AC4
		' (set) Token: 0x06008E7C RID: 36476 RVA: 0x000458CE File Offset: 0x00043ACE
		Friend Overridable Property Label1 As Label

		' Token: 0x17003490 RID: 13456
		' (get) Token: 0x06008E7D RID: 36477 RVA: 0x000458D7 File Offset: 0x00043AD7
		' (set) Token: 0x06008E7E RID: 36478 RVA: 0x000458E1 File Offset: 0x00043AE1
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17003491 RID: 13457
		' (get) Token: 0x06008E7F RID: 36479 RVA: 0x000458EA File Offset: 0x00043AEA
		' (set) Token: 0x06008E80 RID: 36480 RVA: 0x000458F4 File Offset: 0x00043AF4
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17003492 RID: 13458
		' (get) Token: 0x06008E81 RID: 36481 RVA: 0x000458FD File Offset: 0x00043AFD
		' (set) Token: 0x06008E82 RID: 36482 RVA: 0x00045907 File Offset: 0x00043B07
		Friend Overridable Property Label3 As Label

		' Token: 0x17003493 RID: 13459
		' (get) Token: 0x06008E83 RID: 36483 RVA: 0x00045910 File Offset: 0x00043B10
		' (set) Token: 0x06008E84 RID: 36484 RVA: 0x0068A0D4 File Offset: 0x006882D4
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

		' Token: 0x17003494 RID: 13460
		' (get) Token: 0x06008E85 RID: 36485 RVA: 0x0004591A File Offset: 0x00043B1A
		' (set) Token: 0x06008E86 RID: 36486 RVA: 0x0068A118 File Offset: 0x00688318
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox1_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003495 RID: 13461
		' (get) Token: 0x06008E87 RID: 36487 RVA: 0x00045924 File Offset: 0x00043B24
		' (set) Token: 0x06008E88 RID: 36488 RVA: 0x0068A15C File Offset: 0x0068835C
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

		' Token: 0x17003496 RID: 13462
		' (get) Token: 0x06008E89 RID: 36489 RVA: 0x0004592E File Offset: 0x00043B2E
		' (set) Token: 0x06008E8A RID: 36490 RVA: 0x00045938 File Offset: 0x00043B38
		Friend Overridable Property Label6 As Label

		' Token: 0x17003497 RID: 13463
		' (get) Token: 0x06008E8B RID: 36491 RVA: 0x00045941 File Offset: 0x00043B41
		' (set) Token: 0x06008E8C RID: 36492 RVA: 0x0004594B File Offset: 0x00043B4B
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x17003498 RID: 13464
		' (get) Token: 0x06008E8D RID: 36493 RVA: 0x00045954 File Offset: 0x00043B54
		' (set) Token: 0x06008E8E RID: 36494 RVA: 0x0004595E File Offset: 0x00043B5E
		Friend Overridable Property Label8 As Label

		' Token: 0x17003499 RID: 13465
		' (get) Token: 0x06008E8F RID: 36495 RVA: 0x00045967 File Offset: 0x00043B67
		' (set) Token: 0x06008E90 RID: 36496 RVA: 0x0068A1A0 File Offset: 0x006883A0
		Private _ComboBox2 As ComboBox
		Friend Overridable Property ComboBox2 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox2_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox2 = value
				comboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700349A RID: 13466
		' (get) Token: 0x06008E91 RID: 36497 RVA: 0x00045971 File Offset: 0x00043B71
		' (set) Token: 0x06008E92 RID: 36498 RVA: 0x0004597B File Offset: 0x00043B7B
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700349B RID: 13467
		' (get) Token: 0x06008E93 RID: 36499 RVA: 0x00045984 File Offset: 0x00043B84
		' (set) Token: 0x06008E94 RID: 36500 RVA: 0x0004598E File Offset: 0x00043B8E
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700349C RID: 13468
		' (get) Token: 0x06008E95 RID: 36501 RVA: 0x00045997 File Offset: 0x00043B97
		' (set) Token: 0x06008E96 RID: 36502 RVA: 0x000459A1 File Offset: 0x00043BA1
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x1700349D RID: 13469
		' (get) Token: 0x06008E97 RID: 36503 RVA: 0x000459AA File Offset: 0x00043BAA
		' (set) Token: 0x06008E98 RID: 36504 RVA: 0x000459B4 File Offset: 0x00043BB4
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700349E RID: 13470
		' (get) Token: 0x06008E99 RID: 36505 RVA: 0x000459BD File Offset: 0x00043BBD
		' (set) Token: 0x06008E9A RID: 36506 RVA: 0x000459C7 File Offset: 0x00043BC7
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x1700349F RID: 13471
		' (get) Token: 0x06008E9B RID: 36507 RVA: 0x000459D0 File Offset: 0x00043BD0
		' (set) Token: 0x06008E9C RID: 36508 RVA: 0x000459DA File Offset: 0x00043BDA
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x170034A0 RID: 13472
		' (get) Token: 0x06008E9D RID: 36509 RVA: 0x000459E3 File Offset: 0x00043BE3
		' (set) Token: 0x06008E9E RID: 36510 RVA: 0x000459ED File Offset: 0x00043BED
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x170034A1 RID: 13473
		' (get) Token: 0x06008E9F RID: 36511 RVA: 0x000459F6 File Offset: 0x00043BF6
		' (set) Token: 0x06008EA0 RID: 36512 RVA: 0x00045A00 File Offset: 0x00043C00
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x170034A2 RID: 13474
		' (get) Token: 0x06008EA1 RID: 36513 RVA: 0x00045A09 File Offset: 0x00043C09
		' (set) Token: 0x06008EA2 RID: 36514 RVA: 0x00045A13 File Offset: 0x00043C13
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x170034A3 RID: 13475
		' (get) Token: 0x06008EA3 RID: 36515 RVA: 0x00045A1C File Offset: 0x00043C1C
		' (set) Token: 0x06008EA4 RID: 36516 RVA: 0x00045A26 File Offset: 0x00043C26
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170034A4 RID: 13476
		' (get) Token: 0x06008EA5 RID: 36517 RVA: 0x00045A2F File Offset: 0x00043C2F
		' (set) Token: 0x06008EA6 RID: 36518 RVA: 0x00045A39 File Offset: 0x00043C39
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x170034A5 RID: 13477
		' (get) Token: 0x06008EA7 RID: 36519 RVA: 0x00045A42 File Offset: 0x00043C42
		' (set) Token: 0x06008EA8 RID: 36520 RVA: 0x00045A4C File Offset: 0x00043C4C
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170034A6 RID: 13478
		' (get) Token: 0x06008EA9 RID: 36521 RVA: 0x00045A55 File Offset: 0x00043C55
		' (set) Token: 0x06008EAA RID: 36522 RVA: 0x00045A5F File Offset: 0x00043C5F
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x170034A7 RID: 13479
		' (get) Token: 0x06008EAB RID: 36523 RVA: 0x00045A68 File Offset: 0x00043C68
		' (set) Token: 0x06008EAC RID: 36524 RVA: 0x00045A72 File Offset: 0x00043C72
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170034A8 RID: 13480
		' (get) Token: 0x06008EAD RID: 36525 RVA: 0x00045A7B File Offset: 0x00043C7B
		' (set) Token: 0x06008EAE RID: 36526 RVA: 0x00045A85 File Offset: 0x00043C85
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x170034A9 RID: 13481
		' (get) Token: 0x06008EAF RID: 36527 RVA: 0x00045A8E File Offset: 0x00043C8E
		' (set) Token: 0x06008EB0 RID: 36528 RVA: 0x00045A98 File Offset: 0x00043C98
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170034AA RID: 13482
		' (get) Token: 0x06008EB1 RID: 36529 RVA: 0x00045AA1 File Offset: 0x00043CA1
		' (set) Token: 0x06008EB2 RID: 36530 RVA: 0x00045AAB File Offset: 0x00043CAB
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x170034AB RID: 13483
		' (get) Token: 0x06008EB3 RID: 36531 RVA: 0x00045AB4 File Offset: 0x00043CB4
		' (set) Token: 0x06008EB4 RID: 36532 RVA: 0x00045ABE File Offset: 0x00043CBE
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x170034AC RID: 13484
		' (get) Token: 0x06008EB5 RID: 36533 RVA: 0x00045AC7 File Offset: 0x00043CC7
		' (set) Token: 0x06008EB6 RID: 36534 RVA: 0x00045AD1 File Offset: 0x00043CD1
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x170034AD RID: 13485
		' (get) Token: 0x06008EB7 RID: 36535 RVA: 0x00045ADA File Offset: 0x00043CDA
		' (set) Token: 0x06008EB8 RID: 36536 RVA: 0x00045AE4 File Offset: 0x00043CE4
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x170034AE RID: 13486
		' (get) Token: 0x06008EB9 RID: 36537 RVA: 0x00045AED File Offset: 0x00043CED
		' (set) Token: 0x06008EBA RID: 36538 RVA: 0x00045AF7 File Offset: 0x00043CF7
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x170034AF RID: 13487
		' (get) Token: 0x06008EBB RID: 36539 RVA: 0x00045B00 File Offset: 0x00043D00
		' (set) Token: 0x06008EBC RID: 36540 RVA: 0x00045B0A File Offset: 0x00043D0A
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x170034B0 RID: 13488
		' (get) Token: 0x06008EBD RID: 36541 RVA: 0x00045B13 File Offset: 0x00043D13
		' (set) Token: 0x06008EBE RID: 36542 RVA: 0x00045B1D File Offset: 0x00043D1D
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x170034B1 RID: 13489
		' (get) Token: 0x06008EBF RID: 36543 RVA: 0x00045B26 File Offset: 0x00043D26
		' (set) Token: 0x06008EC0 RID: 36544 RVA: 0x00045B30 File Offset: 0x00043D30
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x170034B2 RID: 13490
		' (get) Token: 0x06008EC1 RID: 36545 RVA: 0x00045B39 File Offset: 0x00043D39
		' (set) Token: 0x06008EC2 RID: 36546 RVA: 0x00045B43 File Offset: 0x00043D43
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x170034B3 RID: 13491
		' (get) Token: 0x06008EC3 RID: 36547 RVA: 0x00045B4C File Offset: 0x00043D4C
		' (set) Token: 0x06008EC4 RID: 36548 RVA: 0x00045B56 File Offset: 0x00043D56
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x170034B4 RID: 13492
		' (get) Token: 0x06008EC5 RID: 36549 RVA: 0x00045B5F File Offset: 0x00043D5F
		' (set) Token: 0x06008EC6 RID: 36550 RVA: 0x00045B69 File Offset: 0x00043D69
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x170034B5 RID: 13493
		' (get) Token: 0x06008EC7 RID: 36551 RVA: 0x00045B72 File Offset: 0x00043D72
		' (set) Token: 0x06008EC8 RID: 36552 RVA: 0x00045B7C File Offset: 0x00043D7C
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x170034B6 RID: 13494
		' (get) Token: 0x06008EC9 RID: 36553 RVA: 0x00045B85 File Offset: 0x00043D85
		' (set) Token: 0x06008ECA RID: 36554 RVA: 0x00045B8F File Offset: 0x00043D8F
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x170034B7 RID: 13495
		' (get) Token: 0x06008ECB RID: 36555 RVA: 0x00045B98 File Offset: 0x00043D98
		' (set) Token: 0x06008ECC RID: 36556 RVA: 0x00045BA2 File Offset: 0x00043DA2
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x170034B8 RID: 13496
		' (get) Token: 0x06008ECD RID: 36557 RVA: 0x00045BAB File Offset: 0x00043DAB
		' (set) Token: 0x06008ECE RID: 36558 RVA: 0x00045BB5 File Offset: 0x00043DB5
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x170034B9 RID: 13497
		' (get) Token: 0x06008ECF RID: 36559 RVA: 0x00045BBE File Offset: 0x00043DBE
		' (set) Token: 0x06008ED0 RID: 36560 RVA: 0x00045BC8 File Offset: 0x00043DC8
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x170034BA RID: 13498
		' (get) Token: 0x06008ED1 RID: 36561 RVA: 0x00045BD1 File Offset: 0x00043DD1
		' (set) Token: 0x06008ED2 RID: 36562 RVA: 0x0068A1E4 File Offset: 0x006883E4
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

		' Token: 0x170034BB RID: 13499
		' (get) Token: 0x06008ED3 RID: 36563 RVA: 0x00045BDB File Offset: 0x00043DDB
		' (set) Token: 0x06008ED4 RID: 36564 RVA: 0x0068A228 File Offset: 0x00688428
		Private _btnReset As GelButton
		Friend Overridable Property btnReset As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim gelButton As GelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnReset = value
				gelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170034BC RID: 13500
		' (get) Token: 0x06008ED5 RID: 36565 RVA: 0x00045BE5 File Offset: 0x00043DE5
		' (set) Token: 0x06008ED6 RID: 36566 RVA: 0x0068A26C File Offset: 0x0068846C
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

		' Token: 0x170034BD RID: 13501
		' (get) Token: 0x06008ED7 RID: 36567 RVA: 0x00045BEF File Offset: 0x00043DEF
		' (set) Token: 0x06008ED8 RID: 36568 RVA: 0x00045BF9 File Offset: 0x00043DF9
		Friend Overridable Property colSerialNo1 As DataGridViewTextBoxColumn

		' Token: 0x170034BE RID: 13502
		' (get) Token: 0x06008ED9 RID: 36569 RVA: 0x00045C02 File Offset: 0x00043E02
		' (set) Token: 0x06008EDA RID: 36570 RVA: 0x00045C0C File Offset: 0x00043E0C
		Friend Overridable Property dgwPurchase As DataGridView

		' Token: 0x170034BF RID: 13503
		' (get) Token: 0x06008EDB RID: 36571 RVA: 0x00045C15 File Offset: 0x00043E15
		' (set) Token: 0x06008EDC RID: 36572 RVA: 0x00045C1F File Offset: 0x00043E1F
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x170034C0 RID: 13504
		' (get) Token: 0x06008EDD RID: 36573 RVA: 0x00045C28 File Offset: 0x00043E28
		' (set) Token: 0x06008EDE RID: 36574 RVA: 0x00045C32 File Offset: 0x00043E32
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x170034C1 RID: 13505
		' (get) Token: 0x06008EDF RID: 36575 RVA: 0x00045C3B File Offset: 0x00043E3B
		' (set) Token: 0x06008EE0 RID: 36576 RVA: 0x00045C45 File Offset: 0x00043E45
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x170034C2 RID: 13506
		' (get) Token: 0x06008EE1 RID: 36577 RVA: 0x00045C4E File Offset: 0x00043E4E
		' (set) Token: 0x06008EE2 RID: 36578 RVA: 0x00045C58 File Offset: 0x00043E58
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x170034C3 RID: 13507
		' (get) Token: 0x06008EE3 RID: 36579 RVA: 0x00045C61 File Offset: 0x00043E61
		' (set) Token: 0x06008EE4 RID: 36580 RVA: 0x00045C6B File Offset: 0x00043E6B
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x170034C4 RID: 13508
		' (get) Token: 0x06008EE5 RID: 36581 RVA: 0x00045C74 File Offset: 0x00043E74
		' (set) Token: 0x06008EE6 RID: 36582 RVA: 0x00045C7E File Offset: 0x00043E7E
		Friend Overridable Property DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn

		' Token: 0x170034C5 RID: 13509
		' (get) Token: 0x06008EE7 RID: 36583 RVA: 0x00045C87 File Offset: 0x00043E87
		' (set) Token: 0x06008EE8 RID: 36584 RVA: 0x00045C91 File Offset: 0x00043E91
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x170034C6 RID: 13510
		' (get) Token: 0x06008EE9 RID: 36585 RVA: 0x00045C9A File Offset: 0x00043E9A
		' (set) Token: 0x06008EEA RID: 36586 RVA: 0x00045CA4 File Offset: 0x00043EA4
		Friend Overridable Property DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn

		' Token: 0x170034C7 RID: 13511
		' (get) Token: 0x06008EEB RID: 36587 RVA: 0x00045CAD File Offset: 0x00043EAD
		' (set) Token: 0x06008EEC RID: 36588 RVA: 0x00045CB7 File Offset: 0x00043EB7
		Friend Overridable Property DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn

		' Token: 0x170034C8 RID: 13512
		' (get) Token: 0x06008EED RID: 36589 RVA: 0x00045CC0 File Offset: 0x00043EC0
		' (set) Token: 0x06008EEE RID: 36590 RVA: 0x00045CCA File Offset: 0x00043ECA
		Friend Overridable Property DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn

		' Token: 0x170034C9 RID: 13513
		' (get) Token: 0x06008EEF RID: 36591 RVA: 0x00045CD3 File Offset: 0x00043ED3
		' (set) Token: 0x06008EF0 RID: 36592 RVA: 0x00045CDD File Offset: 0x00043EDD
		Friend Overridable Property DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn

		' Token: 0x170034CA RID: 13514
		' (get) Token: 0x06008EF1 RID: 36593 RVA: 0x00045CE6 File Offset: 0x00043EE6
		' (set) Token: 0x06008EF2 RID: 36594 RVA: 0x00045CF0 File Offset: 0x00043EF0
		Friend Overridable Property DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn

		' Token: 0x170034CB RID: 13515
		' (get) Token: 0x06008EF3 RID: 36595 RVA: 0x00045CF9 File Offset: 0x00043EF9
		' (set) Token: 0x06008EF4 RID: 36596 RVA: 0x00045D03 File Offset: 0x00043F03
		Friend Overridable Property DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn

		' Token: 0x170034CC RID: 13516
		' (get) Token: 0x06008EF5 RID: 36597 RVA: 0x00045D0C File Offset: 0x00043F0C
		' (set) Token: 0x06008EF6 RID: 36598 RVA: 0x00045D16 File Offset: 0x00043F16
		Friend Overridable Property DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn

		' Token: 0x170034CD RID: 13517
		' (get) Token: 0x06008EF7 RID: 36599 RVA: 0x00045D1F File Offset: 0x00043F1F
		' (set) Token: 0x06008EF8 RID: 36600 RVA: 0x00045D29 File Offset: 0x00043F29
		Friend Overridable Property DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn

		' Token: 0x170034CE RID: 13518
		' (get) Token: 0x06008EF9 RID: 36601 RVA: 0x00045D32 File Offset: 0x00043F32
		' (set) Token: 0x06008EFA RID: 36602 RVA: 0x00045D3C File Offset: 0x00043F3C
		Friend Overridable Property DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn

		' Token: 0x170034CF RID: 13519
		' (get) Token: 0x06008EFB RID: 36603 RVA: 0x00045D45 File Offset: 0x00043F45
		' (set) Token: 0x06008EFC RID: 36604 RVA: 0x00045D4F File Offset: 0x00043F4F
		Friend Overridable Property DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn

		' Token: 0x170034D0 RID: 13520
		' (get) Token: 0x06008EFD RID: 36605 RVA: 0x00045D58 File Offset: 0x00043F58
		' (set) Token: 0x06008EFE RID: 36606 RVA: 0x00045D62 File Offset: 0x00043F62
		Friend Overridable Property DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn

		' Token: 0x170034D1 RID: 13521
		' (get) Token: 0x06008EFF RID: 36607 RVA: 0x00045D6B File Offset: 0x00043F6B
		' (set) Token: 0x06008F00 RID: 36608 RVA: 0x00045D75 File Offset: 0x00043F75
		Friend Overridable Property DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn

		' Token: 0x170034D2 RID: 13522
		' (get) Token: 0x06008F01 RID: 36609 RVA: 0x00045D7E File Offset: 0x00043F7E
		' (set) Token: 0x06008F02 RID: 36610 RVA: 0x00045D88 File Offset: 0x00043F88
		Friend Overridable Property DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn

		' Token: 0x170034D3 RID: 13523
		' (get) Token: 0x06008F03 RID: 36611 RVA: 0x00045D91 File Offset: 0x00043F91
		' (set) Token: 0x06008F04 RID: 36612 RVA: 0x00045D9B File Offset: 0x00043F9B
		Friend Overridable Property DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn

		' Token: 0x170034D4 RID: 13524
		' (get) Token: 0x06008F05 RID: 36613 RVA: 0x00045DA4 File Offset: 0x00043FA4
		' (set) Token: 0x06008F06 RID: 36614 RVA: 0x00045DAE File Offset: 0x00043FAE
		Friend Overridable Property DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn

		' Token: 0x170034D5 RID: 13525
		' (get) Token: 0x06008F07 RID: 36615 RVA: 0x00045DB7 File Offset: 0x00043FB7
		' (set) Token: 0x06008F08 RID: 36616 RVA: 0x00045DC1 File Offset: 0x00043FC1
		Friend Overridable Property DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn

		' Token: 0x170034D6 RID: 13526
		' (get) Token: 0x06008F09 RID: 36617 RVA: 0x00045DCA File Offset: 0x00043FCA
		' (set) Token: 0x06008F0A RID: 36618 RVA: 0x00045DD4 File Offset: 0x00043FD4
		Friend Overridable Property DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn

		' Token: 0x170034D7 RID: 13527
		' (get) Token: 0x06008F0B RID: 36619 RVA: 0x00045DDD File Offset: 0x00043FDD
		' (set) Token: 0x06008F0C RID: 36620 RVA: 0x00045DE7 File Offset: 0x00043FE7
		Friend Overridable Property DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn

		' Token: 0x170034D8 RID: 13528
		' (get) Token: 0x06008F0D RID: 36621 RVA: 0x00045DF0 File Offset: 0x00043FF0
		' (set) Token: 0x06008F0E RID: 36622 RVA: 0x00045DFA File Offset: 0x00043FFA
		Friend Overridable Property DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn

		' Token: 0x170034D9 RID: 13529
		' (get) Token: 0x06008F0F RID: 36623 RVA: 0x00045E03 File Offset: 0x00044003
		' (set) Token: 0x06008F10 RID: 36624 RVA: 0x00045E0D File Offset: 0x0004400D
		Friend Overridable Property DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn

		' Token: 0x170034DA RID: 13530
		' (get) Token: 0x06008F11 RID: 36625 RVA: 0x00045E16 File Offset: 0x00044016
		' (set) Token: 0x06008F12 RID: 36626 RVA: 0x00045E20 File Offset: 0x00044020
		Friend Overridable Property DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn

		' Token: 0x170034DB RID: 13531
		' (get) Token: 0x06008F13 RID: 36627 RVA: 0x00045E29 File Offset: 0x00044029
		' (set) Token: 0x06008F14 RID: 36628 RVA: 0x00045E33 File Offset: 0x00044033
		Friend Overridable Property DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn

		' Token: 0x170034DC RID: 13532
		' (get) Token: 0x06008F15 RID: 36629 RVA: 0x00045E3C File Offset: 0x0004403C
		' (set) Token: 0x06008F16 RID: 36630 RVA: 0x00045E46 File Offset: 0x00044046
		Friend Overridable Property DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn

		' Token: 0x170034DD RID: 13533
		' (get) Token: 0x06008F17 RID: 36631 RVA: 0x00045E4F File Offset: 0x0004404F
		' (set) Token: 0x06008F18 RID: 36632 RVA: 0x00045E59 File Offset: 0x00044059
		Friend Overridable Property DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn

		' Token: 0x170034DE RID: 13534
		' (get) Token: 0x06008F19 RID: 36633 RVA: 0x00045E62 File Offset: 0x00044062
		' (set) Token: 0x06008F1A RID: 36634 RVA: 0x00045E6C File Offset: 0x0004406C
		Friend Overridable Property DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn

		' Token: 0x170034DF RID: 13535
		' (get) Token: 0x06008F1B RID: 36635 RVA: 0x00045E75 File Offset: 0x00044075
		' (set) Token: 0x06008F1C RID: 36636 RVA: 0x00045E7F File Offset: 0x0004407F
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x170034E0 RID: 13536
		' (get) Token: 0x06008F1D RID: 36637 RVA: 0x00045E88 File Offset: 0x00044088
		' (set) Token: 0x06008F1E RID: 36638 RVA: 0x00045E92 File Offset: 0x00044092
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x170034E1 RID: 13537
		' (get) Token: 0x06008F1F RID: 36639 RVA: 0x00045E9B File Offset: 0x0004409B
		' (set) Token: 0x06008F20 RID: 36640 RVA: 0x00045EA5 File Offset: 0x000440A5
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x170034E2 RID: 13538
		' (get) Token: 0x06008F21 RID: 36641 RVA: 0x00045EAE File Offset: 0x000440AE
		' (set) Token: 0x06008F22 RID: 36642 RVA: 0x00045EB8 File Offset: 0x000440B8
		Friend Overridable Property colSerial As DataGridViewTextBoxColumn

		' Token: 0x170034E3 RID: 13539
		' (get) Token: 0x06008F23 RID: 36643 RVA: 0x00045EC1 File Offset: 0x000440C1
		' (set) Token: 0x06008F24 RID: 36644 RVA: 0x00045ECB File Offset: 0x000440CB
		Friend Overridable Property dgwSalesReturn As DataGridView

		' Token: 0x170034E4 RID: 13540
		' (get) Token: 0x06008F25 RID: 36645 RVA: 0x00045ED4 File Offset: 0x000440D4
		' (set) Token: 0x06008F26 RID: 36646 RVA: 0x00045EDE File Offset: 0x000440DE
		Friend Overridable Property DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn

		' Token: 0x170034E5 RID: 13541
		' (get) Token: 0x06008F27 RID: 36647 RVA: 0x00045EE7 File Offset: 0x000440E7
		' (set) Token: 0x06008F28 RID: 36648 RVA: 0x00045EF1 File Offset: 0x000440F1
		Friend Overridable Property DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn

		' Token: 0x170034E6 RID: 13542
		' (get) Token: 0x06008F29 RID: 36649 RVA: 0x00045EFA File Offset: 0x000440FA
		' (set) Token: 0x06008F2A RID: 36650 RVA: 0x00045F04 File Offset: 0x00044104
		Friend Overridable Property DataGridViewTextBoxColumn35 As DataGridViewTextBoxColumn

		' Token: 0x170034E7 RID: 13543
		' (get) Token: 0x06008F2B RID: 36651 RVA: 0x00045F0D File Offset: 0x0004410D
		' (set) Token: 0x06008F2C RID: 36652 RVA: 0x00045F17 File Offset: 0x00044117
		Friend Overridable Property DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn

		' Token: 0x170034E8 RID: 13544
		' (get) Token: 0x06008F2D RID: 36653 RVA: 0x00045F20 File Offset: 0x00044120
		' (set) Token: 0x06008F2E RID: 36654 RVA: 0x00045F2A File Offset: 0x0004412A
		Friend Overridable Property DataGridViewTextBoxColumn37 As DataGridViewTextBoxColumn

		' Token: 0x170034E9 RID: 13545
		' (get) Token: 0x06008F2F RID: 36655 RVA: 0x00045F33 File Offset: 0x00044133
		' (set) Token: 0x06008F30 RID: 36656 RVA: 0x00045F3D File Offset: 0x0004413D
		Friend Overridable Property DataGridViewTextBoxColumn38 As DataGridViewTextBoxColumn

		' Token: 0x170034EA RID: 13546
		' (get) Token: 0x06008F31 RID: 36657 RVA: 0x00045F46 File Offset: 0x00044146
		' (set) Token: 0x06008F32 RID: 36658 RVA: 0x00045F50 File Offset: 0x00044150
		Friend Overridable Property DataGridViewTextBoxColumn39 As DataGridViewTextBoxColumn

		' Token: 0x170034EB RID: 13547
		' (get) Token: 0x06008F33 RID: 36659 RVA: 0x00045F59 File Offset: 0x00044159
		' (set) Token: 0x06008F34 RID: 36660 RVA: 0x00045F63 File Offset: 0x00044163
		Friend Overridable Property DataGridViewTextBoxColumn40 As DataGridViewTextBoxColumn

		' Token: 0x170034EC RID: 13548
		' (get) Token: 0x06008F35 RID: 36661 RVA: 0x00045F6C File Offset: 0x0004416C
		' (set) Token: 0x06008F36 RID: 36662 RVA: 0x00045F76 File Offset: 0x00044176
		Friend Overridable Property DataGridViewTextBoxColumn41 As DataGridViewTextBoxColumn

		' Token: 0x170034ED RID: 13549
		' (get) Token: 0x06008F37 RID: 36663 RVA: 0x00045F7F File Offset: 0x0004417F
		' (set) Token: 0x06008F38 RID: 36664 RVA: 0x00045F89 File Offset: 0x00044189
		Friend Overridable Property DataGridViewTextBoxColumn42 As DataGridViewTextBoxColumn

		' Token: 0x170034EE RID: 13550
		' (get) Token: 0x06008F39 RID: 36665 RVA: 0x00045F92 File Offset: 0x00044192
		' (set) Token: 0x06008F3A RID: 36666 RVA: 0x00045F9C File Offset: 0x0004419C
		Friend Overridable Property DataGridViewTextBoxColumn43 As DataGridViewTextBoxColumn

		' Token: 0x170034EF RID: 13551
		' (get) Token: 0x06008F3B RID: 36667 RVA: 0x00045FA5 File Offset: 0x000441A5
		' (set) Token: 0x06008F3C RID: 36668 RVA: 0x00045FAF File Offset: 0x000441AF
		Friend Overridable Property DataGridViewTextBoxColumn44 As DataGridViewTextBoxColumn

		' Token: 0x170034F0 RID: 13552
		' (get) Token: 0x06008F3D RID: 36669 RVA: 0x00045FB8 File Offset: 0x000441B8
		' (set) Token: 0x06008F3E RID: 36670 RVA: 0x00045FC2 File Offset: 0x000441C2
		Friend Overridable Property DataGridViewTextBoxColumn45 As DataGridViewTextBoxColumn

		' Token: 0x170034F1 RID: 13553
		' (get) Token: 0x06008F3F RID: 36671 RVA: 0x00045FCB File Offset: 0x000441CB
		' (set) Token: 0x06008F40 RID: 36672 RVA: 0x00045FD5 File Offset: 0x000441D5
		Friend Overridable Property DataGridViewTextBoxColumn46 As DataGridViewTextBoxColumn

		' Token: 0x170034F2 RID: 13554
		' (get) Token: 0x06008F41 RID: 36673 RVA: 0x00045FDE File Offset: 0x000441DE
		' (set) Token: 0x06008F42 RID: 36674 RVA: 0x00045FE8 File Offset: 0x000441E8
		Friend Overridable Property DataGridViewTextBoxColumn47 As DataGridViewTextBoxColumn

		' Token: 0x170034F3 RID: 13555
		' (get) Token: 0x06008F43 RID: 36675 RVA: 0x00045FF1 File Offset: 0x000441F1
		' (set) Token: 0x06008F44 RID: 36676 RVA: 0x00045FFB File Offset: 0x000441FB
		Friend Overridable Property DataGridViewTextBoxColumn48 As DataGridViewTextBoxColumn

		' Token: 0x170034F4 RID: 13556
		' (get) Token: 0x06008F45 RID: 36677 RVA: 0x00046004 File Offset: 0x00044204
		' (set) Token: 0x06008F46 RID: 36678 RVA: 0x0004600E File Offset: 0x0004420E
		Friend Overridable Property DataGridViewTextBoxColumn49 As DataGridViewTextBoxColumn

		' Token: 0x170034F5 RID: 13557
		' (get) Token: 0x06008F47 RID: 36679 RVA: 0x00046017 File Offset: 0x00044217
		' (set) Token: 0x06008F48 RID: 36680 RVA: 0x00046021 File Offset: 0x00044221
		Friend Overridable Property DataGridViewTextBoxColumn50 As DataGridViewTextBoxColumn

		' Token: 0x170034F6 RID: 13558
		' (get) Token: 0x06008F49 RID: 36681 RVA: 0x0004602A File Offset: 0x0004422A
		' (set) Token: 0x06008F4A RID: 36682 RVA: 0x00046034 File Offset: 0x00044234
		Friend Overridable Property DataGridViewTextBoxColumn51 As DataGridViewTextBoxColumn

		' Token: 0x170034F7 RID: 13559
		' (get) Token: 0x06008F4B RID: 36683 RVA: 0x0004603D File Offset: 0x0004423D
		' (set) Token: 0x06008F4C RID: 36684 RVA: 0x00046047 File Offset: 0x00044247
		Friend Overridable Property DataGridViewTextBoxColumn52 As DataGridViewTextBoxColumn

		' Token: 0x170034F8 RID: 13560
		' (get) Token: 0x06008F4D RID: 36685 RVA: 0x00046050 File Offset: 0x00044250
		' (set) Token: 0x06008F4E RID: 36686 RVA: 0x0004605A File Offset: 0x0004425A
		Friend Overridable Property DataGridViewTextBoxColumn53 As DataGridViewTextBoxColumn

		' Token: 0x170034F9 RID: 13561
		' (get) Token: 0x06008F4F RID: 36687 RVA: 0x00046063 File Offset: 0x00044263
		' (set) Token: 0x06008F50 RID: 36688 RVA: 0x0004606D File Offset: 0x0004426D
		Friend Overridable Property DataGridViewTextBoxColumn54 As DataGridViewTextBoxColumn

		' Token: 0x170034FA RID: 13562
		' (get) Token: 0x06008F51 RID: 36689 RVA: 0x00046076 File Offset: 0x00044276
		' (set) Token: 0x06008F52 RID: 36690 RVA: 0x00046080 File Offset: 0x00044280
		Friend Overridable Property DataGridViewTextBoxColumn55 As DataGridViewTextBoxColumn

		' Token: 0x170034FB RID: 13563
		' (get) Token: 0x06008F53 RID: 36691 RVA: 0x00046089 File Offset: 0x00044289
		' (set) Token: 0x06008F54 RID: 36692 RVA: 0x00046093 File Offset: 0x00044293
		Friend Overridable Property DataGridViewTextBoxColumn56 As DataGridViewTextBoxColumn

		' Token: 0x170034FC RID: 13564
		' (get) Token: 0x06008F55 RID: 36693 RVA: 0x0004609C File Offset: 0x0004429C
		' (set) Token: 0x06008F56 RID: 36694 RVA: 0x000460A6 File Offset: 0x000442A6
		Friend Overridable Property DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn

		' Token: 0x170034FD RID: 13565
		' (get) Token: 0x06008F57 RID: 36695 RVA: 0x000460AF File Offset: 0x000442AF
		' (set) Token: 0x06008F58 RID: 36696 RVA: 0x000460B9 File Offset: 0x000442B9
		Friend Overridable Property dgwPurchaseReturn As DataGridView

		' Token: 0x170034FE RID: 13566
		' (get) Token: 0x06008F59 RID: 36697 RVA: 0x000460C2 File Offset: 0x000442C2
		' (set) Token: 0x06008F5A RID: 36698 RVA: 0x000460CC File Offset: 0x000442CC
		Friend Overridable Property DataGridViewTextBoxColumn58 As DataGridViewTextBoxColumn

		' Token: 0x170034FF RID: 13567
		' (get) Token: 0x06008F5B RID: 36699 RVA: 0x000460D5 File Offset: 0x000442D5
		' (set) Token: 0x06008F5C RID: 36700 RVA: 0x000460DF File Offset: 0x000442DF
		Friend Overridable Property DataGridViewTextBoxColumn59 As DataGridViewTextBoxColumn

		' Token: 0x17003500 RID: 13568
		' (get) Token: 0x06008F5D RID: 36701 RVA: 0x000460E8 File Offset: 0x000442E8
		' (set) Token: 0x06008F5E RID: 36702 RVA: 0x000460F2 File Offset: 0x000442F2
		Friend Overridable Property DataGridViewTextBoxColumn60 As DataGridViewTextBoxColumn

		' Token: 0x17003501 RID: 13569
		' (get) Token: 0x06008F5F RID: 36703 RVA: 0x000460FB File Offset: 0x000442FB
		' (set) Token: 0x06008F60 RID: 36704 RVA: 0x00046105 File Offset: 0x00044305
		Friend Overridable Property DataGridViewTextBoxColumn61 As DataGridViewTextBoxColumn

		' Token: 0x17003502 RID: 13570
		' (get) Token: 0x06008F61 RID: 36705 RVA: 0x0004610E File Offset: 0x0004430E
		' (set) Token: 0x06008F62 RID: 36706 RVA: 0x00046118 File Offset: 0x00044318
		Friend Overridable Property DataGridViewTextBoxColumn62 As DataGridViewTextBoxColumn

		' Token: 0x17003503 RID: 13571
		' (get) Token: 0x06008F63 RID: 36707 RVA: 0x00046121 File Offset: 0x00044321
		' (set) Token: 0x06008F64 RID: 36708 RVA: 0x0004612B File Offset: 0x0004432B
		Friend Overridable Property DataGridViewTextBoxColumn63 As DataGridViewTextBoxColumn

		' Token: 0x17003504 RID: 13572
		' (get) Token: 0x06008F65 RID: 36709 RVA: 0x00046134 File Offset: 0x00044334
		' (set) Token: 0x06008F66 RID: 36710 RVA: 0x0004613E File Offset: 0x0004433E
		Friend Overridable Property DataGridViewTextBoxColumn64 As DataGridViewTextBoxColumn

		' Token: 0x17003505 RID: 13573
		' (get) Token: 0x06008F67 RID: 36711 RVA: 0x00046147 File Offset: 0x00044347
		' (set) Token: 0x06008F68 RID: 36712 RVA: 0x00046151 File Offset: 0x00044351
		Friend Overridable Property DataGridViewTextBoxColumn65 As DataGridViewTextBoxColumn

		' Token: 0x17003506 RID: 13574
		' (get) Token: 0x06008F69 RID: 36713 RVA: 0x0004615A File Offset: 0x0004435A
		' (set) Token: 0x06008F6A RID: 36714 RVA: 0x00046164 File Offset: 0x00044364
		Friend Overridable Property DataGridViewTextBoxColumn66 As DataGridViewTextBoxColumn

		' Token: 0x17003507 RID: 13575
		' (get) Token: 0x06008F6B RID: 36715 RVA: 0x0004616D File Offset: 0x0004436D
		' (set) Token: 0x06008F6C RID: 36716 RVA: 0x00046177 File Offset: 0x00044377
		Friend Overridable Property DataGridViewTextBoxColumn67 As DataGridViewTextBoxColumn

		' Token: 0x17003508 RID: 13576
		' (get) Token: 0x06008F6D RID: 36717 RVA: 0x00046180 File Offset: 0x00044380
		' (set) Token: 0x06008F6E RID: 36718 RVA: 0x0004618A File Offset: 0x0004438A
		Friend Overridable Property DataGridViewTextBoxColumn68 As DataGridViewTextBoxColumn

		' Token: 0x17003509 RID: 13577
		' (get) Token: 0x06008F6F RID: 36719 RVA: 0x00046193 File Offset: 0x00044393
		' (set) Token: 0x06008F70 RID: 36720 RVA: 0x0004619D File Offset: 0x0004439D
		Friend Overridable Property DataGridViewTextBoxColumn69 As DataGridViewTextBoxColumn

		' Token: 0x1700350A RID: 13578
		' (get) Token: 0x06008F71 RID: 36721 RVA: 0x000461A6 File Offset: 0x000443A6
		' (set) Token: 0x06008F72 RID: 36722 RVA: 0x000461B0 File Offset: 0x000443B0
		Friend Overridable Property DataGridViewTextBoxColumn70 As DataGridViewTextBoxColumn

		' Token: 0x1700350B RID: 13579
		' (get) Token: 0x06008F73 RID: 36723 RVA: 0x000461B9 File Offset: 0x000443B9
		' (set) Token: 0x06008F74 RID: 36724 RVA: 0x000461C3 File Offset: 0x000443C3
		Friend Overridable Property DataGridViewTextBoxColumn71 As DataGridViewTextBoxColumn

		' Token: 0x1700350C RID: 13580
		' (get) Token: 0x06008F75 RID: 36725 RVA: 0x000461CC File Offset: 0x000443CC
		' (set) Token: 0x06008F76 RID: 36726 RVA: 0x000461D6 File Offset: 0x000443D6
		Friend Overridable Property DataGridViewTextBoxColumn72 As DataGridViewTextBoxColumn

		' Token: 0x1700350D RID: 13581
		' (get) Token: 0x06008F77 RID: 36727 RVA: 0x000461DF File Offset: 0x000443DF
		' (set) Token: 0x06008F78 RID: 36728 RVA: 0x000461E9 File Offset: 0x000443E9
		Friend Overridable Property DataGridViewTextBoxColumn73 As DataGridViewTextBoxColumn

		' Token: 0x1700350E RID: 13582
		' (get) Token: 0x06008F79 RID: 36729 RVA: 0x000461F2 File Offset: 0x000443F2
		' (set) Token: 0x06008F7A RID: 36730 RVA: 0x000461FC File Offset: 0x000443FC
		Friend Overridable Property DataGridViewTextBoxColumn74 As DataGridViewTextBoxColumn

		' Token: 0x1700350F RID: 13583
		' (get) Token: 0x06008F7B RID: 36731 RVA: 0x00046205 File Offset: 0x00044405
		' (set) Token: 0x06008F7C RID: 36732 RVA: 0x0004620F File Offset: 0x0004440F
		Friend Overridable Property DataGridViewTextBoxColumn75 As DataGridViewTextBoxColumn

		' Token: 0x17003510 RID: 13584
		' (get) Token: 0x06008F7D RID: 36733 RVA: 0x00046218 File Offset: 0x00044418
		' (set) Token: 0x06008F7E RID: 36734 RVA: 0x00046222 File Offset: 0x00044422
		Friend Overridable Property DataGridViewTextBoxColumn76 As DataGridViewTextBoxColumn

		' Token: 0x17003511 RID: 13585
		' (get) Token: 0x06008F7F RID: 36735 RVA: 0x0004622B File Offset: 0x0004442B
		' (set) Token: 0x06008F80 RID: 36736 RVA: 0x00046235 File Offset: 0x00044435
		Friend Overridable Property DataGridViewTextBoxColumn77 As DataGridViewTextBoxColumn

		' Token: 0x17003512 RID: 13586
		' (get) Token: 0x06008F81 RID: 36737 RVA: 0x0004623E File Offset: 0x0004443E
		' (set) Token: 0x06008F82 RID: 36738 RVA: 0x00046248 File Offset: 0x00044448
		Friend Overridable Property DataGridViewTextBoxColumn78 As DataGridViewTextBoxColumn

		' Token: 0x17003513 RID: 13587
		' (get) Token: 0x06008F83 RID: 36739 RVA: 0x00046251 File Offset: 0x00044451
		' (set) Token: 0x06008F84 RID: 36740 RVA: 0x0004625B File Offset: 0x0004445B
		Friend Overridable Property DataGridViewTextBoxColumn79 As DataGridViewTextBoxColumn

		' Token: 0x17003514 RID: 13588
		' (get) Token: 0x06008F85 RID: 36741 RVA: 0x00046264 File Offset: 0x00044464
		' (set) Token: 0x06008F86 RID: 36742 RVA: 0x0004626E File Offset: 0x0004446E
		Friend Overridable Property DataGridViewTextBoxColumn80 As DataGridViewTextBoxColumn

		' Token: 0x17003515 RID: 13589
		' (get) Token: 0x06008F87 RID: 36743 RVA: 0x00046277 File Offset: 0x00044477
		' (set) Token: 0x06008F88 RID: 36744 RVA: 0x00046281 File Offset: 0x00044481
		Friend Overridable Property DataGridViewTextBoxColumn81 As DataGridViewTextBoxColumn

		' Token: 0x17003516 RID: 13590
		' (get) Token: 0x06008F89 RID: 36745 RVA: 0x0004628A File Offset: 0x0004448A
		' (set) Token: 0x06008F8A RID: 36746 RVA: 0x00046294 File Offset: 0x00044494
		Friend Overridable Property DataGridViewTextBoxColumn82 As DataGridViewTextBoxColumn

		' Token: 0x17003517 RID: 13591
		' (get) Token: 0x06008F8B RID: 36747 RVA: 0x0004629D File Offset: 0x0004449D
		' (set) Token: 0x06008F8C RID: 36748 RVA: 0x000462A7 File Offset: 0x000444A7
		Friend Overridable Property Column37 As DataGridViewTextBoxColumn

		' Token: 0x17003518 RID: 13592
		' (get) Token: 0x06008F8D RID: 36749 RVA: 0x000462B0 File Offset: 0x000444B0
		' (set) Token: 0x06008F8E RID: 36750 RVA: 0x000462BA File Offset: 0x000444BA
		Friend Overridable Property Column36 As DataGridViewTextBoxColumn

		' Token: 0x17003519 RID: 13593
		' (get) Token: 0x06008F8F RID: 36751 RVA: 0x000462C3 File Offset: 0x000444C3
		' (set) Token: 0x06008F90 RID: 36752 RVA: 0x0068A2B0 File Offset: 0x006884B0
		Private _txtSerialNumber As TextBox
		Friend Overridable Property txtSerialNumber As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSerialNumber
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSerialNumber_TextChanged
				Dim textBox As TextBox = Me._txtSerialNumber
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSerialNumber = value
				textBox = Me._txtSerialNumber
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700351A RID: 13594
		' (get) Token: 0x06008F91 RID: 36753 RVA: 0x000462CD File Offset: 0x000444CD
		' (set) Token: 0x06008F92 RID: 36754 RVA: 0x000462D7 File Offset: 0x000444D7
		Friend Overridable Property Label5 As Label

		' Token: 0x1700351B RID: 13595
		' (get) Token: 0x06008F93 RID: 36755 RVA: 0x000462E0 File Offset: 0x000444E0
		' (set) Token: 0x06008F94 RID: 36756 RVA: 0x000462EA File Offset: 0x000444EA
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x1700351C RID: 13596
		' (get) Token: 0x06008F95 RID: 36757 RVA: 0x000462F3 File Offset: 0x000444F3
		' (set) Token: 0x06008F96 RID: 36758 RVA: 0x000462FD File Offset: 0x000444FD
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x1700351D RID: 13597
		' (get) Token: 0x06008F97 RID: 36759 RVA: 0x00046306 File Offset: 0x00044506
		' (set) Token: 0x06008F98 RID: 36760 RVA: 0x00046310 File Offset: 0x00044510
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x1700351E RID: 13598
		' (get) Token: 0x06008F99 RID: 36761 RVA: 0x00046319 File Offset: 0x00044519
		' (set) Token: 0x06008F9A RID: 36762 RVA: 0x00046323 File Offset: 0x00044523
		Friend Overridable Property GroupBox5 As GroupBox

		' Token: 0x1700351F RID: 13599
		' (get) Token: 0x06008F9B RID: 36763 RVA: 0x0004632C File Offset: 0x0004452C
		' (set) Token: 0x06008F9C RID: 36764 RVA: 0x00046336 File Offset: 0x00044536
		Friend Overridable Property GroupBox6 As GroupBox

		' Token: 0x06008F9D RID: 36765 RVA: 0x0068A2F4 File Offset: 0x006884F4
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Value = DateAndTime.Today
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

		' Token: 0x06008F9E RID: 36766 RVA: 0x0068A3C8 File Offset: 0x006885C8
		Public Sub Getdata(Optional whereclause As String = "")
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.TaxType), RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Invoice_Product.TaxableAmt) + (Invoice_Product.Discount)) / (Invoice_Product.Qty)), Invoice_Product.Qty,RTRIM(SalesUnit),Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt, Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt,Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount, RTRIM(Product.ProductCode), RTRIM(Invoice_Product.Barcode),RTRIM(Invoice_Product.IM1),RTRIM(Invoice_Product.IM2),RTRIM(Invoice_Product.Descr),RTRIM(Invoice_Product.Batch),RTRIM(Invoice_Product.Mfg),RTRIM(Invoice_Product.Exp),RTRIM(Invoice_Product.Size),RTRIM(Invoice_Product.Colour) , psf.serialno" & vbCrLf & "                                    FROM InvoiceInfo " & vbCrLf & "                                    INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID " & vbCrLf & "                                    INNER JOIN Product ON Invoice_Product.ProductID = Product.PID " & vbCrLf & "                                    INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID " & vbCrLf & "                                    INNER JOIN tbl_product_serial_sale psf on psf.productid = Product.PID and psf.invoice_no = InvoiceInfo.InvoiceNo" & vbCrLf & "                                    where InvoiceDate between @d1 and @d2"
				Dim flag As Boolean = whereclause.Trim().Length > 0
				If flag Then
					text += whereclause
				End If
				text += " order by Invoiceinfo.InvoiceDate"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008F9F RID: 36767 RVA: 0x0068A75C File Offset: 0x0068895C
		Public Sub GetdataPurchase(Optional whereclause As String = "")
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(Stock.InvoiceNo), Stock.Date,Stock.TaxType, RTRIM(Stock.SupplierInvoiceNo),Stock.SupplierInvoiceDate, RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((Stock_Product.TaxableAmt)+(Stock_Product.DiscountAmt)) / (Stock_Product.Qty)), Stock_Product.Qty,RTRIM(PurchaseUnit),Stock_Product.DiscountPer, Stock_Product.DiscountAmt, Stock_Product.CGSTPer, Stock_Product.CGSTAmt, Stock_Product.SGSTPer, Stock_Product.SGSTAmt, Stock_Product.IGSTPer, Stock_Product.IGSTAmt, Stock_Product.CESSPer, Stock_Product.CESSAmt,Stock_Product.TotalAmount,RTRIM(Stock.ReferenceNo2), RTRIM(Product.ProductCode), RTRIM(Stock_Product.Barcode),RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2), psf.serialno1" & vbCrLf & "                                    FROM Stock " & vbCrLf & "                                    INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID " & vbCrLf & "                                    INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID " & vbCrLf & "                                    INNER JOIN Product ON Stock_Product.ProductID = Product.PID " & vbCrLf & "                                    INNER JOIN tbl_product_serial_final psf on psf.productid = Product.PID and psf.invoice_no = stock.InvoiceNo" & vbCrLf & "                                    where Stock.Date between @d1 and @d2 "
				Dim flag As Boolean = whereclause.Trim().Length > 0
				If flag Then
					text += whereclause
				End If
				text += " order by Stock.Date"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgwPurchase.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgwPurchase.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35) })
				End While
				ModCommonClasses.con.Close()
				Me.dgwPurchase.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008FA0 RID: 36768 RVA: 0x0068AB20 File Offset: 0x00688D20
		Public Sub GetdataSalesReturn(Optional whereclause As String = "")
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(SalesReturn.SRNo), SalesReturn.Date, RTRIM(InvoiceInfo.TaxType), RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(Customer.Name), RTRIM(Customer.State), RTRIM(Customer.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((SalesReturn_Join.TaxableAmt) + (SalesReturn_Join.DiscAmt)) / (SalesReturn_Join.ReturnQty)), SalesReturn_Join.ReturnQty,RTRIM(SalesUnit), SalesReturn_Join.DiscPer, SalesReturn_Join.DiscAmt, SalesReturn_Join.CGSTPer, SalesReturn_Join.CGSTAmt, SalesReturn_Join.SGSTPer, SalesReturn_Join.SGSTAmt, SalesReturn_Join.IGSTPer, SalesReturn_Join.IGSTAmt, SalesReturn_Join.CESSPer, SalesReturn_Join.CESSAmt, SalesReturn_Join.TotalAmount,RTRIM(SalesReturn_Join.Barcode), psf.serialno" & vbCrLf & "                                    FROM SalesReturn " & vbCrLf & "                                    INNER JOIN InvoiceInfo ON SalesReturn.SalesID = InvoiceInfo.Inv_ID " & vbCrLf & "                                    INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID " & vbCrLf & "                                    INNER JOIN SalesReturn_Join ON SalesReturn.SR_ID = SalesReturn_Join.SalesReturnID " & vbCrLf & "                                    INNER JOIN Product ON SalesReturn_Join.ProductID = Product.PID " & vbCrLf & "                                    INNER JOIN tbl_product_serial_saleReturn psf on psf.productid = Product.PID and psf.invoice_no = InvoiceInfo.InvoiceNo" & vbCrLf & "                                    where SalesReturn.Date between @d1 and @d2"
				Dim flag As Boolean = whereclause.Trim().Length > 0
				If flag Then
					text += whereclause
				End If
				text += " order by SalesReturn.Date"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgwSalesReturn.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgwSalesReturn.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25) })
				End While
				ModCommonClasses.con.Close()
				Me.dgwSalesReturn.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008FA1 RID: 36769 RVA: 0x0068AE38 File Offset: 0x00689038
		Public Sub GetdataPurchaseReturn(Optional whereclause As String = "")
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(PurchaseReturn.PRNo), PurchaseReturn.Date, RTRIM(Stock.TaxType), RTRIM(Stock.InvoiceNo), Stock.Date,RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((PurchaseReturn_Join.TaxableAmt) + (PurchaseReturn_Join.DiscAmt)) / (PurchaseReturn_Join.ReturnQty)), PurchaseReturn_Join.ReturnQty,RTRIM(PurchaseUnit),PurchaseReturn_Join.DiscPer, PurchaseReturn_Join.DiscAmt, PurchaseReturn_Join.CGSTPer, PurchaseReturn_Join.CGSTAmt, PurchaseReturn_Join.SGSTPer, PurchaseReturn_Join.SGSTAmt, PurchaseReturn_Join.IGSTPer, PurchaseReturn_Join.IGSTAmt, PurchaseReturn_Join.CESSPer, PurchaseReturn_Join.CESSAmt, PurchaseReturn_Join.TotalAmount, RTRIM(PurchaseReturn_Join.Barcode), psf.serialno" & vbCrLf & "                                    FROM PurchaseReturn " & vbCrLf & "                                    INNER JOIN PurchaseReturn_Join ON PurchaseReturn.PR_ID = PurchaseReturn_Join.PurchaseReturnID " & vbCrLf & "                                    INNER JOIN Product ON PurchaseReturn_Join.ProductID = Product.PID " & vbCrLf & "                                    INNER JOIN Stock ON PurchaseReturn.PurchaseID = Stock.ST_ID " & vbCrLf & "                                    INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID " & vbCrLf & "                                    INNER JOIN tbl_product_serial_purchaseReturn psf on psf.productid = Product.PID " & vbCrLf & "                                    where PurchaseReturn.Date between @d1 and @d2"
				Dim flag As Boolean = whereclause.Trim().Length > 0
				If flag Then
					text += whereclause
				End If
				text += " order by PurchaseReturn.Date"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgwPurchaseReturn.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgwPurchaseReturn.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25) })
				End While
				ModCommonClasses.con.Close()
				Me.dgwPurchaseReturn.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008FA2 RID: 36770 RVA: 0x0068B148 File Offset: 0x00689348
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata("")
			Me.GetdataPurchase("")
			Me.GetdataSalesReturn("")
			Me.GetdataPurchaseReturn("")
			Me.Calculate()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06008FA3 RID: 36771 RVA: 0x0068B208 File Offset: 0x00689408
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

		' Token: 0x06008FA4 RID: 36772 RVA: 0x0068B380 File Offset: 0x00689580
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

		' Token: 0x06008FA5 RID: 36773 RVA: 0x0068B44C File Offset: 0x0068964C
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

		' Token: 0x06008FA6 RID: 36774 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06008FA7 RID: 36775 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06008FA8 RID: 36776 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06008FA9 RID: 36777 RVA: 0x0068B518 File Offset: 0x00689718
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

		' Token: 0x06008FAA RID: 36778 RVA: 0x0068B600 File Offset: 0x00689800
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata("")
			Me.GetdataPurchase("")
			Me.GetdataSalesReturn("")
			Me.GetdataPurchaseReturn("")
		End Sub

		' Token: 0x06008FAB RID: 36779 RVA: 0x0068B658 File Offset: 0x00689858
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox1.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Select the search category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.ComboBox1.Focus()
			Else
				Try
					Dim text As String = ""
					Dim text2 As String = ""
					Dim text3 As String = ""
					Dim text4 As String = ""
					Select Case Me.ComboBox1.SelectedIndex
						Case 0
							text = " and InvoiceNo=N'" + Me.TextBox1.Text + "'"
						Case 1
							text = " and Customer.Name=N'" + Me.TextBox1.Text + "'"
						Case 2
							text = " and Product.ProductName=N'" + Me.TextBox1.Text + "'"
						Case 3
							text = " and Product.ProductCode=N'" + Me.TextBox1.Text + "'"
						Case 4
							text = " and Invoice_Product.Barcode=N'" + Me.TextBox1.Text + "'"
						Case 5
							text = " and Invoice_Product.IM1=N'" + Me.TextBox1.Text + "'"
						Case 6
							text = " and Invoice_Product.IM2=N'" + Me.TextBox1.Text + "'"
						Case 7
							text = " and Invoice_Product.Descr like N'" + Me.TextBox1.Text + "%'"
						Case 8
							text = " and Invoice_Product.Batch like N'" + Me.TextBox1.Text + "%'"
						Case 9
							text = " and Invoice_Product.Size like N'" + Me.TextBox1.Text + "%'"
						Case 10
							text = " and Invoice_Product.Colour like N'" + Me.TextBox1.Text + "%'"
						Case 11
							text2 = " and InvoiceNo=N'" + Me.TextBox1.Text + "'"
						Case 12
							text2 = " and Customer.Name=N'" + Me.TextBox1.Text + "'"
						Case 13
							text2 = " and Product.ProductName=N'" + Me.TextBox1.Text + "'"
						Case 14
							text2 = " and Product.ProductCode=N'" + Me.TextBox1.Text + "'"
						Case 15
							text3 = " and InvoiceNo=N'" + Me.TextBox1.Text + "'"
						Case 16
							text3 = " and Customer.Name=N'" + Me.TextBox1.Text + "'"
						Case 17
							text3 = " and Product.ProductName=N'" + Me.TextBox1.Text + "'"
						Case 18
							text3 = " and Product.ProductCode=N'" + Me.TextBox1.Text + "'"
						Case 19
							text4 = " and InvoiceNo=N'" + Me.TextBox1.Text + "'"
						Case 20
							text4 = " and Customer.Name=N'" + Me.TextBox1.Text + "'"
						Case 21
							text4 = " and Product.ProductName=N'" + Me.TextBox1.Text + "'"
						Case 22
							text4 = " and Product.ProductCode=N'" + Me.TextBox1.Text + "'"
					End Select
					Dim flag2 As Boolean = text.Trim().Length > 0
					If flag2 Then
						Me.Getdata(text)
						Me.dgwPurchase.Rows.Clear()
						Me.dgwSalesReturn.Rows.Clear()
						Me.dgwPurchaseReturn.Rows.Clear()
					End If
					Dim flag3 As Boolean = text3.Trim().Length > 0
					If flag3 Then
						Me.GetdataPurchase(text3)
						Me.dgw.Rows.Clear()
						Me.dgwSalesReturn.Rows.Clear()
						Me.dgwPurchaseReturn.Rows.Clear()
					End If
					Dim flag4 As Boolean = text2.Trim().Length > 0
					If flag4 Then
						Me.GetdataSalesReturn(text2)
						Me.dgwPurchase.Rows.Clear()
						Me.dgw.Rows.Clear()
						Me.dgwPurchaseReturn.Rows.Clear()
					End If
					Dim flag5 As Boolean = text4.Trim().Length > 0
					If flag5 Then
						Me.GetdataPurchaseReturn(text4)
						Me.dgwPurchase.Rows.Clear()
						Me.dgwSalesReturn.Rows.Clear()
						Me.dgw.Rows.Clear()
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
				Me.Calculate()
			End If
		End Sub

		' Token: 0x06008FAC RID: 36780 RVA: 0x0004633F File Offset: 0x0004453F
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox1.Focus()
			Me.ComboBox2.SelectedIndex = -1
		End Sub

		' Token: 0x06008FAD RID: 36781 RVA: 0x00046374 File Offset: 0x00044574
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.TextBox1.Focus()
			Me.ComboBox2.SelectedIndex = -1
		End Sub

		' Token: 0x06008FAE RID: 36782 RVA: 0x0068BBAC File Offset: 0x00689DAC
		Private Sub dgw_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				Me.cpy = dataGridViewRow.Cells(0).Value.ToString()
				Clipboard.SetDataObject(Me.cpy)
				MessageBox.Show("Invoice Number is Copied", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06008FAF RID: 36783 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSalesInvoiceRecord_GSTR_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06008FB0 RID: 36784 RVA: 0x0068BC2C File Offset: 0x00689E2C
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))
						End If

				Next
				Me.lblTotalAmount.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.lblTotalAmount.Text = "Total : " + Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
		End Sub

		' Token: 0x06008FB1 RID: 36785 RVA: 0x0068BD44 File Offset: 0x00689F44
		Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.ComboBox1.SelectedIndex = -1
				Me.TextBox1.Text = ""
				Dim text As String = ""
				Dim flag As Boolean = Me.ComboBox2.SelectedIndex = 0
				If flag Then
					text = " and TaxType='GST'"
				Else
					Dim flag2 As Boolean = Me.ComboBox2.SelectedIndex = 1
					If flag2 Then
						text = " and TaxType='NON GST'"
					End If
				End If
				Me.Getdata(text)
				Me.GetdataPurchase(text)
				Me.GetdataSalesReturn(text)
				Me.GetdataPurchaseReturn(text)
			Catch ex As Exception
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06008FB2 RID: 36786 RVA: 0x0068BDF4 File Offset: 0x00689FF4
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox1.Focus()
			Me.ComboBox2.SelectedIndex = -1
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x06008FB3 RID: 36787 RVA: 0x0068BE44 File Offset: 0x0068A044
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
						xlworkbook.Worksheets.Add(dataTable, "Export File")
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008FB4 RID: 36788 RVA: 0x0068C0F0 File Offset: 0x0068A2F0
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Try
				Me.ComboBox1.SelectedIndex = -1
				Me.TextBox1.Text = ""
				Me.ComboBox2.SelectedIndex = -1
				Me.Getdata("")
				Me.GetdataPurchase("")
				Me.GetdataSalesReturn("")
				Me.GetdataPurchaseReturn("")
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06008FB5 RID: 36789 RVA: 0x0068C198 File Offset: 0x0068A398
		Private Sub txtSerialNumber_TextChanged(sender As Object, e As EventArgs)
			Dim text As String = ""
			Dim text2 As String = ""
			Dim flag As Boolean = Me.txtSerialNumber.Text.Trim().Length > 0
			If flag Then
				text = " And psf.serialno like '" + Me.txtSerialNumber.Text + "%'"
				text2 = " And psf.serialno1 like '" + Me.txtSerialNumber.Text + "%'"
			End If
			Me.Getdata(text)
			Me.GetdataPurchase(text2)
			Me.GetdataSalesReturn(text)
			Me.GetdataPurchaseReturn(text)
		End Sub

		' Token: 0x04003F84 RID: 16260
		Private cpy As String

		' Token: 0x020001F6 RID: 502
		Public Enum SearchCategory
			' Token: 0x04003F86 RID: 16262
			SalesInoviceNo
			' Token: 0x04003F87 RID: 16263
			SalesCustomerName
			' Token: 0x04003F88 RID: 16264
			SalesProductName
			' Token: 0x04003F89 RID: 16265
			SalesProductCode
			' Token: 0x04003F8A RID: 16266
			SalesBarcode
			' Token: 0x04003F8B RID: 16267
			SalesIMEI1
			' Token: 0x04003F8C RID: 16268
			SalesIMEI2
			' Token: 0x04003F8D RID: 16269
			SalesDescription
			' Token: 0x04003F8E RID: 16270
			SalesBatch
			' Token: 0x04003F8F RID: 16271
			SalesSize
			' Token: 0x04003F90 RID: 16272
			SalesColour
			' Token: 0x04003F91 RID: 16273
			SalesReturnInoviceNo
			' Token: 0x04003F92 RID: 16274
			SalesReturnCustomerName
			' Token: 0x04003F93 RID: 16275
			SalesReturnProductName
			' Token: 0x04003F94 RID: 16276
			SalesReturnProductCode
			' Token: 0x04003F95 RID: 16277
			PurchaseInoviceNo
			' Token: 0x04003F96 RID: 16278
			PurchaseCustomerName
			' Token: 0x04003F97 RID: 16279
			PurchaseProductName
			' Token: 0x04003F98 RID: 16280
			PurchaseProductCode
			' Token: 0x04003F99 RID: 16281
			PurchaseReturnInoviceNo
			' Token: 0x04003F9A RID: 16282
			PurchaseReturnCustomerName
			' Token: 0x04003F9B RID: 16283
			PurchaseReturnProductName
			' Token: 0x04003F9C RID: 16284
			PurchaseReturnProductCode
		End Enum
	End Class
End Namespace
