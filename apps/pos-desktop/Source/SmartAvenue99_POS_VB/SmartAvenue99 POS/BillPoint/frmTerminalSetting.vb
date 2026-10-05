Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO.Ports
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000559 RID: 1369
	<DesignerGenerated()>
	Public Partial Class frmTerminalSetting
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010BC8 RID: 68552 RVA: 0x009C5FBC File Offset: 0x009C41BC
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmTerminalSetting_Load
			AddHandler MyBase.Closing, AddressOf Me.frmTerminalSetting_Closing
			AddHandler MyBase.KeyDown, AddressOf Me.frmTerminalSetting_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006793 RID: 26515
		' (get) Token: 0x06010BCB RID: 68555 RVA: 0x000737E3 File Offset: 0x000719E3
		' (set) Token: 0x06010BCC RID: 68556 RVA: 0x000737ED File Offset: 0x000719ED
		Friend Overridable Property Label1 As Label

		' Token: 0x17006794 RID: 26516
		' (get) Token: 0x06010BCD RID: 68557 RVA: 0x000737F6 File Offset: 0x000719F6
		' (set) Token: 0x06010BCE RID: 68558 RVA: 0x00073800 File Offset: 0x00071A00
		Friend Overridable Property Label2 As Label

		' Token: 0x17006795 RID: 26517
		' (get) Token: 0x06010BCF RID: 68559 RVA: 0x00073809 File Offset: 0x00071A09
		' (set) Token: 0x06010BD0 RID: 68560 RVA: 0x00073813 File Offset: 0x00071A13
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17006796 RID: 26518
		' (get) Token: 0x06010BD1 RID: 68561 RVA: 0x0007381C File Offset: 0x00071A1C
		' (set) Token: 0x06010BD2 RID: 68562 RVA: 0x00073826 File Offset: 0x00071A26
		Friend Overridable Property txtID As TextBox

		' Token: 0x17006797 RID: 26519
		' (get) Token: 0x06010BD3 RID: 68563 RVA: 0x0007382F File Offset: 0x00071A2F
		' (set) Token: 0x06010BD4 RID: 68564 RVA: 0x00073839 File Offset: 0x00071A39
		Friend Overridable Property Label3 As Label

		' Token: 0x17006798 RID: 26520
		' (get) Token: 0x06010BD5 RID: 68565 RVA: 0x00073842 File Offset: 0x00071A42
		' (set) Token: 0x06010BD6 RID: 68566 RVA: 0x009C8D54 File Offset: 0x009C6F54
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006799 RID: 26521
		' (get) Token: 0x06010BD7 RID: 68567 RVA: 0x0007384C File Offset: 0x00071A4C
		' (set) Token: 0x06010BD8 RID: 68568 RVA: 0x009C8DB4 File Offset: 0x009C6FB4
		Private _cmbPrinter As ComboBox
		Friend Overridable Property cmbPrinter As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbPrinter
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbPrinter_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbPrinter
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbPrinter = value
				comboBox = Me._cmbPrinter
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700679A RID: 26522
		' (get) Token: 0x06010BD9 RID: 68569 RVA: 0x00073856 File Offset: 0x00071A56
		' (set) Token: 0x06010BDA RID: 68570 RVA: 0x009C8E14 File Offset: 0x009C7014
		Private _txtTillID As TextBox
		Friend Overridable Property txtTillID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtTillID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtTillID_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtTillID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtTillID = value
				textBox = Me._txtTillID
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700679B RID: 26523
		' (get) Token: 0x06010BDB RID: 68571 RVA: 0x00073860 File Offset: 0x00071A60
		' (set) Token: 0x06010BDC RID: 68572 RVA: 0x0007386A File Offset: 0x00071A6A
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700679C RID: 26524
		' (get) Token: 0x06010BDD RID: 68573 RVA: 0x00073873 File Offset: 0x00071A73
		' (set) Token: 0x06010BDE RID: 68574 RVA: 0x0007387D File Offset: 0x00071A7D
		Friend Overridable Property Label4 As Label

		' Token: 0x1700679D RID: 26525
		' (get) Token: 0x06010BDF RID: 68575 RVA: 0x00073886 File Offset: 0x00071A86
		' (set) Token: 0x06010BE0 RID: 68576 RVA: 0x009C8E74 File Offset: 0x009C7074
		Private _cmbPrinterType As ComboBox
		Friend Overridable Property cmbPrinterType As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbPrinterType
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbPrinterType_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbPrinterType
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbPrinterType = value
				comboBox = Me._cmbPrinterType
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700679E RID: 26526
		' (get) Token: 0x06010BE1 RID: 68577 RVA: 0x00073890 File Offset: 0x00071A90
		' (set) Token: 0x06010BE2 RID: 68578 RVA: 0x0007389A File Offset: 0x00071A9A
		Friend Overridable Property CheckBox1 As CheckBox

		' Token: 0x1700679F RID: 26527
		' (get) Token: 0x06010BE3 RID: 68579 RVA: 0x000738A3 File Offset: 0x00071AA3
		' (set) Token: 0x06010BE4 RID: 68580 RVA: 0x000738AD File Offset: 0x00071AAD
		Friend Overridable Property Label5 As Label

		' Token: 0x170067A0 RID: 26528
		' (get) Token: 0x06010BE5 RID: 68581 RVA: 0x000738B6 File Offset: 0x00071AB6
		' (set) Token: 0x06010BE6 RID: 68582 RVA: 0x000738C0 File Offset: 0x00071AC0
		Friend Overridable Property PrintDocument1 As PrintDocument

		' Token: 0x170067A1 RID: 26529
		' (get) Token: 0x06010BE7 RID: 68583 RVA: 0x000738C9 File Offset: 0x00071AC9
		' (set) Token: 0x06010BE8 RID: 68584 RVA: 0x000738D3 File Offset: 0x00071AD3
		Friend Overridable Property PrintDialog1 As PrintDialog

		' Token: 0x170067A2 RID: 26530
		' (get) Token: 0x06010BE9 RID: 68585 RVA: 0x000738DC File Offset: 0x00071ADC
		' (set) Token: 0x06010BEA RID: 68586 RVA: 0x009C8ED4 File Offset: 0x009C70D4
		Private _ComboBox2 As ComboBox
		Friend Overridable Property ComboBox2 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.ComboBox2_KeyDown
				Dim comboBox As ComboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._ComboBox2 = value
				comboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170067A3 RID: 26531
		' (get) Token: 0x06010BEB RID: 68587 RVA: 0x000738E6 File Offset: 0x00071AE6
		' (set) Token: 0x06010BEC RID: 68588 RVA: 0x000738F0 File Offset: 0x00071AF0
		Friend Overridable Property Label8 As Label

		' Token: 0x170067A4 RID: 26532
		' (get) Token: 0x06010BED RID: 68589 RVA: 0x000738F9 File Offset: 0x00071AF9
		' (set) Token: 0x06010BEE RID: 68590 RVA: 0x009C8F18 File Offset: 0x009C7118
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.ComboBox1_KeyDown
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170067A5 RID: 26533
		' (get) Token: 0x06010BEF RID: 68591 RVA: 0x00073903 File Offset: 0x00071B03
		' (set) Token: 0x06010BF0 RID: 68592 RVA: 0x0007390D File Offset: 0x00071B0D
		Friend Overridable Property Label7 As Label

		' Token: 0x170067A6 RID: 26534
		' (get) Token: 0x06010BF1 RID: 68593 RVA: 0x00073916 File Offset: 0x00071B16
		' (set) Token: 0x06010BF2 RID: 68594 RVA: 0x009C8F5C File Offset: 0x009C715C
		Private _ComboBox4 As ComboBox
		Friend Overridable Property ComboBox4 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.ComboBox4_KeyDown
				Dim comboBox As ComboBox = Me._ComboBox4
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._ComboBox4 = value
				comboBox = Me._ComboBox4
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170067A7 RID: 26535
		' (get) Token: 0x06010BF3 RID: 68595 RVA: 0x00073920 File Offset: 0x00071B20
		' (set) Token: 0x06010BF4 RID: 68596 RVA: 0x0007392A File Offset: 0x00071B2A
		Friend Overridable Property Label10 As Label

		' Token: 0x170067A8 RID: 26536
		' (get) Token: 0x06010BF5 RID: 68597 RVA: 0x00073933 File Offset: 0x00071B33
		' (set) Token: 0x06010BF6 RID: 68598 RVA: 0x009C8FA0 File Offset: 0x009C71A0
		Private _ComboBox3 As ComboBox
		Friend Overridable Property ComboBox3 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.ComboBox3_KeyDown
				Dim comboBox As ComboBox = Me._ComboBox3
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._ComboBox3 = value
				comboBox = Me._ComboBox3
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170067A9 RID: 26537
		' (get) Token: 0x06010BF7 RID: 68599 RVA: 0x0007393D File Offset: 0x00071B3D
		' (set) Token: 0x06010BF8 RID: 68600 RVA: 0x00073947 File Offset: 0x00071B47
		Friend Overridable Property Label9 As Label

		' Token: 0x170067AA RID: 26538
		' (get) Token: 0x06010BF9 RID: 68601 RVA: 0x00073950 File Offset: 0x00071B50
		' (set) Token: 0x06010BFA RID: 68602 RVA: 0x0007395A File Offset: 0x00071B5A
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x170067AB RID: 26539
		' (get) Token: 0x06010BFB RID: 68603 RVA: 0x00073963 File Offset: 0x00071B63
		' (set) Token: 0x06010BFC RID: 68604 RVA: 0x009C8FE4 File Offset: 0x009C71E4
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
				Dim button As Button = Me._Button2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button2 = value
				button = Me._Button2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170067AC RID: 26540
		' (get) Token: 0x06010BFD RID: 68605 RVA: 0x0007396D File Offset: 0x00071B6D
		' (set) Token: 0x06010BFE RID: 68606 RVA: 0x00073977 File Offset: 0x00071B77
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x170067AD RID: 26541
		' (get) Token: 0x06010BFF RID: 68607 RVA: 0x00073980 File Offset: 0x00071B80
		' (set) Token: 0x06010C00 RID: 68608 RVA: 0x009C9028 File Offset: 0x009C7228
		Private _Button3 As Button
		Friend Overridable Property Button3 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button3_Click
				Dim button As Button = Me._Button3
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button3 = value
				button = Me._Button3
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170067AE RID: 26542
		' (get) Token: 0x06010C01 RID: 68609 RVA: 0x0007398A File Offset: 0x00071B8A
		' (set) Token: 0x06010C02 RID: 68610 RVA: 0x009C906C File Offset: 0x009C726C
		Private _Button4 As Button
		Friend Overridable Property Button4 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button4_Click
				Dim button As Button = Me._Button4
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button4 = value
				button = Me._Button4
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170067AF RID: 26543
		' (get) Token: 0x06010C03 RID: 68611 RVA: 0x00073994 File Offset: 0x00071B94
		' (set) Token: 0x06010C04 RID: 68612 RVA: 0x009C90B0 File Offset: 0x009C72B0
		Private _ComboBox5 As ComboBox
		Friend Overridable Property ComboBox5 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox5_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox5
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox5 = value
				comboBox = Me._ComboBox5
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170067B0 RID: 26544
		' (get) Token: 0x06010C05 RID: 68613 RVA: 0x0007399E File Offset: 0x00071B9E
		' (set) Token: 0x06010C06 RID: 68614 RVA: 0x009C90F4 File Offset: 0x009C72F4
		Private _cmbSecDisplay As ComboBox
		Friend Overridable Property cmbSecDisplay As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSecDisplay
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbSecDisplay_KeyDown
				Dim comboBox As ComboBox = Me._cmbSecDisplay
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbSecDisplay = value
				comboBox = Me._cmbSecDisplay
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170067B1 RID: 26545
		' (get) Token: 0x06010C07 RID: 68615 RVA: 0x000739A8 File Offset: 0x00071BA8
		' (set) Token: 0x06010C08 RID: 68616 RVA: 0x000739B2 File Offset: 0x00071BB2
		Friend Overridable Property Label6 As Label

		' Token: 0x170067B2 RID: 26546
		' (get) Token: 0x06010C09 RID: 68617 RVA: 0x000739BB File Offset: 0x00071BBB
		' (set) Token: 0x06010C0A RID: 68618 RVA: 0x009C9138 File Offset: 0x009C7338
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

		' Token: 0x170067B3 RID: 26547
		' (get) Token: 0x06010C0B RID: 68619 RVA: 0x000739C5 File Offset: 0x00071BC5
		' (set) Token: 0x06010C0C RID: 68620 RVA: 0x009C917C File Offset: 0x009C737C
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

		' Token: 0x170067B4 RID: 26548
		' (get) Token: 0x06010C0D RID: 68621 RVA: 0x000739CF File Offset: 0x00071BCF
		' (set) Token: 0x06010C0E RID: 68622 RVA: 0x009C91C0 File Offset: 0x009C73C0
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

		' Token: 0x170067B5 RID: 26549
		' (get) Token: 0x06010C0F RID: 68623 RVA: 0x000739D9 File Offset: 0x00071BD9
		' (set) Token: 0x06010C10 RID: 68624 RVA: 0x009C9204 File Offset: 0x009C7404
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

		' Token: 0x170067B6 RID: 26550
		' (get) Token: 0x06010C11 RID: 68625 RVA: 0x000739E3 File Offset: 0x00071BE3
		' (set) Token: 0x06010C12 RID: 68626 RVA: 0x009C9248 File Offset: 0x009C7448
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

		' Token: 0x170067B7 RID: 26551
		' (get) Token: 0x06010C13 RID: 68627 RVA: 0x000739ED File Offset: 0x00071BED
		' (set) Token: 0x06010C14 RID: 68628 RVA: 0x000739F7 File Offset: 0x00071BF7
		Friend Overridable Property label15 As Label

		' Token: 0x170067B8 RID: 26552
		' (get) Token: 0x06010C15 RID: 68629 RVA: 0x00073A00 File Offset: 0x00071C00
		' (set) Token: 0x06010C16 RID: 68630 RVA: 0x00073A0A File Offset: 0x00071C0A
		Friend Overridable Property baudrateTxt As TextBox

		' Token: 0x170067B9 RID: 26553
		' (get) Token: 0x06010C17 RID: 68631 RVA: 0x00073A13 File Offset: 0x00071C13
		' (set) Token: 0x06010C18 RID: 68632 RVA: 0x00073A1D File Offset: 0x00071C1D
		Friend Overridable Property ComboBox7 As ComboBox

		' Token: 0x170067BA RID: 26554
		' (get) Token: 0x06010C19 RID: 68633 RVA: 0x00073A26 File Offset: 0x00071C26
		' (set) Token: 0x06010C1A RID: 68634 RVA: 0x00073A30 File Offset: 0x00071C30
		Friend Overridable Property Label12 As Label

		' Token: 0x170067BB RID: 26555
		' (get) Token: 0x06010C1B RID: 68635 RVA: 0x00073A39 File Offset: 0x00071C39
		' (set) Token: 0x06010C1C RID: 68636 RVA: 0x00073A43 File Offset: 0x00071C43
		Friend Overridable Property ComboBox6 As ComboBox

		' Token: 0x170067BC RID: 26556
		' (get) Token: 0x06010C1D RID: 68637 RVA: 0x00073A4C File Offset: 0x00071C4C
		' (set) Token: 0x06010C1E RID: 68638 RVA: 0x00073A56 File Offset: 0x00071C56
		Friend Overridable Property Label11 As Label

		' Token: 0x170067BD RID: 26557
		' (get) Token: 0x06010C1F RID: 68639 RVA: 0x00073A5F File Offset: 0x00071C5F
		' (set) Token: 0x06010C20 RID: 68640 RVA: 0x00073A69 File Offset: 0x00071C69
		Friend Overridable Property Label14 As Label

		' Token: 0x170067BE RID: 26558
		' (get) Token: 0x06010C21 RID: 68641 RVA: 0x00073A72 File Offset: 0x00071C72
		' (set) Token: 0x06010C22 RID: 68642 RVA: 0x00073A7C File Offset: 0x00071C7C
		Friend Overridable Property txtUPIid As TextBox

		' Token: 0x170067BF RID: 26559
		' (get) Token: 0x06010C23 RID: 68643 RVA: 0x00073A85 File Offset: 0x00071C85
		' (set) Token: 0x06010C24 RID: 68644 RVA: 0x00073A8F File Offset: 0x00071C8F
		Friend Overridable Property Label13 As Label

		' Token: 0x170067C0 RID: 26560
		' (get) Token: 0x06010C25 RID: 68645 RVA: 0x00073A98 File Offset: 0x00071C98
		' (set) Token: 0x06010C26 RID: 68646 RVA: 0x00073AA2 File Offset: 0x00071CA2
		Friend Overridable Property txtBrandName As TextBox

		' Token: 0x170067C1 RID: 26561
		' (get) Token: 0x06010C27 RID: 68647 RVA: 0x00073AAB File Offset: 0x00071CAB
		' (set) Token: 0x06010C28 RID: 68648 RVA: 0x00073AB5 File Offset: 0x00071CB5
		Friend Overridable Property chkActivePT As CheckBox

		' Token: 0x170067C2 RID: 26562
		' (get) Token: 0x06010C29 RID: 68649 RVA: 0x00073ABE File Offset: 0x00071CBE
		' (set) Token: 0x06010C2A RID: 68650 RVA: 0x00073AC8 File Offset: 0x00071CC8
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170067C3 RID: 26563
		' (get) Token: 0x06010C2B RID: 68651 RVA: 0x00073AD1 File Offset: 0x00071CD1
		' (set) Token: 0x06010C2C RID: 68652 RVA: 0x00073ADB File Offset: 0x00071CDB
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170067C4 RID: 26564
		' (get) Token: 0x06010C2D RID: 68653 RVA: 0x00073AE4 File Offset: 0x00071CE4
		' (set) Token: 0x06010C2E RID: 68654 RVA: 0x00073AEE File Offset: 0x00071CEE
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170067C5 RID: 26565
		' (get) Token: 0x06010C2F RID: 68655 RVA: 0x00073AF7 File Offset: 0x00071CF7
		' (set) Token: 0x06010C30 RID: 68656 RVA: 0x00073B01 File Offset: 0x00071D01
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170067C6 RID: 26566
		' (get) Token: 0x06010C31 RID: 68657 RVA: 0x00073B0A File Offset: 0x00071D0A
		' (set) Token: 0x06010C32 RID: 68658 RVA: 0x00073B14 File Offset: 0x00071D14
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170067C7 RID: 26567
		' (get) Token: 0x06010C33 RID: 68659 RVA: 0x00073B1D File Offset: 0x00071D1D
		' (set) Token: 0x06010C34 RID: 68660 RVA: 0x00073B27 File Offset: 0x00071D27
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170067C8 RID: 26568
		' (get) Token: 0x06010C35 RID: 68661 RVA: 0x00073B30 File Offset: 0x00071D30
		' (set) Token: 0x06010C36 RID: 68662 RVA: 0x00073B3A File Offset: 0x00071D3A
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x170067C9 RID: 26569
		' (get) Token: 0x06010C37 RID: 68663 RVA: 0x00073B43 File Offset: 0x00071D43
		' (set) Token: 0x06010C38 RID: 68664 RVA: 0x00073B4D File Offset: 0x00071D4D
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x170067CA RID: 26570
		' (get) Token: 0x06010C39 RID: 68665 RVA: 0x00073B56 File Offset: 0x00071D56
		' (set) Token: 0x06010C3A RID: 68666 RVA: 0x00073B60 File Offset: 0x00071D60
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x170067CB RID: 26571
		' (get) Token: 0x06010C3B RID: 68667 RVA: 0x00073B69 File Offset: 0x00071D69
		' (set) Token: 0x06010C3C RID: 68668 RVA: 0x00073B73 File Offset: 0x00071D73
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x170067CC RID: 26572
		' (get) Token: 0x06010C3D RID: 68669 RVA: 0x00073B7C File Offset: 0x00071D7C
		' (set) Token: 0x06010C3E RID: 68670 RVA: 0x00073B86 File Offset: 0x00071D86
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170067CD RID: 26573
		' (get) Token: 0x06010C3F RID: 68671 RVA: 0x00073B8F File Offset: 0x00071D8F
		' (set) Token: 0x06010C40 RID: 68672 RVA: 0x00073B99 File Offset: 0x00071D99
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x170067CE RID: 26574
		' (get) Token: 0x06010C41 RID: 68673 RVA: 0x00073BA2 File Offset: 0x00071DA2
		' (set) Token: 0x06010C42 RID: 68674 RVA: 0x00073BAC File Offset: 0x00071DAC
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x170067CF RID: 26575
		' (get) Token: 0x06010C43 RID: 68675 RVA: 0x00073BB5 File Offset: 0x00071DB5
		' (set) Token: 0x06010C44 RID: 68676 RVA: 0x00073BBF File Offset: 0x00071DBF
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x170067D0 RID: 26576
		' (get) Token: 0x06010C45 RID: 68677 RVA: 0x00073BC8 File Offset: 0x00071DC8
		' (set) Token: 0x06010C46 RID: 68678 RVA: 0x00073BD2 File Offset: 0x00071DD2
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x170067D1 RID: 26577
		' (get) Token: 0x06010C47 RID: 68679 RVA: 0x00073BDB File Offset: 0x00071DDB
		' (set) Token: 0x06010C48 RID: 68680 RVA: 0x00073BE5 File Offset: 0x00071DE5
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x170067D2 RID: 26578
		' (get) Token: 0x06010C49 RID: 68681 RVA: 0x00073BEE File Offset: 0x00071DEE
		' (set) Token: 0x06010C4A RID: 68682 RVA: 0x00073BF8 File Offset: 0x00071DF8
		Friend Overridable Property Label16 As Label

		' Token: 0x06010C4B RID: 68683 RVA: 0x009C928C File Offset: 0x009C748C
		Public Sub Reset()
			MyBase.Size = New Size(560, 562)
			MyBase.StartPosition = FormStartPosition.CenterScreen
			MyBase.Location = New Point(CInt(Math.Round(CDbl((Screen.PrimaryScreen.WorkingArea.Width - MyBase.Width)) / 2.0)), CInt(Math.Round(CDbl((Screen.PrimaryScreen.WorkingArea.Height - MyBase.Height)) / 2.0)))
			Me.cmbPrinter.Text = ""
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.cmbPrinter.SelectedIndex = -1
			Dim printerSettings As PrinterSettings = New PrinterSettings()
			Dim printerName As String = printerSettings.PrinterName
			Me.cmbPrinter.Text = printerName
			Me.cmbPrinterType.SelectedIndex = -1
			Me.txtTillID.Text = Dns.GetHostName()
			Me.txtTillID.Focus()
			Me.CheckBox1.Checked = False
			Me.ComboBox2.SelectedIndex = 0
			Me.ComboBox4.SelectedIndex = 0
			Me.ComboBox1.Text = ""
			Me.ComboBox3.Text = ""
			Me.ComboBox6.Text = ""
			Me.ComboBox7.Text = ""
			Me.baudrateTxt.Text = ""
			Me.txtUPIid.Text = ""
			Me.txtBrandName.Text = ""
			Me.cmbSecDisplay.SelectedIndex = 0
			Me.Getdata()
		End Sub

		' Token: 0x06010C4C RID: 68684 RVA: 0x009C9454 File Offset: 0x009C7654
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,RTRIM(TillID), RTRIM(PrinterName),RTRIM(PrinterType),RTRIM(CashDrawer),RTRIM(WSPort),RTRIM(ActiveWS),RTRIM(CDPort),RTRIM(CustomerDisplay),RTRIM(SecDisplay),QRDisplayPort,ActiveQR,BundRate,UPIID,BrandName,PT from PosPrinterSetting order by TillID", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010C4D RID: 68685 RVA: 0x009C962C File Offset: 0x009C782C
		Private Sub PopulateInstalledPrintersCombo()
			' The following expression was wrapped in a checked-statement
			Try
				Me.cmbPrinter.Items.Clear()
				Dim num As Integer = System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count - 1
				For i As Integer = 0 To num
					Dim text As String = System.Drawing.Printing.PrinterSettings.InstalledPrinters(i)
					Me.cmbPrinter.Items.Add(text)
				Next
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010C4E RID: 68686 RVA: 0x009C96BC File Offset: 0x009C78BC
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from PosPrinterSetting where ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					MessageBox.Show("Successfully Deleted", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Getdata()
					Me.Reset()
				Else
					MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				End If
				Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010C4F RID: 68687 RVA: 0x009C97DC File Offset: 0x009C79DC
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtTillID.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.cmbPrinter.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.cmbPrinterType.Text = dataGridViewRow.Cells(3).Value.ToString()
					Dim flag2 As Boolean = Operators.CompareString(dataGridViewRow.Cells(4).Value.ToString(), "Yes", False) = 0
					If flag2 Then
						Me.CheckBox1.Checked = True
					Else
						Me.CheckBox1.Checked = False
					End If
					Me.ComboBox1.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.ComboBox2.Text = dataGridViewRow.Cells(6).Value.ToString()
					Me.ComboBox3.Text = dataGridViewRow.Cells(7).Value.ToString()
					Me.ComboBox4.Text = dataGridViewRow.Cells(8).Value.ToString()
					Me.cmbSecDisplay.Text = dataGridViewRow.Cells(9).Value.ToString()
					Me.ComboBox6.Text = dataGridViewRow.Cells(10).Value.ToString()
					Me.ComboBox7.Text = dataGridViewRow.Cells(11).Value.ToString()
					Me.baudrateTxt.Text = dataGridViewRow.Cells(12).Value.ToString()
					Me.txtUPIid.Text = dataGridViewRow.Cells(13).Value.ToString()
					Me.txtBrandName.Text = dataGridViewRow.Cells(14).Value.ToString()
					Dim flag3 As Boolean = Operators.CompareString(dataGridViewRow.Cells(15).Value.ToString().Trim(), "Yes", False) = 0
					If flag3 Then
						Me.chkActivePT.Checked = True
					Else
						Me.chkActivePT.Checked = False
					End If
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06010C50 RID: 68688 RVA: 0x009C9AE8 File Offset: 0x009C7CE8
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

		' Token: 0x06010C51 RID: 68689 RVA: 0x009C9BD0 File Offset: 0x009C7DD0
		Private Sub frmTerminalSetting_Load(sender As Object, e As EventArgs)
			MyBase.Size = New Size(560, 562)
			MyBase.StartPosition = FormStartPosition.CenterScreen
			MyBase.Location = New Point(CInt(Math.Round(CDbl((Screen.PrimaryScreen.WorkingArea.Width - MyBase.Width)) / 2.0)), CInt(Math.Round(CDbl((Screen.PrimaryScreen.WorkingArea.Height - MyBase.Height)) / 2.0)))
			Me.ComboBox2.SelectedIndex = 0
			Me.ComboBox4.SelectedIndex = 0
			Me.cmbSecDisplay.SelectedIndex = 0
			Me.Getdata()
			Me.PopulateInstalledPrintersCombo()
			Dim printerSettings As PrinterSettings = New PrinterSettings()
			Dim printerName As String = printerSettings.PrinterName
			Me.cmbPrinter.Text = printerName
			Me.txtTillID.Text = Dns.GetHostName()
			Dim portNames As String() = SerialPort.GetPortNames()
			For Each text As String In portNames
				Me.ComboBox1.Items.Add(text)
				Me.ComboBox3.Items.Add(text)
				Me.ComboBox6.Items.Add(text)
			Next
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox3.SelectedIndex = -1
			Me.ComboBox3.SelectedIndex = -1
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
			Me.Convert_Language()
		End Sub

		' Token: 0x06010C52 RID: 68690 RVA: 0x009C9DC8 File Offset: 0x009C7FC8
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

		' Token: 0x06010C53 RID: 68691 RVA: 0x009C9F40 File Offset: 0x009C8140
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

		' Token: 0x06010C54 RID: 68692 RVA: 0x009C9FFC File Offset: 0x009C81FC
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

		' Token: 0x06010C55 RID: 68693 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06010C56 RID: 68694 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06010C57 RID: 68695 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06010C58 RID: 68696 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtTillID_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06010C59 RID: 68697 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbPrinter_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06010C5A RID: 68698 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbPrinterType_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06010C5B RID: 68699 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06010C5C RID: 68700 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub ComboBox2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06010C5D RID: 68701 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub ComboBox3_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06010C5E RID: 68702 RVA: 0x009CA0C8 File Offset: 0x009C82C8
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtTillID.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtTillID, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtTillID, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.cmbPrinterType.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.cmbPrinterType, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbPrinterType, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.cmbPrinter.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.cmbPrinter, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbPrinter, String.Empty)
			End If
		End Sub

		' Token: 0x06010C5F RID: 68703 RVA: 0x009CA1BC File Offset: 0x009C83BC
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			MyBase.Size = New Size(1035, 562)
			MyBase.StartPosition = FormStartPosition.CenterScreen
			MyBase.Location = New Point(CInt(Math.Round(CDbl((Screen.PrimaryScreen.WorkingArea.Width - MyBase.Width)) / 2.0)), CInt(Math.Round(CDbl((Screen.PrimaryScreen.WorkingArea.Height - MyBase.Height)) / 2.0)))
		End Sub

		' Token: 0x06010C60 RID: 68704 RVA: 0x009CA248 File Offset: 0x009C8448
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			MyBase.Size = New Size(560, 562)
			MyBase.StartPosition = FormStartPosition.CenterScreen
			MyBase.Location = New Point(CInt(Math.Round(CDbl((Screen.PrimaryScreen.WorkingArea.Width - MyBase.Width)) / 2.0)), CInt(Math.Round(CDbl((Screen.PrimaryScreen.WorkingArea.Height - MyBase.Height)) / 2.0)))
		End Sub

		' Token: 0x06010C61 RID: 68705 RVA: 0x00073C01 File Offset: 0x00071E01
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmInvoicePhoto.ShowDialog()
		End Sub

		' Token: 0x06010C62 RID: 68706 RVA: 0x009CA2D4 File Offset: 0x009C84D4
		Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox5.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Please Select Invoice Template Type", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.ComboBox5.Focus()
			Else
				Try
					Dim flag2 As Boolean = Me.ComboBox5.SelectedIndex = 4
					If flag2 Then
						Me.PictureBox1.Image = Image.FromFile(MyProject.Application.Info.DirectoryPath + "\Template\1LaserPrinterA4.jpg")
					Else
						Dim flag3 As Boolean = Me.ComboBox5.SelectedIndex = 5
						If flag3 Then
							Me.PictureBox1.Image = Image.FromFile(MyProject.Application.Info.DirectoryPath + "\Template\2LaserPrinterA4Professional.jpg")
						Else
							Dim flag4 As Boolean = Me.ComboBox5.SelectedIndex = 6
							If flag4 Then
								Me.PictureBox1.Image = Image.FromFile(MyProject.Application.Info.DirectoryPath + "\Template\3LaserPrinterA4Description.jpg")
							Else
								Dim flag5 As Boolean = Me.ComboBox5.SelectedIndex = 7
								If flag5 Then
									Me.PictureBox1.Image = Image.FromFile(MyProject.Application.Info.DirectoryPath + "\Template\4LaserPrinterA4NoTax.jpg")
								Else
									Dim flag6 As Boolean = Me.ComboBox5.SelectedIndex = 8
									If flag6 Then
										Me.PictureBox1.Image = Image.FromFile(MyProject.Application.Info.DirectoryPath + "\Template\5LaserPrinterA4NoTaxDescr.jpg")
									Else
										Dim flag7 As Boolean = Me.ComboBox5.SelectedIndex = 9
										If flag7 Then
											Me.PictureBox1.Image = Image.FromFile(MyProject.Application.Info.DirectoryPath + "\Template\6LaserPrinterA4Mobile.jpg")
										Else
											Dim flag8 As Boolean = Me.ComboBox5.SelectedIndex = 10
											If flag8 Then
												Me.PictureBox1.Image = Image.FromFile(MyProject.Application.Info.DirectoryPath + "\Template\7LaserPrinterA5.jpg")
											Else
												Dim flag9 As Boolean = Me.ComboBox5.SelectedIndex = 11
												If flag9 Then
													Me.PictureBox1.Image = Image.FromFile(MyProject.Application.Info.DirectoryPath + "\Template\8LaserPrinterA5Professional.jpg")
												Else
													Dim flag10 As Boolean = Me.ComboBox5.SelectedIndex = 12
													If flag10 Then
														Me.PictureBox1.Image = Image.FromFile(MyProject.Application.Info.DirectoryPath + "\Template\9LaserPrinterA5Economical.jpg")
													Else
														Dim flag11 As Boolean = Me.ComboBox5.SelectedIndex = 13
														If flag11 Then
															Me.PictureBox1.Image = Image.FromFile(MyProject.Application.Info.DirectoryPath + "\Template\10LaserPrinterA5Description.jpg")
														Else
															Dim flag12 As Boolean = Me.ComboBox5.SelectedIndex = 14
															If flag12 Then
																Me.PictureBox1.Image = Image.FromFile(MyProject.Application.Info.DirectoryPath + "\Template\11LaserPrinterA5NoTax.jpg")
															Else
																Dim flag13 As Boolean = Me.ComboBox5.SelectedIndex = 15
																If flag13 Then
																	Me.PictureBox1.Image = Image.FromFile(MyProject.Application.Info.DirectoryPath + "\Template\12LaserPrinterA5NoTaxDescr.jpg")
																Else
																	Dim flag14 As Boolean = Me.ComboBox5.SelectedIndex = 16
																	If flag14 Then
																		Me.PictureBox1.Image = Image.FromFile(MyProject.Application.Info.DirectoryPath + "\Template\13LaserPrinterA5Mobile.jpg")
																	Else
																		Dim flag15 As Boolean = Me.ComboBox5.SelectedIndex = 17
																		If flag15 Then
																			Me.PictureBox1.Image = Image.FromFile(MyProject.Application.Info.DirectoryPath + "\Template\14ThermalPrinter3InchSlip.jpg")
																		Else
																			Dim flag16 As Boolean = Me.ComboBox5.SelectedIndex = 18
																			If flag16 Then
																				Me.PictureBox1.Image = Image.FromFile(MyProject.Application.Info.DirectoryPath + "\Template\15ThermalPrinter4InchSlip.jpg")
																			Else
																				Dim flag17 As Boolean = Me.ComboBox5.SelectedIndex = 19
																				If flag17 Then
																					Me.PictureBox1.Image = Image.FromFile(MyProject.Application.Info.DirectoryPath + "\Template\16ThermalPrinter3InchExpress.jpg")
																				Else
																					Dim flag18 As Boolean = Me.ComboBox5.SelectedIndex = 20
																					If flag18 Then
																						Me.PictureBox1.Image = Image.FromFile(MyProject.Application.Info.DirectoryPath + "\Template\17ThermalPrinter4InchExpress.jpg")
																					Else
																						Dim flag19 As Boolean = Me.ComboBox5.SelectedIndex = 21
																						If flag19 Then
																							Me.PictureBox1.Image = Image.FromFile(MyProject.Application.Info.DirectoryPath + "\Template\18ThermalPrinter3Inch1Page.jpg")
																						Else
																							Dim flag20 As Boolean = Me.ComboBox5.SelectedIndex = 22
																							If flag20 Then
																								Me.PictureBox1.Image = Image.FromFile(MyProject.Application.Info.DirectoryPath + "\Template\19ThermalPrinter4Inch1Page.jpg")
																							Else
																								Dim flag21 As Boolean = Me.ComboBox5.SelectedIndex = 0 OrElse Me.ComboBox5.SelectedIndex = 1 OrElse Me.ComboBox5.SelectedIndex = 2 OrElse Me.ComboBox5.SelectedIndex = 3
																								If flag21 Then
																									Me.PictureBox1.Image = Resources.Noimage
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
					Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
				Catch ex As Exception
					Me.PictureBox1.Image = Resources.Noimage
					Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
				End Try
			End If
		End Sub

		' Token: 0x06010C63 RID: 68707 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub ComboBox4_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06010C64 RID: 68708 RVA: 0x00073C14 File Offset: 0x00071E14
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06010C65 RID: 68709 RVA: 0x009CA8D8 File Offset: 0x009C8AD8
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
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtTillID.Text)) = 0
				If flag3 Then
					MessageBox.Show("Please enter till id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtTillID.Focus()
				Else
					Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.cmbPrinter.Text)) = 0
					If flag4 Then
						MessageBox.Show("Please select/enter printer", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbPrinter.Focus()
					Else
						Dim flag5 As Boolean = Me.cmbPrinterType.SelectedIndex = -1
						If flag5 Then
							MessageBox.Show("Please select invoice template type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.cmbPrinterType.Focus()
						Else
							Dim checked As Boolean = Me.chkActivePT.Checked
							Dim text2 As String
							If checked Then
								text2 = "Yes"
							Else
								text2 = "No"
							End If
							Try
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "select tillID from PosPrinterSetting where TillID=@d1"
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtTillID.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
								If flag6 Then
									MessageBox.Show("Record already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag7 Then
										ModCommonClasses.rdr.Close()
									End If
								Else
									Dim checked2 As Boolean = Me.CheckBox1.Checked
									If checked2 Then
										Me.st4 = "Yes"
									Else
										Me.st4 = "No"
									End If
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text4 As String = "insert into PosPrinterSetting(TillID,PrinterName,PrinterType,CashDrawer,WSPort,ActiveWS,CDPort,CustomerDisplay,SecDisplay,QRDisplayPort,ActiveQR,BundRate,UPIID,BrandName,PT) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
									ModCommonClasses.cmd = New SqlCommand(text4)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtTillID.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbPrinter.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbPrinterType.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.st4)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.ComboBox1.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.ComboBox2.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.ComboBox3.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.ComboBox4.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.cmbSecDisplay.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.ComboBox6.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.ComboBox7.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.baudrateTxt.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.txtUPIid.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.txtBrandName.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d15", text2)
									ModCommonClasses.cmd.ExecuteReader()
									ModCommonClasses.con.Close()
									MessageBox.Show("Successfully Saved", "Terminal Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.btnSave.Enabled = False
									Me.Getdata()
									Me.Reset()
								End If
							Catch ex As Exception
								MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06010C66 RID: 68710 RVA: 0x009CADD4 File Offset: 0x009C8FD4
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtTillID.Text)) = 0
			If flag Then
				MessageBox.Show("Please enter till id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtTillID.Focus()
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.cmbPrinter.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please select/enter printer", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbPrinter.Focus()
				Else
					Dim flag3 As Boolean = Me.cmbPrinterType.SelectedIndex = -1
					If flag3 Then
						MessageBox.Show("Please select invoice template type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbPrinterType.Focus()
					Else
						Dim checked As Boolean = Me.CheckBox1.Checked
						If checked Then
							Me.st4 = "Yes"
						Else
							Me.st4 = "No"
						End If
						Dim checked2 As Boolean = Me.chkActivePT.Checked
						Dim text As String
						If checked2 Then
							text = "Yes"
						Else
							text = "No"
						End If
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = If(("Update PosPrinterSetting set TillID=@d1,PrinterName=@d2,PrinterType=@d3,CashDrawer=@d4,WSPort=@d5,ActiveWS=@d6,CDPort=@d7,CustomerDisplay=@d8,SecDisplay=@d9,QRDisplayPort=@d10,ActiveQR=@d11,BundRate=@d12,UPIID=@d13,BrandName=@d14 ,PT=@d15 where ID=" + Conversions.ToString(Conversion.Val(Me.txtID.Text))), "")
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtTillID.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbPrinter.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbPrinterType.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.st4)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.ComboBox1.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.ComboBox2.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.ComboBox3.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.ComboBox4.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.cmbSecDisplay.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.ComboBox6.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.ComboBox7.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.baudrateTxt.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.txtUPIid.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.txtBrandName.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d15", text)
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							MessageBox.Show("Successfully Updated", "Terminal Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.btnUpdate.Enabled = False
							Me.Getdata()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x06010C67 RID: 68711 RVA: 0x009CB1A0 File Offset: 0x009C93A0
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

		' Token: 0x06010C68 RID: 68712 RVA: 0x00073C1E File Offset: 0x00071E1E
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTempleteEdit.ShowDialog()
		End Sub

		' Token: 0x06010C69 RID: 68713 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbSecDisplay_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06010C6A RID: 68714 RVA: 0x00073C31 File Offset: 0x00071E31
		Private Sub frmTerminalSetting_Closing(sender As Object, e As CancelEventArgs)
			MyProject.Forms.frmEstimate.ReadWeightPORT()
			MyProject.Forms.frmPOS.ReadWeightPORT()
		End Sub

		' Token: 0x06010C6B RID: 68715 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmTerminalSetting_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0400652E RID: 25902
		Private st2 As String

		' Token: 0x0400652F RID: 25903
		Private st1 As String

		' Token: 0x04006530 RID: 25904
		Private st3 As String

		' Token: 0x04006531 RID: 25905
		Private st4 As String
	End Class
End Namespace
