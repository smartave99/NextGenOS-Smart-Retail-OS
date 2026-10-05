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
Imports CrystalDecisions.CrystalReports.Engine
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000594 RID: 1428
	<DesignerGenerated()>
	Public Partial Class frmPurchaseReturn
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0601172D RID: 71469 RVA: 0x00A1E674 File Offset: 0x00A1C874
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmPurchaseReturn_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmPurchaseReturn_KeyDown
			Me.a = 0D
			Me.intLimitQty_return = 0
			Me.ntid = ""
			Me.Dst = New DataSet()
			Me.voice = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("SAPI.spvoice", ""))
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006C32 RID: 27698
		' (get) Token: 0x06011730 RID: 71472 RVA: 0x0007814F File Offset: 0x0007634F
		' (set) Token: 0x06011731 RID: 71473 RVA: 0x00078159 File Offset: 0x00076359
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006C33 RID: 27699
		' (get) Token: 0x06011732 RID: 71474 RVA: 0x00078162 File Offset: 0x00076362
		' (set) Token: 0x06011733 RID: 71475 RVA: 0x0007816C File Offset: 0x0007636C
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006C34 RID: 27700
		' (get) Token: 0x06011734 RID: 71476 RVA: 0x00078175 File Offset: 0x00076375
		' (set) Token: 0x06011735 RID: 71477 RVA: 0x0007817F File Offset: 0x0007637F
		Friend Overridable Property Label1 As Label

		' Token: 0x17006C35 RID: 27701
		' (get) Token: 0x06011736 RID: 71478 RVA: 0x00078188 File Offset: 0x00076388
		' (set) Token: 0x06011737 RID: 71479 RVA: 0x00078192 File Offset: 0x00076392
		Friend Overridable Property txtPurchaseID As TextBox

		' Token: 0x17006C36 RID: 27702
		' (get) Token: 0x06011738 RID: 71480 RVA: 0x0007819B File Offset: 0x0007639B
		' (set) Token: 0x06011739 RID: 71481 RVA: 0x000781A5 File Offset: 0x000763A5
		Friend Overridable Property lblUser As Label

		' Token: 0x17006C37 RID: 27703
		' (get) Token: 0x0601173A RID: 71482 RVA: 0x000781AE File Offset: 0x000763AE
		' (set) Token: 0x0601173B RID: 71483 RVA: 0x000781B8 File Offset: 0x000763B8
		Friend Overridable Property lblSet As Label

		' Token: 0x17006C38 RID: 27704
		' (get) Token: 0x0601173C RID: 71484 RVA: 0x000781C1 File Offset: 0x000763C1
		' (set) Token: 0x0601173D RID: 71485 RVA: 0x000781CB File Offset: 0x000763CB
		Friend Overridable Property lblUserType As Label

		' Token: 0x17006C39 RID: 27705
		' (get) Token: 0x0601173E RID: 71486 RVA: 0x000781D4 File Offset: 0x000763D4
		' (set) Token: 0x0601173F RID: 71487 RVA: 0x00A26C20 File Offset: 0x00A24E20
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

		' Token: 0x17006C3A RID: 27706
		' (get) Token: 0x06011740 RID: 71488 RVA: 0x000781DE File Offset: 0x000763DE
		' (set) Token: 0x06011741 RID: 71489 RVA: 0x000781E8 File Offset: 0x000763E8
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17006C3B RID: 27707
		' (get) Token: 0x06011742 RID: 71490 RVA: 0x000781F1 File Offset: 0x000763F1
		' (set) Token: 0x06011743 RID: 71491 RVA: 0x000781FB File Offset: 0x000763FB
		Friend Overridable Property txtProductID As TextBox

		' Token: 0x17006C3C RID: 27708
		' (get) Token: 0x06011744 RID: 71492 RVA: 0x00078204 File Offset: 0x00076404
		' (set) Token: 0x06011745 RID: 71493 RVA: 0x0007820E File Offset: 0x0007640E
		Friend Overridable Property GroupBox5 As GroupBox

		' Token: 0x17006C3D RID: 27709
		' (get) Token: 0x06011746 RID: 71494 RVA: 0x00078217 File Offset: 0x00076417
		' (set) Token: 0x06011747 RID: 71495 RVA: 0x00A26C64 File Offset: 0x00A24E64
		Private _dtpPRDate As DateTimePicker
		Friend Overridable Property dtpPRDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpPRDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim eventHandler As EventHandler = AddressOf Me.dtpPRDate_LostFocus
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpPRDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpPRDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.LostFocus, eventHandler
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpPRDate = value
				dateTimePicker = Me._dtpPRDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.LostFocus, eventHandler
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006C3E RID: 27710
		' (get) Token: 0x06011748 RID: 71496 RVA: 0x00078221 File Offset: 0x00076421
		' (set) Token: 0x06011749 RID: 71497 RVA: 0x0007822B File Offset: 0x0007642B
		Friend Overridable Property Label44 As Label

		' Token: 0x17006C3F RID: 27711
		' (get) Token: 0x0601174A RID: 71498 RVA: 0x00078234 File Offset: 0x00076434
		' (set) Token: 0x0601174B RID: 71499 RVA: 0x0007823E File Offset: 0x0007643E
		Friend Overridable Property txtPRNO As TextBox

		' Token: 0x17006C40 RID: 27712
		' (get) Token: 0x0601174C RID: 71500 RVA: 0x00078247 File Offset: 0x00076447
		' (set) Token: 0x0601174D RID: 71501 RVA: 0x00078251 File Offset: 0x00076451
		Friend Overridable Property Label47 As Label

		' Token: 0x17006C41 RID: 27713
		' (get) Token: 0x0601174E RID: 71502 RVA: 0x0007825A File Offset: 0x0007645A
		' (set) Token: 0x0601174F RID: 71503 RVA: 0x00078264 File Offset: 0x00076464
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17006C42 RID: 27714
		' (get) Token: 0x06011750 RID: 71504 RVA: 0x0007826D File Offset: 0x0007646D
		' (set) Token: 0x06011751 RID: 71505 RVA: 0x00A26CC4 File Offset: 0x00A24EC4
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

		' Token: 0x17006C43 RID: 27715
		' (get) Token: 0x06011752 RID: 71506 RVA: 0x00078277 File Offset: 0x00076477
		' (set) Token: 0x06011753 RID: 71507 RVA: 0x00078281 File Offset: 0x00076481
		Friend Overridable Property Label10 As Label

		' Token: 0x17006C44 RID: 27716
		' (get) Token: 0x06011754 RID: 71508 RVA: 0x0007828A File Offset: 0x0007648A
		' (set) Token: 0x06011755 RID: 71509 RVA: 0x00078294 File Offset: 0x00076494
		Friend Overridable Property txtSupplierID As TextBox

		' Token: 0x17006C45 RID: 27717
		' (get) Token: 0x06011756 RID: 71510 RVA: 0x0007829D File Offset: 0x0007649D
		' (set) Token: 0x06011757 RID: 71511 RVA: 0x000782A7 File Offset: 0x000764A7
		Friend Overridable Property Label3 As Label

		' Token: 0x17006C46 RID: 27718
		' (get) Token: 0x06011758 RID: 71512 RVA: 0x000782B0 File Offset: 0x000764B0
		' (set) Token: 0x06011759 RID: 71513 RVA: 0x000782BA File Offset: 0x000764BA
		Friend Overridable Property txtSupplierName As TextBox

		' Token: 0x17006C47 RID: 27719
		' (get) Token: 0x0601175A RID: 71514 RVA: 0x000782C3 File Offset: 0x000764C3
		' (set) Token: 0x0601175B RID: 71515 RVA: 0x000782CD File Offset: 0x000764CD
		Friend Overridable Property txtPurchaseInvoiceNo As TextBox

		' Token: 0x17006C48 RID: 27720
		' (get) Token: 0x0601175C RID: 71516 RVA: 0x000782D6 File Offset: 0x000764D6
		' (set) Token: 0x0601175D RID: 71517 RVA: 0x000782E0 File Offset: 0x000764E0
		Friend Overridable Property Label2 As Label

		' Token: 0x17006C49 RID: 27721
		' (get) Token: 0x0601175E RID: 71518 RVA: 0x000782E9 File Offset: 0x000764E9
		' (set) Token: 0x0601175F RID: 71519 RVA: 0x000782F3 File Offset: 0x000764F3
		Friend Overridable Property Label36 As Label

		' Token: 0x17006C4A RID: 27722
		' (get) Token: 0x06011760 RID: 71520 RVA: 0x000782FC File Offset: 0x000764FC
		' (set) Token: 0x06011761 RID: 71521 RVA: 0x00A26D08 File Offset: 0x00A24F08
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

		' Token: 0x17006C4B RID: 27723
		' (get) Token: 0x06011762 RID: 71522 RVA: 0x00078306 File Offset: 0x00076506
		' (set) Token: 0x06011763 RID: 71523 RVA: 0x00A26D4C File Offset: 0x00A24F4C
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

		' Token: 0x17006C4C RID: 27724
		' (get) Token: 0x06011764 RID: 71524 RVA: 0x00078310 File Offset: 0x00076510
		' (set) Token: 0x06011765 RID: 71525 RVA: 0x0007831A File Offset: 0x0007651A
		Friend Overridable Property dtpPurchaseDate As DateTimePicker

		' Token: 0x17006C4D RID: 27725
		' (get) Token: 0x06011766 RID: 71526 RVA: 0x00078323 File Offset: 0x00076523
		' (set) Token: 0x06011767 RID: 71527 RVA: 0x0007832D File Offset: 0x0007652D
		Friend Overridable Property Label11 As Label

		' Token: 0x17006C4E RID: 27726
		' (get) Token: 0x06011768 RID: 71528 RVA: 0x00078336 File Offset: 0x00076536
		' (set) Token: 0x06011769 RID: 71529 RVA: 0x00A26D90 File Offset: 0x00A24F90
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

		' Token: 0x17006C4F RID: 27727
		' (get) Token: 0x0601176A RID: 71530 RVA: 0x00078340 File Offset: 0x00076540
		' (set) Token: 0x0601176B RID: 71531 RVA: 0x0007834A File Offset: 0x0007654A
		Friend Overridable Property txtPRID As TextBox

		' Token: 0x17006C50 RID: 27728
		' (get) Token: 0x0601176C RID: 71532 RVA: 0x00078353 File Offset: 0x00076553
		' (set) Token: 0x0601176D RID: 71533 RVA: 0x0007835D File Offset: 0x0007655D
		Friend Overridable Property txtSup_ID As TextBox

		' Token: 0x17006C51 RID: 27729
		' (get) Token: 0x0601176E RID: 71534 RVA: 0x00078366 File Offset: 0x00076566
		' (set) Token: 0x0601176F RID: 71535 RVA: 0x00078370 File Offset: 0x00076570
		Friend Overridable Property pnlCalc As Panel

		' Token: 0x17006C52 RID: 27730
		' (get) Token: 0x06011770 RID: 71536 RVA: 0x00078379 File Offset: 0x00076579
		' (set) Token: 0x06011771 RID: 71537 RVA: 0x00078383 File Offset: 0x00076583
		Friend Overridable Property Label43 As Label

		' Token: 0x17006C53 RID: 27731
		' (get) Token: 0x06011772 RID: 71538 RVA: 0x0007838C File Offset: 0x0007658C
		' (set) Token: 0x06011773 RID: 71539 RVA: 0x00078396 File Offset: 0x00076596
		Friend Overridable Property txtCESS As TextBox

		' Token: 0x17006C54 RID: 27732
		' (get) Token: 0x06011774 RID: 71540 RVA: 0x0007839F File Offset: 0x0007659F
		' (set) Token: 0x06011775 RID: 71541 RVA: 0x000783A9 File Offset: 0x000765A9
		Friend Overridable Property txtIGST As TextBox

		' Token: 0x17006C55 RID: 27733
		' (get) Token: 0x06011776 RID: 71542 RVA: 0x000783B2 File Offset: 0x000765B2
		' (set) Token: 0x06011777 RID: 71543 RVA: 0x000783BC File Offset: 0x000765BC
		Friend Overridable Property Label5 As Label

		' Token: 0x17006C56 RID: 27734
		' (get) Token: 0x06011778 RID: 71544 RVA: 0x000783C5 File Offset: 0x000765C5
		' (set) Token: 0x06011779 RID: 71545 RVA: 0x000783CF File Offset: 0x000765CF
		Friend Overridable Property txtSGST As TextBox

		' Token: 0x17006C57 RID: 27735
		' (get) Token: 0x0601177A RID: 71546 RVA: 0x000783D8 File Offset: 0x000765D8
		' (set) Token: 0x0601177B RID: 71547 RVA: 0x000783E2 File Offset: 0x000765E2
		Friend Overridable Property Label23 As Label

		' Token: 0x17006C58 RID: 27736
		' (get) Token: 0x0601177C RID: 71548 RVA: 0x000783EB File Offset: 0x000765EB
		' (set) Token: 0x0601177D RID: 71549 RVA: 0x000783F5 File Offset: 0x000765F5
		Friend Overridable Property txtCGST As TextBox

		' Token: 0x17006C59 RID: 27737
		' (get) Token: 0x0601177E RID: 71550 RVA: 0x000783FE File Offset: 0x000765FE
		' (set) Token: 0x0601177F RID: 71551 RVA: 0x00078408 File Offset: 0x00076608
		Friend Overridable Property Label14 As Label

		' Token: 0x17006C5A RID: 27738
		' (get) Token: 0x06011780 RID: 71552 RVA: 0x00078411 File Offset: 0x00076611
		' (set) Token: 0x06011781 RID: 71553 RVA: 0x0007841B File Offset: 0x0007661B
		Friend Overridable Property Label32 As Label

		' Token: 0x17006C5B RID: 27739
		' (get) Token: 0x06011782 RID: 71554 RVA: 0x00078424 File Offset: 0x00076624
		' (set) Token: 0x06011783 RID: 71555 RVA: 0x0007842E File Offset: 0x0007662E
		Friend Overridable Property txtTotal As TextBox

		' Token: 0x17006C5C RID: 27740
		' (get) Token: 0x06011784 RID: 71556 RVA: 0x00078437 File Offset: 0x00076637
		' (set) Token: 0x06011785 RID: 71557 RVA: 0x00078441 File Offset: 0x00076641
		Friend Overridable Property Label17 As Label

		' Token: 0x17006C5D RID: 27741
		' (get) Token: 0x06011786 RID: 71558 RVA: 0x0007844A File Offset: 0x0007664A
		' (set) Token: 0x06011787 RID: 71559 RVA: 0x00078454 File Offset: 0x00076654
		Friend Overridable Property Label16 As Label

		' Token: 0x17006C5E RID: 27742
		' (get) Token: 0x06011788 RID: 71560 RVA: 0x0007845D File Offset: 0x0007665D
		' (set) Token: 0x06011789 RID: 71561 RVA: 0x00078467 File Offset: 0x00076667
		Friend Overridable Property txtRoundOff As TextBox

		' Token: 0x17006C5F RID: 27743
		' (get) Token: 0x0601178A RID: 71562 RVA: 0x00078470 File Offset: 0x00076670
		' (set) Token: 0x0601178B RID: 71563 RVA: 0x0007847A File Offset: 0x0007667A
		Friend Overridable Property txtGrandTotal As TextBox

		' Token: 0x17006C60 RID: 27744
		' (get) Token: 0x0601178C RID: 71564 RVA: 0x00078483 File Offset: 0x00076683
		' (set) Token: 0x0601178D RID: 71565 RVA: 0x00A26E0C File Offset: 0x00A2500C
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

		' Token: 0x17006C61 RID: 27745
		' (get) Token: 0x0601178E RID: 71566 RVA: 0x0007848D File Offset: 0x0007668D
		' (set) Token: 0x0601178F RID: 71567 RVA: 0x00078497 File Offset: 0x00076697
		Friend Overridable Property Label31 As Label

		' Token: 0x17006C62 RID: 27746
		' (get) Token: 0x06011790 RID: 71568 RVA: 0x000784A0 File Offset: 0x000766A0
		' (set) Token: 0x06011791 RID: 71569 RVA: 0x00A26E50 File Offset: 0x00A25050
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

		' Token: 0x17006C63 RID: 27747
		' (get) Token: 0x06011792 RID: 71570 RVA: 0x000784AA File Offset: 0x000766AA
		' (set) Token: 0x06011793 RID: 71571 RVA: 0x00A26EB0 File Offset: 0x00A250B0
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

		' Token: 0x17006C64 RID: 27748
		' (get) Token: 0x06011794 RID: 71572 RVA: 0x000784B4 File Offset: 0x000766B4
		' (set) Token: 0x06011795 RID: 71573 RVA: 0x000784BE File Offset: 0x000766BE
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x17006C65 RID: 27749
		' (get) Token: 0x06011796 RID: 71574 RVA: 0x000784C7 File Offset: 0x000766C7
		' (set) Token: 0x06011797 RID: 71575 RVA: 0x000784D1 File Offset: 0x000766D1
		Friend Overridable Property txtCESSAmt As TextBox

		' Token: 0x17006C66 RID: 27750
		' (get) Token: 0x06011798 RID: 71576 RVA: 0x000784DA File Offset: 0x000766DA
		' (set) Token: 0x06011799 RID: 71577 RVA: 0x000784E4 File Offset: 0x000766E4
		Friend Overridable Property txtIGSTAmt As TextBox

		' Token: 0x17006C67 RID: 27751
		' (get) Token: 0x0601179A RID: 71578 RVA: 0x000784ED File Offset: 0x000766ED
		' (set) Token: 0x0601179B RID: 71579 RVA: 0x000784F7 File Offset: 0x000766F7
		Friend Overridable Property Label7 As Label

		' Token: 0x17006C68 RID: 27752
		' (get) Token: 0x0601179C RID: 71580 RVA: 0x00078500 File Offset: 0x00076700
		' (set) Token: 0x0601179D RID: 71581 RVA: 0x0007850A File Offset: 0x0007670A
		Friend Overridable Property Label41 As Label

		' Token: 0x17006C69 RID: 27753
		' (get) Token: 0x0601179E RID: 71582 RVA: 0x00078513 File Offset: 0x00076713
		' (set) Token: 0x0601179F RID: 71583 RVA: 0x0007851D File Offset: 0x0007671D
		Friend Overridable Property Label35 As Label

		' Token: 0x17006C6A RID: 27754
		' (get) Token: 0x060117A0 RID: 71584 RVA: 0x00078526 File Offset: 0x00076726
		' (set) Token: 0x060117A1 RID: 71585 RVA: 0x00078530 File Offset: 0x00076730
		Friend Overridable Property txtIGSTPer As TextBox

		' Token: 0x17006C6B RID: 27755
		' (get) Token: 0x060117A2 RID: 71586 RVA: 0x00078539 File Offset: 0x00076739
		' (set) Token: 0x060117A3 RID: 71587 RVA: 0x00078543 File Offset: 0x00076743
		Friend Overridable Property Label42 As Label

		' Token: 0x17006C6C RID: 27756
		' (get) Token: 0x060117A4 RID: 71588 RVA: 0x0007854C File Offset: 0x0007674C
		' (set) Token: 0x060117A5 RID: 71589 RVA: 0x00078556 File Offset: 0x00076756
		Friend Overridable Property txtDisc As TextBox

		' Token: 0x17006C6D RID: 27757
		' (get) Token: 0x060117A6 RID: 71590 RVA: 0x0007855F File Offset: 0x0007675F
		' (set) Token: 0x060117A7 RID: 71591 RVA: 0x00078569 File Offset: 0x00076769
		Friend Overridable Property Label28 As Label

		' Token: 0x17006C6E RID: 27758
		' (get) Token: 0x060117A8 RID: 71592 RVA: 0x00078572 File Offset: 0x00076772
		' (set) Token: 0x060117A9 RID: 71593 RVA: 0x0007857C File Offset: 0x0007677C
		Friend Overridable Property txtCESSPer As TextBox

		' Token: 0x17006C6F RID: 27759
		' (get) Token: 0x060117AA RID: 71594 RVA: 0x00078585 File Offset: 0x00076785
		' (set) Token: 0x060117AB RID: 71595 RVA: 0x0007858F File Offset: 0x0007678F
		Friend Overridable Property txtSGSTAmt As TextBox

		' Token: 0x17006C70 RID: 27760
		' (get) Token: 0x060117AC RID: 71596 RVA: 0x00078598 File Offset: 0x00076798
		' (set) Token: 0x060117AD RID: 71597 RVA: 0x000785A2 File Offset: 0x000767A2
		Friend Overridable Property Label45 As Label

		' Token: 0x17006C71 RID: 27761
		' (get) Token: 0x060117AE RID: 71598 RVA: 0x000785AB File Offset: 0x000767AB
		' (set) Token: 0x060117AF RID: 71599 RVA: 0x000785B5 File Offset: 0x000767B5
		Friend Overridable Property Label46 As Label

		' Token: 0x17006C72 RID: 27762
		' (get) Token: 0x060117B0 RID: 71600 RVA: 0x000785BE File Offset: 0x000767BE
		' (set) Token: 0x060117B1 RID: 71601 RVA: 0x000785C8 File Offset: 0x000767C8
		Friend Overridable Property txtDiscPer As TextBox

		' Token: 0x17006C73 RID: 27763
		' (get) Token: 0x060117B2 RID: 71602 RVA: 0x000785D1 File Offset: 0x000767D1
		' (set) Token: 0x060117B3 RID: 71603 RVA: 0x000785DB File Offset: 0x000767DB
		Friend Overridable Property Label21 As Label

		' Token: 0x17006C74 RID: 27764
		' (get) Token: 0x060117B4 RID: 71604 RVA: 0x000785E4 File Offset: 0x000767E4
		' (set) Token: 0x060117B5 RID: 71605 RVA: 0x000785EE File Offset: 0x000767EE
		Friend Overridable Property txtBarcode As TextBox

		' Token: 0x17006C75 RID: 27765
		' (get) Token: 0x060117B6 RID: 71606 RVA: 0x000785F7 File Offset: 0x000767F7
		' (set) Token: 0x060117B7 RID: 71607 RVA: 0x00078601 File Offset: 0x00076801
		Friend Overridable Property Label33 As Label

		' Token: 0x17006C76 RID: 27766
		' (get) Token: 0x060117B8 RID: 71608 RVA: 0x0007860A File Offset: 0x0007680A
		' (set) Token: 0x060117B9 RID: 71609 RVA: 0x00078614 File Offset: 0x00076814
		Friend Overridable Property txtCGSTAmt As TextBox

		' Token: 0x17006C77 RID: 27767
		' (get) Token: 0x060117BA RID: 71610 RVA: 0x0007861D File Offset: 0x0007681D
		' (set) Token: 0x060117BB RID: 71611 RVA: 0x00078627 File Offset: 0x00076827
		Friend Overridable Property txtPrice As TextBox

		' Token: 0x17006C78 RID: 27768
		' (get) Token: 0x060117BC RID: 71612 RVA: 0x00078630 File Offset: 0x00076830
		' (set) Token: 0x060117BD RID: 71613 RVA: 0x0007863A File Offset: 0x0007683A
		Friend Overridable Property txtSGSTPer As TextBox

		' Token: 0x17006C79 RID: 27769
		' (get) Token: 0x060117BE RID: 71614 RVA: 0x00078643 File Offset: 0x00076843
		' (set) Token: 0x060117BF RID: 71615 RVA: 0x0007864D File Offset: 0x0007684D
		Friend Overridable Property txtQty As TextBox

		' Token: 0x17006C7A RID: 27770
		' (get) Token: 0x060117C0 RID: 71616 RVA: 0x00078656 File Offset: 0x00076856
		' (set) Token: 0x060117C1 RID: 71617 RVA: 0x00078660 File Offset: 0x00076860
		Friend Overridable Property txtCGSTPer As TextBox

		' Token: 0x17006C7B RID: 27771
		' (get) Token: 0x060117C2 RID: 71618 RVA: 0x00078669 File Offset: 0x00076869
		' (set) Token: 0x060117C3 RID: 71619 RVA: 0x00078673 File Offset: 0x00076873
		Friend Overridable Property Label25 As Label

		' Token: 0x17006C7C RID: 27772
		' (get) Token: 0x060117C4 RID: 71620 RVA: 0x0007867C File Offset: 0x0007687C
		' (set) Token: 0x060117C5 RID: 71621 RVA: 0x00078686 File Offset: 0x00076886
		Friend Overridable Property Label12 As Label

		' Token: 0x17006C7D RID: 27773
		' (get) Token: 0x060117C6 RID: 71622 RVA: 0x0007868F File Offset: 0x0007688F
		' (set) Token: 0x060117C7 RID: 71623 RVA: 0x00078699 File Offset: 0x00076899
		Friend Overridable Property Label22 As Label

		' Token: 0x17006C7E RID: 27774
		' (get) Token: 0x060117C8 RID: 71624 RVA: 0x000786A2 File Offset: 0x000768A2
		' (set) Token: 0x060117C9 RID: 71625 RVA: 0x000786AC File Offset: 0x000768AC
		Friend Overridable Property Label13 As Label

		' Token: 0x17006C7F RID: 27775
		' (get) Token: 0x060117CA RID: 71626 RVA: 0x000786B5 File Offset: 0x000768B5
		' (set) Token: 0x060117CB RID: 71627 RVA: 0x000786BF File Offset: 0x000768BF
		Friend Overridable Property txtProductName As TextBox

		' Token: 0x17006C80 RID: 27776
		' (get) Token: 0x060117CC RID: 71628 RVA: 0x000786C8 File Offset: 0x000768C8
		' (set) Token: 0x060117CD RID: 71629 RVA: 0x000786D2 File Offset: 0x000768D2
		Friend Overridable Property txtHSNCode As TextBox

		' Token: 0x17006C81 RID: 27777
		' (get) Token: 0x060117CE RID: 71630 RVA: 0x000786DB File Offset: 0x000768DB
		' (set) Token: 0x060117CF RID: 71631 RVA: 0x000786E5 File Offset: 0x000768E5
		Friend Overridable Property Label15 As Label

		' Token: 0x17006C82 RID: 27778
		' (get) Token: 0x060117D0 RID: 71632 RVA: 0x000786EE File Offset: 0x000768EE
		' (set) Token: 0x060117D1 RID: 71633 RVA: 0x000786F8 File Offset: 0x000768F8
		Friend Overridable Property Label18 As Label

		' Token: 0x17006C83 RID: 27779
		' (get) Token: 0x060117D2 RID: 71634 RVA: 0x00078701 File Offset: 0x00076901
		' (set) Token: 0x060117D3 RID: 71635 RVA: 0x0007870B File Offset: 0x0007690B
		Friend Overridable Property txtTotalAmount As TextBox

		' Token: 0x17006C84 RID: 27780
		' (get) Token: 0x060117D4 RID: 71636 RVA: 0x00078714 File Offset: 0x00076914
		' (set) Token: 0x060117D5 RID: 71637 RVA: 0x0007871E File Offset: 0x0007691E
		Friend Overridable Property Label4 As Label

		' Token: 0x17006C85 RID: 27781
		' (get) Token: 0x060117D6 RID: 71638 RVA: 0x00078727 File Offset: 0x00076927
		' (set) Token: 0x060117D7 RID: 71639 RVA: 0x00078731 File Offset: 0x00076931
		Friend Overridable Property txtTaxType As TextBox

		' Token: 0x17006C86 RID: 27782
		' (get) Token: 0x060117D8 RID: 71640 RVA: 0x0007873A File Offset: 0x0007693A
		' (set) Token: 0x060117D9 RID: 71641 RVA: 0x00078744 File Offset: 0x00076944
		Friend Overridable Property lblUnit As Label

		' Token: 0x17006C87 RID: 27783
		' (get) Token: 0x060117DA RID: 71642 RVA: 0x0007874D File Offset: 0x0007694D
		' (set) Token: 0x060117DB RID: 71643 RVA: 0x00A26F10 File Offset: 0x00A25110
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

		' Token: 0x17006C88 RID: 27784
		' (get) Token: 0x060117DC RID: 71644 RVA: 0x00078757 File Offset: 0x00076957
		' (set) Token: 0x060117DD RID: 71645 RVA: 0x00078761 File Offset: 0x00076961
		Friend Overridable Property Label8 As Label

		' Token: 0x17006C89 RID: 27785
		' (get) Token: 0x060117DE RID: 71646 RVA: 0x0007876A File Offset: 0x0007696A
		' (set) Token: 0x060117DF RID: 71647 RVA: 0x00A26F54 File Offset: 0x00A25154
		Private _txtOtherCharges As TextBox
		Friend Overridable Property txtOtherCharges As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtOtherCharges
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtOtherCharges_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtOtherCharges_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtOtherCharges_KeyDown
				Dim textBox As TextBox = Me._txtOtherCharges
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtOtherCharges = value
				textBox = Me._txtOtherCharges
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006C8A RID: 27786
		' (get) Token: 0x060117E0 RID: 71648 RVA: 0x00078774 File Offset: 0x00076974
		' (set) Token: 0x060117E1 RID: 71649 RVA: 0x00A26FD0 File Offset: 0x00A251D0
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

		' Token: 0x17006C8B RID: 27787
		' (get) Token: 0x060117E2 RID: 71650 RVA: 0x0007877E File Offset: 0x0007697E
		' (set) Token: 0x060117E3 RID: 71651 RVA: 0x00078788 File Offset: 0x00076988
		Friend Overridable Property Label9 As Label

		' Token: 0x17006C8C RID: 27788
		' (get) Token: 0x060117E4 RID: 71652 RVA: 0x00078791 File Offset: 0x00076991
		' (set) Token: 0x060117E5 RID: 71653 RVA: 0x0007879B File Offset: 0x0007699B
		Friend Overridable Property txtMRP As TextBox

		' Token: 0x17006C8D RID: 27789
		' (get) Token: 0x060117E6 RID: 71654 RVA: 0x000787A4 File Offset: 0x000769A4
		' (set) Token: 0x060117E7 RID: 71655 RVA: 0x00A2704C File Offset: 0x00A2524C
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

		' Token: 0x17006C8E RID: 27790
		' (get) Token: 0x060117E8 RID: 71656 RVA: 0x000787AE File Offset: 0x000769AE
		' (set) Token: 0x060117E9 RID: 71657 RVA: 0x000787B8 File Offset: 0x000769B8
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17006C8F RID: 27791
		' (get) Token: 0x060117EA RID: 71658 RVA: 0x000787C1 File Offset: 0x000769C1
		' (set) Token: 0x060117EB RID: 71659 RVA: 0x000787CB File Offset: 0x000769CB
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17006C90 RID: 27792
		' (get) Token: 0x060117EC RID: 71660 RVA: 0x000787D4 File Offset: 0x000769D4
		' (set) Token: 0x060117ED RID: 71661 RVA: 0x000787DE File Offset: 0x000769DE
		Friend Overridable Property Label19 As Label

		' Token: 0x17006C91 RID: 27793
		' (get) Token: 0x060117EE RID: 71662 RVA: 0x000787E7 File Offset: 0x000769E7
		' (set) Token: 0x060117EF RID: 71663 RVA: 0x00A27090 File Offset: 0x00A25290
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

		' Token: 0x17006C92 RID: 27794
		' (get) Token: 0x060117F0 RID: 71664 RVA: 0x000787F1 File Offset: 0x000769F1
		' (set) Token: 0x060117F1 RID: 71665 RVA: 0x000787FB File Offset: 0x000769FB
		Friend Overridable Property Label20 As Label

		' Token: 0x17006C93 RID: 27795
		' (get) Token: 0x060117F2 RID: 71666 RVA: 0x00078804 File Offset: 0x00076A04
		' (set) Token: 0x060117F3 RID: 71667 RVA: 0x0007880E File Offset: 0x00076A0E
		Friend Overridable Property Label48 As Label

		' Token: 0x17006C94 RID: 27796
		' (get) Token: 0x060117F4 RID: 71668 RVA: 0x00078817 File Offset: 0x00076A17
		' (set) Token: 0x060117F5 RID: 71669 RVA: 0x00A270D4 File Offset: 0x00A252D4
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

		' Token: 0x17006C95 RID: 27797
		' (get) Token: 0x060117F6 RID: 71670 RVA: 0x00078821 File Offset: 0x00076A21
		' (set) Token: 0x060117F7 RID: 71671 RVA: 0x00A27118 File Offset: 0x00A25318
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

		' Token: 0x17006C96 RID: 27798
		' (get) Token: 0x060117F8 RID: 71672 RVA: 0x0007882B File Offset: 0x00076A2B
		' (set) Token: 0x060117F9 RID: 71673 RVA: 0x00078835 File Offset: 0x00076A35
		Friend Overridable Property txtInvCode1 As TextBox

		' Token: 0x17006C97 RID: 27799
		' (get) Token: 0x060117FA RID: 71674 RVA: 0x0007883E File Offset: 0x00076A3E
		' (set) Token: 0x060117FB RID: 71675 RVA: 0x00078848 File Offset: 0x00076A48
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x17006C98 RID: 27800
		' (get) Token: 0x060117FC RID: 71676 RVA: 0x00078851 File Offset: 0x00076A51
		' (set) Token: 0x060117FD RID: 71677 RVA: 0x0007885B File Offset: 0x00076A5B
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x17006C99 RID: 27801
		' (get) Token: 0x060117FE RID: 71678 RVA: 0x00078864 File Offset: 0x00076A64
		' (set) Token: 0x060117FF RID: 71679 RVA: 0x0007886E File Offset: 0x00076A6E
		Friend Overridable Property txtSuffix As TextBox

		' Token: 0x17006C9A RID: 27802
		' (get) Token: 0x06011800 RID: 71680 RVA: 0x00078877 File Offset: 0x00076A77
		' (set) Token: 0x06011801 RID: 71681 RVA: 0x00A2715C File Offset: 0x00A2535C
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

		' Token: 0x17006C9B RID: 27803
		' (get) Token: 0x06011802 RID: 71682 RVA: 0x00078881 File Offset: 0x00076A81
		' (set) Token: 0x06011803 RID: 71683 RVA: 0x00A271A0 File Offset: 0x00A253A0
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

		' Token: 0x17006C9C RID: 27804
		' (get) Token: 0x06011804 RID: 71684 RVA: 0x0007888B File Offset: 0x00076A8B
		' (set) Token: 0x06011805 RID: 71685 RVA: 0x00A271E4 File Offset: 0x00A253E4
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

		' Token: 0x17006C9D RID: 27805
		' (get) Token: 0x06011806 RID: 71686 RVA: 0x00078895 File Offset: 0x00076A95
		' (set) Token: 0x06011807 RID: 71687 RVA: 0x00A27228 File Offset: 0x00A25428
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

		' Token: 0x17006C9E RID: 27806
		' (get) Token: 0x06011808 RID: 71688 RVA: 0x0007889F File Offset: 0x00076A9F
		' (set) Token: 0x06011809 RID: 71689 RVA: 0x00A2726C File Offset: 0x00A2546C
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

		' Token: 0x17006C9F RID: 27807
		' (get) Token: 0x0601180A RID: 71690 RVA: 0x000788A9 File Offset: 0x00076AA9
		' (set) Token: 0x0601180B RID: 71691 RVA: 0x000788B3 File Offset: 0x00076AB3
		Friend Overridable Property txtRsToWords As Label

		' Token: 0x17006CA0 RID: 27808
		' (get) Token: 0x0601180C RID: 71692 RVA: 0x000788BC File Offset: 0x00076ABC
		' (set) Token: 0x0601180D RID: 71693 RVA: 0x00A272B0 File Offset: 0x00A254B0
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

		' Token: 0x17006CA1 RID: 27809
		' (get) Token: 0x0601180E RID: 71694 RVA: 0x000788C6 File Offset: 0x00076AC6
		' (set) Token: 0x0601180F RID: 71695 RVA: 0x00A272F4 File Offset: 0x00A254F4
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

		' Token: 0x17006CA2 RID: 27810
		' (get) Token: 0x06011810 RID: 71696 RVA: 0x000788D0 File Offset: 0x00076AD0
		' (set) Token: 0x06011811 RID: 71697 RVA: 0x000788DA File Offset: 0x00076ADA
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x17006CA3 RID: 27811
		' (get) Token: 0x06011812 RID: 71698 RVA: 0x000788E3 File Offset: 0x00076AE3
		' (set) Token: 0x06011813 RID: 71699 RVA: 0x00A27338 File Offset: 0x00A25538
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

		' Token: 0x17006CA4 RID: 27812
		' (get) Token: 0x06011814 RID: 71700 RVA: 0x000788ED File Offset: 0x00076AED
		' (set) Token: 0x06011815 RID: 71701 RVA: 0x000788F7 File Offset: 0x00076AF7
		Friend Overridable Property F2 As TextBox

		' Token: 0x17006CA5 RID: 27813
		' (get) Token: 0x06011816 RID: 71702 RVA: 0x00078900 File Offset: 0x00076B00
		' (set) Token: 0x06011817 RID: 71703 RVA: 0x0007890A File Offset: 0x00076B0A
		Friend Overridable Property F1 As TextBox

		' Token: 0x17006CA6 RID: 27814
		' (get) Token: 0x06011818 RID: 71704 RVA: 0x00078913 File Offset: 0x00076B13
		' (set) Token: 0x06011819 RID: 71705 RVA: 0x0007891D File Offset: 0x00076B1D
		Friend Overridable Property Label6 As Label

		' Token: 0x17006CA7 RID: 27815
		' (get) Token: 0x0601181A RID: 71706 RVA: 0x00078926 File Offset: 0x00076B26
		' (set) Token: 0x0601181B RID: 71707 RVA: 0x00078930 File Offset: 0x00076B30
		Friend Overridable Property txtTaxableAmt As TextBox

		' Token: 0x17006CA8 RID: 27816
		' (get) Token: 0x0601181C RID: 71708 RVA: 0x00078939 File Offset: 0x00076B39
		' (set) Token: 0x0601181D RID: 71709 RVA: 0x00078943 File Offset: 0x00076B43
		Friend Overridable Property txtGSTnonGST As TextBox

		' Token: 0x17006CA9 RID: 27817
		' (get) Token: 0x0601181E RID: 71710 RVA: 0x0007894C File Offset: 0x00076B4C
		' (set) Token: 0x0601181F RID: 71711 RVA: 0x00078956 File Offset: 0x00076B56
		Friend Overridable Property Label24 As Label

		' Token: 0x17006CAA RID: 27818
		' (get) Token: 0x06011820 RID: 71712 RVA: 0x0007895F File Offset: 0x00076B5F
		' (set) Token: 0x06011821 RID: 71713 RVA: 0x00078969 File Offset: 0x00076B69
		Friend Overridable Property DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn

		' Token: 0x17006CAB RID: 27819
		' (get) Token: 0x06011822 RID: 71714 RVA: 0x00078972 File Offset: 0x00076B72
		' (set) Token: 0x06011823 RID: 71715 RVA: 0x0007897C File Offset: 0x00076B7C
		Friend Overridable Property DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn

		' Token: 0x17006CAC RID: 27820
		' (get) Token: 0x06011824 RID: 71716 RVA: 0x00078985 File Offset: 0x00076B85
		' (set) Token: 0x06011825 RID: 71717 RVA: 0x0007898F File Offset: 0x00076B8F
		Friend Overridable Property DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn

		' Token: 0x17006CAD RID: 27821
		' (get) Token: 0x06011826 RID: 71718 RVA: 0x00078998 File Offset: 0x00076B98
		' (set) Token: 0x06011827 RID: 71719 RVA: 0x000789A2 File Offset: 0x00076BA2
		Friend Overridable Property DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn

		' Token: 0x17006CAE RID: 27822
		' (get) Token: 0x06011828 RID: 71720 RVA: 0x000789AB File Offset: 0x00076BAB
		' (set) Token: 0x06011829 RID: 71721 RVA: 0x000789B5 File Offset: 0x00076BB5
		Friend Overridable Property DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn

		' Token: 0x17006CAF RID: 27823
		' (get) Token: 0x0601182A RID: 71722 RVA: 0x000789BE File Offset: 0x00076BBE
		' (set) Token: 0x0601182B RID: 71723 RVA: 0x000789C8 File Offset: 0x00076BC8
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006CB0 RID: 27824
		' (get) Token: 0x0601182C RID: 71724 RVA: 0x000789D1 File Offset: 0x00076BD1
		' (set) Token: 0x0601182D RID: 71725 RVA: 0x000789DB File Offset: 0x00076BDB
		Friend Overridable Property DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn

		' Token: 0x17006CB1 RID: 27825
		' (get) Token: 0x0601182E RID: 71726 RVA: 0x000789E4 File Offset: 0x00076BE4
		' (set) Token: 0x0601182F RID: 71727 RVA: 0x000789EE File Offset: 0x00076BEE
		Friend Overridable Property DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn

		' Token: 0x17006CB2 RID: 27826
		' (get) Token: 0x06011830 RID: 71728 RVA: 0x000789F7 File Offset: 0x00076BF7
		' (set) Token: 0x06011831 RID: 71729 RVA: 0x00078A01 File Offset: 0x00076C01
		Friend Overridable Property DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn

		' Token: 0x17006CB3 RID: 27827
		' (get) Token: 0x06011832 RID: 71730 RVA: 0x00078A0A File Offset: 0x00076C0A
		' (set) Token: 0x06011833 RID: 71731 RVA: 0x00078A14 File Offset: 0x00076C14
		Friend Overridable Property DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn

		' Token: 0x17006CB4 RID: 27828
		' (get) Token: 0x06011834 RID: 71732 RVA: 0x00078A1D File Offset: 0x00076C1D
		' (set) Token: 0x06011835 RID: 71733 RVA: 0x00078A27 File Offset: 0x00076C27
		Friend Overridable Property DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn

		' Token: 0x17006CB5 RID: 27829
		' (get) Token: 0x06011836 RID: 71734 RVA: 0x00078A30 File Offset: 0x00076C30
		' (set) Token: 0x06011837 RID: 71735 RVA: 0x00078A3A File Offset: 0x00076C3A
		Friend Overridable Property DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn

		' Token: 0x17006CB6 RID: 27830
		' (get) Token: 0x06011838 RID: 71736 RVA: 0x00078A43 File Offset: 0x00076C43
		' (set) Token: 0x06011839 RID: 71737 RVA: 0x00078A4D File Offset: 0x00076C4D
		Friend Overridable Property DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn

		' Token: 0x17006CB7 RID: 27831
		' (get) Token: 0x0601183A RID: 71738 RVA: 0x00078A56 File Offset: 0x00076C56
		' (set) Token: 0x0601183B RID: 71739 RVA: 0x00078A60 File Offset: 0x00076C60
		Friend Overridable Property DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn

		' Token: 0x17006CB8 RID: 27832
		' (get) Token: 0x0601183C RID: 71740 RVA: 0x00078A69 File Offset: 0x00076C69
		' (set) Token: 0x0601183D RID: 71741 RVA: 0x00078A73 File Offset: 0x00076C73
		Friend Overridable Property DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn

		' Token: 0x17006CB9 RID: 27833
		' (get) Token: 0x0601183E RID: 71742 RVA: 0x00078A7C File Offset: 0x00076C7C
		' (set) Token: 0x0601183F RID: 71743 RVA: 0x00078A86 File Offset: 0x00076C86
		Friend Overridable Property DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn

		' Token: 0x17006CBA RID: 27834
		' (get) Token: 0x06011840 RID: 71744 RVA: 0x00078A8F File Offset: 0x00076C8F
		' (set) Token: 0x06011841 RID: 71745 RVA: 0x00078A99 File Offset: 0x00076C99
		Friend Overridable Property DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn

		' Token: 0x17006CBB RID: 27835
		' (get) Token: 0x06011842 RID: 71746 RVA: 0x00078AA2 File Offset: 0x00076CA2
		' (set) Token: 0x06011843 RID: 71747 RVA: 0x00078AAC File Offset: 0x00076CAC
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006CBC RID: 27836
		' (get) Token: 0x06011844 RID: 71748 RVA: 0x00078AB5 File Offset: 0x00076CB5
		' (set) Token: 0x06011845 RID: 71749 RVA: 0x00078ABF File Offset: 0x00076CBF
		Friend Overridable Property DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn

		' Token: 0x17006CBD RID: 27837
		' (get) Token: 0x06011846 RID: 71750 RVA: 0x00078AC8 File Offset: 0x00076CC8
		' (set) Token: 0x06011847 RID: 71751 RVA: 0x00078AD2 File Offset: 0x00076CD2
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17006CBE RID: 27838
		' (get) Token: 0x06011848 RID: 71752 RVA: 0x00078ADB File Offset: 0x00076CDB
		' (set) Token: 0x06011849 RID: 71753 RVA: 0x00078AE5 File Offset: 0x00076CE5
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17006CBF RID: 27839
		' (get) Token: 0x0601184A RID: 71754 RVA: 0x00078AEE File Offset: 0x00076CEE
		' (set) Token: 0x0601184B RID: 71755 RVA: 0x00078AF8 File Offset: 0x00076CF8
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x17006CC0 RID: 27840
		' (get) Token: 0x0601184C RID: 71756 RVA: 0x00078B01 File Offset: 0x00076D01
		' (set) Token: 0x0601184D RID: 71757 RVA: 0x00078B0B File Offset: 0x00076D0B
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006CC1 RID: 27841
		' (get) Token: 0x0601184E RID: 71758 RVA: 0x00078B14 File Offset: 0x00076D14
		' (set) Token: 0x0601184F RID: 71759 RVA: 0x00078B1E File Offset: 0x00076D1E
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17006CC2 RID: 27842
		' (get) Token: 0x06011850 RID: 71760 RVA: 0x00078B27 File Offset: 0x00076D27
		' (set) Token: 0x06011851 RID: 71761 RVA: 0x00078B31 File Offset: 0x00076D31
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17006CC3 RID: 27843
		' (get) Token: 0x06011852 RID: 71762 RVA: 0x00078B3A File Offset: 0x00076D3A
		' (set) Token: 0x06011853 RID: 71763 RVA: 0x00078B44 File Offset: 0x00076D44
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17006CC4 RID: 27844
		' (get) Token: 0x06011854 RID: 71764 RVA: 0x00078B4D File Offset: 0x00076D4D
		' (set) Token: 0x06011855 RID: 71765 RVA: 0x00078B57 File Offset: 0x00076D57
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006CC5 RID: 27845
		' (get) Token: 0x06011856 RID: 71766 RVA: 0x00078B60 File Offset: 0x00076D60
		' (set) Token: 0x06011857 RID: 71767 RVA: 0x00078B6A File Offset: 0x00076D6A
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x17006CC6 RID: 27846
		' (get) Token: 0x06011858 RID: 71768 RVA: 0x00078B73 File Offset: 0x00076D73
		' (set) Token: 0x06011859 RID: 71769 RVA: 0x00078B7D File Offset: 0x00076D7D
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17006CC7 RID: 27847
		' (get) Token: 0x0601185A RID: 71770 RVA: 0x00078B86 File Offset: 0x00076D86
		' (set) Token: 0x0601185B RID: 71771 RVA: 0x00078B90 File Offset: 0x00076D90
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17006CC8 RID: 27848
		' (get) Token: 0x0601185C RID: 71772 RVA: 0x00078B99 File Offset: 0x00076D99
		' (set) Token: 0x0601185D RID: 71773 RVA: 0x00078BA3 File Offset: 0x00076DA3
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17006CC9 RID: 27849
		' (get) Token: 0x0601185E RID: 71774 RVA: 0x00078BAC File Offset: 0x00076DAC
		' (set) Token: 0x0601185F RID: 71775 RVA: 0x00078BB6 File Offset: 0x00076DB6
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x17006CCA RID: 27850
		' (get) Token: 0x06011860 RID: 71776 RVA: 0x00078BBF File Offset: 0x00076DBF
		' (set) Token: 0x06011861 RID: 71777 RVA: 0x00078BC9 File Offset: 0x00076DC9
		Friend Overridable Property DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn

		' Token: 0x17006CCB RID: 27851
		' (get) Token: 0x06011862 RID: 71778 RVA: 0x00078BD2 File Offset: 0x00076DD2
		' (set) Token: 0x06011863 RID: 71779 RVA: 0x00078BDC File Offset: 0x00076DDC
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17006CCC RID: 27852
		' (get) Token: 0x06011864 RID: 71780 RVA: 0x00078BE5 File Offset: 0x00076DE5
		' (set) Token: 0x06011865 RID: 71781 RVA: 0x00078BEF File Offset: 0x00076DEF
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17006CCD RID: 27853
		' (get) Token: 0x06011866 RID: 71782 RVA: 0x00078BF8 File Offset: 0x00076DF8
		' (set) Token: 0x06011867 RID: 71783 RVA: 0x00078C02 File Offset: 0x00076E02
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17006CCE RID: 27854
		' (get) Token: 0x06011868 RID: 71784 RVA: 0x00078C0B File Offset: 0x00076E0B
		' (set) Token: 0x06011869 RID: 71785 RVA: 0x00078C15 File Offset: 0x00076E15
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x17006CCF RID: 27855
		' (get) Token: 0x0601186A RID: 71786 RVA: 0x00078C1E File Offset: 0x00076E1E
		' (set) Token: 0x0601186B RID: 71787 RVA: 0x00078C28 File Offset: 0x00076E28
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17006CD0 RID: 27856
		' (get) Token: 0x0601186C RID: 71788 RVA: 0x00078C31 File Offset: 0x00076E31
		' (set) Token: 0x0601186D RID: 71789 RVA: 0x00078C3B File Offset: 0x00076E3B
		Friend Overridable Property DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn

		' Token: 0x17006CD1 RID: 27857
		' (get) Token: 0x0601186E RID: 71790 RVA: 0x00078C44 File Offset: 0x00076E44
		' (set) Token: 0x0601186F RID: 71791 RVA: 0x00078C4E File Offset: 0x00076E4E
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17006CD2 RID: 27858
		' (get) Token: 0x06011870 RID: 71792 RVA: 0x00078C57 File Offset: 0x00076E57
		' (set) Token: 0x06011871 RID: 71793 RVA: 0x00078C61 File Offset: 0x00076E61
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17006CD3 RID: 27859
		' (get) Token: 0x06011872 RID: 71794 RVA: 0x00078C6A File Offset: 0x00076E6A
		' (set) Token: 0x06011873 RID: 71795 RVA: 0x00078C74 File Offset: 0x00076E74
		Friend Overridable Property lblCPhone As Label

		' Token: 0x17006CD4 RID: 27860
		' (get) Token: 0x06011874 RID: 71796 RVA: 0x00078C7D File Offset: 0x00076E7D
		' (set) Token: 0x06011875 RID: 71797 RVA: 0x00A2737C File Offset: 0x00A2557C
		Private _BtnGetData As GelButton
		Friend Overridable Property BtnGetData As GelButton
			<CompilerGenerated()>
			Get
				Return Me._BtnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.BtnGetData_Click
				Dim gelButton As GelButton = Me._BtnGetData
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._BtnGetData = value
				gelButton = Me._BtnGetData
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006CD5 RID: 27861
		' (get) Token: 0x06011876 RID: 71798 RVA: 0x00078C87 File Offset: 0x00076E87
		' (set) Token: 0x06011877 RID: 71799 RVA: 0x00A273C0 File Offset: 0x00A255C0
		Private _btnPrint As GelButton
		Friend Overridable Property btnPrint As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnPrint
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.brnPrint_Click
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

		' Token: 0x17006CD6 RID: 27862
		' (get) Token: 0x06011878 RID: 71800 RVA: 0x00078C91 File Offset: 0x00076E91
		' (set) Token: 0x06011879 RID: 71801 RVA: 0x00A27404 File Offset: 0x00A25604
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

		' Token: 0x17006CD7 RID: 27863
		' (get) Token: 0x0601187A RID: 71802 RVA: 0x00078C9B File Offset: 0x00076E9B
		' (set) Token: 0x0601187B RID: 71803 RVA: 0x00A27448 File Offset: 0x00A25648
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

		' Token: 0x17006CD8 RID: 27864
		' (get) Token: 0x0601187C RID: 71804 RVA: 0x00078CA5 File Offset: 0x00076EA5
		' (set) Token: 0x0601187D RID: 71805 RVA: 0x00A2748C File Offset: 0x00A2568C
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

		' Token: 0x17006CD9 RID: 27865
		' (get) Token: 0x0601187E RID: 71806 RVA: 0x00078CAF File Offset: 0x00076EAF
		' (set) Token: 0x0601187F RID: 71807 RVA: 0x00078CB9 File Offset: 0x00076EB9
		Friend Overridable Property TextBox6 As TextBox

		' Token: 0x17006CDA RID: 27866
		' (get) Token: 0x06011880 RID: 71808 RVA: 0x00078CC2 File Offset: 0x00076EC2
		' (set) Token: 0x06011881 RID: 71809 RVA: 0x00078CCC File Offset: 0x00076ECC
		Friend Overridable Property TextBox5 As TextBox

		' Token: 0x17006CDB RID: 27867
		' (get) Token: 0x06011882 RID: 71810 RVA: 0x00078CD5 File Offset: 0x00076ED5
		' (set) Token: 0x06011883 RID: 71811 RVA: 0x00078CDF File Offset: 0x00076EDF
		Friend Overridable Property TextBox4 As TextBox

		' Token: 0x17006CDC RID: 27868
		' (get) Token: 0x06011884 RID: 71812 RVA: 0x00078CE8 File Offset: 0x00076EE8
		' (set) Token: 0x06011885 RID: 71813 RVA: 0x00078CF2 File Offset: 0x00076EF2
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x17006CDD RID: 27869
		' (get) Token: 0x06011886 RID: 71814 RVA: 0x00078CFB File Offset: 0x00076EFB
		' (set) Token: 0x06011887 RID: 71815 RVA: 0x00078D05 File Offset: 0x00076F05
		Friend Overridable Property DataGridView5F As DataGridView

		' Token: 0x17006CDE RID: 27870
		' (get) Token: 0x06011888 RID: 71816 RVA: 0x00078D0E File Offset: 0x00076F0E
		' (set) Token: 0x06011889 RID: 71817 RVA: 0x00078D18 File Offset: 0x00076F18
		Friend Overridable Property PID1 As DataGridViewTextBoxColumn

		' Token: 0x17006CDF RID: 27871
		' (get) Token: 0x0601188A RID: 71818 RVA: 0x00078D21 File Offset: 0x00076F21
		' (set) Token: 0x0601188B RID: 71819 RVA: 0x00078D2B File Offset: 0x00076F2B
		Friend Overridable Property Productcode1 As DataGridViewTextBoxColumn

		' Token: 0x17006CE0 RID: 27872
		' (get) Token: 0x0601188C RID: 71820 RVA: 0x00078D34 File Offset: 0x00076F34
		' (set) Token: 0x0601188D RID: 71821 RVA: 0x00078D3E File Offset: 0x00076F3E
		Friend Overridable Property Productname1 As DataGridViewTextBoxColumn

		' Token: 0x17006CE1 RID: 27873
		' (get) Token: 0x0601188E RID: 71822 RVA: 0x00078D47 File Offset: 0x00076F47
		' (set) Token: 0x0601188F RID: 71823 RVA: 0x00078D51 File Offset: 0x00076F51
		Friend Overridable Property Barcode1 As DataGridViewTextBoxColumn

		' Token: 0x17006CE2 RID: 27874
		' (get) Token: 0x06011890 RID: 71824 RVA: 0x00078D5A File Offset: 0x00076F5A
		' (set) Token: 0x06011891 RID: 71825 RVA: 0x00078D64 File Offset: 0x00076F64
		Friend Overridable Property Serial_no1 As DataGridViewTextBoxColumn

		' Token: 0x17006CE3 RID: 27875
		' (get) Token: 0x06011892 RID: 71826 RVA: 0x00078D6D File Offset: 0x00076F6D
		' (set) Token: 0x06011893 RID: 71827 RVA: 0x00A274D0 File Offset: 0x00A256D0
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

		' Token: 0x17006CE4 RID: 27876
		' (get) Token: 0x06011894 RID: 71828 RVA: 0x00078D77 File Offset: 0x00076F77
		' (set) Token: 0x06011895 RID: 71829 RVA: 0x00078D81 File Offset: 0x00076F81
		Friend Overridable Property chkSerialno As DataGridViewCheckBoxColumn

		' Token: 0x17006CE5 RID: 27877
		' (get) Token: 0x06011896 RID: 71830 RVA: 0x00078D8A File Offset: 0x00076F8A
		' (set) Token: 0x06011897 RID: 71831 RVA: 0x00078D94 File Offset: 0x00076F94
		Friend Overridable Property PID As DataGridViewTextBoxColumn

		' Token: 0x17006CE6 RID: 27878
		' (get) Token: 0x06011898 RID: 71832 RVA: 0x00078D9D File Offset: 0x00076F9D
		' (set) Token: 0x06011899 RID: 71833 RVA: 0x00078DA7 File Offset: 0x00076FA7
		Friend Overridable Property Productcode As DataGridViewTextBoxColumn

		' Token: 0x17006CE7 RID: 27879
		' (get) Token: 0x0601189A RID: 71834 RVA: 0x00078DB0 File Offset: 0x00076FB0
		' (set) Token: 0x0601189B RID: 71835 RVA: 0x00078DBA File Offset: 0x00076FBA
		Friend Overridable Property Productname As DataGridViewTextBoxColumn

		' Token: 0x17006CE8 RID: 27880
		' (get) Token: 0x0601189C RID: 71836 RVA: 0x00078DC3 File Offset: 0x00076FC3
		' (set) Token: 0x0601189D RID: 71837 RVA: 0x00078DCD File Offset: 0x00076FCD
		Friend Overridable Property Barcode As DataGridViewTextBoxColumn

		' Token: 0x17006CE9 RID: 27881
		' (get) Token: 0x0601189E RID: 71838 RVA: 0x00078DD6 File Offset: 0x00076FD6
		' (set) Token: 0x0601189F RID: 71839 RVA: 0x00078DE0 File Offset: 0x00076FE0
		Friend Overridable Property Serial_no As DataGridViewTextBoxColumn

		' Token: 0x17006CEA RID: 27882
		' (get) Token: 0x060118A0 RID: 71840 RVA: 0x00078DE9 File Offset: 0x00076FE9
		' (set) Token: 0x060118A1 RID: 71841 RVA: 0x00078DF3 File Offset: 0x00076FF3
		Friend Overridable Property CompanyAddress As TextBox

		' Token: 0x17006CEB RID: 27883
		' (get) Token: 0x060118A2 RID: 71842 RVA: 0x00078DFC File Offset: 0x00076FFC
		' (set) Token: 0x060118A3 RID: 71843 RVA: 0x00078E06 File Offset: 0x00077006
		Friend Overridable Property compgstin As TextBox

		' Token: 0x17006CEC RID: 27884
		' (get) Token: 0x060118A4 RID: 71844 RVA: 0x00078E0F File Offset: 0x0007700F
		' (set) Token: 0x060118A5 RID: 71845 RVA: 0x00078E19 File Offset: 0x00077019
		Friend Overridable Property txtcompname As TextBox

		' Token: 0x17006CED RID: 27885
		' (get) Token: 0x060118A6 RID: 71846 RVA: 0x00078E22 File Offset: 0x00077022
		' (set) Token: 0x060118A7 RID: 71847 RVA: 0x00078E2C File Offset: 0x0007702C
		Friend Overridable Property txtCompanyState As TextBox

		' Token: 0x17006CEE RID: 27886
		' (get) Token: 0x060118A8 RID: 71848 RVA: 0x00078E35 File Offset: 0x00077035
		' (set) Token: 0x060118A9 RID: 71849 RVA: 0x00078E3F File Offset: 0x0007703F
		Friend Overridable Property CompanyContact As TextBox

		' Token: 0x17006CEF RID: 27887
		' (get) Token: 0x060118AA RID: 71850 RVA: 0x00078E48 File Offset: 0x00077048
		' (set) Token: 0x060118AB RID: 71851 RVA: 0x00078E52 File Offset: 0x00077052
		Friend Overridable Property CompanyEMail As TextBox

		' Token: 0x17006CF0 RID: 27888
		' (get) Token: 0x060118AC RID: 71852 RVA: 0x00078E5B File Offset: 0x0007705B
		' (set) Token: 0x060118AD RID: 71853 RVA: 0x00078E65 File Offset: 0x00077065
		Friend Overridable Property Label26 As Label

		' Token: 0x17006CF1 RID: 27889
		' (get) Token: 0x060118AE RID: 71854 RVA: 0x00078E6E File Offset: 0x0007706E
		' (set) Token: 0x060118AF RID: 71855 RVA: 0x00078E78 File Offset: 0x00077078
		Friend Overridable Property Label27 As Label

		' Token: 0x060118B0 RID: 71856 RVA: 0x00A27514 File Offset: 0x00A25714
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 PR_ID FROM PurchaseReturn ORDER BY PR_ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("PR_ID"))
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

		' Token: 0x060118B1 RID: 71857 RVA: 0x00A27680 File Offset: 0x00A25880
		Private Function GenerateIDSr() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP 1 ID FROM SrPurReturn ORDER BY ID DESC", ModCommonClasses.con)
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

		' Token: 0x060118B2 RID: 71858 RVA: 0x00A277EC File Offset: 0x00A259EC
		Public Sub Reset()
			Me.txtPRNO.Text = ""
			Me.txtPRID.Text = ""
			Me.TextBox2.Text = ""
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.dtpPurchaseDate.Value = DateAndTime.Today
			Me.txtPurchaseID.Text = ""
			Me.txtPurchaseInvoiceNo.Text = ""
			Me.txtCGST.Text = "0.00"
			Me.txtSGST.Text = "0.00"
			Me.txtIGST.Text = "0.00"
			Me.txtCESS.Text = "0.00"
			Me.txtSubTotal.Text = ""
			Me.txtTotal.Text = "0.00"
			Me.txtSupplierID.Text = ""
			Me.txtSupplierName.Text = ""
			Me.txtSup_ID.Text = ""
			Me.txtGrandTotal.Text = ""
			Me.txtRoundOff.Text = "0.00"
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.DataGridView1.Enabled = True
			Me.btnAdd.Enabled = True
			Me.pnlCalc.Enabled = True
			Me.btnRemove.Enabled = False
			Me.DataGridView1.Rows.Clear()
			Me.DataGridView2.Rows.Clear()
			Me.btnSelection.Enabled = True
			Me.btnPrint.Enabled = False
			Me.txtGSTnonGST.Text = ""
			Me.lblSet.Text = ""
			Me.txtFreightCharges.Text = "0.00"
			Me.txtOtherCharges.Text = "0.00"
			Me.cmbPmtMode.SelectedIndex = -1
			Me.cmbBSundry.Text = "Bill Sundry"
			Me.Clear()
			Me.auto()
			Me.dtpPRDate.Focus()
			Me.cmbNP.SelectedIndex = -1
			Me.txtGSTnonGST.Text = ""
			Me.TextBox3.Text = ""
			Me.TextBox4.Text = ""
			Me.TextBox5.Text = ""
			Me.TextBox6.Text = ""
			Me.DataGridView5.Rows.Clear()
			Me.DataGridView5F.Rows.Clear()
			Me.DataGridView5.Visible = False
			Me.DataGridView5F.Visible = False
		End Sub

		' Token: 0x060118B3 RID: 71859 RVA: 0x00A27AD0 File Offset: 0x00A25CD0
		Public Sub Compute()
			Dim flag As Boolean = Operators.CompareString(Me.TextBox2.Text, "No", False) = 0
			If flag Then
				Me.GridCalc()
				Me.num1 = Conversion.Val(Me.txtSubTotal.Text) + Conversion.Val(Me.txtCGST.Text) + Conversion.Val(Me.txtSGST.Text) + Conversion.Val(Me.txtIGST.Text) + Conversion.Val(Me.txtCESS.Text) + Conversion.Val(Me.txtFreightCharges.Text) - Conversion.Val(Me.txtOtherCharges.Text)
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
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.TextBox2.Text, "Yes", False) = 0
				If flag2 Then
					Me.GridCalc()
					Me.num1 = Conversion.Val(Me.txtSubTotal.Text) + Conversion.Val(Me.txtFreightCharges.Text) - Conversion.Val(Me.txtOtherCharges.Text)
					Me.num1 = Math.Round(Me.num1, 2)
					Me.txtTotal.Text = Conversions.ToString(Me.num1)
					Me.num2 = Math.Round(Me.num1, 0)
					Dim checked2 As Boolean = Me.CheckBox1.Checked
					If checked2 Then
						Me.num3 = Me.num2 - Me.num1
					Else
						Me.num3 = 0.0
					End If
					Me.num3 = Math.Round(Me.num3, 2)
					Me.txtRoundOff.Text = Conversions.ToString(Me.num3)
					Me.num4 = Conversion.Val(Me.txtTotal.Text) + Conversion.Val(Me.txtRoundOff.Text)
					Me.num4 = Math.Round(Me.num4, 2)
					Me.txtGrandTotal.Text = Conversions.ToString(Me.num4)
				End If
			End If
		End Sub

		' Token: 0x060118B4 RID: 71860 RVA: 0x00A27DBC File Offset: 0x00A25FBC
		Private Sub Invoicecode()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select RTRIM(c3),RTRIM(c13) from Invcode"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtInvCode1.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtSuffix.Text = ModCommonClasses.rdr.GetValue(1).ToString()
				Else
					Me.txtInvCode1.Text = "PR"
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
					Me.txtInvCode1.Text = "PR"
				End If
				Dim flag5 As Boolean = Operators.CompareString(Me.txtSuffix.Text, "", False) = 0
				If flag5 Then
					Me.txtSuffix.Text = Me.F1.Text + "/" + Me.F2.Text
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060118B5 RID: 71861 RVA: 0x00A27F94 File Offset: 0x00A26194
		Public Sub auto()
			Try
				Me.txtPRID.Text = Me.GenerateID()
				Me.ntid = Me.GenerateIDSr()
				Me.txtPRNO.Text = String.Concat(New String() { Me.txtInvCode1.Text, "-", Me.GenerateIDSr(), "-", Me.txtSuffix.Text })
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060118B6 RID: 71862 RVA: 0x00A28044 File Offset: 0x00A26244
		Private Sub btnSelection_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseRecord.lblSet.Text = "PR"
			MyProject.Forms.frmPurchaseRecord.Reset()
			MyProject.Forms.frmPurchaseRecord.ShowDialog()
			MyProject.Forms.frmPurchaseRecord.Dispose()
		End Sub

		' Token: 0x060118B7 RID: 71863 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnClose_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x060118B8 RID: 71864 RVA: 0x00A2809C File Offset: 0x00A2629C
		Public Sub GridCalc()
			Dim num As Double = 0.0
			Dim num2 As Double = 0.0
			Dim num3 As Double = 0.0
			Dim num4 As Double = 0.0
			Try
				For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					num = Conversions.ToDouble(Operators.AddObject(num, dataGridViewRow.Cells(10).Value))
					num2 = Conversions.ToDouble(Operators.AddObject(num2, dataGridViewRow.Cells(12).Value))
					num3 = Conversions.ToDouble(Operators.AddObject(num3, dataGridViewRow.Cells(14).Value))
					num4 = Conversions.ToDouble(Operators.AddObject(num4, dataGridViewRow.Cells(16).Value))
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

		' Token: 0x060118B9 RID: 71865 RVA: 0x00A2822C File Offset: 0x00A2642C
		Public Function SubTotal() As Double
			Dim num As Double = 0.0
			Try
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(20).Value))
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

		' Token: 0x060118BA RID: 71866 RVA: 0x00A282EC File Offset: 0x00A264EC
		Public Sub Clear()
			Me.txtHSNCode.Text = ""
			Me.txtProductName.Text = ""
			Me.txtTaxType.Text = ""
			Me.txtTaxableAmt.Text = ""
			Me.txtQty.Text = ""
			Me.txtPrice.Text = ""
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
			Me.txtMRP.Text = ""
			Me.txtTotalAmount.Text = ""
			Me.txtBarcode.Text = ""
			Me.txtReturnQty.Text = ""
			Me.btnAdd.Enabled = True
			Me.btnRemove.Enabled = False
			Me.lblUnit.Text = "Unit"
			Me.txtReturnQty.Focus()
		End Sub

		' Token: 0x060118BB RID: 71867 RVA: 0x00A28488 File Offset: 0x00A26688
		Private Sub btnAdd_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = Operators.CompareString(Me.txtProductName.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please retrieve product info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.DataGridView2.Focus()
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
									Try
										For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
											Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
											Dim flag6 As Boolean = Operators.ConditionalCompareObjectEqual(Me.txtBarcode.Text, dataGridViewRow.Cells(3).Value, False)
											If flag6 Then
												MessageBox.Show("Same barcode already added in grid", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Me.txtBarcode.Focus()
												Return
											End If
											Dim flag7 As Boolean = Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(Me.txtBarcode.Text, dataGridViewRow.Cells(3).Value, False), Operators.CompareObjectEqual(Me.txtProductID.Text, dataGridViewRow.Cells(0).Value, False)))
											If flag7 Then
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
										Dim text As String = "SELECT a.productid AS PID, RTRIM(b.ProductCode) AS Productcode, RTRIM(b.ProductName) AS ProductName, a.barcode AS Barcode, a.serialno1" & vbCrLf & "                              FROM tbl_product_serial_final a" & vbCrLf & "                              INNER JOIN product b ON a.productid = b.pid where a.invoice_no=@d1 and a.barcode=@d2"
										ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtPurchaseInvoiceNo.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcode.Text)
										ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
										Me.DataGridView5.Rows.Clear()
										Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
										If flag8 Then
											Dim text2 As String = Me.txtBarcode.Text
											Dim num As Integer = 0
											Try
												For Each obj2 As Object In CType(Me.DataGridView5F.Rows, IEnumerable)
													Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
													Dim flag9 As Boolean = dataGridViewRow2.Cells("Barcode1").Value IsNot Nothing AndAlso Operators.CompareString(dataGridViewRow2.Cells("Barcode1").Value.ToString(), text2, False) = 0
													If flag9 Then
														num += 1
													End If
												Next
											Finally
												Dim enumerator2 As IEnumerator
												If TypeOf enumerator2 Is IDisposable Then
													TryCast(enumerator2, IDisposable).Dispose()
												End If
											End Try
											Dim flag10 As Boolean = CDbl(num) <> Conversion.Val(Me.txtReturnQty.Text)
											If flag10 Then
												MessageBox.Show(String.Format("Quantity mismatch! Found: {0}, Expected: {1}.", Conversion.Val(Me.txtReturnQty.Text), num), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
												Return
											End If
											Dim flag11 As Boolean = ModCommonClasses.rdr IsNot Nothing
											If flag11 Then
												ModCommonClasses.rdr.Close()
											End If
										End If
										ModCommonClasses.con.Close()
									Catch ex As Exception
										MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									End Try
									Dim num2 As Double = Conversions.ToDouble(Strings.Format(Math.Round(Conversion.Val(Me.txtTaxableAmt.Text) / Conversion.Val(Me.txtQty.Text) * Conversion.Val(Me.txtReturnQty.Text), 2), "0.00"))
									Me.DataGridView1.Rows.Add(New Object() { Me.txtProductID.Text, Me.txtHSNCode.Text, Me.txtProductName.Text, Me.txtBarcode.Text, Conversion.Val(Me.txtQty.Text), Conversion.Val(Me.txtMRP.Text), Conversion.Val(Me.txtPrice.Text), Conversion.Val(Me.txtDiscPer.Text), Conversion.Val(Me.txtDisc.Text), Conversion.Val(Me.txtCGSTPer.Text), Conversion.Val(Me.txtCGSTAmt.Text), Conversion.Val(Me.txtSGSTPer.Text), Conversion.Val(Me.txtSGSTAmt.Text), Conversion.Val(Me.txtIGSTPer.Text), Conversion.Val(Me.txtIGSTAmt.Text), Conversion.Val(Me.txtCESSPer.Text), Conversion.Val(Me.txtCESSAmt.Text), Conversion.Val(Me.txtReturnQty.Text), Conversion.Val(Me.txtTotalAmount.Text), Me.txtTaxType.Text, num2 })
									Dim num3 As Double = Me.SubTotal()
									num3 = Math.Round(num3, 2)
									Me.txtSubTotal.Text = Conversions.ToString(num3)
									Me.Compute()
									Me.Clear()
									Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(2)
									Me.DataGridView5.Visible = False
								End If
							End If
						End If
					End If
				End If
			Catch ex2 As Exception
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x060118BC RID: 71868 RVA: 0x00A28C68 File Offset: 0x00A26E68
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
				Me.Compute()
				Me.btnRemove.Enabled = False
				Me.Clear()
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060118BD RID: 71869 RVA: 0x00A28D88 File Offset: 0x00A26F88
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

		' Token: 0x060118BE RID: 71870 RVA: 0x00A28E80 File Offset: 0x00A27080
		Public Sub Calc()
			Dim flag As Boolean = (Operators.CompareString(Me.txtTaxType.Text, "Exclusive", False) = 0) Or (Operators.CompareString(Me.txtTaxType.Text, "Exempt GST", False) = 0) Or (Operators.CompareString(Me.txtTaxType.Text, "No Taxes", False) = 0)
			If flag Then
				Me.num1 = Conversion.Val(Me.txtReturnQty.Text) * Conversion.Val(Me.txtPrice.Text)
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
			End If
			Dim flag2 As Boolean = Operators.CompareString(Me.txtTaxType.Text, "Inclusive", False) = 0
			If flag2 Then
				Me.num1 = Conversion.Val(Me.txtReturnQty.Text) * Conversion.Val(Me.txtPrice.Text)
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
			End If
		End Sub

		' Token: 0x060118BF RID: 71871 RVA: 0x00078E81 File Offset: 0x00077081
		Private Sub txtRetuenQty_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x060118C0 RID: 71872 RVA: 0x00A29438 File Offset: 0x00A27638
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

		' Token: 0x060118C1 RID: 71873 RVA: 0x00A29530 File Offset: 0x00A27730
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from PurchaseReturn where PR_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtPRID.Text))
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					Try
						For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "Update Temp_Stock set Qty=Qty + " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(17).Value))) + " where ProductID=@d1 and Barcode=@d2"
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
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtPRNO.Text)
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
								If flag3 Then
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text4 As String = "delete from StockMovement where ProductID=@d1 and TransID=@d2"
									ModCommonClasses.cmd = New SqlCommand(text4)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtPRNO.Text)
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
					ModFunc.SrPurReturnDelete(Me.txtPRNO.Text)
					ModFunc.LedgerDelete(Me.txtPRNO.Text, "Purchase Return")
					ModFunc.SupplierLedgerDelete(Me.txtPRNO.Text)
					Dim text5 As String = "deleted the Purchase Return record having PR No. '" + Me.txtPRNO.Text + "'"
					ModFunc.LogFunc(Me.lblUser.Text, text5)
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillPReturnID()
					Me.Reset()
					ModFunc.RefreshRecords()
				Else
					MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillPReturnID()
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

		' Token: 0x060118C2 RID: 71874 RVA: 0x00A29A00 File Offset: 0x00A27C00
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

		' Token: 0x060118C3 RID: 71875 RVA: 0x00078E8B File Offset: 0x0007708B
		Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x060118C4 RID: 71876 RVA: 0x00A29AF8 File Offset: 0x00A27CF8
		Private Sub frmPurchaseReturn_Load(sender As Object, e As EventArgs)
			Me.GetCompanyState()
			Me.GetCompanyState1()
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.DataforNP()
			Me.Invoicecode()
			Me.auto()
			Me.Autoroundoff()
			Me.BillSundryType()
			Me.fillPReturnID()
			Me.LinkLabel1.TabStop = False
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x060118C5 RID: 71877 RVA: 0x00A29BCC File Offset: 0x00A27DCC
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

		' Token: 0x060118C6 RID: 71878 RVA: 0x00A29E6C File Offset: 0x00A2806C
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

		' Token: 0x060118C7 RID: 71879 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060118C8 RID: 71880 RVA: 0x00A29F38 File Offset: 0x00A28138
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

		' Token: 0x060118C9 RID: 71881 RVA: 0x00A2A09C File Offset: 0x00A2829C
		Public Sub GetCompanyState1()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(State), RTRIM(companyName),RTRIM(FYFrom),RTRIM(FYTo),RTRIM(Bankholder),RTRIM(Bankacno),RTRIM(Bankname),RTRIM(Bankifsc),RTRIM(GSTIN),Logo,RTRIM(Address),RTRIM(ContactNo),RTRIM(EmailID) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtCompanyState.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtcompname.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.compgstin.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(8))
					Me.CompanyAddress.Text = ModCommonClasses.rdr.GetValue(10).ToString()
					Me.CompanyContact.Text = ModCommonClasses.rdr.GetValue(11).ToString()
					Me.CompanyEMail.Text = ModCommonClasses.rdr.GetValue(12).ToString()
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

		' Token: 0x060118CA RID: 71882 RVA: 0x00A2A22C File Offset: 0x00A2842C
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

		' Token: 0x060118CB RID: 71883 RVA: 0x00A2A33C File Offset: 0x00A2853C
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

		' Token: 0x060118CC RID: 71884 RVA: 0x00A2A480 File Offset: 0x00A28680
		Private Sub DataGridView2_MouseClick(sender As Object, e As MouseEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = Me.DataGridView2.Rows.Count > 0
				If flag Then
					Me.Clear()
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.SelectedRows(0)
					Me.txtProductID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Try
						Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
						sqlConnection.Open()
						Dim sqlCommand As SqlCommand = sqlConnection.CreateCommand()
						sqlCommand.CommandText = "SELECT a.ProductID, sum(a.ReturnQty)ReturnQty" & vbCrLf & "                   FROM PurchaseReturn_Join a" & vbCrLf & "                   INNER JOIN PurchaseReturn b ON a.PurchaseReturnID  = b.PR_ID" & vbCrLf & "                   LEFT JOIN Stock  c ON b.PurchaseID = c.ST_ID" & vbCrLf & "                   WHERE c.InvoiceNo = @InvoiceNo AND a.ProductID = @ProductID" & vbCrLf & "group by a.ProductID"
						sqlCommand.Parameters.AddWithValue("@InvoiceNo", Me.txtPurchaseInvoiceNo.Text)
						sqlCommand.Parameters.AddWithValue("@ProductID", Convert.ToInt32(Me.txtProductID.Text))
						Dim sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
						Dim flag2 As Boolean = sqlDataReader.Read()
						If flag2 Then
							Dim flag3 As Boolean = Conversion.Val(dataGridViewRow.Cells(4).Value.ToString()) <= Conversion.Val(sqlDataReader("ReturnQty").ToString())
							If flag3 Then
								Me.Label27.Text = "Available(Qty) to Return :0"
								MessageBox.Show("This product already returned")
								Return
							End If
							Me.intLimitQty_return = CInt(Math.Round(Conversion.Val(dataGridViewRow.Cells(4).Value.ToString()) - Conversion.Val(sqlDataReader("ReturnQty").ToString())))
						Else
							Me.intLimitQty_return = CInt(Math.Round(Conversion.Val(dataGridViewRow.Cells(4).Value.ToString())))
						End If
						Me.Label27.Text = "Available(Qty) to Return :" + Conversions.ToString(Me.intLimitQty_return)
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
					Me.txtTaxType.Text = dataGridViewRow.Cells(18).Value.ToString()
					Me.txtHSNCode.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtProductName.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtBarcode.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.bindgrid5_serialno(dataGridViewRow.Cells(3).Value.ToString())
					Me.txtQty.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.txtPrice.Text = dataGridViewRow.Cells(6).Value.ToString()
					Me.txtMRP.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.txtDiscPer.Text = dataGridViewRow.Cells(7).Value.ToString()
					Me.txtDisc.Text = dataGridViewRow.Cells(8).Value.ToString()
					Me.txtCGSTPer.Text = dataGridViewRow.Cells(9).Value.ToString()
					Me.txtCGSTAmt.Text = dataGridViewRow.Cells(10).Value.ToString()
					Me.txtSGSTPer.Text = dataGridViewRow.Cells(11).Value.ToString()
					Me.txtSGSTAmt.Text = dataGridViewRow.Cells(12).Value.ToString()
					Me.txtIGSTPer.Text = dataGridViewRow.Cells(13).Value.ToString()
					Me.txtIGSTAmt.Text = dataGridViewRow.Cells(14).Value.ToString()
					Me.txtCESSPer.Text = dataGridViewRow.Cells(15).Value.ToString()
					Me.txtCESSAmt.Text = dataGridViewRow.Cells(16).Value.ToString()
					Me.txtTaxableAmt.Text = dataGridViewRow.Cells(19).Value.ToString()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
					ModCommonClasses.cmd.CommandText = If(("SELECT RTRIM(PurchaseUnit) from Product where PID=" + Conversions.ToString(Conversion.Val(Me.txtProductID.Text))), "")
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

		' Token: 0x060118CD RID: 71885 RVA: 0x00A2AA54 File Offset: 0x00A28C54
		Public Sub bindgrid5_serialno(strbarcode As String)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT a.productid AS PID, RTRIM(b.ProductCode) AS Productcode, RTRIM(b.ProductName) AS ProductName, a.barcode AS Barcode, a.serialno1" & vbCrLf & "                              FROM tbl_product_serial_final a" & vbCrLf & "                              INNER JOIN product b ON a.productid = b.pid where a.invoice_no=@d1 and a.barcode=@d2"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtPurchaseInvoiceNo.Text)
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

		' Token: 0x060118CE RID: 71886 RVA: 0x00A2ABB4 File Offset: 0x00A28DB4
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

		' Token: 0x060118CF RID: 71887 RVA: 0x00A2AD14 File Offset: 0x00A28F14
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

		' Token: 0x060118D0 RID: 71888 RVA: 0x00A2AD78 File Offset: 0x00A28F78
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

		' Token: 0x060118D1 RID: 71889 RVA: 0x00A2AE60 File Offset: 0x00A29060
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

		' Token: 0x060118D2 RID: 71890 RVA: 0x00078E95 File Offset: 0x00077095
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x060118D3 RID: 71891 RVA: 0x00078E8B File Offset: 0x0007708B
		Private Sub txtFreightCharges_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x060118D4 RID: 71892 RVA: 0x00078E8B File Offset: 0x0007708B
		Private Sub txtOtherCharges_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x060118D5 RID: 71893 RVA: 0x00A2AF48 File Offset: 0x00A29148
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

		' Token: 0x060118D6 RID: 71894 RVA: 0x00A2B040 File Offset: 0x00A29240
		Private Sub txtOtherCharges_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtOtherCharges.Text
					Dim selectionStart As Integer = Me.txtOtherCharges.SelectionStart
					Dim selectionLength As Integer = Me.txtOtherCharges.SelectionLength
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

		' Token: 0x060118D7 RID: 71895 RVA: 0x00078EB1 File Offset: 0x000770B1
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Me.cmbBSundry.Text = "Bill Sundry"
		End Sub

		' Token: 0x060118D8 RID: 71896 RVA: 0x00A2B138 File Offset: 0x00A29338
		Private Sub dtpPRDate_LostFocus(sender As Object, e As EventArgs)
			Dim flag As Boolean = DateTime.Compare(Me.dtpPRDate.Value, Me.DTP1.Value) < 0
			If flag Then
				Me.dtpPRDate.Value = DateAndTime.Today
				MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				MyBase.Close()
			Else
				Dim flag2 As Boolean = DateTime.Compare(Me.dtpPRDate.Value, Me.DTP2.Value) > 0
				If flag2 Then
					Me.dtpPRDate.Value = DateAndTime.Today
					MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060118D9 RID: 71897 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpPRDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060118DA RID: 71898 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtReturnQty_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060118DB RID: 71899 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbBSundry_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060118DC RID: 71900 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtFreightCharges_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060118DD RID: 71901 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtOtherCharges_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060118DE RID: 71902 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbPmtMode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060118DF RID: 71903 RVA: 0x00A2B1E4 File Offset: 0x00A293E4
		Public Sub fillPReturnID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(PR_ID) FROM PurchaseReturn order by PR_ID ASC", ModCommonClasses.con)
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

		' Token: 0x060118E0 RID: 71904 RVA: 0x00A2B320 File Offset: 0x00A29520
		Public Sub NextPrev()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd = New SqlCommand("SELECT PR_ID, RTRIM(PRNo),PurchaseReturn.Date,RTRIM(TaxType),RTRIM(PurchaseID),RTRIM(InvoiceNo),Stock.Date, RTRIM(Supplier.SupplierID),RTRIM(Name),RTRIM(PurchaseReturn.SubTotal),RTRIM(PurchaseReturn.SGST),RTRIM(PurchaseReturn.CGST),RTRIM(PurchaseReturn.IGST),RTRIM(PurchaseReturn.CESS),PurchaseReturn.FreightCharges,PurchaseReturn.OtherCharges,RTRIM(PurchaseReturn.Total),RTRIM(PurchaseReturn.RoundOff),RTRIM(PurchaseReturn.GrandTotal),RTRIM(PurchaseReturn.RCM),RTRIM(PurchaseReturn.PaymentMode),RTRIM(PurchaseReturn.BillSundry) FROM Stock,PurchaseReturn,Supplier where Stock.ST_ID=PurchaseReturn.PurchaseID and Supplier.ID=Stock.SupplierID and PR_ID=@d1", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtPRID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtPRNO.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.dtpPRDate.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.txtTaxType.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.txtPurchaseID.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.txtPurchaseInvoiceNo.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.dtpPurchaseDate.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.txtSupplierID.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.txtSupplierName.Text = ModCommonClasses.rdr.GetValue(8).ToString()
					Me.txtSubTotal.Text = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.txtCGST.Text = ModCommonClasses.rdr.GetValue(10).ToString()
					Me.txtSGST.Text = ModCommonClasses.rdr.GetValue(11).ToString()
					Me.txtIGST.Text = ModCommonClasses.rdr.GetValue(12).ToString()
					Me.txtCESS.Text = ModCommonClasses.rdr.GetValue(13).ToString()
					Me.txtFreightCharges.Text = ModCommonClasses.rdr.GetValue(14).ToString()
					Me.txtOtherCharges.Text = ModCommonClasses.rdr.GetValue(15).ToString()
					Me.txtTotal.Text = ModCommonClasses.rdr.GetValue(16).ToString()
					Me.txtRoundOff.Text = ModCommonClasses.rdr.GetValue(17).ToString()
					Me.txtGrandTotal.Text = ModCommonClasses.rdr.GetValue(18).ToString()
					Me.TextBox2.Text = ModCommonClasses.rdr.GetValue(19).ToString()
					Me.cmbPmtMode.Text = ModCommonClasses.rdr.GetValue(20).ToString()
					Me.cmbBSundry.Text = ModCommonClasses.rdr.GetValue(21).ToString()
					Me.btnSave.Enabled = False
					Me.DataGridView1.Enabled = True
					Me.btnAdd.Enabled = False
					Me.btnRemove.Enabled = False
					Me.lblSet.Text = "Not Allowed"
					Me.pnlCalc.Enabled = False
					Me.btnDelete.Enabled = True
					Me.btnSelection.Enabled = False
					Me.btnPrint.Enabled = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT PurchaseReturn_Join.ProductID,RTRIM(HSNCode),RTRIM(Productname), RTRIM(PurchaseReturn_Join.Barcode), PurchaseReturn_Join.Qty,PurchaseReturn_Join.MRP, PurchaseReturn_Join.Price, PurchaseReturn_Join.DiscPer, PurchaseReturn_Join.DiscAmt, PurchaseReturn_Join.CGSTPer, PurchaseReturn_Join.CGSTAmt, PurchaseReturn_Join.SGSTPer, PurchaseReturn_Join.SGSTAmt, PurchaseReturn_Join.IGSTPer, PurchaseReturn_Join.IGSTAmt, PurchaseReturn_Join.CESSPer, PurchaseReturn_Join.CESSAmt,PurchaseReturn_Join.ReturnQty, PurchaseReturn_Join.TotalAmount,RTRIM(PurchaseReturn_Join.PTaxType),(PurchaseReturn_Join.TaxableAmt) FROM PurchaseReturn_Join INNER JOIN PurchaseReturn ON PurchaseReturn_Join.PurchaseReturnID = PurchaseReturn.PR_ID INNER JOIN Product ON Product.PID = PurchaseReturn_Join.ProductID and PR_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20) })
					End While
					Me.DataGridView1.ClearSelection()
					ModCommonClasses.con.Close()
					Me.Calc()
					Me.Compute()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060118E1 RID: 71905 RVA: 0x00078EC5 File Offset: 0x000770C5
		Private Sub txtNP_KeyDown(sender As Object, e As KeyEventArgs)
			Me.NextPrev()
			Me.NextPrev()
			Me.NextPrev()
		End Sub

		' Token: 0x060118E2 RID: 71906 RVA: 0x00A2B8F0 File Offset: 0x00A29AF0
		Private Sub Button35_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmReminder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmReminder.ShowDialog()
			MyProject.Forms.frmReminder.Dispose()
		End Sub

		' Token: 0x060118E3 RID: 71907 RVA: 0x00078EDD File Offset: 0x000770DD
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseRecord_GSTR.Reset()
			MyProject.Forms.frmPurchaseRecord_GSTR.ShowDialog()
			MyProject.Forms.frmPurchaseRecord_GSTR.Dispose()
		End Sub

		' Token: 0x060118E4 RID: 71908 RVA: 0x00A2B940 File Offset: 0x00A29B40
		Private Sub DataforNP()
			ModCommonClasses.con.Close()
			Me.CurrentRow = 0
			ModCommonClasses.con.Open()
			Me.Dad = New SqlDataAdapter("Select * FROM PurchaseReturn", ModCommonClasses.con)
			Me.Dad.Fill(Me.Dst, "PurchaseReturn")
			Try
				Me.txtNP.Text = Conversions.ToString(Me.Dst.Tables("PurchaseReturn").Rows(Conversions.ToInteger(Me.CurrentRow))("PR_ID"))
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060118E5 RID: 71909 RVA: 0x00A2BA1C File Offset: 0x00A29C1C
		Private Sub btnNext_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtPRID.Text))
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

		' Token: 0x060118E6 RID: 71910 RVA: 0x00A2BAD8 File Offset: 0x00A29CD8
		Private Sub txtPrev_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtPRID.Text))
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

		' Token: 0x060118E7 RID: 71911 RVA: 0x00A2BB84 File Offset: 0x00A29D84
		Private Sub btnLast_Click(sender As Object, e As EventArgs)
			Try
				' The following expression was wrapped in a checked-expression
				Me.CurrentRow = Me.Dst.Tables("PurchaseReturn").Rows.Count - 1
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("PurchaseReturn").Rows(Conversions.ToInteger(Me.CurrentRow))("PR_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060118E8 RID: 71912 RVA: 0x00A2BC3C File Offset: 0x00A29E3C
		Private Sub btnFirst_Click(sender As Object, e As EventArgs)
			Try
				Me.CurrentRow = 0
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("PurchaseReturn").Rows(Conversions.ToInteger(Me.CurrentRow))("PR_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060118E9 RID: 71913 RVA: 0x00078F10 File Offset: 0x00077110
		Private Sub txtSubTotal_TextChanged(sender As Object, e As EventArgs)
			Me.txtSubTotal.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtSubTotal.Text), 2), "0.00")
		End Sub

		' Token: 0x060118EA RID: 71914 RVA: 0x00078F44 File Offset: 0x00077144
		Private Sub brnPrint_Click(sender As Object, e As EventArgs)
			Me.Print()
		End Sub

		' Token: 0x060118EB RID: 71915 RVA: 0x00A2BCD4 File Offset: 0x00A29ED4
		Private Function GetSerialNumbersByBarcode(barcode As String, invoiceno As String) As String
			Dim text As String = String.Empty
			Dim sqlConnection As SqlConnection = Nothing
			Dim sqlDataReader As SqlDataReader = Nothing
			Try
				sqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				Dim text2 As String = vbCrLf & "            SELECT " & vbCrLf & "    STUFF(" & vbCrLf & "        (SELECT ', ' + serialno" & vbCrLf & "         FROM tbl_product_serial_purchaseReturn AS inner_table" & vbCrLf & "         WHERE inner_table.invoice_no = @invoiceno" & vbCrLf & "           AND inner_table.barcode = @barcode" & vbCrLf & "         FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), " & vbCrLf & "    1, 2, '') AS serial_numbers" & vbCrLf & "FROM " & vbCrLf & "    tbl_product_serial_purchaseReturn AS outer_table" & vbCrLf & "WHERE " & vbCrLf & "    outer_table.invoice_no = @invoiceno" & vbCrLf & "    AND outer_table.barcode = @barcode " & vbCrLf & "GROUP BY " & vbCrLf & "    outer_table.invoice_no, outer_table.barcode"
				Dim sqlCommand As SqlCommand = New SqlCommand(text2, sqlConnection)
				sqlCommand.Parameters.AddWithValue("@invoiceno", invoiceno)
				sqlCommand.Parameters.AddWithValue("@barcode", barcode)
				sqlDataReader = sqlCommand.ExecuteReader()
				Dim flag As Boolean = sqlDataReader.Read()
				If flag Then
					text = sqlDataReader("serial_numbers").ToString()
				End If
			Catch ex As Exception
				MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Dim flag2 As Boolean = sqlDataReader IsNot Nothing
				If flag2 Then
					sqlDataReader.Close()
				End If
				Dim flag3 As Boolean = sqlConnection IsNot Nothing AndAlso sqlConnection.State = ConnectionState.Open
				If flag3 Then
					sqlConnection.Close()
				End If
			End Try
			Return text
		End Function

		' Token: 0x060118EC RID: 71916 RVA: 0x00A2BDE8 File Offset: 0x00A29FE8
		Private Sub Print()
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim dataTable As DataTable = New DataTable()
				Dim dataTable2 As DataTable = dataTable
				dataTable2.Columns.Add("PID")
				dataTable2.Columns.Add("HSNC")
				dataTable2.Columns.Add("ProductName")
				dataTable2.Columns.Add("Barcode")
				dataTable2.Columns.Add("Qty")
				dataTable2.Columns.Add("MRP")
				dataTable2.Columns.Add("Rate")
				dataTable2.Columns.Add("DiscPer")
				dataTable2.Columns.Add("Disc")
				dataTable2.Columns.Add("CGSTPer")
				dataTable2.Columns.Add("CGST")
				dataTable2.Columns.Add("SGSTPer")
				dataTable2.Columns.Add("SGST")
				dataTable2.Columns.Add("IGSTPer")
				dataTable2.Columns.Add("IGST")
				dataTable2.Columns.Add("CESSPer")
				dataTable2.Columns.Add("CESS")
				dataTable2.Columns.Add("ReturnQty")
				dataTable2.Columns.Add("Amount")
				dataTable2.Columns.Add("PurchaseTaxType")
				dataTable2.Columns.Add("TaxableAmt")
				dataTable2.Columns.Add("Serialno")
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Dim text As String = ", " + Me.GetSerialNumbersByBarcode(dataGridViewRow.Cells(3).Value.ToString(), Me.txtPRNO.Text)
						Dim text2 As String = text.Replace(",", Environment.NewLine)
						dataTable.Rows.Add(New Object() { dataGridViewRow.Cells(0).Value, dataGridViewRow.Cells(1).Value, Operators.ConcatenateObject(dataGridViewRow.Cells(2).Value, text2), dataGridViewRow.Cells(3).Value, dataGridViewRow.Cells(4).Value, dataGridViewRow.Cells(5).Value, dataGridViewRow.Cells(6).Value, dataGridViewRow.Cells(7).Value, dataGridViewRow.Cells(8).Value, dataGridViewRow.Cells(9).Value, dataGridViewRow.Cells(10).Value, dataGridViewRow.Cells(11).Value, dataGridViewRow.Cells(12).Value, dataGridViewRow.Cells(13).Value, dataGridViewRow.Cells(14).Value, dataGridViewRow.Cells(15).Value, dataGridViewRow.Cells(16).Value, dataGridViewRow.Cells(17).Value, dataGridViewRow.Cells(18).Value, dataGridViewRow.Cells(19).Value, dataGridViewRow.Cells(20).Value })
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim reportDocument As ReportDocument = New ReportDocument()
				reportDocument.Load(Application.StartupPath + "\CryReport\A4PurchaseReturnInv.rpt")
				reportDocument.SetDataSource(dataTable)
				reportDocument.SetParameterValue("P5", Me.cmbBSundry.Text)
				reportDocument.SetParameterValue("Bill Sundry", Me.txtFreightCharges.Text)
				reportDocument.SetParameterValue("Bill Discount", Me.txtOtherCharges.Text)
				reportDocument.SetParameterValue("Grand Total", Me.txtGrandTotal.Text)
				reportDocument.SetParameterValue("Roundoff", Me.txtRoundOff.Text)
				reportDocument.SetParameterValue("Net Total", Me.txtGrandTotal.Text)
				reportDocument.SetParameterValue("Paid", Me.txtGrandTotal.Text)
				reportDocument.SetParameterValue("SuplName", Me.txtSupplierName.Text)
				reportDocument.SetParameterValue("Address", Me.TextBox3.Text)
				reportDocument.SetParameterValue("CompContact", Me.TextBox6.Text)
				reportDocument.SetParameterValue("CompGSTIN", Me.TextBox4.Text)
				reportDocument.SetParameterValue("State", Me.TextBox5.Text)
				reportDocument.SetParameterValue("SuplInv", Me.txtPurchaseInvoiceNo.Text)
				reportDocument.SetParameterValue("SuplDate", Me.dtpPurchaseDate.Text)
				reportDocument.SetParameterValue("Invoice No", Me.txtPRNO.Text)
				reportDocument.SetParameterValue("Inv Date", Me.dtpPRDate.Text)
				reportDocument.SetParameterValue("RefNo", Me.cmbPmtMode.Text)
				reportDocument.SetParameterValue("Reverse", Me.TextBox2.Text)
				reportDocument.SetParameterValue("PurcType", Me.txtGSTnonGST.Text)
				reportDocument.SetParameterValue("TaxType", Me.txtGSTnonGST.Text)
				reportDocument.SetParameterValue("CGSTTot", Me.txtCGST.Text)
				reportDocument.SetParameterValue("SGSTTot", Me.txtSGST.Text)
				reportDocument.SetParameterValue("IGSTTot", Me.txtIGST.Text)
				reportDocument.SetParameterValue("CESSTot", Me.txtCESS.Text)
				reportDocument.SetParameterValue("Company", Me.txtcompname.Text)
				reportDocument.SetParameterValue("CompAddress", Me.CompanyAddress.Text)
				reportDocument.SetParameterValue("CompContact1", Me.CompanyContact.Text)
				reportDocument.SetParameterValue("CompEmail1", Me.CompanyEMail.Text)
				reportDocument.SetParameterValue("CompGSTIN1", Me.compgstin.Text)
				reportDocument.SetParameterValue("CompState1", Me.txtCompanyState.Text)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
				MyProject.Forms.frmReport.ShowDialog()
				MyProject.Forms.frmReport.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060118ED RID: 71917 RVA: 0x00A2C578 File Offset: 0x00A2A778
		Private Sub BtnGetData_Click(sender As Object, e As EventArgs)
			Me.Reset()
			MyProject.Forms.frmPurchaseReturnRecord.lblSet.Text = "PR"
			MyProject.Forms.frmPurchaseReturnRecord.Reset()
			MyProject.Forms.frmPurchaseReturnRecord.ShowDialog()
			MyProject.Forms.frmPurchaseReturnRecord.Dispose()
		End Sub

		' Token: 0x060118EE RID: 71918 RVA: 0x00A2C5D8 File Offset: 0x00A2A7D8
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

		' Token: 0x060118EF RID: 71919 RVA: 0x00A2C640 File Offset: 0x00A2A840
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCPhone.Text, "Trial", False) <> 0
			If Not flag Then
				Dim value As DateTime = Me.dtpPRDate.Value
				Dim dateTime As DateTime = New DateTime(value.Year, value.Month, 1)
				Dim dateTime2 As DateTime = dateTime.AddMonths(1).AddDays(-1.0)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(*) from PurchaseReturn where Date between @d1 and @d2 having count(*) >= 5"
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
					Dim flag6 As Boolean = Strings.Len(Strings.Trim(Me.txtPurchaseInvoiceNo.Text)) = 0
					If flag6 Then
						MessageBox.Show("Please retrieve Purchase Info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtPurchaseInvoiceNo.Focus()
					Else
						Dim flag7 As Boolean = Strings.Len(Strings.Trim(Me.txtSupplierID.Text)) = 0
						If flag7 Then
							MessageBox.Show("Please retrieve supplier id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtSupplierID.Focus()
						Else
							Dim flag8 As Boolean = Me.DataGridView1.Rows.Count = 0
							If flag8 Then
								MessageBox.Show("Sorry no returned product info added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Else
								Dim flag9 As Boolean = Operators.CompareString(Me.cmbBSundry.Text, "", False) = 0
								If flag9 Then
									MessageBox.Show("Not allowed to empty box of Bill Sundry Type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.cmbBSundry.Focus()
								Else
									Dim flag10 As Boolean = Me.cmbPmtMode.SelectedIndex = -1
									If flag10 Then
										MessageBox.Show("Please fill Payment Mode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.cmbPmtMode.Focus()
									Else
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text3 As String = "insert into PurchaseReturn(PR_ID, PRNo, Date, PurchaseID, SubTotal, CGST, SGST, IGST, CESS, Total, RoundOff, GrandTotal,FreightCharges,OtherCharges,RCM,PaymentMode,BillSundry) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)"
										ModCommonClasses.cmd = New SqlCommand(text3)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtPRID.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtPRNO.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpPRDate.Value.[Date])
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.txtPurchaseID.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtSubTotal.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtCGST.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtSGST.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtIGST.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(Me.txtCESS.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(Me.txtTotal.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(Me.txtRoundOff.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(Me.txtGrandTotal.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(Me.txtFreightCharges.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(Me.txtOtherCharges.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Me.TextBox2.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.cmbPmtMode.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Me.cmbBSundry.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text4 As String = "insert into PurchaseReturn_Join(PurchaseReturnID, ProductID, Barcode, Qty,MRP, Price, DiscPer, DiscAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,ReturnQty, TotalAmount, PTaxType, TaxableAmt)VALUES (" + Conversions.ToString(Conversion.Val(Me.txtPRID.Text)) + ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19)"
										ModCommonClasses.cmd = New SqlCommand(text4)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.Prepare()
										Try
											For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
												Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
												Dim flag11 As Boolean = Not dataGridViewRow.IsNewRow
												If flag11 Then
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
													ModCommonClasses.cmd.Parameters.AddWithValue("@d18", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(19).Value))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(20).Value)))
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
										Try
											For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
												Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text5 As String = "Update Temp_Stock set Qty=Qty - " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(17).Value))) + " where ProductID=@d1 and Barcode=@d2"
												ModCommonClasses.cmd = New SqlCommand(text5)
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
													Dim flag13 As Boolean = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(17).Value)) > 0.0
													If flag13 Then
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text6 As String = "select ProductID from StockMovement where ProductID=@d1"
														ModCommonClasses.cmd = New SqlCommand(text6)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
														ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
														Dim flag14 As Boolean = ModCommonClasses.rdr.Read()
														If flag14 Then
															ModCommonClasses.con = New SqlConnection(ModCS.cs)
															ModCommonClasses.con.Open()
															Dim text7 As String = "select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 and Date < @d3"
															ModCommonClasses.cmd = New SqlCommand(text7)
															ModCommonClasses.cmd.Connection = ModCommonClasses.con
															ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpPRDate.Value.[Date])
															ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
															Dim flag15 As Boolean = ModCommonClasses.rdr.Read()
															Dim num As Double
															If flag15 Then
																num = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
															Else
																num = 0.0
															End If
															ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))), New Decimal(num), 0D, New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(17).Value))), Me.dtpPRDate.Value.[Date], Me.txtPRNO.Text)
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
											ModFunc.LedgerSave(Me.dtpPRDate.Value.[Date], Me.txtSupplierName.Text, Me.txtPRNO.Text, "Purchase Return", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D, Me.txtSupplierID.Text, Me.txtSupplierName.Text)
										End If
										Dim flag17 As Boolean = Me.cmbPmtMode.SelectedIndex = 0
										If flag17 Then
											ModFunc.LedgerSave(Me.dtpPRDate.Value.[Date], Me.txtSupplierName.Text, Me.txtPRNO.Text, "Purchase Return", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D, Me.txtSupplierID.Text, Me.txtSupplierName.Text)
											ModFunc.LedgerSave(Me.dtpPRDate.Value.[Date], "Cash Account", Me.txtPRNO.Text, "Purchase Return", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), Me.txtSupplierID.Text, Me.txtSupplierName.Text)
										End If
										Dim flag18 As Boolean = Me.cmbPmtMode.SelectedIndex = 1
										If flag18 Then
											ModFunc.SupplierLedgerSave(Me.dtpPRDate.Value.[Date], Me.txtSupplierName.Text, Me.txtPRNO.Text, "Purchase Return", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D, Me.txtSupplierID.Text, Me.txtSupplierName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtSupplierID.Text.TrimEnd(New Char(-1) {}), Me.txtPurchaseInvoiceNo.Text + ", " + Me.dtpPurchaseDate.Text)
										End If
										Dim flag19 As Boolean = Me.cmbPmtMode.SelectedIndex = 0
										If flag19 Then
											ModFunc.SupplierLedgerSave(Me.dtpPRDate.Value.[Date], Me.txtSupplierName.Text, Me.txtPRNO.Text, "Purchase Return", New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), 0D, Me.txtSupplierID.Text, Me.txtSupplierName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtSupplierID.Text.TrimEnd(New Char(-1) {}), Me.txtPurchaseInvoiceNo.Text + ", " + Me.dtpPurchaseDate.Text)
											ModFunc.SupplierLedgerSave(Me.dtpPRDate.Value.[Date], Me.txtSupplierName.Text, Me.txtPRNO.Text, "Cash Return", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text)), Me.txtSupplierID.Text, Me.txtSupplierName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtSupplierID.Text.TrimEnd(New Char(-1) {}), Me.txtPurchaseInvoiceNo.Text + ", " + Me.dtpPurchaseDate.Text)
										End If
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text8 As String = "insert into SrPurReturn(ID, InvNo) Values (@d1,@d2)"
										ModCommonClasses.cmd = New SqlCommand(text8)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.ntid))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtPRNO.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteReader()
										ModCommonClasses.con.Close()
										Me.InsertSerial_final(Me.txtPRNO.Text, Me.lblUser.Text)
										Me.DataGridView5F.Rows.Clear()
										Me.DataGridView5F.Visible = False
										ModFunc.LogFunc(Me.lblUser.Text, "added the new Purchase return record having PR No. '" + Me.txtPRNO.Text + "'")
										MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										Me.fillPReturnID()
										Me.btnSave.Enabled = False
										ModCommonClasses.con.Close()
										Me.DataforNP()
										ModFunc.RefreshRecords()
										Me.btnPrint.Enabled = True
									End If
								End If
							End If
						End If
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x060118F0 RID: 71920 RVA: 0x00A2DA98 File Offset: 0x00A2BC98
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
										Dim text As String = "INSERT INTO tbl_product_serial_purchaseReturn (productid, barcode, serialno, status, sys_user, invoice_no) VALUES (@productid, @barcode, @serialno, @status, @sys_user, @invoice_no)"
										Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection, sqlTransaction)
											sqlCommand.Parameters.AddWithValue("@productid", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("PID1").Value))
											sqlCommand.Parameters.AddWithValue("@barcode", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("Barcode1").Value))
											sqlCommand.Parameters.AddWithValue("@serialno", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("Serial_no1").Value))
											sqlCommand.Parameters.AddWithValue("@status", "PURCHASE RETURN")
											sqlCommand.Parameters.AddWithValue("@sys_user", SysUser)
											sqlCommand.Parameters.AddWithValue("@invoice_no", InvoiceNo)
											sqlCommand.ExecuteNonQuery()
										End Using
										Dim text2 As String = "UPDATE tbl_product_serial_final SET status = 'PURCHASE RETURN' WHERE serialno1 = @serialno OR serialno2 = @serialno"
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

		' Token: 0x060118F1 RID: 71921 RVA: 0x00078F4E File Offset: 0x0007714E
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060118F2 RID: 71922 RVA: 0x00A2DDB8 File Offset: 0x00A2BFB8
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

		' Token: 0x060118F3 RID: 71923 RVA: 0x00A2E094 File Offset: 0x00A2C294
		Private Sub AddRowToDataGridView5F(rowIndex As Integer)
			Dim dataGridViewRow As DataGridViewRow = Me.DataGridView5.Rows(rowIndex)
			Me.DataGridView5F.Rows.Add(New Object() { dataGridViewRow.Cells("PID").Value, dataGridViewRow.Cells("Productcode").Value, dataGridViewRow.Cells("Productname").Value, dataGridViewRow.Cells("Barcode").Value, dataGridViewRow.Cells("Serial_no").Value })
		End Sub

		' Token: 0x060118F4 RID: 71924 RVA: 0x00A2E144 File Offset: 0x00A2C344
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

		' Token: 0x060118F5 RID: 71925 RVA: 0x00A2E284 File Offset: 0x00A2C484
		Public Sub Speaker()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.DataGridView1.Rows.Count - 1
				For i As Integer = 0 To num
					Dim num2 As Double = Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("DataGridViewTextBoxColumn25").Value))
					Me.txtRsToWords.Text = Conversions.ToString(RupModule1.RupeesToWord(Conversion.Val(num2)))
					Me.a1 = Me.DataGridView1.Rows(i).Cells("DataGridViewTextBoxColumn11").Value.ToString()
					Me.a2 = Conversions.ToString(Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("Column1").Value)))
					NewLateBinding.LateCall(Me.voice, Nothing, "speak", New Object() { String.Concat(New String() { Me.a1, " ", Me.a2, "Main Unit ", Me.txtRsToWords.Text }) }, Nothing, Nothing, Nothing, True)
				Next
				NewLateBinding.LateCall(Me.voice, Nothing, "speak", New Object() { "Thank You" }, Nothing, Nothing, Nothing, True)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060118F6 RID: 71926 RVA: 0x00A2E424 File Offset: 0x00A2C624
		Private Sub Button34_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.DataGridView1.Rows.Count = 0
			If flag Then
				MessageBox.Show("You have not added the products into grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Me.Speaker()
			End If
		End Sub

		' Token: 0x060118F7 RID: 71927 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmPurchaseReturn_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060118F8 RID: 71928 RVA: 0x00A2E468 File Offset: 0x00A2C668
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

		' Token: 0x060118F9 RID: 71929 RVA: 0x00A2E560 File Offset: 0x00A2C760
		Public Sub LastBillDate()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT Top 1 Date from PurchaseReturn order by PR_ID DESC"
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
					Me.dtpPRDate.Value = Me.prevdate
				Else
					Me.dtpPRDate.Value = DateAndTime.Today
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x040069EB RID: 27115
		Private str As String

		' Token: 0x040069EC RID: 27116
		Private st As String

		' Token: 0x040069ED RID: 27117
		Private num1 As Double

		' Token: 0x040069EE RID: 27118
		Private num2 As Double

		' Token: 0x040069EF RID: 27119
		Private num3 As Double

		' Token: 0x040069F0 RID: 27120
		Private num4 As Double

		' Token: 0x040069F1 RID: 27121
		Private num5 As Double

		' Token: 0x040069F2 RID: 27122
		Private num6 As Double

		' Token: 0x040069F3 RID: 27123
		Private num7 As Double

		' Token: 0x040069F4 RID: 27124
		Private num8 As Double

		' Token: 0x040069F5 RID: 27125
		Private num9 As Double

		' Token: 0x040069F6 RID: 27126
		Private num10 As Double

		' Token: 0x040069F7 RID: 27127
		Private num11 As Double

		' Token: 0x040069F8 RID: 27128
		Private a As Decimal

		' Token: 0x040069F9 RID: 27129
		Private intLimitQty_return As Integer

		' Token: 0x040069FA RID: 27130
		Private ntid As String

		' Token: 0x040069FB RID: 27131
		Private Dad As SqlDataAdapter

		' Token: 0x040069FC RID: 27132
		Private Dst As DataSet

		' Token: 0x040069FD RID: 27133
		Private CurrentRow As Object

		' Token: 0x040069FE RID: 27134
		Private voice As Object

		' Token: 0x040069FF RID: 27135
		Private a1 As String

		' Token: 0x04006A00 RID: 27136
		Private a2 As String

		' Token: 0x04006A01 RID: 27137
		Private InvDateSts As String

		' Token: 0x04006A02 RID: 27138
		Private prevdate As DateTime
	End Class
End Namespace
