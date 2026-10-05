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
	' Token: 0x02000362 RID: 866
	<DesignerGenerated()>
	Public Partial Class frmPromotionalOffers
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600CD32 RID: 52530 RVA: 0x0005B3F1 File Offset: 0x000595F1
		Public Sub New()
			AddHandler MyBase.KeyDown, AddressOf Me.frmPromotionalOffer_KeyDown
			AddHandler MyBase.Load, AddressOf Me.frmPromotionalOffers_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x170050A1 RID: 20641
		' (get) Token: 0x0600CD35 RID: 52533 RVA: 0x0005B423 File Offset: 0x00059623
		' (set) Token: 0x0600CD36 RID: 52534 RVA: 0x0005B42D File Offset: 0x0005962D
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170050A2 RID: 20642
		' (get) Token: 0x0600CD37 RID: 52535 RVA: 0x0005B436 File Offset: 0x00059636
		' (set) Token: 0x0600CD38 RID: 52536 RVA: 0x0005B440 File Offset: 0x00059640
		Friend Overridable Property Panel4 As Panel

		' Token: 0x170050A3 RID: 20643
		' (get) Token: 0x0600CD39 RID: 52537 RVA: 0x0005B449 File Offset: 0x00059649
		' (set) Token: 0x0600CD3A RID: 52538 RVA: 0x0005B453 File Offset: 0x00059653
		Friend Overridable Property Label3 As Label

		' Token: 0x170050A4 RID: 20644
		' (get) Token: 0x0600CD3B RID: 52539 RVA: 0x0005B45C File Offset: 0x0005965C
		' (set) Token: 0x0600CD3C RID: 52540 RVA: 0x00806E0C File Offset: 0x0080500C
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
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x170050A5 RID: 20645
		' (get) Token: 0x0600CD3D RID: 52541 RVA: 0x0005B466 File Offset: 0x00059666
		' (set) Token: 0x0600CD3E RID: 52542 RVA: 0x0005B470 File Offset: 0x00059670
		Friend Overridable Property Label1 As Label

		' Token: 0x170050A6 RID: 20646
		' (get) Token: 0x0600CD3F RID: 52543 RVA: 0x0005B479 File Offset: 0x00059679
		' (set) Token: 0x0600CD40 RID: 52544 RVA: 0x0005B483 File Offset: 0x00059683
		Friend Overridable Property Label7 As Label

		' Token: 0x170050A7 RID: 20647
		' (get) Token: 0x0600CD41 RID: 52545 RVA: 0x0005B48C File Offset: 0x0005968C
		' (set) Token: 0x0600CD42 RID: 52546 RVA: 0x0005B496 File Offset: 0x00059696
		Friend Overridable Property lblUser As Label

		' Token: 0x170050A8 RID: 20648
		' (get) Token: 0x0600CD43 RID: 52547 RVA: 0x0005B49F File Offset: 0x0005969F
		' (set) Token: 0x0600CD44 RID: 52548 RVA: 0x0005B4A9 File Offset: 0x000596A9
		Friend Overridable Property chkActive As CheckBox

		' Token: 0x170050A9 RID: 20649
		' (get) Token: 0x0600CD45 RID: 52549 RVA: 0x0005B4B2 File Offset: 0x000596B2
		' (set) Token: 0x0600CD46 RID: 52550 RVA: 0x0005B4BC File Offset: 0x000596BC
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x170050AA RID: 20650
		' (get) Token: 0x0600CD47 RID: 52551 RVA: 0x0005B4C5 File Offset: 0x000596C5
		' (set) Token: 0x0600CD48 RID: 52552 RVA: 0x0005B4CF File Offset: 0x000596CF
		Friend Overridable Property txtSearchByProduct As TextBox

		' Token: 0x170050AB RID: 20651
		' (get) Token: 0x0600CD49 RID: 52553 RVA: 0x0005B4D8 File Offset: 0x000596D8
		' (set) Token: 0x0600CD4A RID: 52554 RVA: 0x0005B4E2 File Offset: 0x000596E2
		Friend Overridable Property txtID As TextBox

		' Token: 0x170050AC RID: 20652
		' (get) Token: 0x0600CD4B RID: 52555 RVA: 0x0005B4EB File Offset: 0x000596EB
		' (set) Token: 0x0600CD4C RID: 52556 RVA: 0x0005B4F5 File Offset: 0x000596F5
		Friend Overridable Property Label15 As Label

		' Token: 0x170050AD RID: 20653
		' (get) Token: 0x0600CD4D RID: 52557 RVA: 0x0005B4FE File Offset: 0x000596FE
		' (set) Token: 0x0600CD4E RID: 52558 RVA: 0x00806E6C File Offset: 0x0080506C
		Private _txtGetFreeQty As TextBox
		Friend Overridable Property txtGetFreeQty As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtGetFreeQty
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtBuyMinqty_KeyPress
				Dim textBox As TextBox = Me._txtGetFreeQty
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._txtGetFreeQty = value
				textBox = Me._txtGetFreeQty
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x170050AE RID: 20654
		' (get) Token: 0x0600CD4F RID: 52559 RVA: 0x0005B508 File Offset: 0x00059708
		' (set) Token: 0x0600CD50 RID: 52560 RVA: 0x00806EB0 File Offset: 0x008050B0
		Private _txtBuyMinqty As TextBox
		Friend Overridable Property txtBuyMinqty As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBuyMinqty
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtBuyMinqty_KeyPress
				Dim textBox As TextBox = Me._txtBuyMinqty
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._txtBuyMinqty = value
				textBox = Me._txtBuyMinqty
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x170050AF RID: 20655
		' (get) Token: 0x0600CD51 RID: 52561 RVA: 0x0005B512 File Offset: 0x00059712
		' (set) Token: 0x0600CD52 RID: 52562 RVA: 0x0005B51C File Offset: 0x0005971C
		Friend Overridable Property dtpEntryDate As DateTimePicker

		' Token: 0x170050B0 RID: 20656
		' (get) Token: 0x0600CD53 RID: 52563 RVA: 0x0005B525 File Offset: 0x00059725
		' (set) Token: 0x0600CD54 RID: 52564 RVA: 0x0005B52F File Offset: 0x0005972F
		Friend Overridable Property dtpExpiryDate As DateTimePicker

		' Token: 0x170050B1 RID: 20657
		' (get) Token: 0x0600CD55 RID: 52565 RVA: 0x0005B538 File Offset: 0x00059738
		' (set) Token: 0x0600CD56 RID: 52566 RVA: 0x00806EF4 File Offset: 0x008050F4
		Private _chkIsExpired As CheckBox
		Friend Overridable Property chkIsExpired As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chkIsExpired
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkIsExpired_CheckedChanged
				Dim checkBox As CheckBox = Me._chkIsExpired
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chkIsExpired = value
				checkBox = Me._chkIsExpired
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170050B2 RID: 20658
		' (get) Token: 0x0600CD57 RID: 52567 RVA: 0x0005B542 File Offset: 0x00059742
		' (set) Token: 0x0600CD58 RID: 52568 RVA: 0x0005B54C File Offset: 0x0005974C
		Friend Overridable Property Label10 As Label

		' Token: 0x170050B3 RID: 20659
		' (get) Token: 0x0600CD59 RID: 52569 RVA: 0x0005B555 File Offset: 0x00059755
		' (set) Token: 0x0600CD5A RID: 52570 RVA: 0x0005B55F File Offset: 0x0005975F
		Friend Overridable Property Label9 As Label

		' Token: 0x170050B4 RID: 20660
		' (get) Token: 0x0600CD5B RID: 52571 RVA: 0x0005B568 File Offset: 0x00059768
		' (set) Token: 0x0600CD5C RID: 52572 RVA: 0x00806F38 File Offset: 0x00805138
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

		' Token: 0x170050B5 RID: 20661
		' (get) Token: 0x0600CD5D RID: 52573 RVA: 0x0005B572 File Offset: 0x00059772
		' (set) Token: 0x0600CD5E RID: 52574 RVA: 0x0005B57C File Offset: 0x0005977C
		Friend Overridable Property txtProductCode As TextBox

		' Token: 0x170050B6 RID: 20662
		' (get) Token: 0x0600CD5F RID: 52575 RVA: 0x0005B585 File Offset: 0x00059785
		' (set) Token: 0x0600CD60 RID: 52576 RVA: 0x0005B58F File Offset: 0x0005978F
		Friend Overridable Property txtProductID As TextBox

		' Token: 0x170050B7 RID: 20663
		' (get) Token: 0x0600CD61 RID: 52577 RVA: 0x0005B598 File Offset: 0x00059798
		' (set) Token: 0x0600CD62 RID: 52578 RVA: 0x0005B5A2 File Offset: 0x000597A2
		Friend Overridable Property Label5 As Label

		' Token: 0x170050B8 RID: 20664
		' (get) Token: 0x0600CD63 RID: 52579 RVA: 0x0005B5AB File Offset: 0x000597AB
		' (set) Token: 0x0600CD64 RID: 52580 RVA: 0x0005B5B5 File Offset: 0x000597B5
		Friend Overridable Property Label4 As Label

		' Token: 0x170050B9 RID: 20665
		' (get) Token: 0x0600CD65 RID: 52581 RVA: 0x0005B5BE File Offset: 0x000597BE
		' (set) Token: 0x0600CD66 RID: 52582 RVA: 0x0005B5C8 File Offset: 0x000597C8
		Friend Overridable Property txtProductName As TextBox

		' Token: 0x170050BA RID: 20666
		' (get) Token: 0x0600CD67 RID: 52583 RVA: 0x0005B5D1 File Offset: 0x000597D1
		' (set) Token: 0x0600CD68 RID: 52584 RVA: 0x0005B5DB File Offset: 0x000597DB
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x170050BB RID: 20667
		' (get) Token: 0x0600CD69 RID: 52585 RVA: 0x0005B5E4 File Offset: 0x000597E4
		' (set) Token: 0x0600CD6A RID: 52586 RVA: 0x0005B5EE File Offset: 0x000597EE
		Friend Overridable Property Label8 As Label

		' Token: 0x170050BC RID: 20668
		' (get) Token: 0x0600CD6B RID: 52587 RVA: 0x0005B5F7 File Offset: 0x000597F7
		' (set) Token: 0x0600CD6C RID: 52588 RVA: 0x0005B601 File Offset: 0x00059801
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x170050BD RID: 20669
		' (get) Token: 0x0600CD6D RID: 52589 RVA: 0x0005B60A File Offset: 0x0005980A
		' (set) Token: 0x0600CD6E RID: 52590 RVA: 0x0005B614 File Offset: 0x00059814
		Friend Overridable Property Label11 As Label

		' Token: 0x170050BE RID: 20670
		' (get) Token: 0x0600CD6F RID: 52591 RVA: 0x0005B61D File Offset: 0x0005981D
		' (set) Token: 0x0600CD70 RID: 52592 RVA: 0x0005B627 File Offset: 0x00059827
		Friend Overridable Property DateTimePicker2 As DateTimePicker

		' Token: 0x170050BF RID: 20671
		' (get) Token: 0x0600CD71 RID: 52593 RVA: 0x0005B630 File Offset: 0x00059830
		' (set) Token: 0x0600CD72 RID: 52594 RVA: 0x0005B63A File Offset: 0x0005983A
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170050C0 RID: 20672
		' (get) Token: 0x0600CD73 RID: 52595 RVA: 0x0005B643 File Offset: 0x00059843
		' (set) Token: 0x0600CD74 RID: 52596 RVA: 0x0005B64D File Offset: 0x0005984D
		Friend Overridable Property Label2 As Label

		' Token: 0x170050C1 RID: 20673
		' (get) Token: 0x0600CD75 RID: 52597 RVA: 0x0005B656 File Offset: 0x00059856
		' (set) Token: 0x0600CD76 RID: 52598 RVA: 0x0005B660 File Offset: 0x00059860
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x170050C2 RID: 20674
		' (get) Token: 0x0600CD77 RID: 52599 RVA: 0x0005B669 File Offset: 0x00059869
		' (set) Token: 0x0600CD78 RID: 52600 RVA: 0x0005B673 File Offset: 0x00059873
		Friend Overridable Property Label6 As Label

		' Token: 0x170050C3 RID: 20675
		' (get) Token: 0x0600CD79 RID: 52601 RVA: 0x0005B67C File Offset: 0x0005987C
		' (set) Token: 0x0600CD7A RID: 52602 RVA: 0x0005B686 File Offset: 0x00059886
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x170050C4 RID: 20676
		' (get) Token: 0x0600CD7B RID: 52603 RVA: 0x0005B68F File Offset: 0x0005988F
		' (set) Token: 0x0600CD7C RID: 52604 RVA: 0x00806F7C File Offset: 0x0080517C
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

		' Token: 0x170050C5 RID: 20677
		' (get) Token: 0x0600CD7D RID: 52605 RVA: 0x0005B699 File Offset: 0x00059899
		' (set) Token: 0x0600CD7E RID: 52606 RVA: 0x0005B6A3 File Offset: 0x000598A3
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170050C6 RID: 20678
		' (get) Token: 0x0600CD7F RID: 52607 RVA: 0x0005B6AC File Offset: 0x000598AC
		' (set) Token: 0x0600CD80 RID: 52608 RVA: 0x0005B6B6 File Offset: 0x000598B6
		Friend Overridable Property Description As DataGridViewTextBoxColumn

		' Token: 0x170050C7 RID: 20679
		' (get) Token: 0x0600CD81 RID: 52609 RVA: 0x0005B6BF File Offset: 0x000598BF
		' (set) Token: 0x0600CD82 RID: 52610 RVA: 0x0005B6C9 File Offset: 0x000598C9
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170050C8 RID: 20680
		' (get) Token: 0x0600CD83 RID: 52611 RVA: 0x0005B6D2 File Offset: 0x000598D2
		' (set) Token: 0x0600CD84 RID: 52612 RVA: 0x0005B6DC File Offset: 0x000598DC
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170050C9 RID: 20681
		' (get) Token: 0x0600CD85 RID: 52613 RVA: 0x0005B6E5 File Offset: 0x000598E5
		' (set) Token: 0x0600CD86 RID: 52614 RVA: 0x0005B6EF File Offset: 0x000598EF
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170050CA RID: 20682
		' (get) Token: 0x0600CD87 RID: 52615 RVA: 0x0005B6F8 File Offset: 0x000598F8
		' (set) Token: 0x0600CD88 RID: 52616 RVA: 0x0005B702 File Offset: 0x00059902
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170050CB RID: 20683
		' (get) Token: 0x0600CD89 RID: 52617 RVA: 0x0005B70B File Offset: 0x0005990B
		' (set) Token: 0x0600CD8A RID: 52618 RVA: 0x0005B715 File Offset: 0x00059915
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x170050CC RID: 20684
		' (get) Token: 0x0600CD8B RID: 52619 RVA: 0x0005B71E File Offset: 0x0005991E
		' (set) Token: 0x0600CD8C RID: 52620 RVA: 0x0005B728 File Offset: 0x00059928
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170050CD RID: 20685
		' (get) Token: 0x0600CD8D RID: 52621 RVA: 0x0005B731 File Offset: 0x00059931
		' (set) Token: 0x0600CD8E RID: 52622 RVA: 0x0005B73B File Offset: 0x0005993B
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x170050CE RID: 20686
		' (get) Token: 0x0600CD8F RID: 52623 RVA: 0x0005B744 File Offset: 0x00059944
		' (set) Token: 0x0600CD90 RID: 52624 RVA: 0x0005B74E File Offset: 0x0005994E
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170050CF RID: 20687
		' (get) Token: 0x0600CD91 RID: 52625 RVA: 0x0005B757 File Offset: 0x00059957
		' (set) Token: 0x0600CD92 RID: 52626 RVA: 0x0005B761 File Offset: 0x00059961
		Friend Overridable Property lblBarcode As Label

		' Token: 0x170050D0 RID: 20688
		' (get) Token: 0x0600CD93 RID: 52627 RVA: 0x0005B76A File Offset: 0x0005996A
		' (set) Token: 0x0600CD94 RID: 52628 RVA: 0x0005B774 File Offset: 0x00059974
		Friend Overridable Property Label12 As Label

		' Token: 0x170050D1 RID: 20689
		' (get) Token: 0x0600CD95 RID: 52629 RVA: 0x0005B77D File Offset: 0x0005997D
		' (set) Token: 0x0600CD96 RID: 52630 RVA: 0x0005B787 File Offset: 0x00059987
		Friend Overridable Property Label13 As Label

		' Token: 0x170050D2 RID: 20690
		' (get) Token: 0x0600CD97 RID: 52631 RVA: 0x0005B790 File Offset: 0x00059990
		' (set) Token: 0x0600CD98 RID: 52632 RVA: 0x00806FC0 File Offset: 0x008051C0
		Private _cmbProductName As ComboBox
		Friend Overridable Property cmbProductName As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbProductName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbProductName_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbProductName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbProductName = value
				comboBox = Me._cmbProductName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170050D3 RID: 20691
		' (get) Token: 0x0600CD99 RID: 52633 RVA: 0x0005B79A File Offset: 0x0005999A
		' (set) Token: 0x0600CD9A RID: 52634 RVA: 0x0005B7A4 File Offset: 0x000599A4
		Friend Overridable Property Label14 As Label

		' Token: 0x170050D4 RID: 20692
		' (get) Token: 0x0600CD9B RID: 52635 RVA: 0x0005B7AD File Offset: 0x000599AD
		' (set) Token: 0x0600CD9C RID: 52636 RVA: 0x00807004 File Offset: 0x00805204
		Private _cmbCategory As ComboBox
		Friend Overridable Property cmbCategory As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbCategory_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbCategory = value
				comboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170050D5 RID: 20693
		' (get) Token: 0x0600CD9D RID: 52637 RVA: 0x0005B7B7 File Offset: 0x000599B7
		' (set) Token: 0x0600CD9E RID: 52638 RVA: 0x0005B7C1 File Offset: 0x000599C1
		Friend Overridable Property ListView1 As ListView

		' Token: 0x170050D6 RID: 20694
		' (get) Token: 0x0600CD9F RID: 52639 RVA: 0x0005B7CA File Offset: 0x000599CA
		' (set) Token: 0x0600CDA0 RID: 52640 RVA: 0x0005B7D4 File Offset: 0x000599D4
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x170050D7 RID: 20695
		' (get) Token: 0x0600CDA1 RID: 52641 RVA: 0x0005B7DD File Offset: 0x000599DD
		' (set) Token: 0x0600CDA2 RID: 52642 RVA: 0x0005B7E7 File Offset: 0x000599E7
		Friend Overridable Property Category As ColumnHeader

		' Token: 0x170050D8 RID: 20696
		' (get) Token: 0x0600CDA3 RID: 52643 RVA: 0x0005B7F0 File Offset: 0x000599F0
		' (set) Token: 0x0600CDA4 RID: 52644 RVA: 0x0005B7FA File Offset: 0x000599FA
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x170050D9 RID: 20697
		' (get) Token: 0x0600CDA5 RID: 52645 RVA: 0x0005B803 File Offset: 0x00059A03
		' (set) Token: 0x0600CDA6 RID: 52646 RVA: 0x0005B80D File Offset: 0x00059A0D
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x170050DA RID: 20698
		' (get) Token: 0x0600CDA7 RID: 52647 RVA: 0x0005B816 File Offset: 0x00059A16
		' (set) Token: 0x0600CDA8 RID: 52648 RVA: 0x00807048 File Offset: 0x00805248
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

		' Token: 0x170050DB RID: 20699
		' (get) Token: 0x0600CDA9 RID: 52649 RVA: 0x0005B820 File Offset: 0x00059A20
		' (set) Token: 0x0600CDAA RID: 52650 RVA: 0x0005B82A File Offset: 0x00059A2A
		Friend Overridable Property ColumnHeader1 As ColumnHeader

		' Token: 0x170050DC RID: 20700
		' (get) Token: 0x0600CDAB RID: 52651 RVA: 0x0005B833 File Offset: 0x00059A33
		' (set) Token: 0x0600CDAC RID: 52652 RVA: 0x0005B83D File Offset: 0x00059A3D
		Friend Overridable Property Label16 As Label

		' Token: 0x170050DD RID: 20701
		' (get) Token: 0x0600CDAD RID: 52653 RVA: 0x0005B846 File Offset: 0x00059A46
		' (set) Token: 0x0600CDAE RID: 52654 RVA: 0x0080708C File Offset: 0x0080528C
		Private _cmbSubCat As ComboBox
		Friend Overridable Property cmbSubCat As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSubCat
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbSubCat_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbSubCat
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbSubCat = value
				comboBox = Me._cmbSubCat
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170050DE RID: 20702
		' (get) Token: 0x0600CDAF RID: 52655 RVA: 0x0005B850 File Offset: 0x00059A50
		' (set) Token: 0x0600CDB0 RID: 52656 RVA: 0x008070D0 File Offset: 0x008052D0
		Private _btnShowAll As GelButton
		Friend Overridable Property btnShowAll As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnShowAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click
				Dim gelButton As GelButton = Me._btnShowAll
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnShowAll = value
				gelButton = Me._btnShowAll
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170050DF RID: 20703
		' (get) Token: 0x0600CDB1 RID: 52657 RVA: 0x0005B85A File Offset: 0x00059A5A
		' (set) Token: 0x0600CDB2 RID: 52658 RVA: 0x00807114 File Offset: 0x00805314
		Private _btnProductData As GelButton
		Friend Overridable Property btnProductData As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnProductData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnProductData_Click
				Dim gelButton As GelButton = Me._btnProductData
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnProductData = value
				gelButton = Me._btnProductData
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170050E0 RID: 20704
		' (get) Token: 0x0600CDB3 RID: 52659 RVA: 0x0005B864 File Offset: 0x00059A64
		' (set) Token: 0x0600CDB4 RID: 52660 RVA: 0x00807158 File Offset: 0x00805358
		Private _btnUpdate As GelButton
		Friend Overridable Property btnUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.frmUpdate_Click
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

		' Token: 0x170050E1 RID: 20705
		' (get) Token: 0x0600CDB5 RID: 52661 RVA: 0x0005B86E File Offset: 0x00059A6E
		' (set) Token: 0x0600CDB6 RID: 52662 RVA: 0x0080719C File Offset: 0x0080539C
		Private _btnDelete As GelButton
		Friend Overridable Property btnDelete As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.frmDelete_Click
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

		' Token: 0x170050E2 RID: 20706
		' (get) Token: 0x0600CDB7 RID: 52663 RVA: 0x0005B878 File Offset: 0x00059A78
		' (set) Token: 0x0600CDB8 RID: 52664 RVA: 0x008071E0 File Offset: 0x008053E0
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

		' Token: 0x170050E3 RID: 20707
		' (get) Token: 0x0600CDB9 RID: 52665 RVA: 0x0005B882 File Offset: 0x00059A82
		' (set) Token: 0x0600CDBA RID: 52666 RVA: 0x00807224 File Offset: 0x00805424
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

		' Token: 0x170050E4 RID: 20708
		' (get) Token: 0x0600CDBB RID: 52667 RVA: 0x0005B88C File Offset: 0x00059A8C
		' (set) Token: 0x0600CDBC RID: 52668 RVA: 0x00807268 File Offset: 0x00805468
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

		' Token: 0x170050E5 RID: 20709
		' (get) Token: 0x0600CDBD RID: 52669 RVA: 0x0005B896 File Offset: 0x00059A96
		' (set) Token: 0x0600CDBE RID: 52670 RVA: 0x008072AC File Offset: 0x008054AC
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

		' Token: 0x170050E6 RID: 20710
		' (get) Token: 0x0600CDBF RID: 52671 RVA: 0x0005B8A0 File Offset: 0x00059AA0
		' (set) Token: 0x0600CDC0 RID: 52672 RVA: 0x008072F0 File Offset: 0x008054F0
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

		' Token: 0x170050E7 RID: 20711
		' (get) Token: 0x0600CDC1 RID: 52673 RVA: 0x0005B8AA File Offset: 0x00059AAA
		' (set) Token: 0x0600CDC2 RID: 52674 RVA: 0x00807334 File Offset: 0x00805534
		Private _GelButton3 As GelButton
		Friend Overridable Property GelButton3 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click_1
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

		' Token: 0x170050E8 RID: 20712
		' (get) Token: 0x0600CDC3 RID: 52675 RVA: 0x0005B8B4 File Offset: 0x00059AB4
		' (set) Token: 0x0600CDC4 RID: 52676 RVA: 0x00807378 File Offset: 0x00805578
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

		' Token: 0x170050E9 RID: 20713
		' (get) Token: 0x0600CDC5 RID: 52677 RVA: 0x0005B8BE File Offset: 0x00059ABE
		' (set) Token: 0x0600CDC6 RID: 52678 RVA: 0x008073BC File Offset: 0x008055BC
		Private _btnDelete1 As GelButton
		Friend Overridable Property btnDelete1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton5_Click
				Dim gelButton As GelButton = Me._btnDelete1
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDelete1 = value
				gelButton = Me._btnDelete1
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170050EA RID: 20714
		' (get) Token: 0x0600CDC7 RID: 52679 RVA: 0x0005B8C8 File Offset: 0x00059AC8
		' (set) Token: 0x0600CDC8 RID: 52680 RVA: 0x00807400 File Offset: 0x00805600
		Private _btnDelete2 As GelButton
		Friend Overridable Property btnDelete2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton6_Click
				Dim gelButton As GelButton = Me._btnDelete2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDelete2 = value
				gelButton = Me._btnDelete2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170050EB RID: 20715
		' (get) Token: 0x0600CDC9 RID: 52681 RVA: 0x0005B8D2 File Offset: 0x00059AD2
		' (set) Token: 0x0600CDCA RID: 52682 RVA: 0x00807444 File Offset: 0x00805644
		Private _btnDisable As GelButton
		Friend Overridable Property btnDisable As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDisable
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton7_Click
				Dim gelButton As GelButton = Me._btnDisable
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDisable = value
				gelButton = Me._btnDisable
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600CDCB RID: 52683 RVA: 0x00807488 File Offset: 0x00805688
		Public Sub Reset()
			Me.txtID.Text = ""
			Me.txtGetFreeQty.Text = ""
			Me.txtBuyMinqty.Text = ""
			Me.txtSearchByProduct.Text = ""
			Me.txtProductID.Text = ""
			Me.txtProductCode.Text = ""
			Me.txtProductName.Text = ""
			Me.chkActive.Checked = True
			Me.chkIsExpired.Checked = False
			Me.dtpEntryDate.Value = DateAndTime.Now
			Me.dtpExpiryDate.Value = DateAndTime.Today
			Me.dtpExpiryDate.Enabled = False
			Me.btnSave.Enabled = True
			Me.btnDelete1.Enabled = True
			Me.btnDelete2.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.btnDelete.Enabled = False
			Me.btnDisable.Enabled = True
			Me.dtpDateFrom.Value = DateAndTime.Today
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.DateTimePicker1.Value = DateAndTime.Today
			Me.DateTimePicker2.Value = DateAndTime.Today
			Me.dgw.Rows.Clear()
			Me.Reset1()
		End Sub

		' Token: 0x0600CDCC RID: 52684 RVA: 0x00807600 File Offset: 0x00805800
		Private Sub Reset1()
			Me.txtID.Text = ""
			Me.cmbProductName.SelectedIndex = -1
			Me.cmbCategory.SelectedIndex = -1
			Me.cmbSubCat.SelectedIndex = -1
			Me.cmbCategory.Focus()
			Me.lblBarcode.Text = ""
			Me.ListView1.Items.Clear()
		End Sub

		' Token: 0x0600CDCD RID: 52685 RVA: 0x00807674 File Offset: 0x00805874
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = If(("delete from Promotion where ProductID=" + Conversions.ToString(Conversion.Val(Me.txtProductID.Text))), "")
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
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

		' Token: 0x0600CDCE RID: 52686 RVA: 0x00807788 File Offset: 0x00805988
		Public Sub GetAllActiveOffers()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,EntryDate,PID,RTRIM(ProductCode),RTRIM(ProductName),MinQty,FreeQty,RTRIM(IsExpired),ExpiryDate,RTRIM(Active) from Promotion INNER JOIN Product ON Promotion.ProductID=Product.PID where Active='Yes' and CAST(GETDATE() as DATE) < ExpiryDate order by 4,9", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CDCF RID: 52687 RVA: 0x00807900 File Offset: 0x00805B00
		Public Sub GetAllInActiveOffers()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,EntryDate,PID,RTRIM(ProductCode),RTRIM(ProductName),MinQty,FreeQty,RTRIM(IsExpired),ExpiryDate,RTRIM(Active) from Promotion INNER JOIN Product ON Promotion.ProductID=Product.PID where Active='No' order by 4,9", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CDD0 RID: 52688 RVA: 0x00807A78 File Offset: 0x00805C78
		Public Sub GetAllExpiredOffers()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,EntryDate,PID,RTRIM(ProductCode),RTRIM(ProductName),MinQty,FreeQty,RTRIM(IsExpired),ExpiryDate,RTRIM(Active) from Promotion INNER JOIN Product ON Promotion.ProductID=Product.PID where CAST(GETDATE() as DATE) > ExpiryDate order by 4,9", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CDD1 RID: 52689 RVA: 0x00807BF0 File Offset: 0x00805DF0
		Private Sub dgw_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dgw.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.dgw.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim controlText As Brush = SystemBrushes.ControlText
			e.Graphics.DrawString(text, Me.Font, controlText, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600CDD2 RID: 52690 RVA: 0x00807CD8 File Offset: 0x00805ED8
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.dtpEntryDate.Value = Conversions.ToDate(dataGridViewRow.Cells(1).Value)
					Me.txtProductID.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtBuyMinqty.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.txtGetFreeQty.Text = dataGridViewRow.Cells(6).Value.ToString()
					Dim flag2 As Boolean = Operators.CompareString(dataGridViewRow.Cells(7).Value.ToString(), "Yes", False) = 0
					If flag2 Then
						Me.chkIsExpired.Checked = True
						Me.dtpExpiryDate.Value = Conversions.ToDate(dataGridViewRow.Cells(8).Value)
					Else
						Me.chkIsExpired.Checked = False
						Me.dtpExpiryDate.Value = DateAndTime.Today
					End If
					Dim flag3 As Boolean = Operators.CompareString(dataGridViewRow.Cells(9).Value.ToString(), "Yes", False) = 0
					If flag3 Then
						Me.chkActive.Checked = True
					Else
						Me.chkActive.Checked = False
					End If
					Me.btnDelete.Enabled = True
					Me.btnUpdate.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CDD3 RID: 52691 RVA: 0x00807EEC File Offset: 0x008060EC
		Private Sub chkIsExpired_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkIsExpired.Checked
			If checked Then
				Me.dtpExpiryDate.Enabled = True
			Else
				Me.dtpExpiryDate.Enabled = False
			End If
		End Sub

		' Token: 0x0600CDD4 RID: 52692 RVA: 0x0005B8DC File Offset: 0x00059ADC
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600CDD5 RID: 52693 RVA: 0x00807F28 File Offset: 0x00806128
		Private Sub frmPromotionalOffer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				MyBase.SelectNextControl(MyBase.ActiveControl, True, True, True, False)
			End If
			Dim flag2 As Boolean = e.KeyCode = Keys.F1
			If flag2 Then
				e.Handled = True
				Me.btnSelection.PerformClick()
			End If
			Dim flag3 As Boolean = e.KeyCode = Keys.Escape
			If flag3 Then
				e.Handled = True
				Dim flag4 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag4 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600CDD6 RID: 52694 RVA: 0x0005B8F8 File Offset: 0x00059AF8
		Private Sub btnSelection_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProductRecord.lblSet.Text = "Promotion"
			MyProject.Forms.frmProductRecord.Reset()
			MyProject.Forms.frmProductRecord.ShowDialog()
		End Sub

		' Token: 0x0600CDD7 RID: 52695 RVA: 0x0005B935 File Offset: 0x00059B35
		Private Sub btnShowAllActiveOffers_Click(sender As Object, e As EventArgs)
			Me.GetAllActiveOffers()
		End Sub

		' Token: 0x0600CDD8 RID: 52696 RVA: 0x00807FB8 File Offset: 0x008061B8
		Private Sub frmPromotionalOffers_Load(sender As Object, e As EventArgs)
			Me.fillCategory()
			Me.fillItem()
			Me.cat()
			Me.lblBarcode.Text = ""
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Reset()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600CDD9 RID: 52697 RVA: 0x00808068 File Offset: 0x00806268
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
						Me.UpdateControlsRecursive(Me)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x0600CDDA RID: 52698 RVA: 0x008081E0 File Offset: 0x008063E0
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

		' Token: 0x0600CDDB RID: 52699 RVA: 0x0080829C File Offset: 0x0080649C
		Private Sub UpdateControlsRecursive(parent As Control)
			Try
				For Each obj As Object In parent.Controls
					Dim control As Control = CType(obj, Control)
					Dim flag As Boolean = TypeOf control Is DataGridView
					If flag Then
						Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
					Else
						Dim flag2 As Boolean = TypeOf control Is ListView
						If flag2 Then
							Me.UpdateListViewHeaders(CType(control, ListView))
						End If
					End If
					Dim hasChildren As Boolean = control.HasChildren
					If hasChildren Then
						Me.UpdateControlsRecursive(control)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600CDDC RID: 52700 RVA: 0x000B726C File Offset: 0x000B546C
		Private Sub UpdateDataGridViewHeaders(dgv As DataGridView)
			Try
				For Each obj As Object In dgv.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(dataGridViewColumn.HeaderText)
					If flag Then
						dataGridViewColumn.HeaderText = GlobalVariables.translations(dataGridViewColumn.HeaderText)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600CDDD RID: 52701 RVA: 0x000B72F4 File Offset: 0x000B54F4
		Private Sub UpdateListViewHeaders(lv As ListView)
			Try
				For Each obj As Object In lv.Columns
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
			Try
				For Each obj2 As Object In lv.Items
					Dim listViewItem As ListViewItem = CType(obj2, ListViewItem)
					Dim flag2 As Boolean = GlobalVariables.translations.ContainsKey(listViewItem.Text)
					If flag2 Then
						listViewItem.Text = GlobalVariables.translations(listViewItem.Text)
					End If
					Try
						For Each obj3 As Object In listViewItem.SubItems
							Dim listViewSubItem As ListViewItem.ListViewSubItem = CType(obj3, ListViewItem.ListViewSubItem)
							Dim flag3 As Boolean = GlobalVariables.translations.ContainsKey(listViewSubItem.Text)
							If flag3 Then
								listViewSubItem.Text = GlobalVariables.translations(listViewSubItem.Text)
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
		End Sub

		' Token: 0x0600CDDE RID: 52702 RVA: 0x0008BE54 File Offset: 0x0008A054
		Private Sub txtBuyMinqty_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = ((e.KeyChar < "0"c) Or (e.KeyChar > "9"c)) And (e.KeyChar <> vbBack)
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600CDDF RID: 52703 RVA: 0x00808348 File Offset: 0x00806548
		Private Sub fillCategory()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(CategoryName) FROM Category order by 1", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbCategory.Items.Clear()
				Try
					Try
						For Each obj As Object In ModCommonClasses.dtable.Rows
							Dim objectValue As Object = RuntimeHelpers.GetObjectValue(obj)
							Dim dataRow As DataRow = CType(objectValue, DataRow)
							Me.cmbCategory.Items.Add(dataRow(0).ToString())
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				Finally
					Dim enumerator2 As IEnumerator
					Dim flag As Boolean = TypeOf enumerator2 Is IDisposable
					Dim flag2 As Boolean = flag
					If flag2 Then
						TryCast(enumerator2, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CDE0 RID: 52704 RVA: 0x008084DC File Offset: 0x008066DC
		Public Sub fillItem()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(ProductName) FROM Product order by 1", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbProductName.Items.Clear()
				Try
					Try
						For Each obj As Object In ModCommonClasses.dtable.Rows
							Dim objectValue As Object = RuntimeHelpers.GetObjectValue(obj)
							Dim dataRow As DataRow = CType(objectValue, DataRow)
							Me.cmbProductName.Items.Add(dataRow(0).ToString())
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				Finally
					Dim enumerator2 As IEnumerator
					Dim flag As Boolean = TypeOf enumerator2 Is IDisposable
					Dim flag2 As Boolean = flag
					If flag2 Then
						TryCast(enumerator2, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CDE1 RID: 52705 RVA: 0x00808670 File Offset: 0x00806870
		Private Sub Getdata()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category.CategoryName), RTRIM(SubCategory.SubCategoryName), Product.PID FROM Product,category,subcategory where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID order by (Product.ProductName) ASC;"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					Me.ListView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.ListView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.ListView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CDE2 RID: 52706 RVA: 0x0080882C File Offset: 0x00806A2C
		Private Sub cmbProductName_SelectedIndexChanged(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category.CategoryName), RTRIM(SubCategory.SubCategoryName), Product.PID FROM Product,category,subcategory where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Product.ProductName like N'" + Me.cmbProductName.Text + "%' order by (Product.ProductName) ASC;"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					Me.ListView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.ListView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.ListView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CDE3 RID: 52707 RVA: 0x008089FC File Offset: 0x00806BFC
		Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category.CategoryName), RTRIM(SubCategory.SubCategoryName), Product.PID FROM Product,category,subcategory where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Category.CategoryName like N'" + Me.cmbCategory.Text + "%' order by (Product.ProductName) ASC;"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					Me.ListView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.ListView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.ListView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CDE4 RID: 52708 RVA: 0x00808BCC File Offset: 0x00806DCC
		Public Sub cat()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(SubCategoryName) FROM SubCategory order by 1", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbSubCat.Items.Clear()
				Try
					Try
						For Each obj As Object In ModCommonClasses.dtable.Rows
							Dim objectValue As Object = RuntimeHelpers.GetObjectValue(obj)
							Dim dataRow As DataRow = CType(objectValue, DataRow)
							Me.cmbSubCat.Items.Add(dataRow(0).ToString())
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				Finally
					Dim enumerator2 As IEnumerator
					Dim flag As Boolean = TypeOf enumerator2 Is IDisposable
					Dim flag2 As Boolean = flag
					If flag2 Then
						TryCast(enumerator2, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CDE5 RID: 52709 RVA: 0x00808D60 File Offset: 0x00806F60
		Private Sub cmbSubCat_SelectedIndexChanged(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category.CategoryName), RTRIM(SubCategory.SubCategoryName), Product.PID FROM Product,category,subcategory where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and SubCategory.SubCategoryName like N'" + Me.cmbSubCat.Text + "%' order by (Product.ProductName) ASC;"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					Me.ListView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.ListView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.ListView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CDE6 RID: 52710 RVA: 0x0005B93F File Offset: 0x00059B3F
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600CDE7 RID: 52711 RVA: 0x00808F30 File Offset: 0x00807130
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ListView1.CheckedItems.Count = 0
			Dim flag2 As Boolean = flag
			If flag2 Then
				MessageBox.Show("Please select the product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbProductName.Focus()
			Else
				Dim flag3 As Boolean = Conversion.Val(Me.txtBuyMinqty.Text) <= 0.0
				If flag3 Then
					MessageBox.Show("Buy Min Qty. must be greater than 0", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtBuyMinqty.Focus()
				Else
					Dim flag4 As Boolean = Conversion.Val(Me.txtGetFreeQty.Text) <= 0.0
					If flag4 Then
						MessageBox.Show("Get Free Qty. must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtGetFreeQty.Focus()
					Else
						Try
							Dim checked As Boolean = Me.chkActive.Checked
							If checked Then
								Me.st1 = "Yes"
							Else
								Me.st1 = "No"
							End If
							Dim checked2 As Boolean = Me.chkIsExpired.Checked
							If checked2 Then
								Me.st2 = "Yes"
							Else
								Me.st2 = "No"
							End If
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "select ProductID from Promotion where ProductID=@d1 and (Active='No' or CAST(GETDATE() as DATE) < ExpiryDate)"
							Dim num As Integer = 0
							Dim num2 As Integer = Me.ListView1.CheckedItems.Count - 1
							Dim num3 As Integer = num
							While True
								Dim num4 As Integer = num3
								Dim num5 As Integer = num2
								Dim flag5 As Boolean = num4 > num5
								If flag5 Then
									Exit While
								End If
								ModCommonClasses.cmd = New SqlCommand(text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Me.ListView1.CheckedItems(num3).SubItems(4).Text))))
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
								If flag6 Then
									GoTo Block_9
								End If
								num3 += 1
							End While
							Try
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text2 As String = "insert into Promotion(EntryDate,ProductID,MinQty,FreeQty,IsExpired,ExpiryDate,Active) VALUES (@d1,@d4,@d7,@d8,@d9,@d10,@d11)"
								ModCommonClasses.cmd = New SqlCommand(text2)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								Dim num6 As Integer = 0
								Dim num7 As Integer = Me.ListView1.CheckedItems.Count - 1
								Dim num8 As Integer = num6
								While True
									Dim num9 As Integer = num8
									Dim num10 As Integer = num7
									Dim flag7 As Boolean = num9 > num10
									If flag7 Then
										Exit While
									End If
									ModCommonClasses.cmd.Parameters.Clear()
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.dtpEntryDate.Value)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Me.ListView1.CheckedItems(num8).SubItems(4).Text))))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtBuyMinqty.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtGetFreeQty.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.st2)
									Dim flag8 As Boolean = Operators.CompareString(Me.st2, "Yes", False) = 0
									If flag8 Then
										ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.dtpExpiryDate.Value.[Date])
									Else
										ModCommonClasses.cmd.Parameters.AddWithValue("@d10", DateAndTime.Today.AddYears(70))
									End If
									ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.st1)
									ModCommonClasses.cmd.ExecuteNonQuery()
									num8 += 1
								End While
								ModCommonClasses.con.Close()
								Dim num11 As Integer = 0
								Dim num12 As Integer = Me.ListView1.CheckedItems.Count - 1
								Dim num13 As Integer = num11
								While True
									Dim num14 As Integer = num13
									Dim num15 As Integer = num12
									Dim flag9 As Boolean = num14 > num15
									If flag9 Then
										Exit While
									End If
									ModFunc.LogFunc(Me.lblUser.Text, "added the new promotional offer '" + Me.ListView1.CheckedItems(num13).SubItems(1).Text + "'")
									num13 += 1
								End While
								MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.btnSave.Enabled = False
								Me.Reset()
							Catch ex As Exception
								MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
							GoTo IL_0561
							Block_9:
							MessageBox.Show("Promotion Already Exists for selected product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Dim flag10 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag10 Then
								ModCommonClasses.rdr.Close()
							End If
						Catch ex2 As Exception
							MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
						IL_0561:
					End If
				End If
			End If
		End Sub

		' Token: 0x0600CDE8 RID: 52712 RVA: 0x008094D4 File Offset: 0x008076D4
		Private Sub frmUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtProductID.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please retrieve product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtProductName.Focus()
			Else
				Dim flag2 As Boolean = Conversion.Val(Me.txtBuyMinqty.Text) <= 0.0
				If flag2 Then
					MessageBox.Show("Buy Min Qty. must be greater than 0", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtBuyMinqty.Focus()
				Else
					Dim flag3 As Boolean = Conversion.Val(Me.txtGetFreeQty.Text) <= 0.0
					If flag3 Then
						MessageBox.Show("Get Free Qty. must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtGetFreeQty.Focus()
					Else
						Try
							Dim checked As Boolean = Me.chkActive.Checked
							If checked Then
								Me.st1 = "Yes"
							Else
								Me.st1 = "No"
							End If
							Dim checked2 As Boolean = Me.chkIsExpired.Checked
							If checked2 Then
								Me.st2 = "Yes"
							Else
								Me.st2 = "No"
							End If
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = If(("Update Promotion set EntryDate=@d1,MinQty=@d7,FreeQty=@d8,IsExpired=@d9,ExpiryDate=@d10,Active=@d11 where ProductID=" + Conversions.ToString(Conversion.Val(Me.txtProductID.Text))), "")
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.dtpEntryDate.Value)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtBuyMinqty.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtGetFreeQty.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.st2)
							Dim flag4 As Boolean = Operators.CompareString(Me.st2, "Yes", False) = 0
							If flag4 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.dtpExpiryDate.Value.[Date])
							Else
								ModCommonClasses.cmd.Parameters.AddWithValue("@d10", DateAndTime.Today.AddYears(70))
							End If
							ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.st1)
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.Reset()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x0600CDE9 RID: 52713 RVA: 0x00809804 File Offset: 0x00807A04
		Private Sub frmDelete_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CDEA RID: 52714 RVA: 0x0005B949 File Offset: 0x00059B49
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x0600CDEB RID: 52715 RVA: 0x0080986C File Offset: 0x00807A6C
		Private Sub btnProductData_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("select id,entrydate,pid,rtrim(productcode),rtrim(productname),minqty,freeqty,rtrim(isexpired),expirydate,rtrim(active) from promotion inner join product on promotion.productid=product.pid where productname like '%" + Me.txtSearchByProduct.Text + "%' order by 4,9", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CDEC RID: 52716 RVA: 0x008099F8 File Offset: 0x00807BF8
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,EntryDate,PID,RTRIM(ProductCode),RTRIM(ProductName),MinQty,FreeQty,RTRIM(IsExpired),ExpiryDate,RTRIM(Active) from Promotion INNER JOIN Product ON Promotion.ProductID=Product.PID where EntryDate >=@d1 and EntryDate < @d2 order by 4,9", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CDED RID: 52717 RVA: 0x00809BF4 File Offset: 0x00807DF4
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,EntryDate,PID,RTRIM(ProductCode),RTRIM(ProductName),MinQty,FreeQty,RTRIM(IsExpired),ExpiryDate,RTRIM(Active) from Promotion INNER JOIN Product ON Promotion.ProductID=Product.PID where ExpiryDate >=@d1 and ExpiryDate < @d2 order by 4,9", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date].AddDays(1.0)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CDEE RID: 52718 RVA: 0x0005B935 File Offset: 0x00059B35
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Me.GetAllActiveOffers()
		End Sub

		' Token: 0x0600CDEF RID: 52719 RVA: 0x0005B953 File Offset: 0x00059B53
		Private Sub GelButton3_Click_1(sender As Object, e As EventArgs)
			Me.GetAllExpiredOffers()
		End Sub

		' Token: 0x0600CDF0 RID: 52720 RVA: 0x0005B95D File Offset: 0x00059B5D
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			Me.GetAllInActiveOffers()
		End Sub

		' Token: 0x0600CDF1 RID: 52721 RVA: 0x00809DF0 File Offset: 0x00807FF0
		Private Sub GelButton5_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete all expired offers ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "delete from Promotion where CAST(GETDATE() as DATE) > ExpiryDate"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
					Dim flag2 As Boolean = num > 0
					If flag2 Then
						MessageBox.Show(Conversions.ToString(num) + " record(s) successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Reset()
					Else
						MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Reset()
					End If
					Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag3 Then
						ModCommonClasses.con.Close()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CDF2 RID: 52722 RVA: 0x00809F0C File Offset: 0x0080810C
		Private Sub GelButton6_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete all inactive offers ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "delete from Promotion where Active='No'"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
					Dim flag2 As Boolean = num > 0
					If flag2 Then
						MessageBox.Show(Conversions.ToString(num) + " record(s) successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Reset()
					Else
						MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Reset()
					End If
					Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag3 Then
						ModCommonClasses.con.Close()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CDF3 RID: 52723 RVA: 0x0080A028 File Offset: 0x00808228
		Private Sub GelButton7_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to deactivate all active offers ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "Update Promotion set Active='No' where Active='Yes' and CAST(GETDATE() as DATE) < ExpiryDate"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
					Dim flag2 As Boolean = num > 0
					If flag2 Then
						MessageBox.Show(Conversions.ToString(num) + " record(s) successfully deactiaved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Reset()
					Else
						MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Reset()
					End If
					Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag3 Then
						ModCommonClasses.con.Close()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CDF4 RID: 52724 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub btnDisable_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600CDF5 RID: 52725 RVA: 0x0080A144 File Offset: 0x00808344
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim num As Integer = 0
			Dim num2 As Integer = Me.ListView1.Items.Count - 1
			Dim num3 As Integer = num
			While True
				Dim num4 As Integer = num3
				Dim num5 As Integer = num2
				Dim flag As Boolean = num4 > num5
				If flag Then
					Exit While
				End If
				Me.ListView1.Items(num3).Checked = Me.chkSelectAll.Checked
				num3 += 1
			End While
		End Sub

		' Token: 0x040052A4 RID: 21156
		Private st1 As String

		' Token: 0x040052A5 RID: 21157
		Private st2 As String
	End Class
End Namespace
