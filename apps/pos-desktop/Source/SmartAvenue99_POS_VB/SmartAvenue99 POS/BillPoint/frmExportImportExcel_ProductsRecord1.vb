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
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x0200010F RID: 271
	<DesignerGenerated()>
	Public Partial Class frmExportImportExcel_ProductsRecord1
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002CB0 RID: 11440 RVA: 0x0001C71B File Offset: 0x0001A91B
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmExportImportExcel_ProductsRecord_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmExportImportExcel_ProductsRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17001161 RID: 4449
		' (get) Token: 0x06002CB3 RID: 11443 RVA: 0x0001C74D File Offset: 0x0001A94D
		' (set) Token: 0x06002CB4 RID: 11444 RVA: 0x0001C757 File Offset: 0x0001A957
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17001162 RID: 4450
		' (get) Token: 0x06002CB5 RID: 11445 RVA: 0x0001C760 File Offset: 0x0001A960
		' (set) Token: 0x06002CB6 RID: 11446 RVA: 0x0001C76A File Offset: 0x0001A96A
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17001163 RID: 4451
		' (get) Token: 0x06002CB7 RID: 11447 RVA: 0x0001C773 File Offset: 0x0001A973
		' (set) Token: 0x06002CB8 RID: 11448 RVA: 0x001BD6B4 File Offset: 0x001BB8B4
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

		' Token: 0x17001164 RID: 4452
		' (get) Token: 0x06002CB9 RID: 11449 RVA: 0x0001C77D File Offset: 0x0001A97D
		' (set) Token: 0x06002CBA RID: 11450 RVA: 0x0001C787 File Offset: 0x0001A987
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17001165 RID: 4453
		' (get) Token: 0x06002CBB RID: 11451 RVA: 0x0001C790 File Offset: 0x0001A990
		' (set) Token: 0x06002CBC RID: 11452 RVA: 0x0001C79A File Offset: 0x0001A99A
		Friend Overridable Property Label1 As Label

		' Token: 0x17001166 RID: 4454
		' (get) Token: 0x06002CBD RID: 11453 RVA: 0x0001C7A3 File Offset: 0x0001A9A3
		' (set) Token: 0x06002CBE RID: 11454 RVA: 0x0001C7AD File Offset: 0x0001A9AD
		Friend Overridable Property Label3 As Label

		' Token: 0x17001167 RID: 4455
		' (get) Token: 0x06002CBF RID: 11455 RVA: 0x0001C7B6 File Offset: 0x0001A9B6
		' (set) Token: 0x06002CC0 RID: 11456 RVA: 0x001BD6F8 File Offset: 0x001BB8F8
		Private _txtProductName As TextBox
		Friend Overridable Property txtProductName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtProductName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtProductName_TextChanged
				Dim textBox As TextBox = Me._txtProductName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtProductName = value
				textBox = Me._txtProductName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001168 RID: 4456
		' (get) Token: 0x06002CC1 RID: 11457 RVA: 0x0001C7C0 File Offset: 0x0001A9C0
		' (set) Token: 0x06002CC2 RID: 11458 RVA: 0x0001C7CA File Offset: 0x0001A9CA
		Friend Overridable Property lblSet As Label

		' Token: 0x17001169 RID: 4457
		' (get) Token: 0x06002CC3 RID: 11459 RVA: 0x0001C7D3 File Offset: 0x0001A9D3
		' (set) Token: 0x06002CC4 RID: 11460 RVA: 0x001BD73C File Offset: 0x001BB93C
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

		' Token: 0x1700116A RID: 4458
		' (get) Token: 0x06002CC5 RID: 11461 RVA: 0x0001C7DD File Offset: 0x0001A9DD
		' (set) Token: 0x06002CC6 RID: 11462 RVA: 0x001BD780 File Offset: 0x001BB980
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

		' Token: 0x1700116B RID: 4459
		' (get) Token: 0x06002CC7 RID: 11463 RVA: 0x0001C7E7 File Offset: 0x0001A9E7
		' (set) Token: 0x06002CC8 RID: 11464 RVA: 0x0001C7F1 File Offset: 0x0001A9F1
		Friend Overridable Property txtID As TextBox

		' Token: 0x1700116C RID: 4460
		' (get) Token: 0x06002CC9 RID: 11465 RVA: 0x0001C7FA File Offset: 0x0001A9FA
		' (set) Token: 0x06002CCA RID: 11466 RVA: 0x0001C804 File Offset: 0x0001AA04
		Friend Overridable Property txtProductCode As TextBox

		' Token: 0x1700116D RID: 4461
		' (get) Token: 0x06002CCB RID: 11467 RVA: 0x0001C80D File Offset: 0x0001AA0D
		' (set) Token: 0x06002CCC RID: 11468 RVA: 0x001BD7C4 File Offset: 0x001BB9C4
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

		' Token: 0x1700116E RID: 4462
		' (get) Token: 0x06002CCD RID: 11469 RVA: 0x0001C817 File Offset: 0x0001AA17
		' (set) Token: 0x06002CCE RID: 11470 RVA: 0x0001C821 File Offset: 0x0001AA21
		Friend Overridable Property FolderBrowserDialog1 As FolderBrowserDialog

		' Token: 0x1700116F RID: 4463
		' (get) Token: 0x06002CCF RID: 11471 RVA: 0x0001C82A File Offset: 0x0001AA2A
		' (set) Token: 0x06002CD0 RID: 11472 RVA: 0x0001C834 File Offset: 0x0001AA34
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17001170 RID: 4464
		' (get) Token: 0x06002CD1 RID: 11473 RVA: 0x0001C83D File Offset: 0x0001AA3D
		' (set) Token: 0x06002CD2 RID: 11474 RVA: 0x0001C847 File Offset: 0x0001AA47
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17001171 RID: 4465
		' (get) Token: 0x06002CD3 RID: 11475 RVA: 0x0001C850 File Offset: 0x0001AA50
		' (set) Token: 0x06002CD4 RID: 11476 RVA: 0x0001C85A File Offset: 0x0001AA5A
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17001172 RID: 4466
		' (get) Token: 0x06002CD5 RID: 11477 RVA: 0x0001C863 File Offset: 0x0001AA63
		' (set) Token: 0x06002CD6 RID: 11478 RVA: 0x0001C86D File Offset: 0x0001AA6D
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17001173 RID: 4467
		' (get) Token: 0x06002CD7 RID: 11479 RVA: 0x0001C876 File Offset: 0x0001AA76
		' (set) Token: 0x06002CD8 RID: 11480 RVA: 0x0001C880 File Offset: 0x0001AA80
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17001174 RID: 4468
		' (get) Token: 0x06002CD9 RID: 11481 RVA: 0x0001C889 File Offset: 0x0001AA89
		' (set) Token: 0x06002CDA RID: 11482 RVA: 0x0001C893 File Offset: 0x0001AA93
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17001175 RID: 4469
		' (get) Token: 0x06002CDB RID: 11483 RVA: 0x0001C89C File Offset: 0x0001AA9C
		' (set) Token: 0x06002CDC RID: 11484 RVA: 0x0001C8A6 File Offset: 0x0001AAA6
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17001176 RID: 4470
		' (get) Token: 0x06002CDD RID: 11485 RVA: 0x0001C8AF File Offset: 0x0001AAAF
		' (set) Token: 0x06002CDE RID: 11486 RVA: 0x0001C8B9 File Offset: 0x0001AAB9
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17001177 RID: 4471
		' (get) Token: 0x06002CDF RID: 11487 RVA: 0x0001C8C2 File Offset: 0x0001AAC2
		' (set) Token: 0x06002CE0 RID: 11488 RVA: 0x0001C8CC File Offset: 0x0001AACC
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17001178 RID: 4472
		' (get) Token: 0x06002CE1 RID: 11489 RVA: 0x0001C8D5 File Offset: 0x0001AAD5
		' (set) Token: 0x06002CE2 RID: 11490 RVA: 0x0001C8DF File Offset: 0x0001AADF
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17001179 RID: 4473
		' (get) Token: 0x06002CE3 RID: 11491 RVA: 0x0001C8E8 File Offset: 0x0001AAE8
		' (set) Token: 0x06002CE4 RID: 11492 RVA: 0x0001C8F2 File Offset: 0x0001AAF2
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x1700117A RID: 4474
		' (get) Token: 0x06002CE5 RID: 11493 RVA: 0x0001C8FB File Offset: 0x0001AAFB
		' (set) Token: 0x06002CE6 RID: 11494 RVA: 0x0001C905 File Offset: 0x0001AB05
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700117B RID: 4475
		' (get) Token: 0x06002CE7 RID: 11495 RVA: 0x0001C90E File Offset: 0x0001AB0E
		' (set) Token: 0x06002CE8 RID: 11496 RVA: 0x0001C918 File Offset: 0x0001AB18
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x1700117C RID: 4476
		' (get) Token: 0x06002CE9 RID: 11497 RVA: 0x0001C921 File Offset: 0x0001AB21
		' (set) Token: 0x06002CEA RID: 11498 RVA: 0x0001C92B File Offset: 0x0001AB2B
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x1700117D RID: 4477
		' (get) Token: 0x06002CEB RID: 11499 RVA: 0x0001C934 File Offset: 0x0001AB34
		' (set) Token: 0x06002CEC RID: 11500 RVA: 0x0001C93E File Offset: 0x0001AB3E
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x1700117E RID: 4478
		' (get) Token: 0x06002CED RID: 11501 RVA: 0x0001C947 File Offset: 0x0001AB47
		' (set) Token: 0x06002CEE RID: 11502 RVA: 0x0001C951 File Offset: 0x0001AB51
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x1700117F RID: 4479
		' (get) Token: 0x06002CEF RID: 11503 RVA: 0x0001C95A File Offset: 0x0001AB5A
		' (set) Token: 0x06002CF0 RID: 11504 RVA: 0x0001C964 File Offset: 0x0001AB64
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17001180 RID: 4480
		' (get) Token: 0x06002CF1 RID: 11505 RVA: 0x0001C96D File Offset: 0x0001AB6D
		' (set) Token: 0x06002CF2 RID: 11506 RVA: 0x0001C977 File Offset: 0x0001AB77
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17001181 RID: 4481
		' (get) Token: 0x06002CF3 RID: 11507 RVA: 0x0001C980 File Offset: 0x0001AB80
		' (set) Token: 0x06002CF4 RID: 11508 RVA: 0x0001C98A File Offset: 0x0001AB8A
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17001182 RID: 4482
		' (get) Token: 0x06002CF5 RID: 11509 RVA: 0x0001C993 File Offset: 0x0001AB93
		' (set) Token: 0x06002CF6 RID: 11510 RVA: 0x0001C99D File Offset: 0x0001AB9D
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17001183 RID: 4483
		' (get) Token: 0x06002CF7 RID: 11511 RVA: 0x0001C9A6 File Offset: 0x0001ABA6
		' (set) Token: 0x06002CF8 RID: 11512 RVA: 0x0001C9B0 File Offset: 0x0001ABB0
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17001184 RID: 4484
		' (get) Token: 0x06002CF9 RID: 11513 RVA: 0x0001C9B9 File Offset: 0x0001ABB9
		' (set) Token: 0x06002CFA RID: 11514 RVA: 0x0001C9C3 File Offset: 0x0001ABC3
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17001185 RID: 4485
		' (get) Token: 0x06002CFB RID: 11515 RVA: 0x0001C9CC File Offset: 0x0001ABCC
		' (set) Token: 0x06002CFC RID: 11516 RVA: 0x0001C9D6 File Offset: 0x0001ABD6
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17001186 RID: 4486
		' (get) Token: 0x06002CFD RID: 11517 RVA: 0x0001C9DF File Offset: 0x0001ABDF
		' (set) Token: 0x06002CFE RID: 11518 RVA: 0x0001C9E9 File Offset: 0x0001ABE9
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17001187 RID: 4487
		' (get) Token: 0x06002CFF RID: 11519 RVA: 0x0001C9F2 File Offset: 0x0001ABF2
		' (set) Token: 0x06002D00 RID: 11520 RVA: 0x0001C9FC File Offset: 0x0001ABFC
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x17001188 RID: 4488
		' (get) Token: 0x06002D01 RID: 11521 RVA: 0x0001CA05 File Offset: 0x0001AC05
		' (set) Token: 0x06002D02 RID: 11522 RVA: 0x0001CA0F File Offset: 0x0001AC0F
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x17001189 RID: 4489
		' (get) Token: 0x06002D03 RID: 11523 RVA: 0x0001CA18 File Offset: 0x0001AC18
		' (set) Token: 0x06002D04 RID: 11524 RVA: 0x0001CA22 File Offset: 0x0001AC22
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x1700118A RID: 4490
		' (get) Token: 0x06002D05 RID: 11525 RVA: 0x0001CA2B File Offset: 0x0001AC2B
		' (set) Token: 0x06002D06 RID: 11526 RVA: 0x0001CA35 File Offset: 0x0001AC35
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x1700118B RID: 4491
		' (get) Token: 0x06002D07 RID: 11527 RVA: 0x0001CA3E File Offset: 0x0001AC3E
		' (set) Token: 0x06002D08 RID: 11528 RVA: 0x0001CA48 File Offset: 0x0001AC48
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x1700118C RID: 4492
		' (get) Token: 0x06002D09 RID: 11529 RVA: 0x0001CA51 File Offset: 0x0001AC51
		' (set) Token: 0x06002D0A RID: 11530 RVA: 0x0001CA5B File Offset: 0x0001AC5B
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x1700118D RID: 4493
		' (get) Token: 0x06002D0B RID: 11531 RVA: 0x0001CA64 File Offset: 0x0001AC64
		' (set) Token: 0x06002D0C RID: 11532 RVA: 0x0001CA6E File Offset: 0x0001AC6E
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x1700118E RID: 4494
		' (get) Token: 0x06002D0D RID: 11533 RVA: 0x0001CA77 File Offset: 0x0001AC77
		' (set) Token: 0x06002D0E RID: 11534 RVA: 0x0001CA81 File Offset: 0x0001AC81
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x1700118F RID: 4495
		' (get) Token: 0x06002D0F RID: 11535 RVA: 0x0001CA8A File Offset: 0x0001AC8A
		' (set) Token: 0x06002D10 RID: 11536 RVA: 0x0001CA94 File Offset: 0x0001AC94
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17001190 RID: 4496
		' (get) Token: 0x06002D11 RID: 11537 RVA: 0x0001CA9D File Offset: 0x0001AC9D
		' (set) Token: 0x06002D12 RID: 11538 RVA: 0x001BD808 File Offset: 0x001BBA08
		Private _btnSave As GelButton
		Friend Overridable Property btnSave As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
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

		' Token: 0x17001191 RID: 4497
		' (get) Token: 0x06002D13 RID: 11539 RVA: 0x0001CAA7 File Offset: 0x0001ACA7
		' (set) Token: 0x06002D14 RID: 11540 RVA: 0x001BD84C File Offset: 0x001BBA4C
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

		' Token: 0x17001192 RID: 4498
		' (get) Token: 0x06002D15 RID: 11541 RVA: 0x0001CAB1 File Offset: 0x0001ACB1
		' (set) Token: 0x06002D16 RID: 11542 RVA: 0x001BD890 File Offset: 0x001BBA90
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

		' Token: 0x17001193 RID: 4499
		' (get) Token: 0x06002D17 RID: 11543 RVA: 0x0001CABB File Offset: 0x0001ACBB
		' (set) Token: 0x06002D18 RID: 11544 RVA: 0x001BD8D4 File Offset: 0x001BBAD4
		Private _GelButton4 As GelButton
		Friend Overridable Property GelButton4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton4_Click
				Dim gelButton As GelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton4 = value
				gelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001194 RID: 4500
		' (get) Token: 0x06002D19 RID: 11545 RVA: 0x0001CAC5 File Offset: 0x0001ACC5
		' (set) Token: 0x06002D1A RID: 11546 RVA: 0x001BD918 File Offset: 0x001BBB18
		Private _GelButton1 As GelButton
		Friend Overridable Property GelButton1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click_1
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

		' Token: 0x17001195 RID: 4501
		' (get) Token: 0x06002D1B RID: 11547 RVA: 0x0001CACF File Offset: 0x0001ACCF
		' (set) Token: 0x06002D1C RID: 11548 RVA: 0x0001CAD9 File Offset: 0x0001ACD9
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x17001196 RID: 4502
		' (get) Token: 0x06002D1D RID: 11549 RVA: 0x0001CAE2 File Offset: 0x0001ACE2
		' (set) Token: 0x06002D1E RID: 11550 RVA: 0x0001CAEC File Offset: 0x0001ACEC
		Friend Overridable Property CheckBox1 As CheckBox

		' Token: 0x17001197 RID: 4503
		' (get) Token: 0x06002D1F RID: 11551 RVA: 0x0001CAF5 File Offset: 0x0001ACF5
		' (set) Token: 0x06002D20 RID: 11552 RVA: 0x001BD95C File Offset: 0x001BBB5C
		Private _GelButton5 As GelButton
		Friend Overridable Property GelButton5 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton5_Click
				Dim gelButton As GelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton5 = value
				gelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001198 RID: 4504
		' (get) Token: 0x06002D21 RID: 11553 RVA: 0x0001CAFF File Offset: 0x0001ACFF
		' (set) Token: 0x06002D22 RID: 11554 RVA: 0x001BD9A0 File Offset: 0x001BBBA0
		Private _btnImportPro As GelButton
		Friend Overridable Property btnImportPro As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnImportPro
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnImportPro_Click
				Dim gelButton As GelButton = Me._btnImportPro
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnImportPro = value
				gelButton = Me._btnImportPro
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x06002D23 RID: 11555 RVA: 0x0011427C File Offset: 0x0011247C
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 PID FROM Product ORDER BY PID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("PID"))
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

		' Token: 0x06002D24 RID: 11556 RVA: 0x001BD9E4 File Offset: 0x001BBBE4
		Public Sub auto()
			Try
				Me.txtID.Text = Me.GenerateID()
				Me.txtProductCode.Text = "P-" + Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002D25 RID: 11557 RVA: 0x001BDA58 File Offset: 0x001BBC58
		Public Sub Getdata()
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				SqlConnection.ClearAllPools()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select PID, RTRIM(ProductCode), RTRIM(Productname), SubCategoryID, RTRIM(HSNCode), RTRIM(PartNo), RTRIM(Description), CostPrice, SellingPrice, Discount, CGST, SGST, CESS, ReorderPoint, RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),Product.MRP,RTRIM(GDown),RTRIM(Rack),(Temp_Stock.Qty),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Temp_Stock.Barcode),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID order by ProductName", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002D26 RID: 11558 RVA: 0x0001CB09 File Offset: 0x0001AD09
		Public Sub Reset()
			Me.txtProductName.Text = ""
			Me.DataGridView1.DataSource = Nothing
			Me.DataGridView1.Visible = False
			Me.Getdata()
		End Sub

		' Token: 0x06002D27 RID: 11559 RVA: 0x001BDD58 File Offset: 0x001BBF58
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

		' Token: 0x06002D28 RID: 11560 RVA: 0x001BDE40 File Offset: 0x001BC040
		Private Sub txtProductName_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				SqlConnection.ClearAllPools()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select PID, RTRIM(ProductCode), RTRIM(Productname), SubCategoryID, RTRIM(HSNCode), RTRIM(PartNo), RTRIM(Description), CostPrice, SellingPrice, Discount, CGST, SGST, CESS, ReorderPoint, RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),Product.MRP,RTRIM(GDown),RTRIM(Rack),(Temp_Stock.Qty),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Temp_Stock.Barcode),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and ProductName like N'%" + Me.txtProductName.Text + "%' order by Productname", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002D29 RID: 11561 RVA: 0x0001CB3E File Offset: 0x0001AD3E
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06002D2A RID: 11562 RVA: 0x001BE14C File Offset: 0x001BC34C
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

		' Token: 0x06002D2B RID: 11563 RVA: 0x00113F98 File Offset: 0x00112198
		Private Function GenerateDate(mfgDate As String) As String
			Dim text As String = ""
			Try
				Dim list As List(Of String) = mfgDate.Split(New Char() { " "c }).First().Split(New Char() { "/"c }).ToList()
				Dim num As Integer = Convert.ToInt32(list(0))
				Dim num2 As Integer = Convert.ToInt32(list(1))
				Dim num3 As Integer = Convert.ToInt32(list(2))
				Dim flag As Boolean = num < 10
				Dim text2 As String
				If flag Then
					text2 = "0" + num.ToString()
				Else
					text2 = Conversions.ToString(num)
				End If
				Dim flag2 As Boolean = num2 < 10
				Dim text3 As String
				If flag2 Then
					text3 = "0" + num2.ToString()
				Else
					text3 = Conversions.ToString(num2)
				End If
				Dim flag3 As Boolean = num3 < 1000
				Dim text4 As String
				If flag3 Then
					text4 = "00" + num3.ToString()
				Else
					text4 = Conversions.ToString(num3)
				End If
				text = String.Concat(New String() { text2, "/", text3, "/", text4 })
			Catch ex As Exception
				text = ""
			End Try
			Return text
		End Function

		' Token: 0x06002D2C RID: 11564 RVA: 0x001BE234 File Offset: 0x001BC434
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Dim folderBrowserDialog As FolderBrowserDialog = Me.FolderBrowserDialog1
			Dim flag As Boolean = Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK
			If flag Then
				Dim selectedPath As String = folderBrowserDialog.SelectedPath
				Try
					Dim flag2 As Boolean = MyProject.Computer.FileSystem.FileExists(selectedPath + "\Product_Format_new.xls")
					If flag2 Then
						File.Delete(selectedPath + "\Product_Format_new.xls")
						MessageBox.Show("Successfully Saved" & vbLf, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Else
						MessageBox.Show("Not Saved" & vbLf, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End If
				Catch ex As Exception
					MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x06002D2D RID: 11565 RVA: 0x001BE310 File Offset: 0x001BC510
		Private Sub frmExportImportExcel_ProductsRecord_Load(sender As Object, e As EventArgs)
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.CheckBox1.Checked = True
			Me.Convert_Language()
		End Sub

		' Token: 0x06002D2E RID: 11566 RVA: 0x001BE40C File Offset: 0x001BC60C
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

		' Token: 0x06002D2F RID: 11567 RVA: 0x001BE584 File Offset: 0x001BC784
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

		' Token: 0x06002D30 RID: 11568 RVA: 0x001BE640 File Offset: 0x001BC840
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

		' Token: 0x06002D31 RID: 11569 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06002D32 RID: 11570 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06002D33 RID: 11571 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06002D34 RID: 11572 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmExportImportExcel_ProductsRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06002D35 RID: 11573 RVA: 0x001BE70C File Offset: 0x001BC90C
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
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
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002D36 RID: 11574 RVA: 0x001BE9B8 File Offset: 0x001BCBB8
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
				MessageBox.Show(ex.Message + "ONCLICK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002D37 RID: 11575 RVA: 0x001BEAC8 File Offset: 0x001BCCC8
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = False
			Try
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
					ModCommonClasses.con.Close()
				Else
					Dim flag4 As Boolean = Me.DataGridView1.RowCount = 0
					If flag4 Then
						MessageBox.Show("Sorry nothing to save.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Else
						Dim num As Integer = Me.DataGridView1.RowCount - 1
						For i As Integer = 0 To num
							Dim flag5 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(0).Value.ToString(), "", False) = 0
							If flag5 Then
								MessageBox.Show("Product Name Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag6 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(1).Value.ToString(), "", False) = 0
							If flag6 Then
								MessageBox.Show("Purchase Price Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag7 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(2).Value.ToString(), "", False) = 0
							If flag7 Then
								MessageBox.Show("Retail Sale Price Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag8 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(3).Value.ToString(), "", False) = 0
							If flag8 Then
								MessageBox.Show("Disc% Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag9 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(4).Value.ToString(), "", False) = 0
							If flag9 Then
								MessageBox.Show("Wholesale Price Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag10 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(5).Value.ToString(), "", False) = 0
							If flag10 Then
								MessageBox.Show("MRP Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag11 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(6).Value.ToString(), "", False) = 0
							If flag11 Then
								MessageBox.Show("Opening Qty Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag12 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(11).Value.ToString(), "", False) = 0
							If flag12 Then
								MessageBox.Show("Barcode Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag13 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(12).Value.ToString(), "", False) = 0
							If flag13 Then
								MessageBox.Show("Default Sale Qty Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim num2 As Integer = i + 1
							Dim num3 As Integer = Me.DataGridView1.RowCount - 1
							For j As Integer = num2 To num3
								Dim flag14 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(11).Value.ToString(), Me.DataGridView1.Rows(j).Cells(11).Value.ToString(), False) = 0
								If flag14 Then
									MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject("Duplicate Barcode Number found ", Me.DataGridView1.Rows(i).Cells(11).Value)))
									Return
								End If
							Next
						Next
						Try
							For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
								Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
								Dim flag15 As Boolean = Not dataGridViewRow.IsNewRow
								If flag15 Then
									SqlConnection.ClearAllPools()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text2 As String = "select Barcode from Product_OpeningStock Where Barcode=@d1"
									ModCommonClasses.cmd = New SqlCommand(text2)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells(11).Value.ToString())
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag16 As Boolean = ModCommonClasses.rdr.Read()
									If flag16 Then
										MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Barcode '", dataGridViewRow.Cells(11).Value), "' Already Exists")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Dim flag17 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag17 Then
											ModCommonClasses.rdr.Close()
										End If
										ModCommonClasses.con.Close()
										Return
									End If
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
								Dim flag18 As Boolean = Not dataGridViewRow2.IsNewRow
								If flag18 Then
									SqlConnection.ClearAllPools()
									Try
										Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
											sqlConnection.Open()
											Dim text3 As String = "select Barcode from Temp_Stock Where Barcode=@d1"
											Using sqlCommand As SqlCommand = New SqlCommand(text3, sqlConnection)
												sqlCommand.Parameters.AddWithValue("@d1", dataGridViewRow2.Cells(11).Value.ToString())
												Dim num4 As Integer = Conversions.ToInteger(sqlCommand.ExecuteScalar())
												Dim flag19 As Boolean = num4 > 0
												If flag19 Then
													MessageBox.Show("Barcode '" + dataGridViewRow2.Cells(11).Value.ToString() + "' Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													Return
												End If
												Dim flag20 As Boolean = ModCommonClasses.rdr IsNot Nothing
												If flag20 Then
													ModCommonClasses.rdr.Close()
												End If
											End Using
										End Using
									Catch ex As Exception
										Console.WriteLine("Error: " + ex.Message)
									End Try
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
						Dim text4 As String = "select  SubCategoryName , Category from SubCategory where IsDefault='Yes'"
						ModCommonClasses.cmd = New SqlCommand(text4)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag21 As Boolean = ModCommonClasses.rdr.Read()
						Dim text5 As String
						If flag21 Then
							text5 = ModCommonClasses.rdr(0).ToString()
							Dim flag22 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag22 Then
								ModCommonClasses.rdr.Close()
							End If
						End If
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text6 As String = "select Unit from UnitMaster where IsDefault='Yes'"
						ModCommonClasses.cmd = New SqlCommand(text6)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag23 As Boolean = ModCommonClasses.rdr.Read()
						Dim text7 As String
						If flag23 Then
							text7 = ModCommonClasses.rdr(0).ToString()
							Dim flag24 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag24 Then
								ModCommonClasses.rdr.Close()
							End If
						End If
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text8 As String = "select Rate  from TaxCat where IsDefault='Yes'"
						ModCommonClasses.cmd = New SqlCommand(text8)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag25 As Boolean = ModCommonClasses.rdr.Read()
						Dim text9 As String
						If flag25 Then
							text9 = ModCommonClasses.rdr(0).ToString()
							Dim flag26 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag26 Then
								ModCommonClasses.rdr.Close()
							End If
						End If
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text10 As String = "select distinct stax_type, ptax_type from Defaulttaxtype where id=1"
						ModCommonClasses.cmd = New SqlCommand(text10)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag27 As Boolean = ModCommonClasses.rdr.Read()
						Dim text11 As String
						Dim num5 As Double
						If flag27 Then
							text11 = ModCommonClasses.rdr(0).ToString()
							num5 = Conversions.ToDouble(ModCommonClasses.rdr(1).ToString())
							Dim flag28 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag28 Then
								ModCommonClasses.rdr.Close()
							End If
						End If
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text12 As String = "SELECT * FROM tbl_loyalty_setting WHERE id = 1"
						ModCommonClasses.cmd = New SqlCommand(text12)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag29 As Boolean = ModCommonClasses.rdr.Read()
						Dim text13 As String
						Dim num6 As Double
						If flag29 Then
							text13 = ModCommonClasses.rdr(1).ToString()
							num6 = Conversions.ToDouble(ModCommonClasses.rdr(2).ToString())
							Dim flag30 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag30 Then
								ModCommonClasses.rdr.Close()
							End If
						End If
						Try
							Try
								For Each obj3 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
									Dim dataGridViewRow3 As DataGridViewRow = CType(obj3, DataGridViewRow)
									flag = False
									Try
										Dim flag31 As Boolean = Me.IsProductExist(Me.txtID.Text.ToString())
										If flag31 Then
											Dim flag32 As Boolean = Operators.CompareString(dataGridViewRow3.Cells(7).Value.ToString(), "", False) = 0
											If Not flag32 Then
												Dim text14 As String = Me.GenerateDate(dataGridViewRow3.Cells(7).Value.ToString())
											End If
											Dim flag33 As Boolean = Operators.CompareString(dataGridViewRow3.Cells(8).Value.ToString(), "", False) = 0
											If Not flag33 Then
												Dim text15 As String = Me.GenerateDate(dataGridViewRow3.Cells(8).Value.ToString())
											End If
											flag = True
										End If
										Dim flag34 As Boolean = Not flag
										If flag34 Then
											Dim flag35 As Boolean = Not dataGridViewRow3.IsNewRow
											If flag35 Then
												Me.Cursor = Cursors.WaitCursor
												Me.Timer1.Enabled = True
												SqlConnection.ClearAllPools()
												Me.auto()
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text16 As String = "insert into Product(PID,ProductCode, Productname, SubCategoryID,HSNCode,PartNo, Description, CostPrice, SellingPrice," & vbCrLf & "                                                Discount,CGST,SGST,CESS, ReorderPoint,OpeningStock,Barcode,PurchaseUnit,SalesUnit,SalesAltUnit,Conv,MinStock,MRP,Status," & vbCrLf & "                                                STax,PTax,GDown,Rack,DefQty,AddDate, loyality_mode, loyality_value)" & vbCrLf & "                                                VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24," & vbCrLf & "                                                @d25,@d26,@d27,@d28,@d29,@d30)"
												ModCommonClasses.cmd = New SqlCommand(text16)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtProductCode.Text)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow3.Cells(0).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(text5))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d4", "")
												ModCommonClasses.cmd.Parameters.AddWithValue("@d5", "")
												ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow3.Cells(0).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(dataGridViewRow3.Cells(1).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(dataGridViewRow3.Cells(2).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(dataGridViewRow3.Cells(3).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(text9))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(text9))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val("0.00"))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(dataGridViewRow3.Cells(4).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(dataGridViewRow3.Cells(6).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d15", dataGridViewRow3.Cells(11).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d16", text7)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d17", text7)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d18", text7)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val("1"))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d20", Conversion.Val("1"))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(5).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d22", "Yes")
												ModCommonClasses.cmd.Parameters.AddWithValue("@d23", text11)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d24", num5)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d25", "")
												ModCommonClasses.cmd.Parameters.AddWithValue("@d26", "")
												ModCommonClasses.cmd.Parameters.AddWithValue("@d27", "1")
												ModCommonClasses.cmd.Parameters.AddWithValue("@d28", DateTime.Today)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d29", text13.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d30", Conversion.Val(num6))
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.CommandTimeout = 0
												ModCommonClasses.cmd.ExecuteNonQuery()
												ModCommonClasses.con.Close()
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text17 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
												ModCommonClasses.cmd = New SqlCommand(text17)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", text7)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.ExecuteReader()
												ModCommonClasses.con.Close()
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text18 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
												ModCommonClasses.cmd = New SqlCommand(text18)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", text7)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.ExecuteReader()
												ModCommonClasses.con.Close()
												Dim flag36 As Boolean = Operators.CompareString(dataGridViewRow3.Cells(1).Value.ToString(), "", False) <> 0
												If flag36 Then
													SqlConnection.ClearAllPools()
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text19 As String = "Select Barcode from Product_OpeningStock where Barcode=@d1"
													ModCommonClasses.cmd = New SqlCommand(text19)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow3.Cells(11).Value.ToString())
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.cmd.CommandTimeout = 0
													ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
													Dim flag37 As Boolean = Not ModCommonClasses.rdr.Read()
													If flag37 Then
														SqlConnection.ClearAllPools()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim flag38 As Boolean = Operators.CompareString(dataGridViewRow3.Cells(7).Value.ToString(), "", False) = 0
														Dim text14 As String
														If flag38 Then
															text14 = ""
														Else
															text14 = Me.GenerateDate(dataGridViewRow3.Cells(7).Value.ToString())
														End If
														Dim flag39 As Boolean = Operators.CompareString(dataGridViewRow3.Cells(8).Value.ToString(), "", False) = 0
														Dim text15 As String
														If flag39 Then
															text15 = ""
														Else
															text15 = Me.GenerateDate(dataGridViewRow3.Cells(8).Value.ToString())
														End If
														Dim text20 As String = "insert into Product_OpeningStock(ProductID,Qty,MRP,SalePrice,WSalePrice,Batch,Mfgdate,Expdate,Size,Colour,Barcode,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18)"
														ModCommonClasses.cmd = New SqlCommand(text20)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(dataGridViewRow3.Cells(6).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(dataGridViewRow3.Cells(5).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(dataGridViewRow3.Cells(2).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(dataGridViewRow3.Cells(4).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d6", "")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d7", text14)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d8", text15)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow3.Cells(9).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d10", dataGridViewRow3.Cells(10).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d11", dataGridViewRow3.Cells(11).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d12", DateTime.Today)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(dataGridViewRow3.Cells(1).Value.ToString()))
														Dim num7 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(1).Value))
														Dim num8 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(6).Value))
														Dim num9 As Double = Conversion.Val(text9)
														Dim num10 As Double = Conversion.Val(text9)
														Dim num11 As Double = Conversion.Val("0.00")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d16", num7 * num8 + num7 * num8 * ((num9 + num10 + num11) / 100.0))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d17", "")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d18", "")
														ModCommonClasses.cmd.CommandTimeout = 0
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
														SqlConnection.ClearAllPools()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text21 As String = "insert into Product_Join(ProductID,Photo) VALUES (" + Conversions.ToString(Conversion.Val(Me.txtID.Text)) + ",@img)"
														ModCommonClasses.cmd = New SqlCommand(text21)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														Dim memoryStream As MemoryStream = New MemoryStream()
														Dim bitmap As Bitmap = New Bitmap(Resources._12)
														bitmap.Save(memoryStream, ImageFormat.Jpeg)
														Dim buffer As Byte() = memoryStream.GetBuffer()
														Dim sqlParameter As SqlParameter = New SqlParameter("@img", SqlDbType.Image)
														sqlParameter.Value = buffer
														ModCommonClasses.cmd.Parameters.Add(sqlParameter)
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
														Dim checked As Boolean = Me.CheckBox1.Checked
														If checked Then
															ModCommonClasses.con = New SqlConnection(ModCS.cs)
															ModCommonClasses.con.Open()
															Dim text22 As String = "select ProductID from StockMovement where ProductID=@d1"
															ModCommonClasses.cmd = New SqlCommand(text22)
															ModCommonClasses.cmd.Connection = ModCommonClasses.con
															ModCommonClasses.cmd.CommandTimeout = 0
															ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
															ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
															Dim flag40 As Boolean = Not ModCommonClasses.rdr.Read()
															If flag40 Then
																ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.txtID.Text))), 0D, New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(6).Value))), 0D, DateAndTime.Today, Me.txtProductCode.Text)
															Else
																ModCommonClasses.con = New SqlConnection(ModCS.cs)
																ModCommonClasses.con.Open()
																Dim text23 As String = "select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 and Date < @d3"
																ModCommonClasses.cmd = New SqlCommand(text23)
																ModCommonClasses.cmd.Connection = ModCommonClasses.con
																ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d3", DateAndTime.Today)
																ModCommonClasses.cmd.CommandTimeout = 0
																ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																Dim flag41 As Boolean = ModCommonClasses.rdr.Read()
																Dim num12 As Double
																If flag41 Then
																	num12 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
																Else
																	num12 = 0.0
																End If
																ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.txtID.Text))), New Decimal(num12), New Decimal(Conversion.Val(dataGridViewRow3.Cells(6).Value.ToString())), 0D, DateAndTime.Today, Me.txtProductCode.Text)
															End If
														End If
													End If
												End If
											End If
										End If
									Catch ex2 As Exception
										MessageBox.Show(ex2.Message)
									End Try
								Next
							Finally
								Dim enumerator3 As IEnumerator
								If TypeOf enumerator3 Is IDisposable Then
									TryCast(enumerator3, IDisposable).Dispose()
								End If
							End Try
							Try
								For Each obj4 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
									Dim dataGridViewRow4 As DataGridViewRow = CType(obj4, DataGridViewRow)
									Dim flag42 As Boolean = Operators.CompareString(dataGridViewRow4.Cells(7).Value.ToString(), "", False) = 0
									Dim text24 As String
									If flag42 Then
										text24 = ""
									Else
										text24 = Me.GenerateDate(dataGridViewRow4.Cells(7).Value.ToString())
									End If
									Dim flag43 As Boolean = Operators.CompareString(dataGridViewRow4.Cells(8).Value.ToString(), "", False) = 0
									Dim text25 As String
									If flag43 Then
										text25 = ""
									Else
										text25 = Me.GenerateDate(dataGridViewRow4.Cells(8).Value.ToString())
									End If
									Dim checked2 As Boolean = Me.CheckBox1.Checked
									If checked2 Then
										Me.Generate_GiftQR(Conversions.ToString(dataGridViewRow4.Cells(11).Value))
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text26 As String = "insert into Temp_Stock(ProductID,Qty,Barcode,SPrice,WPrice,StLimit,MRP,Batch,Mfgdate,Expdate,Size,Colour,SalePrice,WSalePrice,SuplName,IMEI1,IMEI2,PPrice,EPPrice,QrBarcode,SalesManPur,Variant_id) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22)"
										ModCommonClasses.cmd = New SqlCommand(text26)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(dataGridViewRow4.Cells(6).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow4.Cells(11).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(dataGridViewRow4.Cells(2).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(dataGridViewRow4.Cells(4).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val("0.00"))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(dataGridViewRow4.Cells(5).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", "")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d9", text24)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d10", text25)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d11", dataGridViewRow4.Cells(9).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d12", dataGridViewRow4.Cells(10).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Opening Stock")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d16", "")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d17", "")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(dataGridViewRow4.Cells(1).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(dataGridViewRow4.Cells(1).Value.ToString()))
										Dim memoryStream2 As MemoryStream = New MemoryStream()
										Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
										bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
										Dim buffer2 As Byte() = memoryStream2.GetBuffer()
										Dim sqlParameter2 As SqlParameter = New SqlParameter("@d20", SqlDbType.Image)
										sqlParameter2.Value = buffer2
										ModCommonClasses.cmd.Parameters.Add(sqlParameter2)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d21", 0.0)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Conversion.Val(Me.txtID.Text.ToString()))
										ModCommonClasses.cmd.CommandTimeout = 0
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
									End If
									Dim flag44 As Boolean = Not flag
									If flag44 Then
									End If
								Next
							Finally
								Dim enumerator4 As IEnumerator
								If TypeOf enumerator4 Is IDisposable Then
									TryCast(enumerator4, IDisposable).Dispose()
								End If
							End Try
							MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.DataGridView1.DataSource = Nothing
							Me.Reset()
						Catch ex3 As SqlException
							MessageBox.Show(ex3.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			Catch ex4 As Exception
			End Try
		End Sub

		' Token: 0x06002D38 RID: 11576 RVA: 0x001C0B50 File Offset: 0x001BED50
		Private Function IsProductExist(id As String) As Boolean
			Dim flag As Boolean = False
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT COUNT(*) FROM product WHERE PID = @d1"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@d1", id)
						Dim num As Integer = Conversions.ToInteger(sqlCommand.ExecuteScalar())
						Dim flag2 As Boolean = num > 0
						If flag2 Then
							flag = True
						End If
					End Using
				End Using
			Catch ex As Exception
				Console.WriteLine("Error: " + ex.Message)
			End Try
			Return flag
		End Function

		' Token: 0x06002D39 RID: 11577 RVA: 0x001C0C2C File Offset: 0x001BEE2C
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06002D3A RID: 11578 RVA: 0x0001CB5A File Offset: 0x0001AD5A
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06002D3B RID: 11579 RVA: 0x0001CB64 File Offset: 0x0001AD64
		Private Sub GelButton1_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmExportImportExcel_OpeningStock.ShowDialog()
		End Sub

		' Token: 0x06002D3C RID: 11580 RVA: 0x0001CB77 File Offset: 0x0001AD77
		Private Sub GelButton5_Click(sender As Object, e As EventArgs)
			MyBase.Dispose()
			MyProject.Forms.frmProductDefault.lblform.Text = "import"
			MyProject.Forms.frmProductDefault.ShowDialog()
		End Sub

		' Token: 0x06002D3D RID: 11581 RVA: 0x0001CBAB File Offset: 0x0001ADAB
		Private Sub btnImportPro_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmImportPro.ShowDialog()
			MyProject.Forms.frmImportPro.Dispose()
		End Sub
	End Class
End Namespace
