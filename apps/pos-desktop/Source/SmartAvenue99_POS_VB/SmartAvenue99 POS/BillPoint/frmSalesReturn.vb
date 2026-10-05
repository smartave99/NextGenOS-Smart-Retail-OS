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
	' Token: 0x0200058D RID: 1421
	<DesignerGenerated()>
	Public Partial Class frmSalesReturn
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011421 RID: 70689 RVA: 0x00A031D0 File Offset: 0x00A013D0
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSalesReturn_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalesReturn_KeyDown
			Me.a = 0D
			Me.strstatus = ""
			Me.intLimitQty_return = 0
			Me.ntid = ""
			Me.Dst = New DataSet()
			Me.voice = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("SAPI.spvoice", ""))
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006B02 RID: 27394
		' (get) Token: 0x06011424 RID: 70692 RVA: 0x00076ABF File Offset: 0x00074CBF
		' (set) Token: 0x06011425 RID: 70693 RVA: 0x00076AC9 File Offset: 0x00074CC9
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006B03 RID: 27395
		' (get) Token: 0x06011426 RID: 70694 RVA: 0x00076AD2 File Offset: 0x00074CD2
		' (set) Token: 0x06011427 RID: 70695 RVA: 0x00076ADC File Offset: 0x00074CDC
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006B04 RID: 27396
		' (get) Token: 0x06011428 RID: 70696 RVA: 0x00076AE5 File Offset: 0x00074CE5
		' (set) Token: 0x06011429 RID: 70697 RVA: 0x00076AEF File Offset: 0x00074CEF
		Friend Overridable Property Label1 As Label

		' Token: 0x17006B05 RID: 27397
		' (get) Token: 0x0601142A RID: 70698 RVA: 0x00076AF8 File Offset: 0x00074CF8
		' (set) Token: 0x0601142B RID: 70699 RVA: 0x00076B02 File Offset: 0x00074D02
		Friend Overridable Property txtSalesID As TextBox

		' Token: 0x17006B06 RID: 27398
		' (get) Token: 0x0601142C RID: 70700 RVA: 0x00076B0B File Offset: 0x00074D0B
		' (set) Token: 0x0601142D RID: 70701 RVA: 0x00076B15 File Offset: 0x00074D15
		Friend Overridable Property lblUser As Label

		' Token: 0x17006B07 RID: 27399
		' (get) Token: 0x0601142E RID: 70702 RVA: 0x00076B1E File Offset: 0x00074D1E
		' (set) Token: 0x0601142F RID: 70703 RVA: 0x00076B28 File Offset: 0x00074D28
		Friend Overridable Property lblSet As Label

		' Token: 0x17006B08 RID: 27400
		' (get) Token: 0x06011430 RID: 70704 RVA: 0x00076B31 File Offset: 0x00074D31
		' (set) Token: 0x06011431 RID: 70705 RVA: 0x00076B3B File Offset: 0x00074D3B
		Friend Overridable Property lblUserType As Label

		' Token: 0x17006B09 RID: 27401
		' (get) Token: 0x06011432 RID: 70706 RVA: 0x00076B44 File Offset: 0x00074D44
		' (set) Token: 0x06011433 RID: 70707 RVA: 0x00A0B834 File Offset: 0x00A09A34
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

		' Token: 0x17006B0A RID: 27402
		' (get) Token: 0x06011434 RID: 70708 RVA: 0x00076B4E File Offset: 0x00074D4E
		' (set) Token: 0x06011435 RID: 70709 RVA: 0x00076B58 File Offset: 0x00074D58
		Friend Overridable Property txtProductID As TextBox

		' Token: 0x17006B0B RID: 27403
		' (get) Token: 0x06011436 RID: 70710 RVA: 0x00076B61 File Offset: 0x00074D61
		' (set) Token: 0x06011437 RID: 70711 RVA: 0x00076B6B File Offset: 0x00074D6B
		Friend Overridable Property GroupBox5 As GroupBox

		' Token: 0x17006B0C RID: 27404
		' (get) Token: 0x06011438 RID: 70712 RVA: 0x00076B74 File Offset: 0x00074D74
		' (set) Token: 0x06011439 RID: 70713 RVA: 0x00A0B878 File Offset: 0x00A09A78
		Private _dtpSRDate As DateTimePicker
		Friend Overridable Property dtpSRDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpSRDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim eventHandler As EventHandler = AddressOf Me.dtpSRDate_LostFocus
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpSRDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpSRDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.LostFocus, eventHandler
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpSRDate = value
				dateTimePicker = Me._dtpSRDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.LostFocus, eventHandler
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006B0D RID: 27405
		' (get) Token: 0x0601143A RID: 70714 RVA: 0x00076B7E File Offset: 0x00074D7E
		' (set) Token: 0x0601143B RID: 70715 RVA: 0x00076B88 File Offset: 0x00074D88
		Friend Overridable Property txtSRNO As TextBox

		' Token: 0x17006B0E RID: 27406
		' (get) Token: 0x0601143C RID: 70716 RVA: 0x00076B91 File Offset: 0x00074D91
		' (set) Token: 0x0601143D RID: 70717 RVA: 0x00076B9B File Offset: 0x00074D9B
		Friend Overridable Property Label47 As Label

		' Token: 0x17006B0F RID: 27407
		' (get) Token: 0x0601143E RID: 70718 RVA: 0x00076BA4 File Offset: 0x00074DA4
		' (set) Token: 0x0601143F RID: 70719 RVA: 0x00076BAE File Offset: 0x00074DAE
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17006B10 RID: 27408
		' (get) Token: 0x06011440 RID: 70720 RVA: 0x00076BB7 File Offset: 0x00074DB7
		' (set) Token: 0x06011441 RID: 70721 RVA: 0x00A0B8D8 File Offset: 0x00A09AD8
		Private _btnSelection As Button
		Friend Overridable Property btnSelection As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSelection
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSelection_Click
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

		' Token: 0x17006B11 RID: 27409
		' (get) Token: 0x06011442 RID: 70722 RVA: 0x00076BC1 File Offset: 0x00074DC1
		' (set) Token: 0x06011443 RID: 70723 RVA: 0x00076BCB File Offset: 0x00074DCB
		Friend Overridable Property Label10 As Label

		' Token: 0x17006B12 RID: 27410
		' (get) Token: 0x06011444 RID: 70724 RVA: 0x00076BD4 File Offset: 0x00074DD4
		' (set) Token: 0x06011445 RID: 70725 RVA: 0x00076BDE File Offset: 0x00074DDE
		Friend Overridable Property txtCustomerID As TextBox

		' Token: 0x17006B13 RID: 27411
		' (get) Token: 0x06011446 RID: 70726 RVA: 0x00076BE7 File Offset: 0x00074DE7
		' (set) Token: 0x06011447 RID: 70727 RVA: 0x00076BF1 File Offset: 0x00074DF1
		Friend Overridable Property txtCustomerName As TextBox

		' Token: 0x17006B14 RID: 27412
		' (get) Token: 0x06011448 RID: 70728 RVA: 0x00076BFA File Offset: 0x00074DFA
		' (set) Token: 0x06011449 RID: 70729 RVA: 0x00076C04 File Offset: 0x00074E04
		Friend Overridable Property txtSalesInvoiceNo As TextBox

		' Token: 0x17006B15 RID: 27413
		' (get) Token: 0x0601144A RID: 70730 RVA: 0x00076C0D File Offset: 0x00074E0D
		' (set) Token: 0x0601144B RID: 70731 RVA: 0x00076C17 File Offset: 0x00074E17
		Friend Overridable Property Label2 As Label

		' Token: 0x17006B16 RID: 27414
		' (get) Token: 0x0601144C RID: 70732 RVA: 0x00076C20 File Offset: 0x00074E20
		' (set) Token: 0x0601144D RID: 70733 RVA: 0x00076C2A File Offset: 0x00074E2A
		Friend Overridable Property Label36 As Label

		' Token: 0x17006B17 RID: 27415
		' (get) Token: 0x0601144E RID: 70734 RVA: 0x00076C33 File Offset: 0x00074E33
		' (set) Token: 0x0601144F RID: 70735 RVA: 0x00A0B91C File Offset: 0x00A09B1C
		Private _btnRemove As Button
		Public Overridable Property btnRemove As Button
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

		' Token: 0x17006B18 RID: 27416
		' (get) Token: 0x06011450 RID: 70736 RVA: 0x00076C3D File Offset: 0x00074E3D
		' (set) Token: 0x06011451 RID: 70737 RVA: 0x00A0B960 File Offset: 0x00A09B60
		Private _btnAdd As Button
		Public Overridable Property btnAdd As Button
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

		' Token: 0x17006B19 RID: 27417
		' (get) Token: 0x06011452 RID: 70738 RVA: 0x00076C47 File Offset: 0x00074E47
		' (set) Token: 0x06011453 RID: 70739 RVA: 0x00076C51 File Offset: 0x00074E51
		Friend Overridable Property txtTotalAmount As TextBox

		' Token: 0x17006B1A RID: 27418
		' (get) Token: 0x06011454 RID: 70740 RVA: 0x00076C5A File Offset: 0x00074E5A
		' (set) Token: 0x06011455 RID: 70741 RVA: 0x00076C64 File Offset: 0x00074E64
		Friend Overridable Property dtpSalesDate As DateTimePicker

		' Token: 0x17006B1B RID: 27419
		' (get) Token: 0x06011456 RID: 70742 RVA: 0x00076C6D File Offset: 0x00074E6D
		' (set) Token: 0x06011457 RID: 70743 RVA: 0x00076C77 File Offset: 0x00074E77
		Friend Overridable Property Label11 As Label

		' Token: 0x17006B1C RID: 27420
		' (get) Token: 0x06011458 RID: 70744 RVA: 0x00076C80 File Offset: 0x00074E80
		' (set) Token: 0x06011459 RID: 70745 RVA: 0x00A0B9A4 File Offset: 0x00A09BA4
		Private _txtReturnQty As TextBox
		Friend Overridable Property txtReturnQty As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtReturnQty
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtRetuenQty_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtReturnQty_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtReturnQty_KeyDown
				Dim textBox As TextBox = Me._txtReturnQty
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtReturnQty = value
				textBox = Me._txtReturnQty
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006B1D RID: 27421
		' (get) Token: 0x0601145A RID: 70746 RVA: 0x00076C8A File Offset: 0x00074E8A
		' (set) Token: 0x0601145B RID: 70747 RVA: 0x00076C94 File Offset: 0x00074E94
		Friend Overridable Property txtSRID As TextBox

		' Token: 0x17006B1E RID: 27422
		' (get) Token: 0x0601145C RID: 70748 RVA: 0x00076C9D File Offset: 0x00074E9D
		' (set) Token: 0x0601145D RID: 70749 RVA: 0x00076CA7 File Offset: 0x00074EA7
		Friend Overridable Property txtcust_ID As TextBox

		' Token: 0x17006B1F RID: 27423
		' (get) Token: 0x0601145E RID: 70750 RVA: 0x00076CB0 File Offset: 0x00074EB0
		' (set) Token: 0x0601145F RID: 70751 RVA: 0x00076CBA File Offset: 0x00074EBA
		Friend Overridable Property txtMargin As TextBox

		' Token: 0x17006B20 RID: 27424
		' (get) Token: 0x06011460 RID: 70752 RVA: 0x00076CC3 File Offset: 0x00074EC3
		' (set) Token: 0x06011461 RID: 70753 RVA: 0x00076CCD File Offset: 0x00074ECD
		Friend Overridable Property txtPurchaseRate As TextBox

		' Token: 0x17006B21 RID: 27425
		' (get) Token: 0x06011462 RID: 70754 RVA: 0x00076CD6 File Offset: 0x00074ED6
		' (set) Token: 0x06011463 RID: 70755 RVA: 0x00A0BA20 File Offset: 0x00A09C20
		Private _DataGridView2 As DataGridView
		Friend Overridable Property DataGridView2 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView2_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.DataGridView2_RowPostPaint
				Dim dataGridView As DataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._DataGridView2 = value
				dataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006B22 RID: 27426
		' (get) Token: 0x06011464 RID: 70756 RVA: 0x00076CE0 File Offset: 0x00074EE0
		' (set) Token: 0x06011465 RID: 70757 RVA: 0x00A0BA80 File Offset: 0x00A09C80
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

		' Token: 0x17006B23 RID: 27427
		' (get) Token: 0x06011466 RID: 70758 RVA: 0x00076CEA File Offset: 0x00074EEA
		' (set) Token: 0x06011467 RID: 70759 RVA: 0x00076CF4 File Offset: 0x00074EF4
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17006B24 RID: 27428
		' (get) Token: 0x06011468 RID: 70760 RVA: 0x00076CFD File Offset: 0x00074EFD
		' (set) Token: 0x06011469 RID: 70761 RVA: 0x00076D07 File Offset: 0x00074F07
		Friend Overridable Property txtCESSAmt As TextBox

		' Token: 0x17006B25 RID: 27429
		' (get) Token: 0x0601146A RID: 70762 RVA: 0x00076D10 File Offset: 0x00074F10
		' (set) Token: 0x0601146B RID: 70763 RVA: 0x00076D1A File Offset: 0x00074F1A
		Friend Overridable Property txtIGSTAmt As TextBox

		' Token: 0x17006B26 RID: 27430
		' (get) Token: 0x0601146C RID: 70764 RVA: 0x00076D23 File Offset: 0x00074F23
		' (set) Token: 0x0601146D RID: 70765 RVA: 0x00076D2D File Offset: 0x00074F2D
		Friend Overridable Property Label4 As Label

		' Token: 0x17006B27 RID: 27431
		' (get) Token: 0x0601146E RID: 70766 RVA: 0x00076D36 File Offset: 0x00074F36
		' (set) Token: 0x0601146F RID: 70767 RVA: 0x00076D40 File Offset: 0x00074F40
		Friend Overridable Property Label41 As Label

		' Token: 0x17006B28 RID: 27432
		' (get) Token: 0x06011470 RID: 70768 RVA: 0x00076D49 File Offset: 0x00074F49
		' (set) Token: 0x06011471 RID: 70769 RVA: 0x00076D53 File Offset: 0x00074F53
		Friend Overridable Property Label5 As Label

		' Token: 0x17006B29 RID: 27433
		' (get) Token: 0x06011472 RID: 70770 RVA: 0x00076D5C File Offset: 0x00074F5C
		' (set) Token: 0x06011473 RID: 70771 RVA: 0x00076D66 File Offset: 0x00074F66
		Friend Overridable Property txtIGSTPer As TextBox

		' Token: 0x17006B2A RID: 27434
		' (get) Token: 0x06011474 RID: 70772 RVA: 0x00076D6F File Offset: 0x00074F6F
		' (set) Token: 0x06011475 RID: 70773 RVA: 0x00076D79 File Offset: 0x00074F79
		Friend Overridable Property Label42 As Label

		' Token: 0x17006B2B RID: 27435
		' (get) Token: 0x06011476 RID: 70774 RVA: 0x00076D82 File Offset: 0x00074F82
		' (set) Token: 0x06011477 RID: 70775 RVA: 0x00076D8C File Offset: 0x00074F8C
		Friend Overridable Property txtDisc As TextBox

		' Token: 0x17006B2C RID: 27436
		' (get) Token: 0x06011478 RID: 70776 RVA: 0x00076D95 File Offset: 0x00074F95
		' (set) Token: 0x06011479 RID: 70777 RVA: 0x00076D9F File Offset: 0x00074F9F
		Friend Overridable Property Label28 As Label

		' Token: 0x17006B2D RID: 27437
		' (get) Token: 0x0601147A RID: 70778 RVA: 0x00076DA8 File Offset: 0x00074FA8
		' (set) Token: 0x0601147B RID: 70779 RVA: 0x00076DB2 File Offset: 0x00074FB2
		Friend Overridable Property txtCESSPer As TextBox

		' Token: 0x17006B2E RID: 27438
		' (get) Token: 0x0601147C RID: 70780 RVA: 0x00076DBB File Offset: 0x00074FBB
		' (set) Token: 0x0601147D RID: 70781 RVA: 0x00076DC5 File Offset: 0x00074FC5
		Friend Overridable Property txtSGSTAmt As TextBox

		' Token: 0x17006B2F RID: 27439
		' (get) Token: 0x0601147E RID: 70782 RVA: 0x00076DCE File Offset: 0x00074FCE
		' (set) Token: 0x0601147F RID: 70783 RVA: 0x00076DD8 File Offset: 0x00074FD8
		Friend Overridable Property Label45 As Label

		' Token: 0x17006B30 RID: 27440
		' (get) Token: 0x06011480 RID: 70784 RVA: 0x00076DE1 File Offset: 0x00074FE1
		' (set) Token: 0x06011481 RID: 70785 RVA: 0x00076DEB File Offset: 0x00074FEB
		Friend Overridable Property Label46 As Label

		' Token: 0x17006B31 RID: 27441
		' (get) Token: 0x06011482 RID: 70786 RVA: 0x00076DF4 File Offset: 0x00074FF4
		' (set) Token: 0x06011483 RID: 70787 RVA: 0x00076DFE File Offset: 0x00074FFE
		Friend Overridable Property txtDiscPer As TextBox

		' Token: 0x17006B32 RID: 27442
		' (get) Token: 0x06011484 RID: 70788 RVA: 0x00076E07 File Offset: 0x00075007
		' (set) Token: 0x06011485 RID: 70789 RVA: 0x00076E11 File Offset: 0x00075011
		Friend Overridable Property lblUnit As Label

		' Token: 0x17006B33 RID: 27443
		' (get) Token: 0x06011486 RID: 70790 RVA: 0x00076E1A File Offset: 0x0007501A
		' (set) Token: 0x06011487 RID: 70791 RVA: 0x00076E24 File Offset: 0x00075024
		Friend Overridable Property Label21 As Label

		' Token: 0x17006B34 RID: 27444
		' (get) Token: 0x06011488 RID: 70792 RVA: 0x00076E2D File Offset: 0x0007502D
		' (set) Token: 0x06011489 RID: 70793 RVA: 0x00076E37 File Offset: 0x00075037
		Friend Overridable Property txtBarcode As TextBox

		' Token: 0x17006B35 RID: 27445
		' (get) Token: 0x0601148A RID: 70794 RVA: 0x00076E40 File Offset: 0x00075040
		' (set) Token: 0x0601148B RID: 70795 RVA: 0x00076E4A File Offset: 0x0007504A
		Friend Overridable Property Label33 As Label

		' Token: 0x17006B36 RID: 27446
		' (get) Token: 0x0601148C RID: 70796 RVA: 0x00076E53 File Offset: 0x00075053
		' (set) Token: 0x0601148D RID: 70797 RVA: 0x00076E5D File Offset: 0x0007505D
		Friend Overridable Property txtCGSTAmt As TextBox

		' Token: 0x17006B37 RID: 27447
		' (get) Token: 0x0601148E RID: 70798 RVA: 0x00076E66 File Offset: 0x00075066
		' (set) Token: 0x0601148F RID: 70799 RVA: 0x00076E70 File Offset: 0x00075070
		Friend Overridable Property txtSalesRate As TextBox

		' Token: 0x17006B38 RID: 27448
		' (get) Token: 0x06011490 RID: 70800 RVA: 0x00076E79 File Offset: 0x00075079
		' (set) Token: 0x06011491 RID: 70801 RVA: 0x00076E83 File Offset: 0x00075083
		Friend Overridable Property txtSGSTPer As TextBox

		' Token: 0x17006B39 RID: 27449
		' (get) Token: 0x06011492 RID: 70802 RVA: 0x00076E8C File Offset: 0x0007508C
		' (set) Token: 0x06011493 RID: 70803 RVA: 0x00076E96 File Offset: 0x00075096
		Friend Overridable Property txtQty As TextBox

		' Token: 0x17006B3A RID: 27450
		' (get) Token: 0x06011494 RID: 70804 RVA: 0x00076E9F File Offset: 0x0007509F
		' (set) Token: 0x06011495 RID: 70805 RVA: 0x00076EA9 File Offset: 0x000750A9
		Friend Overridable Property txtCGSTPer As TextBox

		' Token: 0x17006B3B RID: 27451
		' (get) Token: 0x06011496 RID: 70806 RVA: 0x00076EB2 File Offset: 0x000750B2
		' (set) Token: 0x06011497 RID: 70807 RVA: 0x00076EBC File Offset: 0x000750BC
		Friend Overridable Property Label25 As Label

		' Token: 0x17006B3C RID: 27452
		' (get) Token: 0x06011498 RID: 70808 RVA: 0x00076EC5 File Offset: 0x000750C5
		' (set) Token: 0x06011499 RID: 70809 RVA: 0x00076ECF File Offset: 0x000750CF
		Friend Overridable Property Label17 As Label

		' Token: 0x17006B3D RID: 27453
		' (get) Token: 0x0601149A RID: 70810 RVA: 0x00076ED8 File Offset: 0x000750D8
		' (set) Token: 0x0601149B RID: 70811 RVA: 0x00076EE2 File Offset: 0x000750E2
		Friend Overridable Property Label22 As Label

		' Token: 0x17006B3E RID: 27454
		' (get) Token: 0x0601149C RID: 70812 RVA: 0x00076EEB File Offset: 0x000750EB
		' (set) Token: 0x0601149D RID: 70813 RVA: 0x00076EF5 File Offset: 0x000750F5
		Friend Overridable Property Label18 As Label

		' Token: 0x17006B3F RID: 27455
		' (get) Token: 0x0601149E RID: 70814 RVA: 0x00076EFE File Offset: 0x000750FE
		' (set) Token: 0x0601149F RID: 70815 RVA: 0x00076F08 File Offset: 0x00075108
		Friend Overridable Property txtProductName As TextBox

		' Token: 0x17006B40 RID: 27456
		' (get) Token: 0x060114A0 RID: 70816 RVA: 0x00076F11 File Offset: 0x00075111
		' (set) Token: 0x060114A1 RID: 70817 RVA: 0x00076F1B File Offset: 0x0007511B
		Friend Overridable Property txtHSNCode As TextBox

		' Token: 0x17006B41 RID: 27457
		' (get) Token: 0x060114A2 RID: 70818 RVA: 0x00076F24 File Offset: 0x00075124
		' (set) Token: 0x060114A3 RID: 70819 RVA: 0x00076F2E File Offset: 0x0007512E
		Friend Overridable Property Label20 As Label

		' Token: 0x17006B42 RID: 27458
		' (get) Token: 0x060114A4 RID: 70820 RVA: 0x00076F37 File Offset: 0x00075137
		' (set) Token: 0x060114A5 RID: 70821 RVA: 0x00076F41 File Offset: 0x00075141
		Friend Overridable Property Label23 As Label

		' Token: 0x17006B43 RID: 27459
		' (get) Token: 0x060114A6 RID: 70822 RVA: 0x00076F4A File Offset: 0x0007514A
		' (set) Token: 0x060114A7 RID: 70823 RVA: 0x00076F54 File Offset: 0x00075154
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17006B44 RID: 27460
		' (get) Token: 0x060114A8 RID: 70824 RVA: 0x00076F5D File Offset: 0x0007515D
		' (set) Token: 0x060114A9 RID: 70825 RVA: 0x00076F67 File Offset: 0x00075167
		Friend Overridable Property Label43 As Label

		' Token: 0x17006B45 RID: 27461
		' (get) Token: 0x060114AA RID: 70826 RVA: 0x00076F70 File Offset: 0x00075170
		' (set) Token: 0x060114AB RID: 70827 RVA: 0x00076F7A File Offset: 0x0007517A
		Friend Overridable Property txtCESS As TextBox

		' Token: 0x17006B46 RID: 27462
		' (get) Token: 0x060114AC RID: 70828 RVA: 0x00076F83 File Offset: 0x00075183
		' (set) Token: 0x060114AD RID: 70829 RVA: 0x00076F8D File Offset: 0x0007518D
		Friend Overridable Property txtIGST As TextBox

		' Token: 0x17006B47 RID: 27463
		' (get) Token: 0x060114AE RID: 70830 RVA: 0x00076F96 File Offset: 0x00075196
		' (set) Token: 0x060114AF RID: 70831 RVA: 0x00076FA0 File Offset: 0x000751A0
		Friend Overridable Property Label24 As Label

		' Token: 0x17006B48 RID: 27464
		' (get) Token: 0x060114B0 RID: 70832 RVA: 0x00076FA9 File Offset: 0x000751A9
		' (set) Token: 0x060114B1 RID: 70833 RVA: 0x00076FB3 File Offset: 0x000751B3
		Friend Overridable Property txtSGST As TextBox

		' Token: 0x17006B49 RID: 27465
		' (get) Token: 0x060114B2 RID: 70834 RVA: 0x00076FBC File Offset: 0x000751BC
		' (set) Token: 0x060114B3 RID: 70835 RVA: 0x00076FC6 File Offset: 0x000751C6
		Friend Overridable Property Label26 As Label

		' Token: 0x17006B4A RID: 27466
		' (get) Token: 0x060114B4 RID: 70836 RVA: 0x00076FCF File Offset: 0x000751CF
		' (set) Token: 0x060114B5 RID: 70837 RVA: 0x00076FD9 File Offset: 0x000751D9
		Friend Overridable Property txtCGST As TextBox

		' Token: 0x17006B4B RID: 27467
		' (get) Token: 0x060114B6 RID: 70838 RVA: 0x00076FE2 File Offset: 0x000751E2
		' (set) Token: 0x060114B7 RID: 70839 RVA: 0x00076FEC File Offset: 0x000751EC
		Friend Overridable Property Label27 As Label

		' Token: 0x17006B4C RID: 27468
		' (get) Token: 0x060114B8 RID: 70840 RVA: 0x00076FF5 File Offset: 0x000751F5
		' (set) Token: 0x060114B9 RID: 70841 RVA: 0x00A0BAE0 File Offset: 0x00A09CE0
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

		' Token: 0x17006B4D RID: 27469
		' (get) Token: 0x060114BA RID: 70842 RVA: 0x00076FFF File Offset: 0x000751FF
		' (set) Token: 0x060114BB RID: 70843 RVA: 0x00077009 File Offset: 0x00075209
		Friend Overridable Property Label29 As Label

		' Token: 0x17006B4E RID: 27470
		' (get) Token: 0x060114BC RID: 70844 RVA: 0x00077012 File Offset: 0x00075212
		' (set) Token: 0x060114BD RID: 70845 RVA: 0x0007701C File Offset: 0x0007521C
		Friend Overridable Property txtGrandTotal As TextBox

		' Token: 0x17006B4F RID: 27471
		' (get) Token: 0x060114BE RID: 70846 RVA: 0x00077025 File Offset: 0x00075225
		' (set) Token: 0x060114BF RID: 70847 RVA: 0x0007702F File Offset: 0x0007522F
		Friend Overridable Property Label31 As Label

		' Token: 0x17006B50 RID: 27472
		' (get) Token: 0x060114C0 RID: 70848 RVA: 0x00077038 File Offset: 0x00075238
		' (set) Token: 0x060114C1 RID: 70849 RVA: 0x00077042 File Offset: 0x00075242
		Friend Overridable Property txtTaxType As TextBox

		' Token: 0x17006B51 RID: 27473
		' (get) Token: 0x060114C2 RID: 70850 RVA: 0x0007704B File Offset: 0x0007524B
		' (set) Token: 0x060114C3 RID: 70851 RVA: 0x00077055 File Offset: 0x00075255
		Friend Overridable Property Label6 As Label

		' Token: 0x17006B52 RID: 27474
		' (get) Token: 0x060114C4 RID: 70852 RVA: 0x0007705E File Offset: 0x0007525E
		' (set) Token: 0x060114C5 RID: 70853 RVA: 0x00A0BB24 File Offset: 0x00A09D24
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

		' Token: 0x17006B53 RID: 27475
		' (get) Token: 0x060114C6 RID: 70854 RVA: 0x00077068 File Offset: 0x00075268
		' (set) Token: 0x060114C7 RID: 70855 RVA: 0x00077072 File Offset: 0x00075272
		Friend Overridable Property Label7 As Label

		' Token: 0x17006B54 RID: 27476
		' (get) Token: 0x060114C8 RID: 70856 RVA: 0x0007707B File Offset: 0x0007527B
		' (set) Token: 0x060114C9 RID: 70857 RVA: 0x00077085 File Offset: 0x00075285
		Friend Overridable Property txtTotal As TextBox

		' Token: 0x17006B55 RID: 27477
		' (get) Token: 0x060114CA RID: 70858 RVA: 0x0007708E File Offset: 0x0007528E
		' (set) Token: 0x060114CB RID: 70859 RVA: 0x00077098 File Offset: 0x00075298
		Friend Overridable Property Label37 As Label

		' Token: 0x17006B56 RID: 27478
		' (get) Token: 0x060114CC RID: 70860 RVA: 0x000770A1 File Offset: 0x000752A1
		' (set) Token: 0x060114CD RID: 70861 RVA: 0x000770AB File Offset: 0x000752AB
		Friend Overridable Property txtRoundOff As TextBox

		' Token: 0x17006B57 RID: 27479
		' (get) Token: 0x060114CE RID: 70862 RVA: 0x000770B4 File Offset: 0x000752B4
		' (set) Token: 0x060114CF RID: 70863 RVA: 0x000770BE File Offset: 0x000752BE
		Friend Overridable Property Label30 As Label

		' Token: 0x17006B58 RID: 27480
		' (get) Token: 0x060114D0 RID: 70864 RVA: 0x000770C7 File Offset: 0x000752C7
		' (set) Token: 0x060114D1 RID: 70865 RVA: 0x00A0BB68 File Offset: 0x00A09D68
		Private _txtBillDiscount As TextBox
		Friend Overridable Property txtBillDiscount As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBillDiscount
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtOtherCharges_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtOtherCharges_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBillDiscount_KeyDown
				Dim textBox As TextBox = Me._txtBillDiscount
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtBillDiscount = value
				textBox = Me._txtBillDiscount
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006B59 RID: 27481
		' (get) Token: 0x060114D2 RID: 70866 RVA: 0x000770D1 File Offset: 0x000752D1
		' (set) Token: 0x060114D3 RID: 70867 RVA: 0x00A0BBE4 File Offset: 0x00A09DE4
		Private _txtFreightCharges As TextBox
		Friend Overridable Property txtFreightCharges As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtFreightCharges
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtFreightCharges_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtFreightCharges_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtFreightCharges_KeyDown
				Dim textBox As TextBox = Me._txtFreightCharges
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtFreightCharges = value
				textBox = Me._txtFreightCharges
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006B5A RID: 27482
		' (get) Token: 0x060114D4 RID: 70868 RVA: 0x000770DB File Offset: 0x000752DB
		' (set) Token: 0x060114D5 RID: 70869 RVA: 0x00A0BC60 File Offset: 0x00A09E60
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

		' Token: 0x17006B5B RID: 27483
		' (get) Token: 0x060114D6 RID: 70870 RVA: 0x000770E5 File Offset: 0x000752E5
		' (set) Token: 0x060114D7 RID: 70871 RVA: 0x000770EF File Offset: 0x000752EF
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17006B5C RID: 27484
		' (get) Token: 0x060114D8 RID: 70872 RVA: 0x000770F8 File Offset: 0x000752F8
		' (set) Token: 0x060114D9 RID: 70873 RVA: 0x00A0BCA4 File Offset: 0x00A09EA4
		Private _cmbPmtMode As ComboBox
		Friend Overridable Property cmbPmtMode As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbPmtMode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbPmtMode_KeyDown
				Dim comboBox As ComboBox = Me._cmbPmtMode
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbPmtMode = value
				comboBox = Me._cmbPmtMode
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006B5D RID: 27485
		' (get) Token: 0x060114DA RID: 70874 RVA: 0x00077102 File Offset: 0x00075302
		' (set) Token: 0x060114DB RID: 70875 RVA: 0x0007710C File Offset: 0x0007530C
		Friend Overridable Property Label8 As Label

		' Token: 0x17006B5E RID: 27486
		' (get) Token: 0x060114DC RID: 70876 RVA: 0x00077115 File Offset: 0x00075315
		' (set) Token: 0x060114DD RID: 70877 RVA: 0x0007711F File Offset: 0x0007531F
		Friend Overridable Property Label54 As Label

		' Token: 0x17006B5F RID: 27487
		' (get) Token: 0x060114DE RID: 70878 RVA: 0x00077128 File Offset: 0x00075328
		' (set) Token: 0x060114DF RID: 70879 RVA: 0x00A0BCE8 File Offset: 0x00A09EE8
		Private _cmbBSundry As ComboBox
		Friend Overridable Property cmbBSundry As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbBSundry
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbBSundry_KeyDown
				Dim comboBox As ComboBox = Me._cmbBSundry
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbBSundry = value
				comboBox = Me._cmbBSundry
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006B60 RID: 27488
		' (get) Token: 0x060114E0 RID: 70880 RVA: 0x00077132 File Offset: 0x00075332
		' (set) Token: 0x060114E1 RID: 70881 RVA: 0x00A0BD2C File Offset: 0x00A09F2C
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

		' Token: 0x17006B61 RID: 27489
		' (get) Token: 0x060114E2 RID: 70882 RVA: 0x0007713C File Offset: 0x0007533C
		' (set) Token: 0x060114E3 RID: 70883 RVA: 0x00077146 File Offset: 0x00075346
		Friend Overridable Property txtInvCode1 As TextBox

		' Token: 0x17006B62 RID: 27490
		' (get) Token: 0x060114E4 RID: 70884 RVA: 0x0007714F File Offset: 0x0007534F
		' (set) Token: 0x060114E5 RID: 70885 RVA: 0x00077159 File Offset: 0x00075359
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x17006B63 RID: 27491
		' (get) Token: 0x060114E6 RID: 70886 RVA: 0x00077162 File Offset: 0x00075362
		' (set) Token: 0x060114E7 RID: 70887 RVA: 0x0007716C File Offset: 0x0007536C
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x17006B64 RID: 27492
		' (get) Token: 0x060114E8 RID: 70888 RVA: 0x00077175 File Offset: 0x00075375
		' (set) Token: 0x060114E9 RID: 70889 RVA: 0x0007717F File Offset: 0x0007537F
		Friend Overridable Property txtSuffix As TextBox

		' Token: 0x17006B65 RID: 27493
		' (get) Token: 0x060114EA RID: 70890 RVA: 0x00077188 File Offset: 0x00075388
		' (set) Token: 0x060114EB RID: 70891 RVA: 0x00A0BD70 File Offset: 0x00A09F70
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

		' Token: 0x17006B66 RID: 27494
		' (get) Token: 0x060114EC RID: 70892 RVA: 0x00077192 File Offset: 0x00075392
		' (set) Token: 0x060114ED RID: 70893 RVA: 0x00A0BDB4 File Offset: 0x00A09FB4
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

		' Token: 0x17006B67 RID: 27495
		' (get) Token: 0x060114EE RID: 70894 RVA: 0x0007719C File Offset: 0x0007539C
		' (set) Token: 0x060114EF RID: 70895 RVA: 0x00A0BDF8 File Offset: 0x00A09FF8
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

		' Token: 0x17006B68 RID: 27496
		' (get) Token: 0x060114F0 RID: 70896 RVA: 0x000771A6 File Offset: 0x000753A6
		' (set) Token: 0x060114F1 RID: 70897 RVA: 0x00A0BE3C File Offset: 0x00A0A03C
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

		' Token: 0x17006B69 RID: 27497
		' (get) Token: 0x060114F2 RID: 70898 RVA: 0x000771B0 File Offset: 0x000753B0
		' (set) Token: 0x060114F3 RID: 70899 RVA: 0x00A0BE80 File Offset: 0x00A0A080
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

		' Token: 0x17006B6A RID: 27498
		' (get) Token: 0x060114F4 RID: 70900 RVA: 0x000771BA File Offset: 0x000753BA
		' (set) Token: 0x060114F5 RID: 70901 RVA: 0x000771C4 File Offset: 0x000753C4
		Friend Overridable Property txtRsToWords As Label

		' Token: 0x17006B6B RID: 27499
		' (get) Token: 0x060114F6 RID: 70902 RVA: 0x000771CD File Offset: 0x000753CD
		' (set) Token: 0x060114F7 RID: 70903 RVA: 0x00A0BEC4 File Offset: 0x00A0A0C4
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

		' Token: 0x17006B6C RID: 27500
		' (get) Token: 0x060114F8 RID: 70904 RVA: 0x000771D7 File Offset: 0x000753D7
		' (set) Token: 0x060114F9 RID: 70905 RVA: 0x00A0BF08 File Offset: 0x00A0A108
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

		' Token: 0x17006B6D RID: 27501
		' (get) Token: 0x060114FA RID: 70906 RVA: 0x000771E1 File Offset: 0x000753E1
		' (set) Token: 0x060114FB RID: 70907 RVA: 0x000771EB File Offset: 0x000753EB
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x17006B6E RID: 27502
		' (get) Token: 0x060114FC RID: 70908 RVA: 0x000771F4 File Offset: 0x000753F4
		' (set) Token: 0x060114FD RID: 70909 RVA: 0x00A0BF4C File Offset: 0x00A0A14C
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

		' Token: 0x17006B6F RID: 27503
		' (get) Token: 0x060114FE RID: 70910 RVA: 0x000771FE File Offset: 0x000753FE
		' (set) Token: 0x060114FF RID: 70911 RVA: 0x00077208 File Offset: 0x00075408
		Friend Overridable Property F2 As TextBox

		' Token: 0x17006B70 RID: 27504
		' (get) Token: 0x06011500 RID: 70912 RVA: 0x00077211 File Offset: 0x00075411
		' (set) Token: 0x06011501 RID: 70913 RVA: 0x0007721B File Offset: 0x0007541B
		Friend Overridable Property F1 As TextBox

		' Token: 0x17006B71 RID: 27505
		' (get) Token: 0x06011502 RID: 70914 RVA: 0x00077224 File Offset: 0x00075424
		' (set) Token: 0x06011503 RID: 70915 RVA: 0x0007722E File Offset: 0x0007542E
		Friend Overridable Property Label9 As Label

		' Token: 0x17006B72 RID: 27506
		' (get) Token: 0x06011504 RID: 70916 RVA: 0x00077237 File Offset: 0x00075437
		' (set) Token: 0x06011505 RID: 70917 RVA: 0x00077241 File Offset: 0x00075441
		Friend Overridable Property txtGSTnonGST As TextBox

		' Token: 0x17006B73 RID: 27507
		' (get) Token: 0x06011506 RID: 70918 RVA: 0x0007724A File Offset: 0x0007544A
		' (set) Token: 0x06011507 RID: 70919 RVA: 0x00077254 File Offset: 0x00075454
		Friend Overridable Property txtTaxableAmt As TextBox

		' Token: 0x17006B74 RID: 27508
		' (get) Token: 0x06011508 RID: 70920 RVA: 0x0007725D File Offset: 0x0007545D
		' (set) Token: 0x06011509 RID: 70921 RVA: 0x00077267 File Offset: 0x00075467
		Friend Overridable Property Label12 As Label

		' Token: 0x17006B75 RID: 27509
		' (get) Token: 0x0601150A RID: 70922 RVA: 0x00077270 File Offset: 0x00075470
		' (set) Token: 0x0601150B RID: 70923 RVA: 0x0007727A File Offset: 0x0007547A
		Friend Overridable Property txtFreeQty As TextBox

		' Token: 0x17006B76 RID: 27510
		' (get) Token: 0x0601150C RID: 70924 RVA: 0x00077283 File Offset: 0x00075483
		' (set) Token: 0x0601150D RID: 70925 RVA: 0x0007728D File Offset: 0x0007548D
		Friend Overridable Property Label14 As Label

		' Token: 0x17006B77 RID: 27511
		' (get) Token: 0x0601150E RID: 70926 RVA: 0x00077296 File Offset: 0x00075496
		' (set) Token: 0x0601150F RID: 70927 RVA: 0x000772A0 File Offset: 0x000754A0
		Friend Overridable Property lblFreeQty As Label

		' Token: 0x17006B78 RID: 27512
		' (get) Token: 0x06011510 RID: 70928 RVA: 0x000772A9 File Offset: 0x000754A9
		' (set) Token: 0x06011511 RID: 70929 RVA: 0x000772B3 File Offset: 0x000754B3
		Friend Overridable Property lblCPhone As Label

		' Token: 0x17006B79 RID: 27513
		' (get) Token: 0x06011512 RID: 70930 RVA: 0x000772BC File Offset: 0x000754BC
		' (set) Token: 0x06011513 RID: 70931 RVA: 0x000772C6 File Offset: 0x000754C6
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17006B7A RID: 27514
		' (get) Token: 0x06011514 RID: 70932 RVA: 0x000772CF File Offset: 0x000754CF
		' (set) Token: 0x06011515 RID: 70933 RVA: 0x00A0BF90 File Offset: 0x00A0A190
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

		' Token: 0x17006B7B RID: 27515
		' (get) Token: 0x06011516 RID: 70934 RVA: 0x000772D9 File Offset: 0x000754D9
		' (set) Token: 0x06011517 RID: 70935 RVA: 0x00A0BFD4 File Offset: 0x00A0A1D4
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

		' Token: 0x17006B7C RID: 27516
		' (get) Token: 0x06011518 RID: 70936 RVA: 0x000772E3 File Offset: 0x000754E3
		' (set) Token: 0x06011519 RID: 70937 RVA: 0x00A0C018 File Offset: 0x00A0A218
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

		' Token: 0x17006B7D RID: 27517
		' (get) Token: 0x0601151A RID: 70938 RVA: 0x000772ED File Offset: 0x000754ED
		' (set) Token: 0x0601151B RID: 70939 RVA: 0x00A0C05C File Offset: 0x00A0A25C
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

		' Token: 0x17006B7E RID: 27518
		' (get) Token: 0x0601151C RID: 70940 RVA: 0x000772F7 File Offset: 0x000754F7
		' (set) Token: 0x0601151D RID: 70941 RVA: 0x00A0C0A0 File Offset: 0x00A0A2A0
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

		' Token: 0x17006B7F RID: 27519
		' (get) Token: 0x0601151E RID: 70942 RVA: 0x00077301 File Offset: 0x00075501
		' (set) Token: 0x0601151F RID: 70943 RVA: 0x0007730B File Offset: 0x0007550B
		Friend Overridable Property txtSalesmanComm As TextBox

		' Token: 0x17006B80 RID: 27520
		' (get) Token: 0x06011520 RID: 70944 RVA: 0x00077314 File Offset: 0x00075514
		' (set) Token: 0x06011521 RID: 70945 RVA: 0x0007731E File Offset: 0x0007551E
		Friend Overridable Property txtSalesManPur As TextBox

		' Token: 0x17006B81 RID: 27521
		' (get) Token: 0x06011522 RID: 70946 RVA: 0x00077327 File Offset: 0x00075527
		' (set) Token: 0x06011523 RID: 70947 RVA: 0x00077331 File Offset: 0x00075531
		Friend Overridable Property txtSalesManId As TextBox

		' Token: 0x17006B82 RID: 27522
		' (get) Token: 0x06011524 RID: 70948 RVA: 0x0007733A File Offset: 0x0007553A
		' (set) Token: 0x06011525 RID: 70949 RVA: 0x00077344 File Offset: 0x00075544
		Friend Overridable Property txtSalesman As TextBox

		' Token: 0x17006B83 RID: 27523
		' (get) Token: 0x06011526 RID: 70950 RVA: 0x0007734D File Offset: 0x0007554D
		' (set) Token: 0x06011527 RID: 70951 RVA: 0x00077357 File Offset: 0x00075557
		Friend Overridable Property lblLoyality As Label

		' Token: 0x17006B84 RID: 27524
		' (get) Token: 0x06011528 RID: 70952 RVA: 0x00077360 File Offset: 0x00075560
		' (set) Token: 0x06011529 RID: 70953 RVA: 0x0007736A File Offset: 0x0007556A
		Friend Overridable Property lblTotalLoyalityPoints As Label

		' Token: 0x17006B85 RID: 27525
		' (get) Token: 0x0601152A RID: 70954 RVA: 0x00077373 File Offset: 0x00075573
		' (set) Token: 0x0601152B RID: 70955 RVA: 0x0007737D File Offset: 0x0007557D
		Friend Overridable Property lblLoyality_cr As Label

		' Token: 0x17006B86 RID: 27526
		' (get) Token: 0x0601152C RID: 70956 RVA: 0x00077386 File Offset: 0x00075586
		' (set) Token: 0x0601152D RID: 70957 RVA: 0x00077390 File Offset: 0x00075590
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x17006B87 RID: 27527
		' (get) Token: 0x0601152E RID: 70958 RVA: 0x00077399 File Offset: 0x00075599
		' (set) Token: 0x0601152F RID: 70959 RVA: 0x000773A3 File Offset: 0x000755A3
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006B88 RID: 27528
		' (get) Token: 0x06011530 RID: 70960 RVA: 0x000773AC File Offset: 0x000755AC
		' (set) Token: 0x06011531 RID: 70961 RVA: 0x000773B6 File Offset: 0x000755B6
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17006B89 RID: 27529
		' (get) Token: 0x06011532 RID: 70962 RVA: 0x000773BF File Offset: 0x000755BF
		' (set) Token: 0x06011533 RID: 70963 RVA: 0x000773C9 File Offset: 0x000755C9
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17006B8A RID: 27530
		' (get) Token: 0x06011534 RID: 70964 RVA: 0x000773D2 File Offset: 0x000755D2
		' (set) Token: 0x06011535 RID: 70965 RVA: 0x000773DC File Offset: 0x000755DC
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17006B8B RID: 27531
		' (get) Token: 0x06011536 RID: 70966 RVA: 0x000773E5 File Offset: 0x000755E5
		' (set) Token: 0x06011537 RID: 70967 RVA: 0x000773EF File Offset: 0x000755EF
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x17006B8C RID: 27532
		' (get) Token: 0x06011538 RID: 70968 RVA: 0x000773F8 File Offset: 0x000755F8
		' (set) Token: 0x06011539 RID: 70969 RVA: 0x00077402 File Offset: 0x00075602
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x17006B8D RID: 27533
		' (get) Token: 0x0601153A RID: 70970 RVA: 0x0007740B File Offset: 0x0007560B
		' (set) Token: 0x0601153B RID: 70971 RVA: 0x00077415 File Offset: 0x00075615
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17006B8E RID: 27534
		' (get) Token: 0x0601153C RID: 70972 RVA: 0x0007741E File Offset: 0x0007561E
		' (set) Token: 0x0601153D RID: 70973 RVA: 0x00077428 File Offset: 0x00075628
		Friend Overridable Property DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn

		' Token: 0x17006B8F RID: 27535
		' (get) Token: 0x0601153E RID: 70974 RVA: 0x00077431 File Offset: 0x00075631
		' (set) Token: 0x0601153F RID: 70975 RVA: 0x0007743B File Offset: 0x0007563B
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x17006B90 RID: 27536
		' (get) Token: 0x06011540 RID: 70976 RVA: 0x00077444 File Offset: 0x00075644
		' (set) Token: 0x06011541 RID: 70977 RVA: 0x0007744E File Offset: 0x0007564E
		Friend Overridable Property DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn

		' Token: 0x17006B91 RID: 27537
		' (get) Token: 0x06011542 RID: 70978 RVA: 0x00077457 File Offset: 0x00075657
		' (set) Token: 0x06011543 RID: 70979 RVA: 0x00077461 File Offset: 0x00075661
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17006B92 RID: 27538
		' (get) Token: 0x06011544 RID: 70980 RVA: 0x0007746A File Offset: 0x0007566A
		' (set) Token: 0x06011545 RID: 70981 RVA: 0x00077474 File Offset: 0x00075674
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17006B93 RID: 27539
		' (get) Token: 0x06011546 RID: 70982 RVA: 0x0007747D File Offset: 0x0007567D
		' (set) Token: 0x06011547 RID: 70983 RVA: 0x00077487 File Offset: 0x00075687
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17006B94 RID: 27540
		' (get) Token: 0x06011548 RID: 70984 RVA: 0x00077490 File Offset: 0x00075690
		' (set) Token: 0x06011549 RID: 70985 RVA: 0x0007749A File Offset: 0x0007569A
		Friend Overridable Property DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn

		' Token: 0x17006B95 RID: 27541
		' (get) Token: 0x0601154A RID: 70986 RVA: 0x000774A3 File Offset: 0x000756A3
		' (set) Token: 0x0601154B RID: 70987 RVA: 0x000774AD File Offset: 0x000756AD
		Friend Overridable Property DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn

		' Token: 0x17006B96 RID: 27542
		' (get) Token: 0x0601154C RID: 70988 RVA: 0x000774B6 File Offset: 0x000756B6
		' (set) Token: 0x0601154D RID: 70989 RVA: 0x000774C0 File Offset: 0x000756C0
		Friend Overridable Property DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn

		' Token: 0x17006B97 RID: 27543
		' (get) Token: 0x0601154E RID: 70990 RVA: 0x000774C9 File Offset: 0x000756C9
		' (set) Token: 0x0601154F RID: 70991 RVA: 0x000774D3 File Offset: 0x000756D3
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17006B98 RID: 27544
		' (get) Token: 0x06011550 RID: 70992 RVA: 0x000774DC File Offset: 0x000756DC
		' (set) Token: 0x06011551 RID: 70993 RVA: 0x000774E6 File Offset: 0x000756E6
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17006B99 RID: 27545
		' (get) Token: 0x06011552 RID: 70994 RVA: 0x000774EF File Offset: 0x000756EF
		' (set) Token: 0x06011553 RID: 70995 RVA: 0x000774F9 File Offset: 0x000756F9
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006B9A RID: 27546
		' (get) Token: 0x06011554 RID: 70996 RVA: 0x00077502 File Offset: 0x00075702
		' (set) Token: 0x06011555 RID: 70997 RVA: 0x0007750C File Offset: 0x0007570C
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006B9B RID: 27547
		' (get) Token: 0x06011556 RID: 70998 RVA: 0x00077515 File Offset: 0x00075715
		' (set) Token: 0x06011557 RID: 70999 RVA: 0x0007751F File Offset: 0x0007571F
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17006B9C RID: 27548
		' (get) Token: 0x06011558 RID: 71000 RVA: 0x00077528 File Offset: 0x00075728
		' (set) Token: 0x06011559 RID: 71001 RVA: 0x00077532 File Offset: 0x00075732
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17006B9D RID: 27549
		' (get) Token: 0x0601155A RID: 71002 RVA: 0x0007753B File Offset: 0x0007573B
		' (set) Token: 0x0601155B RID: 71003 RVA: 0x00077545 File Offset: 0x00075745
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17006B9E RID: 27550
		' (get) Token: 0x0601155C RID: 71004 RVA: 0x0007754E File Offset: 0x0007574E
		' (set) Token: 0x0601155D RID: 71005 RVA: 0x00077558 File Offset: 0x00075758
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17006B9F RID: 27551
		' (get) Token: 0x0601155E RID: 71006 RVA: 0x00077561 File Offset: 0x00075761
		' (set) Token: 0x0601155F RID: 71007 RVA: 0x0007756B File Offset: 0x0007576B
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17006BA0 RID: 27552
		' (get) Token: 0x06011560 RID: 71008 RVA: 0x00077574 File Offset: 0x00075774
		' (set) Token: 0x06011561 RID: 71009 RVA: 0x0007757E File Offset: 0x0007577E
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17006BA1 RID: 27553
		' (get) Token: 0x06011562 RID: 71010 RVA: 0x00077587 File Offset: 0x00075787
		' (set) Token: 0x06011563 RID: 71011 RVA: 0x00077591 File Offset: 0x00075791
		Friend Overridable Property DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn

		' Token: 0x17006BA2 RID: 27554
		' (get) Token: 0x06011564 RID: 71012 RVA: 0x0007759A File Offset: 0x0007579A
		' (set) Token: 0x06011565 RID: 71013 RVA: 0x000775A4 File Offset: 0x000757A4
		Friend Overridable Property DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn

		' Token: 0x17006BA3 RID: 27555
		' (get) Token: 0x06011566 RID: 71014 RVA: 0x000775AD File Offset: 0x000757AD
		' (set) Token: 0x06011567 RID: 71015 RVA: 0x000775B7 File Offset: 0x000757B7
		Friend Overridable Property DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn

		' Token: 0x17006BA4 RID: 27556
		' (get) Token: 0x06011568 RID: 71016 RVA: 0x000775C0 File Offset: 0x000757C0
		' (set) Token: 0x06011569 RID: 71017 RVA: 0x000775CA File Offset: 0x000757CA
		Friend Overridable Property DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn

		' Token: 0x17006BA5 RID: 27557
		' (get) Token: 0x0601156A RID: 71018 RVA: 0x000775D3 File Offset: 0x000757D3
		' (set) Token: 0x0601156B RID: 71019 RVA: 0x000775DD File Offset: 0x000757DD
		Friend Overridable Property DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn

		' Token: 0x17006BA6 RID: 27558
		' (get) Token: 0x0601156C RID: 71020 RVA: 0x000775E6 File Offset: 0x000757E6
		' (set) Token: 0x0601156D RID: 71021 RVA: 0x000775F0 File Offset: 0x000757F0
		Friend Overridable Property DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn

		' Token: 0x17006BA7 RID: 27559
		' (get) Token: 0x0601156E RID: 71022 RVA: 0x000775F9 File Offset: 0x000757F9
		' (set) Token: 0x0601156F RID: 71023 RVA: 0x00077603 File Offset: 0x00075803
		Friend Overridable Property DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn

		' Token: 0x17006BA8 RID: 27560
		' (get) Token: 0x06011570 RID: 71024 RVA: 0x0007760C File Offset: 0x0007580C
		' (set) Token: 0x06011571 RID: 71025 RVA: 0x00077616 File Offset: 0x00075816
		Friend Overridable Property DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn

		' Token: 0x17006BA9 RID: 27561
		' (get) Token: 0x06011572 RID: 71026 RVA: 0x0007761F File Offset: 0x0007581F
		' (set) Token: 0x06011573 RID: 71027 RVA: 0x00077629 File Offset: 0x00075829
		Friend Overridable Property DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn

		' Token: 0x17006BAA RID: 27562
		' (get) Token: 0x06011574 RID: 71028 RVA: 0x00077632 File Offset: 0x00075832
		' (set) Token: 0x06011575 RID: 71029 RVA: 0x0007763C File Offset: 0x0007583C
		Friend Overridable Property DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn

		' Token: 0x17006BAB RID: 27563
		' (get) Token: 0x06011576 RID: 71030 RVA: 0x00077645 File Offset: 0x00075845
		' (set) Token: 0x06011577 RID: 71031 RVA: 0x0007764F File Offset: 0x0007584F
		Friend Overridable Property DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn

		' Token: 0x17006BAC RID: 27564
		' (get) Token: 0x06011578 RID: 71032 RVA: 0x00077658 File Offset: 0x00075858
		' (set) Token: 0x06011579 RID: 71033 RVA: 0x00077662 File Offset: 0x00075862
		Friend Overridable Property DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn

		' Token: 0x17006BAD RID: 27565
		' (get) Token: 0x0601157A RID: 71034 RVA: 0x0007766B File Offset: 0x0007586B
		' (set) Token: 0x0601157B RID: 71035 RVA: 0x00077675 File Offset: 0x00075875
		Friend Overridable Property DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn

		' Token: 0x17006BAE RID: 27566
		' (get) Token: 0x0601157C RID: 71036 RVA: 0x0007767E File Offset: 0x0007587E
		' (set) Token: 0x0601157D RID: 71037 RVA: 0x00077688 File Offset: 0x00075888
		Friend Overridable Property DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn

		' Token: 0x17006BAF RID: 27567
		' (get) Token: 0x0601157E RID: 71038 RVA: 0x00077691 File Offset: 0x00075891
		' (set) Token: 0x0601157F RID: 71039 RVA: 0x0007769B File Offset: 0x0007589B
		Friend Overridable Property DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn

		' Token: 0x17006BB0 RID: 27568
		' (get) Token: 0x06011580 RID: 71040 RVA: 0x000776A4 File Offset: 0x000758A4
		' (set) Token: 0x06011581 RID: 71041 RVA: 0x000776AE File Offset: 0x000758AE
		Friend Overridable Property DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn

		' Token: 0x17006BB1 RID: 27569
		' (get) Token: 0x06011582 RID: 71042 RVA: 0x000776B7 File Offset: 0x000758B7
		' (set) Token: 0x06011583 RID: 71043 RVA: 0x000776C1 File Offset: 0x000758C1
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006BB2 RID: 27570
		' (get) Token: 0x06011584 RID: 71044 RVA: 0x000776CA File Offset: 0x000758CA
		' (set) Token: 0x06011585 RID: 71045 RVA: 0x000776D4 File Offset: 0x000758D4
		Friend Overridable Property DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn

		' Token: 0x17006BB3 RID: 27571
		' (get) Token: 0x06011586 RID: 71046 RVA: 0x000776DD File Offset: 0x000758DD
		' (set) Token: 0x06011587 RID: 71047 RVA: 0x000776E7 File Offset: 0x000758E7
		Friend Overridable Property DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn

		' Token: 0x17006BB4 RID: 27572
		' (get) Token: 0x06011588 RID: 71048 RVA: 0x000776F0 File Offset: 0x000758F0
		' (set) Token: 0x06011589 RID: 71049 RVA: 0x000776FA File Offset: 0x000758FA
		Friend Overridable Property DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn

		' Token: 0x17006BB5 RID: 27573
		' (get) Token: 0x0601158A RID: 71050 RVA: 0x00077703 File Offset: 0x00075903
		' (set) Token: 0x0601158B RID: 71051 RVA: 0x0007770D File Offset: 0x0007590D
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17006BB6 RID: 27574
		' (get) Token: 0x0601158C RID: 71052 RVA: 0x00077716 File Offset: 0x00075916
		' (set) Token: 0x0601158D RID: 71053 RVA: 0x00077720 File Offset: 0x00075920
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17006BB7 RID: 27575
		' (get) Token: 0x0601158E RID: 71054 RVA: 0x00077729 File Offset: 0x00075929
		' (set) Token: 0x0601158F RID: 71055 RVA: 0x00077733 File Offset: 0x00075933
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17006BB8 RID: 27576
		' (get) Token: 0x06011590 RID: 71056 RVA: 0x0007773C File Offset: 0x0007593C
		' (set) Token: 0x06011591 RID: 71057 RVA: 0x00077746 File Offset: 0x00075946
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17006BB9 RID: 27577
		' (get) Token: 0x06011592 RID: 71058 RVA: 0x0007774F File Offset: 0x0007594F
		' (set) Token: 0x06011593 RID: 71059 RVA: 0x00077759 File Offset: 0x00075959
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17006BBA RID: 27578
		' (get) Token: 0x06011594 RID: 71060 RVA: 0x00077762 File Offset: 0x00075962
		' (set) Token: 0x06011595 RID: 71061 RVA: 0x0007776C File Offset: 0x0007596C
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17006BBB RID: 27579
		' (get) Token: 0x06011596 RID: 71062 RVA: 0x00077775 File Offset: 0x00075975
		' (set) Token: 0x06011597 RID: 71063 RVA: 0x0007777F File Offset: 0x0007597F
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17006BBC RID: 27580
		' (get) Token: 0x06011598 RID: 71064 RVA: 0x00077788 File Offset: 0x00075988
		' (set) Token: 0x06011599 RID: 71065 RVA: 0x00A0C0E4 File Offset: 0x00A0A2E4
		Private _DataGridView5 As DataGridView
		Friend Overridable Property DataGridView5 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView5_CellContentClick
				Dim dataGridView As DataGridView = Me._DataGridView5
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._DataGridView5 = value
				dataGridView = Me._DataGridView5
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006BBD RID: 27581
		' (get) Token: 0x0601159A RID: 71066 RVA: 0x00077792 File Offset: 0x00075992
		' (set) Token: 0x0601159B RID: 71067 RVA: 0x0007779C File Offset: 0x0007599C
		Friend Overridable Property chkSerialno As DataGridViewCheckBoxColumn

		' Token: 0x17006BBE RID: 27582
		' (get) Token: 0x0601159C RID: 71068 RVA: 0x000777A5 File Offset: 0x000759A5
		' (set) Token: 0x0601159D RID: 71069 RVA: 0x000777AF File Offset: 0x000759AF
		Friend Overridable Property PID As DataGridViewTextBoxColumn

		' Token: 0x17006BBF RID: 27583
		' (get) Token: 0x0601159E RID: 71070 RVA: 0x000777B8 File Offset: 0x000759B8
		' (set) Token: 0x0601159F RID: 71071 RVA: 0x000777C2 File Offset: 0x000759C2
		Friend Overridable Property Productcode As DataGridViewTextBoxColumn

		' Token: 0x17006BC0 RID: 27584
		' (get) Token: 0x060115A0 RID: 71072 RVA: 0x000777CB File Offset: 0x000759CB
		' (set) Token: 0x060115A1 RID: 71073 RVA: 0x000777D5 File Offset: 0x000759D5
		Friend Overridable Property Productname As DataGridViewTextBoxColumn

		' Token: 0x17006BC1 RID: 27585
		' (get) Token: 0x060115A2 RID: 71074 RVA: 0x000777DE File Offset: 0x000759DE
		' (set) Token: 0x060115A3 RID: 71075 RVA: 0x000777E8 File Offset: 0x000759E8
		Friend Overridable Property Barcode As DataGridViewTextBoxColumn

		' Token: 0x17006BC2 RID: 27586
		' (get) Token: 0x060115A4 RID: 71076 RVA: 0x000777F1 File Offset: 0x000759F1
		' (set) Token: 0x060115A5 RID: 71077 RVA: 0x000777FB File Offset: 0x000759FB
		Friend Overridable Property Serial_no As DataGridViewTextBoxColumn

		' Token: 0x17006BC3 RID: 27587
		' (get) Token: 0x060115A6 RID: 71078 RVA: 0x00077804 File Offset: 0x00075A04
		' (set) Token: 0x060115A7 RID: 71079 RVA: 0x0007780E File Offset: 0x00075A0E
		Friend Overridable Property DataGridView5F As DataGridView

		' Token: 0x17006BC4 RID: 27588
		' (get) Token: 0x060115A8 RID: 71080 RVA: 0x00077817 File Offset: 0x00075A17
		' (set) Token: 0x060115A9 RID: 71081 RVA: 0x00077821 File Offset: 0x00075A21
		Friend Overridable Property PID1 As DataGridViewTextBoxColumn

		' Token: 0x17006BC5 RID: 27589
		' (get) Token: 0x060115AA RID: 71082 RVA: 0x0007782A File Offset: 0x00075A2A
		' (set) Token: 0x060115AB RID: 71083 RVA: 0x00077834 File Offset: 0x00075A34
		Friend Overridable Property Productcode1 As DataGridViewTextBoxColumn

		' Token: 0x17006BC6 RID: 27590
		' (get) Token: 0x060115AC RID: 71084 RVA: 0x0007783D File Offset: 0x00075A3D
		' (set) Token: 0x060115AD RID: 71085 RVA: 0x00077847 File Offset: 0x00075A47
		Friend Overridable Property Productname1 As DataGridViewTextBoxColumn

		' Token: 0x17006BC7 RID: 27591
		' (get) Token: 0x060115AE RID: 71086 RVA: 0x00077850 File Offset: 0x00075A50
		' (set) Token: 0x060115AF RID: 71087 RVA: 0x0007785A File Offset: 0x00075A5A
		Friend Overridable Property Barcode1 As DataGridViewTextBoxColumn

		' Token: 0x17006BC8 RID: 27592
		' (get) Token: 0x060115B0 RID: 71088 RVA: 0x00077863 File Offset: 0x00075A63
		' (set) Token: 0x060115B1 RID: 71089 RVA: 0x0007786D File Offset: 0x00075A6D
		Friend Overridable Property Serial_no1 As DataGridViewTextBoxColumn

		' Token: 0x17006BC9 RID: 27593
		' (get) Token: 0x060115B2 RID: 71090 RVA: 0x00077876 File Offset: 0x00075A76
		' (set) Token: 0x060115B3 RID: 71091 RVA: 0x00077880 File Offset: 0x00075A80
		Friend Overridable Property Label3 As Label

		' Token: 0x17006BCA RID: 27594
		' (get) Token: 0x060115B4 RID: 71092 RVA: 0x00077889 File Offset: 0x00075A89
		' (set) Token: 0x060115B5 RID: 71093 RVA: 0x00077893 File Offset: 0x00075A93
		Friend Overridable Property Label13 As Label

		' Token: 0x060115B6 RID: 71094 RVA: 0x00A0C128 File Offset: 0x00A0A328
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 SR_ID FROM SalesReturn ORDER BY SR_ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("SR_ID"))
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

		' Token: 0x060115B7 RID: 71095 RVA: 0x00A0C294 File Offset: 0x00A0A494
		Private Function GenerateIDSr() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP 1 ID FROM SrSaleReturn ORDER BY ID DESC", ModCommonClasses.con)
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

		' Token: 0x060115B8 RID: 71096 RVA: 0x00A0C400 File Offset: 0x00A0A600
		Public Sub Reset()
			Me.txtSRNO.Text = ""
			Me.txtSRID.Text = ""
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.dtpSalesDate.Value = DateAndTime.Today
			Me.txtSalesID.Text = ""
			Me.txtSalesInvoiceNo.Text = ""
			Me.txtCustomerID.Text = ""
			Me.txtCustomerName.Text = ""
			Me.txtcust_ID.Text = ""
			Me.txtGSTnonGST.Text = ""
			Me.btnDelete.Enabled = True
			Me.btnDelete.Enabled = False
			Me.DataGridView1.Enabled = True
			Me.btnAdd.Enabled = True
			Me.txtTaxType.Text = ""
			Me.txtSubTotal.Text = "0.00"
			Me.txtCGST.Text = "0.00"
			Me.txtSGST.Text = "0.00"
			Me.txtCESS.Text = "0.00"
			Me.txtIGST.Text = "0.00"
			Me.txtFreightCharges.Text = "0.00"
			Me.txtBillDiscount.Text = "0.00"
			Me.txtTotal.Text = "0.00"
			Me.txtRoundOff.Text = "0.00"
			Me.txtGrandTotal.Text = "0.00"
			Me.btnRemove.Enabled = False
			Me.DataGridView1.Rows.Clear()
			Me.DataGridView2.Rows.Clear()
			Me.Clear()
			Me.btnSelection.Enabled = True
			Me.btnPrint.Enabled = False
			Me.btnSave.Enabled = True
			Me.lblSet.Text = ""
			Me.auto()
			Me.cmbPmtMode.SelectedIndex = -1
			Me.cmbBSundry.Text = "Bill Sundry"
			Me.dtpSRDate.Focus()
			Me.cmbNP.SelectedIndex = -1
			Me.lblLoyality.Text = "0.00"
			Me.lblLoyality_cr.Text = "0.00"
			Me.lblTotalLoyalityPoints.Text = "0.00"
			Me.DataGridView5.Rows.Clear()
			Me.DataGridView5F.Rows.Clear()
			Me.DataGridView5.Visible = False
			Me.DataGridView5F.Visible = False
		End Sub

		' Token: 0x060115B9 RID: 71097 RVA: 0x00A0C6C0 File Offset: 0x00A0A8C0
		Private Sub Invoicecode()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select RTRIM(c2),RTRIM(c12) from Invcode"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtInvCode1.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtSuffix.Text = ModCommonClasses.rdr.GetValue(1).ToString()
				Else
					Me.txtInvCode1.Text = "SR"
					Me.txtSuffix.Text = Me.F1.Text + "/" + Me.F2.Text
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
					Me.txtInvCode1.Text = "SR"
				End If
				Dim flag5 As Boolean = Operators.CompareString(Me.txtSuffix.Text, "", False) = 0
				If flag5 Then
					Me.txtSuffix.Text = Me.F1.Text + "/" + Me.F2.Text
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060115BA RID: 71098 RVA: 0x00A0C898 File Offset: 0x00A0AA98
		Public Sub auto()
			Try
				Me.txtSRID.Text = Me.GenerateID()
				Me.ntid = Me.GenerateIDSr()
				Me.txtSRNO.Text = String.Concat(New String() { Me.txtInvCode1.Text, "-", Me.GenerateIDSr(), "-", Me.txtSuffix.Text })
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060115BB RID: 71099 RVA: 0x00A0C948 File Offset: 0x00A0AB48
		Private Sub btnSelection_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesInvoiceRecord.lblSet.Text = "Sales Return"
			MyProject.Forms.frmSalesInvoiceRecord.Reset()
			MyProject.Forms.frmSalesInvoiceRecord.ShowDialog()
			MyProject.Forms.frmSalesInvoiceRecord.Dispose()
		End Sub

		' Token: 0x060115BC RID: 71100 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnClose_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x060115BD RID: 71101 RVA: 0x00A0C9A0 File Offset: 0x00A0ABA0
		Private Sub btnAdd_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.txtProductName.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please retrieve product info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtProductName.Focus()
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.txtReturnQty.Text, "", False) = 0
					If flag2 Then
						MessageBox.Show("Please Enter Return Quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtReturnQty.Focus()
					Else
						Dim flag3 As Boolean = Conversion.Val(Me.txtReturnQty.Text) = 0.0
						If flag3 Then
							MessageBox.Show("Return quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtReturnQty.Focus()
						Else
							Dim flag4 As Boolean = Conversion.Val(Me.txtReturnQty.Text) > Conversion.Val(Me.txtQty.Text)
							If flag4 Then
								MessageBox.Show("Return Quantity can not be greater than purchased quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtReturnQty.Text = ""
								Me.txtReturnQty.Focus()
							Else
								Dim flag5 As Boolean = Conversion.Val(Me.txtReturnQty.Text) > CDbl(Me.intLimitQty_return)
								If flag5 Then
									MessageBox.Show("Return Quantity can not be greater than purchased quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtReturnQty.Text = ""
									Me.txtReturnQty.Focus()
								Else
									Dim flag6 As Boolean = Conversion.Val(Me.txtFreeQty.Text) > Conversion.Val(Me.lblFreeQty.Text)
									If flag6 Then
										MessageBox.Show("Free Quantity can not be greater than sold free quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtFreeQty.Text = ""
										Me.txtFreeQty.Focus()
									Else
										Try
											For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
												Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
												Dim flag7 As Boolean = Operators.ConditionalCompareObjectEqual(Me.txtBarcode.Text, dataGridViewRow.Cells(3).Value, False)
												If flag7 Then
													MessageBox.Show("Same barcode already added in grid", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Me.txtBarcode.Focus()
													Return
												End If
												Dim flag8 As Boolean = Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(Me.txtBarcode.Text, dataGridViewRow.Cells(3).Value, False), Operators.CompareObjectEqual(Me.txtProductID.Text, dataGridViewRow.Cells(0).Value, False)))
												If flag8 Then
													MessageBox.Show("Record already added in grid", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Me.txtBarcode.Focus()
													Return
												End If
											Next
										Finally
											Dim enumerator As IEnumerator
											If TypeOf enumerator Is IDisposable Then
												TryCast(enumerator, IDisposable).Dispose()
											End If
										End Try
										Try
											ModCommonClasses.con.Close()
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text As String = "SELECT a.productid AS PID, RTRIM(b.ProductCode) AS Productcode, RTRIM(b.ProductName) AS ProductName, a.barcode AS Barcode, a.serialno" & vbCrLf & "                              FROM tbl_product_serial_sale a" & vbCrLf & "                              INNER JOIN product b ON a.productid = b.pid where a.invoice_no=@d1 and a.barcode=@d2"
											ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSalesInvoiceNo.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcode.Text)
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
											Me.DataGridView5.Rows.Clear()
											Dim flag9 As Boolean = ModCommonClasses.rdr.Read()
											If flag9 Then
												Dim text2 As String = Me.txtBarcode.Text
												Dim num As Integer = 0
												Try
													For Each obj2 As Object In CType(Me.DataGridView5F.Rows, IEnumerable)
														Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
														Dim flag10 As Boolean = dataGridViewRow2.Cells("Barcode1").Value IsNot Nothing AndAlso Operators.CompareString(dataGridViewRow2.Cells("Barcode1").Value.ToString(), text2, False) = 0
														If flag10 Then
															num += 1
														End If
													Next
												Finally
													Dim enumerator2 As IEnumerator
													If TypeOf enumerator2 Is IDisposable Then
														TryCast(enumerator2, IDisposable).Dispose()
													End If
												End Try
												Dim flag11 As Boolean = CDbl(num) <> Conversion.Val(Me.txtReturnQty.Text)
												If flag11 Then
													MessageBox.Show(String.Format("Quantity mismatch! Found: {0}, Expected: {1}.", Conversion.Val(Me.txtReturnQty.Text), num), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													Return
												End If
												Dim flag12 As Boolean = ModCommonClasses.rdr IsNot Nothing
												If flag12 Then
													ModCommonClasses.rdr.Close()
												End If
											End If
											ModCommonClasses.con.Close()
										Catch ex As Exception
											MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										End Try
										Dim num2 As Double = Conversions.ToDouble(Strings.Format(Math.Round(Conversion.Val(Me.txtTaxableAmt.Text) / Conversion.Val(Me.txtQty.Text) * Conversion.Val(Me.txtReturnQty.Text), 2), "0.00"))
										Me.DataGridView1.Rows.Add(New Object() { Me.txtProductID.Text, Me.txtHSNCode.Text, Me.txtProductName.Text, Me.txtBarcode.Text, Conversion.Val(Me.txtQty.Text) + Conversion.Val(Me.txtFreeQty.Text), Conversion.Val(Me.txtSalesRate.Text), Conversion.Val(Me.txtDiscPer.Text), Conversion.Val(Me.txtDisc.Text), Conversion.Val(Me.txtCGSTPer.Text), Conversion.Val(Me.txtCGSTAmt.Text), Conversion.Val(Me.txtSGSTPer.Text), Conversion.Val(Me.txtSGSTAmt.Text), Conversion.Val(Me.txtIGSTPer.Text), Conversion.Val(Me.txtIGSTAmt.Text), Conversion.Val(Me.txtCESSPer.Text), Conversion.Val(Me.txtCESSAmt.Text), Conversion.Val(Me.txtReturnQty.Text) + Conversion.Val(Me.txtFreeQty.Text), Conversion.Val(Me.txtTotalAmount.Text), Conversion.Val(Me.txtPurchaseRate.Text), Conversion.Val(Me.txtMargin.Text), Me.txtTaxType.Text, num2, Me.txtSalesManId.Text, Me.txtSalesman.Text, Me.txtSalesManPur.Text, Me.txtSalesmanComm.Text, Me.lblLoyality_cr.Text })
										Dim num3 As Double = Me.SubTotal()
										num3 = Math.Round(num3, 2)
										Me.txtSubTotal.Text = Conversions.ToString(num3)
										Me.Compute()
										Me.Clear()
										Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(2)
										Me.DataGridView5.Visible = False
										Me.intLimitQty_return = 0
									End If
								End If
							End If
						End If
					End If
				End If
			Catch ex2 As Exception
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x060115BE RID: 71102 RVA: 0x00A0D26C File Offset: 0x00A0B46C
		Private Sub ValidateAndProceed()
			Dim text As String = Me.txtBarcode.Text
			Dim num As Integer = 0
			Try
				For Each obj As Object In CType(Me.DataGridView5F.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim flag As Boolean = dataGridViewRow.Cells("Barcode1").Value IsNot Nothing AndAlso Operators.CompareString(dataGridViewRow.Cells("Barcode1").Value.ToString(), text, False) = 0
					If flag Then
						num += 1
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Dim flag2 As Boolean = CDbl(num) = Conversion.Val(Me.txtReturnQty.Text)
			If flag2 Then
				MessageBox.Show("The quantity matches. Proceeding...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			Else
				MessageBox.Show(String.Format("Quantity mismatch! Found: {0}, Expected: {1}.", Conversion.Val(Me.txtReturnQty.Text), num), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x060115BF RID: 71103 RVA: 0x00A0D38C File Offset: 0x00A0B58C
		Private Sub btnRemove_Click(sender As Object, e As EventArgs)
			Try
				Dim text As String = ""
				Try
					For Each obj As Object In Me.DataGridView1.SelectedRows
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Me.DataGridView1.Rows.Remove(dataGridViewRow)
						text = Conversions.ToString(dataGridViewRow.Cells(3).Value)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.RemoveRowsByBarcode(text)
				Dim num As Double = Me.SubTotal()
				num = Math.Round(num, 2)
				Me.txtSubTotal.Text = Conversions.ToString(num)
				Me.btnRemove.Enabled = False
				Me.Compute()
				Me.Clear()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060115C0 RID: 71104 RVA: 0x00A0D4A0 File Offset: 0x00A0B6A0
		Private Sub RemoveRowsByBarcode(barcode As String)
			' The following expression was wrapped in a checked-statement
			Try
				Me.DataGridView5.Visible = False
				Dim num As Integer = Me.DataGridView5F.Rows.Count - 1
				For i As Integer = num To 0 Step -1
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView5F.Rows(i)
					Dim flag As Boolean = dataGridViewRow.Cells("Barcode1").Value IsNot Nothing AndAlso Operators.CompareString(dataGridViewRow.Cells("Barcode1").Value.ToString(), barcode, False) = 0
					If flag Then
						Me.DataGridView5F.Rows.Remove(dataGridViewRow)
					End If
				Next
			Catch ex As Exception
				MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
			End Try
		End Sub

		' Token: 0x060115C1 RID: 71105 RVA: 0x0007789C File Offset: 0x00075A9C
		Private Sub txtRetuenQty_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x060115C2 RID: 71106 RVA: 0x00A0D598 File Offset: 0x00A0B798
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from SalesReturn where SR_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtSRID.Text))
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					Try
						For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "Update Temp_Stock set Qty=Qty - " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(16).Value))) + " where ProductID=@d1 and Barcode=@d2"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value))
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
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
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtSRNO.Text)
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
								If flag3 Then
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text4 As String = "delete from StockMovement where ProductID=@d1 and TransID=@d2"
									ModCommonClasses.cmd = New SqlCommand(text4)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtSRNO.Text)
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
					ModFunc.LedgerDelete(Me.txtSRNO.Text, "Sales Return")
					ModFunc.CustomerLedgerDelete(Me.txtSRNO.Text)
					ModFunc.SrSaleReturnDelete(Me.txtSRNO.Text)
					ModFunc.LedgerDelete_Loyality1(Me.txtSRNO.Text)
					ModFunc.CustomerLedgerDelete_Loyality1(Me.txtSRNO.Text)
					Dim text5 As String = "deleted the Sales Return record having SR No. '" + Me.txtSRNO.Text + "'"
					ModFunc.LogFunc(Me.lblUser.Text, text5)
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillSReturnID()
					Me.Reset()
					ModFunc.RefreshRecords()
				Else
					MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillSReturnID()
					Me.Reset()
				End If
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.DataforNP()
		End Sub

		' Token: 0x060115C3 RID: 71107 RVA: 0x00A0DA88 File Offset: 0x00A0BC88
		Private Sub txtReturnQty_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtReturnQty.Text
					Dim selectionStart As Integer = Me.txtReturnQty.SelectionStart
					Dim selectionLength As Integer = Me.txtReturnQty.SelectionLength
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

		' Token: 0x060115C4 RID: 71108 RVA: 0x00A0DB80 File Offset: 0x00A0BD80
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

		' Token: 0x060115C5 RID: 71109 RVA: 0x00A0DBE4 File Offset: 0x00A0BDE4
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

		' Token: 0x060115C6 RID: 71110 RVA: 0x00A0DCCC File Offset: 0x00A0BECC
		Private Sub DataGridView2_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Me.strstatus = "false"
				Dim flag As Boolean = Me.DataGridView2.Rows.Count > 0
				If flag Then
					Me.Clear()
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.SelectedRows(0)
					Me.txtProductID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Try
						Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
						sqlConnection.Open()
						Dim sqlCommand As SqlCommand = sqlConnection.CreateCommand()
						sqlCommand.CommandText = "SELECT a.ProductID, sum(a.ReturnQty)ReturnQty" & vbCrLf & "                   FROM SalesReturn_Join a" & vbCrLf & "                   INNER JOIN SalesReturn b ON a.SalesReturnID = b.SR_ID" & vbCrLf & "                   LEFT JOIN InvoiceInfo c ON b.SalesID = c.Inv_ID" & vbCrLf & "                   WHERE c.InvoiceNo = @InvoiceNo AND a.ProductID = @ProductID" & vbCrLf & "group by a.ProductID"
						sqlCommand.Parameters.AddWithValue("@InvoiceNo", Me.txtSalesInvoiceNo.Text)
						sqlCommand.Parameters.AddWithValue("@ProductID", Convert.ToInt32(Me.txtProductID.Text))
						Dim sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
						Dim flag2 As Boolean = sqlDataReader.Read()
						If flag2 Then
							Dim flag3 As Boolean = Conversion.Val(dataGridViewRow.Cells(4).Value.ToString()) <= Conversion.Val(sqlDataReader("ReturnQty").ToString())
							If flag3 Then
								Me.Label3.Text = "Available(Qty) to Return :0"
								MessageBox.Show("This product already returned")
								Return
							End If
							Me.intLimitQty_return = CInt(Math.Round(Conversion.Val(dataGridViewRow.Cells(4).Value.ToString()) - Conversion.Val(sqlDataReader("ReturnQty").ToString())))
						Else
							Me.intLimitQty_return = CInt(Math.Round(Conversion.Val(dataGridViewRow.Cells(4).Value.ToString())))
						End If
						Me.Label3.Text = "Available(Qty) to Return :" + Conversions.ToString(Me.intLimitQty_return)
						Dim flag4 As Boolean = sqlDataReader IsNot Nothing
						If flag4 Then
							sqlDataReader.Close()
						End If
						Dim flag5 As Boolean = sqlConnection.State = ConnectionState.Open
						If flag5 Then
							sqlConnection.Close()
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
					Me.txtTaxType.Text = dataGridViewRow.Cells(19).Value.ToString()
					Me.txtHSNCode.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtProductName.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtBarcode.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.bindgrid5_serialno(dataGridViewRow.Cells(3).Value.ToString())
					Me.txtQty.Text = Conversions.ToString(Conversion.Val(dataGridViewRow.Cells(4).Value.ToString()) - Conversion.Val(dataGridViewRow.Cells(21).Value.ToString()))
					Me.txtSalesRate.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.txtDiscPer.Text = dataGridViewRow.Cells(6).Value.ToString()
					Me.txtDisc.Text = dataGridViewRow.Cells(7).Value.ToString()
					Me.txtCGSTPer.Text = dataGridViewRow.Cells(8).Value.ToString()
					Me.txtCGSTAmt.Text = dataGridViewRow.Cells(9).Value.ToString()
					Me.txtSGSTPer.Text = dataGridViewRow.Cells(10).Value.ToString()
					Me.txtSGSTAmt.Text = dataGridViewRow.Cells(11).Value.ToString()
					Me.txtIGSTPer.Text = dataGridViewRow.Cells(12).Value.ToString()
					Me.txtIGSTAmt.Text = dataGridViewRow.Cells(13).Value.ToString()
					Me.txtCESSPer.Text = dataGridViewRow.Cells(14).Value.ToString()
					Me.txtCESSAmt.Text = dataGridViewRow.Cells(15).Value.ToString()
					Me.txtPurchaseRate.Text = dataGridViewRow.Cells(17).Value.ToString()
					Me.txtTaxableAmt.Text = dataGridViewRow.Cells(20).Value.ToString()
					Me.txtFreeQty.Text = dataGridViewRow.Cells(21).Value.ToString()
					Me.lblFreeQty.Text = dataGridViewRow.Cells(21).Value.ToString()
					Me.txtPurchaseRate.Text = dataGridViewRow.Cells(17).Value.ToString()
					Me.txtTaxableAmt.Text = dataGridViewRow.Cells(20).Value.ToString()
					Me.txtFreeQty.Text = dataGridViewRow.Cells(21).Value.ToString()
					Me.lblFreeQty.Text = dataGridViewRow.Cells(21).Value.ToString()
					Me.txtSalesManId.Text = dataGridViewRow.Cells(22).Value.ToString()
					Me.txtSalesman.Text = dataGridViewRow.Cells(23).Value.ToString()
					Me.txtSalesManPur.Text = dataGridViewRow.Cells(24).Value.ToString()
					Me.txtSalesmanComm.Text = dataGridViewRow.Cells(25).Value.ToString()
					Me.lblLoyality.Text = dataGridViewRow.Cells(26).Value.ToString()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
					ModCommonClasses.cmd.CommandText = If(("SELECT RTRIM(SalesUnit) from Product where PID=" + Conversions.ToString(Conversion.Val(Me.txtProductID.Text))), "")
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
					If flag6 Then
						Me.lblUnit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					End If
					Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag7 Then
						ModCommonClasses.rdr.Close()
					End If
					Dim flag8 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag8 Then
						ModCommonClasses.con.Close()
					End If
					Me.txtReturnQty.Focus()
				End If
			Catch ex2 As Exception
			End Try
		End Sub

		' Token: 0x060115C7 RID: 71111 RVA: 0x00A0E454 File Offset: 0x00A0C654
		Public Sub bindgrid5_serialno(strbarcode As String)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT a.productid AS PID, RTRIM(b.ProductCode) AS Productcode, RTRIM(b.ProductName) AS ProductName, a.barcode AS Barcode, a.serialno" & vbCrLf & "                              FROM tbl_product_serial_sale a" & vbCrLf & "                              INNER JOIN product b ON a.productid = b.pid where a.invoice_no=@d1 and a.barcode=@d2"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSalesInvoiceNo.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", strbarcode)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView5.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView5.Visible = True
					Me.DataGridView5.Rows.Add(New Object() { False, ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4) })
				End While
				ModCommonClasses.con.Close()
				Me.SyncCheckboxState()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060115C8 RID: 71112 RVA: 0x00A0E5B4 File Offset: 0x00A0C7B4
		Private Sub SyncCheckboxState()
			Try
				For Each obj As Object In CType(Me.DataGridView5.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("Serial_no").Value)
					Dim flag As Boolean = objectValue IsNot Nothing
					If flag Then
						Dim flag2 As Boolean = False
						Try
							For Each obj2 As Object In CType(Me.DataGridView5F.Rows, IEnumerable)
								Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
								Dim flag3 As Boolean = dataGridViewRow2.Cells("Serial_no1").Value IsNot Nothing AndAlso dataGridViewRow2.Cells("Serial_no1").Value.Equals(RuntimeHelpers.GetObjectValue(objectValue))
								If flag3 Then
									flag2 = True
									Exit For
								End If
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
						dataGridViewRow.Cells(0).Value = flag2
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x060115C9 RID: 71113 RVA: 0x00A0E714 File Offset: 0x00A0C914
		Private Sub DataGridView2_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.DataGridView2.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.DataGridView2.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x060115CA RID: 71114 RVA: 0x00A0E7FC File Offset: 0x00A0C9FC
		Public Sub Clear()
			Me.txtHSNCode.Text = ""
			Me.txtProductName.Text = ""
			Me.txtQty.Text = ""
			Me.txtFreeQty.Text = ""
			Me.lblFreeQty.Text = ""
			Me.txtSalesRate.Text = ""
			Me.txtDiscPer.Text = "0.00"
			Me.txtDisc.Text = "0.00"
			Me.txtCESSPer.Text = "0.00"
			Me.txtCESSAmt.Text = "0.00"
			Me.txtCGSTPer.Text = "0.00"
			Me.txtCGSTAmt.Text = "0.00"
			Me.txtSGSTPer.Text = "0.00"
			Me.txtSGSTAmt.Text = "0.00"
			Me.txtIGSTPer.Text = "0.00"
			Me.txtIGSTAmt.Text = "0.00"
			Me.txtReturnQty.Text = ""
			Me.txtTotalAmount.Text = ""
			Me.txtBarcode.Text = ""
			Me.lblUnit.Text = "Unit"
			Me.txtProductID.Text = ""
			Me.btnAdd.Enabled = True
			Me.btnRemove.Enabled = False
			Me.txtPurchaseRate.Text = ""
			Me.txtMargin.Text = ""
			Me.txtTaxType.Text = ""
			Me.txtTaxableAmt.Text = ""
		End Sub

		' Token: 0x060115CB RID: 71115 RVA: 0x000778A6 File Offset: 0x00075AA6
		Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x060115CC RID: 71116 RVA: 0x00A0E9D0 File Offset: 0x00A0CBD0
		Private Sub frmSalesReturn_Load(sender As Object, e As EventArgs)
			Me.GetCompanyState()
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.DataforNP()
			Me.Invoicecode()
			Me.auto()
			Me.Autoroundoff()
			Me.BillSundryType()
			Me.LinkLabel1.TabStop = False
			Me.fillSReturnID()
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x060115CD RID: 71117 RVA: 0x00A0EAA0 File Offset: 0x00A0CCA0
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

		' Token: 0x060115CE RID: 71118 RVA: 0x00A0ED40 File Offset: 0x00A0CF40
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

		' Token: 0x060115CF RID: 71119 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060115D0 RID: 71120 RVA: 0x00A0EE0C File Offset: 0x00A0D00C
		Public Sub GetCompanyState()
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
					Me.F1.Text = ModCommonClasses.rdr.GetValue(0).ToString().Substring(7, 4)
					Me.F2.Text = ModCommonClasses.rdr.GetValue(1).ToString().Substring(9, 2)
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

		' Token: 0x060115D1 RID: 71121 RVA: 0x00A0EF70 File Offset: 0x00A0D170
		Public Sub BillSundryType()
			Try
				ModCommonClasses.con.Close()
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT distinct RTRIM(Head) from BillSundry order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.CommandTimeout = 0
				Me.cmbBSundry.Items.Clear()
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				While ModCommonClasses.rdr.Read()
					Me.cmbBSundry.Items.Add(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060115D2 RID: 71122 RVA: 0x00A0F080 File Offset: 0x00A0D280
		Public Sub Autoroundoff()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(c1) from Autoroundoff"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TextBox1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				Else
					Me.TextBox1.Text = "No"
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				Dim flag4 As Boolean = Operators.CompareString(Me.TextBox1.Text, "Yes", False) = 0
				If flag4 Then
					Me.CheckBox1.Checked = True
				Else
					Me.CheckBox1.Checked = False
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060115D3 RID: 71123 RVA: 0x00A0F1C4 File Offset: 0x00A0D3C4
		Public Function SubTotal() As Double
			Dim num As Double = 0.0
			Try
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(21).Value))
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

		' Token: 0x060115D4 RID: 71124 RVA: 0x00A0F284 File Offset: 0x00A0D484
		Public Sub Compute()
			Me.GridCalc()
			Me.num1 = Conversion.Val(Me.txtSubTotal.Text) + Conversion.Val(Me.txtCGST.Text) + Conversion.Val(Me.txtSGST.Text) + Conversion.Val(Me.txtIGST.Text) + Conversion.Val(Me.txtCESS.Text) + Conversion.Val(Me.txtFreightCharges.Text) - Conversion.Val(Me.txtBillDiscount.Text)
			Me.num1 = Math.Round(Me.num1, 2)
			Me.txtTotal.Text = Conversions.ToString(Me.num1)
			Me.num2 = Math.Round(Me.num1, 0)
			Dim checked As Boolean = Me.CheckBox1.Checked
			If checked Then
				Me.num3 = Me.num2 - Me.num1
			Else
				Me.num3 = 0.0
			End If
			Me.num3 = Math.Round(Me.num3, 2)
			Me.txtRoundOff.Text = Conversions.ToString(Me.num3)
			Me.num4 = Conversion.Val(Me.txtTotal.Text) + Conversion.Val(Me.txtRoundOff.Text)
			Me.num4 = Math.Round(Me.num4, 2)
			Me.txtGrandTotal.Text = Conversions.ToString(Me.num4)
		End Sub

		' Token: 0x060115D5 RID: 71125 RVA: 0x00A0F400 File Offset: 0x00A0D600
		Public Sub GridCalc()
			Dim num As Double = 0.0
			Dim num2 As Double = 0.0
			Dim num3 As Double = 0.0
			Dim num4 As Double = 0.0
			Dim num5 As Double = 0.0
			Try
				For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					num = Conversions.ToDouble(Operators.AddObject(num, dataGridViewRow.Cells(9).Value))
					num2 = Conversions.ToDouble(Operators.AddObject(num2, dataGridViewRow.Cells(11).Value))
					num3 = Conversions.ToDouble(Operators.AddObject(num3, dataGridViewRow.Cells(13).Value))
					num4 = Conversions.ToDouble(Operators.AddObject(num4, dataGridViewRow.Cells(15).Value))
					num5 = Conversions.ToDouble(Operators.AddObject(num5, dataGridViewRow.Cells(26).Value))
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
			num5 = Math.Round(num5, 2)
			Me.txtCGST.Text = Conversions.ToString(num)
			Me.txtSGST.Text = Conversions.ToString(num2)
			Me.txtIGST.Text = Conversions.ToString(num3)
			Me.txtCESS.Text = Conversions.ToString(num4)
			Me.lblTotalLoyalityPoints.Text = Conversions.ToString(num5)
		End Sub

		' Token: 0x060115D6 RID: 71126 RVA: 0x00A0F5DC File Offset: 0x00A0D7DC
		Public Sub Calc()
			Dim flag As Boolean = (Operators.CompareString(Me.txtTaxType.Text, "Exclusive", False) = 0) Or (Operators.CompareString(Me.txtTaxType.Text, "Exempt GST", False) = 0) Or (Operators.CompareString(Me.txtTaxType.Text, "No Taxes", False) = 0)
			If flag Then
				Me.num1 = Conversion.Val(Me.txtReturnQty.Text) * Conversion.Val(Me.txtSalesRate.Text)
				Me.num1 = Math.Round(Me.num1, 2)
				Me.num7 = Conversion.Val(Me.num1 * Conversion.Val(Me.txtDiscPer.Text) / 100.0)
				Me.num7 = Math.Round(Me.num7, 2)
				Me.txtDisc.Text = Conversions.ToString(Me.num7)
				Me.num8 = Me.num1 - Conversion.Val(Me.txtDisc.Text)
				Me.num2 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCGSTPer.Text) / 100.0)
				Me.num2 = Math.Round(Me.num2, 2)
				Me.txtCGSTAmt.Text = Conversions.ToString(Me.num2)
				Me.num3 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtSGSTPer.Text) / 100.0)
				Me.num3 = Math.Round(Me.num3, 2)
				Me.txtSGSTAmt.Text = Conversions.ToString(Me.num3)
				Me.num4 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtIGSTPer.Text) / 100.0)
				Me.num4 = Math.Round(Me.num4, 2)
				Me.txtIGSTAmt.Text = Conversions.ToString(Me.num4)
				Me.num5 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCESSPer.Text) / 100.0)
				Me.num5 = Math.Round(Me.num5, 2)
				Me.txtCESSAmt.Text = Conversions.ToString(Me.num5)
				Me.num6 = Me.num8 + Me.num2 + Me.num3 + Me.num4 + Me.num5
				Me.num6 = Math.Round(Me.num6, 2)
				Me.txtTotalAmount.Text = Conversions.ToString(Me.num6)
				Me.txtMargin.Text = Conversions.ToString(Conversion.Val(Me.txtReturnQty.Text) * (Conversion.Val(Me.txtSalesRate.Text) - Conversion.Val(Me.txtPurchaseRate.Text)) - Conversion.Val(Me.txtDisc.Text))
				Me.lblLoyality_cr.Text = Strings.Format(Conversion.Val(Me.lblLoyality.Text) / Conversion.Val(Me.txtQty.Text) * Conversion.Val(Me.txtReturnQty.Text), "0.00")
			End If
			Dim flag2 As Boolean = Operators.CompareString(Me.txtTaxType.Text, "Inclusive", False) = 0
			If flag2 Then
				Me.num1 = Conversion.Val(Me.txtReturnQty.Text) * Conversion.Val(Me.txtSalesRate.Text)
				Me.num1 = Math.Round(Me.num1, 2)
				Me.num7 = Conversion.Val(Me.num1 * Conversion.Val(Me.txtDiscPer.Text) / 100.0)
				Me.num7 = Math.Round(Me.num7, 2)
				Me.txtDisc.Text = Conversions.ToString(Me.num7)
				Me.num8 = Me.num1 - Conversion.Val(Me.txtDisc.Text)
				Me.num2 = Me.num8 - Conversion.Val(Me.num8 / (1.0 + (Conversion.Val(Me.txtCGSTPer.Text) + Conversion.Val(Me.txtSGSTPer.Text)) / 100.0))
				Me.num2 = Math.Round(Me.num2, 2)
				Me.txtCGSTAmt.Text = Conversions.ToString(Me.num2 / 2.0)
				Me.num3 = Me.num8 - Conversion.Val(Me.num8 / (1.0 + (Conversion.Val(Me.txtCGSTPer.Text) + Conversion.Val(Me.txtSGSTPer.Text)) / 100.0))
				Me.num3 = Math.Round(Me.num3, 2)
				Me.txtSGSTAmt.Text = Conversions.ToString(Me.num3 / 2.0)
				Me.num4 = Me.num8 - Conversion.Val(Me.num8 / (1.0 + Conversion.Val(Me.txtIGSTPer.Text) / 100.0))
				Me.num4 = Math.Round(Me.num4, 2)
				Me.txtIGSTAmt.Text = Conversions.ToString(Me.num4)
				Me.num5 = Me.num8 - Conversion.Val(Me.num8 / (1.0 + Conversion.Val(Me.txtCESSPer.Text) / 100.0))
				Me.num5 = Math.Round(Me.num5, 2)
				Me.txtCESSAmt.Text = Conversions.ToString(Me.num5)
				Me.num6 = Me.num8
				Me.num6 = Math.Round(Me.num6, 2)
				Me.txtTotalAmount.Text = Conversions.ToString(Me.num6)
				Me.txtMargin.Text = Conversions.ToString(Conversion.Val(Me.txtQty.Text) * (Conversion.Val(Me.txtSalesRate.Text) - Conversion.Val(Me.txtPurchaseRate.Text)) - Conversion.Val(Me.txtDisc.Text))
				Me.lblLoyality_cr.Text = Strings.Format(Conversion.Val(Me.lblLoyality.Text) / Conversion.Val(Me.txtQty.Text) * Conversion.Val(Me.txtReturnQty.Text), "0.00")
			End If
		End Sub

		' Token: 0x060115D7 RID: 71127 RVA: 0x000778B0 File Offset: 0x00075AB0
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x060115D8 RID: 71128 RVA: 0x000778A6 File Offset: 0x00075AA6
		Private Sub txtFreightCharges_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x060115D9 RID: 71129 RVA: 0x000778A6 File Offset: 0x00075AA6
		Private Sub txtOtherCharges_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x060115DA RID: 71130 RVA: 0x00A0FCD8 File Offset: 0x00A0DED8
		Private Sub txtFreightCharges_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtFreightCharges.Text
					Dim selectionStart As Integer = Me.txtFreightCharges.SelectionStart
					Dim selectionLength As Integer = Me.txtFreightCharges.SelectionLength
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

		' Token: 0x060115DB RID: 71131 RVA: 0x00A0FDD0 File Offset: 0x00A0DFD0
		Private Sub txtOtherCharges_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtBillDiscount.Text
					Dim selectionStart As Integer = Me.txtBillDiscount.SelectionStart
					Dim selectionLength As Integer = Me.txtBillDiscount.SelectionLength
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

		' Token: 0x060115DC RID: 71132 RVA: 0x000778CC File Offset: 0x00075ACC
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Me.cmbBSundry.Text = "Bill Sundry"
		End Sub

		' Token: 0x060115DD RID: 71133 RVA: 0x00A0FEC8 File Offset: 0x00A0E0C8
		Private Sub dtpSRDate_LostFocus(sender As Object, e As EventArgs)
			Dim flag As Boolean = DateTime.Compare(Me.dtpSRDate.Value, Me.DTP1.Value) < 0
			If flag Then
				Me.dtpSRDate.Value = DateAndTime.Today
				MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				MyBase.Close()
			Else
				Dim flag2 As Boolean = DateTime.Compare(Me.dtpSRDate.Value, Me.DTP2.Value) > 0
				If flag2 Then
					Me.dtpSRDate.Value = DateAndTime.Today
					MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060115DE RID: 71134 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpSRDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060115DF RID: 71135 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtReturnQty_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060115E0 RID: 71136 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbBSundry_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060115E1 RID: 71137 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtFreightCharges_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060115E2 RID: 71138 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtBillDiscount_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060115E3 RID: 71139 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbPmtMode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060115E4 RID: 71140 RVA: 0x00A0FF74 File Offset: 0x00A0E174
		Public Sub fillSReturnID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(SR_ID) FROM SalesReturn order by SR_ID ASC", ModCommonClasses.con)
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

		' Token: 0x060115E5 RID: 71141 RVA: 0x00A100B0 File Offset: 0x00A0E2B0
		Public Sub NextPrev()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd = New SqlCommand("SELECT SR_ID, RTRIM(SRNo),SalesReturn.Date,RTRIM(TaxType),SalesID,RTRIM(InvoiceNo),InvoiceDate, RTRIM(Customer.CustomerID),RTRIM(Name),SalesReturn.SubTotal,SalesReturn.CGST,SalesReturn.SGST,SalesReturn.IGST,SalesReturn.CESS,SalesReturn.FreightCharges,SalesReturn.OtherCharges,SalesReturn.Total,SalesReturn.RoundOff,RTRIM(SalesReturn.GrandTotal),SalesReturn.PaymentMode,SalesReturn.BillSundry FROM InvoiceInfo,SalesReturn,Customer where InvoiceInfo.Inv_ID=SalesReturn.SalesID and Customer.ID=InvoiceInfo.Customer_ID and SR_ID=@d1", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtSRID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtSRNO.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.dtpSRDate.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.txtGSTnonGST.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.txtSalesID.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.txtSalesInvoiceNo.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.dtpSalesDate.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.txtCustomerID.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.txtCustomerName.Text = ModCommonClasses.rdr.GetValue(8).ToString()
					Me.txtSubTotal.Text = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.txtCGST.Text = ModCommonClasses.rdr.GetValue(10).ToString()
					Me.txtSGST.Text = ModCommonClasses.rdr.GetValue(11).ToString()
					Me.txtIGST.Text = ModCommonClasses.rdr.GetValue(12).ToString()
					Me.txtCESS.Text = ModCommonClasses.rdr.GetValue(13).ToString()
					Me.txtFreightCharges.Text = ModCommonClasses.rdr.GetValue(14).ToString()
					Me.txtBillDiscount.Text = ModCommonClasses.rdr.GetValue(15).ToString()
					Me.txtTotal.Text = ModCommonClasses.rdr.GetValue(16).ToString()
					Me.txtRoundOff.Text = ModCommonClasses.rdr.GetValue(17).ToString()
					Me.txtGrandTotal.Text = ModCommonClasses.rdr.GetValue(18).ToString()
					Me.cmbPmtMode.Text = ModCommonClasses.rdr.GetValue(19).ToString()
					Me.cmbBSundry.Text = ModCommonClasses.rdr.GetValue(20).ToString()
					Me.btnDelete.Enabled = False
					Me.DataGridView1.Enabled = True
					Me.btnAdd.Enabled = False
					Me.btnRemove.Enabled = False
					Me.lblSet.Text = "Not Allowed"
					Me.btnDelete.Enabled = True
					Me.btnSelection.Enabled = False
					Me.btnPrint.Enabled = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(SalesReturn_Join.Barcode),SalesReturn_Join.Qty, SalesReturn_Join.SalesRate,SalesReturn_Join. DiscPer, SalesReturn_Join.DiscAmt, SalesReturn_Join.CGSTPer, SalesReturn_Join.CGSTAmt, SalesReturn_Join.SGSTPer, SalesReturn_Join.SGSTAmt, SalesReturn_Join.IGSTPer,SalesReturn_Join. IGSTAmt, SalesReturn_Join.CESSPer,SalesReturn_Join. CESSAmt,ReturnQty,SalesReturn_Join. TotalAmount,SalesReturn_Join.PurchaseRate,SalesReturn_Join.Margin, RTRIM(SalesReturn_Join.STaxType), RTRIM(SalesReturn_Join.TaxableAmt) FROM SalesReturn_Join INNER JOIN SalesReturn ON SalesReturn_Join.SalesReturnID = SalesReturn.SR_ID INNER JOIN Product ON Product.PID = SalesReturn_Join.ProductID and SR_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21) })
					End While
					Me.DataGridView1.ClearSelection()
					ModCommonClasses.con.Close()
					Me.Calc()
					Me.Compute()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060115E6 RID: 71142 RVA: 0x000778E0 File Offset: 0x00075AE0
		Private Sub txtNP_KeyDown(sender As Object, e As KeyEventArgs)
			Me.NextPrev()
			Me.NextPrev()
			Me.NextPrev()
		End Sub

		' Token: 0x060115E7 RID: 71143 RVA: 0x00A10664 File Offset: 0x00A0E864
		Private Sub Button35_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmReminder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmReminder.ShowDialog()
			MyProject.Forms.frmReminder.Dispose()
		End Sub

		' Token: 0x060115E8 RID: 71144 RVA: 0x000778F8 File Offset: 0x00075AF8
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Reset()
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.ShowDialog()
			MyProject.Forms.frmSalesInvoiceRecord_GSTR.Dispose()
		End Sub

		' Token: 0x060115E9 RID: 71145 RVA: 0x00A106B4 File Offset: 0x00A0E8B4
		Private Sub DataforNP()
			ModCommonClasses.con.Close()
			Me.CurrentRow = 0
			ModCommonClasses.con.Open()
			Me.Dad = New SqlDataAdapter("Select * FROM SalesReturn", ModCommonClasses.con)
			Me.Dad.Fill(Me.Dst, "SalesReturn")
			Try
				Me.txtNP.Text = Conversions.ToString(Me.Dst.Tables("SalesReturn").Rows(Conversions.ToInteger(Me.CurrentRow))("SR_ID"))
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060115EA RID: 71146 RVA: 0x00A10790 File Offset: 0x00A0E990
		Private Sub btnNext_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtSRID.Text))
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

		' Token: 0x060115EB RID: 71147 RVA: 0x00A1084C File Offset: 0x00A0EA4C
		Private Sub txtPrev_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtSRID.Text))
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

		' Token: 0x060115EC RID: 71148 RVA: 0x00A108F8 File Offset: 0x00A0EAF8
		Private Sub btnLast_Click(sender As Object, e As EventArgs)
			Try
				' The following expression was wrapped in a checked-expression
				Me.CurrentRow = Me.Dst.Tables("SalesReturn").Rows.Count - 1
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("SalesReturn").Rows(Conversions.ToInteger(Me.CurrentRow))("SR_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060115ED RID: 71149 RVA: 0x00A109B0 File Offset: 0x00A0EBB0
		Private Sub btnFirst_Click(sender As Object, e As EventArgs)
			Try
				Me.CurrentRow = 0
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("SalesReturn").Rows(Conversions.ToInteger(Me.CurrentRow))("SR_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060115EE RID: 71150 RVA: 0x0007792B File Offset: 0x00075B2B
		Private Sub txtSubTotal_TextChanged(sender As Object, e As EventArgs)
			Me.txtSubTotal.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtSubTotal.Text), 2), "0.00")
		End Sub

		' Token: 0x060115EF RID: 71151 RVA: 0x0007795F File Offset: 0x00075B5F
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060115F0 RID: 71152 RVA: 0x00A10A48 File Offset: 0x00A0EC48
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCPhone.Text, "Trial", False) <> 0
			If Not flag Then
				Dim value As DateTime = Me.dtpSRDate.Value
				Dim dateTime As DateTime = New DateTime(value.Year, value.Month, 1)
				Dim dateTime2 As DateTime = dateTime.AddMonths(1).AddDays(-1.0)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(*) from SalesReturn where Date between @d1 and @d2 having count(*) >= 5"
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
				Try
					Dim flag6 As Boolean = Strings.Len(Strings.Trim(Me.txtSalesInvoiceNo.Text)) = 0
					If flag6 Then
						MessageBox.Show("Please retrieve Sales Info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtSalesInvoiceNo.Focus()
					Else
						Dim flag7 As Boolean = Me.DataGridView1.Rows.Count = 0
						If flag7 Then
							MessageBox.Show("Sorry no returned product info added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							Dim flag8 As Boolean = Operators.CompareString(Me.cmbBSundry.Text, "", False) = 0
							If flag8 Then
								MessageBox.Show("Not allowed to empty box of Bill Sundry Type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.cmbBSundry.Focus()
							Else
								Dim flag9 As Boolean = Me.cmbPmtMode.SelectedIndex = -1
								If flag9 Then
									MessageBox.Show("Please fill Payment Mode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.cmbPmtMode.Focus()
								Else
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text3 As String = "insert into SalesReturn(SR_ID, SRNo, Date, SalesID, SubTotal, CGST, SGST, IGST, CESS, GrandTotal,FreightCharges,OtherCharges,Total,RoundOff,PaymentMode,BillSundry,TotalLoyalityPoints) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)"
									ModCommonClasses.cmd = New SqlCommand(text3)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtSRID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtSRNO.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpSRDate.Value.[Date])
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.txtSalesID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtSubTotal.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtCGST.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtSGST.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtIGST.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(Me.txtCESS.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(Me.txtGrandTotal.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(Me.txtFreightCharges.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(Me.txtBillDiscount.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(Me.txtTotal.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(Me.txtRoundOff.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Me.cmbPmtMode.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.cmbBSundry.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Conversion.Val(Me.lblTotalLoyalityPoints.Text))
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteNonQuery()
									ModCommonClasses.con.Close()
									Dim text4 As String = "insert into SalesReturn_Join(SalesReturnID, ProductID, Barcode, Qty,SalesRate, DiscPer, DiscAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,ReturnQty, TotalAmount,PurchaseRate,Margin,STaxType,TaxableAmt,SalesManID,SalesMan,SalesManPur,SalesManComm,loyalityPoints) VALUES (" + Me.txtSRID.Text + ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25)"
									Try
										For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
											Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
											Dim flag10 As Boolean = Not dataGridViewRow.IsNewRow
											If flag10 Then
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												ModCommonClasses.cmd = New SqlCommand(text4)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.Prepare()
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(5).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(7).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(8).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(11).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(12).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(13).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(14).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(15).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(16).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(17).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(18).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(19).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d19", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(20).Value))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d20", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(21).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d21", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(22).Value))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d22", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(23).Value))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d23", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(24).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d24", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(25).Value)))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d25", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(26).Value)))
												ModCommonClasses.cmd.ExecuteNonQuery()
												ModCommonClasses.cmd.Parameters.Clear()
												ModCommonClasses.con.Close()
											End If
											Dim flag11 As Boolean = Operators.ConditionalCompareObjectNotEqual(dataGridViewRow.Cells(23).Value, "", False)
											If flag11 Then
												Dim text5 As String = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Me.txtSRNO.Text + "-" + Me.txtSalesInvoiceNo.Text + "-", dataGridViewRow.Cells(2).Value), "-"), dataGridViewRow.Cells(3).Value), "-"), Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value)).ToString()))
												ModFunc.LedgerSaveSalesman(Me.dtpSRDate.Value.[Date], Conversions.ToString(dataGridViewRow.Cells(23).Value), text5, "Sales Return", New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(25).Value))), 0D, Conversions.ToString(dataGridViewRow.Cells(22).Value), Me.txtSRNO.Text.TrimEnd(New Char(-1) {}))
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
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text6 As String = "Update Temp_Stock set Qty=Qty + " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(16).Value))) + " where ProductID=@d1 and Barcode=@d2"
											ModCommonClasses.cmd = New SqlCommand(text6)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(3).Value))
											ModCommonClasses.cmd.ExecuteReader()
											ModCommonClasses.con.Close()
										Next
									Finally
										Dim enumerator2 As IEnumerator
										If TypeOf enumerator2 Is IDisposable Then
											TryCast(enumerator2, IDisposable).Dispose()
										End If
									End Try
									Try
										For Each obj3 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
											Dim dataGridViewRow3 As DataGridViewRow = CType(obj3, DataGridViewRow)
											Dim flag12 As Boolean = Not dataGridViewRow3.IsNewRow
											If flag12 Then
												Dim flag13 As Boolean = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(16).Value)) > 0.0
												If flag13 Then
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text7 As String = "select ProductID from StockMovement where ProductID=@d1"
													ModCommonClasses.cmd = New SqlCommand(text7)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
													ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
													Dim flag14 As Boolean = Not ModCommonClasses.rdr.Read()
													If flag14 Then
														ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))), 0D, New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(16).Value))), 0D, Me.dtpSRDate.Value.[Date], Me.txtSRNO.Text)
													Else
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text8 As String = "select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 and Date < @d3"
														ModCommonClasses.cmd = New SqlCommand(text8)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpSRDate.Value.[Date])
														ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
														Dim flag15 As Boolean = ModCommonClasses.rdr.Read()
														Dim num As Double
														If flag15 Then
															num = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
														Else
															num = 0.0
														End If
														ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))), New Decimal(num), New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(16).Value))), 0D, Me.dtpSRDate.Value.[Date], Me.txtSRNO.Text)
													End If
													ModCommonClasses.con.Close()
												End If
											End If
										Next
									Finally
										Dim enumerator3 As IEnumerator
										If TypeOf enumerator3 Is IDisposable Then
											TryCast(enumerator3, IDisposable).Dispose()
										End If
									End Try
									Dim flag16 As Boolean = Me.cmbPmtMode.SelectedIndex = 1
									If flag16 Then
										ModFunc.CustomerLedgerSave(Me.dtpSRDate.Value.[Date], Me.txtCustomerName.Text, Me.txtSRNO.Text, "Sales Return", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), Me.txtCustomerID.Text, Me.txtCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {}), Me.txtSalesInvoiceNo.Text + ", " + Me.dtpSRDate.Text)
									End If
									Dim flag17 As Boolean = Me.cmbPmtMode.SelectedIndex = 0
									If flag17 Then
										ModFunc.CustomerLedgerSave(Me.dtpSRDate.Value.[Date], Me.txtCustomerName.Text, Me.txtSRNO.Text, "Sales Return", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), Me.txtCustomerID.Text, Me.txtCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {}), Me.txtSalesInvoiceNo.Text + ", " + Me.dtpSRDate.Text)
										ModFunc.CustomerLedgerSave(Me.dtpSRDate.Value.[Date], Me.txtCustomerName.Text, Me.txtSRNO.Text, "Cash Return", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D, Me.txtCustomerID.Text, Me.txtCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {}), Me.txtSalesInvoiceNo.Text + ", " + Me.dtpSRDate.Text)
									End If
									Dim flag18 As Boolean = Me.cmbPmtMode.SelectedIndex = 1
									If flag18 Then
										ModFunc.LedgerSave(Me.dtpSRDate.Value.[Date], Me.txtCustomerName.Text, Me.txtSRNO.Text, "Sales Return", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), Me.txtCustomerID.Text, Me.txtCustomerName.Text)
									End If
									Dim flag19 As Boolean = Me.cmbPmtMode.SelectedIndex = 0
									If flag19 Then
										ModFunc.LedgerSave(Me.dtpSRDate.Value.[Date], Me.txtCustomerName.Text, Me.txtSRNO.Text, "Sales Return", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), Me.txtCustomerID.Text, Me.txtCustomerName.Text)
										ModFunc.LedgerSave(Me.dtpSRDate.Value.[Date], "Cash Account", Me.txtSRNO.Text, "Sales Return", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D, Me.txtCustomerID.Text, Me.txtCustomerName.Text)
									End If
									Dim flag20 As Boolean = Me.lblTotalLoyalityPoints.Text IsNot Nothing AndAlso Not Information.IsDBNull(Me.lblTotalLoyalityPoints.Text)
									If flag20 Then
										ModFunc.LedgerSave_Loyality(Me.dtpSRDate.Value.[Date], Me.txtCustomerName.Text, Me.txtCustomerID.Text, Me.txtSRNO.Text, New Decimal(Conversion.Val(Me.lblTotalLoyalityPoints.Text)), 0D, Me.txtCustomerID.Text, Me.txtCustomerID.Text)
										ModFunc.CustomerLedgerSave_Loyality(Me.dtpSRDate.Value.[Date], Me.txtCustomerName.Text, Me.txtCustomerID.Text, Me.txtSRNO.Text, New Decimal(Conversion.Val(Me.lblTotalLoyalityPoints.Text)), 0D, Me.txtCustomerID.Text, Me.txtCustomerID.Text, "Sale Return")
									End If
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text9 As String = "insert into SrSaleReturn(ID, InvNo) Values (@d1,@d2)"
									ModCommonClasses.cmd = New SqlCommand(text9)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.ntid))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtSRNO.Text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteReader()
									ModCommonClasses.con.Close()
									Me.InsertSerial_final(Me.txtSRNO.Text, Me.lblUser.Text)
									Me.DataGridView5F.Rows.Clear()
									Me.DataGridView5F.Visible = False
									ModFunc.LogFunc(Me.lblUser.Text, "added the new Sales return record having SR No. '" + Me.txtSRNO.Text + "'")
									MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.fillSReturnID()
									Me.btnSave.Enabled = False
									ModCommonClasses.con.Close()
									Me.DataforNP()
									ModFunc.RefreshRecords()
									Me.btnPrint.Enabled = True
								End If
							End If
						End If
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x060115F1 RID: 71153 RVA: 0x00A12264 File Offset: 0x00A10464
		Public Sub InsertSerial_final(InvoiceNo As String, SysUser As String)
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				Using sqlTransaction As SqlTransaction = sqlConnection.BeginTransaction()
					Try
						Try
							For Each obj As Object In CType(Me.DataGridView5F.Rows, IEnumerable)
								Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
								Dim isNewRow As Boolean = dataGridViewRow.IsNewRow
								If Not isNewRow Then
									Dim flag As Boolean = dataGridViewRow.Cells("PID1").Value Is Nothing OrElse dataGridViewRow.Cells("Barcode1").Value Is Nothing OrElse dataGridViewRow.Cells("Serial_no1").Value Is Nothing
									If Not flag Then
										Dim text As String = "INSERT INTO tbl_product_serial_saleReturn (productid, barcode, serialno, status, sys_user, invoice_no) VALUES (@productid, @barcode, @serialno, @status, @sys_user, @invoice_no)"
										Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection, sqlTransaction)
											sqlCommand.Parameters.AddWithValue("@productid", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("PID1").Value))
											sqlCommand.Parameters.AddWithValue("@barcode", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("Barcode1").Value))
											sqlCommand.Parameters.AddWithValue("@serialno", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("Serial_no1").Value))
											sqlCommand.Parameters.AddWithValue("@status", "SALE RETURN")
											sqlCommand.Parameters.AddWithValue("@sys_user", SysUser)
											sqlCommand.Parameters.AddWithValue("@invoice_no", InvoiceNo)
											sqlCommand.ExecuteNonQuery()
										End Using
										Dim text2 As String = "UPDATE tbl_product_serial_final SET status = 'PURCHASE' WHERE serialno1 = @serialno OR serialno2 = @serialno"
										Using sqlCommand2 As SqlCommand = New SqlCommand(text2, sqlConnection, sqlTransaction)
											sqlCommand2.Parameters.AddWithValue("@serialno", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("Serial_no1").Value))
											sqlCommand2.ExecuteNonQuery()
										End Using
									End If
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						sqlTransaction.Commit()
						MessageBox.Show("Data saved successfully!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Catch ex As Exception
						sqlTransaction.Rollback()
						MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End Using
			End Using
		End Sub

		' Token: 0x060115F2 RID: 71154 RVA: 0x00A12584 File Offset: 0x00A10784
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

		' Token: 0x060115F3 RID: 71155 RVA: 0x00A125EC File Offset: 0x00A107EC
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Me.Reset()
			MyProject.Forms.frmSalesReturnRecord.lblSet.Text = "SR"
			MyProject.Forms.frmSalesReturnRecord.Reset()
			MyProject.Forms.frmSalesReturnRecord.ShowDialog()
			MyProject.Forms.frmSalesReturnRecord.Dispose()
		End Sub

		' Token: 0x060115F4 RID: 71156 RVA: 0x00A1264C File Offset: 0x00A1084C
		Private Sub btnPrint_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim rptCreditNote As rptCreditNote = New rptCreditNote()
				Dim sqlCommand As SqlCommand = New SqlCommand()
				Dim sqlCommand2 As SqlCommand = New SqlCommand()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
				Dim dataSet As DataSet = New DataSet()
				Dim dataSet2 As DataSet = New DataSet()
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = sqlConnection
				sqlCommand2.Connection = sqlConnection
				sqlCommand.CommandText = If(("SELECT " & vbCrLf & "    SR.FreightCharges, SR.OtherCharges, SR.Total, SR.RoundOff, SR.SR_ID, SR.SRNo, SR.Date, SR.SalesID, " & vbCrLf & "    SR.SubTotal, SR.CGST, SR.SGST, SR.IGST, SR.CESS, SR.GrandTotal," & vbCrLf & "    SRJ.SRJ_ID, SRJ.SalesReturnID, SRJ.ProductID, SRJ.Barcode, SRJ.Qty, SRJ.SalesRate, SRJ.DiscPer, SRJ.DiscAmt, " & vbCrLf & "    SRJ.CGSTPer, SRJ.CGSTAmt, SRJ.SGSTPer, SRJ.SGSTAmt, SRJ.IGSTPer, SRJ.IGSTAmt, SRJ.CESSPer, SRJ.CESSAmt, " & vbCrLf & "    SRJ.ReturnQty, SRJ.TotalAmount, SRJ.PurchaseRate, SRJ.Margin, " & vbCrLf & "    P.PID, P.ProductCode, P.ProductName AS ProductName1, P.SubCategoryID, P.HSNCode, SRJ.TaxableAmt AS PartNo, P.Description, " & vbCrLf & "    P.CostPrice, P.SellingPrice, P.Discount, P.CGST AS Expr1, P.SGST AS Expr2, P.CESS AS Expr3, " & vbCrLf & "    P.Barcode AS Expr4, P.ReorderPoint, P.OpeningStock, P.PurchaseUnit, P.SalesUnit, " & vbCrLf & "    II.Inv_ID, II.InvoiceNo, II.InvoiceDate, II.TaxType, II.Customer_ID, " & vbCrLf & "    C.ID, C.CustomerID, C.Name, C.Address, C.City, C.State, C.ZipCode, C.ContactNo, C.EmailID, " & vbCrLf & "    C.Remarks AS Expr11, C.AccountNumber, C.AccountName, C.Bank, C.Branch, C.IFSCCode, C.GSTIN, C.PAN, C.CIN," & vbCrLf & "    RTRIM(P.ProductName) + '(' +" & vbCrLf & "    ISNULL((" & vbCrLf & "    STUFF((" & vbCrLf & "        SELECT ',' + x.serialno" & vbCrLf & "        FROM tbl_product_serial_saleReturn x" & vbCrLf & "        WHERE x.invoice_no = SR.SRNo AND x.productid = SRJ.ProductID" & vbCrLf & "        FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '')),'') + ')' AS ProductName" & vbCrLf & "    FROM SalesReturn SR" & vbCrLf & "    INNER JOIN SalesReturn_Join SRJ ON SR.SR_ID = SRJ.SalesReturnID" & vbCrLf & "    INNER JOIN Product P ON SRJ.ProductID = P.PID" & vbCrLf & "    INNER JOIN InvoiceInfo II ON SR.SalesID = II.Inv_ID" & vbCrLf & "    INNER JOIN Customer C ON II.Customer_ID = C.ID" & vbCrLf & "    WHERE SR.SR_ID=" + Conversions.ToString(Conversion.Val(Me.txtSRID.Text))), "")
				sqlCommand2.CommandText = "SELECT * from Company"
				sqlCommand.CommandType = CommandType.Text
				sqlCommand2.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				sqlDataAdapter2.SelectCommand = sqlCommand2
				sqlDataAdapter.Fill(dataSet, "SalesReturn")
				sqlDataAdapter.Fill(dataSet, "InvoiceInfo")
				sqlDataAdapter.Fill(dataSet, "SalesReturn_join")
				sqlDataAdapter.Fill(dataSet, "Customer")
				sqlDataAdapter.Fill(dataSet, "Product")
				sqlDataAdapter2.Fill(dataSet, "Company")
				rptCreditNote.SetDataSource(dataSet)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = If(("SELECT Sum(ReturnQty*Salesrate) from SalesReturn_Join where SalesReturnID=" + Conversions.ToString(Conversion.Val(Me.txtSRID.Text))), "")
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.a = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				rptCreditNote.SetParameterValue("P1", Me.a)
				rptCreditNote.SetParameterValue("P5", Me.cmbBSundry.Text)
				rptCreditNote.SetParameterValue("SINV", Me.txtSalesInvoiceNo.Text)
				rptCreditNote.SetParameterValue("SDATE", Me.dtpSalesDate.Value)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptCreditNote
				MyProject.Forms.frmReport.ShowDialog()
				rptCreditNote.Close()
				rptCreditNote.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060115F5 RID: 71157 RVA: 0x00A12924 File Offset: 0x00A10B24
		Private Sub DataGridView5_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = e.ColumnIndex = Me.DataGridView5.Columns("chkSerialno").Index AndAlso e.RowIndex >= 0
				If flag Then
					Dim isCurrentCellDirty As Boolean = Me.DataGridView5.IsCurrentCellDirty
					If isCurrentCellDirty Then
						Me.DataGridView5.CommitEdit(DataGridViewDataErrorContexts.Commit)
					End If
					Dim dataGridViewCheckBoxCell As DataGridViewCheckBoxCell = CType(Me.DataGridView5.Rows(e.RowIndex).Cells("chkSerialno"), DataGridViewCheckBoxCell)
					Dim flag2 As Boolean = Convert.ToBoolean(RuntimeHelpers.GetObjectValue(dataGridViewCheckBoxCell.Value))
					Me.DataGridView5F.Visible = True
					Dim flag3 As Boolean = flag2
					If flag3 Then
						dataGridViewCheckBoxCell.Value = True
						Me.AddRowToDataGridView5F(e.RowIndex)
						Dim num As Integer = 0
						Try
							For Each obj As Object In CType(Me.DataGridView5F.Rows, IEnumerable)
								Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
								Dim flag4 As Boolean = dataGridViewRow.Cells("Barcode1").Value IsNot Nothing AndAlso Operators.CompareString(dataGridViewRow.Cells("Barcode1").Value.ToString(), Me.txtBarcode.Text, False) = 0
								If flag4 Then
									num += 1
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						Me.txtReturnQty.Text = Conversions.ToString(num)
					Else
						dataGridViewCheckBoxCell.Value = False
						Me.RemoveRowFromDataGridView5F(e.RowIndex)
						Dim num2 As Integer = 0
						Try
							For Each obj2 As Object In CType(Me.DataGridView5F.Rows, IEnumerable)
								Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
								Dim flag5 As Boolean = dataGridViewRow2.Cells("Barcode1").Value IsNot Nothing AndAlso Operators.CompareString(dataGridViewRow2.Cells("Barcode1").Value.ToString(), Me.txtBarcode.Text, False) = 0
								If flag5 Then
									num2 += 1
								End If
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
						Me.txtReturnQty.Text = num2.ToString()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060115F6 RID: 71158 RVA: 0x00A12C00 File Offset: 0x00A10E00
		Private Sub AddRowToDataGridView5F(rowIndex As Integer)
			Dim dataGridViewRow As DataGridViewRow = Me.DataGridView5.Rows(rowIndex)
			Me.DataGridView5F.Rows.Add(New Object() { dataGridViewRow.Cells("PID").Value, dataGridViewRow.Cells("Productcode").Value, dataGridViewRow.Cells("Productname").Value, dataGridViewRow.Cells("Barcode").Value, dataGridViewRow.Cells("Serial_no").Value })
		End Sub

		' Token: 0x060115F7 RID: 71159 RVA: 0x00A12CB0 File Offset: 0x00A10EB0
		Private Sub RemoveRowFromDataGridView5F(rowIndex As Integer)
			Dim dataGridViewRow As DataGridViewRow = Me.DataGridView5.Rows(rowIndex)
			Dim text As String = If((dataGridViewRow.Cells("Serial_no").Value IsNot Nothing), dataGridViewRow.Cells("Serial_no").Value.ToString(), "")
			Dim flag As Boolean = Not Me.DataGridView5F.Columns.Contains("Serial_no1")
			If flag Then
				MessageBox.Show("Column 'Serial_no' not found in DataGridView5F.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Try
					For Each obj As Object In CType(Me.DataGridView5F.Rows, IEnumerable)
						Dim dataGridViewRow2 As DataGridViewRow = CType(obj, DataGridViewRow)
						Dim flag2 As Boolean = dataGridViewRow2.Cells("Serial_no1").Value IsNot Nothing AndAlso Operators.CompareString(dataGridViewRow2.Cells("Serial_no1").Value.ToString(), text, False) = 0
						If flag2 Then
							Me.DataGridView5F.Rows.Remove(dataGridViewRow2)
							Exit For
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			End If
		End Sub

		' Token: 0x060115F8 RID: 71160 RVA: 0x00A12DF0 File Offset: 0x00A10FF0
		Public Sub Speaker()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.DataGridView1.Rows.Count - 1
				For i As Integer = 0 To num
					Dim num2 As Double = Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("DataGridViewTextBoxColumn28").Value))
					Me.txtRsToWords.Text = Conversions.ToString(RupModule1.RupeesToWord(Conversion.Val(num2)))
					Me.a1 = Me.DataGridView1.Rows(i).Cells("DataGridViewTextBoxColumn12").Value.ToString()
					Me.a2 = Conversions.ToString(Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("Column1").Value)))
					NewLateBinding.LateCall(Me.voice, Nothing, "speak", New Object() { String.Concat(New String() { Me.a1, " ", Me.a2, "Main Unit ", Me.txtRsToWords.Text }) }, Nothing, Nothing, Nothing, True)
				Next
				NewLateBinding.LateCall(Me.voice, Nothing, "speak", New Object() { "Thank You" }, Nothing, Nothing, Nothing, True)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060115F9 RID: 71161 RVA: 0x00A12F90 File Offset: 0x00A11190
		Private Sub Button34_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.DataGridView1.Rows.Count = 0
			If flag Then
				MessageBox.Show("You have not added the products into grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Me.Speaker()
			End If
		End Sub

		' Token: 0x060115FA RID: 71162 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSalesReturn_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060115FB RID: 71163 RVA: 0x00A12FD4 File Offset: 0x00A111D4
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

		' Token: 0x060115FC RID: 71164 RVA: 0x00A130CC File Offset: 0x00A112CC
		Public Sub LastBillDate()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT Top 1 Date from SalesReturn order by SR_ID DESC"
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
					Me.dtpSRDate.Value = Me.prevdate
				Else
					Me.dtpSRDate.Value = DateAndTime.Today
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0400689A RID: 26778
		Private str As String

		' Token: 0x0400689B RID: 26779
		Private st As String

		' Token: 0x0400689C RID: 26780
		Private num1 As Double

		' Token: 0x0400689D RID: 26781
		Private num2 As Double

		' Token: 0x0400689E RID: 26782
		Private num3 As Double

		' Token: 0x0400689F RID: 26783
		Private num4 As Double

		' Token: 0x040068A0 RID: 26784
		Private num5 As Double

		' Token: 0x040068A1 RID: 26785
		Private num6 As Double

		' Token: 0x040068A2 RID: 26786
		Private num7 As Double

		' Token: 0x040068A3 RID: 26787
		Private num8 As Double

		' Token: 0x040068A4 RID: 26788
		Private num9 As Double

		' Token: 0x040068A5 RID: 26789
		Private num10 As Double

		' Token: 0x040068A6 RID: 26790
		Private num11 As Double

		' Token: 0x040068A7 RID: 26791
		Private a As Decimal

		' Token: 0x040068A8 RID: 26792
		Private strstatus As String

		' Token: 0x040068A9 RID: 26793
		Private intLimitQty_return As Integer

		' Token: 0x040068AA RID: 26794
		Private ntid As String

		' Token: 0x040068AB RID: 26795
		Private Dad As SqlDataAdapter

		' Token: 0x040068AC RID: 26796
		Private Dst As DataSet

		' Token: 0x040068AD RID: 26797
		Private CurrentRow As Object

		' Token: 0x040068AE RID: 26798
		Private voice As Object

		' Token: 0x040068AF RID: 26799
		Private a1 As String

		' Token: 0x040068B0 RID: 26800
		Private a2 As String

		' Token: 0x040068B1 RID: 26801
		Private InvDateSts As String

		' Token: 0x040068B2 RID: 26802
		Private prevdate As DateTime
	End Class
End Namespace
