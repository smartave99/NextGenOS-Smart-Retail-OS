Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x02000112 RID: 274
	<DesignerGenerated()>
	Public Partial Class frmFollowUp_Lead
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002DD4 RID: 11732 RVA: 0x0001D063 File Offset: 0x0001B263
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmFollowUp_Lead_Load
			AddHandler MyBase.FormClosing, AddressOf Me.frmFollowUp_Lead_FormClosing
			Me.InitializeComponent()
		End Sub

		' Token: 0x170011D2 RID: 4562
		' (get) Token: 0x06002DD7 RID: 11735 RVA: 0x0001D095 File Offset: 0x0001B295
		' (set) Token: 0x06002DD8 RID: 11736 RVA: 0x001CA724 File Offset: 0x001C8924
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

		' Token: 0x170011D3 RID: 4563
		' (get) Token: 0x06002DD9 RID: 11737 RVA: 0x0001D09F File Offset: 0x0001B29F
		' (set) Token: 0x06002DDA RID: 11738 RVA: 0x001CA768 File Offset: 0x001C8968
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

		' Token: 0x170011D4 RID: 4564
		' (get) Token: 0x06002DDB RID: 11739 RVA: 0x0001D0A9 File Offset: 0x0001B2A9
		' (set) Token: 0x06002DDC RID: 11740 RVA: 0x001CA7AC File Offset: 0x001C89AC
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

		' Token: 0x170011D5 RID: 4565
		' (get) Token: 0x06002DDD RID: 11741 RVA: 0x0001D0B3 File Offset: 0x0001B2B3
		' (set) Token: 0x06002DDE RID: 11742 RVA: 0x001CA7F0 File Offset: 0x001C89F0
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

		' Token: 0x170011D6 RID: 4566
		' (get) Token: 0x06002DDF RID: 11743 RVA: 0x0001D0BD File Offset: 0x0001B2BD
		' (set) Token: 0x06002DE0 RID: 11744 RVA: 0x0001D0C7 File Offset: 0x0001B2C7
		Friend Overridable Property Panel3 As Panel

		' Token: 0x170011D7 RID: 4567
		' (get) Token: 0x06002DE1 RID: 11745 RVA: 0x0001D0D0 File Offset: 0x0001B2D0
		' (set) Token: 0x06002DE2 RID: 11746 RVA: 0x001CA834 File Offset: 0x001C8A34
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

		' Token: 0x170011D8 RID: 4568
		' (get) Token: 0x06002DE3 RID: 11747 RVA: 0x0001D0DA File Offset: 0x0001B2DA
		' (set) Token: 0x06002DE4 RID: 11748 RVA: 0x0001D0E4 File Offset: 0x0001B2E4
		Friend Overridable Property Label13 As Label

		' Token: 0x170011D9 RID: 4569
		' (get) Token: 0x06002DE5 RID: 11749 RVA: 0x0001D0ED File Offset: 0x0001B2ED
		' (set) Token: 0x06002DE6 RID: 11750 RVA: 0x0001D0F7 File Offset: 0x0001B2F7
		Friend Overridable Property dtpReminderDate As DateTimePicker

		' Token: 0x170011DA RID: 4570
		' (get) Token: 0x06002DE7 RID: 11751 RVA: 0x0001D100 File Offset: 0x0001B300
		' (set) Token: 0x06002DE8 RID: 11752 RVA: 0x0001D10A File Offset: 0x0001B30A
		Friend Overridable Property Label4 As Label

		' Token: 0x170011DB RID: 4571
		' (get) Token: 0x06002DE9 RID: 11753 RVA: 0x0001D113 File Offset: 0x0001B313
		' (set) Token: 0x06002DEA RID: 11754 RVA: 0x0001D11D File Offset: 0x0001B31D
		Friend Overridable Property cboxStatus As ComboBox

		' Token: 0x170011DC RID: 4572
		' (get) Token: 0x06002DEB RID: 11755 RVA: 0x0001D126 File Offset: 0x0001B326
		' (set) Token: 0x06002DEC RID: 11756 RVA: 0x0001D130 File Offset: 0x0001B330
		Friend Overridable Property Label10 As Label

		' Token: 0x170011DD RID: 4573
		' (get) Token: 0x06002DED RID: 11757 RVA: 0x0001D139 File Offset: 0x0001B339
		' (set) Token: 0x06002DEE RID: 11758 RVA: 0x0001D143 File Offset: 0x0001B343
		Friend Overridable Property txtRemarks As TextBox

		' Token: 0x170011DE RID: 4574
		' (get) Token: 0x06002DEF RID: 11759 RVA: 0x0001D14C File Offset: 0x0001B34C
		' (set) Token: 0x06002DF0 RID: 11760 RVA: 0x0001D156 File Offset: 0x0001B356
		Friend Overridable Property cmbTime As ComboBox

		' Token: 0x170011DF RID: 4575
		' (get) Token: 0x06002DF1 RID: 11761 RVA: 0x0001D15F File Offset: 0x0001B35F
		' (set) Token: 0x06002DF2 RID: 11762 RVA: 0x0001D169 File Offset: 0x0001B369
		Friend Overridable Property Label2 As Label

		' Token: 0x170011E0 RID: 4576
		' (get) Token: 0x06002DF3 RID: 11763 RVA: 0x0001D172 File Offset: 0x0001B372
		' (set) Token: 0x06002DF4 RID: 11764 RVA: 0x0001D17C File Offset: 0x0001B37C
		Friend Overridable Property Label3 As Label

		' Token: 0x170011E1 RID: 4577
		' (get) Token: 0x06002DF5 RID: 11765 RVA: 0x0001D185 File Offset: 0x0001B385
		' (set) Token: 0x06002DF6 RID: 11766 RVA: 0x0001D18F File Offset: 0x0001B38F
		Friend Overridable Property txtLead_Id As TextBox

		' Token: 0x170011E2 RID: 4578
		' (get) Token: 0x06002DF7 RID: 11767 RVA: 0x0001D198 File Offset: 0x0001B398
		' (set) Token: 0x06002DF8 RID: 11768 RVA: 0x0001D1A2 File Offset: 0x0001B3A2
		Friend Overridable Property Panel4 As Panel

		' Token: 0x170011E3 RID: 4579
		' (get) Token: 0x06002DF9 RID: 11769 RVA: 0x0001D1AB File Offset: 0x0001B3AB
		' (set) Token: 0x06002DFA RID: 11770 RVA: 0x0001D1B5 File Offset: 0x0001B3B5
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170011E4 RID: 4580
		' (get) Token: 0x06002DFB RID: 11771 RVA: 0x0001D1BE File Offset: 0x0001B3BE
		' (set) Token: 0x06002DFC RID: 11772 RVA: 0x0001D1C8 File Offset: 0x0001B3C8
		Friend Overridable Property lblUser As Label

		' Token: 0x170011E5 RID: 4581
		' (get) Token: 0x06002DFD RID: 11773 RVA: 0x0001D1D1 File Offset: 0x0001B3D1
		' (set) Token: 0x06002DFE RID: 11774 RVA: 0x0001D1DB File Offset: 0x0001B3DB
		Friend Overridable Property Label1 As Label

		' Token: 0x170011E6 RID: 4582
		' (get) Token: 0x06002DFF RID: 11775 RVA: 0x0001D1E4 File Offset: 0x0001B3E4
		' (set) Token: 0x06002E00 RID: 11776 RVA: 0x0001D1EE File Offset: 0x0001B3EE
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170011E7 RID: 4583
		' (get) Token: 0x06002E01 RID: 11777 RVA: 0x0001D1F7 File Offset: 0x0001B3F7
		' (set) Token: 0x06002E02 RID: 11778 RVA: 0x0001D201 File Offset: 0x0001B401
		Friend Overridable Property txtCustomerName As TextBox

		' Token: 0x170011E8 RID: 4584
		' (get) Token: 0x06002E03 RID: 11779 RVA: 0x0001D20A File Offset: 0x0001B40A
		' (set) Token: 0x06002E04 RID: 11780 RVA: 0x0001D214 File Offset: 0x0001B414
		Friend Overridable Property lbl_Id As Label

		' Token: 0x170011E9 RID: 4585
		' (get) Token: 0x06002E05 RID: 11781 RVA: 0x0001D21D File Offset: 0x0001B41D
		' (set) Token: 0x06002E06 RID: 11782 RVA: 0x0001D227 File Offset: 0x0001B427
		Friend Overridable Property lblUserType As Label

		' Token: 0x170011EA RID: 4586
		' (get) Token: 0x06002E07 RID: 11783 RVA: 0x0001D230 File Offset: 0x0001B430
		' (set) Token: 0x06002E08 RID: 11784 RVA: 0x001CA878 File Offset: 0x001C8A78
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
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x170011EB RID: 4587
		' (get) Token: 0x06002E09 RID: 11785 RVA: 0x0001D23A File Offset: 0x0001B43A
		' (set) Token: 0x06002E0A RID: 11786 RVA: 0x0001D244 File Offset: 0x0001B444
		Friend Overridable Property lblFollowupID As Label

		' Token: 0x170011EC RID: 4588
		' (get) Token: 0x06002E0B RID: 11787 RVA: 0x0001D24D File Offset: 0x0001B44D
		' (set) Token: 0x06002E0C RID: 11788 RVA: 0x001CA8BC File Offset: 0x001C8ABC
		Private _btnQuotation As GelButton
		Friend Overridable Property btnQuotation As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnQuotation
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnQuotation_Click
				Dim gelButton As GelButton = Me._btnQuotation
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnQuotation = value
				gelButton = Me._btnQuotation
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170011ED RID: 4589
		' (get) Token: 0x06002E0D RID: 11789 RVA: 0x0001D257 File Offset: 0x0001B457
		' (set) Token: 0x06002E0E RID: 11790 RVA: 0x0001D261 File Offset: 0x0001B461
		Friend Overridable Property Label5 As Label

		' Token: 0x170011EE RID: 4590
		' (get) Token: 0x06002E0F RID: 11791 RVA: 0x0001D26A File Offset: 0x0001B46A
		' (set) Token: 0x06002E10 RID: 11792 RVA: 0x0001D274 File Offset: 0x0001B474
		Friend Overridable Property cmbRating As ComboBox

		' Token: 0x170011EF RID: 4591
		' (get) Token: 0x06002E11 RID: 11793 RVA: 0x0001D27D File Offset: 0x0001B47D
		' (set) Token: 0x06002E12 RID: 11794 RVA: 0x0001D287 File Offset: 0x0001B487
		Friend Overridable Property Id As DataGridViewTextBoxColumn

		' Token: 0x170011F0 RID: 4592
		' (get) Token: 0x06002E13 RID: 11795 RVA: 0x0001D290 File Offset: 0x0001B490
		' (set) Token: 0x06002E14 RID: 11796 RVA: 0x0001D29A File Offset: 0x0001B49A
		Friend Overridable Property btnfollowup As DataGridViewTextBoxColumn

		' Token: 0x170011F1 RID: 4593
		' (get) Token: 0x06002E15 RID: 11797 RVA: 0x0001D2A3 File Offset: 0x0001B4A3
		' (set) Token: 0x06002E16 RID: 11798 RVA: 0x0001D2AD File Offset: 0x0001B4AD
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170011F2 RID: 4594
		' (get) Token: 0x06002E17 RID: 11799 RVA: 0x0001D2B6 File Offset: 0x0001B4B6
		' (set) Token: 0x06002E18 RID: 11800 RVA: 0x0001D2C0 File Offset: 0x0001B4C0
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170011F3 RID: 4595
		' (get) Token: 0x06002E19 RID: 11801 RVA: 0x0001D2C9 File Offset: 0x0001B4C9
		' (set) Token: 0x06002E1A RID: 11802 RVA: 0x0001D2D3 File Offset: 0x0001B4D3
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x170011F4 RID: 4596
		' (get) Token: 0x06002E1B RID: 11803 RVA: 0x0001D2DC File Offset: 0x0001B4DC
		' (set) Token: 0x06002E1C RID: 11804 RVA: 0x0001D2E6 File Offset: 0x0001B4E6
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170011F5 RID: 4597
		' (get) Token: 0x06002E1D RID: 11805 RVA: 0x0001D2EF File Offset: 0x0001B4EF
		' (set) Token: 0x06002E1E RID: 11806 RVA: 0x0001D2F9 File Offset: 0x0001B4F9
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x170011F6 RID: 4598
		' (get) Token: 0x06002E1F RID: 11807 RVA: 0x0001D302 File Offset: 0x0001B502
		' (set) Token: 0x06002E20 RID: 11808 RVA: 0x0001D30C File Offset: 0x0001B50C
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170011F7 RID: 4599
		' (get) Token: 0x06002E21 RID: 11809 RVA: 0x0001D315 File Offset: 0x0001B515
		' (set) Token: 0x06002E22 RID: 11810 RVA: 0x0001D31F File Offset: 0x0001B51F
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170011F8 RID: 4600
		' (get) Token: 0x06002E23 RID: 11811 RVA: 0x0001D328 File Offset: 0x0001B528
		' (set) Token: 0x06002E24 RID: 11812 RVA: 0x0001D332 File Offset: 0x0001B532
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170011F9 RID: 4601
		' (get) Token: 0x06002E25 RID: 11813 RVA: 0x0001D33B File Offset: 0x0001B53B
		' (set) Token: 0x06002E26 RID: 11814 RVA: 0x0001D345 File Offset: 0x0001B545
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170011FA RID: 4602
		' (get) Token: 0x06002E27 RID: 11815 RVA: 0x0001D34E File Offset: 0x0001B54E
		' (set) Token: 0x06002E28 RID: 11816 RVA: 0x0001D358 File Offset: 0x0001B558
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x170011FB RID: 4603
		' (get) Token: 0x06002E29 RID: 11817 RVA: 0x0001D361 File Offset: 0x0001B561
		' (set) Token: 0x06002E2A RID: 11818 RVA: 0x0001D36B File Offset: 0x0001B56B
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x170011FC RID: 4604
		' (get) Token: 0x06002E2B RID: 11819 RVA: 0x0001D374 File Offset: 0x0001B574
		' (set) Token: 0x06002E2C RID: 11820 RVA: 0x0001D37E File Offset: 0x0001B57E
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x170011FD RID: 4605
		' (get) Token: 0x06002E2D RID: 11821 RVA: 0x0001D387 File Offset: 0x0001B587
		' (set) Token: 0x06002E2E RID: 11822 RVA: 0x0001D391 File Offset: 0x0001B591
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x170011FE RID: 4606
		' (get) Token: 0x06002E2F RID: 11823 RVA: 0x0001D39A File Offset: 0x0001B59A
		' (set) Token: 0x06002E30 RID: 11824 RVA: 0x0001D3A4 File Offset: 0x0001B5A4
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x170011FF RID: 4607
		' (get) Token: 0x06002E31 RID: 11825 RVA: 0x0001D3AD File Offset: 0x0001B5AD
		' (set) Token: 0x06002E32 RID: 11826 RVA: 0x0001D3B7 File Offset: 0x0001B5B7
		Friend Overridable Property txtCustcode As TextBox

		' Token: 0x17001200 RID: 4608
		' (get) Token: 0x06002E33 RID: 11827 RVA: 0x0001D3C0 File Offset: 0x0001B5C0
		' (set) Token: 0x06002E34 RID: 11828 RVA: 0x0001D3CA File Offset: 0x0001B5CA
		Friend Overridable Property txtIDCus As TextBox

		' Token: 0x17001201 RID: 4609
		' (get) Token: 0x06002E35 RID: 11829 RVA: 0x0001D3D3 File Offset: 0x0001B5D3
		' (set) Token: 0x06002E36 RID: 11830 RVA: 0x0001D3DD File Offset: 0x0001B5DD
		Public Overridable Property pbgiftqr As PictureBox

		' Token: 0x17001202 RID: 4610
		' (get) Token: 0x06002E37 RID: 11831 RVA: 0x0001D3E6 File Offset: 0x0001B5E6
		' (set) Token: 0x06002E38 RID: 11832 RVA: 0x0001D3F0 File Offset: 0x0001B5F0
		Friend Overridable Property lblState As Label

		' Token: 0x17001203 RID: 4611
		' (get) Token: 0x06002E39 RID: 11833 RVA: 0x0001D3F9 File Offset: 0x0001B5F9
		' (set) Token: 0x06002E3A RID: 11834 RVA: 0x0001D403 File Offset: 0x0001B603
		Friend Overridable Property lblMobileno As Label

		' Token: 0x17001204 RID: 4612
		' (get) Token: 0x06002E3B RID: 11835 RVA: 0x0001D40C File Offset: 0x0001B60C
		' (set) Token: 0x06002E3C RID: 11836 RVA: 0x001CA900 File Offset: 0x001C8B00
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
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DataGridView2_KeyDown
				Dim dataGridView As DataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
				End If
				Me._DataGridView2 = value
				dataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17001205 RID: 4613
		' (get) Token: 0x06002E3D RID: 11837 RVA: 0x0001D416 File Offset: 0x0001B616
		' (set) Token: 0x06002E3E RID: 11838 RVA: 0x0001D420 File Offset: 0x0001B620
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x17001206 RID: 4614
		' (get) Token: 0x06002E3F RID: 11839 RVA: 0x0001D429 File Offset: 0x0001B629
		' (set) Token: 0x06002E40 RID: 11840 RVA: 0x0001D433 File Offset: 0x0001B633
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x17001207 RID: 4615
		' (get) Token: 0x06002E41 RID: 11841 RVA: 0x0001D43C File Offset: 0x0001B63C
		' (set) Token: 0x06002E42 RID: 11842 RVA: 0x0001D446 File Offset: 0x0001B646
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x17001208 RID: 4616
		' (get) Token: 0x06002E43 RID: 11843 RVA: 0x0001D44F File Offset: 0x0001B64F
		' (set) Token: 0x06002E44 RID: 11844 RVA: 0x0001D459 File Offset: 0x0001B659
		Friend Overridable Property DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn

		' Token: 0x17001209 RID: 4617
		' (get) Token: 0x06002E45 RID: 11845 RVA: 0x0001D462 File Offset: 0x0001B662
		' (set) Token: 0x06002E46 RID: 11846 RVA: 0x0001D46C File Offset: 0x0001B66C
		Friend Overridable Property DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn

		' Token: 0x1700120A RID: 4618
		' (get) Token: 0x06002E47 RID: 11847 RVA: 0x0001D475 File Offset: 0x0001B675
		' (set) Token: 0x06002E48 RID: 11848 RVA: 0x0001D47F File Offset: 0x0001B67F
		Friend Overridable Property DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn

		' Token: 0x1700120B RID: 4619
		' (get) Token: 0x06002E49 RID: 11849 RVA: 0x0001D488 File Offset: 0x0001B688
		' (set) Token: 0x06002E4A RID: 11850 RVA: 0x0001D492 File Offset: 0x0001B692
		Friend Overridable Property DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn

		' Token: 0x1700120C RID: 4620
		' (get) Token: 0x06002E4B RID: 11851 RVA: 0x0001D49B File Offset: 0x0001B69B
		' (set) Token: 0x06002E4C RID: 11852 RVA: 0x0001D4A5 File Offset: 0x0001B6A5
		Friend Overridable Property DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn

		' Token: 0x1700120D RID: 4621
		' (get) Token: 0x06002E4D RID: 11853 RVA: 0x0001D4AE File Offset: 0x0001B6AE
		' (set) Token: 0x06002E4E RID: 11854 RVA: 0x0001D4B8 File Offset: 0x0001B6B8
		Friend Overridable Property DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn

		' Token: 0x1700120E RID: 4622
		' (get) Token: 0x06002E4F RID: 11855 RVA: 0x0001D4C1 File Offset: 0x0001B6C1
		' (set) Token: 0x06002E50 RID: 11856 RVA: 0x0001D4CB File Offset: 0x0001B6CB
		Friend Overridable Property DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn

		' Token: 0x1700120F RID: 4623
		' (get) Token: 0x06002E51 RID: 11857 RVA: 0x0001D4D4 File Offset: 0x0001B6D4
		' (set) Token: 0x06002E52 RID: 11858 RVA: 0x0001D4DE File Offset: 0x0001B6DE
		Friend Overridable Property DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn

		' Token: 0x17001210 RID: 4624
		' (get) Token: 0x06002E53 RID: 11859 RVA: 0x0001D4E7 File Offset: 0x0001B6E7
		' (set) Token: 0x06002E54 RID: 11860 RVA: 0x0001D4F1 File Offset: 0x0001B6F1
		Friend Overridable Property DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn

		' Token: 0x17001211 RID: 4625
		' (get) Token: 0x06002E55 RID: 11861 RVA: 0x0001D4FA File Offset: 0x0001B6FA
		' (set) Token: 0x06002E56 RID: 11862 RVA: 0x0001D504 File Offset: 0x0001B704
		Friend Overridable Property DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn

		' Token: 0x17001212 RID: 4626
		' (get) Token: 0x06002E57 RID: 11863 RVA: 0x0001D50D File Offset: 0x0001B70D
		' (set) Token: 0x06002E58 RID: 11864 RVA: 0x0001D517 File Offset: 0x0001B717
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17001213 RID: 4627
		' (get) Token: 0x06002E59 RID: 11865 RVA: 0x0001D520 File Offset: 0x0001B720
		' (set) Token: 0x06002E5A RID: 11866 RVA: 0x0001D52A File Offset: 0x0001B72A
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17001214 RID: 4628
		' (get) Token: 0x06002E5B RID: 11867 RVA: 0x0001D533 File Offset: 0x0001B733
		' (set) Token: 0x06002E5C RID: 11868 RVA: 0x0001D53D File Offset: 0x0001B73D
		Friend Overridable Property DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn

		' Token: 0x17001215 RID: 4629
		' (get) Token: 0x06002E5D RID: 11869 RVA: 0x0001D546 File Offset: 0x0001B746
		' (set) Token: 0x06002E5E RID: 11870 RVA: 0x0001D550 File Offset: 0x0001B750
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17001216 RID: 4630
		' (get) Token: 0x06002E5F RID: 11871 RVA: 0x0001D559 File Offset: 0x0001B759
		' (set) Token: 0x06002E60 RID: 11872 RVA: 0x0001D563 File Offset: 0x0001B763
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17001217 RID: 4631
		' (get) Token: 0x06002E61 RID: 11873 RVA: 0x0001D56C File Offset: 0x0001B76C
		' (set) Token: 0x06002E62 RID: 11874 RVA: 0x0001D576 File Offset: 0x0001B776
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17001218 RID: 4632
		' (get) Token: 0x06002E63 RID: 11875 RVA: 0x0001D57F File Offset: 0x0001B77F
		' (set) Token: 0x06002E64 RID: 11876 RVA: 0x0001D589 File Offset: 0x0001B789
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17001219 RID: 4633
		' (get) Token: 0x06002E65 RID: 11877 RVA: 0x0001D592 File Offset: 0x0001B792
		' (set) Token: 0x06002E66 RID: 11878 RVA: 0x0001D59C File Offset: 0x0001B79C
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x1700121A RID: 4634
		' (get) Token: 0x06002E67 RID: 11879 RVA: 0x0001D5A5 File Offset: 0x0001B7A5
		' (set) Token: 0x06002E68 RID: 11880 RVA: 0x0001D5AF File Offset: 0x0001B7AF
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x1700121B RID: 4635
		' (get) Token: 0x06002E69 RID: 11881 RVA: 0x0001D5B8 File Offset: 0x0001B7B8
		' (set) Token: 0x06002E6A RID: 11882 RVA: 0x0001D5C2 File Offset: 0x0001B7C2
		Friend Overridable Property DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn

		' Token: 0x1700121C RID: 4636
		' (get) Token: 0x06002E6B RID: 11883 RVA: 0x0001D5CB File Offset: 0x0001B7CB
		' (set) Token: 0x06002E6C RID: 11884 RVA: 0x0001D5D5 File Offset: 0x0001B7D5
		Friend Overridable Property DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn

		' Token: 0x1700121D RID: 4637
		' (get) Token: 0x06002E6D RID: 11885 RVA: 0x0001D5DE File Offset: 0x0001B7DE
		' (set) Token: 0x06002E6E RID: 11886 RVA: 0x0001D5E8 File Offset: 0x0001B7E8
		Friend Overridable Property DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn

		' Token: 0x1700121E RID: 4638
		' (get) Token: 0x06002E6F RID: 11887 RVA: 0x0001D5F1 File Offset: 0x0001B7F1
		' (set) Token: 0x06002E70 RID: 11888 RVA: 0x0001D5FB File Offset: 0x0001B7FB
		Friend Overridable Property DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn

		' Token: 0x1700121F RID: 4639
		' (get) Token: 0x06002E71 RID: 11889 RVA: 0x0001D604 File Offset: 0x0001B804
		' (set) Token: 0x06002E72 RID: 11890 RVA: 0x0001D60E File Offset: 0x0001B80E
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17001220 RID: 4640
		' (get) Token: 0x06002E73 RID: 11891 RVA: 0x0001D617 File Offset: 0x0001B817
		' (set) Token: 0x06002E74 RID: 11892 RVA: 0x0001D621 File Offset: 0x0001B821
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17001221 RID: 4641
		' (get) Token: 0x06002E75 RID: 11893 RVA: 0x0001D62A File Offset: 0x0001B82A
		' (set) Token: 0x06002E76 RID: 11894 RVA: 0x0001D634 File Offset: 0x0001B834
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17001222 RID: 4642
		' (get) Token: 0x06002E77 RID: 11895 RVA: 0x0001D63D File Offset: 0x0001B83D
		' (set) Token: 0x06002E78 RID: 11896 RVA: 0x0001D647 File Offset: 0x0001B847
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17001223 RID: 4643
		' (get) Token: 0x06002E79 RID: 11897 RVA: 0x0001D650 File Offset: 0x0001B850
		' (set) Token: 0x06002E7A RID: 11898 RVA: 0x0001D65A File Offset: 0x0001B85A
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17001224 RID: 4644
		' (get) Token: 0x06002E7B RID: 11899 RVA: 0x0001D663 File Offset: 0x0001B863
		' (set) Token: 0x06002E7C RID: 11900 RVA: 0x0001D66D File Offset: 0x0001B86D
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17001225 RID: 4645
		' (get) Token: 0x06002E7D RID: 11901 RVA: 0x0001D676 File Offset: 0x0001B876
		' (set) Token: 0x06002E7E RID: 11902 RVA: 0x0001D680 File Offset: 0x0001B880
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x17001226 RID: 4646
		' (get) Token: 0x06002E7F RID: 11903 RVA: 0x0001D689 File Offset: 0x0001B889
		' (set) Token: 0x06002E80 RID: 11904 RVA: 0x0001D693 File Offset: 0x0001B893
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x17001227 RID: 4647
		' (get) Token: 0x06002E81 RID: 11905 RVA: 0x0001D69C File Offset: 0x0001B89C
		' (set) Token: 0x06002E82 RID: 11906 RVA: 0x0001D6A6 File Offset: 0x0001B8A6
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x17001228 RID: 4648
		' (get) Token: 0x06002E83 RID: 11907 RVA: 0x0001D6AF File Offset: 0x0001B8AF
		' (set) Token: 0x06002E84 RID: 11908 RVA: 0x0001D6B9 File Offset: 0x0001B8B9
		Friend Overridable Property Column36 As DataGridViewTextBoxColumn

		' Token: 0x17001229 RID: 4649
		' (get) Token: 0x06002E85 RID: 11909 RVA: 0x0001D6C2 File Offset: 0x0001B8C2
		' (set) Token: 0x06002E86 RID: 11910 RVA: 0x0001D6CC File Offset: 0x0001B8CC
		Friend Overridable Property Column37 As DataGridViewTextBoxColumn

		' Token: 0x1700122A RID: 4650
		' (get) Token: 0x06002E87 RID: 11911 RVA: 0x0001D6D5 File Offset: 0x0001B8D5
		' (set) Token: 0x06002E88 RID: 11912 RVA: 0x0001D6DF File Offset: 0x0001B8DF
		Friend Overridable Property Column38 As DataGridViewTextBoxColumn

		' Token: 0x1700122B RID: 4651
		' (get) Token: 0x06002E89 RID: 11913 RVA: 0x0001D6E8 File Offset: 0x0001B8E8
		' (set) Token: 0x06002E8A RID: 11914 RVA: 0x0001D6F2 File Offset: 0x0001B8F2
		Friend Overridable Property Column39 As DataGridViewTextBoxColumn

		' Token: 0x1700122C RID: 4652
		' (get) Token: 0x06002E8B RID: 11915 RVA: 0x0001D6FB File Offset: 0x0001B8FB
		' (set) Token: 0x06002E8C RID: 11916 RVA: 0x0001D705 File Offset: 0x0001B905
		Friend Overridable Property Column40 As DataGridViewTextBoxColumn

		' Token: 0x1700122D RID: 4653
		' (get) Token: 0x06002E8D RID: 11917 RVA: 0x0001D70E File Offset: 0x0001B90E
		' (set) Token: 0x06002E8E RID: 11918 RVA: 0x0001D718 File Offset: 0x0001B918
		Friend Overridable Property Column41 As DataGridViewTextBoxColumn

		' Token: 0x1700122E RID: 4654
		' (get) Token: 0x06002E8F RID: 11919 RVA: 0x0001D721 File Offset: 0x0001B921
		' (set) Token: 0x06002E90 RID: 11920 RVA: 0x0001D72B File Offset: 0x0001B92B
		Friend Overridable Property Column42 As DataGridViewTextBoxColumn

		' Token: 0x1700122F RID: 4655
		' (get) Token: 0x06002E91 RID: 11921 RVA: 0x0001D734 File Offset: 0x0001B934
		' (set) Token: 0x06002E92 RID: 11922 RVA: 0x0001D73E File Offset: 0x0001B93E
		Friend Overridable Property Column43 As DataGridViewTextBoxColumn

		' Token: 0x17001230 RID: 4656
		' (get) Token: 0x06002E93 RID: 11923 RVA: 0x0001D747 File Offset: 0x0001B947
		' (set) Token: 0x06002E94 RID: 11924 RVA: 0x0001D751 File Offset: 0x0001B951
		Friend Overridable Property Column44 As DataGridViewTextBoxColumn

		' Token: 0x17001231 RID: 4657
		' (get) Token: 0x06002E95 RID: 11925 RVA: 0x0001D75A File Offset: 0x0001B95A
		' (set) Token: 0x06002E96 RID: 11926 RVA: 0x0001D764 File Offset: 0x0001B964
		Friend Overridable Property Column45 As DataGridViewTextBoxColumn

		' Token: 0x17001232 RID: 4658
		' (get) Token: 0x06002E97 RID: 11927 RVA: 0x0001D76D File Offset: 0x0001B96D
		' (set) Token: 0x06002E98 RID: 11928 RVA: 0x0001D777 File Offset: 0x0001B977
		Friend Overridable Property Column46 As DataGridViewTextBoxColumn

		' Token: 0x17001233 RID: 4659
		' (get) Token: 0x06002E99 RID: 11929 RVA: 0x0001D780 File Offset: 0x0001B980
		' (set) Token: 0x06002E9A RID: 11930 RVA: 0x0001D78A File Offset: 0x0001B98A
		Friend Overridable Property Column47 As DataGridViewTextBoxColumn

		' Token: 0x17001234 RID: 4660
		' (get) Token: 0x06002E9B RID: 11931 RVA: 0x0001D793 File Offset: 0x0001B993
		' (set) Token: 0x06002E9C RID: 11932 RVA: 0x0001D79D File Offset: 0x0001B99D
		Friend Overridable Property DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn

		' Token: 0x17001235 RID: 4661
		' (get) Token: 0x06002E9D RID: 11933 RVA: 0x0001D7A6 File Offset: 0x0001B9A6
		' (set) Token: 0x06002E9E RID: 11934 RVA: 0x0001D7B0 File Offset: 0x0001B9B0
		Friend Overridable Property Column49 As DataGridViewTextBoxColumn

		' Token: 0x17001236 RID: 4662
		' (get) Token: 0x06002E9F RID: 11935 RVA: 0x0001D7B9 File Offset: 0x0001B9B9
		' (set) Token: 0x06002EA0 RID: 11936 RVA: 0x001CA960 File Offset: 0x001C8B60
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

		' Token: 0x17001237 RID: 4663
		' (get) Token: 0x06002EA1 RID: 11937 RVA: 0x0001D7C3 File Offset: 0x0001B9C3
		' (set) Token: 0x06002EA2 RID: 11938 RVA: 0x0001D7CD File Offset: 0x0001B9CD
		Friend Overridable Property Label6 As Label

		' Token: 0x17001238 RID: 4664
		' (get) Token: 0x06002EA3 RID: 11939 RVA: 0x0001D7D6 File Offset: 0x0001B9D6
		' (set) Token: 0x06002EA4 RID: 11940 RVA: 0x001CA9A4 File Offset: 0x001C8BA4
		Private _btnUpdate_Lead As Button
		Friend Overridable Property btnUpdate_Lead As Button
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate_Lead
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Lead_Click
				Dim button As Button = Me._btnUpdate_Lead
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnUpdate_Lead = value
				button = Me._btnUpdate_Lead
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x06002EA5 RID: 11941 RVA: 0x0001D7E0 File Offset: 0x0001B9E0
		Private Sub frmFollowUp_Lead_Load(sender As Object, e As EventArgs)
			Me.LoadTimeList()
			Me.Reset()
			Me.Getdata()
			Me.Getdata_Quotation()
		End Sub

		' Token: 0x06002EA6 RID: 11942 RVA: 0x001CA9E8 File Offset: 0x001C8BE8
		Public Sub Getdata_Quotation()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2, Invoiceinfo_Quotation.lead_id   from Invoiceinfo_Quotation " & vbCrLf & "LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID " & vbCrLf & "Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID " & vbCrLf & "Left join tbl_lead_master on CAST(tbl_lead_master.id AS nvarchar(20))  = Invoiceinfo_Quotation.lead_id " & vbCrLf & "where tbl_lead_master.id=@d1 order by InvoiceDate", ModCommonClasses.con)
				Else
					ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, RTRIM(TaxType), Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Customer.Name),RTRIM(Customer.ContactNo),RTRIM(Customer.State),RTRIM(Customer.GSTIN),SM_ID,RTRIM(Salesman.Salesman_ID),RTRIM(Salesman.Name), SubTotal, CGST, SGST, IGST, CESS,FreightCharges,OtherCharges,Total,RoundOff, GrandTotal, TotalPaid, Balance, RTRIM(Invoiceinfo_Quotation.Remarks), RTRIM(Narration), RTRIM(Eway), RTRIM(TillID), RTRIM(Operator), RTRIM(BillSundry), RTRIM(OfferAmt), RTRIM(LoyaAmt),RTRIM(BillDiscount),RTRIM(Customer.City),Tender, Refund, BillCash, CouponAmt, GiftAmt,(Customer.Address),SRNumber,ByReturn,TotalLoyalityPoints, LoyalityReedemPoints, LoyalityReedemAmt, (case when Invoiceinfo_Quotation.Status=0 then 'Pending' else 'Generated' end) as Status,Inv_ID2, Invoiceinfo_Quotation.lead_id   from Invoiceinfo_Quotation " & vbCrLf & "LEFT Join Customer ON Invoiceinfo_Quotation.Customer_ID = Customer.ID " & vbCrLf & "Left Join Salesman ON Invoiceinfo_Quotation.SalesmanID=Salesman.SM_ID " & vbCrLf & "Left join tbl_lead_master on CAST(tbl_lead_master.id AS nvarchar(20))  = Invoiceinfo_Quotation.lead_id " & vbCrLf & "where tbl_lead_master.id=@d1 and Operator=@d2 order by InvoiceDate", ModCommonClasses.con)
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.Int).Value = Conversion.Val(Me.lbl_Id.Text)
				Dim flag2 As Boolean = Operators.CompareString(Me.lblUser.Text, "admin", False) <> 0
				If flag2 Then
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.VarChar).Value = Me.lblUser.Text
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView2.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim num As Integer = Me.DataGridView2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41), ModCommonClasses.rdr(42), ModCommonClasses.rdr(43), ModCommonClasses.rdr(44), ModCommonClasses.rdr(45), ModCommonClasses.rdr(46), ModCommonClasses.rdr(47), ModCommonClasses.rdr(48) })
					Me.ApplyRowColor(Me.DataGridView2.Rows(num), ModCommonClasses.rdr(46).ToString())
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView2.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002EA7 RID: 11943 RVA: 0x00141E1C File Offset: 0x0014001C
		Private Sub ApplyRowColor(row As DataGridViewRow, status As String)
			Dim flag As Boolean = Operators.CompareString(status, "Pending", False) = 0
			If flag Then
				row.DefaultCellStyle.BackColor = Color.Red
				row.DefaultCellStyle.ForeColor = Color.White
			Else
				row.DefaultCellStyle.BackColor = Color.LightGreen
				row.DefaultCellStyle.ForeColor = Color.Black
			End If
		End Sub

		' Token: 0x06002EA8 RID: 11944 RVA: 0x001CAEB0 File Offset: 0x001C90B0
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT a.lead_id id, a.lead_status, b.lead_id," & vbCrLf & "CONVERT(VARCHAR(11), a.reminder_date, 106) + ' ' + " & vbCrLf & "    RIGHT('0' + LTRIM(RIGHT(CONVERT(VARCHAR(20), a.reminder_time, 100), 7)), 7) AS reminder_datetime," & vbCrLf & "a.remarks, b.customer_name,b.mobile,b.state, b.productname, a.followup_by, a.followup_date, a.reminder_date, a.reminder_time, a.followup_id, a.rating" & vbCrLf & "from tbl_followup_lead a" & vbCrLf & "inner join tbl_lead_master b on a.lead_id = b.id where a.lead_id= '" + Me.lbl_Id.Text + "' order by a.followup_date desc", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim text As String = ""
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(8)))
					If flag Then
						Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(14)))
						text = New String("★"c, num) + New String("☆"c, 5 - num)
					End If
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), text, ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002EA9 RID: 11945 RVA: 0x001CB0EC File Offset: 0x001C92EC
		Private Sub LoadTimeList()
			Me.cmbTime.Items.Clear()
			Dim num As Integer = 0
			Do
				Dim num2 As Integer = 0
				Do
					Me.cmbTime.Items.Add(String.Format("{0:D2}:{1:D2}", num, num2))
					num2 += 15
				Loop While num2 <= 45
				num += 1
			Loop While num <= 23
			Me.cmbTime.SelectedIndex = Me.cmbTime.FindStringExact(DateTime.Now.ToString("HH:mm"))
		End Sub

		' Token: 0x06002EAA RID: 11946 RVA: 0x001CB174 File Offset: 0x001C9374
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.lbl_Id.Text)) = 0
			If flag Then
				MessageBox.Show("Please Select Lead", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.txtRemarks.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please write remarks", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtRemarks.Focus()
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.cmbRating.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please Rate this Follow-Up", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbRating.Focus()
					Else
						Dim flag4 As Boolean = Me.cmbTime.SelectedIndex = -1
						If flag4 Then
							MessageBox.Show("Please select Time", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.cmbTime.Focus()
						Else
							Try
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text As String = "INSERT INTO tbl_followup_lead " & vbCrLf & "    (lead_id, remarks, followup_date, lead_status, reminder_date, reminder_time, followup_by, rating) " & vbCrLf & "    VALUES (@lead_id, @remarks, @followup_date, @lead_status, @reminder_date, @reminder_time, @followup_by, @rating)"
								ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.AddWithValue("@lead_id", Conversions.ToInteger(Me.lbl_Id.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@remarks", Me.txtRemarks.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@followup_date", DateTime.Now)
								ModCommonClasses.cmd.Parameters.AddWithValue("@lead_status", Me.cboxStatus.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@reminder_date", RuntimeHelpers.GetObjectValue(If(Me.dtpReminderDate.Checked, Me.dtpReminderDate.Value.[Date], DBNull.Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@reminder_time", RuntimeHelpers.GetObjectValue(If((Operators.CompareString(Me.cmbTime.Text, "", False) <> 0), TimeSpan.Parse(Me.cmbTime.Text), DBNull.Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@followup_by", Me.lblUser.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@rating", Me.cmbRating.Text)
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.con.Close()
								MessageBox.Show("Successfully Saved", "Follow_Up Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.Getdata()
								Me.btnSave.Enabled = False
								Me.Reset()
							Catch ex As Exception
								MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06002EAB RID: 11947 RVA: 0x001CB494 File Offset: 0x001C9694
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmFollowUp_LeadRecords.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmFollowUp_LeadRecords.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmFollowUp_LeadRecords.ShowDialog()
			MyProject.Forms.frmFollowUp_LeadRecords.Dispose()
		End Sub

		' Token: 0x06002EAC RID: 11948 RVA: 0x001CB504 File Offset: 0x001C9704
		Public Sub Reset()
			Me.txtRemarks.Text = ""
			Me.cboxStatus.SelectedIndex = 1
			Me.dtpReminderDate.Text = ""
			Me.cmbTime.SelectedIndex = 0
			Me.cmbRating.SelectedIndex = 0
			Me.lblFollowupID.Text = ""
			Me.btnSave.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.btnDelete.Enabled = False
		End Sub

		' Token: 0x06002EAD RID: 11949 RVA: 0x0001D7FF File Offset: 0x0001B9FF
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x06002EAE RID: 11950 RVA: 0x001CB594 File Offset: 0x001C9794
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
					Me.lbl_Id.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.cboxStatus.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtLead_Id.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtCustomerName.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.txtRemarks.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.dtpReminderDate.Text = dataGridViewRow.Cells(11).Value.ToString()
					Dim flag2 As Boolean = dataGridViewRow.Cells(12).Value IsNot Nothing AndAlso Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(12).Value))
					If flag2 Then
						Dim timeSpan As TimeSpan = TimeSpan.Parse(dataGridViewRow.Cells(12).Value.ToString())
						Me.cmbTime.Text = timeSpan.ToString("hh\:mm")
					End If
					Me.lblFollowupID.Text = dataGridViewRow.Cells(13).Value.ToString()
					Me.cmbRating.Text = dataGridViewRow.Cells(15).Value.ToString()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06002EAF RID: 11951 RVA: 0x001CB7AC File Offset: 0x001C99AC
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "UPDATE tbl_followup_lead " & vbCrLf & "                        SET remarks = @remarks, " & vbCrLf & "                            followup_date = @followup_date, " & vbCrLf & "                            lead_status = @lead_status, " & vbCrLf & "                            reminder_date = @reminder_date, " & vbCrLf & "                            reminder_time = @reminder_time," & vbCrLf & "                            followup_by = @followup_by," & vbCrLf & "                               rating = @rating" & vbCrLf & "                        WHERE followup_id = @followup_id"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@remarks", Me.txtRemarks.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@followup_date", DateTime.Now)
				ModCommonClasses.cmd.Parameters.AddWithValue("@lead_status", Me.cboxStatus.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@reminder_date", Me.dtpReminderDate.Value)
				ModCommonClasses.cmd.Parameters.AddWithValue("@reminder_time", RuntimeHelpers.GetObjectValue(If((Operators.CompareString(Me.cmbTime.Text, "", False) <> 0), TimeSpan.Parse(Me.cmbTime.Text), DBNull.Value)))
				ModCommonClasses.cmd.Parameters.AddWithValue("@followup_by", Me.lblUser.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@followup_id", Conversions.ToInteger(Me.lblFollowupID.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@rating", Conversions.ToInteger(Me.cmbRating.Text))
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
				MessageBox.Show("Successfully Updated", "Follow_Up Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Me.Getdata()
				Me.btnUpdate.Enabled = False
				Me.Reset()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002EB0 RID: 11952 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06002EB1 RID: 11953 RVA: 0x0001D809 File Offset: 0x0001BA09
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06002EB2 RID: 11954 RVA: 0x001CB9C4 File Offset: 0x001C9BC4
		Private Sub btnQuotation_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to Generate Quotation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					MyProject.Forms.frmPOSNewTuch_Quotation.lblUser.Text = Me.lblUser.Text
					MyProject.Forms.frmPOSNewTuch_Quotation.lblUserType.Text = Me.lblUserType.Text
					MyProject.Forms.frmPOSNewTuch_Quotation.lblLQS.Text = "Lead"
					MyProject.Forms.frmPOSNewTuch_Quotation.lblLead_Id.Text = Me.lbl_Id.Text
					MyProject.Forms.frmPOSNewTuch_Quotation.ShowDialog()
					MyProject.Forms.frmPOSNewTuch_Quotation.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002EB3 RID: 11955 RVA: 0x001CBAC4 File Offset: 0x001C9CC4
		Public Sub LeadDataFetch()
			Try
				Dim flag As Boolean = Operators.CompareString(Me.lbl_Id.Text, "", False) <> 0
				If flag Then
					Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
						sqlConnection.Open()
						Dim text As String = "SELECT [id], [customer_name], [mobile], [state], [address], [alloted_user] " & vbCrLf & "                                    FROM [tbl_lead_master] " & vbCrLf & "                                    WHERE id=@d1"
						Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
							sqlCommand.Parameters.AddWithValue("@d1", Me.lbl_Id.Text)
							Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
								Dim flag2 As Boolean = sqlDataReader.Read()
								If flag2 Then
									Dim text2 As String = sqlDataReader("customer_name").ToString().Trim() + "_" + sqlDataReader("mobile").ToString().Trim()
									Dim text3 As String = sqlDataReader("mobile").ToString().Trim()
									sqlDataReader.Close()
									Dim flag3 As Boolean = Operators.CompareString(text2, "", False) <> 0 OrElse Operators.CompareString(text3, "", False) <> 0
									If flag3 Then
										Dim flag4 As Boolean = False
										Dim text4 As String = "SELECT RTRIM(ID), RTRIM(Name), RTRIM(ContactNo), RTRIM(State) " & vbCrLf & "                                                     FROM Customer " & vbCrLf & "                                                     WHERE Name=@d1"
										Using sqlCommand2 As SqlCommand = New SqlCommand(text4, sqlConnection)
											sqlCommand2.Parameters.AddWithValue("@d1", text2)
											Using sqlDataReader2 As SqlDataReader = sqlCommand2.ExecuteReader()
												Dim flag5 As Boolean = sqlDataReader2.Read()
												If flag5 Then
													Me.FillCustomerFromReader(sqlDataReader2)
													flag4 = True
												End If
											End Using
										End Using
										Dim flag6 As Boolean = Not flag4 AndAlso Operators.CompareString(text3, "", False) <> 0
										If flag6 Then
											Dim text5 As String = "SELECT RTRIM(ID), RTRIM(Name), RTRIM(ContactNo), RTRIM(State) " & vbCrLf & "                                                         FROM Customer " & vbCrLf & "                                                         WHERE ContactNo=@d1"
											Using sqlCommand3 As SqlCommand = New SqlCommand(text5, sqlConnection)
												sqlCommand3.Parameters.AddWithValue("@d1", text3)
												Using sqlDataReader3 As SqlDataReader = sqlCommand3.ExecuteReader()
													Dim flag7 As Boolean = sqlDataReader3.Read()
													If flag7 Then
														Me.FillCustomerFromReader(sqlDataReader3)
														flag4 = True
													End If
												End Using
											End Using
										End If
										Dim flag8 As Boolean = Not flag4
										If flag8 Then
											Me.InsertCustomer()
										End If
									Else
										MessageBox.Show("Customer name and/or number cannot be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									End If
								End If
							End Using
						End Using
					End Using
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002EB4 RID: 11956 RVA: 0x00163144 File Offset: 0x00161344
		Private Sub FillCustomerFromReader(rdr As SqlDataReader)
			MyProject.Forms.frmPOSNewTuch.txtCID.Text = rdr(0).ToString()
			MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Text = rdr(1).ToString()
			MyProject.Forms.frmPOSNewTuch.txtContactNo.Text = rdr(2).ToString()
			MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Text = rdr(3).ToString()
			MyProject.Forms.frmPOSNewTuch.GridGetCustomer.Visible = False
			MessageBox.Show("Entered customer is already registered", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
		End Sub

		' Token: 0x06002EB5 RID: 11957 RVA: 0x001CBE18 File Offset: 0x001CA018
		Public Sub InsertCustomer()
			Me.autoCust()
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtCustomerName.Text)) = 0
			If flag Then
				MessageBox.Show("Please enter Customer name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.lblState.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please select state", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.lblMobileno.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please Enter Contact No.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Try
							Dim flag4 As Boolean = Operators.CompareString(Me.txtCustomerName.Text, "", False) = 0
							If flag4 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text As String = "select RTRIM(Name) from Customer where Name=@d1"
								ModCommonClasses.cmd = New SqlCommand(text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustomerName.Text + "_" + Me.lblMobileno.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
								If flag5 Then
									MessageBox.Show("Entered name is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag6 Then
										ModCommonClasses.rdr.Close()
									End If
									Return
								End If
								ModCommonClasses.con.Close()
							End If
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "select RTRIM(ContactNo) from Customer where ContactNo=@d1"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.lblMobileno.Text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
							If flag7 Then
								MessageBox.Show("Entered contact no. is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag8 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "insert into Customer(ID, CustomerID, [Name], Address, City, ContactNo, EmailID,Remarks,State,ZipCode,GSTIN,CIN,PAN,AccountName,AccountNumber,Bank,Branch,IFSCCode,Optype,Opbal,Photo,Tcs,Limit,Lstatus,Route,Taround,DiscPer,DiscStatus,QrCustomer) VALUES (@d1,@d2,@d3,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@qr)"
								ModCommonClasses.cmd = New SqlCommand(text3)
								Me.Generate_GiftQR(Me.lblMobileno.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtIDCus.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtCustcode.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtCustomerName.Text + "_" + Me.lblMobileno.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", "local")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", "localcity")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.lblMobileno.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", "abc@gmail.com")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.lblState.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d11", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", "")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d14", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d16", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d17", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d18", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d19", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d20", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d21", "Cr")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Conversion.Val("0.00"))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d24", "No")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d25", Conversion.Val("0.00"))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d26", "No")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d27", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d28", Conversion.Val("0"))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d29", Conversion.Val("0"))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d30", "No")
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								Dim memoryStream As MemoryStream = New MemoryStream()
								Dim bitmap As Bitmap = New Bitmap(Me.pbgiftqr.Image)
								bitmap.Save(memoryStream, ImageFormat.Jpeg)
								Dim buffer As Byte() = memoryStream.GetBuffer()
								Dim sqlParameter As SqlParameter = New SqlParameter("@d23", SqlDbType.Image)
								sqlParameter.Value = buffer
								ModCommonClasses.cmd.Parameters.Add(sqlParameter)
								Dim memoryStream2 As MemoryStream = New MemoryStream()
								Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
								bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
								Dim buffer2 As Byte() = memoryStream2.GetBuffer()
								Dim sqlParameter2 As SqlParameter = New SqlParameter("@qr", SqlDbType.Image)
								sqlParameter2.Value = buffer2
								ModCommonClasses.cmd.Parameters.Add(sqlParameter2)
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.con.Close()
								ModFunc.LedgerSave(DateAndTime.Today, Me.txtCustomerName.Text + "_" + Me.lblMobileno.Text, Me.txtCustcode.Text, "Opening Balance", 0D, New Decimal(Conversion.Val("0.00")), Me.txtCustcode.Text, Me.txtCustomerName.Text + "_" + Me.lblMobileno.Text)
								ModFunc.CustomerLedgerSave(DateAndTime.Today, Me.txtCustomerName.Text + "_" + Me.lblMobileno.Text, Me.txtCustcode.Text, "Opening Balance", 0D, New Decimal(Conversion.Val("0.00")), Me.txtCustcode.Text, Me.txtCustcode.Text, String.Empty)
								ModFunc.LogFunc(Me.lblUser.Text, "added the new Customer having Customer id '" + Me.txtCustcode.Text + "'")
								MyProject.Forms.frmPOSNewTuch.txtCID.Text = Me.txtIDCus.Text
								MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Text = Me.txtCustomerName.Text
								MyProject.Forms.frmPOSNewTuch.txtContactNo.Text = Me.lblMobileno.Text
								MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Text = Me.lblState.Text
								MyProject.Forms.frmPOSNewTuch.GridGetCustomer.Visible = False
							End If
						Catch ex As Exception
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x06002EB6 RID: 11958 RVA: 0x001CC698 File Offset: 0x001CA898
		Public Sub autoCust()
			Try
				Me.txtIDCus.Text = Me.GenerateIDCus()
				Me.txtCustcode.Text = "C-" + Me.GenerateIDCus()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002EB7 RID: 11959 RVA: 0x00163AF4 File Offset: 0x00161CF4
		Private Function GenerateIDCus() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ID FROM Customer ORDER BY ID DESC", ModCommonClasses.con)
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

		' Token: 0x06002EB8 RID: 11960 RVA: 0x001CC70C File Offset: 0x001CA90C
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06002EB9 RID: 11961 RVA: 0x0001D813 File Offset: 0x0001BA13
		Private Sub DataGridView2_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData_LQ()
		End Sub

		' Token: 0x06002EBA RID: 11962 RVA: 0x001CC790 File Offset: 0x001CA990
		Public Sub RetrieveData_LQ()
			Try
				Dim flag As Boolean = Me.DataGridView2.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.SelectedRows(0)
					MyProject.Forms.frmPOSNewTuch_Quotation.Show()
					MyProject.Forms.frmPOSNewTuch_Quotation.Label207.Text = "edit"
					MyProject.Forms.frmPOSNewTuch_Quotation.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtInvoiceNo.Text = dataGridViewRow.Cells(1).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.dtpInvoiceDate.Text = dataGridViewRow.Cells(2).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtGSTNonGST.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.TextBox7.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtCustomerID.Text = dataGridViewRow.Cells(5).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.Label202.Text = dataGridViewRow.Cells(5).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtCID.Text = dataGridViewRow.Cells(4).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
					Dim flag2 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Text.Trim(), "Cash", False) = 0
					If flag2 Then
						MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerState.Text = MyProject.Forms.frmPOSNewTuch_Quotation.txtCompanyState.Text
					Else
						MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerState.Text = dataGridViewRow.Cells(8).Value.ToString()
					End If
					MyProject.Forms.frmPOSNewTuch_Quotation.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtSM_ID.Text = dataGridViewRow.Cells(10).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtSalesmanID.Text = dataGridViewRow.Cells(11).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtSalesman.Text = dataGridViewRow.Cells(12).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtSubTotal.Text = dataGridViewRow.Cells(13).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtCGST.Text = dataGridViewRow.Cells(14).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtSGST.Text = dataGridViewRow.Cells(15).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtIGST.Text = dataGridViewRow.Cells(16).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtCESS.Text = dataGridViewRow.Cells(17).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtFreightCharges.Text = dataGridViewRow.Cells(18).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtBillDiscount.Text = dataGridViewRow.Cells(19).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtTotal.Text = dataGridViewRow.Cells(20).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtRoundOff.Text = dataGridViewRow.Cells(21).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtGrandTotal.Text = dataGridViewRow.Cells(22).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtTotalPayment.Text = dataGridViewRow.Cells(23).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtPaymentDue.Text = dataGridViewRow.Cells(24).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtNar.Text = dataGridViewRow.Cells(26).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txteway.Text = dataGridViewRow.Cells(27).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.cmbBSundry.Text = dataGridViewRow.Cells(30).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtOffer.Text = dataGridViewRow.Cells(31).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtApplyPoint.Text = dataGridViewRow.Cells(32).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtLAmt.Text = dataGridViewRow.Cells(32).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtbilldisc.Text = dataGridViewRow.Cells(33).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtTCSdbl.Text = dataGridViewRow.Cells(18).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtTendAmt.Text = dataGridViewRow.Cells(35).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtRefAmt.Text = dataGridViewRow.Cells(36).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtBillAmt.Text = dataGridViewRow.Cells(37).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.CAddress = dataGridViewRow.Cells(40).Value.ToString()
					Dim flag3 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(32).Value, 0, False)
					If flag3 Then
						MyProject.Forms.frmPOSNewTuch_Quotation.cb1.Checked = True
					Else
						MyProject.Forms.frmPOSNewTuch_Quotation.cb1.Checked = False
					End If
					MyProject.Forms.frmPOSNewTuch_Quotation.txtCoupAmt.Text = dataGridViewRow.Cells(38).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtgiftamt.Text = dataGridViewRow.Cells(39).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtByReturn.Text = dataGridViewRow.Cells(42).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.txtTotalLoyality_points.Text = dataGridViewRow.Cells(43).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.lblTPoints1.Text = dataGridViewRow.Cells(44).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.lblTPointsAmt1.Text = dataGridViewRow.Cells(45).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.TextBox43.Text = dataGridViewRow.Cells(45).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.lblQ_Status.Text = dataGridViewRow.Cells(46).Value.ToString()
					MyProject.Forms.frmPOSNewTuch_Quotation.btnSave.Enabled = False
					MyProject.Forms.frmPOSNewTuch_Quotation.btnPrint.Enabled = True
					MyProject.Forms.frmPOSNewTuch_Quotation.Button5.Enabled = True
					MyProject.Forms.frmPOSNewTuch_Quotation.Button6.Enabled = True
					MyProject.Forms.frmPOSNewTuch_Quotation.txtOffer.Text = "0.00"
					MyProject.Forms.frmPOSNewTuch_Quotation.btnUpdate.Enabled = True
					MyProject.Forms.frmPOSNewTuch_Quotation.btnDelete.Enabled = True
					MyProject.Forms.frmPOSNewTuch_Quotation.lblSet.Text = "Not Allowed"
					MyProject.Forms.frmPOSNewTuch_Quotation.btnAdd.Enabled = True
					MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Enabled = False
					MyProject.Forms.frmPOSNewTuch_Quotation.txtContactNo.[ReadOnly] = True
					MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerState.Enabled = False
					MyProject.Forms.frmPOSNewTuch_Quotation.btnCustomerSelection.Enabled = False
					MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Enabled = False
					MyProject.Forms.frmPOSNewTuch_Quotation.TextBox15.[ReadOnly] = True
					MyProject.Forms.frmPOSNewTuch_Quotation.Label82.Enabled = False
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(InvoiceInfo_Product_Quotation.Barcode),InvoiceInfo_Product_Quotation.Qty, InvoiceInfo_Product_Quotation.SalesRate,InvoiceInfo_Product_Quotation.DiscountPer, InvoiceInfo_Product_Quotation.Discount, InvoiceInfo_Product_Quotation.CGSTPer, InvoiceInfo_Product_Quotation.CGSTAmt, InvoiceInfo_Product_Quotation.SGSTPer, InvoiceInfo_Product_Quotation.SGSTAmt, InvoiceInfo_Product_Quotation.IGSTPer,InvoiceInfo_Product_Quotation. IGSTAmt, InvoiceInfo_Product_Quotation.CESSPer,InvoiceInfo_Product_Quotation. CESSAmt,InvoiceInfo_Product_Quotation. TotalAmount,InvoiceInfo_Product_Quotation. PurchaseRate,InvoiceInfo_Product_Quotation. Margin,InvoiceInfo_Product_Quotation.Descr,InvoiceInfo_Product_Quotation.Qty,RTRIM(InvoiceInfo_Product_Quotation.IM1),RTRIM(InvoiceInfo_Product_Quotation.IM2),(InvoiceInfo_Product_Quotation.MRP),(InvoiceInfo_Product_Quotation.TaxableAmt),(InvoiceInfo_Product_Quotation.AltQty),(InvoiceInfo_Product_Quotation.AltUnit),(InvoiceInfo_Product_Quotation.STaxType),(InvoiceInfo_Product_Quotation.TotalMRP),(InvoiceInfo_Product_Quotation.PromoQty),RTRIM(InvoiceInfo_Product_Quotation.MainUnit),RTRIM(InvoiceInfo_Product_Quotation.Batch),RTRIM(InvoiceInfo_Product_Quotation.Mfg),RTRIM(InvoiceInfo_Product_Quotation.Exp),RTRIM(InvoiceInfo_Product_Quotation.Size),RTRIM(InvoiceInfo_Product_Quotation.Colour),InvoiceInfo_Product_Quotation.SalesManID,InvoiceInfo_Product_Quotation.SalesMan,InvoiceInfo_Product_Quotation.SalesManPur,InvoiceInfo_Product_Quotation.SalesManComm ,InvoiceInfo_Product_Quotation.StockID, InvoiceInfo_Product_Quotation.LoyalityPoints from InvoiceInfo_Quotation,InvoiceInfo_Product_Quotation,Product where InvoiceInfo_Quotation.Inv_ID=InvoiceInfo_Product_Quotation.InvoiceID and Product.PID=InvoiceInfo_Product_Quotation.ProductID and InvoiceInfo_Quotation.Inv_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), MyProject.Forms.frmPOSNewTuch_Quotation.GetProductImage(CInt(Convert.ToInt16(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(0))))), ModCommonClasses.rdr(40), ModCommonClasses.rdr(41) })
					End While
					MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView1.ClearSelection()
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoiceinfo_Product_Quotation.Barcode),Invoiceinfo_Product_Quotation.Qty, Invoiceinfo_Product_Quotation.SalesRate,Invoiceinfo_Product_Quotation.DiscountPer, Invoiceinfo_Product_Quotation.Discount, Invoiceinfo_Product_Quotation.CGSTPer, Invoiceinfo_Product_Quotation.CGSTAmt, Invoiceinfo_Product_Quotation.SGSTPer, Invoiceinfo_Product_Quotation.SGSTAmt, Invoiceinfo_Product_Quotation.IGSTPer,Invoiceinfo_Product_Quotation. IGSTAmt, Invoiceinfo_Product_Quotation.CESSPer,Invoiceinfo_Product_Quotation. CESSAmt,Invoiceinfo_Product_Quotation. TotalAmount,Invoiceinfo_Product_Quotation. PurchaseRate,Invoiceinfo_Product_Quotation. Margin from Invoiceinfo_Quotation,Invoiceinfo_Product_Quotation,Product where Invoiceinfo_Quotation.Inv_ID=Invoiceinfo_Product_Quotation.InvoiceID and Product.PID=Invoiceinfo_Product_Quotation.ProductID and Invoiceinfo_Quotation.Inv_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView3.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView3.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18) })
					End While
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text3 As String = "SELECT a.productid AS PID, RTRIM(b.ProductCode) AS Productcode, RTRIM(b.ProductName) AS ProductName, a.barcode AS Barcode, a.serialno" & vbCrLf & "                              FROM tbl_product_serial_sale a" & vbCrLf & "                              INNER JOIN product b ON a.productid = b.pid where a.invoice_no=@d1"
					ModCommonClasses.cmd = New SqlCommand(text3, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView5.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView5.Visible = True
						MyProject.Forms.frmPOSNewTuch_Quotation.DataGridView5.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4) })
					End While
					ModCommonClasses.con.Close()
					MyProject.Forms.frmPOSNewTuch_Quotation.CustomerBalance_Loyality()
					MyProject.Forms.frmPOSNewTuch_Quotation.Calc()
					MyProject.Forms.frmPOSNewTuch_Quotation.Compute()
					MyProject.Forms.frmPOSNewTuch_Quotation.alldiscountcalc()
					MyProject.Forms.frmPOSNewTuch_Quotation.Bankcondn()
					MyProject.Forms.frmPOSNewTuch_Quotation.totitemnqty()
					MyProject.Forms.frmPOSNewTuch_Quotation.btnSelectSalesman.Enabled = False
					MyProject.Forms.frmPOSNewTuch_Quotation.btnListReset1.PerformClick()
					MyProject.Forms.frmPOSNewTuch_Quotation.Calculate12345()
					MyProject.Forms.frmPOSNewTuch_Quotation.Calculate143()
					Dim flag4 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch_Quotation.cmbBSundry.Text, "TCS", False) = 0
					If flag4 Then
						MyProject.Forms.frmPOSNewTuch_Quotation.txtTCSdbl.[ReadOnly] = True
					Else
						MyProject.Forms.frmPOSNewTuch_Quotation.txtTCSdbl.[ReadOnly] = True
						MyProject.Forms.frmPOSNewTuch_Quotation.txtTCSdbl.Text = "0"
					End If
					MyProject.Forms.frmPOSNewTuch_Quotation.CTypeStatus()
					MyProject.Forms.frmPOSNewTuch_Quotation.BrokerRetrive()
					MyProject.Forms.frmPOSNewTuch_Quotation.CheckBox11.Checked = False
					MyProject.Forms.frmPOSNewTuch_Quotation.txtInvoiceNo.[ReadOnly] = True
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002EBB RID: 11963 RVA: 0x001CDA78 File Offset: 0x001CBC78
		Private Sub DataGridView2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData_LQ()
			End If
		End Sub

		' Token: 0x06002EBC RID: 11964 RVA: 0x0001D81D File Offset: 0x0001BA1D
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Getdata()
			Me.Getdata_Quotation()
		End Sub

		' Token: 0x06002EBD RID: 11965 RVA: 0x001CDAA0 File Offset: 0x001CBCA0
		Private Sub btnUpdate_Lead_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmLead_Update.lbl_Id.Text = Me.lbl_Id.Text
			MyProject.Forms.frmLead_Update.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmLead_Update.lblUserType.Text = Me.lblUserType.Text
			MyBase.Hide()
			MyProject.Forms.frmLead_Update.ShowDialog()
			MyBase.Show()
		End Sub

		' Token: 0x06002EBE RID: 11966 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmFollowUp_Lead_FormClosing(sender As Object, e As FormClosingEventArgs)
		End Sub
	End Class
End Namespace
