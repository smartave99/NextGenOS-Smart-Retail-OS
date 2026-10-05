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
	' Token: 0x02000110 RID: 272
	<DesignerGenerated()>
	Public Partial Class frmExportImportExcel_ProductsRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002D3E RID: 11582 RVA: 0x0001CBCE File Offset: 0x0001ADCE
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmExportImportExcel_ProductsRecord_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmExportImportExcel_ProductsRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17001199 RID: 4505
		' (get) Token: 0x06002D41 RID: 11585 RVA: 0x0001CC00 File Offset: 0x0001AE00
		' (set) Token: 0x06002D42 RID: 11586 RVA: 0x0001CC0A File Offset: 0x0001AE0A
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700119A RID: 4506
		' (get) Token: 0x06002D43 RID: 11587 RVA: 0x0001CC13 File Offset: 0x0001AE13
		' (set) Token: 0x06002D44 RID: 11588 RVA: 0x0001CC1D File Offset: 0x0001AE1D
		Friend Overridable Property Panel3 As Panel

		' Token: 0x1700119B RID: 4507
		' (get) Token: 0x06002D45 RID: 11589 RVA: 0x0001CC26 File Offset: 0x0001AE26
		' (set) Token: 0x06002D46 RID: 11590 RVA: 0x001C2FC8 File Offset: 0x001C11C8
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

		' Token: 0x1700119C RID: 4508
		' (get) Token: 0x06002D47 RID: 11591 RVA: 0x0001CC30 File Offset: 0x0001AE30
		' (set) Token: 0x06002D48 RID: 11592 RVA: 0x0001CC3A File Offset: 0x0001AE3A
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700119D RID: 4509
		' (get) Token: 0x06002D49 RID: 11593 RVA: 0x0001CC43 File Offset: 0x0001AE43
		' (set) Token: 0x06002D4A RID: 11594 RVA: 0x0001CC4D File Offset: 0x0001AE4D
		Friend Overridable Property Label1 As Label

		' Token: 0x1700119E RID: 4510
		' (get) Token: 0x06002D4B RID: 11595 RVA: 0x0001CC56 File Offset: 0x0001AE56
		' (set) Token: 0x06002D4C RID: 11596 RVA: 0x0001CC60 File Offset: 0x0001AE60
		Friend Overridable Property Label3 As Label

		' Token: 0x1700119F RID: 4511
		' (get) Token: 0x06002D4D RID: 11597 RVA: 0x0001CC69 File Offset: 0x0001AE69
		' (set) Token: 0x06002D4E RID: 11598 RVA: 0x001C300C File Offset: 0x001C120C
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

		' Token: 0x170011A0 RID: 4512
		' (get) Token: 0x06002D4F RID: 11599 RVA: 0x0001CC73 File Offset: 0x0001AE73
		' (set) Token: 0x06002D50 RID: 11600 RVA: 0x0001CC7D File Offset: 0x0001AE7D
		Friend Overridable Property lblSet As Label

		' Token: 0x170011A1 RID: 4513
		' (get) Token: 0x06002D51 RID: 11601 RVA: 0x0001CC86 File Offset: 0x0001AE86
		' (set) Token: 0x06002D52 RID: 11602 RVA: 0x001C3050 File Offset: 0x001C1250
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

		' Token: 0x170011A2 RID: 4514
		' (get) Token: 0x06002D53 RID: 11603 RVA: 0x0001CC90 File Offset: 0x0001AE90
		' (set) Token: 0x06002D54 RID: 11604 RVA: 0x001C3094 File Offset: 0x001C1294
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

		' Token: 0x170011A3 RID: 4515
		' (get) Token: 0x06002D55 RID: 11605 RVA: 0x0001CC9A File Offset: 0x0001AE9A
		' (set) Token: 0x06002D56 RID: 11606 RVA: 0x0001CCA4 File Offset: 0x0001AEA4
		Friend Overridable Property txtID As TextBox

		' Token: 0x170011A4 RID: 4516
		' (get) Token: 0x06002D57 RID: 11607 RVA: 0x0001CCAD File Offset: 0x0001AEAD
		' (set) Token: 0x06002D58 RID: 11608 RVA: 0x0001CCB7 File Offset: 0x0001AEB7
		Friend Overridable Property txtProductCode As TextBox

		' Token: 0x170011A5 RID: 4517
		' (get) Token: 0x06002D59 RID: 11609 RVA: 0x0001CCC0 File Offset: 0x0001AEC0
		' (set) Token: 0x06002D5A RID: 11610 RVA: 0x001C30D8 File Offset: 0x001C12D8
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

		' Token: 0x170011A6 RID: 4518
		' (get) Token: 0x06002D5B RID: 11611 RVA: 0x0001CCCA File Offset: 0x0001AECA
		' (set) Token: 0x06002D5C RID: 11612 RVA: 0x0001CCD4 File Offset: 0x0001AED4
		Friend Overridable Property FolderBrowserDialog1 As FolderBrowserDialog

		' Token: 0x170011A7 RID: 4519
		' (get) Token: 0x06002D5D RID: 11613 RVA: 0x0001CCDD File Offset: 0x0001AEDD
		' (set) Token: 0x06002D5E RID: 11614 RVA: 0x0001CCE7 File Offset: 0x0001AEE7
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x170011A8 RID: 4520
		' (get) Token: 0x06002D5F RID: 11615 RVA: 0x0001CCF0 File Offset: 0x0001AEF0
		' (set) Token: 0x06002D60 RID: 11616 RVA: 0x0001CCFA File Offset: 0x0001AEFA
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x170011A9 RID: 4521
		' (get) Token: 0x06002D61 RID: 11617 RVA: 0x0001CD03 File Offset: 0x0001AF03
		' (set) Token: 0x06002D62 RID: 11618 RVA: 0x0001CD0D File Offset: 0x0001AF0D
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x170011AA RID: 4522
		' (get) Token: 0x06002D63 RID: 11619 RVA: 0x0001CD16 File Offset: 0x0001AF16
		' (set) Token: 0x06002D64 RID: 11620 RVA: 0x0001CD20 File Offset: 0x0001AF20
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170011AB RID: 4523
		' (get) Token: 0x06002D65 RID: 11621 RVA: 0x0001CD29 File Offset: 0x0001AF29
		' (set) Token: 0x06002D66 RID: 11622 RVA: 0x0001CD33 File Offset: 0x0001AF33
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170011AC RID: 4524
		' (get) Token: 0x06002D67 RID: 11623 RVA: 0x0001CD3C File Offset: 0x0001AF3C
		' (set) Token: 0x06002D68 RID: 11624 RVA: 0x0001CD46 File Offset: 0x0001AF46
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170011AD RID: 4525
		' (get) Token: 0x06002D69 RID: 11625 RVA: 0x0001CD4F File Offset: 0x0001AF4F
		' (set) Token: 0x06002D6A RID: 11626 RVA: 0x0001CD59 File Offset: 0x0001AF59
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170011AE RID: 4526
		' (get) Token: 0x06002D6B RID: 11627 RVA: 0x0001CD62 File Offset: 0x0001AF62
		' (set) Token: 0x06002D6C RID: 11628 RVA: 0x0001CD6C File Offset: 0x0001AF6C
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x170011AF RID: 4527
		' (get) Token: 0x06002D6D RID: 11629 RVA: 0x0001CD75 File Offset: 0x0001AF75
		' (set) Token: 0x06002D6E RID: 11630 RVA: 0x0001CD7F File Offset: 0x0001AF7F
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170011B0 RID: 4528
		' (get) Token: 0x06002D6F RID: 11631 RVA: 0x0001CD88 File Offset: 0x0001AF88
		' (set) Token: 0x06002D70 RID: 11632 RVA: 0x0001CD92 File Offset: 0x0001AF92
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x170011B1 RID: 4529
		' (get) Token: 0x06002D71 RID: 11633 RVA: 0x0001CD9B File Offset: 0x0001AF9B
		' (set) Token: 0x06002D72 RID: 11634 RVA: 0x0001CDA5 File Offset: 0x0001AFA5
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x170011B2 RID: 4530
		' (get) Token: 0x06002D73 RID: 11635 RVA: 0x0001CDAE File Offset: 0x0001AFAE
		' (set) Token: 0x06002D74 RID: 11636 RVA: 0x0001CDB8 File Offset: 0x0001AFB8
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170011B3 RID: 4531
		' (get) Token: 0x06002D75 RID: 11637 RVA: 0x0001CDC1 File Offset: 0x0001AFC1
		' (set) Token: 0x06002D76 RID: 11638 RVA: 0x0001CDCB File Offset: 0x0001AFCB
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x170011B4 RID: 4532
		' (get) Token: 0x06002D77 RID: 11639 RVA: 0x0001CDD4 File Offset: 0x0001AFD4
		' (set) Token: 0x06002D78 RID: 11640 RVA: 0x0001CDDE File Offset: 0x0001AFDE
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x170011B5 RID: 4533
		' (get) Token: 0x06002D79 RID: 11641 RVA: 0x0001CDE7 File Offset: 0x0001AFE7
		' (set) Token: 0x06002D7A RID: 11642 RVA: 0x0001CDF1 File Offset: 0x0001AFF1
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x170011B6 RID: 4534
		' (get) Token: 0x06002D7B RID: 11643 RVA: 0x0001CDFA File Offset: 0x0001AFFA
		' (set) Token: 0x06002D7C RID: 11644 RVA: 0x0001CE04 File Offset: 0x0001B004
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x170011B7 RID: 4535
		' (get) Token: 0x06002D7D RID: 11645 RVA: 0x0001CE0D File Offset: 0x0001B00D
		' (set) Token: 0x06002D7E RID: 11646 RVA: 0x0001CE17 File Offset: 0x0001B017
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x170011B8 RID: 4536
		' (get) Token: 0x06002D7F RID: 11647 RVA: 0x0001CE20 File Offset: 0x0001B020
		' (set) Token: 0x06002D80 RID: 11648 RVA: 0x0001CE2A File Offset: 0x0001B02A
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170011B9 RID: 4537
		' (get) Token: 0x06002D81 RID: 11649 RVA: 0x0001CE33 File Offset: 0x0001B033
		' (set) Token: 0x06002D82 RID: 11650 RVA: 0x0001CE3D File Offset: 0x0001B03D
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x170011BA RID: 4538
		' (get) Token: 0x06002D83 RID: 11651 RVA: 0x0001CE46 File Offset: 0x0001B046
		' (set) Token: 0x06002D84 RID: 11652 RVA: 0x0001CE50 File Offset: 0x0001B050
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x170011BB RID: 4539
		' (get) Token: 0x06002D85 RID: 11653 RVA: 0x0001CE59 File Offset: 0x0001B059
		' (set) Token: 0x06002D86 RID: 11654 RVA: 0x0001CE63 File Offset: 0x0001B063
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x170011BC RID: 4540
		' (get) Token: 0x06002D87 RID: 11655 RVA: 0x0001CE6C File Offset: 0x0001B06C
		' (set) Token: 0x06002D88 RID: 11656 RVA: 0x0001CE76 File Offset: 0x0001B076
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x170011BD RID: 4541
		' (get) Token: 0x06002D89 RID: 11657 RVA: 0x0001CE7F File Offset: 0x0001B07F
		' (set) Token: 0x06002D8A RID: 11658 RVA: 0x0001CE89 File Offset: 0x0001B089
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x170011BE RID: 4542
		' (get) Token: 0x06002D8B RID: 11659 RVA: 0x0001CE92 File Offset: 0x0001B092
		' (set) Token: 0x06002D8C RID: 11660 RVA: 0x0001CE9C File Offset: 0x0001B09C
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x170011BF RID: 4543
		' (get) Token: 0x06002D8D RID: 11661 RVA: 0x0001CEA5 File Offset: 0x0001B0A5
		' (set) Token: 0x06002D8E RID: 11662 RVA: 0x0001CEAF File Offset: 0x0001B0AF
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x170011C0 RID: 4544
		' (get) Token: 0x06002D8F RID: 11663 RVA: 0x0001CEB8 File Offset: 0x0001B0B8
		' (set) Token: 0x06002D90 RID: 11664 RVA: 0x0001CEC2 File Offset: 0x0001B0C2
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x170011C1 RID: 4545
		' (get) Token: 0x06002D91 RID: 11665 RVA: 0x0001CECB File Offset: 0x0001B0CB
		' (set) Token: 0x06002D92 RID: 11666 RVA: 0x0001CED5 File Offset: 0x0001B0D5
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x170011C2 RID: 4546
		' (get) Token: 0x06002D93 RID: 11667 RVA: 0x0001CEDE File Offset: 0x0001B0DE
		' (set) Token: 0x06002D94 RID: 11668 RVA: 0x0001CEE8 File Offset: 0x0001B0E8
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x170011C3 RID: 4547
		' (get) Token: 0x06002D95 RID: 11669 RVA: 0x0001CEF1 File Offset: 0x0001B0F1
		' (set) Token: 0x06002D96 RID: 11670 RVA: 0x0001CEFB File Offset: 0x0001B0FB
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x170011C4 RID: 4548
		' (get) Token: 0x06002D97 RID: 11671 RVA: 0x0001CF04 File Offset: 0x0001B104
		' (set) Token: 0x06002D98 RID: 11672 RVA: 0x0001CF0E File Offset: 0x0001B10E
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x170011C5 RID: 4549
		' (get) Token: 0x06002D99 RID: 11673 RVA: 0x0001CF17 File Offset: 0x0001B117
		' (set) Token: 0x06002D9A RID: 11674 RVA: 0x0001CF21 File Offset: 0x0001B121
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x170011C6 RID: 4550
		' (get) Token: 0x06002D9B RID: 11675 RVA: 0x0001CF2A File Offset: 0x0001B12A
		' (set) Token: 0x06002D9C RID: 11676 RVA: 0x0001CF34 File Offset: 0x0001B134
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x170011C7 RID: 4551
		' (get) Token: 0x06002D9D RID: 11677 RVA: 0x0001CF3D File Offset: 0x0001B13D
		' (set) Token: 0x06002D9E RID: 11678 RVA: 0x0001CF47 File Offset: 0x0001B147
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x170011C8 RID: 4552
		' (get) Token: 0x06002D9F RID: 11679 RVA: 0x0001CF50 File Offset: 0x0001B150
		' (set) Token: 0x06002DA0 RID: 11680 RVA: 0x001C311C File Offset: 0x001C131C
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

		' Token: 0x170011C9 RID: 4553
		' (get) Token: 0x06002DA1 RID: 11681 RVA: 0x0001CF5A File Offset: 0x0001B15A
		' (set) Token: 0x06002DA2 RID: 11682 RVA: 0x001C3160 File Offset: 0x001C1360
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

		' Token: 0x170011CA RID: 4554
		' (get) Token: 0x06002DA3 RID: 11683 RVA: 0x0001CF64 File Offset: 0x0001B164
		' (set) Token: 0x06002DA4 RID: 11684 RVA: 0x001C31A4 File Offset: 0x001C13A4
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

		' Token: 0x170011CB RID: 4555
		' (get) Token: 0x06002DA5 RID: 11685 RVA: 0x0001CF6E File Offset: 0x0001B16E
		' (set) Token: 0x06002DA6 RID: 11686 RVA: 0x001C31E8 File Offset: 0x001C13E8
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

		' Token: 0x170011CC RID: 4556
		' (get) Token: 0x06002DA7 RID: 11687 RVA: 0x0001CF78 File Offset: 0x0001B178
		' (set) Token: 0x06002DA8 RID: 11688 RVA: 0x001C322C File Offset: 0x001C142C
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

		' Token: 0x170011CD RID: 4557
		' (get) Token: 0x06002DA9 RID: 11689 RVA: 0x0001CF82 File Offset: 0x0001B182
		' (set) Token: 0x06002DAA RID: 11690 RVA: 0x0001CF8C File Offset: 0x0001B18C
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x170011CE RID: 4558
		' (get) Token: 0x06002DAB RID: 11691 RVA: 0x0001CF95 File Offset: 0x0001B195
		' (set) Token: 0x06002DAC RID: 11692 RVA: 0x0001CF9F File Offset: 0x0001B19F
		Friend Overridable Property CheckBox1 As CheckBox

		' Token: 0x170011CF RID: 4559
		' (get) Token: 0x06002DAD RID: 11693 RVA: 0x0001CFA8 File Offset: 0x0001B1A8
		' (set) Token: 0x06002DAE RID: 11694 RVA: 0x001C3270 File Offset: 0x001C1470
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

		' Token: 0x170011D0 RID: 4560
		' (get) Token: 0x06002DAF RID: 11695 RVA: 0x0001CFB2 File Offset: 0x0001B1B2
		' (set) Token: 0x06002DB0 RID: 11696 RVA: 0x001C32B4 File Offset: 0x001C14B4
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

		' Token: 0x06002DB1 RID: 11697 RVA: 0x0011427C File Offset: 0x0011247C
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

		' Token: 0x06002DB2 RID: 11698 RVA: 0x001C32F8 File Offset: 0x001C14F8
		Public Sub auto()
			Try
				Me.txtID.Text = Me.GenerateID()
				Me.txtProductCode.Text = "P-" + Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002DB3 RID: 11699 RVA: 0x001C336C File Offset: 0x001C156C
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

		' Token: 0x06002DB4 RID: 11700 RVA: 0x0001CFBC File Offset: 0x0001B1BC
		Public Sub Reset()
			Me.txtProductName.Text = ""
			Me.DataGridView1.DataSource = Nothing
			Me.DataGridView1.Visible = False
			Me.Getdata()
		End Sub

		' Token: 0x06002DB5 RID: 11701 RVA: 0x001C366C File Offset: 0x001C186C
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

		' Token: 0x06002DB6 RID: 11702 RVA: 0x001C3754 File Offset: 0x001C1954
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

		' Token: 0x06002DB7 RID: 11703 RVA: 0x0001CFF1 File Offset: 0x0001B1F1
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06002DB8 RID: 11704 RVA: 0x001C3A60 File Offset: 0x001C1C60
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

		' Token: 0x06002DB9 RID: 11705 RVA: 0x00113F98 File Offset: 0x00112198
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

		' Token: 0x06002DBA RID: 11706 RVA: 0x001C3B48 File Offset: 0x001C1D48
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Dim folderBrowserDialog As FolderBrowserDialog = Me.FolderBrowserDialog1
			Dim flag As Boolean = Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK
			If flag Then
				Dim selectedPath As String = folderBrowserDialog.SelectedPath
				File.WriteAllBytes(selectedPath + "\Product_Format.xls", Resources.Product_Format)
				Dim flag2 As Boolean = MyProject.Computer.FileSystem.FileExists(selectedPath + "\Product_Format.xls")
				If flag2 Then
					File.Delete(selectedPath + "\Product_Format.xls")
					File.WriteAllBytes(selectedPath + "\Product_Format.xls", Resources.Product_Format)
					MessageBox.Show("Successfully Saved" & vbLf, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					MessageBox.Show("Not Saved" & vbLf, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			End If
		End Sub

		' Token: 0x06002DBB RID: 11707 RVA: 0x001C3C0C File Offset: 0x001C1E0C
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

		' Token: 0x06002DBC RID: 11708 RVA: 0x001C3D08 File Offset: 0x001C1F08
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

		' Token: 0x06002DBD RID: 11709 RVA: 0x001C3E80 File Offset: 0x001C2080
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

		' Token: 0x06002DBE RID: 11710 RVA: 0x001C3F3C File Offset: 0x001C213C
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

		' Token: 0x06002DBF RID: 11711 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06002DC0 RID: 11712 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06002DC1 RID: 11713 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06002DC2 RID: 11714 RVA: 0x00087110 File Offset: 0x00085310
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

		' Token: 0x06002DC3 RID: 11715 RVA: 0x001C4008 File Offset: 0x001C2208
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

		' Token: 0x06002DC4 RID: 11716 RVA: 0x001C42B4 File Offset: 0x001C24B4
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

		' Token: 0x06002DC5 RID: 11717 RVA: 0x001C43C4 File Offset: 0x001C25C4
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
								MessageBox.Show("ID Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag6 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(1).Value.ToString(), "", False) = 0
							If flag6 Then
								MessageBox.Show("Product Code Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag7 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(2).Value.ToString(), "", False) = 0
							If flag7 Then
								MessageBox.Show("Product Name Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag8 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(3).Value.ToString(), "", False) = 0
							If flag8 Then
								MessageBox.Show("Sub Category ID Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag9 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(7).Value.ToString(), "", False) = 0
							If flag9 Then
								MessageBox.Show("Purchase Price Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag10 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(8).Value.ToString(), "", False) = 0
							If flag10 Then
								MessageBox.Show("Retail Sale Price Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag11 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(9).Value.ToString(), "", False) = 0
							If flag11 Then
								MessageBox.Show("Disc% Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag12 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(10).Value.ToString(), "", False) = 0
							If flag12 Then
								MessageBox.Show("CGST% Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag13 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(11).Value.ToString(), "", False) = 0
							If flag13 Then
								MessageBox.Show("SGST% Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag14 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(12).Value.ToString(), "", False) = 0
							If flag14 Then
								MessageBox.Show("CESS% Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag15 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(13).Value.ToString(), "", False) = 0
							If flag15 Then
								MessageBox.Show("Wholesale Price Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag16 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(14).Value.ToString(), "", False) = 0
							If flag16 Then
								MessageBox.Show("Purchase Unit Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag17 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(15).Value.ToString(), "", False) = 0
							If flag17 Then
								MessageBox.Show("Sale Unit Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag18 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(16).Value.ToString(), "", False) = 0
							If flag18 Then
								MessageBox.Show("Alter Unit Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag19 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(17).Value.ToString(), "", False) = 0
							If flag19 Then
								MessageBox.Show("Conversion Value Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag20 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(18).Value.ToString(), "", False) = 0
							If flag20 Then
								MessageBox.Show("Minimum Stock Value Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag21 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(19).Value.ToString(), "", False) = 0
							If flag21 Then
								MessageBox.Show("MRP Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag22 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(22).Value.ToString(), "", False) = 0
							If flag22 Then
								MessageBox.Show("Opening Qty Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag23 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(28).Value.ToString(), "", False) = 0
							If flag23 Then
								MessageBox.Show("Barcode Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim flag24 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(29).Value.ToString(), "", False) = 0
							If flag24 Then
								MessageBox.Show("Default Sale Qty Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
							Dim num2 As Integer = i + 1
							Dim num3 As Integer = Me.DataGridView1.RowCount - 1
							For j As Integer = num2 To num3
								Dim flag25 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(28).Value.ToString(), Me.DataGridView1.Rows(j).Cells(28).Value.ToString(), False) = 0
								If flag25 Then
									MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject("Duplicate Barcode Number found ", Me.DataGridView1.Rows(i).Cells(28).Value)))
									Return
								End If
							Next
						Next
						Try
							For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
								Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
								Dim flag26 As Boolean = Not dataGridViewRow.IsNewRow
								If flag26 Then
									SqlConnection.ClearAllPools()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text2 As String = "select Barcode from Product_OpeningStock Where Barcode=@d1"
									ModCommonClasses.cmd = New SqlCommand(text2)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells(28).Value.ToString())
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag27 As Boolean = ModCommonClasses.rdr.Read()
									If flag27 Then
										MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Barcode '", dataGridViewRow.Cells(28).Value), "' Already Exists")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Dim flag28 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag28 Then
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
								Dim flag29 As Boolean = Not dataGridViewRow2.IsNewRow
								If flag29 Then
									SqlConnection.ClearAllPools()
									Try
										Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
											sqlConnection.Open()
											Dim text3 As String = "select Barcode from Temp_Stock Where Barcode=@d1"
											Using sqlCommand As SqlCommand = New SqlCommand(text3, sqlConnection)
												sqlCommand.Parameters.AddWithValue("@d1", dataGridViewRow2.Cells(28).Value.ToString())
												Dim num4 As Integer = Conversions.ToInteger(sqlCommand.ExecuteScalar())
												Dim flag30 As Boolean = num4 > 0
												If flag30 Then
													MessageBox.Show("Barcode '" + dataGridViewRow2.Cells(28).Value.ToString() + "' Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													Return
												End If
												Dim flag31 As Boolean = ModCommonClasses.rdr IsNot Nothing
												If flag31 Then
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
						Dim text4 As String = "SELECT * FROM tbl_loyalty_setting WHERE id = 1"
						ModCommonClasses.cmd = New SqlCommand(text4)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag32 As Boolean = ModCommonClasses.rdr.Read()
						Dim text5 As String
						Dim num5 As Double
						If flag32 Then
							text5 = ModCommonClasses.rdr(1).ToString()
							num5 = Conversions.ToDouble(ModCommonClasses.rdr(2).ToString())
							Dim flag33 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag33 Then
								ModCommonClasses.rdr.Close()
							End If
						End If
						Try
							Try
								For Each obj3 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
									Dim dataGridViewRow3 As DataGridViewRow = CType(obj3, DataGridViewRow)
									flag = False
									Try
										Dim flag34 As Boolean = Me.IsProductExist(dataGridViewRow3.Cells(0).Value.ToString())
										If flag34 Then
											Dim flag35 As Boolean = Operators.CompareString(dataGridViewRow3.Cells(24).Value.ToString(), "", False) = 0
											If Not flag35 Then
												Dim text6 As String = Me.GenerateDate(dataGridViewRow3.Cells(24).Value.ToString())
											End If
											Dim flag36 As Boolean = Operators.CompareString(dataGridViewRow3.Cells(25).Value.ToString(), "", False) = 0
											If Not flag36 Then
												Dim text7 As String = Me.GenerateDate(dataGridViewRow3.Cells(25).Value.ToString())
											End If
											flag = True
										End If
										Dim flag37 As Boolean = Not flag
										If flag37 Then
											Dim flag38 As Boolean = Not dataGridViewRow3.IsNewRow
											If flag38 Then
												Me.Cursor = Cursors.WaitCursor
												Me.Timer1.Enabled = True
												SqlConnection.ClearAllPools()
												Me.auto()
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text8 As String = "insert into Product(PID,ProductCode, Productname, SubCategoryID,HSNCode,PartNo, Description, CostPrice, SellingPrice," & vbCrLf & "                                                Discount,CGST,SGST,CESS, ReorderPoint,OpeningStock,Barcode,PurchaseUnit,SalesUnit,SalesAltUnit,Conv,MinStock,MRP,Status," & vbCrLf & "                                                STax,PTax,GDown,Rack,DefQty,AddDate, loyality_mode, loyality_value)" & vbCrLf & "                                                VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24," & vbCrLf & "                                                @d25,@d26,@d27,@d28,@d29,@d30)"
												ModCommonClasses.cmd = New SqlCommand(text8)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(dataGridViewRow3.Cells(0).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow3.Cells(1).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow3.Cells(2).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(dataGridViewRow3.Cells(3).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d4", dataGridViewRow3.Cells(4).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d5", dataGridViewRow3.Cells(5).Value.ToString())
												Dim flag39 As Boolean = dataGridViewRow3.Cells(6).Value IsNot Nothing
												If flag39 Then
													ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow3.Cells(6).Value.ToString())
												Else
													ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow3.Cells(2).Value.ToString())
												End If
												ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(dataGridViewRow3.Cells(7).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(dataGridViewRow3.Cells(8).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(dataGridViewRow3.Cells(9).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(dataGridViewRow3.Cells(10).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(dataGridViewRow3.Cells(11).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(dataGridViewRow3.Cells(12).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(dataGridViewRow3.Cells(13).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "0")
												ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "0")
												ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dataGridViewRow3.Cells(14).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow3.Cells(15).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d18", dataGridViewRow3.Cells(16).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(17).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d20", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(18).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(19).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d22", "Yes")
												ModCommonClasses.cmd.Parameters.AddWithValue("@d23", "Inclusive")
												ModCommonClasses.cmd.Parameters.AddWithValue("@d24", "Exclusive")
												ModCommonClasses.cmd.Parameters.AddWithValue("@d25", dataGridViewRow3.Cells(20).Value.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d26", dataGridViewRow3.Cells(21).Value.ToString())
												Dim flag40 As Boolean = Conversions.ToBoolean(Operators.OrObject(Operators.CompareString(dataGridViewRow3.Cells(29).Value.ToString(), "", False) = 0, Operators.CompareObjectEqual(dataGridViewRow3.Cells(29).Value, "0", False)))
												If flag40 Then
													ModCommonClasses.cmd.Parameters.AddWithValue("@d27", "1")
												Else
													ModCommonClasses.cmd.Parameters.AddWithValue("@d27", dataGridViewRow3.Cells(29).Value.ToString())
												End If
												ModCommonClasses.cmd.Parameters.AddWithValue("@d28", DateTime.Today)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d29", text5.ToString())
												ModCommonClasses.cmd.Parameters.AddWithValue("@d30", Conversion.Val(num5))
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.CommandTimeout = 0
												ModCommonClasses.cmd.ExecuteNonQuery()
												ModCommonClasses.con.Close()
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text9 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
												ModCommonClasses.cmd = New SqlCommand(text9)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(dataGridViewRow3.Cells(0).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow3.Cells(15).Value.ToString())
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.ExecuteReader()
												ModCommonClasses.con.Close()
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text10 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
												ModCommonClasses.cmd = New SqlCommand(text10)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(dataGridViewRow3.Cells(0).Value.ToString()))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow3.Cells(16).Value.ToString())
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.ExecuteReader()
												ModCommonClasses.con.Close()
												Dim flag41 As Boolean = Operators.CompareString(dataGridViewRow3.Cells(28).Value.ToString(), "", False) <> 0
												If flag41 Then
													SqlConnection.ClearAllPools()
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text11 As String = "Select Barcode from Product_OpeningStock where Barcode=@d1"
													ModCommonClasses.cmd = New SqlCommand(text11)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow3.Cells(28).Value.ToString())
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.cmd.CommandTimeout = 0
													ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
													Dim flag42 As Boolean = Not ModCommonClasses.rdr.Read()
													If flag42 Then
														SqlConnection.ClearAllPools()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim flag43 As Boolean = Operators.CompareString(dataGridViewRow3.Cells(24).Value.ToString(), "", False) = 0
														Dim text6 As String
														If flag43 Then
															text6 = ""
														Else
															text6 = Me.GenerateDate(dataGridViewRow3.Cells(24).Value.ToString())
														End If
														Dim flag44 As Boolean = Operators.CompareString(dataGridViewRow3.Cells(25).Value.ToString(), "", False) = 0
														Dim text7 As String
														If flag44 Then
															text7 = ""
														Else
															text7 = Me.GenerateDate(dataGridViewRow3.Cells(25).Value.ToString())
														End If
														Dim text12 As String = "insert into Product_OpeningStock(ProductID,Qty,MRP,SalePrice,WSalePrice,Batch,Mfgdate,Expdate,Size,Colour,Barcode,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18)"
														ModCommonClasses.cmd = New SqlCommand(text12)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(dataGridViewRow3.Cells(0).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(dataGridViewRow3.Cells(22).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(dataGridViewRow3.Cells(19).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(dataGridViewRow3.Cells(8).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(dataGridViewRow3.Cells(13).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow3.Cells(23).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d7", text6)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d8", text7)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow3.Cells(26).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d10", dataGridViewRow3.Cells(27).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d11", dataGridViewRow3.Cells(28).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d12", DateTime.Today)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(dataGridViewRow3.Cells(7).Value.ToString()))
														Dim num6 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(7).Value))
														Dim num7 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(22).Value))
														Dim num8 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(10).Value))
														Dim num9 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(11).Value))
														Dim num10 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(12).Value))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d16", num6 * num7 + num6 * num7 * ((num8 + num9 + num10) / 100.0))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow3.Cells(30).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d18", dataGridViewRow3.Cells(31).Value.ToString())
														ModCommonClasses.cmd.CommandTimeout = 0
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
														SqlConnection.ClearAllPools()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text13 As String = "insert into Product_Join(ProductID,Photo) VALUES (" + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value))) + ",@img)"
														ModCommonClasses.cmd = New SqlCommand(text13)
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
															Dim text14 As String = "select ProductID from StockMovement where ProductID=@d1"
															ModCommonClasses.cmd = New SqlCommand(text14)
															ModCommonClasses.cmd.Connection = ModCommonClasses.con
															ModCommonClasses.cmd.CommandTimeout = 0
															ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
															ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
															Dim flag45 As Boolean = Not ModCommonClasses.rdr.Read()
															If flag45 Then
																ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))), 0D, New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(22).Value))), 0D, DateAndTime.Today, dataGridViewRow3.Cells(1).Value.ToString())
															Else
																ModCommonClasses.con = New SqlConnection(ModCS.cs)
																ModCommonClasses.con.Open()
																Dim text15 As String = "select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 and Date < @d3"
																ModCommonClasses.cmd = New SqlCommand(text15)
																ModCommonClasses.cmd.Connection = ModCommonClasses.con
																ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d3", DateAndTime.Today)
																ModCommonClasses.cmd.CommandTimeout = 0
																ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																Dim flag46 As Boolean = ModCommonClasses.rdr.Read()
																Dim num11 As Double
																If flag46 Then
																	num11 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
																Else
																	num11 = 0.0
																End If
																ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))), New Decimal(num11), New Decimal(Conversion.Val(dataGridViewRow3.Cells(22).Value.ToString())), 0D, DateAndTime.Today, dataGridViewRow3.Cells(1).Value.ToString())
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
									Dim flag47 As Boolean = Operators.CompareString(dataGridViewRow4.Cells(24).Value.ToString(), "", False) = 0
									Dim text16 As String
									If flag47 Then
										text16 = ""
									Else
										text16 = Me.GenerateDate(dataGridViewRow4.Cells(24).Value.ToString())
									End If
									Dim flag48 As Boolean = Operators.CompareString(dataGridViewRow4.Cells(25).Value.ToString(), "", False) = 0
									Dim text17 As String
									If flag48 Then
										text17 = ""
									Else
										text17 = Me.GenerateDate(dataGridViewRow4.Cells(25).Value.ToString())
									End If
									Dim checked2 As Boolean = Me.CheckBox1.Checked
									If checked2 Then
										Me.Generate_GiftQR(Conversions.ToString(dataGridViewRow4.Cells(28).Value))
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text18 As String = "insert into Temp_Stock(ProductID,Qty,Barcode,SPrice,WPrice,StLimit,MRP,Batch,Mfgdate,Expdate,Size,Colour,SalePrice,WSalePrice,SuplName,IMEI1,IMEI2,PPrice,EPPrice,QrBarcode,SalesManPur,Variant_id) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22)"
										ModCommonClasses.cmd = New SqlCommand(text18)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(dataGridViewRow4.Cells(0).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(dataGridViewRow4.Cells(22).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow4.Cells(28).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(dataGridViewRow4.Cells(8).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(dataGridViewRow4.Cells(13).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(dataGridViewRow4.Cells(18).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(dataGridViewRow4.Cells(19).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", dataGridViewRow4.Cells(23).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d9", text16)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d10", text17)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d11", dataGridViewRow4.Cells(26).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d12", dataGridViewRow4.Cells(27).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Opening Stock")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dataGridViewRow4.Cells(30).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow4.Cells(31).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(dataGridViewRow4.Cells(7).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(dataGridViewRow4.Cells(7).Value.ToString()))
										Dim memoryStream2 As MemoryStream = New MemoryStream()
										Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
										bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
										Dim buffer2 As Byte() = memoryStream2.GetBuffer()
										Dim sqlParameter2 As SqlParameter = New SqlParameter("@d20", SqlDbType.Image)
										sqlParameter2.Value = buffer2
										ModCommonClasses.cmd.Parameters.Add(sqlParameter2)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d21", 0.0)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Conversion.Val(dataGridViewRow4.Cells(0).Value.ToString()))
										ModCommonClasses.cmd.CommandTimeout = 0
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
									End If
									Dim flag49 As Boolean = Not flag
									If flag49 Then
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

		' Token: 0x06002DC6 RID: 11718 RVA: 0x001C0B50 File Offset: 0x001BED50
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

		' Token: 0x06002DC7 RID: 11719 RVA: 0x001C690C File Offset: 0x001C4B0C
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06002DC8 RID: 11720 RVA: 0x0001D00D File Offset: 0x0001B20D
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06002DC9 RID: 11721 RVA: 0x0001CB64 File Offset: 0x0001AD64
		Private Sub GelButton1_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmExportImportExcel_OpeningStock.ShowDialog()
		End Sub

		' Token: 0x06002DCA RID: 11722 RVA: 0x0001D017 File Offset: 0x0001B217
		Private Sub GelButton5_Click(sender As Object, e As EventArgs)
			MyBase.Dispose()
			MyProject.Forms.frmLSetDefault.lbltype.Text = "import"
			MyProject.Forms.frmLSetDefault.ShowDialog()
		End Sub

		' Token: 0x06002DCB RID: 11723 RVA: 0x0001CBAB File Offset: 0x0001ADAB
		Private Sub btnImportPro_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmImportPro.ShowDialog()
			MyProject.Forms.frmImportPro.Dispose()
		End Sub
	End Class
End Namespace
